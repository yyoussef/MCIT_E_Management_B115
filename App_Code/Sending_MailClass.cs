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
using System.Net.Mail;

/// <summary>
/// Summary description for Inbox_class
/// </summary>
public class Sending_MailClass
{
    public Sending_MailClass()
    {
        //
        // TODO: Add constructor logic here
        //

    }

    public static void sendmail(string bodymsg, string pmp_name)
    {
        string str_subj = "";
        MailMessage _Message = new MailMessage();
        //if (rol == 2)
        //{
        //     str_subj = " رد علي مقترح مشروع";
        //}
        //else
        //{
             str_subj = "مقترح مشروع";
        //}


       

        //string str_witoutn = str_subj.Replace("\n", "");
        //str_subj = str_witoutn.Replace("\r", "");
             _Message.Subject = "نظام الادارة الالكترونية " + " - " + str_subj + " - " + CDataConverter.ConvertDateTimeNowRtnDt();


        //_Message.BodyEncoding = Encoding.Unicode;
        _Message.BodyEncoding = Encoding.UTF8;
        _Message.SubjectEncoding = Encoding.UTF8;

        //_Message.To.Add(new MailAddress(mail));



        _Message.IsBodyHtml = true;
        _Message.Body = "<html><body dir='rtl'><h3 >";
        _Message.Body += "  السيد";
        _Message.Body += " " + "الادارة العليا" + "    </h3> ";


        _Message.Body += " <h3 > " + " وصلكم مقترح مشروع من " + pmp_name + " بتاريخ " + CDataConverter.ConvertDateTimeNowRtnDt() + " بخصوص <br/>" + "<h3 style=" + "color:blue >" + bodymsg + "</h3>";
        bool flag = false;


        string address2 = System.Web.HttpContext.Current.Request.Url.Authority.ToString();
        //_Message.Body += " <h3 > ورابط الوارد هو  :<br/>";
        //_Message.Body += " <h3 >http:" + "/" + "/" + address2 + "/MainForm/ViewProjectInbox.aspx?id=" + hidden_Id.Value + " </h3>";

        //if (flag)
        //    _Message.Body += "<h3 >   ومرفق الوثائق الخاصة بهذا الوارد</h3> <br /><br />";


        //_Message.Body += "<h3 > مع تحيات </h3> ";
        //_Message.Body += "<h3 >   " + Session_CS.e_signature.ToString() + "  </h3> ";
        //_Message.Body += "</body></html>";
        ////SmtpClient config
        SmtpClient Client = new SmtpClient();
        Client.Port = int.Parse(ConfigurationManager.AppSettings["SMTP_Port"]);
        Client.Host = ConfigurationManager.AppSettings["SMTP_Host"];
        string UserName = ConfigurationManager.AppSettings["SMTP_UserName"];
        string Password = ConfigurationManager.AppSettings["SMTP_Password"];
        _Message.From = new MailAddress(ConfigurationManager.AppSettings["SMTP_FromAddress"]);

        //_Message.Attachments.Add(new Attachment("D:\\Attached.pdf"));
        System.Net.NetworkCredential SMTPUserInfo = new System.Net.NetworkCredential(UserName, Password);

        Client.UseDefaultCredentials = false;
        Client.Credentials = SMTPUserInfo;
        Client.Timeout = 1000000000;

        //try
        //{
        string mail = ConfigurationManager.AppSettings["ProjectNotification_highManagment"];
        string[] mailarray = mail.Split('=');
        //string mail2 = ConfigurationManager.AppSettings["ProjectNotification_highManagment1"];

        for (int i = 0; i < mailarray.Length; i++)
        {
            _Message.To.Add(new MailAddress(mailarray[i]));
            
        }
        Client.Send(_Message);
        //_Message.To.Add(new MailAddress(mail));
        //Client.Send(_Message);
        //_Message.To.Add(new MailAddress(mail2));



        // }
        //catch (Exception ex)
        //{

        //    Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لم يتم ارسال الايميل بنجاح')</script>");

        //}
        //Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم ارسال الايميل بنجاح')</script>");




    }

}