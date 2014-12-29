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
using System.Net.Mail;
using System.IO;

public partial class UserControls_Training_Descion : System.Web.UI.UserControl
{
    string PMP_ID;
    Session_CS Session_CS = new Session_CS();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            fillcontrols();
            int course_employee_id = Convert.ToInt32(Request["id"]);
           
            course_employee_DT ceDT = new course_employee_DT();
            ceDT = course_employee_DB.SelectByID(course_employee_id);
            SqlDataSource1.SelectParameters["course_id"].DefaultValue = ceDT.course_id.ToString();
            SqlDataSource1.DataBind();
          //  Session["ID"] = ceDT.id;///////////////////////////////////////////////////
            Label1.Text = "";
            //rb_redirect.DataBind();
            //SqlDataSource2.DataBind();
            //Ch_rejectlist.DataBind();

           
        }

    }

    protected void rd_descionlist_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rd_descionlist.SelectedItem.Value == "2")
        {
            redirect_tr.Visible = false;
            reject_tr.Visible = true;
            Label1.Text = "اختر احد الاسباب التاليه للرفض";
        }
        else if (rd_descionlist.SelectedItem.Value == "4")
        {
            redirect_tr.Visible = true;
            reject_tr.Visible = false;
            Label1.Text = "اختر احد البرامج التاليه للتحويل";
        }
        else if (rd_descionlist.SelectedItem.Value == "1")
        {
            redirect_tr.Visible = false;
            reject_tr.Visible = false;
            Label1.Text = "";
        }
    }
    protected void btn_save_Click(object sender, EventArgs e)
    {
        string status="";
        //int course_employee_id = Convert.ToInt32(Session["ID"]);
        int course_employee_id = Convert.ToInt32(Request["id"]);
        course_employee_DT ceDT = new course_employee_DT();
        ceDT = course_employee_DB.SelectByID(course_employee_id);
        if (rd_descionlist.SelectedItem.Value == "1")
        {
            status = "1";//Accpeted
            ceDT.converted_to_course = 0;
            ceDT.rejected_reason_id = 0;
        }
        else if (rd_descionlist.SelectedItem.Value == "2")
        {
            status = "2";//Rejected
            ceDT.converted_to_course = 0;
            ceDT.rejected_reason_id = Convert.ToInt32(rb_rejected.SelectedItem.Value);
        }
        else if (rd_descionlist.SelectedItem.Value == "4")
        {
            status = "4";//Transfered to other training program
            ceDT.converted_to_course = Convert.ToInt32(rb_redirect.SelectedItem.Value);
            ceDT.rejected_reason_id = 0;
        }
        course_employee_DB.updateadminapproval(ceDT.id,status, ceDT.converted_to_course, ceDT.rejected_reason_id);

        sendnewcoursemail();

       Response.Redirect("~/MainForm/Training_adminapprove.aspx");
    }
    private void fillcontrols()
    {
        int course_employee_id = Convert.ToInt32(Request["id"]);
        course_employee_DT ceDT = new course_employee_DT();
        ceDT = course_employee_DB.SelectByID(course_employee_id);
        if (ceDT.admin_descion != 3)
        {
            rd_descionlist.SelectedValue = ceDT.admin_descion.ToString();
            Label1.Text = "";

        }
        if (ceDT.rejected_reason_id != 0)
           
        {
            reject_tr.Visible = true;
            Label1.Text = "اختر احد الاسباب التاليه للرفض";
            rb_rejected.SelectedValue = ceDT.rejected_reason_id.ToString();
        }
        if (ceDT.converted_to_course != 0)
        {
            Label1.Text = "اختر احد البرامج التاليه للتحويل";
            redirect_tr.Visible = true;
            rb_redirect.SelectedValue = ceDT.converted_to_course.ToString();
        }

    }
    public void sendnewcoursemail()
    {
       int course_employee_id = Convert.ToInt32(Request["id"]);////////////////////////////
      //  int course_employee_id = Convert.ToInt32(Session["ID"]);
        course_employee_DT ceDT = new course_employee_DT();
        ceDT = course_employee_DB.SelectByID(course_employee_id);
        string c_id = ceDT.course_id.ToString();

        course_DT cDT = new course_DT();
        cDT = course_DB.SelectByID(ceDT.course_id,0);

        DataTable dtcourse = General_Helping.GetDataTable("  SELECT   course.*,courses.course_name,Course_Places.place_desc  FROM  courses inner join course on course.course_id=courses.course_id inner join  Course_Places on course.course_place = Course_Places.place_id  and course.id ='" +CDataConverter.ConvertToInt( c_id )+ "' ");

        DataTable dt_mail = General_Helping.GetDataTable("select emp_id from course_employee where id='" + course_employee_id  + "'");
        PMP_ID = dt_mail.Rows[0]["emp_id"].ToString();


        ////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////// Sending Mail Code /////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////
        bool flag = false;


        DataTable dt_getmail = General_Helping.GetDataTable("select mail,pmp_name from employee where PMP_ID ='" + CDataConverter.ConvertToInt(PMP_ID) + "'");
        string name = "";
        string Succ_names = "", Failed_name = "";
        string mail = dt_getmail.Rows[0]["mail"].ToString();
        string parent_name = dt_getmail.Rows[0]["pmp_name"].ToString();

        MailMessage _Message = new MailMessage();
        string str_subj = "  نتيجه طلب الالتحاق بالدوره التدريبيه  " + dtcourse.Rows[0]["course_name"].ToString();



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
      

        // _Message.Body += " <h1 style=text-align:right>    وصلكم وارد من نظام إدارة مشروعات قطاع البنية المعلوماتية  </h1> ";

        _Message.Body += " <h3 > " + "   وصلكم وارد من اداره الدورات التدريبيه  بخصوص الدوره التدريبيه" + "<br/>" + "<h3 style=" + "color:blue >" + dtcourse.Rows[0]["course_name"].ToString() + "</h3>";
        if (ceDT.admin_descion.ToString() == "1")
        {
            _Message.Body += " <h3 > " + "  بان نتيجه الطلب  هي القبول ";
        }
        else if (ceDT.admin_descion.ToString() == "2")
        {
            _Message.Body += " <h3 > " + " بان نتيجه الطلب هي الرفض بسبب "+rb_rejected.SelectedItem.Text;
        }
        else if (ceDT.admin_descion.ToString() == "4")
         
        {
            _Message.Body += " <h3 > " + " بان نتيجه الطلب هي التحويل للبرنامج التالي "+rb_redirect.SelectedItem.Text;
        }
        
      
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
}
