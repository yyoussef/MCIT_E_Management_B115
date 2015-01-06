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
using CrystalDecisions.CrystalReports.Engine; 
using System.Data.SqlClient;
using CrystalDecisions.Shared;
using MCIT.Web.Data;
using System.Data.SqlClient;
using DBL;
using activityLeveling;
using ReportsClass;

public partial class UserControls_Eval_Reports : System.Web.UI.UserControl
{
    string sql;
    SqlConnection conn;
    SqlDataAdapter da;
    DataSet ds;
   
    private string sql_Connection = Universal.GetConnectionString();
    //Session_CS Session_CS = new Session_CS();
    protected override void OnInit(EventArgs e)
    {
       

        #region BROWSER FOR departments

        //Smrt_Srch_DropDep.sql_Connection = sql_Connection;
        ////Smrt_Srch_DropDep.Query = "select Dept_ID,Dept_name from Departments where Dept_ID <> 6";
        //string Query = "select Dept_ID,Dept_name from Departments where Dept_ID <> 6 and sec_sec_id='" + ddl_sec.SelectedValue + "'";
        //Smrt_Srch_DropDep.datatble = General_Helping.GetDataTable(Query);
        //Smrt_Srch_DropDep.Value_Field = "Dept_ID";
        //Smrt_Srch_DropDep.Text_Field = "Dept_name";
        //Smrt_Srch_DropDep.DataBind();
      
        this.Smart_Search_Departments.Value_Handler += new Smart_Search.Delegate_Selected_Value(MOnMember_Data_Depart);
        this.smart_employee.Value_Handler += new Smart_Search.Delegate_Selected_Value(MOnMember_Data);

        #endregion


        base.OnInit(e);
    }







    void fil_Departements()
    
    {

      //  Smart_Search_Departments.sql_Connection = sql_Connection;

      ////  Smart_Search_Departments.Query = " select distinct Dept_ID,Dept_name from Departments WHERE sec_sec_id =  " + Ddl_Sectors.SelectedValue;
      //  string Query = " select distinct Dept_ID,Dept_name from Departments WHERE sec_sec_id =  " + Ddl_Sectors.SelectedValue;
      //  Smart_Search_Departments.datatble = General_Helping.GetDataTable(Query);
      //  Smart_Search_Departments.Value_Field = "Dept_ID";
      //  Smart_Search_Departments.Text_Field = "Dept_name";
      //  Smart_Search_Departments.DataBind();
      //  this.Smart_Search_Departments.Value_Handler += new Smart_Search.Delegate_Selected_Value(MOnMember_Data_Depart);
      //  Smart_Search_Departments.SelectedValue = Session_CS.dept_id.ToString();

   
    }

    protected void ddl_sectors_SelectedIndexChanged(object sender, EventArgs e)
    {
        fill_smartemp();
       
       
    }

    private void fill_smartemp()
    {
        Smrt_Srch_DropDep.sql_Connection = sql_Connection;
        if (ddl_sec.SelectedValue != "" && ddl_sec.SelectedValue != null && ddl_sec.SelectedValue != "0")
        {
            DataTable dt = General_Helping.GetDataTable("select Dept_ID,Dept_name from Departments where sec_sec_id='" + ddl_sec.SelectedValue + "'");
            Smrt_Srch_DropDep.datatble = dt;
            Smrt_Srch_DropDep.Value_Field = "Dept_ID";
            Smrt_Srch_DropDep.Text_Field = "Dept_name";
            Smrt_Srch_DropDep.DataBind();

        }
    }

    private void MOnMember_Data_Depart(string Value)
    {
        if (Value != "")
        {
            fil_employee();
        }
    }
    void fil_employee()
    {
        smart_employee.sql_Connection = sql_Connection;

      //smart_employee.Query = "SELECT pmp_id, pmp_name FROM employee where pmp_id not in ( 68,596,597 ) and Dept_Dept_id =  " + Smart_Search_Departments.SelectedValue;
        string Query = "SELECT pmp_id, pmp_name FROM employee where pmp_id not in ( 68,596,597 ) and Dept_Dept_id =  " + Smart_Search_Departments.SelectedValue;

        if (hidden_manager.Value == "manager")
        {
            Query += " and pmp_id in (SELECT dbo.Evaluation_For_Manager.Pmp_Id FROM Evaluation_For_Manager inner join employee on Evaluation_For_Manager.Pmp_Id =employee.Pmp_Id  )";
            hidden_manager.Value = "";
        }
        smart_employee.datatble = General_Helping.GetDataTable(Query);
        smart_employee.Show_Code = false;
        smart_employee.Value_Field = "pmp_id";
        smart_employee.Text_Field = "pmp_name";
        smart_employee.DataBind();
    }


    protected void Ddl_Sectors_SelectedIndexChanged(object sender, EventArgs e)
    {
        fil_Departements();
    }

    private void MOnMember_Data(string Value)
    {
        dropdept_fun();
    }

    private void MOnMember_Datamanage(string Value)
    {
        dropprojmanage_fun();
    }
    private void MOnMember_Databudget(string Value)
    {
        conn = new SqlConnection(sql_Connection);
        string name = "";
        int budget = 0;
        string deptname = "";
        if (Value != "")
        {
            sql = "SELECT dbo.Project.Proj_Title, dbo.Project.Proj_InitValue AS Proj_InitValue_integer, dbo.EMPLOYEE.pmp_name, dbo.Project.Proj_id FROM  dbo.Project INNER JOIN  dbo.EMPLOYEE ON dbo.Project.pmp_pmp_id = dbo.EMPLOYEE.PMP_ID where Proj_id= " + Value;
            ds = new DataSet();
            da = new SqlDataAdapter(sql, conn);
            da.Fill(ds, "project_data");
            name = ds.Tables[0].Rows[0]["pmp_name"].ToString();
            budget = CDataConverter.ConvertToInt(ds.Tables[0].Rows[0]["Proj_InitValue_integer"].ToString());
            Labname.Text = name;
            LabValue.Text = budget.ToString();

            string sqldept = "select dept_name,dept_id,proj_id from Departments join project on Project.Dept_Dept_id = Departments.Dept_ID where Project.Proj_id =  " + Value;
            DataSet dss = new DataSet();
            SqlDataAdapter dat = new SqlDataAdapter(sqldept, conn);
            dat.Fill(dss, "dept_data");
            deptname = dss.Tables[0].Rows[0]["dept_name"].ToString();
            LabDeptname.Text = deptname;
            Label6.Visible = false;

            Smart_Search_main.sql_Connection = sql_Connection;
           // Smart_Search_main.Query = "select PActv_ID, Parent_PActv_Desc from dbo.Project_Activities where  PActv_Parent=0 and proj_proj_id=" + Value;
            string Query = "select PActv_ID, Parent_PActv_Desc from dbo.Project_Activities where  PActv_Parent=0 and proj_proj_id=" + Value;
            Smart_Search_main.datatble = General_Helping.GetDataTable(Query);
            Smart_Search_main.Value_Field = "PActv_ID";
            Smart_Search_main.Text_Field = "Parent_PActv_Desc";
            Smart_Search_main.DataBind();
            this.Smart_Search_main.Value_Handler += new Smart_Search.Delegate_Selected_Value(MOnMember_subactivities);


        }
    }
    private void MOnMember_subactivities(string Value)
    {
        if (Value != "")
        {
            Smart_Search_sub.sql_Connection = sql_Connection;

            //Smart_Search_sub.Query = "select PActv_ID, PActv_Desc from dbo.Project_Activities where PActv_Parent=" + Value;
            string Query = "select PActv_ID, PActv_Desc from dbo.Project_Activities where PActv_Parent=" + Value;
            Smart_Search_sub.datatble = General_Helping.GetDataTable(Query);
            Smart_Search_sub.Value_Field = "PActv_ID";
            Smart_Search_sub.Text_Field = "PActv_Desc";
            Smart_Search_sub.DataBind();
        }
    }
    /// <summary>
    /// /////// end 
    /// </summary>
    /// <param name="sender"></param> 
    /// <param name="e"></param>


    protected void Page_Load(object sender, EventArgs e)
    {
        conn = new SqlConnection(sql_Connection);
        Smart_Search_Departments.Show_OrgTree = true;
        Smrt_Srch_DropDep.Show_OrgTree = true;
        fill_structure();
        if (Session_CS.pmp_name != null)
        {
            if (!IsPostBack)
            {
                fillddl();
               // Ddl_Sectors.DataBind();
                //Ddl_Sectors.SelectedValue = Session_CS.sec_id.ToString();
                //fil_Departements();
                hidden_manager.Value = "";


              
                int pmp = int.Parse(Session_CS.pmp_id.ToString());
                //////////////////////////////////// get project manager data to drop list ////////////////////
                sql = "select distinct pmp_pmp_id,PTem_Name,rol_rol_id from dbo.Project_Team where rol_rol_id=4";
                ds = new DataSet();
                da = new SqlDataAdapter(sql, conn);
                da.Fill(ds, "projectsmanage");


                sql = "select id,proj_category from Category";
                ds = new DataSet();
                da = new SqlDataAdapter(sql, conn);
                da.Fill(ds, "category");
                Drop_category.DataSource = ds.Tables[0];
                Drop_category.DataValueField = "id";
                Drop_category.DataTextField = "proj_category";
                Drop_category.DataBind();
                Drop_category.Items.Insert(0, new ListItem("اختر التصنيف......", "0"));
                /////////////////////////////////// get techniqe from tabel to drop list /////////////////////
                sql = "select id,technique from Technique";
                ds = new DataSet();
                da = new SqlDataAdapter(sql, conn);
                da.Fill(ds, "Technique");
                Drop_technology.DataSource = ds.Tables[0];
                Drop_technology.DataValueField = "id";
                Drop_technology.DataTextField = "technique";
                Drop_technology.DataBind();
                Drop_technology.Items.Insert(0, new ListItem("اختر التقنية......", "0"));
                ///////////////////// get data tp departments drop list /////////////////////////
                sql = "select Dept_ID,Dept_name from Departments";
                ds = new DataSet();
                da = new SqlDataAdapter(sql, conn);
                da.Fill(ds, "dept");

                //////////////////// get dates from store to drop list /////////////////////////////
                sql = "select id,convert(nvarchar,available_Date,111) as Date,available_Date from Store";
                ds = new DataSet();
                da = new SqlDataAdapter(sql, conn);
                da.Fill(ds, "dates");
                DropDate.DataSource = ds.Tables[0];
                DropDate.DataValueField = "available_Date";
                DropDate.DataTextField = "Date";
                DropDate.DataBind();
                DropDate.Items.Insert(0, new ListItem("اختر تاريخ الصرف المطلوب......", "0"));

                ///////////////// get organizations from org table to drop list////////////////
                sql = "SELECT DISTINCT dbo.Organization.Org_Desc, dbo.Organization.Org_ID";
                sql += " FROM dbo.Organization INNER JOIN dbo.Project_Organization ON dbo.Organization.Org_ID = dbo.Project_Organization.org_org_id";
                ds = new DataSet();
                da = new SqlDataAdapter(sql, conn);
                da.Fill(ds, "org");
                Droporg.DataSource = ds.Tables[0];
                Droporg.DataValueField = "Org_ID";
                Droporg.DataTextField = "Org_Desc";
                Droporg.DataBind();
                Droporg.Items.Insert(0, new ListItem("اختر الجهة المستفيدة ......", "0"));
                // ahmed salah account //
                int group_id = int.Parse(Session_CS.group_id.ToString());
                
                    eval_statusLB.Visible = true;
                    Image1.Visible = true;
                    //Ddl_Sectors.Enabled = true;
                    tr_empevaltot.Visible = true;

               if(Session_CS.UROL_UROL_ID !=14)
               {
                   showevalreport_forsector();

               }
               

            }

        }

    }
    protected void fill_structure()
    {

        string Query = "";
        Query = "SELECT  * from    Departments  where foundation_id='" + Session_CS.foundation_id + "'";

        Smart_Search_Departments.datatble = General_Helping.GetDataTable(Query);
        Smart_Search_Departments.Value_Field = "Dept_id";
        Smart_Search_Departments.Text_Field = "Dept_name";
        Smart_Search_Departments.DataBind();

        Smrt_Srch_DropDep.datatble = General_Helping.GetDataTable(Query);
        Smrt_Srch_DropDep.Value_Field = "Dept_id";
        Smrt_Srch_DropDep.Text_Field = "Dept_name";
        Smrt_Srch_DropDep.DataBind();
                
    }
    public void showevalreport_forsector()
    {
        tr_empeval.Visible = true;
        tr_empevalfunc.Visible = false;
        tr_empevalfunc2.Visible = false;
        tr_empevalfunc3.Visible = false;
        tr_empevalfunc4.Visible = false;
        Tr3.Visible = false;
        Tr5.Visible = false;
        Tr6.Visible = false;
        Tr8.Visible = false;



    }

    protected void fillddl()
    {
        string Sql = "select Sec_id,Sec_name from Sectors where foundation_id = " + CDataConverter.ConvertToInt(Session_CS.foundation_id.ToString());
        DataTable dt = General_Helping.GetDataTable(Sql);
        ddl_sec.DataSource = dt;
        ddl_sec.DataTextField = "Sec_name";
        ddl_sec.DataValueField = "Sec_id";
        ddl_sec.DataBind();
        ddl_sec.Items.Insert(0, new ListItem("إختر القطاع", "0"));



        if (Session_CS.UROL_UROL_ID != null && Session_CS.UROL_UROL_ID != 14)
        {
            ddl_sec.SelectedValue = Session_CS.sec_id.ToString();
            ddl_sec.Enabled = false;
            fill_smartemp();

        }
      

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


    public static void ShowAlertMessage(string error)
    {

        Page page = HttpContext.Current.Handler as Page;
        if (page != null)
        {
            error = error.Replace("'", "\'");
            ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('" + error + "');", true);
        }
    }

    protected void show_hide_tables()
    {
        tbl_Report.Style.Add("display", "none");
        tbl_Paramater.Style.Add("display", "block");
    }

    





    protected void eval_empLB_Click(object sender, EventArgs e)
    {
        hidden_Rpt_Id.Value = "Evaluation_Report";
        Div_Proj.Style.Add("display", "none");
        Div_Proj_Mngr.Style.Add("display", "none");
        Div_Date_Needs.Style.Add("display", "none");
        Div_Dates_Demands.Style.Add("display", "none");
        Div_Dept.Style.Add("display", "none");
        Div_Date_balance.Style.Add("display", "none");

      
        Div_emp.Style.Add("display", "block");
        show_hide_tables();
        Label6.Visible = false;

        Page.Title = "تقرير " + eval_empLB.Text;
        Label2.Visible = true;
        Label2.Text = Page.Title;
        Drop_Date_fun();
        
    }
    protected void eval_emp_mng_Click(object sender, EventArgs e)
    {
        hidden_Rpt_Id.Value = "mng_Evaluation_grouped_Report";
        Div_Proj.Style.Add("display", "none");
        Div_Proj_Mngr.Style.Add("display", "none");
        Div_Date_Needs.Style.Add("display", "none");
        Div_Dates_Demands.Style.Add("display", "none");
        Div_Dept.Style.Add("display", "none");
        Div_Date_balance.Style.Add("display", "none");

    
        Div_emp.Style.Add("display", "block");
        show_hide_tables();
        Label6.Visible = false;

        Page.Title = "تقرير الوظيفى للمديرين " ;
        Label2.Visible = true;
        Label2.Text = Page.Title;
        Drop_Date_fun();
        hidden_manager.Value = "manager";
        
    }
    //protected void eval_emp_groupedLB_Click(object sender, EventArgs e)
    //{
    //    hidden_Rpt_Id.Value = "Evaluation_grouped_Report";
    //    Div_Proj.Style.Add("display", "none");
    //    Div_Proj_Mngr.Style.Add("display", "none");
    //    Div_Date_Needs.Style.Add("display", "none");
    //    Div_Dates_Demands.Style.Add("display", "none");
    //    Div_Dept.Style.Add("display", "none");
    //    Div_Date_balance.Style.Add("display", "none");

    //    //Div_month.Style.Add("display", "block");
    //    //Div_Balance.Style.Add("display", "block");
    //    Div_emp.Style.Add("display", "block");
    //    show_hide_tables();
    //    Label6.Visible = false;

    //    Page.Title = "تقرير " + eval_emp_groupedLB.Text;
    //    Label2.Visible = true;
    //    Label2.Text = Page.Title;
    //    Drop_Date_fun();
    //   // Session["manager"] = 2;
    //}
    protected void eval_mange_groupedLB_Click(object sender, EventArgs e)
    {
        hidden_Rpt_Id.Value = "Evaluation_mange_grouped_Report";
        Div_Proj.Style.Add("display", "none");
        Div_Proj_Mngr.Style.Add("display", "none");
        Div_Date_Needs.Style.Add("display", "none");
        Div_Dates_Demands.Style.Add("display", "none");
        Div_Dept.Style.Add("display", "none");
        Div_Date_balance.Style.Add("display", "none");

        
        Div_emp.Style.Add("display", "block");
        show_hide_tables();
        Label6.Visible = false;
        Button2.Visible = true;

        Button1.Text = "عرض مفصل التقرير";
        Button1.Width = 200;
        Page.Title = "تقرير التقييم الوظيفى للمديرين " ;
        Label2.Visible = true;
        Label2.Text = Page.Title;
        Drop_Date_fun();
        
    }
    protected void eval_statusLB_Click(object sender, EventArgs e)
    {
        hidden_Rpt_Id.Value = "Evaluation_status_Report";
        Div_Proj.Style.Add("display", "none");
        Div_Proj_Mngr.Style.Add("display", "none");
        Div_Date_Needs.Style.Add("display", "none");
        Div_Dates_Demands.Style.Add("display", "none");
        Div_Dept.Style.Add("display", "block");
        Div_Date_balance.Style.Add("display", "none");

     
        Div_emp.Style.Add("display", "none");
        show_hide_tables();
        Label6.Visible = false;

        Page.Title = "تقرير " + eval_statusLB.Text;
        Label2.Visible = true;
        Label2.Text = Page.Title;
        Drop_Date_fun();
        
    }
    protected void direct_mng_finishedLB_Click(object sender, EventArgs e)
    {
        hidden_Rpt_Id.Value = "Direct_mng_finished_Report";
        Div_Proj.Style.Add("display", "none");
        Div_Proj_Mngr.Style.Add("display", "none");
        Div_Date_Needs.Style.Add("display", "none");
        Div_Dates_Demands.Style.Add("display", "none");
        Div_Dept.Style.Add("display", "block");
        Div_Date_balance.Style.Add("display", "none");

      
        Div_emp.Style.Add("display", "none");
        show_hide_tables();
        Label6.Visible = false;

        Page.Title = "تقرير " + direct_mng_finishedLB.Text;
        Label2.Visible = true;
        Label2.Text = Page.Title;
        Drop_Date_fun();
      
    }
    protected void dept_empLB_Click(object sender, EventArgs e)
    {
        hidden_Rpt_Id.Value = "dept_empLB_Click";
        Div_Proj.Style.Add("display", "none");
        Div_Proj_Mngr.Style.Add("display", "none");
        Div_Date_Needs.Style.Add("display", "none");
        Div_Dates_Demands.Style.Add("display", "none");
        Div_Dept.Style.Add("display", "block");
        Div_Date_balance.Style.Add("display", "none");

        Div_emp.Style.Add("display", "none");
        show_hide_tables();
        Label6.Visible = false;

        Page.Title = "تقرير " + " بموظفي الإدارت";
        Label2.Visible = true;
        Label2.Text = Page.Title;
        Drop_Date_fun();
        
    }
    /// <summary>
    /// This function will display a report with the names of employees,
    /// their departements and sectors
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void emp_dept_sector_Click(object sender, EventArgs e)
    {
        hidden_Rpt_Id.Value = "emp_dept_sector_Click";
        //ReportDocument is the object through which the crystal report is accessed,loaded, set dataset and exported
        ReportDocument rptDoc = new ReportDocument();
        rptDoc.Load(Server.MapPath("../Reports/EmployeeData.rpt"));
        Reports.Load_Report(rptDoc);
         
        rptDoc.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.Excel, Response, true, "Employee Data Report");
   
 
    }
    protected void emp_statisticsLB_Click(object sender, EventArgs e)
    {
        hidden_Rpt_Id.Value = "emp_statisticsLB_Click";
        Div_Proj.Style.Add("display", "none");
        Div_Proj_Mngr.Style.Add("display", "none");
        Div_Date_Needs.Style.Add("display", "none");
        Div_Dates_Demands.Style.Add("display", "none");
        Div_Dept.Style.Add("display", "block");
        Div_Date_balance.Style.Add("display", "none");

     
        Div_emp.Style.Add("display", "none");
        show_hide_tables();
        Label6.Visible = false;

        Page.Title = "تقرير " + "إحصائية بموقف تقييم موظفي الإدارات";
        Label2.Visible = true;
        Label2.Text = Page.Title;
        Drop_Date_fun();
      
    }
    //protected void direct_mgr_emp_not_evalLB_Click(object sender, EventArgs e)
    //{
    //    hidden_Rpt_Id.Value = "direct_mgr_emp_not_evalLB_Click";
    //    Div_Proj.Style.Add("display", "none");
    //    Div_Proj_Mngr.Style.Add("display", "none");
    //    Div_Date_Needs.Style.Add("display", "none");
    //    Div_Dates_Demands.Style.Add("display", "none");
    //    Div_Dept.Style.Add("display", "block");
    //    Div_Date_balance.Style.Add("display", "none");

    //    Div_emp.Style.Add("display", "none");
    //    show_hide_tables();
    //    Label6.Visible = false;

    //    Page.Title = "تقرير " + " بالموظفين الذين لم يتم الانتهاء من تقييمهم من المديرين المباشرين";
    //    Label2.Visible = true;
    //    Label2.Text = Page.Title;
    //    Drop_Date_fun();
    
    //}
    //protected void top_mgr_emp_not_evalLB_Click(object sender, EventArgs e)
    //{
    //    hidden_Rpt_Id.Value = "top_mgr_emp_not_evalLB_Click";
    //    Div_Proj.Style.Add("display", "none");
    //    Div_Proj_Mngr.Style.Add("display", "none");
    //    Div_Date_Needs.Style.Add("display", "none");
    //    Div_Dates_Demands.Style.Add("display", "none");
    //    Div_Dept.Style.Add("display", "block");
    //    Div_Date_balance.Style.Add("display", "none");

      
    //    Div_emp.Style.Add("display", "none");
    //    show_hide_tables();
    //    Label6.Visible = false;

    //    Page.Title = "تقرير " + " بالموظفين الذين لم يتم الانتهاء من تقييمهم من المديرين الأعلى";
    //    Label2.Visible = true;
    //    Label2.Text = Page.Title;
    //    Drop_Date_fun();
   
    //}
    protected void top_mng_finishedLB_Click(object sender, EventArgs e)
    {
        hidden_Rpt_Id.Value = "top_mng_finished_Report";
        Div_Proj.Style.Add("display", "none");
        Div_Proj_Mngr.Style.Add("display", "none");
        Div_Date_Needs.Style.Add("display", "none");
        Div_Dates_Demands.Style.Add("display", "none");
        Div_Dept.Style.Add("display", "block");
        Div_Date_balance.Style.Add("display", "none");

     
        Div_emp.Style.Add("display", "none");
        show_hide_tables();
        Label6.Visible = false;

        Page.Title = "تقرير " + top_mng_finishedLB.Text;
        Label2.Visible = true;
        Label2.Text = Page.Title;
        Drop_Date_fun();
     
    }
    //protected void Dept_Emp_Click(object sender, EventArgs e)
    //{
    //    hidden_Rpt_Id.Value = "Department_Employees";
    //    Div_Proj.Style.Add("display", "none");
    //    Div_Proj_Mngr.Style.Add("display", "none");
    //    Div_Date_Needs.Style.Add("display", "none");
    //    Div_Dates_Demands.Style.Add("display", "none");
    //    Div_Dept.Style.Add("display", "block");
    //    Div_Date_balance.Style.Add("display", "none");

    //    //Div_month.Style.Add("display", "block");
    //    //Div_Balance.Style.Add("display", "block");
    //    Div_emp.Style.Add("display", "none");
    //    show_hide_tables();
    //    Label6.Visible = false;

    //    Page.Title = "تقرير " + eval_statusLB.Text;
    //    Label2.Visible = true;
    //    Label2.Text = Page.Title;
    //    Drop_Date_fun();
    //     Session["manager"] = 2;
    //}

    protected void eval_emp_strengthLB_Click(object sender, EventArgs e)
    {
        //hidden_Rpt_Id.Value = "Evaluation_strength_Report";
        //Div_Proj.Style.Add("display", "none");
        //Div_Proj_Mngr.Style.Add("display", "none");
        //Div_Date_Needs.Style.Add("display", "none");
        //Div_Dates_Demands.Style.Add("display", "none");
        //Div_Dept.Style.Add("display", "none");
        //Div_Date_balance.Style.Add("display", "none");

        //Div_month.Style.Add("display", "block");
        //Div_Balance.Style.Add("display", "block");
        //Div_emp.Style.Add("display", "block");
        //show_hide_tables();
        //Label6.Visible = false;

        //Page.Title = "تقرير " + eval_emp_strengthLB.Text;
        //Label2.Visible = true;
        //Label2.Text = Page.Title;
        //Drop_Date_fun();
        //Session["manager"] = 2;
    }

    protected void eval_emp_needsLB_Click(object sender, EventArgs e)
    {
        //hidden_Rpt_Id.Value = "Evaluation_needs_Report";
        //Div_Proj.Style.Add("display", "none");
        //Div_Proj_Mngr.Style.Add("display", "none");
        //Div_Date_Needs.Style.Add("display", "none");
        //Div_Dates_Demands.Style.Add("display", "none");
        //Div_Dept.Style.Add("display", "none");
        //Div_Date_balance.Style.Add("display", "none");

        //Div_month.Style.Add("display", "block");
        //Div_Balance.Style.Add("display", "block");
        //Div_emp.Style.Add("display", "block");
        //show_hide_tables();
        //Label6.Visible = false;

        //Page.Title = "تقرير " + eval_emp_needsLB.Text;
        //Label2.Visible = true;
        //Label2.Text = Page.Title;
        //Drop_Date_fun();
        //Session["manager"] = 2;
    }

    protected void dropprojmanage_fun()
    {
        
        if (Smrt_Srch_projmanage.SelectedValue != "")
        {
           

            Smart_Search_Proj.sql_Connection = sql_Connection;
            //Smart_Search_Proj.Query = "select proj_title,proj_id from project JOIN Project_Team ON Project.Proj_id = dbo.Project_Team.proj_proj_id  where  Project_Team.rol_rol_id = 4 and Project_Team.pmp_pmp_id= " + Smrt_Srch_projmanage.SelectedValue;
            string Query = "select proj_title,proj_id from project JOIN Project_Team ON Project.Proj_id = dbo.Project_Team.proj_proj_id  where  Project_Team.rol_rol_id = 4 and Project_Team.pmp_pmp_id= " + Smrt_Srch_projmanage.SelectedValue;
            Smart_Search_Proj.datatble = General_Helping.GetDataTable(Query);
            Smart_Search_Proj.Value_Field = "proj_id";
            Smart_Search_Proj.Text_Field = "proj_title";
            Smart_Search_Proj.DataBind();

        }

        Label6.Visible = false;

    }



    protected void dropdept_fun()
    {
        if (Smrt_Srch_DropDep.SelectedValue != "")
        {
            string Query = "";
            Smrt_Srch_projmanage.sql_Connection = sql_Connection;
           // Smrt_Srch_projmanage.Query = "select PMP_ID,pmp_name from dbo.EMPLOYEE where rol_rol_id=4 and Dept_Dept_id=" + Smrt_Srch_DropDep.SelectedValue;
             Query = "select PMP_ID,pmp_name from dbo.EMPLOYEE where rol_rol_id=4 and Dept_Dept_id=" + Smrt_Srch_DropDep.SelectedValue;
            Smrt_Srch_projmanage.datatble = General_Helping.GetDataTable(Query);
            Smrt_Srch_projmanage.Value_Field = "PMP_ID";
            Smrt_Srch_projmanage.Text_Field = "pmp_name";
            Smrt_Srch_projmanage.DataBind();
            Smart_Search_Proj.sql_Connection = sql_Connection;
            //Smart_Search_Proj.Query = "select proj_title,proj_id from project where Dept_Dept_id=" + Smrt_Srch_DropDep.SelectedValue;
            Query = "select proj_title,proj_id from project where Dept_Dept_id=" + Smrt_Srch_DropDep.SelectedValue;
            Smart_Search_Proj.datatble = General_Helping.GetDataTable(Query);
            Smart_Search_Proj.Value_Field = "proj_id";
            Smart_Search_Proj.Text_Field = "proj_title";
            Smart_Search_Proj.DataBind();
        }
        else
        {
            string Query = "";
            Smrt_Srch_projmanage.sql_Connection = sql_Connection;
           // Smrt_Srch_projmanage.Query = "select PMP_ID,rol_rol_id,pmp_name from dbo.EMPLOYEE where rol_rol_id=4";
            Query = "select PMP_ID,rol_rol_id,pmp_name from dbo.EMPLOYEE where rol_rol_id=4";
            Smrt_Srch_projmanage.datatble = General_Helping.GetDataTable(Query);
            Smrt_Srch_projmanage.Value_Field = "PMP_ID";
            Smrt_Srch_projmanage.Text_Field = "pmp_name";
            Smrt_Srch_projmanage.DataBind();

            Smart_Search_Proj.sql_Connection = sql_Connection;
            //Smart_Search_Proj.Query = "select proj_title,proj_id from project ";
            Query = "select proj_title,proj_id from project ";
            Smart_Search_Proj.datatble = General_Helping.GetDataTable(Query);
            Smart_Search_Proj.Value_Field = "proj_id";
            Smart_Search_Proj.Text_Field = "proj_title";
            Smart_Search_Proj.DataBind();

        }
        Label6.Visible = false;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        int emp = 0;


        /////////////////////////////////////////////////////////// Evaluation Report ///////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        if (hidden_Rpt_Id.Value == "Evaluation_Report")
        {
           
            string user = Session_CS.pmp_name.ToString();
            int group = CDataConverter.ConvertToInt(Session_CS.group_id.ToString());
            ReportDocument rd = new ReportDocument();
            string s = "";
            if (smart_employee.SelectedValue != "")
            {
                //int direct_empId =0;
                //DataTable dt = Employee_Managers_DB.Selectby_EmpId(CDataConverter.ConvertToInt(smart_employee.SelectedValue), 1);
                //if (dt.Rows.Count > 0)
                //{
                //      direct_empId = CDataConverter.ConvertToInt(dt.Rows[0]["Mngr_Emp_ID"].ToString());
                //}

                s = Server.MapPath("../Reports/Evaluation_Report_All.rpt");
                rd.Load(s);

                Reports.Load_Report(rd);

                rd.SetParameterValue("@pmp_id", CDataConverter.ConvertToInt(smart_employee.SelectedValue), "Header_Eval_Report.rpt");

                rd.SetParameterValue("@pmp_id", CDataConverter.ConvertToInt(smart_employee.SelectedValue), "sub_Evaluation_Rep_first.rpt");
                rd.SetParameterValue("@pmp_id", CDataConverter.ConvertToInt(smart_employee.SelectedValue), "sub_Evaluation_Rep_strengh_amira.rpt");
                rd.SetParameterValue("@pmp_id", CDataConverter.ConvertToInt(smart_employee.SelectedValue), "sub_Evaluation_Rep_weakness_amira.rpt");
                rd.SetParameterValue("@pmp_id", CDataConverter.ConvertToInt(smart_employee.SelectedValue), "sub_Evaluation_Rep_Needs.rpt");
                rd.SetParameterValue("@pmp_id", CDataConverter.ConvertToInt(smart_employee.SelectedValue), "signatures_Eval_Report.rpt");
                rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
                rd.SetParameterValue("@user", user, "footerRep.rpt");


               
                    rd.SetParameterValue("mng_type", 2, "sub_Evaluation_Rep_first.rpt");

                    rd.SetParameterValue("mng_type", 2, "sub_Evaluation_Rep_strengh_amira.rpt");

                    rd.SetParameterValue("mng_type", 2, "sub_Evaluation_Rep_weakness_amira.rpt");

                    rd.SetParameterValue("mng_type", 2, "sub_Evaluation_Rep_Needs.rpt");

              //  }

                     rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report");


              
            }
            else
            {
                ShowAlertMessage("!!!!!يجب اختيار موظف !!!!");
                return;
            }

        

        



        }
        //else if (hidden_Rpt_Id.Value == "Evaluation_grouped_Report")
        //{
        //    int group = CDataConverter.ConvertToInt(Session_CS.group_id.ToString());
        //    ReportDocument rd = new ReportDocument();
        //    string s = "";
        //    if (smart_employee.SelectedValue != "")
        //    {


        //        //int group = CDataConverter.ConvertToInt(Session_CS.group_id.ToString());
        //        //ReportDocument rd = new ReportDocument();
        //        //string s = "";



        //        string user = Session_CS.pmp_name.ToString();

        //        s = Server.MapPath("../Reports/Evaluation_Report_All_groupby_evaluator.rpt");

        //        rd.Load(s);

        //        Load_Report(rd);
        //        //rd.SetParameterValue("@pmp_id", CDataConverter.ConvertToInt(smart_employee.SelectedValue));
        //        // rd.("@pmp_id", CDataConverter.ConvertToInt(smart_employee.SelectedValue));

        //        rd.SetParameterValue("@pmp_id", CDataConverter.ConvertToInt(smart_employee.SelectedValue), "Header_Eval_Report.rpt");

        //        rd.SetParameterValue("@pmp_id", CDataConverter.ConvertToInt(smart_employee.SelectedValue), "sub_Evaluation_Rep_first_groupby_evaluator.rpt");

        //        rd.SetParameterValue("@pmp_id", CDataConverter.ConvertToInt(smart_employee.SelectedValue), "sub_Evaluation_Rep_strengh__groupby_evaluator.rpt");
        //        rd.SetParameterValue("@pmp_id", CDataConverter.ConvertToInt(smart_employee.SelectedValue), "sub_Evaluation_Rep_weakness_groupby_evaluator.rpt");



        //        rd.SetParameterValue("@pmp_id", CDataConverter.ConvertToInt(smart_employee.SelectedValue), "sub_Evaluation_Rep_Needs_groupby_evaluator.rpt");
        //        //rd.SetParameterValue("@pmp_id", CDataConverter.ConvertToInt(smart_employee.SelectedValue), "signatures_Eval_Report.rpt");
        //        //rd.SetParameterValue("@pmp_id", CDataConverter.ConvertToInt(Smart_Pmp_Id.SelectedValue), "sub_Evaluation_Rep_strenghand weak.rpt");
        //        rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
        //        rd.SetParameterValue("@user", user, "footerRep.rpt");

        //        rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report");
        //    }
        //    else
        //    {
        //        ShowAlertMessage("!!!!!يجب اختيار موظف !!!!");
        //        return;
        //    }
        //}
            //------------------------
            //----------------------------
        else if (hidden_Rpt_Id.Value == "Evaluation_mange_grouped_Report")
        {
            
            int group = CDataConverter.ConvertToInt(Session_CS.group_id.ToString());
            ReportDocument rd = new ReportDocument();
            string s = "";
            if (smart_employee.SelectedValue != "")
            {




                string user = Session_CS.pmp_name.ToString();

                s = Server.MapPath("../Reports/Mng_Evaluation_Report_All.rpt");

                rd.Load(s);

                Reports.Load_Report(rd);
              
                rd.SetParameterValue("@pmp_id", CDataConverter.ConvertToInt(smart_employee.SelectedValue), "Header_Eval_Report.rpt");

                rd.SetParameterValue("@pmp_id", CDataConverter.ConvertToInt(smart_employee.SelectedValue), "mng_sub_Evaluation_Rep_first.rpt");

                rd.SetParameterValue("@Pmp_Id", CDataConverter.ConvertToInt(smart_employee.SelectedValue), "sub_eval_mange_total.rpt");
                rd.SetParameterValue("@pmp_id", CDataConverter.ConvertToInt(smart_employee.SelectedValue), "Emp_Mng_Notes.rpt");

                rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
                rd.SetParameterValue("@user", user, "footerRep.rpt");

                rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report");
            }
            else
            {
                ShowAlertMessage("!!!!!يجب اختيار موظف !!!!");
                return;
            }
        }
        //------------------------
        //----------------------------
        else if (hidden_Rpt_Id.Value == "mng_Evaluation_grouped_Report")
        {
            int group = CDataConverter.ConvertToInt(Session_CS.group_id.ToString());
            ReportDocument rd = new ReportDocument();
            string s = "";
            if (smart_employee.SelectedValue != "")
            {


             


                string user = Session_CS.pmp_name.ToString();

                s = Server.MapPath("../Reports/Mng_Evaluation_Report_All.rpt");

                rd.Load(s);

                Reports.Load_Report(rd);
              

                rd.SetParameterValue("@pmp_id", CDataConverter.ConvertToInt(smart_employee.SelectedValue), "mng_Header_Eval_Report.rpt");

                rd.SetParameterValue("@pmp_id", CDataConverter.ConvertToInt(smart_employee.SelectedValue), "mng_sub_Evaluation_Rep_first.rpt");

                rd.SetParameterValue("@pmp_id", CDataConverter.ConvertToInt(smart_employee.SelectedValue), "Emp_Mng_Notes.rpt");
                

                
                rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
                rd.SetParameterValue("@user", user, "footerRep.rpt");

                rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report");
            }
            else
            {
                ShowAlertMessage("!!!!!يجب اختيار موظف !!!!");
                return;
            }
        }
        //////////////////////////////////////////////------------------------------------------
        else if (hidden_Rpt_Id.Value == "top_mng_finished_Report")
        {
            int dept_id = 0;
            sql = "  select     SUM(top_value)/sum(Weight)*100  AS total_sum,PMP_ID,Dept_Dept_id,Dept_name,Sec_id,Sec_name,pmp_name from [Emp_Eval_Grades]  where 1=1";
            

            if (Smrt_Srch_DropDep.SelectedValue != "")
            {
                dept_id = int.Parse(Smrt_Srch_DropDep.SelectedValue);
                sql += " AND Dept_Dept_ID = " + dept_id;
            }
            sql += "group by PMP_ID,Dept_Dept_id,Dept_name,Sec_id,Sec_name,pmp_name";

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            
            string user = Session_CS.pmp_name.ToString();
            ReportDocument rd = new ReportDocument();
            string s = Server.MapPath("../Reports/top_Mgr_Emp_eval_final.rpt");
            rd.Load(s);
            rd.SetDataSource(dt);
            Reports.Load_Report(rd);

            rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
            rd.SetParameterValue("@user", user, "footerRep.rpt");
            if (rd.Rows.Count == 0)
            {
                ShowAlertMessage("هذا التقرير لا يوجد به بيانات للعرض !!!!");
                return;
            }
            else
            {
                rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report");
            }


        }
        //**************************************************************************************************
        else if (hidden_Rpt_Id.Value == "dept_empLB_Click")
        {
          

            int dept_id = 0;

            SqlCommand comm = new SqlCommand();
            comm.CommandText = "dbo.Department_Employees";
            comm.CommandType = CommandType.StoredProcedure;
            if (Smrt_Srch_DropDep.SelectedValue != "")
            {
                dept_id = int.Parse(Smrt_Srch_DropDep.SelectedValue);
                comm.Parameters.Add(new SqlParameter("@Dept_Id", SqlDbType.NVarChar)).Value = dept_id;
            }

            else
            {
                comm.Parameters.Add(new SqlParameter("@Sec_Id", SqlDbType.NVarChar)).Value = DBNull.Value;
                comm.Parameters.Add(new SqlParameter("@Dept_Id", SqlDbType.NVarChar)).Value = DBNull.Value;
            }
            comm.Connection = conn;
            SqlDataAdapter ad = new SqlDataAdapter(comm);
            DataTable dt = new DataTable();
            conn.Open();
            ad.Fill(dt);
            conn.Close();
            string user = Session_CS.pmp_name.ToString();
            ReportDocument rd = new ReportDocument();
            string s = Server.MapPath("../Reports/Department_Employees.rpt");
            rd.Load(s);
            rd.SetDataSource(dt);
            Reports.Load_Report(rd);

            rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
            rd.SetParameterValue("@user", user, "footerRep.rpt");
            if (rd.Rows.Count == 0)
            {
                ShowAlertMessage("هذا التقرير لا يوجد به بيانات للعرض !!!!");
                return;
            }
            else
            {
                rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report");
            }

        }
        //**************************************************************************************************

        else if (hidden_Rpt_Id.Value == "emp_statisticsLB_Click")
        {
            int dept_id = 0;

            SqlCommand comm = new SqlCommand();
            comm.CommandText = "dbo.Employee_Statistics";
            comm.CommandType = CommandType.StoredProcedure;
            if (Smrt_Srch_DropDep.SelectedValue != "")
            {
                dept_id = int.Parse(Smrt_Srch_DropDep.SelectedValue);
                comm.Parameters.Add(new SqlParameter("@Dept_Id", SqlDbType.NVarChar)).Value = dept_id;
            }

            else
            {
                comm.Parameters.Add(new SqlParameter("@Sec_Id", SqlDbType.NVarChar)).Value = DBNull.Value;
                comm.Parameters.Add(new SqlParameter("@Dept_Id", SqlDbType.NVarChar)).Value = DBNull.Value;
            }
            comm.Connection = conn;
            SqlDataAdapter ad = new SqlDataAdapter(comm);
            DataTable dt = new DataTable();
            conn.Open();
            ad.Fill(dt);
            conn.Close();
            string user = Session_CS.pmp_name.ToString();
            ReportDocument rd = new ReportDocument();
            string s = Server.MapPath("../Reports/Employee_Statistics.rpt");
            rd.Load(s);
            rd.SetDataSource(dt);
            Reports.Load_Report(rd);

            rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
            rd.SetParameterValue("@user", user, "footerRep.rpt");
            if (rd.Rows.Count == 0)
            {
                ShowAlertMessage("هذا التقرير لا يوجد به بيانات للعرض !!!!");
                return;
            }
            else
            {
                rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report");
            }



        }
        //**************************************************************************************************
        //else if (hidden_Rpt_Id.Value == "direct_mgr_emp_not_evalLB_Click")
        //{
        //    int dept_id = 0;

        //    SqlCommand comm = new SqlCommand();
        //    comm.CommandText = "dbo.Direct_Mgr_Emp_not_eval";
        //    comm.CommandType = CommandType.StoredProcedure;
        //    if (Smrt_Srch_DropDep.SelectedValue != "")
        //    {
        //        dept_id = int.Parse(Smrt_Srch_DropDep.SelectedValue);
        //        comm.Parameters.Add(new SqlParameter("@Dept_Id", SqlDbType.NVarChar)).Value = dept_id;
        //    }

        //    else
        //    {
        //        comm.Parameters.Add(new SqlParameter("@Sec_Id", SqlDbType.NVarChar)).Value = DBNull.Value;
        //        comm.Parameters.Add(new SqlParameter("@Dept_Id", SqlDbType.NVarChar)).Value = DBNull.Value;
        //    }
        //    comm.Connection = conn;
        //    SqlDataAdapter ad = new SqlDataAdapter(comm);
        //    DataTable dt = new DataTable();
        //    conn.Open();
        //    ad.Fill(dt);
        //    conn.Close();
        //    string user = Session_CS.pmp_name.ToString();
        //    ReportDocument rd = new ReportDocument();
        //    string s = Server.MapPath("../Reports/Direct_Mgr_Emp_not_eval.rpt");
        //    rd.Load(s);
        //    rd.SetDataSource(dt);
        //    Load_Report(rd);

        //    rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
        //    rd.SetParameterValue("@user", user, "footerRep.rpt");
        //    if (rd.Rows.Count == 0)
        //    {
        //        ShowAlertMessage("هذا التقرير لا يوجد به بيانات للعرض !!!!");
        //        return;
        //    }
        //    else
        //    {
        //        rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report");
        //    }



        //}
        //**************************************************************************************************
        //else if (hidden_Rpt_Id.Value == "top_mgr_emp_not_evalLB_Click")
        //{
        //    int dept_id = 0;

        //    SqlCommand comm = new SqlCommand();
        //    comm.CommandText = "dbo.Top_Mgr_Emp_not_eval";
        //    comm.CommandType = CommandType.StoredProcedure;
        //    if (Smrt_Srch_DropDep.SelectedValue != "")
        //    {
        //        dept_id = int.Parse(Smrt_Srch_DropDep.SelectedValue);
        //        comm.Parameters.Add(new SqlParameter("@Dept_Id", SqlDbType.NVarChar)).Value = dept_id;
        //    }
        //    else
        //    {
        //        comm.Parameters.Add(new SqlParameter("@Sec_Id", SqlDbType.NVarChar)).Value = DBNull.Value;
        //        comm.Parameters.Add(new SqlParameter("@Dept_Id", SqlDbType.NVarChar)).Value = DBNull.Value;
        //    }
        //    comm.Connection = conn;
        //    SqlDataAdapter ad = new SqlDataAdapter(comm);
        //    DataTable dt = new DataTable();
        //    conn.Open();
        //    ad.Fill(dt);
        //    conn.Close();
        //    string user = Session_CS.pmp_name.ToString();
        //    ReportDocument rd = new ReportDocument();
        //    string s = Server.MapPath("../Reports/Top_Mgr_Emp_not_eval.rpt");
        //    rd.Load(s);
        //    rd.SetDataSource(dt);
        //    Load_Report(rd);

        //    rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
        //    rd.SetParameterValue("@user", user, "footerRep.rpt");
        //    if (rd.Rows.Count == 0)
        //    {
        //        ShowAlertMessage("هذا التقرير لا يوجد به بيانات للعرض !!!!");
        //        return;
        //    }
        //    else
        //    {
        //        rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report");
        //    }



        //}
        //**************************************************************************************************
        else if (hidden_Rpt_Id.Value == "Direct_mng_finished_Report")
        {
            int dept_id = 0;
            sql = "  select     SUM(mng_value)/sum(Weight)*100  AS total_sum,PMP_ID, Dept_Dept_id,Dept_name,Sec_id,Sec_name,pmp_name from Emp_Eval_Grades   where 1=1";

            
            if (Smrt_Srch_DropDep.SelectedValue != "")
            {
                dept_id = int.Parse(Smrt_Srch_DropDep.SelectedValue);
                sql += " AND Dept_Dept_ID = " + dept_id;
            }
            sql += "group by PMP_ID,Dept_Dept_id,Dept_name,Sec_id,Sec_name,pmp_name";


            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);



            string user = Session_CS.pmp_name.ToString();
            ReportDocument rd = new ReportDocument();
            string s = Server.MapPath("../Reports/Direct_Mgr_Emp_eval.rpt");
            rd.Load(s);
            rd.SetDataSource(dt);
            Reports.Load_Report(rd);

            rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
            rd.SetParameterValue("@user", user, "footerRep.rpt");
            if (rd.Rows.Count == 0)
            {
                ShowAlertMessage("هذا التقرير لا يوجد به بيانات للعرض !!!!");
                return;
            }
            else
            {
                rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report");
            }


        }
        ///////////////////////////////////////////////////
        else if (hidden_Rpt_Id.Value == "Evaluation_status_Report")
        {
            int dept_id = 0;
            sql = "select eval_final.pmp_id,eval_final.pmp_name,eval_final.dept_id,eval_final.dept_name,sum(case eval_final.Eval_Status when 1 then 1 else 0 end) as 'direct_mng',sum(case eval_final.Eval_Status when 2 then 1 else 0 end) as 'top_mng' from eval_final where 1=1 ";

            if (ddl_sec.SelectedValue != "")
            {
                sql += "and Sec_sec_id='"+ddl_sec.SelectedValue+"'";

            }
            if (Smrt_Srch_DropDep.SelectedValue != "")
            {
                dept_id = int.Parse(Smrt_Srch_DropDep.SelectedValue);
                sql += " AND eval_final.Dept_ID = " + dept_id;
            }

            sql += " group by pmp_id,pmp_name,dept_id,dept_name";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);



            string user = Session_CS.pmp_name.ToString();
            ReportDocument rd = new ReportDocument();
            string s = Server.MapPath("../Reports/emp_eval_status.rpt");
            rd.Load(s);
            rd.SetDataSource(dt);
            Reports.Load_Report(rd);

            rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
            rd.SetParameterValue("@user", user, "footerRep.rpt");
            if (rd.Rows.Count == 0)
            {
                ShowAlertMessage("هذا التقرير لا يوجد به بيانات للعرض !!!!");
                return;
            }
            else
            {
                rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report");
            }


        }




    }


    protected void Button2_Click(object sender, EventArgs e)
    {
        if (smart_employee.SelectedValue != "")
        {
            string encrypted = Encryption.Encrypt(smart_employee.SelectedValue.ToString());
            string queryString =

            "Eval_Report_Details.aspx?id=" +  encrypted;

            string newWin = "window.open('" + queryString + "');";

            Page.ClientScript.RegisterStartupScript(this.GetType(), "pop", newWin,true);
        }
        else
        {
            ShowAlertMessage("!!! يجب إختيار موظف !!!");
            return;
        }



    }






    protected void DropDate_SelectedIndexChanged(object sender, EventArgs e)
    {
        Label6.Visible = false;
    }

    protected void ImgBtnBack_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("../MainForm/Eval_Reports.aspx");
    }
    protected void Droporg_SelectedIndexChanged(object sender, EventArgs e)
    {

    }



    public void Drop_Date_fun()
    {
        for (int i = 0; i < 41; i++)
        {
         

          //  int year = DateTime.Now.Year - 10 + i;
           int year = CDataConverter.ConvertDateTimeNowRtnDt().Year - 10 + i;

            string yearshowed = year.ToString();
            Drop_balance.Items.Add(yearshowed);
            Drop_balance.DataBind();

        }
        Drop_balance.Items.Insert(0, new ListItem("اختر السنة  المطلوبة......", "0"));
    }









   
}
