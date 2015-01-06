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


public partial class testmail : System.Web.UI.Page
{

    //Session_CS Session_CS = new Session_CS();
    private string sql_Connection = Database.ConnectionString;
    // private string sql_Connection = Universal.GetConnectionString();

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            //using (MailMessage mm = new MailMessage("youssefah1@gmail.com", "youssefah1@gmail.com"))
            //{
            //    mm.Subject = "sadas";
                
            //    mm.IsBodyHtml = false;
            //    SmtpClient smtp = new SmtpClient();
            //    smtp.Host = "smtp.gmail.com";
            //    smtp.EnableSsl = true;
            //    NetworkCredential NetworkCred = new NetworkCredential("youssefah1@gmail.com", "letmeknow123");
            //    smtp.UseDefaultCredentials = true;
            //    smtp.Credentials = NetworkCred;
            //    smtp.Port = 587;
            //    smtp.Send(mm);
            //    ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Email sent.');", true);
            //}

            Test_Send_Mail();
            
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
        _Message.Body += "   اختبار ارسال البريد الالكترونى ";
        _Message.Body += "    </h3> ";

       
        _Message.Body += "</body></html>";
        SmtpClient Client = new SmtpClient();
        //Client.Port = Session_CS.Port;
        //Client.Host = Session_CS.Host;
        //string UserName = Session_CS.UserName_mail;
        //string Password = Session_CS.Password;
        //_Message.From = new MailAddress(Session_CS.FromAddress); //"eManagement@luxor.cloud.gov.eg";

        Client.Port = 25;
        Client.Host = "195.43.9.140";
        string UserName = "eri_archiving@eri.sci.eg";
        string Password = "1597530";
        _Message.From = new MailAddress("eri_archiving@eri.sci.eg"); //"eManagement@luxor.cloud.gov.eg";
        System.Net.NetworkCredential SMTPUserInfo = new System.Net.NetworkCredential(UserName, Password);
        Client.UseDefaultCredentials = false;
        Client.Credentials = SMTPUserInfo;
       
        try
        {
            _Message.To.Add(new MailAddress(txt_Mail.Text));


            Client.Send(_Message);
            Response.Write("لقد تم ارسال الايميل بنجاح");

        }
        catch (Exception ex)
        {
            Response.Write(Session_CS.UserName_mail);
            Response.Write(ex.Message);
            //Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لم يتم ارسال الايميل بنجاح')</script>");

        }
        

    }




    protected void Sendmail_Click(object sender, EventArgs e)
    {
        Test_Send_Mail();
    }
}
