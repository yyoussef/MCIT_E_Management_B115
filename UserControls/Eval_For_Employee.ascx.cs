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
using ReportsClass;

public partial class UserControls_Eval_For_Employee : System.Web.UI.UserControl
{
    private string sql_Connection = Database.ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Ddl_Sectors.SelectedValue = Session_CS.sec_id.ToString();
            Ddl_Sectors.DataBind();
            Ddl_Sectors_SelectedIndexChanged(sender, e);
            Ddl_Sectors.Enabled = false;
            
        }
    }

    protected override void OnInit(EventArgs e)
    {

        this.Smart_Pmp_Id.Value_Handler += new Smart_Search.Delegate_Selected_Value(MOnMember_Data_Emp);
        
    }

    #region Methods



    private void MOnMember_Data_Depart(string Value)
    {
        if (Value != "")
        {
            fil_employee();

        }
        else
        {
            Smart_Pmp_Id.Clear_Controls();
            MOnMember_Data_Emp("");
        }
    }

    void fil_employee()
    {
        Smart_Pmp_Id.sql_Connection = sql_Connection;

        string Query = " SELECT  distinct   EMPLOYEE.PMP_ID, EMPLOYEE.pmp_name, Employee_Managers.Mngr_Emp_ID FROM         EMPLOYEE INNER JOIN                       Employee_Managers ON EMPLOYEE.PMP_ID = Employee_Managers.Emp_ID WHERE     (EMPLOYEE.workstatus = 1)  ";
        Query += " and  Mngr_Emp_ID=" + Session_CS.pmp_id.ToString();
        Smart_Pmp_Id.datatble = General_Helping.GetDataTable(Query);
        Smart_Pmp_Id.Show_Code = false;
        Smart_Pmp_Id.Value_Field = "pmp_id";
        Smart_Pmp_Id.Text_Field = "pmp_name";
        Smart_Pmp_Id.DataBind();
        this.Smart_Pmp_Id.Value_Handler += new Smart_Search.Delegate_Selected_Value(MOnMember_Data_Emp);
    }

    private void MOnMember_Data_Emp(string Value)
    {
        if (Value != "")
        {
            DataTable dtEmp = Evaluation_For_Employee_DB.Select_Emp_Info(CDataConverter.ConvertToInt(Value));//get general information for the selected employee
            if (dtEmp.Rows.Count > 0)
            {
                DataRow dr = dtEmp.Rows[0];
                txt_Hire_date.Text = Convert.ToString(dr["Hire_date"].ToString());
                txt_pmp_title.Text = Convert.ToString(dr["pmp_title"].ToString());
                txt_job_no.Text = Convert.ToString(dr["job_no"].ToString());
                tr_grade.Visible = true;

            }

            hidden_hr.Value = "0";


            Evaluation_For_Employee_Select_Info_Mngr_SP obj = new Evaluation_For_Employee_Select_Info_Mngr_SP();//to know mngr type wether if direct or higher
            obj.Emp_ID = CDataConverter.ConvertToInt(Value);
            obj.Mngr_ID = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
            DataTable dt = Evaluation_For_Employee_Select_Info_Mngr_SP.Get_DataTable(obj);
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];



                tr_Grid.Visible = true;//xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
                hidden_Evaluation_id.Value = "";


                if (CDataConverter.ConvertToInt(dr["Mngr_Level"].ToString()) == 1)
                {
                    hidden_direct_mngr.Value = "1";
                    hidden_top_mngr.Value = "0";

                    DataTable dt_mng1 = Evaluation_Main_DB.Select_Employee_Managers(CDataConverter.ConvertToInt(Smart_Pmp_Id.SelectedValue), 1);
                    if (dt_mng1.Rows.Count > 0)
                        hidden_Direct_emp_id.Value = dt_mng1.Rows[0]["Mngr_Emp_ID"].ToString();


                }
                else if (CDataConverter.ConvertToInt(dr["Mngr_Level"].ToString()) == 2)
                {
                    hidden_top_mngr.Value = "1";
                    hidden_direct_mngr.Value = "0";

                    DataTable dt_mng = Evaluation_Main_DB.Select_Employee_Managers(CDataConverter.ConvertToInt(Smart_Pmp_Id.SelectedValue), 1);
                    if (dt_mng.Rows.Count > 0)
                        hidden_Direct_emp_id.Value = dt_mng.Rows[0]["Mngr_Emp_ID"].ToString();

                }




                fil_grid();//fill evaluation gridview



                DataTable dt_btn = Evaluation_Main_DB.Evaluation_Employee_Finished(CDataConverter.ConvertToInt(Smart_Pmp_Id.SelectedValue), CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()));
                if (dt_btn.Rows.Count > 0)
                {
                    if (hidden_direct_mngr.Value == "1")
                    {
                        if (dt_btn.Rows[0]["Direct_Mng_Finished"].ToString() == "True")
                        {
                            btn_finish.Enabled = false;
                            btn_Save.Enabled = false;

                        }
                        else
                        {
                            btn_finish.Enabled = true;
                            btn_Save.Enabled = true;
                        }
                    }
                    else if (hidden_top_mngr.Value == "1")
                    {
                        if (dt_btn.Rows[0]["Top_Mng_Finished"].ToString() == "True")
                        {
                            btn_finish.Enabled = false;
                            btn_Save.Enabled = false;
                        }
                        else
                        {
                            btn_finish.Enabled = true;
                            btn_Save.Enabled = true;
                        }
                    }
                }
                else
                {
                    btn_finish.Enabled = true;
                    btn_Save.Enabled = true;
                }

                fill_Grid_weeknes();
                fill_Grid_Training();

                Get_Enabled_Direct_mngr();
                Get_Enabled_Top_mngr();



            }
            //}
        }
        else
        {
            txt_Hire_date.Text =
            txt_pmp_title.Text =
            txt_job_no.Text = "";


            tr_Grid.Visible = false;
            hidden_Evaluation_id.Value = "";

        }

    }

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

        ////////////////////////// if the employee was evaluated before get the new evaluation items added after employee evaluation and add it on evaluation for employee table ///////////////////////

        DataTable EvalItems_Managernotexis_dt = Evaluation_For_Employee_DB.Evaluationemp_Items_Managernotexist(CDataConverter.ConvertToInt(Smart_Pmp_Id.SelectedValue), CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()));

        if (EvalItems_Managernotexis_dt.Rows.Count > 0)
        {
            main_id = CDataConverter.ConvertToInt(EvalItems_Managernotexis_dt.Rows[0]["Main_Item_Id"].ToString());
            sub_id = CDataConverter.ConvertToInt(EvalItems_Managernotexis_dt.Rows[0]["Sub_Item_Id"].ToString());



            Evaluation_Main_DT obj = new Evaluation_Main_DT();
            obj.Id = 0;
            obj.Evaluation_id = eval_id;
            obj.Direct_Emp_Note = DBNull.Value.ToString();
            obj.Top_Emp_Note = DBNull.Value.ToString();
            obj.Direct_Emp_Degree = 0;
            obj.Direct_Emp_Degree_Id = 0;
            obj.Top_Emp_Degree = 0;
            obj.Top_Emp_Degree_Id = 0;
            obj.HR_Note = DBNull.Value.ToString();
            obj.Main_Item_Id = main_id;
            obj.Sub_Item_Id = sub_id;
            Evaluation_Main_DB.Save(obj);



        }







        /////////////////////////////////////////////////////////////

        DataTable dt = Evaluation_For_Employee_DB.Select_Evaluation_For_Employee_Mngr(CDataConverter.ConvertToInt(Smart_Pmp_Id.SelectedValue), CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()));
        Gridview1.DataSource = dt;
        Gridview1.DataBind();
        Set_Selected_DDL(dt);

        if (CDataConverter.ConvertToInt(hidden_top_mngr.Value) > 0)
        {
            DataTable dt_Direct_Emp = new DataTable();
            dt_Direct_Emp = Evaluation_For_Employee_DB.Select_Evaluation_For_Employee_Mngr(CDataConverter.ConvertToInt(Smart_Pmp_Id.SelectedValue), CDataConverter.ConvertToInt(hidden_Direct_emp_id.Value));
            Set_Selected_DDL_Direct_Emp(dt_Direct_Emp);
        }
    }

    private void fill_Grid_weeknes()
    {

        DataTable dt = Get_Weekness_Strengths(1, CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()));
        if (dt.Rows.Count <= 1)
        {
            for (int i = 0; i < 3; i++)
            {
                DataRow dr = null;
                dr = dt.NewRow();
                dt.Rows.Add(dr);
            }
        }

        ViewState["dt_week"] = dt;
        Gridview_ٍstrength.DataSource = ViewState["dt_week"];
        Gridview_ٍstrength.DataBind();
        if (CDataConverter.ConvertToInt(hidden_top_mngr.Value) > 0)
        {

            DataTable dt_Strength = Get_Weekness_Strengths(1, CDataConverter.ConvertToInt(hidden_Direct_emp_id.Value));
            Fill_strength(dt_Strength);


        }

        DataTable dtW = Get_Weekness_Strengths(0, CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()));
        if (dtW.Rows.Count <= 1)
        {
            for (int i = 0; i < 3; i++)
            {
                DataRow dr = null;
                dr = dtW.NewRow();
                dtW.Rows.Add(dr);
            }
        }

        GridWeaknes.DataSource = dtW;
        GridWeaknes.DataBind();
        if (CDataConverter.ConvertToInt(hidden_top_mngr.Value) > 0)
        {

            DataTable dt_Weaknes = Get_Weekness_Strengths(0, CDataConverter.ConvertToInt(hidden_Direct_emp_id.Value));
            Fill_Weaknes(dt_Weaknes);


        }

    }

    private void fill_Grid_Training()
    {


        DataTable dt = Get_Training_Needs(CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()));
        if (dt.Rows.Count <= 1)
        {
            for (int i = 0; i < 6; i++)
            {
                DataRow dr = null;

                dr = dt.NewRow();
                dt.Rows.Add(dr);
            }
        }

        ViewState["dt_train"] = dt;
        Gridview_training.DataSource = ViewState["dt_train"];
        Gridview_training.DataBind();

        if (CDataConverter.ConvertToInt(hidden_top_mngr.Value) > 0)
        {

            DataTable dt_Train = Get_Training_Needs(CDataConverter.ConvertToInt(hidden_Direct_emp_id.Value));
            Fill_Train(dt_Train);


        }



    }



    private void Set_Selected_DDL(DataTable dt)
    {
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            ((DropDownList)Gridview1.Rows[i].FindControl("ddl_Top_Emp_Degree_Id")).SelectedValue = dt.Rows[i]["Top_Emp_Degree_Id"].ToString();
            ((DropDownList)Gridview1.Rows[i].FindControl("ddl_Direct_Emp_Degree_Id")).SelectedValue = dt.Rows[i]["Direct_Emp_Degree_Id"].ToString();




        }
    }
    private void Set_Selected_DDL_Direct_Emp(DataTable dt)
    {
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            ((TextBox)Gridview1.Rows[i].FindControl("txt_Direct_Emp_Note")).Text = dt.Rows[i]["Direct_Emp_Note"].ToString();
            ((DropDownList)Gridview1.Rows[i].FindControl("ddl_Direct_Emp_Degree_Id")).SelectedValue = dt.Rows[i]["Direct_Emp_Degree_Id"].ToString();
            ((TextBox)Gridview1.Rows[i].FindControl("txt_Direct_Emp_Degree")).Text = dt.Rows[i]["Direct_Emp_Degree"].ToString();

        }
    }

    private void Fill_Train(DataTable dt)
    {
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            ((TextBox)Gridview_training.Rows[i].FindControl("txt_WDirect_Emp_Note")).Text = dt.Rows[i]["Direct_Emp_Note"].ToString();

        }
    }

    private void Fill_strength(DataTable dt)
    {
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            ((TextBox)Gridview_ٍstrength.Rows[i].FindControl("txt_Direct_Emp_Note")).Text = dt.Rows[i]["Direct_Emp_Note"].ToString();


        }
    }

    private void Fill_Weaknes(DataTable dt)
    {
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            ((TextBox)GridWeaknes.Rows[i].FindControl("txt_WDirect_Emp_Note")).Text = dt.Rows[i]["Direct_Emp_Note"].ToString();

        }
    }





    private void Set_Gridview_ٍstrength_Direct_Emp(DataTable dt)
    {
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            ((TextBox)Gridview_ٍstrength.Rows[i].FindControl("txt_Direct_Emp_Note")).Text = dt.Rows[i]["Direct_Emp_Note"].ToString();

        }
    }




    private void ReadPdfFile()
    {
        string path = @"C:\Swift3D.pdf";
        WebClient client = new WebClient();
        Byte[] buffer = client.DownloadData(path);

        if (buffer != null)
        {
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-length", buffer.Length.ToString());
            Response.BinaryWrite(buffer);
        }

    }

    /// <summary>
    /// method to save weekness point for some employee
    /// </summary>
    private void Save_Weekness()
    {
        foreach (GridViewRow row in GridWeaknes.Rows)
        {

            TextBox txt_WDirect_Emp_Note = ((TextBox)row.FindControl("txt_WDirect_Emp_Note"));
            TextBox txt_WTop_Emp_Note = ((TextBox)row.FindControl("txt_WTop_Emp_Note"));
            Evaluation_Strengths_weaknesses_DT obj_Main = new Evaluation_Strengths_weaknesses_DT();
            obj_Main.Evaluation_id = CDataConverter.ConvertToInt(hidden_Evaluation_id.Value);
            obj_Main.Direct_Emp_Note = txt_WDirect_Emp_Note.Text;
            obj_Main.Top_Emp_Note = txt_WTop_Emp_Note.Text;
            obj_Main.type = 0;
            Evaluation_Strengths_weaknesses_DB.Save(obj_Main);

        }

    }

    /// <summary>
    /// method to save Strengths point for some employee
    /// </summary>
    private void Save_Strengths()
    {

        foreach (GridViewRow row in Gridview_ٍstrength.Rows)
        {

            TextBox txt_Direct_Emp_Note = ((TextBox)row.FindControl("txt_Direct_Emp_Note"));
            TextBox txt_Top_Emp_Note = ((TextBox)row.FindControl("txt_Top_Emp_Note"));
            Evaluation_Strengths_weaknesses_DT obj_Main = new Evaluation_Strengths_weaknesses_DT();
            obj_Main.Evaluation_id = CDataConverter.ConvertToInt(hidden_Evaluation_id.Value);
            obj_Main.Direct_Emp_Note = txt_Direct_Emp_Note.Text;
            obj_Main.Top_Emp_Note = txt_Top_Emp_Note.Text;
            obj_Main.type = 1;
            Evaluation_Strengths_weaknesses_DB.Save(obj_Main);

        }

    }

    /// <summary>
    /// method to save Training needs for some employee
    /// </summary>
    private void Save_Training()
    {

        foreach (GridViewRow row in Gridview_training.Rows)
        {

            TextBox txt_Name = ((TextBox)row.FindControl("txt_Name"));
            TextBox txt_WDirect_Emp_Note = ((TextBox)row.FindControl("txt_WDirect_Emp_Note"));
            TextBox txt_WTop_Emp_Note = ((TextBox)row.FindControl("txt_WTop_Emp_Note"));
            Evaluation_Training_Needs_DT obj_Main = new Evaluation_Training_Needs_DT();
            obj_Main.Evaluation_id = CDataConverter.ConvertToInt(hidden_Evaluation_id.Value);
            obj_Main.Name = txt_Name.Text;
            obj_Main.Direct_Emp_Note = txt_WDirect_Emp_Note.Text;
            obj_Main.Top_Emp_Note = txt_WTop_Emp_Note.Text;
            Evaluation_Training_Needs_DB.Save(obj_Main);

        }

    }

    /// <summary>
    /// method to save Evaluation Main Items for some employee
    /// </summary>
    private void Save_Evaluation_Main_Items()
    {
        foreach (GridViewRow row in Gridview1.Rows)
        {

            DropDownList ddl_Direct_Emp_Degree_Id = ((DropDownList)row.FindControl("ddl_Direct_Emp_Degree_Id"));
            DropDownList ddl_Top_Emp_Degree_Id = ((DropDownList)row.FindControl("ddl_Top_Emp_Degree_Id"));
            Label lbl_Main_Item_Id = ((Label)row.FindControl("lbl_Main_Item_Id"));
            Label lbl_Sub_Item_Id = ((Label)row.FindControl("lbl_Sub_Item_Id"));
            TextBox txt_Direct_Emp_Note = ((TextBox)row.FindControl("txt_Direct_Emp_Note"));
            TextBox txt_Top_Emp_Note = ((TextBox)row.FindControl("txt_Top_Emp_Note"));
            TextBox txt_Direct_Emp_Degree = ((TextBox)row.FindControl("txt_Direct_Emp_Degree"));
            TextBox txt_Top_Emp_Degree = ((TextBox)row.FindControl("txt_Top_Emp_Degree"));
            Evaluation_Main_DT obj_Main = new Evaluation_Main_DT();
            obj_Main.Evaluation_id = CDataConverter.ConvertToInt(hidden_Evaluation_id.Value);
            obj_Main.Main_Item_Id = CDataConverter.ConvertToInt(lbl_Main_Item_Id.Text);
            obj_Main.Sub_Item_Id = CDataConverter.ConvertToInt(lbl_Sub_Item_Id.Text);
            if (hidden_direct_mngr.Value == "1")
            {
                obj_Main.Direct_Emp_Degree_Id = CDataConverter.ConvertToInt(ddl_Direct_Emp_Degree_Id.SelectedValue);
                obj_Main.Direct_Emp_Note = txt_Direct_Emp_Note.Text;
                obj_Main.Direct_Emp_Degree = CDataConverter.ConvertToInt(txt_Direct_Emp_Degree.Text);

            }
            else
            {
                obj_Main.Direct_Emp_Degree_Id = 0;
                obj_Main.Direct_Emp_Note = "";
                obj_Main.Direct_Emp_Degree = 0;
            }

            if (hidden_top_mngr.Value == "1")
            {

                obj_Main.Top_Emp_Degree_Id = CDataConverter.ConvertToInt(ddl_Top_Emp_Degree_Id.SelectedValue);
                obj_Main.Top_Emp_Note = txt_Top_Emp_Note.Text;
                obj_Main.Top_Emp_Degree = CDataConverter.ConvertToInt(txt_Top_Emp_Degree.Text);
            }
            else
            {
                obj_Main.Top_Emp_Degree_Id = 0;
                obj_Main.Top_Emp_Note = "";
                obj_Main.Top_Emp_Degree = 0;
            }
            Evaluation_Main_DB.Save(obj_Main);

        }
    }

    #endregion



    #region Event Handlers

    protected void btn_Save_Click(object sender, EventArgs e)
    {
        if (Session_CS.pmp_id != null)
        {
            if (Check_Main_Valid())
            {

                Evaluation_For_Employee_DB.Clear_for_emp(CDataConverter.ConvertToInt(Smart_Pmp_Id.SelectedValue), CDataConverter.ConvertToInt(Session_CS.pmp_id));
                //commented by Eng.:MaHmOuD
                Evaluation_For_Employee_DT obj = Evaluation_For_Employee_DB.Select_By_EmpID_And_MngrID(CDataConverter.ConvertToInt(Smart_Pmp_Id.SelectedValue), CDataConverter.ConvertToInt(Session_CS.pmp_id));

                if (obj.Evaluation_id <= 0)
                {
                    //commented by Eng.:MaHmOuD
                    obj.Evaluation_id = 0;
                    //obj.Month = DateTime.Now.Month; //CDataConverter.ConvertToInt(ddl_month.SelectedItem.Text);
                    //obj.Year = DateTime.Now.Year;// CDataConverter.ConvertToInt(ddl_year.SelectedItem.Text);

                    obj.Month = CDataConverter.ConvertDateTimeNowRtnDt().Month; //CDataConverter.ConvertToInt(ddl_month.SelectedItem.Text);
                    obj.Year = CDataConverter.ConvertDateTimeNowRtnDt().Year;// CDataConverter.ConvertToInt(ddl_year.SelectedItem.Text);
                    obj.Pmp_Id = CDataConverter.ConvertToInt(Smart_Pmp_Id.SelectedValue);

                    obj.Direct_Mng_Finished = false;

                    obj.Top_Mng_Finished = false;


                    obj.Evaluator_emp_ID = CDataConverter.ConvertToInt(Session_CS.pmp_id);

                    hidden_Evaluation_id.Value = Evaluation_For_Employee_DB.Save(obj).ToString();




                }
                else
                {
                    hidden_Evaluation_id.Value = obj.Evaluation_id.ToString();
                }





                Save_Evaluation_Main_Items();
                Save_Strengths();
                Save_Weekness();
                Save_Training();

                calculate_Grade();

                Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم الحفظ بنجاح')</script>");

            }
        }
        else
        {
            Response.Redirect("~\\Default.aspx");
        }

    }

    protected void btn_report_Click(object sender, EventArgs e)
    {
        string user = Session_CS.pmp_name.ToString();
        int group = CDataConverter.ConvertToInt(Session_CS.group_id.ToString());
        ReportDocument rd = new ReportDocument();
        string s = "";

        int direct_empId = 0;
        DataTable dt = Employee_Managers_DB.Selectby_EmpId(CDataConverter.ConvertToInt(Smart_Pmp_Id.SelectedValue), 1);
        if (dt.Rows.Count > 0)
        {
            direct_empId = CDataConverter.ConvertToInt(dt.Rows[0]["Mngr_Emp_ID"].ToString());
        }

        s = Server.MapPath("../Reports/Evaluation_Report_All.rpt");
        rd.Load(s);

        Reports.Load_Report(rd);

        rd.SetParameterValue("@pmp_id", CDataConverter.ConvertToInt(Smart_Pmp_Id.SelectedValue), "Header_Eval_Report.rpt");

        rd.SetParameterValue("@pmp_id", CDataConverter.ConvertToInt(Smart_Pmp_Id.SelectedValue), "sub_Evaluation_Rep_first.rpt");
        rd.SetParameterValue("@pmp_id", CDataConverter.ConvertToInt(Smart_Pmp_Id.SelectedValue), "sub_Evaluation_Rep_strengh_amira.rpt");
        rd.SetParameterValue("@pmp_id", CDataConverter.ConvertToInt(Smart_Pmp_Id.SelectedValue), "sub_Evaluation_Rep_weakness_amira.rpt");
        rd.SetParameterValue("@pmp_id", CDataConverter.ConvertToInt(Smart_Pmp_Id.SelectedValue), "sub_Evaluation_Rep_Needs.rpt");
        rd.SetParameterValue("@pmp_id", CDataConverter.ConvertToInt(Smart_Pmp_Id.SelectedValue), "signatures_Eval_Report.rpt");
        rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
        rd.SetParameterValue("@user", user, "footerRep.rpt");


        if (Session_CS.pmp_id > 0 && CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()) == direct_empId)
        {
            rd.SetParameterValue("mng_type", 1, "sub_Evaluation_Rep_first.rpt");

            rd.SetParameterValue("mng_type", 1, "sub_Evaluation_Rep_strengh_amira.rpt");

            rd.SetParameterValue("mng_type", 1, "sub_Evaluation_Rep_weakness_amira.rpt");

            rd.SetParameterValue("mng_type", 1, "sub_Evaluation_Rep_Needs.rpt");

        }
        else
        {
            rd.SetParameterValue("mng_type", 2, "sub_Evaluation_Rep_first.rpt");

            rd.SetParameterValue("mng_type", 2, "sub_Evaluation_Rep_strengh_amira.rpt");

            rd.SetParameterValue("mng_type", 2, "sub_Evaluation_Rep_weakness_amira.rpt");

            rd.SetParameterValue("mng_type", 2, "sub_Evaluation_Rep_Needs.rpt");

        }

        rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report");

    }

    protected void btn_finish_Click(object sender, EventArgs e)
    {



        Evaluation_For_Employee_DT obj = Evaluation_For_Employee_DB.SelectBypmpID(CDataConverter.ConvertToInt(Smart_Pmp_Id.SelectedValue));
        if (obj.Evaluation_id > 0)
        {
            if (hidden_direct_mngr.Value == "1")
            {
                obj.Direct_Mng_Finished = true;
            }
            else
                obj.Top_Mng_Finished = true;


            Evaluation_For_Employee_DB.Save(obj).ToString();
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
                MOnMember_Data_Emp(Request["pmp_id"].ToString());
            }
            else
                fil_employee();
        }
        else
        {
            Smart_Pmp_Id.Clear_Controls();
            MOnMember_Data_Emp("");
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

    public bool Get_Enabled_Direct_mngr()
    {
        if (hidden_direct_mngr.Value == "1")
        {
            Gridview1.Columns[5].Visible = true;
            Gridview1.Columns[6].Visible = false;
            Gridview1.Columns[7].Visible = false;
            Gridview1.Columns[8].Visible = false;
            Gridview_ٍstrength.Columns[1].Visible = false;
            GridWeaknes.Columns[1].Visible = false;
            Gridview_training.Columns[1].Visible = false;



            return true;
        }
        else
        {
            return false;
        }

    }

    public bool Get_Enabled()
    {
        if (hidden_top_mngr.Value == "1")
            return false;
        else
            return true;
    }
    public bool Get_Enabled_Top_mngr()
    {
        if (hidden_top_mngr.Value == "1")
        {
            Gridview1.Columns[4].Visible = true;
            Gridview1.Columns[5].Visible = true;
            Gridview_ٍstrength.Columns[1].Visible = true;
            GridWeaknes.Columns[1].Visible = true;
            Gridview_training.Columns[1].Visible = true;

            Gridview1.Columns[6].Visible = true;
            Gridview1.Columns[7].Visible = true;

            for (int i = 0; i < Gridview1.Rows.Count; i++)
            {
                TextBox txtbox = (TextBox)Gridview1.Rows[i].FindControl("txt_Direct_Emp_Degree");
                txtbox.Enabled = false;
            }


            return true;
        }
        else
            return false;

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
        DataTable dt = Evaluation_Main_DB.check_dept_category(CDataConverter.ConvertToInt(Smart_Pmp_Id.SelectedValue));

        if (Smart_Pmp_Id.SelectedValue != "" && dt.Rows.Count > 0)
            return true;
        else
        {
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('يجب إدخال أوزان عناصر تقييم الاداء لفئة الوظائف الموجودة بالادارة قبل البدء في عملية التقييم')</script>");
            return false;
        }
    }

    private DataTable Get_Weekness_Strengths(int type, int Evaluator_emp_ID)
    {

        DataTable dt = Evaluation_Main_DB.Get_Weakness_Strengths(CDataConverter.ConvertToInt(Smart_Pmp_Id.SelectedValue), type, Evaluator_emp_ID);

        return dt;

    }

    private DataTable Get_Training_Needs(int Evaluator_emp_ID)
    {

        DataTable dt = Evaluation_Main_DB.Get_Training_Needs(CDataConverter.ConvertToInt(Smart_Pmp_Id.SelectedValue), Evaluator_emp_ID);

        return dt;
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

        obj.Month = CDataConverter.ConvertDateTimeNowRtnDt().Month; //CDataConverter.ConvertToInt(ddl_month.SelectedItem.Text);
        obj.Year = CDataConverter.ConvertDateTimeNowRtnDt().Year;// CDataConverter.ConvertToInt(ddl_year.SelectedItem.Text);

        obj.Pmp_Id = CDataConverter.ConvertToInt(Smart_Pmp_Id.SelectedValue);
        obj.Top_Mng_Finished = false;
        obj.Evaluator_emp_ID = 0;
        hidden_Evaluation_id.Value = Evaluation_For_Employee_DB.Save(obj).ToString();
        //clear previous hr evaluation id
        ClearPrevHrEvaluation(CDataConverter.ConvertToInt(hidden_Evaluation_id.Value));


    }



    private void Fill_Grid_weeknes_Hr()
    {
        DataTable dt = Evaluation_Main_DB.Fill_Weakness_HR(CDataConverter.ConvertToInt(Smart_Pmp_Id.SelectedValue));
        GridWeaknes.DataSource = dt;
        GridWeaknes.DataBind();
    }

    private void Fill_Grid_Strangths_Hr()
    {
        DataTable dt = Evaluation_Main_DB.Get_Eval_Employee_Strengths(CDataConverter.ConvertToInt(Smart_Pmp_Id.SelectedValue));

        ViewState["dt_week"] = dt;
        Gridview_ٍstrength.DataSource = ViewState["dt_week"];
        Gridview_ٍstrength.DataBind();

    }



    private void ClearPrevHrEvaluation(int eval_ID)
    {


        Evaluation_Main_DB.Evaluation_Main_DeletebyID(eval_ID);

    }

    #endregion


    protected void txt_Direct_Emp_Degree_TextChanged(object sender, EventArgs e)
    {

        GridViewRow currentRow = (GridViewRow)((TextBox)sender).Parent.Parent;

        TextBox txt = (TextBox)currentRow.FindControl("txt_Direct_Emp_Degree");
        DropDownList ddl2 = (DropDownList)currentRow.FindControl("ddl_Direct_Emp_Degree_Id");
        if (txt.Text != "")
        {
            Int32 value = Convert.ToInt32(txt.Text);



            if (value >= 0 && value < 60)
            {
                ddl2.Enabled = false;
                ddl2.SelectedIndex = 5;

            }
            else if (value >= 60 && value < 70)
            {
                ddl2.SelectedIndex = 4;
                ddl2.Enabled = false;
            }
            else if (value >= 70 && value < 80)
            {
                ddl2.SelectedIndex = 3;
                ddl2.Enabled = false;
            }
            else if (value >= 80 && value < 90)
            {
                ddl2.SelectedIndex = 2;
                ddl2.Enabled = false;
            }
            else if (value >= 90 && value <= 100)
            {
                ddl2.SelectedIndex = 1;
                ddl2.Enabled = false;
            }
            else
            {

                Page.RegisterStartupScript("Sucess", "<script language=javascript> alert('قم بإدخال أرقام من 1 : 100 فقط')</script>");
            }
        }


    }


    protected void txt_Top_Emp_Degree_TextChanged(object sender, EventArgs e)
    {

        GridViewRow currentRow = (GridViewRow)((TextBox)sender).Parent.Parent;

        TextBox txt1 = (TextBox)currentRow.FindControl("txt_Top_Emp_Degree");
        DropDownList ddl22 = (DropDownList)currentRow.FindControl("ddl_Top_Emp_Degree_Id");


        if (txt1.Text != "")
        {
            Int32 value2 = Convert.ToInt32(txt1.Text);

            if (value2 >= 0 && value2 < 60)
            {
                ddl22.Enabled = false;
                ddl22.SelectedIndex = 5;

            }
            else if (value2 >= 60 && value2 < 70)
            {
                ddl22.SelectedIndex = 4;
                ddl22.Enabled = false;
            }
            else if (value2 >= 70 && value2 < 80)
            {
                ddl22.SelectedIndex = 3;
                ddl22.Enabled = false;
            }
            else if (value2 >= 80 && value2 < 90)
            {
                ddl22.SelectedIndex = 2;
                ddl22.Enabled = false;
            }
            else if (value2 >= 90 && value2 <= 100)
            {
                ddl22.SelectedIndex = 1;
                ddl22.Enabled = false;
            }
            else
            {

                Page.RegisterStartupScript("Sucess", "<script language=javascript> alert('قم بإدخال أرقام من 1 : 100 فقط')</script>");
            }
        }

    }


    private void calculate_Grade()

    {

        string Sql = " select * from Evaluation_For_Employee where year =2015 and Pmp_Id='"+CDataConverter.ConvertToInt(Smart_Pmp_Id.SelectedValue)+"' ";
        DataTable dt = General_Helping.GetDataTable(Sql);
        foreach (DataRow dr in dt.Rows)
        {
            DataTable DT_eval = SqlHelper.ExecuteDataset(Database.ConnectionString, "Eval_Calc_Emp_Select", CDataConverter.ConvertToInt(dr["Pmp_Id"].ToString())).Tables[0];
            if (DT_eval.Rows.Count > 0)
            {
                string sql_update = " update Evaluation_For_Employee set Direct_Mng_Eval =" + CDataConverter.ConvertToDecimal(DT_eval.Rows[0]["Direct_Mng_Eval"]) +
                                    " , Top_Mng_Eval = " + CDataConverter.ConvertToDecimal(DT_eval.Rows[0]["Top_Mng_Eval"]) +
                                    " , Final_Eval_Degree = " + CDataConverter.ConvertToDecimal(DT_eval.Rows[0]["Final_Eval_Degree"]) +
                                    " where Evaluation_id = " + CDataConverter.ConvertToInt(dr["Evaluation_id"].ToString());
                General_Helping.ExcuteQuery(sql_update);


            }

        }
    }


}




