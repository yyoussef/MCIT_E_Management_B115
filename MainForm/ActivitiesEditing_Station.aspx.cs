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
using Dates;

public partial class MainForm_ActivitiesEditing_Station : System.Web.UI.Page
{
    //Session_CS Session_CS = new Session_CS();
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
    General_Helping Obj_General_Helping = new General_Helping();
    //public DataTable dt_Level;
    public void Page_Load(object sender, EventArgs e)
    {
        // dt_Level = activityLeveling.ActivLevls.leveling(CDataConverter.ConvertToInt(Session_CS.Project_id), 0, 0);
        if (!IsPostBack)
        {
            Fil_active_Month();

            //Filldll();

        }
    }

    void Fil_active_Month()
    {
        Project_Activities_Months_DT obj = Project_Activities_Months_DB.Select_Active();
        if (obj.ID > 0)
        {
            hidden_month_id.Value = obj.ID.ToString();
            lbl_Notes.Text = obj.Notes;
            FillGrid();
        }
    }
    private void FillGrid()
    {
        DataTable dt_Level = activityLeveling.ActivLevls.leveling_For_Activities_Station_For_Grid(CDataConverter.ConvertToInt(Session_CS.Project_id), CDataConverter.ConvertToInt(hidden_month_id.Value));
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
    private void Filldll()
    {
        //DropDownList funding_ddl = (DropDownList)gvSub.Rows[i].FindControl("ddlFundResource");
        //string sql="select proj_id,Project_Period_Sources.sources_id,";
        //        sql+=" Project_Period_Sources.provider_id,funding_veiw.provider_name";
        //        sql+=" from Project_Period_Balance";
        //        sql+=" join Project_Period_Sources on Project_Period_Balance.period_id=Project_Period_Sources.period_id";
        //        sql+=" join funding_veiw on Project_Period_Sources.sources_id=funding_veiw.[value] and Project_Period_Sources.provider_id=funding_veiw.Provider_ID";
        //        sql+=" where proj_id="+CDataConverter.ConvertToInt(Session_CS.Project_id);
        //        sql += " group by Project_Period_Sources.sources_id,Project_Period_Sources.provider_id,Project_Period_Balance.Proj_id,funding_veiw.provider_name";
        //        DataTable DT = General_Helping.GetDataTable(sql);
        //        Obj_General_Helping.SmartBindDDL(funding_ddl, DT, "provider_id", "provider_name", ".... اختر مصدر التمويل ....");


    }
    public void GrdView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        myRowIndex = CDataConverter.ConvertToInt(e.CommandName);
        myActiv = CDataConverter.ConvertToInt(e.CommandArgument);
        TextBox weightTextBox = (TextBox)gvSub.Rows[myRowIndex].FindControl("txtWeight");
        TextBox progressTextBox = (TextBox)gvSub.Rows[myRowIndex].FindControl("txtPregress");
        TextBox impPersonTextBox = (TextBox)gvSub.Rows[myRowIndex].FindControl("txtImplementingPerson");

        weight = weightTextBox.Text;
        progress = progressTextBox.Text;


        Project_Activities_DT Activ_Obj = Project_Activities_DB.SelectByID(myActiv);

        Activ_Obj.PActv_Progress = CDataConverter.ConvertToDecimal(progress);
        Project_Activities_DB.Save(Activ_Obj);

        Project_Activities_Station_DT obj_Station = new Project_Activities_Station_DT();
        obj_Station.Month_id = CDataConverter.ConvertToInt(hidden_month_id.Value);
        obj_Station.Notes = impPersonTextBox.Text;
        obj_Station.PActv_ID = myActiv;
        obj_Station.PActv_Progress = CDataConverter.ConvertToDecimal(progress);
        Project_Activities_Station_DB.Save(obj_Station);
        //if (CDataConverter.ConvertToInt(hidden_month_id.Value) > 0)
        //Project_Activities_Versions_DB.Save(Activ_Obj, lbl_Month.Text, lbl_Year.Text);
        //else
        //  Project_Activities_Versions_DB.Save(Activ_Obj, "00", "0000");


        Project_Log_DB.FillLog(CDataConverter.ConvertToInt(Activ_Obj.PActv_ID), (int)Project_Log_DB.Action.edit, Project_Log_DB.operation.Project_Activities);


        Project_Activities_DB.Increase_Recurcive_Activites(Activ_Obj.PActv_ID);
        FillGrid();
        Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم الحفظ بنجاح')</script>");
    }

    protected void gvSub_PreRender1(object sender, EventArgs e)
    {
        MergeRows(gvSub);


    }

    protected void txtPregress_TextChanged(object sender, EventArgs e)
    {
        GridViewRow currentRow = (GridViewRow)(sender as TextBox).Parent.Parent;
        TextBox txtPActv_Parent = (TextBox)currentRow.FindControl("txtPActv_Parent");
        ((CheckBox)currentRow.FindControl("chk_chnged")).Checked=true;
        TextBox txtPregress = (TextBox)sender;
        if (!chek_Weight(txtPActv_Parent.Text, txtPregress.Text))
        {
            lbl_error.Visible = true;
            btnSave.Enabled = false;
        }
        else
        {
            lbl_error.Visible = false;
            btnSave.Enabled = true;
        }

        

    }

    private bool chek_Weight(string PActv_Parent, string Item_Pregress)
    {
        bool flag = true;
        //int Pregress = 0;
        //foreach (GridViewRow currentRow in gvSub.Rows)
        //{
        //    TextBox txtPActv_Parent = (TextBox)currentRow.FindControl("txtPActv_Parent");
        //    if (txtPActv_Parent.Text == PActv_Parent)
        //    {
        //        TextBox txtPregress = (TextBox)currentRow.FindControl("txtPregress");
        //        Pregress += CDataConverter.ConvertToInt(txtPregress.Text);

        //    }
            
        //}
        if (CDataConverter.ConvertToInt( Item_Pregress) > 100)
        {
            flag = false;
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('نسبة الانجاز تتعدى 100 %')</script>");
        }
        return flag;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow currentRow in gvSub.Rows)
        {
            CheckBox chk_chnged= (CheckBox)currentRow.FindControl("chk_chnged");
            if (chk_chnged.Checked)
            {

                TextBox txtPActv_ID = (TextBox)currentRow.FindControl("txtPActv_ID");
                TextBox weightTextBox =(TextBox) currentRow.FindControl("txtWeight");
                TextBox txtPregress = (TextBox)currentRow.FindControl("txtPregress");
                TextBox txtImplementingPerson = (TextBox)currentRow.FindControl("txtImplementingPerson");

                


                Project_Activities_DT Activ_Obj = Project_Activities_DB.SelectByID(CDataConverter.ConvertToInt( txtPActv_ID.Text));
                Activ_Obj.PActv_Progress = CDataConverter.ConvertToDecimal(txtPregress.Text);
                Project_Activities_DB.Save(Activ_Obj);

                Project_Activities_Station_DT obj_Station = new Project_Activities_Station_DT();
                obj_Station.Month_id = CDataConverter.ConvertToInt(hidden_month_id.Value);
                obj_Station.Notes = txtImplementingPerson.Text;
                obj_Station.PActv_ID = CDataConverter.ConvertToInt(txtPActv_ID.Text);
                obj_Station.PActv_Progress = CDataConverter.ConvertToDecimal(txtPregress.Text);
                Project_Activities_Station_DB.Save(obj_Station);
               


                Project_Log_DB.FillLog(CDataConverter.ConvertToInt(Activ_Obj.PActv_ID), (int)Project_Log_DB.Action.edit, Project_Log_DB.operation.Project_Activities);


                Project_Activities_DB.Increase_Recurcive_Activites(Activ_Obj.PActv_ID);
                FillGrid();
                Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم الحفظ بنجاح')</script>");

            }

        }
    }
    protected void txtImplementingPerson_TextChanged(object sender, EventArgs e)
    {
        GridViewRow currentRow = (GridViewRow)(sender as TextBox).Parent.Parent;
        //TextBox txtPActv_Parent = (TextBox)currentRow.FindControl("txtPActv_Parent");
        ((CheckBox)currentRow.FindControl("chk_chnged")).Checked=true;
        
        //TextBox txtPregress = (TextBox)sender;


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
}
