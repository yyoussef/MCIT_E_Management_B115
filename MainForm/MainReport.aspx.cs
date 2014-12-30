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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using ReportsClass;

public partial class WebForms_MainReport : System.Web.UI.Page
{
    //Session_CS Session_CS = new Session_CS();
    string sql, sqlnewt;
    SqlConnection conn;
    SqlDataAdapter da;
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

        if (!IsPostBack)
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            /////////////////////////// get data to Department dropdown list /////////////////////////////////////
            sql = "select Dept_ID,Dept_name from Departments";
            ds = new DataSet();
            da = new SqlDataAdapter(sql, conn);
            da.Fill(ds, "dept");
            Deptdrop.DataSource = ds.Tables[0];
            Deptdrop.DataTextField = "Dept_name";
            Deptdrop.DataValueField = "Dept_ID";
            Deptdrop.DataBind();
            Deptdrop.Items.Insert(0, new ListItem("اختر اسم الإدارة......", "0"));

            /////////////////////////// get data to project dropdown list /////////////////////////////////////
            sql = "select Proj_id,Proj_Title from Project";
            ds = new DataSet();
            da = new SqlDataAdapter(sql, conn);
            da.Fill(ds, "projects");
            projdrop.DataSource = ds.Tables[0];
            projdrop.DataTextField = "Proj_Title";
            projdrop.DataValueField = "Proj_id";
            projdrop.DataBind();
            projdrop.Items.Insert(0, new ListItem("اختر اسم المشروع......", "0"));



        }


    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {

    }
    protected void Deptdrop_SelectedIndexChanged(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        if (Deptdrop.SelectedValue != "0")
        {
            sql = "select Proj_id,Proj_Title,Dept_Dept_id from Project where Dept_Dept_id=" + Deptdrop.SelectedItem.Value;
            ds = new DataSet();
            da = new SqlDataAdapter(sql, conn);
            da.Fill(ds, "projects");
            projdrop.DataSource = ds.Tables[0];
            projdrop.DataTextField = "Proj_Title";
            projdrop.DataValueField = "Proj_id";
            projdrop.DataBind();
            projdrop.Items.Insert(0, new ListItem("اختر اسم المشروع......", "0"));
        }
        else
        {
            sql = "select Proj_id,Proj_Title from Project";
            ds = new DataSet();
            da = new SqlDataAdapter(sql, conn);
            da.Fill(ds, "projects");
            projdrop.DataSource = ds.Tables[0];
            projdrop.DataTextField = "Proj_Title";
            projdrop.DataValueField = "Proj_id";
            projdrop.DataBind();
            projdrop.Items.Insert(0, new ListItem("اختر اسم المشروع......", "0"));
        }

        Label4.Text = "";

    }

    protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Label4.Text = "";
    }


    protected void projdrop_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void EmployeeLB_Click(object sender, EventArgs e)
    {
        ReportDocument rd = new ReportDocument();
        Label4.Visible = false;
        string s = Server.MapPath("../Reports/Employee.rpt");
        rd.Load(s);
        Reports.Load_Report(rd);
        rd.SetParameterValue(0, projdrop.SelectedValue);
        rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.WordForWindows, Response, true, "Report.rpt");



    }
    
    protected void commitedandRefusedProjectsLB_Click(object sender, EventArgs e)
    {
        ReportDocument rd = new ReportDocument();
        Label4.Visible = false;
        string s = Server.MapPath("../Reports/commitedandRefusedProjects.rpt");
        rd.Load(s);
        Reports.Load_Report(rd);
        rd.SetParameterValue(0, Deptdrop.SelectedValue);
        //rd.SetParameterValue(1, Deptdrop.SelectedValue);
        rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.WordForWindows, Response, true, "Report.rpt");
    }
    protected void CurrentProjectsLB_Click(object sender, EventArgs e)
    {
        ReportDocument rd = new ReportDocument();
        Label4.Visible = false;
        string s = Server.MapPath("../Reports/CurrentProjects.rpt");
        rd.Load(s);
        Reports.Load_Report(rd);
        rd.SetParameterValue(0, Deptdrop.SelectedValue);
        rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.WordForWindows, Response, true, "Report.rpt");
    }
    protected void needmaintypeLB_Click(object sender, EventArgs e)
    {
        ReportDocument rd = new ReportDocument();
        Label4.Visible = false;
        string s = Server.MapPath("../Reports/needmaintype.rpt");
        rd.Load(s);
        Reports.Load_Report(rd);
        //rd.SetParameterValue(0, Deptdrop.SelectedValue);
        rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.WordForWindows, Response, true, "Report.rpt");
    }
    protected void OrganizationsProjectsLB_Click(object sender, EventArgs e)
    {
        ReportDocument rd = new ReportDocument();
        Label4.Visible = false;
        string s = Server.MapPath("../Reports/OrganizationsProjects.rpt");
        rd.Load(s);
        Reports.Load_Report(rd);
        //rd.SetParameterValue(0, Deptdrop.SelectedValue);
        rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.WordForWindows, Response, true, "Report.rpt");
    }
    protected void projectsneedapproveLB_Click(object sender, EventArgs e)
    {
        ReportDocument rd = new ReportDocument();
        Label4.Visible = false;
        string s = Server.MapPath("../Reports/CrystalReport2.rpt");
        rd.Load(s);
        Reports.Load_Report(rd);
        rd.SetParameterValue(0, projdrop.SelectedValue);
        rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.WordForWindows, Response, true, "Report.rpt");
    }
    protected void ProjectsEmloyeesLB_Click(object sender, EventArgs e)
    {
        ReportDocument rd = new ReportDocument();
        Label4.Visible = false;
        string s = Server.MapPath("../Reports/ProjectsEmloyees.rpt");
        rd.Load(s);
        Reports.Load_Report(rd);
        rd.SetParameterValue(0, Deptdrop.SelectedValue);
        rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.WordForWindows, Response, true, "Report.rpt");
    }
    protected void projobjectiveLB_Click(object sender, EventArgs e)
    {
        ReportDocument rd = new ReportDocument();
        Label4.Visible = false;
        string s = Server.MapPath("../Reports/Proj_obj.rpt");
        rd.Load(s);
        Reports.Load_Report(rd);
        rd.SetParameterValue(0, projdrop.SelectedValue);
        rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.WordForWindows, Response, true, "Report.rpt");
    }
    protected void projneedsLB_Click(object sender, EventArgs e)
    {
        ReportDocument rd = new ReportDocument();
        Label4.Visible = false;
        string s = Server.MapPath("../Reports/ProjNeeds.rpt");
        rd.Load(s);
        Reports.Load_Report(rd);
        rd.SetParameterValue(0, projdrop.SelectedValue);
        rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.WordForWindows, Response, true, "Report.rpt");
    }
    protected void weightpercentageLB_Click(object sender, EventArgs e)
    {

        ReportDocument rd = new ReportDocument();
        Label4.Visible = false;
        string s = Server.MapPath("../Reports/CrystalReport3.rpt");
        rd.Load(s);
        Reports.Load_Report(rd);
        rd.SetParameterValue(0, projdrop.SelectedValue);
        rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.WordForWindows, Response, true, "Report.rpt");
    }
}
