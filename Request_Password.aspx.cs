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

public partial class Request_Password : System.Web.UI.Page
{
    Session_CS Session_CS = new Session_CS();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        User_Email();
       // Test_User_Email();
        

    }

    private void User_Email()
    {
        DataTable dt = SqlHelper.ExecuteDataset(Database.ConnectionString, "Users_Select_by_Email", Txt_Email.Text).Tables[0];
        if (dt.Rows.Count > 0)
        {
            DataRow dr = dt.Rows[0];
            string mail = dr["mail"].ToString();
            MailMessage _Message = new MailMessage();

            _Message.Subject = "نظام الادارة الالكترونية - المراسلات";


            //_Message.BodyEncoding = Encoding.Unicode;
            _Message.BodyEncoding = Encoding.UTF8;
            _Message.SubjectEncoding = Encoding.UTF8;




            _Message.IsBodyHtml = true;
            _Message.Body = "<html><body dir='rtl'><h3 >  السيد /  " + dr["pmp_name"].ToString() + "    </h3> ";

            _Message.Body += " <h3  >  وصلكم وارد من نظام إدارة مشروعات قطاع البنية المعلوماتية </h3>";
            _Message.Body += " <h3 >  بيانات الدخول </h3>";

            _Message.Body += "<h3 >  اسم المستخدم : " + dr["USR_Name"].ToString() + "    </h3> ";
            _Message.Body += "<h3 >  كلمة المرور  : " + dr["USR_Pass"].ToString() + "    </h3> ";
            _Message.Body += "<h3 > مع تحيات </h3> ";
            _Message.Body += "<h3 >   " + Session_CS.e_signature.ToString() + "  </h3> ";
            _Message.Body += "</body></html>";
            string file = "";
            byte[] files = new byte[0];
            MemoryStream ms = new MemoryStream();
            String encrypted_id = "";
            //SmtpClient Client = new SmtpClient();
            //Client.Port = int.Parse(ConfigurationManager.AppSettings["SMTP_Port"]);
            //Client.Host = ConfigurationManager.AppSettings["SMTP_Host"];
            //string UserName = ConfigurationManager.AppSettings["SMTP_UserName"];
            //string Password = ConfigurationManager.AppSettings["SMTP_Password"];
            //_Message.From = new MailAddress(ConfigurationManager.AppSettings["SMTP_FromAddress"]);

            //System.Net.NetworkCredential SMTPUserInfo = new System.Net.NetworkCredential(UserName, Password);
            //Client.UseDefaultCredentials = false;
            //Client.Credentials = SMTPUserInfo;
            //Client.Timeout = 1000000000;

            try
            {
                //_Message.To.Add(new MailAddress(dr["mail"].ToString()));
                SendingMailthread_class.Sendingmail(_Message,_Message.Subject, _Message.Body, mail, ms, file, encrypted_id, "");
                //Client.Send(_Message);

            }
            catch (Exception ex)
            {

                //Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لم يتم ارسال الايميل بنجاح')</script>");

            }

            //Page.RegisterStartupScript("Sucess", "<script language=javascript>alert(' تم ارسال ايميل ببيانات الدخول الخاصة بك يرجى التأكد من الميل الخاص بك');window.location.href = 'default.aspx';</script>");
        }
        else
        {
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert(' هذا الإيميل غير مسجل فى النظام يرجى الاتصال بإدارة النظام لمراجعة بياناتك')</script>");

        }
    }

    private void Test_User_Email()
    {
       
            MailMessage _Message = new MailMessage();

            _Message.Subject = "نظام الادارة الالكترونية - المراسلات";


        //    _Message.BodyEncoding = Encoding.Unicode;
            _Message.BodyEncoding = Encoding.UTF8;
            _Message.SubjectEncoding = Encoding.UTF8;



            string file = "";
            byte[] files = new byte[0];
            MemoryStream ms = new MemoryStream();
            String encrypted_id = "";

            _Message.IsBodyHtml = true;
            _Message.Body = "<html><body dir='rtl'><h3 >  السيد /     </h3> ";

            _Message.Body += " <h3  >  وصلكم وارد من نظام إدارة مشروعات قطاع البنية المعلوماتية </h3>";
            _Message.Body += " <h3 >  بيانات الدخول </h3>";

            _Message.Body += "<h3 >  اسم المستخدم :   </h3> ";
            _Message.Body += "<h3 >  كلمة المرور  : </h3> ";
            _Message.Body += "<h3 > مع تحيات </h3> ";
            _Message.Body += "<h3 >   " + Session_CS.e_signature.ToString() + "  </h3> ";
            _Message.Body += "</body></html>";
            //SmtpClient Client = new SmtpClient();
            //Client.Port = int.Parse(ConfigurationManager.AppSettings["SMTP_Port"]);
            //Client.Host = ConfigurationManager.AppSettings["SMTP_Host"];
            //string UserName = ConfigurationManager.AppSettings["SMTP_UserName"];
            //string Password = ConfigurationManager.AppSettings["SMTP_Password"];
            //_Message.From = new MailAddress(ConfigurationManager.AppSettings["SMTP_FromAddress"]);

            //System.Net.NetworkCredential SMTPUserInfo = new System.Net.NetworkCredential(UserName, Password);
            //Client.UseDefaultCredentials = false;
            //Client.Credentials = SMTPUserInfo;
            //Client.Timeout = 1000000000;

            try
            {
                //_Message.To.Add(new MailAddress(Txt_Email.Text));
                SendingMailthread_class.Sendingmail(_Message,_Message.Subject, _Message.Body, Txt_Email.Text, ms, file, encrypted_id, "");
                //Client.Send(_Message);

            }
            catch (Exception ex)
            {

               // Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لم يتم ارسال الايميل بنجاح' )</script>");

            }

            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert(' تم ارسال ايميل ببيانات الدخول الخاصة بك يرجى التأكد من الميل الخاص بك');window.location.href = 'default.aspx';</script>");
        //}
        //else
        //{
        //    Page.RegisterStartupScript("Sucess", "<script language=javascript>alert(' هذا الإيميل غير مسجل فى النظام يرجى الاتصال بإدارة النظام لمراجعة بياناتك')</script>");

        //}
    }

}
