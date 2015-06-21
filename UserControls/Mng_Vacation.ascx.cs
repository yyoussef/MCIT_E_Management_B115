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
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Globalization;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;
using CrystalDecisions.Shared;

public partial class UserControls_Mng_Vacation : System.Web.UI.UserControl
{
    private string sql_Connection = Database.ConnectionString;
    SqlConnection conn;

    //Session_CS Session_CS = new Session_CS();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //DateTime str = System.DateTime.Now;
            Smrt_Srch_DropDep.Show_OrgTree = true;
            fill_structure();
            DateTime str = CDataConverter.ConvertDateTimeNowRtnDt();
           // txt_take_date_from.Text = str.ToString("dd/MM/yyyy");
          //  txt_take_date_to.Text = str.ToString("dd/MM/yyyy");
        }

    }
    protected void fill_structure()
    {

        string Query = "";
        Query = "SELECT  * from    Departments  where foundation_id='" + Session_CS.foundation_id + "' ";
        if (Session_CS.UROL_UROL_ID != 12 || Session_CS.UROL_UROL_ID != 2)
        {
            Query += " and Dept_id = '"+Session_CS.dept_id+"'";
        }
        Smrt_Srch_DropDep.datatble = General_Helping.GetDataTable(Query);
        Smrt_Srch_DropDep.Value_Field = "Dept_id";
        Smrt_Srch_DropDep.Text_Field = "Dept_name";
        Smrt_Srch_DropDep.DataBind();


    }
    protected override void OnInit(EventArgs e)
    {
        #region BROWSER FOR departments

        Smrt_Srch_DropDep.sql_Connection = sql_Connection;
        //string Query = "select Dept_ID,Dept_name from Departments where sec_sec_id= '" + Session_CS.sec_id.ToString() + "'";

        //string Query = "select Dept_ID,Dept_name from Departments inner join dbo.Sectors  on dbo.Sectors.Sec_id=Departments.sec_sec_id where sec_sec_id= '" + Session_CS.sec_id.ToString() + "' and dbo.Sectors.foundation_id='" + Session_CS.foundation_id + "'";

        //Smrt_Srch_DropDep.datatble = General_Helping.GetDataTable(Query);
        //Smrt_Srch_DropDep.Value_Field = "Dept_ID";
        //Smrt_Srch_DropDep.Text_Field = "Dept_name";
        //Smrt_Srch_DropDep.DataBind();
        this.Smrt_Srch_DropDep.Value_Handler += new Smart_Search.Delegate_Selected_Value(MOnMember_Data_Depart);

        //smart_employee.sql_Connection = sql_Connection;
        //smart_employee.Query = "select PMP_ID,pmp_name from dbo.EMPLOYEE ";
        //smart_employee.Value_Field = "PMP_ID";
        //smart_employee.Text_Field = "pmp_name";
        //smart_employee.DataBind();
        #endregion

    }
    private void MOnMember_Data_Depart(string Value)
    {
        if (Value != "")
        {
            fill_emplyees();
        }
        else
        {
            smart_employee.Clear_Controls();

        }
    }


    protected void fill_emplyees()
    {
        smart_employee.sql_Connection = sql_Connection;

        //smart_employee.Query = "SELECT pmp_id, pmp_name FROM employee where workstatus=1 and Dept_Dept_id =  " + Smrt_Srch_DropDep.SelectedValue;
        string Query = "SELECT pmp_id, pmp_name FROM employee where EMPLOYEE.foundation_id='" + Session_CS.foundation_id + "' and workstatus=1 and Dept_Dept_id =  " + Smrt_Srch_DropDep.SelectedValue;
        smart_employee.datatble = General_Helping.GetDataTable(Query);
        smart_employee.Value_Field = "pmp_id";
        smart_employee.Text_Field = "pmp_name";
        smart_employee.DataBind();

    }

    protected void gvMain_errand_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditItem")
        {
            Response.Redirect("vacation_errand_request.aspx?edit_type=manage&vacation_id=" + e.CommandArgument);
        }

        if (e.CommandName == "RemoveItem")
        {
            int result = General_Helping.ExcuteQuery("delete from Vacations_errand where id=" + e.CommandArgument);
            Search_Grid_err();
        }
    }
  
    protected void gvMain_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int operation;
        string str = e.CommandArgument.ToString();
        string[] arr = str.Split(',');
        if (e.CommandName == "EditItem")
        {
            Response.Redirect("vacation_request.aspx?edit_type=manage&vacation_id=" + arr[0].ToString());
        }

        if (e.CommandName == "RemoveItem")
        {
            DataTable vac_DT = Vacations_DB.Select_Vac_By_ID(CDataConverter.ConvertToInt(arr[0].ToString()));
            if (vac_DT.Rows.Count > 0)
            {
                if (vac_DT.Rows[0]["manager_approve"].ToString() == "1")
                {
                    string vacation_repeat = "";
                    string field_name = "";
                    if (CDataConverter.ConvertToInt(vac_DT.Rows[0]["vacation_id"].ToString()) > 0 && CDataConverter.ConvertToInt(vac_DT.Rows[0]["vacation_id"].ToString()) < 4)
                    {
                        vacation_repeat = "yearly";
                        //repeat
                        switch (CDataConverter.ConvertToInt(vac_DT.Rows[0]["vacation_id"].ToString()))
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
                    else if (CDataConverter.ConvertToInt(vac_DT.Rows[0]["vacation_id"].ToString()) == 5)
                    {
                        vacation_repeat = "once";
                        field_name = "hajj";
                    }
                    else if (CDataConverter.ConvertToInt(vac_DT.Rows[0]["vacation_id"].ToString()) == 6)
                    {
                        vacation_repeat = "3times";
                        field_name = "birth";
                    }

                    if (field_name != "" && Convert.ToInt16(vac_DT.Rows[0]["no_days"].ToString()) > 0)
                    {
                        int reslt = General_Helping.ExcuteQuery("update Vacations_summary set " + field_name + "=" + field_name + "+(" + vac_DT.Rows[0]["no_days"].ToString() + ") WHERE emp_id = " + vac_DT.Rows[0]["user_id"].ToString());
                    }
                }
            }

            string str2 = "delete from Vacations_users where id=" + arr[0].ToString();
            int result = General_Helping.ExcuteQuery("delete from Vacations_users where id=" + arr[0].ToString());
            operation = (int)Project_Log_DB.Action.delete ;
            Project_Log_DB.FillLog(CDataConverter.ConvertToInt(arr[0].ToString()), operation, Project_Log_DB.operation.vacations_manage);


            Send_mail("بالحذف", arr[1].ToString());
        }

        if (e.CommandName == "dlt")
        {
            string strr = e.CommandArgument.ToString();
            string[] arrr = strr.Split(',');

            GetReport(CDataConverter.ConvertToInt(arrr[0].ToString()), CDataConverter.ConvertToInt(arrr[1].ToString()));
        }

        Search_Grid_Vac();
    }

    private void Send_mail(string Msg, string Pmp_id)
    {
        DataTable Dt_Mng = General_Helping.GetDataTable("Select mail,PMP_ID,pmp_name from EMPLOYEE where PMP_ID = " + Pmp_id);
        string name = "";
        string Succ_names = "", Failed_name = ""; 

        if (Dt_Mng.Rows.Count > 0)
        {
            string mail = Dt_Mng.Rows[0]["mail"].ToString();
            MailMessage _Message = new MailMessage();

            _Message.Subject = "نظام الادارة الالكترونية - الأجازات";


            
            _Message.BodyEncoding = Encoding.UTF8;
            _Message.SubjectEncoding = Encoding.UTF8;

               string address2 ="0";
               String encrypted_id = "0";
               string file = "";
               MemoryStream ms = new MemoryStream();
           
             _Message.Body = "<html><body dir='rtl'><h3 > السيد -" + name + " </h3>";
          
            _Message.Body += Dt_Mng.Rows[0]["pmp_name"] + " </h3> ";
            _Message.Body += "<h3 >قام السيد " + Session_CS.pmp_name + " </h3> ";
            _Message.Body += " <h3 > بالرد على الاجازة المقدمة من جانبكم"
                + " <h3 style=color:blue > " + Msg + "</h3>";
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

    protected void btn_Search_Click(object sender, EventArgs e)
    {
        gvMain_errand.Visible = false;
        gvMain.Visible = false;

        if (ddl_Type.SelectedValue == "1")
        {
            gvMain.Visible = true;

            Search_Grid_Vac();
        }
        else if (ddl_Type.SelectedValue == "2")
        {
            gvMain_errand.Visible = true;
            Search_Grid_err();
        }






    }

    private void GetReport(int id, int vacation_type)
    {



        conn = new SqlConnection(sql_Connection);
        string s = "";
        string sql = "SELECT  dbo.EMPLOYEE.pmp_name, dbo.EMPLOYEE.Dept_Dept_id, dbo.EMPLOYEE.pmp_title,dbo.Vacations_users.vacation_id , dbo.Vacations_summary.id, dbo.Vacations_users.type, ";
        sql += "   dbo.Vacations_users.manager_approve, dbo.Vacations_summary.emp_id,alternative_user_id, dbo.Vacations_summary.unusual, dbo.Vacations_summary.exhibitor, ";
        sql += "   dbo.Vacations_summary.sick, dbo.Vacations_summary.hajj, dbo.Vacations_summary.birth, dbo.Vacations_summary.year, ";
        sql += "    dbo.Vacations_summary.repeat,Vacations_summary.unusual_total,Vacations_summary.exhibitor_total, dbo.Vacations_users.no_days, dbo.Departments.Dept_name, dbo.Vacations_users.start_date,";
        sql += "     dbo.Vacations_users.end_date, dbo.Vacations_users.user_id, dbo.EMPLOYEE.status, ";
        sql += "  (SELECT  pmp_name FROM  dbo.EMPLOYEE WHERE (PMP_ID = dbo.Vacations_users.alternative_user_id)) AS alternative_user";
        sql += "   FROM  dbo.EMPLOYEE INNER JOIN";
        sql += "   dbo.Vacations_summary ON dbo.EMPLOYEE.PMP_ID = dbo.Vacations_summary.emp_id INNER JOIN";
        sql += "    dbo.Departments ON dbo.EMPLOYEE.Dept_Dept_id = dbo.Departments.Dept_ID INNER JOIN";
        sql += "   dbo.Vacations_users ON dbo.EMPLOYEE.PMP_ID = dbo.Vacations_users.user_id";
        sql += "   WHERE  (dbo.Vacations_users.manager_approve = 1)  and status = 2  and status !=0 and dbo.Vacations_summary.year='" + CDataConverter.ConvertDateTimeNowRtnDt().Year + "'";



        if (id != 0)
        {
            sql += " and dbo.Vacations_users.id = " + id;

        }

        //if (vacid_hidden.Value != "0")

        //{ sql += " AND dbo.Vacations_users.vacation_id = " + Convert.ToInt32(vacid_hidden.Value); }

        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            {
                string user = Session_CS.pmp_name.ToString();
                if (vacation_type == 1)
                { s = Server.MapPath("../Reports/Vocations_Designated_unsu.rpt"); }
                if (vacation_type == 2)
                { s = Server.MapPath("../Reports/Vocations_Designated_ex.rpt"); }
                ReportDocument rd = new ReportDocument();
                rd.Load(s);
                ReportsClass.Reports.Load_Report(rd);
                rd.SetDataSource(dt);
                rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
                rd.SetParameterValue("@user", user, "footerRep.rpt");
                rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report");
            }
        }

    }

    private void Search_Grid_err()
    {
        string t1, t2;
        string sql = "set dateformat dmy SELECT     EMPLOYEE.pmp_name, Vacations_errand.id, Vacations_errand.user_id, Vacations_errand.request_user_id, Vacations_errand.alternative_user_id,                       Vacations_errand.vacation_id,dbo.Vacations_errand.start_date,CONVERT(datetime, dbo.datevalid(dbo.Vacations_errand.start_date)) AS start_date ,dbo.Vacations_errand.end_date,CONVERT(datetime, dbo.datevalid(dbo.Vacations_errand.end_date)) AS end_date ,   Vacations_errand.no_days, Vacations_errand.manager_approve,                       Vacations_errand.general_manager_approve, Vacations_errand.dept_id, Vacations_errand.location, Vacations_errand.purpose,                       Vacations_errand.person_to_meet, Vacations_errand.notes, Vacations_errand.start_hour, Vacations_errand.end_hour, Vacations_errand.day_off,                       Departments.Dept_name FROM         Departments INNER JOIN                      EMPLOYEE ON Departments.Dept_ID = EMPLOYEE.Dept_Dept_id INNER JOIN                      Vacations_errand ON EMPLOYEE.PMP_ID = Vacations_errand.user_id  WHERE (1 = 1)  AND (dbo.EMPLOYEE.group_id <> 3 or dbo.EMPLOYEE.group_id is null) ";
        if (Session_CS.UROL_UROL_ID != 12 || Session_CS.UROL_UROL_ID != 2)
        {
            sql += " AND dbo.Departments.Dept_ID = " + Session_CS.dept_id;
        }
        if (Smrt_Srch_DropDep.SelectedValue != "")
        {
            sql += " AND dbo.Departments.Dept_ID = " + Smrt_Srch_DropDep.SelectedValue;
        }
        if (smart_employee.SelectedValue != "")
        {
            sql += " AND dbo.EMPLOYEE.PMP_ID = " + smart_employee.SelectedValue;
        }



        if (string.IsNullOrEmpty(txt_take_date_from.Text) && string.IsNullOrEmpty(txt_take_date_to.Text))
        {

            t1 = "01/01/1900";
            t2 = CDataConverter.ConvertDateTimeToFormatdmy(DateTime.MaxValue); 



        }
        else if (string.IsNullOrEmpty(txt_take_date_from.Text))
        {
            if (VB_Classes.Dates.Dates_Operation.date_validate(txt_take_date_to.Text.Trim()) != "")
            {
                t1 = "01/01/1900";

                t2 = VB_Classes.Dates.Dates_Operation.date_validate(txt_take_date_to.Text .Trim());
                sql += " AND convert ( datetime,dbo.datevalid(dbo.Vacations_errand.end_date)) < = '" + t2.ToString() + "'";
            }
            else
            {
                ShowAlertMessage("!!!!!ادخل التاريخ بطريقة صحيحة !!!!");
                return;
            }

        }
        else if (string.IsNullOrEmpty(txt_take_date_to.Text))
        {
            if (VB_Classes.Dates.Dates_Operation.date_validate(txt_take_date_from.Text.Trim()) != "")
            {
                //t1 = DateTime.ParseExact(Outbox_date_from.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
                t2 = CDataConverter.ConvertDateTimeToFormatdmy(DateTime.MaxValue);
                t1 = VB_Classes.Dates.Dates_Operation.date_validate(txt_take_date_from.Text.Trim());
                sql += " AND convert ( datetime,dbo.datevalid(dbo.Vacations_errand.start_date)) > = '" + t1.ToString() + "'";
            }
            else
            {
                ShowAlertMessage("!!!!!ادخل التاريخ بطريقة صحيحة !!!!");
                return;
            }

        }
        else
        {
            if (VB_Classes.Dates.Dates_Operation.date_validate(txt_take_date_to.Text.Trim()) != "" && VB_Classes.Dates.Dates_Operation.date_validate(txt_take_date_from.Text.Trim()) != "")
            {
                //t1 = DateTime.ParseExact(Outbox_date_from.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
                //t2 = DateTime.ParseExact(Outbox_date_to.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
                t2 = VB_Classes.Dates.Dates_Operation.date_validate(txt_take_date_to.Text.Trim());
                t1 = VB_Classes.Dates.Dates_Operation.date_validate(txt_take_date_from.Text.Trim());
                sql += " AND convert ( datetime,dbo.datevalid(dbo.Vacations_errand.start_date)) > = '" + t1.ToString() + "'";
                sql += " AND convert ( datetime,dbo.datevalid(dbo.Vacations_errand.end_date)) < = '" + t2.ToString() + "'";
            }
            else
            {
                ShowAlertMessage("!!!!!ادخل التاريخ بطريقة صحيحة !!!!");
                return;
            }
        }
        ///////////////////////////////////////////////////////////////////// end check on sign_end _date/////////////////////////////////////
        DateTime date3 = CDataConverter.ConvertToDate(t1);
        DateTime date4 = CDataConverter.ConvertToDate(t2); 
        if (date4.Subtract(date3).Days < 0)
        {
            ShowAlertMessage("!!!!!التاريخ الأول يجب ان يكون قبل التاريخ الثاني !!!!");
            return;
        }

        sql += " ORDER BY Vacations_errand.id desc";

        DataTable dt = General_Helping.GetDataTable(sql);
        gvMain_errand.DataSource = dt;
        gvMain_errand.DataBind();

        if (Session_CS.UROL_UROL_ID != 12 || Session_CS.UROL_UROL_ID != 2)
        {

            gvMain_errand.Columns[6].Visible = false;
            gvMain_errand.Columns[7].Visible = false;
        


        }

    }

    private void Search_Grid_Vac()
    {
        string t1, t2;
        string sql = "set dateformat dmy SELECT dbo.Vacations_users.id, dbo.Vacations.vacation_title,Vacations_users.vacation_id, dbo.Vacations_users.start_date, CONVERT(datetime, dbo.datevalid(dbo.Vacations_users.start_date)) AS start_date, dbo.Vacations_users.end_date, CONVERT(datetime, dbo.datevalid(dbo.Vacations_users.end_date)) AS end_date, dbo.Vacations_users.no_days, dbo.Departments.Dept_ID, dbo.Departments.Dept_name, dbo.Vacations_users.manager_approve, dbo.Vacations_users.general_manager_approve, dbo.EMPLOYEE.pmp_name,dbo.EMPLOYEE.group_id, dbo.Vacations_users.request_date, CONVERT(datetime, dbo.datevalid(dbo.Vacations_users.request_date)) AS request_date, dbo.EMPLOYEE.PMP_ID, dbo.Vacations_summary.unusual, dbo.Vacations_summary.exhibitor, dbo.Vacations_summary.sick, dbo.Vacations_summary.hajj, dbo.Vacations_summary.birth, dbo.Vacations_summary.year, dbo.Vacations_summary.repeat FROM dbo.Vacations_users INNER JOIN dbo.EMPLOYEE INNER JOIN dbo.Departments ON dbo.EMPLOYEE.Dept_Dept_id = dbo.Departments.Dept_ID ON dbo.Vacations_users.user_id = dbo.EMPLOYEE.PMP_ID INNER JOIN dbo.Vacations ON dbo.Vacations_users.vacation_id = dbo.Vacations.id LEFT OUTER JOIN dbo.Vacations_summary ON dbo.EMPLOYEE.PMP_ID = dbo.Vacations_summary.emp_id WHERE (1 = 1) and Vacations_summary.year='" + CDataConverter.ConvertDateTimeNowRtnDt().Year.ToString() + "' AND (dbo.EMPLOYEE.group_id <> 3 or dbo.EMPLOYEE.group_id is null) ";

        if (Session_CS.UROL_UROL_ID != 12 || Session_CS.UROL_UROL_ID != 2)
        {
            sql += " AND dbo.Departments.Dept_ID = " + Session_CS.dept_id ;
        }

        if (Smrt_Srch_DropDep.SelectedValue != "")
        {
            sql += " AND dbo.Departments.Dept_ID = " + Smrt_Srch_DropDep.SelectedValue;
        }
        if (smart_employee.SelectedValue != "")
        {
            sql += " AND dbo.EMPLOYEE.PMP_ID = " + smart_employee.SelectedValue;
        }



        if (string.IsNullOrEmpty(txt_take_date_from.Text) && string.IsNullOrEmpty(txt_take_date_to.Text))
        {

            t1 = "01/01/1900";
            t2 = CDataConverter.ConvertDateTimeToFormatdmy(DateTime.MaxValue); 



        }
        else if (string.IsNullOrEmpty(txt_take_date_from.Text))
        {
            if (VB_Classes.Dates.Dates_Operation.date_validate(txt_take_date_to.Text.Trim()) != "")
            {
                t1 = "01/01/1900";

                t2 = VB_Classes.Dates.Dates_Operation.date_validate(txt_take_date_to.Text.Trim());
                sql += " AND convert ( datetime,dbo.datevalid(dbo.Vacations_users.end_date)) < = '" + t2.ToString() + "'";
            }
            else
            {
                ShowAlertMessage("!!!!!ادخل التاريخ بطريقة صحيحة !!!!");
                return;
            }

        }
        else if (string.IsNullOrEmpty(txt_take_date_to.Text))
        {
            if (VB_Classes.Dates.Dates_Operation.date_validate(txt_take_date_from.Text.Trim()) != "")
            {
                //t1 = DateTime.ParseExact(Outbox_date_from.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
                t2 = CDataConverter.ConvertDateTimeToFormatdmy(DateTime.MaxValue);

                
                t1 = VB_Classes.Dates.Dates_Operation.date_validate(txt_take_date_from.Text.Trim());
                sql += " AND convert ( datetime,dbo.datevalid(dbo.Vacations_users.start_date)) > = '" + t1.ToString() + "'";
            }
            else
            {
                ShowAlertMessage("!!!!!ادخل التاريخ بطريقة صحيحة !!!!");
                return;
            }

        }
        else
        {
            if (VB_Classes.Dates.Dates_Operation.date_validate(txt_take_date_to.Text.Trim()) != "" && VB_Classes.Dates.Dates_Operation.date_validate(txt_take_date_from.Text.Trim()) != "")
            {
                //t1 = DateTime.ParseExact(Outbox_date_from.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
                //t2 = DateTime.ParseExact(Outbox_date_to.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
                t2 = VB_Classes.Dates.Dates_Operation.date_validate(txt_take_date_to.Text.Trim());
                t1 = VB_Classes.Dates.Dates_Operation.date_validate(txt_take_date_from.Text.Trim());
                sql += " AND convert ( datetime,dbo.datevalid(dbo.Vacations_users.start_date)) > = '" + t1.ToString() + "'";
                sql += " AND convert ( datetime,dbo.datevalid(dbo.Vacations_users.end_date)) < = '" + t2.ToString() + "'";
            }
            else
            {
                ShowAlertMessage("!!!!!ادخل التاريخ بطريقة صحيحة !!!!");
                return;
            }
        }
        ///////////////////////////////////////////////////////////////////// end check on sign_end _date/////////////////////////////////////
        DateTime date3 = CDataConverter.ConvertToDate(t1);
        DateTime date4 = CDataConverter.ConvertToDate(t2); 
        if (date4.Subtract(date3).Days < 0)
        {
            ShowAlertMessage("!!!!!التاريخ الأول يجب ان يكون قبل التاريخ الثاني !!!!");
            return;
        }

        sql += " ORDER BY Vacations_users.id desc ";

        DataTable dt = General_Helping.GetDataTable(sql);
        gvMain.DataSource = dt;
        gvMain.DataBind();



        //foreach (GridViewRow row in gvMain.Rows)
        //{
        //    CheckBox chk = (CheckBox)row.FindControl("chkSent");
        //    Label lbl_emp = (Label)row.FindControl("lbl_emp");

        if (Session_CS.UROL_UROL_ID != 12 || Session_CS.UROL_UROL_ID != 2)
        {
            //ImageButton img = (ImageButton)row.FindControl("ImgBtnEdit");
            //ImageButton img2 = (ImageButton)row.FindControl("ImgBtnDelete");

            //img.Visible = false;
            //img2.Visible = false;

            gvMain.Columns[6].Visible = false;
            gvMain.Columns[7].Visible = false;
            gvMain.Columns[8].Visible = false;


        }

        //}



    }


    public string Get_Staus(object G_STatus, object M_status)
    {
        string GMApprove = Convert.ToString(G_STatus);
        string MApprove = Convert.ToString(M_status);
        string VocStat = "";
        if (GMApprove == "1")
        {
            VocStat = "تم الموافقة";
        }
        else if (GMApprove == "2" || MApprove == "2")
        {
            VocStat = "تم الرفض";
        }
        else
        {
            VocStat = "لم تنظر";
        }

        return VocStat;

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


    protected void gvMain_errand_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvMain_errand.PageIndex = e.NewPageIndex;
        Search_Grid_err();
    }


    protected void gvMain_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvMain.PageIndex = e.NewPageIndex;
        Search_Grid_Vac();
    }

    public string IpAddress()
    {
        string name = "";
        string ip = "";
        try
        {
            name = System.Net.Dns.GetHostName();
            ip = System.Net.Dns.GetHostAddresses(name).GetValue(1).ToString();
            return ip;
        }
        catch
        {
            name = System.Net.Dns.GetHostName();
            ip = System.Net.Dns.GetHostAddresses(name).GetValue(0).ToString();
            return ip;
        }
    }

}
