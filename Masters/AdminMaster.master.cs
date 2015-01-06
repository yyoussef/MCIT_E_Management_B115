using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;

public partial class Admin_master : System.Web.UI.MasterPage
{
    //Session_CS Session_CS = new Session_CS();
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["ID"] == null || CDataConverter.ConvertToInt(Session["ID"]) < 0)
        //    Response.Redirect("Default.aspx");
        if (!IsPostBack)
        {
            Footerlab.Text = Footerlab.Text + DateTime.Now.Year.ToString();
            int found_id = CDataConverter.ConvertToInt(Session_CS.foundation_id.ToString());
            DataTable dt = Site_Upload_DB.SelectAll(found_id);
            if (dt.Rows.Count > 0)
            {
                //read the values from database into the site upload dt object
                Site_Upload_DT obj = new Site_Upload_DT();
                obj.File_Name = dt.Rows[0]["File_Name"].ToString();
                obj.File_Ext = dt.Rows[0]["File_Ext"].ToString();
                //load the values into the page controls
                headerImage.ImageUrl = "~/Uploads/SitesPics/" + obj.File_Name + "." + obj.File_Ext;
                
            }

        }
    }

    protected void ImgBtnBack_Clicked(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
    protected void lnklogin_Click(object sender, EventArgs e)
    {
        Session["ID"] = "";
        Session.Clear();
        Session.RemoveAll();
        Response.Redirect("Default.aspx");
    }
   
}
