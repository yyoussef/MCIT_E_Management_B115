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
using System.Collections.ObjectModel;
using System.Collections.Generic;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;
using CrystalDecisions.Shared;
using MCIT.Web.Data;
using System.Data.SqlClient;
using DBL;
using activityLeveling;
using activityversions;
using System.Text;
using ReportsClass;


public partial class UserControls_MMallReports : System.Web.UI.UserControl
{
    string sql;
    SqlConnection conn;
    SqlDataAdapter da;
    DataSet ds;
    //Session_CS Session_CS = new Session_CS();
    //hta5dy start///////////////
    //private cBrowser obj_Browserdept, obj_Browsermanage;
    //private SqlConnection obj_Sql_Con;
    private string sql_Connection = Universal.GetConnectionString();
    string InsideMCIT = System.Configuration.ConfigurationManager.AppSettings["InsideMCIT"].ToString();

    protected override void OnInit(EventArgs e)
    {
        //string strConString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();

        //obj_Sql_Con = new System.Data.SqlClient.SqlConnection(strConString);

        //obj_Sql_Con.Open();

        ////end//
        string Query = "";
        string Query1 = "";
        string Query2 = "";
        smart_org_coop.sql_Connection = sql_Connection;
        smart_advantage_org.sql_Connection = sql_Connection;
        smart_exc_org.sql_Connection = sql_Connection;
        if (Smrt_Srch_DropDep.SelectedValue != "")
        {

            Query = "SELECT  distinct  Protocol_Main_Org.Org_ID, Project.Dept_Dept_id, Organization.Org_Desc, Protocol_Main_Org.Org_Type FROM Protocol_Main_Org INNER JOIN Organization ON Protocol_Main_Org.Org_ID = Organization.Org_ID LEFT OUTER JOIN Project ON Protocol_Main_Org.Protocol_ID = Project.Protocol_ID WHERE	[Dept_Dept_id] = " + Smrt_Srch_DropDep.SelectedValue + " and Org_Type=1";
            Query1 = "SELECT  distinct  Protocol_Main_Org.Org_ID, Project.Dept_Dept_id, Organization.Org_Desc, Protocol_Main_Org.Org_Type FROM Protocol_Main_Org INNER JOIN Organization ON Protocol_Main_Org.Org_ID = Organization.Org_ID LEFT OUTER JOIN Project ON Protocol_Main_Org.Protocol_ID = Project.Protocol_ID WHERE	[Dept_Dept_id] = " + Smrt_Srch_DropDep.SelectedValue + " and Org_Type=2";
            Query2 = "SELECT  distinct  Protocol_Main_Org.Org_ID, Project.Dept_Dept_id, Organization.Org_Desc, Protocol_Main_Org.Org_Type FROM Protocol_Main_Org INNER JOIN Organization ON Protocol_Main_Org.Org_ID = Organization.Org_ID LEFT OUTER JOIN Project ON Protocol_Main_Org.Protocol_ID = Project.Protocol_ID WHERE	[Dept_Dept_id] = " + Smrt_Srch_DropDep.SelectedValue + " and Org_Type=3";


        }
        else
        {

            Query = 
            Query1 = 
             Query2 = "select * from Organization ";

        }
        smart_org_coop.datatble = General_Helping.GetDataTable(Query);
        smart_exc_org.datatble = General_Helping.GetDataTable(Query1);
        smart_advantage_org.datatble = General_Helping.GetDataTable(Query2);
        smart_org_coop.Value_Field = smart_exc_org.Value_Field = smart_advantage_org.Value_Field = "Org_ID";
        smart_org_coop.Text_Field = smart_exc_org.Text_Field = smart_advantage_org.Text_Field = "Org_Desc";
        smart_org_coop.DataBind();
        smart_exc_org.DataBind();
        smart_advantage_org.DataBind();
        this.smart_org_coop.Value_Handler += new Smart_Search.Delegate_Selected_Value(MOnMember_Data_cop_org);
        this.smart_advantage_org.Value_Handler += new Smart_Search.Delegate_Selected_Value(MOnMember_Data_cop_adv);
        this.smart_exc_org.Value_Handler += new Smart_Search.Delegate_Selected_Value(MOnMember_Data_cop_exc);

        #region BROWSER FOR departments

        Smrt_Srch_DropDep.sql_Connection = sql_Connection;
        if (InsideMCIT == "1")
        {
            Query = "SELECT  * from    Departments  where  Sec_sec_id='" + Session_CS.sec_id + "'";
        }
        else
        {
            Query = "SELECT  * from    Departments  where foundation_id='" + Session_CS.foundation_id + "'";


        }
        Smrt_Srch_DropDep.datatble = General_Helping.GetDataTable(Query);
        Smrt_Srch_DropDep.Value_Field = "Dept_ID";
        Smrt_Srch_DropDep.Text_Field = "Dept_name";
        Smrt_Srch_DropDep.DataBind();
        this.Smrt_Srch_DropDep.Value_Handler += new Smart_Search.Delegate_Selected_Value(MOnMember_Data);

        //this.obj_Browserdept = new cBrowser(this, "select Dept_ID,Dept_name from Departments", "الإدارات", 5);

        //this.obj_Browserdept.MAddField("Dept_name", "اسم الإدارة", 150, BrowserFieldType.NIString);

        //this.obj_Browserdept.ID = "obj_Browserdept";

        //this.obj_Browserdept.BrowseData += new BrowseDataEventHandler(MOnMember_Data);


        ////////////////////////////////////////////////////////////
        //ht5dy dh st//
        smart_employee.sql_Connection = sql_Connection;
       // smart_employee.Query = "select PMP_ID,rol_rol_id,pmp_name from dbo.EMPLOYEE ";
        Query = "select PMP_ID,rol_rol_id,pmp_name from dbo.EMPLOYEE ";
        smart_employee.datatble = General_Helping.GetDataTable(Query);
        smart_employee.Value_Field = "PMP_ID";
        smart_employee.Text_Field = "pmp_name";
        smart_employee.DataBind();


        Smrt_Srch_projmanage.sql_Connection = sql_Connection;
       // Smrt_Srch_projmanage.Query = "select PMP_ID,rol_rol_id,pmp_name from dbo.EMPLOYEE where rol_rol_id=4";
        Query = "select PMP_ID,rol_rol_id,pmp_name from dbo.EMPLOYEE where rol_rol_id=4";
        Smrt_Srch_projmanage.datatble = General_Helping.GetDataTable(Query);
        Smrt_Srch_projmanage.Value_Field = "PMP_ID";
        Smrt_Srch_projmanage.Text_Field = "pmp_name";
        Smrt_Srch_projmanage.DataBind();
        this.Smrt_Srch_projmanage.Value_Handler += new Smart_Search.Delegate_Selected_Value(MOnMember_Datamanage);

        //this.obj_Browsermanage = new cBrowser(this, "select distinct pmp_pmp_id , PTem_Name from dbo.Project_Team where rol_rol_id=4", "مديرين المشروعات", 5);

        //this.obj_Browsermanage.MAddField("PTem_Name", "اسم مدير المشروع", 150, BrowserFieldType.NIString);

        //this.obj_Browsermanage.ID = "obj_Browsermanage";

        //this.obj_Browsermanage.BrowseData += new BrowseDataEventHandler(MOnMember_Datamanage);
        if (Request.QueryString["type"] == "1")
        {
            Smart_Search_Proj.sql_Connection = sql_Connection;
            //Smart_Search_Proj.Query = "select proj_title,proj_id from project ";
            Query = "select proj_title,proj_id from project ";
            Smart_Search_Proj.datatble = General_Helping.GetDataTable(Query);
            Smart_Search_Proj.Value_Field = "proj_id";
            Smart_Search_Proj.Text_Field = "proj_title";
            Smart_Search_Proj.DataBind();
        }

        this.Smart_Search_Proj.Value_Handler += new Smart_Search.Delegate_Selected_Value(MOnMember_Databudget);


        this.Smart_Search_main.Value_Handler += new Smart_Search.Delegate_Selected_Value(MOnMember_subactivities);


        #endregion


        base.OnInit(e);
    }


    private void MOnMember_Data_cop_org(string Value)
    {
        dropcop_org_fun();
    }
    private void MOnMember_Data_cop_adv(string Value)
    {
        dropadv_org_fun();
    }
    private void MOnMember_Data_cop_exc(string Value)
    {
        dropexc_org_fun();
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
            //Smart_Search_main.Query = "select PActv_ID, PActv_Desc from dbo.Project_Activities where  PActv_Parent=0 and proj_proj_id=" + Value;
            string Query = "select PActv_ID, PActv_Desc from dbo.Project_Activities where  PActv_Parent=0 and proj_proj_id=" + Value;
            Smart_Search_main.datatble = General_Helping.GetDataTable(Query);
            Smart_Search_main.Value_Field = "PActv_ID";
            Smart_Search_main.Text_Field = "PActv_Desc";
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
        if (Session_CS.pmp_name != null)
        {
            if (!IsPostBack)
            {

                Smrt_Srch_DropDep.Show_OrgTree = true;


                // ImgBtnResearch.Attributes.Add("OnClick", this.obj_Browserdept.ClientSideFunction);
                /////////// ht5dy hena///////////////////////////////////////
                // ImageButtonmanage.Attributes.Add("OnClick", this.obj_Browsermanage.ClientSideFunction);
                ///////////// end hena ///////////////////////////////////////////
                int pmp = int.Parse(Session_CS.pmp_id.ToString());
                //////////////////////////////////// get project manager data to drop list ////////////////////
                sql = "select distinct pmp_pmp_id,PTem_Name,rol_rol_id from dbo.Project_Team where rol_rol_id=4";
                ds = new DataSet();
                da = new SqlDataAdapter(sql, conn);
                da.Fill(ds, "projectsmanage");

                sql = "select id,proj_Classification from Classification";
                ds = new DataSet();
                da = new SqlDataAdapter(sql, conn);
                da.Fill(ds, "Classification");
                Drop_cat.DataSource = ds.Tables[0];
                Drop_cat.DataValueField = "id";
                Drop_cat.DataTextField = "proj_Classification";
                Drop_cat.DataBind();
                Drop_cat.Items.Insert(0, new ListItem("اختر الخطة التابع لها......", "0"));

                /////////////////////////////////////////////////
                sql = "select * from Proj_status";
                ds = new DataSet();
                da = new SqlDataAdapter(sql, conn);
                da.Fill(ds, "status");
                Dropstatus.DataSource = ds.Tables[0];
                Dropstatus.DataValueField = "id";
                Dropstatus.DataTextField = "status";
                Dropstatus.DataBind();
                Dropstatus.Items.Insert(0, new ListItem("اختر الحالة......", "0"));
                //////////////////////////////////////////////////////////////////////////
                ///////////////////////// get data to month drop///////////////////
                sql = "select ID,Notes from Project_Activities_Months";
                ds = new DataSet();
                da = new SqlDataAdapter(sql, conn);
                da.Fill(ds, "Notes");
                Drop_month.DataSource = ds.Tables[0];
                Drop_month.DataValueField = "ID";
                Drop_month.DataTextField = "Notes";
                Drop_month.DataBind();
                Drop_month.Items.Insert(0, new ListItem("اختر الشهر......", "0"));

                //////////////////////////////////////////////////////
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




                ////////////////////////////////////// get data from proj_type table to drop list/////////////
                sql = "select Type_id,Type_name from proj_type";
                ds = new DataSet();
                da = new SqlDataAdapter(sql, conn);
                da.Fill(ds, "Types");
                Drop_type.DataSource = ds.Tables[0];
                Drop_type.DataValueField = "Type_id";
                Drop_type.DataTextField = "Type_name";
                Drop_type.DataBind();
                Drop_type.Items.Insert(0, new ListItem("اختر نوعية المشروع......", "0"));


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

                if (Request.QueryString["type"] == "2")
                {
                    needs_demand_need_tasde2_tr.Visible = false;
                    needs_demand_by_dept_tr.Visible = false;
                    needs_demand_by_proj_tr.Visible = false;
                    fin1_tr.Visible = false;
                    fin2_tr.Visible = false;
                    fin3_tr.Visible = false;
                    fin6_tr.Visible = false;
                    work_at_proj.Visible = false;
                    proj_achieve.Visible = false;
                    high_mini.Visible = false;
                    protocol.Visible = false;
                    end_proj.Visible = false;
                    proj_data.Visible = false;
                    // essential_data.Visible = false;
                    //proj_sit.Visible = false;
                    late_proj.Visible = false;
                    similar_proj.Visible = false;
                    org_proj.Visible = false;
                    proj_detail_dept.Visible = false;
                    proj_abstract.Visible = false;
                    Tr5.Visible = false;
                    tr_monitor.Visible = false;
                    Tr9.Visible = false;
                    tr_vacations.Visible = false;

                }


                if (group_id == 6 || group_id == 10)
                {
                    NeedsTR.Visible = false;
                    FinanceTr.Visible = false;
                    Label1.Text = "التقارير ";
                }

                if (group_id == 11 || pmp == 436 || pmp == 62 || pmp == 518)
                {
                    FinanceTr.Visible = false;
                    Label1.Text = "التقارير ";
                }
                if (CDataConverter.ConvertToInt(Session_CS.group_id.ToString()) == 7)
                {
                    general_tr.Visible = false;
                    indicators_tr.Visible = false;
                    firstreports.Visible = false;
                    firts_tr_reports.Visible = false;
                    activities_tr.Visible = false;
                    second_tr_reports.Visible = false;
                    NeedsTR.Visible = true;
                    Tr3.Visible = true;
                    FinanceTr.Visible = false;
                    Tr4.Visible = false;
                    thirdreport.Visible = false;
                    third_tr_reports.Visible = false;
                    //FinanceTr.Visible = false;
                    Label1.Text = "التقارير ";

                }
                if (pmp == 584)
                {
                    work_at_proj.Visible = false;
                    indicators_tr.Visible = false;
                    firts_tr_reports.Visible = false;
                    activities_tr.Visible = false;
                    second_tr_reports.Visible = false;
                    NeedsTR.Visible = false;
                    Tr3.Visible = false;
                    FinanceTr.Visible = false;
                    Tr4.Visible = false;
                    proj_goals.Visible = false;
                    proj_achieve.Visible = false;
                    high_mini.Visible = false;
                    protocol.Visible = false;
                    end_proj.Visible = false;
                    proj_data.Visible = false;
                    //essential_data.Visible = false;
                    //proj_sit.Visible = false;
                    late_proj.Visible = false;
                    data_entry.Visible = false;
                    similar_proj.Visible = false;
                    org_proj.Visible = false;
                    proj_detail_dept.Visible = false;
                    proj_abstract.Visible = false;
                    tr_vacations.Visible = false;
                    Tr5.Visible = false;
                }
                if (pmp == 481 || pmp == 386)
                {
                    work_at_proj.Visible = false;
                    indicators_tr.Visible = false;
                    firts_tr_reports.Visible = false;
                    activities_tr.Visible = false;
                    second_tr_reports.Visible = false;
                    NeedsTR.Visible = false;
                    Tr3.Visible = false;
                    FinanceTr.Visible = false;
                    Tr4.Visible = false;
                    proj_goals.Visible = false;
                    proj_achieve.Visible = false;
                    high_mini.Visible = false;
                    protocol.Visible = false;
                    end_proj.Visible = false;
                    proj_data.Visible = false;
                    // essential_data.Visible = false;
                    // proj_sit.Visible = false;
                    late_proj.Visible = false;
                    doc_no.Visible = false;
                    All_doc_no.Visible = false;
                    docs_size.Visible = false;
                    similar_proj.Visible = false;
                    org_proj.Visible = false;
                    proj_detail_dept.Visible = false;
                    proj_abstract.Visible = false;
                    tr_vacations.Visible = false;
                    Tr5.Visible = false;
                }
            }

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
    public string get_data_for_projects()
    {
        sql = "SELECT Project.Proj_id, Project.Proj_Title, Project.internal_external, Project.pmp_pmp_id, Project.Dept_Dept_id, Project.Class_id FROM         Departments RIGHT OUTER JOIN  Project LEFT OUTER JOIN  EMPLOYEE ON Project.pmp_pmp_id = EMPLOYEE.PMP_ID ON Departments.Dept_ID = Project.Dept_Dept_id where 1=1 ";
        if (Smrt_Srch_DropDep.SelectedValue != "")
        {
            sql += "AND dbo.Project.Dept_Dept_id=  " + CDataConverter.ConvertToInt(Smrt_Srch_DropDep.SelectedValue);
        }
        if (Smrt_Srch_projmanage.SelectedValue != "")
        {
            sql += "AND dbo.Project.pmp_pmp_id=  " + CDataConverter.ConvertToInt(Smrt_Srch_projmanage.SelectedValue);
        }
        if (Drop_type.SelectedValue != "0")
        {
            sql += "AND dbo.Project.internal_external =  " + CDataConverter.ConvertToInt(Drop_type.SelectedValue);
        }
        if (Drop_cat.SelectedValue != "0")
        {
            sql += "AND Project.Class_id =  " + CDataConverter.ConvertToInt(Drop_cat.SelectedValue);
        }
        //DataTable dt = new DataTable();
        return sql;
    }
    protected void Drop_cat_SelectedIndexChanged(object sender, EventArgs e)
    {

        Smart_Search_Proj.sql_Connection = sql_Connection;
        //Smart_Search_Proj.Query = "SELECT Project.Proj_id, Project.Proj_Title FROM Project LEFT OUTER JOIN Project_Classification ON Project.Proj_id = Project_Classification.proj_id where 1=1 and Project_Classification.proj_Classification_id= " + Drop_cat.SelectedValue;
        //string Query = "SELECT Project.Proj_id, Project.Proj_Title FROM Project LEFT OUTER JOIN Project_Classification ON Project.Proj_id = Project_Classification.proj_id where 1=1 and Project_Classification.proj_Classification_id= " + Drop_cat.SelectedValue;
        Smart_Search_Proj.datatble = General_Helping.GetDataTable( get_data_for_projects());
        //Smart_Search_Proj.datatble = get_data_for_projects();
        Smart_Search_Proj.Value_Field = "proj_id";
        Smart_Search_Proj.Text_Field = "proj_title";
        Smart_Search_Proj.DataBind();
        //this.Smart_proj.Value_Handler += new Smart_Search.Delegate_Selected_Value(show_tr);

    }
    protected void Drop_type_SelectedIndexChanged(object sender, EventArgs e)
    {

        Smart_Search_Proj.sql_Connection = sql_Connection;
        //Smart_Search_Proj.Query = "SELECT Project.Proj_id, Project.Proj_Title FROM Project LEFT OUTER JOIN Project_Classification ON Project.Proj_id = Project_Classification.proj_id where 1=1 and Project_Classification.proj_Classification_id= " + Drop_cat.SelectedValue;
        Smart_Search_Proj.datatble = General_Helping.GetDataTable(get_data_for_projects());
        Smart_Search_Proj.Value_Field = "proj_id";
        Smart_Search_Proj.Text_Field = "proj_title";
        Smart_Search_Proj.DataBind();
        //this.Smart_proj.Value_Handler += new Smart_Search.Delegate_Selected_Value(show_tr);

    }
    protected void vocation_DetailsLB_Click(object sender, EventArgs e)
    {
        hidden_Rpt_Id.Value = "vocation_Details_Report";
        Div_Proj.Style.Add("display", "none");
        Div_Proj_Mngr.Style.Add("display", "none");
        Div_Date_Needs.Style.Add("display", "none");
        Div_Dates_Demands.Style.Add("display", "none");
        Div_Dept.Style.Add("display", "block");
        Div_emp.Style.Add("display", "block");
        Div_request_date_vacation.Style.Add("display", "block");
        Div_take_date_vacation.Style.Add("display", "block");
        //Div_vacation_status.Style.Add("display", "block");
        show_hide_tables();
        Div_Date_balance.Style.Add("display", "none");
        Page.Title = "تقرير " + vocation_DetailsLB.Text;
        Label6.Visible = false;
        Label2.Visible = true;
        Label2.Text = Page.Title;

    }
    protected void LB_Closed_Commission_Click(object sender, EventArgs e)
    {
        hidden_Rpt_Id.Value = "closed_commission_Report";
        Div_Proj.Style.Add("display", "none");
        Div_Proj_Mngr.Style.Add("display", "none");
        Div_Date_Needs.Style.Add("display", "none");
        Div_Dates_Demands.Style.Add("display", "none");
        Div_Dept.Style.Add("display", "none");
        Div_emp.Style.Add("display", "block");
        Div_request_date_vacation.Style.Add("display", "none");
        Div_take_date_vacation.Style.Add("display", "block");
        //Div_vacation_status.Style.Add("display", "block");
        show_hide_tables();
        Div_Date_balance.Style.Add("display", "none");
        Page.Title = "تقرير " + LB_Closed_Commission.Text;
        Label6.Visible = false;
        Label18.Text = "اسم الموظف المسئول عن الاغلاق";
        Label23.Text = "تاريخ الاغلاق- من ";
        Label24.Text = "تاريخ الاغلاق- الي ";
        Label2.Visible = true;
        Label2.Text = Page.Title;

    }
    protected void monitor_DeptLB_Click(object sender, EventArgs e)
    {
        hidden_Rpt_Id.Value = "monitor_dept_Report";
        Div_Proj.Style.Add("display", "none");
        Div_Proj_Mngr.Style.Add("display", "none");
        Div_monitor.Style.Add("display", "block");
        Div_Date_Needs.Style.Add("display", "none");
        Div_Dates_Demands.Style.Add("display", "none");
        Div_Dept.Style.Add("display", "none");
        Div_emp.Style.Add("display", "none");
        Div_request_date_vacation.Style.Add("display", "none");
        Div_take_date_vacation.Style.Add("display", "none");
        //Div_vacation_status.Style.Add("display", "block");
        show_hide_tables();
        Div_Date_balance.Style.Add("display", "none");
        Page.Title = "تقرير " + monitor_DeptLB.Text;
        Label6.Visible = false;
        Label2.Visible = true;
        Label2.Text = Page.Title;

    }
    protected void monitor_projLB_Click(object sender, EventArgs e)
    {
        hidden_Rpt_Id.Value = "monitor_proj_Report";
        Div_Proj.Style.Add("display", "none");
        Div_Proj_Mngr.Style.Add("display", "none");
        Div_monitor.Style.Add("display", "block");
        Div_Date_Needs.Style.Add("display", "none");
        Div_Dates_Demands.Style.Add("display", "none");
        Div_Dept.Style.Add("display", "none");
        Div_emp.Style.Add("display", "none");
        Label26.Text = "عدد المشروعات";
        Div_request_date_vacation.Style.Add("display", "none");
        Div_take_date_vacation.Style.Add("display", "none");
        //Div_vacation_status.Style.Add("display", "block");
        show_hide_tables();
        Div_Date_balance.Style.Add("display", "none");
        Page.Title = "تقرير " + monitor_projLB.Text;
        Label6.Visible = false;
        Label2.Visible = true;
        Label2.Text = Page.Title;

    }
    protected void monitor_projmngLB_Click(object sender, EventArgs e)
    {
        hidden_Rpt_Id.Value = "monitor_projmng_Report";
        Div_Proj.Style.Add("display", "none");
        Div_Proj_Mngr.Style.Add("display", "none");
        Div_monitor.Style.Add("display", "block");
        Div_Date_Needs.Style.Add("display", "none");
        Div_Dates_Demands.Style.Add("display", "none");
        Div_Dept.Style.Add("display", "none");
        Div_emp.Style.Add("display", "none");
        Label26.Text = "عدد المشروعات";
        Div_request_date_vacation.Style.Add("display", "none");
        Div_take_date_vacation.Style.Add("display", "none");
        //Div_vacation_status.Style.Add("display", "block");
        show_hide_tables();
        Div_Date_balance.Style.Add("display", "none");
        Page.Title = "تقرير " + monitor_projmngLB.Text;
        Label6.Visible = false;
        Label2.Visible = true;
        Label2.Text = Page.Title;

    }
    protected void vocation_SumLB_Click(object sender, EventArgs e)
    {
        hidden_Rpt_Id.Value = "vocation_Sum_Report";
        Div_Proj.Style.Add("display", "none");
        Div_Proj_Mngr.Style.Add("display", "none");
        Div_Date_Needs.Style.Add("display", "none");
        Div_Dates_Demands.Style.Add("display", "none");
        Div_Dept.Style.Add("display", "block");
        Div_emp.Style.Add("display", "block");
        //Div_request_date_vacation.Style.Add("display", "block");
        Div_take_date_vacation.Style.Add("display", "block");
        show_hide_tables();
        Div_Date_balance.Style.Add("display", "none");
        Page.Title = "تقرير " + vocation_SumLB.Text;
        Label6.Visible = false;
        Label2.Visible = true;
        Label2.Text = Page.Title;

    }
    protected void vocation_Details_drhesham_LB_Click(object sender, EventArgs e)
    {
        hidden_Rpt_Id.Value = "vocation_Details_dr_hesham_Report";
        Div_Proj.Style.Add("display", "none");
        Div_Proj_Mngr.Style.Add("display", "none");
        Div_Date_Needs.Style.Add("display", "none");
        Div_Dates_Demands.Style.Add("display", "none");
        //Div_Dept.Style.Add("display", "block");
        //Div_emp.Style.Add("display", "block");
        // Div_request_date_vacation.Style.Add("display", "block");
        Div_take_date_vacation.Style.Add("display", "block");
        //Div_vacation_status.Style.Add("display", "block");
        show_hide_tables();
        Div_Date_balance.Style.Add("display", "none");
        Page.Title = "تقرير " + vocation_Details_drhesham_LB.Text;
        Label6.Visible = false;
        Label2.Visible = true;
        Label2.Text = Page.Title;

    }
    protected void vocation_Details_dept_manageLB_Click(object sender, EventArgs e)
    {
        hidden_Rpt_Id.Value = "vocation_Details_dept_manager_Report";
        Div_Proj.Style.Add("display", "none");
        Div_Proj_Mngr.Style.Add("display", "none");
        Div_Date_Needs.Style.Add("display", "none");
        Div_Dates_Demands.Style.Add("display", "none");
        //Div_Dept.Style.Add("display", "block");
        //Div_emp.Style.Add("display", "block");
        // Div_request_date_vacation.Style.Add("display", "block");
        Div_take_date_vacation.Style.Add("display", "block");
        //Div_vacation_status.Style.Add("display", "block");
        show_hide_tables();
        Div_Date_balance.Style.Add("display", "none");
        Page.Title = "تقرير " + vocation_Details_dept_manageLB.Text;
        Label6.Visible = false;
        Label2.Visible = true;
        Label2.Text = Page.Title;

    }
    protected void exist_LB_Click(object sender, EventArgs e)
    {
        hidden_Rpt_Id.Value = "existance_Report";
        Div_Proj.Style.Add("display", "none");
        Div_Proj_Mngr.Style.Add("display", "none");
        Div_Date_Needs.Style.Add("display", "none");
        Div_Dates_Demands.Style.Add("display", "none");
        //Div_Dept.Style.Add("display", "block");
        //Div_emp.Style.Add("display", "block");
        // Div_request_date_vacation.Style.Add("display", "block");
        Div_take_date_vacation.Style.Add("display", "none");
        //Div_vacation_status.Style.Add("display", "block");
        show_hide_tables();
        Div_Dept.Style.Add("display", "block");
        Div_Date_balance.Style.Add("display", "none");
        Page.Title = "تقرير " + exist_LB.Text;
        Label6.Visible = false;
        Label2.Visible = true;
        Label2.Text = Page.Title;

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
    protected void DropProj_SelectedIndexChanged(object sender, EventArgs e)
    {



    }
    protected void show_hide_tables()
    {
        tbl_Report.Style.Add("display", "none");
        tbl_Paramater.Style.Add("display", "block");
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
   

    protected void IndicatortypeLBdeptMang_Click(object sender, EventArgs e)
    {
        hidden_Rpt_Id.Value = "IndicatorType_Report";
        Div_Proj.Style.Add("display", "block");

        Div_Date_Needs.Style.Add("display", "none");
        Div_Dates_Demands.Style.Add("display", "none");
        Div_Date_balance.Style.Add("display", "none");
        //if (Request.QueryString["type"] == "1")
        //{

        //    Div_Proj_Mngr.Style.Add("display", "block");
        //}
        //else
        //{
        Div_Dept.Style.Add("display", "block");
        Div_classifications.Style.Add("display", "block");
        Div_Proj_Mngr.Style.Add("display", "none");
        // }

        show_hide_tables();
        Label6.Visible = false;
        Page.Title = "تقرير " + IndicatortypeLBdeptMang.Text;
        Label2.Visible = true;
        Label2.Text = Page.Title;


    }

    protected void PActivitiesPMLB_Click(object sender, EventArgs e)
    {
        hidden_Rpt_Id.Value = "ProjectActivitiestry_Report";
        Div_Date_balance.Style.Add("display", "none");
        Div_Proj.Style.Add("display", "block");

        Div_Date_Needs.Style.Add("display", "none");
        Div_Dates_Demands.Style.Add("display", "none");
        //if (Request.QueryString["type"] == "1")
        //{
        Div_Dept.Style.Add("display", "block");
        Div_Proj_Mngr.Style.Add("display", "block");
        //}
        //else
        //{
        Div_classifications.Style.Add("display", "block");
        Div_type.Style.Add("display", "block");
        //Div_month.Style.Add("display", "block");
        //Div_Balance.Style.Add("display", "block");
        //LBL_Balance.Text = "السنة";
        // Div_Year.Style.Add("display", "block");
        //}
        show_hide_tables();
        Label6.Visible = false;
        Page.Title = "تقرير " + PActivitiesPMLB.Text;
        Label2.Visible = true;
        Label2.Text = Page.Title;
        Drop_Year_fun();

    }
    protected void PFollowUpPMLB_Click(object sender, EventArgs e)
    {
        hidden_Rpt_Id.Value = "ProjectsFollowUPtry_Report";
        Div_Date_balance.Style.Add("display", "none");
        Div_Proj.Style.Add("display", "block");

        Div_Date_Needs.Style.Add("display", "none");
        Div_Dates_Demands.Style.Add("display", "none");
        //if (Request.QueryString["type"] == "1")
        //{
        Div_Dept.Style.Add("display", "block");
        Div_Proj_Mngr.Style.Add("display", "block");
        //}
        //else
        //{
        Div_classifications.Style.Add("display", "block");
        Div_type.Style.Add("display", "block");
        Div_month.Style.Add("display", "block");
        //Div_Balance.Style.Add("display", "block");
        //LBL_Balance.Text = "السنة";
        // Div_Year.Style.Add("display", "block");
        //}
        show_hide_tables();
        Label6.Visible = false;
        Page.Title = "تقرير " + PFollowUpPMLB.Text;
        Label2.Visible = true;
        Label2.Text = Page.Title;
        Drop_Year_fun();
    }
    protected void ProjectneedReportLB_Click(object sender, EventArgs e)
    {

    }
    protected void EmployeeLB_Click(object sender, EventArgs e)
    {
        hidden_Rpt_Id.Value = "Employees_Report";
        Div_Proj.Style.Add("display", "block");
        Div_Proj_Mngr.Style.Add("display", "none");
        Div_Date_Needs.Style.Add("display", "none");
        Div_Dates_Demands.Style.Add("display", "none");
        Div_Dept.Style.Add("display", "block");
        Div_Date_balance.Style.Add("display", "none");
        show_hide_tables();
        Label6.Visible = false;

        Page.Title = "تقرير " + EmployeeLB.Text;
        Label2.Visible = true;
        Label2.Text = Page.Title;

    }
    protected void projectsneedapproveLB_Click(object sender, EventArgs e)
    {
        hidden_Rpt_Id.Value = "projectsneedapprove_Report";
        Div_Proj.Style.Add("display", "none");
        Div_Proj_Mngr.Style.Add("display", "none");
        Div_Date_Needs.Style.Add("display", "none");
        Div_Dates_Demands.Style.Add("display", "block");
        Div_Dept.Style.Add("display", "block");
        Div_Date_balance.Style.Add("display", "none");
        show_hide_tables();
        Label6.Visible = false;
        Page.Title = "تقرير " + projectsneedapproveLB.Text;
        Label2.Visible = true;
        Label2.Text = Page.Title;


    }
    protected void Similar_ProjectLB_Click(object sender, EventArgs e)
    {
        hidden_Rpt_Id.Value = "similar_projects_Report";
        Div_Proj.Style.Add("display", "none");
        Div_Proj_Mngr.Style.Add("display", "block");
        Div_Date_balance.Style.Add("display", "none");
        Div_Date_Needs.Style.Add("display", "none");
        Div_Dates_Demands.Style.Add("display", "none");
        Div_Org.Style.Add("display", "block");
        Div_Dept.Style.Add("display", "block");
        Div_technology_category.Style.Add("display", "block");
        Label6.Visible = false;
        Label2.Visible = true;

        show_hide_tables();
        Page.Title = "تقرير " + Similar_ProjectLB.Text;
        Label2.Text = Page.Title;
    }
    protected void projobjectiveLB_Click(object sender, EventArgs e)
    {
        hidden_Rpt_Id.Value = "projobjective_Report";
        Div_Proj.Style.Add("display", "block");

        Div_Date_Needs.Style.Add("display", "none");
        Div_Dates_Demands.Style.Add("display", "none");
        if (Request.QueryString["type"] == "1")
        {
            Div_Dept.Style.Add("display", "block");
            Div_Proj_Mngr.Style.Add("display", "block");
        }
        else
        {
            Div_classifications.Style.Add("display", "block");
            Div_Proj_Mngr.Style.Add("display", "none");
        }
        Div_Status.Style.Add("display", "block");
        show_hide_tables();
        Div_Date_balance.Style.Add("display", "none");
        Page.Title = "تقرير " + projobjectiveLB.Text;
        Label6.Visible = false;
        Label2.Visible = true;
        Label2.Text = Page.Title;
        Label36.Visible = false;
        chk_status.Visible = false;
        chk_list_panel.Visible = false;
    }
    protected void project_doc_Click(object sender, EventArgs e)
    {
        hidden_Rpt_Id.Value = "ProjectDocumentReport";
        Div_Proj.Style.Add("display", "block");
        Div_Proj_Mngr.Style.Add("display", "none");
        Div_Date_Needs.Style.Add("display", "none");
        Div_Dates_Demands.Style.Add("display", "none");
        Div_Dept.Style.Add("display", "block");
        Div_Date_balance.Style.Add("display", "none");
        show_hide_tables();
        Label6.Visible = false;

        Page.Title = "تقرير " + project_doc.Text;
        Label2.Visible = true;
        Label2.Text = Page.Title;
    }
    protected void projAchievmentLB_Click(object sender, EventArgs e)
    {
        hidden_Rpt_Id.Value = "projAchievement_Report";
        Div_Proj.Style.Add("display", "block");
        Div_Proj_Mngr.Style.Add("display", "block");
        Div_Date_Needs.Style.Add("display", "none");
        Div_Dates_Demands.Style.Add("display", "none");
        Div_Dept.Style.Add("display", "block");
        show_hide_tables();
        Div_Date_balance.Style.Add("display", "none");
        Page.Title = "تقرير " + projAchievmentLB.Text;
        Label6.Visible = false;
        Label2.Visible = true;
        Label2.Text = Page.Title;
    }
    protected void projneedsLB_Click(object sender, EventArgs e)
    {

    }
    protected void weightpercentageLB_Click(object sender, EventArgs e)
    {

    }
    /// <summary>
    /// ////////////////////////////////// ht5'dy men hena ////////////////
    /// </summary>
    protected void dropprojmanage_fun()
    {
        //int dept_id = int.Parse(Session_CS.dept_id.ToString());
        //SqlConnection conn = new SqlConnection(sql_Connection);
        if (Smrt_Srch_projmanage.SelectedValue != "")
        {
            //sql = "SELECT dbo.Project_Team.PTem_Name, dbo.Project_Team.rol_rol_id, dbo.Project_Team.proj_proj_id, dbo.Project_Team.pmp_pmp_id, dbo.Project.Proj_Title,dbo.Departments.Dept_ID";
            //sql += " FROM dbo.Project INNER JOIN dbo.Project_Team ON dbo.Project.Proj_id = dbo.Project_Team.proj_proj_id ";
            //sql += " INNER JOIN dbo.Departments ON dbo.Project.Dept_Dept_id = dbo.Departments.Dept_ID";
            //sql += " WHERE dbo.Project_Team.rol_rol_id = 4 AND dbo.Project_Team.pmp_pmp_id= " + Smrt_Srch_projmanage.SelectedValue;
            //ds = new DataSet();
            //da = new SqlDataAdapter(sql, conn);
            //da.Fill(ds, "projects");
            //DropProj.DataSource = ds.Tables[0];
            //DropProj.DataTextField = "Proj_Title";
            //DropProj.DataValueField = "proj_proj_id";
            //DropProj.DataBind();
            //DropProj.Items.Insert(0, new ListItem("اختر اسم المشروع......", "0"));

            Smart_Search_Proj.sql_Connection = sql_Connection;
            //Smart_Search_Proj.Query = "select proj_title,proj_id from project JOIN Project_Team ON Project.Proj_id = dbo.Project_Team.proj_proj_id  where  Project_Team.rol_rol_id = 4 and Project_Team.pmp_pmp_id= " + Smrt_Srch_projmanage.SelectedValue;
            Smart_Search_Proj.datatble = General_Helping.GetDataTable(get_data_for_projects());
            Smart_Search_Proj.Value_Field = "proj_id";
            Smart_Search_Proj.Text_Field = "proj_title";
            Smart_Search_Proj.DataBind();

        }
        //else
        //{

        //    sql = "select Proj_id,Proj_Title,Dept_Dept_id from Project where Dept_Dept_id=" + dept_id;
        //    ds = new DataSet();
        //    da = new SqlDataAdapter(sql, conn);
        //    da.Fill(ds, "projects");
        //    DropProj.DataSource = ds.Tables[0];
        //    DropProj.DataTextField = "Proj_Title";
        //    DropProj.DataValueField = "Proj_id";
        //    DropProj.DataBind();
        //    DropProj.Items.Insert(0, new ListItem("اختر اسم المشروع......", "0"));
        //    Label6.Visible = false;
        //}
        Label6.Visible = false;

    }
    /// <summary>
    /// /////////////////// end //////////////////////////////////
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    //protected void Dropprojmanage_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    int dept_id = int.Parse(Session_CS.dept_id.ToString());
    //    SqlConnection conn = new SqlConnection(sql_Connection);
    //    if (Smrt_Srch_projmanage.SelectedValue != "")
    //    {
    //        sql = "SELECT dbo.Project_Team.PTem_Name, dbo.Project_Team.rol_rol_id, dbo.Project_Team.proj_proj_id, dbo.Project_Team.pmp_pmp_id, dbo.Project.Proj_Title,dbo.Departments.Dept_ID";
    //        sql += " FROM dbo.Project INNER JOIN dbo.Project_Team ON dbo.Project.Proj_id = dbo.Project_Team.proj_proj_id ";
    //        sql += " INNER JOIN dbo.Departments ON dbo.Project.Dept_Dept_id = dbo.Departments.Dept_ID";
    //        sql += " WHERE dbo.Project_Team.rol_rol_id = 4 AND dbo.Project_Team.pmp_pmp_id= " + Smrt_Srch_projmanage.SelectedValue;
    //        ds = new DataSet();
    //        da = new SqlDataAdapter(sql, conn);
    //        da.Fill(ds, "projects");
    //        DropProj.DataSource = ds.Tables[0];
    //        DropProj.DataTextField = "Proj_Title";
    //        DropProj.DataValueField = "proj_proj_id";
    //        DropProj.DataBind();
    //        DropProj.Items.Insert(0, new ListItem("اختر اسم المشروع......", "0"));


    //    }
    //    else
    //    {

    //        sql = "select Proj_id,Proj_Title,Dept_Dept_id from Project where Dept_Dept_id=" + dept_id;
    //        ds = new DataSet();
    //        da = new SqlDataAdapter(sql, conn);
    //        da.Fill(ds, "projects");
    //        DropProj.DataSource = ds.Tables[0];
    //        DropProj.DataTextField = "Proj_Title";
    //        DropProj.DataValueField = "Proj_id";
    //        DropProj.DataBind();
    //        DropProj.Items.Insert(0, new ListItem("اختر اسم المشروع......", "0"));
    //        Label6.Visible = false;
    //    }
    //    Label6.Visible = false;
    //}
    protected void PDemandsLB_Click(object sender, EventArgs e)
    {
        hidden_Rpt_Id.Value = "ProjectDemands_Report";
        Div_Proj.Style.Add("display", "none");
        Div_Proj_Mngr.Style.Add("display", "none");
        Div_Date_Needs.Style.Add("display", "none");
        Div_Dates_Demands.Style.Add("display", "block");
        if (Request.QueryString["type"] == "1")
        {
            Div_Dept.Style.Add("display", "block");
            Div_Proj.Style.Add("display", "none");
        }
        else
        {
            Div_classifications.Style.Add("display", "block");
            Div_Proj.Style.Add("display", "block");
        }
        show_hide_tables();
        Div_Date_balance.Style.Add("display", "none");
        Page.Title = "تقرير " + PDemandsLB.Text;
        Label6.Visible = false;
        Label2.Visible = true;
        Label2.Text = Page.Title;
    }
    protected void PDemandsLB_Req_date_Click(object sender, EventArgs e)
    {
        hidden_Rpt_Id.Value = "ProjectDemands_ReqDate_Report";

        Div_Proj_Mngr.Style.Add("display", "none");
        Div_Date_Needs.Style.Add("display", "none");
        Div_Dates_Demands.Style.Add("display", "block");
        if (Request.QueryString["type"] == "1")
        {
            Div_Dept.Style.Add("display", "block");
            Div_Proj.Style.Add("display", "none");
        }
        else
        {
            Div_classifications.Style.Add("display", "block");
            Div_Proj.Style.Add("display", "block");
        }
        Label11.Text = "  تاريخ طلب الاحتياج من ";
        Label12.Text = " تاريخ طلب الاحتياج الي ";
        show_hide_tables();
        Div_Date_balance.Style.Add("display", "none");
        Page.Title = "تقرير " + PDemandsLB_Req_date.Text;
        Label6.Visible = false;
        Label2.Visible = true;
        Label2.Text = Page.Title;
    }


    protected void commitedandRefusedProjectsLB_Click(object sender, EventArgs e)
    {
        hidden_Rpt_Id.Value = "commitedandRefusedProjects_Report";
        Div_Proj.Style.Add("display", "none");
        Div_Proj_Mngr.Style.Add("display", "none");
        Div_Date_Needs.Style.Add("display", "none");
        Div_Dates_Demands.Style.Add("display", "none");
        Div_Dept.Style.Add("display", "block");
        show_hide_tables();
        Div_Date_balance.Style.Add("display", "none");
        Page.Title = "تقرير " + commitedandRefusedProjectsLB.Text;
        Label6.Visible = false;
        Label2.Visible = true;
        Label2.Text = Page.Title;

    }
    protected void projectbalance_status_Click(object sender, EventArgs e)
    {
        hidden_Rpt_Id.Value = "projectbalance_status_report";
        Div_Proj.Style.Add("display", "block");
        Div_Proj_Mngr.Style.Add("display", "none");
        Div_Date_Needs.Style.Add("display", "none");
        Div_Dates_Demands.Style.Add("display", "none");
        Div_Dept.Style.Add("display", "block");
        show_hide_tables();
        Div_Date_balance.Style.Add("display", "none");
        Page.Title = "تقرير " + projectbalance_status.Text;
        Label6.Visible = false;
        Label2.Visible = true;
        Label2.Text = Page.Title;

    }
    protected void CurrentProjectsLB_Click(object sender, EventArgs e)
    {
        //hidden_Rpt_Id.Value = "CurrentProjects_Report";
        //Div_Proj.Style.Add("display", "none");
        //Div_Proj_Mngr.Style.Add("display", "none");
        //Div_Date_Needs.Style.Add("display", "none");
        //Div_Dates_Demands.Style.Add("display", "none");
        //Div_Dept.Style.Add("display", "block");
        //Div_Date_balance.Style.Add("display", "none");
        //show_hide_tables();
        //Page.Title = "تقرير " + CurrentProjectsLB.Text;
        //Label6.Visible = false;
        //Label2.Visible = true;
        //Label2.Text = Page.Title;
    }
    protected void ProjectsEmloyeesLB_Click(object sender, EventArgs e)
    {
        //hidden_Rpt_Id.Value = "ProjectsEmployees_Report";
        //Div_Proj.Style.Add("display", "none");
        //Div_Proj_Mngr.Style.Add("display", "none");
        //Div_Date_Needs.Style.Add("display", "none");
        //Div_Dates_Demands.Style.Add("display", "none");
        //Div_Dept.Style.Add("display", "block");
        //show_hide_tables();
        //Div_Date_balance.Style.Add("display", "none");
        //Page.Title = "تقرير " + ProjectsEmloyeesLB.Text;
        //Label6.Visible = false;
        //Label2.Visible = true;
        //Label2.Text = Page.Title;
    }
    protected void dropcop_org_fun()
    {
        //SqlConnection conn = new SqlConnection(sql_Connection);
        if (smart_org_coop.SelectedValue != "")
        {
            string Query = "";
            string Query1 = "";
            //smart_org_coop.sql_Connection = sql_Connection;
            smart_advantage_org.sql_Connection = sql_Connection;
            smart_exc_org.sql_Connection = sql_Connection;
            //smart_org_coop.Query = "SELECT  distinct  Protocol_Main_Org.Org_ID, Project.Dept_Dept_id, Organization.Org_Desc, Protocol_Main_Org.Org_Type FROM Protocol_Main_Org INNER JOIN Organization ON Protocol_Main_Org.Org_ID = Organization.Org_ID LEFT OUTER JOIN Project ON Protocol_Main_Org.Protocol_ID = Project.Protocol_ID WHERE	[Dept_Dept_id] = " + Smrt_Srch_DropDep.SelectedValue + " and Org_Type=1";
            //smart_advantage_org.Query = "SELECT  distinct  Protocol_Main_Org.Org_ID, Project.Dept_Dept_id, Organization.Org_Desc, Protocol_Main_Org.Org_Type FROM Protocol_Main_Org INNER JOIN Organization ON Protocol_Main_Org.Org_ID = Organization.Org_ID LEFT OUTER JOIN Project ON Protocol_Main_Org.Protocol_ID = Project.Protocol_ID WHERE	[Dept_Dept_id] = " + Smrt_Srch_DropDep.SelectedValue + " and Org_Type=2";
            Query = "SELECT  distinct  Protocol_Main_Org.Org_ID, Project.Dept_Dept_id, Organization.Org_Desc, Protocol_Main_Org.Org_Type FROM Protocol_Main_Org INNER JOIN Organization ON Protocol_Main_Org.Org_ID = Organization.Org_ID LEFT OUTER JOIN Project ON Protocol_Main_Org.Protocol_ID = Project.Protocol_ID WHERE	[Dept_Dept_id] = " + Smrt_Srch_DropDep.SelectedValue + " and Org_Type=2";
            //smart_exc_org.Query1 = "SELECT  distinct  Protocol_Main_Org.Org_ID, Project.Dept_Dept_id, Organization.Org_Desc, Protocol_Main_Org.Org_Type FROM Protocol_Main_Org INNER JOIN Organization ON Protocol_Main_Org.Org_ID = Organization.Org_ID LEFT OUTER JOIN Project ON Protocol_Main_Org.Protocol_ID = Project.Protocol_ID WHERE	[Dept_Dept_id] = " + Smrt_Srch_DropDep.SelectedValue + " and Org_Type=3";
            Query1 = "SELECT  distinct  Protocol_Main_Org.Org_ID, Project.Dept_Dept_id, Organization.Org_Desc, Protocol_Main_Org.Org_Type FROM Protocol_Main_Org INNER JOIN Organization ON Protocol_Main_Org.Org_ID = Organization.Org_ID LEFT OUTER JOIN Project ON Protocol_Main_Org.Protocol_ID = Project.Protocol_ID WHERE	[Dept_Dept_id] = " + Smrt_Srch_DropDep.SelectedValue + " and Org_Type=3";
            smart_advantage_org.datatble = General_Helping.GetDataTable(Query);
            smart_exc_org.datatble = General_Helping.GetDataTable(Query1);
            smart_org_coop.Value_Field = smart_exc_org.Value_Field = smart_advantage_org.Value_Field = "Org_ID";
            smart_org_coop.Text_Field = smart_exc_org.Text_Field = smart_advantage_org.Text_Field = "Org_Desc";
            //smart_org_coop.DataBind();
            smart_exc_org.DataBind();
            smart_advantage_org.DataBind();

            //Smart_Search_Proj.sql_Connection = sql_Connection;
            //Smart_Search_Proj.Query = get_data_for_projects();
            //Smart_Search_Proj.Value_Field = "proj_id";
            //Smart_Search_Proj.Text_Field = "proj_title";
            //Smart_Search_Proj.DataBind();

            //string sql = "SELECT   distinct Project_Organization.org_org_id ,  Organization.Org_Desc, Project.Dept_Dept_id FROM         Project_Organization LEFT OUTER JOIN                      Organization ON Project_Organization.org_org_id = Organization.Org_ID LEFT OUTER JOIN                      Project ON Project_Organization.proj_proj_id = Project.Proj_id where dept_dept_id is not null and org_org_id is not null and Dept_Dept_id = " + Smrt_Srch_DropDep.SelectedValue;
            //ds = new DataSet();
            //da = new SqlDataAdapter(sql, conn);
            //da.Fill(ds, "org");
            //Droporg.DataSource = ds.Tables[0];
            //Droporg.DataValueField = "org_org_ID";
            //Droporg.DataTextField = "Org_Desc";
            //Droporg.DataBind();
            //Droporg.Items.Insert(0, new ListItem("اختر الجهة المستفيدة ......", "0"));
        }
        else
        {
            //Smrt_Srch_projmanage.sql_Connection = sql_Connection;
            //Smrt_Srch_projmanage.Query = "select PMP_ID,rol_rol_id,pmp_name from dbo.EMPLOYEE where rol_rol_id=4";
            //Smrt_Srch_projmanage.Value_Field = "PMP_ID";
            //Smrt_Srch_projmanage.Text_Field = "pmp_name";
            //Smrt_Srch_projmanage.DataBind();

            //Smart_Search_Proj.sql_Connection = sql_Connection;
            //Smart_Search_Proj.Query = "select proj_title,proj_id from project ";
            //Smart_Search_Proj.Value_Field = "proj_id";
            //Smart_Search_Proj.Text_Field = "proj_title";
            //Smart_Search_Proj.DataBind();

        }
        Label6.Visible = false;
    }
    protected void dropadv_org_fun()
    {
        //SqlConnection conn = new SqlConnection(sql_Connection);
        if (smart_advantage_org.SelectedValue != "")
        {
            string Query = "";
            string Query1 = "";
            smart_org_coop.sql_Connection = sql_Connection;
            //smart_advantage_org.sql_Connection = sql_Connection;
            smart_exc_org.sql_Connection = sql_Connection;
           // smart_org_coop.Query = "SELECT  distinct  Protocol_Main_Org.Org_ID, Project.Dept_Dept_id, Organization.Org_Desc, Protocol_Main_Org.Org_Type FROM Protocol_Main_Org INNER JOIN Organization ON Protocol_Main_Org.Org_ID = Organization.Org_ID LEFT OUTER JOIN Project ON Protocol_Main_Org.Protocol_ID = Project.Protocol_ID WHERE	[Dept_Dept_id] = " + Smrt_Srch_DropDep.SelectedValue + " and Org_Type=1";
            Query = "SELECT  distinct  Protocol_Main_Org.Org_ID, Project.Dept_Dept_id, Organization.Org_Desc, Protocol_Main_Org.Org_Type FROM Protocol_Main_Org INNER JOIN Organization ON Protocol_Main_Org.Org_ID = Organization.Org_ID LEFT OUTER JOIN Project ON Protocol_Main_Org.Protocol_ID = Project.Protocol_ID WHERE	[Dept_Dept_id] = " + Smrt_Srch_DropDep.SelectedValue + " and Org_Type=1";
            //smart_advantage_org.Query = "SELECT  distinct  Protocol_Main_Org.Org_ID, Project.Dept_Dept_id, Organization.Org_Desc, Protocol_Main_Org.Org_Type FROM Protocol_Main_Org INNER JOIN Organization ON Protocol_Main_Org.Org_ID = Organization.Org_ID LEFT OUTER JOIN Project ON Protocol_Main_Org.Protocol_ID = Project.Protocol_ID WHERE	[Dept_Dept_id] = " + Smrt_Srch_DropDep.SelectedValue + " and Org_Type=2";
            //smart_exc_org.Query = "SELECT  distinct  Protocol_Main_Org.Org_ID, Project.Dept_Dept_id, Organization.Org_Desc, Protocol_Main_Org.Org_Type FROM Protocol_Main_Org INNER JOIN Organization ON Protocol_Main_Org.Org_ID = Organization.Org_ID LEFT OUTER JOIN Project ON Protocol_Main_Org.Protocol_ID = Project.Protocol_ID WHERE	[Dept_Dept_id] = " + Smrt_Srch_DropDep.SelectedValue + " and Org_Type=3";
            Query1 = "SELECT  distinct  Protocol_Main_Org.Org_ID, Project.Dept_Dept_id, Organization.Org_Desc, Protocol_Main_Org.Org_Type FROM Protocol_Main_Org INNER JOIN Organization ON Protocol_Main_Org.Org_ID = Organization.Org_ID LEFT OUTER JOIN Project ON Protocol_Main_Org.Protocol_ID = Project.Protocol_ID WHERE	[Dept_Dept_id] = " + Smrt_Srch_DropDep.SelectedValue + " and Org_Type=3";
            smart_org_coop.datatble = General_Helping.GetDataTable(Query);
            smart_exc_org.datatble = General_Helping.GetDataTable(Query1);
            smart_org_coop.Value_Field = smart_exc_org.Value_Field = smart_advantage_org.Value_Field = "Org_ID";
            smart_org_coop.Text_Field = smart_exc_org.Text_Field = smart_advantage_org.Text_Field = "Org_Desc";
            smart_org_coop.DataBind();
            smart_exc_org.DataBind();
            //smart_advantage_org.DataBind();

            //Smart_Search_Proj.sql_Connection = sql_Connection;
            //Smart_Search_Proj.Query = get_data_for_projects();
            //Smart_Search_Proj.Value_Field = "proj_id";
            //Smart_Search_Proj.Text_Field = "proj_title";
            //Smart_Search_Proj.DataBind();

            //string sql = "SELECT   distinct Project_Organization.org_org_id ,  Organization.Org_Desc, Project.Dept_Dept_id FROM         Project_Organization LEFT OUTER JOIN                      Organization ON Project_Organization.org_org_id = Organization.Org_ID LEFT OUTER JOIN                      Project ON Project_Organization.proj_proj_id = Project.Proj_id where dept_dept_id is not null and org_org_id is not null and Dept_Dept_id = " + Smrt_Srch_DropDep.SelectedValue;
            //ds = new DataSet();
            //da = new SqlDataAdapter(sql, conn);
            //da.Fill(ds, "org");
            //Droporg.DataSource = ds.Tables[0];
            //Droporg.DataValueField = "org_org_ID";
            //Droporg.DataTextField = "Org_Desc";
            //Droporg.DataBind();
            //Droporg.Items.Insert(0, new ListItem("اختر الجهة المستفيدة ......", "0"));
        }
        else
        {
            //Smrt_Srch_projmanage.sql_Connection = sql_Connection;
            //Smrt_Srch_projmanage.Query = "select PMP_ID,rol_rol_id,pmp_name from dbo.EMPLOYEE where rol_rol_id=4";
            //Smrt_Srch_projmanage.Value_Field = "PMP_ID";
            //Smrt_Srch_projmanage.Text_Field = "pmp_name";
            //Smrt_Srch_projmanage.DataBind();

            //Smart_Search_Proj.sql_Connection = sql_Connection;
            //Smart_Search_Proj.Query = "select proj_title,proj_id from project ";
            //Smart_Search_Proj.Value_Field = "proj_id";
            //Smart_Search_Proj.Text_Field = "proj_title";
            //Smart_Search_Proj.DataBind();

        }
        Label6.Visible = false;
    }
    protected void dropexc_org_fun()
    {
        //SqlConnection conn = new SqlConnection(sql_Connection);
        if (smart_exc_org.SelectedValue != "")
        {

            //smart_org_coop.sql_Connection = sql_Connection;
            smart_advantage_org.sql_Connection = sql_Connection;
            // smart_exc_org.sql_Connection = sql_Connection;
           // smart_org_coop.Query = "SELECT  distinct  Protocol_Main_Org.Org_ID, Project.Dept_Dept_id, Organization.Org_Desc, Protocol_Main_Org.Org_Type FROM Protocol_Main_Org INNER JOIN Organization ON Protocol_Main_Org.Org_ID = Organization.Org_ID LEFT OUTER JOIN Project ON Protocol_Main_Org.Protocol_ID = Project.Protocol_ID WHERE	[Dept_Dept_id] = " + Smrt_Srch_DropDep.SelectedValue + " and Org_Type=1";
          //  smart_advantage_org.Query = "SELECT  distinct  Protocol_Main_Org.Org_ID, Project.Dept_Dept_id, Organization.Org_Desc, Protocol_Main_Org.Org_Type FROM Protocol_Main_Org INNER JOIN Organization ON Protocol_Main_Org.Org_ID = Organization.Org_ID LEFT OUTER JOIN Project ON Protocol_Main_Org.Protocol_ID = Project.Protocol_ID WHERE	[Dept_Dept_id] = " + Smrt_Srch_DropDep.SelectedValue + " and Org_Type=2";
            string Query = "SELECT  distinct  Protocol_Main_Org.Org_ID, Project.Dept_Dept_id, Organization.Org_Desc, Protocol_Main_Org.Org_Type FROM Protocol_Main_Org INNER JOIN Organization ON Protocol_Main_Org.Org_ID = Organization.Org_ID LEFT OUTER JOIN Project ON Protocol_Main_Org.Protocol_ID = Project.Protocol_ID WHERE	[Dept_Dept_id] = " + Smrt_Srch_DropDep.SelectedValue + " and Org_Type=2";
            //smart_exc_org.Query = "SELECT  distinct  Protocol_Main_Org.Org_ID, Project.Dept_Dept_id, Organization.Org_Desc, Protocol_Main_Org.Org_Type FROM Protocol_Main_Org INNER JOIN Organization ON Protocol_Main_Org.Org_ID = Organization.Org_ID LEFT OUTER JOIN Project ON Protocol_Main_Org.Protocol_ID = Project.Protocol_ID WHERE	[Dept_Dept_id] = " + Smrt_Srch_DropDep.SelectedValue + " and Org_Type=3";
            smart_advantage_org.datatble = General_Helping.GetDataTable(Query);
            smart_org_coop.Value_Field = smart_exc_org.Value_Field = smart_advantage_org.Value_Field = "Org_ID";
            smart_org_coop.Text_Field = smart_exc_org.Text_Field = smart_advantage_org.Text_Field = "Org_Desc";
            smart_org_coop.DataBind();
            // smart_exc_org.DataBind();
            smart_advantage_org.DataBind();

            //Smart_Search_Proj.sql_Connection = sql_Connection;
            //Smart_Search_Proj.Query = get_data_for_projects();
            //Smart_Search_Proj.Value_Field = "proj_id";
            //Smart_Search_Proj.Text_Field = "proj_title";
            //Smart_Search_Proj.DataBind();

            //string sql = "SELECT   distinct Project_Organization.org_org_id ,  Organization.Org_Desc, Project.Dept_Dept_id FROM         Project_Organization LEFT OUTER JOIN                      Organization ON Project_Organization.org_org_id = Organization.Org_ID LEFT OUTER JOIN                      Project ON Project_Organization.proj_proj_id = Project.Proj_id where dept_dept_id is not null and org_org_id is not null and Dept_Dept_id = " + Smrt_Srch_DropDep.SelectedValue;
            //ds = new DataSet();
            //da = new SqlDataAdapter(sql, conn);
            //da.Fill(ds, "org");
            //Droporg.DataSource = ds.Tables[0];
            //Droporg.DataValueField = "org_org_ID";
            //Droporg.DataTextField = "Org_Desc";
            //Droporg.DataBind();
            //Droporg.Items.Insert(0, new ListItem("اختر الجهة المستفيدة ......", "0"));
        }
        else
        {
            //Smrt_Srch_projmanage.sql_Connection = sql_Connection;
            //Smrt_Srch_projmanage.Query = "select PMP_ID,rol_rol_id,pmp_name from dbo.EMPLOYEE where rol_rol_id=4";
            //Smrt_Srch_projmanage.Value_Field = "PMP_ID";
            //Smrt_Srch_projmanage.Text_Field = "pmp_name";
            //Smrt_Srch_projmanage.DataBind();

            //Smart_Search_Proj.sql_Connection = sql_Connection;
            //Smart_Search_Proj.Query = "select proj_title,proj_id from project ";
            //Smart_Search_Proj.Value_Field = "proj_id";
            //Smart_Search_Proj.Text_Field = "proj_title";
            //Smart_Search_Proj.DataBind();

        }
        Label6.Visible = false;
    }
    protected void dropdept_fun()
    {
        //SqlConnection conn = new SqlConnection(sql_Connection);
        if (Smrt_Srch_DropDep.SelectedValue != "")
        {
            string Query = "";
            string Query1 = "";
            string Query2 = "";
            smart_org_coop.sql_Connection = sql_Connection;
            smart_advantage_org.sql_Connection = sql_Connection;
            smart_exc_org.sql_Connection = sql_Connection;
            //smart_org_coop.Query = "SELECT  distinct  Protocol_Main_Org.Org_ID, Project.Dept_Dept_id, Organization.Org_Desc, Protocol_Main_Org.Org_Type FROM Protocol_Main_Org INNER JOIN Organization ON Protocol_Main_Org.Org_ID = Organization.Org_ID LEFT OUTER JOIN Project ON Protocol_Main_Org.Protocol_ID = Project.Protocol_ID WHERE	[Dept_Dept_id] = " + Smrt_Srch_DropDep.SelectedValue + " and Org_Type=1";
            Query = "SELECT  distinct  Protocol_Main_Org.Org_ID, Project.Dept_Dept_id, Organization.Org_Desc, Protocol_Main_Org.Org_Type FROM Protocol_Main_Org INNER JOIN Organization ON Protocol_Main_Org.Org_ID = Organization.Org_ID LEFT OUTER JOIN Project ON Protocol_Main_Org.Protocol_ID = Project.Protocol_ID WHERE	[Dept_Dept_id] = " + Smrt_Srch_DropDep.SelectedValue + " and Org_Type=1";
            //smart_advantage_org.Query1 = "SELECT  distinct  Protocol_Main_Org.Org_ID, Project.Dept_Dept_id, Organization.Org_Desc, Protocol_Main_Org.Org_Type FROM Protocol_Main_Org INNER JOIN Organization ON Protocol_Main_Org.Org_ID = Organization.Org_ID LEFT OUTER JOIN Project ON Protocol_Main_Org.Protocol_ID = Project.Protocol_ID WHERE	[Dept_Dept_id] = " + Smrt_Srch_DropDep.SelectedValue + " and Org_Type=2";
            Query1 = "SELECT  distinct  Protocol_Main_Org.Org_ID, Project.Dept_Dept_id, Organization.Org_Desc, Protocol_Main_Org.Org_Type FROM Protocol_Main_Org INNER JOIN Organization ON Protocol_Main_Org.Org_ID = Organization.Org_ID LEFT OUTER JOIN Project ON Protocol_Main_Org.Protocol_ID = Project.Protocol_ID WHERE	[Dept_Dept_id] = " + Smrt_Srch_DropDep.SelectedValue + " and Org_Type=2";
            //smart_exc_org.Query2 = "SELECT  distinct  Protocol_Main_Org.Org_ID, Project.Dept_Dept_id, Organization.Org_Desc, Protocol_Main_Org.Org_Type FROM Protocol_Main_Org INNER JOIN Organization ON Protocol_Main_Org.Org_ID = Organization.Org_ID LEFT OUTER JOIN Project ON Protocol_Main_Org.Protocol_ID = Project.Protocol_ID WHERE	[Dept_Dept_id] = " + Smrt_Srch_DropDep.SelectedValue + " and Org_Type=3";
            Query2 = "SELECT  distinct  Protocol_Main_Org.Org_ID, Project.Dept_Dept_id, Organization.Org_Desc, Protocol_Main_Org.Org_Type FROM Protocol_Main_Org INNER JOIN Organization ON Protocol_Main_Org.Org_ID = Organization.Org_ID LEFT OUTER JOIN Project ON Protocol_Main_Org.Protocol_ID = Project.Protocol_ID WHERE	[Dept_Dept_id] = " + Smrt_Srch_DropDep.SelectedValue + " and Org_Type=3";
            smart_org_coop.datatble = General_Helping.GetDataTable(Query);
            smart_advantage_org.datatble = General_Helping.GetDataTable(Query1);
            smart_exc_org.datatble = General_Helping.GetDataTable(Query2);
            smart_org_coop.Value_Field = smart_exc_org.Value_Field = smart_advantage_org.Value_Field = "Org_ID";
            smart_org_coop.Text_Field = smart_exc_org.Text_Field = smart_advantage_org.Text_Field = "Org_Desc";
            smart_org_coop.DataBind();
            smart_exc_org.DataBind();
            smart_advantage_org.DataBind();

            Smart_Search_Proj.sql_Connection = sql_Connection;
            Smart_Search_Proj.datatble = General_Helping.GetDataTable(get_data_for_projects());
            Smart_Search_Proj.Value_Field = "proj_id";
            Smart_Search_Proj.Text_Field = "proj_title";
            Smart_Search_Proj.DataBind();

            string sql = "SELECT   distinct Project_Organization.org_org_id ,  Organization.Org_Desc, Project.Dept_Dept_id FROM         Project_Organization LEFT OUTER JOIN                      Organization ON Project_Organization.org_org_id = Organization.Org_ID LEFT OUTER JOIN                      Project ON Project_Organization.proj_proj_id = Project.Proj_id where dept_dept_id is not null and org_org_id is not null and Dept_Dept_id = " + Smrt_Srch_DropDep.SelectedValue;
            ds = new DataSet();
            da = new SqlDataAdapter(sql, conn);
            da.Fill(ds, "org");
            Droporg.DataSource = ds.Tables[0];
            Droporg.DataValueField = "org_org_ID";
            Droporg.DataTextField = "Org_Desc";
            Droporg.DataBind();
            Droporg.Items.Insert(0, new ListItem("اختر الجهة المستفيدة ......", "0"));
        }
        else
        {
            string Query = "";
            Smrt_Srch_projmanage.sql_Connection = sql_Connection;
            //Smrt_Srch_projmanage.Query = "select PMP_ID,rol_rol_id,pmp_name from dbo.EMPLOYEE where rol_rol_id=4";
            Query = "select PMP_ID,rol_rol_id,pmp_name from dbo.EMPLOYEE where rol_rol_id=4";
            Smrt_Srch_projmanage.datatble = General_Helping.GetDataTable(Query);
            Smrt_Srch_projmanage.Value_Field = "PMP_ID";
            Smrt_Srch_projmanage.Text_Field = "pmp_name";
            Smrt_Srch_projmanage.DataBind();

            Smart_Search_Proj.sql_Connection = sql_Connection;
            Query = "select proj_title,proj_id from project ";
            Smart_Search_Proj.datatble = General_Helping.GetDataTable(Query);
            Smart_Search_Proj.Value_Field = "proj_id";
            Smart_Search_Proj.Text_Field = "proj_title";
            Smart_Search_Proj.DataBind();

        }
        Label6.Visible = false;
    }
    //protected void DropDep_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    SqlConnection conn = new SqlConnection(sql_Connection);
    //    if (Smrt_Srch_DropDep.SelectedValue == "")
    //    {
    //        sql = "select Proj_id,Proj_Title from Project";
    //        ds = new DataSet();
    //        da = new SqlDataAdapter(sql, conn);
    //        da.Fill(ds, "projects");
    //        DropProj.DataSource = ds.Tables[0];
    //        DropProj.DataTextField = "Proj_Title";
    //        DropProj.DataValueField = "Proj_id";
    //        DropProj.DataBind();
    //        DropProj.Items.Insert(0, new ListItem("اختر اسم المشروع......", "0"));
    //    }
    //    else
    //    {
    //        sql = "select Proj_id,Proj_Title,Dept_Dept_id from Project where Dept_Dept_id=" + Smrt_Srch_DropDep.SelectedValue;
    //        ds = new DataSet();
    //        da = new SqlDataAdapter(sql, conn);
    //        da.Fill(ds, "projects");
    //        DropProj.DataSource = ds.Tables[0];
    //        DropProj.DataTextField = "Proj_Title";
    //        DropProj.DataValueField = "Proj_id";
    //        DropProj.DataBind();
    //        DropProj.Items.Insert(0, new ListItem("اختر اسم المشروع......", "0"));
    //        Label6.Visible = false;
    //    }
    //    Label6.Visible = false;
    //}
    protected void Button1_Click(object sender, EventArgs e)
    {
        int emp = 0;
        int found_id = CDataConverter.ConvertToInt(Session_CS.foundation_id.ToString());
        DataTable dtpic = Site_Upload_DB.SelectAll(found_id);
        string orgname = dtpic.Rows[0]["Site_name"].ToString();
        /////////////////////////////////////////////////////////// Project document Report ///////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        if (hidden_Rpt_Id.Value == "ProjectDocumentReport")
        {
            SqlConnection conn = new SqlConnection(sql_Connection);

            int proj_id = 0;
            decimal budget = 0;
            string proj_name = "";
            string ptem_name = "";
            string dept_name = "";
            int dept_id = 0;
            //sql = "SELECT dbo.Project.Proj_id, dbo.Project.Proj_Title, dbo.Departments.Dept_name,dbo.Departments.Dept_id, dbo.JOB_TITLE.JTIT_Desc, dbo.Project.Proj_InitValue, dbo.Project_Team.PTem_Name,";
            //sql += " dbo.Project_Team.pmp_pmp_id,";
            //sql += " dbo.Project_Team.rol_rol_id,PTem_Task";
            //sql += " FROM dbo.Project INNER JOIN";
            //sql += " dbo.Departments ON dbo.Project.Dept_Dept_id = dbo.Departments.Dept_ID INNER JOIN";
            //sql += " dbo.Project_Team ON dbo.Project.Proj_id = dbo.Project_Team.proj_proj_id INNER JOIN";
            //sql += " dbo.JOB_TITLE INNER JOIN";
            //sql += " dbo.JOB ON dbo.JOB_TITLE.JTIT_ID = dbo.JOB.JTIT_JTIT_ID ON dbo.Project_Team.job_job_id = dbo.JOB.JOB_ID";
            //sql += " where 1=1";



            if (Smart_Search_Proj.SelectedValue != "")
            {
                proj_id = int.Parse(Smart_Search_Proj.SelectedValue);
                budget = decimal.Parse(LabValue.Text);
                proj_name = Smart_Search_Proj.Text_Field;
                ptem_name = Labname.Text;
                dept_name = LabDeptname.Text;
                //sql += " AND dbo.Project.Proj_id = " + proj_id;
            }
            if (Smrt_Srch_DropDep.SelectedValue != "")
            {
                dept_id = int.Parse(Smrt_Srch_DropDep.SelectedValue);
                //sql += " AND dbo.Departments.Dept_id =" + dept_id;
            }
            //sql += "order by Proj_Title,dbo.Project_Team.rol_rol_id ";
            //SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            //DataTable dt = new DataTable();
            //da.Fill(dt);
            string user = Session_CS.pmp_name.ToString();
            ReportDocument rd = new ReportDocument();
            string s = Server.MapPath("../Reports/proj_documn.rpt");
            rd.Load(s);
            //rd.SetDataSource(dt);
            Reports.Load_Report(rd);
            rd.SetParameterValue("@projdoc_id", proj_id);
            //rd.SetParameterValue(1, dept_id);
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
        /////////////////////////////////////////////////////////// Indicator type Report ///////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        if (hidden_Rpt_Id.Value == "IndicatorType_Report")
        {
            SqlConnection conn = new SqlConnection(sql_Connection);
            int proj_id = 0;
            int projmanage = 0;
            decimal budget = 0;
            string proj_name = "";
            string ptem_name = "";
            string dept_name = "";
            int dept_id = 0;


            sql = "select * ,(Case When PActv_Parent=0 Then PActv_Desc Else null End)as parent,(Case When PActv_Parent=0 Then 0 Else null End) as Parent_Actv_Num,PActv_Parent as LVL from Project_Activities  join project on Project_Activities.proj_proj_id=project.proj_id join Departments on project.Dept_Dept_id=Departments.Dept_ID inner join Project_Activities_Indicators on Project_Activities.PActv_ID=Project_Activities_Indicators.pactv_pactv_id left outer join Indicators_Type on Project_Activities_Indicators.indt_indt_id=Indicators_Type.IndT_id left outer join Project_Activity_indicator_period on Project_Activities_Indicators.PAIP_period_id=Project_Activity_indicator_period.ID left outer join Project_Activities_Indicators_History on Project_Activities_Indicators.PAI_ID=Project_Activities_Indicators_History.pai_pai_id  left outer join Organization on Project_Activities.Excutive_responsible_Org_Org_id = Organization.org_id where 1=1";
            if (Smrt_Srch_DropDep.SelectedValue != "")
            {
                dept_id = int.Parse(Smrt_Srch_DropDep.SelectedValue);
                sql += " AND dbo.Departments.Dept_ID = " + dept_id;
            }
            if (Smart_Search_Proj.SelectedValue != "")
            {
                proj_id = int.Parse(Smart_Search_Proj.SelectedValue);
                budget = decimal.Parse(LabValue.Text);
                proj_name = Smart_Search_Proj.Text_Field;
                ptem_name = Labname.Text;
                dept_name = LabDeptname.Text;
                sql += " AND dbo.Project.Proj_id = " + proj_id;

            }

            sql += " ORDER BY dbo.Project.Proj_id,PActv_ID";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);



            string user = Session_CS.pmp_name.ToString();
            ReportDocument rd = new ReportDocument();
            string s = Server.MapPath("../Reports/Indicator_Type_parameters.rpt");
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
        ///////////////////////////////////////////////////////////////////////////////// vocation dept managers
        ////////////////////////////////////////////////////////////////////////////////////////////

        else if (hidden_Rpt_Id.Value == "vocation_Details_dept_manager_Report")
        {
            string t1 = "";
            string t2 = "";
            int dept_id = 0;

            SqlConnection conn = new SqlConnection(sql_Connection);
            // sql = "set dateformat dmy SELECT dbo.Vacations.vacation_title, dbo.Vacations_users.start_date, CONVERT(datetime, dbo.datevalid(dbo.Vacations_users.start_date)) AS start_date, dbo.Vacations_users.end_date, CONVERT(datetime, dbo.datevalid(dbo.Vacations_users.end_date)) AS end_date, dbo.Vacations_users.no_days, dbo.Departments.Dept_ID, dbo.Departments.Dept_name, dbo.Vacations_users.manager_approve, dbo.Vacations_users.general_manager_approve, dbo.EMPLOYEE.pmp_name, dbo.Vacations_users.request_date AS request_date, CONVERT(datetime, dbo.datevalid(dbo.Vacations_users.request_date)) AS request_date, dbo.EMPLOYEE.PMP_ID, dbo.Vacations_summary.unusual, dbo.Vacations_summary.exhibitor, dbo.Vacations_summary.sick, dbo.Vacations_summary.hajj, dbo.Vacations_summary.birth, dbo.Vacations_summary.year, dbo.Vacations_summary.repeat FROM dbo.Vacations_users INNER JOIN  dbo.EMPLOYEE INNER JOIN dbo.Departments ON dbo.EMPLOYEE.Dept_Dept_id = dbo.Departments.Dept_ID ON dbo.Vacations_users.user_id = dbo.EMPLOYEE.PMP_ID INNER JOIN dbo.Vacations ON dbo.Vacations_users.vacation_id = dbo.Vacations.id  LEFT OUTER JOIN dbo.Vacations_summary ON dbo.Vacations_users.id = dbo.Vacations_summary.id AND dbo.EMPLOYEE.PMP_ID = dbo.Vacations_summary.emp_id where 1=1";
            sql = "set dateformat dmy select * from vacations_errand_View where 1=1";
            if (Smrt_Srch_DropDep.SelectedValue != "")
            {
                dept_id = int.Parse(Smrt_Srch_DropDep.SelectedValue);
                sql += " AND vacations_errand_View.Dept_ID = " + dept_id;
            }
            if (smart_employee.SelectedValue != "")
            {
                emp = int.Parse(smart_employee.SelectedValue);
                sql += " AND vacations_errand_View.PMP_ID = " + emp;
            }
            if (CDataConverter.ConvertToInt(Session_CS.group_id.ToString()) == 3)
            {
                sql += " AND vacations_errand_View.group_id = 3";
            }
            else
            {
                sql += " AND vacations_errand_View.vacation_mng_pmp_id = 57";
            }
            //if (Drop_vacation_status.SelectedValue !="4")
            //{
            //    vocation_stat = int.Parse(Drop_vacation_status.SelectedValue);
            //    sql += " AND dbo.Vacations_users.manager_approve = " + vocation_stat;

            //}



            /////////// begin check on take the vacation date

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
                    sql += " AND convert ( datetime,dbo.datevalid(vacations_errand_View.end_date)) < = '" + t2.ToString() + "'";
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
                    sql += " AND convert ( datetime,dbo.datevalid(vacations_errand_View.start_date)) > = '" + t1.ToString() + "'";
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
                    sql += " AND convert ( datetime,dbo.datevalid(vacations_errand_View.start_date)) > = '" + t1.ToString() + "'";
                    sql += " AND convert ( datetime,dbo.datevalid(vacations_errand_View.end_date)) < = '" + t2.ToString() + "'";
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


            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);





            string user = Session_CS.pmp_name.ToString();
            ReportDocument rd = new ReportDocument();
            string s = Server.MapPath("../Reports/Vacation_Detail_Dept_manager.rpt");
            rd.Load(s);
            rd.SetDataSource(dt);
            Reports.Load_Report(rd);

            rd.SetParameterValue("Orgname", orgname);
            rd.SetParameterValue("@start_Date", txt_take_date_from.Text);
            rd.SetParameterValue("@End_date", txt_take_date_to.Text);
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
        ///////////////////////////////////////////////////////////////////////////////// exist report
        ////////////////////////////////////////////////////////////////////////////////////////////

        else if (hidden_Rpt_Id.Value == "existance_Report")
        {

            int dept_id = 0;

            SqlConnection conn = new SqlConnection(sql_Connection);
            sql = "select case when (EMPLOYEE.PMP_ID  in (select  user_id  from Vacations_users where convert(datetime, end_date,103) >=  convert(datetime,convert(int,GETDATE()))  and convert(datetime, start_date,103) <= convert(datetime,convert(int,GETDATE())))) then '  أجازة '  when (EMPLOYEE.PMP_ID  in (select  user_id  from Vacations_errand where convert(datetime, end_date,103) >=  convert(datetime,convert(int,GETDATE()))  and convert(datetime, start_date,103) <= convert(datetime,convert(int,GETDATE())))) then '  مأمورية' else 'متواجد ' end as status,EMPLOYEE.PMP_ID,EMPLOYEE.pmp_name,Departments.Dept_ID,Departments.Dept_name from EMPLOYEE inner join Departments on Departments.Dept_ID=EMPLOYEE.Dept_Dept_id  ";
            if (Smrt_Srch_DropDep.SelectedValue != "")
            {
                dept_id = int.Parse(Smrt_Srch_DropDep.SelectedValue);
                sql += " where Departments.Dept_ID = " + dept_id;
            }
            sql += "order by status";


            //if (CDataConverter.ConvertToInt(Session_CS.group_id.ToString()) == 3)
            //{
            //    sql += " AND employee.group_id = 3";
            //}
            //else
            //{
            //    sql += " AND employee.group_id <> 3";
            //}







            ///////////////////////////////////////////////////////////////////// end check on sign_end _date/////////////////////////////////////



            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);





            string user = Session_CS.pmp_name.ToString();
            ReportDocument rd = new ReportDocument();
            string s = Server.MapPath("../Reports/existance_emp.rpt");
            rd.Load(s);
            rd.SetDataSource(dt);
            Reports.Load_Report(rd);
            //rd.SetParameterValue("@start_Date", txt_take_date_from.Text);
            //rd.SetParameterValue("@End_date", txt_take_date_to.Text);

            rd.SetParameterValue("Orgname", orgname);
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
        ///////////////////////////////////////////////////////////////////////////////// vocation dr hesham
        ////////////////////////////////////////////////////////////////////////////////////////////
        else if (hidden_Rpt_Id.Value == "vocation_Details_dr_hesham_Report")
        {
            string t1 = "";
            string t2 = "";
            int dept_id = 0;

            SqlConnection conn = new SqlConnection(sql_Connection);
            // sql = "set dateformat dmy SELECT dbo.Vacations.vacation_title, dbo.Vacations_users.start_date, CONVERT(datetime, dbo.datevalid(dbo.Vacations_users.start_date)) AS start_date, dbo.Vacations_users.end_date, CONVERT(datetime, dbo.datevalid(dbo.Vacations_users.end_date)) AS end_date, dbo.Vacations_users.no_days, dbo.Departments.Dept_ID, dbo.Departments.Dept_name, dbo.Vacations_users.manager_approve, dbo.Vacations_users.general_manager_approve, dbo.EMPLOYEE.pmp_name, dbo.Vacations_users.request_date AS request_date, CONVERT(datetime, dbo.datevalid(dbo.Vacations_users.request_date)) AS request_date, dbo.EMPLOYEE.PMP_ID, dbo.Vacations_summary.unusual, dbo.Vacations_summary.exhibitor, dbo.Vacations_summary.sick, dbo.Vacations_summary.hajj, dbo.Vacations_summary.birth, dbo.Vacations_summary.year, dbo.Vacations_summary.repeat FROM dbo.Vacations_users INNER JOIN  dbo.EMPLOYEE INNER JOIN dbo.Departments ON dbo.EMPLOYEE.Dept_Dept_id = dbo.Departments.Dept_ID ON dbo.Vacations_users.user_id = dbo.EMPLOYEE.PMP_ID INNER JOIN dbo.Vacations ON dbo.Vacations_users.vacation_id = dbo.Vacations.id  LEFT OUTER JOIN dbo.Vacations_summary ON dbo.Vacations_users.id = dbo.Vacations_summary.id AND dbo.EMPLOYEE.PMP_ID = dbo.Vacations_summary.emp_id where 1=1";
            sql = "set dateformat dmy SELECT TOP (100) PERCENT dbo.Vacations.vacation_title, dbo.Vacations_users.start_date, CONVERT(datetime, dbo.datevalid(dbo.Vacations_users.start_date)) AS start_date, dbo.Vacations_users.end_date, CONVERT(datetime, dbo.datevalid(dbo.Vacations_users.end_date)) AS end_date, dbo.Vacations_users.no_days, dbo.Departments.Dept_ID, dbo.Departments.Dept_name, dbo.Vacations_users.manager_approve, dbo.Vacations_users.general_manager_approve, dbo.EMPLOYEE.pmp_name, dbo.Vacations_users.request_date, CONVERT(datetime, dbo.datevalid(dbo.Vacations_users.request_date)) AS request_date, dbo.EMPLOYEE.PMP_ID, dbo.Vacations_summary.unusual, dbo.Vacations_summary.exhibitor, dbo.Vacations_summary.sick, dbo.Vacations_summary.hajj, dbo.Vacations_summary.birth, dbo.Vacations_summary.year, dbo.Vacations_summary.repeat FROM dbo.Vacations_users INNER JOIN dbo.EMPLOYEE INNER JOIN dbo.Departments ON dbo.EMPLOYEE.Dept_Dept_id = dbo.Departments.Dept_ID ON dbo.Vacations_users.user_id = dbo.EMPLOYEE.PMP_ID INNER JOIN dbo.Vacations ON dbo.Vacations_users.vacation_id = dbo.Vacations.id LEFT OUTER JOIN dbo.Vacations_summary ON dbo.EMPLOYEE.PMP_ID = dbo.Vacations_summary.emp_id WHERE (1 = 1)  and Vacations.id in (1,2) and  dbo.Vacations_users.manager_approve=1  ";
            if (Smrt_Srch_DropDep.SelectedValue != "")
            {
                dept_id = int.Parse(Smrt_Srch_DropDep.SelectedValue);
                sql += " AND dbo.Departments.Dept_ID = " + dept_id;
            }
            if (smart_employee.SelectedValue != "")
            {
                emp = int.Parse(smart_employee.SelectedValue);
                sql += " AND dbo.EMPLOYEE.PMP_ID = " + emp;
            }
            //if (Drop_vacation_status.SelectedValue !="4")
            //{
            //    vocation_stat = int.Parse(Drop_vacation_status.SelectedValue);
            //    sql += " AND dbo.Vacations_users.manager_approve = " + vocation_stat;

            //}



            /////////// begin check on take the vacation date

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

            sql += " and dbo.Vacations_users.user_id not in (563,566,565,505,599) ORDER BY dbo.Vacations_users.dept_id";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);





            string user = Session_CS.pmp_name.ToString();
            ReportDocument rd = new ReportDocument();
            string s = Server.MapPath("../Reports/Vacation_Detail_Dr_Hesham.rpt");
            rd.Load(s);
            rd.SetDataSource(dt);
            Reports.Load_Report(rd);
            rd.SetParameterValue("Orgname", orgname);
            rd.SetParameterValue("@start_Date", txt_take_date_from.Text);
            rd.SetParameterValue("@End_Date", txt_take_date_to.Text);
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
        ///////////////////////////////////////////////////////////// vacation summation ////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////
        else if (hidden_Rpt_Id.Value == "vocation_Sum_Report")
        {
            string t1 = "";
            string t2 = "";
            int dept_id = 0;

            SqlConnection conn = new SqlConnection(sql_Connection);
            sql = " set dateformat dmy SELECT SUM(CASE [vacation_id] WHEN 1 THEN dbo.Vacations_users.no_days ELSE 0 END) AS [اعتيادي],SUM(CASE [vacation_id] WHEN 2 THEN dbo.Vacations_users.no_days ELSE 0 END) AS [عارضة],SUM(CASE [vacation_id] WHEN 3 THEN dbo.Vacations_users.no_days ELSE 0 END) AS [مرضية],unusual as 'المتبقي اعتيادي',exhibitor as 'المتبقي عارضة',sick as 'المتبقي مرضي', dbo.Departments.Dept_ID, dbo.Departments.Dept_name, dbo.EMPLOYEE.pmp_name, dbo.EMPLOYEE.PMP_ID,dbo.EMPLOYEE.group_id FROM dbo.Vacations_users INNER JOIN dbo.EMPLOYEE INNER JOIN dbo.Departments ON dbo.EMPLOYEE.Dept_Dept_id = dbo.Departments.Dept_ID ON dbo.Vacations_users.user_id = dbo.EMPLOYEE.PMP_ID INNER JOIN dbo.Vacations ON dbo.Vacations_users.vacation_id = dbo.Vacations.id left outer join  dbo.Vacations_summary on dbo.EMPLOYEE.pmp_id = Vacations_summary.emp_id where 1=1 AND Vacations_users.manager_approve=1 ";
            if (Smrt_Srch_DropDep.SelectedValue != "")
            {
                dept_id = int.Parse(Smrt_Srch_DropDep.SelectedValue);
                sql += " AND dbo.Departments.Dept_ID = " + dept_id;
            }
            if (smart_employee.SelectedValue != "")
            {
                emp = int.Parse(smart_employee.SelectedValue);
                sql += " AND dbo.EMPLOYEE.PMP_ID = " + emp;
            }

            if (CDataConverter.ConvertToInt(Session_CS.group_id.ToString()) == 3)
            {
                sql += " AND dbo.EMPLOYEE.group_id = 3";
            }
            else
            {
                sql += " AND dbo.EMPLOYEE.group_id <> 3";
            }




            /////////// begin check on take the vacation date

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
            sql += " group by dbo.EMPLOYEE.PMP_ID,dbo.Departments.Dept_ID,dbo.Departments.Dept_name,dbo.EMPLOYEE.pmp_name,sick,unusual,exhibitor,dbo.EMPLOYEE.group_id";
            sql += " ORDER BY dept_id ";

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);



            string user = Session_CS.pmp_name.ToString();
            ReportDocument rd = new ReportDocument();
            string s = Server.MapPath("../Reports/Vacation_Summation.rpt");
            rd.Load(s);
            rd.SetDataSource(dt);
            Reports.Load_Report(rd);
            rd.SetParameterValue("Orgname", orgname);
            rd.SetParameterValue("@strat_date", t1);
            rd.SetParameterValue("@End_Date", t2);
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

        //////////////////////////////////////////////////////// vacation details report////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////
        else if (hidden_Rpt_Id.Value == "vocation_Details_Report")
        {
            string t1 = "";
            string t2 = "";
            int dept_id = 0;

            SqlConnection conn = new SqlConnection(sql_Connection);
            // sql = "set dateformat dmy SELECT dbo.Vacations.vacation_title, dbo.Vacations_users.start_date, CONVERT(datetime, dbo.datevalid(dbo.Vacations_users.start_date)) AS start_date, dbo.Vacations_users.end_date, CONVERT(datetime, dbo.datevalid(dbo.Vacations_users.end_date)) AS end_date, dbo.Vacations_users.no_days, dbo.Departments.Dept_ID, dbo.Departments.Dept_name, dbo.Vacations_users.manager_approve, dbo.Vacations_users.general_manager_approve, dbo.EMPLOYEE.pmp_name, dbo.Vacations_users.request_date AS request_date, CONVERT(datetime, dbo.datevalid(dbo.Vacations_users.request_date)) AS request_date, dbo.EMPLOYEE.PMP_ID, dbo.Vacations_summary.unusual, dbo.Vacations_summary.exhibitor, dbo.Vacations_summary.sick, dbo.Vacations_summary.hajj, dbo.Vacations_summary.birth, dbo.Vacations_summary.year, dbo.Vacations_summary.repeat FROM dbo.Vacations_users INNER JOIN  dbo.EMPLOYEE INNER JOIN dbo.Departments ON dbo.EMPLOYEE.Dept_Dept_id = dbo.Departments.Dept_ID ON dbo.Vacations_users.user_id = dbo.EMPLOYEE.PMP_ID INNER JOIN dbo.Vacations ON dbo.Vacations_users.vacation_id = dbo.Vacations.id  LEFT OUTER JOIN dbo.Vacations_summary ON dbo.Vacations_users.id = dbo.Vacations_summary.id AND dbo.EMPLOYEE.PMP_ID = dbo.Vacations_summary.emp_id where 1=1";
            sql = "set dateformat dmy SELECT TOP (100) PERCENT dbo.Vacations.vacation_title, dbo.Vacations_users.start_date, CONVERT(datetime, dbo.datevalid(dbo.Vacations_users.start_date)) AS start_date, dbo.Vacations_users.end_date, CONVERT(datetime, dbo.datevalid(dbo.Vacations_users.end_date)) AS end_date, dbo.Vacations_users.no_days, dbo.Departments.Dept_ID, dbo.Departments.Dept_name, dbo.Vacations_users.manager_approve, dbo.Vacations_users.general_manager_approve, dbo.EMPLOYEE.pmp_name,dbo.EMPLOYEE.group_id, dbo.Vacations_users.request_date, CONVERT(datetime, dbo.datevalid(dbo.Vacations_users.request_date)) AS request_date, dbo.EMPLOYEE.PMP_ID, dbo.Vacations_summary.unusual, dbo.Vacations_summary.exhibitor, dbo.Vacations_summary.sick, dbo.Vacations_summary.hajj, dbo.Vacations_summary.birth, dbo.Vacations_summary.year, dbo.Vacations_summary.repeat FROM dbo.Vacations_users INNER JOIN dbo.EMPLOYEE INNER JOIN dbo.Departments ON dbo.EMPLOYEE.Dept_Dept_id = dbo.Departments.Dept_ID ON dbo.Vacations_users.user_id = dbo.EMPLOYEE.PMP_ID INNER JOIN dbo.Vacations ON dbo.Vacations_users.vacation_id = dbo.Vacations.id LEFT OUTER JOIN dbo.Vacations_summary ON dbo.EMPLOYEE.PMP_ID = dbo.Vacations_summary.emp_id WHERE (1 = 1)";
            if (Smrt_Srch_DropDep.SelectedValue != "")
            {
                dept_id = int.Parse(Smrt_Srch_DropDep.SelectedValue);
                sql += " AND dbo.Departments.Dept_ID = " + dept_id;
            }
            if (smart_employee.SelectedValue != "")
            {
                emp = int.Parse(smart_employee.SelectedValue);
                sql += " AND dbo.EMPLOYEE.PMP_ID = " + emp;
            }
            if (CDataConverter.ConvertToInt(Session_CS.group_id.ToString()) == 3)
            {
                sql += " AND dbo.EMPLOYEE.group_id=3";
            }
            else
            {
                sql += " AND dbo.EMPLOYEE.group_id <> 3";
            }
            //if (Drop_vacation_status.SelectedValue !="4")
            //{
            //    vocation_stat = int.Parse(Drop_vacation_status.SelectedValue);
            //    sql += " AND dbo.Vacations_users.manager_approve = " + vocation_stat;

            //}
            //////////////// begin chek on request date field

            if (string.IsNullOrEmpty(txt_req_date_from.Text) && string.IsNullOrEmpty(txt_req_date_to.Text))
            {

                t1 = "01/01/1900";
                t2 = CDataConverter.ConvertDateTimeToFormatdmy(DateTime.MaxValue); 

            }
            else if (string.IsNullOrEmpty(txt_req_date_from.Text))
            {
                if (VB_Classes.Dates.Dates_Operation.date_validate(txt_req_date_to.Text.Trim()) != "")
                {
                    t1 = "01/01/1900";
                    //t2 = DateTime.ParseExact(Inbox_date_to.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
                    t2 = VB_Classes.Dates.Dates_Operation.date_validate(txt_req_date_to.Text.Trim());
                    sql += " AND convert (datetime,dbo.datevalid(dbo.Vacations_users.request_date)) < = '" + t2.ToString() + "'";
                }
                else
                {
                    ShowAlertMessage("!!!!!ادخل التاريخ بطريقة صحيحة !!!!");
                    return;
                }
            }
            else if (string.IsNullOrEmpty(txt_req_date_to.Text))
            {
                if (VB_Classes.Dates.Dates_Operation.date_validate(txt_req_date_from.Text.Trim()) != "")
                {
                    //t1 = DateTime.ParseExact(Inbox_date_from.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
                    t2 = CDataConverter.ConvertDateTimeToFormatdmy(DateTime.MaxValue); 
                    t1 = VB_Classes.Dates.Dates_Operation.date_validate(txt_req_date_from.Text.Trim());
                    sql += " AND convert (datetime,dbo.datevalid(dbo.Vacations_users.request_date)) > = '" + t1.ToString() + "'";

                }
                else
                {
                    ShowAlertMessage("!!!!!ادخل التاريخ بطريقة صحيحة !!!!");
                    return;
                }
            }
            else
            {
                if (VB_Classes.Dates.Dates_Operation.date_validate(txt_req_date_to.Text.Trim()) != "" && VB_Classes.Dates.Dates_Operation.date_validate(txt_req_date_from.Text.Trim()) != "")
                {

                    t2 = VB_Classes.Dates.Dates_Operation.date_validate(txt_req_date_to.Text.Trim());

                    t1 = VB_Classes.Dates.Dates_Operation.date_validate(txt_req_date_from.Text.Trim());
                    sql += " AND convert (datetime,dbo.datevalid(dbo.Vacations_users.request_date)) > = '" + t1.ToString() + "'";
                    sql += " AND convert (datetime,dbo.datevalid(dbo.Vacations_users.request_date)) < = '" + t2.ToString() + "'";
                }
                else
                {
                    ShowAlertMessage("!!!!!ادخل التاريخ بطريقة صحيحة !!!!");
                    return;
                }

            }
            DateTime date1 = CDataConverter.ConvertToDate(t1);
            DateTime date2 = CDataConverter.ConvertToDate(t2); 
            if (date2.Subtract(date1).Days < 0)
            {
                ShowAlertMessage("!!!!!التاريخ الأول يجب ان يكون قبل التاريخ الثاني !!!!");
                return;
            }

            /////////// begin check on take the vacation date

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

            sql += " ORDER BY dbo.Vacations_users.dept_id";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);






            string user = Session_CS.pmp_name.ToString();
            ReportDocument rd = new ReportDocument();
            string s = Server.MapPath("../Reports/Vacation_Detail.rpt");
            rd.Load(s);
            rd.SetDataSource(dt);
            Reports.Load_Report(rd);

            //DataTable dt_pic = General_Helping.GetDataTable("");

            rd.SetParameterValue("Orgname", orgname);
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
        //////////////////////////////////////////////////////// closed commission report////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////
        else if (hidden_Rpt_Id.Value == "closed_commission_Report")
        {
            string t1 = "";
            string t2 = "";
            int dept_id = 0;

            SqlConnection conn = new SqlConnection(sql_Connection);
            // sql = "set dateformat dmy SELECT dbo.Vacations.vacation_title, dbo.Vacations_users.start_date, CONVERT(datetime, dbo.datevalid(dbo.Vacations_users.start_date)) AS start_date, dbo.Vacations_users.end_date, CONVERT(datetime, dbo.datevalid(dbo.Vacations_users.end_date)) AS end_date, dbo.Vacations_users.no_days, dbo.Departments.Dept_ID, dbo.Departments.Dept_name, dbo.Vacations_users.manager_approve, dbo.Vacations_users.general_manager_approve, dbo.EMPLOYEE.pmp_name, dbo.Vacations_users.request_date AS request_date, CONVERT(datetime, dbo.datevalid(dbo.Vacations_users.request_date)) AS request_date, dbo.EMPLOYEE.PMP_ID, dbo.Vacations_summary.unusual, dbo.Vacations_summary.exhibitor, dbo.Vacations_summary.sick, dbo.Vacations_summary.hajj, dbo.Vacations_summary.birth, dbo.Vacations_summary.year, dbo.Vacations_summary.repeat FROM dbo.Vacations_users INNER JOIN  dbo.EMPLOYEE INNER JOIN dbo.Departments ON dbo.EMPLOYEE.Dept_Dept_id = dbo.Departments.Dept_ID ON dbo.Vacations_users.user_id = dbo.EMPLOYEE.PMP_ID INNER JOIN dbo.Vacations ON dbo.Vacations_users.vacation_id = dbo.Vacations.id  LEFT OUTER JOIN dbo.Vacations_summary ON dbo.Vacations_users.id = dbo.Vacations_summary.id AND dbo.EMPLOYEE.PMP_ID = dbo.Vacations_summary.emp_id where 1=1";
            sql = "set dateformat dmy SELECT  Commission.ID, Commission.Proj_id, Commission.Name, Commission.Code, Commission.Date, Commission.Type, Commission.Dept_ID, Commission.Emp_ID, Commission.Org_Id, Commission.Org_Name, Commission.Org_Out_Box_Code, Commission.Org_Out_Box_DT, Commission.Org_Out_Box_Person,Commission.Subject, Commission.Related_Type, Commission.Related_Id, Commission.Notes, Commission.Paper_No, Commission.Paper_Attached, Commission.Follow_Up_Dept_ID, Commission.Follow_Up_Emp_ID, Commission.Dept_Desc, Commission.Source_Type, Commission.Status,  Commission.Org_Dept_Name, Commission.Enter_Date, Commission.Dept_Dept_ID, Commission.Group_id, Commission.pmp_pmp_id, Commission.sub_Cat_id, Commission.finished, Commission.Resp_emp_close, Commission.Actual_emp_close, Commission.Date_close, EMPLOYEE.PMP_ID, EMPLOYEE_1.PMP_ID AS pmp_id_act, EMPLOYEE.pmp_name, EMPLOYEE_1.pmp_name AS pmp_name_act FROM EMPLOYEE AS EMPLOYEE_1 RIGHT OUTER JOIN Commission ON EMPLOYEE_1.PMP_ID = Commission.Actual_emp_close LEFT OUTER JOIN  EMPLOYEE ON Commission.Resp_emp_close = EMPLOYEE.PMP_ID WHERE (Commission.Actual_emp_close <> 0)";
            if (smart_employee.SelectedValue != "")
            {
                emp = int.Parse(smart_employee.SelectedValue);
                sql += " AND dbo.EMPLOYEE.PMP_ID = " + emp;
            }




            /////////// begin check on Closing Commission date

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
                    sql += " AND convert ( datetime,dbo.datevalid(dbo.Commission.Date_close)) < = '" + t2.ToString() + "'";
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
                    sql += " AND convert ( datetime,dbo.datevalid(dbo.Commission.Date_close)) > = '" + t1.ToString() + "'";
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
                    sql += " AND convert ( datetime,dbo.datevalid(dbo.Commission.Date_close)) > = '" + t1.ToString() + "'";
                    sql += " AND convert ( datetime,dbo.datevalid(dbo.Commission.Date_close)) < = '" + t2.ToString() + "'";
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

            sql += " ORDER BY Commission.ID";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);





            string user = Session_CS.pmp_name.ToString();
            ReportDocument rd = new ReportDocument();
            string s = Server.MapPath("../Reports/Closed_Commissions.rpt");
            rd.Load(s);
            rd.SetDataSource(dt);
            Reports.Load_Report(rd);
            rd.SetParameterValue("@start_Date", CDataConverter.ConvertDateTimeToFormatdmy(date3));
            rd.SetParameterValue("@End_Date", CDataConverter.ConvertDateTimeToFormatdmy(date4));
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
        //////////////////////////////////////////////////////// monitor dept report////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////
        else if (hidden_Rpt_Id.Value == "monitor_dept_Report")
        {
            string t1 = "";
            string t2 = "";


            SqlConnection conn = new SqlConnection(sql_Connection);
            // sql = "set dateformat dmy SELECT dbo.Vacations.vacation_title, dbo.Vacations_users.start_date, CONVERT(datetime, dbo.datevalid(dbo.Vacations_users.start_date)) AS start_date, dbo.Vacations_users.end_date, CONVERT(datetime, dbo.datevalid(dbo.Vacations_users.end_date)) AS end_date, dbo.Vacations_users.no_days, dbo.Departments.Dept_ID, dbo.Departments.Dept_name, dbo.Vacations_users.manager_approve, dbo.Vacations_users.general_manager_approve, dbo.EMPLOYEE.pmp_name, dbo.Vacations_users.request_date AS request_date, CONVERT(datetime, dbo.datevalid(dbo.Vacations_users.request_date)) AS request_date, dbo.EMPLOYEE.PMP_ID, dbo.Vacations_summary.unusual, dbo.Vacations_summary.exhibitor, dbo.Vacations_summary.sick, dbo.Vacations_summary.hajj, dbo.Vacations_summary.birth, dbo.Vacations_summary.year, dbo.Vacations_summary.repeat FROM dbo.Vacations_users INNER JOIN  dbo.EMPLOYEE INNER JOIN dbo.Departments ON dbo.EMPLOYEE.Dept_Dept_id = dbo.Departments.Dept_ID ON dbo.Vacations_users.user_id = dbo.EMPLOYEE.PMP_ID INNER JOIN dbo.Vacations ON dbo.Vacations_users.vacation_id = dbo.Vacations.id  LEFT OUTER JOIN dbo.Vacations_summary ON dbo.Vacations_users.id = dbo.Vacations_summary.id AND dbo.EMPLOYEE.PMP_ID = dbo.Vacations_summary.emp_id where 1=1";
            if (txt_no.Text != "")
            {
                sql = " set dateformat dmy SELECT   top " + txt_no.Text;
            }
            else
                sql = " set dateformat dmy SELECT  ";

            sql += "  COUNT(Project_Log.id) AS a, Departments.Dept_ID, Departments.Dept_name, MAX(CONVERT(datetime, dbo.datevalid(Project_Log.action_date))) AS date ,(select top(1) (P_log.Proj_id)  FROM         Project as proj INNER JOIN Project_Log as P_log  ON proj.Proj_id = P_log.proj_id where proj.Dept_Dept_id = Departments.Dept_ID order by P_log.id desc) as Proj_id_Last, (select top(1) (P_log.record_type)  FROM         Project as proj INNER JOIN Project_Log as P_log  ON proj.Proj_id = P_log.proj_id where proj.Dept_Dept_id = Departments.Dept_ID order by P_log.id desc) as record_type, (select top(1) (P_log.process)  FROM         Project as proj INNER JOIN Project_Log as P_log  ON proj.Proj_id = P_log.proj_id where proj.Dept_Dept_id = Departments.Dept_ID order by P_log.id desc) as process,(select top(1) (proj.Proj_Title)  FROM         Project as proj INNER JOIN Project_Log as P_log  ON proj.Proj_id = P_log.proj_id where proj.Dept_Dept_id = Departments.Dept_ID order by P_log.id desc) as Proj_Title_Last FROM         Departments INNER JOIN  Project ON Departments.Dept_ID = Project.Dept_Dept_id INNER JOIN EMPLOYEE INNER JOIN Project_Log ON EMPLOYEE.PMP_ID = Project_Log.user_id ON Project.Proj_id = Project_Log.proj_id where 1=1";


            //////////////// begin chek on request date field

            if (string.IsNullOrEmpty(txt_date_from.Text) && string.IsNullOrEmpty(txt_date_to.Text))
            {

                t1 = "01/01/1900";
                t2 = CDataConverter.ConvertDateTimeToFormatdmy(DateTime.MaxValue); 

            }
            else if (string.IsNullOrEmpty(txt_date_from.Text))
            {
                if (VB_Classes.Dates.Dates_Operation.date_validate(txt_date_to.Text.Trim()) != "")
                {
                    t1 = "01/01/1900";
                    //t2 = DateTime.ParseExact(Inbox_date_to.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
                    t2 = VB_Classes.Dates.Dates_Operation.date_validate(txt_date_to.Text.Trim());
                    sql += " AND convert (datetime,dbo.datevalid(dbo.Project_Log.action_date)) < = '" + t2.ToString() + "'";
                }
                else
                {
                    ShowAlertMessage("!!!!!ادخل التاريخ بطريقة صحيحة !!!!");
                    return;
                }
            }
            else if (string.IsNullOrEmpty(txt_date_to.Text))
            {
                if (VB_Classes.Dates.Dates_Operation.date_validate(txt_date_from.Text.Trim()) != "")
                {
                    //t1 = DateTime.ParseExact(Inbox_date_from.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
                    t2 = CDataConverter.ConvertDateTimeToFormatdmy(DateTime.MaxValue);
                    t1 = VB_Classes.Dates.Dates_Operation.date_validate(txt_date_from.Text.Trim());
                    sql += " AND convert (datetime,dbo.datevalid(dbo.Project_Log.action_date)) > = '" + t1.ToString() + "'";

                }
                else
                {
                    ShowAlertMessage("!!!!!ادخل التاريخ بطريقة صحيحة !!!!");
                    return;
                }
            }
            else
            {
                if (VB_Classes.Dates.Dates_Operation.date_validate(txt_date_to.Text.Trim()) != "" && VB_Classes.Dates.Dates_Operation.date_validate(txt_date_from.Text.Trim()) != "")
                {

                    t2 = VB_Classes.Dates.Dates_Operation.date_validate(txt_date_to.Text.Trim());

                    t1 = VB_Classes.Dates.Dates_Operation.date_validate(txt_date_from.Text.Trim());
                    sql += " AND convert (datetime,dbo.datevalid(dbo.Project_Log.action_date)) > = '" + t1.ToString() + "'";
                    sql += " AND convert (datetime,dbo.datevalid(dbo.Project_Log.action_date)) < = '" + t2.ToString() + "'";
                }
                else
                {
                    ShowAlertMessage("!!!!!ادخل التاريخ بطريقة صحيحة !!!!");
                    return;
                }

            }
            DateTime date1 = CDataConverter.ConvertToDate(t1); 
            DateTime date2 = CDataConverter.ConvertToDate(t2); 
            if (date2.Subtract(date1).Days < 0)
            {
                ShowAlertMessage("!!!!!التاريخ الأول يجب ان يكون قبل التاريخ الثاني !!!!");
                return;
            }


            sql += " GROUP BY dbo.Departments.Dept_ID, dbo.Departments.Dept_name";
            if (drop_stat.SelectedValue == "1")
            {
                sql += " order by COUNT(dbo.Project_Log.id) desc";
            }
            else
            {
                sql += " order by COUNT(dbo.Project_Log.id) asc";
            }

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);





            string user = Session_CS.pmp_name.ToString();
            ReportDocument rd = new ReportDocument();
            string s = Server.MapPath("../Reports/monitor_dept_report.rpt");
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
        //////////////////////////////////////////////////////// monitor proj report////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////
        else if (hidden_Rpt_Id.Value == "monitor_proj_Report")
        {
            string t1 = "";
            string t2 = "";


            SqlConnection conn = new SqlConnection(sql_Connection);
            // sql = "set dateformat dmy SELECT dbo.Vacations.vacation_title, dbo.Vacations_users.start_date, CONVERT(datetime, dbo.datevalid(dbo.Vacations_users.start_date)) AS start_date, dbo.Vacations_users.end_date, CONVERT(datetime, dbo.datevalid(dbo.Vacations_users.end_date)) AS end_date, dbo.Vacations_users.no_days, dbo.Departments.Dept_ID, dbo.Departments.Dept_name, dbo.Vacations_users.manager_approve, dbo.Vacations_users.general_manager_approve, dbo.EMPLOYEE.pmp_name, dbo.Vacations_users.request_date AS request_date, CONVERT(datetime, dbo.datevalid(dbo.Vacations_users.request_date)) AS request_date, dbo.EMPLOYEE.PMP_ID, dbo.Vacations_summary.unusual, dbo.Vacations_summary.exhibitor, dbo.Vacations_summary.sick, dbo.Vacations_summary.hajj, dbo.Vacations_summary.birth, dbo.Vacations_summary.year, dbo.Vacations_summary.repeat FROM dbo.Vacations_users INNER JOIN  dbo.EMPLOYEE INNER JOIN dbo.Departments ON dbo.EMPLOYEE.Dept_Dept_id = dbo.Departments.Dept_ID ON dbo.Vacations_users.user_id = dbo.EMPLOYEE.PMP_ID INNER JOIN dbo.Vacations ON dbo.Vacations_users.vacation_id = dbo.Vacations.id  LEFT OUTER JOIN dbo.Vacations_summary ON dbo.Vacations_users.id = dbo.Vacations_summary.id AND dbo.EMPLOYEE.PMP_ID = dbo.Vacations_summary.emp_id where 1=1";
            if (txt_no.Text != "")
            {
                sql = " set dateformat dmy SELECT   top " + txt_no.Text;
            }
            else
                sql = " set dateformat dmy SELECT   ";

            sql += " COUNT(dbo.Project_Log.id) AS a,  dbo.Project.Proj_id, dbo.Project.Proj_Title, dbo.EMPLOYEE.pmp_name,max(convert(datetime,dbo.datevalid(dbo.Project_Log.action_date))) as date,(select top(1) (b.record_type) from project_log as b where b.Proj_id = Project.Proj_id order by b.id desc ) as record_type,(select top(1) (b.process) from project_log as b where b.Proj_id = Project.Proj_id order by b.id desc ) as process FROM         dbo.Project_Log INNER JOIN dbo.Project ON dbo.Project_Log.proj_id = dbo.Project.Proj_id LEFT OUTER JOIN dbo.EMPLOYEE ON dbo.Project_Log.user_id = dbo.EMPLOYEE.PMP_ID where 1=1";


            //////////////// begin chek on action date field

            if (string.IsNullOrEmpty(txt_date_from.Text) && string.IsNullOrEmpty(txt_date_to.Text))
            {

                t1 = "01/01/1900";
                t2 = CDataConverter.ConvertDateTimeToFormatdmy(DateTime.MaxValue); 

            }
            else if (string.IsNullOrEmpty(txt_date_from.Text))
            {
                if (VB_Classes.Dates.Dates_Operation.date_validate(txt_date_to.Text.Trim()) != "")
                {
                    t1 = "01/01/1900";
                    //t2 = DateTime.ParseExact(Inbox_date_to.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
                    t2 = VB_Classes.Dates.Dates_Operation.date_validate(txt_date_to.Text.Trim());
                    sql += " AND convert (datetime,dbo.datevalid(dbo.Project_Log.action_date)) < = '" + t2.ToString() + "'";
                }
                else
                {
                    ShowAlertMessage("!!!!!ادخل التاريخ بطريقة صحيحة !!!!");
                    return;
                }
            }
            else if (string.IsNullOrEmpty(txt_date_to.Text))
            {
                if (VB_Classes.Dates.Dates_Operation.date_validate(txt_date_from.Text.Trim()) != "")
                {
                    //t1 = DateTime.ParseExact(Inbox_date_from.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
                    t2 = CDataConverter.ConvertDateTimeToFormatdmy(DateTime.MaxValue);
                    t1 = VB_Classes.Dates.Dates_Operation.date_validate(txt_date_from.Text.Trim());
                    sql += " AND convert (datetime,dbo.datevalid(dbo.Project_Log.action_date)) > = '" + t1.ToString() + "'";

                }
                else
                {
                    ShowAlertMessage("!!!!!ادخل التاريخ بطريقة صحيحة !!!!");
                    return;
                }
            }
            else
            {
                if (VB_Classes.Dates.Dates_Operation.date_validate(txt_date_to.Text.Trim()) != "" && VB_Classes.Dates.Dates_Operation.date_validate(txt_date_from.Text.Trim()) != "")
                {

                    t2 = VB_Classes.Dates.Dates_Operation.date_validate(txt_date_to.Text.Trim());

                    t1 = VB_Classes.Dates.Dates_Operation.date_validate(txt_date_from.Text.Trim());
                    sql += " AND convert (datetime,dbo.datevalid(dbo.Project_Log.action_date)) > = '" + t1.ToString() + "'";
                    sql += " AND convert (datetime,dbo.datevalid(dbo.Project_Log.action_date)) < = '" + t2.ToString() + "'";
                }
                else
                {
                    ShowAlertMessage("!!!!!ادخل التاريخ بطريقة صحيحة !!!!");
                    return;
                }

            }
            DateTime date1 = CDataConverter.ConvertToDate(t1);
            DateTime date2 = CDataConverter.ConvertToDate(t2); 
            if (date2.Subtract(date1).Days < 0)
            {
                ShowAlertMessage("!!!!!التاريخ الأول يجب ان يكون قبل التاريخ الثاني !!!!");
                return;
            }


            sql += " GROUP BY dbo.Project.Proj_id, dbo.Project.Proj_Title,pmp_name";
            if (drop_stat.SelectedValue == "1")
            {
                sql += " order by COUNT(dbo.Project_Log.id) desc";
            }
            else
            {
                sql += " order by COUNT(dbo.Project_Log.id) asc";
            }

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);





            string user = Session_CS.pmp_name.ToString();
            ReportDocument rd = new ReportDocument();
            string s = Server.MapPath("../Reports/monitor_proj_report.rpt");
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
        //////////////////////////////////////////////////////// monitor proj mng report////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////
        else if (hidden_Rpt_Id.Value == "monitor_projmng_Report")
        {
            string t1 = "";
            string t2 = "";


            SqlConnection conn = new SqlConnection(sql_Connection);
            // sql = "set dateformat dmy SELECT dbo.Vacations.vacation_title, dbo.Vacations_users.start_date, CONVERT(datetime, dbo.datevalid(dbo.Vacations_users.start_date)) AS start_date, dbo.Vacations_users.end_date, CONVERT(datetime, dbo.datevalid(dbo.Vacations_users.end_date)) AS end_date, dbo.Vacations_users.no_days, dbo.Departments.Dept_ID, dbo.Departments.Dept_name, dbo.Vacations_users.manager_approve, dbo.Vacations_users.general_manager_approve, dbo.EMPLOYEE.pmp_name, dbo.Vacations_users.request_date AS request_date, CONVERT(datetime, dbo.datevalid(dbo.Vacations_users.request_date)) AS request_date, dbo.EMPLOYEE.PMP_ID, dbo.Vacations_summary.unusual, dbo.Vacations_summary.exhibitor, dbo.Vacations_summary.sick, dbo.Vacations_summary.hajj, dbo.Vacations_summary.birth, dbo.Vacations_summary.year, dbo.Vacations_summary.repeat FROM dbo.Vacations_users INNER JOIN  dbo.EMPLOYEE INNER JOIN dbo.Departments ON dbo.EMPLOYEE.Dept_Dept_id = dbo.Departments.Dept_ID ON dbo.Vacations_users.user_id = dbo.EMPLOYEE.PMP_ID INNER JOIN dbo.Vacations ON dbo.Vacations_users.vacation_id = dbo.Vacations.id  LEFT OUTER JOIN dbo.Vacations_summary ON dbo.Vacations_users.id = dbo.Vacations_summary.id AND dbo.EMPLOYEE.PMP_ID = dbo.Vacations_summary.emp_id where 1=1";
            if (txt_no.Text != "")
            {
                sql = " set dateformat dmy SELECT   top " + txt_no.Text;
            }
            else
                sql = " set dateformat dmy SELECT   ";

            sql += "  count (Project_Log.id) as count_log, EMPLOYEE.pmp_name, MAX(CONVERT(datetime, dbo.datevalid(Project_Log.action_date))) AS date ,(select top(1) (P_log.Proj_id)  FROM   Project as proj INNER JOIN Project_Log as P_log  ON proj.Proj_id = P_log.proj_id where P_log.user_id = EMPLOYEE.pmp_id  order by P_log.id desc) as Proj_id_Last, (select top(1) (P_log.record_type)  FROM  Project as proj INNER JOIN Project_Log as P_log  ON proj.Proj_id = P_log.proj_id where P_log.user_id = EMPLOYEE.pmp_id order by P_log.id desc) as record_type, (select top(1) (P_log.process)  FROM  Project as proj INNER JOIN Project_Log as P_log  ON proj.Proj_id = P_log.proj_id where P_log.user_id = EMPLOYEE.pmp_id order by P_log.id desc) as process,(select top(1) (proj.Proj_Title)  FROM Project as proj INNER JOIN Project_Log as P_log  ON proj.Proj_id = P_log.proj_id where P_log.user_id = EMPLOYEE.pmp_id order by P_log.id desc) as Proj_Title_Last FROM         Project INNER JOIN Project_Log ON Project.Proj_id = Project_Log.proj_id INNER JOIN EMPLOYEE ON Project_Log.user_id = EMPLOYEE.PMP_ID where 1=1";


            //////////////// begin chek on action date field

            if (string.IsNullOrEmpty(txt_date_from.Text) && string.IsNullOrEmpty(txt_date_to.Text))
            {

                t1 = "01/01/1900";
                t2 = CDataConverter.ConvertDateTimeToFormatdmy(DateTime.MaxValue); 

            }
            else if (string.IsNullOrEmpty(txt_date_from.Text))
            {
                if (VB_Classes.Dates.Dates_Operation.date_validate(txt_date_to.Text.Trim()) != "")
                {
                    t1 = "01/01/1900";
                    //t2 = DateTime.ParseExact(Inbox_date_to.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
                    t2 = VB_Classes.Dates.Dates_Operation.date_validate(txt_date_to.Text.Trim());
                    sql += " AND convert (datetime,dbo.datevalid(dbo.Project_Log.action_date)) < = '" + t2.ToString() + "'";
                }
                else
                {
                    ShowAlertMessage("!!!!!ادخل التاريخ بطريقة صحيحة !!!!");
                    return;
                }
            }
            else if (string.IsNullOrEmpty(txt_date_to.Text))
            {
                if (VB_Classes.Dates.Dates_Operation.date_validate(txt_date_from.Text.Trim()) != "")
                {
                    //t1 = DateTime.ParseExact(Inbox_date_from.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
                    t2 = CDataConverter.ConvertDateTimeToFormatdmy(DateTime.MaxValue); 
                    t1 = VB_Classes.Dates.Dates_Operation.date_validate(txt_date_from.Text.Trim());
                    sql += " AND convert (datetime,dbo.datevalid(dbo.Project_Log.action_date)) > = '" + t1.ToString() + "'";

                }
                else
                {
                    ShowAlertMessage("!!!!!ادخل التاريخ بطريقة صحيحة !!!!");
                    return;
                }
            }
            else
            {
                if (VB_Classes.Dates.Dates_Operation.date_validate(txt_date_to.Text.Trim()) != "" && VB_Classes.Dates.Dates_Operation.date_validate(txt_date_from.Text.Trim()) != "")
                {

                    t2 = VB_Classes.Dates.Dates_Operation.date_validate(txt_date_to.Text.Trim());

                    t1 = VB_Classes.Dates.Dates_Operation.date_validate(txt_date_from.Text.Trim());
                    sql += " AND convert (datetime,dbo.datevalid(dbo.Project_Log.action_date)) > = '" + t1.ToString() + "'";
                    sql += " AND convert (datetime,dbo.datevalid(dbo.Project_Log.action_date)) < = '" + t2.ToString() + "'";
                }
                else
                {
                    ShowAlertMessage("!!!!!ادخل التاريخ بطريقة صحيحة !!!!");
                    return;
                }

            }
            DateTime date1 = CDataConverter.ConvertToDate(t1);
            DateTime date2 = CDataConverter.ConvertToDate(t2); 
            if (date2.Subtract(date1).Days < 0)
            {
                ShowAlertMessage("!!!!!التاريخ الأول يجب ان يكون قبل التاريخ الثاني !!!!");
                return;
            }


            sql += " group by pmp_name,EMPLOYEE.pmp_id ";
            if (drop_stat.SelectedValue == "1")
            {
                sql += " order by COUNT(dbo.Project_Log.id) desc";
            }
            else
            {
                sql += " order by COUNT(dbo.Project_Log.id) asc";
            }

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);





            string user = Session_CS.pmp_name.ToString();
            ReportDocument rd = new ReportDocument();
            string s = Server.MapPath("../Reports/monitor_projmng_report.rpt");
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
        ////////////////////////////////////////////////////////////// similar projetcs//////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        else if (hidden_Rpt_Id.Value == "similar_projects_Report")
        {
            SqlConnection conn = new SqlConnection(sql_Connection);
            if (Drop_category.SelectedValue != "0" || Drop_technology.SelectedValue != "0")
            {
                ReportDocument rd = new ReportDocument();

                int projmanage = 0;
                int org_id = 0;
                int cat = 0;
                int tech = 0;
                int dept_id = 0;

                sql = "select distinct proj_id,proj_title,Dept_name,dept_dept_id,pmp_name from Similar_Projects_View";
                sql += " where 1=1  ";

                if (Smrt_Srch_DropDep.SelectedValue != "")
                {
                    dept_id = int.Parse(Smrt_Srch_DropDep.SelectedValue);
                    sql += " AND dept_dept_id = " + dept_id;
                }
                if (Smrt_Srch_projmanage.SelectedValue != "")
                {
                    projmanage = int.Parse(Smrt_Srch_projmanage.SelectedValue);
                    sql += " AND PMP_ID = " + projmanage;
                }
                if (Drop_category.SelectedValue != "0")
                {
                    cat = int.Parse(Drop_category.SelectedValue);
                    sql += " AND proj_category_id = " + cat;
                }
                if (Drop_technology.SelectedValue != "0")
                {
                    tech = int.Parse(Drop_technology.SelectedValue);
                    sql += " AND technique_id = " + tech;
                }
                if (Droporg.SelectedValue != "0")
                {
                    org_id = int.Parse(Droporg.SelectedValue);
                    sql += " AND org_org_id = " + org_id;
                }
                //DataTable DT = General_Helping.GetDataTable("select dept_id from EMPLOYEE_Departemnts where pmp_id=" + pmp);

                ////string sql = "SELECT Project.proj_id,Project.Proj_Title, Departments.Dept_name, Project.Dept_Dept_id , Project.Pmp_pmp_id , employee.pmp_name,(select COUNT(Project_Activities.proj_proj_id) from Project_Activities where Project_Activities.proj_proj_id=project.Proj_id AND PActv_Parent=0) as  Parent_Act_Count,(select COUNT(Project_Activities.proj_proj_id) from Project_Activities where Project_Activities.proj_proj_id=project.Proj_id AND PActv_Parent<>0) as  child_Act_Count,(select COUNT(Project_Needs.proj_proj_id) from Project_Needs where Project_Needs.proj_proj_id=project.Proj_id ) as Pneeds,(select COUNT(Project_Objective.proj_proj_id) from Project_Objective where Project_Objective.proj_proj_id=project.Proj_id ) as proj_obj,(select COUNT(Project_Team.proj_proj_id) from Project_Team where Project_Team.proj_proj_id=project.Proj_id ) as proj_team,(select COUNT(Project_Organization.proj_proj_id) from Project_Organization where Project_Organization.proj_proj_id=project.Proj_id ) as proj_org FROM Departments INNER JOIN Project ON Departments.Dept_ID = Project.Dept_Dept_id LEFT OUTER JOIN employee on project.pmp_pmp_id=employee.pmp_id";
                //sql += " AND dept_id = " + dept_id;
                //if (DT.Rows.Count > 1)
                //{
                //    for (int i = 0; i < DT.Rows.Count; i++)
                //    {
                //        sql += " or dept_id = " + CDataConverter.ConvertToInt(DT.Rows[i]["dept_id"].ToString());
                //    }
                //}



                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt_Report = new DataTable();
                da.Fill(dt_Report);
                string user = Session_CS.pmp_name.ToString();
                string s = Server.MapPath("../Reports/Similar_projects.rpt");
                rd.Load(s);
                rd.SetDataSource(dt_Report);
                Reports.Load_Report(rd);

                rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
                rd.SetParameterValue("@user", user, "footerRep.rpt");
                if (dt_Report.Rows.Count == 0)
                {
                    ShowAlertMessage("!!!!!هذا التقرير لا يوجد به بيانات للعرض !!!!");
                    return;
                }
                else
                {
                    rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report");
                }

            }
            else
            {
                ShowAlertMessage("!!!!!يجب اختيار تصنيف أو تقنية لعرض هذا التقرير !!!!");
                return;
            }
            //int pmp = int.Parse(Session_CS.pmp_id.ToString());



        }
        /////////////////////////////////////////////////////////////////////

        else if (hidden_Rpt_Id.Value == "DeptProjectReport")
        {
            ReportDocument rd = new ReportDocument();
            SqlConnection conn = new SqlConnection(sql_Connection);
            if (Droporg.SelectedValue != "0")
            {
                /// org_id = int.Parse(Droporg.SelectedValue);
                // sql += " AND org_org_id = " + org_id;
            }
            //SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            // DataTable dt_Report = new DataTable();
            // da.Fill(dt_Report);
            string user = Session_CS.pmp_name.ToString();
            string s = Server.MapPath("../Reports/Proj_InfoByDept.rpt");
            rd.Load(s);
            //rd.SetDataSource(dt_Report);
            Reports.Load_Report(rd);
            rd.SetParameterValue("@dept_id", Smrt_Srch_DropDep.SelectedValue);
            rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
            rd.SetParameterValue("@user", user, "footerRep.rpt");
            if (rd.Rows.Count == 0)
            {
                ShowAlertMessage("!!!!!هذا التقرير لا يوجد به بيانات للعرض !!!!");
                return;
            }
            else
            {
                rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report");
            }

        }


        else if (hidden_Rpt_Id.Value == "OrgProjectReport")
        {
            ReportDocument rd = new ReportDocument();
            SqlConnection conn = new SqlConnection(sql_Connection);
            if (Droporg.SelectedValue != "0")
            {
                /// org_id = int.Parse(Droporg.SelectedValue);
                // sql += " AND org_org_id = " + org_id;
            }
            //SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            // DataTable dt_Report = new DataTable();
            // da.Fill(dt_Report);
            string user = Session_CS.pmp_name.ToString();
            string s = Server.MapPath("../Reports/Proj_Info.rpt");
            rd.Load(s);
            //rd.SetDataSource(dt_Report);
            Reports.Load_Report(rd);
            rd.SetParameterValue("@org_id", Droporg.SelectedValue);
            rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
            rd.SetParameterValue("@user", user, "footerRep.rpt");
            if (rd.Rows.Count == 0)
            {
                ShowAlertMessage("!!!!!هذا التقرير لا يوجد به بيانات للعرض !!!!");
                return;
            }
            else
            {
                rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report");
            }

        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        else if (hidden_Rpt_Id.Value == "SummryProjectReport")
        {

            int proj_id = 0;
            int projmanage = 0;
            decimal budget = 0;
            string proj_name = "";
            string ptem_name = "";
            string dept_name = "";
            int dept_id = 0;
            ReportDocument rd = new ReportDocument();
            SqlConnection conn = new SqlConnection(sql_Connection);
            if (Smart_Search_Proj.SelectedValue != "")
            {
                //DeptProjectLink

                proj_id = int.Parse(Smart_Search_Proj.SelectedValue);
                budget = decimal.Parse(LabValue.Text);
                proj_name = Smart_Search_Proj.Text_Field;
                ptem_name = Labname.Text;
                dept_name = LabDeptname.Text;
                /// org_id = int.Parse(Droporg.SelectedValue);
                // sql += " AND org_org_id = " + org_id;

                //SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                // DataTable dt_Report = new DataTable();
                // da.Fill(dt_Report);
                string user = Session_CS.pmp_name.ToString();
                string s = Server.MapPath("../Reports/Proj_ALL_Data.rpt");
                rd.Load(s);
                //rd.SetDataSource(dt_Report);
                Reports.Load_Report(rd);
                rd.SetParameterValue("@proj_id", proj_id);
                //rd.SetParameterValue("@proj_id", proj_id, "Report_Sticker_Try2.rpt");

                rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
                rd.SetParameterValue("@user", user, "footerRep.rpt");


                if (rd.Rows.Count == 0)
                {
                    ShowAlertMessage("!!!!!هذا التقرير لا يوجد به بيانات للعرض !!!!");
                    return;
                }
                else
                {
                    rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.WordForWindows, Response, true, "Report");
                }


            }

            else { ShowAlertMessage("يجب اختيار المشروع أولاَ!!!!!!!!"); }

        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        else if (hidden_Rpt_Id.Value == "proj_people_services")
        {



            SqlConnection conn = new SqlConnection(sql_Connection);

            sql = "select proj_services.* , Project.Proj_Title,Departments.Dept_name from proj_services inner join Project on Project.proj_id=proj_services.proj_id and( proj_services.proj_citizen_service !='' or proj_services.proj_gov_service  !='' ) inner join Departments on Departments.Dept_id=Project.Dept_Dept_id where (1=1)";


            if (Smrt_Srch_DropDep.SelectedValue != "")
            {

                sql += " AND Departments.Dept_ID = " + Smrt_Srch_DropDep.SelectedValue;
            }

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            ReportDocument rd = new ReportDocument();
            string user = Session_CS.pmp_name.ToString();
            string s = Server.MapPath("../Reports/project_people_services.rpt");
            rd.Load(s);
            rd.SetDataSource(dt);
            Reports.Load_Report(rd);

            //rd.SetParameterValue(0, proj_id);
            rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
            rd.SetParameterValue("@user", user, "footerRep.rpt");
            if (dt.Rows.Count == 0)
            {
                ShowAlertMessage("!!!!!هذا التقرير لا يوجد به بيانات للعرض !!!!");
                return;
            }
            else
            {
                rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.WordForWindows, Response, true, "Report");
            }



        }













        /////////////////////////////////////////////////////////// Indicator development Report ///////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        if (hidden_Rpt_Id.Value == "Indicator_Development_Report")
        {
            SqlConnection conn = new SqlConnection(sql_Connection);
            int proj_id = 0;
            int projmanage = 0;
            decimal budget = 0;
            string proj_name = "";
            string ptem_name = "";
            string dept_name = "";
            int dept_id = 0;
            int pAct_id = 0;



            sql = "select * ,(Case When PActv_Parent=0 Then PActv_Desc Else null End)as parent,(Case When PActv_Parent=0 Then 0 Else null End) as Parent_Actv_Num,PActv_Parent as LVL from Project_Activities  join project on Project_Activities.proj_proj_id=project.proj_id join Departments on project.Dept_Dept_id=Departments.Dept_ID inner join Project_Activities_Indicators on Project_Activities.PActv_ID=Project_Activities_Indicators.pactv_pactv_id inner join Indicators_Type on Project_Activities_Indicators.indt_indt_id=Indicators_Type.IndT_id inner join Project_Activity_indicator_period on Project_Activities_Indicators.PAIP_period_id=Project_Activity_indicator_period.ID inner join Project_Activities_Indicators_History on Project_Activities_Indicators.PAI_ID=Project_Activities_Indicators_History.pai_pai_id left outer join Organization on Project_Activities.Excutive_responsible_Org_Org_id = Organization.org_id where 1=1";


            if (Request.QueryString["type"] == "1")
            {
                if (Smrt_Srch_DropDep.SelectedValue != "")
                {
                    dept_id = int.Parse(Smrt_Srch_DropDep.SelectedValue);
                    sql += " AND dbo.Departments.Dept_ID = " + dept_id;
                }
                if (Smart_Search_Proj.SelectedValue != "")
                {
                    proj_id = int.Parse(Smart_Search_Proj.SelectedValue);
                    budget = decimal.Parse(LabValue.Text);
                    proj_name = Smart_Search_Proj.Text_Field;
                    ptem_name = Labname.Text;
                    dept_name = LabDeptname.Text;
                    sql += " AND dbo.Project.Proj_id = " + proj_id;

                }
                if (Smrt_Srch_projmanage.SelectedValue != "")
                {
                    projmanage = int.Parse(Smrt_Srch_projmanage.SelectedValue);
                    sql += " AND dbo.employee.pmp_id = " + projmanage;
                }
            }
            else
            {
                if (Smrt_Srch_DropDep.SelectedValue != "")
                {
                    dept_id = int.Parse(Smrt_Srch_DropDep.SelectedValue);
                    sql += " AND dbo.Departments.Dept_ID = " + dept_id;
                }
                if (Smart_Search_Proj.SelectedValue != "")
                {
                    proj_id = int.Parse(Smart_Search_Proj.SelectedValue);
                    budget = decimal.Parse(LabValue.Text);
                    proj_name = Smart_Search_Proj.Text_Field;
                    ptem_name = Labname.Text;
                    dept_name = LabDeptname.Text;
                    sql += " AND dbo.Project.Proj_id = " + proj_id;

                }
                //else
                //{
                //    ShowAlertMessage("!!!!!يجب اختيار مشروع لعرض التقرير !!!!");
                //    return;
                //}
            }
            if (Smart_Search_main.SelectedValue != "" && Smart_Search_sub.SelectedValue == "")
            {
                pAct_id = int.Parse(Smart_Search_main.SelectedValue);
                sql += " AND dbo.Project_Activities.PActv_ID = " + pAct_id;
            }
            else if (Smart_Search_sub.SelectedValue != "" && Smart_Search_main.SelectedValue == "")
            {
                pAct_id = int.Parse(Smart_Search_sub.SelectedValue);
                sql += " AND dbo.Project_Activities.PActv_ID = " + pAct_id;
            }
            else if (Smart_Search_main.SelectedValue != "" && Smart_Search_sub.SelectedValue != "")
            {
                pAct_id = int.Parse(Smart_Search_sub.SelectedValue);
                sql += " AND dbo.Project_Activities.PActv_ID = " + pAct_id;
            }
            sql += " ORDER BY dbo.Project.Proj_id";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);



            string user = Session_CS.pmp_name.ToString();
            ReportDocument rd = new ReportDocument();
            string s = Server.MapPath("../Reports/Indicator_Development.rpt");
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

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////// needs _ in detail report////////////////////////////////////////
        else if (hidden_Rpt_Id.Value == "needs_in_details_Report")
        {
            SqlConnection conn = new SqlConnection(sql_Connection);
            int proj_id = 0;
            int projmanage = 0;
            decimal budget = 0;
            string proj_name = "";
            string ptem_name = "";
            string dept_name = "";
            int dept_id = 0;
            sql = "SELECT dbo.Project.Proj_id, dbo.Project.Proj_Title, dbo.Needs_Sup_Type.NST_Desc,";
            sql += " SUM(dbo.Project_Needs.PNed_Number) AS summation, dbo.Project_Needs.PNed_InitValue, dbo.Departments.Dept_name, ";
            sql += " dbo.Departments.Dept_ID, dbo.employee.Pmp_Name, dbo.Project.Proj_InitValue, ";
            sql += " dbo.Project.pmp_pmp_id ";
            sql += " FROM dbo.Departments INNER JOIN ";
            sql += " dbo.Project ON dbo.Departments.Dept_ID = dbo.Project.Dept_Dept_id INNER JOIN ";
            sql += " dbo.Project_Needs ON dbo.Project.Proj_id = dbo.Project_Needs.proj_proj_id INNER JOIN ";
            sql += " dbo.Needs_Sup_Type ON dbo.Project_Needs.nst_nst_id = dbo.Needs_Sup_Type.NST_ID ";
            sql += " AND dbo.Project_Needs.nst_nst_id = dbo.Needs_Sup_Type.NST_ID INNER JOIN ";
            sql += " dbo.employee ON dbo.Project.Pmp_pmp_id = dbo.employee.pmp_id";
            sql += " where 1=1  ";





            if (Smrt_Srch_projmanage.SelectedValue != "")
            {
                projmanage = int.Parse(Smrt_Srch_projmanage.SelectedValue);
                sql += " AND dbo.employee.pmp_id = " + projmanage;
            }
            if (Request.QueryString["type"] == "1")
            {
                if (Smrt_Srch_DropDep.SelectedValue != "")
                {
                    dept_id = int.Parse(Smrt_Srch_DropDep.SelectedValue);
                    sql += " AND dbo.Departments.Dept_ID = " + dept_id;
                }
                if (Smart_Search_Proj.SelectedValue != "")
                {
                    proj_id = int.Parse(Smart_Search_Proj.SelectedValue);
                    budget = decimal.Parse(LabValue.Text);
                    proj_name = Smart_Search_Proj.Text_Field;
                    ptem_name = Labname.Text;
                    dept_name = LabDeptname.Text;
                    sql += " AND dbo.Project.Proj_id = " + proj_id;

                }
            }
            else
            {
                if (Smart_Search_Proj.SelectedValue != "")
                {
                    proj_id = int.Parse(Smart_Search_Proj.SelectedValue);
                    budget = decimal.Parse(LabValue.Text);
                    proj_name = Smart_Search_Proj.Text_Field;
                    ptem_name = Labname.Text;
                    dept_name = LabDeptname.Text;
                    sql += " AND dbo.Project.Proj_id = " + proj_id;

                }
                else
                {
                    ShowAlertMessage("!!!!!يجب اختيار مشروع لعرض التقرير !!!!");
                    return;
                }
            }


            sql += " GROUP BY dbo.Project.Proj_id, dbo.Project.Proj_Title, dbo.Needs_Sup_Type.NST_Desc, dbo.Project_Needs.PNed_InitValue, dbo.Departments.Dept_name, dbo.Departments.Dept_ID, employee.pmp_name, dbo.Project.Proj_InitValue, employee.pmp_id,dbo.Project.pmp_pmp_id";



            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            string user = Session_CS.pmp_name.ToString();
            ReportDocument rd = new ReportDocument();
            string s = Server.MapPath("../Reports/Needs_In_Details_Proj.rpt");
            rd.Load(s);
            rd.SetDataSource(dt);
            Reports.Load_Report(rd);

            rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
            rd.SetParameterValue("@user", user, "footerRep.rpt");
            if (dt.Rows.Count == 0)
            {
                ShowAlertMessage("هذا التقرير لا يوجد به بيانات للعرض !!!!");
                return;
            }
            else
            {
                rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report");
            }


        }
        /////////////////////////////////////////////////// employee report///////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        else if (hidden_Rpt_Id.Value == "Employees_Report")
        {
            SqlConnection conn = new SqlConnection(sql_Connection);

            int proj_id = 0;
            decimal budget = 0;
            string proj_name = "";
            string ptem_name = "";
            string dept_name = "";
            int dept_id = 0;
            sql = "SELECT dbo.Project.Proj_id, dbo.Project.Proj_Title, dbo.Departments.Dept_name,dbo.Departments.Dept_id, dbo.JOB_TITLE.JTIT_Desc, dbo.Project.Proj_InitValue, dbo.Project_Team.PTem_Name,";
            sql += " dbo.Project_Team.pmp_pmp_id,";
            sql += " dbo.Project_Team.rol_rol_id,PTem_Task";
            sql += " FROM dbo.Project INNER JOIN";
            sql += " dbo.Departments ON dbo.Project.Dept_Dept_id = dbo.Departments.Dept_ID INNER JOIN";
            sql += " dbo.Project_Team ON dbo.Project.Proj_id = dbo.Project_Team.proj_proj_id INNER JOIN";
            sql += " dbo.JOB_TITLE INNER JOIN";
            sql += " dbo.JOB ON dbo.JOB_TITLE.JTIT_ID = dbo.JOB.JTIT_JTIT_ID ON dbo.Project_Team.job_job_id = dbo.JOB.JOB_ID";
            sql += " where 1=1";



            if (Smart_Search_Proj.SelectedValue != "")
            {
                proj_id = int.Parse(Smart_Search_Proj.SelectedValue);
                budget = decimal.Parse(LabValue.Text);
                proj_name = Smart_Search_Proj.Text_Field;
                ptem_name = Labname.Text;
                dept_name = LabDeptname.Text;
                sql += " AND dbo.Project.Proj_id = " + proj_id;
            }
            if (Smrt_Srch_DropDep.SelectedValue != "")
            {
                dept_id = int.Parse(Smrt_Srch_DropDep.SelectedValue);
                sql += " AND dbo.Departments.Dept_id =" + dept_id;
            }
            sql += "order by Proj_Title,dbo.Project_Team.rol_rol_id ";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            string user = Session_CS.pmp_name.ToString();
            ReportDocument rd = new ReportDocument();
            string s = Server.MapPath("../Reports/Employees_Job_Category_Sticker.rpt");
            rd.Load(s);
            rd.SetDataSource(dt);
            Reports.Load_Report(rd);
            //rd.SetParameterValue(0, proj_id);
            //rd.SetParameterValue(1, dept_id);
            rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
            rd.SetParameterValue("@user", user, "footerRep.rpt");
            if (rd.Rows.Count == 0)
            {
                ShowAlertMessage("هذا التقرير لا يوجد به بيانات للعرض !!!!");
                return;
            }
            else
            {
                rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.WordForWindows, Response, true, "Report");
            }

            //}
            //else
            //{
            //    Label6.Visible = true;
            //    Label6.Text = "يجب اختيار المشروع لعرض هذا التقرير";
            //    return;
            //}
        }


         ///////////////////////////////////////////////Projects budgets status Report///////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        else if (hidden_Rpt_Id.Value == "projectbalance_status_report")
        {

            SqlConnection conn = new SqlConnection(sql_Connection);

            string sql = "select Project.Proj_id,Project.Proj_Title,Project.Balance_Suggest_Initial,Project.Balance_Suggest_Finial,Project.Balance_Suggest_Approved,Departments.Dept_ID,Departments.Dept_name from Project inner join Departments on Project.Dept_Dept_id=Departments.Dept_ID where 1=1 ";
            if (Smrt_Srch_DropDep.SelectedValue != "")
            {
                sql += " AND dbo.Departments.Dept_ID=" + Smrt_Srch_DropDep.SelectedValue;
            }
            if (Smart_Search_Proj.SelectedValue != "")
            {
                sql += " AND dbo.Project.Proj_id = " + Smart_Search_Proj.SelectedValue;
            }

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            ReportDocument rd = new ReportDocument();
            string user = Session_CS.pmp_name.ToString();
            string s = Server.MapPath("../Reports/balance_approvedstatus.rpt");
            rd.Load(s);
            rd.SetDataSource(dt);
            Reports.Load_Report(rd);
            rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
            rd.SetParameterValue("@user", user, "footerRep.rpt");
            if (rd.Rows.Count == 0)
            {
                ShowAlertMessage("!!!!!هذا التقرير لا يوجد به بيانات للعرض !!!!");
                return;
            }
            else
            {
                rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report");
            }


        }



        /////////////////////////////////////////////////////////// project activities Report ///////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        else if (hidden_Rpt_Id.Value == "ProjectActivities_Report")
        {
            if (Smart_Search_Proj.SelectedValue != "")
            {
                SqlConnection conn = new SqlConnection(sql_Connection);
                int projmanage = 0;
                int dept_id = 0;
                int proj_id = 0;
                decimal budget = 0;
                string proj_name = "";
                string ptem_name = "";
                string dept_name = "";
                if (Smart_Search_Proj.SelectedValue != "")
                {
                    proj_id = int.Parse(Smart_Search_Proj.SelectedValue);
                    budget = decimal.Parse(LabValue.Text);
                    proj_name = Smart_Search_Proj.Text_Field;
                    ptem_name = Labname.Text;
                    dept_name = LabDeptname.Text;

                }
                if (Smrt_Srch_projmanage.SelectedValue != "")
                {
                    projmanage = int.Parse(Smrt_Srch_projmanage.SelectedValue);
                }
                if (Smrt_Srch_DropDep.SelectedValue != "")
                {
                    dept_id = int.Parse(Smrt_Srch_DropDep.SelectedValue);
                }

                string user = Session_CS.pmp_name.ToString();

                string s = Server.MapPath("../Reports/PActivities_parameter.rpt");
                ReportDocument rd = new ReportDocument();
                rd.Load(s);
                Reports.Load_Report(rd);
                DataTable dt = new DataTable();

                dt = ActivLevls.leveling(proj_id, dept_id, projmanage, 0, 0);
                rd.SetDataSource(dt);
                rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
                rd.SetParameterValue("@user", user, "footerRep.rpt");
                if (dt.Rows.Count == 0)
                {
                    ShowAlertMessage("هذا التقرير لا يوجد به بيانات للعرض !!!!");
                    return;
                }
                else
                {
                    rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report");
                }

            }
            else
            {
                ShowAlertMessage("يجب اختيار مشروع لعرض هذا التقرير !!!!");
                return;
            }




        }

        /////////////////////////////////////////////////////////// project activities tryyyyyyyy Report ///////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        else if (hidden_Rpt_Id.Value == "ProjectActivitiestry_Report")
        {

            SqlConnection conn = new SqlConnection(sql_Connection);
            int proj_id = 0;

            DataTable dt_merge = new DataTable();
            DataTable dt = new DataTable();
            string Main_Query = get_data_for_projects();
            if (Smart_Search_Proj.SelectedValue != "")
                Main_Query += " and proj_id = " + Smart_Search_Proj.SelectedValue;

            DataTable dt_no_proj = General_Helping.GetDataTable(Main_Query);
            if (dt_no_proj.Rows.Count > 0)
            {

                for (int i = 0; i < dt_no_proj.Rows.Count; i++)
                {

                    proj_id = CDataConverter.ConvertToInt(dt_no_proj.Rows[i]["proj_id"].ToString());
                    //if (Drop_month.SelectedValue == "0" && Drop_year.SelectedValue == "0")
                    //{

                    dt = ActivLevls.leveling(proj_id, 0, 0, 0, 0);
                    //}
                    //else if (Drop_month.SelectedValue != "0" && Drop_year.SelectedValue != "0")
                    //{
                    //    dt = activitiesByMonth.getActivitiesByMonth(Drop_month.SelectedValue, Drop_year.SelectedValue, proj_id);
                    //}
                    //else
                    //{
                    //    ShowAlertMessage("يجب اختيار الشهر والسنة");
                    //    return;
                    //}
                    dt_merge.Merge(dt);
                }


            }



            string user = Session_CS.pmp_name.ToString();

            string s = Server.MapPath("../Reports/PActivities_parameter.rpt");
            ReportDocument rd = new ReportDocument();
            rd.Load(s);
            Reports.Load_Report(rd);
            //DataTable dt = new DataTable();

            //dt = ActivLevls.leveling(proj_id, dept_id, projmanage, 0, 0);
            rd.SetDataSource(dt_merge);
            rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
            rd.SetParameterValue("@user", user, "footerRep.rpt");
            if (dt_merge.Rows.Count == 0)
            {
                ShowAlertMessage("هذا التقرير لا يوجد به بيانات للعرض !!!!");
                return;
            }
            else
            {
                rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report");
            }





        }

        /////////////////////////////////////////////////////////// project Demands Report ///////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        else if (hidden_Rpt_Id.Value == "ProjectDocFiles_Report")
        {

            string t1 = "";
            string t2 = "";
            int dept_id = 0;


            string user = Session_CS.pmp_name.ToString();



            SqlConnection conn = new SqlConnection(sql_Connection);
            sql = "SELECT dbo.Departments_Documents.File_ext, SUM(DATALENGTH(dbo.Departments_Documents.File_data)) AS size, dbo.Project.Proj_Title, " +
                      "COUNT(dbo.Departments_Documents.File_ext) AS files, dbo.Departments.Dept_name, dbo.Departments.Dept_ID " +
                      "FROM dbo.Departments_Documents INNER JOIN " +
                      "dbo.Project ON dbo.Departments_Documents.Proj_Proj_id = dbo.Project.Proj_id INNER JOIN " +
                      "dbo.Departments ON dbo.Project.Dept_Dept_id = dbo.Departments.Dept_ID where 1=1";


            if (Smrt_Srch_DropDep.SelectedValue != "")
            {
                dept_id = int.Parse(Smrt_Srch_DropDep.SelectedValue);
                sql += " and dbo.Departments.Dept_ID=" + dept_id;

            }

            sql += " GROUP BY dbo.Departments_Documents.File_ext, dbo.Project.Proj_Title, dbo.Departments.Dept_name, dbo.Departments.Dept_ID ";
            sql += " ORDER BY dbo.Project.Proj_Title";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            ReportDocument rd = new ReportDocument();
            string s = Server.MapPath("../Reports/Documents_Sizes_report.rpt");
            rd.Load(s);

            rd.SetDataSource(dt);
            Reports.Load_Report(rd);
            rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
            rd.SetParameterValue("@user", user, "footerRep.rpt");
            //rd.SetParameterValue("@Dept_ID", dept_id);
            if (dt.Rows.Count == 0)
            {
                ShowAlertMessage("!!!!!هذا التقرير لا يوجد به بيانات للعرض !!!!");
                return;
            }
            else
            {
                rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report.rpt");
            }

        }
        /////////////////////////////////////////////////////////// project Demands Report ///////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        else if (hidden_Rpt_Id.Value == "ProjectDemands_Report")
        {

            string t1 = "";
            string t2 = "";
            int dept_id = 0;
            int proj_id = 0;


            string user = Session_CS.pmp_name.ToString();



            SqlConnection conn = new SqlConnection(sql_Connection);
            sql = "select pmp_name,need_Serial,Pned_name,approved_amount,PNed_Number,PNed_ID,convert(datetime,dbo.datevalid(dbo.project_needs.PNed_Date)) as PNed_Date ,";
            sql += " Proj_Title,Proj_id,TotalDelievered,Dept_id,Dept_name ";
            sql += " from ";
            sql += " project_needs join Project on project_needs.Proj_proj_id = project.Proj_id  ";
            sql += " inner join employee on Project.pmp_pmp_id = EMPLOYEE.PMP_ID   ";
            sql += " inner join Departments on Project.Dept_Dept_id = Departments.Dept_id  ";
            sql += " where 1=1 ";
            if (Request.QueryString["type"] == "1")
            {
                if (Smrt_Srch_DropDep.SelectedValue != "")
                {
                    dept_id = int.Parse(Smrt_Srch_DropDep.SelectedValue);
                    sql += " AND Departments.Dept_id = " + dept_id;
                }
            }
            else
            {
                if (Smart_Search_Proj.SelectedValue != "")
                {
                    proj_id = int.Parse(Smart_Search_Proj.SelectedValue);
                    sql += " AND project.Proj_id = " + proj_id;
                }
                else
                {
                    ShowAlertMessage("!!!!!يجب اختيار مشروع لعرض التقرير !!!!");
                    return;
                }
            }

            if (string.IsNullOrEmpty(TextBox1.Text) && string.IsNullOrEmpty(TextBox2.Text))
            {

                t1 = "01/01/1900";
                t2 = CDataConverter.ConvertDateTimeToFormatdmy(DateTime.MaxValue); 
                //sql += " AND convert(datetime,dbo.datevalid(dbo.project_needs.PNed_Date)) > = '" + t1.ToString() + "'";
                //sql += " AND convert(datetime,dbo.datevalid(dbo.project_needs.PNed_Date)) < = '" + t2.ToString() + "'";
            }
            else if (string.IsNullOrEmpty(TextBox1.Text))
            {
                if (VB_Classes.Dates.Dates_Operation.date_validate(TextBox2.Text.Trim()) != "")
                {
                    t1 = "01/01/1900";
                    //t2 = DateTime.ParseExact(Inbox_date_to.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
                    t2 = VB_Classes.Dates.Dates_Operation.date_validate(TextBox2.Text.Trim());
                    sql += " AND convert(datetime,dbo.datevalid(dbo.project_needs.PNed_Date)) < = '" + t2.ToString() + "'";
                }
                else
                {
                    ShowAlertMessage("!!!!!ادخل التاريخ بطريقة صحيحة !!!!");
                    return;
                }

            }
            else if (string.IsNullOrEmpty(TextBox2.Text))
            {

                if (VB_Classes.Dates.Dates_Operation.date_validate(TextBox1.Text.Trim()) != "")
                {
                    //t1 = DateTime.ParseExact(Inbox_date_from.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
                    t2 = CDataConverter.ConvertDateTimeToFormatdmy(DateTime.MaxValue); 
                    t1 = VB_Classes.Dates.Dates_Operation.date_validate(TextBox1.Text.Trim());
                    sql += " AND convert(datetime,dbo.datevalid(dbo.project_needs.PNed_Date)) > = '" + t1.ToString() + "'";

                }
                else
                {
                    ShowAlertMessage("!!!!!ادخل التاريخ بطريقة صحيحة !!!!");
                    return;
                }

            }

            else
            {
                if (VB_Classes.Dates.Dates_Operation.date_validate(TextBox2.Text.Trim()) != "" && VB_Classes.Dates.Dates_Operation.date_validate(TextBox1.Text.Trim()) != "")
                {
                    //t1 = DateTime.ParseExact(Inbox_date_from.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
                    t2 = VB_Classes.Dates.Dates_Operation.date_validate(TextBox2.Text.Trim());
                    //t2 = DateTime.ParseExact(Inbox_date_to.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
                    t1 = VB_Classes.Dates.Dates_Operation.date_validate(TextBox1.Text.Trim());
                    sql += " AND convert(datetime,dbo.datevalid(dbo.project_needs.PNed_Date)) > = '" + t1.ToString() + "'";
                    sql += " AND convert(datetime,dbo.datevalid(dbo.project_needs.PNed_Date)) < = '" + t2.ToString() + "'";
                }
                else
                {
                    ShowAlertMessage("!!!!!ادخل التاريخ بطريقة صحيحة !!!!");
                    return;
                }


            }
            DateTime date1 = CDataConverter.ConvertToDate(t1);
            DateTime date2 = CDataConverter.ConvertToDate(t2); 
            if (date2.Subtract(date1).Days < 0)
            {
                ShowAlertMessage("!!!!!التاريخ الأول يجب ان يكون قبل التاريخ الثاني !!!!");
                return;
            }
            sql += "order by Proj_Title, pmp_name,need_Serial ";

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            ReportDocument rd = new ReportDocument();
            string s = Server.MapPath("../Reports/PDemands_Approve.rpt");
            rd.Load(s);
            rd.SetDataSource(dt);
            //rd.SetParameterValue("@Dept_id", dept_id);
            rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
            rd.SetParameterValue("@user", user, "footerRep.rpt");
            if (dt.Rows.Count == 0)
            {

                ShowAlertMessage("!!!!!هذا التقرير لا يوجد به بيانات للعرض !!!!");
                return;

            }
            else
            {


                rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report.rpt");


            }

        }
        /////////////////////////////////////////////////////////// project Demands Report arranged by requested date ///////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        else if (hidden_Rpt_Id.Value == "ProjectDemands_ReqDate_Report")
        {

            string t1 = "";
            string t2 = "";
            int dept_id = 0;
            int proj_id = 0;

            string user = Session_CS.pmp_name.ToString();



            SqlConnection conn = new SqlConnection(sql_Connection);
            sql = " set dateformat dmy select pmp_name,need_Serial,Pned_name,approved_amount,PNed_Number,PNed_ID,convert(datetime,dbo.datevalid(dbo.project_needs.PNed_Date)) as PNed_Date ,convert(datetime,dbo.datevalid(dbo.project_needs.Request_DT)) as Request_DT ,";
            sql += " Proj_Title,Proj_id,TotalDelievered,Dept_id,Dept_name ";
            sql += " from ";
            sql += " project_needs join Project on project_needs.Proj_proj_id = project.Proj_id  ";
            sql += " inner join employee on Project.pmp_pmp_id = EMPLOYEE.PMP_ID   ";
            sql += " inner join Departments on Project.Dept_Dept_id = Departments.Dept_id  ";
            sql += " where 1=1 ";
            if (Request.QueryString["type"] == "1")
            {
                if (Smrt_Srch_DropDep.SelectedValue != "")
                {
                    dept_id = int.Parse(Smrt_Srch_DropDep.SelectedValue);
                    sql += " AND Departments.Dept_id = " + dept_id;
                }
            }
            else
            {
                if (Smart_Search_Proj.SelectedValue != "")
                {
                    proj_id = int.Parse(Smart_Search_Proj.SelectedValue);
                    sql += " AND project.Proj_id = " + proj_id;
                }
                else
                {
                    ShowAlertMessage("!!!!!يجب اختيار مشروع لعرض التقرير !!!!");
                    return;
                }
            }
            if (string.IsNullOrEmpty(TextBox1.Text) && string.IsNullOrEmpty(TextBox2.Text))
            {

                t1 = "01/01/1900";
                t2 = CDataConverter.ConvertDateTimeToFormatdmy(DateTime.MaxValue); 
                //sql += " AND convert(datetime,dbo.datevalid(dbo.project_needs.PNed_Date)) > = '" + t1.ToString() + "'";
                //sql += " AND convert(datetime,dbo.datevalid(dbo.project_needs.PNed_Date)) < = '" + t2.ToString() + "'";
            }
            else if (string.IsNullOrEmpty(TextBox1.Text))
            {
                if (VB_Classes.Dates.Dates_Operation.date_validate(TextBox2.Text.Trim()) != "")
                {
                    t1 = "01/01/1900";
                    //t2 = DateTime.ParseExact(Inbox_date_to.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
                    t2 = VB_Classes.Dates.Dates_Operation.date_validate(TextBox2.Text.Trim());
                    sql += " AND convert(datetime,dbo.datevalid(dbo.project_needs.Request_DT)) < = '" + t2.ToString() + "'";
                }
                else
                {
                    ShowAlertMessage("!!!!!ادخل التاريخ بطريقة صحيحة !!!!");
                    return;
                }

            }
            else if (string.IsNullOrEmpty(TextBox2.Text))
            {

                if (VB_Classes.Dates.Dates_Operation.date_validate(TextBox1.Text.Trim()) != "")
                {
                    //t1 = DateTime.ParseExact(Inbox_date_from.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
                    t2 = CDataConverter.ConvertDateTimeToFormatdmy(DateTime.MaxValue);
                    t1 = VB_Classes.Dates.Dates_Operation.date_validate(TextBox1.Text.Trim());
                    sql += " AND convert(datetime,dbo.datevalid(dbo.project_needs.Request_DT)) > = '" + t1.ToString() + "'";

                }
                else
                {
                    ShowAlertMessage("!!!!!ادخل التاريخ بطريقة صحيحة !!!!");
                    return;
                }

            }

            else
            {
                if (VB_Classes.Dates.Dates_Operation.date_validate(TextBox2.Text.Trim()) != "" && VB_Classes.Dates.Dates_Operation.date_validate(TextBox1.Text.Trim()) != "")
                {
                    //t1 = DateTime.ParseExact(Inbox_date_from.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
                    t2 = VB_Classes.Dates.Dates_Operation.date_validate(TextBox2.Text.Trim());
                    //t2 = DateTime.ParseExact(Inbox_date_to.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
                    t1 = VB_Classes.Dates.Dates_Operation.date_validate(TextBox1.Text.Trim());
                    sql += " AND convert(datetime,dbo.datevalid(dbo.project_needs.Request_DT)) > = '" + t1.ToString() + "'";
                    sql += " AND convert(datetime,dbo.datevalid(dbo.project_needs.Request_DT)) < = '" + t2.ToString() + "'";
                }
                else
                {
                    ShowAlertMessage("!!!!!ادخل التاريخ بطريقة صحيحة !!!!");
                    return;
                }


            }
            DateTime date1 = CDataConverter.ConvertToDate(t1);
            DateTime date2 = CDataConverter.ConvertToDate(t2); 
            if (date2.Subtract(date1).Days < 0)
            {
                ShowAlertMessage("!!!!!التاريخ الأول يجب ان يكون قبل التاريخ الثاني !!!!");
                return;
            }
            sql += "order by Proj_Title, pmp_name,need_Serial ";

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            ReportDocument rd = new ReportDocument();
            string s = Server.MapPath("../Reports/PDemands_Approve_Req_Date.rpt");
            rd.Load(s);
            rd.SetDataSource(dt);
            //rd.SetParameterValue("@Dept_id", dept_id);
            rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
            rd.SetParameterValue("@user", user, "footerRep.rpt");
            if (dt.Rows.Count == 0)
            {

                ShowAlertMessage("!!!!!هذا التقرير لا يوجد به بيانات للعرض !!!!");
                return;

            }
            else
            {


                rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report.rpt");


            }

        }
        ///////////////////////////////////////////////budget source report///////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        else if (hidden_Rpt_Id.Value == "Budget_Per_Year_Report")
        {

            string t1 = "";
            string t2 = "";
            int dept_id = 0;


            string user = Session_CS.pmp_name.ToString();


            if (Drop_balance.SelectedValue != "0")
            {
                SqlConnection conn = new SqlConnection(sql_Connection);
                //sql = "SELECT DISTINCT View_firstpart.Dept_name, View_firstpart.Dept_ID, SUM(View_firstpart.Summation) AS Summation, View_firstpart.Sources_ID, View_firstpart.Source_Name, try_View.[مجموع المكافأت], try_View.[مجموع الانتقالات], try_View.[مجموع المستلزمات], try_View.[مجموع حجز الفنادق], try_View.[مجموع التدريب], try_View.[مجموع التطبيقات], try_View.[مجموع المناقصات], try_View.[(مجموع موارد (أجهزة ومعدات], try_View.[مجموع الاتصالات], try_View.[مجموع أعمال هندسية], try_View.[مجموع اعادة الاستثمار], try_View.[مجموع الرخص] FROM View_firstpart INNER JOIN try_View ON View_firstpart.Sources_ID = try_View.Sources_ID AND View_firstpart.Dept_ID = try_View.Dept_ID LEFT OUTER JOIN date_view ON View_firstpart.Sources_ID = date_view.Sources_ID";
                //sql += " where View_firstpart.Strt_Date > = '01" + "/07" + "/" + int.Parse(Drop_balance.Text.Substring(5,4)) + "'";
                //sql += " and  View_firstpart.End_Date < = '30" + "/06" + "/" + (int.Parse(Drop_balance.Text.Substring(5,4)) + 1) + "'";
                //sql += " and convert(datetime,date_view.pned_date,103)>convert(datetime,View_firstpart.Strt_Date,103)";
                //sql += " and convert(datetime,date_view.pned_date,103)<convert(datetime,View_firstpart.End_Date,103)"; 
                sql = "set dateformat dmy SELECT DISTINCT Summation_Sources_View.Dept_name, Summation_Sources_View.Dept_ID, Summation_Sources_View.Summation,Summation_Sources_View.Sources_ID, Summation_Sources_View.Source_Name,  sum (try_View.[مجموع المكافأت]) as 'مجموع المكافأت', sum( try_View.[مجموع الانتقالات]) as 'مجموع الانتقالات' ,sum (try_View.[مجموع المستلزمات]) as 'مجموع المستلزمات' , sum ( try_View.[مجموع حجز الفنادق]) as 'مجموع حجز الفنادق',  sum (try_View.[مجموع التدريب]) as 'مجموع التدريب' ,  sum (try_View.[مجموع التطبيقات]) as 'مجموع التطبيقات' ,sum (try_View.[مجموع المناقصات]) as 'مجموع المناقصات' ,  sum (try_View.[(مجموع موارد (أجهزة ومعدات]) as '(مجموع موارد (أجهزة ومعدات',  sum (try_View.[مجموع الاتصالات]) as 'مجموع الاتصالات' , sum (try_View.[مجموع أعمال هندسية]) as 'مجموع أعمال هندسية' , sum(try_View.[مجموع اعادة الاستثمار]) as 'مجموع اعادة الاستثمار' ,sum ( try_View.[مجموع الرخص]) as 'مجموع الرخص'  FROM Summation_Sources_View left outer JOIN try_View ON Summation_Sources_View.Sources_ID =  try_View.Sources_ID AND Summation_Sources_View.Dept_ID = try_View.Dept_ID   ";
                sql += " where Summation_Sources_View.Quarter_Year = " + int.Parse(Drop_balance.Text.Substring(5, 4));
                if (Smrt_Srch_DropDep.SelectedValue != "")
                {
                    dept_id = int.Parse(Smrt_Srch_DropDep.SelectedValue);
                    sql += " AND Summation_Sources_View.Dept_ID = " + dept_id;
                }

                sql += "  and try_view.Year = " + int.Parse(Drop_balance.Text.Substring(5, 4));
                //sql += " and convert(datetime,dbo.datevalid(date_view.pned_date))>= '01" + "/07" + "/" + int.Parse(Drop_balance.Text.Substring(5, 4)) + "'";
                //sql += " and  convert(datetime,dbo.datevalid(date_view.pned_date))<= '30" + "/06" + "/" + (int.Parse(Drop_balance.Text.Substring(5, 4)) + 1) + "'";
                //sql += " and convert(datetime,dbo.datevalid(try_view.pned_date))>= '01" + "/07" + "/" + int.Parse(Drop_balance.Text.Substring(5, 4)) + "'";
                //sql += " and  convert(datetime,dbo.datevalid(try_view.pned_date))<= '30" + "/06" + "/" + (int.Parse(Drop_balance.Text.Substring(5, 4)) + 1) + "'";

                sql += " GROUP BY Summation_Sources_View.Source_Name, Summation_Sources_View.Dept_ID, Summation_Sources_View.Dept_name,Summation_Sources_View.Summation, Summation_Sources_View.Sources_ID   ORDER BY Summation_Sources_View.Dept_ID,sources_id asc   ";






                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                ReportDocument rd = new ReportDocument();
                string s = Server.MapPath("../Reports/balance_per_years.rpt");
                rd.Load(s);
                rd.SetDataSource(dt);
                rd.SetParameterValue("@Year1", int.Parse(Drop_balance.Text.Substring(5, 4)));
                rd.SetParameterValue("@Year2", (int.Parse(Drop_balance.Text.Substring(5, 4)) + 1));
                //rd.SetParameterValue("@Dept_ID", dept_id);
                rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
                rd.SetParameterValue("@user", user, "footerRep.rpt");
                if (dt.Rows.Count == 0)
                {

                    ShowAlertMessage("!!!!!هذا التقرير لا يوجد به بيانات للعرض !!!!");
                    return;

                }
                else
                {

                    rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report.rpt");
                }

            }
            else
            {
                ShowAlertMessage("!!!!!يجب اختيار السنة المالية المطلوبة !!!!");
                return;
            }

        }
        /////////////////////////////////////////////////////////////  المناقصات المفتوحة
        else if (hidden_Rpt_Id.Value == "Tender_Report")
        {
            //int dept_id = 0;


            //if (TextBox3.Text == "")
            //{
            //    Label6.Visible = true;
            //    Label6.Text = " يجب اختيار التاريخ أولاّ";
            //}
            //else if (TextBox4.Text == "")
            //{
            //    Label6.Visible = true;
            //    Label6.Text = " يجب اختيار التاريخ أولاّ";

            //}
            if (Drop_balance.SelectedValue != "0")
            {


                //SqlConnection conn = new SqlConnection(sql_Connection);
                //sql = " SELECT Project.Proj_id, Project.Proj_Title, Departments.Dept_name,Departments.Dept_id,Fin_Bills.Work_Order_ID, Project_Team.PTem_Name, Fin_Tender.Name, Fin_Work_Order.Tender_NO,Fin_Work_Order.Tender_Year, Fin_Work_Order.Code, substring(Fin_Work_Order.Date,7,4) as date, Fin_Work_Order.Work_Total_Value, Fin_Company.Company_Name,sum(Fin_Bills.Bil_Value) as Fin_Bills_Bil_Value FROM Fin_Company INNER JOIN Fin_Work_Order ON Fin_Company.Company_ID = Fin_Work_Order.Company_ID INNER JOIN Fin_Bills ON Fin_Work_Order.Work_Order_ID = Fin_Bills.Work_Order_ID INNER JOIN Fin_Tender ON Fin_Work_Order.Tender_Type_ID = Fin_Tender.ID INNER JOIN Departments INNER JOIN Project ON Departments.Dept_ID = Project.Dept_Dept_id INNER JOIN Project_Team ON Project.Proj_id = Project_Team.proj_proj_id ON Fin_Work_Order.Project_ID = Project.Proj_id ";
                //sql += " WHERE (Project_Team.rol_rol_id = 4) ";



                //sql += " and  convert(datetime,dbo.datevalid(dbo.Fin_Bills.Date)) > = '01" + "/07" + "/" + int.Parse(Drop_balance.Text.Substring(5, 4)) + "'";
                //sql += " and  convert(datetime,dbo.datevalid(dbo.Fin_Bills.Date)) < ='30" + "/06" + "/" + (int.Parse(Drop_balance.Text.Substring(5, 4)) + 1) + "'";


                //if (Smrt_Srch_DropDep.SelectedValue != "")
                //{
                //    sql += " and Departments.Dept_ID =" + Smrt_Srch_DropDep.SelectedValue;
                //}
                //if (Smart_Search_Proj.SelectedValue != "")
                //{
                //    sql += " and  Project.Proj_id =" + Smart_Search_Proj.SelectedValue;
                //}

                //if (Smrt_Srch_projmanage.SelectedValue != "")
                //{
                //    sql += " and  Project_Team.pmp_pmp_id =" + Smrt_Srch_projmanage.SelectedValue;
                //}

                //sql += " group by Project.Proj_id, Project.Proj_Title, Departments.Dept_name, Project_Team.PTem_Name, Fin_Tender.Name, Fin_Work_Order.Tender_NO,   Fin_Work_Order.Tender_Year, Fin_Work_Order.Code, Fin_Work_Order.Date, Fin_Work_Order.Work_Total_Value, Fin_Company.Company_Name,Fin_Bills.Work_Order_ID,Departments.Dept_id ";





                //conn.Open();

                //SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                //DataTable dt = new DataTable();
                //da.Fill(dt);
                //if (dt.Rows.Count == 0)
                //{

                //    ShowAlertMessage("!!!!!هذا التقرير لا يوجد به بيانات للعرض !!!!");
                //    return;

                //}
                //else
                //{

                ReportDocument rd = new ReportDocument();
                string user = Session_CS.pmp_name.ToString();
                //if (Smrt_Srch_DropDep.SelectedValue != "")
                //{
                //    dept_id = int.Parse(Smrt_Srch_DropDep.SelectedValue);
                //}
                //string s = Server.MapPath("../Reports/Copy of Tender.rpt");
                string s = Server.MapPath("../Reports/Tender_work_order.rpt");
                rd.Load(s);
                //rd.SetDataSource(dt);

                rd.SetParameterValue("@Strt_DT", int.Parse(Drop_balance.Text.Substring(5, 4)));
                rd.SetParameterValue("@End_DT", (int.Parse(Drop_balance.Text.Substring(5, 4)) + 1));

                rd.SetParameterValue("@Dept_ID", CDataConverter.ConvertToInt(Smrt_Srch_DropDep.SelectedValue));

                //rd.SetParameterValue("@Dept_ID", dept_id);
                rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
                rd.SetParameterValue("@user", user, "footerRep.rpt");
                Reports.Load_Report(rd);
                if (rd.Rows.Count == 0)
                {
                    ShowAlertMessage("!!!!!هذا التقرير لا يوجد به بيانات للعرض !!!!");
                    return;
                }
                rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report");
                // conn.Close();
            }

           // }
            else
            {
                ShowAlertMessage("!!!!!يجب اختيار السنة المالية المطلوبة !!!!");
                return;
            }

        }
        //////////////////////////////////////////////////////////////// budget recieve //////////////////////////////////////////

        //else if (hidden_Rpt_Id.Value == "dismissal_Report")
        //{

        //    string t1 = "";
        //    string t2 = "";
        //    int dept_id = 0;


        //    string user = Session_CS.pmp_name.ToString();


        //    if (Drop_balance.SelectedValue != "0")
        //    {
        //        SqlConnection conn = new SqlConnection(sql_Connection);
        //        //sql = "SELECT View_firstpart.Dept_name,View_firstpart.Dept_ID,View_firstpart.Summation AS Summation,Right_Recieve_View.[يناير],Right_Recieve_View.[فبراير],Right_Recieve_View.[مارس],  Right_Recieve_View.[أبريل], Right_Recieve_View.[مايو], Right_Recieve_View.[يونيو],Right_Recieve_View.[يوليو], Right_Recieve_View.[أغسطس],  Right_Recieve_View.[سبتمبر], Right_Recieve_View.[أكتوبر], Right_Recieve_View.[نوفمبر], Right_Recieve_View.[ديسمبر],View_firstpart.Sources_ID, View_firstpart.Source_Name FROM View_firstpart full outer JOIN Right_Recieve_View ON View_firstpart.Dept_ID = Right_Recieve_View.Dept_ID full outer join date_Recieve_View on Right_Recieve_View.sources_id=date_Recieve_View.sources_id AND View_firstpart.Sources_ID = Right_Recieve_View.Sources_ID";               
        //        //sql += " where View_firstpart.Strt_Date='01" + "/07" + "/" + int.Parse(Drop_balance.Text.Substring(5, 4)) + "'";
        //        //sql += " and  View_firstpart.End_Date='30" + "/06" + "/" + (int.Parse(Drop_balance.Text.Substring(5, 4)) + 1) + "'";
        //        //sql += " and convert(datetime,date_Recieve_View.recieved_amount_date,103)>convert(datetime,View_firstpart.Strt_Date,103)";
        //        //sql += " and convert(datetime,date_Recieve_View.recieved_amount_date,103)<convert(datetime,View_firstpart.End_Date,103)";
        //        sql = "set dateformat dmy SELECT     Year, Source_ID, Source_Name, Dept_name, Dept_ID,Quarter_Year,Summation, SUM(يناير) AS 'يناير', SUM(فبراير) AS 'فبراير', SUM(مارس) AS 'مارس', SUM(أبريل) AS 'أبريل', SUM(مايو) AS 'مايو',                       SUM(يونيو) AS 'يونيو', SUM(يوليو) AS 'يوليو', SUM(أغسطس) AS 'أغسطس', SUM(سبتمبر) AS 'سبتمبر', SUM(أكتوبر) AS 'أكتوبر', SUM(نوفمبر) AS 'نوفمبر', SUM(ديسمبر) AS 'ديسمبر'  FROM         dbo.Financial_Bills_Recieved_Union ";
        //        sql += " where Year = " + int.Parse(Drop_balance.Text.Substring(5, 4));
        //        sql += " and Quarter_Year = " + int.Parse(Drop_balance.Text.Substring(5, 4));
        //        if (Smrt_Srch_DropDep.SelectedValue != "")
        //        {
        //            dept_id = int.Parse(Smrt_Srch_DropDep.SelectedValue);
        //            sql += " AND Dept_ID = " + dept_id;
        //        }

        //        //sql += " and (";
        //        //sql += "  convert(datetime,dbo.datevalid(date_Recieve_View.recieved_amount_date))>= '01" + "/07" + "/" + int.Parse(Drop_balance.Text.Substring(5, 4)) + "'";
        //        //sql += " and  convert(datetime,dbo.datevalid(date_Recieve_View.recieved_amount_date))<= '30" + "/06" + "/" + (int.Parse(Drop_balance.Text.Substring(5, 4)) + 1) + "'";
        //        //sql += "  and convert(datetime,dbo.datevalid(Right_Recieve_View.recieved_amount_date))>= '01" + "/07" + "/" + int.Parse(Drop_balance.Text.Substring(5, 4)) + "'";
        //        //sql += " and  convert(datetime,dbo.datevalid(Right_Recieve_View.recieved_amount_date))<= '30" + "/06" + "/" + (int.Parse(Drop_balance.Text.Substring(5, 4)) + 1) + "'";
        //        //sql += " or convert(datetime,dbo.datevalid(Fin_Bill_view_By_source.Date))>= '01" + "/07" + "/" + int.Parse(Drop_balance.Text.Substring(5, 4)) + "'";
        //        //sql += " and  convert(datetime,dbo.datevalid(Fin_Bill_view_By_source.Date))<= '30" + "/06" + "/" + (int.Parse(Drop_balance.Text.Substring(5, 4)) + 1) + "'";

        //        //sql += "  or date_Recieve_View.recieved_amount_date is null )";

        //        sql += " GROUP BY Year, Source_ID, Source_Name, Dept_name, Dept_ID,Quarter_Year,Summation ORDER BY Dept_ID DESC ";
        //        //sql += " order by dept_id desc ";



        //        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        //        DataTable dt = new DataTable();
        //        da.Fill(dt);
        //        ReportDocument rd = new ReportDocument();
        //        string s = Server.MapPath("../Reports/balance_Recieve_per_years.rpt");
        //        rd.Load(s);
        //        rd.SetDataSource(dt);
        //        rd.SetParameterValue("@Year1", int.Parse(Drop_balance.Text.Substring(5, 4)));
        //        rd.SetParameterValue("@Year2", (int.Parse(Drop_balance.Text.Substring(5, 4)) + 1));
        //        //rd.SetParameterValue("@Dept_ID", dept_id);
        //        rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
        //        rd.SetParameterValue("@user", user, "footerRep.rpt");
        //        if (dt.Rows.Count == 0)
        //        {

        //            ShowAlertMessage("!!!!!هذا التقرير لا يوجد به بيانات للعرض !!!!");
        //            return;

        //        }
        //        else
        //        {

        //            rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report.rpt");
        //        }

        //    }
        //    else
        //    {
        //        ShowAlertMessage("!!!!!يجب اختيار السنة المالية المطلوبة !!!!");
        //        return;
        //    }

        //}

            //////////////////////////////////////////////////////////////// total spent per year  //////////////////////////////////////////

        else if (hidden_Rpt_Id.Value == "total_spent_per_year_Report")
        {

            string t1 = "";
            string t2 = "";
            int dept_id = 0;


            string user = Session_CS.pmp_name.ToString();


            if (Drop_balance.SelectedValue != "0")
            {
                SqlConnection conn = new SqlConnection(sql_Connection);

                sql = "set dateformat dmy SELECT    * from Financial_Bills_Recieved_All_Union_Report ";
                sql += " where Quarter_Year = " + int.Parse(Drop_balance.Text.Substring(5, 4));
                if (Smrt_Srch_DropDep.SelectedValue != "")
                {
                    dept_id = int.Parse(Smrt_Srch_DropDep.SelectedValue);
                    sql += " AND Dept_ID = " + dept_id;
                }


                sql += " order by proj_id,source_id ";




                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                ReportDocument rd = new ReportDocument();
                string s = Server.MapPath("../Reports/Total_spent_per_year.rpt");
                rd.Load(s);
                rd.SetDataSource(dt);
                rd.SetParameterValue("@Year1", int.Parse(Drop_balance.Text.Substring(5, 4)));
                rd.SetParameterValue("@Year2", (int.Parse(Drop_balance.Text.Substring(5, 4)) + 1));

                rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
                rd.SetParameterValue("@user", user, "footerRep.rpt");
                if (dt.Rows.Count == 0)
                {

                    ShowAlertMessage("!!!!!هذا التقرير لا يوجد به بيانات للعرض !!!!");
                    return;

                }
                else
                {

                    rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report.rpt");
                }

            }
            else
            {
                ShowAlertMessage("!!!!!يجب اختيار السنة المالية المطلوبة !!!!");
                return;
            }

        }
        /////////////////////////////////////////////////////////// Project Follow Up Report ///////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        else if (hidden_Rpt_Id.Value == "ProjectsFollowUP_Report")
        {
            if (Smart_Search_Proj.SelectedValue != "")
            {
                SqlConnection conn = new SqlConnection(sql_Connection);

                int proj_id = 0;
                int projmanage = 0;
                int dept_id = 0;
                decimal budget = 0;
                string proj_name = "";
                string ptem_name = "";
                string dept_name = "";
                if (Smart_Search_Proj.SelectedValue != "")
                {
                    proj_id = int.Parse(Smart_Search_Proj.SelectedValue);
                    budget = decimal.Parse(LabValue.Text);
                    proj_name = Smart_Search_Proj.Text_Field;
                    ptem_name = Labname.Text;
                    dept_name = LabDeptname.Text;

                }
                if (Smrt_Srch_projmanage.SelectedValue != "")
                {
                    projmanage = int.Parse(Smrt_Srch_projmanage.SelectedValue);
                }
                if (Smrt_Srch_DropDep.SelectedValue != "")
                {
                    dept_id = int.Parse(Smrt_Srch_DropDep.SelectedValue);
                }

                string user = Session_CS.pmp_name.ToString();
                ReportDocument rd = new ReportDocument();
                string s = Server.MapPath("../Reports/Project_Follow_Report.rpt");
                rd.Load(s);
                Reports.Load_Report(rd);
                DataTable dt = new DataTable();

                dt = ActivLevls.leveling(proj_id, dept_id, projmanage, 1, 0);
                rd.SetDataSource(dt);


                rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
                rd.SetParameterValue("@user", user, "footerRep.rpt");
                if (dt.Rows.Count == 0)
                {
                    ShowAlertMessage("!!!!!هذا التقرير لا يوجد به بيانات للعرض !!!!");
                    return;
                }
                else
                {
                    rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report");
                }

            }
            else
            {
                ShowAlertMessage("!!!!!يجب إختيار مشروع لعرض التقرير !!!!");
                return;
            }



        }
        /////////////////////////////////////////////////////////// Project Follow try Up Report ///////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        else if (hidden_Rpt_Id.Value == "ProjectsFollowUPtry_Report")
        {
            SqlConnection conn = new SqlConnection(sql_Connection);
            int proj_id = 0;
            if (Drop_month.SelectedValue != "0")
            {

                DataTable dt_merge = new DataTable();
                DataTable dt = new DataTable();
                string Main_Query = get_data_for_projects();
                if (Smart_Search_Proj.SelectedValue != "")
                    Main_Query += " and proj_id = " + Smart_Search_Proj.SelectedValue;

                DataTable dt_no_proj = General_Helping.GetDataTable(Main_Query);
                if (dt_no_proj.Rows.Count > 0)
                {

                    for (int i = 0; i < dt_no_proj.Rows.Count; i++)
                    {

                        proj_id = CDataConverter.ConvertToInt(dt_no_proj.Rows[i]["proj_id"].ToString());
                        //if (Drop_month.SelectedValue == "0" && Drop_year.SelectedValue == "0")
                        //{

                        dt = ActivLevls.leveling_For_Activities_Station(proj_id, CDataConverter.ConvertToInt(Drop_month.SelectedValue));
                        //}
                        //else if (Drop_month.SelectedValue != "0" && Drop_year.SelectedValue != "0")
                        //{
                        //    dt = activitiesByMonth.getActivitiesByMonth(Drop_month.SelectedValue, Drop_year.SelectedValue, proj_id);
                        //}
                        //else
                        //{
                        //    ShowAlertMessage("يجب اختيار الشهر والسنة");
                        //    return;
                        //}
                        dt_merge.Merge(dt);
                    }


                }



                string user = Session_CS.pmp_name.ToString();

                string s = Server.MapPath("../Reports/Project_Activ_stations.rpt");
                ReportDocument rd = new ReportDocument();
                rd.Load(s);
                Reports.Load_Report(rd);
                //DataTable dt = new DataTable();

                //dt = ActivLevls.leveling(proj_id, dept_id, projmanage, 0, 0);
                rd.SetDataSource(dt_merge);
                rd.SetParameterValue("@note", Drop_month.SelectedItem.Text);
                rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
                rd.SetParameterValue("@user", user, "footerRep.rpt");
                if (dt_merge.Rows.Count == 0)
                {
                    ShowAlertMessage("هذا التقرير لا يوجد به بيانات للعرض !!!!");
                    return;
                }
                else
                {
                    rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report");
                }
            }
            else
            {
                ShowAlertMessage("يجب اختيار الشهر ");
                return;
            }





        }
        else if (hidden_Rpt_Id.Value == "needhighinter_Report")
        {
            SqlConnection conn = new SqlConnection(sql_Connection);

            int proj_id = 0;
            int projmanage = 0;
            int dept_id = 0;
            decimal budget = 0;
            string proj_name = "";
            string ptem_name = "";
            string dept_name = "";

            //sql = "SELECT dbo.Project_Activities.PActv_Desc, dbo.Project_Activities.Parent_PActv_Desc, dbo.Project.Proj_id, dbo.Project.Proj_Title, dbo.Departments.Dept_name,dbo.Departments.Dept_ID, dbo.Project_Team.PTem_Name, dbo.Project_Team.pmp_pmp_id, dbo.Project_Team.rol_rol_id,dbo.Project_Constraints.PCONS_IS_CRITICAL, dbo.Project.Proj_InitValue, dbo.Project_Activities.PActv_Start_Date, dbo.Project_Activities.PActv_End_Date,dbo.Project_Activities.PActv_Actual_End_Date, dbo.Project_Constraints.PCONS_DESC, dbo.Project_Constraints.PCONS_Sugg_Solutions,dbo.Project_Activities.PActv_wieght, dbo.Project_Activities.PActv_Implementing_Location, dbo.Activity_sitiuation.actv_sit_desc ";
            //sql += " FROM dbo.Departments INNER JOIN dbo.Project ON dbo.Departments.Dept_ID = dbo.Project.Dept_Dept_id INNER JOIN dbo.Project_Activities ON dbo.Project.Proj_id = dbo.Project_Activities.proj_proj_id INNER JOIN dbo.Project_Constraints ON dbo.Project_Activities.PActv_ID = dbo.Project_Constraints.PActv_PActv_ID INNER JOIN dbo.Project_Team ON dbo.Project.Proj_id = dbo.Project_Team.proj_proj_id INNER JOIN dbo.Activity_sitiuation ON dbo.Project_Activities.PActv_ID = dbo.Activity_sitiuation.project_activity_FK ";
            //sql += " WHERE(dbo.Project_Team.rol_rol_id = 4) AND (dbo.Project_Constraints.PCONS_IS_CRITICAL = 1)";
            sql = "select * ,(Case When PActv_Parent=0 Then PActv_Desc Else null End)as parent,(Case When PActv_Parent=0 Then 0 Else null End) as Parent_Actv_Num,PActv_Parent as LVL from Project_Activities full OUTER JOIN dbo.Project_Constraints ON dbo.Project_Activities.PActv_ID = dbo.Project_Constraints.PActv_PActv_ID  full OUTER join project on Project_Activities.proj_proj_id=project.proj_id full OUTER join Departments on project.Dept_Dept_id=Departments.Dept_ID full OUTER join Active_Satatus on Project_Activities.ActStat_ActStat_id=Active_Satatus.ActStat_ID full OUTER join Project_Activities_Indicators on Project_Activities.PActv_ID=Project_Activities_Indicators.pactv_pactv_id full OUTER join Indicators_Type on Project_Activities_Indicators.indt_indt_id=Indicators_Type.IndT_id full OUTER join Project_Activity_indicator_period on Project_Activities_Indicators.PAIP_period_id=Project_Activity_indicator_period.ID full OUTER join Project_Activities_Indicators_History on Project_Activities_Indicators.PAI_ID=Project_Activities_Indicators_History.pai_pai_id full OUTER join Organization on Project_Activities.Excutive_responsible_Org_Org_id = Organization.org_id where 1=1 AND (dbo.Project_Constraints.PCONS_IS_CRITICAL = 1)";
            if (Smart_Search_Proj.SelectedValue != "")
            {
                proj_id = int.Parse(Smart_Search_Proj.SelectedValue);
                budget = decimal.Parse(LabValue.Text);
                proj_name = Smart_Search_Proj.Text_Field;
                ptem_name = Labname.Text;
                dept_name = LabDeptname.Text;
                sql += " AND dbo.Project.Proj_id= " + proj_id;


            }
            if (Smrt_Srch_projmanage.SelectedValue != "")
            {
                projmanage = int.Parse(Smrt_Srch_projmanage.SelectedValue);
                sql += " AND dbo.Project_Team.pmp_pmp_id = " + projmanage;

            }
            if (Smrt_Srch_DropDep.SelectedValue != "")
            {
                dept_id = int.Parse(Smrt_Srch_DropDep.SelectedValue);
                sql += " AND dbo.Departments.Dept_ID= " + dept_id;
            }
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            string user = Session_CS.pmp_name.ToString();
            ReportDocument rd = new ReportDocument();
            string s = Server.MapPath("../Reports/NeedHInterference.rpt");
            rd.Load(s);
            rd.SetDataSource(dt);
            Reports.Load_Report(rd);



            rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
            rd.SetParameterValue("@user", user, "footerRep.rpt");
            if (dt.Rows.Count == 0)
            {
                ShowAlertMessage("!!!!!هذا التقرير لا يوجد به بيانات للعرض !!!!");
                return;
            }
            else
            {
                rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report");
            }
        }
        //else if (hidden_Rpt_Id.Value == "project_select_status_Report")
        //{
        //    SqlConnection conn = new SqlConnection(sql_Connection);

        //    //int proj_id = 0;
        //    //int projmanage = 0;
        //    //int dept_id = 0;

        //    int commit = 0;
        //    sql = " SELECT Proj_id,Proj_Title,pmp_pmp_id,Project.Dept_Dept_id,Proj_is_commit,pmp_name,Dept_name from dbo.Project";
        //    sql += " inner join employee on Project.pmp_pmp_id=employee.pmp_id";
        //    sql += " inner join dbo.Departments on Project.Dept_Dept_id=Departments.dept_id where 1=1";


        //    if (Dropstatus.SelectedValue != "0")
        //    {
        //        commit = int.Parse(Dropstatus.SelectedValue);
        //        sql += " AND dbo.Project.Proj_is_commit= " + commit;


        //    }

        //    sql += "order by Proj_is_commit,Project.Dept_Dept_id";
        //    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        //    DataTable dt = new DataTable();
        //    da.Fill(dt);
        //    string user = Session_CS.pmp_name.ToString();
        //    ReportDocument rd = new ReportDocument();
        //    string s = Server.MapPath("../Reports/Proj_Status_AccordingDept.rpt");
        //    rd.Load(s);
        //    rd.SetDataSource(dt);
        //    Reports.Load_Report(rd);



        //    rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
        //    rd.SetParameterValue("@user", user, "footerRep.rpt");
        //    if (dt.Rows.Count == 0)
        //    {
        //        ShowAlertMessage("!!!!!هذا التقرير لا يوجد به بيانات للعرض !!!!");
        //        return;
        //    }
        //    else
        //    {
        //        rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report");
        //    }
        //}


        /////////////////////////////////////////////////////////// Project Needs  Report ///////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        else if (hidden_Rpt_Id.Value == "ProjectNeeds_Report")
        {
            //SqlConnection conn = new SqlConnection(sql_Connection);
            //if (DropDate.SelectedValue != "0")
            //{
            //    int proj_id = 0;
            //    int projmanage = 0;
            //    int dept_id = 0;
            //    decimal budget = 0;
            //    string proj_name = "";
            //    string ptem_name = "";
            //    string dept_name = "";
            //    if (DropProj.SelectedValue != "0")
            //    {
            //        proj_id = int.Parse(DropProj.SelectedItem.Value);
            //        budget = decimal.Parse(LabValue.Text);
            //        proj_name = DropProj.SelectedItem.Text;
            //        ptem_name = Labname.Text;
            //        dept_name = LabDeptname.Text;

            //    }
            //    if (Smrt_Srch_projmanage.SelectedValue != "0")
            //    {
            //        projmanage = int.Parse(Smrt_Srch_projmanage.SelectedValue);
            //    }
            //    if (Smrt_Srch_DropDep.SelectedValue != "0")
            //    {
            //        dept_id = int.Parse(Smrt_Srch_DropDep.SelectedValue);
            //    }        


            //            string user = Session_CS.pmp_name.ToString();
            //            ReportDocument rd = new ReportDocument();
            //            string s = Server.MapPath("../Reports/PNeeds_parameter.rpt");
            //            rd.Load(s);
            //            Reports.Load_Report(rd);
            //            rd.SetParameterValue(0, proj_id);
            //            rd.SetParameterValue(1, DropDate.SelectedItem.Text);
            //            rd.SetParameterValue("@Dept_id", dept_id);
            //            rd.SetParameterValue("@PMP_id", projmanage);

            //            rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
            //            rd.SetParameterValue("@user", user, "footerRep.rpt");

            //            if (rd.Rows.Count == 0)
            //            {
            //                ShowAlertMessage("!!!!!هذا التقرير لا يوجد به بيانات للعرض !!!!");
            //                return;
            //            }
            //            else
            //            {
            //                rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.WordForWindows, Response, true, "Report");
            //            }                

            //}
            //else
            //{
            //    Label6.Visible = true;
            //    Label6.Text = "!!!!!!يجب اختيار تاريخ الصرف لعرض هذا التقرير";
            //    return;
            //}

        }
        /////////////////////////////////////////////////////////// commited Projects budgets Report ///////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        else if (hidden_Rpt_Id.Value == "commitedandRefusedProjects_Report")
        {

            SqlConnection conn = new SqlConnection(sql_Connection);

            int dept_id = 0;
            string sql = "SELECT dbo.Departments.Dept_ID, dbo.Departments.Dept_name, dbo.Project.Proj_id, dbo.Project.Proj_Title, dbo.Project.Proj_is_commit, convert(datetime,dbo.Project.Proj_Creation_Date,103) as  Proj_Creation_Date , dbo.Project.Proj_InitValue FROM dbo.Departments INNER JOIN dbo.Project ON dbo.Departments.Dept_ID = dbo.Project.Dept_Dept_id where 1=1 ";
            if (Smrt_Srch_DropDep.SelectedValue != "")
            {
                sql += " and dbo.Departments.Dept_ID = " + dept_id;
                dept_id = int.Parse(Smrt_Srch_DropDep.SelectedValue);
            }
            sql += " order by dbo.Project.Proj_Creation_Date,Dept_name,Proj_Title";
            string user = Session_CS.pmp_name.ToString();
            ReportDocument rd = new ReportDocument();
            string s = Server.MapPath("../Reports/commitedandRefusedProjects.rpt");
            rd.Load(s);
            Reports.Load_Report(rd);
            //rd.SetParameterValue(0, dept_id);
            rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
            rd.SetParameterValue("@user", user, "footerRep.rpt");
            if (rd.Rows.Count == 0)
            {
                ShowAlertMessage("!!!!!هذا التقرير لا يوجد به بيانات للعرض !!!!");
                return;
            }
            else
            {
                rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report");
            }


        }






        /////////////////////////////////////////////////////////// current projects Report ///////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        else if (hidden_Rpt_Id.Value == "CurrentProjects_Report")
        {
            SqlConnection conn = new SqlConnection(sql_Connection);
            int dept_id = 0;
            if (Smrt_Srch_DropDep.SelectedValue != "")
            {
                dept_id = int.Parse(Smrt_Srch_DropDep.SelectedValue);
            }

            string user = Session_CS.pmp_name.ToString();
            ReportDocument rd = new ReportDocument();

            string s = Server.MapPath("../Reports/CurrentProjects.rpt");
            rd.Load(s);
            Reports.Load_Report(rd);

            rd.SetParameterValue(0, dept_id);
            rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
            rd.SetParameterValue("@user", user, "footerRep.rpt");
            if (rd.Rows.Count == 0)
            {
                ShowAlertMessage("!!!!!هذا التقرير لا يوجد به بيانات للعرض !!!!");
                return;
            }
            else
            {
                rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.WordForWindows, Response, true, "Report");
            }



        }
        /////////////////////////////////////////////////////////// Projects Employees Report ///////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        else if (hidden_Rpt_Id.Value == "ProjectsEmployees_Report")
        {

            SqlConnection conn = new SqlConnection(sql_Connection);

            int dept_id = 0;
            string sql = "SELECT TOP (100) PERCENT dbo.Project_Team.PTem_Name, dbo.Project_Team.PTem_Task_Cat, dbo.JOB_TITLE.JTIT_Desc, dbo.Project.Proj_Title, dbo.Project.Proj_id,dbo.Departments.Dept_name, dbo.Departments.Dept_ID, dbo.Project_Team.pmp_pmp_id FROM dbo.Project INNER JOIN dbo.Departments ON dbo.Project.Dept_Dept_id = dbo.Departments.Dept_ID INNER JOIN dbo.Project_Team ON dbo.Project.Proj_id = dbo.Project_Team.proj_proj_id INNER JOIN dbo.JOB_TITLE INNER JOIN dbo.JOB ON dbo.JOB_TITLE.JTIT_ID = dbo.JOB.JTIT_JTIT_ID ON dbo.Project_Team.job_job_id = dbo.JOB.JOB_ID where 1=1";
            if (Smrt_Srch_DropDep.SelectedValue != "")
            {
                sql += " and dbo.Departments.Dept_ID = " + dept_id;
                dept_id = int.Parse(Smrt_Srch_DropDep.SelectedValue);
            }


            string user = Session_CS.pmp_name.ToString();
            ReportDocument rd = new ReportDocument();
            DataTable DT_Report = General_Helping.GetDataTable(sql);
            string s = Server.MapPath("../Reports/ProjectsEmloyees.rpt");
            rd.Load(s);
            rd.SetDataSource(DT_Report);
            Reports.Load_Report(rd);

            //rd.SetParameterValue(0, dept_id);
            rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
            rd.SetParameterValue("@user", user, "footerRep.rpt");
            if (rd.Rows.Count == 0)
            {
                ShowAlertMessage("!!!!!هذا التقرير لا يوجد به بيانات للعرض !!!!");
                return;
            }
            else
            {
                rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.WordForWindows, Response, true, "Report");
            }


        }
        ///////////////////////////////////// summation needs proj///////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        else if (hidden_Rpt_Id.Value == "summation_needs_proj_Report")
        {

            SqlConnection conn = new SqlConnection(sql_Connection);

            int dept_id = 0;
            sql = "SELECT sum((Project_Needs.PNed_Number)*(Project_Needs.PNed_InitValue)) as Sumation,dept_id,dept_name,proj_id,Proj_Title FROM dbo.Departments inner JOIN dbo.Project ON dbo.Departments.Dept_ID = dbo.Project.Dept_Dept_id INNER JOIN dbo.Project_Needs ON dbo.Project.Proj_id = dbo.Project_Needs.proj_proj_id";
            sql += " where 1=1 ";
            if (Smrt_Srch_DropDep.SelectedValue != "")
            {
                dept_id = int.Parse(Smrt_Srch_DropDep.SelectedValue);
                sql += " AND dept_id = " + dept_id;
            }

            string user = Session_CS.pmp_name.ToString();
            ReportDocument rd = new ReportDocument();
            string s = Server.MapPath("../Reports/summation_need_projects.rpt");
            rd.Load(s);
            Reports.Load_Report(rd);

            //rd.SetParameterValue(0, dept_id);
            rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
            rd.SetParameterValue("@user", user, "footerRep.rpt");
            if (rd.Rows.Count == 0)
            {
                ShowAlertMessage("!!!!!هذا التقرير لا يوجد به بيانات للعرض !!!!");
                return;
            }
            else
            {
                rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report");
            }


        }
        ///////////////////////////////////// End Year VS Projects///////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        else if (hidden_Rpt_Id.Value == "year_Vs_Project_Report")
        {

            SqlConnection conn = new SqlConnection(sql_Connection);

            int dept_id = 0;
            sql = "set dateformat dmy ";
            sql += " SELECT dbo.Departments.Dept_name,dbo.Departments.Dept_ID, dbo.Project.Proj_Title, dbo.Project.Proj_id, dbo.Project.Dept_Dept_id,year(convert(datetime,dbo.datevalid(dbo.Project.Proj_End_Date),103)) AS valid_date FROM dbo.Departments INNER JOIN dbo.Project ON dbo.Departments.Dept_ID = dbo.Project.Dept_Dept_id where 1=1";
            if (Smrt_Srch_DropDep.SelectedValue != "")
            {
                sql += " and dbo.Departments.Dept_ID = " + dept_id;
                dept_id = int.Parse(Smrt_Srch_DropDep.SelectedValue);
            }
            DataTable dt_report = General_Helping.GetDataTable(sql);
            string user = Session_CS.pmp_name.ToString();
            ReportDocument rd = new ReportDocument();
            string s = Server.MapPath("../Reports/EndTim_VS_Proj.rpt");
            rd.Load(s);
            rd.SetDataSource(dt_report);
            Reports.Load_Report(rd);

            //rd.SetParameterValue(0, dept_id);
            rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
            rd.SetParameterValue("@user", user, "footerRep.rpt");
            if (rd.Rows.Count == 0)
            {
                ShowAlertMessage("!!!!!هذا التقرير لا يوجد به بيانات للعرض !!!!");
                return;
            }
            else
            {
                rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report");
            }


        }
        /////////////////////////////////////  Projects Status ///////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        else if (hidden_Rpt_Id.Value == "Projects_Status_Report")
        {

            SqlConnection conn = new SqlConnection(sql_Connection);

            int dept_id = 0;
            int org_id = 0;
            int status = 0;


            sql = " SELECT    distinct Project.Proj_id,[dbo].[project_Projress](Proj_id)  as Proj_progress, Project.Proj_Title, EMPLOYEE.pmp_name, Project.Proj_InitValue, Project.Proj_is_commit, CONVERT(datetime, Project.Proj_Creation_Date, 103)  AS Proj_Creation_Date, CONVERT(datetime, Project.proj_start_date, 103) AS proj_start_date, CONVERT(datetime, Project.Proj_End_Date, 103) AS Proj_End_Date, Departments.Dept_name, Departments.Dept_ID FROM         Departments INNER JOIN Project ON Departments.Dept_ID = Project.Dept_Dept_id INNER JOIN EMPLOYEE ON Project.pmp_pmp_id = EMPLOYEE.PMP_ID LEFT OUTER JOIN Project_Organization ON Project.Proj_id = Project_Organization.proj_proj_id WHERE     (1 = 1)";
            if (Smrt_Srch_DropDep.SelectedValue != "")
            {
                dept_id = int.Parse(Smrt_Srch_DropDep.SelectedValue);
                sql += " and dbo.Departments.Dept_ID = " + dept_id;

            }
            if (Droporg.SelectedValue != "0")
            {
                org_id = int.Parse(Droporg.SelectedValue);
                sql += " and Project_Organization.org_org_id = " + org_id;

            }

            string ss = "";
            foreach (ListItem item in chk_status.Items)
            {
                if (item.Selected)
                {
                    ss += item.Value.ToString() + ",";


                }
            }
            if (ss.Length > 0)
            {
                // ss += "0";
                ss = ss.Remove(ss.Length - 1);
                sql += " and Project.Proj_is_commit  in(" + ss + ")";
            }


            sql += " Order by Proj_is_commit ";

            DataTable dt_report = General_Helping.GetDataTable(sql);
            string user = Session_CS.pmp_name.ToString();
            ReportDocument rd = new ReportDocument();
            string s = Server.MapPath("../Reports/CurrentProjectsPerDept.rpt");
            rd.Load(s);
            rd.SetDataSource(dt_report);
            Reports.Load_Report(rd);

            //rd.SetParameterValue(0, dept_id);
            rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
            rd.SetParameterValue("@user", user, "footerRep.rpt");
            if (rd.Rows.Count == 0)
            {
                ShowAlertMessage("!!!!!هذا التقرير لا يوجد به بيانات للعرض !!!!");
                return;
            }
            else
            {
                rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report");
            }


        }
        /////////////////////////////////////  protocol ///////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        else if (hidden_Rpt_Id.Value == "protocol_Report")
        {

            SqlConnection conn = new SqlConnection(sql_Connection);

            int dept_id = 0;
            int org_id_coop = 0;
            int org_id_advg = 0;
            int org_id_exc = 0;
            int status = 0;
            sql = "set dateformat dmy  SELECT DISTINCT   Protocol_Main_Def.Protocol_ID, Protocol_Main_Def.Name, Protocol_Main_Def.Total_Balance_LE, Protocol_Main_Def.Total_Balance_US, Protocol_Main_Def.Strt_DT,convert(datetime,dbo.datevalid(Protocol_Main_Def.Strt_DT)) as dateconverted,Protocol_Main_Def.End_DT, dbo.datevalid(Protocol_Main_Def.Strt_DT) AS valid_date, Departments.Dept_name, Project.Dept_Dept_id,                       dbo.Protocol_org(Protocol_Main_Def.Protocol_ID, 1) AS 'جهات  مشاركة ', dbo.Protocol_org(Protocol_Main_Def.Protocol_ID, 2) AS 'جهات مستفيدة',                       dbo.Protocol_org(Protocol_Main_Def.Protocol_ID, 3) AS 'جهات منفذة' FROM         Protocol_Main_Def LEFT OUTER JOIN                      Departments RIGHT OUTER JOIN                      Project ON Departments.Dept_ID = Project.Dept_Dept_id ON Protocol_Main_Def.Protocol_ID = Project.Protocol_ID LEFT OUTER JOIN                      Protocol_Main_Org ON Protocol_Main_Def.Protocol_ID = Protocol_Main_Org.Protocol_ID WHERE     (Protocol_Main_Def.Protocol_ID NOT IN (2, 3, 4, 149))";

            if (Smrt_Srch_DropDep.SelectedValue != "")
            {
                dept_id = int.Parse(Smrt_Srch_DropDep.SelectedValue);
                sql += " and dbo.Project.Dept_Dept_ID = " + dept_id;

            }
            bool Flag = false;
            //if (smart_org_coop.SelectedValue != "" || smart_advantage_org.SelectedValue != "" || smart_exc_org.SelectedValue != "")
            //{
            //    sql += " and ";
            //    Flag = true;
            //}
            if (smart_org_coop.SelectedValue != "")
            {
                org_id_coop = int.Parse(smart_org_coop.SelectedValue);
                sql += " and ";
                Flag = true;
                sql += " ( Protocol_Main_Org.Org_ID = " + org_id_coop + " and Org_Type=1 )";

            }
            if (smart_advantage_org.SelectedValue != "")
            {
                if (Flag)
                    sql += " or ";
                else
                {
                    sql += " and ";
                    Flag = true;
                }

                org_id_advg = int.Parse(smart_advantage_org.SelectedValue);
                sql += " ( Protocol_Main_Org.Org_ID = " + org_id_advg + " and Org_Type=2 ) ";

            }
            if (smart_exc_org.SelectedValue != "")
            {

                if (Flag)
                    sql += " or ";
                else
                {
                    sql += " and ";
                    Flag = true;
                }
                org_id_exc = int.Parse(smart_exc_org.SelectedValue);
                sql += " ( Protocol_Main_Org.Org_ID = " + org_id_exc + " and Org_Type=3)";

            }

            sql += " ORDER BY convert(datetime,dbo.datevalid(Protocol_Main_Def.Strt_DT)) , Protocol_Main_Def.Protocol_ID desc";
            DataTable dt_report = General_Helping.GetDataTable(sql);
            string user = Session_CS.pmp_name.ToString();
            ReportDocument rd = new ReportDocument();
            //string s = Server.MapPath("../Reports/Protocole_General_Data_Portrait.rpt");
            string s = Server.MapPath("../Reports/Protocole_try_excel.rpt");
            rd.Load(s);
            rd.SetDataSource(dt_report);
            Reports.Load_Report(rd);

            //rd.SetParameterValue(0, dept_id);
            //rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
            //rd.SetParameterValue("@user", user, "footerRep.rpt");
            if (rd.Rows.Count == 0)
            {
                ShowAlertMessage("!!!!!هذا التقرير لا يوجد به بيانات للعرض !!!!");
                return;
            }
            else
            {

                rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.Excel, Response, true, "Report");
            }


        }
        /////////////////////////////////////////////////////////// Projects needs approve Report ///////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        else if (hidden_Rpt_Id.Value == "projectsneedapprove_Report")
        {
            string t1 = "";
            string t2 = "";
            int dept_id = 0;


            string user = Session_CS.pmp_name.ToString();



            SqlConnection conn = new SqlConnection(sql_Connection);
            sql = "select pmp_name,need_Serial,Pned_name,approved_amount,PNed_Number,PNed_ID,convert(datetime,PNed_Date,103) as PNed_Date,";
            sql += " Proj_Title,Proj_id,TotalDelievered,Dept_id,Dept_name ";
            sql += " from ";
            sql += " project_needs join Project on project_needs.Proj_proj_id = project.Proj_id  ";
            sql += " inner join employee on Project.pmp_pmp_id = EMPLOYEE.PMP_ID   ";
            sql += " inner join Departments on Project.Dept_Dept_id = Departments.Dept_id  ";
            sql += " AND  approved_amount=0";
            if (Smrt_Srch_DropDep.SelectedValue != "")
            {
                dept_id = int.Parse(Smrt_Srch_DropDep.SelectedValue);
                sql += " AND Departments.Dept_id=" + dept_id;
            }
            if (string.IsNullOrEmpty(TextBox1.Text) && string.IsNullOrEmpty(TextBox2.Text))
            {

                t1 = "01/01/1900";
                t2 = CDataConverter.ConvertDateTimeToFormatdmy(DateTime.MaxValue);
                //sql += " AND convert(datetime,dbo.datevalid(dbo.project_needs.PNed_Date)) > = '" + t1.ToString() + "'";
                //sql += " AND convert(datetime,dbo.datevalid(dbo.project_needs.PNed_Date)) < = '" + t2.ToString() + "'";
            }
            else if (string.IsNullOrEmpty(TextBox1.Text))
            {
                if (VB_Classes.Dates.Dates_Operation.date_validate(TextBox2.Text.Trim()) != "")
                {
                    t1 = "01/01/1900";
                    //t2 = DateTime.ParseExact(Inbox_date_to.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
                    t2 = VB_Classes.Dates.Dates_Operation.date_validate(TextBox2.Text.Trim());
                    sql += " AND convert(datetime,dbo.datevalid(dbo.project_needs.PNed_Date)) < = '" + t2.ToString() + "'";
                }
                else
                {
                    ShowAlertMessage("!!!!!ادخل التاريخ بطريقة صحيحة !!!!");
                    return;
                }

            }
            else if (string.IsNullOrEmpty(TextBox2.Text))
            {

                if (VB_Classes.Dates.Dates_Operation.date_validate(TextBox1.Text.Trim()) != "")
                {
                    //t1 = DateTime.ParseExact(Inbox_date_from.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
                    t2 = CDataConverter.ConvertDateTimeToFormatdmy(DateTime.MaxValue); 
                    t1 = VB_Classes.Dates.Dates_Operation.date_validate(TextBox1.Text.Trim());
                    sql += " AND convert(datetime,dbo.datevalid(dbo.project_needs.PNed_Date)) > = '" + t1.ToString() + "'";

                }
                else
                {
                    ShowAlertMessage("!!!!!ادخل التاريخ بطريقة صحيحة !!!!");
                    return;
                }

            }

            else
            {
                if (VB_Classes.Dates.Dates_Operation.date_validate(TextBox2.Text.Trim()) != "" && VB_Classes.Dates.Dates_Operation.date_validate(TextBox1.Text.Trim()) != "")
                {
                    //t1 = DateTime.ParseExact(Inbox_date_from.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
                    t2 = VB_Classes.Dates.Dates_Operation.date_validate(TextBox2.Text.Trim());
                    //t2 = DateTime.ParseExact(Inbox_date_to.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
                    t1 = VB_Classes.Dates.Dates_Operation.date_validate(TextBox1.Text.Trim());
                    sql += " AND convert(datetime,dbo.datevalid(dbo.project_needs.PNed_Date)) > = '" + t1.ToString() + "'";
                    sql += " AND convert(datetime,dbo.datevalid(dbo.project_needs.PNed_Date)) < = '" + t2.ToString() + "'";
                }
                else
                {
                    ShowAlertMessage("!!!!!ادخل التاريخ بطريقة صحيحة !!!!");
                    return;
                }


            }
            DateTime date1 = CDataConverter.ConvertToDate(t1);
            DateTime date2 = CDataConverter.ConvertToDate(t2); 
            if (date2.Subtract(date1).Days < 0)
            {
                ShowAlertMessage("!!!!!التاريخ الأول يجب ان يكون قبل التاريخ الثاني !!!!");
                return;
            }
            sql += "order by Proj_id, pmp_name,need_Serial ";

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            ReportDocument rd = new ReportDocument();
            string s = Server.MapPath("../Reports/PDemands_NOTApprove.rpt");
            rd.Load(s);
            rd.SetDataSource(dt);
            //rd.SetParameterValue("@Dept_id", dept_id);
            rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
            rd.SetParameterValue("@user", user, "footerRep.rpt");
            if (dt.Rows.Count == 0)
            {

                ShowAlertMessage("!!!!!هذا التقرير لا يوجد به بيانات للعرض !!!!");
                return;

            }
            else
            {



                rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report.rpt");


            }

        }
        /////////////////////////////////////////////////////////// Projects Objective Report ///////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        else if (hidden_Rpt_Id.Value == "projobjective_Report")
        {
            ReportDocument rd = new ReportDocument();
            int proj_id = 0;
            int projmanage = 0;
            decimal budget = 0;
            int commit = 0;
            string proj_name = "";
            string ptem_name = "";
            string dept_name = "";
            int dept_id = 0;
            sql = "SELECT     Project.Proj_Title, Project.Proj_Brief, Project_Objective.PObj_Desc, Project_Objective.PObj_ID, Project.Proj_id, Departments.Dept_name, Departments.Dept_id,                       EMPLOYEE.pmp_name, Project_Objective.PObj_Num, Project.Proj_InitValue, EMPLOYEE.PMP_ID FROM         Departments INNER JOIN                      Project ON Departments.Dept_ID = Project.Dept_Dept_id LEFT OUTER JOIN                      EMPLOYEE ON Project.pmp_pmp_id = EMPLOYEE.PMP_ID LEFT OUTER JOIN                      Project_Objective ON Project.Proj_id = Project_Objective.proj_proj_id where 1=1";
            if (Smrt_Srch_projmanage.SelectedValue != "")
            {
                projmanage = int.Parse(Smrt_Srch_projmanage.SelectedValue);
                sql += " AND dbo.Project.pmp_pmp_id = " + projmanage;
            }
            if (Request.QueryString["type"] == "1")
            {
                if (Smrt_Srch_DropDep.SelectedValue != "")
                {
                    dept_id = int.Parse(Smrt_Srch_DropDep.SelectedValue);
                    sql += " AND dbo.Departments.Dept_ID = " + dept_id;
                }
                if (Smart_Search_Proj.SelectedValue != "")
                {
                    proj_id = int.Parse(Smart_Search_Proj.SelectedValue);
                    budget = decimal.Parse(LabValue.Text);
                    proj_name = Smart_Search_Proj.Text_Field;
                    ptem_name = Labname.Text;
                    dept_name = LabDeptname.Text;
                    sql += " AND dbo.Project.Proj_id = " + proj_id;

                }
            }
            else
            {
                if (Smart_Search_Proj.SelectedValue != "")
                {
                    proj_id = int.Parse(Smart_Search_Proj.SelectedValue);
                    budget = decimal.Parse(LabValue.Text);
                    proj_name = Smart_Search_Proj.Text_Field;
                    ptem_name = Labname.Text;
                    dept_name = LabDeptname.Text;
                    sql += " AND dbo.Project.Proj_id = " + proj_id;

                }
                else
                {
                    ShowAlertMessage("!!!!!يجب اختيار مشروع لعرض التقرير !!!!");
                    return;
                }
            }
            if (Dropstatus.SelectedValue != "0")
            {
                commit = int.Parse(Dropstatus.SelectedValue);
                sql += " AND dbo.Project.Proj_is_commit = " + commit;
            }
            sql += " order by dbo.Project.Proj_id";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            string user = Session_CS.pmp_name.ToString();
            string s = Server.MapPath("../Reports/Proj_obj.rpt");
            rd.Load(s);
            rd.SetDataSource(dt);
            Reports.Load_Report(rd);

            rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
            rd.SetParameterValue("@user", user, "footerRep.rpt");
            if (rd.Rows.Count == 0)
            {
                ShowAlertMessage("!!!!!هذا التقرير لا يوجد به بيانات للعرض !!!!");
                return;
            }
            else
            {
                rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.WordForWindows, Response, true, "Report");
            }


        }

        /////////////////////////////////////////////////////////// project Achievement Report ///////////////////////////////////////////////////////////
        else if (hidden_Rpt_Id.Value == "projAchievement_Report")
        {
            ReportDocument rd = new ReportDocument();
            int proj_id = 0;
            int projmanage = 0;
            decimal budget = 0;
            string proj_name = "";
            string ptem_name = "";
            string dept_name = "";
            int dept_id = 0;
            //sql = "SELECT dbo.Project.Proj_Title, dbo.Project_Objective.PObj_Desc,PObj_ID, dbo.Project.Proj_id, dbo.Departments.Dept_name,";
            //sql += " dbo.Departments.Dept_ID, employee.pmp_name,  dbo.Project_Objective.PObj_Num,";
            //sql += " dbo.Project.Proj_InitValue, employee.pmp_id";
            //sql += " FROM dbo.Project_Objective INNER JOIN ";
            //sql += " dbo.Project ON dbo.Project_Objective.proj_proj_id = dbo.Project.Proj_id INNER JOIN";
            //sql += " dbo.Departments ON dbo.Project.Dept_Dept_id = dbo.Departments.Dept_ID INNER JOIN ";
            //sql += " employee ON dbo.Project.pmp_pmp_id= employee.pmp_id";

            sql = " SELECT dbo.project_Achievements.ach_id,dbo.project_Achievements.ach_desc,";
            sql += " dbo.project_Achievements.ach_type,dbo.project_Achievements.ach_other_desc,";
            sql += " dbo.project_Achievements.ach_from_date,dbo.project_Achievements.ach_to_date,dbo.Project.Proj_Title,";
            sql += " dbo.Project.Proj_id,dbo.Departments.Dept_name,dbo.Departments.Dept_ID,";
            sql += " Project_Team.pTem_name,achievments_types.type_desc , dbo.Project.Proj_InitValue";
            sql += " FROM dbo.project_Achievements";
            sql += " join achievments_types on project_Achievements.ach_type=achievments_types.type_id";
            sql += " join project on project_Achievements.proj_id=project.proj_id";
            sql += " join Departments on project.dept_dept_id=Departments.dept_id";
            sql += " join Project_Team on project.pmp_pmp_id=Project_Team.pmp_pmp_id and project.proj_id=Project_Team.proj_proj_id";

            if (Smart_Search_Proj.SelectedValue != "")
            {
                proj_id = int.Parse(Smart_Search_Proj.SelectedValue);
                budget = decimal.Parse(LabValue.Text);
                proj_name = Smart_Search_Proj.Text_Field;
                ptem_name = Labname.Text;
                dept_name = LabDeptname.Text;
                sql += " AND dbo.Project.Proj_id = " + proj_id;

            }
            if (Smrt_Srch_projmanage.SelectedValue != "")
            {
                projmanage = int.Parse(Smrt_Srch_projmanage.SelectedValue);
                sql += " AND project.pmp_pmp_id = " + projmanage;
            }
            if (Smrt_Srch_DropDep.SelectedValue != "")
            {
                dept_id = int.Parse(Smrt_Srch_DropDep.SelectedValue);
                sql += " AND dbo.Departments.Dept_ID = " + dept_id;
            }
            sql += " order by dbo.Project.Proj_id,dbo.project_Achievements.ach_type";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            string user = Session_CS.pmp_name.ToString();
            string s = Server.MapPath("../Reports/Proj_achievments.rpt");
            rd.Load(s);
            rd.SetDataSource(dt);
            Reports.Load_Report(rd);

            //rd.SetParameterValue(0, proj_id);
            rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
            rd.SetParameterValue("@user", user, "footerRep.rpt");
            if (dt.Rows.Count == 0)
            {
                ShowAlertMessage("!!!!!هذا التقرير لا يوجد به بيانات للعرض !!!!");
                return;
            }
            else
            {
                rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report");
            }


        }
        /////////////////////////////////////////////////////////// Projects needs Report ///////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        else if (hidden_Rpt_Id.Value == "projobjneeds_Report")
        {
            //ReportDocument rd = new ReportDocument();
            //int proj_id = 0;
            //decimal budget = 0;
            //string proj_name = "";
            //string ptem_name = "";
            //string dept_name = "";
            //if (DropProj.SelectedValue != "0")
            //{
            //    proj_id = int.Parse(DropProj.SelectedItem.Value);
            //    budget = decimal.Parse(LabValue.Text);
            //    proj_name = DropProj.SelectedItem.Text;
            //    ptem_name = Labname.Text;
            //    dept_name = LabDeptname.Text;

            //}



            //string user = Session_CS.pmp_name.ToString();

            //string s = Server.MapPath("../Reports/ProjNeeds.rpt");
            //rd.Load(s);
            //Reports.Load_Report(rd);
            //rd.SetParameterValue(0, proj_id);
            //rd.SetParameterValue("@Proj_Name", proj_name, "Report_Sticker_Try2.rpt");
            //rd.SetParameterValue("@Dept_Name", dept_name, "Report_Sticker_Try2.rpt");
            //rd.SetParameterValue("@budget", budget, "Report_Sticker_Try2.rpt");
            //rd.SetParameterValue("@PMP_Name", ptem_name, "Report_Sticker_Try2.rpt");
            //rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
            //rd.SetParameterValue("@user", user, "footerRep.rpt");
            //if (rd.Rows.Count == 0)
            //{
            //    ShowAlertMessage("!!!!!هذا التقرير لا يوجد به بيانات للعرض !!!!");
            //    return;
            //}
            //else
            //{
            //    rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.WordForWindows, Response, true, "Report");
            //}


        }
        /////////////////////////////////////////////////////////// weight percentage Report ///////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        else if (hidden_Rpt_Id.Value == "weightpercentage_Report")
        {
            //ReportDocument rd = new ReportDocument();
            //int proj_id = 0;
            //decimal budget = 0;
            //string proj_name = "";
            //string ptem_name = "";
            //string dept_name = "";
            //if (DropProj.SelectedValue != "0")
            //{
            //    proj_id = int.Parse(DropProj.SelectedItem.Value);
            //    budget = decimal.Parse(LabValue.Text);
            //    proj_name = DropProj.SelectedItem.Text;
            //    ptem_name = Labname.Text;
            //    dept_name = LabDeptname.Text;

            //}


            //string user = Session_CS.pmp_name.ToString();

            //string s = Server.MapPath("../Reports/CrystalReport3.rpt");
            //rd.Load(s);
            //Reports.Load_Report(rd);
            //rd.SetParameterValue(0, proj_id);
            //rd.SetParameterValue("@Proj_Name", proj_name, "Report_Sticker_Try2.rpt");
            //rd.SetParameterValue("@Dept_Name", dept_name, "Report_Sticker_Try2.rpt");
            //rd.SetParameterValue("@budget", budget, "Report_Sticker_Try2.rpt");
            //rd.SetParameterValue("@PMP_Name", ptem_name, "Report_Sticker_Try2.rpt");
            //rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
            //rd.SetParameterValue("@user", user, "footerRep.rpt");
            //if (rd.Rows.Count == 0)
            //{
            //    ShowAlertMessage("!!!!!هذا التقرير لا يوجد به بيانات للعرض !!!!");
            //    return;
            //}
            //else
            //{
            //    rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.WordForWindows, Response, true, "Report");
            //}


        }
        else if (hidden_Rpt_Id.Value == "orgReport_Report")
        {
            //ReportDocument rd = new ReportDocument();
            //int org_id = 0;
            //if (Droporg.SelectedValue != "0")
            //{
            //    org_id = int.Parse(Droporg.SelectedValue);
            //}
            //string user = Session_CS.pmp_name.ToString();

            //string s = Server.MapPath("../Reports/OrganizationsProjects.rpt");
            //rd.Load(s);
            //Reports.Load_Report(rd);
            //rd.SetParameterValue(0, org_id);
            //rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
            //rd.SetParameterValue("@user", user, "footerRep.rpt");
            //if (rd.Rows.Count == 0)
            //{
            //    ShowAlertMessage("!!!!!هذا التقرير لا يوجد به بيانات للعرض !!!!");
            //    return;
            //}
            //else
            //{
            //    rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.WordForWindows, Response, true, "Report");
            //}
        }
        /////////////////////////////////////////////////////////// weight percentage Report ///////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //else if (hidden_Rpt_Id.Value == "projects_Org")
        //{
        //    ReportDocument rd = new ReportDocument();
        //    int org_id = 0;
        //    sql = "SELECT DISTINCT dbo.Project.Proj_id, dbo.Project.Proj_Title, dbo.EMPLOYEE.pmp_name, "+
        //        "dbo.Project.Proj_InitValue, dbo.Project.Proj_is_commit, CONVERT(datetime,dbo.Project.Proj_Creation_Date, 103) AS Proj_Creation_Date,"+
        //        "CONVERT(datetime, dbo.Project.proj_start_date, 103) AS proj_start_date, "+
        //        "CONVERT(datetime, dbo.Project.Proj_End_Date, 103) AS Proj_End_Date, dbo.Departments.Dept_name,"+
        //        "dbo.Departments.Dept_ID, dbo.Organization.Org_Desc, dbo.Organization.Org_ID FROM dbo.Departments "+
        //        "INNER JOIN  dbo.Project ON dbo.Departments.Dept_ID = dbo.Project.Dept_Dept_id "+
        //        "INNER JOIN dbo.EMPLOYEE ON dbo.Project.pmp_pmp_id = dbo.EMPLOYEE.PMP_ID "+
        //        "INNER JOIN dbo.Project_Organization ON dbo.Project.Proj_id = dbo.Project_Organization.proj_proj_id INNER JOIN dbo.Organization ON dbo.Project_Organization.org_org_id = dbo.Organization.Org_ID where 1=1";
        //    if (Droporg.SelectedValue != "0")
        //    {

        //        org_id = int.Parse(Droporg.SelectedValue);
        //        sql += " AND dbo.Organization.Org_ID = " + org_id;
        //    }
        //    DataTable dt_report = General_Helping.GetDataTable(sql);
        //    string user = Session_CS.pmp_name.ToString();

        //    string s = Server.MapPath("../Reports/ProjectsStatusByOrg.rpt");
        //    rd.Load(s);
        //    rd.SetDataSource(dt_report);
        //    Reports.Load_Report(rd);
        //    rd.SetParameterValue(0, org_id);
        //    rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
        //    rd.SetParameterValue("@user", user, "footerRep.rpt");
        //    if (rd.Rows.Count == 0)
        //    {
        //        ShowAlertMessage("!!!!!هذا التقرير لا يوجد به بيانات للعرض !!!!");
        //        return;
        //    }
        //    else
        //    {
        //        rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report");
        //    }
        //}

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////إجمالي الميزانية///////////////////////////////////////////////////////////


        else if (hidden_Rpt_Id.Value == "linkAllBalance")
        {

            int dept_id = 0;

            if (Drop_balance.SelectedValue == "0")
            {
                ShowAlertMessage("!!!!!يجب اختيار سنة مالية !!!!");
                return;
            }



            else
            {
                //string str;
                //string endd;
                //string date1 = (Drop_balance.SelectedValue).Substring(5,4);
                //string date_1 = "01/07/" + date1;

                //string date2 = (Drop_balance.SelectedValue).Substring(0,4);
                //string date_2 = "30/06/" + date2;

                SqlConnection conn = new SqlConnection(sql_Connection);
                sql = " set dateformat dmy set dateformat dmy SELECT     Proj_id, Proj_Title, Dept_ID,Dept_name , " +
                        " (SELECT SUM(Project_Period_Balance.Init_Value) from Project_Period_Balance where projects_Departments.Proj_id = Project_Period_Balance.Proj_id  " +
                        " and CONVERT(datetime, dbo.datevalid(Project_Period_Balance.Strt_Date))  > = '01" + "/07" + "/" + int.Parse(Drop_balance.Text.Substring(5, 4)) + "' and  CONVERT(datetime, dbo.datevalid(Project_Period_Balance.Strt_Date))< ='30" + "/06" + "/" + (int.Parse(Drop_balance.Text.Substring(5, 4)) + 1) + "' ) as totl " +
                        " FROM         projects_Departments ";






                //str = Convert.ToDateTime(TextBox3.Text);

                //str = DateTime.ParseExact(date_1, "dd/MM/yyyy", null).ToString("MM/dd/yyyy");


                //endd = DateTime.ParseExact(date_2, "dd/MM/yyyy", null).ToString("MM/dd/yyyy");
                //sql += " WHERE CONVERT(datetime, Project_Period_Balance.Strt_Date, 103) > = '" + str + "'";

                //sql += "AND CONVERT(datetime, Project_Period_Balance.End_Date, 103) < = '" + endd + "'";

                // sql += " and  CONVERT(datetime, dbo.datevalid(Project_Period_Balance.Strt_Date))  > = '01" + "/07" + "/" + int.Parse(Drop_balance.Text.Substring(5, 4)) + "'";
                // sql += " and  CONVERT(datetime, dbo.datevalid(Project_Period_Balance.Strt_Date)) < ='30" + "/06" + "/" + (int.Parse(Drop_balance.Text.Substring(5, 4)) + 1) + "'";


                if (Smrt_Srch_DropDep.SelectedValue != "")
                {
                    sql += " AND projects_Departments.Dept_ID = " + Smrt_Srch_DropDep.SelectedValue;
                }

                //sql += " GROUP BY Project_Period_Balance.Proj_id, Departments.Dept_name, Project.Proj_Title, Departments.Dept_ID,CONVERT(datetime, dbo.datevalid(Project_Period_Balance.Strt_Date))";


                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count == 0)
                {

                    ShowAlertMessage("!!!!!هذا التقرير لا يوجد به بيانات للعرض !!!!");
                    return;

                }

                else
                {

                    ReportDocument rd = new ReportDocument();
                    string user = Session_CS.pmp_name.ToString();
                    if (Smrt_Srch_DropDep.SelectedValue != "")
                    {
                        dept_id = int.Parse(Smrt_Srch_DropDep.SelectedValue);
                    }
                    string s = Server.MapPath("../Reports/totalofbalance.rpt");
                    rd.Load(s);
                    rd.SetDataSource(dt);
                    // rd.SetParameterValue("@Dept_ID", dept_id);
                    //rd.SetParameterValue("@Strt_DT", );
                    //rd.SetParameterValue("@End_DT", );
                    rd.SetParameterValue("@Date_str", int.Parse(Drop_balance.Text.Substring(5, 4)));
                    rd.SetParameterValue("@Date_end", (int.Parse(Drop_balance.Text.Substring(5, 4)) + 1));
                    rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
                    rd.SetParameterValue("@user", user, "footerRep.rpt");

                    Reports.Load_Report(rd);
                    rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report");
                    conn.Close();
                }
            }
        }
        else if (hidden_Rpt_Id.Value == "work_order")
        {
            if (Smart_Search_Proj.SelectedValue != "")
            {

                SqlConnection conn = new SqlConnection(sql_Connection);
                sql = "SELECT  Fin_Work_Order.Work_Order_ID, CONVERT(int, Fin_Work_Order.Work_Total_Value) AS Work_Total_Value, CONVERT(int, SUM(Fin_Bills.Bil_Value)) AS bil_total_value, Fin_Work_Order.Project_ID, CONVERT(int, Fin_Work_Order.Work_Total_Value) - CONVERT(int, SUM(Fin_Bills.Bil_Value)) AS sub, Project.Proj_Title, Fin_Work_Order.Code, Fin_Work_Order.Date, Fin_Work_Order.Tender_NO, Fin_Work_Order.Tender_Year FROM         Fin_Work_Order INNER JOIN                      Project ON Fin_Work_Order.Project_ID = Project.Proj_id LEFT OUTER JOIN                      Fin_Bills ON Fin_Work_Order.Work_Order_ID = Fin_Bills.Work_Order_ID where 1=1";




                sql += " and Fin_Work_Order.Project_ID = " + Smart_Search_Proj.SelectedValue;

                sql += " GROUP BY Fin_Work_Order.Work_Order_ID, Fin_Work_Order.Work_Total_Value, Fin_Work_Order.Project_ID, Fin_Work_Order.Project_ID, Project.Proj_Title, Fin_Work_Order.Code, Fin_Work_Order.Date, Fin_Work_Order.Tender_NO, Fin_Work_Order.Tender_Year ";
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count == 0)
                {

                    ShowAlertMessage("!!!!!هذا التقرير لا يوجد به بيانات للعرض !!!!");
                    return;

                }

                else
                {

                    ReportDocument rd = new ReportDocument();
                    string user = Session_CS.pmp_name.ToString();

                    string s = Server.MapPath("../Reports/work_order.rpt");
                    rd.Load(s);
                    rd.SetDataSource(dt);


                    rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
                    rd.SetParameterValue("@user", user, "footerRep.rpt");

                    Reports.Load_Report(rd);
                    rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report");
                    conn.Close();

                }
            }
            else
            {
                ShowAlertMessage("!!!!!يجب اختيار مشروع !!!!");
                return;
            }
        }
        else if (hidden_Rpt_Id.Value == "link_M_Balance")
        {
            if (Drop_balance.SelectedValue == "0")
            {
                ShowAlertMessage("!!!!!يجب اختيار سنة مالية !!!!");
                return;
            }
            else
            {
                //string str;
                //string endd;
                //string date1 = (Drop_balance.SelectedValue).Substring(5,4);
                //string date_1 = "01/07/" + date1;
                //string date2 = (Drop_balance.SelectedValue).Substring(0,4);
                //string date_2 = "30/06/" + date2;
                SqlConnection conn = new SqlConnection(sql_Connection);
                sql = " set dateformat dmy SELECT SUM(Project_Period_Balance.Init_Value) AS Init_Value,Departments.Dept_name,Departments.Dept_ID";
                sql += " FROM  Departments INNER JOIN Project ON Departments.Dept_ID = Project.Dept_Dept_id left outer JOIN";
                sql += " Project_Period_Balance ON Project.Proj_id = Project_Period_Balance.Proj_id ";

                //str = Convert.ToDateTime(TextBox3.Text);

                //str = DateTime.ParseExact(date_1, "dd/MM/yyyy", null).ToString("MM/dd/yyyy");
                ////string strt_date = str.Substring(6, 4);

                //endd = DateTime.ParseExact(date_2, "dd/MM/yyyy", null).ToString("MM/dd/yyyy");
                //string end_date = endd.Substring(6, 4);
                sql += " and  CONVERT(datetime, dbo.datevalid(Project_Period_Balance.Strt_Date))  > = '01" + "/07" + "/" + int.Parse(Drop_balance.Text.Substring(5, 4)) + "'";
                sql += " and  CONVERT(datetime, dbo.datevalid(Project_Period_Balance.Strt_Date)) < ='30" + "/06" + "/" + (int.Parse(Drop_balance.Text.Substring(5, 4)) + 1) + "'";





                sql += " GROUP BY  Departments.Dept_name, Departments.Dept_ID";

                //DateTime date1 = DateTime.ParseExact(str, "MM/dd/yyyy", null);
                //DateTime date2 = DateTime.ParseExact(endd, "MM/dd/yyyy", null);
                //if (date2.Year <= date1.Year)
                //{
                //    Label6.Visible = true;
                //    Label6.Text = "يجب ان يكون تاريخ البداية قبل تاريخ النهاية";

                //}
                //else
                //{

                conn.Open();

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count == 0)
                {

                    ShowAlertMessage("!!!!!هذا التقرير لا يوجد به بيانات للعرض !!!!");
                    return;

                }
                else
                {

                    ReportDocument rd = new ReportDocument();
                    string user = Session_CS.pmp_name.ToString();
                    //if (Smrt_Srch_DropDep.SelectedValue != "")
                    //{
                    //    dept_id = int.Parse(Smrt_Srch_DropDep.SelectedValue);
                    //}
                    string s = Server.MapPath("../Reports/SumOfSum.rpt");

                    rd.Load(s);
                    rd.SetDataSource(dt);
                    string year1 = Drop_balance.SelectedValue;
                    rd.SetParameterValue("@start_date", int.Parse(Drop_balance.Text.Substring(5, 4)));
                    rd.SetParameterValue("@end_date", (int.Parse(Drop_balance.Text.Substring(5, 4)) + 1));
                    //rd.SetParameterValue("@Dept_ID", dept_id);
                    rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
                    rd.SetParameterValue("@user", user, "footerRep.rpt");
                    Reports.Load_Report(rd);
                    rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report");
                    conn.Close();
                }

            }
        }



        else if (hidden_Rpt_Id.Value == "suggest_plan")
        {


            if (Drop_balance.SelectedValue == "0")
            {
                ShowAlertMessage("!!!!!يجب اختيار سنة مالية !!!!");
                return;
            }
            else
            {
                conn = new SqlConnection(sql_Connection);


                sql = " SELECT Project_Funding_Sources.Source_Name, Project_Period_Sources.Sources_ID, Project_Period_Sources.Value as 'total value', Project_Period_Balance.Quarter_Year,  Project_Exchange.Rewards  as 'أجور ومكافئات',Project_Exchange.Transitions as 'انتقالات',Project_Exchange.Hotels as 'حجز فنادق',Project_Exchange.Requirements as 'مستلزمات' , Project_Exchange.Training as'تدريب', Project_Exchange.Application as'تطبيقات', Project_Exchange.Tenders as'مناقصات/ممارسات', Project_Exchange.Resources as'موارد',Project_Exchange.Communication as'اتصالات',Project_Exchange.Engineering as'اعمال هندسية', Project_Exchange.Licence as'رخص برامج', Project_Exchange.Reinvestment as'إعادة استثمار',Project.Proj_Title,Project.Proj_id,Departments.Dept_name,Departments.Dept_ID,EMPLOYEE.PMP_ID,EMPLOYEE.pmp_name FROM Project_Period_Sources INNER JOIN Project_Period_Balance ON Project_Period_Sources.Period_ID = Project_Period_Balance.Period_ID INNER JOIN Project_Funding_Sources ON Project_Period_Sources.Sources_ID = Project_Funding_Sources.Sources_ID INNER JOIN Project_Exchange ON  Project_Period_Sources.Sources_ID = Project_Exchange.Sources_ID AND Project_Period_Sources.Provider_ID=Project_Exchange.Provider_ID AND Project_Period_Balance.Proj_id = Project_Exchange.Proj_id AND Project_Period_Balance.Quarter_Year = Project_Exchange.Year inner join  Project on Project_Exchange.Proj_id=Project.Proj_id inner join Departments on Project.Dept_Dept_id= Departments.Dept_ID inner join EMPLOYEE on Project.pmp_pmp_id=EMPLOYEE.PMP_ID WHERE 1=1  ";




                if (Request.QueryString["type"] == "1")
                {
                    if (Smrt_Srch_DropDep.SelectedValue != "")

                        sql += " and Departments.Dept_ID= " + Smrt_Srch_DropDep.SelectedValue;

                    if (Smart_Search_Proj.SelectedValue != "")

                        sql += " and Project.Proj_id= " + Smart_Search_Proj.SelectedValue;


                    if (Smrt_Srch_projmanage.SelectedValue != "")
                        sql += " and EMPLOYEE.PMP_ID= " + Smrt_Srch_projmanage.SelectedValue;
                }
                else
                {
                    if (Smart_Search_Proj.SelectedValue != "")
                        sql += " and Project.Proj_id= " + Smart_Search_Proj.SelectedValue;

                    else
                    {
                        ShowAlertMessage("!!!!!يجب اختيار مشروع لعرض التقرير !!!!");
                        return;
                    }

                }

                string d1 = Drop_balance.SelectedValue.Substring(5, 4);
                string date_1 = "01/07/" + d1;


                string d2 = Drop_balance.SelectedValue.Substring(0, 4);

                string date_2 = "30/06/" + d2;


                sql += " and Year= " + d1;

                // sql += " and  CONVERT(datetime, dbo.datevalid(Project_Period_Balance.Strt_Date))  > = '01" + "/07" + "/" + int.Parse(Drop_balance.Text.Substring(5, 4)) + "'";
                // sql += " and  CONVERT(datetime, dbo.datevalid(Project_Period_Balance.Strt_Date)) < ='30" + "/06" + "/" + (int.Parse(Drop_balance.Text.Substring(5, 4)) + 1) + "'";


                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    string year1 = Drop_balance.SelectedValue;

                    ReportDocument rd = new ReportDocument();
                    string user = Session_CS.pmp_name.ToString();
                    string s = Server.MapPath("../Reports/proj_sources_balance2.rpt");
                    rd.Load(s);
                    rd.SetDataSource(dt);
                    rd.SetParameterValue("date1", d1);
                    rd.SetParameterValue("date2", d2);
                    rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
                    rd.SetParameterValue("@user", user, "footerRep.rpt");
                    Reports.Load_Report(rd);
                    rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report");
                    conn.Close();
                }


                else
                {
                    ShowAlertMessage("!!!!!هذا التقرير لا يوجد به بيانات للعرض !!!!");
                    return;
                }

            }
            //else
            //{
            //    Label6.Visible = true;
            //    Label6.Text = "اختر السنة المالية";
            //}

        }
        else
        {
            ShowAlertMessage("!!!!! لم يتم اختيار أي تقرير للعرض !!!!");
            return;
        }
        //if (Smrt_Srch_DropDep.SelectedValue != "")
        //{

        //    smart_org_coop.sql_Connection = sql_Connection;
        //    smart_advantage_org.sql_Connection = sql_Connection;
        //    smart_exc_org.sql_Connection = sql_Connection;
        //    smart_org_coop.Query = "SELECT  distinct  Protocol_Main_Org.Org_ID, Project.Dept_Dept_id, Organization.Org_Desc, Protocol_Main_Org.Org_Type FROM Protocol_Main_Org INNER JOIN Organization ON Protocol_Main_Org.Org_ID = Organization.Org_ID LEFT OUTER JOIN Project ON Protocol_Main_Org.Protocol_ID = Project.Protocol_ID WHERE	[Dept_Dept_id] = " + Smrt_Srch_DropDep.SelectedValue + " and Org_Type=1";
        //    smart_advantage_org.Query = "SELECT  distinct  Protocol_Main_Org.Org_ID, Project.Dept_Dept_id, Organization.Org_Desc, Protocol_Main_Org.Org_Type FROM Protocol_Main_Org INNER JOIN Organization ON Protocol_Main_Org.Org_ID = Organization.Org_ID LEFT OUTER JOIN Project ON Protocol_Main_Org.Protocol_ID = Project.Protocol_ID WHERE	[Dept_Dept_id] = " + Smrt_Srch_DropDep.SelectedValue + " and Org_Type=2";
        //    smart_exc_org.Query = "SELECT  distinct  Protocol_Main_Org.Org_ID, Project.Dept_Dept_id, Organization.Org_Desc, Protocol_Main_Org.Org_Type FROM Protocol_Main_Org INNER JOIN Organization ON Protocol_Main_Org.Org_ID = Organization.Org_ID LEFT OUTER JOIN Project ON Protocol_Main_Org.Protocol_ID = Project.Protocol_ID WHERE	[Dept_Dept_id] = " + Smrt_Srch_DropDep.SelectedValue + " and Org_Type=3";
        //    smart_org_coop.Value_Field = smart_exc_org.Value_Field = smart_advantage_org.Value_Field = "Org_ID";
        //    smart_org_coop.Text_Field = smart_exc_org.Text_Field = smart_advantage_org.Text_Field = "Org_Desc";
        //    smart_org_coop.DataBind();
        //    smart_exc_org.DataBind();
        //    smart_advantage_org.DataBind();
        //}

    }

    protected void needmaintypeLB_Click(object sender, EventArgs e)
    {
        //Div_Proj.Style.Add("display", "none");
        //Div_Proj_Mngr.Style.Add("display", "none");
        //Div_Date_Needs.Style.Add("display", "none");
        //Div_Dates_Demands.Style.Add("display", "none");
        //Div_Dept.Style.Add("display", "none");
        //Div_Date_balance.Style.Add("display", "none");
        //string user = Session_CS.pmp_name.ToString();
        //ReportDocument rd = new ReportDocument();
        //string s = Server.MapPath("../Reports/needmaintype.rpt");
        //rd.Load(s);
        //Reports.Load_Report(rd);

        //rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
        //rd.SetParameterValue("@user", user, "footerRep.rpt");
        //if (rd.Rows.Count == 0)
        //{
        //    ShowAlertMessage("!!!!!هذا التقرير لا يوجد به بيانات للعرض !!!!");
        //    return;
        //}
        //else
        //{
        //    rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.WordForWindows, Response, true, "Report");
        //}

    }
    protected void OrganizationsProjectsLB_Click(object sender, EventArgs e)
    {
        //hidden_Rpt_Id.Value = "orgReport_Report";
        //Div_Proj.Style.Add("display", "none");
        //Div_Proj_Mngr.Style.Add("display", "none");
        //Div_Date_Needs.Style.Add("display", "none");
        //Div_Dates_Demands.Style.Add("display", "none");
        //Div_Org.Style.Add("display", "block");
        //show_hide_tables();
        //Div_Date_balance.Style.Add("display", "none");
        //Label2.Visible = true;
        //Label6.Visible = false;
        //Page.Title = "تقرير " + OrganizationsProjectsLB.Text;
        //Label2.Text = Page.Title;

    }
    protected void DropDate_SelectedIndexChanged(object sender, EventArgs e)
    {
        Label6.Visible = false;
    }

    protected void ImgBtnBack_Click(object sender, ImageClickEventArgs e)
    {

        Response.Redirect("../MainForm/MMallReports.aspx");
    }
    protected void Droporg_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void needhighinetrLB_Click(object sender, EventArgs e)
    {
        hidden_Rpt_Id.Value = "needhighinter_Report";
        Div_Proj.Style.Add("display", "block");
        Div_Proj_Mngr.Style.Add("display", "block");
        Div_Date_Needs.Style.Add("display", "none");
        Div_Dates_Demands.Style.Add("display", "none");
        Div_Dept.Style.Add("display", "block");
        Div_Date_balance.Style.Add("display", "none");
        show_hide_tables();
        Label6.Visible = false;
        Page.Title = "تقرير " + needhighinetrLB.Text;
        Label2.Visible = true;
        Label2.Text = Page.Title;
    }
    protected void linkAllBalance_Click(object sender, EventArgs e)
    {
        Drop_Date_fun();
        hidden_Rpt_Id.Value = "linkAllBalance";
        Div_Proj.Style.Add("display", "none");
        Div_Proj_Mngr.Style.Add("display", "none");
        Div_Date_balance.Style.Add("display", "none");
        Div_Dept.Style.Add("display", "block");
        Div_Balance.Style.Add("display", "block");
        Div_Dates_Demands.Style.Add("display", "none");
        show_hide_tables();
        Page.Title = "تقرير " + linkAllBalance.Text;
        Label6.Visible = false;
        Label2.Visible = true;
        //DateLabel.Visible = true;
        Label2.Text = Page.Title;

    }
    protected void work_orderLB_Click(object sender, EventArgs e)
    {
        Drop_Date_fun();
        hidden_Rpt_Id.Value = "work_order";
        Div_Proj.Style.Add("display", "block");
        Div_Proj_Mngr.Style.Add("display", "none");
        Div_Date_balance.Style.Add("display", "none");
        Div_Dept.Style.Add("display", "block");
        Div_Balance.Style.Add("display", "none");
        Div_Dates_Demands.Style.Add("display", "none");
        show_hide_tables();
        Page.Title = "تقرير " + work_orderLB.Text;
        Label6.Visible = false;
        Label2.Visible = true;
        //DateLabel.Visible = true;
        Label2.Text = Page.Title;

    }
    protected void Files_No_Click(object sender, EventArgs e)
    {
        //show_hide_tables();
        int dept_id = 0;
        //hidden_Rpt_Id.Value = "Files_No_Report";

        Div_Proj.Style.Add("display", "none");
        Div_Proj_Mngr.Style.Add("display", "none");
        Div_Date_Needs.Style.Add("display", "none");
        Div_Dates_Demands.Style.Add("display", "none");
        Div_Date_balance.Style.Add("display", "none");
        Label2.Visible = true;

        Page.Title = "تقرير " + Files_No.Text;
        Label2.Text = Page.Title;
        Label6.Visible = false;

        string user = Session_CS.pmp_name.ToString();
        ReportDocument rd = new ReportDocument();

        string s = Server.MapPath("../Reports/Files_No.rpt");
        rd.Load(s);
        Reports.Load_Report(rd);

        rd.SetParameterValue("@Dept_id", dept_id);
        rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
        rd.SetParameterValue("@user", user, "footerRep.rpt");
        if (rd.Rows.Count == 0)
        {
            ShowAlertMessage("!!!!!هذا التقرير لا يوجد به بيانات للعرض !!!!");
            return;
        }
        else
        {
            rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report");
        }

    }
    protected void protocole_Report_Click(object sender, EventArgs e)
    {
        //show_hide_tables();

        //hidden_Rpt_Id.Value = "Files_No_Report";
        hidden_Rpt_Id.Value = "protocol_Report";
        Div_Proj.Style.Add("display", "none");
        Div_Proj_Mngr.Style.Add("display", "none");
        Div_Date_Needs.Style.Add("display", "none");
        Div_Dates_Demands.Style.Add("display", "none");
        Div_Date_balance.Style.Add("display", "none");
        Div_Dept.Style.Add("display", "block");
        div_advantage_org.Style.Add("display", "block");
        div_coop_org.Style.Add("display", "block");
        div_exc_org.Style.Add("display", "block");
        show_hide_tables();
        Label2.Visible = true;

        Page.Title = "تقرير " + protocole_Report.Text;
        Label6.Visible = true;
        Label2.Visible = true;
        Label2.Text = Page.Title;


        //string user = Session_CS.pmp_name.ToString();
        //ReportDocument rd = new ReportDocument();
        //string s = Server.MapPath("../Reports/Protocole_General_Data_Portrait.rpt");
        //rd.Load(s);
        //Reports.Load_Report(rd);


        //rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
        //rd.SetParameterValue("@user", user, "footerRep.rpt");
        //if (rd.Rows.Count == 0)
        //{
        //    ShowAlertMessage("!!!!!هذا التقرير لا يوجد به بيانات للعرض !!!!");
        //    return;
        //}
        //else
        //{
        //    rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report");
        //}

    }
    protected void ALL_Actions_No_Click(object sender, EventArgs e)
    {
        //show_hide_tables();
        int dept_id = 0;
        //hidden_Rpt_Id.Value = "Files_No_Report";

        Div_Proj.Style.Add("display", "none");
        Div_Proj_Mngr.Style.Add("display", "none");
        Div_Date_Needs.Style.Add("display", "none");
        Div_Dates_Demands.Style.Add("display", "none");
        Div_Date_balance.Style.Add("display", "none");
        Label2.Visible = true;

        Page.Title = "تقرير " + ALL_Actions_No.Text;
        Label2.Text = Page.Title;
        Label6.Visible = false;

        string user = Session_CS.pmp_name.ToString();
        ReportDocument rd = new ReportDocument();
        string s = Server.MapPath("../Reports/ALL_Actions_No.rpt");
        rd.Load(s);
        Reports.Load_Report(rd);

        rd.SetParameterValue("@Dept_id", dept_id);
        rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
        rd.SetParameterValue("@user", user, "footerRep.rpt");
        if (rd.Rows.Count == 0)
        {
            ShowAlertMessage("!!!!!هذا التقرير لا يوجد به بيانات للعرض !!!!");
            return;
        }
        else
        {
            rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report");
        }

    }


    protected void lnk_achievement_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/MainForm/Yearbook_report.aspx");
        ////show_hide_tables();
        //int dept_id = 0;
        ////hidden_Rpt_Id.Value = "Files_No_Report";

        //Div_Proj.Style.Add("display", "none");
        //Div_Proj_Mngr.Style.Add("display", "none");
        //Div_Date_Needs.Style.Add("display", "none");
        //Div_Dates_Demands.Style.Add("display", "none");
        //Div_Date_balance.Style.Add("display", "none");
        //Label2.Visible = true;

        //Page.Title = "تقرير " + lnk_achievement.Text ;
        //Label2.Text = Page.Title;
        //Label6.Visible = false;

        //string user = Session_CS.pmp_name.ToString();
        //ReportDocument rd = new ReportDocument();
        //string s = Server.MapPath("../Reports/ProjectsDetailsFinal.rpt");
        //rd.Load(s);
        //Reports.Load_Report(rd);

       
        //rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
        //rd.SetParameterValue("@user", user, "footerRep.rpt");
        //if (rd.Rows.Count == 0)
        //{
        //    ShowAlertMessage("!!!!!هذا التقرير لا يوجد به بيانات للعرض !!!!");
        //    return;
        //}
        //else
        //{
        //    rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.WordForWindows, Response, true, "Report");
        //}

    }

    protected void ALL_Act_Actions_No_Click(object sender, EventArgs e)
    {
        //show_hide_tables();
        int dept_id = 0;
        //hidden_Rpt_Id.Value = "Files_No_Report";

        Div_Proj.Style.Add("display", "none");
        Div_Proj_Mngr.Style.Add("display", "none");
        Div_Date_Needs.Style.Add("display", "none");
        Div_Dates_Demands.Style.Add("display", "none");
        Div_Date_balance.Style.Add("display", "none");
        Label2.Visible = true;

        Page.Title = "تقرير " + ALL_Actions_No.Text;
        Label2.Text = Page.Title;
        Label6.Visible = false;
        string sql = "SELECT Project.proj_id,Project.Proj_Title, Departments.Dept_name, Project.Dept_Dept_id , Project.Pmp_pmp_id , employee.pmp_name,(select COUNT(Project_Activities.proj_proj_id) from Project_Activities where Project_Activities.proj_proj_id=project.Proj_id AND PActv_Parent=0) as  Parent_Act_Count,(select COUNT(Project_Activities.proj_proj_id) from Project_Activities where Project_Activities.proj_proj_id=project.Proj_id AND PActv_Parent<>0) as  child_Act_Count,(select COUNT(Project_Needs.proj_proj_id) from Project_Needs where Project_Needs.proj_proj_id=project.Proj_id ) as Pneeds,(select COUNT(Project_Objective.proj_proj_id) from Project_Objective where Project_Objective.proj_proj_id=project.Proj_id ) as proj_obj,(select COUNT(Project_Team.proj_proj_id) from Project_Team where Project_Team.proj_proj_id=project.Proj_id ) as proj_team,(select COUNT(Project_Organization.proj_proj_id) from Project_Organization where Project_Organization.proj_proj_id=project.Proj_id ) as proj_org FROM Departments INNER JOIN Project ON Departments.Dept_ID = Project.Dept_Dept_id LEFT OUTER JOIN employee on project.pmp_pmp_id=employee.pmp_id";
        DataTable dt_report = General_Helping.GetDataTable(sql);
        string user = Session_CS.pmp_name.ToString();
        ReportDocument rd = new ReportDocument();
        string s = Server.MapPath("../Reports/ALL_Activities_Actions_No.rpt");
        rd.Load(s);
        //rd.SetDataSource(dt_report);
        Reports.Load_Report(rd);

        rd.SetParameterValue("@Dept_id", dept_id);
        rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
        rd.SetParameterValue("@user", user, "footerRep.rpt");
        if (rd.Rows.Count == 0)
        {
            ShowAlertMessage("!!!!!هذا التقرير لا يوجد به بيانات للعرض !!!!");
            return;
        }
        else
        {
            rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report");
        }

    }
    protected void summation_needs_deptLB_Click(object sender, EventArgs e)
    {
        Div_Proj.Style.Add("display", "none");
        Div_Proj_Mngr.Style.Add("display", "none");
        Div_Date_Needs.Style.Add("display", "none");
        Div_Dates_Demands.Style.Add("display", "none");
        Div_Dept.Style.Add("display", "none");
        Div_Date_balance.Style.Add("display", "none");
        string user = Session_CS.pmp_name.ToString();
        ReportDocument rd = new ReportDocument();
        string s = Server.MapPath("../Reports/summatio_needs_dept.rpt");
        rd.Load(s);
        Reports.Load_Report(rd);

        rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
        rd.SetParameterValue("@user", user, "footerRep.rpt");
        if (rd.Rows.Count == 0)
        {
            ShowAlertMessage("!!!!!هذا التقرير لا يوجد به بيانات للعرض !!!!");
            return;
        }
        else
        {
            rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report");
        }
    }
    protected void link_M_Balance_Click(object sender, EventArgs e)
    {
        Drop_Date_fun();
        hidden_Rpt_Id.Value = "link_M_Balance";
        Div_Proj.Style.Add("display", "none");
        Div_Proj_Mngr.Style.Add("display", "none");
        Div_Date_balance.Style.Add("display", "none");
        Div_Balance.Style.Add("display", "block");
        Div_Dates_Demands.Style.Add("display", "none");
        //Div_Dept.Style.Add("display","block");
        show_hide_tables();
        Page.Title = "تقرير " + link_M_Balance.Text;
        Label6.Visible = true;
        Label2.Visible = true;
        Label2.Text = Page.Title;

    }
    protected void summation_needs_projLB_Click(object sender, EventArgs e)
    {
        hidden_Rpt_Id.Value = "summation_needs_proj_Report";
        Div_Proj.Style.Add("display", "none");
        Div_Proj_Mngr.Style.Add("display", "none");
        Div_Date_Needs.Style.Add("display", "none");
        Div_Dates_Demands.Style.Add("display", "none");
        Div_Dept.Style.Add("display", "block");
        show_hide_tables();
        Div_Date_balance.Style.Add("display", "none");

        Page.Title = "تقرير " + summation_needs_projLB.Text;
        Label6.Visible = false;
        Label2.Visible = true;
        Label2.Text = Page.Title;
    }
    protected void year_Vs_Project_Click(object sender, EventArgs e)
    {
        hidden_Rpt_Id.Value = "year_Vs_Project_Report";
        Div_Proj.Style.Add("display", "none");
        Div_Proj_Mngr.Style.Add("display", "none");
        Div_Date_Needs.Style.Add("display", "none");
        Div_Dates_Demands.Style.Add("display", "none");
        Div_Dept.Style.Add("display", "block");
        show_hide_tables();
        Div_Date_balance.Style.Add("display", "none");

        Page.Title = "تقرير " + year_Vs_Project.Text;
        Label6.Visible = false;
        Label2.Visible = true;
        Label2.Text = Page.Title;
    }
    //protected void project_select_status_Click(object sender, EventArgs e)
    //{
    //    hidden_Rpt_Id.Value = "project_select_status_Report";
    //    Div_Proj.Style.Add("display", "none");
    //    Div_Proj_Mngr.Style.Add("display", "none");
    //    Div_Date_Needs.Style.Add("display", "none");
    //    Div_Dates_Demands.Style.Add("display", "none");
    //    Div_Dept.Style.Add("display", "none");
    //    show_hide_tables();
    //    Div_Date_balance.Style.Add("display", "none");
    //    Div_Status.Style.Add("display", "block");
    //    Page.Title = "تقرير " + project_select_status.Text;
    //    Label6.Visible = false;
    //    Label2.Visible = true;
    //    Label2.Text = Page.Title;
    //}
    protected void needs_in_detailsLB_Click(object sender, EventArgs e)
    {
        hidden_Rpt_Id.Value = "needs_in_details_Report";
        Div_Proj.Style.Add("display", "block");
        Div_Proj_Mngr.Style.Add("display", "block");
        Div_Date_Needs.Style.Add("display", "none");
        Div_Dates_Demands.Style.Add("display", "none");
        if (Request.QueryString["type"] == "1")
        {
            Div_Dept.Style.Add("display", "block");
        }
        else
        {
            Div_classifications.Style.Add("display", "block");
        }

        show_hide_tables();
        Div_Date_balance.Style.Add("display", "none");
        Label6.Visible = false;
        Page.Title = "تقرير " + needs_in_detailsLB.Text;
        Label2.Visible = true;
        Label2.Text = Page.Title;
    }
    protected void lnk_Tender_Click(object sender, EventArgs e)
    {
        hidden_Rpt_Id.Value = "Tender_Report";

        Div_Proj_Mngr.Style.Add("display", "none");
        Div_Date_Needs.Style.Add("display", "none");
        Div_Dates_Demands.Style.Add("display", "none");
        if (Request.QueryString["type"] == "1")
        {
            Div_Dept.Style.Add("display", "block");
            Div_Proj.Style.Add("display", "none");
        }
        else
        {
            Div_classifications.Style.Add("display", "block");
            Div_Proj.Style.Add("display", "block");
        }
        Div_Date_balance.Style.Add("display", "none");
        Div_Balance.Style.Add("display", "block");
        show_hide_tables();
        Label6.Visible = false;
        Page.Title = "تقرير " + lnk_Tender.Text;
        Label2.Visible = true;
        Label2.Text = Page.Title;
        Drop_Date_fun();
    }
    public void Drop_Year_fun()
    {
        for (int i = 0; i < 41; i++)
        {
            //Drop_balance.Items.Add(DateTime.Now.Year + i);

           // int year = DateTime.Now.Year - 10 + i;
            int year = CDataConverter.ConvertDateTimeNowRtnDt().Year - 10 + i;
            string yearshowed = (year + 1).ToString();
            //Drop_balance.Items.Add(year.ToString());
            Drop_year.Items.Add(yearshowed);
            Drop_year.DataBind();

        }
        Drop_year.Items.Insert(0, new ListItem("اختر السنة المطلوبة......", "0"));
    }

    public void Drop_Date_fun()
    {
        for (int i = 0; i < 41; i++)
        {
            //Drop_balance.Items.Add(DateTime.Now.Year + i);

          //  int year = DateTime.Now.Year - 10 + i;
            int year = CDataConverter.ConvertDateTimeNowRtnDt().Year  - 10 + i;
            string yearshowed = (year + 1) + "/" + year;
            //Drop_balance.Items.Add(year.ToString());
            Drop_balance.Items.Add(yearshowed);
            Drop_balance.DataBind();

        }
        Drop_balance.Items.Insert(0, new ListItem("اختر السنة  المالية المطلوبة......", "0"));
    }

    protected void Budget_SourceLB_Click(object sender, EventArgs e)
    {
        //hidden_Rpt_Id.Value = "Budget_Per_Year_Report";
        //Div_Proj.Style.Add("display", "none");
        //Div_Proj_Mngr.Style.Add("display", "none");
        //Div_Date_Needs.Style.Add("display", "none");
        //Div_Dates_Demands.Style.Add("display", "none");
        //Div_Dept.Style.Add("display", "block");
        //Div_Balance.Style.Add("display", "block");
        //Div_Date_balance.Style.Add("display", "none");
        //show_hide_tables();
        //Page.Title = "تقرير " + Budget_SourceLB.Text;
        //Label6.Visible = false;
        //Label2.Visible = true;
        //Label2.Text = Page.Title;
        //Drop_Date_fun();

    }
    protected void dismissal_ReportLB_Click(object sender, EventArgs e)
    {
        //hidden_Rpt_Id.Value = "dismissal_Report";
        //Div_Proj.Style.Add("display", "none");
        //Div_Proj_Mngr.Style.Add("display", "none");
        //Div_Date_Needs.Style.Add("display", "none");
        //Div_Dates_Demands.Style.Add("display", "none");
        //Div_Dept.Style.Add("display", "block");
        //Div_Balance.Style.Add("display", "block");
        //Div_Date_balance.Style.Add("display", "none");
        //show_hide_tables();
        //Page.Title = "تقرير " + dismissal_ReportLB.Text;
        //Label6.Visible = false;
        //Label2.Visible = true;
        //Label2.Text = Page.Title;
        //Drop_Date_fun();

    }
    protected void total_spent_per_yearLB_Click(object sender, EventArgs e)
    {
        hidden_Rpt_Id.Value = "total_spent_per_year_Report";
        Div_Proj.Style.Add("display", "none");
        Div_Proj_Mngr.Style.Add("display", "none");
        Div_Date_Needs.Style.Add("display", "none");
        Div_Dates_Demands.Style.Add("display", "none");
        Div_Dept.Style.Add("display", "block");
        Div_Balance.Style.Add("display", "block");
        Div_Date_balance.Style.Add("display", "none");
        show_hide_tables();
        Page.Title = "تقرير " + total_spent_per_yearLB.Text;
        Label6.Visible = false;
        Label2.Visible = true;
        Label2.Text = Page.Title;
        Drop_Date_fun();

    }
    protected void suggest_plan_Click(object sender, EventArgs e)
    {
        hidden_Rpt_Id.Value = "suggest_plan";
        Div_Proj.Style.Add("display", "none");
        Div_Proj_Mngr.Style.Add("display", "none");
        Div_Date_Needs.Style.Add("display", "none");
        Div_Dates_Demands.Style.Add("display", "none");
        if (Request.QueryString["type"] == "1")
        {
            Div_Dept.Style.Add("display", "block");
            Div_Proj_Mngr.Style.Add("display", "block");
        }
        else
        {
            Div_classifications.Style.Add("display", "block");
            Div_Proj_Mngr.Style.Add("display", "none");
        }
        Div_Balance.Style.Add("display", "block");
        Div_Proj.Style.Add("display", "block");

        Div_Date_balance.Style.Add("display", "none");
        show_hide_tables();
        Page.Title = "تقرير " + suggest_plan.Text;
        Label6.Visible = false;
        Label2.Visible = true;
        Label2.Text = Page.Title;
        Drop_Date_fun();
    }

    protected void Drop_balance_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Indicator_develp_LB_Click(object sender, EventArgs e)
    {
        hidden_Rpt_Id.Value = "Indicator_Development_Report";
        Div_Proj.Style.Add("display", "block");

        Div_Date_Needs.Style.Add("display", "none");
        Div_Dates_Demands.Style.Add("display", "none");
        Div_Date_balance.Style.Add("display", "none");
        if (Request.QueryString["type"] == "1")
        {

            Div_Proj_Mngr.Style.Add("display", "block");
        }
        else
        {
            Div_Dept.Style.Add("display", "block");
            Div_classifications.Style.Add("display", "block");
            Div_Proj_Mngr.Style.Add("display", "none");
        }

        Div_Main_Activity.Style.Add("display", "block");
        Div_sub_Activity.Style.Add("display", "block");
        show_hide_tables();
        Label6.Visible = false;
        Page.Title = "تقرير " + Indicator_develp_LB.Text;
        Label2.Visible = true;
        Label2.Text = Page.Title;
    }
    protected void Projects_Status_Click(object sender, EventArgs e)
    {
        hidden_Rpt_Id.Value = "Projects_Status_Report";
        Div_Proj.Style.Add("display", "none");
        Div_Proj_Mngr.Style.Add("display", "none");
        Div_Date_Needs.Style.Add("display", "none");
        Div_Dates_Demands.Style.Add("display", "none");
        Div_Dept.Style.Add("display", "block");
        Div_Status.Style.Add("display", "block");
        Div_Org.Style.Add("display", "block");
        Div_Date_balance.Style.Add("display", "none");
        show_hide_tables();
        Page.Title = "تقرير " + Projects_Status.Text;
        Label6.Visible = false;
        Label2.Visible = true;
        Label2.Text = Page.Title;
        Label15.Visible = false;
        Dropstatus.Visible = false;
    }
    //protected void projects_Org_Click(object sender, EventArgs e)
    //{
    //    hidden_Rpt_Id.Value = "projects_Org";
    //    Div_Proj.Style.Add("display", "none");
    //    Div_Proj_Mngr.Style.Add("display", "none");
    //    Div_Date_Needs.Style.Add("display", "none");
    //    Div_Dates_Demands.Style.Add("display", "none");
    //    Div_Org.Style.Add("display", "block");
    //    show_hide_tables();
    //    Div_Date_balance.Style.Add("display", "none");
    //    Label2.Visible = true;
    //    Label6.Visible = false;
    //    Page.Title = "تقرير " + projects_Org.Text;
    //    Label2.Text = Page.Title;

    //}


    protected void Delay_Projects_Click(object sender, EventArgs e)
    {
        hidden_Rpt_Id.Value = "Delay_Projects_Report";
        Div_Proj.Style.Add("display", "none");
        Div_Proj_Mngr.Style.Add("display", "none");
        Div_Date_Needs.Style.Add("display", "none");
        Div_Dates_Demands.Style.Add("display", "none");
        Div_Org.Style.Add("display", "none");
        int dept_id = 0;
        Div_Date_balance.Style.Add("display", "none");
        Label2.Visible = true;
        Label6.Visible = false;


        sql = "SELECT DISTINCT dbo.Project.Proj_Title, dbo.Project.Proj_id, dbo.EMPLOYEE.pmp_name, dbo.Departments.Dept_name, dbo.Departments.Dept_ID FROM dbo.Departments INNER JOIN dbo.Project ON dbo.Departments.Dept_ID = dbo.Project.Dept_Dept_id INNER JOIN  dbo.EMPLOYEE ON dbo.Project.pmp_pmp_id = dbo.EMPLOYEE.PMP_ID INNER JOIN dbo.Project_Activities ON dbo.Project.Proj_id = dbo.Project_Activities.proj_proj_id WHERE     (dbo.Project_Activities.ActStat_ActStat_id <> 3) AND (CONVERT(datetime, dbo.Project_Activities.PActv_End_Date, 103) < GETDATE()) ";

        DataTable dt_report = General_Helping.GetDataTable(sql);

        ReportDocument rd = new ReportDocument();
        //string year1 = Drop_balance.SelectedValue;
        string user = Session_CS.pmp_name.ToString();

        string s = Server.MapPath("../Reports/DelayProjects.rpt");
        rd.Load(s);
        rd.SetDataSource(dt_report);
        Reports.Load_Report(rd);
        //rd.SetParameterValue(0,dept_id);
        rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
        rd.SetParameterValue("@user", user, "footerRep.rpt");
        if (rd.Rows.Count == 0)
        {
            ShowAlertMessage("!!!!!هذا التقرير لا يوجد به بيانات للعرض !!!!");
            return;
        }
        else
        {
            rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report");
        }
        //DelayProjectsReport();
        //Label2.Text = Page.Title;
        //string user = Session_CS.pmp_name.ToString();
        //ReportDocument rd = new ReportDocument();
        //string s = Server.MapPath("../Reports/DelayProjects.rpt");
        //rd.Load(s);
        //Reports.Load_Report(rd);

        //rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
        //rd.SetParameterValue("@user", user, "footerRep.rpt");
        //if (rd.Rows.Count == 0)
        //{
        //    ShowAlertMessage("!!!!!هذا التقرير لا يوجد به بيانات للعرض !!!!");
        //    return;
        //}
        //else
        //{
        //    rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report");
        //}

    }
    protected void Files_No_Size_Click(object sender, EventArgs e)
    {
        hidden_Rpt_Id.Value = "ProjectDocFiles_Report";
        Div_Proj.Style.Add("display", "none");
        Div_Proj_Mngr.Style.Add("display", "none");
        Div_Date_Needs.Style.Add("display", "none");
        Div_Dates_Demands.Style.Add("display", "none");
        Div_Dept.Style.Add("display", "block");
        show_hide_tables();
        Div_Date_balance.Style.Add("display", "none");
        Page.Title = "تقرير وثائق المشروعات ";
        Label6.Visible = false;
        Label2.Visible = true;
        Label2.Text = Page.Title;
    }
    protected void OrgProjectLink_Click(object sender, EventArgs e)
    {
        hidden_Rpt_Id.Value = "OrgProjectReport";
        Div_Proj.Style.Add("display", "none");
        Div_Proj_Mngr.Style.Add("display", "none");
        Div_Date_balance.Style.Add("display", "none");
        Div_Date_Needs.Style.Add("display", "none");
        Div_Dates_Demands.Style.Add("display", "none");
        Div_Org.Style.Add("display", "block");
        //Div_Dept.Style.Add("display", "block");
        Div_technology_category.Style.Add("display", "none");
        Label6.Visible = false;
        Label2.Visible = true;

        show_hide_tables();
        Page.Title = "تقرير " + OrgProjectLink.Text;
        Label2.Text = Page.Title;
    }


    protected void SummryprojectLink_Click(object sender, EventArgs e)
    {
        hidden_Rpt_Id.Value = "SummryProjectReport";
        Div_Proj.Style.Add("display", "block");
        Div_Proj_Mngr.Style.Add("display", "none");
        Div_Date_balance.Style.Add("display", "none");
        Div_Date_Needs.Style.Add("display", "none");
        Div_Dates_Demands.Style.Add("display", "none");
        Div_Org.Style.Add("display", "none");
        //Div_Dept.Style.Add("display", "block");
        Div_technology_category.Style.Add("display", "none");
        Label6.Visible = false;
        Label2.Visible = true;
        show_hide_tables();
        Page.Title = "تقرير " + SummryprojectLink.Text;
        Label2.Text = Page.Title;
    }
    protected void proj_people_services_Click(object sender, EventArgs e)
    {
        hidden_Rpt_Id.Value = "proj_people_services";

        Div_Proj.Style.Add("display", "none");
        Div_Proj_Mngr.Style.Add("display", "none");
        Div_Date_Needs.Style.Add("display", "none");
        Div_Dates_Demands.Style.Add("display", "none");
        Div_Dept.Style.Add("display", "block");
        Div_Date_balance.Style.Add("display", "none");
        show_hide_tables();
        Label6.Visible = false;
        Page.Title = "تقرير " + proj_people_serv.Text;
        Label2.Text = Page.Title;







    }


  

    protected void DeptProjectLink_Click(object sender, EventArgs e)
    {
        hidden_Rpt_Id.Value = "DeptProjectReport";
        Div_Proj.Style.Add("display", "none");
        Div_Proj_Mngr.Style.Add("display", "none");
        Div_Date_balance.Style.Add("display", "none");
        Div_Date_Needs.Style.Add("display", "none");
        Div_Dates_Demands.Style.Add("display", "none");
        Div_Org.Style.Add("display", "none");
        Div_Dept.Style.Add("display", "block");
        Div_technology_category.Style.Add("display", "none");
        Label6.Visible = false;
        Label2.Visible = true;

        show_hide_tables();
        Page.Title = "تقرير " + DeptProjectLink.Text;
        Label2.Text = Page.Title;
    }


}
