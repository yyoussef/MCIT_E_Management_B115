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


public partial class UserControls_ProjectReview : System.Web.UI.UserControl
{
    private string sql_Connection = Database.ConnectionString;

    General_Helping Obj_General_Helping = new General_Helping();
    int id; Session_CS Session_CS = new Session_CS();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Smart_Search_dept.Show_OrgTree = true;
            fill_structure();
            if (CDataConverter.ConvertToInt(Session_CS.Project_id.ToString()) > 0)
            {
                
                //TabPanel_Visa_Folow.Visible = false;

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
            //tr_old_emp.Visible = false;
            string sql_for_chklist_emp = " select * from pmp_fav_View where pmp_fav_View.employee_id = " + CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()) + " ORDER BY LTRIM(pmp_name)";
            DataTable dt_emp_fav = General_Helping.GetDataTable(sql_for_chklist_emp);
            chklst_Visa_Emp_All.DataSource = dt_emp_fav;
            chklst_Visa_Emp_All.DataBind();
            //string sql2 = " select Group_id from employee where PMP_ID = " +int.Parse( Session_CS.pmp_id.ToString());
            //DataTable DT2 = General_Helping.GetDataTable(sql2);
           // Session_CS.group_id = 3;
           
            TabPanel_All.ActiveTab = TabPanel_dtl;
            //Fil_Dll();
           
            //fill_sub_category();
            //fil_emp_Visa();
            if (Request["id"] != null)
            {
                String decrypted_id = Encryption.Decrypt(Request.QueryString["id"].ToString());
                id = Convert.ToInt16(decrypted_id);
                Fill_Controll(id);
                Fil_Grid_Documents();
               // Fil_Grid_Visa();
               // Fil_chk_main_category(CDataConverter.ConvertToInt(Request["id"]));
               // Fil_Grid_Visa_Follow();
               // Fil_Emp_Visa_Follow();
                //Chk_sub_cat.Visible = true;
                if (CDataConverter.ConvertToInt(Session_CS.group_id.ToString()) == 3)
                {
                    Smart_Search_dept.SelectedValue = "15";
                }

            }
            else
            {
                //DateTime str = System.DateTime.Now;
                DateTime str = CDataConverter.ConvertDateTimeNowRtnDt();

               // DateTime st_deadline_date = System.DateTime.Now.AddDays(7);
                DateTime st_deadline_date = CDataConverter.ConvertDateTimeNowRtnDt().AddDays(7);
                //txt_Dead_Line_DT.Text = st_deadline_date.ToString("dd/MM/yyyy");
               // txt_Visa_date.Text = CDataConverter.ConvertDateTimeNowRtrnString();
                txt_Date.Text = CDataConverter.ConvertDateTimeNowRtrnString();
               // btn_print_report.Enabled = false;

            }

        }
    }

    protected void btnSend_Click(object sender, EventArgs e)
    {
        if (CDataConverter.ConvertToInt(hidden_Id.Value) > 0)
        {
            if (Session_CS.pmp_id != null)
            {
                //// get Parent 
               

                ///////////////  to store that mohammed eid send to dr hesham the mail
               
                ////////////////////////////////////////////////////////////////////////////////////////////
                /////////////////// Sending Mail Code /////////////////////////////////////////
                //////////////////////////////////////////////////////////////////////////////////////////
                //General_Helping.ExcuteQuery("delete  from review_track_emp where review_id = " + hidden_Id.Value);


                string dept = Session_CS.dept.ToString();
                string name = "";
                string Succ_names = "", Failed_name = "";
                DataTable dt_review_emp = General_Helping.GetDataTable("select * from Review_track_Emp where Review_Id =" + hidden_Id.Value);
                foreach (DataRow item in dt_review_emp.Rows)
                {
                    Review_DB.update_Review_Track_Emp(hidden_Id.Value, item["Emp_ID"].ToString(), 2, 1);
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

                        _Message.Subject = ("INIR" + " - " + str_subj + " - " + txt_Date.Text).ToString();
                    }
                    else
                    {

                        _Message.Subject = "نظام الادارة الالكترونية - المراسلات" + " - " + str_subj + " - " + txt_Date.Text;
                    }


                    //_Message.BodyEncoding = Encoding.Unicode;
                    _Message.BodyEncoding = Encoding.UTF8;
                    _Message.SubjectEncoding = Encoding.UTF8;



                    bool flag = false;
                    DataTable dt = General_Helping.GetDataTable("select * from Review_Files where Review_ID =" + hidden_Id.Value);
                    string file = "";
                    MemoryStream ms = new MemoryStream();
                    foreach (DataRow dr in dt.Rows)
                    {

                        if (dr["File_data"] != DBNull.Value)
                        {

                            file = dr["File_name"].ToString() + dr["File_ext"].ToString();
                            byte[] files = (byte[])dr["File_data"];
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
                    string address2 = System.Web.HttpContext.Current.Request.Url.Authority.ToString();
                    String encrypted_id = Encryption.Encrypt(hidden_Id.Value);

                    //  _Message.IsBodyHtml = true;
                    _Message.Body = "<html><body dir='rtl'><h3 > السيد - " + name + " </h3>";
                    _Message.Body += " <h3 > " + " وصلكم نشره من " + dept + " بتاريخ " + txt_Date.Text + " بخصوص  <br/>" + "<h3 style=" + "color:blue >" + txt_Subject.Text + "</h3>" + " </h3>";
                    //_Message.Body += " <h3 > " + "  وتأشيرة  السيد المدير المختص أن :" + "<h3 style=" + "color:blue >" + txt_Visa_Desc.Text + "</h3>" + " </h3>";

                    _Message.Body += " <h3 > ورابط النشرة هو  :<br/>";
                    //_Message.Body += " <h3 >http:" + "/" + "/" + address2 + "/MainForm/ViewProjectInbox.aspx?id=" + hidden_Id.Value + "  &1=1 </h3>";
                    _Message.Body += " <h3 >http:" + "/" + "/" + address2 + "/MainForm/ViewProjectReview.aspx?id=" + encrypted_id + "&1=1 </h3>";

                    if (flag)
                        _Message.Body += "<h3 >  " + " ومرفق الوثائق الخاصة بهذة النشره</h3> ";

                    ////////http://localhost:4665/Projects_Management/WebForms2/ViewProjectInbox.aspx?id=5458


                    _Message.Body += "<h3 > مع تحيات </h3> ";
                    _Message.Body += "<h3 >   " + Session_CS.e_signature.ToString() + "  </h3> ";
                    _Message.Body += "</body></html>";

                    //////





                    /////////////////////// update have visa = 0/////////////////////////////////////////////
                    //Update_Have_Visa(e.CommandArgument.ToString());


                    try
                    {
                        //_Message.To.Add(new MailAddress(mail));
                        SendingMailthread_class.Sendingmail(_Message, _Message.Subject, _Message.Body, mail, ms, file, encrypted_id, "");

                        Succ_names += name + ",";


                    }
                    catch (Exception ex)
                    {
                        Failed_name += name + ",";

                        //Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لم يتم ارسال الايميل بنجاح' )</script>");

                    }
                }
                string message = Show_Alert(Succ_names, Failed_name);
                if (!string.IsNullOrEmpty(message))
                {
                    //Fil_Grid_Visa();

                    Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('" + message + "')</script>");
                }

            }
            else
            {
                Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('يرجي الخروج و الدخول مرة اخري للنظام')</script>");
                return;

            }
            ////// get Parent 
            //string sqlformail = "SELECT parent_pmp_id from parent_employee where pmp_id =  " + int.Parse(Session_CS.pmp_id.ToString());
            //DataTable ds = General_Helping.GetDataTable(sqlformail);
            //int parent_pmp = int.Parse(ds.Rows[0]["parent_pmp_id"].ToString());
            ///////////// change  is_new_mail=1 /////////////////////////////////////////////





            //////////////////// to show mohammed eid in the drop down list of employee in المسير


        }
        else
        {
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('يجب إدخال بيانات الخطاب أولا')</script>");

        }

    }
   
    protected void fill_structure()
    {

        string Query = "";
        Query = "SELECT  * from    Departments  where sec_sec_id='" + Session_CS.sec_id + "'";

        Smart_Search_dept.datatble = General_Helping.GetDataTable(Query);
        Smart_Search_dept.Value_Field = "Dept_id";
        Smart_Search_dept.Text_Field = "Dept_name";
        Smart_Search_dept.DataBind();


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
            Review_DT obj = Review_DB.SelectByID(id);
            hidden_Id.Value = obj.ID.ToString();
            //hidden_Proj_id.Value = obj.Proj_id.ToString();
            //Smart_Search_Proj.SelectedValue = obj.Proj_id.ToString();
            //txt_Name.Text = obj.Name;
            txt_Code.Text = obj.Code;
            txt_Date.Text = obj.Date;
            string sql = "SELECT dbo.EMPLOYEE.pmp_name, dbo.Review_track_emp.Emp_ID FROM  dbo.EMPLOYEE INNER JOIN dbo.Review_track_emp ON dbo.EMPLOYEE.PMP_ID = dbo.Review_track_emp.Emp_ID where dbo.Review_track_emp.Review_id = " + hidden_Id.Value;
            DataTable dt = General_Helping.GetDataTable(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem obj1 = new ListItem(dt.Rows[i]["pmp_name"].ToString(), dt.Rows[i]["Emp_ID"].ToString());
                lst_emp.Items.Add(obj1);


            }

            //ddl_Type.SelectedValue = obj.CatType.ToString();
            //Type_Changed();
            //if (obj.Dept_ID > 0)
            //    //ddl_Dept_ID.SelectedValue = obj.Dept_ID.ToString();
            //    //fil_emp();
            //    if (obj.Emp_ID > 0)
            //        //Smart_Emp_ID.SelectedValue = obj.Emp_ID.ToString();
            //        if (obj.Org_Id > 0)
            //            //Smart_Org_ID.SelectedValue = obj.Org_Id.ToString();
            //            // lbl_Org_Name.Text = obj.Org_Name;
            //            //txt_Org_Out_Box_Code.Text = obj.Org_Out_Box_Code;
            //            //txt_Org_Out_Box_DT.Text = obj.Org_Out_Box_DT;
            //            //txt_Org_Out_Box_Person.Text = obj.Org_Out_Box_Person;
            txt_Subject.Text = obj.Subject;

            //ddl_Related_Type.SelectedValue = obj.Related_Type.ToString();
            //Related_type_Changed();
            //Smart_Related_Id.SelectedValue = obj.Related_Id.ToString();
            txt_Notes.Text = obj.Notes;
            //txt_Paper_No.Text = obj.Paper_No;
            //txt_Paper_Attached.Text = obj.Paper_Attached;
            // ddl_Follow_Up_Dept_ID.SelectedValue = obj.Follow_Up_Dept_ID.ToString();
            //fil_emp_Folow_Up();
            // Smart_Follow_Up_Emp_ID.SelectedValue = obj.Follow_Up_Emp_ID.ToString();
            // txt_Follow_Up_Notes.Text = obj.Follow_Up_Notes;
            //txt_Dept_Desc.Text = obj.Dept_Desc;
            //ddl_Source_Type.SelectedValue = obj.Source_Type.ToString();
            //txt_Org_Dept_Name.Text = obj.Org_Dept_Name;
            //ddlMainCat.SelectedValue = (General_Helping.GetDataTable("select main_id from Inbox_sub_categories where id=" + CDataConverter.ConvertToInt(obj.sub_Cat_id)).Rows[0]["main_id"]).ToString();
            //DataTable DT3 = new DataTable();
            //DT3 = General_Helping.GetDataTable("select * from Inbox_sub_categories where main_id=" + ddlMainCat.SelectedValue);
            //ddlSubCat.DataSource = DT3;
            //ddlSubCat.DataTextField = "name";
            //ddlSubCat.DataValueField = "id";
            //ddlSubCat.DataBind();
            //ddlSubCat.SelectedValue = obj.sub_Cat_id.ToString();

        }
        catch
        { }
    }

    protected void btn_New_Org_Click(object sender, EventArgs e)
    {
        //if (!string.IsNullOrEmpty(txt_New_Org.Text))
        //{
        //    SqlCommand cmd_tbl = new SqlCommand();
        //    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        //    cmd_tbl.Connection = con;
        //    cmd_tbl.CommandType = CommandType.Text;

        //    cmd_tbl.CommandText = " insert into Organization (Org_Desc) VALUES ('" + txt_New_Org.Text + "') select @@identity";
        //    con.Open();
        //    object obj = cmd_tbl.ExecuteScalar();
        //    con.Close();
        //    int id = CDataConverter.ConvertToInt(obj.ToString());
        //    Smart_Org_ID.SelectedValue = id.ToString();

        //}
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        hidden_Id.Value = "";
        txt_Code.Text = "";


      
        //Smart_Org_ID.SelectedValue = "";
        //Smart_Related_Id.SelectedValue = "";
        //Smart_Related_Id.Text_Field = "";
        //txt_Org_Out_Box_Code.Text = "";
        //txt_Org_Out_Box_DT.Text = "";
        //txt_Org_Dept_Name.Text = "";
        //txt_Org_Out_Box_Person.Text = "";
        //txt_Dept_Desc.Text = "";
        txt_Subject.Text = "";
        //txt_Paper_No.Text = "";
        //txt_Paper_Attached.Text = "";
        txt_Notes.Text = "";
        txtFileName.Text = "";
        GrdView_Documents.DataSource = null;
        GrdView_Documents.DataBind();
       // GridView_Visa.DataSource = null;
       // GridView_Visa.DataBind();
        lst_emp.Items.Clear();
        // Session_CS.Project_id = null;

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        //if (true)//(CDataConverter.ConvertToInt(ddl_Type.SelectedValue) == 2 && CDataConverter.ConvertToInt(Smart_Org_ID.SelectedValue) > 0) || CDataConverter.ConvertToInt(ddl_Type.SelectedValue) == 1 || CDataConverter.ConvertToInt(ddl_Type.SelectedValue) == 3)
        //{
        string datenow = "";
        int dept = 0;
        int pmp = 0;
        int group = 0;
        Review_DT obj = new Review_DT();
        obj.ID = CDataConverter.ConvertToInt(hidden_Id.Value);//hidden_Id IS REVIEW ID
     
        obj.Code = txt_Code.Text;
        obj.Date = txt_Date.Text;
        if (obj.ID == 0)
        {
           // datenow = DateTime.Now.ToString();
            datenow =CDataConverter.ConvertDateTimeNowRtrnString();
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
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            con.Open();
            string sql = "select Enter_Date,Dept_Dept_ID,Group_id,pmp_pmp_id from Review where ID = " + obj.ID;
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            datenow = ds.Tables[0].Rows[0]["Enter_Date"].ToString();
            dept = int.Parse(ds.Tables[0].Rows[0]["Dept_Dept_ID"].ToString());
            group = int.Parse(ds.Tables[0].Rows[0]["Group_id"].ToString());
            pmp = int.Parse(ds.Tables[0].Rows[0]["pmp_pmp_id"].ToString());
            obj.Enter_Date = datenow;
            obj.Dept_Dept_ID = dept;
            obj.Group_id = group;
            obj.pmp_pmp_id = pmp;
        }

       
        obj.Subject = txt_Subject.Text;
      
        obj.Notes = txt_Notes.Text;
      
        //////////////////////////// check that the code is not repeated for group=3 ( sahar )
       // string year_now = DateTime.Now.Year.ToString();
        string year_now = CDataConverter.ConvertDateTimeNowRtnDt().Year.ToString();
        string year_inbox_txt = CDataConverter.ConvertToDate(txt_Date.Text).Year.ToString();
        if (CDataConverter.ConvertToInt(Session_CS.group_id.ToString()) == 3)
        {
            DataTable dt_code = General_Helping.GetDataTable("select * from Review where code = '" + txt_Code.Text + "' and group_id = 3");
            if (dt_code.Rows.Count > 0)
            {
                string year_inbox_DB = DateTime.Parse(dt_code.Rows[0]["Date"].ToString()).Year.ToString();
                if (year_inbox_DB == year_inbox_txt)
                {
                    Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('هذا الكود موجود من قبل !!! من فضلك أدخل كودا أخر')</script>");
                    return;
                }

            }

        }

        obj.ID = Review_DB.Save(obj);
       
        ////// save the categories for the inbox
        // Dear Motaz please convert all these query to SP and then put all below code in another function

       

       
       
        hidden_Id.Value = obj.ID.ToString();
        if (Request["id"] != null)
        {
            General_Helping.ExcuteQuery("delete from review_track_emp where review_id= " + hidden_Id.Value);
            if (lst_emp.Items.Count > 0)
            {
                foreach (ListItem item in lst_emp.Items)
                {
                    Review_DB.update_Review_Track_Emp(hidden_Id.Value, item.Value, 1, 1);
                }
            }
        }
        else
        {
            if (lst_emp.Items.Count > 0)
            {
                foreach (ListItem item in lst_emp.Items)
                {
                    Review_DB.update_Review_Track_Emp(hidden_Id.Value, item.Value, 1, 1);
                }
            }
        }
        //Fil_Grid_Visa();

       



        if (obj.ID > 0)
        {
           
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم الحفظ بنجاح')</script>");
           
        }
        else
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لم يتم الحفظ يرجى التأكد من البيانات ')</script>");

        
    }
    public string Get_Visa_Emp(object obj)
    {
        string Review_ID = obj.ToString();
        string emp_name = "";
        DataTable DT = new DataTable();
        DT = General_Helping.GetDataTable("SELECT EMPLOYEE.pmp_name FROM Review_Track_Emp INNER JOIN EMPLOYEE ON Review_Track_Emp.Emp_ID = EMPLOYEE.PMP_ID WHERE Review_Track_Emp.Review_id  =" + Review_ID);
        foreach (DataRow dr in DT.Rows)
        {
            emp_name += dr["pmp_name"].ToString() + ",";
        }
        return emp_name;

    }

    //private void Fil_Dll()
    //{
    //    DataTable DT = new DataTable();
    //    DT = General_Helping.GetDataTable("select * from Departments");
    //    //Obj_General_Helping.SmartBindDDL(ddl_Dept_ID, DT, "Dept_ID", "Dept_name", "....اختر اسم الإدارة ....");
    //    //Obj_General_Helping.SmartBindDDL(ddl_Follow_Up_Dept_ID, DT, "Dept_ID", "Dept_name", "....اختر اسم الإدارة ....");
    //    //Obj_General_Helping.SmartBindDDL(ddl_Visa_Dept_ID, DT, "Dept_ID", "Dept_name", "....اختر اسم الإدارة ....");


    //    //DataTable dt_Org = new DataTable();
    //    //dt_Org = General_Helping.GetDataTable("SELECT [Org_ID], [Org_Desc] FROM [Organization]");
    //    //Obj_General_Helping.SmartBindDDL(ddl_Org_Id, dt_Org, "Org_ID", "Org_Desc", "....اختر اسم الإدارة ....");
    //}

   

    protected override void OnInit(EventArgs e)
    {
        #region BROWSER FOR departments

        //Smart_Org_ID.sql_Connection = sql_Connection;
        //Smart_Org_ID.Query = "SELECT Org_ID, Org_Desc FROM Organization";
        //Smart_Org_ID.Value_Field = "Org_ID";
        //Smart_Org_ID.Text_Field = "Org_Desc";
        //Smart_Org_ID.DataBind();

        ////fil_emp();
        //Smart_Emp_ID.sql_Connection = sql_Connection;
        //Smart_Emp_ID.Query = "SELECT PMP_ID, pmp_name FROM EMPLOYEE ";
        //Smart_Emp_ID.Value_Field = "PMP_ID";
        //Smart_Emp_ID.Text_Field = "pmp_name";
        //Smart_Emp_ID.DataBind();

        //this.Smrt_Srch_DropDep.Value_Handler += new Smart_Search.Delegate_Selected_Value(MOnMember_Data);
        //Inbox_organization.SelectedValue;
        // fill project

        //Smart_Search_Proj.sql_Connection = sql_Connection;
        //Smart_Search_Proj.Query = "SELECT Proj_id, Proj_Title FROM Project ";
        //Smart_Search_Proj.Value_Field = "Proj_id";
        //Smart_Search_Proj.Text_Field = "Proj_Title";
        //Smart_Search_Proj.DataBind();

       // Smart_Search_dept.sql_Connection = sql_Connection;
       //// Smart_Search_dept.Query = "SELECT Dept_id, Dept_name FROM Departments ";
       // string Query = "SELECT Dept_id, Dept_name FROM Departments ";
       // Smart_Search_dept.datatble = General_Helping.GetDataTable(Query);
       // Smart_Search_dept.Value_Field = "Dept_id";
       // Smart_Search_dept.Text_Field = "Dept_name";
       // Smart_Search_dept.DataBind();
       // this.Smart_Search_dept.Value_Handler += new Smart_Search.Delegate_Selected_Value(MOnMember_Data);
        #endregion
        this.Smart_Search_dept.Value_Handler += new Smart_Search.Delegate_Selected_Value(MOnMember_Data);
        Smart_Search_dept.sql_Connection = sql_Connection;
        base.OnInit(e);
    }

    private void MOnMember_Data(string Value)
    {
        dropdept_fun();
    }

    protected void dropdept_fun()
    {
        //SqlConnection conn = new SqlConnection(sql_Connection);


        //fil_emp_Visa();

        string sql, sql_emp = "";

        if (radlst_Type.SelectedValue == "1")
        {
            sql_emp = " select * from pmp_fav_View where pmp_fav_View.employee_id = " + CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
            if (Smart_Search_dept.SelectedValue != "")
            {
                sql_emp += " AND Dept_Dept_id = " + Smart_Search_dept.SelectedValue;
            }

        }
        else if (radlst_Type.SelectedValue == "2")
        {
            ////////// the static number 1178 is not to add the second user of eng.rabea
            sql_emp = " select * from employee where pmp_id <> 1178";
            if (Smart_Search_dept.SelectedValue != "")
            {
                sql_emp += " and Dept_Dept_id = " + Smart_Search_dept.SelectedValue;
            }

        }
        else if (radlst_Type.SelectedValue == "3")
        {
            sql_emp = " select * from employee where rol_rol_id=3 and pmp_id <> 1178  ";
            if (Smart_Search_dept.SelectedValue != "")
            {
                sql_emp += " AND Dept_Dept_id = " + Smart_Search_dept.SelectedValue;
            }

        }
        else if (radlst_Type.SelectedValue == "4")
        {
            sql_emp = " select * from employee where contact_person=1  ";
            if (Smart_Search_dept.SelectedValue != "")
            {
                sql_emp += " AND Dept_Dept_id = " + Smart_Search_dept.SelectedValue;
            }

        }
        sql_emp += " ORDER BY LTRIM(pmp_name)";
       
        DataTable dt_emp_fav = General_Helping.GetDataTable(sql_emp);
        chklst_Visa_Emp_All.DataSource = dt_emp_fav;
        chklst_Visa_Emp_All.DataBind();
       

    }

    //protected void ddl_Type_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    Type_Changed();

    //}

    //private void Type_Changed()
    //{
    //    if (ddl_Type.SelectedValue == "1")
    //    {
    //        tr_Inbox_out.Visible = false;
    //        tr_Inbox_In.Visible = true;
    //    }
    //    else if (ddl_Type.SelectedValue == "2")
    //    {
    //        tr_Inbox_In.Visible = false;
    //        tr_Inbox_out.Visible = true;
    //    }
    //    else if (ddl_Type.SelectedValue == "3")
    //    {
    //        tr_Inbox_In.Visible = false;
    //        tr_Inbox_out.Visible = false;
    //        tr_Inbox_out_info.Visible = false;
    //        tr_Related_Type.Visible = false;
    //    }

    //    TabPanel_All.ActiveTab = TabPanel_dtl;
    //}
    //protected void ddl_Dept_ID_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    fil_emp();
    //}

    protected void ddl_Follow_Up_Dept_ID_SelectedIndexChanged(object sender, EventArgs e)
    {
        fil_emp_Folow_Up();
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

    //private void fil_emp()
    //{
    //    int Dept_ID = CDataConverter.ConvertToInt(ddl_Dept_ID.SelectedValue);
    //    if (Dept_ID > 0)
    //    {
    //        Smart_Emp_ID.sql_Connection = sql_Connection;
    //        Smart_Emp_ID.Query = "SELECT PMP_ID, pmp_name FROM EMPLOYEE where Dept_Dept_id = " + Dept_ID;
    //        Smart_Emp_ID.Value_Field = "PMP_ID";
    //        Smart_Emp_ID.Text_Field = "pmp_name";
    //        Smart_Emp_ID.DataBind();
    //    }
    //    else
    //        Smart_Emp_ID.Clear_Controls();
    //}
    //protected void ddl_Related_Type_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    Related_type_Changed();

    //}

    //private void Related_type_Changed()
    //{
    //    if (ddl_Related_Type.SelectedValue == "1")
    //    {
    //        trSmart.Visible = false;
    //    }
    //    else if (ddl_Related_Type.SelectedValue == "2")
    //    {

    //        trSmart.Visible = true;
    //        lbl_Inbox_type.Text = "رد على الصادر رقم";
    //        Fil_Smrt_From_OutBox();
    //    }
    //    else if (ddl_Related_Type.SelectedValue == "3")
    //    {

    //        trSmart.Visible = true;
    //        lbl_Inbox_type.Text = " استعجال الوارد للوارد رقم";
    //        Fil_Smrt_From_InBox();
    //    }
    //    else if (ddl_Related_Type.SelectedValue == "4")
    //    {

    //        trSmart.Visible = true;
    //        lbl_Inbox_type.Text = " استكمال الوارد للوارد رقم";
    //        Fil_Smrt_From_InBox();
    //    }
    //    TabPanel_All.ActiveTab = TabPanel_dtl;
    //}

    //void Fil_Smrt_From_OutBox()
    //{
    //    Smart_Related_Id.sql_Connection = sql_Connection;
    //    Smart_Related_Id.Query = "SELECT * from vw_outbox_DateString where group_id =  " + int.Parse(Session_CS.group_id.ToString());
    //    if (CDataConverter.ConvertToInt(Session_CS.Project_id.ToString()) > 0)
    //    {
    //        Smart_Related_Id.Query += " AND Proj_id = " + int.Parse(Session_CS.Project_id.ToString());
    //    }
    //    Smart_Related_Id.Value_Field = "id";
    //    Smart_Related_Id.Text_Field = "con";
    //    Smart_Related_Id.DataBind();
    //}

    //void Fil_Smrt_From_InBox()
    //{
    //    Smart_Related_Id.sql_Connection = sql_Connection;
    //    Smart_Related_Id.Query = "SELECT * from vw_inbox_DateSubject where group_id =  " + int.Parse(Session_CS.group_id.ToString());
    //    if (CDataConverter.ConvertToInt(Session_CS.Project_id.ToString()) > 0)
    //    {
    //        Smart_Related_Id.Query += " AND Proj_id = " + int.Parse(Session_CS.Project_id.ToString());
    //    }
    //    Smart_Related_Id.Value_Field = "id";
    //    Smart_Related_Id.Text_Field = "con";
    //    Smart_Related_Id.DataBind();
    //}

    protected void btn_Doc_Click(object sender, EventArgs e)
    {
        if (CDataConverter.ConvertToInt(hidden_Id.Value) > 0)
        {
            //if (FileUpload1.PostedFile != null)
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

                //if (CDataConverter.ConvertToInt(hidden_Review_File_ID.Value) > 0)
                if (CDataConverter.ConvertToInt(hidden_Review_File_ID.Value) > 0)
                {
                    SqlCommand cmd = new SqlCommand();
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    //cmd.CommandText = " update Review_Files set Original_Or_Attached=@Original_Or_Attached ,File_data=@File_data ,File_name=@File_name,File_ext=@File_ext where Review_File_ID =@Review_File_ID";
                    cmd.CommandText =
                    "update Review_Files SET" + "\r\n" +
                    "   Review_ID = @Review_ID" + "\r\n" +
                    "  ,Original_Or_Attached = @Original_Or_Attached" + "\r\n" +
                    "  ,File_data = @File_data" + "\r\n" +
                    "  ,File_name = @File_name" + "\r\n" +
                    "  ,File_ext = @File_ext" + "\r\n" +
                    "WHERE Review_File_ID = @Review_File_ID";




                    cmd.Parameters.Add("@File_data", SqlDbType.VarBinary);
                    cmd.Parameters.Add("@Review_File_ID", SqlDbType.Int);
                    cmd.Parameters.Add("@Review_ID", SqlDbType.Int);
                    cmd.Parameters.Add("@Original_Or_Attached", SqlDbType.Int);
                    cmd.Parameters.Add("@File_name", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@File_ext", SqlDbType.NVarChar);

                    cmd.Parameters["@File_data"].Value = Input;
                    cmd.Parameters["@Review_File_ID"].Value = CDataConverter.ConvertToInt(hidden_Review_File_ID.Value);
                    cmd.Parameters["@Review_ID"].Value = CDataConverter.ConvertToInt(hidden_Id.Value);
                    cmd.Parameters["@Original_Or_Attached"].Value = CDataConverter.ConvertToInt(ddl_Original_Or_Attached.SelectedValue);
                    cmd.Parameters["@File_ext"].Value = type;
                    cmd.Parameters["@File_name"].Value = txtFileName.Text;

                    con.Open();
                    cmd.ExecuteScalar();

                    con.Close();
                    txtFileName.Text =
                    hidden_Review_File_ID.Value = "";
                }
                else
                {
                    SqlCommand cmd = new SqlCommand();
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    //cmd.CommandText = " insert into Review_Files ( Review_ID, Inbox_Or_Outbox, Original_Or_Attached, File_data, File_name, File_ext) VALUES ( @Review_ID, @Inbox_Or_Outbox, @Original_Or_Attached, @File_data, @File_name, @File_ext)";
                    cmd.CommandText =
                    "insert into Review_Files (" + "\r\n" +
                    "   Review_ID" + "\r\n" +
                    "  ,Original_Or_Attached" + "\r\n" +
                    "  ,File_data" + "\r\n" +
                    "  ,File_name" + "\r\n" +
                    "  ,File_ext" + "\r\n" +
                    ") VALUES (" + "\r\n" +
                    "   @Review_ID" + "\r\n" +
                    "  ,@Original_Or_Attached" + "\r\n" +
                    "  ,@File_data" + "\r\n" +
                    "  ,@File_name" + "\r\n" +
                    "  ,@File_ext" + "\r\n" +
                    ")";

                    cmd.Parameters.Add("@File_data", SqlDbType.VarBinary);
                    cmd.Parameters.Add("@Original_Or_Attached", SqlDbType.Int);
                    cmd.Parameters.Add("@Review_ID", SqlDbType.Int);
                    //cmd.Parameters.Add("@Inbox_Or_Outbox", SqlDbType.Int);
                    cmd.Parameters.Add("@File_name", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@File_ext", SqlDbType.NVarChar);

                    cmd.Parameters["@File_data"].Value = Input;
                    cmd.Parameters["@Original_Or_Attached"].Value = CDataConverter.ConvertToInt(ddl_Original_Or_Attached.SelectedValue);
                    cmd.Parameters["@Review_ID"].Value = CDataConverter.ConvertToInt(hidden_Id.Value);
                    //cmd.Parameters["@Inbox_Or_Outbox"].Value = 1;
                    cmd.Parameters["@File_ext"].Value = type;
                    cmd.Parameters["@File_name"].Value = txtFileName.Text;

                    con.Open();
                    cmd.ExecuteScalar();

                    con.Close();
                    txtFileName.Text =
                    hidden_Review_File_ID.Value = "";

                }



            }
            else
            {
                ShowAlertMessage("يجب ادخال الملف ");
                return;
            
            }





            // Clear_Cntrl();
            Fil_Grid_Documents();
        }
        else
        {
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('يجب إدخال بيانات الخطاب أولا')</script>");

        }

    }

    protected void GrdView_Documents_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditItem")
        {
            Review_Files_DT obj = Review_Files_DB.SelectByID(CDataConverter.ConvertToInt(e.CommandArgument));
            if (obj.Review_File_ID > 0)
            {
                hidden_Review_File_ID.Value = obj.Review_File_ID.ToString();
                txtFileName.Text = obj.File_name;
                ddl_Original_Or_Attached.SelectedValue = obj.Original_Or_Attached.ToString();
            }

        }

        if (e.CommandName == "RemoveItem")
        {
            Review_Files_DB.Delete(CDataConverter.ConvertToInt(e.CommandArgument));
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم الحذف بنجاح')</script>");
            Fil_Grid_Documents();
        }
    }

    private void Fil_Grid_Documents()
    {
        DataTable DT = new DataTable();
        DT = General_Helping.GetDataTable("select * from Review_Files where Review_ID=" + hidden_Id.Value);

        GrdView_Documents.DataSource = DT;
        GrdView_Documents.DataBind();
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

    protected void btn_add_Click(object sender, EventArgs e)
    {

        fill_listbox();
        TabPanel_All.ActiveTab = TabPanel_dtl;
    }

    protected void btn_delete_Click(object sender, EventArgs e)
    {
        if (lst_emp.SelectedValue == "")
        {
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('يجب اختيار موظف ليتم الحذف')</script>");
        }
        else
        {
            lst_emp.Items.Remove(lst_emp.SelectedItem);

            //foreach (ListItem item  in lst_emp.Items)
            //{

            //    ListItem item2 = chklst_Visa_Emp_All.Items.FindByValue(item.Value);
            //    if (item2 != null)
            //        item2.Selected = true;
            //    else item2.Selected = false;
            //}

        }
        TabPanel_All.ActiveTab = TabPanel_dtl;

    }

  

   

    public static void ShowAlertMessage(string error)
    {

        Page page = HttpContext.Current.Handler as Page;
        if (page != null)
        {
            error = error.Replace("'", "\'");
            ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('" + error + "');", true);
        }
    }

  

   
    

    

    private void Save_inox_Visa(Review_Visa_DT obj)
    {

        string Sql_Delete = "delete from Review_Visa_Emp where Visa_Id =" + obj.Visa_Id;
        General_Helping.ExcuteQuery(Sql_Delete);
        string Sql_insert = "";
        //foreach (ListItem item in chklst_Visa_Emp.Items)
        //{
        //    if (item.Selected)
        //    {
        //        if (CDataConverter.ConvertToInt(Session_CS.group_id.ToString()) == 2)
        //        {
        //            Sql_insert = "insert into Review_Visa_Emp ( Visa_Id , Emp_ID ,Sender_id) values ( " + obj.Visa_Id + "," + item.Value + ",57 " + ")";
        //        }
        //        else
        //        {
        //            Sql_insert = "insert into Review_Visa_Emp ( Visa_Id , Emp_ID ,Sender_id) values ( " + obj.Visa_Id + "," + item.Value + "," + CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()) + ")";
        //        }

        //        General_Helping.ExcuteQuery(Sql_insert);

        //        item.Selected = false;
        //    }

        //}

        foreach (ListItem item in lst_emp.Items)
        {

            DataTable dt = General_Helping.GetDataTable("select * from parent_employee where pmp_id = " + CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()));
            if (dt.Rows.Count > 0)
            {

                Sql_insert = "insert into Review_Visa_Emp ( Visa_Id , Emp_ID ,Sender_id) values ( " + obj.Visa_Id + "," + item.Value + "," + CDataConverter.ConvertToInt(dt.Rows[0]["parent_pmp_id"].ToString()) + ")";

            }
            else
            {

                Sql_insert = "insert into Review_Visa_Emp ( Visa_Id , Emp_ID ,Sender_id) values ( " + obj.Visa_Id + "," + item.Value + "," + CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()) + ")";
            }


            General_Helping.ExcuteQuery(Sql_insert);

            //item.Selected = false;


        }




    }

  

    

    

  

    private string Show_Alert(string Succ_names, string Failed_name)
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

      

        return message;


        //      if (!string.IsNullOrEmpty(Failed_name))
        //        Page.RegisterStartupScript("Sucess", "<script language=javascript>alert(' لم يتم ارسال الايميل إلي " + Failed_name + "')</script>");

    }

    private void Fil_Visa_Lstbox(int ID)
    {
        string sql = "SELECT dbo.EMPLOYEE.pmp_name, dbo.Review_Visa_Emp.Emp_ID, dbo.Review_Visa_Emp.Visa_Id FROM  dbo.EMPLOYEE INNER JOIN dbo.Review_Visa_Emp ON dbo.EMPLOYEE.PMP_ID = dbo.Review_Visa_Emp.Emp_ID where dbo.Review_Visa_Emp.Visa_Id = " + ID;
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
        TabPanel_All.ActiveTab = TabPanel_dtl;
    }

    protected void Chk_ALL_cat_CheckedChanged(object sender, EventArgs e)
    {
        //foreach (ListItem item in Chk_main_cat.Items)
        //{
        //    item.Selected = Chk_ALL_cat.Checked;
        //}
        //TabPanel_All.ActiveTab = TabPanel_dtl;
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
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    string temp_sql = "";
        //    DataTable Dt;
        //    string id = (string)Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Visa_Id"));
        //    temp_sql = "select mail_sent from Review_Visa where Visa_Id=" + id;
        //    Dt = General_Helping.GetDataTable(temp_sql);
        //    if (Dt.Rows.Count > 0)
        //    {
        //        if (Dt.Rows[0]["mail_sent"].ToString() == "1")
        //        {
        //            CheckBox chbsent = (CheckBox)e.Row.FindControl("chkSent");
        //            chbsent.Checked = true;
        //        }

        //    }
        //}
    }

   

    protected void radlst_Type_SelectedIndexChanged(object sender, EventArgs e)
    {

        tr_emp_list.Visible = true;
        string sql, sql_emp = "";

        if (radlst_Type.SelectedValue == "1")
        {
            sql_emp = " select * from pmp_fav_View where pmp_fav_View.employee_id = " + CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
            if (Smart_Search_dept.SelectedValue != "")
            {
                sql_emp += " AND Dept_Dept_id = " + Smart_Search_dept.SelectedValue;
            }



        }
        else if (radlst_Type.SelectedValue == "2")
        {
            sql_emp = " select * from employee ";
            if (Smart_Search_dept.SelectedValue != "")
            {
                sql_emp += " where Dept_Dept_id = " + Smart_Search_dept.SelectedValue;
            }

        }
        else if (radlst_Type.SelectedValue == "3")
        {
            sql_emp = " select * from employee where rol_rol_id=3  ";
            if (Smart_Search_dept.SelectedValue != "")
            {
                sql_emp += " AND Dept_Dept_id = " + Smart_Search_dept.SelectedValue;
            }

        }
        else if (radlst_Type.SelectedValue == "4")
        {
            sql_emp = " select * from employee where contact_person=1  ";
            if (Smart_Search_dept.SelectedValue != "")
            {
                sql_emp += " AND Dept_Dept_id = " + Smart_Search_dept.SelectedValue;
            }

        }
        sql_emp += " ORDER BY LTRIM(pmp_name)";
        TabPanel_All.ActiveTab = TabPanel_dtl;
        DataTable dt_emp_fav = General_Helping.GetDataTable(sql_emp);
        chklst_Visa_Emp_All.DataSource = dt_emp_fav;
        chklst_Visa_Emp_All.DataBind();
    }

   

  
}
