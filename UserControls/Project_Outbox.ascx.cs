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
using System.Net.Mail;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using ReportsClass;


public partial class UserControls_Project_Outbox : System.Web.UI.UserControl
{
    Session_CS Session_CS = new Session_CS();
    private string sql_Connection = Database.ConnectionString;
    General_Helping Obj_General_Helping = new General_Helping();
    int id;
    protected void Page_Load(object sender, EventArgs e)
    {
        Smrt_Srch_structure.Show_OrgTree = true;
        Smrt_Srch_structure2.Show_OrgTree = true;
        if (!IsPostBack)
        {
            // Smrt_Srch_structure.Show_OrgTree = true;
            int grp = CDataConverter.ConvertToInt(Session_CS.group_id.ToString());
            if (CDataConverter.ConvertToInt(Session_CS.Project_id.ToString()) > 0)
            {


                if (Session_CS.UROL_UROL_ID != null && CDataConverter.ConvertToInt(Session_CS.UROL_UROL_ID) == 3)
                {
                    string sql1 = " SELECT Proj_id ,pmp_pmp_id " +
                       " FROM     Project     " +
                       " where Proj_id = '" + Session_CS.Project_id + "' and pmp_pmp_id = '" + Session_CS.pmp_id + "'";
                    DataTable DT = General_Helping.GetDataTable(sql1);
                    if (DT.Rows.Count > 0)
                        btn_Doc.Visible = btnClear.Visible = BtnSave.Visible = true;
                    else
                        btn_Doc.Visible = btnClear.Visible = BtnSave.Visible = false;
                }
                else if (Session_CS.UROL_UROL_ID != null && CDataConverter.ConvertToInt(Session_CS.UROL_UROL_ID) == 2)
                {
                    btn_Doc.Visible = btnClear.Visible = BtnSave.Visible = false;
                }
            }
            tr_old_emp.Visible = false;
            string sql_for_chklist_emp = " select * from pmp_fav_View where pmp_fav_View.employee_id = " + CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()) + " ORDER BY LTRIM(pmp_name)";
            DataTable dt_emp_fav = General_Helping.GetDataTable(sql_for_chklist_emp);
            chklst_Visa_Emp_All.DataSource = dt_emp_fav;
            chklst_Visa_Emp_All.DataBind();


            TabPanel_Visa_Folow.Visible = true;
            TabPanel_Visa.Visible = true;
            Button2.Visible = true;

            DataTable dt_get_dr_hesham_visa = General_Helping.GetDataTable("select * from Outbox_Track_Manager where Outbox_id = " + CDataConverter.ConvertToInt(Request["id"]));
            if (dt_get_dr_hesham_visa.Rows.Count > 0)
            {
                txt_dr_hesham_visa.Text = dt_get_dr_hesham_visa.Rows[0]["visa_desc"].ToString();
                if (txt_dr_hesham_visa.Text != "")
                {
                    txt_Visa_Desc.Text = txt_dr_hesham_visa.Text;
                }

            }
            else
            {
                txt_dr_hesham_visa.Text = "";
            }

            // Fil_Dll();

            Fill_main_Category();
            //fill_sectors();
            fill_structure();
            fill_structure2();
            fil_emp_Visa();
            if (Request["id"] != null)
            {
                String decrypted_id = Encryption.Decrypt(Request.QueryString["id"].ToString());
                id = Convert.ToInt16(decrypted_id);
                hidden_Id.Value = id.ToString();
                Fill_Controll(id);
                Fil_Grid_Documents();
                Fil_Grid_Visa();
                Fil_chk_main_category(id);
                Fil_Grid_Visa_Follow();
                Fil_Emp_Visa_Follow();

            }
            else
            {
                DateTime str = CDataConverter.ConvertDateTimeNowRtnDt();
                DateTime st_deadline_date = CDataConverter.ConvertDateTimeNowRtnDt().AddDays(7);
                txt_Dead_Line_DT.Text = CDataConverter.ConvertDateTimeToFormatdmy(st_deadline_date);
                txt_Visa_date.Text = CDataConverter.ConvertDateTimeNowRtrnString();
                txt_Date.Text = CDataConverter.ConvertDateTimeNowRtrnString();
                txt_Follow_Date.Text = CDataConverter.ConvertDateTimeNowRtrnString();

                // btn_print_report.Enabled = false;

            }

            if (Session_CS.pmp_id > 0 && Request["id"] == null)
            {
                //drop_sectors.SelectedValue = Session_CS.sec_id.ToString();
                //ddl_sectors2.SelectedValue = Session_CS.sec_id.ToString();
                //fill_depts();
                fill_structure();
                TabPanel_All.ActiveTabIndex = 0;


            }


        }

    }

    //private void fill_sectors()
    //{
    //    DataTable dt = Sectors_DB.SelectAll(0, CDataConverter.ConvertToInt(Session_CS.foundation_id.ToString()));
    //    drop_sectors.DataSource = dt;
    //    ddl_sectors2.DataSource = dt;

    //    ddl_sectors2.DataBind();
    //    drop_sectors.DataBind();
    //    drop_sectors.Items.Insert(0, new ListItem("إختر القطاع", "0"));
    //    ddl_sectors2.Items.Insert(0, new ListItem("إختر القطاع", "0"));

    //}
    protected void fill_structure()
    {

        string Query = "";
        Query = "SELECT  * from    Departments  where foundation_id='" + Session_CS.foundation_id + "'";


        //if (Request.Url.ToString().ToLower().Contains("admin") || (Session_CS.Hr_Eval != null && Session_CS.Hr_Eval.ToString() == "1"))

        //    tr_allow_chk_dept.Visible = true;

        //else if (Session_CS.Hr_Eval != null && Session_CS.Hr_Eval.ToString() != "1")
        //{
        //    Query += " and Dept_parent_id = '"+Session_CS.Dept_parent_id+"'";
        //    //ddl_sectors.SelectedValue = Session_CS.sec_id.ToString();
        //    Smrt_Srch_structure.SelectedValue = Session_CS.Dept_parent_id.ToString();

        //   // ddl_sectors.Enabled = false;
        //    fill_emplyees();
        //    tr_allow_chk_dept.Visible = true;
        //}

        Smrt_Srch_structure.datatble = General_Helping.GetDataTable(Query);
        Smrt_Srch_structure.Value_Field = "Dept_id";
        Smrt_Srch_structure.Text_Field = "Dept_name";


        Smrt_Srch_structure.DataBind();
    }
    protected void fill_structure2()
    {

        string Query = "";
        Query = "SELECT  * from    Departments  where foundation_id='" + Session_CS.foundation_id + "'";


        //if (Request.Url.ToString().ToLower().Contains("admin") || (Session_CS.Hr_Eval != null && Session_CS.Hr_Eval.ToString() == "1"))

        //    tr_allow_chk_dept.Visible = true;

        //else if (Session_CS.Hr_Eval != null && Session_CS.Hr_Eval.ToString() != "1")
        //{
        //    Query += " and Dept_parent_id = '"+Session_CS.Dept_parent_id+"'";
        //    //ddl_sectors.SelectedValue = Session_CS.sec_id.ToString();
        //    Smrt_Srch_structure.SelectedValue = Session_CS.Dept_parent_id.ToString();

        //   // ddl_sectors.Enabled = false;
        //    fill_emplyees();
        //    tr_allow_chk_dept.Visible = true;
        //}

        Smrt_Srch_structure2.datatble = General_Helping.GetDataTable(Query);
        Smrt_Srch_structure2.Value_Field = "Dept_id";
        Smrt_Srch_structure2.Text_Field = "Dept_name";


        Smrt_Srch_structure2.DataBind();
    }

    protected void drop_sectors_SelectedIndexChanged(object sender, EventArgs e)
    {
        //fill_structure2();
        //fill_depts();
        fil_emp();

        TabPanel_All.ActiveTabIndex = 0;

    }


    protected void fill_depts()
    {
        string Query = "";
        if (Smrt_Srch_structure2.SelectedValue != "0")
        {
            Smrt_Srch_structure2.sql_Connection = sql_Connection;
            //    Smart_Search_mang.Query = "select Dept_ID,Dept_name from Departments where sec_sec_id='" + drop_sectors.SelectedValue + "' ";
            Query = "select Dept_ID,Dept_name from Departments where sec_sec_id='" + CDataConverter.ConvertToInt("0") + "' ";
            Smrt_Srch_structure2.datatble = General_Helping.GetDataTable(Query);
            Smrt_Srch_structure2.Value_Field = "Dept_ID";
            Smrt_Srch_structure2.Text_Field = "Dept_name";
            Smrt_Srch_structure2.Orderby = "ORDER BY LTRIM(Dept_name)";
            Smrt_Srch_structure2.DataBind();
        }
        else
        {
            Smrt_Srch_structure2.Clear_Controls();
        }

        //////////////////////////////////////////////////////////

        if (Smrt_Srch_structure.SelectedValue != "0")
        {
            //Smart_Search_dept.Query = "select Dept_ID,Dept_name from Departments where sec_sec_id='" + ddl_sectors2.SelectedValue + "' ";
            Query = "select Dept_ID,Dept_name from Departments where sec_sec_id='" + CDataConverter.ConvertToInt("0") + "' ";
            Smrt_Srch_structure.datatble = General_Helping.GetDataTable(Query);
            Smrt_Srch_structure.Value_Field = "Dept_ID";
            Smrt_Srch_structure.Text_Field = "Dept_name";
            Smrt_Srch_structure.Orderby = "ORDER BY LTRIM(Dept_name)";
            Smrt_Srch_structure.DataBind();
        }
        else
        {
            Smrt_Srch_structure.Clear_Controls();
        }


        Smart_Emp_ID.sql_Connection = sql_Connection;
        // Smart_Emp_ID.Query = "SELECT PMP_ID, pmp_name,Dept_Dept_id,Sec_id FROM EMPLOYEE inner join dbo.Departments on EMPLOYEE.Dept_Dept_id=Departments.Dept_id inner join Sectors on Sectors.Sec_id=Departments.Sec_sec_id where Sectors.Sec_id='" + drop_sectors.SelectedValue + "' ";
        Query = "SELECT PMP_ID, pmp_name,Dept_Dept_id,Sec_id FROM EMPLOYEE inner join dbo.Departments on EMPLOYEE.Dept_Dept_id=Departments.Dept_id inner join Sectors on Sectors.Sec_id=Departments.Sec_sec_id where Sectors.Sec_id='" + CDataConverter.ConvertToInt("0") + "' ";
        Smart_Emp_ID.datatble = General_Helping.GetDataTable(Query);
        Smart_Emp_ID.Value_Field = "PMP_ID";
        Smart_Emp_ID.Text_Field = "pmp_name";
        //  Smart_Emp_ID.Orderby = "ORDER BY LTRIM(Dept_name)";
        Smart_Emp_ID.DataBind();


    }

    protected void ddl_sectors2_SelectedIndexChanged(object sender, EventArgs e)
    {

        fill_depts();
        fill_resp_Emp();

        dropdept_fun();

    }

    protected void btn_print_report_Click(object sender, EventArgs e)
    {
        string user = Session_CS.pmp_name.ToString();
        int found_id = CDataConverter.ConvertToInt(Session_CS.foundation_id.ToString());
        if (Request.QueryString["id"] != null)
        {
            ReportDocument rd = new ReportDocument();
            string s = Server.MapPath("../Reports/InboxOutboxReport/outbox_Data.rpt");
            rd.Load(s);
            Reports.Load_Report(rd);
            rd.SetParameterValue("@out_ID", CDataConverter.ConvertToInt(hidden_Id.Value));
            rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
            rd.SetParameterValue("@user", user, "footerRep.rpt");
            rd.SetParameterValue("@found_id", found_id, "Logo_Header_pic_dynamic.rpt");

            if (rd.Rows.Count == 0)
            {
                //ShowAlertMessage("!!!!!هذا التقرير لا يوجد به بيانات للعرض !!!!");
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('!!!!!هذا التقرير لا يوجد به بيانات للعرض !!!!');", true);

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
        string Sql = "SELECT Outbox_Visa_Follows.Follow_ID,Outbox_Visa_Follows.File_name,Outbox_Visa_Follows.time_follow,Outbox_Visa_Follows.Outbox_ID, Outbox_Visa_Follows.Descrption, Outbox_Visa_Follows.Date, Outbox_Visa_Follows.Visa_Emp_id, EMPLOYEE.pmp_name " +
                     " FROM  Outbox_Visa_Follows INNER JOIN EMPLOYEE ON Outbox_Visa_Follows.Visa_Emp_id = EMPLOYEE.PMP_ID where Outbox_ID =" + hidden_Id.Value;
        DT = General_Helping.GetDataTable(Sql);

        GridView_Visa_Follow.DataSource = DT;
        GridView_Visa_Follow.DataBind();
    }
    protected void GridView_Visa_Follow_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string sqlformail = "SELECT parent_pmp_id from parent_employee where pmp_id =  " + int.Parse(Session_CS.pmp_id.ToString());
        DataTable ds = General_Helping.GetDataTable(sqlformail);
        int parent_pmp = int.Parse(ds.Rows[0]["parent_pmp_id"].ToString());
        if (e.CommandName == "EditItem")
        {

            Outbox_Visa_Follows_DT obj = Outbox_Visa_Follows_DB.SelectByID(CDataConverter.ConvertToInt(e.CommandArgument));
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
            Outbox_Visa_Follows_DB.Delete(CDataConverter.ConvertToInt(e.CommandArgument));
           // Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم الحذف بنجاح')</script>");
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('لقد تم الحذف بنجاح');", true);

            Fil_Grid_Visa_Follow();
        }

        if (e.CommandName == "SendItem")
        {
            ////////////////////////////////////////////////////////////////////////////////////////////
            /////////////////// Sending Mail Code /////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////

            DataTable dt_getmail = General_Helping.GetDataTable("select mail,pmp_name from employee where pmp_id = " + parent_pmp);
            string mail = dt_getmail.Rows[0]["mail"].ToString();
            string parent_name = dt_getmail.Rows[0]["pmp_name"].ToString();



            MailMessage _Message = new MailMessage();
            if (int.Parse(Session_CS.group_id.ToString()) == 3)
            {
                _Message.Subject = "OUTIR";
            }
            else
            {
                _Message.Subject = "نظام الادارة الالكترونية - المراسلات";
            }


            //_Message.BodyEncoding = Encoding.Unicode;
            _Message.BodyEncoding = Encoding.UTF8;
            _Message.SubjectEncoding = Encoding.UTF8;

            //_Message.To.Add(new MailAddress(mail));



            // _Message.IsBodyHtml = true;
            _Message.Body = "<html><body dir='rtl'><h3 >";

            _Message.Body += " السيد  -   ";
            _Message.Body += parent_name;
            _Message.Body += " </h3>";
            //_Message.Body += " <h1 style=text-align:right>    وصلكم وارد من نظام إدارة مشروعات قطاع البنية المعلوماتية  </h1> ";
            _Message.Body += " <h3 > إيماءً إلى الوارد من  " + Smart_Org_ID.SelectedText + " بتاريخ " + txt_Date.Text + " بخصوص " + txt_Subject.Text + " </h3>";

            bool flag = false;

            string address2 = System.Web.HttpContext.Current.Request.Url.Authority.ToString();
            String encrypted_id = Encryption.Encrypt(hidden_Id.Value);

            string Sql = "SELECT     Inbox_Visa_Follows.Follow_ID, Inbox_Visa_Follows.File_data,Inbox_Visa_Follows.File_name,Inbox_Visa_Follows.File_ext,Inbox_Visa_Follows.Inbox_ID, Inbox_Visa_Follows.Descrption, Inbox_Visa_Follows.Date, Inbox_Visa_Follows.Visa_Emp_id, EMPLOYEE.pmp_name " +
                         " FROM         Inbox_Visa_Follows INNER JOIN EMPLOYEE ON Inbox_Visa_Follows.Visa_Emp_id = EMPLOYEE.PMP_ID where Inbox_ID =" + hidden_Id.Value;

            DataTable dt = General_Helping.GetDataTable(Sql);
            string file = "";
            byte[] files = new byte[0];
            MemoryStream ms = new MemoryStream();
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
                _Message.Body += "<h3 >   ومرفق الوثائق الخاصة بهذا الوارد</h3> <br /><br />";


            _Message.Body += "<h3 > مع تحيات </h3> ";
            _Message.Body += "<h3 >   " + Session_CS.e_signature.ToString() + "  </h3> ";
            _Message.Body += "</body></html>";
            ////SmtpClient config
            //SmtpClient Client = new SmtpClient();
            //Client.Port = int.Parse(ConfigurationManager.AppSettings["SMTP_Port"]);
            //Client.Host = ConfigurationManager.AppSettings["SMTP_Host"];
            //string UserName = ConfigurationManager.AppSettings["SMTP_UserName"];
            //string Password = ConfigurationManager.AppSettings["SMTP_Password"];
            //_Message.From = new MailAddress(ConfigurationManager.AppSettings["SMTP_FromAddress"]);

            ////_Message.Attachments.Add(new Attachment("D:\\Attached.pdf"));
            //System.Net.NetworkCredential SMTPUserInfo = new System.Net.NetworkCredential(UserName, Password);

            //Client.UseDefaultCredentials = false;
            //Client.Credentials = SMTPUserInfo;
            //Client.Timeout = 1000000000;
            try
            {
                //Client.Send(_Message);
                SendingMailthread_class.Sendingmail(_Message, _Message.Subject, _Message.Body, mail, ms, file, encrypted_id, "");
            }
            catch (Exception ex)
            {
                // Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لم يتم ارسال الايميل للسيد المدير المختص بنجاح')</script>");

            }
            //Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم ارسال الايميل للسيد المدير المختص بنجاح')</script>");
        }


    }
    private void Fil_Emp_Visa_Follow()
    {
        if (CDataConverter.ConvertToInt(hidden_Id.Value) > 0)
        {
            DataTable DT = new DataTable();
            string sql = " SELECT   distinct EMPLOYEE.PMP_ID, EMPLOYEE.pmp_name, Outbox_Visa.Outbox_ID " +
                         " FROM   Outbox_Visa_Emp INNER JOIN  EMPLOYEE ON Outbox_Visa_Emp.Emp_ID = EMPLOYEE.PMP_ID " +
                         " INNER JOIN  Outbox_Visa ON Outbox_Visa_Emp.Visa_Id = Outbox_Visa.Visa_Id " +
                         " INNER JOIN  Outbox ON Outbox_Visa.Outbox_ID = Outbox.ID " +
                         " where Outbox_ID=" + hidden_Id.Value;
            DT = General_Helping.GetDataTable(sql);
            Obj_General_Helping.SmartBindDDL(ddl_Visa_Emp_id, DT, "PMP_ID", "pmp_name", "....اختر اسم الموظف ....");
        }
    }
    private void Fill_main_Category()
    {
        DataTable dt_main_cat = General_Helping.GetDataTable(" select * from Inbox_Main_Categories where group_id = " + CDataConverter.ConvertToInt(Session_CS.group_id.ToString()));
        Chk_main_cat.DataSource = dt_main_cat;
        //ddlMainCat.DataTextField = "Name";
        //ddlMainCat.DataValueField = "id";
        Chk_main_cat.DataBind();

    }
    private void fill_sub_category()
    {
        DataTable dt_sub_cat = General_Helping.GetDataTable(" select * from inbox_Sub_Categories ");
        Chk_sub_cat.DataSource = dt_sub_cat;
        //ddlMainCat.DataTextField = "Name";
        //ddlMainCat.DataValueField = "id";
        Chk_sub_cat.DataBind();

    }

    private void Fill_Controll(int id)
    {
        try
        {

            Outbox_DT obj = Outbox_DB.SelectByID(id);
            hidden_Id.Value = obj.ID.ToString();
            hidden_Proj_id.Value = obj.Proj_id.ToString();
            txt_Name.Text = obj.Name;
            txt_Code.Text = obj.Code;
            txt_Date.Text = obj.Date;
            ddl_Type.SelectedValue = obj.Type.ToString();
            Type_Changed();
            //if (obj.Dept_ID > 0)
            // ddl_Dept_ID.SelectedValue = obj.Dept_ID.ToString();
            //  fill_depts();
            // Smart_Search_mang.SelectedValue = obj.Dept_ID.ToString();


            DataTable dt_outboxinside = Outbox_DB.outbox_inside_data(id);

            if (obj.Type.ToString() == "1")
            {
                if (dt_outboxinside.Rows[0]["type"].ToString() == "1")
                {
                    //drop_sectors.SelectedValue = dt_outboxinside.Rows[0]["sec_sec_id"].ToString();
                    fill_structure2();
                    //Fil_Dll();
                    //fill_depts();
                    Smrt_Srch_structure2.SelectedValue = dt_outboxinside.Rows[0]["Org_id"].ToString();
                }
            }

            fil_emp();
            if (obj.Emp_ID > 0)
                Smart_Emp_ID.SelectedValue = obj.Emp_ID.ToString();
            if (obj.Org_Id > 0)
                Smart_Org_ID.SelectedValue = obj.Org_Id.ToString();
            // lbl_Org_Name.Text = obj.Org_Name;
            txt_Org_Out_Box_Code.Text = obj.Org_Out_Box_Code;
            txt_Org_Out_Box_DT.Text = obj.Org_Out_Box_DT;
            txt_Org_Out_Box_Person.Text = obj.Org_Out_Box_Person;
            txt_Subject.Text = obj.Subject;

            ddl_Related_Type.SelectedValue = obj.Related_Type.ToString();

            Related_type_Changed();
            Smart_Related_Id.SelectedValue = obj.Related_Id.ToString();
            txt_Notes.Text = obj.Notes;
            txt_Paper_No.Text = obj.Paper_No;
            txt_Paper_Attached.Text = obj.Paper_Attached;
            // ddl_Follow_Up_Dept_ID.SelectedValue = obj.Follow_Up_Dept_ID.ToString();
            //fil_emp_Folow_Up();
            // Smart_Follow_Up_Emp_ID.SelectedValue = obj.Follow_Up_Emp_ID.ToString();
            // txt_Follow_Up_Notes.Text = obj.Follow_Up_Notes;
            txt_Dept_Desc.Text = obj.Dept_Desc;
            ddl_Source_Type.SelectedValue = obj.Source_Type.ToString();
            txt_Org_Dept_Name.Text = obj.Org_Dept_Name;


            ////////////////////////   fill main and sub category of outbox letter  ///////////////////////////////////////

            DataTable dt = Outbox_DB.outbox_cat_select(id, 1);
            if (dt.Rows.Count > 0)
            {

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Chk_main_cat.SelectedValue = dt.Rows[i]["Cat_id"].ToString();
                }



            }



        }
        catch
        { }
    }
    private void Fil_chk_main_category(int ID)
    {
        string Sql_main_cat = "select * from outbox_cat where outbox_id =" + ID + " and Type =1 and outbox_type = 1";
        DataTable DT_main_cat = General_Helping.GetDataTable(Sql_main_cat);
        DataTable dt_sub_cat = General_Helping.GetDataTable("select * from outbox_cat where outbox_id = " + ID + " and Type=2 and outbox_type = 1 ");
        foreach (DataRow dr in DT_main_cat.Rows)
        {
            string Value = dr["Cat_id"].ToString();
            DataTable dt = General_Helping.GetDataTable(" select * from inbox_sub_categories where main_id = " + Value);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem obj = new ListItem(dt.Rows[i]["name"].ToString(), dt.Rows[i]["id"].ToString());
                Chk_sub_cat.Items.Add(obj);
            }
            ListItem item = Chk_main_cat.Items.FindByValue(Value);
            if (item != null)
                item.Selected = true;


        }
        foreach (DataRow dr in dt_sub_cat.Rows)
        {
            string Value = dr["Cat_id"].ToString();
            ListItem item = Chk_sub_cat.Items.FindByValue(Value);
            if (item != null)
                item.Selected = true;


        }
    }
    protected void btnSend_Click(object sender, EventArgs e)
    {
        if (CDataConverter.ConvertToInt(hidden_Id.Value) > 0)
        {
            ////// get Parent 
            string sqlformail = "SELECT parent_pmp_id from parent_employee where pmp_id =  " + int.Parse(Session_CS.pmp_id.ToString());
            DataTable ds = General_Helping.GetDataTable(sqlformail);
            int parent_pmp = int.Parse(ds.Rows[0]["parent_pmp_id"].ToString());
            ///////////// change  is_new_mail=1 /////////////////////////////////////////////



            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            DataTable DT = new DataTable();
            DT = General_Helping.GetDataTable("select * from Outbox_Track_Manager where Outbox_id = " + hidden_Id.Value);
            if (DT.Rows.Count > 0)
            {
                conn.Open();
                string sql = "update Outbox_Track_Manager set status=1 , All_visa_sent=0 where Outbox_id =" + hidden_Id.Value;
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();

            }
            else
            {
                Outbox_Track_Manager_DT obj = new Outbox_Track_Manager_DT();
                obj.Outbox_id = CDataConverter.ConvertToInt(hidden_Id.Value);
                obj.Have_Visa = 0;
                obj.Have_Follow = 0;
                obj.IS_New_Mail = 1;
                obj.status = 1;
                obj.IS_Old_Mail = 0;
                obj.Visa_Desc = "";
                obj.Type_Track = 1;
                obj.pmp_id = int.Parse(Session_CS.pmp_id.ToString());
                obj.parent_pmp_id = parent_pmp;
                obj.Outbox_id = Outbox_Track_Manager_DB.Save(obj);
                if (obj.Outbox_id > 0)
                    //Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم الارسال بنجاح')</script>");

                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('لقد تم الارسال بنجاح ');", true);

            }


            ////////////////////////////////////////////////////////////////////////////////////////////
            /////////////////// Sending Mail Code /////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////
            ///////////////  to store that mohammed eid send to dr hesham the mail
            Outbox_Visa_Follows_DT obj_follow = Outbox_Visa_Follows_DB.SelectByID(CDataConverter.ConvertToInt(hidden_Follow_ID.Value));
            obj_follow.Follow_ID = CDataConverter.ConvertToInt(hidden_Follow_ID.Value);
            obj_follow.Outbox_ID = CDataConverter.ConvertToInt(hidden_Id.Value);

            obj_follow.Descrption = "تم الارسال الي المدير المختص";
            string date = CDataConverter.ConvertDateTimeToFormatdmy(CDataConverter.ConvertDateTimeNowRtnDt());
            obj_follow.Date = date;
            obj_follow.time_follow = CDataConverter.ConvertDateTimeNowRtnDt().ToLocalTime().ToLongTimeString();
            obj_follow.entery_pmp_id = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
            obj_follow.Visa_Emp_id = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
            obj_follow.Follow_ID = Outbox_Visa_Follows_DB.Save(obj_follow);
            Fil_Grid_Visa_Follow();


            DataTable dt_getmail = General_Helping.GetDataTable("select mail,pmp_name from employee where pmp_id = " + parent_pmp);
            string mail = dt_getmail.Rows[0]["mail"].ToString();
            string parent_name = dt_getmail.Rows[0]["pmp_name"].ToString();

            MailMessage _Message = new MailMessage();
            string str_subj = "";
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

                _Message.Subject = ("OUTIR" + " - " + str_subj + " - " + txt_Date.Text).ToString();

            }
            else
            {

                _Message.Subject = "نظام الادارة الالكترونية - المراسلات" + " - " + str_subj + " - " + txt_Date.Text;
            }


            //_Message.BodyEncoding = Encoding.Unicode;
            _Message.BodyEncoding = Encoding.UTF8;
            _Message.SubjectEncoding = Encoding.UTF8;

            ////_Message.To.Add(new MailAddress(mail));



            //_Message.IsBodyHtml = true;
            _Message.Body = "<html><body dir='rtl'><h3 >";
            _Message.Body += "  السيد";
            _Message.Body += " " + parent_name + "    </h3> ";
            // _Message.Body += " <h1 style=text-align:right>    وصلكم وارد من نظام إدارة مشروعات قطاع البنية المعلوماتية  </h1> ";

            _Message.Body += " <h3 > " + " وصلكم صادر من " + Smart_Org_ID.SelectedText + " بتاريخ " + txt_Date.Text + " بخصوص <br/>" + "<h3 style=" + "color:blue >" + txt_Subject.Text + "</h3>";
            bool flag = false;
            string file = "";
            byte[] files = new byte[0];
            MemoryStream ms = new MemoryStream();
            DataTable dt = General_Helping.GetDataTable("select * from Inbox_OutBox_Files where Inbox_Outbox_ID =" + hidden_Id.Value + " and Inbox_Or_Outbox =2 ");
            foreach (DataRow dr in dt.Rows)
            {

                if (dr["File_data"] != DBNull.Value)
                {

                    file = dr["File_name"].ToString() + dr["File_ext"].ToString();
                    files = (byte[])dr["File_data"];
                    ms = new MemoryStream(files);
                    _Message.Attachments.Add(new Attachment(ms, file));
                    if (ms.Length > 26214400)
                    {
                        //Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('حجم الملفات التابعة لهذا البريد أكبر من المسموح')</script>");

                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('حجم الملفات التابعة لهذا البريد أكبر من المسموح ');", true);

                        return;
                    }
                    flag = true;

                }
            }
            String encrypted_id = Encryption.Encrypt(hidden_Id.Value);
            string address2 = System.Web.HttpContext.Current.Request.Url.Authority.ToString();
            _Message.Body += " <h3 > ورابط الصادر هو  :<br/>";
            _Message.Body += " <h3 >http:" + "/" + "/" + address2 + "/MainForm/ViewProjectOutbox.aspx?id=" + encrypted_id + "&1=1</h3>";

            if (flag)
                _Message.Body += "<h3 >   ومرفق الوثائق الخاصة بهذا الصادر</h3> <br /><br />";


            _Message.Body += "<h3 > مع تحيات </h3> ";
            _Message.Body += "<h3 >   " + Session_CS.e_signature.ToString() + "  </h3> ";
            _Message.Body += "</body></html>";
            ////SmtpClient config
            //SmtpClient Client = new SmtpClient();
            //Client.Port = int.Parse(ConfigurationManager.AppSettings["SMTP_Port"]);
            //Client.Host = ConfigurationManager.AppSettings["SMTP_Host"];
            //string UserName = ConfigurationManager.AppSettings["SMTP_UserName"];
            //string Password = ConfigurationManager.AppSettings["SMTP_Password"];
            //_Message.From = new MailAddress(ConfigurationManager.AppSettings["SMTP_FromAddress"]);

            ////_Message.Attachments.Add(new Attachment("D:\\Attached.pdf"));
            //System.Net.NetworkCredential SMTPUserInfo = new System.Net.NetworkCredential(UserName, Password);

            //Client.UseDefaultCredentials = false;
            //Client.Credentials = SMTPUserInfo;
            //Client.Timeout = 1000000000;

            try
            {
                //_Message.To.Add(new MailAddress(mail));

                //Client.Send(_Message);
                SendingMailthread_class.Sendingmail(_Message, _Message.Subject, _Message.Body, mail, ms, file, encrypted_id, "");

            }
            catch (Exception ex)
            {

                //Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لم يتم ارسال الايميل بنجاح')</script>");

            }
            // Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم ارسال الايميل بنجاح')</script>");



            //////////////////// to show mohammed eid in the drop down list of employee in المسير


        }
        else
        {
           // Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('يجب إدخال بيانات الخطاب أولا')</script>");

            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('يجب إدخال بيانات الخطاب أولا ');", true);


        }

    }
    public string Get_Visa_Emp(object obj)
    {
        string visa_ID = obj.ToString();
        string emp_name = "";
        DataTable DT = new DataTable();
        DT = General_Helping.GetDataTable("SELECT EMPLOYEE.pmp_name FROM Outbox_Visa_Emp INNER JOIN EMPLOYEE ON Outbox_Visa_Emp.Emp_ID = EMPLOYEE.PMP_ID WHERE Outbox_Visa_Emp.Visa_Id  =" + visa_ID);
        foreach (DataRow dr in DT.Rows)
        {
            emp_name += dr["pmp_name"].ToString() + ",";
        }
        return emp_name;

    }


    protected void btnSave_Click(object sender, EventArgs e)
    {
        if ((CDataConverter.ConvertToInt(ddl_Type.SelectedValue) == 2 && CDataConverter.ConvertToInt(Smart_Org_ID.SelectedValue) > 0) || CDataConverter.ConvertToInt(ddl_Type.SelectedValue) == 1)
        {
            string datenow = "";
            int dept = 0;
            int pmp = 0;
            int group = 0;
            Outbox_DT obj = new Outbox_DT();
            obj.ID = CDataConverter.ConvertToInt(hidden_Id.Value);
            obj.Proj_id = int.Parse(Session_CS.Project_id.ToString());
            obj.Name = txt_Name.Text;
            obj.Code = txt_Code.Text;
            obj.Date = txt_Date.Text;
            if (obj.ID == 0)
            {
                datenow = CDataConverter.ConvertDateTimeNowRtnDt().ToString();
                obj.Enter_Date = datenow;
                dept = int.Parse(Session_CS.dept_id.ToString());
                pmp = int.Parse(Session_CS.pmp_id.ToString());
                group = int.Parse(Session_CS.group_id.ToString());
                obj.Dept_Dept_id = dept;
                obj.pmp_pmp_id = pmp;
                obj.Group_id = group;

            }
            else
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                con.Open();
                string sql = "select Enter_Date,Dept_Dept_id,Group_id,pmp_pmp_id from outbox where ID = " + obj.ID;
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                datenow = ds.Tables[0].Rows[0]["Enter_Date"].ToString();
                dept = int.Parse(ds.Tables[0].Rows[0]["Dept_Dept_id"].ToString());
                group = int.Parse(ds.Tables[0].Rows[0]["Group_id"].ToString());
                pmp = int.Parse(ds.Tables[0].Rows[0]["pmp_pmp_id"].ToString());
                obj.Enter_Date = datenow;
                obj.Dept_Dept_id = dept;
                obj.Group_id = group;
                obj.pmp_pmp_id = pmp;
            }

            obj.Type = CDataConverter.ConvertToInt(ddl_Type.SelectedValue);
            if (CDataConverter.ConvertToInt(ddl_Type.SelectedValue) == 1)
            {
                //if (CDataConverter.ConvertToInt(ddl_Dept_ID.SelectedValue) > 0)
                //{
                //    obj.Dept_ID = CDataConverter.ConvertToInt(ddl_Dept_ID.SelectedValue);
                //    obj.Org_Id = 0;
                //}
                if (CDataConverter.ConvertToInt(Smrt_Srch_structure2.SelectedValue) > 0)
                {
                    obj.Dept_ID = CDataConverter.ConvertToInt(Smrt_Srch_structure2.SelectedValue);
                    obj.Org_Id = 0;
                }

                else
                {
                    //Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('يجب إختيار الإدارة')</script>");

                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('يجب إختيار الإدارة ');", true);

                    return;
                }

            }
            else
            {
                obj.Dept_ID = 0;
                obj.Org_Id = CDataConverter.ConvertToInt(Smart_Org_ID.SelectedValue);
            }

            obj.Emp_ID = CDataConverter.ConvertToInt(Smart_Emp_ID.SelectedValue);

            //obj.Org_Name = lbl_Org_Name.Text;
            obj.Org_Out_Box_Code = txt_Org_Out_Box_Code.Text;
            obj.Org_Out_Box_DT = txt_Org_Out_Box_DT.Text;
            obj.Org_Out_Box_Person = txt_Org_Out_Box_Person.Text;
            obj.Subject = txt_Subject.Text;
            //obj.Related_link_type =CDataConverter.ConvertToInt( ddl_Related_Type.SelectedValue);
            obj.Related_Type = CDataConverter.ConvertToInt(ddl_Related_Type.SelectedValue);
            obj.Related_Id = CDataConverter.ConvertToInt(Smart_Related_Id.SelectedValue);
            obj.Notes = txt_Notes.Text;
            obj.Paper_No = txt_Paper_No.Text;
            obj.Paper_Attached = txt_Paper_Attached.Text;
            obj.Follow_Up_Dept_ID = 0;
            obj.Follow_Up_Emp_ID = 0;
            obj.Dept_Desc = txt_Dept_Desc.Text;
            obj.Source_Type = CDataConverter.ConvertToInt(ddl_Source_Type.SelectedValue);
            obj.Status = 0;
            obj.finished = 0;
            obj.Org_Dept_Name = txt_Org_Dept_Name.Text;
            obj.foundation_id = CDataConverter.ConvertToInt(Session_CS.foundation_id.ToString());
            obj.ID = Outbox_DB.Save(obj);
            hidden_Id.Value = obj.ID.ToString();

            string Sql_Delete = "delete from  outbox_cat where  outbox_id = " + obj.ID;
            General_Helping.ExcuteQuery(Sql_Delete);

            foreach (ListItem item in Chk_main_cat.Items)
            {
                if (item.Selected)
                {
                    ////string Sql_insert = "insert into outbox_cat ( outbox_id , Cat_id ,Type,outbox_type) values ( " + obj.ID + "," + item.Value + ",1,1 " + ")";
                    ////General_Helping.ExcuteQuery(Sql_insert);
                    Outbox_DB.Outbox_cat_save(CDataConverter.ConvertToInt(obj.ID), CDataConverter.ConvertToInt(item.Value), 1, 1);
                }
            }
            foreach (ListItem item in Chk_sub_cat.Items)
            {
                if (item.Selected)
                {
                    //string Sql_insert = "insert into outbox_cat ( outbox_id , Cat_id ,Type,outbox_type) values ( " + obj.ID + "," + item.Value + ",2,1 " + ")";
                    //General_Helping.ExcuteQuery(Sql_insert);
                    Outbox_DB.Outbox_cat_save(CDataConverter.ConvertToInt(obj.ID), CDataConverter.ConvertToInt(item.Value), 2, 1);
                }
            }
            int found = Session_CS.foundation_id;
            if (obj.ID > 0)
            {

                string sql_related = "";
                if (ddl_Related_Type.SelectedValue == "2")
                {

                    //sql_related = "insert into Inbox_Relations values ( " + obj.ID + "," + CDataConverter.ConvertToInt(Smart_Related_Id.SelectedValue) + ",1,2," + found + " )";
                    sql_related = "insert into Inbox_Relations values ( " + obj.ID + ",2," + CDataConverter.ConvertToInt(Smart_Related_Id.SelectedValue) + ",1," + found + " )";
                    sql_related += " insert into Inbox_Relations values ( " + CDataConverter.ConvertToInt(Smart_Related_Id.SelectedValue) + ",1," + obj.ID + ",2," + found + " )";
                    General_Helping.ExcuteQuery(sql_related);
                }
                else if (ddl_Related_Type.SelectedValue == "3")
                {
                    // sql_related = "insert into Inbox_Relations values ( " + obj.ID + "," + CDataConverter.ConvertToInt(Smart_Related_Id.SelectedValue) + ",2,2," + found + " )";
                    sql_related = "insert into Inbox_Relations values ( " + obj.ID + ",2," + CDataConverter.ConvertToInt(Smart_Related_Id.SelectedValue) + ",2," + found + " )";
                    General_Helping.ExcuteQuery(sql_related);
                }

               // Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم الحفظ بنجاح')</script>");

                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('لقد تم الحفظ بنجاح');", true);


            }
            else
            {
              //  Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لم يتم الحفظ يرجى التأكد من البيانات ')</script>");

                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('لم يتم الحفظ يرجى التأكد من البيانات');", true);

            }
            if (ddl_Related_Type.SelectedValue == "2")
            {
                string sql = "update inbox set Related_Type =5 , Related_Id = " + hidden_Id.Value + " where ID = " + Smart_Related_Id.SelectedValue + " and Related_Type=1";
                General_Helping.ExcuteQuery(sql);
            }
        }
        else
        {
            //Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('يجب إختيار الجهة الصادر لها')</script>");

            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('يجب إختيار الجهة الصادر لها');", true);


        }
        Fil_Smrt_From_Outbox();

    }

    private void Fil_Smrt_From_Outbox()
    {
        Smart_Related_Id.sql_Connection = sql_Connection;
        //  Smart_Related_Id.Query = "SELECT * from vw_outbox_DateSubject where group_id =  " + int.Parse(Session_CS.group_id.ToString());
        string Query = "SELECT * from vw_outbox_DateSubject where group_id =  " + int.Parse(Session_CS.group_id.ToString());
        Smart_Related_Id.datatble = General_Helping.GetDataTable(Query);
        Smart_Related_Id.Show_Code = false;
        Smart_Related_Id.Value_Field = "id";
        Smart_Related_Id.Text_Field = "con";
        Smart_Related_Id.DataBind();
    }
    private void Fil_Dll()
    {
        //  DataTable DT = new DataTable();
        //  DT = General_Helping.GetDataTable("select * from Departments");
        // Obj_General_Helping.SmartBindDDL(ddl_Dept_ID, DT, "Dept_ID", "Dept_name", "....اختر اسم الإدارة ....");

        //Obj_General_Helping.SmartBindDDL(ddl_Visa_Dept_ID, DT, "Dept_ID", "Dept_name", "....اختر اسم الإدارة ....");

        //DataTable dt_Org = new DataTable();
        //dt_Org = General_Helping.GetDataTable("SELECT [Org_ID], [Org_Desc] FROM [Organization]");
        //Obj_General_Helping.SmartBindDDL(ddl_Org_Id, dt_Org, "Org_ID", "Org_Desc", "....اختر اسم الإدارة ....");
    }
    protected override void OnInit(EventArgs e)
    {
        #region BROWSER FOR departments

        int found_id = CDataConverter.ConvertToInt(Session_CS.foundation_id.ToString());
        string Query = "";
        Smart_Org_ID.sql_Connection = sql_Connection;
        Query = "SELECT Org_ID, Org_Desc FROM Organization where foundation_id = " + found_id;
        Smart_Org_ID.datatble = General_Helping.GetDataTable(Query);
        Smart_Org_ID.Value_Field = "Org_ID";
        Smart_Org_ID.Text_Field = "Org_Desc";
        Smart_Org_ID.DataBind();
        //this.Smrt_Srch_DropDep.Value_Handler += new Smart_Search.Delegate_Selected_Value(MOnMember_Data);
        //Inbox_organization.SelectedValue;
        Smart_Emp_ID.sql_Connection = sql_Connection;

        //Query = "SELECT PMP_ID, pmp_name FROM EMPLOYEE ";
        //Smart_Emp_ID.datatble = General_Helping.GetDataTable(Query);
        //Smart_Emp_ID.Value_Field = "PMP_ID";
        //Smart_Emp_ID.Text_Field = "pmp_name";
        //Smart_Emp_ID.DataBind();


        //Smart_Search_dept.sql_Connection = sql_Connection;
        //Query = "SELECT Dept_id, Dept_name FROM Departments ";
        //Smart_Search_dept.datatble = General_Helping.GetDataTable(Query);
        //Smart_Search_dept.Value_Field = "Dept_id";
        //Smart_Search_dept.Text_Field = "Dept_name";
        //Smart_Search_dept.DataBind();
        this.Smrt_Srch_structure.Value_Handler += new Smart_Search.Delegate_Selected_Value(MOnMember_Data);
        this.Smrt_Srch_structure2.Value_Handler += new Smart_Search.Delegate_Selected_Value(MOnMember_Data2);

        #endregion
        base.OnInit(e);
    }


    private void MOnMember_Data(string Value)
    {
        dropdept_fun();
        fill_emplyees();
    }

    private void MOnMember_Data2(string Value)
    {

        fill_emplyees();
        fill_resp_Emp();
    }
    protected void fill_emplyees()
    {
        Smart_Emp_ID.sql_Connection = sql_Connection;
        string Query = "SELECT     EMPLOYEE.PMP_ID, EMPLOYEE.pmp_name, Departments.sec_sec_id FROM         EMPLOYEE INNER JOIN                       Departments ON EMPLOYEE.Dept_Dept_id = Departments.Dept_ID  and EMPLOYEE.workstatus!=4";
        if (Smrt_Srch_structure2.SelectedValue != "")
        {
            Query += " where Departments.Dept_ID =  " + Smrt_Srch_structure2.SelectedValue;
        }


        Smart_Emp_ID.datatble = General_Helping.GetDataTable(Query);
        Smart_Emp_ID.Value_Field = "pmp_id";
        Smart_Emp_ID.Text_Field = "pmp_name";
        Smart_Emp_ID.Orderby = "ORDER BY LTRIM(pmp_name)";
        Smart_Emp_ID.DataBind();


    }
    protected void dropdept_fun()
    {
        //SqlConnection conn = new SqlConnection(sql_Connection);


        fil_emp_Visa();

        tr_emp_list.Visible = true;
        string sql, sql_emp = "";

        if (radlst_Type.SelectedValue == "1")
        {
            sql_emp = " select * from pmp_fav_View where pmp_fav_View.employee_id = " + CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
            if (Smrt_Srch_structure.SelectedValue != "")
            {
                sql_emp += " AND Dept_Dept_id = " + Smrt_Srch_structure.SelectedValue;
                //sql_emp += "  and  sec_sec_id=" + CDataConverter.ConvertToInt("0");
            }
            //if (ddl_sectors2.SelectedValue != "" && ddl_sectors2.SelectedValue != "0")
            //{
            //    sql_emp += "  and  sec_sec_id=" + ddl_sectors2.SelectedValue;
            //}



        }
        else if (radlst_Type.SelectedValue == "2")
        {
            // sql_emp = " select * from employee where dbo.EMPLOYEE.workstatus = 1";


            sql_emp = "SELECT     EMPLOYEE.*,Departments.* FROM Departments  INNER JOIN EMPLOYEE ON Departments.Dept_id = EMPLOYEE.Dept_Dept_id where  EMPLOYEE.PMP_ID not in(select parent_pmp_id from dbo.parent_employee) and dbo.EMPLOYEE.workstatus = 1 and EMPLOYEE.foundation_id='" + Session_CS.foundation_id + "'";

            if (Smrt_Srch_structure.SelectedValue != "")
            {
                sql_emp += " and Dept_Dept_id = " + Smrt_Srch_structure.SelectedValue;
                //sql_emp += "  and  sec_sec_id=" + CDataConverter.ConvertToInt("0");
            }
            //if (ddl_sectors2.SelectedValue != "" && ddl_sectors2.SelectedValue != "0")
            //{
            //    sql_emp += "and  Sectors.Sec_id=" + ddl_sectors2.SelectedValue;
            //}

        }
        else if (radlst_Type.SelectedValue == "3")
        {
            // sql_emp = " select * from employee where rol_rol_id=3  and dbo.EMPLOYEE.workstatus = 1";

            sql_emp = "SELECT     EMPLOYEE.*,Departments.* FROM Departments  INNER JOIN EMPLOYEE ON Departments.Dept_id = EMPLOYEE.Dept_Dept_id where dbo.EMPLOYEE.workstatus = 1 and rol_rol_id=3 and EMPLOYEE.foundation_id='" + Session_CS.foundation_id + "'";


            if (Smrt_Srch_structure.SelectedValue != "")
            {
                sql_emp += " AND Dept_Dept_id = " + Smrt_Srch_structure.SelectedValue;
                //sql_emp += "  and  sec_sec_id=" + CDataConverter.ConvertToInt("0");
            }

            //if (ddl_sectors2.SelectedValue != "" && ddl_sectors2.SelectedValue != "0")
            //{
            //    sql_emp += "and  Sectors.Sec_id=" + ddl_sectors2.SelectedValue;
            //}

        }
        else if (radlst_Type.SelectedValue == "4")
        {
            // sql_emp = " select * from employee where contact_person=1 and dbo.EMPLOYEE.workstatus = 1 ";

            sql_emp = "SELECT     EMPLOYEE.*,  Sectors.*,Departments.* FROM Departments INNER JOIN Sectors ON Departments.Sec_sec_id = Sectors.Sec_id INNER JOIN EMPLOYEE ON Departments.Dept_id = EMPLOYEE.Dept_Dept_id where dbo.EMPLOYEE.workstatus = 1 and contact_person=1 and EMPLOYEE.foundation_id='" + Session_CS.foundation_id + "'";

            if (Smrt_Srch_structure.SelectedValue != "")
            {
                sql_emp += " AND Dept_Dept_id = " + Smrt_Srch_structure.SelectedValue;
                //sql_emp += "  and  sec_sec_id=" + CDataConverter.ConvertToInt("0");
            }

            //if (ddl_sectors2.SelectedValue != "" && ddl_sectors2.SelectedValue != "0")
            //{
            //    sql_emp += "and  Sectors.Sec_id=" + ddl_sectors2.SelectedValue;
            //}

        }

        else if (radlst_Type.SelectedValue == "5")
        {
            sql_emp = "  select EMPLOYEE.pmp_name + ' - رئيس ' + +' '+ Commitee.Commitee_Title as pmp_name ,EMPLOYEE.PMP_ID from EMPLOYEE inner join commitee_presidents on  EMPLOYEE.PMP_ID=commitee_presidents.pmp_id inner join Commitee on commitee_presidents.comt_id = Commitee.ID where  Commitee.foundation_id='" + Session_CS.foundation_id + "'";

        }

        else if (radlst_Type.SelectedValue == "6")
        {

            sql_emp = "select EMPLOYEE.pmp_name COLLATE DATABASE_DEFAULT  + ' -  ' + Departments.Dept_name  as pmp_name,EMPLOYEE.PMP_ID from EMPLOYEE inner join commitee_presidents on  EMPLOYEE.PMP_ID=commitee_presidents.pmp_id inner join Departments on  commitee_presidents.dept_id = Departments.Dept_id   inner join Sectors  on Sectors.Sec_id = Departments.Sec_sec_id where Sectors.foundation_id='" + Session_CS.foundation_id + "'";
        }
        sql_emp += " ORDER BY LTRIM(pmp_name)";
        TabPanel_All.ActiveTab = TabPanel_Visa;
        DataTable dt_emp_fav = General_Helping.GetDataTable(sql_emp);
        chklst_Visa_Emp_All.DataSource = dt_emp_fav;
        chklst_Visa_Emp_All.DataBind();
        TabPanel_All.ActiveTab = TabPanel_Visa;

    }
    protected void ddl_Type_SelectedIndexChanged(object sender, EventArgs e)
    {
        Type_Changed();

    }

    private void Type_Changed()
    {
        if (ddl_Type.SelectedValue == "1")
        {
            tr_Inbox_out.Visible = false;
           // tr_Inbox_In.Visible = true;

            tr_Inbox_In.Style.Add("display", "block");
        }
        else if (ddl_Type.SelectedValue == "2")
        {
          //  tr_Inbox_In.Visible = false;
            tr_Inbox_In.Style.Add("display", "none");
            tr_Inbox_out.Visible = true;
        }
        TabPanel_All.ActiveTab = TabPanel_dtl;
    }
    //protected void ddl_Dept_ID_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    fil_emp();
    //}
    protected void ddl_Follow_Up_Dept_ID_SelectedIndexChanged(object sender, EventArgs e)
    {
        fil_emp_Folow_Up();
    }
    protected void ddl_Visa_Dept_ID_SelectedIndexChanged(object sender, EventArgs e)
    {
        fil_emp_Visa();
        TabPanel_All.ActiveTab = TabPanel_Visa;
    }
    private void fil_emp_Visa()
    {
        int Dept_ID = CDataConverter.ConvertToInt(Smrt_Srch_structure.SelectedValue);
        string sql = "SELECT PMP_ID, pmp_name FROM EMPLOYEE where 1=1 ";
        if (Dept_ID > 0)
        {
            sql += " and Dept_Dept_id = " + Dept_ID;

        }
        sql += " order by pmp_name asc";
        chklst_Visa_Emp.DataSource = General_Helping.GetDataTable(sql);
        chklst_Visa_Emp.DataBind();

        //    Smart_Visa_Emp.sql_Connection = sql_Connection;
        //    Smart_Visa_Emp.Query = "SELECT PMP_ID, pmp_name FROM EMPLOYEE where Dept_Dept_id = " + Dept_ID;
        //    Smart_Visa_Emp.Value_Field = "PMP_ID";
        //    Smart_Visa_Emp.Text_Field = "pmp_name";
        //    Smart_Visa_Emp.DataBind();
        //}
        //else
        //    Smart_Visa_Emp.Clear_Controls();
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
        Smart_Emp_ID.sql_Connection = sql_Connection;
        string Query = "";
        Query = "SELECT     EMPLOYEE.*,  Sectors.*,Departments.* FROM Departments INNER JOIN Sectors ON Departments.Sec_sec_id = Sectors.Sec_id INNER JOIN EMPLOYEE ON Departments.Dept_id = EMPLOYEE.Dept_Dept_id where dbo.EMPLOYEE.workstatus = 1";
        if (Smrt_Srch_structure2.SelectedValue != "")
        {
            Query += " and Departments.Dept_id = " + Smrt_Srch_structure2.SelectedValue;
            //Query += " and  Sectors.Sec_id=" + CDataConverter.ConvertToInt("0");
        }
        //if (drop_sectors.SelectedValue != "" && drop_sectors.SelectedValue != "0")
        //{
        //    Query += " and  Sectors.Sec_id=" + drop_sectors.SelectedValue;
        //}
        Smart_Emp_ID.datatble = General_Helping.GetDataTable(Query);
        Smart_Emp_ID.Value_Field = "PMP_ID";
        Smart_Emp_ID.Text_Field = "pmp_name";
        Smart_Emp_ID.DataBind();






    }
    protected void ddl_Related_Type_SelectedIndexChanged(object sender, EventArgs e)
    {
        Related_type_Changed();

    }

    private void Related_type_Changed()
    {
        if (ddl_Related_Type.SelectedValue == "1")
        {
            trSmart.Visible = false;
        }
        else if (ddl_Related_Type.SelectedValue == "2")
        {

            trSmart.Visible = true;
            lbl_Inbox_type.Text = "رد على وارد رقم";
            Fil_Smrt_From_InBox();

        }
        else if (ddl_Related_Type.SelectedValue == "3")
        {

            trSmart.Visible = true;
            lbl_Inbox_type.Text = "استعجال للصادر رقم";
            Fil_Smrt_From_OutBox();

        }
        else if (ddl_Related_Type.SelectedValue == "4")
        {

            trSmart.Visible = true;
            lbl_Inbox_type.Text = "رد علي تأشيرة وزير رقم";
            Fil_Smrt_From_InBox_Minister();

        }
        TabPanel_All.ActiveTab = TabPanel_dtl;
    }

    void Fil_Smrt_From_OutBox()
    {
        Smart_Related_Id.sql_Connection = sql_Connection;
        // Smart_Related_Id.Query = "SELECT * from vw_outbox_DateSubject where group_id = " + int.Parse(Session_CS.group_id.ToString());
        string Query = "set dateformat dmy SELECT vw_outbox_DateSubject.*,CONVERT(datetime, dbo.datevalid(Date)) as date1 from vw_outbox_DateSubject where group_id = " + int.Parse(Session_CS.group_id.ToString());
        if (CDataConverter.ConvertToInt(Session_CS.Project_id.ToString()) > 0)
        {
            Query += " AND Proj_id = " + int.Parse(Session_CS.Project_id.ToString());
        }
        Query += " order by  convert(datetime,Date) desc ";
        Smart_Related_Id.datatble = General_Helping.GetDataTable(Query);
        Smart_Related_Id.Value_Field = "id";
        Smart_Related_Id.Text_Field = "con";
        Smart_Related_Id.Show_Code = false;
        Smart_Related_Id.Orderby = "date1 desc";
        Smart_Related_Id.DataBind();
    }
    public  void ShowAlertMessage(string error)
    {

        Page page = HttpContext.Current.Handler as Page;
        if (page != null)
        {
            error = error.Replace("'", "\'");
          //  ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('" + error + "');", true);

            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('"+error+"');", true);



        }
    }
    void Fil_Smrt_From_InBox()
    {
        Smart_Related_Id.sql_Connection = sql_Connection;
        // Smart_Related_Id.Query = "SELECT * from vw_inbox_DateSubject where  group_id = " + int.Parse(Session_CS.group_id.ToString());
        string Query = "set dateformat dmy SELECT vw_inbox_DateSubject.*,CONVERT(datetime, dbo.datevalid(Date)) as date1 from vw_inbox_DateSubject where  group_id = " + int.Parse(Session_CS.group_id.ToString());
        if (CDataConverter.ConvertToInt(Session_CS.Project_id.ToString()) > 0)
        {
            Query += " AND Proj_id = " + int.Parse(Session_CS.Project_id.ToString());
        }
        Query += " order by CONVERT(datetime, dbo.datevalid(Date)) desc ";
        Smart_Related_Id.datatble = General_Helping.GetDataTable(Query);
        Smart_Related_Id.Value_Field = "id";
        Smart_Related_Id.Text_Field = "con";
        Smart_Related_Id.Show_Code = false;
        Smart_Related_Id.Orderby = "date1 desc";
        Smart_Related_Id.DataBind();
    }
    void Fil_Smrt_From_InBox_Minister()
    {
        Smart_Related_Id.sql_Connection = sql_Connection;
        string Query = "";
        Query = "set dateformat dmy SELECT vw_inbox_minister_DateSubject.* from vw_inbox_minister_DateSubject where  group_id = " + int.Parse(Session_CS.group_id.ToString());
        if (CDataConverter.ConvertToInt(Session_CS.Project_id.ToString()) > 0)
        {
            Query += " AND Proj_id = " + int.Parse(Session_CS.Project_id.ToString());
        }
        Smart_Related_Id.datatble = General_Helping.GetDataTable(Query);
        Smart_Related_Id.Value_Field = "id";
        Smart_Related_Id.Text_Field = "con";
        Smart_Related_Id.Show_Code = false;
        Smart_Related_Id.DataBind();
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        hidden_Id.Value = "";
        txt_Code.Text = "";
        Smart_Org_ID.SelectedValue = "";
        txt_Org_Out_Box_Code.Text = "";
        txt_Org_Out_Box_DT.Text = "";
        txt_Org_Dept_Name.Text = "";
        txt_Org_Out_Box_Person.Text = "";
        txt_Dept_Desc.Text = "";
        txt_Subject.Text = "";
        txt_Paper_No.Text = "";
        txt_Paper_Attached.Text = "";
        txt_Notes.Text = "";
        txtFileName.Text = "";
        GrdView_Documents.DataSource = null;
        GrdView_Documents.DataBind();
        GridView_Visa.DataSource = null;
        GridView_Visa.DataBind();
        lst_emp.Items.Clear();
    }

    protected void btn_Doc_Click(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand();
        SqlConnection con = new SqlConnection();
        SqlCommand cmd_local = new SqlCommand();
        SqlConnection con_local = new SqlConnection();
        con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        con_local = new SqlConnection(Session_CS.local_connectionstring);
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
                cmd.Parameters.Add("@Inbox_Or_Outbox", SqlDbType.Int);
                cmd.Parameters.Add("@Inbox_Outbox_ID", SqlDbType.Int);
                cmd.Parameters.Add("@Inbox_OutBox_File_ID", SqlDbType.Int);
                cmd.Parameters.Add("@Original_Or_Attached", SqlDbType.Int);
                cmd.Parameters.Add("@File_name", SqlDbType.NVarChar);
                cmd.Parameters.Add("@File_ext", SqlDbType.NVarChar);
                cmd.Parameters.Add("@File_data", SqlDbType.VarBinary);
                cmd.Parameters["@Inbox_OutBox_File_ID"].Value = CDataConverter.ConvertToInt(hidden_Inbox_OutBox_File_ID.Value);
                cmd.Parameters["@Original_Or_Attached"].Value = CDataConverter.ConvertToInt(ddl_Original_Or_Attached.SelectedValue);
                cmd.Parameters["@File_ext"].Value = type;
                cmd.Parameters["@File_name"].Value = txtFileName.Text;
                cmd.Parameters["@Inbox_Or_Outbox"].Value = 2;

                cmd.CommandType = CommandType.Text;



                if (CDataConverter.ConvertToInt(hidden_Inbox_OutBox_File_ID.Value) > 0)
                {

                    cmd.CommandText = " update Inbox_OutBox_Files set Original_Or_Attached=@Original_Or_Attached ,File_data=@File_data ,File_name=@File_name,File_ext=@File_ext where Inbox_OutBox_File_ID =@Inbox_OutBox_File_ID";
                   

                    if (string.IsNullOrEmpty(Session_CS.local_connectionstring))
                    {
                        cmd.Connection = con;
                        cmd.Parameters["@File_data"].Value = Input;
                        con.Open();
                        cmd.ExecuteScalar();
                        con.Close();

                    }
                    else
                    {

                        cmd.Connection = con;
                        cmd.Parameters["@File_data"].Value = DBNull.Value;
                        con.Open();
                        cmd.ExecuteScalar();
                        con.Close();
                        try
                        {
                            cmd.Connection = con_local;
                            cmd.Parameters["@File_data"].Value = Input;
                            
                            con_local.Open();
                            cmd.ExecuteScalar();
                            con_local.Close();


                        }
                        catch
                        {
                            // can't connect to sql local, we should show message here
                           // ShowAlertMessage(" عفوا لم يتم الإتصال بقاعدة البيانات الداخلية");

                            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('عفوا لم يتم الإتصال بقاعدة البيانات الداخلية');", true);

                        }
                    }

                    txtFileName.Text =
                    hidden_Inbox_OutBox_File_ID.Value = "";
                }

                else
                {
                    cmd.CommandText = " insert into Inbox_OutBox_Files ( Inbox_Outbox_ID, Inbox_Or_Outbox, Original_Or_Attached, File_data,File_name, File_ext) VALUES ( @Inbox_Outbox_ID, @Inbox_Or_Outbox, @Original_Or_Attached, @File_data, @File_name, @File_ext) select @@identity";

                    if (string.IsNullOrEmpty(Session_CS.local_connectionstring))
                    {
                        cmd.Connection = con;
                        cmd.Parameters["@File_data"].Value = Input;
                        cmd.Parameters["@Inbox_Outbox_ID"].Value = CDataConverter.ConvertToInt(hidden_Id.Value);
                        con.Open();
                        cmd.ExecuteScalar();
                        con.Close();

                    }
                    else
                    {

                        cmd.Connection = con;
                        cmd.Parameters["@File_data"].Value = DBNull.Value;
                        cmd.Parameters["@Inbox_Outbox_ID"].Value = CDataConverter.ConvertToInt(hidden_Id.Value);
                        con.Open();
                        out_box = CDataConverter.ConvertToInt(cmd.ExecuteScalar());
                        con.Close();
                        try
                        {
                            cmd.CommandText = " insert into Inbox_OutBox_Files ( Inbox_OutBox_File_ID,Inbox_Outbox_ID, Inbox_Or_Outbox, Original_Or_Attached, File_data,File_name, File_ext) VALUES ( @Inbox_OutBox_File_ID,@Inbox_Outbox_ID, @Inbox_Or_Outbox, @Original_Or_Attached, @File_data, @File_name, @File_ext) select @@identity";
                            cmd.Connection = con_local;
                            cmd.Parameters["@File_data"].Value = Input;
                            cmd.Parameters["@Inbox_OutBox_File_ID"].Value = out_box;
                            con_local.Open();
                            cmd.ExecuteScalar();
                            con_local.Close();


                        }
                        catch
                        {
                            // can't connect to sql local, we should show message here

                           // ShowAlertMessage(" عفوا لم يتم الإتصال بقاعدة البيانات الداخلية");

                            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('عفوا لم يتم الإتصال بقاعدة البيانات الداخلية');", true);

                        }
                    }



                    txtFileName.Text =
                    hidden_Inbox_OutBox_File_ID.Value = "";
                }


            }

            // Clear_Cntrl();
            Fil_Grid_Documents();
        }
        else
        {
            //Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('يجب إدخال بيانات الخطاب أولا')</script>");

            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('يجب إدخال بيانات الخطاب أولا');", true);


        }

    }
    protected void btn_Visa_Click(object sender, EventArgs e)
    {
        DataTable dt_mng_sent = General_Helping.GetDataTable("select * from Outbox_Track_Manager where Outbox_id = " + CDataConverter.ConvertToInt(hidden_Id.Value));
        if (dt_mng_sent.Rows.Count > 0)
        {
            if (CDataConverter.ConvertToInt(hidden_Id.Value) > 0)
            {
                if (lst_emp.Items.Count > 0)
                {
                    Outbox_Visa_DT obj = new Outbox_Visa_DT();
                    obj.Visa_Id = CDataConverter.ConvertToInt(hidden_Visa_Id.Value);
                    obj.Outbox_ID = CDataConverter.ConvertToInt(hidden_Id.Value);
                    obj.Visa_date = txt_Visa_date.Text;
                    obj.Important_Degree = CDataConverter.ConvertToInt(ddl_Important_Degree.SelectedValue);
                    obj.Important_Degree_Txt = txt_Important_Degree_Txt.Text;
                    if (string.IsNullOrEmpty(obj.Important_Degree_Txt))
                        obj.Important_Degree_Txt = ddl_Important_Degree.SelectedItem.Text;

                    obj.Dept_ID = CDataConverter.ConvertToInt(Smrt_Srch_structure.SelectedValue);
                    obj.Dept_ID_Txt = Smrt_Srch_structure.SelectedText;
                    if (string.IsNullOrEmpty(obj.Dept_ID_Txt))
                        obj.Dept_ID_Txt = Smrt_Srch_structure.SelectedText;

                    obj.Emp_ID = 0;
                    obj.Emp_ID_Txt = txt_Emp_ID_Txt.Text;
                    //if (string.IsNullOrEmpty(obj.Emp_ID_Txt))
                    //    obj.Emp_ID_Txt = Smart_Visa_Emp.SelectedText;

                    obj.Visa_Desc = txt_Visa_Desc.Text;
                    obj.Visa_Period = txt_Visa_Period.Text;
                    obj.Visa_Satus = CDataConverter.ConvertToInt(ddl_Visa_Satus.SelectedValue);
                    //obj.Follow_Up_Dept_ID = CDataConverter.ConvertToInt(ddl_Follow_Up_Dept_ID.SelectedValue);
                    //obj.Follow_Up_Emp_ID = CDataConverter.ConvertToInt(Smart_Follow_Up_Emp_ID.SelectedValue);
                    obj.Follow_Up_Notes = txt_Follow_Up_Notes.Text;
                    obj.saving_file = txt_saving_file.Text;
                    obj.Dead_Line_DT = txt_Dead_Line_DT.Text;
                    obj.Visa_Goal_ID = CDataConverter.ConvertToInt(ddl_Visa_Goal_ID.SelectedValue);
                    obj.mail_sent = 0;


                    obj.Visa_Id = Outbox_Visa_DB.Save(obj);

                    Save_inox_Visa(obj);
                    Clear_Visa_Cntrl();
                    Fil_Grid_Visa();
                    fil_emp_Folow_Up();
                    Fil_Emp_Visa_Follow();
                    ///////////////////////// update have visa = 1/////////////////////////////////////////////

                    Update_Have_Visa_all_emp(obj.Outbox_ID);
                    lst_emp.Items.Clear();
                }
                else
                {
                  //  Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لا يوجد أسماء في القائمة اليسري')</script>");

                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('لا يوجد أسماء في القائمة اليسري');", true);

                }



            }
            else
            {
              //  Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('يجب إدخال بيانات الخطاب أولا')</script>");
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('يجب إدخال بيانات الخطاب أولا');", true);



            }
        }
        else
        {
          //  Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('يجب إرسال الخطاب للمدير المختص أولا ')</script>");

            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('يجب إرسال الخطاب للمدير المختص أولا');", true);

        }


    }
    public void fill_listbox()
    {
        foreach (ListItem item in chklst_Visa_Emp_All.Items)
        {
            if (item.Selected && lst_emp.Items.FindByValue(item.Value) == null)
            {
                ListItem obj = new ListItem(item.Text, item.Value);
                lst_emp.Items.Add(obj);
                item.Selected = false;
            }
            //foreach (ListItem item2 in lst_emp.Items)
            //{
            //    if (item2.Value == item.Value)
            //    {
            //        Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('احد الموظفين المختارين موجود من قبل')</script>");
            //        return;
            //    }

            //}

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


    private void Update_Have_Visa(string Visa_Id)
    {
        string Sql_Visa_Sent = "select Visa_Id from Outbox_Visa where mail_sent = 1 and Visa_Id !=" + Visa_Id + " and Outbox_id = " + hidden_Id.Value;
        int Visa_Sent_Count = General_Helping.GetDataTable(Sql_Visa_Sent).Rows.Count;
        if (Visa_Sent_Count == GridView_Visa.Rows.Count - 1)
        {
            DataTable DT = General_Helping.GetDataTable("select * from Outbox_Track_Manager where Outbox_id = " + hidden_Id.Value);
            if (DT.Rows.Count > 0)
            {
                string sql = "update Outbox_Track_Manager set Have_visa=0 , All_visa_sent=1 where Outbox_id =" + hidden_Id.Value;
                General_Helping.ExcuteQuery(sql);
            }
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
            Outbox_Visa_DT obj = Outbox_Visa_DB.SelectByID(CDataConverter.ConvertToInt(visa_id));
            obj.mail_sent = 1;
            Outbox_Visa_DB.Save(obj);


        }

        return message;


        //      if (!string.IsNullOrEmpty(Failed_name))
        //        Page.RegisterStartupScript("Sucess", "<script language=javascript>alert(' لم يتم ارسال الايميل إلي " + Failed_name + "')</script>");

    }
    protected void btn_add_Click(object sender, EventArgs e)
    {

        fill_listbox();
        TabPanel_All.ActiveTab = TabPanel_Visa;
    }
    protected void btn_delete_Click(object sender, EventArgs e)
    {
        if (lst_emp.SelectedValue == "")
        {
           // Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('يجب اختيار موظف ليتم الحذف')</script>");


            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('يجب اختيار موظف ليتم الحذف');", true);

        }
        else
        {
            lst_emp.Items.Remove(lst_emp.SelectedItem);


        }
        TabPanel_All.ActiveTab = TabPanel_Visa;

    }
    private void Update_Have_Visa_all_emp(int outbox_ID)
    {
        string sql = "update Outbox_Track_Manager set status=0,Have_Follow=0,Have_visa=1 , ";
        sql += "Visa_Desc = '" + txt_Visa_Desc.Text + "'";
        sql += " where Outbox_id =" + outbox_ID;
        General_Helping.ExcuteQuery(sql);

        string sql_all_User = "update Outbox_Track_Emp set Outbox_Status =2 where Outbox_id=" + outbox_ID;
        General_Helping.ExcuteQuery(sql_all_User);
    }
    private void Fil_Grid_Visa()
    {
        DataTable DT = new DataTable();
        DT = General_Helping.GetDataTable("select * from Outbox_Visa where Outbox_ID=" + hidden_Id.Value);

        GridView_Visa.DataSource = DT;
        GridView_Visa.DataBind();

    }
    protected void radlst_Type_SelectedIndexChanged(object sender, EventArgs e)
    {
        fill_resp_Emp();

    }

    private void fill_resp_Emp()
    {
        tr_emp_list.Visible = true;
        string sql, sql_emp = "";

        if (radlst_Type.SelectedValue == "1")
        {
            sql_emp = " select * from pmp_fav_View where pmp_fav_View.employee_id = " + CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
            if (Smrt_Srch_structure.SelectedValue != "")
            {
                sql_emp += " AND Dept_Dept_id = " + Smrt_Srch_structure.SelectedValue;
                // sql_emp += "  and  sec_sec_id=" + CDataConverter.ConvertToInt("0");
            }
            //if (ddl_sectors2.SelectedValue != "" && ddl_sectors2.SelectedValue != "0")
            //{
            //    sql_emp += "  and  sec_sec_id=" + ddl_sectors2.SelectedValue;
            //}



        }
        else if (radlst_Type.SelectedValue == "2")
        {
            // sql_emp = " select * from employee where dbo.EMPLOYEE.workstatus = 1";


            sql_emp = "SELECT     EMPLOYEE.*,Departments.* FROM Departments  INNER JOIN EMPLOYEE ON Departments.Dept_id = EMPLOYEE.Dept_Dept_id where  EMPLOYEE.PMP_ID not in(select parent_pmp_id from dbo.parent_employee) and dbo.EMPLOYEE.workstatus = 1 and EMPLOYEE.foundation_id='" + Session_CS.foundation_id + "'";

            if (Smrt_Srch_structure.SelectedValue != "")
            {
                sql_emp += " and Dept_Dept_id = " + Smrt_Srch_structure.SelectedValue;
                // sql_emp += "  and  sec_sec_id=" + CDataConverter.ConvertToInt("0");
            }
            //if (ddl_sectors2.SelectedValue != "" && ddl_sectors2.SelectedValue != "0")
            //{
            //    sql_emp += "and  Sectors.Sec_id=" + ddl_sectors2.SelectedValue;
            //}

        }
        else if (radlst_Type.SelectedValue == "3")
        {
            // sql_emp = " select * from employee where rol_rol_id=3  and dbo.EMPLOYEE.workstatus = 1";

            sql_emp = "SELECT     EMPLOYEE.*,Departments.* FROM Departments  INNER JOIN EMPLOYEE ON Departments.Dept_id = EMPLOYEE.Dept_Dept_id where dbo.EMPLOYEE.workstatus = 1 and rol_rol_id=3 and EMPLOYEE.foundation_id='" + Session_CS.foundation_id + "'";


            if (Smrt_Srch_structure.SelectedValue != "")
            {
                sql_emp += " AND Dept_Dept_id = " + Smrt_Srch_structure.SelectedValue;
                // sql_emp += "  and  sec_sec_id=" + CDataConverter.ConvertToInt("0");
            }

            //if (ddl_sectors2.SelectedValue != "" && ddl_sectors2.SelectedValue != "0")
            //{
            //    sql_emp += "and  Sectors.Sec_id=" + ddl_sectors2.SelectedValue;
            //}

        }
        else if (radlst_Type.SelectedValue == "4")
        {
            // sql_emp = " select * from employee where contact_person=1 and dbo.EMPLOYEE.workstatus = 1 ";

            sql_emp = "SELECT     EMPLOYEE.*,  Sectors.*,Departments.* FROM Departments INNER JOIN Sectors ON Departments.Sec_sec_id = Sectors.Sec_id INNER JOIN EMPLOYEE ON Departments.Dept_id = EMPLOYEE.Dept_Dept_id where dbo.EMPLOYEE.workstatus = 1 and contact_person=1 and EMPLOYEE.foundation_id='" + Session_CS.foundation_id + "'";

            if (Smrt_Srch_structure.SelectedValue != "")
            {
                sql_emp += " AND Dept_Dept_id = " + Smrt_Srch_structure.SelectedValue;
                //sql_emp += "  and  sec_sec_id=" + CDataConverter.ConvertToInt("0");
            }

            //if (ddl_sectors2.SelectedValue != "" && ddl_sectors2.SelectedValue != "0")
            //{
            //    sql_emp += "and  Sectors.Sec_id=" + ddl_sectors2.SelectedValue;
            //}

        }

        else if (radlst_Type.SelectedValue == "5")
        {
            sql_emp = "  select EMPLOYEE.pmp_name + ' - رئيس ' + +' '+ Commitee.Commitee_Title as pmp_name ,EMPLOYEE.PMP_ID from EMPLOYEE inner join commitee_presidents on  EMPLOYEE.PMP_ID=commitee_presidents.pmp_id inner join Commitee on commitee_presidents.comt_id = Commitee.ID where  Commitee.foundation_id='" + Session_CS.foundation_id + "'";

        }

        else if (radlst_Type.SelectedValue == "6")
        {

            sql_emp = "select EMPLOYEE.pmp_name COLLATE DATABASE_DEFAULT  + ' -  ' + Departments.Dept_name  as pmp_name,EMPLOYEE.PMP_ID from EMPLOYEE inner join commitee_presidents on  EMPLOYEE.PMP_ID=commitee_presidents.pmp_id inner join Departments on  commitee_presidents.dept_id = Departments.Dept_id   inner join Sectors  on Sectors.Sec_id = Departments.Sec_sec_id where Sectors.foundation_id='" + Session_CS.foundation_id + "'";
        }

        sql_emp += " ORDER BY LTRIM(pmp_name)";
        TabPanel_All.ActiveTab = TabPanel_Visa;
        DataTable dt_emp_fav = General_Helping.GetDataTable(sql_emp);
        chklst_Visa_Emp_All.DataSource = dt_emp_fav;
        chklst_Visa_Emp_All.DataBind();
    }
    private void Save_trackmanager(int id)
    {
        DataTable dt = General_Helping.GetDataTable("select * from parent_employee where Type=2 ");
        if (dt.Rows.Count > 0)
        {

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                foreach (ListItem item in lst_emp.Items)
                {
                    if (CDataConverter.ConvertToInt(item.Value) == CDataConverter.ConvertToInt(dt.Rows[i]["parent_pmp_id"].ToString()))
                    {
                        Outbox_Track_Manager_DT obj = new Outbox_Track_Manager_DT();
                        obj.Outbox_id = CDataConverter.ConvertToInt(hidden_Id.Value);
                        obj.Have_Visa = 0;
                        obj.Have_Follow = 0;
                        obj.IS_New_Mail = 1;
                        obj.status = 1;
                        obj.IS_Old_Mail = 0;
                        obj.Visa_Desc = "";
                        obj.Type_Track = 1;
                        obj.pmp_id = int.Parse(Session_CS.pmp_id.ToString());
                        obj.parent_pmp_id = CDataConverter.ConvertToInt(item.Value);
                        //obj.parent_pmp_id = CDataConverter.ConvertToInt(Session_CS.parent_id.ToString());
                        obj.All_visa_sent = 0;
                        obj.Outbox_id = Outbox_Track_Manager_DB.Save(obj);
                    }

                }
            }


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
            Outbox_Visa_DB.Delete(CDataConverter.ConvertToInt(e.CommandArgument));
           // Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم الحذف بنجاح')</script>");

            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('لقد تم الحذف بنجاح');", true);

            Fil_Grid_Visa();
            Fil_Emp_Visa_Follow();
        }
        if (e.CommandName == "SendItem")
        {
            Save_trackmanager(CDataConverter.ConvertToInt(hidden_Id.Value));
            ////////////////////////////////////////////////////////////////////////////////////////////
            /////////////////// Sending Mail Code /////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////
            string dept = Session_CS.dept.ToString();
            string name = "";
            string Succ_names = "", Failed_name = "";
            DataTable dt_outbox_Visa = General_Helping.GetDataTable("select * from Outbox_Visa_Emp where Visa_Id =" + e.CommandArgument.ToString());
            foreach (DataRow item in dt_outbox_Visa.Rows)
            {
                Outbox_DB.update_Outbox_Track_Emp(hidden_Id.Value, item["Emp_ID"].ToString(), 1, 1);
                string sqlformail = "SELECT * from employee ";
                sqlformail += " where pmp_id= " + item["Emp_ID"].ToString();
                DataTable ds = General_Helping.GetDataTable(sqlformail);

                //DataTable DT = General_Helping.GetDataTable(sqlformail);
                string mail = ds.Rows[0]["mail"].ToString();

                name = ds.Rows[0]["pmp_name"].ToString();


                MailMessage _Message = new MailMessage();
                string str_subj = "";
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

                    _Message.Subject = ("OUTIR" + " - " + str_subj + " - " + txt_Date.Text).ToString();
                }
                else
                {

                    _Message.Subject = "نظام الادارة الالكترونية - المراسلات" + " - " + str_subj + " - " + txt_Date.Text;
                }


                //_Message.BodyEncoding = Encoding.Unicode;
                _Message.BodyEncoding = Encoding.UTF8;
                _Message.SubjectEncoding = Encoding.UTF8;



                bool flag = false;
                string file = "";
                byte[] files = new byte[0];
                MemoryStream ms = new MemoryStream();
                DataTable dt = General_Helping.GetDataTable("select * from Inbox_OutBox_Files where Inbox_Outbox_ID =" + hidden_Id.Value + " and Inbox_Or_Outbox =2 ");
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

                //else
                //{
                //    _Message.Body = " السيد " + name + " \n\n";
                //    _Message.Body += " وصلكم صادر من " + dept + " " + " بتاريخ " + txt_Visa_date.Text;
                //}
                String encrypted_id = Encryption.Encrypt(hidden_Id.Value);
                string address2 = System.Web.HttpContext.Current.Request.Url.Authority.ToString();
                _Message.IsBodyHtml = true;
                _Message.Body = "<html><body dir='rtl'><h3 > السيد - " + name + " </h3>";
                _Message.Body += " <h3 > " + " وصلكم صادر من " + dept + " بتاريخ " + txt_Date.Text + " بخصوص  <br/>" + "<h3 style=" + "color:blue >" + txt_Subject.Text + "</h3>" + " </h3>";
                _Message.Body += " <h3 > " + "  وتأشيرة  السيد المدير المختص أن :" + "<h3 style=" + "color:blue >" + txt_Visa_Desc.Text + "</h3>" + " </h3>";

                _Message.Body += " <h3 > ورابط الوارد هو  :<br/>";
                _Message.Body += " <h3 >http:" + "/" + "/" + address2 + "/MainForm/ViewProjectOutbox.aspx?id=" + encrypted_id + "&1=1 </h3>";

                if (flag)
                    _Message.Body += "<h3 >  " + " ومرفق الوثائق الخاصة بهذا الصادر</h3> ";

                ////////http://localhost:4665/Projects_Management/WebForms2/ViewProjectInbox.aspx?id=5458


                _Message.Body += "<h3 > مع تحيات </h3> ";
                _Message.Body += "<h3 >   " + Session_CS.e_signature.ToString() + "  </h3> ";
                _Message.Body += "</body></html>";

                //////





                /////////////////////// update have visa = 0/////////////////////////////////////////////
                Update_Have_Visa(e.CommandArgument.ToString());

                ////SmtpClient config
                //SmtpClient Client = new SmtpClient();
                //Client.Port = int.Parse(ConfigurationManager.AppSettings["SMTP_Port"]);
                //Client.Host = ConfigurationManager.AppSettings["SMTP_Host"];
                //string UserName = ConfigurationManager.AppSettings["SMTP_UserName"];
                //string Password = ConfigurationManager.AppSettings["SMTP_Password"];
                //_Message.From = new MailAddress(ConfigurationManager.AppSettings["SMTP_FromAddress"]);

                ////_Message.Attachments.Add(new Attachment("D:\\Attached.pdf"));
                //System.Net.NetworkCredential SMTPUserInfo = new System.Net.NetworkCredential(UserName, Password);

                //Client.UseDefaultCredentials = false;
                //Client.Credentials = SMTPUserInfo;
                //Client.Timeout = 1000000000;
                try
                {
                    //_Message.To.Add(new MailAddress(mail));
                    //Client.Send(_Message);
                    SendingMailthread_class.Sendingmail(_Message, _Message.Subject, _Message.Body, mail, ms, file, encrypted_id, "");

                    Succ_names += name + ",";


                }
                catch (Exception ex)
                {
                    Failed_name += name + ",";

                    //Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لم يتم ارسال الايميل بنجاح' )</script>");

                }
            }
            string message = Show_Alert(Succ_names, Failed_name, e.CommandArgument.ToString());
            if (!string.IsNullOrEmpty(message))
            {
                Fil_Grid_Visa();
                ///////////////  to store that mohammed eid send visa to employee
                Outbox_Visa_Follows_DT obj_follow = Outbox_Visa_Follows_DB.SelectByID(CDataConverter.ConvertToInt(hidden_Follow_ID.Value));
                obj_follow.Follow_ID = CDataConverter.ConvertToInt(hidden_Follow_ID.Value);
                obj_follow.Outbox_ID = CDataConverter.ConvertToInt(hidden_Id.Value);

                obj_follow.Descrption = message + " بواسطة النظام -- ";
                string date = CDataConverter.ConvertDateTimeToFormatdmy(CDataConverter.ConvertDateTimeNowRtnDt());
                obj_follow.Date = date;
                obj_follow.time_follow = CDataConverter.ConvertDateTimeNowRtnDt().ToLocalTime().ToLongTimeString();
                obj_follow.entery_pmp_id = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());

                obj_follow.Visa_Emp_id = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
                obj_follow.Follow_ID = Outbox_Visa_Follows_DB.Save(obj_follow);
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
             //   Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('" + message + "')</script>");

                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('"+message+"');", true);

            }
            //Page.RegisterStartupScript("Sucess", "<script language=javascript>alert(' لقد تم ارسال الايميل بنجاح إلي " +allnames+"')</script>");
        }
    }
    private void Fil_Visa_Lstbox(int ID)
    {
        string sql = "SELECT dbo.EMPLOYEE.pmp_name, dbo.Outbox_Visa_Emp.Emp_ID, dbo.Outbox_Visa_Emp.Visa_Id FROM  dbo.EMPLOYEE INNER JOIN dbo.Outbox_Visa_Emp ON dbo.EMPLOYEE.PMP_ID = dbo.Outbox_Visa_Emp.Emp_ID where dbo.Outbox_Visa_Emp.Visa_Id = " + ID;
        DataTable dt = General_Helping.GetDataTable(sql);
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            ListItem obj = new ListItem(dt.Rows[i]["pmp_name"].ToString(), dt.Rows[i]["Emp_ID"].ToString());
            lst_emp.Items.Add(obj);


        }

    }
    protected void chk_ALL_CheckedChanged(object sender, EventArgs e)
    {
        foreach (ListItem item in chklst_Visa_Emp_All.Items)
        {
            item.Selected = chk_ALL.Checked;
        }
        TabPanel_All.ActiveTab = TabPanel_Visa;
    }
    private void Fil_Visa_Lst(int ID)
    {
        string Sql_Delete = "select * from Outbox_Visa_Emp where Visa_Id =" + ID;
        DataTable DT = General_Helping.GetDataTable(Sql_Delete);
        foreach (DataRow dr in DT.Rows)
        {
            string Value = dr["Emp_ID"].ToString();
            ListItem item = chklst_Visa_Emp.Items.FindByValue(Value);
            if (item != null)
                item.Selected = true;
        }


    }
    protected void btn_Visa_Follow_Click(object sender, EventArgs e)
    {
        if (CDataConverter.ConvertToDate(txt_Follow_Date.Text) >= CDataConverter.ConvertToDate(txt_Date.Text))
        {
            if (CDataConverter.ConvertToInt(hidden_Id.Value) > 0)
            {
                Outbox_Visa_Follows_DT obj = Outbox_Visa_Follows_DB.SelectByID(CDataConverter.ConvertToInt(hidden_Follow_ID.Value));
                obj.Follow_ID = CDataConverter.ConvertToInt(hidden_Follow_ID.Value);
                obj.Outbox_ID = CDataConverter.ConvertToInt(hidden_Id.Value);
                obj.Descrption = txt_Descrption.Text;
                obj.Date = txt_Follow_Date.Text;
                obj.time_follow = CDataConverter.ConvertDateTimeNowRtnDt().ToLocalTime().ToLongTimeString();
                obj.entery_pmp_id = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
                obj.Visa_Emp_id = CDataConverter.ConvertToInt(ddl_Visa_Emp_id.SelectedValue);
                obj.Type_Follow = 1;
                obj.Follow_ID = Outbox_Visa_Follows_DB.Save(obj);

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


                    SqlCommand cmd = new SqlCommand();
                    SqlConnection con = new SqlConnection();
                    SqlCommand cmd_local = new SqlCommand();
                    SqlConnection con_local = new SqlConnection();
                    con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                    con_local = new SqlConnection(Session_CS.local_connectionstring);
                    cmd.Parameters.Add("@File_data", SqlDbType.VarBinary);
                    cmd.Parameters.Add("@File_name", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@File_ext", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@Follow_ID", SqlDbType.BigInt);

                    //cmd.Parameters["@File_data"].Value = Input;
                    cmd.Parameters["@File_name"].Value = DocName;
                    cmd.Parameters["@File_ext"].Value = type;
                    cmd.Parameters["@Follow_ID"].Value = obj.Follow_ID;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = " update Outbox_Visa_Follows set File_data =@File_data ,File_name=@File_name,File_ext=@File_ext where Follow_ID =@Follow_ID";


                    if (string.IsNullOrEmpty(Session_CS.local_connectionstring))
                    {
                        cmd.Connection = con;
                        cmd.Parameters["@File_data"].Value = Input;
                        con.Open();
                        cmd.ExecuteScalar();
                        con.Close();

                    }
                    else
                    {

                        cmd.Connection = con;
                        cmd.Parameters["@File_data"].Value = DBNull.Value;
                        con.Open();
                        cmd.ExecuteScalar();
                        con.Close();
                        try
                        {
                            cmd.Connection = con_local;
                            cmd.Parameters["@File_data"].Value = Input;

                            con_local.Open();
                            cmd.ExecuteScalar();
                            con_local.Close();


                        }
                        catch
                        {
                            // can't connect to sql local, we should show message here

                         //   ShowAlertMessage("   عفوا لم يتم الإتصال بقاعدة البيانات الداخلية");

                            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('عفوا لم يتم الإتصال بقاعدة البيانات الداخلية');", true);

                        }
                    }



                }
                ///////////// change have follow = 1/////////////////////////////////////////////

                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                DataTable DT = new DataTable();
                DT = General_Helping.GetDataTable("select * from Outbox_Track_Manager where Outbox_id = " + hidden_Id.Value);
                if (DT.Rows.Count > 0)
                {
                    conn.Open();
                    string sql = "update Outbox_Track_Manager set Have_Follow=1 where Outbox_id =" + hidden_Id.Value;
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();

                }


                Clear_visa_Follow();

                Fil_Grid_Visa_Follow();
            }
            else
            {
                //Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('يجب إدخال بيانات الخطاب أولا')</script>");

                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('يجب إدخال بيانات الخطاب أولا');", true);


            }

        }
        else
        {

            //Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('تاريخ المتابعة يجب أن يكون أكبر من أو يساوي تاريخ الخطاب')</script>");

            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('تاريخ المتابعة يجب أن يكون أكبر من أو يساوي تاريخ الخطاب');", true);

        }

    }
    private void Clear_visa_Follow()
    {
        hidden_Follow_ID.Value =
        txt_Descrption.Text =
        txt_Follow_Date.Text = "";
        ddl_Visa_Emp_id.SelectedIndex = 0;
    }
    private void Fil_Visa_Control(int ID)
    {
        Outbox_Visa_DT obj = Outbox_Visa_DB.SelectByID(ID);
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
                    Smrt_Srch_structure.SelectedValue = obj.Dept_ID.ToString();
                else
                {
                    Smrt_Srch_structure.Clear_Selected();
                    //txt_Dept_ID_Txt.Text = obj.Dept_ID_Txt;
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
                txt_Visa_Period.Text = obj.Visa_Period;
                txt_saving_file.Text = obj.saving_file;
                ddl_Visa_Satus.SelectedValue = obj.Visa_Satus.ToString();
                //ddl_Follow_Up_Dept_ID.SelectedValue = obj.Follow_Up_Dept_ID.ToString();
                fil_emp_Folow_Up();
                //Smart_Follow_Up_Emp_ID.SelectedValue = obj.Follow_Up_Emp_ID.ToString();
                txt_Follow_Up_Notes.Text = obj.Follow_Up_Notes;
                txt_Dead_Line_DT.Text = obj.Dead_Line_DT;
                ddl_Visa_Goal_ID.SelectedValue = obj.Visa_Goal_ID.ToString();

            }
            catch
            { }
        }



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
    private void Clear_Visa_Cntrl()
    {
        hidden_Visa_Id.Value = "";
        chk_ALL.Checked = false;

        //  Smart_Visa_Emp.Clear_Controls();
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

            Outbox_Visa_Follows_DT obj_follow = Outbox_Visa_Follows_DB.SelectByID(CDataConverter.ConvertToInt(hidden_Follow_ID.Value));
            obj_follow.Follow_ID = 0;
            obj_follow.Outbox_ID = CDataConverter.ConvertToInt(hidden_Id.Value);

            obj_follow.Descrption = " تم انهاء التاشيرة " + lbl_desc.Text + " بواسطة  " + Session_CS.pmp_name.ToString();
            string date = CDataConverter.ConvertDateTimeToFormatdmy(CDataConverter.ConvertDateTimeNowRtnDt());
            obj_follow.Date = date;
            obj_follow.time_follow = CDataConverter.ConvertDateTimeNowRtnDt().ToLocalTime().ToLongTimeString();
            obj_follow.entery_pmp_id = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());

            obj_follow.Visa_Emp_id = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
            obj_follow.Follow_ID = Outbox_Visa_Follows_DB.Save(obj_follow);
            Outbox_Visa_DT obj = Outbox_Visa_DB.SelectByID(CDataConverter.ConvertToInt(Id));
            obj.mail_sent = 1;
            Outbox_Visa_DB.Save(obj);
            Update_Have_Visa(Id);

            Fil_Grid_Visa_Follow();




        }
        Fil_Grid_Visa();
        TabPanel_All.ActiveTab = TabPanel_Visa;

    }
    protected void GridView_Visa_rw_data_bound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string temp_sql = "";
            DataTable Dt;
            string id = (string)Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Visa_Id"));
            temp_sql = "select mail_sent from Outbox_Visa where Visa_Id=" + id;
            Dt = General_Helping.GetDataTable(temp_sql);
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
    private void Save_inox_Visa(Outbox_Visa_DT obj)
    {

        string Sql_Delete = "delete from Outbox_Visa_Emp where Visa_Id =" + obj.Visa_Id;
        General_Helping.ExcuteQuery(Sql_Delete);
        string Sql_insert = "";


        foreach (ListItem item in lst_emp.Items)
        {

            DataTable dt = General_Helping.GetDataTable("select * from parent_employee where pmp_id = " + CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()));
            if (dt.Rows.Count > 0)
            {

                // Sql_insert = "insert into outbox_Visa_Emp ( Visa_Id , Emp_ID ,Sender_id) values ( " + obj.Visa_Id + "," + item.Value + "," + CDataConverter.ConvertToInt(dt.Rows[0]["parent_pmp_id"].ToString()) + ")";
                Outbox_DB.Outbox_visa_emp_save(CDataConverter.ConvertToInt(obj.Visa_Id), CDataConverter.ConvertToInt(item.Value), CDataConverter.ConvertToInt(dt.Rows[0]["parent_pmp_id"].ToString()));
            }
            else
            {

                // Sql_insert = "insert into outbox_Visa_Emp ( Visa_Id , Emp_ID ,Sender_id) values ( " + obj.Visa_Id + "," + item.Value + "," + CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()) + ")";
                Outbox_DB.Outbox_visa_emp_save(CDataConverter.ConvertToInt(obj.Visa_Id), CDataConverter.ConvertToInt(item.Value), CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()));
            }


            //General_Helping.ExcuteQuery(Sql_insert);

            //item.Selected = false;


        }




    }

    protected void GrdView_Documents_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditItem")
        {
            Inbox_OutBox_Files_DT obj = Inbox_OutBox_Files_DB.SelectByID(CDataConverter.ConvertToInt(e.CommandArgument));
            if (obj.Inbox_OutBox_File_ID > 0)
            {
                hidden_Inbox_OutBox_File_ID.Value = obj.Inbox_OutBox_File_ID.ToString();
                txtFileName.Text = obj.File_name;
                ddl_Original_Or_Attached.SelectedValue = obj.Original_Or_Attached.ToString();
            }

        }

        if (e.CommandName == "RemoveItem")
        {
            Inbox_OutBox_Files_DB.Delete(CDataConverter.ConvertToInt(e.CommandArgument));
            //Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم الحذف بنجاح')</script>");

            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('لقد تم الحذف بنجاح');", true);

            Fil_Grid_Documents();
        }
    }

    private void Fil_Grid_Documents()
    {
        DataTable DT = new DataTable();
        DT = General_Helping.GetDataTable("select * from Inbox_OutBox_Files where Inbox_Or_Outbox = 2 and  Inbox_Outbox_ID=" + hidden_Id.Value);

        GrdView_Documents.DataSource = DT;
        GrdView_Documents.DataBind();
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

    protected void Chk_main_cat_SelectedIndexChanged(object sender, EventArgs e)
    {
        Chk_sub_cat.Visible = true;
        DataTable dt;
        ListItem obj;
        foreach (ListItem item in Chk_main_cat.Items)
        {
            if (item.Selected)
            {
                dt = General_Helping.GetDataTable(" select * from inbox_Sub_Categories where main_id = " + item.Value);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    obj = new ListItem(dt.Rows[i]["name"].ToString(), dt.Rows[i]["id"].ToString());
                    //lst_emp.Items.Add(obj);
                    if (Chk_sub_cat.Items.FindByValue(obj.Value) == null)
                    {
                        Chk_sub_cat.Items.Add(obj);
                    }


                }
            }
            else
            {
                dt = General_Helping.GetDataTable(" select * from inbox_Sub_Categories where main_id = " + item.Value);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    obj = new ListItem(dt.Rows[i]["name"].ToString(), dt.Rows[i]["id"].ToString());
                    //lst_emp.Items.Add(obj);


                    Chk_sub_cat.Items.Remove(obj);



                }
            }

            //item.Selected = Chk_ALL_cat.Checked;
        }

        TabPanel_All.ActiveTab = TabPanel_dtl;
    }
}
