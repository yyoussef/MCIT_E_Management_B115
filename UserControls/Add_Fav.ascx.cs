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

using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;

public partial class UserControls_Add_Fav : System.Web.UI.UserControl
{
    //test from moataz
    string sql;
    SqlConnection conn;
    SqlDataAdapter da;
    DataSet ds;
    SqlCommand cmd;
    private string sql_Connection = Database.ConnectionString;
    //Session_CS Session_CS = new Session_CS();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int pmp = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
            Smart_Search_dept.Show_OrgTree = true;
            fill_structure();
           // fil_emp_Visa();
            //Fil_Visa_Lst(pmp);
            DataTable dt = General_Helping.GetDataTable("SELECT pmp_fav.employee_id, pmp_fav.pmp_fav_id, EMPLOYEE.pmp_name FROM pmp_fav INNER JOIN EMPLOYEE ON pmp_fav.pmp_fav_id = EMPLOYEE.PMP_ID where employee_id =" + pmp + " order by LTRIM(pmp_name)");
            foreach (DataRow dr in dt.Rows)
            {
                ListItem obj = new ListItem(dr["pmp_name"].ToString(), dr["pmp_fav_id"].ToString());
                lst_emp.Items.Add(obj);

                //string Value = dr["pmp_name"].ToString();
                //ListItem item = lst_emp.Items.FindByValue(Value);
               // lst_emp.Items.Add(Value);


            }

        }
    }
    protected override void OnInit(EventArgs e)
    {
        #region BROWSER FOR departments

      

        //fil_emp();
       

        //this.Smrt_Srch_DropDep.Value_Handler += new Smart_Search.Delegate_Selected_Value(MOnMember_Data);
        //Inbox_organization.SelectedValue;
        // fill project

      

        //smart_Search_sector.sql_Connection = sql_Connection;
        //string Query = "SELECT Sec_id, Sec_name FROM Sectors  where foundation_id= " + CDataConverter.ConvertToInt(Session_CS.foundation_id.ToString());
        //smart_Search_sector.Value_Field = "Sec_id";
        //smart_Search_sector.Text_Field = "Sec_name";
        //smart_Search_sector.datatble = General_Helping.GetDataTable(Query);
        //smart_Search_sector.DataBind();
        //this.smart_Search_sector.Value_Handler += new Smart_Search.Delegate_Selected_Value(MOnMember_Data);
        //this.smart_Search_sector.Value_Handler += new Smart_Search.Delegate_Selected_Value(MOnMember_Data2);
        
        //if (smart_Search_sector.SelectedValue!="")
        //{
        //    string Query2 = "SELECT dept_id, dept_name FROM Departments where sec_sec_id =  " + smart_Search_sector.SelectedValue;
        //    Smart_Search_dept.Value_Field = "dept_id";
        //    Smart_Search_dept.Text_Field = "dept_name";
        //    Smart_Search_dept.datatble = General_Helping.GetDataTable(Query2);
        //    Smart_Search_dept.DataBind();
        //}
        this.Smart_Search_dept.Value_Handler += new Smart_Search.Delegate_Selected_Value(MOnMember_Data2);
        Smart_Search_dept.sql_Connection = sql_Connection;
  

        #endregion
        base.OnInit(e);
    }
    private void MOnMember_Data(string Value)
    {
        smartdept_fun();
    }
    protected void smartdept_fun()
    {

        //Smart_Search_dept.sql_Connection = sql_Connection;
        //string Query = "SELECT dept_id, dept_name FROM Departments where sec_sec_id =  " + smart_Search_sector.SelectedValue;
        //Smart_Search_dept.Value_Field = "dept_id";
        //Smart_Search_dept.Text_Field = "dept_name";
        //Smart_Search_dept.datatble = General_Helping.GetDataTable(Query);
        //Smart_Search_dept.DataBind();


        string Query = "";
        Query = "SELECT  * from    Departments  where foundation_id='" + Session_CS.foundation_id + "'";

        Smart_Search_dept.datatble = General_Helping.GetDataTable(Query);
        Smart_Search_dept.Value_Field = "Dept_id";
        Smart_Search_dept.Text_Field = "Dept_name";
        Smart_Search_dept.DataBind();

        
        this.Smart_Search_dept.Value_Handler += new Smart_Search.Delegate_Selected_Value(MOnMember_Data2);
        

    }
    protected void fill_structure()
    {

        string Query = "";
        Query = "SELECT  * from    Departments  where foundation_id='" + Session_CS.foundation_id + "'";

        Smart_Search_dept.datatble = General_Helping.GetDataTable(Query);
        Smart_Search_dept.Value_Field = "Dept_id";
        Smart_Search_dept.Text_Field = "Dept_name";
        Smart_Search_dept.DataBind();


    }
    private void MOnMember_Data2(string Value)
    {
        getemployee();
    }

    private void getemployee()
    {
        if (Smart_Search_dept.SelectedValue!="")
        {
            chklst_Visa_Emp_All.DataSource = General_Helping.GetDataTable("SELECT PMP_ID, pmp_name FROM EMPLOYEE where dept_dept_id =  " + Smart_Search_dept.SelectedValue + " order by LTRIM(pmp_name)");
            chklst_Visa_Emp_All.DataBind();
        }
       
    }

    //protected void chk_ALL_CheckedChanged(object sender, EventArgs e)
    //{
    //    foreach (ListItem item in chklst_Visa_Emp_All.Items)
    //    {
    //        item.Selected = chk_ALL.Checked;
    //    }
    //    //TabPanel_All.ActiveTab = TabPanel_Visa;
    //}
    protected void btn_add_Click(object sender, EventArgs e)
    {

        fill_listbox();
       // TabPanel_All.ActiveTab = TabPanel_Visa;
    }
    public void fill_listbox()
    {
        foreach (ListItem item in chklst_Visa_Emp_All.Items)
        {
            if (item.Selected && lst_emp.Items.FindByValue(item.Value) == null)
            {
                ListItem obj = new ListItem(item.Text, item.Value);
                lst_emp.Items.Add(obj);
                item.Selected = false;
            }
          

        }
    }
    protected void btn_delete_Click(object sender, EventArgs e)
    {
        if (lst_emp.SelectedValue == "")
        {
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('يجب اختيار موظف ليتم الحذف')</script>");
        }
        else
        {
            lst_emp.Items.Remove(lst_emp.SelectedItem);

           

        }
        //TabPanel_All.ActiveTab = TabPanel_Visa;

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
 

    private void Fil_Visa_Lst(int pmp)
    {
        // pmp = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
        //string Sql_Delete = "select * from pmp_fav where employee_id =" + pmp;
        //DataTable DT = General_Helping.GetDataTable(Sql_Delete);
        //foreach (DataRow dr in DT.Rows)
        //{
        //    string Value = dr["pmp_fav_id"].ToString();
        //    ListItem item = chklst_Visa_Emp.Items.FindByValue(Value);
        //    if (item != null)
        //        item.Selected = true;


        //}
       

    }


    protected void SaveButton_Click(object sender, EventArgs e)
    {
        int pmp = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
        if (lst_emp.Items.Count > 0)
        {

            string Sql_Delete = "delete from pmp_fav where employee_id =" + pmp;
            General_Helping.ExcuteQuery(Sql_Delete);
            string Sql_insert = "";

         
            foreach (ListItem item in lst_emp.Items)
            {
               

                    Sql_insert = "insert into pmp_fav ( employee_id , pmp_fav_id ) values ( " + pmp + "," + item.Value + ")";
                    General_Helping.ExcuteQuery(Sql_insert);
                    //item.Selected = false;
               

            }
            ShowAlertMessage("تم الإضافة للمفضلة");
        }
        else
        {
            ShowAlertMessage("لا يوجد موظفين فالقائمة .. من فضلك اختر موظفين ثم اضغط علي زرار اضف ");
            return;
        }
      

    }
}
