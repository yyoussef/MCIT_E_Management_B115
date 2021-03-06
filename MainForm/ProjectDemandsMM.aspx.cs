﻿using System;
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

public partial class WebForms_ProjectDemandsMM : System.Web.UI.Page
{
    //Session_CS Session_CS = new Session_CS();
    string sql;
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
            DropDownList1.DataSource = ds.Tables[0];
            DropDownList1.DataTextField = "Dept_name";
            DropDownList1.DataValueField = "Dept_ID";
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, new ListItem("اختر اسم الإدارة......", "0"));
            TextBox1.Text = CDataConverter.ConvertDateTimeNowRtrnString();
            TextBox2.Text = CDataConverter.ConvertDateTimeNowRtrnString();

        }


    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        if (DropDownList1.SelectedValue != "0")
        {
            sql = "select PTem_name,need_Serial,Pned_name,PNed_Number,PNed_Date,Proj_Title,TotalDelievered,Dept_id,Dept_name from project_needs";
            sql += " join Project on project_needs.Proj_proj_id = project.Proj_id ";
            sql += " Full OUTER join employee on Project.pmp_pmp_id = EMPLOYEE.PMP_ID  ";
            sql += " Full OUTER join Departments on Project.Dept_Dept_id = Departments.Dept_id ";
            sql += " Full OUTER join project_team on project.proj_id = project_team.proj_proj_id ";

            // sql += " join need_recieve on project_needs.pned_id = need_recieve.pned_pned_id ";

            sql += " where  Project_Team.rol_rol_id = 4 AND Proj_is_commit=2";
            //if (DropDownList1.SelectedValue != "0")
            //{
            sql += " AND Dept_id= '" + DropDownList1.SelectedItem.Value + "'";
            //}
            DateTime t1 = CDataConverter.ConvertDateTimeNowRtnDt();
            DateTime t2 = CDataConverter.ConvertDateTimeNowRtnDt();
            if (TextBox1.Text != "" && TextBox2.Text != "")
            {
                t1 = DateTime.ParseExact(TextBox1.Text, "dd/MM/yyyy", null);
                t2 = DateTime.ParseExact(TextBox2.Text, "dd/MM/yyyy", null);


                if (t2.Subtract(t1).Days < 0)
                {
                    Label5.Visible = true;
                    Label5.Text = "التاريخ الأول أكبر من التاريخ الثاني !!!!!";
                    return;
                }
                sql += " AND PNed_Date > '" + t1.ToString("MM/dd/yyyy") + "'";
                sql += " AND PNed_Date < '" + t2.ToString("MM/dd/yyyy") + "'";


            }
            else if (TextBox1.Text != "")
            {
                t1 = DateTime.ParseExact(TextBox1.Text, "dd/MM/yyyy", null);
                sql += " AND PNed_Date > '" + t1.ToString("MM/dd/yyyy") + "'";

            }
            else if (TextBox2.Text != "")
            {
                t2 = DateTime.ParseExact(TextBox2.Text, "dd/MM/yyyy", null);
                sql += " AND PNed_Date < '" + t2.ToString("MM/dd/yyyy") + "'";
            }
            sql += "order by Proj_Title,PTem_name,need_Serial ";

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
                string s = Server.MapPath("../Reports/projectDemands.rpt");
                rd.Load(s);
                rd.SetDataSource(dt);
                rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.WordForWindows, Response, true, "Report.rpt");

            }

        }
        else
        {
            Label4.Visible = true;
            Label4.Text = "يجب اختيار الإدارة أولاً!!!!!!!";

            return;
        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Label4.Text = "";
    }
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        Label4.Text = "";
    }
    protected void TextBox2_TextChanged(object sender, EventArgs e)
    {
        Label4.Text = "";
    }
}
