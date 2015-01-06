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

public partial class UserControls_Add_Org : System.Web.UI.UserControl
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
        int found_id = CDataConverter.ConvertToInt(Session_CS.foundation_id.ToString());
      
        DataTable dt = Organization_DB.SelectAll(found_id);

        gvMain.DataSource = dt;
        gvMain.DataBind();

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        int found_id = CDataConverter.ConvertToInt(Session_CS.foundation_id.ToString());
        DataTable dt = Organization_DB.orgbyname(txtCatName.Text, found_id);
        gvMain.DataSource = dt;
        gvMain.DataBind();
         

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        int found_id = CDataConverter.ConvertToInt(Session_CS.foundation_id.ToString());
    
        if (txtCatName.Text != "")
        {
            if (btnSave.CommandArgument == "edit")
            {
             
                Organization_DT deptOrg = new Organization_DT();
                deptOrg.Org_Desc = txtCatName.Text;

                deptOrg.Org_ID = CDataConverter.ConvertToInt(CMT_ID.Value);
                deptOrg.New_ID = 0;
                deptOrg.foundation_id = found_id;
                Organization_DB.Save(deptOrg);
                btnSave.CommandArgument = "new";
                btnSave.Text = "حفظ";
                txtCatName.Text = "";
            }
            else
            {
                Organization_DT Org = Organization_DB.SelectByName(txtCatName.Text, CDataConverter.ConvertToInt(Session_CS.foundation_id.ToString()));
                
                if (Org != null && Org.Org_ID > 0)
                {
                   
                    lblPageStatus.Visible = true;
                    lblPageStatus.Text = "هذة الجهة موجوده من قبل";
                    return;
                }

              
                Organization_DT deptOrg = new Organization_DT();
                deptOrg.Org_Desc = txtCatName.Text;
                deptOrg.New_ID = 0;
                deptOrg.foundation_id = found_id;
                Organization_DB.Save(deptOrg);

            


            }
            FillGrid();
            lblPageStatus.Visible = true;
            txtCatName.Text = "";
            lblPageStatus.Text = "تم الحفظ بنجاح";
        }
        else
        {
            lblPageStatus.Visible = true;
            lblPageStatus.Text = "ادخل اسم الجهة";
            return;
        }

    }

    protected void BtnNew_Click(object sender, EventArgs e)
    {
        CMT_ID.Value =
        txtCatName.Text = "";
        btnSave.Text = "حفظ";
        lblPageStatus.Visible = false;

    }
    protected void ImgBtnEdit_Click(object sender, System.Web.UI.ImageClickEventArgs e)
    {
        btnSave.CommandArgument = "edit";
        btnSave.Text = "تعديل";
     
       // DataTable OrgDT = new DataTable();

      //  OrgDT = General_Helping.GetDataTable("select * from Organization where Org_ID = " + CDataConverter.ConvertToInt(((ImageButton)sender).CommandArgument));

        DataTable dt = SqlHelper.ExecuteDataset(Database.ConnectionString, "organizations_selectbyid", CDataConverter.ConvertToInt(((ImageButton)sender).CommandArgument)).Tables[0];

        txtCatName.Text = dt.Rows[0]["Org_Desc"].ToString();
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
      //  string Sql = "select org_id from inbox where org_id = " + ((ImageButton)sender).CommandArgument;

      //  DataTable _dt = General_Helping.GetDataTable(Sql);

        //Outbox_DT odt = Outbox_DB.SelectOutboxByOrg(CDataConverter.ConvertToInt(((ImageButton)sender).CommandArgument));
        //Inbox_DT indt = Inbox_DB.SelectInboxByOrg(CDataConverter.ConvertToInt(((ImageButton)sender).CommandArgument));
       
        DataTable dt = SqlHelper.ExecuteDataset(Database.ConnectionString, "InboxOutbox_DeleteByOrg", CDataConverter.ConvertToInt(((ImageButton)sender).CommandArgument)).Tables[0];

        if (dt != null && dt.Rows[0]["row"].ToString() == "")
        {
            lblPageStatus.Visible = true;
            lblPageStatus.Text = "لا يمكن حذف الجهة لوجود صادر أو وارد خاص بها";
        }

        else if (dt != null && dt.Rows[0]["row"].ToString() == "affected")
        {
           // Organization_DB.Delete(CDataConverter.ConvertToInt(((ImageButton)sender).CommandArgument));
            lblPageStatus.Visible = true;
            lblPageStatus.Text = "تم الحذف بنجاح";
            CMT_ID.Value =
            txtCatName.Text = "";
            btnSave.Text = "حفظ";
        }
        FillGrid();

    }

}
