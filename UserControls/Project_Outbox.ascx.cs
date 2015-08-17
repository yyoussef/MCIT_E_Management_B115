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
using System.Data.Linq;
using System.Text;
using System.Data.SqlClient;
using System.IO;
using System.Net.Mail;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using ReportsClass;
using System.Collections.Generic;
using EFModels;


public partial class UserControls_Project_Outbox : System.Web.UI.UserControl
{
    //Session_CS Session_CS = new Session_CS();
    private string sql_Connection = Database.ConnectionString;
    General_Helping Obj_General_Helping = new General_Helping();
        InboxContext pm_inbox = new InboxContext();
        OutboxContext pm_outbox = new OutboxContext();
    int id;
    int inbx_id;
    string v_desc;
    int commarg;
    int  in_id ;
    //OutboxDataContext outboxDBContext = new OutboxDataContext();
   // OutboxContext outboxDBContext = new OutboxContext();
    //InboxContext inboxContext = new InboxContext();
    //ActiveDirectoryContext ADContext = new ActiveDirectoryContext();
    //ProjectsContext ProjectsContext = new ProjectsContext();
   
    #region "page lifecycle"
    protected override void OnInit(EventArgs e)
    {
        
        #region BROWSER FOR departments

        
        //string Query = "";
        /////Smart_Org_ID.sql_Connection = sql_Connection;
        //Query = "SELECT Org_ID, Org_Desc FROM Organization where foundation_id = " + found_id;

        //this.Smrt_Srch_DropDep.Value_Handler += new Smart_Search.Delegate_Selected_Value(MOnMember_Data);
        //Inbox_organization.SelectedValue;
        ////Smart_Emp_ID.sql_Connection = sql_Connection;

        ///Query = "SELECT PMP_ID, pmp_name FROM EMPLOYEE ";
        //Smart_Org_ID.datatble = General_Helping.GetDataTable(Query);
        //Smart_Org_ID.Value_Field = "Org_ID";
        //Smart_Org_ID.Text_Field = "Org_Desc";
        //Smart_Org_ID.DataBind();

       // DataTable orgsdt = new DataTable();
        //orgsdt.Columns.Add("Org_ID", typeof(long));
        //orgsdt.Columns.Add("Org_Desc", typeof(string));
        
        //var orgsquery = (from orgs in ADContext.Organizations //General_Helping.GetDataTable(Query);
        //                 where orgs.foundation_id == Session_CS.foundation_id
        //                 select orgsdt.LoadDataRow(
        //                 new object[] {
        //                            orgs.Org_ID,
        //                            orgs.Org_Desc
        //                        }, false)).ToList();
        using (var context = new ActiveDirectoryContext())
        {
            int found_id = CDataConverter.ConvertToInt(Session_CS.foundation_id.ToString());
            var orgsquery = from orgs in context.Organizations 
                            where orgs.foundation_id == Session_CS.foundation_id
                            select orgs;

            DataTable orgsdt = extentionMethods.ToDataTable<Organization>(orgsquery);

            Smart_Org_ID.datatble = orgsdt;
            Smart_Org_ID.Value_Field = "Org_ID";
            Smart_Org_ID.Text_Field = "Org_Desc";
            Smart_Org_ID.DataBind();
        }
        //Smart_Search_dept.sql_Connection = sql_Connection;
        //Query = "SELECT Dept_id, Dept_name FROM Departments ";
        //Smart_Search_dept.datatble = General_Helping.GetDataTable(Query);
        //Smart_Search_dept.Value_Field = "Dept_id";
        //Smart_Search_dept.Text_Field = "Dept_name";
        //Smart_Search_dept.DataBind();
        this.Smrt_Srch_structure.Value_Handler += new Smart_Search.Delegate_Selected_Value(MOnMember_Data);
        this.Smrt_Srch_structure2.Value_Handler += new Smart_Search.Delegate_Selected_Value(MOnMember_Data2);
        TabPanel_All.ActiveTabIndex = 0;
        #endregion
        base.OnInit(e);
    }
    protected void Page_Load(object sender, EventArgs e)
    {


        Smrt_Srch_structure.Show_OrgTree = true;
        Smrt_Srch_structure2.Show_OrgTree = true;
        if (!IsPostBack)
        {
            fill_txt_data();


            // Smrt_Srch_structure.Show_OrgTree = true;
            int grp = CDataConverter.ConvertToInt(Session_CS.group_id.ToString());
            if (CDataConverter.ConvertToInt(Session_CS.Project_id.ToString()) > 0)
            {

        
                
                if (Session_CS.UROL_UROL_ID != null && CDataConverter.ConvertToInt(Session_CS.UROL_UROL_ID) == 3)
                {
                    using(var context = new ProjectsContext()){
                        var proj = from project in context.Projects
                                                where project.Proj_id == Session_CS.Project_id && project.pmp_pmp_id == Session_CS.pmp_id
                                                select project;
                    //Refactored by hafs
                    //string sql1 = " SELECT Proj_id ,pmp_pmp_id " +
                    //   " FROM     Project     " +
                    //   " where Proj_id = '" + Session_CS.Project_id + "' and pmp_pmp_id = '" + Session_CS.pmp_id + "'";
                    //DataTable DT = General_Helping.GetDataTable(sql1);
                    if (proj.Count() > 0)
                        btn_Doc.Visible = btnClear.Visible = BtnSave.Visible = true;
                    else
                        btn_Doc.Visible = btnClear.Visible = BtnSave.Visible = false;
                    }
                }
                else if (Session_CS.UROL_UROL_ID != null && CDataConverter.ConvertToInt(Session_CS.UROL_UROL_ID) == 2)
                {
                    btn_Doc.Visible = btnClear.Visible = BtnSave.Visible = false;
                }
            }
            ////tr_old_emp.Visible = false;

            //IEnumerable<pmp_fav_View> pmpFavView = from favView in outboxDBContext.pmp_fav_Views
            //                                       where favView.employee_id == CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString())
            //                                       orderby favView.pmp_name.Trim()
            //                                       select favView;
            //chklst_Visa_Emp_All.DataSource = pmpFavView;
            //chklst_Visa_Emp_All.DataBind();

            //Refactored by hafs
            //string sql_for_chklist_emp = " select * from pmp_fav_View where pmp_fav_View.employee_id = " + CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()) + " ORDER BY LTRIM(pmp_name)";
            //DataTable dt_emp_fav = General_Helping.GetDataTable(sql_for_chklist_emp);
            //chklst_Visa_Emp_All.DataSource = dt_emp_fav;
            //chklst_Visa_Emp_All.DataBind();


            TabPanel_Visa_Folow.Visible = true;
            TabPanel_Visa.Visible = true;
            Button2.Visible = true;

            //IEnumerable<Outbox_Track_Manager> OutboxTrackManager = from OutTrackManager in outboxDBContext.Outbox_Track_Managers
            //                                                       where OutTrackManager.Outbox_id == CDataConverter.ConvertToInt(Request["id"])
            //                                                       select OutTrackManager;
            ////Refactored by hafs
            //// DataTable dt_get_dr_hesham_visa = General_Helping.GetDataTable("select * from Outbox_Track_Manager where Outbox_id = " + CDataConverter.ConvertToInt(Request["id"]));
            //if (OutboxTrackManager.Count() > 0)
            //{
            //    txt_dr_hesham_visa.Text = OutboxTrackManager.FirstOrDefault().Visa_Desc;
            //    //Refactored by hafs
            //    //txt_dr_hesham_visa.Text = dt_get_dr_hesham_visa.Rows[0]["visa_desc"].ToString();
            //    if (txt_dr_hesham_visa.Text != "")
            //    {
            //        txt_Visa_Desc.Text = txt_dr_hesham_visa.Text;
            //    }

            //}
            //else
            //{
            //    txt_dr_hesham_visa.Text = "";
            //}

            // Fil_Dll();

            Fill_main_Category();
            //fill_sectors();
            fill_structure();

            //refactored by hafs
            //fill_structure2();

            //refactored by hafs
            // chklst_Visa_Emp.DataSource = fil_emp_by_Dept(CDataConverter.ConvertToInt(Smrt_Srch_structure.SelectedValue));//fil_emp_Visa();
            //  chklst_Visa_Emp.DataBind();
            if (Session_CS.code_outbox == 1)
            {
                txt_Code.Enabled = false;
            }
            if (Request["id"] != null)
            {
                String decrypted_id = Encryption.Decrypt(Request.QueryString["id"].ToString());
                id = Convert.ToInt16(decrypted_id);
                Outbox_ID.Value = id.ToString();
                Fill_Controll(id);
                Fil_Grid_Documents();
                Fil_Grid_Visa();
                Fil_chk_main_category(id);
                Fil_Grid_Visa_Follow();
                Fil_Emp_Visa_Follow();

            }
            else
            {
                DateTime str = CDataConverter.ConvertDateTimeNowRtnDt();
                DateTime st_deadline_date = CDataConverter.ConvertDateTimeNowRtnDt().AddDays(7);
                txt_Dead_Line_DT.Text = CDataConverter.ConvertDateTimeToFormatdmy(st_deadline_date);
                txt_Visa_date.Text = CDataConverter.ConvertDateTimeNowRtrnString();
                txt_Date.Text = CDataConverter.ConvertDateTimeNowRtrnString();
                txt_Follow_Date.Text = CDataConverter.ConvertDateTimeNowRtrnString();


               
                // try
                // {
                //DataTable getmax = SqlHelper.ExecuteDataset(Database.ConnectionString, "get_max_code_outbox", Session_CS.foundation_id).Tables[0];
                // txt_Code.Text = getmax.Rows[0]["code"].ToString();
                //  }
                //catch
                // {
                //  txt_Code.Text = "1";
                // }
               //}
                // btn_print_report.Enabled = false;

            }


            if (Session_CS.pmp_id > 0 && Request["id"] == null)
            {
                //drop_sectors.SelectedValue = Session_CS.sec_id.ToString();
                //ddl_sectors2.SelectedValue = Session_CS.sec_id.ToString();
                //fill_depts();
                //fill_structure();
                TabPanel_All.ActiveTabIndex = 0;


            }


        }

    }
    #endregion



    #region "Fills"
    protected void fill_structure()
    {
        using (var context = new ActiveDirectoryContext())
        {
            var deptartments = (from dep in context.Departments
                                where dep.foundation_id == Session_CS.foundation_id
                                select dep).ToList();

            DataTable deptartmentsdt = extentionMethods.ToDataTable<Department>(deptartments);
            Smrt_Srch_structure.datatble = Smrt_Srch_structure2.datatble = deptartmentsdt;
            Smrt_Srch_structure.Value_Field = Smrt_Srch_structure2.Value_Field = "Dept_id";
            Smrt_Srch_structure.Text_Field = Smrt_Srch_structure2.Text_Field = "Dept_name";
            Smrt_Srch_structure.DataBind(); Smrt_Srch_structure2.DataBind();
        }


        //refactored by hafs
        //string Query = "";
        //Query = "SELECT  * from    Departments  where foundation_id='" + Session_CS.foundation_id + "'";


        //if (Request.Url.ToString().ToLower().Contains("admin") || (Session_CS.Hr_Eval != null && Session_CS.Hr_Eval.ToString() == "1"))

        //    tr_allow_chk_dept.Visible = true;

        //else if (Session_CS.Hr_Eval != null && Session_CS.Hr_Eval.ToString() != "1")
        //{
        //    Query += " and Dept_parent_id = '"+Session_CS.Dept_parent_id+"'";
        //    //ddl_sectors.SelectedValue = Session_CS.sec_id.ToString();
        //    Smrt_Srch_structure.SelectedValue = Session_CS.Dept_parent_id.ToString();

        //   // ddl_sectors.Enabled = false;
        //    fill_emplyees();
        //    tr_allow_chk_dept.Visible = true;
        //}

        //Smrt_Srch_structure.datatble = General_Helping.GetDataTable(Query);


    }

    protected void fill_txt_data()
    {

        if (Session["txt_subject"] != null && Session["txt_subject"] != "")
        {

            txt_Subject.Text = Session["txt_subject"].ToString();

            Session["txt_subject"] = "";
            
        }

        if (Session["inb_id"]!="" && Session["inb_id"]!=null )

        {
            ddl_Related_Type.SelectedValue = "2";
            trSmart.Style.Add("Display","Block");
            lbl_Inbox_type.Text = "موضوع الخطاب الوارد :";
            Fil_Smrt_From_InBox();
            Smart_Related_Id.SelectedValue = Session["inb_id"].ToString();

            Session["inb_id"] = "";
        }

        if (Session["Smart_Org_ID"] != "" && Session["Smart_Org_ID"] != null)

        {
          Smart_Org_ID.SelectedValue=  Session["Smart_Org_ID"].ToString();
          Session["Smart_Org_ID"] = "";
        }

    }
    protected void fill_depts()
    {
        using (var context = new ActiveDirectoryContext())
        {
            var deptartments = from dep in context.Departments
                               where dep.Sec_sec_id == CDataConverter.ConvertToInt("0")
                               orderby dep.Dept_name.Trim()
                               select dep;
            DataTable deptartmentsdt = extentionMethods.ToDataTable<Department>(deptartments);
            Smrt_Srch_structure.datatble = Smrt_Srch_structure2.datatble = deptartmentsdt;
            Smrt_Srch_structure.Value_Field = Smrt_Srch_structure2.Value_Field = "Dept_id";
            Smrt_Srch_structure.Text_Field = Smrt_Srch_structure2.Text_Field = "Dept_name";
            Smrt_Srch_structure.DataBind(); Smrt_Srch_structure2.DataBind();
        }
        //string Query = "";
        //if (Smrt_Srch_structure2.SelectedValue != "0")
        //{
        //    Smrt_Srch_structure2.sql_Connection = sql_Connection;
        //    Smart_Search_mang.Query = "select Dept_ID,Dept_name from Departments where sec_sec_id='" + drop_sectors.SelectedValue + "' ";
        //     Query = "select Dept_ID,Dept_name from Departments where sec_sec_id='" + CDataConverter.ConvertToInt("0") + "' ";
        //     Smrt_Srch_structure2.datatble = General_Helping.GetDataTable(Query);
        //    Smrt_Srch_structure2.Value_Field = "Dept_ID";
        //    Smrt_Srch_structure2.Text_Field = "Dept_name";
        //     Smrt_Srch_structure2.Orderby = "ORDER BY LTRIM(Dept_name)";
        //     Smrt_Srch_structure2.DataBind();
        // }
        // else
        //  {
        //      Smrt_Srch_structure2.Clear_Controls();
        //  }

        //////////////////////////////////////////////////////////

        //   if (Smrt_Srch_structure.SelectedValue != "0")
        //  {
        //Smart_Search_dept.Query = "select Dept_ID,Dept_name from Departments where sec_sec_id='" + ddl_sectors2.SelectedValue + "' ";
        //       Query = "select Dept_ID,Dept_name from Departments where sec_sec_id='" + CDataConverter.ConvertToInt("0") + "' ";
        //       Smrt_Srch_structure.datatble = General_Helping.GetDataTable(Query);
        //      Smrt_Srch_structure.Value_Field = "Dept_ID";
        //      Smrt_Srch_structure.Text_Field = "Dept_name";
        //      Smrt_Srch_structure.Orderby = "ORDER BY LTRIM(Dept_name)";
        //      Smrt_Srch_structure.DataBind();
        //   }
        //   else
        //   {
        //       Smrt_Srch_structure.Clear_Controls();
        //   }


        //  Smart_Emp_ID.sql_Connection = sql_Connection;
        //  Smart_Emp_ID.Query = "SELECT PMP_ID, pmp_name,Dept_Dept_id,Sec_id FROM EMPLOYEE inner join dbo.Departments on EMPLOYEE.Dept_Dept_id=Departments.Dept_id inner join Sectors on Sectors.Sec_id=Departments.Sec_sec_id where Sectors.Sec_id='" + drop_sectors.SelectedValue + "' ";
        //Query = "SELECT PMP_ID, pmp_name,Dept_Dept_id,Sec_id FROM EMPLOYEE inner join dbo.Departments on EMPLOYEE.Dept_Dept_id=Departments.Dept_id inner join Sectors on Sectors.Sec_id=Departments.Sec_sec_id where Sectors.Sec_id='" + CDataConverter.ConvertToInt("0") + "' ";
        // Smart_Emp_ID.datatble = General_Helping.GetDataTable(Query);
        DataTable EMPLOYEEdt = fil_emp_by_Dept(0);
        Smart_Emp_ID.datatble = EMPLOYEEdt;
        Smart_Emp_ID.Value_Field = "PMP_ID";
        Smart_Emp_ID.Text_Field = "pmp_name";
        Smart_Emp_ID.DataBind();


    }
    private void Fil_Grid_Visa_Follow()
    {
        //refactored by hafs
        ////DataTable DT = new DataTable();
        ////string Sql = "SELECT Outbox_Visa_Follows.Follow_ID,Outbox_Visa_Follows.File_name,Outbox_Visa_Follows.time_follow,Outbox_Visa_Follows.Outbox_ID, Outbox_Visa_Follows.Descrption, Outbox_Visa_Follows.Date, Outbox_Visa_Follows.Visa_Emp_id, EMPLOYEE.pmp_name " +
        ////             " FROM  Outbox_Visa_Follows INNER JOIN EMPLOYEE ON Outbox_Visa_Follows.Visa_Emp_id = EMPLOYEE.PMP_ID where Outbox_ID =" + Outbox_ID.Value;
        ////DT = General_Helping.GetDataTable(Sql);

        ////GridView_Visa_Follow.DataSource = DT;
        //GridView_Visa_Follow.DataSource = from OutboxVisaFollows in outboxDBContext.Outbox_Visa_Follows
        //                                  join emp in outboxDBContext.EMPLOYEEs
        //                                  on OutboxVisaFollows.Visa_Emp_id equals emp.PMP_ID
        //                                  where OutboxVisaFollows.Outbox_ID == CDataConverter.ConvertToInt(Outbox_ID.Value)
        //                                  select new
        //                                  {
        //                                      Follow_ID = OutboxVisaFollows.Follow_ID,
        //                                      File_name = OutboxVisaFollows.File_name,
        //                                      time_follow = OutboxVisaFollows.time_follow,
        //                                      Outbox_ID = OutboxVisaFollows.Outbox_ID,
        //                                      Descrption = OutboxVisaFollows.Descrption,
        //                                      Date = OutboxVisaFollows.Date,
        //                                      Visa_Emp_id = OutboxVisaFollows.Visa_Emp_id,
        //                                      pmp_name = emp.pmp_name
        //                                  };
        using (var context = new ActiveDirectoryContext())
        {
            GridView_Visa_Follow.DataSource = context.get_employee_from_Outbox_Visa_Follows(CDataConverter.ConvertToInt(Outbox_ID.Value));
            GridView_Visa_Follow.DataBind();
        }
    }
    private void Fil_Emp_Visa_Follow()
    {


        Obj_General_Helping.SmartBindDDL(ddl_Visa_Emp_id, Fil_Emp_Visa(), "PMP_ID", "pmp_name", "....اختر اسم الموظف ....");

    }
    private DataTable Fil_Emp_Visa()
    {

        DataTable resultDT = new DataTable();
        //EmpDT.Columns.Add("PMP_ID", typeof(int));
        //EmpDT.Columns.Add("pmp_name", typeof(string));
        //EmpDT.Columns.Add("Outbox_ID", typeof(int));

        if (CDataConverter.ConvertToInt(Outbox_ID.Value) > 0)
        {
            //DataTable DT = new DataTable();
            //string sql = " SELECT   distinct EMPLOYEE.PMP_ID, EMPLOYEE.pmp_name, Outbox_Visa.Outbox_ID " +
            //             " FROM   Outbox_Visa_Emp INNER JOIN  EMPLOYEE ON Outbox_Visa_Emp.Emp_ID = EMPLOYEE.PMP_ID " +
            //             " INNER JOIN  Outbox_Visa ON Outbox_Visa_Emp.Visa_Id = Outbox_Visa.Visa_Id " +
            //             " INNER JOIN  Outbox ON Outbox_Visa.Outbox_ID = Outbox.ID " +
            //             " where Outbox_ID=" + Outbox_ID.Value;
            //DT = General_Helping.GetDataTable(sql);
            ////var OutboxVisaEmpDT = (from OutboxVisaEmp in outboxDBContext.Outbox_Visa_Emps
            ////                       join EMP in outboxDBContext.EMPLOYEEs on (Int64)OutboxVisaEmp.Emp_ID equals EMP.PMP_ID
            ////                       join OutboxVisa in outboxDBContext.Outbox_Visas on OutboxVisaEmp.Visa_Id equals OutboxVisa.Visa_Id
            ////                       join Outbx in outboxDBContext.Outboxes on OutboxVisa.Outbox_ID equals Outbx.ID
            ////                       where OutboxVisa.Outbox_ID == CDataConverter.ConvertToInt(Outbox_ID.Value)
            ////                       select EmpDT.LoadDataRow(
            ////                     new object[]  {
            ////                        EMP.PMP_ID,
            ////                          EMP.pmp_name,
            ////                          OutboxVisa.Outbox_ID
            ////                       }, false)).Distinct();
            using (var context = new OutboxContext())
            {
                var OutboxVisaEmpDT = context.OutboxVisaEmpSelectOutboxId1(CDataConverter.ConvertToInt(Outbox_ID.Value));
                resultDT = extentionMethods.ToDataTable<OutboxVisaEmpSelectOutboxId1_Result>(OutboxVisaEmpDT);
            }

        }
        return resultDT;
    }
    private void Fill_main_Category()
    {

        using (var context = new InboxContext())
        {
          
  var inboxMainCat =from ChkMainCat in context.inbox_Main_Categories
                                      where ChkMainCat.group_id == Session_CS.group_id
                                      select ChkMainCat;
  DataTable dt_main_cat = extentionMethods.ToDataTable<inbox_Main_Categories>(inboxMainCat);
            Chk_main_cat.DataSource = dt_main_cat;
            Chk_main_cat.DataBind();
        }

        //Refactored by hafs
        //DataTable dt_main_cat = General_Helping.GetDataTable(" select * from Inbox_Main_Categories where group_id = " + CDataConverter.ConvertToInt(Session_CS.group_id.ToString()));
        //Chk_main_cat.DataSource = dt_main_cat;
        //Chk_main_cat.DataBind();

        //ddlMainCat.DataTextField = "Name";
        //ddlMainCat.DataValueField = "id";

    }
    private void fill_sub_category()
    {
        //DataTable dt_sub_cat = General_Helping.GetDataTable(" select * from inbox_Sub_Categories ");
        using (var context = new InboxContext())
        {
            var inboxSubCat = from ChkSubCat in context.inbox_sub_categories
                                select ChkSubCat;
            Chk_sub_cat.DataSource = extentionMethods.ToDataTable<inbox_sub_categories>(inboxSubCat);
            //ddlMainCat.DataTextField = "Name";
            //ddlMainCat.DataValueField = "id";
            Chk_sub_cat.DataBind();
        }

    }
    private void Fill_Controll(int id)
    {
        try
        {
            using (var context = new OutboxContext())
            {
                Outbox OutboxObj = context.Outboxes.Where(x => x.ID == id).SingleOrDefault();
                // Outbox OutboxObj = outboxDBContext.Outboxes.Where(x => x.ID == id).SingleOrDefault();

                //refactored by hafs
                //Outbox_DT obj = Outbox_DB.SelectByID(id);
                //Outbox_ID.Value = obj.ID.ToString();
                hidden_Proj_id.Value = OutboxObj.Proj_id.ToString();
                txt_Name.Text = OutboxObj.Name;
                txt_Code.Text = OutboxObj.Code;
                txt_Date.Text = OutboxObj.Date;
                ddl_Type.SelectedValue = OutboxObj.Type.ToString();
                Type_Changed();
                //if (obj.Dept_ID > 0)
                // ddl_Dept_ID.SelectedValue = obj.Dept_ID.ToString();
                //  fill_depts();
                // Smart_Search_mang.SelectedValue = obj.Dept_ID.ToString();

                DataTable dt_outboxinside = extentionMethods.ToDataTable<outboxinside_data_Result>(context.outboxinside_data(id));
                //DataTable dt_outboxinside = Outbox_DB.outbox_inside_data(id);

                if (OutboxObj.Type.ToString() == "1")
                {
                    if (dt_outboxinside.Rows[0]["type"].ToString() == "1")
                    {
                        //drop_sectors.SelectedValue = dt_outboxinside.Rows[0]["sec_sec_id"].ToString();
                        //refactored by hafs
                        if (Smrt_Srch_structure2.datatble == null)
                            fill_structure();
                        //Fil_Dll();
                        //fill_depts();
                        Smrt_Srch_structure2.SelectedValue = dt_outboxinside.Rows[0]["Org_id"].ToString();
                    }
                }

                //refactored by hafs
                fill_emplyees();


                if (OutboxObj.Emp_ID > 0)
                    Smart_Emp_ID.SelectedValue = OutboxObj.Emp_ID.ToString();
                //if (OutboxObj.Org_Id > 0)
                //    Smart_Org_ID.SelectedValue = OutboxObj.Org_Id.ToString();
                // lbl_Org_Name.Text = obj.Org_Name;
                txt_Org_Out_Box_Code.Text = OutboxObj.Org_Out_Box_Code;
                txt_Org_Out_Box_DT.Text = OutboxObj.Org_Out_Box_DT;
                txt_Org_Out_Box_Person.Text = OutboxObj.Org_Out_Box_Person;
                txt_Subject.Text = OutboxObj.Subject;
                ddl_Related_Type.SelectedValue = OutboxObj.Related_Type.ToString();
                Related_type_Changed();
                Smart_Related_Id.SelectedValue = OutboxObj.Related_Id.ToString();

                Fill__related_Controll(id);


                txt_Notes.Text = OutboxObj.Notes;
                txt_Paper_No.Text = OutboxObj.Paper_No;
                txt_Paper_Attached.Text = OutboxObj.Paper_Attached;
                // ddl_Follow_Up_Dept_ID.SelectedValue = obj.Follow_Up_Dept_ID.ToString();
                //fil_emp_Folow_Up();
                // Smart_Follow_Up_Emp_ID.SelectedValue = obj.Follow_Up_Emp_ID.ToString();
                // txt_Follow_Up_Notes.Text = obj.Follow_Up_Notes;
                txt_Dept_Desc.Text = OutboxObj.Dept_Desc;
                ddl_Source_Type.SelectedValue = OutboxObj.Source_Type.ToString();
                txt_Org_Dept_Name.Text = OutboxObj.Org_Dept_Name;


                ////////////////////////   fill main and sub category of outbox letter  ///////////////////////////////////////


                var dt = from outboxcat in context.outbox_cat_select(id, 1)
                         select outboxcat;
                // DataTable dt = Outbox_DB.outbox_cat_select(id, 1);
                if (dt.Count() > 0)
                {

                    foreach (var record in dt)
                    {
                        Chk_main_cat.SelectedValue = record.Cat_id.ToString();
                    }

                }

            }

        }
        catch
        { }
    }
    private void Fil_chk_main_category(int ID)
    {
        //var mainOutCat = from outcat in outboxDBContext.outbox_cats
        //                 where outcat.outbox_id == ID && outcat.Type == 1 && outcat.outbox_type == 1
        //                 select outcat;
        //var subOutCat = from outcat in outboxDBContext.outbox_cats
        //                where outcat.outbox_id == ID && outcat.Type == 2 && outcat.outbox_type == 1
        //                select outcat;
        string Sql_main_cat = "select * from outbox_cat where outbox_id =" + ID + " and Type =1 and outbox_type = 1";
        DataTable DT_main_cat = General_Helping.GetDataTable(Sql_main_cat);
        DataTable dt_sub_cat = General_Helping.GetDataTable("select * from outbox_cat where outbox_id = " + ID + " and Type=2 and outbox_type = 1 ");
        if (DT_main_cat.Rows.Count > 0)
        {
            foreach (DataRow dr in DT_main_cat.Rows)
            {
                //refactored by hafs
                string Value = dr["Cat_id"].ToString();
                DataTable dt = General_Helping.GetDataTable(" select * from inbox_sub_categories where main_id = " + Value);
                //var subInboxCat = from InboxCat in outboxDBContext.inbox_sub_categories
                //                  where InboxCat.main_id == dr.Cat_id
                //                  select InboxCat;
                foreach (DataRow drs in dt.Rows)
                {
                    ListItem obj = new ListItem(drs["name"].ToString(), drs["id"].ToString());
                    Chk_sub_cat.Items.Add(obj);
                }
                ListItem item = Chk_main_cat.Items.FindByValue(dr["Cat_id"].ToString());
                if (item != null)
                    item.Selected = true;


            }
        }
        foreach (DataRow drsub in dt_sub_cat.Rows)
        {
            //refactored by hafs
            //string Value = dr["Cat_id"].ToString();
            ListItem item = Chk_sub_cat.Items.FindByValue(drsub["Cat_id"].ToString());
            if (item != null)
                item.Selected = true;


        }
    }
    protected void fill_emplyees()
    {
        //Smart_Emp_ID.sql_Connection = sql_Connection;
        //string Query = "SELECT     EMPLOYEE.PMP_ID, EMPLOYEE.pmp_name, Departments.sec_sec_id FROM " +
        //"EMPLOYEE INNER JOIN   " +
        //"Departments ON EMPLOYEE.Dept_Dept_id = Departments.Dept_ID  and EMPLOYEE.workstatus!=4";
        //if (Smrt_Srch_structure2.SelectedValue != "")
        //{
        //    Query += " where Departments.Dept_ID =  " + Smrt_Srch_structure2.SelectedValue;
        //}

       // DataTable EMPLOYEEdt = extentionMethods.ToDataTable<EMPLOYEE>(fil_emp_by_Dept(CDataConverter.ConvertToInt(Smrt_Srch_structure2.SelectedValue)));
        DataTable EMPLOYEEdt = fil_emp_by_Dept(CDataConverter.ConvertToInt(Smrt_Srch_structure2.SelectedValue));
        Smart_Emp_ID.datatble = EMPLOYEEdt;////fil_emp_by_Dept(CDataConverter.ConvertToInt(Smrt_Srch_structure2.SelectedValue)) as DataTable;
        Smart_Emp_ID.Value_Field = "pmp_id";
        Smart_Emp_ID.Text_Field = "pmp_name";
        Smart_Emp_ID.DataBind();
        TabPanel_All.ActiveTabIndex = 0;


    }
    private DataTable fil_emp_by_Dept(int DeptID)
    {
        // int Dept_ID = CDataConverter.ConvertToInt(Smrt_Srch_structure.SelectedValue);
        IEnumerable<EMPLOYEE> Employees;
        
        using (var context = new ActiveDirectoryContext()) { 
        if (DeptID > 0)
        {
            Employees = from Emps in context.EMPLOYEEs
                        where Emps.Dept_Dept_id == DeptID
                        orderby Emps.pmp_name
                        select Emps;


        }
        else
        {
            Employees = from Emps in context.EMPLOYEEs
                        where Emps.foundation_id == Session_CS.foundation_id
                        orderby Emps.pmp_name
                        select Emps;
        }
        DataTable EMPLOYEEdt = extentionMethods.ToDataTable<EMPLOYEE>(Employees);
        return EMPLOYEEdt;
        }

        //string sql = "SELECT PMP_ID, pmp_name FROM EMPLOYEE where 1=1 ";
        //if (Dept_ID > 0)
        //{
        //    sql += " and Dept_Dept_id = " + Dept_ID;

        //}
        //sql += " order by pmp_name asc";
        //chklst_Visa_Emp.DataSource = General_Helping.GetDataTable(sql);


        //    Smart_Visa_Emp.sql_Connection = sql_Connection;
        //    Smart_Visa_Emp.Query = "SELECT PMP_ID, pmp_name FROM EMPLOYEE where Dept_Dept_id = " + Dept_ID;
        //    Smart_Visa_Emp.Value_Field = "PMP_ID";
        //    Smart_Visa_Emp.Text_Field = "pmp_name";
        //    Smart_Visa_Emp.DataBind();
        //}
        //else
        //    Smart_Visa_Emp.Clear_Controls();
    }


    private void Fill__related_Controll(int id)
    {
        try
        {
            DataTable allinboxdata = pm_outbox.Outbox_fillcontrol(id).ToDataTable();

            DataRow inall = allinboxdata.Rows[0];

            hidden_Id.Value = inall["id"].ToString();

            hidden_Proj_id.Value = inall["Proj_id"].ToString();

            string all = "";
            int idrelated = 0;

            if (inall["Related_Type"].ToString() != "")
            {
                int x = CDataConverter.ConvertToInt(inall["Related_Type"].ToString());
                int yy = CDataConverter.ConvertToInt(inall["Related_Id"].ToString());

                // DataTable dt_direct_related = Inbox_DB.inbox_Direct_Relating(CDataConverter.ConvertToInt(inall["Related_Type"].ToString()), CDataConverter.ConvertToInt(inall["Related_Id"].ToString()));
                DataTable dt_direct_related = pm_inbox.inbox_DIrect_Relating(CDataConverter.ConvertToInt(inall["Related_Type"].ToString()), CDataConverter.ConvertToInt(inall["Related_Id"].ToString())).ToDataTable();
                if (inall["Related_Type"].ToString() == "1")
                {

                    // lbl_Inbox_type.Visible = false;
                    // lbl_letter.Visible = false;

                    tr_link.Style.Add("Display", "None");

                }
                if (inall["Related_Type"].ToString() == "2" || inall["Related_Type"].ToString() == "5")
                {
                    tr_link.Style.Add("Display", "block");

                    all = dt_direct_related.Rows[0]["con"].ToString();
                    string[] res = all.Split('-');
                    idrelated = CDataConverter.ConvertToInt(res[3].ToString());
                    //  lbl_Inbox_type.Text = "موضوع الخطاب الصادر :";


                    if (dt_direct_related.Rows.Count > 0)
                    {

                        int outid = idrelated;
                        string encrypted = Encryption.Encrypt(outid.ToString());


                        lbl_letter.Text = dt_direct_related.Rows[0]["con"].ToString();
                        lbl_letter.NavigateUrl = "../mainform/Project_inbox.aspx?id=" + encrypted;
                    }
                }
                if (inall["Related_Type"].ToString() == "3" || inall["Related_Type"].ToString() == "4")
                {
                    tr_link.Style.Add("Display", "block");

                    all = dt_direct_related.Rows[0]["con"].ToString();
                    string[] res = all.Split('-');
                    idrelated = CDataConverter.ConvertToInt(res[3].ToString());
                    lbl_Inbox_type.Text = "موضوع الخطاب الوارد :";


                    if (dt_direct_related.Rows.Count > 0)
                    {

                        int INid = idrelated;
                        string encrypted = Encryption.Encrypt(INid.ToString());


                        lbl_letter.Text = dt_direct_related.Rows[0]["con"].ToString();
                        lbl_letter.NavigateUrl = "../mainform/Project_inbox.aspx?id=" + encrypted;


                    }

                }

                if (inall["Related_Type"].ToString() == "6")
                {
                    tr_link.Style.Add("Display", "block");

                    all = dt_direct_related.Rows[0]["con"].ToString();
                    string[] res = all.Split('-');
                    idrelated = CDataConverter.ConvertToInt(res[3].ToString());
                    lbl_Inbox_type.Text = "وارد لصادر داخلي :";


                    if (dt_direct_related.Rows.Count > 0)
                    {

                        int outid = idrelated;
                        string encrypted = Encryption.Encrypt(outid.ToString());


                        lbl_letter.Text = dt_direct_related.Rows[0]["con"].ToString();
                        lbl_letter.NavigateUrl = "../mainform/Project_inbox.aspx?id=" + encrypted;
                    }
                }


            }


        }
        catch
        { }
    }


    private void Fil_Smrt_From(DataTable dt)
    {
        Smart_Related_Id.datatble = dt;
        Smart_Related_Id.Value_Field = "id";
        Smart_Related_Id.Text_Field = "con";
        Smart_Related_Id.Show_Code = false;
  
        Smart_Related_Id.DataBind();
    }
    public void fill_listbox()
    {
        foreach (ListItem item in chklst_Visa_Emp_All.Items)
        {
            if (item.Selected && lst_emp.Items.FindByValue(item.Value) == null)
            {
                ListItem obj = new ListItem(item.Text, item.Value);
                lst_emp.Items.Add(obj);
                item.Selected = false;
            }
            //foreach (ListItem item2 in lst_emp.Items)
            //{
            //    if (item2.Value == item.Value)
            //    {
            //        Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('احد الموظفين المختارين موجود من قبل')</script>");
            //        return;
            //    }

            //}

        }
    }
    private void Fil_Grid_Visa()
        {

        if (CDataConverter.ConvertToInt(ddl_Type.SelectedValue) == 1)
        {

         DataTable DT = pm_inbox.get_inbox_visa(inbx_id).ToDataTable();


        GridView_Visa.DataSource = DT;
        GridView_Visa.DataBind();

            foreach (GridViewRow row in GridView_Visa.Rows)
            {
                CheckBox chk = (CheckBox)row.FindControl("chkSent");
                Label lbl_emp = (Label)row.FindControl("lbl_emp");

                if (chk.Checked == true || lbl_emp.Text  != Session_CS.pmp_id.ToString())
                {
                    ImageButton img = (ImageButton)row.FindControl("ImgBtnEdit");
                    ImageButton img2 = (ImageButton)row.FindControl("ImgBtnDelete");
                    ImageButton img3 = (ImageButton)row.FindControl("ImgBtnEdit123");
                    img.Visible = false;
                    img2.Visible = false;
                    img3.Visible = false;
                //img.Visible = false;
                //img2.Visible = false;

               }

          }

        }

        else 
        {
        //refactored by hafs
        //DataTable DT = new DataTable();
        //DT = General_Helping.GetDataTable("select * from Outbox_Visa where Outbox_ID=" + Outbox_ID.Value);
        int hiddenValue = CDataConverter.ConvertToInt(Outbox_ID.Value);
        using (var context = new OutboxContext())
        {
            var query = from ds in context.Outbox_Visa
                            where ds.Outbox_ID == hiddenValue
                            select ds;
            DataTable DT = extentionMethods.ToDataTable<Outbox_Visa>(query);
            GridView_Visa.DataSource = DT;
            GridView_Visa.DataBind();
        }

        foreach (GridViewRow row in GridView_Visa.Rows)
        {
            CheckBox chk = (CheckBox)row.FindControl("chkSent");
            Label lbl_emp = (Label)row.FindControl("lbl_emp");

            if (chk.Checked == true || lbl_emp.Text != Session_CS.pmp_id.ToString())
            {
                ImageButton img = (ImageButton)row.FindControl("ImgBtnEdit");
                ImageButton img2 = (ImageButton)row.FindControl("ImgBtnDelete");
                ImageButton img3 = (ImageButton)row.FindControl("ImgBtnEdit123");
                img.Visible = false;
                img2.Visible = false;
                img3.Visible = false;
         
            }

        }


        }


    }

    private void Fil_Visa_Lstbox(int ID)
    {
        // string sql = "SELECT dbo.EMPLOYEE.pmp_name, dbo.Outbox_Visa_Emp.Emp_ID, dbo.Outbox_Visa_Emp.Visa_Id FROM  dbo.EMPLOYEE INNER JOIN dbo.Outbox_Visa_Emp ON dbo.EMPLOYEE.PMP_ID = dbo.Outbox_Visa_Emp.Emp_ID where dbo.Outbox_Visa_Emp.Visa_Id = " + ID;

        //var OutboxVisaEmps = from EMPLOYEES in outboxDBContext.EMPLOYEEs
        //                    join OutboxVisaEmp in outboxDBContext.Outbox_Visa_Emps on EMPLOYEES.PMP_ID equals (long)OutboxVisaEmp.Emp_ID 
        //                    where OutboxVisaEmp.Visa_Id == ID
        //                    select new {
        //                    EMPs = EMPLOYEES,
        //                    OVEmp = OutboxVisaEmp
        //                    };

        //// DataTable dt = Fil_Emp_Visa();
        using (var context = new OutboxContext())
        {
            var OutboxVisaEmps = context.OutboxVisaEmpSelectVisa_Id(ID).ToList();
            if (OutboxVisaEmps.Count() > 0)
            {
                foreach (var OutboxVisaEmp in OutboxVisaEmps)
                {
                    ListItem obj = new ListItem(OutboxVisaEmp.pmp_name, OutboxVisaEmp.Emp_ID.ToString());
                    lst_emp.Items.Add(obj);


                }
            }
        }

    }
    private void Fil_Grid_Documents()
    {
        //refactored by hafs
        //DataTable DT = new DataTable();
        //DT = General_Helping.GetDataTable("select * from Inbox_OutBox_Files where Inbox_Or_Outbox = 2 and  Inbox_Outbox_ID=" + Outbox_ID.Value);
        int hiddenValue = CDataConverter.ConvertToInt(Outbox_ID.Value);
        using (var context = new InboxContext())
        {
            var query = from ds in context.Inbox_OutBox_Files
                           where ds.Inbox_Or_Outbox == 2 && ds.Inbox_Outbox_ID == hiddenValue
                           select ds;
            DataTable dtInbox_OutBox_Files = extentionMethods.ToDataTable(query);
            GrdView_Documents.DataSource = dtInbox_OutBox_Files;
            GrdView_Documents.DataBind();
        }
    }
    private void Fil_Visa_Control(int ID)
    {
        //Outbox_Visa_DT obj = Outbox_Visa_DB.SelectByID(ID);
        using (var context = new OutboxContext())
        {
            Outbox_Visa OutboxVisaObj = context.Outbox_Visa.Where(x => x.Visa_Id == ID).SingleOrDefault();
            if (OutboxVisaObj != null)
            {
                if (OutboxVisaObj.Visa_Id > 0)
                {
                    try
                    {
                        hidden_Visa_Id.Value = OutboxVisaObj.Visa_Id.ToString();
                        txt_Visa_date.Text = OutboxVisaObj.Visa_date;
                        if (OutboxVisaObj.Important_Degree > 0)
                            ddl_Important_Degree.SelectedValue = OutboxVisaObj.Important_Degree.ToString();
                        else
                            txt_Important_Degree_Txt.Text = OutboxVisaObj.Important_Degree_Txt;
                        if (OutboxVisaObj.Dept_ID > 0)
                            //ddl_Visa_Dept_ID.SelectedValue = obj.Dept_ID.ToString();
                            Smrt_Srch_structure.SelectedValue = OutboxVisaObj.Dept_ID.ToString();
                        else
                        {
                            Smrt_Srch_structure.Clear_Selected();
                            //txt_Dept_ID_Txt.Text = obj.Dept_ID_Txt;
                        }
                        ////refactored by hafs
                        ////chklst_Visa_Emp.DataSource = fil_emp_by_Dept(CDataConverter.ConvertToInt(Smrt_Srch_structure.SelectedValue));//fil_emp_Visa();
                        ////chklst_Visa_Emp.DataBind();

                        ////if (OutboxVisaObj.Emp_ID > 0)
                        ////{
                        ////    ListItem item = chklst_Visa_Emp.Items.FindByValue(OutboxVisaObj.Emp_ID.ToString());
                        ////    //ListItem item_fav = chklst_Visa_Emp_fav.Items.FindByValue(obj.Emp_ID.ToString());
                        ////    if (item != null)
                        ////        item.Selected = true;
                        ////    //if (item_fav != null)
                        ////    //    item_fav.Selected = true;

                        ////}
                        //else
                        //    txt_Emp_ID_Txt.Text = obj.Emp_ID_Txt;




                        txt_Visa_Desc.Text = OutboxVisaObj.Visa_Desc;
                        txt_Visa_Period.Text = OutboxVisaObj.Visa_Period;
                        txt_saving_file.Text = OutboxVisaObj.saving_file;
                        ddl_Visa_Satus.SelectedValue = OutboxVisaObj.Visa_Satus.ToString();
                        //ddl_Follow_Up_Dept_ID.SelectedValue = obj.Follow_Up_Dept_ID.ToString();
                        ////fil_emp_Folow_Up();
                        //Smart_Follow_Up_Emp_ID.SelectedValue = obj.Follow_Up_Emp_ID.ToString();
                        txt_Follow_Up_Notes.Text = OutboxVisaObj.Follow_Up_Notes;
                        txt_Dead_Line_DT.Text = OutboxVisaObj.Dead_Line_DT;
                        ddl_Visa_Goal_ID.SelectedValue = OutboxVisaObj.Visa_Goal_ID.ToString();

                    }
                    catch
                    { }
                }
            }
        }


    }

    #endregion

    #region "events handler"
    protected void drop_sectors_SelectedIndexChanged(object sender, EventArgs e)
    {
        //fill_structure2();
        //fill_depts();
        //fil_emp();

        TabPanel_All.ActiveTabIndex = 0;

    }
    protected void ddl_sectors2_SelectedIndexChanged(object sender, EventArgs e)
    {

        fill_depts();
        ////fill_resp_Emp();

        dropdept_fun();

    }
    protected void btn_print_report_Click(object sender, EventArgs e)
    {
        string user = Session_CS.pmp_name.ToString();
        int found_id = CDataConverter.ConvertToInt(Session_CS.foundation_id.ToString());
        if (Request.QueryString["id"] != null)
        {
            ReportDocument rd = new ReportDocument();
            string s = Server.MapPath("../Reports/InboxOutboxReport/outbox_Data.rpt");
            rd.Load(s);
            Reports.Load_Report(rd);
            rd.SetParameterValue("@out_ID", CDataConverter.ConvertToInt(Outbox_ID.Value));
            rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
            rd.SetParameterValue("@user", user, "footerRep.rpt");
            rd.SetParameterValue("@found_id", found_id, "Logo_Header_pic_dynamic.rpt");

            if (rd.Rows.Count == 0)
            {
                //ShowAlertMessage("!!!!!هذا التقرير لا يوجد به بيانات للعرض !!!!");
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('!!!!!هذا التقرير لا يوجد به بيانات للعرض !!!!');", true);

                return;
            }
            else
            {
                rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report");
            }
        }


    }
    protected void GridView_Visa_Follow_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        ////string sqlformail = "SELECT parent_pmp_id from parent_employee where pmp_id =  " + int.Parse(Session_CS.pmp_id.ToString());
        ////DataTable ds = General_Helping.GetDataTable(sqlformail);

        //var parent_pmp = from parentemp in outboxDBContext.parent_employees ////int.Parse(ds.Rows[0]["parent_pmp_id"].ToString());
        //                 where parentemp.pmp_id == int.Parse(Session_CS.pmp_id.ToString())
        //                 select parentemp;
        int parentPmpID = get_parent_emp();
        
        if (e.CommandName == "EditItem")
        {
            using (var context = new OutboxContext())
            {
            ////Outbox_Visa_Follows_DT obj = Outbox_Visa_Follows_DB.SelectByID(CDataConverter.ConvertToInt(e.CommandArgument));
                int hiddenValue = CDataConverter.ConvertToInt(e.CommandArgument);
                Outbox_Visa_Follows OutboxVisaFollowObj = context.Outbox_Visa_Follows.Where(x => x.Follow_ID == hiddenValue).SingleOrDefault();

            if (OutboxVisaFollowObj.Follow_ID > 0)
            {
                hidden_Follow_ID.Value = OutboxVisaFollowObj.Follow_ID.ToString();
                txt_Descrption.Text = OutboxVisaFollowObj.Descrption;
                txt_Follow_Date.Text = OutboxVisaFollowObj.Date;
                if (OutboxVisaFollowObj.Visa_Emp_id > 0)
                {

                    ddl_Visa_Emp_id.SelectedValue = OutboxVisaFollowObj.Visa_Emp_id.ToString();
                }


            }
            }
        }

        if (e.CommandName == "RemoveItem")
        {
            using (var context = new OutboxContext())
            {
            ////Outbox_Visa_Follows_DB.Delete(CDataConverter.ConvertToInt(e.CommandArgument));
                int CAValue = CDataConverter.ConvertToInt(e.CommandArgument);
                Outbox_Visa_Follows OutboxVisaFollowObj = context.Outbox_Visa_Follows.Where(x => x.Follow_ID == CAValue).SingleOrDefault();
            context.Outbox_Visa_Follows.Remove(OutboxVisaFollowObj);
            context.SaveChanges();
            // Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم الحذف بنجاح')</script>");
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('لقد تم الحذف بنجاح');", true);

            Fil_Grid_Visa_Follow();
        }
        }
        if (e.CommandName == "SendItem")
        {
            ////////////////////////////////////////////////////////////////////////////////////////////
            /////////////////// Sending Mail Code /////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////
            ////DataTable dt_getmail = General_Helping.GetDataTable("select mail,pmp_name from employee where pmp_id = " + parentPmpID);
            string mail;
            string parent_name;
            get_emplyee_mail_pmp_name(parentPmpID, out mail, out parent_name);



            MailMessage _Message = new MailMessage();
            if (int.Parse(Session_CS.group_id.ToString()) == 3)
            {
                _Message.Subject = "OUTIR";
            }
            else
            {
                _Message.Subject = "نظام الادارة الالكترونية - المراسلات";
            }


            //_Message.BodyEncoding = Encoding.Unicode;
            _Message.BodyEncoding = Encoding.UTF8;
            _Message.SubjectEncoding = Encoding.UTF8;

            //_Message.To.Add(new MailAddress(mail));



            // _Message.IsBodyHtml = true;
            _Message.Body = "<html><body dir='rtl'><h3 >";

            _Message.Body += " السيد  -   ";
            _Message.Body += parent_name;
            _Message.Body += " </h3>";
            //_Message.Body += " <h1 style=text-align:right>    وصلكم وارد من نظام إدارة مشروعات قطاع البنية المعلوماتية  </h1> ";
            _Message.Body += " <h3 > إيماءً إلى الوارد من  " + /*OrgDesc.Value*/ Smart_Org_ID.SelectedText + " بتاريخ " + txt_Date.Text + " بخصوص " + txt_Subject.Text + " </h3>";

            bool flag = false;

            string address2 = System.Web.HttpContext.Current.Request.Url.Authority.ToString();
            String encrypted_id = Encryption.Encrypt(Outbox_ID.Value);

            ////string Sql = "SELECT     Inbox_Visa_Follows.Follow_ID, Inbox_Visa_Follows.File_data,Inbox_Visa_Follows.File_name,Inbox_Visa_Follows.File_ext,Inbox_Visa_Follows.Inbox_ID, Inbox_Visa_Follows.Descrption, Inbox_Visa_Follows.Date, Inbox_Visa_Follows.Visa_Emp_id, EMPLOYEE.pmp_name " +
            ////            " FROM         Inbox_Visa_Follows INNER JOIN EMPLOYEE ON Inbox_Visa_Follows.Visa_Emp_id = EMPLOYEE.PMP_ID where Inbox_ID =" + Outbox_ID.Value;

            ///// DataTable dt = General_Helping.GetDataTable(Sql);
            using (var inboxContext = new InboxContext())
            {
                using (var ADContext = new ActiveDirectoryContext())
                {
                    int hiddenval = CDataConverter.ConvertToInt(Outbox_ID.Value);
                    var InboxVisaFollows = from IVF in inboxContext.Inbox_Visa_Follows
                                           join emps in ADContext.EMPLOYEEs on (long)IVF.Visa_Emp_id equals emps.PMP_ID
                                           where IVF.Inbox_ID == hiddenval
                                           select new
                                           {
                                               IVF = IVF,
                                               employee = emps
                                           };

                    string file = "";
                    byte[] files = new byte[0];
                    MemoryStream ms = new MemoryStream();
                    foreach (var inboxvisafollows in InboxVisaFollows)
                    {

                        if (!Equals(inboxvisafollows.IVF.File_data, DBNull.Value))
                        {

                            file = inboxvisafollows.IVF.File_name + inboxvisafollows.IVF.File_ext; //// file = dr["File_name"].ToString() + dr["File_ext"].ToString();
                            files = inboxvisafollows.IVF.File_data.ToArray(); ////(byte[])dr["File_data"];
                            ms = new MemoryStream(files);
                            _Message.Attachments.Add(new Attachment(ms, file));
                            flag = true;

                        }
                        if (inboxvisafollows.IVF.Follow_ID == CDataConverter.ConvertToInt(e.CommandArgument.ToString()))
                        {
                            _Message.Body += " <h3 > فقد أفاد السيد  " + inboxvisafollows.employee.pmp_name + "  فى تاريخ " + inboxvisafollows.IVF.Date + " بالتالى  </h3>";
                            _Message.Body += " <h3 > " + inboxvisafollows.IVF.Descrption + "  </h3>";
                        }
                    }
              

            if (flag)
                _Message.Body += "<h3 >   ومرفق الوثائق الخاصة بهذا الوارد</h3> <br /><br />";


            _Message.Body += "<h3 > مع تحيات </h3> ";
            _Message.Body += "<h3 >   " + Session_CS.e_signature.ToString() + "  </h3> ";
            _Message.Body += "</body></html>";
            ////SmtpClient config
            //SmtpClient Client = new SmtpClient();
            //Client.Port = int.Parse(ConfigurationManager.AppSettings["SMTP_Port"]);
            //Client.Host = ConfigurationManager.AppSettings["SMTP_Host"];
            //string UserName = ConfigurationManager.AppSettings["SMTP_UserName"];
            //string Password = ConfigurationManager.AppSettings["SMTP_Password"];
            //_Message.From = new MailAddress(ConfigurationManager.AppSettings["SMTP_FromAddress"]);

            ////_Message.Attachments.Add(new Attachment("D:\\Attached.pdf"));
            //System.Net.NetworkCredential SMTPUserInfo = new System.Net.NetworkCredential(UserName, Password);

            //Client.UseDefaultCredentials = false;
            //Client.Credentials = SMTPUserInfo;
            //Client.Timeout = 1000000000;

            GridViewRow row = (GridViewRow)((ImageButton)e.CommandSource).NamingContainer;
            int xx = row.RowIndex;
            GridView_Visa.Rows[xx].Cells[8].Visible = false;
            GridView_Visa.Rows[xx].Cells[9].Visible = false;
            GridView_Visa.Rows[xx].Cells[7].Visible = false;


            try
            {
                //Client.Send(_Message);
                SendingMailthread_class.Sendingmail(_Message, _Message.Subject, _Message.Body, mail, ms, file, encrypted_id, "");
            }
            catch (Exception ex)
            {
                // Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لم يتم ارسال الايميل للسيد المدير المختص بنجاح')</script>");

            }
            //Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم ارسال الايميل للسيد المدير المختص بنجاح')</script>");
                }
            }
                }


    }
    private void get_emplyee_mail_pmp_name(int parentPmpID, out string mail, out string parent_name)
    {
        using (var context = new ActiveDirectoryContext()) {
            EMPLOYEE OutboxVisaFollowObj = context.EMPLOYEEs.Where(x => x.PMP_ID == parentPmpID).FirstOrDefault();
        mail = OutboxVisaFollowObj.mail; ////dt_getmail.Rows[0]["mail"].ToString();
        parent_name = OutboxVisaFollowObj.pmp_name; ////dt_getmail.Rows[0]["pmp_name"].ToString();
        }
    }
    private int get_parent_emp()
    {
        using (var context = new ActiveDirectoryContext())
        {
            var pmpVal=int.Parse(Session_CS.pmp_id.ToString());
            var parentpmp = context.parent_employee.Where(x => x.pmp_id == pmpVal).FirstOrDefault();

            return parentpmp.parent_pmp_id;
        }
    }
    protected void btnSend_Click(object sender, EventArgs e)
    {
        if (CDataConverter.ConvertToInt(Outbox_ID.Value) > 0)
        {
            ////// get Parent 
            int parentPmpID = get_parent_emp();
            //string sqlformail = "SELECT parent_pmp_id from parent_employee where pmp_id =  " + int.Parse(Session_CS.pmp_id.ToString());
            //DataTable ds = General_Helping.GetDataTable(sqlformail);
            //int parent_pmp = int.Parse(ds.Rows[0]["parent_pmp_id"].ToString());
            ///////////// change  is_new_mail=1 /////////////////////////////////////////////



            //// SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            //// DataTable DT = new DataTable();
            //// DT = General_Helping.GetDataTable("select * from Outbox_Track_Manager where Outbox_id = " + Outbox_ID.Value);
            using (var context = new OutboxContext())
            {
                int hiddenval = CDataConverter.ConvertToInt(Outbox_ID.Value);
                var OutboxTrackManager = from outboxtrackmanager in context.Outbox_Track_Manager
                                         where outboxtrackmanager.Outbox_id == hiddenval
                                         select outboxtrackmanager;
                ////DataTable OutboxTrackManagerDT = OutboxTrackManager as DataTable;
                if (OutboxTrackManager.Count() > 0)
                {
                    ////conn.Open();
                    ////string sql = "update Outbox_Track_Manager set status=1 , All_visa_sent=0 where Outbox_id =" + Outbox_ID.Value;
                    Outbox_Track_Manager OutboxTrackManagerObj = context.Outbox_Track_Manager.Where(x => x.Outbox_id == hiddenval).SingleOrDefault();
                    OutboxTrackManagerObj.status = 1;
                    OutboxTrackManagerObj.All_visa_sent = 0;
                    context.SaveChanges();
                    //// SqlCommand cmd = new SqlCommand(sql, conn);
                    ////cmd.ExecuteNonQuery();
                    ///conn.Close();

                }
                else
                {

                    Outbox_Track_Manager OutboxTrackManagerObj = new Outbox_Track_Manager
                    {
                        Outbox_id = CDataConverter.ConvertToInt(Outbox_ID.Value),
                        Have_Visa = 0,
                        Have_Follow = 0,
                        IS_New_Mail = 1,
                        status = 1,
                        IS_Old_Mail = 0,
                        Visa_Desc = "",
                        Type_Track = 1,
                        pmp_id = int.Parse(Session_CS.pmp_id.ToString()),
                        parent_pmp_id = parentPmpID
                    };


                    try
                    {
                        context.Outbox_Track_Manager.Add(OutboxTrackManagerObj);
                        context.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('" + ex.Message + "');", true);
                    }
                    //Outbox_Track_Manager_DT obj = new Outbox_Track_Manager_DT();
                    //obj.Outbox_id = CDataConverter.ConvertToInt(Outbox_ID.Value);
                    //obj.Have_Visa = 0;
                    //obj.Have_Follow = 0;
                    //obj.IS_New_Mail = 1;
                    //obj.status = 1;
                    //obj.IS_Old_Mail = 0;
                    //obj.Visa_Desc = "";
                    //obj.Type_Track = 1;
                    //obj.pmp_id = int.Parse(Session_CS.pmp_id.ToString());
                    //obj.parent_pmp_id = parentPmpID;
                    //obj.Outbox_id = Outbox_Track_Manager_DB.Save(obj);
                    //if (obj.Outbox_id > 0)
                    //    //Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم الارسال بنجاح')</script>");

                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('لقد تم الارسال بنجاح ');", true);

                }


                ////////////////////////////////////////////////////////////////////////////////////////////
                /////////////////// Sending Mail Code /////////////////////////////////////////
                //////////////////////////////////////////////////////////////////////////////////////////
                ///////////////  to store that mohammed eid send to dr hesham the mail
                string date = CDataConverter.ConvertDateTimeToFormatdmy(CDataConverter.ConvertDateTimeNowRtnDt());
                
                Outbox_Visa_Follows OutboxVisaFollows = context.Outbox_Visa_Follows.Where(x => x.Follow_ID == hiddenval).SingleOrDefault();
                ////Outbox_Visa_Follows_DT obj_follow = Outbox_Visa_Follows_DB.SelectByID(CDataConverter.ConvertToInt(hidden_Follow_ID.Value));
                if (OutboxVisaFollows != null)
                {
                   // OutboxVisaFollows.Follow_ID = CDataConverter.ConvertToInt(hidden_Follow_ID.Value);
                    OutboxVisaFollows.Outbox_ID = CDataConverter.ConvertToInt(Outbox_ID.Value);

                    OutboxVisaFollows.Descrption = "تم الارسال الي المدير المختص";

                    OutboxVisaFollows.Date = date;
                    OutboxVisaFollows.time_follow = CDataConverter.ConvertTimeNowRtnLongTimeFormat();

                    OutboxVisaFollows.entery_pmp_id = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
                    OutboxVisaFollows.Visa_Emp_id = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());

                    context.Outbox_Visa_Follows.Add(OutboxVisaFollows);
                }
                else
                {
                    Outbox_Visa_Follows OutboxVisaFollowsnew = new Outbox_Visa_Follows
                    {
                        Follow_ID = CDataConverter.ConvertToInt(hidden_Follow_ID.Value),
                        Outbox_ID = CDataConverter.ConvertToInt(Outbox_ID.Value),
                        Descrption = "تم الارسال الي المدير المختص",
                        Date = date,
                        time_follow = CDataConverter.ConvertDateTimeNowRtnDt().ToLocalTime().ToLongTimeString(),
                        entery_pmp_id = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()),
                        Visa_Emp_id = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString())
                    };
                    context.Outbox_Visa_Follows.Add(OutboxVisaFollowsnew);
                }

                
                context.SaveChanges();
                ////obj_follow.Follow_ID = Outbox_Visa_Follows_DB.Save(obj_follow);
                Fil_Grid_Visa_Follow();


                string mail;
                string parent_name;
                get_emplyee_mail_pmp_name(parentPmpID, out mail, out parent_name);

                MailMessage _Message = new MailMessage();
                string str_subj = "";
                if (txt_Subject.Text.Length > 160)
                {
                    if (int.Parse(Session_CS.group_id.ToString()) == 3)
                    {
                        str_subj = txt_Subject.Text.Substring(0, 160);
                    }
                    else
                        str_subj = txt_Subject.Text.Substring(0, 130);


                }
                else
                {
                    str_subj = txt_Subject.Text;
                }


                string str_witoutn = str_subj.Replace("\n", "");
                str_subj = str_witoutn.Replace("\r", "");

                if (int.Parse(Session_CS.group_id.ToString()) == 3)
                {

                    _Message.Subject = ("OUTIR" + " - " + str_subj + " - " + txt_Date.Text).ToString();

                }
                else
                {

                    _Message.Subject = "نظام الادارة الالكترونية - المراسلات" + " - " + str_subj + " - " + txt_Date.Text;
                }


                //_Message.BodyEncoding = Encoding.Unicode;
                _Message.BodyEncoding = Encoding.UTF8;
                _Message.SubjectEncoding = Encoding.UTF8;

                ////_Message.To.Add(new MailAddress(mail));



                //_Message.IsBodyHtml = true;
                _Message.Body = "<html><body dir='rtl'><h3 >";
                _Message.Body += "  السيد";
                _Message.Body += " " + parent_name + "    </h3> ";
                // _Message.Body += " <h1 style=text-align:right>    وصلكم وارد من نظام إدارة مشروعات قطاع البنية المعلوماتية  </h1> ";

                _Message.Body += " <h3 > " + " وصلكم صادر من " + Smart_Org_ID.SelectedText /*OrgDesc.Value*/ + " بتاريخ " + txt_Date.Text + " بخصوص <br/>" + "<h3 style=" + "color:blue >" + txt_Subject.Text + "</h3>";
                bool flag = false;
                string file = "";
                byte[] files = new byte[0];
                MemoryStream ms = new MemoryStream();
                using (var inboxcontext = new InboxContext())
                {
                    IEnumerable<Inbox_OutBox_Files> InboxOutBoxFile = inboxcontext.Inbox_OutBox_Files.Where(x => x.Inbox_Outbox_ID == hiddenval && x.Inbox_Or_Outbox == 2);

                    ////DataTable dt = General_Helping.GetDataTable("select * from Inbox_OutBox_Files where Inbox_Outbox_ID =" + Outbox_ID.Value + " and Inbox_Or_Outbox =2 ");
                    foreach (Inbox_OutBox_Files inboxoutBoxfile in InboxOutBoxFile)
                    {

                        if (!Equals(inboxoutBoxfile.File_data, DBNull.Value))
                        {

                            file = inboxoutBoxfile.File_name + inboxoutBoxfile.File_ext;
                            files = inboxoutBoxfile.File_data.ToArray();
                            ms = new MemoryStream(files);
                            _Message.Attachments.Add(new Attachment(ms, file));
                            if (ms.Length > 26214400)
                            {
                                //Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('حجم الملفات التابعة لهذا البريد أكبر من المسموح')</script>");

                                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('حجم الملفات التابعة لهذا البريد أكبر من المسموح ');", true);

                                return;
                            }
                            flag = true;

                        }
                    }
                    String encrypted_id = Encryption.Encrypt(Outbox_ID.Value);
                    string address2 = System.Web.HttpContext.Current.Request.Url.Authority.ToString();
                    _Message.Body += " <h3 > ورابط الصادر هو  :<br/>";
                    _Message.Body += " <h3 >http:" + "/" + "/" + address2 + "/MainForm/ViewProjectOutbox.aspx?id=" + encrypted_id + "&1=1</h3>";

                    if (flag)
                        _Message.Body += "<h3 >   ومرفق الوثائق الخاصة بهذا الصادر</h3> <br /><br />";


                    _Message.Body += "<h3 > مع تحيات </h3> ";
                    _Message.Body += "<h3 >   " + Session_CS.e_signature.ToString() + "  </h3> ";
                    _Message.Body += "</body></html>";
                    ////SmtpClient config
                    //SmtpClient Client = new SmtpClient();
                    //Client.Port = int.Parse(ConfigurationManager.AppSettings["SMTP_Port"]);
                    //Client.Host = ConfigurationManager.AppSettings["SMTP_Host"];
                    //string UserName = ConfigurationManager.AppSettings["SMTP_UserName"];
                    //string Password = ConfigurationManager.AppSettings["SMTP_Password"];
                    //_Message.From = new MailAddress(ConfigurationManager.AppSettings["SMTP_FromAddress"]);

                    ////_Message.Attachments.Add(new Attachment("D:\\Attached.pdf"));
                    //System.Net.NetworkCredential SMTPUserInfo = new System.Net.NetworkCredential(UserName, Password);

                    //Client.UseDefaultCredentials = false;
                    //Client.Credentials = SMTPUserInfo;
                    //Client.Timeout = 1000000000;

                    try
                    {
                        //_Message.To.Add(new MailAddress(mail));

                        //Client.Send(_Message);
                        SendingMailthread_class.Sendingmail(_Message, _Message.Subject, _Message.Body, mail, ms, file, encrypted_id, "");

                    }
                    catch (Exception ex)
                    {

                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('" + ex.Message + "');", true);

                    }
                    // Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم ارسال الايميل بنجاح')</script>");



                    //////////////////// to show mohammed eid in the drop down list of employee in المسير
                }
            }
        }
        else
        {
            // Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('يجب إدخال بيانات الخطاب أولا')</script>");

            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('يجب إدخال بيانات الخطاب أولا ');", true);


        }
        

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {


        if ((CDataConverter.ConvertToInt(ddl_Type.SelectedValue) == 2 && CDataConverter.ConvertToInt(/*OrgID.Value*/Smart_Org_ID.SelectedValue) > 0) || CDataConverter.ConvertToInt(ddl_Type.SelectedValue) == 1)
        {

            if (Session_CS.code_outbox == 1)
            {
                // txt_Code.Enabled = false;

                DataTable getmax = SqlHelper.ExecuteDataset(Database.ConnectionString, "get_max_code_outbox", Session_CS.foundation_id).Tables[0];
                txt_Code.Text = getmax.Rows[0]["code"].ToString();
            }

            string datenow = "";
            int dept_id = 0;
            int Org_Id = 0;
            datenow = CDataConverter.ConvertDateTimeNowRtnDt().ToString();
            if (CDataConverter.ConvertToInt(ddl_Type.SelectedValue) == 1)
            {
                if (CDataConverter.ConvertToInt(Smrt_Srch_structure2.SelectedValue) > 0)
                {
                    dept_id = CDataConverter.ConvertToInt(Smrt_Srch_structure2.SelectedValue);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('يجب إختيار الإدارة ');", true);
                    return;
                }
            }
            else
            {
                Org_Id = CDataConverter.ConvertToInt(Smart_Org_ID.SelectedValue /*OrgID.Value*/);
            }
            using (var context = new OutboxContext())
            {
                if (CDataConverter.ConvertToInt(Outbox_ID.Value) > 0)
                {
                    int xy = CDataConverter.ConvertToInt(Outbox_ID.Value);

                    Outbox OutboxObj = context.Outboxes.SingleOrDefault(x => x.ID == xy );
                    OutboxObj.Proj_id = int.Parse(Session_CS.Project_id.ToString());
                    OutboxObj.Name = txt_Name.Text;
                    OutboxObj.Code = txt_Code.Text;
                    OutboxObj.Date = txt_Date.Text;
                    OutboxObj.Enter_Date = datenow;
                    OutboxObj.Dept_Dept_ID = int.Parse(Session_CS.dept_id.ToString());
                    OutboxObj.pmp_pmp_id = int.Parse(Session_CS.pmp_id.ToString());
                    OutboxObj.Group_id = int.Parse(Session_CS.group_id.ToString());
                    OutboxObj.Type = CDataConverter.ConvertToInt(ddl_Type.SelectedValue);
                    OutboxObj.Dept_ID = dept_id;
                    OutboxObj.Org_Id = Org_Id;
                    OutboxObj.Emp_ID = CDataConverter.ConvertToInt(Smart_Emp_ID.SelectedValue);
                    OutboxObj.Org_Out_Box_Code = txt_Org_Out_Box_Code.Text;
                    OutboxObj.Org_Out_Box_DT = txt_Org_Out_Box_DT.Text;
                    OutboxObj.Org_Out_Box_Person = txt_Org_Out_Box_Person.Text;
                    OutboxObj.Subject = txt_Subject.Text;
                    OutboxObj.Related_Type = CDataConverter.ConvertToInt(ddl_Related_Type.SelectedValue);
                    OutboxObj.Related_Id = CDataConverter.ConvertToInt(Smart_Related_Id.SelectedValue);
                    OutboxObj.Notes = txt_Notes.Text;
                    OutboxObj.Paper_No = txt_Paper_No.Text;
                    OutboxObj.Paper_Attached = txt_Paper_Attached.Text;
                    OutboxObj.Follow_Up_Dept_ID = 0;
                    OutboxObj.Follow_Up_Emp_ID = 0;
                    OutboxObj.Dept_Desc = txt_Dept_Desc.Text;
                    OutboxObj.Source_Type = CDataConverter.ConvertToInt(ddl_Source_Type.SelectedValue);
                    OutboxObj.Status = 0;
                    OutboxObj.finished = 0;
                    OutboxObj.Org_Dept_Name = txt_Org_Dept_Name.Text;
                    OutboxObj.foundation_id = CDataConverter.ConvertToInt(Session_CS.foundation_id.ToString());
                    context.SaveChanges();


                }
                else
                {
                    Outbox OutboxObj = new Outbox
                        {
                            ID = CDataConverter.ConvertToInt(Outbox_ID.Value),

                            Proj_id = int.Parse(Session_CS.Project_id.ToString()),
                            Name = txt_Name.Text,
                            Code = txt_Code.Text,
                            Date = txt_Date.Text,
                            Enter_Date = datenow,
                            Dept_Dept_ID = int.Parse(Session_CS.dept_id.ToString()),
                            pmp_pmp_id = int.Parse(Session_CS.pmp_id.ToString()),
                            Group_id = int.Parse(Session_CS.group_id.ToString()),
                            Type = CDataConverter.ConvertToInt(ddl_Type.SelectedValue),
                            Dept_ID = dept_id,
                            Org_Id = Org_Id,
                            Emp_ID = CDataConverter.ConvertToInt(Smart_Emp_ID.SelectedValue),
                            Org_Out_Box_Code = txt_Org_Out_Box_Code.Text,
                            Org_Out_Box_DT = txt_Org_Out_Box_DT.Text,
                            Org_Out_Box_Person = txt_Org_Out_Box_Person.Text,
                            Subject = txt_Subject.Text,
                            Related_Type = CDataConverter.ConvertToInt(ddl_Related_Type.SelectedValue),
                            Related_Id = CDataConverter.ConvertToInt(Smart_Related_Id.SelectedValue),
                            Notes = txt_Notes.Text,
                            Paper_No = txt_Paper_No.Text,
                            Paper_Attached = txt_Paper_Attached.Text,
                            Follow_Up_Dept_ID = 0,
                            Follow_Up_Emp_ID = 0,
                            Dept_Desc = txt_Dept_Desc.Text,
                            Source_Type = CDataConverter.ConvertToInt(ddl_Source_Type.SelectedValue),
                            Status = 0,
                            finished = 0,
                            Org_Dept_Name = txt_Org_Dept_Name.Text,
                            foundation_id = CDataConverter.ConvertToInt(Session_CS.foundation_id.ToString()),


                        };

                    context.Outboxes.Add(OutboxObj);
                    context.SaveChanges();

                    Outbox_ID.Value = OutboxObj.ID.ToString();

                    //if (OutboxObj.ID > 0)
                    //{

                    //    if (Session_CS.code_outbox == 1)
                    //    {
                    //        txt_Code.Enabled = false;

                    //        DataTable getmax = SqlHelper.ExecuteDataset(Database.ConnectionString, "get_max_code_outbox", Session_CS.foundation_id).Tables[0];
                    //        txt_Code.Text = getmax.Rows[0]["code"].ToString();


                    //        int row = SqlHelper.ExecuteNonQuery(Database.ConnectionString, "update_code",OutboxObj.ID,2,txt_Code.Text);

                    //    }
                    //}



                    context.SPOutboxCatDelete(CDataConverter.ConvertToInt(Outbox_ID.Value));
                }
                //var outboxCats = outboxDBContext.outbox_cats.Where(x => x.outbox_id == CDataConverter.ConvertToInt(Outbox_ID.Value));
                //if (outboxCats.Count() > 0)
                //{
                //    foreach (var outboxCat in outboxCats)
                //    {
                //        outboxDBContext.outbox_cats.DeleteOnSubmit(outboxCat);
                //        outboxDBContext.SubmitChanges();
                //    }
                //}////string Sql_Delete = "delete from  outbox_cat where  outbox_id = " + lastOutboxObj.ID;
                ////General_Helping.ExcuteQuery(Sql_Delete);

                foreach (ListItem item in Chk_main_cat.Items)
                {
                    if (item.Selected)
                    {
                        ////Outbox_DB.Outbox_cat_save(CDataConverter.ConvertToInt(lastOutboxObj.ID), CDataConverter.ConvertToInt(item.Value), 1, 1);
                        context.Outbox_cat_save(CDataConverter.ConvertToInt(CDataConverter.ConvertToInt(Outbox_ID.Value)), CDataConverter.ConvertToInt(item.Value), 1, 1);
                    }
                }
                foreach (ListItem item in Chk_sub_cat.Items)
                {
                    if (item.Selected)
                    {
                        context.Outbox_cat_save(CDataConverter.ConvertToInt(CDataConverter.ConvertToInt(Outbox_ID.Value)), CDataConverter.ConvertToInt(item.Value), 2, 1);
                    }
                }

                int found = Session_CS.foundation_id;
                using (var inboxContext = new InboxContext())
                {
                    if (CDataConverter.ConvertToInt(Outbox_ID.Value) > 0)
                    {

                        if (ddl_Related_Type.SelectedValue == "2")
                        {

                            //sql_related = "insert into Inbox_Relations values ( " + obj.ID + "," + CDataConverter.ConvertToInt(Smart_Related_Id.SelectedValue) + ",1,2," + found + " )";
                            Inbox_Relations InboxRelation1 = new Inbox_Relations
                            {
                                inbox_id = CDataConverter.ConvertToInt(Outbox_ID.Value),
                                inbox_id_type = 2,
                                Related_ID = CDataConverter.ConvertToInt(Smart_Related_Id.SelectedValue),
                                Related_ID_Type = 1,
                                foundation_id = found
                            };
                            Inbox_Relations InboxRelation2 = new Inbox_Relations
                            {
                                inbox_id = CDataConverter.ConvertToInt(Smart_Related_Id.SelectedValue),
                                inbox_id_type = 1,
                                Related_ID = CDataConverter.ConvertToInt(Outbox_ID.Value),
                                Related_ID_Type = 2,
                                foundation_id = found
                            };

                            inboxContext.Inbox_Relations.Add(InboxRelation1);
                            inboxContext.Inbox_Relations.Add(InboxRelation2);
                            inboxContext.SaveChanges();
                            //// sql_related = "insert into Inbox_Relations values ( " + obj.ID + ",2," + CDataConverter.ConvertToInt(Smart_Related_Id.SelectedValue) + ",1," + found + " )";
                            ///// sql_related += " insert into Inbox_Relations values ( " + CDataConverter.ConvertToInt(Smart_Related_Id.SelectedValue) + ",1," + obj.ID + ",2," + found + " )";
                            //// General_Helping.ExcuteQuery(sql_related);
                        }
                        else if (ddl_Related_Type.SelectedValue == "3")
                        {
                            // sql_related = "insert into Inbox_Relations values ( " + obj.ID + "," + CDataConverter.ConvertToInt(Smart_Related_Id.SelectedValue) + ",2,2," + found + " )";
                            Inbox_Relations InboxRelation3 = new Inbox_Relations
                            {
                                inbox_id = CDataConverter.ConvertToInt(Outbox_ID.Value),
                                inbox_id_type = 2,
                                Related_ID = CDataConverter.ConvertToInt(Smart_Related_Id.SelectedValue),
                                Related_ID_Type = 2,
                                foundation_id = found
                            };
                            inboxContext.Inbox_Relations.Add(InboxRelation3);
                            inboxContext.SaveChanges();
                            //// sql_related = "insert into Inbox_Relations values ( " + obj.ID + ",2," + CDataConverter.ConvertToInt(Smart_Related_Id.SelectedValue) + ",2," + found + " )";
                            //// General_Helping.ExcuteQuery(sql_related);
                        }

                        // Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم الحفظ بنجاح')</script>");

                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('لقد تم الحفظ بنجاح');", true);


                    }
                    else
                    {
                        //  Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لم يتم الحفظ يرجى التأكد من البيانات ')</script>");

                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('لم يتم الحفظ يرجى التأكد من البيانات');", true);

                    }
                    if (ddl_Related_Type.SelectedValue == "2")
                    {

                        int smartValue = CDataConverter.ConvertToInt(Smart_Related_Id.SelectedValue);
                        IEnumerable<Inbox> inboxObjs = inboxContext.Inboxes.Where(x => x.ID == smartValue && x.Related_Type == 1);
                        foreach (Inbox inboxObj in inboxObjs)
                        {
                            inboxObj.Related_Type = 5;
                            inboxObj.Related_Id = CDataConverter.ConvertToInt(Outbox_ID.Value);
                        }
                        inboxContext.SaveChanges();
                        ////string sql = "update inbox set Related_Type =5 , Related_Id = " + Outbox_ID.Value + " where ID = " + Smart_Related_Id.SelectedValue + " and Related_Type=1";
                        ////General_Helping.ExcuteQuery(sql);
                    }

                    else
                    {
                        //Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('يجب إختيار الجهة الصادر لها')</script>");

                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('يجب إختيار الجهة الصادر لها');", true);


                    }
                    //Fil_Smrt_From_Outbox();
                    DataTable orgsdt = new DataTable();
                    orgsdt.Columns.Add("id", typeof(int));
                    orgsdt.Columns.Add("con", typeof(string));
                    int groupVal = int.Parse(Session_CS.group_id.ToString());
                    int projectVal = CDataConverter.ConvertToInt(Session_CS.Project_id.ToString());
                    var orgsDT = from orgs in context.SP_vw_outbox_DateSubject(groupVal, projectVal)
                                 select orgsdt.LoadDataRow(
                                          new object[] {
                                     orgs.ID,
                                    orgs.con
                                }, false);

                    Fil_Smrt_From(orgsdt);
                }
            }
        }
    }
    private void MOnMember_Data(string Value)
    {
        dropdept_fun();
        //// fill_emplyees();
    }
    private void MOnMember_Data2(string Value)
    {

        fill_emplyees();
        //// fill_resp_Emp();
    }
    protected void dropdept_fun()
    {
        //SqlConnection conn = new SqlConnection(sql_Connection);

        ////refactored by hafs
        ////chklst_Visa_Emp.DataSource = fil_emp_by_Dept(CDataConverter.ConvertToInt(Smrt_Srch_structure.SelectedValue));//fil_emp_Visa();
        ////chklst_Visa_Emp.DataBind();
        ////chklst_Visa_Emp_All.Items.Clear();
        ////int? deptID = CDataConverter.ConvertToInt(DBNull.Value);
        ////if (radlst_Type.SelectedValue != "7")
        ////{

        ////    deptID = (CDataConverter.ConvertToInt(Smrt_Srch_structure.SelectedValue) > 0) ? CDataConverter.ConvertToInt(Smrt_Srch_structure.SelectedValue) : deptID;
        ////    chklst_Visa_Emp_All.DataSource = outboxDBContext.get_employee_accoording_to_radiochek(radlst_Type.SelectedValue, Session_CS.pmp_id, deptID, Session_CS.foundation_id).ToList();
        ////    chklst_Visa_Emp_All.DataBind();
        ////    TabPanel_All.ActiveTab = TabPanel_Visa;
        ////    tr_emp_list.Visible = true;
        ////}
        chklst_Visa_Emp_All.Items.Clear();

        if (radlst_Type.SelectedValue != "7")
        {


            DataTable DT_emp;

            SqlParameter[] sqlParams = new SqlParameter[4];

            sqlParams[0] = new SqlParameter("@radiocheck", radlst_Type.SelectedValue);
            sqlParams[1] = new SqlParameter("@pmp_id", Session_CS.pmp_id);

            if (CDataConverter.ConvertToInt(Smrt_Srch_structure.SelectedValue) > 0)
                sqlParams[2] = new SqlParameter("@dept_id", CDataConverter.ConvertToInt(Smrt_Srch_structure.SelectedValue));
            else
                sqlParams[2] = new SqlParameter("@dept_id", CDataConverter.ConvertToInt(DBNull.Value));

            sqlParams[3] = new SqlParameter("@found_id", Session_CS.foundation_id);

            DT_emp = DatabaseFunctions.SelectDataByParam(sqlParams, "get_employee_accoording_to_radiochek");
            if (DT_emp.Rows.Count > 0)
            {
                chklst_Visa_Emp_All.DataSource = DT_emp;
                chklst_Visa_Emp_All.DataBind();
            }
        }




    }
    protected void ddl_Type_SelectedIndexChanged(object sender, EventArgs e)
    {
        Type_Changed();

    }
    protected void ddl_Follow_Up_Dept_ID_SelectedIndexChanged(object sender, EventArgs e)
    {
        ////fil_emp_Folow_Up();
    }

    void Fil_Smrt_From_InBox()
    {
        Smart_Related_Id.sql_Connection = sql_Connection;
        // Smart_Related_Id.Query = "SELECT * from vw_inbox_DateSubject where  group_id = " + int.Parse(Session_CS.group_id.ToString());
        string Query = "set dateformat dmy SELECT vw_inbox_DateSubject.*,CONVERT(datetime, dbo.datevalid(Date)) as date1 from vw_inbox_DateSubject where  group_id = " + int.Parse(Session_CS.group_id.ToString());
        if (CDataConverter.ConvertToInt(Session_CS.Project_id.ToString()) > 0)
        {
            Query += " AND Proj_id = " + int.Parse(Session_CS.Project_id.ToString());
        }
        Query += " order by CONVERT(datetime, dbo.datevalid(Date)) desc ";
        Smart_Related_Id.datatble = General_Helping.GetDataTable(Query);
        Smart_Related_Id.Value_Field = "id";
        Smart_Related_Id.Text_Field = "con";
        Smart_Related_Id.Show_Code = false;
        Smart_Related_Id.Orderby = "date1 desc";
        Smart_Related_Id.DataBind();
    }

    private void Fil_Smrt_From_Outbox()
    {
        Smart_Related_Id.sql_Connection = sql_Connection;
        //  Smart_Related_Id.Query = "SELECT * from vw_outbox_DateSubject where group_id =  " + int.Parse(Session_CS.group_id.ToString());
        string Query = "SELECT * from vw_outbox_DateSubject where group_id =  " + int.Parse(Session_CS.group_id.ToString());
        Smart_Related_Id.datatble = General_Helping.GetDataTable(Query);
        Smart_Related_Id.Show_Code = false;
        Smart_Related_Id.Value_Field = "id";
        Smart_Related_Id.Text_Field = "con";
        Smart_Related_Id.DataBind();
    }

    void Fil_Smrt_From_InBox_Minister()
    {
        Smart_Related_Id.sql_Connection = sql_Connection;
        string Query = "";
        Query = "set dateformat dmy SELECT vw_inbox_minister_DateSubject.* from vw_inbox_minister_DateSubject where  group_id = " + int.Parse(Session_CS.group_id.ToString());
        if (CDataConverter.ConvertToInt(Session_CS.Project_id.ToString()) > 0)
        {
            Query += " AND Proj_id = " + int.Parse(Session_CS.Project_id.ToString());
        }
        Smart_Related_Id.datatble = General_Helping.GetDataTable(Query);
        Smart_Related_Id.Value_Field = "id";
        Smart_Related_Id.Text_Field = "con";
        Smart_Related_Id.Show_Code = false;
        Smart_Related_Id.DataBind();
    }

    protected void ddl_Related_Type_SelectedIndexChanged(object sender, EventArgs e)
    {
        Related_type_Changed();

    }
    private void Related_type_Changed()
    {
        if (ddl_Related_Type.SelectedValue == "1")
        {
           // trSmart.Visible = false;
            trSmart.Style.Add("display", "none");
        }
        else if (ddl_Related_Type.SelectedValue == "2")
        {

            //trSmart.Visible = true;
            trSmart.Style.Add("display", "block");
            lbl_Inbox_type.Text = "رد على وارد رقم";
            Fil_Smrt_From_InBox();


            //DataTable orgsdt = new DataTable();
            //orgsdt.Columns.Add("id", typeof(int));
            //orgsdt.Columns.Add("con", typeof(string));
            //var orgsDT = from orgs in (outboxDBContext.SP_vw_inbox_DateSubject(int.Parse(Session_CS.group_id.ToString()), CDataConverter.ConvertToInt(Session_CS.Project_id.ToString())))
            //             select orgsdt.LoadDataRow(
            //                      new object[] {
            //                         orgs.ID,
            //                        orgs.con
            //                    }, false);
            //Fil_Smrt_From(orgsdt);

        }
        else if (ddl_Related_Type.SelectedValue == "3")
        {

            //trSmart.Visible = true;
            trSmart.Style.Add("display", "block");
            lbl_Inbox_type.Text = "استعجال للصادر رقم";
            Fil_Smrt_From_Outbox();
           
            //DataTable orgsdt = new DataTable();
            //orgsdt.Columns.Add("id", typeof(int));
            //orgsdt.Columns.Add("con", typeof(string));
            //var orgsDT = from orgs in outboxDBContext.SP_vw_outbox_DateSubject(int.Parse(Session_CS.group_id.ToString()), CDataConverter.ConvertToInt(Session_CS.Project_id.ToString()))
            //             select orgsdt.LoadDataRow(
            //                      new object[] {
            //                         orgs.ID,
            //                        orgs.con
            //                    }, false);
            //Fil_Smrt_From(orgsdt);

        }
        else if (ddl_Related_Type.SelectedValue == "4")
        {

            //trSmart.Visible = true;
            trSmart.Style.Add("display", "block");
            lbl_Inbox_type.Text = "رد علي تأشيرة وزير رقم";
            Fil_Smrt_From_InBox_Minister();


            //DataTable orgsdt = new DataTable();
            //orgsdt.Columns.Add("id", typeof(int));
            //orgsdt.Columns.Add("con", typeof(string));
            //var orgsDT = from orgs in outboxDBContext.SP_vw_inbox_minister_DateSubject(int.Parse(Session_CS.group_id.ToString()), CDataConverter.ConvertToInt(Session_CS.Project_id.ToString()))
            //             select orgsdt.LoadDataRow(
            //                      new object[] {
            //                         orgs.ID,
            //                        orgs.con
            //                    }, false);
            //Fil_Smrt_From(orgsdt);


        }

        else if (ddl_Related_Type.SelectedValue == "5")
        {
            trSmart.Style.Add("display", "none");
        }


        else if (ddl_Related_Type.SelectedValue == "6")
        {

       
            trSmart.Style.Add("display", "block");
            lbl_Inbox_type.Text = " وارد لصادر داخلي رقم ";
            Fil_Smrt_From_InBox();



        }

        TabPanel_All.ActiveTab = TabPanel_dtl;
    }



    protected void chkSent_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox checkbox = (CheckBox)sender;
        if (checkbox.Checked)
        {
            GridViewRow row = (GridViewRow)checkbox.NamingContainer;
            ImageButton imgEdit = (ImageButton)row.FindControl("ImgBtnEdit");
            Label lbl_desc = (Label)row.FindControl("lbl_desc");
            string Id = imgEdit.CommandArgument.ToString();

            ////Outbox_Visa_Follows_DT obj_follow = Outbox_Visa_Follows_DB.SelectByID(CDataConverter.ConvertToInt(hidden_Follow_ID.Value));
            using (var outboxContext = new OutboxContext()) {
                int hiddenFollowID= CDataConverter.ConvertToInt(hidden_Follow_ID.Value);
                Outbox_Visa_Follows OutboxVisaFollow = outboxContext.Outbox_Visa_Follows.Where(x => x.Follow_ID == hiddenFollowID).FirstOrDefault();
            if (OutboxVisaFollow != null)
            {
                OutboxVisaFollow.Follow_ID = 0;
                OutboxVisaFollow.Outbox_ID = CDataConverter.ConvertToInt(Outbox_ID.Value);
                OutboxVisaFollow.Descrption = " تم انهاء التاشيرة " + lbl_desc.Text + " بواسطة  " + Session_CS.pmp_name.ToString();
                string date = CDataConverter.ConvertDateTimeToFormatdmy(CDataConverter.ConvertDateTimeNowRtnDt());
                OutboxVisaFollow.Date = date;
                OutboxVisaFollow.time_follow = CDataConverter.ConvertTimeNowRtnLongTimeFormat();
                OutboxVisaFollow.entery_pmp_id = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
                OutboxVisaFollow.Visa_Emp_id = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
                ////obj_follow.Follow_ID = Outbox_Visa_Follows_DB.Save(obj_follow);
                ////Outbox_Visa_DT obj = Outbox_Visa_DB.SelectByID(CDataConverter.ConvertToInt(Id));
                Outbox_Visa OutboxVisa = outboxContext.Outbox_Visa.Where(x => x.Visa_Id == CDataConverter.ConvertToInt(Id)).SingleOrDefault();
                OutboxVisa.mail_sent = 1;
                outboxContext.SaveChanges();
            }
            }
            ////Outbox_Visa_DB.Save(obj);
            Update_Have_Visa(Id);

            Fil_Grid_Visa_Follow();




        }
        Fil_Grid_Visa();
        TabPanel_All.ActiveTab = TabPanel_Visa;

    }
    protected void GridView_Visa_rw_data_bound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ////string temp_sql = "";
            ////DataTable Dt;
            string id = (string)Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Visa_Id"));
            ////temp_sql = "select mail_sent from Outbox_Visa where Visa_Id=" + id;
            ////Dt = General_Helping.GetDataTable(temp_sql);
            using (var outboxContext = new OutboxContext())
            {
                var idVal =  CDataConverter.ConvertToInt(id);
                var OutboxVisa = outboxContext.Outbox_Visa.Where(x => x.Visa_Id == idVal);

                if (OutboxVisa.Count() > 0)
                {
                    if (OutboxVisa.FirstOrDefault().mail_sent == 1)
                    {
                        CheckBox chbsent = (CheckBox)e.Row.FindControl("chkSent");
                        chbsent.Checked = true;
                    }

                }
            }
        }
    }
    private void Save_inox_Visa(int visaID)
    {
        //var OutboxVisaEmps = outboxDBContext.Outbox_Visa_Emps.Where(x => x.Visa_Id == visaID);
        //foreach (var OutboxVisaEmp in OutboxVisaEmps)
        //{
        //    outboxDBContext.Outbox_Visa_Emps.DeleteOnSubmit(OutboxVisaEmp);
        //}
        using (var outboxContext = new OutboxContext())
        {
            outboxContext.SPOutbox_Visa_EmpDelete(visaID);

            //outboxDBContext.SubmitChanges();
            //// string Sql_Delete = "delete from Outbox_Visa_Emp where Visa_Id =" + obj.Visa_Id;
            ////General_Helping.ExcuteQuery(Sql_Delete);
            using (var ADContext = new ActiveDirectoryContext())
            {
                var pmpIDVal = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
                parent_employee parent_employee = ADContext.parent_employee.Where(x => x.pmp_id == pmpIDVal && x.Type == 2).SingleOrDefault();

                foreach (ListItem item in lst_emp.Items)
                {

                    //// DataTable dt = General_Helping.GetDataTable("select * from parent_employee where pmp_id = " + CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()));
                    if (parent_employee != null)
                    {
                        // Sql_insert = "insert into outbox_Visa_Emp ( Visa_Id , Emp_ID ,Sender_id) values ( " + obj.Visa_Id + "," + item.Value + "," + CDataConverter.ConvertToInt(dt.Rows[0]["parent_pmp_id"].ToString()) + ")";

                        outboxContext.Outbox_visa_emp_save(visaID, CDataConverter.ConvertToInt(item.Value), parent_employee.parent_pmp_id);
                        ////Outbox_DB.Outbox_visa_emp_save(CDataConverter.ConvertToInt(obj.Visa_Id), CDataConverter.ConvertToInt(item.Value), CDataConverter.ConvertToInt(dt.Rows[0]["parent_pmp_id"].ToString()));

                    }
                    else
                    {
                        // Sql_insert = "insert into outbox_Visa_Emp ( Visa_Id , Emp_ID ,Sender_id) values ( " + obj.Visa_Id + "," + item.Value + "," + CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()) + ")";
                        ////Outbox_DB.Outbox_visa_emp_save(CDataConverter.ConvertToInt(obj.Visa_Id), CDataConverter.ConvertToInt(item.Value), CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()));
                        outboxContext.Outbox_visa_emp_save(visaID, CDataConverter.ConvertToInt(item.Value), CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()));
                    }

                }
            }
        }

    }
    protected void GrdView_Documents_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        var commArgVal = CDataConverter.ConvertToInt(e.CommandArgument);
        if (e.CommandName == "EditItem")
        {
            using (var inboxContext = new InboxContext())
            {
               
                Inbox_OutBox_Files InboxOutBoxFile = inboxContext.Inbox_OutBox_Files.Where(x => x.Inbox_OutBox_File_ID == commArgVal).SingleOrDefault();
                ////Inbox_OutBox_Files_DT obj = Inbox_OutBox_Files_DB.SelectByID(CDataConverter.ConvertToInt(e.CommandArgument));
                if (InboxOutBoxFile.Inbox_OutBox_File_ID > 0)
                {
                    hidden_Inbox_OutBox_File_ID.Value = InboxOutBoxFile.Inbox_OutBox_File_ID.ToString();
                    txtFileName.Text = InboxOutBoxFile.File_name;
                    ddl_Original_Or_Attached.SelectedValue = InboxOutBoxFile.Original_Or_Attached.ToString();
                }

            }
        }

        if (e.CommandName == "RemoveItem")
        {
            using (var inboxContext = new InboxContext())
            {
                Inbox_OutBox_Files InboxOutBoxFile = inboxContext.Inbox_OutBox_Files.Where(x => x.Inbox_OutBox_File_ID == commArgVal).SingleOrDefault();
                inboxContext.Inbox_OutBox_Files.Remove(InboxOutBoxFile);
                inboxContext.SaveChanges();
                ////Inbox_OutBox_Files_DB.Delete(CDataConverter.ConvertToInt(e.CommandArgument));
                //Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم الحذف بنجاح')</script>");
            }
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('لقد تم الحذف بنجاح');", true);

            Fil_Grid_Documents();
        }
    }

    public int InsertOrUpdate_Inbox(Inbox blog)
    {


        using (var context = new InboxContext())
        {

            context.Entry(blog).State = blog.ID == 0 ?
                                      System.Data.Entity.EntityState.Added :
                                      System.Data.Entity.EntityState.Modified;

            context.SaveChanges();
            return blog.ID;
        }
    }
    public void InsertOrUpdate_Inbox_Visa_follows(Inbox_Visa_Follows blog)
    {


        using (var context = new InboxContext())
        {
            context.Entry(blog).State = blog.Follow_ID == 0 ?
                                      System.Data.Entity.EntityState.Added :
                                      System.Data.Entity.EntityState.Modified;

            context.SaveChanges();

        }
    }

    protected void GridView_Visa_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        var commArgVal = CDataConverter.ConvertToInt(e.CommandArgument);
        if (e.CommandName == "EditItem")
        {
            Fil_Visa_Control(commArgVal);
            ////Fil_Visa_Lst(CDataConverter.ConvertToInt(e.CommandArgument));
            Fil_Visa_Lstbox(commArgVal);

        }

        if (e.CommandName == "RemoveItem")
        {
            using (var outboxContext = new OutboxContext())
            {
                Outbox_Visa OutboxVisa = outboxContext.Outbox_Visa.Where(x => x.Visa_Id == commArgVal).SingleOrDefault();
                outboxContext.Outbox_Visa.Remove(OutboxVisa);
                outboxContext.SaveChanges();

                ////Outbox_Visa_DB.Delete(CDataConverter.ConvertToInt(e.CommandArgument));
                // Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم الحذف بنجاح')</script>");
            }
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('لقد تم الحذف بنجاح');", true);

            Fil_Grid_Visa();
            Fil_Emp_Visa_Follow();
        }
        if (e.CommandName == "SendItem")
         {


            /////////////////////////////////////////////////check if internal outbox then save it inbox table and act the outbox as new inbox in user profile //////////////////////////////////////////////////////////////



            if (CDataConverter.ConvertToInt(ddl_Type.SelectedValue) == 1)
            {

                 commarg = CDataConverter.ConvertToInt(e.CommandArgument);

                var inbb = from inbx in pm_inbox.Inbox_Visa where inbx.Visa_Id == commarg select inbx;
                DataTable dtx = inbb.ToDataTable();
                 in_id = CDataConverter.ConvertToInt( dtx.Rows[0]["Inbox_ID"].ToString());
                 inbx_id  = CDataConverter.ConvertToInt(dtx.Rows[0]["Inbox_ID"].ToString());

                //////////////inbox //////////////////


             //   Save_trackmanager(in_id);

                 Save_trackmanager_ForInbox(in_id);

                ////////////////////////////////////////////////////////////////////////////////////////////
                /////////////////// Sending Mail Code /////////////////////////////////////////
                //////////////////////////////////////////////////////////////////////////////////////////
                string dept = Session_CS.dept.ToString();
                string name = "";
                string Succ_names = "", Failed_name = "";
                DataTable dt_Inbox_Visa = pm_inbox.get_emp_id_from_visa(CDataConverter.ConvertToInt(e.CommandArgument.ToString())).ToDataTable();
                foreach (DataRow item in dt_Inbox_Visa.Rows)
                {
                   // Inbox_DB.update_inbox_Track_Emp(hidden_Id.Value, item["Emp_ID"].ToString(), 1, 1);

               

                    DataTable dt1 = pm_inbox.get_data_from_inbox_track_emp_by_inbox_emp(in_id, CDataConverter.ConvertToInt(item["Emp_ID"].ToString())).ToDataTable();

                    if (dt1.Rows.Count > 0)
                    {



                        var result = pm_inbox.Inbox_Track_Emp.SingleOrDefault(b => b.inbox_id == in_id && b.Emp_ID == CDataConverter.ConvertToInt(item["Emp_ID"].ToString()));
                        if (result != null)
                        {
                            result.Inbox_Status = 2;

                            pm_inbox.SaveChanges();
                        }


                    }
                    else
                    {


                        Inbox_Track_Emp inbemp = new Inbox_Track_Emp();
                        inbemp.inbox_id = in_id;
                        inbemp.Emp_ID = CDataConverter.ConvertToInt(item["Emp_ID"].ToString());
                        inbemp.Inbox_Status = 1;
                        inbemp.Type_Track_emp = 1;
                        pm_inbox.Inbox_Track_Emp.Add(inbemp);
                        pm_inbox.SaveChanges();
                    }
         

                    DataTable dt_emp = pm_inbox.get_mail_pmpname_from_employee_by_parent(CDataConverter.ConvertToInt(item["Emp_ID"].ToString())).ToDataTable();

                    string mail = dt_emp.Rows[0]["mail"].ToString();

                    name = dt_emp.Rows[0]["pmp_name"].ToString();


                    MailMessage _Message = new MailMessage();
                    string str_subj = "";
                    if (txt_Subject.Text.Length > 160)
                    {
                        if (int.Parse(Session_CS.group_id.ToString()) == 3)
                        {
                            str_subj = txt_Subject.Text.Substring(0, 160);
                        }
                        else
                            str_subj = txt_Subject.Text.Substring(0, 130);


                    }
                    else
                    {
                        str_subj = txt_Subject.Text;
                    }


                    string str_witoutn = str_subj.Replace("\n", "");
                    str_subj = str_witoutn.Replace("\r", "");

                    if (int.Parse(Session_CS.group_id.ToString()) == 3)
                    {

                        _Message.Subject = ("INIR" + " - " + str_subj + " - " + txt_Date.Text).ToString();
                    }
                    else
                    {

                        _Message.Subject = "نظام الادارة الالكترونية - المراسلات" + " - " + str_subj + " - " + txt_Date.Text;
                    }

                    _Message.BodyEncoding = Encoding.UTF8;
                    _Message.SubjectEncoding = Encoding.UTF8;
                    bool flag = false;
                    string file = "";
                    byte[] files = new byte[0];
                    MemoryStream ms = new MemoryStream();


                    DataTable dt = pm_inbox.get_attachment_for_mail_visa_tab(in_id).ToDataTable();

                    foreach (DataRow dr in dt.Rows)
                    {

                        if (dr["File_data"] != DBNull.Value)
                        {

                            file = dr["File_name"].ToString() + dr["File_ext"].ToString();
                            files = (byte[])dr["File_data"];
                            ms = new MemoryStream(files);
                            _Message.Attachments.Add(new Attachment(ms, file));
                            flag = true;

                        }
                    }

             
                    String encrypted_id = Encryption.Encrypt(in_id.ToString());
                    string address2 = System.Web.HttpContext.Current.Request.Url.Authority.ToString();
                    _Message.IsBodyHtml = true;
                    _Message.Body = "<html><body dir='rtl'><h3 > السيد - " + name + " </h3>";
                    _Message.Body += " <h3 > " + " وصلكم وارد من " + dept + " بتاريخ " + txt_Visa_date.Text + " بخصوص  <br/>" + "<h3 style=" + "color:blue >" + txt_Subject.Text + "</h3>" + " </h3>";
                    _Message.Body += " <h3 > " + "  وتأشيرة  السيد المدير المختص أن :" + "<h3 style=" + "color:blue >" + txt_Visa_Desc.Text + "</h3>" + " </h3>";

                    _Message.Body += " <h3 > ورابط الوارد هو  :<br/>";
                    _Message.Body += " <h3 >http:" + "/" + "/" + address2 + "/MainForm/ViewProjectInbox.aspx?id=" + encrypted_id + "&1=1 </h3>";

                    if (flag)
                        _Message.Body += "<h3 >  " + " ومرفق الوثائق الخاصة بهذا الوارد</h3> ";

                    ////////http://localhost:4665/Projects_Management/WebForms2/ViewProjectInbox.aspx?id=5458


                    _Message.Body += "<h3 > مع تحيات </h3> ";
                    _Message.Body += "</body></html>";

                    /////////////////////// update have visa = 0/////////////////////////////////////////////
                    Update_Have_Visa_inbox(e.CommandArgument.ToString());

                    try
                    {
                  
                        SendingMailthread_class.Sendingmail(_Message, str_subj, _Message.Body, mail, ms, file, encrypted_id, "");
                        Succ_names += name + ",";

                    }
                    catch (Exception ex)
                    {
                        Failed_name += name + ",";
                    }

                }
                string message = Show_Alert(Succ_names, Failed_name, e.CommandArgument.ToString());
                if (!string.IsNullOrEmpty(message))
                {
                    Fil_Grid_Visa();



                    ///////////////  to store that mohammed eid send visa to employee


                    int vis_id = CDataConverter.ConvertToInt(hidden_Follow_ID.Value);

                    Inbox_Visa_Follows obj_follow = new Inbox_Visa_Follows();

                    obj_follow.Follow_ID = CDataConverter.ConvertToInt(hidden_Follow_ID.Value);

                    obj_follow.Inbox_ID = in_id;

                    GridViewRow row = (GridViewRow)((ImageButton)e.CommandSource).NamingContainer;
                    int xx = row.RowIndex;

                    if (row != null)
                    {
                        v_desc = GridView_Visa.Rows[xx].Cells[3].Text;

                        Label download = (Label)row.FindControl("lbl_desc");

                        v_desc = download.Text;


                    }

                    obj_follow.Descrption = message + " ونص التأشيرة:   " + v_desc;

                    string date = CDataConverter.ConvertDateTimeToFormatdmy(CDataConverter.ConvertDateTimeNowRtnDt());
                    obj_follow.Date = date;
                    obj_follow.Entery_Date = date;
                    obj_follow.time_follow = CDataConverter.ConvertTimeNowRtnLongTimeFormat();

                    obj_follow.entery_pmp_id = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());

                    obj_follow.Visa_Emp_id = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());

                    InsertOrUpdate_Inbox_Visa_follows(obj_follow);


                    Fil_Grid_Visa_Follow();



                    GridView_Visa.Rows[xx].Cells[8].Visible = false;
                    GridView_Visa.Rows[xx].Cells[9].Visible = false;
                    GridView_Visa.Rows[xx].Cells[10].Visible = false;

                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('" + message + "');", true);

                }






            }

            else
            {




                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                Save_trackmanager(CDataConverter.ConvertToInt(Outbox_ID.Value));
                ////////////////////////////////////////////////////////////////////////////////////////////
                /////////////////// Sending Mail Code /////////////////////////////////////////
                //////////////////////////////////////////////////////////////////////////////////////////
                string dept = Session_CS.dept.ToString();
                string name = "";
                string Succ_names = "", Failed_name = "";
                int lastindx = 0;
                ////DataTable dt_outbox_Visa = General_Helping.GetDataTable("select * from Outbox_Visa_Emp where Visa_Id =" + e.CommandArgument.ToString());
                using (var outboxContext = new OutboxContext())
                {
                    var OutboxVisaEmps = outboxContext.OutboxVisaEmpSelect(commArgVal);
                    using (var ADContext = new ActiveDirectoryContext())
                    {
                        using (var inboxContext = new InboxContext())
                        {

                            foreach (var OutboxVisaEmp in OutboxVisaEmps)
                            {
                                var empIdVal = CDataConverter.ConvertToInt(OutboxVisaEmp.Emp_ID);
                                update_Outbox_Track_Emp(Outbox_ID.Value, empIdVal, 1, 1);
                                ////string sqlformail = "SELECT * from employee ";
                                ////sqlformail += " where pmp_id= " + item["Emp_ID"].ToString();
                                ////DataTable ds = General_Helping.GetDataTable(sqlformail);
                                EMPLOYEE emp = ADContext.EMPLOYEEs.Where(x => x.PMP_ID == empIdVal).SingleOrDefault();

                                //DataTable DT = General_Helping.GetDataTable(sqlformail);
                                string mail = emp.mail;

                                name = emp.pmp_name;


                                MailMessage _Message = new MailMessage();
                                string str_subj = "";
                                if (txt_Subject.Text.Length > 160)
                                {
                                    if (int.Parse(Session_CS.group_id.ToString()) == 3)
                                    {
                                        str_subj = txt_Subject.Text.Substring(0, 160);
                                    }
                                    else
                                        str_subj = txt_Subject.Text.Substring(0, 130);


                                }
                                else
                                {
                                    str_subj = txt_Subject.Text;
                                }


                                string str_witoutn = str_subj.Replace("\n", "");
                                str_subj = str_witoutn.Replace("\r", "");

                                if (int.Parse(Session_CS.group_id.ToString()) == 3)
                                {

                                    _Message.Subject = ("OUTIR" + " - " + str_subj + " - " + txt_Date.Text).ToString();
                                }
                                else
                                {

                                    _Message.Subject = "نظام الادارة الالكترونية - المراسلات" + " - " + str_subj + " - " + txt_Date.Text;
                                }


                                //_Message.BodyEncoding = Encoding.Unicode;
                                _Message.BodyEncoding = Encoding.UTF8;
                                _Message.SubjectEncoding = Encoding.UTF8;



                                bool flag = false;
                                string file = "";
                                byte[] files = new byte[0];
                                MemoryStream ms = new MemoryStream();
                                ////DataTable dt = General_Helping.GetDataTable("select * from Inbox_OutBox_Files where Inbox_Outbox_ID =" + Outbox_ID.Value + " and Inbox_Or_Outbox =2 ");
                                var hiddVal = CDataConverter.ConvertToInt(Outbox_ID.Value);
                                IEnumerable<Inbox_OutBox_Files> InboxOutBoxFile = inboxContext.Inbox_OutBox_Files.Where(x => x.Inbox_Outbox_ID == hiddVal && x.Inbox_Or_Outbox == 2);

                                ////foreach (DataRow dr in dt.Rows)
                                ////{

                                ////    if (dr["File_data"] != DBNull.Value)
                                ////    {

                                ////        file = dr["File_name"].ToString() + dr["File_ext"].ToString();
                                ////        files = (byte[])dr["File_data"];
                                ////        ms = new MemoryStream(files);
                                ////        _Message.Attachments.Add(new Attachment(ms, file));
                                ////        flag = true;

                                ////    }
                                ////}
                                foreach (Inbox_OutBox_Files inboxoutBoxfile in InboxOutBoxFile)
                                {

                                    if (!Equals(inboxoutBoxfile.File_data, DBNull.Value))
                                    {

                                        file = inboxoutBoxfile.File_name + inboxoutBoxfile.File_ext;
                                        files = inboxoutBoxfile.File_data.ToArray();
                                        ms = new MemoryStream(files);
                                        _Message.Attachments.Add(new Attachment(ms, file));
                                        if (ms.Length > 26214400)
                                        {
                                            //Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('حجم الملفات التابعة لهذا البريد أكبر من المسموح')</script>");

                                            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('حجم الملفات التابعة لهذا البريد أكبر من المسموح ');", true);

                                            return;
                                        }
                                        flag = true;

                                    }
                                }
                                //else
                                //{
                                //    _Message.Body = " السيد " + name + " \n\n";
                                //    _Message.Body += " وصلكم صادر من " + dept + " " + " بتاريخ " + txt_Visa_date.Text;
                                //}
                                String encrypted_id = Encryption.Encrypt(Outbox_ID.Value);
                                string address2 = System.Web.HttpContext.Current.Request.Url.Authority.ToString();
                                _Message.IsBodyHtml = true;
                                _Message.Body = "<html><body dir='rtl'><h3 > السيد - " + name + " </h3>";
                                _Message.Body += " <h3 > " + " وصلكم صادر من " + dept + " بتاريخ " + txt_Date.Text + " بخصوص  <br/>" + "<h3 style=" + "color:blue >" + txt_Subject.Text + "</h3>" + " </h3>";
                                _Message.Body += " <h3 > " + "  وتأشيرة  السيد المدير المختص أن :" + "<h3 style=" + "color:blue >" + txt_Visa_Desc.Text + "</h3>" + " </h3>";

                                _Message.Body += " <h3 > ورابط الوارد هو  :<br/>";
                                _Message.Body += " <h3 >http:" + "/" + "/" + address2 + "/MainForm/ViewProjectOutbox.aspx?id=" + encrypted_id + "&1=1 </h3>";

                                if (flag)
                                    _Message.Body += "<h3 >  " + " ومرفق الوثائق الخاصة بهذا الصادر</h3> ";

                                ////////http://localhost:4665/Projects_Management/WebForms2/ViewProjectInbox.aspx?id=5458


                                _Message.Body += "<h3 > مع تحيات </h3> ";
                                _Message.Body += "<h3 >   " + Session_CS.e_signature.ToString() + "  </h3> ";
                                _Message.Body += "</body></html>";

                                //////





                                /////////////////////// update have visa = 0/////////////////////////////////////////////
                                Update_Have_Visa(e.CommandArgument.ToString());

                                ////SmtpClient config
                                //SmtpClient Client = new SmtpClient();
                                //Client.Port = int.Parse(ConfigurationManager.AppSettings["SMTP_Port"]);
                                //Client.Host = ConfigurationManager.AppSettings["SMTP_Host"];
                                //string UserName = ConfigurationManager.AppSettings["SMTP_UserName"];
                                //string Password = ConfigurationManager.AppSettings["SMTP_Password"];
                                //_Message.From = new MailAddress(ConfigurationManager.AppSettings["SMTP_FromAddress"]);

                                ////_Message.Attachments.Add(new Attachment("D:\\Attached.pdf"));
                                //System.Net.NetworkCredential SMTPUserInfo = new System.Net.NetworkCredential(UserName, Password);

                                //Client.UseDefaultCredentials = false;
                                //Client.Credentials = SMTPUserInfo;
                                //Client.Timeout = 1000000000;
                                try
                                {
                                    //_Message.To.Add(new MailAddress(mail));
                                    //Client.Send(_Message);
                                    SendingMailthread_class.Sendingmail(_Message, _Message.Subject, _Message.Body, mail, ms, file, encrypted_id, "");

                                    Succ_names += name + ",";
                                    lastindx = Succ_names.LastIndexOf(',');

                                }
                                catch (Exception ex)
                                {
                                    Failed_name += name + ",";

                                    //Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لم يتم ارسال الايميل بنجاح' )</script>");

                                }
                            }




                            string Succ_namesresult = Succ_names.Substring(0, lastindx);
                            string message = Show_Alert(Succ_namesresult, Failed_name, e.CommandArgument.ToString());
                            if (!string.IsNullOrEmpty(message))
                            {
                                Fil_Grid_Visa();
                                ///////////////  to store that mohammed eid send visa to employee
                                string date = CDataConverter.ConvertDateTimeToFormatdmy(CDataConverter.ConvertDateTimeNowRtnDt());
                                var hiddFollowId = CDataConverter.ConvertToInt(hidden_Follow_ID.Value);
                                var hiddId = CDataConverter.ConvertToInt(Outbox_ID.Value);
                                Outbox_Visa_Follows OutboxVisaFollow = outboxContext.Outbox_Visa_Follows.Where(x => x.Follow_ID == hiddFollowId).SingleOrDefault();
                                ////Outbox_Visa_Follows_DT obj_follow = Outbox_Visa_Follows_DB.SelectByID(CDataConverter.ConvertToInt(hidden_Follow_ID.Value));
                                if (OutboxVisaFollow != null)
                                {
                                    OutboxVisaFollow.Follow_ID = hiddFollowId;
                                    OutboxVisaFollow.Outbox_ID = hiddId;

                                    OutboxVisaFollow.Descrption = message + " بواسطة النظام -- ";
                                    OutboxVisaFollow.Date = date;
                                    OutboxVisaFollow.time_follow = CDataConverter.ConvertTimeNowRtnLongTimeFormat();
                                    OutboxVisaFollow.entery_pmp_id = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());

                                    OutboxVisaFollow.Visa_Emp_id = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());

                                }
                                else
                                {
                                    Outbox_Visa_Follows OutboxVisaFollowNew = new Outbox_Visa_Follows
                                    {
                                        Outbox_ID = CDataConverter.ConvertToInt(Outbox_ID.Value),
                                        Descrption = message + " بواسطة النظام -- ",
                                        Date = date,
                                        time_follow = CDataConverter.ConvertDateTimeNowRtnDt().ToLocalTime().ToLongTimeString(),
                                        entery_pmp_id = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()),
                                        Visa_Emp_id = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString())
                                    };
                                    outboxContext.Outbox_Visa_Follows.Add(OutboxVisaFollowNew);
                                }
                                outboxContext.SaveChanges();
                                ////obj_follow.Follow_ID = Outbox_Visa_Follows_DB.Save(obj_follow);
                                Fil_Grid_Visa_Follow();

                                //SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                                //DataTable DT = new DataTable();
                                //DT = General_Helping.GetDataTable("select * from Inbox_Track_Manager where inbox_id = " + Outbox_ID.Value);
                                //if (DT.Rows.Count > 0)
                                //{
                                //    conn.Open();
                                //    string sql = "update Inbox_Track_Manager set Have_Follow=0,All_visa_sent=0,Have_Visa=1,IS_Old_Mail=0,IS_New_Mail=0 where inbox_id =" + Outbox_ID.Value;
                                //    SqlCommand cmd = new SqlCommand(sql, conn);
                                //    cmd.ExecuteNonQuery();
                                //    conn.Close();

                                //}
                                //   Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('" + message + "')</script>");

                                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('" + message + "');", true);

                            }
                            //Page.RegisterStartupScript("Sucess", "<script language=javascript>alert(' لقد تم ارسال الايميل بنجاح إلي " +allnames+"')</script>");
                        }
                    }
                }

            }
        }
    }





    private void Update_Have_Visa_inbox(string Visa_Id)
    {
      //  DataTable dt_mail_sent = SqlHelper.ExecuteDataset(Database.ConnectionString, "get_mail_sent_from_visa", Visa_Id, CDataConverter.ConvertToInt(hidden_Id.Value)).Tables[0];

        DataTable dt_mail_sent = pm_inbox.get_mail_sent_from_visa(CDataConverter.ConvertToInt(Visa_Id), in_id ).ToDataTable();

        int Visa_Sent_Count = dt_mail_sent.Rows.Count;
        if (Visa_Sent_Count == GridView_Visa.Rows.Count - 1)
        {

         //   DataTable DT = SqlHelper.ExecuteDataset(Database.ConnectionString, "get_data_from_inbox_track_manager", CDataConverter.ConvertToInt(hidden_Id.Value)).Tables[0];

            DataTable DT = pm_inbox.get_data_from_inbox_track_manager(in_id).ToDataTable();

            if (DT.Rows.Count > 0)
            {
               // string sql = "update Inbox_Track_Manager set Have_visa=0 , All_visa_sent=1 where inbox_id =" + hidden_Id.Value;

               // General_Helping.ExcuteQuery(sql);

                pm_inbox.Inbox_Track_Managerupdate(in_id);
            }
        }

    }

    protected void Chk_main_cat_SelectedIndexChanged(object sender, EventArgs e)
    {
        Chk_sub_cat.Visible = true;
        Chk_sub_cat.Items.Clear();
        ListItem obj;
        using (var inboxContext = new InboxContext()) { 
        foreach (ListItem item in Chk_main_cat.Items)
        {
            var itemVal=CDataConverter.ConvertToInt(item.Value);
            var subInboxCat = from InboxCat in inboxContext.inbox_sub_categories
                              where InboxCat.main_id == itemVal
                              select InboxCat;
            if (item.Selected)
            {

                foreach (var drs in subInboxCat)
                {
                    obj = new ListItem(drs.name, drs.id.ToString());
                    //lst_emp.Items.Add(obj);
                    if (Chk_sub_cat.Items.FindByValue(obj.Value) == null)
                    {
                        Chk_sub_cat.Items.Add(obj);
                    }
                }
                //// dt = General_Helping.GetDataTable(" select * from inbox_Sub_Categories where main_id = " + item.Value);

                ////for (int i = 0; i < dt.Rows.Count; i++)
                ////{
                ////    obj = new ListItem(dt.Rows[i]["name"].ToString(), dt.Rows[i]["id"].ToString());
                ////    //lst_emp.Items.Add(obj);
                ////    if (Chk_sub_cat.Items.FindByValue(obj.Value) == null)
                ////    {
                ////        Chk_sub_cat.Items.Add(obj);
                ////    }


                ////}
            }
            else
            {
                foreach (var drs in subInboxCat)
                {
                    obj = new ListItem(drs.name, drs.id.ToString());
                    //lst_emp.Items.Add(obj);


                    Chk_sub_cat.Items.Remove(obj);
                }
                ////dt = General_Helping.GetDataTable(" select * from inbox_Sub_Categories where main_id = " + item.Value);

                ////for (int i = 0; i < dt.Rows.Count; i++)
                ////{
                ////    obj = new ListItem(dt.Rows[i]["name"].ToString(), dt.Rows[i]["id"].ToString());
                ////    //lst_emp.Items.Add(obj);


                ////    Chk_sub_cat.Items.Remove(obj);



                ////}
            }

            //item.Selected = Chk_ALL_cat.Checked;
        }

        TabPanel_All.ActiveTab = TabPanel_dtl;
        }
    }
    protected void btn_Doc_Click(object sender, EventArgs e)
    {
        ////SqlCommand cmd = new SqlCommand();
        ////SqlConnection con = new SqlConnection();
        ////SqlCommand cmd_local = new SqlCommand();
        ////SqlConnection con_local = new SqlConnection();
        ////con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        ////con_local = new SqlConnection(Session_CS.local_connectionstring);
        ////int out_box = 0;
        if (CDataConverter.ConvertToInt(Outbox_ID.Value) > 0)
        {
            if (FileUpload1.HasFile)
            {
                using (var inboxContext = new InboxContext())
                {
                    string DocName = FileUpload1.FileName;
                    int dotindex = DocName.LastIndexOf(".");
                    string type = DocName.Substring(dotindex, DocName.Length - dotindex);

                    Stream myStream;
                    int fileLen;
                    StringBuilder displayString = new StringBuilder();
                    fileLen = FileUpload1.PostedFile.ContentLength;
                    Byte[] Input = new Byte[fileLen];
                    myStream = FileUpload1.FileContent;
                    myStream.Read(Input, 0, fileLen);


                    ////cmd.Parameters.Add("@Inbox_Or_Outbox", SqlDbType.Int);
                    ////cmd.Parameters.Add("@Inbox_Outbox_ID", SqlDbType.Int);
                    ////cmd.Parameters.Add("@Inbox_OutBox_File_ID", SqlDbType.Int);
                    ////cmd.Parameters.Add("@Original_Or_Attached", SqlDbType.Int);
                    ////cmd.Parameters.Add("@File_name", SqlDbType.NVarChar);
                    ////cmd.Parameters.Add("@File_ext", SqlDbType.NVarChar);
                    ////cmd.Parameters.Add("@File_data", SqlDbType.VarBinary);
                    ////cmd.Parameters["@Inbox_OutBox_File_ID"].Value = CDataConverter.ConvertToInt(hidden_Inbox_OutBox_File_ID.Value);
                    ////cmd.Parameters["@Original_Or_Attached"].Value = CDataConverter.ConvertToInt(ddl_Original_Or_Attached.SelectedValue);
                    ////cmd.Parameters["@File_ext"].Value = type;
                    ////cmd.Parameters["@File_name"].Value = txtFileName.Text;
                    ////cmd.Parameters["@Inbox_Or_Outbox"].Value = 2;

                    ////cmd.CommandType = CommandType.Text;



                    if (CDataConverter.ConvertToInt(hidden_Inbox_OutBox_File_ID.Value) > 0)
                    {
                        var hiddInboxOutboxVal=CDataConverter.ConvertToInt(hidden_Inbox_OutBox_File_ID.Value);
                        Inbox_OutBox_Files InboxOutBoxFile = inboxContext.Inbox_OutBox_Files.Where(x => x.Inbox_OutBox_File_ID == hiddInboxOutboxVal).SingleOrDefault();

                        InboxOutBoxFile.Original_Or_Attached = CDataConverter.ConvertToInt(ddl_Original_Or_Attached.SelectedValue);
                        InboxOutBoxFile.File_ext = type;
                        InboxOutBoxFile.File_name = txtFileName.Text;
                        InboxOutBoxFile.Inbox_Or_Outbox = 2;
                        InboxOutBoxFile.File_data = Input;

                        ////cmd.CommandText = " update Inbox_OutBox_Files set Original_Or_Attached=@Original_Or_Attached ,File_data=@File_data ,File_name=@File_name,File_ext=@File_ext where Inbox_OutBox_File_ID =@Inbox_OutBox_File_ID";


                        ////if (string.IsNullOrEmpty(Session_CS.local_connectionstring))
                        ////{
                        ////    cmd.Connection = con;
                        ////    cmd.Parameters["@File_data"].Value = Input;
                        ////    con.Open();
                        ////    cmd.ExecuteScalar();
                        ////    con.Close();

                        ////}
                        ////else
                        ////{

                        ////    cmd.Connection = con;
                        ////    cmd.Parameters["@File_data"].Value = DBNull.Value;
                        ////    con.Open();
                        ////    cmd.ExecuteScalar();
                        ////    con.Close();
                        ////    try
                        ////    {
                        ////        cmd.Connection = con_local;
                        ////        cmd.Parameters["@File_data"].Value = Input;

                        ////        con_local.Open();
                        ////        cmd.ExecuteScalar();
                        ////        con_local.Close();


                        ////    }
                        ////    catch
                        ////    {
                        ////        // can't connect to sql local, we should show message here
                        ////        // ShowAlertMessage(" عفوا لم يتم الإتصال بقاعدة البيانات الداخلية");

                        ////        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('عفوا لم يتم الإتصال بقاعدة البيانات الداخلية');", true);

                        ////    }
                        ////}


                    }

                    else
                    {
                        // cmd.CommandText = " insert into Inbox_OutBox_Files ( Inbox_Outbox_ID, Inbox_Or_Outbox, Original_Or_Attached, File_data,File_name, File_ext) VALUES ( @Inbox_Outbox_ID, @Inbox_Or_Outbox, @Original_Or_Attached, @File_data, @File_name, @File_ext) select @@identity";
                        Inbox_OutBox_Files InboxOutBoxFile = new Inbox_OutBox_Files
                        {
                            Inbox_Outbox_ID = CDataConverter.ConvertToInt(Outbox_ID.Value),
                            Original_Or_Attached = CDataConverter.ConvertToInt(ddl_Original_Or_Attached.SelectedValue),
                            File_ext = type,
                            File_name = txtFileName.Text,
                            Inbox_Or_Outbox = 2,
                            File_data = Input
                        };
                        inboxContext.Inbox_OutBox_Files.Add(InboxOutBoxFile);


                    }
                    inboxContext.SaveChanges();
                    txtFileName.Text = hidden_Inbox_OutBox_File_ID.Value = "";
                }

            }

            // Clear_Cntrl();
            Fil_Grid_Documents();
        }
        else
        {
            //Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('يجب إدخال بيانات الخطاب أولا')</script>");

            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('يجب إدخال بيانات الخطاب أولا');", true);


        }

    }

    private bool check_Send_mng()
    {
        //bool flag = false;
        string InsideMCIT = System.Configuration.ConfigurationManager.AppSettings["InsideMCIT"].ToString();
        if (InsideMCIT == "1" && Session_CS.pmp_id == 47)
        {
            return true;
        }


        // DataTable dt_mng_sent = SqlHelper.ExecuteDataset(Database.ConnectionString, "get_data_from_inbox_track_manager", CDataConverter.ConvertToInt(hidden_Id.Value)).Tables[0];

        DataTable dt_mng_sent = pm_inbox.get_data_from_inbox_track_manager(CDataConverter.ConvertToInt(hidden_Id.Value)).ToDataTable();



        // DataTable dt_emp_hasparent = SqlHelper.ExecuteDataset(Database.ConnectionString, "get_data_from_parent_employee", Session_CS.pmp_id).Tables[0];

        DataTable dt_emp_hasparent = pm_inbox.get_data_from_parent_employee(Session_CS.pmp_id).ToDataTable();

        if (dt_mng_sent.Rows.Count <= 0 && dt_emp_hasparent.Rows.Count <= 0)
        {
            return true;
        }
        else if (dt_mng_sent.Rows.Count > 0)
        {

            return true;
        }
        else
        {

            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('يجب إرسال الخطاب للمدير المختص أولا ');", true);

            return false;
        }





    }

    public int  InsertOrUpdate_Inbox_Visa(Inbox_Visa blog)
    {


        using (var context = new InboxContext())
        {

            context.Entry(blog).State = blog.Visa_Id == 0 ?
                                      System.Data.Entity.EntityState.Added :
                                      System.Data.Entity.EntityState.Modified;

            context.SaveChanges();
            return blog.Visa_Id;

        }
    }

    private void Save_inox_Visa(Inbox_Visa obj)
    {

   

        pm_inbox.Inbox_Visa_Emp.RemoveRange(pm_inbox.Inbox_Visa_Emp.Where(x => x.Visa_Id == obj.Visa_Id));
        pm_inbox.SaveChanges();


        foreach (ListItem item in lst_emp.Items)
        {


            DataTable dt = pm_inbox.get_data_from_parent_employee(Session_CS.pmp_id).ToDataTable();

            if (dt.Rows.Count > 0)
            {


                pm_inbox.inbox_visa_emp_save(CDataConverter.ConvertToInt(obj.Visa_Id), CDataConverter.ConvertToInt(item.Value), CDataConverter.ConvertToInt(dt.Rows[0]["parent_pmp_id"].ToString()));
            }
            else
            {


                pm_inbox.inbox_visa_emp_save(CDataConverter.ConvertToInt(obj.Visa_Id), CDataConverter.ConvertToInt(item.Value), CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()));
            }

        }


     }

    public int InsertOrUpdate_Outbox (Outbox  blog)
    {


        using (var context = new OutboxContext())
        {

            context.Entry(blog).State = blog.ID == 0 ?
                                      System.Data.Entity.EntityState.Added :
                                      System.Data.Entity.EntityState.Modified;

            context.SaveChanges();
            return blog.ID;
        }
    }


    protected void btn_Visa_Click(object sender, EventArgs e)
    {
        if (CDataConverter.ConvertToInt(ddl_Type.SelectedValue) == 1)
        {


            ////////////////////////////////////  add row in inbox table /////////////////


            if (Session_CS.code_outbox == 1)
            {
                int session_found = Session_CS.foundation_id;

                DataTable getmax = null;

                getmax = pm_inbox.get_max_code_inbox(Session_CS.foundation_id).ToDataTable();



                txt_Code.Text = getmax.Rows[0]["code"].ToString();
            }


            string datenow = "";
            int dept_id = 0;
            int Org_Id = 0;
            datenow = CDataConverter.ConvertDateTimeNowRtnDt().ToString();
            if (CDataConverter.ConvertToInt(ddl_Type.SelectedValue) == 1)
            {
                if (CDataConverter.ConvertToInt(Smrt_Srch_structure2.SelectedValue) > 0)
                {
                    dept_id = CDataConverter.ConvertToInt(Smrt_Srch_structure2.SelectedValue);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('يجب إختيار الإدارة ');", true);
                    return;
                }
            }
            else
            {
                Org_Id = CDataConverter.ConvertToInt(Smart_Org_ID.SelectedValue /*OrgID.Value*/);
            }
            using (var context = new InboxContext())
            {
                if (CDataConverter.ConvertToInt(Outbox_ID.Value) > 0)
                {

                    Inbox inboxObj = new Inbox();

                    inboxObj.Proj_id = int.Parse(Session_CS.Project_id.ToString());
                    inboxObj.Name = txt_Name.Text;
                    inboxObj.Code = txt_Code.Text;
                    inboxObj.Date = txt_Date.Text;
                    inboxObj.Enter_Date = datenow;
                    inboxObj.Dept_Dept_ID = int.Parse(Session_CS.dept_id.ToString());
                    inboxObj.pmp_pmp_id = int.Parse(Session_CS.pmp_id.ToString());
                    inboxObj.Group_id = int.Parse(Session_CS.group_id.ToString());
                    inboxObj.Type = CDataConverter.ConvertToInt(ddl_Type.SelectedValue);
                    inboxObj.Dept_ID = dept_id;
                    inboxObj.Org_Id = Org_Id;
                    inboxObj.Emp_ID = CDataConverter.ConvertToInt(Smart_Emp_ID.SelectedValue);
                    inboxObj.Org_Out_Box_Code = txt_Org_Out_Box_Code.Text;
                    inboxObj.Org_Out_Box_DT = txt_Org_Out_Box_DT.Text;
                    inboxObj.Org_Out_Box_Person = txt_Org_Out_Box_Person.Text;
                    inboxObj.Subject = txt_Subject.Text;
                   // inboxObj.Related_Type = CDataConverter.ConvertToInt(ddl_Related_Type.SelectedValue);
                     inboxObj.Related_Type = 6;
                    inboxObj.Related_Id = CDataConverter.ConvertToInt(Outbox_ID.Value);
                    inboxObj.Notes = txt_Notes.Text;
                    inboxObj.Paper_No = txt_Paper_No.Text;
                    inboxObj.Paper_Attached = txt_Paper_Attached.Text;
                    inboxObj.Follow_Up_Dept_ID = 0;
                    inboxObj.Follow_Up_Emp_ID = 0;
                    inboxObj.Dept_Desc = txt_Dept_Desc.Text;
                    inboxObj.Source_Type = CDataConverter.ConvertToInt(ddl_Source_Type.SelectedValue);
                    inboxObj.Status = 0;
                    inboxObj.finished = 0;
                    inboxObj.Org_Dept_Name = txt_Org_Dept_Name.Text;
                    inboxObj.foundation_id = CDataConverter.ConvertToInt(Session_CS.foundation_id.ToString());

                    //   context.Inboxes.Add(inboxObj);
                    // context.SaveChanges();
                    inbx_id = InsertOrUpdate_Inbox(inboxObj);


                    ////////////////////////////////update outbox status to 6 ///////////////////////////////////
                    //int idd;
                    //Outbox outbx = new Outbox();
                    //outbx.ID = CDataConverter.ConvertToInt(Outbox_ID.Value);
                    //outbx.Related_Type = 6;
                    //outbx.Related_Id = inbx_id;

                    //idd = InsertOrUpdate_Outbox(outbx);

                    pm_outbox.update_outbox_relatedtype(CDataConverter.ConvertToInt(Outbox_ID.Value), 6, inbx_id);


                    //////////////////////////////////////////update outbox related type to 6   وارد لصادر داخلي  /////////////////////////////////////////////////





                    ////////////////////////////////////////////////////////////////////////////////////////

                }
            }


            /////////////////////////////////////save inbox_visa table//////////////////////////////////////////////


            string today = CDataConverter.ConvertDateTimeNowRtrnString();//VB_Classes.Dates.Dates_Operation.date_validate(CDataConverter.ConvertDateTimeNowRtnDt().ToShortDateString().ToString());
          
                if (lst_emp.Items.Count > 0)
                {
                    DateTime visainitial = CDataConverter.ConvertToDate(txt_Visa_date.Text);

                    DateTime visalastdate = CDataConverter.ConvertToDate(txt_Dead_Line_DT.Text);
                    if (visalastdate >= visainitial)
                    {


                        Inbox_Visa obj = new Inbox_Visa();
                        obj.Visa_Id = CDataConverter.ConvertToInt(hidden_Visa_Id.Value);
                        obj.Inbox_ID = inbx_id;
                        obj.Visa_date = txt_Visa_date.Text;
                        obj.Important_Degree = CDataConverter.ConvertToInt(ddl_Important_Degree.SelectedValue);
                        obj.Important_Degree_Txt = txt_Important_Degree_Txt.Text;
                        if (string.IsNullOrEmpty(obj.Important_Degree_Txt))
                            obj.Important_Degree_Txt = ddl_Important_Degree.SelectedItem.Text;

                        obj.Dept_ID = CDataConverter.ConvertToInt(Smrt_Srch_structure.SelectedValue);
                        obj.Dept_ID_Txt = txt_Dept_ID_Txt.Text;
                        if (string.IsNullOrEmpty(obj.Dept_ID_Txt))
                            obj.Dept_ID_Txt = Smrt_Srch_structure.SelectedText;

                        obj.Emp_ID = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
                        obj.Emp_ID_Txt = txt_Emp_ID_Txt.Text;
                        //if (string.IsNullOrEmpty(obj.Emp_ID_Txt))
                        //    obj.Emp_ID_Txt = Smart_Visa_Emp.SelectedText;

                        obj.Visa_Desc = txt_Visa_Desc.Text;
                        obj.Visa_Period = txt_Visa_Period.Text;
                        obj.Visa_Satus = CDataConverter.ConvertToInt(ddl_Visa_Satus.SelectedValue);

                        obj.Follow_Up_Notes = txt_Follow_Up_Notes.Text;
                        obj.saving_file = txt_saving_file.Text;
                        obj.Dead_Line_DT = txt_Dead_Line_DT.Text;
                        obj.Visa_Goal_ID = CDataConverter.ConvertToInt(ddl_Visa_Goal_ID.SelectedValue);
                        obj.mail_sent = 0;


                        if (FileUpload_Visa.HasFile)
                        {
                            string DocName = FileUpload_Visa.FileName;
                            int dotindex = DocName.LastIndexOf(".");
                            string type = DocName.Substring(dotindex, DocName.Length - dotindex);
                            string Doc_Name = System.IO.Path.GetFileNameWithoutExtension(FileUpload_Visa.FileName);
                            Stream myStream;
                            int fileLen;
                            StringBuilder displayString = new StringBuilder();
                            fileLen = FileUpload_Visa.PostedFile.ContentLength;
                            Byte[] Input = new Byte[fileLen];
                            myStream = FileUpload_Visa.FileContent;
                            myStream.Read(Input, 0, fileLen);
                            obj.File_data = Input;
                            obj.File_name = Doc_Name;
                            obj.File_ext = type;



                        }

                        InsertOrUpdate_Inbox_Visa(obj);

                        Save_inox_Visa(obj);
                        Clear_Visa_Cntrl();
                        Fil_Grid_Visa();
                        // fil_emp_Folow_Up();
                        Fil_Emp_Visa_Follow();
                        ///////////////////////// update have visa = 1/////////////////////////////////////////////

                        Update_Have_Visa_all_emp(CDataConverter.ConvertToInt(obj.Inbox_ID));

                        lst_emp.Items.Clear();
                     }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('أخر تاريخ يجب ان يكون اكبر من تاريخ التأشيره');", true);

                    }

                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('لا يوجد أسماء في القائمة اليسري');", true);

                }





        

        }
        else
        {

            using (var outboxContext = new OutboxContext())
            {
                var HiddVal = CDataConverter.ConvertToInt(Outbox_ID.Value);
                var OutboxTrackManagerDT = outboxContext.Outbox_Track_Manager.Where(x => x.Outbox_id == HiddVal);
                if (OutboxTrackManagerDT.Count() > 0)
                {
                    if (CDataConverter.ConvertToInt(Outbox_ID.Value) > 0)
                    {
                        if (lst_emp.Items.Count > 0)
                        {
                            DateTime visainitial = CDataConverter.ConvertToDate(txt_Visa_date.Text);

                            //DateTime visalastdate = DateTime.ParseExact(txt_Dead_Line_DT.Text, "dd/MM/yyyy", null);
                            DateTime visalastdate = CDataConverter.ConvertToDate(txt_Dead_Line_DT.Text);
                            if (visalastdate >= visainitial)
                            {

                                if (CDataConverter.ConvertToInt(hidden_Visa_Id.Value) > 0)
                                {
                                    int idd = CDataConverter.ConvertToInt(hidden_Visa_Id.Value);

                                    Outbox_Visa OutboxVisaObj = outboxContext.Outbox_Visa.SingleOrDefault(x => x.Visa_Id == idd);
                                    OutboxVisaObj.Outbox_ID = CDataConverter.ConvertToInt(Outbox_ID.Value);
                                    OutboxVisaObj.Visa_date = txt_Visa_date.Text;
                                    OutboxVisaObj.Important_Degree = CDataConverter.ConvertToInt(ddl_Important_Degree.SelectedValue);
                                    OutboxVisaObj.Important_Degree_Txt = (string.IsNullOrEmpty(txt_Important_Degree_Txt.Text) ? ddl_Important_Degree.SelectedItem.Text : txt_Important_Degree_Txt.Text);
                                    OutboxVisaObj.Dept_ID = CDataConverter.ConvertToInt(Smrt_Srch_structure.SelectedValue);
                                    OutboxVisaObj.Dept_ID_Txt = Smrt_Srch_structure.SelectedText;
                                    OutboxVisaObj.Emp_ID = CDataConverter.ConvertToInt(Session_CS.pmp_id);
                                    OutboxVisaObj.Emp_ID_Txt = txt_Emp_ID_Txt.Text;
                                    OutboxVisaObj.Visa_Desc = txt_Visa_Desc.Text;
                                    OutboxVisaObj.Visa_Period = txt_Visa_Period.Text;
                                    OutboxVisaObj.Visa_Satus = CDataConverter.ConvertToInt(ddl_Visa_Satus.SelectedValue);
                                    OutboxVisaObj.Follow_Up_Notes = txt_Follow_Up_Notes.Text;
                                    OutboxVisaObj.saving_file = txt_saving_file.Text;
                                    OutboxVisaObj.Dead_Line_DT = txt_Dead_Line_DT.Text;
                                    OutboxVisaObj.Visa_Goal_ID = CDataConverter.ConvertToInt(ddl_Visa_Goal_ID.SelectedValue);
                                    OutboxVisaObj.mail_sent = 0;

                                    if (FileUpload_Visa.HasFile)
                                    {
                                        string DocName = FileUpload_Visa.FileName;
                                        int dotindex = DocName.LastIndexOf(".");
                                        string type = DocName.Substring(dotindex, DocName.Length - dotindex);

                                        Stream myStream;
                                        int fileLen;
                                        StringBuilder displayString = new StringBuilder();
                                        fileLen = FileUpload_Visa.PostedFile.ContentLength;
                                        Byte[] Input = new Byte[fileLen];
                                        myStream = FileUpload_Visa.FileContent;
                                        myStream.Read(Input, 0, fileLen);


                                        OutboxVisaObj.File_name = DocName;
                                        OutboxVisaObj.File_ext = type;

                                        if (string.IsNullOrEmpty(Session_CS.local_connectionstring))
                                        {
                                            OutboxVisaObj.File_data = Input;
                                            //cmd.Connection = con;
                                            //cmd.Parameters["@File_data"].Value = Input;
                                            //con.Open();
                                            //cmd.ExecuteScalar();
                                            //con.Close();

                                        }
                                        else
                                        {

                                            //cmd.Connection = con;
                                            //cmd.Parameters["@File_data"].Value = DBNull.Value;
                                            //con.Open();
                                            //cmd.ExecuteScalar();
                                            //con.Close();
                                            try
                                            {
                                                SqlCommand cmd = new SqlCommand();
                                                SqlConnection con = new SqlConnection();
                                                SqlCommand cmd_local = new SqlCommand();
                                                SqlConnection con_local = new SqlConnection();
                                                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                                                con_local = new SqlConnection(Session_CS.local_connectionstring);
                                                cmd.Parameters.Add("@File_data", SqlDbType.VarBinary);
                                                cmd.Parameters.Add("@File_name", SqlDbType.NVarChar);
                                                cmd.Parameters.Add("@File_ext", SqlDbType.NVarChar);
                                                cmd.Parameters.Add("@visa_ID", SqlDbType.BigInt);

                                                //cmd.Parameters["@File_data"].Value = Input;
                                                cmd.Parameters["@File_name"].Value = DocName;
                                                cmd.Parameters["@File_ext"].Value = type;
                                                cmd.Parameters["@visa_ID"].Value = OutboxVisaObj.Visa_Id;
                                                cmd.CommandType = CommandType.Text;
                                                cmd.CommandText = " update Outbox_Visa set File_data =@File_data ,File_name=@File_name,File_ext=@File_ext where visa_ID =@visa_ID";

                                                cmd.Connection = con_local;
                                                cmd.Parameters["@File_data"].Value = Input;

                                                con_local.Open();
                                                cmd.ExecuteScalar();
                                                con_local.Close();


                                            }
                                            catch
                                            {
                                                // can't connect to sql local, we should show message here


                                                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('عفوا لم يتم الإتصال بقاعدة البيانات الداخلية');", true);

                                            }
                                        }



                                    }
                                    outboxContext.SaveChanges();
                                    Save_inox_Visa(CDataConverter.ConvertToInt(hidden_Visa_Id.Value));

                                }
                                else
                                {
                                    Outbox_Visa OutboxVisa = new Outbox_Visa
                                    {
                                        Visa_Id = CDataConverter.ConvertToInt(hidden_Visa_Id.Value),
                                        Outbox_ID = CDataConverter.ConvertToInt(Outbox_ID.Value),
                                        Visa_date = txt_Visa_date.Text,
                                        Important_Degree = CDataConverter.ConvertToInt(ddl_Important_Degree.SelectedValue),
                                        Important_Degree_Txt = (string.IsNullOrEmpty(txt_Important_Degree_Txt.Text) ? ddl_Important_Degree.SelectedItem.Text : txt_Important_Degree_Txt.Text),
                                        Dept_ID = CDataConverter.ConvertToInt(Smrt_Srch_structure.SelectedValue),
                                        Dept_ID_Txt = Smrt_Srch_structure.SelectedText,
                                        Emp_ID = CDataConverter.ConvertToInt(Session_CS.pmp_id),
                                        Emp_ID_Txt = txt_Emp_ID_Txt.Text,
                                        Visa_Desc = txt_Visa_Desc.Text,
                                        Visa_Period = txt_Visa_Period.Text,
                                        Visa_Satus = CDataConverter.ConvertToInt(ddl_Visa_Satus.SelectedValue),
                                        Follow_Up_Notes = txt_Follow_Up_Notes.Text,
                                        saving_file = txt_saving_file.Text,
                                        Dead_Line_DT = txt_Dead_Line_DT.Text,
                                        Visa_Goal_ID = CDataConverter.ConvertToInt(ddl_Visa_Goal_ID.SelectedValue),
                                        mail_sent = 0
                                    };


                                    if (FileUpload_Visa.HasFile)
                                    {
                                        string DocName = FileUpload_Visa.FileName;
                                        int dotindex = DocName.LastIndexOf(".");
                                        string type = DocName.Substring(dotindex, DocName.Length - dotindex);

                                        Stream myStream;
                                        int fileLen;
                                        StringBuilder displayString = new StringBuilder();
                                        fileLen = FileUpload_Visa.PostedFile.ContentLength;
                                        Byte[] Input = new Byte[fileLen];
                                        myStream = FileUpload_Visa.FileContent;
                                        myStream.Read(Input, 0, fileLen);
                                        OutboxVisa.File_name = DocName;
                                        OutboxVisa.File_ext = type;


                                        if (string.IsNullOrEmpty(Session_CS.local_connectionstring))
                                        {
                                            OutboxVisa.File_data = Input;
                                            //cmd.Connection = con;
                                            //cmd.Parameters["@File_data"].Value = Input;
                                            //con.Open();
                                            //cmd.ExecuteScalar();
                                            //con.Close();

                                        }
                                        else
                                        {

                                            //cmd.Connection = con;
                                            //cmd.Parameters["@File_data"].Value = DBNull.Value;
                                            //con.Open();
                                            //cmd.ExecuteScalar();
                                            //con.Close();
                                            try
                                            {
                                                SqlCommand cmd = new SqlCommand();
                                                SqlConnection con = new SqlConnection();
                                                SqlCommand cmd_local = new SqlCommand();
                                                SqlConnection con_local = new SqlConnection();
                                                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                                                con_local = new SqlConnection(Session_CS.local_connectionstring);
                                                cmd.Parameters.Add("@File_data", SqlDbType.VarBinary);
                                                cmd.Parameters.Add("@File_name", SqlDbType.NVarChar);
                                                cmd.Parameters.Add("@File_ext", SqlDbType.NVarChar);
                                                cmd.Parameters.Add("@visa_ID", SqlDbType.BigInt);

                                                //cmd.Parameters["@File_data"].Value = Input;
                                                cmd.Parameters["@File_name"].Value = DocName;
                                                cmd.Parameters["@File_ext"].Value = type;
                                                cmd.Parameters["@visa_ID"].Value = OutboxVisa.Visa_Id;
                                                cmd.CommandType = CommandType.Text;
                                                cmd.CommandText = " update Outbox_Visa set File_data =@File_data ,File_name=@File_name,File_ext=@File_ext where visa_ID =@visa_ID";

                                                cmd.Connection = con_local;
                                                cmd.Parameters["@File_data"].Value = Input;

                                                con_local.Open();
                                                cmd.ExecuteScalar();
                                                con_local.Close();


                                            }
                                            catch
                                            {
                                                // can't connect to sql local, we should show message here


                                                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('عفوا لم يتم الإتصال بقاعدة البيانات الداخلية');", true);

                                            }
                                        }



                                    }
                                    outboxContext.Outbox_Visa.Add(OutboxVisa);
                                    outboxContext.SaveChanges();
                                    hidden_Visa_Id.Value = OutboxVisa.Visa_Id.ToString();
                                    Save_inox_Visa(CDataConverter.ConvertToInt(hidden_Visa_Id.Value));
                                }
                                ////Outbox_Visa_DT obj = new Outbox_Visa_DT();
                                ////obj.Visa_Id = CDataConverter.ConvertToInt(hidden_Visa_Id.Value);
                                ////obj.Outbox_ID = CDataConverter.ConvertToInt(Outbox_ID.Value);
                                ////obj.Visa_date = txt_Visa_date.Text;
                                ////obj.Important_Degree = CDataConverter.ConvertToInt(ddl_Important_Degree.SelectedValue);
                                ////obj.Important_Degree_Txt = txt_Important_Degree_Txt.Text;
                                ////if (string.IsNullOrEmpty(obj.Important_Degree_Txt))
                                ////    obj.Important_Degree_Txt = ddl_Important_Degree.SelectedItem.Text;

                                ////obj.Dept_ID = CDataConverter.ConvertToInt(Smrt_Srch_structure.SelectedValue);
                                ////obj.Dept_ID_Txt = Smrt_Srch_structure.SelectedText;
                                ////if (string.IsNullOrEmpty(obj.Dept_ID_Txt))
                                ////    obj.Dept_ID_Txt = Smrt_Srch_structure.SelectedText;

                                ////obj.Emp_ID = 0;
                                ////obj.Emp_ID_Txt = txt_Emp_ID_Txt.Text;
                                //if (string.IsNullOrEmpty(obj.Emp_ID_Txt))
                                //    obj.Emp_ID_Txt = Smart_Visa_Emp.SelectedText;

                                ////obj.Visa_Desc = txt_Visa_Desc.Text;
                                ////obj.Visa_Period = txt_Visa_Period.Text;
                                ////obj.Visa_Satus = CDataConverter.ConvertToInt(ddl_Visa_Satus.SelectedValue);
                                //obj.Follow_Up_Dept_ID = CDataConverter.ConvertToInt(ddl_Follow_Up_Dept_ID.SelectedValue);
                                //obj.Follow_Up_Emp_ID = CDataConverter.ConvertToInt(Smart_Follow_Up_Emp_ID.SelectedValue);
                                ////obj.Follow_Up_Notes = txt_Follow_Up_Notes.Text;
                                ////obj.saving_file = txt_saving_file.Text;
                                ////obj.Dead_Line_DT = txt_Dead_Line_DT.Text;
                                ////obj.Visa_Goal_ID = CDataConverter.ConvertToInt(ddl_Visa_Goal_ID.SelectedValue);
                                ////obj.mail_sent = 0;


                                //obj.Visa_Id = Outbox_Visa_DB.Save(obj);


                                Clear_Visa_Cntrl();
                                Fil_Grid_Visa();
                                ////fil_emp_Folow_Up();
                                Fil_Emp_Visa_Follow();
                                ///////////////////////// update have visa = 1/////////////////////////////////////////////

                                Update_Have_Visa_all_emp(CDataConverter.ConvertToInt(Outbox_ID.Value));
                                lst_emp.Items.Clear();
                            }
                            else
                            {
                                //Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('أخر تاريخ يجب ان يكون اكبر من تاريخ التأشيره')</script>");
                                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('أخر تاريخ يجب ان يكون اكبر من تاريخ التأشيره');", true);

                            }

                        }
                        else
                        {
                            //  Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لا يوجد أسماء في القائمة اليسري')</script>");

                            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('لا يوجد أسماء في القائمة اليسري');", true);

                        }



                    }
                    else
                    {
                        //  Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('يجب إدخال بيانات الخطاب أولا')</script>");
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('يجب إدخال بيانات الخطاب أولا');", true);



                    }
                }
                else
                {
                    //  Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('يجب إرسال الخطاب للمدير المختص أولا ')</script>");

                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('يجب إرسال الخطاب للمدير المختص أولا');", true);

                }
            }
        }
    }
    protected void btn_Visa_Follow_Click(object sender, EventArgs e)
    {
        string DocName = "";
        string type = "";
        Byte[] Input = new Byte[0];
        if (CDataConverter.ConvertToDate(txt_Follow_Date.Text) >= CDataConverter.ConvertToDate(txt_Date.Text))
        {
            if (CDataConverter.ConvertToInt(Outbox_ID.Value) > 0)
            {
                using (var outboxContext = new OutboxContext())
                {
                    var hiddFollowVal=CDataConverter.ConvertToInt(hidden_Follow_ID.Value);
                    Outbox_Visa_Follows Outbox_Visa_Follow = outboxContext.Outbox_Visa_Follows.Where(x => x.Follow_ID == hiddFollowVal).SingleOrDefault();
                    ////Outbox_Visa_Follows_DT obj = Outbox_Visa_Follows_DB.SelectByID(CDataConverter.ConvertToInt(hidden_Follow_ID.Value));
                    if (FileUpload_Visa_Follow.HasFile)
                    {
                        DocName = FileUpload_Visa_Follow.FileName;
                        int dotindex = DocName.LastIndexOf(".");
                        type = DocName.Substring(dotindex, DocName.Length - dotindex);

                        Stream myStream;
                        int fileLen;
                        StringBuilder displayString = new StringBuilder();
                        fileLen = FileUpload_Visa_Follow.PostedFile.ContentLength;
                        Input = new Byte[fileLen];
                        myStream = FileUpload_Visa_Follow.FileContent;
                        myStream.Read(Input, 0, fileLen);
                    }
                    if (Outbox_Visa_Follow != null)
                    {
                        Outbox_Visa_Follow.Follow_ID = CDataConverter.ConvertToInt(hidden_Follow_ID.Value);
                        Outbox_Visa_Follow.Outbox_ID = CDataConverter.ConvertToInt(Outbox_ID.Value);
                        Outbox_Visa_Follow.Descrption = txt_Descrption.Text;
                        Outbox_Visa_Follow.Date = txt_Follow_Date.Text;
                        Outbox_Visa_Follow.time_follow = CDataConverter.ConvertTimeNowRtnLongTimeFormat();
                        Outbox_Visa_Follow.entery_pmp_id = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
                        Outbox_Visa_Follow.Visa_Emp_id = CDataConverter.ConvertToInt(ddl_Visa_Emp_id.SelectedValue);
                        Outbox_Visa_Follow.Type_Follow = 1;

                        //obj.Follow_ID = Outbox_Visa_Follows_DB.Save(obj);




                        ////SqlCommand cmd = new SqlCommand();
                        ////SqlConnection con = new SqlConnection();
                        ////SqlCommand cmd_local = new SqlCommand();
                        ////SqlConnection con_local = new SqlConnection();
                        ////con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                        ////con_local = new SqlConnection(Session_CS.local_connectionstring);
                        ////cmd.Parameters.Add("@File_data", SqlDbType.VarBinary);
                        ////cmd.Parameters.Add("@File_name", SqlDbType.NVarChar);
                        ////cmd.Parameters.Add("@File_ext", SqlDbType.NVarChar);
                        ////cmd.Parameters.Add("@Follow_ID", SqlDbType.BigInt);

                        //////cmd.Parameters["@File_data"].Value = Input;
                        ////cmd.Parameters["@File_name"].Value = DocName;
                        ////cmd.Parameters["@File_ext"].Value = type;
                        ////cmd.Parameters["@Follow_ID"].Value = obj.Follow_ID;
                        ////cmd.CommandType = CommandType.Text;
                        ////cmd.CommandText = " update Outbox_Visa_Follows set File_data =@File_data ,File_name=@File_name,File_ext=@File_ext where Follow_ID =@Follow_ID";
                        Outbox_Visa_Follow.File_name = DocName;
                        Outbox_Visa_Follow.File_ext = type;
                        Outbox_Visa_Follow.File_data = Input;

                        ////if (string.IsNullOrEmpty(Session_CS.local_connectionstring))
                        ////{
                        ////    cmd.Connection = con;
                        ////    cmd.Parameters["@File_data"].Value = Input;
                        ////    con.Open();
                        ////    cmd.ExecuteScalar();
                        ////    con.Close();

                        ////}
                        ////else
                        ////{

                        ////    cmd.Connection = con;
                        ////    cmd.Parameters["@File_data"].Value = DBNull.Value;
                        ////    con.Open();
                        ////    cmd.ExecuteScalar();
                        ////    con.Close();
                        ////    try
                        ////    {
                        ////        cmd.Connection = con_local;
                        ////        cmd.Parameters["@File_data"].Value = Input;

                        ////        con_local.Open();
                        ////        cmd.ExecuteScalar();
                        ////        con_local.Close();


                        ////    }
                        ////    catch
                        ////    {
                        ////        // can't connect to sql local, we should show message here

                        ////        //   ShowAlertMessage("   عفوا لم يتم الإتصال بقاعدة البيانات الداخلية");

                        ////        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('عفوا لم يتم الإتصال بقاعدة البيانات الداخلية');", true);

                        ////    }
                        ////}




                    }
                    else
                    {
                        Outbox_Visa_Follows Outbox_Visa_FollowNew = new Outbox_Visa_Follows
                        {

                            Outbox_ID = CDataConverter.ConvertToInt(Outbox_ID.Value),
                            Descrption = txt_Descrption.Text,
                            Date = txt_Follow_Date.Text,
                            time_follow = CDataConverter.ConvertTimeNowRtnLongTimeFormat(),
                            entery_pmp_id = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()),
                            Visa_Emp_id = CDataConverter.ConvertToInt(ddl_Visa_Emp_id.SelectedValue),
                            Type_Follow = 1,
                            File_name = DocName,
                            File_ext = type,
                            File_data = Input
                        };
                        outboxContext.Outbox_Visa_Follows.Add(Outbox_Visa_FollowNew);
                    }
                    ///////////// change have follow = 1/////////////////////////////////////////////

                    ////SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                    ////DataTable DT = new DataTable();
                    ////DT = General_Helping.GetDataTable("select * from Outbox_Track_Manager where Outbox_id = " + Outbox_ID.Value);
                    var hiddVal= CDataConverter.ConvertToInt(Outbox_ID.Value);
                    var OutboxTrackManagerDT = outboxContext.Outbox_Track_Manager.Where(x => x.Outbox_id == hiddVal);
                    if (OutboxTrackManagerDT.Count() > 0)
                    {
                        ////conn.Open();
                        ////string sql = "update Outbox_Track_Manager set Have_Follow=1 where Outbox_id =" + Outbox_ID.Value;
                        ////SqlCommand cmd = new SqlCommand(sql, conn);
                        ////cmd.ExecuteNonQuery();
                        ////conn.Close();

                        foreach (var OutboxTrackManager in OutboxTrackManagerDT)
                        {
                            OutboxTrackManager.Have_Follow = 1;
                        }

                    }

                    outboxContext.SaveChanges();
                    Clear_visa_Follow();

                    Fil_Grid_Visa_Follow();
                }
            }
            else
            {
                //Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('يجب إدخال بيانات الخطاب أولا')</script>");

                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('يجب إدخال بيانات الخطاب أولا');", true);


            }

        
                }
        else
        {

            //Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('تاريخ المتابعة يجب أن يكون أكبر من أو يساوي تاريخ الخطاب')</script>");

            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('تاريخ المتابعة يجب أن يكون أكبر من أو يساوي تاريخ الخطاب');", true);

        }

    }
    private void Update_Have_Visa(string Visa_Id)
    {
        using (var outboxContext = new OutboxContext()) {
            var visaVal=CDataConverter.ConvertToInt(Visa_Id);
            var outboxVal=CDataConverter.ConvertToInt(Outbox_ID.Value);
            var OutboxVisa = outboxContext.Outbox_Visa.Where(x => x.mail_sent == 1 && x.Visa_Id != visaVal && x.Outbox_ID == outboxVal);
        ////string Sql_Visa_Sent = "select Visa_Id from Outbox_Visa where mail_sent = 1 and Visa_Id !=" + Visa_Id + " and Outbox_id = " + Outbox_ID.Value;
        //// int Visa_Sent_Count = General_Helping.GetDataTable(Sql_Visa_Sent).Rows.Count;
        if (OutboxVisa.Count() == GridView_Visa.Rows.Count - 1)
        {
            //// DataTable DT = General_Helping.GetDataTable("select * from Outbox_Track_Manager where Outbox_id = " + Outbox_ID.Value);
            
            var OutboxTrackManagers = outboxContext.Outbox_Track_Manager.Where(x => x.Outbox_id == outboxVal);
            if (OutboxTrackManagers.Count() > 0)
            {
                ////string sql = "update Outbox_Track_Manager set Have_visa=0 , All_visa_sent=1 where Outbox_id =" + Outbox_ID.Value;
                /////General_Helping.ExcuteQuery(sql);
                foreach (var OutboxTrackManager in OutboxTrackManagers)
                {
                    OutboxTrackManager.Have_Visa = 0;
                    OutboxTrackManager.All_visa_sent = 1;
                }
                outboxContext.SaveChanges();
            }
        }
        }

    }
    protected void btn_add_Click(object sender, EventArgs e)
    {

        fill_listbox();
        TabPanel_All.ActiveTab = TabPanel_Visa;
    }
    protected void btn_delete_Click(object sender, EventArgs e)
    {
        if (lst_emp.SelectedValue == "")
        {
            // Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('يجب اختيار موظف ليتم الحذف')</script>");


            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('يجب اختيار موظف ليتم الحذف');", true);

        }
        else
        {
            lst_emp.Items.Remove(lst_emp.SelectedItem);


        }
        TabPanel_All.ActiveTab = TabPanel_Visa;

    }
    private void Update_Have_Visa_all_emp(int outbox_ID)
    {
        using (var outboxContext = new OutboxContext()) {
            var OutboxTrackManagerObjs = outboxContext.Outbox_Track_Manager.Where(x => x.Outbox_id == outbox_ID);
        foreach (var OutboxTrackManagerObj in OutboxTrackManagerObjs)
        {
            OutboxTrackManagerObj.status = 0;
            OutboxTrackManagerObj.Have_Follow = 0;
            OutboxTrackManagerObj.Have_Visa = 1;
            OutboxTrackManagerObj.Visa_Desc = txt_Visa_Desc.Text;
        }

        ////string sql = "update Outbox_Track_Manager set status=0,Have_Follow=0,Have_visa=1 , ";
        ////sql += "Visa_Desc = '" + txt_Visa_Desc.Text + "'";
        ////sql += " where Outbox_id =" + outbox_ID;
        ////General_Helping.ExcuteQuery(sql);
        var Outbox_Track_Emps = outboxContext.Outbox_Track_Emp.Where(x => x.Outbox_id == outbox_ID);
        foreach (var Outbox_Track_Emp in Outbox_Track_Emps)
        {
            Outbox_Track_Emp.Outbox_Status = 2;
        }
        outboxContext.SaveChanges();
        ////string sql_all_User = "update Outbox_Track_Emp set Outbox_Status =2 where Outbox_id=" + outbox_ID;
        ////General_Helping.ExcuteQuery(sql_all_User);
        }
    }
    protected void radlst_Type_SelectedIndexChanged(object sender, EventArgs e)
    {
        dropdept_fun();

    }
    private void Save_trackmanager_ForInbox(int id)
    {

        DataTable dt = pm_inbox.get_data_from_parent_employee_inbox_type_only().ToDataTable();

        if (dt.Rows.Count > 0)
        {

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                foreach (ListItem item in lst_emp.Items)
                {
                    if (CDataConverter.ConvertToInt(item.Value) == CDataConverter.ConvertToInt(dt.Rows[i]["parent_pmp_id"].ToString()))
                    {
                        // Inbox_track_manager_DT obj = new Inbox_track_manager_DT();

                        Inbox_Track_Manager obj = new Inbox_Track_Manager();

                        obj.inbox_id = CDataConverter.ConvertToInt(hidden_Id.Value);
                        obj.Have_Visa = 0;
                        obj.Have_Follow = 0;
                        obj.IS_New_Mail = 1;
                        obj.status = 1;
                        obj.IS_Old_Mail = 0;
                        obj.Visa_Desc = "";
                        obj.Type_Track = 1;
                        obj.pmp_id = int.Parse(Session_CS.pmp_id.ToString());
                        obj.parent_pmp_id = CDataConverter.ConvertToInt(item.Value);
                        //obj.parent_pmp_id = CDataConverter.ConvertToInt(Session_CS.parent_id.ToString());
                        obj.All_visa_sent = 0;
                        // obj.inbox_id = Inbox_track_manager_DB.Save(obj);

                        // InsertOrUpdate_Inbox_track_manager(obj);

                        pm_inbox.Inbox_Track_Manager.Add(obj);
                        pm_inbox.SaveChanges();

                    }

                }
            }


        }
    }

    private void Save_trackmanager(int id)
    {
        DataTable dt = pm_inbox.get_data_from_parent_employee_inbox_type_only().ToDataTable();

        if (dt.Rows.Count > 0)
        {

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                foreach (ListItem item in lst_emp.Items)
                {
                    if (CDataConverter.ConvertToInt(item.Value) == CDataConverter.ConvertToInt(dt.Rows[i]["parent_pmp_id"].ToString()))
                    {
                        // Inbox_track_manager_DT obj = new Inbox_track_manager_DT();

                        Inbox_Track_Manager obj = new Inbox_Track_Manager();

                        obj.inbox_id = CDataConverter.ConvertToInt(hidden_Id.Value);
                        obj.Have_Visa = 0;
                        obj.Have_Follow = 0;
                        obj.IS_New_Mail = 1;
                        obj.status = 1;
                        obj.IS_Old_Mail = 0;
                        obj.Visa_Desc = "";
                        obj.Type_Track = 1;
                        obj.pmp_id = int.Parse(Session_CS.pmp_id.ToString());
                        obj.parent_pmp_id = CDataConverter.ConvertToInt(item.Value);
                        //obj.parent_pmp_id = CDataConverter.ConvertToInt(Session_CS.parent_id.ToString());
                        obj.All_visa_sent = 0;
                        // obj.inbox_id = Inbox_track_manager_DB.Save(obj);

                        // InsertOrUpdate_Inbox_track_manager(obj);

                        pm_inbox.Inbox_Track_Manager.Add(obj);
                        pm_inbox.SaveChanges();

                    }

                }
            }


        }
        //using (var ADContext = new ActiveDirectoryContext())
        //{
        //    var parent_employees = ADContext.parent_employee.Where(x => x.Type == 2);
        //    ////DataTable dt = General_Helping.GetDataTable("select * from parent_employee where Type=2 ");
        //    if (parent_employees.Count() > 0)
        //    {

        //        foreach (var parent_employee in parent_employees)
        //        {

        //            foreach (ListItem item in lst_emp.Items)
        //            {
        //                if (CDataConverter.ConvertToInt(item.Value) == parent_employee.parent_pmp_id)
        //                {
        //                    Outbox_Track_Manager OutboxTrackManager = new Outbox_Track_Manager
        //                    {
        //                        Outbox_id = CDataConverter.ConvertToInt(Outbox_ID.Value),
        //                        Have_Visa = 0,
        //                        Have_Follow = 0,
        //                        IS_New_Mail = 1,
        //                        status = 1,
        //                        IS_Old_Mail = 0,
        //                        Visa_Desc = "",
        //                        Type_Track = 1,
        //                        pmp_id = int.Parse(Session_CS.pmp_id.ToString()),
        //                        parent_pmp_id = CDataConverter.ConvertToInt(item.Value),
        //                        All_visa_sent = 0
        //                    };

                    
        //                }

        //            }
        //        }
        //        ADContext.SaveChanges();

        //    }
        //}
    }
    protected void chk_ALL_CheckedChanged(object sender, EventArgs e)
    {
        foreach (ListItem item in chklst_Visa_Emp_All.Items)
        {
            item.Selected = chk_ALL.Checked;
        }
        TabPanel_All.ActiveTab = TabPanel_Visa;
    }


    #endregion



    #region "methods"
    public void ShowAlertMessage(string error)
    {

        Page page = HttpContext.Current.Handler as Page;
        if (page != null)
        {
            error = error.Replace("'", "\'");
            //  ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('" + error + "');", true);

            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('" + error + "');", true);



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
    private string Show_Alert(string Succ_names, string Failed_name, string visa_id)
    {
        string message = "";
        int flag = 0;
        if (!string.IsNullOrEmpty(Succ_names))
        {
            flag = 1;
            message += " لقد تم ارسال الايميل بنجاح إلي " + Succ_names;

        }
        if (!string.IsNullOrEmpty(Failed_name))
        {
            flag = 2;
            message += " ولم يتم ارسال الايميل إلي " + Failed_name;
        }

        if (flag == 1)
        {
            Outbox_Visa_DT obj = Outbox_Visa_DB.SelectByID(CDataConverter.ConvertToInt(visa_id));
            obj.mail_sent = 1;
            Outbox_Visa_DB.Save(obj);


        }

        return message;


        //      if (!string.IsNullOrEmpty(Failed_name))
        //        Page.RegisterStartupScript("Sucess", "<script language=javascript>alert(' لم يتم ارسال الايميل إلي " + Failed_name + "')</script>");

    }
    public void Clear_visa_Follow()
    {
        hidden_Follow_ID.Value =
        txt_Descrption.Text =
        txt_Follow_Date.Text = "";
        ddl_Visa_Emp_id.SelectedIndex = 0;
    }
    public string Get_Type_Visa(object obj)
    {
        string str = obj.ToString();
        if (str == "1")
            return "هام";
        else if (str == "2")
            return "عاجل";
        else if (str == "3")
            return "عادى";
        else return "";
    }
    private void Clear_Visa_Cntrl()
    {
        hidden_Visa_Id.Value = "";
        chk_ALL.Checked = false;

        //  Smart_Visa_Emp.Clear_Controls();
    }
    private void Type_Changed()
    {
        if (ddl_Type.SelectedValue == "1")
        {
            tr_Inbox_out.Visible = false;
            // tr_Inbox_In.Visible = true;

            tr_Inbox_In.Style.Add("display", "block");
        }
        else if (ddl_Type.SelectedValue == "2")
        {
            //  tr_Inbox_In.Visible = false;
            tr_Inbox_In.Style.Add("display", "none");
            tr_Inbox_out.Visible = true;
        }
        TabPanel_All.ActiveTab = TabPanel_dtl;
    }
    public string Get_Type(object obj)
    {
        string str = obj.ToString();
        if (str == "1")
            return "وثيقة أصلية";
        else if (str == "2")
            return "مرفقات";
        else return "وثيقة";
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        Outbox_ID.Value = "";
        txt_Code.Text = "";
        //Smart_Org_ID.SelectedValue = "";
        txt_Org_Out_Box_Code.Text = "";
        txt_Org_Out_Box_DT.Text = "";
        txt_Org_Dept_Name.Text = "";
        txt_Org_Out_Box_Person.Text = "";
        txt_Dept_Desc.Text = "";
        txt_Subject.Text = "";
        txt_Paper_No.Text = "";
        txt_Paper_Attached.Text = "";
        txt_Notes.Text = "";
        txtFileName.Text = "";
        GrdView_Documents.DataSource = null;
        GrdView_Documents.DataBind();
        GridView_Visa.DataSource = null;
        GridView_Visa.DataBind();
        lst_emp.Items.Clear();
    }

   
    public void update_Outbox_Track_Emp(string Outbox_id, int Emp_ID, int Outbox_Status, int Type)
    {
        ////DataTable DT = General_Helping.GetDataTable("select * from Outbox_Track_Emp where Outbox_id = " + Outbox_id + " and Emp_ID =" + Emp_ID);
        using (var outboxContext = new OutboxContext())
        {
            var outboxVal=CDataConverter.ConvertToInt(Outbox_id);
            var Outbox_Track_Emps = outboxContext.Outbox_Track_Emp.Where(x => x.Outbox_id == outboxVal  && x.Emp_ID == Emp_ID);
            if (Outbox_Track_Emps.Count() > 0)
            {

                ////string sql = "update Outbox_Track_Emp set Outbox_Status= " + Outbox_Status + " where Outbox_id =" + Outbox_id + " and Emp_ID =" + Emp_ID;
                ////General_Helping.ExcuteQuery(sql);
                foreach (var Outbox_Track_Emp in Outbox_Track_Emps)
                {
                    Outbox_Track_Emp.Outbox_Status = Outbox_Status;
                }
            }
            else
            {
                ////string sql = "insert into Outbox_Track_Emp (Outbox_id,Emp_ID,Outbox_Status,Type_Track_emp) values ( " + Outbox_id + "," + Emp_ID + "," + Outbox_Status + "," + "1" + ")";
                ////General_Helping.ExcuteQuery(sql);
                Outbox_Track_Emp OutboxTrackEmp = new Outbox_Track_Emp
                {
                    Outbox_id = CDataConverter.ConvertToInt(Outbox_id),
                    Emp_ID = Emp_ID,
                    Outbox_Status = Outbox_Status,
                    Type_Track_emp = 1

                };
                outboxContext.Outbox_Track_Emp.Add(OutboxTrackEmp);

            }
            outboxContext.SaveChanges();
        }
    }
    public string Get_Visa_Emp(object obj)
    {
        if (CDataConverter.ConvertToInt(ddl_Type.SelectedValue) == 1)
        {
            string visa_ID = obj.ToString();
            string emp_name = "";
            DataTable DT = new DataTable();



            DT = pm_inbox.Get_Visa_Emp(CDataConverter.ConvertToInt(visa_ID)).ToDataTable();

            foreach (DataRow dr in DT.Rows)
            {
                emp_name += dr["pmp_name"].ToString() + ",";
            }
            return emp_name;
        }

        else
        {

            string visa_ID = obj.ToString();
            string emp_name = "";


            using (var outboxContext = new OutboxContext())
            {
                string result = "";
                var visaVal = CDataConverter.ConvertToInt(visa_ID);

                List<string> OutboxVisaEmps = outboxContext.get_OutboxVisaEmps(visaVal).ToList();
                //    SELECT EMPLOYEE.pmp_name 
                //      FROM Outbox_Visa_Emp INNER JOIN EMPLOYEE ON Outbox_Visa_Emp.Emp_ID = EMPLOYEE.PMP_ID 
                //      WHERE Outbox_Visa_Emp.Visa_Id  = @visa_ID
                //DataTable DT = extentionMethods.ToDataTable(OutboxVisaEmps);
                if (OutboxVisaEmps.Count() > 0)
                {
                    foreach (string item in OutboxVisaEmps)
                    {

                        emp_name += item + ",";
                    }
                    int lastindx = emp_name.LastIndexOf(',');
                    result = emp_name.Substring(0, lastindx);
                }


                return result;
                //string visa_ID = obj.ToString();
                //string emp_name = "";
                //DataTable DT = new DataTable();
                //DT = General_Helping.GetDataTable("SELECT EMPLOYEE.pmp_name FROM Outbox_Visa_Emp INNER JOIN EMPLOYEE ON Outbox_Visa_Emp.Emp_ID = EMPLOYEE.PMP_ID WHERE Outbox_Visa_Emp.Visa_Id  =" + visa_ID);
                //foreach (DataRow dr in DT.Rows)
                //{
                //    emp_name += dr["pmp_name"].ToString() + ",";
                //}
                //return emp_name;
            }
        }
    }
    #endregion




    #region "refactored and removed"

    //protected void ddl_Dept_ID_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    fil_emp();
    //}
    ////protected void ddl_Visa_Dept_ID_SelectedIndexChanged(object sender, EventArgs e)
    ////{
    ////    //refactored by hafs
    ////    chklst_Visa_Emp.DataSource = fil_emp_by_Dept(CDataConverter.ConvertToInt(Smrt_Srch_structure.SelectedValue));//fil_emp_Visa();
    ////    chklst_Visa_Emp.DataBind();
    ////    TabPanel_All.ActiveTab = TabPanel_Visa;
    ////}
    ////private void Fil_Visa_Lst(int ID)
    ////{
    ////    //refactroed by hafs
    ////    //string Sql_Delete = "select * from Outbox_Visa_Emp where Visa_Id =" + ID;
    ////    var Outbox_Visa_Emps = outboxDBContext.Outbox_Visa_Emps.Where(x => x.Visa_Id == ID);
    ////    ////DataTable DT = Fil_Emp_Visa();
    ////    foreach (var Outbox_Visa_Emp in Outbox_Visa_Emps)
    ////    {
    ////        string Value = Outbox_Visa_Emp.Emp_ID.ToString();
    ////        ListItem item = chklst_Visa_Emp.Items.FindByValue(Value);
    ////        if (item != null)
    ////            item.Selected = true;
    ////    }


    ////}
    //private void fill_resp_Emp()
    //{

    //    chklst_Visa_Emp_All.DataSource = outboxDBContext.get_employee_accoording_to_radiochek(radlst_Type.SelectedValue, Session_CS.pmp_id, Session_CS.dept_id, Session_CS.foundation_id);
    //    chklst_Visa_Emp_All.DataBind();
    //    //TabPanel_All.ActiveTab = TabPanel_Visa;
    //    tr_emp_list.Visible = true;
    //refactored by hafs
    //DataTable DT_emp = SqlHelper.ExecuteDataset(Database.ConnectionString, "get_employee_accoording_to_radiochek", radlst_Type.SelectedValue, Session_CS.pmp_id, Session_CS.dept_id, Session_CS.foundation_id).Tables[0];
    //tr_emp_list.Visible = true;
    //string sql, sql_emp = "";

    //if (radlst_Type.SelectedValue == "1")
    //{
    //    sql_emp = " select * from pmp_fav_View where pmp_fav_View.employee_id = " + CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
    //    if (Smrt_Srch_structure.SelectedValue != "")
    //    {
    //        sql_emp += " AND Dept_Dept_id = " + Smrt_Srch_structure.SelectedValue;
    //        // sql_emp += "  and  sec_sec_id=" + CDataConverter.ConvertToInt("0");
    //    }
    //    //if (ddl_sectors2.SelectedValue != "" && ddl_sectors2.SelectedValue != "0")
    //    //{
    //    //    sql_emp += "  and  sec_sec_id=" + ddl_sectors2.SelectedValue;
    //    //}



    //}
    //else if (radlst_Type.SelectedValue == "2")
    //{
    //    // sql_emp = " select * from employee where dbo.EMPLOYEE.workstatus = 1";


    //    sql_emp = "SELECT     EMPLOYEE.*,Departments.* FROM Departments  INNER JOIN EMPLOYEE ON Departments.Dept_id = EMPLOYEE.Dept_Dept_id where  EMPLOYEE.PMP_ID not in(select parent_pmp_id from dbo.parent_employee) and dbo.EMPLOYEE.workstatus = 1 and EMPLOYEE.foundation_id='" + Session_CS.foundation_id + "'";

    //    if (Smrt_Srch_structure.SelectedValue != "")
    //    {
    //        sql_emp += " and Dept_Dept_id = " + Smrt_Srch_structure.SelectedValue;
    //        // sql_emp += "  and  sec_sec_id=" + CDataConverter.ConvertToInt("0");
    //    }
    //    //if (ddl_sectors2.SelectedValue != "" && ddl_sectors2.SelectedValue != "0")
    //    //{
    //    //    sql_emp += "and  Sectors.Sec_id=" + ddl_sectors2.SelectedValue;
    //    //}

    //}
    //else if (radlst_Type.SelectedValue == "3")
    //{
    //    // sql_emp = " select * from employee where rol_rol_id=3  and dbo.EMPLOYEE.workstatus = 1";

    //    sql_emp = "SELECT     EMPLOYEE.*,Departments.* FROM Departments  INNER JOIN EMPLOYEE ON Departments.Dept_id = EMPLOYEE.Dept_Dept_id where dbo.EMPLOYEE.workstatus = 1 and rol_rol_id=3 and EMPLOYEE.foundation_id='" + Session_CS.foundation_id + "'";


    //    if (Smrt_Srch_structure.SelectedValue != "")
    //    {
    //        sql_emp += " AND Dept_Dept_id = " + Smrt_Srch_structure.SelectedValue;
    //        // sql_emp += "  and  sec_sec_id=" + CDataConverter.ConvertToInt("0");
    //    }

    //    //if (ddl_sectors2.SelectedValue != "" && ddl_sectors2.SelectedValue != "0")
    //    //{
    //    //    sql_emp += "and  Sectors.Sec_id=" + ddl_sectors2.SelectedValue;
    //    //}

    //}
    //else if (radlst_Type.SelectedValue == "4")
    //{
    //    // sql_emp = " select * from employee where contact_person=1 and dbo.EMPLOYEE.workstatus = 1 ";

    //    sql_emp = "SELECT     EMPLOYEE.*,  Sectors.*,Departments.* FROM Departments INNER JOIN Sectors ON Departments.Sec_sec_id = Sectors.Sec_id INNER JOIN EMPLOYEE ON Departments.Dept_id = EMPLOYEE.Dept_Dept_id where dbo.EMPLOYEE.workstatus = 1 and contact_person=1 and EMPLOYEE.foundation_id='" + Session_CS.foundation_id + "'";

    //    if (Smrt_Srch_structure.SelectedValue != "")
    //    {
    //        sql_emp += " AND Dept_Dept_id = " + Smrt_Srch_structure.SelectedValue;
    //        //sql_emp += "  and  sec_sec_id=" + CDataConverter.ConvertToInt("0");
    //    }

    //    //if (ddl_sectors2.SelectedValue != "" && ddl_sectors2.SelectedValue != "0")
    //    //{
    //    //    sql_emp += "and  Sectors.Sec_id=" + ddl_sectors2.SelectedValue;
    //    //}

    //}

    //else if (radlst_Type.SelectedValue == "5")
    //{
    //    sql_emp = "  select EMPLOYEE.pmp_name + ' - رئيس ' + +' '+ Commitee.Commitee_Title as pmp_name ,EMPLOYEE.PMP_ID from EMPLOYEE inner join commitee_presidents on  EMPLOYEE.PMP_ID=commitee_presidents.pmp_id inner join Commitee on commitee_presidents.comt_id = Commitee.ID where  Commitee.foundation_id='" + Session_CS.foundation_id + "'";

    //}

    //else if (radlst_Type.SelectedValue == "6")
    //{

    //    sql_emp = "select EMPLOYEE.pmp_name COLLATE DATABASE_DEFAULT  + ' -  ' + Departments.Dept_name  as pmp_name,EMPLOYEE.PMP_ID from EMPLOYEE inner join commitee_presidents on  EMPLOYEE.PMP_ID=commitee_presidents.pmp_id inner join Departments on  commitee_presidents.dept_id = Departments.Dept_id   inner join Sectors  on Sectors.Sec_id = Departments.Sec_sec_id where Sectors.foundation_id='" + Session_CS.foundation_id + "'";
    //}

    //sql_emp += " ORDER BY LTRIM(pmp_name)";
    //TabPanel_All.ActiveTab = TabPanel_Visa;
    //DataTable dt_emp_fav = General_Helping.GetDataTable(sql_emp);
    //chklst_Visa_Emp_All.DataSource = dt_emp_fav;
    //chklst_Visa_Emp_All.DataBind();
    //}
    ////////refactored by hafs
    //private void fil_emp()
    // {


    //Smart_Emp_ID.sql_Connection = sql_Connection;
    //string Query = "";
    //Query = "SELECT     EMPLOYEE.*,  Sectors.*,Departments.* FROM Departments INNER JOIN Sectors ON Departments.Sec_sec_id = Sectors.Sec_id INNER JOIN EMPLOYEE ON Departments.Dept_id = EMPLOYEE.Dept_Dept_id where dbo.EMPLOYEE.workstatus = 1";
    //if (Smrt_Srch_structure2.SelectedValue != "")
    //{
    //    Query += " and Departments.Dept_id = " + Smrt_Srch_structure2.SelectedValue;
    //    //Query += " and  Sectors.Sec_id=" + CDataConverter.ConvertToInt("0");
    //}
    ////if (drop_sectors.SelectedValue != "" && drop_sectors.SelectedValue != "0")
    ////{
    ////    Query += " and  Sectors.Sec_id=" + drop_sectors.SelectedValue;
    ////}
    //Smart_Emp_ID.datatble = General_Helping.GetDataTable(Query);
    //Smart_Emp_ID.Value_Field = "PMP_ID";
    //Smart_Emp_ID.Text_Field = "pmp_name";
    //Smart_Emp_ID.DataBind();

    // }


    //////refactored by hafs
    // void Fil_Smrt_From_OutBox()
    //{


    //Smart_Related_Id.sql_Connection = sql_Connection;
    //// Smart_Related_Id.Query = "SELECT * from vw_outbox_DateSubject where group_id = " + int.Parse(Session_CS.group_id.ToString());
    //string Query = "set dateformat dmy SELECT vw_outbox_DateSubject.*,CONVERT(datetime, dbo.datevalid(Date)) as date1 from vw_outbox_DateSubject where group_id = " + int.Parse(Session_CS.group_id.ToString());
    //if (CDataConverter.ConvertToInt(Session_CS.Project_id.ToString()) > 0)
    //{
    //    Query += " AND Proj_id = " + int.Parse(Session_CS.Project_id.ToString());
    //}
    //Query += " order by  convert(datetime,Date) desc ";

    //}
    //////refactored by hafs
    // void Fil_Smrt_From_InBox()
    // {



    //Smart_Related_Id.sql_Connection = sql_Connection;
    // Smart_Related_Id.Query = "SELECT * from vw_inbox_DateSubject where  group_id = " + int.Parse(Session_CS.group_id.ToString());
    //string Query = "set dateformat dmy SELECT vw_inbox_DateSubject.*,CONVERT(datetime, dbo.datevalid(Date)) as date1 from vw_inbox_DateSubject where  group_id = " + int.Parse(Session_CS.group_id.ToString());
    //if (CDataConverter.ConvertToInt(Session_CS.Project_id.ToString()) > 0)
    // {
    //    Query += " AND Proj_id = " + int.Parse(Session_CS.Project_id.ToString());
    //}
    //Query += " order by CONVERT(datetime, dbo.datevalid(Date)) desc ";
    //Smart_Related_Id.datatble = General_Helping.GetDataTable(Query);

    //}
    ////////refactored by hafs
    //void Fil_Smrt_From_InBox_Minister()
    //{


    //Smart_Related_Id.sql_Connection = sql_Connection;
    //string Query = "";
    //Query = "set dateformat dmy SELECT vw_inbox_minister_DateSubject.* from vw_inbox_minister_DateSubject where  group_id = " + int.Parse(Session_CS.group_id.ToString());
    //if (CDataConverter.ConvertToInt(Session_CS.Project_id.ToString()) > 0)
    //{
    //    Query += " AND Proj_id = " + int.Parse(Session_CS.Project_id.ToString());
    //}
    //Smart_Related_Id.datatble = General_Helping.GetDataTable(Query);
    //Smart_Related_Id.Value_Field = "id";
    //Smart_Related_Id.Text_Field = "con";
    //Smart_Related_Id.Show_Code = false;
    //Smart_Related_Id.DataBind();
    //}

    //private void Fil_Smrt_From_Outbox()
    //{
    //    Smart_Related_Id.sql_Connection = sql_Connection;
    //    //  Smart_Related_Id.Query = "SELECT * from vw_outbox_DateSubject where group_id =  " + int.Parse(Session_CS.group_id.ToString());
    //    string Query = "SELECT * from vw_outbox_DateSubject where group_id =  " + int.Parse(Session_CS.group_id.ToString());
    //    Smart_Related_Id.datatble = General_Helping.GetDataTable(Query);
    //    Smart_Related_Id.Show_Code = false;
    //    Smart_Related_Id.Value_Field = "id";
    //    Smart_Related_Id.Text_Field = "con";
    //    Smart_Related_Id.DataBind();
    //}


    #endregion
}
