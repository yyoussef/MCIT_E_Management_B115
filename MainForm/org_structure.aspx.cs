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
using System.Text;
using System.Data.SqlClient;
using Geekees.Common.Utilities.Xml;
using Geekees.Common.Controls;

using System.Xml;
using Dates;
using Microsoft.Office.Interop.MSProject;
using System.Reflection;
using System.Data.Sql;
public partial class MainForm_org_structure : System.Web.UI.Page
{
    Session_CS Session_CS = new Session_CS();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GenerateTree();
        }
    }

    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);

        //link the css file
        this.lASTreeViewThemeCssFile.Text = "<link id='astreeviewcssfile' href='' type='text/css' rel='stylesheet' />";

        //  string script = string.Format("document.getElementById('astreeviewcss').href='{0}'", this.astvMyTree.ThemeCssFile);
        //   this.ClientScript.RegisterStartupScript(this.GetType(), "js" + Guid.NewGuid().ToString(), script, true);

    }

    private void GenerateTree()
    {
        ASTreeViewTheme rightLeft = new ASTreeViewTheme();
        rightLeft.BasePath = "~/javascript/astreeview/themes/right-left/";
        rightLeft.CssFile = "right-left.css";
        this.astvMyTree.Theme = rightLeft;
        this.astvMyTree.EnableTreeLines = true;
        this.astvMyTree.EnableRightToLeftRender = true;

        DataTable DT_Tree = new DataTable();
        string sql = "select * from Departments where 1=1 ";
        sql += " AND foundation_id = " + CDataConverter.ConvertToInt(Session_CS.foundation_id.ToString());
        sql += " order by dept_name";

        DT_Tree = General_Helping.GetDataTable(sql);

        ASTreeViewDataTableColumnDescriptor descripter = new ASTreeViewDataTableColumnDescriptor("dept_name"
            , "Dept_id"
            , "Dept_parent_id");
        this.astvMyTree.DataSourceDescriptor = descripter;
        this.astvMyTree.DataSource = DT_Tree;
        this.astvMyTree.DataBind();
    }

    protected void btnPostBackTrigger_Click(object sender, EventArgs e)
    {
        string curNodeValue = this.txtCurrentNode.Text;
        ASTreeViewNode node = this.astvMyTree.FindByValue(curNodeValue);
        if (node.ParentNode != null)
            this.txtNewParentNode.Text = node.ParentNode.NodeValue;
       

    }

    protected void btnPostBackTrigger2_Click(object sender, EventArgs e)
    {


    }

    protected void btnPostBackTrigger3_Click(object sender, EventArgs e)
    {

    }

    //protected void btn_Click(object sender, EventArgs e)
    //{
    //    Session["selected"] = txtCurrentNode.Text;
    //    string xx=   Session["selected"].ToString();

    //}
   
}
