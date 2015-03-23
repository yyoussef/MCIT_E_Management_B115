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
using System.Data.SqlClient;

public partial class UserControls_vacations : System.Web.UI.UserControl
{
    private string sql_Connection = Database.ConnectionString;
    //Session_CS Session_CS = new Session_CS();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            FillGrids();
      
            BtnRequests.Visible = true;
       
        //if (CDataConverter.ConvertToInt(Session_CS.group_id.ToString()) == 3)
        //{//vacations.Columns[4].Visible = false;
        //}
        //else 
       // { 
            vacations.Columns[2].Visible = false;
        //}
    }
    private void FillGrids()
    {
        int curYear = CDataConverter.ConvertDateTimeNowRtnDt().Year ;
        SqlParameter[] sqlParams = new SqlParameter[] { new SqlParameter("@id",CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString())), 
                                    new SqlParameter("@year", curYear)};
        Vacations_DT VacObj = new Vacations_DT();

        DataTable AllVacDT = Vacations_DB.SelectAll(sqlParams);
        DataTable VacDT = Vacations_DB.SelectAll_by_user_id2(CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()),curYear );
        vacations.DataSource = VacDT;
        vacations.DataBind();
        requests.DataSource = AllVacDT;
        requests.DataBind();
    }
    protected void BtnVacationRequest_Click(object sender, EventArgs e)
    {
        Response.Redirect("vacation_request.aspx");
    }
    protected void BtnRequests_Click(object sender, EventArgs e)
    {
        Response.Redirect("vacations_manager.aspx");
    }
    protected void requests_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //VocStatus ,manager_approve,general_manager_approve
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string GMApprove = (string)Convert.ToString(DataBinder.Eval(e.Row.DataItem, "general_manager_approve"));
            string MApprove = (string)Convert.ToString(DataBinder.Eval(e.Row.DataItem, "manager_approve"));
            string Type = (string)Convert.ToString(DataBinder.Eval(e.Row.DataItem, "type"));
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
               // if (Type == "0")
               // {
                    imgEdit.Visible = true;
                    imgDelete.Visible = true;
              //  }
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
            Response.Redirect("vacation_request.aspx?vacation_id=" + e.CommandArgument);
        }

        if (e.CommandName == "RemoveItem")
        {
            int result = General_Helping.ExcuteQuery("delete from Vacations_users where id=" + e.CommandArgument);
        }
        FillGrids();
    }
}
