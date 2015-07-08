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
using System.Security.Cryptography;
using ReportsClass;
using System.Threading;


public partial class UserControls_ViewProject_Inbox : System.Web.UI.UserControl
{
    private string sql_Connection = Database.ConnectionString;
    General_Helping Obj_General_Helping = new General_Helping();
    int id;
    string v_desc;
    Thread threadObj;

    //Session_CS Session_CS = new Session_CS();

    protected void Page_Load(object sender, EventArgs e)
    {
        Smart_Search_dept.Show_OrgTree = true;

        // TESTING TANI //
        //if (!string.IsNullOrEmpty(hidden_Number.Value))
        //{
        //    string Div = "div" + hidden_Number.Value;
        //    string image = "image" + hidden_Number.Value;
        // ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(),"success", "<script language=javascript>ChangeMeCase('" + Div + "','" + image + "','" + hidden_Number.Value + "');</script>",true);
        //Page.RegisterStartupScript("Sucess", "<script language=javascript>ChangeMeCase('" + Div + "','" + image + "','" + hidden_Number.Value + "');</script>");

        //}

         if (!IsPostBack)
            {
               

                if (Request.QueryString["id"] != null)
                {
                    //string s = Request.Url.ToString();
                    //string query = QueryStringModule.Encrypt(s);

                    DateTime str = CDataConverter.ConvertDateTimeNowRtnDt();
                    DateTime str_dead = CDataConverter.ConvertDateTimeNowRtnDt().AddDays(7);
                    txt_Visa_date.Text = CDataConverter.ConvertDateTimeToFormatdmy(str);
                    txt_Dead_Line_DT.Text = CDataConverter.ConvertDateTimeToFormatdmy(str_dead);
                    txt_Follow_Date.Text = CDataConverter.ConvertDateTimeToFormatdmy(str);
                    txt_time_follow.Text = CDataConverter.ConvertTimeNowRtnLongTimeFormat();


                    //string encrypted_id = Encrypt(id.ToString());
                    //String decrypted_id = Decrypt(Session["encrypted"].ToString());

                    String decrypted_id = Encryption.Decrypt(Request.QueryString["id"].ToString());
                    id = Convert.ToInt16(decrypted_id);
                    hidden_Id.Value = id.ToString();
                    int pmp = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());


                    DataTable dt_closing = Inbox_DB.inbox_getparent_certainInbox(id);
                    if (dt_closing.Rows.Count > 0)
                    {
                        if (CDataConverter.ConvertToInt(dt_closing.Rows[0]["parent_pmp_id"].ToString()) == pmp)
                        {
                            btn_close_inbox.Visible = true;
                            btn_end_late.Visible = true;
                            lnkBtnUnderStudy.Visible = true;

                        }
                    }




                    if (CDataConverter.ConvertToInt(Session_CS.child_emp.ToString()) > 0)
                    {
                        DataTable dt_mng = Inbox_DB.getparent(Session_CS.child_emp, 1);
                        if (dt_mng.Rows.Count > 0)
                        //DataTable dt_mng = General_Helping.GetDataTable("SELECT distinct EMPLOYEE.PMP_ID, EMPLOYEE.foundation_id, EMPLOYEE.pmp_name, parent_employee.pmp_id AS child_id FROM EMPLOYEE INNER JOIN parent_employee ON EMPLOYEE.PMP_ID = parent_employee.parent_pmp_id where parent_employee.pmp_id =" + CDataConverter.ConvertToInt(Session_CS.child_emp.ToString()));
                        {
                            ListItem obj = new ListItem(dt_mng.Rows[0]["pmp_name"].ToString(), dt_mng.Rows[0]["parent_pmp_id"].ToString());
                            lst_emp.Items.Add(obj);
                        }
                    }

                   // tr_old_emp.Visible = false;
                   // tr_old_emp_resp.Visible = false;
                    string sql_for_chklist_emp = " select * from pmp_fav_View where pmp_fav_View.employee_id = " + CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()) + " ORDER BY LTRIM(pmp_name)";
                    DataTable dt_emp_fav = General_Helping.GetDataTable(sql_for_chklist_emp);
                    chklst_Visa_Emp_All.DataSource = dt_emp_fav;
                    chklst_Visa_Emp_All.DataBind();
                    //if (Session_CS.pmp_id.ToString() == "57")
                    DataTable dt = General_Helping.GetDataTable("select parent_pmp_id,pmp_id from parent_employee where pmp_id = " + CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()) + "or parent_pmp_id = " + CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()));
                    //if (dt.Rows.Count > 0)

                    if(Session_CS.pmp_id > 0)
                    {
                       // if (CDataConverter.ConvertToInt(dt.Rows[0]["parent_pmp_id"].ToString()) == CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()))
                       // {
                            Trfollow.Visible = true;
                            tr_follow_proj.Visible = true;
                            //tr_follow_date.Visible = false;
                            //tr_follow_desc.Visible = false;
                            //tr_follow_doc.Visible = false;
                            //tr_follow_person.Visible = false;
                            //tr_follow_save.Visible = false;
                            //tr_follow_proj.Visible = false;
                            //tr_follow_time.Visible = false;
                           // SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                           // DataTable DT = new DataTable();
                          //  DT = General_Helping.GetDataTable("select * from Inbox_Track_Manager where inbox_id = " + id);
                            //if (DT.Rows.Count > 0)
                            //{
                            //    //foreach (DataRow rw in DT.Rows)
                            //    //{
                            //    DataRow rw = DT.Rows[0];
                            //    if (rw["status"].ToString() != "2")
                            //    {
                            //        if (rw["Have_visa"].ToString() != "1")
                            //            lnkBtnUnderStudy.Visible = true;

                            //    }
                            //    //if (CDataConverter.ConvertToInt(Session_CS.group_id.ToString()) == 3)
                            //    //{
                            //    //    if (rw["IS_New_Mail"].ToString() != "3")
                            //    //    {
                            //    //        conn.Open();
                            //    //        string sql = "update Inbox_Track_Manager set status=0,Have_Follow=0 where inbox_id =" + id;
                            //    //        SqlCommand cmd = new SqlCommand(sql, conn);
                            //    //        cmd.ExecuteNonQuery();
                            //    //        conn.Close();
                            //    //    }
                            //    //}

                            //    // }

                            //}
                        }
                        //else
                        //{
                        //    tr_mngr1.Visible =
                        //   tr_mngr2.Visible = false;
                        //    GridView_Visa.Columns[6].Visible = false;

                        //}
                   // }
                    else
                    {
                        // tr_mngr1.Visible =
                        //tr_mngr2.Visible = false;

                        // GridView_Visa.Columns[6].Visible = false;
                        DataTable dt_proj = General_Helping.GetDataTable(" select Proj_id from inbox where ID = " + id);
                        Smart_Search_proj.sql_Connection = sql_Connection;
                        if (dt_proj.Rows.Count > 0 && CDataConverter.ConvertToInt(dt_proj.Rows[0]["Proj_id"].ToString()) > 0)
                        {


                           // Smart_Search_proj.SelectedValue = dt_proj.Rows[0]["Proj_id"].ToString();

                        }
                        ///////// commented By nora //////////////
                        //else
                        //{
                        //    string sql = "";
                        //    string Main_sql = " SELECT  dbo.Project.Proj_id, dbo.Project.pmp_pmp_id, dbo.Project.Proj_Title, dbo.EMPLOYEE.pmp_name, dbo.Project.Proj_InitValue, dbo.Project.Proj_Notes,dbo.Protocol_Main_Def.Name, dbo.Protocol_Main_Def.Protocol_ID FROM dbo.Project LEFT OUTER JOIN dbo.Protocol_Main_Def ON dbo.Project.Protocol_ID = dbo.Protocol_Main_Def.Protocol_ID LEFT OUTER JOIN dbo.EMPLOYEE ON dbo.Project.pmp_pmp_id = dbo.EMPLOYEE.PMP_ID where 1=1  ";
                        //    if (Session_CS.UROL_UROL_ID != null && Session_CS.UROL_UROL_ID.ToString() == "4")
                        //    {
                        //        string Sql_Edit_Project = " or (Project.Proj_id IN (SELECT     Project_Team.proj_proj_id FROM Project_Team INNER JOIN Project ON Project_Team.proj_proj_id = Project.Proj_id  WHERE     (Edit_Project = 'true') AND (Project.Proj_is_commit = 2) and(Project_Team.pmp_pmp_id = " + Session_CS.pmp_id.ToString() + "))) ";
                        //        sql = Main_sql + " and Proj_is_commit = 2  and   pmp_pmp_id = " + Session_CS.pmp_id.ToString() + Sql_Edit_Project;
                        //    }
                        //    else if (Session_CS.UROL_UROL_ID != null && Session_CS.UROL_UROL_ID.ToString() == "3")
                        //    {

                        //        string Sql_Edit_Project = " or (Project.Proj_id IN (SELECT Project_Team.proj_proj_id FROM  Project_Team INNER JOIN Project ON Project_Team.proj_proj_id = Project.Proj_id  WHERE     (Edit_Project = 'true') AND (Project.Proj_is_commit = 2) and(Project_Team.pmp_pmp_id = " + Session_CS.pmp_id.ToString() + "))) ";
                        //        string sql_Proj_Deprts = " or Project.Dept_Dept_id in (select Dept_id from EMPLOYEE_Departemnts where PMP_ID = " + Session_CS.pmp_id.ToString() + ") and Proj_is_commit = 2 ";
                        //        sql = Main_sql + " and Proj_is_commit = 2 and  (pmp_pmp_id = " + Session_CS.pmp_id.ToString() + " or Project.Dept_Dept_id = " + Session_CS.dept_id.ToString() + ")" + sql_Proj_Deprts + Sql_Edit_Project;
                        //    }
                        //    else if (Session_CS.UROL_UROL_ID != null && Session_CS.UROL_UROL_ID.ToString() == "2")
                        //    {
                        //        sql = Main_sql + "and Proj_is_commit = 2 ";
                        //    }
                        //    if (sql != "")
                        //    {
                        //        Smart_Search_proj.datatble = General_Helping.GetDataTable(sql);
                        //        Smart_Search_proj.Value_Field = "Proj_id";
                        //        Smart_Search_proj.Text_Field = "Proj_Title";
                        //        Smart_Search_proj.DataBind();
                        //    }

                        //    //if (pmp == 70)
                        //    //{
                        //    //    //Trfollow.Visible = false;
                        //    //    tr_follow_date.Visible = false;
                        //    //    tr_follow_desc.Visible = false;
                        //    //    tr_follow_doc.Visible = false;
                        //    //    tr_follow_person.Visible = false;
                        //    //    tr_follow_save.Visible = false;
                        //    //    tr_follow_proj.Visible = false;
                        //    //    //     tr_mngr1.Visible =
                        //    //    //tr_mngr2.Visible = true;
                        //    //    //     GridView_Visa.Columns[6].Visible = true;
                        //    //}
                        //}
                    }
                    //}
                    //else
                    //{
                    //tr_mngr1.Visible =
                    //    tr_mngr2.Visible = true;
                    //GridView_Visa.Columns[6].Visible = false;
                    // }
                    //DataTable dt_follow = General_Helping.GetDataTable("select * from inbox_follow_emp where inbox_id=" + id + "AND pmp_id = " + pmp);
                    //if (dt_follow.Rows.Count > 0)
                    //{
                    //    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                    //    conn.Open();

                   SqlParameter[] sqlParams = new SqlParameter[] 
                {
                   new SqlParameter("@inbox_id", id),
                  
                   new SqlParameter("@pmp",pmp)        
               };

              int row =  DatabaseFunctions.UpdateData(sqlParams,"update_inbox_follow");
              if (row > 0)
              { }
                    //string sql_update = "update inbox_follow_emp set Have_follow = 0";
                    //sql_update += " where ( inbox_follow_emp.pmp_id =" + pmp;
                    //sql_update += " AND inbox_follow_emp.inbox_id = " + id;
                    //sql_update += ")";
                    //General_Helping.ExcuteQuery(sql_update);
                    //    SqlCommand cmd = new SqlCommand(sql_update, conn);
                    //    cmd.ExecuteNonQuery();
                    //    conn.Close();

                    //}
                    Fill_Controll(id);
                    Fil_Grid_Documents();
                    Fil_Grid_Visa_Follow();
                    Fil_Dll();
                    //fil_emp_Visa();
                    Fil_Emp_Visa_Follow();
                    Fil_Grid_Visa();
                    //if (CDataConverter.ConvertToInt(Session_CS.group_id.ToString()) == 3)
                    //{
                    //    Smart_Search_dept.SelectedValue = "15";
                    //}

                }

                //if (CDataConverter.ConvertToInt(Session_CS.parent_id.ToString()) > 0)
                //{
                //    lnkBtnUnderStudy.Visible = true;
                //}
                //else
                //    lnkBtnUnderStudy.Visible = false;



                if (Session_CS.pmp_id > 0)
                {
                    //drop_sectors.SelectedValue = Session_CS.sec_id.ToString();
                    fill_depts();



                }


            }

        }


    private void fill_sectors()
    {
        //DataTable dt = Sectors_DB.SelectAll(0, CDataConverter.ConvertToInt(Session_CS.foundation_id.ToString()));
        //drop_sectors.DataSource = dt;

        //drop_sectors.DataBind();
        //drop_sectors.Items.Insert(0, new ListItem("إختر القطاع", "0"));

    }

    protected void fill_depts()
    {
       // if (drop_sectors.SelectedValue != "0")
       // {
            Smart_Search_dept.sql_Connection = sql_Connection;
       
          //  string Query = "select Dept_ID,Dept_name from Departments where sec_sec_id='" + drop_sectors.SelectedValue + "' ";

            string Query = "SELECT  * from    Departments  where foundation_id='" + Session_CS.foundation_id + "'";
            Smart_Search_dept.datatble = General_Helping.GetDataTable(Query);
            Smart_Search_dept.Value_Field = "Dept_ID";
            Smart_Search_dept.Text_Field = "Dept_name";
            Smart_Search_dept.Orderby = "ORDER BY LTRIM(Dept_name)";
            Smart_Search_dept.DataBind();
    //    }

        //else
        //{
        //    Smart_Search_dept.Clear_Controls();
        //}

        //////////////////////////////////////////////////////////


    }

    //protected void drop_sectors_SelectedIndexChanged(object sender, EventArgs e)
    //{

    //   // fill_depts();
    //    //fill_resp_Emp();

    //}

    public static string Decode(string decodeMe)
    {
        byte[] encoded = Convert.FromBase64String(decodeMe);
        return System.Text.Encoding.UTF8.GetString(encoded);
    }
    //public static string Encrypt(string pstrText)
    //{
    //    string pstrEncrKey = "1239;[pewGKG)NisarFidesTech";
    //    byte[] byKey = { };
    //    byte[] IV = { 18, 52, 86, 120, 144, 171, 205, 239 };
    //    byKey = System.Text.Encoding.UTF8.GetBytes(pstrEncrKey.Substring(0, 8));
    //    DESCryptoServiceProvider des = new DESCryptoServiceProvider();
    //    byte[] inputByteArray = Encoding.UTF8.GetBytes(pstrText);
    //    MemoryStream ms = new MemoryStream();
    //    CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(byKey, IV), CryptoStreamMode.Write);
    //    cs.Write(inputByteArray, 0, inputByteArray.Length);
    //    cs.FlushFinalBlock();
    //    return Convert.ToBase64String(ms.ToArray());
    //}
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
    protected void radlst_Type_SelectedIndexChanged(object sender, EventArgs e)
    {
        fill_resp_Emp();
    }

    private void fill_resp_Emp()
    {
        //this.Smart_Search_dept.Value_Handler += new Smart_Search.Delegate_Selected_Value(MOnMember_Data);
       
            //= SqlHelper.ExecuteDataset(Database.ConnectionString, "get_employee_accoording_to_radiochek", radlst_Type.SelectedValue, Session_CS.pmp_id, Session_CS.dept_id, Session_CS.foundation_id).Tables[0];

       



        //SqlParameter[] sqlParams = new SqlParameter[] 
        //        {
        //            new SqlParameter("@radiocheck", radlst_Type.SelectedValue),
                  
        //          new SqlParameter("@pmp_id",Session_CS.pmp_id),
        //           new SqlParameter("@dept_id",CDataConverter.ConvertToInt( Smart_Search_dept.SelectedValue)),
        //           new SqlParameter("@found_id",Session_CS.foundation_id)
        //           //if(CDataConverter.ConvertToInt( Smart_Search_dept.SelectedValue) > 0)
                       
                   
         //  };

        chklst_Visa_Emp_All.Items.Clear();
     //   lst_emp.Items.Clear();


        //chklst_Visa_Emp_All.DataBind();


        if (radlst_Type.SelectedValue != "7")
        {
            

            //tr_emp_list.Visible = true;
            DataTable DT_emp;
            //= SqlHelper.ExecuteDataset(Database.ConnectionString, "get_employee_accoording_to_radiochek", radlst_Type.SelectedValue, Session_CS.pmp_id, Session_CS.dept_id, Session_CS.foundation_id).Tables[0];

            SqlParameter[] sqlParams = new SqlParameter[4];

            sqlParams[0] = new SqlParameter("@radiocheck", radlst_Type.SelectedValue);
            sqlParams[1] = new SqlParameter("@pmp_id", Session_CS.pmp_id);

            if (CDataConverter.ConvertToInt(Smart_Search_dept.SelectedValue) > 0)
                sqlParams[2] = new SqlParameter("@dept_id", CDataConverter.ConvertToInt(Smart_Search_dept.SelectedValue));
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

    protected void btn_add_Click(object sender, EventArgs e)
    {

        fill_listbox();
        //TabPanel_All.ActiveTab = TabPanel_Visa;
    }
    public void fill_listbox()
    {
        foreach (ListItem item in chklst_Visa_Emp_All.Items)
        {
            if (item.Selected)
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
    protected void btn_delete_Click(object sender, EventArgs e)
    {
        if (lst_emp.SelectedValue == "")
        {
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('يجب اختيار موظف ليتم الحذف')</script>");

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
        //TabPanel_All.ActiveTab = TabPanel_Visa;

    }
    protected void chk_ALL_CheckedChanged(object sender, EventArgs e)
    {
        foreach (ListItem item in chklst_Visa_Emp_All.Items)
        {
            item.Selected = chk_ALL.Checked;
       
        }
        //TabPanel_All.ActiveTab = TabPanel_Visa;
    }
    protected override void OnInit(EventArgs e)
    {
        #region BROWSER FOR departments
        //string Query = "";

        Smart_Search_proj.sql_Connection = sql_Connection;
        string InsideMCIT = System.Configuration.ConfigurationManager.AppSettings["InsideMCIT"].ToString();
        if (InsideMCIT == "1")
        {

            string sql = "";
            string Main_sql = " SELECT  dbo.Project.Proj_id, dbo.Project.pmp_pmp_id, dbo.Project.Proj_Title, dbo.EMPLOYEE.pmp_name, dbo.Project.Proj_InitValue, dbo.Project.Proj_Notes,dbo.Protocol_Main_Def.Name, dbo.Protocol_Main_Def.Protocol_ID FROM dbo.Project LEFT OUTER JOIN dbo.Protocol_Main_Def ON dbo.Project.Protocol_ID = dbo.Protocol_Main_Def.Protocol_ID LEFT OUTER JOIN dbo.EMPLOYEE ON dbo.Project.pmp_pmp_id = dbo.EMPLOYEE.PMP_ID where 1=1  ";
            if (Session_CS.UROL_UROL_ID != null && Session_CS.UROL_UROL_ID.ToString() == "4")
            {
                string Sql_Edit_Project = " or (Project.Proj_id IN (SELECT Project_Team.proj_proj_id FROM Project_Team INNER JOIN Project ON Project_Team.proj_proj_id = Project.Proj_id  WHERE     (Edit_Project = 'true') AND (Project.Proj_is_commit = 2) and(Project_Team.pmp_pmp_id = " + Session_CS.pmp_id.ToString() + "))) ";
                sql = Main_sql + " and Proj_is_commit = 2  and   pmp_pmp_id = " + Session_CS.pmp_id.ToString() + Sql_Edit_Project;
            }
            else if (Session_CS.UROL_UROL_ID != null && Session_CS.UROL_UROL_ID.ToString() == "3")
            {

                string Sql_Edit_Project = " or (Project.Proj_id IN (SELECT Project_Team.proj_proj_id FROM  Project_Team INNER JOIN Project ON Project_Team.proj_proj_id = Project.Proj_id  WHERE     (Edit_Project = 'true') AND (Project.Proj_is_commit = 2) and(Project_Team.pmp_pmp_id = " + Session_CS.pmp_id.ToString() + "))) ";
                string sql_Proj_Deprts = " or Project.Dept_Dept_id in (select Dept_id from EMPLOYEE_Departemnts where PMP_ID = " + Session_CS.pmp_id.ToString() + ") and Proj_is_commit = 2 ";
                sql = Main_sql + " and Proj_is_commit = 2 and  (pmp_pmp_id = " + Session_CS.pmp_id.ToString() + " or Project.Dept_Dept_id = " + Session_CS.dept_id.ToString() + ")" + sql_Proj_Deprts + Sql_Edit_Project;
            }
            else if (Session_CS.UROL_UROL_ID != null && Session_CS.UROL_UROL_ID.ToString() == "2")
            {
                sql = Main_sql + "and Proj_is_commit = 2 ";
            }
            if (sql != "")
            {
                Smart_Search_proj.datatble = General_Helping.GetDataTable(sql);
                Smart_Search_proj.Value_Field = "Proj_id";
                Smart_Search_proj.Text_Field = "Proj_Title";
                Smart_Search_proj.DataBind();
            }

        }


        //Smart_Search_proj.sql_Connection = sql_Connection;
        ////Smart_Search_proj.Query = "SELECT Proj_id, Proj_Title FROM Project ";
        //string Query = "SELECT Proj_id, Proj_Title FROM Project ";
        //Smart_Search_proj.datatble = General_Helping.GetDataTable(Query);
        //Smart_Search_proj.Value_Field = "Proj_id";
        //Smart_Search_proj.Text_Field = "Proj_Title";
        //Smart_Search_proj.DataBind();

        Smart_Search_dept.sql_Connection = sql_Connection;
        //Smart_Search_dept.Query = "SELECT Dept_id, Dept_name FROM Departments ";
        // Query = "SELECT Dept_id, Dept_name FROM Departments"; 

        Smart_Search_dept.datatble = SqlHelper.ExecuteDataset(Database.ConnectionString, "get_all_departments").Tables[0];
        Smart_Search_dept.Value_Field = "Dept_id";
        Smart_Search_dept.Text_Field = "Dept_name";
        Smart_Search_dept.DataBind();

        fill_depts();
        this.Smart_Search_dept.Value_Handler += new Smart_Search.Delegate_Selected_Value(MOnMember_Data);
        #endregion
        base.OnInit(e);
    }
    private void MOnMember_Data(string Value)
    {
        dropdept_fun();
    }
    protected void dropdept_fun()
    {
       
        fill_resp_Emp();


    }
    private void Fil_Dll()
    {
        //DataTable DT = new DataTable();
        //DT = General_Helping.GetDataTable("select * from Departments");
        //Obj_General_Helping.SmartBindDDL(ddl_Visa_Dept_ID, DT, "Dept_ID", "Dept_name", "....اختر اسم الإدارة ....");


    }

    private void fil_emp_Visa()
    {
        //int Dept_ID = CDataConverter.ConvertToInt(Smart_Search_dept.SelectedValue);
        //string sql = "SELECT PMP_ID, pmp_name FROM EMPLOYEE ";
        //if (Dept_ID > 0)
        //{
        //    sql += " where Dept_Dept_id = " + Dept_ID;

        //}
        //sql += " order by pmp_name asc";
        //chklst_Visa_Emp_All.DataSource = General_Helping.GetDataTable(sql);
        //chklst_Visa_Emp_All.DataBind();
        // this.Smart_Search_dept.Value_Handler += new Smart_Search.Delegate_Selected_Value(MOnMember_Data);

    }

    protected void ddl_Visa_Dept_ID_SelectedIndexChanged(object sender, EventArgs e)
    {
        //fil_emp_Visa();
    }

    private void Fill_Controll(int id)
    {
        try
        {
            DataTable allinboxdata = Inbox_DB.inbox_fillcontrol(id);
            DataRow inall = allinboxdata.Rows[0];

            hidden_Id.Value = inall["id"].ToString();

            hidden_Proj_id.Value = inall["Proj_id"].ToString();


            if (inall["Type"].ToString() == "2")
            {
                lblLetterType.Text = "وارد خارجي";
            }
            if (inall["Type"].ToString() == "1")
            { lblLetterType.Text = "وارد داخلي"; }
            lblCode.Text = inall["Code"].ToString();
            lblLetterDate.Text = inall["Date"].ToString();

            if (inall["Source_Type"].ToString() == "1")
            {
                lblSourceType.Text = "البريد";
            }
            if (inall["Source_Type"].ToString() == "2")
            { lblSourceType.Text = "الايميل"; }
            if (inall["Source_Type"].ToString() == "3")
            { lblSourceType.Text = "الفاكس"; }


            if (inall["Org_Dept_Name"].ToString() != "")
                lblDept_in.Text = inall["Org_Dept_Name"].ToString();

            if (inall["Org_Out_Box_Person"].ToString() != "")
                lblOrg_Out_Box_Person.Text = inall["Org_Out_Box_Person"].ToString();

            lblOrg_Out_Box_DT.Text = inall["Org_Out_Box_DT"].ToString();
            lblOrg_Out_Box_Code.Text = inall["Org_Out_Box_Code"].ToString();
            lbl_paper_no.Text = inall["Paper_No"].ToString();
            lbl_att_no.Text = inall["Paper_Attached"].ToString();
            txt_subject.Text = inall["Subject"].ToString();
            txt_notes.Text = inall["Notes"].ToString();

            Smart_Search_proj.SelectedValue = inall["Proj_id"].ToString();
            if (inall["Related_Type"].ToString() != "")
            {
                if (inall["Related_Type"].ToString() == "1")
                { lblRelatedType.Text = "وارد جديد"; }
                if (inall["Related_Type"].ToString() == "2")
                { lblRelatedType.Text = "رد على صادر"; }
                if (inall["Related_Type"].ToString() == "3")
                { lblRelatedType.Text = "استعجال وارد"; }
                if (inall["Related_Type"].ToString() == "4")
                { lblRelatedType.Text = "استكمال وارد"; }
                if (inall["Related_Type"].ToString() == "5")
                { lblRelatedType.Text = "أخري"; }

                if (inall["Related_Type"].ToString() == "6")
                { lblRelatedType.Text = "وارد لصادر داخلي"; }
            }

            txt_Visa_Desc.Text = inall["Visa_Desc"].ToString();

            GrdView_Relation.DataSource = Inbox_DB.SelectRelated(id, 1);

            GrdView_Relation.DataBind();



            string all = "";
            int idrelated = 0;

            if (inall["Related_Type"].ToString() != "")
            {
                int x = CDataConverter.ConvertToInt(inall["Related_Type"].ToString());
                int yy = CDataConverter.ConvertToInt(inall["Related_Id"].ToString());

                DataTable dt_direct_related = Inbox_DB.inbox_Direct_Relating(CDataConverter.ConvertToInt(inall["Related_Type"].ToString()), CDataConverter.ConvertToInt(inall["Related_Id"].ToString()));
                if (inall["Related_Type"].ToString() == "1")
                {

                    lbl_Inbox_type.Visible = false;
                    lbl_letter.Visible = false;

                }
                if (inall["Related_Type"].ToString() == "2" || inall["Related_Type"].ToString() == "5")
                {
                    all = dt_direct_related.Rows[0]["con"].ToString();
                    string[] res = all.Split('-');
                    idrelated = CDataConverter.ConvertToInt(res[3].ToString());
                    lbl_Inbox_type.Text = "موضوع الخطاب الصادر :";


                    if (dt_direct_related.Rows.Count > 0)
                    {

                        int outid = idrelated;
                        string encrypted = Encryption.Encrypt(outid.ToString());


                        lbl_letter.Text = dt_direct_related.Rows[0]["con"].ToString();
                        lbl_letter.NavigateUrl = "../mainform/ViewProjectOutbox.aspx?id=" + encrypted;
                    }
                }
                if (inall["Related_Type"].ToString() == "3" || inall["Related_Type"].ToString() == "4")
                {
                    all = dt_direct_related.Rows[0]["con"].ToString();
                    string[] res = all.Split('-');
                    idrelated = CDataConverter.ConvertToInt(res[3].ToString());
                    lbl_Inbox_type.Text = "موضوع الخطاب الوارد :";


                    if (dt_direct_related.Rows.Count > 0)
                    {

                        int INid = idrelated;
                        string encrypted = Encryption.Encrypt(INid.ToString());


                        lbl_letter.Text = dt_direct_related.Rows[0]["con"].ToString();
                        lbl_letter.NavigateUrl = "../mainform/ViewProjectInbox.aspx?id=" + encrypted;


                    }

                }

                if (inall["Related_Type"].ToString() == "6")
                {
                    all = dt_direct_related.Rows[0]["con"].ToString();
                    string[] res = all.Split('-');
                    idrelated = CDataConverter.ConvertToInt(res[3].ToString());
                    lbl_Inbox_type.Text = "وارد لصادر داخلي :";


                    if (dt_direct_related.Rows.Count > 0)
                    {

                        int outid = idrelated;
                        string encrypted = Encryption.Encrypt(outid.ToString());


                        lbl_letter.Text = dt_direct_related.Rows[0]["con"].ToString();
                        lbl_letter.NavigateUrl = "../mainform/ViewProjectOutbox.aspx?id=" + encrypted;
                    }
                }


            }




            DataTable dtorg = Inbox_DB.inbox_getorg(id);
           
            lblOrgName.Text = dtorg.Rows[0]["Org_Desc"].ToString();
          


        }
        catch
        { }
    }
    public string Get_Type_2(object obj)
    {
        string str = obj.ToString();
        if (str == "1")
        {
            //hidden1.Value = "inbox";
            return "وارد";
        }
        else if (str == "2")
        {
            //hidden1.Value = "Outbox";
            return "صادر";
        }
        else return "";
    }

    public string Get_Visa_Emp_Dept(object obj)
    {
        string Emp_ID = obj.ToString();
        string dept_name = "";
        DataTable DT = new DataTable();
        DT = General_Helping.GetDataTable("SELECT distinct Departments.Dept_name FROM Departments INNER JOIN EMPLOYEE on EMPLOYEE.Dept_Dept_id=Departments.Dept_id INNER JOIN  Inbox_Visa ON Inbox_Visa.Emp_ID = EMPLOYEE.PMP_ID WHERE Inbox_Visa.Emp_ID  =" + Emp_ID);

        foreach (DataRow dr in DT.Rows)
        {
            dept_name += dr["Dept_name"].ToString() + ",";
        }
        return dept_name;

    }
    protected void GrdView_Relation_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditItem")
        {
            int row_Index = ((GridViewRow)(((ImageButton)e.CommandSource).NamingContainer)).RowIndex;

            //DataTable dt2 = ViewState["dt"];
            // DataTable dt2 = ViewState["dt"] as DataTable ; 
            // DataTable dt = General_Helping.GetDataTable("select * from inbox_relations where id = " + CDataConverter.ConvertToInt(e.CommandArgument));
            //string encrypted = Encryption.Encrypt(dt2.ro.ToString());
            //DataRow[]  res = dt2.Select("Inbox_or_outbox = 2 ");

            //DataRow[] resss = dt2.Select("ID =  " + CDataConverter.ConvertToInt(e.CommandArgument.ToString()) + " and Inbox_or_outbox = 1");
            //DataRow[] resss_in = dt2.Select("ID =  " + CDataConverter.ConvertToInt(e.CommandArgument.ToString()) + " and Inbox_or_outbox = 1");
            // string all = e.CommandArgument.ToString();
            // string[] res = all.Split('#');
            // string ID = res[0];
            string R2 = ((HtmlInputHidden)(GrdView_Relation.Rows[row_Index].FindControl("input_type"))).Value; //res[1];
            //Get_Type_2(res[1]);
            //DataRow[] res2 = dt2.Select("Inbox_or_outbox = 1 "); 
            //DataTable st3 = res as DataTable;

            string encrypted = Encryption.Encrypt(e.CommandArgument.ToString());
            if (R2 == "2")
            {
                Response.Redirect("ViewProjectOutbox.aspx?id=" + encrypted);
            }
            else if (R2 == "1")
            {
                Response.Redirect("ViewProjectInbox.aspx?id=" + encrypted);
            }

            //if (resss.Length>0)
            //{
            //    Response.Redirect("ViewProjectInbox.aspx?id=" + encrypted);
            //}
            //foreach (DataRow row in resss)
            //{

            //    Response.Redirect("ViewProjectOutbox.aspx?id=" + encrypted);

            //}
            //foreach (DataRow row in resss_in)
            //{

            //    Response.Redirect("ViewProjectInbox.aspx?id=" + encrypted);

            //}

            //foreach (DataRow row in res)
            //{

            //}
            //for (int i = 0; i < dt2.Rows.Count; i++)
            //{
            // string encrypted = Encryption.Encrypt(res.);
            //if (dt2.Rows[i]["inbox_or_outbox"].ToString() == "2" )
            //{
            //    Response.Redirect("ViewProjectOutbox.aspx?id=" + encrypted);    
            //}
            //else 
            //    Response.Redirect("ViewProjectInbox.aspx?id=" + encrypted);
            //}
            //if (dt.Rows[0]["inbox_or_outbox"].ToString()=="1")
            //{
            //    Response.Redirect("ViewProjectInbox.aspx?id=" + encrypted);
            //}
            //else
            //    Response.Redirect("ViewProjectOutbox.aspx?id=" + encrypted);    
            //DataTable dt = General_Helping.GetDataTable("select * from inbox_relations where ");
            //DataTable dt_relation = General_Helping.GetDataTable("select * from inbox_Relations where  Related_id<>0 and inbox_id = " + e.CommandArgument + " or Related_id = " + e.CommandArgument);
            //for (int i = 0; i < dt_relation.Rows.Count; i++)
            //{
            //    if (CDataConverter.ConvertToInt(dt_relation.Rows[i]["Related_Type"].ToString()) == 2 )
            //    {
            //        if (CDataConverter.ConvertToInt(dt_relation.Rows[i]["Related_id"].ToString()) == CDataConverter.ConvertToInt( e.CommandArgument))
            //        {
            //            Response.Redirect("ViewProjectOutbox.aspx?id=" + encrypted);    
            //        }
            //    }
            //    else
            //        Response.Redirect("ViewProjectInbox.aspx?id=" + encrypted);


            //string s = GrdView_Relation.SelectedRow.Cells[0].Text;
            //int row = Convert.ToInt32(e.CommandArgument);
            // string pc = GrdView_Relation.Rows[1].Cells[1].Text;
            //}


            //if ( == "inbox")
            //{
            //    Response.Redirect("ViewProjectInbox.aspx?id=" + encrypted);
            //}
            //else if (hidden1.Value == "Outbox")
            //{
            //    Response.Redirect("ViewProjectOutbox.aspx?id=" + encrypted);
            //}

        }
    }
    protected void btn_Visa_Follow_Click(object sender, EventArgs e)
    {
        if (CDataConverter.ConvertToInt(hidden_Id.Value) > 0)
        {
            string datenow = CDataConverter.ConvertDateTimeToFormatdmy(CDataConverter.ConvertDateTimeNowRtnDt());
            Inbox_Visa_Follows_DT obj = Inbox_Visa_Follows_DB.SelectByID(CDataConverter.ConvertToInt(hidden_Follow_ID.Value));
            obj.Follow_ID = CDataConverter.ConvertToInt(hidden_Follow_ID.Value);
            obj.Inbox_ID = CDataConverter.ConvertToInt(hidden_Id.Value);
            obj.Descrption = txt_Descrption.Text;
            obj.Date = txt_Follow_Date.Text;
            obj.Entery_Date = datenow;
            obj.time_follow = txt_time_follow.Text;
            obj.entery_pmp_id = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
            obj.Visa_Emp_id = CDataConverter.ConvertToInt(ddl_Visa_Emp_id.SelectedValue);
            obj.Follow_ID = Inbox_Visa_Follows_DB.Save(obj);

            //DataTable dt_Inbox_Visa = General_Helping.GetDataTable("select * from Inbox_Track_Emp where inbox_id =" + hidden_Id.Value);
            //foreach (DataRow item in dt_Inbox_Visa.Rows)
            //{
            //    Inbox_DB.update_inbox_Track_Emp(hidden_Id.Value, item["Emp_ID"].ToString(), 4, 1);
            //}

            if (FileUpload_Visa_Follow.HasFile)
            {
                SqlCommand cmd = new SqlCommand();
                SqlConnection con = new SqlConnection();
              
                SqlConnection con_local = new SqlConnection();
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                con_local = new SqlConnection(Session_CS.local_connectionstring);

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

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = " update Inbox_Visa_Follows set File_data =@File_data ,File_name=@File_name,File_ext=@File_ext where Follow_ID =@Follow_ID";
                cmd.Parameters.Add("@File_data", SqlDbType.VarBinary);
                cmd.Parameters.Add("@File_name", SqlDbType.NVarChar);
                cmd.Parameters.Add("@File_ext", SqlDbType.NVarChar);
                cmd.Parameters.Add("@Follow_ID", SqlDbType.BigInt);

                //cmd.Parameters["@File_data"].Value = Input;
                cmd.Parameters["@File_name"].Value = DocName;
                cmd.Parameters["@File_ext"].Value = type;
                cmd.Parameters["@Follow_ID"].Value = obj.Follow_ID;
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
                    }
                }

                //SqlCommand cmd = new SqlCommand();
                //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                //cmd.Connection = con;
                //cmd.CommandType = CommandType.Text;
                //cmd.CommandText = " update Inbox_Visa_Follows set File_data =@File_data ,File_name=@File_name,File_ext=@File_ext where Follow_ID =@Follow_ID";
                //cmd.Parameters.Add("@File_data", SqlDbType.VarBinary);
                //cmd.Parameters.Add("@File_name", SqlDbType.NVarChar);
                //cmd.Parameters.Add("@File_ext", SqlDbType.NVarChar);
                //cmd.Parameters.Add("@Follow_ID", SqlDbType.BigInt);

                //cmd.Parameters["@File_data"].Value = Input;
                //cmd.Parameters["@File_name"].Value = DocName;
                //cmd.Parameters["@File_ext"].Value = type;
                //cmd.Parameters["@Follow_ID"].Value = obj.Follow_ID;

                //con.Open();
                //cmd.ExecuteScalar();
                //con.Close();



            }
            ///////////// change have follow = 1 , All_visa_sent=0 /////////////////////////////////////////////

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            //DataTable DT = new DataTable();
            //DT = General_Helping.GetDataTable("select * from Inbox_Track_Manager where inbox_id = " + hidden_Id.Value);
            //if (DT.Rows.Count > 0)
            //{
            //    conn.Open();
            //    string sql = "update Inbox_Track_Manager set Have_Follow=1,All_visa_sent=0 where inbox_id =" + hidden_Id.Value;
            //    SqlCommand cmd = new SqlCommand(sql, conn);
            //    cmd.ExecuteNonQuery();
            //    conn.Close();

            //}
            int id = CDataConverter.ConvertToInt(hidden_Id.Value);
            if (CDataConverter.ConvertToInt(Session_CS.parent_id.ToString()) == 0)
            {
                string sql = "SELECT dbo.Inbox_Visa_Emp.Sender_ID, dbo.Inbox_Visa_Emp.Emp_ID FROM dbo.Inbox_Visa INNER JOIN dbo.Inbox_Visa_Emp ON dbo.Inbox_Visa.Visa_Id = dbo.Inbox_Visa_Emp.Visa_Id where dbo.Inbox_Visa.Inbox_ID = " + id + "AND dbo.Inbox_Visa_Emp.Emp_ID = " + CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
                DataTable dt = General_Helping.GetDataTable(sql);
                int sender1 = CDataConverter.ConvertToInt(dt.Rows[0]["Sender_id"].ToString());


                string both_see = " SELECT     Inbox_Visa_Emp.Visa_Emp_ID, Inbox_Visa_Emp.Visa_Id, Inbox_Visa_Emp.Emp_ID, Inbox_Visa_Emp.Sender_ID, Inbox_Visa.Inbox_ID FROM         Inbox_Visa_Emp LEFT OUTER JOIN                       Inbox_Visa ON Inbox_Visa_Emp.Visa_Id = Inbox_Visa.Visa_Id ";
                both_see += " where Sender_id=" + sender1 + " and Inbox_ID =" + id;
                DataTable dt_both_see = General_Helping.GetDataTable(both_see);
                for (int i = 0; i < dt_both_see.Rows.Count; i++)
                {
                    if (CDataConverter.ConvertToInt(dt_both_see.Rows[i]["Emp_ID"].ToString()) != CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()))
                    {
                        string sql_exist = "select * from inbox_follow_emp where inbox_id = " + id + " AND inbox_follow_emp.pmp_id = " + CDataConverter.ConvertToInt(dt_both_see.Rows[i]["Emp_ID"].ToString());
                        DataTable dt_exist = General_Helping.GetDataTable(sql_exist);
                        if (dt_exist.Rows.Count > 0)
                        {
                            General_Helping.ExcuteQuery(" update inbox_follow_emp set Have_follow = 1 where (inbox_id = " + id + "  AND inbox_follow_emp.pmp_id = " + CDataConverter.ConvertToInt(dt_both_see.Rows[i]["Emp_ID"].ToString()) + ")");

                        }
                        else
                        {
                            string Sql_insert = "insert into inbox_follow_emp (pmp_id , Have_follow ,inbox_id) values ( " + CDataConverter.ConvertToInt(dt_both_see.Rows[i]["Emp_ID"].ToString()) + ",1," + id + ")";
                            General_Helping.ExcuteQuery(Sql_insert);
                        }
                    }

                }
                string sql_sender_exist = "select * from inbox_follow_emp where inbox_id = " + id + " AND inbox_follow_emp.pmp_id = " + sender1;
                DataTable dt_sender_exist = General_Helping.GetDataTable(sql_sender_exist);
                if (dt_sender_exist.Rows.Count > 0)
                {
                    General_Helping.ExcuteQuery(" update inbox_follow_emp set Have_follow = 1 where (inbox_id = " + id + " AND inbox_follow_emp.pmp_id = " + sender1 + ")");
                }
                else
                {
                    string Sql_insert_parent = "insert into inbox_follow_emp (pmp_id , Have_follow ,inbox_id) values ( " + CDataConverter.ConvertToInt(dt.Rows[0]["Sender_ID"].ToString()) + ",1," + id + ")";
                    General_Helping.ExcuteQuery(Sql_insert_parent);
                }

            }

            if (Smart_Search_proj.SelectedValue != "")
            {

                //conn.Open();
                General_Helping.ExcuteQuery("update inbox set proj_id =" + Smart_Search_proj.SelectedValue + " where ID = " + hidden_Id.Value);
                //string sql = "update inbox set proj_id = " + Smart_Search_proj.SelectedValue;
                //sql += " where ID  =" + hidden_Id.Value;
                //SqlCommand cmd = new SqlCommand(sql, conn);
                //cmd.ExecuteNonQuery();
                //conn.Close();

            }
            Clear_visa_Follow();

            Fil_Grid_Visa_Follow();
            if (CDataConverter.ConvertToInt(Session_CS.parent_id.ToString()) > 0)
            {
                //Update_Have_Visa_all_emp(id);
                Inbox_DB.update_inbox_Track_manger(id.ToString(), 0);

            }

            Inbox_DB.update_inbox_Track_Emp(id.ToString(), Session_CS.pmp_id.ToString(), 2, 1);
        }
        else
        {
           // Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('يجب إدخال بيانات الخطاب أولا')</script>");

            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('يجب إدخال بيانات الخطاب أولا')</script>");


        }

    }
    private void Clear_visa_Follow()
    {
        ddl_Visa_Emp_id.SelectedIndex = 0;
        hidden_Follow_ID.Value =

        txt_Descrption.Text = "";

       // txt_Follow_Date.Text = "";

      
    }
    private void Fil_Grid_Visa_Follow()
    {
        DataTable DT = new DataTable();
        string Sql = "SELECT Inbox_Visa_Follows.Follow_ID,Inbox_Visa_Follows.Entery_Date,Inbox_Visa_Follows.File_name,Inbox_Visa_Follows.time_follow,Inbox_Visa_Follows.Inbox_ID, Inbox_Visa_Follows.Descrption, Inbox_Visa_Follows.Date, Inbox_Visa_Follows.Visa_Emp_id, EMPLOYEE.pmp_name " +
                     " FROM         Inbox_Visa_Follows INNER JOIN EMPLOYEE ON Inbox_Visa_Follows.Visa_Emp_id = EMPLOYEE.PMP_ID where Inbox_ID =" + hidden_Id.Value;
        DT = General_Helping.GetDataTable(Sql);

        GridView_Visa_Follow.DataSource = DT;
        GridView_Visa_Follow.DataBind();
    }
    protected void GridView_Visa_Follow_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "EditItem")
        {

            Inbox_Visa_Follows_DT obj = Inbox_Visa_Follows_DB.SelectByID(CDataConverter.ConvertToInt(e.CommandArgument));
            if (obj.Follow_ID > 0)
            {
                hidden_Follow_ID.Value = obj.Follow_ID.ToString();
                txt_Descrption.Text = obj.Descrption;
                txt_Follow_Date.Text = obj.Date;
                ddl_Visa_Emp_id.SelectedValue = obj.Visa_Emp_id.ToString();

            }
        }

        if (e.CommandName == "RemoveItem")
        {
            Inbox_Visa_Follows_DB.Delete(CDataConverter.ConvertToInt(e.CommandArgument));
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم الحذف بنجاح')</script>");
            Fil_Grid_Visa_Follow();
        }
    }
    private void Fil_Emp_Visa_Follow()
    {
        int grp = CDataConverter.ConvertToInt(Session_CS.group_id.ToString());
        if (CDataConverter.ConvertToInt(hidden_Id.Value) > 0)
        {
            DataTable DT = new DataTable();
            string sql = " SELECT  distinct   EMPLOYEE.PMP_ID, EMPLOYEE.pmp_name, Inbox_Visa.Inbox_ID ";
            sql += " FROM Inbox_Visa_Emp INNER JOIN EMPLOYEE ON Inbox_Visa_Emp.Emp_ID = EMPLOYEE.PMP_ID INNER JOIN Inbox_Visa ON Inbox_Visa_Emp.Visa_Id = Inbox_Visa.Visa_Id INNER JOIN Inbox ON Inbox_Visa.Inbox_ID = Inbox.ID ";
            sql += " where Inbox_ID=" + hidden_Id.Value;
            if (grp != 9)
            {
                sql += " AND EMPLOYEE.PMP_ID = " + CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
            }


            DT = General_Helping.GetDataTable(sql);
            //Obj_General_Helping.SmartBindDDL(ddl_Visa_Emp_id, DT, "PMP_ID", "pmp_name",);
            ddl_Visa_Emp_id.DataSource = DT;
            ddl_Visa_Emp_id.DataTextField = "pmp_name";
            ddl_Visa_Emp_id.DataValueField = "pmp_id";

            ddl_Visa_Emp_id.DataBind();

        }
    }

    protected void GrdView_Documents_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //if (e.CommandName == "EditItem")
        //{
        //    Inbox_OutBox_Files_DT obj = Inbox_OutBox_Files_DB.SelectByID(CDataConverter.ConvertToInt(e.CommandArgument));
        //    if (obj.Inbox_OutBox_File_ID > 0)
        //    {
        //        hidden_Inbox_OutBox_File_ID.Value = obj.Inbox_OutBox_File_ID.ToString();
        //        txtFileName.Text = obj.File_name;
        //        //ddl_Original_Or_Attached.SelectedValue = obj.Original_Or_Attached.ToString();
        //    }

    }

    private void Fil_Grid_Documents()
    {
        DataTable DT = new DataTable();
        DT = General_Helping.GetDataTable("select  Inbox_OutBox_File_ID, Inbox_Outbox_ID, Inbox_Or_Outbox, Original_Or_Attached, File_name, File_ext from Inbox_OutBox_Files where Inbox_Or_Outbox = 1 and Inbox_Outbox_ID=" + id);

        GrdView_Documents.DataSource = DT;
        GrdView_Documents.DataBind();


    }


    protected void btn_print_report_Click(object sender, EventArgs e)
    {
        string user = Session_CS.pmp_name.ToString();
        int found_id = CDataConverter.ConvertToInt(Session_CS.foundation_id.ToString());
        if (Request.QueryString["id"] != null)
        {
            ReportDocument rd = new ReportDocument();
            string s = Server.MapPath("../Reports/InboxOutboxReport/Inbox_Data.rpt");
            //string s = Server.MapPath("../Reports/Logo_try.rpt");
            rd.Load(s);
            Reports.Load_Report(rd);
            // Load_Report(rd);

            rd.SetParameterValue("@Inbox_ID", CDataConverter.ConvertToInt(hidden_Id.Value));
            rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
            rd.SetParameterValue("@user", user, "footerRep.rpt");
            rd.SetParameterValue("@found_id", found_id, "Logo_Header_pic_dynamic.rpt");

            if (rd.Rows.Count == 0)
            {
              //  ShowAlertMessage("!!!!!هذا التقرير لا يوجد به بيانات للعرض !!!!");

                Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('!!!!!هذا التقرير لا يوجد به بيانات للعرض !!!!')</script>");

                return;
            }
            else
            {
                rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report");
            }
        }


    }
    protected void btn_close_inbox_Click(object sender, EventArgs e)
    {

        ///////////// change status = 3  /////////////////////////////////////////////
        // int id = Convert.ToInt16(Request["id"]);
        DataTable DT = new DataTable();
        DT = General_Helping.GetDataTable("select * from Inbox_Track_Manager where inbox_id = " + hidden_Id.Value);
        if (DT.Rows.Count > 0)
        {
            string sql = "update Inbox_Track_Manager set Have_Follow=0,All_visa_sent=0,Have_Visa=0,status=3 where inbox_id =" + hidden_Id.Value;
            General_Helping.ExcuteQuery(sql);

        }
        DataTable dt_Inbox_Visa = General_Helping.GetDataTable("select * from Inbox_Track_Emp where inbox_id =" + hidden_Id.Value);
        foreach (DataRow item in dt_Inbox_Visa.Rows)
        {
            Inbox_DB.update_inbox_Track_Emp(hidden_Id.Value, item["Emp_ID"].ToString(), 3, 1);
        }

        Inbox_Visa_Follows_DT obj = Inbox_Visa_Follows_DB.SelectByID(CDataConverter.ConvertToInt(hidden_Follow_ID.Value));
        obj.Follow_ID = CDataConverter.ConvertToInt(hidden_Follow_ID.Value);
        obj.Inbox_ID = CDataConverter.ConvertToInt(hidden_Id.Value);
        obj.Descrption = "تم إغلاق الموضوع";
        string date = CDataConverter.ConvertDateTimeToFormatdmy(CDataConverter.ConvertDateTimeNowRtnDt());
        obj.Date = date;
        obj.time_follow = CDataConverter.ConvertTimeNowRtnLongTimeFormat();
        obj.entery_pmp_id = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
        obj.Visa_Emp_id = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
        obj.Follow_ID = Inbox_Visa_Follows_DB.Save(obj);
        Fil_Grid_Visa_Follow();
        ///////////////////////////////////////////////////////////////// when dr hesham close inbox update all have follow in inbox follow emp to be zero
        General_Helping.ExcuteQuery("update inbox_follow_emp set Have_follow = 0 where inbox_id = " + hidden_Id.Value);
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('تم إغلاق الموضوع بنجاح' )</script>");

       // Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('تم إغلاق الموضوع بنجاح')</script>");
        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('تم إغلاق الموضوع بنجاح');", true);




    }
    protected void btn_end_late_Click(object sender, EventArgs e)
    {

        ///////////// change status = 3  /////////////////////////////////////////////
        int id = Convert.ToInt16(hidden_Id.Value);
        DataTable DT = new DataTable();
        DT = General_Helping.GetDataTable("select * from Inbox where ID = " + id);
        if (DT.Rows.Count > 0)
        {
            string sql = "update Inbox set finished=1 where ID =" + id;
            General_Helping.ExcuteQuery(sql);

        }
        //DataTable dt_Inbox_Visa = General_Helping.GetDataTable("select * from Inbox_Track_Emp where inbox_id =" + hidden_Id.Value);
        //foreach (DataRow item in dt_Inbox_Visa.Rows)
        //{
        //    Inbox_DB.update_inbox_Track_Emp(hidden_Id.Value, item["Emp_ID"].ToString(), 3, 1);
        //}

        Inbox_Visa_Follows_DT obj = Inbox_Visa_Follows_DB.SelectByID(CDataConverter.ConvertToInt(hidden_Follow_ID.Value));
        obj.Follow_ID = CDataConverter.ConvertToInt(hidden_Follow_ID.Value);
        obj.Inbox_ID = CDataConverter.ConvertToInt(hidden_Id.Value);
        obj.Descrption = "تم انهاء تأخير الموضوع";
        string date = CDataConverter.ConvertDateTimeToFormatdmy(CDataConverter.ConvertDateTimeNowRtnDt());
        obj.Date = date;
        obj.time_follow = CDataConverter.ConvertTimeNowRtnLongTimeFormat();
        obj.entery_pmp_id = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
        obj.Visa_Emp_id = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
        obj.Follow_ID = Inbox_Visa_Follows_DB.Save(obj);
        Fil_Grid_Visa_Follow();
        ///////////////////////////////////////////////////////////////// when dr hesham close inbox update all have follow in inbox follow emp to be zero
        //General_Helping.ExcuteQuery("update inbox_follow_emp set Have_follow = 0 where inbox_id = " + id);
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('تم انهاء تأخير الموضوع بنجاح' )</script>");

        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('تم انهاء تأخير الموضوع بنجاح');", true);



    }
    //protected void btn_mzkra_Click(object sender, EventArgs e)
    //{
    //    string File_Name = Server.MapPath("~//Uploads/نموذج مذكرة.doc");
    //    FileStream fs = new FileStream(File_Name, FileMode.Open, FileAccess.Read);

    //    byte[] bytes = new byte[fs.Length];

    //    fs.Read(bytes, 0, System.Convert.ToInt32(fs.Length));

    //    fs.Close();
    //    Response.ContentType = "application/x-unknown";
    //    string File_Name_Show = "";
    //    File_Name_Show = "نموذج مذكرة.doc";
    //    Response.AddHeader("Content-Disposition", "attachment; filename=" + Server.UrlPathEncode(File_Name_Show));
    //    Response.BinaryWrite(bytes);
    //    Response.Flush();
    //    Response.Close();
    //}
    protected void btn_Ltr_Click(object sender, EventArgs e)
    {
        string File_Name = Server.MapPath("~//Uploads/نموذج خطاب.doc");
        FileStream fs = new FileStream(File_Name, FileMode.Open, FileAccess.Read);

        byte[] bytes = new byte[fs.Length];

        fs.Read(bytes, 0, System.Convert.ToInt32(fs.Length));

        fs.Close();
        Response.ContentType = "application/x-unknown";
        string File_Name_Show = "";
        File_Name_Show = "نموذج خطاب.doc";
        Response.AddHeader("Content-Disposition", "attachment; filename=" + Server.UrlPathEncode(File_Name_Show));
        Response.BinaryWrite(bytes);
        Response.Flush();
        Response.Close();
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



    protected void btn_Visa_Click(object sender, EventArgs e)
    {
        int id = CDataConverter.ConvertToInt(hidden_Id.Value);
        // SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        DataTable DT = new DataTable();
        DT = General_Helping.GetDataTable("select * from Inbox_Track_Manager where inbox_id = " + id);
        if (DT.Rows.Count > 0)
        {
            string datenow = CDataConverter.ConvertDateTimeToFormatdmy(CDataConverter.ConvertDateTimeNowRtnDt());
            //conn.Open();
            //Inbox_Visa_Follows_DT obj_follow = Inbox_Visa_Follows_DB.SelectByID(CDataConverter.ConvertToInt(hidden_Follow_ID.Value));
            //obj_follow.Follow_ID = CDataConverter.ConvertToInt(hidden_Follow_ID.Value);
            //obj_follow.Inbox_ID = CDataConverter.ConvertToInt(hidden_Id.Value);
            //obj_follow.Descrption = txt_Visa_Desc.Text;
            ////string date = DateTime.Now.ToShortDateString().ToString();
            //string date = txt_Visa_date.Text;
            //obj_follow.Entery_Date = datenow;
            //obj_follow.Date = date;
            //obj_follow.time_follow = CDataConverter.ConvertDateTimeNowRtnDt().ToLocalTime().ToLongTimeString();
            //obj_follow.entery_pmp_id = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
            //obj_follow.Visa_Emp_id = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
            //obj_follow.Follow_ID = Inbox_Visa_Follows_DB.Save(obj_follow);


            Fil_Grid_Visa_Follow();

            if (CDataConverter.ConvertToInt(Session_CS.parent_id.ToString()) > 0)
            {
                Update_Have_Visa_all_emp(id);
                Inbox_DB.update_inbox_Track_manger(id.ToString(), 0);

            }
            else
                Inbox_DB.update_inbox_Track_Emp(id.ToString(), Session_CS.pmp_id.ToString(), 2, 1);


            lnkBtnUnderStudy.Visible = false;
            Save_Visa(id);
            Save_trackmanager(id);
           // Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('تم حفظ التاشيرة بنجاح')</script>");

            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('تم حفظ التاشيرة بنجاح');", true);

            clear_Visa_cntrl();
            Fil_Grid_Visa();
            lst_emp.Items.Clear();

        }
        else
        {
          //  Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لا يوجد بيانات للخطاب')</script>");

            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('لا يوجد بيانات للخطاب');", true);

        }
    }

    private void Update_Have_Visa_all_emp(int Inbox_ID)
    {
        string sql = "update Inbox_Track_Manager set status=0,Have_Follow=0,Have_visa=1 , ";
        sql += "Visa_Desc = '" + txt_Visa_Desc.Text + "'";
        sql += " where inbox_id =" + Inbox_ID;
        General_Helping.ExcuteQuery(sql);

        string sql_all_User = "update Inbox_Track_Emp set Inbox_Status =2 where inbox_id=" + Inbox_ID;
        General_Helping.ExcuteQuery(sql_all_User);
    }

    private void clear_Visa_cntrl()
    {
        hidden_Visa_Id.Value = "";

    }

    private void Save_Visa(int id)
    {
                DateTime visainitial = CDataConverter.ConvertToDate(txt_Visa_date.Text);
                DateTime visalastdate = CDataConverter.ConvertToDate(txt_Dead_Line_DT.Text);
                if (visalastdate >= visainitial)
                {
                    Inbox_Visa_DT obj = new Inbox_Visa_DT();
                    obj.Visa_Id = CDataConverter.ConvertToInt(hidden_Visa_Id.Value);
                    obj.Inbox_ID = id;
                    obj.Emp_ID = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());

                    obj.Important_Degree = CDataConverter.ConvertToInt(ddl_Important_Degree.SelectedValue);
                    obj.Important_Degree_Txt = txt_Important_Degree_Txt.Text;
                    if (string.IsNullOrEmpty(obj.Important_Degree_Txt))
                        obj.Important_Degree_Txt = ddl_Important_Degree.SelectedItem.Text;
                    DateTime str = CDataConverter.ConvertDateTimeNowRtnDt();
                    obj.Visa_date = CDataConverter.ConvertDateTimeToFormatdmy(str);
                    //obj.Important_Degree = 1;
                    obj.Dept_ID = CDataConverter.ConvertToInt(Smart_Search_dept.SelectedValue);
                    obj.Visa_Desc = txt_Visa_Desc.Text;
                    obj.Dead_Line_DT = txt_Dead_Line_DT.Text;
                    obj.Visa_Goal_ID = CDataConverter.ConvertToInt(ddl_Visa_Goal_ID.SelectedValue);

                    obj.Visa_Id = Inbox_Visa_DB.Save(obj);

                    if (FileUpload_Visa.HasFile)
                    
                    {
                        SqlCommand cmd = new SqlCommand();
                        SqlConnection con = new SqlConnection();

                        SqlConnection con_local = new SqlConnection();
                        con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                        con_local = new SqlConnection(Session_CS.local_connectionstring);

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
                        cmd.Parameters.Add("@File_data", SqlDbType.VarBinary);
                        cmd.Parameters.Add("@File_name", SqlDbType.NVarChar);
                        cmd.Parameters.Add("@File_ext", SqlDbType.NVarChar);
                        cmd.Parameters.Add("@visa_ID", SqlDbType.BigInt);

                        cmd.Parameters["@File_name"].Value = DocName;
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
                            }
                        }

                        //SqlCommand cmd = new SqlCommand();
                        //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                        //cmd.Connection = con;
                        //cmd.CommandType = CommandType.Text;
                        //cmd.CommandText = " update Inbox_Visa set File_data =@File_data ,File_name=@File_name,File_ext=@File_ext where visa_ID =@visa_ID";
                        //cmd.Parameters.Add("@File_data", SqlDbType.VarBinary);
                        //cmd.Parameters.Add("@File_name", SqlDbType.NVarChar);
                        //cmd.Parameters.Add("@File_ext", SqlDbType.NVarChar);
                        //cmd.Parameters.Add("@visa_ID", SqlDbType.BigInt);

                        //cmd.Parameters["@File_data"].Value = Input;
                        //cmd.Parameters["@File_name"].Value = DocName;
                        //cmd.Parameters["@File_ext"].Value = type;
                        //cmd.Parameters["@visa_ID"].Value = obj.Visa_Id;

                        //con.Open();
                        //cmd.ExecuteScalar();
                        //con.Close();



                    }

                    Save_inox_Visa(obj);
                }
                else
                {
                    //Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('أخر تاريخ يجب ان يكون اكبر من تاريخ التأشيره')</script>");
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('أخر تاريخ يجب ان يكون اكبر من تاريخ التأشيره');", true);

                }
       

        if (CDataConverter.ConvertToInt(Session_CS.parent_id.ToString()) <= 0)
        {
            // //Thread objth = new Thread(new ThreadStart(Send_Visa(obj.Visa_Id.ToString())));
            //// Thread threadObj2 = new Thread(new ThreadStart(Send_Visa));
            // //threadObj.Start(obj.Visa_Id);
            // Thread t1 =new Thread ( delegate() { Send_Visa(obj.Visa_Id.ToString()); });
            //Send_Visa(obj.Visa_Id.ToString());
        }
    }
    public void MyWorkerThreadMethod()
    {
       // Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('thread started!!!!!')</script>");


        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('thread started!!!!!');", true);

    }
    private void Save_trackmanager(int id)
    {
        DataTable dt = General_Helping.GetDataTable("select * from parent_employee where Type=1 and pmp_id= " + Session_CS.pmp_id);
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
    private void Save_inox_Visa(Inbox_Visa_DT obj)
    {

        string Sql_Delete = "delete from Inbox_Visa_Emp where Visa_Id =" + obj.Visa_Id;
        General_Helping.ExcuteQuery(Sql_Delete);
        string Sql_insert = "";
        //foreach (ListItem item in chklst_Visa_Emp.Items)
        //{
        //    if (item.Selected)
        //    {
        //        if (CDataConverter.ConvertToInt(Session_CS.group_id.ToString()) == 2)
        //        {
        //            Sql_insert = "insert into Inbox_Visa_Emp ( Visa_Id , Emp_ID ,Sender_id) values ( " + obj.Visa_Id + "," + item.Value + ",57 " + ")";
        //        }
        //        else
        //        {
        //            Sql_insert = "insert into Inbox_Visa_Emp ( Visa_Id , Emp_ID ,Sender_id) values ( " + obj.Visa_Id + "," + item.Value + "," + CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()) + ")";
        //        }

        //        General_Helping.ExcuteQuery(Sql_insert);

        //        item.Selected = false;
        //    }

        //}

        foreach (ListItem item in lst_emp.Items)
        {

            DataTable dt = General_Helping.GetDataTable("select * from parent_employee where pmp_id = " + CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()));
            if (dt.Rows.Count > 0)
            {

                Sql_insert = "insert into Inbox_Visa_Emp ( Visa_Id , Emp_ID ,Sender_id) values ( " + obj.Visa_Id + "," + item.Value + "," + CDataConverter.ConvertToInt(dt.Rows[0]["parent_pmp_id"].ToString()) + ")";

            }
            else
            {

                Sql_insert = "insert into Inbox_Visa_Emp ( Visa_Id , Emp_ID ,Sender_id) values ( " + obj.Visa_Id + "," + item.Value + "," + CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()) + ")";
            }


            General_Helping.ExcuteQuery(Sql_insert);

            //item.Selected = false;


        }




    }
    //private void Save_inox_Visa(Inbox_Visa_DT obj)
    //{

    //    string Sql_Delete = "delete from Inbox_Visa_Emp where Visa_Id =" + obj.Visa_Id;
    //    General_Helping.ExcuteQuery(Sql_Delete);
    //    foreach (ListItem item in chklst_Visa_Emp.Items)
    //    {
    //        if (item.Selected)
    //        {

    //            string Sql_insert = "insert into Inbox_Visa_Emp ( Visa_Id , Emp_ID ,Sender_id) values ( " + obj.Visa_Id + "," + item.Value + "," + CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()) + ")";
    //            General_Helping.ExcuteQuery(Sql_insert);
    //            item.Selected = false;
    //        }

    //    }
    //}

    protected void lnkBtnUnderStudy_Click(object sender, EventArgs e)
    {
        int id = CDataConverter.ConvertToInt(hidden_Id.Value);
        // int id = Convert.ToInt16(Request["id"]);
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        DataTable DT = new DataTable();
        DT = General_Helping.GetDataTable("select * from Inbox_Track_Manager where inbox_id = " + id);
        if (DT.Rows.Count > 0)
        {
            //conn.Open();
            General_Helping.ExcuteQuery("update Inbox_Track_Manager set status=2 where inbox_id = " + id);
            //string sql = "" + id;
            //SqlCommand cmd = new SqlCommand(sql, conn);
            //cmd.ExecuteNonQuery();
            // conn.Close();
            DataTable dt_get_group_id = General_Helping.GetDataTable("select group_id from employee where pmp_id = " + CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()));
            int group = CDataConverter.ConvertToInt(dt_get_group_id.Rows[0]["group_id"].ToString());
            if (group == 2)
            {
                Response.Redirect("~\\WebForms2");
            }
            else if (group == 3)
            {
                Response.Redirect("~\\WebForms");
            }


        }
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
    public string Get_Visa_Emp(object obj)
    {
        string visa_ID = obj.ToString();
        string emp_name = "";
        DataTable DT = new DataTable();
        DT = General_Helping.GetDataTable("SELECT EMPLOYEE.pmp_name FROM Inbox_Visa_Emp INNER JOIN EMPLOYEE ON Inbox_Visa_Emp.Emp_ID = EMPLOYEE.PMP_ID WHERE Inbox_Visa_Emp.Visa_Id  =" + visa_ID);
        foreach (DataRow dr in DT.Rows)
        {
            emp_name += dr["pmp_name"].ToString() + ",";
        }

        return emp_name;

    }

    private void Fil_Grid_Visa()
    {
        DataTable DT = new DataTable();
        DT = General_Helping.GetDataTable("select * from Inbox_Visa where Inbox_ID=" + hidden_Id.Value);
      //  int empid = CDataConverter.ConvertToInt(DT.Rows[0]["Emp_ID"].ToString());
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
        

        //DataTable dt = General_Helping.GetDataTable("select parent_pmp_id,pmp_id from parent_employee where pmp_id = " + CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()) + "or parent_pmp_id = " + CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()));
        //if (dt.Rows.Count > 0)
        //{
        //    if (CDataConverter.ConvertToInt(dt.Rows[0]["parent_pmp_id"].ToString()) == CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()))
        //    {
        //        GridView_Visa.Columns[8].Visible = GridView_Visa.Columns[9].Visible = GridView_Visa.Columns[10].Visible = true;
        //    }
        //    else
        //    {
        //        GridView_Visa.Columns[8].Visible = GridView_Visa.Columns[9].Visible = GridView_Visa.Columns[10].Visible = false;
        //    }
        //}
        //else
        //{
        //    GridView_Visa.Columns[8].Visible = GridView_Visa.Columns[9].Visible = GridView_Visa.Columns[10].Visible = false;
        //}

    }
    private void Fil_Visa_Lstbox(int ID)
    {
        string sql = "SELECT dbo.EMPLOYEE.pmp_name, dbo.Inbox_Visa_Emp.Emp_ID, dbo.Inbox_Visa_Emp.Visa_Id FROM  dbo.EMPLOYEE INNER JOIN dbo.Inbox_Visa_Emp ON dbo.EMPLOYEE.PMP_ID = dbo.Inbox_Visa_Emp.Emp_ID where dbo.Inbox_Visa_Emp.Visa_Id = " + ID;
        DataTable dt = General_Helping.GetDataTable(sql);
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            ListItem obj = new ListItem(dt.Rows[i]["pmp_name"].ToString(), dt.Rows[i]["Emp_ID"].ToString());
            lst_emp.Items.Add(obj);


        }

    }
    protected void GridView_Visa_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "EditItem")
        {
            Fil_Visa_Control(CDataConverter.ConvertToInt(e.CommandArgument));
            //Fil_Visa_Lst(CDataConverter.ConvertToInt(e.CommandArgument));
            Fil_Visa_Lstbox(CDataConverter.ConvertToInt(e.CommandArgument));

        }
        if (e.CommandName == "RemoveItem")
        {
            Inbox_Visa_DB.Delete(CDataConverter.ConvertToInt(e.CommandArgument));
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم الحذف بنجاح')</script>");
            Fil_Grid_Visa();
            Fil_Emp_Visa_Follow();
        }
        if (e.CommandName == "SendItem")
        {
            string Visa_ID = e.CommandArgument.ToString();
           // Send_Visa(e.CommandArgument.ToString());

            ////////////////////////////////////////////////////////////////////////////////////////////
            /////////////////// Sending Mail Code /////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////
            string dept = Session_CS.dept.ToString();
            string name = "";
            string Succ_names = "", Failed_name = "";
            DataTable dt_Inbox_Visa = General_Helping.GetDataTable("select * from Inbox_Visa_Emp where Visa_Id =" + Visa_ID);
            foreach (DataRow item in dt_Inbox_Visa.Rows)
            {
                Inbox_DB.update_inbox_Track_Emp(hidden_Id.Value, item["Emp_ID"].ToString(), 1, 1);
                string sqlformail = "SELECT * from employee ";
                sqlformail += " where pmp_id= " + item["Emp_ID"].ToString();
                DataTable ds = General_Helping.GetDataTable(sqlformail);

                //DataTable DT = General_Helping.GetDataTable(sqlformail);
                string mail = ds.Rows[0]["mail"].ToString();

                name = ds.Rows[0]["pmp_name"].ToString();


                MailMessage _Message = new MailMessage();
                string str_subj = "";
                if (txt_subject.Text.Length > 160)
                {
                    if (int.Parse(Session_CS.group_id.ToString()) == 3)
                    {
                        str_subj = txt_subject.Text.Substring(0, 160);
                    }
                    else
                        str_subj = txt_subject.Text.Substring(0, 130);


                }
                else
                {
                    str_subj = txt_subject.Text;
                }


                string str_witoutn = str_subj.Replace("\n", "");
                str_subj = str_witoutn.Replace("\r", "");


                if (int.Parse(Session_CS.group_id.ToString()) == 3)
                {

                    _Message.Subject = ("INIR" + " - " + str_subj + " - " + lblLetterDate.Text).ToString();
                }
                else
                {

                    _Message.Subject = ("نظام الادارة الالكترونية - المراسلات" + " - " + str_subj + " - " + lblLetterDate.Text).ToString();
                }


                //_Message.BodyEncoding = Encoding.Unicode;
                //_Message.BodyEncoding = Encoding.UTF8;
                //_Message.SubjectEncoding = Encoding.UTF8;



                bool flag = false;
                string file = "";
                byte[] files = new byte[0];
                MemoryStream ms = new MemoryStream();
                DataTable dt = General_Helping.GetDataTable("select * from Inbox_OutBox_Files where Inbox_Outbox_ID =" + hidden_Id.Value + " and Inbox_Or_Outbox =1 ");
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


                string address2 = System.Web.HttpContext.Current.Request.Url.Authority.ToString();
                String encrypted_id = Encryption.Encrypt(hidden_Id.Value);
                _Message.IsBodyHtml = true;
                _Message.Body = "<html><body dir='rtl'><h3 > السيد - " + name + " </h3>";
                _Message.Body += " <h3 > " + " وصلكم وارد من " + dept + " بتاريخ " + txt_Visa_date.Text + " بخصوص  <br/>" + "<h3 style=" + "color:blue >" + txt_subject.Text + "</h3>" + " </h3>";
                _Message.Body += " <h3 > " + "  وتأشيرة  السيد المدير المختص أن :" + "<h3 style=" + "color:blue >" + txt_Visa_Desc.Text + "</h3>" + " </h3>";

                _Message.Body += " <h3 > ورابط الوارد هو  :<br/>";
                _Message.Body += " <h3 >http:" + "/" + "/" + address2 + "/MainForm/ViewProjectInbox.aspx?id=" + encrypted_id + "&1=1 </h3>";

                if (flag)
                    _Message.Body += "<h3 >  " + " ومرفق الوثائق الخاصة بهذا الوارد</h3> ";



                _Message.Body += "<h3 > مع تحيات </h3> ";
                _Message.Body += "<h3 >   " + Session_CS.e_signature.ToString() + "  </h3> ";
                _Message.Body += "</body></html>";

                //////




                Inbox_Visa_DT obj = Inbox_Visa_DB.SelectByID(CDataConverter.ConvertToInt(Visa_ID));
                obj.mail_sent = 1;
                Inbox_Visa_DB.Save(obj);
                /////////////////////// update have visa = 0/////////////////////////////////////////////
                Update_Have_Visa(Visa_ID);


                try
                {
                    SendingMailthread_class.Sendingmail(_Message, _Message.Subject, _Message.Body, mail, ms, file, encrypted_id, "");

                    Succ_names += name + ",";


                }
                catch (Exception ex)
                {
                    Failed_name += name + ",";


                }
            }
            string message = Show_Alert(Succ_names, Failed_name, Visa_ID);
            Fil_Grid_Visa();
            ///////////////  to store that mohammed eid send visa to employee
            Inbox_Visa_Follows_DT obj_follow = Inbox_Visa_Follows_DB.SelectByID(CDataConverter.ConvertToInt(hidden_Follow_ID.Value));
            obj_follow.Follow_ID = CDataConverter.ConvertToInt(hidden_Follow_ID.Value);
            obj_follow.Inbox_ID = CDataConverter.ConvertToInt(hidden_Id.Value);

            GridViewRow row = (GridViewRow)((ImageButton)e.CommandSource).NamingContainer;
            int xx = row.RowIndex;

            if (row != null)
            {
                v_desc = GridView_Visa.Rows[xx].Cells[3].Text;

                Label download = (Label)row.FindControl("lbl_desc");

                v_desc = download.Text;


            }

            obj_follow.Descrption = message + " ونص التأشيرة:   " + v_desc;

            obj_follow.Descrption = message + "و تم الارسال بواسطة النظام";
            string date = CDataConverter.ConvertDateTimeToFormatdmy(CDataConverter.ConvertDateTimeNowRtnDt());
            obj_follow.Date = date;
            obj_follow.time_follow = CDataConverter.ConvertTimeNowRtnLongTimeFormat();
            obj_follow.entery_pmp_id = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());

            obj_follow.Visa_Emp_id = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
            obj_follow.Follow_ID = Inbox_Visa_Follows_DB.Save(obj_follow);
            Fil_Grid_Visa_Follow();

            GridView_Visa.Rows[xx].Cells[9].Visible = false;
            GridView_Visa.Rows[xx].Cells[10].Visible = false;
            GridView_Visa.Rows[xx].Cells[11].Visible = false;

            //Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('" + message + "')</script>");

            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('" + message + "');", true);

            
        }

    }

    public void Send_Visa(string Visa_ID)
    {
        ////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////// Sending Mail Code /////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////
        string dept = Session_CS.dept.ToString();
        string name = "";
        string Succ_names = "", Failed_name = "";
        DataTable dt_Inbox_Visa = General_Helping.GetDataTable("select * from Inbox_Visa_Emp where Visa_Id =" + Visa_ID);
        foreach (DataRow item in dt_Inbox_Visa.Rows)
        {
            Inbox_DB.update_inbox_Track_Emp(hidden_Id.Value, item["Emp_ID"].ToString(), 1, 1);
            string sqlformail = "SELECT * from employee ";
            sqlformail += " where pmp_id= " + item["Emp_ID"].ToString();
            DataTable ds = General_Helping.GetDataTable(sqlformail);

            //DataTable DT = General_Helping.GetDataTable(sqlformail);
            string mail = ds.Rows[0]["mail"].ToString();

            name = ds.Rows[0]["pmp_name"].ToString();


            MailMessage _Message = new MailMessage();
            string str_subj = "";
            if (txt_subject.Text.Length > 160)
            {
                if (int.Parse(Session_CS.group_id.ToString()) == 3)
                {
                    str_subj = txt_subject.Text.Substring(0, 160);
                }
                else
                    str_subj = txt_subject.Text.Substring(0, 130);


            }
            else
            {
                str_subj = txt_subject.Text;
            }


            string str_witoutn = str_subj.Replace("\n", "");
            str_subj = str_witoutn.Replace("\r", "");


            if (int.Parse(Session_CS.group_id.ToString()) == 3)
            {

                _Message.Subject = ("INIR" + " - " + str_subj + " - " + lblLetterDate.Text).ToString();
            }
            else
            {

                _Message.Subject = ("نظام الادارة الالكترونية - المراسلات" + " - " + str_subj + " - " + lblLetterDate.Text).ToString();
            }


            //_Message.BodyEncoding = Encoding.Unicode;
            //_Message.BodyEncoding = Encoding.UTF8;
            //_Message.SubjectEncoding = Encoding.UTF8;



            bool flag = false;
            string file = "";
            byte[] files = new byte[0];
            MemoryStream ms = new MemoryStream();
            DataTable dt = General_Helping.GetDataTable("select * from Inbox_OutBox_Files where Inbox_Outbox_ID =" + hidden_Id.Value + " and Inbox_Or_Outbox =1 ");
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

        
            string address2 = System.Web.HttpContext.Current.Request.Url.Authority.ToString();
            String encrypted_id = Encryption.Encrypt(hidden_Id.Value);
            _Message.IsBodyHtml = true;
            _Message.Body = "<html><body dir='rtl'><h3 > السيد - " + name + " </h3>";
            _Message.Body += " <h3 > " + " وصلكم وارد من " + dept + " بتاريخ " + txt_Visa_date.Text + " بخصوص  <br/>" + "<h3 style=" + "color:blue >" + txt_subject.Text + "</h3>" + " </h3>";
            _Message.Body += " <h3 > " + "  وتأشيرة  السيد المدير المختص أن :" + "<h3 style=" + "color:blue >" + txt_Visa_Desc.Text + "</h3>" + " </h3>";

            _Message.Body += " <h3 > ورابط الوارد هو  :<br/>";
            _Message.Body += " <h3 >http:" + "/" + "/"+address2+"/MainForm/ViewProjectInbox.aspx?id="+encrypted_id+"&1=1 </h3>";

            if (flag)
                _Message.Body += "<h3 >  " + " ومرفق الوثائق الخاصة بهذا الوارد</h3> ";



            _Message.Body += "<h3 > مع تحيات </h3> ";
            _Message.Body += "<h3 >   " + Session_CS.e_signature.ToString() + "  </h3> ";
            _Message.Body += "</body></html>";

            //////




            Inbox_Visa_DT obj = Inbox_Visa_DB.SelectByID(CDataConverter.ConvertToInt(Visa_ID));
            obj.mail_sent = 1;
            Inbox_Visa_DB.Save(obj);
            /////////////////////// update have visa = 0/////////////////////////////////////////////
            Update_Have_Visa(Visa_ID);

         
            try
            {
                SendingMailthread_class.Sendingmail(_Message,_Message.Subject, _Message.Body, mail, ms, file, encrypted_id, "");

                Succ_names += name + ",";


            }
            catch (Exception ex)
            {
                Failed_name += name + ",";


            }
        }
        string message = Show_Alert(Succ_names, Failed_name, Visa_ID);
        Fil_Grid_Visa();
        ///////////////  to store that mohammed eid send visa to employee
        Inbox_Visa_Follows_DT obj_follow = Inbox_Visa_Follows_DB.SelectByID(CDataConverter.ConvertToInt(hidden_Follow_ID.Value));
        obj_follow.Follow_ID = CDataConverter.ConvertToInt(hidden_Follow_ID.Value);
        obj_follow.Inbox_ID = CDataConverter.ConvertToInt(hidden_Id.Value);

   
        obj_follow.Descrption = message + " ونص التأشيرة:   " + v_desc;

        obj_follow.Descrption = message + "و تم الارسال بواسطة النظام";
        string date = CDataConverter.ConvertDateTimeToFormatdmy(CDataConverter.ConvertDateTimeNowRtnDt());
        obj_follow.Date = date;
        obj_follow.time_follow = CDataConverter.ConvertTimeNowRtnLongTimeFormat();
        obj_follow.entery_pmp_id = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());

        obj_follow.Visa_Emp_id = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
        obj_follow.Follow_ID = Inbox_Visa_Follows_DB.Save(obj_follow);
        Fil_Grid_Visa_Follow();


        //GridView_Visa.Rows[xx].Cells[10].Enabled = false;
        //GridView_Visa.Rows[xx].Cells[11].Enabled = false;

        //Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('" + message + "')</script>");

        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('"+message+"');", true);


    }
    private void Update_Have_Visa(string Visa_Id)
    {
        string Sql_Visa_Sent = "select Visa_Id from Inbox_Visa where mail_sent = 1 and Visa_Id !=" + Visa_Id + " and inbox_id = " + hidden_Id.Value;
        int Visa_Sent_Count = General_Helping.GetDataTable(Sql_Visa_Sent).Rows.Count;
        if (Visa_Sent_Count == GridView_Visa.Rows.Count - 1)
        {
            DataTable DT = General_Helping.GetDataTable("select * from Inbox_Track_Manager where inbox_id = " + hidden_Id.Value);
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
            message += " لقد تم ارسال الايميل بنجاح إلي " + Succ_names;
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



    }
    //private void Fil_Visa_Lst(int ID)
    //{
    //    string Sql_Delete = "select * from Inbox_Visa_Emp where Visa_Id =" + ID;
    //    DataTable DT = General_Helping.GetDataTable(Sql_Delete);
    //    foreach (DataRow dr in DT.Rows)
    //    {
    //        string Value = dr["Emp_ID"].ToString();
    //        ListItem item = chklst_Visa_Emp.Items.FindByValue(Value);
    //        if (item != null)
    //            item.Selected = true;
    //    }


    //}

    private void Fil_Visa_Control(int ID)
    {
        Inbox_Visa_DT obj = Inbox_Visa_DB.SelectByID(ID);
        if (obj.Visa_Id > 0)
        {
            try
            {
                hidden_Visa_Id.Value = obj.Visa_Id.ToString();
                Smart_Search_dept.datatble = General_Helping.GetDataTable("select * from departments where foundation_id =" +CDataConverter.ConvertToInt( Session_CS.foundation_id));

               // Smart_Search_dept.SelectedValue = obj.Dept_ID.ToString();
                if (obj.Important_Degree > 0)
                    ddl_Important_Degree.SelectedValue = obj.Important_Degree.ToString();
                else
                    txt_Important_Degree_Txt.Text = obj.Important_Degree_Txt;
                fil_emp_Visa();
                //if (obj.Emp_ID > 0)
                //{
                //    ListItem item = chklst_Visa_Emp.Items.FindByValue(obj.Emp_ID.ToString());
                //    if (item != null)
                //        item.Selected = true;

                //}
                txt_Visa_Desc.Text = obj.Visa_Desc;
                txt_Dead_Line_DT.Text = obj.Dead_Line_DT;
                ddl_Visa_Goal_ID.SelectedValue = obj.Visa_Goal_ID.ToString();

            }
            catch
            { }
        }



    }
    protected void GridView_Visa_rw_data_bound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string temp_sql = "";
            DataTable Dt;
            string id = (string)Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Visa_Id"));
            temp_sql = "select mail_sent from Inbox_Visa where Visa_Id=" + id;
            Dt = General_Helping.GetDataTable(temp_sql);
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


    protected void GridView_Visa_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView_Visa.PageIndex = e.NewPageIndex;
        Fil_Grid_Visa();
    }



}

