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

public partial class UserControls_vacations_Dayoff_old : System.Web.UI.UserControl
{
    private string sql_Connection = Database.ConnectionString;
    //Session_CS Session_CS = new Session_CS();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            FillGrids();
    }

    private void FillGrids()
    {
        Vacations_Dayoff_DT VacObj = new Vacations_Dayoff_DT();
        DataTable AllVacDT = Vacations_Dayoff_DB.Select_old(CDataConverter.ConvertToInt(Session_CS.pmp_id));
        requests.DataSource = AllVacDT;
        requests.DataBind();
    }
    protected void BtnVacationRequest_Click(object sender, EventArgs e)
    {
        Response.Redirect("vacations_dayoff_manager.aspx");
    }
    protected void requests_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditItem")
        {
            Response.Redirect("vacation_Dayoff_request.aspx?edit_type=manage&vacation_id=" + e.CommandArgument);
        }

        if (e.CommandName == "RemoveItem")
        {
            int result = General_Helping.ExcuteQuery("delete from Vacations_users where id=" + e.CommandArgument);
        }
        FillGrids();
    }
}
