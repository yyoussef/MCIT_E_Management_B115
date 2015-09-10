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
using System.Text;



public partial class UserControls_Employee_data : System.Web.UI.UserControl
{

    private string sql_Connection = Database.ConnectionString;
    General_Helping Obj_General_Helping = new General_Helping();
    string InsideMCIT = System.Configuration.ConfigurationManager.AppSettings["InsideMCIT"].ToString();
    protected void Page_Load(object sender, EventArgs e)
    {



        if (!IsPostBack)
        {
            Smrt_Srch_structure.Show_OrgTree = true;
            // fillddl();
            fill_job_category();

            // fill_emplyees();

            Smart_Search_emp.Show_Code = false;




            //  DataTable dt = General_Helping.GetDataTable("select count(*) as 'total' from EMPLOYEE where EMPLOYEE.workstatus!=4 and foundation_id ="+Session_CS.foundation_id);
            // lbl_total_emp.Text = dt.Rows[0]["total"].ToString();
            //   lbl_total_emp.Visible = true;
            // Label41.Visible = true;

            if (Request.QueryString["pmp_id"] != null && Request["dept_id"] != null)
            {
                FillEmpData(Request.QueryString["pmp_id"].ToString(), Request.QueryString["dept_id"].ToString());
            }

        }


    }

    protected void check_inside_mcit()
    {
        if (InsideMCIT == "1")
        {
            TabPanel1.Enabled = true;
            TabPanel2.Enabled = true;
            TabPanel3.Enabled = true;
            TabPanel4.Enabled = true;

        }
        else
        {
            TabPanel1.Enabled = false;
            TabPanel2.Enabled = false;
            TabPanel3.Enabled = false;
            TabPanel4.Enabled = false;

        }
    }

    protected void FillEmpData(string pmp_id, string dept_id)
    {
        // ddl_sectors.SelectedValue = sec_id;

        fill_depts();
        //  Smart_Search_mang.SelectedValue = dept_id;
        Smrt_Srch_structure.SelectedValue = dept_id;
        //this.Smart_Search_emp.Value_Handler += new Smart_Search.Delegate_Selected_Value(emp_Data);
        fill_emplyees();
        Smart_Search_emp.SelectedValue = pmp_id;
        emp_Data(Request.QueryString["pmp_id"].ToString());

    }

    protected void fillddl()
    {
        //    string Sql = "select Sec_id,Sec_name from Sectors where foundation_id = " + CDataConverter.ConvertToInt(Session_CS.foundation_id.ToString());
        //    DataTable dt = General_Helping.GetDataTable(Sql);
        //    ddl_sectors.DataSource = dt;
        //    ddl_sectors.DataTextField = "Sec_name";
        //    ddl_sectors.DataValueField = "Sec_id";
        //    ddl_sectors.DataBind();
        //    ddl_sectors.Items.Insert(0, new ListItem("إختر القطاع", "0"));


        //       // if (Request.Url.ToString().ToLower().Contains("admin") || (Session_CS.Hr_Eval != null && Session_CS.Hr_Eval.ToString() == "1"))
        //        if (Request.Url.ToString().ToLower().Contains("admin") || (Session_CS.Hr_Eval != null && Session_CS.Hr_Eval.ToString() == "1"))

        //            tr_allow_chk_dept.Visible = true;

        //       // else if (Session_CS.Hr_Eval != null && Session_CS.Hr_Eval.ToString() != "1")
        //        else if (Session_CS.Hr_Eval != null && Session_CS.Hr_Eval.ToString() != "1")
        //        {
        //            ddl_sectors.SelectedValue = Session_CS.sec_id.ToString();
        //            ddl_sectors.Enabled = false;
        fill_depts();
        //            tr_allow_chk_dept.Visible = true;
        //        }

    }



    protected void fill_job_category()
    {
        string Sql = "SELECT URol_ID,URol_Desc FROM User_Role";
        DataTable dt = General_Helping.GetDataTable(Sql);
        ddl_Job_Category.DataSource = dt;
        ddl_Job_Category.DataValueField = "URol_ID";
        ddl_Job_Category.DataTextField = "URol_Desc";
        ddl_Job_Category.DataBind();
        ddl_Job_Category.Items.Insert(0, new ListItem("اختر...", "0"));
    }

    protected void fill_depts()
    {
        // Smart_Search_mang.sql_Connection = sql_Connection;
        ////Smart_Search_mang.Query = "select Dept_ID,Dept_name from Departments where sec_sec_id='" + ddl_sectors.SelectedValue + "' ";
        ////Smart_Search_mang.Value_Field = "Dept_ID";
        ////Smart_Search_mang.Text_Field = "Dept_name";
        ////Smart_Search_mang.Orderby = "ORDER BY LTRIM(Dept_name)";
        ////Smart_Search_mang.DataBind();
        //if (ddl_sectors.SelectedValue != "" && ddl_sectors.SelectedValue != null && ddl_sectors.SelectedValue !="0")
        //{
        //    DataTable dt = General_Helping.GetDataTable("select Dept_ID,Dept_name from Departments where sec_sec_id='" + ddl_sectors.SelectedValue + "'");
        //    Smart_Search_mang.datatble = dt;
        //    Smart_Search_mang.Value_Field = "Dept_ID";
        //    Smart_Search_mang.Text_Field = "Dept_name";
        //    Smart_Search_mang.DataBind();

        //}



        Fill_All_Smart_Employee();

    }
    protected void fill_vac_manager()
    {
        Smart_Search_Vaction_mng.sql_Connection = sql_Connection;
        DataTable dt211 = General_Helping.GetDataTable("SELECT     EMPLOYEE.PMP_ID, EMPLOYEE.pmp_name, Departments.sec_sec_id FROM  EMPLOYEE INNER JOIN Departments ON EMPLOYEE.Dept_Dept_id = Departments.Dept_ID  where EMPLOYEE.foundation_id= '" + CDataConverter.ConvertToInt(Session_CS.foundation_id.ToString()) + "'");

        Smart_Search_Vaction_mng.datatble = dt211;
        Smart_Search_Vaction_mng.Value_Field = "PMP_ID";
        Smart_Search_Vaction_mng.Text_Field = "pmp_name";
        Smart_Search_Vaction_mng.DataBind();
    }

    private void Fill_All_Smart_Employee()
    {
        // string Query = " SELECT     EMPLOYEE.PMP_ID, EMPLOYEE.pmp_name, Departments.sec_sec_id FROM  EMPLOYEE INNER JOIN Departments ON EMPLOYEE.Dept_Dept_id = Departments.Dept_ID  where EMPLOYEE.foundation_id= "+ CDataConverter.ConvertToInt(Session_CS.foundation_id.ToString());

        //Smart_Search2.sql_Connection = sql_Connection;
        //Smart_Search3.sql_Connection = sql_Connection;
        Smart_Search_Vaction_mng.sql_Connection = sql_Connection;
        smrtDirectManager.sql_Connection = sql_Connection;
        smrtHigherManager.sql_Connection = sql_Connection;

        //Smart_Search2.Query = Query;
        //Smart_Search2.Value_Field = "pmp_id";
        //Smart_Search2.Text_Field = "pmp_name";
        //Smart_Search2.DataBind();


        DataTable dt21 = General_Helping.GetDataTable("SELECT     EMPLOYEE.PMP_ID, EMPLOYEE.pmp_name, Departments.sec_sec_id FROM  EMPLOYEE INNER JOIN Departments ON EMPLOYEE.Dept_Dept_id = Departments.Dept_ID  where EMPLOYEE.foundation_id= '" + CDataConverter.ConvertToInt(Session_CS.foundation_id.ToString()) + "'");
        //Smart_Search2.datatble = dt21;
        //Smart_Search2.Value_Field = "PMP_ID";
        //Smart_Search2.Text_Field = "pmp_name";
        //Smart_Search2.DataBind();

        //////////////////////////////////////////////////////////////
        //Smart_Search3.Query = Query;
        //Smart_Search3.Value_Field = "pmp_id";
        //Smart_Search3.Text_Field = "pmp_name";
        //Smart_Search3.DataBind();


        //DataTable dt1 = Smart_Search_mang.datasource("SELECT     EMPLOYEE.PMP_ID, EMPLOYEE.pmp_name, Departments.sec_sec_id FROM  EMPLOYEE INNER JOIN Departments ON EMPLOYEE.Dept_Dept_id = Departments.Dept_ID  where EMPLOYEE.foundation_id= '" + CDataConverter.ConvertToInt(Session_CS.foundation_id.ToString()) + "'");
        //Smart_Search3.datatble = dt21;
        //Smart_Search3.Value_Field = "PMP_ID";
        //Smart_Search3.Text_Field = "pmp_name";
        //Smart_Search3.DataBind();

        //////////////////////////////////////////////////////////////////


        //smrtDirectManager.Query = Query;
        //smrtDirectManager.Value_Field = "pmp_id";
        //smrtDirectManager.Text_Field = "pmp_name";
        //smrtDirectManager.DataBind();

        //DataTable dt3 = Smart_Search_mang.datasource("SELECT     EMPLOYEE.PMP_ID, EMPLOYEE.pmp_name, Departments.sec_sec_id FROM  EMPLOYEE INNER JOIN Departments ON EMPLOYEE.Dept_Dept_id = Departments.Dept_ID  where EMPLOYEE.foundation_id= '" + CDataConverter.ConvertToInt(Session_CS.foundation_id.ToString()) + "'");
        smrtDirectManager.datatble = dt21;
        smrtDirectManager.Value_Field = "PMP_ID";
        smrtDirectManager.Text_Field = "pmp_name";
        smrtDirectManager.DataBind();

        ///////////////////////////////////////////////////////////////
        //smrtHigherManager.Query = Query;
        //smrtHigherManager.Value_Field = "pmp_id";
        //smrtHigherManager.Text_Field = "pmp_name";
        //smrtHigherManager.DataBind();

        //DataTable dt4 = Smart_Search_mang.datasource("SELECT     EMPLOYEE.PMP_ID, EMPLOYEE.pmp_name, Departments.sec_sec_id FROM  EMPLOYEE INNER JOIN Departments ON EMPLOYEE.Dept_Dept_id = Departments.Dept_ID  where EMPLOYEE.foundation_id= '" + CDataConverter.ConvertToInt(Session_CS.foundation_id.ToString()) + "'");
        smrtHigherManager.datatble = dt21;
        smrtHigherManager.Value_Field = "PMP_ID";
        smrtHigherManager.Text_Field = "pmp_name";
        smrtHigherManager.DataBind();

    }
    protected void fill_emplyees()
    {
        Smart_Search_emp.sql_Connection = sql_Connection;
        //string Query = "SELECT     EMPLOYEE.PMP_ID, EMPLOYEE.pmp_name, Departments.sec_sec_id FROM         EMPLOYEE INNER JOIN                       Departments ON EMPLOYEE.Dept_Dept_id = Departments.Dept_ID  and EMPLOYEE.workstatus!=4";

        //Query += "where Departments.Dept_ID =  " + Smart_Search_mang.SelectedValue;

        //Smart_Search_emp.Query = Query;



        //Smart_Search_emp.Value_Field = "PMP_ID";
        //Smart_Search_emp.Text_Field = "pmp_name";

        //Smart_Search_emp.DataBind();

        //DataTable dt = General_Helping.GetDataTable("SELECT     EMPLOYEE.PMP_ID, EMPLOYEE.pmp_name, Departments.sec_sec_id FROM    EMPLOYEE INNER JOIN     Departments ON EMPLOYEE.Dept_Dept_id = Departments.Dept_ID  where Departments.Dept_ID = '"+Smart_Search_mang.SelectedValue+"'");
        //Smart_Search_emp.datatble = dt;
        //Smart_Search_emp.Value_Field = "PMP_ID";
        //Smart_Search_emp.Text_Field = "pmp_name";
        //Smart_Search_emp.Clear_Controls();
        //Smart_Search_emp.DataBind();
        string emp_query = "";
        if (Smrt_Srch_structure.SelectedValue != "" && Smrt_Srch_structure.SelectedValue != null)
        {


            emp_query = "SELECT     EMPLOYEE.PMP_ID, EMPLOYEE.pmp_name, Departments.sec_sec_id FROM    EMPLOYEE INNER JOIN     Departments ON EMPLOYEE.Dept_Dept_id = Departments.Dept_ID  where Departments.Dept_ID = '" + Smrt_Srch_structure.SelectedValue + "'";

        }
        else
        {
            emp_query += "SELECT     EMPLOYEE.PMP_ID, EMPLOYEE.pmp_name FROM    EMPLOYEE   where EMPLOYEE.foundation_id = '" + Session_CS.foundation_id + "'";

        }
        DataTable dtt = General_Helping.GetDataTable(emp_query);
        Smart_Search_emp.datatble = dtt;
        Smart_Search_emp.Value_Field = "PMP_ID";
        Smart_Search_emp.Text_Field = "pmp_name";
        Smart_Search_emp.Clear_Controls();
        Smart_Search_emp.DataBind();

        Lbl_count.Text = Smart_Search_emp.Items_Count.ToString();
        Lbl_count.Visible = true;
        Label39.Visible = true;



    }
    private void fil_smart_category()
    {
        Smart_search_category.sql_Connection = sql_Connection;

        //Smart_search_category.Query = "select Rol_ID ,Rol_Desc from Roles where Rol_ID >=5 ";


        //Smart_search_category.Value_Field = "Rol_ID";
        //Smart_search_category.Text_Field = "Rol_Desc";

        //Smart_search_category.DataBind();

        DataTable dt5 = General_Helping.GetDataTable(" select Rol_ID ,Rol_Desc from Roles where Rol_ID >=5");
        Smart_search_category.datatble = dt5;
        Smart_search_category.Value_Field = "Rol_ID";
        Smart_search_category.Text_Field = "Rol_Desc";
        Smart_search_category.DataBind();


    }
    protected override void OnInit(EventArgs e)
    {
        check_inside_mcit();
        if (InsideMCIT == "1")
        {
            fil_smart_category();
            Fill_All_Smart_Employee();
            fill_vac_manager();
            tr_cat.Visible = true;
        }
        else
        {
            tr_cat.Visible = false;
            fill_vac_manager();
        }

        this.Smart_Search_emp.Value_Handler += new Smart_Search.Delegate_Selected_Value(emp_Data);
        //this.Smart_Search_mang.Value_Handler += new Smart_Search.Delegate_Selected_Value(MOnMember_Data_Depart);
        this.Smrt_Srch_structure.Value_Handler += new Smart_Search.Delegate_Selected_Value(MOnMember_Data_Depart);
        Smrt_Srch_structure.sql_Connection = sql_Connection;
        fill_structure();


        base.OnInit(e);


    }

    protected void fill_structure()
    {

        string Query = "";
        Query = "SELECT  * from    Departments  where foundation_id='" + Session_CS.foundation_id + "'";



        if (Request.Url.ToString().ToLower().Contains("admin") || (Session_CS.Hr_Eval != null && Session_CS.Hr_Eval.ToString() == "1"))
            tr_allow_chk_dept.Visible = true;
        else if (Session_CS.Hr_Eval != null && Session_CS.Hr_Eval.ToString() != "1")
        {

            //fill_depts();
            tr_allow_chk_dept.Visible = true;
        }

        Smrt_Srch_structure.datatble = General_Helping.GetDataTable(Query);
        Smrt_Srch_structure.Value_Field = "Dept_id";
        Smrt_Srch_structure.Text_Field = "Dept_name";


        Smrt_Srch_structure.DataBind();
    }
    private void MOnMember_Data_Depart(string Value)
    {
        //if (Session_CS.Hr_Eval.ToString() == "1" )
        //{
        if (!chk_allow_Chn_dept.Checked)
        {
            if (Value != "")
            {

                fill_emplyees();
            }
            else
            {
                //       if (!chk_allow_Chn_dept.Checked)
                Smart_Search_emp.Clear_Controls();


            }
        }
        // }
    }

    //protected void ddl_sectors_SelectedIndexChanged(object sender, EventArgs e)
    //{

    //    //  if (ddl_sectors.SelectedItem.Text.Contains("معلوماتي") )
    //    //{
    //    //  Label42.Visible = true;

    //    //}
    //    //else
    //    //{

    //    fill_depts();
    //    if (!chk_allow_Chn_dept.Checked)
    //        clear_fields();
    //    DataTable dr = General_Helping.GetDataTable("select count(*) as 'total' from EMPLOYEE inner join Departments on Departments.Dept_id=EMPLOYEE.Dept_Dept_id and  EMPLOYEE.workstatus!=4 inner join Sectors on Departments.Sec_sec_id=Sectors.Sec_id where Sectors.Sec_id ='" + CDataConverter.ConvertToInt(ddl_sectors.SelectedValue) + "'");
    //    lbl_sec_count.Text = dr.Rows[0]["total"].ToString();
    //    Lbl_count.Visible = false;
    //    Label39.Visible = false;
    //    Label40.Visible = true;
    //    lbl_sec_count.Visible = true;

    //    Label42.Visible = false;

    //    // Label39.Text = "إجمالي عدد الموظفين بالقطاع ";
    //    // }



    //}



    private void emp_Data(string Value)
    {
        //if (Request.QueryString["pmp_id"].ToString() != null)
        //{
        //    Value = Request.QueryString["pmp_id"];
        //}
        if (Value != "")
        {
            //btn_Save.Text = "تعديل";
            DataTable dt = Employee_Data_DB.Select_all(CDataConverter.ConvertToInt(Smart_Search_emp.SelectedValue));
            DataTable dt2 = Users_data_DB.UsersDataSelect(CDataConverter.ConvertToInt(Smart_Search_emp.SelectedValue));
            DataRow dr = dt.Rows[0];
            if (dt.Rows.Count > 0)
            {


                job_no_txt.Text = dt.Rows[0]["job_no"].ToString();
                title_txt.Text = dt.Rows[0]["pmp_title"].ToString();
                if (dt.Rows[0]["rol_rol_id"].ToString() != null && CDataConverter.ConvertToInt(dt.Rows[0]["rol_rol_id"].ToString()) > 0)
                {
                    ddl_Job_Category.SelectedValue = dt.Rows[0]["rol_rol_id"].ToString();
                }
                txt_rec_DT.Text = dt.Rows[0]["Hire_date"].ToString();
                txtmail.Text = dt.Rows[0]["mail"].ToString();
                //ddl_sectors.SelectedValue = dt.Rows[0]["Sec_id"].ToString();
                //if (Session_CS.Hr_Eval.ToString() != "1")
                //{
                //    Smart_Search_mang.SelectedValue = dt.Rows[0]["Dept_Dept_ID"].ToString();
                //}
                //Smart_Search2.SelectedValue = dt.Rows[0]["direct_manager"].ToString();
                //Smart_Search3.SelectedValue = dt.Rows[0]["higher_manager"].ToString();
                Smart_Search_Vaction_mng.SelectedValue = dt.Rows[0]["vacation_mng_pmp_id"].ToString();
                ddl_status.SelectedValue = dt.Rows[0]["workstatus"].ToString();
                ddl_universitydegree.SelectedValue = dt.Rows[0]["university_degree"].ToString();
                txt_major.Text = dt.Rows[0]["major"].ToString();
                txt_universityname.Text = dt.Rows[0]["university_name"].ToString();
                Smart_search_category.SelectedValue = dt.Rows[0]["category"].ToString();

                if (dt2.Rows.Count > 0)
                {
                    txt_username.Text = dt2.Rows[0]["USR_Name"].ToString();
                }

                if (dt.Rows[0]["contact_person"].ToString() == "True")
                {
                    chk_resp.Checked = true;
                }
                else
                {
                    chk_resp.Checked = false;
                }
                lbl_success.Visible = false;
                lbl_res.Visible = false;
                Label36.Visible = false;
                Label38.Visible = false;
                //fill_emplyees();
                string x = Smart_Search_emp.SelectedValue;
                FillManagersGridView();
                fillcontrols(CDataConverter.ConvertToInt(Value));





            }

            else
            {
                clear_fields();
                job_no_txt.Text = "";
                btn_Save.Text = "حفظ";
            }
        }

    }


    protected void btn_clear_Click(object sender, EventArgs e)
    {

        clear_on_new();



    }


    protected void Btn_Reset_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Smart_Search_emp.SelectedText))
        {
            General_Helping.ExcuteQuery("update users set USR_Pass='1234' where pmp_pmp_id='" + Smart_Search_emp.SelectedValue + "'");
            lbl_success.Visible = true;
            lbl_success.Text = "تمت إعادة تعيين كلمة المرور بنجاح";

        }
        else
        {
            //Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('يجب  إختيار بيانات الموظف اولا')</script>");
            lbl_success.Visible = true;
            lbl_success.Text = "يجب  إختيار بيانات الموظف اولا";

        }


    }

    protected void btn_active_Click(object sender, EventArgs e)
    {
        if (Smart_Search_emp.SelectedValue != "" && Smart_Search_emp.SelectedValue != "")
        {
            SqlHelper.ExecuteNonQuery(Database.ConnectionString, "users_activateaccount", Smart_Search_emp.SelectedValue);
            lbl_success.Visible = true;
            lbl_success.Text = "تم تفعيل الحساب بنجاح ";

        }

        else
        {
            lbl_success.Visible = true;
            lbl_success.Text = "يجب  إختيار الموظف اولا";

        }

    }


    private void clear_on_new()
    {
        //fill_depts();
        // this.Smart_Search_mang.Value_Handler += new Smart_Search.Delegate_Selected_Value(MOnMember_Data_Depart);


        fill_emplyees();
        Fill_All_Smart_Employee();
        job_no_txt.Text = "";
        title_txt.Text = "";
        txt_rec_DT.Text = "";
        txtmail.Text = "";
        //Smart_Search_Vaction_mng.Clear_Selected();
        // ddl_status.SelectedValue = "0";
        Smart_search_category.Clear_Selected();
        ddl_universitydegree.SelectedValue = "0";
        txt_universityname.Text = "";
        txt_major.Text = "";
        txt_othermail.Text = "";
        txt_otherphone.Text = "";
        txt_mobile.Text = "";
        txt_currenttasks.Text = "";
        txt_noofemployee.Text = "";
        txt_coursename.Text = "";
        tx_startdate.Text = "";
        txt_endate.Text = "";
        chk_resp.Checked = false;
        //Smart_Search2.Clear_Selected();
        //Smart_Search3.Clear_Selected();
        lbl_success.Visible = false;
        lbl_res.Visible = false;
        Label36.Visible = false;
        Label38.Visible = false;
        txt_username.Text = "";
        ddl_Job_Category.SelectedValue = "0";

        ////////////////////////////////////clear grid views//////////////////////////////////////////
        gvManagers.DataSource = null;
        gvManagers.DataBind();

        ///////////////////////////////////////////////

        gv_Employee_EX_TRaing.DataSource = null;
        gv_Employee_EX_TRaing.DataBind();

        /////////////////////////////////////

        gv_experience.DataSource = null;
        gv_experience.DataBind();

    }

    protected void btn_Save_Click(object sender, EventArgs e)
    {

        int operation;
        DataTable dt_users;
        Users_data_DT uobj = new Users_data_DT();

        string user_name = "";
        if (txt_username.Text != "")
        {

            user_name = txt_username.Text.Trim();
            uobj.USR_Name = user_name;
        }
        int emp_id = CDataConverter.ConvertToInt(Smart_Search_emp.SelectedValue);
        dt_users = Users_data_DB.Select_UsersData(emp_id, user_name);

        if (dt_users.Rows.Count <= 0)
        {

            if (!string.IsNullOrEmpty(Smrt_Srch_structure.SelectedValue) && !string.IsNullOrEmpty(Smart_Search_emp.SelectedText))
            // if ( !string.IsNullOrEmpty(Smart_Search_emp.SelectedText))
            {
                Employee_Data_DT obj = new Employee_Data_DT();
                //  obj.Dept_Dept_id = CDataConverter.ConvertToInt(Smart_Search_mang.SelectedValue);
                obj.Dept_Dept_id = CDataConverter.ConvertToInt(Smrt_Srch_structure.SelectedValue);
                obj.pmp_name = Smart_Search_emp.SelectedText;
                obj.mail = txtmail.Text;
                //obj.sec_sec_id = CDataConverter.ConvertToInt(ddl_sectors.SelectedValue);
                obj.Hire_date = txt_rec_DT.Text;
                obj.pmp_title = title_txt.Text;
                obj.job_no = job_no_txt.Text;
                //obj.direct_manager = CDataConverter.ConvertToInt(Smart_Search2.SelectedValue);
                //obj.higher_manager = CDataConverter.ConvertToInt(Smart_Search3.SelectedValue);
                obj.PMP_ID = CDataConverter.ConvertToInt(Smart_Search_emp.SelectedValue);
                obj.vacation_mng_pmp_id = CDataConverter.ConvertToInt(Smart_Search_Vaction_mng.SelectedValue);
                obj.workstatus = CDataConverter.ConvertToInt(ddl_status.SelectedItem.Value);
                obj.category = CDataConverter.ConvertToInt(Smart_search_category.SelectedValue);
                obj.major = txt_major.Text;
                obj.university_degree = Convert.ToInt32(ddl_universitydegree.SelectedValue);
                obj.university_name = txt_universityname.Text;
                obj.rol_rol_id = Convert.ToInt32(ddl_Job_Category.SelectedValue);

                obj.foundation_id = CDataConverter.ConvertToInt(Session_CS.foundation_id.ToString());

                obj.contact_person = chk_resp.Checked;
                obj.PMP_ID = Employee_Data_DB.Save(obj);

                //////////////////////////////////////////////////////////////////////////////////

                operation = (int)Project_Log_DB.Action.add;

                DataTable dt_check = Users_data_DB.UsersDataSelect(CDataConverter.ConvertToInt(obj.PMP_ID));

                if (Smart_Search_emp.SelectedValue != "" && Smart_Search_emp.SelectedValue != "0" && dt_check.Rows.Count > 0)
                {
                    uobj.USR_ID = 1;
                }
                else if (Smart_Search_emp.SelectedValue != "" && Smart_Search_emp.SelectedValue != "0" && dt_check.Rows.Count < 0)
                {
                    uobj.USR_ID = 0;

                }
                else
                {
                    uobj.USR_ID = 0;
                }
                uobj.USR_Pass = "1234";
                uobj.pmp_pmp_id = obj.PMP_ID;
                uobj.UROL_UROL_ID = 9;
                uobj.System_ID = 1;
                uobj.account_active = true;

                //  uobj.USR_Name = txt_username.Text;

                uobj.USR_ID = Users_data_DB.Save(uobj);



                fill_emplyees();
                Smart_Search_emp.SelectedValue = obj.PMP_ID.ToString();




                if (obj.PMP_ID > 0)
                {
                    lbl_success.Visible = true;
                    lbl_success.Text = "تم الحفظ بنجاح";
                    lbl_user.Visible = false;
                    operation = (int)Project_Log_DB.Action.add;

                    //   Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('تم الحفظ بنجاح')</script>");
                    Project_Log_DB.FillLog(CDataConverter.ConvertToInt(obj.PMP_ID), operation, Project_Log_DB.operation.Employee_Data);
                    //clear_fields();
                    //fill_emplyees();
                }


            }
            else
            {
                lbl_success.Visible = true;
                lbl_success.Text = "يجب استكمال بيانات الموظف اولا ";

                lbl_user.Visible = false;

            }

        }

        else
        {
            lbl_user.Visible = true;
            lbl_success.Visible = false;
            lbl_user.Text = "برجاء إدخال إسم مستخدم أخر";
        }


    }

    //protected void txtmail_TextChanged(object sender, EventArgs e)
    //{
    //    string[] user_mail = txtmail.Text.Split('@');
    //   string user_name2 = user_mail[0];
    //   txt_username.Text = user_name2; 
    //}

    public void clear_fields()
    {
        job_no_txt.Text = "";
        title_txt.Text = "";
        txt_rec_DT.Text = "";
        txtmail.Text = "";
        txt_username.Text = "";
        //chk_allow_Chn_dept.Checked = false;
        //Smart_Search_mang.Clear_Selected();
        // Smart_Search2.Clear_Selected();
        //Smart_Search3.Clear_Selected();
        fill_emplyees();
        Smart_Search_emp.Clear_Controls();
        chk_resp.Checked = false;
        btn_Save.Text = "حفظ";

    }


    protected void btn_addexperience_Click(object sender, EventArgs e)
    {
        int pmp_id = CDataConverter.ConvertToInt(Smart_Search_emp.SelectedValue);
        if (pmp_id > 0)
        {

            Employee_Experience_DT eexperience = new Employee_Experience_DT();
            int employeeExperience = CDataConverter.ConvertToInt(update_id2.Value);
            if (employeeExperience > 0)
            {
                eexperience = Employee_Experience_DB.SelectByID(employeeExperience);
                eexperience.FromDate = txtExperienceStartDate.Text;
                eexperience.ToDate = txtExperienceEndDate.Text;
                eexperience.organization = txt_organization.Text;
                eexperience.pmp_id = pmp_id;
                eexperience.job_title = txt_jobtitle.Text;
                eexperience.desc = txt_tasks.Text;

                Employee_Experience_DB.Save(eexperience);
                Label37.Visible = true;
                Label37.Text += Smart_Search_emp.SelectedText;
            }
            else
            {
                eexperience.FromDate = txtExperienceStartDate.Text;
                eexperience.ToDate = txtExperienceEndDate.Text;
                eexperience.organization = txt_organization.Text;
                eexperience.pmp_id = pmp_id;
                eexperience.job_title = txt_jobtitle.Text;
                eexperience.desc = txt_tasks.Text;
                Employee_Experience_DB.Save(eexperience);
                Label37.Visible = true;
                Label37.Text = "تم حفظ بيانات الخبرات السابقة بنجاح للموظف  :" + Smart_Search_emp.SelectedText;
            }
            DataTable dt_sub_cat2 = General_Helping.GetDataTable(" SELECT  * FROM  Employee_Experience where pmp_id=" + pmp_id);
            gv_experience.DataSource = dt_sub_cat2;
            gv_experience.DataBind();
        }
        clear();
    }

    private void clear()
    {
        txt_organization.Text = "";
        txt_jobtitle.Text = "";
        txt_tasks.Text = "";
        txtExperienceEndDate.Text = "";
        txtExperienceStartDate.Text = "";


    }
    protected void gv_experience_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "RemoveItem")
        {

            Employee_Experience_DB.Delete(CDataConverter.ConvertToInt(e.CommandArgument));
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم الحذف بنجاح')</script>");

            DataTable dt_sub_cat = General_Helping.GetDataTable(" SELECT  * FROM  Employee_Experience where pmp_id=" + CDataConverter.ConvertToInt(Smart_Search_emp.SelectedValue));
            gv_experience.DataSource = dt_sub_cat;
            gv_experience.DataBind();
            Label37.Visible = true;
            Label37.Text = "تم الحذف بنجاح";
        }

        if (e.CommandName == "editItem")
        {
            Employee_Experience_DT employeExperience = new Employee_Experience_DT();
            employeExperience = Employee_Experience_DB.SelectByID((CDataConverter.ConvertToInt(e.CommandArgument)));
            txt_organization.Text = employeExperience.organization;
            txt_jobtitle.Text = employeExperience.job_title;
            txt_tasks.Text = employeExperience.desc;
            txtExperienceStartDate.Text = employeExperience.FromDate;
            txtExperienceEndDate.Text = employeExperience.ToDate;
            update_id2.Value = employeExperience.id.ToString();
            Label37.Visible = false;


        }
    }
    protected void btn_publicdatasave_Click(object sender, EventArgs e)
    {
        if (Smart_Search_emp.SelectedValue != "")
        {

            Employee_publicdata_DT dt = new Employee_publicdata_DT();

            int pmp_id = CDataConverter.ConvertToInt(Smart_Search_emp.SelectedValue);
            dt = Employee_publicdata_DB.SelectBypmp_id(pmp_id);
            if (dt.id > 0)
            {

                dt.pmp_id = pmp_id;


                dt.mail = txt_othermail.Text;
                dt.phone = txt_otherphone.Text;

                dt.mobile = txt_mobile.Text;
                if (rb_ismanager.SelectedItem.Value == "1")
                {
                    dt.is_manager = true;
                    dt.noofemployee = Convert.ToInt32(txt_noofemployee.Text);
                }
                else if (rb_ismanager.SelectedItem.Value == "0")
                {
                    dt.is_manager = false;
                    dt.noofemployee = 0;
                }
                dt.current_tasks = txt_currenttasks.Text;
                dt.englishlevel = Convert.ToInt32(rb_englishlevel.SelectedItem.Value);
                Employee_publicdata_DB.Save(dt);
            }
            else
            {
                dt.pmp_id = pmp_id;


                dt.mail = txt_othermail.Text;
                dt.phone = txt_otherphone.Text;

                dt.mobile = txt_mobile.Text;
                if (rb_ismanager.SelectedItem.Value == "1")
                {
                    dt.is_manager = true;
                    dt.noofemployee = Convert.ToInt32(txt_noofemployee.Text);
                }
                else if (rb_ismanager.SelectedItem.Value == "0")
                {
                    dt.is_manager = false;
                    dt.noofemployee = 0;
                }
                dt.current_tasks = txt_currenttasks.Text;
                dt.englishlevel = Convert.ToInt32(rb_englishlevel.SelectedItem.Value);
            }
            Employee_publicdata_DB.Save(dt);
            Label36.Visible = true;
            Label36.Text = "تم حفظ البيانات العامة بنجاح للموظف  :  " + Smart_Search_emp.SelectedText;
        }
        else
        {
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('يجب إختيار موظف اولا')</script>");

        }
    }
    protected void changing(object sender, EventArgs e)
    {
        if (rb_ismanager.SelectedValue == "1")
        {
            noofemployee_tr.Visible = true;
        }
        else if (rb_ismanager.SelectedValue == "0")
        {
            noofemployee_tr.Visible = false;
        }
    }
    public void btn_save_EX_Training_Click(object sender, EventArgs e)
    {
        int pmp_id = CDataConverter.ConvertToInt(Smart_Search_emp.SelectedValue);
        if (pmp_id > 0)
        {
            //DataTable datatable = Employee_Ex_Training_DB.SelectByPmp_id(pmp_id);
            Employee_Ex_Training_DT eExTraining = new Employee_Ex_Training_DT();
            int employeeExTraining = CDataConverter.ConvertToInt(update_id.Value);
            //if (employeeExTraining > 0)
            //{

            // eExTraining = Employee_Ex_Training_DB.SelectByID(employeeExTraining);
            eExTraining.id = employeeExTraining;
            eExTraining.pmp_id = pmp_id;
            eExTraining.course_name = txt_coursename.Text.ToString();
            eExTraining.start_date = tx_startdate.Text.ToString();
            eExTraining.end_date = txt_endate.Text;
            Employee_Ex_Training_DB.Save(eExTraining);

            //}
            ////Employee_Ex_Training_DT eExTraining = new Employee_Ex_Training_DT();
            //eExTraining.pmp_id = pmp_id;
            //eExTraining.course_name = txt_coursename.Text.ToString();
            //eExTraining.start_date = tx_startdate.Text.ToString();
            //eExTraining.end_date = txt_endate.Text;

            //Employee_Ex_Training_DB.Save(eExTraining);
            DataTable dt_sub_cat = General_Helping.GetDataTable(" SELECT  * FROM Employee_Ex_Training where pmp_id=" + pmp_id);
            gv_Employee_EX_TRaing.DataSource = dt_sub_cat;
            gv_Employee_EX_TRaing.DataBind();
            Label38.Visible = true;
            Label38.Text = "تم حفظ بيانات الدورات التريبية بنجاح للموظف  :  " + Smart_Search_emp.SelectedText;

        }
        clears();
    }
    private void clears()
    {
        txt_coursename.Text = "";
        tx_startdate.Text = "";
        txt_endate.Text = "";

    }
    protected void gv_Employee_EX_TRaing_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "RemoveItem")
        {


            Employee_Ex_Training_DB.Delete(CDataConverter.ConvertToInt(e.CommandArgument));
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم الحذف بنجاح')</script>");

            DataTable dt_sub_cat = General_Helping.GetDataTable(" SELECT  * FROM Employee_Ex_Training where pmp_id=" + CDataConverter.ConvertToInt(Smart_Search_emp.SelectedValue));
            gv_Employee_EX_TRaing.DataSource = dt_sub_cat;
            gv_Employee_EX_TRaing.DataBind();
            Label38.Visible = true;
            Label38.Text = "تم الحذف بنجاح";
        }
        if (e.CommandName == "editItem")
        {
            Employee_Ex_Training_DT employeeExTraining = new Employee_Ex_Training_DT();

            employeeExTraining = Employee_Ex_Training_DB.SelectByID((CDataConverter.ConvertToInt(e.CommandArgument)));
            txt_coursename.Text = employeeExTraining.course_name;
            tx_startdate.Text = employeeExTraining.start_date;
            txt_endate.Text = employeeExTraining.end_date;
            update_id.Value = employeeExTraining.id.ToString();
            Label38.Visible = false;


        }
    }
    private void fillcontrols(int pmp_id)
    {
        //int pmp_id = Convert.ToInt32(Session_CS.pmp_id);
        //Employee_Ex_Training_DT employeeExTraining = new Employee_Ex_Training_DT();
        Employee_publicdata_DT employeePublicdata = new Employee_publicdata_DT();
        //Employee_Experience_DT employeExperience = new Employee_Experience_DT();
        //employeeExTraining = Employee_Ex_Training_DB.SelectByPmp_id(pmp_id);
        employeePublicdata = Employee_publicdata_DB.SelectBypmp_id(pmp_id);
        //employeExperience = Employee_Experience_DB.SelectBypmp_id(pmp_id);
        txt_otherphone.Text = employeePublicdata.phone;
        txt_mobile.Text = employeePublicdata.mobile;
        txt_othermail.Text = employeePublicdata.mail;
        txt_currenttasks.Text = employeePublicdata.current_tasks;
        if (employeePublicdata.is_manager)
            rb_ismanager.SelectedValue = "1";
        else
            rb_ismanager.SelectedValue = "0";
        if (employeePublicdata.englishlevel > 0)
            rb_englishlevel.SelectedValue = employeePublicdata.englishlevel.ToString();
        txt_noofemployee.Text = employeePublicdata.noofemployee.ToString();
        //////////////////experience///////////

        // txt_organization.Text=employeExperience.organization;
        //txt_jobtitle.Text= employeExperience.job_title;
        //txt_tasks.Text = employeExperience.desc ;
        //ddl_year.SelectedItem.Value = employeExperience.experience_year;
        //////////////////////training/////////////////
        //txt_coursename.Text = employeeExTraining.course_name;
        //tx_startdate.Text= employeeExTraining.start_date ;
        DataTable dt_sub_cat = General_Helping.GetDataTable(" SELECT  * FROM  Employee_Experience where pmp_id=" + pmp_id);
        gv_experience.DataSource = dt_sub_cat;
        gv_experience.DataBind();



        DataTable dt_sub_cat1 = General_Helping.GetDataTable(" SELECT  * FROM Employee_Ex_Training where pmp_id=" + pmp_id);
        gv_Employee_EX_TRaing.DataSource = dt_sub_cat1;
        gv_Employee_EX_TRaing.DataBind();

        //btn_publicdatasave.Text = "تعديل";
        //btn_addexperience.Text = "تعديل";
        //btn_save_EX_Training.Text = "تعديل";

    }
    public void DimControls()
    {
        //ddl_sectors.Enabled =
        chk_allow_Chn_dept.Enabled =
        job_no_txt.Enabled =
        title_txt.Enabled =
        txt_rec_DT.Enabled =
        txtmail.Enabled =
        ddl_status.Enabled =
        txt_universityname.Enabled =
        txt_major.Enabled =
            //Smart_Search_emp.Enabled = 
        ddl_universitydegree.Enabled = false;


    }

    #region Direct Manager and Higher Manager

    #region Methods

    private void FillManagersGridView()
    {
        string employee_id;


        //will be deleted just for testing
        //Fill_All_Smart_Employee();
        //will be converted to stored procedures
        string x = Smart_Search_emp.SelectedValue;
        string SQL =
            "SELECT * ," + "\r\n" +
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
            "       ON Employee_Managers.Mngr_Emp_ID = ManagerName.pmp_id" + "\r\n";

        if (Request.QueryString["pmp_id"] != null)
        {
            employee_id = Request["pmp_id"].ToString();
            SQL += " WHERE Employee_Managers.emp_id =" + employee_id;

        }
        else
        {

            SQL += " WHERE Employee_Managers.emp_id =" + Smart_Search_emp.SelectedValue;
        }
        DataTable dt = General_Helping.GetDataTable(SQL);
        ViewState["dtInitialData"] = dt;
        gvManagers.DataSource = dt;
        gvManagers.DataBind();



    }

    private void Save()
    {

        int drctMngr = 0;
        int HiMngr = 0;
        if (!CheckMngrNotAddedBefor())
        {
            DataTable dt = (DataTable)ViewState["dtInitialData"];
            if (smrtDirectManager.SelectedValue != "")
            {
                DataRow dtRow = dt.NewRow();
                dtRow["Emp_Mngr_ID"] = 0;
                dtRow["Emp_ID"] = Smart_Search_emp.SelectedValue;
                dtRow["Mngr_Emp_ID"] = smrtDirectManager.SelectedValue;
                dtRow["Mngr_Level"] = 1;
                dtRow["MngrName"] = smrtDirectManager.SelectedText;
                dtRow["managerlevel"] = "مدير مباشر";
                dt.Rows.Add(dtRow);
                drctMngr = InsertUpdateEmpMngr(dtRow);
            }
            if (smrtHigherManager.SelectedValue != "")
            {
                DataRow dtRow = dt.NewRow();
                dtRow["Emp_Mngr_ID"] = 0;
                dtRow["Emp_ID"] = Smart_Search_emp.SelectedValue;
                dtRow["Mngr_Emp_ID"] = smrtHigherManager.SelectedValue;
                dtRow["Mngr_Level"] = 2;
                dtRow["MngrName"] = smrtHigherManager.SelectedText;
                dtRow["managerlevel"] = " مدير اعلي";
                dt.Rows.Add(dtRow);
                HiMngr = InsertUpdateEmpMngr(dtRow);
            }
            FillManagersGridView();
            ClearCtrls();
            if (drctMngr >= 0 & HiMngr >= 0)
            {
                // Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('تم الحفظ بنجاح ')</script>");
                lbl_res.Visible = true;
                lbl_res.Text = "تم حفظ بيانات مديرين تقييم الاداء بنجاح للموظف  :  " + Smart_Search_emp.SelectedText;
            }
            else
                Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('حدث خطا اثناء الحفظ يرجي اعادة المحاولة ')</script>");
        }
        else
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('عفوا يرجي عدم تكرار البيانات ')</script>");
    }

    private void EditRecord()
    {
        int drctMngr = 0;
        int HiMngr = 0;
        if (!CheckMngrNotAddedBefor())
        {
            DataTable dt = (DataTable)ViewState["dtInitialData"];
            //int id = To .ConvertToInt(gvManagers.Rows[e.RowIndex].Cells[2].Text.ToString());

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //if (Equals(id, dt.Rows[i]["id"]))
                if (ViewState["Emp_Mngr_ID"].ToString() == dt.Rows[i]["Emp_Mngr_ID"].ToString())
                {
                    dt.Rows[i].Delete();
                    dt.AcceptChanges();
                    if (smrtDirectManager.SelectedValue != "")
                    {
                        DataRow dtRow = dt.NewRow();
                        dtRow["Emp_Mngr_ID"] = CDataConverter.ConvertToInt(ViewState["Emp_Mngr_ID"]);
                        dtRow["Emp_ID"] = Smart_Search_emp.SelectedValue;
                        dtRow["Mngr_Emp_ID"] = smrtDirectManager.SelectedValue;
                        dtRow["Mngr_Level"] = 1;
                        dtRow["MngrName"] = smrtDirectManager.SelectedText;
                        dtRow["managerlevel"] = "مدير مباشر";
                        dt.Rows.Add(dtRow);
                        drctMngr = InsertUpdateEmpMngr(dtRow);
                    }
                    if (smrtHigherManager.SelectedValue != "")
                    {
                        DataRow dtRow = dt.NewRow();
                        dtRow["Emp_Mngr_ID"] = CDataConverter.ConvertToInt(ViewState["Emp_Mngr_ID"]);
                        dtRow["Emp_ID"] = Smart_Search_emp.SelectedValue;
                        dtRow["Mngr_Emp_ID"] = smrtHigherManager.SelectedValue;
                        dtRow["Mngr_Level"] = 2;
                        dtRow["MngrName"] = smrtHigherManager.SelectedText;
                        dtRow["managerlevel"] = " مدير اعلي";
                        dt.Rows.Add(dtRow);
                        HiMngr = InsertUpdateEmpMngr(dtRow);
                    }

                    break;
                }
            }
            FillManagersGridView();
            ClearCtrls();
            ViewState["Emp_Mngr_ID"] = null;
            if (drctMngr >= 0 & HiMngr >= 0)
            {
                Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('تم الحفظ بنجاح ')</script>");
            }
            else
                Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('حدث خطا اثناء الحفظ يرجي اعادة المحاولة ')</script>");
        }
        else
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('عفوا يرجي عدم تكرار البيانات ')</script>");
    }

    private void ClearCtrls()
    {
        smrtDirectManager.Clear_Controls();
        smrtHigherManager.Clear_Controls();
    }

    #endregion

    #region Event Handlars

    protected void gvManagers_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        DataTable dt = (DataTable)ViewState["dtInitialData"];
        string id = (string)gvManagers.DataKeys[e.RowIndex].Value.ToString();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (id == dt.Rows[i]["Emp_Mngr_ID"].ToString())
            {
                Employee_Managers_DB.Delete(CDataConverter.ConvertToInt(id));
                dt.Rows[i].Delete();
                dt.AcceptChanges();
                break;
            }
        }
        ViewState["dtInitialData"] = dt;
        gvManagers.DataSource = dt;
        gvManagers.DataBind();
        lbl_res.Visible = true;
        lbl_res.Text = "تم الحذف بنجاح ";

    }

    protected void gvManagers_RowEditing(object sender, GridViewEditEventArgs e)
    {

        ViewState["Emp_Mngr_ID"] = (int)gvManagers.DataKeys[e.NewEditIndex].Value;
        Employee_Managers_DT ObjEmpMngr = Employee_Managers_DB.SelectByID(CDataConverter.ConvertToInt(ViewState["Emp_Mngr_ID"]));
        if (ObjEmpMngr.Mngr_Level == 1)//direct manager
        {
            smrtDirectManager.SelectedValue = ObjEmpMngr.Mngr_Emp_ID.ToString();
        }
        else if (ObjEmpMngr.Mngr_Level == 2)//higher manager
        {
            smrtHigherManager.SelectedValue = ObjEmpMngr.Mngr_Emp_ID.ToString();
        }

    }

    protected void imgbtnAddMngr_Click(object sender, EventArgs e)
    {
        try
        {
            if (ViewState["Emp_Mngr_ID"] == null)//new record
            {
                if (smrtHigherManager.SelectedValue != "" | smrtDirectManager.SelectedValue != "")
                {
                    Save();
                    Fill_All_Smart_Employee();
                }
                else
                    Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('عفوا يرجي اختيار احد المديرين علي الاقل ')</script>");

            }
            else//edited record
            {
                EditRecord();
            }

        }
        catch (Exception)
        {

            throw;
        }
    }

    #endregion

    #region Functions

    private bool CheckMngrNotAddedBefor()
    {
        DataTable dt = (DataTable)ViewState["dtInitialData"];

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (smrtDirectManager.SelectedValue == dt.Rows[i]["Mngr_Emp_ID"].ToString())
            {
                if (CDataConverter.ConvertToInt(dt.Rows[i]["Mngr_Level"]) == 1)
                {
                    smrtDirectManager.Clear_Controls();
                    return true;
                }

            }
            if (smrtHigherManager.SelectedValue == dt.Rows[i]["Mngr_Emp_ID"].ToString())
            {
                if (CDataConverter.ConvertToInt(dt.Rows[i]["Mngr_Level"]) == 2)
                {
                    smrtHigherManager.Clear_Controls();
                    return true;
                }
            }
        }
        return false;
    }

    private int InsertUpdateEmpMngr(DataRow dtRow)
    {
        Employee_Managers_DT dtManagers = new Employee_Managers_DT();
        dtManagers.Emp_Mngr_ID = CDataConverter.ConvertToInt(dtRow["Emp_Mngr_ID"]);
        dtManagers.Emp_ID = CDataConverter.ConvertToInt(dtRow["Emp_ID"]);
        dtManagers.Mngr_Emp_ID = CDataConverter.ConvertToInt(dtRow["Mngr_Emp_ID"]);
        dtManagers.Mngr_Level = CDataConverter.ConvertToInt(dtRow["Mngr_Level"]);
        return Employee_Managers_DB.Save(dtManagers);
    }

    protected void TabPanel_All_ActiveTabChanged(object sender, EventArgs e)
    {
        lbl_success.Visible = false;
        lbl_res.Visible = false;
        Label36.Visible = false;
        Label38.Visible = false;
    }


    #endregion

    #endregion

}



