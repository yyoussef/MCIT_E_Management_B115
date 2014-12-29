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

public partial class Masters_MainMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["ID"] == null || CDataConverter.ConvertToInt(Session["ID"]) < 0)
          //  Response.Redirect("Default.aspx");

        if (!IsPostBack)
        {
            Footerlab.Text = Footerlab.Text + DateTime.Now.Year.ToString();

            //if (Session["CourtName"] != null)
            //    Label1.Text = Session["CourtName"].ToString();
            int found_id = 0;//CDataConverter.ConvertToInt(Session_CS.foundation_id.ToString());
            DataTable dt = Site_Upload_DB.SelectAll(found_id);
            if (dt.Rows.Count > 0)
            {
                Site_Upload_DT obj = new Site_Upload_DT();
                obj.File_Name = dt.Rows[0]["File_Name"].ToString();
                obj.File_Ext = dt.Rows[0]["File_Ext"].ToString();
                headerImage.ImageUrl = "~/Uploads/SitesPics/" + obj.File_Name + "." + obj.File_Ext;
            }


        }
    }

    protected void ImgBtnBack_Clicked(object sender, EventArgs e)
    {
    }
}
