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
using ReportsClass;


public partial class UserControls_View_Commission : System.Web.UI.UserControl
{
    private string sql_Connection = Database.ConnectionString;
    General_Helping Obj_General_Helping = new General_Helping();
    int id;
    //Session_CS Session_CS = new Session_CS();
    protected void Page_Load(object sender, EventArgs e)
    {
        Smart_Search_dept.Show_OrgTree = true;
        if (!string.IsNullOrEmpty(hidden_Number.Value))
        {
            string Div = "div" + hidden_Number.Value;
            string image = "image" + hidden_Number.Value;
          //  Page.RegisterStartupScript("Sucess", "<script language=javascript>ChangeMeCase('" + Div + "','" + image + "','" + hidden_Number.Value + "');</script>");

            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "success", "<script language=javascript>ChangeMeCase('" + Div + "','" + image + "','" + hidden_Number.Value + "');</script>", true);

        }

        if (!IsPostBack)
        {
            Smart_Search_dept.Show_OrgTree = true;
           // fill_sectors();

            int pmp = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
            if (Request.QueryString["id"] != null)
            {
                DateTime str = CDataConverter.ConvertDateTimeNowRtnDt();
                //DateTime st_deadline = System.DateTime.Now.AddDays(7);
                txt_Visa_date.Text = CDataConverter.ConvertDateTimeToFormatdmy(str); 
                //txt_Dead_Line_DT.Text = st_deadline.ToString("dd/MM/yyyy");
                txt_Follow_Date.Text = CDataConverter.ConvertDateTimeToFormatdmy(str);
                txt_time_follow.Text = CDataConverter.ConvertTimeNowRtnLongTimeFormat(); 

                String decrypted_id = Encryption.Decrypt(Request.QueryString["id"].ToString());
                id = Convert.ToInt16(decrypted_id);

                hidden_Id.Value = id.ToString();

                if (CDataConverter.ConvertToInt(Session_CS.group_id.ToString()) == 3)
                {
                    DataTable dt_closed = General_Helping.GetDataTable(" select * from Commission_Track_Emp where Emp_ID = " + pmp + " and Commission_id = " + id);
                    if (dt_closed.Rows.Count > 0)
                    {
                        btn_close_com.Visible = true;
                    }
                    else
                        btn_close_com.Visible = false;
                }
                else
                {
                    DataTable dt_closed = General_Helping.GetDataTable(" select * from commission where Resp_emp_close = " + pmp + " and id = " + id);
                    if (CDataConverter.ConvertToInt(Session_CS.parent_id.ToString()) > 0 || dt_closed.Rows.Count > 0)
                    {
                        btn_close_com.Visible = true;
                        btn_end_late.Visible = true;

                        //Trfollow.Visible = false;
                    }
                    else
                    {
                        btn_close_com.Visible = false;
                        btn_end_late.Visible = false;
                    }
                }


                tr_old_emp.Visible = false;
                tr_old_emp_resp.Visible = false;
                string sql_for_chklist_emp = " select * from pmp_fav_View where pmp_fav_View.employee_id = " + CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
                DataTable dt_emp_fav = General_Helping.GetDataTable(sql_for_chklist_emp);
                chklst_Visa_Emp_All.DataSource = dt_emp_fav;
                chklst_Visa_Emp_All.DataBind();
                //if (Session_CS.pmp_id.ToString() == "57")
                DataTable dt = General_Helping.GetDataTable("select parent_pmp_id,pmp_id from parent_employee where pmp_id = " + CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()) + "or parent_pmp_id = " + CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()));
                if (dt.Rows.Count > 0)
                {
                    if (CDataConverter.ConvertToInt(dt.Rows[0]["parent_pmp_id"].ToString()) == CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()))
                    {
                        Trfollow.Visible = false;
                        TemplateE.Visible = false;
                        TemplateA.Visible = false;
                        tr_follow_date.Visible = false;
                        tr_follow_desc.Visible = false;
                        tr_follow_doc.Visible = false;
                        tr_follow_person.Visible = false;
                        tr_follow_save.Visible = false;

                        tr_follow_time.Visible = false;

                    }

                }
                else
                {

                    if (pmp == 70)
                    {
                        //Trfollow.Visible = false;
                        tr_follow_date.Visible = false;
                        tr_follow_desc.Visible = false;
                        tr_follow_doc.Visible = false;
                        tr_follow_person.Visible = false;
                        tr_follow_save.Visible = false;

                    }
                }
            }

            string sql_update = "update Commission_follow_emp set Have_follow = 0";
            sql_update += " where ( Commission_follow_emp.pmp_id =" + pmp;
            sql_update += " AND Commission_follow_emp.Commission_id = " + id;
            sql_update += ")";
            General_Helping.ExcuteQuery(sql_update);
            //    SqlCommand cmd = new SqlCommand(sql_update, conn);
            //    cmd.ExecuteNonQuery();
            //    conn.Close();

            //}

            DataTable dt_com = General_Helping.GetDataTable("select * from Commission_Track_Emp where Commission_id=" + id);
            if (dt_com.Rows.Count > 0)
            {
                if (CDataConverter.ConvertToInt(dt_com.Rows[0]["Commission_Status"].ToString()) == 3)
                {
                    btn_end_late.Visible = false;
                    btn_close_com.Visible = false;
                }
            }


            Fill_Controll(id);
            Fil_Grid_Documents();
            Fil_Grid_Visa_Follow();
            Fil_Dll();
            fil_emp_Visa();
            Fil_Emp_Visa_Follow();
            Fil_Grid_Visa();
            if (CDataConverter.ConvertToInt(Session_CS.group_id.ToString()) == 3)
            {
                Smart_Search_dept.SelectedValue = "15";
            }


            if (Session_CS.pmp_id > 0)
            {
               // drop_sectors.SelectedValue = Session_CS.sec_id.ToString();
                fill_depts();



            }

        }


    }


    //private void fill_sectors()
    //{
    //    DataTable dt = Sectors_DB.SelectAll(0, CDataConverter.ConvertToInt(Session_CS.foundation_id.ToString()));
    //    drop_sectors.DataSource = dt;

    //    drop_sectors.DataBind();
    //    drop_sectors.Items.Insert(0, new ListItem("إختر القطاع", "0"));

    //}

    protected void fill_depts()
    {
        //if (drop_sectors.SelectedValue != "0")
        //{
            Smart_Search_dept.sql_Connection = sql_Connection;

            string Query = "select * from Departments where foundation_id='" + Session_CS.foundation_id+ "' ";
            Smart_Search_dept.datatble = General_Helping.GetDataTable(Query);
            Smart_Search_dept.Value_Field = "Dept_ID";
            Smart_Search_dept.Text_Field = "Dept_name";
            Smart_Search_dept.Orderby = "ORDER BY LTRIM(Dept_name)";
            Smart_Search_dept.DataBind();

        //}

        //else
        //{
        //    Smart_Search_dept.Clear_Controls();
        //}

        //////////////////////////////////////////////////////////


    }

    //protected void drop_sectors_SelectedIndexChanged(object sender, EventArgs e)
    //{

    //    fill_depts();
    //    fill_resp_Emp();

    //}


    protected void radlst_Type_SelectedIndexChanged(object sender, EventArgs e)
    {

        fill_resp_Emp();
    }

    private void fill_resp_Emp()
    {
        tr_emp_list.Visible = true;
        string sql, sql_emp = "";

        if (radlst_Type.SelectedValue == "1")
        {
            sql_emp = " select * from pmp_fav_View where pmp_fav_View.employee_id = " + CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
            if (Smart_Search_dept.SelectedValue != "")
            {
                sql_emp += " AND Dept_Dept_id = " + Smart_Search_dept.SelectedValue;
            }
            //if (ddl_sectors2.SelectedValue != "" && ddl_sectors2.SelectedValue != "0")
            //{
            sql_emp += "  and  sec_sec_id=0";
            //}



        }
        else if (radlst_Type.SelectedValue == "2")
        {
            // sql_emp = " select * from employee where dbo.EMPLOYEE.workstatus = 1";


            sql_emp = "SELECT     EMPLOYEE.*,Departments.* FROM Departments  INNER JOIN EMPLOYEE ON Departments.Dept_id = EMPLOYEE.Dept_Dept_id where  EMPLOYEE.PMP_ID not in(select parent_pmp_id from dbo.parent_employee) and dbo.EMPLOYEE.workstatus = 1 and EMPLOYEE.foundation_id='" + Session_CS.foundation_id + "'";

            if (Smart_Search_dept.SelectedValue != "")
            {
                sql_emp += " and Dept_Dept_id = " + Smart_Search_dept.SelectedValue;
            }
            //// if (ddl_sectors2.SelectedValue != "" && ddl_sectors2.SelectedValue != "0")
            //// {
            //     sql_emp += "and  Sectors.Sec_id=0"; //+ ddl_sectors2.SelectedValue;
            //// }

        }
        else if (radlst_Type.SelectedValue == "3")
        {
            // sql_emp = " select * from employee where rol_rol_id=3  and dbo.EMPLOYEE.workstatus = 1";

            sql_emp = "SELECT     EMPLOYEE.*,Departments.* FROM Departments  INNER JOIN EMPLOYEE ON Departments.Dept_id = EMPLOYEE.Dept_Dept_id where dbo.EMPLOYEE.workstatus = 1 and rol_rol_id=3 and EMPLOYEE.foundation_id='" + Session_CS.foundation_id + "'";


            if (Smart_Search_dept.SelectedValue != "")
            {
                sql_emp += " AND Dept_Dept_id = " + Smart_Search_dept.SelectedValue;
            }

            //  //if (ddl_sectors2.SelectedValue != "" && ddl_sectors2.SelectedValue != "0")
            ////  {
            //  sql_emp += "and  Sectors.Sec_id="; +ddl_sectors2.SelectedValue;
            // // }

        }
        else if (radlst_Type.SelectedValue == "4")
        {
            // sql_emp = " select * from employee where contact_person=1 and dbo.EMPLOYEE.workstatus = 1 ";

            sql_emp = "SELECT     EMPLOYEE.*,Departments.* FROM Departments  INNER JOIN EMPLOYEE ON Departments.Dept_id = EMPLOYEE.Dept_Dept_id where dbo.EMPLOYEE.workstatus = 1 and contact_person=1 and EMPLOYEE.foundation_id='" + Session_CS.foundation_id + "'";

            if (Smart_Search_dept.SelectedValue != "")
            {
                sql_emp += " AND Dept_Dept_id = " + Smart_Search_dept.SelectedValue;
            }

            //// if (ddl_sectors2.SelectedValue != "" && ddl_sectors2.SelectedValue != "0")
            // //{
            //     sql_emp += "and  Sectors.Sec_id="; + ddl_sectors2.SelectedValue;
            // //}

        }

        else if (radlst_Type.SelectedValue == "5")
        {
            sql_emp = "  select EMPLOYEE.pmp_name + ' - رئيس ' + +' '+ Commitee.Commitee_Title as pmp_name ,EMPLOYEE.PMP_ID from EMPLOYEE inner join commitee_presidents on  EMPLOYEE.PMP_ID=commitee_presidents.pmp_id inner join Commitee on commitee_presidents.comt_id = Commitee.ID where  Commitee.foundation_id='" + Session_CS.foundation_id + "'";

        }

        else if (radlst_Type.SelectedValue == "6")
        {

            sql_emp = "select EMPLOYEE.pmp_name COLLATE DATABASE_DEFAULT  + ' -  ' + Departments.Dept_name  as pmp_name,EMPLOYEE.PMP_ID from EMPLOYEE inner join commitee_presidents on  EMPLOYEE.PMP_ID=commitee_presidents.pmp_id inner join Departments on  commitee_presidents.dept_id = Departments.Dept_id   inner join Sectors  on Sectors.Sec_id = Departments.Sec_sec_id where Sectors.foundation_id='" + Session_CS.foundation_id + "'";
        }
        DataTable dt_emp_fav = General_Helping.GetDataTable(sql_emp);
        chklst_Visa_Emp_All.DataSource = dt_emp_fav;
        chklst_Visa_Emp_All.DataBind();
    }
    protected void btn_add_Click(object sender, EventArgs e)
    {

        fill_listbox();
        //TabPanel_All.ActiveTab = TabPanel_Visa;
    }
    public void fill_listbox()
    {
        ListItem obj = new ListItem();
        foreach (ListItem item in chklst_Visa_Emp_All.Items)
        {
            if (item.Selected && lst_emp.Items.FindByValue(item.Value) == null)
            {
                obj = new ListItem(item.Text, item.Value);
                lst_emp.Items.Add(obj);
                item.Selected = false;
            }


        }
        foreach (ListItem item in lst_emp.Items)
        {
            obj = new ListItem(item.Text, item.Value);
            drop_Resp_close_emp.Items.Add(obj);
        }
        drop_Resp_close_emp.Items.Insert(0, new ListItem(" اختر الموظف المسئول عن اغلاق التكليف ......", "0"));

    }
    protected void btn_delete_Click(object sender, EventArgs e)
    {
        drop_Resp_close_emp.Items.Clear();
        if (lst_emp.SelectedValue == "")
        {
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('يجب اختيار موظف ليتم الحذف')</script>");
        }
        else
        {
            lst_emp.Items.Remove(lst_emp.SelectedItem);
            ListItem obj = new ListItem();
            foreach (ListItem item in lst_emp.Items)
            {
                obj = new ListItem(item.Text, item.Value);
                drop_Resp_close_emp.Items.Add(obj);
            }
            drop_Resp_close_emp.Items.Insert(0, new ListItem(" اختر الموظف المسئول عن اغلاق التكليف ......", "0"));
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

        //Smart_Org_ID.sql_Connection = sql_Connection;
        //Smart_Org_ID.Query = "SELECT Org_ID, Org_Desc FROM Organization";
        //Smart_Org_ID.Value_Field = "Org_ID";
        //Smart_Org_ID.Text_Field = "Org_Desc";
        //Smart_Org_ID.DataBind();

        //fil_emp();
        //Smart_Emp_ID.sql_Connection = sql_Connection;
        //Smart_Emp_ID.Query = "SELECT PMP_ID, pmp_name FROM EMPLOYEE ";
        //Smart_Emp_ID.Value_Field = "PMP_ID";
        //Smart_Emp_ID.Text_Field = "pmp_name";
        //Smart_Emp_ID.DataBind();

        //this.Smrt_Srch_DropDep.Value_Handler += new Smart_Search.Delegate_Selected_Value(MOnMember_Data);
        //Inbox_organization.SelectedValue;
        // fill project

        //Smart_Search_proj.sql_Connection = sql_Connection;
        //Smart_Search_proj.Query = "SELECT Proj_id, Proj_Title FROM Project ";
        //Smart_Search_proj.Value_Field = "Proj_id";

        //Smart_Search_proj.Text_Field = "Proj_Title";
        //Smart_Search_proj.DataBind();

        Smart_Search_dept.sql_Connection = sql_Connection;
        //Smart_Search_dept.Query = "SELECT Dept_id, Dept_name FROM Departments ";
        string Query = "SELECT Dept_id, Dept_name FROM Departments ";
        Smart_Search_dept.datatble = General_Helping.GetDataTable(Query);
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
        fill_resp_Emp();
    }
    protected void dropdept_fun()
    {



        fil_emp_Visa();


    }
    private void Fil_Dll()
    {
        //DataTable DT = new DataTable();
        //DT = General_Helping.GetDataTable("select * from Departments");
        //Obj_General_Helping.SmartBindDDL(ddl_Visa_Dept_ID, DT, "Dept_ID", "Dept_name", "....اختر اسم الإدارة ....");


    }

    private void fil_emp_Visa()
    {
        int Dept_ID = CDataConverter.ConvertToInt(Smart_Search_dept.SelectedValue);
        string sql = "SELECT PMP_ID, pmp_name FROM EMPLOYEE ";
        if (Dept_ID > 0)
        {
            sql += " where Dept_Dept_id = " + Dept_ID;

        }
        sql += " order by pmp_name asc";
        chklst_Visa_Emp.DataSource = General_Helping.GetDataTable(sql);
        chklst_Visa_Emp.DataBind();


    }

    protected void ddl_Visa_Dept_ID_SelectedIndexChanged(object sender, EventArgs e)
    {
        //fil_emp_Visa();
    }
    protected void btn_end_late_Click(object sender, EventArgs e)
    {

        ///////////// change status = 3  /////////////////////////////////////////////
        int id = Convert.ToInt16(hidden_Id.Value);
        DataTable DT = new DataTable();
        DT = General_Helping.GetDataTable("select * from Commission where ID = " + id);
        if (DT.Rows.Count > 0)
        {
            string sql = "update Commission set finished=1 where ID =" + id;
            General_Helping.ExcuteQuery(sql);
            string sql2 = "update Commission_Track_Emp set Commission_Status=2 where Commission_id = " + id;
            General_Helping.ExcuteQuery(sql2);


        }
        //DataTable dt_Inbox_Visa = General_Helping.GetDataTable("select * from Inbox_Track_Emp where inbox_id =" + hidden_Id.Value);
        //foreach (DataRow item in dt_Inbox_Visa.Rows)
        //{
        //    Inbox_DB.update_inbox_Track_Emp(hidden_Id.Value, item["Emp_ID"].ToString(), 3, 1);
        //}

        Commission_Visa_Follows_DT obj = Commission_Visa_Follows_DB.SelectByID(CDataConverter.ConvertToInt(hidden_Follow_ID.Value));
        obj.Follow_ID = CDataConverter.ConvertToInt(hidden_Follow_ID.Value);
        obj.Commission_ID = CDataConverter.ConvertToInt(hidden_Id.Value);
        obj.Descrption = "تم انهاء تأخير الموضوع";
        string date = CDataConverter.ConvertDateTimeToFormatdmy(CDataConverter.ConvertDateTimeNowRtnDt());
        obj.Date = date;
        obj.time_follow = CDataConverter.ConvertDateTimeNowRtnDt().ToLocalTime().ToLongTimeString();
        obj.entery_pmp_id = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
        obj.Visa_Emp_id = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
        obj.Follow_ID = Commission_Visa_Follows_DB.Save(obj);
        Fil_Grid_Visa_Follow();
        ///////////////////////////////////////////////////////////////// when dr hesham close inbox update all have follow in inbox follow emp to be zero
        //General_Helping.ExcuteQuery("update inbox_follow_emp set Have_follow = 0 where inbox_id = " + id);
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('تم انهاء تأخير الموضوع بنجاح' )</script>");

        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('تم انهاء تأخير الموضوع بنجاح');", true);



    }
    private void Fill_Controll(int id)
    {
        try
        {
            Commission_DT obj = Commission_DB.SelectByID(id);
            hidden_Id.Value = obj.ID.ToString();
            drop_Resp_close_emp.SelectedValue = (obj.Resp_emp_close.ToString());
            //lblCode.Text = obj.Code;
            lblLetterDate.Text = obj.Date;

            txt_subject.Text = obj.Subject.ToString();
            txt_notes.Text = obj.Notes.ToString();
            DataTable DT_vd = new DataTable();
            DataTable dt_closeemp = new DataTable();
            DT_vd = General_Helping.GetDataTable("select * from Commission_Visa where Commission_id = " + id);
            if (DT_vd.Rows.Count > 0)
            {
                txt_Visa_Desc.Text = DT_vd.Rows[0]["Visa_Desc"].ToString();
                txt_Dead_Line_DT.Text = DT_vd.Rows[0]["Dead_Line_DT"].ToString();
            }

            dt_closeemp = General_Helping.GetDataTable("select Commission.*, dbo.EMPLOYEE. pmp_name from Commission  inner join dbo.EMPLOYEE on Commission.Resp_emp_close=EMPLOYEE.PMP_ID where ID = " + id);

            if (dt_closeemp.Rows.Count > 0)
            {
                lbl_close.Visible = true;
                lbl_closeperson.Visible = true;

                lbl_closeperson.Text = dt_closeemp.Rows[0]["pmp_name"].ToString();
             
            }

        }
        catch
        { }
    }
    protected void btn_Visa_Follow_Click(object sender, EventArgs e)
    {
        if (CDataConverter.ConvertToInt(hidden_Id.Value) > 0)
        {
            Commission_Visa_Follows_DT obj = Commission_Visa_Follows_DB.SelectByID(CDataConverter.ConvertToInt(hidden_Follow_ID.Value));
            obj.Follow_ID = CDataConverter.ConvertToInt(hidden_Follow_ID.Value);
            obj.Commission_ID = CDataConverter.ConvertToInt(hidden_Id.Value);
            obj.Descrption = txt_Descrption.Text;
            obj.Date = txt_Follow_Date.Text;
            obj.time_follow = txt_time_follow.Text;
            obj.entery_pmp_id = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
            obj.Visa_Emp_id = CDataConverter.ConvertToInt(ddl_Visa_Emp_id.SelectedValue);
            obj.Follow_ID = Commission_Visa_Follows_DB.Save(obj);

         

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

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = " update Commission_Visa_Follows set File_data =@File_data ,File_name=@File_name,File_ext=@File_ext where Follow_ID =@Follow_ID";
                cmd.Parameters.Add("@File_data", SqlDbType.VarBinary);
                cmd.Parameters.Add("@File_name", SqlDbType.NVarChar);
                cmd.Parameters.Add("@File_ext", SqlDbType.NVarChar);
                cmd.Parameters.Add("@Follow_ID", SqlDbType.BigInt);

               // cmd.Parameters["@File_data"].Value = Input;
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

                        //ShowAlertMessage("   عفوا لم يتم الإتصال بقاعدة البيانات الداخلية");

                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('عفوا لم يتم الإتصال بقاعدة البيانات الداخلية');", true);

                    }
                }
                //con.Open();
                //cmd.ExecuteScalar();
                //con.Close();



            }
            ///////////// change have follow = 1 , All_visa_sent=0 /////////////////////////////////////////////

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
           
            ArrayList arr = new ArrayList();
            //ArrayList arr_sender = new ArrayList();

            int id = CDataConverter.ConvertToInt(hidden_Id.Value);
            if (CDataConverter.ConvertToInt(Session_CS.parent_id.ToString()) == 0)
            {
                string sql = "SELECT dbo.Commission_Visa_Emp.Sender_ID, dbo.Commission_Visa_Emp.Emp_ID FROM dbo.Commission_Visa INNER JOIN dbo.Commission_Visa_Emp ON dbo.Commission_Visa.Visa_Id = dbo.Commission_Visa_Emp.Visa_Id where dbo.Commission_Visa.Commission_ID = " + id + "AND dbo.Commission_Visa_Emp.Emp_ID = " + CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
                DataTable dt = General_Helping.GetDataTable(sql);
                int sender1 = CDataConverter.ConvertToInt(dt.Rows[0]["Sender_id"].ToString());


                string both_see = " SELECT     Commission_Visa_Emp.Visa_Emp_ID, Commission_Visa_Emp.Visa_Id, Commission_Visa_Emp.Emp_ID, Commission_Visa_Emp.Sender_ID, Commission_Visa.Commission_ID FROM Commission_Visa_Emp LEFT OUTER JOIN  Commission_Visa ON Commission_Visa_Emp.Visa_Id = Commission_Visa.Visa_Id ";
                both_see += " where Sender_id=" + sender1 + " and Commission_ID =" + id;
                DataTable dt_both_see = General_Helping.GetDataTable(both_see);
                for (int i = 0; i < dt_both_see.Rows.Count; i++)
                {
                    if (CDataConverter.ConvertToInt(dt_both_see.Rows[i]["Emp_ID"].ToString()) != CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()))
                    {
                        string sql_exist = "select * from Commission_follow_emp where Commission_id = " + id + " AND Commission_follow_emp.pmp_id = " + CDataConverter.ConvertToInt(dt_both_see.Rows[i]["Emp_ID"].ToString());
                        DataTable dt_exist = General_Helping.GetDataTable(sql_exist);
                        if (dt_exist.Rows.Count > 0)
                        {
                            General_Helping.ExcuteQuery(" update Commission_follow_emp set Have_follow = 1 where (Commission_id = " + id + "  AND Commission_follow_emp.pmp_id = " + CDataConverter.ConvertToInt(dt_both_see.Rows[i]["Emp_ID"].ToString()) + ")");

                        }
                        else
                        {
                            string Sql_insert = "insert into Commission_follow_emp (pmp_id , Have_follow ,Commission_id) values ( " + CDataConverter.ConvertToInt(dt_both_see.Rows[i]["Emp_ID"].ToString()) + ",1," + id + ")";
                            General_Helping.ExcuteQuery(Sql_insert);
                        }
                         //arr = new ArrayList(i);
                        arr.Add(CDataConverter.ConvertToInt(dt_both_see.Rows[i]["Emp_ID"].ToString()));
                        
                    }
                    

                }   

                string sql_sender_exist = "select * from Commission_follow_emp where Commission_id = " + id + " AND Commission_follow_emp.pmp_id = " + sender1;
                DataTable dt_sender_exist = General_Helping.GetDataTable(sql_sender_exist);
                if (dt_sender_exist.Rows.Count > 0)
                {
                    General_Helping.ExcuteQuery(" update Commission_follow_emp set Have_follow = 1 where (Commission_id = " + id + " AND Commission_follow_emp.pmp_id = " + sender1 + ")");
                }
                else
                {
                    string Sql_insert_parent = "insert into Commission_follow_emp (pmp_id , Have_follow ,Commission_id) values ( " + CDataConverter.ConvertToInt(dt.Rows[0]["Sender_ID"].ToString()) + ",1," + id + ")";
                    General_Helping.ExcuteQuery(Sql_insert_parent);
                }
             

            }
            string Succ_names = "", Failed_name = "";
            string name = "";
            DataTable dt_sendmail = General_Helping.GetDataTable("select * from Commission_follow_emp where Commission_id = " + id + "and Have_follow= 1 and pmp_id <>" + Session_CS.pmp_id);
            foreach (int  item in arr)
            {
                string sqlformail = "SELECT * from employee ";
                sqlformail += " where pmp_id= " + item;

                DataTable ds = General_Helping.GetDataTable(sqlformail);

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

                    _Message.Subject = ("Com" + " - " + str_subj + " - " + lblLetterDate.Text).ToString();
                }
                else
                {

                    _Message.Subject = ("نظام الادارة الالكترونية - المراسلات" + " - " + str_subj + " - " + lblLetterDate.Text).ToString();
                }


                //_Message.BodyEncoding = Encoding.Unicode;
                _Message.BodyEncoding = Encoding.UTF8;
                _Message.SubjectEncoding = Encoding.UTF8;
                string address2 = System.Web.HttpContext.Current.Request.Url.Authority.ToString();
                String encrypted_id = Encryption.Encrypt(hidden_Id.Value);
                string file = "";
                MemoryStream ms = new MemoryStream();
                //_Message.IsBodyHtml = true;
                _Message.Body = "<html><body dir='rtl'><h3 > السيد - " + name + " </h3>";

                _Message.Body += " <h3 > " + "  وصلكم متابعة من  " + "" + Session_CS.pmp_name.ToString() + " بتاريخ " + txt_Visa_date.Text + " بخصوص  <br/>" + "<h3 style=" + "color:blue >" + txt_subject.Text + "</h3>" + " </h3>";
                _Message.Body += " <h3 > " + "  والمتابعة هي   :" + "<h3 style=" + "color:blue >" + txt_Descrption.Text + "</h3>" + " </h3>";



                _Message.Body += " <h3 > ورابط التكليف هو  :<br/>";
                _Message.Body += " <h3 >http:" + "/" + "/" + address2 + "/MainForm/View_Commission.aspx?id=" + Request.QueryString["id"] + "&1=1 </h3>";



                ////////http://localhost:4665/Projects_Management/WebForms2/ViewProjectInbox.aspx?id=5458


                _Message.Body += "<h3 > مع تحيات </h3> ";
                _Message.Body += "<h3 >   " + Session_CS.e_signature.ToString() + "  </h3> ";
                _Message.Body += "</body></html>";


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
            string message = Show_Alert2(Succ_names, Failed_name);
       
            Clear_visa_Follow();

            Fil_Grid_Visa_Follow();
        }
        else
        {
           // Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('يجب إدخال بيانات الخطاب أولا')</script>");

            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('يجب إدخال بيانات الخطاب أولا');", true);


        }

    }
    private void Clear_visa_Follow()
    {
        hidden_Follow_ID.Value =
        txt_Descrption.Text =
        txt_Follow_Date.Text = "";
        ddl_Visa_Emp_id.SelectedIndex = 0;
    }
    private void Fil_Grid_Visa_Follow()
    {
        DataTable DT = new DataTable();
        string Sql = "SELECT Commission_Visa_Follows.Follow_ID,Commission_Visa_Follows.File_name,Commission_Visa_Follows.time_follow,Commission_Visa_Follows.Commission_ID, Commission_Visa_Follows.Descrption, Commission_Visa_Follows.Date, Commission_Visa_Follows.Visa_Emp_id, EMPLOYEE.pmp_name " +
                     " FROM Commission_Visa_Follows INNER JOIN EMPLOYEE ON Commission_Visa_Follows.Visa_Emp_id = EMPLOYEE.PMP_ID where Commission_ID =" + hidden_Id.Value;
        DT = General_Helping.GetDataTable(Sql);

        GridView_Visa_Follow.DataSource = DT;
        GridView_Visa_Follow.DataBind();
    }
    protected void GridView_Visa_Follow_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "EditItem")
        {

            Commission_Visa_Follows_DT obj = Commission_Visa_Follows_DB.SelectByID(CDataConverter.ConvertToInt(e.CommandArgument));
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
            Commission_Visa_Follows_DB.Delete(CDataConverter.ConvertToInt(e.CommandArgument));
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم الحذف بنجاح')</script>");
            Fil_Grid_Visa_Follow();
        }
    }
    private void Fil_Emp_Visa_Follow()
    {
        if (CDataConverter.ConvertToInt(hidden_Id.Value) > 0)
        {
            DataTable DT = new DataTable();
            string sql = " SELECT  distinct   EMPLOYEE.PMP_ID, EMPLOYEE.pmp_name, Commission_Visa.Commission_ID " +
                         " FROM  Commission_Visa_Emp INNER JOIN  EMPLOYEE ON Commission_Visa_Emp.Emp_ID = EMPLOYEE.PMP_ID INNER JOIN  Commission_Visa ON Commission_Visa_Emp.Visa_Id = Commission_Visa.Visa_Id INNER JOIN Commission ON Commission_Visa.Commission_ID = Commission.ID " +
                         " where Commission_ID=" + hidden_Id.Value + " AND EMPLOYEE.PMP_ID = " + CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
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
        DT = General_Helping.GetDataTable("select * from Commission_Files where Inbox_Or_Outbox = 1 and Commission_ID=" + id);

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
            string s = Server.MapPath("../Reports/InboxOutboxReport/Commission_Data.rpt");
            rd.Load(s);
            Reports.Load_Report(rd);
            rd.SetParameterValue("@Com_ID", CDataConverter.ConvertToInt(hidden_Id.Value));
            rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
            rd.SetParameterValue("@user", user, "footerRep.rpt");
            rd.SetParameterValue("@found_id", found_id, "Logo_Header_pic_dynamic.rpt");

            if (rd.Rows.Count == 0)
            {
              //  ShowAlertMessage("!!!!!هذا التقرير لا يوجد به بيانات للعرض !!!!");

                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('!!!!!هذا التقرير لا يوجد به بيانات للعرض !!!!');", true);

                return;
            }
            else
            {
                rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report");
            }
        }


    }
    protected void btn_close_com_Click(object sender, EventArgs e)
    {
        int pmp = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
        ///////////// change status = 3  /////////////////////////////////////////////
        int id = Convert.ToInt16(hidden_Id.Value);
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        //DataTable DT = new DataTable();
        //DT = General_Helping.GetDataTable("select * from Commission_Track_Emp where Commission_id = " + hidden_Id.Value);
        //if (DT.Rows.Count > 0)
        //{
        //    conn.Open();
        //    string sql = "update Commission_Track_Emp set Commission_Status=3 where Commission_id =" + hidden_Id.Value;
        //    SqlCommand cmd = new SqlCommand(sql, conn);
        //    cmd.ExecuteNonQuery();
        //    conn.Close();

        //}
        DataTable DT = General_Helping.GetDataTable("select * from Commission where ID = " + id);
        if (DT.Rows.Count > 0)
        {
            string sql = "update Commission set finished=1 , Actual_emp_close = " + pmp + ", Date_close='" + CDataConverter.ConvertDateTimeToFormatdmy(CDataConverter.ConvertDateTimeNowRtnDt()) + "' where ID =" + id;
            General_Helping.ExcuteQuery(sql);


        }
        DataTable dt_Commission_Visa = General_Helping.GetDataTable("select * from Commission_Track_Emp where Commission_id =" + hidden_Id.Value);
        foreach (DataRow item in dt_Commission_Visa.Rows)
        {
            Commission_DB.update_Commission_Track_Emp(hidden_Id.Value, item["Emp_ID"].ToString(), 3, 1);
        }

        Commission_Visa_Follows_DT obj = Commission_Visa_Follows_DB.SelectByID(CDataConverter.ConvertToInt(hidden_Follow_ID.Value));
        obj.Follow_ID = CDataConverter.ConvertToInt(hidden_Follow_ID.Value);
        obj.Commission_ID = CDataConverter.ConvertToInt(hidden_Id.Value);
        obj.Descrption = "تم إغلاق الموضوع";
        string date = CDataConverter.ConvertDateTimeToFormatdmy(CDataConverter.ConvertDateTimeNowRtnDt());
        obj.Date = date;
        obj.time_follow = CDataConverter.ConvertDateTimeNowRtnDt().ToLocalTime().ToLongTimeString();
        obj.entery_pmp_id = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
        obj.Visa_Emp_id = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
        obj.Follow_ID = Commission_Visa_Follows_DB.Save(obj);
        Fil_Grid_Visa_Follow();
        ///////////////////////////////////////////////////////////////// when dr hesham close inbox update all have follow in inbox follow emp to be zero
        General_Helping.ExcuteQuery("update Commission_follow_emp set Have_follow = 0 where Commission_id = " + id);
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////

       // Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('تم إغلاق الموضوع بنجاح' )</script>");

        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('تم إغلاق الموضوع بنجاح');", true);


        btn_close_com.Visible = false;
        btn_end_late.Visible = false;

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
        int id = Convert.ToInt16(hidden_Id.Value);
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        //DataTable DT = new DataTable();
        //DT = General_Helping.GetDataTable("select * from Inbox_Track_Manager where inbox_id = " + id);
        if (Request.QueryString["id"] != null)
        {
            conn.Open();
            Commission_Visa_Follows_DT obj_follow = Commission_Visa_Follows_DB.SelectByID(CDataConverter.ConvertToInt(hidden_Follow_ID.Value));
            obj_follow.Follow_ID = CDataConverter.ConvertToInt(hidden_Follow_ID.Value);
            obj_follow.Commission_ID = CDataConverter.ConvertToInt(hidden_Id.Value);
            obj_follow.Descrption = txt_Visa_Desc.Text;
            string date = CDataConverter.ConvertDateTimeToFormatdmy(CDataConverter.ConvertDateTimeNowRtnDt());
            obj_follow.Date = date;
            obj_follow.time_follow = CDataConverter.ConvertDateTimeNowRtnDt().ToLocalTime().ToLongTimeString();
            obj_follow.entery_pmp_id = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
            obj_follow.Visa_Emp_id = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
            obj_follow.Follow_ID = Commission_Visa_Follows_DB.Save(obj_follow);
            Fil_Grid_Visa_Follow();

            if (CDataConverter.ConvertToInt(Session_CS.parent_id.ToString()) > 0)
            {
                Update_Have_Visa_all_emp(id);
            }

            //lnkBtnUnderStudy.Visible = false;
            Save_Visa(id);
          //  Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('تم حفظ التاشيرة بنجاح')</script>");
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('تم حفظ التاشيرة بنجاح');", true);

            clear_Visa_cntrl();
            Fil_Grid_Visa();
            lst_emp.Items.Clear();
        }
        else
        {
           // Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لا يوجد بيانات للخطاب')</script>");

            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('لا يوجد بيانات للخطاب');", true);

        }
    }

    private void Update_Have_Visa_all_emp(int Com_ID)
    {
        //string sql = "update Inbox_Track_Manager set status=0,Have_Follow=0,Have_visa=1 , ";
        //sql += "Visa_Desc = '" + txt_Visa_Desc.Text + "'";
        //sql += " where inbox_id =" + Inbox_ID;
        //General_Helping.ExcuteQuery(sql);

        string sql_all_User = "update Commission_Track_Emp set Commission_Status =2 where Commission_id=" + Com_ID;
        General_Helping.ExcuteQuery(sql_all_User);
    }

    private void clear_Visa_cntrl()
    {
        hidden_Visa_Id.Value = "";

    }

    private void Save_Visa(int id)
    {
        Commission_Visa_DT obj = new Commission_Visa_DT();
        obj.Visa_Id = CDataConverter.ConvertToInt(hidden_Visa_Id.Value);
        obj.Commission_ID = id;
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

        obj.Visa_Id = Commission_Visa_DB.Save(obj);

        Save_inox_Visa(obj);
        if (CDataConverter.ConvertToInt(Session_CS.parent_id.ToString()) <= 0)
            Send_Visa(obj.Visa_Id.ToString());

    }

    private void Save_inox_Visa(Commission_Visa_DT obj)
    {

        string Sql_Delete = "delete from Commission_Visa_Emp where Visa_Id =" + obj.Visa_Id;
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
            Commission_Visa_Emp_DT obj_commvisa = new Commission_Visa_Emp_DT();
            obj_commvisa.Visa_Id = obj.Visa_Id;
            obj_commvisa.Emp_ID = CDataConverter.ConvertToInt(item.Value);

            DataTable dt = General_Helping.GetDataTable("select * from parent_employee where pmp_id = " + CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()));
            if (dt.Rows.Count > 0)
            {

                //  Sql_insert = "insert into Commission_Visa_Emp ( Visa_Id , Emp_ID ,Sender_id) values ( " + obj.Visa_Id + "," + item.Value + "," + CDataConverter.ConvertToInt(dt.Rows[0]["parent_pmp_id"].ToString()) + ")";


                obj_commvisa.Sender_ID = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());

            }
            else
            {

                // Sql_insert = "insert into Commission_Visa_Emp ( Visa_Id , Emp_ID ,Sender_id) values ( " + obj.Visa_Id + "," + item.Value + "," + CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()) + ")";

                obj_commvisa.Sender_ID = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());

            }


            // General_Helping.ExcuteQuery(Sql_insert);

            Commission_Visa_Emp_DB.Save(obj_commvisa);




        }
        Commission_Visa_Emp_DT comm_visa_obj = new Commission_Visa_Emp_DT();
        comm_visa_obj.Visa_Id = obj.Visa_Id;

        /// to insert the row of parent in table commission visa emp///////////////////////
        DataTable dt_new = General_Helping.GetDataTable("select * from parent_employee where pmp_id = " + CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()));
        if (dt_new.Rows.Count > 0)
        {

            //  Sql_insert = "insert into Commission_Visa_Emp ( Visa_Id , Emp_ID ,Sender_id) values ( " + obj.Visa_Id + "," + CDataConverter.ConvertToInt(dt_new.Rows[0]["parent_pmp_id"].ToString()) + "," + CDataConverter.ConvertToInt(dt_new.Rows[0]["parent_pmp_id"].ToString()) + ")";

            comm_visa_obj.Emp_ID = CDataConverter.ConvertToInt(dt_new.Rows[0]["parent_pmp_id"].ToString());
            comm_visa_obj.Sender_ID = CDataConverter.ConvertToInt(dt_new.Rows[0]["parent_pmp_id"].ToString());

        }
        else
        {

            //  Sql_insert = "insert into Commission_Visa_Emp ( Visa_Id , Emp_ID ,Sender_id) values ( " + obj.Visa_Id + "," + CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()) + "," + CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()) + ")";


            comm_visa_obj.Emp_ID = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
            comm_visa_obj.Sender_ID = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
        }


        // General_Helping.ExcuteQuery(Sql_insert);

        Commission_Visa_Emp_DB.Save(comm_visa_obj);




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
        //int id = Convert.ToInt16(Request["id"]);
        //SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        ////DataTable DT = new DataTable();
        ////DT = General_Helping.GetDataTable("select * from Inbox_Track_Manager where inbox_id = " + id);
        //if (Request.QueryString["id"] != null)
        //{
        //    conn.Open();
        //    string sql = "update Inbox_Track_Manager set status=2 where inbox_id =" + id;
        //    SqlCommand cmd = new SqlCommand(sql, conn);
        //    cmd.ExecuteNonQuery();
        //    conn.Close();
        //    DataTable dt_get_group_id = General_Helping.GetDataTable("select group_id from employee where pmp_id = " + CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()));
        //    int group = CDataConverter.ConvertToInt(dt_get_group_id.Rows[0]["group_id"].ToString());
        //    if (group == 2)
        //    {
        //        Response.Redirect("~\\WebForms2");
        //    }
        //    else if (group == 3)
        //    {
        //        Response.Redirect("~\\WebForms");
        //    }


        //}
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
        string sql = "SELECT EMPLOYEE.pmp_name FROM Commission_Visa_Emp INNER JOIN EMPLOYEE ON Commission_Visa_Emp.Emp_ID = EMPLOYEE.PMP_ID WHERE Commission_Visa_Emp.Visa_Id  =" + visa_ID + " and emp_id <> sender_id ";
        DataTable dt_new = General_Helping.GetDataTable("select * from parent_employee where pmp_id = " + CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()));

        DT = General_Helping.GetDataTable(sql);
        foreach (DataRow dr in DT.Rows)
        {
            emp_name += dr["pmp_name"].ToString() + ",";
        }

        return emp_name;

    }

    private void Fil_Grid_Visa()
    {
        DataTable DT = new DataTable();
        DT = General_Helping.GetDataTable("select * from Commission_Visa where Commission_ID=" + hidden_Id.Value);

        GridView_Visa.DataSource = DT;
        GridView_Visa.DataBind();
        DataTable dt = General_Helping.GetDataTable("select parent_pmp_id,pmp_id from parent_employee where pmp_id = " + CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()) + "or parent_pmp_id = " + CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()));
        if (dt.Rows.Count > 0)
        {
            if (CDataConverter.ConvertToInt(dt.Rows[0]["parent_pmp_id"].ToString()) == CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()))
            {
                GridView_Visa.Columns[8].Visible = GridView_Visa.Columns[9].Visible = GridView_Visa.Columns[10].Visible = true;
            }
            else
            {
                GridView_Visa.Columns[8].Visible = GridView_Visa.Columns[9].Visible = GridView_Visa.Columns[10].Visible = false;
            }
        }
        else
        {
            GridView_Visa.Columns[8].Visible = GridView_Visa.Columns[9].Visible = GridView_Visa.Columns[10].Visible = false;
        }

    }
    private void Fil_Visa_Lstbox(int ID)
    {
        string sql = "SELECT dbo.EMPLOYEE.pmp_name, dbo.Commission_Visa_Emp.Emp_ID, dbo.Commission_Visa_Emp.Visa_Id FROM  dbo.EMPLOYEE INNER JOIN dbo.Commission_Visa_Emp ON dbo.EMPLOYEE.PMP_ID = dbo.Commission_Visa_Emp.Emp_ID where dbo.Commission_Visa_Emp.Visa_Id = " + ID;
        DataTable dt = General_Helping.GetDataTable(sql);
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            ListItem obj = new ListItem(dt.Rows[i]["pmp_name"].ToString(), dt.Rows[i]["Emp_ID"].ToString());
            lst_emp.Items.Add(obj);
            drop_Resp_close_emp.Items.Add(obj);

        }
        drop_Resp_close_emp.Items.Insert(0, new ListItem(" اختر الموظف المسئول عن اغلاق التكليف ......", "0"));
        Commission_DT objtab = Commission_DB.SelectByID(CDataConverter.ConvertToInt(hidden_Id.Value));
        drop_Resp_close_emp.SelectedValue = objtab.Resp_emp_close.ToString();
    }
    protected void GridView_Visa_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "EditItem")
        {
            Fil_Visa_Control(CDataConverter.ConvertToInt(e.CommandArgument));
            Fil_Visa_Lstbox(CDataConverter.ConvertToInt(e.CommandArgument));
            Fil_Visa_Lst(CDataConverter.ConvertToInt(e.CommandArgument));


        }
        if (e.CommandName == "RemoveItem")
        {
            Commission_Visa_DB.Delete(CDataConverter.ConvertToInt(e.CommandArgument));
          //  Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم الحذف بنجاح')</script>");

            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('لقد تم الحذف بنجاح');", true);

            Fil_Grid_Visa();
            Fil_Emp_Visa_Follow();
        }
        if (e.CommandName == "SendItem")
            Send_Visa(e.CommandArgument.ToString());

    }

    private void Send_Visa(string Visa_ID)
    {
        ////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////// Sending Mail Code /////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////
        string dept = Session_CS.dept.ToString();
        string name = "";
        string Succ_names = "", Failed_name = "";
        DataTable dt_Commission_Visa = General_Helping.GetDataTable("select * from Commission_Visa_Emp where Visa_Id =" + Visa_ID);
        foreach (DataRow item in dt_Commission_Visa.Rows)
        {
            if (CDataConverter.ConvertToInt(Session_CS.parent_id.ToString()) == 0)
            {
                DataTable dt_parent = General_Helping.GetDataTable("select * from parent_employee where pmp_id = " + CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()));
                if (dt_parent.Rows.Count > 0)
                {
                    if (CDataConverter.ConvertToInt(item["Emp_id"].ToString()) == CDataConverter.ConvertToInt(dt_parent.Rows[0]["parent_pmp_id"].ToString()))
                    {
                        Commission_DB.update_Commission_Track_Emp(hidden_Id.Value, item["Emp_ID"].ToString(), 2, 1);
                    }
                    else
                        Commission_DB.update_Commission_Track_Emp(hidden_Id.Value, item["Emp_ID"].ToString(), 1, 1);
                }
                else
                {
                    Commission_DB.update_Commission_Track_Emp(hidden_Id.Value, item["Emp_ID"].ToString(), 1, 1);
                }

            }
            else
            {
                if (CDataConverter.ConvertToInt(item["Emp_id"].ToString()) == CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()))
                {
                    Commission_DB.update_Commission_Track_Emp(hidden_Id.Value, item["Emp_ID"].ToString(), 2, 1);
                }
                else
                    Commission_DB.update_Commission_Track_Emp(hidden_Id.Value, item["Emp_ID"].ToString(), 1, 1);
            }


            string sqlformail = "SELECT * from employee ";
            sqlformail += " where pmp_id= " + item["Emp_ID"].ToString();
            if (CDataConverter.ConvertToInt(Session_CS.parent_id.ToString()) > 0)
            {
                if (CDataConverter.ConvertToInt(item["Emp_id"].ToString()) == CDataConverter.ConvertToInt(Session_CS.parent_id.ToString()))
                {
                    sqlformail += " and pmp_id <> " + CDataConverter.ConvertToInt(Session_CS.parent_id.ToString());
                }

            }
            DataTable ds = General_Helping.GetDataTable(sqlformail);
            if (ds.Rows.Count > 0)
            {
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

                    _Message.Subject = ("Com" + " - " + str_subj + " - " + lblLetterDate.Text).ToString();
                }
                else
                {

                    _Message.Subject = ("نظام الادارة الالكترونية - المراسلات" + " - " + str_subj + " - " + lblLetterDate.Text).ToString();
                }


                //_Message.BodyEncoding = Encoding.Unicode;
                _Message.BodyEncoding = Encoding.UTF8;
                _Message.SubjectEncoding = Encoding.UTF8;



                bool flag = false;
                DataTable dt = General_Helping.GetDataTable("select * from Commission_Files where Commission_ID =" + hidden_Id.Value + " and Inbox_Or_Outbox =1 ");
                string file = "";
                MemoryStream ms = new MemoryStream();
                foreach (DataRow dr in dt.Rows)
                {

                    if (dr["File_data"] != DBNull.Value)
                    {

                         file = dr["File_name"].ToString() + dr["File_ext"].ToString();
                        byte[] files = (byte[])dr["File_data"];
                         ms = new MemoryStream(files);
                        _Message.Attachments.Add(new Attachment(ms, file));
                        flag = true;

                    }
                }

              
                string address2 = System.Web.HttpContext.Current.Request.Url.Authority.ToString();
                String encrypted_id = Encryption.Encrypt(hidden_Id.Value);
                //_Message.IsBodyHtml = true;
                _Message.Body = "<html><body dir='rtl'><h3 > السيد - " + name + " </h3>";
                if (CDataConverter.ConvertToInt(Session_CS.parent_id.ToString()) == 0)
                {
                    _Message.Body += " <h3 > " + "  وصلكم تكليف من  " + "" + Session_CS.pmp_name.ToString() + " بتاريخ " + txt_Visa_date.Text + " بخصوص  <br/>" + "<h3 style=" + "color:blue >" + txt_subject.Text + "</h3>" + " </h3>";
                    _Message.Body += " <h3 > " + "  وتكليف  السيد المدير المختص أن :" + "<h3 style=" + "color:blue >" + txt_Visa_Desc.Text + "</h3>" + " </h3>";
                }
                else
                {
                    _Message.Body += " <h3 > " + "  وصلكم تكليف من الادارة العليا لقطاع البنية المعلوماتية " + "" + " بتاريخ " + txt_Visa_date.Text + " بخصوص  <br/>" + "<h3 style=" + "color:blue >" + txt_subject.Text + "</h3>" + " </h3>";
                    _Message.Body += " <h3 > " + "  وتكليف  السيد المدير المختص أن :" + "<h3 style=" + "color:blue >" + txt_Visa_Desc.Text + "</h3>" + " </h3>";
                }

                _Message.Body += " <h3 > ورابط التكليف هو  :<br/>";
                _Message.Body += " <h3 >http:" + "/" + "/" + address2 + "/MainForm/View_Commission.aspx?id=" + Request.QueryString["id"] + "&1=1 </h3>";

                if (flag)
                    _Message.Body += "<h3 >  " + " ومرفق الوثائق الخاصة بهذا التكليف</h3> ";



                _Message.Body += "<h3 > مع تحيات </h3> ";
                _Message.Body += "<h3 >   " + Session_CS.e_signature.ToString() + "  </h3> ";
                _Message.Body += "</body></html>";

                //////




                Commission_Visa_DT obj = Commission_Visa_DB.SelectByID(CDataConverter.ConvertToInt(Visa_ID));
                obj.mail_sent = 1;
                Commission_Visa_DB.Save(obj);
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



        }
        string message = Show_Alert(Succ_names, Failed_name, Visa_ID);
        Fil_Grid_Visa();
        ///////////////  to store that mohammed eid send visa to employee
        Commission_Visa_Follows_DT obj_follow = Commission_Visa_Follows_DB.SelectByID(CDataConverter.ConvertToInt(hidden_Follow_ID.Value));
        obj_follow.Follow_ID = CDataConverter.ConvertToInt(hidden_Follow_ID.Value);
        obj_follow.Commission_ID = CDataConverter.ConvertToInt(hidden_Id.Value);

        obj_follow.Descrption = message + "و تم الارسال بواسطة النظام";
        string date = CDataConverter.ConvertDateTimeToFormatdmy(CDataConverter.ConvertDateTimeNowRtnDt());
        obj_follow.Date = date;
        obj_follow.time_follow = CDataConverter.ConvertDateTimeNowRtnDt().ToLocalTime().ToLongTimeString();
        obj_follow.entery_pmp_id = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());

        obj_follow.Visa_Emp_id = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
        obj_follow.Follow_ID = Commission_Visa_Follows_DB.Save(obj_follow);
        Fil_Grid_Visa_Follow();

   


       // Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('" + message + "')</script>");

        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('" + message + "');", true);


    }
    private void Update_Have_Visa(string Visa_Id)
    {
     

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
            Commission_Visa_DT obj = Commission_Visa_DB.SelectByID(CDataConverter.ConvertToInt(visa_id));
            obj.mail_sent = 1;
            Commission_Visa_DB.Save(obj);


        }

        return message;


        //      if (!string.IsNullOrEmpty(Failed_name))
        //        Page.RegisterStartupScript("Sucess", "<script language=javascript>alert(' لم يتم ارسال الايميل إلي " + Failed_name + "')</script>");

    }
    private string Show_Alert2(string Succ_names, string Failed_name)
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



        return message;


        //      if (!string.IsNullOrEmpty(Failed_name))
        //        Page.RegisterStartupScript("Sucess", "<script language=javascript>alert(' لم يتم ارسال الايميل إلي " + Failed_name + "')</script>");

    }
    private void Fil_Visa_Lst(int ID)
    {
        string Sql_Delete = "select * from Commission_Visa_Emp where Visa_Id =" + ID;
        DataTable DT = General_Helping.GetDataTable(Sql_Delete);
        foreach (DataRow dr in DT.Rows)
        {
            string Value = dr["Emp_ID"].ToString();
            ListItem item = chklst_Visa_Emp.Items.FindByValue(Value);
            if (item != null)
                item.Selected = true;
        }


    }

    private void Fil_Visa_Control(int ID)
    {
        Commission_Visa_DT obj = Commission_Visa_DB.SelectByID(ID);
        if (obj.Visa_Id > 0)
        {
            try
            {
                hidden_Visa_Id.Value = obj.Visa_Id.ToString();
                Smart_Search_dept.SelectedValue = obj.Dept_ID.ToString();
                if (obj.Important_Degree > 0)
                    ddl_Important_Degree.SelectedValue = obj.Important_Degree.ToString();
                else
                    txt_Important_Degree_Txt.Text = obj.Important_Degree_Txt;
                fil_emp_Visa();
                if (obj.Emp_ID > 0)
                {
                    ListItem item = chklst_Visa_Emp.Items.FindByValue(obj.Emp_ID.ToString());
                    if (item != null)
                        item.Selected = true;

                }
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
            temp_sql = "select mail_sent from Commission_Visa where Visa_Id=" + id;
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
    protected void Drop_arabic_doc_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (CDataConverter.ConvertToInt(Drop_arabic_doc.SelectedValue) == 1)
        //{
        //    string File_Name = Server.MapPath("~//Uploads/arabic doc/نموذج تقرير متكامل.doc");
        //    FileStream fs = new FileStream(File_Name, FileMode.Open, FileAccess.Read);
        //    byte[] bytes = new byte[fs.Length];
        //    fs.Read(bytes, 0, System.Convert.ToInt32(fs.Length));
        //    fs.Close();
        //    Response.ContentType = "application/x-unknown";
        //    string File_Name_Show = "";
        //    File_Name_Show = "نموذج تقرير متكامل.doc";
        //    Response.AddHeader("Content-Disposition", "attachment; filename=" + Server.UrlPathEncode(File_Name_Show));
        //    Response.BinaryWrite(bytes);
        //    Response.Flush();
        //    Response.Close();
        //}
        //string File_Name_Show = "";
        //string File_Name = "";
        //if (CDataConverter.ConvertToInt(Drop_arabic_doc.SelectedValue) == 1)
        //{
        //    File_Name = Server.MapPath("~//Uploads/arabic doc/نموذج تقرير متكامل.doc");
        //    File_Name_Show = "نموذج تقرير متكامل.doc";


        //}
        //else if (CDataConverter.ConvertToInt(Drop_arabic_doc.SelectedValue) == 2)
        //{
        //    File_Name = Server.MapPath("~//Uploads/arabic doc/نموذج تقرير مختصر.doc");
        //    File_Name_Show = "نموذج تقرير مختصر.doc";

        //}
        //else
        //{
        //    File_Name = Server.MapPath("~//Uploads/arabic doc/نموذج خطاب.doc");
        //    File_Name_Show = "نموذج خطاب.doc";

        //}
        //FileStream fs = new FileStream(File_Name, FileMode.Open, FileAccess.Read);
        //byte[] bytes = new byte[fs.Length];
        //fs.Read(bytes, 0, System.Convert.ToInt32(fs.Length));
        //fs.Close();
        //Response.ContentType = "application/x-unknown";
        //Response.AddHeader("Content-Disposition", "attachment; filename=" + Server.UrlPathEncode(File_Name_Show));
        //Response.BinaryWrite(bytes);
        //Response.Flush();
        //Response.Close();
        //Drop_arabic_doc.SelectedValue = "0";
        //Drop_english_doc.SelectedValue = "0";
    }
    protected void Drop_english_doc_SelectedIndexChanged(object sender, EventArgs e)
    {
        //string File_Name_Show = "";
        //string File_Name = "";
        //if (CDataConverter.ConvertToInt(Drop_english_doc.SelectedValue) == 1)
        //{
        //    File_Name = Server.MapPath("~//Uploads/English doc/Detailed Report Temp.doc");
        //    File_Name_Show = "Detailed Report Temp.doc";

        //}
        //else if (CDataConverter.ConvertToInt(Drop_english_doc.SelectedValue) == 2)
        //{
        //    File_Name = Server.MapPath("~//Uploads/English doc/Short Report Temp.doc");
        //    File_Name_Show = "Short Report Temp.doc";

        //}
        //else
        //{
        //    File_Name = Server.MapPath("~//Uploads/English doc/Letter Temp.doc");
        //    File_Name_Show = "Letter Temp.doc";

        //}
        //Drop_english_doc.SelectedIndex = 0;
        //FileStream fs = new FileStream(File_Name, FileMode.Open, FileAccess.Read);
        //byte[] bytes = new byte[fs.Length];
        //fs.Read(bytes, 0, System.Convert.ToInt32(fs.Length));
        //fs.Close();
        //Response.ContentType = "application/x-unknown";
        //Response.AddHeader("Content-Disposition", "attachment; filename=" + Server.UrlPathEncode(File_Name_Show));
        //Response.BinaryWrite(bytes);
        //Response.Flush();

        //Response.Close();



    }

    protected void btn_arabic_doc_Click(object sender, EventArgs e)
    {
        if (Drop_arabic_doc.SelectedValue == "0")
        {
           // Page.RegisterStartupScript("Sucess", "<script language=javascript>alert(' يجب اختيار نموذج ')</script>");

            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('يجب اختيار نموذج');", true);

        }
        else
        {
            string File_Name_Show = "";
            string File_Name = "";
            if (CDataConverter.ConvertToInt(Drop_arabic_doc.SelectedValue) == 1)
            {
                File_Name = Server.MapPath("~//Uploads/arabic doc/نموذج تقرير متكامل.doc");
                File_Name_Show = "نموذج تقرير متكامل.doc";


            }
            else if (CDataConverter.ConvertToInt(Drop_arabic_doc.SelectedValue) == 2)
            {
                File_Name = Server.MapPath("~//Uploads/arabic doc/نموذج تقرير مختصر.doc");
                File_Name_Show = "نموذج تقرير مختصر.doc";

            }
            else if (CDataConverter.ConvertToInt(Drop_arabic_doc.SelectedValue) == 3)
            {
                File_Name = Server.MapPath("~//Uploads/arabic doc/نموذج خطاب.doc");
                File_Name_Show = "نموذج خطاب.doc";

            }
            else if (CDataConverter.ConvertToInt(Drop_arabic_doc.SelectedValue) == 4)
            {
                File_Name = Server.MapPath("~//Uploads/arabic doc/خطاب الى مدير مكتب الوزير.docx");
                File_Name_Show = "خطاب الى مدير مكتب الوزير.docx";

            }
            else if (CDataConverter.ConvertToInt(Drop_arabic_doc.SelectedValue) == 5)
            {
                File_Name = Server.MapPath("~//Uploads/arabic doc/ل- احمد فرج.docx");
                File_Name_Show = "نموذج ل- احمد فرج.docx";

            }
            else if (CDataConverter.ConvertToInt(Drop_arabic_doc.SelectedValue) == 6)
            {
                File_Name = Server.MapPath("~//Uploads/arabic doc/ل ايمن صادق.doc");
                File_Name_Show = "نموذج ل ايمن صادق.doc";

            }
            else if (CDataConverter.ConvertToInt(Drop_arabic_doc.SelectedValue) == 7)
            {
                File_Name = Server.MapPath("~//Uploads/arabic doc/مذكرة  موارد .doc");
                File_Name_Show = "نموذج مذكرة  موارد .doc";

            }
            else if (CDataConverter.ConvertToInt(Drop_arabic_doc.SelectedValue) == 8)
            {
                File_Name = Server.MapPath("~//Uploads/arabic doc/مذكرة اتصالات .docx");
                File_Name_Show = "نموذج مذكرة اتصالات .docx";

            }
            else if (CDataConverter.ConvertToInt(Drop_arabic_doc.SelectedValue) == 9)
            {
                File_Name = Server.MapPath("~//Uploads/arabic doc/مذكرة ا-محمد شاهين تلفيات.docx");
                File_Name_Show = "نموذج مذكرة ا-محمد شاهين تلفيات.docx";

            }
            else if (CDataConverter.ConvertToInt(Drop_arabic_doc.SelectedValue) == 10)
            {
                File_Name = Server.MapPath("~//Uploads/arabic doc/مذكرة عرض ل-ايمن صادق .doc");
                File_Name_Show = "نموذج مذكرة عرض ل-ايمن صادق .doc";

            }
            else if (CDataConverter.ConvertToInt(Drop_arabic_doc.SelectedValue) == 11)
            {
                File_Name = Server.MapPath("~//Uploads/arabic doc/وزير .docx");
                File_Name_Show = "وزير .docx";

            }


            FileStream fs = new FileStream(File_Name, FileMode.Open, FileAccess.Read);
            byte[] bytes = new byte[fs.Length];
            fs.Read(bytes, 0, System.Convert.ToInt32(fs.Length));
            fs.Close();
            Response.ContentType = "application/x-unknown";
            Response.AddHeader("Content-Disposition", "attachment; filename=" + Server.UrlPathEncode(File_Name_Show));
            Response.BinaryWrite(bytes);
            Response.Flush();
            Response.Close();

        }
    }
    protected void btn_english_doc_Click(object sender, EventArgs e)
    {
        if (Drop_english_doc.SelectedValue == "0")
        {
            //Page.RegisterStartupScript("Sucess", "<script language=javascript>alert(' يجب اختيار نموذج ')</script>");

            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('يجب اختيار نموذج');", true);

        }
        else
        {
            string File_Name_Show = "";
            string File_Name = "";

            if (CDataConverter.ConvertToInt(Drop_english_doc.SelectedValue) == 1)
            {
                File_Name = Server.MapPath("~//Uploads/English doc/Detailed Report Temp.doc");
                File_Name_Show = "Detailed Report Temp.doc";

            }
            else if (CDataConverter.ConvertToInt(Drop_english_doc.SelectedValue) == 2)
            {
                File_Name = Server.MapPath("~//Uploads/English doc/Short Report Temp.doc");
                File_Name_Show = "Short Report Temp.doc";

            }
            else
            {
                File_Name = Server.MapPath("~//Uploads/English doc/Letter Temp.doc");
                File_Name_Show = "Letter Temp.doc";

            }
            FileStream fs = new FileStream(File_Name, FileMode.Open, FileAccess.Read);
            byte[] bytes = new byte[fs.Length];
            fs.Read(bytes, 0, System.Convert.ToInt32(fs.Length));
            fs.Close();
            Response.ContentType = "application/x-unknown";
            Response.AddHeader("Content-Disposition", "attachment; filename=" + Server.UrlPathEncode(File_Name_Show));
            Response.BinaryWrite(bytes);
            Response.Flush();
            Response.Close();

        }
    }
}

