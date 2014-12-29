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
//using Geekees.Common.Controls;
//using Geekees.Common.Controls.Demo;
using System.Xml;
using Geekees.Common.Controls;

public partial class WebForms_Deprt_Documnts : System.Web.UI.Page
{
    Session_CS Session_CS = new Session_CS();
    General_Helping Obj_General_Helping = new General_Helping();
    #region overrided methods
    /// <summary>
    /// OnInit
    /// </summary>
    /// <param name="e"></param>
    /// 
    private void InitializeComponent()
    {

    }
    protected override void OnInit(EventArgs e)
    {
        InitializeComponent();
        base.OnInit(e);
    }
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //if (Session_CS.Project_id != null && CDataConverter.ConvertToInt(Session_CS.Project_id.ToString()) > 0)
            //{
            fil_Grid();
            Fil_ddl_by_Parent_ID();
            GenerateTree();
        }
    }
    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);

        //link the css file
        this.lASTreeViewThemeCssFile.Text = "<link id='astreeviewcssfile' href='' type='text/css' rel='stylesheet' />";

        string script = string.Format("document.getElementById('astreeviewcssfile').href='{0}'", this.astvMyTree.ThemeCssFile);
        this.ClientScript.RegisterStartupScript(this.GetType(), "js" + Guid.NewGuid().ToString(), script, true);

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
        string sql = "select File_ID,File_name,Parent_ID from Departments_Documents where 1=1 ";
        if (CDataConverter.ConvertToInt(Session_CS.Project_id.ToString()) > 0)
        {
            sql += " AND Proj_Proj_id = " + int.Parse(Session_CS.Project_id.ToString());
        }
        else
            sql += " AND Proj_Proj_id = 0 AND Dept_ID = " + int.Parse(Session_CS.dept_id.ToString());

        sql += " ORDER By " + orderType.Value + " ASC";

        DT_Tree = General_Helping.GetDataTable(sql);
        
        ASTreeViewDataTableColumnDescriptor descripter = new ASTreeViewDataTableColumnDescriptor("File_name"
            , "File_ID"
            , "Parent_ID");
        this.astvMyTree.DataSourceDescriptor = descripter;
        this.astvMyTree.DataSource = DT_Tree;
        this.astvMyTree.DataBind();
    }

    protected void btnPostBackTrigger_Click(object sender, EventArgs e)
    {
        string curNodeValue = this.txtCurrentNode.Text;
        string newParentValue = this.txtNewParentNode.Text;
        string prevNodeVal = this.txtCurrentNode.Text;
        ASTreeViewNode node = this.astvMyTree.FindByValue(newParentValue);
        bool isFirst = false;
        if (CDataConverter.ConvertToInt(newParentValue)<=0)
        {
            General_Helping.ExcuteQuery("UPDATE Departments_Documents set Parent_ID=0 where File_ID =" + CDataConverter.ConvertToInt(curNodeValue));
        }
        else
        {
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
        }
    }
    private void fil_Grid()  {}

    private void Fill_Controll(int id)
    {
        try
        {
            Departments_Documents_DT obj = Departments_Documents_DB.SelectByID(id);
            hidden_File_ID.Value = obj.File_ID.ToString();
            txt_File_Desc.Text = obj.File_Desc;
            txtFileName.Text = obj.File_name;
            TheOrder.Text = obj.TheOrder.ToString();
            hidden_File_ext.Value = obj.File_ext;
            ddl_File_Type.SelectedValue = obj.File_Type.ToString();
            if (obj.Parent_ID > 0)
                ddl_Parent_ID.SelectedValue = obj.Parent_ID.ToString();
            else
                ddl_Parent_ID.SelectedIndex = 0;
            hidden_File_Sytem_Name.Value = obj.File_Sytem_Name;
            hidden_Page_Count.Value = obj.Page_Count.ToString();

            //if (obj.upload_on_sector == 1)
            //{
            //    chk_upload.Checked = true;
            //}
            //else chk_upload.Checked = false;
            if (obj.File_data != null || !string.IsNullOrEmpty(obj.File_Sytem_Name))
            {
                A2.Visible = true;
                A2.HRef = "ALL_Document_Details.aspx?type=deprtfile&id=" + id;
            }
            else
                A2.Visible = false;
        }
        catch
        { }
    }

    public string Get_Type(object obj)
    {
        string str = obj.ToString();
        if (str == "1")
            return "Word";
        else if (str == "2")
            return "Excel";
        else if (str == "3")
            return "PDF";
        else if (str == "4")
            return "IMAGE";
        else if (str == "5")
            return "PowerPoint";
        else return "";
    } 



    protected void btn_New_Click(object sender, EventArgs e)
    {
        btn_Doc.Text = "حفظ";
        Clear_Contrl();
        GenerateTree();
    }

    private void Clear_Contrl()
    {
        hidden_File_ID.Value =
        mode.Value =
        txt_File_Desc.Text =
        txtFileName.Text =
        TheOrder.Text =
        hidden_File_Sytem_Name.Value =
        hidden_File_ext.Value =
        hidden_Page_Count.Value = "";
        ddl_Parent_ID.SelectedIndex = 0;
        A2.Visible = false;
        btn_Doc.Text = "حفظ";
    } 


    protected void btn_Doc_Click(object sender, EventArgs e)
    {
        int operation;
        if (CDataConverter.ConvertToInt(hidden_File_ID.Value) == 0)
            operation = (int)Project_Log_DB.Action.add;
        else
            operation = (int)Project_Log_DB.Action.edit;

        Departments_Documents_DT obj = new Departments_Documents_DT();
        obj.File_ID = CDataConverter.ConvertToInt(hidden_File_ID.Value);
        obj.File_Desc = txt_File_Desc.Text;
        obj.File_name = txtFileName.Text;
        obj.TheOrder = CDataConverter.ConvertToInt(TheOrder.Text);
        obj.File_Type = CDataConverter.ConvertToInt(ddl_File_Type.SelectedValue);
        obj.Dept_ID = CDataConverter.ConvertToInt(Session_CS.dept_id.ToString());
        obj.Emp_ID = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
        obj.Parent_ID = CDataConverter.ConvertToInt(ddl_Parent_ID.SelectedValue);
        obj.File_Sytem_Name = hidden_File_Sytem_Name.Value;
        obj.File_ext = hidden_File_ext.Value;
        obj.Entery_DT = System.DateTime.Now.ToString("dd/MM/yyyy");
        obj.Page_Count = CDataConverter.ConvertToInt(hidden_Page_Count.Value);
        if (Session_CS.Project_id != null && CDataConverter.ConvertToInt(Session_CS.Project_id.ToString()) > 0)
            obj.Proj_Proj_id = CDataConverter.ConvertToInt(Session_CS.Project_id.ToString());
        obj.upload_on_sector = 0;
        //if (chk_upload.Checked == true)
        //{
        //    obj.upload_on_sector = 1;
        //}
        //else
        //    obj.upload_on_sector = 0;
       

        obj.File_ID = Departments_Documents_DB.Save(obj);
        hidden_File_ID.Value = obj.File_ID.ToString();
        Project_Log_DB.FillLog(CDataConverter.ConvertToInt(hidden_File_ID.Value), operation, Project_Log_DB.operation.Departments_Documents);

      

        if (FileUpload1.HasFile)
        {

            string DocName = FileUpload1.FileName;
            int dotindex = DocName.LastIndexOf(".");
            string type = DocName.Substring(dotindex, DocName.Length - dotindex);

            //if (type.ToLower().Contains("pdf"))
            //{
            Stream myStream;
            int fileLen;
            StringBuilder displayString = new StringBuilder();
            fileLen = FileUpload1.PostedFile.ContentLength;
            Byte[] Input = new Byte[fileLen];
            myStream = FileUpload1.FileContent;
            myStream.Read(Input, 0, fileLen);

            if (Input.Length < 8000000)
            {
                SqlCommand cmd = new SqlCommand();
                SqlConnection con = new SqlConnection(Database.ConnectionString);
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = " update Departments_Documents set File_data = @File_data where File_ID =@File_ID";
                cmd.Parameters.Add("@File_data", SqlDbType.VarBinary);
                cmd.Parameters.Add("@File_ID", SqlDbType.BigInt);
                //cmd.Parameters.Add("@File_ext", SqlDbType.NVarChar);

                cmd.Parameters["@File_data"].Value = Input;
                cmd.Parameters["@File_ID"].Value = obj.File_ID;
                //cmd.Parameters["@File_ext"].Value = type;
                con.Open();
                cmd.ExecuteScalar();
                con.Close();
                obj.File_Sytem_Name = "";
            }
            else
            {
                obj.File_data = null;

                string filename = "";
                string guid = System.Guid.NewGuid().ToString();
                filename = FileUpload1.PostedFile.FileName;
                filename = guid + filename.Substring(filename.LastIndexOf("\\") + 1);
                string path = Server.MapPath("~\\Uploads\\doc") + "\\";
                string fullpath = path + filename;
                FileUpload1.PostedFile.SaveAs(fullpath);

                obj.File_Sytem_Name = filename;
            }

            if (type.ToLower().Contains("pdf"))
            {
                iTextSharp.text.pdf.PdfReader reader;
                reader = new iTextSharp.text.pdf.PdfReader(Input);
                
                obj.Page_Count = reader.NumberOfPages;
            }
            else
                obj.Page_Count = 1;
            obj.File_ext = type;
            Departments_Documents_DB.Save(obj);
           
            //}
            //else
            //    Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('يجب ادخال pdf  ')</script>");



        }
        if (obj.File_ID > 0)
        {
            Clear_Contrl();
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم الحفظ بنجاح')</script>");
        }
        //A2.Visible = false;
        fil_Grid();
        Fil_ddl_by_Parent_ID();
        GenerateTree();
        btn_Doc.Text = "حفظ";
       
    }

    protected void GrdView_Documents_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditItem")
        {


        }

        if (e.CommandName == "RemoveItem")
        {

        }
    }

    protected void Fil_ddl_by_Parent_ID()
    {
        DataTable DT4 = new DataTable();
        string sql = "select File_ID,File_name,Parent_ID from Departments_Documents where 1=1 ";
        if (CDataConverter.ConvertToInt(Session_CS.Project_id.ToString()) > 0)
        {
            sql += " AND Proj_Proj_id = " + int.Parse(Session_CS.Project_id.ToString());
        }
        else
            sql += " AND Proj_Proj_id = 0 AND Dept_ID = " + int.Parse(Session_CS.dept_id.ToString());
        DT4 = General_Helping.GetDataTable(sql);
        Obj_General_Helping.SmartBindDDL(ddl_Parent_ID, DT4, "File_ID", "File_name", "....اختر الملف الرئيسى....");
        ddl_Parent_ID.SelectedIndex = 0;

    }

    private void Deleted_Rec(int File_ID)
    {
        DataTable DT = new DataTable();
        DT = General_Helping.GetDataTable("select File_ID,File_name,Parent_ID from Departments_Documents where Parent_ID =" + File_ID);

        if (DT.Rows.Count != 0)
        {
            foreach (DataRow row in DT.Rows)
            {
                General_Helping.ExcuteQuery("Delete From Departments_Documents where File_ID =" + row["File_ID"].ToString());
                Deleted_Rec(CDataConverter.ConvertToInt(row["File_ID"].ToString()));
            }
        }
    }

    protected void btn_Show_Click(object sender, EventArgs e)
    {
        string curNodeValue = this.txtCurrentNode.Text;
        Project_Log_DB.FillLog(CDataConverter.ConvertToInt(curNodeValue), (int)Project_Log_DB.Action.read, Project_Log_DB.operation.Departments_Documents);
        if (CDataConverter.ConvertToInt(curNodeValue) > 0)
        {
            Page.RegisterStartupScript("error", "<script language=javascript>window.open('Open_Documents.aspx?id=" + curNodeValue + "');</script>");
        }
    }

    protected void btn_Delte_Click(object sender, EventArgs e)
    {
        string curNodeValue = this.txtCurrentNode.Text;
        if (CDataConverter.ConvertToInt(curNodeValue) > 0)
        {
            Departments_Documents_DB.Delete(CDataConverter.ConvertToInt(curNodeValue));
            GenerateTree();
            Deleted_Rec(CDataConverter.ConvertToInt(curNodeValue));
            Fil_ddl_by_Parent_ID();
            Clear_Contrl();

        }
    }

    protected void btnPostBackTrigger2_Click(object sender, EventArgs e)
    {
        string curNodeValue = this.txtCurrentNode.Text;

        if (CDataConverter.ConvertToInt(curNodeValue) > 0)
        {
            btn_Doc.Text = "تعديل";
            hidden_File_ID.Value = curNodeValue;
            mode.Value = "edit";
            Fill_Controll(CDataConverter.ConvertToInt(curNodeValue));
        }
    }

    protected void btnPostBackTrigger3_Click(object sender, EventArgs e)
    {
         string curFileValue = hidden_File_ID.Value;

        if (CDataConverter.ConvertToInt(curFileValue) > 0)
        {
            Project_Log_DB.FillLog(CDataConverter.ConvertToInt(curFileValue), (int)Project_Log_DB.Action.read, Project_Log_DB.operation.Departments_Documents);
            //FillLog(CDataConverter.ConvertToInt(curFileValue), "read");
        }
    }

     
    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        orderType.Value = RadioButtonList1.SelectedValue;
        GenerateTree();
    }

    
}
