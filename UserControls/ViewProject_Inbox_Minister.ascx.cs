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


public partial class UserControls_ViewProject_Inbox_Minister : System.Web.UI.UserControl
{
    private string sql_Connection = Database.ConnectionString;
    General_Helping Obj_General_Helping = new General_Helping();
    int id;
    //Session_CS Session_CS = new Session_CS();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["id"] != null)
            {

                id = Convert.ToInt16(Request["id"]);
                hidden_Id.Value = id.ToString();
                //if (Session_CS.pmp_id.ToString() == "57")
                DataTable dt = General_Helping.GetDataTable("select parent_pmp_id,pmp_id from parent_employee where pmp_id = " + CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()) + "or parent_pmp_id = " + CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()));
                if (dt.Rows.Count > 0)
                {
                    if (CDataConverter.ConvertToInt(dt.Rows[0]["parent_pmp_id"].ToString()) == CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()))
                    {
                        tr_follow_date.Visible = false;
                        tr_follow_desc.Visible = false;
                        tr_follow_doc.Visible = false;
                        tr_follow_person.Visible = false;
                        tr_follow_save.Visible = false;
                        Trfollow.Visible = false;
                        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                        DataTable DT = new DataTable();
                        DT = General_Helping.GetDataTable("select * from Inbox_Track_Manager where inbox_id = " + id + " AND Type_Track=3");
                        if (DT.Rows.Count > 0)
                        {

                            //foreach (DataRow rw in DT.Rows)
                            //{
                            DataRow rw = DT.Rows[0];
                            if (rw["IS_New_Mail"].ToString() != "2")
                            {
                                if (rw["Have_visa"].ToString() != "1")
                                    lnkBtnUnderStudy.Visible = true;
                                //conn.Open();
                                //string sql = "update Inbox_Track_Manager set IS_New_Mail=0,IS_Old_Mail=1,Have_Follow=0 where inbox_id =" + id;
                                //SqlCommand cmd = new SqlCommand(sql, conn);
                                //cmd.ExecuteNonQuery();
                                //conn.Close();
                            }
                            // }

                        }
                    }
                    else
                    {
                        tr_mngr1.Visible =
                        tr_mngr2.Visible = false;

                        GridView_Visa.Columns[6].Visible = false;
                    }
                }
                else
                {
                    tr_mngr1.Visible =
                   tr_mngr2.Visible = false;
                    //Trfollow.Visible = True;
                    GridView_Visa.Columns[6].Visible = false;
                }
                //}
                //else
                //{
                //tr_mngr1.Visible =
                //    tr_mngr2.Visible = true;
                //GridView_Visa.Columns[6].Visible = false;
                // }

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

            }


        }
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

        //Smart_Search_Proj.sql_Connection = sql_Connection;
        //Smart_Search_Proj.Query = "SELECT Proj_id, Proj_Title FROM Project ";
        //Smart_Search_Proj.Value_Field = "Proj_id";
        //Smart_Search_Proj.Text_Field = "Proj_Title";
        //Smart_Search_Proj.DataBind();

        Smart_Search_dept.sql_Connection = sql_Connection;
        //Smart_Search_dept.Query = "SELECT Dept_id, Dept_name FROM Departments ";
        string Query = "SELECT Dept_id, Dept_name FROM Departments ";
        Smart_Search_dept.datatble = General_Helping.GetDataTable(Query);
        Smart_Search_dept.Value_Field = "Dept_id";
        Smart_Search_dept.Text_Field = "Dept_name";
        Smart_Search_dept.DataBind();
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



        fil_emp_Visa();


    }
    private void Fil_Dll()
    {
        //DataTable DT = new DataTable();
        //DT = General_Helping.GetDataTable("select * from Departments");
        //Obj_General_Helping.SmartBindDDL(ddl_Visa_Dept_ID, DT, "Dept_ID", "Dept_name", "....اختر اسم الإدارة ....");


    }
    protected void btn_close_inbox_Click(object sender, EventArgs e)
    {

        ///////////// change In_new_mail = 3  /////////////////////////////////////////////

        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        DataTable DT = new DataTable();
        DT = General_Helping.GetDataTable("select * from Inbox_Track_Manager where inbox_id = " + hidden_Id.Value);
        if (DT.Rows.Count > 0)
        {
            conn.Open();
            string sql = "update Inbox_Track_Manager set status=3,Have_Follow=0,All_visa_sent=0,Have_Visa=0,IS_Old_Mail=0,IS_New_Mail=3 where inbox_id =" + hidden_Id.Value;
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();

        }
        DataTable dt_Inbox_Visa = General_Helping.GetDataTable("select * from Inbox_Track_Emp where inbox_id =" + hidden_Id.Value);
        foreach (DataRow item in dt_Inbox_Visa.Rows)
        {
            Inbox_Minister_DB.update_inbox_Track_Emp(hidden_Id.Value, item["Emp_ID"].ToString(), 3, 3);
        }

        Inbox_minister_Visa_Follows_DT obj = Inbox_minister_Visa_Follows_DB.SelectByID(CDataConverter.ConvertToInt(hidden_Follow_ID.Value));
        obj.Follow_ID = CDataConverter.ConvertToInt(hidden_Follow_ID.Value);
        obj.Inbox_ID = CDataConverter.ConvertToInt(hidden_Id.Value);
        obj.Descrption = "تم إغلاق الموضوع";
        string date = CDataConverter.ConvertDateTimeNowRtrnString();
        obj.Date = date;
        obj.time_follow = CDataConverter.ConvertDateTimeNowRtnDt().ToLocalTime().ToLongTimeString();
        obj.entery_pmp_id = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
        obj.Visa_Emp_id = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
        obj.Follow_ID = Inbox_minister_Visa_Follows_DB.Save(obj);
        Fil_Grid_Visa_Follow();
        Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('تم إغلاق الموضوع بنجاح' )</script>");


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

    private void Fill_Controll(int id)
    {
        try
        {
            Inbox_Minister_DT obj = Inbox_Minister_DB.SelectByID(id);
            hidden_Id.Value = obj.ID.ToString();
            hidden_Proj_id.Value = obj.Proj_id.ToString();
            if (obj.Type == 2)
            {
                lblLetterType.Text = "تأشيرة";
            }
            if (obj.Type == 1)
            { lblLetterType.Text = "تأشيرة"; }
            lblCode.Text = obj.Code;
            lblLetterDate.Text = obj.Date;
            //ddl_Type.SelectedValue = obj.Type.ToString();
            if (obj.Source_Type == 1)
            {
                lblSourceType.Text = "البريد";
            }
            if (obj.Source_Type == 2)
            { lblSourceType.Text = "الايميل"; }
            if (obj.Source_Type == 3)
            { lblSourceType.Text = "الفاكس"; }


            if (obj.Org_Dept_Name != "")
                lblDept_in.Text = obj.Org_Dept_Name.ToString();

            if (obj.Org_Out_Box_Person != "")
                lblOrg_Out_Box_Person.Text = obj.Org_Out_Box_Person.ToString();

            lblOrg_Out_Box_DT.Text = obj.Org_Out_Box_DT.ToString();
            lblOrg_Out_Box_Code.Text = obj.Org_Out_Box_Code.ToString();
            lbl_paper_no.Text = obj.Paper_No.ToString();
            lbl_att_no.Text = obj.Org_Out_Box_Code.ToString();
            txt_subject.Text = obj.Subject.ToString();
            txt_notes.Text = obj.Notes.ToString();
            DataTable DT_vd = new DataTable();
            DT_vd = General_Helping.GetDataTable("select * from Inbox_Track_Manager where inbox_id = " + id + " AND Type_Track=3 ");
            if (DT_vd.Rows.Count > 0)
                txt_Visa_Desc.Text = DT_vd.Rows[0]["Visa_Desc"].ToString();
            //ddl_Related_Type.SelectedValue = obj.Related_Type.ToString();
            if (obj.Related_Type.ToString() != "")
            {
                if (obj.Related_Type == 1)
                { lblRelatedType.Text = "تأشيرة جديدة"; }
                if (obj.Related_Type == 2)
                { lblRelatedType.Text = "رد على مذكرة عرض"; }



            }
            if (obj.Org_Id.ToString() != "")
            {
                DataTable DT = new DataTable();
                DT = General_Helping.GetDataTable("SELECT  [Org_ID], [Org_Desc] FROM Organization WHERE Org_ID=" + obj.Org_Id);
                if (DT.Rows.Count != 0)
                {
                    lblOrgName.Text = DT.Rows[0]["Org_Desc"].ToString();
                }

            }


        }
        catch
        { }
    }
    protected void btn_Visa_Follow_Click(object sender, EventArgs e)
    {
        if (CDataConverter.ConvertToInt(hidden_Id.Value) > 0)
        {
            Inbox_minister_Visa_Follows_DT obj = Inbox_minister_Visa_Follows_DB.SelectByID(CDataConverter.ConvertToInt(hidden_Follow_ID.Value));
            obj.Follow_ID = CDataConverter.ConvertToInt(hidden_Follow_ID.Value);
            obj.Inbox_ID = CDataConverter.ConvertToInt(hidden_Id.Value);
            obj.Descrption = txt_Descrption.Text;
            obj.Date = txt_Follow_Date.Text;
            obj.entery_pmp_id = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
            obj.Visa_Emp_id = CDataConverter.ConvertToInt(ddl_Visa_Emp_id.SelectedValue);
            obj.Follow_ID = Inbox_minister_Visa_Follows_DB.Save(obj);

            DataTable dt_Inbox_Visa = General_Helping.GetDataTable("select * from Inbox_Track_Emp where inbox_id =" + hidden_Id.Value);
            foreach (DataRow item in dt_Inbox_Visa.Rows)
            {
                Inbox_Minister_DB.update_inbox_Track_Emp(hidden_Id.Value, item["Emp_ID"].ToString(), 4, 3);
            }
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
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = " update Inbox_Minister_Visa_Follows set File_data =@File_data ,File_name=@File_name,File_ext=@File_ext where Follow_ID =@Follow_ID";
                cmd.Parameters.Add("@File_data", SqlDbType.VarBinary);
                cmd.Parameters.Add("@File_name", SqlDbType.NVarChar);
                cmd.Parameters.Add("@File_ext", SqlDbType.NVarChar);
                cmd.Parameters.Add("@Follow_ID", SqlDbType.BigInt);

                cmd.Parameters["@File_data"].Value = Input;
                cmd.Parameters["@File_name"].Value = DocName;
                cmd.Parameters["@File_ext"].Value = type;
                cmd.Parameters["@Follow_ID"].Value = obj.Follow_ID;

                con.Open();
                cmd.ExecuteScalar();
                con.Close();



            }
            ///////////// change have follow = 1 , All_visa_sent=0 /////////////////////////////////////////////

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            DataTable DT = new DataTable();
            DT = General_Helping.GetDataTable("select * from Inbox_Track_Manager where inbox_id = " + hidden_Id.Value);
            if (DT.Rows.Count > 0)
            {
                conn.Open();
                string sql = "update Inbox_Track_Manager set Have_Follow=1,All_visa_sent=0 where inbox_id =" + hidden_Id.Value;
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();

            }


            Clear_visa_Follow();

            Fil_Grid_Visa_Follow();
        }
        else
        {
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('يجب إدخال بيانات الخطاب أولا')</script>");

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
        string Sql = "SELECT Inbox_Minister_Visa_Follows.Follow_ID,Inbox_Minister_Visa_Follows.time_follow,Inbox_Minister_Visa_Follows.File_name,Inbox_Minister_Visa_Follows.Inbox_ID, Inbox_Minister_Visa_Follows.Descrption, Inbox_Minister_Visa_Follows.Date, Inbox_Minister_Visa_Follows.Visa_Emp_id, EMPLOYEE.pmp_name " +
                    " FROM Inbox_Minister_Visa_Follows INNER JOIN EMPLOYEE ON Inbox_Minister_Visa_Follows.Visa_Emp_id = EMPLOYEE.PMP_ID where Inbox_ID =" + hidden_Id.Value;
        DT = General_Helping.GetDataTable(Sql);

        GridView_Visa_Follow.DataSource = DT;
        GridView_Visa_Follow.DataBind();
    }
    protected void GridView_Visa_Follow_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "EditItem")
        {

            Inbox_minister_Visa_Follows_DT obj = Inbox_minister_Visa_Follows_DB.SelectByID(CDataConverter.ConvertToInt(e.CommandArgument));
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
            Inbox_minister_Visa_Follows_DB.Delete(CDataConverter.ConvertToInt(e.CommandArgument));
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم الحذف بنجاح')</script>");
            Fil_Grid_Visa_Follow();
        }
    }
    private void Fil_Emp_Visa_Follow()
    {
        if (CDataConverter.ConvertToInt(hidden_Id.Value) > 0)
        {
            DataTable DT = new DataTable();

            string sql = "  SELECT distinct EMPLOYEE.PMP_ID, EMPLOYEE.pmp_name,Inbox_Minister_Visa.Inbox_ID FROM Inbox_Minister_Visa_Emp INNER JOIN  EMPLOYEE ON Inbox_Minister_Visa_Emp.Emp_ID = EMPLOYEE.PMP_ID INNER JOIN Inbox_Minister_Visa ON Inbox_Minister_Visa_Emp.Visa_Id = Inbox_Minister_Visa.Visa_Id INNER JOIN Inbox_Minister ON Inbox_Minister_Visa.Inbox_ID = Inbox_Minister.ID" +
                        " where Inbox_ID=" + hidden_Id.Value + " AND EMPLOYEE.PMP_ID = " + CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());

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
        DT = General_Helping.GetDataTable("select * from Inbox_OutBox_Files where Inbox_Or_Outbox = 3 and Inbox_Outbox_ID=" + id);

        GrdView_Documents.DataSource = DT;
        GrdView_Documents.DataBind();
    }





    protected void btn_Visa_Click(object sender, EventArgs e)
    {
        int id = Convert.ToInt16(Request["id"]);
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        DataTable DT = new DataTable();
        DT = General_Helping.GetDataTable("select * from Inbox_Track_Manager where inbox_id = " + id + " AND Type_Track = 3");
        if (DT.Rows.Count > 0)
        {
            conn.Open();
            Inbox_minister_Visa_Follows_DT obj_follow = Inbox_minister_Visa_Follows_DB.SelectByID(CDataConverter.ConvertToInt(hidden_Follow_ID.Value));
            obj_follow.Follow_ID = CDataConverter.ConvertToInt(hidden_Follow_ID.Value);
            obj_follow.Inbox_ID = CDataConverter.ConvertToInt(hidden_Id.Value);
            obj_follow.Descrption = txt_Visa_Desc.Text;
            string date = CDataConverter.ConvertDateTimeToFormatdmy(CDataConverter.ConvertDateTimeNowRtnDt());
            obj_follow.Date = date;
            obj_follow.time_follow = CDataConverter.ConvertDateTimeNowRtnDt().ToLocalTime().ToLongTimeString();
            obj_follow.entery_pmp_id = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
            obj_follow.Visa_Emp_id = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
            obj_follow.Follow_ID = Inbox_minister_Visa_Follows_DB.Save(obj_follow);
            Fil_Grid_Visa_Follow();

            string sql = "update Inbox_Track_Manager set IS_New_Mail=0,IS_Old_Mail=1,Have_Follow=0,Have_visa=1 , ";
            //string sql = "update Inbox_Track_Manager set IS_New_Mail=0,Have_visa=1, ";
            sql += "Visa_Desc = '" + txt_Visa_Desc.Text + "'";
            sql += " where inbox_id =" + id;
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            lnkBtnUnderStudy.Visible = false;
            Save_Visa(id);
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('تم حفظ التاشيرة بنجاح')</script>");
            clear_Visa_cntrl();
            Fil_Grid_Visa();
        }
        else
        {
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لا يوجد بيانات للخطاب')</script>");
        }
    }

    private void clear_Visa_cntrl()
    {
        hidden_Visa_Id.Value = "";

    }

    private void Save_Visa(int id)
    {
        Inbox_Minister_Visa_DT obj = new Inbox_Minister_Visa_DT();
        obj.Visa_Id = CDataConverter.ConvertToInt(hidden_Visa_Id.Value);
        obj.Inbox_ID = id;
        obj.Important_Degree = CDataConverter.ConvertToInt(ddl_Important_Degree.SelectedValue);
        obj.Important_Degree_Txt = txt_Important_Degree_Txt.Text;
        if (string.IsNullOrEmpty(obj.Important_Degree_Txt))
            obj.Important_Degree_Txt = ddl_Important_Degree.SelectedItem.Text;
        DateTime str = CDataConverter.ConvertDateTimeNowRtnDt();
        obj.Visa_date = str.ToString("dd/MM/yyyy");

        obj.Dept_ID = CDataConverter.ConvertToInt(Smart_Search_dept.SelectedValue);
        obj.Visa_Desc = txt_Visa_Desc.Text;
        obj.Dead_Line_DT = txt_Dead_Line_DT.Text;
        obj.Visa_Goal_ID = CDataConverter.ConvertToInt(ddl_Visa_Goal_ID.SelectedValue);

        obj.Visa_Id = Inbox_Minister_Visa_DB.Save(obj);

        Save_inox_Visa(obj);
    }


    private void Save_inox_Visa(Inbox_Minister_Visa_DT obj)
    {

        string Sql_Delete = "delete from Inbox_Minister_Visa_Emp where Visa_Id =" + obj.Visa_Id;
        General_Helping.ExcuteQuery(Sql_Delete);
        foreach (ListItem item in chklst_Visa_Emp.Items)
        {
            if (item.Selected)
            {
                string Sql_insert = "insert into Inbox_Minister_Visa_Emp ( Visa_Id , Emp_ID ) values ( " + obj.Visa_Id + "," + item.Value + ")";
                General_Helping.ExcuteQuery(Sql_insert);
                item.Selected = false;
            }

        }
    }

    protected void lnkBtnUnderStudy_Click(object sender, EventArgs e)
    {
        int id = Convert.ToInt16(Request["id"]);
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        DataTable DT = new DataTable();
        DT = General_Helping.GetDataTable("select * from Inbox_Track_Manager where inbox_id = " + id + " AND Type_Track=3 ");
        if (DT.Rows.Count > 0)
        {
            conn.Open();
            string sql = "update Inbox_Track_Manager set IS_New_Mail=2 where inbox_id =" + id + " AND Type_Track=3 ";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
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
        DT = General_Helping.GetDataTable("SELECT EMPLOYEE.pmp_name FROM Inbox_Minister_Visa_Emp INNER JOIN EMPLOYEE ON Inbox_Minister_Visa_Emp.Emp_ID = EMPLOYEE.PMP_ID WHERE Inbox_Minister_Visa_Emp.Visa_Id  =" + visa_ID);
        foreach (DataRow dr in DT.Rows)
        {
            emp_name += dr["pmp_name"].ToString() + ",";
        }

        return emp_name;

    }

    private void Fil_Grid_Visa()
    {
        DataTable DT = new DataTable();
        DT = General_Helping.GetDataTable("select * from Inbox_Minister_Visa where Inbox_ID=" + Request.QueryString["id"]);

        GridView_Visa.DataSource = DT;
        GridView_Visa.DataBind();

    }

    protected void GridView_Visa_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "EditItem")
        {
            Fil_Visa_Control(CDataConverter.ConvertToInt(e.CommandArgument));
            Fil_Visa_Lst(CDataConverter.ConvertToInt(e.CommandArgument));

        }
        if (e.CommandName == "RemoveItem")
        {
            Inbox_Minister_Visa_DB.Delete(CDataConverter.ConvertToInt(e.CommandArgument));
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم الحذف بنجاح')</script>");
            Fil_Grid_Visa();
            Fil_Emp_Visa_Follow();
        }
        if (e.CommandName == "SendItem")
        {
            ////////////////////////////////////////////////////////////////////////////////////////////
            /////////////////// Sending Mail Code /////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////
            string dept = Session_CS.dept.ToString();
            string name = "";
            string Succ_names = "", Failed_name = "";
            DataTable dt_Inbox_Visa = General_Helping.GetDataTable("select * from Inbox_minister_Visa_Emp where Visa_Id =" + e.CommandArgument.ToString());
            foreach (DataRow item in dt_Inbox_Visa.Rows)
            {
                Inbox_Minister_DB.update_inbox_Track_Emp(hidden_Id.Value, item["Emp_ID"].ToString(), 1, 3);
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
                    _Message.Subject = ("MRIR" + " - " + str_subj + " - " + lblLetterDate.Text).ToString();
                }
                else
                {
                    _Message.Subject = "نظام الادارة الالكترونية - المراسلات";
                }


                //_Message.BodyEncoding = Encoding.Unicode;
                _Message.BodyEncoding = Encoding.UTF8;
                _Message.SubjectEncoding = Encoding.UTF8;



                bool flag = false;
                string file = "";
                byte[] files = new byte[0];
                MemoryStream ms = new MemoryStream();
                DataTable dt = General_Helping.GetDataTable("select * from Inbox_OutBox_Files where Inbox_Outbox_ID =" + hidden_Id.Value + " and Inbox_Or_Outbox =3 ");
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
                _Message.Body += " <h3 > " + " وصلكم وارد من " + dept + " بتاريخ " + txt_Visa_date.Text + " بخصوص  <br/>" + "<h3 style=" + "color:blue >" + txt_subject.Text + "</h3>" + " </h3>";
                _Message.Body += " <h3 > " + "  وتأشيرة  السيد المدير المختص أن :" + "<h3 style=" + "color:blue >" + txt_Visa_Desc.Text + "</h3>" + " </h3>";

                _Message.Body += " <h3 > ورابط الوارد هو  :<br/>";
                _Message.Body += " <h3 >http:" + "/" + "/" + address2 + "/MainForm/ViewProjectInbox.aspx?id=" + Request.QueryString["id"] + "&1=1 </h3>";
                if (flag)
                    _Message.Body += "<h3 >  " + " ومرفق الوثائق الخاصة بهذا الوارد</h3> ";

                ////////http://localhost:4665/Projects_Management/WebForms2/ViewProjectInbox.aspx?id=5458


                _Message.Body += "<h3 > مع تحيات </h3> ";
                _Message.Body += "<h3 >   " + Session_CS.e_signature.ToString() + "  </h3> ";
                _Message.Body += "</body></html>";

                //////


                Inbox_Minister_Visa_DT obj = Inbox_Minister_Visa_DB.SelectByID(CDataConverter.ConvertToInt(e.CommandArgument.ToString()));
                obj.mail_sent = 1;
                Inbox_Minister_Visa_DB.Save(obj);



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
                    SendingMailthread_class.Sendingmail(_Message,_Message.Subject, _Message.Body, mail, ms, file, encrypted_id, "");

                    Succ_names += name + ",";


                }
                catch (Exception ex)
                {
                    Failed_name += name + ",";

                    //Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لم يتم ارسال الايميل بنجاح' )</script>");

                }
            }
            //Show_Alert(Succ_names, Failed_name);
            string message = Show_Alert(Succ_names, Failed_name, e.CommandArgument.ToString());
            Fil_Grid_Visa();

            Inbox_minister_Visa_Follows_DT obj_follow = Inbox_minister_Visa_Follows_DB.SelectByID(CDataConverter.ConvertToInt(hidden_Follow_ID.Value));
            obj_follow.Follow_ID = CDataConverter.ConvertToInt(hidden_Follow_ID.Value);
            obj_follow.Inbox_ID = CDataConverter.ConvertToInt(hidden_Id.Value);

            obj_follow.Descrption = message + "و تم الارسال بواسطة النظام";
            string date = CDataConverter.ConvertDateTimeNowRtrnString();
            obj_follow.Date = date;
            obj_follow.time_follow = CDataConverter.ConvertDateTimeNowRtnDt().ToLocalTime().ToLongTimeString();
            obj_follow.entery_pmp_id = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());

            obj_follow.Visa_Emp_id = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
            obj_follow.Follow_ID = Inbox_minister_Visa_Follows_DB.Save(obj_follow);
            Fil_Grid_Visa_Follow();
            ////////////////////////////////////////////// bring the inbox closed to life again //////////
            ///////////// change In_new_mail = 0 , have_visa = 1  /////////////////////////////////////////////

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


            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('" + message + "')</script>");
            //Page.RegisterStartupScript("Sucess", "<script language=javascript>alert(' لقد تم ارسال الايميل بنجاح إلي " +allnames+"')</script>");
        }

    }
    private void Update_Have_Visa(string Visa_Id)
    {
        string Sql_Visa_Sent = "select Visa_Id from Inbox_Minister_Visa where mail_sent = 1 and Visa_Id !=" + Visa_Id + " and inbox_id = " + hidden_Id.Value;
        int Visa_Sent_Count = General_Helping.GetDataTable(Sql_Visa_Sent).Rows.Count;
        if (Visa_Sent_Count == GridView_Visa.Rows.Count - 1)
        {
            DataTable DT = General_Helping.GetDataTable("select * from Inbox_Track_Manager where inbox_id = " + hidden_Id.Value + " AND Type_Track=3");
            if (DT.Rows.Count > 0)
            {
                string sql = "update Inbox_Track_Manager set Have_visa=0 , All_visa_sent=1 where inbox_id =" + hidden_Id.Value + " AND Type_Track=3";
                General_Helping.ExcuteQuery(sql);
            }
        }

    }
    private void Fil_Visa_Lst(int ID)
    {
        string Sql_Delete = "select * from Inbox_Minister_Visa_Emp where Visa_Id =" + ID;
        DataTable DT = General_Helping.GetDataTable(Sql_Delete);
        foreach (DataRow dr in DT.Rows)
        {
            string Value = dr["Emp_ID"].ToString();
            ListItem item = chklst_Visa_Emp.Items.FindByValue(Value);
            if (item != null)
                item.Selected = true;
        }


    }
    private string Show_Alert(string Succ_names, string Failed_name, string visa_id)
    {
        string message = "";
        bool flag = true;
        if (!string.IsNullOrEmpty(Succ_names))
            message += " لقد تم ارسال الايميل بنجاح إلي " + Succ_names;
        if (!string.IsNullOrEmpty(Failed_name))
        {
            flag = false;
            message += " ولم يتم ارسال الايميل إلي " + Failed_name;
        }

        if (flag)
        {
            Inbox_Minister_Visa_DT obj = Inbox_Minister_Visa_DB.SelectByID(CDataConverter.ConvertToInt(visa_id));
            obj.mail_sent = 1;
            Inbox_Minister_Visa_DB.Save(obj);


        }

        return message;

        Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('" + message + "')</script>");

        //      if (!string.IsNullOrEmpty(Failed_name))
        //        Page.RegisterStartupScript("Sucess", "<script language=javascript>alert(' لم يتم ارسال الايميل إلي " + Failed_name + "')</script>");

    }
    private void Fil_Visa_Control(int ID)
    {
        Inbox_Minister_Visa_DT obj = Inbox_Minister_Visa_DB.SelectByID(ID);
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
            temp_sql = "select mail_sent from Inbox_Minister_Visa where Visa_Id=" + id;
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
}

