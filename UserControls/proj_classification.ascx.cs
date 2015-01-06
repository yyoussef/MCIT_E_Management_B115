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

using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;

public partial class UserControls_proj_classification : System.Web.UI.UserControl
{
    string sql,sql_type;
    SqlConnection conn;
    SqlDataAdapter da;
    DataSet ds;
    SqlCommand cmd;

    private string sql_Connection = Database.ConnectionString;
    General_Helping Obj_General_Helping = new General_Helping();
    //Session_CS Session_CS = new Session_CS();
    protected void Page_Load(object sender, EventArgs e)
    {
        conn = new SqlConnection(sql_Connection);
        if (!IsPostBack)
        {
            int pmp = int.Parse(Session_CS.pmp_id.ToString());
           

           

            grid_class_data();
            grid_Type_data();
            if (drop_type.SelectedValue == "1")
            {
                tr_proj.Visible = true;
            }
            else
            {
                tr_proj.Visible = false;
                Smart_Search_Proj.SelectedValue = "";
            }


        }
    }


    //proj_type_view

    public static void ShowAlertMessage(string error)
    {

        Page page = HttpContext.Current.Handler as Page;
        if (page != null)
        {
            error = error.Replace("'", "\'");
            ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('" + error + "');", true);
        }
    }



    protected void SaveButton_Click(object sender, EventArgs e)
    {

        if (Drop_class.SelectedValue != "0" && drop_type.SelectedValue != "0")
        {
            General_Helping.ExcuteQuery("update project set Class_id = " + Drop_class.SelectedValue + " where proj_id = " + CDataConverter.ConvertToInt(Session_CS.Project_id.ToString()));
            /////////////////////////////
            sql_type = "update project set internal_external = " + drop_type.SelectedValue;
            if (Smart_Search_Proj.SelectedValue != "")
            {
                sql_type += ",connected_to_proj = " + Smart_Search_Proj.SelectedValue;
            }
            else
            {
                sql_type += ",connected_to_proj = 0";
            }
            sql_type += " where proj_id = " + CDataConverter.ConvertToInt(Session_CS.Project_id.ToString());

            General_Helping.ExcuteQuery(sql_type);


            ShowAlertMessage("تم التعديل بنجاح");
        }
        else
        {
            ShowAlertMessage("يجب اختيار الخطة التابع لها ونوعية المشروع");
            return;
        }
        drop_type.SelectedValue = "0";
        Smart_Search_Proj.SelectedValue = "0";
        grid_class_data();
        grid_Type_data();
       
    }
   
    protected void grid_class_data()
    {
       // int pmp = int.Parse(Session_CS.pmp_id.ToString());
        DataTable dt = General_Helping.GetDataTable("SELECT  * from proj_class_view where proj_class_view.proj_id= " + CDataConverter.ConvertToInt(Session_CS.Project_id.ToString()));
        if (dt.Rows[0]["id"].ToString()=="")
        {
            Drop_class.SelectedValue = "0";
        }
        else
        Drop_class.SelectedValue = dt.Rows[0]["id"].ToString();

       
    }
    protected void grid_Type_data()
    {
        //int pmp = int.Parse(Session_CS.pmp_id.ToString());
        DataTable dt = General_Helping.GetDataTable("SELECT  * from proj_Type_view where proj_Type_view.proj_id= " + CDataConverter.ConvertToInt(Session_CS.Project_id.ToString()));
        if (dt.Rows[0]["Type_id"].ToString() == "")
        {
            drop_type.SelectedValue = "0";
        }
        else
        {
            drop_type.SelectedValue = dt.Rows[0]["Type_id"].ToString();
            Smart_Search_Proj.SelectedValue = dt.Rows[0]["connected_to_proj"].ToString();
        }

      
    }
    public string Get_Name()
    {
        return "ttt";
    }

   
    protected override void OnInit(EventArgs e)
    {
       

     
        Smart_Search_Proj.sql_Connection = sql_Connection;
       // Smart_Search_Proj.Query = "SELECT Proj_id, Proj_Title FROM Project ";
        string Query = "SELECT Proj_id, Proj_Title FROM Project ";
        Smart_Search_Proj.datatble = General_Helping.GetDataTable(Query);
        Smart_Search_Proj.Value_Field = "Proj_id";
        Smart_Search_Proj.Text_Field = "Proj_Title";
        Smart_Search_Proj.DataBind();

       
        base.OnInit(e);
    }
    //protected void gvMain_RowCommand(object sender, GridViewCommandEventArgs e)
    //{
    //    int pmp = int.Parse(Session_CS.pmp_id.ToString());
    //    DataTable dt = General_Helping.GetDataTable("select * from proj_class_view where proj_class_view.proj_id =  " + e.CommandArgument);
    //    //Smart_Search_Proj.SelectedValue = dt.Rows[0]["proj_id"].ToString();
    //    if (dt.Rows[0]["id"].ToString() == "")
    //    {
    //        Drop_class.SelectedValue = "0";
    //    }
    //    else
    //    {
    //        Drop_class.SelectedValue = dt.Rows[0]["id"].ToString();
    //    }


    //}
    //protected void gv_type_RowCommand(object sender, GridViewCommandEventArgs e)
    //{
    //    //int pmp = int.Parse(Session_CS.pmp_id.ToString());
    //    DataTable dt = General_Helping.GetDataTable("select * from proj_Type_view where proj_Type_view.proj_id =  " + e.CommandArgument);
    //    //Smart_Search_Proj.SelectedValue = dt.Rows[0]["proj_id"].ToString();
    //    if (dt.Rows[0]["type_id"].ToString() == "")
    //    {
    //        drop_type.SelectedValue = "0";
    //    }
    //    else
    //    {
    //        drop_type.SelectedValue = dt.Rows[0]["type_id"].ToString();
    //        Smart_Search_Proj.SelectedValue = dt.Rows[0]["connected_to_proj"].ToString();
    //    }


    ////}
    //protected void gvMain_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{

    //}
   
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
    }


    protected void drop_type_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drop_type.SelectedValue == "1")
        {
            tr_proj.Visible = true;
        }
        else
        {
            tr_proj.Visible = false;
            Smart_Search_Proj.SelectedValue = "";
        }
    }
}
