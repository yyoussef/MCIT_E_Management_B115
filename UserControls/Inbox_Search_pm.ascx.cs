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

using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using System.Security.Cryptography;
using System.Drawing;
using ReportsClass;

public partial class UserControls_Inbox_Search_pm : System.Web.UI.UserControl
{
    string sql;
    SqlConnection conn;
    SqlDataAdapter da;
    DataSet ds;
    SqlCommand cmd;
    private string sql_Connection = Database.ConnectionString;
    General_Helping Obj_General_Helping = new General_Helping(); //Session_CS Session_CS = new Session_CS();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {

        }
    }





    protected void gvMain_DataBound(object sender, EventArgs e)
    {
      
        for (int i = 0; i <= gvMain.Rows.Count - 1; i++)
        {
            Label lblparent = (Label)gvMain.Rows[i].FindControl("Label1");

            if (lblparent.Text == "متأخر")
            {
                
                //gvMain.Rows[i].BackColor = Color.DarkRed;
                gvMain.Rows[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#FF3030");
            }
        }

       
           
    }
    //public static string Encrypt(string pstrText)
    //{
    //    string pstrEncrKey = "1239;[pewGKG)NisarFidesTech";
    //    byte[] byKey = { };
    //    byte[] IV = { 18, 52, 86, 120, 144, 171, 205, 239 };
    //    byKey = System.Text.Encoding.UTF8.GetBytes(pstrEncrKey.Substring(0, 8));
    //    DESCryptoServiceProvider des = new DESCryptoServiceProvider();
    //    byte[] inputByteArray = Encoding.UTF8.GetBytes(pstrText);
    //    MemoryStream ms = new MemoryStream();
    //    CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(byKey, IV), CryptoStreamMode.Write);
    //    cs.Write(inputByteArray, 0, inputByteArray.Length);
    //    cs.FlushFinalBlock();
    //    return Convert.ToBase64String(ms.ToArray());
    //}


    protected override void OnInit(EventArgs e)
    {
        string Query = "";
        int found_id = CDataConverter.ConvertToInt(Session_CS.foundation_id.ToString());
        Smrt_Srch_org.sql_Connection = sql_Connection;
        //Smrt_Srch_org.Query = "select Org_ID,Org_Desc from Organization where foundation_id = " + found_id;
        Query = "select Org_ID,Org_Desc from Organization where foundation_id = " + found_id;
        Smrt_Srch_org.datatble = General_Helping.GetDataTable(Query);
        Smrt_Srch_org.Value_Field = "Org_ID";
        Smrt_Srch_org.Text_Field = "Org_Desc";
        Smrt_Srch_org.DataBind();










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




        SqlParameter[] parms = new SqlParameter[4];

        // t1 = DateTime.ParseExact(DateTime.Now.AddDays(1).ToString("dd/MM/yyyy"), "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
         t1 = CDataConverter.ConvertDateTimeNowRtnDt().AddDays(1).ToString();
        parms[0] = new SqlParameter("@Org_id", CDataConverter.ConvertToInt(Smrt_Srch_org.SelectedValue));


        parms[1] = new SqlParameter("@DateNowplus1", t1);

        parms[2] = new SqlParameter("@found_id", Session_CS.foundation_id);

        parms[3] = new SqlParameter("@group_id", Session_CS.group_id);








        DataTable dt = new DataTable();
        dt = DatabaseFunctions.SelectDataByParam(parms, "all_archiving_status_prime_minister");

        ViewState["dt_report"] = dt;


        if (dt.Rows.Count == 0)
        {
            gvMain.EmptyDataText = ".....عفوا لا يوجد بيانات ......";
        }
        else
        {
            gvMain.DataSource = dt;
           // btnReport.Visible = true;
        }

        gvMain.DataBind();

    }

    protected void SaveButton_Click(object sender, EventArgs e)
    {
        if (Smrt_Srch_org.SelectedValue != "")
        {
            SearchRecord();

        }
        else
        {
            ShowAlertMessage("يجب اختيار الجهة ");
            return;
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
    protected void btnReport_Click(object sender, EventArgs e)
    {
        if (Smrt_Srch_org.SelectedValue != "")
        {
            SqlParameter[] parms = new SqlParameter[3];
          //  string t1 = DateTime.ParseExact(DateTime.Now.AddDays(1).ToString("dd/MM/yyyy"), "dd/MM/yyyy", null).ToString("dd/MM/yyyy");

            string t1 = CDataConverter.ConvertDateTimeNowRtnDt().AddDays(1).ToString();
            parms[0] = new SqlParameter("@Org_id", CDataConverter.ConvertToInt(Smrt_Srch_org.SelectedValue));
            parms[1] = new SqlParameter("@DateNowplus1", t1);
            parms[2] = new SqlParameter("@found_id", Session_CS.foundation_id);
            DataTable dt = new DataTable();
            dt = DatabaseFunctions.SelectDataByParam(parms, "all_archiving_status_prime_minister");
            string user = Session_CS.pmp_name.ToString();
            ReportDocument rd = new ReportDocument();
            string s = Server.MapPath("../Reports/Archiving_Report_Prime_Minister.rpt");
            rd.Load(s);
            rd.SetDataSource(dt);
            Reports.Load_Report(rd);
            rd.SetParameterValue("@org_desc", Smrt_Srch_org.SelectedText);
            rd.SetParameterValue("@Date", CDataConverter.ConvertDateTimeToFormatdmy(CDataConverter.ConvertDateTimeNowRtnDt()));
            rd.SetParameterValue("@found_id", Session_CS.foundation_id, "Logo_Header_pic_dynamic.rpt");
            rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
            rd.SetParameterValue("@user", user, "footerRep.rpt");
            if (dt.Rows.Count == 0)
            {
                ShowAlertMessage("هذا التقرير لا يوجد به بيانات للعرض !!!!");
                return;
            }
            else
                rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report");

        }
        else
        {
            ShowAlertMessage("يجب اختيار الجهة ");
            return;
        }
       




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
        if (e.CommandName == "EditItem")
        {
            string encrypted = Encryption.Encrypt(e.CommandArgument.ToString());
            //Session["encrypted"] = encrypted;
            DataTable dtissec = General_Helping.GetDataTable("select * from inbox where id = " + e.CommandArgument + "and pmp_pmp_id = " + pmp + "or group_id = " + CDataConverter.ConvertToInt(Session_CS.group_id.ToString()));
            if (dt.Rows.Count > 0)
            {

                if (dtissec.Rows.Count > 0)
                {
                    ///////// ده لو هو سكرتير وهو اللي دخل الوارد ده 
                    Response.Redirect("Project_Inbox.aspx?id=" + encrypted);
                }
                else
                    Response.Redirect("ViewProjectInbox.aspx?id=" + encrypted); ////ده لو هو سكرتير بس مش هو اللي دخل الوارد
            }
            else if (dtissec.Rows[0]["pmp_pmp_id"].ToString() == Session_CS.pmp_id.ToString())
            {
                Response.Redirect("Project_Inbox.aspx?id=" + encrypted); // ده لو موظف عادي هو اللي دخل الوارد
            }
            else
                Response.Redirect("ViewProjectInbox.aspx?id=" + encrypted);///  لو مش سكرتير 
        }


    }
    protected void gvMain_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvMain.PageIndex = e.NewPageIndex;
        SearchRecord();
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        // SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        //sql = "SELECT dbo.Inbox.Date, dbo.Inbox.Code, dbo.Inbox.Org_Out_Box_DT, dbo.Inbox.Org_Out_Box_Code, dbo.Organization.Org_Desc, dbo.Inbox.Subject, dbo.Inbox.Paper_No,";
        //sql+=" dbo.Inbox_Visa.Visa_date, dbo.Inbox_Visa.Important_Degree, dbo.Departments.Dept_name, dbo.Inbox_Visa.Visa_Desc, dbo.Inbox_Visa.Visa_Period,";
        //sql += " dbo.Inbox_Visa.Follow_Up_Emp_ID, dbo.EMPLOYEE.pmp_name, dbo.Inbox_Visa.Emp_ID, EMPLOYEE_1.pmp_name AS exc_person";
        //sql+=" FROM dbo.EMPLOYEE INNER JOIN";
        //sql+=" dbo.Departments ON dbo.EMPLOYEE.Dept_Dept_id = dbo.Departments.Dept_ID INNER JOIN";
        //sql+=" dbo.EMPLOYEE AS EMPLOYEE_1 ON dbo.Departments.Dept_ID = EMPLOYEE_1.Dept_Dept_id RIGHT OUTER JOIN";
        //sql+=" dbo.Inbox_Visa ON EMPLOYEE_1.PMP_ID = dbo.Inbox_Visa.Emp_ID AND dbo.EMPLOYEE.PMP_ID = dbo.Inbox_Visa.Follow_Up_Emp_ID AND ";
        //sql+=" dbo.Departments.Dept_ID = dbo.Inbox_Visa.Dept_ID FULL OUTER JOIN";
        //sql+=" dbo.Organization RIGHT OUTER JOIN";
        //sql+=" dbo.Inbox ON dbo.Organization.Org_ID = dbo.Inbox.Org_Id ON dbo.Departments.Dept_ID = dbo.Inbox.Dept_ID AND dbo.Inbox_Visa.Inbox_ID = dbo.Inbox.ID";

        //SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        //DataTable dt = new DataTable();
        //da.Fill(dt);



        //ReportDocument rd = new ReportDocument();
        //string s = Server.MapPath("../Reports/Follow_Up_Inbox_Outbox.rpt");
        //rd.Load(s);
        //rd.SetDataSource(dt);
        //Load_Report(rd);

        ////rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
        ////rd.SetParameterValue("@user", user, "footerRep.rpt");
        //if (rd.Rows.Count == 0)
        //{
        //    ShowAlertMessage("هذا التقرير لا يوجد به بيانات للعرض !!!!");
        //    return;
        //}
        //else
        //{


        //    rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.Excel, Response, true, "Report");
        //}
    }
    public string Get_Type(object obj)
    {
        string str = obj.ToString();
        if (str == "1")
            return "وارد";

        else return "صادر";
    }
    public string Get_Type_status(object obj)
    {
        string str = obj.ToString();
        if (str == "0")
            return "جاري";
        else if (str == "1")
            return "جديد";
        else if (str == "2")
            return "تحت الدراسة";
        else if (str == "3")
            return "مغلق";

        else return "متأخر";
    }

}
