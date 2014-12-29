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

public partial class WebForms2_Employee_Depts : System.Web.UI.Page
{
    private string sql_Connection = Database.ConnectionString;
    General_Helping Obj_General_Helping = new General_Helping();
    Session_CS Session_CS = new Session_CS();
    protected override void OnInit(EventArgs e)
    {
        string Query = "";
        Smart_Search_Dept.sql_Connection = sql_Connection;
     
      
        this.Smart_Search_Dept.Value_Handler += new Smart_Search.Delegate_Selected_Value(MOnMember_Data);
        Smart_Search_emp.sql_Connection = sql_Connection;
    
        Query = "select * from employee";
        Smart_Search_emp.datatble = General_Helping.GetDataTable(Query);
        Smart_Search_emp.Text_Field = "pmp_name";
        Smart_Search_emp.Value_Field = "pmp_id";
        Smart_Search_emp.DataBind();

       ////////////////////////////fill departments///////////////////////
        string Query2 = "";
        Query2 = "SELECT  * from    Departments  where foundation_id='" + Session_CS.foundation_id + "'";
        Smart_Search_Dept.datatble = General_Helping.GetDataTable(Query2);
        Smart_Search_Dept.Text_Field = "Dept_name";
        Smart_Search_Dept.Value_Field = "Dept_id";
        Smart_Search_Dept.DataBind();
        
        this.Smart_Search_emp.Value_Handler += new Smart_Search.Delegate_Selected_Value(MOnMember_Data_emp);
    }
    //private void Fill_sector()
    //{
    //    string sql = "select * from sectors";
    //    DataTable dt = General_Helping.GetDataTable(sql);
    //    ddl_sectors.DataSource = dt;
    //    ddl_sectors.DataValueField = "Sec_id";
    //    ddl_sectors.DataTextField = "Sec_name";
    //    ddl_sectors.DataBind();
    //    ddl_sectors.Items.Insert(0, new ListItem("اختر القطاع......", "0"));

    //}
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //Fill_sector();
            Smart_Search_Dept.Show_OrgTree = true;
            fill_structure();
        }
    }
    protected void fill_structure()
    {

        string Query = "";
        Query = "SELECT  * from    Departments  where foundation_id='" + Session_CS.foundation_id + "'";

        Smart_Search_Dept.datatble = General_Helping.GetDataTable(Query);
        Smart_Search_Dept.Value_Field = "Dept_id";
        Smart_Search_Dept.Text_Field = "Dept_name";
        Smart_Search_Dept.DataBind();


    }
    protected void ddl_sectors_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Smart_Search_Dept.sql_Connection = sql_Connection;
        //string Query = "";
        //Query = "SELECT  * from    Departments  where foundation_id='" + Session_CS.foundation_id + "'";
        //Smart_Search_Dept.datatble = General_Helping.GetDataTable(Query);
        //Smart_Search_Dept.Text_Field = "Dept_name";
        //Smart_Search_Dept.Value_Field = "Dept_id";
        //Smart_Search_Dept.DataBind();
        //clear_fields();

    }
    public void clear_fields()
    {
        Smart_Search_Dept.Clear_Selected();
        Smart_Search_emp.Clear_Selected();

    }
    private void MOnMember_Data(string Value)
    {
        dropdept_fun();
    }
    private void MOnMember_Data_emp(string Value)
    {
       // get_depts();
    }

    private void dropdept_fun()
    {
        if (Smart_Search_Dept.SelectedValue != "")
        {
            Smart_Search_emp.sql_Connection = sql_Connection;

          // string Query = "select * from employee where  dept_dept_id=" + Smart_Search_Dept.SelectedValue + " ORDER BY LTRIM(pmp_name)";
           

         DataTable dt = SqlHelper.ExecuteDataset(Database.ConnectionString, "EmpDeptartmentSelect",CDataConverter.ConvertToInt(Smart_Search_Dept.SelectedValue)).Tables[0];

             Smart_Search_emp.datatble = dt;

            Smart_Search_emp.Text_Field = "pmp_name";
            Smart_Search_emp.Value_Field = "pmp_id";
            Smart_Search_emp.DataBind();
        }
    }

    protected void cbl_depts_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void get_depts()
    {
       // //string sql = @"SELECT d.Dept_id, d.Dept_name FROM Sectors s, Departments d WHERE s.Sec_id = d.Sec_sec_id and s.sec_id = "
       // //    + ddl_sectors.SelectedValue + " and d.Dept_id <> '" + Smart_Search_Dept.SelectedValue + "'" + " ORDER BY LTRIM(d.Dept_name)";

       // //DataTable dt = General_Helping.GetDataTable(sql);

       //DataTable dt = SqlHelper.ExecuteDataset(Database.ConnectionString, "GetsectorsDept", CDataConverter.ConvertToInt(ddl_sectors.SelectedValue), CDataConverter.ConvertToInt(Smart_Search_Dept.SelectedValue)).Tables[0];

       // cbl_depts.DataSource = dt;
       // cbl_depts.DataValueField = "dept_id";
       // cbl_depts.DataTextField = "dept_name";
       // cbl_depts.DataBind();

       // if (Smart_Search_Dept.SelectedValue != "" && Smart_Search_emp.SelectedValue != "")
       // {
       //    // string sql_compare = @"SELECT * FROM EMPLOYEE_Departemnts WHERE pmp_id=" + Smart_Search_emp.SelectedValue;

       //    // DataTable dt_compare = General_Helping.GetDataTable(sql_compare);

       //     DataTable dt_compare = SqlHelper.ExecuteDataset(Database.ConnectionString, "EMPLOYEE_DepartemntsSelect", Smart_Search_emp.SelectedValue).Tables[0];


       //     foreach (DataRow row_compare in dt_compare.Rows)
       //     {
       //         string Value = row_compare["Dept_id"].ToString();
       //         foreach (DataRow row in dt.Rows)
       //         {
       //             if (row["Dept_id"].ToString() == Value)
       //             {
       //                 ListItem item = cbl_depts.Items.FindByValue(Value);
       //                 if (item != null)
       //                     item.Selected = true;
       //             }
       //         }

       //     }
       // }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        string sql = "";

       // sql = "delete from dbo.EMPLOYEE_Departemnts where pmp_id =" + Smart_Search_emp.SelectedValue;

        SqlHelper.ExecuteNonQuery(Database.ConnectionString, "EMPLOYEE_DepartemntsDelete", Smart_Search_emp.SelectedValue);

     

        foreach (ListItem item in cbl_depts.Items)
        {
            if (item.Selected)
            {

                SqlHelper.ExecuteNonQuery(Database.ConnectionString, "EMPLOYEE_Departemnts_Save", 0,Smart_Search_emp.SelectedValue, item.Value);

                //sql = "insert into dbo.EMPLOYEE_Departemnts(PMP_ID,Dept_id) values (" + Smart_Search_emp.SelectedValue + "," + item.Value + ")";
                //General_Helping.ExcuteQuery(sql);
            }
        }
        Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('تم الحفظ بنجاح')</script>");
    }
}
