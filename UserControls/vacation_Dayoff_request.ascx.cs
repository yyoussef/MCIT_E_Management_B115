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

public partial class UserControls_vacation_Dayoff_request : System.Web.UI.UserControl
{

    string InsideMCIT = System.Configuration.ConfigurationManager.AppSettings["InsideMCIT"].ToString();
    Session_CS Session_CS = new Session_CS();
    private string sql_Connection = Database.ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //txtStartDate.Text = DateTime.Today.ToShortDateString();
            //txtEndDate.Text = DateTime.Today.ToShortDateString();

           // DateTime str = System.DateTime.Now;
            txtStartDate.Text = CDataConverter.ConvertDateTimeNowRtrnString();
            txtEndDate.Text = CDataConverter.ConvertDateTimeNowRtrnString();

            if (Request["vacation_id"] != null && Request["vacation_id"] != "")
                FillControls(Request.QueryString["vacation_id"]);
            else
                Smrt_Srch_user.SelectedValue = Session_CS.pmp_id.ToString();
        }
    }
    private void FillControls(string vacation_id)
    {
        vac_id.Value = vacation_id;
        DataTable vac_DT = Vacations_Dayoff_DB.Select_VacOff_By_ID(CDataConverter.ConvertToInt(vacation_id));
        if (vac_DT.Rows.Count > 0)
        {

            start_hour.SelectedValue = vac_DT.Rows[0]["start_hour"].ToString();
            purpose.Text = vac_DT.Rows[0]["purpose"].ToString();
            notes.Text = vac_DT.Rows[0]["notes"].ToString();
            end_hour.SelectedValue = vac_DT.Rows[0]["end_hour"].ToString();
            Smrt_Srch_user.SelectedValue = vac_DT.Rows[0]["user_id"].ToString();
            txtStartDate.Text = vac_DT.Rows[0]["start_date"].ToString();
            txtEndDate.Text = vac_DT.Rows[0]["end_date"].ToString();

            hidden_StartDate.Value = txtStartDate.Text;
            hidden_EndDate.Value = txtEndDate.Text;
        }
    }

    private void Clear_cntrol()
    {
        vac_id.Value =
        txtStartDate.Text =
            txtEndDate.Text =
              purpose.Text =
            notes.Text =
            hidden_StartDate.Value =
            hidden_EndDate.Value = "";

        Smrt_Srch_user.Clear_Selected();


    }


    protected override void OnInit(EventArgs e)
    {
        Smrt_Srch_user.sql_Connection = sql_Connection;
        //if (CDataConverter.ConvertToInt(Session_CS.group_id.ToString()) == 3)
        //{
        //    Smrt_Srch_user.Query = "select PMP_ID,pmp_name,group_id from EMPLOYEE where group_id = 3";
        //}
        //else
        //{
            //Smrt_Srch_user.Query = "select PMP_ID,pmp_name from EMPLOYEE where ( vacation_mng_pmp_id=" + Session_CS.vacation_mng.ToString() + " or PMP_ID=" + Session_CS.vacation_mng.ToString() + " or vacation_mng_pmp_id=" + Session_CS.pmp_id.ToString() + ")";
           // Smrt_Srch_user.Query = "SELECT     EMPLOYEE.PMP_ID, EMPLOYEE.pmp_name, Departments.sec_sec_id FROM         EMPLOYEE INNER JOIN                      Departments ON EMPLOYEE.Dept_Dept_id = Departments.Dept_ID where Departments.sec_sec_id =1";

           // Smrt_Srch_user.Query = "SELECT     EMPLOYEE.PMP_ID, EMPLOYEE.pmp_name, Departments.sec_sec_id FROM         EMPLOYEE INNER JOIN                      Departments ON EMPLOYEE.Dept_Dept_id = Departments.Dept_ID where  Departments.sec_sec_id =" + CDataConverter.ConvertToInt(Session_CS.sec_id.ToString());
        string Query = "SELECT     EMPLOYEE.PMP_ID, EMPLOYEE.pmp_name, Departments.sec_sec_id FROM         EMPLOYEE INNER JOIN                      Departments ON EMPLOYEE.Dept_Dept_id = Departments.Dept_ID where EMPLOYEE.foundation_id='" + Session_CS.foundation_id + "' and  Departments.sec_sec_id ='" + CDataConverter.ConvertToInt(Session_CS.sec_id.ToString()) + "' and EMPLOYEE.workstatus=1 ORDER BY LTRIM(pmp_name)";
            if (InsideMCIT == "1")
            {
                if (CDataConverter.ConvertToInt(Session_CS.group_id.ToString()) == 3)
                {
                    Query = "SELECT     EMPLOYEE.PMP_ID, EMPLOYEE.pmp_name, Departments.sec_sec_id FROM         EMPLOYEE INNER JOIN                      Departments ON EMPLOYEE.Dept_Dept_id = Departments.Dept_ID where EMPLOYEE.foundation_id='" + Session_CS.foundation_id + "' and   Departments.sec_sec_id ='" + CDataConverter.ConvertToInt(Session_CS.sec_id.ToString()) + "' and EMPLOYEE.workstatus=1 and group_id=3 ORDER BY LTRIM(pmp_name)";

                }

            }

       // }
            Smrt_Srch_user.datatble = General_Helping.GetDataTable(Query);
        Smrt_Srch_user.Value_Field = "PMP_ID";
        Smrt_Srch_user.Text_Field = "pmp_name";
        //Smrt_Srch_user.Orderby = "";
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
        lblPageStatus.Visible = true;
        lblPageStatus.Text = "";
        if (CheckValidate())
        {

            DateTime one;
            DateTime dtone;
            DateTime dtone2;
            Vacations_Dayoff_DT VacObj = new Vacations_Dayoff_DT();
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
            dtone = CDataConverter.ConvertToDate(txtStartDate.Text);
            dtone2 = CDataConverter.ConvertToDate(txtEndDate.Text);
            int i = dtone2.Subtract(dtone).Days + 1;
            VacObj.no_days = i;
            VacObj.id = CDataConverter.ConvertToInt(vac_id.Value);
            //if (Session_CS.is_vacation_mng.ToString() == "1")
            //{
            //    VacObj.general_manager_approve = 1;
            //    VacObj.manager_approve = 1;
            //    General_Helping.ExcuteQuery("update Vacations_summary set day_off_no = ISNULL(day_off_no, 0)  + " + VacObj.no_days + " where emp_id=" + VacObj.user_id);
            //}
            //else
            //{
                VacObj.general_manager_approve = 0;
                VacObj.manager_approve = 0;
           // }


                VacObj.request_date = CDataConverter.ConvertDateTimeToFormatdmy(CDataConverter.ConvertDateTimeNowRtnDt());
            if (Session_CS.dept_id.ToString() != "")
                VacObj.dept_id = CDataConverter.ConvertToInt(Session_CS.dept_id.ToString());
            int result = Vacations_Dayoff_DB.Save(VacObj);
            Clear_cntrol();
            //Response.Redirect("vacations_DayOff.aspx");
            ShowAlertMessage("لقد تم الحفظ بنجاح");
        }
    }

    private bool CheckValidate()
    {
        bool isValid = true;
        if (!(VB_Classes.Dates.Dates_Operation.date_validate(txtStartDate.Text.Trim()) != "" && VB_Classes.Dates.Dates_Operation.date_validate(txtEndDate.Text.Trim()) != ""))
        {
            isValid = false;
            lblPageStatus.Visible = true;
            lblPageStatus.Text = "ادخل تاريخ بداية ونهاية بشكل صحيح";
            goto returnPart;
        }
        else if (!(VB_Classes.Dates.Dates_Operation.Date_compare(txtEndDate.Text.Trim(), txtStartDate.Text.Trim())))
        {
            isValid = false;
            lblPageStatus.Visible = true;
            lblPageStatus.Text = "تاريخ البداية أكبر من تاريخ النهاية";
            goto returnPart;
        }
        if (txtStartDate.Text == "" || txtEndDate.Text == "")
        {
            isValid = false;
            lblPageStatus.Visible = true;
            lblPageStatus.Text = "ادخل تاريخ البداية والنهاية ";
            goto returnPart;
        }

        DataTable Dt_Vac_Valid = Vacations_DB.Check_DT_Valid(txtStartDate.Text, txtEndDate.Text, CDataConverter.ConvertToInt(Smrt_Srch_user.SelectedValue));
        if (Dt_Vac_Valid.Rows.Count > 0)
        {
            lblPageStatus.Visible = true;
            lblPageStatus.Text = "يوجد أجازة أخرى فى نفس الفترة";
            isValid = false;
        }

        DataTable Dt_errnd_Valid = Vacations_errand_DB.Check_DT_Valid(txtStartDate.Text, txtEndDate.Text, CDataConverter.ConvertToInt(Smrt_Srch_user.SelectedValue));
        if (Dt_errnd_Valid.Rows.Count > 0)
        {
            lblPageStatus.Visible = true;
            lblPageStatus.Text = "يوجد مأمورية فى نفس الفترة";
            isValid = false;
        }

        if (string.IsNullOrEmpty(vac_id.Value) || hidden_StartDate.Value != txtStartDate.Text || hidden_EndDate.Value != txtEndDate.Text)
        {
            DataTable Dt_Vac_Valid2 = Vacations_Dayoff_DB.Check_DT_Valid(txtStartDate.Text, txtEndDate.Text, CDataConverter.ConvertToInt(Smrt_Srch_user.SelectedValue));
            if (Dt_Vac_Valid2.Rows.Count > 0)
            {
                lblPageStatus.Visible = true;
                lblPageStatus.Text = "يوجد طلب راحة فى نفس الفترة";
                isValid = false;
            }
        }

    returnPart:
        return isValid;
    }
}
