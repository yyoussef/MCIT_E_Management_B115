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

public partial class UserControls_Projects_Grid_Page : System.Web.UI.UserControl
{
    //Session_CS Session_CS = new Session_CS();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session_CS.pmp_id != null && CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()) > 0)
            {
               // Session_CS.Project_id = 0;
                Load_Grids();

            }
            else
            {
                Response.Redirect("~\\Grids_Dr_Hesham.aspx");
            }


        }


    }




    public string Get_url(object proj_id)
    {

        if (Request["Type"].ToString() == "suggest_proj")
            return "~/MainForm/Project_Details.aspx?Proj_id=" + proj_id.ToString() + "&mode=edit";
        else
            return "~/MainForm/Project_Details.aspx?proj_id=" + proj_id.ToString();


    }

    private void Load_Grids()
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
        DataTable dt_Proj_Const = new DataTable();


       

        
       
        ////////////////////////////////////////////////////////////////////////////////////////////////////////
        if (Request["Type"].ToString() == "Active_proj")
        {
            
            dt_avtive_proj = Project_class.Active_Projects(rol, Dept, pmp);
            
            gvMain.DataSource = dt_avtive_proj;
            gvMain.DataBind();
            lblMain.Text = "قائمة المشروعات الجارية";
        }
        if (Request["Type"].ToString() == "Ended_proj")
        {
            dt_Ended_proj = Project_class.Ended_Projects(rol, Dept, pmp);
            gvMain.DataSource = dt_Ended_proj;
            gvMain.DataBind();
            lblMain.Text = "قائمة المشروعات المنهية";
        }
        if (Request["Type"].ToString() == "underfollow_proj")
        {
            dt_underfollow_proj = Project_class.under_follow_Projects(rol, Dept, pmp);
            gvMain.DataSource = dt_underfollow_proj;
            gvMain.DataBind();
            lblMain.Text = "قائمة المشروعات المنتهيه تحت المتابعة";
        }
        if (Request["Type"].ToString() == "stopped_proj")
        {
            dt_stopped_proj = Project_class.Stopped_Projects(rol, Dept, pmp);
            gvMain.DataSource = dt_stopped_proj;
            gvMain.DataBind();
            lblMain.Text = "قائمة المشروعات المتوقفة";
        }
        if (Request["Type"].ToString() == "suggest_proj")
        {
            dt_suggest_proj = Project_class.Suggest_Projects(rol, Dept, pmp);
            gvMain.DataSource = dt_suggest_proj;
           
            gvMain.DataBind();
            lblMain.Text = "قائمة المشروعات المقترحة";
        }
        if (Request["Type"].ToString() == "suggest_approved_proj")
        {
            dt_suggest_approved_proj = Project_class.Suggest_Approved_Projects(rol, Dept, pmp);
            gvMain.DataSource = dt_suggest_approved_proj;
            gvMain.DataBind();
            lblMain.Text = "قائمة المشروعات الجديدة المعتمدة";

        }
        if (Request["Type"].ToString() == "Repeated_proj")
        {
            dt_Repeated_proj = Project_class.Repeated_Projects(rol, Dept, pmp);
            gvMain.DataSource = dt_Repeated_proj;
            gvMain.DataBind();
            lblMain.Text = "قائمة المشروعات المطلوب اعادتها";
        }
        if (Request["Type"].ToString() == "Refused_proj")
        {
            dt_Refused_proj = Project_class.Refused_Projects(rol, Dept, pmp);
            gvMain.DataSource = dt_Refused_proj;
            gvMain.DataBind();
            lblMain.Text = "قائمة المشروعات التي تم رفضها";

        }
        if (Request["Type"].ToString() == "Canceled_proj")
        {
            dt_Canceled_proj = Project_class.Canceled_Projects(rol, Dept, pmp);
            gvMain.DataSource = dt_Canceled_proj;
            gvMain.DataBind();
            lblMain.Text = "قائمة المشروعات تم الغاؤها";

        }


        if (Request["Type"].ToString() == "proj_const")
        {
            dt_Proj_Const = Project_class.Projects_Constraints ();
            Gv_Proj_const .DataSource = dt_Proj_Const;
            Gv_Proj_const.DataBind();
            lblMain.Text = "  قائمة المشروعات المتواجد بها معوقات وتحتاج تدخل إدارة عليا ";
            gvMain.Visible = false;

        }
       
      

    }

   
   
    protected void gvMain_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvMain.PageIndex = e.NewPageIndex;
        Load_Grids();
    }
  
    protected void gvMain_RowCommand(object sender, GridViewCommandEventArgs e)
    {
       // SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        if (e.CommandName == "show_inbox_Details")
        {
            if (Request["Type"].ToString() == "1" || Request["Type"].ToString() == "6")
            {
                Inbox_DB.update_inbox_Track_Emp(e.CommandArgument.ToString(), Session_CS.pmp_id.ToString(), 2, 1);
               
                Response.Redirect("ViewProjectInbox.aspx?id=" + e.CommandArgument);
            }
            else if (Request["Type"].ToString() == "2" || Request["Type"].ToString() == "3" || Request["Type"].ToString() == "10" || Request["Type"].ToString() == "5" || Request["Type"].ToString() == "11")
            {
                
                Response.Redirect("ViewProjectInbox.aspx?id=" + e.CommandArgument);
            }
          

        }



    }
    protected void ImgBtnBack_Click(object sender, System.Web.UI.ImageClickEventArgs e)
    {
        Response.Redirect("~/MainForm/Default.aspx");
    }
}
