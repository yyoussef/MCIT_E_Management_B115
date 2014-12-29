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

public partial class UserControls_Commission_Grid_Page : System.Web.UI.UserControl
{
    Session_CS Session_CS = new Session_CS();
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
                Response.Redirect("~\\Grids_Dr_Hesham.aspx");
            }

           

        }


    }






    private void Load_Grid()
    {

        //string todayplus1 = VB_Classes.Dates.Dates_Operation.date_validate(DateTime.Now.AddDays(1).ToShortDateString());
        //string todayplus2 = VB_Classes.Dates.Dates_Operation.date_validate(DateTime.Now.AddDays(2).ToShortDateString());


        string todayplus1 = CDataConverter.ConvertDateTimeToFormatdmy(CDataConverter.ConvertDateTimeNowRtnDt().AddDays(1));
        string todayplus2 = CDataConverter.ConvertDateTimeToFormatdmy(CDataConverter.ConvertDateTimeNowRtnDt().AddDays(2));

        string today = CDataConverter.ConvertDateTimeToFormatdmy(CDataConverter.ConvertDateTimeNowRtnDt());
        int group = CDataConverter.ConvertToInt(Session_CS.group_id.ToString());
        int parent = CDataConverter.ConvertToInt(Session_CS.parent_id.ToString());
        int pmp = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());

        DataTable dt_com_late = new DataTable();
        DataTable dt_com_new = new DataTable();
        DataTable dt_com_old = new DataTable();
        DataTable dt_com_closed = new DataTable();
        DataTable dt_com_follow = new DataTable();

        
       
        
        
        

        tbl_grd.Visible = true;
        ////////////////////////////////////////////////////////////////////////////////////////////////////////
       
       

        if (Request["Type"].ToString() == "newcom")
        {
            dt_com_new = Commission_DB.new_com_all(parent, group, pmp);
           
            gvMain.Visible = true;
            gvMain.DataSource = dt_com_new;
            gvMain.DataBind();
            lblMain.Text = "قائمة التكليفات الجديدة";
        }
       
        else if (Request["Type"].ToString() == "followcom")
        {

            dt_com_follow = Commission_DB.follow_com_all(parent, pmp);
            gvMain.Visible = true;
            gvMain.DataSource = dt_com_follow;
            gvMain.DataBind();
            lblMain.Text = "قائمة التكليفات التي لها متابعة";
        }
       
       
        else if (Request["Type"].ToString() == "oldcom")
        {
            dt_com_old = Commission_DB.old_com_all(parent, group, pmp);
            gvMain.Visible = true;
            gvMain.DataSource = dt_com_old;
            gvMain.DataBind();
            lblMain.Text = "قائمة التكليفات الجارية";
        }
        else if (Request["Type"].ToString() == "latecom")
        {
            dt_com_late = Commission_DB.late_com_all(parent, group, pmp, todayplus1, todayplus2);

            gvMain.Visible = true;
            gvMain.DataSource = dt_com_late;
            gvMain.DataBind();
         
            lblMain.Text = "قائمة التكليفات المتأخرة";
        }
       
        else if (Request["Type"].ToString() == "closedcom")
        {
            dt_com_closed = Commission_DB.closed_com_all(parent, group, pmp);
            gvMain.Visible = true;
            gvMain.DataSource = dt_com_closed;
            gvMain.DataBind();
         
          
            lblMain.Text = "قائمة التكليفات المنتهية";
        }
       



       

        ////////////////////////////////////////////////////////////////////////





    }

   
   
  
    
   

   
    protected void gvMain_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvMain.PageIndex = e.NewPageIndex;
        Load_Grid();
    }
  
    protected void gvMain_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "show_com_Details")
        {
            string encrypted = Encryption.Encrypt(e.CommandArgument.ToString());
            if (Request["Type"].ToString() == "newcom" || Request["Type"].ToString() == "followcom")
            {
                Commission_DB.update_Commission_Track_Emp(e.CommandArgument.ToString(), Session_CS.pmp_id.ToString(), 2, 1);

                Response.Redirect("View_Commission.aspx?id=" + encrypted);
            }
            else if (Request["Type"].ToString() == "closedcom" || Request["Type"].ToString() == "latecom" || Request["Type"].ToString() == "oldcom")
            {

                Response.Redirect("View_Commission.aspx?id=" + encrypted);
            }
           
        }

    }


    public string GetUrl(object id)
    {

        string url = "";

         url = "~/MainForm/ViewProjectInbox.aspx?id=" + Encryption.Encrypt(id.ToString());

         if (Request["Type"].ToString() == "newcom" || Request["Type"].ToString() == "followcom")
         {
             Commission_DB.update_Commission_Track_Emp(id.ToString(), Session_CS.pmp_id.ToString(), 2, 1);

            
             url = "~/MainForm/View_Commission.aspx?id=" + Encryption.Encrypt(id.ToString());
         }
         else if (Request["Type"].ToString() == "closedcom" || Request["Type"].ToString() == "latecom" || Request["Type"].ToString() == "oldcom")
         {

             url = "~/MainForm/View_Commission.aspx?id=" + Encryption.Encrypt(id.ToString());
         }





        return url;
    }
    protected void ImgBtnBack_Click(object sender, System.Web.UI.ImageClickEventArgs e)
    {

        Response.Redirect("~/MainForm/Default.aspx");
       
    }
}
