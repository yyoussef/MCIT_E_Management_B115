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

public partial class UserControls_ProjectsUserControl : System.Web.UI.UserControl
{
    Session_CS Session_CS = new Session_CS();
    protected void Page_Load(object sender, EventArgs e)
    {
        loadCount();
        Show_Hide_Catagerios_inbox();
        if (!IsPostBack)
        {
            if (CDataConverter.ConvertToInt(Session_CS.UROL_UROL_ID.ToString()) == 2)
            {
                 tr_Commit_2.Visible = tr_Re_Update_2.Visible = tr_Repeted_2.Visible = tr_refused_2.Visible = tr_Canceled_2.Visible = false;
                tr_Commit_2.Visible =done_2.Visible= true;
                tr_Project_Constraints.Visible = true;

            }
          //  else if (CDataConverter.ConvertToInt(Session_CS.UROL_UROL_ID.ToString()) == 3 && CDataConverter.ConvertToInt(Session_CS.UROL_UROL_ID.ToString()) != 3)
           // {
                tr_Re_Update_2.Visible = true;
           // }

           
        }
      
    }
    private void loadCount()
    {

        int pmp = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
        int Dept = CDataConverter.ConvertToInt(Session_CS.dept_id.ToString());
        int rol = CDataConverter.ConvertToInt(Session_CS.UROL_UROL_ID.ToString());
        //initiate variables
        DataTable dt_avtive_proj = new DataTable();
        DataTable dt_Ended_proj = new DataTable();
        DataTable dt_underfollow_proj = new DataTable();
        DataTable dt_stopped_proj = new DataTable();
        DataTable dt_suggest_proj = new DataTable();
        DataTable dt_suggest_approved_proj = new DataTable();
        DataTable dt_Repeated_proj = new DataTable();
        DataTable dt_Refused_proj = new DataTable();
        DataTable dt_Canceled_proj = new DataTable();
        DataTable dt_project_Constraints = new DataTable();
        
       
        ///////////////////// calling the function to get datatable data

        dt_avtive_proj = Project_class.Active_Projects(rol, Dept, pmp);
        dt_Ended_proj = Project_class.Ended_Projects(rol, Dept, pmp);
        dt_underfollow_proj = Project_class.under_follow_Projects(rol, Dept, pmp);
        dt_stopped_proj = Project_class.Stopped_Projects(rol, Dept, pmp);
        dt_suggest_proj = Project_class.Suggest_Projects(rol, Dept, pmp);
        dt_suggest_approved_proj = Project_class.Suggest_Approved_Projects(rol, Dept, pmp);
        dt_Repeated_proj = Project_class.Repeated_Projects(rol, Dept, pmp);
        dt_Refused_proj = Project_class.Refused_Projects(rol, Dept, pmp);
        dt_Canceled_proj = Project_class.Canceled_Projects(rol, Dept, pmp);
        dt_project_Constraints = Project_class.Projects_Constraints();


        ///////////////// assign data counts  to links
        ///////// active projects
        lnk_btn_Active_proj_2.Text = dt_avtive_proj.Rows.Count.ToString();
        /////////ended projects
        lbtnProj_done_2.Text = dt_Ended_proj.Rows.Count.ToString();
        /////////under follow Projects
        Lb_Lbdonefollow_2.Text = dt_underfollow_proj.Rows.Count.ToString();
        //Stopped Projects
        lbtnProj_stopped_2.Text = dt_stopped_proj.Rows.Count.ToString();
        /////// suggest  projects
        LBtnProj_ٍSuggest_2.Text = dt_suggest_proj.Rows.Count.ToString();
        /////// suggest approved projects
        lbtnProj_Approved_2.Text = dt_suggest_approved_proj.Rows.Count.ToString();
        ////////Repeated Projects
        lbtnProj_Repeted_2.Text = dt_Repeated_proj.Rows.Count.ToString();
        //////////////////// Refused projects
        lbtnProj_refused_2.Text = dt_Refused_proj.Rows.Count.ToString();
        //////////////////// Canceled projects
        lnkProj_Canceled_2.Text = dt_Canceled_proj.Rows.Count.ToString();
        //////////////////////////////////Project Constraints//////////////////////////
        lnk_const_count.Text = dt_project_Constraints.Rows.Count.ToString();
    }
    void Show_Hide_Catagerios_inbox()
    {
        if (CDataConverter.ConvertToInt(LBtnProj_ٍSuggest_2.Text) > 0)
            tr_LBtnProj_ٍSuggest_2.BgColor = "#FCFBB2";
        if (CDataConverter.ConvertToInt(LBtnProj_ٍSuggest_2.Text) > 0)
            lbl_Project.ForeColor = System.Drawing.Color.Red;
        //if (CDataConverter.ConvertToInt(link_new_inbox_forall.Text) > 0 || CDataConverter.ConvertToInt(link_inbox_have_follow_forall.Text) > 0)
        //    lbl_archive_forall.ForeColor = System.Drawing.Color.Red;

        ////chnage the BgColor for archiving
        //if (CDataConverter.ConvertToInt(link_new_inbox_forall.Text) > 0)
        //    td_link_new_inbox_forall.BgColor = "#FCFBB2";


        //if (CDataConverter.ConvertToInt(link_inbox_have_follow_forall.Text) > 0)
        //    td_link_inbox_have_follow_forall.BgColor = "#FCFBB2";



    }
    protected void lnk_btn_Active_proj_2_Click(object sender, EventArgs e)
    {
        if (CDataConverter.ConvertToInt(lnk_btn_Active_proj_2.Text) > 0)
        {

            Response.Redirect("Projects_Grid_Page.aspx?Type=Active_proj");


        }
    }
    protected void LBtnProj_ٍSuggest_2_Click(object sender, EventArgs e)
    {
        if (CDataConverter.ConvertToInt(LBtnProj_ٍSuggest_2.Text) > 0)
        {

            Response.Redirect("Projects_Grid_Page.aspx?Type=suggest_proj");

        }
    }
    protected void lbtnProj_done_2_Click(object sender, EventArgs e)
    {
        if (CDataConverter.ConvertToInt(lbtnProj_done_2.Text) > 0)
        {
            Response.Redirect("Projects_Grid_Page.aspx?Type=Ended_proj");
        }
    }
    protected void Lbdonefollow_2_Click(object sender, EventArgs e)
    {
        if (CDataConverter.ConvertToInt(Lb_Lbdonefollow_2.Text) > 0)
        {
            Response.Redirect("Projects_Grid_Page.aspx?Type=underfollow_proj");

        }
    }
    protected void lbtnProj_stopped_2_Click(object sender, EventArgs e)
    {
        if (CDataConverter.ConvertToInt(lbtnProj_stopped_2.Text) > 0)
        {

            Response.Redirect("Projects_Grid_Page.aspx?Type=stopped_proj");
        }
    }
    protected void lbtnProj_Approved_2_Click(object sender, EventArgs e)
    {
        if (CDataConverter.ConvertToInt(lbtnProj_Approved_2.Text) > 0)
        {
            Response.Redirect("Projects_Grid_Page.aspx?Type=suggest_approved_proj");

        }
    }
    protected void lbtnProj_Repeted_2_Click(object sender, EventArgs e)
    {
        if (CDataConverter.ConvertToInt(lbtnProj_Repeted_2.Text) > 0)
        {
            Response.Redirect("Projects_Grid_Page.aspx?Type=Repeated_proj");

        }
    }
    protected void lbtnProj_refused_2_Click(object sender, EventArgs e)
    {
        if (CDataConverter.ConvertToInt(lbtnProj_refused_2.Text) > 0)
        {

            Response.Redirect("Projects_Grid_Page.aspx?Type=Refused_proj");

        }
    }
    protected void lnkProj_Canceled_2_Click(object sender, EventArgs e)
    {
        if (CDataConverter.ConvertToInt(lnkProj_Canceled_2.Text) > 0)
        {

            Response.Redirect("Projects_Grid_Page.aspx?Type=Canceled_proj");

        }
    }

    protected void lnk_const_Click(object sender, EventArgs e)
    {
        if (CDataConverter.ConvertToInt(lnk_const_count.Text) > 0)
        {

            Response.Redirect("Projects_Grid_Page.aspx?Type=proj_const");

        }
    }
  
   
    
}
