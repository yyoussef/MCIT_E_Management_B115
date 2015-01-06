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

public partial class WebForms_Protocole_Search : System.Web.UI.Page
{
    //Session_CS Session_CS = new Session_CS();
    string sql;
    SqlConnection conn;
    SqlDataAdapter da;
    DataSet ds;
    SqlCommand cmd;
    protected void Page_Load(object sender, EventArgs e)
    {
        
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
        string t1 = "";
        string t2 = "";
        string t3 = "";
        string t4 = "";
        string t5 = "";
        string t6 = "";
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        sql = "SELECT     TOP (100) PERCENT Protocol_Def.Protocol_ID, Protocol_Def.Name, Protocol_Def.Signt_Str_DT, Protocol_Def.Signt_End_DT, Protocol_Def.Total_Balance_LE,                        Protocol_Def.Total_Balance_US, Organization.Org_Desc, Protocol_Type.Type_Name, Protocol_Type.Type_ID, Organization.Org_ID ";
        sql += "  FROM         Protocol_Type RIGHT OUTER JOIN                       Protocol_Def ON Protocol_Type.Type_ID = Protocol_Def.Type LEFT OUTER JOIN                       Organization ON Protocol_Def.Org_ID = Organization.Org_ID WHERE     (1 = 1) ";
                     
        if (Protocole_name_text.Text!="")
        {
            sql += " AND Name like" + "'%" + Protocole_name_text.Text + "%'";
        }
        if (Txt_doc_name.Text!="")
        {
            sql += " AND Protocol_Documents.File_Name like" + "'%" + Txt_doc_name.Text + "%'";
        }
        if (Drop_doc_Type.SelectedValue!="0")
        {
            sql += " AND Protocol_Documents.File_Kind = " + Drop_doc_Type.SelectedValue;
        }
        /*
        //////////////////////////////////////// begin chek on doc date "dbo.Protocol_Documents.File_Date" //////////////////////////////////////////
        if (string.IsNullOrEmpty(Txt_doc_date_from.Text) && string.IsNullOrEmpty(Txt_doc_date_to.Text))
        {
            t1 = DateTime.ParseExact("01/01/1900", "MM/dd/yyyy", null).ToString("MM/dd/yyyy");
            t2 = DateTime.MaxValue.ToString("MM/dd/yyyy");
            sql += " AND convert(datetime,dbo.Protocol_Documents.File_Date,103) > = '" + t1.ToString() + "' OR dbo.Protocol_Documents.File_Date is NULL ";
            sql += " AND convert(datetime,dbo.Protocol_Documents.File_Date,103) < = '" + t2.ToString() + "' OR dbo.Protocol_Documents.File_Date is NULL";
        }
        else if (string.IsNullOrEmpty(Txt_doc_date_from.Text))
        {
            t1 = DateTime.ParseExact("01/01/1900", "MM/dd/yyyy", null).ToString("MM/dd/yyyy");
            t2 = DateTime.ParseExact(Txt_doc_date_to.Text, "dd/MM/yyyy", null).ToString("MM/dd/yyyy");

            sql += " AND convert(datetime,dbo.Protocol_Documents.File_Date,103) < = '" + t2.ToString() + "' OR dbo.Protocol_Documents.File_Date is NULL";
        }
        else if (string.IsNullOrEmpty(Txt_doc_date_to.Text))
        {
            t1 = DateTime.ParseExact(Txt_doc_date_from.Text, "dd/MM/yyyy", null).ToString("MM/dd/yyyy");
            t2 = DateTime.MaxValue.ToString("MM/dd/yyyy");

            sql += " AND convert(datetime,dbo.Protocol_Documents.File_Date,103) > = '" + t1.ToString() + "' OR dbo.Protocol_Documents.File_Date is NULL";
        }
        else
        {
            t1 = DateTime.ParseExact(Txt_doc_date_from.Text, "dd/MM/yyyy", null).ToString("MM/dd/yyyy");

            t2 = DateTime.ParseExact(Txt_doc_date_to.Text, "dd/MM/yyyy", null).ToString("MM/dd/yyyy");

            sql += " AND convert(datetime,dbo.Protocol_Documents.File_Date,103) > = '" + t1.ToString() + "' OR dbo.Protocol_Documents.File_Date is NULL";
            sql += " AND convert(datetime,dbo.Protocol_Documents.File_Date,103) < = '" + t2.ToString() + "' OR dbo.Protocol_Documents.File_Date is NULL";

        }
        DateTime date1 = DateTime.ParseExact(t1, "MM/dd/yyyy", null);
        DateTime date2 = DateTime.ParseExact(t2, "MM/dd/yyyy", null);
        if (date2.Subtract(date1).Days < 0)
        {
            ShowAlertMessage("!!!!!التاريخ الأول يجب ان يكون قبل التاريخ الثاني !!!!");
            return;
        }

        /////////////////////////////////////// end chek on doc date "dbo.Protocol_Documents.File_Date" /////////////
        ///////////////////////////// begin check on sign start date////////////////////////////////////////////

        if (string.IsNullOrEmpty(prot_strt_date_from.Text) && string.IsNullOrEmpty(prot_strt_date_to.Text))
        {
            t3 = DateTime.ParseExact("01/01/1900", "MM/dd/yyyy", null).ToString("MM/dd/yyyy");
            t4 = DateTime.MaxValue.ToString("MM/dd/yyyy");
            sql += " AND convert(datetime,Signt_Str_DT,103) > = '" + t3.ToString() + "'";
            sql += " AND convert(datetime,Signt_Str_DT,103) < = '" + t4.ToString() + "'";
        }
        else if (string.IsNullOrEmpty(prot_strt_date_from.Text))
        {
            t3 = DateTime.ParseExact("01/01/1900", "MM/dd/yyyy", null).ToString("MM/dd/yyyy");
            t4 = DateTime.ParseExact(prot_strt_date_to.Text, "dd/MM/yyyy", null).ToString("MM/dd/yyyy");

            sql += " AND convert(datetime,Signt_Str_DT,103) < = '" + t4.ToString() + "'";
        }
        else if (string.IsNullOrEmpty(prot_strt_date_to.Text))
        {
            t3 = DateTime.ParseExact(prot_strt_date_from.Text, "dd/MM/yyyy", null).ToString("MM/dd/yyyy");
            t4 = DateTime.MaxValue.ToString("MM/dd/yyyy");

            sql += " AND convert(datetime,Signt_Str_DT,103) > = '" + t1.ToString() + "'";
        }
        else
        {
            t3 = DateTime.ParseExact(prot_strt_date_from.Text, "dd/MM/yyyy", null).ToString("MM/dd/yyyy");

            t4 = DateTime.ParseExact(prot_strt_date_to.Text, "dd/MM/yyyy", null).ToString("MM/dd/yyyy");

            sql += " AND convert(datetime,Signt_Str_DT,103) > = '" + t3.ToString() + "'";
            sql += " AND convert(datetime,Signt_Str_DT,103) < = '" + t4.ToString() + "'";

        }
        DateTime date3 = DateTime.ParseExact(t3, "MM/dd/yyyy", null);
        DateTime date4 = DateTime.ParseExact(t4, "MM/dd/yyyy", null);
        if (date4.Subtract(date3).Days < 0)
        {
            ShowAlertMessage("!!!!!التاريخ الأول يجب ان يكون قبل التاريخ الثاني !!!!");
            return;
        }
        //////////////////////////////////////////////////////////// finished check on sign_strt_Date/////////////////////////////////////

        /////////////////////////////////////////////////////// begin check on sign_end_date///////////////////////////////////////////
        if (string.IsNullOrEmpty(prot_end_date_from.Text) && string.IsNullOrEmpty(prot_end_date_to.Text))
        {
            t5 = DateTime.ParseExact("01/01/1900", "MM/dd/yyyy", null).ToString("MM/dd/yyyy");
            t6 = DateTime.MaxValue.ToString("MM/dd/yyyy");
            sql += " AND convert(datetime,Signt_End_DT,103) > = '" + t5.ToString() + "'";
            sql += " AND convert(datetime,Signt_End_DT,103) < = '" + t6.ToString() + "'";
        }
        else if (string.IsNullOrEmpty(prot_end_date_from.Text))
        {
            t5 = DateTime.ParseExact("01/01/1900", "MM/dd/yyyy", null).ToString("MM/dd/yyyy");
            t6 = DateTime.ParseExact(prot_end_date_to.Text, "dd/MM/yyyy", null).ToString("MM/dd/yyyy");

            sql += " AND convert(datetime,Signt_End_DT,103) < = '" + t6.ToString() + "'";
        }
        else if (string.IsNullOrEmpty(prot_end_date_to.Text))
        {
            t5 = DateTime.ParseExact(prot_end_date_from.Text, "dd/MM/yyyy", null).ToString("MM/dd/yyyy");
            t6 = DateTime.MaxValue.ToString("MM/dd/yyyy");

            sql += " AND convert(datetime,Signt_End_DT,103) > = '" + t5.ToString() + "'";
        }
        else
        {
            t5 = DateTime.ParseExact(prot_end_date_from.Text, "dd/MM/yyyy", null).ToString("MM/dd/yyyy");

            t6 = DateTime.ParseExact(prot_end_date_to.Text, "dd/MM/yyyy", null).ToString("MM/dd/yyyy");

            sql += " AND convert(datetime,Signt_End_DT,103) > = '" + t5.ToString() + "'";
            sql += " AND convert(datetime,Signt_End_DT,103) < = '" + t6.ToString() + "'";

        }
        /////////////////////////////////////////////////////////////////// end check on sign_end _date/////////////////////////////////////
        */
        sql += " order by convert(datetime,Signt_Str_DT,103) asc";
        //DateTime date5 = DateTime.ParseExact(t5, "MM/dd/yyyy", null);
        //DateTime date6 = DateTime.ParseExact(t6, "MM/dd/yyyy", null);
        //if (date6.Subtract(date5).Days < 0)
        //{
        //    ShowAlertMessage("!!!!!التاريخ الأول يجب ان يكون قبل التاريخ الثاني !!!!");
        //    return;
        //}


        DataTable dt = General_Helping.GetDataTable(sql);
        if (dt.Rows.Count == 0)
        {
            gvMain.EmptyDataText = ".....عفوا لا يوجد بيانات ......";
        }
        else
        {
            gvMain.DataSource = dt;
        }
        gvMain.DataBind();
        //conn.Close();
    }

    protected void SaveButton_Click(object sender, EventArgs e)
    {
        SearchRecord();
    }

    
    protected void gvMain_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }
    protected void gvMain_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName=="EditItem")
        {
            Response.Redirect("../WebForms2/Protocol_Def.aspx?prot_id=" + e.CommandArgument);
        }
        if (e.CommandName == "RemoveItem")
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            conn.Open();

            sql += "delete from Protocol_Def where Protocol_ID= " + e.CommandArgument;
            cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();

            gvMain.DataBind();
            
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم الحذف بنجاح')</script>");
            SearchRecord();
        }
       
    }
    protected void gvMain_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvMain.PageIndex = e.NewPageIndex;
        SearchRecord();
    }
}
