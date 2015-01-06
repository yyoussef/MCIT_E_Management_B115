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

public partial class WebForms_ProjectFollowUpPM : System.Web.UI.Page
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
                Label5.Visible = false;
                conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                /////////////////////////// get data to Department lable /////////////////////////////////////
                Label6.Text = Session_CS.pmp_name.ToString();
                int dept_id = int.Parse(Session_CS.dept_id.ToString());
                int pmp = int.Parse(Session_CS.pmp_id.ToString());
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
                DropDownList1.DataSource = ds.Tables[0];
                DropDownList1.DataTextField = "Proj_Title";
                DropDownList1.DataValueField = "Proj_id";
                DropDownList1.DataBind();
                DropDownList1.Items.Insert(0, new ListItem("اختر اسم المشروع......", "0"));



            }

        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

        if (DropDownList1.SelectedValue != "0")
        {
            sql = "select proj_id,proj_title,Parent_Actv_Num,PCONS_IS_CRITICAL,Parent_PActv_Desc,Child_Actv_Num,PActv_Desc,actv_sit_num,actv_sit_desc,PActv_wieght,Dept_id";
            sql += ",PActv_Start_Date,PActv_End_Date,PActv_Actual_End_Date,Org_Desc";
            sql += ",PCONS_DESC,PCONS_Sugg_Solutions";
            sql += " from Project_Activities";
            sql += " Full OUTER join Activity_sitiuation on Project_Activities.PActv_ID = Activity_sitiuation.project_activity_FK";
            sql += " Full OUTER join Project on Project_Activities.Proj_proj_id = project.Proj_id ";

            sql += " Full OUTER join Departments on Project.Dept_Dept_id = Departments.Dept_id ";

            sql += " Full OUTER join Project_Constraints on Project_Activities.PActv_ID = Project_Constraints.PActv_PActv_ID";
            sql += " Full OUTER join Project_Activities_Exe_Organization on Project_Activities.Excutive_responsible_Org_Org_id = Project_Activities_Exe_Organization.PAOrg_ID";
            sql += " Full OUTER join Organization On Project_Activities_Exe_Organization.org_org_id = Organization.Org_ID";
            sql += " where Project_Activities.proj_proj_id =project.Proj_id";
            //sql += " AND Dept_id= '" + int.Parse(Session_CS.dept_id.ToString()) + "'";

            sql += " AND proj_id= '" + DropDownList1.SelectedItem.Value + "'";

            //DateTime t1 = DateTime.Now;
            //DateTime t2 = DateTime.Now;
            //if (TextBox1.Text != "" && TextBox2.Text != "")
            //{
            //    t1 = DateTime.ParseExact(TextBox1.Text, "dd/MM/yyyy", null);
            //    t2 = DateTime.ParseExact(TextBox2.Text, "dd/MM/yyyy", null);

            //    if (t2.Subtract(t1).Days < 0)
            //    {
            //        Label4.Text = "التاريخ الاول اكبر من التاريخ الثاني !!!!!!!";
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
            sql += " order by proj_title,Parent_PActv_Desc,Parent_Actv_Num desc,Child_Actv_Num";
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

                Label5.Visible = false;
                string s = Server.MapPath("../Reports/Copy of PFollowUp.rpt");
                rd.Load(s);
                rd.SetDataSource(dt);
                rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.WordForWindows, Response, true, "Report.rpt");

            }
        }
        else
        {
            Label5.Visible = true;
            Label5.Text = "يجب إختيار المشروع اولا !!!!";

            return;
        }

    }

    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        Label5.Text = "";
    }
    protected void TextBox2_TextChanged(object sender, EventArgs e)
    {
        Label5.Text = "";
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Label5.Text = "";
    }
}
