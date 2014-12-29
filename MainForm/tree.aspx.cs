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
using Geekees.Common.Utilities.Xml;
using Geekees.Common.Controls;
using Geekees.Common.Controls.Demo;
using System.Xml;
public partial class WebForms2_tree : System.Web.UI.Page
{
    Session_CS Session_CS = new Session_CS();
    #region overrided methods
		/// <summary>
		/// OnInit
		/// </summary>
		/// <param name="e"></param>
        /// 
    private void InitializeComponent()
    {

    }
		protected override void OnInit( EventArgs e )
		{
			InitializeComponent();
			base.OnInit( e );
		}
		#endregion

		#region event handlers (Page_Load etc...)

		/// <summary>
		/// Page load logic
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void Page_Load( object sender, EventArgs e )
		{
			if( !IsPostBack )
				GenerateTree();
		}

		protected override void OnPreRender( EventArgs e )
		{
			base.OnPreRender( e );

			//link the css file
			this.lASTreeViewThemeCssFile.Text = "<link id='astreeviewcssfile' href='' type='text/css' rel='stylesheet' />";

			string script = string.Format( "document.getElementById('astreeviewcssfile').href='{0}'", this.astvMyTree.ThemeCssFile );
			this.ClientScript.RegisterStartupScript( this.GetType(), "js" + Guid.NewGuid().ToString(), script, true );

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
        DT_Tree = General_Helping.GetDataTable("select File_ID,File_name,Parent_ID from Departments_Documents where Proj_Proj_id =" + CDataConverter.ConvertToInt(Session_CS.Project_id.ToString()) + " order by TheOrder asc");

        ASTreeViewDataTableColumnDescriptor descripter = new ASTreeViewDataTableColumnDescriptor("File_name"
            , "File_ID"
            , "Parent_ID");
		//descripter.AddSingleQuotationOnQuery = false;
        this.astvMyTree.DataSourceDescriptor = descripter;
        this.astvMyTree.DataSource = DT_Tree;
		this.astvMyTree.DataBind();
        
		
	}
	#endregion

    protected void btnPostBackTrigger_Click(object sender, EventArgs e)
    {
        string curNodeValue = this.txtCurrentNode.Text;
        string newParentValue = this.txtNewParentNode.Text;
        string prevNodeVal = this.txtCurrentNode.Text;
        ASTreeViewNode node = this.astvMyTree.FindByValue(newParentValue);
        bool isFirst = false;
        foreach (ASTreeViewNode child in node.ChildNodes)
        {
            prevNodeVal = curNodeValue;
            curNodeValue = child.NodeValue;
            if (this.txtCurrentNode.Text == child.NodeValue)
            {
                DataTable Prev_Node = new DataTable();
                int Prev_Order;
                if (!isFirst)
                {
                    Prev_Node = General_Helping.GetDataTable("select * from Departments_Documents where File_ID =" + CDataConverter.ConvertToInt(child.NodeValue));
                    if (Prev_Node.Rows.Count > 0)
                    {
                        General_Helping.ExcuteQuery("UPDATE Departments_Documents set TheOrder=0, Parent_ID=" + newParentValue + " where File_ID =" + CDataConverter.ConvertToInt(curNodeValue));
                        General_Helping.ExcuteQuery("UPDATE Departments_Documents set TheOrder=TheOrder+1 where Parent_ID =" + CDataConverter.ConvertToInt(newParentValue) + " and File_ID<>" + CDataConverter.ConvertToInt(curNodeValue));
                    }
                }
                else
                {
                    Prev_Node = General_Helping.GetDataTable("select * from Departments_Documents where File_ID =" + CDataConverter.ConvertToInt(prevNodeVal));
                    if(Prev_Node.Rows.Count > 0)
                    {
                        Prev_Order = CDataConverter.ConvertToInt(Prev_Node.Rows[0]["TheOrder"].ToString()) + 1;
                        int curOrder = Prev_Order + 1;
                        General_Helping.ExcuteQuery("UPDATE Departments_Documents set TheOrder=" + Prev_Order + ", Parent_ID=" + newParentValue + " where File_ID =" + CDataConverter.ConvertToInt(curNodeValue));
                        General_Helping.ExcuteQuery("UPDATE Departments_Documents set TheOrder=TheOrder+" + Prev_Order + " where Parent_ID =" + CDataConverter.ConvertToInt(newParentValue) + " and TheOrder>=" + Prev_Order + " and File_ID<>" + CDataConverter.ConvertToInt(curNodeValue));
                    }
                }
                break;
            }
            isFirst = true;
        }

        string curNodeValue2 = curNodeValue;
        string prevNodeVal2 = prevNodeVal;
    }
    protected void btnRightLeft_Click(object sender, EventArgs e)
    {
        ASTreeViewTheme rightLeft = new ASTreeViewTheme();
        rightLeft.BasePath = "~/javascript/astreeview/themes/right-left/";
        rightLeft.CssFile = "right-left.css";
        this.astvMyTree.Theme = rightLeft;
        this.astvMyTree.EnableTreeLines = true;
        this.astvMyTree.EnableRightToLeftRender = true;
    }
}
