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

public partial class WebForms_Company : System.Web.UI.Page
{
    //Session_CS Session_CS = new Session_CS();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        { 
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        string sql = " insert into Fin_Company (Company_Name) VALUES ('" + txt_Company.Text + "') select @@identity";
       int ID = General_Helping.ExcuteQuery(sql);
        //if (Request["postpack"] != null && Request["postpack"].ToString() == "1")
         //   Response.Write("<script>opener.document.forms[0].submit() ;window.close();</script>");
        //else //if (Request["postpack"] != null && Request["postpack"].ToString() == "0")
        string ctrlName = Request.QueryString["field"];
        Response.Write("<script>window.opener.document.getElementById('" + ctrlName + "').value='" + ID + "';opener.document.forms[0].submit() ;window.close();</script>");
    }
}
