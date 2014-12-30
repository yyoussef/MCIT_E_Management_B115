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

public partial class WebForms_DMallReports : System.Web.UI.Page
{
    //Session_CS Session_CS = new Session_CS();
    string sql;
    SqlConnection conn;
    SqlDataAdapter da;
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        if (Session_CS.pmp_name != null)
        {
            if (!IsPostBack)
            {
                //Label5.Visible = false;
                Label3.Text = Session_CS.dept.ToString();
                //int proj_id = int.Parse(Session_CS.Project_id.ToString());
                int dept_id = int.Parse(Session_CS.dept_id.ToString());
                int pmp = int.Parse(Session_CS.pmp_id.ToString());
                //////////////////////////////////// get project manager data to drop list ////////////////////
                sql = "select distinct pmp_pmp_id,PTem_Name,rol_rol_id from dbo.Project_Team where rol_rol_id=4";
                ds = new DataSet();
                da = new SqlDataAdapter(sql, conn);
                da.Fill(ds, "projectsmanage");
                Dropprojmanage.DataSource = ds.Tables[0];
                Dropprojmanage.DataTextField = "PTem_Name";
                Dropprojmanage.DataValueField = "pmp_pmp_id";
                Dropprojmanage.DataBind();
                Dropprojmanage.Items.Insert(0, new ListItem("اختر اسم مدير المشروع ......", "0"));
                /////////////////////////// get data of project to drop list //////////////////////////
                //sql = "select Proj_id,Proj_Title,Dept_Dept_id from Project where Dept_Dept_id=" + dept_id;
                //ds = new DataSet();
                //da = new SqlDataAdapter(sql, conn);
                //da.Fill(ds, "projects");
                //DropProj.DataSource = ds.Tables[0];
                //DropProj.DataTextField = "Proj_Title";
                //DropProj.DataValueField = "Proj_id";
                //DropProj.DataBind();
                //DropProj.Items.Insert(0, new ListItem("اختر اسم المشروع......", "0"));
                //////////////////// get dates from store to drop list /////////////////////////////
                sql = "select id,convert(nvarchar,available_Date,111) as Date,available_Date from Store";
                ds = new DataSet();
                da = new SqlDataAdapter(sql, conn);
                da.Fill(ds, "dates");
                DropDate.DataSource = ds.Tables[0];
                DropDate.DataValueField = "available_Date";
                DropDate.DataTextField = "Date";
                DropDate.DataBind();
                DropDate.Items.Insert(0, new ListItem("اختر تاريخ الصرف المطلوب......", "0"));
                TextBox1.Text = CDataConverter.ConvertDateTimeNowRtrnString();
                TextBox2.Text = CDataConverter.ConvertDateTimeNowRtrnString();

            }

        }

    }
    protected void DropProj_SelectedIndexChanged(object sender, EventArgs e)
    {


    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    
    protected void IndicatortypeLBdeptMang_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        int dept_id = int.Parse(Session_CS.dept_id.ToString());
        int proj_id = int.Parse(DropProj.SelectedItem.Value);
        ReportDocument rd = new ReportDocument();
        string s = Server.MapPath("../Reports/Indicator_Type_parameters.rpt");
        rd.Load(s);
        Reports.Load_Report(rd);
        rd.SetParameterValue(0, proj_id);
        rd.SetParameterValue(1, dept_id);
        rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.WordForWindows, Response, true, "Report");
    }

    protected void PActivitiesPMLB_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        int dept_id = int.Parse(Session_CS.dept_id.ToString());
        int proj_id = int.Parse(DropProj.SelectedItem.Value);
        ReportDocument rd = new ReportDocument();

        //Label5.Visible = true;
        string s = Server.MapPath("../Reports/PActivities_parameter.rpt");
        rd.Load(s);
        Reports.Load_Report(rd);
        rd.SetParameterValue(0, proj_id);
        rd.SetParameterValue(1, dept_id);
        rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.WordForWindows, Response, true, "Report");
    }
    protected void PFollowUpPMLB_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        int dept_id = int.Parse(Session_CS.dept_id.ToString());
        int proj_id = int.Parse(DropProj.SelectedItem.Value);
        ReportDocument rd = new ReportDocument();

        //Label5.Visible = true;
        string s = Server.MapPath("../Reports/PFollowUpReport_parameters.rpt");
        rd.Load(s);
        Reports.Load_Report(rd);
        rd.SetParameterValue(0, proj_id);
        rd.SetParameterValue(1, dept_id);
        rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.WordForWindows, Response, true, "Report");
    }
    protected void ProjectneedReportLB_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        if (DropDate.SelectedValue != "0")
        {
            int dept_id = int.Parse(Session_CS.dept_id.ToString());
            int proj_id = int.Parse(DropProj.SelectedItem.Value);
            ReportDocument rd = new ReportDocument();

            //Label5.Visible = true;
            string s = Server.MapPath("../Reports/PNeeds_parameter.rpt");
            rd.Load(s);
            Reports.Load_Report(rd);
            rd.SetParameterValue(0, proj_id);
            rd.SetParameterValue(1, DropDate.SelectedItem.Text);
            rd.SetParameterValue(2, dept_id);
            rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.WordForWindows, Response, true, "Report");
        }
        else
        {
            return;
        }

    }
    protected void EmployeeLB_Click(object sender, EventArgs e)
    {
        ReportDocument rd = new ReportDocument();
        int proj_id = int.Parse(Session_CS.Project_id.ToString());
        string s = Server.MapPath("../Reports/Employee.rpt");
        rd.Load(s);
        Reports.Load_Report(rd);
        rd.SetParameterValue(0, proj_id);
        rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.WordForWindows, Response, true, "Report.rpt");
    }
    protected void projectsneedapproveLB_Click(object sender, EventArgs e)
    {
        ReportDocument rd = new ReportDocument();
        int proj_id = int.Parse(Session_CS.Project_id.ToString());
        string s = Server.MapPath("../Reports/CrystalReport2.rpt");
        rd.Load(s);
        Reports.Load_Report(rd);
        rd.SetParameterValue(0, proj_id);
        rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.WordForWindows, Response, true, "Report.rpt");
    }
    protected void projobjectiveLB_Click(object sender, EventArgs e)
    {
        ReportDocument rd = new ReportDocument();
        int proj_id = int.Parse(Session_CS.Project_id.ToString());
        string s = Server.MapPath("../Reports/Proj_obj.rpt");
        rd.Load(s);
        Reports.Load_Report(rd);
        rd.SetParameterValue(0, proj_id);
        rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.WordForWindows, Response, true, "Report.rpt");
    }
    protected void projneedsLB_Click(object sender, EventArgs e)
    {
        ReportDocument rd = new ReportDocument();
        int proj_id = int.Parse(Session_CS.Project_id.ToString());
        string s = Server.MapPath("../Reports/ProjNeeds.rpt");
        rd.Load(s);
        Reports.Load_Report(rd);
        rd.SetParameterValue(0, proj_id);
        rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.WordForWindows, Response, true, "Report.rpt");
    }
    protected void weightpercentageLB_Click(object sender, EventArgs e)
    {
        ReportDocument rd = new ReportDocument();
        int proj_id = int.Parse(Session_CS.Project_id.ToString());
        string s = Server.MapPath("../Reports/CrystalReport3.rpt");
        rd.Load(s);
        Reports.Load_Report(rd);
        rd.SetParameterValue(0, proj_id);
        rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.WordForWindows, Response, true, "Report.rpt");
    }
    protected void Dropprojmanage_SelectedIndexChanged(object sender, EventArgs e)
    {
        int dept_id = int.Parse(Session_CS.dept_id.ToString());
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        if (Dropprojmanage.SelectedValue != "0")
        {
            sql = "SELECT dbo.Project_Team.PTem_Name, dbo.Project_Team.rol_rol_id, dbo.Project_Team.proj_proj_id, dbo.Project_Team.pmp_pmp_id, dbo.Project.Proj_Title,dbo.Departments.Dept_ID";
            sql += " FROM dbo.Project INNER JOIN dbo.Project_Team ON dbo.Project.Proj_id = dbo.Project_Team.proj_proj_id ";
            sql += " INNER JOIN dbo.Departments ON dbo.Project.Dept_Dept_id = dbo.Departments.Dept_ID";
            sql += " WHERE dbo.Project_Team.rol_rol_id = 4 AND dbo.Project_Team.pmp_pmp_id= " + Dropprojmanage.SelectedValue;
            sql += " AND dbo.Departments.Dept_ID = " + dept_id;
            ds = new DataSet();
            da = new SqlDataAdapter(sql, conn);
            da.Fill(ds, "projects");
            DropProj.DataSource = ds.Tables[0];
            DropProj.DataTextField = "Proj_Title";
            DropProj.DataValueField = "proj_proj_id";
            DropProj.DataBind();
            DropProj.Items.Insert(0, new ListItem("اختر اسم المشروع......", "0"));


        }
        else
        {

            sql = "select Proj_id,Proj_Title,Dept_Dept_id from Project where Dept_Dept_id=" + dept_id;
            ds = new DataSet();
            da = new SqlDataAdapter(sql, conn);
            da.Fill(ds, "projects");
            DropProj.DataSource = ds.Tables[0];
            DropProj.DataTextField = "Proj_Title";
            DropProj.DataValueField = "Proj_id";
            DropProj.DataBind();
            DropProj.Items.Insert(0, new ListItem("اختر اسم المشروع......", "0"));

        }
    }
    protected void PDemandsLB_Click(object sender, EventArgs e)
    {
        ReportDocument rd = new ReportDocument();
        int dept_id = int.Parse(Session_CS.dept_id.ToString());
        string t1 = DateTime.ParseExact(TextBox1.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
        string t2 = DateTime.ParseExact(TextBox2.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
        string s = Server.MapPath("../Reports/projectDemands_parameters.rpt");
        rd.Load(s);
        //t1=t1.ToString("dd/MM/yyyy");
        Reports.Load_Report(rd);
        rd.SetParameterValue("@Dept_id", dept_id);
        rd.SetParameterValue("@PNed_Date_From", t1);
        rd.SetParameterValue("@PNed_Date_To", t2);
        rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.WordForWindows, Response, true, "Report.rpt");
    }
    protected void TextBox2_TextChanged(object sender, EventArgs e)
    {

    }
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {

    }
    protected void commitedandRefusedProjectsLB_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        int dept_id = int.Parse(Session_CS.dept_id.ToString());
        //int proj_id = int.Parse(DropProj.SelectedItem.Value);
        ReportDocument rd = new ReportDocument();

        //Label5.Visible = true;
        string s = Server.MapPath("../Reports/commitedandRefusedProjects.rpt");
        rd.Load(s);
        Reports.Load_Report(rd);
        //rd.SetParameterValue(0, proj_id);
        rd.SetParameterValue(0, dept_id);
        rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.WordForWindows, Response, true, "Report");
    }
    protected void CurrentProjectsLB_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        int dept_id = int.Parse(Session_CS.dept_id.ToString());
        //int proj_id = int.Parse(DropProj.SelectedItem.Value);
        ReportDocument rd = new ReportDocument();

        //Label5.Visible = true;
        string s = Server.MapPath("../Reports/CurrentProjects.rpt");
        rd.Load(s);
        Reports.Load_Report(rd);
        //rd.SetParameterValue(0, proj_id);
        rd.SetParameterValue(0, dept_id);
        rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.WordForWindows, Response, true, "Report");
    }
    protected void ProjectsEmloyeesLB_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        int dept_id = int.Parse(Session_CS.dept_id.ToString());
        //int proj_id = int.Parse(DropProj.SelectedItem.Value);
        ReportDocument rd = new ReportDocument();

        //Label5.Visible = true;
        string s = Server.MapPath("../Reports/ProjectsEmloyees.rpt");
        rd.Load(s);
        Reports.Load_Report(rd);
        //rd.SetParameterValue(0, proj_id);
        rd.SetParameterValue(0, dept_id);
        rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.WordForWindows, Response, true, "Report");
    }
    protected void projAchievmentLB_Click(object sender, EventArgs e)
    {

    }

}
