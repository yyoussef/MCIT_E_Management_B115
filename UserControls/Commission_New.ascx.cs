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
using System.Data.Linq;
using System.Collections.Generic;
using System.Data.Entity.Core;

 


public partial class UserControls_Commission : System.Web.UI.UserControl
{


    Projects_ManagementEntities10 pmentity = new Projects_ManagementEntities10();
    private string sql_Connection = Database.ConnectionString;
    General_Helping Obj_General_Helping = new General_Helping();
    DateTime str_deadline;
    int id;
    OutboxDataContext outboxDBContext = new OutboxDataContext();
    //Session_CS Session_CS = new Session_CS();
    protected void Page_Load(object sender, EventArgs e)
    {
        Smart_Search_dept.Show_OrgTree = true;
        if (!IsPostBack)
        {
            
     
            str_deadline = CDataConverter.ConvertDateTimeNowRtnDt();
            DateTime str = CDataConverter.ConvertDateTimeNowRtnDt();
            tr_old_emp.Visible = false;

           // string sql_for_chklist_emp = " select * from pmp_fav_View where pmp_fav_View.employee_id = " + CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
            //DataTable dt_emp_fav = General_Helping.GetDataTable(sql_for_chklist_emp);

            var query = from pmp_fav in outboxDBContext.pmp_fav_Views where pmp_fav.employee_id == CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()) select pmp_fav;

           

            DataTable dt_emp_fav = query.ToDataTable();
            chklst_Visa_Emp_All.DataSource = dt_emp_fav;
            chklst_Visa_Emp_All.DataBind();
            
            TabPanel_All.ActiveTab = TabPanel_Visa;

            fil_emp_Visa();
            if (Request["id"] != null)
            {
                String decrypted_id = Encryption.Decrypt(Request.QueryString["id"].ToString());
                id = Convert.ToInt16(decrypted_id);
                hidden_Id.Value = id.ToString();
                Fil_Visa_Control(id);
                Fil_Visa_Lstbox(id);
                Fill_Controll(id);
                Fil_Grid_Documents();

                //Fil_Grid_Visa();

                Fil_Grid_Visa_Follow();
                Fil_Emp_Visa_Follow();

                if (CDataConverter.ConvertToInt(Session_CS.group_id.ToString()) == 3)
                {
                    Smart_Search_dept.SelectedValue = "15";
                    
                  
             
                    
                }

            }
            else
            {

                btn_print_report.Enabled = false;
               // str_deadline = System.DateTime.Now.AddDays(7);

                str_deadline = CDataConverter.ConvertDateTimeNowRtnDt().AddDays(7);
               // str = System.DateTime.Now;

                str = CDataConverter.ConvertDateTimeNowRtnDt();
            }


            txt_Visa_date.Text = CDataConverter.ConvertDateTimeNowRtrnString();
            txt_Follow_Date.Text = CDataConverter.ConvertDateTimeNowRtrnString();
            txt_Dead_Line_DT.Text = CDataConverter.ConvertDateTimeToFormatdmy(str_deadline);
            int period = str_deadline.Subtract(str).Days + 1;
            lbl_period.Text = period.ToString();


            if (Session_CS.pmp_id > 0)
            {
               // drop_sectors.SelectedValue = Session_CS.sec_id.ToString();
                fill_depts();
                TabPanel_All.ActiveTabIndex = 0;


            }

        }




    }

    //private void fill_sectors()
    //{
    //    DataTable dt = Sectors_DB.SelectAll(0, CDataConverter.ConvertToInt(Session_CS.foundation_id.ToString()));
    //    drop_sectors.DataSource = dt;

    //    drop_sectors.DataBind();
    //    drop_sectors.Items.Insert(0, new ListItem("إختر القطاع", "0"));

    //}



    protected void fill_depts()
    {
        //Smart_Search_dept.sql_Connection = sql_Connection;
        //string Query = "select Dept_ID,Dept_name , Dept_parent_id from Departments where foundation_id='" + Session_CS.foundation_id + "'";
        //Smart_Search_dept.datatble = General_Helping.GetDataTable(Query);
        //Smart_Search_dept.Value_Field = "Dept_ID";
        //Smart_Search_dept.Text_Field = "Dept_name";
        //Smart_Search_dept.Orderby = "ORDER BY LTRIM(Dept_name)";
        //Smart_Search_dept.DataBind();

        IEnumerable<Department> deptartments = from dep in outboxDBContext.Departments
                                               where dep.foundation_id == Session_CS.foundation_id
                                               select dep;

        DataTable deptartmentsdt = extentionMethods.ToDataTable<Department>(deptartments);
        Smart_Search_dept.datatble  = deptartmentsdt;
        Smart_Search_dept.Value_Field  = "Dept_id";
        Smart_Search_dept.Text_Field = "Dept_name";
        Smart_Search_dept.DataBind(); 

       //int found_id = CDataConverter.ConvertToInt(Session_CS.foundation_id);

       // var depts = from deppt in pmentity.Departments  where deppt.foundation_id == found_id orderby deppt.Dept_name  select deppt;

       // DataTable dt = depts.ToDataTable();

       // Smart_Search_dept.datatble = dt;
       // Smart_Search_dept.Value_Field = "Dept_ID";
       // Smart_Search_dept.Text_Field = "Dept_name";
       // Smart_Search_dept.DataBind();


        //int found_id = CDataConverter.ConvertToInt(Session_CS.foundation_id);

        //IEnumerable<Departments> deptartment = from deppt in pmentity.Departments
        //                                       where deppt.foundation_id == found_id
        //                                       orderby deppt.Dept_name.Trim()
        //                                       select deppt;


        //DataTable dt = extentionMethods.ToDataTable<Departments>(deptartment);
        //Smart_Search_dept.datatble = dt;
        //Smart_Search_dept.Value_Field = "Dept_ID";
        //Smart_Search_dept.Text_Field = "Dept_name";
        //Smart_Search_dept.DataBind();
        //////////////////////////////////////////////////////////



    }

    protected void txt_Visa_date_TextChanged(object sender, EventArgs e)
    {

    }
    protected void txt_Dead_Line_DT_TextChanged(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txt_Dead_Line_DT.Text) || string.IsNullOrEmpty(txt_Visa_date.Text))
        {
           // Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('يجب ادخال تاريخ التكليف و اخر تاريخ مسموح به ')</script>");

            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('يجب ادخال تاريخ التكليف و اخر تاريخ مسموح به');", true);

            return;
        }
        else if (txt_Dead_Line_DT.Text.Trim() == "")
        {
            //Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('يجب ادخال أخر  تاريخ مسموح به   بشكل صحيح ')</script>");

            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('يجب ادخال أخر  تاريخ مسموح به   بشكل صحيح');", true);

            return;
        }
        else
        {
            //string Strt_date = VB_Classes.Dates.Dates_Operation.date_validate(txt_Visa_date.Text);
            //string End_date = VB_Classes.Dates.Dates_Operation.date_validate(txt_Dead_Line_DT.Text);

            string Strt_date = txt_Visa_date.Text;
            string End_date = txt_Dead_Line_DT.Text;

            if (!VB_Classes.Dates.Dates_Operation.Date_compare(Strt_date, End_date))
            {
                if (!string.IsNullOrEmpty(Strt_date) && !string.IsNullOrEmpty(End_date))
                {
                    DateTime t2 = CDataConverter.ConvertToDate(txt_Dead_Line_DT.Text);//DateTime.Parse(txt_Dead_Line_DT.Text);
                    DateTime t1 = CDataConverter.ConvertToDate(txt_Visa_date.Text);//DateTime.Parse(txt_Visa_date.Text);
                    if (t1 < t2)
                    {
                        int Total_Days = t2.Subtract(t1).Days;//DateTime.ParseExact(End_date, "dd/MM/yyyy", null).Subtract(DateTime.ParseExact(Strt_date, "dd/MM/yyyy", null)).Days;
                        lbl_period.Text = Total_Days.ToString();
                    }
                    else
                    {
                        //Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('اخر تاريخ مسموح به يجب أن يكون أكبر من تاريخ التكليف ')</script>");

                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('اخر تاريخ مسموح به يجب أن يكون أكبر من تاريخ التكليف');", true);

                        return;
                    }



                }
                else
                {
                   // Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('أدخل التاريخ يوم/شهر/سنة ')</script>");

                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('أدخل التاريخ يوم/شهر/سنة');", true);

                    return;

                }
            }
            else
            {
                //Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('اخر تاريخ مسموح به يجب أن يكون أكبر من تاريخ التكليف')</script>");

                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('اخر تاريخ مسموح به يجب أن يكون أكبر من تاريخ التكليف');", true);

                return;

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
    private void Fill_Controll(int id)
    {
        try
        {
           //Commission_DT obj = Commission_DB.SelectByID(id);

            Commission obj = pmentity.Commission.Where(x => x.ID == id ).SingleOrDefault(); 

            hidden_Id.Value = obj.ID.ToString();
            drop_Resp_close_emp.SelectedValue = obj.Resp_emp_close.ToString();
            txt_Subject.Text = obj.Subject;




        }
        catch
        { }
    }


    protected void btnClear_Click(object sender, EventArgs e)
    {
        hidden_Id.Value = "";
        hidden_Visa_Id.Value = "";
        lst_emp.Items.Clear();
        lbl_period.Text = "";
        txt_Visa_Desc.Text = txt_Notes.Text = txt_Dead_Line_DT.Text = txt_Notes.Text = txt_Subject.Text = "";
        txtFileName.Text = "";
        GrdView_Documents.DataSource = null;
        GrdView_Documents.DataBind();
        GridView_Visa.DataSource = null;
        GridView_Visa.DataBind();
        lst_emp.Items.Clear();


    }

    protected void btn_send_Click(object sender, EventArgs e)
    {
        ////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////// Sending Mail Code /////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////
        if (CDataConverter.ConvertToInt(hidden_Id.Value) > 0)
        {
          //  DataTable dt = General_Helping.GetDataTable("select * from Commission_Files where Commission_ID = " + hidden_Id.Value);
            int com_id = CDataConverter.ConvertToInt(hidden_Id.Value);
            var query = from comm_file in pmentity.Commission_Files where comm_file.Commission_ID ==com_id  select comm_file;
            DataTable dt = query.ToDataTable();

            if (CDataConverter.ConvertToInt(hidden_Visa_Id.Value) > 0)
            {

                //if (dt.Rows.Count > 0)
                //{
                send_visa(hidden_Visa_Id.Value);

                //}
                //else
                //{
                //    Page.RegisterStartupScript("Sucess", "<script language=javascript>if(confirm('لا يوجد ملفات مرفقة لهذا التكليف !!! هل انت واثق من انك تود ارساله ؟؟?') == false) return false;</script>");
                //    if (System.Windows.Forms.MessageBox.Show("لا يوجد ملفات مرفقة لهذا التكليف !!! هل انت واثق من انك تود ارساله ؟؟?", "تحذيــر", System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                //    {

                //send_visa(hidden_Visa_Id.Value);

                //}
                //else
                //{
                //    Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('برجاء ادخال الملفات المرفقة')</script>");
                //}

            }
        }



        else

           // Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لم يتم ادخال بيانات التكليف')</script>");

        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('لم يتم ادخال بيانات التكليف');", true);

    }
    //public void send_visa(string visa_id)
    //{
    //    string dept = Session_CS.dept.ToString();
    //    string name = "";
    //    string Succ_names = "", Failed_name = "";
    //    DataTable dt_Commission_Visa = General_Helping.GetDataTable("select * from Commission_Visa_Emp where Visa_Id =" + hidden_Visa_Id.Value);
    //    foreach (DataRow item in dt_Commission_Visa.Rows)
    //    {
    //        //commented by youssef because i can't understand it

    //        //if (CDataConverter.ConvertToInt(Session_CS.parent_id.ToString()) == 0)
    //        //{
    //        //    DataTable dt_parent = General_Helping.GetDataTable("select * from parent_employee where pmp_id = " + CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()));
    //        //    if (CDataConverter.ConvertToInt(item["Emp_id"].ToString()) == CDataConverter.ConvertToInt(dt_parent.Rows[0]["parent_pmp_id"].ToString()))
    //        //    {
    //        //        Commission_DB.update_Commission_Track_Emp(hidden_Id.Value, item["Emp_ID"].ToString(), 2, 1);
    //        //    }
    //        //    else
    //        //        Commission_DB.update_Commission_Track_Emp(hidden_Id.Value, item["Emp_ID"].ToString(), 1, 1);
    //        //}
    //        //else
    //        //{
    //        if (CDataConverter.ConvertToInt(item["Emp_id"].ToString()) == CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()))
    //        {
    //            Commission_DB.update_Commission_Track_Emp(hidden_Id.Value, item["Emp_ID"].ToString(), 2, 1);
    //        }
    //        else
    //            Commission_DB.update_Commission_Track_Emp(hidden_Id.Value, item["Emp_ID"].ToString(), 1, 1);
    //        //}
    //        /////////// handle that the commission appears as جاري at dr hesham///////////////////////



    //        //if (CDataConverter.ConvertToInt(Session_CS.parent_id.ToString()) > 0)
    //        //{
    //        //    if (CDataConverter.ConvertToInt(item["Emp_id"].ToString()) == CDataConverter.ConvertToInt(Session_CS.parent_id.ToString()))
    //        //    {
    //        //        sqlformail += " and pmp_id <> " + CDataConverter.ConvertToInt(Session_CS.parent_id.ToString());
    //        //    }

    //        //}
    //        Update_Have_Visa(hidden_Visa_Id.Value);

    //        if (CDataConverter.ConvertToInt(item["Emp_id"].ToString()) != CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()))
    //        {
    //            string sqlformail = "SELECT * from employee ";
    //            sqlformail += " where pmp_id= " + item["Emp_ID"].ToString();
    //            //sqlformail += " and pmp_id <> " + CDataConverter.ConvertToInt(Session_CS.parent_id.ToString());


    //            DataTable ds = General_Helping.GetDataTable(sqlformail);
    //            ////////////////// this great if cond is to handle if dr hesham howa ele da7'el/////////
    //            //////////////////// we esmo mwgood fe el t2shera mesh ytb3tlo mail////////////////
    //            if (ds.Rows.Count > 0)
    //            {
    //                string mail = ds.Rows[0]["mail"].ToString();

    //                name = ds.Rows[0]["pmp_name"].ToString();


    //                MailMessage _Message = new MailMessage();
    //                string str_subj = "";

    //                ///////////////////// handling size of mail subject
    //                if (txt_Subject.Text.Length > 160)
    //                {
    //                    if (int.Parse(Session_CS.group_id.ToString()) == 3)
    //                    {
    //                        str_subj = txt_Subject.Text.Substring(0, 160);
    //                    }
    //                    else
    //                        str_subj = txt_Subject.Text.Substring(0, 130);


    //                }
    //                else
    //                {
    //                    str_subj = txt_Subject.Text;
    //                }


    //                string str_witoutn = str_subj.Replace("\n", "");
    //                str_subj = str_witoutn.Replace("\r", "");

    //                if (int.Parse(Session_CS.group_id.ToString()) == 3)
    //                {

    //                    _Message.Subject = ("INIR" + " - " + str_subj + " - " + txt_Visa_date.Text).ToString();
    //                }
    //                else
    //                {

    //                    _Message.Subject = "نظام الادارة الالكترونية - المراسلات" + " - " + str_subj + " - " + txt_Visa_date.Text;
    //                }

    //                //////////////////////////////////////////////////////////////////////////////
    //                //_Message.BodyEncoding = Encoding.Unicode;
    //                _Message.BodyEncoding = Encoding.UTF8;
    //                _Message.SubjectEncoding = Encoding.UTF8;

    //                string address = System.Web.HttpContext.Current.Request.ServerVariables["LOCAL_ADDR"];


    //                string address2 = System.Web.HttpContext.Current.Request.Url.Authority.ToString();
    //                String encrypted_id = Encryption.Encrypt(hidden_Id.Value);


    //                bool flag = false;
    //                DataTable dt = General_Helping.GetDataTable("select * from Commission_Files where Commission_ID =" + hidden_Id.Value);
    //                foreach (DataRow dr in dt.Rows)
    //                {

    //                    if (dr["File_data"] != DBNull.Value)
    //                    {

    //                        string file = dr["File_name"].ToString() + dr["File_ext"].ToString();
    //                        byte[] files = (byte[])dr["File_data"];
    //                        MemoryStream ms = new MemoryStream(files);
    //                        _Message.Attachments.Add(new Attachment(ms, file));
    //                        flag = true;

    //                    }
    //                }

    //                //else
    //                //{
    //                //    _Message.Body = " السيد " + name + " \n\n";
    //                //    _Message.Body += " وصلكم صادر من " + dept + " " + " بتاريخ " + txt_Visa_date.Text;
    //                //}
    //                _Message.IsBodyHtml = true;
    //                _Message.Body = "<html><body dir='rtl'><h3 > السيد - " + name + " </h3>";
    //                //if (CDataConverter.ConvertToInt(Session_CS.parent_id.ToString()) == 0)
    //                //{
    //                //    DataTable dt_parent = General_Helping.GetDataTable("select * from parent_employee where pmp_id = " + CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()));
    //                //    if (CDataConverter.ConvertToInt(item["Emp_id"].ToString()) == CDataConverter.ConvertToInt(dt_parent.Rows[0]["parent_pmp_id"].ToString()))
    //                //    {
    //                //        _Message.Body += " <h3 > " + "  وصلكم تكليف تم إدخالة بواسطة مدخل البيانات " + "" + " بتاريخ " + txt_Visa_date.Text + " بخصوص  <br/>" + "<h3 style=" + "color:blue >" + txt_Subject.Text + "</h3>" + " </h3>";
    //                //        _Message.Body += " <h3 > " + "  وتكليف  سيادتكم أن :" + "<h3 style=" + "color:blue >" + txt_Visa_Desc.Text + "</h3>" + " </h3>";
    //                //    }
    //                //    else
    //                //    {
    //                //        _Message.Body += " <h3 > " + "  وصلكم تكليف من الادارة العليا لقطاع البنية المعلوماتية " + "" + " بتاريخ " + txt_Visa_date.Text + " بخصوص  <br/>" + "<h3 style=" + "color:blue >" + txt_Subject.Text + "</h3>" + " </h3>";
    //                //        _Message.Body += " <h3 > " + "  وتكليف  السيد المدير المختص أن :" + "<h3 style=" + "color:blue >" + txt_Visa_Desc.Text + "</h3>" + " </h3>";
    //                //    }

    //                //}
    //                //else
    //                //{
    //                _Message.Body += " <h3 > " + "  وصلكم تكليف  " + "" + " بتاريخ " + txt_Visa_date.Text + " بخصوص  <br/>" + "<h3 style=" + "color:blue >" + txt_Subject.Text + "</h3>" + " </h3>";
    //                _Message.Body += " <h3 > " + "  ونص التكليف :" + "<h3 style=" + "color:blue >" + txt_Visa_Desc.Text + "</h3>" + " </h3>";
    //                //  }
    //                _Message.Body += " <h3 > ورابط التكليف هو  :<br/>";
    //                //  _Message.Body += " <h3 >http:" + "/" + "/" + "pms.gov/WebForms/View_Commission.aspx?id=" + hidden_Id.Value + " </h3>";

    //                _Message.Body += " <h3 >http:" + "/" + "/" + address2 + "/MainForm/View_Commission.aspx?id=" + encrypted_id +"&test=test </h3>";


    //                if (flag)
    //                    _Message.Body += "<h3 >  " + " ومرفق الوثائق الخاصة بهذا التكليف</h3> ";

    //                ////////http://localhost:4665/Projects_Management/WebForms2/ViewProjectInbox.aspx?id=5458


    //                _Message.Body += "<h3 > مع تحيات </h3> ";
    //                _Message.Body += "<h3 >   " + Session_CS.e_signature.ToString() + "  </h3> ";
    //                _Message.Body += "</body></html>";

    //                //////





    //                /////////////////////// update have visa = 0/////////////////////////////////////////////

    //                ////SmtpClient config
    //                SmtpClient Client = new SmtpClient();
    //                Client.Port = int.Parse(ConfigurationManager.AppSettings["SMTP_Port"]);
    //                Client.Host = ConfigurationManager.AppSettings["SMTP_Host"];
    //                string UserName = ConfigurationManager.AppSettings["SMTP_UserName"];
    //                string Password = ConfigurationManager.AppSettings["SMTP_Password"];
    //                _Message.From = new MailAddress(ConfigurationManager.AppSettings["SMTP_FromAddress"]);

    //                //_Message.Attachments.Add(new Attachment("D:\\Attached.pdf"));
    //                System.Net.NetworkCredential SMTPUserInfo = new System.Net.NetworkCredential(UserName, Password);

    //                Client.UseDefaultCredentials = false;
    //                Client.Credentials = SMTPUserInfo;
    //                Client.Timeout = 1000000000;
    //                try
    //                {
    //                    _Message.To.Add(new MailAddress(mail));

    //                    Client.Send(_Message);


    //                    Succ_names += name + ",";


    //                }
    //                catch (Exception ex)
    //                {
    //                    Failed_name += name + ",";

    //                    //Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لم يتم ارسال الايميل بنجاح' )</script>");

    //                }
    //            }
    //        }
    //        //DataTable DT = General_Helping.GetDataTable(sqlformail);

    //    }
    //    string message = Show_Alert(Succ_names, Failed_name, hidden_Visa_Id.Value);
    //    if (!string.IsNullOrEmpty(message))
    //    {
    //        //Fil_Grid_Visa();
    //        ///////////////  to store that mohammed eid send visa to employee
    //        Commission_Visa_Follows_DT obj_follow = Commission_Visa_Follows_DB.SelectByID(CDataConverter.ConvertToInt(hidden_Follow_ID.Value));
    //        obj_follow.Follow_ID = CDataConverter.ConvertToInt(hidden_Follow_ID.Value);
    //        obj_follow.Commission_ID = CDataConverter.ConvertToInt(hidden_Id.Value);

    //        obj_follow.Descrption = message + " بواسطة النظام -- ";
    //        string date = DateTime.Now.ToShortDateString().ToString();
    //        obj_follow.Date = date;
    //        obj_follow.time_follow = DateTime.UtcNow.ToLocalTime().ToLongTimeString();
    //        obj_follow.entery_pmp_id = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());

    //        obj_follow.Visa_Emp_id = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
    //        obj_follow.Follow_ID = Commission_Visa_Follows_DB.Save(obj_follow);
    //        Fil_Grid_Visa_Follow();

    //        //SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
    //        //DataTable DT = new DataTable();
    //        //DT = General_Helping.GetDataTable("select * from Inbox_Track_Manager where inbox_id = " + hidden_Id.Value);
    //        //if (DT.Rows.Count > 0)
    //        //{
    //        //    conn.Open();
    //        //    string sql = "update Inbox_Track_Manager set Have_Follow=0,All_visa_sent=0,Have_Visa=1,IS_Old_Mail=0,IS_New_Mail=0 where inbox_id =" + hidden_Id.Value;
    //        //    SqlCommand cmd = new SqlCommand(sql, conn);
    //        //    cmd.ExecuteNonQuery();
    //        //    conn.Close();

    //        //}
    //        Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('" + message + "')</script>");
    //    }

    //}

    public  void update_Commission_Track_Emp2(string Commission_id, string Emp_ID, int Commission_Status, int Type)
    {
        //DataTable DT = General_Helping.GetDataTable("select * from Commission_Track_Emp where Commission_id = " + Commission_id + " and Emp_ID =" + Emp_ID);
        int Commnid = CDataConverter.ConvertToInt(Commission_id);
        int EmpID = CDataConverter.ConvertToInt(Emp_ID);
        Commission_Track_Emp comm_track_obj = new Commission_Track_Emp();
        var orign = from com_tra_emp in pmentity.Commission_Track_Emp where com_tra_emp.Commission_id == Commnid && com_tra_emp.Emp_ID == EmpID select com_tra_emp;
        DataTable DT = orign.ToDataTable();
      
          if (DT.Rows.Count > 0)
        {
              
            using (var db = new Projects_ManagementEntities10())
            {

                IQueryable<Commission_Track_Emp> comm_trackk = db.Commission_Track_Emp.Where(x => x.Commission_id == Commnid && x.Emp_ID == EmpID);

                foreach (Commission_Track_Emp comm_tra in comm_trackk)
                {
                    comm_tra.Commission_Status = Commission_Status;
                }
                db.SaveChanges();
            }

            //string sql = "update Commission_Track_Emp set Commission_Status= " + Commission_Status + " where Commission_id =" + Commission_id + " and Emp_ID =" + Emp_ID;
            //General_Helping.ExcuteQuery(sql);

            
        }
        else
        {
            //string sql = "insert into Commission_Track_Emp (Commission_id,Emp_ID,Commission_Status,Type_Track_emp) values ( " + Commission_id + "," + Emp_ID + "," + Commission_Status + "," + "1" + ")";
            //General_Helping.ExcuteQuery(sql);

            comm_track_obj.Commission_Status = Commission_Status;
            comm_track_obj.Commission_id = Commnid;
            comm_track_obj.Emp_ID = EmpID;
            comm_track_obj.Type_Track_emp = 1;
            pmentity.Entry(comm_track_obj).State = System.Data.Entity.EntityState.Added;
            pmentity.SaveChanges();

        }

    }


    public void send_visa(string visa_id)
    {
        string dept = Session_CS.dept.ToString();
        string name = "";
        string Succ_names = "", Failed_name = "";
       // DataTable dt_Commission_Visa = General_Helping.GetDataTable("select * from Commission_Visa_Emp where Visa_Id =" + hidden_Visa_Id.Value);
        int v_id = CDataConverter.ConvertToInt(hidden_Visa_Id.Value);
        var query = from comm_v_emp in pmentity.Commission_Visa_Emp where comm_v_emp.Visa_Id ==v_id  select comm_v_emp ;
        DataTable dt_Commission_Visa = query.ToDataTable();

        foreach (DataRow item in dt_Commission_Visa.Rows)
        {

        //    Commission_DB.update_Commission_Track_Emp(hidden_Id.Value, item["Emp_ID"].ToString(), 1, 1);

            update_Commission_Track_Emp2(hidden_Id.Value, item["Emp_ID"].ToString(), 1, 1);

            //string sqlformail = "SELECT * from employee ";
            //sqlformail += " where pmp_id= " + item["Emp_ID"].ToString();
          //  DataTable ds = General_Helping.GetDataTable(sqlformail);

            int pm = CDataConverter.ConvertToInt(item["Emp_ID"].ToString());

            var sqlformail = from sql_emp in outboxDBContext.EMPLOYEEs where sql_emp.PMP_ID == pm select sql_emp;
            DataTable ds = sqlformail.ToDataTable();


            ////////////////// this great if cond is to handle if dr hesham howa ele da7'el/////////
            //////////////////// we esmo mwgood fe el t2shera mesh ytb3tlo mail////////////////
            if (ds.Rows.Count > 0)
            {
                string mail = ds.Rows[0]["mail"].ToString();
                name = ds.Rows[0]["pmp_name"].ToString();
                MailMessage _Message = new MailMessage();
                string str_subj = "";

                ///////////////////// handling size of mail subject
                if (txt_Subject.Text.Length > 160)
                {
                    if (int.Parse(Session_CS.group_id.ToString()) == 3)
                    {
                        str_subj = txt_Subject.Text.Substring(0, 160);
                    }
                    else
                        str_subj = txt_Subject.Text.Substring(0, 130);


                }
                else
                {
                    str_subj = txt_Subject.Text;
                }


                string str_witoutn = str_subj.Replace("\n", "");
                str_subj = str_witoutn.Replace("\r", "");

                if (int.Parse(Session_CS.group_id.ToString()) == 3)
                {

                    _Message.Subject = ("Com" + " - " + str_subj + " - " + txt_Visa_date.Text).ToString();
                }
                else
                {

                    _Message.Subject = "نظام الادارة الالكترونية - المراسلات" + " - " + str_subj + " - " + txt_Visa_date.Text;
                }

                //////////////////////////////////////////////////////////////////////////////
       


                bool flag = false;
                string file = "";
                byte[] files = new byte[0];
                MemoryStream ms = new MemoryStream();
               // DataTable dt = General_Helping.GetDataTable("select * from Commission_Files where Commission_ID =" + hidden_Id.Value);

                int hid_id = CDataConverter.ConvertToInt(hidden_Id.Value);

                var comm_file = from co_file in pmentity.Commission_Files where co_file.Commission_ID == hid_id select co_file;

                DataTable dt = comm_file.ToDataTable();
                foreach (DataRow dr in dt.Rows)
                {

                    if (dr["File_data"] != DBNull.Value)
                    {

                        file = dr["File_name"].ToString() + dr["File_ext"].ToString();
                        files = (byte[])dr["File_data"];
                        ms = new MemoryStream(files);
                        _Message.Attachments.Add(new Attachment(ms, file));
                        flag = true;

                    }
                }

               

                string address2 = System.Web.HttpContext.Current.Request.Url.Authority.ToString();
                String encrypted_id = Encryption.Encrypt(hidden_Id.Value);
                //_Message.IsBodyHtml = true;
                _Message.Body = "<html><body dir='rtl'><h3 > السيد - " + name + " </h3>";
              
                _Message.Body += " <h3 > " + "  وصلكم تكليف  " + "" + " بتاريخ " + txt_Visa_date.Text + " بخصوص  <br/>" + "<h3 style=" + "color:blue >" + txt_Subject.Text + "</h3>" + " </h3>";
                _Message.Body += " <h3 > " + "  ونص التكليف :" + "<h3 style=" + "color:blue >" + txt_Visa_Desc.Text + "</h3>" + " </h3>";
                //  }
                _Message.Body += " <h3 > ورابط التكليف هو  :<br/>";

                _Message.Body += " <h3 >http:" + "/" + "/" + address2 + "/MainForm/View_Commission.aspx?id=" + encrypted_id + "&1=1 </h3>";


                if (flag)
                    _Message.Body += "<h3 >  " + " ومرفق الوثائق الخاصة بهذا التكليف</h3> ";



                _Message.Body += "<h3 > مع تحيات </h3> ";
                _Message.Body += "<h3 >   " + Session_CS.e_signature.ToString() + "  </h3> ";
                _Message.Body += "</body></html>";



                /////////////////////// update have visa = 0/////////////////////////////////////////////

              
                Inbox_Visa_DT obj = Inbox_Visa_DB.SelectByID(CDataConverter.ConvertToInt(visa_id));
                


                obj.mail_sent = 1;
                Inbox_Visa_DB.Save(obj);
                /////////////////////// update have visa = 0/////////////////////////////////////////////
                Update_Have_Visa(visa_id);
                try
                {
                    SendingMailthread_class.Sendingmail(_Message,_Message.Subject, _Message.Body, mail, ms, file, encrypted_id, "");


                    Succ_names += name + ",";


                }
                catch (Exception ex)
                {
                    Failed_name += name + ",";


                }
            }
      

        }
        string message = Show_Alert(Succ_names, Failed_name, hidden_Visa_Id.Value);
        if (!string.IsNullOrEmpty(message))
        {
            //Fil_Grid_Visa();
            ///////////////  to store that mohammed eid send visa to employee
         Commission_Visa_Follows_DT obj_follow = Commission_Visa_Follows_DB.SelectByID(CDataConverter.ConvertToInt(hidden_Follow_ID.Value));

         //   int foll_id = CDataConverter.ConvertToInt(hidden_Follow_ID.Value);
           // Commission_Visa_Follows obj_follow = pmentity.Commission_Visa_Follows.Where( x => x.Follow_ID == foll_id  ).SingleOrDefault();

            obj_follow.Follow_ID = CDataConverter.ConvertToInt(hidden_Follow_ID.Value);
            obj_follow.Commission_ID = CDataConverter.ConvertToInt(hidden_Id.Value);

            obj_follow.Descrption = message + " بواسطة النظام -- ";
            string date = CDataConverter.ConvertDateTimeToFormatdmy(CDataConverter.ConvertDateTimeNowRtnDt());
            obj_follow.Date = date;
            //obj_follow.time_follow = DateTime.UtcNow.ToLocalTime().ToLongTimeString();

            obj_follow.time_follow = CDataConverter.ConvertDateTimeNowRtnDt().ToLongTimeString();
            obj_follow.entery_pmp_id = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());

            obj_follow.Visa_Emp_id = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());

           obj_follow.Follow_ID = Commission_Visa_Follows_DB.Save(obj_follow);

           // InsertOrUpdate_Commission_Visa_follows(obj_follow);


            Fil_Grid_Visa_Follow();

            //SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            //DataTable DT = new DataTable();
            //DT = General_Helping.GetDataTable("select * from Inbox_Track_Manager where inbox_id = " + hidden_Id.Value);
            //if (DT.Rows.Count > 0)
            //{
            //    conn.Open();
            //    string sql = "update Inbox_Track_Manager set Have_Follow=0,All_visa_sent=0,Have_Visa=1,IS_Old_Mail=0,IS_New_Mail=0 where inbox_id =" + hidden_Id.Value;
            //    SqlCommand cmd = new SqlCommand(sql, conn);
            //    cmd.ExecuteNonQuery();
            //    conn.Close();

            //}
           // Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('" + message + "')</script>");
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('"+message +"');", true);

        }

    }




    private void Fil_Emp_Visa_Follow()
    {
        if (CDataConverter.ConvertToInt(hidden_Id.Value) > 0)
        {
            
           int xx= CDataConverter.ConvertToInt(hidden_Id.Value);
            DataTable DT = new DataTable();
            //string sql = " SELECT     distinct EMPLOYEE.PMP_ID, EMPLOYEE.pmp_name, Commission_Visa.Commission_ID " +
            //             " FROM         Commission_Visa_Emp INNER JOIN  EMPLOYEE ON Commission_Visa_Emp.Emp_ID = EMPLOYEE.PMP_ID INNER JOIN  Commission_Visa ON Commission_Visa_Emp.Visa_Id = Commission_Visa.Visa_Id INNER JOIN Commission ON Commission_Visa.Commission_ID = Commission.ID " +
            //             " where Commission_ID=" + hidden_Id.Value;

       
               
                         
           // DT = General_Helping.GetDataTable(sql);

            DT = pmentity.get_Emp_Visa_Follow(xx).ToDataTable();


            Obj_General_Helping.SmartBindDDL(ddl_Visa_Emp_id, DT, "PMP_ID", "pmp_name", "....اختر اسم الموظف ....");
        }
    }
    protected override void OnInit(EventArgs e)
    {
        #region BROWSER FOR departments



        //Smart_Search_dept.sql_Connection = sql_Connection;
        ////Smart_Search_dept.Query = "SELECT Dept_id, Dept_name FROM Departments ";
        //string Query = "SELECT Dept_id, Dept_name ,Dept_parent_id FROM Departments where foundation_id='" + Session_CS.foundation_id + "'";
        //Smart_Search_dept.datatble = General_Helping.GetDataTable(Query);
        //Smart_Search_dept.Value_Field = "Dept_id";
        //Smart_Search_dept.Text_Field = "Dept_name";
        //Smart_Search_dept.DataBind();


        IEnumerable<Department> deptartments = from dep in outboxDBContext.Departments
                                               where dep.foundation_id == Session_CS.foundation_id
                                               select dep;

        DataTable deptartmentsdt = extentionMethods.ToDataTable<Department>(deptartments);
        Smart_Search_dept.datatble = deptartmentsdt;
        Smart_Search_dept.Value_Field = "Dept_id";
        Smart_Search_dept.Text_Field = "Dept_name";
        Smart_Search_dept.DataBind();



      //  int found_id = CDataConverter.ConvertToInt(Session_CS.foundation_id);

      //  //IEnumerable<Departments> deptartment = from deppt in pmentity.Departments
      //  //                                       where deppt.foundation_id == found_id
      //  //                                       orderby deppt.Dept_name.Trim()
      //  //                                       select deppt;

      //  //DataTable dt = extentionMethods.ToDataTable<Departments>(deptartment);

      //List<Departments> dep = pmentity.Departments.Where(x => x.foundation_id == found_id).ToList();

      //DataTable dt = dep.ToDataTable();

      // Smart_Search_dept.datatble = dt;
      //  Smart_Search_dept.Value_Field = "Dept_ID";
      //  Smart_Search_dept.Text_Field = "Dept_name";
      //  Smart_Search_dept.DataBind();

        this.Smart_Search_dept.Value_Handler += new Smart_Search.Delegate_Selected_Value(MOnMember_Data);
        #endregion
        base.OnInit(e);
    }
    private void MOnMember_Data(string Value)
    {
        dropdept_fun();
        
    }
    protected void dropdept_fun()
    {



        fil_emp_Visa();

        tr_emp_list.Visible = true;
        string sql, sql_emp = "";

        tr_emp_list.Visible = true;
       // string sql, sql_emp = "";
        int dept_selected = CDataConverter.ConvertToInt(Smart_Search_dept.SelectedValue);
        int session_found = CDataConverter.ConvertToInt(Session_CS.foundation_id);
     //   var emp_query = default(object);


        if (radlst_Type.SelectedValue != "7")
        {


            DataTable DT_emp;

            SqlParameter[] sqlParams = new SqlParameter[4];

            sqlParams[0] = new SqlParameter("@radiocheck", radlst_Type.SelectedValue);
            sqlParams[1] = new SqlParameter("@pmp_id", Session_CS.pmp_id);

            if (CDataConverter.ConvertToInt(Smart_Search_dept.SelectedValue) > 0)
                sqlParams[2] = new SqlParameter("@dept_id", CDataConverter.ConvertToInt(Smart_Search_dept.SelectedValue));
            else
                sqlParams[2] = new SqlParameter("@dept_id", CDataConverter.ConvertToInt(DBNull.Value));

            sqlParams[3] = new SqlParameter("@found_id", Session_CS.foundation_id);

            DT_emp = DatabaseFunctions.SelectDataByParam(sqlParams, "get_employee_accoording_to_radiochek");
            if (DT_emp.Rows.Count > 0)
            {
                chklst_Visa_Emp_All.DataSource = DT_emp;
                chklst_Visa_Emp_All.DataBind();
            }
        }

        TabPanel_All.ActiveTab = TabPanel_Visa;


        //if (radlst_Type.SelectedValue == "1")
        //{
        //    sql_emp = " select * from pmp_fav_View where pmp_fav_View.employee_id = " + CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());

        //    int pmp = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());

        //  //  emp_query = from emmp in pmentity.pmp_fav_View where emmp.employee_id == pmp select emmp;

        //    if (Smart_Search_dept.SelectedValue != "")
        //    {
        //        sql_emp += " AND Dept_Dept_id = " + Smart_Search_dept.SelectedValue;

        //       // emp_query = from emmp in pmentity.pmp_fav_View where emmp.employee_id == pmp && emmp.Dept_Dept_id == dept_selected select emmp;
        //    }




        //}
        //else if (radlst_Type.SelectedValue == "2")
        //{

        //    sql_emp = "SELECT     EMPLOYEE.*,Departments.* FROM Departments  INNER JOIN EMPLOYEE ON Departments.Dept_id = EMPLOYEE.Dept_Dept_id where  EMPLOYEE.PMP_ID not in(select parent_pmp_id from dbo.parent_employee) and dbo.EMPLOYEE.workstatus = 1 and EMPLOYEE.foundation_id='" + Session_CS.foundation_id + "'";

        //    //emp_query = (from empp in pmgeneralentity.EMPLOYEE
        //    //             join deppp in pmgeneralentity.Departments on empp.Dept_Dept_id equals deppp.Dept_id
        //    //             where empp.foundation_id == session_found
        //    //             select new
        //    //             {

        //    //             }


        //    //            );

        //    if (Smart_Search_dept.SelectedValue != "")
        //    {
        //         sql_emp += " and Dept_Dept_id = " + Smart_Search_dept.SelectedValue;

        //        //emp_query = (from empp in pmgeneralentity.EMPLOYEE
        //        //             join deppp in pmgeneralentity.Departments on empp.Dept_Dept_id equals deppp.Dept_id
        //        //             where empp.foundation_id == session_found && empp.Dept_Dept_id == dept_selected
        //        //             select new
        //        //             {

        //        //             }


        //        //   );
        //    }

        //}
        //else if (radlst_Type.SelectedValue == "3")
        //{
        //    // sql_emp = " select * from employee where rol_rol_id=3  and dbo.EMPLOYEE.workstatus = 1";

        //    sql_emp = "SELECT     EMPLOYEE.*,Departments.* FROM Departments  INNER JOIN EMPLOYEE ON Departments.Dept_id = EMPLOYEE.Dept_Dept_id where dbo.EMPLOYEE.workstatus = 1 and rol_rol_id=3 and EMPLOYEE.foundation_id='" + Session_CS.foundation_id + "'";


        //    if (Smart_Search_dept.SelectedValue != "")
        //    {
        //        sql_emp += " AND Dept_Dept_id = " + Smart_Search_dept.SelectedValue;
        //    }

        //    //if (drop_sectors.SelectedValue != "" && drop_sectors.SelectedValue != "0")
        //    //{
        //    //    sql_emp += "and  Sectors.Sec_id=" + drop_sectors.SelectedValue;
        //    //}

        //}
        //else if (radlst_Type.SelectedValue == "4")
        //{
        //    // sql_emp = " select * from employee where contact_person=1 and dbo.EMPLOYEE.workstatus = 1 ";

        //    sql_emp = "SELECT     EMPLOYEE.*,  Sectors.*,Departments.* FROM Departments INNER JOIN Sectors ON Departments.Sec_sec_id = Sectors.Sec_id INNER JOIN EMPLOYEE ON Departments.Dept_id = EMPLOYEE.Dept_Dept_id where dbo.EMPLOYEE.workstatus = 1 and contact_person=1 and EMPLOYEE.foundation_id='" + Session_CS.foundation_id + "' ";

        //    if (Smart_Search_dept.SelectedValue != "")
        //    {
        //        sql_emp += " AND Dept_Dept_id = " + Smart_Search_dept.SelectedValue;
        //    }

        //    //if (drop_sectors.SelectedValue != "" && drop_sectors.SelectedValue != "0")
        //    //{
        //    //    sql_emp += "and  Sectors.Sec_id=" + drop_sectors.SelectedValue;
        //    //}

        //}

        //else if (radlst_Type.SelectedValue == "5")
        //{
        //    sql_emp = "  select EMPLOYEE.pmp_name + ' - رئيس ' + +' '+ Commitee.Commitee_Title as pmp_name ,EMPLOYEE.PMP_ID from EMPLOYEE inner join commitee_presidents on  EMPLOYEE.PMP_ID=commitee_presidents.pmp_id inner join Commitee on commitee_presidents.comt_id = Commitee.ID where  Commitee.foundation_id='" + Session_CS.foundation_id + "'";

        //}

        //else if (radlst_Type.SelectedValue == "6")
        //{

        //    sql_emp = "select EMPLOYEE.pmp_name COLLATE DATABASE_DEFAULT  + ' -  ' + Departments.Dept_name  as pmp_name,EMPLOYEE.PMP_ID from EMPLOYEE inner join commitee_presidents on  EMPLOYEE.PMP_ID=commitee_presidents.pmp_id inner join Departments on  commitee_presidents.dept_id = Departments.Dept_id   inner join Sectors  on Sectors.Sec_id = Departments.Sec_sec_id where Sectors.foundation_id='" + Session_CS.foundation_id + "'";
        //}

        //TabPanel_All.ActiveTab = TabPanel_Visa;
        //DataTable dt_emp_fav = General_Helping.GetDataTable(sql_emp);
        //chklst_Visa_Emp_All.DataSource = dt_emp_fav;
        //chklst_Visa_Emp_All.DataBind();


       

    }



    protected void ddl_Type_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Type_Changed();

    }

    protected void ddl_Dept_ID_SelectedIndexChanged(object sender, EventArgs e)
    {
        fil_emp();
    }

    protected void ddl_Follow_Up_Dept_ID_SelectedIndexChanged(object sender, EventArgs e)
    {
        fil_emp_Folow_Up();
    }




    private void fil_emp_Visa()
    {
        int Dept_ID = CDataConverter.ConvertToInt(Smart_Search_dept.SelectedValue);

       // string sql = "SELECT PMP_ID, pmp_name FROM EMPLOYEE where 1=1";

        var results = from empm in outboxDBContext.EMPLOYEEs select empm;

        if (Dept_ID > 0)
        {
          //  sql += " AND Dept_Dept_id = " + Dept_ID;

            results = results.Where(x => x.Dept_Dept_id==Dept_ID).OrderBy(xx => xx.pmp_name);
        }
       // sql += " order by pmp_name asc";

      //  chklst_Visa_Emp.DataSource = General_Helping.GetDataTable(sql);

        chklst_Visa_Emp.DataSource = results.ToDataTable();
        chklst_Visa_Emp.DataBind();

    }


    private void fil_emp_Folow_Up()
    {
        //int Dept_ID = CDataConverter.ConvertToInt(ddl_Follow_Up_Dept_ID.SelectedValue);
        //if (Dept_ID > 0)
        //{
        //    Smart_Follow_Up_Emp_ID.sql_Connection = sql_Connection;
        //    Smart_Follow_Up_Emp_ID.Query = "SELECT PMP_ID, pmp_name FROM EMPLOYEE where Dept_Dept_id = " + Dept_ID;
        //    Smart_Follow_Up_Emp_ID.Value_Field = "PMP_ID";
        //    Smart_Follow_Up_Emp_ID.Text_Field = "pmp_name";
        //    Smart_Follow_Up_Emp_ID.DataBind();
        //}
        //else
        //    Smart_Follow_Up_Emp_ID.Clear_Controls();
    }

    private void fil_emp()
    {
        //int Dept_ID = CDataConverter.ConvertToInt(ddl_Dept_ID.SelectedValue);
        //if (Dept_ID > 0)
        //{
        //    Smart_Emp_ID.sql_Connection = sql_Connection;
        //    Smart_Emp_ID.Query = "SELECT PMP_ID, pmp_name FROM EMPLOYEE where Dept_Dept_id = " + Dept_ID;
        //    Smart_Emp_ID.Value_Field = "PMP_ID";
        //    Smart_Emp_ID.Text_Field = "pmp_name";
        //    Smart_Emp_ID.DataBind();
        //}
        //else
        //    Smart_Emp_ID.Clear_Controls();
    }
    protected void ddl_Related_Type_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Related_type_Changed();

    }



    protected void btn_Doc_Click(object sender, EventArgs e)
    {

        //SqlCommand cmd = new SqlCommand();
        //SqlConnection con = new SqlConnection();
        //SqlCommand cmd_local = new SqlCommand();
        //SqlConnection con_local = new SqlConnection();
        //con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        //con_local = new SqlConnection(Session_CS.local_connectionstring);
        int out_box = 0;

        if (CDataConverter.ConvertToInt(hidden_Id.Value) > 0)
        {
            if (FileUpload1.HasFile)
            {
                string DocName = FileUpload1.FileName;
                int dotindex = DocName.LastIndexOf(".");
                string type = DocName.Substring(dotindex, DocName.Length - dotindex);

                Stream myStream;
                int fileLen;
                StringBuilder displayString = new StringBuilder();
                fileLen = FileUpload1.PostedFile.ContentLength;
                Byte[] Input = new Byte[fileLen];
                myStream = FileUpload1.FileContent;
                myStream.Read(Input, 0, fileLen);

                //cmd.Parameters.Add("@File_data", SqlDbType.VarBinary);
                //cmd.Parameters.Add("@Commission_File_ID", SqlDbType.Int);
                //cmd.Parameters.Add("@Original_Or_Attached", SqlDbType.Int);
                //cmd.Parameters.Add("@File_name", SqlDbType.NVarChar);
                //cmd.Parameters.Add("@File_ext", SqlDbType.NVarChar);
                //cmd.Parameters.Add("@Inbox_Or_Outbox", SqlDbType.Int);
                //cmd.Parameters.Add("@Commission_ID", SqlDbType.Int);
                //cmd.Parameters["@Commission_File_ID"].Value = CDataConverter.ConvertToInt(hidden_Inbox_OutBox_File_ID.Value);
                //cmd.Parameters["@Original_Or_Attached"].Value = CDataConverter.ConvertToInt(ddl_Original_Or_Attached.SelectedValue);
                //cmd.Parameters["@File_ext"].Value = type;
                //cmd.Parameters["@File_name"].Value = txtFileName.Text;
                //cmd.Parameters["@Inbox_Or_Outbox"].Value = 1;


                if (CDataConverter.ConvertToInt(hidden_Inbox_OutBox_File_ID.Value) > 0)
                {
                    int xx =CDataConverter.ConvertToInt(hidden_Inbox_OutBox_File_ID.Value);

                    Commission_Files  commFile = pmentity.Commission_Files.Where(x => x.Commission_File_ID ==xx ).SingleOrDefault();

                    commFile.Original_Or_Attached = CDataConverter.ConvertToInt(ddl_Original_Or_Attached.SelectedValue);
                    commFile.File_ext = type;
                    commFile.File_name = txtFileName.Text;
                    commFile.Inbox_Or_Outbox = 1;
                    commFile.File_data = Input;

                  //con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                  //  cmd.Connection = con;
                  //  cmd.CommandType = CommandType.Text;
                  //  //cmd.CommandText = "Commission_Files_Save";

                  //  cmd.CommandText = " update Commission_Files set Original_Or_Attached=@Original_Or_Attached ,File_data=@File_data ,File_name=@File_name,File_ext=@File_ext where Commission_File_ID =@Commission_File_ID";

                  //  if (string.IsNullOrEmpty(Session_CS.local_connectionstring))
                  //  {
                  //      cmd.Connection = con;
                  //      cmd.Parameters["@File_data"].Value = Input;
                  //      con.Open();
                  //      cmd.ExecuteScalar();
                  //      con.Close();

                  //  }
                  //  else
                  //  {

                  //      cmd.Connection = con;
                  //      cmd.Parameters["@File_data"].Value = DBNull.Value;
                  //      con.Open();
                  //      cmd.ExecuteScalar();
                  //      con.Close();
                  //      try
                  //      {
                  //          cmd.Connection = con_local;
                  //          cmd.Parameters["@File_data"].Value = Input;

                  //          con_local.Open();
                  //          cmd.ExecuteScalar();
                  //          con_local.Close();


                  //      }
                  //      catch
                  //      {
                  //          // can't connect to sql local, we should show message here
                  //          ShowAlertMessage(" عفوا لم يتم الإتصال بقاعدة البيانات الداخلية");

                  //          ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('عفوا لم يتم الإتصال بقاعدة البيانات الداخلية');", true);

                  //      }
                  //  }
                    

                    txtFileName.Text =
                    hidden_Inbox_OutBox_File_ID.Value = "";
                    InsertOrUpdate_Commission_files(commFile);
                }
                else
                {

                    Commission_Files comFile = new Commission_Files();
                   
                       comFile.Commission_ID  = CDataConverter.ConvertToInt(hidden_Id.Value);
                       comFile.Original_Or_Attached  = CDataConverter.ConvertToInt(ddl_Original_Or_Attached.SelectedValue);
                       comFile. File_ext = type;
                       comFile.File_name = txtFileName.Text;
                       comFile.Inbox_Or_Outbox = 1;
                       comFile. File_data = Input;
                    

                    InsertOrUpdate_Commission_files(comFile);



                    //cmd.CommandText = " insert into Commission_Files ( Commission_ID, Inbox_Or_Outbox, Original_Or_Attached, File_data, File_name, File_ext) VALUES ( @Commission_ID, @Inbox_Or_Outbox, @Original_Or_Attached, @File_data, @File_name, @File_ext) select @@identity";

                    //if (string.IsNullOrEmpty(Session_CS.local_connectionstring))
                    //{
                    //    cmd.Connection = con;
                    //    cmd.Parameters["@File_data"].Value = Input;
                    //    cmd.Parameters["@Commission_ID"].Value = CDataConverter.ConvertToInt(hidden_Id.Value);
                    //    con.Open();
                    //    cmd.ExecuteScalar();
                    //    con.Close();

                    //}
                    //else
                    //{

                    //    cmd.Connection = con;
                    //    cmd.Parameters["@File_data"].Value = DBNull.Value;
                    //    cmd.Parameters["@Commission_ID"].Value = CDataConverter.ConvertToInt(hidden_Id.Value);
                    //    con.Open();
                    //    out_box = CDataConverter.ConvertToInt(cmd.ExecuteScalar());
                    //    con.Close();
                    //    try
                    //    {
                    //        cmd.CommandText = " insert into Commission_Files ( Commission_File_ID,Commission_ID, Inbox_Or_Outbox, Original_Or_Attached, File_data, File_name, File_ext) VALUES ( @Commission_File_ID,@Commission_ID, @Inbox_Or_Outbox, @Original_Or_Attached, @File_data, @File_name, @File_ext) select @@identity";
                    //        cmd.Connection = con_local;
                    //        cmd.Parameters["@File_data"].Value = Input;
                    //        cmd.Parameters["@Commission_File_ID"].Value = out_box;
                    //        con_local.Open();
                    //        cmd.ExecuteScalar();
                    //        con_local.Close();


                    //    }
                    //    catch
                    //    {
                    //        // can't connect to sql local, we should show message here
                    //        //ShowAlertMessage(" عفوا لم يتم الإتصال بقاعدة البيانات الداخلية");
                    //        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('عفوا لم يتم الإتصال بقاعدة البيانات الداخلية');", true);

                    //    }
                    //}

                    txtFileName.Text =
                    hidden_Inbox_OutBox_File_ID.Value = "";

                }



                Fil_Grid_Documents();

            }

           
        }
        else
        {
           // Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('يجب إدخال بيانات الخطاب أولا')</script>");

            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('يجب إدخال بيانات الخطاب أولا');", true);


        }

    }

    protected void GrdView_Documents_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditItem")
        {
            int com_file_id = CDataConverter.ConvertToInt(e.CommandArgument);
            
          //  Commission_Files_DT obj = Commission_Files_DB.SelectByID(CDataConverter.ConvertToInt(e.CommandArgument));

            Commission_Files obj = pmentity.Commission_Files.Where(x=> x.Commission_File_ID == com_file_id).SingleOrDefault();

            if (obj.Commission_File_ID > 0)
            {
                hidden_Inbox_OutBox_File_ID.Value = obj.Commission_File_ID.ToString();
                txtFileName.Text = obj.File_name;
                ddl_Original_Or_Attached.SelectedValue = obj.Original_Or_Attached.ToString();
            }

        }

        if (e.CommandName == "RemoveItem")
        {
           
            
            //Commission_Files_DB.Delete(CDataConverter.ConvertToInt(e.CommandArgument));

            int com_file_id = CDataConverter.ConvertToInt(e.CommandArgument);

            //Commission_Files comm = new Commission_Files()
            //{
            //    Commission_File_ID=com_file_id
            //};
            //pmentity.Commission_Files.Attach(comm);
            //pmentity.Commission_Files.Remove(comm);
            pmentity.Commission_Files.RemoveRange(pmentity.Commission_Files.Where(x => x.Commission_File_ID==com_file_id));
            pmentity.SaveChanges();




            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('لقد تم الحذف بنجاح');", true);

            Fil_Grid_Documents();
        }
    }

    private void Fil_Grid_Documents()
    {
        DataTable DT = new DataTable();
      //  DT = General_Helping.GetDataTable("select * from Commission_Files where Inbox_Or_Outbox = 1 and Commission_ID=" + hidden_Id.Value);

        int xx = CDataConverter.ConvertToInt(hidden_Id.Value);

        var query = from comm_query in pmentity.Commission_Files
                    where comm_query.Inbox_Or_Outbox == 1  &&  comm_query.Commission_ID == xx
                    select comm_query;

        DT = query.ToDataTable();
        GrdView_Documents.DataSource = DT;
        GrdView_Documents.DataBind();
    }

    public void InsertOrUpdate( Commission blog)
    {
       

        using (var context = new Projects_ManagementEntities10())
        {
            
            context.Entry(blog).State = blog.ID == 0 ?
                                      System.Data.Entity.EntityState.Added :
                                      System.Data.Entity.EntityState.Modified;

            context.SaveChanges();
        }
    }

    public void InsertOrUpdate_Commission_Visa_follows(Commission_Visa_Follows blog)
    {


        using (var context = new Projects_ManagementEntities10())
        {
            context.Entry(blog).State = blog.Follow_ID == 0 ?
                                       System.Data.Entity.EntityState.Added :
                                        System.Data.Entity.EntityState.Modified;

            context.SaveChanges();
        }
    }

    public void InsertOrUpdate_Commission_Visa_Emp(Commission_Visa_Emp blog)
    {


        using (var context = new Projects_ManagementEntities10())
        {
            context.Entry(blog).State = blog.Visa_Emp_ID == 0 ?
                                       System.Data.Entity.EntityState.Added :
                                        System.Data.Entity.EntityState.Modified;

            context.SaveChanges();
        }
    }
    public void InsertOrUpdate_Commission_Visa(Commission_Visa blog)
    {


        using (var context = new Projects_ManagementEntities10())
        {
            context.Entry(blog).State = blog.Visa_Id == 0 ?
                                      System.Data.Entity.EntityState.Added :
                                      System.Data.Entity.EntityState.Modified;
           
            context.SaveChanges();
            
        }
    }

    public void InsertOrUpdate_Commission_files(Commission_Files blog)
    {


        using (var context = new Projects_ManagementEntities10())
        {
            context.Entry(blog).State = blog.Commission_File_ID == 0 ?
                                      System.Data.Entity.EntityState.Added :
                                      System.Data.Entity.EntityState.Modified;

            context.SaveChanges();

        }
    }



    protected void btn_Visa_Click(object sender, EventArgs e)
    {

        if (lst_emp.Items.Count > 0)
        {
            string datenow = "";
            int dept = 0;
            int pmp = 0;
            int group = 0;

         //   Commission_DT obj = new Commission_DT();

            Commission obj = new Commission();

            obj.ID = CDataConverter.ConvertToInt(hidden_Id.Value);

            obj.Date = txt_Visa_date.Text;
            if (obj.ID == 0)
            {
                //datenow = DateTime.Now.ToString();
                datenow = CDataConverter.ConvertDateTimeNowRtrnString();
                obj.Enter_Date = datenow;
                dept = int.Parse(Session_CS.dept_id.ToString());
                pmp = int.Parse(Session_CS.pmp_id.ToString());
                group = int.Parse(Session_CS.group_id.ToString());
                obj.Dept_Dept_ID = dept;
                obj.pmp_pmp_id = pmp;
                obj.Group_id = group;

            }
            else
            {
                //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                //con.Open();
                //string sql = "select Enter_Date,Dept_Dept_id,Group_id,pmp_pmp_id from Commission where ID = " + obj.ID;
                //SqlDataAdapter da = new SqlDataAdapter(sql, con);
                //DataSet ds = new DataSet();
                //da.Fill(ds);

                //datenow = ds.Tables[0].Rows[0]["Enter_Date"].ToString();
                //dept = int.Parse(ds.Tables[0].Rows[0]["Dept_Dept_id"].ToString());
                //group = int.Parse(ds.Tables[0].Rows[0]["Group_id"].ToString());
                //pmp = int.Parse(ds.Tables[0].Rows[0]["pmp_pmp_id"].ToString());

                Commission comm = pmentity.Commission.Where( x => x.ID==obj.ID ).SingleOrDefault();
                datenow = comm.Enter_Date.ToString();
                dept = CDataConverter.ConvertToInt( comm.Dept_Dept_ID.ToString());
                group = CDataConverter.ConvertToInt(comm.Group_id);
                pmp = CDataConverter.ConvertToInt(comm.pmp_pmp_id);

                obj.Enter_Date = datenow;
                obj.Dept_Dept_ID = dept;
                obj.Group_id = group;
                obj.pmp_pmp_id = pmp;
            }


            obj.Subject = txt_Subject.Text;
            obj.finished = 0;
            obj.Notes = txt_Notes.Text;
            obj.Resp_emp_close = CDataConverter.ConvertToInt(drop_Resp_close_emp.SelectedValue);
            obj.foundation_id = CDataConverter.ConvertToInt(Session_CS.foundation_id.ToString());

           // obj.ID = Commission_DB.Save(obj);

            InsertOrUpdate(obj);

            hidden_Id.Value = obj.ID.ToString();

            ///////////////  to store that mohammed eid send to dr hesham the mail

          //Commission_Visa_Follows_DT obj_follow = Commission_Visa_Follows_DB.SelectByID(CDataConverter.ConvertToInt(hidden_Follow_ID.Value));

            int f_id=CDataConverter.ConvertToInt(hidden_Follow_ID.Value);

            Commission_Visa_Follows obj_follow = new Commission_Visa_Follows();

         //  Commission_Visa_Follows obj_follow = pmentity.Commission_Visa_Follows.SingleOrDefault(y => y.Follow_ID == f_id);


            //IQueryable<Commission_Visa_Follows> obj_follow2 = from comm in pmentity.Commission_Visa_Follows
            //                                                  where comm.Follow_ID == f_id
            //                                                  select comm;
       
        

          
               obj_follow.Follow_ID = f_id;
               obj_follow.Commission_ID = CDataConverter.ConvertToInt(hidden_Id.Value);

               obj_follow.Descrption = "تم حفظ التكليف";
               //string date = DateTime.Now.ToShortDateString().ToString();
               string date = CDataConverter.ConvertDateTimeNowRtrnString();
               obj_follow.Date = date;
               //obj_follow.time_follow = DateTime.UtcNow.ToLocalTime().ToLongTimeString();
               obj_follow.time_follow = CDataConverter.ConvertDateTimeNowRtnDt().ToLongTimeString();
               obj_follow.entery_pmp_id = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
               obj_follow.Visa_Emp_id = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());

             InsertOrUpdate_Commission_Visa_follows(obj_follow);

             //  obj_follow.Follow_ID = Commission_Visa_Follows_DB.Save(obj_follow);
               Fil_Grid_Visa_Follow();

          



         //  Commission_Visa_DT obj_visa = new Commission_Visa_DT();

           Commission_Visa obj_visa = new Commission_Visa();

            obj_visa.Visa_Id = CDataConverter.ConvertToInt(hidden_Visa_Id.Value);
            obj_visa.Commission_ID = CDataConverter.ConvertToInt(hidden_Id.Value);

            obj_visa.Visa_date = txt_Visa_date.Text;
            obj_visa.Important_Degree = CDataConverter.ConvertToInt(ddl_Important_Degree.SelectedValue);
            obj_visa.Important_Degree_Txt = txt_Important_Degree_Txt.Text;
            if (string.IsNullOrEmpty(obj_visa.Important_Degree_Txt))
                obj_visa.Important_Degree_Txt = ddl_Important_Degree.SelectedItem.Text;

            obj_visa.Dept_ID = CDataConverter.ConvertToInt(Smart_Search_dept.SelectedValue);
            obj_visa.Dept_ID_Txt = txt_Dept_ID_Txt.Text;
            if (string.IsNullOrEmpty(obj_visa.Dept_ID_Txt))
                obj_visa.Dept_ID_Txt = Smart_Search_dept.SelectedText;

            obj_visa.Emp_ID = 0;
            obj_visa.Emp_ID_Txt = txt_Emp_ID_Txt.Text;
            //if (string.IsNullOrEmpty(obj.Emp_ID_Txt))
            //    obj.Emp_ID_Txt = Smart_Visa_Emp.SelectedText;

            obj_visa.Visa_Desc = txt_Visa_Desc.Text;
            //obj_visa.Visa_Period = txt_Visa_Period.Text;
            // obj_visa.Visa_Satus = CDataConverter.ConvertToInt(ddl_Visa_Satus.SelectedValue);
            //obj.Follow_Up_Dept_ID = CDataConverter.ConvertToInt(ddl_Follow_Up_Dept_ID.SelectedValue);
            //obj.Follow_Up_Emp_ID = CDataConverter.ConvertToInt(Smart_Follow_Up_Emp_ID.SelectedValue);
            //obj.Follow_Up_Notes = txt_Follow_Up_Notes.Text;
            // obj.saving_file = txt_saving_file.Text;
            obj_visa.Dead_Line_DT = txt_Dead_Line_DT.Text;
            obj_visa.Visa_Goal_ID = CDataConverter.ConvertToInt(ddl_Visa_Goal_ID.SelectedValue);
            obj_visa.mail_sent = 0;


         //   obj_visa.Visa_Id = Commission_Visa_DB.Save(obj_visa);

            InsertOrUpdate_Commission_Visa(obj_visa);


            hidden_Visa_Id.Value = obj_visa.Visa_Id.ToString();

            string exist_vac = "", notexixt_vac = "";
            string exist_err = "", notexixt_err = "";
            string exist_dayoff = "", notexixt_dayoff = "";
            foreach (ListItem item in lst_emp.Items)
            {

                DataTable Dt_Vac_Valid = Vacations_DB.Check_DT_Valid(txt_Visa_date.Text, txt_Visa_date.Text, CDataConverter.ConvertToInt(item.Value));
                if (Dt_Vac_Valid.Rows.Count > 0)
                {
                    exist_vac += item.Text + ",";

                }
                else
                {
                    notexixt_vac += item.Text + ",";
                }
                DataTable Dt_errnd_Valid = Vacations_errand_DB.Check_DT_Valid(txt_Visa_date.Text, txt_Visa_date.Text, CDataConverter.ConvertToInt(item.Value));
                if (Dt_errnd_Valid.Rows.Count > 0)
                {
                    exist_err += item.Text + ",";
                }
                DataTable Dt_Vac_Valid2 = Vacations_Dayoff_DB.Check_DT_Valid(txt_Visa_date.Text, txt_Visa_date.Text, CDataConverter.ConvertToInt(item.Value));
                if (Dt_Vac_Valid2.Rows.Count > 0)
                {
                    exist_dayoff += item.Text + ",";
                }

            }

            Save_inox_Visa(obj_visa);

            Clear_Visa_Cntrl();
            // Fil_Grid_Visa();
            fil_emp_Folow_Up();
            Fil_Emp_Visa_Follow();
            ///////////////////////// update have visa = 1/////////////////////////////////////////////

            Update_Have_Visa_all_emp(CDataConverter.ConvertToInt (obj_visa.Commission_ID));

            string message_vac = Show_Alert_vac(exist_vac, notexixt_vac);
            string messsage_err = Show_Alert_err(exist_err, notexixt_err);
            string messsage_dayoff = Show_Alert_dayoff(exist_dayoff, notexixt_dayoff);
           // Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('  تم الحفظ بنجاح" + message_vac + "" + messsage_err + "" + messsage_dayoff + "  ')</script>");

            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('  تم الحفظ بنجاح" + message_vac + "" + messsage_err + "" + messsage_dayoff + "  ');", true);

            // Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('"+message+"')</script>");

        }
        else
        {
           // Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لا يوجد أسماء في القائمة اليسري')</script>");

            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('لا يوجد أسماء في القائمة اليسري');", true);

        }





    }
    private string Show_Alert_vac(string exist_vac, string notexixt_vac)
    {
        string message = "";

        if (!string.IsNullOrEmpty(exist_vac))
        {

            message += " يوجد اجازة في نفس التاريخ ل " + exist_vac;
        }

        return message;




    }
    private string Show_Alert_err(string exist_vac, string notexixt_vac)
    {
        string message = "";

        if (!string.IsNullOrEmpty(exist_vac))
        {

            message += " يوجد مامورية في نفس التاريخ ل " + exist_vac;
        }

        return message;




    }
    private string Show_Alert_dayoff(string exist_vac, string notexixt_vac)
    {
        string message = "";

        if (!string.IsNullOrEmpty(exist_vac))
        {

            message += " يوجد طلب راحة في نفس التاريخ ل " + exist_vac;
        }

        return message;




    }
    public void fill_listbox()
    {
        drop_Resp_close_emp.Items.Clear();
        ListItem obj = new ListItem();
        foreach (ListItem item in chklst_Visa_Emp_All.Items)
        {
            if (item.Selected && lst_emp.Items.FindByValue(item.Value) == null)
            {
                obj = new ListItem(item.Text, item.Value);
                lst_emp.Items.Add(obj);
                //drop_Resp_close_emp.Items.Add(obj);
                item.Selected = false;
            }


        }
        foreach (ListItem item in lst_emp.Items)
        {
            obj = new ListItem(item.Text, item.Value);
            drop_Resp_close_emp.Items.Add(obj);
        }
        drop_Resp_close_emp.Items.Insert(0, new ListItem(" اختر الموظف المسئول عن اغلاق التكليف ......", "0"));



        //drop_Resp_close_emp.Items.Insert(0, new ListItem(" اختر الموظف المسئول عن اغلاق التكليف ......", "0"));
    }
    protected void btn_add_Click(object sender, EventArgs e)
    {

        fill_listbox();
        TabPanel_All.ActiveTab = TabPanel_Visa;
    }
    protected void btn_delete_Click(object sender, EventArgs e)
    {
        drop_Resp_close_emp.Items.Clear();
        if (lst_emp.SelectedValue == "")
        {
           // Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('يجب اختيار موظف ليتم الحذف')</script>");

            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('يجب اختيار موظف ليتم الحذف');", true);

        }
        else
        {
            lst_emp.Items.Remove(lst_emp.SelectedItem);
            drop_Resp_close_emp.Items.Remove(lst_emp.SelectedItem);
            ListItem obj = new ListItem();
            foreach (ListItem item in lst_emp.Items)
            {
                obj = new ListItem(item.Text, item.Value);
                drop_Resp_close_emp.Items.Add(obj);
            }
            drop_Resp_close_emp.Items.Insert(0, new ListItem(" اختر الموظف المسئول عن اغلاق التكليف ......", "0"));
            //foreach (ListItem item  in lst_emp.Items)
            //{

            //    ListItem item2 = chklst_Visa_Emp_All.Items.FindByValue(item.Value);
            //    if (item2 != null)
            //        item2.Selected = true;
            //    else item2.Selected = false;
            //}

        }
        TabPanel_All.ActiveTab = TabPanel_Visa;

    }
    private void Update_Have_Visa_all_emp(int Commission_id)
    {


        // string sql_all_User = "update Commission_Track_Emp set commission_Status =2 where Commission_id=" + Commission_id;
        //  General_Helping.ExcuteQuery(sql_all_User);
    //    Commission_Track_Emp_DB.Commission_Track_Emp_update(Commission_id);

        using (var db = new Projects_ManagementEntities10())
        {

            IQueryable<Commission_Track_Emp> comm_trackk = db.Commission_Track_Emp.Where(x => x.Commission_id == Commission_id);

            foreach (Commission_Track_Emp comm_tra in comm_trackk)
            {
                comm_tra.Commission_Status = 2;
            }
            db.SaveChanges();
        }


    }


    public  void ShowAlertMessage(string error)
    {

        Page page = HttpContext.Current.Handler as Page;
        if (page != null)
        {
            error = error.Replace("'", "\'");
         //   ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('" + error + "');", true);

            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('"+error+"');", true);

        }
    }
    protected void btn_Visa_Follow_Click(object sender, EventArgs e)
    {
        if (CDataConverter.ConvertToDate(txt_Follow_Date.Text) >= CDataConverter.ConvertToDate (txt_Visa_date.Text))
        {
            if (CDataConverter.ConvertToInt(hidden_Id.Value) > 0)
            {
               // Commission_Visa_Follows_DT obj = Commission_Visa_Follows_DB.SelectByID(CDataConverter.ConvertToInt(hidden_Follow_ID.Value));

                Commission_Visa_Follows obj = new Commission_Visa_Follows();

                obj.Follow_ID = CDataConverter.ConvertToInt(hidden_Follow_ID.Value);
                obj.Commission_ID = CDataConverter.ConvertToInt(hidden_Id.Value);
                obj.Descrption = txt_Descrption.Text;
                obj.Date = txt_Follow_Date.Text;
                //obj.time_follow = DateTime.UtcNow.ToLocalTime().ToLongTimeString();
                obj.time_follow = CDataConverter.ConvertDateTimeNowRtnDt().ToLongTimeString();

                obj.entery_pmp_id = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
                obj.Visa_Emp_id = CDataConverter.ConvertToInt(ddl_Visa_Emp_id.SelectedValue);
                obj.Type_Follow = 1;

              //  obj.Follow_ID = Commission_Visa_Follows_DB.Save(obj);

               

                if (FileUpload_Visa_Follow.HasFile)
                {
                    string DocName = FileUpload_Visa_Follow.FileName;
                    int dotindex = DocName.LastIndexOf(".");
                    string type = DocName.Substring(dotindex, DocName.Length - dotindex);

                    Stream myStream;
                    int fileLen;
                    StringBuilder displayString = new StringBuilder();
                    fileLen = FileUpload_Visa_Follow.PostedFile.ContentLength;
                    Byte[] Input = new Byte[fileLen];
                    myStream = FileUpload_Visa_Follow.FileContent;
                    myStream.Read(Input, 0, fileLen);

                   // SqlCommand cmd = new SqlCommand();
                   // SqlConnection con = new SqlConnection();
                   // SqlCommand cmd_local = new SqlCommand();
                   // SqlConnection con_local = new SqlConnection();
                   // con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                   // con_local = new SqlConnection(Session_CS.local_connectionstring);
                   // cmd.Parameters.Add("@File_data", SqlDbType.VarBinary);
                   // cmd.Parameters.Add("@File_name", SqlDbType.NVarChar);
                   // cmd.Parameters.Add("@File_ext", SqlDbType.NVarChar);
                   // cmd.Parameters.Add("@Follow_ID", SqlDbType.BigInt);

                   //// cmd.Parameters["@File_data"].Value = Input;
                   // cmd.Parameters["@File_name"].Value = DocName;
                   // cmd.Parameters["@File_ext"].Value = type;
                   // cmd.Parameters["@Follow_ID"].Value = obj.Follow_ID;

                   
                    obj.File_name = DocName;
                    obj.File_ext = type;
                    obj.Follow_ID = obj.Follow_ID;
                    obj.File_data = Input;

                   // cmd.CommandType = CommandType.Text;
                  //  cmd.CommandText = " update Commission_Visa_Follows set File_data =@File_data ,File_name=@File_name,File_ext=@File_ext where Follow_ID =@Follow_ID";
                    //if (string.IsNullOrEmpty(Session_CS.local_connectionstring))
                    //{
                    //    cmd.Connection = con;
                    //    cmd.Parameters["@File_data"].Value = Input;
                    //    con.Open();
                    //    cmd.ExecuteScalar();
                    //    con.Close();

                    //}
                    //else
                    //{

                    //    cmd.Connection = con;
                    //    cmd.Parameters["@File_data"].Value = DBNull.Value;
                    //    con.Open();
                    //    cmd.ExecuteScalar();
                    //    con.Close();
                    //    try
                    //    {
                    //        cmd.Connection = con_local;
                    //        cmd.Parameters["@File_data"].Value = Input;

                    //        con_local.Open();
                    //        cmd.ExecuteScalar();
                    //        con_local.Close();


                    //    }
                    //    catch
                    //    {
                    //        // can't connect to sql local, we should show message here

                    //     //   ShowAlertMessage("   عفوا لم يتم الإتصال بقاعدة البيانات الداخلية");


                    //        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('عفوا لم يتم الإتصال بقاعدة البيانات الداخلية');", true);

                    //    }
                    //}


                  //  InsertOrUpdate_Commission_Visa_follows(com);

                    InsertOrUpdate_Commission_Visa_follows(obj);

                    Fil_Grid_Visa_Follow();
                }


                Clear_visa_Follow();

            
            }
            else
            {
                Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('يجب إدخال بيانات الخطاب أولا')</script>");

                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('يجب إدخال بيانات الخطاب أولا');", true);


            }
        }
        else
        {

            //Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('تاريخ المتابعة يجب أن يكون أكبر من أو يساوي تاريخ الخطاب')</script>");
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('تاريخ المتابعة يجب أن يكون أكبر من أو يساوي تاريخ الخطاب');", true);


        }

    }
    protected void btn_print_report_Click(object sender, EventArgs e)
    {
        string user = Session_CS.pmp_name.ToString();
        int found_id = CDataConverter.ConvertToInt(Session_CS.foundation_id.ToString());
        if (Request.QueryString["id"] != null)
        {
            ReportDocument rd = new ReportDocument();
            string s = Server.MapPath("../Reports/InboxOutboxReport/Commission_Data.rpt");
            rd.Load(s);
            Reports.Load_Report(rd);
            rd.SetParameterValue("@Com_ID", CDataConverter.ConvertToInt(hidden_Id.Value));
            rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
            rd.SetParameterValue("@user", user, "footerRep.rpt");
            rd.SetParameterValue("@found_id", found_id, "Logo_Header_pic_dynamic.rpt");
            if (rd.Rows.Count == 0)
            {
                ShowAlertMessage("!!!!!هذا التقرير لا يوجد به بيانات للعرض !!!!");
                return;
            }
            else
            {
                rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report");
            }
        }

    }
    private void Fil_Grid_Visa_Follow()
    {
        DataTable DT = new DataTable();
        //string Sql = "SELECT Commission_Visa_Follows.Follow_ID,Commission_Visa_Follows.File_name,Commission_Visa_Follows.time_follow,Commission_Visa_Follows.Commission_ID, Commission_Visa_Follows.Descrption, Commission_Visa_Follows.Date, Commission_Visa_Follows.Visa_Emp_id, EMPLOYEE.pmp_name " +
        //             " FROM   Commission_Visa_Follows INNER JOIN EMPLOYEE ON Commission_Visa_Follows.Visa_Emp_id = EMPLOYEE.PMP_ID where Commission_ID =" + hidden_Id.Value;

      
      //  DT = General_Helping.GetDataTable(Sql);

        int co_id = CDataConverter.ConvertToInt( hidden_Id.Value);

        DT = pmentity.get_Visa_Follow(co_id).ToDataTable();

        GridView_Visa_Follow.DataSource = DT;
        GridView_Visa_Follow.DataBind();
    }

    private void Clear_visa_Follow()
    {
        hidden_Follow_ID.Value =
        txt_Descrption.Text =
        txt_Follow_Date.Text = "";
        ddl_Visa_Emp_id.SelectedIndex = 0;
    }


    private void Save_inox_Visa(Commission_Visa obj)
    {

        //string Sql_Delete = "delete from Commission_Visa_Emp where Visa_Id =" + obj.Visa_Id;
        
        //General_Helping.ExcuteQuery(Sql_Delete);
      //  string Sql_insert = "";

       pmentity.Commission_Visa_Emp.RemoveRange(pmentity.Commission_Visa_Emp.Where(x => x.Visa_Id == obj.Visa_Id));
       pmentity.SaveChanges();

        //Commission_Visa_Emp foun = new Commission_Visa_Emp()
        //{
        //    Visa_Id  = obj.Visa_Id
        //};

        //pmentity.Commission_Visa_Emp.Attach(foun);
        //pmentity.Commission_Visa_Emp.Remove(foun);
        //pmentity.SaveChanges();

     

        foreach (ListItem item in lst_emp.Items)
        {
           // Commission_Visa_Emp_DT obj_commvisa = new Commission_Visa_Emp_DT();

            Commission_Visa_Emp obj_commvisa = new Commission_Visa_Emp();

            obj_commvisa.Visa_Id = obj.Visa_Id;
            obj_commvisa.Emp_ID = CDataConverter.ConvertToInt(item.Value);


         //  DataTable dt = General_Helping.GetDataTable("select * from parent_employee where pmp_id = " + CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()));

            DataTable dt = new DataTable();
            int pmpid = CDataConverter.ConvertToInt(Session_CS.pmp_id);
            var query = from emp_tble in outboxDBContext.EMPLOYEEs where emp_tble.PMP_ID == pmpid select emp_tble;
            dt = query.ToDataTable();

           

            if (dt.Rows.Count > 0)
            {

                //  Sql_insert = "insert into Commission_Visa_Emp ( Visa_Id , Emp_ID ,Sender_id) values ( " + obj.Visa_Id + "," + item.Value + "," + CDataConverter.ConvertToInt(dt.Rows[0]["parent_pmp_id"].ToString()) + ")";

                obj_commvisa.Sender_ID = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());

            }
            else
            {

                // Sql_insert = "insert into Commission_Visa_Emp ( Visa_Id , Emp_ID ,Sender_id) values ( " + obj.Visa_Id + "," + item.Value + "," + CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()) + ")";

                obj_commvisa.Sender_ID = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
            }

         //   Commission_Visa_Emp_DB.Save(obj_commvisa);

            InsertOrUpdate_Commission_Visa_Emp(obj_commvisa);

            




        }

        //Commission_Visa_Emp_DT comm_visa_obj = new Commission_Visa_Emp_DT();

        Commission_Visa_Emp comm_visa_obj = new Commission_Visa_Emp();

        comm_visa_obj.Visa_Id = obj.Visa_Id;


        /// to insert the row of parent in table commission visa emp///////////////////////
      //  DataTable dt_new = General_Helping.GetDataTable("select * from parent_employee where pmp_id = " + CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()));
        int pmp_id = CDataConverter.ConvertToInt(Session_CS.pmp_id);
        DataTable dt_new = new DataTable();

        dt_new = (from par_emp in outboxDBContext.parent_employees where par_emp.pmp_id == pmp_id select par_emp).ToDataTable(); 
        
        if (dt_new.Rows.Count > 0)
        {

            // Sql_insert = "insert into Commission_Visa_Emp ( Visa_Id , Emp_ID ,Sender_id) values ( " + obj.Visa_Id + "," + CDataConverter.ConvertToInt(dt_new.Rows[0]["parent_pmp_id"].ToString()) + "," + CDataConverter.ConvertToInt(dt_new.Rows[0]["parent_pmp_id"].ToString()) + ")";
            comm_visa_obj.Emp_ID = CDataConverter.ConvertToInt(dt_new.Rows[0]["parent_pmp_id"].ToString());
            comm_visa_obj.Sender_ID = CDataConverter.ConvertToInt(dt_new.Rows[0]["parent_pmp_id"].ToString());

        }
        else
        {

            //Sql_insert = "insert into Commission_Visa_Emp ( Visa_Id , Emp_ID ,Sender_id) values ( " + obj.Visa_Id + "," + CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()) + "," + CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()) + ")";

            comm_visa_obj.Emp_ID = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
            comm_visa_obj.Sender_ID = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
        }


        // General_Helping.ExcuteQuery(Sql_insert);

      //  Commission_Visa_Emp_DB.Save(comm_visa_obj);

        InsertOrUpdate_Commission_Visa_Emp(comm_visa_obj);


    }

    private void Clear_Visa_Cntrl()
    {
        //hidden_Visa_Id.Value = "";

        chk_ALL.Checked = false;

        //  Smart_Visa_Emp.Clear_Controls();
    }




    protected void GridView_Visa_Follow_RowCommand(object sender, GridViewCommandEventArgs e)
    {
       // string sqlformail = "SELECT parent_pmp_id from parent_employee where pmp_id =  " + int.Parse(Session_CS.pmp_id.ToString());
      //  DataTable ds = General_Helping.GetDataTable(sqlformail);
        

        int pmp_id = CDataConverter.ConvertToInt(Session_CS.pmp_id);
        DataTable ds = new DataTable();

        ds = (from par_emp in outboxDBContext.parent_employees where par_emp.pmp_id == pmp_id select par_emp).ToDataTable();
        int parent_pmp = int.Parse(ds.Rows[0]["parent_pmp_id"].ToString());

        if (e.CommandName == "EditItem")
        {

         //   Commission_Visa_Follows_DT obj = Commission_Visa_Follows_DB.SelectByID(CDataConverter.ConvertToInt(e.CommandArgument));

            int id = CDataConverter.ConvertToInt(e.CommandArgument);

            Commission_Visa_Follows obj = pmentity.Commission_Visa_Follows.Where(x => x.Follow_ID == id ).SingleOrDefault();
            if (obj.Follow_ID > 0)
            {
                hidden_Follow_ID.Value = obj.Follow_ID.ToString();
                txt_Descrption.Text = obj.Descrption;
                txt_Follow_Date.Text = obj.Date;
                if (obj.Visa_Emp_id > 0)
                {

                    ddl_Visa_Emp_id.SelectedValue = obj.Visa_Emp_id.ToString();
                }


            }
        }

        if (e.CommandName == "RemoveItem")
        {
            Commission_Visa_Follows_DB.Delete(CDataConverter.ConvertToInt(e.CommandArgument));
           // Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم الحذف بنجاح')</script>");
             int id = CDataConverter.ConvertToInt(e.CommandArgument);
            Commission_Visa_Follows obj = new Commission_Visa_Follows()
            {
                Follow_ID = id
            };

            pmentity.Commission_Visa_Follows.Attach(obj );
            pmentity.Commission_Visa_Follows.Remove(obj);
            pmentity.SaveChanges();



            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('لقد تم الحذف بنجاح');", true);

            Fil_Grid_Visa_Follow();
        }

        if (e.CommandName == "SendItem")
        {
            ////////////////////////////////////////////////////////////////////////////////////////////
            /////////////////// Sending Mail Code /////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////
            string name = "";
            string Succ_names = "";

           // DataTable dt_getmail = General_Helping.GetDataTable("select mail,pmp_name from employee where pmp_id = " + parent_pmp);

            DataTable dt_getmail = (from pmp_tbl in outboxDBContext.EMPLOYEEs where pmp_tbl.PMP_ID == parent_pmp select pmp_tbl).ToDataTable();

            string mail = dt_getmail.Rows[0]["mail"].ToString();
            string parent_name = dt_getmail.Rows[0]["pmp_name"].ToString();



            MailMessage _Message = new MailMessage();
            if (int.Parse(Session_CS.group_id.ToString()) == 3)
            {
                _Message.Subject = "COM";
            }
            else
            {
                _Message.Subject = "نظام الادارة الالكترونية - المراسلات";
            }


            //_Message.BodyEncoding = Encoding.Unicode;
            _Message.BodyEncoding = Encoding.UTF8;
            _Message.SubjectEncoding = Encoding.UTF8;

            _Message.To.Add(new MailAddress(mail));


            string address2 = System.Web.HttpContext.Current.Request.Url.Authority.ToString();
            String encrypted_id = Encryption.Encrypt(hidden_Id.Value);
           // _Message.IsBodyHtml = true;
            _Message.Body = "<html><body dir='rtl'><h3 >";

            _Message.Body += " السيد  -   ";
            _Message.Body += parent_name;
            _Message.Body += " </h3>";
            _Message.Body += " <h1 style=text-align:right>    وصلكم تكليف   </h1> ";
            _Message.Body += " <h3 > إيماءً إلى التكليف   " + " " + " بتاريخ " + txt_Visa_date.Text + " بخصوص " + txt_Subject.Text + " </h3>";

            bool flag = false;

            //string Sql = "SELECT     Commission_Visa_Follows.Follow_ID, Commission_Visa_Follows.File_data,Commission_Visa_Follows.File_name,Commission_Visa_Follows.File_ext,Commission_Visa_Follows.Commission_ID, Commission_Visa_Follows.Descrption, Commission_Visa_Follows.Date, Commission_Visa_Follows.Visa_Emp_id, EMPLOYEE.pmp_name " +
            //             " FROM         Commission_Visa_Follows INNER JOIN EMPLOYEE ON Commission_Visa_Follows.Visa_Emp_id = EMPLOYEE.PMP_ID where Commission_ID =" + hidden_Id.Value;

            DataTable dt = pmentity.get_comm_infor_formail(CDataConverter.ConvertToInt(hidden_Id.Value)).ToDataTable();

            string file = "";

            byte[] files = new byte[0];
            MemoryStream ms = new MemoryStream();
           // DataTable dt = General_Helping.GetDataTable(Sql);
            foreach (DataRow dr in dt.Rows)
            {

                if (dr["File_data"] != DBNull.Value)
                {

                     file = dr["File_name"].ToString() + dr["File_ext"].ToString();
                     files = (byte[])dr["File_data"];
                     ms = new MemoryStream(files);
                    _Message.Attachments.Add(new Attachment(ms, file));
                    flag = true;

                }
                if (CDataConverter.ConvertToInt(dr["Follow_ID"].ToString()) == CDataConverter.ConvertToInt(e.CommandArgument.ToString()))
                {
                    _Message.Body += " <h3 > فقد أفاد السيد  " + dr["pmp_name"].ToString() + "  فى تاريخ " + dr["Date"].ToString() + " بالتالى  </h3>";
                    _Message.Body += " <h3 > " + dr["Descrption"].ToString() + "  </h3>";
                }
            }


            if (flag)
                _Message.Body += "<h3 >   ومرفق الوثائق الخاصة بهذا التكليف</h3> <br /><br />";


            _Message.Body += "<h3 > مع تحيات </h3> ";
            _Message.Body += "<h3 >   " + Session_CS.e_signature.ToString() + "  </h3> ";
            _Message.Body += "</body></html>";
       
            try
            {
                SendingMailthread_class.Sendingmail(_Message,_Message.Subject, _Message.Body, mail, ms, file, encrypted_id, "");

                Succ_names += name + ",";

            }
            catch (Exception ex)
            {
               // Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لم يتم ارسال الايميل للسيد المدير المختص بنجاح')</script>");

                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('لم يتم ارسال الايميل للسيد المدير المختص بنجاح');", true);


            }
           // Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم ارسال الايميل للسيد المدير المختص بنجاح')</script>");

            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('لقد تم ارسال الايميل للسيد المدير المختص بنجاح');", true);

        }


    }



    protected void GridView_Visa_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "EditItem")
        {
            Fil_Visa_Control(CDataConverter.ConvertToInt(e.CommandArgument));
            Fil_Visa_Lst(CDataConverter.ConvertToInt(e.CommandArgument));
            Fil_Visa_Lstbox(CDataConverter.ConvertToInt(e.CommandArgument));

        }

        if (e.CommandName == "RemoveItem")
        {
           // Commission_Visa_DB.Delete(CDataConverter.ConvertToInt(e.CommandArgument));

            int v_id = CDataConverter.ConvertToInt(e.CommandArgument );
            Commission_Visa obj = new Commission_Visa()
            {
                      Visa_Id = v_id

            };

            pmentity.Commission_Visa.Attach(obj);
            pmentity.Commission_Visa.Remove(obj);
            pmentity.SaveChanges();

            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('لقد تم الحذف بنجاح');", true);

  
            Fil_Emp_Visa_Follow();
        }

        if (e.CommandName == "SendItem")
        {
        }


    }

    private void Update_Have_Visa(string Visa_Id)
    {
        //string Sql_Visa_Sent = "select Visa_Id from Commission_Visa where mail_sent = 1 and Visa_Id !=" + Visa_Id + " and Commission_id = " + hidden_Id.Value;

        int hid_id = CDataConverter.ConvertToInt(hidden_Id.Value);
        int v_id =CDataConverter.ConvertToInt(Visa_Id);
        var query = from com_tble in pmentity.Commission_Visa where com_tble.mail_sent == 1 && com_tble.Visa_Id == v_id && com_tble.Commission_ID == hid_id  select com_tble;
        DataTable dt = query.ToDataTable();


       // int Visa_Sent_Count = General_Helping.GetDataTable(Sql_Visa_Sent).Rows.Count;
        int Visa_Sent_Count = dt.Rows.Count;

        if (Visa_Sent_Count == GridView_Visa.Rows.Count - 1)
        {
            //DataTable DT = General_Helping.GetDataTable("select * from Inbox_Track_Manager where inbox_id = " + hidden_Id.Value);
            //if (DT.Rows.Count > 0)
            //{
            string sql = "update Inbox_Track_Manager set Have_visa=0 , All_visa_sent=1 where Commission_id =" + hidden_Id.Value;
            General_Helping.ExcuteQuery(sql);
            //}

        }

    }

    private string Show_Alert(string Succ_names, string Failed_name, string visa_id)
    {
        string message = "";
        int flag = 0;
        if (!string.IsNullOrEmpty(Succ_names))
        {
            flag = 1;
            message += " لقد تم ارسال الايميل بنجاح إلي " + Succ_names;
        }
        if (!string.IsNullOrEmpty(Failed_name))
        {
            flag = 2;
            message += " ولم يتم ارسال الايميل إلي " + Failed_name;
        }

        if (flag == 1)
        {

          //  Commission_Visa_DT obj = Commission_Visa_DB.SelectByID(CDataConverter.ConvertToInt(visa_id));
            Commission_Visa obj = new Commission_Visa();


            obj.mail_sent = 1;
          //  Commission_Visa_DB.Save(obj);
            InsertOrUpdate_Commission_Visa(obj);


        }

        return message;


        //      if (!string.IsNullOrEmpty(Failed_name))
        //        Page.RegisterStartupScript("Sucess", "<script language=javascript>alert(' لم يتم ارسال الايميل إلي " + Failed_name + "')</script>");

    }
    private void Fil_Visa_Lstbox(int ID)
    {
        int v_id = CDataConverter.ConvertToInt(hidden_Visa_Id.Value);
 
        int visaid = CDataConverter.ConvertToInt(hidden_Visa_Id.Value);
      // string sql = "SELECT dbo.EMPLOYEE.pmp_name, dbo.Commission_Visa_Emp.Emp_ID, dbo.Commission_Visa_Emp.Visa_Id FROM  dbo.EMPLOYEE INNER JOIN dbo.Commission_Visa_Emp ON dbo.EMPLOYEE.PMP_ID = dbo.Commission_Visa_Emp.Emp_ID where dbo.Commission_Visa_Emp.Visa_Id = " + hidden_Visa_Id.Value;

       DataTable dt = pmentity.Fil_Visa_foremployee(visaid).ToDataTable();

        //DataTable dt = General_Helping.GetDataTable(sql);
     
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            ListItem obj = new ListItem(dt.Rows[i]["pmp_name"].ToString(), dt.Rows[i]["Emp_ID"].ToString());
            lst_emp.Items.Add(obj);
            drop_Resp_close_emp.Items.Add(obj);


        }
        drop_Resp_close_emp.Items.Insert(0, new ListItem(" اختر الموظف المسئول عن اغلاق التكليف ......", "0"));

    }
    protected void chk_ALL_CheckedChanged(object sender, EventArgs e)
    {
        foreach (ListItem item in chklst_Visa_Emp_All.Items)
        {
            item.Selected = chk_ALL.Checked;
        }
        TabPanel_All.ActiveTab = TabPanel_Visa;
    }
    protected void Chk_ALL_cat_CheckedChanged(object sender, EventArgs e)
    {
        //foreach (ListItem item in Chk_main_cat.Items)
        //{
        //    item.Selected = Chk_ALL_cat.Checked;
        //}
        //TabPanel_All.ActiveTab = TabPanel_dtl;
    }

    private void Fil_Visa_Lst(int ID)
    {
       // string Sql_Delete = "select * from Commission_Visa_Emp where Visa_Id =" + ID;
       // DataTable DT = General_Helping.GetDataTable(Sql_Delete);

        var query = from commvisa in pmentity.Commission_Visa where commvisa.Visa_Id == ID select commvisa;
        DataTable DT = query.ToDataTable();


        foreach (DataRow dr in DT.Rows)
        {
            string Value = dr["Emp_ID"].ToString();
            ListItem item = chklst_Visa_Emp.Items.FindByValue(Value);
            if (item != null)
                item.Selected = true;
        }
    }

    private void Fil_Visa_Control(int ID)
    {

        
       // Commission_Visa_DT obj = Commission_Visa_DB.SelectByID(ID);

        Commission_Visa  obj = pmentity.Commission_Visa.Where(x => x.Commission_ID == ID ).SingleOrDefault();
      
        if (obj.Visa_Id > 0)
        {
            try
            {
                hidden_Visa_Id.Value = obj.Visa_Id.ToString();
                txt_Visa_date.Text = obj.Visa_date;
                if (obj.Important_Degree > 0)
                    ddl_Important_Degree.SelectedValue = obj.Important_Degree.ToString();
                else
                    txt_Important_Degree_Txt.Text = obj.Important_Degree_Txt;
                if (obj.Dept_ID > 0)
                    //ddl_Visa_Dept_ID.SelectedValue = obj.Dept_ID.ToString();
                    Smart_Search_dept.SelectedValue = obj.Dept_ID.ToString();
                else
                {
                    Smart_Search_dept.Clear_Selected();
                    txt_Dept_ID_Txt.Text = obj.Dept_ID_Txt;
                }
                fil_emp_Visa();
                if (obj.Emp_ID > 0)
                {
                    ListItem item = chklst_Visa_Emp.Items.FindByValue(obj.Emp_ID.ToString());
                    //ListItem item_fav = chklst_Visa_Emp_fav.Items.FindByValue(obj.Emp_ID.ToString());
                    if (item != null)
                        item.Selected = true;
                    //if (item_fav != null)
                    //    item_fav.Selected = true;

                }
                //else
                //    txt_Emp_ID_Txt.Text = obj.Emp_ID_Txt;




                txt_Visa_Desc.Text = obj.Visa_Desc;
                //txt_Visa_Period.Text = obj.Visa_Period;
                //txt_saving_file.Text = obj.saving_file;
                //ddl_Visa_Satus.SelectedValue = obj.Visa_Satus.ToString();
                //ddl_Follow_Up_Dept_ID.SelectedValue = obj.Follow_Up_Dept_ID.ToString();
                fil_emp_Folow_Up();
                //Smart_Follow_Up_Emp_ID.SelectedValue = obj.Follow_Up_Emp_ID.ToString();
                //txt_Follow_Up_Notes.Text = obj.Follow_Up_Notes;
                txt_Dead_Line_DT.Text = obj.Dead_Line_DT;
                str_deadline = DateTime.Parse(txt_Dead_Line_DT.Text);
                ddl_Visa_Goal_ID.SelectedValue = obj.Visa_Goal_ID.ToString();

            }
            catch
            { }
        }



    }

    //private void Fil_Grid_Visa()
    //{

    //    DataTable DT = new DataTable();
    //    string sql = "select * from Commission_Visa where Commission_ID=" + hidden_Id.Value;


    //    DT = General_Helping.GetDataTable(sql);

    //    GridView_Visa.DataSource = DT;
    //    GridView_Visa.DataBind();

    //}

    protected void btnSend_Click(object sender, EventArgs e)
    {
        

    }

    public string Get_Visa_Emp(object obj)
    {
        int pmp = CDataConverter.ConvertToInt(Session_CS.pmp_id);
        string visa_ID = obj.ToString();
        string emp_name = "";
       DataTable DT = new DataTable();
     //   string sql = "SELECT EMPLOYEE.pmp_name FROM Commission_Visa_Emp INNER JOIN EMPLOYEE ON Commission_Visa_Emp.Emp_ID = EMPLOYEE.PMP_ID WHERE Commission_Visa_Emp.Visa_Id  =" + visa_ID;
     //   DataTable dt_new = General_Helping.GetDataTable("select * from parent_employee where pmp_id = " + CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()));

        var query = from par_emp in outboxDBContext.parent_employees where par_emp.pmp_id == pmp select pmp;
        DataTable dt_new = query.ToDataTable();

        //var resu = pmentity.Get_Visa_foremployee(CDataConverter.ConvertToInt(visa_ID));


        if (dt_new.Rows.Count > 0)
        {

          // sql += " and Commission_Visa_Emp.Emp_id <> " + CDataConverter.ConvertToInt(dt_new.Rows[0]["parent_pmp_id"].ToString());


            DT = (pmentity.get_commission_visa_emp(CDataConverter.ConvertToInt(dt_new.Rows[0]["parent_pmp_id"].ToString())).ToDataTable());
        }
        else
        {
       //     sql += " and Commission_Visa_Emp.Emp_id <> " + CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());


            DT = (pmentity.get_commission_visa_emp( CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString())).ToDataTable());

        }

    //    DT = General_Helping.GetDataTable(sql);

        foreach (DataRow dr in DT.Rows)
        {
            emp_name += dr["pmp_name"].ToString() + ",";
        }
        return emp_name;

    }


    public string Get_Type(object obj)
    {
        string str = obj.ToString();
        if (str == "1")
            return "وثيقة أصلية";
        else if (str == "2")
            return "مرفقات";
        else return "وثيقة";
    }

    public string Get_Type_Visa(object obj)
    {
        string str = obj.ToString();
        if (str == "1")
            return "هام";
        else if (str == "2")
            return "عاجل";
        else if (str == "3")
            return "عادى";
        else return "";
    }

    protected void GridView_Visa_rw_data_bound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string temp_sql = "";
            DataTable Dt;
            string id = (string)Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Visa_Id"));
            int ids = CDataConverter.ConvertToInt(id);
         //   temp_sql = "select mail_sent from Commission_Visa where Visa_Id=" + id;
           // Dt = General_Helping.GetDataTable(temp_sql);

            var query = from comm_visatble in pmentity.Commission_Visa where comm_visatble.Visa_Id == ids select comm_visatble;

            Dt = query.ToDataTable();

            if (Dt.Rows.Count > 0)
            {
                if (Dt.Rows[0]["mail_sent"].ToString() == "1")
                {
                    CheckBox chbsent = (CheckBox)e.Row.FindControl("chkSent");
                    chbsent.Checked = true;
                }

            }
        }
    }


    protected void chkSent_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox checkbox = (CheckBox)sender;
        if (checkbox.Checked)
        {
            GridViewRow row = (GridViewRow)checkbox.NamingContainer;
            ImageButton imgEdit = (ImageButton)row.FindControl("ImgBtnEdit");
            Label lbl_desc = (Label)row.FindControl("lbl_desc");
            string Id = imgEdit.CommandArgument.ToString();

           // Commission_Visa_Follows_DT obj_follow = Commission_Visa_Follows_DB.SelectByID(CDataConverter.ConvertToInt(hidden_Follow_ID.Value));

            Commission_Visa_Follows obj_follow = new Commission_Visa_Follows();
            obj_follow.Follow_ID = 0;
            obj_follow.Commission_ID = CDataConverter.ConvertToInt(hidden_Id.Value);

            obj_follow.Descrption = " تم انهاء التاشيرة " + lbl_desc.Text + " بواسطة  " + Session_CS.pmp_name.ToString();
           // string date = DateTime.Now.ToShortDateString().ToString();
            string date = CDataConverter.ConvertDateTimeNowRtrnString();
            obj_follow.Date = date;
           // obj_follow.time_follow = DateTime.UtcNow.ToLocalTime().ToLongTimeString();

            obj_follow.time_follow = CDataConverter.ConvertDateTimeNowRtnDt().ToLongTimeString();
            obj_follow.entery_pmp_id = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());

            obj_follow.Visa_Emp_id = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());

           // obj_follow.Follow_ID = Commission_Visa_Follows_DB.Save(obj_follow);

            InsertOrUpdate_Commission_Visa_follows(obj_follow);




         //   Commission_Visa_DT obj = Commission_Visa_DB.SelectByID(CDataConverter.ConvertToInt(Id));

            Commission_Visa obj = new Commission_Visa();
            obj.mail_sent = 1;
           // Commission_Visa_DB.Save(obj);

            InsertOrUpdate_Commission_Visa(obj);
            Update_Have_Visa(Id);

            Fil_Grid_Visa_Follow();




        }
        //Fil_Grid_Visa();
        TabPanel_All.ActiveTab = TabPanel_Visa;

    }

    protected void radlst_Type_SelectedIndexChanged(object sender, EventArgs e)
    {

        tr_emp_list.Visible = true;
        string sql, sql_emp = "";
        int dept_selected = CDataConverter.ConvertToInt(Smart_Search_dept.SelectedValue);
        int session_found = CDataConverter.ConvertToInt(Session_CS.foundation_id);



        if (radlst_Type.SelectedValue != "7")
        {


            DataTable DT_emp;

            SqlParameter[] sqlParams = new SqlParameter[4];

            sqlParams[0] = new SqlParameter("@radiocheck", radlst_Type.SelectedValue);
            sqlParams[1] = new SqlParameter("@pmp_id", Session_CS.pmp_id);

            if (CDataConverter.ConvertToInt(Smart_Search_dept.SelectedValue) > 0)
                sqlParams[2] = new SqlParameter("@dept_id", CDataConverter.ConvertToInt(Smart_Search_dept.SelectedValue));
            else
                sqlParams[2] = new SqlParameter("@dept_id", CDataConverter.ConvertToInt(DBNull.Value));

            sqlParams[3] = new SqlParameter("@found_id", Session_CS.foundation_id);

            DT_emp = DatabaseFunctions.SelectDataByParam(sqlParams, "get_employee_accoording_to_radiochek");
            if (DT_emp.Rows.Count > 0)
            {
                chklst_Visa_Emp_All.DataSource = DT_emp;
                chklst_Visa_Emp_All.DataBind();
            }
        }
        TabPanel_All.ActiveTab = TabPanel_Visa;



        //var emp_query = default(object);

        //if (radlst_Type.SelectedValue == "1")
        //{
        //    sql_emp = " select * from pmp_fav_View where pmp_fav_View.employee_id = " + CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());

        //    int pmp = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());

        //  //  emp_query = from emmp in pmentity.pmp_fav_View where emmp.employee_id == pmp select emmp;  

        //    if (Smart_Search_dept.SelectedValue != "")
        //    {
        //       sql_emp += " AND Dept_Dept_id = " + Smart_Search_dept.SelectedValue;

        //       // emp_query = from emmp in pmentity.pmp_fav_View where emmp.employee_id == pmp && emmp.Dept_Dept_id == dept_selected  select emmp; 
        //    }

          


        //}
        //else if (radlst_Type.SelectedValue == "2")
        //{

        //    sql_emp = "SELECT     EMPLOYEE.*,Departments.* FROM Departments  INNER JOIN EMPLOYEE ON Departments.Dept_id = EMPLOYEE.Dept_Dept_id where  EMPLOYEE.PMP_ID not in(select parent_pmp_id from dbo.parent_employee) and dbo.EMPLOYEE.workstatus = 1 and EMPLOYEE.foundation_id='" + Session_CS.foundation_id + "'";

        //    //emp_query = (from empp in pmentity.EMPLOYEE
        //    //             join deppp in pmentity.Departments on empp.Dept_Dept_id equals deppp.Dept_id
        //    //             where empp.foundation_id == session_found
        //    //             select new
        //    //             {

        //    //             }


        //    //            );

        //    if (Smart_Search_dept.SelectedValue != "")
        //    {
        //       sql_emp += " and Dept_Dept_id = " + Smart_Search_dept.SelectedValue;

        //        //emp_query = (from empp in pmentity.EMPLOYEE
        //        //             join deppp in pmentity.Departments on empp.Dept_Dept_id equals deppp.Dept_id
        //        //             where empp.foundation_id == session_found && empp.Dept_Dept_id == dept_selected
        //        //             select new
        //        //             {

        //        //             }


        //        //   );
        //    }
     
        //}
        //else if (radlst_Type.SelectedValue == "3")
        //{
        //    // sql_emp = " select * from employee where rol_rol_id=3  and dbo.EMPLOYEE.workstatus = 1";

        //    sql_emp = "SELECT     EMPLOYEE.*,Departments.* FROM Departments  INNER JOIN EMPLOYEE ON Departments.Dept_id = EMPLOYEE.Dept_Dept_id where dbo.EMPLOYEE.workstatus = 1 and rol_rol_id=3 and EMPLOYEE.foundation_id='" + Session_CS.foundation_id + "'";


        //    if (Smart_Search_dept.SelectedValue != "")
        //    {
        //        sql_emp += " AND Dept_Dept_id = " + Smart_Search_dept.SelectedValue;
        //    }

        //    //if (drop_sectors.SelectedValue != "" && drop_sectors.SelectedValue != "0")
        //    //{
        //    //    sql_emp += "and  Sectors.Sec_id=" + drop_sectors.SelectedValue;
        //    //}

        //}
        //else if (radlst_Type.SelectedValue == "4")
        //{
        //    // sql_emp = " select * from employee where contact_person=1 and dbo.EMPLOYEE.workstatus = 1 ";

        //    sql_emp = "SELECT     EMPLOYEE.*,  Sectors.*,Departments.* FROM Departments INNER JOIN Sectors ON Departments.Sec_sec_id = Sectors.Sec_id INNER JOIN EMPLOYEE ON Departments.Dept_id = EMPLOYEE.Dept_Dept_id where dbo.EMPLOYEE.workstatus = 1 and contact_person=1 and EMPLOYEE.foundation_id='" + Session_CS.foundation_id + "'";

        //    if (Smart_Search_dept.SelectedValue != "")
        //    {
        //        sql_emp += " AND Dept_Dept_id = " + Smart_Search_dept.SelectedValue;
        //    }

        //    //if (drop_sectors.SelectedValue != "" && drop_sectors.SelectedValue != "0")
        //    //{
        //    //    sql_emp += "and  Sectors.Sec_id=" + drop_sectors.SelectedValue;
        //    //}

        //}
        //else if (radlst_Type.SelectedValue == "5")
        //{
        //    sql_emp = "  select EMPLOYEE.pmp_name + ' - رئيس ' + +' '+ Commitee.Commitee_Title as pmp_name ,EMPLOYEE.PMP_ID from EMPLOYEE inner join commitee_presidents on  EMPLOYEE.PMP_ID=commitee_presidents.pmp_id inner join Commitee on commitee_presidents.comt_id = Commitee.ID where  Commitee.foundation_id='" + Session_CS.foundation_id + "'";

        //}

        //else if (radlst_Type.SelectedValue == "6")
        //{

        //    sql_emp = "select EMPLOYEE.pmp_name COLLATE DATABASE_DEFAULT  + ' -  ' + Departments.Dept_name  as pmp_name,EMPLOYEE.PMP_ID from EMPLOYEE inner join commitee_presidents on  EMPLOYEE.PMP_ID=commitee_presidents.pmp_id inner join Departments on  commitee_presidents.dept_id = Departments.Dept_id   inner join Sectors  on Sectors.Sec_id = Departments.Sec_sec_id where Sectors.foundation_id='" + Session_CS.foundation_id + "'";
        //}

       
        //DataTable dt_emp_fav = General_Helping.GetDataTable(sql_emp);
        //chklst_Visa_Emp_All.DataSource = dt_emp_fav;
        //chklst_Visa_Emp_All.DataBind();

       
    }
    protected void Chk_main_cat_SelectedIndexChanged(object sender, EventArgs e)
    {
        //    Chk_sub_cat.Visible = true;
        //    DataTable dt;
        //    ListItem obj;
        //    foreach (ListItem item in Chk_main_cat.Items)
        //    {
        //        if (item.Selected)
        //        {
        //            dt = General_Helping.GetDataTable(" select * from Inbox_sub_categories where main_id = " + item.Value);

        //            for (int i = 0; i < dt.Rows.Count; i++)
        //            {
        //                obj = new ListItem(dt.Rows[i]["name"].ToString(), dt.Rows[i]["id"].ToString());
        //                //lst_emp.Items.Add(obj);
        //                if (Chk_sub_cat.Items.FindByValue(obj.Value) == null)
        //                {
        //                    Chk_sub_cat.Items.Add(obj);
        //                }


        //            }
        //        }
        //        else
        //        {
        //            dt = General_Helping.GetDataTable(" select * from Inbox_sub_categories where main_id = " + item.Value);

        //            for (int i = 0; i < dt.Rows.Count; i++)
        //            {
        //                obj = new ListItem(dt.Rows[i]["name"].ToString(), dt.Rows[i]["id"].ToString());
        //                //lst_emp.Items.Add(obj);


        //                Chk_sub_cat.Items.Remove(obj);



        //            }
        //        }

        //        //item.Selected = Chk_ALL_cat.Checked;
        //    }

        //    TabPanel_All.ActiveTab = TabPanel_dtl;
    }


    protected void drop_sectors_SelectedIndexChanged(object sender, EventArgs e)
    {

        fill_depts();
        dropdept_fun();

    }
}
