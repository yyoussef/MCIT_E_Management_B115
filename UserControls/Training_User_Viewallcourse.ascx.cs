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

public partial class UserControls_Training_User_Viewallcourse : System.Web.UI.UserControl
{
    Session_CS Session_CS = new Session_CS();
    protected void Page_Load(object sender, EventArgs e)
    {
        fill_GridView();
    
    }
    public void fill_GridView()
    {
        int emp_id= Convert.ToInt32(Session_CS.pmp_id);

        Gv_view_courses.DataSource = course_DB.SelectAll_Cource_Not_Registered(emp_id);

        Gv_view_courses.DataBind();
        

    }
}
