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
using System.Net.Mail;
using System.Data.SqlClient;
using System.Text;
using System.IO;

public partial class UserControls_Training_Add_NewCourse : System.Web.UI.UserControl
{

    Session_CS Session_CS = new Session_CS();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {

            Page.DataBind();
            fill_ddl_programs();
            fill_ddl_places();
            //if (type == 2)
            //{
            if (Request["id"] != null)
            {
                hidden_Id.Value = Request["id"].ToString();
                fillcontrols();
                gv_referancefile.Visible = true;
            }
            //}
            if (CDataConverter.ConvertToInt(hidden_Id.Value) <= 0)
            {
                Button3.Enabled = false;

            }
        }
        //if (course_id != 0)
        //{
        //    Button3.Enabled = true;
        //    Button1.Enabled = true;
        //}




    }

    private void fill_ddl_programs()
    {
        DataTable dt1 = Course_Programs_DB.SelectAll();
        ddl_programs.DataSource = dt1;
        ddl_programs.DataBind();
        ddl_programs.DataTextField = "prog_name";
        ddl_programs.DataValueField = "prog_id";
        ddl_programs.Items.Insert(0, new ListItem("..... اختر  البرنامج  ....", "0"));

    }

    private void fill_ddl_places()
    {
        DataTable dt1 = Course_Places_DB.SelectAll();
        ddl_place.DataSource = dt1;
        ddl_place.DataBind();
        ddl_place.DataTextField = "place_desc";
        ddl_place.DataValueField = "place_id";
        ddl_place.Items.Insert(0, new ListItem("..... اختر  مكان الانعقاد  ....", "0"));

    }

    protected void nextbutton_Click(object sender, EventArgs e)
    {
        if (txt_enddate.Text != "" && txt_startdate.Text!="")
        {
            this.CourseDurationVal.ValueToCompare = ((CDataConverter.ConvertToDate(txt_enddate.Text).Subtract(CDataConverter.ConvertToDate(txt_startdate.Text))).Days).ToString();
            CourseDurationVal.Validate();
            
        }
        
        
        if (Page.IsValid)
        {
            // course_DT cdt = course_DB.SelectByID (CDataConverter.ConvertToInt(ddl_course.SelectedValue ));
            course_DT cdt = new course_DT();
            cdt.id = CDataConverter.ConvertToInt(hidden_Id.Value);
            cdt.course_id = CDataConverter.ConvertToInt(ddl_course.SelectedValue);
            cdt.course_place = CDataConverter.ConvertToInt(ddl_place.SelectedValue);
            cdt.created_by = Convert.ToInt32((Session_CS.pmp_id));
            cdt.emp_no = Convert.ToInt32(tx_noofemployee.Text);
            cdt.last_register_date = tx_lastgenertiondate.Text;
            cdt.organization = tx_organization.Text;
            cdt.comments = txt_desc.Text;
            cdt.candidate_criteria = txt_candidatescriterea.Text;
            if (txt_duration.Text != "")
            {
                cdt.duration = Convert.ToInt32(txt_duration.Text);
            }
            else
                cdt.duration = 0; 
           
            cdt.refrences = Convert.ToInt32(ddl_refrences.SelectedItem.Value);
            cdt.course_cost = CDataConverter.ConvertToDecimal(txt_cost.Text);
            cdt.prog_id = CDataConverter.ConvertToInt(ddl_programs.SelectedValue);

            cdt.track_id = CDataConverter.ConvertToInt(ddl_tracks.SelectedValue);
            cdt.start_date = txt_startdate.Text;
            cdt.end_date = txt_enddate.Text;

            if (Convert.ToInt32(ddl_refrences.SelectedValue) == 1)
            {
                email_tr.Visible = true;
                refrence_files.Visible = false;
                gridviewfiles_tr.Visible = false;
                cdt.inbox_id = Convert.ToInt32(ddl_email.SelectedValue);

            }
            else if (Convert.ToInt32(ddl_refrences.SelectedValue) > 1)
            {
                email_tr.Visible = false;
                refrence_files.Visible = true;
                gridviewfiles_tr.Visible = true;
                cdt.inbox_id = 0;
            }

            hidden_Id.Value = course_DB.Save(cdt).ToString();
            btn_sendmail.Visible = true;
            //course_details_DT courseDetails = new course_details_DT();
            //courseDetails.course_id = Convert.ToInt32(hidden_Id.Value);
            //courseDetails.start_date = txt_startdate.Text;
            //courseDetails.end_date = txt_enddate.Text;
            //course_details_DB.Save(courseDetails);
            if (FileUpload_refrencefiles.HasFile)
            {
                string DocName = FileUpload_refrencefiles.FileName;
                int dotindex = DocName.LastIndexOf(".");
                string type = DocName.Substring(dotindex, DocName.Length - dotindex);

                Stream myStream;
                int fileLen;
                StringBuilder displayString = new StringBuilder();
                fileLen = FileUpload_refrencefiles.PostedFile.ContentLength;
                Byte[] Input = new Byte[fileLen];
                myStream = FileUpload1.FileContent;
                myStream.Read(Input, 0, fileLen);

                SqlCommand cmd = new SqlCommand();
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO [course_files] ( [course_id], [file_path],[file_name],[type_id]) VALUES (@course_id,@file_path,@file_name,2 )";

                cmd.Parameters.Add("@course_id", SqlDbType.Int);
                cmd.Parameters.Add("@file_path", SqlDbType.VarBinary);
                cmd.Parameters.Add("@file_name", SqlDbType.NVarChar);

                cmd.Parameters["@course_id"].Value = CDataConverter.ConvertToInt(hidden_Id.Value);
                cmd.Parameters["@file_path"].Value = Input;
                cmd.Parameters["@file_name"].Value = DocName;

                con.Open();
                cmd.ExecuteScalar();

                con.Close();

                DataTable dt_sub_cat = General_Helping.GetDataTable(" SELECT course_files.* FROM  course_files WHERE   course_id = " + CDataConverter.ConvertToInt(hidden_Id.Value) + " and type_id=2");
                gv_referancefile.DataSource = dt_sub_cat;
                gv_referancefile.DataBind();
            }
            Button3.Enabled = true;
            //Button1.Enabled = true;


            if (cdt.id > 0)
            {
                Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم الحفظ بنجاح')</script>");
            }
            // }        

        }

    }
    protected void Button3_Click(object sender, EventArgs e)
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


            SqlCommand cmd = new SqlCommand();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO course_files  (course_id, file_path, file_name, type_id)VALUES        (@course_id,@file_path,@file_name, 1)";


            cmd.Parameters.Add("@course_id", SqlDbType.Int);
            cmd.Parameters.Add("@file_path", SqlDbType.VarBinary);
            cmd.Parameters.Add("@file_name", SqlDbType.NVarChar);

            cmd.Parameters["@course_id"].Value = CDataConverter.ConvertToInt(hidden_Id.Value);
            cmd.Parameters["@file_path"].Value = Input;
            cmd.Parameters["@file_name"].Value = DocName;


            con.Open();
            cmd.ExecuteScalar();

            con.Close();

        }

        DataTable dt_sub_cat = General_Helping.GetDataTable(" SELECT course_files.* FROM  course_files WHERE   course_id = " + CDataConverter.ConvertToInt(hidden_Id.Value) + " and type_id=1");
        gv_files.DataSource = dt_sub_cat;
        gv_files.DataBind();

    }
    public void fillcontrols()
    {


        int courseid = Convert.ToInt32(Request["id"]);
        course_DT cDT = course_DB.SelectByID(courseid, CDataConverter.ConvertToInt(hidden_Id.Value));
        //course_DT cDT = new course_DT();
        hidden_Id.Value = cDT.id.ToString();

        //tx_courseplace.Text = cDT.course_place;
        tx_noofemployee.Text = cDT.emp_no.ToString();
        tx_organization.Text = cDT.organization.ToString();
        tx_lastgenertiondate.Text = cDT.last_register_date.ToString();
        txt_desc.Text = cDT.comments.ToString();
        txt_candidatescriterea.Text = cDT.candidate_criteria;
        txt_duration.Text = cDT.duration.ToString();
        txt_cost.Text = cDT.course_cost.ToString();
        ddl_refrences.SelectedValue = cDT.refrences.ToString();
        ddl_programs.SelectedValue = cDT.prog_id.ToString();
        ddl_place.SelectedValue = cDT.course_place.ToString();
        ddl_programs.SelectedValue = cDT.prog_id.ToString();
        fill_ddl_course();
        ddl_course.SelectedValue = cDT.course_id.ToString();
        ddl_course.Visible = true;


        //txt_course_name.Text = Request["name"].ToString();
        //txt_course_name.Visible = true;
        //txt_course_name.Enabled = false;

        fill_ddl_tracks();
        ddl_tracks.SelectedValue = cDT.track_id.ToString();
        txt_enddate.Text = cDT.end_date.ToString();
        txt_startdate.Text = cDT.start_date.ToString();
        btn_sendmail.Visible = true;





        if (Convert.ToInt32(ddl_refrences.SelectedValue) > 1)
        {
            refrence_files.Visible = true;
            gridviewfiles_tr.Visible = true;
            email_tr.Visible = false;
        }
        else if (Convert.ToInt32(ddl_refrences.SelectedValue) == 1)
        {
            refrence_files.Visible = false;
            gridviewfiles_tr.Visible = false;
            email_tr.Visible = true;
        }
        //course_details_DT courseDetails = new course_details_DT();
        //courseDetails = course_details_DB.SelectByCourseId(CDataConverter.ConvertToInt(hidden_Id.Value));
        //txt_enddate.Text = courseDetails.end_date;
        //txt_startdate.Text = courseDetails.start_date;

        //ddl_email.SelectedValue = cDT.inbox_id.ToString();
        DataTable dt_sub_cat = General_Helping.GetDataTable(" SELECT  * FROM  courses where course_id=" + cDT.course_id);
        //gv_dates.DataSource = dt_sub_cat;
        //gv_dates.DataBind();
        //  DataTable dt_sub_cat2 = General_Helping.GetDataTable(" SELECT course_files.* FROM   course_files WHERE   course_id =" + cDT.course_id + "and type_id=1");

        DataTable dt_sub_cat2 = General_Helping.GetDataTable(" SELECT course_files.* FROM  course_files WHERE   course_id = " + CDataConverter.ConvertToInt(courseid) + " and type_id=1");

        gv_files.DataSource = dt_sub_cat2;
        gv_files.DataBind();

        DataTable dt_sub_cat3 = General_Helping.GetDataTable(" SELECT course_files.* FROM   course_files WHERE   course_id =" + CDataConverter.ConvertToInt(courseid) + "and type_id=2");
        gv_referancefile.DataSource = dt_sub_cat3;
        gv_referancefile.DataBind();


    }


    protected void gv_dates_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "RemoveItem")
        {
            // course_details_DB.Delete(CDataConverter.ConvertToInt(e.CommandArgument));

            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم الحذف بنجاح')</script>");
            //co
            DataTable dt_sub_cat = General_Helping.GetDataTable("SELECT  * FROM  course_details where course_id=" + hidden_Id.Value);
            //gv_dates.DataSource = dt_sub_cat;
            //gv_dates.DataBind();
        }
    }

    protected void gv_files_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "RemoveItem")
        {
            course_files_DB.Delete(CDataConverter.ConvertToInt(e.CommandArgument));
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم الحذف بنجاح')</script>");

            DataTable dt_sub_cat = General_Helping.GetDataTable(" SELECT course_files.* FROM  course_files WHERE   course_id = " + hidden_Id.Value + "and type_id=1");
            gv_files.DataSource = dt_sub_cat;
            gv_files.DataBind();
        }
    }

    void Send_Email_for_Proj_mngr()
    {

        string main_sql = " SELECT  distinct   EMPLOYEE.pmp_name, EMPLOYEE.mail FROM         EMPLOYEE INNER JOIN                       Project ON EMPLOYEE.PMP_ID = Project.pmp_pmp_id  ";

        DataTable dt_act = General_Helping.GetDataTable(main_sql);
        string name = "";
        string Succ_names = "", Failed_name = "";
        if (dt_act.Rows.Count > 0)
        {
            MailMessage _Message = new MailMessage();
            _Message.Subject = "دوره  تدريبيه جديده";
            _Message.BodyEncoding = System.Text.Encoding.Unicode;

            string address2 = "0";
            String encrypted_id = "0";
            string file = "";
            MemoryStream ms = new MemoryStream();
           // _Message.IsBodyHtml = true;

            _Message.Body = "<html><body dir='rtl'><h3 >";
            _Message.Body += " السادة الزملاء";
            _Message.Body += "    </h3> تحيه طيبه وبعد";

            _Message.Body += " <h3 > " + "  تتشرف إداره الموارد البشريه بفتح باب التسجيل في دورات التدريبيه بال " + "<h3 style=color:blue >" + tx_organization.Text.ToString() + "</h3>" + "  وأن اخر تاريخ لتعديل الأنشطة على نظام ال (pms) هو <br/><h3 style=color:blue ></h3>";
            //_Message.Body += "<h3 >   ومرفق الوثيقة الخاصة بهذه التعديلات</h3> <br /><br />";
            _Message.Body += "<h3 > مع تحيات </h3> ";
            _Message.Body += "<h3 >   " + Session_CS.e_signature.ToString() + "  </h3> ";
            _Message.Body += "</body></html>";
        
            string mail = "";
            try
            {
                foreach (DataRow dr in dt_act.Rows)
                {
                    _Message.To.Add(new MailAddress(dr["mail"].ToString()));
                }

              
                SendingMailthread_class.Sendingmail(_Message,_Message.Subject, _Message.Body, mail, ms, file, encrypted_id, "");

                Succ_names += name + ",";
            }
            catch (Exception ex)
            {
                Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لم يتم ارسال الايميل بنجاح')</script>");


            }
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم ارسال الايميل بنجاح')</script>");
        }

    }
    protected void ddl_refrences_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_refrences.SelectedItem.Value == "1")
        {
            email_tr.Visible = true;
            refrence_files.Visible = false;
            gridviewfiles_tr.Visible = false;

        }
        else if (Convert.ToInt32(ddl_refrences.SelectedItem.Value) > 1)
        {
            refrence_files.Visible = true;
            gridviewfiles_tr.Visible = true;
            email_tr.Visible = false;
        }
    }
    protected void gv_referancefile_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "RemoveItem")
        {
            course_files_DB.Delete(CDataConverter.ConvertToInt(e.CommandArgument));
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم الحذف بنجاح')</script>");

            DataTable dt_sub_cat = General_Helping.GetDataTable(" SELECT course_files.* FROM  course_files WHERE   course_id = " + hidden_Id.Value + "and type_id=2");
            gv_referancefile.DataSource = dt_sub_cat;
            gv_referancefile.DataBind();
        }
    }





    ////////////////////////////send mail////////////////////////////////////////////

    public void sendnewcoursemail()
    {

        ////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////// Sending Mail Code /////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////
        bool flag = false;
        DataTable dt_getmail = new DataTable();
        string name = "";
        string Succ_names = "", Failed_name = "";
        //if (CDataConverter.ConvertToInt(Session_CS.group_id.ToString()) == 16)
        //{

        //    dt_getmail = General_Helping.GetDataTable("SELECT EMPLOYEE.PMP_ID, EMPLOYEE.pmp_name, Departments.sec_sec_id, EMPLOYEE.mail FROM EMPLOYEE INNER JOIN       Departments ON EMPLOYEE.Dept_Dept_id = Departments.Dept_ID WHERE        (EMPLOYEE.mail IS NOT NULL) AND  (EMPLOYEE.PMP_ID=450) AND (EMPLOYEE.mail <> '') AND (Departments.sec_sec_id = 1) AND (EMPLOYEE.mail LIKE '%mcit%') ORDER BY LTRIM(EMPLOYEE.pmp_name)");
        //}
        //else if (CDataConverter.ConvertToInt(Session_CS.group_id.ToString()) == 15)
        //{
        dt_getmail = General_Helping.GetDataTable("SELECT EMPLOYEE.PMP_ID, EMPLOYEE.pmp_name,EMPLOYEE.mail FROM EMPLOYEE WHERE sec_sec_id=1  and  (EMPLOYEE.mail IS NOT NULL) AND (EMPLOYEE.mail <> '') AND (EMPLOYEE.mail LIKE '%mcit%') ORDER BY LTRIM(EMPLOYEE.pmp_name)");
        //dt_getmail = General_Helping.GetDataTable("SELECT EMPLOYEE.PMP_ID, EMPLOYEE.pmp_name,EMPLOYEE.mail FROM EMPLOYEE WHERE pmp_id=33");
        //   }


        string mail = dt_getmail.Rows[0]["mail"].ToString();
        string parent_name = dt_getmail.Rows[0]["pmp_name"].ToString();

        MailMessage _Message = new MailMessage();
       // string str_subj = "الإعلان عن دورة تدريبيه جديده";
        string str_subj = "test mail from E-managment Developer Team";



        string str_witoutn = str_subj.Replace("\n", "");
        str_subj = str_witoutn.Replace("\r", "");

        if (int.Parse(Session_CS.group_id.ToString()) == 3)
        {

            _Message.Subject = ("INIR" + " - " + str_subj + " - " + CDataConverter.ConvertDateTimeNowRtrnString()).ToString();

        }
        else
        {

            //_Message.Subject = "نظام الادارة الالكترونية - التدريب" + " - " + str_subj + " - " + DateTime.Today.Date;
            _Message.Subject =  str_subj + " - " + CDataConverter.ConvertDateTimeNowRtrnString();
        }


        //_Message.BodyEncoding = Encoding.Unicode;
        _Message.BodyEncoding = Encoding.UTF8;
        _Message.SubjectEncoding = Encoding.UTF8;

        //_Message.To.Add(new MailAddress(mail));


        string address2 = "0";
        String encrypted_id = "0";
        string file = "";
        MemoryStream ms = new MemoryStream();
      //  _Message.IsBodyHtml = true;
        _Message.Body = "<html><body dir='rtl'><h3 >";
        _Message.Body += "  test body from E-managment Developer Team";
        //_Message.Body = "<html><body dir='rtl'><h3 >";
        //_Message.Body += "  الساده الزملاء";

        //// _Message.Body += " <h1 style=text-align:right>    وصلكم وارد من نظام إدارة مشروعات قطاع البنية المعلوماتية  </h1> ";

        //_Message.Body += " <h3 > " + "   وصلكم وارد من اداره الدورات التدريبيه بقطاع البنيه المعلوماتيه بعنوان" + "<br/>" + "<h3 style=" + "color:blue >" + ddl_course.SelectedItem.Text + "</h3>";
        //_Message.Body += " <h3 > " + "   مقدمه من " + tx_organization.Text;
        //_Message.Body += " <h3 > " + "   مكان الانعقاد " + ddl_place.SelectedItem.Text;
        //_Message.Body += " <h3 > " + "  عدد الموظفين المطلوب " + tx_noofemployee.Text;
        //_Message.Body += " <h3 > " + " اخر معاد للترشح " + tx_lastgenertiondate.Text;
        //_Message.Body += " <h3 > " + "شروط الترشح " + txt_candidatescriterea.Text;


        DataTable dt = General_Helping.GetDataTable(" SELECT course_files.* FROM  course_files WHERE   course_id = " + CDataConverter.ConvertToInt(ddl_course.SelectedValue) + " and type_id=1");
        foreach (DataRow dr in dt.Rows)
        {

            if (dr["file_path"] != DBNull.Value)
            {

                 file = dr["File_name"].ToString();
                byte[] files = (byte[])dr["file_path"];
                ms = new MemoryStream(files);
                _Message.Attachments.Add(new Attachment(ms, file));
                if (ms.Length > 26214400)
                {
                    Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('حجم الملفات التابعة لهذا البريد أكبر من المسموح')</script>");
                    return;
                }
                flag = true;

            }
        }

        if (flag)
        _Message.Body += "<h3 > مع تحيات </h3> ";
        _Message.Body += "<h3 >   " + Session_CS.e_signature.ToString() + "  </h3> ";
        _Message.Body += "</body></html>";
      

        try
        {
            


            //commented until Publish 
            _Message.To.Add(new MailAddress(" ITInfrastructure "));

        
            SendingMailthread_class.Sendingmail(_Message,_Message.Subject, _Message.Body, mail, ms, file, encrypted_id, "");

            Succ_names += name + ",";
        }
        catch (Exception ex)
        {

            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لم يتم ارسال الايميل بنجاح')</script>");

        }
        Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم ارسال الايميل بنجاح')</script>");

        /////////////////  to store that mohammed eid send to dr hesham the mail
        //Inbox_Visa_Follows_DT obj_follow = Inbox_Visa_Follows_DB.SelectByID(CDataConverter.ConvertToInt(hidden_Follow_ID.Value));
        //obj_follow.Follow_ID = CDataConverter.ConvertToInt(hidden_Follow_ID.Value);
        //obj_follow.Inbox_ID = CDataConverter.ConvertToInt(hidden_Id.Value);

        //obj_follow.Descrption = "تم الارسال الي المدير المختص";
        //string date = DateTime.Now.ToShortDateString().ToString();
        //obj_follow.Date = date;
        //obj_follow.time_follow = DateTime.UtcNow.ToLocalTime().ToLongTimeString();
        //obj_follow.entery_pmp_id = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
        //obj_follow.Visa_Emp_id = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
        //obj_follow.Follow_ID = Inbox_Visa_Follows_DB.Save(obj_follow);
        //Fil_Grid_Visa_Follow();

        ////////////////////// to show mohammed eid in the drop down list of employee in المسير


    }


    protected void btn_sendmail_Click(object sender, EventArgs e)
    {
        sendnewcoursemail();
    }

    private void fill_ddl_course()
    {
        DataTable dt1 = Courses_DB.SelectAll(0, CDataConverter.ConvertToInt(ddl_programs.SelectedValue));
        ddl_course.DataSource = dt1;
        ddl_course.DataBind();
        ddl_course.DataTextField = "course_name";
        ddl_course.DataValueField = "course_id";
        ddl_course.Items.Insert(0, new ListItem("..... اختر  الدورة التريبية ....", "0"));

    }


    private void fill_ddl_tracks()
    {
        DataTable dt2 = Course_Tracks_DB.SelectAll(0, CDataConverter.ConvertToInt(ddl_course.SelectedValue));
        ddl_tracks.DataSource = dt2;
        ddl_tracks.DataBind();
        ddl_tracks.DataTextField = "track_name";
        ddl_tracks.DataValueField = "id";
        ddl_tracks.Items.Insert(0, new ListItem("..... اختر  المسار  ....", "0"));

    }

    protected void ddl_programs_SelectedIndexChanged(object sender, EventArgs e)
    {
        fill_ddl_course();

    }
    protected void ddl_course_SelectedIndexChanged(object sender, EventArgs e)
    {
        fill_ddl_tracks();


    }


}
