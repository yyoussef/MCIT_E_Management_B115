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
//using CrystalDecisions.CrystalReports.Engine;
//using CrystalDecisions.Shared;
using System.Globalization;
//using ReportsClass;


public partial class testlist : System.Web.UI.Page
{
    string main_sql, sql_act, sql_arc, sql_arc_late;
    const string Mona = "mdarwish@mcit.gov.eg";
    const string youssef = "eManagement@luxor.cloud.gov.eg";
    const string asalaheldin = "asalaheldin@mcit.gov.eg";
    const string rabdelghafar = "rabdelghafar@mcit.gov.eg";
    const string Sbeih = "Sbeih@mcit.gov.eg";

    private string sql_Connection = Database.ConnectionString;
    // private string sql_Connection = Universal.GetConnectionString();

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            string sq = "select * from employee";
            DataTable dt = General_Helping.GetDataTable(sq);

            //foreach (Control c in this.Controls)
            //{
            //    if (c is ListView)
            //    {
            //        ListView mylist = (ListView)c;
            //        mylist.DataSource = dt;
            //    }


            //}
            LoopTextBoxes(Page);

            //ListView1.DataSource = dt;
            //ListView1.DataBind();
            //fun_act();

            //fun_archiving_inbox();
            //fun_archiving_Outbox();
            //fun_archiving_Com();
            //fun_finance();

            //Update_Employee_permission();

            // fun_needs();

        }


    }
    private void LoopTextBoxes(Control parent)
    {
        string sq = "select * from employee";
        DataTable dt = General_Helping.GetDataTable(sq);
        ControlCollection collection = Page.Form.Controls;
        foreach (Control c in collection)
        {
            ListView tb = c as ListView;
            if (tb != null)
                tb.DataSource = dt;
        }
    }
    protected void ListView1_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        Label lblname = (Label)e.Item.FindControl("lblname");
        //lblname.Text = "asasasasas";

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

    private void Test_Send_Mail()
    {
        MailMessage _Message = new MailMessage();
        _Message.Subject = "نظام الادارة الالكترونية - المراسلات";
        //_Message.BodyEncoding = Encoding.Unicode;
        _Message.BodyEncoding = Encoding.UTF8;
        _Message.SubjectEncoding = Encoding.UTF8;




        string address2 = System.Web.HttpContext.Current.Request.Url.Authority.ToString();



        _Message.IsBodyHtml = true;

        _Message.Body = "<html><body dir='rtl'><h3 >";
        _Message.Body += "    السيد المهندس ";
        _Message.Body += "    </h3> ";

        _Message.Body += " <h3 > " + "  وصلكم وارد من قطاع البنية المعلوماتية " + " بتاريخ " + CDataConverter.ConvertDateTimeNowRtnDt() + "  بخصوص التعديلات في الخطط الزمنية في المشروعات <br/>" + "<h3 style=" + "color:blue >" + "</h3>";
        _Message.Body += "<h3 >   ومرفق الوثيقة الخاصة بهذه التعديلات</h3> <br /><br />";
        _Message.Body += "<h3 > مع تحيات </h3> ";
        _Message.Body += "<h3 >   " + "IT" + "  </h3> ";

        _Message.Body += " <h3 >http:" + "/" + "/" + address2 + "/MainForm/View_Commission.aspx?id=" + 40 + "&1=1</h3>";

        _Message.Body += "</body></html>";
        SmtpClient Client = new SmtpClient();
        Client.Port = 587;
        Client.Host = "smtp.linkdatacenter.net";
        string UserName = "eManagement@luxor.cloud.gov.eg";
        string Password = "P@ssw0rd";
        _Message.From = new MailAddress("eManagement@luxor.cloud.gov.eg"); //"eManagement@luxor.cloud.gov.eg";
        System.Net.NetworkCredential SMTPUserInfo = new System.Net.NetworkCredential(UserName, Password);
        Client.UseDefaultCredentials = false;
        Client.Credentials = SMTPUserInfo;
        // Client.Timeout = 1000000000;
        //try
        //{
        _Message.To.Add(new MailAddress(youssef));


        Client.Send(_Message);

        //}
        //catch (Exception ex)
        //{
        //    Response.Write("لم يتم ارسال الايميل بنجاح");
        //    //Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لم يتم ارسال الايميل بنجاح')</script>");

        //}
        //Response.Write("لقد تم ارسال الايميل بنجاح");

    }




    protected void Sendmail_Click(object sender, EventArgs e)
    {
        //  Test_Send_Mail();
    }
}
