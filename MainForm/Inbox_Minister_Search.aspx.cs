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

public partial class WebForms_Inbox_Minister_Search : System.Web.UI.Page
{
    //Session_CS Session_CS = new Session_CS();
    string sql;
    SqlConnection conn;
    SqlDataAdapter da;
    DataSet ds;
    SqlCommand cmd;
    private string sql_Connection = Database.ConnectionString;
    General_Helping Obj_General_Helping = new General_Helping();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Fillddl();
        }
    }
    protected override void OnInit(EventArgs e)
    {

        Smrt_Srch_org.sql_Connection = sql_Connection;
     //   Smrt_Srch_org.Query = "select Org_ID,Org_Desc from Organization";
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
    public void SearchRecord()
    {

        string t1 = "";
        string t2 = "";
        int group = int.Parse(Session_CS.group_id.ToString());
        int pmp = int.Parse(Session_CS.pmp_id.ToString());
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        sql = "set dateformat dmy ";
        sql += " SELECT ID, Proj_id, Name, Code, Date,Group_id,pmp_pmp_id, incombination, Type, Emp_ID, Related_Type, Related_Id, Paper_No, Paper_Attached, Org_Dept_Name, outcombination, Org_Desc,";
        sql += " Org_Id,Subject,Org_Out_Box_DT,valid_date,out_valid_date";
        sql += " FROM from_inbox_Minister_view where 1=1";
        sql += " AND Group_id= " + group;
        //int dept = int.Parse(Session_CS.dept_id.ToString());


        if ( CDataConverter.ConvertToInt( ddlMainCat.SelectedValue)  >0 )
        {
            if (CDataConverter.ConvertToInt(ddlSubCat.SelectedValue) <= 0 )
            {
                sql += " AND  from_inbox_Minister_view.ID in (select inbox_min_id from Inbox_minister_cat where cat_id = " + ddlMainCat.SelectedValue + " and Type=1) ";
            }
            else
            {
               // sql += " AND  from_inbox_Minister_view.ID in (select inbox_min_id from Inbox_minister_cat where cat_id = " + ddlMainCat.SelectedValue + " and Type=1) ";
                sql += " AND  from_inbox_Minister_view.ID in (select inbox_min_id from Inbox_minister_cat where cat_id = " + ddlSubCat.SelectedValue + " and Type=2) ";
            }
        }
        if (Txtcode.Text != "")
        {
            sql += " AND from_inbox_Minister_view.Code like" + "'%" + Txtcode.Text + "%'";
        }
        if (Inbox_name_text.Text != "")
        {
            sql += " AND from_inbox_Minister_view.Subject like" + "'%" + Inbox_name_text.Text + "%'";
        }
        if (Smrt_Srch_org.SelectedValue != "")
        {
            sql += " AND from_inbox_Minister_view.Org_Id = " + Smrt_Srch_org.SelectedValue;
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

        /////////////////////////////////////////////////////// begin check on Outbox Date Field///////////////////////////////////////////
        if (string.IsNullOrEmpty(Outbox_date_from.Text) && string.IsNullOrEmpty(Outbox_date_to.Text))
        {
            t1 = DateTime.ParseExact("01/01/1900", "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
            t2 = DateTime.MaxValue.ToString("dd/MM/yyyy");
            //sql += " AND convert(datetime,out_valid_date) > = '" + t1.ToString() + "'";
            //sql += " AND convert(datetime,out_valid_date) < = '" + t2.ToString() + "' ";
        }
        else if (string.IsNullOrEmpty(Outbox_date_from.Text))
        {
            t1 = DateTime.ParseExact("01/01/1900", "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
            t2 = DateTime.ParseExact(Outbox_date_to.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");

            sql += " AND convert(datetime,out_valid_date) < = '" + t2.ToString() + "'";
        }
        else if (string.IsNullOrEmpty(Outbox_date_to.Text))
        {
            t1 = DateTime.ParseExact(Outbox_date_from.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
            t2 = DateTime.MaxValue.ToString("dd/MM/yyyy");

            sql += " AND convert(datetime,out_valid_date) > = '" + t1.ToString() + "'";
        }
        else
        {
            t1 = DateTime.ParseExact(Outbox_date_from.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
            t2 = DateTime.ParseExact(Outbox_date_to.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
            sql += " AND convert(datetime,out_valid_date) > = '" + t1.ToString() + "'";
            sql += " AND convert(datetime,out_valid_date) < = '" + t2.ToString() + "'";

        }
        ///////////////////////////////////////////////////////////////////// end check on sign_end _date/////////////////////////////////////
        DateTime date1 = DateTime.ParseExact(t1, "dd/MM/yyyy", null);
        DateTime date2 = DateTime.ParseExact(t2, "dd/MM/yyyy", null);
        if (date2.Subtract(date1).Days < 0)
        {
            ShowAlertMessage("!!!!!التاريخ الأول يجب ان يكون قبل التاريخ الثاني !!!!");
            return;
        }
        sql += " order by convert(datetime,valid_date) desc , convert(datetime,out_valid_date) desc";


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
        if (e.CommandName == "EditItem")
        {
            Response.Redirect("Project_Inbox_Minister.aspx?id=" + e.CommandArgument);
        }
        if (e.CommandName == "RemoveItem")
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            conn.Open();

            sql += "delete from Inbox_Minister where ID= " + e.CommandArgument;
            cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();

            gvMain.DataBind();

            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم الحذف بنجاح')</script>");
            SearchRecord();
        }

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
    protected void ddlMainCat_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillSubCat();
    }
    protected void Fillddl()
    {

        int group = CDataConverter.ConvertToInt(Session_CS.group_id.ToString());
        DataTable DT3 = General_Helping.GetDataTable("select * from Inbox_Main_Categories where group_id = '" + group +"'" );

        Obj_General_Helping.SmartBindDDL(ddlMainCat, DT3, "id", "name", "....اختر التصنيف الرئيسى ....");
    }
    protected void FillSubCat()
    {
        string sql = "";
        if (ddlMainCat.SelectedIndex != 0)
        {
            sql = "select * from Inbox_sub_categories where  main_id= " + ddlMainCat.SelectedValue;

        }
        else
            sql = "select * from Inbox_sub_categories where  main_id=0";
        DataTable dt = General_Helping.GetDataTable(sql);
        Obj_General_Helping.SmartBindDDL(ddlSubCat, dt, "id", "name", "....اختر التصنيف الفرعي ....");


    }
}

