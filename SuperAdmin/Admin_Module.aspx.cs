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

public partial class Admin_Admin_Module : System.Web.UI.Page
{
    string sql, Sql_insert;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Get_Module();
            Get_found();
        }

    }

    private void Get_found()
    {
        DataTable dt = Foundations_DB.SelectAll();
        drop_found.DataSource = dt;

        drop_found.DataBind();
        drop_found.Items.Insert(0, new ListItem("إختر الجهة", "0"));

    }
    protected void drop_found_SelectedIndexChanged(object sender, EventArgs e)
    {
        cbl_Module.ClearSelection();
        //Get_Module();
        DataTable dt = General_Helping.GetDataTable("select * from admin_module_found where found_id= " + CDataConverter.ConvertToInt(drop_found.SelectedValue));
        foreach (DataRow row in dt.Rows)
        {
            string Value = row["Mod_ID"].ToString();
            if (row["Mod_status"].ToString() == "True")
            {
                ListItem item = cbl_Module.Items.FindByValue(Value);
                if (item != null)
                    item.Selected = true;
            }

        }
    }
    protected void Get_Module()
    {
        sql = @"select * from Admin_Module  ORDER BY LTRIM(Name)";
        DataTable dt = General_Helping.GetDataTable(sql);
        cbl_Module.DataSource = dt;
        cbl_Module.DataValueField = "pk_ID";
        cbl_Module.DataTextField = "Name";
        cbl_Module.DataBind();
        //foreach (DataRow row in dt.Rows)
        //{
        //    string Value = row["pk_ID"].ToString();

        //    ListItem item = cbl_Module.Items.FindByValue(Value);
        //    if (item != null)
        //        item.Selected = true;

        //}

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        //sql = "update Admin_Module set Active=0";
        General_Helping.ExcuteQuery("delete from admin_module_found where found_id = " + CDataConverter.ConvertToInt(drop_found.SelectedValue));
       // General_Helping.ExcuteQuery(sql);
        foreach (ListItem item in cbl_Module.Items)
        {
            if (item.Selected)
            {
                if (drop_found.SelectedValue != "0")
                {

                    Sql_insert = "insert into admin_module_found ( Mod_id , Mod_status ,found_id) values ( " + item.Value + "," + 1 + "," + CDataConverter.ConvertToInt(drop_found.SelectedValue) + ")";
                    General_Helping.ExcuteQuery(Sql_insert);
                }

                //sql = "update Admin_Module set Active=1 where pk_ID=" + item.Value;

                //General_Helping.ExcuteQuery(sql);
            }
        }
        Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('تم الحفظ بنجاح')</script>");
    }
}
