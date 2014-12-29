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

public partial class UserControls_Inbox_Search : System.Web.UI.UserControl
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

        if (!IsPostBack)
        {
            //int group = CDataConverter.ConvertToInt(Session_CS.group_id.ToString());
            //if (group == 2)
            //{
            //    tr_smart_proj.Visible = true;

            //}
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
        int group = CDataConverter.ConvertToInt(Session_CS.group_id.ToString());
        Smart_Search_emp.sql_Connection = sql_Connection;
        string Query = "";
        if (group!=3)
        {
            //Smart_Search_emp.Query = "SELECT pmp_id, pmp_name FROM employee ";
             Query = "SELECT pmp_id, pmp_name FROM employee ";
        }
        else
            //Smart_Search_emp.Query = "SELECT pmp_id, pmp_name,group_id FROM employee where group_id = 3  ";
             Query = "SELECT pmp_id, pmp_name,group_id FROM employee where group_id = 3  ";
        
         Smart_Search_emp.datatble=General_Helping.GetDataTable(Query);
        Smart_Search_emp.Value_Field = "pmp_id";
        Smart_Search_emp.Text_Field = "pmp_name";
        Smart_Search_emp.DataBind();
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
        if (group != 3)
        {
          
            sql += "SELECT * from Follow_Emp_View_inbox";
        }
        else
        {
            sql += "SELECT * from emp_folow_inbox_All_view";
        }
        
        sql+= " where 1=1 AND Group_id= " + group;
        //int dept = int.Parse(Session_CS.dept_id.ToString());

        if (Smart_Search_emp.SelectedValue != "")
        {
            if (group != 3)
            {
                sql += " AND  Follow_Emp_View_inbox.Visa_Emp_id = " + Smart_Search_emp.SelectedValue;
            }
            else
                sql += " AND  emp_folow_inbox_All_view.Visa_Emp_id = " + Smart_Search_emp.SelectedValue;
            
        }
        
        if (string.IsNullOrEmpty(Follow_date_from.Text) && string.IsNullOrEmpty(Follow_date_to.Text))
        {
           
                t1 = "01/01/1900";
                t2 = CDataConverter.ConvertDateTimeToFormatdmy(DateTime.MaxValue); 
           
        }
        else if (string.IsNullOrEmpty(Follow_date_from.Text))
        {
            if (VB_Classes.Dates.Dates_Operation.date_validate(Follow_date_to.Text.Trim()) != "")
            {
                t1 = "01/01/1900";
               //t2 = DateTime.ParseExact(Follow_date_to.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
                t2 = VB_Classes.Dates.Dates_Operation.date_validate(Follow_date_to.Text.Trim());
                if (group != 3)
                {
                    sql += " AND convert(datetime,dbo.datevalid(Follow_Emp_View_inbox.Date)) < = '" + t2.ToString() + "'";
                }
                else
                    sql += " AND convert(datetime,dbo.datevalid(emp_folow_inbox_All_view.Date)) < = '" + t2.ToString() + "'";
                
            }
            else
            {
                ShowAlertMessage("!!!!!ادخل التاريخ بطريقة صحيحة !!!!");
                return;
            }
        }
        else if (string.IsNullOrEmpty(Follow_date_to.Text))
        {
            if (VB_Classes.Dates.Dates_Operation.date_validate(Follow_date_from.Text.Trim()) != "")
            {
                //t1 = DateTime.ParseExact(Follow_date_from.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
                t2 = CDataConverter.ConvertDateTimeToFormatdmy(DateTime.MaxValue); 
                t1 = VB_Classes.Dates.Dates_Operation.date_validate(Follow_date_from.Text.Trim());
                if (group != 3)
                {
                    sql += " AND convert(datetime,dbo.datevalid(Follow_Emp_View_inbox.Date)) > = '" + t1.ToString() + "'";    
                }
                else
                    sql += " AND convert(datetime,dbo.datevalid(emp_folow_inbox_All_view.Date)) > = '" + t1.ToString() + "'";    
                

            }
            else
            {
                ShowAlertMessage("!!!!!ادخل التاريخ بطريقة صحيحة !!!!");
                return;
            }
        }
        else
        {
            if (VB_Classes.Dates.Dates_Operation.date_validate(Follow_date_to.Text.Trim()) != "" && VB_Classes.Dates.Dates_Operation.date_validate(Follow_date_from.Text.Trim()) !="")
            {
                //t1 = DateTime.ParseExact(Follow_date_from.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
                t2 = VB_Classes.Dates.Dates_Operation.date_validate(Follow_date_to.Text.Trim());
                //t2 = DateTime.ParseExact(Follow_date_to.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
                t1 = VB_Classes.Dates.Dates_Operation.date_validate(Follow_date_from.Text.Trim());
                if (group != 3)
                {
                    sql += " AND convert(datetime,dbo.datevalid(Follow_Emp_View_inbox.Date)) > = '" + t1.ToString() + "'";
                    sql += " AND convert(datetime,dbo.datevalid(Follow_Emp_View_inbox.Date)) < = '" + t2.ToString() + "'";
                }
                else
                {
                    sql += " AND convert(datetime,dbo.datevalid(emp_folow_inbox_All_view.Date)) > = '" + t1.ToString() + "'";
                    sql += " AND convert(datetime,dbo.datevalid(emp_folow_inbox_All_view.Date)) < = '" + t2.ToString() + "'";
                }
                
            }
            else
            {
                ShowAlertMessage("!!!!!ادخل التاريخ بطريقة صحيحة !!!!");
                return;
            }

        }
        DateTime date3 = CDataConverter.ConvertToDate(t1);
        DateTime date4 = CDataConverter.ConvertToDate(t2); 
        if (date4.Subtract(date3).Days < 0)
        {
            ShowAlertMessage("!!!!!التاريخ الأول يجب ان يكون قبل التاريخ الثاني !!!!");
            return;
        }
        //////////////////////////////////////////////////////////// finished check on Date Field/////////////////////////////////////

        
       
        //if (CDataConverter.ConvertToInt(Session_CS.Project_id.ToString()) > 0)
        //{
        //    sql += " AND Proj_id = " + int.Parse(Session_CS.Project_id.ToString());
        //}
        //else if (Session_CS.group_id.ToString()=="2" )
        //{
        //    if (Smart_Search_Proj.SelectedValue != "")
        //    {
        //        sql += " AND Proj_id = " + Smart_Search_Proj.SelectedValue;
        //    }
        //    //else
        //    //{
        //    //    sql += " AND Proj_id = 0";
        //    //}
        //}
        //else
        //    sql += " AND Proj_id = 0 AND Dept_Dept_ID = " + int.Parse(Session_CS.dept_id.ToString());
        if (group != 3)
        {
            sql += " order by convert(datetime,dbo.datevalid(Follow_Emp_View_inbox.Date)) desc ";
        }
        else
            sql += " order by convert(datetime,dbo.datevalid(emp_folow_inbox_All_view.Date)) desc ";
        


        conn.Open();
        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        DataTable dt = new DataTable();

        //for (int i = 0; i < dt.Rows.Count; i++)
        //{
        //    if (dt.Rows[i]["Descrption"].ToString()=="")
        //    {
                
        //    }
        //}
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
        //if (e.CommandName == "EditItem")
        //{
        //    Response.Redirect("Project_Inbox.aspx?id=" + e.CommandArgument);
        //}
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
