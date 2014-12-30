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
using System.Data.SqlClient;
using System.IO;
using DBL;
using System.Text;

public partial class MainForm_FDocuments : System.Web.UI.Page
{
    //Session_CS Session_CS = new Session_CS();
    string sql_Connection = Universal.GetConnectionString();
    string Str =""; 
    protected void Page_Load(object sender, EventArgs e)
     {
        if (!IsPostBack)
        {
            //txtdate.Text = DateTime.Today.ToString("dd/MM/yyyy");
            //GridView1.DataBind();
            //gvMain.DataBind();
            FileSearch();
            //int user_id = Convert.ToInt32(Session_CS.UROL_UROL_ID);
            //if (user_id == 8)

            //SaveButnDoc.Enabled = false;
            //if (mode.Value != "edit")
            //GridView1.Visible = false;

            if (Request["Files_id"] != null)
            {
                fill_controls();
            }
        }
    }
    public string Fileid()
    {
        string FID = "";

        SqlDataAdapter sqladptr = new SqlDataAdapter();
        SqlConnection con = new SqlConnection(sql_Connection);
        SqlCommand obj = new SqlCommand("Get_Files_ID", con);
        obj.CommandType = CommandType.StoredProcedure;
        con.Open();
        sqladptr.SelectCommand = obj;
        DataTable DT = new DataTable();
        sqladptr.Fill(DT);
        FID = DT.Rows[0]["Files_id"].ToString();
        con.Close();
        return FID;
    }
    public void AddNewDocument()
    {
        if (TextBox3.Text != "")
        {
            Str = Request.QueryString["id"];
            SqlDataAdapter sqladptr = new SqlDataAdapter();
            SqlConnection con = new SqlConnection(sql_Connection);
            SqlCommand obj = new SqlCommand("Add_Update_FileDocuments", con);
            obj.CommandType = CommandType.StoredProcedure;
            obj.Parameters.Add(new SqlParameter("@Doc_ID", Convert.ToInt16(doc_ID.Value)));
            obj.Parameters.Add(new SqlParameter("@Source_id", Convert.ToInt32(Source_name.SelectedValue)));
            if (Str != null)
                obj.Parameters.Add(new SqlParameter("@Files_id", Convert.ToInt16(Str)));
            else
            obj.Parameters.Add(new SqlParameter("@Files_id", Fileid()));
            

            obj.Parameters.Add(new SqlParameter("@mode", "new"));

            if (Upload_File_data.HasFile)
            {
                string DocName = Upload_File_data.FileName;
                int dotindex = DocName.LastIndexOf(".");
                string type = DocName.Substring(dotindex, DocName.Length - dotindex);

                Stream myStream;
                int fileLen;
                StringBuilder displayString = new StringBuilder();
                fileLen = Upload_File_data.PostedFile.ContentLength;
                Byte[] Input = new Byte[fileLen];
                myStream = Upload_File_data.FileContent;
                myStream.Read(Input, 0, fileLen);

                //obj.Parameters.Add(new SqlParameter("@mode", "editWithFile"));
                obj.Parameters.Add(new SqlParameter("@Doc_File", Input));
                obj.Parameters.Add(new SqlParameter("@Doc_name", TextBox3.Text));
                obj.Parameters.Add(new SqlParameter("@Doc_type", type));

                con.Open();
               // int rows = obj.ExecuteNonQuery();

                object objj = obj.ExecuteScalar();
                doc_ID.Value = Convert.ToString(objj);
                con.Close();

              //  if (rows > 0)
               // {
                
                    lblErrorMsg.Text= "تم إدخال الوثيقة بنجاح";
               
                   // btn_ClearFileds.Visible = true;
                   // btn_SendToManager.Visible = true;
                    SqlDataAdapter sqladptr1 = new SqlDataAdapter();
                    SqlConnection con1 = new SqlConnection(sql_Connection);
                    SqlCommand obj1 = new SqlCommand("Get_All_Files_Q", con1);
                    obj1.CommandType = CommandType.StoredProcedure;
                    obj1.Parameters.Add(new SqlParameter("@id", Fileid()));
                    con1.Open();
                    sqladptr1.SelectCommand = obj1;
                    DataTable DT1 = new DataTable(); 
                    sqladptr1.Fill(DT1);
                    con1.Close();
                    if (DT1.Rows.Count > 0)
                    {


                        GridView1.DataSource = DT1;
                        GridView1.DataBind();
                        GridView1.Visible = true;
                    }
               // }
            }
            //TextBox3.Text = "";
            Source_name.SelectedIndex = 0;
        }
        else
            lblErrorMsg.Text = "اختر وثيقة أولاَ";

        //edit//
        //    else
        //    {
        //        Byte[] Input = new Byte[3];
        //        obj.Parameters.Add(new SqlParameter("@File_name", Input));
        //        obj.Parameters.Add(new SqlParameter("@File_name", ""));
        //        obj.Parameters.Add(new SqlParameter("@mode", "edit"));
        //    }
        //    con.Open();
        //    int rows = obj.ExecuteNonQuery();
        //    con.Close();

        //    if (rows > 0)
        //        lblErrorMsg.Text = "تم التعديل بنجاح.";
        //    else
        //        lblErrorMsg.Text = "حدث خطأ أثناء التعديل من فضلك حاول مرة اخرى.";

        //    Event_name.Text = "";
        //    Event_date.Text = "";
        //    Event_location.Text = "";
        //    Notes.Text = "";
        //}
        //else
        //    lblErrorMsg.Text = "أدخل كافة الحقول التى يسبقها *";
        //FillGrid();
        //SaveButton.Text = "حفظ";


    }
    public void UpdateDocument()
    {
        if (TextBox3.Text != "")
        {
            SqlDataAdapter sqladptr = new SqlDataAdapter();
            SqlConnection con = new SqlConnection(sql_Connection);
            SqlCommand obj = new SqlCommand("Add_Update_FileDocuments", con);
            obj.CommandType = CommandType.StoredProcedure;
            obj.Parameters.Add(new SqlParameter("@Doc_ID", Convert.ToInt16(doc_ID.Value)));
            obj.Parameters.Add(new SqlParameter("@Source_id", Convert.ToInt32(Source_name.SelectedValue)));
            
            obj.Parameters.Add(new SqlParameter("@Files_id", Doc_File_id.Value));
            obj.Parameters.Add(new SqlParameter("@mode", "editWithFile"));

            if (Upload_File_data.HasFile)
            {
                string DocName = Upload_File_data.FileName;

                int dotindex = DocName.LastIndexOf(".");
                string type = DocName.Substring(dotindex, DocName.Length - dotindex);
                Stream myStream;
                int fileLen;
                StringBuilder displayString = new StringBuilder();
                fileLen = Upload_File_data.PostedFile.ContentLength;
                Byte[] Input = new Byte[fileLen];
                myStream = Upload_File_data.FileContent;
                myStream.Read(Input, 0, fileLen);

                obj.Parameters.Add(new SqlParameter("@Doc_File", Input));
                obj.Parameters.Add(new SqlParameter("@Doc_name", TextBox3.Text));
                obj.Parameters.Add(new SqlParameter("@Doc_type", type));

                con.Open();
                int rows = obj.ExecuteNonQuery();
                con.Close();

            }
            
            lblErrorMsg.Text = "تم التعديل بنجاح.";
            mode.Value = "edit";
            SqlDataAdapter sqladptr1 = new SqlDataAdapter();
            SqlConnection con1 = new SqlConnection(sql_Connection);
            SqlCommand obj1 = new SqlCommand("Get_All_Files_Q", con1);
            obj1.CommandType = CommandType.StoredProcedure;
            obj1.Parameters.Add(new SqlParameter("@id", Doc_File_id.Value));
            con1.Open();
            sqladptr1.SelectCommand = obj1;
            DataTable DT1 = new DataTable();
            sqladptr1.Fill(DT1);
            con1.Close();
            if (DT1.Rows.Count > 0)
            {


                GridView1.DataSource = DT1;
                GridView1.DataBind();
                GridView1.Visible = true;
            }
        }
        else
            lblErrorMsg.Text = "ادخل البيانات أولاَ";
    }
    public void UpdateRow()
    {
        //bool isDate = false;
        //if (VB_Classes.Dates.Dates_Operation.date_validate(txtdate.Text) != "")
        //    isDate = true;

        if (txtdate.Text!= "" && TextBox1.Text != "")
        {
            Str = Request.QueryString["id"];
            SqlDataAdapter sqladptr = new SqlDataAdapter();
            SqlConnection con = new SqlConnection(sql_Connection);
            SqlCommand obj = new SqlCommand("Add_Update_Files", con);
            obj.CommandType = CommandType.StoredProcedure;
            obj.Parameters.Add(new SqlParameter("@id", Convert.ToInt16(Str)));
            obj.Parameters.Add(new SqlParameter("@File_Name", TextBox1.Text));
            obj.Parameters.Add(new SqlParameter("@File_date", txtdate.Text));
            obj.Parameters.Add(new SqlParameter("@File_note", doctxt.Text));
            // obj.BeginExecuteReader();

            obj.Parameters.Add(new SqlParameter("@mode", "edit"));
            con.Open();
            int rows = obj.ExecuteNonQuery();
            con.Close();

            if (rows > 0)

                lblErrorMsg.Text = "تم التعديل بنجاح.";

        }
        else
        {
            lblErrorMsg.Text = "ادخل البيانات أولاَ";
            //GridView1.DataBind();
        }
    }
    //if (File_data.HasFile)
    //    {
    //        string DocName = File_data.FileName;
    //        int dotindex = DocName.LastIndexOf(".");
    //        string type = DocName.Substring(dotindex, DocName.Length - dotindex);
    //        string fileName = DocName.Substring(0, dotindex);
    //        Stream myStream;
    //        int fileLen;
    //        StringBuilder displayString = new StringBuilder();
    //        fileLen = File_data.PostedFile.ContentLength;
    //        Byte[] Input = new Byte[fileLen];
    //        myStream = File_data.FileContent;
    //        myStream.Read(Input, 0, fileLen);

    //        obj.Parameters.Add(new SqlParameter("@mode", "editWithFile"));
    //        obj.Parameters.Add(new SqlParameter("@File_data", Input));
    //        obj.Parameters.Add(new SqlParameter("@File_name", fileName));
    //        obj.Parameters.Add(new SqlParameter("@File_ext", type));
    //    }
    //    else
    //    {
    //        Byte[] Input = new Byte[3];
    //        obj.Parameters.Add(new SqlParameter("@File_name", Input));
    //        obj.Parameters.Add(new SqlParameter("@File_name", ""));
    //        obj.Parameters.Add(new SqlParameter("@mode", "edit"));
    //    }
    //    con.Open();
    //    int rows = obj.ExecuteNonQuery();
    //    con.Close();

    //    if (rows > 0)
    //        lblErrorMsg.Text = "تم التعديل بنجاح.";
    //    else
    //        lblErrorMsg.Text = "حدث خطأ أثناء التعديل من فضلك حاول مرة اخرى.";

    //    Event_name.Text = "";
    //    Event_date.Text = "";
    //    Event_location.Text = "";
    //    Notes.Text = "";
    //}
    //else
    //    lblErrorMsg.Text = "أدخل كافة الحقول التى يسبقها *";
    //FillGrid();
    //SaveButton.Text = "حفظ";



    public void AddRow()
    {
        //bool isDate = false;
        //if (VB_Classes.Dates.Dates_Operation.date_validate(txtdate.Text) != "")
        //    isDate = true;

       
            
            SqlDataAdapter sqladptr = new SqlDataAdapter();
            SqlConnection con = new SqlConnection(sql_Connection);
            SqlCommand obj = new SqlCommand("Add_Update_Files", con);
            obj.CommandType = CommandType.StoredProcedure;
            obj.Parameters.Add(new SqlParameter("@id", Convert.ToInt16(File_id.Value)));
            obj.Parameters.Add(new SqlParameter("@File_Name", TextBox1.Text));
            obj.Parameters.Add(new SqlParameter("@File_date", txtdate.Text));
            obj.Parameters.Add(new SqlParameter("@File_note", doctxt.Text));
            if (File_id.Value == "0")
            obj.Parameters.Add(new SqlParameter("@mode", "new"));
            else
            obj.Parameters.Add(new SqlParameter("@mode", "edit"));
            con.Open();
            int rows = obj.ExecuteNonQuery();
            con.Close();

            if (rows > 0)
            {
                File_id.Value = Fileid();
                lblErrorMsg.Text = "تم الإدخال بنجاح.";
                SaveButnDoc.Enabled = true;
            
               
            }
            
            //gvMain.DataBind();
        
        //else if (Upload_File_data.HasFile == false)
        //{ lblErrorMsg.Text = "ادخل الوثيقة"; }

      }
    public void FileSearch()
    {
        Str = Request.QueryString["id"];
        if (Str != null)
        {
            fillFields();
            SqlDataAdapter sqladptr = new SqlDataAdapter();
            SqlConnection con = new SqlConnection(sql_Connection);
            SqlCommand obj = new SqlCommand("Get_All_Files_Q", con);
            obj.CommandType = CommandType.StoredProcedure;
            obj.Parameters.Add(new SqlParameter("@id", Convert.ToInt32(Str)));
            con.Open();
            sqladptr.SelectCommand = obj;
            DataTable DT = new DataTable();
            sqladptr.Fill(DT);
            con.Close();
            if (DT.Rows.Count > 0)
            {


                GridView1.DataSource = DT;
                GridView1.DataBind();
                GridView1.Visible = true;
            }
            btn_SendToManager.Visible = true;
        }
        
       
    }
    public void fillFields()
    {
        Str = Request.QueryString["id"];
        SqlDataAdapter sqladptr = new SqlDataAdapter();
        SqlConnection con = new SqlConnection(sql_Connection);
        SqlCommand obj = new SqlCommand("Get_Files", con);
        obj.CommandType = CommandType.StoredProcedure;
        obj.Parameters.Add(new SqlParameter("@id", Convert.ToInt32(Str)));
        con.Open();
        sqladptr.SelectCommand = obj;
        DataTable DT = new DataTable();
        sqladptr.Fill(DT);
        con.Close();
        txtdate.Text = DT.Rows[0]["File_date"].ToString();
        TextBox1.Text = DT.Rows[0]["File_Name"].ToString();
        doctxt.Text = DT.Rows[0]["File_note"].ToString();
        mode.Value = "edit";
    }

    protected void SaveButnDoc_Click(object sender, EventArgs e)
    {
        
        if (mode.Value != "editDoc")
        {
            if (TextBox1.Text == "")
            {
                lblErrorMsg.Text = "ادخل اسم الملف أولاَ";
            }
            if (txtdate.Text == "")
            {
                lblErrorMsg.Text = "ادخل التاريخ";
            }

            else
            {
                AddNewDocument();
                FileSearch();

            }
        }


        else
        {
            UpdateDocument();
        }

    }
    protected void SaveButton_Click(object sender, EventArgs e)
    {
        //if (mode.Value == "new")
        //{
        //    AddRow();
        //    txtdate.Enabled = false;
        //    TextBox1.Enabled = false;
        //    doctxt.Enabled = false;
        //    gvMain.DataBind();
        //}
        //else
        //UpdateRow();
        //gvMain.DataBind();
        //SaveButton.Text = "حفظ";
        if (mode.Value == "new")
        {
            if (Str == "")
            {
                if (TextBox1.Text == "")
                {
                    lblErrorMsg.Text = "ادخل اسم الملف أولاَ";
                }
                if (txtdate.Text == "")
                {
                    lblErrorMsg.Text = "ادخل التاريخ";
                }

                else
                {
                    AddRow();
                    //AddNewDocument();
                    //TextBox3.Enabled = false;
                    //Source_name.Enabled = false;
                    //TextBox1.Enabled = false;
                    //txtdate.Enabled = false;
                    //doctxt.Enabled = false;
                    //GridView1.DataBind();
                    btn_ClearFileds.Visible = true;
                    btn_SendToManager.Visible  = true;
                    
                }
            }
        }
        else if (mode.Value == "edit")
            UpdateRow();
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditItem")
        {
            doc_ID.Value = (e.CommandArgument).ToString();
            mode.Value = "editDoc";
            Doc_File_id.Value = Request.QueryString["id"];
            if (Doc_File_id.Value == "")
                Doc_File_id.Value=Fileid();
           
            SqlDataAdapter sqladptr = new SqlDataAdapter();
            SqlConnection con = new SqlConnection(sql_Connection);
            SqlCommand obj = new SqlCommand("Get_File_Documents", con);
            obj.CommandType = CommandType.StoredProcedure;
            obj.Parameters.Add(new SqlParameter("@id", Convert.ToInt16(doc_ID.Value)));
            con.Open();
            sqladptr.SelectCommand = obj;
            DataTable DT = new DataTable();
            sqladptr.Fill(DT);
            con.Close();
            if (DT.Rows.Count > 0)
            {
                TextBox3.Text = DT.Rows[0]["File_name"].ToString();
                Source_name.SelectedValue = DT.Rows[0]["Source_id"].ToString();

            }
        }
        if (e.CommandName == "RemoveItem")
        {
            doc_ID.Value = (e.CommandArgument).ToString();
            SqlDataAdapter sqladptr = new SqlDataAdapter();
            SqlConnection con = new SqlConnection(sql_Connection);
            SqlCommand obj = new SqlCommand("Delete_Files_Documents", con);
            obj.CommandType = CommandType.StoredProcedure;
            obj.Parameters.Add(new SqlParameter("@id", Convert.ToInt16(e.CommandArgument)));
            con.Open();
            sqladptr.SelectCommand = obj;
            DataTable DT = new DataTable();
            sqladptr.Fill(DT);
            con.Close();
            lblErrorMsg.Text = "تم الحذف بنجاح.";
            GridView1.DataBind();
        }

    }
    //protected void gvMain_RowCommand(object sender, GridViewCommandEventArgs e)
    //{
        //if (e.CommandName == "EditItem")
        //{
        //    File_id.Value = (e.CommandArgument).ToString();
        //    SqlDataAdapter sqladptr = new SqlDataAdapter();
        //    SqlConnection con = new SqlConnection(sql_Connection);
        //    SqlCommand obj = new SqlCommand("Get_Files", con);
        //    obj.CommandType = CommandType.StoredProcedure;
        //    obj.Parameters.Add(new SqlParameter("@id", Convert.ToInt16(e.CommandArgument)));

        //    con.Open();

        //    sqladptr.SelectCommand = obj;
        //    DataTable DT = new DataTable();
        //    sqladptr.Fill(DT);
        //    con.Close();
        //    //doc_ID.Value = DT.Rows[0]["Files_ID"].ToString();
        //    if (DT.Rows.Count  > 0)
        //    {
        //        TextBox1.Text = DT.Rows[0]["File_Name"].ToString();
        //        txtdate.Text = DT.Rows[0]["File_date"].ToString();
        //        doctxt.Text = DT.Rows[0]["File_note"].ToString();
        //        mode.Value = "edit";
        //    }
        //}
       
        //if (e.CommandName == "RemoveItem")
        //{
        //    File_id.Value = (e.CommandArgument).ToString();
        //    SqlDataAdapter sqladptr = new SqlDataAdapter();
        //    SqlConnection con = new SqlConnection(sql_Connection);
        //    SqlCommand obj = new SqlCommand("Delete_Files", con);
        //    obj.CommandType = CommandType.StoredProcedure;
        //    obj.Parameters.Add(new SqlParameter("@id", Convert.ToInt16(e.CommandArgument)));
        //    con.Open();
        //    sqladptr.SelectCommand = obj;
        //    DataTable DT = new DataTable();
        //    sqladptr.Fill(DT);
        //    con.Close();
        //    lblErrorMsg.Text = "تم الحذف بنجاح.";
        //    gvMain.DataBind();
        //}

    //}


    protected void btn_SendToManager_Click(object sender, EventArgs e)
    {
        
        DataTable dtselect = File_Archive_Status_DB.Select_BYFileID(CDataConverter.ConvertToInt(Request.QueryString["id"]));
        if (dtselect.Rows.Count > 0 )
        {
            General_Helping.ExcuteQuery("update File_Archive_Status set status=0 where file_id='" + CDataConverter.ConvertToInt(Request.QueryString["id"]) + "'");
         Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('تم  الارسال الي المدير المختص بنجاح ')</script>");
        }
        else
        {
            DataTable dtselect2 = File_Archive_Status_DB.Select_BYFileID(CDataConverter.ConvertToInt(File_id.Value));
            if (dtselect2.Rows.Count > 0)
            {
                General_Helping.ExcuteQuery("update File_Archive_Status set status=0 where file_id='" + CDataConverter.ConvertToInt(File_id.Value) + "'");
                Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('تم  الارسال الي المدير المختص بنجاح ')</script>");
            }
            else
            {
                File_Archive_Status_DT obj = new File_Archive_Status_DT();
                // obj.pmp_id = CDataConverter.ConvertToInt(Session_CS.pmp_id);
                obj.pmp_id = 0;
                obj.status = 0;
                obj.file_id = CDataConverter.ConvertToInt(File_id.Value);
                File_Archive_Status_DB.Save(obj);
                Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('تم  الارسال الي المدير المختص بنجاح ')</script>");
                // btn_SendToManager.Visible = false;
                //clear();
            }
        }


    }

    protected void btn_ClearFileds_Click(object sender, EventArgs e)
    {
        clear();

 


    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void clear()
    {
        File_id.Value = "0"; 
        TextBox1.Text = "";
        txtdate.Text = "";
        doctxt.Text = "";
        TextBox3.Text = "";
        Source_name.SelectedValue = "0";

        GridView1.DataSource = null;
        GridView1.DataBind();
        btn_SendToManager.Visible = false;
        


    }



    private void fill_controls()
    {
        int files_id = Convert.ToInt32(Request["Files_id"]);
        Files_DT  dt = Files_DB.SelectByID(files_id);
        TextBox1.Text = dt.File_Name.ToString();
        TextBox1.Enabled = false;
        txtdate.Text = dt.File_date.ToString();
        txtdate.Enabled = false;
        doctxt.Text = dt.File_note.ToString();
        doctxt.Enabled = false;
        SaveButton.Enabled  = false;
        TextBox3.Enabled = false;
        Source_name.Enabled = false;
        Upload_File_data.Enabled = false;
        SaveButnDoc.Enabled = false;
        Label2.Text = "بيانات الملف";
        DataTable DtFiles = Files_DB.SelectAllFileDocumnets(files_id);
        if (DtFiles.Rows.Count > 0)
        {


            GridView1.DataSource = DtFiles;
           GridView1.DataBind();
            GridView1.Visible = true;
            
       for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            ImageButton img_btn = (ImageButton)GridView1.Rows[i].FindControl("ImgBtnEdit");
            ImageButton img_btn1 = (ImageButton)GridView1.Rows[i].FindControl("ImgBtnDelete");
            img_btn.Enabled = false;
            img_btn1.Enabled = false;     

        }

        }

        //////////Update File status to 1 as readed  ////////////////////////

        General_Helping.ExcuteQuery("update File_Archive_Status set status = 1 where file_id='"+files_id+"' ");

        
    }
}



