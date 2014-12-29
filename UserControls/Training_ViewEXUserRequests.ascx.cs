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

public partial class UserControls_Training_ViewEXUserRequests : System.Web.UI.UserControl
{
    Session_CS Session_CS = new Session_CS();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            gv_viewuserrequest.DataSource = course_DB.Select_Courses_Emlployee_Manager(CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()), "2");
            gv_viewuserrequest.DataBind();
        }
    }
}
