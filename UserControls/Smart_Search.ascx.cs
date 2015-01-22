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
using System.Text;
using Geekees.Common.Utilities.Xml;
using Geekees.Common.Controls;
using System.Xml;
using Dates;
using System.Reflection;
using System.Data.Sql;






public partial class Smart_Search : System.Web.UI.UserControl
{

    public delegate void Delegate_Selected_Value(string strValue);

    public event Delegate_Selected_Value Value_Handler;


    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {

        if (CDataConverter.ConvertToInt(SelectedValue) > 0)
            Set_Color_Selected_Value();
        else
            Set_Color_Not_Selected_Value();


        // }

    }


    public int Items_Count
    {

        get
        {
            return ((DataTable)(Grdvew_Search.DataSource)).Rows.Count;
        }
    }

    public string Value_Field
    {

        get
        {
            //if (Query_Value_Field == "")
            return this.hidden_Value_Field.Text;
            //return Query_Value_Field;
        }
        set
        {
            // Query_Value_Field = value;
            this.hidden_Value_Field.Text = value;

        }

    }

    public bool Enabled
    {
        set
        {
            //if (!value)
            //{
            set_control_enabled(value);
            //}
            //else
            //{
            //  set_control_enabled(true);
            // }

        }
    }

    public bool Show_OrgTree
    {
        set
        {

            // btn_show_tree.Visible = true;
            ImageButton2.Visible = true;
            GenerateTree();

        }
    }

    void set_control_enabled(bool flag)
    {
        txt_Id.Enabled =
        btn_Search.Enabled =
        ImageButton1.Enabled =
        rdl_Search.Enabled =
        txt_Name.Enabled = flag;

        Grdvew_Search.DataSource = null;
        Grdvew_Search.DataBind();

    }



    public string Text_Field
    {

        get
        {
            return this.hidden_Text_Field.Text;
        }
        set
        {
            this.hidden_Text_Field.Text = value;

        }

    }

    public string SelectedValue
    {

        get
        {
            return hidden_Value.Value;
        }
        set
        {
            hidden_Value.Value = value;
            txt_Id.Text = value;
            this.lbl_Value.Text = value;
            Fil_Cntrl_by_txt_ID();
            Set_Color_Selected_Value();
            Div_Grid.Style.Add("display", "none");
            divtree.Style.Add("display", "none");

        }

    }

    public string SelectedText
    {

        get
        {
            return txt_Name.Text;
        }
    }

    public bool Show_Code
    {

        set
        {
            if (value == true)
            {
                this.Div_Code.Visible =
                this.Grdvew_Search.Columns[0].Visible = true;
                Div_Grid.Style.Add("width", "350px");
            }
            else
            {
                this.Div_Code.Visible =
                this.Grdvew_Search.Columns[0].Visible = false;
                Div_Grid.Style.Add("width", "250px");
            }


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
        ASTreeViewDataTableColumnDescriptor descripter = new ASTreeViewDataTableColumnDescriptor("dept_name"
            , "Dept_id"
            , "Dept_parent_id");
        this.astvMyTree.DataSourceDescriptor = descripter;
        this.astvMyTree.DataSource = datatble;
        this.astvMyTree.DataBind();
    }

    protected void btn_show_Click(object sender, EventArgs e)
    {
        divtree.Style.Add("display", "block");
        astvMyTree.Visible = true;



    }

    private void Set_Color_Selected_Value()
    {
        this.txt_Id.BackColor = System.Drawing.Color.FromName("#C2DDF0");
        this.txt_Name.BackColor = System.Drawing.Color.FromName("#C2DDF0");
    }

    private void Set_Color_Not_Selected_Value()
    {
        txt_Id.BackColor = System.Drawing.Color.FromName("#C8C8C8");
        txt_Name.BackColor = System.Drawing.Color.FromName("#C8C8C8");
    }

    public override void DataBind()
    {
        //Clear_Controls();
        //Fil_Grid(Query);


        // DataTable dt;
        if (hidden_Searched.Value == "2")
        {
            Clear_Controls();
           
                Grdvew_Search.DataSource = datatble;
          
        }
        else
        {
           
                Grdvew_Search.DataSource = datatble_Searched;
           
        }



        Grdvew_Search.DataBind();

    }

    public void Clear_Controls()
    {
        hidden_Searched.Value = "2";
        //this.Clear_Selected();
        this.hidden_Value.Value =
             this.lbl_Value.Text =
        this.txt_Id.Text =
        this.SelectedValue =
        this.txt_Name.Text = "";
        if (Value_Handler != null)
            Value_Handler("");
        Set_Color_Not_Selected_Value();
        // this.Grdvew_Search.DataSource = new DataTable();
        // this.Grdvew_Search.DataBind();

    }

    public void Clear_Selected()
    {
        Clear_Controls();


    }
    protected void btn_Clear_Click(object sender, EventArgs e)
    {
        this.Clear_Selected();
        DataBind();
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


    }

    protected void btnPostBackTrigger3_Click(object sender, EventArgs e)
    {

    }




    public string Validation_Group
    {

        set
        {
            if (!string.IsNullOrEmpty(value))
            {
                this.RequiredFieldValidator3.Visible = true;
                this.RequiredFieldValidator3.ValidationGroup = value;
            }
            else
                this.RequiredFieldValidator3.Visible = false;


        }
    }

    //public string Query
    //{
    //    get
    //    {
    //        return this.hiden_Query.Text;
    //    }
    //    set
    //    {
    //        //Select_Query = value;
    //        this.hiden_Query.Text = value;
    //        //if (string.IsNullOrEmpty(Txt_Original_Query.Text))
    //        //    Txt_Original_Query.Text = value;
    //    }
    //}




    //public DataTable datasource(string SQL)
    //{

    //    return SqlHelper.ExecuteDataset(Database.ConnectionString, CommandType.Text, SQL).Tables[0];


    //}



    public string Orderby
    {
        get
        {
            //return this.hiden_Orderby.Text;
            return "";
        }
        set
        {
            this.hiden_Orderby.Text = value;
        }
    }

    public DataTable datatble
    {
        get
        {
            return (DataTable)ViewState["dt"];
        }
        set
        {
            ViewState["dt"] = value;
        }


    }
    public DataTable datatble_Searched
    {
        get
        {
            return (DataTable)ViewState["dt_Searched"];
        }
        set
        {
            ViewState["dt_Searched"] = value;
        }


    }

  



    public string sql_Connection
    {
        get
        {
            return this.hiden_Con_Query.Text;
        }
        set
        {
            //sql_Connection = value;
            this.hiden_Con_Query.Text = value;
        }
    }

    protected void btn_Search_Click(object sender, EventArgs e)
    {
        hidden_Searched.Value = "1";
      
            Search_Grid();
     
       

    }

    protected void txt_Id_TextChanged(object sender, EventArgs e)
    {

        if (!string.IsNullOrEmpty(txt_Id.Text))
        {
            hidden_Searched.Value = "1";
            Fil_Cntrl_by_txt_ID();
        }
        else
        {
            hidden_Searched.Value = "2";
            Clear_Controls();
            DataBind();
        }
    }

    protected void txt_Name_TextChanged(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txt_Name.Text))
        {
            hidden_Searched.Value = "2";
            Clear_Controls();
            DataBind();
        }
        else
        {
            hidden_Searched.Value = "1";
            Search_Grid();

        }
    }



    private void Fil_Cntrl_by_txt_ID()
    {
        try
        {

            if (!string.IsNullOrEmpty(txt_Id.Text))
            {
                if (txt_Id.Text != "--- البحث بالكود ----" && txt_Id.Text != "")
                {
                    DataTable searchDt = datatble;

                    DataTable resultDT = searchDt.Clone();

                    DataRow[] foundRows;
                    foundRows = searchDt.Select("" + Value_Field + " =" + txt_Id.Text + "");
                    for (int i = 0; i < foundRows.Length; i++)
                    {

                        resultDT.ImportRow(foundRows[i]);
                        resultDT.AcceptChanges();
                    }
                    if (resultDT.Rows.Count > 0)
                    {
                        this.lbl_Value.Text = hidden_Value.Value = txt_Id.Text;
                        txt_Id.Text = txt_Id.Text;

                        txt_Name.Text = resultDT.Rows[0][Text_Field.Trim().ToLower().ToString()].ToString();
                        if (Value_Handler != null)
                            Value_Handler(txt_Id.Text);


                    }
                    else
                    {

                        txt_Id.Text =
                            txt_Name.Text = "";
                    }



                }


            }

        }
        catch
        {
        }
    }
  
    private void Search_Grid()
    {
        string value = rdl_Search.SelectedValue;
        if (hidden_Searched.Value == "1")
        {
            DataTable searchDt = datatble;

            DataTable resultDT = searchDt.Clone();
            DataRow[] foundRows;

            if (searchDt.Rows.Count > 0)
            {
                if (txt_Id.Text != "--- البحث بالكود ----" && txt_Id.Text != "")
                {
                    var records = (from record in searchDt.AsEnumerable()
                                   where (record.Field<Int64>(Value_Field) == CDataConverter.ConvertToInt(txt_Id.Text))

                                   select record).First();

                    resultDT.ImportRow(records);
                    resultDT.AcceptChanges();

                    //foundRows = searchDt.Select(Value_Field + " = " + txt_Id.Text + "");
                    //for (int i = 0; i < foundRows.Length; i++ )
                    //{

                    //    resultDT.ImportRow(foundRows[i]);

                    //    resultDT.AcceptChanges();
                    //}


                }
                else if (txt_Name.Text != "--- البحث بالإسم ----" && txt_Name.Text != "")
                {
                    if (value == "1")
                    {
                        // foundRows = searchDt.Select(Text_Field + " like '%" + txt_Name.Text + "%'");


                        var records = from record in searchDt.AsEnumerable()
                                      where (record.Field<String>(Text_Field).Contains(txt_Name.Text))

                                      select record;

                        foreach (DataRow dr in records)
                        {
                            resultDT.ImportRow(dr);
                            resultDT.AcceptChanges();
                            resultDT.DefaultView.Sort = Orderby;
                        }

                        //for (int i = 0; i < foundRows.Length; i++)
                        //{


                        //    resultDT.ImportRow(foundRows[i]);
                        //    resultDT.AcceptChanges();
                        //    resultDT.DefaultView.Sort = Orderby; 

                        //}


                    }
                    else if (value == "2")
                    {

                        var records2 = from record in searchDt.AsEnumerable()
                                       where (record.Field<String>(Text_Field).Contains(txt_Name.Text))

                                       select record;

                        foreach (DataRow dr in records2)
                        {
                            resultDT.ImportRow(dr);
                            resultDT.AcceptChanges();
                            resultDT.DefaultView.Sort = Orderby;
                        }


                        //foundRows = searchDt.Select(Text_Field + " like '%" + txt_Name.Text + "'" );
                        //for (int i = 0; i < foundRows.Length; i++)
                        //{

                        //    resultDT.ImportRow(foundRows[i]);
                        //    resultDT.AcceptChanges();
                        //    resultDT.DefaultView.Sort = Orderby;

                        //}
                    }


                }
                else if (txt_Name.Text == "--- البحث بالإسم ----" || txt_Name.Text != "")
                {


                }
                else
                {
                    resultDT = searchDt;
                    resultDT.DefaultView.Sort = Orderby;
                }




            }

            datatble_Searched = resultDT;
            DataBind();
            Div_Grid.Style.Add("display", "block");
        }

    }


    private void Fil_Grid(string Sql_Query)
    {

        if (!string.IsNullOrEmpty(Sql_Query))
        {
            try
            {
                Sql_Query += Orderby;

                SqlConnection con = new SqlConnection(sql_Connection);
                SqlCommand comnd = new SqlCommand(Sql_Query, con);
                SqlDataAdapter obj = new SqlDataAdapter(comnd);
                DataTable Dt = new DataTable();
                obj.Fill(Dt);
                Grdvew_Search.DataSource = Dt;
                Grdvew_Search.DataBind();

            }
            catch
            { }


        }
    }


    //public void smartbind(DataTable dt)
    //{
    //    Clear_Controls();
    //    Grdvew_Search.DataSource = datatble;
    //    Grdvew_Search.DataBind();
    //}







    protected void Grdvew_Search_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int Current_PageIndex = Grdvew_Search.PageIndex;
        int New_PageIndex = 0;
        if (e.CommandName == "Select")
        {
            string str = e.CommandArgument.ToString();
            string[] arrstr = str.Split(',');
            this.lbl_Value.Text = hidden_Value.Value = txt_Id.Text = arrstr[0].ToString();
            txt_Name.Text = arrstr[1].ToString();
            if (Value_Handler != null)
                Value_Handler(txt_Id.Text);
            //Div_Grid.Visible = false;
            hidden_Searched.Value = "2";
            // Search_Grid();
            Div_Grid.Style.Add("display", "none");
            Set_Color_Selected_Value();

        }
        else if (e.CommandName == "nextPage")
        {
            if (Current_PageIndex != Grdvew_Search.PageCount)
                New_PageIndex = Current_PageIndex + 1;

        }
        else if (e.CommandName == "first")
        {
            New_PageIndex = 0;

        }
        else if (e.CommandName == "lastPage")
        {
            New_PageIndex = Grdvew_Search.PageCount;

        }
        else if (e.CommandName == "prev")
        {
            if (Current_PageIndex > 0)
                New_PageIndex = Current_PageIndex - 1;

        }

        if (e.CommandName != "Select")
        {

            Grdvew_Search.PageIndex = New_PageIndex;
            //Grdvew_Search.DataSource = datatble;
            //Grdvew_Search.DataBind();
            DataBind();
            Div_Grid.Style.Add("display", "block");
            // Fil_Grid(Query);
        }
    }

    protected void Grdvew_Search_DataBound(object sender, EventArgs e)
    {
        try
        {
            GridViewRow pagerRow = Grdvew_Search.BottomPagerRow;

            Label lbl_Page_Info = (Label)pagerRow.Cells[0].FindControl("lbl_Page_Info");



            if (lbl_Page_Info != null)
            {
                int currentPage = Grdvew_Search.PageIndex + 1;

                lbl_Page_Info.Text = "صفحة " + currentPage.ToString() +
                " من " + Grdvew_Search.PageCount.ToString();
            }

        }
        catch (Exception ex)
        {

        }
    }

    public string Get_Valid_Group()
    {
        return "A";
    }

    protected void astvMyTree_OnSelectedNodeChanged(object src, ASTreeViewNodeSelectedEventArgs e)
    {

        // txt_Id.Text =  e.NodeValue.ToString();
        //Fil_Cntrl_by_txt_ID();
        this.lbl_Value.Text = hidden_Value.Value = txt_Id.Text = e.NodeValue.ToString();
        txt_Name.Text = e.NodeText.ToString();
        if (Value_Handler != null)
        {
            Value_Handler(txt_Name.Text);
        }
        divtree.Style.Add("display", "none");

        // astvMyTree.Visible = false;


    }


}