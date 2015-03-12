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
using DBL;

public partial class WebForms_AdminUserPage : System.Web.UI.Page
{
    private string SqlConnection = Universal.GetConnectionString();
    //Session_CS Session_CS = new Session_CS();
    protected void Page_Load(object sender, EventArgs e)
    {
        lblMessage.Text = "";
        if (!Page.IsPostBack )
        {
            //Response.Write(Session_CS.foundation_id.ToString());
           // Label4.Text = Session_CS.foundation_id.ToString();
            DataTable dt = Admin_Module_DB.SelectAllActiveModule_found(Session_CS.foundation_id);
            DropModule.DataSource = dt;
            DropModule.DataValueField = "pk_ID";
            DropModule.DataTextField = "Name";
            DropModule.DataBind();
            //DropModule.Items.Add(new ListItem("اختر الموديول......", "0"));
            DropModule.Items.Insert(0, new ListItem("اختر الصلاحية......", "0"));


           
        }
    }
    protected override void OnInit(EventArgs e)
    {
        SmartEmployee.sql_Connection = SqlConnection;
        string Query = "select PMP_ID,rol_rol_id,pmp_name from dbo.EMPLOYEE where foundation_id = "+ CDataConverter.ConvertToInt(Session_CS.foundation_id.ToString());
        SmartEmployee.datatble = General_Helping.GetDataTable(Query);
        SmartEmployee.Value_Field = "PMP_ID";
        SmartEmployee.Text_Field = "pmp_name";
        SmartEmployee.DataBind();
        this.SmartEmployee.Value_Handler += new Smart_Search.Delegate_Selected_Value(MOnMember_Data_cop_org);

        //DataTable dt = Admin_Module_DB.SelectAllActiveModule_found(Session_CS.foundation_id);
        //DropModule.DataSource = dt;
        //DropModule.DataValueField = "pk_ID";
        //DropModule.DataTextField = "Name";
        ////DropModule.Items.Add(new ListItem("اختر الموديول......", "0"));
        //DropModule.DataBind();

        lblMessage.Text = "";

    }

    private void GetUserPages()
    {
     
        //string sql = @"SELECT ap.pk_ID, ap.Name page FROM dbo.users_permission up,dbo.Admin_Page ap WHERE ap.pk_ID = up.Page_ID AND ap.Active = 1 AND up.pmp_pmp_id = " + SmartEmployee.SelectedValue;
       // Label4.Text = SmartEmployee.SelectedValue.ToString();
        if (SmartEmployee.SelectedValue != "" && SmartEmployee.SelectedValue != "0")
        {
            DataTable dt = SqlHelper.ExecuteDataset(Database.ConnectionString, "Select_UserPages", SmartEmployee.SelectedValue).Tables[0];
            if (dt.Rows.Count > 0)
            {
                gvUserPages.DataSource = dt;
                gvUserPages.DataBind();
            }
        }



    }
    protected void ImgBtnDelete_Click(object sender, System.Web.UI.ImageClickEventArgs e)
    {

       // string Sql = "delete from users_permission where pmp_pmp_id=" + SmartEmployee.SelectedValue + " and page_id=" + Convert.ToInt32(((ImageButton)sender).CommandArgument);

       // int result = General_Helping.ExcuteQuery(Sql);
        int result= SqlHelper.ExecuteNonQuery(Database.ConnectionString, "users_permissiondelete", SmartEmployee.SelectedValue,Convert.ToInt32(((ImageButton)sender).CommandArgument));


        if (result >= 0)
        {
            lblMessage.Visible = true;
            lblMessage.Text = "تم الحذف بنجاح";
            GetUserPages();
        }
        else
        {
            lblMessage.Visible = true;
            lblMessage.Text = "خطأ في عملية الحذف";
        }

    }

    protected void SaveButton_Click(object sender, EventArgs e)
    {
        try
        {
            int EmpID = CDataConverter.ConvertToInt(SmartEmployee.SelectedValue);
            if (EmpID == 0)
            {
                lblMessage.Text = "من فضلك إختر موظف";
                return;
            }

            CheckBox chkActive;
            Label lblID;
            Label lblInsertedBefore;

            foreach (GridViewRow rowItem in gvMain.Rows)
            {

                chkActive = (CheckBox)(rowItem.FindControl("chkSelected"));
                lblID = (Label)(rowItem.FindControl("lblPageID"));
                lblInsertedBefore = (Label)(rowItem.FindControl("lblInsertedBefore"));

                if (chkActive.Checked && lblInsertedBefore.Text != "1")
                {
                    Users_Permission_DT UserPermissionDT = new Users_Permission_DT();

                    UserPermissionDT.Page_ID = CDataConverter.ConvertToInt(lblID.Text);
                    UserPermissionDT.pmp_pmp_id = CDataConverter.ConvertToInt(SmartEmployee.SelectedValue);

                    Users_Permission_DB.Save(UserPermissionDT);

                }
                else if ((!chkActive.Checked) && lblInsertedBefore.Text == "1")
                {
                    Admin_Athorization_Delete_Employee_Page_SP SP = new Admin_Athorization_Delete_Employee_Page_SP();

                    SP.PageID = CDataConverter.ConvertToInt(lblID.Text);
                    SP.EmployeeID = CDataConverter.ConvertToInt(SmartEmployee.SelectedValue);

                    Admin_Athorization_Delete_Employee_Page_SP.Get_DataTable(SP);
                }
            }

            lblMessage.Text = "تم الحفظ بنجاح";
        }
        catch
        {
            lblMessage.Text = "حدث خطاء أثناء الحفظ";
        }
        fillData();
        MarkPagesAsChecked();
        if (SmartEmployee.SelectedValue!="")
        {
        GetUserPages();
        }
    }

    private void MOnMember_Data_cop_org(string Value)
    {
        if (SmartEmployee.SelectedValue != "" && SmartEmployee.SelectedValue != "0")
        {
            //DataTable dt_found = General_Helping.GetDataTable("select foundation_id from employee where pmp_id=" + SmartEmployee.SelectedValue);

 GetUserPages();
            //fillData();
            //MarkPagesAsChecked();
           
           
            
        }

    }

    protected void DropModule_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillData();
        MarkPagesAsChecked();
    }

    private void fillData()
    {
        Admin_Athorization_Select_Module_Page_SP SP = new Admin_Athorization_Select_Module_Page_SP();

        SP.ModuleID = CDataConverter.ConvertToInt(DropModule.SelectedValue);

        DataTable dt = Admin_Athorization_Select_Module_Page_SP.Get_DataTable(SP);
        gvMain.DataSource = dt;
        gvMain.DataBind();
    }

    private void MarkPagesAsChecked()
    {
        int EmpID = CDataConverter.ConvertToInt(SmartEmployee.SelectedValue);
        if (EmpID != 0)
        {
            CheckBox chkActive;
            Label lblID;
            Label lblInsertedBefore;

            DataTable Pages = Users_Permission_DB.Select_by_pmp_pmp_id(EmpID);

            foreach (DataRow dr in Pages.Rows)
            {
                foreach (GridViewRow rowItem in gvMain.Rows)
                {


                    lblID = (Label)(rowItem.FindControl("lblPageID"));
                    if (CDataConverter.ConvertToInt(lblID.Text) == CDataConverter.ConvertToInt(dr["Page_ID"].ToString()))
                    {
                        chkActive = (CheckBox)(rowItem.FindControl("chkSelected"));
                        lblInsertedBefore = (Label)(rowItem.FindControl("lblInsertedBefore"));
                        chkActive.Checked = true;
                        lblInsertedBefore.Text = "1";
                    }

                }
            }
        }
    }
}
