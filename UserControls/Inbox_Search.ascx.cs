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
using System.Security.Cryptography;

public partial class UserControls_Inbox_Search : System.Web.UI.UserControl
{
    string sql;
    SqlConnection conn;
    SqlDataAdapter da;
    DataSet ds;
    SqlCommand cmd;
    private string sql_Connection = Database.ConnectionString;
    General_Helping Obj_General_Helping = new General_Helping(); //Session_CS Session_CS = new Session_CS();
    protected void Page_Load(object sender, EventArgs e)
    {
        Smart_Search_depts.Show_OrgTree = true;
        if (!IsPostBack)
        {
            Fillddl();
            Fill_Groups();
            string sql2 = " select Group_id from employee where PMP_ID = " + int.Parse(Session_CS.pmp_id.ToString());
            DataTable DT2 = General_Helping.GetDataTable(sql2);
            if (DT2.Rows[0]["Group_id"].ToString() == "2")
            {
                tr_smart_proj.Visible = true;

            }
            ddlSubCat.Items.Insert(0, new ListItem("....اختر التصنيف الفرعي ....", "0"));


            if (Session_CS.code_archiving == 1)
            {
                Txtcode.Enabled = false;
            }
            else
            {

                Txtcode.Enabled = true;
            }


        }
    }



    private void Fill_Groups()
    {
       // string sql = "select * from Employee_Groups where foundation_id=" + CDataConverter.ConvertToInt(Session_CS.foundation_id.ToString());
  
       // DataTable dt = General_Helping.GetDataTable(sql);
          DataTable dt = Employee_Groups_DB.SelectAll(CDataConverter.ConvertToInt(Session_CS.foundation_id.ToString()));
        ddl_Groups.DataSource = dt;
        ddl_Groups.DataValueField = "ID";
        ddl_Groups.DataTextField = "Name";
        ddl_Groups.DataBind();
        ddl_Groups.Items.Insert(0, new ListItem("اختر المجموعة......", "0"));
    }

    protected void ddlMainCat_SelectedIndexChanged(object sender, EventArgs e)
    {

        FillSubCat();
    }
    //public static string Encrypt(string pstrText)
    //{
    //    string pstrEncrKey = "1239;[pewGKG)NisarFidesTech";
    //    byte[] byKey = { };
    //    byte[] IV = { 18, 52, 86, 120, 144, 171, 205, 239 };
    //    byKey = System.Text.Encoding.UTF8.GetBytes(pstrEncrKey.Substring(0, 8));
    //    DESCryptoServiceProvider des = new DESCryptoServiceProvider();
    //    byte[] inputByteArray = Encoding.UTF8.GetBytes(pstrText);
    //    MemoryStream ms = new MemoryStream();
    //    CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(byKey, IV), CryptoStreamMode.Write);
    //    cs.Write(inputByteArray, 0, inputByteArray.Length);
    //    cs.FlushFinalBlock();
    //    return Convert.ToBase64String(ms.ToArray());
    //}
    protected void FillSubCat()
    {
        string sql = "";
        conn = new SqlConnection(sql_Connection);
        //Drop_category.Items.Insert(0, new ListItem("اختر التصنيف......", "0"));
        if (ddlMainCat.SelectedValue != "0")
        {
            sql = "select * from Inbox_sub_categories where  main_id= " + ddlMainCat.SelectedValue;

        }
        else
            sql = "select * from Inbox_sub_categories where  main_id=0";
        da = new SqlDataAdapter(sql, conn);
        ds = new DataSet();
        da.Fill(ds, "category");
        ddlSubCat.DataSource = ds.Tables[0];
        ddlSubCat.DataValueField = "id";
        ddlSubCat.DataTextField = "name";
        ddlSubCat.DataBind();
        // DataTable dt = General_Helping.GetDataTable(sql);
        ddlSubCat.Items.Insert(0, new ListItem("....اختر التصنيف الفرعي ....", "0"));
        // Obj_General_Helping.SmartBindDDL(ddlSubCat, dt, "id", "name", "....اختر التصنيف الفرعي ....");


    }
    protected void Fillddl()
    {
        conn = new SqlConnection(sql_Connection);
        int group = CDataConverter.ConvertToInt(Session_CS.group_id.ToString());
        sql = "select * from Inbox_Main_Categories where group_id = " + group;
        da = new SqlDataAdapter(sql, conn);
        ds = new DataSet();
        da.Fill(ds, "maincategory");
        ddlMainCat.DataSource = ds.Tables[0];
        ddlMainCat.DataValueField = "id";
        ddlMainCat.DataTextField = "name";
        ddlMainCat.DataBind();
        ddlMainCat.Items.Insert(0, new ListItem("....اختر التصنيف الرئيسى ....", "0"));
        //DataTable DT3 = General_Helping.GetDataTable("select * from Inbox_Main_Categories where group_id = " + group + " and id <>" + 1);

        ///Obj_General_Helping.SmartBindDDL(ddlMainCat, DT3, "id", "name", "....اختر التصنيف الرئيسى ....");
    }
    protected override void OnInit(EventArgs e)
    {
        string Query = "";
        int found_id = CDataConverter.ConvertToInt(Session_CS.foundation_id.ToString());
        Smrt_Srch_org.sql_Connection = sql_Connection;
        //Smrt_Srch_org.Query = "select Org_ID,Org_Desc from Organization where foundation_id = " + found_id;
        Query = "select Org_ID,Org_Desc from Organization where foundation_id = " + found_id;
        Smrt_Srch_org.datatble = General_Helping.GetDataTable(Query);
        Smrt_Srch_org.Value_Field = "Org_ID";
        Smrt_Srch_org.Text_Field = "Org_Desc";
        Smrt_Srch_org.DataBind();

        Smart_Search_depts.sql_Connection = sql_Connection;
        //Smart_Search_depts.Query = "select Dept_ID,Dept_name from Departments inner join dbo.Sectors on Departments.Sec_sec_id=Sectors.Sec_id where Sectors.foundation_id='" + Session_CS.foundation_id + "' ";
        Query = "select Dept_ID,Dept_name,Dept_parent_id from Departments  where foundation_id='" + Session_CS.foundation_id + "' ";
        Smart_Search_depts.datatble = General_Helping.GetDataTable(Query);
        Smart_Search_depts.Value_Field = "Dept_ID";
        Smart_Search_depts.Text_Field = "Dept_name";
        Smart_Search_depts.DataBind();

        Smart_Search_Proj.sql_Connection = sql_Connection;
        //Smart_Search_Proj.Query = "SELECT Proj_id, Proj_Title FROM Project ";
        Query = "SELECT Proj_id, Proj_Title FROM Project ";
        Smart_Search_Proj.datatble = General_Helping.GetDataTable(Query);
        Smart_Search_Proj.Value_Field = "Proj_id";
        Smart_Search_Proj.Text_Field = "Proj_Title";
        Smart_Search_Proj.DataBind();




        Smart_Emp_ID.sql_Connection = sql_Connection;
        Query = "SELECT EMPLOYEE.PMP_ID, EMPLOYEE.pmp_name FROM EMPLOYEE  where foundation_id='"+Session_CS.foundation_id+"' and EMPLOYEE.workstatus!=4";
     
        //Query += "where Departments.sec_sec_id =  " + CDataConverter.ConvertToInt(Session_CS.sec_id);

        Smart_Emp_ID.datatble = General_Helping.GetDataTable(Query);
        Smart_Emp_ID.Value_Field = "pmp_id";
        Smart_Emp_ID.Text_Field = "pmp_name";
        Smart_Emp_ID.Orderby = "ORDER BY LTRIM(pmp_name)";
        Smart_Emp_ID.DataBind();



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


        int session_group = 0;
        int selected_group = 0;

        if (CDataConverter.ConvertToInt(Session_CS.parent_id.ToString()) > 0 || CDataConverter.ConvertToInt(Session_CS.child_emp.ToString()) > 0)
        {
            session_group = int.Parse(Session_CS.group_id.ToString());

        }
       
        else
        {

            session_group = CDataConverter.ConvertToInt(DBNull.Value);
        }

        if (ddl_Groups.SelectedValue != "0" && ddl_Groups.SelectedValue != null)
        {
            selected_group = CDataConverter.ConvertToInt(ddl_Groups.SelectedValue);

        }
        else
        {

            selected_group = CDataConverter.ConvertToInt(DBNull.Value);
        }


        int maincat = 0; int subcat = 0;
        if (ddlMainCat.SelectedValue == "0")
        {
            maincat = CDataConverter.ConvertToInt(DBNull.Value);
        }
        else
        {
            maincat = CDataConverter.ConvertToInt(ddlMainCat.SelectedValue);
        }
        if (ddlSubCat.SelectedValue == "0")
        {
            subcat = CDataConverter.ConvertToInt(DBNull.Value);
        }
        else
        {
            subcat = CDataConverter.ConvertToInt(ddlSubCat.SelectedValue);
        }

        SqlParameter[] parms = new SqlParameter[19];
      

        if (ddl_Groups.SelectedValue != "0" && ddl_Groups.SelectedValue != null)
        {
            parms[0] = new SqlParameter("@selected_group_id", CDataConverter.ConvertToInt(ddl_Groups.SelectedValue));
        }
        else
        {
            parms[0] = new SqlParameter("@selected_group_id", CDataConverter.ConvertToInt(DBNull.Value));
        }

        if (CDataConverter.ConvertToInt(Session_CS.parent_id.ToString()) > 0 || CDataConverter.ConvertToInt(Session_CS.child_emp.ToString()) > 0)
        {
            parms[1] = new SqlParameter("@session_User_group_id", int.Parse(Session_CS.group_id.ToString()));
        }

        else
        {
            parms[1] = new SqlParameter("@session_User_group_id", CDataConverter.ConvertToInt(DBNull.Value));
        }

        parms[2] = new SqlParameter("@pmp", int.Parse(Session_CS.pmp_id.ToString()));
        if (ddlMainCat.SelectedValue == "0")
        {
            parms[3] = new SqlParameter("@main_cat", CDataConverter.ConvertToInt(DBNull.Value));
        }
        else
            parms[3] = new SqlParameter("@main_cat", CDataConverter.ConvertToInt(ddlMainCat.SelectedValue));
        if (ddlSubCat.SelectedValue == "0")
        {
            parms[4] = new SqlParameter("@sub_cat", CDataConverter.ConvertToInt(DBNull.Value));
        }
        else
            parms[4] = new SqlParameter("@sub_cat", CDataConverter.ConvertToInt(ddlSubCat.SelectedValue));
        parms[5] = new SqlParameter("@out_code", txt_out_code.Text);
        parms[6] = new SqlParameter("@code", Txtcode.Text);
        parms[7] = new SqlParameter("@subject", Inbox_name_text.Text);

        if (Smrt_Srch_org.SelectedValue == "")
        {
            parms[8] = new SqlParameter("@Org_id", CDataConverter.ConvertToInt(DBNull.Value));
        }
        else
        {
            parms[8] = new SqlParameter("@Org_id", CDataConverter.ConvertToInt(Smrt_Srch_org.SelectedValue));
        }
        if (Inbox_date_from.Text == "")
        {
            parms[9] = new SqlParameter("@inbox_date_from", "01/01/1900");
        }
        else
            parms[9] = new SqlParameter("@inbox_date_from", Inbox_date_from.Text);
        if (Inbox_date_to.Text == "")
        {
            parms[10] = new SqlParameter("@inbox_date_to",CDataConverter.ConvertDateTimeToFormatdmy(DateTime.MaxValue));
        }
        else
            parms[10] = new SqlParameter("@inbox_date_to", Inbox_date_to.Text);

        if (Outbox_date_from.Text == "")
        {
            parms[11] = new SqlParameter("@outbox_date_from", "01/01/1900");
        }
        else
            parms[11] = new SqlParameter("@outbox_date_from", Outbox_date_from.Text);
        if (Outbox_date_to.Text == "")
        {
            parms[12] = new SqlParameter("@outbox_date_to", CDataConverter.ConvertDateTimeToFormatdmy(DateTime.MaxValue));
        }
        else
            parms[12] = new SqlParameter("@outbox_date_to", Outbox_date_to.Text);

        parms[13] = new SqlParameter("@visa_desc", txt_word_visa.Text);
        parms[14] = new SqlParameter("@notes_word", txt_word_notes.Text);
        if (ddl_Related_Type.SelectedValue == "0")
        {
            parms[15] = new SqlParameter("@Related_type_par", CDataConverter.ConvertToInt(DBNull.Value));
        }
        else
            parms[15] = new SqlParameter("@Related_type_par", CDataConverter.ConvertToInt(ddl_Related_Type.SelectedValue));

        parms[16] = new SqlParameter("@visa_emp", CDataConverter.ConvertToInt(Smart_Emp_ID.SelectedValue));
        parms[17] = new SqlParameter("@found_id", Session_CS.foundation_id);


        if (Smart_Search_depts.SelectedValue == "")
        {
            parms[18] = new SqlParameter("@Dept_Dept_ID", CDataConverter.ConvertToInt(DBNull.Value));
        }
        else
        {
            parms[18] = new SqlParameter("@Dept_Dept_ID", CDataConverter.ConvertToInt(Smart_Search_depts.SelectedValue));
        }
     
         
        DataTable dt = new DataTable();
        dt = DatabaseFunctions.SelectDataByParam(parms, "inbox_search_par");


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
        int pmp = int.Parse(Session_CS.pmp_id.ToString());
        if (Session_CS.Project_id != null && CDataConverter.ConvertToInt(Session_CS.Project_id.ToString()) > 0)
        {
            gvMain.Columns[4].Visible = gvMain.Columns[0].Visible = false;
            if (Session_CS.UROL_UROL_ID != null && CDataConverter.ConvertToInt(Session_CS.UROL_UROL_ID) == 2)
            {
                gvMain.Columns[8].Visible = gvMain.Columns[9].Visible = false;
                gvMain.Columns[10].Visible = true;
            }
            else if (Session_CS.UROL_UROL_ID != null && CDataConverter.ConvertToInt(Session_CS.UROL_UROL_ID) == 3)
            {
                string sql1 = " SELECT Proj_id ,pmp_pmp_id " +
                        " FROM     Project     " +
                        " where Proj_id = '" + Session_CS.Project_id + "' and pmp_pmp_id = '" + Session_CS.pmp_id + "'";
                DataTable DT = General_Helping.GetDataTable(sql1);
                if (DT.Rows.Count <= 0)
                {
                    gvMain.Columns[8].Visible = gvMain.Columns[9].Visible = false;
                    gvMain.Columns[10].Visible = true;

                }
            }
        }
        else
            gvMain.Columns[1].Visible = gvMain.Columns[2].Visible = gvMain.Columns[5].Visible = gvMain.Columns[6].Visible = false;
        if (pmp == 70)
        {
            gvMain.Columns[8].Visible = gvMain.Columns[9].Visible = false;
            gvMain.Columns[10].Visible = true;
            //gvMain.Columns[9].Visible = true;
        }



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
        DataTable dt = General_Helping.GetDataTable("select * from parent_employee where pmp_id = " + pmp);
        if (e.CommandName == "EditItem")
        {
            string encrypted = Encryption.Encrypt(e.CommandArgument.ToString());
            //Session["encrypted"] = encrypted;
             DataTable dtissec = General_Helping.GetDataTable("select * from inbox where id = " + e.CommandArgument + "and pmp_pmp_id = " + pmp + "or group_id = " + CDataConverter.ConvertToInt(Session_CS.group_id.ToString()));
            if (dt.Rows.Count > 0)
            {
               
                if (dtissec.Rows.Count > 0)
                {
                    ///////// ده لو هو سكرتير وهو اللي دخل الوارد ده 
                    Response.Redirect("Project_Inbox.aspx?id=" + encrypted);
                }
                else
                    Response.Redirect("ViewProjectInbox.aspx?id=" + encrypted); ////ده لو هو سكرتير بس مش هو اللي دخل الوارد
            }

            else if (dtissec.Rows.Count>0 && dtissec.Rows[0]["pmp_pmp_id"].ToString() == Session_CS.pmp_id.ToString())
            {
                Response.Redirect("Project_Inbox.aspx?id=" + encrypted); // ده لو موظف عادي هو اللي دخل الوارد
            }
            else
                Response.Redirect("ViewProjectInbox.aspx?id=" + encrypted);///  لو مش سكرتير 
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
