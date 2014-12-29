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

public partial class UserControls_change_proj_status : System.Web.UI.UserControl
{
    string sql;
    SqlConnection conn;
    SqlDataAdapter da;
    DataSet ds; 
    private string sql_Connection = Database.ConnectionString;
    General_Helping Obj_General_Helping = new General_Helping();
    Session_CS Session_CS = new Session_CS();
    protected void Page_Load(object sender, EventArgs e)
    {
        conn = new SqlConnection(sql_Connection);
        if (!IsPostBack)
        {
            string sql = "select * from Proj_status ";
            ds = new DataSet();
            da = new SqlDataAdapter(sql, conn);
            da.Fill(ds, "status");
            ddl_status.DataSource = ds.Tables[0];
            ddl_status.DataValueField = "id";
            ddl_status.DataTextField = "status";
            ddl_status.DataBind();
            ddl_status.Items.Insert(0, new ListItem("اختر الحالة......", "0"));

           
           
           
        }
    }
    protected override void OnInit(EventArgs e)
    {

      

        smart_proj.sql_Connection = sql_Connection;
        //smart_proj.Query = "SELECT Proj_id, Proj_Title FROM Project ";
        string Query = "SELECT Proj_id, Proj_Title FROM Project ";
        smart_proj.datatble = General_Helping.GetDataTable(Query);
        smart_proj.Value_Field = "Proj_id";
        smart_proj.Text_Field = "Proj_Title";
        smart_proj.DataBind();
        this.smart_proj.Value_Handler += new Smart_Search.Delegate_Selected_Value(MOnMember_Data_proj);
        
       
        base.OnInit(e);


    }
    private void MOnMember_Data_proj(string Value)
    {
        changestatus();
    }

    private void changestatus()
    {
        //Project_DT obj = Project_DB.SelectByID(CDataConverter.ConvertToInt( smart_proj.SelectedValue));
        DataTable dt = General_Helping.GetDataTable("select * from Project where  Proj_id = " + CDataConverter.ConvertToInt(smart_proj.SelectedValue));
        if (dt.Rows[0]["Proj_is_commit"].ToString() == "2")
        {
            ddl_status.SelectedValue = "1";
        }
        else if (CDataConverter.ConvertToInt( dt.Rows[0]["Proj_is_commit"].ToString()) == 4)
        {
            ddl_status.SelectedValue = "2";
        }
        else if (CDataConverter.ConvertToInt(dt.Rows[0]["Proj_is_commit"].ToString()) == 5)
        {
            ddl_status.SelectedValue = "3";
        }
        else if (CDataConverter.ConvertToInt(dt.Rows[0]["Proj_is_commit"].ToString()) == 1)
        {
            ddl_status.SelectedValue = "4";
        }
        else if (CDataConverter.ConvertToInt(dt.Rows[0]["Proj_is_commit"].ToString()) == 3)
        {
            ddl_status.SelectedValue = "5";
        }
        else if (CDataConverter.ConvertToInt(dt.Rows[0]["Proj_is_commit"].ToString()) == 0 && CDataConverter.ConvertToInt(dt.Rows[0]["Proj_is_repeated"].ToString()) == 1)
        {
            ddl_status.SelectedValue = "6";
        }
        else if (CDataConverter.ConvertToInt(dt.Rows[0]["Proj_is_commit"].ToString()) == 0 && CDataConverter.ConvertToInt(dt.Rows[0]["Proj_is_refused"].ToString()) == 1)
        {
            ddl_status.SelectedValue = "7";
        }
        else if (CDataConverter.ConvertToInt(dt.Rows[0]["Proj_is_commit"].ToString()) == 7)
        {
            ddl_status.SelectedValue = "8";
        }
        else if (CDataConverter.ConvertToInt(dt.Rows[0]["Proj_is_commit"].ToString()) == 6)
        {
            ddl_status.SelectedValue = "9";
        }
        else if (CDataConverter.ConvertToInt(dt.Rows[0]["Proj_is_commit"].ToString()) == 8)
        {
            ddl_status.SelectedValue = "10";
        }
       
    }
    protected void FillGrid()
    {
        //string sql = "";
        //int group = CDataConverter.ConvertToInt(Session_CS.group_id.ToString());
        
        //    sql = "select * from Inbox_Main_Categories where id <>" + 1 + " and group_id = " + group ;
      
        //DataTable dt = General_Helping.GetDataTable(sql);

        //gvMain.DataSource = dt;
        //gvMain.DataBind();

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
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (smart_proj.SelectedValue != "")
        {
            sql = "update Project ";
            if (ddl_status.SelectedValue=="1")
            {
                sql += " set Proj_is_commit = 2 ";
            }
            else if (ddl_status.SelectedValue == "2")
            {
                sql += " set Proj_is_commit = 4 ";
            }
            else if (ddl_status.SelectedValue == "3")
            {
                sql += " set Proj_is_commit = 5 ";
            }
            else if (ddl_status.SelectedValue == "4")
            {
                sql += " set Proj_is_commit = 1 ";
            }
            else if (ddl_status.SelectedValue == "5")
            {
                sql += " set Proj_is_commit = 3 ";
            }
            else if (ddl_status.SelectedValue == "6")
            {
                sql += " set Proj_is_commit = 0 , Proj_is_refused =0  , Proj_is_repeated=1 ";
            }
            else if (ddl_status.SelectedValue == "7")
            {
                sql += " set Proj_is_commit = 0 , Proj_is_refused =1  , Proj_is_repeated=0 ";
            }
            else if (ddl_status.SelectedValue == "8")
            {
                sql += " set Proj_is_commit = 7";
            }
            else if (ddl_status.SelectedValue == "9")
            {
                sql += " set Proj_is_commit = 6";
            }
            else if (ddl_status.SelectedValue == "10")
            {
                sql += " set Proj_is_commit = 8";
            }

            sql += " where Proj_id = "+ CDataConverter.ConvertToInt(smart_proj.SelectedValue);
            General_Helping.ExcuteQuery(sql);
            Project_Log_DB.FillLog(CDataConverter.ConvertToInt(smart_proj.SelectedValue), (int)Project_Log_DB.Action.edit, Project_Log_DB.operation.Fin_Bills);
            ShowAlertMessage("تم التعديل");

        }
        else
        {
            ShowAlertMessage("يجب اختيار مشروع");
            return;
        }
    }
   
    
}
