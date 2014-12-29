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
using VB_Classes;
using VB_Classes.Dates;
using System.IO;
using System.Text;
using System.Data.SqlClient;
public partial class UserControls_Fin_Work_Order : System.Web.UI.UserControl
{
    General_Helping Obj_General_Helping = new General_Helping();
    private string sql_Connection = Database.ConnectionString;
    Session_CS Session_CS = new Session_CS();

    protected override void OnInit(EventArgs e)
    {
        #region BROWSER FOR departments

        Smart_Project_ID.sql_Connection = sql_Connection;
       // Smart_Project_ID.Query = "SELECT Proj_id, Proj_Title FROM Project";
        string Query = "SELECT Proj_id, Proj_Title FROM Project";
        Smart_Project_ID.datatble = General_Helping.GetDataTable(Query);
        Smart_Project_ID.Value_Field = "Proj_id";
        Smart_Project_ID.Text_Field = "Proj_Title";
        Smart_Project_ID.DataBind();
        this.Smart_Project_ID.Value_Handler += new Smart_Search.Delegate_Selected_Value(MOnMember_Data);
        //Inbox_organization.SelectedValue;


        #endregion
        base.OnInit(e);
    }

    private void MOnMember_Data(string Value)
    {
        if (Value != "")
        {
            Clear_Cntrl();
            DataTable DT = new DataTable();
            DT = General_Helping.GetDataTable("SELECT    * FROM         Project_Activities WHERE     (PActv_Parent = 0) and proj_proj_id =" + Value);
            grdView_Main.DataSource = DT;
            grdView_Main.DataBind();
            Fil_Grid();
            Fil_Grid_Documents();
            Fil_Grd_Needs();
            Fil_Grd_Letter();
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fill_ddlyear();
            if (Session_CS.Project_id != null && CDataConverter.ConvertToInt(Session_CS.Project_id.ToString()) > 0)
            {
                tr_Smart_Project.Visible = false;
                Smart_Project_ID.SelectedValue = Session_CS.Project_id.ToString();
                MOnMember_Data(Session_CS.Project_id.ToString());
            }
            //DateTime str = System.DateTime.Now;

            DateTime str = CDataConverter.ConvertDateTimeNowRtnDt();
            txt_Date.Text = CDataConverter.ConvertDateTimeToFormatdmy(str);
            Fil_Dll();


        }


    }

    protected void fill_ddlyear()
    {
        int year = CDataConverter.ConvertDateTimeNowRtnDt().Year + 10;
        for (int i = 2000; i <= year ;i++ )
        {
            ddl_Tender_Year.Items.Add(i.ToString());
           

        }
     
  
    }

    private void Fil_Dll()
    {
        DataTable DT3 = new DataTable();
        DT3 = General_Helping.GetDataTable("select * from Needs_Main_Type ");
        Obj_General_Helping.SmartBindDDL(ddl_NMT_ID, DT3, "NMT_ID", "NMT_Desc", "....اختر البند الرئيسى ....");


        DataTable DT = new DataTable();
        DT = General_Helping.GetDataTable("select * from Fin_Company");

        Obj_General_Helping.SmartBindDDL(ddl_Company_ID, DT, "Company_ID", "Company_Name", "....اختر اسم الشركة ....");
        DataTable DT2 = new DataTable();
        DT2 = General_Helping.GetDataTable("select * from Fin_Tender");
        Obj_General_Helping.SmartBindDDL(DDl_Tender_Type_ID, DT2, "ID", "Name", "....اختر نوع المناقصة ....");
    }

    protected void btn_New_Click(object sender, EventArgs e)
    {
        Clear_Cntrl();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        int operation ;
        if(CDataConverter.ConvertToInt(hidden_Work_Order_ID.Value)==0)
            operation = (int)Project_Log_DB.Action.add;
        else
            operation = (int)Project_Log_DB.Action.edit;

        if (CDataConverter.ConvertToInt(Smart_Project_ID.SelectedValue) > 0)
        {
            Fin_Work_Order_DT obj = Fin_Work_Order_DB.SelectByID(CDataConverter.ConvertToInt(hidden_Work_Order_ID.Value));
            obj.Work_Order_ID = CDataConverter.ConvertToInt(hidden_Work_Order_ID.Value);
            obj.Code = txt_Code.Text;
            obj.Date = VB_Classes.Dates.Dates_Operation.date_validate(txt_Date.Text);
            obj.Company_ID = CDataConverter.ConvertToInt(ddl_Company_ID.SelectedValue);
            obj.Comapny_Period = txt_Comapny_Period.Text;
            obj.Contract_File_Type = obj.Contract_Image_Type = obj.Work_File_Type = obj.Work_Image_Type = "";


            obj.Tender_Type_ID = CDataConverter.ConvertToInt(DDl_Tender_Type_ID.SelectedValue);
            obj.Tender_NO = CDataConverter.ConvertToInt(txt_Tender_NO.Text);
            obj.Tender_Year = CDataConverter.ConvertToInt(ddl_Tender_Year.SelectedItem.Text);
            obj.Project_ID = CDataConverter.ConvertToInt(Smart_Project_ID.SelectedValue);
            obj.Work_Total_Value = CDataConverter.ConvertToDecimal(txt_Work_Total_Value.Text);


            obj.Work_Order_ID = Fin_Work_Order_DB.Save(obj);
            hidden_Work_Order_ID.Value = obj.Work_Order_ID.ToString();
            Save_Activites(obj.Work_Order_ID);
            Fil_Object_File(obj);
            Project_Log_DB.FillLog(CDataConverter.ConvertToInt(hidden_Work_Order_ID.Value), operation, Project_Log_DB.operation.Fin_Work_Order);
            //FillLog(CDataConverter.ConvertToInt(hidden_Work_Order_ID.Value), operation);

            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم الحفظ بنجاح')</script>");

            // Clear_Cntrl();
            Fil_Grid();
        }
        else
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('يجب إختيار المشروع أولا')</script>");
    }
    
    private void Save_Activites(int Work_Order_ID)
    {
        Fin_Work_Activites_DB.Delete_by_Work_Order_ID(CDataConverter.ConvertToInt(hidden_Work_Order_ID.Value));
        foreach (GridViewRow grdrow in grdView_Main.Rows)
        {
            Label lbl_Parent_ID4 = (Label)grdrow.FindControl("lbl_Parent_ID");

            HtmlInputCheckBox Chk_Parent = (HtmlInputCheckBox)grdrow.FindControl("Chk_Parent");
            GridView grdView_Sub = (GridView)grdrow.FindControl("grdView_Sub");
            bool All_Check = true;
            foreach (GridViewRow grdrow_Sub in grdView_Sub.Rows)
            {
                HtmlInputCheckBox Chk_Child = (HtmlInputCheckBox)grdrow_Sub.FindControl("Chk_Child");
                if (!Chk_Child.Checked)
                    All_Check = false;
            }

            if (All_Check)
            {
                Label lbl_Parent_ID = (Label)grdrow.FindControl("lbl_Parent_ID");
                Fin_Work_Activites_DT obj = new Fin_Work_Activites_DT();
                obj.Work_Act_ID = 0;
                obj.PActv_ID = CDataConverter.ConvertToInt(lbl_Parent_ID.Text);
                obj.Work_Order_ID = Work_Order_ID;
                Fin_Work_Activites_DB.Save(obj);

            }
            else
            {
                //GridView grdView_Sub = (GridView)grdrow.FindControl("grdView_Sub");
                foreach (GridViewRow grdrow_Sub in grdView_Sub.Rows)
                {
                    HtmlInputCheckBox Chk_Child = (HtmlInputCheckBox)grdrow_Sub.FindControl("Chk_Child");

                    //            lbl_Child_ID
                    if (Chk_Child != null && Chk_Child.Checked)
                    {
                        Label lbl_Child_ID = (Label)grdrow_Sub.FindControl("lbl_Child_ID");
                        Fin_Work_Activites_DT obj = new Fin_Work_Activites_DT();
                        obj.Work_Act_ID = 0;
                        obj.PActv_ID = CDataConverter.ConvertToInt(lbl_Child_ID.Text);
                        obj.Work_Order_ID = Work_Order_ID;
                        Fin_Work_Activites_DB.Save(obj);

                    }
                }

            }




        }
    }

    protected void GrdView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditItem")
        {
            Fill_Controll(CDataConverter.ConvertToInt(e.CommandArgument));
            Fil_Grid_Documents();
            Fil_Grd_Needs();
            Fil_Grd_Letter();
        }

        if (e.CommandName == "RemoveItem")
        {
            Fin_Work_Order_DB.Delete(CDataConverter.ConvertToInt(e.CommandArgument));
            Fin_Work_Activites_DB.Delete_by_Work_Order_ID(CDataConverter.ConvertToInt(e.CommandArgument));
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم الحذف بنجاح')</script>");
            Fil_Grid();
        }
    }

    private void Fil_Object_File(Fin_Work_Order_DT obj)
    {
        if (FileUpload_Work_Image.HasFile)
        {
            string DocName = FileUpload_Work_Image.FileName;
            int dotindex = DocName.LastIndexOf(".");
            string type = DocName.Substring(dotindex, DocName.Length - dotindex);

            Stream myStream;
            int fileLen;
            StringBuilder displayString = new StringBuilder();
            fileLen = FileUpload_Work_Image.PostedFile.ContentLength;
            Byte[] Input = new Byte[fileLen];
            myStream = FileUpload_Work_Image.FileContent;
            myStream.Read(Input, 0, fileLen);

            obj.Work_Image = Input;
            obj.Work_Image_Type = type;

            //string sql = "update Fin_Work_Order set Work_Image =" + Input + " where Work_Order_ID = " + obj.Work_Order_ID;
            //db.ExcuteQuery(sql);

            SqlCommand cmd = new SqlCommand();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = " update Fin_Work_Order set Work_Image =@Image ,Work_Image_Type=@Type where Work_Order_ID =@Work_Order_ID";
            cmd.Parameters.Add("@Image", SqlDbType.VarBinary);
            cmd.Parameters.Add("@Work_Order_ID", SqlDbType.BigInt);
            cmd.Parameters.Add("@Type", SqlDbType.NVarChar);

            cmd.Parameters["@Image"].Value = Input;
            cmd.Parameters["@Work_Order_ID"].Value = obj.Work_Order_ID;
            cmd.Parameters["@Type"].Value = obj.Work_Image_Type;
            con.Open();
            cmd.ExecuteScalar();
            con.Close();



        }
        if (FileUpload_Work_File.HasFile)
        {
            string DocName = FileUpload_Work_File.FileName;
            int dotindex = DocName.LastIndexOf(".");
            string type = DocName.Substring(dotindex, DocName.Length - dotindex);

            Stream myStream;
            int fileLen;
            StringBuilder displayString = new StringBuilder();
            fileLen = FileUpload_Work_File.PostedFile.ContentLength;
            Byte[] Input = new Byte[fileLen];
            myStream = FileUpload_Work_File.FileContent;
            myStream.Read(Input, 0, fileLen);

            obj.Work_File = Input;
            obj.Work_File_Type = type;

            SqlCommand cmd = new SqlCommand();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = " update Fin_Work_Order set Work_File =@Image ,Work_File_Type=@Type where Work_Order_ID =@Work_Order_ID";
            cmd.Parameters.Add("@Image", SqlDbType.VarBinary);
            cmd.Parameters.Add("@Work_Order_ID", SqlDbType.BigInt);
            cmd.Parameters.Add("@Type", SqlDbType.NVarChar);

            cmd.Parameters["@Image"].Value = Input;
            cmd.Parameters["@Work_Order_ID"].Value = obj.Work_Order_ID;
            cmd.Parameters["@Type"].Value = obj.Work_File_Type;
            con.Open();
            cmd.ExecuteScalar();
            con.Close();

        }
        if (FileUpload_Contract_Image.HasFile)
        {
            string DocName = FileUpload_Contract_Image.FileName;
            int dotindex = DocName.LastIndexOf(".");
            string type = DocName.Substring(dotindex, DocName.Length - dotindex);

            Stream myStream;
            int fileLen;
            StringBuilder displayString = new StringBuilder();
            fileLen = FileUpload_Contract_Image.PostedFile.ContentLength;
            Byte[] Input = new Byte[fileLen];
            myStream = FileUpload_Contract_Image.FileContent;
            myStream.Read(Input, 0, fileLen);

            obj.Contract_Image = Input;
            obj.Contract_Image_Type = type;

            SqlCommand cmd = new SqlCommand();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = " update Fin_Work_Order set Contract_Image =@Image ,Contract_Image_Type=@Type where Work_Order_ID =@Work_Order_ID";
            cmd.Parameters.Add("@Image", SqlDbType.VarBinary);
            cmd.Parameters.Add("@Work_Order_ID", SqlDbType.BigInt);
            cmd.Parameters.Add("@Type", SqlDbType.NVarChar);

            cmd.Parameters["@Image"].Value = Input;
            cmd.Parameters["@Work_Order_ID"].Value = obj.Work_Order_ID;
            cmd.Parameters["@Type"].Value = obj.Contract_Image_Type;
            con.Open();
            cmd.ExecuteScalar();
            con.Close();

        }
        if (FileUpload_Contract_File.HasFile)
        {
            string DocName = FileUpload_Contract_File.FileName;
            int dotindex = DocName.LastIndexOf(".");
            string type = DocName.Substring(dotindex, DocName.Length - dotindex);

            Stream myStream;
            int fileLen;
            StringBuilder displayString = new StringBuilder();
            fileLen = FileUpload_Contract_File.PostedFile.ContentLength;
            Byte[] Input = new Byte[fileLen];
            myStream = FileUpload_Contract_File.FileContent;
            myStream.Read(Input, 0, fileLen);

            obj.Contract_File = Input;
            obj.Contract_File_Type = type;

            SqlCommand cmd = new SqlCommand();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = " update Fin_Work_Order set Contract_File =@Image ,Contract_File_Type=@Type where Work_Order_ID =@Work_Order_ID";
            cmd.Parameters.Add("@Image", SqlDbType.VarBinary);
            cmd.Parameters.Add("@Work_Order_ID", SqlDbType.BigInt);
            cmd.Parameters.Add("@Type", SqlDbType.NVarChar);

            cmd.Parameters["@Image"].Value = Input;
            cmd.Parameters["@Work_Order_ID"].Value = obj.Work_Order_ID;
            cmd.Parameters["@Type"].Value = obj.Contract_File_Type;
            con.Open();
            cmd.ExecuteScalar();
            con.Close();

        }
    }

    private void Fill_Controll(int ID)
    {
        Fin_Work_Order_DT obj = Fin_Work_Order_DB.SelectByID(ID);
        hidden_Work_Order_ID.Value = obj.Work_Order_ID.ToString();
        txt_Code.Text = obj.Code;
        txt_Date.Text = obj.Date;
        ddl_Company_ID.SelectedValue = obj.Company_ID.ToString();
        txt_Comapny_Period.Text = obj.Comapny_Period.ToString();

        if (obj.Tender_Type_ID > 0)
            DDl_Tender_Type_ID.SelectedValue = obj.Tender_Type_ID.ToString();
        txt_Tender_NO.Text = obj.Tender_NO.ToString();
        ddl_Tender_Year.SelectedItem.Text = obj.Tender_Year.ToString();
        txt_Work_Total_Value.Text =CDataConverter.ConvertToInt( obj.Work_Total_Value).ToString();

        if (obj.Work_Image != null)
        {
            A1.Visible = true;
            A1.HRef = "../webforms/Fin_Document_View.aspx?type=1&id=" + hidden_Work_Order_ID.Value;
        }
        if (obj.Work_File != null)
        {
            A2.Visible = true;
            A2.HRef = "../webforms/Fin_Document_View.aspx?type=2&id=" + hidden_Work_Order_ID.Value;
        }
        if (obj.Contract_Image != null)
        {
            A3.Visible = true;
            A3.HRef = "../webforms/Fin_Document_View.aspx?type=3&id=" + hidden_Work_Order_ID.Value;
        }
        if (obj.Contract_File != null)
        {
            A4.Visible = true;
            A4.HRef = "../webforms/Fin_Document_View.aspx?type=4&id=" + hidden_Work_Order_ID.Value;
        }

        DataTable DT = Fin_Work_Activites_DB.SelectAll(obj.Work_Order_ID);
        foreach (GridViewRow grdrow in grdView_Main.Rows)
        {
            Label lbl_Parent_ID4 = (Label)grdrow.FindControl("lbl_Parent_ID");
            int parent_ID = CDataConverter.ConvertToInt(lbl_Parent_ID4.Text);
            HtmlInputCheckBox Chk_Parent = (HtmlInputCheckBox)grdrow.FindControl("Chk_Parent");
            GridView grdView_Sub = (GridView)grdrow.FindControl("grdView_Sub");
            DataRow[] DR = DT.Select("PActv_ID=" + parent_ID);
            if (DR.Length > 0)
            {
                Chk_Parent.Checked = true;
                foreach (GridViewRow grdrow_Sub in grdView_Sub.Rows)
                {
                    HtmlInputCheckBox Chk_Child = (HtmlInputCheckBox)grdrow_Sub.FindControl("Chk_Child");
                    Chk_Child.Checked = true;
                }
            }
            else
            {
                foreach (GridViewRow grdrow_Sub in grdView_Sub.Rows)
                {
                    Label lbl_Child_ID = (Label)grdrow_Sub.FindControl("lbl_Child_ID");
                    int Child_ID = CDataConverter.ConvertToInt(lbl_Child_ID.Text);
                    DataRow[] DRchild = DT.Select("PActv_ID=" + Child_ID);
                    if (DRchild.Length > 0)
                    {
                        HtmlInputCheckBox Chk_Child = (HtmlInputCheckBox)grdrow_Sub.FindControl("Chk_Child");
                        Chk_Child.Checked = true;
                    }
                }
            }

        }

    }

    void Clear_Cntrl()
    {
        hidden_Work_Order_ID.Value =
        txt_Code.Text =
        txt_Date.Text =
        txt_Comapny_Period.Text =
        txt_Tender_NO.Text =
        txt_Work_Total_Value.Text = "";

        ddl_Tender_Year.SelectedIndex =
        DDl_Tender_Type_ID.SelectedIndex =
        ddl_Company_ID.SelectedIndex = 0;

        A1.Visible =
            A2.Visible =
            A3.Visible =
            A4.Visible = false;





    }

    public DataTable GetDataSet(string ID)
    {
        return General_Helping.GetDataTable("SELECT    * FROM         Project_Activities WHERE     PActv_Parent=" + ID);
    }

    void Fil_Grid()
    {
        grd_View_Mng.DataSource = Fin_Work_Order_DB.SelectAll(CDataConverter.ConvertToInt(Smart_Project_ID.SelectedValue));
        grd_View_Mng.DataBind();
    }


    protected void btn_Doc_Click(object sender, EventArgs e)
    {
        if (CDataConverter.ConvertToInt(hidden_Work_Order_ID.Value) > 0)
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

                if (CDataConverter.ConvertToInt(hidden_File_ID.Value) > 0)
                {
                    SqlCommand cmd = new SqlCommand();
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = " update Fin_Work_bill_Files set File_data=@File_data ,File_Desc=@File_Desc,File_name=@File_name,File_ext=@File_ext,File_Sytem_Name=@File_Sytem_Name where File_ID =@File_ID";


                    cmd.Parameters.Add("@File_data", SqlDbType.VarBinary);
                    cmd.Parameters.Add("@File_ID", SqlDbType.Int);
                    cmd.Parameters.Add("@File_name", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@File_Desc", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@File_ext", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@File_Sytem_Name", SqlDbType.NVarChar);

                    if (Input.Length < 8000000)
                    {
                        cmd.Parameters["@File_data"].Value = Input;
                        cmd.Parameters["@File_Sytem_Name"].Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters["@File_data"].Value = DBNull.Value;

                        string filename = "";
                        string guid = System.Guid.NewGuid().ToString();
                        filename = FileUpload1.PostedFile.FileName;
                        filename = guid + filename.Substring(filename.LastIndexOf("\\") + 1);
                        string path = Server.MapPath("~\\Uploads\\Fin") + "\\";
                        string fullpath = path + filename;
                        FileUpload1.PostedFile.SaveAs(fullpath);

                        cmd.Parameters["@File_Sytem_Name"].Value = filename;
                    }

                    //cmd.Parameters["@File_data"].Value = Input;
                    cmd.Parameters["@File_ID"].Value = CDataConverter.ConvertToInt(hidden_File_ID.Value);
                    cmd.Parameters["@File_ext"].Value = type;
                    cmd.Parameters["@File_Desc"].Value = txt_File_Desc.Text;
                    cmd.Parameters["@File_name"].Value = txtFileName.Text;

                    con.Open();
                    cmd.ExecuteScalar();

                    con.Close();
                    txtFileName.Text =
                        txt_File_Desc.Text =
                    hidden_File_ID.Value = "";
                }
                else
                {
                    SqlCommand cmd = new SqlCommand();
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = " insert into Fin_Work_bill_Files ( Work_Or_Bill_ID,  Work_Or_Bill, File_data, File_name, File_ext,File_Desc,File_Sytem_Name) VALUES " +
                                                                        "( @Work_Or_Bill_ID,@Work_Or_Bill, @File_data, @File_name, @File_ext,@File_Desc,@File_Sytem_Name)";


                    cmd.Parameters.Add("@File_data", SqlDbType.VarBinary);
                    cmd.Parameters.Add("@Work_Or_Bill", SqlDbType.Int);
                    cmd.Parameters.Add("@Work_Or_Bill_ID", SqlDbType.Int);
                    cmd.Parameters.Add("@File_name", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@File_ext", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@File_Desc", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@File_Sytem_Name", SqlDbType.NVarChar);

                    if (Input.Length < 8000000)
                    {
                        cmd.Parameters["@File_data"].Value = Input;
                        cmd.Parameters["@File_Sytem_Name"].Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters["@File_data"].Value = DBNull.Value;

                        string filename = "";
                        string guid = System.Guid.NewGuid().ToString();
                        filename = FileUpload1.PostedFile.FileName;
                        filename = guid + filename.Substring(filename.LastIndexOf("\\") + 1);
                        string path = Server.MapPath("~\\Uploads\\Fin") + "\\";
                        string fullpath = path + filename;
                        FileUpload1.PostedFile.SaveAs(fullpath);

                        cmd.Parameters["@File_Sytem_Name"].Value = filename;
                    }


                    cmd.Parameters["@Work_Or_Bill_ID"].Value = CDataConverter.ConvertToInt(hidden_Work_Order_ID.Value);
                    cmd.Parameters["@Work_Or_Bill"].Value = 1;
                    cmd.Parameters["@File_ext"].Value = type;
                    cmd.Parameters["@File_Desc"].Value = txt_File_Desc.Text;
                    cmd.Parameters["@File_name"].Value = txtFileName.Text;

                    con.Open();
                    cmd.ExecuteScalar();

                    con.Close();
                    txtFileName.Text =
                        txt_File_Desc.Text =
                    hidden_File_ID.Value = "";

                }



            }





            // Clear_Cntrl();
            Fil_Grid_Documents();
        }
        else
        {
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('يجب إدخال بيانات أوامر التوريد أولا')</script>");

        }

    }

    protected void GrdView_Documents_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditItem")
        {
            DataTable DT = General_Helping.GetDataTable("select * from Fin_Work_bill_Files where File_ID=" + CDataConverter.ConvertToInt(e.CommandArgument));
            if (DT.Rows.Count > 0)
            {
                hidden_File_ID.Value = DT.Rows[0]["File_ID"].ToString();
                txtFileName.Text = DT.Rows[0]["File_name"].ToString();
                txt_File_Desc.Text = DT.Rows[0]["File_Desc"].ToString();

            }

        }

        if (e.CommandName == "RemoveItem")
        {
            General_Helping.GetDataTable("delete from Fin_Work_bill_Files where File_ID=" + CDataConverter.ConvertToInt(e.CommandArgument));
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم الحذف بنجاح')</script>");
            Fil_Grid_Documents();
        }
    }

    private void Fil_Grid_Documents()
    {

        DataTable DT = new DataTable();
        DT = General_Helping.GetDataTable("select * from Fin_Work_bill_Files where Work_Or_Bill = 1 and Work_Or_Bill_ID =" + CDataConverter.ConvertToInt(hidden_Work_Order_ID.Value));

        GrdView_Documents.DataSource = DT;
        GrdView_Documents.DataBind();
    }

    protected void ddl_NMT_ID_SelectedIndexChanged(object sender, EventArgs e)
    {

        Fil_dll_nmt();
        TabPanel_All.ActiveTab = TabPanel_Needs;

    }

    private void Fil_dll_nmt()
    {
        DataTable DT = new DataTable();
        DT = General_Helping.GetDataTable("select * from Needs_Sup_Type where nmt_nmt_id=" + ddl_NMT_ID.SelectedValue);
        Obj_General_Helping.SmartBindDDL(ddl_NST_ID, DT, "NST_ID", "NST_Desc", "....اختر البند الفرعى ....");
    }

    protected void btn_Needs_Click(object sender, EventArgs e)
    {
        if (CDataConverter.ConvertToInt(hidden_Work_Order_ID.Value) > 0)
        {
            Fin_Work_bill_Needs_DT obj = new Fin_Work_bill_Needs_DT();
            obj.Fin_Need_ID = CDataConverter.ConvertToInt(hidden_Fin_Need_ID.Value);
            obj.NMT_ID = CDataConverter.ConvertToInt(ddl_NMT_ID.SelectedValue);
            obj.NST_ID = CDataConverter.ConvertToInt(ddl_NST_ID.SelectedValue);
            obj.Value = CDataConverter.ConvertToInt(txt_Value.Text);
            obj.Work_Or_Bill = 1;
            obj.Work_Or_Bill_ID = CDataConverter.ConvertToInt(hidden_Work_Order_ID.Value);
            Fin_Work_bill_Needs_DB.Save(obj);
            txt_Value.Text = "";
            Fil_Grd_Needs();

        }
        else
        {
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('يجب إدخال بيانات أوامر التوريد أولا')</script>");

        }
    }


    protected void GridView_Needs_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditItem")
        {
            Fin_Work_bill_Needs_DT obj = Fin_Work_bill_Needs_DB.SelectByID(CDataConverter.ConvertToInt(e.CommandArgument));
            hidden_Fin_Need_ID.Value = obj.Fin_Need_ID.ToString();
            ddl_NMT_ID.SelectedValue = obj.NMT_ID.ToString();
            Fil_dll_nmt();
            ddl_NST_ID.SelectedValue = obj.NST_ID.ToString();
            txt_Value.Text = obj.Value.ToString();


        }

        if (e.CommandName == "RemoveItem")
        {
            Fin_Work_bill_Needs_DB.Delete(CDataConverter.ConvertToInt(e.CommandArgument));
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم الحذف بنجاح')</script>");
            Fil_Grd_Needs();
        }
    }
    private void Fil_Grd_Needs()
    {
        GridView_Needs.DataSource = Fin_Work_bill_Needs_DB.SelectAll_by_Parent_id(CDataConverter.ConvertToInt(hidden_Work_Order_ID.Value), 1);
        GridView_Needs.DataBind();
    }

    protected void btn_Letter_Click(object sender, EventArgs e)
    {
        if (CDataConverter.ConvertToInt(hidden_Work_Order_ID.Value) > 0)
        {
            Fin_Work_Order_Letter_DT obj = new Fin_Work_Order_Letter_DT();
            obj.Letter_Id = CDataConverter.ConvertToInt(hidden_Letter_Id.Value);
            obj.Work_Order_ID = CDataConverter.ConvertToInt(hidden_Work_Order_ID.Value);
            obj.Strt_DT = VB_Classes.Dates.Dates_Operation.date_validate(txt_Strt_DT.Text);
            obj.End_Dt = VB_Classes.Dates.Dates_Operation.date_validate(txt_End_Dt.Text);
            obj.Letter_Value = CDataConverter.ConvertToInt(txt_Letter_Value.Text);
            obj.Letter_Percent = CDataConverter.ConvertToInt(txt_Letter_Percent.Text);
            obj.Bank = txt_Bank.Text;
            obj.Type = CDataConverter.ConvertToInt(ddl_type.SelectedValue);
            obj.Alarm_DT = VB_Classes.Dates.Dates_Operation.date_validate(txt_Alarm_DT.Text);
            obj.Letter_Id = Fin_Work_Order_Letter_DB.Save(obj);
            if (FileUpload_letter.HasFile)
            {
                string DocName = FileUpload_letter.FileName;
                int dotindex = DocName.LastIndexOf(".");
                string type = DocName.Substring(dotindex, DocName.Length - dotindex);

                Stream myStream;
                int fileLen;
                StringBuilder displayString = new StringBuilder();
                fileLen = FileUpload_letter.PostedFile.ContentLength;
                Byte[] Input = new Byte[fileLen];
                myStream = FileUpload_letter.FileContent;
                myStream.Read(Input, 0, fileLen);

                obj.Letter_File = Input;
                obj.Letter_File_Type = type;

                SqlCommand cmd = new SqlCommand();
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = " update Fin_Work_Order_Letter set Letter_File =@Letter_File ,Letter_File_Type=@Letter_File_Type where Letter_Id =@Letter_Id";
                cmd.Parameters.Add("@Letter_File", SqlDbType.VarBinary);
                cmd.Parameters.Add("@Letter_Id", SqlDbType.BigInt);
                cmd.Parameters.Add("@Letter_File_Type", SqlDbType.NVarChar);

                cmd.Parameters["@Letter_File"].Value = Input;
                cmd.Parameters["@Letter_Id"].Value = obj.Letter_Id;
                cmd.Parameters["@Letter_File_Type"].Value = obj.Letter_File_Type;
                con.Open();
                cmd.ExecuteScalar();
                con.Close();



            }

            Clear_Letter_Cntrl();
            Fil_Grd_Letter();

        }
        else
        {
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('يجب إدخال بيانات أوامر التوريد أولا')</script>");

        }
    }

    protected void GridView_Letter_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditItem")
        {
            Fin_Work_Order_Letter_DT obj = Fin_Work_Order_Letter_DB.SelectByID(CDataConverter.ConvertToInt(e.CommandArgument));
            hidden_Letter_Id.Value = obj.Letter_Id.ToString();
            txt_Strt_DT.Text = obj.Strt_DT;
            txt_End_Dt.Text = obj.End_Dt;
            txt_Letter_Value.Text = obj.Letter_Value.ToString();
            txt_Letter_Percent.Text = obj.Letter_Percent.ToString();
            txt_Bank.Text = obj.Bank;
            ddl_type.SelectedValue = obj.Type.ToString();
            txt_Alarm_DT.Text = obj.Alarm_DT;


        }

        if (e.CommandName == "RemoveItem")
        {
            Fin_Work_Order_Letter_DB.Delete(CDataConverter.ConvertToInt(e.CommandArgument));
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم الحذف بنجاح')</script>");
            Fil_Grd_Letter();
        }
    }



    private void Fil_Grd_Letter()
    {
        GridView_Letter.DataSource = Fin_Work_Order_Letter_DB.Select_by_ID_Datatable(CDataConverter.ConvertToInt(hidden_Work_Order_ID.Value));
        GridView_Letter.DataBind();
    }

    private void Clear_Letter_Cntrl()
    {
        hidden_Letter_Id.Value =
        txt_Strt_DT.Text =
        txt_End_Dt.Text =
        txt_Letter_Value.Text =
        txt_Letter_Percent.Text =
        txt_Bank.Text =
        txt_Alarm_DT.Text = "";

    }

    protected void txt_comapny_ID_TextChanged(object sender, EventArgs e)
    {
        DataTable DT = new DataTable();
        DT = General_Helping.GetDataTable("select * from Fin_Company");
        Obj_General_Helping.SmartBindDDL(ddl_Company_ID, DT, "Company_ID", "Company_Name", "....اختر اسم الشركة ....");
        ddl_Company_ID.SelectedValue = txt_comapny_ID.Text;
    }

    public string Get_Type(object obj)
    {
        string str = obj.ToString();
        if (str == "1")
            return "ابتدائى";
        else if (str == "2")
            return "نهائى";
        else if (str == "3")
            return "مقابل دفعة مقدمة";
        else return "";
    }


}
