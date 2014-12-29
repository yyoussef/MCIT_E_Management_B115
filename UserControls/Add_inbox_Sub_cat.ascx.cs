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
using System.Text;
using System.Data.SqlClient;
using System.IO;

using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;

public partial class UserControls_Add_inbox_Sub_cat : System.Web.UI.UserControl
{
    General_Helping Obj_General_Helping = new General_Helping();
    Session_CS Session_CS = new Session_CS();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Fillddl();
           
          

        }
    }
    protected void Fillddl()
    {

        int group = CDataConverter.ConvertToInt(Session_CS.group_id.ToString());
        DataTable DT3 = General_Helping.GetDataTable("select * from Inbox_Main_Categories where group_id = " + group );
        
        Obj_General_Helping.SmartBindDDL(ddlMainCat, DT3, "id", "name", "....اختر التصنيف الرئيسى ....");
    }



    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (ddlMainCat.SelectedIndex != 0)
        {
            if (btnSave.CommandArgument == "edit")
            {
                //if (txtCatName.Text != "" & CST_ID.Value !="0")
                //{

                //General_Helping.ExcuteQuery("update Inbox_sub_categories set name ='" + txtCatName.Text + "' where id=" + CST_ID.Value);
                int x = Inbox_DB.Inbox_sub_categories_update(txtCatName.Text, CST_ID.Value);
                btnSave.CommandArgument = "new";
                btnSave.Text = "حفظ";

            }

            else
            {
                DataTable DT = General_Helping.GetDataTable("  select Inbox_sub_categories.id from Inbox_sub_categories inner join  dbo.inbox_Main_Categories on dbo.inbox_Main_Categories.id=dbo.inbox_sub_categories.main_id and inbox_Main_Categories.group_id='" + CDataConverter.ConvertToInt(Session_CS.group_id) + "' where Inbox_sub_categories.name='" + txtCatName.Text + "'");
                if (DT.Rows.Count > 0)
                {
                    lblPageStatus.Visible = true;
                    lblPageStatus.Text = "هذا التصنيف موجود";
                    return;
                }
                General_Helping.ExcuteQuery("insert into Inbox_sub_categories (name,main_id) values ('" + txtCatName.Text + "'," + ddlMainCat.SelectedValue + ")");

            }
            FillGrid();
            lblPageStatus.Visible = true;
            lblPageStatus.Text = "تم الحفظ بنجاح";
        }
        else
        {
            lblPageStatus.Visible = true;
            lblPageStatus.Text = "اختر التصنيف الرئيسى";
        }
    }
    protected void ImgBtnEdit_Click(object sender, System.Web.UI.ImageClickEventArgs e)
    {
        btnSave.CommandArgument = "edit";
        btnSave.Text = "تعديل";
        string Sql = "select name from Inbox_sub_categories where id = " + ((ImageButton)sender).CommandArgument;
        DataTable _dt = General_Helping.GetDataTable(Sql);
        txtCatName.Text = _dt.Rows[0]["name"].ToString();
        lblPageStatus.Visible = false;
        CST_ID.Value = ((ImageButton)sender).CommandArgument;

        int i = 0, id = 0;
        foreach (GridViewRow row in gvSub.Rows)
        {
            if (((TextBox)row.FindControl("txtid")).Text == CST_ID.Value)
                id = i;
            else
                gvSub.Rows[i].BackColor = System.Drawing.Color.White;


            i += 1;
        }

        gvSub.Rows[id].BackColor = System.Drawing.Color.Lavender;

    }

    protected void ImgBtnDelete_Click(object sender, System.Web.UI.ImageClickEventArgs e)
    {

        SqlParameter[] sqlParams = new SqlParameter[] 
          {
         
           new SqlParameter("@cat_id",((ImageButton)sender).CommandArgument),
           new SqlParameter("@type",2)
          
          };

        DataTable dt = DatabaseFunctions.SelectDataByParam(sqlParams, "Select_InboxCat_ByCatID");
        if (dt != null && dt.Rows[0]["deleted"].ToString() == "")
        {
            lblPageStatus.Visible = true;
            lblPageStatus.Text = "لا يمكن الحذف حيث أن هذا التصنيف مرتبط بصادر أو وارد";
        }

        if (dt != null && dt.Rows[0]["deleted"].ToString() == "rowsdeleted")
        {
            lblPageStatus.Visible = true;
            lblPageStatus.Text = "تم الحذف بنجاح";

        }
        FillGrid();
    }
    protected void ddlMainCat_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblPageStatus.Visible = false;
        lblPageStatus.Text = "";
        FillGrid();
    }
    protected void Drop_type_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblPageStatus.Visible = false;
        lblPageStatus.Text = "";
        Fillddl();
        //DataTable dt =  General_Helping.GetDataTable();
    }
    protected void FillGrid()
    {
        if (ddlMainCat.SelectedIndex != 0)
        {
            string sql = "select * from Inbox_sub_categories where  main_id= " + ddlMainCat.SelectedValue;
            DataTable dt = General_Helping.GetDataTable(sql);

            gvSub.DataSource = dt;
            gvSub.DataBind();
        }


    }
   
}
