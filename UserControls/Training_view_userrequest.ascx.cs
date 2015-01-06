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
using System.IO;
public partial class UserControls_Training_view_userrequest : System.Web.UI.UserControl
{
    string txt_course;
    int PMP_ID;
    int c_id;
    //Session_CS Session_CS = new Session_CS();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            Fil_Grid();
        
    }

    void Fil_Grid()
    {
        gv_viewuserrequest.DataSource = course_DB.Select_Courses_Emlployee_Manager(CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()),"3");
        gv_viewuserrequest.DataBind();
    }
 


    protected void Button2_Click(object sender, EventArgs e)
    {
        Button1.Visible = false;
        Button2.Visible = false;
        DataTable dt=new DataTable();
        dt=course_DB.Select_Courses_Emlployee_EX_Manager (CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()));
        gv_viewuserrequest.DataSource = dt;
        gv_viewuserrequest.DataBind();
        for (int i = 0; i < gv_viewuserrequest.Rows.Count; i++)
        {
            if (gv_viewuserrequest.Rows[i].RowType == System.Web.UI.WebControls.DataControlRowType.DataRow)
            {
                RadioButtonList rb = (RadioButtonList)gv_viewuserrequest.Rows[i].FindControl("RadioButtonList1");
                rb.Enabled = false;
                rb.SelectedValue = dt.Rows[i]["status"].ToString();
           }
       }
      

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        
       
        string status = "3";
        int id = 0;
        
        //for (int i = 0; i < gv_viewuserrequest.Rows.Count;i++)
        //{

        foreach (GridViewRow row in gv_viewuserrequest.Rows)
        {
            RadioButtonList rb = (RadioButtonList)row.FindControl("RadioButtonList1");
            TextBox tx_comment = (TextBox)row.FindControl("tx_comment");
            TextBox tx_id = (TextBox)row.FindControl("txt_id");
            TextBox tx_course_id = (TextBox)row.FindControl("tx_course_id");
            TextBox txt_c_id = (TextBox)row.FindControl("txt_c_id");
            c_id = CDataConverter.ConvertToInt(txt_c_id.Text);
            txt_course = tx_course_id.Text;
            TextBox txt_emp = (TextBox)row.FindControl("txt_emp_id");
            PMP_ID = CDataConverter.ConvertToInt(txt_emp.Text);

            if (!string.IsNullOrEmpty(rb.SelectedValue))
            {
                status = rb.SelectedValue;
                string comment = tx_comment.Text;
                string r_id = tx_id.Text;

                id = CDataConverter.ConvertToInt(r_id);

                course_employee_DB.updateemployeestatus(id, status, comment);
            }
            //else if (rb.SelectedValue == null || rb.SelectedValue=="")
            //{
            //    status = "3";
            //}

        }
        Fil_Grid();
       
        //}
        //----------------------------------------------------------------------------------
       //Check if there is any employees in the list or not before calling sendnewcourseemail
        if( PMP_ID > 0 )//There was an employee chosen to send an email to him 
         sendnewcoursemail();
        //----------------------------------------------------------------------------------

        }

    protected void gv_viewuserrequest_DataBound(object sender, EventArgs e)
    {
       
       
    }
    public void sendnewcoursemail()
    {
        int course_employee_id = Convert.ToInt32(Request["id"]);
        
        //course_employee_DT ceDT = new course_employee_DT();
        //ceDT = course_employee_DB.SelectByID(course_employee_id);
        //course_DT cDT = new course_DT();
        //cDT = course_DB.SelectByID(0, ceDT.course_id);

        DataTable dtcourse = General_Helping.GetDataTable("SELECT   course_employee.*,course.*,courses.course_name,Course_Places.place_desc  FROM  courses inner join course on course.course_id=courses.course_id inner join  Course_Places on course.course_place = Course_Places.place_id inner join course_employee on course_employee.course_id=course.id      where course_employee.emp_id='" + PMP_ID  + "' and course.id ='" + CDataConverter.ConvertToInt(c_id) + "' ");


        ////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////// Sending Mail Code /////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////
        bool flag = false;


        DataTable dt_getmail = General_Helping.GetDataTable("select mail,pmp_name from employee where pmp_id='" + PMP_ID + "'");
        string name = "";
        string Succ_names = "", Failed_name = "";

        string mail = dt_getmail.Rows[0]["mail"].ToString();
        string parent_name = dt_getmail.Rows[0]["pmp_name"].ToString();

        MailMessage _Message = new MailMessage();
        string str_subj = "نتيجه طلب الالتحاق بالدوره التدريبيه-من المدير المباشر" + dtcourse.Rows[0]["course_name"].ToString();



        string str_witoutn = str_subj.Replace("\n", "");
        str_subj = str_witoutn.Replace("\r", "");

        if (int.Parse(Session_CS.group_id.ToString()) == 3)
        {

            _Message.Subject = ("INIR" + " - " + str_subj + " - " + CDataConverter.ConvertDateTimeNowRtrnString()).ToString();

        }
        else
        {

            _Message.Subject = "نظام الادارة الالكترونية - التدريب" + " - " + str_subj + " - " + CDataConverter.ConvertDateTimeNowRtrnString();
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

        _Message.Body += " <h3 > " + "     وصلكم  وارد من المدير المباشر بخصوص الدوره التدريبيه" + "<br/>" + "<h3 style=" + "color:blue >" + dtcourse.Rows[0]["course_name"].ToString() + "</h3>";

        if (dtcourse.Rows[0]["status"].ToString() == "1")
        {
            _Message.Body += "<h3 >   بان نتيجه الطلب  هي : القبول   </h3> ";

            
        }
        else if (dtcourse.Rows[0]["status"].ToString() == "2")
        {
            _Message.Body += "<h3 >   بان نتيجه الطلب هي الرفض ويرجي الرجوع للمدير المباشر لمعرفه الاسباب    </h3> ";

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
    protected void gv_viewuserrequest_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}

