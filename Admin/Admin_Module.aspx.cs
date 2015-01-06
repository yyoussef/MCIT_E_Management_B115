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
    string sql;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Get_Module();
      //
        }

    }
    protected void Get_Module()
    {
        sql = @"select * from Admin_Module ORDER BY LTRIM(Name)";
        DataTable dt = General_Helping.GetDataTable(sql);
        cbl_Module.DataSource = dt;
        cbl_Module.DataValueField = "pk_ID";
        cbl_Module.DataTextField = "Name";
        cbl_Module.DataBind();
        foreach (DataRow row in dt.Rows)
        {
            string Value = row["pk_ID"].ToString();
            if (row["Active"].ToString() == "True")
            {
                ListItem item = cbl_Module.Items.FindByValue(Value);
                if (item != null)
                    item.Selected = true;
            }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        sql = "update Admin_Module set Active=0";
        General_Helping.ExcuteQuery(sql);
        foreach (ListItem item in cbl_Module.Items)
        {
            if (item.Selected)
            {
                sql = "update Admin_Module set Active=1 where pk_ID=" + item.Value;
                General_Helping.ExcuteQuery(sql);
            }
        }
        Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('تم الحفظ بنجاح')</script>");
    }
}
