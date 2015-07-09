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

public partial class UserControls_Outbox_Search : System.Web.UI.UserControl
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
        Smart_Search_depts.Show_OrgTree = true;
        if (!IsPostBack)
        {
          //  Fillddl();
            Fill_Groups();
        }

    }

    private void Fill_Groups()
    {
        //string sql = "select * from Employee_Groups where foundation_id=" + CDataConverter.ConvertToInt(Session_CS.foundation_id.ToString());
        //DataTable dt = General_Helping.GetDataTable(sql);

        DataTable dt = Employee_Groups_DB.SelectAll(CDataConverter.ConvertToInt(Session_CS.foundation_id.ToString()));
        ddl_Groups.DataSource = dt;
        ddl_Groups.DataValueField = "ID";
        ddl_Groups.DataTextField = "Name";
        ddl_Groups.DataBind();
        ddl_Groups.Items.Insert(0, new ListItem("اختر المجموعة......", "0"));

        if (Session_CS.group_id != null && Session_CS.group_id != 0)
        {
            ddl_Groups.SelectedValue = Session_CS.group_id.ToString();
            Fillddl();
        }

    }
    protected void Fillddl()
    {

        int group = CDataConverter.ConvertToInt(Session_CS.group_id.ToString());

        if (ddl_Groups.SelectedValue != "" && ddl_Groups.SelectedValue != null && ddl_Groups.SelectedValue != "0")
        {
            group = CDataConverter.ConvertToInt( ddl_Groups.SelectedValue);

        }


        sql = "select * from inbox_Main_Categories where group_id = " + group;
        ds = new DataSet();
        da = new SqlDataAdapter(sql, sql_Connection);
        da.Fill(ds, "Main");
        ddlMainCat.DataSource = ds.Tables[0];
        ddlMainCat.DataValueField = "id";
        ddlMainCat.DataTextField = "name";
        ddlMainCat.DataBind();
        ddlMainCat.Items.Insert(0, new ListItem("اختر التصنيف الرئيسي......", "0"));
    }

    protected void ddl_Groups_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (ddl_Groups.SelectedValue != "" && ddl_Groups.SelectedValue != null && ddl_Groups.SelectedValue != "0")
        {
            Fillddl();
        }
        else if (ddlMainCat.SelectedValue != "0" && ddlMainCat.SelectedValue != null)
        {
            ddlSubCat.Items.Clear();

        }
        if (ddl_Groups.SelectedValue != "" && ddl_Groups.SelectedValue != null && ddl_Groups.SelectedValue != "0" && ddlMainCat.SelectedValue == "0")
        {
            ddlSubCat.Items.Clear();
        }

        else
        {
            ddlMainCat.DataSource = null;
            ddlSubCat.DataSource = null;
            ddlMainCat.DataBind();
            ddlSubCat.DataBind();

            ddlSubCat.Items.Clear();

            ddlMainCat.Items.Clear();

        }
    }


    protected override void OnInit(EventArgs e)
    {
        int found_id = CDataConverter.ConvertToInt(Session_CS.foundation_id.ToString());
        //Smrt_Srch_org.sql_Connection = sql_Connection;
        ////Smrt_Srch_org.Query = "select Org_ID,Org_Desc from Organization where foundation_id = " + found_id;
        //string Query = "select Org_ID,Org_Desc from Organization where foundation_id = " + found_id;
        //Smrt_Srch_org.datatble = General_Helping.GetDataTable(Query);
        //Smrt_Srch_org.Value_Field = "Org_ID";
        //Smrt_Srch_org.Text_Field = "Org_Desc";
        //Smrt_Srch_org.DataBind();
        Smart_Search_depts.sql_Connection = sql_Connection;
        //Smart_Search_depts.Query = "select Dept_ID,Dept_name from Departments inner join dbo.Sectors on Departments.Sec_sec_id=Sectors.Sec_id where Sectors.foundation_id='" + Session_CS.foundation_id + "' ";
        string Query = "select Dept_ID,Dept_name , Dept_parent_id from Departments  where foundation_id='" + Session_CS.foundation_id + "' ";
        Smart_Search_depts.datatble = General_Helping.GetDataTable(Query);
        Smart_Search_depts.Value_Field = "Dept_ID";
        Smart_Search_depts.Text_Field = "Dept_name";
        Smart_Search_depts.DataBind();



        Smart_Emp_ID.sql_Connection = sql_Connection;

        Query = "SELECT EMPLOYEE.PMP_ID, EMPLOYEE.pmp_name FROM EMPLOYEE  where foundation_id='" + Session_CS.foundation_id + "' and EMPLOYEE.workstatus!=4";
       

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
        string t1 = "";
        string t2 = "";
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        //int group = int.Parse(Session_CS.group_id.ToString());
        int pmp = int.Parse(Session_CS.pmp_id.ToString());
        int session_group = 0;
        int selected_group = 0;

        if (CDataConverter.ConvertToInt(Session_CS.parent_id.ToString()) > 0 || CDataConverter.ConvertToInt(Session_CS.child_emp.ToString()) > 0)
        {
            session_group = int.Parse(Session_CS.group_id.ToString());

        }

        else
        {

            session_group = 0;
        }

        if (ddl_Groups.SelectedValue != "0" && ddl_Groups.SelectedValue != null)
        {
            selected_group = CDataConverter.ConvertToInt(ddl_Groups.SelectedValue);

        }
        else
        {

            selected_group = 0 ;
        }


        int maincat = 0; int subcat = 0;
        if (ddlMainCat.SelectedValue == "0")
        {
            maincat = 0 ;
        }
        else
        {
            maincat = CDataConverter.ConvertToInt(ddlMainCat.SelectedValue);
        }
        if (ddlSubCat.SelectedValue == "0")
        {
            subcat = 0 ;
        }
        else
        {
            subcat = CDataConverter.ConvertToInt(ddlSubCat.SelectedValue);
        }

        SqlParameter[] parms = new SqlParameter[16];

        if (ddl_Groups.SelectedValue != "0" && ddl_Groups.SelectedValue != null)
        {
            parms[0] = new SqlParameter("@selected_group_id", CDataConverter.ConvertToInt(ddl_Groups.SelectedValue));
        }
        else
        {
            parms[0] = new SqlParameter("@selected_group_id", 0);
        }

        if (CDataConverter.ConvertToInt(Session_CS.group_id.ToString()) > 0)
        {
            parms[1] = new SqlParameter("@session_User_group_id", int.Parse(Session_CS.group_id.ToString()));
        }

        else
        {
            parms[1] = new SqlParameter("@session_User_group_id", 0);
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
        //parms[4] = new SqlParameter("@out_code", txt_out_code.Text);
        parms[5] = new SqlParameter("@code", Txtcode.Text);
        parms[6] = new SqlParameter("@subject", Inbox_name_text.Text);

        if (/*Smrt_Srch_org.SelectedValue*/OrgID.Value == "")
        {
            parms[7] = new SqlParameter("@Org_id", CDataConverter.ConvertToInt(DBNull.Value));
        }
        else
        {
            parms[7] = new SqlParameter("@Org_id", CDataConverter.ConvertToInt(/*Smrt_Srch_org.SelectedValue*/OrgID.Value));
        }
        //if (Inbox_date_from.Text == "")
        //{
        //    parms[8] = new SqlParameter("@inbox_date_from", DateTime.ParseExact("01/01/1900", "dd/MM/yyyy", null).ToString("dd/MM/yyyy"));
        //}
        //else
        //    parms[8] = new SqlParameter("@inbox_date_from", Inbox_date_from.Text);
        //if (Inbox_date_to.Text == "")
        //{
        //    parms[9] = new SqlParameter("@inbox_date_to", DateTime.MaxValue.ToString("dd/MM/yyyy"));
        //}
        //else
        //    parms[9] = new SqlParameter("@inbox_date_to", Inbox_date_to.Text);

        if (Inbox_date_from.Text == "")
        {
            parms[8] = new SqlParameter("@outbox_date_from","01/01/1900");
        }
        else
            parms[8] = new SqlParameter("@outbox_date_from", Inbox_date_from.Text);
        if (Inbox_date_to.Text == "")
        {
            parms[9] = new SqlParameter("@outbox_date_to", "31/12/9999");
        }
        else
            parms[9] = new SqlParameter("@outbox_date_to", Inbox_date_to.Text);

        parms[10] = new SqlParameter("@visa_desc", txt_word_visa.Text);
        parms[11] = new SqlParameter("@notes_word", txt_word_notes.Text);
        if (ddl_Related_Type.SelectedValue == "0")
        {
            parms[12] = new SqlParameter("@Related_type_par", CDataConverter.ConvertToInt(DBNull.Value));
        }
        else
            parms[12] = new SqlParameter("@Related_type_par", CDataConverter.ConvertToInt(ddl_Related_Type.SelectedValue));

        parms[13] = new SqlParameter("@visa_emp", CDataConverter.ConvertToInt(Smart_Emp_ID.SelectedValue));
        parms[14] = new SqlParameter("@found_id", Session_CS.foundation_id);

        if (Smart_Search_depts.SelectedValue == "")
        {
            parms[15] = new SqlParameter("@Dept_Dept_ID", CDataConverter.ConvertToInt(DBNull.Value));
        }
        else
        {
            parms[15] = new SqlParameter("@Dept_Dept_ID", CDataConverter.ConvertToInt(Smart_Search_depts.SelectedValue));
        }

        DataTable dt = new DataTable();
        dt = DatabaseFunctions.SelectDataByParam(parms, "Outbox_search_par");


        if (dt.Rows.Count == 0)
        {
            gvMain.EmptyDataText = ".....عفوا لا يوجد بيانات ......";
        }
        else
        {
            gvMain.DataSource = dt;
        }

        gvMain.DataBind();
        //SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        //sql = "set dateformat dmy ";
        //sql += " SELECT  distinct From_Outbox_View.ID, Proj_id, Name, Code, Date,Org_Out_Box_Code,Group_id,pmp_pmp_id, incombination, Type,"
        //+ "From_Outbox_View.Emp_ID, Related_Type,CONVERT(datetime, From_Outbox_View.valid_date), Related_Id, Paper_No, Paper_Attached, Org_Dept_Name, outcombination, Org_Desc," +
        // " Org_Id,Subject,Org_Out_Box_DT,valid_date,out_valid_date ,From_Outbox_View.notes,convert(nvarchar(MAX),Outbox_Visa.Visa_Desc) " +
        //" FROM From_Outbox_View LEFT OUTER JOIN  Outbox_Track_Emp ON From_Outbox_View.ID = Outbox_Track_Emp.Outbox_id  LEFT OUTER JOIN Outbox_Visa on From_Outbox_View.ID= Outbox_Visa.Outbox_ID  LEFT OUTER JOIN Outbox_Visa_Emp on Outbox_Visa.Visa_Id= Outbox_Visa_Emp.Visa_Id  where 1=1 ";
        //if (CDataConverter.ConvertToInt(Session_CS.parent_id.ToString()) > 0 || CDataConverter.ConvertToInt(Session_CS.child_emp.ToString()) > 0)
        //{
        //    sql += " AND (Group_id= " + group + " or Outbox_Track_Emp.emp_id=" + pmp + ")";
        //}
        //else
        //    sql += " AND Outbox_Track_Emp.emp_id= " + pmp;

        //if (ddlSubCat.SelectedValue != "0" && ddlMainCat.SelectedValue != "0")
        //{
        //    sql += " AND  From_Outbox_View.ID in (select outbox_id from outbox_cat where cat_id = " + ddlMainCat.SelectedValue + " and Type=1) ";
        //    sql += " AND  From_Outbox_View.ID in (select outbox_id from outbox_cat where cat_id = " + ddlSubCat.SelectedValue + " and Type=2) ";
          
        //}
        //else if (ddlMainCat.SelectedValue != "0")
        //{
        //    sql += " AND  From_Outbox_View.ID in (select outbox_id from outbox_cat where cat_id = " + ddlMainCat.SelectedValue + " and Type=1) ";
        //}
        ////int dept = int.Parse(Session_CS.dept_id.ToString());

        ////if (txt_out_code.Text != "")
        ////{
        ////    sql += " AND Org_Out_Box_Code like" + "'%" + txt_out_code.Text + "%'";
        ////}
        //if (Txtcode.Text != "")
        //{
        //    sql += " AND Code like" + "'%" + Txtcode.Text + "%'";
        //}
        //if (Inbox_name_text.Text != "")
        //{
        //    sql += " AND Subject like" + "'%" + Inbox_name_text.Text + "%'";
        //}



        //if (txt_word_notes.Text != "")
        //{
        //    sql += " AND notes like" + "'%" + txt_word_notes.Text + "%'";
        //}

        //if (txt_word_visa.Text != "")
        //{
        //    sql += " AND Visa_Desc like" + "'%" + txt_word_visa.Text + "%'";
        //}

        //if (Smart_Emp_ID.SelectedValue != "")
        //{
        //    sql += " AND Outbox_Visa_Emp.Emp_ID = " + Smart_Emp_ID.SelectedValue;
        //}


        //if (ddl_Related_Type.SelectedValue != "" && ddl_Related_Type.SelectedValue != "0")
        //{
        //    sql += " AND From_Outbox_View.Related_Type = " + ddl_Related_Type.SelectedValue;
        //}





        //if (CDataConverter.ConvertToInt(Session_CS.Project_id.ToString()) > 0)
        //{
        //    sql += " AND Proj_id = " + int.Parse(Session_CS.Project_id.ToString());
        //}
        //else
        //    sql += " AND Proj_id = 0  " ;

        //if (Smrt_Srch_org.SelectedValue != "")
        //{
        //    sql += " AND From_Outbox_View.Org_Id = " + Smrt_Srch_org.SelectedValue;
        //    //sql += " AND From_Outbox_View.Org_Desc like " + "'%" + Smrt_Srch_org.Text_Field + "%'";
        //}
        //if (Smart_Search_depts.SelectedValue != "")
        //{
        //    sql += " AND From_Outbox_View.Org_Id = " + Smart_Search_depts.SelectedValue + " and type = 1";
        //}
        //if (string.IsNullOrEmpty(Inbox_date_from.Text) && string.IsNullOrEmpty(Inbox_date_to.Text))
        //{
        //    t1 = DateTime.ParseExact("01/01/1900", "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
        //    t2 = DateTime.MaxValue.ToString("dd/MM/yyyy");
        //    //sql += " AND convert(datetime,valid_date) > = '" + t1.ToString() + "'";
        //    //sql += " AND convert(datetime,valid_date) < = '" + t2.ToString() + "'";
        //}
        //else if (string.IsNullOrEmpty(Inbox_date_from.Text))
        //{
        //    if (VB_Classes.Dates.Dates_Operation.date_validate(Inbox_date_to.Text.Trim()) != "")
        //    {
        //        t1 = DateTime.ParseExact("01/01/1900", "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
        //        // t2 = DateTime.ParseExact(Inbox_date_to.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
        //        t2 = VB_Classes.Dates.Dates_Operation.date_validate(Inbox_date_to.Text.Trim());
        //        sql += " AND convert(datetime,valid_date) < = '" + t2.ToString() + "'";
        //    }
        //    else
        //    {
        //        ShowAlertMessage("!!!!!ادخل التاريخ بطريقة صحيحة !!!!");
        //        return;
        //    }

        //}
        //else if (string.IsNullOrEmpty(Inbox_date_to.Text))
        //{
        //    if (VB_Classes.Dates.Dates_Operation.date_validate(Inbox_date_from.Text.Trim()) != "")
        //    {
        //        //t1 = DateTime.ParseExact(Inbox_date_from.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
        //        t2 = DateTime.MaxValue.ToString("dd/MM/yyyy");
        //        t1 = VB_Classes.Dates.Dates_Operation.date_validate(Inbox_date_from.Text.Trim());
        //        sql += " AND convert(datetime,valid_date) > = '" + t1.ToString() + "'";
        //    }
        //    else
        //    {
        //        ShowAlertMessage("!!!!!ادخل التاريخ بطريقة صحيحة !!!!");
        //        return;
        //    }
        //}
        //else
        //{
        //    if (VB_Classes.Dates.Dates_Operation.date_validate(Inbox_date_to.Text.Trim()) != "" && VB_Classes.Dates.Dates_Operation.date_validate(Inbox_date_from.Text.Trim()) != "")
        //    {
        //        //t1 = DateTime.ParseExact(Inbox_date_from.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
        //        //t2 = DateTime.ParseExact(Inbox_date_to.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
        //        t2 = VB_Classes.Dates.Dates_Operation.date_validate(Inbox_date_to.Text.Trim());
        //        t1 = VB_Classes.Dates.Dates_Operation.date_validate(Inbox_date_from.Text.Trim());
        //        sql += " AND convert(datetime,valid_date) > = '" + t1.ToString() + "'";
        //        sql += " AND convert(datetime,valid_date) < = '" + t2.ToString() + "'";
        //    }
        //    else
        //    {
        //        ShowAlertMessage("!!!!!ادخل التاريخ بطريقة صحيحة !!!!");
        //        return;
        //    }

        //}
        //DateTime date3 = DateTime.ParseExact(t1, "dd/MM/yyyy", null);
        //DateTime date4 = DateTime.ParseExact(t2, "dd/MM/yyyy", null);
        //if (date4.Subtract(date3).Days < 0)
        //{
        //    ShowAlertMessage("!!!!!التاريخ الأول يجب ان يكون قبل التاريخ الثاني !!!!");
        //    return;
        //}
        ////////////////////////////////////////////////////////////// finished check on Date Field/////////////////////////////////////


        //sql += " order by convert(datetime,valid_date)  desc ,  Code desc";
        //conn.Open();
        //SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        //DataTable dt = new DataTable();
        //da.Fill(dt);
        //if (dt.Rows.Count == 0)
        //{
        //    gvMain.EmptyDataText = ".....عفوا لا يوجد بيانات ......";
        //}
        //else
        //{
        //    gvMain.DataSource = dt;
        //}
        //gvMain.DataBind();
        //conn.Close();
    }

    protected void SaveButton_Click(object sender, EventArgs e)
    {
        SearchRecord();
        if (Session_CS.Project_id != null && CDataConverter.ConvertToInt(Session_CS.Project_id.ToString()) > 0)
        {
            if (Session_CS.UROL_UROL_ID != null && CDataConverter.ConvertToInt(Session_CS.UROL_UROL_ID) == 2)
            {
                gvMain.Columns[4].Visible = gvMain.Columns[5].Visible = false;
                gvMain.Columns[6].Visible = true;

            }

            else if (Session_CS.UROL_UROL_ID != null && CDataConverter.ConvertToInt(Session_CS.UROL_UROL_ID) == 3)
            {

                string sql1 = " SELECT Proj_id ,pmp_pmp_id " +
                        " FROM     Project     " +
                        " where Proj_id = '" + Session_CS.Project_id + "' and pmp_pmp_id = '" + Session_CS.pmp_id + "'";
                DataTable DT = General_Helping.GetDataTable(sql1);
                if (DT.Rows.Count <= 0)
                {
                    gvMain.Columns[4].Visible = gvMain.Columns[5].Visible = false;
                    gvMain.Columns[6].Visible = true;

                }
            }
        }

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
            if (dt.Rows.Count > 0)
            {
                DataTable dtissec = General_Helping.GetDataTable("select * from Outbox where id = " + e.CommandArgument + "and pmp_pmp_id = " + pmp + "or group_id = " + CDataConverter.ConvertToInt(Session_CS.group_id.ToString()));
                if (dtissec.Rows.Count > 0)
                {
                    ///////// ده لو هو سكرتير وهو اللي دخل الوارد ده 
                    Response.Redirect("Project_Outbox.aspx?id=" + encrypted);
                }
                else
                    Response.Redirect("ViewProjectOutbox.aspx?id=" + encrypted); ////ده لو هو سكرتير بس مش هو اللي دخل الوارد
            }
            else

                Response.Redirect("ViewProjectOutbox.aspx?id=" + encrypted);


            Response.Redirect("Project_Outbox.aspx?id=" + encrypted);
        }
        if (e.CommandName == "RemoveItem")
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            conn.Open();

            sql += "delete from Outbox where ID= " + e.CommandArgument;
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

    }
    protected void ddlMainCat_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlMainCat.SelectedValue != "" && ddlMainCat.SelectedValue != null && ddlMainCat.SelectedValue != "0")
        {
            FillSubCat();
        }
        else
        {

            ddlSubCat.DataSource = null;

            ddlSubCat.DataBind();
            ddlSubCat.Items.Clear();

        }
    }
    protected void FillSubCat()
    {
        string sql = "";
        if (ddlMainCat.SelectedValue != "")
        {
            sql = "select * from inbox_Sub_Categories where  main_id= " + ddlMainCat.SelectedValue;

        }
        else
            sql = "select * from inbox_Sub_Categories where  main_id=0";
        //DataTable dt = General_Helping.GetDataTable(sql);
        //Obj_General_Helping.SmartBindDDL(ddlSubCat, dt, "id", "name", "....اختر التصنيف الفرعي ....");



      //  sql = "select * from inbox_Main_Categories where group_id = " + group;
        ds = new DataSet();
        da = new SqlDataAdapter(sql, sql_Connection);
        da.Fill(ds, "sub");
        ddlSubCat.DataSource = ds.Tables[0];
        ddlSubCat.DataValueField = "id";
        ddlSubCat.DataTextField = "name";
        ddlSubCat.DataBind();
        ddlSubCat.Items.Insert(0, new ListItem("اختر التصنيف الفرعي......", "0"));


    }
}
