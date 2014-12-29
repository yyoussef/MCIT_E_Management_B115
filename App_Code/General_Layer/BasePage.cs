using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Threading;
using System.Globalization;


public class BasePage : System.Web.UI.Page  
{
    public BasePage()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    protected override void OnLoad(EventArgs e)
    {
        Session_CS Session_CS = new Session_CS();
        base.OnLoad(e);
            this.MaintainScrollPositionOnPostBack = true;
            
       
       
    }
    
}


