using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Data;
using System.Web.Security;
using System.Collections;
using System.Configuration;
using System.Net.Mail;
using System.Text;
using System.IO;
using System.Threading;

/// <summary>
/// Summary description for Inbox_class
/// </summary>
/// 




public class SendingMailthread_class
{
    
    
    //Thread t1;
    public SendingMailthread_class()
    {
        //
        // TODO: Add constructor logic here
        //

    }

    public static void Sendingmail(MailMessage _Message, string subject, string body, string mail, MemoryStream ms, string file, string encrypted_id, string cc_mail)
    {
        Session_CS Session_CS = new Session_CS();
        
        try
        {
            Thread t1;
            string str_subj = "";

            _Message.BodyEncoding = Encoding.UTF8;
            _Message.SubjectEncoding = Encoding.UTF8;
            _Message.IsBodyHtml = true;

            //_Message.Body = body;
            //_Message.Subject = subject;
            SmtpClient Client = new SmtpClient();
            //Client.Port = int.Parse(ConfigurationManager.AppSettings["SMTP_Port"]);
            //Client.Host = ConfigurationManager.AppSettings["SMTP_Host"];
            //string UserName_mail = ConfigurationManager.AppSettings["SMTP_UserName"];
            //string Password = ConfigurationManager.AppSettings["SMTP_Password"];
            //_Message.From = new MailAddress(ConfigurationManager.AppSettings["SMTP_FromAddress"]);

            string UserName_mail = "";
            string Password = "";
            
            if (Session_CS.Host != "" && Session_CS.Port != 0 && Session_CS.UserName_mail != "" && Session_CS.Password != "" && Session_CS.FromAddress != "")
            {
                Client.Host = Session_CS.Host;
                Client.Port = Session_CS.Port;
                UserName_mail = Session_CS.UserName_mail;
                Password = Session_CS.Password;
                _Message.From = new MailAddress(Session_CS.FromAddress);
                System.Net.NetworkCredential SMTPUserInfo = new System.Net.NetworkCredential(UserName_mail, Password);
                Client.UseDefaultCredentials = false;
                Client.Credentials = SMTPUserInfo;
                // Client.Timeout = 1000000000;
                //foreach (string  att in attachments)
                //{
                //    _Message.Attachments.Add(new Attachment(att));
                //}
                //if (ms.Length > 0)
                //    _Message.Attachments.Add(new Attachment(ms, file));
                //foreach (string  mail in mailarray)
                //{.
                if (!string.IsNullOrEmpty(cc_mail) && cc_mail.Trim().Contains("@"))
                {
                    _Message.CC.Add(new MailAddress(cc_mail));
                }
                if (!string.IsNullOrEmpty(mail) && mail.Trim().Contains("@"))
                {
                    _Message.To.Add(new MailAddress(mail));
                    try
                    {

                        t1 = new Thread(delegate() { Client.Send(_Message); });
                        t1.Start();

                        // System.Web.HttpContext.Current.Response.Write("<script language=javascript>alert('تم ارسال الايميل بنجاح ')</script>");



                    }
                    catch (Exception ex)
                    {


                        // System.Web.HttpContext.Current.Response.Write("<script language=javascript>alert('عفوا لم يتم ارسال الايميل ')</script>");

                    }
                }




            }
        }
        catch (Exception ex)
        {



        }





    }




}