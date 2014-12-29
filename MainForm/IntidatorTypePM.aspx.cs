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

public partial class WebForms_IntidatorTypePM : System.Web.UI.Page
{
    Session_CS Session_CS = new Session_CS();
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
                Label5.Visible = false;
                Label2.Text = Session_CS.pmp_name.ToString();
                int dept_id = int.Parse(Session_CS.dept_id.ToString());
                int pmp = int.Parse(Session_CS.pmp_id.ToString());
                conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                /////////////////////////// get the pmp id /////////////////////////////////////
                sql = "SELECT PTem_ID";
                sql += " FROM View_5";
                sql += " WHERE PMP_ID=" + int.Parse(Session_CS.pmp_id.ToString());

                ds = new DataSet();
                da = new SqlDataAdapter(sql, conn);
                da.Fill(ds, "ptem_id");
                int tem_id = int.Parse(ds.Tables[0].Rows[0]["PTem_ID"].ToString());

                /////////////////////////// get data to project of one user /////////////////////////////////////
                sql = " SELECT dbo.Project.Proj_id, dbo.Project.Proj_Title, dbo.Project.Dept_Dept_id, dbo.Project_Team.PTem_ID";
                sql += " FROM dbo.Project_Team INNER JOIN";
                sql += " dbo.Project ON dbo.Project_Team.proj_proj_id = dbo.Project.Proj_id INNER JOIN";
                sql += " dbo.Departments ON dbo.Project.Dept_Dept_id = dbo.Departments.Dept_ID";
                sql += " INNER JOIN dbo.Employee ON dbo.Project_Team.pmp_pmp_id = dbo.Employee.PMP_ID";


                sql += " WHERE PMP_ID=" + pmp;

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

    }
    protected void DropProj_SelectedIndexChanged(object sender, EventArgs e)
    {
        Label5.Text = "";

    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void IndicatortypeLBdeptMang_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

        if (DropProj.SelectedValue != "0")
        {
            sql = "select DiSTINCT Parent_PActv_Desc,PAI_Desc,PAI_Wieght ,PAI_Unit,PActv_Desc,IndT_Desc,Proj_title,Dept_id,Proj_id from Project_Activities_Indicators";
            sql += " Full OUTER join Project_Activities ON  pactv_pactv_id =PActv_id";
            sql += " Full OUTER join Indicators_Type on Project_Activities_Indicators.indt_indt_id=IndT_id";
            sql += " Full OUTER join Project on proj_proj_id=proj_id";
            sql += " Full OUTER join Departments on Project.Dept_Dept_id = Departments.Dept_id";
            sql += " where PActv_parent = 0";


            //sql += " AND Dept_id= '" + int.Parse(Session_CS.dept_id.ToString()) + "'";

            //if (DropProj.SelectedValue != "0")
            //{
            sql += " AND Proj_id= '" + DropProj.SelectedItem.Value + "'";
            // }

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            ReportDocument rd = new ReportDocument();

            if (dt.Rows.Count == 0)
            {
                Label5.Visible = true;
                string nodata = "لا يوجد بيانات";
                Label5.Text = nodata;

            }
            else
            {

                Label5.Visible = true;
                string s = Server.MapPath("../Reports/Indicator_Type.rpt");
                rd.Load(s);
                rd.SetDataSource(dt);
                rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.WordForWindows, Response, true, "Report");


            }



        }
        else
        {
            Label5.Visible = true;
            Label5.Text = "اختر  المشروع اولاً !!!!";
            // CrystalReportViewer1.Visible = false;
            return;
        }

    }
}
