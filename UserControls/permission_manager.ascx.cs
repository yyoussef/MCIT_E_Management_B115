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

public partial class UserControls_permission_manager : System.Web.UI.UserControl
{

    private string sql_Connection = Database.ConnectionString;
    string start_date;
    int month;
    int year;
    Session_CS Session_CS = new Session_CS();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillGrids();
            if (requests.Rows.Count > 0)
                Btn_AcceptReject.Visible = true;
            else
                Btn_AcceptReject.Visible = false;
        }
    }

    private void FillGrids()
    {
        Vocations_permission_DT VacObj = new Vocations_permission_DT();
        DataTable AllVacDT = Vocations_permission_DB.Select_by_dept(CDataConverter.ConvertToInt(Session_CS.pmp_id));
        requests.Visible = true;
        requests.DataSource = AllVacDT;
        requests.DataBind();
        // start_date = AllVacDT.Rows[0]["start_date"].ToString();
        //DateTime date1 = Convert.ToDateTime(start_date );
        // month = date1.Month;
        // year = date1.Year;

    }


    protected void BtnVacationRequest_Click(object sender, EventArgs e)
    {
        Response.Redirect("permission_request.aspx");
    }
    protected void BtnVacationOld_Click(object sender, EventArgs e)
    {
        Response.Redirect("permission_old.aspx");
    }

    protected void requests_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        // int grop = CDataConverter.ConvertToInt(Session_CS.group_id.ToString());
        // Change_cntrol_enabled(false);
        // string str = e.CommandArgument.ToString();
        // string[] arr = str.Split(',');

        // DataTable dttt = General_Helping.GetDataTable("select * from Vocation_permission where id='" + int.Parse(arr[0].ToString()) + "'  ");
        //// string  year11 = dttt.Rows[0]["start_date"].ToString();
        // start_date = dttt.Rows[0]["start_date"].ToString();
        // DateTime date1 = Convert.ToDateTime(start_date);
        // month = date1.Month;
        // year = date1.Year;

        // if (e.CommandName == "EditItem")
        // {
        //     DataTable dt33 = Vocations_permission_DB.Select_by_dept(CDataConverter.ConvertToInt(Session_CS.pmp_id));

        //     //start_date = dt33.Rows[0]["start_date"].ToString();
        //     //DateTime date1 = Convert.ToDateTime(start_date);
        //     //month = date1.Month;
        //     //year = date1.Year;

        //     int curYear = DateTime.Now.Year;
        //   //  DataTable dt = General_Helping.GetDataTable("select * from Vacations_summary where emp_id='" + int.Parse(arr[1].ToString())+"'and year='"+curYear+"'");
        //     DataTable dt = General_Helping.GetDataTable("select * from Vacations_summary where emp_id='"+ int.Parse(arr[1].ToString())+"' and year='"+DateTime.Now.Year.ToString()+"' ");

        //     int res = 0;
        //     res = dt.Rows.Count;
        //     if (res == 0)
        //     {
        //         ///////////////////////// ADD new record in Vacations_summary/////////////////////////////
        //         SqlParameter[] sqlParams2 = new SqlParameter[] { new SqlParameter("@result", res.ToString ()), 
        //                             new SqlParameter("@emp_id", CDataConverter.ConvertToInt(arr[1].ToString())),
        //                             new SqlParameter("@no_days", CDataConverter.ConvertToInt(0)),
        //                             new SqlParameter("@field", "")};
        //         int UpdateSummary = Vacations_DB.UpdatePermSummary(sqlParams2);

        //         /////////////////////////GET Permission count from Vacations_summary///////////////////////////////
        //     }    
        //     else  permno_hidden.Value = dt.Rows[0]["permission"].ToString();

        //     if (CDataConverter.ConvertToInt(permno_hidden.Value) != 0)
        //     {
        //         SqlDataAdapter sqladptr = new SqlDataAdapter();
        //         SqlConnection con = new SqlConnection(sql_Connection);
        //         SqlCommand obj = new SqlCommand("Edit_AppManger_permission", con);
        //         obj.CommandType = CommandType.StoredProcedure;
        //         obj.Parameters.Add(new SqlParameter("@id", arr[0].ToString()));
        //         obj.Parameters.Add(new SqlParameter("@manager_approve", "1"));
        //         con.Open();
        //         sqladptr.SelectCommand = obj;
        //         int id = obj.ExecuteNonQuery();

        //         if (id > 0 )
        //         {
        //             if (month == DateTime.Now.Month && year == DateTime.Now.Year)
        //             {
        //                 int var = CDataConverter.ConvertToInt(permno_hidden.Value) - 1;
        //                // General_Helping.ExcuteQuery("update Vacations_summary set permission = " + var + " where '" + int.Parse(arr[1].ToString()) +"'");
        //                 General_Helping.ExcuteQuery("update Vacations_summary set permission = " + var + " where emp_id='" + int.Parse(arr[1].ToString())+"' and year='"+DateTime.Now.Year.ToString() +"'");

        //             }
        //             else
        //             {

        //             }

        //         }
        //         con.Close();
        //         Send_mail("تم الموافقة", arr[1].ToString());
        //     }
        //     else
        //     {
        //         if (CDataConverter.ConvertToInt(permno_hidden.Value) == 0)

        //         { 
        //            ShowAlertMessage(" لقد استنفذ جميع الأذونات خلال الشهر");
        //           //  General_Helping.ExcuteQuery("update Vocation_permission set manager_approve = 1,general_manager_approve=1 where id='" + int.Parse(arr[0].ToString()) + "'");


        //         }

        //     }

        //     if (grop == 3)
        //     {
        //         // send_mail_to_sahar("تم الموافقة", arr[1].ToString());
        //     }


        // }

        // if (e.CommandName == "RemoveItem")
        // {
        //     SqlDataAdapter sqladptr = new SqlDataAdapter();
        //     SqlConnection con = new SqlConnection(sql_Connection);
        //     SqlCommand obj = new SqlCommand("Edit_AppManger_permission", con);
        //     obj.CommandType = CommandType.StoredProcedure;
        //     obj.Parameters.Add(new SqlParameter("@id", arr[0].ToString()));
        //     obj.Parameters.Add(new SqlParameter("@manager_approve", "2"));
        //     con.Open();
        //     sqladptr.SelectCommand = obj;
        //     obj.ExecuteNonQuery();
        //     con.Close();
        //     Send_mail("بالرفض", arr[1].ToString());
        //     if (grop == 3)
        //     {
        //         //send_mail_to_sahar("بالرفض", arr[1].ToString());
        //     }

        // }
        // FillGrids();
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
    private void Change_cntrol_enabled(bool Flag)
    {
        foreach (GridViewRow grdrow in requests.Rows)
        {
            ((ImageButton)grdrow.FindControl("ImgBtnEdit")).Enabled = Flag;
            ((ImageButton)grdrow.FindControl("ImgBtnDelete")).Enabled = Flag;

        }
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

            _Message.Subject = "نظام الادارة الالكترونية - إذن";


            _Message.BodyEncoding = Encoding.UTF8;
            _Message.SubjectEncoding = Encoding.UTF8;


            string address2 ="0";
            String encrypted_id = "0";
            string file = "";
            MemoryStream ms = new MemoryStream();
            //_Message.IsBodyHtml = true;
            _Message.Body = "<html><body dir='rtl'><h3 >";
            _Message.Body += " السيد /  ";
            _Message.Body += Dt_Mng.Rows[0]["pmp_name"] + " </h3> ";
            _Message.Body += "<h3 >قام السيد / " + Session_CS.pmp_name + " </h3> ";
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


    protected void Btn_AcceptReject_Click(object sender, EventArgs e)
    {
        //Change_cntrol_enabled(false);

        string status = "3";//Status indicating the value of the radio button
        foreach (GridViewRow row in this.requests.Rows)
        {
            RadioButtonList rb = (RadioButtonList)row.FindControl("AcceptRefuseRBList");
            //Set the value of status
            if (!string.IsNullOrEmpty(rb.SelectedValue))
            {
                status = rb.SelectedValue;


                int grop = CDataConverter.ConvertToInt(Session_CS.group_id.ToString());
                TextBox txt_Data = (TextBox)row.FindControl("txt_Data");
                string str = txt_Data.Text.ToString();
                string[] arr = str.Split(',');
                int gridIndex = CDataConverter.ConvertToInt(arr[2]);
                //DataTable dttt = General_Helping.GetDataTable("select * from Vocation_permission where id='" + int.Parse(arr[0].ToString()) + "'  ");
                //start_date = dttt.Rows[0]["start_date"].ToString();
                //DateTime date1 = Convert.ToDateTime(start_date);
                string DateString = ((DataBoundLiteralControl)(requests.Rows[gridIndex].Cells[1].Controls[0])).Text;
                DateTime date = CDataConverter.ConvertToDate(DateString);
                month = date.Month;
                year = date.Year;


                if (status == "1")//Permission Accpeted
                {
                    //DataTable dt33 = Vocations_permission_DB.Select_by_dept(CDataConverter.ConvertToInt(Session_CS.pmp_id));
                    //int curYear = DateTime.Now.Year;
                    ////  DataTable dt = General_Helping.GetDataTable("select * from Vacations_summary where emp_id='" + int.Parse(arr[1].ToString())+"'and year='"+curYear+"'");
                    //DataTable dt = General_Helping.GetDataTable("select * from Vacations_summary where emp_id='" + int.Parse(arr[1].ToString()) + "' and year='" + DateTime.Now.Year.ToString() + "' ");
                    //int res = 0;
                    //res = dt.Rows.Count;
                    //if (res == 0)
                    //{
                    //    ///////////////////////// ADD new record in Vacations_summary/////////////////////////////
                    //    SqlParameter[] sqlParams2 = new SqlParameter[] { new SqlParameter("@result", res.ToString ()), 
                    //                    new SqlParameter("@emp_id", CDataConverter.ConvertToInt(arr[1].ToString())),
                    //                    new SqlParameter("@no_days", CDataConverter.ConvertToInt(0)),
                    //                    new SqlParameter("year",curYear.ToString()),///Amira Addition///
                    //                    new SqlParameter("@field", "")};
                    //    int UpdateSummary = Vacations_DB.UpdatePermSummary(sqlParams2);
                    //    //Added this to initialize the value of hidden number of permissions
                    //    //as it is initialized in database permission column in vacation summary table
                    //    permno_hidden.Value = "2";////Amira Addition///

                    //    /////////////////////////GET Permission count from Vacations_summary///////////////////////////////
                    //}
                    //else permno_hidden.Value = dt.Rows[0]["permission"].ToString();

                    //if (CDataConverter.ConvertToInt(permno_hidden.Value) != 0)
                    //{
                    SqlDataAdapter sqladptr = new SqlDataAdapter();
                    SqlConnection con = new SqlConnection(sql_Connection);
                    SqlCommand obj = new SqlCommand("Edit_AppManger_permission", con);
                    obj.CommandType = CommandType.StoredProcedure;
                    obj.Parameters.Add(new SqlParameter("@id", arr[0].ToString()));
                    obj.Parameters.Add(new SqlParameter("@manager_approve", "1"));
                    con.Open();
                    sqladptr.SelectCommand = obj;
                    int id = obj.ExecuteNonQuery();

                    if (id > 0)
                    {
                        if (month == CDataConverter.ConvertDateTimeNowRtnDt().Month  && year == CDataConverter.ConvertDateTimeNowRtnDt().Year )

                            //if (month == DateTime.Now.Month && year == DateTime.Now.Year)
                        {
                            //int var = CDataConverter.ConvertToInt(permno_hidden.Value) - 1;
                            ///////////////////////////////////////
                            //permno_hidden.Value = var.ToString();//update the value of hidden field permission number
                            //////////////////////////////////////
                            // General_Helping.ExcuteQuery("update Vacations_summary set permission = " + var + " where '" + int.Parse(arr[1].ToString()) +"'");
                            General_Helping.ExcuteQuery("update Vacations_summary set permission = permission - 1  where emp_id='" + int.Parse(arr[1].ToString()) + "' and year='" + CDataConverter.ConvertDateTimeNowRtnDt().Year.ToString() + "'");
                        }
                        else
                        {

                        }
                    }
                    con.Close();
                    Send_mail("تم الموافقة", arr[1].ToString());
                    if (grop != 3)
                    {
                        //   sendmailtoHR(CDataConverter.ConvertToInt(arr[1]), CDataConverter.ConvertToInt(arr[2]));
                    }
                    //}
                    //else
                    //{
                    //    if (CDataConverter.ConvertToInt(permno_hidden.Value) == 0)
                    //    {
                    //        ShowAlertMessage(" لقد استنفذ جميع الأذونات خلال الشهر");
                    //        //  General_Helping.ExcuteQuery("update Vocation_permission set manager_approve = 1,general_manager_approve=1 where id='" + int.Parse(arr[0].ToString()) + "'");
                    //    }
                    //}
                    //if (grop == 3)
                    //{
                    //     send_mail_to_sahar("تم الموافقة", arr[1].ToString());
                    //}
                }
                else if (status == "2")
                {
                    SqlDataAdapter sqladptr = new SqlDataAdapter();
                    SqlConnection con = new SqlConnection(sql_Connection);
                    SqlCommand obj = new SqlCommand("Edit_AppManger_permission", con);
                    obj.CommandType = CommandType.StoredProcedure;
                    obj.Parameters.Add(new SqlParameter("@id", arr[0].ToString()));
                    obj.Parameters.Add(new SqlParameter("@manager_approve", "2"));
                    con.Open();
                    sqladptr.SelectCommand = obj;
                    obj.ExecuteNonQuery();
                    con.Close();
                    Send_mail("بالرفض", arr[1].ToString());
                    if (grop == 3)
                    {
                        //send_mail_to_sahar("بالرفض", arr[1].ToString());
                    }

                }
            }
        }

        FillGrids();
        if (requests.Rows.Count > 0)
            Btn_AcceptReject.Visible = true;
        else
            Btn_AcceptReject.Visible = false;
    }
    /// <summary>
    /// This function send mail to HR department confirming the direct manager's 
    /// acceptance to the employee request to get an errand.
    /// </summary>
    /// <param name="pmp_id">The accepted Employee ID in Database</param>
    public void sendmailtoHR(int pmp_id, int gridIndex)
    {
      
        int group_id = int.Parse(Session_CS.group_id.ToString());
        if (group_id != 3)
        {
            DataTable dt_getmail = General_Helping.GetDataTable("select mail,pmp_name from employee where  pmp_id= " + pmp_id);
            string name = "";
            string Succ_names = "", Failed_name = ""; 

            if (dt_getmail.Rows.Count > 0)
            {
           

                name = dt_getmail.Rows[0]["pmp_name"].ToString();
            
                string mail_test = System.Configuration.ConfigurationManager.AppSettings["vacation_responsable"].ToString();
               
                MailMessage _Message = new MailMessage();
              
                {
                    _Message.Subject = "نظام الادارة الالكترونية - الأذنات";
                }

                _Message.BodyEncoding = Encoding.UTF8;
                _Message.SubjectEncoding = Encoding.UTF8;

                string address2 = "0";
                String encrypted_id = "0";
                string file = "";
                MemoryStream ms = new MemoryStream();

                _Message.Body = "<html><body dir='rtl'><h4>";

                _Message.Body += " السيد  - ";
                _Message.Body += "  أحمد عاصم";
                _Message.Body += " </h4>";

                _Message.Body += " <h4> تم الموافقةعلي الاذن المقدم بواسطة " + name + "";
                //if (location.Text != "")
                //{
                _Message.Body += "<h4> و ذلك في يوم " + ((DataBoundLiteralControl)(requests.Rows[gridIndex].Cells[1].Controls[0])).Text.ToString() + "</h4>";
                //}
                _Message.Body += " من " + ((DataBoundLiteralControl)(requests.Rows[gridIndex].Cells[2].Controls[0])).Text.ToString() + " إلي " + ((DataBoundLiteralControl)(requests.Rows[gridIndex].Cells[3].Controls[0])).Text.ToString() + " ";
                _Message.Body += "<h4 > مع تحيات </h4> ";
                _Message.Body += "<h4 >   " + Session_CS.e_signature.ToString() + "  </h4> ";
                _Message.Body += "</body></html>";
           

                try
                {
                  
                    SendingMailthread_class.Sendingmail(_Message,_Message.Subject, _Message.Body, mail_test, ms, file, encrypted_id, "");


                    Succ_names += name + ",";
                }
                catch (Exception ex)
                {
                    Failed_name += name + ",";
                }

            }
        }
    }

}