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

public partial class WebForms_ProjectNeedsPM : System.Web.UI.Page
{
    //Session_CS Session_CS = new Session_CS();
    string sql, sql2;
    SqlConnection conn;
    SqlDataAdapter da, da1;
    DataSet ds, ds1;
    protected void Page_Load(object sender, EventArgs e)
    {
        conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        if (Session_CS.pmp_name != null)
        {


            if (!IsPostBack)
            {
                Label4.Visible = false;
                conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                Label7.Text = Session_CS.pmp_name.ToString();
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
                DropDownList2.DataSource = ds.Tables[0];
                DropDownList2.DataTextField = "Proj_Title";
                DropDownList2.DataValueField = "Proj_id";
                DropDownList2.DataBind();
                DropDownList2.Items.Insert(0, new ListItem("اختر اسم المشروع......", "0"));

                /////////////////////////////// get dates from Store table to the dropdown list /////////////////////////////////////
                sql = "select id,convert(nvarchar,available_Date,111) as Date,available_Date from Store";
                ds = new DataSet();
                da = new SqlDataAdapter(sql, conn);
                da.Fill(ds, "dates");
                DropDownList1.DataSource = ds.Tables[0];
                DropDownList1.DataValueField = "available_Date";
                DropDownList1.DataTextField = "Date";
                DropDownList1.DataBind();
                DropDownList1.Items.Insert(0, new ListItem("اختر تاريخ الصرف المطلوب......", "0"));

            }

        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {


        if (DropDownList1.SelectedValue != "0")
        {

            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            sql2 = "SELECT PTem_ID,PTem_Name";
            sql2 += " FROM View_5";
            sql2 += " where PMP_ID=" + int.Parse(Session_CS.pmp_id.ToString());
            ds1 = new DataSet();
            da1 = new SqlDataAdapter(sql2, conn);
            da1.Fill(ds1, "ptem_id");
            int tem_id = int.Parse(ds1.Tables[0].Rows[0]["PTem_ID"].ToString());
            string name = ds1.Tables[0].Rows[0]["PTem_Name"].ToString();

            sql = "select pmp_pmp_id,Proj_Title,PTem_Name,PTem_ID,Proj_id,Store.*,";
            sql += " sum(case [nst_nst_ID] when 1 then approved_amount else 0 end) as [server_A],";
            sql += " sum(case [nst_nst_ID] when 1 then TotalDelievered else 0 end) as [server_D],";
            sql += " sum(case [nst_nst_ID] when 2 then approved_amount else 0 end) as [computer_A],";
            sql += " sum(case [nst_nst_ID] when 2 then TotalDelievered else 0 end) as [computer_D],";
            sql += " sum(case [nst_nst_ID] when 3 then approved_amount else 0 end) as [printer_A],";
            sql += " sum(case [nst_nst_ID] when 3 then TotalDelievered else 0 end) as [printer_D],";
            sql += " sum(case [nst_nst_ID] when 4 then approved_amount else 0 end) as [chair_A],";
            sql += " sum(case [nst_nst_ID] when 4 then TotalDelievered else 0 end) as [chair_D]";
            sql += " from ProjectNeedsView,Store where 1=1 AND pmp_pmp_id=" + int.Parse(Session_CS.pmp_id.ToString()) + " AND Store.available_Date= '" + DropDownList1.SelectedItem.Text + "'";


            if (DropDownList2.SelectedValue != "0")
            {
                sql += " AND Proj_id= '" + DropDownList2.SelectedValue + "'";
            }

            DateTime t1 = CDataConverter.ConvertDateTimeNowRtnDt();
            DateTime t2 = CDataConverter.ConvertDateTimeNowRtnDt();
            if (DropDownList1.SelectedValue != "0")
            {

                t1 = DateTime.Parse(DropDownList1.SelectedItem.Text);
                sql += " AND recieved_amount_date < '" + t1.ToString("MM/dd/yyyy") + "'";


            }
            sql += " group by pmp_pmp_id,Store.id,Store.PC_BrandName_No,Store.Printer_No,Store.PC_No,Store.Server_No,Store.available_Date,Proj_Title,proj_id,PTem_Name,PTem_ID";
            sql += " order by proj_title";




            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            ReportDocument rd = new ReportDocument();
            if (dt.Rows.Count == 0)
            {
                //CrystalReportViewer1.Visible = false;
                string nodata = "لا يوجد بيانات";
                Label4.Visible = true;
                Label4.Text = nodata;

            }
            else
            {
                //CrystalReportViewer1.Visible = true;
                Label4.Visible = false;
                string s = Server.MapPath("../Reports/PNeeds.rpt");
                rd.Load(s);
                rd.SetDataSource(dt);
                rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.WordForWindows, Response, true, "Report.rpt");
                // CrystalReportViewer1.ReportSource = rd;
                //CrystalReportViewer1.DataBind();

            }
        }
        else
        {
            // CrystalReportViewer1.Visible = false;
            Label4.Visible = true;
            Label4.Text = "اختر تاريخ الصرف المطلوب";

            return;
        }
    }




    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Label4.Text = "";


    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        Label4.Text = "";
    }
}
