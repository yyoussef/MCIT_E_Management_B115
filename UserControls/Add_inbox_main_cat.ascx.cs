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

public partial class UserControls_Add_inbox_main_cat : System.Web.UI.UserControl
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
        string sql = "";
        int group = CDataConverter.ConvertToInt(Session_CS.group_id.ToString());

        sql = "select * from Inbox_Main_Categories where group_id = " + group;

        DataTable dt = General_Helping.GetDataTable(sql);

        gvMain.DataSource = dt;
        gvMain.DataBind();

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        int group = CDataConverter.ConvertToInt(Session_CS.group_id.ToString());
        // int type = CDataConverter.ConvertToInt(Drop_type.SelectedValue);
        if (btnSave.CommandArgument == "edit")
        {
            General_Helping.ExcuteQuery("update Inbox_Main_Categories set name ='" + txtCatName.Text + "' where id=" + CMT_ID.Value);
            btnSave.CommandArgument = "new";
            btnSave.Text = "حفظ";
        }
        else
        {
            DataTable DT = General_Helping.GetDataTable("select id from Inbox_Main_Categories where name='" + txtCatName.Text + "' and group_id='" + CDataConverter.ConvertToInt(Session_CS.group_id) + "' ");
            if (DT.Rows.Count > 0)
            {
                lblPageStatus.Visible = true;
                lblPageStatus.Text = "هذا التصنيف موجود";
                return;
            }

            string Sql_insert = "insert into Inbox_Main_Categories ( Name , group_id ) values ( '" + txtCatName.Text + "'," + group + ")";
            General_Helping.ExcuteQuery(Sql_insert);

            //General_Helping.ExcuteQuery("insert into Inbox_Main_Categories (name) values ('" + txtCatName.Text + "')");
            int lastID = CDataConverter.ConvertToInt(General_Helping.GetDataTable("select id from Inbox_Main_Categories where name='" + txtCatName.Text + "'").Rows[0]["id"]);
            General_Helping.ExcuteQuery("insert into Inbox_sub_categories (name,main_id) values ('غير مصنف'," + lastID + ")");

        }
        FillGrid();
        lblPageStatus.Visible = true;
        lblPageStatus.Text = "تم الحفظ بنجاح";
        txtCatName.Text = "";
    }
    protected void ImgBtnEdit_Click(object sender, System.Web.UI.ImageClickEventArgs e)
    {
        btnSave.CommandArgument = "edit";
        btnSave.Text = "تعديل";
        string Sql = "select name from Inbox_Main_Categories where id = " + ((ImageButton)sender).CommandArgument;
        DataTable _dt = General_Helping.GetDataTable(Sql);
        txtCatName.Text = _dt.Rows[0]["name"].ToString();
        lblPageStatus.Visible = false;
        CMT_ID.Value = ((ImageButton)sender).CommandArgument;

        int i = 0, id = 0;
        foreach (GridViewRow row in gvMain.Rows)
        {
            if (((TextBox)row.FindControl("txtid")).Text == CMT_ID.Value)
                id = i;
            else
                gvMain.Rows[i].BackColor = System.Drawing.Color.White;


            i += 1;
        }

        gvMain.Rows[id].BackColor = System.Drawing.Color.Lavender;

    }

    protected void ImgBtnDelete_Click(object sender, System.Web.UI.ImageClickEventArgs e)
    {
        SqlParameter[] sqlParams = new SqlParameter[] 
          {
         
           new SqlParameter("@cat_id",((ImageButton)sender).CommandArgument),
           new SqlParameter("@type",1)
          
          };
        //int row = SqlHelper.ExecuteNonQuery(Database.ConnectionString, CommandType.StoredProcedure, "Select_InboxCat_ByCatID", sqlParams);

       
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
    public string Get_Type(object obj)
    {
        string str = obj.ToString();
        if (str == "1")
            return "وارد";
        else if (str == "3")
            return "تأشيرة وزير";

        else return "";
    }

}
