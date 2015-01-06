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

public partial class UserControls_Add_Sectors : System.Web.UI.UserControl
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
        DataTable dt;
        dt = Sectors_DB.SelectAll(0, CDataConverter.ConvertToInt(Session_CS.foundation_id.ToString()));
        gvMain.DataSource = dt;
        gvMain.DataBind();

    }


    protected void btnSave_Click(object sender, EventArgs e)
    {
        // int group = CDataConverter.ConvertToInt(Session_CS.group_id.ToString());
        // int type = CDataConverter.ConvertToInt(Drop_type.SelectedValue);
        if (btnSave.CommandArgument == "edit")
        {
            //General_Helping.ExcuteQuery("update Departments set Dept_name =N'" + txtCatName.Text + "' where dept_id=" + CMT_ID.Value);
            //General_Helping.ExcuteQuery(Sql_insert);
            Sectors_DT Secdt = new Sectors_DT();
            Secdt.Sec_name = txtCatName.Text;
            Secdt.foundation_id = CDataConverter.ConvertToInt(Session_CS.foundation_id.ToString());

            Secdt.Sec_id = CDataConverter.ConvertToInt(CMT_ID.Value);
            Sectors_DB.Save(Secdt);
            btnSave.CommandArgument = "new";
            btnSave.Text = "حفظ";

        }
        else
        {
            string sql = "select * from Sectors where Sec_name='" + txtCatName.Text + "' and foundation_id = " + CDataConverter.ConvertToInt(Session_CS.foundation_id.ToString());
            DataTable dt = General_Helping.GetDataTable(sql);
            //Departments_DT dept = Departments_DB.SelectByID(txtCatName.Text);
            if (dt.Rows.Count > 0)
            {
                lblPageStatus.Visible = true;
                lblPageStatus.Text = "هذا القطاع موجود من قبل";
                return;
            }

            Sectors_DT Secdt = new Sectors_DT();
            Secdt.Sec_name = txtCatName.Text;
            Secdt.foundation_id = CDataConverter.ConvertToInt(Session_CS.foundation_id.ToString());

            long x = Sectors_DB.Save(Secdt);

        }
        FillGrid();
        lblPageStatus.Visible = true;
        lblPageStatus.Text = "تم الحفظ بنجاح";
    }
    protected void ImgBtnEdit_Click(object sender, System.Web.UI.ImageClickEventArgs e)
    {
        btnSave.CommandArgument = "edit";
        btnSave.Text = "تعديل";
        //string Sql = "select Dept_name from Departments where Dept_id = " + ((ImageButton)sender).CommandArgument;
        //DataTable _dt = General_Helping.GetDataTable(Sql);
        Sectors_DT sec = new Sectors_DT();
        sec = Sectors_DB.SelectByID(Convert.ToInt32(((ImageButton)sender).CommandArgument), CDataConverter.ConvertToInt(Session_CS.foundation_id.ToString()));

        txtCatName.Text = sec.Sec_name.ToString();
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
        string Sql = "select Dept_name from Departments where Sec_sec_id = " + ((ImageButton)sender).CommandArgument;
        DataTable _dt = General_Helping.GetDataTable(Sql);

        if (_dt.Rows.Count < 1)
        {
            Sectors_DB.Delete(Convert.ToInt32(((ImageButton)sender).CommandArgument));
            lblPageStatus.Visible = true;
            lblPageStatus.Text = "تم الحفظ بنجاح";
            FillGrid();
        }
        else
        {
            lblPageStatus.Visible = true;
            lblPageStatus.Text = "لا يمكن حذف القطاع لارتباطه بإدارات";
        }

    }


}
