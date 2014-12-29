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
using System.Data.SqlClient;

public partial class WebForms_Protocol_Main_Search : System.Web.UI.Page
{
   
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
           // string Query = " SELECT Proj_id, Proj_Title FROM Project where Protocol_ID is not null ";
           // string Value_Field = "Proj_id";
           // string Text_Field = "Proj_Title";
           // Smart_Project.sql_Connection = sql_Connection;
           // Smart_Project.Query = Query;
           //Smart_Project.Value_Field = Value_Field;
           //Smart_Project.Text_Field = Text_Field;
           // Smart_Project.DataBind();
        }
    }
}
