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

public partial class WebForms_Training_UserDeleteCourseRequest : System.Web.UI.Page
{
    Session_CS Session_CS = new Session_CS();
    protected void Page_Load(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(Request["id"]);
        
            course_employee_DB.Delete(id);
            Response.Redirect("~/WebForms/Training_ViewUserRegisteredCourses.aspx");
        

        //int course_id = Convert.ToInt32(Request["course_id"]);
        //if (course_id != null)
        //{
        //    course_DB.Delete(course_id);
        //    Response.Redirect("~/WebForms/Trainig_ViewAllCourses.aspx");
        //}
    }
}
