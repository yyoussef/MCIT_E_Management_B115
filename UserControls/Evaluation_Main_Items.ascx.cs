using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class UserControls_Evaluation_Main_Items : System.Web.UI.UserControl
{
    //Session_CS Session_CS = new Session_CS();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillGrid();

        }
    }
    protected void FillGrid()
    {

        DataTable dat = new DataTable();
        dat = Evaluation_Main_Items_DB.SelectAll();
        GridView1.DataSource = dat;
        GridView1.DataBind();


    }
    protected void save_Click(object sender, EventArgs e)
    {
        Evaluation_Main_Items_DT admino = new Evaluation_Main_Items_DT();
        admino.Name = txt1.Text;
        admino.Main_Item_Id = CDataConverter.ConvertToInt(HiddenField1.Value);
        int id = Evaluation_Main_Items_DB.Save(admino);
        HiddenField1.Value = "0";
        txt1.Text = "";

        FillGrid();
        HiddenField1.Value = "";
        Page.RegisterStartupScript("success","<script language=javascript>alert('تم الحفظ بنجاح')</script");
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        FillGrid();
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delette")
        {

            Evaluation_Main_Items_DB.Delete(Int32.Parse(e.CommandArgument.ToString()));

            FillGrid();
            clear();
            Page.RegisterStartupScript("success", "<script language=javascript>alert('تم الحذف بنجاح')</script");



        }
        if (e.CommandName == "Updates")
        {

            Evaluation_Main_Items_DT adminob = new Evaluation_Main_Items_DT();


            adminob = Evaluation_Main_Items_DB.SelectByID(Int32.Parse(e.CommandArgument.ToString()));
            txt1.Text = adminob.Name;

            HiddenField1.Value = adminob.Main_Item_Id.ToString();





        }
    }
    protected void ddl_Groups_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void clear()
    {
        HiddenField1.Value=
        txt1.Text = "";
    }
}