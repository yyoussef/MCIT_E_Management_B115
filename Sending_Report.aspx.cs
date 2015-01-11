using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Text;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Net.Mail;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Globalization;
using ReportsClass;


public partial class Sending_Report : System.Web.UI.Page
{
    string main_sql, sql_act,sql_arc,sql_arc_late;
    const string Mona = "mdarwish@mcit.gov.eg";
    const string youssef = "yyoussef@mcit.gov.eg";
    const string asalaheldin = "asalaheldin@mcit.gov.eg";
    const string rabdelghafar = "rabdelghafar@mcit.gov.eg";
    const string Sbeih = "Sbeih@mcit.gov.eg";
//    Session_CS Session_CS = new Session_CS();
    private string sql_Connection = Database.ConnectionString;
    // private string sql_Connection = Universal.GetConnectionString();

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {


            fun_act();

            fun_archiving_inbox();
            fun_archiving_Outbox();
            fun_archiving_Com();
            fun_finance();

            Update_Employee_permission();

             fun_needs();
            //Test_Send_Mail();
        }


    }
    void fun_archiving_inbox()
    {
        string todayplus2late = VB_Classes.Dates.Dates_Operation.date_validate(CDataConverter.ConvertDateTimeToFormatdmy(CDataConverter.ConvertDateTimeNowRtnDt().AddDays(2)));
        DataTable dt = General_Helping.GetDataTable("select * from employee where rol_rol_id=3");
        main_sql = "set dateformat dmy select * from inbox_Report_view where 1=1 ";
        //string[] files = Directory.GetFiles(Server.MapPath("Uploads/archive"));
        //foreach (string file in files)
        //{
        //    File.Delete(file);
        //}
        for (int i = 0; i < dt.Rows.Count; i++)
        {
           
           
            ///////////// old inbox
            sql_arc = main_sql + " and inbox_Report_view.Inbox_Status=2 and inbox_Report_view.Emp_id = " + CDataConverter.ConvertToInt(dt.Rows[i]["pmp_id"].ToString()) + " order by inbox_Report_view.follow_id asc";
            DataTable dt_arc = General_Helping.GetDataTable(sql_arc);
            ReportDocument rd = new ReportDocument();
           
           
            #region mail
            if (dt_arc.Rows.Count>0)
            {
                string s = Server.MapPath("Reports/General_inbox_Report.rpt");
                rd.Load(s);
                rd.SetDataSource(dt_arc);
                Reports.Load_Report(rd);
                rd.SetParameterValue("@Report_name", "الوارد الجاري لمديري الادارات");
                rd.SetParameterValue("@pmp_id", CDataConverter.ConvertToInt(dt.Rows[i]["pmp_id"].ToString()), "Header_Eval_Report.rpt");
                rd.SetParameterValue("@pmp_id", CDataConverter.ConvertToInt(dt.Rows[i]["pmp_id"].ToString()));
                rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
                rd.SetParameterValue("@user", "automatic Report", "footerRep.rpt");
                //string exportname = "ACT_Report.rpt";
                string exportpath = Server.MapPath("Uploads/archive/inbox_Old" + i + ".pdf");
                ExportOptions crExportOptions;
                DiskFileDestinationOptions crDestOptions = new DiskFileDestinationOptions();
                crDestOptions.DiskFileName = exportpath;
                crExportOptions = rd.ExportOptions;
                crExportOptions.DestinationOptions = crDestOptions;
                crExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                crExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                crExportOptions.Clone();
                rd.Export(crExportOptions);
                MailMessage _Message = new MailMessage();
                _Message.Subject = "الخدمات الإلكترونية - الأرشيف";
                //_Message.BodyEncoding = Encoding.Unicode;
                _Message.BodyEncoding = Encoding.UTF8;
                _Message.SubjectEncoding = Encoding.UTF8;

                //_Message.To.Add(new MailAddress(mail));



                _Message.IsBodyHtml = true;

                _Message.Body = "<html><body dir='rtl'><h3 >";
                _Message.Body += "    السيد ";
                _Message.Body += dt.Rows[i]["pmp_name"].ToString();
                _Message.Body += "    </h3> ";
                // _Message.Body += " <h1 style=text-align:right>    وصلكم وارد من نظام إدارة مشروعات قطاع البنية المعلوماتية  </h1> ";

                _Message.Body += " <h3 > " + "  وصلكم وارد من قطاع البنية المعلوماتية " + " بتاريخ " +CDataConverter.ConvertDateTimeToFormatdmy ( CDataConverter.ConvertDateTimeNowRtnDt()) + "  بخصوص الوارد الجاري <br/>" + "<h3 style=" + "color:blue >" + "</h3>";
                _Message.Body += "<h3 >   ومرفق الوثيقة الخاصة </h3> <br /><br />";
                _Message.Body += "<h3 > مع تحيات </h3> ";
                _Message.Body += "<h3 >   " + Session_CS.e_signature.ToString() + "  </h3> ";
                _Message.Body += "</body></html>";
                SmtpClient Client = new SmtpClient();
                Client.Port = int.Parse(ConfigurationManager.AppSettings["SMTP_Port"]);
                Client.Host = ConfigurationManager.AppSettings["SMTP_Host"];
                string UserName = ConfigurationManager.AppSettings["SMTP_UserName"];
                string Password = ConfigurationManager.AppSettings["SMTP_Password"];
                _Message.From = new MailAddress(ConfigurationManager.AppSettings["SMTP_FromAddress"]);
                System.Net.NetworkCredential SMTPUserInfo = new System.Net.NetworkCredential(UserName, Password);
                _Message.Attachments.Add(new Attachment(Server.MapPath("Uploads/archive/inbox_Old" + i + ".pdf")));
                Client.UseDefaultCredentials = false;
                Client.Credentials = SMTPUserInfo;
                Client.Timeout = 1000000000;
                try
                {
                    _Message.To.Add(new MailAddress(dt.Rows[i]["mail"].ToString()));
                    _Message.CC.Add("yyoussef@mcit.gov.eg");

                    Client.Send(_Message);
                    Response.Write(" يتم ارسال الايميل بنجاح");
                }
                catch (Exception ex)
                {
                    Response.Write("لم يتم ارسال الايميل بنجاح");

                    //Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لم يتم ارسال الايميل بنجاح')</script>");

                }
            }
           
            #endregion

        }
        for (int j = 0; j < dt.Rows.Count; j++)
        {

            ///////////////////// late inbox
            sql_arc_late = main_sql + "";
            sql_arc_late += " and Emp_id =" + CDataConverter.ConvertToInt(dt.Rows[j]["pmp_id"].ToString());
            sql_arc_late += " and inbox_Report_view.finished = 0 AND inbox_Report_view.Inbox_Status <> 3  and CONVERT(datetime,Dead_Line_DT) < = '" + todayplus2late + "'";
            sql_arc_late += " order by inbox_Report_view.follow_id asc";
            ///////////// old inbox

            DataTable dt_arc_late = General_Helping.GetDataTable(sql_arc_late);
            ReportDocument rd = new ReportDocument();
          
            #region mail
            if (dt_arc_late.Rows.Count>0)
            {
                string s = Server.MapPath("Reports/General_inbox_Report.rpt");
                rd.Load(s);
                rd.SetDataSource(dt_arc_late);
                Reports.Load_Report(rd);
                rd.SetParameterValue("@Report_name", "الوارد المتأخر لمديري الادارات");
                rd.SetParameterValue("@pmp_id", CDataConverter.ConvertToInt(dt.Rows[j]["pmp_id"].ToString()), "Header_Eval_Report.rpt");
                rd.SetParameterValue("@pmp_id", CDataConverter.ConvertToInt(dt.Rows[j]["pmp_id"].ToString()));
                rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
                rd.SetParameterValue("@user", "automatic Report", "footerRep.rpt");
                //string exportname = "ACT_Report.rpt";
                string exportpath = Server.MapPath("Uploads/archive/inbox_late" + j + ".pdf");
                ExportOptions crExportOptions;
                DiskFileDestinationOptions crDestOptions = new DiskFileDestinationOptions();
                crDestOptions.DiskFileName = exportpath;
                crExportOptions = rd.ExportOptions;
                crExportOptions.DestinationOptions = crDestOptions;
                crExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                crExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                crExportOptions.Clone();
                rd.Export(crExportOptions);
                MailMessage _Message = new MailMessage();
                _Message.Subject = "الخدمات الإلكترونية - الأرشيف";
                //_Message.BodyEncoding = Encoding.Unicode;
                _Message.BodyEncoding = Encoding.UTF8;
                _Message.SubjectEncoding = Encoding.UTF8;

                //_Message.To.Add(new MailAddress(mail));



                _Message.IsBodyHtml = true;

                _Message.Body = "<html><body dir='rtl'><h3 >";
                _Message.Body += "    السيد ";
                _Message.Body += dt.Rows[j]["pmp_name"].ToString();
                _Message.Body += "    </h3> ";
                // _Message.Body += " <h1 style=text-align:right>    وصلكم وارد من نظام إدارة مشروعات قطاع البنية المعلوماتية  </h1> ";

                _Message.Body += " <h3 > " + "  وصلكم وارد من قطاع البنية المعلوماتية " + " بتاريخ " + CDataConverter.ConvertDateTimeToFormatdmy(CDataConverter.ConvertDateTimeNowRtnDt()) + "  بخصوص الوارد المتأخر <br/>" + "<h3 style=" + "color:blue >" + "</h3>";
                _Message.Body += "<h3 >   ومرفق الوثيقة الخاصة </h3> <br /><br />";
                _Message.Body += "<h3 > مع تحيات </h3> ";
                _Message.Body += "<h3 >   " + Session_CS.e_signature.ToString() + "  </h3> ";
                _Message.Body += "</body></html>";
                SmtpClient Client = new SmtpClient();
                Client.Port = int.Parse(ConfigurationManager.AppSettings["SMTP_Port"]);
                Client.Host = ConfigurationManager.AppSettings["SMTP_Host"];
                string UserName = ConfigurationManager.AppSettings["SMTP_UserName"];
                string Password = ConfigurationManager.AppSettings["SMTP_Password"];
                _Message.From = new MailAddress(ConfigurationManager.AppSettings["SMTP_FromAddress"]);
                System.Net.NetworkCredential SMTPUserInfo = new System.Net.NetworkCredential(UserName, Password);
                _Message.Attachments.Add(new Attachment(Server.MapPath("Uploads/archive/inbox_late" + j + ".pdf")));
                Client.UseDefaultCredentials = false;
                Client.Credentials = SMTPUserInfo;
                Client.Timeout = 1000000000;
                try
                {
                    _Message.To.Add(new MailAddress(dt.Rows[j]["mail"].ToString()));
                    _Message.CC.Add("yyoussef@mcit.gov.eg");

                    Client.Send(_Message);
                    Response.Write(" يتم ارسال الايميل بنجاح");
                }
                catch (Exception ex)
                {
                    Response.Write("لم يتم ارسال الايميل بنجاح");

                    //Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لم يتم ارسال الايميل بنجاح')</script>");

                }
            }
           
            #endregion

        }
       
    }
    void fun_archiving_Outbox()
    {
        string todayplus2late = VB_Classes.Dates.Dates_Operation.date_validate(CDataConverter.ConvertDateTimeToFormatdmy(CDataConverter.ConvertDateTimeNowRtnDt().AddDays(2)));
        DataTable dt = General_Helping.GetDataTable("select * from employee where rol_rol_id=3");
        main_sql = "set dateformat dmy select * from Outbox_Report_view where 1=1 ";
        //string[] files = Directory.GetFiles(Server.MapPath("Uploads/archive"));
        //foreach (string file in files)
        //{
        //    File.Delete(file);
        //}
        for (int i = 0; i < dt.Rows.Count; i++)
        {


            ///////////// old inbox
            sql_arc = main_sql + " and Outbox_Report_view.Outbox_Status=2 and Outbox_Report_view.Emp_id = " + CDataConverter.ConvertToInt(dt.Rows[i]["pmp_id"].ToString()) + " order by Outbox_Report_view.follow_id asc";
            DataTable dt_arc = General_Helping.GetDataTable(sql_arc);
            ReportDocument rd = new ReportDocument();


            #region mail
            if (dt_arc.Rows.Count > 0)
            {
                string s = Server.MapPath("Reports/General_inbox_Report.rpt");
                rd.Load(s);
                rd.SetDataSource(dt_arc);
                Reports.Load_Report(rd);
                rd.SetParameterValue("@Report_name", "الصادر الجاري لمديري الادارات");
                rd.SetParameterValue("@pmp_id", CDataConverter.ConvertToInt(dt.Rows[i]["pmp_id"].ToString()), "Header_Eval_Report.rpt");
                rd.SetParameterValue("@pmp_id", CDataConverter.ConvertToInt(dt.Rows[i]["pmp_id"].ToString()));
                rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
                rd.SetParameterValue("@user", "automatic Report", "footerRep.rpt");
                //string exportname = "ACT_Report.rpt";
                string exportpath = Server.MapPath("Uploads/archive/Outbox_Old" + i + ".pdf");
                ExportOptions crExportOptions;
                DiskFileDestinationOptions crDestOptions = new DiskFileDestinationOptions();
                crDestOptions.DiskFileName = exportpath;
                crExportOptions = rd.ExportOptions;
                crExportOptions.DestinationOptions = crDestOptions;
                crExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                crExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                crExportOptions.Clone();
                rd.Export(crExportOptions);
                MailMessage _Message = new MailMessage();
                _Message.Subject = "الخدمات الإلكترونية - الأرشيف";
                //_Message.BodyEncoding = Encoding.Unicode;
                _Message.BodyEncoding = Encoding.UTF8;
                _Message.SubjectEncoding = Encoding.UTF8;

                //_Message.To.Add(new MailAddress(mail));



                _Message.IsBodyHtml = true;

                _Message.Body = "<html><body dir='rtl'><h3 >";
                _Message.Body += "    السيد ";
                _Message.Body += dt.Rows[i]["pmp_name"].ToString();
                _Message.Body += "    </h3> ";
                // _Message.Body += " <h1 style=text-align:right>    وصلكم وارد من نظام إدارة مشروعات قطاع البنية المعلوماتية  </h1> ";

                _Message.Body += " <h3 > " + "  وصلكم وارد من قطاع البنية المعلوماتية " + " بتاريخ " + CDataConverter.ConvertDateTimeToFormatdmy(CDataConverter.ConvertDateTimeNowRtnDt()) + "  بخصوص الصادر الجاري <br/>" + "<h3 style=" + "color:blue >" + "</h3>";
                _Message.Body += "<h3 >   ومرفق الوثيقة الخاصة </h3> <br /><br />";
                _Message.Body += "<h3 > مع تحيات </h3> ";
                _Message.Body += "<h3 >   " + Session_CS.e_signature.ToString() + "  </h3> ";
                _Message.Body += "</body></html>";
                SmtpClient Client = new SmtpClient();
                Client.Port = int.Parse(ConfigurationManager.AppSettings["SMTP_Port"]);
                Client.Host = ConfigurationManager.AppSettings["SMTP_Host"];
                string UserName = ConfigurationManager.AppSettings["SMTP_UserName"];
                string Password = ConfigurationManager.AppSettings["SMTP_Password"];
                _Message.From = new MailAddress(ConfigurationManager.AppSettings["SMTP_FromAddress"]);
                System.Net.NetworkCredential SMTPUserInfo = new System.Net.NetworkCredential(UserName, Password);
                _Message.Attachments.Add(new Attachment(Server.MapPath("Uploads/archive/Outbox_Old" + i + ".pdf")));
                Client.UseDefaultCredentials = false;
                Client.Credentials = SMTPUserInfo;
                Client.Timeout = 1000000000;
                try
                {
                    _Message.To.Add(new MailAddress(dt.Rows[i]["mail"].ToString()));
                    _Message.CC.Add("yyoussef@mcit.gov.eg");

                    Client.Send(_Message);
                    Response.Write(" يتم ارسال الايميل بنجاح");
                }
                catch (Exception ex)
                {
                    Response.Write("لم يتم ارسال الايميل بنجاح");

                    //Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لم يتم ارسال الايميل بنجاح')</script>");

                }
            }

            #endregion

        }
        for (int j = 0; j < dt.Rows.Count; j++)
        {

            ///////////////////// late inbox
            sql_arc_late = main_sql + "";
            sql_arc_late += " and Emp_id =" + CDataConverter.ConvertToInt(dt.Rows[j]["pmp_id"].ToString());
            sql_arc_late += " and Outbox_Report_view.finished = 0 AND Outbox_Report_view.Outbox_Status <> 3  and CONVERT(datetime,Dead_Line_DT) < = '" + todayplus2late + "'";
            sql_arc_late += " order by Outbox_Report_view.follow_id asc";
            ///////////// old inbox

            DataTable dt_arc_late = General_Helping.GetDataTable(sql_arc_late);
            ReportDocument rd = new ReportDocument();

            #region mail
            if (dt_arc_late.Rows.Count > 0)
            {
                string s = Server.MapPath("Reports/General_inbox_Report.rpt");
                rd.Load(s);
                rd.SetDataSource(dt_arc_late);
                Reports.Load_Report(rd);
                rd.SetParameterValue("@Report_name", "الصادر المتأخر لمديري الادارات");
                rd.SetParameterValue("@pmp_id", CDataConverter.ConvertToInt(dt.Rows[j]["pmp_id"].ToString()), "Header_Eval_Report.rpt");
                rd.SetParameterValue("@pmp_id", CDataConverter.ConvertToInt(dt.Rows[j]["pmp_id"].ToString()));
                rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
                rd.SetParameterValue("@user", "automatic Report", "footerRep.rpt");
                //string exportname = "ACT_Report.rpt";
                string exportpath = Server.MapPath("Uploads/archive/Outbox_late" + j + ".pdf");
                ExportOptions crExportOptions;
                DiskFileDestinationOptions crDestOptions = new DiskFileDestinationOptions();
                crDestOptions.DiskFileName = exportpath;
                crExportOptions = rd.ExportOptions;
                crExportOptions.DestinationOptions = crDestOptions;
                crExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                crExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                crExportOptions.Clone();
                rd.Export(crExportOptions);
                MailMessage _Message = new MailMessage();
                _Message.Subject = "الخدمات الإلكترونية - الأرشيف";
                //_Message.BodyEncoding = Encoding.Unicode;
                _Message.BodyEncoding = Encoding.UTF8;
                _Message.SubjectEncoding = Encoding.UTF8;

                //_Message.To.Add(new MailAddress(mail));



                _Message.IsBodyHtml = true;

                _Message.Body = "<html><body dir='rtl'><h3 >";
                _Message.Body += "    السيد ";
                _Message.Body += dt.Rows[j]["pmp_name"].ToString();
                _Message.Body += "    </h3> ";
                // _Message.Body += " <h1 style=text-align:right>    وصلكم وارد من نظام إدارة مشروعات قطاع البنية المعلوماتية  </h1> ";

                _Message.Body += " <h3 > " + "  وصلكم وارد من قطاع البنية المعلوماتية " + " بتاريخ " + CDataConverter.ConvertDateTimeToFormatdmy(CDataConverter.ConvertDateTimeNowRtnDt()) + "  بخصوص الصادر المتاخر <br/>" + "<h3 style=" + "color:blue >" + "</h3>";
                _Message.Body += "<h3 >   ومرفق الوثيقة الخاصة </h3> <br /><br />";
                _Message.Body += "<h3 > مع تحيات </h3> ";
                _Message.Body += "<h3 >   " + Session_CS.e_signature.ToString() + "  </h3> ";
                _Message.Body += "</body></html>";
                SmtpClient Client = new SmtpClient();
                Client.Port = int.Parse(ConfigurationManager.AppSettings["SMTP_Port"]);
                Client.Host = ConfigurationManager.AppSettings["SMTP_Host"];
                string UserName = ConfigurationManager.AppSettings["SMTP_UserName"];
                string Password = ConfigurationManager.AppSettings["SMTP_Password"];
                _Message.From = new MailAddress(ConfigurationManager.AppSettings["SMTP_FromAddress"]);
                System.Net.NetworkCredential SMTPUserInfo = new System.Net.NetworkCredential(UserName, Password);
                _Message.Attachments.Add(new Attachment(Server.MapPath("Uploads/archive/Outbox_late" + j + ".pdf")));
                Client.UseDefaultCredentials = false;
                Client.Credentials = SMTPUserInfo;
                Client.Timeout = 1000000000;
                try
                {
                    _Message.To.Add(new MailAddress(dt.Rows[j]["mail"].ToString()));
                    _Message.CC.Add("yyoussef@mcit.gov.eg");

                    Client.Send(_Message);
                    Response.Write(" يتم ارسال الايميل بنجاح");
                }
                catch (Exception ex)
                {
                    Response.Write("لم يتم ارسال الايميل بنجاح");

                    //Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لم يتم ارسال الايميل بنجاح')</script>");

                }
            }

            #endregion

        }

    }
    void fun_archiving_Com()
    {
        string todayplus2late = VB_Classes.Dates.Dates_Operation.date_validate(CDataConverter.ConvertDateTimeToFormatdmy(CDataConverter.ConvertDateTimeNowRtnDt().AddDays(2)));
        DataTable dt = General_Helping.GetDataTable("select * from employee where rol_rol_id=3");
        main_sql = "set dateformat dmy select * from com_Report_view where 1=1 ";
        //string[] files = Directory.GetFiles(Server.MapPath("Uploads/archive"));
        //foreach (string file in files)
        //{
        //    File.Delete(file);
        //}
        for (int i = 0; i < dt.Rows.Count; i++)
        {


            ///////////// old inbox
            sql_arc = main_sql + " and com_Report_view.commission_Status=2 and com_Report_view.visa_emp = " + CDataConverter.ConvertToInt(dt.Rows[i]["pmp_id"].ToString()) + " order by com_Report_view.follow_id asc";
            DataTable dt_arc = General_Helping.GetDataTable(sql_arc);
            ReportDocument rd = new ReportDocument();


            #region mail
            if (dt_arc.Rows.Count > 0)
            {
                string s = Server.MapPath("Reports/General_inbox_Report.rpt");
                rd.Load(s);
                rd.SetDataSource(dt_arc);
                Reports.Load_Report(rd);
                rd.SetParameterValue("@Report_name", "التكليفات الجارية لمديري الادارات");
                rd.SetParameterValue("@pmp_id", CDataConverter.ConvertToInt(dt.Rows[i]["pmp_id"].ToString()), "Header_Eval_Report.rpt");
                rd.SetParameterValue("@pmp_id", CDataConverter.ConvertToInt(dt.Rows[i]["pmp_id"].ToString()));
                rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
                rd.SetParameterValue("@user", "automatic Report", "footerRep.rpt");
                //string exportname = "ACT_Report.rpt";
                string exportpath = Server.MapPath("Uploads/archive/com_Old" + i + ".pdf");
                ExportOptions crExportOptions;
                DiskFileDestinationOptions crDestOptions = new DiskFileDestinationOptions();
                crDestOptions.DiskFileName = exportpath;
                crExportOptions = rd.ExportOptions;
                crExportOptions.DestinationOptions = crDestOptions;
                crExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                crExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                crExportOptions.Clone();
                rd.Export(crExportOptions);
                MailMessage _Message = new MailMessage();
                _Message.Subject = "الخدمات الإلكترونية - الأرشيف";
                //_Message.BodyEncoding = Encoding.Unicode;
                _Message.BodyEncoding = Encoding.UTF8;
                _Message.SubjectEncoding = Encoding.UTF8;

                //_Message.To.Add(new MailAddress(mail));



                _Message.IsBodyHtml = true;

                _Message.Body = "<html><body dir='rtl'><h3 >";
                _Message.Body += "    السيد ";
                _Message.Body += dt.Rows[i]["pmp_name"].ToString();
                _Message.Body += "    </h3> ";
                // _Message.Body += " <h1 style=text-align:right>    وصلكم وارد من نظام إدارة مشروعات قطاع البنية المعلوماتية  </h1> ";

                _Message.Body += " <h3 > " + "  وصلكم وارد من قطاع البنية المعلوماتية " + " بتاريخ " + CDataConverter.ConvertDateTimeToFormatdmy(CDataConverter.ConvertDateTimeNowRtnDt()) + "  بخصوص التكليفات الجارية <br/>" + "<h3 style=" + "color:blue >" + "</h3>";
                _Message.Body += "<h3 >   ومرفق الوثيقة الخاصة </h3> <br /><br />";
                _Message.Body += "<h3 > مع تحيات </h3> ";
                _Message.Body += "<h3 >   " + Session_CS.e_signature.ToString() + "  </h3> ";
                _Message.Body += "</body></html>";
                SmtpClient Client = new SmtpClient();
                Client.Port = int.Parse(ConfigurationManager.AppSettings["SMTP_Port"]);
                Client.Host = ConfigurationManager.AppSettings["SMTP_Host"];
                string UserName = ConfigurationManager.AppSettings["SMTP_UserName"];
                string Password = ConfigurationManager.AppSettings["SMTP_Password"];
                _Message.From = new MailAddress(ConfigurationManager.AppSettings["SMTP_FromAddress"]);
                System.Net.NetworkCredential SMTPUserInfo = new System.Net.NetworkCredential(UserName, Password);
                _Message.Attachments.Add(new Attachment(Server.MapPath("Uploads/archive/com_Old" + i + ".pdf")));
                Client.UseDefaultCredentials = false;
                Client.Credentials = SMTPUserInfo;
                Client.Timeout = 1000000000;
                try
                {
                    _Message.To.Add(new MailAddress(dt.Rows[i]["mail"].ToString()));

                    _Message.CC.Add("yyoussef@mcit.gov.eg");
                    Client.Send(_Message);
                    Response.Write(" يتم ارسال الايميل بنجاح");
                }
                catch (Exception ex)
                {
                    Response.Write("لم يتم ارسال الايميل بنجاح");

                    //Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لم يتم ارسال الايميل بنجاح')</script>");

                }
            }

            #endregion

        }
        for (int j = 0; j < dt.Rows.Count; j++)
        {

            ///////////////////// late inbox
            sql_arc_late = main_sql + "";
            sql_arc_late += " and visa_emp =" + CDataConverter.ConvertToInt(dt.Rows[j]["pmp_id"].ToString());
            sql_arc_late += " and emp_id =" + CDataConverter.ConvertToInt(dt.Rows[j]["pmp_id"].ToString());
            sql_arc_late += " and com_Report_view.finished = 0 AND com_Report_view.commission_Status <> 3  and CONVERT(datetime,Dead_Line_DT) < = '" + todayplus2late + "'";
            sql_arc_late += " order by com_Report_view.follow_id asc";
            ///////////// old inbox

            DataTable dt_arc_late = General_Helping.GetDataTable(sql_arc_late);
            ReportDocument rd = new ReportDocument();

            #region mail
            if (dt_arc_late.Rows.Count > 0)
            {
                string s = Server.MapPath("Reports/General_inbox_Report.rpt");
                rd.Load(s);
                rd.SetDataSource(dt_arc_late);
                Reports.Load_Report(rd);
                rd.SetParameterValue("@Report_name", "التكليفات المتأخرة لمديري الادارات");
                rd.SetParameterValue("@pmp_id", CDataConverter.ConvertToInt(dt.Rows[j]["pmp_id"].ToString()), "Header_Eval_Report.rpt");
                rd.SetParameterValue("@pmp_id", CDataConverter.ConvertToInt(dt.Rows[j]["pmp_id"].ToString()));
                rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
                rd.SetParameterValue("@user", "automatic Report", "footerRep.rpt");
                //string exportname = "ACT_Report.rpt";
                string exportpath = Server.MapPath("Uploads/archive/com_late" + j + ".pdf");
                ExportOptions crExportOptions;
                DiskFileDestinationOptions crDestOptions = new DiskFileDestinationOptions();
                crDestOptions.DiskFileName = exportpath;
                crExportOptions = rd.ExportOptions;
                crExportOptions.DestinationOptions = crDestOptions;
                crExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                crExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                crExportOptions.Clone();
                rd.Export(crExportOptions);
                MailMessage _Message = new MailMessage();
                _Message.Subject = "الخدمات الإلكترونية - الأرشيف";
                //_Message.BodyEncoding = Encoding.Unicode;
                _Message.BodyEncoding = Encoding.UTF8;
                _Message.SubjectEncoding = Encoding.UTF8;

                //_Message.To.Add(new MailAddress(mail));



                _Message.IsBodyHtml = true;

                _Message.Body = "<html><body dir='rtl'><h3 >";
                _Message.Body += "    السيد ";
                _Message.Body += dt.Rows[j]["pmp_name"].ToString();
                _Message.Body += "    </h3> ";
                // _Message.Body += " <h1 style=text-align:right>    وصلكم وارد من نظام إدارة مشروعات قطاع البنية المعلوماتية  </h1> ";

                _Message.Body += " <h3 > " + "  وصلكم وارد من قطاع البنية المعلوماتية " + " بتاريخ " + CDataConverter.ConvertDateTimeToFormatdmy(CDataConverter.ConvertDateTimeNowRtnDt()) + "  بخصوص التكليفات المتاخرة <br/>" + "<h3 style=" + "color:blue >" + "</h3>";
                _Message.Body += "<h3 >   ومرفق الوثيقة الخاصة </h3> <br /><br />";
                _Message.Body += "<h3 > مع تحيات </h3> ";
                _Message.Body += "<h3 >   " + Session_CS.e_signature.ToString() + "  </h3> ";
                _Message.Body += "</body></html>";
                SmtpClient Client = new SmtpClient();
                Client.Port = int.Parse(ConfigurationManager.AppSettings["SMTP_Port"]);
                Client.Host = ConfigurationManager.AppSettings["SMTP_Host"];
                string UserName = ConfigurationManager.AppSettings["SMTP_UserName"];
                string Password = ConfigurationManager.AppSettings["SMTP_Password"];
                _Message.From = new MailAddress(ConfigurationManager.AppSettings["SMTP_FromAddress"]);
                System.Net.NetworkCredential SMTPUserInfo = new System.Net.NetworkCredential(UserName, Password);
                _Message.Attachments.Add(new Attachment(Server.MapPath("Uploads/archive/com_late" + j + ".pdf")));
                Client.UseDefaultCredentials = false;
                Client.Credentials = SMTPUserInfo;
                Client.Timeout = 1000000000;
                try
                {
                    _Message.To.Add(new MailAddress(dt.Rows[j]["mail"].ToString()));
                    _Message.CC.Add("yyoussef@mcit.gov.eg");


                    Client.Send(_Message);
                    Response.Write(" يتم ارسال الايميل بنجاح");
                }
                catch (Exception ex)
                {
                    Response.Write("لم يتم ارسال الايميل بنجاح");

                    //Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لم يتم ارسال الايميل بنجاح')</script>");

                }
            }

            #endregion

        }

    }
    public string IpAddress()
    {
        string name = "";
        string ip = "";
        try
        {
            name = System.Net.Dns.GetHostName();
            ip = System.Net.Dns.GetHostAddresses(name).GetValue(1).ToString();
            return ip;
        }
        catch
        {
            name = System.Net.Dns.GetHostName();
            ip = System.Net.Dns.GetHostAddresses(name).GetValue(0).ToString();
            return ip;
        }
    }
    void Update_Employee_permission()
    {
        int day = CDataConverter.ConvertDateTimeNowRtnDt().Day;
        int month = CDataConverter.ConvertDateTimeNowRtnDt().Month;
        if (day == 1)
        {
            string sql = " update Vacations_summary set permission = 2 where year = '" + CDataConverter.ConvertDateTimeNowRtnDt().Year.ToString() + "'";
            General_Helping.ExcuteQuery(sql);
            if (month == 1)
            {
                int current_year = CDataConverter.ConvertDateTimeNowRtnDt().Year;
                int Previous_year = current_year - 1;
                string sql2 = "insert into Vacations_summary (emp_id,unusual ,exhibitor , sick ,hajj,birth,year,repeat,day_off_no,permission  , unusual_total ,exhibitor_total) select emp_id,21,6,0,30,90," + current_year + ",0,0,2 , unusual_total,exhibitor_total  from Vacations_summary where year = " + Previous_year;
                General_Helping.ExcuteQuery(sql2);
            }

        }

    }
    private void Test_Send_Mail()
    {
        MailMessage _Message = new MailMessage();
        _Message.Subject = "الخدمات الإلكترونية - الأرشيف";
        //_Message.BodyEncoding = Encoding.Unicode;
        _Message.BodyEncoding = Encoding.UTF8;
        _Message.SubjectEncoding = Encoding.UTF8;

        
  

        string address2 = System.Web.HttpContext.Current.Request.Url.Authority.ToString();



        _Message.IsBodyHtml = true;

        _Message.Body = "<html><body dir='rtl'><h3 >";
        _Message.Body += "    السيد المهندس ";
        _Message.Body += "    </h3> ";

        _Message.Body += " <h3 > " + "  وصلكم وارد من قطاع البنية المعلوماتية " + " بتاريخ " + CDataConverter.ConvertDateTimeNowRtnDt() + "  بخصوص التعديلات في الخطط الزمنية في المشروعات <br/>" + "<h3 style=" + "color:blue >" + "</h3>";
        _Message.Body += "<h3 >   ومرفق الوثيقة الخاصة بهذه التعديلات</h3> <br /><br />";
        _Message.Body += "<h3 > مع تحيات </h3> ";
        _Message.Body += "<h3 >   " + Session_CS.e_signature.ToString() + "  </h3> ";

        _Message.Body += " <h3 >http:" + "/" + "/" + address2 + "/MainForm/View_Commission.aspx?id=" + 40 + "&1=1</h3>";

        _Message.Body += "</body></html>";
        SmtpClient Client = new SmtpClient();
        Client.Port = int.Parse(ConfigurationManager.AppSettings["SMTP_Port"]);
        Client.Host = ConfigurationManager.AppSettings["SMTP_Host"];
        string UserName = ConfigurationManager.AppSettings["SMTP_UserName"];
        string Password = ConfigurationManager.AppSettings["SMTP_Password"];
        _Message.From = new MailAddress(ConfigurationManager.AppSettings["SMTP_FromAddress"]);
        System.Net.NetworkCredential SMTPUserInfo = new System.Net.NetworkCredential(UserName, Password);
        Client.UseDefaultCredentials = false;
        Client.Credentials = SMTPUserInfo;
        Client.Timeout = 1000000000;
        try
        {
            _Message.To.Add(new MailAddress(youssef));
           // _Message.Bcc.Add(new MailAddress(Mona));

            Client.Send(_Message);

        }
        catch (Exception ex)
        {
            Response.Write("لم يتم ارسال الايميل بنجاح");
            //Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لم يتم ارسال الايميل بنجاح')</script>");

        }
        Response.Write("لقد تم ارسال الايميل بنجاح");

    }
    void fun_act()
    {
        main_sql = "select * from Log_view_Act where 1=1";

        sql_act = main_sql + " AND Log_view_Act.record_type = 2 or Log_view_Act.record_type = 3";
        //sql_needs = main_sql += " AND record_type = 4";
        //sql_period_balance = main_sql += " AND record_type = 1";
        //sql_fin = main_sql += " AND record_type = 5";
        DataTable dt_act = General_Helping.GetDataTable(sql_act);
        ReportDocument rd = new ReportDocument();
        string s = Server.MapPath("Reports/Log_ACT_Report.rpt");
        rd.Load(s);
        rd.SetDataSource(dt_act);
        Reports.Load_Report(rd);
        //string exportname = "ACT_Report.rpt";
        string exportpath = Server.MapPath("Uploads/ACT_Report.pdf");
        //string exportpath = "D:\\WorkShop_VSS\\Projects_Management\\Uploads\\ACT_Report.pdf";
        ExportOptions crExportOptions;
        DiskFileDestinationOptions crDestOptions = new DiskFileDestinationOptions();
        crDestOptions.DiskFileName = exportpath;
        crExportOptions = rd.ExportOptions;
        crExportOptions.DestinationOptions = crDestOptions;
        crExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
        crExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
        crExportOptions.Clone();
        rd.Export(crExportOptions);
        if (dt_act.Rows.Count > 0)
        {
            MailMessage _Message = new MailMessage();
            _Message.Subject = "الخدمات الإلكترونية - الأرشيف";
            //_Message.BodyEncoding = Encoding.Unicode;
            _Message.BodyEncoding = Encoding.UTF8;
            _Message.SubjectEncoding = Encoding.UTF8;

            //_Message.To.Add(new MailAddress(mail));



            _Message.IsBodyHtml = true;

            _Message.Body = "<html><body dir='rtl'><h3 >";
            _Message.Body += "    السيد المهندس / أحمد صلاح";
            _Message.Body += "    </h3> ";
            // _Message.Body += " <h1 style=text-align:right>    وصلكم وارد من نظام إدارة مشروعات قطاع البنية المعلوماتية  </h1> ";

            _Message.Body += " <h3 > " + "  وصلكم وارد من قطاع البنية المعلوماتية " + " بتاريخ " + CDataConverter.ConvertDateTimeToFormatdmy(CDataConverter.ConvertDateTimeNowRtnDt()) + "  بخصوص التعديلات في الخطط الزمنية في المشروعات <br/>" + "<h3 style=" + "color:blue >" + "</h3>";
            _Message.Body += "<h3 >   ومرفق الوثيقة الخاصة بهذه التعديلات</h3> <br /><br />";
            _Message.Body += "<h3 > مع تحيات </h3> ";
            _Message.Body += "<h3 >   " + Session_CS.e_signature.ToString() + "  </h3> ";
            _Message.Body += "</body></html>";
            SmtpClient Client = new SmtpClient();
            Client.Port = int.Parse(ConfigurationManager.AppSettings["SMTP_Port"]);
            Client.Host = ConfigurationManager.AppSettings["SMTP_Host"];
            string UserName = ConfigurationManager.AppSettings["SMTP_UserName"];
            string Password = ConfigurationManager.AppSettings["SMTP_Password"];
            _Message.From = new MailAddress(ConfigurationManager.AppSettings["SMTP_FromAddress"]);
            System.Net.NetworkCredential SMTPUserInfo = new System.Net.NetworkCredential(UserName, Password);
            _Message.Attachments.Add(new Attachment(Server.MapPath("Uploads/ACT_Report.pdf")));
            Client.UseDefaultCredentials = false;
            Client.Credentials = SMTPUserInfo;
            Client.Timeout = 1000000000;
            try
            {
                _Message.To.Add(new MailAddress(asalaheldin));
                _Message.Bcc.Add(new MailAddress(Mona));

                Client.Send(_Message);

            }
            catch (Exception ex)
            {
                Response.Write("لم يتم ارسال الايميل بنجاح");

                //Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لم يتم ارسال الايميل بنجاح')</script>");

            }
            Response.Write("لقد تم ارسال الايميل بنجاح");
            //Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم ارسال الايميل بنجاح')</script>");
        }

    }
    void fun_needs()
    {
        main_sql = "select * from Log_need_final where 1=1";

        //sql_act = main_sql + " AND Log_view_Act.record_type = 2";
        // sql_needs = main_sql += " AND record_type = 4 or record_type = 9 or record_type = 10 or record_type = 11";
        //sql_period_balance = main_sql += " AND record_type = 1";
        //sql_fin = main_sql += " AND record_type = 5";
        DataTable dt_needs_request = General_Helping.GetDataTable(main_sql);
        ReportDocument rd = new ReportDocument();
        string s = Server.MapPath("Reports/Log_Needs_Report.rpt");
        rd.Load(s);
        rd.SetDataSource(dt_needs_request);
        Reports.Load_Report(rd);
        //string exportname = "ACT_Report.rpt";
        string exportpath = Server.MapPath("Uploads/PNeeds_Report.pdf");
        //"D:\\WorkShop_VSS\\Projects_Management\\Uploads\\PNeeds_Report.pdf";
        ExportOptions crExportOptions;
        DiskFileDestinationOptions crDestOptions = new DiskFileDestinationOptions();

        crDestOptions.DiskFileName = exportpath;
        crExportOptions = rd.ExportOptions;
        crExportOptions.DestinationOptions = crDestOptions;
        crExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
        crExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;

        rd.Export();
        if (dt_needs_request.Rows.Count > 0)
        {
            MailMessage _Message = new MailMessage();
            _Message.Subject = "الخدمات الإلكترونية - الأرشيف";
            //_Message.BodyEncoding = Encoding.Unicode;
            _Message.BodyEncoding = Encoding.UTF8;
            _Message.SubjectEncoding = Encoding.UTF8;

            //_Message.To.Add(new MailAddress(mail));



            _Message.IsBodyHtml = true;

            _Message.Body = "<html><body dir='rtl'><h3 >";
            _Message.Body += "    السيد المهندس / سامي البيه";
            _Message.Body += "    </h3> ";
            // _Message.Body += " <h1 style=text-align:right>    وصلكم وارد من نظام إدارة مشروعات قطاع البنية المعلوماتية  </h1> ";

            _Message.Body += " <h3 > " + "  وصلكم وارد من قطاع البنية المعلوماتية " + " بتاريخ " + CDataConverter.ConvertDateTimeToFormatdmy(CDataConverter.ConvertDateTimeNowRtnDt()) + "  بخصوص التعديلات في الاحتياجات للمشروعات <br/>" + "<h3 style=" + "color:blue >" + "</h3>";
            _Message.Body += "<h3 >   ومرفق الوثيقة الخاصة بهذه التعديلات</h3> <br /><br />";
            _Message.Body += "<h3 > مع تحيات </h3> ";
            _Message.Body += "<h3 >   " + Session_CS.e_signature.ToString() + "  </h3> ";
            _Message.Body += "</body></html>";
            SmtpClient Client = new SmtpClient();
            Client.Port = int.Parse(ConfigurationManager.AppSettings["SMTP_Port"]);
            Client.Host = ConfigurationManager.AppSettings["SMTP_Host"];
            string UserName = ConfigurationManager.AppSettings["SMTP_UserName"];
            string Password = ConfigurationManager.AppSettings["SMTP_Password"];
            _Message.From = new MailAddress(ConfigurationManager.AppSettings["SMTP_FromAddress"]);
            System.Net.NetworkCredential SMTPUserInfo = new System.Net.NetworkCredential(UserName, Password);
            _Message.Attachments.Add(new Attachment(Server.MapPath("Uploads/PNeeds_Report.pdf")));
            Client.UseDefaultCredentials = false;
            Client.Credentials = SMTPUserInfo;
            Client.Timeout = 1000000000;
            try
            {
                _Message.To.Add(new MailAddress(Sbeih));
                _Message.Bcc.Add(new MailAddress(Mona));

                Client.Send(_Message);

            }
            catch (Exception ex)
            {
                Response.Write("لم يتم ارسال الايميل بنجاح");
                //Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لم يتم ارسال الايميل بنجاح')</script>");

            }
            Response.Write("لقد تم ارسال الايميل بنجاح");
            //Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم ارسال الايميل بنجاح')</script>");

        }

    }
    void fun_finance()
    {
        main_sql = "select * from Log_Finance_final where 1=1";

        //sql_act = main_sql + " AND Log_view_Act.record_type = 2 or Log_view_Act.record_type = 3";
        //sql_needs = main_sql += " AND record_type = 4";
        //sql_period_balance = main_sql += " AND record_type = 1";
        //sql_fin = main_sql += " AND record_type = 5 or record_type = 1 or record_type = 7 or record_type = 8";
        DataTable dt_fin = General_Helping.GetDataTable(main_sql);
        ReportDocument rd = new ReportDocument();
        string s = Server.MapPath("Reports/Log_fin_Report.rpt");
        rd.Load(s);
        rd.SetDataSource(dt_fin);
        Reports.Load_Report(rd);
        //string exportname = "ACT_Report.rpt";
        string exportpath = Server.MapPath("Uploads/Finance_Report.pdf");
        //string exportpath = "D:\\WorkShop_VSS\\Projects_Management\\Uploads\\Finance_Report.pdf";
        ExportOptions crExportOptions;
        DiskFileDestinationOptions crDestOptions = new DiskFileDestinationOptions();
        crDestOptions.DiskFileName = exportpath;
        crExportOptions = rd.ExportOptions;
        crExportOptions.DestinationOptions = crDestOptions;
        crExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
        crExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;


        rd.Export();
        if (dt_fin.Rows.Count > 0)
        {
            MailMessage _Message = new MailMessage();
            _Message.Subject = "الخدمات الإلكترونية - الأرشيف";
            //_Message.BodyEncoding = Encoding.Unicode;
            _Message.BodyEncoding = Encoding.UTF8;
            _Message.SubjectEncoding = Encoding.UTF8;

            //_Message.To.Add(new MailAddress(mail));



            _Message.IsBodyHtml = true;

            _Message.Body = "<html><body dir='rtl'><h3 >";
            _Message.Body += "     المهندسة /  رانيا عبد الغفار";
            _Message.Body += "    </h3> ";
            // _Message.Body += " <h1 style=text-align:right>    وصلكم وارد من نظام إدارة مشروعات قطاع البنية المعلوماتية  </h1> ";

            _Message.Body += " <h3 > " + "  وصلكم وارد من قطاع البنية المعلوماتية " + " بتاريخ " + CDataConverter.ConvertDateTimeToFormatdmy(CDataConverter.ConvertDateTimeNowRtnDt()) + "  بخصوص التعديلات في الأمور المالية للمشروعات <br/>" + "<h3 style=" + "color:blue >" + "</h3>";
            _Message.Body += "<h3 >   ومرفق الوثيقة الخاصة بهذه التعديلات</h3> <br /><br />";
            _Message.Body += "<h3 > مع تحيات </h3> ";
            _Message.Body += "<h3 >   " + Session_CS.e_signature.ToString() + "  </h3> ";
            _Message.Body += "</body></html>";
            SmtpClient Client = new SmtpClient();
            Client.Port = int.Parse(ConfigurationManager.AppSettings["SMTP_Port"]);
            Client.Host = ConfigurationManager.AppSettings["SMTP_Host"];
            string UserName = ConfigurationManager.AppSettings["SMTP_UserName"];
            string Password = ConfigurationManager.AppSettings["SMTP_Password"];
            _Message.From = new MailAddress(ConfigurationManager.AppSettings["SMTP_FromAddress"]);
            System.Net.NetworkCredential SMTPUserInfo = new System.Net.NetworkCredential(UserName, Password);
            _Message.Attachments.Add(new Attachment(Server.MapPath("Uploads/Finance_Report.pdf")));
            Client.UseDefaultCredentials = false;
            Client.Credentials = SMTPUserInfo;
            Client.Timeout = 1000000000;
            try
            {
                _Message.To.Add(new MailAddress(rabdelghafar));
                _Message.Bcc.Add(new MailAddress(Mona));

                Client.Send(_Message);

            }
            catch (Exception ex)
            {
                Response.Write("لم يتم ارسال الايميل بنجاح");
                //Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لم يتم ارسال الايميل بنجاح')</script>");

            }
            Response.Write("لقد تم ارسال الايميل بنجاح");
            //Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم ارسال الايميل بنجاح')</script>");

        }

    }


    /* ضبط الرصيد السنوي للاجازات مع يداية كل سنة 
     * اول خطوة 
     *  insert into Vacations_summary (emp_id,unusual ,exhibitor , sick ,hajj,birth,year,repeat,day_off_no,permission 
 , unusual_total ,exhibitor_total) 
select emp_id,unusual_total,exhibitor_total,0,30,90,2015,0,0,2 , unusual_total,exhibitor_total
  from Vacations_summary where year = 2014
     * 
     * ثاني خطوة   
     * 
     * 
     * 
     * 
     * 
     * 


declare @emp_id int
Declare @old_unusual int

Declare @year int




DECLARE MY_CURSOR CURSOR 
  LOCAL STATIC READ_ONLY FORWARD_ONLY
FOR 
SELECT DISTINCT Vacations_summary.emp_id,  Vacations_summary.unusual   from Projects_Management.dbo.Vacations_summary 
where Vacations_summary.year=2014

OPEN MY_CURSOR
FETCH NEXT FROM MY_CURSOR INTO @emp_id,@old_unusual
WHILE @@FETCH_STATUS = 0
BEGIN 
   
   update Vacations_summary set unusual=unusual +@old_unusual where emp_id =@emp_id and year=2015
    
    FETCH NEXT FROM MY_CURSOR INTO @emp_id,@old_unusual
END
CLOSE MY_CURSOR
DEALLOCATE MY_CURSOR
     * 
     
     */

}
