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
using System.Data.SqlClient;

public partial class WebForms_Deprt_Documnts_Search : System.Web.UI.Page
{
    Session_CS Session_CS = new Session_CS();
    private string sql_Connection = Database.ConnectionString;
    General_Helping Obj_General_Helping = new General_Helping();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            Fil_Dll();
    }

    private void Fil_Dll()
    {
        DataTable DT = new DataTable();
        DT = General_Helping.GetDataTable("select * from Departments");
        Obj_General_Helping.SmartBindDDL(ddl_Dept_ID, DT, "Dept_ID", "Dept_name", "....اختر اسم الإدارة ....");
    }

    protected override void OnInit(EventArgs e)
    {
        #region BROWSER FOR departments

        Smart_Emp_ID.sql_Connection = sql_Connection;
       // Smart_Emp_ID.Query = "SELECT PMP_ID, pmp_name FROM EMPLOYEE ";
        string Query = "SELECT PMP_ID, pmp_name FROM EMPLOYEE ";
        Smart_Emp_ID.datatble = General_Helping.GetDataTable(Query);
        Smart_Emp_ID.Value_Field = "PMP_ID";
        Smart_Emp_ID.Text_Field = "pmp_name";
        Smart_Emp_ID.DataBind();


        #endregion
        base.OnInit(e);
    }

    protected void ddl_Dept_ID_SelectedIndexChanged(object sender, EventArgs e)
    {
        fil_emp();
    }

    private void fil_emp()
    {
        int Dept_ID = CDataConverter.ConvertToInt(ddl_Dept_ID.SelectedValue);
        string sql = " SELECT PMP_ID, pmp_name FROM EMPLOYEE ";
        if (Dept_ID > 0)
            sql += " where Dept_Dept_id = " + Dept_ID;


        Smart_Emp_ID.sql_Connection = sql_Connection;
        Smart_Emp_ID.datatble =General_Helping.GetDataTable(sql);
        Smart_Emp_ID.Value_Field = "PMP_ID";
        Smart_Emp_ID.Text_Field = "pmp_name";
        Smart_Emp_ID.DataBind();
        if (Smart_Emp_ID.Items_Count < 0)
            Smart_Emp_ID.Clear_Controls();
    }

    protected void GrdView_Documents_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditItem")
        {


        }

        if (e.CommandName == "RemoveItem")
        {

        }
    }

    protected void btn_Doc_Click(object sender, EventArgs e)
    {
        DataTable DT = Searc_Record();
        GrdView_Documents.DataSource = DT;
        GrdView_Documents.DataBind();
    }

    private DataTable Searc_Record()
    {
        
        string sql = " SELECT     Departments_Documents.File_ID, Departments_Documents.File_Desc, Departments_Documents.File_name, Departments_Documents.File_data,  " +
                     " Departments_Documents.File_ext, Departments_Documents.File_Type, Departments_Documents.Dept_ID, Departments_Documents.Emp_ID, EMPLOYEE.pmp_name,  " +
                     " Departments.Dept_name FROM         Departments_Documents INNER JOIN " +
                     " Departments ON Departments_Documents.Dept_ID = Departments.Dept_ID INNER JOIN EMPLOYEE ON Departments_Documents.Emp_ID = EMPLOYEE.PMP_ID where 1=1 ";
        if (CDataConverter.ConvertToInt(ddl_Dept_ID.SelectedValue) > 0)
        {
            sql += " AND Departments_Documents.Dept_ID =" + CDataConverter.ConvertToInt(ddl_Dept_ID.SelectedValue);
        }
        if (CDataConverter.ConvertToInt(Smart_Emp_ID.SelectedValue) > 0)
        {
            sql += " AND Departments_Documents.Emp_ID =" + CDataConverter.ConvertToInt(Smart_Emp_ID.SelectedValue);
        }
        if (txt_FileName.Text != "")
        {
            sql += " AND File_name like" + "'%" + txt_FileName.Text + "%'";
        }
        if (txt_File_Desc.Text != "")
        {
            sql += " AND File_Desc like" + "'%" + txt_File_Desc.Text + "%'";
        }
        if (CDataConverter.ConvertToInt(ddl_File_Type.SelectedValue) > 0)
        {
            sql += " AND File_Type =" + CDataConverter.ConvertToInt(ddl_File_Type.SelectedValue);
        }


        DataTable DT = General_Helping.GetDataTable(sql);

        return DT;

    }


    public string Get_Type(object obj)
    {
        string str = obj.ToString();
        if (str == "1")
            return "Word";
        else if (str == "2")
            return "Excel";
        else if (str == "3")
            return "PDF";
        else if (str == "4")
            return "IMAGE";
        else if (str == "5")
            return "PowerPoint";
        else return "";
    }


}
