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
using ReportsClass;
using System.Data.Linq;
using System.Collections.Generic;
using System.Data.Entity.Core;
using DBL;

public partial class UserControls_Change_Password : System.Web.UI.UserControl
{
    string sql, sql1;
    SqlConnection conn;
    SqlDataAdapter da;
    DataSet ds, ds_total;
    SqlCommand cmd;
    private string sql_Connection = Database.ConnectionString;

    Projects_ManagementEntities10 pmentity = new Projects_ManagementEntities10();
    Projects_ManagementEntities pmgenentity = new Projects_ManagementEntities();
    OutboxDataContext outboxDBContext = new OutboxDataContext();

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


    public void InsertOrUpdate(super_admin blog)
    {


        using (var context = new Projects_ManagementEntities())
        {
            context.Entry(blog).State = blog.ID == 0 ?
                                      System.Data.Entity.EntityState.Added :
                                      System.Data.Entity.EntityState.Modified;

            context.SaveChanges();

        }
    }


    protected void SaveButton_Click(object sender, EventArgs e)
    {



        //  DataTable dt = SqlHelper.ExecuteDataset(Database.ConnectionString, "SuperAdminUsers_SelectName", Session["UserName"].ToString()).Tables[0];

        DataTable dt = pmgenentity.SuperAdminUsers_SelectName(Session["UserName"].ToString()).ToDataTable();

        if (TxtRecentPass.Text == dt.Rows[0]["Password"].ToString())
        {
            if (TxtNewPassword.Text != "" && TxtRetype_Pass.Text != "")
            {
                if (TxtNewPassword.Text == TxtRetype_Pass.Text)
                {
                 //   sql = "update super_admin  set Password = '" + TxtNewPassword.Text + "'";
                  //  sql += " where ID=" + dt.Rows[0]["ID"].ToString();

                    SqlHelper.ExecuteNonQuery(Database.ConnectionString, "SuperAdminUsers_updateName", TxtNewPassword.Text, dt.Rows[0]["ID"].ToString());
                 //   super_admin obj = new super_admin();
                 //   obj.ID = CDataConverter.ConvertToInt(dt.Rows[0]["ID"].ToString());
                  //  obj.Password = TxtNewPassword.Text;
                    
                  //  InsertOrUpdate(obj);



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
