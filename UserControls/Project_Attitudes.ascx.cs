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
using System.Data.SqlClient;

public partial class UserControls_Project_Attitude : System.Web.UI.UserControl
{
    Session_CS Session_CS = new Session_CS();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           fillgrid();
           

        }
    }
    private void fillgrid()
    {
        DataTable DT = Project_Attitude_DB.SelectAll(CDataConverter.ConvertToInt(Session_CS.Project_id));
        gvMain.DataSource = DT;
        gvMain .DataBind();
        
    }
   

    protected void btn_Save_Click(object sender, EventArgs e)
    {
        
         string t1;
         if (CDataConverter.ConvertToDate(txtattdate.Text) < CDataConverter.ConvertDateTimeNowRtnDt())
         {
             t1 = VB_Classes.Dates.Dates_Operation.date_validate(txtattdate.Text.Trim());
             Project_Attitude_DT obj = new Project_Attitude_DT();
             obj.Proj_id = CDataConverter.ConvertToInt(Session_CS.Project_id.ToString());
             obj.last_attitude_desc = att_desc.Text;
             obj.last_attitude_date = txtattdate.Text;
             obj.id = CDataConverter.ConvertToInt(project_id.Value);
             obj.id =  Project_Attitude_DB.Save(obj);
             project_id.Value =
             att_desc.Text = "";
             txtattdate.Text = "";
             if (obj.id > 0)
             {
                 Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('تم الحفظ بنجاح')</script>");
                 fillgrid();

             }
         }
         else
         {
             Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('أدخل التاريخ بصورة صحيحة')</script>");

         }
            
           
        
    }


  



    protected void gvMain_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Show")
        {
            Project_Attitude_DT obj = Project_Attitude_DB.SelectByID(CDataConverter.ConvertToInt(e.CommandArgument));
            project_id.Value = obj.id.ToString();
            att_desc.Text = obj.last_attitude_desc.ToString();
            txtattdate.Text = obj.last_attitude_date.ToString();


        }
        else if (e.CommandName == "dlt")
        {
            Project_Attitude_DB.Delete(CDataConverter.ConvertToInt(e.CommandArgument));
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('تم الحذف بنجاح')</script>");
            fillgrid();
          
        }

    }
    //protected void gvMain_PreRender(object sender, EventArgs e)
    //{
    //       MergeRows(gvMain);
    //}
    //protected void MergeRows(GridView GridView)
    //{
    //    if (GridView.Rows.Count > 1)
    //    {
    //        for (int rowIndex = GridView.Rows.Count - 2; rowIndex > -1; rowIndex--)
    //        {
    //            GridViewRow row = GridView.Rows[rowIndex];
    //            GridViewRow previousRow = GridView.Rows[rowIndex + 1];
    //            string last = previousRow.Cells[4].Text;
    //            if (row.Cells[4].Text == last)
    //            {
    //                if (previousRow.Cells[4].RowSpan < 2)
    //                    row.Cells[4].RowSpan = 2;
    //                else
    //                    row.Cells[4].RowSpan = CDataConverter.ConvertToInt(previousRow.Cells[4].RowSpan + 1);

    //                previousRow.Cells[4].Visible = false;
    //            }
    //        }
    //    }
    //}
}
