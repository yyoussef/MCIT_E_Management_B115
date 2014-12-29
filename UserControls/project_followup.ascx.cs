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
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;
using CrystalDecisions.Shared;
using MCIT.Web.Data;
using DBL;

public partial class UserControls_project_followup : System.Web.UI.UserControl
{
    SqlConnection conn;
    Session_CS Session_CS = new Session_CS();
    private string sql_Connection = Universal.GetConnectionString();

    protected override void OnInit(EventArgs e)
    {
        Smrt_Srch_DropDep.sql_Connection = sql_Connection;
        string Query = "select Dept_ID,Dept_name,Dept_parent_id from Departments where Dept_ID <> 6";
        Smrt_Srch_DropDep.datatble = General_Helping.GetDataTable(Query);
        Smrt_Srch_DropDep.Value_Field = "Dept_ID";
        Smrt_Srch_DropDep.Text_Field = "Dept_name";
        Smrt_Srch_DropDep.DataBind();
        this.Smrt_Srch_DropDep.Value_Handler += new Smart_Search.Delegate_Selected_Value(dropdept_fun);

        Smart_Search_Proj.sql_Connection = sql_Connection;
        string Query1 = "select proj_title,proj_id from project where Proj_is_commit=2";
        Smart_Search_Proj.datatble = General_Helping.GetDataTable(Query1);
        Smart_Search_Proj.Value_Field = "proj_id";
        Smart_Search_Proj.Text_Field = "proj_title";
        Smart_Search_Proj.DataBind();

        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        Smrt_Srch_DropDep.Show_OrgTree = true;
        if (!IsPostBack)
        {

        }
    }

    protected void dropdept_fun(string Value)
    {
        if (Smrt_Srch_DropDep.SelectedValue != "")
        {
            Smart_Search_Proj.sql_Connection = sql_Connection;
            string Query = "select proj_title,proj_id from project where Dept_Dept_id=" + Smrt_Srch_DropDep.SelectedValue;
            Smart_Search_Proj.datatble = General_Helping.GetDataTable(Query);
            Smart_Search_Proj.Value_Field = "proj_id";
            Smart_Search_Proj.Text_Field = "proj_title";
            Smart_Search_Proj.DataBind();
        }
        else
        {
            Smart_Search_Proj.sql_Connection = sql_Connection;
            string Query = "select proj_title,proj_id from project where Proj_is_commit=2";
            Smart_Search_Proj.datatble = General_Helping.GetDataTable(Query);
            Smart_Search_Proj.Value_Field = "proj_id";
            Smart_Search_Proj.Text_Field = "proj_title";
            Smart_Search_Proj.DataBind();
        }
    }

    protected void BtnView_Click(object sender, EventArgs e)
    {
        if (CDataConverter.ConvertToInt(Smart_Search_Proj.SelectedValue) > 0)
        {
            SqlDataAdapter sqladptr = new SqlDataAdapter();
            SqlConnection con = new SqlConnection(sql_Connection);
            SqlCommand obj = new SqlCommand("Get_Proj_Log", con);
            obj.CommandType = CommandType.StoredProcedure;
            switch (ddl_record_type.SelectedValue)
            {
                case "1":
                    obj.Parameters.Add(new SqlParameter("@mode", "1"));
                    break;
                case "2":
                    obj.Parameters.Add(new SqlParameter("@mode", "2"));
                    break;
                case "3":
                    obj.Parameters.Add(new SqlParameter("@mode", "3"));
                    break;
                case "4":
                    obj.Parameters.Add(new SqlParameter("@mode", "4"));
                    break;
                case "5":
                    obj.Parameters.Add(new SqlParameter("@mode", "5"));
                    break;
                case "6":
                    obj.Parameters.Add(new SqlParameter("@mode", "6"));
                    break;
                default:
                    obj.Parameters.Add(new SqlParameter("@mode", "111"));
                    break;
            }
            obj.Parameters.Add(new SqlParameter("@proj_id", Convert.ToInt16(Smart_Search_Proj.SelectedValue)));
            obj.Parameters.Add(new SqlParameter("@record_type", ddl_record_type.SelectedValue));
            con.Open();
            sqladptr.SelectCommand = obj;
            DataTable DT = new DataTable();
            sqladptr.Fill(DT);
            gvMain.DataSource = DT;
            gvMain.DataBind();
            con.Close();
        }
        else
        {
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('يجب إختيار المشروع أولا')</script>");
        }
    }
    protected void gvMain_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string STRprocess = (string)Convert.ToString(DataBinder.Eval(e.Row.DataItem, "process"));
            Label ProcessStat = (Label)e.Row.FindControl("LBLprocess");
            if (STRprocess == "1")
            {
                ProcessStat.Text = "إضافة";
            }
            else if (STRprocess == "2")
            {
                ProcessStat.Text = "تعديل";
            }
            else
            {
                ProcessStat.Text = "إطلاع";
            }
        }
    }
}
