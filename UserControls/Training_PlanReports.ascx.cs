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
using System.Data.SqlClient;
using DBL;
using activityLeveling;
using ReportsClass;


public partial class UserControls_Training_PlanReports : System.Web.UI.UserControl
{

    General_Helping Obj_General_Helping = new General_Helping();

    string sql;
    SqlConnection conn;
    SqlDataAdapter da;
    DataSet ds;

    private string sql_Connection = Universal.GetConnectionString();


    //Session_CS Session_CS = new Session_CS();

    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected override void OnInit(EventArgs e)
    {


        #region BROWSER FOR departments

        Smart_dept.sql_Connection = sql_Connection;
        string Query = "select Dept_ID,Dept_name from Departments where Sec_sec_id='"+Session_CS.sec_id+"' ";
        Smart_dept.datatble = General_Helping.GetDataTable(Query);
        Smart_dept.Value_Field = "Dept_ID";
        Smart_dept.Text_Field = "Dept_name";
        Smart_dept.DataBind();
        this.Smart_dept.Value_Handler += new Smart_Search.Delegate_Selected_Value(MOnMember_Data);




        ////////////////////////////////////////////////////////////

        smart_course.sql_Connection = sql_Connection;
        string Query1 = "select course_id,course_name from dbo.courses ";
        smart_course.datatble = General_Helping.GetDataTable(Query1);
        smart_course.Value_Field = "course_id";
        smart_course.Text_Field = "course_name";
        smart_course.DataBind();

        //////////////////////////////////////////////////////////




        #endregion


        base.OnInit(e);
    }


    private void MOnMember_Data(string Value)
    {

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

    public static void ShowAlertMessage(string error)
    {

        Page page = HttpContext.Current.Handler as Page;
        if (page != null)
        {
            error = error.Replace("'", "\'");
            ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('" + error + "');", true);
        }
    }

    protected void show_hide_tables()
    {
        tbl_Report.Style.Add("display", "none");
        tbl_Paramater.Style.Add("display", "block");
        tbl_Paramater1.Style.Add("display", "block");
    }

     protected void ImgBtnBack_Click(object sender, ImageClickEventArgs e)
    {
       
            Response.Redirect("../MainForm/Training_PlanReports.aspx");
       
    }

    protected void Training_emp_Click(object sender, EventArgs e)
    {
        hidden_Rpt_Id.Value = "Training_employee";

        Div_dept.Style.Add("display", "block");
        div_course.Style.Add("display", "block");
        show_hide_tables();
        Page.Title = "تقرير " + Training_emp.Text;
        Label2.Visible = true;
        Label2.Text = Page.Title;
    }

    protected void Training_emp_count_Click(object sender, EventArgs e)
    {

        SqlConnection conn = new SqlConnection(sql_Connection);

           
             string s= Server.MapPath("../Reports/Training_plan_count.rpt");;

            sql = " select distinct dbo.Course_Programs.prog_name,dbo.Course_Programs.prog_id,dbo.Courses.course_name,dbo.Courses.course_id,count(*)as count_numbers from dbo.Course_Programs inner join dbo.Courses  on dbo.Course_Programs.prog_id=dbo.Courses.prog_id inner join dbo.Training_Plan on dbo.Training_Plan.course_id=dbo.Courses.course_id where dbo.Training_Plan.isapproved=1 group by dbo.Course_Programs.prog_name,dbo.Course_Programs.prog_id,dbo.Courses.course_name,dbo.Courses.course_id ";
            
         
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);



            string user = Session_CS.pmp_name.ToString();
            ReportDocument rd = new ReportDocument();
           
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

    protected void Button1_Click(object sender, EventArgs e)
    {

        if (hidden_Rpt_Id.Value == "Training_employee")
        {
             SqlConnection conn = new SqlConnection(sql_Connection);

           
             string s= Server.MapPath("../Reports/Training_plan.rpt");;

            sql = " select dbo.EMPLOYEE.PMP_ID,dbo.EMPLOYEE.pmp_name,dbo.EMPLOYEE.job_no,dbo.EMPLOYEE.pmp_title,dbo.Departments.Dept_id,dbo.Departments.Dept_name,dbo.Courses.course_id,dbo.Courses.course_name from  dbo.EMPLOYEE inner join dbo.Departments  on dbo.EMPLOYEE.Dept_Dept_id=dbo.Departments.Dept_id inner join dbo.Training_Plan on dbo.Training_Plan.emp_id=dbo.EMPLOYEE.PMP_ID inner join dbo.Courses on dbo.Courses.course_id=dbo.Training_Plan.course_id and dbo.Training_Plan.isapproved=1  ";
            
            if (smart_course.SelectedValue != "")
            {
                sql += " and  dbo.Training_Plan.course_id=" + CDataConverter.ConvertToInt(smart_course.SelectedValue);
            }

            if (Smart_dept.SelectedValue != "")
            {
                
                sql += " AND Departments.Dept_ID = " + CDataConverter.ConvertToInt(Smart_dept.SelectedValue);

                 s = Server.MapPath("../Reports/Training_planbydept.rpt");
            }
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);



            string user = Session_CS.pmp_name.ToString();
            ReportDocument rd = new ReportDocument();
           //  s = Server.MapPath("../Reports/Training_Detail.rpt");
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

        }
    }






