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

public partial class UserControls_Project_Activities : System.Web.UI.UserControl
{


    public string startDate = "";
    public string endDate = "";
    public string period = "";
    public string actualStartDate = "";
    public string actualEndDate = "";
    public string weight = "";
    public string progress = "";
    public string impPerson = "";
    public int myActiv = 0;
    public int myRowIndex = 0;
    public int fundres_id = 0;
    public int fundres_source = 0;
    public int fundAmount = 0;
    public int pacv_id = 0;
    public int ppp = 0;

  
    private string sql_Connection = Database.ConnectionString;

    General_Helping Obj_General_Helping = new General_Helping();
    //Session_CS Session_CS = new Session_CS();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GenerateTree();

        calc_achievment();

        }


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
        string sql = "select PActv_ID,PActv_Desc,PActv_Parent,PActv_wieght,PActv_Progress  from Project_Activities where 1=1 ";
       // sql += " AND proj_proj_id = " + CDataConverter.ConvertToInt(Session_CS.Project_id.ToString());

        sql += " AND proj_proj_id = " + CDataConverter.ConvertToInt(Session_CS.Project_id);

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
    }


    protected void btnPostBackTrigger2_Click(object sender, EventArgs e)
    {
        string curNodeValue = this.txtCurrentNode.Text;
        this.txtCurrentNode.BackColor = System.Drawing.Color.SkyBlue;
        ASTreeViewNode node = this.astvMyTree.FindByValue(curNodeValue);

        FillGrid();
        btnRowSave.Visible = true;

          
    }


    protected void btnPostBackTrigger3_Click(object sender, EventArgs e)
    {
      
    }


    private void calc_achievment()
    {
        DataTable dt_Level = activityLeveling.ActivLevls.leveling(CDataConverter.ConvertToInt(Session_CS.Project_id), 0, 0, 0, 0);
       



        if (dt_Level.Rows.Count > 0)
        {
            int rw_indx = 0;
            Decimal projProgress = 0;
            DropDownList funding_ddl;


            foreach (DataRow rw in dt_Level.Rows)
            {
                if (CDataConverter.ConvertToInt(rw["PActv_Parent"]) == 0)
                {
                    projProgress += CDataConverter.ConvertToDecimal(rw["PActv_wieght"]) * CDataConverter.ConvertToDecimal(rw["PActv_Progress"]) / 100;
                }

              

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



    private void FillGrid()
    {
        DataTable dt_Level = activityLeveling.ActivLevls.levelingacvtivity(CDataConverter.ConvertToInt(Session_CS.Project_id ), 0, 0, 0, 0,CDataConverter.ConvertToInt(txtCurrentNode.Text));
        gvSub.DataSource = dt_Level;
        gvSub.DataBind();



        if (dt_Level.Rows.Count > 0)
        {
            int rw_indx = 0;
            Decimal projProgress = 0;
            DropDownList funding_ddl;
            foreach (DataRow rw in dt_Level.Rows)
            {
                //if (CDataConverter.ConvertToInt(rw["PActv_Parent"]) == 0)
                //{
                //    projProgress += CDataConverter.ConvertToDecimal(rw["PActv_wieght"]) * CDataConverter.ConvertToDecimal(rw["PActv_Progress"]) / 100;
                //}

                pacv_id = CDataConverter.ConvertToInt(rw["PActv_ID"].ToString());

                int childs_count = CDataConverter.ConvertToInt(General_Helping.GetDataTable("select count(PActv_ID) as count from Project_Activities where PActv_Parent=" + CDataConverter.ConvertToInt(dt_Level.Rows[CDataConverter.ConvertToInt(rw_indx)]["PActv_ID"].ToString())).Rows[0]["count"].ToString());
               


                    TextBox progressTextBox = (TextBox)gvSub.Rows[rw_indx].FindControl("txtPregress");
                    TextBox weightTextBox = (TextBox)gvSub.Rows[rw_indx].FindControl("txtWeight");


                    if (childs_count > 0)
                    {
                        progressTextBox.ReadOnly = true;
                    }

                    string[] progressStr = progressTextBox.Text.Split('.');
                    if (progressStr.Length > 1 && progressStr[1] == "00")
                        progressTextBox.Text = progressStr[0];
                    if (progressTextBox.Text == "100")
                        progressTextBox.BackColor = System.Drawing.Color.LightGreen;




                    rw_indx += 1;

                //if (projProgress != 0)
                //    lblProgProgress.Text = (projProgress).ToString("#.00") + "%";
                //else
                //    lblProgProgress.Text = (projProgress).ToString() + "%";
            }
        }

        else
        {
            lblProgProgress.Text = "0%";
        }

        calc_achievment();
       

    }


    protected void btnRowSave_Click(object sender, EventArgs e)
    {


        foreach (GridViewRow row in gvSub.Rows)
        {



          //  CheckBox chk_chnged = (CheckBox)row.FindControl("chk_chnged");
          //if (chk_chnged.Checked)
          //{
            int PActv_Parenttt = CDataConverter.ConvertToInt(((TextBox)row.FindControl("txtPActv_Parent")).Text);

                TextBox periodTextBox1 = (TextBox)row.FindControl("txtPActv_ID");
                TextBox periodTextBox12 = (TextBox)row.FindControl("txtdat");

                pacv_id = CDataConverter.ConvertToInt(periodTextBox1.Text);


                TextBox startDateTextBox = (TextBox)row.FindControl("txtStartDate");
                TextBox endDateTextBox = (TextBox)row.FindControl("txtEndDate");
                TextBox periodTextBox = (TextBox)row.FindControl("txtPeriod");
                TextBox actualStartDateTextBox = (TextBox)row.FindControl("txtActualStartDate");
                TextBox actualEndDateTextBox = (TextBox)row.FindControl("txtActualEndDate");
                TextBox weightTextBox = (TextBox)row.FindControl("txtWeight");
                TextBox progressTextBox = (TextBox)row.FindControl("txtPregress");
                TextBox impPersonTextBox = (TextBox)row.FindControl("txtImplementingPerson");
                DropDownList ddlfund = (DropDownList)row.FindControl("ddlFundResource");
                TextBox fundingAmountBox = (TextBox)row.FindControl("txtfunds");
                startDate = startDateTextBox.Text;
                endDate = endDateTextBox.Text;
                period = periodTextBox.Text;
                actualStartDate = actualStartDateTextBox.Text;
                actualEndDate = actualEndDateTextBox.Text;
                weight = weightTextBox.Text;
                progress = progressTextBox.Text;
                impPerson = impPersonTextBox.Text;
                if (ddlfund.SelectedValue != "0" && ddlfund.SelectedValue != "")
                {
                    string source_id = ddlfund.SelectedValue.ToString();
                    string source = source_id.Substring(0, 1);
                    string id = source_id.Substring(1);
                    fundres_id = CDataConverter.ConvertToInt(id);
                    fundres_source = CDataConverter.ConvertToInt(source);
                }
                else
                {
                    fundres_id = 0;
                    fundres_source = 0;
                }
                fundAmount = CDataConverter.ConvertToInt(fundingAmountBox.Text);
              if (Check_Valid(pacv_id,PActv_Parenttt))
              {
                    Project_Activities_DT Activ_Obj = Project_Activities_DB.SelectByID(pacv_id);
                    Activ_Obj.PActv_Start_Date = startDate;
                    Activ_Obj.PActv_End_Date = endDate;
                    Activ_Obj.PActv_Period = CDataConverter.ConvertToDecimal(period);
                    Activ_Obj.PActv_Actual_Start_Date = actualStartDate;
                    Activ_Obj.PActv_Actual_End_Date = actualEndDate;
                    Activ_Obj.PActv_wieght = CDataConverter.ConvertToDecimal(weight);
                    Activ_Obj.PActv_Progress = CDataConverter.ConvertToDecimal(progress);
                    Activ_Obj.PActv_Implementing_person = impPerson;
                    Activ_Obj.funding_res_id = fundres_id;
                    Activ_Obj.funding_amount = fundAmount;
                    Activ_Obj.funding_res_source = fundres_source;

                    /////////////////////   validate start date  /////////////////////////////

                    if (Dates_operations.date_validate(startDate) != "")
                    {
                        startDateTextBox.Text = Dates_operations.date_validate(startDate);

                    }
                    else if (startDate != "")
                    {
                        Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('أدخل التاريخ (يوم/شهر/سنة) ')</script>");
                        startDateTextBox.Text = "";
                        
                        return ;
                    }
                    ////
                    // validate end date

                    if (Dates_operations.date_validate(endDate) != "")
                    {
                        endDateTextBox.Text = Dates_operations.date_validate(endDate);

                    }
                    else if (endDate != "")
                    {
                        Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('أدخل التاريخ (يوم/شهر/سنة) ')</script>");
                        endDateTextBox.Text = "";
                        
                        return ;
                    }
                    //
                    //// compare start and end dates
                    if (endDateTextBox.Text != "" && startDateTextBox.Text != "")
                    {
                        if (Dates_operations.Date_compare(endDateTextBox.Text, startDateTextBox.Text) == false)
                        {
                            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('تاريخ البداية  يجب أن يكون قبل تاريخ النهاية ')</script>");
                            endDateTextBox.Text = "";
                           
                            return ;
                        }
                    }
                    ////
                    // validate actual start date

                    if (Dates_operations.date_validate(actualStartDate) != "")
                    {
                        actualStartDate = Dates_operations.date_validate(actualStartDate);

                    }
                    else if (actualStartDate != "")
                    {
                        Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('أدخل التاريخ (يوم/شهر/سنة) ')</script>");
                        actualStartDate = "";
                        
                        return ;
                    }
                    ////
                    // validate actual end date

                    if (Dates_operations.date_validate(actualEndDate) != "")
                    {
                        actualEndDate = Dates_operations.date_validate(actualEndDate);

                    }
                    else if (actualEndDate != "")
                    {
                        Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('أدخل التاريخ (يوم/شهر/سنة) ')</script>");
                        actualEndDate = "";
                       
                        return ;
                    }
                    // compare actual start and actual end
                    if (actualEndDateTextBox.Text != "" && actualStartDateTextBox.Text != "")
                    {
                        if (Dates_operations.Date_compare(actualEndDateTextBox.Text, actualStartDateTextBox.Text) == false)
                        {
                            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('تاريخ البداية الفعلى يجب أن يكون قبل تاريخ النهاية الفعلى ')</script>");
                            actualEndDateTextBox.Text = "";
                         
                            return ;
                        }
                    }

                    Project_Activities_DB.Save(Activ_Obj);

                    Project_Activities_Versions_DB.Save(Activ_Obj, CDataConverter.ConvertDateTimeNowRtnDt().Month.ToString(), CDataConverter.ConvertDateTimeNowRtnDt().Year.ToString());




                    Project_Log_DB.FillLog(CDataConverter.ConvertToInt(Activ_Obj.PActv_ID), (int)Project_Log_DB.Action.edit, Project_Log_DB.operation.Project_Activities);


                    Project_Activities_DB.Increase_Recurcive_Activites(Activ_Obj.PActv_ID);

                    FillGrid();
                    Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم الحفظ بنجاح')</script>");
               }



          // }
        }

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
                int funding_id_row = CDataConverter.ConvertToInt(((TextBox)row.FindControl("txtfund_id")).Text);
                int funding_id_previousRow = CDataConverter.ConvertToInt(((TextBox)previousRow.FindControl("txtfund_id")).Text);
                int funding_source_row = CDataConverter.ConvertToInt(((TextBox)row.FindControl("txtfund_source")).Text);
                int funding_source_previousRow = CDataConverter.ConvertToInt(((TextBox)previousRow.FindControl("txtfund_source")).Text);
                string funding_id_source_row = funding_source_row.ToString() + funding_id_row.ToString();
                int fundingIdSourceRow = CDataConverter.ConvertToInt(funding_id_source_row);
                string funding_id_source_previousRow = funding_source_previousRow.ToString() + funding_id_previousRow.ToString();
                int fundingIdSourcePreviousRow = CDataConverter.ConvertToInt(funding_id_source_previousRow);

                if (lvl_previousRow < 5)
                    previousRow.Font.Size = 16 - lvl_previousRow * 2;
                else
                    previousRow.Font.Size = 8;

                if (rowIndex > -1)
                {
                    DropDownList funding_ddl = (DropDownList)previousRow.FindControl("ddlFundResource");

                    string sql = "select * from new_funding_veiw where proj_id=" + CDataConverter.ConvertToInt(Session_CS.Project_id);

                    DataTable DT = General_Helping.GetDataTable(sql);

                   // Obj_General_Helping.SmartBindDDL(funding_ddl, DT, "id", "name", ".... اختر مصدر التمويل ....");
                    funding_ddl.DataSource = DT;
                    funding_ddl.DataTextField = "name";
                    funding_ddl.DataValueField = "ID";
                    funding_ddl.DataBind();
                    funding_ddl.Items.Insert(0, new ListItem(" .... اختر مصدر التمويل ....", "0"));

                    if (DT.Rows.Count > 0 && funding_ddl.Items.Count > 0 && CDataConverter.ConvertToInt(fundingIdSourcePreviousRow) > 0)

                        funding_ddl.SelectedValue = fundingIdSourcePreviousRow.ToString();

                    if (rowIndex == 0)
                    {
                        DropDownList funding_ddl2 = (DropDownList)row.FindControl("ddlFundResource");
                        DataTable DT2 = General_Helping.GetDataTable(sql);

                      //  Obj_General_Helping.SmartBindDDL(funding_ddl2, DT2, "id", "name", ".... اختر مصدر التمويل ....");
                        funding_ddl.DataSource = DT2;
                        funding_ddl.DataTextField = "name";
                        funding_ddl.DataValueField = "ID";
                        funding_ddl.DataBind();
                        funding_ddl.Items.Insert(0, new ListItem(" .... اختر مصدر التمويل ....", "0"));

                        if (DT2.Rows.Count > 0 && funding_ddl.Items.Count > 0 && CDataConverter.ConvertToInt(fundingIdSourceRow) > 0)
                            funding_ddl2.SelectedValue = fundingIdSourceRow.ToString();
                    }
                }



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
            string sql = "select * from new_funding_veiw where proj_id=" + CDataConverter.ConvertToInt(Session_CS.Project_id);

            DropDownList funding_ddl = (DropDownList)GridView.Rows[0].FindControl("ddlFundResource");
            DataTable DT2 = General_Helping.GetDataTable(sql);
            //Obj_General_Helping.SmartBindDDL(funding_ddl, DT2, "id", "name", ".... اختر مصدر التمويل ....");
            funding_ddl.DataSource = DT2;
            funding_ddl.DataTextField = "name";
            funding_ddl.DataValueField = "ID";
            funding_ddl.DataBind();
            funding_ddl.Items.Insert(0, new ListItem(" .... اختر مصدر التمويل ....", "0"));

            int funding_id_row = CDataConverter.ConvertToInt(((TextBox)GridView.Rows[0].FindControl("txtfund_id")).Text);
            int funding_source_row = CDataConverter.ConvertToInt(((TextBox)GridView.Rows[0].FindControl("txtfund_source")).Text);
            string funding_id_source_row = funding_source_row.ToString() + funding_id_row.ToString();
            int fundingIdSourceRow = CDataConverter.ConvertToInt(funding_id_source_row);
            if (DT2.Rows.Count > 0)
                funding_ddl.SelectedValue = fundingIdSourceRow.ToString();
            GridView.Rows[0].Cells[1].Font.Bold = true;
            GridView.Rows[0].Cells[1].Font.Size = 14;
            GridView.Rows[0].Cells[1].BackColor = System.Drawing.Color.FromArgb(235, 236, 239);
        }
    }

    protected void gvSub_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onclick", "javascript:ChangeRowColor('" + e.Row.ClientID + "')");

         
            
 
        
        }
    }



    protected void gvSub_PreRender1(object sender, EventArgs e)
    {
        MergeRows(gvSub);


    }


    public void GrdView_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        //myActiv = CDataConverter.ConvertToInt(e.CommandArgument);
        //myRowIndex = CDataConverter.ConvertToInt(e.CommandName);
        //TextBox startDateTextBox = (TextBox)gvSub.Rows[myRowIndex].FindControl("txtStartDate");
        //TextBox endDateTextBox = (TextBox)gvSub.Rows[myRowIndex].FindControl("txtEndDate");
        //TextBox periodTextBox = (TextBox)gvSub.Rows[myRowIndex].FindControl("txtPeriod");
        //TextBox actualStartDateTextBox = (TextBox)gvSub.Rows[myRowIndex].FindControl("txtActualStartDate");
        //TextBox actualEndDateTextBox = (TextBox)gvSub.Rows[myRowIndex].FindControl("txtActualEndDate");
        //TextBox weightTextBox = (TextBox)gvSub.Rows[myRowIndex].FindControl("txtWeight");
        //TextBox progressTextBox = (TextBox)gvSub.Rows[myRowIndex].FindControl("txtPregress");
        //TextBox impPersonTextBox = (TextBox)gvSub.Rows[myRowIndex].FindControl("txtImplementingPerson");
        //DropDownList ddlfund = (DropDownList)gvSub.Rows[myRowIndex].FindControl("ddlFundResource");
        //TextBox fundingAmountBox = (TextBox)gvSub.Rows[myRowIndex].FindControl("txtfunds");
        //startDate = startDateTextBox.Text;
        //endDate = endDateTextBox.Text;
        //period = periodTextBox.Text;
        //actualStartDate = actualStartDateTextBox.Text;
        //actualEndDate = actualEndDateTextBox.Text;
        //weight = weightTextBox.Text;
        //progress = progressTextBox.Text;
        //impPerson = impPersonTextBox.Text;
        //if (ddlfund.SelectedValue != "0")
        //{
        //    string source_id = ddlfund.SelectedValue.ToString();
        //    string source = source_id.Substring(0, 1);
        //    string id = source_id.Substring(1);
        //    fundres_id = CDataConverter.ConvertToInt(id);
        //    fundres_source = CDataConverter.ConvertToInt(source);
        //}
        //else
        //{
        //    fundres_id = 0;
        //    fundres_source = 0;
        //}
        //fundAmount = CDataConverter.ConvertToInt(fundingAmountBox.Text);
        //if (Check_Valid())
        //{
        //    Project_Activities_DT Activ_Obj = Project_Activities_DB.SelectByID(myActiv);
        //    Activ_Obj.PActv_Start_Date = startDate;
        //    Activ_Obj.PActv_End_Date = endDate;
        //    Activ_Obj.PActv_Period = CDataConverter.ConvertToDecimal(period);
        //    Activ_Obj.PActv_Actual_Start_Date = actualStartDate;
        //    Activ_Obj.PActv_Actual_End_Date = actualEndDate;
        //    Activ_Obj.PActv_wieght = CDataConverter.ConvertToDecimal(weight);
        //    Activ_Obj.PActv_Progress = CDataConverter.ConvertToDecimal(progress);
        //    Activ_Obj.PActv_Implementing_person = impPerson;
        //    Activ_Obj.funding_res_id = fundres_id;
        //    Activ_Obj.funding_amount = fundAmount;
        //    Activ_Obj.funding_res_source = fundres_source;
        //    Project_Activities_DB.Save(Activ_Obj);

        //    Project_Activities_Versions_DB.Save(Activ_Obj, DateTime.Now.Month.ToString(), DateTime.Now.Year.ToString());
     
           


        //    Project_Log_DB.FillLog(CDataConverter.ConvertToInt(Activ_Obj.PActv_ID), (int)Project_Log_DB.Action.edit, Project_Log_DB.operation.Project_Activities);

       
        //    Project_Activities_DB.Increase_Recurcive_Activites(Activ_Obj.PActv_ID);
       
        //    FillGrid();
        //    Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم الحفظ بنجاح')</script>");
        //}
    }


    private bool Check_Valid( int pacv_id,int pact_parent)
    {


        bool Flag = true;
      

                decimal Parent_Weight = 0;
                decimal activ_progress = CDataConverter.ConvertToDecimal(progress);
                decimal Total_Weight = CDataConverter.ConvertToDecimal(weight);
                decimal total_childs_weight = 0;

                if (pact_parent  != 0)
                {
                    Project_Activities_DT main_Activ_Obj = Project_Activities_DB.SelectByID(pact_parent );
                    Parent_Weight = main_Activ_Obj.PActv_wieght;
                    string tempSql = " select sum(PActv_wieght) as PActv_wieght  from Project_Activities where proj_proj_id = " + CDataConverter.ConvertToInt(Session_CS.Project_id) + " and PActv_Parent =  " + pacv_id ;
                    DataTable Dt = General_Helping.GetDataTable(tempSql);
                    if (Dt.Rows.Count > 0)
                    {
                        //for (int i = 0; i < Dt.Rows.Count; i++)
                        total_childs_weight += CDataConverter.ConvertToDecimal(Dt.Rows[0]["PActv_wieght"].ToString());
                    }
                    if (total_childs_weight > Total_Weight)
                    {

                        Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('الوزن النسبى أقل من الأوزان النسبية للأنشطة الفرعية%')</script>");

                        Flag = false;
                        return Flag;

                    }
                    string tempSql1 = " select sum(PActv_wieght) as PActv_wieght  from Project_Activities where proj_proj_id = " + CDataConverter.ConvertToInt(Session_CS.Project_id) + " and PActv_Parent =  " + pact_parent + " and PActv_ID != " + pacv_id;
                    DataTable Dt1 = General_Helping.GetDataTable(tempSql1);
                    

                    if (Dt1.Rows.Count > 0)
                    {
                        Total_Weight += CDataConverter.ConvertToDecimal(Dt1.Rows[0]["PActv_wieght"].ToString());
                    }
                    if (Total_Weight > Parent_Weight)
                    {

                        Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('إجمالى الوزن النسبى يتعدى النشاط الرئيسى   %')</script>");

                        Flag = false;
                        return Flag;

                    }
                }
                else
                {

                    string tempSql = " select sum(PActv_wieght) as PActv_wieght  from Project_Activities where proj_proj_id = " + CDataConverter.ConvertToInt(Session_CS.Project_id) + " and PActv_Parent =  " + pacv_id;
                    DataTable Dt = General_Helping.GetDataTable(tempSql);
                    if (Dt.Rows.Count > 0)
                    {
                        total_childs_weight += CDataConverter.ConvertToDecimal(Dt.Rows[0]["PActv_wieght"].ToString());
                    }
                    if (total_childs_weight > Total_Weight)
                    {

                        Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('الوزن النسبى أقل من الأوزان النسبية للأنشطة الفرعية%')</script>");

                        Flag = false;
                        return Flag;

                    }
                    string tempSql1 = " select sum(PActv_wieght) as PActv_wieght  from Project_Activities where proj_proj_id = " + CDataConverter.ConvertToInt(Session_CS.Project_id) + " and PActv_Parent = 0 and PActv_ID != " + pacv_id;
                    DataTable Dt1 = General_Helping.GetDataTable(tempSql1);
                    if (Dt1.Rows.Count > 0)
                    {
                        Total_Weight += CDataConverter.ConvertToDecimal(Dt1.Rows[0]["PActv_wieght"].ToString());
                    }

                }

                if (Total_Weight > 100)
                {

                    Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('إجمالى الوزن النسبى يتعدى 100 ')</script>");

                    Flag = false;
                    return Flag;

                }


                if (activ_progress > 100)
                {
                    Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('نسبة الأنجاز تتعدى 100 %')</script>");

                    Flag = false;
                    return Flag;
                }


           //}
      //  }

        return Flag;
    }



    protected void txtWeight_TextChanged(object sender, EventArgs e)
    {
        GridViewRow currentRow = (GridViewRow)(sender as TextBox).Parent.Parent;
       
        ((CheckBox)currentRow.FindControl("chk_chnged")).Checked = true;

        Page.MaintainScrollPositionOnPostBack = true;
    }

 



}
