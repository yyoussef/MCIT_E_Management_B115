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


public class BaseControl : System.Web.UI.UserControl 
{
   
    public BaseControl()
    {
       
        //
        // TODO: Add constructor logic here
        //
    }

    protected override void OnLoad(EventArgs e)
    {
        
        base.OnLoad(e);
            //this.MaintainScrollPositionOnPostBack = true;
            
       
       
    }
    
}


