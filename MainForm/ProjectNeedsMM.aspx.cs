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

public partial class WebForms_ProjectNeedsMM : System.Web.UI.Page
{
    Session_CS Session_CS = new Session_CS();
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

            /////////////////////// get data to manager drop //////////////////////////
            sql = "select distinct pmp_pmp_id,PTem_Name,rol_rol_id from dbo.Project_Team where rol_rol_id=4";
            ds = new DataSet();
            da = new SqlDataAdapter(sql, conn);
            da.Fill(ds, "projectsmanage");
            Projmanagedrop.DataSource = ds.Tables[0];
            Projmanagedrop.DataTextField = "PTem_Name";
            Projmanagedrop.DataValueField = "pmp_pmp_id";
            Projmanagedrop.DataBind();
            Projmanagedrop.Items.Insert(0, new ListItem("اختر اسم مدير المشروع ......", "0"));




            /////////////////////////////// get dates from Store table to the dropdown list /////////////////////////////////////
            sql = "select id,convert(nvarchar,available_Date,111) as Date,available_Date from Store";
            ds = new DataSet();
            da = new SqlDataAdapter(sql, conn);
            da.Fill(ds, "dates");
            DropDownList5.DataSource = ds.Tables[0];
            DropDownList5.DataValueField = "available_Date";
            DropDownList5.DataTextField = "Date";
            DropDownList5.DataBind();
            DropDownList5.Items.Insert(0, new ListItem("اختر تاريخ الصرف المطلوب......", "0"));


        }


    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        if (DropDownList5.SelectedValue != "0")
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            sql = "select Proj_Title,PTem_Name,PTem_ID,Proj_id,Dept_ID,Store.*,";
            sql += " sum(case [nst_nst_ID] when 1 then approved_amount else 0 end) as [server_A],";
            sql += " sum(case [nst_nst_ID] when 1 then TotalDelievered else 0 end) as [server_D],";
            sql += " sum(case [nst_nst_ID] when 2 then approved_amount else 0 end) as [computer_A],";
            sql += " sum(case [nst_nst_ID] when 2 then TotalDelievered else 0 end) as [computer_D],";
            sql += " sum(case [nst_nst_ID] when 3 then approved_amount else 0 end) as [printer_A],";
            sql += " sum(case [nst_nst_ID] when 3 then TotalDelievered else 0 end) as [printer_D],";
            sql += " sum(case [nst_nst_ID] when 4 then approved_amount else 0 end) as [chair_A],";
            sql += " sum(case [nst_nst_ID] when 4 then TotalDelievered else 0 end) as [chair_D]";
            sql += " from ProjectNeedsView,Store where 1=1 AND Store.available_Date= '" + DropDownList5.SelectedItem.Text + "'";

            if (Deptdrop.SelectedValue != "0")
            {
                sql += " AND Dept_ID= '" + Deptdrop.SelectedItem.Value + "'";
            }
            if (Projmanagedrop.SelectedValue != "0")
            {
                sql += " AND PTem_Name= '" + Projmanagedrop.SelectedItem.Text + "'";
            }
            if (projdrop.SelectedValue != "0")
            {
                sql += " AND Proj_id= '" + projdrop.SelectedValue + "'";
            }

            DateTime t1 = CDataConverter.ConvertDateTimeNowRtnDt();
            DateTime t2 = CDataConverter.ConvertDateTimeNowRtnDt();
            t1 = DateTime.Parse(DropDownList5.SelectedItem.Text);
            sql += " AND recieved_amount_date < '" + t1.ToString("MM/dd/yyyy") + "'";
            sql += " group by Dept_id,Store.id,Store.PC_BrandName_No,Store.Printer_No,Store.PC_No,Store.Server_No,Store.available_Date,Proj_Title,proj_id,PTem_Name,PTem_ID";
            sql += " order by proj_title";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            ReportDocument rd = new ReportDocument();

            if (dt.Rows.Count == 0)
            {

                Label4.Visible = true;
                string nodata = "لا يوجد بيانات";
                Label4.Text = nodata;

            }
            else
            {

                Label4.Visible = false;
                string s = Server.MapPath("../Reports/PNeeds.rpt");
                rd.Load(s);
                rd.SetDataSource(dt);
                rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.WordForWindows, Response, true, "Report.rpt");


            }
        }
        else
        {

            Label4.Visible = true;
            Label4.Text = "يجب اختيار تاريخ الصرف المراد";
            return;
        }

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
    protected void Projmanagedrop_SelectedIndexChanged(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

        if (Projmanagedrop.SelectedValue != "0")
        {
            sql = "SELECT dbo.Project_Team.PTem_Name, dbo.Project_Team.rol_rol_id, dbo.Project_Team.proj_proj_id, dbo.Project_Team.pmp_pmp_id, dbo.Project.Proj_Title,dbo.Departments.Dept_ID";
            sql += " FROM dbo.Project INNER JOIN dbo.Project_Team ON dbo.Project.Proj_id = dbo.Project_Team.proj_proj_id ";
            sql += " INNER JOIN dbo.Departments ON dbo.Project.Dept_Dept_id = dbo.Departments.Dept_ID";
            sql += " WHERE dbo.Project_Team.rol_rol_id = 4 AND dbo.Project_Team.pmp_pmp_id= " + Projmanagedrop.SelectedValue;

            ds = new DataSet();
            da = new SqlDataAdapter(sql, conn);
            da.Fill(ds, "projects");
            projdrop.DataSource = ds.Tables[0];
            projdrop.DataTextField = "Proj_Title";
            projdrop.DataValueField = "proj_proj_id";
            projdrop.DataBind();
            projdrop.Items.Insert(0, new ListItem("اختر اسم المشروع......", "0"));


        }
        else
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




        Label4.Text = "";
    }
    protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Label4.Text = "";
    }

    protected void DropDownList5_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Label4.Text = "";
    }
    protected void projdrop_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
