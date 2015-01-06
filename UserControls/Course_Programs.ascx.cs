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
    //Session_CS Session_CS = new Session_CS();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(! IsPostBack )
        {
        fill_grid();
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Course_Programs_DT obj = new Course_Programs_DT();
        obj.prog_name = txt_prog_name.Text.Trim();
        obj.prog_id = CDataConverter.ConvertToInt(prog_id.Value );
        //-------------------------------------------------------------
        //Check if a program has been added before with that name
        string sqlComm = "SELECT * FROM Course_Programs WHERE prog_name='" + obj.prog_name + "'";
        SqlDataReader reader = SqlHelper.ExecuteReader(Database.ConnectionString, CommandType.Text, sqlComm);
        if (reader.HasRows)//This program name does exist before
        {
            Page.RegisterStartupScript("Error", "<script language=javascript>alert('اسم هذا البرنامج موجود من قبل')</script>");
            return;//Will not continue to save to prevent repeated names
        }
        //Else will go ahead for saving or updating
        //--------------------------------------------------------------

        obj.prog_id = Course_Programs_DB.Save(obj );
        prog_id.Value =
        txt_prog_name.Text = "";
        if (obj.prog_id  > 0)
        {
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('تم الحفظ بنجاح')</script>");
            fill_grid();

        }    



    }

    private void fill_grid()
    {
        DataTable dt = Course_Programs_DB.SelectAll();
        gvprog.DataSource = dt;
        gvprog.DataBind();

    }
    protected void gvprog_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Show")
        {
            Course_Programs_DT  obj = Course_Programs_DB.SelectByID (CDataConverter.ConvertToInt(e.CommandArgument));
            prog_id .Value = obj.prog_id .ToString();
            txt_prog_name.Text = obj.prog_name .ToString();
          


        }
        else if (e.CommandName == "dlt")
        {
            Course_Programs_DB.Delete(CDataConverter.ConvertToInt(e.CommandArgument));
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('تم الحذف بنجاح')</script>");
            fill_grid();
            
            prog_id.Value =
        txt_prog_name.Text = "";
            

        }
    }
}
