using System;
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



public partial class WebForms2_Project_Activities : System.Web.UI.Page
{
    //Session_CS Session_CS = new Session_CS();
    private string sql_Connection = Database.ConnectionString;

    General_Helping Obj_General_Helping = new General_Helping();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GenerateTree();
            FillDDL();
            FillGrid();
            FillChkBoxTeam();
          
        }
    }
  

    private void FillGrid()
    {
        DataTable dt_Level = activityLeveling.ActivLevls.leveling(CDataConverter.ConvertToInt(Session_CS.Project_id), 0, 0, 0, 0);
        gvSub.DataSource = dt_Level;
        gvSub.DataBind();
        if (dt_Level.Rows.Count > 0)
        {
            int rw_indx = 0;
            Decimal projProgress = 0;
            foreach (DataRow rw in dt_Level.Rows)
            {
                if (CDataConverter.ConvertToInt(rw["PActv_Parent"]) == 0)
                {
                    projProgress += CDataConverter.ConvertToDecimal(rw["PActv_wieght"]) * CDataConverter.ConvertToDecimal(rw["PActv_Progress"]) / 100;
                }

                ((ProgressBar)gvSub.Rows[rw_indx].FindControl("SubPB")).SetProgress(CDataConverter.ConvertToInt(rw["PActv_Progress"]), 100);
                rw_indx += 1;
            }

            if (projProgress != 0)
                lblProgProgress.Text = (projProgress).ToString("#.00") + "%";
            else
                lblProgProgress.Text = (projProgress).ToString() + "%";
            
        }
        else
        {
            lblProgProgress.Text = "0%";
        }

    }
    private void FillDDL()
     {
        string sql5 = "SELECT PActv_ID,PActv_Desc FROM Project_Activities where proj_proj_id=" + CDataConverter.ConvertToInt(Session_CS.Project_id) + " order by PActv_ID";
        DataTable _dt5 = General_Helping.GetDataTable(sql5);

        Obj_General_Helping.SmartBindDDL(ddlActivities, _dt5, "PActv_ID", "PActv_Desc", "اختر النشاط");

        string sql4 = "select * from Active_Satatus";
        DataTable _dt4 = General_Helping.GetDataTable(sql4);

        Obj_General_Helping.SmartBindDDL(ddlActvSit, _dt4, "ActStat_ID", "ActStat_Desc", "اختر موقف التنفيذ");

      }           
    private void FillChkBoxTeam()
    {
        string sql5   = "";
        sql5 = "select * from Project_Team where proj_proj_id=" + CDataConverter.ConvertToInt(Session_CS.Project_id);
           sql5+= " and rol_rol_id <> 4";
        DataTable _dt5   = General_Helping.GetDataTable(sql5);
        chkBoxTeam.DataTextField = "PTem_Name";
        chkBoxTeam.DataValueField = "pmp_pmp_id";
        chkBoxTeam.DataSource = _dt5;
        chkBoxTeam.DataBind();
       
    }
    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);

        //link the css file
        this.lASTreeViewThemeCssFile.Text = "<link id='astreeviewcssfile' href='' type='text/css' rel='stylesheet' />";

        string script = string.Format("document.getElementById('astreeviewcssfile').href='{0}'", this.astvMyTree.ThemeCssFile);
        this.ClientScript.RegisterStartupScript(this.GetType(), "js" + Guid.NewGuid().ToString(), script, true);

    }

    

    protected override void OnInit(EventArgs e)
    {
        #region BROWSER FOR departments

        Smart_Search_org.sql_Connection = sql_Connection;
       // Smart_Search_org.Query = "SELECT Org_ID, Org_Desc FROM Organization";
        string Query = "SELECT Org_ID, Org_Desc FROM Organization";
        Smart_Search_org.datatble = General_Helping.GetDataTable(Query);
        Smart_Search_org.Value_Field = "ORG_id";
        Smart_Search_org.Text_Field = "Org_Desc";
        Smart_Search_org.DataBind();
        

        #endregion
        base.OnInit(e);
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
        string sql = "select PActv_ID,PActv_Desc,PActv_Parent from Project_Activities where 1=1 ";
        sql += " AND proj_proj_id = " + CDataConverter.ConvertToInt(Session_CS.Project_id.ToString());
        sql += " order by PActv_ID";

        DT_Tree = General_Helping.GetDataTable(sql);

        ASTreeViewDataTableColumnDescriptor descripter = new ASTreeViewDataTableColumnDescriptor("PActv_Desc"
            , "PActv_ID"
            , "PActv_Parent");
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


        //string newParentValue = this.txtNewParentNode.Text;
        //string prevNodeVal = this.txtCurrentNode.Text;
        //ASTreeViewNode node = this.astvMyTree.FindByValue(newParentValue);
        //bool isFirst = false;
        //if (CDataConverter.ConvertToInt(newParentValue) <= 0)
        //{
        //    General_Helping.ExcuteQuery("UPDATE Departments_Documents set Parent_ID=0 where File_ID =" + CDataConverter.ConvertToInt(curNodeValue));
        //}
        //else
        //{
        //    foreach (ASTreeViewNode child in node.ChildNodes)
        //    {
        //        prevNodeVal = curNodeValue;
        //        curNodeValue = child.NodeValue;
        //        if (this.txtCurrentNode.Text == child.NodeValue)
        //        {
        //            DataTable Prev_Node = new DataTable();
        //            int Prev_Order;
        //            if (!isFirst)
        //            {
        //                Prev_Node = General_Helping.GetDataTable("select * from Departments_Documents where File_ID =" + CDataConverter.ConvertToInt(child.NodeValue));
        //                if (Prev_Node.Rows.Count > 0)
        //                {
        //                    General_Helping.ExcuteQuery("UPDATE Departments_Documents set TheOrder=0, Parent_ID=" + newParentValue + " where File_ID =" + CDataConverter.ConvertToInt(curNodeValue));
        //                    General_Helping.ExcuteQuery("UPDATE Departments_Documents set TheOrder=TheOrder+1 where Parent_ID =" + CDataConverter.ConvertToInt(newParentValue) + " and File_ID<>" + CDataConverter.ConvertToInt(curNodeValue));
        //                }
        //            }
        //            else
        //            {
        //                Prev_Node = General_Helping.GetDataTable("select * from Departments_Documents where File_ID =" + CDataConverter.ConvertToInt(prevNodeVal));
        //                if (Prev_Node.Rows.Count > 0)
        //                {
        //                    Prev_Order = CDataConverter.ConvertToInt(Prev_Node.Rows[0]["TheOrder"].ToString()) + 1;
        //                    int curOrder = Prev_Order + 1;
        //                    General_Helping.ExcuteQuery("UPDATE Departments_Documents set TheOrder=" + Prev_Order + ", Parent_ID=" + newParentValue + " where File_ID =" + CDataConverter.ConvertToInt(curNodeValue));
        //                    General_Helping.ExcuteQuery("UPDATE Departments_Documents set TheOrder=TheOrder+" + Prev_Order + " where Parent_ID =" + CDataConverter.ConvertToInt(newParentValue) + " and TheOrder>=" + Prev_Order + " and File_ID<>" + CDataConverter.ConvertToInt(curNodeValue));
        //                }
        //            }
        //            break;
        //        }
        //        isFirst = true;
        //    }
        //}
    }

    protected void btnPostBackTrigger2_Click(object sender, EventArgs e)
    {
        string curNodeValue = this.txtCurrentNode.Text;
        this.txtCurrentNode.BackColor = System.Drawing.Color.SkyBlue;
        ASTreeViewNode node = this.astvMyTree.FindByValue(curNodeValue);

        // show activity details

        //if (astvMyTree.GetSelectedNode() == null)
        //    Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('يجب إختيار النشاط أولا')</script>");
        //else if (CDataConverter.ConvertToInt(astvMyTree.GetSelectedNode().NodeValue) <= 0)
        //    Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('يجب إختيار النشاط أولا')</script>");
        Clear_Control();
        //if (node.ChildNodes.Count > 0)
        //    //txt_Progress.Enabled = false;

        Project_Activities_DT obj = Project_Activities_DB.SelectByID(CDataConverter.ConvertToInt(txtCurrentNode.Text));
        txtDesc.Text = obj.PActv_Desc;
        //txt_PActv_wieght.Text = CDataConverter.ConvertToInt(obj.PActv_wieght).ToString();
        //txt_Progress.Text = CDataConverter.ConvertToInt(obj.PActv_Progress).ToString();
        txtStartDate.Text = obj.PActv_Start_Date;
        txtEndDate.Text = obj.PActv_End_Date;
        txtPeriod.Text = obj.PActv_Period.ToString();
        txtActStartDate.Text = obj.PActv_Actual_Start_Date.ToString();
        txtActEndDate.Text = obj.PActv_Actual_End_Date.ToString();
        txtPeriod.Text = obj.PActv_Actual_Period.ToString();
        if (obj.ActStat_ActStat_id > 0)
            ddlActvSit.SelectedValue = obj.ActStat_ActStat_id.ToString();
        Smart_Search_org.SelectedValue = obj.Excutive_responsible_Org_Org_id.ToString();
        txtExPer.Text = obj.PActv_Implementing_person;
        txtActvNote.Text = obj.Notes;
        txtSummery.Text = obj.summery;
        if (obj.priorities > 0)
        ddlPriorities.SelectedValue = obj.priorities.ToString();

        Show_Gov(obj.PActv_ID);

        string sql5 = "";
        sql5 = "select * from Activities_Assigned_team where activ_id=" + CDataConverter.ConvertToInt(txtCurrentNode.Text);
        DataTable _dt5 = General_Helping.GetDataTable(sql5);
        if (_dt5.Rows.Count > 0)
        {
            for (int DTindex = 0; DTindex < _dt5.Rows.Count; DTindex++)
            {
                for (int index = 0; index < chkBoxTeam.Items.Count; index++)
                {

                    if (CDataConverter.ConvertToInt(chkBoxTeam.Items[index].Value) == CDataConverter.ConvertToInt(_dt5.Rows[DTindex]["emp_id"].ToString()))
                    {
                        chkBoxTeam.Items[index].Selected = true;
                        chkBoxTeam.Items[index].Attributes["style"] = "color:red";
                    }

                }
            }

        }
        ddlActivities.Items.Clear();
        string sql55 = "SELECT PActv_ID,PActv_Desc FROM Project_Activities where proj_proj_id=" + CDataConverter.ConvertToInt(Session_CS.Project_id) + " and PActv_ID<>" + CDataConverter.ConvertToInt(txtCurrentNode.Text) + " order by PActv_ID";
        DataTable _dt55 = General_Helping.GetDataTable(sql55);
        if (_dt55.Rows.Count>0)
        Obj_General_Helping.SmartBindDDL(ddlActivities, _dt55, "PActv_ID", "PActv_Desc", "اختر النشاط");
        DataTable dt6 = General_Helping.GetDataTable("select * from Activities_Relations where current_activ =" + CDataConverter.ConvertToInt(txtCurrentNode.Text));
        if (dt6.Rows.Count > 0)
        {
            ddlRelation.SelectedIndex = CDataConverter.ConvertToInt(dt6.Rows[0]["relation"].ToString());
            ddlActivities.SelectedValue = dt6.Rows[0]["related_activ"].ToString();
        }
        else
        {
            ddlRelation.SelectedIndex = 0;
            if (_dt55.Rows.Count > 0)
            ddlActivities.SelectedIndex = 0;
        }
    

        //


        if (node.ParentNode != null)
            this.txtNewParentNode.Text = node.ParentNode.NodeValue;
        //
        //if (node.ChildNodes.Count > 0)
        //    txt_Progress.Enabled = false;

        //string curNodeValue = this.txtCurrentNode.Text;

        //if (CDataConverter.ConvertToInt(curNodeValue) > 0)
        //{
        //    btn_Doc.Text = "تعديل";
        //    Fill_Controll(CDataConverter.ConvertToInt(curNodeValue));
        //}
    }

    protected void btnPostBackTrigger3_Click(object sender, EventArgs e)
    {
        //string curFileValue = hidden_File_ID.Value;

        //if (CDataConverter.ConvertToInt(curFileValue) > 0)
        //{
        //    FillLog(CDataConverter.ConvertToInt(curFileValue), "read");
        //}
    }

    protected void chkAllMain_CheckedChanged(object sender, EventArgs e)
    {
        foreach (ListItem item in chk_gov_list.Items)
        {
            item.Selected = chkAllMain.Checked;
        }
    }
   
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        int operation;
        if (CDataConverter.ConvertToInt(txtCurrentNode.Text) == 0)
            operation = (int)Project_Log_DB.Action.add;
        else
            operation = (int)Project_Log_DB.Action.edit;

        if (Check_Valid())
        {
            Project_Activities_DT obj = new Project_Activities_DT();
            obj.PActv_ID = CDataConverter.ConvertToInt(txtCurrentNode.Text);
            obj.PActv_Desc = txtDesc.Text;
            obj.PActv_Start_Date = txtStartDate.Text;
            obj.PActv_End_Date = txtEndDate.Text;
            obj.PActv_Period = CDataConverter.ConvertToDecimal(txtPeriod.Text);
            obj.PActv_Actual_Start_Date = txtActStartDate.Text;
            obj.PActv_Actual_End_Date = txtActEndDate.Text;
            obj.PActv_Actual_Period = CDataConverter.ConvertToDecimal(txtPeriod.Text);
            obj.PActv_Parent = CDataConverter.ConvertToInt(txtNewParentNode.Text);
            obj.PActv_is_Milestone = 0;
            obj.proj_proj_id = CDataConverter.ConvertToInt(Session_CS.Project_id.ToString());
            obj.ActStat_ActStat_id = CDataConverter.ConvertToInt(ddlActvSit.SelectedValue);
            obj.priorities = CDataConverter.ConvertToInt(ddlPriorities.SelectedValue);
            obj.Excutive_responsible_Org_Org_id = CDataConverter.ConvertToInt(Smart_Search_org.SelectedValue);
            obj.PActv_Implementing_person = txtExPer.Text;
            obj.Notes = txtActvNote.Text;
            obj.summery = txtSummery.Text;
            obj.PActv_ID = Project_Activities_DB.Save(obj);
            //Project_Activities_Versions_DB.Save(obj, "00", "0000");
            Project_Activities_Versions_DB.Save(obj, DateTime.Now.Month.ToString(), CDataConverter.ConvertDateTimeNowRtnDt().Year.ToString());
            Save_Gov(obj.PActv_ID);
            Project_Log_DB.FillLog(CDataConverter.ConvertToInt(obj.PActv_ID), operation, Project_Log_DB.operation.Project_Activities);
            
            GenerateTree();

            if (obj.PActv_ID > 0)
            { 
                //ASTreeViewNode node = this.astvMyTree.FindByValue(obj.PActv_ID.ToString());
                //if (node != null && node.ChildNodes.Count == 0 && !string.IsNullOrEmpty(txt_Progress.Text) && !string.IsNullOrEmpty(txt_PActv_wieght.Text))
                //{
                    Project_Activities_DB.Increase_Recurcive_Activites(obj.PActv_ID);
                //}
                //save assigned team
                General_Helping.ExcuteQuery("delete from Activities_Assigned_team where activ_id=" + obj.PActv_ID);
                string sql5   = "";
                sql5 = "select * from Project_Team where proj_proj_id=" + CDataConverter.ConvertToInt(Session_CS.Project_id);
                   sql5+=  " and rol_rol_id <> 4";
                DataTable _dt5   = General_Helping.GetDataTable(sql5);
                if( _dt5.Rows.Count > 0 ){
                    for (int index = 0;index<_dt5.Rows.Count;index++)
                    {
                        if( chkBoxTeam.Items[index].Selected == true){
                            General_Helping.ExcuteQuery("insert into Activities_Assigned_team (activ_id,emp_id) values (" + obj.PActv_ID + "," + chkBoxTeam.Items[index].Value + ")");
                        }
                    }

                }
                //
                // save activity relation with another avtivity
                if (ddlActivities.SelectedIndex != 0 && ddlRelation.SelectedIndex != 0)
                    {
                        General_Helping.ExcuteQuery("delete from Activities_Relations where current_activ=" + obj.PActv_ID);
                        General_Helping.ExcuteQuery("insert into Activities_Relations (current_activ,related_activ,relation) values (" + obj.PActv_ID + "," + CDataConverter.ConvertToInt(ddlActivities.SelectedValue) + "," + ddlRelation.SelectedIndex+ ")");
                    }
                //
                FillGrid();
                //txtCurrentNode.Text =
                //txtNewParentNode.Text = "";
                Clear_Control();
                
                Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم الحفظ بنجاح')</script>");
            }
            
        }
    }

    
    private bool Check_Valid()
    {
        bool Flag = true;
       
        int PActv_Parent = CDataConverter.ConvertToInt(txtNewParentNode.Text);
        int PActv_ID = CDataConverter.ConvertToInt(txtCurrentNode.Text);


        // validate start date

        //if (Dates_operations.date_validate(txtStartDate.Text) != "")
        //{
        //    txtStartDate.Text = Dates_operations.date_validate(txtStartDate.Text);
     if (txtStartDate.Text != "")
        {
            txtStartDate.Text = CDataConverter.ConvertDateTimeToFormatdmy(CDataConverter.ConvertToDate(txtStartDate.Text));
        }
        else if (txtStartDate.Text != "")
        {
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('أدخل التاريخ (يوم/شهر/سنة) ')</script>");
            txtStartDate.Text = "";
            Flag = false;
            return Flag;
        }
        ////
        // validate end date

        if (txtEndDate.Text != "")
            //if (Dates_operations.date_validate(txtEndDate.Text) != "")
        {
            //txtEndDate.Text = Dates_operations.date_validate(txtEndDate.Text);
            txtEndDate.Text = CDataConverter.ConvertDateTimeToFormatdmy(CDataConverter.ConvertToDate(txtEndDate.Text));
        }
        else if (txtEndDate.Text != "")
        {
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('أدخل التاريخ (يوم/شهر/سنة) ')</script>");
            txtEndDate.Text = "";
            Flag = false;
            return Flag;
        }
        //
        //// compare start and end dates
        if (txtEndDate.Text != "" && txtStartDate.Text != "")
        {
            if (Dates_operations.Date_compare(txtEndDate.Text, txtStartDate.Text) == false)
            {
                Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('تاريخ البداية  يجب أن يكون قبل تاريخ النهاية ')</script>");
                txtEndDate.Text = "";
                Flag = false;
                return Flag;
            }
        }
        // validate actual start date

        if (txtActStartDate.Text != "")
           // if (Dates_operations.date_validate(txtActStartDate.Text) != "")
        {
            //txtActStartDate.Text = Dates_operations.date_validate(txtActStartDate.Text);
            txtActStartDate.Text = CDataConverter.ConvertDateTimeToFormatdmy(CDataConverter.ConvertToDate(txtActStartDate.Text));

        }
        else if (txtActStartDate.Text != "")
        {
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('أدخل التاريخ (يوم/شهر/سنة) ')</script>");
            txtActStartDate.Text = "";
            Flag = false;
            return Flag;
        }
        ////
        // validate actual end date

       // if (Dates_operations.date_validate(txtActEndDate.Text) != "")

        if (txtActEndDate.Text != "")
        {
            //txtActEndDate.Text = Dates_operations.date_validate(txtActEndDate.Text);
            txtActEndDate.Text = CDataConverter.ConvertDateTimeToFormatdmy(CDataConverter.ConvertToDate(txtActEndDate.Text));
        }
        else if (txtActEndDate.Text != "")
        {
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('أدخل التاريخ (يوم/شهر/سنة) ')</script>");
            txtActEndDate.Text = "";
            Flag = false;
            return Flag;
        }
        //
        ////txtActStartDate.Text;
        // txtActEndDate.Text;
        // compare actual start and actual end
        if (txtActEndDate.Text != "" && txtActStartDate.Text != "")
        {
            if (Dates_operations.Date_compare(txtActEndDate.Text, txtActStartDate.Text) == false)
            {
                Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('تاريخ البداية الفعلى يجب أن يكون قبل تاريخ النهاية الفعلى ')</script>");
                txtActEndDate.Text = "";
                Flag = false;
                return Flag;
            }
        }
        /////

        //decimal Parent_Weight = 0;
        //decimal activ_progress = CDataConverter.ConvertToDecimal(txt_Progress.Text.ToString());
        //decimal Total_Weight = CDataConverter.ConvertToDecimal(txt_PActv_wieght.Text.ToString());
        //decimal total_childs_weight = 0;

        //if (PActv_Parent != 0)
        //{
        //    Project_Activities_DT main_Activ_Obj = Project_Activities_DB.SelectByID(PActv_Parent);
        //    Parent_Weight = main_Activ_Obj.PActv_wieght;
        //    string tempSql = " select sum(PActv_wieght) as PActv_wieght  from Project_Activities where proj_proj_id = " + Session_CS.Project_id.ToString() + " and PActv_Parent =  " + PActv_Parent;
        //    DataTable Dt = General_Helping.GetDataTable(tempSql);
        //    if (Dt.Rows.Count > 0)
        //    {
        //        //for (int i = 0; i < Dt.Rows.Count; i++)
        //        total_childs_weight += CDataConverter.ConvertToDecimal(Dt.Rows[0]["PActv_wieght"].ToString());
        //    }
        //    if (total_childs_weight > Total_Weight)
        //    {

        //        Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('الوزن النسبى أقل من الأوزان النسبية للأنشطة الفرعية%')</script>");

        //        Flag = false;
        //        return Flag;

        //    }
        //    string tempSql1 = " select sum(PActv_wieght) as PActv_wieght  from Project_Activities where proj_proj_id = " + Session_CS.Project_id.ToString() + " and PActv_Parent =  " + PActv_Parent + " and PActv_ID != " + PActv_ID;
        //    DataTable Dt1 = General_Helping.GetDataTable(tempSql1);

        //    if (Dt1.Rows.Count > 0)
        //    {
        //        //for (int i = 0; i < Dt1.Rows.Count; i++)
        //        Total_Weight += CDataConverter.ConvertToDecimal(Dt1.Rows[0]["PActv_wieght"].ToString());
        //    }
        //    if (Total_Weight > Parent_Weight)
        //    {

        //        Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('إجمالى الوزن النسبى يتعدى النشاط الرئيسى   %')</script>");

        //        Flag = false;
        //        return Flag;

        //    }
        //}
        //else
        //{

        //    string tempSql = " select sum(PActv_wieght) as PActv_wieght  from Project_Activities where proj_proj_id = " + Session_CS.Project_id.ToString() + " and PActv_Parent =  " + PActv_ID;
        //    DataTable Dt = General_Helping.GetDataTable(tempSql);
        //    if (Dt.Rows.Count > 0)
        //    {
        //        //for (int i = 0; i < Dt.Rows.Count; i++)
        //        total_childs_weight += CDataConverter.ConvertToDecimal(Dt.Rows[0]["PActv_wieght"].ToString());
        //    }
        //    if (total_childs_weight > Total_Weight)
        //    {

        //        Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('الوزن النسبى أقل من الأوزان النسبية للأنشطة الفرعية%')</script>");

        //        Flag = false;
        //        return Flag;

        //    }
        //    string tempSql1 = " select sum(PActv_wieght) as PActv_wieght  from Project_Activities where proj_proj_id = " + Session_CS.Project_id.ToString() + " and PActv_Parent = 0 and PActv_ID != " + PActv_ID;
        //    DataTable Dt1 = General_Helping.GetDataTable(tempSql1);
        //    if (Dt1.Rows.Count > 0)
        //    {
        //        //for (int i = 0; i < Dt1.Rows.Count; i++)
        //        Total_Weight += CDataConverter.ConvertToDecimal(Dt1.Rows[0]["PActv_wieght"].ToString());
        //    }

        //}

        //if (Total_Weight > 100)
        //{

        //    Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('إجمالى الوزن النسبى يتعدى 100 ')</script>");

        //    Flag = false;
        //    return Flag;

        //}


        //if (activ_progress > 100)
        //{
        //    Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('نسبة الأنجاز تتعدى 100 %')</script>");

        //    Flag = false;
        //    return Flag;
        //}


        //ASTreeViewNode node = this.astvMyTree.FindByValue(this.txtCurrentNode.Text);
        //if (node != null && node.ChildNodes.Count < 0 && !string.IsNullOrEmpty(txt_Progress.Text))
        //{
        //    if (string.IsNullOrEmpty(txt_PActv_wieght.Text))
        //    {
        //        Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('يجب إدخال نسبة الإنجاز')</script>");

        //        Flag = false;
        //    }

        //}


        //if (Child_Total_Weight > Parent_ToTal_Weight)
        //{

        //    Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('إجمالى الوزن النسبى للفرعى يتعدى الوزن النسبى للرئيسى')</script>");

        //    Flag = false;

        //}


        return Flag;
    }
    protected void btn_New_Click(object sender, EventArgs e)
    {
        
        txtCurrentNode.Text =
            txtNewParentNode.Text = "";
        astvMyTree.ClearNodesSelection();
        //GenerateTree();
        Clear_Control();
    }

    private void Clear_Control()
    {
        //  txtCurrentNode.Text =
        
        //txt_PActv_wieght.Text =
        txtDesc.Text =
        txtStartDate.Text =
        txtEndDate.Text =
        txtPeriod.Text =
        txtActStartDate.Text =
        txtActEndDate.Text =
        txtPeriod.Text =
        //txt_Progress.Text =
            // txtNewParentNode.Text =
         txtExPer.Text =
        txtActvNote.Text = "";
        txtSummery.Text = "";
        ddlPriorities.SelectedIndex = 0;
        ddlActvSit.SelectedIndex = 0;
        //txt_Progress.Enabled = true;    
        for(int index = 0 ;index< chkBoxTeam.Items.Count ; index++){
            chkBoxTeam.Items[index].Selected = false;
            chkBoxTeam.Items[index].Attributes["style"] = "color:black";
            
        }
        chkAllMain.Checked = false;
        for (int index = 0; index < chk_gov_list.Items.Count; index++)
        {
            chk_gov_list.Items[index].Selected = false;
           

        }
        if (ddlActivities.Items.Count > 0)
            ddlActivities.SelectedIndex = 0;
        if (ddlRelation.Items.Count > 0)
            ddlRelation.SelectedIndex = 0;
    }

    protected void btn_New_same_Click(object sender, EventArgs e)
    {
        if (astvMyTree.GetSelectedNode() == null)
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('يجب إختيار النشاط أولا')</script>");
        else            if (CDataConverter.ConvertToInt(astvMyTree.GetSelectedNode().NodeValue) <= 0)
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('يجب إختيار النشاط أولا')</script>");

        else
        {
            txtCurrentNode.Text = "0";
            Clear_Control();
        }

    }

    protected void btn_New_Under_Click(object sender, EventArgs e)
    {
        if (astvMyTree.GetSelectedNode() == null)
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('يجب إختيار النشاط أولا')</script>");
        else if (CDataConverter.ConvertToInt(astvMyTree.GetSelectedNode().NodeValue) <= 0)
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('يجب إختيار النشاط أولا')</script>");

        else
        {
            txtNewParentNode.Text = txtCurrentNode.Text;
            txtCurrentNode.Text = "0";
            Clear_Control();
        }
    }

    protected void btn_New_Show_Click(object sender, EventArgs e)
    {
        
    }

    private void Show_Gov(long activity_id)
    {
        string Sql_Delete = "select * from Project_Activities_gov where activity_id =" + activity_id;
        DataTable DT = General_Helping.GetDataTable(Sql_Delete);
        foreach (DataRow dr in DT.Rows)
        {
            string Value = dr["gov_id"].ToString();
            ListItem item = chk_gov_list.Items.FindByValue(Value);
            if (item != null)
                item.Selected = true;
        }
    }

    protected void btn_New_Delete_Click(object sender, EventArgs e)
    {
        if (CDataConverter.ConvertToInt(txtCurrentNode.Text) <= 0)
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('يجب إختيار النشاط أولا')</script>");

        else
        {
            ASTreeViewNode node = this.astvMyTree.FindByValue(txtCurrentNode.Text);
            

            if (node != null && node.ChildNodes.Count == 0 )
            {
                Project_Activities_DT obj = Project_Activities_DB.SelectByID(CDataConverter.ConvertToInt(txtCurrentNode.Text));
                obj.PActv_Progress = 0;
                obj.PActv_wieght = 0;
                Project_Activities_DB.Save(obj);

                Project_Activities_DB.Increase_Recurcive(obj.PActv_ID);

                Project_Activities_DB.Delete(CDataConverter.ConvertToInt(txtCurrentNode.Text));
                Clear_Control();
                GenerateTree();
                FillGrid();
                Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم الحذف بنجاح')</script>");
            }

            if (node.ChildNodes.Count != 0)
            {
                Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لا يمكن حذف هذا النشاط حيث أن لديه أنشطة فرعية')</script>");
            }

        }
    }

    private void Save_Gov(long activity_id)
    {
        string Sql_Delete = "delete from Project_Activities_gov where activity_id =" + activity_id;
        General_Helping.ExcuteQuery(Sql_Delete);
        foreach (ListItem item in chk_gov_list.Items)
        {
            if (item.Selected)
            {
                string Sql_insert = "insert into Project_Activities_gov ( activity_id,gov_id  ) values ( " + activity_id + "," + item.Value + ")";
                General_Helping.ExcuteQuery(Sql_insert);
                item.Selected = false;
            }

        }
    }
    protected void gvSub_PreRender1(object sender, EventArgs e)
    {
        MergeRows(gvSub);
        
        
    }
    
    protected void MergeRows(GridView GridView)
    {
        //DataTable dt_Level = activityLeveling.ActivLevls.leveling(CDataConverter.ConvertToInt(Session_CS.Project_id), 0, 0);
        if (GridView.Rows.Count > 1)
        {

            for (int rowIndex = GridView.Rows.Count - 2; rowIndex > -1; rowIndex--)
            {
                GridViewRow row = GridView.Rows[rowIndex];
                GridViewRow previousRow = GridView.Rows[rowIndex + 1];
                int lvl_row = CDataConverter.ConvertToInt(((TextBox)row.FindControl("txtLevel")).Text);
                int lvl_previousRow = CDataConverter.ConvertToInt(((TextBox)previousRow.FindControl("txtLevel")).Text);

                if (lvl_previousRow < 5)
                    previousRow.Font.Size = 16 - lvl_previousRow * 2;
                else
                    previousRow.Font.Size = 8;


                if (lvl_row == 1)
                {
                    row.Font.Bold = true;
                    row.Font.Size = 14;
                    row.BackColor = System.Drawing.Color.FromArgb(235, 236, 239);
                    row.ForeColor = System.Drawing.Color.Black;

                }
                if (lvl_previousRow == 1)
                {
                    previousRow.Font.Bold = true;
                    previousRow.Font.Size = 14;
                    previousRow.BackColor = System.Drawing.Color.FromArgb(235, 236, 239);
                    previousRow.ForeColor = System.Drawing.Color.Black;
                }
                if (lvl_previousRow == 2)
                    previousRow.BackColor = System.Drawing.Color.FromArgb(138, 173, 198);

                if (lvl_previousRow == 3)
                    previousRow.BackColor = System.Drawing.Color.FromArgb(175, 207, 229);

                if (lvl_previousRow == 4)
                    previousRow.BackColor = System.Drawing.Color.FromArgb(194, 221, 238);

                if (lvl_previousRow == 5)
                    previousRow.BackColor = System.Drawing.Color.FromArgb(212, 226, 243);

                if (lvl_previousRow == 6)
                    previousRow.BackColor = System.Drawing.Color.FromArgb(240, 226, 243);

                if (lvl_previousRow == 7)
                    previousRow.BackColor = System.Drawing.Color.White;

                if (lvl_previousRow == 8)
                    previousRow.BackColor = System.Drawing.Color.White;

                if (lvl_previousRow == 9)
                    previousRow.BackColor = System.Drawing.Color.White;




                if (previousRow.Cells[1].Text == "&nbsp;")
                {
                    if (previousRow.Cells[1].RowSpan < 2)
                        row.Cells[1].RowSpan = 2;
                    else
                        row.Cells[1].RowSpan = CDataConverter.ConvertToInt(previousRow.Cells[1].RowSpan + 1);

                    previousRow.Cells[1].Visible = false;
                }


            }
        }
        else if (GridView.Rows.Count == 1)
        {
            GridView.Rows[0].Cells[1].Font.Bold = true;
            GridView.Rows[0].Cells[1].Font.Size = 14;
            GridView.Rows[0].Cells[1].BackColor = System.Drawing.Color.FromArgb(235, 236, 239);
        }
    }
    protected void ddlRelation_SelectedIndexChanged(object sender, EventArgs e)
    {
       // buildRelation();
       // FillDDL();
    }
    protected void ddlActivities_SelectedIndexChanged(object sender, EventArgs e)
    {
        buildRelation();
    }
    private void buildRelation()
    {
        if (ddlRelation.SelectedIndex != 0 && ddlActivities.SelectedIndex != 0)
        {
            if (ddlRelation.SelectedIndex == 1  )
            {
                txtStartDate.Text = (General_Helping.GetDataTable("select PActv_Start_Date from Project_Activities where PActv_ID=" + CDataConverter.ConvertToInt(ddlActivities.SelectedValue)).Rows[0]["PActv_Start_Date"]).ToString();
                
                
                
            }
            else if (ddlRelation.SelectedIndex == 2)
            {
                txtStartDate.Text = (General_Helping.GetDataTable("select PActv_End_Date from Project_Activities where PActv_ID=" + CDataConverter.ConvertToInt(ddlActivities.SelectedValue)).Rows[0]["PActv_End_Date"]).ToString();
            }
            else if (ddlRelation.SelectedIndex == 3)
            {
                txtEndDate.Text = (General_Helping.GetDataTable("select PActv_Start_Date from Project_Activities where PActv_ID=" + CDataConverter.ConvertToInt(ddlActivities.SelectedValue)).Rows[0]["PActv_Start_Date"]).ToString();
            }
            else if (ddlRelation.SelectedIndex == 4)
            {
                txtEndDate.Text = (General_Helping.GetDataTable("select PActv_End_Date from Project_Activities where PActv_ID=" + CDataConverter.ConvertToInt(ddlActivities.SelectedValue)).Rows[0]["PActv_End_Date"]).ToString();
            }
        
        }
    }

    protected void btn_Mpp_Create_Click(object sender, EventArgs e)
     {
         Create_MPP();
     }
    private void Create_MPP()
    {
        string File_Name; //= "D://Test_Project.mpp";
        File_Name = Server.MapPath("~//Uploads/Project_Activities.mpp");
        Application appclass = new Application();

        appclass.FileOpen(File_Name, false, Missing.Value, Missing.Value, Missing.Value,
        Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value,
        PjPoolOpen.pjDoNotOpenPool, Missing.Value, Missing.Value, true, Missing.Value);



        appclass.Visible = false;
        Project proj = appclass.ActiveProject;
        for (int z = 1; z <= 3; z++)
            foreach (Microsoft.Office.Interop.MSProject.Task task_old in proj.Tasks)
                task_old.Delete();

        Microsoft.Office.Interop.MSProject.Task task;



        DataTable DT_Proj_Activitess = General_Helping.GetDataTable("select * from Project_Activities where PActv_Parent=0 and proj_proj_id =" + CDataConverter.ConvertToInt(Session_CS.Project_id) + "order by PActv_ID DESC ");
        for (int i = 0; i < DT_Proj_Activitess.Rows.Count; i++)
        {

            task = proj.Tasks.Add(DT_Proj_Activitess.Rows[i]["PActv_Desc"].ToString(), 1);
            task.PercentWorkComplete = DT_Proj_Activitess.Rows[i]["PActv_Progress"].ToString();
            task.OutlineLevel = (short)(1);
            if (CDataConverter.ConvertToInt(DT_Proj_Activitess.Rows[i]["PActv_Period"].ToString()) > 0)
                task.Duration = DT_Proj_Activitess.Rows[i]["PActv_Period"].ToString();
            task.Start = DT_Proj_Activitess.Rows[i]["PActv_Start_Date"].ToString();
            task.Finish = DT_Proj_Activitess.Rows[i]["PActv_End_Date"].ToString();
            task.Text1 = DT_Proj_Activitess.Rows[i]["PActv_Desc"].ToString();

            Load_Rec(proj, 1, DT_Proj_Activitess.Rows[i]["PActv_ID"].ToString());

        }



        appclass.SaveSheetSelection();
        appclass.FileCloseAll(PjSaveType.pjSave);



        // for open document for user
        FileStream fs = new FileStream(File_Name, FileMode.Open, FileAccess.Read);

        byte[] bytes = new byte[fs.Length];

        fs.Read(bytes, 0, System.Convert.ToInt32(fs.Length));

        fs.Close();


        Response.ContentType = "application/x-unknown";
        string File_Name_Show = "";
        File_Name_Show = "Project_Activities.mpp";
        Response.AddHeader("Content-Disposition", "attachment; filename=" + Server.UrlPathEncode(File_Name_Show));
        Response.BinaryWrite(bytes);
        Response.Flush();
        Response.Close();




    }

    private void Load_Rec(Project proj, int OutlineLevel, string PActv_ID)
    {
        Microsoft.Office.Interop.MSProject.Task task;
        DataTable DT_Proj_Activitess = new DataTable();
        DT_Proj_Activitess = General_Helping.GetDataTable("select * from Project_Activities where PActv_Parent =" + PActv_ID + "order by PActv_ID DESC ");

        if (DT_Proj_Activitess.Rows.Count != 0)
        {
            for (int i = 0; i < DT_Proj_Activitess.Rows.Count; i++)
            {

                DataRow row = DT_Proj_Activitess.Rows[i];
                task = proj.Tasks.Add(row["PActv_Desc"].ToString(), OutlineLevel + 1);
                task.PercentWorkComplete = row["PActv_Progress"].ToString();
                task.OutlineLevel = (short)(OutlineLevel + 1);
                if (CDataConverter.ConvertToInt(row["PActv_Period"].ToString()) > 0)
                    task.Duration = row["PActv_Period"].ToString();
                task.Start = row["PActv_Start_Date"].ToString();
                task.Finish = row["PActv_End_Date"].ToString();
                task.Text1 = row["PActv_Desc"].ToString();
                Load_Rec(proj, task.OutlineLevel, row["PActv_ID"].ToString());

            }


        }

    }

    
}


