using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class WebForms_Vacation_Mng_ALL_User_Summery : System.Web.UI.Page
{
    Session_CS Session_CS = new Session_CS();
    private string sql_Connection = Database.ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Smart_Search_mang.Show_OrgTree = true;
            fill_structure();
        }
    }
    protected void fill_structure()
    {

        string Query = "";
        Query = "SELECT  * from    Departments  where foundation_id='" + Session_CS.foundation_id + "'";

        Smart_Search_mang.datatble = General_Helping.GetDataTable(Query);
        Smart_Search_mang.Value_Field = "Dept_id";
        Smart_Search_mang.Text_Field = "Dept_name";
        Smart_Search_mang.DataBind();


    }
    protected override void OnInit(EventArgs e)
    {

       // fill_depts();
        //Smrt_Srch_user.sql_Connection = sql_Connection;
        //Smrt_Srch_user.Query = "select PMP_ID,pmp_name from EMPLOYEE";
        //Smrt_Srch_user.Value_Field = "PMP_ID";
        //Smrt_Srch_user.Text_Field = "pmp_name";
        //Smrt_Srch_user.DataBind();
        this.Smrt_Srch_user.Value_Handler += new Smart_Search.Delegate_Selected_Value(MOnMember_Data);
        this.Smart_Search_mang.Value_Handler += new Smart_Search.Delegate_Selected_Value(MOnMember_Data_Depart);
        base.OnInit(e);

    }

    private void MOnMember_Data_Depart(string Value)
    {
        if (Value != "")
        {
            fill_emplyees();
        }
        else
        {
            Smrt_Srch_user.Clear_Controls();

        }
    }

   
    protected void fill_depts()
    {
        Smart_Search_mang.sql_Connection = sql_Connection;
        //string Query = "select Dept_ID,Dept_name from Departments where sec_sec_id= '" + Session_CS.sec_id.ToString() + "'";
        string Query = "select Dept_ID,Dept_name from Departments inner join dbo.Sectors  on dbo.Sectors.Sec_id=Departments.sec_sec_id where sec_sec_id= '" + Session_CS.sec_id.ToString() + "' and dbo.Sectors.foundation_id='" + Session_CS.foundation_id + "'";
        Smart_Search_mang.datatble = General_Helping.GetDataTable(Query);
        Smart_Search_mang.Value_Field = "Dept_ID";
        Smart_Search_mang.Text_Field = "Dept_name";
        Smart_Search_mang.DataBind();


    }
    protected void fill_emplyees()
    {
        Smrt_Srch_user.sql_Connection = sql_Connection;

        //Smrt_Srch_user.Query = "SELECT pmp_id, pmp_name FROM employee where Dept_Dept_id =  " + Smart_Search_mang.SelectedValue;
        string Query = "SELECT pmp_id, pmp_name FROM employee where EMPLOYEE.foundation_id='" + Session_CS.foundation_id + "' and  Dept_Dept_id =  " + Smart_Search_mang.SelectedValue;
        Smrt_Srch_user.datatble = General_Helping.GetDataTable(Query);
        Smrt_Srch_user.Value_Field = "pmp_id";
        Smrt_Srch_user.Text_Field = "pmp_name";
        Smrt_Srch_user.DataBind();

    }


    private void MOnMember_Data(string Value)
    {
        if (CDataConverter.ConvertToInt(Value) > 0)
        {
            
            Vacations_summary_DT obj = Vacations_summary_DB.SelectBy_Emp_ID(CDataConverter.ConvertToInt(Value));
            if (obj.id > 0)
            {
                txt_exhibitor.Text = obj.exhibitor.ToString();
                txt_sick.Text = obj.sick.ToString();
                txt_unusual.Text = obj.unusual.ToString();
                txt_exihib_total.Text = obj.exhibitor_total.ToString();
                txt_unusual_total.Text = obj.unusual_total.ToString();
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
                    txt_exihib_total.Text = dt.Rows[1]["vacation_days"].ToString();
                    txt_unusual_total .Text = dt.Rows[0]["vacation_days"].ToString();
                }

                // create field for user in vacation summary

            }
        }
    }

    protected void BtnVacationRequest_Click(object sender, EventArgs e)
    {
        int operation;
        //if (CheckValidate())
        //{
        //    Vacations_DT VacObj = new Vacations_DT();
        //    VacObj.vacation_id = CDataConverter.ConvertToInt(DDLVacationType.SelectedValue);
        //    VacObj.user_id = CDataConverter.ConvertToInt(Smrt_Srch_user.SelectedValue);
        //    VacObj.alternative_user_id = CDataConverter.ConvertToInt(Smrt_Srch_user.SelectedValue); ;
        //    VacObj.request_user_id = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
        //    VacObj.start_date = txtStartDate.Text;
        //    VacObj.end_date = txtEndDate.Text;
        //    VacObj.no_days = CDataConverter.ConvertToInt(no_days.Text);
        //    VacObj.manager_approve = 1;
        //    VacObj.general_manager_approve = 1;
        //    VacObj.request_date = VacObj.start_date;
        //    VacObj.dept_id = 0;
        //    int result = Vacations_DB.Save(VacObj);
        //    if (result > 0)
        //    {
        //        Fill_Grid();
        //        Clear_Cntrl();
        //        Vacations_DB.vacation_summary(CDataConverter.ConvertToInt(result));
        //        MOnMember_Data(Smrt_Srch_user.SelectedValue);
        //        Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم الحفظ بنجاح')</script>");
        //    }
        //}
        Vacations_summary_DT obj = Vacations_summary_DB.SelectBy_Emp_ID(CDataConverter.ConvertToInt(Smrt_Srch_user.SelectedValue));
        if (obj.id > 0)
        {
            obj.exhibitor = CDataConverter.ConvertToInt(txt_exhibitor.Text);
            obj.sick = CDataConverter.ConvertToInt(txt_sick.Text);
            obj.unusual = CDataConverter.ConvertToInt(txt_unusual.Text);
            obj.unusual_total = CDataConverter.ConvertToInt ( txt_unusual_total.Text );
            obj.exhibitor_total = CDataConverter.ConvertToInt(txt_exihib_total.Text );
            Vacations_summary_DB.Save(obj);
            operation = (int)Project_Log_DB.Action.edit;
            Project_Log_DB.FillLog(CDataConverter.ConvertToInt(obj.id), operation, Project_Log_DB.operation.vacations_balance);

        }
        else
        {
            Vacations_summary_DT obj_New = new Vacations_summary_DT();
            obj_New.exhibitor = CDataConverter.ConvertToInt(txt_exhibitor.Text);
            obj_New.sick = CDataConverter.ConvertToInt(txt_sick.Text);
            obj_New.unusual = CDataConverter.ConvertToInt(txt_unusual.Text);
            obj_New.emp_id = CDataConverter.ConvertToInt(Smrt_Srch_user.SelectedValue);
            obj_New.year = CDataConverter.ConvertDateTimeNowRtnDt().Year.ToString();
            obj_New.unusual_total = CDataConverter.ConvertToInt(txt_unusual_total.Text); 
            obj_New.exhibitor_total = CDataConverter.ConvertToInt(txt_exihib_total.Text);
            Vacations_summary_DB.Save(obj_New);

        }

        Smrt_Srch_user.Clear_Selected();
        txt_unusual.Text =
        txt_sick.Text =
        txt_exhibitor.Text = "";

        Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم الحفظ بنجاح')</script>");
    }

    
}
