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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using ReportsClass;



public partial class Admin_Admin_Report : System.Web.UI.Page
{
    string sql;
    Session_CS Session_CS = new Session_CS();

    SqlDataAdapter da;
    DataSet ds;

    private string sql_Connection = Database.ConnectionString;
    General_Helping Obj_General_Helping = new General_Helping();

    
    protected override void OnInit(EventArgs e)
    {
       

        #region BROWSER FOR departments

        Smrt_Srch_DropDep.sql_Connection = sql_Connection;
     //   Smrt_Srch_DropDep.Query = "select Dept_ID,Dept_name from Departments ";
        string Query = "select Dept_ID,Dept_name from Departments ";
        Smrt_Srch_DropDep.datatble = General_Helping.GetDataTable(Query);
        Smrt_Srch_DropDep.Value_Field = "Dept_ID";
        Smrt_Srch_DropDep.Text_Field = "Dept_name";
        Smrt_Srch_DropDep.DataBind();
        this.Smrt_Srch_DropDep.Value_Handler += new Smart_Search.Delegate_Selected_Value(MOnMember_Data);

       


       
        smart_employee.sql_Connection = sql_Connection;
      //  smart_employee.Query = "select PMP_ID,pmp_name from dbo.EMPLOYEE ";
        Query = "select PMP_ID,pmp_name from dbo.EMPLOYEE ";
        smart_employee.datatble = General_Helping.GetDataTable(Query);
        smart_employee.Value_Field = "PMP_ID";
        smart_employee.Text_Field = "pmp_name";
        smart_employee.DataBind();


       

      

      

        #endregion


        base.OnInit(e);
    }
    private void MOnMember_Data(string Value)
    {
        dropdept_fun();
    }
    protected void dropdept_fun()
    {
        //SqlConnection conn = new SqlConnection(sql_Connection);
        if (Smrt_Srch_DropDep.SelectedValue != "")
        {
            smart_employee.sql_Connection = sql_Connection;
           // smart_employee.Query = "select * from dbo.EMPLOYEE where dept_dept_id= " + Smrt_Srch_DropDep.SelectedValue;
            string Query = "select * from dbo.EMPLOYEE where dept_dept_id= " + Smrt_Srch_DropDep.SelectedValue;
            smart_employee.datatble = General_Helping.GetDataTable(Query);
            smart_employee.Value_Field = "PMP_ID";
            smart_employee.Text_Field = "pmp_name";
            smart_employee.DataBind();




           
        }
       
        Label6.Visible = false;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            //Label2.Text = Session_CS.pmp_name.ToString();
          
            //Fill_emp();


        }
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
        int dept_id = 0;
        int pmp_id = 0;
        SqlConnection conn = new SqlConnection(sql_Connection);
        sql = "select * from final_report_follow where 1=1";
        if (Smrt_Srch_DropDep.SelectedValue != "")
        {
            dept_id = int.Parse(Smrt_Srch_DropDep.SelectedValue);
            sql += " AND dbo.final_report_follow.Dept_Dept_ID = " + dept_id;
        }
        if (smart_employee.SelectedValue != "")
        {
            pmp_id = int.Parse(smart_employee.SelectedValue);
            sql += " AND dbo.final_report_follow.pmp_id = " + pmp_id;
        }
        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        DataTable dt = new DataTable();
        da.Fill(dt);



        string user = Session_CS.pmp_name.ToString();
        ReportDocument rd = new ReportDocument();
        string s = Server.MapPath("../Reports/emp_follow.rpt");
        rd.Load(s);
        rd.SetDataSource(dt);
        Reports.Load_Report(rd);

        rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
        rd.SetParameterValue("@user", user, "footerRep.rpt");
        if (rd.Rows.Count == 0)
        {
            ShowAlertMessage("هذا التقرير لا يوجد به بيانات للعرض !!!!");
            return;
        }
        else
        {
            rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report");
        }


    }
  
    public string IpAddress()
    {
        string name = "";
        string ip = "";
        try
        {
            name = System.Net.Dns.GetHostName();
            ip = System.Net.Dns.GetHostAddresses(name).GetValue(1).ToString();
            return ip;
        }
        catch
        {
            name = System.Net.Dns.GetHostName();
            ip = System.Net.Dns.GetHostAddresses(name).GetValue(0).ToString();
            return ip;
        }
    }
   
   
    

 
    //protected void Drop_Names_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
    //    conn.Open();
    //    sql = "select Adress from MCIT_mail_list where name = '" + Drop_Names.SelectedItem.Text + "'";
    //    da = new SqlDataAdapter(sql, conn);
    //    ds = new DataSet();
    //    da.Fill(ds);
    //    txt_emp_email.Text = ds.Tables[0].Rows[0]["Adress"].ToString();
    //}
}
