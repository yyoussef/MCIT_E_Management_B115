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

public partial class ProjectGeneralData : System.Web.UI.Page
{
   
    public string strdisplay = string.Empty;
    Session_CS Session_CS = new Session_CS();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            strdisplay = "none";
        }

    }   
}
