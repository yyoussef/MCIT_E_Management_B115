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
using Dates;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Text;
using System.IO;
using DBL;



public partial class UserControls_Project_Attitude : System.Web.UI.UserControl
{
    int rows;
    int x;
    string sql_Connection = Universal.GetConnectionString();
    Session_CS Session_CS = new Session_CS();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillgrid();
            btn_send.Visible = false;


        }
    }
    private void fillgrid()
    {
        DataTable DT = General_Helping.GetDataTable("SELECT * FROM File_Archive");
        gv_files.DataSource = DT;
        gv_files.DataBind();

    }


    protected void btnSave_Click(object sender, EventArgs e)
    {

        if (mode.Value == "new")
        {
            AddNewRecord();
        }
        else
        {
            UpdateExistRecord();
           
        }


    }


    protected void gv_files_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditItem")
        {
            SqlDataAdapter sqladptr = new SqlDataAdapter();
            SqlConnection con = new SqlConnection(sql_Connection);
            SqlCommand obj = new SqlCommand("Get_all_filearchive", con);
            obj.CommandType = CommandType.StoredProcedure;
            obj.Parameters.Add(new SqlParameter("@id", Convert.ToInt16(e.CommandArgument)));
            Archive_ID.Value = e.CommandArgument.ToString();
            con.Open();
            sqladptr.SelectCommand = obj;
            DataTable DT = new DataTable();
            sqladptr.Fill(DT);
            con.Close();

            tx_filename.Text = DT.Rows[0]["file_name"].ToString();
            txt_desc.Text = DT.Rows[0]["file_desc"].ToString();


            mode.Value = "edit";
            btnSave.Text = "تعديل";
            btn_send.Visible = false  ;
            


        }


        if (e.CommandName == "RemoveItem")
        {
            General_Helping.ExcuteQuery("delete from File_Archive where id='" + CDataConverter.ConvertToInt(e.CommandArgument) + "'");
            General_Helping.ExcuteQuery("delete from File_Archive_Status where file_id='" + CDataConverter.ConvertToInt(e.CommandArgument) + "'");

            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('تم الحذف بنجاح')</script>");
            fillgrid();
            btn_send.Visible = false;


        }
    }
    protected void btn_send_Click(object sender, EventArgs e)
    {

        //DataTable dtselect = General_Helping.GetDataTable("select * from File_Archive_Status where file_id='"+Archive_ID.Value  +"'");
        //if (dtselect.Rows.Count > 0 )
        //{
        //    lbl_result.Visible = true;
        //    lbl_result.Text = " تم الارسال الي المدير المختص من قبل";

        //}
        //else
        //{
            File_Archive_Status_DT obj = new File_Archive_Status_DT();
            // obj.pmp_id = CDataConverter.ConvertToInt(Session_CS.pmp_id);
            obj.pmp_id = 0;
            obj.status = 0;
            obj.file_id = CDataConverter.ConvertToInt(file_id.Value);
            File_Archive_Status_DB.Save(obj);
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('تم  الارسال الي المدير المختص بنجاح ')</script>");
            btn_send.Visible = false;
            clear();
      //  }


    }
    private void clear()
    {
        file_id.Value=
        txt_desc.Text = "";
      //  Archive_ID.Value=
        tx_filename.Text = "";

    }



    public void AddNewRecord()
    {

        SqlDataAdapter sqladptr = new SqlDataAdapter();
        SqlConnection con = new SqlConnection(sql_Connection);
        SqlCommand obj = new SqlCommand("Add_Edit_filearchive", con);
        obj.CommandType = CommandType.StoredProcedure;


        if (FileUpload1.HasFile)
        {
            string DocName = FileUpload1.FileName;
            int dotindex = DocName.LastIndexOf(".");
            string type = DocName.Substring(dotindex, DocName.Length - dotindex);
            //  string fileName = DocName.Substring(0, dotindex);
            Stream myStream;
            int fileLen;
            StringBuilder displayString = new StringBuilder();
            fileLen = FileUpload1.PostedFile.ContentLength;
            Byte[] Input = new Byte[fileLen];
            myStream = FileUpload1.FileContent;
            myStream.Read(Input, 0, fileLen);

            obj.Parameters.Add(new SqlParameter("@File_data", Input));
            obj.Parameters.Add(new SqlParameter("@File_name", DocName));
            obj.Parameters.Add(new SqlParameter("@id", "0"));
            obj.Parameters.Add(new SqlParameter("@mode", "new"));
            obj.Parameters.Add(new SqlParameter("@file_desc", txt_desc.Text));

            con.Open();
            object objj = obj.ExecuteScalar();
            file_id.Value = Convert.ToString(objj);
            con.Close();

            fillgrid();
           // clear();
            btn_send.Visible = true;
            btn_clear.Visible = true;
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('    تم الحفظ بنجاح  ')</script>");



        }
        else
        {
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert(' يجب إختيار ملف التحميل  ')</script>");

        }




    }


    public void UpdateExistRecord()
    {
        string DocName;
        SqlDataAdapter sqladptr = new SqlDataAdapter();
        SqlConnection con = new SqlConnection(sql_Connection);
        SqlCommand obj = new SqlCommand("Add_Edit_filearchive", con);
        obj.CommandType = CommandType.StoredProcedure;
        obj.Parameters.Add(new SqlParameter("@id", CDataConverter.ConvertToInt(Archive_ID.Value)));
       // obj.Parameters.Add(new SqlParameter("@mode", "edit"));
        obj.Parameters.Add(new SqlParameter("@file_desc", txt_desc.Text));

        if (FileUpload1.HasFile)
        {
            DocName = FileUpload1.FileName;
            int dotindex = DocName.LastIndexOf(".");
            string type = DocName.Substring(dotindex, DocName.Length - dotindex);
           // string fileName = DocName.Substring(0, dotindex);
            Stream myStream;
            int fileLen;
            StringBuilder displayString = new StringBuilder();
            fileLen = FileUpload1.PostedFile.ContentLength;
            Byte[] Input = new Byte[fileLen];
            myStream = FileUpload1.FileContent;
            myStream.Read(Input, 0, fileLen);

            obj.Parameters.Add(new SqlParameter("@File_data", Input));
            obj.Parameters.Add(new SqlParameter("@File_name", DocName));
            obj.Parameters.Add(new SqlParameter("@mode", "editWithFile"));

        }
        else
        {
            Byte[] Input = new Byte[3];
            obj.Parameters.Add(new SqlParameter("@File_data", Input));
            obj.Parameters.Add(new SqlParameter("@File_name","" ));
            obj.Parameters.Add(new SqlParameter("@mode","edit"));

        }
        con.Open();
        rows = obj.ExecuteNonQuery();
        con.Close();
        fillgrid();
      
        clear();
        mode.Value = "new";

        Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('    تم التعديل بنجاح  ')</script>");
        btnSave.Text = "حفظ";



    }

    protected void btn_clear_Click(object sender, EventArgs e)
    {

        clear();


    }




}
