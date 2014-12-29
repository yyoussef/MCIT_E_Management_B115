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

public partial class WebForms2_Employees_Group : System.Web.UI.Page
{
    private string sql_Connection = Database.ConnectionString;
    General_Helping Obj_General_Helping = new General_Helping();
    Session_CS Session_CS = new Session_CS();
    protected override void OnInit(EventArgs e)
    {
        //Smart_Search_Dept.sql_Connection = sql_Connection;
        //Smart_Search_Dept.Query = "select * from Departments ";
        //Smart_Search_Dept.Text_Field = "Dept_name";
        //Smart_Search_Dept.Value_Field = "Dept_id";
        //Smart_Search_Dept.DataBind();
        this.Smart_Search_Dept.Value_Handler += new Smart_Search.Delegate_Selected_Value(MOnMember_Data);
        Fill_dept();
        //if (!IsPostBack)
        //{
        //    Fill_dept();
        //}
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Smart_Search_Dept.Show_OrgTree = true;
            Fill_Groups();
           // Fill_sector();
           // Fill_dept();
        }
    }
    private void MOnMember_Data(string Value)
    {
        Get_Emp();

    }
    private void Fill_Groups()
    {
        string sql = "select * from Employee_Groups where foundation_id="+CDataConverter.ConvertToInt(Session_CS.foundation_id.ToString());
        DataTable dt = General_Helping.GetDataTable(sql);
        ddl_Groups.DataSource = dt;
        ddl_Groups.DataValueField = "ID";
        ddl_Groups.DataTextField = "Name";
        ddl_Groups.DataBind();
        ddl_Groups.Items.Insert(0, new ListItem("اختر المجموعة......", "0"));
    }
    //private void Fill_sector()
    //{
    //    string sql = "select * from sectors where foundation_id=" + CDataConverter.ConvertToInt(Session_CS.foundation_id.ToString());
    //    DataTable dt = General_Helping.GetDataTable(sql);
    //    ddl_Sectors.DataSource = dt;
    //    ddl_Sectors.DataValueField = "Sec_id";
    //    ddl_Sectors.DataTextField = "Sec_name";
    //    ddl_Sectors.DataBind();
    //    ddl_Sectors.Items.Insert(0, new ListItem("اختر القطاع......", "0"));
    //}
    //protected void ddl_Sectors_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    Fill_dept();
    //    //this.Smart_Search_Dept.Value_Handler += new Smart_Search.Delegate_Selected_Value(MOnMember_Data);
    //    //Smart_Search_Dept.SelectedValue = "0";
    //}

    void Fill_dept()
    {
        Smart_Search_Dept.sql_Connection = sql_Connection;
        string Query = "";
        Query = "SELECT  * from    Departments  where foundation_id='" + Session_CS.foundation_id + "'";
        Smart_Search_Dept.datatble = General_Helping.GetDataTable(Query);
        Smart_Search_Dept.Text_Field = "Dept_name";
        Smart_Search_Dept.Value_Field = "Dept_id";
        Smart_Search_Dept.DataBind();
        //this.Smart_Search_Dept.Value_Handler += new Smart_Search.Delegate_Selected_Value(MOnMember_Data);
        
    }

    private void Get_Emp()
    {
        string sql = "";
        if (Smart_Search_Dept.SelectedValue=="")
        {
            sql = @"select * from Employee where foundation_id = " + Session_CS.foundation_id + " ORDER BY LTRIM(pmp_name)";
        }
        else
        {
            sql = @"select * from Employee where foundation_id = " + Session_CS.foundation_id + " and Dept_Dept_id="
            + Smart_Search_Dept.SelectedValue + " ORDER BY LTRIM(pmp_name)";
        }
        DataTable dt = General_Helping.GetDataTable(sql);
        cbl_Employees.DataSource = dt;
        cbl_Employees.DataValueField = "PMP_ID";
        cbl_Employees.DataTextField = "pmp_name";
        cbl_Employees.DataMember = "group_id";
        cbl_Employees.DataBind();

        if (ddl_Groups.SelectedValue != "0" && ddl_Groups.SelectedValue !="")
        {
            string sql_compare = "select * from Employee where foundation_id = " + Session_CS.foundation_id + " and group_id=" + ddl_Groups.SelectedValue + " ORDER BY LTRIM(pmp_name)";
            DataTable dt_compare = General_Helping.GetDataTable(sql_compare);

            foreach (DataRow row_compare in dt_compare.Rows)
            {
                string Value = row_compare["pmp_id"].ToString();
                foreach (DataRow row in dt.Rows)
                {
                    if (row["pmp_id"].ToString() == Value)
                    {
                        ListItem item = cbl_Employees.Items.FindByValue(Value);
                        if (item != null)
                            item.Selected = true;
                    }
                }

            }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        string sql = "";
        string Sql_Delete = "update EMPLOYEE set Group_id=Null where Group_id ='" + CDataConverter.ConvertToInt(ddl_Groups.SelectedValue) + "' ";
     
        General_Helping.ExcuteQuery(Sql_Delete);
        //foreach (ListItem item in cbl_Employees.Items)
        //{
        //    sql = "update employee set group_id=null where sec_sec_id=" + ddl_Sectors.SelectedValue;
        //    General_Helping.ExcuteQuery(sql);
        //}
        foreach (ListItem item in cbl_Employees.Items)
        {
            if (item.Selected)
            {
                sql = "update employee set group_id=" + ddl_Groups.SelectedValue + " where  pmp_id ="
                    + item.Value;
                if(Smart_Search_Dept.SelectedValue!="")
                {
                   sql+=" and Dept_Dept_id='" + Smart_Search_Dept.SelectedValue + "'";
                }
                General_Helping.ExcuteQuery(sql);
            }
        }
        Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('تم الحفظ بنجاح')</script>");
    }
    protected void ddl_Groups_SelectedIndexChanged(object sender, EventArgs e)
    {

        Get_Emp();
    }
}
