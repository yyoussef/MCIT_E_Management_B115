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

public partial class UserControls_Change_Password : System.Web.UI.UserControl
{
    string sql, sql1;
    SqlConnection conn;
    SqlDataAdapter da;
    DataSet ds, ds_total;
    SqlCommand cmd;
    private string sql_Connection = Database.ConnectionString;
    Session_CS Session_CS = new Session_CS();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            Label2.Text = Session_CS.pmp_name.ToString();

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
        //if (Regex.IsMatch(UserName.Value, @"^[a-zA-Z-\d-أ-ي]{1,40}$") && Regex.IsMatch(Password.Value, @"^[a-zA-Z-\d\w\@\!]{8,16}$"))
        //string reg = @"^[a-zA-Z-\d\w\@\!]{8,16}+$";
        //if (Regex.Escape(TxtNewPassword.Text) != "")

        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        conn.Open();
        sql = " Select * from Users where USR_Name = '" + Session_CS.Usr_Name.ToString() + "'";
        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        ds = new DataSet();
        da.Fill(ds);
        if (TxtRecentPass.Text == ds.Tables[0].Rows[0]["USR_Pass"].ToString())
        {
            if (TxtNewPassword.Text != "" && TxtRetype_Pass.Text != "")
            {
                if (TxtNewPassword.Text == TxtRetype_Pass.Text)
                {
                    sql = "update Users set USR_Pass = '" + TxtNewPassword.Text + "'";
                    sql += " where USR_ID=" + ds.Tables[0].Rows[0]["USR_ID"].ToString();
                    cmd = new SqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
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
