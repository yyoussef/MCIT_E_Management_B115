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

public partial class UserControls_sector_view : System.Web.UI.UserControl
{
    //Session_CS Session_CS = new Session_CS();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void gv_sector_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "RemoveItem")
        {
            Sectors_DB.Delete(CDataConverter.ConvertToInt(e.CommandArgument));
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم الحذف بنجاح')</script>");
            gv_sector.DataBind();
        }
        if (e.CommandName == "EditItem")
        {
            Response.Redirect("Sector_save_update.aspx?id=" + CDataConverter.ConvertToInt(e.CommandArgument));
        }
    }
}
