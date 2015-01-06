using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class WebForms_Vacation_Mng_ALL_User : System.Web.UI.Page
{
    //Session_CS Session_CS = new Session_CS();
    private string sql_Connection = Database.ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnInit(EventArgs e)
    {


        Smrt_Srch_user.sql_Connection = sql_Connection;
        string Query = "select PMP_ID,pmp_name from EMPLOYEE";
        Smrt_Srch_user.datatble = General_Helping.GetDataTable(Query); 
        Smrt_Srch_user.Value_Field = "PMP_ID";
        Smrt_Srch_user.Text_Field = "pmp_name";
        Smrt_Srch_user.DataBind();
        this.Smrt_Srch_user.Value_Handler += new Smart_Search.Delegate_Selected_Value(MOnMember_Data);
        base.OnInit(e);
    }

    private void MOnMember_Data(string Value)
    {
        if (CDataConverter.ConvertToInt(Value) > 0)
        {
            Fill_Grid();
            Vacations_summary_DT obj = Vacations_summary_DB.SelectBy_Emp_ID(CDataConverter.ConvertToInt(Value));
            if (obj.id > 0)
            {
                txt_exhibitor.Text = obj.exhibitor.ToString();
                txt_sick.Text = obj.sick.ToString();
                txt_unusual.Text = obj.unusual.ToString();
            }
            else
            {
                string sql = " select * from  Vacations ";
                DataTable dt = General_Helping.GetDataTable(sql);
                if (dt.Rows.Count > 0)
                {
                    txt_exhibitor.Text = dt.Rows[1]["vacation_days"].ToString();
                    txt_sick.Text = dt.Rows[2]["vacation_days"].ToString();
                    txt_unusual.Text = dt.Rows[0]["vacation_days"].ToString();
                }

                // create field for user in vacation summary

            }
        }
    }

    protected void BtnVacationRequest_Click(object sender, EventArgs e)
    {
        if (CheckValidate())
        {
            Vacations_DT VacObj = new Vacations_DT();
            VacObj.vacation_id = CDataConverter.ConvertToInt(DDLVacationType.SelectedValue);
            VacObj.user_id = CDataConverter.ConvertToInt(Smrt_Srch_user.SelectedValue);
            VacObj.alternative_user_id = CDataConverter.ConvertToInt(Smrt_Srch_user.SelectedValue); ;
            VacObj.request_user_id = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
            VacObj.start_date = txtStartDate.Text;
            VacObj.end_date = txtEndDate.Text;
            VacObj.no_days = CDataConverter.ConvertToInt(no_days.Text);
            VacObj.manager_approve = 1;
            VacObj.general_manager_approve = 1;
            VacObj.request_date = VacObj.start_date;
            VacObj.dept_id = 0;
            int result = Vacations_DB.Save(VacObj);
            if (result > 0)
            {
                Fill_Grid();
                Clear_Cntrl();
                Vacations_DB.vacation_summary(CDataConverter.ConvertToInt(result));
                MOnMember_Data(Smrt_Srch_user.SelectedValue);
                Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم الحفظ بنجاح')</script>");
            }
        }
    }

    private void Fill_Grid()
    {
        if (CDataConverter.ConvertToInt(Smrt_Srch_user.SelectedValue) > 0)
        {
            string sql = " SELECT     Vacations.vacation_title, Vacations_users.start_date, Vacations_users.end_date, Vacations_users.no_days, Vacations_users.user_id " +
                         " FROM         Vacations INNER JOIN                       Vacations_users ON Vacations.id = Vacations_users.vacation_id " +
                         "where user_id=" + Smrt_Srch_user.SelectedValue;

            GridView_Main.DataSource = General_Helping.GetDataTable(sql);
            GridView_Main.DataBind();
        }
        
    }

    private void Clear_Cntrl()
    {
        txtStartDate.Text =
        txtEndDate.Text =
        no_days.Text = "";
    }

    protected void GridView_Main_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView_Main.PageIndex = e.NewPageIndex;
        Fill_Grid();
        
    }

    private bool CheckValidate()
    {
        bool isValid = true;
        if (!(txtStartDate.Text.Trim() != "" && txtEndDate.Text.Trim() != ""))

          //  if (!(VB_Classes.Dates.Dates_Operation.date_validate(txtStartDate.Text.Trim()) != "" && VB_Classes.Dates.Dates_Operation.date_validate(txtEndDate.Text.Trim()) != ""))

        
        {
            isValid = false;
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('ادخل تاريخ بداية ونهاية الأجازة بشكل صحيح')</script>");

            goto returnPart;
        }
        else if (!(VB_Classes.Dates.Dates_Operation.Date_compare(txtEndDate.Text.Trim(), txtStartDate.Text.Trim())))
        {
            isValid = false;
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('تاريخ بداية الأجازة أكبر من تاريخ النهاية')</script>");

            goto returnPart;
        }
        else
        {
            int vacation_days;
            DateTime start_date = CDataConverter.ConvertToDate(txtStartDate.Text.Trim());
            DateTime end_date = CDataConverter.ConvertToDate(txtEndDate.Text.Trim());
            //DateTime start_date = CDataConverter.ConvertToDate(VB_Classes.Dates.Dates_Operation.date_validate(txtStartDate.Text.Trim()));
            //DateTime end_date = CDataConverter.ConvertToDate(VB_Classes.Dates.Dates_Operation.date_validate(txtEndDate.Text.Trim()));

            TimeSpan diff_days = end_date.Subtract(start_date);
            vacation_days = diff_days.Days + 1;
            no_days.Text = vacation_days.ToString();
        }
        if (CDataConverter.ConvertToInt(no_days.Text) <= 0)
        {
            isValid = false;
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('عدد الايام يجب ان يكون رقم صحيح')</script>");
            goto returnPart;
        }
        if (txtStartDate.Text == "" || txtEndDate.Text == "")
        {
            isValid = false;
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('ادخل تاريخ بداية ونهاية الأجازة')</script>");
            
            goto returnPart;
        }

        int curYear = CDataConverter.ConvertDateTimeNowRtnDt().Year;
        string vacation_repeat = "";
        string field_name = "";
        if (CDataConverter.ConvertToInt(DDLVacationType.SelectedValue) > 0 && CDataConverter.ConvertToInt(DDLVacationType.SelectedValue) < 4)
        {
            vacation_repeat = "yearly";
            //repeat
            switch (CDataConverter.ConvertToInt(DDLVacationType.SelectedValue))
            {
                case 1:
                    field_name = "unusual";
                    break;
                case 2:
                    field_name = "exhibitor";
                    break;
                case 3:
                    field_name = "sick";
                    break;
            }
        }
        else if (CDataConverter.ConvertToInt(DDLVacationType.SelectedValue) == 5)
        {
            vacation_repeat = "once";
            field_name = "hajj";
        }
        else if (CDataConverter.ConvertToInt(DDLVacationType.SelectedValue) == 6)
        {
            vacation_repeat = "3times";
            field_name = "birth";
        }
        SqlParameter[] sqlParams = new SqlParameter[] { new SqlParameter("@user_id", Smrt_Srch_user.SelectedValue), 
                                    new SqlParameter("@vac_id", CDataConverter.ConvertToInt(DDLVacationType.SelectedValue)), 
                                    new SqlParameter("@year", curYear.ToString()),
                                    new SqlParameter("@vacation_repeat", vacation_repeat.ToString()),
                                    new SqlParameter("@field", field_name.ToString())};
        DataTable BalanceDT = General_Helping.GetDataTable("SELECT " + field_name.ToString() + " AS remaining FROM Vacations_summary WHERE emp_id = " + Smrt_Srch_user.SelectedValue);





        if (BalanceDT.Rows.Count > 0)
        {
            int uu = CDataConverter.ConvertToInt(BalanceDT.Rows[0]["remaining"].ToString());
            switch (vacation_repeat)
            {
                case "yearly":
                    if ((CDataConverter.ConvertToInt(BalanceDT.Rows[0]["remaining"].ToString()) - CDataConverter.ConvertToInt(no_days.Text)) < 0)
                    {
                        Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('عدد الأيام أكبر من الرصيد المتبقى')</script>");
                        isValid = false;
                    }
                    break;
                case "once":
                    if (CDataConverter.ConvertToInt(BalanceDT.Rows[0]["remaining"].ToString()) > 0)
                    {
                        Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد استنفذت هذا النوع من الأجازات')</script>");
                        isValid = false;
                    }
                    break;
                case "3times":
                    if (CDataConverter.ConvertToInt(BalanceDT.Rows[0]["remaining"].ToString()) == 3)
                    {
                        Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد استنفذت هذا النوع من الأجازات')</script>");
                        isValid = false;
                    }
                    break;
            }
        }
        else
        {
            BalanceDT.Clear();
            BalanceDT = Vacations_DB.get_vacation_limit(CDataConverter.ConvertToInt(DDLVacationType.SelectedValue));
            if (BalanceDT.Rows.Count > 0)
            {
                if ((CDataConverter.ConvertToInt(BalanceDT.Rows[0]["vacation_days"].ToString()) - CDataConverter.ConvertToInt(no_days.Text)) < 0)
                {
                    Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('عدد الأيام أكبر من الرصيد المتبقى')</script>");
                    
                    isValid = false;
                }
            }
        }

    returnPart:
        return isValid;
    }

    protected void txtEndDate_TextChanged(object sender, EventArgs e)
    {
        if (!(txtStartDate.Text.Trim() != "" &&txtEndDate.Text.Trim() != ""))

         //   if (!(VB_Classes.Dates.Dates_Operation.date_validate(txtStartDate.Text.Trim()) != "" && VB_Classes.Dates.Dates_Operation.date_validate(txtEndDate.Text.Trim()) != ""))

        
        {

        }
        else if (!(VB_Classes.Dates.Dates_Operation.Date_compare(txtEndDate.Text.Trim(), txtStartDate.Text.Trim())))
        {

        }
        else
        {
            int vacation_days;
            //DateTime start_date = CDataConverter.ConvertToDate(VB_Classes.Dates.Dates_Operation.date_validate(txtStartDate.Text.Trim()));
            //DateTime end_date = CDataConverter.ConvertToDate(VB_Classes.Dates.Dates_Operation.date_validate(txtEndDate.Text.Trim()));

            DateTime start_date = CDataConverter.ConvertToDate(txtStartDate.Text.Trim());
            DateTime end_date = CDataConverter.ConvertToDate(txtEndDate.Text.Trim());

            TimeSpan diff_days = end_date.Subtract(start_date);
            vacation_days = diff_days.Days + 1;
            no_days.Text = vacation_days.ToString();
        }
    }
}
