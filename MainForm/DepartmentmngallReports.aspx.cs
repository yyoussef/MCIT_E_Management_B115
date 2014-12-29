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
using DBL;
using activityLeveling;
using ReportsClass;


public partial class WebForms_DepartmentmngallReports : System.Web.UI.Page
{
    Session_CS Session_CS = new Session_CS();
    string sql;
    SqlConnection conn;
    SqlDataAdapter da;
    DataSet ds;
    //private cBrowser obj_Browserdept, obj_Browsermanage;
    private string sql_Connection = Universal.GetConnectionString();
    string InsideMCIT = System.Configuration.ConfigurationManager.AppSettings["InsideMCIT"].ToString();


    protected void Page_Load(object sender, EventArgs e)
    {
        conn = new SqlConnection(sql_Connection);
        if (Session_CS.pmp_name != null)
        {
            if (!IsPostBack)
            {
                Smrt_srch_dept.Show_OrgTree = true;
                // ImageButtonmanage.Attributes.Add("OnClick", this.obj_Browsermanage.ClientSideFunction);
                //if (int.Parse(Session_CS.pmp_id.ToString()) == 492)
                //{
                //    surprise.Visible = true;
                //}
                int dept_id = int.Parse(Session_CS.dept_id.ToString());
                int pmp = int.Parse(Session_CS.pmp_id.ToString());

                sql = "select id,proj_Classification from Classification";
                ds = new DataSet();
                da = new SqlDataAdapter(sql, conn);
                da.Fill(ds, "Classification");
                Drop_cat.DataSource = ds.Tables[0];
                Drop_cat.DataValueField = "id";
                Drop_cat.DataTextField = "proj_Classification";
                Drop_cat.DataBind();
                Drop_cat.Items.Insert(0, new ListItem("اختر الخطة التابع لها......", "0"));

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

                //////////////////// get dates from store to drop list /////////////////////////////
                sql = "select id,convert(datetime,available_Date,103) as Date,available_Date from Store";
                ds = new DataSet();
                da = new SqlDataAdapter(sql, conn);
                da.Fill(ds, "dates");
                DropDate.DataSource = ds.Tables[0];
                DropDate.DataValueField = "Date";
                DropDate.DataTextField = "available_Date";
                DropDate.DataBind();
                DropDate.Items.Insert(0, new ListItem("اختر تاريخ الصرف المطلوب......", "0"));
                /////////////////////////////////// get category from tabel to drop list /////////////////////
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
                if (pmp == 28)
                {
                    activities_tr.Visible = false;
                    FinanceTr.Visible = false;
                    Label1.Text = "التقارير ";
                }

            }

        }

    }
    public string get_data_for_projects()
    {
        sql = "SELECT Project.Proj_id, Project.Proj_Title, Project.internal_external, Project.pmp_pmp_id, Project.Dept_Dept_id, Project.Class_id FROM         Departments RIGHT OUTER JOIN  Project LEFT OUTER JOIN  EMPLOYEE ON Project.pmp_pmp_id = EMPLOYEE.PMP_ID ON Departments.Dept_ID = Project.Dept_Dept_id where 1=1 ";
        if (Smrt_srch_dept.SelectedValue != "")
        {
            sql += "AND dbo.Project.Dept_Dept_id=  " + CDataConverter.ConvertToInt(Smrt_srch_dept.SelectedValue);
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
        return sql;
    }
    protected void Drop_cat_SelectedIndexChanged(object sender, EventArgs e)
    {

        Smart_Search_Proj.sql_Connection = sql_Connection;
        //Smart_Search_Proj.Query = "SELECT Project.Proj_id, Project.Proj_Title FROM Project LEFT OUTER JOIN Project_Classification ON Project.Proj_id = Project_Classification.proj_id where 1=1 and Project_Classification.proj_Classification_id= " + Drop_cat.SelectedValue;
      //  Smart_Search_Proj.Query = get_data_for_projects();
        Smart_Search_Proj.datatble = General_Helping.GetDataTable(get_data_for_projects());
        Smart_Search_Proj.Value_Field = "proj_id";
        Smart_Search_Proj.Text_Field = "proj_title";
        Smart_Search_Proj.DataBind();
        //this.Smart_proj.Value_Handler += new Smart_Search.Delegate_Selected_Value(show_tr);

    }
    protected void Drop_type_SelectedIndexChanged(object sender, EventArgs e)
    {

        Smart_Search_Proj.sql_Connection = sql_Connection;
        //Smart_Search_Proj.Query = "SELECT Project.Proj_id, Project.Proj_Title FROM Project LEFT OUTER JOIN Project_Classification ON Project.Proj_id = Project_Classification.proj_id where 1=1 and Project_Classification.proj_Classification_id= " + Drop_cat.SelectedValue;
      //  Smart_Search_Proj.Query = get_data_for_projects();
        Smart_Search_Proj.datatble = General_Helping.GetDataTable(get_data_for_projects());
        Smart_Search_Proj.Value_Field = "proj_id";
        Smart_Search_Proj.Text_Field = "proj_title";
        Smart_Search_Proj.DataBind();
        //this.Smart_proj.Value_Handler += new Smart_Search.Delegate_Selected_Value(show_tr);

    }
    protected override void OnInit(EventArgs e)
    {
        #region BROWSER FOR projects_Projmange

        Smrt_Srch_projmanage.sql_Connection = sql_Connection;
       // Smrt_Srch_projmanage.Query = "SELECT DISTINCT dbo.EMPLOYEE.pmp_name, dbo.EMPLOYEE.PMP_ID FROM  dbo.EMPLOYEE INNER JOIN  dbo.Project ON dbo.EMPLOYEE.PMP_ID = dbo.Project.pmp_pmp_id where EMPLOYEE.dept_dept_id = " + CDataConverter.ConvertToInt(Session_CS.dept_id.ToString());
        string Query = "SELECT DISTINCT dbo.EMPLOYEE.pmp_name, dbo.EMPLOYEE.PMP_ID FROM  dbo.EMPLOYEE INNER JOIN  dbo.Project ON dbo.EMPLOYEE.PMP_ID = dbo.Project.pmp_pmp_id where EMPLOYEE.dept_dept_id = " + CDataConverter.ConvertToInt(Session_CS.dept_id.ToString());
        Smrt_Srch_projmanage.datatble = General_Helping.GetDataTable(Query);
        Smrt_Srch_projmanage.Value_Field = "PMP_ID";
        Smrt_Srch_projmanage.Text_Field = "pmp_name";
        //Smart_Search1.Selected_Value = "1";
        Smrt_Srch_projmanage.DataBind();
        this.Smrt_Srch_projmanage.Value_Handler += new Smart_Search.Delegate_Selected_Value(MOnMember_Datamanage);
        Smart_Search_Proj.sql_Connection = sql_Connection;
      //  Smart_Search_Proj.Query = " select distinct proj_id,proj_title from dbo.Project where dept_dept_id= '" + int.Parse(Session_CS.dept_id.ToString()) + "' or dept_dept_id  in (select Dept_id  from EMPLOYEE_Departemnts where PMP_ID='" + int.Parse(Session_CS.pmp_id.ToString() )+ "')";
        Query = " select distinct proj_id,proj_title from dbo.Project where dept_dept_id= '" + int.Parse(Session_CS.dept_id.ToString()) + "' or dept_dept_id  in (select Dept_id  from EMPLOYEE_Departemnts where PMP_ID='" + int.Parse(Session_CS.pmp_id.ToString()) + "')";
        Smart_Search_Proj.datatble = General_Helping.GetDataTable(Query);
        Smart_Search_Proj.Value_Field = "proj_id";
        Smart_Search_Proj.Text_Field = "proj_title";
        //Smart_Search1.Selected_Value = "1";
        Smart_Search_Proj.DataBind();
        this.Smart_Search_Proj.Value_Handler += new Smart_Search.Delegate_Selected_Value(MonMember_Databudjet);

        //string strConString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();

        //obj_Sql_Con = new System.Data.SqlClient.SqlConnection(strConString);

        //obj_Sql_Con.Open();

        //#region BROWSER FOR departments

        //this.obj_Browsermanage = new cBrowser(this, "select distinct pmp_pmp_id , PTem_Name from dbo.Project_Team where rol_rol_id=4", "مديرين المشروعات", 5);

        //this.obj_Browsermanage.MAddField("PTem_Name", "اسم مدير المشروع", 150, BrowserFieldType.NIString);

        //this.obj_Browsermanage.ID = "obj_Browsermanage";

        //this.obj_Browsermanage.BrowseData += new BrowseDataEventHandler(MOnMember_Datamanage);

        this.Smart_Search_main.Value_Handler += new Smart_Search.Delegate_Selected_Value(MOnMember_subactivities);
        //Smart_Search_Proj.sql_Connection = sql_Connection;
        //Smart_Search_Proj.Query = "select proj_title,proj_id from project where Proj_is_commit=2";
        //Smart_Search_Proj.Value_Field = "proj_id";
        //Smart_Search_Proj.Text_Field = "proj_title";
        //Smart_Search_Proj.DataBind();

        #endregion
        Smrt_srch_dept.sql_Connection = sql_Connection;
        if (InsideMCIT == "1")
        {
            Query = "select distinct Dept_ID,Dept_name,Dept_parent_id from Employee_Departments WHERE PMP_ID='" + Session_CS.pmp_id.ToString() + "' and foundation_id='" + Session_CS.foundation_id + "' and sec_sec_id='"+Session_CS.sec_id+"'";
        }
        else
        {
            Query = "select distinct Dept_ID,Dept_name,Dept_parent_id from Employee_Departments WHERE PMP_ID='" + Session_CS.pmp_id.ToString() + "' and foundation_id='" + Session_CS.foundation_id + "' ";


        }

        Smrt_srch_dept.datatble = General_Helping.GetDataTable(Query);
        Smrt_srch_dept.Value_Field = "Dept_ID";
        Smrt_srch_dept.Text_Field = "Dept_name";
        Smrt_srch_dept.DataBind();

        base.OnInit(e);
    }

    private void MOnMember_Datamanage(string Value)
    {


        //Smrt_Srch_projmanage.SelectedValue = VArgs[0].ToString();
        //dropprojmanage_fun();
        Smart_Search_Proj.Clear_Controls();
        Smart_Search_Proj.sql_Connection = sql_Connection;
      //  Smart_Search_Proj.Query = "select proj_title,proj_id from project JOIN Project_Team ON Project.Proj_id = dbo.Project_Team.proj_proj_id  where  Project_Team.rol_rol_id = 4 and Project_Team.pmp_pmp_id= " + Value;
        string Query = "select proj_title,proj_id from project JOIN Project_Team ON Project.Proj_id = dbo.Project_Team.proj_proj_id  where  Project_Team.rol_rol_id = 4 and Project_Team.pmp_pmp_id= " + Value;
        Smart_Search_Proj.datatble = General_Helping.GetDataTable(Query);
        Smart_Search_Proj.Value_Field = "proj_id";
        Smart_Search_Proj.Text_Field = "proj_title";
        Smart_Search_Proj.DataBind();
        //if (Smart_Search_Proj.Items_Count == 0)
        //{
        //    Smart_Search_Proj.Clear_Controls();
        //}

    }
   
    public void MonMember_Databudjet(string Value)
    {

        getbudget_pmp();
    }

    //protected void dropprojmanage_fun()
    //{
    //    //int dept_id = int.Parse(Session_CS.dept_id.ToString());
    //    //SqlConnection conn = new SqlConnection(sql_Connection);
    //    if (Smrt_Srch_projmanage.SelectedValue != "")
    //    {
    //        //sql = "SELECT dbo.Project_Team.PTem_Name, dbo.Project_Team.rol_rol_id, dbo.Project_Team.proj_proj_id, dbo.Project_Team.pmp_pmp_id, dbo.Project.Proj_Title,dbo.Departments.Dept_ID";
    //        //sql += " FROM dbo.Project INNER JOIN dbo.Project_Team ON dbo.Project.Proj_id = dbo.Project_Team.proj_proj_id ";
    //        //sql += " INNER JOIN dbo.Departments ON dbo.Project.Dept_Dept_id = dbo.Departments.Dept_ID";
    //        //sql += " WHERE dbo.Project_Team.rol_rol_id = 4 AND dbo.Project_Team.pmp_pmp_id= " + Smrt_Srch_projmanage.SelectedValue;
    //        //ds = new DataSet();
    //        //da = new SqlDataAdapter(sql, conn);
    //        //da.Fill(ds, "projects");
    //        //DropProj.DataSource = ds.Tables[0];
    //        //DropProj.DataTextField = "Proj_Title";
    //        //DropProj.DataValueField = "proj_proj_id";
    //        //DropProj.DataBind();
    //        //DropProj.Items.Insert(0, new ListItem("اختر اسم المشروع......", "0"));
    //        Smart_Search_Proj.sql_Connection = sql_Connection;
    //        Smart_Search_Proj.Query = "select proj_title,proj_id from project JOIN Project_Team ON Project.Proj_id = dbo.Project_Team.proj_proj_id  where Proj_is_commit=2 and Project_Team.rol_rol_id = 4 and Project_Team.pmp_pmp_id= " + Smrt_Srch_projmanage.SelectedValue;
    //        Smart_Search_Proj.Value_Field = "proj_id";
    //        Smart_Search_Proj.Text_Field = "proj_title";
    //        Smart_Search_Proj.DataBind();
    //        if (Smart_Search_Proj.Items_Count <= 0)
    //        {
    //            Smart_Search_Proj.Clear_Controls();
    //        }

    //    }
    //    else
    //        Smart_Search_Proj.Clear_Controls();

    //    //else
    //    //{

    //    //    sql = "select Proj_id,Proj_Title,Dept_Dept_id from Project where Dept_Dept_id=" + dept_id;
    //    //    ds = new DataSet();
    //    //    da = new SqlDataAdapter(sql, conn);
    //    //    da.Fill(ds, "projects");
    //    //    DropProj.DataSource = ds.Tables[0];
    //    //    DropProj.DataTextField = "Proj_Title";
    //    //    DropProj.DataValueField = "Proj_id";
    //    //    DropProj.DataBind();
    //    //    DropProj.Items.Insert(0, new ListItem("اختر اسم المشروع......", "0"));
    //    //    Label6.Visible = false;
    //    //}
    //    Label6.Visible = false;

    //}

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


   
    protected void Smart_Search_Proj_SelectedIndexChanged(object sender, EventArgs e)
    {
        //getbudget_pmp();
        //Label6.Visible = false;
    }
    private void MOnMember_subactivities(string Value)
    {
        if (Value != "")
        {
            Smart_Search_sub.sql_Connection = sql_Connection;

          //  Smart_Search_sub.Query = "select PActv_ID, PActv_Desc from dbo.Project_Activities where PActv_Parent=" + Value;
            string Query = "select PActv_ID, PActv_Desc from dbo.Project_Activities where PActv_Parent=" + Value;
            Smart_Search_sub.datatble = General_Helping.GetDataTable(Query);
            Smart_Search_sub.Value_Field = "PActv_ID";
            Smart_Search_sub.Text_Field = "PActv_Desc";
            Smart_Search_sub.DataBind();
        }
    }
    public void getbudget_pmp()
    {
        conn = new SqlConnection(sql_Connection);
        if (Smart_Search_Proj.SelectedValue != "")
        {

            sql = "select proj_title,Proj_InitValue as Proj_InitValue_integer,ptem_name , proj_id from project join project_team on proj_id = proj_proj_id where rol_rol_id=4 and Proj_id=  " + Smart_Search_Proj.SelectedValue;
            ds = new DataSet();
            da = new SqlDataAdapter(sql, conn);
            da.Fill(ds, "project_data");
           
            if(ds.Tables[0].Rows.Count >0)
            {
                string name = ds.Tables[0].Rows[0]["ptem_name"].ToString();
                decimal budget = decimal.Parse(ds.Tables[0].Rows[0]["Proj_InitValue_integer"].ToString());
                Labname.Text = name;
                LabValue.Text = budget.ToString();
            }

       
           
            Smart_Search_main.sql_Connection = sql_Connection;
           // Smart_Search_main.Query = "select PActv_ID, Parent_PActv_Desc from dbo.Project_Activities where  PActv_Parent=0 and proj_proj_id=" + Smart_Search_Proj.SelectedValue;
            string Query = "select PActv_ID, Parent_PActv_Desc from dbo.Project_Activities where  PActv_Parent=0 and proj_proj_id=" + Smart_Search_Proj.SelectedValue;
            Smart_Search_main.datatble = General_Helping.GetDataTable(Query);
            Smart_Search_main.Value_Field = "PActv_ID";
            Smart_Search_main.Text_Field = "Parent_PActv_Desc";
            Smart_Search_main.DataBind();
            this.Smart_Search_main.Value_Handler += new Smart_Search.Delegate_Selected_Value(MOnMember_subactivities);
        }



    }
    
    protected void show_hide_tables()
    {
        tbl_Report.Style.Add("display", "none");
        tbl_Paramater.Style.Add("display", "block");
    }
    protected void IndicatortypeLBdeptMang_Click(object sender, EventArgs e)
    {

        show_hide_tables();

        hidden_Rpt_Id.Value = "IndicatorType_Report";

        Div_Proj.Style.Add("display", "block");
        Div_Proj_Mngr.Style.Add("display", "block");
        Div_Date_Needs.Style.Add("display", "none");
        Div_Dates_Demands.Style.Add("display", "none");
        Div_Date_balance.Style.Add("display", "none");
        Div_Dept.Style.Add("display", "none");
        Label2.Visible = true;

        Page.Title = "تقرير " + IndicatortypeLBdeptMang.Text;
        Label2.Text = Page.Title;
        Label6.Visible = false;



    }

    protected void Files_No_Click(object sender, EventArgs e)
    {

        //show_hide_tables();
        //int dept_id = int.Parse(Session_CS.dept_id.ToString());
        //hidden_Rpt_Id.Value = "Files_No_Report";

        //Div_Proj.Style.Add("display", "block");
        //Div_Proj_Mngr.Style.Add("display", "block");
        //Div_Date_Needs.Style.Add("display", "none");
        //Div_Dates_Demands.Style.Add("display", "none");
        //Div_Date_balance.Style.Add("display", "none");
        //Label2.Visible = true;

        //Page.Title = "تقرير " + Files_No.Text;
        //Label2.Text = Page.Title;
        //Label6.Visible = false;

        // string user = Session_CS.pmp_name.ToString();
        //ReportDocument rd = new ReportDocument();
        //string s = Server.MapPath("../Reports/Files_No.rpt");
        //rd.Load(s);
        //Load_Report(rd);

        //rd.SetParameterValue(0, dept_id);
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
        //int dept_id = int.Parse(Session_CS.dept_id.ToString());
        //hidden_Rpt_Id.Value = "Files_No_Report";

        //Div_Proj.Style.Add("display", "block");
        //Div_Proj_Mngr.Style.Add("display", "block");
        //Div_Date_Needs.Style.Add("display", "none");
        //Div_Dates_Demands.Style.Add("display", "none");
        //Div_Date_balance.Style.Add("display", "none");
        //Label2.Visible = true;

        //Page.Title = "تقرير " + ALL_Actions_No.Text;
        //Label2.Text = Page.Title;
        //Label6.Visible = false;

        //string user = Session_CS.pmp_name.ToString();
        //ReportDocument rd = new ReportDocument();
        //string s = Server.MapPath("../Reports/ALL_Actions_No.rpt");
        //rd.Load(s);
        //Load_Report(rd);

        //rd.SetParameterValue(0, dept_id);
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

    protected void PActivitiesPMLB_Click(object sender, EventArgs e)
    {
        hidden_Rpt_Id.Value = "ProjectActivities_Report";
        show_hide_tables();
        Div_Date_balance.Style.Add("display", "none");
        Div_Proj.Style.Add("display", "block");
        Div_Proj_Mngr.Style.Add("display", "block");
        Div_Date_Needs.Style.Add("display", "none");
        Div_Dates_Demands.Style.Add("display", "none");
        Div_Dept.Style.Add("display", "none");
        Div_classifications.Style.Add("display", "block");
        Div_type.Style.Add("display", "block");

        Page.Title = "تقرير " + PActivitiesPMLB.Text;
        Label2.Visible = true;
        Label2.Text = Page.Title;
        Label6.Visible = false;
    }
    protected void PFollowUpPMLB_Click(object sender, EventArgs e)
    {
        show_hide_tables();
        Div_Date_balance.Style.Add("display", "none");
        hidden_Rpt_Id.Value = "ProjectsFollowUP_Report";
        Div_Proj.Style.Add("display", "block");
        Div_Proj_Mngr.Style.Add("display", "none");
        Div_Date_Needs.Style.Add("display", "none");
        Div_Dates_Demands.Style.Add("display", "none");
        Div_Dept.Style.Add("display", "block");
        Div_month.Style.Add("display", "block");

        Label6.Visible = false;
        Page.Title = "تقرير " + PFollowUpPMLB.Text;
        Label2.Visible = true;
        Label2.Text = Page.Title;
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
        Div_Date_balance.Style.Add("display", "none");
        Div_Dept.Style.Add("display", "none");

        Label6.Visible = false;
        Label2.Visible = true;
        show_hide_tables();
        Page.Title = "تقرير " + EmployeeLB.Text;
        Label2.Text = Page.Title;

    }
    protected void projectsneedapproveLB_Click(object sender, EventArgs e)
    {
        hidden_Rpt_Id.Value = "projectsneedapprove_Report";
        Div_Proj.Style.Add("display", "none");
        Div_Proj_Mngr.Style.Add("display", "none");
        Div_Dates_Demands.Style.Add("display", "block");
        Div_Date_Needs.Style.Add("display", "none");
        Div_Date_balance.Style.Add("display", "none");
        Div_Dept.Style.Add("display", "none");

        Label6.Visible = false;
        Label2.Visible = true;
        show_hide_tables();
        Page.Title = "تقرير " + projectsneedapproveLB.Text;
        Label2.Text = Page.Title;



    }
    protected void projobjectiveLB_Click(object sender, EventArgs e)
    {
        hidden_Rpt_Id.Value = "projobjective_Report";
        Div_Proj.Style.Add("display", "block");
        Div_Proj_Mngr.Style.Add("display", "block");
        Div_Date_balance.Style.Add("display", "none");
        Div_Date_Needs.Style.Add("display", "none");
        Div_Dates_Demands.Style.Add("display", "none");
        Div_Dept.Style.Add("display", "none");

        Label6.Visible = false;
        Label2.Visible = true;

        show_hide_tables();
        Page.Title = "تقرير " + projobjectiveLB.Text;
        Label2.Text = Page.Title;


    }
    protected void projAchievmentLB_Click(object sender, EventArgs e)
    {
        hidden_Rpt_Id.Value = "projAchievment_Report";
        Div_Proj.Style.Add("display", "block");
        Div_Proj_Mngr.Style.Add("display", "block");
        Div_Date_balance.Style.Add("display", "none");
        Div_Date_Needs.Style.Add("display", "none");
        Div_Dates_Demands.Style.Add("display", "none");
        Div_Dept.Style.Add("display", "none");

        Label6.Visible = false;
        Label2.Visible = true;

        show_hide_tables();
        Page.Title = "تقرير " + projAchievmentLB.Text;
        Label2.Text = Page.Title;


    }
    
    protected void projneedsLB_Click(object sender, EventArgs e)
    {


    }
    protected void weightpercentageLB_Click(object sender, EventArgs e)
    {

    }



    protected void PDemandsLB_Click(object sender, EventArgs e)
    {
        hidden_Rpt_Id.Value = "ProjectDemands_Report";
        Div_Proj.Style.Add("display", "none");
        Div_Proj_Mngr.Style.Add("display", "none");
        Div_Dates_Demands.Style.Add("display", "block");
        Div_Date_Needs.Style.Add("display", "none");
        Div_Date_balance.Style.Add("display", "none");
        Div_Dept.Style.Add("display", "none");

        show_hide_tables();
        Label2.Visible = true;
        Label6.Visible = false;
        Page.Title = "تقرير " + PDemandsLB.Text;
        Label2.Text = Page.Title;


    }
    protected void PDemandsLB_Req_date_Click(object sender, EventArgs e)
    {
        hidden_Rpt_Id.Value = "ProjectDemands_ReqDate_Report";
        Div_Proj.Style.Add("display", "none");
        Div_Proj_Mngr.Style.Add("display", "none");
        Div_Dates_Demands.Style.Add("display", "block");
        Div_Date_Needs.Style.Add("display", "none");
        Div_Date_balance.Style.Add("display", "none");
        Div_Dept.Style.Add("display", "none");

        Label11.Text = "تاريخ طلب الاحتياج من ";
        Label12.Text = " تاريخ طلب الاحتياج الي";
        show_hide_tables();
        Label2.Visible = true;
        Label6.Visible = false;
        Page.Title = "تقرير " + PDemandsLB_Req_date.Text;
        Label2.Text = Page.Title;


    }
    protected void TextBox2_TextChanged(object sender, EventArgs e)
    {

    }
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {

    }
    protected void commitedandRefusedProjectsLB_Click(object sender, EventArgs e)
    {
        int dept_id = int.Parse(Session_CS.dept_id.ToString());
        int pmp = int.Parse(Session_CS.pmp_id.ToString());
        SqlConnection conn = new SqlConnection(sql_Connection);
        //hidden_Rpt_Id.Value = "commitedandRefusedProjects_Report";
        Div_Proj.Style.Add("display", "none");
        Div_Proj_Mngr.Style.Add("display", "none");
        Div_Date_Needs.Style.Add("display", "none");
        Div_Dates_Demands.Style.Add("display", "none");
        Div_Date_balance.Style.Add("display", "none");
        Div_Dept.Style.Add("display", "none");

        show_hide_tables();
        Label6.Visible = false;
        Label2.Visible = true;

        Page.Title = "تقرير " + commitedandRefusedProjectsLB.Text;
        Label2.Text = Page.Title;

        DataTable DT = General_Helping.GetDataTable("select dept_id from EMPLOYEE_Departemnts where pmp_id=" + pmp);
        string sql = "SELECT dbo.Departments.Dept_ID, dbo.Departments.Dept_name, dbo.Project.Proj_id, dbo.Project.Proj_Title, dbo.Project.Proj_is_commit, convert(datetime,dbo.Project.Proj_Creation_Date,103) as  Proj_Creation_Date , dbo.Project.Proj_InitValue FROM dbo.Departments INNER JOIN dbo.Project ON dbo.Departments.Dept_ID = dbo.Project.Dept_Dept_id ";
        sql += " where dept_id = " + dept_id;
        if (DT.Rows.Count > 1)
        {
            for (int i = 0; i < DT.Rows.Count; i++)
            {
                sql += " or dept_id = " + CDataConverter.ConvertToInt(DT.Rows[i]["dept_id"].ToString());
            }
        }
        sql += " order by dbo.Project.Proj_Creation_Date,Dept_name,Proj_Title";
        DataTable DT_Report = General_Helping.GetDataTable(sql);
        string user = Session_CS.pmp_name.ToString();
        ReportDocument rd = new ReportDocument();
        string s = Server.MapPath("../Reports/commitedandRefusedProjects.rpt");
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
            rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report");
        }





    }
    protected void ALL_Act_Actions_No_Click(object sender, EventArgs e)
    {
        int dept_id = int.Parse(Session_CS.dept_id.ToString());
        int pmp = int.Parse(Session_CS.pmp_id.ToString());
        SqlConnection conn = new SqlConnection(sql_Connection);
        //hidden_Rpt_Id.Value = "commitedandRefusedProjects_Report";
        DataTable DT = General_Helping.GetDataTable("select dept_id from EMPLOYEE_Departemnts where pmp_id=" + pmp);

        string sql = "SELECT Project.proj_id,Project.Proj_Title, Departments.Dept_name, Project.Dept_Dept_id , Project.Pmp_pmp_id , employee.pmp_name,(select COUNT(Project_Activities.proj_proj_id) from Project_Activities where Project_Activities.proj_proj_id=project.Proj_id AND PActv_Parent=0) as  Parent_Act_Count,(select COUNT(Project_Activities.proj_proj_id) from Project_Activities where Project_Activities.proj_proj_id=project.Proj_id AND PActv_Parent<>0) as  child_Act_Count,(select COUNT(Project_Needs.proj_proj_id) from Project_Needs where Project_Needs.proj_proj_id=project.Proj_id ) as Pneeds,(select COUNT(Project_Objective.proj_proj_id) from Project_Objective where Project_Objective.proj_proj_id=project.Proj_id ) as proj_obj,(select COUNT(Project_Team.proj_proj_id) from Project_Team where Project_Team.proj_proj_id=project.Proj_id ) as proj_team,(select COUNT(Project_Organization.proj_proj_id) from Project_Organization where Project_Organization.proj_proj_id=project.Proj_id ) as proj_org FROM Departments INNER JOIN Project ON Departments.Dept_ID = Project.Dept_Dept_id LEFT OUTER JOIN employee on project.pmp_pmp_id=employee.pmp_id";
        sql += " where dept_id = " + dept_id;
        if (DT.Rows.Count > 1)
        {
            for (int i = 0; i < DT.Rows.Count; i++)
            {
                sql += " or dept_id = " + CDataConverter.ConvertToInt(DT.Rows[i]["dept_id"].ToString());
            }
        }

        Div_Proj.Style.Add("display", "none");
        Div_Proj_Mngr.Style.Add("display", "none");
        Div_Date_Needs.Style.Add("display", "none");
        Div_Dates_Demands.Style.Add("display", "none");
        Div_Date_balance.Style.Add("display", "none");
        Div_Dept.Style.Add("display", "none");

        show_hide_tables();
        Label6.Visible = false;
        Label2.Visible = true;

        Page.Title = "تقرير " + commitedandRefusedProjectsLB.Text;
        Label2.Text = Page.Title;
        DataTable DT_Report = General_Helping.GetDataTable(sql);


        string user = Session_CS.pmp_name.ToString();
        ReportDocument rd = new ReportDocument();
        string s = Server.MapPath("../Reports/ALL_Activities_Actions_NoParametr_Dept_manage.rpt");
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
            rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report");
        }





    }
    protected void CurrentProjectsLB_Click(object sender, EventArgs e)
    {
        //hidden_Rpt_Id.Value = "CurrentProjects_Report";
        //int dept_id = int.Parse(Session_CS.dept_id.ToString());
        //Div_Proj.Style.Add("display", "none");
        //Div_Proj_Mngr.Style.Add("display", "none");
        //Div_Date_Needs.Style.Add("display", "none");
        //Div_Dates_Demands.Style.Add("display", "none");
        //Div_Date_balance.Style.Add("display", "none");

        ////show_hide_tables();
        //Label2.Visible = true;
        //Label6.Visible = false;
        //Page.Title = "تقرير " + CurrentProjectsLB.Text;
        //Label2.Text = Page.Title;
        ///////////////////////////////////////////////////////////// current projects Report ///////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //SqlConnection conn = new SqlConnection(sql_Connection);


        //string user = Session_CS.pmp_name.ToString();
        //ReportDocument rd = new ReportDocument();
        //string s = Server.MapPath("../Reports/CurrentProjects.rpt");
        //rd.Load(s);
        //Load_Report(rd);

        //rd.SetParameterValue(0, dept_id);
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
    protected void ProjectsEmloyeesLB_Click(object sender, EventArgs e)
    {
        int dept_id = int.Parse(Session_CS.dept_id.ToString());
        int pmp = int.Parse(Session_CS.pmp_id.ToString());
        SqlConnection conn = new SqlConnection(sql_Connection);
        hidden_Rpt_Id.Value = "ProjectsEmployees_Report";
        Div_Proj.Style.Add("display", "none");
        Div_Proj_Mngr.Style.Add("display", "noe");
        Div_Date_Needs.Style.Add("display", "none");
        Div_Dates_Demands.Style.Add("display", "none");
        Div_Date_balance.Style.Add("display", "none");
        Div_Dept.Style.Add("display", "none");

        show_hide_tables();
        Label2.Visible = true;
        Label6.Visible = false;
        Page.Title = "تقرير " + ProjectsEmloyeesLB.Text;
        Label2.Text = Page.Title;
        DataTable DT = General_Helping.GetDataTable("select dept_id from EMPLOYEE_Departemnts where pmp_id=" + pmp);
        string sql_Report = "SELECT TOP (100) PERCENT dbo.Project_Team.PTem_Name, dbo.Project_Team.PTem_Task_Cat, dbo.JOB_TITLE.JTIT_Desc, dbo.Project.Proj_Title, dbo.Project.Proj_id,dbo.Departments.Dept_name, dbo.Departments.Dept_ID, dbo.Project_Team.pmp_pmp_id FROM dbo.Project INNER JOIN dbo.Departments ON dbo.Project.Dept_Dept_id = dbo.Departments.Dept_ID INNER JOIN dbo.Project_Team ON dbo.Project.Proj_id = dbo.Project_Team.proj_proj_id INNER JOIN dbo.JOB_TITLE INNER JOIN dbo.JOB ON dbo.JOB_TITLE.JTIT_ID = dbo.JOB.JTIT_JTIT_ID ON dbo.Project_Team.job_job_id = dbo.JOB.JOB_ID ";
        sql_Report += " where Dept_ID = " + dept_id;
        if (DT.Rows.Count > 1)
        {
            for (int i = 0; i < DT.Rows.Count; i++)
            {
                sql_Report += " or dept_id = " + CDataConverter.ConvertToInt(DT.Rows[i]["dept_id"].ToString());
            }
        }
        sql_Report += " order by dbo.Project_Team.PTem_Name";
        DataTable DT_Report = General_Helping.GetDataTable(sql_Report);
        string user = Session_CS.pmp_name.ToString();
        ReportDocument rd = new ReportDocument();
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
            rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report");
        }





    }
    protected void DropDep_SelectedIndexChanged(object sender, EventArgs e)
    {

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
    protected void Button1_Click(object sender, EventArgs e)
    {
        int dept_id = int.Parse(Session_CS.dept_id.ToString());
        int pmp = int.Parse(Session_CS.pmp_id.ToString());
        /////////////////////////////////////////////////////////// Indicator type Report ///////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        if (hidden_Rpt_Id.Value == "IndicatorType_Report")
        {
            SqlConnection conn = new SqlConnection(sql_Connection);
            DataTable DT = General_Helping.GetDataTable("select dept_id from EMPLOYEE_Departemnts where pmp_id=" + pmp);
            ReportDocument rd = new ReportDocument();
            int proj_id = 0;
            int projmanage = 0;
            decimal budget = 0;
            string proj_name = "";
            string ptem_name = "";
            string dept_name = "";


            sql = "select * ,(Case When PActv_Parent=0 Then PActv_Desc Else null End)as parent,(Case When PActv_Parent=0 Then 0 Else null End) as Parent_Actv_Num,PActv_Parent as LVL from Project_Activities  join project on Project_Activities.proj_proj_id=project.proj_id join Departments on project.Dept_Dept_id=Departments.Dept_ID inner join Project_Activities_Indicators on Project_Activities.PActv_ID=Project_Activities_Indicators.pactv_pactv_id inner join Indicators_Type on Project_Activities_Indicators.indt_indt_id=Indicators_Type.IndT_id inner join Project_Activity_indicator_period on Project_Activities_Indicators.PAIP_period_id=Project_Activity_indicator_period.ID inner join Project_Activities_Indicators_History on Project_Activities_Indicators.PAI_ID=Project_Activities_Indicators_History.pai_pai_id  join Organization on Project_Activities.Excutive_responsible_Org_Org_id = Organization.org_id where 1=1";
            if (Smart_Search_Proj.SelectedValue != "")
            {
                proj_id = int.Parse(Smart_Search_Proj.SelectedValue);
                budget = decimal.Parse(LabValue.Text);
                proj_name = Smart_Search_Proj.Text_Field;
                ptem_name = Labname.Text;
                dept_name = Session_CS.dept.ToString();
                sql += " AND dbo.Project.Proj_id=" + proj_id;

            }
            if (Smrt_Srch_projmanage.SelectedValue != "")
            {
                projmanage = int.Parse(Smrt_Srch_projmanage.SelectedValue);
                sql += " AND dbo.Project.pmp_pmp_id =" + projmanage;
            }


            sql += " AND dbo.Departments.Dept_ID = " + dept_id;
            if (DT.Rows.Count > 1)
            {
                for (int i = 0; i < DT.Rows.Count; i++)
                {
                    sql += " or dept_id = " + CDataConverter.ConvertToInt(DT.Rows[i]["dept_id"].ToString());
                }
            }
            sql += " ORDER BY dbo.Project.Proj_id,PActv_ID";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt_report = new DataTable();
            da.Fill(dt_report);
            string user = Session_CS.pmp_name.ToString();
            string s = Server.MapPath("../Reports/Indicator_Type_parameters.rpt");
            rd.Load(s);
            rd.SetDataSource(dt_report);
            Reports.Load_Report(rd);
           
            rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
            rd.SetParameterValue("@user", user, "footerRep.rpt");
            if (dt_report.Rows.Count == 0)
            {
                ShowAlertMessage("!!!!!هذا التقرير لا يوجد به بيانات للعرض !!!!");
                return;
            }
            else
            {
                rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report");
            }




        }
        if (hidden_Rpt_Id.Value == "Indicator_Development_Report")
        {
            SqlConnection conn = new SqlConnection(sql_Connection);

            ReportDocument rd = new ReportDocument();
            int proj_id = 0;
            int projmanage = 0;
            decimal budget = 0;
            string proj_name = "";
            string ptem_name = "";
            string dept_name = "";
            int pAct_id = 0;
           
            sql = "select * ,(Case When PActv_Parent=0 Then PActv_Desc Else null End)as parent,(Case When PActv_Parent=0 Then 0 Else null End) as Parent_Actv_Num,PActv_Parent as LVL from Project_Activities  join project on Project_Activities.proj_proj_id=project.proj_id join Departments on project.Dept_Dept_id=Departments.Dept_ID inner join Project_Activities_Indicators on Project_Activities.PActv_ID=Project_Activities_Indicators.pactv_pactv_id inner join Indicators_Type on Project_Activities_Indicators.indt_indt_id=Indicators_Type.IndT_id inner join Project_Activity_indicator_period on Project_Activities_Indicators.PAIP_period_id=Project_Activity_indicator_period.ID inner join Project_Activities_Indicators_History on Project_Activities_Indicators.PAI_ID=Project_Activities_Indicators_History.pai_pai_id  join Organization on Project_Activities.Excutive_responsible_Org_Org_id = Organization.org_id where 1=1";
            if (Smart_Search_Proj.SelectedValue != "")
            {
                proj_id = int.Parse(Smart_Search_Proj.SelectedValue);
                budget = decimal.Parse(LabValue.Text);
                proj_name = Smart_Search_Proj.Text_Field;
                ptem_name = Labname.Text;
                dept_name = Session_CS.dept.ToString();
                sql += " AND dbo.Project.Proj_id=" + proj_id;

            }
            if (Smrt_Srch_projmanage.SelectedValue != "")
            {
                projmanage = int.Parse(Smrt_Srch_projmanage.SelectedValue);
                sql += " AND dbo.project.pmp_pmp_id =" + projmanage;
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
            DataTable DT = General_Helping.GetDataTable("select dept_id from EMPLOYEE_Departemnts where pmp_id=" + pmp);

            //string sql = "SELECT Project.proj_id,Project.Proj_Title, Departments.Dept_name, Project.Dept_Dept_id , Project.Pmp_pmp_id , employee.pmp_name,(select COUNT(Project_Activities.proj_proj_id) from Project_Activities where Project_Activities.proj_proj_id=project.Proj_id AND PActv_Parent=0) as  Parent_Act_Count,(select COUNT(Project_Activities.proj_proj_id) from Project_Activities where Project_Activities.proj_proj_id=project.Proj_id AND PActv_Parent<>0) as  child_Act_Count,(select COUNT(Project_Needs.proj_proj_id) from Project_Needs where Project_Needs.proj_proj_id=project.Proj_id ) as Pneeds,(select COUNT(Project_Objective.proj_proj_id) from Project_Objective where Project_Objective.proj_proj_id=project.Proj_id ) as proj_obj,(select COUNT(Project_Team.proj_proj_id) from Project_Team where Project_Team.proj_proj_id=project.Proj_id ) as proj_team,(select COUNT(Project_Organization.proj_proj_id) from Project_Organization where Project_Organization.proj_proj_id=project.Proj_id ) as proj_org FROM Departments INNER JOIN Project ON Departments.Dept_ID = Project.Dept_Dept_id LEFT OUTER JOIN employee on project.pmp_pmp_id=employee.pmp_id";


            sql += " AND dbo.Departments.Dept_ID = " + dept_id;
            if (DT.Rows.Count > 1)
            {
                for (int i = 0; i < DT.Rows.Count; i++)
                {
                    sql += " or dept_id = " + CDataConverter.ConvertToInt(DT.Rows[i]["dept_id"].ToString());
                }
            }
            sql += " ORDER BY dbo.Project.Proj_id";


            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt_report = new DataTable();
            da.Fill(dt_report);
            string user = Session_CS.pmp_name.ToString();
            string s = Server.MapPath("../Reports/Indicator_Development.rpt");
            rd.Load(s);
            rd.SetDataSource(dt_report);
            Reports.Load_Report(rd);
            //rd.SetParameterValue(0, proj_id);
            //rd.SetParameterValue(1, projmanage);
            //rd.SetParameterValue(2, dept_id);
            rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
            rd.SetParameterValue("@user", user, "footerRep.rpt");
            if (dt_report.Rows.Count == 0)
            {
                ShowAlertMessage("!!!!!هذا التقرير لا يوجد به بيانات للعرض !!!!");
                return;
            }
            else
            {
                rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report");
            }




        }
        ////////////////////////////////////////////////////////////////////////// Employees in projetcs Report /////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        else if (hidden_Rpt_Id.Value == "Employees_Report")
        {
            SqlConnection conn = new SqlConnection(sql_Connection);
            DataTable DT = General_Helping.GetDataTable("select dept_id from EMPLOYEE_Departemnts where pmp_id=" + pmp);
            int proj_id = 0;
            decimal budget = 0;
            string proj_name = "";
            string ptem_name = "";
            string dept_name = "";

            sql = "SELECT dbo.Project.Proj_id, dbo.Project.Proj_Title, dbo.Departments.Dept_name,dbo.Departments.Dept_id, dbo.JOB_TITLE.JTIT_Desc, dbo.Project.Proj_InitValue, dbo.Project_Team.PTem_Name,";
            sql += " dbo.Project_Team.pmp_pmp_id,";
            sql += " dbo.Project_Team.rol_rol_id,PTem_Task";
            sql += " FROM dbo.Project INNER JOIN";
            sql += " dbo.Departments ON dbo.Project.Dept_Dept_id = dbo.Departments.Dept_ID INNER JOIN";
            sql += " dbo.Project_Team ON dbo.Project.Proj_id = dbo.Project_Team.proj_proj_id INNER JOIN";
            sql += " dbo.JOB_TITLE INNER JOIN";
            sql += " dbo.JOB ON dbo.JOB_TITLE.JTIT_ID = dbo.JOB.JTIT_JTIT_ID ON dbo.Project_Team.job_job_id = dbo.JOB.JOB_ID";
            sql += " where 1=1";


            string user = Session_CS.pmp_name.ToString();

            if (Smart_Search_Proj.SelectedValue != "")
            {
                proj_id = int.Parse(Smart_Search_Proj.SelectedValue);
                budget = decimal.Parse(LabValue.Text);
                proj_name = Smart_Search_Proj.Text_Field;
                ptem_name = Labname.Text;
                dept_name = Session_CS.dept.ToString();
                sql += " AND dbo.Project.Proj_id = " + proj_id;

            }

            sql += " AND dbo.Departments.Dept_id =" + dept_id;
            if (DT.Rows.Count > 1)
            {
                for (int i = 0; i < DT.Rows.Count; i++)
                {
                    sql += " or dept_id = " + CDataConverter.ConvertToInt(DT.Rows[i]["dept_id"].ToString());
                }
            }
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt_report = new DataTable();
            da.Fill(dt_report);

            ReportDocument rd = new ReportDocument();
            string s = Server.MapPath("../Reports/Work_emp_proj.rpt");
            rd.Load(s);
            rd.SetDataSource(dt_report);
            Reports.Load_Report(rd);

            rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
            rd.SetParameterValue("@user", user, "footerRep.rpt");
            if (dt_report.Rows.Count == 0)
            {
                ShowAlertMessage("هذا التقرير لا يوجد به بيانات للعرض !!!!");
                return;
            }
            else
            {
                rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report");
            }



        }



            /////////////////////////////////////////////////////Existence Employees////////////////////////
            ///////////////////////////////////////////////////////////////////////////////////////////////
        else if (hidden_Rpt_Id.Value == "Existence_Emp")
        {
            SqlConnection conn = new SqlConnection(sql_Connection);
            if (Smrt_srch_dept.SelectedValue != "")
            {
                dept_id = int.Parse(Smrt_srch_dept.SelectedValue);
                sql = "select case when (EMPLOYEE.PMP_ID  in (select  user_id  from Vacations_users where convert(datetime, end_date,103) >=  convert(datetime,convert(int,GETDATE()))  and convert(datetime, start_date,103) <= convert(datetime,convert(int,GETDATE())))) then '  أجازة '  when (EMPLOYEE.PMP_ID  in (select  user_id  from Vacations_errand where convert(datetime, end_date,103) >=  convert(datetime,convert(int,GETDATE()))  and convert(datetime, start_date,103) <= convert(datetime,convert(int,GETDATE())))) then '  مأمورية' else 'متواجد ' end as status,EMPLOYEE.PMP_ID,EMPLOYEE.pmp_name,Departments.Dept_ID,Departments.Dept_name from EMPLOYEE inner join Departments on Departments.Dept_ID=EMPLOYEE.Dept_Dept_id where Departments.Dept_ID='" + dept_id + "' order by status";

               
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                ReportDocument rd = new ReportDocument();
                string user = Session_CS.pmp_name.ToString();

                string s = Server.MapPath("../Reports/existance_emp.rpt");
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
            else
            {
                ShowAlertMessage(" يجب إختيار إدارة لعرض هذا التقرير!!!!");
                return;
            }
        }



        /////////////////////////////////////////////////////////// project activities Report ///////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        else if (hidden_Rpt_Id.Value == "ProjectActivities_Report")
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
                   
                    
                    dt = ActivLevls.leveling(proj_id, CDataConverter.ConvertToInt(Session_CS.dept_id.ToString()),0, 0, 0);
                   
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
        else if (hidden_Rpt_Id.Value == "ProjectDemands_Report")
        {
            //ReportDocument rd = new ReportDocument();
            string t1 = "";
            string t2 = "";


            string user = Session_CS.pmp_name.ToString();


            SqlConnection conn = new SqlConnection(sql_Connection);
            //////////////////////////////////////////////////////////////// MOATAZ work 1/////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            sql = " set dateformat dmy select pmp_name,need_Serial,Pned_name,approved_amount,PNed_Number,PNed_ID,convert(datetime,dbo.datevalid(dbo.project_needs.PNed_Date)) as PNed_Date,";
            sql += " Proj_Title,Proj_id,TotalDelievered,Dept_id,Dept_name ";
            sql += " from ";
            sql += " project_needs join Project on project_needs.Proj_proj_id = project.Proj_id  ";
            sql += " inner join employee on Project.pmp_pmp_id = EMPLOYEE.PMP_ID   ";
            sql += " inner join Departments on Project.Dept_Dept_id = Departments.Dept_id  ";
            sql += " where 1=1 ";




            //hidden_Rpt_Id.Value = "commitedandRefusedProjects_Report";
            DataTable DT = General_Helping.GetDataTable("select dept_id from EMPLOYEE_Departemnts where pmp_id=" + pmp);

            //string sql = "SELECT Project.proj_id,Project.Proj_Title, Departments.Dept_name, Project.Dept_Dept_id , Project.Pmp_pmp_id , employee.pmp_name,(select COUNT(Project_Activities.proj_proj_id) from Project_Activities where Project_Activities.proj_proj_id=project.Proj_id AND PActv_Parent=0) as  Parent_Act_Count,(select COUNT(Project_Activities.proj_proj_id) from Project_Activities where Project_Activities.proj_proj_id=project.Proj_id AND PActv_Parent<>0) as  child_Act_Count,(select COUNT(Project_Needs.proj_proj_id) from Project_Needs where Project_Needs.proj_proj_id=project.Proj_id ) as Pneeds,(select COUNT(Project_Objective.proj_proj_id) from Project_Objective where Project_Objective.proj_proj_id=project.Proj_id ) as proj_obj,(select COUNT(Project_Team.proj_proj_id) from Project_Team where Project_Team.proj_proj_id=project.Proj_id ) as proj_team,(select COUNT(Project_Organization.proj_proj_id) from Project_Organization where Project_Organization.proj_proj_id=project.Proj_id ) as proj_org FROM Departments INNER JOIN Project ON Departments.Dept_ID = Project.Dept_Dept_id LEFT OUTER JOIN employee on project.pmp_pmp_id=employee.pmp_id";
            sql += " AND dept_id = " + dept_id;
            if (DT.Rows.Count > 1)
            {
                for (int i = 0; i < DT.Rows.Count; i++)
                {
                    sql += " or dept_id = " + CDataConverter.ConvertToInt(DT.Rows[i]["dept_id"].ToString());
                }
            }
            //sql += " AND Departments.Dept_id = '" + dept_id + "'";
            if (string.IsNullOrEmpty(TextBox1.Text) && string.IsNullOrEmpty(TextBox2.Text))
            {

                t1 = DateTime.ParseExact("01/01/1900", "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
                t2 = DateTime.MaxValue.ToString("dd/MM/yyyy");
                //sql += " AND convert(datetime,dbo.datevalid(dbo.project_needs.PNed_Date)) > = '" + t1.ToString() + "'";
                //sql += " AND convert(datetime,dbo.datevalid(dbo.project_needs.PNed_Date)) < = '" + t2.ToString() + "'";
            }
            else if (string.IsNullOrEmpty(TextBox1.Text))
            {
                if (TextBox2.Text.Trim() != "")

                  //  if (VB_Classes.Dates.Dates_Operation.date_validate(TextBox2.Text.Trim()) != "")
                {
                    t1 = DateTime.ParseExact("01/01/1900", "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
                    //t2 = DateTime.ParseExact(Inbox_date_to.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
                    t2 = TextBox2.Text.Trim();
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

                if (TextBox1.Text.Trim() != "")

                 //   if (VB_Classes.Dates.Dates_Operation.date_validate(TextBox1.Text.Trim()) != "")
                {
                    //t1 = DateTime.ParseExact(Inbox_date_from.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
                    t2 = DateTime.MaxValue.ToString("dd/MM/yyyy");
                    t1 = TextBox1.Text.Trim();

                    //t1 = VB_Classes.Dates.Dates_Operation.date_validate(TextBox1.Text.Trim());
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
                if (TextBox2.Text.Trim() != "" && TextBox1.Text.Trim() != "")

                //    if (VB_Classes.Dates.Dates_Operation.date_validate(TextBox2.Text.Trim()) != "" && VB_Classes.Dates.Dates_Operation.date_validate(TextBox1.Text.Trim()) != "")
 
                {
                    //t1 = DateTime.ParseExact(Inbox_date_from.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
                    t2 = TextBox2.Text.Trim();

                  //  t2 = VB_Classes.Dates.Dates_Operation.date_validate(TextBox2.Text.Trim());
                    //t2 = DateTime.ParseExact(Inbox_date_to.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
                  //  t1 = VB_Classes.Dates.Dates_Operation.date_validate(TextBox1.Text.Trim());

                    t1 = TextBox1.Text.Trim();
                    sql += " AND convert(datetime,dbo.datevalid(dbo.project_needs.PNed_Date)) > = '" + t1.ToString() + "'";
                    sql += " AND convert(datetime,dbo.datevalid(dbo.project_needs.PNed_Date)) < = '" + t2.ToString() + "'";
                }
                else
                {
                    ShowAlertMessage("!!!!!ادخل التاريخ بطريقة صحيحة !!!!");
                    return;
                }


            }
            DateTime date1 = DateTime.ParseExact(t1, "dd/MM/yyyy", null);
            DateTime date2 = DateTime.ParseExact(t2, "dd/MM/yyyy", null);
            if (date2.Subtract(date1).Days < 0)
            {
                Label6.Text = "التاريخ الاول يجب ان يكون قبل التاريخ الثاني  !!!!";
                return;
            }



            sql += "order by Proj_Title, employee.pmp_name,need_Serial ";

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            ReportDocument rd = new ReportDocument();

            if (dt.Rows.Count == 0)
            {

                ShowAlertMessage("!!!!!هذا التقرير لا يوجد به بيانات للعرض !!!!");
                return;

            }
            else
            {


                string s = Server.MapPath("../Reports/PDemands_Approve.rpt");
                rd.Load(s);
                rd.SetDataSource(dt);

                rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
                rd.SetParameterValue("@user", user, "footerRep.rpt");
                rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report.rpt");


            }


        }
        /////////////////////////////////////////////////////////// project Demands Report arranged by Requested date ///////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        else if (hidden_Rpt_Id.Value == "ProjectDemands_ReqDate_Report")
        {
            //ReportDocument rd = new ReportDocument();
            string t1 = "";
            string t2 = "";


            string user = Session_CS.pmp_name.ToString();


            SqlConnection conn = new SqlConnection(sql_Connection);
            //////////////////////////////////////////////////////////////// MOATAZ work 1/////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            sql = " set dateformat dmy select pmp_name,need_Serial,Pned_name,approved_amount,PNed_Number,PNed_ID,convert(datetime,dbo.datevalid(dbo.project_needs.PNed_Date)) as PNed_Date, convert(datetime,dbo.datevalid(dbo.project_needs.Request_DT)) as Request_DT,";
            sql += " Proj_Title,Proj_id,TotalDelievered,Dept_id,Dept_name ";
            sql += " from ";
            sql += " project_needs join Project on project_needs.Proj_proj_id = project.Proj_id  ";
            sql += " inner join employee on Project.pmp_pmp_id = EMPLOYEE.PMP_ID   ";
            sql += " inner join Departments on Project.Dept_Dept_id = Departments.Dept_id  ";
            sql += " where 1=1 ";




            //hidden_Rpt_Id.Value = "commitedandRefusedProjects_Report";
            DataTable DT = General_Helping.GetDataTable("select dept_id from EMPLOYEE_Departemnts where pmp_id=" + pmp);

            //string sql = "SELECT Project.proj_id,Project.Proj_Title, Departments.Dept_name, Project.Dept_Dept_id , Project.Pmp_pmp_id , employee.pmp_name,(select COUNT(Project_Activities.proj_proj_id) from Project_Activities where Project_Activities.proj_proj_id=project.Proj_id AND PActv_Parent=0) as  Parent_Act_Count,(select COUNT(Project_Activities.proj_proj_id) from Project_Activities where Project_Activities.proj_proj_id=project.Proj_id AND PActv_Parent<>0) as  child_Act_Count,(select COUNT(Project_Needs.proj_proj_id) from Project_Needs where Project_Needs.proj_proj_id=project.Proj_id ) as Pneeds,(select COUNT(Project_Objective.proj_proj_id) from Project_Objective where Project_Objective.proj_proj_id=project.Proj_id ) as proj_obj,(select COUNT(Project_Team.proj_proj_id) from Project_Team where Project_Team.proj_proj_id=project.Proj_id ) as proj_team,(select COUNT(Project_Organization.proj_proj_id) from Project_Organization where Project_Organization.proj_proj_id=project.Proj_id ) as proj_org FROM Departments INNER JOIN Project ON Departments.Dept_ID = Project.Dept_Dept_id LEFT OUTER JOIN employee on project.pmp_pmp_id=employee.pmp_id";
            sql += " AND dept_id = " + dept_id;
            if (DT.Rows.Count > 1)
            {
                for (int i = 0; i < DT.Rows.Count; i++)
                {
                    sql += " or dept_id = " + CDataConverter.ConvertToInt(DT.Rows[i]["dept_id"].ToString());
                }
            }
            //sql += " AND Departments.Dept_id = '" + dept_id + "'";
            if (string.IsNullOrEmpty(TextBox1.Text) && string.IsNullOrEmpty(TextBox2.Text))
            {

                t1 = DateTime.ParseExact("01/01/1900", "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
                t2 = DateTime.MaxValue.ToString("dd/MM/yyyy");
                //sql += " AND convert(datetime,dbo.datevalid(dbo.project_needs.PNed_Date)) > = '" + t1.ToString() + "'";
                //sql += " AND convert(datetime,dbo.datevalid(dbo.project_needs.PNed_Date)) < = '" + t2.ToString() + "'";
            }
            else if (string.IsNullOrEmpty(TextBox1.Text))
            {
                if (TextBox2.Text.Trim() != "")

                 //   if (VB_Classes.Dates.Dates_Operation.date_validate(TextBox2.Text.Trim()) != "")
                {
                    t1 = DateTime.ParseExact("01/01/1900", "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
                    //t2 = DateTime.ParseExact(Inbox_date_to.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");


                    t2 = TextBox2.Text.Trim();

                  //  t2 = VB_Classes.Dates.Dates_Operation.date_validate(TextBox2.Text.Trim());
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

                if (TextBox1.Text.Trim() != "")

                 //   if (VB_Classes.Dates.Dates_Operation.date_validate(TextBox1.Text.Trim()) != "")
                {
                    //t1 = DateTime.ParseExact(Inbox_date_from.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
                    t2 = DateTime.MaxValue.ToString("dd/MM/yyyy");
                    t1 = TextBox1.Text.Trim();

                   // t1 = VB_Classes.Dates.Dates_Operation.date_validate(TextBox1.Text.Trim());
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
                if (TextBox2.Text.Trim() != "" && TextBox1.Text.Trim() != "")

                 //   if (VB_Classes.Dates.Dates_Operation.date_validate(TextBox2.Text.Trim()) != "" && VB_Classes.Dates.Dates_Operation.date_validate(TextBox1.Text.Trim()) != "")

                {
                    //t1 = DateTime.ParseExact(Inbox_date_from.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
                    t2 = TextBox2.Text.Trim();

                   // t2 = VB_Classes.Dates.Dates_Operation.date_validate(TextBox2.Text.Trim());
                    //t2 = DateTime.ParseExact(Inbox_date_to.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
                    t1 = TextBox1.Text.Trim();

                    //t1 = VB_Classes.Dates.Dates_Operation.date_validate(TextBox1.Text.Trim());
                    sql += " AND convert(datetime,dbo.datevalid(dbo.project_needs.Request_DT)) > = '" + t1.ToString() + "'";
                    sql += " AND convert(datetime,dbo.datevalid(dbo.project_needs.Request_DT)) < = '" + t2.ToString() + "'";
                }
                else
                {
                    ShowAlertMessage("!!!!!ادخل التاريخ بطريقة صحيحة !!!!");
                    return;
                }


            }
            DateTime date1 = DateTime.ParseExact(t1, "dd/MM/yyyy", null);
            DateTime date2 = DateTime.ParseExact(t2, "dd/MM/yyyy", null);
            if (date2.Subtract(date1).Days < 0)
            {
                Label6.Text = "التاريخ الاول يجب ان يكون قبل التاريخ الثاني  !!!!";
                return;
            }



            sql += "order by Proj_Title, employee.pmp_name,need_Serial ";

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            ReportDocument rd = new ReportDocument();

            if (dt.Rows.Count == 0)
            {

                ShowAlertMessage("!!!!!هذا التقرير لا يوجد به بيانات للعرض !!!!");
                return;

            }
            else
            {


                string s = Server.MapPath("../Reports/PDemands_Approve_Req_Date.rpt");
                rd.Load(s);
                rd.SetDataSource(dt);

                rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
                rd.SetParameterValue("@user", user, "footerRep.rpt");
                rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report.rpt");


            }


        }
        /////////////////////////////////////////////////////////// Project Follow Up Report ///////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        else if (hidden_Rpt_Id.Value == "ProjectsFollowUP_Report")
        {
            //SqlConnection conn = new SqlConnection(sql_Connection);
            //if (Drop_month.SelectedValue != "0")
            //{
            //    int proj_id = 0;
            //    int projmanage = 0;
            //    decimal budget = 0;
            //    string proj_name = "";
            //    string ptem_name = "";
            //    string dept_name = "";
            //    if (Smart_Search_Proj.SelectedValue != "")
            //    {
            //        proj_id = int.Parse(Smart_Search_Proj.SelectedValue);
            //        budget = decimal.Parse(LabValue.Text);
            //        proj_name = Smart_Search_Proj.Text_Field;
            //        ptem_name = Labname.Text;
            //        dept_name = Session_CS.dept.ToString();

            //    }
              


            //    string user = Session_CS.pmp_name.ToString();

            //    string s = Server.MapPath("../Reports/Project_Activ_stations.rpt");
            //    ReportDocument rd = new ReportDocument();
            //    rd.Load(s);
            //    Load_Report(rd);
            //    DataTable dt = new DataTable();

            //    dt = ActivLevls.leveling(proj_id, dept_id, 0, 1, 0);
            //    rd.SetDataSource(dt);
            //   rd.SetParameterValue("@note", Drop_month.SelectedItem.Text);
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
            //else
            //{
            //    ShowAlertMessage("يجب اختيار الشهر ");
            //        return;
            //}






            SqlConnection conn = new SqlConnection(sql_Connection);
            int proj_id = 0;

            //sql = "SELECT Project.Proj_id, Project.Proj_Title, Project.internal_external, Project.pmp_pmp_id, Project.Dept_Dept_id, Project.Class_id FROM         Departments RIGHT OUTER JOIN  Project LEFT OUTER JOIN  EMPLOYEE ON Project.pmp_pmp_id = EMPLOYEE.PMP_ID ON Departments.Dept_ID = Project.Dept_Dept_id where 1=1 ";
            //if (Smrt_srch_dept.SelectedValue != "")
            //{
            //    sql += "AND dbo.Project.Dept_Dept_id=  " + CDataConverter.ConvertToInt(Smrt_srch_dept.SelectedValue);
            //}
            //if (Smart_Search_Proj.SelectedValue != "")
            //{
            //    sql += "and proj_id = " + CDataConverter.ConvertToInt(Smart_Search_Proj.SelectedValue);
            //}
           
                DataTable dt_merge = new DataTable();
                DataTable dt = new DataTable();
                string Main_Query = get_data_for_projects();
                if (Smrt_srch_dept.SelectedValue != "")
                {
                    Main_Query += "AND dbo.Project.Dept_Dept_id=  " + CDataConverter.ConvertToInt(Smrt_srch_dept.SelectedValue);
                }
                if (Smart_Search_Proj.SelectedValue != "")
                {
                    Main_Query += " and proj_id = " + Smart_Search_Proj.SelectedValue;
                }

                DataTable dt_no_proj = General_Helping.GetDataTable(Main_Query);

                if (dt_no_proj.Rows.Count > 0)
                {

                    for (int i = 0; i < dt_no_proj.Rows.Count; i++)
                    {

                        proj_id = CDataConverter.ConvertToInt(dt_no_proj.Rows[i]["proj_id"].ToString());
                       

                        dt = ActivLevls.leveling_For_Activities_Station(proj_id, CDataConverter.ConvertToInt(Drop_month.SelectedValue));
                      
                        dt_merge.Merge(dt);
                   }


                }



                string user = Session_CS.pmp_name.ToString();

                string s = Server.MapPath("../Reports/Project_Activ_stations.rpt");
                ReportDocument rd = new ReportDocument();
                rd.Load(s);
                Reports.Load_Report(rd);
               

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
          





        
        /////////////////////////////////////////////////////////// Project Needs  Report ///////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        else if (hidden_Rpt_Id.Value == "ProjectNeeds_Report")
        {
            //SqlConnection conn = new SqlConnection(sql_Connection);
            //if (DropDate.SelectedValue != "0")
            //{

            //    int proj_id = 0;
            //    int projmanage = 0;
            //    decimal budget = 0;
            //    string proj_name = "";
            //    string ptem_name = "";
            //    string dept_name = "";
            //    if (Smart_Search_Proj.SelectedValue != "0")
            //    {
            //        proj_id = int.Parse(Smart_Search_Proj.SelectedValue);
            //        budget = decimal.Parse(LabValue.Text);
            //        proj_name = Smart_Search_Proj.Text_Field;
            //        ptem_name = Labname.Text;
            //        dept_name = Session_CS.dept.ToString();

            //    }
            //    if (Smrt_Srch_projmanage.SelectedValue!="0")
            //    {
            //        projmanage = int.Parse(Smrt_Srch_projmanage.SelectedValue);
            //    }
            //    DateTime t1 = DateTime.Now;
            //    t1 = DateTime.Parse(DropDate.SelectedItem.Text);       
            //            string user = Session_CS.pmp_name.ToString();

            //            sql = "select pmp_pmp_id,Proj_Title,Proj_InitValue,PTem_Name,PTem_ID,Proj_id,recieved_amount_date,Dept_ID,Dept_name,";
            //            sql+="Store.*,";
            //            sql += "sum(case [nst_nst_ID] when 1 then approved_amount else 0 end) as [server_A], ";
            //           sql+="sum(case [nst_nst_ID] when 1 then TotalDelievered else 0 end) as [server_D],";
            //            sql+="sum(case [nst_nst_ID] when 2 then approved_amount else 0 end) as [computer_A], ";
            //             sql+="sum(case [nst_nst_ID] when 2 then TotalDelievered else 0 end) as [computer_D], ";
            //            sql+="sum(case [nst_nst_ID] when 3 then approved_amount else 0 end) as [printer_A], ";
            //           sql+="sum(case [nst_nst_ID] when 3 then TotalDelievered else 0 end) as [printer_D],";
            //            sql+="sum(case [nst_nst_ID] when 4 then approved_amount else 0 end) as [chair_A],"; 
            //           sql+="sum(case [nst_nst_ID] when 4 then TotalDelievered else 0 end) as [chair_D]";
            //            sql+=" from ProjectNeedsView,Store";
            //            sql += " where Store.available_Date < '" + DropDate.SelectedValue + "'";
            //           sql+=" group by pmp_pmp_id,Store.id,Store.PC_BrandName_No,Store.Printer_No,Store.PC_No,Store.Server_No,Store.available_Date,Proj_Title,proj_id,PTem_Name,PTem_ID,recieved_amount_date,Dept_ID,Proj_InitValue,Dept_name order by proj_title";


            //           SqlDataAdapter da = new SqlDataAdapter(sql,conn);
            //           DataTable dt = new DataTable();
            //           da.Fill(dt);

            //           ReportDocument rd = new ReportDocument();

            //           if (dt.Rows.Count == 0)
            //           {

            //               ShowAlertMessage("!!!!!هذا التقرير لا يوجد به بيانات للعرض !!!!");
            //               return;

            //           }
            //           else
            //           {

            //               string s = Server.MapPath("../Reports/PNeeds_parameter.rpt");
            //               rd.Load(s);
            //               rd.SetDataSource(dt);
            //               rd.SetParameterValue(0, proj_id);

            //               rd.SetParameterValue("@Dept_id", dept_id);
            //               rd.SetParameterValue("@PMP_id", projmanage);
            //               rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
            //               rd.SetParameterValue("@user", user, "footerRep.rpt");
            //               rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.WordForWindows, Response, true, "Report.rpt");

            //           }


            //            if (rd.Rows.Count == 0)
            //            {
            //                ShowAlertMessage("!!!!!هذا التقرير لا يوجد به بيانات للعرض !!!!");
            //                return;
            //            }
            //            else
            //            {
            //                rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.WordForWindows, Response, true, "Report");
            //            }


            //   }
            //else
            //{
            //    Label6.Visible = true;
            //    Label6.Text = "يجب اختيار تاريخ الجرد !!!!";
            //    return;
            //}

        }



        /////////////////////////////////////////////////////////// Projects Employees Report ///////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////// Projects needs approve Report ///////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        else if (hidden_Rpt_Id.Value == "projectsneedapprove_Report")
        {
            string t1 = "";
            string t2 = "";

            //int pmp = int.Parse(Session_CS.pmp_id.ToString());
            string user = Session_CS.pmp_name.ToString();

            //////////////////////////////////////////////////////////////// MOATAZ work 2 //////////////////////////////////////////////////////////////
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            SqlConnection conn = new SqlConnection(sql_Connection);
            sql = " set dateformat dmy select pmp_name,need_Serial,Pned_name,approved_amount,PNed_Number,PNed_ID,convert(datetime,PNed_Date,103) as PNed_Date,";
            sql += " Proj_Title,Proj_id,TotalDelievered,Dept_id,Dept_name ";
            sql += " from ";
            sql += " project_needs join Project on project_needs.Proj_proj_id = project.Proj_id  ";
            sql += " inner join employee on Project.pmp_pmp_id = EMPLOYEE.PMP_ID   ";
            sql += " inner join Departments on Project.Dept_Dept_id = Departments.Dept_id  ";
            sql += " where  approved_amount=0";
            DataTable DT = General_Helping.GetDataTable("select dept_id from EMPLOYEE_Departemnts where pmp_id=" + pmp);

            //string sql = "SELECT Project.proj_id,Project.Proj_Title, Departments.Dept_name, Project.Dept_Dept_id , Project.Pmp_pmp_id , employee.pmp_name,(select COUNT(Project_Activities.proj_proj_id) from Project_Activities where Project_Activities.proj_proj_id=project.Proj_id AND PActv_Parent=0) as  Parent_Act_Count,(select COUNT(Project_Activities.proj_proj_id) from Project_Activities where Project_Activities.proj_proj_id=project.Proj_id AND PActv_Parent<>0) as  child_Act_Count,(select COUNT(Project_Needs.proj_proj_id) from Project_Needs where Project_Needs.proj_proj_id=project.Proj_id ) as Pneeds,(select COUNT(Project_Objective.proj_proj_id) from Project_Objective where Project_Objective.proj_proj_id=project.Proj_id ) as proj_obj,(select COUNT(Project_Team.proj_proj_id) from Project_Team where Project_Team.proj_proj_id=project.Proj_id ) as proj_team,(select COUNT(Project_Organization.proj_proj_id) from Project_Organization where Project_Organization.proj_proj_id=project.Proj_id ) as proj_org FROM Departments INNER JOIN Project ON Departments.Dept_ID = Project.Dept_Dept_id LEFT OUTER JOIN employee on project.pmp_pmp_id=employee.pmp_id";
            sql += " AND dept_id = " + dept_id;
            if (DT.Rows.Count > 1)
            {
                for (int i = 0; i < DT.Rows.Count; i++)
                {
                    sql += " or dept_id = " + CDataConverter.ConvertToInt(DT.Rows[i + 1]["dept_id"].ToString());
                }
            }


            if (string.IsNullOrEmpty(TextBox1.Text) && string.IsNullOrEmpty(TextBox2.Text))
            {

                t1 = DateTime.ParseExact("01/01/1900", "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
                t2 = DateTime.MaxValue.ToString("dd/MM/yyyy");
                //sql += " AND convert(datetime,dbo.datevalid(dbo.project_needs.PNed_Date)) > = '" + t1.ToString() + "'";
                //sql += " AND convert(datetime,dbo.datevalid(dbo.project_needs.PNed_Date)) < = '" + t2.ToString() + "'";
            }
            else if (string.IsNullOrEmpty(TextBox1.Text))
            {
                if (TextBox2.Text.Trim() != "")

                  //  if (VB_Classes.Dates.Dates_Operation.date_validate(TextBox2.Text.Trim()) != "")
                {
                    t1 = DateTime.ParseExact("01/01/1900", "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
                    //t2 = DateTime.ParseExact(Inbox_date_to.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
                    t2 = TextBox2.Text.Trim();

                    //t2 = VB_Classes.Dates.Dates_Operation.date_validate(TextBox2.Text.Trim());
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

                if (TextBox1.Text.Trim() != "")

                 //  if (VB_Classes.Dates.Dates_Operation.date_validate(TextBox1.Text.Trim()) != "")
                {
                    //t1 = DateTime.ParseExact(Inbox_date_from.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
                    t2 = DateTime.MaxValue.ToString("dd/MM/yyyy");
                    t1 = TextBox1.Text.Trim();
                   // t1 = VB_Classes.Dates.Dates_Operation.date_validate(TextBox1.Text.Trim());
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
                if (TextBox2.Text.Trim() != "" && TextBox1.Text.Trim() != "")

               //     if (VB_Classes.Dates.Dates_Operation.date_validate(TextBox2.Text.Trim()) != "" && VB_Classes.Dates.Dates_Operation.date_validate(TextBox1.Text.Trim()) != "")

                
                {
                   // t2 = VB_Classes.Dates.Dates_Operation.date_validate(TextBox2.Text.Trim());

                    t2 =TextBox2.Text.Trim();

                    t1 = TextBox1.Text.Trim();
                   // t1 = VB_Classes.Dates.Dates_Operation.date_validate(TextBox1.Text.Trim());

                    sql += " AND convert(datetime,dbo.datevalid(dbo.project_needs.PNed_Date)) > = '" + t1.ToString() + "'";
                    sql += " AND convert(datetime,dbo.datevalid(dbo.project_needs.PNed_Date)) < = '" + t2.ToString() + "'";
                }
                else
                {
                    ShowAlertMessage("!!!!!ادخل التاريخ بطريقة صحيحة !!!!");
                    return;
                }


            }
            DateTime date1 = DateTime.ParseExact(t1, "dd/MM/yyyy", null);
            DateTime date2 = DateTime.ParseExact(t2, "dd/MM/yyyy", null);
            if (date2.Subtract(date1).Days < 0)
            {
                ShowAlertMessage("!!!!!التاريخ الأول يجب ان يكون قبل التاريخ الثاني !!!!");
                return;
            }



            sql += "order by Proj_Title, employee.pmp_name,need_Serial ";

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            ReportDocument rd = new ReportDocument();

            if (dt.Rows.Count == 0)
            {

                ShowAlertMessage("!!!!!هذا التقرير لا يوجد به بيانات للعرض !!!!");
                return;

            }
            else
            {


                string s = Server.MapPath("../Reports/PDemands_NOTApprove.rpt");
                rd.Load(s);
                rd.SetDataSource(dt);

                rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
                rd.SetParameterValue("@user", user, "footerRep.rpt");
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
            string proj_name = "";
            string ptem_name = "";
            string dept_name = "";
            sql = "SELECT dbo.Project.Proj_Title, dbo.Project_Objective.PObj_Desc,PObj_ID, dbo.Project.Proj_id, dbo.Departments.Dept_name,";
            sql += " dbo.Departments.Dept_ID, employee.pmp_name,  dbo.Project_Objective.PObj_Num,";
            sql += " dbo.Project.Proj_InitValue, employee.pmp_id";
            sql += " FROM dbo.Project_Objective INNER JOIN ";
            sql += " dbo.Project ON dbo.Project_Objective.proj_proj_id = dbo.Project.Proj_id INNER JOIN";
            sql += " dbo.Departments ON dbo.Project.Dept_Dept_id = dbo.Departments.Dept_ID INNER JOIN ";
            sql += " employee ON dbo.Project.pmp_pmp_id= employee.pmp_id where 1=1";
            if (Smart_Search_Proj.SelectedValue != "")
            {
                proj_id = int.Parse(Smart_Search_Proj.SelectedValue);
                budget = decimal.Parse(LabValue.Text);
                proj_name = Smart_Search_Proj.Text_Field;
                ptem_name = Labname.Text;
                dept_name = Session_CS.dept.ToString();
                sql += " AND dbo.Project.Proj_id = " + proj_id;

            }
            if (Smrt_Srch_projmanage.SelectedValue != "")
            {
                projmanage = int.Parse(Smrt_Srch_projmanage.SelectedValue);
                sql += " AND dbo.Project.pmp_pmp_id = " + projmanage;
            }
            DataTable DT = General_Helping.GetDataTable("select dept_id from EMPLOYEE_Departemnts where pmp_id=" + pmp);

            //string sql = "SELECT Project.proj_id,Project.Proj_Title, Departments.Dept_name, Project.Dept_Dept_id , Project.Pmp_pmp_id , employee.pmp_name,(select COUNT(Project_Activities.proj_proj_id) from Project_Activities where Project_Activities.proj_proj_id=project.Proj_id AND PActv_Parent=0) as  Parent_Act_Count,(select COUNT(Project_Activities.proj_proj_id) from Project_Activities where Project_Activities.proj_proj_id=project.Proj_id AND PActv_Parent<>0) as  child_Act_Count,(select COUNT(Project_Needs.proj_proj_id) from Project_Needs where Project_Needs.proj_proj_id=project.Proj_id ) as Pneeds,(select COUNT(Project_Objective.proj_proj_id) from Project_Objective where Project_Objective.proj_proj_id=project.Proj_id ) as proj_obj,(select COUNT(Project_Team.proj_proj_id) from Project_Team where Project_Team.proj_proj_id=project.Proj_id ) as proj_team,(select COUNT(Project_Organization.proj_proj_id) from Project_Organization where Project_Organization.proj_proj_id=project.Proj_id ) as proj_org FROM Departments INNER JOIN Project ON Departments.Dept_ID = Project.Dept_Dept_id LEFT OUTER JOIN employee on project.pmp_pmp_id=employee.pmp_id";
            sql += " AND dbo.Departments.dept_id = " + dept_id;
            if (DT.Rows.Count > 1)
            {
                for (int i = 1; i < DT.Rows.Count; i++)
                {
                    sql += " or dbo.Departments.dept_id = " + CDataConverter.ConvertToInt(DT.Rows[i]["dept_id"].ToString());
                }
            }

            sql += " order by dbo.Departments.dept_id ";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt_report = new DataTable();
            da.Fill(dt_report);
            string user = Session_CS.pmp_name.ToString();
            string s = Server.MapPath("../Reports/Proj_obj.rpt");
            rd.Load(s);
            rd.SetDataSource(dt_report);
            Reports.Load_Report(rd);

            rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
            rd.SetParameterValue("@user", user, "footerRep.rpt");
            if (dt_report.Rows.Count == 0)
            {
                ShowAlertMessage("!!!!!هذا التقرير لا يوجد به بيانات للعرض !!!!");
                return;
            }
            else
            {
                rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.WordForWindows, Response, true, "Report");
            }

        }
            ///////////////////////////////////////////////////////Portal_data /////////////////////////////////////

        else if (hidden_Rpt_Id.Value == "Portal_data_Report")
        {
            ReportDocument rd = new ReportDocument();
           // string sql111;
           
                string user = Session_CS.pmp_name.ToString();
                string s = Server.MapPath("../Reports/Portal_secctors_data_all.rpt");

                rd.Load(s);

                // rd.SetDataSource(dt_report);

                Reports.Load_Report(rd);
                int proj_id = 0;
                // rd.SetParameterValue("@Proj_ID", CDataConverter.ConvertToInt(Smart_Search_Proj.SelectedValue) );
                if (Smart_Search_Proj.SelectedValue != "")
                {
                    proj_id =CDataConverter.ConvertToInt( Smart_Search_Proj.SelectedValue);
                }
                else
                {
                    proj_id = 0;
                }
                rd.SetParameterValue("@proj_id",proj_id, "portal_sub_rep7.rpt");
                rd.SetParameterValue("Project_Id",proj_id, "portal_sub_rep.rpt");
                rd.SetParameterValue("proj_id",proj_id, "portal_sub_rep2.rpt");
                rd.SetParameterValue("proj_id",proj_id, "portal_sub_rep4.rpt");
                rd.SetParameterValue("proj_id", proj_id, "portal_sub_rep6.rpt");
                rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
                rd.SetParameterValue("@user", user, "footerRep.rpt");


                //if (dt_report.Rows.Count == 0)
                //{
                //    ShowAlertMessage("!!!!!هذا التقرير لا يوجد به بيانات للعرض !!!!");
                //    return;
                //}
                //else
                //{
                rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report");
                //}


            
           
           
            //ReportDocument rd1 = new ReportDocument();

           // sql = "select Project.Proj_id,Project.Proj_Title from Project where (1=1)";

            //if (Smart_Search_Proj.SelectedValue != "")
            //{
            //    int proj_id = CDataConverter.ConvertToInt(Smart_Search_Proj.SelectedValue);

            //     sql += " AND dbo.Project.Proj_id = "+ proj_id   ;

            //}


            //SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            //DataTable dt_report = new DataTable();
           
         
            //da.Fill(dt_report);
          
           

        }




/////////////////////////////////////////////////////////project_balance_status///////////////////////////////////////////////////
            /////////////////////////////////////////////////////////////////////////////////////////////////
        else if (hidden_Rpt_Id.Value == "projectbalance_status_report")
        {
            ReportDocument rd = new ReportDocument();
            int emp_dept = int.Parse(Session_CS.dept_id.ToString());

            string sql = "select Project.Proj_id,Project.Proj_Title,Project.Balance_Suggest_Initial,Project.Balance_Suggest_Finial,Project.Balance_Suggest_Approved,Departments.Dept_ID,Departments.Dept_name from Project inner join Departments on Project.Dept_Dept_id=Departments.Dept_ID and Departments.Dept_ID = '" + emp_dept + "' where 1=1  ";
            if (Smart_Search_Proj.SelectedValue != "")
            {
                sql += " AND dbo.Project.Proj_id = " + Smart_Search_Proj.SelectedValue;

            }
           
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt_report = new DataTable();
            da.Fill(dt_report);
            string user = Session_CS.pmp_name.ToString();
            string s = Server.MapPath("../Reports/balance_approvedstatus.rpt");
            rd.Load(s);
            rd.SetDataSource(dt_report);
            Reports.Load_Report(rd);

            rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
            rd.SetParameterValue("@user", user, "footerRep.rpt");
            if (dt_report.Rows.Count == 0)
            {
                ShowAlertMessage("!!!!!هذا التقرير لا يوجد به بيانات للعرض !!!!");
                return;
            }
            else
            {
                rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat , Response, true, "Report");
            }

        }






             /////////////////////////////////////////////////////////// Projects achievements Report ///////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        else if (hidden_Rpt_Id.Value == "projAchievment_Report")
        {
            ReportDocument rd = new ReportDocument();
            int proj_id = 0;

            int projmanage = 0;
            decimal budget = 0;
            string proj_name = "";
            string ptem_name = "";
            string dept_name = "";
            sql = " SELECT dbo.project_Achievements.ach_id,dbo.project_Achievements.ach_desc,";
            sql += " dbo.project_Achievements.ach_type,dbo.project_Achievements.ach_other_desc,";
            sql += " dbo.project_Achievements.ach_from_date,dbo.project_Achievements.ach_to_date,dbo.Project.Proj_Title,";
            sql += " dbo.Project.Proj_id,dbo.Departments.Dept_name,dbo.Departments.Dept_ID,";
            sql += " Project_Team.pTem_name,achievments_types.type_desc , dbo.Project.Proj_InitValue";
            sql += " FROM dbo.project_Achievements";
            sql += " join achievments_types on project_Achievements.ach_type=achievments_types.type_id";
            sql += " join project on project_Achievements.proj_id=project.proj_id";
            sql += " join Departments on project.dept_dept_id=Departments.dept_id";
            sql += " join Project_Team on project.pmp_pmp_id=Project_Team.pmp_pmp_id and project.proj_id=Project_Team.proj_proj_id where 1=1";
            if (Smart_Search_Proj.SelectedValue != "")
            {
                proj_id = int.Parse(Smart_Search_Proj.SelectedValue);
                budget = decimal.Parse(LabValue.Text);
                proj_name = Smart_Search_Proj.Text_Field;
                ptem_name = Labname.Text;
                dept_name = Session_CS.dept.ToString();
                sql += " AND dbo.Project.Proj_id = " + proj_id;

            }
            if (Smrt_Srch_projmanage.SelectedValue != "")
            {
                projmanage = int.Parse(Smrt_Srch_projmanage.SelectedValue);
                sql += " AND dbo.Project.pmp_pmp_id = " + projmanage;
            }
            DataTable DT = General_Helping.GetDataTable("select dept_id from EMPLOYEE_Departemnts where pmp_id=" + pmp);

            //string sql = "SELECT Project.proj_id,Project.Proj_Title, Departments.Dept_name, Project.Dept_Dept_id , Project.Pmp_pmp_id , employee.pmp_name,(select COUNT(Project_Activities.proj_proj_id) from Project_Activities where Project_Activities.proj_proj_id=project.Proj_id AND PActv_Parent=0) as  Parent_Act_Count,(select COUNT(Project_Activities.proj_proj_id) from Project_Activities where Project_Activities.proj_proj_id=project.Proj_id AND PActv_Parent<>0) as  child_Act_Count,(select COUNT(Project_Needs.proj_proj_id) from Project_Needs where Project_Needs.proj_proj_id=project.Proj_id ) as Pneeds,(select COUNT(Project_Objective.proj_proj_id) from Project_Objective where Project_Objective.proj_proj_id=project.Proj_id ) as proj_obj,(select COUNT(Project_Team.proj_proj_id) from Project_Team where Project_Team.proj_proj_id=project.Proj_id ) as proj_team,(select COUNT(Project_Organization.proj_proj_id) from Project_Organization where Project_Organization.proj_proj_id=project.Proj_id ) as proj_org FROM Departments INNER JOIN Project ON Departments.Dept_ID = Project.Dept_Dept_id LEFT OUTER JOIN employee on project.pmp_pmp_id=employee.pmp_id";
            sql += " AND dbo.Departments.dept_id = " + dept_id;
            if (DT.Rows.Count > 1)
            {
                for (int i = 1; i < DT.Rows.Count; i++)
                {
                    sql += " or dbo.Departments.dept_id = " + CDataConverter.ConvertToInt(DT.Rows[i]["dept_id"].ToString());
                }
            }

            sql += " order by dbo.Departments.dept_id ";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt_report = new DataTable();
            da.Fill(dt_report);
            string user = Session_CS.pmp_name.ToString();
            string s = Server.MapPath("../Reports/Proj_achievments.rpt");
            rd.Load(s);
            rd.SetDataSource(dt_report);
            Reports.Load_Report(rd);

            rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
            rd.SetParameterValue("@user", user, "footerRep.rpt");
            if (dt_report.Rows.Count == 0)
            {
                ShowAlertMessage("!!!!!هذا التقرير لا يوجد به بيانات للعرض !!!!");
                return;
            }
            else
            {
                rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report");
            }

        }
        ////////////////////////////////////////////// need in details ////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        else if (hidden_Rpt_Id.Value == "needs_in_details_Report")
        {
            SqlConnection conn = new SqlConnection(sql_Connection);
            //int pmp = int.Parse(Session_CS.pmp_id.ToString());
            ReportDocument rd = new ReportDocument();
            int proj_id = 0;
            int projmanage = 0;
            decimal budget = 0;
            string proj_name = "";
            string ptem_name = "";
            string dept_name = "";
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

            if (Smart_Search_Proj.SelectedValue != "")
            {
                proj_id = int.Parse(Smart_Search_Proj.SelectedValue);
                budget = decimal.Parse(LabValue.Text);
                proj_name = Smart_Search_Proj.Text_Field;
                ptem_name = Labname.Text;
                dept_name = Session_CS.dept.ToString();
                sql += " AND dbo.Project.Proj_id = " + proj_id;

            }
            if (Smrt_Srch_projmanage.SelectedValue != "")
            {
                projmanage = int.Parse(Smrt_Srch_projmanage.SelectedValue);
                sql += " AND dbo.project.pmp_pmp_id = " + projmanage;
            }
            DataTable DT = General_Helping.GetDataTable("select dept_id from EMPLOYEE_Departemnts where pmp_id=" + pmp);

            //string sql = "SELECT Project.proj_id,Project.Proj_Title, Departments.Dept_name, Project.Dept_Dept_id , Project.Pmp_pmp_id , employee.pmp_name,(select COUNT(Project_Activities.proj_proj_id) from Project_Activities where Project_Activities.proj_proj_id=project.Proj_id AND PActv_Parent=0) as  Parent_Act_Count,(select COUNT(Project_Activities.proj_proj_id) from Project_Activities where Project_Activities.proj_proj_id=project.Proj_id AND PActv_Parent<>0) as  child_Act_Count,(select COUNT(Project_Needs.proj_proj_id) from Project_Needs where Project_Needs.proj_proj_id=project.Proj_id ) as Pneeds,(select COUNT(Project_Objective.proj_proj_id) from Project_Objective where Project_Objective.proj_proj_id=project.Proj_id ) as proj_obj,(select COUNT(Project_Team.proj_proj_id) from Project_Team where Project_Team.proj_proj_id=project.Proj_id ) as proj_team,(select COUNT(Project_Organization.proj_proj_id) from Project_Organization where Project_Organization.proj_proj_id=project.Proj_id ) as proj_org FROM Departments INNER JOIN Project ON Departments.Dept_ID = Project.Dept_Dept_id LEFT OUTER JOIN employee on project.pmp_pmp_id=employee.pmp_id";
            sql += " AND dept_id = " + dept_id;
            if (DT.Rows.Count > 1)
            {
                for (int i = 0; i < DT.Rows.Count; i++)
                {
                    sql += " or dept_id = " + CDataConverter.ConvertToInt(DT.Rows[i]["dept_id"].ToString());
                }
            }
            //sql += " AND dbo.Departments.Dept_ID = " + dept_id;
            sql += " GROUP BY dbo.Project.Proj_id, dbo.Project.Proj_Title, dbo.Needs_Sup_Type.NST_Desc, dbo.Project_Needs.PNed_InitValue, dbo.Departments.Dept_name,";
            sql += " dbo.Departments.Dept_ID, dbo.employee.pmp_name, dbo.Project.Proj_InitValue, employee.pmp_id,project.pmp_pmp_id";

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt_Report = new DataTable();
            da.Fill(dt_Report);
            string user = Session_CS.pmp_name.ToString();
            string s = Server.MapPath("../Reports/Needs_In_Details_Proj.rpt");
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


                sql = "select distinct proj_id,proj_title,Dept_name,dept_dept_id,pmp_name from Similar_Projects_View";
                sql += " where 1=1  ";


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

        /////////////////////////////////////////////////////////// Projects needs Report ///////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        else if (hidden_Rpt_Id.Value == "projobjneeds_Report")
        {
            ReportDocument rd = new ReportDocument();
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
                dept_name = Session_CS.dept.ToString();

            }


            string user = Session_CS.pmp_name.ToString();
            string s = Server.MapPath("../Reports/ProjNeeds.rpt");
            rd.Load(s);
            Reports.Load_Report(rd);
            rd.SetParameterValue(0, proj_id);
            rd.SetParameterValue("@Proj_Name", proj_name, "Report_Sticker_Try2.rpt");
            rd.SetParameterValue("@Dept_Name", dept_name, "Report_Sticker_Try2.rpt");
            rd.SetParameterValue("@budget", budget, "Report_Sticker_Try2.rpt");
            rd.SetParameterValue("@PMP_Name", ptem_name, "Report_Sticker_Try2.rpt");
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
            //if (Smart_Search_Proj.SelectedValue != "")
            //{
            //    proj_id = int.Parse(Smart_Search_Proj.SelectedValue);
            //    budget = decimal.Parse(LabValue.Text);
            //    proj_name = Smart_Search_Proj.Text_Field;
            //    ptem_name = Labname.Text;
            //    dept_name = Session_CS.dept.ToString();

            //}

            //string user = Session_CS.pmp_name.ToString();
            //string s = Server.MapPath("../Reports/CrystalReport3.rpt");
            //rd.Load(s);
            //Load_Report(rd);
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
        }
        ////////////////////////////////////////إجمالي الميزانية/////////////////////////////////////////

        else if (hidden_Rpt_Id.Value == "linkAllBalance_report")
        {
            //int pmp = int.Parse(Session_CS.pmp_id.ToString());
            if (Drop_balance.SelectedValue == "0")
            {
                ShowAlertMessage("!!!!!يجب اختيار سنة مالية !!!!");
                return;

            }
            else
            {
                DataTable DT = General_Helping.GetDataTable("select dept_id from EMPLOYEE_Departemnts where pmp_id=" + pmp);

                //string sql = "SELECT Project.proj_id,Project.Proj_Title, Departments.Dept_name, Project.Dept_Dept_id , Project.Pmp_pmp_id , employee.pmp_name,(select COUNT(Project_Activities.proj_proj_id) from Project_Activities where Project_Activities.proj_proj_id=project.Proj_id AND PActv_Parent=0) as  Parent_Act_Count,(select COUNT(Project_Activities.proj_proj_id) from Project_Activities where Project_Activities.proj_proj_id=project.Proj_id AND PActv_Parent<>0) as  child_Act_Count,(select COUNT(Project_Needs.proj_proj_id) from Project_Needs where Project_Needs.proj_proj_id=project.Proj_id ) as Pneeds,(select COUNT(Project_Objective.proj_proj_id) from Project_Objective where Project_Objective.proj_proj_id=project.Proj_id ) as proj_obj,(select COUNT(Project_Team.proj_proj_id) from Project_Team where Project_Team.proj_proj_id=project.Proj_id ) as proj_team,(select COUNT(Project_Organization.proj_proj_id) from Project_Organization where Project_Organization.proj_proj_id=project.Proj_id ) as proj_org FROM Departments INNER JOIN Project ON Departments.Dept_ID = Project.Dept_Dept_id LEFT OUTER JOIN employee on project.pmp_pmp_id=employee.pmp_id";


                SqlConnection conn = new SqlConnection(sql_Connection);
                sql = " set dateformat dmy SELECT SUM(Project_Period_Balance.Init_Value) AS totl,CONVERT(datetime, dbo.datevalid(Project_Period_Balance.Strt_Date)), Project_Period_Balance.Proj_id, Departments.Dept_name, Project.Proj_Title, Departments.Dept_ID FROM Departments INNER JOIN";
                sql += "  Project ON Departments.Dept_ID = Project.Dept_Dept_id INNER JOIN";
                sql += "  Project_Period_Balance ON Project.Proj_id = Project_Period_Balance.Proj_id where 1=1";

                //str = Convert.ToDateTime(TextBox3.Text);

                //str = DateTime.ParseExact(date_1, "dd/MM/yyyy", null).ToString("MM/dd/yyyy");


                //endd = DateTime.ParseExact(date_2, "dd/MM/yyyy", null).ToString("MM/dd/yyyy");
                //sql += " WHERE CONVERT(datetime, Project_Period_Balance.Strt_Date, 103) > = '" + str + "'";

                //sql += "AND CONVERT(datetime, Project_Period_Balance.End_Date, 103) < = '" + endd + "'";

                sql += " and  CONVERT(datetime, dbo.datevalid(Project_Period_Balance.Strt_Date))  > = '01" + "/07" + "/" + int.Parse(Drop_balance.Text.Substring(5, 4)) + "'";
                sql += " and  CONVERT(datetime, dbo.datevalid(Project_Period_Balance.Strt_Date)) < ='30" + "/06" + "/" + (int.Parse(Drop_balance.Text.Substring(5, 4)) + 1) + "'";

                sql += " AND dept_id = " + dept_id;
                if (DT.Rows.Count > 1)
                {
                    for (int i = 0; i < DT.Rows.Count; i++)
                    {
                        sql += " or dept_id = " + CDataConverter.ConvertToInt(DT.Rows[i]["dept_id"].ToString());
                    }
                }
                //string strt = str.Substring(6, 4);
                //sql += "AND CONVERT(datetime, Project_Period_Balance.End_Date, 103) < = '" + endd + "'";

                //string end_date = endd.Substring(6, 4);

                sql += " GROUP BY Project_Period_Balance.Proj_id, Departments.Dept_name, Project.Proj_Title, Departments.Dept_ID,CONVERT(datetime, dbo.datevalid(Project_Period_Balance.Strt_Date))";

                //DateTime date1 = DateTime.ParseExact(str, "MM/dd/yyyy", null);
                //DateTime date2 = DateTime.ParseExact(endd, "MM/dd/yyyy", null);
                //if (date2.Year <= date1.Year)
                //{
                ReportDocument rd = new ReportDocument();
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt_Report = new DataTable();
                da.Fill(dt_Report);
                string user = Session_CS.pmp_name.ToString();
                string s = Server.MapPath("../Reports/totalofbalance.rpt");
                rd.Load(s);
                rd.SetDataSource(dt_Report);
                Reports.Load_Report(rd);
                rd.SetParameterValue("@Date_str", int.Parse(Drop_balance.Text.Substring(5, 4)));
                rd.SetParameterValue("@Date_end", (int.Parse(Drop_balance.Text.Substring(5, 4)) + 1));
                //rd.SetParameterValue("@Dept_ID", dept_id);
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

                //    ReportDocument rd = new ReportDocument();
                //    string user = Session_CS.pmp_name.ToString();


                //    string s = Server.MapPath("../Reports/totalofbalance.rpt");
                //    rd.Load(s);
                //    rd.SetDataSource(dt);
                //    //rd.SetParameterValue("@date", TextBox3.Text);

                //    //string strt = TextBox3.Text.Substring(6, 4);

                //    rd.SetParameterValue("@Date_str", date1);
                //    rd.SetParameterValue("@Date_end", date2);
                //    rd.SetParameterValue("@Dept_ID", dept_id);
                //    rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
                //    rd.SetParameterValue("@user", user, "footerRep.rpt");

                //    Load_Report(rd);
                //    rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report");
                //    conn.Close();

                //}
            }
        }


        ////////////////////////////BALANCE///////////////////////////////////////////
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


                SqlConnection conn = new SqlConnection(sql_Connection);
                DataTable DT = General_Helping.GetDataTable("select dept_id from EMPLOYEE_Departemnts where pmp_id=" + pmp);


                sql = "  set dateformat dmy SELECT Project.Proj_id, Project.Proj_Title, Departments.Dept_name, Project_Team.PTem_Name, Fin_Tender.Name, Fin_Work_Order.Tender_NO,                       Fin_Work_Order.Tender_Year, Fin_Work_Order.Code, substring(Fin_Work_Order.Date,7,4) as date, Fin_Work_Order.Work_Total_Value, Fin_Company.Company_Name,                       sum(Fin_Bills.Bil_Value) as Fin_Bills_Bil_Value FROM         Fin_Company INNER JOIN                       Fin_Work_Order ON Fin_Company.Company_ID = Fin_Work_Order.Company_ID INNER JOIN                       Fin_Bills ON Fin_Work_Order.Work_Order_ID = Fin_Bills.Work_Order_ID INNER JOIN                       Fin_Tender ON Fin_Work_Order.Tender_Type_ID = Fin_Tender.ID INNER JOIN                       Departments INNER JOIN                       Project ON Departments.Dept_ID = Project.Dept_Dept_id INNER JOIN                        Project_Team ON Project.Proj_id = Project_Team.proj_proj_id ON Fin_Work_Order.Project_ID = Project.Proj_id ";
                sql += " WHERE (Project_Team.rol_rol_id = 4) ";



                sql += " and  CONVERT(datetime,Fin_Bills.Date, 103) > = '01" + "/07" + "/" + int.Parse(Drop_balance.Text.Substring(5, 4)) + "'";
                sql += " and  CONVERT(datetime,Fin_Bills.Date, 103) < ='30" + "/06" + "/" + (int.Parse(Drop_balance.Text.Substring(5, 4)) + 1) + "'";
                if (Smart_Search_Proj.SelectedValue != "")
                {
                    sql += " and  Project.Proj_id =" + Smart_Search_Proj.SelectedValue;
                }

                if (Smrt_Srch_projmanage.SelectedValue != "")
                {
                    sql += " and  Project_Team.pmp_pmp_id =" + Smrt_Srch_projmanage.SelectedValue;
                }

                sql += " and dept_id= " + dept_id;
                if (DT.Rows.Count > 1)
                {
                    for (int i = 0; i < DT.Rows.Count; i++)
                    {
                        sql += " or dept_id = " + CDataConverter.ConvertToInt(DT.Rows[i]["dept_id"].ToString());
                    }
                }

                //strt_DT = DateTime.ParseExact(TextBox3.Text, "dd/MM/yyyy", null).ToString("MM/dd/yyyy");

                //end_DT = DateTime.ParseExact(TextBox4.Text, "dd/MM/yyyy", null).ToString("MM/dd/yyyy");


                //sql += " and  CONVERT(datetime,  Fin_Bills.Date, 103) > = '" + strt_DT.ToString() + "'";

                //sql += " AND CONVERT(datetime,Fin_Bills.Date, 103) < = '" + end_DT.ToString() + "'";




                sql += " group by Project.Proj_id, Project.Proj_Title, Departments.Dept_name, Project_Team.PTem_Name, Fin_Tender.Name, Fin_Work_Order.Tender_NO,Fin_Work_Order.Tender_Year, Fin_Work_Order.Code, Fin_Work_Order.Date, Fin_Work_Order.Work_Total_Value, Fin_Company.Company_Name ";




                conn.Open();

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt_Report = new DataTable();
                da.Fill(dt_Report);
                if (dt_Report.Rows.Count == 0)
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
                    string s = Server.MapPath("../Reports/Copy of Tender.rpt");

                    rd.Load(s);
                    rd.SetDataSource(dt_Report);
                    rd.SetParameterValue("@Strt_DT", int.Parse(Drop_balance.Text.Substring(5, 4)));
                    rd.SetParameterValue("@End_DT", (int.Parse(Drop_balance.Text.Substring(5, 4)) + 1));
                    //rd.SetParameterValue("@Dept_ID", dept_id);
                    rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
                    rd.SetParameterValue("@user", user, "footerRep.rpt");
                    Reports.Load_Report(rd);
                    rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report");
                    conn.Close();


                }

            }
            else
            {
                ShowAlertMessage("!!!!!يجب اختيار السنة المالية المطلوبة !!!!");
                return;
            }


        }

        ////////////////////////////////////////////////////////////////////////////

        else if (hidden_Rpt_Id.Value == "orgReport_Report")
        {
            ReportDocument rd = new ReportDocument();
            int org_id = 0;
            if (Droporg.SelectedValue != "0")
            {
                org_id = int.Parse(Droporg.SelectedValue);
            }
            string user = Session_CS.pmp_name.ToString();

            string s = Server.MapPath("../Reports/OrganizationsProjects.rpt");
            rd.Load(s);
            Reports.Load_Report(rd);
            rd.SetParameterValue(0, org_id);
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
        else if (hidden_Rpt_Id.Value == "needhighinter_Report")
        {
            SqlConnection conn = new SqlConnection(sql_Connection);

            int proj_id = 0;
            int projmanage = 0;
            DataTable DT = General_Helping.GetDataTable("select dept_id from EMPLOYEE_Departemnts where pmp_id=" + pmp);
            decimal budget = 0;
            string proj_name = "";
            string ptem_name = "";
            string dept_name = "";

            sql = "select * ,(Case When PActv_Parent=0 Then PActv_Desc Else null End)as parent,(Case When PActv_Parent=0 Then 0 Else null End) as Parent_Actv_Num,PActv_Parent as LVL from Project_Activities full OUTER JOIN dbo.Project_Constraints ON dbo.Project_Activities.PActv_ID = dbo.Project_Constraints.PActv_PActv_ID  full OUTER join project on Project_Activities.proj_proj_id=project.proj_id full OUTER join Departments on project.Dept_Dept_id=Departments.Dept_ID full OUTER join Active_Satatus on Project_Activities.ActStat_ActStat_id=Active_Satatus.ActStat_ID full OUTER join Project_Activities_Indicators on Project_Activities.PActv_ID=Project_Activities_Indicators.pactv_pactv_id full OUTER join Indicators_Type on Project_Activities_Indicators.indt_indt_id=Indicators_Type.IndT_id full OUTER join Project_Activity_indicator_period on Project_Activities_Indicators.PAIP_period_id=Project_Activity_indicator_period.ID full OUTER join Project_Activities_Indicators_History on Project_Activities_Indicators.PAI_ID=Project_Activities_Indicators_History.pai_pai_id full OUTER join Organization on Project_Activities.Excutive_responsible_Org_Org_id = Organization.org_id where 1=1 AND (dbo.Project_Constraints.PCONS_IS_CRITICAL = 1)";

            if (Smart_Search_Proj.SelectedValue != "")
            {
                proj_id = int.Parse(Smart_Search_Proj.SelectedValue);
                budget = decimal.Parse(LabValue.Text);
                proj_name = Smart_Search_Proj.Text_Field;
                ptem_name = Labname.Text;
                dept_name = Session_CS.dept.ToString();
                sql += " AND dbo.Project.Proj_id= " + proj_id;


            }
            if (Smrt_Srch_projmanage.SelectedValue != "")
            {
                projmanage = int.Parse(Smrt_Srch_projmanage.SelectedValue);
                sql += " AND Project.pmp_pmp_id = " + projmanage;

            }
            sql += " AND dbo.Departments.Dept_ID = " + dept_id;
            if (DT.Rows.Count > 1)
            {
                for (int i = 1; i < DT.Rows.Count; i++)
                {
                    sql += " or dept_id = " + CDataConverter.ConvertToInt(DT.Rows[i]["dept_id"].ToString());
                }
            }

            //if (Smrt_Srch_DropDep.SelectedValue != "")
            //{
            //    dept_id = int.Parse(Smrt_Srch_DropDep.SelectedValue);
            //    sql += " AND dbo.Departments.Dept_ID= " + dept_id;
            //}
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt_report = new DataTable();
            da.Fill(dt_report);
            string user = Session_CS.pmp_name.ToString();
            ReportDocument rd = new ReportDocument();
            string s = Server.MapPath("../Reports/NeedHInterference.rpt");
            rd.Load(s);
            rd.SetDataSource(dt_report);
            Reports.Load_Report(rd);



            rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
            rd.SetParameterValue("@user", user, "footerRep.rpt");
            if (dt_report.Rows.Count == 0)
            {
                ShowAlertMessage("!!!!!هذا التقرير لا يوجد به بيانات للعرض !!!!");
                return;
            }
            else
            {
                rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report");
            }
        }
        else if (hidden_Rpt_Id.Value == "projects_Org")
        {
            //    SqlConnection conn = new SqlConnection(sql_Connection);

            //    //int proj_id = 0;
            //    //int projmanage = 0;

            //    //decimal budget = 0;
            //    //string proj_name = "";
            //    //string ptem_name = "";
            //    //string dept_name = "";
            //    DataTable DT = General_Helping.GetDataTable("select dept_id from EMPLOYEE_Departemnts where pmp_id=" + pmp);
            //    sql = "SELECT DISTINCT dbo.Project.Proj_id, dbo.Project.Proj_Title, dbo.EMPLOYEE.pmp_name, dbo.Project.Proj_InitValue, dbo.Project.Proj_is_commit, CONVERT(datetime,dbo.Project.Proj_Creation_Date, 103) AS Proj_Creation_Date, CONVERT(datetime, dbo.Project.proj_start_date, 103) AS proj_start_date, CONVERT(datetime, dbo.Project.Proj_End_Date, 103) AS Proj_End_Date, dbo.Departments.Dept_name, dbo.Departments.Dept_ID, dbo.Organization.Org_Desc, dbo.Organization.Org_ID FROM dbo.Departments INNER JOIN  dbo.Project ON dbo.Departments.Dept_ID = dbo.Project.Dept_Dept_id INNER JOIN dbo.EMPLOYEE ON dbo.Project.pmp_pmp_id = dbo.EMPLOYEE.PMP_ID INNER JOIN dbo.Project_Organization ON dbo.Project.Proj_id = dbo.Project_Organization.proj_proj_id INNER JOIN dbo.Organization ON dbo.Project_Organization.org_org_id = dbo.Organization.Org_ID";
            //    sql += " AND dbo.Departments.Dept_ID = " + dept_id;
            //    if (DT.Rows.Count > 1)
            //    {
            //        for (int i = 1; i < DT.Rows.Count; i++)
            //        {
            //            sql += " or dept_id = " + CDataConverter.ConvertToInt(DT.Rows[i]["dept_id"].ToString());
            //        }
            //    }
            //    ReportDocument rd = new ReportDocument();

            //    int org_id = 0;
            //    if (Droporg.SelectedValue != "0")
            //    {
            //        org_id = int.Parse(Droporg.SelectedValue);
            //        sql += " AND dbo.Organization.Org_ID = " + org_id;
            //    }
            //    string user = Session_CS.pmp_name.ToString();
            //    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            //    DataTable dt_report = new DataTable();
            //    da.Fill(dt_report);
            //    string s = Server.MapPath("../Reports/ProjectsStatusByOrg.rpt");
            //    rd.Load(s);
            //    rd.SetDataSource(dt_report);
            //    Load_Report(rd);
            //    rd.SetParameterValue(0, org_id);
            //    //rd.SetParameterValue(1, dept_id);
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
        }
        else if (hidden_Rpt_Id.Value == "project_select_status_Report")
        {
            SqlConnection conn = new SqlConnection(sql_Connection);


            DataTable DT = General_Helping.GetDataTable("select dept_id from EMPLOYEE_Departemnts where pmp_id=" + pmp);
            int commit = 0;
            sql = " SELECT Proj_id,Proj_Title,pmp_pmp_id,Project.Dept_Dept_id,Proj_is_commit,pmp_name,Dept_name,dbo.Departments.Dept_ID from dbo.Project";
            sql += " inner join employee on Project.pmp_pmp_id=employee.pmp_id";
            sql += " inner join dbo.Departments on Project.Dept_Dept_id=Departments.dept_id where 1=1";
            if (Dropstatus.SelectedValue != "0")
            {
                commit = int.Parse(Dropstatus.SelectedValue);
                sql += " AND dbo.Project.Proj_is_commit= " + commit;
            }
            sql += " AND Departments.dept_id = " + dept_id;
            //sql += " OR Departments.dept_id in (" + dept_id;
            if (DT.Rows.Count > 1)
            {
                for (int i = 1; i < DT.Rows.Count; i++)
                {
                    //sql += "," + CDataConverter.ConvertToInt(DT.Rows[i]["dept_id"].ToString());
                    sql += " or dept_id = " + CDataConverter.ConvertToInt(DT.Rows[i]["dept_id"].ToString());

                }
                //sql += ")";
            }


            sql += " order by Proj_is_commit,Project.Dept_Dept_id";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt_report = new DataTable();
            da.Fill(dt_report);
            string user = Session_CS.pmp_name.ToString();
            ReportDocument rd = new ReportDocument();
            string s = Server.MapPath("../Reports/Proj_Status_AccordingDept.rpt");
            rd.Load(s);
            rd.SetDataSource(dt_report);
            Reports.Load_Report(rd);



            rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
            rd.SetParameterValue("@user", user, "footerRep.rpt");
            if (dt_report.Rows.Count == 0)
            {
                ShowAlertMessage("!!!!!هذا التقرير لا يوجد به بيانات للعرض !!!!");
                return;
            }
            else
            {
                rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report");
            }
        }
        else if (hidden_Rpt_Id.Value == "sug_plan")
        {

            conn = new SqlConnection(sql_Connection);
            DataTable DT = General_Helping.GetDataTable("select dept_id from EMPLOYEE_Departemnts where pmp_id=" + pmp);



            sql = "select Total_Value, pmp_pmp_id, PTem_Name, Proj_Title, Source_Name, Dept_ID, [مجموع المكافأت], [مجموع الانتقالات], [مجموع حجز الفنادق], [مجموع المستلزمات], [مجموع التدريب],";
            sql += "[مجموع التطبيقات], [مجموع المناقصات], [مجموع موارد], اتصالات, [أعمال هندسية], [ برامج رخص], [ اعادة], Sources_ID, Proj_id";
            sql += " from  total_balance_view ";



            sql += " where dept_id = " + dept_id;
            if (DT.Rows.Count > 1)
            {
                for (int i = 0; i < DT.Rows.Count; i++)
                {
                    sql += " or dept_id = " + CDataConverter.ConvertToInt(DT.Rows[i]["dept_id"].ToString());
                }
            }


            if (Smrt_Srch_projmanage.SelectedValue != "")
                sql += " and pmp_pmp_id= " + Smrt_Srch_projmanage.SelectedValue;

            if (Smart_Search_Proj.SelectedValue != "")
                sql += " and Proj_id= " + Smart_Search_Proj.SelectedValue;


            if (Drop_balance.SelectedValue != "0")
            {
                string d1 = Drop_balance.SelectedValue.Substring(5, 4);
                string date_1 = "01/07/" + d1;


                string d2 = Drop_balance.SelectedValue.Substring(0, 4);

                string date_2 = "30/06/" + d2;


                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt_Report = new DataTable();
                da.Fill(dt_Report);
                if (dt_Report.Rows.Count > 0)
                {


                    ReportDocument rd = new ReportDocument();
                    string user = Session_CS.pmp_name.ToString();
                    string s = Server.MapPath("../Reports/proj_sources_balance.rpt");
                    rd.Load(s);
                    rd.SetDataSource(dt_Report);
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

            else
            {
                Label6.Visible = true;
                Label6.Text = "اختر السنة المالية";
            }
        }

        else
        {
            Label6.Visible = true;
            Label6.Text = "لم يتم اختيار تقرير للعرض";
            return;
        }
    }



    protected void needmaintypeLB_Click(object sender, EventArgs e)
    {

        string user = Session_CS.pmp_name.ToString();
        ReportDocument rd = new ReportDocument();
        string s = Server.MapPath("../Reports/needmaintype.rpt");
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
            rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.WordForWindows, Response, true, "Report");
        }


        //else if (hidden_Rpt_Id.Value == "Tender_Report")
        //{}


    }
    protected void OrganizationsProjectsLB_Click(object sender, EventArgs e)
    {

        //hidden_Rpt_Id.Value = "orgReport_Report";
        //Div_Proj.Style.Add("display", "none");
        //Div_Proj_Mngr.Style.Add("display", "none");
        //Div_Date_Needs.Style.Add("display", "none");
        //Div_Dates_Demands.Style.Add("display", "none");
        //Div_Org.Style.Add("display", "block");
        //Div_Date_balance.Style.Add("display", "none");
        //show_hide_tables();
        //Label2.Visible = true;
        //Label6.Visible = false;
        //Page.Title = "تقرير " + OrganizationsProjectsLB.Text;
        //Label2.Text = Page.Title;



    }
    protected void project_select_status_Click(object sender, EventArgs e)
    {
        hidden_Rpt_Id.Value = "project_select_status_Report";
        Div_Proj.Style.Add("display", "none");
        Div_Proj_Mngr.Style.Add("display", "none");
        Div_Date_Needs.Style.Add("display", "none");
        Div_Dates_Demands.Style.Add("display", "none");
        //Div_Dept.Style.Add("display", "none");
        show_hide_tables();
        Div_Date_balance.Style.Add("display", "none");
        Div_Status.Style.Add("display", "block");
        Div_Dept.Style.Add("display", "none");

        Page.Title = "تقرير " + project_select_status.Text;
        Label6.Visible = false;
        Label2.Visible = true;
        Label2.Text = Page.Title;
    }
    protected void Delay_Projects_Click(object sender, EventArgs e)
    {
        hidden_Rpt_Id.Value = "Delay_Projects_Report";
        Div_Proj.Style.Add("display", "none");
        Div_Proj_Mngr.Style.Add("display", "none");
        Div_Date_Needs.Style.Add("display", "none");
        Div_Dates_Demands.Style.Add("display", "none");
        Div_Org.Style.Add("display", "none");
        int dept_id = int.Parse(Session_CS.dept_id.ToString());
        int pmp = int.Parse(Session_CS.pmp_id.ToString());
        Div_Date_balance.Style.Add("display", "none");
        Div_Dept.Style.Add("display", "none");

        Label2.Visible = true;
        Label6.Visible = false;
        ReportDocument rd = new ReportDocument();
        //string year1 = Drop_balance.SelectedValue;
        string user = Session_CS.pmp_name.ToString();
        DataTable DT = General_Helping.GetDataTable("select dept_id from EMPLOYEE_Departemnts where pmp_id=" + pmp);
        sql = "SELECT DISTINCT dbo.Project.Proj_Title, dbo.Project.Proj_id, dbo.EMPLOYEE.pmp_name, dbo.Departments.Dept_name, dbo.Departments.Dept_ID FROM dbo.Departments INNER JOIN dbo.Project ON dbo.Departments.Dept_ID = dbo.Project.Dept_Dept_id INNER JOIN  dbo.EMPLOYEE ON dbo.Project.pmp_pmp_id = dbo.EMPLOYEE.PMP_ID INNER JOIN dbo.Project_Activities ON dbo.Project.Proj_id = dbo.Project_Activities.proj_proj_id WHERE     (dbo.Project_Activities.ActStat_ActStat_id <> 3) AND (CONVERT(datetime, dbo.Project_Activities.PActv_End_Date, 103) < GETDATE()) ";
        sql += " AND dbo.Departments.Dept_ID = " + dept_id;
        if (DT.Rows.Count > 1)
        {
            for (int i = 1; i < DT.Rows.Count; i++)
            {
                sql += " or dbo.Departments.Dept_ID = " + CDataConverter.ConvertToInt(DT.Rows[i]["dept_id"].ToString());
            }
        }
        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        DataTable dt_Report = new DataTable();
        da.Fill(dt_Report);
        string s = Server.MapPath("../Reports/DelayProjects.rpt");
        rd.Load(s);
        rd.SetDataSource(dt_Report);
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
        //DelayProjectsReport();
        //Label2.Text = Page.Title;
        //string user = Session_CS.pmp_name.ToString();
        //ReportDocument rd = new ReportDocument();
        //string s = Server.MapPath("../Reports/DelayProjects.rpt");
        //rd.Load(s);
        //Load_Report(rd);

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
    protected void DropDate_SelectedIndexChanged(object sender, EventArgs e)
    {
        Label6.Visible = false;
    }
    protected void ImgBtnBack_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("../mainform/DepartmentmngallReports.aspx");
    }
    protected void Droporg_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void linkAllBalance_report_Click(object sender, EventArgs e)
    {
        Yeardate();
        hidden_Rpt_Id.Value = "linkAllBalance_report";
        Div_Proj.Style.Add("display", "none");
        Div_Proj_Mngr.Style.Add("display", "none");
        Div_Date_balance.Style.Add("display", "none");
        Div_Dept.Style.Add("display", "none");

        Div_Balance.Style.Add("display", "block");
        show_hide_tables();
        Page.Title = "تقرير " + linkAllBalance_report.Text;
        Label6.Visible = false;
        Label2.Visible = true;
        Label2.Text = Page.Title;

    }
    protected void projectbalance_status_Click(object sender, EventArgs e)
    {

        hidden_Rpt_Id.Value = "projectbalance_status_report";
        Div_Proj.Style.Add("display", "block");
        Div_Proj_Mngr.Style.Add("display", "none");
        Div_Date_balance.Style.Add("display", "none");
        Div_Dept.Style.Add("display", "none");

        Div_Balance.Style.Add("display", "none");
        show_hide_tables();
        Page.Title = "تقرير " + projectbalance_status.Text;
        Label6.Visible = false;
        Label2.Visible = true;
        Label2.Text = Page.Title;

    }


    protected void needhighinetrLB_Click(object sender, EventArgs e)
    {
        hidden_Rpt_Id.Value = "needhighinter_Report";
        Div_Proj.Style.Add("display", "block");
        Div_Proj_Mngr.Style.Add("display", "block");
        Div_Date_Needs.Style.Add("display", "none");
        Div_Dates_Demands.Style.Add("display", "none");
        //Div_Dept.Style.Add("display", "block");
        Div_Date_balance.Style.Add("display", "none");
        Div_Dept.Style.Add("display", "none");

        show_hide_tables();
        Label6.Visible = false;
        Page.Title = "تقرير " + needhighinetrLB.Text;
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

        Div_Date_balance.Style.Add("display", "none");
        Div_Dept.Style.Add("display", "none");


        int dept_id = int.Parse(Session_CS.dept_id.ToString());
        int pmp = int.Parse(Session_CS.pmp_id.ToString());
        DataTable DT = General_Helping.GetDataTable("select dept_id from EMPLOYEE_Departemnts where pmp_id=" + pmp);
        sql = "set dateformat dmy ";
        sql += " SELECT dbo.Departments.Dept_name,dbo.Departments.Dept_ID, dbo.Project.Proj_Title, dbo.Project.Proj_id, dbo.Project.Dept_Dept_id,year(convert(datetime,dbo.datevalid(dbo.Project.Proj_End_Date),103)) AS valid_date FROM dbo.Departments INNER JOIN dbo.Project ON dbo.Departments.Dept_ID = dbo.Project.Dept_Dept_id ";
        sql += " where dbo.Departments.Dept_ID = " + dept_id;
        if (DT.Rows.Count > 1)
        {
            for (int i = 1; i < DT.Rows.Count; i++)
            {
                sql += " or dbo.Departments.Dept_ID  = " + CDataConverter.ConvertToInt(DT.Rows[i]["dept_id"].ToString());
            }
        }


        string user = Session_CS.pmp_name.ToString();
        ReportDocument rd = new ReportDocument();
        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        DataTable dt_report = new DataTable();
        da.Fill(dt_report);
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
    protected void Projects_Status_Click(object sender, EventArgs e)
    {
        hidden_Rpt_Id.Value = "Projects_Status_Report";
        Div_Proj.Style.Add("display", "none");
        Div_Proj_Mngr.Style.Add("display", "none");
        Div_Date_Needs.Style.Add("display", "none");
        Div_Dates_Demands.Style.Add("display", "none");
        Div_Date_balance.Style.Add("display", "none");
        Div_Dept.Style.Add("display", "none");

        int dept_id = int.Parse(Session_CS.dept_id.ToString());
        int pmp = int.Parse(Session_CS.pmp_id.ToString());

        string sqltest = " SELECT dbo.Project.Proj_id, dbo.Project.pmp_pmp_id, dbo.Project.Proj_Title, dbo.EMPLOYEE.pmp_name, dbo.Project.Proj_InitValue,Project.Proj_is_commit,Project.Proj_is_refused,Project.Proj_is_repeated,CONVERT(datetime, Project.Proj_Creation_Date, 103) AS Proj_Creation_Date, CONVERT(datetime, Project.proj_start_date, 103) AS proj_start_date,CONVERT(datetime, Project.Proj_End_Date, 103) AS Proj_End_Date,dbo.Project.Proj_Notes,Departments.Dept_id,Departments.Dept_name FROM dbo.Project LEFT OUTER JOIN dbo.Departments ON dbo.Departments.Dept_id = dbo.Project.Dept_Dept_id LEFT OUTER JOIN dbo.EMPLOYEE ON dbo.Project.pmp_pmp_id = dbo.EMPLOYEE.PMP_ID where 1=1  and  (pmp_pmp_id = '" + pmp + "'  or Project.Dept_Dept_id in (select Dept_id from EMPLOYEE_Departemnts where PMP_ID = '" + pmp + "') or (Project.Proj_id IN  (SELECT  Project_Team.proj_proj_id FROM Project_Team INNER JOIN Project ON Project_Team.proj_proj_id = Project.Proj_id  WHERE (Edit_Project = 'true') and(Project_Team.pmp_pmp_id = '" + pmp + "'))))";


      //  DataTable DT = General_Helping.GetDataTable("select dept_id from EMPLOYEE_Departemnts where pmp_id=" + pmp);
      //  sql = " SELECT dbo.Project.Proj_id, dbo.Project.Proj_Title, dbo.EMPLOYEE.pmp_name, dbo.Project.Proj_InitValue, dbo.Project.Proj_is_commit, CONVERT(datetime,dbo.Project.Proj_Creation_Date, 103) AS Proj_Creation_Date, CONVERT(datetime, dbo.Project.proj_start_date, 103) AS proj_start_date,CONVERT(datetime, dbo.Project.Proj_End_Date, 103) AS Proj_End_Date, dbo.Departments.Dept_name, dbo.Departments.Dept_ID FROM dbo.Departments INNER JOIN dbo.Project ON dbo.Departments.Dept_ID = dbo.Project.Dept_Dept_id INNER JOIN  dbo.EMPLOYEE ON dbo.Project.pmp_pmp_id = dbo.EMPLOYEE.PMP_ID";
       // sql += " where dbo.Departments.Dept_ID = " + dept_id;
        //if (dt.Rows.Count > 1)
        //{
        //    for (int i = 1; i < DT.Rows.Count; i++)
        //    {
        //        sql += " or dbo.Departments.Dept_ID  = " + CDataConverter.ConvertToInt(DT.Rows[i]["dept_id"].ToString());
        //    }
        //}
        string user = Session_CS.pmp_name.ToString();
        SqlDataAdapter da = new SqlDataAdapter(sqltest, conn);
        DataTable dt_report = new DataTable();
        da.Fill(dt_report);
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
    protected void projects_Org_Click(object sender, EventArgs e)
    {
        //hidden_Rpt_Id.Value = "projects_Org";
        //Div_Proj.Style.Add("display", "none");
        //Div_Proj_Mngr.Style.Add("display", "none");
        //Div_Date_Needs.Style.Add("display", "none");
        //Div_Dates_Demands.Style.Add("display", "none");
        //Div_Org.Style.Add("display", "block");
        //show_hide_tables();
        //Div_Date_balance.Style.Add("display", "none");
        //Label2.Visible = true;
        //Label6.Visible = false;
        //Page.Title = "تقرير " + projects_Org.Text;
        //Label2.Text = Page.Title;

    }
    protected void summation_need_deptLB_Click(object sender, EventArgs e)
    {
        int dept_id = int.Parse(Session_CS.dept_id.ToString());
        int pmp = int.Parse(Session_CS.pmp_id.ToString());
        SqlConnection conn = new SqlConnection(sql_Connection);
        //hidden_Rpt_Id.Value = "ProjectsEmployees_Report";
        Div_Proj.Style.Add("display", "none");
        Div_Proj_Mngr.Style.Add("display", "noe");
        Div_Date_Needs.Style.Add("display", "none");
        Div_Dates_Demands.Style.Add("display", "none");
        Div_Date_balance.Style.Add("display", "none");
        Div_Dept.Style.Add("display", "none");

        //show_hide_tables();
        Label2.Visible = true;
        Label6.Visible = false;
        Page.Title = "تقرير " + summation_need_deptLB.Text;
        Label2.Text = Page.Title;

        sql = "SELECT sum((Project_Needs.PNed_Number)*(Project_Needs.PNed_InitValue)) as Sumation,dept_id,dept_name,proj_id,Proj_Title FROM dbo.Departments inner JOIN dbo.Project ON dbo.Departments.Dept_ID = dbo.Project.Dept_Dept_id INNER JOIN dbo.Project_Needs ON dbo.Project.Proj_id = dbo.Project_Needs.proj_proj_id";
        sql += " where 1=1 ";
        //sql += " and approved_amount=0";
        DataTable DT = General_Helping.GetDataTable("select dept_id from EMPLOYEE_Departemnts where pmp_id=" + pmp);

        //string sql = "SELECT Project.proj_id,Project.Proj_Title, Departments.Dept_name, Project.Dept_Dept_id , Project.Pmp_pmp_id , employee.pmp_name,(select COUNT(Project_Activities.proj_proj_id) from Project_Activities where Project_Activities.proj_proj_id=project.Proj_id AND PActv_Parent=0) as  Parent_Act_Count,(select COUNT(Project_Activities.proj_proj_id) from Project_Activities where Project_Activities.proj_proj_id=project.Proj_id AND PActv_Parent<>0) as  child_Act_Count,(select COUNT(Project_Needs.proj_proj_id) from Project_Needs where Project_Needs.proj_proj_id=project.Proj_id ) as Pneeds,(select COUNT(Project_Objective.proj_proj_id) from Project_Objective where Project_Objective.proj_proj_id=project.Proj_id ) as proj_obj,(select COUNT(Project_Team.proj_proj_id) from Project_Team where Project_Team.proj_proj_id=project.Proj_id ) as proj_team,(select COUNT(Project_Organization.proj_proj_id) from Project_Organization where Project_Organization.proj_proj_id=project.Proj_id ) as proj_org FROM Departments INNER JOIN Project ON Departments.Dept_ID = Project.Dept_Dept_id LEFT OUTER JOIN employee on project.pmp_pmp_id=employee.pmp_id";
        sql += " AND dept_id = " + dept_id;
        if (DT.Rows.Count > 1)
        {
            for (int i = 0; i < DT.Rows.Count; i++)
            {
                sql += " or dept_id = " + CDataConverter.ConvertToInt(DT.Rows[i]["dept_id"].ToString());
            }
        }
        sql += " group by dept_id,dept_name,proj_id,Proj_Title";
        DataTable DT_Report = General_Helping.GetDataTable(sql);

        string user = Session_CS.pmp_name.ToString();
        ReportDocument rd = new ReportDocument();
        string s = Server.MapPath("../Reports/summation_need_projects.rpt");
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
            rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report");
        }
    }
    protected void surprise_Click(object sender, EventArgs e)
    {

        //SqlConnection conn = new SqlConnection(sql_Connection);
        ////hidden_Rpt_Id.Value = "ProjectsEmployees_Report";
        //Div_Proj.Style.Add("display", "none");
        //Div_Proj_Mngr.Style.Add("display", "noe");
        //Div_Date_Needs.Style.Add("display", "none");
        //Div_Dates_Demands.Style.Add("display", "none");
        //Div_Date_balance.Style.Add("display", "none");
        ////show_hide_tables();
        ////Label2.Visible = true;
        ////Label6.Visible = false;
        ////Page.Title = "تقرير " + surprise.Text;
        ////Label2.Text = Page.Title;



        //string user = Session_CS.pmp_name.ToString();
        //ReportDocument rd = new ReportDocument();
        //string s = Server.MapPath("../Reports/surprised_Report.rpt");
        //rd.Load(s);
        //Load_Report(rd);


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
    protected void needs_in_detailLB_Click(object sender, EventArgs e)
    {
        hidden_Rpt_Id.Value = "needs_in_details_Report";
        Div_Proj.Style.Add("display", "block");
        Div_Proj_Mngr.Style.Add("display", "block");
        Div_Date_balance.Style.Add("display", "none");
        Div_Date_Needs.Style.Add("display", "none");
        Div_Dates_Demands.Style.Add("display", "none");
        Div_Dept.Style.Add("display", "none");

        Label6.Visible = false;
        Label2.Visible = true;

        show_hide_tables();
        Page.Title = "تقرير " + needs_in_detailLB.Text;
        Label2.Text = Page.Title;
    }
    protected void Similar_ProjectLB_Click(object sender, EventArgs e)
    {
        hidden_Rpt_Id.Value = "similar_projects_Report";
        Div_Proj.Style.Add("display", "block");
        Div_Proj_Mngr.Style.Add("display", "none");
        Div_Date_balance.Style.Add("display", "none");
        Div_Date_Needs.Style.Add("display", "none");
        Div_Dates_Demands.Style.Add("display", "none");
        Div_Dept.Style.Add("display", "none");

        Div_Org.Style.Add("display", "none");
        Div_technology_category.Style.Add("display", "none");
        Label6.Visible = false;
        Label2.Visible = true;

        show_hide_tables();
        Page.Title = "تقرير " + Similar_ProjectLB.Text;
        Label2.Text = Page.Title;
    }


    protected void Portal_data_Click(object sender, EventArgs e)
    {
        hidden_Rpt_Id.Value = "Portal_data_Report";
        Div_Proj.Style.Add("display", "block");
        Div_Proj_Mngr.Style.Add("display", "none");
        Div_Date_balance.Style.Add("display", "none");
        Div_Date_Needs.Style.Add("display", "none");
        Div_Dates_Demands.Style.Add("display", "none");
        Div_Dept.Style.Add("display", "none");

        Div_Org.Style.Add("display", "none");
        Div_technology_category.Style.Add("display", "none");
        Label6.Visible = false;
        Label2.Visible = true;
        show_hide_tables();
        Page.Title = "تقرير " + Lnk_Portal_data .Text;
        Label2.Text = Page.Title;
    }



    protected void lnk_Tender_Click(object sender, EventArgs e)
    {
        hidden_Rpt_Id.Value = "Tender_Report";
        Div_Proj.Style.Add("display", "block");
        Div_Proj_Mngr.Style.Add("display", "block");
        Div_Date_Needs.Style.Add("display", "none");
        Div_Dates_Demands.Style.Add("display", "none");
        Div_Date_balance.Style.Add("display", "none");
        Div_Dept.Style.Add("display", "none");

        Div_Balance.Style.Add("display", "block");
        show_hide_tables();
        Label6.Visible = false;
        Page.Title = "تقرير " + lnk_Tender.Text;
        Label2.Visible = true;
        Label2.Text = Page.Title;
        Drop_Date_fun();
    }
    public void Drop_Date_fun()
    {
        for (int i = 0; i < 41; i++)
        {
            //Drop_balance.Items.Add(DateTime.Now.Year + i);

            int year = CDataConverter.ConvertDateTimeNowRtnDt().Year  - 10 + i;
            string yearshowed = (year + 1) + "/" + year;
            //Drop_balance.Items.Add(year.ToString());
            Drop_balance.Items.Add(yearshowed);
            Drop_balance.DataBind();

        }
        Drop_balance.Items.Insert(0, new ListItem("اختر السنة المالية المطلوبة......", "0"));
    }
    protected void sug_plan_Click(object sender, EventArgs e)
    {
        hidden_Rpt_Id.Value = "sug_plan";
        Yeardate();
        Div_Proj.Style.Add("display", "block");
        Div_Proj_Mngr.Style.Add("display", "block");
        Div_Date_Needs.Style.Add("display", "none");
        Div_Dates_Demands.Style.Add("display", "none");
        Div_Date_balance.Style.Add("display", "none");
        Div_Dept.Style.Add("display", "none");

        show_hide_tables();
        Label6.Visible = false;
        Page.Title = "تقرير " + sug_plan.Text;
        Label2.Visible = true;
        Label2.Text = Page.Title;
        Div_Balance.Style.Add("display", "block");

    }

    public void Yeardate()
    {

        for (int i = 0; i < 41; i++)
        {
            //Drop_balance.Items.Add(DateTime.Now.Year + i);

            int year = CDataConverter.ConvertDateTimeNowRtnDt().Year  - 10 + i;
            string yearshowed = (year + 1) + "/" + year;
            //Drop_balance.Items.Add(year.ToString());
            Drop_balance.Items.Add(yearshowed);
            Drop_balance.DataBind();

        }
        Drop_balance.Items.Insert(0, new ListItem("اختر السنة المالية المطلوبة......", "0"));
    }
    protected void Indicator_developLB_Click(object sender, EventArgs e)
    {
        show_hide_tables();

        hidden_Rpt_Id.Value = "Indicator_Development_Report";

        Div_Proj.Style.Add("display", "block");
        Div_Proj_Mngr.Style.Add("display", "block");
        Div_Date_Needs.Style.Add("display", "none");
        Div_Dates_Demands.Style.Add("display", "none");
        Div_Date_balance.Style.Add("display", "none");
        Div_Dept.Style.Add("display", "none");

        Div_Main_Activity.Style.Add("display", "block");
        Div_sub_Activity.Style.Add("display", "block");
        Label2.Visible = true;

        Page.Title = "تقرير " + Indicator_developLB.Text;
        Label2.Text = Page.Title;
        Label6.Visible = false;
    }

    protected void Existence_Emp_Click(object sender, EventArgs e)
    {
        show_hide_tables();

        hidden_Rpt_Id.Value = "Existence_Emp";

        Div_Proj.Style.Add("display", "none");
        Div_Proj_Mngr.Style.Add("display", "none");
        Div_Date_Needs.Style.Add("display", "none");
        Div_Dates_Demands.Style.Add("display", "none");
        Div_Date_balance.Style.Add("display", "none");
        Div_Dept.Style.Add("display", "block");

        Div_Main_Activity.Style.Add("display", "none");
        Div_sub_Activity.Style.Add("display", "none");
        Label2.Visible = true;

        Page.Title = "تقرير " + Lnk_Exist.Text;
        Label2.Text = Page.Title;
        Label6.Visible = false;
    }
}
