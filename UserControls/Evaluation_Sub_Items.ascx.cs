using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class UserControls_Evaluation_Sub_Items : System.Web.UI.UserControl
{
    Session_CS Session_CS = new Session_CS();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Fill_Module();

            FillGrid();
        }

    }
    private void Fill_Module()
    {

        string sql = "select * From Evaluation_Main_Items ";
        DataTable dt = General_Helping.GetDataTable(sql);
        ddl_Groups.DataSource = dt;
        ddl_Groups.DataValueField = "Main_Item_Id";
        ddl_Groups.DataTextField = "Name";
        ddl_Groups.DataBind();
        //ddl_Groups.Items.Insert(0, new ListItem("اختر المجموعة......", "0"));
    }
    //protected void ddl_Groups_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    Fill_Module();
    //}
    protected void save_Click(object sender, EventArgs e)
    {

        Evaluation_Sub_Items_DT admino = new Evaluation_Sub_Items_DT();
        admino.Name = txt1.Text;
        admino.ToolTip = TextBox1.Text;
        admino.Main_Item_Id = Convert.ToInt32(ddl_Groups.SelectedValue);
        admino.Sub_Item_Id = Convert.ToInt32(HiddenField1.Value);
        int id = Evaluation_Sub_Items_DB.Save(admino);

        if (id > 0)
        {
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('تم الحفظ بنجاح')</script>");
        }
        txt1.Text = "";
        TextBox1.Text = "";

        FillGrid();
        HiddenField1.Value = "0";
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delette")
        {

            Evaluation_Sub_Items_DB.Delete(Int32.Parse(e.CommandArgument.ToString()));

            FillGrid();


        }

        if (e.CommandName == "Delette")
        {

            Evaluation_Sub_Items_DB.Delete(Int32.Parse(e.CommandArgument.ToString()));

            FillGrid();


        }
        if (e.CommandName == "Updates")
        {

            Evaluation_Sub_Items_DT adminob = new Evaluation_Sub_Items_DT();


            adminob = Evaluation_Sub_Items_DB.SelectByID(Int32.Parse(e.CommandArgument.ToString()));
            ddl_Groups.SelectedValue = adminob.Main_Item_Id.ToString();
            txt1.Text = adminob.Name;
            TextBox1.Text = adminob.ToolTip;
            HiddenField1.Value = adminob.Sub_Item_Id.ToString();





        }

    }
    protected void FillGrid()
    {

        DataTable dat = new DataTable();
        dat = Evaluation_Sub_Items_DB.SelectAll();
        GridView1.DataSource = dat;
        GridView1.DataBind();


    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        FillGrid();

    }
}
