using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Collections.Generic;
using System.ComponentModel;
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
//using Geekees.Common.Controls.Demo;
using System.Xml;
using Dates;
using Microsoft.Office.Interop.MSProject;
using System.Reflection;
using System.Data.Sql;



public partial class WebForms2_Department_manage : System.Web.UI.Page
{

    private string sql_Connection = Database.ConnectionString;
    General_Helping Obj_General_Helping = new General_Helping();
    //Session_CS Session_CS = new Session_CS(); 
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GenerateTree();
            //  Fillddl();

        }
    }


    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);

        //link the css file
        // this.lASTreeViewThemeCssFile.Text = "<link id='astreeviewcssfile' href='' type='text/css' rel='stylesheet' />";

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
    private void Clear_Control()
    {

        hid_id.Value =
        txt_name.Text = "";
        txtCurrentNode.Text = "";
        txtNewParentNode.Text = "";
        txt_update.Text = "";

    }

    protected void btnPostBackTrigger2_Click(object sender, EventArgs e)
    {


    }

    protected void btnPostBackTrigger3_Click(object sender, EventArgs e)
    {

    }

    protected void btn_New_Click(object sender, EventArgs e)
    {

        txtCurrentNode.Text =
        txtNewParentNode.Text = "";
        astvMyTree.ClearNodesSelection();

        Clear_Control();
    }

    protected void btn_Update_Click(object sender, EventArgs e)
    {

        ASTreeViewNode node = this.astvMyTree.FindByValue(txtCurrentNode.Text);


        if (node != null)
        {
            fill_actv_details();

            //if(txt_name.Text != "")
            //{
            //Departments_DT obj = new Departments_DT();
            //obj.Dept_id = CDataConverter.ConvertToInt(txtCurrentNode.Text);
            //obj.Dept_name = txt_name.Text;
            //obj.foundation_id = Session_CS.foundation_id;
            //obj.Dept_id = Departments_DB.Save(obj);
            //GenerateTree();
            //Clear_Control();
            //}
            //else 
            //{
            //      Page.RegisterStartupScript("Sucess", "<script language=javascript>alert(' يجب إستكمال البيانات أولا')</script>");
            //}
        }
        else
        {
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('يجب إختيار عنصر  من الشجرة أولا')</script>");

        }
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        //if (txt_name.Text != "" && ddltype.SelectedValue!="" && ddltype.SelectedValue!="0")
        if (txt_name.Text != "")
        {
            Departments_DT obj = new Departments_DT();
            obj.Dept_id = CDataConverter.ConvertToInt(hid_id.Value);
            obj.Dept_name = txt_name.Text;
            //   obj.Dept_type = CDataConverter.ConvertToInt(ddltype.SelectedValue);
            obj.Dept_type = 0;
            if (obj.Dept_id == 0 && obj.Dept_id != null)
            {
                obj.Dept_parent_id = CDataConverter.ConvertToInt(txtCurrentNode.Text);
            }
            else
            {
                obj.Dept_parent_id = CDataConverter.ConvertToInt(txt_update.Text);
            }
            obj.foundation_id = Session_CS.foundation_id;

            obj.Dept_id = Departments_DB.Save(obj);
            GenerateTree();
            Clear_Control();


            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم الحفظ بنجاح')</script>");



        }
        else
        {
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert(' يجب إستكمال البيانات أولا')</script>");

        }


    }

    //protected void Fillddl()
    //{




    //    string Sql = "select * from Department_Type";
    //    DataTable dt = General_Helping.GetDataTable(Sql);
    //    ddltype.DataSource = dt;
    //    ddltype.DataTextField = "Deptt_Desc";
    //    ddltype.DataValueField = "Deptt_ID";
    //    ddltype.DataBind();
    //    ddltype.Items.Insert(0, new ListItem("إختر النوع ", "0"));

    //}

    protected void btn_New_Delete_Click(object sender, EventArgs e)
    {
        if (CDataConverter.ConvertToInt(txtCurrentNode.Text) <= 0)
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('يجب إختيار عنصر الحذف من الشجرة أولا')</script>");

        else
        {
            ASTreeViewNode node = this.astvMyTree.FindByValue(txtCurrentNode.Text);


            if (node != null && node.ChildNodes.Count == 0)
            {
                Employee_Data_DT dt = Employee_Data_DB.Select_EmployeeByDeptID(CDataConverter.ConvertToInt(txtCurrentNode.Text));

                if (dt != null && dt.PMP_ID > 0)
                {
                    Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لا يمكن حذف هذه الإدارة حيث أن لديها موظفين')</script>");
                }
                else
                {
                    // Departments_DB.Delete(CDataConverter.ConvertToInt(txtCurrentNode.Text));

                    Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم الحذف بنجاح')</script>");
                }

                Clear_Control();
                GenerateTree();
            }

            if (node.ChildNodes.Count != 0)
            {
                Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لا يمكن حذف هذا العنصر حيث أن لديه عناصر فرعية')</script>");
            }

        }
    }

    protected void astvMyTree_OnSelectedNodeChanged(object src, ASTreeViewNodeSelectedEventArgs e)
    {
        //  fill_actv_details();
    }

    private void fill_actv_details()
    {
        string curNodeValue = this.txtCurrentNode.Text;
        this.txtCurrentNode.BackColor = System.Drawing.Color.SkyBlue;
        ASTreeViewNode node = this.astvMyTree.FindByValue(curNodeValue);

        Departments_DT obj = Departments_DB.SelectByID(CDataConverter.ConvertToInt(txtCurrentNode.Text));
        txt_name.Text = obj.Dept_name;
        hid_id.Value = obj.Dept_id.ToString();
        txt_update.Text = obj.Dept_parent_id.ToString();

    }



}
