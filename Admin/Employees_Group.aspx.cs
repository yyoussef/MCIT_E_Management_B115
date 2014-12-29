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
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Fill_Groups();
            Fill_sector();
        }
    }
    private void Fill_Groups()
    {
        string sql = "select * from Employee_Groups";
        DataTable dt = General_Helping.GetDataTable(sql);
        ddl_Groups.DataSource = dt;
        ddl_Groups.DataValueField = "ID";
        ddl_Groups.DataTextField = "Name";
        ddl_Groups.DataBind();
        ddl_Groups.Items.Insert(0, new ListItem("اختر المجموعة......", "0"));
    }
    private void Fill_sector()
    {
        string sql = "select * from sectors";
        DataTable dt = General_Helping.GetDataTable(sql);
        ddl_Sectors.DataSource = dt;
        ddl_Sectors.DataValueField = "Sec_id";
        ddl_Sectors.DataTextField = "Sec_name";
        ddl_Sectors.DataBind();
        ddl_Sectors.Items.Insert(0, new ListItem("اختر القطاع......", "0"));
    }
    protected void ddl_Sectors_SelectedIndexChanged(object sender, EventArgs e)
    {
        string sql = "select * from Employee where sec_sec_id = " + ddl_Sectors.SelectedValue + " ORDER BY LTRIM(pmp_name)";
        DataTable dt = General_Helping.GetDataTable(sql);
        cbl_Employees.DataSource = dt;
        cbl_Employees.DataValueField = "PMP_ID";
        cbl_Employees.DataTextField = "pmp_name";
        cbl_Employees.DataMember = "group_id";
        cbl_Employees.DataBind();
        
        if (ddl_Sectors.SelectedValue != "0" && ddl_Groups.SelectedValue != "0")
        {
            string sql_compare = "select * from Employee where sec_sec_id = " + ddl_Sectors.SelectedValue + " and group_id=" + ddl_Groups.SelectedValue + " ORDER BY LTRIM(pmp_name)";
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
        foreach (ListItem item in cbl_Employees.Items)
        {
            sql = "update employee set group_id=null where sec_sec_id=" + ddl_Sectors.SelectedValue;
            General_Helping.ExcuteQuery(sql);
        }
        foreach (ListItem item in cbl_Employees.Items)
        {
            if (item.Selected)
            {
                sql = "update employee set group_id=" + ddl_Groups.SelectedValue + " where sec_sec_id=" + ddl_Sectors.SelectedValue + " and pmp_id ="
                    + item.Value;
                General_Helping.ExcuteQuery(sql);
            }
        }
        Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('تم الحفظ بنجاح')</script>");
    }
    protected void ddl_Groups_SelectedIndexChanged(object sender, EventArgs e)
    {

        string sql = "select * from Employee where sec_sec_id = " + ddl_Sectors.SelectedValue + " ORDER BY LTRIM(pmp_name)";
        DataTable dt = General_Helping.GetDataTable(sql);


        string sql_compare = "select * from Employee where sec_sec_id = " + ddl_Sectors.SelectedValue + " and group_id=" + ddl_Groups.SelectedValue + " ORDER BY LTRIM(pmp_name)";
        DataTable dt_compare = General_Helping.GetDataTable(sql_compare);

        if (dt_compare.Rows.Count == 0)
        {
            foreach (ListItem item in cbl_Employees.Items)
            {


                item.Selected = false;

            }
        }
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
