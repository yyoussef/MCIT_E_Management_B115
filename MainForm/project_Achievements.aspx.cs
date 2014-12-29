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


public partial class WebForms2_project_Achievements : System.Web.UI.Page
{
    Session_CS Session_CS = new Session_CS();
    General_Helping Obj_General_Helping = new General_Helping();
    public void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillddl();
            fillgrid();
            
        }

    }
    #region "fills"

    private void fillgrid()
    {
        DataTable DT = project_achievements_DB.SelectAll(CDataConverter.ConvertToInt(Session_CS.Project_id));
        gvAchievements.DataSource = DT;
        gvAchievements.DataBind();
        txtOther.Visible = false;
        Clear_fields();
    }
    private void Clear_fields()
    {
        achievement_ID.Value =
        txtAchiveDesc.Text =
        txtOther.Text =
        txtStartDate.Text =
        txtEndDate.Text = "";
        txtOther.Visible = false;
        ddlAchiveTypes.SelectedIndex = 0;
    }
    private void fillddl()
    {
        DataTable DT = General_Helping.GetDataTable("select * from achievments_types order by type_id");
        Obj_General_Helping.SmartBindDDL(ddlAchiveTypes, DT, "type_id", "type_desc", ".. اختر نوع الانجاز ..");
    }

    protected void ddlAchiveTypes_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (CDataConverter.ConvertToInt(ddlAchiveTypes.SelectedValue) == 4)
            txtOther.Visible = true;
        else
            txtOther.Visible = false;
    }

    # endregion

    #region "save"

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (check_valid())
            {
                project_achievements_DT obj = new project_achievements_DT();

                obj.ach_id = CDataConverter.ConvertToInt(achievement_ID.Value);
                obj.ach_desc= txtAchiveDesc.Text;
                if (CDataConverter.ConvertToInt(ddlAchiveTypes.SelectedValue) == 0)
                    obj.ach_type = 4;
                else
                    obj.ach_type= CDataConverter.ConvertToInt(ddlAchiveTypes.SelectedValue);
                obj.ach_other_desc = txtOther.Text;
                obj.ach_from_date = txtStartDate.Text;
                obj.ach_to_date = txtEndDate.Text;
                obj.proj_id = CDataConverter.ConvertToInt(Session_CS.Project_id);
                obj.ach_id=project_achievements_DB.Save(obj);
                if (obj.ach_id > 0)
                {
                    Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('تم الحفظ بنجاح')</script>");
                    fillgrid();
                    
                }
            }

        }

        private bool check_valid()
        {   
            bool flag = true;

            // validate desc 

            if (txtAchiveDesc.Text == "")
            {
                Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('أدخل وصف الإنجاز')</script>");
                flag = false;
                return flag;
            }
            // validate start date

            if (txtStartDate.Text != "")
            {
                txtStartDate.Text =  CDataConverter.ConvertDateTimeToFormatdmy (CDataConverter.ConvertToDate(txtStartDate.Text));
            //      if (Dates_operations.date_validate(txtStartDate.Text) != "")
            //{
            //    txtStartDate.Text = Dates_operations.date_validate(txtStartDate.Text);

            }
            else if (txtStartDate.Text != "")
            {
                Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('أدخل التاريخ (يوم/شهر/سنة) ')</script>");
                txtStartDate.Text = "";
                flag = false;
                return flag;
            }

            // validate end date

            //if (Dates_operations.date_validate(txtEndDate.Text) != "")
            //{
            //    txtEndDate.Text = Dates_operations.date_validate(txtEndDate.Text);
            if (txtEndDate.Text != "")
            {
                txtEndDate.Text = CDataConverter.ConvertDateTimeToFormatdmy(CDataConverter.ConvertToDate(txtEndDate.Text));
            }
            else if (txtEndDate.Text != "")
            {
                Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('أدخل التاريخ (يوم/شهر/سنة) ')</script>");
                txtEndDate.Text = "";
                flag = false;
                return flag;
            }
            // validate start_end date
            if (txtEndDate.Text != "" && txtStartDate.Text != "")
            {
                if (Dates_operations.Date_compare(txtEndDate.Text, txtStartDate.Text) == false)
                {
                    Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('تاريخ البداية يجب أن يكون قبل تاريخ النهاية ')</script>");
                    txtEndDate.Text = "";
                    flag = false;
                    return flag;
                }
            }


            return flag;
        }

    #endregion

        # region "edit_delete"

       

        protected void GrdView_RowCommand(object sender, GridViewCommandEventArgs e)
     {


         if (e.CommandName == "Show")
         {
             project_achievements_DT obj = project_achievements_DB.SelectByID(CDataConverter.ConvertToInt(e.CommandArgument));

             achievement_ID.Value = obj.ach_id.ToString();
             txtAchiveDesc.Text = obj.ach_desc.ToString();
             ddlAchiveTypes.SelectedValue = obj.ach_type.ToString();
             if (CDataConverter.ConvertToInt(ddlAchiveTypes.SelectedValue) == 4)
                 txtOther.Visible = true;
             else
                 txtOther.Visible = false;
             txtOther.Text = obj.ach_other_desc.ToString();
             txtStartDate.Text = obj.ach_from_date.ToString();
             txtEndDate.Text = obj.ach_to_date.ToString();


         }
         else if (e.CommandName == "dlt")
         {
             project_achievements_DB.Delete(CDataConverter.ConvertToInt(e.CommandArgument));
             Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('تم الحذف بنجاح')</script>");
             fillgrid();
             fillddl();
         }
     }

    #endregion




        protected void gvAchievements_PreRender(object sender, EventArgs e)
        {
            MergeRows(gvAchievements);
        }

        protected void MergeRows(GridView GridView)
        {
            if (GridView.Rows.Count > 1)
            {
                for (int rowIndex = GridView.Rows.Count - 2; rowIndex > -1; rowIndex--)
                {
                    GridViewRow row = GridView.Rows[rowIndex];
                    GridViewRow previousRow = GridView.Rows[rowIndex + 1];
                    string last = previousRow.Cells[4].Text;
                    if (row.Cells[4].Text == last)
                    {
                        if (previousRow.Cells[4].RowSpan < 2)
                            row.Cells[4].RowSpan = 2;
                        else
                            row.Cells[4].RowSpan = CDataConverter.ConvertToInt(previousRow.Cells[4].RowSpan + 1);

                        previousRow.Cells[4].Visible = false;
                    }
                }
            }
        }
}
