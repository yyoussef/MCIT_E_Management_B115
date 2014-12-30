
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
using System.Net.Mail;
using System.Text;
using System.IO;

public partial class UserControls_vacation_request : System.Web.UI.UserControl
{
    string InsideMCIT = System.Configuration.ConfigurationManager.AppSettings["InsideMCIT"].ToString();
    int operation;
    private string sql_Connection = Database.ConnectionString;
    int group_id;
    //Session_CS Session_CS = new Session_CS();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            txtStartDate.Text = CDataConverter.ConvertDateTimeNowRtrnString();
            txtEndDate.Text = CDataConverter.ConvertDateTimeNowRtrnString();
            //txtStartDate.Text = DateTime.Today.ToShortDateString();
            //txtEndDate.Text = DateTime.Today.ToShortDateString();

            if (Request["vacation_id"] != null && Request["vacation_id"] != "")
            {
                FillControls(Request.QueryString["vacation_id"]);
                operation = (int)Project_Log_DB.Action.edit;
                Project_Log_DB.FillLog(CDataConverter.ConvertToInt(Request["vacation_id"]), operation, Project_Log_DB.operation.vacations_manage);
            }
            else
            {
                Smrt_Srch_user.SelectedValue = Session_CS.pmp_id.ToString();
                DropVocation_Type();
            }
        }
        //group_id = CDataConverter.ConvertToInt(Session_CS.group_id.ToString()); 

    }
    private void DropVocation_Type()
    {
        group_id = CDataConverter.ConvertToInt(Session_CS.group_id.ToString());
        string sql = "";
        sql = "SELECT id, vacation_title FROM Vacations where active =1";
        DataTable dt = new DataTable();
        dt = General_Helping.GetDataTable(sql);
        DDLVacationType.DataSource = dt;
        DDLVacationType.DataBind();

        ////////////////////check if the system inside MCIT when the value readed from web.config=1  .... then show vacation type Illness/////////////////////


        if (InsideMCIT == "1")
        {
            if (group_id != 3)
            {
                DDLVacationType.Items.RemoveAt(2);

            }
        }

    }
    private void FillControls(string vacation_id)
    {
        vac_id.Value = vacation_id;
        DataTable vac_DT = Vacations_DB.Select_Vac_By_ID(CDataConverter.ConvertToInt(vacation_id));
        if (vac_DT.Rows.Count > 0)
        {
            DropVocation_Type();
            DDLVacationType.SelectedValue = vac_DT.Rows[0]["vacation_id"].ToString();
        }
        Smrt_Srch_user.SelectedValue = vac_DT.Rows[0]["user_id"].ToString();
        Smrt_Srch_alter.SelectedValue = vac_DT.Rows[0]["alternative_user_id"].ToString();
        txtStartDate.Text = vac_DT.Rows[0]["start_date"].ToString();
        txtEndDate.Text = vac_DT.Rows[0]["end_date"].ToString();
        no_days.Text = vac_DT.Rows[0]["no_days"].ToString();
        vac_days.Value = vac_DT.Rows[0]["no_days"].ToString();
        manager_approve.Value = vac_DT.Rows[0]["manager_approve"].ToString();
        hidden_StartDate.Value = txtStartDate.Text;
        hidden_EndDate.Value = txtEndDate.Text;

    }


    private void Clear_cntrol()
    {
        txtStartDate.Text = CDataConverter.ConvertDateTimeToFormatdmy(CDataConverter.ConvertDateTimeNowRtnDt());
        txtEndDate.Text = CDataConverter.ConvertDateTimeToFormatdmy(CDataConverter.ConvertDateTimeNowRtnDt());
        vac_id.Value =

            no_days.Text =
            // vac_days.Value = 
            manager_approve.Value =

            hidden_StartDate.Value =
            hidden_EndDate.Value = "";

        Smrt_Srch_user.Clear_Selected();
        Smrt_Srch_alter.Clear_Selected();


    }
    protected override void OnInit(EventArgs e)
    {
        Smrt_Srch_user.sql_Connection = sql_Connection;
        //if (CDataConverter.ConvertToInt(Session_CS.group_id.ToString()) == 3)
        //{
        //    Smrt_Srch_user.Query = "select PMP_ID,pmp_name,group_id from EMPLOYEE where workstatus=1 and group_id=3";
        //}
        // else
        //{
        string Query = "";
        Query = "SELECT     EMPLOYEE.PMP_ID, EMPLOYEE.pmp_name, Departments.sec_sec_id FROM         EMPLOYEE INNER JOIN                      Departments ON EMPLOYEE.Dept_Dept_id = Departments.Dept_ID where EMPLOYEE.foundation_id='" + Session_CS.foundation_id + "' and  Departments.sec_sec_id ='" + CDataConverter.ConvertToInt(Session_CS.sec_id.ToString()) + "' and EMPLOYEE.workstatus=1   ";
        //   }
        //Smrt_Srch_user.Query = "select PMP_ID,pmp_name from EMPLOYEE where ( vacation_mng_pmp_id=" + Session_CS.vacation_mng.ToString() + " or PMP_ID=" + Session_CS.vacation_mng.ToString() + " or vacation_mng_pmp_id=" + Session_CS.pmp_id.ToString() + ")";
        if (InsideMCIT == "1")
        {
            if (CDataConverter.ConvertToInt(Session_CS.group_id.ToString()) == 3)
            {
                Query = "SELECT     EMPLOYEE.PMP_ID, EMPLOYEE.pmp_name, Departments.sec_sec_id FROM         EMPLOYEE INNER JOIN                      Departments ON EMPLOYEE.Dept_Dept_id = Departments.Dept_ID where EMPLOYEE.foundation_id='" + Session_CS.foundation_id + "' and  Departments.sec_sec_id ='" + CDataConverter.ConvertToInt(Session_CS.sec_id.ToString()) + "' and EMPLOYEE.workstatus=1 and group_id=3";
                Query = "SELECT EMPLOYEE.PMP_ID, EMPLOYEE.pmp_name, Departments.sec_sec_id FROM         EMPLOYEE INNER JOIN                      Departments ON EMPLOYEE.Dept_Dept_id = Departments.Dept_ID where EMPLOYEE.foundation_id='" + Session_CS.foundation_id + "' and  Departments.sec_sec_id ='" + CDataConverter.ConvertToInt(Session_CS.sec_id.ToString()) + "' and EMPLOYEE.workstatus=1 and group_id=3";

            }

        }
        Smrt_Srch_user.datatble = General_Helping.GetDataTable(Query);
        Smrt_Srch_user.Value_Field = "PMP_ID";
        Smrt_Srch_user.Text_Field = "pmp_name";
        Smrt_Srch_user.Orderby = "ORDER BY LTRIM(pmp_name)";

        Smrt_Srch_user.DataBind();

        Smrt_Srch_alter.sql_Connection = sql_Connection;
        //if (CDataConverter.ConvertToInt(Session_CS.group_id.ToString()) == 3)
        //{
        //    Smrt_Srch_alter.Query = "select PMP_ID,pmp_name,group_id from EMPLOYEE where workstatus=1 and group_id=3";
        //}
        //else
        //{
        Query = "SELECT EMPLOYEE.PMP_ID, EMPLOYEE.pmp_name, Departments.sec_sec_id FROM         EMPLOYEE INNER JOIN                      Departments ON EMPLOYEE.Dept_Dept_id = Departments.Dept_ID where EMPLOYEE.foundation_id='" + Session_CS.foundation_id + "' and  Departments.sec_sec_id ='" + CDataConverter.ConvertToInt(Session_CS.sec_id.ToString()) + "' and EMPLOYEE.workstatus=1";


        if (InsideMCIT == "1")
        {
            if (CDataConverter.ConvertToInt(Session_CS.group_id.ToString()) == 3)
            {
                Query = "select PMP_ID,pmp_name,group_id from EMPLOYEE where EMPLOYEE.foundation_id='" + Session_CS.foundation_id + "' and  workstatus=1 and group_id=3";
            }


        }
        Smrt_Srch_alter.datatble = General_Helping.GetDataTable(Query);
        //}
        Smrt_Srch_alter.Value_Field = "PMP_ID";
        Smrt_Srch_alter.Text_Field = "pmp_name";
        Smrt_Srch_alter.Orderby = "ORDER BY LTRIM(pmp_name)";
        Smrt_Srch_alter.DataBind();

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
        lblPageStatus.Visible = false;
        lblPageStatus.Text = "";

        save();

    }
    public void save()
{

        if (CheckValidate())
        {
            if (Checkfile())
            {
                Vacations_DT VacObj = new Vacations_DT();
                VacObj.vacation_id = CDataConverter.ConvertToInt(DDLVacationType.SelectedValue);
                VacObj.user_id = CDataConverter.ConvertToInt(Smrt_Srch_user.SelectedValue);
                VacObj.alternative_user_id = CDataConverter.ConvertToInt(Smrt_Srch_alter.SelectedValue);
                VacObj.request_user_id = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
                VacObj.start_date = txtStartDate.Text;
                VacObj.end_date = txtEndDate.Text;
                VacObj.id = CDataConverter.ConvertToInt(vac_id.Value);
                VacObj.no_days = CDataConverter.ConvertToInt(no_days.Text);
                if (txt_note.Text != "")
                {
                    VacObj.notes = txt_note.Text;
                }
                VacObj.file_name = voc_file.FileName;
                saveFileSystem();

                VacObj.general_manager_approve = 0;
                VacObj.manager_approve = 0;


                int difference = CDataConverter.ConvertToInt(vac_days.Value) - CDataConverter.ConvertToInt(no_days.Text);
                VacObj.request_date = CDataConverter.ConvertDateTimeNowRtrnString();
                VacObj.dept_id = CDataConverter.ConvertToInt(Session_CS.dept_id.ToString());
                if (Session_CS.UROL_UROL_ID.ToString() == "12")
                {
                    if (DDLVacationType.SelectedValue == "1")

                    { VacObj.type = 1; }
                }
                else { VacObj.type = 0; }
                VacObj.id = Vacations_DB.Save(VacObj);
                //if (vac_field_name.Value != "" && Convert.ToInt16(vac_days.Value) > 0 && Session_CS.is_vacation_mng.ToString() == "1")
                //{
                //    int reslt = General_Helping.ExcuteQuery("update Vacations_summary set " + vac_field_name.Value + "=" + vac_field_name.Value + "+(" + difference + ") WHERE emp_id = " + Smrt_Srch_user.SelectedValue);
                //}
                if (VacObj.id > 0)
                {
                    Send_Mail(VacObj);



                    ////////////////////check if the system inside MCIT when the value readed from web.config=1  .... then activate send mail to sahar in 3lakat dawleea/////////////////////



                    if (InsideMCIT == "1")
                    {
                        if (CDataConverter.ConvertToInt(Session_CS.group_id.ToString()) == 3)
                        {
                            Send_Mail(VacObj);
                        }

                    }
                    Clear_cntrol();
                    ShowAlertMessage("لقد تم الحفظ بنجاح");
                }



            }

        }


    }






    private void Send_Mail(Vacations_DT VacObj)
    {
        int group = CDataConverter.ConvertToInt(Session_CS.group_id.ToString());
        DataTable Dt_Emp = General_Helping.GetDataTable("Select mail,PMP_ID,pmp_name,vacation_mng_pmp_id from EMPLOYEE where PMP_ID = " + VacObj.user_id);
        string name = "";
        string mail = "";
        string Succ_names = "", Failed_name = "";
        string vacation_mng_pmp_id = "";
        string vacresponsible_mail = "";
        if (Dt_Emp.Rows.Count > 0)
        {
            vacation_mng_pmp_id = Dt_Emp.Rows[0]["vacation_mng_pmp_id"].ToString();
        }



        DataTable Dt_Mng = General_Helping.GetDataTable("Select mail,PMP_ID,pmp_name from EMPLOYEE where PMP_ID = " + vacation_mng_pmp_id);
        DataTable dt_vacresponsible = Vacations_View_class.Sector_Vacation_Resposible(CDataConverter.ConvertToInt(Session_CS.sec_id), CDataConverter.ConvertToInt(Session_CS.foundation_id));
        if (Dt_Mng.Rows.Count > 0 && dt_vacresponsible.Rows.Count > 0)
        {
            mail = Dt_Mng.Rows[0]["mail"].ToString();

            vacresponsible_mail = dt_vacresponsible.Rows[0]["mail"].ToString();

            MailMessage _Message = new MailMessage();

            _Message.Subject = "نظام الادارة الالكترونية - الأجازات";


            //_Message.BodyEncoding = Encoding.Unicode;
            _Message.BodyEncoding = Encoding.UTF8;
            _Message.SubjectEncoding = Encoding.UTF8;

            string address2 = "0";
            String encrypted_id = "0";
            string file = "";
            MemoryStream ms = new MemoryStream();
            //  _Message.IsBodyHtml = true;
            _Message.Body = "<html><body dir='rtl'><h3 >";
            _Message.Body += " السيد  ";
            _Message.Body += Dt_Mng.Rows[0]["pmp_name"] + " </h3> ";
            _Message.Body += "<h3 > نرجو من سيادتكم التكرم بالدخول على النظام لقبول أو رفض طلب الاجازة المقدمة من </h3> ";
            _Message.Body += " <h3 > " + Smrt_Srch_user.SelectedText
                + "<br/> <h3 style=" + "color:blue > من تاريخ  " + txtStartDate.Text + " إلى " + txtEndDate.Text + "</h3>";
            _Message.Body += "<h3 > مع تحيات </h3> ";
            _Message.Body += "<h3 >   " + Session_CS.e_signature.ToString() + "  </h3> ";
            _Message.Body += "</body></html>";


            try
            {



                SendingMailthread_class.Sendingmail(_Message, _Message.Subject, _Message.Body, mail, ms, file, encrypted_id, vacresponsible_mail);

                Succ_names += name + ",";
            }
            catch (Exception ex)
            {
                Failed_name += name + ",";
            }

        }

    }

    private bool CheckValidate()
    {
        bool isValid = true;
        if (!(txtStartDate.Text.Trim() != "" && txtEndDate.Text.Trim() != ""))
        {
            isValid = false;
            lblPageStatus.Visible = true;
            lblPageStatus.Text = "ادخل تاريخ بداية ونهاية الأجازة بشكل صحيح";
            goto returnPart;
        }
        else if (!(VB_Classes.Dates.Dates_Operation.Date_compare(txtEndDate.Text.Trim(), txtStartDate.Text.Trim())))
        {
            isValid = false;
            lblPageStatus.Visible = true;
            lblPageStatus.Text = "تاريخ بداية الأجازة أكبر من تاريخ النهاية";
            goto returnPart;
        }
        else if (DDLVacationType.SelectedValue == "1")
        {



            int vacation_days;
            DateTime start_date = CDataConverter.ConvertDateTimeNowRtnDt();
            DateTime end_date = CDataConverter.ConvertToDate (txtStartDate.Text.Trim());
            TimeSpan diff_days = end_date.Subtract(start_date);
            vacation_days = diff_days.Days;

            string days_before_vacation = System.Configuration.ConfigurationManager.AppSettings["days_before_vacation"].ToString();

            if (vacation_days < Convert.ToInt32(days_before_vacation))
                
            {
                Response.Write("vacation dayes=" + vacation_days);
                if (InsideMCIT == "1" && Session_CS.UROL_UROL_ID.ToString() == "12" || Session_CS.dept_id.ToString() == "54" || CDataConverter.ConvertToInt(Session_CS.group_id.ToString()) == 3 || Session_CS.pmp_id.ToString() == "436" || Session_CS.pmp_id.ToString() == "584")
                {
                   
                    isValid = true;
                    lblPageStatus.Visible = false;
                }

                else
                {
                   
                    isValid = false;
                    lblPageStatus.Visible = true;
                    lblPageStatus.Text = "الأجازة الإعتيادية يجب أن تقدم قبلها بعدد  " + days_before_vacation + "يوم ";
                    goto returnPart;
                   
                }


            }
            else
            {
                isValid = true;
                lblPageStatus.Visible = false;
            }

        }
        if (CDataConverter.ConvertToInt(no_days.Text) <= 0)
        {
            isValid = false;
            lblPageStatus.Visible = true;
            lblPageStatus.Text = "عدد الايام يجب ان يكون رقم صحيح";
            goto returnPart;
        }
        if (txtStartDate.Text == "" || txtEndDate.Text == "")
        {
            isValid = false;
            lblPageStatus.Visible = true;
            lblPageStatus.Text = "ادخل تاريخ بداية ونهاية الأجازة";
            goto returnPart;
        }
        int curYear = CDataConverter.ConvertDateTimeNowRtnDt().Year ;
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
        else if (CDataConverter.ConvertToInt(DDLVacationType.SelectedValue) == 8)
        {
            vacation_repeat = "day_off";
            field_name = "day_off_no";
        }

        DataTable BalanceDT = new DataTable();
        if (field_name != "" && field_name != "sick" && CDataConverter.ConvertToInt(Session_CS.group_id.ToString()) != 3)
        {
            vac_field_name.Value = field_name;
            SqlParameter[] sqlParams = new SqlParameter[] { new SqlParameter("@user_id", Smrt_Srch_user.SelectedValue), 
                                    new SqlParameter("@vac_id", CDataConverter.ConvertToInt(DDLVacationType.SelectedValue)), 
                                    new SqlParameter("@year", curYear.ToString()),
                                    new SqlParameter("@vacation_repeat", vacation_repeat.ToString()),
                                    new SqlParameter("@field", field_name.ToString())};
            BalanceDT = General_Helping.GetDataTable("SELECT " + field_name.ToString() + " AS remaining FROM Vacations_summary WHERE emp_id =  '" + Smrt_Srch_user.SelectedValue + "' and year='" + CDataConverter.ConvertDateTimeNowRtnDt().Year  + "'");
        }
        if (BalanceDT.Rows.Count > 0)
        {
            int uu = CDataConverter.ConvertToInt(BalanceDT.Rows[0]["remaining"].ToString());
            switch (vacation_repeat)
            {
                case "yearly":
                    if (((CDataConverter.ConvertToInt(BalanceDT.Rows[0]["remaining"].ToString()) + CDataConverter.ConvertToInt(vac_days.Value)) - CDataConverter.ConvertToInt(no_days.Text)) < 0)
                    {

                        lblPageStatus.Visible = true;
                        lblPageStatus.Text = "عدد الأيام أكبر من الرصيد المتبقى";
                        isValid = false;

                    }


                    break;
                case "once":
                    if (CDataConverter.ConvertToInt(BalanceDT.Rows[0]["remaining"].ToString()) > 0)
                    {
                        lblPageStatus.Visible = true;
                        lblPageStatus.Text = "لقد استنفذت هذا النوع من الأجازات";
                        isValid = false;
                    }
                    break;
                case "3times":
                    if (CDataConverter.ConvertToInt(BalanceDT.Rows[0]["remaining"].ToString()) == 3)
                    {
                        lblPageStatus.Visible = true;
                        lblPageStatus.Text = "لقد استنفذت هذا النوع من الأجازات";
                        isValid = false;
                    }
                    break;
                case "day_off":
                    if (CDataConverter.ConvertToInt(BalanceDT.Rows[0]["remaining"].ToString()) < CDataConverter.ConvertToInt(no_days.Text))
                    {
                        lblPageStatus.Visible = true;
                        lblPageStatus.Text = "لديك عدد " + CDataConverter.ConvertToInt(BalanceDT.Rows[0]["remaining"].ToString()) + "بدل راحة ";
                        isValid = false;
                    }
                    break;


            }
        }
        else if (field_name != "")
        {
            BalanceDT.Clear();
            BalanceDT = Vacations_DB.get_vacation_limit(CDataConverter.ConvertToInt(DDLVacationType.SelectedValue));
            if (BalanceDT.Rows.Count > 0)
            {
                string ball=BalanceDT.Rows[0]["vacation_days"].ToString();
                if ((CDataConverter.ConvertToInt(ball) - CDataConverter.ConvertToInt(no_days.Text)) < 0)
                {
                    lblPageStatus.Visible = true;
                    lblPageStatus.Text = "عدد الأيام أكبر من الرصيد المتبقى";
                    isValid = false;
                }
            }
        }

        if (string.IsNullOrEmpty(vac_id.Value) || hidden_StartDate.Value != txtStartDate.Text || hidden_EndDate.Value != txtEndDate.Text)
        {
            DataTable Dt_Vac_Valid = Vacations_DB.Check_DT_Valid(txtStartDate.Text, txtEndDate.Text, CDataConverter.ConvertToInt(Smrt_Srch_user.SelectedValue));
            if (Dt_Vac_Valid.Rows.Count > 0)
            {
                if (Request["vacation_id"] != null && Request["vacation_id"] != "" && Dt_Vac_Valid.Rows.Count == 1 && Dt_Vac_Valid.Rows[0]["id"].ToString() == Request["vacation_id"].ToString())
                {
                    //in case of update 
                }
                else
                {

                    lblPageStatus.Visible = true;
                    lblPageStatus.Text = "يوجد أجازة أخرى فى نفس الفترة";
                    isValid = false;
                }
            }
        }

        DataTable Dt_errnd_Valid = Vacations_errand_DB.Check_DT_Valid(txtStartDate.Text, txtEndDate.Text, CDataConverter.ConvertToInt(Smrt_Srch_user.SelectedValue));
        if (Dt_errnd_Valid.Rows.Count > 0)
        {
            lblPageStatus.Visible = true;
            lblPageStatus.Text = "يوجد مأمورية فى نفس الفترة";
            isValid = false;
        }



    returnPart:
        return isValid;
    }
    protected void txtEndDate_TextChanged(object sender, EventArgs e)
    {
        if (!(txtStartDate.Text.Trim() != "" && txtEndDate.Text.Trim() != ""))
        {

        }
        else if (!(VB_Classes.Dates.Dates_Operation.Date_compare(txtEndDate.Text.Trim(), txtStartDate.Text.Trim())))
        {

        }
        else
        {
            Calc_No_days();
        }
    }
    protected void txtStartDate_TextChanged(object sender, EventArgs e)
    {
        if (!(txtStartDate.Text.Trim() != "" && txtEndDate.Text.Trim() != ""))
        {

        }
        else if (!(VB_Classes.Dates.Dates_Operation.Date_compare(txtEndDate.Text.Trim(), txtStartDate.Text.Trim())))
        {
            txtEndDate.Text = txtStartDate.Text;
            Calc_No_days();
        }
        else
        {

            Calc_No_days();
        }
    }

    void Calc_No_days()
    {
        int vacation_days; DateTime start_date = CDataConverter.ConvertToDate(txtStartDate.Text.Trim());
        DateTime end_date = CDataConverter.ConvertToDate(txtEndDate.Text.Trim());
        TimeSpan diff_days = end_date.Subtract(start_date);
        vacation_days = diff_days.Days + 1;
        no_days.Text = vacation_days.ToString();

    }
    protected void DDLVacationType_DataBinding(object sender, EventArgs e)
    {

    }

    private bool Checkfile()
    {
        bool vaild = true;
        if (voc_file.HasFile)
        {

            String[] FileNameDot = voc_file.FileName.Split('.');
            if (FileNameDot.Length == 2)
            {
                string file_exe = FileNameDot[1].ToString();
                if (file_exe == "docx" || file_exe == "doc" || file_exe == "pdf")
                {
                    vaild = true;
                    return vaild;

                }
                else
                {
                    lblPageStatus.Visible = true;
                    lblPageStatus.Text = " امتداد الملف غير صحيح ";
                    vaild = false;
                    return vaild;
                }


            }
            else
            {
                lblPageStatus.Visible = true;
                lblPageStatus.Text = " امتداد الملف غير صحيح ";
                vaild = false;
                return vaild;
            }

        }
        return vaild;
    }
    protected void saveFileSystem()
    {
        string savePath = MapPath("..") + "\\upload\\";

        string fileName = voc_file.FileName;
        if (fileName != "")
        {
            savePath += fileName;
            voc_file.SaveAs(savePath);
        }
    }
}
