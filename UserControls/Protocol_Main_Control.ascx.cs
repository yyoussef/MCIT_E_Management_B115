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
using System.Data.SqlClient;
using System.Text;

public partial class UserControls_Protocol_Main_Control : System.Web.UI.UserControl
{

    General_Helping Obj_General_Helping = new General_Helping();
    private string sql_Connection = Database.ConnectionString;
    string sql;
      SqlConnection conn;
    SqlDataAdapter da;
    DataSet ds;
    Session_CS Session_CS = new Session_CS();
    protected override void OnInit(EventArgs e)
    {
        fill_smart();
        base.OnInit(e);
    }

    private void fill_smart()
    {

        #region BROWSER FOR departments
      
        string Query = "";
        Query = "SELECT Org_ID, Org_Desc FROM Organization";
        string Value_Field = "Org_ID";
        string Text_Field = "Org_Desc";
        DataTable dtorg = General_Helping.GetDataTable(Query);
        Smart_Org1.sql_Connection = sql_Connection;
        Smart_Org1.datatble = dtorg;
        Smart_Org1.Value_Field = Value_Field;
        Smart_Org1.Text_Field = Text_Field;
        Smart_Org1.DataBind();
        this.Smart_Org1.Value_Handler += new Smart_Search.Delegate_Selected_Value(MOnMember_org1_Data);

        Smart_Org2.sql_Connection = sql_Connection;
        Smart_Org2.datatble = dtorg;
        Smart_Org2.Value_Field = Value_Field;
        Smart_Org2.Text_Field = Text_Field;
        Smart_Org2.DataBind();
       this.Smart_Org2.Value_Handler += new Smart_Search.Delegate_Selected_Value(MOnMember_org2_Data);

        Smart_Org3.sql_Connection = sql_Connection;
        Smart_Org3.datatble = dtorg;
        Smart_Org3.Value_Field = Value_Field;
        Smart_Org3.Text_Field = Text_Field;
        Smart_Org3.DataBind();
        this.Smart_Org3.Value_Handler += new Smart_Search.Delegate_Selected_Value(MOnMember_org3_Data);



        Smart_PMP_ID.sql_Connection = sql_Connection;
        // Smart_PMP_ID.Query = "select * from EMPLOYEE ";//where rol_rol_id in( 3,4)";
        Query = "select PMP_ID, pmp_name from EMPLOYEE ";//where rol_rol_id in( 3,4)";
        Smart_PMP_ID.datatble = General_Helping.GetDataTable(Query);
        Smart_PMP_ID.Value_Field = "PMP_ID";
        Smart_PMP_ID.Text_Field = "pmp_name";
        Smart_PMP_ID.DataBind();

        Smart_all_Project.sql_Connection = sql_Connection;
        // Smart_all_Project.Query = "select * from Project ";//where rol_rol_id in( 3,4)";
        Query = "select Proj_id, Proj_Title from Project ";//where rol_rol_id in( 3,4)";
        Smart_all_Project.datatble = General_Helping.GetDataTable(Query);
        Smart_all_Project.Value_Field = "Proj_id";
        Smart_all_Project.Text_Field = "Proj_Title";
        Smart_all_Project.DataBind();
     this.Smart_all_Project.Value_Handler += new Smart_Search.Delegate_Selected_Value(MOnMember_Data);
        smart_Protocol.sql_Connection = sql_Connection;
        if (Request["Id"] != null)
        {
            Query = "select Protocol_ID,Name from Protocol_Main_Def where Protocol_ID <> " + Request["Id"];
        }
        else
        {
            Query = "select Protocol_ID,Name from Protocol_Main_Def";
        }

        smart_Protocol.datatble = General_Helping.GetDataTable(Query);
        smart_Protocol.Value_Field = "Protocol_ID";
        smart_Protocol.Text_Field = "Name";
        smart_Protocol.DataBind();



        #endregion
    }

    private void MOnMember_org1_Data(string Value)
    {
        org_1_smart_fun();
    }
    private void MOnMember_org2_Data(string Value)
    {
        org_2_smart_fun();
    }
    private void MOnMember_org3_Data(string Value)
    {
        org_3_smart_fun();
    }
    private void MOnMember_org_ID_Data(string Value)
    {
        org_comitte_smart_fun();
    }
    private void MOnMember_Data(string Value)
    {
        proj_smart_fun();
    }

    protected void org_1_smart_fun()
    {

        TabPanel_All.ActiveTab = TabPanel_Main;

    }
    protected void org_2_smart_fun()
    {

        TabPanel_All.ActiveTab = TabPanel_Main;

    }
    protected void org_3_smart_fun()
    {

        TabPanel_All.ActiveTab = TabPanel_Main;

    }

    protected void org_comitte_smart_fun()
    {

        TabPanel_All.ActiveTab = TabPanel_committee;

    }
    protected void proj_smart_fun()
    {
        
        TabPanel_All.ActiveTab = TabPanel_Project;

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        //string ss =Session_CS.Project_id.ToString();
        if (CDataConverter.ConvertToInt(Session_CS.Project_id) > 0)
        {
            btn_New.Enabled = false;
            BtnSave.Enabled = false;
            btn_Org1.Enabled = false;
            btn_Org2.Enabled = false;
            btn_Org3.Enabled = false;
            btn_save_Project.Enabled = false;
            BtnSave_committee.Enabled = false;
            btn_Doc.Enabled = false;
            GridView_Org1.Columns[3].Visible = false;
            GridView_Org1.Columns[4].Visible = false;
            GridView_Org2.Columns[1].Visible = false;
            GridView_Org2.Columns[2].Visible = false;
            GridView_Org3.Columns[1].Visible = false;
            GridView_Org3.Columns[2].Visible = false;
            GridView_Projects.Columns[1].Visible = false;
            GrdView_Documents.Columns[4].Visible = false;
            GrdView_Documents.Columns[5].Visible = false;
            GridView_Protocole_Committee.Columns[2].Visible = false;
            GridView_Protocole_Committee.Columns[3].Visible = false;
            
        }

        if (!IsPostBack)
        {
        fill_realtion();
            if (Request["Id"] != null)
            {
                Fill_Controll(CDataConverter.ConvertToInt(Request["Id"]));
                if (CDataConverter.ConvertToInt( Session_CS.Project_id ) > 0)
                    Change_btn_Status(false);
                else
                    Change_btn_Status(true);
                fil_Grd_Org1();
                fil_Grd_Org2();
                fil_Grd_Org3();
                fil_smart_org_comittee();
                Fil_Grd_Projects();
                Fil_Grid_Committee();
                Fil_Grid_Documents();
                TabPanel_All.ActiveTab = TabPanel_Main;

            }
            if (Request["Related_ID"] != null && CDataConverter.ConvertToInt(Request["Related_ID"].ToString()) > 0)
            {
                hidden_Related_ID.Value = Request["Related_ID"].ToString();
            }
            //else
            //{

            //    Fil_Grid();
            //}


            if (Session_CS.UROL_UROL_ID != 11 & Session_CS.UROL_UROL_ID != 2)
            {
                Disable_controls();
            }

        }
    }


    public  void fill_realtion()
    {
        
            conn = new SqlConnection(sql_Connection);
            Fil_Dll();
            sql = "select id,Type from Protocol_Relation_Type";
            ds = new DataSet();
            da = new SqlDataAdapter(sql, conn);
            da.Fill(ds, "Type");
            drop_relation.DataSource = ds.Tables[0];
            drop_relation.DataValueField = "id";
            drop_relation.DataTextField = "Type";
            drop_relation.DataBind();
            drop_relation.Items.Insert(0, new ListItem("اختر العلاقة......", "0"));
    }


    private void Disable_controls()
    {

        ddl_Type.Enabled = false;
        txt_Name.Enabled = false;
        Smart_PMP_ID.Enabled = false;
        txt_Signt_DT.Enabled = false;
        txtdate_CalendarExtender.Enabled = false;
        txt_Strt_DT.Enabled = false;
        CalendarExtender7.Enabled = false;
        CalendarExtender1.EnableClientState = false;
        txt_End_DT.Enabled = false;
        txt_Period_Day.Enabled = false;
        txt_Period_Month.Enabled = false;
        txt_Period_Year.Enabled = false;
        Button2.Enabled = false;
        drop_relation.Enabled = false;
        smart_Protocol.Enabled = false;
        BtnSave.Enabled = false;
        btn_New.Enabled = false;
        Smart_Org1.Enabled = false;
        txtAmountLE.Enabled = false;
        txtAmountUS.Enabled = false;
        Txt_Resp.Enabled = false;
        btn_Org1.Enabled = false;
        GridView_Org1.Enabled = false;
        txt_Total_Balance_LE.Enabled = false;
        txt_Total_Balance_US.Enabled = false;
        Smart_Org2.Enabled = false;
        btn_Org2.Enabled = false;
        GridView_Org2.Enabled = false;
        Smart_Org3.Enabled = false;
        btn_Org3.Enabled = false;
        GridView_Org3.Enabled = false;
        Smart_all_Project.Enabled = false;
        btn_save_Project.Enabled = false;
        GridView_Projects.Enabled = false;
        ddl_File_Kind.Enabled = false;
        txtFileName.Enabled = false;
        FileUpload1.Enabled = false;
        txt_File_Date.Enabled = false;
        CalendarExtender6.Enabled = false;
        txt_File_desc.Enabled = false;
        btn_Doc.Enabled = false;
        GrdView_Documents.Enabled = false;
        Txt_Person_data.Enabled = false;
        Smart_Org_ID.Enabled = false;
        Txt_notes.Enabled = false;
        BtnSave_committee.Enabled = false;
        GridView_Protocole_Committee.Enabled = false;


     
    }

    private void Fil_Grid_Committee()
    {
        DataTable DT = new DataTable();
        DT = General_Helping.GetDataTable("select * from View_Protocole_committe where Protocol_ID=" + hidden_Protocol_ID.Value);

        GridView_Protocole_Committee.DataSource = DT;
        GridView_Protocole_Committee.DataBind();

    }
    protected void BtnSave_committee_Click(object sender, EventArgs e)
    {
        if (CDataConverter.ConvertToInt(hidden_Protocol_ID.Value) > 0)
        {
            if (Txt_Person_data.Text != "")
            {
                Protocol_Main_Committee_DT obj = new Protocol_Main_Committee_DT();
                obj.ID = CDataConverter.ConvertToInt(hidden_committe_id.Value);
                obj.Protocol_ID = CDataConverter.ConvertToInt(hidden_Protocol_ID.Value);
                obj.Notes = Txt_notes.Text;
                obj.Person_Name = Txt_Person_data.Text;
                obj.Person_Job = "";
                obj.Org_Type = 0;
                if (Smart_Org_ID.SelectedValue!="")
                {
                    obj.Org_id = CDataConverter.ConvertToInt(Smart_Org_ID.SelectedValue);

                }
                else
                {
                        Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('يجب إختيار الجهة')</script>");
                        return;
                    
                }
                obj.ID = Protocol_Main_Committee_DB.Save(obj);
                hidden_committe_id.Value = obj.ID.ToString();
                



                if (obj.ID > 0)
                    Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم الحفظ بنجاح')</script>");
                else
                    Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لم يتم الحفظ يرجى التأكد من البيانات ')</script>");
            }

            else
            {
                Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('يجب ادخال الاسم ')</script>");
            }
        }
        else
        {
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert(' يرجي ادخال تفاصيل البروتوكول / الاتفاقية ')</script>");
        }
       
        Fil_Grid_Committee();
        hidden_committe_id.Value = "";
        Txt_Person_data.Text = "";
        Txt_notes.Text = "";
        Smart_Org_ID.Clear_Selected();
    }
    private void Fil_committee_Control(int ID)
    {
        Protocol_Main_Committee_DT obj = Protocol_Main_Committee_DB.SelectByID(ID);
        if (obj.ID > 0)
        {
            try
            {
                hidden_committe_id.Value = obj.ID.ToString();
                hidden_job.Value = obj.Person_Job;
                Txt_Person_data.Text = obj.Person_Name;
                hidden_org_type.Value = obj.Org_Type.ToString();

                if (obj.Org_id > 0)
                {
                    //tr_org_out.Visible = true;
                    //tr_dept.Visible = false;
                    Smart_Org_ID.SelectedValue = obj.Org_id.ToString();
                }
                hidden_dept_id.Value = obj.Dept_id.ToString();
                //if (obj.Dept_id > 0)
                //{
                //    tr_dept.Visible = true;
                //    tr_org_out.Visible = false;
                //    ddl_Dept_ID.SelectedValue = obj.Dept_id.ToString();
                //}


            }
            catch
            { }
        }



    }
    protected void GridView_Protocole_Committee_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditItem")
        {
            Fil_committee_Control(CDataConverter.ConvertToInt(e.CommandArgument));


        }
        if (e.CommandName == "RemoveItem")
        {
            General_Helping.ExcuteQuery("delete from Protocol_Main_Committee where ID = " + e.CommandArgument);
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم الحذف بنجاح')</script>");
            Fil_Grid_Committee();

        }
    }
    private void Fill_Controll(int ID)
    {
        Protocol_Main_Def_DT obj = Protocol_Main_Def_DB.SelectByID(ID);
        hidden_Protocol_ID.Value = obj.Protocol_ID.ToString();
        txt_Name.Text = obj.Name;
        lblMastertitle.Text = obj.Name;
        ddl_Type.SelectedValue = obj.Type.ToString();
        txt_Signt_DT.Text = obj.Signt_DT;
        txt_Strt_DT.Text = obj.Strt_DT;
        
        txt_End_DT.Text = obj.End_DT;
        DateTime t1 = CDataConverter.ConvertToDate(obj.End_DT); 
        //DateTime tnow = DateTime.ParseExact(DateTime.Now.ToString("dd/MM/yyyy"), "dd/MM/yyyy", null); 

        DateTime tnow = CDataConverter.ConvertDateTimeNowRtnDt(); 

        if (txt_End_DT.Text!="")
        {
            if (t1 < tnow)
            {
                lbl_prot_sit.ForeColor = System.Drawing.Color.Red;
                lbl_prot_sit.Text = "منتهي";
            }
            else
            {
                lbl_prot_sit.ForeColor = System.Drawing.Color.Black;
                lbl_prot_sit.Text = "قائم";
            }
        }

        drop_relation.SelectedValue = obj.Related_Type.ToString();
        if (drop_relation.SelectedValue!="0")
        {
            lbl_prot.Visible = true;
            smart_Protocol.Visible = true;
        }
        smart_Protocol.SelectedValue = obj.Related_Protocol_ID.ToString();
        Smart_PMP_ID.SelectedValue = obj.PMP_ID.ToString();
        txt_Total_Balance_LE.Text = obj.Total_Balance_LE.ToString();
        txt_Total_Balance_US.Text = obj.Total_Balance_US.ToString();
        hidden_Status.Value = obj.Status.ToString();
        txt_Period_Day.Text = obj.Period_Day.ToString();
        txt_Period_Month.Text = obj.Period_Month.ToString();
        txt_Period_Year.Text = obj.Period_Year.ToString();
        hidden_Related_ID.Value = obj.Related_ID.ToString();

    }

    protected void btn_New_Click(object sender, EventArgs e)
    {
        Clear_cntrl();
    }

    private void Clear_cntrl()
    {
        hidden_Protocol_ID.Value =
        txt_Name.Text =
        ddl_Type.SelectedValue =
        txt_Signt_DT.Text =
        txt_Strt_DT.Text =
        txt_End_DT.Text =

        txt_Total_Balance_LE.Text =
        txt_Total_Balance_US.Text =
        hidden_Status.Value =
        txt_Period_Day.Text =
        txt_Period_Month.Text =
        txt_Period_Year.Text = "";
        lblMastertitle.Text = "بروتوكولات / اتفاقيات";
        lbl_prot_sit.Text = "";
        Change_btn_Status(false);
        fil_Grd_Org1();
        fil_Grd_Org2();
        fil_Grd_Org3();
        Fil_Grd_Projects();
        Fil_Grid_Documents();
        Smart_PMP_ID.Clear_Selected();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        Protocol_Main_Def_DT obj = new Protocol_Main_Def_DT();
        string Strt_date = VB_Classes.Dates.Dates_Operation.date_validate(txt_Strt_DT.Text);
        string End_date = VB_Classes.Dates.Dates_Operation.date_validate(txt_End_DT.Text);
        string sign_date = VB_Classes.Dates.Dates_Operation.date_validate(txt_Signt_DT.Text);
        if (VB_Classes.Dates.Dates_Operation.date_validate(txt_Signt_DT.Text.Trim()) != "")
        {
            obj.Signt_DT = VB_Classes.Dates.Dates_Operation.date_validate(txt_Signt_DT.Text);
        }
        else
        {
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('ادخل تاريخ التوقيع بشكل صحيح')</script>");
            return;
        }

        if (VB_Classes.Dates.Dates_Operation.date_validate(txt_Strt_DT.Text.Trim()) != "")
        {
            obj.Strt_DT = VB_Classes.Dates.Dates_Operation.date_validate(txt_Strt_DT.Text);
        }
        else
        {
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('ادخل تاريخ البداية بشكل صحيح')</script>");
            return;
        }
        if (VB_Classes.Dates.Dates_Operation.date_validate(txt_End_DT.Text.Trim()) != "")
        {
            obj.End_DT = VB_Classes.Dates.Dates_Operation.date_validate(txt_End_DT.Text);
        }
        else
        {
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('ادخل تاريخ النهاية بشكل صحيح')</script>");
            return;
        }
        if (!VB_Classes.Dates.Dates_Operation.Date_compare(Strt_date, sign_date))
        {
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('تاريخ التوقيع يجب ان يكون قبل تاريخ البداية ')</script>");
            return;
        }
        if (VB_Classes.Dates.Dates_Operation.Date_compare(VB_Classes.Dates.Dates_Operation.date_validate(txt_Strt_DT.Text), VB_Classes.Dates.Dates_Operation.date_validate(txt_End_DT.Text)) != false)
        {
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('تاريخ النهاية يجب ان يكون اكبر من تاريخ البداية')</script>");
            return;
        }
        if (Protocol_Main_Def_DB.SelectBy_Name(txt_Name.Text, CDataConverter.ConvertToInt(hidden_Protocol_ID.Value)))
        {
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم ادخال نفس البروتوكول من قبل')</script>");
            return;
        }

        
        obj.Protocol_ID = CDataConverter.ConvertToInt(hidden_Protocol_ID.Value);
        obj.Name = txt_Name.Text;
        obj.Type = CDataConverter.ConvertToInt(ddl_Type.SelectedValue);
        
        
        
       
        obj.PMP_ID = CDataConverter.ConvertToInt(Smart_PMP_ID.SelectedValue);

        obj.Total_Balance_LE = CDataConverter.ConvertToInt(txt_Total_Balance_LE.Text);
        obj.Total_Balance_US = CDataConverter.ConvertToInt(txt_Total_Balance_US.Text);
        obj.Status = CDataConverter.ConvertToInt(hidden_Status.Value);
        obj.Period_Day = CDataConverter.ConvertToInt(txt_Period_Day.Text);
        obj.Period_Month = CDataConverter.ConvertToInt(txt_Period_Month.Text);
        obj.Period_Year = CDataConverter.ConvertToInt(txt_Period_Year.Text);
        obj.Related_ID = CDataConverter.ConvertToInt(hidden_Related_ID.Value);
        if (drop_relation.SelectedValue != "0")
        {
            obj.Related_Type =CDataConverter.ConvertToInt( drop_relation.SelectedValue);
        }
        else
        {
            obj.Related_Type = 0;
            obj.Related_Protocol_ID = 0;

        }
        if (drop_relation.SelectedValue != "0")
        {
            if (smart_Protocol.SelectedValue != "")
            {
                obj.Related_Protocol_ID = CDataConverter.ConvertToInt(smart_Protocol.SelectedValue);
            }
            else
            {
                obj.Related_Protocol_ID = 0;
            }
        }
       

        obj.Protocol_ID = Protocol_Main_Def_DB.Save(obj);
        hidden_Protocol_ID.Value = obj.Protocol_ID.ToString();
        Change_btn_Status(true);
        if (obj.Protocol_ID > 0)
        {
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم الحفظ بنجاح')</script>");
        }
        else
        {
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لم يتم الحفظ ')</script>");
        }


    }

    private void Change_btn_Status(bool p)
    {
        btn_Doc.Enabled =
        btn_save_Project.Enabled =
        btn_Org3.Enabled =
        btn_Org2.Enabled =
        btn_Org1.Enabled = p;
    }

    private void Fil_Dll()
    {
        // DataTable DT2 = new DataTable();
        // DT2 = General_Helping.GetDataTable("select * from EMPLOYEE where rol_rol_id in( 3,4) ");
        // Obj_General_Helping.SmartBindDDL(ddl_PMP_ID, DT2, "PMP_ID", "pmp_name", "....اختر المسئول ....");


    }

    protected void btn_Org1_Click(object sender, EventArgs e)
    {



        if (CDataConverter.ConvertToInt(Smart_Org1.SelectedValue) <= 0)
        {
            Page.RegisterStartupScript("error", "<script language=javascript>alert('يجب اختيار الجهة')</script>");
            return;
        }
        Protocol_Main_Org_DT obj = new Protocol_Main_Org_DT();
        obj.Protocol_Org_ID = CDataConverter.ConvertToInt(hidden_Protocol_Org_ID1.Value);
        obj.Protocol_ID = CDataConverter.ConvertToInt(hidden_Protocol_ID.Value);
        obj.Org_Type = 1;
        obj.Org_ID = CDataConverter.ConvertToInt(Smart_Org1.SelectedValue);
        obj.Total_Balance_LE = CDataConverter.ConvertToInt(txtAmountLE.Text);
        obj.Total_Balance_US = CDataConverter.ConvertToInt(txtAmountUS.Text);
        obj.Org_Responsibilities = Txt_Resp.Text;
        Protocol_Main_Org_DB.Save(obj);

        Protocol_Main_Def_DT obj_Main = Protocol_Main_Def_DB.SelectByID(obj.Protocol_ID);

        obj_Main.Total_Balance_LE += obj.Total_Balance_LE - CDataConverter.ConvertToInt(hidden_LE.Value);
        obj_Main.Total_Balance_US += obj.Total_Balance_US - CDataConverter.ConvertToInt(hidden_US.Value);
        Protocol_Main_Def_DB.Save(obj_Main);
        txt_Total_Balance_LE.Text = obj_Main.Total_Balance_LE.ToString();
        txt_Total_Balance_US.Text = obj_Main.Total_Balance_US.ToString();
        fil_smart_org_comittee();
        fil_Grd_Org1();
        txtAmountLE.Text =
            txtAmountUS.Text =
            Txt_Resp.Text = "";
            hidden_Protocol_Org_ID1.Value = "";
        Smart_Org1.Clear_Selected();



    }

    protected void btn_Org2_Click(object sender, EventArgs e)
    {



        if (CDataConverter.ConvertToInt(Smart_Org2.SelectedValue) <= 0)
        {
            Page.RegisterStartupScript("error", "<script language=javascript>alert('يجب اختيار الجهة')</script>");
            return;
        }
        Protocol_Main_Org_DT obj = new Protocol_Main_Org_DT();
        obj.Protocol_Org_ID = CDataConverter.ConvertToInt(hidden_Protocol_Org_ID2.Value);
        obj.Protocol_ID = CDataConverter.ConvertToInt(hidden_Protocol_ID.Value);
        obj.Org_Type = 2;
        obj.Org_ID = CDataConverter.ConvertToInt(Smart_Org2.SelectedValue);
        Protocol_Main_Org_DB.Save(obj);

        fil_smart_org_comittee();
        fil_Grd_Org2();
        hidden_Protocol_Org_ID2.Value = "";
        Smart_Org2.Clear_Selected();



    }

    protected void btn_Org3_Click(object sender, EventArgs e)
    {



        if (CDataConverter.ConvertToInt(Smart_Org3.SelectedValue) <= 0)
        {
            Page.RegisterStartupScript("error", "<script language=javascript>alert('يجب اختيار الجهة')</script>");
            return;
        }
        Protocol_Main_Org_DT obj = new Protocol_Main_Org_DT();
        obj.Protocol_Org_ID = CDataConverter.ConvertToInt(hidden_Protocol_Org_ID3.Value);
        obj.Protocol_ID = CDataConverter.ConvertToInt(hidden_Protocol_ID.Value);
        obj.Org_Type = 3;
        obj.Org_ID = CDataConverter.ConvertToInt(Smart_Org3.SelectedValue);
        Protocol_Main_Org_DB.Save(obj);

        fil_smart_org_comittee();
        fil_Grd_Org3();
        hidden_Protocol_Org_ID3.Value = "";
        Smart_Org3.Clear_Selected();



    }

    protected void btn_save_Project_Click(object sender, EventArgs e)
    {
        string sql_prot_proj = "select * from project where proj_id = "+ Smart_all_Project.SelectedValue + "AND Protocol_ID = "+ hidden_Protocol_ID.Value;
        DataTable dt_prot_proj = General_Helping.GetDataTable(sql_prot_proj);
        if (dt_prot_proj.Rows.Count>0)
        {
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('تم إضافة هذا المشروع من قبل')</script>");
            return;
        }
        int Project_ID = CDataConverter.ConvertToInt(Smart_all_Project.SelectedValue);
        if (Project_ID > 0)
        {
            string sql = " update Project set Protocol_ID = '" + hidden_Protocol_ID.Value + "' where Proj_id = " + Project_ID;
            General_Helping.ExcuteQuery(sql);

        }
        //else
        //{
        //    string sql = " insert into Project (Proj_Title,Protocol_ID ) VALUES ('" + txt_Project.Text + "'," + hidden_Protocol_ID.Value + " )";
        //    General_Helping.ExcuteQuery(sql);


        //}
        Fil_Grd_Projects();
        //txt_Project.Text =
        // hidden_Proj_id.Value = "";



    }

    private void Fil_Grd_Projects()
    {

        GridView_Projects.DataSource = General_Helping.GetDataTable("Select * from Project where Protocol_ID =" + CDataConverter.ConvertToInt(hidden_Protocol_ID.Value));
        GridView_Projects.DataBind();
    }

    private void fil_Grd_Org3()
    {
        GridView_Org3.DataSource = Protocol_Main_Org_DB.SelectAll_by_protocol_Id(CDataConverter.ConvertToInt(hidden_Protocol_ID.Value), 3);
        GridView_Org3.DataBind();
    }

    private void fil_Grd_Org2()
    {
        GridView_Org2.DataSource = Protocol_Main_Org_DB.SelectAll_by_protocol_Id(CDataConverter.ConvertToInt(hidden_Protocol_ID.Value), 2);
        GridView_Org2.DataBind();
    }

    private void fil_Grd_Org1()
    {
        
        

        GridView_Org1.DataSource = Protocol_Main_Org_DB.SelectAll_by_protocol_Id(CDataConverter.ConvertToInt(hidden_Protocol_ID.Value), 1);
        GridView_Org1.DataBind();

    }
    private void fil_smart_org_comittee()
    {
        string Query2 = "SELECT distinct dbo.Protocol_Main_Org.Org_ID,dbo.Protocol_Main_Org.Protocol_ID,  dbo.Organization.Org_Desc FROM dbo.Protocol_Main_Org INNER JOIN dbo.Organization ON dbo.Protocol_Main_Org.Org_ID = dbo.Organization.Org_ID where dbo.Protocol_Main_Org.Protocol_ID = " + hidden_Protocol_ID.Value;
        string Value_Field = "Org_ID";
        string Text_Field = "Org_Desc";
        Smart_Org_ID.sql_Connection = sql_Connection;
        Smart_Org_ID.datatble = General_Helping.GetDataTable(Query2);
        Smart_Org_ID.Value_Field = Value_Field;
        Smart_Org_ID.Text_Field = Text_Field;
        Smart_Org_ID.DataBind();
    }

    protected void GridView_Org1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditItem")
        {
            Protocol_Main_Org_DT obj = Protocol_Main_Org_DB.SelectByID(CDataConverter.ConvertToInt(e.CommandArgument.ToString()));
            hidden_Protocol_Org_ID1.Value = obj.Protocol_Org_ID.ToString();
            Smart_Org1.SelectedValue = obj.Org_ID.ToString();
            Txt_Resp.Text = obj.Org_Responsibilities;
            hidden_LE.Value = txtAmountLE.Text = obj.Total_Balance_LE.ToString();
            hidden_US.Value = txtAmountUS.Text = obj.Total_Balance_US.ToString();

        }

        if (e.CommandName == "RemoveItem")
        {
            Protocol_Main_Org_DB.Delete(CDataConverter.ConvertToInt(e.CommandArgument));
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم الحذف بنجاح')</script>");
            fil_Grd_Org1();
        }
    }

    protected void GridView_Org2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditItem")
        {
            Protocol_Main_Org_DT obj = Protocol_Main_Org_DB.SelectByID(CDataConverter.ConvertToInt(e.CommandArgument.ToString()));
            hidden_Protocol_Org_ID2.Value = obj.Protocol_Org_ID.ToString();
            Smart_Org2.SelectedValue = obj.Org_ID.ToString();

        }

        if (e.CommandName == "RemoveItem")
        {
            Protocol_Main_Org_DB.Delete(CDataConverter.ConvertToInt(e.CommandArgument));
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم الحذف بنجاح')</script>");
            fil_Grd_Org2();
        }
    }

    protected void GridView_Org3_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditItem")
        {
            Protocol_Main_Org_DT obj = Protocol_Main_Org_DB.SelectByID(CDataConverter.ConvertToInt(e.CommandArgument.ToString()));
            hidden_Protocol_Org_ID3.Value = obj.Protocol_Org_ID.ToString();
            Smart_Org3.SelectedValue = obj.Org_ID.ToString();

        }

        if (e.CommandName == "RemoveItem")
        {
            Protocol_Main_Org_DB.Delete(CDataConverter.ConvertToInt(e.CommandArgument));
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم الحذف بنجاح')</script>");
            fil_Grd_Org3();
        }
    }

    protected void GridView_Projects_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditItem")
        {
            Smart_all_Project.SelectedValue = e.CommandArgument.ToString();
            //DataTable Dt = General_Helping.GetDataTable("Select * from Project where Proj_id =" + e.CommandArgument.ToString());
            //if (Dt.Rows.Count > 0)
            //{
            //    txt_Project.Text = Dt.Rows[0]["Proj_Title"].ToString();
            //    hidden_Proj_id.Value = Dt.Rows[0]["Proj_id"].ToString();
            //}

        }

        if (e.CommandName == "RemoveItem")
        {
            string sql = " update Project set Protocol_ID = NULL where Proj_id =" + e.CommandArgument.ToString();
            General_Helping.ExcuteQuery(sql);
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم الحذف بنجاح')</script>");
            Fil_Grd_Projects();
        }
    }

    protected void GrdView_Documents_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditItem")
        {
            DataTable DT = new DataTable();
            DT = General_Helping.GetDataTable("select * from Protocol_Main_Documents where id=" + e.CommandArgument.ToString());
            if (DT.Rows.Count > 0)
            {
                DataRow dr = DT.Rows[0];
                hidden_Doc_ID.Value = dr["ID"].ToString();
                txtFileName.Text = dr["File_Name"].ToString();
                ddl_File_Kind.SelectedValue = dr["File_Kind"].ToString();
                txt_File_Date.Text = dr["File_Date"].ToString();
                txt_File_desc.Text = dr["File_desc"].ToString();


            }

        }

        if (e.CommandName == "RemoveItem")
        {
            string sql = "delete from Protocol_Main_Documents where ID = " + e.CommandArgument;
            General_Helping.ExcuteQuery(sql);
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم الحذف بنجاح')</script>");
            Fil_Grid_Documents();
        }
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
                cmd.CommandText = " update Protocol_Main_Documents set File_desc=@File_desc ,File_Date=@File_Date ,File_Kind=@File_Kind,Protocol_ID=@Protocol_ID ,File_Name=@File_Name ,File_Type=@File_Type,File_Source=@File_Source where ID =@ID";


                cmd.Parameters.Add("@File_Source", SqlDbType.VarBinary);
                cmd.Parameters.Add("@Protocol_ID", SqlDbType.Int);
                cmd.Parameters.Add("@ID", SqlDbType.Int);
                cmd.Parameters.Add("@File_Name", SqlDbType.NVarChar);
                cmd.Parameters.Add("@File_Type", SqlDbType.NVarChar);
                cmd.Parameters.Add("@File_desc", SqlDbType.NVarChar);
                cmd.Parameters.Add("@File_Date", SqlDbType.NVarChar);
                cmd.Parameters.Add("@File_Kind", SqlDbType.Int);


                cmd.Parameters["@File_Source"].Value = Input;
                cmd.Parameters["@ID"].Value = CDataConverter.ConvertToInt(hidden_Doc_ID.Value);
                cmd.Parameters["@Protocol_ID"].Value = CDataConverter.ConvertToInt(hidden_Protocol_ID.Value);
                cmd.Parameters["@File_Type"].Value = type;
                cmd.Parameters["@File_Name"].Value = txtFileName.Text;
                cmd.Parameters["@File_desc"].Value = txt_File_desc.Text;
                if (VB_Classes.Dates.Dates_Operation.date_validate(txt_File_Date.Text.Trim()) != "")
                {
                    cmd.Parameters["@File_Date"].Value = VB_Classes.Dates.Dates_Operation.date_validate(txt_File_Date.Text);
                }
                else
                {
                    Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('ادخل تاريخ  بشكل صحيح')</script>");
                    return;
                }
                
                cmd.Parameters["@File_Kind"].Value = CDataConverter.ConvertToInt(ddl_File_Kind.SelectedValue);




                con.Open();
                cmd.ExecuteScalar();
                con.Close();
                txtFileName.Text =
                txt_File_Date.Text = "";
                txt_File_desc.Text = "";
                hidden_Doc_ID.Value = "";
            }
            else
            {
                SqlCommand cmd = new SqlCommand();
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = " update Protocol_Main_Documents set File_desc=@File_desc ,File_Date=@File_Date ,File_Kind=@File_Kind,File_Name=@File_Name where ID =@ID";

                cmd.Parameters.Add("@File_Name", SqlDbType.NVarChar);
                cmd.Parameters.Add("@ID", SqlDbType.Int);
                cmd.Parameters.Add("@File_desc", SqlDbType.NVarChar);
                cmd.Parameters.Add("@File_Date", SqlDbType.NVarChar);
                cmd.Parameters.Add("@File_Kind", SqlDbType.Int);

                cmd.Parameters["@File_Name"].Value = txtFileName.Text;
                cmd.Parameters["@ID"].Value = CDataConverter.ConvertToInt(hidden_Doc_ID.Value);
                cmd.Parameters["@File_desc"].Value = txt_File_desc.Text;

                if (VB_Classes.Dates.Dates_Operation.date_validate(txt_File_Date.Text.Trim()) != "")
                {
                    cmd.Parameters["@File_Date"].Value = VB_Classes.Dates.Dates_Operation.date_validate(txt_File_Date.Text);
                }
                else
                {
                    Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('ادخل تاريخ  بشكل صحيح')</script>");
                    return;
                }
                cmd.Parameters["@File_Kind"].Value = CDataConverter.ConvertToInt(ddl_File_Kind.SelectedValue);

                con.Open();
                cmd.ExecuteScalar();
                btn_Doc.Text = "حفظ وثيقة";
                con.Close();
                txtFileName.Text =
                    txt_File_Date.Text = "";
                txt_File_desc.Text = "";
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
                cmd.CommandText = " insert into Protocol_Main_Documents (Protocol_ID,File_Name,File_Type,File_Source,File_desc,File_Date,File_Kind) VALUES (@Protocol_ID,@File_Name,@File_Type,@File_Source,@File_desc,@File_Date,@File_Kind)";


                cmd.Parameters.Add("@File_Source", SqlDbType.VarBinary);
                cmd.Parameters.Add("@Protocol_ID", SqlDbType.Int);
                cmd.Parameters.Add("@File_Name", SqlDbType.NVarChar);
                cmd.Parameters.Add("@File_Type", SqlDbType.NVarChar);
                cmd.Parameters.Add("@File_desc", SqlDbType.NVarChar);
                cmd.Parameters.Add("@File_Date", SqlDbType.NVarChar);
                cmd.Parameters.Add("@File_Kind", SqlDbType.Int);

                cmd.Parameters["@File_Source"].Value = Input;
                cmd.Parameters["@Protocol_ID"].Value = CDataConverter.ConvertToInt(hidden_Protocol_ID.Value);
                cmd.Parameters["@File_Type"].Value = type;
                cmd.Parameters["@File_Name"].Value = txtFileName.Text;
                cmd.Parameters["@File_desc"].Value = txt_File_desc.Text;
                if (VB_Classes.Dates.Dates_Operation.date_validate(txt_File_Date.Text.Trim()) != "")
                {
                    cmd.Parameters["@File_Date"].Value = VB_Classes.Dates.Dates_Operation.date_validate(txt_File_Date.Text);
                }
                else
                {
                    Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('ادخل تاريخ  بشكل صحيح')</script>");
                    return;
                }
                cmd.Parameters["@File_Kind"].Value = CDataConverter.ConvertToInt(ddl_File_Kind.SelectedValue);



                con.Open();
                cmd.ExecuteScalar();
                con.Close();
                txtFileName.Text =
                 txt_File_Date.Text = "";
                txt_File_desc.Text = "";
                hidden_Doc_ID.Value = "";
            }
        }

        Fil_Grid_Documents();


    }

    private void Fil_Grid_Documents()
    {
        DataTable DT = new DataTable();
        DT = General_Helping.GetDataTable("select * from Protocol_Main_Documents where Protocol_ID=" + CDataConverter.ConvertToInt(hidden_Protocol_ID.Value));

        GrdView_Documents.DataSource = DT;
        GrdView_Documents.DataBind();
    }

    public string Get_Type(object obj)
    {
        string str = obj.ToString();
        if (str == "1")
            return "اتفاقية/بروتوكول";
        else if (str == "2")
            return "خطابات";
        else if (str == "3")
            return "مذكرات عرض";
        else if (str == "4")
            return "أخرى";
        else return "";
    }

    protected void btnCalc_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(txt_Period_Month.Text) && !string.IsNullOrEmpty(txt_Period_Year.Text))
        {
            string Strt_date = VB_Classes.Dates.Dates_Operation.date_validate(txt_Strt_DT.Text);
            if (!string.IsNullOrEmpty(Strt_date))
            {
                int Total_Days = CDataConverter.ConvertToInt(txt_Period_Year.Text) * 360 + CDataConverter.ConvertToInt(txt_Period_Month.Text) * 30 + CDataConverter.ConvertToInt(txt_Period_Day.Text);
                txt_End_DT.Text = CDataConverter.ConvertDateTimeToFormatdmy(CDataConverter.ConvertToDate(Strt_date).AddDays(Total_Days)); 


            }
        }

    }

    protected void txt_End_DT_TextChanged(object sender, EventArgs e)
    {

        if (string.IsNullOrEmpty(txt_Strt_DT.Text) || string.IsNullOrEmpty(txt_End_DT.Text))
        {
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('يجب ادخال تاريخ البداية و النهاية ')</script>");
            return;
        }
        else if (VB_Classes.Dates.Dates_Operation.date_validate(txt_End_DT.Text.Trim()) == "")
        {
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('يجب ادخال تاريخ  النهاية بشكل صحيح ')</script>");
            return;
        }
        else if (VB_Classes.Dates.Dates_Operation.date_validate(txt_Strt_DT.Text.Trim()) == "")
        {
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('يجب ادخال تاريخ  البداية بشكل صحيح ')</script>");
            return;
        }
        else 
        {
            string Strt_date = VB_Classes.Dates.Dates_Operation.date_validate(txt_Strt_DT.Text);
            string End_date = VB_Classes.Dates.Dates_Operation.date_validate(txt_End_DT.Text);
            if (!VB_Classes.Dates.Dates_Operation.Date_compare(Strt_date, End_date))
            {
                if (!string.IsNullOrEmpty(Strt_date) && !string.IsNullOrEmpty(End_date))
                {
                    DateTime t1 = CDataConverter.ConvertToDate(txt_End_DT.Text);
                    //DateTime tnow = DateTime.Now;

                  DateTime tnow = CDataConverter.ConvertDateTimeNowRtnDt();
                    if (t1 < tnow)
                    {
                        lbl_prot_sit.ForeColor = System.Drawing.Color.Red;
                        lbl_prot_sit.Text = "منتهي";
                    }
                    else
                    {
                        lbl_prot_sit.ForeColor = System.Drawing.Color.Black;
                        lbl_prot_sit.Text = "قائم";
                    }
                    int Total_Days = CDataConverter.ConvertToDate(End_date).Subtract(CDataConverter.ConvertToDate(Strt_date)).Days;
                    int Year = Total_Days / 360;
                    txt_Period_Year.Text = Year.ToString();
                    int month = (Total_Days % 360) / 30;
                    int days = (Total_Days % 360) % 30;
                    if (days > 15)
                    {
                        txt_Period_Month.Text = (month + 1).ToString();
                        //txt_Period_Day.Text = (30 - days).ToString();
                    }
                    else
                    {
                        txt_Period_Month.Text = month.ToString();
                        //txt_Period_Day.Text = days.ToString();
                    }

                }
                else
                {
                    Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('أدخل التاريخ يوم/شهر/سنة ')</script>");
                    return;

                }
            }
            else
            {
                Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('تاريخ النهاية يجب ان يكون اكبر من تاريخ البداية')</script>");
                return;

            }
        }
        
    }

    protected void TabPanel_All_ActiveTabChanged(object sender, EventArgs e)
    {
        if (TabPanel_All.ActiveTab == TabPanel_committee)
        {
            fil_smart_org_comittee();
        }
    }

    protected void drop_relation_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drop_relation.SelectedValue != "0")
        {
            lbl_prot.Visible = true;
            smart_Protocol.Visible = true;
        }
        else
        {
            lbl_prot.Visible = false;
            smart_Protocol.Visible = false;
        }
       
    }
}
