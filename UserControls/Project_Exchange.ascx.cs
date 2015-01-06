using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class UserControls_Project_Exchange : System.Web.UI.UserControl
{
    //Session_CS Session_CS = new Session_CS();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(! IsPostBack )
        {
            fill_year();
        }
    }

    protected void fill_year()
    {
        ddl_Year.Items.Insert(0, new ListItem("-- اختر السنة المالية --", "0"));
        ddl_Year.SelectedValue = "0";
      
        int x;
        int year= CDataConverter.ConvertDateTimeNowRtnDt().Year + 10;
        for (int i=2000;i<=year ;i++)
        {
            ListItem itm = new ListItem();
            x = i - 1;
            itm.Text = i.ToString() + "/" + x.ToString();
            itm.Value = x.ToString();
            
            ddl_Year.Items.Add(itm);

        }
    }


    protected void ddl_Year_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (CDataConverter.ConvertToInt(ddl_Year.SelectedValue) > 0)
        {
            Fill_Grid();
        }
    }

    private void Fill_Grid()
    {
       
        DataTable Dt = Project_Exchange_DB.Select_For_Grid(CDataConverter.ConvertToInt(Session_CS.Project_id.ToString()), CDataConverter.ConvertToInt(ddl_Year.SelectedValue));
        Gridview1.DataSource = Dt;
        Gridview1.DataBind();
    }

    protected void btn_Save_Click(object sender, EventArgs e)
    {
        bool Is_valid = true;
        foreach (GridViewRow row in Gridview1.Rows)
        {
            Label lbl_Project_Exchange_ID = ((Label)row.FindControl("lbl_Project_Exchange_ID"));
            Label lbl_Provider_ID = ((Label)row.FindControl("lbl_Provider_ID"));
            Label lbl_Sources_ID = ((Label)row.FindControl("lbl_Sources_ID"));
            Label lbl_Value = ((Label)row.FindControl("lbl_Value"));

            TextBox txt_Rewards = ((TextBox)row.FindControl("txt_Rewards"));
            TextBox txt_Transitions = ((TextBox)row.FindControl("txt_Transitions"));
            TextBox txt_Hotels = ((TextBox)row.FindControl("txt_Hotels"));
            TextBox txt_Requirements = ((TextBox)row.FindControl("txt_Requirements"));

            TextBox txt_Training = ((TextBox)row.FindControl("txt_Training"));
            TextBox txt_Application = ((TextBox)row.FindControl("txt_Application"));
            TextBox txt_Tenders = ((TextBox)row.FindControl("txt_Tenders"));
            TextBox txt_Resources = ((TextBox)row.FindControl("txt_Resources"));

            TextBox txt_Communication = ((TextBox)row.FindControl("txt_Communication"));
            TextBox txt_Engineering = ((TextBox)row.FindControl("txt_Engineering"));
            TextBox txt_Licence = ((TextBox)row.FindControl("txt_Licence"));
            TextBox txt_Reinvestment = ((TextBox)row.FindControl("txt_Reinvestment"));



            Project_Exchange_DT obj_Main = new Project_Exchange_DT();
            obj_Main.Project_Exchange_ID = CDataConverter.ConvertToInt(lbl_Project_Exchange_ID.Text);
            obj_Main.Provider_ID = CDataConverter.ConvertToInt(lbl_Provider_ID.Text);
            obj_Main.Sources_ID = CDataConverter.ConvertToInt(lbl_Sources_ID.Text);
            obj_Main.Proj_id = CDataConverter.ConvertToInt(Session_CS.Project_id.ToString());
            obj_Main.Year = CDataConverter.ConvertToInt(ddl_Year.SelectedValue);

            obj_Main.Rewards = CDataConverter.ConvertToDecimal(txt_Rewards.Text);
            obj_Main.Transitions = CDataConverter.ConvertToDecimal(txt_Transitions.Text);
            obj_Main.Hotels = CDataConverter.ConvertToDecimal(txt_Hotels.Text);
            obj_Main.Requirements = CDataConverter.ConvertToDecimal(txt_Requirements.Text);

            obj_Main.Training = CDataConverter.ConvertToDecimal(txt_Training.Text);
            obj_Main.Application = CDataConverter.ConvertToDecimal(txt_Application.Text);
            obj_Main.Tenders = CDataConverter.ConvertToDecimal(txt_Tenders.Text);
            obj_Main.Resources = CDataConverter.ConvertToDecimal(txt_Resources.Text);

            obj_Main.Communication = CDataConverter.ConvertToDecimal(txt_Communication.Text);
            obj_Main.Engineering = CDataConverter.ConvertToDecimal(txt_Engineering.Text);
            obj_Main.Licence = CDataConverter.ConvertToDecimal(txt_Licence.Text);
            obj_Main.Reinvestment = CDataConverter.ConvertToDecimal(txt_Reinvestment.Text);

            decimal Total_sum = obj_Main.Rewards + obj_Main.Transitions + obj_Main.Hotels + obj_Main.Requirements + obj_Main.Training +
                                  obj_Main.Application + obj_Main.Tenders + obj_Main.Resources + obj_Main.Communication + obj_Main.Engineering + obj_Main.Licence + obj_Main.Reinvestment;
            if (Total_sum <= CDataConverter.ConvertToDecimal(lbl_Value.Text))
            {
                lbl_Project_Exchange_ID.Text = Project_Exchange_DB.Save(obj_Main).ToString();
                row.BackColor = System.Drawing.Color.White;

            }
            else
            {
                row.BackColor = System.Drawing.Color.Red;
                Is_valid = false;
            }


        }
        if (Is_valid)
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم الحفظ بنجاح')</script>");
        else
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('إجمالى القيم فى الصف الاحمر يتعدى قيمة التمويل')</script>");

    }



}
