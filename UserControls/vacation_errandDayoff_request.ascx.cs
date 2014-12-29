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

public partial class UserControls_vacation_errandDayoff_request : System.Web.UI.UserControl
{
    Session_CS Session_CS = new Session_CS();
    private string sql_Connection = Database.ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtStartDate.Text = CDataConverter .ConvertDateTimeNowRtrnString();
            txtEndDate.Text = CDataConverter.ConvertDateTimeNowRtrnString();
            if (Request["vacation_id"] != null && Request["vacation_id"] != "")
                FillControls(Request.QueryString["vacation_id"]);
        }
    }
    private void FillControls(string vacation_id)
    {
        //vac_id.Value = vacation_id;
        //DataTable vac_DT = Vacations_errand_DB.Select_Vac_By_ID(CDataConverter.ConvertToInt(vacation_id));
        //if (vac_DT.Rows.Count > 0)
        //{
        //    location.Text = vac_DT.Rows[0]["location"].ToString();
        //    person_to_meet.Text = vac_DT.Rows[0]["person_to_meet"].ToString();
        //    start_hour.SelectedValue = vac_DT.Rows[0]["start_hour"].ToString();
        //    purpose.Text = vac_DT.Rows[0]["purpose"].ToString();
        //    notes.Text = vac_DT.Rows[0]["notes"].ToString();
        //    end_hour.SelectedValue = vac_DT.Rows[0]["end_hour"].ToString();
        //    Smrt_Srch_user.SelectedValue = vac_DT.Rows[0]["user_id"].ToString();
        //    Smrt_Srch_alter.SelectedValue = vac_DT.Rows[0]["alternative_user_id"].ToString();
        //    txtStartDate.Text = vac_DT.Rows[0]["start_date"].ToString();
        //    txtEndDate.Text = vac_DT.Rows[0]["end_date"].ToString();
        //}
    }
    protected override void OnInit(EventArgs e)
    {
        Smrt_Srch_user.sql_Connection = sql_Connection;
        //Smrt_Srch_user.Query = "select PMP_ID,pmp_name from EMPLOYEE where ( vacation_mng_pmp_id=" + Session_CS.vacation_mng.ToString() + " or PMP_ID=" + Session_CS.vacation_mng.ToString() + " or vacation_mng_pmp_id=" + Session_CS.pmp_id.ToString() + ")";
        string Query = "select PMP_ID,pmp_name from EMPLOYEE where ( vacation_mng_pmp_id=" + Session_CS.vacation_mng.ToString() + " or PMP_ID=" + Session_CS.vacation_mng.ToString() + " or vacation_mng_pmp_id=" + Session_CS.pmp_id.ToString() + ")";
        Smrt_Srch_user.datatble = General_Helping.GetDataTable(Query);
        Smrt_Srch_user.Value_Field = "PMP_ID";
        Smrt_Srch_user.Text_Field = "pmp_name";
        Smrt_Srch_user.DataBind();

        //Smrt_Srch_alter.sql_Connection = sql_Connection;
        //Smrt_Srch_alter.Query = "select PMP_ID,pmp_name from EMPLOYEE";
        //Smrt_Srch_alter.Value_Field = "PMP_ID";
        //Smrt_Srch_alter.Text_Field = "pmp_name";
        //Smrt_Srch_alter.DataBind();

        base.OnInit(e);
    }
    public static void ShowAlertMessage(string error)
    {

        Page page = HttpContext.Current.Handler as Page;
        if (page != null)
        {
            error = error.Replace("'", "\'");
            ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('" + error + "');", true);
        }
    }

    protected void BtnVacationRequest_Click(object sender, EventArgs e)
    {
        if (CheckValidate())
        {
            Vacations_errand_DT VacObj = new Vacations_errand_DT();
            VacObj.vacation_id = CDataConverter.ConvertToInt("0");
            VacObj.user_id = CDataConverter.ConvertToInt(Smrt_Srch_user.SelectedValue);
            //VacObj.alternative_user_id = CDataConverter.ConvertToInt(Smrt_Srch_alter.SelectedValue);
            VacObj.request_user_id = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
            VacObj.start_date = txtStartDate.Text;
            VacObj.end_date = txtEndDate.Text;
           // VacObj.location = location.Text;
            VacObj.purpose = purpose.Text;
            //VacObj.person_to_meet = person_to_meet.Text;
            VacObj.notes = notes.Text;
            VacObj.start_hour = start_hour.SelectedValue;
            VacObj.end_hour = end_hour.SelectedValue;
            VacObj.no_days = 0;
            VacObj.day_off = ChkdayOff.Checked;
            VacObj.id = CDataConverter.ConvertToInt(vac_id.Value);
            //if (Session_CS.is_vacation_mng.ToString() == "1")
            //{
            //    VacObj.general_manager_approve = 1;
            //    VacObj.manager_approve = 1;
            //}
            //else
            //{
                VacObj.general_manager_approve = 0;
                VacObj.manager_approve = 0;
           // }


                VacObj.request_date = CDataConverter.ConvertDateTimeToFormatdmy(CDataConverter.ConvertDateTimeNowRtnDt());
            if (Session_CS.dept_id.ToString() != "")
                VacObj.dept_id = CDataConverter.ConvertToInt(Session_CS.dept_id.ToString());
            int result = Vacations_errand_DB.Save(VacObj);
            Response.Redirect("vacations_errand.aspx");
        }
    }

    private bool CheckValidate()
    {
        bool isValid = true;
        if (!(txtStartDate.Text.Trim() != "" && txtEndDate.Text.Trim() != ""))
        {
            isValid = false;
            lblPageStatus.Visible = true;
            lblPageStatus.Text = "ادخل تاريخ بداية ونهاية المأمورية بشكل صحيح";
            goto returnPart;
        }
        else if (!(VB_Classes.Dates.Dates_Operation.Date_compare(txtEndDate.Text.Trim(), txtStartDate.Text.Trim())))
        {
            isValid = false;
            lblPageStatus.Visible = true;
            lblPageStatus.Text = "تاريخ بداية المأمورية أكبر من تاريخ النهاية";
            goto returnPart;
        }
        if (txtStartDate.Text == "" || txtEndDate.Text == "")
        {
            isValid = false;
            lblPageStatus.Visible = true;
            lblPageStatus.Text = "ادخل تاريخ بداية ونهاية المأمورية";
            goto returnPart;
        }
        DataTable VacExist = General_Helping.GetDataTable("select id from Vacations_errand where user_id=" + Smrt_Srch_user.SelectedValue + " AND" + " id <> " + vac_id.Value + " AND" +
           "((convert(datetime, '" + txtStartDate.Text + "',103) between convert(datetime, start_date,103) and convert(datetime, end_date,103)) OR " +
           "(convert(datetime, '" + txtEndDate.Text + "',103) between convert(datetime, start_date,103) and convert(datetime, end_date,103)))  ");
        DataTable VacExist2 = new DataTable();
        if (vac_id.Value != "0")
        {
            VacExist2 = General_Helping.GetDataTable("select id from Vacations_users where user_id=" + Smrt_Srch_user.SelectedValue + " AND" +
                "((convert(datetime, '" + txtStartDate.Text + "',103) between convert(datetime, start_date,103) and convert(datetime, end_date,103)) OR " +
                "(convert(datetime, '" + txtEndDate.Text + "',103) between convert(datetime, start_date,103) and convert(datetime, end_date,103)))  ");
        }
        else
        {
            VacExist2 = General_Helping.GetDataTable("select id from Vacations_users where user_id=" + Smrt_Srch_user.SelectedValue + " AND" +
                "((convert(datetime, '" + txtStartDate.Text + "',103) between convert(datetime, start_date,103) and convert(datetime, end_date,103)) OR " +
                "(convert(datetime, '" + txtEndDate.Text + "',103) between convert(datetime, start_date,103) and convert(datetime, end_date,103)))  ");

        }
    //if (VacExist.Rows.Count > 0 || VacExist2.Rows.Count > 0)
    //{
    //    lblPageStatus.Visible = true;
    //    lblPageStatus.Text = "يوجد مأمورية أخرى فى نفس الفترة";
    //    isValid = false;
    //}
    returnPart:
        return isValid;
    }
}
