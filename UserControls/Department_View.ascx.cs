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

public partial class UserControls_Department_View : System.Web.UI.UserControl
{
    //Session_CS Session_CS = new Session_CS();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void gv_dept_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "RemoveItem")
        {

            Departments_DB.Delete(CDataConverter.ConvertToInt(e.CommandArgument));
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم الحذف بنجاح')</script>");
            gv_dept.DataBind();
        }
        if (e.CommandName == "EditItem")
        {
            Response.Redirect("~/WebForms/Department_Save_Update.aspx?id=" + CDataConverter.ConvertToInt(e.CommandArgument));

        }
    }

}