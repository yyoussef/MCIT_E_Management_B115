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

//using Microsoft.Office.Interop.Word;

public partial class WebForms_Protocols_Reports : System.Web.UI.Page
{
    Session_CS Session_CS = new Session_CS();
    string sql;
    SqlConnection conn;
    SqlDataAdapter da;
    DataSet ds;
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

        #region BROWSER FOR departments

        //Smrt_Srch_DropDep.sql_Connection = sql_Connection;
        //Smrt_Srch_DropDep.Query = "select Dept_ID,Dept_name from Departments where Dept_ID <> 6";
        //Smrt_Srch_DropDep.Value_Field = "Dept_ID";
        //Smrt_Srch_DropDep.Text_Field = "Dept_name";
        //Smrt_Srch_DropDep.DataBind();
        //this.Smrt_Srch_DropDep.Value_Handler += new Smart_Search.Delegate_Selected_Value(MOnMember_Data);

        //this.obj_Browserdept = new cBrowser(this, "select Dept_ID,Dept_name from Departments", "الإدارات", 5);

        //this.obj_Browserdept.MAddField("Dept_name", "اسم الإدارة", 150, BrowserFieldType.NIString);

        //this.obj_Browserdept.ID = "obj_Browserdept";

        //this.obj_Browserdept.BrowseData += new BrowseDataEventHandler(MOnMember_Data);


        ////////////////////////////////////////////////////////////
        //ht5dy dh st//


        //Smrt_Srch_projmanage.sql_Connection = sql_Connection;
        //Smrt_Srch_projmanage.Query = "select PMP_ID,rol_rol_id,pmp_name from dbo.EMPLOYEE where rol_rol_id=4";
        //Smrt_Srch_projmanage.Value_Field = "PMP_ID";
        //Smrt_Srch_projmanage.Text_Field = "pmp_name";
        //Smrt_Srch_projmanage.DataBind();
        //this.Smrt_Srch_projmanage.Value_Handler += new Smart_Search.Delegate_Selected_Value(MOnMember_Datamanage);

        //this.obj_Browsermanage = new cBrowser(this, "select distinct pmp_pmp_id , PTem_Name from dbo.Project_Team where rol_rol_id=4", "مديرين المشروعات", 5);

        //this.obj_Browsermanage.MAddField("PTem_Name", "اسم مدير المشروع", 150, BrowserFieldType.NIString);

        //this.obj_Browsermanage.ID = "obj_Browsermanage";

        //this.obj_Browsermanage.BrowseData += new BrowseDataEventHandler(MOnMember_Datamanage);
        Smart_org.sql_Connection = sql_Connection;
        //Smart_org.Query = "select Org_id,Org_desc from Organization ";
        string Query = "select Org_id,Org_desc from Organization ";
        Smart_org.datatble = General_Helping.GetDataTable(Query);
        Smart_org.Value_Field = "Org_id";
        Smart_org.Text_Field = "Org_desc";
        Smart_org.DataBind();


        
      
        //this.Smart_Search_main.Value_Handler += new Smart_Search.Delegate_Selected_Value(MOnMember_subactivities);


        #endregion


        base.OnInit(e);
    }


    private void MOnMember_Data(string Value)
    {
        //dropdept_fun();
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


                //// ImgBtnResearch.Attributes.Add("OnClick", this.obj_Browserdept.ClientSideFunction);
                ///////////// ht5dy hena///////////////////////////////////////
                //// ImageButtonmanage.Attributes.Add("OnClick", this.obj_Browsermanage.ClientSideFunction);
                /////////////// end hena ///////////////////////////////////////////
                //int pmp = int.Parse(Session_CS.pmp_id.ToString());
                ////////////////////////////////////// get project manager data to drop list ////////////////////
                //sql = "select distinct pmp_pmp_id,PTem_Name,rol_rol_id from dbo.Project_Team where rol_rol_id=4";
                //ds = new DataSet();
                //da = new SqlDataAdapter(sql, conn);
                //da.Fill(ds, "projectsmanage");
                ////Dropprojmanage.DataSource = ds.Tables[0];
                ////Dropprojmanage.DataTextField = "PTem_Name";
                ////Dropprojmanage.DataValueField = "pmp_pmp_id";
                ////Dropprojmanage.DataBind();
                ////Dropprojmanage.Items.Insert(0, new ListItem("اختر اسم مدير المشروع ......", "0"));
                ////DropProj.Items.Insert(0, new ListItem("اختر اسم  المشروع ......", "0"));

                //sql = "select id,proj_category from Category";
                //ds = new DataSet();
                //da = new SqlDataAdapter(sql, conn);
                //da.Fill(ds, "category");
                //Drop_category.DataSource = ds.Tables[0];
                //Drop_category.DataValueField = "id";
                //Drop_category.DataTextField = "proj_category";
                //Drop_category.DataBind();
                //Drop_category.Items.Insert(0, new ListItem("اختر التصنيف......", "0"));
                ///////////////////////////////////// get techniqe from tabel to drop list /////////////////////
                //sql = "select id,technique from Technique";
                //ds = new DataSet();
                //da = new SqlDataAdapter(sql, conn);
                //da.Fill(ds, "Technique");
                //Drop_technology.DataSource = ds.Tables[0];
                //Drop_technology.DataValueField = "id";
                //Drop_technology.DataTextField = "technique";
                //Drop_technology.DataBind();
                //Drop_technology.Items.Insert(0, new ListItem("اختر التقنية......", "0"));
                /////////////////////// get data tp departments drop list /////////////////////////
                //sql = "select Dept_ID,Dept_name from Departments";
                //ds = new DataSet();
                //da = new SqlDataAdapter(sql, conn);
                //da.Fill(ds, "dept");
                ////DropDep.DataSource = ds.Tables[0];
                ////DropDep.DataTextField = "Dept_name";
                ////DropDep.DataValueField = "Dept_ID";
                ////DropDep.DataBind();
                ////DropDep.Items.Insert(0, new ListItem("اختر اسم الإدارة......", "0"));
                ////////////////////// get dates from store to drop list /////////////////////////////
                //sql = "select id,convert(nvarchar,available_Date,111) as Date,available_Date from Store";
                //ds = new DataSet();
                //da = new SqlDataAdapter(sql, conn);
                //da.Fill(ds, "dates");
                //DropDate.DataSource = ds.Tables[0];
                //DropDate.DataValueField = "available_Date";
                //DropDate.DataTextField = "Date";
                //DropDate.DataBind();
                //DropDate.Items.Insert(0, new ListItem("اختر تاريخ الصرف المطلوب......", "0"));

                /////////////////// get organizations from org table to drop list////////////////
                //sql = "SELECT DISTINCT dbo.Organization.Org_Desc, dbo.Organization.Org_ID";
                //sql += " FROM dbo.Organization INNER JOIN dbo.Project_Organization ON dbo.Organization.Org_ID = dbo.Project_Organization.org_org_id";
                //ds = new DataSet();
                //da = new SqlDataAdapter(sql, conn);
                //da.Fill(ds, "org");
                //Droporg.DataSource = ds.Tables[0];
                //Droporg.DataValueField = "Org_ID";
                //Droporg.DataTextField = "Org_Desc";
                //Droporg.DataBind();
                //Droporg.Items.Insert(0, new ListItem("اختر الجهة المستفيدة ......", "0"));
                //// ahmed salah account //
                //int group_id = int.Parse(Session_CS.group_id.ToString());
                
                //if (group_id == 6)

                //{ 
                //    NeedsTR.Visible = false;
                //   FinanceTr.Visible = false;
                //   Label1.Text = "التقارير ";
                //}
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
    
    protected void Ended_protocol_cont_proj_Click(object sender, EventArgs e)
    {
        hidden_Rpt_Id.Value = "Ended_protocol_cont_proj_Report";
        Div_Date_end.Style.Add("display", "block");
        Div_Org.Style.Add("display", "block");
        show_hide_tables();
        Label6.Visible = false;
        Page.Title = "تقرير " + Ended_protocol_cont_proj.Text;
        Label2.Visible = true;
        Label2.Text = Page.Title;


    }
    protected void Ended_protocol_ended_proj_Click(object sender, EventArgs e)
    {
        hidden_Rpt_Id.Value = "Ended_protocol_ended_proj_Report";
        Div_Date_end.Style.Add("display", "block");
        Div_Org.Style.Add("display", "block");
        show_hide_tables();
        Label6.Visible = false;
        Page.Title = "تقرير " + Ended_protocol_ended_proj.Text;
        Label2.Visible = true;
        Label2.Text = Page.Title;


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

            //Smart_Search_Proj.sql_Connection = sql_Connection;
            //Smart_Search_Proj.Query = "select proj_title,proj_id from project JOIN Project_Team ON Project.Proj_id = dbo.Project_Team.proj_proj_id  where Proj_is_commit=2 and Project_Team.rol_rol_id = 4 and Project_Team.pmp_pmp_id= " + Smrt_Srch_projmanage.SelectedValue;
            //Smart_Search_Proj.Value_Field = "proj_id";
            //Smart_Search_Proj.Text_Field = "proj_title";
            //Smart_Search_Proj.DataBind();

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
   


   
    protected void dropdept_fun()
    {
        string Query = "";
        //SqlConnection conn = new SqlConnection(sql_Connection);
        if (Smrt_Srch_DropDep.SelectedValue != "")
        {
            //sql = "select Proj_id,Proj_Title from Project";
            //ds = new DataSet();
            //da = new SqlDataAdapter(sql, conn);
            //da.Fill(ds, "projects");
            //DropProj.DataSource = ds.Tables[0];
            //DropProj.DataTextField = "Proj_Title";
            //DropProj.DataValueField = "Proj_id";
            //DropProj.DataBind();
            //DropProj.Items.Insert(0, new ListItem("اختر اسم المشروع......", "0"));
            Smrt_Srch_projmanage.sql_Connection = sql_Connection;
           // Smrt_Srch_projmanage.Query = "select PMP_ID,pmp_name from dbo.EMPLOYEE where rol_rol_id=4 and Dept_Dept_id=" + Smrt_Srch_DropDep.SelectedValue;
            Query = "select PMP_ID,pmp_name from dbo.EMPLOYEE where rol_rol_id=4 and Dept_Dept_id=" + Smrt_Srch_DropDep.SelectedValue;
            Smrt_Srch_projmanage.datatble = General_Helping.GetDataTable(Query);
            Smrt_Srch_projmanage.Value_Field = "PMP_ID";
            Smrt_Srch_projmanage.Text_Field = "pmp_name";
            Smrt_Srch_projmanage.DataBind();
           
        }
        else
        {
            Smrt_Srch_projmanage.sql_Connection = sql_Connection;
           // Smrt_Srch_projmanage.Query = "select PMP_ID,rol_rol_id,pmp_name from dbo.EMPLOYEE where rol_rol_id=4";
            Query = "select PMP_ID,rol_rol_id,pmp_name from dbo.EMPLOYEE where rol_rol_id=4";
            Smrt_Srch_projmanage.datatble = General_Helping.GetDataTable(Query);
            Smrt_Srch_projmanage.Value_Field = "PMP_ID";
            Smrt_Srch_projmanage.Text_Field = "pmp_name";
            Smrt_Srch_projmanage.DataBind();

           
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
        int org = 0;
        string t1 = "";
        string t2 = "";
        /////////////////////////////////////////////////////////// Indicator type Report ///////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        if (hidden_Rpt_Id.Value == "Ended_protocol_cont_proj_Report")
        {
            SqlConnection conn = new SqlConnection(sql_Connection);
          
            sql = "set dateformat dmy SELECT DISTINCT dbo.Protocol_Main_Def.Protocol_ID, dbo.Protocol_Main_Def.Name, dbo.Protocol_Main_Def.End_DT, CONVERT(datetime, dbo.datevalid(dbo.Protocol_Main_Def.End_DT), 103) AS End_date_converted, dbo.Project.Proj_is_commit FROM dbo.Protocol_Main_Def left outer JOIN dbo.Protocol_Main_Org ON dbo.Protocol_Main_Def.Protocol_ID = dbo.Protocol_Main_Org.Protocol_ID left outer JOIN dbo.Organization ON dbo.Protocol_Main_Org.Org_ID = dbo.Organization.Org_ID LEFT OUTER JOIN dbo.Project ON dbo.Protocol_Main_Def.Protocol_ID = dbo.Project.Protocol_ID WHERE 1=1";     
            sql+= " AND (dbo.Project.Proj_is_commit = 2)";
            sql += " AND CONVERT(datetime, dbo.datevalid(dbo.Protocol_Main_Def.End_DT), 103) < GETDATE()";
            
            if (Smart_org.SelectedValue != "")
            {
                org  = int.Parse(Smart_org.SelectedValue);
                sql += " AND dbo.Organization.Org_ID =" + org;
            }

            if (string.IsNullOrEmpty(Date_end_from.Text) && string.IsNullOrEmpty(Date_end_to.Text))
            {

                t1 = DateTime.ParseExact("01/01/1900", "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
                t2 = DateTime.MaxValue.ToString("dd/MM/yyyy");

            }
            else if (string.IsNullOrEmpty(Date_end_from.Text))
            {
                if (Date_end_to.Text.Trim() != "")

                    //if (VB_Classes.Dates.Dates_Operation.date_validate(Date_end_to.Text.Trim()) != "")
                {
                    t1 = DateTime.ParseExact("01/01/1900", "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
                    //t2 = DateTime.ParseExact(Inbox_date_to.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
                   // t2 = VB_Classes.Dates.Dates_Operation.date_validate(Date_end_to.Text.Trim());

                    t2 = Date_end_to.Text.Trim();
                    sql += " AND CONVERT(datetime, dbo.datevalid(dbo.Protocol_Main_Def.End_DT), 103) < = '" + t2.ToString() + "'";
                }
                else
                {
                    ShowAlertMessage("!!!!!ادخل التاريخ بطريقة صحيحة !!!!");
                    return;
                }
            }
            else if (string.IsNullOrEmpty(Date_end_to.Text))
            {
                if (Date_end_from.Text.Trim() != "")
                    //if (VB_Classes.Dates.Dates_Operation.date_validate(Date_end_from.Text.Trim()) != "")
                {
                    //t1 = DateTime.ParseExact(Inbox_date_from.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
                    t2 = DateTime.MaxValue.ToString("dd/MM/yyyy");
                    t1 = Date_end_from.Text.Trim();

                    //t1 = VB_Classes.Dates.Dates_Operation.date_validate(Date_end_from.Text.Trim());
                    sql += " AND CONVERT(datetime, dbo.datevalid(dbo.Protocol_Main_Def.End_DT), 103) > = '" + t1.ToString() + "'";

                }
                else
                {
                    ShowAlertMessage("!!!!!ادخل التاريخ بطريقة صحيحة !!!!");
                    return;
                }
            }
            else
            {
                if (Date_end_to.Text.Trim() != "" && Date_end_from.Text.Trim() != "")
                  //  if (VB_Classes.Dates.Dates_Operation.date_validate(Date_end_to.Text.Trim()) != "" && VB_Classes.Dates.Dates_Operation.date_validate(Date_end_from.Text.Trim()) != "")

                
                {
                    //t1 = DateTime.ParseExact(Inbox_date_from.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
                    t2 = Date_end_to.Text.Trim();

                   // t2 = VB_Classes.Dates.Dates_Operation.date_validate(Date_end_to.Text.Trim());
                    //t2 = DateTime.ParseExact(Inbox_date_to.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
                    t1 = Date_end_from.Text.Trim();

                    //t1 = VB_Classes.Dates.Dates_Operation.date_validate(Date_end_from.Text.Trim());
                    sql += " AND CONVERT(datetime, dbo.datevalid(dbo.Protocol_Main_Def.End_DT), 103) > = '" + t1.ToString() + "'";
                    sql += " AND CONVERT(datetime, dbo.datevalid(dbo.Protocol_Main_Def.End_DT), 103) < = '" + t2.ToString() + "'";
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
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);



            string user = Session_CS.pmp_name.ToString();
            ReportDocument rd = new ReportDocument();
            string s = Server.MapPath("../Reports/finished_protocal_cont_proj.rpt");
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
            ///////////////////////////////////////////////////// finished Protocols finished projects /////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        else if (hidden_Rpt_Id.Value=="Ended_protocol_ended_proj_Report")
        {
             SqlConnection conn = new SqlConnection(sql_Connection);
          
            sql = "SELECT DISTINCT dbo.Protocol_Main_Def.Protocol_ID, dbo.Protocol_Main_Def.Name, dbo.Protocol_Main_Def.End_DT, CONVERT(datetime,dbo.datevalid(dbo.Protocol_Main_Def.End_DT), 103) AS End_date_converted FROM  dbo.Protocol_Main_Def INNER JOIN dbo.Project ON dbo.Protocol_Main_Def.Protocol_ID = dbo.Project.Protocol_ID INNER JOIN  dbo.Protocol_Main_Org ON dbo.Protocol_Main_Def.Protocol_ID = dbo.Protocol_Main_Org.Protocol_ID INNER JOIN dbo.Organization ON dbo.Protocol_Main_Org.Org_ID = dbo.Organization.Org_ID WHERE     (1 = 1) AND CONVERT(datetime, dbo.datevalid(dbo.Protocol_Main_Def.End_DT), 103) < GETDATE() AND (dbo.Protocol_Main_Def.Protocol_ID NOT IN (SELECT DISTINCT Protocol_ID FROM         dbo.Project AS Project_1 WHERE     (Proj_is_commit = 2) AND (Protocol_ID IS NOT NULL)))";
            
            if (Smart_org.SelectedValue != "")
            {
                org  = int.Parse(Smart_org.SelectedValue);
                sql += " AND dbo.Organization.Org_ID =" + org;
            }

            if (string.IsNullOrEmpty(Date_end_from.Text) && string.IsNullOrEmpty(Date_end_to.Text))
            {

                t1 = DateTime.ParseExact("01/01/1900", "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
                t2 = DateTime.MaxValue.ToString("dd/MM/yyyy");

            }
            else if (string.IsNullOrEmpty(Date_end_from.Text))
            {
                if (Date_end_to.Text.Trim() != "")

                  //  if (VB_Classes.Dates.Dates_Operation.date_validate(Date_end_to.Text.Trim()) != "")
                
                {
                    t1 = DateTime.ParseExact("01/01/1900", "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
                    //t2 = DateTime.ParseExact(Inbox_date_to.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
                   // t2 = VB_Classes.Dates.Dates_Operation.date_validate(Date_end_to.Text.Trim());

                    t2 = Date_end_to.Text.Trim();
                    sql += " AND CONVERT(datetime, dbo.datevalid(dbo.Protocol_Main_Def.End_DT), 103) < = '" + t2.ToString() + "'";
                }
                else
                {
                    ShowAlertMessage("!!!!!ادخل التاريخ بطريقة صحيحة !!!!");
                    return;
                }
            }
            else if (string.IsNullOrEmpty(Date_end_to.Text))
            {
                if (Date_end_from.Text.Trim() != "")
               //     if (VB_Classes.Dates.Dates_Operation.date_validate(Date_end_from.Text.Trim()) != "")
                
                
                {
                    //t1 = DateTime.ParseExact(Inbox_date_from.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
                    t2 = DateTime.MaxValue.ToString("dd/MM/yyyy");
                    t1 = Date_end_from.Text.Trim();
                    //t1 = VB_Classes.Dates.Dates_Operation.date_validate(Date_end_from.Text.Trim());
                    sql += " AND CONVERT(datetime, dbo.datevalid(dbo.Protocol_Main_Def.End_DT), 103) > = '" + t1.ToString() + "'";

                }
                else
                {
                    ShowAlertMessage("!!!!!ادخل التاريخ بطريقة صحيحة !!!!");
                    return;
                }
            }
            else
            {
                if (Date_end_to.Text.Trim() != "" &&Date_end_from.Text.Trim() != "")

                   // if (VB_Classes.Dates.Dates_Operation.date_validate(Date_end_to.Text.Trim()) != "" && VB_Classes.Dates.Dates_Operation.date_validate(Date_end_from.Text.Trim()) != "")

                
                {
                    //t1 = DateTime.ParseExact(Inbox_date_from.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
                    t2 = Date_end_to.Text.Trim();

                   // t2 = VB_Classes.Dates.Dates_Operation.date_validate(Date_end_to.Text.Trim());
                    //t2 = DateTime.ParseExact(Inbox_date_to.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
                    t1 = Date_end_from.Text.Trim();

                   // t1 = VB_Classes.Dates.Dates_Operation.date_validate(Date_end_from.Text.Trim());
                    sql += " AND CONVERT(datetime, dbo.datevalid(dbo.Protocol_Main_Def.End_DT), 103) > = '" + t1.ToString() + "'";
                    sql += " AND CONVERT(datetime, dbo.datevalid(dbo.Protocol_Main_Def.End_DT), 103) < = '" + t2.ToString() + "'";
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
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);



            string user = Session_CS.pmp_name.ToString();
            ReportDocument rd = new ReportDocument();
            string s = Server.MapPath("../Reports/finished_protocal_finished_proj.rpt");
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
      
        
        else
        {
            ShowAlertMessage("!!!!! لم يتم اختيار أي تقرير للعرض !!!!");
            return;
        }


    }
   
    protected void DropDate_SelectedIndexChanged(object sender, EventArgs e)
    {
        Label6.Visible = false;
    }

    protected void ImgBtnBack_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("../WebForms2/Protocols_Reports.aspx");
    }
    protected void Droporg_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
   
   

   
   

    protected void Drop_balance_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
   

    
   
}
