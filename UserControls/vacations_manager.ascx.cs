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
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;
using CrystalDecisions.Shared;
using System.Threading;
using System.ComponentModel;
using System.IO;

public partial class UserControls_vacations_manager : System.Web.UI.UserControl
{
    //Session_CS Session_CS = new Session_CS();
    SqlConnection conn;
    private string sql_Connection = Database.ConnectionString;
    Thread t1;
    
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {



            FillGrids();
            if (requests.Rows.Count > 0)
                Btn_Accept.Visible = true;
            else
                Btn_Accept.Visible = false;
        }
    }
   
    private void FillGrids()
    {
        if (Request.QueryString["type"] == "0")
        {
            requests.Visible = true;
            Vacations_DT VacObj = new Vacations_DT();
            DataTable AllVacDT = Vacations_View_class.new_vacations_requests(CDataConverter.ConvertToInt(Session_CS.pmp_id));
            requests.Visible = true;
            requests.DataSource = AllVacDT;
            requests.DataBind();
        }
        //requests_urgent 
        else if (Request.QueryString["type"] == "1")
        {
            trOldVac.Visible = true;
            requests.Visible = false;
            DataTable AllVacErgDT = new DataTable();
            //if (Session_CS.pmp_id.ToString() == "57")
            //{

            //    AllVacErgDT = Vacations_View_class.new_vacations_requests_dept(0);

            //}
            //else
            //{
            AllVacErgDT = Vacations_View_class.new_vacations_requests_dept(CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()));
            //requests.Columns[6].Visible = requests.Columns[7].Visible = false;
            // }


            requests.Visible = true;
            requests.DataSource = AllVacErgDT;
            requests.DataBind();
        }

    }

    protected void BtnVacationRequest_Click(object sender, EventArgs e)
    {
        Response.Redirect("vacation_request.aspx");
    }
    protected void BtnVacationOld_Click(object sender, EventArgs e)
    {
        Response.Redirect("vacations_old.aspx");

    }

    protected void requests_RowCommand(object sender, GridViewCommandEventArgs e)
    {
     
    }
    /// VOCATIONS URGENT ///

    private void GetReport(ArrayList arrlist)
    {



        conn = new SqlConnection(sql_Connection);
        string s = "";
        string sql = "SELECT  dbo.EMPLOYEE.pmp_name, dbo.EMPLOYEE.Dept_Dept_id, dbo.EMPLOYEE.pmp_title,dbo.Vacations_users.vacation_id , dbo.Vacations_summary.id, dbo.Vacations_users.type, ";
        sql += "   dbo.Vacations_users.manager_approve, dbo.Vacations_summary.emp_id,alternative_user_id, dbo.Vacations_summary.unusual, dbo.Vacations_summary.exhibitor, ";
        sql += "   dbo.Vacations_summary.sick, dbo.Vacations_summary.hajj, dbo.Vacations_summary.birth, dbo.Vacations_summary.year, ";
        sql += "    dbo.Vacations_summary.repeat,Vacations_summary.unusual_total,Vacations_summary.exhibitor_total, dbo.Vacations_users.no_days, dbo.Departments.Dept_name, dbo.Vacations_users.start_date,";
        sql += "     dbo.Vacations_users.end_date, dbo.Vacations_users.user_id, dbo.EMPLOYEE.status, ";
        sql += "  (SELECT  pmp_name FROM  dbo.EMPLOYEE WHERE (PMP_ID = dbo.Vacations_users.alternative_user_id)) AS alternative_user";
        sql += "   FROM  dbo.EMPLOYEE INNER JOIN";
        sql += "   dbo.Vacations_summary ON dbo.EMPLOYEE.PMP_ID = dbo.Vacations_summary.emp_id INNER JOIN";
        sql += "    dbo.Departments ON dbo.EMPLOYEE.Dept_Dept_id = dbo.Departments.Dept_ID INNER JOIN";
        sql += "   dbo.Vacations_users ON dbo.EMPLOYEE.PMP_ID = dbo.Vacations_users.user_id";
        sql += "   WHERE  (dbo.Vacations_users.manager_approve = 1) and dbo.EMPLOYEE.group_id <> 3 and EMPLOYEE.foundation_id='" + Session_CS.foundation_id + "' and status = 2  and status !=0 and dbo.Vacations_summary.year='" + CDataConverter.ConvertDateTimeNowRtnDt().Year  + "'";

        // for (int i = 0; i < arrlist.Count; i++)
        //{
        sql += " and dbo.Vacations_users.id = " + CDataConverter.ConvertToInt(arrlist[0].ToString());
        //}

        //if (id != 0)
        //{
        //    sql += " and dbo.Vacations_users.id = " + id;

        //}

        //if (vacid_hidden.Value != "0")

        //{ sql += " AND dbo.Vacations_users.vacation_id = " + Convert.ToInt32(vacid_hidden.Value); }

        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            {
                string user = Session_CS.pmp_name.ToString();
                if (vacid_hidden.Value == "1")
                { s = Server.MapPath("../Reports/Vocations_Designated_unsu.rpt"); }
                if (vacid_hidden.Value == "2")
                { s = Server.MapPath("../Reports/Vocations_Designated_ex.rpt"); }
                ReportDocument rd = new ReportDocument();
                rd.Load(s);
                ReportsClass.Reports.Load_Report(rd);
                rd.SetDataSource(dt);
                rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
                rd.SetParameterValue("@user", user, "footerRep.rpt");
                rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report");
            }
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
    private void Change_cntrol_enabled(bool Flag)
    {
        foreach (GridViewRow grdrow in requests.Rows)
        {
            ((ImageButton)grdrow.FindControl("ImgBtnEdit")).Enabled = Flag;
            ((ImageButton)grdrow.FindControl("ImgBtnDelete")).Enabled = Flag;

        }
    }

    private void Send_mail(string Msg, int Pmp_id,string str_date,string end_date,string vacation_type)
    {
        DataTable Dt_Mng = General_Helping.GetDataTable("Select mail,PMP_ID,pmp_name from EMPLOYEE where PMP_ID = " + Pmp_id);
        DataTable dt_vacresponsible = Vacations_View_class.Sector_Vacation_Resposible(CDataConverter.ConvertToInt(Session_CS.sec_id),CDataConverter.ConvertToInt(Session_CS.foundation_id));

        string name = "";
        string mail = "";
        string vacresponsible_mail = "";
        if (Dt_Mng.Rows.Count > 0 && dt_vacresponsible.Rows.Count > 0)
        {
             mail = Dt_Mng.Rows[0]["mail"].ToString();

             vacresponsible_mail = dt_vacresponsible.Rows[0]["mail"].ToString();
          



            MailMessage _Message = new MailMessage();

            _Message.Subject = "نظام الادارة الالكترونية - الأجازات";


            _Message.BodyEncoding = Encoding.UTF8;
            _Message.SubjectEncoding = Encoding.UTF8;


            string address2 = "0";
            String encrypted_id = "0";
            string file = "";            
            MemoryStream ms = new MemoryStream();
          //  _Message.IsBodyHtml = true;
            _Message.Body = "<html><body dir='rtl'><h3 >";
            _Message.Body += " السيد  ";
            _Message.Body += Dt_Mng.Rows[0]["pmp_name"] + " </h3> ";
            _Message.Body += "<h3 >قام السيد " + Session_CS.pmp_name + " </h3> ";
            _Message.Body += " <h3 > بالرد على الأجازة ";

            _Message.Body += " <h3 style=color:blue > " + vacation_type + "</h3>";

            _Message.Body += " <h3 >  المقدمة من جانبكم";
            _Message.Body += "<h3 >خلال الفترة من : " + str_date + " </h3> ";
            _Message.Body += "<h3 >  إلي  : " + end_date + " </h3> ";

            _Message.Body += " <h3 style=color:blue > " + Msg + "</h3>";

            _Message.Body += "<h3 > مع تحيات </h3> ";
            _Message.Body += "<h3 >   " + Session_CS.e_signature.ToString() + "  </h3> ";
            _Message.Body += "</body></html>";
                   

            try
            {
                    SendingMailthread_class.Sendingmail(_Message,_Message.Subject, _Message.Body, mail, ms, file, encrypted_id, vacresponsible_mail);
               

            }
            catch (Exception ex)
            {
            }

        }


    }
  
    protected void requests_urgent_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //VocStatus ,manager_approve,general_manager_approve
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string GMApprove = (string)Convert.ToString(DataBinder.Eval(e.Row.DataItem, "general_manager_approve"));
            //string MApprove = (string)Convert.ToString(DataBinder.Eval(e.Row.DataItem, "manager_approve"));
            Label VocStat = (Label)e.Row.FindControl("VocStatus");
            if (GMApprove == "1")
            {
                VocStat.Text = "تم الموافقة";
            }
            else if (GMApprove == "2")
            {
                VocStat.Text = "تم الرفض";
            }
            else
            {
                VocStat.Text = "لم تنظر";
            }
        }
    }

    protected void requests_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {


    }
    private void refresh_grid()
    {
        ArrayList arr = new ArrayList();
        string strID = "";
        string statuss = "";
        foreach (GridViewRow row in requests.Rows)
        {
            RadioButtonList rb = (RadioButtonList)row.FindControl("AcceptRefuseRBList");

            if (!string.IsNullOrEmpty(rb.SelectedValue))
            {
                statuss = rb.SelectedValue;
                if (statuss == "1")  //Vacation Accpeted
                {
                    TextBox txt_Data = (TextBox)row.FindControl("txt_Data");
                    string str = txt_Data.Text.ToString();
                    string[] arry = str.Split(',');
                    arr.Add(CDataConverter.ConvertToInt(arry[0].ToString()));
                }
            }
        }
    }



    protected void Btn_Accept_Click(object sender, EventArgs e)
    {
        //threadObj = new Thread(new ThreadStart(MyWorkerThreadMethod));

        //threadObj.Start();

        ArrayList arrlist = new ArrayList();

        Btn_Accept.Enabled = false;
        string status = "3";//Status indicating the value of the radio button

        foreach (GridViewRow row in this.requests.Rows)
        {
            RadioButtonList rb = (RadioButtonList)row.FindControl("AcceptRefuseRBList");
            //Set the value of status
            if (!string.IsNullOrEmpty(rb.SelectedValue))
            {
                status = rb.SelectedValue;

                int grop = CDataConverter.ConvertToInt(Session_CS.group_id.ToString());
                //not needed
                //Change_cntrol_enabled(false);
                TextBox txt_pmpid = (TextBox)row.FindControl("txt_pmpid");

                TextBox txt_start = (TextBox)row.FindControl("txt_start");
                TextBox txt_end = (TextBox)row.FindControl("txt_end");

                int vac_empid = CDataConverter.ConvertToInt( txt_pmpid.Text);
                TextBox txt_Data = (TextBox)row.FindControl("txt_Data");
                string str = txt_Data.Text.ToString();
                string[] arr = str.Split(',');

                int vac_type = CDataConverter.ConvertToInt(arr[2].ToString());
                string vactype = "";
                if(vac_type==1)
                {
                    vactype = " الإعتيادي";

                }
                else if(vac_type==2)
                {
                    vactype = " العارضة";
                }
                else 
                {
                    vactype = " ";
                }
                if (status == "1")  //Vacation Accpeted
                {
                    int pmpID = CDataConverter.ConvertToInt(arr[1].ToString());
                    int gridIndex = CDataConverter.ConvertToInt(arr[3].ToString());
                    SqlDataAdapter sqladptr = new SqlDataAdapter();
                    SqlConnection con = new SqlConnection(sql_Connection);
                    SqlCommand obj = new SqlCommand("Add_Edit_Vacation_User", con);
                    obj.CommandType = CommandType.StoredProcedure;
                    obj.Parameters.Add(new SqlParameter("@id", arr[0].ToString()));
                    obj.Parameters.Add(new SqlParameter("@manager_approve", "1"));
                    con.Open();
                    sqladptr.SelectCommand = obj;
                    obj.ExecuteNonQuery();
                    //sendmailtoHR(CDataConverter.ConvertToInt(arr[1].ToString()),CDataConverter.ConvertToInt(arr[3].ToString()));

                    //  requests.DeleteRow(CDataConverter.ConvertToInt(arr[3].ToString()));



                   
                    Vacations_DB.vacation_summary(CDataConverter.ConvertToInt(arr[0].ToString()));
                    con.Close();



                   //if (grop != 3)
                   //{
                        int id = Convert.ToInt32(arr[0].ToString());
                        vacid_hidden.Value = arr[2].ToString();
                        if (vacid_hidden.Value == "1" || vacid_hidden.Value == "2")
                        {

                            arrlist.Add(CDataConverter.ConvertToInt(arr[0].ToString()));

                        }

                        Send_mail(" بالموافقة", vac_empid, txt_start.Text, txt_end.Text,vactype);
                      

                   // }

                  

                }
                else if (status == "2")//Vacation is rejected
                {
                    SqlDataAdapter sqladptr = new SqlDataAdapter();
                    SqlConnection con = new SqlConnection(sql_Connection);
                    SqlCommand obj = new SqlCommand("Add_Edit_Vacation_User", con);
                    obj.CommandType = CommandType.StoredProcedure;
                    obj.Parameters.Add(new SqlParameter("@id", arr[0].ToString()));
                    obj.Parameters.Add(new SqlParameter("@manager_approve", "2"));
                    con.Open();
                    sqladptr.SelectCommand = obj;
                    obj.ExecuteNonQuery();
                    con.Close();

                    requests.DeleteRow(CDataConverter.ConvertToInt(arr[3].ToString()));//Delete the row from grid in which an action was taken


                    //if (grop != 3)
                    //{
                        Send_mail("بالرفض", vac_empid,txt_start.Text,txt_end.Text,vactype);
                        
                   // }
                 

                }
         

            }
        }
        requests.DeleteRow(0);
        requests.DataBind();
         FillGrids();
        Btn_Accept.Enabled = true;

        if (requests.Rows.Count > 0)
            Btn_Accept.Visible = true;
        else
            Btn_Accept.Visible = false;


        if (arrlist.Count > 0)
        {


            //GetReport(arrlist);



        }
    }



   

    protected void gvMain_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        requests.PageIndex = e.NewPageIndex;
        FillGrids();


    }
    
}
