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

public partial class WebForms_Connecting_InIR_OutIR : System.Web.UI.Page
{
    Session_CS Session_CS = new Session_CS();
    string sql, sql1;
    SqlConnection conn;
    SqlDataAdapter da;
    DataSet ds,ds_total;
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
        div_grid_Main.Style.Add("Display", "none");
        if (hidden_in_out.Value=="1")
        {
            flag = 1;
            hidden1.Value = "1";
           
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            sql = "set dateformat dmy select * from inbox_outbox_View where typedesc=1 and Group_id= " + Session_CS.group_id;
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
                sql += " AND inbox_outbox_View.Org_Id = " + Smrt_Srch_org.SelectedValue;
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
                //sql += " AND convert(datetime,out_valid_date) < = '" + t2.ToString() + "'";
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
            /////////////////////////////////////////////////////////////////// end check on sign_end _date/////////////////////////////////////
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
            sql += " order by convert(datetime,valid_date) desc , convert(datetime,out_valid_date) desc";
           

            conn.Open();
            div_grid_Main.Style.Add("Display", "block");
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
        else if (hidden_in_out.Value=="2")
        {
            flag = 2;
            hidden1.Value = "2";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            sql = "set dateformat dmy SELECT * from inbox_outbox_View where typedesc=2";
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
                sql += " AND inbox_outbox_View.Org_Id = " + Smrt_Srch_org.SelectedValue;
            }
            
            if (string.IsNullOrEmpty(Inbox_date_from.Text) && string.IsNullOrEmpty(Inbox_date_to.Text))
            {
                t3 = DateTime.ParseExact("01/01/1900", "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
                t4 = DateTime.MaxValue.ToString("dd/MM/yyyy");
                //sql += " AND convert(datetime,valid_date) > = '" + t1.ToString() + "'";
                //sql += " AND convert(datetime,valid_date) < = '" + t2.ToString() + "'";
            }
            else if (string.IsNullOrEmpty(Inbox_date_from.Text))
            {
                t3 = DateTime.ParseExact("01/01/1900", "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
                t4 = DateTime.ParseExact(Inbox_date_to.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");

                sql += " AND convert(datetime,valid_date) < = '" + t4.ToString() + "'";
            }
            else if (string.IsNullOrEmpty(Inbox_date_to.Text))
            {
                t3 = DateTime.ParseExact(Inbox_date_from.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
                t4 = DateTime.MaxValue.ToString("dd/MM/yyyy");

                sql += " AND convert(datetime,valid_date) > = '" + t3.ToString() + "'";
            }
            else
            {
                t3 = DateTime.ParseExact(Inbox_date_from.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");

                t4 = DateTime.ParseExact(Inbox_date_to.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");

                sql += " AND convert(datetime,valid_date) > = '" + t3.ToString() + "'";
                sql += " AND convert(datetime,valid_date) < = '" + t4.ToString() + "'";

            }
            DateTime date3 = DateTime.ParseExact(t3, "dd/MM/yyyy", null);
            DateTime date4 = DateTime.ParseExact(t4, "dd/MM/yyyy", null);
            if (date4.Subtract(date3).Days < 0)
            {
                ShowAlertMessage("!!!!!التاريخ الأول يجب ان يكون قبل التاريخ الثاني !!!!");
                return;
            }
            //////////////////////////////////////////////////////////// finished check on Date Field/////////////////////////////////////

            /////////////////////////////////////////////////////// begin check on Outbox Date Field///////////////////////////////////////////
            if (string.IsNullOrEmpty(Outbox_date_from.Text) && string.IsNullOrEmpty(Outbox_date_to.Text))
            {
                t3 = DateTime.ParseExact("01/01/1900", "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
                t4 = DateTime.MaxValue.ToString("dd/MM/yyyy");
                //sql += " AND convert(datetime,out_valid_date) > = '" + t1.ToString() + "'";
                //sql += " AND convert(datetime,out_valid_date) < = '" + t2.ToString() + "'";
            }
            else if (string.IsNullOrEmpty(Outbox_date_from.Text))
            {
                t3 = DateTime.ParseExact("01/01/1900", "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
                t4 = DateTime.ParseExact(Outbox_date_to.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");

                sql += " AND convert(datetime,out_valid_date) < = '" + t4.ToString() + "'";
            }
            else if (string.IsNullOrEmpty(Outbox_date_to.Text))
            {
                t3 = DateTime.ParseExact(Outbox_date_from.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
                t4 = DateTime.MaxValue.ToString("dd/MM/yyyy");

                sql += " AND convert(datetime,out_valid_date) > = '" + t3.ToString() + "'";
            }
            else
            {
                t3 = DateTime.ParseExact(Outbox_date_from.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");

                t4 = DateTime.ParseExact(Outbox_date_to.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");

                sql += " AND convert(datetime,out_valid_date) > = '" + t3.ToString() + "'";
                sql += " AND convert(datetime,out_valid_date) < = '" + t4.ToString() + "'";

            }
            /////////////////////////////////////////////////////////////////// end check on sign_end _date/////////////////////////////////////
            DateTime date1 = DateTime.ParseExact(t3, "dd/MM/yyyy", null);
            DateTime date2 = DateTime.ParseExact(t4, "dd/MM/yyyy", null);
            if (date2.Subtract(date1).Days < 0)
            {
                ShowAlertMessage("!!!!!التاريخ الأول يجب ان يكون قبل التاريخ الثاني !!!!");
                return;
            }
            if (Session_CS.Project_id != null)
            {
                sql += " AND Proj_id = " + int.Parse(Session_CS.Project_id.ToString());
            }
            sql += " order by convert(datetime,valid_date) desc , convert(datetime,out_valid_date) desc";
           
            conn.Open();
            div_grid_Main.Style.Add("Display", "block");
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
        else if (hidden_in_out.Value == "3")
        {
            flag = 3;
            hidden1.Value = "3";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            sql = "set dateformat dmy ";
            sql += " SELECT ID, Proj_id, Name, Code, Date,Group_id,pmp_pmp_id, incombination, Type, Emp_ID, Related_Type, Related_Id, Paper_No, Paper_Attached, Org_Dept_Name, outcombination, Org_Desc,";
            sql += " Org_Id,Subject,Org_Out_Box_DT,valid_date,out_valid_date";
            sql += " FROM from_inbox_Minister_view where 1=1";
            
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
            div_grid_Main.Style.Add("Display", "block");
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
        //else
        //{
        //    flag = 4;
        //    hidden1.Value = "4";
        //    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        //    sql = "set dateformat dmy SELECT * from InIR_OutIR_View where 1=1 ";
        //    if (Txtcode.Text != "")
        //    {
        //        sql += " AND Code like" + "'%" + Txtcode.Text + "%'";
        //    }
        //    if (Inbox_name_text.Text != "")
        //    {
        //        sql += " AND Subject like" + "'%" + Inbox_name_text.Text + "%'";
        //    }
        //    if (Smrt_Srch_org.SelectedValue != "")
        //    {
        //        sql += " AND inbox_outbox_View.Org_Id = " + Smrt_Srch_org.SelectedValue;
        //    }
        //    if (string.IsNullOrEmpty(Inbox_date_from.Text) && string.IsNullOrEmpty(Inbox_date_to.Text))
        //    {
        //        t5 = DateTime.ParseExact("01/01/1900", "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
        //        t6 = DateTime.MaxValue.ToString("dd/MM/yyyy");
        //        //sql += " AND convert(datetime,valid_date) > = '" + t1.ToString() + "'";
        //        //sql += " AND convert(datetime,valid_date) < = '" + t2.ToString() + "'";
        //    }
        //    else if (string.IsNullOrEmpty(Inbox_date_from.Text))
        //    {
        //        t5 = DateTime.ParseExact("01/01/1900", "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
        //        t6 = DateTime.ParseExact(Inbox_date_to.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");

        //        sql += " AND convert(datetime,valid_date) < = '" + t6.ToString() + "'";
        //    }
        //    else if (string.IsNullOrEmpty(Inbox_date_to.Text))
        //    {
        //        t5 = DateTime.ParseExact(Inbox_date_from.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
        //        t6 = DateTime.MaxValue.ToString("dd/MM/yyyy");

        //        sql += " AND convert(datetime,valid_date) > = '" + t5.ToString() + "'";
        //    }
        //    else
        //    {
        //        t5 = DateTime.ParseExact(Inbox_date_from.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");

        //        t6 = DateTime.ParseExact(Inbox_date_to.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");

        //        sql += " AND convert(datetime,valid_date) > = '" + t5.ToString() + "'";
        //        sql += " AND convert(datetime,valid_date) < = '" + t6.ToString() + "'";

        //    }
        //    DateTime date3 = DateTime.ParseExact(t5, "dd/MM/yyyy", null);
        //    DateTime date4 = DateTime.ParseExact(t6, "dd/MM/yyyy", null);
        //    if (date4.Subtract(date3).Days < 0)
        //    {
        //        ShowAlertMessage("!!!!!التاريخ الأول يجب ان يكون قبل التاريخ الثاني !!!!");
        //        return;
        //    }
        //    //////////////////////////////////////////////////////////// finished check on Date Field/////////////////////////////////////

        //    /////////////////////////////////////////////////////// begin check on Outbox Date Field///////////////////////////////////////////
        //    if (string.IsNullOrEmpty(Outbox_date_from.Text) && string.IsNullOrEmpty(Outbox_date_to.Text))
        //    {
        //        t5 = DateTime.ParseExact("01/01/1900", "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
        //        t6 = DateTime.MaxValue.ToString("dd/MM/yyyy");
        //        //sql += " AND convert(datetime,out_valid_date) > = '" + t1.ToString() + "'";
        //        //sql += " AND convert(datetime,out_valid_date) < = '" + t2.ToString() + "'";
        //    }
        //    else if (string.IsNullOrEmpty(Outbox_date_from.Text))
        //    {
        //        t5 = DateTime.ParseExact("01/01/1900", "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
        //        t6 = DateTime.ParseExact(Outbox_date_to.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");

        //        sql += " AND convert(datetime,out_valid_date) < = '" + t6.ToString() + "'";
        //    }
        //    else if (string.IsNullOrEmpty(Outbox_date_to.Text))
        //    {
        //        t5 = DateTime.ParseExact(Outbox_date_from.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
        //        t6 = DateTime.MaxValue.ToString("dd/MM/yyyy");

        //        sql += " AND convert(datetime,out_valid_date) > = '" + t6.ToString() + "'";
        //    }
        //    else
        //    {
        //        t5 = DateTime.ParseExact(Outbox_date_from.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");

        //        t6 = DateTime.ParseExact(Outbox_date_to.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");

        //        sql += " AND convert(datetime,out_valid_date) > = '" + t5.ToString() + "'";
        //        sql += " AND convert(datetime,out_valid_date) < = '" + t6.ToString() + "'";

        //    }
        //    /////////////////////////////////////////////////////////////////// end check on sign_end _date/////////////////////////////////////
        //    DateTime date1 = DateTime.ParseExact(t5, "dd/MM/yyyy", null);
        //    DateTime date2 = DateTime.ParseExact(t6, "dd/MM/yyyy", null);
        //    if (date2.Subtract(date1).Days < 0)
        //    {
        //        ShowAlertMessage("!!!!!التاريخ الأول يجب ان يكون قبل التاريخ الثاني !!!!");
        //        return;
        //    }
        //    if (Session_CS.Project_id != null)
        //    {
        //        sql += " AND Proj_id = " + int.Parse(Session_CS.Project_id.ToString());
        //    }
        //    sql += " order by convert(datetime,valid_date) desc , convert(datetime,out_valid_date) desc";
           
        //    conn.Open();
        //    div_grid_Main.Style.Add("Display", "block");
        //    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        //    DataTable dt = new DataTable();
        //    da.Fill(dt);
        //    if (dt.Rows.Count == 0)
        //    {
        //        gvMain.EmptyDataText = ".....عفوا لا يوجد بيانات ......";
        //    }
        //    else
        //    {
        //        gvMain.DataSource = dt;
        //    }
        //    gvMain.DataBind();
        //    conn.Close();
        //}
    }

    protected void SaveButton_Click(object sender, EventArgs e)
    {
        //SmtpMail.Send("me", "moatazfalak@yahoo.com", "dgshdgshd", "ssssssssssssssssssssssss");
        SearchRecord();
    }

    
    protected void gvMain_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }       
    public void Rec_List_Inbox(int table_id)
    {
        conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        conn.Open();
        DataSet Ds_Temp = new DataSet();
        sql = "select *,convert(nvarchar(max),Related_Type) as Rtype,convert(nvarchar(max),Related_Type) as R2type,";
        sql += " dbo.datevalid(inbox.Date) AS valid_date,dbo.datevalid(inbox.Org_Out_Box_DT) AS out_valid_date,convert(datetime,dbo.datevalid(inbox.Date)) as dateconverted from Inbox where Related_ID=" + table_id;
        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        da.Fill(Ds_Temp);
        if (Ds_Temp.Tables[0].Rows.Count == 0)
        {
            return;
        }
       
       
        else
        {
            for (int j = 0; j < Ds_Temp.Tables[0].Rows.Count; j++)
            {
                if (Ds_Temp.Tables[0].Rows[j]["Rtype"].ToString() == "2")
                {
                    Ds_Temp.Tables[0].Rows[j]["Rtype"] = "رد علي صادر";
                    Ds_Temp.Tables[0].Rows[j]["R2type"] = "";
                }
                if (Ds_Temp.Tables[0].Rows[j]["Rtype"].ToString() == "3")
                {

                    Ds_Temp.Tables[0].Rows[j]["Rtype"] = "استعجال وارد";
                    Ds_Temp.Tables[0].Rows[j]["R2type"] = "";

                }
                if (Ds_Temp.Tables[0].Rows[j]["Rtype"].ToString() == "4")
                {

                    Ds_Temp.Tables[0].Rows[j]["Rtype"] = "استكمال وارد";
                    Ds_Temp.Tables[0].Rows[j]["R2type"] = "";

                }
            }
           
            ds_total.Merge(Ds_Temp);                                 
            for (int i = 0; i < Ds_Temp.Tables[0].Rows.Count; i++)
            {
                Rec_List_Inbox(int.Parse(Ds_Temp.Tables[0].Rows[i]["ID"].ToString()));
                Rec_List_outbox(int.Parse(Ds_Temp.Tables[0].Rows[i]["ID"].ToString()));
            }
            return;
        }
    }
    public void Rec_List_Inbox_minister(int table_id)
    {
        conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        conn.Open();
        DataSet Ds_Temp = new DataSet();
        sql = "select *,convert(nvarchar(max),Related_Type) as Rtype,convert(nvarchar(max),Related_Type) as R2type,";
        sql += " dbo.datevalid(inbox_minister.Date) AS valid_date,dbo.datevalid(inbox_minister.Org_Out_Box_DT) AS out_valid_date,convert(datetime,dbo.datevalid(inbox_minister.Date)) as dateconverted from Inbox_minister where Related_ID=" + table_id;
        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        da.Fill(Ds_Temp);
        if (Ds_Temp.Tables[0].Rows.Count == 0)
        {
            return;
        }


        else
        {
            for (int j = 0; j < Ds_Temp.Tables[0].Rows.Count; j++)
            {
                if (Ds_Temp.Tables[0].Rows[j]["Rtype"].ToString() == "2")
                {
                    Ds_Temp.Tables[0].Rows[j]["Rtype"] = "رد على مذكرة عرض";
                    Ds_Temp.Tables[0].Rows[j]["R2type"] = "";
                }
                
            }

            ds_total.Merge(Ds_Temp);
            for (int i = 0; i < Ds_Temp.Tables[0].Rows.Count; i++)
            {
                Rec_List_Inbox_minister(int.Parse(Ds_Temp.Tables[0].Rows[i]["ID"].ToString()));
                Rec_List_outbox(int.Parse(Ds_Temp.Tables[0].Rows[i]["ID"].ToString()));
            }
            return;
        }
    }
    public void Rec_List_outbox(int table_id)
    {
        conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        conn.Open();
        DataSet Ds_Temp = new DataSet();
        sql = "select *,convert(nvarchar(max),Related_Type) as Rtype,convert(nvarchar(max),Related_Type) as R2type,";
        sql += " dbo.datevalid(outbox.Date) AS valid_date,dbo.datevalid(outbox.Org_Out_Box_DT) AS out_valid_date,convert(datetime,dbo.datevalid(outbox.Date)) as dateconverted from outbox where Related_ID=" + table_id;
        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        da.Fill(Ds_Temp);
        if (Ds_Temp.Tables[0].Rows.Count == 0)
        {
            return;
        }
       
        else
        {
            for (int j = 0; j < Ds_Temp.Tables[0].Rows.Count; j++)
            {
                if (Ds_Temp.Tables[0].Rows[j]["R2type"].ToString() == "2")
                {
                    Ds_Temp.Tables[0].Rows[j]["Rtype"] = "";
                    Ds_Temp.Tables[0].Rows[j]["R2type"] = "رد علي وارد";
                }
                if (Ds_Temp.Tables[0].Rows[j]["R2type"].ToString() == "3")
                {

                    Ds_Temp.Tables[0].Rows[j]["RType"] = "";
                    Ds_Temp.Tables[0].Rows[j]["R2type"] = "استعجال صادر";

                }
                if (Ds_Temp.Tables[0].Rows[j]["R2type"].ToString() == "4")
                {

                    Ds_Temp.Tables[0].Rows[j]["RType"] = "";
                    Ds_Temp.Tables[0].Rows[j]["R2type"] = "رد علي تأشيرة وزير";

                }
            }
       
            ds_total.Merge(Ds_Temp);
            for (int i = 0; i < Ds_Temp.Tables[0].Rows.Count; i++)
            {
                Rec_List_outbox(int.Parse(Ds_Temp.Tables[0].Rows[i]["ID"].ToString()));
                Rec_List_Inbox(int.Parse(Ds_Temp.Tables[0].Rows[i]["ID"].ToString()));
            }
            return;
        }
    }
    protected void gvMain_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        conn.Open();
        gvsub.DataSource = null;
        gvsub.DataBind();
        if (e.CommandName == "Link")
        {
            
            if (hidden1.Value=="1")
            {
                div_connecting_label.Style.Add("Display", "Block");
                div_connecting_grid.Style.Add("Display", "block");

                ds_total = new DataSet();
                int parent_id = 0;
                parent_id = int.Parse(e.CommandArgument.ToString());
                Rec_List_Inbox(parent_id);
                Rec_List_outbox(parent_id);
                gvsub.DataSource = ds_total;

                if (ds_total.Tables.Count == 0)
                {
                    return;
                }
                else
                {
                    DataTable dt = ds_total.Tables[0];
                    dt.DefaultView.Sort = "dateconverted desc";
                    gvsub.DataBind();
                }
            }
            else if (hidden1.Value == "2")
            {
                div_connecting_label.Style.Add("Display", "Block");
                div_connecting_grid.Style.Add("Display", "block");

                ds_total = new DataSet();
                int parent_id = 0;
                parent_id = int.Parse(e.CommandArgument.ToString());
                Rec_List_outbox(parent_id);
                Rec_List_Inbox(parent_id);
                gvsub.DataSource = ds_total;

                if (ds_total.Tables.Count == 0)
                {
                    return;
                }
                else
                {
                    DataTable dt = ds_total.Tables[0];
                    dt.DefaultView.Sort = "dateconverted desc";
                    gvsub.DataBind();
                }
            }
            else if (hidden1.Value == "3")
            {
                div_connecting_label.Style.Add("Display", "Block");
                div_connecting_grid.Style.Add("Display", "block");

                ds_total = new DataSet();
                int parent_id = 0;
                parent_id = int.Parse(e.CommandArgument.ToString());
                Rec_List_outbox(parent_id);
                Rec_List_Inbox_minister(parent_id);
                gvsub.DataSource = ds_total;

                if (ds_total.Tables.Count == 0)
                {
                    return;
                }
                else
                {
                    DataTable dt = ds_total.Tables[0];
                    dt.DefaultView.Sort = "dateconverted desc";
                    gvsub.DataBind();
                }
            }
            else
            {

                sql = " SELECT typedesc from inbox_outbox_View where ID = " + e.CommandArgument;
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataSet ds_all = new DataSet();
                da.Fill(ds_all);
                if (ds_all.Tables[0].Rows[0]["typedesc"].ToString() == "1")
                {
                    div_connecting_label.Style.Add("Display", "Block");
                    div_connecting_grid.Style.Add("Display", "block");

                    ds_total = new DataSet();
                    int parent_id = 0;
                    parent_id = int.Parse(e.CommandArgument.ToString());
                    Rec_List_Inbox(parent_id);
                    Rec_List_outbox(parent_id);
                    gvsub.DataSource = ds_total;

                    if (ds_total.Tables.Count == 0)
                    {
                        return;
                    }
                    else
                    {
                        DataTable dt = ds_total.Tables[0];
                        dt.DefaultView.Sort = "dateconverted desc";
                        gvsub.DataBind();
                    }
                }
                else
                {

                    div_connecting_label.Style.Add("Display", "Block");
                    div_connecting_grid.Style.Add("Display", "block");

                    ds_total = new DataSet();
                    int parent_id = 0;
                    parent_id = int.Parse(e.CommandArgument.ToString());
                    Rec_List_outbox(parent_id);
                    Rec_List_Inbox(parent_id);
                    gvsub.DataSource = ds_total;

                    if (ds_total.Tables.Count == 0)
                    {
                        return;
                    }
                    else
                    {
                        DataTable dt = ds_total.Tables[0];
                        dt.DefaultView.Sort = "dateconverted desc";
                        gvsub.DataBind();
                    }
                    
                }


               
            }

           
               
         


        }

            //////////////////////////////////////////////////////////////////////////////////////////
        //else if (e.CommandName=="Link_minister")
        //{
        //    if (hidden1.Value == "1")
        //    {
        //        div_connecting_label.Style.Add("Display", "Block");
        //        div_connecting_grid.Style.Add("Display", "block");

        //        ds_total = new DataSet();
        //        int parent_id = 0;
        //        parent_id = int.Parse(e.CommandArgument.ToString());
        //        Rec_List_Inbox_minister(parent_id);
        //        Rec_List_outbox(parent_id);
        //        gvsub.DataSource = ds_total;

        //        if (ds_total.Tables.Count == 0)
        //        {
        //            return;
        //        }
        //        else
        //        {
        //            DataTable dt = ds_total.Tables[0];
        //            dt.DefaultView.Sort = "dateconverted desc";
        //            gvsub.DataBind();
        //        }
        //    }
        //    else if (hidden1.Value == "2")
        //    {
        //        div_connecting_label.Style.Add("Display", "Block");
        //        div_connecting_grid.Style.Add("Display", "block");

        //        ds_total = new DataSet();
        //        int parent_id = 0;
        //        parent_id = int.Parse(e.CommandArgument.ToString());
        //        Rec_List_outbox(parent_id);
        //        Rec_List_Inbox_minister(parent_id);
        //        gvsub.DataSource = ds_total;

        //        if (ds_total.Tables.Count == 0)
        //        {
        //            return;
        //        }
        //        else
        //        {
        //            DataTable dt = ds_total.Tables[0];
        //            dt.DefaultView.Sort = "dateconverted desc";
        //            gvsub.DataBind();
        //        }
        //    }
        //    else
        //    {

        //        sql = " SELECT typedesc from inbox_minister_outbox where ID = " + e.CommandArgument;
        //        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        //        DataSet ds_all = new DataSet();
        //        da.Fill(ds_all);
        //        if (ds_all.Tables[0].Rows[0]["typedesc"].ToString() == "1")
        //        {
        //            div_connecting_label.Style.Add("Display", "Block");
        //            div_connecting_grid.Style.Add("Display", "block");

        //            ds_total = new DataSet();
        //            int parent_id = 0;
        //            parent_id = int.Parse(e.CommandArgument.ToString());
        //            Rec_List_Inbox_minister(parent_id);
        //            Rec_List_outbox(parent_id);
        //            gvsub.DataSource = ds_total;

        //            if (ds_total.Tables.Count == 0)
        //            {
        //                return;
        //            }
        //            else
        //            {
        //                DataTable dt = ds_total.Tables[0];
        //                dt.DefaultView.Sort = "dateconverted desc";
        //                gvsub.DataBind();
        //            }
        //        }
        //        else
        //        {

        //            div_connecting_label.Style.Add("Display", "Block");
        //            div_connecting_grid.Style.Add("Display", "block");

        //            ds_total = new DataSet();
        //            int parent_id = 0;
        //            parent_id = int.Parse(e.CommandArgument.ToString());
        //            Rec_List_outbox(parent_id);
        //            Rec_List_Inbox_minister(parent_id);
        //            gvsub.DataSource = ds_total;

        //            if (ds_total.Tables.Count == 0)
        //            {
        //                return;
        //            }
        //            else
        //            {
        //                DataTable dt = ds_total.Tables[0];
        //                dt.DefaultView.Sort = "dateconverted desc";
        //                gvsub.DataBind();
        //            }

        //        }



        //    }

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
    protected void gvsub_RowCommand(object sender, GridViewCommandEventArgs e)
    {
       

            //Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم الحذف بنجاح')</script>");
            //SearchRecord();
        
    }
    protected void gvsub_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
     protected void  showfroinbox()
    {
        div_inbox_code_label.Style.Add("Display", "Block");
        div_inbox_code_text.Style.Add("Display", "Block");
        div_inbox_subject_label.Style.Add("Display", "Block");
        div_inbox_subject_text.Style.Add("Display", "Block");
        div_title_inbox.Style.Add("Display", "Block");
        div_connecting_grid.Style.Add("Display", "none");
        div_title_oubbox.Style.Add("Display", "none");
        div_grid_Main.Style.Add("Display", "none");
        div_title_ALL.Style.Add("Display", "none");
        div_connecting_label.Style.Add("Display", "none");
        div_inbox_date_label.Style.Add("Display", "Block");
        div_inbox_date_label_from.Style.Add("Display", "Block");
        div_inbox_date_text.Style.Add("Display", "Block");
        div_outbox_date_label.Style.Add("Display", "Block");
        div_outbox_date_label_from.Style.Add("Display", "Block");
        div_outbox_date_text.Style.Add("Display", "Block");
        div_inbox_org_label.Style.Add("Display", "Block");
        div_inbox_org_smart.Style.Add("Display", "Block");
        div_save.Style.Add("Display", "Block");
    }
     protected void showfrooutbox()
     {
         div_inbox_code_label.Style.Add("Display", "block");
         div_inbox_code_text.Style.Add("Display", "block");
         div_inbox_subject_label.Style.Add("Display", "block");
         div_inbox_subject_text.Style.Add("Display", "block");
         div_title_inbox.Style.Add("Display", "none");
         div_connecting_grid.Style.Add("Display", "none");
         div_connecting_label.Style.Add("Display", "none");
         div_grid_Main.Style.Add("Display", "none");
         div_inbox_date_label.Style.Add("Display", "block");
         div_inbox_date_label_from.Style.Add("Display", "block");
         div_inbox_date_text.Style.Add("Display", "block");
         div_outbox_date_label.Style.Add("Display", "block");
         div_outbox_date_label_from.Style.Add("Display", "block");
         div_outbox_date_text.Style.Add("Display", "block");
         div_inbox_org_label.Style.Add("Display", "block");
         div_inbox_org_smart.Style.Add("Display", "block");
         div_save.Style.Add("Display", "block");
         div_title_oubbox.Style.Add("Display", "Block");
         div_title_ALL.Style.Add("Display", "none");
     }
    protected void Drop_choose_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Drop_choose.SelectedValue=="1")
        {

            showfroinbox();
            div_title_inbox_minister.Style.Add("Display", "none");
            hidden_in_out.Value = "1";
            gvMain.Columns[5].HeaderText = "المرتبط ";
            //div_inbox_code_label.Style.Add("Display", "Block");
            //gvMain.Columns[6].Visible = false;
        }
        else if (Drop_choose.SelectedValue=="2")
        {
            showfrooutbox();
            div_title_inbox_minister.Style.Add("Display", "none");
            hidden_in_out.Value = "2";
            //gvMain.Columns[5].HeaderText = "المرتبط بوارد";
            //gvMain.Columns[6].HeaderText = "المرتبط بتأشيرة وزير";
            //gvMain.Columns[6].Visible = true;
        }
        else if (Drop_choose.SelectedValue == "3")
        {
            showfroinbox();
            div_title_inbox.Style.Add("Display", "none");
            div_title_inbox_minister.Style.Add("Display", "block");
            hidden_in_out.Value = "3";
            //gvMain.Columns[5].HeaderText = "المرتبط ";
            //gvMain.Columns[6].Visible = false;
        
        }
        //else if (Drop_choose.SelectedValue == "4")
        //{
        //    div_inbox_code_label.Style.Add("Display", "block");
        //    div_inbox_code_text.Style.Add("Display", "block");
        //    div_inbox_subject_label.Style.Add("Display", "block");
        //    div_inbox_subject_text.Style.Add("Display", "block");
        //    div_title_inbox.Style.Add("Display", "none");
        //    div_connecting_grid.Style.Add("Display", "none");
        //    div_connecting_label.Style.Add("Display", "none");
        //    div_grid_Main.Style.Add("Display", "none");
        //    div_inbox_date_label.Style.Add("Display", "block");
        //    div_inbox_date_label_from.Style.Add("Display", "block");
        //    div_inbox_date_text.Style.Add("Display", "block");
        //    div_outbox_date_label.Style.Add("Display", "block");
        //    div_outbox_date_label_from.Style.Add("Display", "block");
        //    div_outbox_date_text.Style.Add("Display", "block");
        //    div_inbox_org_label.Style.Add("Display", "block");
        //    div_inbox_org_smart.Style.Add("Display", "block");
        //    div_save.Style.Add("Display", "block");
        //    div_title_oubbox.Style.Add("Display", "none");
        //    div_title_ALL.Style.Add("Display", "Block");
        //    div_title_inbox_minister.Style.Add("Display", "none");
        //    hidden_in_out.Value = "4";
        //    gvMain.Columns[5].HeaderText = "المرتبط ";
        //    gvMain.Columns[6].Visible = false;
        //}

    }
    protected void gvMain_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        
    }
}

