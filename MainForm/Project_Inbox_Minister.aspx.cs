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



public partial class WebForms_Project_Inbox_Minister : System.Web.UI.Page
{
    //Session_CS Session_CS = new Session_CS();
    private string sql_Connection = Database.ConnectionString;
    General_Helping Obj_General_Helping = new General_Helping();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            Fil_Dll();
            fil_emp_Visa();
            Fill_main_Category();
            if (Request["id"] != null)
            {
                Fill_Controll(CDataConverter.ConvertToInt(Request["id"]));
                Fil_Grid_Documents();
                Fil_chk_main_category(CDataConverter.ConvertToInt(Request["id"]));
                Fil_Grid_Visa();
                Fil_Grid_Visa_Follow();
                Fil_Emp_Visa_Follow();
                if (CDataConverter.ConvertToInt(Session_CS.group_id.ToString()) == 3)
                {
                    Smart_Search_dept.SelectedValue = "15";
                }

            }
            else
            {
                DateTime str = CDataConverter.ConvertDateTimeNowRtnDt();
                txt_Date.Text = str.ToString("dd/MM/yyyy");

            }

        }
    }
    private void Fill_main_Category()
    {
        DataTable dt_main_cat = General_Helping.GetDataTable(" select * from Inbox_Main_Categories where group_id = " + CDataConverter.ConvertToInt(Session_CS.group_id.ToString()) );
        Chk_main_cat.DataSource = dt_main_cat;
        
        Chk_main_cat.DataBind();

    }
    private void Fil_Emp_Visa_Follow()
    {
        if (CDataConverter.ConvertToInt(hidden_Id.Value) > 0)
        {
            DataTable DT = new DataTable();
            string sql = "  SELECT distinct EMPLOYEE.PMP_ID, EMPLOYEE.pmp_name,Inbox_Minister_Visa.Inbox_ID FROM Inbox_Minister_Visa_Emp INNER JOIN  EMPLOYEE ON Inbox_Minister_Visa_Emp.Emp_ID = EMPLOYEE.PMP_ID INNER JOIN Inbox_Minister_Visa ON Inbox_Minister_Visa_Emp.Visa_Id = Inbox_Minister_Visa.Visa_Id INNER JOIN Inbox_Minister ON Inbox_Minister_Visa.Inbox_ID = Inbox_Minister.ID" +
                         " where Inbox_ID=" + hidden_Id.Value;
            DT = General_Helping.GetDataTable(sql);
            Obj_General_Helping.SmartBindDDL(ddl_Visa_Emp_id, DT, "PMP_ID", "pmp_name", "....اختر اسم الموظف ....");
        }
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        hidden_Id.Value = "";
        txt_Code.Text = "";
        Smart_Org_ID.SelectedValue = "";
        txt_Org_Out_Box_Code.Text = "";
        txt_Org_Out_Box_DT.Text = "";
        txt_Org_Dept_Name.Text = "";
        txt_Org_Out_Box_Person.Text = "";
        txt_Dept_Desc.Text = "";
        txt_Subject.Text = "";
        txt_Paper_No.Text = "";
        txt_Paper_Attached.Text = "";
        txt_Notes.Text = "";
    }
    private void Fill_Controll(int id)
    {
        try
        {
            Inbox_Minister_DT obj = Inbox_Minister_DB.SelectByID(id);
            hidden_Id.Value = obj.ID.ToString();
            hidden_Proj_id.Value = obj.Proj_id.ToString();
            txt_Name.Text = obj.Name;
            txt_Code.Text = obj.Code;
            txt_Date.Text = obj.Date;
            ddl_Type.SelectedValue = obj.Type.ToString();
            Type_Changed();
            if (obj.Dept_ID > 0)
                ddl_Dept_ID.SelectedValue = obj.Dept_ID.ToString();
            fil_emp();
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
            txt_Dept_Desc.Text = obj.Dept_Desc;
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

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if ((CDataConverter.ConvertToInt(ddl_Type.SelectedValue) == 2 && CDataConverter.ConvertToInt(Smart_Org_ID.SelectedValue) > 0) || CDataConverter.ConvertToInt(ddl_Type.SelectedValue) == 1)
        {
            string datenow = "";
            int dept=0;
            int pmp = 0;
            int group = 0;
            Inbox_Minister_DT obj = new Inbox_Minister_DT();
            obj.ID = CDataConverter.ConvertToInt(hidden_Id.Value);

            obj.Proj_id = CDataConverter.ConvertToInt(hidden_Proj_id.Value);
            obj.Name = txt_Name.Text;
            obj.Code = txt_Code.Text;
            obj.Date = txt_Date.Text;
            if (obj.ID == 0)
            {
                datenow = CDataConverter.ConvertDateTimeNowRtrnString();
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
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                con.Open();
                string sql = "select Enter_Date,Dept_Dept_id,Group_id,pmp_pmp_id from Inbox_Minister where ID = " + obj.ID;
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                datenow = ds.Tables[0].Rows[0]["Enter_Date"].ToString();
                dept = int.Parse (ds.Tables[0].Rows[0]["Dept_Dept_id"].ToString());
                group = int.Parse(ds.Tables[0].Rows[0]["Group_id"].ToString());
                pmp = int.Parse(ds.Tables[0].Rows[0]["pmp_pmp_id"].ToString());
                obj.Enter_Date = datenow;
                obj.Dept_Dept_id = dept;
                obj.Group_id = group;
                obj.pmp_pmp_id = pmp;
            }

            obj.Type = CDataConverter.ConvertToInt(ddl_Type.SelectedValue);
            if (CDataConverter.ConvertToInt(ddl_Type.SelectedValue) == 1)
            {
                obj.Dept_ID = CDataConverter.ConvertToInt(ddl_Dept_ID.SelectedValue);
                obj.Org_Id = 0;
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
            obj.Related_Type = CDataConverter.ConvertToInt(ddl_Related_Type.SelectedValue);
            obj.Related_Id = CDataConverter.ConvertToInt(Smart_Related_Id.SelectedValue);
            obj.Notes = txt_Notes.Text;
            obj.Paper_No = txt_Paper_No.Text;
            obj.Paper_Attached = txt_Paper_Attached.Text;
            obj.Follow_Up_Dept_ID = 0;
            obj.Follow_Up_Emp_ID = 0;
            obj.Dept_Desc = txt_Dept_Desc.Text;
            obj.Source_Type = CDataConverter.ConvertToInt(ddl_Source_Type.SelectedValue);
            obj.Status = 0;
            obj.Org_Dept_Name = txt_Org_Dept_Name.Text;
            //obj.sub_Cat_id = CDataConverter.ConvertToInt(ddlSubCat.SelectedValue);
            obj.ID = Inbox_Minister_DB.Save(obj);


            string Sql_Delete = "delete from  Inbox_minister_cat where  inbox_min_id = " + obj.ID;
            General_Helping.ExcuteQuery(Sql_Delete);

            foreach (ListItem item in Chk_main_cat.Items)
            {
                if (item.Selected)
                {
                    string Sql_insert = "insert into Inbox_minister_cat ( inbox_min_id , Cat_id ,Type,inbox_type) values ( " + obj.ID + "," + item.Value + ",1,3 " + ")";
                    General_Helping.ExcuteQuery(Sql_insert);
                }
            }
            foreach (ListItem item in Chk_sub_cat.Items)
            {
                if (item.Selected)
                {
                    string Sql_insert = "insert into Inbox_minister_cat ( inbox_min_id , Cat_id ,Type,inbox_type) values ( " + obj.ID + "," + item.Value + ",2,3 " + ")";
                    General_Helping.ExcuteQuery(Sql_insert);
                }
            }


            hidden_Id.Value = obj.ID.ToString();
            if (obj.ID > 0)
                Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم الحفظ بنجاح')</script>");
            else
                Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لم يتم الحفظ يرجى التأكد من البيانات ')</script>");

        }
        else
        {
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('يجب إختيار جهة الورورد')</script>");

        }
    }
    private void Fil_chk_main_category(int ID)
    {
        string Sql_main_cat = "select * from Inbox_minister_cat where inbox_min_id =" + ID + " and Type =1 and inbox_type =3";
        DataTable DT_main_cat = General_Helping.GetDataTable(Sql_main_cat);
        DataTable dt_sub_cat = General_Helping.GetDataTable("select * from Inbox_minister_cat where inbox_min_id = " + ID + " and Type=2 and inbox_type =3");
        foreach (DataRow dr in DT_main_cat.Rows)
        {
            string Value = dr["Cat_id"].ToString();
            DataTable dt = General_Helping.GetDataTable(" select * from Inbox_sub_categories where main_id = " + Value);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem obj = new ListItem(dt.Rows[i]["name"].ToString(), dt.Rows[i]["id"].ToString());
                Chk_sub_cat.Items.Add(obj);
            }
            ListItem item = Chk_main_cat.Items.FindByValue(Value);
            if (item != null)
                item.Selected = true;


        }
        foreach (DataRow dr in dt_sub_cat.Rows)
        {
            string Value = dr["Cat_id"].ToString();
            ListItem item = Chk_sub_cat.Items.FindByValue(Value);
            if (item != null)
                item.Selected = true;


        }
    }
    private void Fil_Dll()
    {
        DataTable DT = new DataTable();
        DT = General_Helping.GetDataTable("select * from Departments");
        Obj_General_Helping.SmartBindDDL(ddl_Dept_ID, DT, "Dept_ID", "Dept_name", "....اختر اسم الإدارة ....");

        //DataTable DT2 = new DataTable();
        //DT2 = General_Helping.GetDataTable("select * from Inbox_Main_Categories");
        //ddlMainCat.DataSource = DT2;
        //ddlMainCat.DataTextField = "name";
        //ddlMainCat.DataValueField = "id";
        //ddlMainCat.DataBind();

        //DataTable DT3 = new DataTable();
        //DT3 = General_Helping.GetDataTable("select * from Inbox_sub_categories where main_id=" + ddlMainCat.SelectedValue);
        //ddlSubCat.DataSource = DT3;
        //ddlSubCat.DataTextField = "name";
        //ddlSubCat.DataValueField = "id";
        //ddlSubCat.DataBind();
        
    }
    protected override void OnInit(EventArgs e)
    {
        #region BROWSER FOR departments

        Smart_Org_ID.sql_Connection = sql_Connection;
        //Smart_Org_ID.Query = "SELECT Org_ID, Org_Desc FROM Organization";
        string Query = "SELECT Org_ID, Org_Desc FROM Organization";
        Smart_Org_ID.datatble = General_Helping.GetDataTable(Query);
        Smart_Org_ID.Value_Field = "Org_ID";
        Smart_Org_ID.Text_Field = "Org_Desc";
        Smart_Org_ID.DataBind();
        //this.Smrt_Srch_DropDep.Value_Handler += new Smart_Search.Delegate_Selected_Value(MOnMember_Data);
        //Inbox_organization.SelectedValue;
        Smart_Search_dept.sql_Connection = sql_Connection;
       // Smart_Search_dept.Query = "SELECT Dept_id, Dept_name FROM Departments ";
        Query = "SELECT Dept_id, Dept_name FROM Departments ";
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
        //SqlConnection conn = new SqlConnection(sql_Connection);


        fil_emp_Visa();
        TabPanel_All.ActiveTab = TabPanel_Visa;

    }



    protected void ddl_Type_SelectedIndexChanged(object sender, EventArgs e)
    {
        Type_Changed();

    }

    private void Type_Changed()
    {
        if (ddl_Type.SelectedValue == "1")
        {
            tr_Inbox_out.Visible = false;
            tr_Inbox_In.Visible = true;
        }
        else if (ddl_Type.SelectedValue == "2")
        {
            tr_Inbox_In.Visible = false;
            tr_Inbox_out.Visible = true;
        }
        TabPanel_All.ActiveTab = TabPanel_dtl;
    }
    protected void ddl_Dept_ID_SelectedIndexChanged(object sender, EventArgs e)
    {
        fil_emp();
    }

    protected void ddl_Follow_Up_Dept_ID_SelectedIndexChanged(object sender, EventArgs e)
    {
        fil_emp_Folow_Up();
    }


    protected void ddl_Visa_Dept_ID_SelectedIndexChanged(object sender, EventArgs e)
    {
        fil_emp_Visa();
        TabPanel_All.ActiveTab = TabPanel_Visa;
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
        int Dept_ID = CDataConverter.ConvertToInt(ddl_Dept_ID.SelectedValue);
        if (Dept_ID > 0)
        {
            Smart_Emp_ID.sql_Connection = sql_Connection;
           // Smart_Emp_ID.Query = "SELECT PMP_ID, pmp_name FROM EMPLOYEE where Dept_Dept_id = " + Dept_ID;
            string Query = "SELECT PMP_ID, pmp_name FROM EMPLOYEE where Dept_Dept_id = " + Dept_ID;
            Smart_Emp_ID.datatble = General_Helping.GetDataTable(Query);
            Smart_Emp_ID.Value_Field = "PMP_ID";
            Smart_Emp_ID.Text_Field = "pmp_name";
            Smart_Emp_ID.DataBind();
        }
        else
            Smart_Emp_ID.Clear_Controls();
    }
    protected void ddl_Related_Type_SelectedIndexChanged(object sender, EventArgs e)
    {
        Related_type_Changed();

    }

    private void Related_type_Changed()
    {
        if (ddl_Related_Type.SelectedValue == "1")
        {
            trSmart.Visible = false;
        }
        else if (ddl_Related_Type.SelectedValue == "2")
        {

            trSmart.Visible = true;
            lbl_Inbox_type.Text = "رد على الصادر رقم";
            Fil_Smrt_From_OutBox();
        }
        else if (ddl_Related_Type.SelectedValue == "3")
        {

            trSmart.Visible = true;
            lbl_Inbox_type.Text = " استعجال الوارد للصادر رقم";
            Fil_Smrt_From_InBox();
        }
        TabPanel_All.ActiveTab = TabPanel_dtl;
    }

    void Fil_Smrt_From_OutBox()
    {
        Smart_Related_Id.sql_Connection = sql_Connection;
        //Smart_Related_Id.Query = "SELECT id, Code FROM Outbox where group_id = " + int.Parse(Session_CS.group_id.ToString());
        string Query = "SELECT id, Code FROM Outbox where group_id = " + int.Parse(Session_CS.group_id.ToString());
        Smart_Related_Id.datatble = General_Helping.GetDataTable(Query);
        Smart_Related_Id.Value_Field = "id";
        Smart_Related_Id.Text_Field = "Code";
        Smart_Related_Id.DataBind();
    }

    void Fil_Smrt_From_InBox()
    {
        Smart_Related_Id.sql_Connection = sql_Connection;
      //  Smart_Related_Id.Query = "SELECT id, Code FROM Inbox where group_id = " + int.Parse(Session_CS.group_id.ToString());
        string Query = "SELECT id, Code FROM Inbox where group_id = " + int.Parse(Session_CS.group_id.ToString());
        Smart_Related_Id.datatble = General_Helping.GetDataTable(Query);
        Smart_Related_Id.Value_Field = "id";
        Smart_Related_Id.Text_Field = "Code";
        Smart_Related_Id.DataBind();
    }

    protected void btn_Doc_Click(object sender, EventArgs e)
    {
        if (CDataConverter.ConvertToInt(hidden_Id.Value) > 0)
        {
            if (FileUpload1.HasFile)
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

                if (CDataConverter.ConvertToInt(hidden_Inbox_OutBox_File_ID.Value) > 0)
                {
                    SqlCommand cmd = new SqlCommand();
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = " update Inbox_OutBox_Files set Original_Or_Attached=@Original_Or_Attached ,File_data=@File_data ,File_name=@File_name,File_ext=@File_ext where Inbox_OutBox_File_ID =@Inbox_OutBox_File_ID";


                    cmd.Parameters.Add("@File_data", SqlDbType.VarBinary);
                    cmd.Parameters.Add("@Inbox_OutBox_File_ID", SqlDbType.Int);
                    cmd.Parameters.Add("@Original_Or_Attached", SqlDbType.Int);
                    cmd.Parameters.Add("@File_name", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@File_ext", SqlDbType.NVarChar);

                    cmd.Parameters["@File_data"].Value = Input;
                    cmd.Parameters["@Inbox_OutBox_File_ID"].Value = CDataConverter.ConvertToInt(hidden_Inbox_OutBox_File_ID.Value);
                    cmd.Parameters["@Original_Or_Attached"].Value = CDataConverter.ConvertToInt(ddl_Original_Or_Attached.SelectedValue);
                    cmd.Parameters["@File_ext"].Value = type;
                    cmd.Parameters["@File_name"].Value = txtFileName.Text;

                    con.Open();
                    cmd.ExecuteScalar();

                    con.Close();
                    txtFileName.Text =
                    hidden_Inbox_OutBox_File_ID.Value = "";
                }
                else
                {
                    SqlCommand cmd = new SqlCommand();
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = " insert into Inbox_OutBox_Files ( Inbox_Outbox_ID, Inbox_Or_Outbox, Original_Or_Attached, File_data, File_name, File_ext) VALUES ( @Inbox_Outbox_ID, @Inbox_Or_Outbox, @Original_Or_Attached, @File_data, @File_name, @File_ext)";


                    cmd.Parameters.Add("@File_data", SqlDbType.VarBinary);
                    cmd.Parameters.Add("@Original_Or_Attached", SqlDbType.Int);
                    cmd.Parameters.Add("@Inbox_Outbox_ID", SqlDbType.Int);
                    cmd.Parameters.Add("@Inbox_Or_Outbox", SqlDbType.Int);
                    cmd.Parameters.Add("@File_name", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@File_ext", SqlDbType.NVarChar);

                    cmd.Parameters["@File_data"].Value = Input;
                    cmd.Parameters["@Original_Or_Attached"].Value = CDataConverter.ConvertToInt(ddl_Original_Or_Attached.SelectedValue);
                    cmd.Parameters["@Inbox_Outbox_ID"].Value = CDataConverter.ConvertToInt(hidden_Id.Value);
                    cmd.Parameters["@Inbox_Or_Outbox"].Value = 3;
                    cmd.Parameters["@File_ext"].Value = type;
                    cmd.Parameters["@File_name"].Value = txtFileName.Text;

                    con.Open();
                    cmd.ExecuteScalar();

                    con.Close();
                    txtFileName.Text =
                    hidden_Inbox_OutBox_File_ID.Value = "";

                }



            }





            // Clear_Cntrl();
            Fil_Grid_Documents();
        }
        else
        {
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('يجب إدخال بيانات الخطاب أولا')</script>");

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
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم الحذف بنجاح')</script>");
            Fil_Grid_Documents();
        }
    }

    private void Fil_Grid_Documents()
    {
        DataTable DT = new DataTable();
        DT = General_Helping.GetDataTable("select * from Inbox_OutBox_Files where Inbox_Or_Outbox = 3 and Inbox_Outbox_ID=" + hidden_Id.Value);

        GrdView_Documents.DataSource = DT;
        GrdView_Documents.DataBind();
    }

    protected void btn_Visa_Click(object sender, EventArgs e)
    {
        if (CDataConverter.ConvertToInt(hidden_Id.Value) > 0)
        {

            Inbox_Minister_Visa_DT obj = new Inbox_Minister_Visa_DT();
            obj.Visa_Id = CDataConverter.ConvertToInt(hidden_Visa_Id.Value);
            obj.Inbox_ID = CDataConverter.ConvertToInt(hidden_Id.Value);
            obj.Visa_date = txt_Visa_date.Text;
            obj.Important_Degree = CDataConverter.ConvertToInt(ddl_Important_Degree.SelectedValue);
            obj.Important_Degree_Txt = txt_Important_Degree_Txt.Text;
            if (string.IsNullOrEmpty(obj.Important_Degree_Txt))
                obj.Important_Degree_Txt = ddl_Important_Degree.SelectedItem.Text;

            obj.Dept_ID = CDataConverter.ConvertToInt(Smart_Search_dept.SelectedValue);
            obj.Dept_ID_Txt = txt_Dept_ID_Txt.Text;
            if (string.IsNullOrEmpty(obj.Dept_ID_Txt))
                obj.Dept_ID_Txt = Smart_Search_dept.SelectedText;

            obj.Emp_ID = 0;
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

            obj.Visa_Id = Inbox_Minister_Visa_DB.Save(obj);

            Save_inox_Visa(obj);
            Clear_Visa_Cntrl();
            Fil_Grid_Visa();
            fil_emp_Folow_Up();
            Fil_Emp_Visa_Follow();
            ///////////////////////// update have visa = 0/////////////////////////////////////////////
            //SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            //DataTable DT = new DataTable();
            //DT = General_Helping.GetDataTable("select * from Inbox_Track_Manager where inbox_id = " + hidden_Id.Value);
            //if (DT.Rows.Count > 0)
            //{
            //    conn.Open();
            //    string sql = "update Inbox_Track_Manager set Have_visa=0 where inbox_id =" + hidden_Id.Value;
            //    SqlCommand cmd = new SqlCommand(sql, conn);
            //    cmd.ExecuteNonQuery();
            //    conn.Close();

            //}
        }
        else
        {
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('يجب إدخال بيانات الخطاب أولا')</script>");

        }

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
            obj.time_follow = DateTime.UtcNow.ToLocalTime().ToLongTimeString();
            obj.entery_pmp_id = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
            obj.Visa_Emp_id = CDataConverter.ConvertToInt(ddl_Visa_Emp_id.SelectedValue);
            obj.Type_Follow = 3;
            obj.Follow_ID = Inbox_minister_Visa_Follows_DB.Save(obj);

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
            ///////////// change have follow = 1/////////////////////////////////////////////

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            DataTable DT = new DataTable();
            DT = General_Helping.GetDataTable("select * from Inbox_Track_Manager where inbox_id = " + hidden_Id.Value + " And Type_Track = 3");
            if (DT.Rows.Count > 0)
            {
                conn.Open();
                string sql = "update Inbox_Track_Manager set Have_Follow=1 where inbox_id =" + hidden_Id.Value + " And Type_Track = 3";
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
    private void Fil_Grid_Visa_Follow()
    {
        DataTable DT = new DataTable();
        string Sql = "SELECT Inbox_Minister_Visa_Follows.Follow_ID,Inbox_Minister_Visa_Follows.time_follow,Inbox_Minister_Visa_Follows.File_name,Inbox_Minister_Visa_Follows.Inbox_ID, Inbox_Minister_Visa_Follows.Descrption, Inbox_Minister_Visa_Follows.Date, Inbox_Minister_Visa_Follows.Visa_Emp_id, EMPLOYEE.pmp_name " +
                     " FROM Inbox_Minister_Visa_Follows INNER JOIN EMPLOYEE ON Inbox_Minister_Visa_Follows.Visa_Emp_id = EMPLOYEE.PMP_ID where Inbox_ID =" + hidden_Id.Value;
        DT = General_Helping.GetDataTable(Sql);

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

    private void Clear_Visa_Cntrl()
    {
        hidden_Visa_Id.Value = "";


        //  Smart_Visa_Emp.Clear_Controls();
    }
    protected void GridView_Visa_Follow_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string sqlformail = "SELECT parent_pmp_id from parent_employee where pmp_id =  " + int.Parse(Session_CS.pmp_id.ToString());
        DataTable ds = General_Helping.GetDataTable(sqlformail);
        int parent_pmp = int.Parse(ds.Rows[0]["parent_pmp_id"].ToString());
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

        if (e.CommandName == "SendItem")
        {
            ////////////////////////////////////////////////////////////////////////////////////////////
            /////////////////// Sending Mail Code /////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////

            DataTable dt_getmail = General_Helping.GetDataTable("select mail,pmp_name from employee where pmp_id = " + parent_pmp);
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

            //_Message.To.Add(new MailAddress(mail));



            _Message.IsBodyHtml = true;
            _Message.Body = "<html><body dir='rtl'><h3 >";

            _Message.Body += " السيد  -   ";
            _Message.Body += parent_name;
            _Message.Body += " </h3>";

            //_Message.Body += " <h1 style=text-align:right>    وصلكم وارد من نظام إدارة مشروعات قطاع البنية المعلوماتية  </h1> ";
            _Message.Body += " <h3 > إيماءً إلى الوارد من  " + Smart_Org_ID.SelectedText + " بتاريخ " + txt_Date.Text + " بخصوص " + txt_Subject.Text + " </h3>";

            bool flag = false;

            string Sql = "SELECT     Inbox_Visa_Follows.Follow_ID, Inbox_Visa_Follows.File_data,Inbox_Visa_Follows.File_name,Inbox_Visa_Follows.File_ext,Inbox_Visa_Follows.Inbox_ID, Inbox_Visa_Follows.Descrption, Inbox_Visa_Follows.Date, Inbox_Visa_Follows.Visa_Emp_id, EMPLOYEE.pmp_name " +
                         " FROM         Inbox_Visa_Follows INNER JOIN EMPLOYEE ON Inbox_Visa_Follows.Visa_Emp_id = EMPLOYEE.PMP_ID where Inbox_ID =" + hidden_Id.Value;

            DataTable dt = General_Helping.GetDataTable(Sql);
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
                //Client.Send(_Message);
                SendingMailthread_class.Sendingmail(_Message,_Message.Subject, _Message.Body,mail, ms, file, encrypted_id, "");
            }
            catch (Exception ex)
            {
                //Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لم يتم ارسال الايميل للسيد المدير المختص بنجاح')</script>");

            }
            //Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم ارسال الايميل للسيد المدير المختص بنجاح')</script>");
        }


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
            string name="";
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

                 name= ds.Rows[0]["pmp_name"].ToString();


                MailMessage _Message = new MailMessage();
                string str_subj = "";
                if (txt_Subject.Text.Length > 160)
                {
                    str_subj = txt_Subject.Text.Substring(0, 160);

                }
                else
                {
                    str_subj = txt_Subject.Text;
                }


                string str_witoutn = str_subj.Replace("\n", "");
                str_subj = str_witoutn.Replace("\r", "");
                if (int.Parse(Session_CS.group_id.ToString()) == 3)
                {

                    _Message.Subject = ("MRIR" + " - " + str_subj + " - " + txt_Date.Text).ToString(); 
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
                String encrypted_id = "";

                //else
                //{
                //    _Message.Body = " السيد " + name + " \n\n";
                //    _Message.Body += " وصلكم صادر من " + dept + " " + " بتاريخ " + txt_Visa_date.Text;
                //}
                _Message.IsBodyHtml = true;
                _Message.Body = "<html><body dir='rtl'><h3 > السيد - " + name + " </h3>";
                _Message.Body += " <h3 > " + " وصلكم وارد من " + dept +  " بتاريخ " + txt_Visa_date.Text + " بخصوص  <br/>" + "<h3 style=" + "color:blue >" + txt_Subject.Text + "</h3>" + " </h3>";
                _Message.Body += " <h3 > " + "  وتأشيرة  السيد المدير المختص أن :" + "<h3 style=" + "color:blue >" + txt_dr_hesham_visa.Text + "</h3>" + " </h3>";
               
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
                Fil_Grid_Visa();

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
                    Succ_names += name  + ",";

                    
                }
                catch (Exception ex)
                {
                    Failed_name += name + ",";

                    //Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لم يتم ارسال الايميل بنجاح' )</script>");

                }
            }
            //Show_Alert(Succ_names, Failed_name);
            string message = Show_Alert(Succ_names, Failed_name, e.CommandArgument.ToString());
            if (!string.IsNullOrEmpty(message))
            {
                Fil_Grid_Visa();
                ///////////////  to store that mohammed eid send visa to employee
                Inbox_minister_Visa_Follows_DT obj_follow = Inbox_minister_Visa_Follows_DB.SelectByID(CDataConverter.ConvertToInt(hidden_Follow_ID.Value));
                obj_follow.Follow_ID = CDataConverter.ConvertToInt(hidden_Follow_ID.Value);
                obj_follow.Inbox_ID = CDataConverter.ConvertToInt(hidden_Id.Value);

                obj_follow.Descrption = message + " بواسطة النظام -- ";
                string date = CDataConverter.ConvertDateTimeToFormatdmy (CDataConverter.ConvertDateTimeNowRtnDt());
                obj_follow.Date = date;
                obj_follow.time_follow = DateTime.UtcNow.ToLocalTime().ToLongTimeString();
                obj_follow.entery_pmp_id = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());

                obj_follow.Visa_Emp_id = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
                obj_follow.Follow_ID = Inbox_minister_Visa_Follows_DB.Save(obj_follow);
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
                Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('" + message + "')</script>");
            }
            //Page.RegisterStartupScript("Sucess", "<script language=javascript>alert(' لقد تم ارسال الايميل بنجاح إلي " +allnames+"')</script>");
        }
        
    }
    protected void btnSend_Click(object sender, EventArgs e)
    {
        if (CDataConverter.ConvertToInt(hidden_Id.Value) > 0)
        {
            ////// get Parent 
            string sqlformail = "SELECT parent_pmp_id from parent_employee where pmp_id =  " + int.Parse(Session_CS.pmp_id.ToString());
            DataTable ds = General_Helping.GetDataTable(sqlformail);
            int parent_pmp = int.Parse(ds.Rows[0]["parent_pmp_id"].ToString());
            ///////////// change  is_new_mail=1 /////////////////////////////////////////////



            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            DataTable DT = new DataTable();
            DT = General_Helping.GetDataTable("select * from Inbox_Track_Manager where inbox_id = " + hidden_Id.Value + " AND Type_Track=3");
            if (DT.Rows.Count > 0)
            {
                conn.Open();
                string sql = "update Inbox_Track_Manager set IS_New_Mail=1 , All_visa_sent=0 where inbox_id =" + hidden_Id.Value + " AND Type_Track=3";
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
                obj.IS_Old_Mail = 0;
                obj.Visa_Desc = "";
                obj.Type_Track = 3;
                obj.pmp_id = int.Parse(Session_CS.pmp_id.ToString());
                obj.parent_pmp_id = parent_pmp;
                obj.All_visa_sent = 0;
                obj.inbox_id = Inbox_track_manager_DB.Save(obj);
                if (obj.inbox_id > 0)
                    Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم الحفظ بنجاح')</script>");
            }


            ////////////////////////////////////////////////////////////////////////////////////////////
            /////////////////// Sending Mail Code /////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////



            DataTable dt_getmail = General_Helping.GetDataTable("select mail,pmp_name from employee where pmp_id = " + parent_pmp);
            string mail = dt_getmail.Rows[0]["mail"].ToString();
            string parent_name = dt_getmail.Rows[0]["pmp_name"].ToString();

            MailMessage _Message = new MailMessage();
            
            string str_subj = "";
            if (txt_Subject.Text.Length > 160)
            {
                str_subj = txt_Subject.Text.Substring(0, 160);
              
            }
            else
            {
                str_subj = txt_Subject.Text;
            }
            

            string str_witoutn= str_subj.Replace("\n", "");
             str_subj = str_witoutn.Replace("\r", "");
            if (int.Parse(Session_CS.group_id.ToString()) == 3)
            {
                string str = "MRIR" + " - " + str_subj.ToString() + " - " + txt_Date.Text;
                _Message.Subject = str;
            }
            else
            {
                _Message.Subject = "نظام الادارة الالكترونية - المراسلات";
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
            DataTable dt = General_Helping.GetDataTable("select * from Inbox_OutBox_Files where Inbox_Outbox_ID =" + hidden_Id.Value + " and Inbox_Or_Outbox =3 ");
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
                        Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('حجم الملفات التابعة لهذا البريد أكبر من المسموح')</script>");
                        return;
                    }
                    flag = true;

                }
            }
            _Message.Body += " <h3 > ورابط الوارد هو  :<br/>";
            string address2 = System.Web.HttpContext.Current.Request.Url.Authority.ToString();
            String encrypted_id = Encryption.Encrypt(hidden_Id.Value);
            _Message.Body += " <h3 >http:" + "/" + "/" + address2 + "/MainForm/ViewProjectInbox.aspx?id=" + Request.QueryString["id"] + "&1=1</h3>";

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

            try
            {
                //_Message.To.Add(new MailAddress(mail));
                SendingMailthread_class.Sendingmail(_Message,_Message.Subject, _Message.Body, mail, ms, file, encrypted_id, "");
                //Client.Send(_Message);

            }
            catch (Exception ex)
            {

               // Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لم يتم ارسال الايميل بنجاح')</script>");

            }
           // Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم ارسال الايميل بنجاح')</script>");

            Inbox_minister_Visa_Follows_DT obj_follow = Inbox_minister_Visa_Follows_DB.SelectByID(CDataConverter.ConvertToInt(hidden_Follow_ID.Value));
            obj_follow.Follow_ID = CDataConverter.ConvertToInt(hidden_Follow_ID.Value);
            obj_follow.Inbox_ID = CDataConverter.ConvertToInt(hidden_Id.Value);
            obj_follow.Descrption = "تم الارسال الي المدير المختص";
            string date = CDataConverter.ConvertDateTimeToFormatdmy(CDataConverter.ConvertDateTimeNowRtnDt());
            obj_follow.Date = date;
            obj_follow.time_follow = DateTime.UtcNow.ToLocalTime().ToLongTimeString();
            obj_follow.entery_pmp_id = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
            obj_follow.Visa_Emp_id = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
            obj_follow.Follow_ID = Inbox_minister_Visa_Follows_DB.Save(obj_follow);
            Fil_Grid_Visa_Follow();
        }
        else
        {
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('يجب إدخال بيانات الخطاب أولا')</script>");

        }

    }
    private void Update_Have_Visa(string Visa_Id)
    {
        string Sql_Visa_Sent = "select Visa_Id from Inbox_Minister_Visa where mail_sent = 1 and Visa_Id !=" + Visa_Id + " and inbox_id = " + hidden_Id.Value;
        int Visa_Sent_Count = General_Helping.GetDataTable(Sql_Visa_Sent).Rows.Count;
        if (Visa_Sent_Count == GridView_Visa.Rows.Count - 1)
        {
            DataTable DT = General_Helping.GetDataTable("select * from Inbox_Track_Manager where inbox_id = " + hidden_Id.Value+ " AND Type_Track=3");
            if (DT.Rows.Count > 0)
            {
                string sql = "update Inbox_Track_Manager set Have_visa=0 , All_visa_sent=1 where inbox_id =" + hidden_Id.Value + " AND Type_Track=3";
                General_Helping.ExcuteQuery(sql);
            }
        }

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
            Inbox_Minister_Visa_DT obj = Inbox_Minister_Visa_DB.SelectByID(CDataConverter.ConvertToInt(visa_id));
            obj.mail_sent = 1;
            Inbox_Minister_Visa_DB.Save(obj);


        }

        return message;


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
                txt_Visa_date.Text = obj.Visa_date;
                if (obj.Important_Degree > 0)
                    ddl_Important_Degree.SelectedValue = obj.Important_Degree.ToString();
                else
                    txt_Important_Degree_Txt.Text = obj.Important_Degree_Txt;
                if (obj.Dept_ID > 0)
                    //ddl_Visa_Dept_ID.SelectedValue = obj.Dept_ID.ToString();
                    Smart_Search_dept.SelectedValue = obj.Dept_ID.ToString();
                else
                    txt_Dept_ID_Txt.Text = obj.Dept_ID_Txt;
                fil_emp_Visa();
                if (obj.Emp_ID > 0)
                {
                    ListItem item = chklst_Visa_Emp.Items.FindByValue(obj.Emp_ID.ToString());
                    if (item != null)
                        item.Selected = true;

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
        DT = General_Helping.GetDataTable("select * from Inbox_Minister_Visa where Inbox_ID=" + hidden_Id.Value);

        GridView_Visa.DataSource = DT;
        GridView_Visa.DataBind();

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

    protected void ddlMainCat_SelectedIndexChanged(object sender, EventArgs e)
    {

        //DataTable DT3 = new DataTable();
        //DT3 = General_Helping.GetDataTable("select * from Inbox_sub_categories where main_id=" + ddlMainCat.SelectedValue);
        //ddlSubCat.DataSource = DT3;
        //ddlSubCat.DataTextField = "name";
        //ddlSubCat.DataValueField = "id";
        //ddlSubCat.DataBind();

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
                dt = General_Helping.GetDataTable("select * from Inbox_sub_categories where main_id = " + item.Value);

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
                dt = General_Helping.GetDataTable(" select * from Inbox_sub_categories where main_id = " + item.Value);

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
}