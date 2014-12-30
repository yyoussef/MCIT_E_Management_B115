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
using System.Text;
using System.Data.SqlClient;
using System.IO;

public partial class WebForms_File_Search : System.Web.UI.Page
{
    //Session_CS Session_CS = new Session_CS();
    string sql;
    SqlConnection conn;
    SqlDataAdapter da;
    DataSet ds;
    SqlCommand cmd;
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    public static void ShowAlertMessage(string error)
    {

        Page page = HttpContext.Current.Handler as Page;
        if (page != null)
        {
            error = error.Replace("'", "\'");
            ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('" + error + "');", true);
        }
    }
    public void SearchRecord()
    {
        string t1 = "";
        string t2 = "";
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        sql = "select * from Files where 1=1";
        if (File_name_text.Text!="")
        {
            sql += " AND File_Name like"+"'%"+File_name_text.Text+"%'";
        }
        //if (string.IsNullOrEmpty(File_date_from.Text) && string.IsNullOrEmpty(File_date_to.Text))
        //{

        //    sql += " AND convert(nvarchar(50),File_date)> = " + 1900;
        //    sql += " AND convert(nvarchar(50),File_date) < = " + 3000;
        //}
        //else if (string.IsNullOrEmpty(File_date_from.Text))
        //{


        //    sql += " AND convert(nvarchar(50),File_date) < = " + File_date_to.Text;
        //}
        //else if (string.IsNullOrEmpty(File_date_to.Text))
        //{


        //    sql += " AND convert(nvarchar(50),File_date) > = " + File_date_from.Text;
        //}
        //else
        //{


        //    sql += " AND convert(nvarchar(50),File_date) > = " + File_date_from.Text;
        //    sql += " AND convert(nvarchar(50),File_date) < = " + File_date_to.Text;

        //}
        sql += " OR File_date is NULL order by convert(nvarchar(50),file_date) asc";
        
        conn.Open();
        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        if (dt.Rows.Count == 0)
        {
            gvMain.EmptyDataText = ".....عفوا لا يوجد بيانات ......";
        }
        else
        {
            gvMain.DataSource = dt;
        }
        gvMain.DataBind();
        conn.Close();
    }

    protected void SaveButton_Click(object sender, EventArgs e)
    {
        SearchRecord();
    }

    
    protected void gvMain_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }
    protected void gvMain_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName=="EditItem")
        {
            Response.Redirect("../mainform/FDocuments.aspx?id=" + e.CommandArgument);
        }
        if (e.CommandName == "RemoveItem")
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            conn.Open();

            sql += "delete from files where files_id= " + e.CommandArgument;
            cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();

            gvMain.DataBind();
            
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم الحذف بنجاح')</script>");
            SearchRecord();
        }
       
    }
    protected void gvMain_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvMain.PageIndex = e.NewPageIndex;
        SearchRecord();
    }
}
