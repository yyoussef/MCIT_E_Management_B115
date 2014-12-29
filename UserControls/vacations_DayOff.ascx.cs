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
using System.IO;
using System.Net;

public partial class UserControls_vacations_errand : System.Web.UI.UserControl
{
    private string sql_Connection = Database.ConnectionString;
    Session_CS Session_CS = new Session_CS();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            FillGrids();
        if (Session_CS.UROL_UROL_ID != null && Session_CS.UROL_UROL_ID.ToString() == "3")
            BtnRequests.Visible = true;
    }
    private void FillGrids()
    {
        Vacations_Dayoff_DT VacObj = new Vacations_Dayoff_DT();
        DataTable AllVacDT = Vacations_Dayoff_DB.SelectAll(CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()));
        requests.DataSource = AllVacDT;
        requests.DataBind();
    }
    protected void BtnVacationRequest_Click(object sender, EventArgs e)
    {
        Response.Redirect("vacation_DayOff_request.aspx");
    }
    protected void BtnRequests_Click(object sender, EventArgs e)
    {
        Response.Redirect("vacations_dayoff_manager.aspx");
    }
    protected void requests_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //VocStatus ,manager_approve,general_manager_approve
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string GMApprove = (string)Convert.ToString(DataBinder.Eval(e.Row.DataItem, "general_manager_approve"));
            string MApprove = (string)Convert.ToString(DataBinder.Eval(e.Row.DataItem, "manager_approve"));
            Label VocStat = (Label)e.Row.FindControl("VocStatus");
            if (GMApprove == "1")
            {
                VocStat.Text = "تم الموافقة";
            }
            else if (GMApprove == "2" || MApprove == "2")
            {
                VocStat.Text = "تم الرفض";
            }
            else
            {
                VocStat.Text = "لم تنظر";
                ImageButton imgEdit = (ImageButton)e.Row.FindControl("ImgBtnEdit");
                ImageButton imgDelete = (ImageButton)e.Row.FindControl("ImgBtnDelete");
                imgEdit.Visible = true;
                imgDelete.Visible = true;
            }
        }
    }
    protected void vacations_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void requests_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditItem")
        {
            Response.Redirect("vacation_DayOff_request.aspx?vacation_id=" + e.CommandArgument);
        }

        if (e.CommandName == "RemoveItem")
        {
            int result = General_Helping.ExcuteQuery("delete from Vacations_DayOff where id=" + e.CommandArgument);
        }
        FillGrids();
    }
}
