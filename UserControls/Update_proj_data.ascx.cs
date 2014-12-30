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

public partial class UserControls_Update_proj_data : System.Web.UI.UserControl
{
    string sql;
    SqlConnection conn;
    SqlDataAdapter da;
    DataSet ds;
    SqlCommand cmd;
    private string sql_Connection = Database.ConnectionString;
    General_Helping Obj_General_Helping = new General_Helping();
    //Session_CS Session_CS = new Session_CS();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            Smart_Search_depts.Show_OrgTree = true;
            fill_structure();
            string sql = "select * from Proj_status ";
            ds = new DataSet();
            da = new SqlDataAdapter(sql, sql_Connection);
            da.Fill(ds, "status");
            ddl_status.DataSource = ds.Tables[0];
            ddl_status.DataValueField = "id";
            ddl_status.DataTextField = "status";
            ddl_status.DataBind();
            ddl_status.Items.Insert(0, new ListItem("اختر الحالة......", "0"));

            btn_Update.Text = "تعديل";
        }
    }
    protected void fill_structure()
    {

        string Query = "";
        Query = "SELECT  * from    Departments  where foundation_id='" + Session_CS.foundation_id + "'";

        Smart_Search_depts.datatble = General_Helping.GetDataTable(Query);
        Smart_Search_depts.Value_Field = "Dept_id";
        Smart_Search_depts.Text_Field = "Dept_name";
        Smart_Search_depts.DataBind();


    }
    protected override void OnInit(EventArgs e)
    {

        string Query = "";
        Smart_Search_manager.sql_Connection = sql_Connection;
       // Smart_Search_manager.Query = "select pmp_id,pmp_name from employee";
         Query = "select pmp_id,pmp_name from employee";
         Smart_Search_manager.datatble = General_Helping.GetDataTable(Query);
        Smart_Search_manager.Value_Field = "pmp_id";
        Smart_Search_manager.Text_Field = "pmp_name";
        Smart_Search_manager.DataBind();

      //  Smart_Search_depts.sql_Connection = sql_Connection;
      ////  Smart_Search_depts.Query = "select Dept_ID,Dept_name from Departments";
      //  Query = "select Dept_ID,Dept_name from Departments";
      //  Smart_Search_depts.datatble = General_Helping.GetDataTable(Query);
      //  Smart_Search_depts.Value_Field = "Dept_ID";
      //  Smart_Search_depts.Text_Field = "Dept_name";
      //  Smart_Search_depts.DataBind();

        
            Smart_Search_Proj.sql_Connection = sql_Connection;
        //    Smart_Search_Proj.Query = "SELECT Proj_id, Proj_Title FROM Project ";
            Query = "SELECT Proj_id, Proj_Title FROM Project ";
            Smart_Search_Proj.datatble = General_Helping.GetDataTable(Query);
            Smart_Search_Proj.Value_Field = "Proj_id";
            Smart_Search_Proj.Text_Field = "Proj_Title";
            Smart_Search_Proj.DataBind();
            this.Smart_Search_Proj.Value_Handler += new Smart_Search.Delegate_Selected_Value(MOnMember_Data);
            base.OnInit(e);

            //this.Smart_Search_depts.Value_Handler += new Smart_Search.Delegate_Selected_Value(MOnMember_Data_Depart);
            //Smart_Search_depts.sql_Connection = sql_Connection;

    }
    private void MOnMember_Data(string Value)
    {
        dropproj_fun();
    }
    protected void dropproj_fun()
    {
        if (Smart_Search_Proj.SelectedValue != "")
        {
            DataTable dt = General_Helping.GetDataTable(" select * from Project where proj_id = " + Smart_Search_Proj.SelectedValue);
            txt_proj_name.Text = dt.Rows[0]["Proj_Title"].ToString();
            txt_date.Text = dt.Rows[0]["Proj_Creation_Date"].ToString();
            txt_Brief.Text = dt.Rows[0]["Proj_Brief"].ToString();
            ddl_status.SelectedValue = dt.Rows[0]["proj_is_commit"].ToString();
            Smart_Search_depts.SelectedValue = dt.Rows[0]["Dept_Dept_id"].ToString();
            Smart_Search_manager.SelectedValue = dt.Rows[0]["pmp_pmp_id"].ToString();
        }
        else 
        {
            clear();
        }
    }

   public void clear()
    {
        txt_proj_name.Text = "";
        txt_date.Text = "";
        txt_Brief.Text = "";
        Smart_Search_depts.Clear_Selected();
        Smart_Search_manager.Clear_Selected();
        
   }
    protected void btn_Update_Click(object sender, EventArgs e)
    {
        if (hidtype.Value == "0")
        {
            if (Smart_Search_Proj.SelectedValue != "")
            {
                sql = " update Project set Proj_Title =  '" + txt_proj_name.Text + "'";
                sql += " , Proj_Creation_Date = '" + txt_date.Text + "'";
                sql += " , Proj_Brief = '" + txt_Brief.Text + "'";
                sql += " , Dept_Dept_id = '" + Smart_Search_depts.SelectedValue + "'";
                sql += " , pmp_pmp_id = '" + Smart_Search_manager.SelectedValue + "'";
                sql += " , proj_is_commit = " + CDataConverter.ConvertToInt( ddl_status.SelectedValue );

                sql += " where proj_id = '" + Smart_Search_Proj.SelectedValue + "'";
                int success = General_Helping.ExcuteQuery(sql);
                if (success == 0)
                {
                    Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('تم التعديل بنجاح')</script>");
                    Smart_Search_Proj.Clear_Selected();
                    clear();
                }
                else
                {
                    Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لم يتم الحفظ')</script>");
                    Smart_Search_Proj.Clear_Selected();
                    clear();
                    return;
                }
            }
            else
            {
                Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('يجب إختيار مشروع')</script>");
                return;
            }
            ddl_status.ClearSelection();
        }
        else if (hidtype.Value == "1")
        {
            sql = " insert into Project (Proj_Title, Proj_Creation_Date, Proj_Brief, Dept_Dept_id, pmp_pmp_id,Proj_is_commit ) Values('" + txt_proj_name.Text + "'";
            sql += ",'" + txt_date.Text + "'";
            sql += ",'" + txt_Brief.Text + "'";
            sql += ",'" + Smart_Search_depts.SelectedValue + "'";
            sql += ",'" + Smart_Search_manager.SelectedValue+"'";
            sql += ",'" + 2 + "')";
            int success = General_Helping.ExcuteQuery(sql);
            if (success == 0)
            {
                Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('تم ادخال بيانات المشروع بنجاح')</script>");
                clear();
                hidtype.Value = "0";
                tr1.Visible = true;
            }
            else
            {
                Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لم يتم الحفظ')</script>");
                clear();
                return;
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        tr1.Visible = false;
       // Smart_Search_Proj.Visible = false;
        clear();
        btn_Update.Text = "حفظ";
        hidtype.Value = "1";
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (Smart_Search_Proj.SelectedValue != "")
        {
            sql = " delete from Project ";
            sql += " where proj_id = '" + Smart_Search_Proj.SelectedValue + "'";
            int success = General_Helping.ExcuteQuery(sql);
            if (success == 0)
            {
                Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('تم الحذف بنجاح')</script>");
                Smart_Search_Proj.Clear_Selected();
                clear();
            }
            else
            {
                Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لم يتم الحذف')</script>");
                Smart_Search_Proj.Clear_Selected();
                clear();
                return;
            }
        }
        else
        {
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('يجب إختيار مشروع أولا')</script>");
            return;
        }
    }
}
