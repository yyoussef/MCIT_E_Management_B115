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

public partial class UserControls_Course_Programs : System.Web.UI.UserControl
{
    Session_CS Session_CS = new Session_CS();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fill_grid();
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Course_Places_DT obj = new Course_Places_DT();
        obj.place_desc = txt_place_name.Text.Trim();
        obj.place_id  = CDataConverter.ConvertToInt(place_id .Value );
        //-------------------------------------------------------------
        //Check if a place has been added before with that name
        string sqlComm = "SELECT * FROM Course_Places WHERE place_desc='" + obj.place_desc+"'";
        SqlDataReader reader = SqlHelper.ExecuteReader(Database.ConnectionString, CommandType.Text, sqlComm);
        if (reader.HasRows)//This place name does exist 
        {
            Page.RegisterStartupScript("Error", "<script language=javascript>alert('هذا المكان موجود من قبل')</script>");
            return;//Will not continue to save to prevent repeated names
        }
        //Else will go ahead for saving or updating
        //--------------------------------------------------------------
        obj.place_id = Course_Places_DB.Save(obj);
        place_id .Value =
        txt_place_name.Text = "";
        if (obj.place_id   > 0)
        {
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('تم الحفظ بنجاح')</script>");
            fill_grid();

        }    



    }

    private void fill_grid()
    {
        DataTable dt = Course_Places_DB.SelectAll();
        gvplaces.DataSource = dt;
        gvplaces.DataBind();

    }
    protected void gvprog_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Show")
        {
            Course_Places_DT  obj = Course_Places_DB.SelectByID  (CDataConverter.ConvertToInt(e.CommandArgument));
            place_id  .Value = obj.place_id  .ToString();
            txt_place_name.Text = obj.place_desc.ToString();
          


        }
        else if (e.CommandName == "dlt")
        {
            Course_Places_DB.Delete(CDataConverter.ConvertToInt(e.CommandArgument));
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('تم الحذف بنجاح')</script>");
            fill_grid();
            place_id.Value =
       txt_place_name.Text = "";

        }
    }
}
