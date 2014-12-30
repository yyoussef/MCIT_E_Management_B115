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
using System.Web.Mail;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;

public partial class WebForms2_Search_ALL_Documents : System.Web.UI.Page
{
    //Session_CS Session_CS = new Session_CS();
    string sql, sql1;
    SqlConnection conn;
    SqlDataAdapter da;
    DataSet ds, ds_total;
    SqlCommand cmd;
    bool f = true;
    int flag;
    private string sql_Connection = Database.ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected override void OnInit(EventArgs e)
    {

        Smrt_Srch_org.sql_Connection = sql_Connection;
      //  Smrt_Srch_org.Query = "select Org_ID,Org_Desc from Organization";
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
        string t3 = "";
        string t4 = "";
        string t5 = "";
        string t6 = "";
        int group = int.Parse(Session_CS.group_id.ToString());
        int pmp = int.Parse(Session_CS.pmp_id.ToString());
        //div_grid_Main.Style.Add("Display", "none");
        //////////////////////////////////////////////////////////////////////////////// INBOX Condition//////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        if (hidden_in_out.Value == "1")
        {
            flag = 1;
            hidden1.Value = "1";

            //string t1 = "";
            //string t2 = "";

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            sql = "set dateformat dmy ";
            sql += " SELECT ID, Proj_id, Name, Code, Date,Org_Out_Box_Code,Group_id,pmp_pmp_id, incombination, Type, Emp_ID, Related_Type, Related_Id, Paper_No, Paper_Attached, Org_Dept_Name, outcombination, Org_Desc,";
            sql += " Org_Id,Subject,Org_Out_Box_DT,valid_date,out_valid_date";
            sql += " FROM From_Inbox_View where 1=1 ";
            if (Check_inbox.Checked == true)
            {
                sql += " AND Group_id = 2";
            }
            else
            {
                sql += "AND Group_id= " + group;
            }

            //int dept = int.Parse(Session_CS.dept_id.ToString());

            if (txt_out_code.Text != "")
            {
                sql += " AND Org_Out_Box_Code like" + "'%" + txt_out_code.Text + "%'";
            }
            if (Txtcode.Text != "")
            {
                sql += " AND Code like" + "'%" + Txtcode.Text + "%'";
            }
            if (Inbox_name_text.Text != "")
            {
                sql += " AND Subject like" + "'%" + Inbox_name_text.Text + "%'";
            }

            if (Smrt_Srch_org.SelectedText != "")
            {
                if (Smrt_Srch_org.SelectedValue != "")
                {
                    sql += " AND From_Inbox_View.Org_Id = " + Smrt_Srch_org.SelectedValue;
                }
                else
                {
                    sql += " AND From_Inbox_View.Org_Desc like" + "'%" + Smrt_Srch_org.SelectedText + "%'";
                }
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
            if (Session_CS.Project_id != null)
            {
                sql += " AND Proj_id = " + int.Parse(Session_CS.Project_id.ToString());
            }
            sql += " order by convert(datetime,valid_date) desc , Code desc";


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
            div_grid_Main.Style.Add("Display", "block");
            div_inbox_word.Style.Add("Display", "block");
            conn.Close();
        }
        //////////////////////////////////////////////////////////////////////////////// OUTBOX Condition//////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        else if (hidden_in_out.Value == "2")
        {
            flag = 2;
            hidden1.Value = "2";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            //int group = int.Parse(Session_CS.group_id.ToString());
            //int pmp = int.Parse(Session_CS.pmp_id.ToString());
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
            if (txt_Code_outbox.Text != "")
            {
                sql += " AND Code like" + "'%" + txt_Code_outbox.Text + "%'";
            }
            if (txt_subject_outbox.Text != "")
            {
                sql += " AND Subject like" + "'%" + txt_subject_outbox.Text + "%'";
            }
            if (CDataConverter.ConvertToInt(Session_CS.Project_id) > 0)
            {
                sql += " AND Proj_id = " + int.Parse(Session_CS.Project_id.ToString());
            }
            //if (Smrt_Srch_org.SelectedValue != "")
            //{
            //    sql += " AND From_Outbox_View.Org_Id = " + Smrt_Srch_org.SelectedValue;
            //    //sql += " AND From_Outbox_View.Org_Desc like " + "'%" + Smrt_Srch_org.Text_Field + "%'";
            //}
            if (string.IsNullOrEmpty(outbox_date_from_out.Text) && string.IsNullOrEmpty(Outbox_date_to_out.Text))
            {
                t1 = DateTime.ParseExact("01/01/1900", "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
                t2 = DateTime.MaxValue.ToString("dd/MM/yyyy");
                //sql += " AND convert(datetime,valid_date) > = '" + t1.ToString() + "'";
                //sql += " AND convert(datetime,valid_date) < = '" + t2.ToString() + "'";
            }
            else if (string.IsNullOrEmpty(outbox_date_from_out.Text))
            {
                t1 = DateTime.ParseExact("01/01/1900", "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
                t2 = DateTime.ParseExact(Outbox_date_to_out.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");

                sql += " AND convert(datetime,valid_date) < = '" + t2.ToString() + "'";
            }
            else if (string.IsNullOrEmpty(Outbox_date_to_out.Text))
            {
                t1 = DateTime.ParseExact(outbox_date_from_out.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
                t2 = DateTime.MaxValue.ToString("dd/MM/yyyy");

                sql += " AND convert(datetime,valid_date) > = '" + t1.ToString() + "'";
            }
            else
            {
                t1 = DateTime.ParseExact(outbox_date_from_out.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");

                t2 = DateTime.ParseExact(Outbox_date_to_out.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");

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
                GridViewoutbox.EmptyDataText = ".....عفوا لا يوجد بيانات ......";
            }
            else
            {
                GridViewoutbox.DataSource = dt;
            }
            GridViewoutbox.DataBind();
            div_outbox_word.Style.Add("Display", "block");
            div_grid_outbox.Style.Add("Display", "block");
            conn.Close();
        }
        //////////////////////////////////////////////////////////////////////////////// MEETINGS Condition//////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        else if (hidden_in_out.Value == "4")
        {
            get_meetings();
            div_meet_word.Style.Add("Display", "block");
            div_grid_meetings.Style.Add("Display", "block");
        }
        //////////////////////////////////////////////////////////////////////////////// PRESENTATION Condition//////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        else if (hidden_in_out.Value == "5")
        {
            get_presentations();
            div_pres_word.Style.Add("Display", "block");
            div_grid_Presentations.Style.Add("Display", "block");

        }
        //////////////////////////////////////////////////////////////////////////////// EVENTS Condition//////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        else if (hidden_in_out.Value == "6")
        {

            get_events();
            div_event_word.Style.Add("Display", "block");
            div_grid_events.Style.Add("Display", "block");
        }
        else if (hidden_in_out.Value == "7")
        {
            get_generaldocuments();
            div_general_documents_word.Style.Add("Display", "block");
            div_grid_general_doc.Style.Add("Display", "block");
        }
        else
        {
            ////////////////////////////////////////////////////////// inbox

            get_inbox();
            div_inbox_word.Style.Add("Display", "block");
            div_grid_Main.Style.Add("Display", "block");

            ///////////////////////////////////////////////////////////// outbox
            get_outbox();
            div_outbox_word.Style.Add("Display", "block");
            div_grid_outbox.Style.Add("Display", "block");
            /////////////////////////////////////////////////////////////////////// meetings

            get_meetings();
            div_meet_word.Style.Add("Display", "block");
            div_grid_meetings.Style.Add("Display", "block");

            ////////////////////////////////////////////////////////////////////////////// presentations
            get_presentations();
            div_pres_word.Style.Add("Display", "block");
            div_grid_Presentations.Style.Add("Display", "block");


            ////////////////////////////////////////////////////////////////////////////// events

            get_events();
            div_event_word.Style.Add("Display", "block");
            div_grid_events.Style.Add("Display", "block");


            /////////////////////////////////////////////////////////// general documents
            get_generaldocuments();
            //con.Close();
            div_general_documents_word.Style.Add("Display", "block");
            div_grid_general_doc.Style.Add("Display", "block");



        }
    }
    protected void get_generaldocuments()
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        sql = "SELECT [File_ID],[File_Type],[File_name],[File_ext],[File_ext] as File_Type_Resolved FROM";

        sql += " [dbo].[Departments_Documents]";

        sql += " WHERE (File_Sytem_Name not like '' or File_data is not null ) and ";
        sql += " [proj_proj_id] =" + CDataConverter.ConvertToInt(Session_CS.Project_id.ToString());
        // sql += " and [Dept_ID] =" + CDataConverter.ConvertToInt(Session_CS.dept_id.ToString());
        if (ddl_File_Type.SelectedValue != "0")
            sql += " and [File_Type] = " + CDataConverter.ConvertToInt(ddl_File_Type.SelectedValue);
        if (txt_file_name.Text != "")
            sql += " and [File_name] like '%" + txt_file_name.Text + "%'  ";
        if (txt_file_discribtion.Text != "")
            sql += " and [File_Desc] like '%" + txt_file_discribtion.Text + "%'";
        DataTable DT = new DataTable();

        DT = General_Helping.GetDataTable(sql);

        foreach (DataRow dr in DT.Rows)
        {
            if (dr["File_Type"].ToString() == "1")
                dr["File_Type_Resolved"] = "Word";
            else if (dr["File_Type"].ToString() == "2")
                dr["File_Type_Resolved"] = "Excel";
            else if (dr["File_Type"].ToString() == "3")
                dr["File_Type_Resolved"] = "PDF";
            else if (dr["File_Type"].ToString() == "4")
                dr["File_Type_Resolved"] = "Image";
            else if (dr["File_Type"].ToString() == "5")
                dr["File_Type_Resolved"] = "Power Point";
            else if (dr["File_Type"].ToString() == "6")
                dr["File_Type_Resolved"] = "Microsoft Project";
            else if (dr["File_Type"].ToString() == "7")
                dr["File_Type_Resolved"] = "Video";

        }
        GridView_general_doc.DataSource = DT;
        GridView_general_doc.DataBind();
    }
    protected void get_events()
    {
        string strMaxDT = "";
        string strMinDT = "";

        strMaxDT = Event_date_to.Text;
        strMinDT = Event_date_from.Text;

        SqlDataAdapter sqladptr3 = new SqlDataAdapter();
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        SqlCommand obj3 = new SqlCommand("Get_Event_Search", con);
        obj3.CommandType = CommandType.StoredProcedure;
        obj3.Parameters.Add(new SqlParameter("@ProjID", Session_CS.Project_id.ToString()));
        obj3.Parameters.Add(new SqlParameter("@Dept_ID", Session_CS.dept_id.ToString()));
        obj3.Parameters.Add(new SqlParameter("@Event_name", "%" + Event_name.Text + "%"));
        obj3.Parameters.Add(new SqlParameter("@Event_location", "%" + Event_location.Text + "%"));
        obj3.Parameters.Add(new SqlParameter("@Event_date_from", strMinDT));
        obj3.Parameters.Add(new SqlParameter("@Event_date_to", strMaxDT));

        //con.Open();
        sqladptr3.SelectCommand = obj3;
        DataTable DT5 = new DataTable();
        sqladptr3.Fill(DT5);
        GridView_events.DataSource = DT5;
        GridView_events.DataBind();
    }
    protected void get_presentations()
    {
        string strMaxDT = "";
        string strMinDT = "";

        strMaxDT = Presentation_date_to.Text;
        strMinDT = Presentation_date_from.Text;

        SqlDataAdapter sqladptr2 = new SqlDataAdapter();
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        SqlCommand obj2 = new SqlCommand("Get_Presentation_Search", con);
        obj2.CommandType = CommandType.StoredProcedure;
        obj2.Parameters.Add(new SqlParameter("@ProjID", Session_CS.Project_id.ToString()));
        obj2.Parameters.Add(new SqlParameter("@Dept_ID", Session_CS.dept_id.ToString()));
        obj2.Parameters.Add(new SqlParameter("@Presentation_name", "%" + Presentation_name.Text + "%"));
        obj2.Parameters.Add(new SqlParameter("@Presentation_location", "%" + Presentation_location.Text + "%"));
        obj2.Parameters.Add(new SqlParameter("@Presentation_date_from", strMinDT));
        obj2.Parameters.Add(new SqlParameter("@Presentation_date_to", strMaxDT));

        //con.Open();
        sqladptr2.SelectCommand = obj2;
        DataTable DT2 = new DataTable();
        sqladptr2.Fill(DT2);
        GridView_presentations.DataSource = DT2;
        GridView_presentations.DataBind();
    }
    protected void get_meetings()
    {
        string strMaxDT = "";
        string strMinDT = "";

        strMaxDT = Meeting_date_to.Text;
        strMinDT = Meeting_date_from.Text;

        SqlDataAdapter sqladptr = new SqlDataAdapter();
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        if (Meeting_Side.Text.Trim() == "")
        {
            SqlCommand obj = new SqlCommand("Get_Meeting_Search", con);
            obj.CommandType = CommandType.StoredProcedure;
            obj.Parameters.Add(new SqlParameter("@ProjID", Session_CS.Project_id.ToString()));
            obj.Parameters.Add(new SqlParameter("@Meeting_name", "%" + Meeting_name.Text + "%"));
            obj.Parameters.Add(new SqlParameter("@Dept_ID", Session_CS.dept_id.ToString()));
            obj.Parameters.Add(new SqlParameter("@Meeting_location", "%" + Meeting_location.Text + "%"));
            obj.Parameters.Add(new SqlParameter("@Meeting_date_from", strMinDT));
            obj.Parameters.Add(new SqlParameter("@Meeting_date_to", strMaxDT));
            con.Open();
            sqladptr.SelectCommand = obj;
            DataTable DT = new DataTable();
            sqladptr.Fill(DT);
            GridView_Meetings.DataSource = DT;
            GridView_Meetings.DataBind();

            //con.Close();
        }
        else
        {
            SqlCommand obj = new SqlCommand("Get_Meeting_Search2", con);
            obj.CommandType = CommandType.StoredProcedure;
            obj.Parameters.Add(new SqlParameter("@Meeting_Side", Meeting_Side.Text));
            obj.Parameters.Add(new SqlParameter("@ProjID", Session_CS.Project_id.ToString()));
            obj.Parameters.Add(new SqlParameter("@Dept_ID", Session_CS.dept_id.ToString()));
            obj.Parameters.Add(new SqlParameter("@Meeting_name", "%" + Meeting_name.Text + "%"));
            obj.Parameters.Add(new SqlParameter("@Meeting_location", "%" + Meeting_location.Text + "%"));
            obj.Parameters.Add(new SqlParameter("@Meeting_date_from", strMinDT));
            obj.Parameters.Add(new SqlParameter("@Meeting_date_to", strMaxDT));
            con.Open();
            sqladptr.SelectCommand = obj;
            DataTable DT = new DataTable();
            sqladptr.Fill(DT);
            GridView_Meetings.DataSource = DT;
            GridView_Meetings.DataBind();

            //con.Close();
        }
    }
    protected void get_outbox()
    {
        int group = int.Parse(Session_CS.group_id.ToString());
        sql1 = "set dateformat dmy ";
        sql1 += " SELECT ID, Proj_id, Name, Code, Date,Org_Out_Box_Code,Group_id,pmp_pmp_id, incombination, Type, Emp_ID, Related_Type, Related_Id, Paper_No, Paper_Attached, Org_Dept_Name, outcombination, Org_Desc,";
        sql1 += " Org_Id,Subject,Org_Out_Box_DT,valid_date,out_valid_date";
        sql1 += " FROM From_Outbox_View where 1=1 AND Group_id= " + group;

        if (Part.Text != "")
        {
            sql1 += " AND Code like" + "'%" + Part.Text + "%'";
        }
        if (Session_CS.Project_id != null)
        {
            sql1 += " AND Proj_id = " + int.Parse(Session_CS.Project_id.ToString());
        }

        DataTable dt1 = General_Helping.GetDataTable(sql1);
        if (dt1.Rows.Count == 0)
        {
            GridViewoutbox.EmptyDataText = ".....عفوا لا يوجد بيانات ......";
        }
        else
        {
            GridViewoutbox.DataSource = dt1;
        }
        GridViewoutbox.DataBind();
    }
    protected void get_inbox()
    {
        int group = int.Parse(Session_CS.group_id.ToString());
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        sql = "set dateformat dmy ";
        sql += " SELECT ID, Proj_id, Name, Code, Date,Org_Out_Box_Code,Group_id,pmp_pmp_id, incombination, Type, Emp_ID, Related_Type, Related_Id, Paper_No, Paper_Attached, Org_Dept_Name, outcombination, Org_Desc,";
        sql += " Org_Id,Subject,Org_Out_Box_DT,valid_date,out_valid_date";
        sql += " FROM From_Inbox_View where 1=1 AND Group_id= " + group;
        //int dept = int.Parse(Session_CS.dept_id.ToString());

        if (Part.Text != "")
        {
            sql += " AND Subject like" + "'%" + Part.Text + "%'";
        }
        if (Session_CS.Project_id != null)
        {
            sql += " AND Proj_id = " + int.Parse(Session_CS.Project_id.ToString());
        }

        DataTable dt = General_Helping.GetDataTable(sql);
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
    }


    protected void gvMain_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void gvMain_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string encrypted = Encryption.Encrypt(e.CommandArgument.ToString());
        if (e.CommandName == "EditItem")
        {

            Response.Redirect("Project_Inbox.aspx?id=" + encrypted);
        }
        if (e.CommandName == "RemoveItem")
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            conn.Open();

            sql += "delete from Inbox where ID= " + e.CommandArgument;
            cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();

            gvMain.DataBind();

            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم الحذف بنجاح')</script>");
            SearchRecord();
        }

    }
    protected void GridViewoutbox_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string encrypted = Encryption.Encrypt(e.CommandArgument.ToString());
        if (e.CommandName == "EditItem")
        {
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
    protected void GridView_events_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView_events.PageIndex = e.NewPageIndex;
        SearchRecord();
    }
    protected void GridViewoutbox_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewoutbox.PageIndex = e.NewPageIndex;
        SearchRecord();
    }
    protected void GridView_Meetings_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView_Meetings.PageIndex = e.NewPageIndex;
        SearchRecord();
    }
    protected void GridView_presentations_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView_presentations.PageIndex = e.NewPageIndex;
        SearchRecord();
    }
    protected void GridView_general_doc_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView_general_doc.PageIndex = e.NewPageIndex;
        SearchRecord();
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
    }

    protected void Button1_Click(object sender, EventArgs e)
    {


    }

    public void all_none()
    {
        div_grid_Main.Style.Add("Display", "none");
        div_grid_events.Style.Add("Display", "none");
        div_grid_meetings.Style.Add("Display", "none");
        div_grid_outbox.Style.Add("Display", "none");
        div_grid_general_doc.Style.Add("Display", "none");
        div_grid_Presentations.Style.Add("Display", "none");
        div_inbox_word.Style.Add("Display", "none");
        div_outbox_word.Style.Add("Display", "none");
        div_meet_word.Style.Add("Display", "none");
        div_pres_word.Style.Add("Display", "none");
        div_event_word.Style.Add("Display", "none");
        div_general_documents_word.Style.Add("Display", "none");
    }
    protected void Drop_choose_SelectedIndexChanged(object sender, EventArgs e)
    {
        ////////////////////////////////////////////////////////////// Inbox Condition///////////////////////////////////
        if (Drop_choose.SelectedValue == "1")
        {


            all_none();



            div_save.Style.Add("Display", "Block");
            table_inbox.Style.Add("Display", "Block");
            table_presentations.Style.Add("Display", "none");
            table_outbox.Style.Add("Display", "none");
            table_Meetings.Style.Add("Display", "none");
            table_Events.Style.Add("Display", "none");
            table_General_Documents.Style.Add("Display", "none");
            table_All.Style.Add("Display", "none");
            hidden_in_out.Value = "1";


        }
        ///////////////////////////////////////////////////// Outbox Condition//////////////////////////////////////
        else if (Drop_choose.SelectedValue == "2")
        {

            all_none();

            table_All.Style.Add("Display", "none");
            table_inbox.Style.Add("Display", "none");
            table_outbox.Style.Add("Display", "block");
            table_Meetings.Style.Add("Display", "none");
            table_presentations.Style.Add("Display", "none");
            table_Events.Style.Add("Display", "none");
            div_save.Style.Add("Display", "block");
            table_General_Documents.Style.Add("Display", "none");
            hidden_in_out.Value = "2";
        }
        else if (Drop_choose.SelectedValue == "7")
        {

            all_none();

            table_All.Style.Add("Display", "none");
            table_inbox.Style.Add("Display", "none");
            table_outbox.Style.Add("Display", "none");
            table_Meetings.Style.Add("Display", "none");
            table_presentations.Style.Add("Display", "none");
            table_Events.Style.Add("Display", "none");
            div_save.Style.Add("Display", "block");
            table_General_Documents.Style.Add("Display", "block");
            hidden_in_out.Value = "7";
        }

            //////////////////////////////////////////////////// ALL Documents Condition/////////////////////////////////
        else if (Drop_choose.SelectedValue == "3")
        {
            div_grid_outbox.Style.Add("Display", "none");
            div_grid_Main.Style.Add("Display", "none");
            div_grid_Presentations.Style.Add("Display", "none");
            div_grid_meetings.Style.Add("Display", "none");
            div_grid_events.Style.Add("Display", "none");
            div_grid_general_doc.Style.Add("Display", "none");

            table_All.Style.Add("Display", "block");
            table_inbox.Style.Add("Display", "none");
            table_outbox.Style.Add("Display", "none");
            table_presentations.Style.Add("Display", "none");
            table_General_Documents.Style.Add("Display", "none");

            div_inbox_word.Style.Add("Display", "none");
            div_outbox_word.Style.Add("Display", "none");
            div_meet_word.Style.Add("Display", "none");
            div_pres_word.Style.Add("Display", "none");
            div_event_word.Style.Add("Display", "none");
            div_general_documents_word.Style.Add("Display", "none");

            table_Meetings.Style.Add("Display", "none");
            table_Events.Style.Add("Display", "none");
            div_save.Style.Add("Display", "block");
            hidden_in_out.Value = "3";
        }
        ///////////////////////////////////////////////////// Meetings Condition///////////////////////////////////////////////////////////
        else if (Drop_choose.SelectedValue == "4")
        {
            all_none();


            table_All.Style.Add("Display", "none");
            table_inbox.Style.Add("Display", "none");
            table_outbox.Style.Add("Display", "none");
            table_Meetings.Style.Add("Display", "block");
            table_presentations.Style.Add("Display", "none");
            table_Events.Style.Add("Display", "none");
            div_save.Style.Add("Display", "block");
            table_General_Documents.Style.Add("Display", "none");
            hidden_in_out.Value = "4";
        }
        /////////////////////////////////////////////////////// Presentations condition////////////////////////////////////////////////
        else if (Drop_choose.SelectedValue == "5")
        {
            all_none();



            table_All.Style.Add("Display", "none");
            table_inbox.Style.Add("Display", "none");
            table_presentations.Style.Add("Display", "block");
            table_outbox.Style.Add("Display", "none");
            table_Meetings.Style.Add("Display", "none");
            table_Events.Style.Add("Display", "none");
            table_General_Documents.Style.Add("Display", "none");
            div_save.Style.Add("Display", "block");
            hidden_in_out.Value = "5";
        }
        ///////////////////////////////////////////////////////// Evenets Condition/////////////////////////////////////////////
        else if (Drop_choose.SelectedValue == "6")
        {
            all_none();


            table_All.Style.Add("Display", "none");
            table_inbox.Style.Add("Display", "none");
            table_presentations.Style.Add("Display", "none");
            table_Events.Style.Add("Display", "block");
            table_outbox.Style.Add("Display", "none");
            table_Meetings.Style.Add("Display", "none");
            div_save.Style.Add("Display", "block");
            table_General_Documents.Style.Add("Display", "none");
            hidden_in_out.Value = "6";
        }

    }

}

