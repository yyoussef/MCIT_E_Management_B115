using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class UserControls_Hr_Eval_Grid : System.Web.UI.UserControl
{
    private string sql_Connection = Database.ConnectionString;


    //Session_CS Session_CS = new Session_CS();
     protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            General_Helping obj = new General_Helping();
            DataTable DT = General_Helping.GetDataTable("select Sec_id,Sec_name from Sectors");
            obj.SmartBindDDL(Ddl_Sectors, DT, "Sec_id", "Sec_name", "-- اختر الإدارة");
            //Ddl_Sectors.DataBind();
            //Ddl_Sectors.SelectedValue = Session_CS.sec_id.ToString();
            //fil_Departements();
            Load_Grid();
            
                   

               

          }
        }
        
   
   


    protected void gvMain_PageIndexChanging(object sender, GridViewPageEventArgs e)
     {
        //if (sec_id == 0 && dept_id == 0)
        //{
            gvMain.PageIndex = e.NewPageIndex;

            Load_Grid();
        //}
        //else if (sec_id >= 0 && dept_id == 0)
        //{
        //    Load_Grid_filtering();
        //}
        //else if (sec_id == 0 && dept_id >= 0)
        //{
        //    Load_Grid_filtering();
        //}
        //else if (sec_id >=1  && dept_id >= 1)
        //{
        //    Load_Grid_filtering();
        //}

       
    }

    //private void Load_Grid_filtering()
    //{
    //    if (Request["type"] != null)
    //    {
    //        SqlParameter[] parms = new SqlParameter[2];

    //        parms[0] = new SqlParameter();
    //        parms[0].Direction = ParameterDirection.Input;
    //        parms[0].Value = sec_id;
    //        parms[0].ParameterName = "@sec_id";
    //        parms[0].SqlDbType = SqlDbType.Int;
    //        parms[0].Size = 4;

    //        parms[1] = new SqlParameter();
    //        parms[1].Direction = ParameterDirection.Input;
    //        parms[1].Value = dept_id;
    //        parms[1].ParameterName = "@dept_id";
    //        parms[1].SqlDbType = SqlDbType.Int;
    //        parms[1].Size =4;


    //        if (Request["type"].ToString() == "1")
    //        {
    //            lblMain.Text = "الموظفين الذى تم تقييمهم من المدير المباشر";
    //            DataTable dt = SqlHelper.ExecuteDataset(Database.ConnectionString, "Evaluation_For_HR_mng_filter", parms).Tables[0];
    //            gvMain.DataSource = dt;
    //            gvMain.DataBind();

    //        }
    //        else if (Request["type"].ToString() == "2")
    //        {
    //            lblMain.Text = "الموظفين الذى تم تقييمهم من المدير الأعلى";
    //            DataTable dt = SqlHelper.ExecuteDataset(Database.ConnectionString, "Evaluation_For_HR_Top",parms).Tables[0];
    //            gvMain.DataSource = dt;
    //            gvMain.DataBind();

    //        }
    //        else if (Request["type"].ToString() == "3")
    //        {
    //            lblMain.Text = "الموظفين الذى لم يتم تقييمهم ";
    //            DataTable dt = SqlHelper.ExecuteDataset(Database.ConnectionString, "Evaluation_For_dt_Not_Eval_filter", parms).Tables[0];
    //            gvMain.DataSource = dt;
    //            gvMain.DataBind();

    //        }

    //    }
    //}
    public void  Load_Grid()
    {
        if (Request["type"] != null)
        {

            if (Request["type"].ToString() == "1")
            {
                lblMain.Text = "الموظفين الذى تم تقييمهم من المدير المباشر";
                DataTable dt = SqlHelper.ExecuteDataset(Database.ConnectionString, "Evaluation_For_HR_Manage", CDataConverter.ConvertToInt(Ddl_Sectors.SelectedValue), CDataConverter.ConvertToInt(Smart_Search_Departments.SelectedValue)).Tables[0];
                gvMain.DataSource = dt;
                gvMain.DataBind();

            }
            else if (Request["type"].ToString() == "2")
            {
                lblMain.Text = "الموظفين الذى تم تقييمهم من المدير الأعلى";
                DataTable dt = SqlHelper.ExecuteDataset(Database.ConnectionString, "Evaluation_For_HR_Top", CDataConverter.ConvertToInt(Ddl_Sectors.SelectedValue), CDataConverter.ConvertToInt(Smart_Search_Departments.SelectedValue)).Tables[0];
                gvMain.DataSource = dt;
                gvMain.DataBind();

            }
            else if (Request["type"].ToString() == "3")
            {
                lblMain.Text = "الموظفين الذى لم يتم تقييمهم ";
                DataTable dt = SqlHelper.ExecuteDataset(Database.ConnectionString, "Evaluation_For_dt_Not_Eval", CDataConverter.ConvertToInt(Ddl_Sectors.SelectedValue), CDataConverter.ConvertToInt(Smart_Search_Departments.SelectedValue)).Tables[0];
                gvMain.DataSource = dt;
                gvMain.DataBind();

            }
        }
    }

    protected void gvMain_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "show")
        {
            Response.Redirect("Eval_For_Employee.aspx?PMP_id=" + e.CommandArgument);
        }


    }
    void fil_Departements()
    {

        Smart_Search_Departments.sql_Connection = sql_Connection;

        //Smart_Search_Departments.Query = " select distinct Dept_ID,Dept_name from Employee_Departments WHERE sec_sec_id =  " + Ddl_Sectors.SelectedValue;
        string Query = " select distinct Dept_ID,Dept_name from Employee_Departments WHERE sec_sec_id =  " + Ddl_Sectors.SelectedValue;
        if (Session_CS.Hr_Eval.ToString() != "1")
            Query += " and  pmp_id = " + Session_CS.pmp_id.ToString();
        Smart_Search_Departments.datatble = General_Helping.GetDataTable(Query);
        Smart_Search_Departments.Value_Field = "Dept_ID";
        Smart_Search_Departments.Text_Field = "Dept_name";
        Smart_Search_Departments.DataBind();
        this.Smart_Search_Departments.Value_Handler += new Smart_Search.Delegate_Selected_Value(MOnMember_Data_Depart);
       // Smart_Search_Departments.SelectedValue = Session_CS.dept_id.ToString();
        //dept_id = Convert.ToInt32(Smart_Search_Departments.SelectedValue);
    }

         protected void Ddl_Sectors_SelectedIndexChanged(object sender, EventArgs e)
    {
        fil_Departements();
        //  Ddl_Department.DataBind();
        
    }
         private void MOnMember_Data_Depart(string Value)
         {
            
            
         }


         protected void search_button_Click(object sender, EventArgs e)
         {

             Load_Grid();

         }
    
        
}
