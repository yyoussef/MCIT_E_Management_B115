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


public partial class WebForms_Emp_ADD : System.Web.UI.Page
{
    Session_CS Session_CS = new Session_CS();
    string sql, sql1;
    SqlConnection conn;
    SqlDataAdapter da;
    DataSet ds, ds_total;
    SqlCommand cmd;
    private string sql_Connection = Database.ConnectionString;
    General_Helping Obj_General_Helping = new General_Helping();


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            Label2.Text = Session_CS.pmp_name.ToString();
            fillgrid();
            Fil_Dll();
            Fill_emp();


        }
    }
    public void Fil_Dll()
    {
        DataTable DT = new DataTable();
        DT = General_Helping.GetDataTable("select * from Departments");
        Obj_General_Helping.SmartBindDDL(ddl_Dept_ID, DT, "Dept_ID", "Dept_name", "....اختر اسم الإدارة ....");
        //SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        //conn.Open();
        //sql = "select * from Departments";
        //da = new SqlDataAdapter(sql, conn);
        //DataSet ds = new DataSet ();
        //da.Fill(ds);
        //ddl_Dept_ID.DataSource = ds;
        //ddl_Dept_ID.DataTextField = "Dept_name";
        //ddl_Dept_ID.DataValueField = "Dept_ID";
        //ddl_Dept_ID.DataBind();

    }
    public void Fill_emp()
    {
        DataTable DT = new DataTable();
        DT = General_Helping.GetDataTable("select * from MCIT_mail_list");
        Obj_General_Helping.SmartBindDDL(Drop_Names, DT, "Adress", "Name", "....اختر اسم الموظف ....");


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

    public void fillgrid()
    {

        DataTable dt = General_Helping.GetDataTable("select * from employee");
        if (dt.Rows.Count == 0)
        {
            gvMain.EmptyDataText = ".....عفوا لا يوجد بيانات ......";
        }
        else
        {
            gvMain.DataSource = dt;
        }

        gvMain.DataBind();
        
    }
    protected void SaveButton_Click(object sender, EventArgs e)
    {

        if (h1.Value != "0")
        {
            if (txt_emp_name.Text != "" && txt_emp_email.Text != "" && ddl_Dept_ID.SelectedValue != "0")
            {
                sql = "update Employee set pmp_name = '" + txt_emp_name.Text + "'";
                sql += " , mail = '" + txt_emp_email.Text + "'" + " where pmp_id = " + int.Parse(h1.Value);
                General_Helping.ExcuteQuery(sql);

            }
            else
            {
                ShowAlertMessage("يجب ادخال كافة البيانات");
                return;
            }
        }
        else
        {
            if (txt_emp_name.Text != "" && txt_emp_email.Text != "" && ddl_Dept_ID.SelectedValue != "0")
            {
                DataTable DT = new DataTable();
                DT = General_Helping.GetDataTable("select * from employee where mail = '"+txt_emp_email.Text+"'");
                if (DT.Rows.Count != 0)
                {
                    ShowAlertMessage("هذا الموظف موجود بالفعل بإسم " + DT.Rows[0]["pmp_name"].ToString());
                    return;
                }
                else
                {
                    sql = "insert into Employee (pmp_name,mail,group_id,rol_rol_id,Dept_Dept_id) values ('" + txt_emp_name.Text + "','" + txt_emp_email.Text + "','" + 1 + "','" + 7 + "'," + ddl_Dept_ID.SelectedValue + ")";
                    General_Helping.ExcuteQuery(sql);
                    ShowAlertMessage("تم الحفظ بنجاح");
                }


               
            }
            else
            {
                ShowAlertMessage("يجب ادخال كافة البيانات");
                return;
            }
        }
        fillgrid();
    }
    protected void gvMain_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        conn.Open();
        if (e.CommandName == "EditItem")
        {
            // Response.Redirect("../webforms/Project_Inbox.aspx?id=" + e.CommandArgument);
            sql = "select * from employee where pmp_id = " + e.CommandArgument;
            da = new SqlDataAdapter(sql, conn);
            ds = new DataSet();
            da.Fill(ds);
            txt_emp_name.Text = ds.Tables[0].Rows[0]["pmp_name"].ToString();
            txt_emp_email.Text = ds.Tables[0].Rows[0]["mail"].ToString();
            Fil_Dll();
            Fill_emp();
            h1.Value = e.CommandArgument.ToString();
        }
        //if (e.CommandName == "RemoveItem")
        //{

        //    sql += "delete from employee where pmp_id = " + e.CommandArgument;
        //    cmd = new SqlCommand(sql, conn);
        //    cmd.ExecuteNonQuery();
        //    conn.Close();

        //    gvMain.DataBind();

        //    Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم الحذف بنجاح')</script>");
        //    fillgrid();
        //}
    }
    protected void gvMain_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvMain.PageIndex = e.NewPageIndex;
        fillgrid();
    }
    protected void Drop_Names_SelectedIndexChanged(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        conn.Open();
        sql = "select Adress from MCIT_mail_list where name = '" + Drop_Names.SelectedItem.Text + "'";
        da = new SqlDataAdapter(sql, conn);
        ds = new DataSet();
        da.Fill(ds);
        txt_emp_email.Text = ds.Tables[0].Rows[0]["Adress"].ToString();
    }
}
