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
using System.Data.SqlClient;
using System.Net.Mail;
using System.Text;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;
using CrystalDecisions.Shared;
using System.IO;
public partial class UserControls_vacations_manager : System.Web.UI.UserControl
{
    SqlConnection conn;
    private string sql_Connection = Database.ConnectionString;
    Session_CS Session_CS = new Session_CS();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            FillGrids();
    }

    private void FillGrids()
    {
        Vacations_DT VacObj = new Vacations_DT();
        DataTable AllVacDT = Vacations_DB.Select_old(CDataConverter.ConvertToInt(Session_CS.pmp_id));
        requests.DataSource = AllVacDT;
        requests.DataBind();
    }
    protected void BtnVacationRequest_Click(object sender, EventArgs e)
    {
        Response.Redirect("vacations_manager.aspx?type=0");
    }
    protected void requests_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string str = e.CommandArgument.ToString();
        string[] arr = str.Split(',');
        if (e.CommandName == "EditItem")
        {
            Response.Redirect("vacation_request.aspx?edit_type=manage&vacation_id=" + arr[0].ToString());
        }

        if (e.CommandName == "RemoveItem")
        {
            DataTable vac_DT = Vacations_DB.Select_Vac_By_ID(CDataConverter.ConvertToInt(arr[0].ToString()));
            if (vac_DT.Rows.Count > 0)
            {
                if (vac_DT.Rows[0]["manager_approve"].ToString() == "1")
                {
                    string vacation_repeat = "";
                    string field_name = "";
                    if (CDataConverter.ConvertToInt(vac_DT.Rows[0]["vacation_id"].ToString()) > 0 && CDataConverter.ConvertToInt(vac_DT.Rows[0]["vacation_id"].ToString()) < 4)
                    {
                        vacation_repeat = "yearly";
                        //repeat
                        switch (CDataConverter.ConvertToInt(vac_DT.Rows[0]["vacation_id"].ToString()))
                        {
                            case 1:
                                field_name = "unusual";
                                break;
                            case 2:
                                field_name = "exhibitor";
                                break;
                            case 3:
                                field_name = "sick";
                                break;
                        }
                    }
                    else if (CDataConverter.ConvertToInt(vac_DT.Rows[0]["vacation_id"].ToString()) == 5)
                    {
                        vacation_repeat = "once";
                        field_name = "hajj";
                    }
                    else if (CDataConverter.ConvertToInt(vac_DT.Rows[0]["vacation_id"].ToString()) == 6)
                    {
                        vacation_repeat = "3times";
                        field_name = "birth";
                    }

                    if (field_name != "" && Convert.ToInt16(vac_DT.Rows[0]["no_days"].ToString()) > 0)
                    {
                        int reslt = General_Helping.ExcuteQuery("update Vacations_summary set " + field_name + "=" + field_name + "+(" + vac_DT.Rows[0]["no_days"].ToString() + ") WHERE emp_id = " + vac_DT.Rows[0]["user_id"].ToString());
                    }
                }
            }

            string str2 = "delete from Vacations_users where id=" + arr[0].ToString();
            int result = General_Helping.ExcuteQuery("delete from Vacations_users where id=" + arr[0].ToString());
            Send_mail("بالحذف", arr[1].ToString());
        }

        if (e.CommandName == "dlt")
        {
            string strr = e.CommandArgument.ToString();
            string[] arrr = strr.Split(',');

            GetReport(CDataConverter.ConvertToInt( arrr[0].ToString()), CDataConverter.ConvertToInt(arrr[1].ToString()));
        }
        
        FillGrids();
    }

    private void Send_mail(string Msg, string Pmp_id)
    {
        DataTable Dt_Mng = General_Helping.GetDataTable("Select mail,PMP_ID,pmp_name from EMPLOYEE where PMP_ID = " + Pmp_id);
        string name = "";
        string Succ_names = "", Failed_name = "";
        if (Dt_Mng.Rows.Count > 0)
        {
            string mail = Dt_Mng.Rows[0]["mail"].ToString();
            MailMessage _Message = new MailMessage();

            _Message.Subject = "نظام الادارة الالكترونية - الأجازات";


            //_Message.BodyEncoding = Encoding.Unicode;
            _Message.BodyEncoding = Encoding.UTF8;
            _Message.SubjectEncoding = Encoding.UTF8;

            string address2 = "0";
            String encrypted_id = "0";
            string file = "";
            MemoryStream ms = new MemoryStream();
           // _Message.IsBodyHtml = true;
            _Message.Body = "<html><body dir='rtl'><h3 >";
            _Message.Body += " السيد  ";
            _Message.Body += Dt_Mng.Rows[0]["pmp_name"] + " </h3> ";
            _Message.Body += "<h3 >قام السيد " + Session_CS.pmp_name + " </h3> ";
            _Message.Body += " <h3 > بالرد على الاجازة المقدمة من جانبكم"
                + " <h3 style=color:blue > " + Msg + "</h3>";
            _Message.Body += "<h3 > مع تحيات </h3> ";
            _Message.Body += "<h3 >   " + Session_CS.e_signature.ToString() + "  </h3> ";
            _Message.Body += "</body></html>";
            SmtpClient Client = new SmtpClient();
            //Client.Port = int.Parse(ConfigurationManager.AppSettings["SMTP_Port"]);
            //Client.Host = ConfigurationManager.AppSettings["SMTP_Host"];
            //string UserName = ConfigurationManager.AppSettings["SMTP_UserName"];
            //string Password = ConfigurationManager.AppSettings["SMTP_Password"];
            //_Message.From = new MailAddress(ConfigurationManager.AppSettings["SMTP_FromAddress"]);
            Client.Host = Session_CS.Host;
            Client.Port = Session_CS.Port;
            string UserName_mail = Session_CS.UserName_mail;
            //int Password= Session_CS.Password;
            string Password = Session_CS.Password;
            _Message.From = new MailAddress(Session_CS.FromAddress);
            //_Message.Attachments.Add(new Attachment("D:\\Attached.pdf"));
            System.Net.NetworkCredential SMTPUserInfo = new System.Net.NetworkCredential(UserName_mail, Password);

            Client.UseDefaultCredentials = false;
            Client.Credentials = SMTPUserInfo;
            Client.Timeout = 1000000000;

            try
            {
                _Message.To.Add(new MailAddress(mail));

               // Client.Send(_Message);
                SendingMailthread_class.Sendingmail(_Message,_Message.Subject, _Message.Body, mail, ms, file, encrypted_id, "");

                Succ_names += name + ",";
            }
            catch (Exception ex)
            {
                Failed_name += name + ",";
            }

        }
    }



    private void GetReport(int id,int vacation_type )
    {



        conn = new SqlConnection(sql_Connection);
        string s = "";
        string sql = "SELECT  dbo.EMPLOYEE.pmp_name, dbo.EMPLOYEE.Dept_Dept_id, dbo.EMPLOYEE.pmp_title,dbo.Vacations_users.vacation_id , dbo.Vacations_summary.id, dbo.Vacations_users.type, ";
        sql += "   dbo.Vacations_users.manager_approve, dbo.Vacations_summary.emp_id,alternative_user_id, dbo.Vacations_summary.unusual, dbo.Vacations_summary.exhibitor, ";
        sql += "   dbo.Vacations_summary.sick, dbo.Vacations_summary.hajj, dbo.Vacations_summary.birth, dbo.Vacations_summary.year, ";
        sql += "    dbo.Vacations_summary.repeat,Vacations_summary.unusual_total,Vacations_summary.exhibitor_total, dbo.Vacations_users.no_days, dbo.Departments.Dept_name, dbo.Vacations_users.start_date,";
        sql += "     dbo.Vacations_users.end_date, dbo.Vacations_users.user_id, dbo.EMPLOYEE.status, ";
        sql += "  (SELECT  pmp_name FROM  dbo.EMPLOYEE WHERE (PMP_ID = dbo.Vacations_users.alternative_user_id)) AS alternative_user";
        sql += "   FROM  dbo.EMPLOYEE INNER JOIN";
        sql += "   dbo.Vacations_summary ON dbo.EMPLOYEE.PMP_ID = dbo.Vacations_summary.emp_id INNER JOIN";
        sql += "    dbo.Departments ON dbo.EMPLOYEE.Dept_Dept_id = dbo.Departments.Dept_ID INNER JOIN";
        sql += "   dbo.Vacations_users ON dbo.EMPLOYEE.PMP_ID = dbo.Vacations_users.user_id";
        sql += "   WHERE  (dbo.Vacations_users.manager_approve = 1) and dbo.EMPLOYEE.group_id <> 3 and status = 2  and status !=0 and dbo.Vacations_summary.year='" + CDataConverter.ConvertDateTimeNowRtnDt().Year  + "'";



        if (id != 0)
        {
            sql += " and dbo.Vacations_users.id = " + id;

        }

        //if (vacid_hidden.Value != "0")

        //{ sql += " AND dbo.Vacations_users.vacation_id = " + Convert.ToInt32(vacid_hidden.Value); }

        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            {
                string user = Session_CS.pmp_name.ToString();
                if (vacation_type  == 1)
                { s = Server.MapPath("../Reports/Vocations_Designated_unsu.rpt"); }
                if (vacation_type == 2)
                { s = Server.MapPath("../Reports/Vocations_Designated_ex.rpt"); }
                ReportDocument rd = new ReportDocument();
                rd.Load(s);
                ReportsClass.Reports.Load_Report(rd);
                rd.SetDataSource(dt);
                rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
                rd.SetParameterValue("@user", user, "footerRep.rpt");
                rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report");
            }
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

  
}
