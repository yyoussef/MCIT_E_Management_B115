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

public partial class WebForms_Grids_International_Relations : System.Web.UI.Page
{
    //Session_CS Session_CS = new Session_CS();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session_CS.pmp_id != null && CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()) > 0)
            {
                Session_CS.Project_id = 0;
                Load_Grid();
                              
            }
            else
            {
                Response.Redirect("~\\Grids_International_Relations.aspx");
            }


        }
       

    }

  

  
    
   
    private void Load_Grid()
    {

        ///// get group id from employee table 
        DataTable dt_get_group_id = General_Helping.GetDataTable("select group_id from employee where pmp_id = " + CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()));
        int group = CDataConverter.ConvertToInt(dt_get_group_id.Rows[0]["group_id"].ToString());


        tbl_grd.Visible = true;
        string main_sql = "SELECT ID, From_Inbox_View.Proj_id, Name, Code, Date,Org_Out_Box_Code,Group_id,From_Inbox_View.pmp_pmp_id, incombination, Type, Emp_ID, Related_Type, Related_Id, Paper_No, Paper_Attached, Org_Dept_Name, outcombination, Org_Desc,";
        main_sql += " Org_Id,Subject,Org_Out_Box_DT,valid_date,out_valid_date,project.proj_title";
        main_sql += " FROM From_Inbox_View right outer join dbo.Inbox_Track_Manager on From_Inbox_View.id=Inbox_Track_Manager.inbox_id";
        main_sql += " left join project on From_Inbox_View.proj_id = project.proj_id ";
        main_sql += " where 1=1";
        main_sql += "AND Group_id= " + group;
        main_sql += " AND Inbox_Track_Manager.Type_Track = 1";

        string main_sql_inbox_minister = " SELECT ID,from_inbox_Minister_view.Proj_id, Name, Code, Date,Org_Out_Box_Code,Group_id,from_inbox_Minister_view.pmp_pmp_id, incombination, Type, Emp_ID, Related_Type, Related_Id, Paper_No, Paper_Attached, Org_Dept_Name, outcombination, Org_Desc,";
        main_sql_inbox_minister += " Org_Id,Subject,Org_Out_Box_DT,valid_date,out_valid_date,project.proj_title";
        main_sql_inbox_minister += " FROM from_inbox_Minister_view right outer join dbo.Inbox_Track_Manager on from_inbox_Minister_view.id=Inbox_Track_Manager.inbox_id";
        main_sql_inbox_minister += " left join project on from_inbox_Minister_view.proj_id = project.proj_id ";
        main_sql_inbox_minister += " where 1=1 ";
        main_sql_inbox_minister += " AND Group_id = " + group;
        main_sql_inbox_minister += " AND Inbox_Track_Manager.Type_Track = 3";

        if (Request["Type"].ToString()=="1")
        {
            string sql_new_inbox = main_sql + " AND IS_New_Mail=1 order by Inbox_Track_Manager.inbox_id desc";
            DataTable dt_inbox_new = General_Helping.GetDataTable(sql_new_inbox);
            gvMain.Visible = true;
            gvMain.DataSource = dt_inbox_new;
            gvMain.DataBind();
            lblMain.Text = "قائمة الوارد الجديد";
        }
        else if (Request["Type"].ToString() == "2")
        {
            string sql_inbox_have_follow = main_sql + " AND Have_Follow=1 order by Inbox_Track_Manager.inbox_id desc";
            DataTable dt_inbox_have_follow = General_Helping.GetDataTable(sql_inbox_have_follow);
            gvMain.Visible = true;
            gvMain.DataSource = dt_inbox_have_follow;
            gvMain.DataBind();
            lblMain.Text = "قائمة الوارد الذي له متابعة";
        }
        else if (Request["Type"].ToString() == "3")
        {
            string sql_inbox_old = main_sql + " AND IS_New_Mail=0 order by Inbox_Track_Manager.inbox_id desc";
            DataTable dt_inbox_old = General_Helping.GetDataTable(sql_inbox_old);
            gvMain.Visible = true;
            gvMain.DataSource = dt_inbox_old;
            gvMain.DataBind();
            lblMain.Text = "قائمة الوارد القديم";
        }
        else if (Request["Type"].ToString() == "4")
        {
            string sql_inbox_us = main_sql + " AND IS_New_Mail=2 order by Inbox_Track_Manager.inbox_id desc";
            DataTable dt_inbox_us = General_Helping.GetDataTable(sql_inbox_us);
            gvMain.Visible = true;
            gvMain.DataSource = dt_inbox_us;
            gvMain.DataBind();
            lblMain.Text = "قائمة الوارد تحت الدراسة";
        }
        else if (Request["Type"].ToString() == "5")
        {
            string sql_new_inbox_minister = main_sql_inbox_minister + " AND IS_New_Mail=1 order by Inbox_Track_Manager.inbox_id desc";
            DataTable dt_inbox_minister_new = General_Helping.GetDataTable(sql_new_inbox_minister);
            gvMain.Visible = true;
            gvMain.DataSource = dt_inbox_minister_new;
            gvMain.DataBind();
            lblMain.Text = "قائمة تأشيرة الوزير الجديد";
        }
        else if (Request["Type"].ToString() == "6")
        {
            string sql_inbox_minister_have_follow = main_sql_inbox_minister + " AND Have_Follow=1 order by Inbox_Track_Manager.inbox_id desc";
            DataTable dt_inbox_minister_have_follow = General_Helping.GetDataTable(sql_inbox_minister_have_follow);
            gvMain.Visible = true;
            gvMain.DataSource = dt_inbox_minister_have_follow;
            gvMain.DataBind();
            lblMain.Text = "قائمة تأشيرة الوزير الذي له متابعة";
        }
        else if (Request["Type"].ToString() == "7")
        {
            string sql_inbox_minister_old = main_sql_inbox_minister + " AND IS_New_Mail=0 order by Inbox_Track_Manager.inbox_id desc";
            DataTable dt_inbox_minister_old = General_Helping.GetDataTable(sql_inbox_minister_old);
            gvMain.Visible = true;
            gvMain.DataSource = dt_inbox_minister_old;
            gvMain.DataBind();
            lblMain.Text = "قائمة تأشيرة الوزير القديم";
        }
        else if (Request["Type"].ToString() == "8")
        {
            string sql_inbox_minister_us = main_sql_inbox_minister + " AND IS_New_Mail=2 order by Inbox_Track_Manager.inbox_id desc";
            DataTable dt_inbox_minister_us = General_Helping.GetDataTable(sql_inbox_minister_us);
            gvMain.Visible = true;
            gvMain.DataSource = dt_inbox_minister_us;
            gvMain.DataBind();
            lblMain.Text = "قائمة تأشيرة الوزير تحت الدراسة";
        }
       
       
           
            

            ////////////////////////////////////////////////////////////////////////

           
            
        

    }
   

    


   

  

   

   

   
    protected void gvMain_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "show_inbox_Details")
        {
            Response.Redirect("..\\WebForms\\ViewProjectInbox_minister.aspx?id=" + e.CommandArgument);
        }
       

    }
    protected void Gv_inbox_follow_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "show_inbox_Details")
        {
            Response.Redirect("..\\WebForms\\ViewProjectInbox_minister.aspx?id=" + e.CommandArgument);
        }


    }



    protected void gvMain_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvMain.PageIndex = e.NewPageIndex;
        Load_Grid();
    }
}
