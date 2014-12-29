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
using System.Net.Mail;
using System.Text;
using System.Data.SqlClient;
using System.IO;

public partial class UserControls_permission_request : System.Web.UI.UserControl
{
    Session_CS Session_CS = new Session_CS();

    string InsideMCIT = System.Configuration.ConfigurationManager.AppSettings["InsideMCIT"].ToString();

    private string sql_Connection = Database.ConnectionString;
    int group_id;
    private string startDate = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            //txtStartDate.Text = DateTime.Today.ToShortDateString();

            //DateTime str = System.DateTime.Now;
            //txtStartDate.Text = str.ToString("dd/MM/yyyy");
            txtStartDate.Text = CDataConverter.ConvertDateTimeNowRtrnString();

            //txtEndDate.Text = DateTime.Today.ToShortDateString();
            if (Request["id"] != null && Request["id"] != "")
            {
                FillControls(Request.QueryString["id"]);
            }

            else
            {
                Smrt_Srch_user.SelectedValue = Session_CS.pmp_id.ToString();
            }

            end_hour.Text = "11";
        }
       
         

    }

    private void FillControls(string perm_id)
    {
        vac_id.Value = perm_id;
        DataTable vac_DT = Vocations_permission_DB.Select_Vac_By_ID(CDataConverter.ConvertToInt(perm_id));
        if (vac_DT.Rows.Count > 0)
        {   Smrt_Srch_user.SelectedValue = vac_DT.Rows[0]["user_id"].ToString();
          Smrt_Srch_alter.SelectedValue = vac_DT.Rows[0]["alter_user_id"].ToString();
            txtStartDate.Text = vac_DT.Rows[0]["start_date"].ToString();
            start_hour.SelectedValue = vac_DT.Rows[0]["start_hour"].ToString();
            start_hour.SelectedValue = vac_DT.Rows[0]["end_hour"].ToString();
            //no_days.Text = vac_DT.Rows[0]["no_days"].ToString();
            vac_days.Value = vac_DT.Rows[0]["permission_no"].ToString();
            manager_approve.Value = vac_DT.Rows[0]["manager_approve"].ToString();
            hidden_StartDate.Value = txtStartDate.Text;
            // hidden_EndDate.Value = txtEndDate.Text;
        }
    }


    private void Clear_cntrol()
    {
        //txtStartDate.Text = DateTime.Today.ToShortDateString();

        txtStartDate.Text = CDataConverter.ConvertDateTimeToFormatdmy(CDataConverter.ConvertDateTimeNowRtnDt());
        //txtEndDate.Text = DateTime.Today.ToShortDateString();
        vac_id.Value =

            //no_days.Text =
            vac_days.Value =
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
        //    Smrt_Srch_user.Query = "select PMP_ID,pmp_name,group_id from EMPLOYEE where group_id=3";
        //}
        //else
        //{
       // Smrt_Srch_user.Query = "SELECT     EMPLOYEE.PMP_ID, EMPLOYEE.pmp_name, Departments.sec_sec_id FROM         EMPLOYEE INNER JOIN                      Departments ON EMPLOYEE.Dept_Dept_id = Departments.Dept_ID where  Departments.sec_sec_id =" + CDataConverter.ConvertToInt(Session_CS.sec_id.ToString());
        string Query = "";
        Query = "SELECT     EMPLOYEE.PMP_ID, EMPLOYEE.pmp_name, Departments.sec_sec_id FROM         EMPLOYEE INNER JOIN                      Departments ON EMPLOYEE.Dept_Dept_id = Departments.Dept_ID where EMPLOYEE.foundation_id='" + Session_CS.foundation_id + "' and   Departments.sec_sec_id ='" + CDataConverter.ConvertToInt(Session_CS.sec_id.ToString()) + "' and EMPLOYEE.workstatus=1";
        if (InsideMCIT == "1")
        {
            if (CDataConverter.ConvertToInt(Session_CS.group_id.ToString()) == 3)
            {
                Query = "SELECT     EMPLOYEE.PMP_ID, EMPLOYEE.pmp_name, Departments.sec_sec_id FROM         EMPLOYEE INNER JOIN                      Departments ON EMPLOYEE.Dept_Dept_id = Departments.Dept_ID where EMPLOYEE.foundation_id='" + Session_CS.foundation_id + "' and  Departments.sec_sec_id ='" + CDataConverter.ConvertToInt(Session_CS.sec_id.ToString()) + "' and EMPLOYEE.workstatus=1 and group_id=3";

            }

        }
        Smrt_Srch_user.datatble = General_Helping.GetDataTable(Query);
        //}
        //Smrt_Srch_user.Query = "select PMP_ID,pmp_name from EMPLOYEE where ( vacation_mng_pmp_id=" + Session_CS.vacation_mng.ToString() + " or PMP_ID=" + Session_CS.vacation_mng.ToString() + " or vacation_mng_pmp_id=" + Session_CS.pmp_id.ToString() + ")";
        Smrt_Srch_user.Value_Field = "PMP_ID";
        Smrt_Srch_user.Text_Field = "pmp_name";
        Smrt_Srch_user.Orderby = "ORDER BY LTRIM(pmp_name)";
        Smrt_Srch_user.DataBind();

        Smrt_Srch_alter.sql_Connection = sql_Connection;
        //if (CDataConverter.ConvertToInt(Session_CS.group_id.ToString()) == 3)
        //{
        //    Smrt_Srch_alter.Query = "select PMP_ID,pmp_name,group_id from EMPLOYEE where group_id=3";
        //}
        //else
        //{
        //    Smrt_Srch_alter.Query = "SELECT     EMPLOYEE.PMP_ID, EMPLOYEE.pmp_name, Departments.sec_sec_id FROM         EMPLOYEE INNER JOIN                      Departments ON EMPLOYEE.Dept_Dept_id = Departments.Dept_ID where Departments.sec_sec_id =1";
        //}

      //  Smrt_Srch_alter.Query = "SELECT     EMPLOYEE.PMP_ID, EMPLOYEE.pmp_name, Departments.sec_sec_id FROM         EMPLOYEE INNER JOIN                      Departments ON EMPLOYEE.Dept_Dept_id = Departments.Dept_ID where  Departments.sec_sec_id =" + CDataConverter.ConvertToInt(Session_CS.sec_id.ToString());
        Query = "SELECT     EMPLOYEE.PMP_ID, EMPLOYEE.pmp_name, Departments.sec_sec_id FROM         EMPLOYEE INNER JOIN                      Departments ON EMPLOYEE.Dept_Dept_id = Departments.Dept_ID where EMPLOYEE.foundation_id='" + Session_CS.foundation_id + "' and  Departments.sec_sec_id ='" + CDataConverter.ConvertToInt(Session_CS.sec_id.ToString()) + "' and EMPLOYEE.workstatus=1";

        if (InsideMCIT == "1")
        {
            if (CDataConverter.ConvertToInt(Session_CS.group_id.ToString()) == 3)
            {
                Query = "SELECT     EMPLOYEE.PMP_ID, EMPLOYEE.pmp_name, Departments.sec_sec_id FROM         EMPLOYEE INNER JOIN                      Departments ON EMPLOYEE.Dept_Dept_id = Departments.Dept_ID where EMPLOYEE.foundation_id='" + Session_CS.foundation_id + "' and  Departments.sec_sec_id ='" + CDataConverter.ConvertToInt(Session_CS.sec_id.ToString()) + "' and EMPLOYEE.workstatus=1 and group_id=3";

            }

        }
        Smrt_Srch_alter.datatble = General_Helping.GetDataTable(Query);
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
                       
                Vocations_permission_DT VacObj = new Vocations_permission_DT();
                VacObj.user_id = CDataConverter.ConvertToInt(Smrt_Srch_user.SelectedValue);
                VacObj.alternative_user_id = CDataConverter.ConvertToInt(Smrt_Srch_alter.SelectedValue);
                VacObj.request_user_id = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
                VacObj.start_date = txtStartDate.Text;
                //string start_date = txtStartDate.Text;
               // VacObj.request_date = DateTime.Today.ToShortDateString();

                VacObj.request_date = CDataConverter.ConvertDateTimeToFormatdmy(CDataConverter.ConvertDateTimeNowRtnDt());
                VacObj.id = CDataConverter.ConvertToInt(vac_id.Value);
                VacObj.start_hour = start_hour.SelectedItem.Value;
                VacObj.end_hour = end_hour.Text;
                VacObj.permission_no = 1;
                //VacObj.no_days = CDataConverter.ConvertToInt(no_days.Text);
                //if (Session_CS.is_vacation_mng.ToString() == "1")
                //{
                //    VacObj.general_manager_approve = 1;
                //    VacObj.manager_approve = 1;
                //    General_Helping.ExcuteQuery("update Vacations_summary set permission= ISNULL(permission, 0) - " + VacObj.permission_no + " where emp_id=" + VacObj.user_id);
                //}
                //  else
                //{
                VacObj.general_manager_approve = 0;
                VacObj.manager_approve = 0;
                //}


                // VacObj.request_date = DateTime.Today.ToShortDateString();
                VacObj.dept_id = CDataConverter.ConvertToInt(Session_CS.dept_id.ToString());
                VacObj.id = Vocations_permission_DB.Save(VacObj);
                if (VacObj.id > 0)
                {

                    //Send_Mails_to_Emp_and_Mng(VacObj);
                    //if (CDataConverter.ConvertToInt(Session_CS.group_id.ToString()) == 3)
                    //{
                    //Send_Mails_to_sahar(VacObj);
                    //}
                    Clear_cntrol();
                    ShowAlertMessage("لقد تم الحفظ بنجاح");
                    //send mail to direct Manager
                    Send_Mails_to_Mng(VacObj.user_id, VacObj.start_date);
                }
            }

            // Response.Redirect(this.previousPageID);

        
     

    }

    private void Send_Mails_to_Mng(int requestingEmpID, string start_date)
    {
        int group = CDataConverter.ConvertToInt(Session_CS.group_id.ToString());
        DataTable Dt_Emp = General_Helping.GetDataTable("Select mail,PMP_ID,pmp_name,vacation_mng_pmp_id from EMPLOYEE where PMP_ID = " + requestingEmpID);
        string vacation_mng_pmp_id = "";
        if (Dt_Emp.Rows.Count > 0)
            vacation_mng_pmp_id = Dt_Emp.Rows[0]["vacation_mng_pmp_id"].ToString();


        DataTable Dt_Mng = General_Helping.GetDataTable("Select mail,PMP_ID,pmp_name from EMPLOYEE where PMP_ID = " + vacation_mng_pmp_id);
        string name = "";
        string Succ_names = "", Failed_name = "";
        if (Dt_Mng.Rows.Count > 0)
        {
            string mail = Dt_Mng.Rows[0]["mail"].ToString();
            MailMessage _Message = new MailMessage();

            _Message.Subject = "نظام الادارة الالكترونية - أذن";


            //_Message.BodyEncoding = Encoding.Unicode;
            _Message.BodyEncoding = Encoding.UTF8;
            _Message.SubjectEncoding = Encoding.UTF8;

            string address2 = "0";
            String encrypted_id = "0";
            string file = "";
            MemoryStream ms = new MemoryStream();
           // _Message.IsBodyHtml = true;
            _Message.Body = "<html><body dir='rtl'><h3 >";
            _Message.Body += " السيد / ";
            _Message.Body += Dt_Mng.Rows[0]["pmp_name"] + " </h3> ";
            _Message.Body += "<h3 >  :نرجو من سيادتكم التكرم بالدخول على النظام لقبول أو رفض طلب الاذن المقدم من </h3> ";
            _Message.Body += " <h3 > " + Dt_Emp.Rows[0]["pmp_name"].ToString();
            _Message.Body += "<br/> <h3 style=" + "color:blue >  يوم  " + start_date + "</h3>";
            _Message.Body += "<h3>" + " من الساعة " + start_hour.Text + ":00 الي الساعة " + end_hour.Text + ":00</h3>";
            _Message.Body += "<h3 > مع تحيات </h3> ";
            _Message.Body += "<h3 >   " + Session_CS.e_signature.ToString() + "  </h3> ";
            _Message.Body += "</body></html>";
         

            try
            {
               
                SendingMailthread_class.Sendingmail(_Message,_Message.Subject, _Message.Body, mail, ms, file, encrypted_id, "");

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
        if (!(txtStartDate.Text.Trim() != ""))
        {
            isValid = false;
            lblPageStatus.Visible = true;
            lblPageStatus.Text = "ادخل التاريخ بشكل صحيح";
            goto returnPart;
        }

        //int curYear = DateTime.Now.Year;
       
        //int curmonth = DateTime.Now.Month;

        int curYear = CDataConverter.ConvertDateTimeNowRtnDt().Year ;

        int curmonth = CDataConverter.ConvertDateTimeNowRtnDt().Month ;

        int month = CDataConverter.ConvertToDate(txtStartDate.Text).Month;
        DataTable pendingDT = new DataTable();

        SqlParameter[] sqlParams= new SqlParameter[] { new SqlParameter("@check_pending", true), new SqlParameter("@user_id", Smrt_Srch_user.SelectedValue), new SqlParameter("@month", month), new SqlParameter("@year", curYear.ToString()) };
        pendingDT = SqlHelper.ExecuteDataset(Database.ConnectionString, "Get_Permissions_of_Month", sqlParams).Tables[0];


        //check to see if there is pending requests
        if (pendingDT.Rows.Count == 1)
        {
            lblPageStatus.Visible = true;
            lblPageStatus.Text = "لا تستطيع طلب اذن قبل الموافقة علي الاذن الذي لم ينظر بعد";
            isValid = false;

        }//else there is no pending request
        //Check if exceeded number of requests for that month
        SqlParameter[] sqlParams2 = new SqlParameter[] { 
        new SqlParameter("@pmp_id", CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString())), 
        new SqlParameter("@year", curYear),
        new SqlParameter("@month", month)

        };
        DataTable BalanceDT = Vocations_permission_DB.Selecttotalbalance(sqlParams2);
        int remain =CDataConverter.ConvertToInt(BalanceDT.Rows[0]["remain"].ToString());
        //DataTable BalanceDT = new DataTable();

        sqlParams = new SqlParameter[] { new SqlParameter("@user_id", Smrt_Srch_user.SelectedValue), 
                                       new SqlParameter("@year", curYear.ToString())};
       // BalanceDT = General_Helping.GetDataTable("SELECT permission FROM Vacations_summary WHERE emp_id = '" + Smrt_Srch_user.SelectedValue + "' and year='" + curYear + "'");


        if (remain <= 0)
        {
            
                lblPageStatus.Visible = true;
                lblPageStatus.Text = "لقد استنفذت جميع الأذونات خلال الشهر";
                isValid = false;

            

        }


        DataTable Dt_Vac_Valid = Vocations_permission_DB.Check_DT_Valid(txtStartDate.Text, CDataConverter.ConvertToInt(Smrt_Srch_user.SelectedValue));
        if (Dt_Vac_Valid.Rows.Count > 0)
        {
            lblPageStatus.Visible = true;
            lblPageStatus.Text = "يوجد أذن في نفس اليوم ";
            isValid = false;
        }


        returnPart:
        return isValid;

    }
        
    protected void txtEndDate_TextChanged(object sender, EventArgs e)
    {
        
    }
    protected void txtStartDate_TextChanged(object sender, EventArgs e)
    {

        this.startDate = this.txtStartDate.Text;
    }
    protected void start_hour_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (start_hour.SelectedItem.Value == "9")
        {
            end_hour.Text = "11";
        }
        else if (start_hour.SelectedItem.Value == "1")
        {
            end_hour.Text = "3";
        }
    }
}

   
    
