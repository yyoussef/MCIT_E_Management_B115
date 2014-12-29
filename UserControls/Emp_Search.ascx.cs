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

public partial class Emp_Search : System.Web.UI.UserControl
{
    //string sql;
    //SqlConnection conn;
    //SqlDataAdapter da;
    //DataSet ds;
    //SqlCommand cmd;

    Session_CS Session_CS = new Session_CS();
    private string sql_Connection = Database.ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            //fill_sectors();
            //int group = CDataConverter.ConvertToInt(Session_CS.group_id.ToString());
            //if (group == 2)
            //{
            //    tr_smart_proj.Visible = true;

            //}
            Smart_Search_mang.Show_OrgTree = true;
        }
    }

    protected override void OnInit(EventArgs e)
    {

        string Query = "";
        Query = "SELECT  * from    Departments  where foundation_id='" + Session_CS.foundation_id + "'";

        Smart_Search_mang.datatble = General_Helping.GetDataTable(Query);



        Smart_Search_mang.Value_Field = "Dept_ID";
        Smart_Search_mang.Text_Field = "Dept_name";
        Smart_Search_mang.Orderby = "ORDER BY LTRIM(Dept_name)";
        Smart_Search_mang.DataBind();




       // this.Smart_Search_mang.Value_Handler += new Smart_Search.Delegate_Selected_Value(emp_Data);

        base.OnInit(e);


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

    //private void fill_sectors()
    //{
    //    DataTable dt = Sectors_DB.SelectAll(0, CDataConverter.ConvertToInt(Session_CS.foundation_id.ToString()));
    //  ddl_sectors.DataSource = dt;
    //  ddl_sectors.DataBind();
    //  ddl_sectors.Items.Insert(0, new ListItem("إختر القطاع","0"));
    //}


    //protected void fill_depts()
    //{
    //   // DataTable dt = General_Helping.GetDataTable("select Dept_ID,Dept_name from Departments where sec_sec_id='" + ddl_sectors.SelectedValue + "' ");
    //   // DataTable dt = SqlHelper.ExecuteDataset(Database.ConnectionString, "DepartmentsSelect", ddl_sectors.SelectedValue).Tables[0];
    //    string Query = "";
    //    Query = "SELECT  * from    Departments  where foundation_id='" + Session_CS.foundation_id + "'";

    //    Smart_Search_mang.datatble = General_Helping.GetDataTable(Query);

       
     
    //    Smart_Search_mang.Value_Field = "Dept_ID";
    //    Smart_Search_mang.Text_Field = "Dept_name";
    //    Smart_Search_mang.Orderby = "ORDER BY LTRIM(Dept_name)";
    //    Smart_Search_mang.DataBind();
       
    //}

    public void SearchRecord()
    {
        string name="";
        int sec_id=0;
        int dept_id=0 ;
        string job_no="";

        DataTable dt = new DataTable();

      
        if(Smart_Search_mang.SelectedValue !="" && Smart_Search_mang.SelectedValue!="0")
        {
            dept_id=CDataConverter.ConvertToInt(Smart_Search_mang.SelectedValue );
        }

        if(txt_pmp_name.Text!="")
        {
            name=txt_pmp_name.Text;
        }
        if(job_no_txt.Text!="")
        {
            job_no = job_no_txt.Text;

        }
        
         dt = Employee_Data_DB.Select_EmployeeData(name,dept_id,job_no,Session_CS.foundation_id );
      
        gvMain.DataSource = dt;
        gvMain.DataBind();

       
    }

    protected void SaveButton_Click(object sender, EventArgs e)
    {
        SearchRecord();



    }

    public string Get_Name()
    {
        return "ttt";
    }

    protected void gvMain_SelectedIndexChanged(object sender, EventArgs e)
    {
  
    }
    protected void gvMain_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Show_Details")
        {
            GridViewRow row = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer); 
            Label lblsecID = (Label)row.FindControl("lblSecID");
            Label lblDeptID = (Label)row.FindControl("lblDeptID");
            Label lblPmpName = (Label)row.FindControl("lblPmpName");
            Label lblPmpID = (Label)row.FindControl("lbPmpID");
            Response.Redirect("Employee_data.aspx?pmp_id=" + lblPmpID.Text + "&dept_id=" + lblDeptID.Text);
        }

    }
    protected void gvMain_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvMain.PageIndex = e.NewPageIndex;
        SearchRecord();
    }
    
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
      
    }

    //protected void ddl_sectors_SelectedIndexChanged(object sender, EventArgs e)
    //{


    //    fill_depts();

    //}
}
