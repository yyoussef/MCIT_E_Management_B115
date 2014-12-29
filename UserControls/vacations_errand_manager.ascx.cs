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
using System.Data.SqlClient;
using System.Net.Mail;
using System.Text;
using System.IO;
public partial class UserControls_vacations_errand_manager : System.Web.UI.UserControl
{
    Session_CS Session_CS = new Session_CS();
    private string sql_Connection = Database.ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillGrids();
            if (requests.Rows.Count > 0)
                Btn_AccRej.Visible = true;
            else
                Btn_AccRej.Visible = false;
        }
    }

    private void FillGrids()
    {
        Vacations_errand_DT VacObj = new Vacations_errand_DT();
        DataTable AllVacDT = Vacations_errand_DB.Select_by_dept(CDataConverter.ConvertToInt(Session_CS.pmp_id));

        requests.DataSource = AllVacDT;
        requests.DataBind();
    }
    protected void BtnVacationRequest_Click(object sender, EventArgs e)
    {
        Response.Redirect("vacation_errand_request.aspx");
    }
    protected void requests_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        

    }
    protected void BtnVacationOld_Click(object sender, EventArgs e)
    {
        Response.Redirect("vacations_errand_old.aspx");
    }

    public void Vacations_errand(int id, int user_id)
    {
        //int Days_no;

        Vacations_errand_DT VacObj = new Vacations_errand_DT();
        DataTable AllVacDT = Vacations_errand_DB.GetVacations_errandByID(id);
        int no_days = int.Parse(AllVacDT.Rows[0]["no_days"].ToString());
        int manager_approve = int.Parse(AllVacDT.Rows[0]["manager_approve"].ToString());
        bool day_off = bool.Parse(AllVacDT.Rows[0]["day_off"].ToString());
        if (manager_approve == 1 & day_off == true)
        {
            //General_Helping.GetDataTable("select * from Vacations_summary where emp_id= " + user_id);
            General_Helping.ExcuteQuery("update Vacations_summary set day_off_no= ISNULL(day_off_no, 0) +" + no_days + " where emp_id=" + user_id);


        }


    }
   

    protected void Btn_AccRej_Click(object sender, EventArgs e)
    {
        string status = "3";//Status indicating the value of the radio button

        foreach (GridViewRow row in this.requests.Rows)
        {
            RadioButtonList rb = (RadioButtonList)row.FindControl("AcceptRefuseRBList");
            int grop = CDataConverter.ConvertToInt(Session_CS.group_id.ToString());
            //Set the value of status
            if (!string.IsNullOrEmpty(rb.SelectedValue))
            {
                status = rb.SelectedValue;

                TextBox txt_Data = (TextBox)row.FindControl("txt_Data");

                TextBox txt_start = (TextBox)row.FindControl("txt_start");
                TextBox txt_end = (TextBox)row.FindControl("txt_end");
                TextBox txt_loc = (TextBox)row.FindControl("txt_loc");
                TextBox txt_start_hour = (TextBox)row.FindControl("txt_start_hour");
                TextBox txt_end_hour = (TextBox)row.FindControl("txt_end_hour");

                string str = txt_Data.Text.ToString();

                string[] arr = str.Split(',');
                int pmpID = CDataConverter.ConvertToInt(arr[1].ToString());
                if (status == "1")//Accepted
                {

                    SqlDataAdapter sqladptr = new SqlDataAdapter();
                    SqlConnection con = new SqlConnection(sql_Connection);
                    SqlCommand obj = new SqlCommand("Add_Edit_Vacation_Errand_User", con);
                    obj.CommandType = CommandType.StoredProcedure;
                    obj.Parameters.Add(new SqlParameter("@id", arr[0].ToString()));
                    obj.Parameters.Add(new SqlParameter("@manager_approve", "1"));
                    con.Open();
                    sqladptr.SelectCommand = obj;
                    obj.ExecuteNonQuery();
                    Vacations_errand(CDataConverter.ConvertToInt(arr[0].ToString()), CDataConverter.ConvertToInt(arr[1].ToString()));
                    con.Close();

                   
                    //Send email to the employee to tell him that his/her errand is accepted and cc vacation responsible
                  

                    Send_mail(" بالموافقة", pmpID.ToString(), txt_start.Text, txt_end.Text,txt_loc.Text,txt_start_hour.Text,txt_end_hour.Text  );
                }

                else if (status == "2")//Rejected
                {
                    SqlDataAdapter sqladptr = new SqlDataAdapter();
                    SqlConnection con = new SqlConnection(sql_Connection);
                    SqlCommand obj = new SqlCommand("Add_Edit_Vacation_Errand_User", con);
                    obj.CommandType = CommandType.StoredProcedure;
                    obj.Parameters.Add(new SqlParameter("@id", arr[0].ToString()));
                    obj.Parameters.Add(new SqlParameter("@manager_approve", "2"));
                    con.Open();
                    sqladptr.SelectCommand = obj;
                    obj.ExecuteNonQuery();
                    con.Close();
                    //Send email to the employee to tell him that his/her errand is rejected and cc vacation responsible
                    Send_mail(" بالرفض", pmpID.ToString(), txt_start.Text, txt_end.Text, txt_loc.Text, txt_start_hour.Text, txt_end_hour.Text);

                }
            }
        }
        FillGrids();
        if (requests.Rows.Count > 0)
            Btn_AccRej.Visible = true;
        else
            Btn_AccRej.Visible = false;

    }
    private void Send_mail(string Msg, string Pmp_id, string str_date, string end_date,string location,string start_hour,string end_hour)
    {
        DataTable Dt_Mng = General_Helping.GetDataTable("Select mail,PMP_ID,pmp_name from EMPLOYEE where PMP_ID = " + Pmp_id);
        DataTable dt_vacresponsible = Vacations_View_class.Sector_Vacation_Resposible(CDataConverter.ConvertToInt(Session_CS.sec_id),CDataConverter.ConvertToInt(Session_CS.foundation_id));

        string name = "";
        string Succ_names = "", Failed_name = "";
        string mail = "";
        string vacresponsible_mail = "";
        if (Dt_Mng.Rows.Count > 0 && dt_vacresponsible.Rows.Count > 0)
        {
             mail = Dt_Mng.Rows[0]["mail"].ToString();

             vacresponsible_mail = dt_vacresponsible.Rows[0]["mail"].ToString();


            MailMessage _Message = new MailMessage();

            _Message.Subject = "نظام الادارة الالكترونية - المأموريات";


            //_Message.BodyEncoding = Encoding.Unicode;
            _Message.BodyEncoding = Encoding.UTF8;
            _Message.SubjectEncoding = Encoding.UTF8;


            string address2 = "0";
            String encrypted_id = "0";
            string file = "";
            MemoryStream ms = new MemoryStream();
           // _Message.IsBodyHtml = true;
            _Message.Body = "<html><body dir='rtl'><h3 >";
            _Message.Body += " السيد  ";
            _Message.Body += Dt_Mng.Rows[0]["pmp_name"] + " </h3> ";
            _Message.Body += "<h3 >قام السيد " + Session_CS.pmp_name + " </h3> ";
            _Message.Body += " <h3 > بالرد على المأمورية المقدمة من جانبكم";

            _Message.Body += "<h3 >خلال الفترة من : " + str_date + " </h3> ";
            _Message.Body += "<h3 >  إلي  : " + end_date + " </h3> ";
            _Message.Body += "<h3 >  جهة المأمورية  : " + location  + " </h3> ";

            _Message.Body += "<h3 > من الساعة : " + start_hour + " </h3> ";
            _Message.Body += "<h3 >  إلي الساعة  : " + end_hour + " </h3> ";

            _Message.Body += " <h3 style=color:blue > " + Msg + "</h3>";
            _Message.Body += "<h3 > مع تحيات </h3> ";
            _Message.Body += "<h3 >   " + Session_CS.e_signature.ToString() + "  </h3> ";
            _Message.Body += "</body></html>";
            SmtpClient Client = new SmtpClient();
            //Client.Port = int.Parse(ConfigurationManager.AppSettings["SMTP_Port"]);
            //Client.Host = ConfigurationManager.AppSettings["SMTP_Host"];
            //string UserName = ConfigurationManager.AppSettings["SMTP_UserName"];
            //string Password = ConfigurationManager.AppSettings["SMTP_Password"];
            //_Message.From = new MailAddress(ConfigurationManager.AppSettings["SMTP_FromAddress"]);
            Client.Host = Session_CS.Host;
            Client.Port = Session_CS.Port;
            string UserName_mail = Session_CS.UserName_mail;
            //int Password= Session_CS.Password;
            string Password = Session_CS.Password;
            _Message.From = new MailAddress(Session_CS.FromAddress);
            //_Message.Attachments.Add(new Attachment("D:\\Attached.pdf"));
            System.Net.NetworkCredential SMTPUserInfo = new System.Net.NetworkCredential(UserName_mail, Password);

            Client.UseDefaultCredentials = false;
            Client.Credentials = SMTPUserInfo;
            Client.Timeout = 1000000000;

            try
            {
                _Message.To.Add(new MailAddress(mail));
                _Message.CC.Add(new MailAddress(vacresponsible_mail));
              //  Client.Send(_Message);
                SendingMailthread_class.Sendingmail(_Message,_Message.Subject, _Message.Body, mail, ms, file, encrypted_id, vacresponsible_mail);

                Succ_names += name + ",";
            }
            catch (Exception ex)
            {
                Failed_name += name + ",";
            }

        }
    }



    protected void gvMain_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        requests.PageIndex = e.NewPageIndex;
        FillGrids();


    }


}
