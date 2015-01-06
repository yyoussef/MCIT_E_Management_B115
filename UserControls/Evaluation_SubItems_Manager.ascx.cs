using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class UserControls_Evaluation_Sub_Items : System.Web.UI.UserControl
{
    //Session_CS Session_CS = new Session_CS();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Fill_Module();

            FillGrid();
            Calc_Weigth_Total();
           
        }

    }
    private void Fill_Module()
    {


        DataTable dt = Evaluation_Main_Items_Manager_DB.SelectAll();
        ddl_Groups.DataSource = dt;
        ddl_Groups.DataValueField = "Main_Item_Id";
        ddl_Groups.DataTextField = "Name";

        ddl_Groups.DataBind();
        ddl_Groups.Items.Insert(0, new ListItem("..... اختر عنصر التقييم الرئيسي ....", "0"));

        
    }

    void Calc_Weigth_Total()
    {
        decimal Total_Weight = 0;
        try
        {
            DataTable dt = Evaluation_Sub_Items_Manager_DB.Evaluation_Sub_Items_Manager_Sum();

            if (dt.Rows.Count > 0)
            {
                Total_Weight = CDataConverter.ConvertToDecimal(dt.Rows[0]["weight"].ToString());
                txt_Total_Weight.Text = Total_Weight.ToString();
            }
        }

        catch (Exception ex)
        {

        }
      
    }
    public bool  check_weight()
    {
        decimal weight = 0; 
        decimal tot_wight = 0;
        decimal tot_update = 0;

        DataTable dt = Evaluation_Sub_Items_Manager_DB.Evaluation_Sub_Items_Manager_Sum();
        if (dt.Rows.Count > 0)
        {
            weight = CDataConverter.ConvertToDecimal(dt.Rows[0]["weight"].ToString());
        }

        tot_wight = weight + CDataConverter.ConvertToDecimal(txt_weight.Text);

  
            
        if (tot_wight <= 100 && hid_sub_id.Value =="" )
        {
            return true;
        }
        else if ((weight - CDataConverter.ConvertToDecimal(Lbl_weight.Text))+ CDataConverter.ConvertToDecimal( txt_weight.Text)<=100 && hid_sub_id.Value != "")
        {
            return true;
        }

        else
        {
            //Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('إجمالي أوزان عناصر تقييم الاداء يجب الا يتجاوز 100')</script>");
            return false;

        }



    }
 
    protected void save_Click(object sender, EventArgs e)
    {
    

    

        if (ddl_Groups.SelectedValue != "" && ddl_Groups.SelectedValue != "0")
        {
            if ( check_weight())
            {
                Evaluation_Sub_Items_Manager_DT admino = new Evaluation_Sub_Items_Manager_DT();
                admino.Name = txt_subitem.Text;
                admino.ToolTip = txt_notes.Text;
                admino.FK_Main_Item_Id = CDataConverter.ConvertToInt(ddl_Groups.SelectedValue);
                admino.Sub_Item_Id = CDataConverter.ConvertToInt(hid_sub_id.Value);
                admino.Weight = CDataConverter.ConvertToDecimal(txt_weight.Text);
                admino.Sub_Item_Id = Evaluation_Sub_Items_Manager_DB.Save(admino);

                hid_sub_id.Value =
                txt_notes.Text = "";
                clear();
                Calc_Weigth_Total();
                FillGrid();

                 //if (admino.Sub_Item_Id > 0)
                 // {
                      Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('تم الحفظ بنجاح')</script>");

                  //}
            }
            else
            {
                Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('إجمالي أوزان عناصر تقييم الاداء يجب الا يتجاوز 100')</script>");

            }
          
        }

        else
        {
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert(' يجب إختيار عنصر التقييم الرئيسي')</script>");

        }
    }
    protected void gvMain_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "dlt")
        {

            Evaluation_Sub_Items_Manager_DB.Delete(CDataConverter.ConvertToInt(e.CommandArgument.ToString()));

            FillGrid();
            clear();
            Calc_Weigth_Total();
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('تم الحذف بنجاح')</script>");
        }


        else if (e.CommandName == "Show")
        {

            Evaluation_Sub_Items_Manager_DT obj = Evaluation_Sub_Items_Manager_DB.SelectByID(CDataConverter.ConvertToInt(e.CommandArgument.ToString()));

            txt_subitem.Text = obj.Name;
            txt_notes.Text = obj.ToolTip;
            hid_sub_id.Value = obj.Sub_Item_Id.ToString();
            ddl_Groups.SelectedValue = obj.FK_Main_Item_Id.ToString();
            txt_weight.Text =  obj.Weight.ToString();
            Lbl_weight.Text = obj.Weight.ToString(); 
        


        }

    }
    protected void FillGrid()
    {

        DataTable dat = new DataTable();
        dat = Evaluation_Sub_Items_Manager_DB.SelectAll();
        gvMain.DataSource = dat;
        gvMain.DataBind();


    }
    protected void gvMain_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvMain.PageIndex = e.NewPageIndex;
        FillGrid();

    }

    private void clear()
    {
        hid_sub_id.Value=
        txt_notes.Text = "";
        txt_subitem.Text = "";
        txt_weight.Text = "";
    }
}
