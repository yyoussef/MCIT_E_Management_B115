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
using System.IO;
using System.Text;
using System.Data.SqlClient;
using Geekees.Common.Utilities.Xml;
using Geekees.Common.Controls;
using System.Xml;
using Dates;
using Microsoft.Office.Interop.MSProject;
using System.Reflection;

public partial class UserControls_Planning_Stages : System.Web.UI.UserControl
{
    private string sql_Connection = Database.ConnectionString;
    //Session_CS Session_CS = new Session_CS();
    General_Helping Obj_General_Helping = new General_Helping();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillddrop();
            PopulateTreeview();
        }
    }

    public void get_project_activity()
    {

    }
    private void PopulateTreeview()
    {
        this.TreeView1.Nodes.Clear();
        HierarchyTrees hierarchyTrees = new HierarchyTrees();
        HierarchyTrees.HTree objHTree = null;
        SqlConnection connection = new SqlConnection(sql_Connection);
        SqlDataAdapter adp = new SqlDataAdapter();
        SqlCommand command = new SqlCommand("get_active", connection);
        command.CommandType = CommandType.StoredProcedure;
        DataTable dt = new DataTable();
        SqlParameter param = new SqlParameter("@proj_id", CDataConverter.ConvertToInt(Session_CS.Project_id.ToString()));
        command.Parameters.Add(param);
        adp.SelectCommand = command;
        adp.Fill(dt);
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            objHTree = new HierarchyTrees.HTree();
            objHTree.LevelDepth = CDataConverter.ConvertToInt(dt.Rows[i]["PActv_Parent"].ToString());
            objHTree.NodeID = CDataConverter.ConvertToInt(dt.Rows[i]["PActv_ID"].ToString());
            objHTree.UnderParent = CDataConverter.ConvertToInt(dt.Rows[i]["PActv_Parent"].ToString());
            objHTree.NodeDescription = dt.Rows[i]["PActv_Desc"].ToString();
            hierarchyTrees.Add(objHTree);

        }


        foreach (HierarchyTrees.HTree hTree in hierarchyTrees)
        {
            //Filter the collection HierarchyTrees based on 
            //Iteration as per object Htree Parent ID 
            HierarchyTrees.HTree parentNode = hierarchyTrees.Find
            (delegate(HierarchyTrees.HTree emp)
           { return emp.NodeID == hTree.UnderParent; });
            //If parent node has child then populate the leaf node.
            if (parentNode != null)
            {
                foreach (TreeNode tn in TreeView1.Nodes)
                {
                    //If single child then match Node ID with Parent ID
                    if (tn.Value == parentNode.NodeID.ToString())
                    {
                        tn.ChildNodes.Add(new TreeNode
                        (hTree.NodeDescription.ToString(), hTree.NodeID.ToString()));
                    }

                    //If Node has multiple child ,
                    //recursively traverse through end child or leaf node.
                    if (tn.ChildNodes.Count > 0)
                    {
                        foreach (TreeNode ctn in tn.ChildNodes)
                        {
                            RecursiveChild(ctn, parentNode.NodeID.ToString(), hTree);
                        }
                    }
                }
            }
            //Else add all Node at first level 
            else
            {
                TreeView1.Nodes.Add(new TreeNode(hTree.NodeDescription, hTree.NodeID.ToString()));
                //actv_id = hTree.NodeID.ToString();


            }
        }
        TreeView1.ExpandAll();
    }
    public void RecursiveChild(TreeNode tn, string searchValue, HierarchyTrees.HTree hTree)
    {
        if (tn.Value == searchValue)
        {
            tn.ChildNodes.Add(new TreeNode
            (hTree.NodeDescription.ToString(), hTree.NodeID.ToString()));
        }
        if (tn.ChildNodes.Count > 0)
        {
            foreach (TreeNode ctn in tn.ChildNodes)
            {
                RecursiveChild(ctn, searchValue, hTree);
            }
        }
    }


    public void OnCheckChanged(Object sender, TreeNodeEventArgs e)
    {

    }

    private void fillddrop()
    {
        DataTable dt = Stages_DB.SelectAll();
        drop_stage.DataSource = dt;
        drop_stage.DataBind();
        ListItem litem = new ListItem("-- اختر المرحلة  --", "0");
        litem.Selected = true;
        drop_stage.Items.Insert(0, litem);



    }
    protected override void OnPreRender(EventArgs e)
    {


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

    protected void btn_Click(object sender, EventArgs e)
    {

        int stage_id = 0;
        string actv_id = "0";
        if (drop_stage.SelectedValue != "0")
        {
            stage_id = CDataConverter.ConvertToInt(drop_stage.SelectedValue);
        }

        if (TreeView1.CheckedNodes.Count > 0 && drop_stage.SelectedValue != "0")
        {
            //WhatsChecked.Text = "The checked values are:<ul>";
            // Activities_Stages_DB.Deletebystageid(stage_id,CDataConverter.ConvertToInt(Session_CS.Project_id.ToString()));
            string Sql_Delete = "delete from Activities_Stages where stage_id =" + stage_id + " and proj_id = " + CDataConverter.ConvertToInt(Session_CS.Project_id.ToString());
            General_Helping.ExcuteQuery(Sql_Delete);
            foreach (TreeNode item in TreeView1.CheckedNodes)
            {

                actv_id = item.Value;
                Activities_Stages_DT AS_dt = Activities_Stages_DB.Activities_Stages_ByID_Select(CDataConverter.ConvertToInt(actv_id), stage_id);
                if (AS_dt.id > 0)
                {
                    AS_dt.id = AS_dt.id;
                }
                else
                {
                    AS_dt.id = 0;
                }
                AS_dt.Actv_ID = CDataConverter.ConvertToInt(actv_id);
                AS_dt.proj_id = CDataConverter.ConvertToInt(Session_CS.Project_id.ToString());
                AS_dt.stage_id = stage_id;
                int row = Activities_Stages_DB.Save(AS_dt);
                ShowAlertMessage("  لقد تم الحفظ بنجاح");

            }

        }

        else
        {
            //Activities_Stages_DT AS_dt = Activities_Stages_DB.Activities_Stages_ByID_Select(CDataConverter.ConvertToInt(actv_id), stage_id);
            //if(AS_dt.id > 0)
            //{ 


            //} 
            ShowAlertMessage("  يجب اختيار المرحلة و نشاط");
            return;

        }

    }

    protected void drop_stage_SelectedIndexChanged(object sender, EventArgs e)
    {

        int stage_id = CDataConverter.ConvertToInt(drop_stage.SelectedValue);
        DataTable AS_dt = Activities_Stages_DB.Activities_Stages_ByProjID_Select(CDataConverter.ConvertToInt(Session_CS.Project_id.ToString()), stage_id);
        foreach (TreeNode ptnode in TreeView1.Nodes)
        {
            Rec_Childclear(ptnode);
        }

        if (AS_dt.Rows.Count > 0)
        {
            for (int i = 0; i < AS_dt.Rows.Count; i++)
            {

                foreach (TreeNode ptnode in TreeView1.Nodes)
                {


                    if (ptnode.Value == AS_dt.Rows[i]["Actv_ID"].ToString())
                    {

                        ptnode.Checked = true;
                    }
                    Rec_Child(ptnode, AS_dt.Rows[i]["Actv_ID"].ToString());





                }

            }


        }
        else
        {
            foreach (TreeNode ptnode in TreeView1.Nodes)
            {
                ////Rec_Childclear(ptnode);
                //ptnode.Parent.Checked = false;
                //ptnode.Parent.ChildNodes.Clear();


            }
        }

    }
    public void Rec_Childclear(TreeNode tn)
    {
        tn.Checked = false;


        foreach (TreeNode ctn in tn.ChildNodes)
        {

            { Rec_Childclear(ctn); }
        }

    }
    public void Rec_Child(TreeNode tn, string Value)
    {
        // tn.Checked = true;


        foreach (TreeNode ctn in tn.ChildNodes)
        {
            if (ctn.Value == Value)
                ctn.Checked = true;

            else
                Rec_Child(ctn, Value);


        }

    }


    private void node_AfterCheck(object sender, System.Windows.Forms.TreeViewEventArgs e)
    {
        // The code only executes if the user caused the checked state to change.
        if (e.Action != System.Windows.Forms.TreeViewAction.Unknown)
        {
            if (e.Node.Nodes.Count > 0)
            {
                /* Calls the CheckAllChildNodes method, passing in the current 
                Checked value of the TreeNode whose checked state changed. */
                //this.CheckAllChildNodes(e.Node, e.Node.Checked);
            }
        }
    }


}
