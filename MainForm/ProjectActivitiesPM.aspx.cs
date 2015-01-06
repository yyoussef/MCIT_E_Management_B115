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

public partial class WebForms_ProjectActivitiesPM : System.Web.UI.Page
{
    //Session_CS Session_CS = new Session_CS();
    string sql;
    SqlConnection conn;
    SqlDataAdapter da;
    DataSet ds, ds1;

    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        if (Session_CS.pmp_name != null)
        {


            if (!IsPostBack)
            {
                conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                //int tem_id = 0;
                Label8.Text = Session_CS.pmp_name.ToString();
                Label5.Visible = false;
                int dept_id = int.Parse(Session_CS.dept_id.ToString());
                int pmp = int.Parse(Session_CS.pmp_id.ToString());
                /////////////////////////// get Manager dropdown list /////////////////////////////////////
                sql = "SELECT PTem_ID";
                sql += " FROM View_5";

                sql += " where PMP_ID=" + int.Parse(Session_CS.pmp_id.ToString());
                ds1 = new DataSet();
                da = new SqlDataAdapter(sql, conn);
                da.Fill(ds1, "ptem_id");

                int tem_id = int.Parse(ds1.Tables[0].Rows[0]["PTem_ID"].ToString());

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
                DropDownList2.DataSource = ds.Tables[0];
                DropDownList2.DataTextField = "Proj_Title";
                DropDownList2.DataValueField = "Proj_id";
                DropDownList2.DataBind();
                DropDownList2.Items.Insert(0, new ListItem("اختر اسم المشروع......", "0"));
            }

        }
    }

    protected void PActivitiesReportLink_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        if (DropDownList2.SelectedValue != "0")
        {
            sql = " SELECT TOP (100) PERCENT dbo.Project_Activities.PActv_Desc, dbo.Project_Activities.PActv_Start_Date, dbo.Project_Activities.PActv_End_Date,";
            sql += " dbo.Project_Activities.PActv_Parent, dbo.Project_Activities.proj_proj_id, dbo.Project_Activities.Parent_PActv_Desc, dbo.Project_Activities.Parent_Actv_Num,";
            sql += " dbo.Project_Activities.Child_Actv_Num, dbo.Project_Activities.Excutive_responsible_Org_Org_id, dbo.Project_Activities.PActv_Implementing_person,";
            sql += " dbo.Project_Activities.PActv_Implementing_Location, dbo.Project.Proj_id, dbo.Project.Proj_Title, dbo.Project.Proj_is_commit, dbo.Organization.Org_ID,";
            sql += " dbo.Organization.Org_Desc";
            sql += " FROM dbo.Project_Activities Full OUTER JOIN";
            sql += " dbo.Project ON dbo.Project_Activities.proj_proj_id = dbo.Project.Proj_id Full OUTER JOIN";
            sql += " dbo.Organization ON dbo.Project_Activities.Excutive_responsible_Org_Org_id = dbo.Organization.Org_ID";
            sql += " WHERE (dbo.Project.Proj_is_commit = 2)";


            //if (DropDownList2.SelectedValue != "0")
            //{
            sql += " AND proj_id= '" + DropDownList2.SelectedItem.Value + "'";
            //}
            //DateTime t1 = DateTime.Now;
            //DateTime t2 = DateTime.Now;
            //if (TextBox1.Text != "" && TextBox2.Text != "")
            //{
            //    t1 = DateTime.ParseExact(TextBox1.Text, "dd/MM/yyyy", null);
            //    t2 = DateTime.ParseExact(TextBox2.Text, "dd/MM/yyyy", null);


            //    if (t2.Subtract(t1).Days < 0)
            //    {
            //        Label7.Text = "التاريخ الاول أكبر من التاريخ الثاني !!!!!!!!!!!!";
            //        //CrystalReportViewer1.Visible = false;
            //        return;
            //    }

            //    sql += " AND PActv_Start_Date > '" + t1.ToString("MM/dd/yyyy") + "'";
            //    sql += " AND PActv_End_Date < '" + t2.ToString("MM/dd/yyyy") + "'";


            //}
            //else if (TextBox1.Text != "")
            //{
            //    t1 = DateTime.ParseExact(TextBox1.Text, "dd/MM/yyyy", null);

            //    sql += " AND PActv_Start_Date > '" + t1.ToString("MM/dd/yyyy") + "'";

            //}
            //else if (TextBox2.Text != "")
            //{
            //    t2 = DateTime.ParseExact(TextBox2.Text, "dd/MM/yyyy", null);
            //    sql += " AND PActv_End_Date < '" + t2.ToString("MM/dd/yyyy") + "'";
            //}
            sql += " ORDER BY dbo.Project_Activities.Parent_PActv_Desc";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            ReportDocument rd = new ReportDocument();

            if (dt.Rows.Count == 0)
            {

                Label5.Visible = true;

                Label5.Text = "لا يوجد بيانات";

            }
            else
            {

                Label5.Visible = false;
                string s = Server.MapPath("../Reports/PActivities.rpt");
                rd.Load(s);
                rd.SetDataSource(dt);
                rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.WordForWindows, Response, true, "Report.rpt");


            }

        }
        else
        {

            Label5.Visible = true;
            Label5.Text = "اختر المشروع المطلوب !!!!!!!";
            return;
        }

    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        Label5.Text = "";

    }
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        Label5.Text = "";

    }
    protected void TextBox2_TextChanged(object sender, EventArgs e)
    {
        Label5.Text = "";

    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
