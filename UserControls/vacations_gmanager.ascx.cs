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

public partial class UserControls_vacations_gmanager : System.Web.UI.UserControl
{
    Session_CS Session_CS = new Session_CS();
    private string sql_Connection = Database.ConnectionString;
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
        // commented by youssef
        Vacations_DT VacObj = new Vacations_DT();
        DataTable AllVacDT = Vacations_DB.Select_by_dept(0);
        requests.DataSource = AllVacDT;
        requests.DataBind();
    }
    protected void BtnVacationRequest_Click(object sender, EventArgs e)
    {
        Response.Redirect("vacation_request.aspx");
    }
    protected void requests_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //if (e.CommandName == "EditItem")
        //{
        //    SqlDataAdapter sqladptr = new SqlDataAdapter();
        //    SqlConnection con = new SqlConnection(sql_Connection);
        //    SqlCommand obj = new SqlCommand("Add_Edit_Vacation_GManager", con);
        //    obj.CommandType = CommandType.StoredProcedure;
        //    obj.Parameters.Add(new SqlParameter("@id", Convert.ToInt16(e.CommandArgument)));
        //    obj.Parameters.Add(new SqlParameter("@general_manager_approve", "1"));
        //    con.Open();
        //    sqladptr.SelectCommand = obj;
        //    obj.ExecuteNonQuery();
        //    con.Close();
            
        //    Vacations_DB.vacation_summary(CDataConverter.ConvertToInt(e.CommandArgument));

        //}

        //if (e.CommandName == "RemoveItem")
        //{
        //    SqlDataAdapter sqladptr = new SqlDataAdapter();
        //    SqlConnection con = new SqlConnection(sql_Connection);
        //    SqlCommand obj = new SqlCommand("Add_Edit_Vacation_GManager", con);
        //    obj.CommandType = CommandType.StoredProcedure;
        //    obj.Parameters.Add(new SqlParameter("@id", Convert.ToInt16(e.CommandArgument)));
        //    obj.Parameters.Add(new SqlParameter("@general_manager_approve", "2"));
        //    con.Open();
        //    sqladptr.SelectCommand = obj;
        //    obj.ExecuteNonQuery();
        //    con.Close();
        //}
        //FillGrids();
    }
    protected void Btn_AcceptReject_Click(object sender, EventArgs e)
    {
         string status = "3";//Status indicating the value of the radio button
         foreach (GridViewRow row in this.requests.Rows)
         {
             RadioButtonList rb = (RadioButtonList)row.FindControl("AcceptRefuseRBList");
             //Set the value of status
             if (!string.IsNullOrEmpty(rb.SelectedValue))
             {
                 status = rb.SelectedValue;
             }
             // int grop = CDataConverter.ConvertToInt(Session_CS.group_id.ToString());
             TextBox txt_Data = (TextBox)row.FindControl("txt_Data");
             string str = txt_Data.Text.ToString();
             string[] arr = str.Split(',');
             if (status == "1")//Vacation Accpeted
             {

                 SqlDataAdapter sqladptr = new SqlDataAdapter();
                 SqlConnection con = new SqlConnection(sql_Connection);
                 SqlCommand obj = new SqlCommand("Add_Edit_Vacation_GManager", con);
                 obj.CommandType = CommandType.StoredProcedure;
                 obj.Parameters.Add(new SqlParameter("@id", Convert.ToInt16(arr[0].ToString())));
                 obj.Parameters.Add(new SqlParameter("@general_manager_approve", "1"));
                 con.Open();
                 sqladptr.SelectCommand = obj;
                 obj.ExecuteNonQuery();
                 con.Close();

                 Vacations_DB.vacation_summary(CDataConverter.ConvertToInt(arr[0].ToString()));

             }
             else if (status == "2")
             {
                 SqlDataAdapter sqladptr = new SqlDataAdapter();
                 SqlConnection con = new SqlConnection(sql_Connection);
                 SqlCommand obj = new SqlCommand("Add_Edit_Vacation_GManager", con);
                 obj.CommandType = CommandType.StoredProcedure;
                 obj.Parameters.Add(new SqlParameter("@id", Convert.ToInt16(arr[0].ToString())));
                 obj.Parameters.Add(new SqlParameter("@general_manager_approve", "2"));
                 con.Open();
                 sqladptr.SelectCommand = obj;
                 obj.ExecuteNonQuery();
                 con.Close();

             }

             //Else, nothing has happened

         }
         FillGrids();
         if (requests.Rows.Count > 0)
             Btn_AcceptReject.Visible = true;
         else
             Btn_AcceptReject.Visible = false;

    }
}
