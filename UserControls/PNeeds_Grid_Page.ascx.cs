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

public partial class UserControls_PNeeds_Grid_Page : System.Web.UI.UserControl
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
           


        }


    }






    private void Load_Grid()
    {
        
        int pmp = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());

        DataTable dt_need_Approved = new DataTable();
        DataTable dt_need_available_recievable = new DataTable();
      
        if (Request["Type"].ToString() == "needapproved")
        {
            dt_need_Approved = Needs_class.Needs_Approved(pmp);
           
            gvMain.Visible = true;
            gvMain.DataSource = dt_need_Approved;
            gvMain.DataBind();
            lblMain.Text = "قائمة المشروعات التى لها طلبات مصدق عليها";
        }
        if (Request["Type"].ToString() == "needRecievable")
        {

            dt_need_available_recievable = Needs_class.Needs_Available_Recievable(pmp);

            gvMain.Visible = true;
            gvMain.DataSource = dt_need_available_recievable;
            gvMain.DataBind();
            lblMain.Text = "قائمة المشروعات التى لها إتاحة وتحتاج صرف";
        }
      
       
     

    }

   
  
   
   

   
    protected void gvMain_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvMain.PageIndex = e.NewPageIndex;
        Load_Grid();
    }
  
    protected void gvMain_RowCommand(object sender, GridViewCommandEventArgs e)
    {
       // SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        if (e.CommandName == "Show")
        {
            Session_CS.Project_id = CDataConverter.ConvertToInt( e.CommandArgument.ToString());
            if (Request["Type"].ToString() == "needapproved")
            {
                Response.Redirect("Needs_Approvment.aspx?mode=1");
 
            }
            else if (Request["Type"].ToString() == "needRecievable")
            {
                Response.Redirect("Need_Recieve.aspx?mode=1");
            }
           
        }



    }
    protected void ImgBtnBack_Click(object sender, System.Web.UI.ImageClickEventArgs e)
    {
        Response.Redirect("~/MainForm/Default.aspx");
    }
}
