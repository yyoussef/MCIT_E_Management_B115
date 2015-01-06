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

public partial class WebForms_IndicatorTypeDM : System.Web.UI.Page
{
    //Session_CS Session_CS = new Session_CS();
    string sql;
    SqlConnection conn;
    SqlDataAdapter da;
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        if (Session_CS.dept != null)
        {


            if (!IsPostBack)
            {

                Label5.Visible = false;
                conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                Label2.Text = Session_CS.dept.ToString();
                int dept_id = int.Parse(Session_CS.dept_id.ToString());
                /////////////// get data to project drop /////////////////////////////////////
                sql = "select Proj_id,Proj_Title,Dept_Dept_id from Project where Dept_Dept_id=" + dept_id;
                ds = new DataSet();
                da = new SqlDataAdapter(sql, conn);
                da.Fill(ds, "projects");
                DropProj.DataSource = ds.Tables[0];
                DropProj.DataTextField = "Proj_Title";
                DropProj.DataValueField = "Proj_id";
                DropProj.DataBind();
                DropProj.Items.Insert(0, new ListItem("اختر اسم المشروع......", "0"));
                //////////////////// get data to project manager drop ///////////////////////////
                sql = "select distinct pmp_pmp_id,PTem_Name,rol_rol_id from dbo.Project_Team where rol_rol_id=4";
                ds = new DataSet();
                da = new SqlDataAdapter(sql, conn);
                da.Fill(ds, "projectsmanage");
                Dropprojmanage.DataSource = ds.Tables[0];
                Dropprojmanage.DataTextField = "PTem_Name";
                Dropprojmanage.DataValueField = "pmp_pmp_id";
                Dropprojmanage.DataBind();
                Dropprojmanage.Items.Insert(0, new ListItem("اختر اسم مدير المشروع ......", "0"));

            }


        }

    }
    protected void DropProjMang_SelectedIndexChanged(object sender, EventArgs e)
    {
        Label5.Text = "";
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


        Label5.Text = "";

    }
    protected void IndicatortypeLBdeptMang_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

        if (DropProj.SelectedValue != "0")
        {

            sql = "select DiSTINCT Parent_PActv_Desc,PAI_Desc ,PAI_Unit,PAI_Wieght,PActv_Desc,IndT_Desc, Proj_title,Dept_id,Proj_id from Project_Activities_Indicators";
            sql += " Full OUTER join Project_Activities ON  pactv_pactv_id =PActv_id";
            sql += " Full OUTER join Indicators_Type on Project_Activities_Indicators.indt_indt_id=IndT_id";
            sql += " Full OUTER join Project on proj_proj_id=proj_id";
            sql += " Full OUTER join Departments on Project.Dept_Dept_id = Departments.Dept_id";
            sql += " where PActv_parent = 0";
            sql += " AND Dept_id= '" + int.Parse(Session_CS.dept_id.ToString()) + "'";

            //if (DropProj.SelectedValue != "0")
            //{
            sql += " AND Proj_id= '" + DropProj.SelectedItem.Value + "'";
            //}

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
            Label5.Text = "اختر  المشروع أولاً !!!!";
            return;
        }

    }
    protected void DropProj_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
