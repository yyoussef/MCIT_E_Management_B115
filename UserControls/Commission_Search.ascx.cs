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
using ReportsClass;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using ReportsClass;

public partial class UserControls_Commission_Search : System.Web.UI.UserControl
{
    string sql;
    SqlConnection conn;
    SqlDataAdapter da;
    DataSet ds;
    SqlCommand cmd;
    private string sql_Connection = Database.ConnectionString;
    General_Helping Obj_General_Helping = new General_Helping();
    Session_CS Session_CS = new Session_CS();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {


        }
    }


    protected override void OnInit(EventArgs e)
    {
      

        Smart_Emp_ID.sql_Connection = sql_Connection;
      string  Query = "SELECT EMPLOYEE.PMP_ID, EMPLOYEE.pmp_name FROM EMPLOYEE  where foundation_id='" + Session_CS.foundation_id + "' and EMPLOYEE.workstatus!=4";

        Smart_Emp_ID.datatble = General_Helping.GetDataTable(Query);
        Smart_Emp_ID.Value_Field = "pmp_id";
        Smart_Emp_ID.Text_Field = "pmp_name";
        Smart_Emp_ID.Orderby = "ORDER BY LTRIM(pmp_name)";
        Smart_Emp_ID.DataBind();


        base.OnInit(e);
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

    public void SearchRecord()
    {
        int dept = int.Parse(Session_CS.dept_id.ToString());
        string t1 = "";
        string t2 = "";

        int pmp = int.Parse(Session_CS.pmp_id.ToString());


        int group = 0;

        if (CDataConverter.ConvertToInt(Session_CS.parent_id.ToString()) > 0 || CDataConverter.ConvertToInt(Session_CS.child_emp.ToString()) > 0)
        {
            group = int.Parse(Session_CS.group_id.ToString());

        }
        else
        {

            group = CDataConverter.ConvertToInt(DBNull.Value);
        }
       
        

        SqlParameter[] parms = new SqlParameter[9];
        if (CDataConverter.ConvertToInt(Session_CS.parent_id.ToString()) > 0 || CDataConverter.ConvertToInt(Session_CS.child_emp.ToString()) > 0)
        {
            parms[0] = new SqlParameter("@group_id", int.Parse(Session_CS.group_id.ToString()));
        }
        else
        {
            parms[0] = new SqlParameter("@group_id", CDataConverter.ConvertToInt(DBNull.Value));
        }
        parms[1] = new SqlParameter("@pmp", int.Parse(Session_CS.pmp_id.ToString()));


        parms[2] = new SqlParameter("@subject", Com_name_text.Text);


        if (Com_date_from.Text == "")
        {
            parms[3] = new SqlParameter("@com_date_from","01/01/1900");
        }
        else
            parms[3] = new SqlParameter("@com_date_from", Com_date_from.Text);
        if (Com_date_to.Text == "")
        {
            parms[4] = new SqlParameter("@com_date_to", DateTime.MaxValue.ToString("dd/MM/yyyy"));
        }
        else
            parms[4] = new SqlParameter("@com_date_to", Com_date_to.Text);

       
       

        parms[5] = new SqlParameter("@visa_desc", txt_word_visa.Text);
        parms[6] = new SqlParameter("@notes_word", txt_word_notes.Text);
       

        parms[7] = new SqlParameter("@visa_emp", CDataConverter.ConvertToInt(Smart_Emp_ID.SelectedValue));

        parms[8] = new SqlParameter("@found_id", Session_CS.foundation_id);


        DataTable dt = new DataTable();
        dt = DatabaseFunctions.SelectDataByParam(parms, "commission_search_par");


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
        SearchRecord();



    }

    public string Get_Name()
    {
        return "ttt";
    }

    protected void gvMain_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void gvMain_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int pmp = int.Parse(Session_CS.pmp_id.ToString());
        DataTable dt = General_Helping.GetDataTable("select * from parent_employee where pmp_id = " + pmp);
        string encrypted = Encryption.Encrypt(e.CommandArgument.ToString());
        if (e.CommandName == "showItem")
        {


            //DataTable dt = General_Helping.GetDataTable("select * from parent_employee where pmp_id = " + pmp);

            //if (dt.Rows.Count > 0)
            //{
            //    Response.Redirect("Commission.aspx?id=" + e.CommandArgument);
            //}
            //else

            Response.Redirect("View_Commission.aspx?id=" + encrypted);
        }
        if (e.CommandName == "EditItem")
        {

            //DataTable dt = General_Helping.GetDataTable("select * from parent_employee where pmp_id = " + pmp);

            //if (dt.Rows.Count > 0)
            //{
            Response.Redirect("Commission.aspx?id=" + encrypted);
            //}
            //else

            //    Response.Redirect("View_Commission.aspx?id=" + e.CommandArgument);
        }

        //



    }
    protected void gvMain_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvMain.PageIndex = e.NewPageIndex;
        SearchRecord();
    }
    
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
    }


}
