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
using DBL;

public partial class UserControls_Change_Password : System.Web.UI.UserControl
{
    string sql, sql1;
    SqlConnection conn;
    SqlDataAdapter da;
    DataSet ds, ds_total;
    SqlCommand cmd;
    private string sql_Connection = Database.ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            if (Session["UserName"] != "" && Session["UserName"] != null)
            {

                Label2.Text = Session["UserName"].ToString();

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
    protected void SaveButton_Click(object sender, EventArgs e)
    {

      

        
     // DataTable dt=  General_Helping.GetDataTable("Select *  from super_admin  where User_name = '" + Session["UserName"].ToString() + "'");

        DataTable dt = SqlHelper.ExecuteDataset(Database.ConnectionString, "SuperAdminUsers_SelectName", Session["UserName"].ToString()).Tables[0];


        if (TxtRecentPass.Text == dt.Rows[0]["Password"].ToString())
        {
            if (TxtNewPassword.Text != "" && TxtRetype_Pass.Text != "")
            {
                if (TxtNewPassword.Text == TxtRetype_Pass.Text)
                {
                    //sql = "update super_admin  set Password = '" + TxtNewPassword.Text + "'";
                    //sql += " where ID=" + dt.Rows[0]["ID"].ToString();

                    SqlHelper.ExecuteNonQuery(Database.ConnectionString, "SuperAdminUsers_updateName", TxtNewPassword.Text, dt.Rows[0]["ID"].ToString());


                    ShowAlertMessage("تم تغيير كلمة السر بنجاح");
                }
                else
                {
                    ShowAlertMessage("!!!أعد كتابة كلمة السر بطريقة صحيحة");
                    return;
                }
            }
            else
            {
                ShowAlertMessage("!!!يجب إدخال كلمة السر");
                return;
            }



        }
        else if (TxtRecentPass.Text == "")
        {
            ShowAlertMessage("!!!لم يتم كتابة كلمة السر الحالية");
            return;
        }
        else
        {
            ShowAlertMessage("!!!كلمة السر الحالية خاطئة");
            return;
        }

    }
}
