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

public partial class UserControls_Bulliten_Grid_Page : System.Web.UI.UserControl
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
                Response.Redirect("~\\MainForm\\Default.aspx");
            }

           

        }


    }






    private void Load_Grid()
    {



        string today = CDataConverter.ConvertDateTimeNowRtrnString();
        int group = CDataConverter.ConvertToInt(Session_CS.group_id.ToString());
        int parent = CDataConverter.ConvertToInt(Session_CS.parent_id.ToString());
        int pmp = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());


        DataTable dt_Bulliten_new = new DataTable();

        DataTable dt_Bulliten_closed = new DataTable();
        DataTable dt_Bulliten_All = new DataTable();

        
       
        
        
        

        tbl_grd.Visible = true;
        ///////////////////////////////////////////////////////////////////////////////////////////////////////



        if (Request["Type"].ToString() == "newBulliten")
        {
            dt_Bulliten_new = Bulliten_View.new_bulliten(CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()), 1);
           
            gvMain.Visible = true; 
            gvMain.DataSource = dt_Bulliten_new;
            gvMain.DataBind();
            lblMain.Text = "قائمة النشرات الجديدة";
        }

        else if (Request["Type"].ToString() == "AllBulliten")
        {

            dt_Bulliten_All = Bulliten_View.new_bulliten_review();
            gvMain.Visible = true;
            gvMain.DataSource = dt_Bulliten_All;
            gvMain.DataBind();
            lblMain.Text = "قائمة النشرات";
        }





        else if (Request["Type"].ToString() == "closedBulliten")
        {
            dt_Bulliten_closed = Bulliten_View.closed_bulliten(CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()), 3);
            gvMain.Visible = true;
            gvMain.DataSource = dt_Bulliten_closed;
            gvMain.DataBind();


            lblMain.Text = "قائمة النشرات المنتهية";
        }
       



    }

   
   
  
    
   

   
    protected void gvMain_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvMain.PageIndex = e.NewPageIndex;
        Load_Grid();
    }
  
    protected void gvMain_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "show_Bulliten_Details")
        {
            if (Request["Type"].ToString() == "newBulliten")
            {
                Review_DB.update_Review_Track_Emp(e.CommandArgument.ToString(), Session_CS.pmp_id.ToString(), 3, 1);

                Response.Redirect("ViewProjectReview.aspx?id=" + e.CommandArgument);
            }
            else if (Request["Type"].ToString() == "AllBulliten" || Request["Type"].ToString() == "closedBulliten")
            {

                Response.Redirect("ViewProjectReview.aspx?id=" + e.CommandArgument);
            }
           
        }

    }
    protected void ImgBtnBack_Click(object sender, System.Web.UI.ImageClickEventArgs e)
    {

        Response.Redirect("~/MainForm/Default.aspx");
       
    }
}
