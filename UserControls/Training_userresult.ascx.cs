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

public partial class UserControls_Training_userresult : System.Web.UI.UserControl
{
    int course_employee_id;
    //Session_CS Session_CS = new Session_CS();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            int type = Convert.ToInt32(Request["type"]);

            course_employee_id = Convert.ToInt32(Request["id"]);
            DataTable dt_sub_cat = General_Helping.GetDataTable(" SELECT  courses.course_name AS coursename, EMPLOYEE.pmp_name AS empname, course.start_date AS startdate,course.end_date AS enddate, course_employee.comment, course_employee.admin_descion AS admindescion, course_employee.course_id, course_employee.emp_id, course_employee.id, course_employee.status,result FROM  course_employee INNER JOIN  course ON course_employee.course_id = course.id  INNER JOIN courses ON courses.course_id = course.course_id   INNER JOIN    EMPLOYEE ON course_employee.emp_id = EMPLOYEE.PMP_ID    WHERE course_employee.id= " + course_employee_id);
            //tx_employeename.Text = dt_sub_cat.Rows[0]["empname"].ToString();
            txt_coursename.Text = dt_sub_cat.Rows[0]["coursename"].ToString();

            ddl_result.SelectedValue = dt_sub_cat.Rows[0]["result"].ToString();
          
            fill_result();
            if (type == 2)
            {
                fillcontrols();
            }
        }
    }

    private void  fill_result()
    {
        DataTable dt_sub_cat = General_Helping.GetDataTable(" SELECT course_files.* FROM  course_files inner join course_employee on course_employee.course_id=course_files.course_id WHERE   course_employee.id = " + Convert.ToInt32(Request["id"]) + " and type_id=3");
                gv_referancefile.DataSource = dt_sub_cat;
                gv_referancefile.DataBind();  
       
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (ddl_result.SelectedValue != "0")
        {
            int resulttype = Convert.ToInt32(Request["type"]);

            if (resulttype == 1)
            {
                int id = Convert.ToInt32(Request["id"]);
                course_employee_DT cedt = new course_employee_DT();
                cedt = course_employee_DB.SelectByID(id);

                int result = Convert.ToInt32(ddl_result.SelectedItem.Value);

                course_employee_DB.updateemployeeresult(id, result);
                if (FileUpload1.HasFile)
                {
                    string DocName = FileUpload1.FileName;
                    int dotindex = DocName.LastIndexOf(".");
                    string type = DocName.Substring(dotindex, DocName.Length - dotindex);

                    Stream myStream;
                    int fileLen;
                    System.Text.StringBuilder displayString = new StringBuilder();
                    fileLen = FileUpload1.PostedFile.ContentLength;
                    Byte[] Input = new Byte[fileLen];
                    myStream = FileUpload1.FileContent;
                    myStream.Read(Input, 0, fileLen);


                    SqlCommand cmd = new SqlCommand();
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "INSERT INTO [course_files] ( [course_id], [file_path],[file_name],[type_id]) VALUES (@course_id,@file_path,@file_name,3 )";



                    cmd.Parameters.Add("@course_id", SqlDbType.Int);
                    cmd.Parameters.Add("@file_path", SqlDbType.VarBinary);
                    cmd.Parameters.Add("@file_name", SqlDbType.NVarChar);

                    cmd.Parameters["@course_id"].Value = cedt.course_id;
                    cmd.Parameters["@file_path"].Value = Input;
                    cmd.Parameters["@file_name"].Value = DocName;


                    con.Open();
                    cmd.ExecuteScalar();

                    con.Close();

                    DataTable dt_sub_cat = General_Helping.GetDataTable(" SELECT course_files.* FROM  course_files WHERE   course_id = " + cedt.course_id + " and type_id=3");
                    gv_referancefile.DataSource = dt_sub_cat;
                    gv_referancefile.DataBind();

                }

                sendnewcoursemail();


            }
            else if (resulttype == 2)
            {

                fillcontrols();
                Response.Redirect("~/WebForms/Training_adminapprove.aspx");

            }
        }

        else
        {
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('يجب إختيار النتيجة')</script>");

        }
    }
    private void fillcontrols()
    {
        int id = Convert.ToInt32(Request["id"]);
        course_employee_DT cedt = new course_employee_DT();
        cedt = course_employee_DB.SelectByID(id);
        DataTable dt_sub_cat = General_Helping.GetDataTable("SELECT  courses.course_name AS coursename, EMPLOYEE.pmp_name AS empname, course.start_date AS startdate, course.end_date AS enddate,course_employee.comment, course_employee.admin_descion AS admindescion, course_employee.course_id, course_employee.emp_id, course_employee.id, course_employee.status,result FROM  course_employee INNER JOIN  course ON course_employee.course_id = course.id INNER JOIN  courses on   course.course_id = courses.course_id INNER JOIN     EMPLOYEE ON course_employee.emp_id = EMPLOYEE.PMP_ID WHERE course_employee.id="+id);
        //tx_employeename.Text = dt_sub_cat.Rows[0]["empname"].ToString();
        txt_coursename.Text = dt_sub_cat.Rows[0]["coursename"].ToString();
        ddl_result.SelectedValue = dt_sub_cat.Rows[0]["result"].ToString();
        //HyperLink1.NavigateUrl = "ALL_Document_Details.aspx?type=trainingresult&id="+dt_sub_cat.Rows[1]["id"];
        filerow.Visible = false;
        hyperlinkrow.Visible = true;

        filerow.Visible = false;
        //buttonrow.Visible = false;
        //tx_employeename.Enabled = false;
        txt_coursename.Enabled = false;
        ddl_result.Enabled = false;
        DataTable dt_sub_cat2 = General_Helping.GetDataTable(" SELECT course_files.* FROM  course_files WHERE   course_id = " + cedt.course_id + " and type_id=3");
        gv_referancefile.DataSource = dt_sub_cat2;
        gv_referancefile.DataBind();

        Button1.Text = "عوده";

        
    }
    protected void gv_referancefile_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "RemoveItem")
        {
            course_files_DB.Delete(CDataConverter.ConvertToInt(e.CommandArgument));
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم الحذف بنجاح')</script>");

            DataTable dt_sub_cat = General_Helping.GetDataTable(" SELECT course_files.* FROM  course_files WHERE   course_id = " + course_employee_id+ "and type_id=3");
            gv_referancefile.DataSource = dt_sub_cat;
            gv_referancefile.DataBind();
        }
    }




    public void sendnewcoursemail()
    {

        ////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////// Sending Mail Code /////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////
        bool flag = false;
        DataTable dt_getmail = new DataTable();

        dt_getmail = General_Helping.GetDataTable("SELECT EMPLOYEE.pmp_name,EMPLOYEE.pmp_id,EMPLOYEE.mail,course_employee.result,course_employee.course_id as courseid ,Courses.course_name FROM  course_employee INNER JOIN  course ON course_employee.course_id = course.id  INNER JOIN courses ON courses.course_id = course.course_id  INNER JOIN EMPLOYEE ON course_employee.emp_id = EMPLOYEE.PMP_ID  where course_employee.id='" + CDataConverter.ConvertToInt(Request["id"]) + "'");
        string name = "";
        string Succ_names = "", Failed_name = "";
     
        string mail = dt_getmail.Rows[0]["mail"].ToString();
        string parent_name = dt_getmail.Rows[0]["pmp_name"].ToString();

        MailMessage _Message = new MailMessage();
        string str_subj = "الإعلان عن نتيجة دورة تدريبيه ";



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
        _Message.Body = "<html><body dir='rtl'><h3 >";



        _Message.Body += " <h3 > " + "   وصلكم وارد من اداره الدورات التدريبيه بقطاع البنيه المعلوماتيه بخصوص الدوره التدريبيه" + "<br/>" + "<h3 style=" + "color:blue >" + dt_getmail.Rows[0]["course_name"].ToString() + "</h3>";
        if (ddl_result.SelectedValue == "1")
        {
            _Message.Body += " <h3 > " + "  بان النتيجة هي النجاح ";
        }
        else if (ddl_result.SelectedValue == "2")
        {
            _Message.Body += " <h3 > " + " بان النتيجه هي الرسوب " ;
        }
        else if (ddl_result.SelectedValue == "3")
        {
            _Message.Body += " <h3 > " + " بان النتيجه  هي  معتذر ";
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

       


    }



}
