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

public partial class UserControls_PNeedsUserControl : System.Web.UI.UserControl
{
    //Session_CS Session_CS = new Session_CS();
    protected void Page_Load(object sender, EventArgs e)
    {
        loadgrid();
        Show_Hide_Catagerios_inbox();
    }
    private void loadgrid()
    {
        int pmp = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());

        DataTable dt_need_no_approve = new DataTable();
        DataTable dt_need_no_available= new DataTable();
        DataTable dt_need_recieved = new DataTable();
        DataTable dt_need_Approved = new DataTable();
        DataTable dt_need_available_recievable = new DataTable();



        dt_need_no_approve = Needs_class.Needs_No_Approve();
        dt_need_no_available = Needs_class.Needs_No_Available();
        dt_need_recieved = Needs_class.Needs_Recieved();
        dt_need_Approved = Needs_class.Needs_Approved(pmp);
        dt_need_available_recievable = Needs_class.Needs_Available_Recievable(pmp);
        if (CDataConverter.ConvertToInt(Session_CS.UROL_UROL_ID) == 4 || CDataConverter.ConvertToInt(Session_CS.UROL_UROL_ID) == 3)
        {
            trNeeds_Recieve_2.Visible = false;
            trNeedsNoAvailable_2.Visible = false;
            trNeedsNoApproving_2.Visible = false;

            tr_needs_approved.Visible = true;
            tr_Needs_Available_Recievable.Visible = true;
        }
        else if (CDataConverter.ConvertToInt(Session_CS.UROL_UROL_ID) == 2)
        {
            trNeeds_Recieve_2.Visible = true;
            trNeedsNoAvailable_2.Visible = true;
            trNeedsNoApproving_2.Visible = true;

            tr_needs_approved.Visible = false;
            tr_Needs_Available_Recievable.Visible = false;
        }
        else
        {
            trNeeds_Recieve_2.Visible = false;
            trNeedsNoAvailable_2.Visible = false;
            trNeedsNoApproving_2.Visible = false;
            tr_needs_approved.Visible = false;
            tr_Needs_Available_Recievable.Visible = false;
        }
     
        lnkNeedsNoApprovingNo_2.Text = dt_need_no_approve.Rows.Count.ToString();
        lnkNeedsNo_Available_2.Text = dt_need_no_available.Rows.Count.ToString();
        lnkNeeds_Recieve_2.Text = dt_need_recieved.Rows.Count.ToString();
        lbtnProj_Approve_Needs.Text = dt_need_Approved.Rows.Count.ToString();
        lbtn_project_Available.Text = dt_need_available_recievable.Rows.Count.ToString();
       
    }
    void Show_Hide_Catagerios_inbox()
    {
        if (CDataConverter.ConvertToInt(Session_CS.UROL_UROL_ID) == 2)
        {

            if (CDataConverter.ConvertToInt(lnkNeedsNoApprovingNo_2.Text) > 0 || CDataConverter.ConvertToInt(lnkNeedsNo_Available_2.Text) > 0 || CDataConverter.ConvertToInt(lnkNeeds_Recieve_2.Text) > 0)
            {

                lbl_needs.ForeColor = System.Drawing.Color.Red;
            }
        }

        if (CDataConverter.ConvertToInt(lnkNeeds_Recieve_2.Text) > 0)
            td_lnkNeeds_Recieve_2.BgColor = "#FCFBB2";
        if (CDataConverter.ConvertToInt(lnkNeedsNo_Available_2.Text) > 0)
            td_lnkNeedsNo_Available_2.BgColor = "#FCFBB2";
        if (CDataConverter.ConvertToInt(lnkNeedsNoApprovingNo_2.Text) > 0)
            td_lnkNeedsNoApprovingNo_2.BgColor = "#FCFBB2";



    }

    protected void lnkNeedsNoApprovingNo_2_Click(object sender, EventArgs e)
    {
        if (CDataConverter.ConvertToInt(lnkNeedsNoApprovingNo_2.Text) > 0)
        {
            Response.Redirect("Needs_Approvment.aspx");
          
        }
    }
    protected void lbtn_project_Available_Click(object sender, EventArgs e)
    {
        if (CDataConverter.ConvertToInt(lbtn_project_Available.Text) > 0)
        {
            Response.Redirect("PNeeds_Grid_Page.aspx?type=needRecievable");

        }
    }
    protected void lbtnProj_Approve_Needs_Click(object sender, EventArgs e)
    {
        if (CDataConverter.ConvertToInt(lbtnProj_Approve_Needs.Text) > 0)
        {
            Response.Redirect("PNeeds_Grid_Page.aspx?type=needapproved");

        }
    }
    protected void lnkNeedsNo_Available_2_Click(object sender, EventArgs e)
    {
        if (CDataConverter.ConvertToInt(lnkNeedsNo_Available_2.Text) > 0)
        {
            Response.Redirect("Need_Available.aspx");
        }
    }

    protected void lnkNeeds_Recieve_2_Click(object sender, EventArgs e)
    {
        if (CDataConverter.ConvertToInt(lnkNeeds_Recieve_2.Text) > 0)
        {
            Response.Redirect("Need_Recieve.aspx");
        }

    }
}
