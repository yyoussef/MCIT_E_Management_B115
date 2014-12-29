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
using System.Text;
using System.Data.SqlClient;
using System.IO;

using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;

public partial class MainForm_Business_Card_System : System.Web.UI.Page
{
    Session_CS Session_CS = new Session_CS();
    string sql;
    SqlConnection conn;
    SqlDataAdapter da;
    DataSet ds;
    SqlCommand cmd;
    private string sql_Connection = Database.ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
       
        
    }
    protected override void OnInit(EventArgs e)
    {

        //Smrt_Srch_org.sql_Connection = sql_Connection;
        //Smrt_Srch_org.Query = "select Org_ID,Org_Desc from Organization";
        //Smrt_Srch_org.Value_Field = "Org_ID";
        //Smrt_Srch_org.Text_Field = "Org_Desc";
        //Smrt_Srch_org.DataBind();
        //base.OnInit(e);
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
    public void SearchRecord()
    {
        if (h1.Value != "0")
        {
            
                sql = "update Business_card set Name_ar = '" + Txtname_ar.Text + "'";
                sql += ", Name_eng = '" + Txtname_eng.Text + "'";
                sql += ", mobile1 = '" + txtmobile1.Text + "'";
                sql += ", mobile2 = '" + txtmobile2.Text + "'";
                sql += ", mail = '" + txtmail.Text + "'";
                sql += ", tel1 = '" + txtphone1.Text + "'";
                sql += ", tel2 = '" + txtphone2.Text + "'";
                sql += ", Fax = '" + txtfax.Text + "'";
                sql += ", org_ar = '" + txtorg_ar.Text + "'";
                sql += ", job_ar = '" + txtjob_ar.Text + "'";
                sql += ", Adress_ar = '" + txtadress_ar.Text + "'";
                sql += ", org_eng = '" + txtorg_eng.Text + "'";
                sql += ", job_eng = '" + txtjob_eng.Text + "'";
                sql += ", Adress_eng = '" + txtadress_eng.Text + "'";
                sql += " where ID = " + int.Parse(h1.Value);
                General_Helping.ExcuteQuery(sql);
                ShowAlertMessage("تم التعديل بنجاح");
                clear_controls();
                fillgrid();
                SaveButton.Text = "حفظ";
                h1.Value = "0";

            
        }
              
        
        else
        {

            //if (Txtname_ar.Text != "")
            //{
                
                sql = "insert into Business_Card values('" + Txtname_ar.Text + "','" + txtmobile1.Text + "','" + txtmobile2.Text + "','" + txtmail.Text + "','" + txtphone1.Text + "','" + txtphone2.Text + "','" + txtfax.Text + "','" + txtorg_ar.Text + "','" + txtjob_ar.Text + "','" + txtadress_ar.Text + "','" + Txtname_eng.Text + "','" + txtorg_eng.Text + "','" + txtadress_eng.Text + "','" + txtjob_eng.Text + "')";
                General_Helping.ExcuteQuery(sql);
                ShowAlertMessage("تم الحفظ بنجاح");
                clear_controls();
                fillgrid();
                
            //}
            //else
           // {
                //ShowAlertMessage("لم يتم كتابة الاسم ");
                //return;
            //}
          
        }
        
    }

    protected void SaveButton_Click(object sender, EventArgs e)
    {
        SearchRecord();
        h1.Value = "0";
    }

    
    protected void gvMain_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }
    protected void clear_controls()
    {
        Txtname_ar.Text = "";
        Txtname_eng.Text = "";
        txtadress_ar.Text = "";
        txtadress_eng.Text = "";
        txtfax.Text = "";
        txtjob_ar.Text = "";
        txtjob_eng.Text = "";
        txtmail.Text = "";
        txtmobile1.Text = "";
        txtmobile2.Text = "";
        txtorg_ar.Text = "";
        txtorg_eng.Text = "";
        txtphone1.Text = "";
        txtphone2.Text = "";
        
    }
    protected void gvMain_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        if (e.CommandName == "EditItem")
        {
            // Response.Redirect("../webforms/Project_Inbox.aspx?id=" + e.CommandArgument);
            sql = "select * from Business_card where ID = " + e.CommandArgument;
            da = new SqlDataAdapter(sql, conn);
            ds = new DataSet();
            da.Fill(ds);
            Txtname_ar.Text = ds.Tables[0].Rows[0]["Name_ar"].ToString();
            txtmobile1.Text = ds.Tables[0].Rows[0]["mobile1"].ToString();
            txtmobile2.Text = ds.Tables[0].Rows[0]["mobile2"].ToString();
            txtmail.Text = ds.Tables[0].Rows[0]["mail"].ToString();
            txtphone1.Text = ds.Tables[0].Rows[0]["tel1"].ToString();
            txtphone2.Text = ds.Tables[0].Rows[0]["tel2"].ToString();
            txtfax.Text = ds.Tables[0].Rows[0]["Fax"].ToString();
            txtorg_ar.Text = ds.Tables[0].Rows[0]["org_ar"].ToString();
            txtjob_ar.Text = ds.Tables[0].Rows[0]["job_ar"].ToString();
            txtadress_ar.Text = ds.Tables[0].Rows[0]["Adress_ar"].ToString();
            Txtname_eng.Text = ds.Tables[0].Rows[0]["Name_eng"].ToString();
            txtorg_eng.Text = ds.Tables[0].Rows[0]["org_eng"].ToString();
            txtjob_eng.Text = ds.Tables[0].Rows[0]["job_eng"].ToString();
            txtadress_eng.Text = ds.Tables[0].Rows[0]["Adress_eng"].ToString();


            h1.Value = e.CommandArgument.ToString();
            SaveButton.Text = "تعديل";
        }
        if (e.CommandName == "RemoveItem")
        {
            
            conn.Open();

            sql += "delete from business_card where ID= " + e.CommandArgument;
            cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();

            gvMain.DataBind();

            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم الحذف بنجاح')</script>");
            fillgrid();
        }
        
            
       
    }
    protected void gvMain_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        
    }
    
    protected void LinkButton1_Click(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        // SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        //sql = "SELECT dbo.Inbox.Date, dbo.Inbox.Code, dbo.Inbox.Org_Out_Box_DT, dbo.Inbox.Org_Out_Box_Code, dbo.Organization.Org_Desc, dbo.Inbox.Subject, dbo.Inbox.Paper_No,";
        //sql+=" dbo.Inbox_Visa.Visa_date, dbo.Inbox_Visa.Important_Degree, dbo.Departments.Dept_name, dbo.Inbox_Visa.Visa_Desc, dbo.Inbox_Visa.Visa_Period,";
        //sql += " dbo.Inbox_Visa.Follow_Up_Emp_ID, dbo.EMPLOYEE.pmp_name, dbo.Inbox_Visa.Emp_ID, EMPLOYEE_1.pmp_name AS exc_person";
        //sql+=" FROM dbo.EMPLOYEE INNER JOIN";
        //sql+=" dbo.Departments ON dbo.EMPLOYEE.Dept_Dept_id = dbo.Departments.Dept_ID INNER JOIN";
        //sql+=" dbo.EMPLOYEE AS EMPLOYEE_1 ON dbo.Departments.Dept_ID = EMPLOYEE_1.Dept_Dept_id RIGHT OUTER JOIN";
        //sql+=" dbo.Inbox_Visa ON EMPLOYEE_1.PMP_ID = dbo.Inbox_Visa.Emp_ID AND dbo.EMPLOYEE.PMP_ID = dbo.Inbox_Visa.Follow_Up_Emp_ID AND ";
        //sql+=" dbo.Departments.Dept_ID = dbo.Inbox_Visa.Dept_ID FULL OUTER JOIN";
        //sql+=" dbo.Organization RIGHT OUTER JOIN";
        //sql+=" dbo.Inbox ON dbo.Organization.Org_ID = dbo.Inbox.Org_Id ON dbo.Departments.Dept_ID = dbo.Inbox.Dept_ID AND dbo.Inbox_Visa.Inbox_ID = dbo.Inbox.ID";

        //SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        //DataTable dt = new DataTable();
        //da.Fill(dt);



        //ReportDocument rd = new ReportDocument();
        //string s = Server.MapPath("../Reports/Follow_Up_Inbox_Outbox.rpt");
        //rd.Load(s);
        //rd.SetDataSource(dt);
        //Load_Report(rd);
        
        ////rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
        ////rd.SetParameterValue("@user", user, "footerRep.rpt");
        //if (rd.Rows.Count == 0)
        //{
        //    ShowAlertMessage("هذا التقرير لا يوجد به بيانات للعرض !!!!");
        //    return;
        //}
        //else
        //{
         
           
        //    rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.Excel, Response, true, "Report");
        //}
    }
    protected void fillgrid()
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        sql = " SELECT * from Business_Card where 1=1 ";
        if (Txtname_ar.Text != "")
        {
            sql += " AND Name_ar like" + "'%" + Txtname_ar.Text + "%'";
        }
        if (txtorg_ar.Text != "")
        {
            sql += " AND org_ar like" + "'%" + txtorg_ar.Text + "%'";
        }
        if (txtjob_ar.Text != "")
        {
            sql += " AND job_ar like" + "'%" + txtjob_ar.Text + "%'";
        }
        if (Txtname_eng.Text != "")
        {
            sql += " AND Name_eng like" + "'%" + Txtname_eng.Text + "%'";
        }
        if (txtorg_eng.Text != "")
        {
            sql += " AND org_eng like" + "'%" + txtorg_eng.Text + "%'";
        }
        if (txtjob_eng.Text != "")
        {
            sql += " AND job_eng like" + "'%" + txtjob_eng.Text + "%'";
        }

        sql += " order by ID desc ";


        conn.Open();
        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        if (dt.Rows.Count == 0)
        {
            gvMain.EmptyDataText = ".....عفوا لا يوجد بيانات ......";
        }
        else
        {
            gvMain.DataSource = dt;
        }

        gvMain.DataBind();
        clear_controls();
    }
    protected void Search_Click(object sender, EventArgs e)
    {
        fillgrid();
    }
}

