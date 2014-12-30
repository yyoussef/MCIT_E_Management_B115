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

public partial class UserControls_vacations_dayoff_manager : System.Web.UI.UserControl
{
    private string sql_Connection = Database.ConnectionString;
    //Session_CS Session_CS = new Session_CS();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillGrids();
            if (requests.Rows.Count > 0)
                Btn_AcceptRefuse.Visible = true;
            else
                Btn_AcceptRefuse.Visible = false;
        }
    }

    private void FillGrids()
    {
        Vacations_Dayoff_DT VacObj = new Vacations_Dayoff_DT();
        DataTable AllVacDT = Vacations_Dayoff_DB.Select_by_dept(CDataConverter.ConvertToInt(Session_CS.pmp_id));

        requests.DataSource = AllVacDT;
        requests.DataBind();
    }
    protected void BtnVacationRequest_Click(object sender, EventArgs e)
    {
        Response.Redirect("vacation_Dayoff_request.aspx");
    }
    protected void requests_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //if (e.CommandName == "EditItem")
        //{
        //    string str = e.CommandArgument.ToString();
        //    string[] arr = str.Split(',');
        //    SqlDataAdapter sqladptr = new SqlDataAdapter();
        //    SqlConnection con = new SqlConnection(sql_Connection);
        //    SqlCommand obj = new SqlCommand("Add_Edit_Vacations_DayOff_User", con);
        //    obj.CommandType = CommandType.StoredProcedure;
        //    obj.Parameters.Add(new SqlParameter("@id", arr[0].ToString ()));
        //    obj.Parameters.Add(new SqlParameter("@manager_approve", "1"));
        //    con.Open();
        //    sqladptr.SelectCommand = obj;
        //    obj.ExecuteNonQuery();
        //    Vacations_errand(CDataConverter.ConvertToInt(arr[0].ToString()), CDataConverter.ConvertToInt(arr[1].ToString()));
        //    con.Close();


        //}

        //if (e.CommandName == "RemoveItem")
        //{
        //    SqlDataAdapter sqladptr = new SqlDataAdapter();
        //    SqlConnection con = new SqlConnection(sql_Connection);
        //    SqlCommand obj = new SqlCommand("Add_Edit_Vacations_DayOff_User", con);
        //    obj.CommandType = CommandType.StoredProcedure;
        //    obj.Parameters.Add(new SqlParameter("@id", Convert.ToInt16(e.CommandArgument)));
        //    obj.Parameters.Add(new SqlParameter("@manager_approve", "2"));
        //    con.Open();
        //    sqladptr.SelectCommand = obj;
        //    obj.ExecuteNonQuery();
        //    con.Close();
        //}
        //FillGrids();
    }
    protected void BtnVacationOld_Click(object sender, EventArgs e)
    {
        Response.Redirect("vacations_Dayoff_old.aspx");
    }

    public void Vacations_errand(int id, int user_id)
    {
        //int Days_no;

        Vacations_Dayoff_DT VacObj = new Vacations_Dayoff_DT();
        DataTable AllVacDT = Vacations_Dayoff_DB.GetVacations_DayOffByID(id);
        int no_days = int.Parse(AllVacDT.Rows[0]["no_days"].ToString());
        int manager_approve = int.Parse(AllVacDT.Rows[0]["manager_approve"].ToString());

        if (manager_approve == 1)
        {
            //General_Helping.GetDataTable("select * from Vacations_summary where emp_id= " + user_id);
            General_Helping.ExcuteQuery("update Vacations_summary set day_off_no = ISNULL(day_off_no, 0)  + " + no_days + " where emp_id=" + user_id);
        }

    }

    protected void Btn_AcceptRefuse_Click(object sender, EventArgs e)
    {
        string status = "3";//Status indicating the value of the radio button

        foreach (GridViewRow row in this.requests.Rows)
        {
            RadioButtonList rb = (RadioButtonList)row.FindControl("AcceptRefuseRBList");
            //Set the value of status
            if (!string.IsNullOrEmpty(rb.SelectedValue))
            {
                status = rb.SelectedValue;

                TextBox txt_Data = (TextBox)row.FindControl("txt_Data");
                string str = txt_Data.Text.ToString();

                string[] arr = str.Split(',');
                if (status == "1")//Accepted
                {
                    //string str = e.CommandArgument.ToString();
                    //string[] arr = str.Split(',');
                    SqlDataAdapter sqladptr = new SqlDataAdapter();
                    SqlConnection con = new SqlConnection(sql_Connection);
                    SqlCommand obj = new SqlCommand("Add_Edit_Vacations_DayOff_User", con);
                    obj.CommandType = CommandType.StoredProcedure;
                    obj.Parameters.Add(new SqlParameter("@id", arr[0].ToString()));
                    obj.Parameters.Add(new SqlParameter("@manager_approve", "1"));
                    con.Open();
                    sqladptr.SelectCommand = obj;
                    obj.ExecuteNonQuery();
                    Vacations_errand(CDataConverter.ConvertToInt(arr[0].ToString()), CDataConverter.ConvertToInt(arr[1].ToString()));
                    con.Close();
                }
                else if (status == "2")
                {
                    SqlDataAdapter sqladptr = new SqlDataAdapter();
                    SqlConnection con = new SqlConnection(sql_Connection);
                    SqlCommand obj = new SqlCommand("Add_Edit_Vacations_DayOff_User", con);
                    obj.CommandType = CommandType.StoredProcedure;
                    obj.Parameters.Add(new SqlParameter("@id", Convert.ToInt16(arr[0].ToString())));
                    obj.Parameters.Add(new SqlParameter("@manager_approve", "2"));
                    con.Open();
                    sqladptr.SelectCommand = obj;
                    obj.ExecuteNonQuery();
                    con.Close();
                }
            }

        }
        FillGrids();
        if (requests.Rows.Count > 0)
            Btn_AcceptRefuse.Visible = true;
        else
            Btn_AcceptRefuse.Visible = false;
    }
}
