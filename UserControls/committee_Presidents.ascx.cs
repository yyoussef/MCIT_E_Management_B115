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
using System.Text;


public partial class UserControls_committee_Presidents : System.Web.UI.UserControl
{
    Session_CS Session_CS = new Session_CS();
    private string sql_Connection = Database.ConnectionString;
    General_Helping Obj_General_Helping = new General_Helping();

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            Smart_Search_mang.Show_OrgTree = true;
            fill_committee();


        }


    }

    protected override void OnInit(EventArgs e)
    {



        DataTable dt = General_Helping.GetDataTable( "select PMP_ID,pmp_name from dbo.EMPLOYEE where foundation_id='"+Session_CS.foundation_id +"' ");

        Smart_Search_emp.sql_Connection = sql_Connection;
        Smart_Search_emp.datatble =dt;
        
        Smart_Search_emp.Value_Field = "PMP_ID";
        Smart_Search_emp.Text_Field = "pmp_name";
        Smart_Search_emp.DataBind();


        DataTable dt1 = General_Helping.GetDataTable("select Dept_ID,Dept_name,Dept_parent_id from Departments  where foundation_id='" + Session_CS.foundation_id + "' ");
        Smart_Search_mang.sql_Connection = sql_Connection;
        Smart_Search_mang.datatble = dt1;

     

        Smart_Search_mang.Value_Field = "Dept_ID";
        Smart_Search_mang.Text_Field = "Dept_name";
        Smart_Search_mang.Orderby = "ORDER BY LTRIM(Dept_name)";
        Smart_Search_mang.DataBind();

        this.Smart_Search_emp.Value_Handler += new Smart_Search.Delegate_Selected_Value(emp_Data);

        base.OnInit(e);


    }




    private void emp_Data(string Value)
    {
        if (Value != "")
        {
            DataTable dt = commitee_presidents_DB.SelectAll(0, (CDataConverter.ConvertToInt(Smart_Search_emp.SelectedValue)));

            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["comt_id"] != DBNull.Value)
                {
                    ddl_committee.SelectedValue = dt.Rows[0]["comt_id"].ToString();
                }
                else
                {
                    ddl_committee.SelectedValue = "0";

                }
                Smart_Search_mang.SelectedValue = dt.Rows[0]["dept_id"].ToString();
                hid_id.Value = dt.Rows[0]["id"].ToString();

            }
            else
            {
                hid_id.Value =
                ddl_committee.SelectedValue = "0";
                Smart_Search_mang.SelectedValue = "0";



            }



        }



    }

    protected void btn_Save_Click(object sender, EventArgs e)
    {

        if (Smart_Search_emp.SelectedValue != "")
        {
            commitee_presidents_DT obj = new commitee_presidents_DT();
            obj.pmp_id = CDataConverter.ConvertToInt(Smart_Search_emp.SelectedValue);
            obj.comt_id = CDataConverter.ConvertToInt(ddl_committee.SelectedValue);
            obj.dept_id = CDataConverter.ConvertToInt(Smart_Search_mang.SelectedValue);
            obj.id = CDataConverter.ConvertToInt(hid_id.Value);
            obj.id = commitee_presidents_DB.Save(obj);


            if (obj.id > 0)
            {
                Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('تم الحفظ بنجاح')</script>");

            }
            clear();


        }
        else
        {
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('يجب إختيار الموظف ')</script>");

        }

    }



    protected void fill_committee()
    {
        DataTable dt = Commitee_DB.SelectAll(0,Session_CS.foundation_id);
        ddl_committee.DataSource = dt;
        ddl_committee.DataBind();
        ddl_committee.Items.Insert(0, new ListItem("..... اختر  اللجنة  ....", "0"));


    }
    private void clear()
    {
        hid_id.Value =
        ddl_committee.SelectedValue = "0";
        Smart_Search_emp.SelectedValue = "0";
        Smart_Search_mang.SelectedValue = "0";

    }



}














