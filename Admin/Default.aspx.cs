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
using System.Data.OleDb;
using System.Data.SqlClient;
using DBL;


public partial class Admin_Default : System.Web.UI.Page
{
    Session_CS Session_CS = new Session_CS();
    protected void Page_Load(object sender, EventArgs e)
    {



        //Session["ID"] = "";
        //Session.Clear();
        //Session.RemoveAll();
        if (!IsPostBack)
        {
            Footerlab.Text = Footerlab.Text + DateTime.Now.Year.ToString();
            int found_id = 0;
            DataTable dt = Site_Upload_DB.SelectAll(found_id);
            if (dt.Rows.Count > 0)
            {
                try
                {
                    //read the values from database into the site upload dt object
                    Site_Upload_DT obj = new Site_Upload_DT();
                    obj.ID = (int)dt.Rows[0]["ID"];
                    obj.Site_Name = dt.Rows[0]["Site_Name"].ToString();
                    obj.File_Name = dt.Rows[0]["File_Name"].ToString();
                    obj.File_Ext = dt.Rows[0]["File_Ext"].ToString();
                    obj.e_signature = dt.Rows[0]["e_signature"].ToString();

                    Session_CS.e_signature = obj.e_signature.ToString();
                    Session_CS.Site_Name = obj.Site_Name;
                    Page.Title = obj.Site_Name;
                    //load the values into the page controls
                    string newPath = "";
                    newPath = "~/Uploads/SitesPics/" + obj.File_Name + "." + obj.File_Ext;
                    HtmlImage headerImage = (HtmlImage)Page.FindControl("headerImage");
                    //headerImage.ImageUrl = newPath;
                    headerImage.Src = newPath;
                }
                catch (Exception EX)
                {

                }

            }
        }

        //Response.Redirect("Default.aspx");
        //Users_Select
        //if (!IsPostBack) 
        //{
        //    string filePath = @"D:\MCIT-Projects\Project-documents\Test.xls";
        //    // filePath = File1.Value;
        //    string strConn;
        //    strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" +
        //    "Data Source=" + filePath + ";" +
        //    "Extended Properties=Excel 8.0;";
        //    OleDbDataAdapter myCommand = new OleDbDataAdapter("SELECT * FROM [Sheet$]", strConn);
        //    DataSet myDataSet = new DataSet();
        //    myCommand.Fill(myDataSet, "ExcelInfo");
        //    GridView1.DataSource = myDataSet;
        //    GridView1.DataBind();
        //}

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        User_Login();

    }
    private void User_Login()
    {
       // int attempts = 0;
        int config_attemts = CDataConverter.ConvertToInt(System.Configuration.ConfigurationManager.AppSettings["login_attempts"].ToString());

        DataTable dt = SqlHelper.ExecuteDataset(Database.ConnectionString, "Admin_UsersSelect", UserName.Text, Password.Text).Tables[0];

        //string sql = "select * from Admin_Users where User_name='" + UserName.Text + "' and Password='" + Password.Text + "'";
        //DataTable dt = General_Helping.GetDataTable(sql);

        if (dt.Rows.Count > 0)
        {
            Session["pmp_name"] = dt.Rows[0]["Name"].ToString();
            Session["ID"] = dt.Rows[0]["ID"].ToString();
            Session_CS.foundation_id = CDataConverter.ConvertToInt(dt.Rows[0]["foundation_id"].ToString());

            Response.Redirect("../Admin/Home.aspx");

        }

        else
        {
            hdn_attempts.Value = (CDataConverter.ConvertToInt(hdn_attempts.Value) + 1).ToString() ;


            if (CDataConverter.ConvertToInt(hdn_attempts.Value) == config_attemts)
            {
                SqlHelper.ExecuteNonQuery(Database.ConnectionString, "Admin_Users_lockaccount", UserName.Text);

                ShowAlertMessage("!!!تم غلق الحساب الخاص بك نتيجة لآستنفاذك عدد المحاولات برجاء الاتصال بمدير النظام لتفعيل الحساب ");

            }
            else if (CDataConverter.ConvertToInt(hdn_attempts.Value) < config_attemts)
            {
                ShowAlertMessage("!!!يوجد خطأ فى اسم المستخدم أو كلمة المرور من فضلك أعد المحاولة ");
            }
            else
            {
                ShowAlertMessage("!!! هذا الحساب مغلق برجاء الاتصال بمدير النظام لتفعيل الحساب");

            }

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

}

  

