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
using System.Data.SqlClient;

public partial class WebForms2_Inbox_List_Emp : System.Web.UI.Page
{
    Session_CS Session_CS = new Session_CS();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session_CS.pmp_id != null && CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()) > 0)
            {

                Load_Grid_Emp();

            }



        }


    }

    private void Load_Grid_Emp()
    {
        string todayplus2 = CDataConverter.ConvertDateTimeToFormatdmy(CDataConverter.ConvertDateTimeNowRtnDt().AddDays(2));
        string todayplus1 = CDataConverter.ConvertDateTimeToFormatdmy(CDataConverter.ConvertDateTimeNowRtnDt().AddDays(1));
        string today = CDataConverter.ConvertDateTimeToFormatdmy(CDataConverter.ConvertDateTimeNowRtnDt());
        ///////////////////////////////////////////////// Review////////////////////////////////////////////
        string Review = "set dateformat dmy SELECT DISTINCT  From_Review_View.Code, From_Review_View.Date, From_Review_View.Group_id, From_Review_View.pmp_pmp_id, From_Review_View.incombination, From_Review_View.Emp_ID, From_Review_View.valid_date, CONVERT(nvarchar, From_Review_View.Subject) AS Subject, From_Review_View.ID, Review_Track_Emp.Review_Status, Review_Track_Emp.Emp_ID FROM         From_Review_View LEFT OUTER JOIN Review_Track_Emp ON From_Review_View.ID = Review_Track_Emp.Review_id WHERE (1 = 1)";
        //////////////////////////////////////////////// Late Commission//////////////////////////////////////////
        string late_commission = " set dateformat dmy SELECT distinct From_commission_view.ID,From_commission_view.Group_id, From_commission_view.pmp_pmp_id, From_commission_view.incombination,From_commission_view.Emp_ID, From_commission_view.Date, convert( nvarchar , From_commission_view.Subject) as Subject,From_commission_view.valid_date  FROM Commission_Visa INNER JOIN From_commission_view ON Commission_Visa.Commission_ID = From_commission_view.ID RIGHT OUTER JOIN  Commission_Visa_Emp ON Commission_Visa.Visa_Id = Commission_Visa_Emp.Visa_Id  where 1=1";
        late_commission += " and  Commission_Visa_Emp.Emp_ID = " + Session_CS.pmp_id;
        ////////////////////////////////////////////////////////////////////////////////////////////

        /////////////////////////////////////////Late Inbox/////////////////////////////////////////////////////
        //string late_inbox = "  set dateformat dmy  SELECT distinct From_inbox_view.ID,From_inbox_view.incombination,From_inbox_view.outcombination,From_inbox_view.Org_Desc,From_inbox_view.Org_Out_Box_Code, From_inbox_view.Date,From_inbox_view.finished,project.proj_title, convert( nvarchar , From_inbox_view.Subject) as Subject  FROM inbox_Visa INNER JOIN From_inbox_view ON inbox_Visa.inbox_ID = From_inbox_view.ID RIGHT OUTER JOIN  inbox_Visa_Emp ON inbox_Visa.Visa_Id = inbox_Visa_Emp.Visa_Id left join project on From_Inbox_View.proj_id = project.proj_id where 1=1";
	    string late_inbox = "  set dateformat dmy  SELECT distinct From_inbox_view.ID as inbox_id,From_inbox_view.incombination,From_inbox_view.outcombination,From_inbox_view.Org_Desc,From_inbox_view.Org_Out_Box_Code, From_inbox_view.Date,From_inbox_view.finished,project.proj_title,  From_inbox_view.Subject   FROM inbox_Visa INNER JOIN From_inbox_view ON inbox_Visa.inbox_ID = From_inbox_view.ID RIGHT OUTER JOIN  inbox_Visa_Emp ON inbox_Visa.Visa_Id = inbox_Visa_Emp.Visa_Id RIGHT OUTER JOIN  Inbox_Track_Emp ON From_inbox_view.ID = Inbox_Track_Emp.inbox_id left join project on From_Inbox_View.proj_id = project.proj_id where 1=1";
        late_inbox += " and  inbox_Visa_Emp.Emp_ID = " + Session_CS.pmp_id;
        ////////////////////////////////////////////////////////////////////////////////////////////////

        string sql_com = " set dateformat dmy SELECT *,Commission_Track_Emp.Emp_ID , Commission_Track_Emp.Type_Track_emp,Commission_Track_Emp.Commission_Status  FROM From_commission_view INNER JOIN " +
                       " Commission_Track_Emp ON From_commission_view.ID = Commission_Track_Emp.Commission_id     ";

        tbl_grd.Visible = true;
        //string main_sql_dr_hesham = " set dateformat dmy SELECT *,Inbox_Track_Emp.Emp_ID , Inbox_Track_Emp.Type_Track_emp,Inbox_Track_Emp.Inbox_Status,project.proj_title  FROM From_Inbox_View INNER JOIN " +
        //               " Inbox_Track_Emp ON From_Inbox_View.ID = Inbox_Track_Emp.inbox_id     ";
        //main_sql_dr_hesham += " left join project on From_Inbox_View.proj_id = project.proj_id where 1=1";
        string main_sql_dr_hesham = " SELECT *,Inbox_Track_Emp.ID, Inbox_Track_Emp.inbox_id, Inbox_Track_Emp.Emp_ID, Inbox_Track_Emp.Inbox_Status, Inbox_Track_Emp.Type_Track_emp   FROM          Inbox_Track_Emp LEFT OUTER JOIN  inbox_follow_emp ON Inbox_Track_Emp.Emp_ID = inbox_follow_emp.pmp_id  AND Inbox_Track_Emp.inbox_id = inbox_follow_emp.inbox_id   left outer join From_Inbox_View on Inbox_Track_Emp.inbox_id = From_Inbox_View.ID  left join project on From_Inbox_View.proj_id = project.proj_id where 1=1";
        /////////////////////////////////////////////////////inbox have follow////////////////////////////////////////////////////////////////////
        string sql_for_follow_only = " set dateformat dmy SELECT *,project.proj_title FROM From_Inbox_View " +
                    " left join project on From_Inbox_View.proj_id = project.proj_id  " +
                    " join inbox_follow_emp on From_Inbox_View.ID = inbox_follow_emp.inbox_id  where 1=1 ";
        ///////////////////////////////////////////////////////////////////////////////////////////////////////
      ///////////////////////////////////////////////////////////// commission have follow////////////////////
        string sql_for_follow_com = " set dateformat dmy SELECT * FROM From_commission_view " +
                      " join Commission_follow_emp on From_commission_view.ID = Commission_follow_emp.Commission_id  where 1=1 ";
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// 
        string main_sql_international = " set dateformat dmy SELECT *,Inbox_Track_Emp.Emp_ID ,Inbox_Track_Emp.Type_Track_emp, Inbox_Track_Emp.Inbox_Status,project.proj_title  FROM from_inbox_Minister_view INNER JOIN " +
                       " Inbox_Track_Emp ON from_inbox_Minister_view.ID = Inbox_Track_Emp.inbox_id     ";
        main_sql_international += " left join project on from_inbox_Minister_view.proj_id = project.proj_id where 1=1";
        if (Request["Type"].ToString() == "1")
        {
            string sql_new_inbox = main_sql_dr_hesham + " AND Type_Track_emp =1 AND Inbox_Track_Emp.Emp_ID =" + Session_CS.pmp_id.ToString() + " AND Inbox_Status = 1  and (  Inbox_Track_Emp.inbox_id not in(select inbox_id from dbo.inbox_follow_emp where inbox_follow_emp.Have_follow=1 and  pmp_id =" + Session_CS.pmp_id + ")) order by Inbox_Track_Emp.inbox_id desc";
            DataTable dt_inbox_new = General_Helping.GetDataTable(sql_new_inbox);
            gvMain.Visible = true;
            gv_com.Visible = false;
            gv_Review.Visible = true;
            gvMain.DataSource = dt_inbox_new;
            gvMain.DataBind();
            lblMain.Text = "قائمة الوارد الجديد";
        }
        if (Request["Type"].ToString() == "Rev_new")
        {
            string rev_new = Review + " and Review_Track_Emp.Emp_ID = " + Session_CS.pmp_id + " and Review_Track_Emp.Review_Status =1";
            DataTable dt_rev_new = General_Helping.GetDataTable(rev_new);
            gvMain.Visible = false;
            gv_Review.Visible = true;
            gv_com.Visible = false;
            gv_Review.DataSource = dt_rev_new;
            gv_Review.DataBind();
            lblMain.Text = "  قائمة النشرات الجديدة ";
        }
        if (Request["Type"].ToString() == "Rev_closed")
        {
            string rev_closed = Review + " and Review_Track_Emp.Emp_ID = " + Session_CS.pmp_id + " and Review_Track_Emp.Review_Status =3";
            DataTable dt_rev_closed = General_Helping.GetDataTable(rev_closed);
            gvMain.Visible = false;
            gv_Review.Visible = true;
            gv_com.Visible = false;
            gv_Review.DataSource = dt_rev_closed;
            gv_Review.DataBind();
            lblMain.Text = "  قائمة النشرات المقروءة ";
        }
        if (Request["Type"].ToString() == "7")
        {
            string sql_new_com = sql_com + " AND Type_Track_emp =1 AND Commission_Track_Emp.Emp_ID =" + Session_CS.pmp_id.ToString() + " AND Commission_Status = 1  and (  Commission_Track_Emp.Commission_id not in(select Commission_id from dbo.Commission_follow_emp where Commission_follow_emp.Have_follow=1 and  pmp_id =" + Session_CS.pmp_id + ")) order by Commission_Track_Emp.Commission_id desc";
            DataTable dt_com_new = General_Helping.GetDataTable(sql_new_com);
            gvMain.Visible = false;
            gv_Review.Visible = false;
            gv_com.Visible = true;
            gv_com.DataSource = dt_com_new;
            gv_com.DataBind();
            lblMain.Text = "قائمة التكليفات الجديدة";
        }
        else if (Request["Type"].ToString() == "2")
        {
            string sql_inbox_old = main_sql_dr_hesham + " AND Type_Track_emp =1 AND Inbox_Track_Emp.Emp_ID =" + Session_CS.pmp_id.ToString() + " AND (Inbox_Status = 2 or  Inbox_Status = 4)  and (  Inbox_Track_Emp.inbox_id not in(select inbox_id from dbo.inbox_follow_emp where inbox_follow_emp.Have_follow=1 and  pmp_id =" + Session_CS.pmp_id + ")) order by Inbox_Track_Emp.inbox_id desc";
            DataTable dt_inbox_old = General_Helping.GetDataTable(sql_inbox_old);
            gvMain.Visible = true;
            gv_Review.Visible = false;
            gv_com.Visible = false;
            gvMain.DataSource = dt_inbox_old;
            gvMain.DataBind();
            lblMain.Text = "قائمة الوارد الجاري";
        }
        else if (Request["Type"].ToString() == "11")
        {
            string sql_inbox_late = late_inbox + " AND CONVERT(datetime, dbo.datevalid(inbox_Visa.Dead_Line_DT))<='" + todayplus2.ToString() + "' and From_inbox_view.finished = 0 and Inbox_Track_Emp.Inbox_Status <> 3";
            DataTable dt_inbox_late = General_Helping.GetDataTable(sql_inbox_late);
            gvMain.Visible = true;
            gv_com.Visible = false;
            gv_Review.Visible = false;
            gvMain.DataSource = dt_inbox_late;
            gvMain.DataBind();
            lblMain.Text = "قائمة الوارد المتأخر";
        }
        else if (Request["Type"].ToString() == "8")
        {
            string sql_com_old = sql_com + " AND Type_Track_emp =1 AND Commission_Track_Emp.Emp_ID =" + Session_CS.pmp_id.ToString() + " AND (Commission_Status = 2 or  Commission_Status = 4)  and (  Commission_Track_Emp.Commission_id not in(select Commission_id from dbo.Commission_follow_emp where Commission_follow_emp.Have_follow=1 and  pmp_id =" + Session_CS.pmp_id + ")) order by Commission_Track_Emp.Commission_id desc";
            DataTable dt_com_old = General_Helping.GetDataTable(sql_com_old);
            gvMain.Visible = false;
            gv_com.Visible = true;
            gv_Review.Visible = false;
            gv_com.DataSource = dt_com_old;
            gv_com.DataBind();
            lblMain.Text = "قائمة التكليفات الجارية";
        }
        else if (Request["Type"].ToString() == "12")
        {
            string sql_com_late = late_commission + " AND CONVERT(datetime, dbo.datevalid(Commission_Visa.Dead_Line_DT))<='" + todayplus2.ToString() + "' and From_commission_view.finished = 0";
            DataTable dt_com_late = General_Helping.GetDataTable(sql_com_late);
            gvMain.Visible = false;
            gv_com.Visible = true;
            gv_Review.Visible = false;
            gv_com.DataSource = dt_com_late;
            gv_com.DataBind();
            lblMain.Text = "قائمة التكليفات المتأخرة";
        }
        if (Request["Type"].ToString() == "6")
        {
            string sql_inbox_follow = sql_for_follow_only + "AND inbox_follow_emp.Have_follow=1 AND inbox_follow_emp.pmp_id =" + CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
            DataTable dt_inbox_follow = General_Helping.GetDataTable(sql_inbox_follow);
            gvMain.Visible = true;
            gv_Review.Visible = false;
            gv_com.Visible = false;
            gvMain.DataSource = dt_inbox_follow;
            gvMain.DataBind();
            lblMain.Text = "قائمة الوارد له متابعة";
        }
        if (Request["Type"].ToString() == "10")
        {
            string sql_com_follow = sql_for_follow_com + "AND Commission_follow_emp.Have_follow=1 AND Commission_follow_emp.pmp_id =" + CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
            DataTable dt_com_follow = General_Helping.GetDataTable(sql_com_follow);
            gvMain.Visible = false;
            gv_com.Visible = true;
            gv_Review.Visible = false;
            gv_com.DataSource = dt_com_follow;
            gv_com.DataBind();
            lblMain.Text = "قائمة التكليفات لها متابعة";
        }
        else if (Request["Type"].ToString() == "5")
        {
            string sql_inbox_closed = main_sql_dr_hesham + " AND Type_Track_emp =1 AND Inbox_Track_Emp.Emp_ID =" + Session_CS.pmp_id.ToString() + " AND Inbox_Status = 3   order by Inbox_Track_Emp.inbox_id desc";
            DataTable dt_inbox_closed = General_Helping.GetDataTable(sql_inbox_closed);
            gvMain.Visible = true;
            gv_Review.Visible = false;
            gv_com.Visible = false;
            gvMain.DataSource = dt_inbox_closed;
            gvMain.DataBind();
            lblMain.Text = "قائمة الوارد المنتهي";
        }
        else if (Request["Type"].ToString() == "9")
        {
            string sql_com_closed = sql_com + " AND Type_Track_emp =1 AND Commission_Track_Emp.Emp_ID =" + Session_CS.pmp_id.ToString() + " AND Commission_Status = 3   order by Commission_Track_Emp.Commission_ID desc";
            DataTable dt_com_closed = General_Helping.GetDataTable(sql_com_closed);
            gvMain.Visible = false;
            gv_com.Visible = true;
            gv_Review.Visible = false;
            gv_com.DataSource = dt_com_closed;
            gv_com.DataBind();
            lblMain.Text = "قائمة التكليفات المنتهية";
        }
        else if (Request["Type"].ToString() == "3")
        {
            string sql_inbox_minister_old = main_sql_international + " AND Type_Track_emp =3 AND Inbox_Track_Emp.Emp_ID =" + Session_CS.pmp_id.ToString() + " AND Inbox_Status = 1 order by Inbox_Track_Emp.inbox_id desc";
            DataTable dt_inbox_minister_old = General_Helping.GetDataTable(sql_inbox_minister_old);
            gvMain.Visible = true;
            gv_Review.Visible = false;
            gv_com.Visible = false;
            gvMain.DataSource = dt_inbox_minister_old;
            gvMain.DataBind();
            lblMain.Text = "قائمة تأشيرة وزير الجديد";
        }
        else if (Request["Type"].ToString() == "4")
        {
            string sql_inbox_minister_old = main_sql_international + " AND Type_Track_emp =3 AND Inbox_Track_Emp.Emp_ID =" + Session_CS.pmp_id.ToString() + " AND Inbox_Status = 2 order by Inbox_Track_Emp.inbox_id desc";
            DataTable dt_inbox_minister_old = General_Helping.GetDataTable(sql_inbox_minister_old);
            gvMain.Visible = true;
            gv_Review.Visible = false;
            gv_com.Visible = false;
            gvMain.DataSource = dt_inbox_minister_old;
            gvMain.DataBind();
            lblMain.Text = "قائمة تأشيرة وزير الجارية";
        }



    }
    protected void gv_Review_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "show_Review_Details")
        {


            Response.Redirect("..\\WebForms2\\ViewProjectReview.aspx?id=" + e.CommandArgument);
        }


    }
    protected void gv_Review_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv_Review.PageIndex = e.NewPageIndex;
        Load_Grid_Emp();
    }
    protected void gvMain_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        if (e.CommandName == "show_inbox_Details")
        {
            if (Request["Type"].ToString() == "1" || Request["Type"].ToString() == "6")
            {
                Inbox_DB.update_inbox_Track_Emp(e.CommandArgument.ToString(), Session_CS.pmp_id.ToString(), 2, 1);
                //conn.Open();
                //string sql_update = "update inbox_follow_emp set Have_follow = 0";
                //sql_update += " where inbox_id  =" + e.CommandArgument;
                //SqlCommand cmd = new SqlCommand(sql_update, conn);
                //cmd.ExecuteNonQuery();
                //conn.Close(); 
                Response.Redirect("ViewProjectInbox.aspx?id=" + e.CommandArgument);
            }
            else if (Request["Type"].ToString() == "2" || Request["Type"].ToString() == "5" || Request["Type"].ToString() == "11")
            {
                //Inbox_DB.update_inbox_Track_Emp(e.CommandArgument.ToString(), Session_CS.pmp_id.ToString(), 2, 1);
                Response.Redirect("ViewProjectInbox.aspx?id=" + e.CommandArgument);
            }
            else if (Request["Type"].ToString() == "3")
            {
                Inbox_Minister_DB.update_inbox_Track_Emp(e.CommandArgument.ToString(), Session_CS.pmp_id.ToString(), 2, 3);
                Response.Redirect("ViewProjectInboxminister.aspx?id=" + e.CommandArgument);
            }
            else if (Request["Type"].ToString() == "4")
            {
                Response.Redirect("ViewProjectInboxminister.aspx?id=" + e.CommandArgument);
            }

        }
        


    }
    protected void gv_com_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        if (e.CommandName == "show_com_Details")
        {
            if ( Request["Type"].ToString() == "7" || Request["Type"].ToString() == "10")
            {
                Commission_DB.update_Commission_Track_Emp(e.CommandArgument.ToString(), Session_CS.pmp_id.ToString(), 2, 1);
                //conn.Open();
                //string sql_update = "update inbox_follow_emp set Have_follow = 0";
                //sql_update += " where inbox_id  =" + e.CommandArgument;
                //SqlCommand cmd = new SqlCommand(sql_update, conn);
                //cmd.ExecuteNonQuery();
                //conn.Close(); 
                Response.Redirect("View_Commission.aspx?id=" + e.CommandArgument);
            }
            else if (Request["Type"].ToString() == "8" || Request["Type"].ToString() == "9" || Request["Type"].ToString() == "12")
            {
                //Inbox_DB.update_inbox_Track_Emp(e.CommandArgument.ToString(), Session_CS.pmp_id.ToString(), 2, 1);
                Response.Redirect("View_Commission.aspx?id=" + e.CommandArgument);
            }
            else if (Request["Type"].ToString() == "3")
            {
                //Inbox_Minister_DB.update_inbox_Track_Emp(e.CommandArgument.ToString(), Session_CS.pmp_id.ToString(), 2, 3);
                //Response.Redirect("ViewProjectInboxminister.aspx?id=" + e.CommandArgument);
            }
            else if (Request["Type"].ToString() == "4")
            {
                //Response.Redirect("ViewProjectInboxminister.aspx?id=" + e.CommandArgument);
            }

        }



    }


    protected void gvMain_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvMain.PageIndex = e.NewPageIndex;
        Load_Grid_Emp();
    }
    protected void gv_com_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv_com.PageIndex = e.NewPageIndex;
        Load_Grid_Emp();
    }
}