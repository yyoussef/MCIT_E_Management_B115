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
using DBL;
public partial class WebForms_Protocol_Project_Search : System.Web.UI.Page
{
    SqlConnection con;
    Session_CS Session_CS = new Session_CS();
    private string sql_Connection = Universal.GetConnectionString(); 
     
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SetValue();
        }
    }
 
    //protected override void OnInit(EventArgs e)
    //{
    //    //string strConString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();

    //    //obj_Sql_Con = new System.Data.SqlClient.SqlConnection(strConString);

    //    //obj_Sql_Con.Open();

    //    ////end//

    //    #region BROWSER FOR departments

    //    Smrt_Srch_DropDep.sql_Connection = sql_Connection;
    //    Smrt_Srch_DropDep.Query = "select Dept_ID,Dept_name from Departments where Dept_ID <> 6";
    //    Smrt_Srch_DropDep.Value_Field = "Dept_ID";
    //    Smrt_Srch_DropDep.Text_Field = "Dept_name";
    //    Smrt_Srch_DropDep.DataBind();
    //    this.Smrt_Srch_DropDep.Value_Handler += new Smart_Search.Delegate_Selected_Value(MOnMember_Data);

    //    //this.obj_Browserdept = new cBrowser(this, "select Dept_ID,Dept_name from Departments", "الإدارات", 5);

    //    //this.obj_Browserdept.MAddField("Dept_name", "اسم الإدارة", 150, BrowserFieldType.NIString);

    //    //this.obj_Browserdept.ID = "obj_Browserdept";

    //    //this.obj_Browserdept.BrowseData += new BrowseDataEventHandler(MOnMember_Data);


    //    ////////////////////////////////////////////////////////////
    //    //ht5dy dh st//


    //    Smrt_Srch_projmanage.sql_Connection = sql_Connection;
    //    Smrt_Srch_projmanage.Query = "select PMP_ID,rol_rol_id,pmp_name from dbo.EMPLOYEE where rol_rol_id=4";
    //    Smrt_Srch_projmanage.Value_Field = "PMP_ID";
    //    Smrt_Srch_projmanage.Text_Field = "pmp_name";
    //    Smrt_Srch_projmanage.DataBind();
    //    this.Smrt_Srch_projmanage.Value_Handler += new Smart_Search.Delegate_Selected_Value(MOnMember_Datamanage);

    //    //this.obj_Browsermanage = new cBrowser(this, "select distinct pmp_pmp_id , PTem_Name from dbo.Project_Team where rol_rol_id=4", "مديرين المشروعات", 5);

    //    //this.obj_Browsermanage.MAddField("PTem_Name", "اسم مدير المشروع", 150, BrowserFieldType.NIString);

    //    //this.obj_Browsermanage.ID = "obj_Browsermanage";

    //    //this.obj_Browsermanage.BrowseData += new BrowseDataEventHandler(MOnMember_Datamanage);

    //    Smart_Search_Proj.sql_Connection = sql_Connection;
    //    Smart_Search_Proj.Query = "select proj_title,proj_id from project ";
    //    Smart_Search_Proj.Value_Field = "proj_id";
    //    Smart_Search_Proj.Text_Field = "proj_title";
    //    Smart_Search_Proj.DataBind();
    //    this.Smart_Search_Proj.Value_Handler += new Smart_Search.Delegate_Selected_Value(MOnMember_Databudget);


    //    this.Smart_Search_main.Value_Handler += new Smart_Search.Delegate_Selected_Value(MOnMember_subactivities);


    //    #endregion


    //    base.OnInit(e);
    //}


    public void SetValue ()
    {
        con = new SqlConnection(sql_Connection);
    SqlDataAdapter da;
    DataSet ds;

    string sql = "select Protocol_Def.Protocol_ID ,Protocol_Def.Name ";
       sql +=" FROM Protocol_Def ";
       sql += " WHERE  (Protocol_Def.Type = 2)";

    
        ds = new DataSet();
        da = new SqlDataAdapter(sql, con);
        da.Fill(ds , "Protocol_Def");
        drop_agrement.DataSource = ds.Tables[0]  ;
        drop_agrement.DataValueField ="Protocol_ID";
        drop_agrement.DataTextField = "Name";
        drop_agrement.DataBind();
        drop_agrement.Items.Insert(0,new ListItem("....اختر الاتفاقية...","0"));
    }
    //////////
    public void SearchRecord()
    {
        string sql;
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        {
          
            ////////////////////////////////////////////////
            sql =" SELECT DISTINCT dbo.Project.Proj_id, dbo.Project_Period_Sources.Value, dbo.Project.Proj_Title, dbo.Protocol_Def.Protocol_ID, dbo.EMPLOYEE.PMP_ID, dbo.EMPLOYEE.pmp_name";
            sql +=" ,dbo.Departments.Dept_name ";
            sql +=" FROM dbo.Departments INNER JOIN dbo.EMPLOYEE ON dbo.Departments.Dept_ID = dbo.EMPLOYEE.Dept_Dept_id INNER JOIN dbo.Protocol_Def INNER JOIN";
            sql +=" dbo.Project INNER JOIN dbo.Project_Period_Sources INNER JOIN dbo.Project_Period_Balance ON dbo.Project_Period_Sources.Period_ID = dbo.Project_Period_Balance.Period_ID ON"; 
            sql +=" dbo.Project.Proj_id = dbo.Project_Period_Balance.Proj_id ON dbo.Protocol_Def.Protocol_ID = dbo.Project_Period_Sources.Provider_ID ON ";
            sql += " dbo.EMPLOYEE.PMP_ID = dbo.Project.pmp_pmp_id WHERE (dbo.Project.Proj_is_commit = 2) AND (dbo.Protocol_Def.Type = 2)";

            if (drop_agrement.SelectedValue != "0")
            {
                sql += "  AND dbo.Protocol_Def.Protocol_ID = " + drop_agrement.SelectedValue;
            }
            else sql += sql;
            
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count == 0)
            {
                gvMain.EmptyDataText = ".....عفوا لا يوجد بيانات ......";
            }
            else
            {
                gvMain.DataSource = dt;
            }
            gvMain.DataBind();
            conn.Close();
            
        }
    }
                      
    protected void gvMain_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditItem")
        {
        //    Response.Redirect("../webforms/Protocol_Def.aspx?prot_id=" + e.CommandArgument);
        //}
        //if (e.CommandName == "RemoveItem")
        //{
        //    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        //    conn.Open();

        //    sql += "delete from Protocol_Def where Protocol_ID= " + e.CommandArgument;
        //    cmd = new SqlCommand(sql, conn);
        //    cmd.ExecuteNonQuery();
        //    conn.Close();

        //    gvMain.DataBind();

        //    Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم الحذف بنجاح')</script>");
        //    SearchRecord();
        }

    }
    protected void gvMain_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvMain.PageIndex = e.NewPageIndex;
        SearchRecord();
    }
    protected void SaveButton_Click(object sender, EventArgs e)
    {
        SearchRecord();
    }
}
