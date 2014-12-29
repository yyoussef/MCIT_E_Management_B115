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

public partial class admin_Organizations_Add : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(! IsPostBack )
        {
            fill_category();

             fillgrid();

        }

    }


    private void fill_category()
    {
       

    }

    private void fill_organizations()
    {
        



    }

    protected void btnSave_Click(object sender, EventArgs e)
    {

        

    }


    private void clear()
    {
        
    }



    private void fillgrid()
    {
       
    }

    protected void gvMain_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        
    }




    protected void ddl_cat_SelectedIndexChanged(object sender, EventArgs e)
    {
       
    }
}
