using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Geekees.Common.Controls.Demo
{
	public partial class Header : System.Web.UI.UserControl
    {
        Session_CS Session_CS = new Session_CS();
		protected string ASTreeViewVersion
		{
			get
			{
				return typeof( ASTreeView ).Assembly.GetName().Version.ToString();
			}
		}

		protected void Page_Load( object sender, EventArgs e )
		{

		}
	}
}