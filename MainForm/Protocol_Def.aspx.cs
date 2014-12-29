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
using DBL;
using System.Text;
using System.Data.SqlClient;
using System.IO;

public partial class WebForms_Protocol_Def : System.Web.UI.Page
{
    General_Helping Obj_General_Helping = new General_Helping();
    Session_CS Session_CS = new Session_CS();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            btn_New.Visible = false;
            Fil_Dll();
            if (Request["prot_id"] != null)
            {
                Fill_Controll(CDataConverter.ConvertToInt(Request["prot_id"]));
                Fil_ddl_by_Parent_ID();
                LoadX();
                Fil_Grid_Documents();
                Fil_Grid_periods();
                if (Session_CS.UROL_UROL_ID.ToString() == "2")
                {
                    Change_ModeRead_only();
                }
            }
            else
            {

                Fil_Grid();
            }
            

        }
    }

    private void LoadX()
    {
        if (CDataConverter.ConvertToInt(hidden_Protocol_ID.Value) > 0)
        {
            Tree_Files.Nodes.Clear();
            DataTable DT_Tree = new DataTable();
            DT_Tree = General_Helping.GetDataTable("select * from Protocol_Documents where Protocol_ID =" + CDataConverter.ConvertToInt(hidden_Protocol_ID.Value));

            TreeNode nodeX = new TreeNode("الوثائق", "0");
            Tree_Files.Nodes.Add(nodeX);
            LoadTree(DT_Tree);
        }
    }
    private void LoadTree(DataTable TreeTable)
    {
        for (int i = TreeTable.Rows.Count - 1; i >= 0; i--)
        {
            TreeNode treeNode = new TreeNode(TreeTable.Rows[i]["File_Name"].ToString(), TreeTable.Rows[i]["ID"].ToString());
            if (CDataConverter.ConvertToInt(TreeTable.Rows[i]["Parent_ID"].ToString()) == 0)
            {
                Tree_Files.Nodes[0].ChildNodes.Add(treeNode);

            }
            LoadSubTree(TreeTable, treeNode);
        }
    }

    private void LoadSubTree(DataTable TreeTable, TreeNode treeNode)
    {
        DataTable DT = new DataTable();
        DT = General_Helping.GetDataTable("select * from Protocol_Documents where Parent_ID =" + CDataConverter.ConvertToInt(treeNode.Value));

        if (DT.Rows.Count != 0)
        {
            foreach (DataRow row in DT.Rows)
            {
                TreeNode newNode = new TreeNode(row["File_Name"].ToString(), row["ID"].ToString());
                treeNode.ChildNodes.Add(newNode);
                LoadSubTree(TreeTable, newNode);
            }
        }
    }

    private void Change_ModeRead_only()
    {
        //txt_Total_Balance.Enabled =
        //    txt_Period.Enabled =
        ddl_PMP_ID.Enabled =

    ddl_Org_ID.Enabled =
    txt_Signt_End_DT.Enabled =
    txt_Signt_Str_DT.Enabled =
    ddl_Type.Enabled =
    txt_Name.Enabled = false;

        btn_New.Visible =
            Label15.Visible =
            Label17.Visible =
            FileUpload1.Visible =
            Label18.Visible =
            txtFileName.Visible =
            btn_Doc.Visible =
            btn_period_balance.Visible =
            GrdView_Documents.Columns[1].Visible =
            GrdView_Documents.Columns[2].Visible =
            // grdView_Projects.Columns[1].Visible =
            //grdView_Projects.Columns[2].Visible =

        BtnSave.Visible = false;

    }
    private void afterSave()
    {
        ddl_PMP_ID.Enabled =

       ddl_Org_ID.Enabled =
       txt_Signt_End_DT.Enabled =
       txt_Signt_Str_DT.Enabled =
       ddl_Type.Enabled =
       txt_Total_Balance_LE.Enabled =
       txt_Total_Balance_US.Enabled =
       txtAuthortyApprovDate.Enabled =
       txtsigndate.Enabled =
       txtApprovalNum.Enabled =
       txtApprovalAuthority.Enabled =
       txt_Name.Enabled = false;
        BtnSave.Visible = false;
        btn_New.Visible = true;
        btn_period_balance.Enabled = true;
        btn_Doc.Enabled = true;
    }
    private void afterNew()
    {
        ddl_PMP_ID.Enabled =

       ddl_Org_ID.Enabled =
       txt_Signt_End_DT.Enabled =
       txt_Signt_Str_DT.Enabled =
       ddl_Type.Enabled =
       txt_Total_Balance_LE.Enabled =
       txt_Total_Balance_US.Enabled =
       txtAuthortyApprovDate.Enabled =
       txtsigndate.Enabled =
       txtApprovalNum.Enabled =
       txtApprovalAuthority.Enabled =
       txt_Name.Enabled = true;
        BtnSave.Visible = true;
        btn_New.Visible = false;
        btn_period_balance.Enabled = false;
        btn_Doc.Enabled = false;
    }

    //protected override void OnInit(EventArgs e)
    //{




    //    //string strConString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();

    //    //obj_Sql_Con = new System.Data.SqlClient.SqlConnection(strConString);

    //    //obj_Sql_Con.Open();

    //    ////end//

    //    //#region BROWSER FOR departments

    //    //Smart_Search_Proj.sql_Connection = Universal.GetConnectionString();
    //    //Smart_Search_Proj.Query = "SELECT Proj_id, Proj_Title FROM Project";
    //    //Smart_Search_Proj.Value_Field = "Proj_id";
    //    //Smart_Search_Proj.Text_Field = "Proj_Title";
    //    //Smart_Search_Proj.DataBind();
    //    ////this.Smrt_Srch_DropDep.Value_Handler += new Smart_Search.Delegate_Selected_Value(MOnMember_Data);
    //    ////Inbox_organization.SelectedValue;


    //    //#endregion


    //    base.OnInit(e);
    //}


    private void Fil_Dll()
    {

        DataTable DT = new DataTable();
        DT = General_Helping.GetDataTable("select * from Organization");

        Obj_General_Helping.SmartBindDDL(ddl_Org_ID, DT, "Org_ID", "Org_Desc", "....اختر اسم الجهة المشاركة ....");
        DataTable DT2 = new DataTable();
        DT2 = General_Helping.GetDataTable("select * from EMPLOYEE where rol_rol_id = 3 ");
        Obj_General_Helping.SmartBindDDL(ddl_PMP_ID, DT2, "PMP_ID", "pmp_name", "....اختر المسئول ....");


        DataTable DT3 = new DataTable();
        DT3 = General_Helping.GetDataTable("select * from Protocol_Type");
        Obj_General_Helping.SmartBindDDL(ddl_Type, DT3, "Type_ID", "Type_Name", "....اختر نوع....");





    }


    protected void Fil_ddl_by_Parent_ID()
    {
        DataTable DT4 = new DataTable();
        DT4 = General_Helping.GetDataTable("select * from Protocol_Documents where Protocol_ID =" + CDataConverter.ConvertToInt(hidden_Protocol_ID.Value));
        Obj_General_Helping.SmartBindDDL(ddl_Parent_ID, DT4, "ID", "File_Name", "....اختر الملف الرئيسى....");

    }



    protected void btn_New_Click(object sender, EventArgs e)
    {
        Clear_Cntrl();
        afterNew();


    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (ddl_Org_ID.SelectedIndex == 0 || ddl_Type.SelectedIndex == 0)
        {
            Page.RegisterStartupScript("error", "<script language=javascript>alert('ادخل النوع/الجهة المشاركة/المسئول')</script>");
            return;
        }
        if ((txt_Signt_Str_DT.Text == "" && txt_Signt_Str_DT.Text != "") || (txt_Signt_End_DT.Text == "" && txt_Signt_End_DT.Text != "") || (txtsigndate.Text == "" && txtsigndate.Text != "") || (txtAuthortyApprovDate.Text == "" && txtAuthortyApprovDate.Text != ""))
      //        if ((VB_Classes.Dates.Dates_Operation.date_validate(txt_Signt_Str_DT.Text) == "" && txt_Signt_Str_DT.Text != "") || (VB_Classes.Dates.Dates_Operation.date_validate(txt_Signt_End_DT.Text) == "" && txt_Signt_End_DT.Text != "") || (VB_Classes.Dates.Dates_Operation.date_validate(txtsigndate.Text) == "" && txtsigndate.Text != "") || (VB_Classes.Dates.Dates_Operation.date_validate(txtAuthortyApprovDate.Text) == "" && txtAuthortyApprovDate.Text != ""))
 
        
        {
            Page.RegisterStartupScript("error", "<script language=javascript>alert('ادخل التاريخ يوم/شهر/سنه')</script>");
            return;
        }

        if (txt_Signt_Str_DT.Text != "" && txt_Signt_End_DT.Text != "")
            //if (VB_Classes.Dates.Dates_Operation.date_validate(txt_Signt_Str_DT.Text) != "" && VB_Classes.Dates.Dates_Operation.date_validate(txt_Signt_End_DT.Text) != "")

        {
            if (VB_Classes.Dates.Dates_Operation.Date_compare(txt_Signt_End_DT.Text, txt_Signt_Str_DT.Text) == false)
               // if (VB_Classes.Dates.Dates_Operation.Date_compare(VB_Classes.Dates.Dates_Operation.date_validate(txt_Signt_End_DT.Text), VB_Classes.Dates.Dates_Operation.date_validate(txt_Signt_Str_DT.Text)) == false)

            {
                Page.RegisterStartupScript("error", "<script language=javascript>alert('تاريخ النهاية يجب أن يكون بعد تاريخ البداية')</script>");
                return;
            }
        }

        Protocol_Def_DT obj = new Protocol_Def_DT();
        obj.Protocol_ID = CDataConverter.ConvertToInt(hidden_Protocol_ID.Value);
        obj.Name = txt_Name.Text;
        obj.Type = CDataConverter.ConvertToInt(ddl_Type.SelectedValue);
        obj.Signt_Str_DT = txt_Signt_Str_DT.Text;
        obj.Signt_End_DT = txt_Signt_End_DT.Text;

        //obj.Signt_Str_DT = VB_Classes.Dates.Dates_Operation.date_validate(txt_Signt_Str_DT.Text);
        //obj.Signt_End_DT = VB_Classes.Dates.Dates_Operation.date_validate(txt_Signt_End_DT.Text);
        obj.PMP_ID = 48;

        obj.Org_ID = CDataConverter.ConvertToInt(ddl_Org_ID.SelectedValue);
        obj.Total_Balance_LE = CDataConverter.ConvertToInt(txt_Total_Balance_LE.Text);
        obj.Total_Balance_US = CDataConverter.ConvertToInt(txt_Total_Balance_US.Text);
        obj.Status = CDataConverter.ConvertToInt(hidden_Status.Value);
        obj.Documentary_DT = txtsigndate.Text;

        //obj.Documentary_DT = VB_Classes.Dates.Dates_Operation.date_validate(txtsigndate.Text);
        obj.approval_DT = txtAuthortyApprovDate.Text;
        //obj.approval_DT = VB_Classes.Dates.Dates_Operation.date_validate(txtAuthortyApprovDate.Text);
        obj.approval_NM = txtApprovalNum.Text;
        obj.Concern_authority = txtApprovalAuthority.Text;
        obj.Job_Authority = txt_Job_Authority.Text;
        obj.Job_Org = txt_Job_Org.Text;
        obj.Sign_Authority = chk_Sign_Authority.Checked;
        obj.Sign_Org = chk_Sign_Org.Checked;


        obj.Protocol_ID = Protocol_Def_DB.Save(obj);
        hidden_Protocol_ID.Value = obj.Protocol_ID.ToString();
        afterSave();
        Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم الحفظ بنجاح')</script>");
        Fil_Grid();
       

    }

    protected void btn_balance_period_Click(object sender, EventArgs e)
    {

        if (txtFrom.Text == "" || txtTo.Text == "" || (txtAmountLE.Text == "" && txtAmountUS.Text == ""))
        {
            Page.RegisterStartupScript("error", "<script language=javascript>alert('ادخل بيانات الفترة')</script>");
            return;
        }

        if ((txtFrom.Text == "" && txtFrom.Text != "") || (txtTo.Text == "" && txtTo.Text != ""))
          //  if ((VB_Classes.Dates.Dates_Operation.date_validate(txtFrom.Text) == "" && txtFrom.Text != "") || (VB_Classes.Dates.Dates_Operation.date_validate(txtTo.Text) == "" && txtTo.Text != ""))

        
        {
            Page.RegisterStartupScript("error", "<script language=javascript>alert('ادخل التاريخ يوم/شهر/سنه')</script>");
            return;
        }

        if (txtFrom.Text != "" && txtTo.Text != "")
          //  if (VB_Classes.Dates.Dates_Operation.date_validate(txtFrom.Text) != "" && VB_Classes.Dates.Dates_Operation.date_validate(txtTo.Text) != "")

        
        {
            if (VB_Classes.Dates.Dates_Operation.Date_compare(txtTo.Text,txtFrom.Text) == false)

              //  if (VB_Classes.Dates.Dates_Operation.Date_compare(VB_Classes.Dates.Dates_Operation.date_validate(txtTo.Text), VB_Classes.Dates.Dates_Operation.date_validate(txtFrom.Text)) == false)

            {
                Page.RegisterStartupScript("error", "<script language=javascript>alert('تاريخ نهاية الفترة يجب أن يكون بعد تاريخ بداية الفترة')</script>");
                return;
            }
            if (txt_Signt_Str_DT.Text != "")
               // if (VB_Classes.Dates.Dates_Operation.date_validate(txt_Signt_Str_DT.Text) != "")
            {
                if (VB_Classes.Dates.Dates_Operation.Date_compare(txtFrom.Text,txt_Signt_Str_DT.Text) == false)
                  //  if (VB_Classes.Dates.Dates_Operation.Date_compare(VB_Classes.Dates.Dates_Operation.date_validate(txtFrom.Text), VB_Classes.Dates.Dates_Operation.date_validate(txt_Signt_Str_DT.Text)) == false)

                {
                    Page.RegisterStartupScript("error", "<script language=javascript>alert('تاريخ بداية الفترة يجب أن يكون بعد تاريخ البداية')</script>");
                    return;
                }
            }
            if (txt_Signt_End_DT.Text != "")
               // if (VB_Classes.Dates.Dates_Operation.date_validate(txt_Signt_End_DT.Text) != "")
            {
                if (VB_Classes.Dates.Dates_Operation.Date_compare(txt_Signt_End_DT.Text,txtTo.Text) == false)
                    //if (VB_Classes.Dates.Dates_Operation.Date_compare(VB_Classes.Dates.Dates_Operation.date_validate(txt_Signt_End_DT.Text), VB_Classes.Dates.Dates_Operation.date_validate(txtTo.Text)) == false)

                {
                    Page.RegisterStartupScript("error", "<script language=javascript>alert('تاريخ نهاية الفترة يجب أن يكون قبل تاريخ النهاية')</script>");
                    return;
                }
            }
        }


        Protocol_Periods_Balance_DT obj = new Protocol_Periods_Balance_DT();
        obj.Protocol_ID = CDataConverter.ConvertToInt(hidden_Protocol_ID.Value);
        //obj.From_DT = VB_Classes.Dates.Dates_Operation.date_validate(txtFrom.Text);
        obj.From_DT = txtFrom.Text;
       // obj.To_DT = VB_Classes.Dates.Dates_Operation.date_validate(txtTo.Text);
        obj.To_DT = txtTo.Text;
        obj.Amount_LE = CDataConverter.ConvertToInt(txtAmountLE.Text);
        obj.Amount_US = CDataConverter.ConvertToInt(txtAmountUS.Text);
        obj.Protocol_Balance_ID = CDataConverter.ConvertToInt(hidden_balance_period_ID.Value);


        obj.Protocol_Balance_ID = Protocol_Periods_Balance_DB.Save(obj);
        hidden_balance_period_ID.Value = obj.Protocol_Balance_ID.ToString();





        // Clear_Cntrl();
        Fil_Grid_periods();
        txtFrom.Text = "";
        txtTo.Text = "";
        txtAmountLE.Text = "";
        txtAmountUS.Text = "";
        btn_period_balance.Text = "حفظ فترة ";
    }

    protected void btn_Doc_Click(object sender, EventArgs e)
    {


        if (CDataConverter.ConvertToInt(hidden_Doc_ID.Value) > 0)
        {
            if (FileUpload1.HasFile)
            {
                string DocName = FileUpload1.FileName;
                int dotindex = DocName.LastIndexOf(".");
                string type = DocName.Substring(dotindex, DocName.Length - dotindex);

                Stream myStream;
                int fileLen;
                StringBuilder displayString = new StringBuilder();
                fileLen = FileUpload1.PostedFile.ContentLength;
                Byte[] Input = new Byte[fileLen];
                myStream = FileUpload1.FileContent;
                myStream.Read(Input, 0, fileLen);
                SqlCommand cmd = new SqlCommand();
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = " update Protocol_Documents set File_desc=@File_desc ,File_Date=@File_Date ,File_Kind=@File_Kind,Protocol_ID=@Protocol_ID ,File_Name=@File_Name ,File_Type=@File_Type,File_Source=@File_Source,Parent_ID=@Parent_ID where ID =@ID";


                cmd.Parameters.Add("@File_Source", SqlDbType.VarBinary);
                cmd.Parameters.Add("@Protocol_ID", SqlDbType.Int);
                cmd.Parameters.Add("@ID", SqlDbType.Int);
                cmd.Parameters.Add("@File_Name", SqlDbType.NVarChar);
                cmd.Parameters.Add("@File_Type", SqlDbType.NVarChar);
                cmd.Parameters.Add("@File_desc", SqlDbType.NVarChar);
                cmd.Parameters.Add("@File_Date", SqlDbType.NVarChar);
                cmd.Parameters.Add("@File_Kind", SqlDbType.Int);
                cmd.Parameters.Add("@Parent_ID", SqlDbType.Int);


                cmd.Parameters["@File_Source"].Value = Input;
                cmd.Parameters["@ID"].Value = CDataConverter.ConvertToInt(hidden_Doc_ID.Value);
                cmd.Parameters["@Protocol_ID"].Value = CDataConverter.ConvertToInt(hidden_Protocol_ID.Value);
                cmd.Parameters["@File_Type"].Value = type;
                cmd.Parameters["@File_Name"].Value = txtFileName.Text;
                cmd.Parameters["@File_desc"].Value = txt_File_desc.Text;
                //cmd.Parameters["@File_Date"].Value = VB_Classes.Dates.Dates_Operation.date_validate(txt_File_Date.Text);
                cmd.Parameters["@File_Date"].Value = txt_File_Date.Text;
                cmd.Parameters["@File_Kind"].Value = CDataConverter.ConvertToInt(ddl_File_Kind.SelectedValue);
                cmd.Parameters["@Parent_ID"].Value = CDataConverter.ConvertToInt(ddl_Parent_ID.SelectedValue);




                con.Open();
                cmd.ExecuteScalar();
                btn_Doc.Text = "حفظ وثيقة";
                con.Close();
                txtFileName.Text =
                hidden_Doc_ID.Value = "";
            }
            else
            {
                SqlCommand cmd = new SqlCommand();
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = " update Protocol_Documents set File_desc=@File_desc ,File_Date=@File_Date ,File_Kind=@File_Kind,File_Name=@File_Name,Parent_ID=@Parent_ID where ID =@ID";

                cmd.Parameters.Add("@File_Name", SqlDbType.NVarChar);
                cmd.Parameters.Add("@ID", SqlDbType.Int);
                cmd.Parameters.Add("@File_desc", SqlDbType.NVarChar);
                cmd.Parameters.Add("@File_Date", SqlDbType.NVarChar);
                cmd.Parameters.Add("@File_Kind", SqlDbType.Int);
                cmd.Parameters.Add("@Parent_ID", SqlDbType.Int);

                cmd.Parameters["@File_Name"].Value = txtFileName.Text;
                cmd.Parameters["@ID"].Value = CDataConverter.ConvertToInt(hidden_Doc_ID.Value);
                cmd.Parameters["@File_desc"].Value = txt_File_desc.Text;
               // cmd.Parameters["@File_Date"].Value = VB_Classes.Dates.Dates_Operation.date_validate(txt_File_Date.Text);
                cmd.Parameters["@File_Date"].Value = txt_File_Date.Text;
                cmd.Parameters["@File_Kind"].Value = CDataConverter.ConvertToInt(ddl_File_Kind.SelectedValue);
                cmd.Parameters["@Parent_ID"].Value = CDataConverter.ConvertToInt(ddl_Parent_ID.SelectedValue);

                con.Open();
                cmd.ExecuteScalar();
                btn_Doc.Text = "حفظ وثيقة";
                con.Close();
                txtFileName.Text =
                hidden_Doc_ID.Value = "";
            }

        }
        else
        {
            if (FileUpload1.HasFile)
            {
                string DocName = FileUpload1.FileName;
                int dotindex = DocName.LastIndexOf(".");
                string type = DocName.Substring(dotindex, DocName.Length - dotindex);

                Stream myStream;
                int fileLen;
                StringBuilder displayString = new StringBuilder();
                fileLen = FileUpload1.PostedFile.ContentLength;
                Byte[] Input = new Byte[fileLen];
                myStream = FileUpload1.FileContent;
                myStream.Read(Input, 0, fileLen);
                SqlCommand cmd = new SqlCommand();
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = " insert into Protocol_Documents (Protocol_ID,File_Name,File_Type,File_Source,File_desc,File_Date,File_Kind,Parent_ID) VALUES (@Protocol_ID,@File_Name,@File_Type,@File_Source,@File_desc,@File_Date,@File_Kind,@Parent_ID)";


                cmd.Parameters.Add("@File_Source", SqlDbType.VarBinary);
                cmd.Parameters.Add("@Protocol_ID", SqlDbType.Int);
                cmd.Parameters.Add("@File_Name", SqlDbType.NVarChar);
                cmd.Parameters.Add("@File_Type", SqlDbType.NVarChar);
                cmd.Parameters.Add("@File_desc", SqlDbType.NVarChar);
                cmd.Parameters.Add("@File_Date", SqlDbType.NVarChar);
                cmd.Parameters.Add("@File_Kind", SqlDbType.Int);
                cmd.Parameters.Add("@Parent_ID", SqlDbType.Int);

                cmd.Parameters["@File_Source"].Value = Input;
                cmd.Parameters["@Protocol_ID"].Value = CDataConverter.ConvertToInt(hidden_Protocol_ID.Value);
                cmd.Parameters["@File_Type"].Value = type;
                cmd.Parameters["@File_Name"].Value = txtFileName.Text;
                cmd.Parameters["@File_desc"].Value = txt_File_desc.Text;
                //cmd.Parameters["@File_Date"].Value = VB_Classes.Dates.Dates_Operation.date_validate(txt_File_Date.Text);
                cmd.Parameters["@File_Date"].Value = txt_File_Date.Text;

                cmd.Parameters["@File_Kind"].Value = CDataConverter.ConvertToInt(ddl_File_Kind.SelectedValue);
                cmd.Parameters["@Parent_ID"].Value = CDataConverter.ConvertToInt(ddl_Parent_ID.SelectedValue);



                con.Open();
                cmd.ExecuteScalar();
                con.Close();
                txtFileName.Text =
                hidden_Doc_ID.Value = "";
            }
        }

        Fil_Grid_Documents();

        Fil_ddl_by_Parent_ID();

        LoadX();



        // Clear_Cntrl();


    }

    private void Fil_Grid_Documents()
    {
        DataTable DT = new DataTable();
        DT = General_Helping.GetDataTable("select * from Protocol_Documents where Protocol_ID=" + hidden_Protocol_ID.Value);

        GrdView_Documents.DataSource = DT;
        GrdView_Documents.DataBind();
    }

    private void Fil_Grid_periods()
    {

        grdView_periods.DataSource = Protocol_Periods_Balance_DB.SelectAll(CDataConverter.ConvertToInt(hidden_Protocol_ID.Value));
        grdView_periods.DataBind();
    }


    protected void GrdView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditItem")
        {
            afterNew();
            Fill_Controll(CDataConverter.ConvertToInt(e.CommandArgument));

            Fil_Grid_periods();
            Fil_Grid_Documents();
        }

        if (e.CommandName == "RemoveItem")
        {
            Protocol_Def_DB.Delete(CDataConverter.ConvertToInt(e.CommandArgument));
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم الحذف بنجاح')</script>");
            Fil_Grid();
        }
    }

    protected void grdView_Periods_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditItem")
        {
            int id = CDataConverter.ConvertToInt(e.CommandArgument);
            Protocol_Periods_Balance_DT obj = Protocol_Periods_Balance_DB.SelectByID(id);
            txtFrom.Text = obj.From_DT.ToString();
            txtTo.Text = obj.To_DT.ToString();
            txtAmountLE.Text = obj.Amount_LE.ToString();
            txtAmountUS.Text = obj.Amount_US.ToString();
            hidden_balance_period_ID.Value = obj.Protocol_Balance_ID.ToString();
            btn_period_balance.Text = "تعديل فترة";
            //int rw=0,i=0;
            //foreach (GridViewRow row in grdView_periods.Rows)
            //{

            //    if (CDataConverter.ConvertToInt(grdView_periods.Rows[i].FindControl("hidden_Balance_ID")) == hidden_balance_period_ID.Value)
            //    {
            //        rw = i;
            //    }
            //    else
            //    {
            //        
            //    }
            //    i += 1;

            //}
            //int z = grdView_periods.SelectedRow.RowIndex;
            //grdView_periods.Rows[i].FindControl("hidden_Balance_ID")
            ////grdView_periods.SelectedRow.BackColor= System.Drawing.Color.Lavender;
            //grdView_periods.Rows[grdView_periods.SelectedRow.RowIndex].BackColor = System.Drawing.Color.Lavender;


        }

        if (e.CommandName == "RemoveItem")
        {
            Protocol_Periods_Balance_DB.Delete(CDataConverter.ConvertToInt(e.CommandArgument));
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم الحذف بنجاح')</script>");
            Fil_Grid_periods();
        }
    }

    protected void GrdView_Documents_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditItem")
        {
            DataTable DT = new DataTable();
            DT = General_Helping.GetDataTable("select * from Protocol_Documents where id=" + e.CommandArgument.ToString());
            if (DT.Rows.Count > 0)
            {
                DataRow dr = DT.Rows[0];
                hidden_Doc_ID.Value = dr["ID"].ToString();
                txtFileName.Text = dr["File_Name"].ToString();
                ddl_File_Kind.SelectedValue = dr["File_Kind"].ToString();
                txt_File_Date.Text = dr["File_Date"].ToString();
                txt_File_desc.Text = dr["File_desc"].ToString();
                btn_Doc.Text = "تعديل الوثيقة";
            }

        }

        if (e.CommandName == "RemoveItem")
        {
            string sql = "delete from Protocol_Documents where ID = " + e.CommandArgument;
            General_Helping.ExcuteQuery(sql);
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم الحذف بنجاح')</script>");
            Fil_Grid_Documents();
        }
    }

    private void Fill_Controll(int ID)
    {
        Protocol_Def_DT obj = Protocol_Def_DB.SelectByID(ID);
        hidden_Protocol_ID.Value = ID.ToString();
        txt_Name.Text = obj.Name;
        if (CDataConverter.ConvertToInt(obj.PMP_ID) > 0)
            ddl_PMP_ID.SelectedValue = obj.PMP_ID.ToString();
        txt_Signt_Str_DT.Text = obj.Signt_Str_DT;
        txt_Signt_End_DT.Text = obj.Signt_End_DT;
        if (CDataConverter.ConvertToInt(obj.Org_ID) > 0)
            ddl_Org_ID.SelectedValue = obj.Org_ID.ToString();
        if (CDataConverter.ConvertToInt(obj.Type) > 0)
            ddl_Type.SelectedValue = obj.Type.ToString();
        txt_Total_Balance_LE.Text = obj.Total_Balance_LE.ToString();
        txt_Total_Balance_US.Text = obj.Total_Balance_US.ToString();
        txtAuthortyApprovDate.Text = obj.approval_DT.ToString();
        txtsigndate.Text = obj.Documentary_DT.ToString();
        txtApprovalNum.Text = obj.approval_NM.ToString();
        txtApprovalAuthority.Text = obj.Concern_authority.ToString();
        txt_Job_Authority.Text = obj.Job_Authority;
        txt_Job_Org.Text = obj.Job_Org;
        chk_Sign_Authority.Checked = obj.Sign_Authority;
        chk_Sign_Org.Checked = obj.Sign_Org;
        // txt_Total_Balance.Text = obj.Total_Balance.ToString();
        // txt_Period.Text = obj.Period;
        hidden_Status.Value = obj.Status.ToString();
        btn_period_balance.Enabled =
          btn_Doc.Enabled = true;
        txtFrom.Text =
            txtTo.Text =
            txtAmountUS.Text =
            txtAmountLE.Text =
            txtFileName.Text = "";

    }

    void Clear_Cntrl()
    {
        //hidden_Protocol_ID.Value =
        txt_Name.Text =
        txt_Signt_Str_DT.Text =
        txt_Signt_End_DT.Text =
        txt_Total_Balance_LE.Text =
        txt_Total_Balance_US.Text =
        txtAuthortyApprovDate.Text =
        txtApprovalNum.Text =
        txtApprovalAuthority.Text =
        txtsigndate.Text = "";

        //hidden_Status.Value = "1";


        ddl_Type.SelectedIndex =
        ddl_PMP_ID.SelectedIndex =
        ddl_Org_ID.SelectedIndex = 0;
        GrdView_Documents.DataSource = new DataTable();
        GrdView_Documents.DataBind();
        //grdView_Projects.DataSource = new DataTable();
        //grdView_Projects.DataBind();






    }

    void Fil_Grid()
    {

        grd_View_Mng.DataSource = Protocol_Def_DB.SelectAll();
        grd_View_Mng.DataBind();
    }

    public string Get_Type(object obj)
    {
        string str = obj.ToString();
        if (str == "1")
            return "اتفاقية/بروتوكول";
        else if (str == "2")
            return "مخاطبات";
        else if (str == "3")
            return "موافقات";
        else if (str == "4")
            return "أمر شغل /نطاق أعمال";
        else return "اتفاقية";
    }


}
