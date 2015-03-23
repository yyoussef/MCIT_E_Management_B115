
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
using System.Text;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Net.Mail;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Globalization;
using System.Security.Cryptography;
using ReportsClass;


public partial class UserControls_Project_Inbox : System.Web.UI.UserControl
{
    //test by youssef
    //Session_CS Session_CS = new Session_CS();
    private string sql_Connection = Database.ConnectionString;
    General_Helping Obj_General_Helping = new General_Helping();
    int id;
    string v_desc;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
        
            Smart_Search_structure.Show_OrgTree = true;
            Smart_Search_structure2.Show_OrgTree = true;
        
            //fill_structure();
            //if (CDataConverter.ConvertToInt(Session_CS.Project_id.ToString()) > 0)
            //{
            //    TabPanel_Visa.Visible = false;
            //    TabPanel_Visa_Folow.Visible = false;

            //    if (Session_CS.UROL_UROL_ID != null && CDataConverter.ConvertToInt(Session_CS.UROL_UROL_ID) == 3)
            //    {
            //        //string sql1 = " SELECT Proj_id ,pmp_pmp_id " +
            //        //   " FROM     Project     " +
            //        //   " where Proj_id = '" + Session_CS.Project_id + "' and pmp_pmp_id = '" + Session_CS.pmp_id + "'";
            //        //DataTable DT = General_Helping.GetDataTable(sql1);
            //        DataTable DT = SqlHelper.ExecuteDataset(Database.ConnectionString, "select_projects_by_pmp", Session_CS.Project_id, Session_CS.pmp_id).Tables[0];
                    
            //        if (DT.Rows.Count > 0)
            //            btn_Doc.Visible = btnClear.Visible = BtnSave.Visible = true;
            //        else
            //            btn_Doc.Visible = btnClear.Visible = BtnSave.Visible = false;
            //    }
            //    else if (Session_CS.UROL_UROL_ID != null && CDataConverter.ConvertToInt(Session_CS.UROL_UROL_ID) == 2)
            //    {
            //        btn_Doc.Visible = btnClear.Visible = BtnSave.Visible = false;
            //    }


            //}

            if (CDataConverter.ConvertToInt(Session_CS.child_emp.ToString()) > 0)
            {
                Button2.Visible = true;
            }
            else
                Button2.Visible = false;


            tr_old_emp.Visible = false;
            //string sql_for_chklist_emp = " select * from pmp_fav_View where pmp_fav_View.employee_id = " + CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()) + " ORDER BY LTRIM(pmp_name)";
            //DataTable dt_emp_fav = General_Helping.GetDataTable(sql_for_chklist_emp);
            //DataTable dt_emp_fav = SqlHelper.ExecuteDataset(Database.ConnectionString, "fill_employee_chklist", Session_CS.pmp_id).Tables[0];
            //chklst_Visa_Emp_All.DataSource = dt_emp_fav;
            //chklst_Visa_Emp_All.DataBind();
            //string sql2 = " select Group_id from employee where PMP_ID = " +int.Parse( Session_CS.pmp_id.ToString());
            //DataTable DT2 = General_Helping.GetDataTable(sql2);
            // if (CDataConverter.ConvertToInt(Session_CS.group_id.ToString()) == 2 || CDataConverter.ConvertToInt(Session_CS.group_id.ToString()) == 1 || CDataConverter.ConvertToInt(Session_CS.group_id.ToString()) == 3 || CDataConverter.ConvertToInt(Session_CS.group_id.ToString()) == 4 || CDataConverter.ConvertToInt(Session_CS.group_id.ToString()) == 6 || CDataConverter.ConvertToInt(Session_CS.group_id.ToString()) == 9)
            //{
            //if (CDataConverter.ConvertToInt(Session_CS.group_id.ToString()) == 3)
            //{


            //}
            //else
            //{
            //string InsideMCIT = System.Configuration.ConfigurationManager.AppSettings["InsideMCIT"].ToString();
            //if (InsideMCIT=="1")
            //{
            //    tr_smart_proj.Visible = true;
            //}
           

            //}
          

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            TabPanel_Visa_Folow.Visible = true;
            // Button2.Visible = true;
            //tr_dr_hesham_Visa.Visible = true;
            //DataTable dt_get_dr_hesham_visa = General_Helping.GetDataTable("select * from Inbox_Track_Manager where inbox_id = " + CDataConverter.ConvertToInt(Request["id"]));
            //if (dt_get_dr_hesham_visa.Rows.Count > 0)
            //{
            //    txt_dr_hesham_visa.Text = dt_get_dr_hesham_visa.Rows[0]["visa_desc"].ToString();
            //    if (txt_dr_hesham_visa.Text != "")
            //    {
            //        txt_Visa_Desc.Text = txt_dr_hesham_visa.Text;
            //    }

            //}
            //else
            //{
            //    txt_dr_hesham_visa.Text = "";
            //}
            //}
            //else
            //{
            //    TabPanel_Visa_Folow.Visible = false;
            //    Button2.Visible = false;
            //}
            TabPanel_All.ActiveTab = TabPanel_dtl;
            //Fil_Dll();
            //Fil_Sector_Dll();
            Fill_main_Category();
            //fill_sub_category();

            //fill_sectors(); commented because it is an empty function
            //fil_emp_Visa(); commented because it databind to invisible control
            if (Session_CS.code_archiving == 1)
            {
                txt_Code.Enabled = false;
            }
            if (Request["id"] != null)
            {
                String decrypted_id = Encryption.Decrypt(Request.QueryString["id"].ToString());
                id = Convert.ToInt16(decrypted_id);

                

                hidden_Id.Value = id.ToString();
                Fill_Controll(id);
                Fil_Grid_Documents();
                Fil_Grid_Visa();
                Fil_chk_main_category(id);
                Fil_Grid_Visa_Follow();
                Fil_Emp_Visa_Follow();
                //Chk_sub_cat.Visible = true;
                if (CDataConverter.ConvertToInt(Session_CS.group_id.ToString()) == 3)
                {
                    //Smart_Search_dept.SelectedValue = "15";
                    Smart_Search_structure2.SelectedValue = "15";
                }

            }
            else
            {
                //DateTime str = CDataConverter.ConvertDateTimeNowRtnDt();//System.DateTime.Now;
                DateTime st_deadline_date = CDataConverter.ConvertDateTimeNowRtnDt().AddDays(7);
                txt_Dead_Line_DT.Text = CDataConverter.ConvertDateTimeToFormatdmy(st_deadline_date); // by youssef
                txt_Visa_date.Text = CDataConverter.ConvertDateTimeNowRtrnString(); //str.ToString("dd/MM/yyyy");
                txt_Date.Text = CDataConverter.ConvertDateTimeNowRtrnString();//str.ToString("dd/MM/yyyy");
                txt_Follow_Date.Text = CDataConverter.ConvertDateTimeNowRtrnString();//str.ToString("dd/MM/yyyy");
                //btn_print_report.Enabled = false;
                /////////////////////////////////////////////////////// to get type of code archiving ///////////////////////////////////
                //DataTable dt_code_type = Inbox_DB.Selectcode(Session_CS.foundation_id);
               

                   // try
                    //{
                        //DataTable getmax = General_Helping.GetDataTable("select isnull(max(convert( int,code)),0)+1  as code    from inbox where foundation_id=" + Session_CS.foundation_id);
                       // DataTable getmax = SqlHelper.ExecuteDataset(Database.ConnectionString, "get_max_code_inbox", Session_CS.foundation_id).Tables[0];
                       // txt_Code.Text = getmax.Rows[0]["code"].ToString();
                   // }
                   // catch
                   // {
                     //   txt_Code.Text = "1";
                   // }
               

            }

            if (Session_CS.pmp_id > 0 && Request["id"] == null)
            {
                //drop_sectors.SelectedValue = Session_CS.sec_id.ToString();
                //ddl_sectors2.SelectedValue = Session_CS.sec_id.ToString();
                //fill_depts();
                //Fil_Dll();
                //fill_depts2();
                TabPanel_All.ActiveTabIndex = 0;

            }

        }
    }


  



    //    this.Smart_Search_structure.Value_Handler += new Smart_Search.Delegate_Selected_Value(MOnMember_Data_Depart);
    //    Smart_Search_structure.sql_Connection = sql_Connection;
    //    fill_structure();
    //    base.OnInit(e);

    //}

    private void MOnMember_Data_Depart(string Value)
    {

            if (Value != "")
            {

                fill_emplyees2();
                
               
            }
            else
            {
                //       if (!chk_allow_Chn_dept.Checked)
                Smart_Emp_ID.Clear_Controls();


            }
        
    }

    private void MOnMember_Data_Depart2(string Value)
    {



        if (Value != "")
        {

           
            fill_resp_Emp();

        }
        else
        {
        


        }


    }

    protected void fill_emplyees()
    {
        //Smart_Emp_ID.sql_Connection = sql_Connection;
        //string Query = "SELECT     EMPLOYEE.PMP_ID, EMPLOYEE.pmp_name, Departments.sec_sec_id FROM         EMPLOYEE INNER JOIN                       Departments ON EMPLOYEE.Dept_Dept_id = Departments.Dept_ID  and EMPLOYEE.workstatus!=4";

        //if (Smart_Search_structure.SelectedValue != "")
        //{
        //    Query += " where Departments.Dept_ID =  " + Smart_Search_structure.SelectedValue;
        //}
        //Smart_Emp_ID.datatble = General_Helping.GetDataTable(Query);
        //// Smart_Emp_ID.Query = Query;
        //Smart_Emp_ID.Value_Field = "pmp_id";
        //Smart_Emp_ID.Text_Field = "pmp_name";
        //Smart_Emp_ID.Orderby = "ORDER BY LTRIM(pmp_name)";
        //Smart_Emp_ID.DataBind();


    }

    //public static string Decrypt(string pstrText)
    //{
    //    pstrText = pstrText.Replace(" ", "+");
    //    string pstrDecrKey = "1239;[pewGKG)NisarFidesTech";
    //    byte[] byKey = { };
    //    byte[] IV = { 18, 52, 86, 120, 144, 171, 205, 239 };
    //    byte[] inputByteArray = new byte[pstrText.Length];

    //    byKey = System.Text.Encoding.UTF8.GetBytes(pstrDecrKey.Substring(0, 8));
    //    DESCryptoServiceProvider des = new DESCryptoServiceProvider();
    //    inputByteArray = Convert.FromBase64String(pstrText);
    //    MemoryStream ms = new MemoryStream();
    //    CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(byKey, IV), CryptoStreamMode.Write);
    //    cs.Write(inputByteArray, 0, inputByteArray.Length);
    //    cs.FlushFinalBlock();
    //    System.Text.Encoding encoding = System.Text.Encoding.UTF8;
    //    return encoding.GetString(ms.ToArray());
    //}
    private void Fill_main_Category()
    {
        DataTable dt_main_cat = SqlHelper.ExecuteDataset(Database.ConnectionString, "select_main_cat_by_group", Session_CS.group_id).Tables[0];
        //DataTable dt_main_cat = General_Helping.GetDataTable(" select * from Inbox_Main_Categories where group_id = " + CDataConverter.ConvertToInt(Session_CS.group_id.ToString()));
        Chk_main_cat.DataSource = dt_main_cat;
        //ddlMainCat.DataTextField = "Name";
        //ddlMainCat.DataValueField = "id";
        Chk_main_cat.DataBind();

    }
    private void fill_sub_category()
    {
        //DataTable dt_sub_cat = General_Helping.GetDataTable(" select * from Inbox_sub_categories ");
        //Chk_sub_cat.DataSource = dt_sub_cat;
        ////ddlMainCat.DataTextField = "Name";
        ////ddlMainCat.DataValueField = "id";
        //Chk_sub_cat.DataBind();

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
    private void Fill_Controll(int id)
    {
        try
        {
            DataTable dt_inboxinside = Inbox_DB.inbox_inside_data(id);



            Inbox_DT obj = Inbox_DB.SelectByID(id);
            //if (obj.Type.ToString() == "1")
            //{
            //    if (dt_inboxinside.Rows[0]["type"].ToString() == "1")
            //    {
            //        //drop_sectors.SelectedValue = dt_inboxinside.Rows[0]["sec_sec_id"].ToString();
            //        //Fil_Dll(); commented because it is an empty function
            //        //fill_depts2(); commented because it is an empty function
            //        // ddl_Dept_ID.SelectedValue = dt_inboxinside.Rows[0]["Org_id"].ToString();
            //        //Smart_Search_mang.SelectedValue = dt_inboxinside.Rows[0]["Org_id"].ToString();
            //    }
            //}
            hidden_Id.Value = obj.ID.ToString();
            hidden_Proj_id.Value = obj.Proj_id.ToString();
            Smart_Search_Proj.SelectedValue = obj.Proj_id.ToString();
            txt_Name.Text = obj.Name;
            txt_Code.Text = obj.Code;
            txt_Date.Text = obj.Date;
            ddl_Type.SelectedValue = obj.Type.ToString();
            Type_Changed();
            if (obj.Dept_ID > 0)
                Smart_Search_structure.SelectedValue = obj.Dept_ID.ToString();
            //    // ddl_Dept_ID.SelectedValue = obj.Dept_ID.ToString();
            //    //Smart_Search_mang.SelectedValue = obj.Dept_ID.ToString();
            //fil_emp(); commented because it is an empty function

            ///////////
            fil_emp2();
            if (obj.Emp_ID > 0)
                Smart_Emp_ID.SelectedValue = obj.Emp_ID.ToString();
            if (obj.Org_Id > 0)
                Smart_Org_ID.SelectedValue = obj.Org_Id.ToString();
            // lbl_Org_Name.Text = obj.Org_Name;
            txt_Org_Out_Box_Code.Text = obj.Org_Out_Box_Code;
            txt_Org_Out_Box_DT.Text = obj.Org_Out_Box_DT;
            txt_Org_Out_Box_Person.Text = obj.Org_Out_Box_Person;
            txt_Subject.Text = obj.Subject;

            ddl_Related_Type.SelectedValue = obj.Related_Type.ToString();
            Related_type_Changed();
            Smart_Related_Id.SelectedValue = obj.Related_Id.ToString();
            txt_Notes.Text = obj.Notes;
            txt_Paper_No.Text = obj.Paper_No;
            txt_Paper_Attached.Text = obj.Paper_Attached;
            // ddl_Follow_Up_Dept_ID.SelectedValue = obj.Follow_Up_Dept_ID.ToString();
            //fil_emp_Folow_Up();
            // Smart_Follow_Up_Emp_ID.SelectedValue = obj.Follow_Up_Emp_ID.ToString();
            // txt_Follow_Up_Notes.Text = obj.Follow_Up_Notes;
            //txt_Dept_Desc.Text = obj.Dept_Desc;
            ddl_Source_Type.SelectedValue = obj.Source_Type.ToString();
            txt_Org_Dept_Name.Text = obj.Org_Dept_Name;
            //ddlMainCat.SelectedValue = (General_Helping.GetDataTable("select main_id from Inbox_sub_categories where id=" + CDataConverter.ConvertToInt(obj.sub_Cat_id)).Rows[0]["main_id"]).ToString();
            //DataTable DT3 = new DataTable();
            //DT3 = General_Helping.GetDataTable("select * from Inbox_sub_categories where main_id=" + ddlMainCat.SelectedValue);
            //ddlSubCat.DataSource = DT3;
            //ddlSubCat.DataTextField = "name";
            //ddlSubCat.DataValueField = "id";
            //ddlSubCat.DataBind();
            //ddlSubCat.SelectedValue = obj.sub_Cat_id.ToString();

            ////////////////////////   fill main and sub category of inbox letter  ///////////////////////////////////////

            DataTable dt = Inbox_DB.Inbox_cat_select(id, 1);
            if (dt.Rows.Count > 0)
            {

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Chk_main_cat.SelectedValue = dt.Rows[i]["Cat_id"].ToString();
                }



            }

        }
        catch
        { }
    }

    protected void btn_New_Org_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(txt_New_Org.Text))
        {
            SqlCommand cmd_tbl = new SqlCommand();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            cmd_tbl.Connection = con;
            cmd_tbl.CommandType = CommandType.Text;

            cmd_tbl.CommandText = " insert into Organization (Org_Desc) VALUES ('" + txt_New_Org.Text + "') select @@identity";
            con.Open();
            object obj = cmd_tbl.ExecuteScalar();
            con.Close();
            int id = CDataConverter.ConvertToInt(obj.ToString());
            Smart_Org_ID.SelectedValue = id.ToString();

        }
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        hidden_Id.Value = "";
        txt_Code.Text = "";
        Smart_Org_ID.SelectedValue = "";
        Smart_Related_Id.SelectedValue = "";
        Smart_Related_Id.Text_Field = "";
        Smart_Search_structure.SelectedValue = "0";
        Smart_Emp_ID.SelectedValue = "0";
        txt_Org_Out_Box_Code.Text = "";
        txt_Org_Out_Box_DT.Text = "";
        txt_Org_Dept_Name.Text = "";
        txt_Org_Out_Box_Person.Text = "";
       // txt_Dept_Desc.Text = "";
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
        // Session_CS.Project_id = null;

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if ((CDataConverter.ConvertToInt(ddl_Type.SelectedValue) == 2 && CDataConverter.ConvertToInt(Smart_Org_ID.SelectedValue) > 0) || CDataConverter.ConvertToInt(ddl_Type.SelectedValue) == 1 || CDataConverter.ConvertToInt(ddl_Type.SelectedValue) == 3)
        {

            if (Request["id"] == null)
            {
               
                    if (Session_CS.code_outbox == 1)
                    {
                      DataTable getmax = SqlHelper.ExecuteDataset(Database.ConnectionString, "get_max_code_inbox", Session_CS.foundation_id).Tables[0];
                        txt_Code.Text = getmax.Rows[0]["code"].ToString();
                    }
                
            }
            string datenow = "";
            int dept = 0;
            int pmp = 0;
            int group = 0;
            Inbox_DT obj = new Inbox_DT();
            obj.ID = CDataConverter.ConvertToInt(hidden_Id.Value);
            if (Smart_Search_Proj.SelectedValue != "")
            {
                obj.Proj_id = CDataConverter.ConvertToInt(Smart_Search_Proj.SelectedValue.ToString());
            }
            else
            {
                obj.Proj_id = CDataConverter.ConvertToInt(Session_CS.Project_id.ToString());
            }
            obj.Name = txt_Name.Text;



            obj.Code = txt_Code.Text;
            obj.Date = txt_Date.Text;
            if (obj.ID == 0)
            {
                datenow = CDataConverter.ConvertDateTimeNowRtrnString();//DateTime.Now.ToString();
                obj.Enter_Date = datenow;
                dept = int.Parse(Session_CS.dept_id.ToString());
                pmp = int.Parse(Session_CS.pmp_id.ToString());
                group = int.Parse(Session_CS.group_id.ToString());
                obj.Dept_Dept_id = dept;
                obj.pmp_pmp_id = pmp;
                obj.Group_id = group;

            }
            else
            {
                //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                //con.Open();
                //string sql = "select Enter_Date,Dept_Dept_id,Group_id,pmp_pmp_id from inbox where ID = " + obj.ID;
                //SqlDataAdapter da = new SqlDataAdapter(sql, con);
                //DataSet ds = new DataSet();
                //da.Fill(ds);
                DataTable dt_par = SqlHelper.ExecuteDataset(Database.ConnectionString, "get_par_by_inbox_id", obj.ID).Tables[0];
                datenow = dt_par.Rows[0]["Enter_Date"].ToString();
                dept = int.Parse(dt_par.Rows[0]["Dept_Dept_id"].ToString());
                group = int.Parse(dt_par.Rows[0]["Group_id"].ToString());
                pmp = int.Parse(dt_par.Rows[0]["pmp_pmp_id"].ToString());
                obj.Enter_Date = datenow;
                obj.Dept_Dept_id = dept;
                obj.Group_id = group;
                obj.pmp_pmp_id = pmp;
            }

            obj.Type = CDataConverter.ConvertToInt(ddl_Type.SelectedValue);
            if (CDataConverter.ConvertToInt(ddl_Type.SelectedValue) == 1)
            {
                //if (CDataConverter.ConvertToInt(ddl_Dept_ID.SelectedValue) > 0)
                //{
                //    obj.Dept_ID = CDataConverter.ConvertToInt(ddl_Dept_ID.SelectedValue);
                //    obj.Org_Id = 0;
                //}

                if (CDataConverter.ConvertToInt(Smart_Search_structure.SelectedValue) > 0)
                {
                    obj.Dept_ID = CDataConverter.ConvertToInt(Smart_Search_structure.SelectedValue);
                    obj.Org_Id = 0;
                }


                //else
                //{
                //    Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('يجب إختيار الإدارة')</script>");
                //    return;
                //}

            }
            else
            {
                obj.Dept_ID = 0;
                obj.Org_Id = CDataConverter.ConvertToInt(Smart_Org_ID.SelectedValue);
            }

            obj.Emp_ID = CDataConverter.ConvertToInt(Smart_Emp_ID.SelectedValue);

            //obj.Org_Name = lbl_Org_Name.Text;
            obj.Org_Out_Box_Code = txt_Org_Out_Box_Code.Text;
            obj.Org_Out_Box_DT = txt_Org_Out_Box_DT.Text;
            obj.Org_Out_Box_Person = txt_Org_Out_Box_Person.Text;
            obj.Subject = txt_Subject.Text;
            obj.finished = 0;
            obj.Related_Type = CDataConverter.ConvertToInt(ddl_Related_Type.SelectedValue);
            obj.Related_Id = CDataConverter.ConvertToInt(Smart_Related_Id.SelectedValue);
            obj.Notes = txt_Notes.Text;
            obj.Paper_No = txt_Paper_No.Text;
            obj.Paper_Attached = txt_Paper_Attached.Text;
            obj.Follow_Up_Dept_ID = 0;
            obj.Follow_Up_Emp_ID = 0;
            obj.Dept_Desc = "";
            obj.Source_Type = CDataConverter.ConvertToInt(ddl_Source_Type.SelectedValue);
            obj.Status = 0;
            obj.Org_Dept_Name = txt_Org_Dept_Name.Text;
            //obj.sub_Cat_id = CDataConverter.ConvertToInt(ddlSubCat.SelectedValue);

            //////////////////////////// check that the code is not repeated for group=3 ( sahar )
            string year_now = CDataConverter.ConvertDateTimeNowRtnDt().Year.ToString();
            //string year_inbox_txt = DateTime.Parse(txt_Date.Text).Year.ToString();
            string year_inbox_txt = DateTime.ParseExact(txt_Date.Text, "dd/MM/yyyy", null).Year.ToString();
            string InsideMCIT = System.Configuration.ConfigurationManager.AppSettings["InsideMCIT"].ToString();
            if (InsideMCIT == "1")
            {
                if (CDataConverter.ConvertToInt(Session_CS.group_id.ToString()) == 3)
                {
                    DataTable dt_code = General_Helping.GetDataTable("select * from inbox where code = '" + txt_Code.Text + "' and group_id = 3");
                    if (dt_code.Rows.Count > 0)
                    {
                        string year_inbox_DB = CDataConverter.ConvertToDate(dt_code.Rows[0]["Date"].ToString()).Year.ToString();
                        if (year_inbox_DB == year_inbox_txt)
                        {

                            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('هذا الكود موجود من قبل !!! من فضلك أدخل كودا أخر');", true);

                            return;
                        }

                    }

                }
            }
            obj.foundation_id = CDataConverter.ConvertToInt(Session_CS.foundation_id.ToString());
            obj.ID = Inbox_DB.Save(obj);

            

            ////// save the categories for the inbox
            // Dear Motaz please convert all these query to SP and then put all below code in another function

            string Sql_Delete = "delete from  inbox_cat where  inbox_id = " + obj.ID;
            General_Helping.ExcuteQuery(Sql_Delete);
            //inbox_cat_save
            foreach (ListItem item in Chk_main_cat.Items)
            {
                if (item.Selected)
                {
                    ////string Sql_insert = "insert into inbox_cat ( inbox_id , Cat_id ,Type,inbox_type) values ( " + obj.ID + "," + item.Value + ",1,1 " + ")";
                    ////General_Helping.ExcuteQuery(Sql_insert);
                    Inbox_DB.inbox_cat_save(CDataConverter.ConvertToInt(obj.ID), CDataConverter.ConvertToInt(item.Value), 1, 1);
                }
            }
            foreach (ListItem item in Chk_sub_cat.Items)
            {
                if (item.Selected)
                {
                    //string Sql_insert = "insert into inbox_cat ( inbox_id , Cat_id ,Type,inbox_type) values ( " + obj.ID + "," + item.Value + ",2,1 " + ")";
                    //General_Helping.ExcuteQuery(Sql_insert);
                    Inbox_DB.inbox_cat_save(CDataConverter.ConvertToInt(obj.ID), CDataConverter.ConvertToInt(item.Value), 2, 1);
                }
            }
            hidden_Id.Value = obj.ID.ToString();
            Smart_Search_Proj.SelectedValue = "";


            if (Request["id"] != null)
            {
                fill_Inbox_Visa_Follows();
            }

            int found = Session_CS.foundation_id;
            if (obj.ID > 0)
            {

                string sql_related = "";
             
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('لقد تم الحفظ بنجاح');", true);


                if (ddl_Related_Type.SelectedValue == "2")
                {

                    //sql_related = "insert into Inbox_Relations values ( " + obj.ID + "," + CDataConverter.ConvertToInt(Smart_Related_Id.SelectedValue) + ",2,1," + found + " )";
                    sql_related = "insert into Inbox_Relations values ( " + obj.ID + ",1," + CDataConverter.ConvertToInt(Smart_Related_Id.SelectedValue) + ",2," + found + " )";
                    sql_related += ", values ( " + CDataConverter.ConvertToInt(Smart_Related_Id.SelectedValue) + ",2," + obj.ID + ",1," + found + " )";


                    General_Helping.ExcuteQuery(sql_related);
                }
                else if (ddl_Related_Type.SelectedValue == "3" || ddl_Related_Type.SelectedValue == "4")
                {
                    // sql_related = "insert into Inbox_Relations values ( " + obj.ID + "," + CDataConverter.ConvertToInt(Smart_Related_Id.SelectedValue) + ",1,1," + found + " )";
                    sql_related = "insert into Inbox_Relations values ( " + obj.ID + ",1," + CDataConverter.ConvertToInt(Smart_Related_Id.SelectedValue) + ",1," + found + " )";
                    General_Helping.ExcuteQuery(sql_related);
                }


            }

            else
            {

                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('لم يتم الحفظ يرجى التأكد من البيانات ');", true);

            }
            if (ddl_Related_Type.SelectedValue == "2")
            {
                string sql = "update Outbox set Related_Type =5 , Related_Id = " + hidden_Id.Value + " where ID = " + Smart_Related_Id.SelectedValue + " and Related_Type=1";
                General_Helping.ExcuteQuery(sql);
            }

        }
        else
        {
           // Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('يجب إختيار جهة الورورد')</script>");
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('يجب إختيار جهة الورورد');", true);


        }
        Fil_Smrt_From_InBox();
        ///////////////// to make the related outbox with related type "اخري" \\\\\

        Smart_Related_Id.SelectedValue = "";

        //Session_CS.Project_id = null;
    }
    private void Fil_Dll()
    {
        //    DataTable DT = new DataTable();
        //    DT = General_Helping.GetDataTable("select * from Departments where Sec_sec_id = " + CDataConverter.ConvertToInt(drop_sectors.SelectedValue));
        //// Obj_General_Helping.SmartBindDDL(ddl_Dept_ID, DT, "Dept_ID", "Dept_name", "....اختر اسم الإدارة ....");
        //    ddl_Dept_ID.DataSource = DT;
        //    ddl_Dept_ID.DataBind();
        //    ddl_Dept_ID.Items.Insert(0, new ListItem("اختر اسم الإدارة", "0"));


    }
    private void Fil_Sector_Dll()
    {
        //DataTable DT = Sectors_DB.SelectAll(0, CDataConverter.ConvertToInt(Session_CS.foundation_id.ToString()));
        //drop_sectors.DataSource = DT;
        //drop_sectors.DataBind();
        //drop_sectors.Items.Insert(0, new ListItem("اختر اسم القطاع", "0"));
    }

    private void fill_sectors()
    {
        //DataTable dt = Sectors_DB.SelectAll(0, CDataConverter.ConvertToInt(Session_CS.foundation_id.ToString()));
        //ddl_sectors2.DataSource = dt;
        //ddl_sectors2.DataBind();
        //ddl_sectors2.Items.Insert(0, new ListItem("إختر القطاع", "0"));
    }
    protected void fill_emplyees2()
    {
        Smart_Emp_ID.sql_Connection = sql_Connection;
        
       // DataTable dtt = General_Helping.GetDataTable("SELECT     EMPLOYEE.PMP_ID, EMPLOYEE.pmp_name, Departments.sec_sec_id FROM    EMPLOYEE INNER JOIN     Departments ON EMPLOYEE.Dept_Dept_id = Departments.Dept_ID  where Departments.Dept_ID = '" + Smart_Search_structure.SelectedValue + "'");
        DataTable dtt = SqlHelper.ExecuteDataset(Database.ConnectionString, "fill_employee2", CDataConverter.ConvertToInt(Smart_Search_structure.SelectedValue)).Tables[0];
        Smart_Emp_ID.datatble = dtt;
        Smart_Emp_ID.Value_Field = "PMP_ID";
        Smart_Emp_ID.Text_Field = "pmp_name";
        Smart_Emp_ID.Clear_Controls();
        Smart_Emp_ID.DataBind();





        //Lbl_count.Text = Smart_Emp_ID.Items_Count.ToString();
        //Lbl_count.Visible = true;
        Label39.Visible = true;



    }
    private void Fil_Emp_Visa_Follow()
    {
        if (CDataConverter.ConvertToInt(hidden_Id.Value) > 0)
        {
            //DataTable DT = new DataTable();
            //string sql = " SELECT     distinct EMPLOYEE.PMP_ID, EMPLOYEE.pmp_name, Inbox_Visa.Inbox_ID " +
            //             " FROM         Inbox_Visa_Emp INNER JOIN  EMPLOYEE ON Inbox_Visa_Emp.Emp_ID = EMPLOYEE.PMP_ID INNER JOIN                      Inbox_Visa ON Inbox_Visa_Emp.Visa_Id = Inbox_Visa.Visa_Id INNER JOIN                       Inbox ON Inbox_Visa.Inbox_ID = Inbox.ID " +
            //             " where Inbox_ID=" + hidden_Id.Value;
            //DT = General_Helping.GetDataTable(sql);
            DataTable DT = SqlHelper.ExecuteDataset(Database.ConnectionString, "Fil_Emp_Visa_Follow", CDataConverter.ConvertToInt(hidden_Id.Value)).Tables[0];
            Obj_General_Helping.SmartBindDDL(ddl_Visa_Emp_id, DT, "PMP_ID", "pmp_name", "....اختر اسم الموظف ....");
        }
    }
    protected override void OnInit(EventArgs e)
    {
        #region BROWSER FOR departments
     
        int found_id = CDataConverter.ConvertToInt(Session_CS.foundation_id.ToString());
        string Query = "";
        Smart_Org_ID.sql_Connection = sql_Connection;
        //Query = "SELECT Org_ID, Org_Desc FROM Organization where foundation_id = " + found_id;
        DataTable DT = SqlHelper.ExecuteDataset(Database.ConnectionString, "get_org_by_found", Session_CS.foundation_id).Tables[0];
        Smart_Org_ID.datatble = DT;
        Smart_Org_ID.Value_Field = "Org_ID";
        Smart_Org_ID.Text_Field = "Org_Desc";
       
        Smart_Org_ID.DataBind();

        //fil_emp();

        Smart_Emp_ID.sql_Connection = sql_Connection;
        // Smart_Emp_ID.Query = "SELECT PMP_ID, pmp_name FROM EMPLOYEE ";
        Query = "SELECT PMP_ID, pmp_name FROM EMPLOYEE where foundation_id='"+CDataConverter.ConvertToInt(Session_CS.foundation_id )+"' ";
        Smart_Emp_ID.datatble = General_Helping.GetDataTable(Query);
        Smart_Emp_ID.Value_Field = "PMP_ID";
        Smart_Emp_ID.Text_Field = "pmp_name";
        Smart_Emp_ID.DataBind();

        //this.Smrt_Srch_DropDep.Value_Handler += new Smart_Search.Delegate_Selected_Value(MOnMember_Data);
        //Inbox_organization.SelectedValue;
        // fill project

        Smart_Search_Proj.sql_Connection = sql_Connection;
         string InsideMCIT = System.Configuration.ConfigurationManager.AppSettings["InsideMCIT"].ToString();
         if (InsideMCIT == "1")
         {
             tr_smart_proj.Visible = true;
             DataTable DT_proj = SqlHelper.ExecuteDataset(Database.ConnectionString, "get_all_projects").Tables[0];
             //  Smart_Search_Proj.Query = "SELECT Proj_id, Proj_Title FROM Project ";
            // Query = "SELECT Proj_id, Proj_Title FROM Project ";
             Smart_Search_Proj.datatble = DT_proj;
             Smart_Search_Proj.Value_Field = "Proj_id";
             Smart_Search_Proj.Text_Field = "Proj_Title";
             Smart_Search_Proj.DataBind();
         }

        //Smart_Search_dept.sql_Connection = sql_Connection;
        //  Smart_Search_dept.Query = " SELECT Dept_id, Dept_name FROM Departments ";
        Query = " SELECT     Departments.Dept_id, Departments.Dept_name, Sectors.foundation_id FROM Departments INNER JOIN Sectors ON Departments.Sec_sec_id = Sectors.Sec_id  where Departments.foundation_id =  " + Session_CS.foundation_id;
       // Smart_Search_dept.datatble = General_Helping.GetDataTable(Query);
        //Smart_Search_dept.Value_Field = "Dept_id";
        //Smart_Search_dept.Text_Field = "Dept_name";
        //Smart_Search_dept.DataBind();
        //this.Smart_Search_dept.Value_Handler += new Smart_Search.Delegate_Selected_Value(MOnMember_Data);
        #endregion

        this.Smart_Search_structure.Value_Handler += new Smart_Search.Delegate_Selected_Value(MOnMember_Data_Depart);
        Smart_Search_structure.sql_Connection = sql_Connection;

        this.Smart_Search_structure2.Value_Handler += new Smart_Search.Delegate_Selected_Value(MOnMember_Data_Depart2);
        
        Smart_Search_structure2.sql_Connection = sql_Connection;

        fill_structure();
        base.OnInit(e);
        

        //this.Smart_Search_mang.Value_Handler += new Smart_Search.Delegate_Selected_Value(MOnMember_Data_Depart);

    }
  
   
    private void MOnMember_Data(string Value)
    {
        dropdept_fun();

    }
    protected void dropdept_fun()
    {
        //SqlConnection conn = new SqlConnection(sql_Connection);


        //fil_emp_Visa();
        DataTable DT_emp = SqlHelper.ExecuteDataset(Database.ConnectionString, "get_employee_accoording_to_radiochek", radlst_Type.SelectedValue,Session_CS.pmp_id,Session_CS.dept_id,Session_CS.foundation_id).Tables[0];
        tr_emp_list.Visible = true;
        //string sql, sql_emp = "";

        //if (radlst_Type.SelectedValue == "1")
        //{
        //    sql_emp = " select * from pmp_fav_View where pmp_fav_View.employee_id = " + CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
        //    if (Smart_Search_structure2.SelectedValue != "")
        //    {
        //        sql_emp += " AND Dept_Dept_id = " + Smart_Search_structure2.SelectedValue;
        //    }
        //    //if (ddl_sectors2.SelectedValue != "" && ddl_sectors2.SelectedValue != "0")
        //    //{
        //    sql_emp += "  and  sec_sec_id=0";
        //    //}



        //}
        //else if (radlst_Type.SelectedValue == "2")
        //{
        //    // sql_emp = " select * from employee where dbo.EMPLOYEE.workstatus = 1";


        //    sql_emp = "SELECT     EMPLOYEE.*,Departments.* FROM Departments  INNER JOIN EMPLOYEE ON Departments.Dept_id = EMPLOYEE.Dept_Dept_id where  EMPLOYEE.PMP_ID not in(select parent_pmp_id from dbo.parent_employee) and dbo.EMPLOYEE.workstatus = 1 and EMPLOYEE.foundation_id='" + Session_CS.foundation_id + "'";

        //    if (Smart_Search_structure2.SelectedValue != "")
        //    {
        //        sql_emp += " and Dept_Dept_id = " + Smart_Search_structure2.SelectedValue;
        //    }
        //   //// if (ddl_sectors2.SelectedValue != "" && ddl_sectors2.SelectedValue != "0")
        //   //// {
        //   //     sql_emp += "and  Sectors.Sec_id=0"; //+ ddl_sectors2.SelectedValue;
        //   //// }

        //}
        //else if (radlst_Type.SelectedValue == "3")
        //{
        //    // sql_emp = " select * from employee where rol_rol_id=3  and dbo.EMPLOYEE.workstatus = 1";

        //    sql_emp = "SELECT     EMPLOYEE.*,Departments.* FROM Departments  INNER JOIN EMPLOYEE ON Departments.Dept_id = EMPLOYEE.Dept_Dept_id where dbo.EMPLOYEE.workstatus = 1 and rol_rol_id=3 and EMPLOYEE.foundation_id='" + Session_CS.foundation_id + "'";


        //    if (Smart_Search_structure2.SelectedValue != "")
        //    {
        //        sql_emp += " AND Dept_Dept_id = " + Smart_Search_structure2.SelectedValue;
        //    }

        //  //  //if (ddl_sectors2.SelectedValue != "" && ddl_sectors2.SelectedValue != "0")
        //  ////  {
        //  //  sql_emp += "and  Sectors.Sec_id="; +ddl_sectors2.SelectedValue;
        //  // // }

        //}
        //else if (radlst_Type.SelectedValue == "4")
        //{
        //    // sql_emp = " select * from employee where contact_person=1 and dbo.EMPLOYEE.workstatus = 1 ";

        //    sql_emp = "SELECT     EMPLOYEE.*,Departments.* FROM Departments  INNER JOIN EMPLOYEE ON Departments.Dept_id = EMPLOYEE.Dept_Dept_id where dbo.EMPLOYEE.workstatus = 1 and contact_person=1 and EMPLOYEE.foundation_id='" + Session_CS.foundation_id + "'";

        //    if (Smart_Search_structure2.SelectedValue != "")
        //    {
        //        sql_emp += " AND Dept_Dept_id = " + Smart_Search_structure2.SelectedValue;
        //    }

        //   //// if (ddl_sectors2.SelectedValue != "" && ddl_sectors2.SelectedValue != "0")
        //   // //{
        //   //     sql_emp += "and  Sectors.Sec_id="; + ddl_sectors2.SelectedValue;
        //   // //}

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
        TabPanel_All.ActiveTab = TabPanel_Visa;
        //DataTable dt_emp_fav = DT_emp;
        chklst_Visa_Emp_All.DataSource = DT_emp;
        chklst_Visa_Emp_All.DataBind();
        TabPanel_All.ActiveTab = TabPanel_Visa;

    }
    protected void fill_structure()
    {

        //string Query = "";
        DataTable DT_dept = SqlHelper.ExecuteDataset(Database.ConnectionString, "get_dept_by_found", Session_CS.foundation_id).Tables[0];
        //Query = "SELECT  * from    Departments  where foundation_id='" + Session_CS.foundation_id + "'";

        Smart_Search_structure.datatble = DT_dept;
        Smart_Search_structure.Value_Field = "Dept_id";
        Smart_Search_structure.Text_Field = "Dept_name";
        Smart_Search_structure.DataBind();

        Smart_Search_structure2.datatble = DT_dept;
        Smart_Search_structure2.Value_Field = "Dept_id";
        Smart_Search_structure2.Text_Field = "Dept_name";
        Smart_Search_structure2.DataBind();
    }


    protected void ddl_Type_SelectedIndexChanged(object sender, EventArgs e)
    {
        Type_Changed();

    }

    private void Type_Changed()
    {
        if (ddl_Type.SelectedValue == "1")
        {
          //  tr_Inbox_out.Visible = false;
            tr_Inbox_out.Style.Add("display", "none");
            //tr_Inbox_In.Visible = true;
            tr_Inbox_In.Style.Add("display", "block");
        }
        else if (ddl_Type.SelectedValue == "2")
        {
            tr_Inbox_In.Style.Add("display", "none");
            //tr_Inbox_In.Visible = false;

           // tr_Inbox_out.Visible = true;
            tr_Inbox_out.Style.Add("display", "block");
        }


        TabPanel_All.ActiveTab = TabPanel_dtl;
    }
    //protected void ddl_Dept_ID_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    fil_emp();
    //    fil_emp2();
    //}
    protected void drop_sectors_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Fil_Dll();
        //fill_depts2();
    }

    protected void ddl_sectors2_SelectedIndexChanged(object sender, EventArgs e)
    {

        //fill_depts();
        fill_resp_Emp();
        dropdept_fun();


    }
    protected void ddl_Follow_Up_Dept_ID_SelectedIndexChanged(object sender, EventArgs e)
    {
        //fil_emp_Folow_Up();
    }




    private void fil_emp_Visa()
    {
        int Dept_ID = CDataConverter.ConvertToInt(Smart_Search_structure2.SelectedValue);
        string sql = "SELECT ID, code FROM inbox where 1=1";
        //string sql_fav = "SELECT PMP_ID, pmp_name FROM EMPLOYEE where 1=1";
        //if (CDataConverter.ConvertToInt(Session_CS.group_id.ToString())==2)
        //{
        //    sql += " AND favorite_group <> 1";
        //    sql_fav += " AND favorite_group = 1";
        //}

        //if (Dept_ID > 0)
        //{
        //    sql += " AND Dept_Dept_id = " + Dept_ID;
        //    //sql_fav += " AND Dept_Dept_id = " + Dept_ID;

        //}
        //sql += " order by pmp_name asc";
        //sql_fav += " order by pmp_name asc";
        chklst_Visa_Emp.DataSource = General_Helping.GetDataTable(sql);
        chklst_Visa_Emp.DataBind();


        //chklst_Visa_Emp_fav.DataSource = General_Helping.GetDataTable(sql_fav);
        //chklst_Visa_Emp_fav.DataBind();

        //    Smart_Visa_Emp.sql_Connection = sql_Connection;
        //    Smart_Visa_Emp.Query = "SELECT PMP_ID, pmp_name FROM EMPLOYEE where Dept_Dept_id = " + Dept_ID;
        //    Smart_Visa_Emp.Value_Field = "PMP_ID";
        //    Smart_Visa_Emp.Text_Field = "pmp_name";
        //    Smart_Visa_Emp.DataBind();
        //}
        //else
        //    Smart_Visa_Emp.Clear_Controls();

    }


    private void fil_emp_Folow_Up()
    {
        //int Dept_ID = CDataConverter.ConvertToInt(ddl_Follow_Up_Dept_ID.SelectedValue);
        //if (Dept_ID > 0)
        //{
        //    Smart_Follow_Up_Emp_ID.sql_Connection = sql_Connection;
        //    Smart_Follow_Up_Emp_ID.Query = "SELECT PMP_ID, pmp_name FROM EMPLOYEE where Dept_Dept_id = " + Dept_ID;
        //    Smart_Follow_Up_Emp_ID.Value_Field = "PMP_ID";
        //    Smart_Follow_Up_Emp_ID.Text_Field = "pmp_name";
        //    Smart_Follow_Up_Emp_ID.DataBind();
        //}
        //else
        //    Smart_Follow_Up_Emp_ID.Clear_Controls();
    }

    private void fil_emp()
    {
        //int Dept_ID = CDataConverter.ConvertToInt(ddl_Dept_ID.SelectedValue);
        //if (Dept_ID > 0)
        //{
        //    Smart_Emp_ID.sql_Connection = sql_Connection;
        //    Smart_Emp_ID.Query = "SELECT PMP_ID, pmp_name FROM EMPLOYEE where Dept_Dept_id = " + Dept_ID;
        //    Smart_Emp_ID.Value_Field = "PMP_ID";
        //    Smart_Emp_ID.Text_Field = "pmp_name";
        //    Smart_Emp_ID.DataBind();
        //}
        //else
        //    Smart_Emp_ID.Clear_Controls();
    }

    private void fil_emp2()
    {
        int Dept_ID = CDataConverter.ConvertToInt(Smart_Search_structure.SelectedValue);
        if (Dept_ID > 0)
        {
            Smart_Emp_ID.sql_Connection = sql_Connection;

            DataTable DT = SqlHelper.ExecuteDataset(Database.ConnectionString, "get_pmp_by_dept", Session_CS.dept_id).Tables[0];
            //  Smart_Emp_ID.Query = "SELECT PMP_ID, pmp_name FROM EMPLOYEE where Dept_Dept_id = " + Dept_ID;
            //string Query = "SELECT PMP_ID, pmp_name FROM EMPLOYEE where Dept_Dept_id = " + Dept_ID;
            Smart_Emp_ID.datatble = DT;//General_Helping.GetDataTable(Query);
            Smart_Emp_ID.Value_Field = "PMP_ID";
            Smart_Emp_ID.Text_Field = "pmp_name";
            Smart_Emp_ID.DataBind();
        }
        else
            Smart_Emp_ID.Clear_Controls();
    }

    protected void fill_depts2()
    {
        //Smart_Search_mang.sql_Connection = sql_Connection;
        ////        Smart_Search_mang.Query = "select Dept_ID,Dept_name from Departments where sec_sec_id='" + drop_sectors.SelectedValue + "' ";
        //string Query = "select Dept_ID,Dept_name from Departments where sec_sec_id='" + drop_sectors.SelectedValue + "' ";
        //Smart_Search_mang.datatble = General_Helping.GetDataTable(Query);
        //Smart_Search_mang.Value_Field = "Dept_ID";
        //Smart_Search_mang.Text_Field = "Dept_name";
        //Smart_Search_mang.Orderby = "ORDER BY LTRIM(Dept_name)";
        //Smart_Search_mang.DataBind();
    }

    protected void fill_depts()
    {


        //    //////////////////////////////////////////////////////////
        //if (ddl_sectors2.SelectedValue != "0")
        //{
        //Smart_Search_dept.sql_Connection = sql_Connection;
        ////        Smart_Search_dept.Query = "select Dept_ID,Dept_name from Departments where sec_sec_id='" + ddl_sectors2.SelectedValue + "' ";
        //string Query = "select Dept_ID,Dept_name from Departments where sec_sec_id='" + ddl_sectors2.SelectedValue + "' ";
        //Smart_Search_dept.datatble = General_Helping.GetDataTable(Query);
        //Smart_Search_dept.Value_Field = "Dept_ID";
        //Smart_Search_dept.Text_Field = "Dept_name";
        //Smart_Search_dept.Orderby = "ORDER BY LTRIM(Dept_name)";
        //Smart_Search_dept.DataBind();
        //}
        //else
        //{
        //    Smart_Search_dept.Clear_Controls();
        //}


    }

    protected void ddl_Related_Type_SelectedIndexChanged(object sender, EventArgs e)
    {
        Related_type_Changed();

    }

    private void Related_type_Changed()
    {
        if (ddl_Related_Type.SelectedValue == "1")
        {
            trSmart.Style.Add("display", "none");
            //trSmart.Visible = false;
        }
        else if (ddl_Related_Type.SelectedValue == "2")
        {

            //trSmart.Visible = true;
            trSmart.Style.Add("display", "block");
            lbl_Inbox_type.Text = "رد على الصادر رقم";
            Fil_Smrt_From_OutBox();
        }
        else if (ddl_Related_Type.SelectedValue == "3")
        {

            trSmart.Style.Add("display", "block");
           // trSmart.Visible = true;
            lbl_Inbox_type.Text = " استعجال الوارد للوارد رقم";
            Fil_Smrt_From_InBox();
        }
        else if (ddl_Related_Type.SelectedValue == "4")
        {
            trSmart.Style.Add("display", "block");
            //trSmart.Visible = true;
            lbl_Inbox_type.Text = " استكمال الوارد للوارد رقم";
            Fil_Smrt_From_InBox();
        }
        else if (ddl_Related_Type.SelectedValue == "5")
        {
            trSmart.Style.Add("display", "none");
        }
        TabPanel_All.ActiveTab = TabPanel_dtl;
    }

    void Fil_Smrt_From_OutBox()
    {
        Smart_Related_Id.sql_Connection = sql_Connection;
        // Smart_Related_Id.Query = "SELECT * from vw_outbox_DateString where group_id =  " + int.Parse(Session_CS.group_id.ToString());
        //string Query = "set dateformat dmy SELECT vw_outbox_DateString.*,CONVERT(datetime, dbo.datevalid(Date)) as date1 from vw_outbox_DateString where group_id =  " + int.Parse(Session_CS.group_id.ToString());
        //if (CDataConverter.ConvertToInt(Session_CS.Project_id.ToString()) > 0)
        //{
        //    Query += " AND Proj_id = " + int.Parse(Session_CS.Project_id.ToString());
        //}
        //Query += " order by CONVERT(datetime, dbo.datevalid(Date)) desc";
        //DataTable dt = General_Helping.GetDataTable(Query);
        DataTable dt = SqlHelper.ExecuteDataset(Database.ConnectionString, "get_related_outbox_inbox_page", Session_CS.group_id,Session_CS.Project_id).Tables[0];

        Smart_Related_Id.datatble = dt;
        Smart_Related_Id.Value_Field = "id";
        Smart_Related_Id.Text_Field = "con";
        Smart_Related_Id.Show_Code = false;
        dt.DefaultView.Sort = "date1 desc";
        Smart_Related_Id.Orderby = "date1 desc";
        Smart_Related_Id.DataBind();
    }

    void Fil_Smrt_From_InBox()
    {
        Smart_Related_Id.sql_Connection = sql_Connection;
        // Smart_Related_Id.Query = "SELECT * from vw_inbox_DateSubject where group_id =  " + int.Parse(Session_CS.group_id.ToString());
        //string Query = "set dateformat dmy SELECT vw_inbox_DateSubject.*,CONVERT(datetime, dbo.datevalid(Date)) as date1 from vw_inbox_DateSubject where group_id =  " + int.Parse(Session_CS.group_id.ToString());
        //if (CDataConverter.ConvertToInt(Session_CS.Project_id.ToString()) > 0)
        //{
        //    Query += " AND Proj_id = " + int.Parse(Session_CS.Project_id.ToString());
        //}
        //Query += " order by CONVERT(datetime, dbo.datevalid(Date)) desc ";
        //DataTable dt = General_Helping.GetDataTable(Query);
        DataTable dt = SqlHelper.ExecuteDataset(Database.ConnectionString, "get_related_inbox_inbox_page", Session_CS.group_id, Session_CS.Project_id).Tables[0];
        Smart_Related_Id.datatble = dt;
        Smart_Related_Id.Value_Field = "id";
        Smart_Related_Id.Text_Field = "con";
        dt.DefaultView.Sort = "date1 desc";
        Smart_Related_Id.Show_Code = false;
        Smart_Related_Id.Orderby = "date1 desc";
        Smart_Related_Id.DataBind();
    }

    protected void btn_Doc_Click(object sender, EventArgs e)
    {
       

        SqlCommand cmd = new SqlCommand();
        SqlConnection con = new SqlConnection();
        SqlCommand cmd_local = new SqlCommand();
        SqlConnection con_local = new SqlConnection();
        con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        con_local = new SqlConnection(Session_CS.local_connectionstring);
        int out_box = 0;
        

        if (CDataConverter.ConvertToInt(hidden_Id.Value) > 0)
        {
            if (FileUpload1.HasFile)
            {
                string DocName = FileUpload1.FileName;
                string Doc_Name = System.IO.Path.GetFileNameWithoutExtension(FileUpload1.FileName);
                int dotindex = DocName.LastIndexOf(".");
                string type = DocName.Substring(dotindex, DocName.Length - dotindex);

                Stream myStream;
                int fileLen;
                StringBuilder displayString = new StringBuilder();
                fileLen = FileUpload1.PostedFile.ContentLength;
                Byte[] Input = new Byte[fileLen];
                myStream = FileUpload1.FileContent;
                myStream.Read(Input, 0, fileLen);

             Stream fss=   FileUpload1.PostedFile.InputStream;
             BinaryReader br = new BinaryReader(fss);
             byte[] bytes = br.ReadBytes((Int32)fss.Length);

                cmd.Parameters.Add("@File_data", SqlDbType.VarBinary);
                cmd.Parameters.Add("@Inbox_OutBox_File_ID", SqlDbType.Int);
                cmd.Parameters.Add("@Inbox_Outbox_ID", SqlDbType.Int);
                cmd.Parameters.Add("@Original_Or_Attached", SqlDbType.Int);
                cmd.Parameters.Add("@Inbox_Or_Outbox", SqlDbType.Int);
                cmd.Parameters.Add("@File_name", SqlDbType.NVarChar);
                cmd.Parameters.Add("@File_ext", SqlDbType.NVarChar);

                cmd.Parameters["@Inbox_OutBox_File_ID"].Value = CDataConverter.ConvertToInt(hidden_Inbox_OutBox_File_ID.Value);
                cmd.Parameters["@Original_Or_Attached"].Value = CDataConverter.ConvertToInt(ddl_Original_Or_Attached.SelectedValue);
                cmd.Parameters["@File_ext"].Value = type;
                cmd.Parameters["@File_name"].Value = txtFileName.Text; 
                cmd.Parameters["@Inbox_Or_Outbox"].Value = 1;
                cmd.CommandType = CommandType.Text;
                if (CDataConverter.ConvertToInt(hidden_Inbox_OutBox_File_ID.Value) > 0)
                {

                    cmd.CommandText = " update Inbox_OutBox_Files set Original_Or_Attached=@Original_Or_Attached ,File_data=@File_data ,File_name=@File_name,File_ext=@File_ext where Inbox_OutBox_File_ID =@Inbox_OutBox_File_ID";

                    if (string.IsNullOrEmpty(Session_CS.local_connectionstring))
                    {
                        cmd.Connection = con;
                        cmd.Parameters["@File_data"].Value = bytes;
                        cmd.Parameters["@Inbox_Outbox_ID"].Value = CDataConverter.ConvertToInt(hidden_Id.Value);
                        con.Open();
                        cmd.ExecuteScalar();
                        con.Close();
                    }
                    else
                    {
                        cmd.Connection = con;
                        cmd.Parameters["@File_data"].Value = DBNull.Value;
                        cmd.Parameters["@Inbox_Outbox_ID"].Value = CDataConverter.ConvertToInt(hidden_Id.Value);
                        con.Open();
                        cmd.ExecuteScalar();
                        con.Close();
                        try
                        {
                            cmd.Connection = con_local;
                            cmd.Parameters["@File_data"].Value = bytes;
                            cmd.Parameters["@Inbox_Outbox_ID"].Value = CDataConverter.ConvertToInt(hidden_Id.Value);

                            con_local.Open();
                            cmd.ExecuteScalar();
                            con_local.Close();
                        }
                        catch
                        {
                            // can't connect to sql local, we should show message here
                           // ShowAlertMessage(" عفوا لم يتم الإتصال بقاعدة البيانات الداخلية");
                            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('عفوا لم يتم الإتصال بقاعدة البيانات الداخلية ');", true);

                        }
                    }

                    txtFileName.Text =
                    hidden_Inbox_OutBox_File_ID.Value = "";
                }
                else
                {
                    cmd.CommandText = " insert into Inbox_OutBox_Files (Inbox_Outbox_ID, Inbox_Or_Outbox, Original_Or_Attached, File_data, File_name, File_ext) VALUES ( @Inbox_Outbox_ID, @Inbox_Or_Outbox, @Original_Or_Attached, @File_data, @File_name, @File_ext) select @@identity";

                    if (string.IsNullOrEmpty(Session_CS.local_connectionstring))
                    {
                        cmd.Connection = con;
                        cmd.Parameters["@File_data"].Value = Input;
                        cmd.Parameters["@Inbox_Outbox_ID"].Value = CDataConverter.ConvertToInt(hidden_Id.Value);
                        con.Open();
                        cmd.ExecuteScalar();
                        con.Close();

                    }
                    else
                    {

                        cmd.Connection = con;
                        cmd.Parameters["@File_data"].Value = DBNull.Value;
                        cmd.Parameters["@Inbox_Outbox_ID"].Value = CDataConverter.ConvertToInt(hidden_Id.Value);
                        con.Open();
                        out_box = CDataConverter.ConvertToInt(cmd.ExecuteScalar());
                        con.Close();
                        try
                        {
                            cmd.CommandText = " insert into Inbox_OutBox_Files ( Inbox_OutBox_File_ID,Inbox_Outbox_ID, Inbox_Or_Outbox, Original_Or_Attached, File_data,File_name, File_ext) VALUES ( @Inbox_OutBox_File_ID,@Inbox_Outbox_ID, @Inbox_Or_Outbox, @Original_Or_Attached, @File_data, @File_name, @File_ext) select @@identity";
                            cmd.Connection = con_local;
                            cmd.Parameters["@File_data"].Value = Input;
                            cmd.Parameters["@Inbox_OutBox_File_ID"].Value = out_box;
                            con_local.Open();
                            cmd.ExecuteScalar();
                            con_local.Close();


                        }
                        catch
                        {
                            // can't connect to sql local, we should show message here

                           // ShowAlertMessage(" عفوا لم يتم الإتصال بقاعدة البيانات الداخلية");
                            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('عفوا لم يتم الإتصال بقاعدة البيانات الداخلية ');", true);

                        }
                    }


                    txtFileName.Text =
                    hidden_Inbox_OutBox_File_ID.Value = "";

                }



            }





            // Clear_Cntrl();
            Fil_Grid_Documents();
            //fill_Inbox_Visa_Follows();
        }
        else
        {
            //Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('يجب إدخال بيانات الخطاب أولا')</script>");
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('يجب إدخال بيانات الخطاب أولا ');", true);


        }

    }

    protected void GrdView_Documents_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditItem")
        {
            Inbox_OutBox_Files_DT obj = Inbox_OutBox_Files_DB.SelectByID(CDataConverter.ConvertToInt(e.CommandArgument));
            if (obj.Inbox_OutBox_File_ID > 0)
            {
                hidden_Inbox_OutBox_File_ID.Value = obj.Inbox_OutBox_File_ID.ToString();
                txtFileName.Text = obj.File_name;
                ddl_Original_Or_Attached.SelectedValue = obj.Original_Or_Attached.ToString();
            }

        }

        if (e.CommandName == "RemoveItem")
        {
            Inbox_OutBox_Files_DB.Delete(CDataConverter.ConvertToInt(e.CommandArgument));
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('لقد تم الحذف بنجاح ');", true);


            Fil_Grid_Documents();
            //fill_Inbox_Visa_Follows();
        }
    }

    private void Fil_Grid_Documents()
    {
        DataTable DT = new DataTable();
        DT = SqlHelper.ExecuteDataset(Database.ConnectionString, "get_files_by_inbox_id", hidden_Id.Value).Tables[0];
        //DT = General_Helping.GetDataTable("select * from Inbox_OutBox_Files where Inbox_Or_Outbox = 1 and Inbox_Outbox_ID=" + hidden_Id.Value);

        GrdView_Documents.DataSource = DT;
        GrdView_Documents.DataBind();
    }
    private bool check_Send_mng()
    {
        //bool flag = false;
        string InsideMCIT = System.Configuration.ConfigurationManager.AppSettings["InsideMCIT"].ToString();
        if (InsideMCIT == "1" && Session_CS.pmp_id == 47)
        {
            return true;
        }

        //DataTable dt_mng_sent = General_Helping.GetDataTable("select * from Inbox_Track_Manager where inbox_id = " + CDataConverter.ConvertToInt(hidden_Id.Value));
        DataTable dt_mng_sent = SqlHelper.ExecuteDataset(Database.ConnectionString, "get_data_from_inbox_track_manager", CDataConverter.ConvertToInt(hidden_Id.Value)).Tables[0];
        //DataTable dt_emp_hasparent = General_Helping.GetDataTable("select * from parent_employee where pmp_id = " + Session_CS.pmp_id);
        DataTable dt_emp_hasparent = SqlHelper.ExecuteDataset(Database.ConnectionString, "get_data_from_parent_employee", Session_CS.pmp_id).Tables[0];

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
    protected void btn_Visa_Click(object sender, EventArgs e)
    {

        ////////// check that secretary send the inbox to the mng first befor sending visa///////////////////
        // string today = VB_Classes.Dates.Dates_Operation.date_validate(DateTime.Now.ToShortDateString());
        string today = CDataConverter.ConvertDateTimeNowRtrnString();//VB_Classes.Dates.Dates_Operation.date_validate(CDataConverter.ConvertDateTimeNowRtnDt().ToShortDateString().ToString());
        if (CDataConverter.ConvertToInt(hidden_Id.Value) > 0 && check_Send_mng())
        {
            if (lst_emp.Items.Count > 0)
            {
                //DateTime visainitial = DateTime.ParseExact(txt_Visa_date.Text, "dd/MM/yyyy", null);
                DateTime visainitial = CDataConverter.ConvertToDate(txt_Visa_date.Text);

                //DateTime visalastdate = DateTime.ParseExact(txt_Dead_Line_DT.Text, "dd/MM/yyyy", null);
                DateTime visalastdate = CDataConverter.ConvertToDate(txt_Dead_Line_DT.Text);
                if (visalastdate >= visainitial)
                {
                    Inbox_Visa_DT obj = new Inbox_Visa_DT();
                    obj.Visa_Id = CDataConverter.ConvertToInt(hidden_Visa_Id.Value);
                    obj.Inbox_ID = CDataConverter.ConvertToInt(hidden_Id.Value);
                    obj.Visa_date = txt_Visa_date.Text;
                    obj.Important_Degree = CDataConverter.ConvertToInt(ddl_Important_Degree.SelectedValue);
                    obj.Important_Degree_Txt = txt_Important_Degree_Txt.Text;
                    if (string.IsNullOrEmpty(obj.Important_Degree_Txt))
                        obj.Important_Degree_Txt = ddl_Important_Degree.SelectedItem.Text;

                    obj.Dept_ID = CDataConverter.ConvertToInt(Smart_Search_structure2.SelectedValue);
                    obj.Dept_ID_Txt = txt_Dept_ID_Txt.Text;
                    if (string.IsNullOrEmpty(obj.Dept_ID_Txt))
                        obj.Dept_ID_Txt = Smart_Search_structure2.SelectedText;

                    obj.Emp_ID = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
                    obj.Emp_ID_Txt = txt_Emp_ID_Txt.Text;
                    //if (string.IsNullOrEmpty(obj.Emp_ID_Txt))
                    //    obj.Emp_ID_Txt = Smart_Visa_Emp.SelectedText;

                    obj.Visa_Desc = txt_Visa_Desc.Text;
                    obj.Visa_Period = txt_Visa_Period.Text;
                    obj.Visa_Satus = CDataConverter.ConvertToInt(ddl_Visa_Satus.SelectedValue);
                    //obj.Follow_Up_Dept_ID = CDataConverter.ConvertToInt(ddl_Follow_Up_Dept_ID.SelectedValue);
                    //obj.Follow_Up_Emp_ID = CDataConverter.ConvertToInt(Smart_Follow_Up_Emp_ID.SelectedValue);
                    obj.Follow_Up_Notes = txt_Follow_Up_Notes.Text;
                    obj.saving_file = txt_saving_file.Text;
                    obj.Dead_Line_DT = txt_Dead_Line_DT.Text;
                    obj.Visa_Goal_ID = CDataConverter.ConvertToInt(ddl_Visa_Goal_ID.SelectedValue);
                    obj.mail_sent = 0;


                    obj.Visa_Id = Inbox_Visa_DB.Save(obj);

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
                        cmd.Parameters["@File_name"].Value = Doc_Name ;
                        cmd.Parameters["@File_ext"].Value = type;
                        cmd.Parameters["@visa_ID"].Value = obj.Visa_Id;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = " update Inbox_Visa set File_data =@File_data ,File_name=@File_name,File_ext=@File_ext where visa_ID =@visa_ID";

                        if (string.IsNullOrEmpty(Session_CS.local_connectionstring))
                        {
                            cmd.Connection = con;
                            cmd.Parameters["@File_data"].Value = Input;
                            con.Open();
                            cmd.ExecuteScalar();
                            con.Close();

                        }
                        else
                        {

                            cmd.Connection = con;
                            cmd.Parameters["@File_data"].Value = DBNull.Value;
                            con.Open();
                            cmd.ExecuteScalar();
                            con.Close();
                            try
                            {
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

                    Save_inox_Visa(obj);
                    Clear_Visa_Cntrl();
                    Fil_Grid_Visa();
                   // fil_emp_Folow_Up();
                    Fil_Emp_Visa_Follow();
                    ///////////////////////// update have visa = 1/////////////////////////////////////////////

                    Update_Have_Visa_all_emp(obj.Inbox_ID);
                    lst_emp.Items.Clear();
                }
                else
                {
                    //Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('أخر تاريخ يجب ان يكون اكبر من تاريخ التأشيره')</script>");
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('أخر تاريخ يجب ان يكون اكبر من تاريخ التأشيره');", true);

                }
                //Inbox_Visa_DT obj = new Inbox_Visa_DT();
                //obj.Visa_Id = CDataConverter.ConvertToInt(hidden_Visa_Id.Value);
                //obj.Inbox_ID = CDataConverter.ConvertToInt(hidden_Id.Value);
                //obj.Visa_date = txt_Visa_date.Text;
                //obj.Important_Degree = CDataConverter.ConvertToInt(ddl_Important_Degree.SelectedValue);
                //obj.Important_Degree_Txt = txt_Important_Degree_Txt.Text;
                //if (string.IsNullOrEmpty(obj.Important_Degree_Txt))
                //    obj.Important_Degree_Txt = ddl_Important_Degree.SelectedItem.Text;

                //obj.Dept_ID = CDataConverter.ConvertToInt(Smart_Search_dept.SelectedValue);
                //obj.Dept_ID_Txt = txt_Dept_ID_Txt.Text;
                //if (string.IsNullOrEmpty(obj.Dept_ID_Txt))
                //    obj.Dept_ID_Txt = Smart_Search_dept.SelectedText;

                //obj.Emp_ID = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
                //obj.Emp_ID_Txt = txt_Emp_ID_Txt.Text;
                ////if (string.IsNullOrEmpty(obj.Emp_ID_Txt))
                ////    obj.Emp_ID_Txt = Smart_Visa_Emp.SelectedText;

                //obj.Visa_Desc = txt_Visa_Desc.Text;
                //obj.Visa_Period = txt_Visa_Period.Text;
                //obj.Visa_Satus = CDataConverter.ConvertToInt(ddl_Visa_Satus.SelectedValue);
                ////obj.Follow_Up_Dept_ID = CDataConverter.ConvertToInt(ddl_Follow_Up_Dept_ID.SelectedValue);
                ////obj.Follow_Up_Emp_ID = CDataConverter.ConvertToInt(Smart_Follow_Up_Emp_ID.SelectedValue);
                //obj.Follow_Up_Notes = txt_Follow_Up_Notes.Text;
                //obj.saving_file = txt_saving_file.Text;
                //obj.Dead_Line_DT = txt_Dead_Line_DT.Text;
                //obj.Visa_Goal_ID = CDataConverter.ConvertToInt(ddl_Visa_Goal_ID.SelectedValue);
                //obj.mail_sent = 0;


                //obj.Visa_Id = Inbox_Visa_DB.Save(obj);

                //Save_inox_Visa(obj);
                //Clear_Visa_Cntrl();
                //Fil_Grid_Visa();
                //fil_emp_Folow_Up();
                //Fil_Emp_Visa_Follow();
                /////////////////////////// update have visa = 1/////////////////////////////////////////////

                //Update_Have_Visa_all_emp(obj.Inbox_ID);
                //lst_emp.Items.Clear();
            }
            else
            {
               // Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لا يوجد أسماء في القائمة اليسري')</script>");
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('لا يوجد أسماء في القائمة اليسري');", true);

            }
        
            



        }
        else
        {

            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('يجب إدخال بيانات الخطاب أولا');", true);


        }



    }

    public void insert_Visa_Follows()
    {
        Inbox_Visa_Follows_DT obj_follow = Inbox_Visa_Follows_DB.SelectByID(CDataConverter.ConvertToInt(hidden_Follow_ID.Value));
        obj_follow.Follow_ID = CDataConverter.ConvertToInt(hidden_Follow_ID.Value);
        obj_follow.Inbox_ID = CDataConverter.ConvertToInt(hidden_Id.Value);
        obj_follow.Descrption = txt_Visa_Desc.Text;

        //string datenow = DateTime.Now.ToShortDateString().ToString();
        string datenow = CDataConverter.ConvertDateTimeToFormatdmy(CDataConverter.ConvertDateTimeNowRtnDt());

        string date = txt_Visa_date.Text;

        obj_follow.Date = date;
        obj_follow.Entery_Date = datenow;
        obj_follow.time_follow = CDataConverter.ConvertTimeNowRtnLongTimeFormat();
        obj_follow.entery_pmp_id = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
        obj_follow.Visa_Emp_id = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
        obj_follow.Follow_ID = Inbox_Visa_Follows_DB.Save(obj_follow);
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
    protected void btn_add_Click(object sender, EventArgs e)
    {

        fill_listbox();
        TabPanel_All.ActiveTab = TabPanel_Visa;
    }
    protected void btn_delete_Click(object sender, EventArgs e)
    {
        if (lst_emp.SelectedValue == "")
        {
          //  Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('يجب اختيار موظف ليتم الحذف')</script>");

            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('يجب اختيار موظف ليتم الحذف');", true);

        }
        else
        {
            lst_emp.Items.Remove(lst_emp.SelectedItem);

            //foreach (ListItem item  in lst_emp.Items)
            //{

            //    ListItem item2 = chklst_Visa_Emp_All.Items.FindByValue(item.Value);
            //    if (item2 != null)
            //        item2.Selected = true;
            //    else item2.Selected = false;
            //}

        }
        TabPanel_All.ActiveTab = TabPanel_Visa;

    }
    private void Update_Have_Visa_all_emp(int Inbox_ID)
    {
        string sql = "update Inbox_Track_Manager set status=0,Have_Follow=0,Have_visa=1 , ";
        sql += "Visa_Desc = N'" + txt_Visa_Desc.Text + "'";
        sql += " where inbox_id =" + Inbox_ID;
        General_Helping.ExcuteQuery(sql);

        string sql_all_User = "update Inbox_Track_Emp set Inbox_Status =2 where inbox_id=" + Inbox_ID;
        General_Helping.ExcuteQuery(sql_all_User);
    }


    public  void ShowAlertMessage(string error)
    {

        Page page = HttpContext.Current.Handler as Page;
        if (page != null)
        {
            error = error.Replace("'", "\'");
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('"+error+"');", true);

           
        }
    }
    protected void btn_Visa_Follow_Click(object sender, EventArgs e)
    {
        Inbox_Visa_Follows_DT obj = Inbox_Visa_Follows_DB.SelectByID(CDataConverter.ConvertToInt(hidden_Follow_ID.Value));
        if (CDataConverter.ConvertToDate(txt_Follow_Date.Text) >= CDataConverter.ConvertToDate(txt_Date.Text))
        {
            if (CDataConverter.ConvertToInt(hidden_Id.Value) > 0)
            {
                //string today = VB_Classes.Dates.Dates_Operation.date_validate(DateTime.Now.ToShortDateString());
                string today = CDataConverter.ConvertDateTimeToFormatdmy((CDataConverter.ConvertDateTimeNowRtnDt()));
                obj.Follow_ID = CDataConverter.ConvertToInt(hidden_Follow_ID.Value);
                obj.Inbox_ID = CDataConverter.ConvertToInt(hidden_Id.Value);
                obj.Descrption = txt_Descrption.Text;

                obj.Date = txt_Follow_Date.Text;


                obj.time_follow = CDataConverter.ConvertDateTimeNowRtnDt().ToLocalTime().ToLongTimeString();
                obj.entery_pmp_id = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
                obj.Visa_Emp_id = CDataConverter.ConvertToInt(ddl_Visa_Emp_id.SelectedValue);
                obj.Type_Follow = 1;
                obj.Entery_Date = today;
                obj.Follow_ID = Inbox_Visa_Follows_DB.Save(obj);

                if (FileUpload_Visa_Follow.HasFile)
                {
                    string DocName = FileUpload_Visa_Follow.FileName;
                    int dotindex = DocName.LastIndexOf(".");
                    string type = DocName.Substring(dotindex, DocName.Length - dotindex);

                    Stream myStream;
                    int fileLen;
                    StringBuilder displayString = new StringBuilder();
                    fileLen = FileUpload_Visa_Follow.PostedFile.ContentLength;
                    Byte[] Input = new Byte[fileLen];
                    myStream = FileUpload_Visa_Follow.FileContent;
                    myStream.Read(Input, 0, fileLen);
                    SqlCommand cmd = new SqlCommand();
                    SqlConnection con = new SqlConnection();
                    SqlCommand cmd_local = new SqlCommand();
                    SqlConnection con_local = new SqlConnection();
                    con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                    con_local = new SqlConnection(Session_CS.local_connectionstring);

                    cmd.Parameters.Add("@File_data", SqlDbType.VarBinary);
                    cmd.Parameters.Add("@File_name", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@File_ext", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@Follow_ID", SqlDbType.BigInt);

                    //cmd.Parameters["@File_data"].Value = Input;
                    cmd.Parameters["@File_name"].Value = DocName;
                    cmd.Parameters["@File_ext"].Value = type;
                    cmd.Parameters["@Follow_ID"].Value = obj.Follow_ID;

                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = " update Inbox_Visa_Follows set File_data =@File_data ,File_name=@File_name,File_ext=@File_ext where Follow_ID =@Follow_ID";


                    if (string.IsNullOrEmpty(Session_CS.local_connectionstring))
                    {
                        cmd.Connection = con;
                        cmd.Parameters["@File_data"].Value = Input;
                        con.Open();
                        cmd.ExecuteScalar();
                        con.Close();

                    }
                    else
                    {

                        cmd.Connection = con;
                        cmd.Parameters["@File_data"].Value = DBNull.Value;
                        con.Open();
                        cmd.ExecuteScalar();
                        con.Close();
                        try
                        {
                            cmd.Connection = con_local;
                            cmd.Parameters["@File_data"].Value = Input;

                            con_local.Open();
                            cmd.ExecuteScalar();
                            con_local.Close();


                        }
                        catch
                        {
                            // can't connect to sql local, we should show message here

                          //  ShowAlertMessage("   عفوا لم يتم الإتصال بقاعدة البيانات الداخلية");

                            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('عفوا لم يتم الإتصال بقاعدة البيانات الداخلية');", true);

                        }
                    }



                }
                ///////////// change have follow = 1/////////////////////////////////////////////

                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                DataTable DT = new DataTable();
               // DT = General_Helping.GetDataTable("select * from Inbox_Track_Manager where inbox_id = " + hidden_Id.Value);
                DT = SqlHelper.ExecuteDataset(Database.ConnectionString, "get_data_from_inbox_track_manager", hidden_Id.Value).Tables[0];
                if (DT.Rows.Count > 0)
                {
                    conn.Open();
                    string sql = "update Inbox_Track_Manager set Have_Follow=1 where inbox_id =" + hidden_Id.Value;
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();

                }


                Clear_visa_Follow();

                Fil_Grid_Visa_Follow();
            }

            else
            {
                //Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('يجب إدخال بيانات الخطاب أولا')</script>");

                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('يجب إدخال بيانات الخطاب أولا');", true);


            }
            int id = CDataConverter.ConvertToInt(hidden_Id.Value);
            Inbox_DB.update_inbox_Track_Emp(id.ToString(), obj.Visa_Emp_id.ToString(), 2, 1);

        }
        else
        {

            //Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('تاريخ المتابعة يجب أن يكون أكبر من أو يساوي تاريخ الخطاب')</script>");

            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('تاريخ المتابعة يجب أن يكون أكبر من أو يساوي تاريخ الخطاب');", true);

        }

        //if (obj.Visa_Emp_id > 0)
        //{

        //}

    }
    protected void btn_print_report_Click(object sender, EventArgs e)
    {
        string user = Session_CS.pmp_name.ToString();
        int found_id = CDataConverter.ConvertToInt(Session_CS.foundation_id.ToString());
        if (Request.QueryString["id"] != null)
        {
            ReportDocument rd = new ReportDocument();
            string s = Server.MapPath("../Reports/InboxOutboxReport/Inbox_Data.rpt");
            rd.Load(s);
            Reports.Load_Report(rd);
            rd.SetParameterValue("@Inbox_ID", CDataConverter.ConvertToInt(hidden_Id.Value));
            rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
            rd.SetParameterValue("@user", user, "footerRep.rpt");
            rd.SetParameterValue("@found_id", found_id, "Logo_Header_pic_dynamic.rpt");

            if (rd.Rows.Count == 0)
            {
               // ShowAlertMessage("!!!!!هذا التقرير لا يوجد به بيانات للعرض !!!!");

                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('!!!!!هذا التقرير لا يوجد به بيانات للعرض !!!!');", true);

                return;
            }
            else
            {
                rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report");
            }
        }


    }
    private void Fil_Grid_Visa_Follow()
    {
        //DataTable DT = new DataTable();
        //string Sql = "SELECT Inbox_Visa_Follows.Follow_ID,Inbox_Visa_Follows.Entery_Date,Inbox_Visa_Follows.File_name,Inbox_Visa_Follows.time_follow,Inbox_Visa_Follows.Inbox_ID, Inbox_Visa_Follows.Descrption, Inbox_Visa_Follows.Date, Inbox_Visa_Follows.Visa_Emp_id, EMPLOYEE.pmp_name " +
        //             " FROM         Inbox_Visa_Follows INNER JOIN EMPLOYEE ON Inbox_Visa_Follows.Visa_Emp_id = EMPLOYEE.PMP_ID where Inbox_ID =" +CDataConverter.ConvertToInt(hidden_Id.Value);
        //DT = General_Helping.GetDataTable(Sql);

        DataTable DT = SqlHelper.ExecuteDataset(Database.ConnectionString, "get_visa_follows_for_grid", CDataConverter.ConvertToInt(hidden_Id.Value)).Tables[0];

        GridView_Visa_Follow.DataSource = DT;
        GridView_Visa_Follow.DataBind();
    }

    private void Clear_visa_Follow()
    {
        hidden_Follow_ID.Value =
        txt_Descrption.Text =
        txt_Follow_Date.Text = "";
        ddl_Visa_Emp_id.SelectedIndex = 0;
    }


    private void Save_inox_Visa(Inbox_Visa_DT obj)
    {

        string Sql_Delete = "delete from Inbox_Visa_Emp where Visa_Id =" + obj.Visa_Id;
        General_Helping.ExcuteQuery(Sql_Delete);
        string Sql_insert = "";


        foreach (ListItem item in lst_emp.Items)
        {
            //inbox_visa_emp_save
            //DataTable dt = General_Helping.GetDataTable("select * from parent_employee where pmp_id = " + CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()));

            DataTable dt = SqlHelper.ExecuteDataset(Database.ConnectionString, "get_data_from_parent_employee", Session_CS.pmp_id).Tables[0];
            if (dt.Rows.Count > 0)
            {

                //Sql_insert = "insert into Inbox_Visa_Emp ( Visa_Id , Emp_ID ,Sender_id) values ( " + obj.Visa_Id + "," + item.Value + "," + CDataConverter.ConvertToInt(dt.Rows[0]["parent_pmp_id"].ToString()) + ")";
                Inbox_DB.inbox_visa_emp_save(CDataConverter.ConvertToInt(obj.Visa_Id), CDataConverter.ConvertToInt(item.Value), CDataConverter.ConvertToInt(dt.Rows[0]["parent_pmp_id"].ToString()));

            }
            else
            {

                //Sql_insert = "insert into Inbox_Visa_Emp ( Visa_Id , Emp_ID ,Sender_id) values ( " + obj.Visa_Id + "," + item.Value + "," + CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()) + ")";
                Inbox_DB.inbox_visa_emp_save(CDataConverter.ConvertToInt(obj.Visa_Id), CDataConverter.ConvertToInt(item.Value), CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()));
            }



        }




    }

    private void Clear_Visa_Cntrl()
    {
        hidden_Visa_Id.Value = "";
        chk_ALL.Checked = false;

        //  Smart_Visa_Emp.Clear_Controls();
    }




    protected void GridView_Visa_Follow_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //string sqlformail = "SELECT parent_pmp_id from parent_employee where pmp_id =  " + int.Parse(Session_CS.pmp_id.ToString());
        //DataTable ds = General_Helping.GetDataTable(sqlformail);
        //int parent_pmp = int.Parse(ds.Rows[0]["parent_pmp_id"].ToString());

        DataTable DT = SqlHelper.ExecuteDataset(Database.ConnectionString, "get_data_from_parent_employee", Session_CS.pmp_id).Tables[0];
        int parent_pmp = CDataConverter.ConvertToInt(DT.Rows[0]["parent_pmp_id"].ToString());
        if (e.CommandName == "EditItem")
        {

            Inbox_Visa_Follows_DT obj = Inbox_Visa_Follows_DB.SelectByID(CDataConverter.ConvertToInt(e.CommandArgument));
            if (obj.Follow_ID > 0)
            {
                hidden_Follow_ID.Value = obj.Follow_ID.ToString();
                txt_Descrption.Text = obj.Descrption;
                txt_Follow_Date.Text = obj.Date;
                if (obj.Visa_Emp_id > 0)
                {

                    ddl_Visa_Emp_id.SelectedValue = obj.Visa_Emp_id.ToString();
                }


            }
        }

        if (e.CommandName == "RemoveItem")
        {
            Inbox_Visa_Follows_DB.Delete(CDataConverter.ConvertToInt(e.CommandArgument));
          //  Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم الحذف بنجاح')</script>");

            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('لقد تم الحذف بنجاح');", true);

            Fil_Grid_Visa_Follow();
        }

        if (e.CommandName == "SendItem")
        {
            ////////////////////////////////////////////////////////////////////////////////////////////
            /////////////////// Sending Mail Code /////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////

            //DataTable dt_getmail = General_Helping.GetDataTable("select mail,pmp_name from employee where pmp_id = " + parent_pmp);
            DataTable dt_getmail = SqlHelper.ExecuteDataset(Database.ConnectionString, "get_mail_pmpname_from_employee_by_parent", parent_pmp).Tables[0];
            string mail = dt_getmail.Rows[0]["mail"].ToString();
            string parent_name = dt_getmail.Rows[0]["pmp_name"].ToString();



            MailMessage _Message = new MailMessage();
            if (int.Parse(Session_CS.group_id.ToString()) == 3)
            {
                _Message.Subject = "INIR";
            }
            else
            {
                _Message.Subject = "نظام الادارة الالكترونية - المراسلات";
            }


            //_Message.BodyEncoding = Encoding.Unicode;
            _Message.BodyEncoding = Encoding.UTF8;
            _Message.SubjectEncoding = Encoding.UTF8;

            _Message.To.Add(new MailAddress(mail));



            _Message.IsBodyHtml = true;
            _Message.Body = "<html><body dir='rtl'><h3 >";

            _Message.Body += " السيد  -   ";
            _Message.Body += parent_name;
            _Message.Body += " </h3>";
            //_Message.Body += " <h1 style=text-align:right>    وصلكم وارد من نظام إدارة مشروعات قطاع البنية المعلوماتية  </h1> ";
            _Message.Body += " <h3 > إيماءً إلى الوارد من  " + Smart_Org_ID.SelectedText + " بتاريخ " + txt_Date.Text + " بخصوص " + txt_Subject.Text + " </h3>";

            bool flag = false;

            //string Sql = "SELECT     Inbox_Visa_Follows.Follow_ID, Inbox_Visa_Follows.File_data,Inbox_Visa_Follows.File_name,Inbox_Visa_Follows.File_ext,Inbox_Visa_Follows.Inbox_ID, Inbox_Visa_Follows.Descrption, Inbox_Visa_Follows.Date, Inbox_Visa_Follows.Visa_Emp_id, EMPLOYEE.pmp_name " +
            //             " FROM         Inbox_Visa_Follows INNER JOIN EMPLOYEE ON Inbox_Visa_Follows.Visa_Emp_id = EMPLOYEE.PMP_ID where Inbox_ID =" + hidden_Id.Value;
            DataTable dt = SqlHelper.ExecuteDataset(Database.ConnectionString, "get_attachment_for_mail", CDataConverter.ConvertToInt(hidden_Id.Value)).Tables[0];
            //DataTable dt = General_Helping.GetDataTable(Sql);
            string file = "";
            byte[] files = new byte[0];
            MemoryStream ms = new MemoryStream();
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
                if (CDataConverter.ConvertToInt(dr["Follow_ID"].ToString()) == CDataConverter.ConvertToInt(e.CommandArgument.ToString()))
                {
                    _Message.Body += " <h3 > فقد أفاد السيد  " + dr["pmp_name"].ToString() + "  فى تاريخ " + dr["Date"].ToString() + " بالتالى  </h3>";
                    _Message.Body += " <h3 > " + dr["Descrption"].ToString() + "  </h3>";
                }
            }


            if (flag)
                _Message.Body += "<h3 >   ومرفق الوثائق الخاصة بهذا الوارد</h3> <br /><br />";


            _Message.Body += "<h3 > مع تحيات </h3> ";
            _Message.Body += "<h3 >   " + Session_CS.e_signature.ToString() + "  </h3> ";
            _Message.Body += "</body></html>";
            String encrypted_id = Encryption.Encrypt(hidden_Id.Value);
            string address2 = System.Web.HttpContext.Current.Request.Url.Authority.ToString();
            ////SmtpClient config
            //SmtpClient Client = new SmtpClient();
            //Client.Port = int.Parse(ConfigurationManager.AppSettings["SMTP_Port"]);
            //Client.Host = ConfigurationManager.AppSettings["SMTP_Host"];
            //string UserName = ConfigurationManager.AppSettings["SMTP_UserName"];
            //string Password = ConfigurationManager.AppSettings["SMTP_Password"];
            //_Message.From = new MailAddress(ConfigurationManager.AppSettings["SMTP_FromAddress"]);

            //_Message.Attachments.Add(new Attachment("D:\\Attached.pdf"));
            //System.Net.NetworkCredential SMTPUserInfo = new System.Net.NetworkCredential(UserName, Password);

            //Client.UseDefaultCredentials = false;
            //Client.Credentials = SMTPUserInfo;
            //Client.Timeout = 1000000000;
            try
            {
                //Client.Send(_Message);
                SendingMailthread_class.Sendingmail(_Message, _Message.Subject, _Message.Body, mail, ms, file, encrypted_id, "");

            }
            catch (Exception ex)
            {
                //Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لم يتم ارسال الايميل للسيد المدير المختص بنجاح')</script>");

            }
            //Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم ارسال الايميل للسيد المدير المختص بنجاح')</script>");

          


        }


    }


    private void Save_trackmanager(int id)
    {
        //DataTable dt = General_Helping.GetDataTable("select * from parent_employee where Type=1 ");
        DataTable dt = SqlHelper.ExecuteDataset(Database.ConnectionString, "get_data_from_parent_employee_inbox_type_only").Tables[0];
        if (dt.Rows.Count > 0)
        {

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                foreach (ListItem item in lst_emp.Items)
                {
                    if (CDataConverter.ConvertToInt(item.Value) == CDataConverter.ConvertToInt(dt.Rows[i]["parent_pmp_id"].ToString()))
                    {
                        Inbox_track_manager_DT obj = new Inbox_track_manager_DT();
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
                        obj.inbox_id = Inbox_track_manager_DB.Save(obj);
                    }

                }
            }


        }
    }
    protected void GridView_Visa_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "EditItem")
        {
            Fil_Visa_Control(CDataConverter.ConvertToInt(e.CommandArgument));
            Fil_Visa_Lst(CDataConverter.ConvertToInt(e.CommandArgument));
            Fil_Visa_Lstbox(CDataConverter.ConvertToInt(e.CommandArgument));

        }

        if (e.CommandName == "RemoveItem")
        {
            Inbox_Visa_DB.Delete(CDataConverter.ConvertToInt(e.CommandArgument));
           // Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم الحذف بنجاح')</script>");
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('لقد تم الحذف بنجاح');", true);



            Fil_Grid_Visa();
            Fil_Emp_Visa_Follow();
        }

        if (e.CommandName == "SendItem")
        {
            Save_trackmanager(CDataConverter.ConvertToInt(hidden_Id.Value));
            ////////////////////////////////////////////////////////////////////////////////////////////
            /////////////////// Sending Mail Code /////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////
            string dept = Session_CS.dept.ToString();
            string name = "";
            string Succ_names = "", Failed_name = "";
           // DataTable dt_Inbox_Visa = General_Helping.GetDataTable("select * from Inbox_Visa_Emp where Visa_Id =" + e.CommandArgument.ToString());
            DataTable dt_Inbox_Visa = SqlHelper.ExecuteDataset(Database.ConnectionString, "get_emp_id_from_visa", CDataConverter.ConvertToInt(e.CommandArgument.ToString())).Tables[0];
            foreach (DataRow item in dt_Inbox_Visa.Rows)
            {
                Inbox_DB.update_inbox_Track_Emp(hidden_Id.Value, item["Emp_ID"].ToString(), 1, 1);
                //string sqlformail = "SELECT * from employee ";
                //sqlformail += " where pmp_id= " + item["Emp_ID"].ToString();
                //DataTable ds = General_Helping.GetDataTable(sqlformail);

                //DataTable DT = General_Helping.GetDataTable(sqlformail);
                DataTable dt_emp = SqlHelper.ExecuteDataset(Database.ConnectionString, "get_mail_pmpname_from_employee_by_parent", CDataConverter.ConvertToInt( item["Emp_ID"].ToString())).Tables[0];
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


                //_Message.BodyEncoding = Encoding.Unicode;
                _Message.BodyEncoding = Encoding.UTF8;
                _Message.SubjectEncoding = Encoding.UTF8;



                bool flag = false;
                string file = "";
                byte[] files = new byte[0];
                MemoryStream ms = new MemoryStream();
                //DataTable dt = General_Helping.GetDataTable("select * from Inbox_OutBox_Files where Inbox_Outbox_ID =" + hidden_Id.Value + " and Inbox_Or_Outbox =1 ");
                DataTable dt = SqlHelper.ExecuteDataset(Database.ConnectionString, "get_attachment_for_mail_visa_tab",CDataConverter.ConvertToInt( hidden_Id.Value)).Tables[0];
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

                //else
                //{
                //    _Message.Body = " السيد " + name + " \n\n";
                //    _Message.Body += " وصلكم صادر من " + dept + " " + " بتاريخ " + txt_Visa_date.Text;
                //}
                String encrypted_id = Encryption.Encrypt(hidden_Id.Value);
                string address2 = System.Web.HttpContext.Current.Request.Url.Authority.ToString();
                _Message.IsBodyHtml = true;
                _Message.Body = "<html><body dir='rtl'><h3 > السيد - " + name + " </h3>";
                _Message.Body += " <h3 > " + " وصلكم وارد من " + dept + " بتاريخ " + txt_Visa_date.Text + " بخصوص  <br/>" + "<h3 style=" + "color:blue >" + txt_Subject.Text + "</h3>" + " </h3>";
                _Message.Body += " <h3 > " + "  وتأشيرة  السيد المدير المختص أن :" + "<h3 style=" + "color:blue >" + txt_Visa_Desc.Text + "</h3>" + " </h3>";

                _Message.Body += " <h3 > ورابط الوارد هو  :<br/>";
                _Message.Body += " <h3 >http:" + "/" + "/"+address2+"/MainForm/ViewProjectInbox.aspx?id="+encrypted_id+"&1=1 </h3>";

                if (flag)
                    _Message.Body += "<h3 >  " + " ومرفق الوثائق الخاصة بهذا الوارد</h3> ";

                ////////http://localhost:4665/Projects_Management/WebForms2/ViewProjectInbox.aspx?id=5458


                _Message.Body += "<h3 > مع تحيات </h3> ";
                //_Message.Body += "<h3 >   " + Session_CS.e_signature.ToString() + "  </h3> ";
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
                    SendingMailthread_class.Sendingmail(_Message, str_subj, _Message.Body, mail, ms, file, encrypted_id, "");
                    Succ_names += name + ",";




                }
                catch (Exception ex)
                {
                    Failed_name += name + ",";

                    //Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لم يتم ارسال الايميل بنجاح' )</script>");

                }

                
            }
            string message = Show_Alert(Succ_names, Failed_name, e.CommandArgument.ToString());
            if (!string.IsNullOrEmpty(message))
            {
                Fil_Grid_Visa();


                //foreach (GridViewRow row in GridView_Visa.Rows)
                //{
                //    if (row.RowIndex != null && e.CommandArgument !="")
                //    {
                //        ImageButton img = (ImageButton)row.FindControl("ImgBtnEdit");
                //        ImageButton img2 = (ImageButton)row.FindControl("ImgBtnDelete");
                //        img.Enabled = false;
                //        img2.Enabled = false;

                //        var lbl = row.FindControl("lbl_desc") as Label;
                //        v_desc = lbl.Text;
                       
                //    }

                //}
                


                ///////////////  to store that mohammed eid send visa to employee
                Inbox_Visa_Follows_DT obj_follow = Inbox_Visa_Follows_DB.SelectByID(CDataConverter.ConvertToInt(hidden_Follow_ID.Value));
                obj_follow.Follow_ID = CDataConverter.ConvertToInt(hidden_Follow_ID.Value);
                obj_follow.Inbox_ID = CDataConverter.ConvertToInt(hidden_Id.Value);

                GridViewRow row = (GridViewRow)((ImageButton)e.CommandSource).NamingContainer;
                int xx = row.RowIndex;

                   if (row != null)
                    {
                       v_desc=  GridView_Visa.Rows[xx].Cells[3].Text;

                       Label download = (Label)row.FindControl("lbl_desc");

                       v_desc = download.Text;

                    
                    }

                obj_follow.Descrption = message + " ونص التأشيرة:   " + v_desc ;

                //string date = DateTime.Now.ToShortDateString().ToString();
                string date = CDataConverter.ConvertDateTimeToFormatdmy(CDataConverter.ConvertDateTimeNowRtnDt());
                obj_follow.Date = date;
                obj_follow.Entery_Date = date;
                obj_follow.time_follow = CDataConverter.ConvertTimeNowRtnLongTimeFormat();
               
                obj_follow.entery_pmp_id = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());

                obj_follow.Visa_Emp_id = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
                obj_follow.Follow_ID = Inbox_Visa_Follows_DB.Save(obj_follow);




                Fil_Grid_Visa_Follow();

                //SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                //DataTable DT = new DataTable();
                //DT = General_Helping.GetDataTable("select * from Inbox_Track_Manager where inbox_id = " + hidden_Id.Value);
                //if (DT.Rows.Count > 0)
                //{
                //    conn.Open();
                //    string sql = "update Inbox_Track_Manager set Have_Follow=0,All_visa_sent=0,Have_Visa=1,IS_Old_Mail=0,IS_New_Mail=0 where inbox_id =" + hidden_Id.Value;
                //    SqlCommand cmd = new SqlCommand(sql, conn);
                //    cmd.ExecuteNonQuery();
                //    conn.Close();

                //}
               // Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('" + message + "')</script>");

                GridView_Visa.Rows[xx].Cells[8].Visible = false;
                GridView_Visa.Rows[xx].Cells[9].Visible = false;
                GridView_Visa.Rows[xx].Cells[10].Visible = false;

                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('"+message+"');", true);

            }
            //Page.RegisterStartupScript("Sucess", "<script language=javascript>alert(' لقد تم ارسال الايميل بنجاح إلي " +allnames+"')</script>");
            
       


        }


    }

    private void Update_Have_Visa(string Visa_Id)
    {
        //string Sql_Visa_Sent = "select Visa_Id from Inbox_Visa where mail_sent = 1 and Visa_Id !=" + Visa_Id + " and inbox_id = " + hidden_Id.Value;
        DataTable dt_mail_sent = SqlHelper.ExecuteDataset(Database.ConnectionString, "get_mail_sent_from_visa", Visa_Id, CDataConverter.ConvertToInt(hidden_Id.Value)).Tables[0];
        int Visa_Sent_Count = dt_mail_sent.Rows.Count;
        if (Visa_Sent_Count == GridView_Visa.Rows.Count - 1)
        {
            //DataTable DT = General_Helping.GetDataTable("select * from Inbox_Track_Manager where inbox_id = " + hidden_Id.Value);

            DataTable DT = SqlHelper.ExecuteDataset(Database.ConnectionString, "get_data_from_inbox_track_manager", CDataConverter.ConvertToInt(hidden_Id.Value)).Tables[0];
            if (DT.Rows.Count > 0)
            {
                string sql = "update Inbox_Track_Manager set Have_visa=0 , All_visa_sent=1 where inbox_id =" + hidden_Id.Value;
                General_Helping.ExcuteQuery(sql);
            }
        }

    }

    private string Show_Alert(string Succ_names, string Failed_name, string visa_id)
    {
        string message = "";
        int flag = 0;
        if (!string.IsNullOrEmpty(Succ_names))
        {
            flag = 1;
            message += " لقد تم ارسال الايميل  بواسطة النظام بنجاح إلي " + Succ_names;
        }
        if (!string.IsNullOrEmpty(Failed_name))
        {
            flag = 2;
            message += " ولم يتم ارسال الايميل إلي " + Failed_name;
        }

        if (flag == 1)
        {
            Inbox_Visa_DT obj = Inbox_Visa_DB.SelectByID(CDataConverter.ConvertToInt(visa_id));
            obj.mail_sent = 1;
            Inbox_Visa_DB.Save(obj);


        }

        return message;


        //      if (!string.IsNullOrEmpty(Failed_name))
        //        Page.RegisterStartupScript("Sucess", "<script language=javascript>alert(' لم يتم ارسال الايميل إلي " + Failed_name + "')</script>");

    }
    private void Fil_Visa_Lstbox(int ID)
    {
        //string sql = "SELECT dbo.EMPLOYEE.pmp_name, dbo.Inbox_Visa_Emp.Emp_ID, dbo.Inbox_Visa_Emp.Visa_Id FROM  dbo.EMPLOYEE INNER JOIN dbo.Inbox_Visa_Emp ON dbo.EMPLOYEE.PMP_ID = dbo.Inbox_Visa_Emp.Emp_ID where dbo.Inbox_Visa_Emp.Visa_Id = " + ID;
        //DataTable dt = General_Helping.GetDataTable(sql);
        DataTable dt = SqlHelper.ExecuteDataset(Database.ConnectionString, "get_Fil_Visa_Lstbox", id).Tables[0];
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            ListItem obj = new ListItem(dt.Rows[i]["pmp_name"].ToString(), dt.Rows[i]["Emp_ID"].ToString());
            lst_emp.Items.Add(obj);


        }

    }
    protected void chk_ALL_CheckedChanged(object sender, EventArgs e)
    {
        foreach (ListItem item in chklst_Visa_Emp_All.Items)
        {
            item.Selected = chk_ALL.Checked;
        }
        TabPanel_All.ActiveTab = TabPanel_Visa;
    }
    protected void Chk_ALL_cat_CheckedChanged(object sender, EventArgs e)
    {
        //foreach (ListItem item in Chk_main_cat.Items)
        //{
        //    item.Selected = Chk_ALL_cat.Checked;
        //}
        //TabPanel_All.ActiveTab = TabPanel_dtl;
    }
    private void Fil_chk_main_category(int ID)
    {
        //string Sql_main_cat = "select * from inbox_cat where inbox_id =" + ID + " and Type =1 and inbox_type = 1";
        //DataTable DT_main_cat = SqlHelper.ExecuteDataset(Database.ConnectionString, "get_main_cat_by_inbox_id", id).Tables[0];
        //DataTable DT_main_cat = General_Helping.GetDataTable(Sql_main_cat);
        //DataTable dt_sub_cat = General_Helping.GetDataTable("select * from inbox_cat where inbox_id = " + ID + " and Type=2 and inbox_type = 1 ");
        //DataTable dt_sub_cat = SqlHelper.ExecuteDataset(Database.ConnectionString, "get_sub_cat_by_inbox_id", id).Tables[0];
        DataTable dt_all = SqlHelper.ExecuteDataset(Database.ConnectionString, "get_all_cat_sub_main", id).Tables[0];
        DataTable dt_all_subs = SqlHelper.ExecuteDataset(Database.ConnectionString, "get_all_subs", id).Tables[0];
        Chk_sub_cat.DataSource = dt_all_subs;
        Chk_sub_cat.DataBind();
        foreach (DataRow dr in dt_all.Rows)
        {
            string type = dr["type"].ToString();
            string Value = dr["Cat_id"].ToString();
            if (type == "1")
            {
                ListItem item = Chk_main_cat.Items.FindByValue(Value);
                if (item != null)
                    item.Selected = true;
            }
            else
            {
                ListItem item = Chk_sub_cat.Items.FindByValue(Value);
                if (item != null)
                    item.Selected = true;
            }
            
           // DataTable dt = General_Helping.GetDataTable(" select * from Inbox_sub_categories where main_id = " +CDataConverter.ConvertToInt( Value));
            //DataTable dt = SqlHelper.ExecuteDataset(Database.ConnectionString, "get_sub_cat_by_main_cat", CDataConverter.ConvertToInt(Value)).Tables[0];
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    ListItem obj = new ListItem(dt.Rows[i]["name"].ToString(), dt.Rows[i]["id"].ToString());
            //    Chk_sub_cat.Items.Add(obj);
            //}
            


        }
        //foreach (DataRow dr in dt_sub_cat.Rows)
        //{
        //    string Value = dr["Cat_id"].ToString();
           


        //}
    }
    private void Fil_Visa_Lst(int ID)
    {
        //string Sql_Delete = "select * from Inbox_Visa_Emp where Visa_Id =" + ID;
        //DataTable DT = General_Helping.GetDataTable(Sql_Delete);

        DataTable DT = SqlHelper.ExecuteDataset(Database.ConnectionString, "get_emp_id_from_visa", ID).Tables[0];
        foreach (DataRow dr in DT.Rows)
        {
            string Value = dr["Emp_ID"].ToString();
            ListItem item = chklst_Visa_Emp.Items.FindByValue(Value);
            if (item != null)
                item.Selected = true;


        }
        //foreach (DataRow dr in DT.Rows)
        //{
        //    string Value = dr["Emp_ID"].ToString();
        //    ListItem item = chklst_Visa_Emp_fav.Items.FindByValue(Value);
        //    if (item != null)
        //        item.Selected = true;
        //}


    }

    private void Fil_Visa_Control(int ID)
    {
        Inbox_Visa_DT obj = Inbox_Visa_DB.SelectByID(ID);
        if (obj.Visa_Id > 0)
        {
            try
            {
                hidden_Visa_Id.Value = obj.Visa_Id.ToString();
                txt_Visa_date.Text = obj.Visa_date;
                if (obj.Important_Degree > 0)
                    ddl_Important_Degree.SelectedValue = obj.Important_Degree.ToString();
                else
                    txt_Important_Degree_Txt.Text = obj.Important_Degree_Txt;
                if (obj.Dept_ID > 0)
                    //ddl_Visa_Dept_ID.SelectedValue = obj.Dept_ID.ToString();
                    Smart_Search_structure2.SelectedValue = obj.Dept_ID.ToString();
                else
                {
                    Smart_Search_structure2.Clear_Selected();
                    txt_Dept_ID_Txt.Text = obj.Dept_ID_Txt;
                }
                fil_emp_Visa();
                if (obj.Emp_ID > 0)
                {
                    ListItem item = chklst_Visa_Emp.Items.FindByValue(obj.Emp_ID.ToString());
                    //ListItem item_fav = chklst_Visa_Emp_fav.Items.FindByValue(obj.Emp_ID.ToString());
                    if (item != null)
                        item.Selected = true;
                    //if (item_fav != null)
                    //    item_fav.Selected = true;

                }
                //else
                //    txt_Emp_ID_Txt.Text = obj.Emp_ID_Txt;




                txt_Visa_Desc.Text = obj.Visa_Desc;
                txt_Visa_Period.Text = obj.Visa_Period;
                txt_saving_file.Text = obj.saving_file;
                ddl_Visa_Satus.SelectedValue = obj.Visa_Satus.ToString();
                //ddl_Follow_Up_Dept_ID.SelectedValue = obj.Follow_Up_Dept_ID.ToString();
                fil_emp_Folow_Up();
                //Smart_Follow_Up_Emp_ID.SelectedValue = obj.Follow_Up_Emp_ID.ToString();
                txt_Follow_Up_Notes.Text = obj.Follow_Up_Notes;
                txt_Dead_Line_DT.Text = obj.Dead_Line_DT;
                ddl_Visa_Goal_ID.SelectedValue = obj.Visa_Goal_ID.ToString();

            }
            catch
            { }
        }



    }

    private void Fil_Grid_Visa()
    {
        DataTable DT = new DataTable();
        DT = SqlHelper.ExecuteDataset(Database.ConnectionString, "get_inbox_visa", hidden_Id.Value).Tables[0];

       // int empid = CDataConverter.ConvertToInt(DT.Rows[0]["Emp_ID"].ToString()); 

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

    protected void btnSend_Click(object sender, EventArgs e)
    {
        if (CDataConverter.ConvertToInt(hidden_Id.Value) > 0)
        {
            if (Session_CS.pmp_id != null)
            {
                DataTable dtparent = SqlHelper.ExecuteDataset(Database.ConnectionString, "get_data_from_parent_employee", Session_CS.pmp_id).Tables[0];
                //// get Parent 
                //string sqlformail = "SELECT parent_pmp_id from parent_employee where pmp_id =  " + int.Parse(Session_CS.pmp_id.ToString());
                //DataTable ds = General_Helping.GetDataTable(sqlformail);
                int parent_pmp = CDataConverter.ConvertToInt(dtparent.Rows[0]["parent_pmp_id"].ToString());

                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                //DataTable DT = new DataTable();
                //DT = General_Helping.GetDataTable("select * from Inbox_Track_Manager where inbox_id = " + hidden_Id.Value);

                DataTable DT = SqlHelper.ExecuteDataset(Database.ConnectionString, "get_data_from_inbox_track_manager", CDataConverter.ConvertToInt(hidden_Id.Value)).Tables[0];
                if (DT.Rows.Count > 0)
                {
                    conn.Open();
                    string sql = "update Inbox_Track_Manager set status=1 , All_visa_sent=0 where inbox_id =" + hidden_Id.Value;
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();

                }
                else
                {
                    Inbox_track_manager_DT obj = new Inbox_track_manager_DT();
                    obj.inbox_id = CDataConverter.ConvertToInt(hidden_Id.Value);
                    obj.Have_Visa = 0;
                    obj.Have_Follow = 0;
                    obj.IS_New_Mail = 1;
                    obj.status = 1;
                    obj.IS_Old_Mail = 0;
                    obj.Visa_Desc = "";
                    obj.Type_Track = 1;
                    obj.pmp_id = int.Parse(Session_CS.pmp_id.ToString());
                    obj.parent_pmp_id = parent_pmp;
                    //obj.parent_pmp_id = CDataConverter.ConvertToInt(Session_CS.parent_id.ToString());
                    obj.All_visa_sent = 0;
                    obj.inbox_id = Inbox_track_manager_DB.Save(obj);
                    if (obj.inbox_id > 0)
                      //  Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم الارسال بنجاح')</script>");

                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('لقد تم الارسال بنجاح');", true);

                }

                ///////////////  to store that mohammed eid send to dr hesham the mail
                Inbox_Visa_Follows_DT obj_follow = Inbox_Visa_Follows_DB.SelectByID(CDataConverter.ConvertToInt(hidden_Follow_ID.Value));
                obj_follow.Follow_ID = CDataConverter.ConvertToInt(hidden_Follow_ID.Value);
                obj_follow.Inbox_ID = CDataConverter.ConvertToInt(hidden_Id.Value);

                obj_follow.Descrption = "تم الارسال الي المدير المختص";
                //string date = DateTime.Now.ToShortDateString().ToString();
                string date = CDataConverter.ConvertDateTimeToFormatdmy(CDataConverter.ConvertDateTimeNowRtnDt());
                obj_follow.Date = date;
                obj_follow.Entery_Date = date;
                obj_follow.time_follow = CDataConverter.ConvertTimeNowRtnLongTimeFormat(); 
                obj_follow.entery_pmp_id = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
                obj_follow.Visa_Emp_id = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
                obj_follow.Follow_ID = Inbox_Visa_Follows_DB.Save(obj_follow);
                Fil_Grid_Visa_Follow();
                ////////////////////////////////////////////////////////////////////////////////////////////
                /////////////////// Sending Mail Code /////////////////////////////////////////
                //////////////////////////////////////////////////////////////////////////////////////////



                //DataTable dt_getmail = General_Helping.GetDataTable("select mail,pmp_name from employee where pmp_id = " + parent_pmp);
                DataTable dt_getmail = SqlHelper.ExecuteDataset(Database.ConnectionString, "get_mail_pmpname_from_employee_by_parent", parent_pmp).Tables[0];
                //DataTable dt_getmail = General_Helping.GetDataTable("select mail,pmp_name from employee where pmp_id = " + CDataConverter.ConvertToInt(Session_CS.parent_id.ToString()));
                string mail = dt_getmail.Rows[0]["mail"].ToString();
                string parent_name = dt_getmail.Rows[0]["pmp_name"].ToString();

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


                //_Message.BodyEncoding = Encoding.Unicode;
                _Message.BodyEncoding = Encoding.UTF8;
                _Message.SubjectEncoding = Encoding.UTF8;

                //_Message.To.Add(new MailAddress(mail));



                _Message.IsBodyHtml = true;
                _Message.Body = "<html><body dir='rtl'><h3 >";
                _Message.Body += "  السيد";
                _Message.Body += " " + parent_name + "    </h3> ";
                // _Message.Body += " <h1 style=text-align:right>    وصلكم وارد من نظام إدارة مشروعات قطاع البنية المعلوماتية  </h1> ";

                _Message.Body += " <h3 > " + " وصلكم وارد من " + Smart_Org_ID.SelectedText + " بتاريخ " + txt_Date.Text + " بخصوص <br/>" + "<h3 style=" + "color:blue >" + txt_Subject.Text + "</h3>";
                bool flag = false;
                string file = "";
                byte[] files = new byte[0];
                MemoryStream ms = new MemoryStream();
                //DataTable dt = General_Helping.GetDataTable("select * from Inbox_OutBox_Files where Inbox_Outbox_ID =" + hidden_Id.Value + " and Inbox_Or_Outbox =1 ");
                DataTable dt = SqlHelper.ExecuteDataset(Database.ConnectionString, "get_attachment_for_mail_visa_tab", CDataConverter.ConvertToInt(hidden_Id.Value)).Tables[0];
                foreach (DataRow dr in dt.Rows)
                {

                    if (dr["File_data"] != DBNull.Value)
                    {

                        file = dr["File_name"].ToString() + dr["File_ext"].ToString();
                        files = (byte[])dr["File_data"];
                        ms = new MemoryStream(files);
                        _Message.Attachments.Add(new Attachment(ms, file));
                        if (ms.Length > 26214400)
                        {
                           // Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('حجم الملفات التابعة لهذا البريد أكبر من المسموح')</script>");

                            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('حجم الملفات التابعة لهذا البريد أكبر من المسموح');", true);

                            return;
                        }
                        flag = true;

                    }
                }

                String encrypted_id = Encryption.Encrypt(hidden_Id.Value);
                string address2 = System.Web.HttpContext.Current.Request.Url.Authority.ToString();
                _Message.Body += " <h3 > ورابط الوارد هو  :<br/>";
                _Message.Body += " <h3 >http:" + "/" + "/"+address2+"/MainForm/ViewProjectInbox.aspx?id="+encrypted_id+"&1=1 </h3>";

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

                //try
                //{
                //    _Message.To.Add(new MailAddress(mail));

                //    Client.Send(_Message);

                //}
                SendingMailthread_class.Sendingmail(_Message, _Message.Subject, _Message.Body, mail, ms, file, encrypted_id, "");
                //catch (Exception ex)
                //{

                //    Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لم يتم ارسال الايميل بنجاح')</script>");

                //}
                //Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم ارسال الايميل بنجاح')</script>");


            }
            else
            {
                //Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('يرجي الخروج و الدخول مرة اخري للنظام')</script>");

                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('يرجي الخروج و الدخول مرة اخري للنظام');", true);

                return;

            }
            ////// get Parent 
            //string sqlformail = "SELECT parent_pmp_id from parent_employee where pmp_id =  " + int.Parse(Session_CS.pmp_id.ToString());
            //DataTable ds = General_Helping.GetDataTable(sqlformail);
            //int parent_pmp = int.Parse(ds.Rows[0]["parent_pmp_id"].ToString());
            ///////////// change  is_new_mail=1 /////////////////////////////////////////////





            //////////////////// to show mohammed eid in the drop down list of employee in المسير


        }
        else
        {
           // Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('يجب إدخال بيانات الخطاب أولا')</script>");

            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('يجب إدخال بيانات الخطاب أولا');", true);


        }

    }





    public string Get_Visa_Emp(object obj)
    {
        string visa_ID = obj.ToString();
        string emp_name = "";
        DataTable DT = new DataTable();
        //DT = General_Helping.GetDataTable("SELECT EMPLOYEE.pmp_name FROM Inbox_Visa_Emp INNER JOIN EMPLOYEE ON Inbox_Visa_Emp.Emp_ID = EMPLOYEE.PMP_ID WHERE Inbox_Visa_Emp.Visa_Id  =" + visa_ID);

         DT = SqlHelper.ExecuteDataset(Database.ConnectionString, "Get_Visa_Emp", visa_ID).Tables[0];
        foreach (DataRow dr in DT.Rows)
        {
            emp_name += dr["pmp_name"].ToString() + ",";
        }
        return emp_name;

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

    protected void GridView_Visa_rw_data_bound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string temp_sql = "";
            DataTable Dt;
            string id = (string)Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Visa_Id"));
            //temp_sql = "select mail_sent from Inbox_Visa where Visa_Id=" + id;
            //Dt = General_Helping.GetDataTable(temp_sql);
             Dt = SqlHelper.ExecuteDataset(Database.ConnectionString, "Get_mail_sent_from_inbox_visa_by_visa",id).Tables[0];
            if (Dt.Rows.Count > 0)
            {
                if (Dt.Rows[0]["mail_sent"].ToString() == "1")
                {
                    CheckBox chbsent = (CheckBox)e.Row.FindControl("chkSent");
                    chbsent.Checked = true;
                }

            }
        }
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

            Inbox_Visa_Follows_DT obj_follow = Inbox_Visa_Follows_DB.SelectByID(CDataConverter.ConvertToInt(hidden_Follow_ID.Value));
            obj_follow.Follow_ID = 0;
            obj_follow.Inbox_ID = CDataConverter.ConvertToInt(hidden_Id.Value);

            obj_follow.Descrption = " تم انهاء التاشيرة " + lbl_desc.Text + " بواسطة  " + Session_CS.pmp_name.ToString();
            // string date = DateTime.Now.ToShortDateString().ToString();
            string date = CDataConverter.ConvertDateTimeToFormatdmy(CDataConverter.ConvertDateTimeNowRtnDt());
            obj_follow.Date = date;
            obj_follow.time_follow = CDataConverter.ConvertTimeNowRtnLongTimeFormat();
            obj_follow.entery_pmp_id = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());

            obj_follow.Visa_Emp_id = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
            obj_follow.Follow_ID = Inbox_Visa_Follows_DB.Save(obj_follow);
            Inbox_Visa_DT obj = Inbox_Visa_DB.SelectByID(CDataConverter.ConvertToInt(Id));
            obj.mail_sent = 1;
            Inbox_Visa_DB.Save(obj);
            Update_Have_Visa(Id);

            Fil_Grid_Visa_Follow();





        }
        Fil_Grid_Visa();
        TabPanel_All.ActiveTab = TabPanel_Visa;

    }

    protected void radlst_Type_SelectedIndexChanged(object sender, EventArgs e)
    {
        fill_resp_Emp();

    }

    private void fill_resp_Emp()
    {

        chklst_Visa_Emp_All.Items.Clear();
        lst_emp.Items.Clear();
        //chklst_Visa_Emp_All.DataBind();


        if (radlst_Type.SelectedValue != "7")
        {


            //tr_emp_list.Visible = true;
            DataTable DT_emp;
            //= SqlHelper.ExecuteDataset(Database.ConnectionString, "get_employee_accoording_to_radiochek", radlst_Type.SelectedValue, Session_CS.pmp_id, Session_CS.dept_id, Session_CS.foundation_id).Tables[0];

            SqlParameter[] sqlParams = new SqlParameter[4];

            sqlParams[0] = new SqlParameter("@radiocheck", radlst_Type.SelectedValue);
            sqlParams[1] = new SqlParameter("@pmp_id", Session_CS.pmp_id);

            if (CDataConverter.ConvertToInt(Smart_Search_structure2.SelectedValue) > 0)
                sqlParams[2] = new SqlParameter("@dept_id", CDataConverter.ConvertToInt(Smart_Search_structure2.SelectedValue));
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
        TabPanel_All.ActiveTab = TabPanel_Visa;
        //DataTable dt_emp_fav = General_Helping.GetDataTable(sql_emp);
       
        TabPanel_All.ActiveTab = TabPanel_Visa;
    }
    protected void Chk_main_cat_SelectedIndexChanged(object sender, EventArgs e)
    {
        Chk_sub_cat.Visible = true;
        DataTable dt;
        ListItem obj;
        foreach (ListItem item in Chk_main_cat.Items)
        {
            if (item.Selected)
            {
                //dt = General_Helping.GetDataTable(" select * from Inbox_sub_categories where main_id = " + item.Value);

                dt = SqlHelper.ExecuteDataset(Database.ConnectionString, "get_sub_cat_by_main_cat", item.Value).Tables[0];

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    obj = new ListItem(dt.Rows[i]["name"].ToString(), dt.Rows[i]["id"].ToString());
                    //lst_emp.Items.Add(obj);
                    if (Chk_sub_cat.Items.FindByValue(obj.Value) == null)
                    {
                        Chk_sub_cat.Items.Add(obj);
                    }


                }
            }
            else
            {
                //dt = General_Helping.GetDataTable(" select * from Inbox_sub_categories where main_id = " + item.Value);
                dt = SqlHelper.ExecuteDataset(Database.ConnectionString, "get_sub_cat_by_main_cat", item.Value).Tables[0];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    obj = new ListItem(dt.Rows[i]["name"].ToString(), dt.Rows[i]["id"].ToString());
                    //lst_emp.Items.Add(obj);


                    Chk_sub_cat.Items.Remove(obj);



                }
            }

            //item.Selected = Chk_ALL_cat.Checked;
        }

        TabPanel_All.ActiveTab = TabPanel_dtl;
    }
    private void fill_Inbox_Visa_Follows()
    {
        //Inbox_Visa_Follows_DT obj_follow = Inbox_Visa_Follows_DB.SelectByID(CDataConverter.ConvertToInt(hidden_Follow_ID.Value));
        //obj_follow.Follow_ID = CDataConverter.ConvertToInt(hidden_Follow_ID.Value);
        //obj_follow.Inbox_ID = CDataConverter.ConvertToInt(hidden_Id.Value);

        //obj_follow.Descrption = "تم التعديل في بيانات الخطاب";
        //string date = DateTime.Now.ToShortDateString().ToString();
        //obj_follow.Date = date;
        //obj_follow.time_follow = DateTime.UtcNow.ToLocalTime().ToLongTimeString();
        //obj_follow.entery_pmp_id = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
        //obj_follow.Visa_Emp_id = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
        //obj_follow.Follow_ID = Inbox_Visa_Follows_DB.Save(obj_follow);
        //Fil_Grid_Visa_Follow();
    }
}
