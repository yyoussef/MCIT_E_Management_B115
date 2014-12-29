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





/// <summary>
/// Summary description for Reports
/// </summary>
/// 

namespace ReportsClass
{
   
    
    
    public class Reports : System.Web.UI.Page
    {
        Session_CS Session_CS = new Session_CS();
        string sql;
        static SqlConnection conn;
        SqlDataAdapter da;
        DataSet ds;
        public Reports()
        {


        }
        public void setsession()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            //IpAddress();

            string dept_name = Session_CS.dept.ToString();
            //Label2.Text = Session_CS.pmp_name.ToString();
            int proj_id = int.Parse(Session_CS.Project_id.ToString());
            decimal budget = decimal.Parse(System.Web.HttpContext.Current.Session["Budget"].ToString());
            sql = " select Proj_id,Proj_Title from Project where Proj_id = " + proj_id;
            ds = new DataSet();
            da = new SqlDataAdapter(sql, conn);
            da.Fill(ds, "project name");
            string proj_name = ds.Tables[0].Rows[0]["Proj_Title"].ToString();
            System.Web.HttpContext.Current.Session["projectname"] = proj_name;
            // Label3.Text = proj_name;

            int dept_id = int.Parse(Session_CS.dept_id.ToString());
            int pmp = int.Parse(Session_CS.pmp_id.ToString());
            sql = "select pmp_name , pmp_id from Employee where pmp_id = " + pmp;
            ds = new DataSet();
            da = new SqlDataAdapter(sql, conn);
            da.Fill(ds, "project manager name");
            string projmanage_name = ds.Tables[0].Rows[0]["pmp_name"].ToString();
            System.Web.HttpContext.Current.Session["projectmanagername"] = projmanage_name;
            //
            // TODO: Add constructor logic here
            //
        }
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
        public static void ShowAlertMessage(string error)
        {

            Page page = HttpContext.Current.Handler as Page;
            if (page != null)
            {
                error = error.Replace("'", "\'");
                ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('" + error + "');", true);
            }
        }
       

        public static void Load_Report(ReportDocument rd)
        {
            ConnectionInfo coninfo = new ConnectionInfo();
            TableLogOnInfos crTableLogonInfos = new TableLogOnInfos();
            System.Data.SqlClient.SqlConnectionStringBuilder builder = new System.Data.SqlClient.SqlConnectionStringBuilder();
            builder.ConnectionString = Database.ConnectionString;

            coninfo.ServerName = builder.DataSource;

            coninfo.DatabaseName = builder.InitialCatalog;
            coninfo.UserID = builder.UserID;
            coninfo.Password = builder.Password;

            foreach (CrystalDecisions.CrystalReports.Engine.Table table in rd.Database.Tables)
            {

                TableLogOnInfo crTableLogonInfo = new TableLogOnInfo();

                crTableLogonInfo.TableName = table.Name;

                crTableLogonInfo.ConnectionInfo = coninfo;

                crTableLogonInfos.Add(crTableLogonInfo);

                table.ApplyLogOnInfo(crTableLogonInfo);

            }
            for (int i = 0; i < rd.Subreports.Count; i++)
            {
                foreach (CrystalDecisions.CrystalReports.Engine.Table table222 in rd.Subreports[i].Database.Tables)
                {

                    TableLogOnInfo crTableLogonInfo = new TableLogOnInfo();

                    crTableLogonInfo.TableName = table222.Name;

                    crTableLogonInfo.ConnectionInfo = coninfo;

                    crTableLogonInfos.Add(crTableLogonInfo);

                    table222.ApplyLogOnInfo(crTableLogonInfo);

                    rd.Subreports[i].SetDatabaseLogon(coninfo.UserID, coninfo.Password, coninfo.ServerName, coninfo.DatabaseName);
                }

                rd.Subreports[i].SetDatabaseLogon(coninfo.UserID, coninfo.Password, coninfo.ServerName, coninfo.DatabaseName);
            }

        }

        public ReportDocument project_abstract()
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                conn.Open();
                setsession();
                string user = Session_CS.pmp_name.ToString();
                int proj_id = int.Parse(Session_CS.Project_id.ToString());
                ReportDocument rd = new ReportDocument();
                string s = Server.MapPath("../Reports/Proj_Abstract.rpt");
                rd.Load(s);
                Load_Report(rd);
                rd.SetParameterValue("@Proj_id", proj_id);
                rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
                rd.SetParameterValue("@user", user, "footerRep.rpt");
                return rd;
            }
            catch
            {

                return null;
                // throw;
            }



        }
        public ReportDocument project_document()
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                conn.Open();

                string user = Session_CS.pmp_name.ToString();

                int proj_id = int.Parse(Session_CS.Project_id.ToString());
                ReportDocument rd = new ReportDocument();
                string s = Server.MapPath("../Reports/Project_doc.rpt");
                rd.Load(s);
                Load_Report(rd);

                rd.SetParameterValue("@Proj_id", proj_id);
                rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
                rd.SetParameterValue("@user", user, "footerRep.rpt");
                return rd;
            }
            catch
            {
                return null;
            }


        }
        public ReportDocument Project_Team_Rep()
        {
            try
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
                sql = "SELECT dbo.Project.Proj_id, dbo.Project.Proj_Title, dbo.Departments.Dept_name,dbo.Departments.Dept_id,dbo.JOB_TITLE.JTIT_Desc,dbo.Project_Team.proj_proj_id, dbo.Project.Proj_InitValue, dbo.Project_Team.PTem_Name,dbo.Project_Team.rol_rol_id, Project.pmp_pmp_id, PTem_Task FROM dbo.Project INNER JOIN dbo.Departments ON dbo.Project.Dept_Dept_id = dbo.Departments.Dept_ID INNER JOIN dbo.Project_Team ON dbo.Project.Proj_id = dbo.Project_Team.proj_proj_id INNER JOIN dbo.JOB_TITLE INNER JOIN dbo.JOB ON dbo.JOB_TITLE.JTIT_ID = dbo.JOB.JTIT_JTIT_ID ON dbo.Project_Team.job_job_id = dbo.JOB.JOB_ID where 1=1 ";
                sql += " AND dbo.Project.Proj_id = " + proj_id;
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                string s = Server.MapPath("../Reports/Employees_Job_Category_Sticker.rpt");
                rd.Load(s);
                rd.SetDataSource(dt);
                Load_Report(rd);

                rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
                rd.SetParameterValue("@user", user, "footerRep.rpt");
                return rd;
            }
            catch
            {
                return null;
            }


        }
        public ReportDocument Proj_Objective()
        {
            try
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
                sql = "SELECT dbo.Project.Proj_Title, dbo.Project_Objective.PObj_Desc,PObj_ID, dbo.Project.Proj_id, dbo.Departments.Dept_name, dbo.Departments.Dept_ID, ";
                sql += " dbo.Project_Team.PTem_Name, dbo.Project_Team.rol_rol_id, dbo.Project_Objective.PObj_Num, dbo.Project.Proj_InitValue, dbo.Project_Team.pmp_pmp_id";
                sql += " FROM dbo.Project_Objective INNER JOIN dbo.Project ON dbo.Project_Objective.proj_proj_id = dbo.Project.Proj_id INNER JOIN";
                sql += " dbo.Departments ON dbo.Project.Dept_Dept_id = dbo.Departments.Dept_ID INNER JOIN";
                sql += " dbo.Project_Team ON dbo.Project.Proj_id = dbo.Project_Team.proj_proj_id";
                sql += " WHERE(dbo.Project_Team.rol_rol_id = 4)";
                sql += " AND dbo.Project.Proj_id = " + proj_id;
                sql += " AND dbo.Project_Team.pmp_pmp_id = " + pmp;
                sql += " AND dbo.Departments.Dept_ID = " + dept_id;
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                string s = Server.MapPath("../Reports/Proj_obj.rpt");
                rd.Load(s);
                rd.SetDataSource(dt);
                Load_Report(rd);

                rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
                rd.SetParameterValue("@user", user, "footerRep.rpt");
                return rd;
            }
            catch
            {

                return null;
            }

        }
        public ReportDocument proj_cons_rep()
        {

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
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
            Load_Report(rd);
            DataTable dt = new DataTable();

            dt = VB_Classes.Activities.Activities_Levl.Activities_levels_DT_cons(proj_id, dept_id, pmp);
            rd.SetDataSource(dt);
            rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
            rd.SetParameterValue("@user", user, "footerRep.rpt");
            //if (dt.Rows.Count == 0)
            //{
            //    ShowAlertMessage("هذا التقرير لا يوجد به بيانات للعرض !!!!");
            //    return null;
            //}
            //else
            //{
            //    rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.WordForWindows, Response, true, "Report");
            //}
            return rd;





        }
        public ReportDocument proj_notes_rep()
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                conn.Open();
                string user = Session_CS.pmp_name.ToString();
                int proj_id = int.Parse(Session_CS.Project_id.ToString());
                ReportDocument rd = new ReportDocument();
                string s = Server.MapPath("../Reports/Proj_Notes.rpt");
                rd.Load(s);
                Load_Report(rd);

                rd.SetParameterValue("@Proj_id", proj_id);

                rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
                rd.SetParameterValue("@user", user, "footerRep.rpt");

                return rd;
            }
            catch
            {

                return null;
            }


        }

    }
}
