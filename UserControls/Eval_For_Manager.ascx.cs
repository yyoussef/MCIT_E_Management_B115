using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportAppServer.DataDefModel;
using System.IO;
using System.Net;


public partial class UserControls_Eval_For_manager : System.Web.UI.UserControl
{
    private string sql_Connection = Database.ConnectionString;
    Session_CS Session_CS = new Session_CS();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
          
            Ddl_Sectors.SelectedValue = Session_CS.sec_id.ToString();
            Ddl_Sectors.DataBind();
            Ddl_Sectors_SelectedIndexChanged(sender, e);

            if (Session_CS.group_id.ToString() == "12")
            {

                Ddl_Sectors.Enabled = true;
            }
            else
            {

                Ddl_Sectors.Enabled = false;
            }


        }
    }

    protected override void OnInit(EventArgs e)
    {
        this.Smart_Pmp_Id.Value_Handler += new Smart_Search.Delegate_Selected_Value(emp_Data);
    }
    private void emp_Data(string Value)
    {

        if (Value != "")
        {



           
            DataTable dt = Evaluation_For_Employee_DB.Select_Emp_Info(CDataConverter.ConvertToInt(Value));//get general information for the selected employee

            if (dt.Rows.Count > 0)
            {
                txt_job_no.Text = dt.Rows[0]["job_no"].ToString();
                txt_pmp_title.Text = dt.Rows[0]["pmp_title"].ToString();
                txt_Hire_date.Text = dt.Rows[0]["Hire_date"].ToString();

                
            }

            else
            {
                btn_Save.Text = "حفظ";
            }
            ShowHide();
            SetManagerData(Convert.ToInt32(Smart_Pmp_Id.SelectedValue));
            
        }

    }
    public void clear_fields()
    {
        txt_Hire_date.Text = "";
        txt_job_no.Text = "";
        txt_pmp_title.Text = "";
        btn_Save.Text = "حفظ";
    }
    #region Methods
    private void fil_grid()
    {
        int main_id = 0;
        int sub_id = 0;
        int eval_id = 0;


        ///////////////////////////////////check if the manager is evaluated before from this employee //////////////////////////

        DataTable Get_Evaluation_dt = Evaluation_For_Manager_DB.Get_EvaluationID(CDataConverter.ConvertToInt(Smart_Pmp_Id.SelectedValue), CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()));
        if (Get_Evaluation_dt.Rows.Count > 0)
        {
            eval_id = CDataConverter.ConvertToInt(Get_Evaluation_dt.Rows[0]["Evaluation_id"].ToString());

        }

        //////////////////////// if the employee was evaluated before get the new evaluation items added after employee evaluation and add it on evaluation for manager table ///////////////////////

        DataTable EvalItems_Managernotexis_dt = Evaluation_For_Manager_DB.Evaluation_Items_Managernotexist(CDataConverter.ConvertToInt(Smart_Pmp_Id.SelectedValue), CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()));

        if (EvalItems_Managernotexis_dt.Rows.Count > 0)
        {
            main_id = CDataConverter.ConvertToInt(EvalItems_Managernotexis_dt.Rows[0]["FK_Main_Item_Id"].ToString());
            sub_id = CDataConverter.ConvertToInt(EvalItems_Managernotexis_dt.Rows[0]["Sub_Item_Id"].ToString());
      

            Evaluation_Main_Manager_DT obj = new Evaluation_Main_Manager_DT();
            obj.Id = 0;
            obj.Evaluation_id = eval_id;
            obj.Emp_Note = DBNull.Value.ToString();
            obj.Main_Item_Id = main_id;
            obj.Sub_Item_Id = sub_id;
            obj.Degree_Id = 0;
            obj.HR_Note = DBNull.Value.ToString();

            Evaluation_Main_Manager_DB.Save(obj);

        }

        

        DataTable Select_Evaluation_dt = Evaluation_For_Manager_DB.Select_Evaluation_Manager_For_Employee_Mngr(CDataConverter.ConvertToInt(Smart_Pmp_Id.SelectedValue), CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()));

        gvEvaluateManager.DataSource = Select_Evaluation_dt;
        gvEvaluateManager.DataBind();
        Set_Selected_DDL(Select_Evaluation_dt);


    }

    private void Set_Selected_DDL(DataTable dt)
    {
        int rowCount = 0;
        foreach (DataRow row in dt.Rows)
        {

            ((DropDownList)gvEvaluateManager.Rows[rowCount].FindControl("ddl_Direct_Emp_Degree_Id")).SelectedValue = dt.Rows[rowCount]["Degree_Id"].ToString();


            rowCount++;
        }
    }

    private void SetManagerData(int manager_id)
    {
        btn_Save.Enabled = true;
        btn_finish.Enabled = true;

        fil_grid();
        string sql = "";
   


        Evaluation_For_Manager_DT obj = Evaluation_For_Manager_DB.SelectByID(Convert.ToInt32(Smart_Pmp_Id.SelectedValue), Convert.ToInt32(Session_CS.pmp_id.ToString()));
        if (obj.Finished.ToString() == "True")
        {
            btn_Save.Enabled = false;
            btn_finish.Enabled = false;
        }
        //--------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------

        string note_type="Emp";
        DataTable dt_note = Evaluation_For_Manager_DB.Evaluation_Manager_Notesselect(obj.Evaluation_id,note_type);
        int i = 0;
        if (dt_note.Rows.Count <= 0)
        {
            for (i = 0; i < 3; i++)
            {
                DataRow dr = null;
                dr = dt_note.NewRow();
                dt_note.Rows.Add(dr);
            }
        }
        gvEmpGeneralNotes.DataSource = dt_note;
        gvEmpGeneralNotes.DataBind();

        i = 0;
        foreach (GridViewRow row in gvEmpGeneralNotes.Rows)
        {

            ((TextBox)gvEmpGeneralNotes.Rows[i].FindControl("txt_Emp_Gen_Notes")).Text
                = dt_note.Rows[i]["Note"].ToString();
            i++;
        }


        //--------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------

        





    }
    private void ShowHide()
    {
        gvEvaluateManager.Visible = true;
      //  gvEvaluateManager.Columns[4].Visible = false;
        
    }
      
    void fil_employee()
    {
        Smart_Pmp_Id.sql_Connection = sql_Connection;
        //Smart_Pmp_Id.Query =
        //    "SELECT distinct * ," + "\r\n" +
        //    "       employeeName.pmp_name empName," + "\r\n" +
        //    "       ManagerName.pmp_name MngrName," + "\r\n" +
        //    "       Serial = ROW_NUMBER () OVER (ORDER BY Employee_Managers.Emp_Mngr_ID ASC)," + "\r\n" +
        //    "       CASE mngr_level" + "\r\n" +
        //    "          WHEN 1 THEN 'مدير مباشر'" + "\r\n" +
        //    "          ELSE 'مدير اعلي'" + "\r\n" +
        //    "       END" + "\r\n" +
        //    "          managerlevel" + "\r\n" +
        //    "  FROM       Employee_Managers" + "\r\n" +
        //    "          LEFT JOIN" + "\r\n" +
        //    "             EMPLOYEE employeeName" + "\r\n" +
        //    "          ON Employee_Managers.emp_ID = employeeName.pmp_id" + "\r\n" +
        //    "       LEFT JOIN" + "\r\n" +
        //    "          EMPLOYEE ManagerName" + "\r\n" +
        //    "       ON Employee_Managers.Mngr_Emp_ID = ManagerName.pmp_id" + "\r\n" +
        //    " WHERE Employee_Managers.emp_id ='" + Session_CS.pmp_id + "'  and Employee_Managers.Mngr_Level=1";
        string Query =
                "SELECT distinct * ," + "\r\n" +
                "       employeeName.pmp_name empName," + "\r\n" +
                "       ManagerName.pmp_name MngrName," + "\r\n" +
                "       Serial = ROW_NUMBER () OVER (ORDER BY Employee_Managers.Emp_Mngr_ID ASC)," + "\r\n" +
                "       CASE mngr_level" + "\r\n" +
                "          WHEN 1 THEN 'مدير مباشر'" + "\r\n" +
                "          ELSE 'مدير اعلي'" + "\r\n" +
                "       END" + "\r\n" +
                "          managerlevel" + "\r\n" +
                "  FROM       Employee_Managers" + "\r\n" +
                "          LEFT JOIN" + "\r\n" +
                "             EMPLOYEE employeeName" + "\r\n" +
                "          ON Employee_Managers.emp_ID = employeeName.pmp_id" + "\r\n" +
                "       LEFT JOIN" + "\r\n" +
                "          EMPLOYEE ManagerName" + "\r\n" +
                "       ON Employee_Managers.Mngr_Emp_ID = ManagerName.pmp_id" + "\r\n" +
                " WHERE Employee_Managers.emp_id ='" + Session_CS.pmp_id + "'  and Employee_Managers.Mngr_Level=1";
        Smart_Pmp_Id.datatble = General_Helping.GetDataTable(Query);
        Smart_Pmp_Id.Show_Code = false;
       
        Smart_Pmp_Id.Value_Field = "mngr_emp_id";
        Smart_Pmp_Id.Text_Field = "mngrname";
        Smart_Pmp_Id.DataBind();
        this.Smart_Pmp_Id.Value_Handler += new Smart_Search.Delegate_Selected_Value(MOnMember_Data_Emp);

    }
    private void MOnMember_Data_Emp(string Value)
    {
        if (Value != "")
        {
            //DataTable dtEmp = Evaluation_For_Employee_DB.Select_Emp_Info(CDataConverter.ConvertToInt(Value));//get general information for the selected employee
            //if (dtEmp.Rows.Count > 0)
            //{
            //    DataRow dr = dtEmp.Rows[0];
            //    txt_Hire_date.Text = Convert.ToString(dr["Hire_date"].ToString());
            //    txt_pmp_title.Text = Convert.ToString(dr["pmp_title"].ToString());
            //    txt_job_no.Text = Convert.ToString(dr["job_no"].ToString());
            //    fil_grid();
           // }
        }
    }




    #endregion


    #region Event Handlers

    protected void btn_Save_Click(object sender, EventArgs e)
    {
        if (Check_Main_Valid())
        {
            

            {
                Evaluation_For_Manager_DT obj = Evaluation_For_Manager_DB.SelectByID(Convert.ToInt32(Smart_Pmp_Id.SelectedValue), Convert.ToInt32(Session_CS.pmp_id.ToString()));

                if (obj.Evaluation_id <= 0)
                {

                    obj.Evaluation_id = 0;

                    //obj.Month = DateTime.Now.Month;
                    //obj.Year = DateTime.Now.Year;

                    obj.Month = CDataConverter.ConvertDateTimeNowRtnDt().Month;
                    obj.Year = CDataConverter.ConvertDateTimeNowRtnDt().Year;
                    obj.Pmp_Id = CDataConverter.ConvertToInt(Smart_Pmp_Id.SelectedValue);

                    obj.Evaluator_emp_ID = CDataConverter.ConvertToInt(Session_CS.pmp_id);

                    hidden_Evaluation_id.Value = Evaluation_For_Manager_DB.Save(obj).ToString();
                }
                else
                {
                    hidden_Evaluation_id.Value = obj.Evaluation_id.ToString();
                    Evaluation_Main_Manager_DB.Delete(obj.Evaluation_id);
                }

                foreach (GridViewRow row in gvEvaluateManager.Rows)
                {
                    Label main = (Label)row.FindControl("lbl_Main_Item_Id");
                    Label sub = (Label)row.FindControl("lbl_Sub_Item_Id");
                    DropDownList degree = (DropDownList)row.FindControl("ddl_Direct_Emp_Degree_Id");
                    TextBox emp_note = (TextBox)row.FindControl("txt_emp_Note");
                   
                        Evaluation_Main_Manager_DT main__mngr = new Evaluation_Main_Manager_DT();
                        main__mngr.Evaluation_id = Convert.ToInt32(hidden_Evaluation_id.Value);
                        main__mngr.Main_Item_Id = Convert.ToInt32(main.Text);
                        main__mngr.Sub_Item_Id = Convert.ToInt32(sub.Text);
                        main__mngr.Degree_Id = Convert.ToInt32(degree.SelectedValue);
                        main__mngr.Emp_Note = emp_note.Text;
                        int x = Evaluation_Main_Manager_DB.Save(main__mngr);
                    //}
                }


                Evaluation_Manager_Notes_DT notes_obj = Evaluation_Manager_Notes_DB.SelectByID(obj.Evaluation_id, "Emp");
                if (notes_obj.Evaluation_id > 0)
                {
                    foreach (GridViewRow row in gvEmpGeneralNotes.Rows)
                    {
                        Evaluation_Manager_Notes_DB.Delete(notes_obj.Evaluation_id, "Emp");
                    }
                }

                foreach (GridViewRow row in gvEmpGeneralNotes.Rows)
                {
                    Evaluation_Manager_Notes_DT notes = new Evaluation_Manager_Notes_DT();
                    notes.Evaluation_id = obj.Evaluation_id;
                    TextBox txt_Emp_Gen_Notes = (TextBox)row.FindControl("txt_Emp_Gen_Notes");
                    notes.Note = txt_Emp_Gen_Notes.Text;
                    notes.Note_Type = "Emp";
                    Evaluation_Manager_Notes_DB.Save(notes);
                }


                notes_obj = Evaluation_Manager_Notes_DB.SelectByID(obj.Evaluation_id, "HR");
                if (notes_obj.Evaluation_id > 0)
                {
                    foreach (GridViewRow row in gvEmpGeneralNotes.Rows)
                    {
                        Evaluation_Manager_Notes_DB.Delete(notes_obj.Evaluation_id, "HR");
                    }
                }

             



                Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم الحفظ بنجاح')</script>");
             
            }
        }
    }



    protected void btn_finish_Click(object sender, EventArgs e)
    {



        Evaluation_For_Manager_DT obj = Evaluation_For_Manager_DB.SelectByID(CDataConverter.ConvertToInt(Smart_Pmp_Id.SelectedValue), Convert.ToInt32(Session_CS.pmp_id.ToString()));
        if (obj.Evaluation_id > 0)
        {
            obj.Finished = true;

            Evaluation_For_Manager_DB.Save(obj);
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('تم انهاء التقييم')</script>");
            btn_finish.Enabled = false;
            btn_Save.Enabled = false;
        }
        else
        {
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لم يتم حفظ التقييم ليتم الانتهاء')</script>");
            return;
        }

    }

    protected void Ddl_Sectors_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (CDataConverter.ConvertToInt(Ddl_Sectors.SelectedValue) > 0)
        {
            if (Request["pmp_id"] != null)
            {
                fil_employee();
                Smart_Pmp_Id.SelectedValue = Request["pmp_id"].ToString();

            }
            else
                fil_employee();
        }
        else
        {
            Smart_Pmp_Id.Clear_Controls();

        }
    }

  

    #endregion

    #region Functions


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
    public bool Get_Enabled_Hr()
    {
        if (hidden_hr.Value == "1")
            return true;
        else
            return false;

    }

    private bool Check_Main_Valid()
    {
        if (Smart_Pmp_Id.SelectedValue != "")
            return true;
        else
        {
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('يجب إختيار الموظف اولا')</script>");
            return false;
        }
    }





    #endregion

    #region Methods


    private void Set_Hr_Last_Eval_ID()
    {
  

        DataTable dt = Evaluation_Main_DB.Set_Hr_Last_Eval_ID(CDataConverter.ConvertToInt(Smart_Pmp_Id.SelectedValue));


        if (dt.Rows.Count > 0)
        {

            hidden_Evaluation_id.Value = dt.Rows[0]["Evaluation_id"].ToString();

        }
        else
            hidden_Evaluation_id.Value = "";
      
    }

    private void SaveHrNotes()
    {
        Evaluation_For_Employee_DT obj = new Evaluation_For_Employee_DT();
        if (hidden_Evaluation_id.Value == "")
        {
            obj.Evaluation_id = 0;

        }
        else
            obj.Evaluation_id = CDataConverter.ConvertToInt(hidden_Evaluation_id.Value);

        //obj.Month = DateTime.Now.Month; //CDataConverter.ConvertToInt(ddl_month.SelectedItem.Text);
        //obj.Year = DateTime.Now.Year;// CDataConverter.ConvertToInt(ddl_year.SelectedItem.Text);

        obj.Month = CDataConverter.ConvertDateTimeNowRtnDt().Month ; //CDataConverter.ConvertToInt(ddl_month.SelectedItem.Text);
        obj.Year = CDataConverter.ConvertDateTimeNowRtnDt().Year;// CDataConverter.ConvertToInt(ddl_year.SelectedItem.Text);

        obj.Pmp_Id = CDataConverter.ConvertToInt(Smart_Pmp_Id.SelectedValue);
        obj.Top_Mng_Finished = false;
        obj.Evaluator_emp_ID = 0;
        hidden_Evaluation_id.Value = Evaluation_For_Employee_DB.Save(obj).ToString();
        //clear previous hr evaluation id
        ClearPrevHrEvaluation(CDataConverter.ConvertToInt( hidden_Evaluation_id.Value));
     
    }


   

    private void ClearPrevHrEvaluation(int eval_ID)
    {
        Evaluation_Main_DB.Evaluation_Main_DeletebyID(eval_ID);

    }

    #endregion

}
