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
using System.Data.Entity;
using EFModels;

public partial class WebForms2_Groups : System.Web.UI.Page
{
    static long id;
    ActiveDirectoryContext ADContext = new ActiveDirectoryContext();

    //Session_CS Session_CS = new Session_CS();
    protected void Page_Load(object sender, EventArgs e)
    {
        fillgrid();
    }
    protected void ImgBtnDelete_Click(object sender, System.Web.UI.ImageClickEventArgs e)
    {
        int g_id = CDataConverter.ConvertToInt(((ImageButton)sender).CommandArgument);

        var emp_group = from emp in ADContext.EMPLOYEEs where emp.Group_id == g_id select emp;
        DataTable dt_emp = emp_group.ToDataTable();
        if (dt_emp.Rows.Count > 0)
        {
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لم يتم الحذف لوجود سجلات مرتبطة')</script>");
        }
        else
        {

            int x = Employee_Groups_DB.Delete(Convert.ToInt32(((ImageButton)sender).CommandArgument));
            if (x > 0)
            {
                Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('تم الحذف بنجاح')</script>");
                fillgrid();
                txt_Group_Name.Text = "";
            }
        }

    }
    protected void ImgBtnEdit_Click(object sender, System.Web.UI.ImageClickEventArgs e)
    {
        int found_id = CDataConverter.ConvertToInt(Session_CS.foundation_id.ToString());
        btn_Dept_Save.CommandArgument = "edit";
        Employee_Groups_DT _dt = Employee_Groups_DB.SelectByID(Convert.ToInt32(((ImageButton)sender).CommandArgument),found_id);
        txt_Group_Name.Text = _dt.Name;
        id = _dt.ID;

    }


    protected void btn_Dept_Save_Click(object sender, EventArgs e)
    {
        int found_id = CDataConverter.ConvertToInt(Session_CS.foundation_id.ToString());

      //  string sql = "select * from Employee_Groups where Name='" + txt_Group_Name.Text + "' and foundation_id = " + CDataConverter.ConvertToInt(Session_CS.foundation_id.ToString());


       // DataTable dt = General_Helping.GetDataTable(sql);

        DataTable dt = SqlHelper.ExecuteDataset(Database.ConnectionString, "SelectEmployee_Groups", txt_Group_Name.Text, CDataConverter.ConvertToInt(Session_CS.foundation_id.ToString())).Tables[0];

        if (dt.Rows.Count > 0)
        {
            Page.RegisterStartupScript("Error", "<script language=javascript>alert('اسم المجموعة موجود بالفعل')</script>");
            return;
        }
        if (txt_Group_Name.Text == "")
        {
            Page.RegisterStartupScript("Error", "<script language=javascript>alert('أدخل اسم المجموعة')</script>");
            return;
        }
        if (btn_Dept_Save.CommandArgument == "edit")
        {
            Employee_Groups_DT eg = new Employee_Groups_DT();
            eg.ID = id;
            eg.Name = txt_Group_Name.Text.Trim();
            eg.foundation_id = found_id;
            int x = Employee_Groups_DB.Save(eg);
            if (x > 0)
            {
                Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('تم الحفظ بنجاح')</script>");
                fillgrid();
                txt_Group_Name.Text = "";
            }
        }
        else
        {
            Employee_Groups_DT eg = new Employee_Groups_DT();
            eg.Name = txt_Group_Name.Text.Trim();
            eg.foundation_id = found_id;
            eg.ID = Employee_Groups_DB.Save(eg);

            if (eg.ID > 0)
            {
                Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('تم الحفظ بنجاح')</script>");
                fillgrid();
                txt_Group_Name.Text = "";
            }
        }
    }

    private void fillgrid()
    {
        int found_id = CDataConverter.ConvertToInt(Session_CS.foundation_id.ToString());
        DataTable dt = Employee_Groups_DB.SelectAll(found_id);
        gvMain.DataSource = dt;
        gvMain.DataBind();

    }
}
