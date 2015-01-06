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
using System.Text;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using DBL;
using ReportsClass;
using System.IO;



public partial class UserControls_Training_User_Register : System.Web.UI.UserControl
{
    private string sql_Connection = Universal.GetConnectionString();
    string sql;
    //Session_CS Session_CS = new Session_CS();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request["id"] != null)
            {
                fillcontrols();
                fill_RadioButtonList();
                int id = Convert.ToInt32(Request["id"]);
                DataTable dt_sub_cat = General_Helping.GetDataTable(" SELECT course_files.* FROM  course_files WHERE   course_id = " + CDataConverter.ConvertToInt(Request["id"]) + "and  type_id=1");
                gv_files.DataSource = dt_sub_cat;
                gv_files.DataBind();
            }
            else
            {
                int request_id = Convert.ToInt32(Request["request_id"]);
                course_employee_DT cedt = new course_employee_DT();
                cedt = course_employee_DB.SelectByID(request_id);
                fillcontrolsupdate();
                fill_RadioButtonList();
                DataTable dt_sub_cat = General_Helping.GetDataTable(" SELECT course_files.* FROM  course_files WHERE   course_id = " + cedt.course_id + "and  type_id=1");
                gv_files.DataSource = dt_sub_cat;
                gv_files.DataBind();

            }
        }
    }
    public void fillcontrols()
    {
        int id = Convert.ToInt32(Request["id"]);

       // course_DT cDT = course_DB.course_Select_details(id);
        DataTable dtcourse = General_Helping.GetDataTable(" SELECT  course.*,courses.course_name,Course_Places.place_desc  FROM  courses inner join course on course.course_id=courses.course_id inner join  Course_Places on course.course_place = Course_Places.place_id and course.id ='"+id +"' ");

        //tx_coursename.Text = cDT.course_name;
        //tx_organization.Text = cDT.organization;
        //tx_courseplace.Text = cDT.course_place;
        //tx_lastgenertiondate.Text =cDT.last_register_date;
        //tx_noofemployee.Text = cDT.emp_no.ToString();
        //txt_candidatecriteria.Text = cDT.candidate_criteria;
        //txt_duration.Text = cDT.duration.ToString();
        //txt_cost.Text = cDT.course_cost.ToString();
        //course_details_DT cdetails = new course_details_DT();
        //cdetails = course_details_DB.SelectByCourseId(id);
        //txt_startdate.Text = cdetails.start_date.ToString();
        //txt_enddate.Text = cdetails.end_date.ToString();

        tx_coursename.Text = dtcourse.Rows[0]["course_name"].ToString();
        tx_organization.Text = dtcourse.Rows[0]["organization"].ToString();
        tx_courseplace.Text = dtcourse.Rows[0]["place_desc"].ToString();
        tx_lastgenertiondate.Text = dtcourse.Rows[0]["last_register_date"].ToString();
        tx_noofemployee.Text = dtcourse.Rows[0]["emp_no"].ToString();
        txt_candidatecriteria.Text = dtcourse.Rows[0]["candidate_criteria"].ToString();
        txt_duration.Text = dtcourse.Rows[0]["duration"].ToString();
        txt_cost.Text = dtcourse.Rows[0]["course_cost"].ToString();
       // course_details_DT cdetails = new course_details_DT();
       // cdetails = course_details_DB.SelectByCourseId(id);
        txt_startdate.Text = dtcourse.Rows[0]["start_date"].ToString();
        txt_enddate.Text = dtcourse.Rows[0]["end_date"].ToString();
        txt_desc.Text = dtcourse.Rows[0]["comments"].ToString();

    }
    public void fill_RadioButtonList()
    {
        //if (Request["id"] != null)
        //{
        //    int id = Convert.ToInt32(Request["id"]);
        //    DataTable dt_sub_cat = General_Helping.GetDataTable("SELECT     { fn CONCAT({ fn CONCAT(start_date, 'إلي') }, end_date) } AS start_date, id from course_details WHERE course_id=" + id);
        //    rb_coursedates.DataSource = dt_sub_cat;
        //    rb_coursedates.DataBind();
        //}

       
        //if (Request["request_id"] != null)
        //{
        //    int request_id = Convert.ToInt32(Request["request_id"]);
        //    course_employee_DT cedt = new course_employee_DT();
        //    cedt = course_employee_DB.SelectByID(request_id);
        //    DataTable dt_sub_cat = General_Helping.GetDataTable("SELECT     { fn CONCAT({ fn CONCAT(start_date, 'إلي') }, end_date) } AS start_date, id from course_details WHERE course_id=" +cedt.course_id);
        //    rb_coursedates.DataSource = dt_sub_cat;
        //    rb_coursedates.DataBind();
        //    rb_coursedates.SelectedValue = cedt.course_details_id.ToString();
        //}
    }
    public void deletemp_course()
    {
        //int course_id = Convert.ToInt32(Request["id"]);
        //int emp = Convert.ToInt32(Session_CS.pmp_id);
        //course_employee_DB.deleteByempid(emp,course_id);
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        DataTable dtselect = General_Helping.GetDataTable("select * from course_employee where course_id='"+Convert.ToInt32(Request["id"])+"' and emp_id='"+CDataConverter.ConvertToInt(Session_CS.pmp_id)+"'");
        if (dtselect.Rows.Count == 0)
        {
            if (Request["id"] != null)
            {
                course_employee_DT ce_DT = new course_employee_DT();
                ce_DT.course_id = Convert.ToInt32(Request["id"]);
                ce_DT.emp_id = Convert.ToInt32(Session_CS.pmp_id);
                ce_DT.status = "3";
                ce_DT.course_details_id = 0;
                //course_details_DT cdetails = new course_details_DT();
                //cdetails = course_details_DB.SelectByCourseId(Convert.ToInt32(Request["id"]));
                //ce_DT.course_details_id = cdetails.id;
                course_employee_DB.Save(ce_DT);

                sendnewcoursemail();

                // Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم الحفظ بنجاح')</script>");
                // show_report();
                //Response.Redirect("~/Webforms/Training_User_Viewallcourse.aspx");


            }
                 

            else if (Request["request_id"] != null)
            {
                int request_id = Convert.ToInt32(Request["request_id"]);
                course_employee_DT cedt = new course_employee_DT();
                cedt = course_employee_DB.SelectByID(request_id);
                cedt.course_details_id = 0;
                //course_details_DT cdetails = new course_details_DT();
                //cdetails = course_details_DB.SelectByCourseId(Convert.ToInt32(Request["id"]));
               // cedt.course_details_id = cdetails.id;

                //cedt.course_details_id = Convert.ToInt32(rb_coursedates.SelectedValue.ToString());
                course_employee_DB.Save(cedt);
              
                // Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم الحفظ بنجاح')</script>");
                //show_report();
                // Response.Redirect("~/Webforms/Training_User_Viewallcourse.aspx");

                sendnewcoursemail();
            }
           // sendnewcoursemail();
            // Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم الحفظ بنجاح')</script>");

            show_report();
            
        }
        else
        {
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('  تم التسجيل في هذه الدورة من قبل')</script>");

        }
        

    }
    public void fillcontrolsupdate()
    {
        int request_id = Convert.ToInt32(Request["request_id"]);
        DataTable dtcourse = General_Helping.GetDataTable("SELECT  course.*,courses.course_name,Course_Places.place_desc  FROM  courses inner join course on course.course_id=courses.course_id inner join  Course_Places on course.course_place  =Course_Places.place_id and courses.course_id'" + request_id + "' ");

        tx_coursename.Text = dtcourse.Rows[0]["course_name"].ToString();
        tx_organization.Text = dtcourse.Rows[0]["organization"].ToString();
        tx_courseplace.Text = dtcourse.Rows[0]["place_desc"].ToString();
        tx_lastgenertiondate.Text = dtcourse.Rows[0]["last_register_date"].ToString();
        tx_noofemployee.Text = dtcourse.Rows[0]["emp_no"].ToString();
        txt_candidatecriteria.Text = dtcourse.Rows[0]["candidate_criteria"].ToString();
        txt_duration.Text = dtcourse.Rows[0]["duration"].ToString();
        txt_cost.Text = dtcourse.Rows[0]["course_cost"].ToString();
        // course_details_DT cdetails = new course_details_DT();
        // cdetails = course_details_DB.SelectByCourseId(id);
        txt_startdate.Text = dtcourse.Rows[0]["start_date"].ToString();
        txt_enddate.Text = dtcourse.Rows[0]["end_date"].ToString();
        txt_desc.Text = dtcourse.Rows[0]["comments"].ToString();
        //course_employee_DT cedt = new course_employee_DT();
        //cedt = course_employee_DB.SelectByID(request_id);
        //course_DT cDT = course_DB.course_Select_details(ID);
        //tx_coursename.Text = cDT.course_name;
        //tx_organization.Text = cDT.organization;
        //tx_courseplace.Text = cDT.course_place;
        //tx_lastgenertiondate.Text = cDT.last_register_date;
        //tx_noofemployee.Text = cDT.emp_no.ToString();
        //txt_candidatecriteria.Text = cDT.candidate_criteria;
        //txt_duration.Text = cDT.duration.ToString();
        //txt_cost.Text = cDT.course_cost.ToString ();
        //ddl_refrence.SelectedValue =cDT.refrences.ToString();
    }


    protected void rb_coursedates_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Page.IsPostBack)
        {
            deletemp_course();
        }

    }
    public void sendnewcoursemail()
    {

        ////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////// Sending Mail Code /////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////
        bool flag = false;


        DataTable dt_getmail = General_Helping.GetDataTable("select mail,pmp_name from employee where pmp_id ='" + Convert.ToInt32(Session_CS.pmp_id.ToString()) + "'");
        string name = "";
        string Succ_names = "", Failed_name = "";

        string parent_name = dt_getmail.Rows[0]["pmp_name"].ToString();

        DataTable dt_employeeinfo = General_Helping.GetDataTable("select * from employee where pmp_id =" + Convert.ToInt32(Session_CS.pmp_id.ToString()));

        DataTable dt_getdirectmanager = General_Helping.GetDataTable("select * from employee where pmp_id =" + Convert.ToInt32(dt_employeeinfo.Rows[0]["vacation_mng_pmp_id"]));
        string mail = dt_getdirectmanager.Rows[0]["mail"].ToString();

        MailMessage _Message = new MailMessage();
        string str_subj = "طلب الالتحاق لدوره تدريبيه";



        string str_witoutn = str_subj.Replace("\n", "");
        str_subj = str_witoutn.Replace("\r", "");

        if (int.Parse(Session_CS.group_id.ToString()) == 3)
        {

            _Message.Subject = ("INIR" + " - " + str_subj + " - " + CDataConverter.ConvertDateTimeNowRtrnString()).ToString();

        }
        else
        {

            _Message.Subject = "نظام الادارة الالكترونية - المراسلات" + " - " + str_subj + " - " + CDataConverter.ConvertDateTimeNowRtrnString();
        }


        //_Message.BodyEncoding = Encoding.Unicode;
        _Message.BodyEncoding = Encoding.UTF8;
        _Message.SubjectEncoding = Encoding.UTF8;

        
        //_Message.To.Add(new MailAddress(mail));
        string address2 = "0";
        String encrypted_id = "0";
        string file = "";
        MemoryStream ms = new MemoryStream();
       // _Message.IsBodyHtml = true;
        _Message.Body = "<html><body dir='rtl'><h3 >";
        _Message.Body += " السيد/"+ dt_getdirectmanager.Rows[0]["pmp_name"].ToString(); 


        _Message.Body += " <h3 > " + "   وصلكم طلب للترشح لدوره تدريبية من : " + "<br/>" + "<h3 style=" + "color:blue >" + dt_employeeinfo.Rows[0]["pmp_name"].ToString() + "</h3>";
        _Message.Body += " <h3 > " + "   اسم الدورة التدريبية: " + tx_coursename.Text;
        _Message.Body += " <h3 > " + "  فتره الانعقاد من :" + txt_startdate.Text + " <h3 > " + " إلي : "+txt_enddate.Text;
     


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

    private void show_report()
    {
        SqlConnection conn = new SqlConnection(sql_Connection);

        //sql = "SELECT  course.id, course.course_name, course_details.start_date, course_details.end_date, course_employee.comment, EMPLOYEE.PMP_ID, EMPLOYEE.pmp_name,  EMPLOYEE.job_no, EMPLOYEE.pmp_title, EMPLOYEE.Hire_date, EMPLOYEE.university_degree, EMPLOYEE.major, Departments.Dept_id, Departments.Dept_name,  Employee_publicdata.phone, Employee_publicdata.mobile, Employee_publicdata.mail, Employee_publicdata.current_tasks, Employee_publicdata.is_manager,   Employee_publicdata.noofemployee, Employee_publicdata.englishlevel, course.duration FROM  EMPLOYEE INNER JOIN Departments ON EMPLOYEE.Dept_Dept_id = Departments.Dept_id LEFT OUTER JOIN  Employee_publicdata ON EMPLOYEE.PMP_ID = Employee_publicdata.pmp_id LEFT OUTER JOIN  Employee_Experience ON EMPLOYEE.PMP_ID = Employee_Experience.pmp_id LEFT OUTER JOIN Employee_Ex_Training ON EMPLOYEE.PMP_ID = Employee_Ex_Training.pmp_id INNER JOIN course_employee ON course_employee.emp_id = EMPLOYEE.PMP_ID LEFT OUTER JOIN course ON course.id = course_employee.course_id LEFT OUTER JOIN  course_details ON course_details.course_id = course.id WHERE (1=1)";
        //SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        //DataTable dt = new DataTable();
        //da.Fill(dt);
        string user = Session_CS.pmp_name.ToString();
        ReportDocument rd = new ReportDocument();
        string s = Server.MapPath("../Reports/Training_Forms.rpt");
        rd.Load(s);
       // rd.SetDataSource(dt);
        Reports.Load_Report(rd);

      

      //rd.SetParameterValue("@PMP_ID", Convert.ToInt32(Session_CS.pmp_id));
      // rd.SetParameterValue("Course_ID", Convert.ToInt32(Request["id"]));

        rd.SetParameterValue("Pmp_id", Convert.ToInt32(Session_CS.pmp_id), "trainingSubRep3.rpt");
        rd.SetParameterValue("course_id", Convert.ToInt32(Request["id"]), "trainingSubRep3.rpt");

        rd.SetParameterValue("pmp_id", CDataConverter.ConvertToInt(Session_CS.pmp_id), "trainingSubRep2.rpt");

        rd.SetParameterValue("PMP_id", CDataConverter.ConvertToInt(Session_CS.pmp_id), "trainingSubRep.rpt");

        rd.SetParameterValue("Pmp_id", CDataConverter.ConvertToInt(Session_CS.pmp_id), "trainingSubRep5.rpt");


        rd.SetParameterValue("Pmp_id", CDataConverter.ConvertToInt(Session_CS.pmp_id), "trainingSubRep4.rpt");
        rd.SetParameterValue("course_id", Convert.ToInt32(Request["id"]), "trainingSubRep4.rpt");
       // rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
        //rd.SetParameterValue("@user", user, "footerRep.rpt");
       
        
      // if (dt.Rows.Count > 0)
      // {
          rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.WordForWindows, Response, true, "Report");
           
      //}
      // else
      // {

      // }
        
       
    }

}
