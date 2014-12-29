using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class UserControls_Evaluation_Main_Items : System.Web.UI.UserControl
{
    Session_CS Session_CS = new Session_CS();
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
        dat = Evaluation_Main_Items_Manager_DB.SelectAll();
        GridView1.DataSource = dat;
        GridView1.DataBind();


    }
    protected void save_Click(object sender, EventArgs e)
    {
        Evaluation_Main_Items_Manager_DT admino = new Evaluation_Main_Items_Manager_DT();
        admino.Name = txt_mainitem.Text;
        admino.Main_Item_Id = CDataConverter.ConvertToInt(hidd_main_id.Value);
        int id = Evaluation_Main_Items_Manager_DB.Save(admino);
        hidd_main_id.Value = 
        txt_mainitem.Text = "";

        FillGrid();
        hidd_main_id.Value = "";
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
            DataTable dt = Evaluation_Sub_Items_Manager_DB.Select_Eval_SubMainItemsManager(CDataConverter.ConvertToInt(e.CommandArgument.ToString()));
            if (dt.Rows.Count > 0)
            {
                Page.RegisterStartupScript("success", "<script language=javascript>alert('لم يتم الحذف لوجود سجلات مرتبطة')</script");
   
            }

            else
            {
                Evaluation_Main_Items_Manager_DB.Delete(CDataConverter.ConvertToInt(e.CommandArgument.ToString()));

                FillGrid();
                clear();
                Page.RegisterStartupScript("success", "<script language=javascript>alert('تم الحذف بنجاح')</script");
            }



        }
        if (e.CommandName == "Updates")
        {

            Evaluation_Main_Items_Manager_DT adminob = new Evaluation_Main_Items_Manager_DT();


            adminob = Evaluation_Main_Items_Manager_DB.SelectByID(Int32.Parse(e.CommandArgument.ToString()));
            txt_mainitem.Text = adminob.Name;

            hidd_main_id.Value = adminob.Main_Item_Id.ToString();





        }
    }
    protected void ddl_Groups_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void clear()
    {
        hidd_main_id.Value=
        txt_mainitem.Text = "";
    }
}