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

public partial class WebForms2_Vocations_Confirm : System.Web.UI.Page
{
    //Session_CS Session_CS = new Session_CS();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        { Fillgrid(); }

    }

    private void Fillgrid()
    {

        string sql_vocations = "SELECT  dbo.EMPLOYEE.PMP_ID, pmp_name, dbo.EMPLOYEE.Dept_Dept_id, dbo.Vacations.vacation_days, dbo.Vacations.vacation_title,dbo.Vacations_users.id,";
        sql_vocations += " dbo.Vacations_users.request_user_id, dbo.Vacations_users.general_manager_approve, dbo.Vacations_users.manager_approve, dbo.Vacations_users.user_id,";
        sql_vocations += "  dbo.Vacations_users.start_date, dbo.Vacations_users.end_date, dbo.Vacations_users.alternative_user_id, dbo.Vacations.id, dbo.EMPLOYEE.rol_rol_id,  dbo.Departments.Dept_name";
        sql_vocations += " FROM  dbo.Vacations INNER JOIN";
        sql_vocations += "  dbo.Vacations_users ON dbo.Vacations.id = dbo.Vacations_users.vacation_id INNER JOIN";
        sql_vocations += " dbo.EMPLOYEE ON dbo.Vacations_users.user_id = dbo.EMPLOYEE.PMP_ID INNER JOIN";
        sql_vocations += " dbo.Departments ON dbo.EMPLOYEE.Dept_Dept_id = dbo.Departments.Dept_ID";
        sql_vocations += " WHERE  (dbo.Vacations_users.manager_approve = 1)";
        DataTable dt_voc = General_Helping.GetDataTable(sql_vocations);
        GVrequests.DataSource = dt_voc;
        GVrequests.DataBind();

     }
    
    
    
    
    protected void GVrequests_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //CheckBox CheckBox1 = (CheckBox)e.Row.FindControl("CheckBox1");

        //CheckBox CheckBox2 = (CheckBox)e.Row.FindControl("CheckBox2");
        
        //CType(gvMain.Rows(i).FindControl("CheckBox1"), CheckBox).Checked = True 
    //    if (e.CommandArgument =1)

    //         For Each row As GridViewRow In gvMain.Rows
    }
    protected void approved_Click(object sender, EventArgs e)
    {
       // int rowsAffected=0;
        foreach (GridViewRow row in GVrequests.Rows)
        {
            CheckBox CheckBox1 = (CheckBox)row.FindControl("CheckBox1");
            CheckBox CheckBox2 = (CheckBox)row.FindControl("CheckBox2");
            HtmlInputHidden Voc_id = (HtmlInputHidden)row.FindControl("Voc_id");
            HtmlInputHidden VocR_id = (HtmlInputHidden)row.FindControl("VocR_id");

            if (CheckBox1.Checked == true )
            {
                 General_Helping.ExcuteQuery("update  dbo.Vacations_users  set dbo.Vacations_users.general_manager_approve= 1 where  Vacations_users.id=" + Voc_id.Value.ToString());
                 lblerror.Visible = true;
                 lblerror.Text = "تم الحفظ بنجاح";
            }
            if (CheckBox2.Checked == true )
            {
                 General_Helping.ExcuteQuery("update  dbo.Vacations_users  set dbo.Vacations_users.general_manager_approve= 2 where  Vacations_users.id=" + VocR_id.Value.ToString());
                 lblerror.Visible = true;
                 lblerror.Text = "تم الحفظ بنجاح";
            }
           

        }
    }
}
