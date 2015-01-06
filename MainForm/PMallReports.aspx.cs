using System;
using System.Globalization;
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
using DBL;
using activityLeveling;
using ReportsClass;

public partial class WebForms_PMallReports : System.Web.UI.Page
{
    //Session_CS Session_CS = new Session_CS();
    string sql;
    SqlConnection conn;
    SqlDataAdapter da;
    DataSet ds;
    string sql_Connection = Universal.GetConnectionString();
    protected void Page_Load(object sender, EventArgs e)
    {

        conn = new SqlConnection(sql_Connection);
        if (Session_CS.pmp_name != null)
        {
            if (!IsPostBack)
            {

                IpAddress();

                string dept_name = Session_CS.dept.ToString();
                //Label2.Text = Session_CS.pmp_name.ToString();
                int proj_id = int.Parse(Session_CS.Project_id.ToString());
                decimal budget = decimal.Parse(Session["Budget"].ToString());
                sql = " select Proj_id,Proj_Title from Project where Proj_id = " + proj_id;
                ds = new DataSet();
                da = new SqlDataAdapter(sql, conn);
                da.Fill(ds, "project name");
                string proj_name = ds.Tables[0].Rows[0]["Proj_Title"].ToString();
                Session["projectname"] = proj_name;
                Label3.Text = proj_name;

                int dept_id = int.Parse(Session_CS.dept_id.ToString());
                int pmp = int.Parse(Session_CS.pmp_id.ToString());
                sql = "select pmp_name , pmp_id from Employee where pmp_id = " + pmp;
                ds = new DataSet();
                da = new SqlDataAdapter(sql, conn);
                da.Fill(ds, "project manager name");
                string projmanage_name = ds.Tables[0].Rows[0]["pmp_name"].ToString();
                Session["projectmanagername"] = projmanage_name;
                DateTime date = CDataConverter.ConvertDateTimeNowRtnDt();
                sql = "select id,available_Date from Store";
                ds = new DataSet();
                da = new SqlDataAdapter(sql, conn);
                da.Fill(ds, "dates");
                DropDate.DataSource = ds.Tables[0];

                DropDate.DataValueField = "available_Date";
                DropDate.DataTextField = "available_Date";
                DropDate.DataBind();
                DropDate.Items.Insert(0, new ListItem("اختر تاريخ الجرد المطلوب......", "0"));


            }



        }

    }
    protected void DropProj_SelectedIndexChanged(object sender, EventArgs e)
    {


    }

    protected void set_session()
    {

    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    //Get HostIP//
    public string IpAddress()
    {
        try
        {
            string name = System.Net.Dns.GetHostName();
            string ip = System.Net.Dns.GetHostAddresses(name).GetValue(1).ToString();

            return ip;
        }


        catch
        {
            string name = System.Net.Dns.GetHostName();
            string ip = System.Net.Dns.GetHostAddresses(name).GetValue(0).ToString();

            return ip;
        }

    }
   
    protected void IndicatortypeLBdeptMang_Click(object sender, EventArgs e)
    {

        SqlConnection conn = new SqlConnection(sql_Connection);
        conn.Open();
        int pmp = int.Parse(Session_CS.pmp_id.ToString());
        string user = Session_CS.pmp_name.ToString();
        decimal budget = decimal.Parse(Session["Budget"].ToString());
        string dept_name = Session_CS.dept.ToString();
        string projmanage_name = Session["projectmanagername"].ToString();
        string proj_name = Session["projectname"].ToString();
        int dept_id = int.Parse(Session_CS.dept_id.ToString());
        int proj_id = int.Parse(Session_CS.Project_id.ToString());
 
        //sql = "SELECT TOP (100) PERCENT dbo.Project.Proj_Title, dbo.Departments.Dept_name, dbo.Departments.Dept_ID, dbo.Project.Proj_InitValue,";
        //sql += " dbo.employee.pmp_name,  dbo.Project.pmp_pmp_id, dbo.Project_Activities.Parent_PActv_Desc,";
        //sql += " dbo.Project_Activities_Indicators.PAI_Desc,  dbo.Project_Activities_Indicators.PAI_Wieght, ";
        //sql += " dbo.Project_Activities_Indicators.PAI_Unit, dbo.Project_Activities.PActv_Desc, dbo.Indicators_Type.IndT_Desc, ";
        //sql += "  dbo.Project.Proj_id, dbo.Project_Activities.PActv_Parent, dbo.Project_Activities_Indicators.PAI_attainment_value,";
        //sql += " dbo.Project_Activities_Indicators_History.PAIH_Date,  dbo.Project_Activities_Indicators_History.PAIH_Value, ";
        //sql += " dbo.Project_Activity_indicator_period.period_desc FROM dbo.Project INNER JOIN ";
        //sql += " dbo.Departments ON dbo.Project.Dept_Dept_id = dbo.Departments.Dept_ID INNER JOIN";
        //sql += " dbo.employee ON dbo.Project.Pmp_pmp_id = dbo.employee.pmp_id INNER JOIN";
        //sql += " dbo.Project_Activities ON dbo.Project.Proj_id = dbo.Project_Activities.proj_proj_id inner JOIN ";
        //sql += " dbo.Project_Activities_Indicators ON dbo.Project_Activities.PActv_ID = dbo.Project_Activities_Indicators.pactv_pactv_id inner JOIN";
        //sql += " dbo.Indicators_Type ON dbo.Project_Activities_Indicators.indt_indt_id = dbo.Indicators_Type.IndT_id left outer JOIN ";
        //sql += " dbo.Project_Activities_Indicators_History ON dbo.Project_Activities_Indicators.PAI_ID = dbo.Project_Activities_Indicators_History.pai_pai_id left outer JOIN ";
        //sql += " dbo.Project_Activity_indicator_period ON dbo.Project_Activities_Indicators.PAIP_period_id = dbo.Project_Activity_indicator_period.ID ";
        //sql += " where 1=1 ";
        sql = "select * ,(Case When PActv_Parent=0 Then PActv_Desc Else null End)as parent,(Case When PActv_Parent=0 Then 0 Else null End) as Parent_Actv_Num,PActv_Parent as LVL from Project_Activities  join project on Project_Activities.proj_proj_id=project.proj_id join Departments on project.Dept_Dept_id=Departments.Dept_ID inner join Project_Activities_Indicators on Project_Activities.PActv_ID=Project_Activities_Indicators.pactv_pactv_id inner join Indicators_Type on Project_Activities_Indicators.indt_indt_id=Indicators_Type.IndT_id inner join Project_Activity_indicator_period on Project_Activities_Indicators.PAIP_period_id=Project_Activity_indicator_period.ID inner join Project_Activities_Indicators_History on Project_Activities_Indicators.PAI_ID=Project_Activities_Indicators_History.pai_pai_id  join Organization on Project_Activities.Excutive_responsible_Org_Org_id = Organization.org_id where 1=1 ";
        sql += " AND dbo.Project.Proj_id=" + proj_id;
        sql += " AND dbo.Project.pmp_pmp_id =" + pmp;
        sql += " AND dbo.Departments.Dept_ID = " + dept_id;
        sql += " ORDER BY dbo.Project.Proj_id";
        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        ReportDocument rd = new ReportDocument();
        string s = Server.MapPath("../Reports/Indicator_Type_parameters.rpt");
        rd.Load(s);
        rd.SetDataSource(dt);
        Reports.Load_Report(rd);


        rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
        rd.SetParameterValue("@user", user, "footerRep.rpt");

        if (dt.Rows.Count == 0)
        {
            ShowAlertMessage("هذا التقرير لا يوجد به بيانات للعرض !!!!");
            return;
        }
        else
        {
            rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report");
        }



    }

    protected void PActivitiesPMLB_Click(object sender, EventArgs e)
    {

        SqlConnection conn = new SqlConnection(sql_Connection);
        string user = Session_CS.pmp_name.ToString();
        int pmp = int.Parse(Session_CS.pmp_id.ToString());
        decimal budget = decimal.Parse(Session["Budget"].ToString());
        string dept_name = Session_CS.dept.ToString();
        string projmanage_name = Session["projectmanagername"].ToString();
        string proj_name = Session["projectname"].ToString();
        int dept_id = int.Parse(Session_CS.dept_id.ToString());
        int proj_id = int.Parse(Session_CS.Project_id.ToString());
        //ReportDocument rd = new ReportDocument();

        //string s = Server.MapPath("../Reports/PActivities_parameter.rpt");
        //rd.Load(s);
        //Load_Report(rd);
        DataTable dt = new DataTable();

        dt = ActivLevls.leveling(proj_id, dept_id, pmp,0,0);
        ReportDocument rd = new ReportDocument();

        string s = Server.MapPath("../Reports/PActivities_parameter.rpt");
        rd.Load(s);
        Reports.Load_Report(rd);
        rd.SetDataSource(dt);

        rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
        rd.SetParameterValue("@user", user, "footerRep.rpt");


        if (dt.Rows.Count == 0)
        {
            ShowAlertMessage("هذا التقرير لا يوجد به بيانات للعرض !!!!");
            return;
        }
        else
        {
            rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report");
        }

    }
    protected void PFollowUpPMLB_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(sql_Connection);
        string user = Session_CS.pmp_name.ToString();
        int pmp = int.Parse(Session_CS.pmp_id.ToString());
        decimal budget = decimal.Parse(Session["Budget"].ToString());
        string dept_name = Session_CS.dept.ToString();
        string projmanage_name = Session["projectmanagername"].ToString();
        string proj_name = Session["projectname"].ToString();
        int dept_id = int.Parse(Session_CS.dept_id.ToString());
        int proj_id = int.Parse(Session_CS.Project_id.ToString());
        ReportDocument rd = new ReportDocument();


        string s = Server.MapPath("../Reports/Project_Follow_Report.rpt");
        rd.Load(s);
        Reports.Load_Report(rd);
        DataTable dt = new DataTable();

        dt = ActivLevls.leveling(proj_id, dept_id, pmp, 1, 0);
        rd.SetDataSource(dt);
        rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
        rd.SetParameterValue("@user", user, "footerRep.rpt");

        if (dt.Rows.Count == 0)
        {
            ShowAlertMessage("هذا التقرير لا يوجد به بيانات للعرض !!!!");
            return;
        }
        else
        {
            rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report");
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
    protected void ProjectneedReportLB_Click(object sender, EventArgs e)
    {


    }
    protected void show_hide_tables()
    {
        tbl_Report.Style.Add("display", "none");
        tbl_Paramater.Style.Add("display", "block");
    }
    public void Project_Team_Rep()
    {
        ReportDocument rd = new ReportDocument();
        string user = Session_CS.pmp_name.ToString();

        decimal budget = decimal.Parse(Session["Budget"].ToString());
        string dept_name = Session_CS.dept.ToString();
        int pmp = int.Parse(Session_CS.pmp_id.ToString());
        string projmanage_name = Session["projectmanagername"].ToString();
        string proj_name = Session["projectname"].ToString();
        int proj_id = int.Parse(Session_CS.Project_id.ToString());
        int dept_id = int.Parse(Session_CS.dept_id.ToString());

        sql = "SELECT dbo.Project.Proj_id, dbo.Project.Proj_Title, dbo.Departments.Dept_name,dbo.Departments.Dept_id, dbo.JOB_TITLE.JTIT_Desc, dbo.Project.Proj_InitValue, dbo.Project_Team.PTem_Name,";
        sql += " dbo.Project_Team.pmp_pmp_id,";
        sql += " dbo.Project_Team.rol_rol_id,PTem_Task";
        sql += " FROM dbo.Project INNER JOIN";
        sql += " dbo.Departments ON dbo.Project.Dept_Dept_id = dbo.Departments.Dept_ID INNER JOIN";
        sql += " dbo.Project_Team ON dbo.Project.Proj_id = dbo.Project_Team.proj_proj_id INNER JOIN";
        sql += " dbo.JOB_TITLE INNER JOIN";
        sql += " dbo.JOB ON dbo.JOB_TITLE.JTIT_ID = dbo.JOB.JTIT_JTIT_ID ON dbo.Project_Team.job_job_id = dbo.JOB.JOB_ID";
        sql += " where 1=1";
        sql += " AND dbo.Project.Proj_id = " + proj_id;


        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        string s = Server.MapPath("../Reports/Employees_Job_Category_Sticker.rpt");
        rd.Load(s);
        rd.SetDataSource(dt);
        Reports.Load_Report(rd);


        rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
        rd.SetParameterValue("@user", user, "footerRep.rpt");

        if (dt.Rows.Count == 0)
        {
            ShowAlertMessage("هذا التقرير لا يوجد به بيانات للعرض !!!!");
            return;
        }
        else
        {
            rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report");
        }
    }
    protected void EmployeeLB_Click(object sender, EventArgs e)
    {
        Project_Team_Rep();
    }
    protected void projectsneedapproveLB_Click(object sender, EventArgs e)
    {
        ReportDocument rd = new ReportDocument();
        string user = Session_CS.pmp_name.ToString();
        int proj_id = int.Parse(Session_CS.Project_id.ToString());
        int dept_id = int.Parse(Session_CS.dept_id.ToString());
        string s = Server.MapPath("../Reports/CrystalReport2.rpt");
        rd.Load(s);
        Reports.Load_Report(rd);
        rd.SetParameterValue(0, proj_id);
        rd.SetParameterValue(1, dept_id);
        rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
        rd.SetParameterValue("@user", user, "footerRep.rpt");
        if (rd.Rows.Count == 0)
        {
            ShowAlertMessage("هذا التقرير لا يوجد به بيانات للعرض !!!!");
            return;
        }
        else
        {
            rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.WordForWindows, Response, true, "Report");
        }

    }
    protected void Proj_Objective()
    {
        ReportDocument rd = new ReportDocument();
        string user = Session_CS.pmp_name.ToString();
        int pmp = int.Parse(Session_CS.pmp_id.ToString());
        decimal budget = decimal.Parse(Session["Budget"].ToString());
        string dept_name = Session_CS.dept.ToString();
        string projmanage_name = Session["projectmanagername"].ToString();
        string proj_name = Session["projectname"].ToString();
        int proj_id = int.Parse(Session_CS.Project_id.ToString());
        int dept_id = int.Parse(Session_CS.dept_id.ToString());
        sql = "SELECT dbo.Project.Proj_Title, dbo.Project_Objective.PObj_Desc,PObj_ID, dbo.Project.Proj_id, dbo.Departments.Dept_name,";
        sql += " dbo.Departments.Dept_ID, employee.pmp_name,  dbo.Project_Objective.PObj_Num,";
        sql += " dbo.Project.Proj_InitValue, employee.pmp_id";
        sql += " FROM dbo.Project_Objective INNER JOIN ";
        sql += " dbo.Project ON dbo.Project_Objective.proj_proj_id = dbo.Project.Proj_id INNER JOIN";
        sql += " dbo.Departments ON dbo.Project.Dept_Dept_id = dbo.Departments.Dept_ID INNER JOIN ";
        sql += " employee ON dbo.Project.pmp_pmp_id= employee.pmp_id where 1=1";
        sql += " AND dbo.Project.Proj_id = " + proj_id;
        sql += " AND dbo.Project.pmp_pmp_id = " + pmp;

        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        string s = Server.MapPath("../Reports/Proj_obj.rpt");
        rd.Load(s);
        rd.SetDataSource(dt);
        Reports.Load_Report(rd);

        rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
        rd.SetParameterValue("@user", user, "footerRep.rpt");
        if (dt.Rows.Count == 0)
        {
            ShowAlertMessage("هذا التقرير لا يوجد به بيانات للعرض !!!!");
            return;
        }
        else
        {
            rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report");
        }
    }
    protected void workorder()
    {
        ReportDocument rd = new ReportDocument();
        string user = Session_CS.pmp_name.ToString();
        int pmp = int.Parse(Session_CS.pmp_id.ToString());
        decimal budget = decimal.Parse(Session["Budget"].ToString());
        string dept_name = Session_CS.dept.ToString();
        string projmanage_name = Session["projectmanagername"].ToString();
        string proj_name = Session["projectname"].ToString();
        int proj_id = int.Parse(Session_CS.Project_id.ToString());
        int dept_id = int.Parse(Session_CS.dept_id.ToString());
        sql = "SELECT  Fin_Work_Order.Work_Order_ID, CONVERT(int, Fin_Work_Order.Work_Total_Value) AS Work_Total_Value, CONVERT(int, SUM(Fin_Bills.Bil_Value)) AS bil_total_value, Fin_Work_Order.Project_ID, CONVERT(int, Fin_Work_Order.Work_Total_Value) - CONVERT(int, SUM(Fin_Bills.Bil_Value)) AS sub, Project.Proj_Title, Fin_Work_Order.Code, Fin_Work_Order.Date, Fin_Work_Order.Tender_NO, Fin_Work_Order.Tender_Year FROM         Fin_Work_Order INNER JOIN                      Project ON Fin_Work_Order.Project_ID = Project.Proj_id LEFT OUTER JOIN                      Fin_Bills ON Fin_Work_Order.Work_Order_ID = Fin_Bills.Work_Order_ID";
        sql += " where Fin_Work_Order.Project_ID = " + proj_id;
        sql += " GROUP BY Fin_Work_Order.Work_Order_ID, Fin_Work_Order.Work_Total_Value, Fin_Work_Order.Project_ID, Fin_Work_Order.Project_ID, Project.Proj_Title, Fin_Work_Order.Code, Fin_Work_Order.Date, Fin_Work_Order.Tender_NO, Fin_Work_Order.Tender_Year ";

        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        string s = Server.MapPath("../Reports/work_order.rpt");
        rd.Load(s);
        rd.SetDataSource(dt);
        Reports.Load_Report(rd);

        rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
        rd.SetParameterValue("@user", user, "footerRep.rpt");
        if (dt.Rows.Count == 0)
        {
            ShowAlertMessage("هذا التقرير لا يوجد به بيانات للعرض !!!!");
            return;
        }
        else
        {
            rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report");
        }
    }
    protected void Proj_achievements()
    {
        ReportDocument rd = new ReportDocument();
        string user = Session_CS.pmp_name.ToString();
        int pmp = int.Parse(Session_CS.pmp_id.ToString());
        decimal budget = decimal.Parse(Session["Budget"].ToString());
        string dept_name = Session_CS.dept.ToString();
        string projmanage_name = Session["projectmanagername"].ToString();
        string proj_name = Session["projectname"].ToString();
        int proj_id = int.Parse(Session_CS.Project_id.ToString());
        int dept_id = int.Parse(Session_CS.dept_id.ToString());
        sql =" SELECT dbo.project_Achievements.ach_id,dbo.project_Achievements.ach_desc,";
        sql +=" dbo.project_Achievements.ach_type,dbo.project_Achievements.ach_other_desc,";
        sql +=" dbo.project_Achievements.ach_from_date,dbo.project_Achievements.ach_to_date,dbo.Project.Proj_Title,"; 
        sql +=" dbo.Project.Proj_id,dbo.Departments.Dept_name,dbo.Departments.Dept_ID,";
        sql += " Project_Team.pTem_name,achievments_types.type_desc , dbo.Project.Proj_InitValue";
        sql +=" FROM dbo.project_Achievements";
        sql +=" join achievments_types on project_Achievements.ach_type=achievments_types.type_id";
        sql +=" join project on project_Achievements.proj_id=project.proj_id";
        sql +=" join Departments on project.dept_dept_id=Departments.dept_id";
        sql += " join Project_Team on project.pmp_pmp_id=Project_Team.pmp_pmp_id and project.proj_id=Project_Team.proj_proj_id where 1=1";

        sql += " AND dbo.Project.Proj_id = " + proj_id;
        sql += " AND dbo.Project.pmp_pmp_id = " + pmp;

        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        string s = Server.MapPath("../Reports/Proj_achievments.rpt");
        rd.Load(s);
        rd.SetDataSource(dt);
        Reports.Load_Report(rd);

        rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
        rd.SetParameterValue("@user", user, "footerRep.rpt");
        if (dt.Rows.Count == 0)
        {
            ShowAlertMessage("هذا التقرير لا يوجد به بيانات للعرض !!!!");
            return;
        }
        else
        {
            rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report");
        }
    }
    protected void projobjectiveLB_Click(object sender, EventArgs e)
    {

        Proj_Objective();
    }
    protected void Work_orderLB_Click(object sender, EventArgs e)
    {

        workorder();
    }
    protected void projAchievmentLB_Click(object sender, EventArgs e)
    {

        Proj_achievements();
    }
    protected void Proj_Details()
    {
        //ReportDocument rd = new ReportDocument();
        //string user = Session_CS.pmp_name.ToString();
        //int pmp = int.Parse(Session_CS.pmp_id.ToString());
        //decimal budget = decimal.Parse(Session["Budget"].ToString());
        //string dept_name = Session_CS.dept.ToString();
        //string projmanage_name = Session["projectmanagername"].ToString();
        //string proj_name = Session["projectname"].ToString();
        //int proj_id = int.Parse(Session_CS.Project_id.ToString());
        //int dept_id = int.Parse(Session_CS.dept_id.ToString());
        ////sql = "SELECT dbo.Project.Proj_Title, dbo.Project_Objective.PObj_Desc,dbo.Project.proj_start_date,dbo.Project.Proj_End_Date,PObj_ID, dbo.Project.Proj_id, dbo.Departments.Dept_name,";
        ////sql += " dbo.Departments.Dept_ID, employee.pmp_name,  dbo.Project_Objective.PObj_Num,";
        ////sql += " dbo.Project.Proj_InitValue, employee.pmp_id";
        ////sql += " FROM dbo.Project_Objective INNER JOIN ";
        ////sql += " dbo.Project ON dbo.Project_Objective.proj_proj_id = dbo.Project.Proj_id INNER JOIN";
        ////sql += " dbo.Departments ON dbo.Project.Dept_Dept_id = dbo.Departments.Dept_ID INNER JOIN ";
        ////sql += " employee ON dbo.Project.pmp_pmp_id= employee.pmp_id where 1=1";
        ////sql += " AND dbo.Project.Proj_id = " + proj_id;
        ////sql += " AND dbo.Project.pmp_pmp_id = " + pmp;

        ////SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        ////DataTable dt = new DataTable();
        ////da.Fill(dt);
        //string s = Server.MapPath("../Reports/Proj_ALL_Data.rpt");
        ////string s = Server.MapPath("../Reports/proj_org_for_details.rpt");
        //rd.Load(s);
        //Load_Report(rd);
        //rd.SetParameterValue("@Proj_id", proj_id);

        //rd.SetParameterValue("@pmp", pmp);

        //rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
        //rd.SetParameterValue("@user", user, "footerRep.rpt");

        //if (rd.Rows.Count == 0)
        //{
        //    ShowAlertMessage("هذا التقرير لا يوجد به بيانات للعرض !!!!");
        //    return;
        //}
        //else
        //{
        //    rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report");
        //}

        //rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
        //rd.SetParameterValue("@user", user, "footerRep.rpt");
        //if (dt.Rows.Count == 0)
        //{
        //    ShowAlertMessage("هذا التقرير لا يوجد به بيانات للعرض !!!!");
        //    return;
        //}
        //else
        //{
        //    rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report");
        //}
    }
    protected void project_DetailsLB_Click(object sender, EventArgs e)
    {

        Proj_Details();
    }
    protected void projneedsLB_Click(object sender, EventArgs e)
    {
        //hidden_Rpt_Id.Value = "ProjectNeeds_Report";
        //Div_date.Style.Add("display", "block");
        //show_hide_tables();
        //headertable.Style.Add("display", "none");
        //header2table.Style.Add("display", "none");
        //header3table.Style.Add("display", "none");
        //Label4.Visible = true;
        //Page.Title = "تقرير " + projneedsLB.Text;
        //Label4.Text = Page.Title;



    }
    protected void weightpercentageLB_Click(object sender, EventArgs e)
    {
        //ReportDocument rd = new ReportDocument();
        //string user = Session_CS.pmp_name.ToString();
        //int pmp = int.Parse(Session_CS.pmp_id.ToString());
        //decimal budget = decimal.Parse(Session["Budget"].ToString());
        //string dept_name = Session_CS.dept.ToString();
        //string projmanage_name = Session["projectmanagername"].ToString();
        //string proj_name = Session["projectname"].ToString(); 
        //int proj_id = int.Parse(Session_CS.Project_id.ToString());
        //int dept_id = int.Parse(Session_CS.dept_id.ToString());
        //string s = Server.MapPath("../Reports/CrystalReport3.rpt");
        //rd.Load(s);

        //Load_Report(rd);
        //rd.SetParameterValue(0, proj_id);
        //rd.SetParameterValue(1, dept_id);
        //rd.SetParameterValue(2, pmp);
        //rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
        //rd.SetParameterValue("@user", user, "footerRep.rpt");

        //if (rd.Rows.Count == 0)
        //{
        //    ShowAlertMessage("هذا التقرير لا يوجد به بيانات للعرض !!!!");
        //    return;
        //}
        //else
        //{
        //    rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.WordForWindows, Response, true, "Report");
        //}

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        IpAddress();
        SqlConnection conn = new SqlConnection(sql_Connection);
        if (hidden_Rpt_Id.Value == "ProjectNeeds_Report")
        {

            //if (DropDate.SelectedValue != "0")
            //{

            //    ReportDocument rd = new ReportDocument();
            //    string user = Session_CS.pmp_name.ToString();
            //    int pmp = int.Parse(Session_CS.pmp_id.ToString());
            //    decimal budget = decimal.Parse(Session["Budget"].ToString());
            //    string dept_name = Session_CS.dept.ToString();
            //    string projmanage_name = Session["projectmanagername"].ToString();
            //    string proj_name = Session["projectname"].ToString();
            //    int proj_id = int.Parse(Session_CS.Project_id.ToString());
            //    int dept_id = int.Parse(Session_CS.dept_id.ToString());
            //    string s = Server.MapPath("../Reports/PNeeds_parameter.rpt");
            //    rd.Load(s);
            //    Load_Report(rd);
            //    rd.SetParameterValue("@Proj_id", proj_id);
            //    rd.SetParameterValue("@Dept_id", dept_id);
            //    rd.SetParameterValue("@PMP_id", pmp);
            //    rd.SetParameterValue("@availabledate",DropDate.SelectedItem.Text);
            //    rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
            //    rd.SetParameterValue("@user", user, "footerRep.rpt");

            //    if (rd.Rows.Count == 0)
            //    {
            //        ShowAlertMessage("هذا التقرير لا يوجد به بيانات للعرض !!!!");
            //        return;
            //    }
            //    else
            //    {
            //        rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.WordForWindows, Response, true, "Report");
            //    }


            //}
            //else
            //{
            //    ShowAlertMessage("!!!يجب اختيار تاريخ جرد");
            //    return;
            //}

        }

        else if (hidden_Rpt_Id.Value == "Link_Fin")
        {



            if (Drop_balance.SelectedValue != "0")
            {
                int pmp = int.Parse(Session_CS.pmp_id.ToString());
                int proj_id = int.Parse(Session_CS.Project_id.ToString());
                

                conn = new SqlConnection(sql_Connection);
                sql = "set dateformat dmy  SELECT Project.Proj_id, Project.Proj_Title, Departments.Dept_name,Project_Team.PTem_Name, Fin_Tender.Name, Fin_Work_Order.Tender_NO,Fin_Work_Order.Tender_Year, Fin_Work_Order.Code, substring(Fin_Work_Order.Date,7,4) as date, Fin_Work_Order.Work_Total_Value, Fin_Company.Company_Name,sum(Fin_Bills.Bil_Value) as Fin_Bills_Bil_Value FROM  Fin_Company INNER JOIN  Fin_Work_Order ON Fin_Company.Company_ID = Fin_Work_Order.Company_ID INNER JOIN Fin_Bills ON Fin_Work_Order.Work_Order_ID = Fin_Bills.Work_Order_ID INNER JOIN Fin_Tender ON Fin_Work_Order.Tender_Type_ID = Fin_Tender.ID INNER JOIN Departments INNER JOIN  Project ON Departments.Dept_ID = Project.Dept_Dept_id INNER JOIN  Project_Team ON Project.Proj_id = Project_Team.proj_proj_id ON Fin_Work_Order.Project_ID = Project.Proj_id ";
                sql += " WHERE (Project_Team.rol_rol_id = 4)";
                sql += " and Project_Team.pmp_pmp_id= " + pmp;
                sql += " and Project.Proj_id =" + proj_id;


                sql += " and  CONVERT(datetime,dbo.datevalid(dbo.Fin_Bills.Date)) > = '01" + "/07" + "/" + int.Parse(Drop_balance.Text.Substring(5, 4)) + "'";
                sql += " and  CONVERT(datetime,dbo.datevalid(dbo.Fin_Bills.Date)) < ='30" + "/06" + "/" + (int.Parse(Drop_balance.Text.Substring(5, 4)) + 1) + "'";



                sql += " group by Project.Proj_id, Project.Proj_Title, Departments.Dept_name, Project_Team.PTem_Name, Fin_Tender.Name, Fin_Work_Order.Tender_NO,Fin_Work_Order.Tender_Year, Fin_Work_Order.Code, Fin_Work_Order.Date, Fin_Work_Order.Work_Total_Value, Fin_Company.Company_Name ";

                
              

                    conn.Open();

                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count == 0)
                    {

                        ShowAlertMessage("!!!!!هذا التقرير لا يوجد به بيانات للعرض !!!!");
                        return;

                    }
                    else
                    {

                        ReportDocument rd = new ReportDocument();
                        string user = Session_CS.pmp_name.ToString();
                        //if (Smrt_Srch_DropDep.SelectedValue != "")
                        //{
                        //    dept_id = int.Parse(Smrt_Srch_DropDep.SelectedValue);
                        //}
                        string s = Server.MapPath("../Reports/Copy of Tender.rpt");

                        rd.Load(s);
                        rd.SetDataSource(dt);
                        rd.SetParameterValue("@Strt_DT", int.Parse(Drop_balance.Text.Substring(5, 4)));
                        rd.SetParameterValue("@End_DT", (int.Parse(Drop_balance.Text.Substring(5, 4)) + 1));
                        //rd.SetParameterValue("@Dept_ID", dept_id);
                        rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
                        rd.SetParameterValue("@user", user, "footerRep.rpt");
                        Reports.Load_Report(rd);
                        rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report");
                        conn.Close();
                    }

                
            }
            else
            {
                ShowAlertMessage("!!!!!يجب اختيار السنة المالية المطلوبة !!!!");
                return;
            }
            

        }



        //else if (hidden_Rpt_Id.Value == "Link_suggest_plan")
        //{
        //    int pmp = int.Parse(Session_CS.pmp_id.ToString());
        //    int proj_id = int.Parse(Session_CS.Project_id.ToString());
        //    int dept_id = int.Parse(Session_CS.dept_id.ToString());
        //    conn = new SqlConnection(sql_Connection);
        //    sql = " SELECT Project_Funding_Sources.Source_Name, Project_Period_Sources.Sources_ID, Project_Period_Sources.Value as 'total value', Project_Period_Balance.Quarter_Year,  Project_Exchange.Rewards  as 'أجور ومكافئات',Project_Exchange.Transitions as 'انتقالات',Project_Exchange.Hotels as 'حجز فنادق',Project_Exchange.Requirements as 'مستلزمات' , Project_Exchange.Training as'تدريب', Project_Exchange.Application as'تطبيقات', Project_Exchange.Tenders as'مناقصات/ممارسات', Project_Exchange.Resources as'موارد',Project_Exchange.Communication as'اتصالات',Project_Exchange.Engineering as'اعمال هندسية', Project_Exchange.Licence as'رخص برامج', Project_Exchange.Reinvestment as'إعادة استثمار',Project.Proj_Title,Project.Proj_id,Departments.Dept_name,Departments.Dept_ID,EMPLOYEE.PMP_ID,EMPLOYEE.pmp_name FROM Project_Period_Sources INNER JOIN Project_Period_Balance ON Project_Period_Sources.Period_ID = Project_Period_Balance.Period_ID INNER JOIN Project_Funding_Sources ON Project_Period_Sources.Sources_ID = Project_Funding_Sources.Sources_ID INNER JOIN Project_Exchange ON  Project_Period_Sources.Sources_ID = Project_Exchange.Sources_ID AND Project_Period_Sources.Provider_ID=Project_Exchange.Provider_ID AND Project_Period_Balance.Proj_id = Project_Exchange.Proj_id AND Project_Period_Balance.Quarter_Year = Project_Exchange.Year inner join  Project on Project_Exchange.Proj_id=Project.Proj_id inner join Departments on Project.Dept_Dept_id= Departments.Dept_ID inner join EMPLOYEE on Project.pmp_pmp_id=EMPLOYEE.PMP_ID WHERE 1=1  ";



        //    sql += " and  Departments.Dept_ID= " + dept_id;


        //    sql += " and EMPLOYEE.PMP_ID= " + pmp;


        //    if (Drop_balance.SelectedValue == "0")
        //    {
        //        Laberror.Visible = true;
        //        Laberror.Text = "اختر السنة المالية";

        //    }
        //    else
        //    {

        //        string d1 = Drop_balance.SelectedValue.Substring(5, 4);
        //        string date_1 = "01/07/" + d1;


        //        string d2 = Drop_balance.SelectedValue.Substring(0, 4);

        //        string date_2 = "30/06/" + d2;


        //        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        //        DataTable dt = new DataTable();
        //        da.Fill(dt);
        //        if (dt.Rows.Count > 0)
        //        {
        //            //string year1 = Drop_balance.SelectedValue;

        //            ReportDocument rd = new ReportDocument();
        //            string user = Session_CS.pmp_name.ToString();
        //            string s = Server.MapPath("../Reports/proj_sources_balance2.rpt");
        //            rd.Load(s);
        //            rd.SetDataSource(dt);
        //            rd.SetParameterValue("date1", d1);
        //            rd.SetParameterValue("date2", d2);
        //            rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
        //            rd.SetParameterValue("@user", user, "footerRep.rpt");
        //            Load_Report(rd);
        //            rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report");
        //            conn.Close();
        //        }
        //        else
        //        {
        //            ShowAlertMessage("!!!!!هذا التقرير لا يوجد به بيانات للعرض !!!!");
        //            return;
        //        }
        //    }
        //}

        else if (hidden_Rpt_Id.Value == "Link_suggest_plan")
        {
           if (Drop_balance.SelectedValue == "0")
            {
                Laberror.Visible = true;
                Laberror.Text = "اختر السنة المالية";
                
            }

          else
           {
            int pmp = int.Parse(Session_CS.pmp_id.ToString());
            int proj_id = int.Parse(Session_CS.Project_id.ToString());
            int dept_id = int.Parse(Session_CS.dept_id.ToString());
            conn = new SqlConnection(sql_Connection);
            sql = " SELECT Project_Funding_Sources.Source_Name, Project_Period_Sources.Sources_ID, Project_Period_Sources.Value as 'total value', Project_Period_Balance.Quarter_Year,  Project_Exchange.Rewards  as 'أجور ومكافئات',Project_Exchange.Transitions as 'انتقالات',Project_Exchange.Hotels as 'حجز فنادق',Project_Exchange.Requirements as 'مستلزمات' , Project_Exchange.Training as'تدريب', Project_Exchange.Application as'تطبيقات', Project_Exchange.Tenders as'مناقصات/ممارسات', Project_Exchange.Resources as'موارد',Project_Exchange.Communication as'اتصالات',Project_Exchange.Engineering as'اعمال هندسية', Project_Exchange.Licence as'رخص برامج', Project_Exchange.Reinvestment as'إعادة استثمار',Project.Proj_Title,Project.Proj_id,Departments.Dept_name,Departments.Dept_ID,EMPLOYEE.PMP_ID,EMPLOYEE.pmp_name FROM Project_Period_Sources INNER JOIN Project_Period_Balance ON Project_Period_Sources.Period_ID = Project_Period_Balance.Period_ID INNER JOIN Project_Funding_Sources ON Project_Period_Sources.Sources_ID = Project_Funding_Sources.Sources_ID INNER JOIN Project_Exchange ON  Project_Period_Sources.Sources_ID = Project_Exchange.Sources_ID AND Project_Period_Sources.Provider_ID=Project_Exchange.Provider_ID AND Project_Period_Balance.Proj_id = Project_Exchange.Proj_id AND Project_Period_Balance.Quarter_Year = Project_Exchange.Year inner join  Project on Project_Exchange.Proj_id=Project.Proj_id inner join Departments on Project.Dept_Dept_id= Departments.Dept_ID inner join EMPLOYEE on Project.pmp_pmp_id=EMPLOYEE.PMP_ID  WHERE 1=1 ";  

           sql += "and Project.Proj_id=" + proj_id;


                string d1 = Drop_balance.SelectedValue.Substring(5, 4);
                string date_1 = "01/07/" + d1;


                string d2 = Drop_balance.SelectedValue.Substring(0, 4);

                string date_2 = "30/06/" + d2;


                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    //string year1 = Drop_balance.SelectedValue;

                    ReportDocument rd = new ReportDocument();
                    string user = Session_CS.pmp_name.ToString();
                    string s = Server.MapPath("../Reports/proj_sources_balance2.rpt");
                    rd.Load(s);
                    rd.SetDataSource(dt);
                    rd.SetParameterValue("date1", d1);
                    rd.SetParameterValue("date2", d2);
                    rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
                    rd.SetParameterValue("@user", user, "footerRep.rpt");
                    Reports.Load_Report(rd);
                    rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report");
                    conn.Close();
                }
                else
                {
                    ShowAlertMessage("!!!!!هذا التقرير لا يوجد به بيانات للعرض !!!!");
                    return;
                }
            }
        }
    }


    protected void ImgBtnBack_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("../WebForms2/PMallReports.aspx");
    }
    protected void proj_notes_rep()
    {
        try
        {
            SqlConnection conn = new SqlConnection(sql_Connection);
            conn.Open();
            string user = Session_CS.pmp_name.ToString();
            int proj_id = int.Parse(Session_CS.Project_id.ToString());
            ReportDocument rd = new ReportDocument();
            string s = Server.MapPath("../Reports/Proj_Notes.rpt");
            rd.Load(s);
            Reports.Load_Report(rd);

            rd.SetParameterValue("@Proj_id", proj_id);

            rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
            rd.SetParameterValue("@user", user, "footerRep.rpt");

            if (rd.Rows.Count == 0)
            {
                ShowAlertMessage("هذا التقرير لا يوجد به بيانات للعرض !!!!");
                return;
            }
            else
            {
                rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.WordForWindows, Response, true, "Report");
            }
        }
        catch (Exception)
        {

            throw;
        }

    }
    protected void Proj_notesLB_Click(object sender, EventArgs e)
    {

    }
    public void project_abstract()
    {
        try
        {
            SqlConnection conn = new SqlConnection(sql_Connection);
            conn.Open();
            string user = Session_CS.pmp_name.ToString();
            int proj_id = int.Parse(Session_CS.Project_id.ToString());
            ReportDocument rd = new ReportDocument();
            string s = Server.MapPath("../Reports/Proj_Abstract.rpt");
            rd.Load(s);
            Reports.Load_Report(rd);
            rd.SetParameterValue("@Proj_id", proj_id);
            rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
            rd.SetParameterValue("@user", user, "footerRep.rpt");

            if (rd.Rows.Count == 0)
            {
                ShowAlertMessage("هذا التقرير لا يوجد به بيانات للعرض !!!!");
                return;
            }
            else
            {
                rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.WordForWindows, Response, true, "Report");
            }
        }
        catch (Exception)
        {

            throw;
        }


    }
    public void project_document()
    {
        try
        {
            SqlConnection conn = new SqlConnection(sql_Connection);
            conn.Open();

            string user = Session_CS.pmp_name.ToString();

            int proj_id = int.Parse(Session_CS.Project_id.ToString());
            ReportDocument rd = new ReportDocument();
            string s = Server.MapPath("../Reports/Project_doc.rpt");
            rd.Load(s);
            Reports.Load_Report(rd);

            rd.SetParameterValue("@Proj_id", proj_id);
            rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
            rd.SetParameterValue("@user", user, "footerRep.rpt");

            if (rd.Rows.Count == 0)
            {
                ShowAlertMessage("هذا التقرير لا يوجد به بيانات للعرض !!!!");
                return;
            }
            else
            {
                rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.WordForWindows, Response, true, "Report");
            }
        }
        catch (Exception)
        {

            throw;
        }

    }

    protected void Proj_AbstractLB_Click(object sender, EventArgs e)
    {

    }

    protected void Proj_docLB_Click(object sender, EventArgs e)
    {

    }
    protected void proj_cons_rep()
    {
        try
        {
            SqlConnection conn = new SqlConnection(sql_Connection);
            string user = Session_CS.pmp_name.ToString();
            int pmp = int.Parse(Session_CS.pmp_id.ToString());
            decimal budget = decimal.Parse(Session["Budget"].ToString());
            string dept_name = Session_CS.dept.ToString();
            string projmanage_name = Session["projectmanagername"].ToString();
            string proj_name = Session["projectname"].ToString();
            int dept_id = int.Parse(Session_CS.dept_id.ToString());
            int proj_id = int.Parse(Session_CS.Project_id.ToString());
            ReportDocument rd = new ReportDocument();


            string s = Server.MapPath("../Reports/Project_Constrains.rpt");
            rd.Load(s);
            Reports.Load_Report(rd);
            DataTable dt = new DataTable();

            dt = VB_Classes.Activities.Activities_Levl.Activities_levels_DT(proj_id, dept_id, pmp);
            rd.SetDataSource(dt);
            rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
            rd.SetParameterValue("@user", user, "footerRep.rpt");

            if (dt.Rows.Count == 0)
            {
                ShowAlertMessage("هذا التقرير لا يوجد به بيانات للعرض !!!!");
                return;
            }
            else
            {
                rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.WordForWindows, Response, true, "Report");
            }
        }
        catch (Exception)
        {

            throw;
        }

    }
    protected void Drop_balance_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    public void Yeardate()
    {
        for (int i = 0; i < 41; i++)
        {
            //Drop_balance.Items.Add(DateTime.Now.Year + i);

            int year = CDataConverter.ConvertDateTimeNowRtnDt().Year - 10 + i;
            string yearshowed = (year + 1) + "/" + year;
            //Drop_balance.Items.Add(year.ToString());
            Drop_balance.Items.Add(yearshowed);
            Drop_balance.DataBind();

        }
        Drop_balance.Items.Insert(0, new ListItem("اختر السنة المالية المطلوبة......", "0"));
    }


    protected void Proj_consLB_Click(object sender, EventArgs e)
    {

    }
    protected void Link_Fin_Click(object sender, EventArgs e)
    {

        hidden_Rpt_Id.Value = "Link_Fin";
        Div_date.Style.Add("display", "none");
        Div_Date_start.Style.Add("display", "none");
        Div_Balance.Style.Add("display", "block");

        show_hide_tables();
        Label6.Visible = true;
        Label4.Visible = true;
        Label4.Text = "تقرير " + Link_Fin.Text;
        Laberror.Visible = true;
        Page.Title = "تقرير " + Link_Fin.Text;
        headertable.Style.Add("display", "none");
        header3table.Style.Add("display", "none");
        Yeardate();
        //Label4.Visible = true;
        //Label4.Text = Page.Title;


    }


    protected void Link_suggest_plan_Click(object sender, EventArgs e)
    {
        hidden_Rpt_Id.Value = "Link_suggest_plan";
        Div_date.Style.Add("display", "none");
        Div_Date_start.Style.Add("display", "none");
        show_hide_tables();
        Label6.Visible = true;
        Label4.Visible = true;
        Div_Balance.Style.Add("display", "block");
        Label4.Text = "تقرير " + Link_suggest_plan.Text;
        Laberror.Visible = true;
        Page.Title = "تقرير " + Link_suggest_plan.Text;
        headertable.Style.Add("display", "none");
        header3table.Style.Add("display", "none");
        Yeardate();

    }
    protected void ALL_Act_Actions_No_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(sql_Connection);
        conn.Open();
        int pmp = int.Parse(Session_CS.pmp_id.ToString());
        string user = Session_CS.pmp_name.ToString();
        decimal budget = decimal.Parse(Session["Budget"].ToString());
        string dept_name = Session_CS.dept.ToString();
        string projmanage_name = Session["projectmanagername"].ToString();
        string proj_name = Session["projectname"].ToString();
        int dept_id = int.Parse(Session_CS.dept_id.ToString());
        int proj_id = int.Parse(Session_CS.Project_id.ToString());
       
        sql = "SELECT Project.proj_id,Project.Proj_Title, Departments.Dept_name, Project.Dept_Dept_id , Project.Pmp_pmp_id , employee.pmp_name,(select COUNT(Project_Activities.proj_proj_id) from Project_Activities where Project_Activities.proj_proj_id=project.Proj_id AND PActv_Parent=0) as  Parent_Act_Count,(select COUNT(Project_Activities.proj_proj_id) from Project_Activities where Project_Activities.proj_proj_id=project.Proj_id AND PActv_Parent<>0) as  child_Act_Count,(select COUNT(Project_Needs.proj_proj_id) from Project_Needs where Project_Needs.proj_proj_id=project.Proj_id ) as Pneeds,(select COUNT(Project_Objective.proj_proj_id) from Project_Objective where Project_Objective.proj_proj_id=project.Proj_id ) as proj_obj,(select COUNT(Project_Team.proj_proj_id) from Project_Team where Project_Team.proj_proj_id=project.Proj_id ) as proj_team,(select COUNT(Project_Organization.proj_proj_id) from Project_Organization where Project_Organization.proj_proj_id=project.Proj_id ) as proj_org FROM Departments INNER JOIN Project ON Departments.Dept_ID = Project.Dept_Dept_id LEFT OUTER JOIN employee on project.pmp_pmp_id=employee.pmp_id";
        sql += " where 1=1 ";
        sql += " AND dbo.Project.Proj_id=" + proj_id;
        sql += " AND dbo.Project.pmp_pmp_id =" + pmp;
        sql += " AND dbo.Departments.Dept_ID = " + dept_id;
        sql += " GROUP BY  Project.Proj_Title, Departments.Dept_name, Project.Dept_Dept_id,Project.Pmp_pmp_id,employee.pmp_name,project.Proj_id ";
        sql += " ORDER BY dbo.Project.Proj_id";
        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        ReportDocument rd = new ReportDocument();
        string s = Server.MapPath("../Reports/ALL_Activities_Actions_No_projmanage.rpt");
        rd.Load(s);
        rd.SetDataSource(dt);
        Reports.Load_Report(rd);

        rd.SetParameterValue(0, dept_id);
        rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
        rd.SetParameterValue("@user", user, "footerRep.rpt");

        if (dt.Rows.Count == 0)
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
