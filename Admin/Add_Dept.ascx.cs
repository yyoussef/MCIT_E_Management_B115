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

public partial class UserControls_Add_Dept : System.Web.UI.UserControl
{
    Session_CS Session_CS = new Session_CS();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //comment
            FillGrid();
            Fill_sector();

        }
    }
    protected void FillGrid()
    {
        if (CDataConverter.ConvertToInt(ddl_sectors.SelectedValue) > 0)
        {
          //  string sql = "select * from Departments where sec_sec_id=" + ddl_sectors.SelectedValue;

           // DataTable dt = General_Helping.GetDataTable(sql);

            DataTable dt = SqlHelper.ExecuteDataset(Database.ConnectionString, "Select_SectorDepartments", ddl_sectors.SelectedValue).Tables[0];

            if (dt.Rows.Count > 0)
            {
                gvMain.DataSource = dt;
                gvMain.DataBind();
            }
        }
    }
    private void Fill_sector()
    {
       // string sql = "select * from sectors where foundation_id='"+Session_CS.foundation_id +"'";

        //DataTable dt = General_Helping.GetDataTable(sql);
        DataTable dt = SqlHelper.ExecuteDataset(Database.ConnectionString, "Select_FoundationSectors", Session_CS.foundation_id).Tables[0];

        if(dt.Rows.Count>0)
        {
        ddl_sectors.DataSource = dt;
        ddl_sectors.DataValueField = "Sec_id";
        ddl_sectors.DataTextField = "Sec_name";
        ddl_sectors.DataBind();
        ddl_sectors.Items.Insert(0, new ListItem("اختر القطاع......", "0"));
        }

    }
    protected void ddl_sectors_SelectedIndexChanged(object sender, EventArgs e)
    {
      //  string sql = "select * from Departments where sec_sec_id=" + ddl_sectors.SelectedValue;
       // DataTable dt = General_Helping.GetDataTable(sql);
        DataTable dt = SqlHelper.ExecuteDataset(Database.ConnectionString, "Select_SectorDepartments", ddl_sectors.SelectedValue).Tables[0];
        if (dt.Rows.Count > 0)
        {

            gvMain.DataSource = dt;
            gvMain.DataBind();
        }

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
    
        if (btnSave.CommandArgument == "edit")
        {
            
            Departments_DT deptdt = new Departments_DT();
            deptdt.Dept_name = txtCatName.Text;
            deptdt.Dept_parent_id = 0;
            deptdt.Sec_sec_id = Convert.ToInt32(ddl_sectors.SelectedValue);
           
            deptdt.Dept_id = CDataConverter.ConvertToInt(CMT_ID.Value);
            Departments_DB.Save(deptdt);
            btnSave.CommandArgument = "new";
            btnSave.Text = "حفظ";

        }
        else
        {
         //   string sql = "select * from Departments where Dept_name='" + txtCatName.Text + "' and Sec_sec_id = " + Convert.ToInt32(ddl_sectors.SelectedValue);

         //   DataTable dt = General_Helping.GetDataTable(sql);

            DataTable dt = SqlHelper.ExecuteDataset(Database.ConnectionString, "check_deptexist", txtCatName.Text, Convert.ToInt32(ddl_sectors.SelectedValue)).Tables[0];

            if (dt.Rows.Count > 0)
            {
                lblPageStatus.Visible = true;
                lblPageStatus.Text = "هذة الادارة موجوده من قبل";
                return;
            }

          
            Departments_DT deptdt = new Departments_DT();
            deptdt.Dept_name = txtCatName.Text;
            deptdt.Dept_parent_id = 0;
            deptdt.Sec_sec_id = Convert.ToInt32(ddl_sectors.SelectedValue);
          
            long x = Departments_DB.Save(deptdt);

        

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
        DataTable dt = SqlHelper.ExecuteDataset(Database.ConnectionString, "Departments_Select", ((ImageButton)sender).CommandArgument).Tables[0];

        Departments_DT dept = new Departments_DT();
        dept = Departments_DB.SelectByID(CDataConverter.ConvertToInt(((ImageButton)sender).CommandArgument));

        txtCatName.Text = dt.Rows[0]["Dept_name"].ToString();
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
        //string Sql = "select Dept_dept_id from employee where Dept_dept_id = " + ((ImageButton)sender).CommandArgument;
        //DataTable _dt = General_Helping.GetDataTable(Sql);

        DataTable dt = SqlHelper.ExecuteDataset(Database.ConnectionString, "EmployeeSelectbydept", ((ImageButton)sender).CommandArgument).Tables[0];

        if (dt.Rows.Count < 1)
        {
            Departments_DB.Delete(Convert.ToInt32(((ImageButton)sender).CommandArgument));

            lblPageStatus.Visible = true;
            lblPageStatus.Text = "تم الحفظ بنجاح";
            FillGrid();
        }
        else
        {
            lblPageStatus.Visible = true;
            lblPageStatus.Text = "لا يمكن حذف الإدارة لوجود موظفين بها";
        }

    }
  

}
