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
using System.IO;
using System.Text;
//using CrystalDecisions.CrystalReports.Engine;
//using CrystalDecisions.Shared;



public partial class _Default : System.Web.UI.Page
{
    //Session_CS Session_CS = new Session_CS();
    //checkGit123
    protected void Page_Load(object sender, EventArgs e)
    {
    
        if (!IsPostBack)
        { 
            if (!IsCookieDisabled())
            {
                Footerlab.Text = Footerlab.Text + DateTime.Now.Year.ToString();
                tbl_login.Visible = true;
                tbl_cookie.Visible = false;
                tbl_footer.Visible = true;

                //if (Request["errorCode"] != null)
                //{


                //    string errorCode = Request["errorCode"].ToString();
                //    if (errorCode == "0")
                //    {
                //        if (Session["User_dt"] != null)
                //        {
                //            Fill_Session((DataTable)Session["User_dt"]);
                //        }
                //    }
                //    else
                //    {
                //        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msg", "alert('Invalid token');", true);
                //    }
                //}
               // logo_change();
            }
            else
            {
                //ShowAlertMessage("please enable cookies");
                //Button1.Visible = false;
                tbl_cookie.Visible = true;
                tbl_login.Visible = false;
                tbl_footer.Visible = true;
                lblchrome.Text = "<h3 ><br/><br/>error : you have to enable cookies to use E-managment application</h3 >";
                lblchrome.Text += "<h3 ><br/><br/>A)Enabling cookies on google chrome as follows:</h3 >";
                lblchrome.Text += "<h3 >1-Click the icon depicting three horizontal lines in the top-right corner:</h3 >";
                lblchrome.Text += "<h3 >2-Click Settings</h3 >";
                lblchrome.Text += "<h3 >3-Click Show advanced settings... at the bottom of the page</h3 >";
                lblchrome.Text += "<h3 >4-In the section entitled 'Privacy' click the button Content settings...</h3 >";
                lblchrome.Text += "<h3 >5-In the section entitled 'Cookies' select the option Allow local data to be set</h3 >";
                lblchrome.Text += "<h3 >6-click Done</h3 >";
                lblchrome.Text += "<h3 >7-please restart your browser</h3 >";

                lblchrome.Text += "<h3 ><br/><br/>B)Enabling cookies on Internet explorer as follows:</h3 >";
                lblchrome.Text += "<h3 >1-Click on the 'Tools' menu in Internet Explorer.:</h3 >";
                lblchrome.Text += "<h3 >2-Click 'Internet Options'.</h3 >";
                lblchrome.Text += "<h3 >3-Change to the 'Privacy' tab.</h3 >";
                lblchrome.Text += "<h3 >4-Set the horizontal slider to 'Medium'.</h3 >";
                lblchrome.Text += "<h3 >5-click sites</h3 >";
                lblchrome.Text += "<h3 >6-Enter your url in the 'Address of the website:' input </h3 >";
                lblchrome.Text += "<h3 >7-click Allow</h3 >";
                lblchrome.Text += "<h3 >8-click ok</h3 >";
                lblchrome.Text += "<h3 >9-please restart your browser</h3 >";

                
            }
            }
          

    }

    private bool IsCookieDisabled()
    {
        string currentUrl = Request.RawUrl;

        if (Request.QueryString["cookieCheck"] == null)
        {
            try
            {
                HttpCookie c = new HttpCookie("SupportCookies", "true");
                Response.Cookies.Add(c);

                if (currentUrl.IndexOf("?") > 0)
                    currentUrl = currentUrl + "&cookieCheck=true";
                else
                    currentUrl = currentUrl + "?cookieCheck=true";

                Response.Redirect(currentUrl);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        if (!Request.Browser.Cookies || Request.Cookies["SupportCookies"] == null)
            return true;

        return false;
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
    private void check()
    {
        if (Request["mode"] == "test")
        {
            div_test.Visible = true;
            div_test2.Visible = false;
        }
        else
        {
            div_test.Visible = false;
            div_test2.Visible = true;
        }

    }



    private void logo_change()
    {
        // DataTable dt_select = Site_Upload_DB.SelectAll();
        // Session["page_title"] = dt_select.Rows[0]["Site_Name"].ToString();
        // Page.Title = Session["page_title"].ToString();
        // string MY_File_Path = "";
        // MY_File_Path = "Uploads/Fin/";


        // Session["File_Path"] = MY_File_Path + dt_select.Rows[0]["File_Name"].ToString() + dt_select.Rows[0]["File_Ext"].ToString();

        // //FileStream fs = new FileStream(Session["File_Path"].ToString(), FileMode.Open, FileAccess.Read);

        // //byte[] bytes = new byte[fs.Length];
        // //fs.Read(bytes, 0, System.Convert.ToInt32(fs.Length));
        // //fs.Close();
        // // Response.ContentType = "application/x-unknown";
        // //Response.ContentType = "image/jpeg";

        // Session["File_Name"] = dt_select.Rows[0]["File_name"].ToString() + dt_select.Rows[0]["File_Ext"].ToString();


        // // Response.AddHeader("Content-Disposition", "attachment; filename=" + Server.UrlPathEncode(File_Name));
        // //Response.BinaryWrite(bytes);
        //// Response.Flush();
        //// Response.Close();





        //// img_logo.ResolveClientUrl(Session["File_Path"].ToString());
        // img_logo.Src = Session["File_Path"].ToString();
    }



    protected void Button1_Click(object sender, EventArgs e)
    {
        User_Login();

    }
    private void User_Login()
    {

        int config_attemts = CDataConverter.ConvertToInt(System.Configuration.ConfigurationManager.AppSettings["login_attempts"].ToString());

        DataTable dt = SqlHelper.ExecuteDataset(Database.ConnectionString, "Users_Select", UserName.Text, Password.Text).Tables[0];
        

        //string sql_Connection = Universal.GetConnectionString();
        //SqlDataAdapter SqlAdp = new SqlDataAdapter();
        //SqlConnection con = new SqlConnection(sql_Connection);
        //SqlCommand obj = new SqlCommand("Users_Select", con);
        //obj.CommandType = CommandType.StoredProcedure;

        //{
        //    obj.Parameters.Add((new SqlParameter("@USR_Name", UserName.Text)));

        //    obj.Parameters.Add((new SqlParameter("@USR_Pass", Password.Text)));

        //    con.Open();
        //    SqlAdp.SelectCommand = obj;
        //    DataTable dt = new DataTable();
        //    SqlAdp.Fill(dt);
        //    con.Close();
        if (dt.Rows.Count > 0)
        {
            //string Token_User_pin = dt.Rows[0]["Token_User_pin"].ToString();
            //if (string.IsNullOrEmpty(Token_User_pin))
            //{
                Fill_Session(dt);

             DataTable dtable = SqlHelper.ExecuteDataset(Database.ConnectionString, "Foundations_Select_localconnectionstring", Session_CS.foundation_id).Tables[0];

                if (dtable.Rows.Count > 0)
                {
                    fill_localfile_savesession(dtable);
                }
            //}
            //else
            //{
            //    //User_info obj_User_info = new User_info(Token_User_pin);
            //    //if (obj_User_info.Check_Valid_Token_login())
            //    //    Fill_Session(dt);
            //    //else
            //    //    ShowAlertMessage("Smart token error found !!! ");
            //   // Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "alert", "ValidateToken(" + Token_User_pin + ");", true);
            //    Session["User_dt"] = dt;
            //}



        }
        else
        {
            hdn_attempts.Value = (CDataConverter.ConvertToInt(hdn_attempts.Value) + 1).ToString();


            if (CDataConverter.ConvertToInt(hdn_attempts.Value) == config_attemts)
            {
                SqlHelper.ExecuteNonQuery(Database.ConnectionString, "users_lockaccount", UserName.Text);

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
    void fill_localfile_savesession(DataTable dtable)
    {

       
        Session_CS.local_filesave = Convert.ToBoolean(dtable.Rows[0]["islocal"].ToString());
        Session_CS.local_connectionstring = dtable.Rows[0]["connection_string"].ToString();
        
    }

    void Fill_Session(DataTable dt)
    {
        Session_CS.parent_id = 0;
        Session_CS.child_emp = 0;
        Session_CS.Project_id = 0;
        Session_CS.System_ID = CDataConverter.ConvertToInt(dt.Rows[0]["System_ID"].ToString());
        Session_CS.group_id = CDataConverter.ConvertToInt(dt.Rows[0]["Group_id"]);
        //Session_CS.UserName  =  dt.Rows[0]["pmp_name"].ToString();
        Session_CS.Usr_Name = dt.Rows[0]["USR_Name"].ToString();
        Session_CS.pmp_id = CDataConverter.ConvertToInt(dt.Rows[0]["PMP_ID"].ToString());
        Session_CS.dept = dt.Rows[0]["Dept_name"].ToString();
        Session_CS.dept_id = CDataConverter.ConvertToInt(dt.Rows[0]["Dept_Dept_id"].ToString());
        Session_CS.UROL_UROL_ID = CDataConverter.ConvertToInt(dt.Rows[0]["UROL_UROL_ID"].ToString());
        Session_CS.vacation_mng = CDataConverter.ConvertToInt(dt.Rows[0]["vacation_mng_pmp_id"].ToString());
        Session_CS.sec_id = CDataConverter.ConvertToInt(dt.Rows[0]["sec_sec_id"].ToString());
        Session_CS.pmp_name = dt.Rows[0]["pmp_name"].ToString();
        Session_CS.foundation_id = CDataConverter.ConvertToInt(dt.Rows[0]["foundation_id"].ToString());
        Session_CS.code_archiving = CDataConverter.ConvertToInt(dt.Rows[0]["code_archiving"].ToString());

      Session_CS.code_outbox = CDataConverter.ConvertToInt(dt.Rows[0]["code_outbox"].ToString());
        Session_CS.Host = dt.Rows[0]["Host"].ToString();
        Session_CS.UserName_mail = dt.Rows[0]["UserName_mail"].ToString();
       // Session_CS.FromAddress =  dt.Rows[0]["FromAddress"].ToString().Replace("\r\n", "");
        Session_CS.FromAddress =  dt.Rows[0]["FromAddress"].ToString();

        Session_CS.Port = CDataConverter.ConvertToInt(dt.Rows[0]["Port"].ToString());
        //Session_CS.Password = CDataConverter.ConvertToInt(dt.Rows[0]["Password"].ToString());
        Session_CS.Password = dt.Rows[0]["Password"].ToString();

        //if (dt.Rows[0]["islocal"].ToString() != "" && Convert.ToBoolean(dt.Rows[0]["islocal"].ToString()) == true)
        //{
        //    Session_CS.local_filesave = Convert.ToBoolean(dt.Rows[0]["islocal"].ToString());
        //    Session_CS.local_connectionstring = dt.Rows[0]["connection_string"].ToString();
        //}
        //Session_CS.Dept_parent_id = CDataConverter.ConvertToInt(dt.Rows[0]["Dept_parent_id"].ToString());

       
        //DataTable dtparentbychild = new DataTable();
        //dtparentbychild = Inbox_class.getparent(CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()), 1);
        //if (dtparentbychild.Rows.Count > 0)
        //{
        //    Session_CS.parentbychild = dtparentbychild.Rows[0]["parent_pmp_id"].ToString();
        //}
        //else
        //{
        //   Session_CS.parentbychild  = "0";
        //}

        //DataTable dt_getchild = new DataTable();
        //dt_getchild = Inbox_class.getchild(CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()));
        //if (dt_getchild.Rows.Count > 0)
        if (CDataConverter.ConvertToInt(dt.Rows[0]["child"].ToString()) > 0)
        {
            Session_CS.child_emp = CDataConverter.ConvertToInt(dt.Rows[0]["pmp_id"].ToString());
        }
        else
        {
            Session_CS.child_emp = 0;
        }

       // DataTable dt_emp_MNG = General_Helping.GetDataTable("select parent_pmp_id,pmp_id from parent_employee where parent_pmp_id = " + CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()));
        if (CDataConverter.ConvertToInt(dt.Rows[0]["parent_pmp_id"].ToString()) > 0)
            Session_CS.parent_id = CDataConverter.ConvertToInt(dt.Rows[0]["parent_pmp_id"].ToString());
        else
            Session_CS.parent_id = 0;

        //DataTable UserVacationAdmin = General_Helping.GetDataTable("select DISTINCT PMP_ID from EMPLOYEE where vacation_mng_pmp_id=" + Session_CS.pmp_id.ToString());
        //if (UserVacationAdmin.Rows.Count > 0)
        //    Session_CS.is_vacation_mng = 1;
        //else
        //    Session_CS.is_vacation_mng = 0;

        //DataTable dt_Eval_mng = General_Helping.GetDataTable("select DISTINCT PMP_ID from EMPLOYEE where direct_manager= " + Session_CS.pmp_id.ToString() + " or  higher_manager = " + Session_CS.pmp_id.ToString());
        //if (dt_Eval_mng.Rows.Count > 0)
        //    Session_CS.Eval_mng = 1;
        //else
        //    Session_CS.Eval_mng = 0;


        //if the enter employee is hr set session 1 else 0


        if (Session_CS.group_id.ToString() == "12")

            Session_CS.Hr_Eval = 1;
        else
            Session_CS.Hr_Eval = 0;


        //if (dt.Rows[0]["PMP_ID"].ToString() == "436" || dt.Rows[0]["PMP_ID"].ToString() == "1965" || dt.Rows[0]["PMP_ID"].ToString() == "383" || dt.Rows[0]["PMP_ID"].ToString() == "62" || dt.Rows[0]["PMP_ID"].ToString() == "450" || dt.Rows[0]["PMP_ID"].ToString() == "37" || Session_CS.group_id.ToString() == "15")
        //{
        Response.Redirect("~/MainForm");
        //}


        //if (dt.Rows[0]["System_ID"].ToString() == "0")
        //{
        //    Response.Redirect("~/WebForms2");
        //}

        //else
        //    Response.Redirect("~/WebForms");


    }
    //public static void ShowAlertMessage(string error)
    //{

    //    Page page = HttpContext.Current.Handler as Page;
    //    if (page != null)
    //    {
    //        error = error.Replace("'", "\'");
    //        ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('" + error + "');", true);
    //    }
    //}
}
