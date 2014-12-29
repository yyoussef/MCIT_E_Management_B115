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

public partial class UserControls_vacation_errand_request : System.Web.UI.UserControl
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
            txtStartDate.Text = CDataConverter.ConvertDateTimeNowRtrnString(); ;
            txtEndDate.Text = CDataConverter.ConvertDateTimeNowRtrnString(); ;

            if (Request["vacation_id"] != null && Request["vacation_id"] != "")
                FillControls(Request.QueryString["vacation_id"]);
            else
                Smrt_Srch_user.SelectedValue = Session_CS.pmp_id.ToString();
        }
    }
    private void FillControls(string vacation_id)
    {
        vac_id.Value = vacation_id;
        DataTable vac_DT = Vacations_errand_DB.Select_Vac_By_ID(CDataConverter.ConvertToInt(vacation_id));
        if (vac_DT.Rows.Count > 0)
        {
            location.Text = vac_DT.Rows[0]["location"].ToString();
            person_to_meet.Text = vac_DT.Rows[0]["person_to_meet"].ToString();
            start_hour.SelectedValue = vac_DT.Rows[0]["start_hour"].ToString();
            purpose.Text = vac_DT.Rows[0]["purpose"].ToString();
            notes.Text = vac_DT.Rows[0]["notes"].ToString();
            if (!string.IsNullOrEmpty(vac_DT.Rows[0]["day_off"].ToString()))
                ChkdayOff.Checked = Convert.ToBoolean(vac_DT.Rows[0]["day_off"].ToString());
            end_hour.SelectedValue = vac_DT.Rows[0]["end_hour"].ToString();
            Smrt_Srch_user.SelectedValue = vac_DT.Rows[0]["user_id"].ToString();
            Smrt_Srch_alter.SelectedValue = vac_DT.Rows[0]["alternative_user_id"].ToString();
            txtStartDate.Text = vac_DT.Rows[0]["start_date"].ToString();
            txtEndDate.Text = vac_DT.Rows[0]["end_date"].ToString();
            hidden_StartDate.Value = txtStartDate.Text;
            hidden_EndDate.Value = txtEndDate.Text;

        }
    }

    private void Clear_cntrol()
    {
        hidden_StartDate.Value =
        hidden_EndDate.Value =
        vac_id.Value =
            location.Text =
            person_to_meet.Text =
            purpose.Text =
            notes.Text =
            txtStartDate.Text =
            txtEndDate.Text = "";
        Smrt_Srch_user.Clear_Selected();
        Smrt_Srch_alter.Clear_Selected();

        ChkdayOff.Checked = false;

    }
    protected override void OnInit(EventArgs e)
    {
        Smrt_Srch_user.sql_Connection = sql_Connection;
   
        string Query = "";
        Query = "SELECT     EMPLOYEE.PMP_ID, EMPLOYEE.pmp_name, Departments.sec_sec_id FROM         EMPLOYEE INNER JOIN                      Departments ON EMPLOYEE.Dept_Dept_id = Departments.Dept_ID where EMPLOYEE.foundation_id='" + Session_CS.foundation_id + "' and  Departments.sec_sec_id ='" + CDataConverter.ConvertToInt(Session_CS.sec_id.ToString()) + "' and EMPLOYEE.workstatus=1";
            if (InsideMCIT == "1")
            {
                if (CDataConverter.ConvertToInt(Session_CS.group_id.ToString()) == 3)
                {
                    Query = "SELECT     EMPLOYEE.PMP_ID, EMPLOYEE.pmp_name, Departments.sec_sec_id FROM         EMPLOYEE INNER JOIN                      Departments ON EMPLOYEE.Dept_Dept_id = Departments.Dept_ID where EMPLOYEE.foundation_id='" + Session_CS.foundation_id + "' and  Departments.sec_sec_id ='" + CDataConverter.ConvertToInt(Session_CS.sec_id.ToString()) + "' and EMPLOYEE.workstatus=1 and group_id=3";

                }

            }
            Smrt_Srch_user.datatble = General_Helping.GetDataTable(Query);
       // }
        Smrt_Srch_user.Value_Field = "PMP_ID";
        Smrt_Srch_user.Text_Field = "pmp_name";
        Smrt_Srch_user.Orderby = "ORDER BY LTRIM(pmp_name)";
        Smrt_Srch_user.DataBind();


        Smrt_Srch_alter.sql_Connection = sql_Connection;


        Query = "SELECT     EMPLOYEE.PMP_ID, EMPLOYEE.pmp_name, Departments.sec_sec_id FROM         EMPLOYEE INNER JOIN                      Departments ON EMPLOYEE.Dept_Dept_id = Departments.Dept_ID where EMPLOYEE.foundation_id='" + Session_CS.foundation_id + "' and   Departments.sec_sec_id ='" + CDataConverter.ConvertToInt(Session_CS.sec_id.ToString()) + "' and EMPLOYEE.workstatus=1";

        if (InsideMCIT == "1")
        {
            if (CDataConverter.ConvertToInt(Session_CS.group_id.ToString()) == 3)
            {
                Query = "SELECT     EMPLOYEE.PMP_ID, EMPLOYEE.pmp_name, Departments.sec_sec_id FROM         EMPLOYEE INNER JOIN                      Departments ON EMPLOYEE.Dept_Dept_id = Departments.Dept_ID where EMPLOYEE.foundation_id='" + Session_CS.foundation_id + "' and   Departments.sec_sec_id ='" + CDataConverter.ConvertToInt(Session_CS.sec_id.ToString()) + "' and EMPLOYEE.workstatus=1 and group_id=3";

            }

        }
        Smrt_Srch_alter.datatble = General_Helping.GetDataTable(Query);
       // }
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
        if (CheckValidate())
        {
            DateTime one;
            DateTime dtone;
            DateTime dtone2;
            Vacations_errand_DT VacObj = new Vacations_errand_DT();
            VacObj.vacation_id = CDataConverter.ConvertToInt("0");
            VacObj.user_id = CDataConverter.ConvertToInt(Smrt_Srch_user.SelectedValue);
            VacObj.alternative_user_id = CDataConverter.ConvertToInt(Smrt_Srch_alter.SelectedValue);
            VacObj.request_user_id = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
            VacObj.start_date = txtStartDate.Text;
            VacObj.end_date = txtEndDate.Text;
            //if (location.Text != "")
            VacObj.location = location.Text; 
         
            VacObj.purpose = purpose.Text;
            VacObj.person_to_meet = person_to_meet.Text;
            VacObj.notes = notes.Text;
            if (ChkdayOff.Checked == true)
            {
                dtone = CDataConverter.ConvertToDate(txtStartDate.Text);
                dtone2 = CDataConverter.ConvertToDate(txtEndDate.Text);
                int i = dtone2.Subtract(dtone).Days + 1;
                VacObj.no_days = i;
                no_days.Value = i.ToString();
            }
            else
            { VacObj.no_days = 0;
        
                     
            }
            VacObj.day_off = ChkdayOff.Checked;
            VacObj.start_hour = start_hour.SelectedValue;
            VacObj.end_hour = end_hour.SelectedValue;

            VacObj.id = CDataConverter.ConvertToInt(vac_id.Value);
         
                VacObj.general_manager_approve = 0;
                VacObj.manager_approve = 0;



                VacObj.request_date = CDataConverter.ConvertDateTimeToFormatdmy(CDataConverter.ConvertDateTimeNowRtnDt());
            if (Session_CS.dept_id.ToString() != "")
                VacObj.dept_id = CDataConverter.ConvertToInt(Session_CS.dept_id.ToString());
            VacObj.id = Vacations_errand_DB.Save(VacObj);
            if (VacObj.id > 0)
            {
                
               
                Send_Mail(VacObj.user_id);
             
                Clear_cntrol();
                ShowAlertMessage("لقد تم الحفظ بنجاح");
            
            }
           

        }
    }

    private void Send_Mail(int requestingEmpID)
    {

        string mail = "";
        string vacresponsible_mail = "";

        int group = CDataConverter.ConvertToInt(Session_CS.group_id.ToString());
        DataTable Dt_Emp = General_Helping.GetDataTable("Select mail,PMP_ID,pmp_name,vacation_mng_pmp_id from EMPLOYEE where PMP_ID = " + requestingEmpID);
        string vacation_mng_pmp_id = "";
        if (Dt_Emp.Rows.Count > 0)
            vacation_mng_pmp_id = Dt_Emp.Rows[0]["vacation_mng_pmp_id"].ToString();
         
        DataTable Dt_Mng = General_Helping.GetDataTable("Select mail,PMP_ID,pmp_name from EMPLOYEE where PMP_ID = " + vacation_mng_pmp_id);
        DataTable dt_vacresponsible = Vacations_View_class.Sector_Vacation_Resposible(CDataConverter.ConvertToInt(Session_CS.sec_id),CDataConverter.ConvertToInt(Session_CS.foundation_id ));

        string name = "";
        string Succ_names = "", Failed_name = "";
        if (Dt_Mng.Rows.Count > 0 && dt_vacresponsible.Rows.Count > 0)
        {
             mail = Dt_Mng.Rows[0]["mail"].ToString();

             vacresponsible_mail = dt_vacresponsible.Rows[0]["mail"].ToString();

            MailMessage _Message = new MailMessage();

            _Message.Subject = "نظام الادارة الالكترونية - المأموريات";

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
            _Message.Body += "<h3 > نرجو من سادتكم التكرم بالدخول على النظام لقبول أو رفض طلب المأمورية المقدمة من </h3> ";
            _Message.Body += " <h3 > " + Dt_Emp.Rows[0]["pmp_name"].ToString();
            if (location.Text != "")
            { _Message.Body += " وجهة المأمورية " + location.Text; }
            _Message.Body+= "<br/> <h3 style=" + "color:blue > من تاريخ  " + txtStartDate.Text + " إلى " + txtEndDate.Text + "</h3>";
            _Message.Body += "   و من الساعة " + start_hour.Text + ":00 " + "  إلي  " + end_hour.Text + ":00 " + "</h4>";

             if (purpose.Text != "")
             {_Message.Body += "<h4> بخصوص  " + purpose.Text + "</h4>";}
             

            _Message.Body += "<h3 > مع تحيات </h3> ";
            _Message.Body += "<h3 >   " + Session_CS.e_signature.ToString() + "  </h3> ";
            _Message.Body += "</body></html>";
           

            try
            {
         

           
                SendingMailthread_class.Sendingmail(_Message,_Message.Subject, _Message.Body, mail, ms, file, encrypted_id, vacresponsible_mail);

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
        DataTable Dt_Vac_Valid = Vacations_DB.Check_DT_Valid(txtStartDate.Text, txtEndDate.Text, CDataConverter.ConvertToInt(Smrt_Srch_user.SelectedValue));
        if (Dt_Vac_Valid.Rows.Count > 0)
        {
          lblPageStatus.Visible = true;
         lblPageStatus.Text = "يوجد أجازة فى نفس الفترة";
         isValid = false;
        }

        //DataTable Dt_errnd_Valid = Vacations_errand_DB.Check_DT_Valid(txtStartDate.Text, txtEndDate.Text, CDataConverter.ConvertToInt(Smrt_Srch_user.SelectedValue));
        //if (Dt_errnd_Valid.Rows.Count > 0)
        //{
        //    lblPageStatus.Visible = true;
        //    lblPageStatus.Text = "يوجد مأمورية أخرى فى نفس الفترة";
        //    isValid = false;
        //}

        if (string.IsNullOrEmpty(vac_id.Value) || hidden_StartDate.Value != txtStartDate.Text || hidden_EndDate.Value != txtEndDate.Text)
        {
            DataTable Dt_Time_errnd_Valid = Vacations_errand_DB.Check_DT_Time_Valid(txtStartDate.Text,txtEndDate.Text, CDataConverter.ConvertToInt(start_hour.SelectedValue), CDataConverter.ConvertToInt(end_hour.SelectedValue), CDataConverter.ConvertToInt(Smrt_Srch_user.SelectedValue));
            if (Dt_Time_errnd_Valid.Rows.Count > 0)
           {
                lblPageStatus.Visible = true;
                lblPageStatus.Text = "يوجد مأمورية أخرى فى نفس الفترة الزمنية";
                isValid = false;
            }
        }


      
    returnPart:
        return isValid;
    }

    
}
