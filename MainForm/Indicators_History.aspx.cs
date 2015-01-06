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
using System.IO;
using DBL;
using System.Text;
using Dates;



public partial class WebForms_Indicators_History : System.Web.UI.Page
{
    //Session_CS Session_CS = new Session_CS();
    General_Helping Obj_General_Helping = new General_Helping();
    string sql_Connection = Universal.GetConnectionString();
    DataTable dt;
    SqlDataAdapter ad;
    int tn = 0;
    string sql = "";
    // int id= ["Project_id"]);





    protected void Page_Load(object sender, EventArgs e)
    {
        //Request.QueryString["Project_id"].ToString();

        if (!IsPostBack)
        {
            int proj_id = int.Parse(Session_CS.Project_id.ToString());
            LoadX(proj_id);
            DateTime str = CDataConverter.ConvertDateTimeNowRtnDt();
            TextBox5.Text = str.ToString("dd/MM/yyyy");
            fill_IndicatorPeiod();



        }

    }
    protected void fill_IndicatorPeiod()
    {
        DataTable dt_ind = General_Helping.GetDataTable("select * from Project_Activity_indicator_period ");
        IndicatorPeiod.DataSource = dt_ind;
        IndicatorPeiod.DataTextField = "period_desc";
        IndicatorPeiod.DataValueField = "ID";
        IndicatorPeiod.DataBind();
    }

    protected override void OnInit(EventArgs e)
    {
        Smart_Search_org.sql_Connection = sql_Connection;
       // Smart_Search_org.Query = "select ORG_id,Org_Desc from Organization where ( Org_Desc <> '' )";
        string Query = "select ORG_id,Org_Desc from Organization where ( Org_Desc <> '' )";
        Smart_Search_org.datatble = General_Helping.GetDataTable(Query);
        Smart_Search_org.Value_Field = "ORG_id";
        Smart_Search_org.Text_Field = "Org_Desc";
        Smart_Search_org.DataBind();

    }

    #region "clear"
    protected void clear()
    {
        Pai_ID.Value =
        TextBox2.Text = "";
        TextBox1.Text = "";
        TextBox4.Text = "";
        lblErrorMsg.Visible = false;
        TextBox6.Text = "";
        ddlInd.SelectedIndex = 0;
        IndicatorPeiod.SelectedIndex = 0;
        gvInd.Visible = false;
        


    }
    #endregion
    #region "dimm"
    protected void dimm()
    {
        TextBox2.Enabled = false;
        TextBox1.Enabled = false;
        ddlInd.Enabled = false;
        TextBox4.Enabled = false;
        IndicatorPeiod.Enabled = false;
        trsaveind.Visible = false;
    }
    #endregion
    #region "Fills"

    protected void fillgrid()
    {
        string fillsql = "select * ,Org_Desc from Project_Activities_Indicators_History ";
        fillsql += " join Organization on Organization.Org_ID = Project_Activities_Indicators_History.PAIH_org_id";
        fillsql += " where pai_pai_id = " + CDataConverter.ConvertToInt(Pai_ID.Value) + " order by PAIH_ID";
        DataTable dtx = General_Helping.GetDataTable(fillsql);
        if (dtx.Rows.Count > 0)
        {
            gvInd.DataSource = dtx;
            gvInd.DataBind();
            gvInd.Visible = true;
            lblErrorMsg.Visible = false;
        }
        else
        {
            gvInd.Visible = false;
        }
        TextBox6.Text =
            TextBox5.Text = "";
        //Smart_Search_org.Clear_Controls();
    }
    #endregion
    # region "tree action"

    private void LoadX(int proj_id)
    {

        TreeView1.Nodes.Clear();
        DataTable DT_Tree = new DataTable();
        DT_Tree = activityLeveling.ActivLevls.leveling(proj_id, 0, 0, 0, 0);
        TreeNode nodeX = new TreeNode("الأنشطة", "0");
        TreeView1.Nodes.Add(nodeX);
        LoadTree(DT_Tree);

    }
    private void LoadTree(DataTable TreeTable)
    {
        for (int i = 0; i <= TreeTable.Rows.Count - 1; i++)
        {
            TreeNode treeNode = new TreeNode(TreeTable.Rows[i]["parent"].ToString(), TreeTable.Rows[i]["PActv_ID"].ToString());
            if (CDataConverter.ConvertToInt(TreeTable.Rows[i]["PActv_Parent"].ToString()) == 0)
            {
                TreeView1.Nodes[0].ChildNodes.Add(treeNode);

            }
            LoadSubTree(TreeTable, treeNode);
        }
    }

    private void LoadSubTree(DataTable TreeTable, TreeNode treeNode)
    {
        DataTable DTTR = new DataTable();
        DTTR = General_Helping.GetDataTable("select * from Project_Activities where PActv_Parent =" + CDataConverter.ConvertToInt(treeNode.Value));

        if (DTTR.Rows.Count != 0)
        {
            foreach (DataRow row in DTTR.Rows)
            {
                TreeNode newNode = new TreeNode(row["PActv_Desc"].ToString(), row["PActv_ID"].ToString());
                treeNode.ChildNodes.Add(newNode);
                LoadSubTree(TreeTable, newNode);
            }
        }
    }

    void Fill_Grid_Indicator()
    {
        GridView_Indic.Visible = true;
        PActv_id.Value = TreeView1.SelectedValue.ToString();
        DataTable dt = new DataTable();
        string sql = "select * from Project_Activities_Indicators ";
        if (RblIndType.SelectedValue == "0")
        {

            
            sql += " where pactv_pactv_id = " + Convert.ToInt32(PActv_id.Value);
            dt = General_Helping.GetDataTable(sql);
            GridView_Indic.DataSource = dt;
            GridView_Indic.DataBind();

        }
        else if (RblIndType.SelectedValue == "1")
        {
            sql += " where pactv_pactv_id = 0 and proj_proj_id = " + Session_CS.Project_id.ToString();
            dt = General_Helping.GetDataTable(sql);
            GridView_Indic.DataSource = dt;
            GridView_Indic.DataBind();
 
        }
        

    }
    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    {
        if (TreeView1.SelectedNode.Selected == true)
        {
            clear();
            Pai_ID.Value =
            PAIH_ID.Value = "";
            Fill_Grid_Indicator();
            //if (dt.Rows.Count > 0)
            //{
            //    //dimm();
            //    //trsaveind.Visible = false;
            //    if (dt.Rows[0]["PAI_Desc"].ToString() != null && dt.Rows[0]["PAI_Desc"].ToString() != "")
            //        TextBox2.Text = dt.Rows[0]["PAI_Desc"].ToString();
            //    if (dt.Rows[0]["PAI_Unit"].ToString() != null && dt.Rows[0]["PAI_Unit"].ToString() != "")
            //        TextBox1.Text = dt.Rows[0]["PAI_Unit"].ToString();
            //    if (dt.Rows[0]["indt_indt_id"].ToString() != null && dt.Rows[0]["indt_indt_id"].ToString() != "")
            //        ddlInd.SelectedIndex = Convert.ToInt32(dt.Rows[0]["indt_indt_id"]);
            //    if (dt.Rows[0]["PAI_attainment_value"].ToString() != null && dt.Rows[0]["PAI_attainment_value"].ToString() != "")
            //        TextBox4.Text = dt.Rows[0]["PAI_attainment_value"].ToString();
            //    if (dt.Rows[0]["PAIP_period_id"].ToString() != null && dt.Rows[0]["PAIP_period_id"].ToString() != "")
            //        IndicatorPeiod.SelectedIndex = Convert.ToInt32(dt.Rows[0]["PAIP_period_id"]);
            //    //Mesuare.Visible = true;
            //    Pai_ID.Value = dt.Rows[0]["PAI_ID"].ToString();
            //    fillgrid();
            //}
            //else
            //{
            //    clear();
            //    //Mesuare.Visible = false;


            //}
            //parent_activ.Text = TreeView1.SelectedNode.Text;
        }


    }

    void Fil_Control_indicator(int PAI_ID)
    {
        string sql = "select * from Project_Activities_Indicators ";
        sql += " where PAI_ID = " + PAI_ID;
        DataTable dt = General_Helping.GetDataTable(sql);
        if (dt.Rows.Count > 0)
        {
            //dimm();
            //trsaveind.Visible = false;
            if (dt.Rows[0]["PAI_Desc"].ToString() != null && dt.Rows[0]["PAI_Desc"].ToString() != "")
                TextBox2.Text = dt.Rows[0]["PAI_Desc"].ToString();
            if (dt.Rows[0]["PAI_Unit"].ToString() != null && dt.Rows[0]["PAI_Unit"].ToString() != "")
                TextBox1.Text = dt.Rows[0]["PAI_Unit"].ToString();
            if (dt.Rows[0]["indt_indt_id"].ToString() != null && dt.Rows[0]["indt_indt_id"].ToString() != "")
                ddlInd.SelectedIndex = Convert.ToInt32(dt.Rows[0]["indt_indt_id"]);
            if (dt.Rows[0]["PAI_attainment_value"].ToString() != null && dt.Rows[0]["PAI_attainment_value"].ToString() != "")
                TextBox4.Text = dt.Rows[0]["PAI_attainment_value"].ToString();
            if (dt.Rows[0]["PAIP_period_id"].ToString() != null && dt.Rows[0]["PAIP_period_id"].ToString() != "")
                IndicatorPeiod.SelectedValue  = dt.Rows[0]["PAIP_period_id"].ToString();
            //Mesuare.Visible = true;
            Pai_ID.Value = dt.Rows[0]["PAI_ID"].ToString();
            fillgrid();
        }
        else
        {
            clear();
            //Mesuare.Visible = false;


        }

    }

    # endregion
    #region "save"
    protected void save_New_Click(object sender, EventArgs e)
    {
        clear();
        Pai_ID.Value =
        PAIH_ID.Value = "";
      

    }

    protected void saveInd_Click(object sender, EventArgs e)
    {



        if (RblIndType.SelectedValue == "0")
        {
            if (TreeView1.SelectedValue == null || TreeView1.SelectedValue == "")
            {
                lblErrorMsg.Visible = true;
                lblErrorMsg.Text = "يجب اختيار النشاط أولاً";
                return;

            }

            //sql = "select * from Project_Activities_Indicators ";
            //sql += " where pactv_pactv_id = " + Convert.ToInt32(TreeView1.SelectedValue);
            //ad = new SqlDataAdapter(sql, sql_Connection);
            //dt = new DataTable();
            //ad.Fill(dt);
            if (CDataConverter.ConvertToInt(Pai_ID.Value) > 0)
            {
                General_Helping.ExcuteQuery("update Project_Activities_Indicators set PAI_Desc='" + TextBox2.Text + "' where PAI_ID=" + Convert.ToInt32(Pai_ID.Value));

                General_Helping.ExcuteQuery("update Project_Activities_Indicators set PAI_Unit='" + TextBox1.Text + "' where PAI_ID=" + Convert.ToInt32(Pai_ID.Value));



                General_Helping.ExcuteQuery("update Project_Activities_Indicators set indt_indt_id='" + ddlInd.SelectedIndex + "' where PAI_ID=" + Convert.ToInt32(Pai_ID.Value));

                if (TextBox4.Text != "")
                    General_Helping.ExcuteQuery("update Project_Activities_Indicators set PAI_attainment_value='" + TextBox4.Text + "' where PAI_ID=" + Convert.ToInt32(Pai_ID.Value));
                else
                    General_Helping.ExcuteQuery("update Project_Activities_Indicators set PAI_attainment_value= null where PAI_ID=" + Convert.ToInt32(Pai_ID.Value));

                General_Helping.ExcuteQuery("update Project_Activities_Indicators set PAIP_period_id='" + IndicatorPeiod.SelectedValue  + "' where PAI_ID=" + Convert.ToInt32(Pai_ID.Value));
            }
            else
            {
                string Tempsql = "";
                Tempsql = "insert into Project_Activities_Indicators (PAI_Desc,PAI_Unit,indt_indt_id,PAI_attainment_value,PAIP_period_id,pactv_pactv_id) values('" + TextBox2.Text + "','" + TextBox1.Text + "'," + ddlInd.SelectedIndex + "," + CDataConverter.ConvertToInt(TextBox4.Text) + "," + IndicatorPeiod.SelectedValue  + "," + Convert.ToInt32(TreeView1.SelectedValue) + ") select @@identity";
                Pai_ID.Value = General_Helping.ExcuteQuery(Tempsql).ToString();
            }
            //lblErrorMsg.Visible = false;
            //Mesuare.Visible = true;
            //Fill_Grid_Indicator();

        }
        else if(RblIndType.SelectedValue == "1")
        {
            
            if (CDataConverter.ConvertToInt(Pai_ID.Value) > 0)
            {

                General_Helping.ExcuteQuery("update Project_Activities_Indicators set PAI_Desc='" + TextBox2.Text + "' where PAI_ID=" + Convert.ToInt32(Pai_ID.Value));


                General_Helping.ExcuteQuery("update Project_Activities_Indicators set PAI_Unit='" + TextBox1.Text + "' where PAI_ID=" + Convert.ToInt32(Pai_ID.Value));


                General_Helping.ExcuteQuery("update Project_Activities_Indicators set indt_indt_id='" + ddlInd.SelectedIndex + "' where PAI_ID=" + Convert.ToInt32(Pai_ID.Value));

                if (TextBox4.Text != "")
                    General_Helping.ExcuteQuery("update Project_Activities_Indicators set PAI_attainment_value='" + TextBox4.Text + "' where PAI_ID=" + Convert.ToInt32(Pai_ID.Value));
                else
                    General_Helping.ExcuteQuery("update Project_Activities_Indicators set PAI_attainment_value = null where where PAI_ID=" + Convert.ToInt32(Pai_ID.Value));

                General_Helping.ExcuteQuery("update Project_Activities_Indicators set PAIP_period_id='" + IndicatorPeiod.SelectedValue  + "' where PAI_ID=" + Convert.ToInt32(Pai_ID.Value));

            }
            else
            {
                string Tempsql = "";
                Tempsql = "insert into Project_Activities_Indicators (PAI_Desc,PAI_Unit,indt_indt_id,PAI_attainment_value,PAIP_period_id,pactv_pactv_id,proj_proj_id) values('" + TextBox2.Text + "','" + TextBox1.Text + "'," + ddlInd.SelectedIndex + "," + CDataConverter.ConvertToInt(TextBox4.Text) + "," + IndicatorPeiod.SelectedValue + ",0," + Session_CS.Project_id + ") select @@identity";
                Pai_ID.Value = General_Helping.ExcuteQuery(Tempsql).ToString();
            }
           

        }
       
        lblErrorMsg.Visible = false;
        Mesuare.Visible = true;
        Fill_Grid_Indicator();
        
    }
    protected void saveIndHist_Click(object sender, EventArgs e)
    {
        if (RblIndType.SelectedValue == "0")
        {
            if (TextBox6.Text == "" || TextBox5.Text == "" || Smart_Search_org.SelectedValue == "" || TreeView1.SelectedValue == null || TreeView1.SelectedValue == "")

              //  if (TextBox6.Text == "" || Dates_operations.date_validate(TextBox5.Text) == "" || Smart_Search_org.SelectedValue == "" || TreeView1.SelectedValue == null || TreeView1.SelectedValue == "")

            {
                lblErrorMsg.Visible = true;
                lblErrorMsg.Text = "يجب إدخال البيانات أولاً";
                return;

            }
            if (string.IsNullOrEmpty(PAIH_ID.Value) && Pai_ID.Value != "")
            {
                //sql = "select * from Project_Activities_Indicators ";
                //sql += " where pactv_pactv_id = " + Convert.ToInt32(TreeView1.SelectedValue);
                //ad = new SqlDataAdapter(sql, sql_Connection);
                //dt = new DataTable();
                //ad.Fill(dt);
                string Sql1 = "insert into Project_Activities_Indicators_History (PAIH_Value,PAIH_org_id,PAIH_Date,pai_pai_id) values (" + TextBox6.Text + "," + CDataConverter.ConvertToInt(Smart_Search_org.SelectedValue) + ",'" + TextBox5.Text + "'," + CDataConverter.ConvertToInt(Pai_ID.Value) + ")";
                General_Helping.ExcuteQuery(Sql1);

                fillgrid();
                PAIH_ID.Value = null;
            }
            else
            {
                string sql2 = "update Project_Activities_Indicators_History set PAIH_org_id=" + Convert.ToInt32(Smart_Search_org.SelectedValue) + ",PAIH_Value=" + TextBox6.Text + ",PAIH_Date='" + TextBox5.Text + "'  where PAIH_ID=" + CDataConverter.ConvertToInt(PAIH_ID.Value);

             //   string sql2 = "update Project_Activities_Indicators_History set PAIH_org_id=" + Convert.ToInt32(Smart_Search_org.SelectedValue) + ",PAIH_Value=" + TextBox6.Text + ",PAIH_Date='" + Dates_operations.date_validate(TextBox5.Text) + "'  where PAIH_ID=" + CDataConverter.ConvertToInt(PAIH_ID.Value);

                General_Helping.ExcuteQuery(sql2);
                lblErrorMsg.Visible = false;
                fillgrid();
                PAIH_ID.Value = null;
            }
        }
        else
        {
            if (TextBox6.Text == "" || TextBox5.Text == "" || Smart_Search_org.SelectedValue == "")
            //    if (TextBox6.Text == "" || Dates_operations.date_validate(TextBox5.Text) == "" || Smart_Search_org.SelectedValue == "")


            {
                lblErrorMsg.Visible = true;
                lblErrorMsg.Text = "يجب إدخال البيانات أولاً";
                return;

            }
            if (string.IsNullOrEmpty(PAIH_ID.Value) && Pai_ID.Value !="")
            {
                
                string Sql1 = "insert into Project_Activities_Indicators_History (PAIH_Value,PAIH_org_id,PAIH_Date,pai_pai_id) values (" + TextBox6.Text + "," + Convert.ToInt32(Smart_Search_org.SelectedValue) + ",'" + TextBox5.Text + "'," + Convert.ToInt32(Pai_ID.Value) + ")";
            //    string Sql1 = "insert into Project_Activities_Indicators_History (PAIH_Value,PAIH_org_id,PAIH_Date,pai_pai_id) values (" + TextBox6.Text + "," + Convert.ToInt32(Smart_Search_org.SelectedValue) + ",'" + Dates_operations.date_validate(TextBox5.Text) + "'," + Convert.ToInt32(Pai_ID.Value) + ")";


                General_Helping.ExcuteQuery(Sql1);
                
            }
            else
            {
               
           //    string sql2 = "update Project_Activities_Indicators_History set PAIH_org_id=" + Convert.ToInt32(Smart_Search_org.SelectedValue) + ",PAIH_Value=" + TextBox6.Text + ",PAIH_Date='" + Dates_operations.date_validate(TextBox5.Text) + "'  where PAIH_ID=" + CDataConverter.ConvertToInt(PAIH_ID.Value);

               string sql2 = "update Project_Activities_Indicators_History set PAIH_org_id=" + Convert.ToInt32(Smart_Search_org.SelectedValue) + ",PAIH_Value=" + TextBox6.Text + ",PAIH_Date='" + TextBox5.Text + "'  where PAIH_ID=" + CDataConverter.ConvertToInt(PAIH_ID.Value);

                General_Helping.ExcuteQuery(sql2);
                
            }



            
            lblErrorMsg.Visible = false;
            fillgrid();
            PAIH_ID.Value = null;

        }

    }
    #endregion



    protected void GridView_Indic_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditItem")
        {
           Fil_Control_indicator(CDataConverter.ConvertToInt(e.CommandArgument));

           
        }

        if (e.CommandName == "RemoveItem")
        {
            string Sql1 = " delete from Project_Activities_Indicators_History where pai_pai_id = " + CDataConverter.ConvertToInt(e.CommandArgument);
            Sql1 += "; delete from Project_Activities_Indicators where PAI_ID=" + CDataConverter.ConvertToInt(e.CommandArgument);

            General_Helping.ExcuteQuery(Sql1);
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم الحذف بنجاح')</script>");

            clear();
            Pai_ID.Value =
            PAIH_ID.Value = "";
            Fill_Grid_Indicator();


        }
    }
    protected void GrdView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditItem")
        {
            TextBox6.Text =
            TextBox5.Text = "";
            //Smart_Search_org.Clear_Controls();
            Fill_Controll(CDataConverter.ConvertToInt(e.CommandArgument));

            PAIH_ID.Value = e.CommandArgument.ToString();
            //Fil_Grd_Needs();
            //Fil_Grd_Letter();
        }

        if (e.CommandName == "RemoveItem")
        {
            TextBox6.Text =
            TextBox5.Text = "";
            //Smart_Search_org.Clear_Controls();
            string Sql1 = "delete from Project_Activities_Indicators_History where PAIH_ID=" + CDataConverter.ConvertToInt(e.CommandArgument);
            General_Helping.ExcuteQuery(Sql1);
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم الحذف بنجاح')</script>");
            sql = "select * from Project_Activities_Indicators ";
            sql += " where proj_proj_id = " + Session_CS.Project_id;
            ad = new SqlDataAdapter(sql, sql_Connection);
            dt = new DataTable();
            ad.Fill(dt);
            fillgrid();
        }
    }
    protected void Fill_Controll(int ID)
    {
        sql = "select * ,Org_Desc from Project_Activities_Indicators_History ";
        sql += " join Organization on Organization.Org_ID = Project_Activities_Indicators_History.PAIH_org_id";
        sql += " where PAIH_ID = " + ID;
        ad = new SqlDataAdapter(sql, sql_Connection);
        dt = new DataTable();
        ad.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            TextBox6.Text = (CDataConverter.ConvertToInt(dt.Rows[0]["PAIH_Value"])).ToString();
            Smart_Search_org.SelectedValue = dt.Rows[0]["PAIH_org_id"].ToString();
            TextBox5.Text = dt.Rows[0]["PAIH_Date"].ToString();
        }
    }
    protected void RblIndType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RblIndType.SelectedValue == "0")
        {
            GridView_Indic.Visible = false;
            clear();
            treeActv.Visible = true;
            int proj_id = int.Parse(Session_CS.Project_id.ToString());
            LoadX(proj_id);
        }
        else
        {
            clear();
            treeActv.Visible = false;
            GridView_Indic.Visible = true;
            Fill_Grid_Indicator();

            //string sql = "select * from Project_Activities_Indicators ";
            //sql += " where proj_proj_id = " + Session_CS.Project_id;
            //DataTable dt = General_Helping.GetDataTable(sql);
            //if (dt.Rows.Count > 0)
            //{
            //    //dimm();
            //    //trsaveind.Visible = false;
            //    if (dt.Rows[0]["PAI_Desc"].ToString() != null && dt.Rows[0]["PAI_Desc"].ToString() != "")
            //        TextBox2.Text = dt.Rows[0]["PAI_Desc"].ToString();
            //    if (dt.Rows[0]["PAI_Unit"].ToString() != null && dt.Rows[0]["PAI_Unit"].ToString() != "")
            //        TextBox1.Text = dt.Rows[0]["PAI_Unit"].ToString();
            //    if (dt.Rows[0]["indt_indt_id"].ToString() != null && dt.Rows[0]["indt_indt_id"].ToString() != "")
            //        ddlInd.SelectedIndex = Convert.ToInt32(dt.Rows[0]["indt_indt_id"]);
            //    if (dt.Rows[0]["PAI_attainment_value"].ToString() != null && dt.Rows[0]["PAI_attainment_value"].ToString() != "")
            //        TextBox4.Text = dt.Rows[0]["PAI_attainment_value"].ToString();
            //    if (dt.Rows[0]["PAIP_period_id"].ToString() != null && dt.Rows[0]["PAIP_period_id"].ToString() != "")
            //        IndicatorPeiod.SelectedIndex = Convert.ToInt32(dt.Rows[0]["PAIP_period_id"]);
            //    //Mesuare.Visible = true;
            //    fillgrid();
            //}
            //else
            //{
            //    General_Helping.ExcuteQuery("insert into Project_Activities_Indicators (proj_proj_id) values (" + Session_CS.Project_id + ")");
            //    clear();
            //    //Mesuare.Visible = false;


            //}
        }

    }
}
