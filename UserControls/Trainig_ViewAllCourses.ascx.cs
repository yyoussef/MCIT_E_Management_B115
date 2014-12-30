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

public partial class UserControls_Trainig_ViewAllCourses : System.Web.UI.UserControl
{
    //Session_CS Session_CS = new Session_CS();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fill_grid_courses();
        }
        string group_id = Session_CS.group_id.ToString();
    }
  
   
    protected void gv_viewuserrequest_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "RemoveItem")
        {
            course_DB.Delete(CDataConverter.ConvertToInt(e.CommandArgument));
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم الحذف بنجاح')</script>");
            gv_viewuserrequest.DataBind();
        }
        if (e.CommandName == "EditItem")
        {
            DataTable dt = General_Helping.GetDataTable("SELECT        courses.course_id, courses.course_name FROM courses   inner JOIN course ON courses.course_id = course.course_id and id='" + CDataConverter.ConvertToInt(e.CommandArgument) + "'");
          //  string course_name = dt.Rows[0]["course_name"].ToString();
            int id = CDataConverter.ConvertToInt(e.CommandArgument); 

          //  Response.Redirect(string.Format("Page2.aspx?param1={0}&m2={1} &param3={2}", empName, empAddress, strDate));



            Response.Redirect(string.Format("~/MainForm/Training_Add_NewCourse.aspx?type={0}&id={1}", 2, CDataConverter.ConvertToInt(e.CommandArgument)));
        }
    }

    protected void gv_viewuserrequest_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv_viewuserrequest.PageIndex = e.NewPageIndex;
         fill_grid_courses();
    }

    private void fill_grid_courses()
    {
        DataTable dt = General_Helping.GetDataTable("set dateformat dmy SELECT course.id, Courses.course_id, Courses.course_name, course.last_register_date,course.emp_no, course.created_by, course.organization, course.comments, course.candidate_criteria, course.duration, course.refrences, course.refrance_file, course.inbox_id, Course_Places.place_desc, Course_Tracks.track_name FROM Courses INNER JOIN course ON Courses.course_id = course.course_id INNER JOIN Course_Places ON Course_Places.place_id = course.course_place INNER JOIN EMPLOYEE AS EMPLOYEE_1 ON EMPLOYEE_1.PMP_ID = course.created_by INNER JOIN Course_Tracks ON Courses.course_id = Course_Tracks.course_id order by convert(datetime, course.last_register_date) desc");
        gv_viewuserrequest.DataSource = dt;
        gv_viewuserrequest.DataBind();
    }
}
