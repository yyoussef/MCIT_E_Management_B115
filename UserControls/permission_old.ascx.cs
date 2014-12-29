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
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Globalization;

public partial class UserControls_permission_old : System.Web.UI.UserControl
{
    Session_CS Session_CS = new Session_CS();
    private string sql_Connection = Database.ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            FillGrids();
    }

    private void FillGrids()
    {
        Vocations_permission_DT VacObj = new Vocations_permission_DT();
        DataTable AllVacDT = Vocations_permission_DB.Select_Old(CDataConverter.ConvertToInt(Session_CS.pmp_id));
        requests.DataSource = AllVacDT;
        requests.DataBind();
    }
    protected void BtnVacationRequest_Click(object sender, EventArgs e)
    {
        Response.Redirect("permission_manager.aspx");
    }
    protected void requests_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string str = e.CommandArgument.ToString();
        string[] arr = str.Split(',');
        if (e.CommandName == "EditItem")
        {
            Response.Redirect("permission_request.aspx?edit_type=manage&vacation_id=" + arr[0].ToString());
        }

        if (e.CommandName == "RemoveItem")
        {
            DataTable vac_DT = Vocations_permission_DB.Select_Vac_By_ID(CDataConverter.ConvertToInt(arr[0].ToString()));
            if (vac_DT.Rows.Count > 0)
            {
                if (vac_DT.Rows[0]["manager_approve"].ToString() == "1")
                {
                    int reslt = General_Helping.ExcuteQuery("update Vacations_summary set permission = " + vac_DT.Rows[0]["permission"].ToString() + " WHERE emp_id = " + vac_DT.Rows[0]["user_id"].ToString());
                }
                    
             }

            int result = General_Helping.ExcuteQuery("delete from Vocation_permission where id=" + arr[0].ToString());
            //Send_mail("بالحذف", arr[1].ToString());
        }
        FillGrids();
    }

    private void Send_mail(string Msg, string Pmp_id)
    {
        DataTable Dt_Mng = General_Helping.GetDataTable("Select mail,PMP_ID,pmp_name from EMPLOYEE where PMP_ID = " + Pmp_id);
        string name = "";
        string Succ_names = "", Failed_name = "";
        if (Dt_Mng.Rows.Count > 0)
        {
            string mail = Dt_Mng.Rows[0]["mail"].ToString();
            MailMessage _Message = new MailMessage();

            _Message.Subject = "نظام الادارة الالكترونية - الأذونات";

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
            _Message.Body += " <h3 > بالرد على الإذن المقدم من جانبكم"
                + " <h3 style=color:blue > " + Msg + "</h3>";
            _Message.Body += "<h3 > مع تحيات </h3> ";
            _Message.Body += "<h3 >   " + Session_CS.e_signature.ToString() + "  </h3> ";
            _Message.Body += "</body></html>";
         

            try
            {
               
                SendingMailthread_class.Sendingmail(_Message,_Message.Subject, _Message.Body, mail, ms, file, encrypted_id, "");

                Succ_names += name + ",";

            }
            catch (Exception ex)
            {
                Failed_name += name + ",";
            }

        }
    }
}
