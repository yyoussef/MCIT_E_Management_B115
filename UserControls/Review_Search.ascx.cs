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

public partial class UserControls_Review_Search : System.Web.UI.UserControl
{
    string sql;
    SqlConnection conn;
    SqlDataAdapter da;
    DataSet ds;
    SqlCommand cmd;
    private string sql_Connection = Database.ConnectionString;
    General_Helping Obj_General_Helping = new General_Helping();
    //Session_CS Session_CS = new Session_CS();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            //Fillddl();
            string sql2 = " select Group_id from employee where PMP_ID = " + int.Parse(Session_CS.pmp_id.ToString());
            DataTable DT2 = General_Helping.GetDataTable(sql2);
            //if (DT2.Rows[0]["Group_id"].ToString() == "2")
            //{
            //    tr_smart_proj.Visible = true;

            //}
           // ddlSubCat.Items.Insert(0, new ListItem("....اختر التصنيف الفرعي ....", "0"));
        }
    }
   
    protected override void OnInit(EventArgs e)
    {

        //Smrt_Srch_org.sql_Connection = sql_Connection;
        //Smrt_Srch_org.Query = "select Org_ID,Org_Desc from Organization";
        //Smrt_Srch_org.Value_Field = "Org_ID";
        //Smrt_Srch_org.Text_Field = "Org_Desc";
        //Smrt_Srch_org.DataBind();

        //Smart_Search_depts.sql_Connection = sql_Connection;
        //Smart_Search_depts.Query = "select Dept_ID,Dept_name from Departments";
        //Smart_Search_depts.Value_Field = "Dept_ID";
        //Smart_Search_depts.Text_Field = "Dept_name";
        //Smart_Search_depts.DataBind();

        //Smart_Search_Proj.sql_Connection = sql_Connection;
        //Smart_Search_Proj.Query = "SELECT Proj_id, Proj_Title FROM Project ";
        //Smart_Search_Proj.Value_Field = "Proj_id";
        //Smart_Search_Proj.Text_Field = "Proj_Title";
        //Smart_Search_Proj.DataBind();
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
        int dept = int.Parse(Session_CS.dept_id.ToString());
        string t1 = "";
        string t2 = "";

        int pmp = int.Parse(Session_CS.pmp_id.ToString());


        

       
        

        SqlParameter[] parms = new SqlParameter[5];
       
     
        parms[0] = new SqlParameter("@pmp", int.Parse(Session_CS.pmp_id.ToString()));
       
        
        parms[1] = new SqlParameter("@code", Txtcode.Text);
        parms[2] = new SqlParameter("@subject", Inbox_name_text.Text);

       
        if (Review_date_from.Text == "")
        {
            parms[3] = new SqlParameter("@Review_date_from", "01/01/1900");
        }
        else
            parms[3] = new SqlParameter("@Review_date_from", Review_date_from.Text);
        if (Review_date_to.Text == "")
        {
            parms[4] = new SqlParameter("@Review_date_to", CDataConverter.ConvertDateTimeToFormatdmy(DateTime.MaxValue));
        }
        else
            parms[4] = new SqlParameter("@Review_date_to", Review_date_to.Text);

       

       
        
       
       


        DataTable dt = new DataTable();
        dt = DatabaseFunctions.SelectDataByParam(parms, "Review_search_par");


        if (dt.Rows.Count == 0)
        {
            gvMain.EmptyDataText = ".....عفوا لا يوجد بيانات ......";
        }
        else
        {
            gvMain.DataSource = dt;
        }

        gvMain.DataBind();

    }
    protected void SaveButton_Click(object sender, EventArgs e)
    {
        SearchRecord();
        //int pmp = int.Parse(Session_CS.pmp_id.ToString());
        //if (Session_CS.Project_id != null && CDataConverter.ConvertToInt(Session_CS.Project_id.ToString()) > 0)
        //{
        //    gvMain.Columns[4].Visible = gvMain.Columns[0].Visible = false;
        //    if (Session_CS.UROL_UROL_ID != null && CDataConverter.ConvertToInt(Session_CS.UROL_UROL_ID) == 2)
        //    {
        //        gvMain.Columns[8].Visible = gvMain.Columns[9].Visible = false;
        //        gvMain.Columns[10].Visible = true;
        //    }
        //    else if (Session_CS.UROL_UROL_ID != null && CDataConverter.ConvertToInt(Session_CS.UROL_UROL_ID) == 3)
        //    {
        //        string sql1 = " SELECT Proj_id ,pmp_pmp_id " +
        //                " FROM     Project     " +
        //                " where Proj_id = '" + Session_CS.Project_id + "' and pmp_pmp_id = '" + Session_CS.pmp_id + "'";
        //        DataTable DT = General_Helping.GetDataTable(sql1);
        //        if (DT.Rows.Count <= 0)
        //        {
        //            gvMain.Columns[8].Visible = gvMain.Columns[9].Visible = false;
        //            gvMain.Columns[10].Visible = true;

        //        }
        //    }
        //}
        //else
        //    gvMain.Columns[1].Visible = gvMain.Columns[2].Visible = gvMain.Columns[5].Visible = gvMain.Columns[6].Visible = false;
        //if (pmp == 70)
        //{
        //    gvMain.Columns[8].Visible = gvMain.Columns[9].Visible = false;
        //    gvMain.Columns[10].Visible = true;
        //    //gvMain.Columns[9].Visible = true;
        //}



    }

    public string Get_Name()
    {
        return "ttt";
    }

    protected void gvMain_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void gvMain_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int pmp = int.Parse(Session_CS.pmp_id.ToString());
        DataTable dt = General_Helping.GetDataTable("select * from Review where pmp_pmp_id = " + pmp);
        if (e.CommandName == "EditItem")
        {
            string encrypted = Encryption.Encrypt(e.CommandArgument.ToString());
            if (dt.Rows.Count > 0)
            {
                Response.Redirect("ProjectReview.aspx?id=" + encrypted);
            }
            else

                Response.Redirect("ViewProjectReview.aspx?id=" + encrypted);
        }
        //if (e.CommandName == "RemoveItem")
        //{
        //    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        //    conn.Open();

        //    sql += "delete from Inbox where ID= " + e.CommandArgument;
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
   
}
