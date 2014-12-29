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
using System.IO;
using System.Data.SqlClient;
using System.Text;

public partial class UserControls_Protocol_Main_Control : System.Web.UI.UserControl
{

    General_Helping Obj_General_Helping = new General_Helping();
    private string sql_Connection = Database.ConnectionString;
    Session_CS Session_CS = new Session_CS();

    protected override void OnInit(EventArgs e)
    {
        #region BROWSER FOR departments
        string Query = "SELECT Org_ID, Org_Desc FROM Organization";
        string Value_Field = "Org_ID";
        string Text_Field = "Org_Desc";
        DataTable dt = General_Helping.GetDataTable(Query);
        Smart_Org1.sql_Connection = sql_Connection;
        Smart_Org1.datatble = dt;
        Smart_Org1.Value_Field = Value_Field;
        Smart_Org1.Text_Field = Text_Field;
        Smart_Org1.DataBind();

        Smart_Org2.sql_Connection = sql_Connection;
        Smart_Org2.datatble = dt;
        Smart_Org2.Value_Field = Value_Field;
        Smart_Org2.Text_Field = Text_Field;
        Smart_Org2.DataBind();

        Smart_Org3.sql_Connection = sql_Connection;
        Smart_Org3.datatble = dt;
        Smart_Org3.Value_Field = Value_Field;
        Smart_Org3.Text_Field = Text_Field;
        Smart_Org3.DataBind();


        Smart_PMP_ID.sql_Connection = sql_Connection;
        string Query1 = "select * from EMPLOYEE ";//where rol_rol_id in( 3,4)";
        Smart_PMP_ID.datatble = General_Helping.GetDataTable(Query1);
        Smart_PMP_ID.Value_Field = "PMP_ID";
        Smart_PMP_ID.Text_Field = "pmp_name";
        Smart_PMP_ID.DataBind();

        Smart_all_Project.sql_Connection = sql_Connection;
        string Query2 = "select * from Project ";//where rol_rol_id in( 3,4)";
        Smart_all_Project.datatble = General_Helping.GetDataTable(Query2);
        Smart_all_Project.Value_Field = "Proj_id";
        Smart_all_Project.Text_Field = "Proj_Title";
        Smart_all_Project.DataBind();






        #endregion
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //string ss =Session_CS.Project_id.ToString();
        if (CDataConverter.ConvertToInt(Session_CS.Project_id) > 0)
        {
            btn_New.Enabled = false;
            BtnSave.Enabled = false;
            btn_Org1.Enabled = false;
            btn_Org2.Enabled = false;
            btn_Org3.Enabled = false;
            btn_save_Project.Enabled = false;
            btn_Doc.Enabled = false;
            GridView_Org1.Columns[3].Visible = false;
            GridView_Org1.Columns[4].Visible = false;
            GridView_Org2.Columns[1].Visible = false;
            GridView_Org2.Columns[2].Visible = false;
            GridView_Org3.Columns[1].Visible = false;
            GridView_Org3.Columns[2].Visible = false;
            GridView_Projects.Columns[1].Visible = false;
            GrdView_Documents.Columns[4].Visible = false;
            GrdView_Documents.Columns[5].Visible = false;
            
            
        }

        if (!IsPostBack)
        {
            Fil_Dll();
            if (Request["Id"] != null)
            {
                Fill_Controll(CDataConverter.ConvertToInt(Request["Id"]));
                if (CDataConverter.ConvertToInt( Session_CS.Project_id ) > 0)
                    Change_btn_Status(false);
                else
                    Change_btn_Status(true);
                fil_Grd_Org1();
                fil_Grd_Org2();
                fil_Grd_Org3();
                Fil_Grd_Projects();
                Fil_Grid_Documents();

            }
            if (Request["Related_ID"] != null && CDataConverter.ConvertToInt(Request["Related_ID"].ToString()) > 0)
            {
                hidden_Related_ID.Value = Request["Related_ID"].ToString();
            }
            //else
            //{

            //    Fil_Grid();
            //}


        }
    }

    private void Fill_Controll(int ID)
    {
        Protocol_Main_Def_DT obj = Protocol_Main_Def_DB.SelectByID(ID);
        hidden_Protocol_ID.Value = obj.Protocol_ID.ToString();
        txt_Name.Text = obj.Name;
        ddl_Type.SelectedValue = obj.Type.ToString();
        txt_Signt_DT.Text = obj.Signt_DT;
        txt_Strt_DT.Text = obj.Strt_DT;
        txt_End_DT.Text = obj.End_DT;
        Smart_PMP_ID.SelectedValue = obj.PMP_ID.ToString();
        txt_Total_Balance_LE.Text = obj.Total_Balance_LE.ToString();
        txt_Total_Balance_US.Text = obj.Total_Balance_US.ToString();
        hidden_Status.Value = obj.Status.ToString();
        txt_Period_Day.Text = obj.Period_Day.ToString();
        txt_Period_Month.Text = obj.Period_Month.ToString();
        txt_Period_Year.Text = obj.Period_Year.ToString();
        hidden_Related_ID.Value = obj.Related_ID.ToString();

    }

    protected void btn_New_Click(object sender, EventArgs e)
    {
        Clear_cntrl();
    }

    private void Clear_cntrl()
    {
        hidden_Protocol_ID.Value =
        txt_Name.Text =
        ddl_Type.SelectedValue =
        txt_Signt_DT.Text =
        txt_Strt_DT.Text =
        txt_End_DT.Text =

        txt_Total_Balance_LE.Text =
        txt_Total_Balance_US.Text =
        hidden_Status.Value =
        txt_Period_Day.Text =
        txt_Period_Month.Text =
        txt_Period_Year.Text = "";
        Change_btn_Status(false);
        fil_Grd_Org1();
        fil_Grd_Org2();
        fil_Grd_Org3();
        Fil_Grd_Projects();
        Fil_Grid_Documents();
        Smart_PMP_ID.Clear_Selected();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {



        if (VB_Classes.Dates.Dates_Operation.Date_compare(VB_Classes.Dates.Dates_Operation.date_validate(txt_Strt_DT.Text), VB_Classes.Dates.Dates_Operation.date_validate(txt_End_DT.Text)) != false)
        {
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('تاريخ النهاية يجب ان يكون اكبر من تاريخ البداية')</script>");
            return;
        }
        if (Protocol_Main_Def_DB.SelectBy_Name(txt_Name.Text, CDataConverter.ConvertToInt(hidden_Protocol_ID.Value)))
        {
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم ادخال نفس البروتوكول من قبل')</script>");
            return;
        }
        Protocol_Main_Def_DT obj = new Protocol_Main_Def_DT();
        obj.Protocol_ID = CDataConverter.ConvertToInt(hidden_Protocol_ID.Value);
        obj.Name = txt_Name.Text;
        obj.Type = CDataConverter.ConvertToInt(ddl_Type.SelectedValue);
        obj.Signt_DT = VB_Classes.Dates.Dates_Operation.date_validate(txt_Signt_DT.Text);
        obj.Strt_DT = VB_Classes.Dates.Dates_Operation.date_validate(txt_Strt_DT.Text);
        obj.End_DT = VB_Classes.Dates.Dates_Operation.date_validate(txt_End_DT.Text);
        obj.PMP_ID = CDataConverter.ConvertToInt(Smart_PMP_ID.SelectedValue);

        obj.Total_Balance_LE = CDataConverter.ConvertToInt(txt_Total_Balance_LE.Text);
        obj.Total_Balance_US = CDataConverter.ConvertToInt(txt_Total_Balance_US.Text);
        obj.Status = CDataConverter.ConvertToInt(hidden_Status.Value);
        obj.Period_Day = CDataConverter.ConvertToInt(txt_Period_Day.Text);
        obj.Period_Month = CDataConverter.ConvertToInt(txt_Period_Month.Text);
        obj.Period_Year = CDataConverter.ConvertToInt(txt_Period_Year.Text);
        obj.Related_ID = CDataConverter.ConvertToInt(hidden_Related_ID.Value);
        obj.Protocol_ID = Protocol_Main_Def_DB.Save(obj);
        hidden_Protocol_ID.Value = obj.Protocol_ID.ToString();
        Change_btn_Status(true);
        Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم الحفظ بنجاح')</script>");



    }

    private void Change_btn_Status(bool p)
    {
        btn_Doc.Enabled =
        btn_save_Project.Enabled =
        btn_Org3.Enabled =
        btn_Org2.Enabled =
        btn_Org1.Enabled = p;
    }

    private void Fil_Dll()
    {
        // DataTable DT2 = new DataTable();
        // DT2 = General_Helping.GetDataTable("select * from EMPLOYEE where rol_rol_id in( 3,4) ");
        // Obj_General_Helping.SmartBindDDL(ddl_PMP_ID, DT2, "PMP_ID", "pmp_name", "....اختر المسئول ....");


    }

    protected void btn_Org1_Click(object sender, EventArgs e)
    {



        if (CDataConverter.ConvertToInt(Smart_Org1.SelectedValue) <= 0)
        {
            Page.RegisterStartupScript("error", "<script language=javascript>alert('يجب اختيار الجهة')</script>");
            return;
        }
        Protocol_Main_Org_DT obj = new Protocol_Main_Org_DT();
        obj.Protocol_Org_ID = CDataConverter.ConvertToInt(hidden_Protocol_Org_ID1.Value);
        obj.Protocol_ID = CDataConverter.ConvertToInt(hidden_Protocol_ID.Value);
        obj.Org_Type = 1;
        obj.Org_ID = CDataConverter.ConvertToInt(Smart_Org1.SelectedValue);
        obj.Total_Balance_LE = CDataConverter.ConvertToInt(txtAmountLE.Text);
        obj.Total_Balance_US = CDataConverter.ConvertToInt(txtAmountUS.Text);
        Protocol_Main_Org_DB.Save(obj);

        Protocol_Main_Def_DT obj_Main = Protocol_Main_Def_DB.SelectByID(obj.Protocol_ID);

        obj_Main.Total_Balance_LE += obj.Total_Balance_LE - CDataConverter.ConvertToInt(hidden_LE.Value);
        obj_Main.Total_Balance_US += obj.Total_Balance_US - CDataConverter.ConvertToInt(hidden_US.Value);
        Protocol_Main_Def_DB.Save(obj_Main);
        txt_Total_Balance_LE.Text = obj_Main.Total_Balance_LE.ToString();
        txt_Total_Balance_US.Text = obj_Main.Total_Balance_US.ToString();

        fil_Grd_Org1();
        txtAmountLE.Text =
            txtAmountUS.Text =
            hidden_Protocol_Org_ID1.Value = "";
        Smart_Org1.Clear_Selected();



    }

    protected void btn_Org2_Click(object sender, EventArgs e)
    {



        if (CDataConverter.ConvertToInt(Smart_Org2.SelectedValue) <= 0)
        {
            Page.RegisterStartupScript("error", "<script language=javascript>alert('يجب اختيار الجهة')</script>");
            return;
        }
        Protocol_Main_Org_DT obj = new Protocol_Main_Org_DT();
        obj.Protocol_Org_ID = CDataConverter.ConvertToInt(hidden_Protocol_Org_ID2.Value);
        obj.Protocol_ID = CDataConverter.ConvertToInt(hidden_Protocol_ID.Value);
        obj.Org_Type = 2;
        obj.Org_ID = CDataConverter.ConvertToInt(Smart_Org2.SelectedValue);
        Protocol_Main_Org_DB.Save(obj);


        fil_Grd_Org2();
        hidden_Protocol_Org_ID2.Value = "";
        Smart_Org2.Clear_Selected();



    }

    protected void btn_Org3_Click(object sender, EventArgs e)
    {



        if (CDataConverter.ConvertToInt(Smart_Org3.SelectedValue) <= 0)
        {
            Page.RegisterStartupScript("error", "<script language=javascript>alert('يجب اختيار الجهة')</script>");
            return;
        }
        Protocol_Main_Org_DT obj = new Protocol_Main_Org_DT();
        obj.Protocol_Org_ID = CDataConverter.ConvertToInt(hidden_Protocol_Org_ID3.Value);
        obj.Protocol_ID = CDataConverter.ConvertToInt(hidden_Protocol_ID.Value);
        obj.Org_Type = 3;
        obj.Org_ID = CDataConverter.ConvertToInt(Smart_Org3.SelectedValue);
        Protocol_Main_Org_DB.Save(obj);


        fil_Grd_Org3();
        hidden_Protocol_Org_ID3.Value = "";
        Smart_Org3.Clear_Selected();



    }

    protected void btn_save_Project_Click(object sender, EventArgs e)
    {

        int Project_ID = CDataConverter.ConvertToInt(Smart_all_Project.SelectedValue);
        if (Project_ID > 0)
        {
            string sql = " update Project set Protocol_ID = '" + hidden_Protocol_ID.Value + "' where Proj_id = " + Project_ID;
            General_Helping.ExcuteQuery(sql);

        }
        //else
        //{
        //    string sql = " insert into Project (Proj_Title,Protocol_ID ) VALUES ('" + txt_Project.Text + "'," + hidden_Protocol_ID.Value + " )";
        //    General_Helping.ExcuteQuery(sql);


        //}
        Fil_Grd_Projects();
        //txt_Project.Text =
        // hidden_Proj_id.Value = "";



    }

    private void Fil_Grd_Projects()
    {

        GridView_Projects.DataSource = General_Helping.GetDataTable("Select * from Project where Protocol_ID =" + CDataConverter.ConvertToInt(hidden_Protocol_ID.Value));
        GridView_Projects.DataBind();
    }

    private void fil_Grd_Org3()
    {
        GridView_Org3.DataSource = Protocol_Main_Org_DB.SelectAll_by_protocol_Id(CDataConverter.ConvertToInt(hidden_Protocol_ID.Value), 3);
        GridView_Org3.DataBind();
    }

    private void fil_Grd_Org2()
    {
        GridView_Org2.DataSource = Protocol_Main_Org_DB.SelectAll_by_protocol_Id(CDataConverter.ConvertToInt(hidden_Protocol_ID.Value), 2);
        GridView_Org2.DataBind();
    }

    private void fil_Grd_Org1()
    {
        GridView_Org1.DataSource = Protocol_Main_Org_DB.SelectAll_by_protocol_Id(CDataConverter.ConvertToInt(hidden_Protocol_ID.Value), 1);
        GridView_Org1.DataBind();

    }

    protected void GridView_Org1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditItem")
        {
            Protocol_Main_Org_DT obj = Protocol_Main_Org_DB.SelectByID(CDataConverter.ConvertToInt(e.CommandArgument.ToString()));
            hidden_Protocol_Org_ID1.Value = obj.Protocol_Org_ID.ToString();
            Smart_Org1.SelectedValue = obj.Org_ID.ToString();
            hidden_LE.Value = txtAmountLE.Text = obj.Total_Balance_LE.ToString();
            hidden_US.Value = txtAmountUS.Text = obj.Total_Balance_US.ToString();

        }

        if (e.CommandName == "RemoveItem")
        {
            Protocol_Main_Org_DB.Delete(CDataConverter.ConvertToInt(e.CommandArgument));
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم الحذف بنجاح')</script>");
            fil_Grd_Org1();
        }
    }

    protected void GridView_Org2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditItem")
        {
            Protocol_Main_Org_DT obj = Protocol_Main_Org_DB.SelectByID(CDataConverter.ConvertToInt(e.CommandArgument.ToString()));
            hidden_Protocol_Org_ID2.Value = obj.Protocol_Org_ID.ToString();
            Smart_Org2.SelectedValue = obj.Org_ID.ToString();

        }

        if (e.CommandName == "RemoveItem")
        {
            Protocol_Main_Org_DB.Delete(CDataConverter.ConvertToInt(e.CommandArgument));
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم الحذف بنجاح')</script>");
            fil_Grd_Org2();
        }
    }

    protected void GridView_Org3_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditItem")
        {
            Protocol_Main_Org_DT obj = Protocol_Main_Org_DB.SelectByID(CDataConverter.ConvertToInt(e.CommandArgument.ToString()));
            hidden_Protocol_Org_ID3.Value = obj.Protocol_Org_ID.ToString();
            Smart_Org3.SelectedValue = obj.Org_ID.ToString();

        }

        if (e.CommandName == "RemoveItem")
        {
            Protocol_Main_Org_DB.Delete(CDataConverter.ConvertToInt(e.CommandArgument));
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم الحذف بنجاح')</script>");
            fil_Grd_Org3();
        }
    }

    protected void GridView_Projects_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditItem")
        {
            Smart_all_Project.SelectedValue = e.CommandArgument.ToString();
            //DataTable Dt = General_Helping.GetDataTable("Select * from Project where Proj_id =" + e.CommandArgument.ToString());
            //if (Dt.Rows.Count > 0)
            //{
            //    txt_Project.Text = Dt.Rows[0]["Proj_Title"].ToString();
            //    hidden_Proj_id.Value = Dt.Rows[0]["Proj_id"].ToString();
            //}

        }

        if (e.CommandName == "RemoveItem")
        {
            string sql = " update Project set Protocol_ID = NULL where Proj_id =" + e.CommandArgument.ToString();
            General_Helping.ExcuteQuery(sql);
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم الحذف بنجاح')</script>");
            Fil_Grd_Projects();
        }
    }

    protected void GrdView_Documents_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditItem")
        {
            DataTable DT = new DataTable();
            DT = General_Helping.GetDataTable("select * from Protocol_Main_Documents where id=" + e.CommandArgument.ToString());
            if (DT.Rows.Count > 0)
            {
                DataRow dr = DT.Rows[0];
                hidden_Doc_ID.Value = dr["ID"].ToString();
                txtFileName.Text = dr["File_Name"].ToString();
                ddl_File_Kind.SelectedValue = dr["File_Kind"].ToString();
                txt_File_Date.Text = dr["File_Date"].ToString();
                txt_File_desc.Text = dr["File_desc"].ToString();


            }

        }

        if (e.CommandName == "RemoveItem")
        {
            string sql = "delete from Protocol_Main_Documents where ID = " + e.CommandArgument;
            General_Helping.ExcuteQuery(sql);
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم الحذف بنجاح')</script>");
            Fil_Grid_Documents();
        }
    }

    protected void btn_Doc_Click(object sender, EventArgs e)
    {


        if (CDataConverter.ConvertToInt(hidden_Doc_ID.Value) > 0)
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
                SqlCommand cmd = new SqlCommand();
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = " update Protocol_Main_Documents set File_desc=@File_desc ,File_Date=@File_Date ,File_Kind=@File_Kind,Protocol_ID=@Protocol_ID ,File_Name=@File_Name ,File_Type=@File_Type,File_Source=@File_Source where ID =@ID";


                cmd.Parameters.Add("@File_Source", SqlDbType.VarBinary);
                cmd.Parameters.Add("@Protocol_ID", SqlDbType.Int);
                cmd.Parameters.Add("@ID", SqlDbType.Int);
                cmd.Parameters.Add("@File_Name", SqlDbType.NVarChar);
                cmd.Parameters.Add("@File_Type", SqlDbType.NVarChar);
                cmd.Parameters.Add("@File_desc", SqlDbType.NVarChar);
                cmd.Parameters.Add("@File_Date", SqlDbType.NVarChar);
                cmd.Parameters.Add("@File_Kind", SqlDbType.Int);


                cmd.Parameters["@File_Source"].Value = Input;
                cmd.Parameters["@ID"].Value = CDataConverter.ConvertToInt(hidden_Doc_ID.Value);
                cmd.Parameters["@Protocol_ID"].Value = CDataConverter.ConvertToInt(hidden_Protocol_ID.Value);
                cmd.Parameters["@File_Type"].Value = type;
                cmd.Parameters["@File_Name"].Value = txtFileName.Text;
                cmd.Parameters["@File_desc"].Value = txt_File_desc.Text;
                cmd.Parameters["@File_Date"].Value = VB_Classes.Dates.Dates_Operation.date_validate(txt_File_Date.Text);
                cmd.Parameters["@File_Kind"].Value = CDataConverter.ConvertToInt(ddl_File_Kind.SelectedValue);




                con.Open();
                cmd.ExecuteScalar();
                con.Close();
                txtFileName.Text =
                hidden_Doc_ID.Value = "";
            }
            else
            {
                SqlCommand cmd = new SqlCommand();
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = " update Protocol_Main_Documents set File_desc=@File_desc ,File_Date=@File_Date ,File_Kind=@File_Kind,File_Name=@File_Name where ID =@ID";

                cmd.Parameters.Add("@File_Name", SqlDbType.NVarChar);
                cmd.Parameters.Add("@ID", SqlDbType.Int);
                cmd.Parameters.Add("@File_desc", SqlDbType.NVarChar);
                cmd.Parameters.Add("@File_Date", SqlDbType.NVarChar);
                cmd.Parameters.Add("@File_Kind", SqlDbType.Int);

                cmd.Parameters["@File_Name"].Value = txtFileName.Text;
                cmd.Parameters["@ID"].Value = CDataConverter.ConvertToInt(hidden_Doc_ID.Value);
                cmd.Parameters["@File_desc"].Value = txt_File_desc.Text;
                cmd.Parameters["@File_Date"].Value = VB_Classes.Dates.Dates_Operation.date_validate(txt_File_Date.Text);
                cmd.Parameters["@File_Kind"].Value = CDataConverter.ConvertToInt(ddl_File_Kind.SelectedValue);

                con.Open();
                cmd.ExecuteScalar();
                btn_Doc.Text = "حفظ وثيقة";
                con.Close();
                txtFileName.Text =
                hidden_Doc_ID.Value = "";
            }

        }
        else
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
                SqlCommand cmd = new SqlCommand();
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = " insert into Protocol_Main_Documents (Protocol_ID,File_Name,File_Type,File_Source,File_desc,File_Date,File_Kind) VALUES (@Protocol_ID,@File_Name,@File_Type,@File_Source,@File_desc,@File_Date,@File_Kind)";


                cmd.Parameters.Add("@File_Source", SqlDbType.VarBinary);
                cmd.Parameters.Add("@Protocol_ID", SqlDbType.Int);
                cmd.Parameters.Add("@File_Name", SqlDbType.NVarChar);
                cmd.Parameters.Add("@File_Type", SqlDbType.NVarChar);
                cmd.Parameters.Add("@File_desc", SqlDbType.NVarChar);
                cmd.Parameters.Add("@File_Date", SqlDbType.NVarChar);
                cmd.Parameters.Add("@File_Kind", SqlDbType.Int);

                cmd.Parameters["@File_Source"].Value = Input;
                cmd.Parameters["@Protocol_ID"].Value = CDataConverter.ConvertToInt(hidden_Protocol_ID.Value);
                cmd.Parameters["@File_Type"].Value = type;
                cmd.Parameters["@File_Name"].Value = txtFileName.Text;
                cmd.Parameters["@File_desc"].Value = txt_File_desc.Text;
                cmd.Parameters["@File_Date"].Value = VB_Classes.Dates.Dates_Operation.date_validate(txt_File_Date.Text);
                cmd.Parameters["@File_Kind"].Value = CDataConverter.ConvertToInt(ddl_File_Kind.SelectedValue);



                con.Open();
                cmd.ExecuteScalar();
                con.Close();
                txtFileName.Text =
                hidden_Doc_ID.Value = "";
            }
        }

        Fil_Grid_Documents();


    }

    private void Fil_Grid_Documents()
    {
        DataTable DT = new DataTable();
        DT = General_Helping.GetDataTable("select * from Protocol_Main_Documents where Protocol_ID=" + CDataConverter.ConvertToInt(hidden_Protocol_ID.Value));

        GrdView_Documents.DataSource = DT;
        GrdView_Documents.DataBind();
    }

    public string Get_Type(object obj)
    {
        string str = obj.ToString();
        if (str == "1")
            return "اتفاقية/بروتوكول";
        else if (str == "2")
            return "خطابات";
        else if (str == "3")
            return "مذكرات عرض";
        else if (str == "4")
            return "أخرى";
        else return "";
    }

    protected void btnCalc_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(txt_Period_Month.Text) && !string.IsNullOrEmpty(txt_Period_Year.Text))
        {
            string Strt_date = VB_Classes.Dates.Dates_Operation.date_validate(txt_Strt_DT.Text);
            if (!string.IsNullOrEmpty(Strt_date))
            {
                int Total_Days = CDataConverter.ConvertToInt(txt_Period_Year.Text) * 360 + CDataConverter.ConvertToInt(txt_Period_Month.Text) * 30 + CDataConverter.ConvertToInt(txt_Period_Day.Text);
                txt_End_DT.Text = DateTime.ParseExact(Strt_date, "dd/MM/yyyy", null).AddDays(Total_Days).ToString("dd/MM/yyyy");


            }
        }

    }

    protected void txt_End_DT_TextChanged(object sender, EventArgs e)
    {

        string Strt_date = VB_Classes.Dates.Dates_Operation.date_validate(txt_Strt_DT.Text);
        string End_date = VB_Classes.Dates.Dates_Operation.date_validate(txt_End_DT.Text);
        if (!VB_Classes.Dates.Dates_Operation.Date_compare(Strt_date, End_date))
        {
            if (!string.IsNullOrEmpty(Strt_date) && !string.IsNullOrEmpty(End_date))
            {
                int Total_Days = DateTime.ParseExact(End_date, "dd/MM/yyyy", null).Subtract(DateTime.ParseExact(Strt_date, "dd/MM/yyyy", null)).Days;
                int Year = Total_Days / 360;
                txt_Period_Year.Text = Year.ToString();
                int month = (Total_Days % 360) / 30;
                int days = (Total_Days % 360) % 30;
                if (days > 15)
                {
                    txt_Period_Month.Text = (month + 1).ToString();
                    //txt_Period_Day.Text = (30 - days).ToString();
                }
                else
                {
                    txt_Period_Month.Text = month.ToString();
                    //txt_Period_Day.Text = days.ToString();
                }

            }
            else
            {
                Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('أدخل التاريخ يوم/شهر/سنة ')</script>");

            }
        }
        else
        {
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('تاريخ النهاية يجب ان يكون اكبر من تاريخ البداية')</script>");

        }
    }
}
