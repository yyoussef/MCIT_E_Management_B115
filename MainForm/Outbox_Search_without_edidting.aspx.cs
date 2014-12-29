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
using ReportsClass;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;

public partial class WebForms_Outbox_Search_without_edidting : System.Web.UI.Page
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

        Smrt_Srch_org.sql_Connection = sql_Connection;
        //Smrt_Srch_org.Query = "select Org_ID,Org_Desc from Organization";
        string Query = "select Org_ID,Org_Desc from Organization";
        Smrt_Srch_org.datatble = General_Helping.GetDataTable(Query);
        Smrt_Srch_org.Value_Field = "Org_ID";
        Smrt_Srch_org.Text_Field = "Org_Desc";
        Smrt_Srch_org.DataBind();
        base.OnInit(e);
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
    public string IpAddress()
    {
        string name = "";
        string ip = "";
        try
        {
            name = System.Net.Dns.GetHostName();
            ip = System.Net.Dns.GetHostAddresses(name).GetValue(1).ToString();
            return ip;
        }
        catch
        {
            name = System.Net.Dns.GetHostName();
            ip = System.Net.Dns.GetHostAddresses(name).GetValue(0).ToString();
            return ip;
        }
    }
    public void SearchRecord()
    {
        string t1 = "";
        string t2 = "";
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        int group = int.Parse(Session_CS.group_id.ToString());
        int pmp = int.Parse(Session_CS.pmp_id.ToString());
        //SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        sql = "set dateformat dmy ";
        sql += " SELECT ID, Proj_id, Name, Code, Date,Org_Out_Box_Code,Group_id,pmp_pmp_id, incombination, Type, Emp_ID, Related_Type, Related_Id, Paper_No, Paper_Attached, Org_Dept_Name, outcombination, Org_Desc,";
        sql += " Org_Id,Subject,Org_Out_Box_DT,valid_date,out_valid_date";
        sql += " FROM From_Outbox_View where 1=1 AND Group_id= " + group;
        //int dept = int.Parse(Session_CS.dept_id.ToString());

        //if (txt_out_code.Text != "")
        //{
        //    sql += " AND Org_Out_Box_Code like" + "'%" + txt_out_code.Text + "%'";
        //}
        if (Txtcode.Text != "")
        {
            sql += " AND Code like" + "'%" + Txtcode.Text + "%'";
        }
        if (Inbox_name_text.Text != "")
        {
            sql += " AND Subject like" + "'%" + Inbox_name_text.Text + "%'";
        }
        if (Smrt_Srch_org.SelectedValue != "")
        {
            sql += " AND From_Outbox_View.Org_Id = " + Smrt_Srch_org.SelectedValue;
            //sql += " AND From_Outbox_View.Org_Desc like " + "'%" + Smrt_Srch_org.Text_Field + "%'";
        }
        if (string.IsNullOrEmpty(Inbox_date_from.Text) && string.IsNullOrEmpty(Inbox_date_to.Text))
        {
            t1 = DateTime.ParseExact("01/01/1900", "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
            t2 = DateTime.MaxValue.ToString("dd/MM/yyyy");
            //sql += " AND convert(datetime,valid_date) > = '" + t1.ToString() + "'";
            //sql += " AND convert(datetime,valid_date) < = '" + t2.ToString() + "'";
        } 
        else if (string.IsNullOrEmpty(Inbox_date_from.Text))
        {
            t1 = DateTime.ParseExact("01/01/1900", "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
            t2 = DateTime.ParseExact(Inbox_date_to.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");

            sql += " AND convert(datetime,valid_date) < = '" + t2.ToString() + "'";
        }
        else if (string.IsNullOrEmpty(Inbox_date_to.Text))
        {
            t1 = DateTime.ParseExact(Inbox_date_from.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
            t2 = DateTime.MaxValue.ToString("dd/MM/yyyy");

            sql += " AND convert(datetime,valid_date) > = '" + t1.ToString() + "'";
        }
        else
        {
            t1 = DateTime.ParseExact(Inbox_date_from.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");

            t2 = DateTime.ParseExact(Inbox_date_to.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");

            sql += " AND convert(datetime,valid_date) > = '" + t1.ToString() + "'";
            sql += " AND convert(datetime,valid_date) < = '" + t2.ToString() + "'";

        }
        DateTime date3 = DateTime.ParseExact(t1, "dd/MM/yyyy", null);
        DateTime date4 = DateTime.ParseExact(t2, "dd/MM/yyyy", null);
        if (date4.Subtract(date3).Days < 0)
        {
            ShowAlertMessage("!!!!!التاريخ الأول يجب ان يكون قبل التاريخ الثاني !!!!");
            return;
        }
        //////////////////////////////////////////////////////////// finished check on Date Field/////////////////////////////////////

       
      
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
        conn.Close();
    }

    protected void SaveButton_Click(object sender, EventArgs e)
    {
        SearchRecord();
    }

    
    protected void gvMain_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }
    protected void gvMain_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //if (e.CommandName=="EditItem")
        //{
        //    Response.Redirect("../webforms/Project_Outbox.aspx?id=" + e.CommandArgument);
        //}
        //if (e.CommandName == "RemoveItem")
        //{
        //    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        //    conn.Open();

        //    sql += "delete from Outbox where ID= " + e.CommandArgument;
        //    cmd = new SqlCommand(sql, conn);
        //    cmd.ExecuteNonQuery();
        //    conn.Close();

        //    gvMain.DataBind();
            
        //    Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم الحذف بنجاح')</script>");
        //    SearchRecord();
        //}
       
    }
    protected void gvMain_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvMain.PageIndex = e.NewPageIndex;
        SearchRecord();
    }
    
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
    }
    protected void btn_Report_Click(object sender, EventArgs e)
    {
        Reportfun();
    }
    protected void Reportfun()
    {
        string user = Session_CS.pmp_name.ToString();
        string t1 = "";
        string t2 = "";
        int group = int.Parse(Session_CS.group_id.ToString());
        int pmp = int.Parse(Session_CS.pmp_id.ToString());
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        sql = "set dateformat dmy ";
        sql += " SELECT ID, Proj_id, Name, Code, Date,Org_Out_Box_Code,Group_id,pmp_pmp_id, incombination, Type, Emp_ID, Related_Type, Related_Id, Paper_No, Paper_Attached, Org_Dept_Name, outcombination, Org_Desc,";
        sql += " Org_Id,Subject,Org_Out_Box_DT,valid_date,out_valid_date";
        sql += " FROM From_Outbox_View where 1=1 AND Group_id= " + group;
        //int dept = int.Parse(Session_CS.dept_id.ToString());

        
        if (Txtcode.Text != "")
        {
            sql += " AND Code like" + "'%" + Txtcode.Text + "%'";
        }
        if (Inbox_name_text.Text != "")
        {
            sql += " AND Subject like" + "'%" + Inbox_name_text.Text + "%'";
        }
        if (Smrt_Srch_org.SelectedValue != "")
        {
            sql += " AND From_Outbox_View.Org_Id = " + Smrt_Srch_org.SelectedValue;
        }
        if (string.IsNullOrEmpty(Inbox_date_from.Text) && string.IsNullOrEmpty(Inbox_date_to.Text))
        {
            t1 = DateTime.ParseExact("01/01/1900", "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
            t2 = DateTime.MaxValue.ToString("dd/MM/yyyy");
            //sql += " AND convert(datetime,valid_date) > = '" + t1.ToString() + "'";
            //sql += " AND convert(datetime,valid_date) < = '" + t2.ToString() + "'";
        }
        else if (string.IsNullOrEmpty(Inbox_date_from.Text))
        {
            t1 = DateTime.ParseExact("01/01/1900", "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
            t2 = DateTime.ParseExact(Inbox_date_to.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");

            sql += " AND convert(datetime,valid_date) < = '" + t2.ToString() + "'";
        }
        else if (string.IsNullOrEmpty(Inbox_date_to.Text))
        {
            t1 = DateTime.ParseExact(Inbox_date_from.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
            t2 = DateTime.MaxValue.ToString("dd/MM/yyyy");

            sql += " AND convert(datetime,valid_date) > = '" + t1.ToString() + "'";
        }
        else
        {
            t1 = DateTime.ParseExact(Inbox_date_from.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
            t2 = DateTime.ParseExact(Inbox_date_to.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");

            sql += " AND convert(datetime,valid_date) > = '" + t1.ToString() + "'";
            sql += " AND convert(datetime,valid_date) < = '" + t2.ToString() + "'";

        }
        DateTime date3 = DateTime.ParseExact(t1, "dd/MM/yyyy", null);
        DateTime date4 = DateTime.ParseExact(t2, "dd/MM/yyyy", null);
        if (date4.Subtract(date3).Days < 0)
        {
            ShowAlertMessage("!!!!!التاريخ الأول يجب ان يكون قبل التاريخ الثاني !!!!");
            return;
        }
        //////////////////////////////////////////////////////////// finished check on Date Field/////////////////////////////////////

        
       
        sql += " order by convert(datetime,valid_date) desc , Code desc";


        conn.Open();
        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        ReportDocument rd = new ReportDocument();
        string s = Server.MapPath("../Reports/Outbox_Report.rpt");
        rd.Load(s);
        rd.SetDataSource(dt);
        Reports.Load_Report(rd);
        rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
        rd.SetParameterValue("@user", user, "footerRep.rpt");
        if (dt.Rows.Count == 0)
        {
            ShowAlertMessage("هذا التقرير لا يوجد به بيانات للعرض !!!!");
            return;
        }
        else
        {
            rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report");
        }


        conn.Close();

    }
}

