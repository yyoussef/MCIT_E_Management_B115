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

public partial class WebForms_IndicatorTypeMM : System.Web.UI.Page
{
    Session_CS Session_CS = new Session_CS();
    string sql;
    SqlConnection conn;
    SqlDataAdapter da;
    DataSet ds;

    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

        if (!IsPostBack)
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            /////////////////////////// get data to Department dropdown list /////////////////////////////////////
            sql = "select Dept_ID,Dept_name from Departments";
            ds = new DataSet();
            da = new SqlDataAdapter(sql, conn);
            da.Fill(ds, "dept");
            DropDep.DataSource = ds.Tables[0];
            DropDep.DataTextField = "Dept_name";
            DropDep.DataValueField = "Dept_ID";
            DropDep.DataBind();
            DropDep.Items.Insert(0, new ListItem("اختر اسم الإدارة......", "0"));

            /////////////////////////// get data to project dropdown list /////////////////////////////////////
            sql = "select Proj_id,Proj_Title from Project";
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
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

        if (DropProj.SelectedValue != "0")
        {
            sql = "select DiSTINCT Parent_PActv_Desc,PAI_Desc,PAI_Wieght ,PAI_Unit,PActv_Desc,IndT_Desc, Proj_title,Dept_id,Proj_id from Project_Activities_Indicators";
            sql += " Full OUTER join Project_Activities ON  pactv_pactv_id =PActv_id";
            sql += " Full OUTER join Indicators_Type on Project_Activities_Indicators.indt_indt_id=IndT_id";
            sql += " Full OUTER join Project on proj_proj_id=proj_id";
            sql += " Full OUTER join Departments on Project.Dept_Dept_id = Departments.Dept_id";
            sql += " where PActv_parent = 0";

            if (DropDep.SelectedValue != "0")
            {
                sql += " AND Dept_id= '" + DropDep.SelectedItem.Value + "'";
            }
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
                Label3.Visible = true;
                string nodata = "لا يوجد بيانات";
                Label3.Text = nodata;

            }
            else
            {

                Label3.Visible = false;
                string s = Server.MapPath("../Reports/Indicator_Type.rpt");
                rd.Load(s);
                rd.SetDataSource(dt);
                rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.WordForWindows, Response, true, "Report.rpt");

            }

        }
        else
        {
            Label3.Visible = true;
            Label3.Text = "اختر المشروع أولاً !!!!";

            return;
        }

    }
    protected void DropDep_SelectedIndexChanged(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        if (DropDep.SelectedValue == "0")
        {
            sql = "select Proj_id,Proj_Title from Project";
            ds = new DataSet();
            da = new SqlDataAdapter(sql, conn);
            da.Fill(ds, "projects");
            DropProj.DataSource = ds.Tables[0];
            DropProj.DataTextField = "Proj_Title";
            DropProj.DataValueField = "Proj_id";
            DropProj.DataBind();
            DropProj.Items.Insert(0, new ListItem("اختر اسم المشروع......", "0"));
        }
        else
        {
            sql = "select Proj_id,Proj_Title,Dept_Dept_id from Project where Dept_Dept_id=" + DropDep.SelectedItem.Value;
            ds = new DataSet();
            da = new SqlDataAdapter(sql, conn);
            da.Fill(ds, "projects");
            DropProj.DataSource = ds.Tables[0];
            DropProj.DataTextField = "Proj_Title";
            DropProj.DataValueField = "Proj_id";
            DropProj.DataBind();
            DropProj.Items.Insert(0, new ListItem("اختر اسم المشروع......", "0"));
        }
        Label3.Text = "";


    }
    protected void DropProj_SelectedIndexChanged(object sender, EventArgs e)
    {
        Label3.Text = "";
    }


}
