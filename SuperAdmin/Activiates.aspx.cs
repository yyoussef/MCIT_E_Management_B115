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

public partial class Superadmin_Activiates : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Fill_Module();
            //Fill_sector();
        }
    }
    private void Fill_Module()
    {
        string sql = "select * from Admin_Module";
        DataTable dt = General_Helping.GetDataTable(sql);
        ddl_Groups.DataSource = dt;
        ddl_Groups.DataValueField = "pk_ID";
        ddl_Groups.DataTextField = "Name";
        ddl_Groups.DataBind();
        //ddl_Groups.Items.Insert(0, new ListItem("اختر المجموعة......", "0"));
    }
    //private void Fill_sector()
    //{
    //    string sql = "select * from sectors";
    //    DataTable dt = General_Helping.GetDataTable(sql);
    //    ddl_Sectors.DataSource = dt;
    //    ddl_Sectors.DataValueField = "Sec_id";
    //    ddl_Sectors.DataTextField = "Sec_name";
    //    ddl_Sectors.DataBind();
    //    ddl_Sectors.Items.Insert(0, new ListItem("اختر القطاع......", "0"));
    //}
    protected void ddl_Groups_SelectedIndexChanged(object sender, EventArgs e)
    {
        string sql = "select * from Admin_page ";
        DataTable dt = General_Helping.GetDataTable(sql);
        cbl_Employees.DataSource = dt;
        cbl_Employees.DataValueField = "pk_ID";
        cbl_Employees.DataTextField = "Name";
        //cbl_Employees.DataMember = "group_id";
        cbl_Employees.DataBind();

        if ( ddl_Groups.SelectedValue != "0")
        {
            //string sql_compare = "select * from Admin_ModulePage where fk_ModuleID= " + ddl_Groups.SelectedValue + "";
            //DataTable dt_compare = General_Helping.GetDataTable(sql_compare);

            DataTable dt_compare = new DataTable();
            dt_compare = Admin_ModulePage_DB.SelectAll(Convert.ToInt16(ddl_Groups.SelectedValue));
            foreach (DataRow row_compare in dt_compare.Rows)
            {
                string Value = row_compare["fk_PageID"].ToString();
                foreach (DataRow row in dt.Rows)
                {
                    if (row["pk_ID"].ToString() == Value)
                    {
                        ListItem item = cbl_Employees.Items.FindByValue(Value);
                        if (item != null)
                            item.Selected = true;
                    }
                }

            }
        }

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Admin_ModulePage_DT activate = new Admin_ModulePage_DT();
        Admin_ModulePage_DB.Delete(Convert.ToInt16(ddl_Groups.SelectedValue));
           //string sql = ""; 
           //string sqll = ""; 
           // //sqll = "delete From Admin_ModulePage Where fk_ModuleID= " + ddl_Groups.SelectedValue + " ";
           // General_Helping.ExcuteQuery(sqll);
            
            //foreach (ListItem item in cbl_Employees.Items)
            //{
            //    //if (item.Selected)
            //    //{
            //    //    sql = "update Admin_ModulePage set  fk_PageID= null where fk_ModuleID=" + ddl_Groups.SelectedValue + " ";
            //    //    General_Helping.ExcuteQuery(sql);
            //    //}
            //}
            foreach (ListItem item in cbl_Employees.Items)
            {
                if (item.Selected)
                {
                    activate.fk_PageID = Convert.ToInt32(item.Value);
                    activate.fk_ModuleID =  Convert.ToInt16(ddl_Groups.SelectedValue);
                    int success=Admin_ModulePage_DB.Save(activate);

                    //sql = "INSERT INTO  [Admin_ModulePage] ([fk_PageID ] ,[fk_ModuleID])values (" + Convert.ToInt32(item.Value) + " , " + ddl_Groups.SelectedValue + ")";

                    //General_Helping.ExcuteQuery(sql);
                }


               
            }
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('تم الحفظ بنجاح')</script>");
     //string sqll = "";
     ////foreach (ListItem item in cbl_Employees.Items)
     ////{

     ////    sql = "update Admin_ModulePage set fk_PageID= null where  fk_ModuleID= " + ddl_Groups.SelectedValue + " = item.Value";
     ////    General_Helping.ExcuteQuery(sql);
         
     ////}
     //foreach (ListItem item in cbl_Employees.Items)
     //{
     //    if (item.Selected)
     //    {
     //          ;
     //        General_Helping.ExcuteQuery(sql);
     //    }
     }
    protected void cbl_Employees_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}

        
  
