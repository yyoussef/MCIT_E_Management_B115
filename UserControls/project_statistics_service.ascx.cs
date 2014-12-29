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


public partial class UserControls_project_statistics_service : System.Web.UI.UserControl
{
    private string sql_Connection = Database.ConnectionString;
    General_Helping Obj_General_Helping = new General_Helping();
    Session_CS Session_CS = new Session_CS();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            if (CDataConverter.ConvertToInt(Session_CS.Project_id.ToString()) > 0)
            {

                Fil_Grid_Documents();


            }





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


    public string Get_Type(object obj)
    {
        string str = obj.ToString();
        if (str == "0")
            return "خدمات مواطنين";
        else if (str == "1")
            return "خدمات جهة حكومية";
        else return "وثيقة";
    }

    protected void btn_Doc_Click(object sender, EventArgs e)
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

            if (CDataConverter.ConvertToInt(hidden_proj_img_serv_File_ID.Value) > 0)
            {
                SqlCommand cmd = new SqlCommand();
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = " update proj_statistics_service set proj_id=@proj_id , service_id=@service_id ,File_data=@File_data ,File_name=@File_name,File_ext=@File_ext where proj_statistics_service_id =@proj_statistics_service_id";


                cmd.Parameters.Add("@File_data", SqlDbType.VarBinary);
                cmd.Parameters.Add("@proj_statistics_service_id", SqlDbType.Int);
                cmd.Parameters.Add("@service_id", SqlDbType.Int);
                cmd.Parameters.Add("@File_name", SqlDbType.NVarChar);
                cmd.Parameters.Add("@File_ext", SqlDbType.NVarChar);
                cmd.Parameters.Add("@proj_id", SqlDbType.Int);

                cmd.Parameters["@File_data"].Value = Input;
                cmd.Parameters["@proj_statistics_service_id"].Value = CDataConverter.ConvertToInt(hidden_proj_img_serv_File_ID.Value);
                cmd.Parameters["@service_id"].Value = CDataConverter.ConvertToInt(ddl_service.SelectedValue);
                cmd.Parameters["@File_ext"].Value = type;
                cmd.Parameters["@File_name"].Value = txtFileName.Text;
                cmd.Parameters["@proj_id"].Value = CDataConverter.ConvertToInt(Session_CS.Project_id.ToString());

                con.Open();
                cmd.ExecuteScalar();

                con.Close();
                txtFileName.Text =
                hidden_proj_img_serv_File_ID.Value = "";
            }
            else
            {
                SqlCommand cmd = new SqlCommand();
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = " insert into proj_statistics_service ( proj_id, service_id, File_data, File_name, File_ext) VALUES ( @proj_id, @service_id, @File_data, @File_name, @File_ext)";


                cmd.Parameters.Add("@File_data", SqlDbType.VarBinary);
                cmd.Parameters.Add("@service_id", SqlDbType.Int);
                cmd.Parameters.Add("@proj_id", SqlDbType.Int);

                cmd.Parameters.Add("@File_name", SqlDbType.NVarChar);
                cmd.Parameters.Add("@File_ext", SqlDbType.NVarChar);

                cmd.Parameters["@File_data"].Value = Input;
                cmd.Parameters["@service_id"].Value = CDataConverter.ConvertToInt(ddl_service.SelectedValue);
                cmd.Parameters["@proj_id"].Value = CDataConverter.ConvertToInt(Session_CS.Project_id.ToString());

                cmd.Parameters["@File_ext"].Value = type;
                cmd.Parameters["@File_name"].Value = txtFileName.Text;

                con.Open();
                cmd.ExecuteScalar();

                con.Close();
                txtFileName.Text =
                hidden_proj_img_serv_File_ID.Value = "";

            }



        }
        else
        {
            ShowAlertMessage("يجب ادخال ملف");
            return;
        }





        // Clear_Cntrl();
        Fil_Grid_Documents();
    }



    protected void ddl_service_SelectedIndexChanged(object sender, EventArgs e)
    {
        Fil_Grid_Documents();

    }
    protected void GrdView_Documents_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditItem")
        {
            proj_statistics_service_DT obj = proj_statistics_service_DB.SelectByID(CDataConverter.ConvertToInt(e.CommandArgument));
            if (obj.proj_id > 0)
            {
                hidden_proj_img_serv_File_ID.Value = obj.proj_statistics_service_id.ToString();
                txtFileName.Text = obj.File_name;
                ddl_service.SelectedValue = obj.service_id.ToString();
            }

        }

        if (e.CommandName == "RemoveItem")
        {
            proj_statistics_service_DB.Delete(CDataConverter.ConvertToInt(e.CommandArgument));
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم الحذف بنجاح')</script>");
            Fil_Grid_Documents();
        }
    }

    private void Fil_Grid_Documents()
    {
        DataTable DT = new DataTable();
        DT = General_Helping.GetDataTable("select * from proj_statistics_service where proj_id = " + CDataConverter.ConvertToInt(Session_CS.Project_id.ToString()) + "and  service_id=" + ddl_service.SelectedValue);

        GrdView_Documents.DataSource = DT;
        GrdView_Documents.DataBind();
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










































}
