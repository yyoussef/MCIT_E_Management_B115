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
using System.Net;
using System.Net.Mail;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Globalization;

public partial class UserControls_Evaluation_Dept_Weightl : System.Web.UI.UserControl
{

    private string sql_Connection = Database.ConnectionString;
    General_Helping Obj_General_Helping = new General_Helping();
    //Session_CS Session_CS = new Session_CS();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillddl();
            General_Helping obj = new General_Helping();
            string sql = "SELECT [Main_Item_Id], [Name] FROM [Evaluation_Main_Items]";
            DataTable dt = General_Helping.GetDataTable(sql);
            obj.SmartBindDDL(DdlMain_Item_Name, dt, "Main_Item_Id", "Name", "-- اختر --");
            //fil_smart(); 
            //DdlMain_Item_Name.DataBind();
            //DdlMain_Item_Name.Items.Insert(0, "-- اختر --");
            // Ddl_Sub_Item_Name.Items.Insert(0, "-- اختر --");

        }
    }

    private void fil_smart()
    {
        Smart_Search_depts.sql_Connection = sql_Connection;
        //Smart_Search_depts.Query = "select Dept_ID,Dept_name from Departments";
        string Query = "select Dept_ID,Dept_name from Departments";
        // if (Session_CS.UROL_UROL_ID.ToString() == "3" || Session_CS.group_id.ToString() == "3")
        //     Smart_Search_depts.Query += " where  Dept_ID = " + Session_CS.dept_id.ToString();
        Smart_Search_depts.datatble = General_Helping.GetDataTable(Query);
        Smart_Search_depts.Value_Field = "Dept_ID";
        Smart_Search_depts.Text_Field = "Dept_name";
        Smart_Search_depts.DataBind();
        


    }
    private void fil_smart_category(string Value)
    {
        if (Value != "")
        {
            Smart_search_category.sql_Connection = sql_Connection;
            //Smart_search_category.Query = "SELECT DISTINCT Roles.Rol_Desc,Roles.Rol_ID, Departments.Dept_id FROM      Roles INNER JOIN    EMPLOYEE ON Roles.Rol_ID = EMPLOYEE.category INNER JOIN   Departments ON EMPLOYEE.Dept_Dept_id = Departments.Dept_id WHERE        (Roles.Rol_ID >= 5) AND Departments.Dept_id =" + Value;
            string Query = "SELECT DISTINCT Roles.Rol_Desc,Roles.Rol_ID, Departments.Dept_id FROM      Roles INNER JOIN    EMPLOYEE ON Roles.Rol_ID = EMPLOYEE.category INNER JOIN   Departments ON EMPLOYEE.Dept_Dept_id = Departments.Dept_id WHERE        (Roles.Rol_ID >= 5) AND Departments.Dept_id =" + Value;
            // if (Session_CS.UROL_UROL_ID.ToString() == "3" || Session_CS.group_id.ToString() == "3")
            //     Smart_Search_depts.Query += " where  Dept_ID = " + Session_CS.dept_id.ToString();
            Smart_search_category.datatble = General_Helping.GetDataTable(Query);
            Smart_search_category.Value_Field = "Rol_ID";
            Smart_search_category.Text_Field = "Rol_Desc";

            Smart_search_category.DataBind();
            
        }
    }

    public void Smart_search_category_Selected(string Value)
    {
        if (Value != "")
        {
            string sql_emp = "SELECT Evaluation_Dept_Weight.Weight_Id, Evaluation_Main_Items.Name, Evaluation_Sub_Items.Name AS name1, Evaluation_Dept_Weight.Weight, Evaluation_Dept_Weight.category, Roles.Rol_Desc , Roles.Rol_ID FROM            Evaluation_Dept_Weight INNER JOIN     Evaluation_Main_Items ON Evaluation_Dept_Weight.Main_Item_Id = Evaluation_Main_Items.Main_Item_Id INNER JOIN   Evaluation_Sub_Items ON Evaluation_Dept_Weight.Sub_Item_Id = Evaluation_Sub_Items.Sub_Item_Id INNER JOIN   Roles ON Evaluation_Dept_Weight.category = Roles.Rol_ID WHERE Evaluation_Dept_Weight.Dept_id =" + Smart_Search_depts.SelectedValue + " AND Evaluation_Dept_Weight.category =" + Smart_search_category.SelectedValue;
            sql_emp += " ORDER BY (Evaluation_Dept_Weight.Main_Item_Id)";

            txt_Total_Weight.Text = "";
            DataTable eval_dept = General_Helping.GetDataTable(sql_emp);
            GridView1.DataSource = eval_dept;
            GridView1.DataBind();
           Calc_Weigth_Total();
        }
    }
    void Calc_Weigth_Total()
    {

        decimal Total_Weight = 0;
        DataTable dt = Evaluation_Dept_Weight_DB.Evaluation_Dept_Weight_sum(CDataConverter.ConvertToInt(Smart_Search_depts.SelectedValue),CDataConverter.ConvertToInt(Smart_search_category.SelectedValue));


        if (dt.Rows.Count > 0)
        {
            Total_Weight = CDataConverter.ConvertToDecimal(dt.Rows[0]["weight"].ToString());
            txt_Total_Weight.Text = Total_Weight.ToString();
        }
    }

    protected override void OnInit(EventArgs e)
    {
        fil_smart();
        this.Smart_Search_depts.Value_Handler += new Smart_Search.Delegate_Selected_Value(fil_smart_category);
        this.Smart_search_category.Value_Handler += new Smart_Search.Delegate_Selected_Value(Smart_search_category_Selected);
        
        //string dept = Smart_Search_depts.SelectedValue;
        //fil_smart_category(dept);

    }


    public bool check_weight()
    {
        decimal weight = 0;
        decimal tot_wight = 0;
        DataTable dt = Evaluation_Dept_Weight_DB.Evaluation_Dept_Weight_sum(CDataConverter.ConvertToInt(Smart_Search_depts.SelectedValue), CDataConverter.ConvertToInt(Smart_search_category.SelectedValue));

        if (dt.Rows.Count > 0)
        {
            weight = CDataConverter.ConvertToDecimal(dt.Rows[0]["weight"].ToString());
        }

        tot_wight = weight + CDataConverter.ConvertToDecimal(Txtwight.Text);


        if (tot_wight <= 100 && hidden_id.Value == "")
        {
            return true;
        }
        else if ((weight - CDataConverter.ConvertToDecimal(Lbl_weight.Text)) + CDataConverter.ConvertToDecimal(Txtwight.Text) <= 100 && hidden_id.Value != "")
        {
            return true;
        }

        else
        {
            //Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('إجمالي أوزان عناصر تقييم الاداء يجب الا يتجاوز 100')</script>");
            return false;

        }



    }

    protected void Btnsave_Click(object sender, EventArgs e)
    {

        DataTable dteval_checkexist = Evaluation_Dept_Weight_DB.EvaluationDeptWeight_checkExist(CDataConverter.ConvertToInt(Smart_Search_depts.SelectedValue), CDataConverter.ConvertToInt(DdlMain_Item_Name.SelectedValue), CDataConverter.ConvertToInt(Ddl_Sub_Item_Name.SelectedValue), CDataConverter.ConvertToInt(Smart_search_category.SelectedValue));


        
        //////////////////////////////////////////////////////////////

        Evaluation_Dept_Weight_DT obj = new Evaluation_Dept_Weight_DT();

        if(DdlMain_Item_Name.SelectedValue!="0"&& Ddl_Sub_Item_Name.SelectedValue!=""&&Ddl_Sub_Item_Name.SelectedValue!="0"  )
        {
            if( check_weight())
            {

          obj.Main_Item_Id = CDataConverter.ConvertToInt(DdlMain_Item_Name.SelectedValue);
          obj.Sub_Item_Id = CDataConverter.ConvertToInt(Ddl_Sub_Item_Name.SelectedValue);
          obj.category = CDataConverter.ConvertToInt(Smart_search_category.SelectedValue);
          obj.Dept_id = CDataConverter.ConvertToInt(Smart_Search_depts.SelectedValue.ToString());
          obj.Weight = CDataConverter.ConvertToDecimal(Txtwight.Text);
          obj.Weight_Id = CDataConverter.ConvertToInt(hidden_id.Value);
            if(dteval_checkexist.Rows.Count > 0 && hidden_id.Value == "" )
            {
                Page.RegisterStartupScript("Sucess", "<script language=javascript>alert(' هذا العنصر تمت إضافته من قبل ')</script>");
                return;
            }
            else 
            {
                obj.Weight_Id = Evaluation_Dept_Weight_DB.Save(obj);
                Page.RegisterStartupScript("Sucess", "<script language=javascript>alert(' تم الحفظ بنجاح')</script>");

            }

            Smart_search_category_Selected(Smart_Search_depts.SelectedValue);

          hidden_id.Value=
          Txtwight.Text="";
          clear();
            }
            else
            {
                Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('إجمالي أوزان عناصر تقييم الاداء يجب الا يتجاوز 100')</script>");

            }

        }

        else 
        {
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert(' يجب إختيار العنصر الرئيسي والفرعي ')</script>");

        }


        //obj.Dept_id = CDataConverter.ConvertToInt(Smart_Search_depts.SelectedValue.ToString());
        //if (obj.Dept_id == 0)
        //{
        //    ShowAlertMessage("يجب إختيار الإدارة");
        //}
        //else
        //{
        //    obj.Weight = CDataConverter.ConvertToDecimal(Txtwight.Text);
        //    if (obj.Weight != 0 && tot_wight> 100 )
        //    {
        //        ShowAlertMessage(" إجمالي أوزان العناصر  يجب الا يتجاوز 100");
        //    }
        //    else
        //    {
                //obj.Main_Item_Id = CDataConverter.ConvertToInt(DdlMain_Item_Name.SelectedValue);
                //obj.Sub_Item_Id = CDataConverter.ConvertToInt(Ddl_Sub_Item_Name.SelectedValue);
                //obj.category = CDataConverter.ConvertToInt(Smart_search_category.SelectedValue);
                //if (hidden_id.Value == "0"  )
                //{
                //    int x = Evaluation_Dept_Weight_DB.Save(obj);

                //    ShowAlertMessage("تم الحفظ بنجاح");

                //    Txtwight.Text = "";
                //}
                //else
                //{
                //    obj.Weight_Id = CDataConverter.ConvertToInt(hidden_id.Value);
                //    int x = Evaluation_Dept_Weight_DB.Save(obj);

                //    ShowAlertMessage("تم الحفظ بنجاح");
                //    hidden_id.Value = "0";

                //    Txtwight.Text = "";
                //}
             


         }

    public void clear()
    {
        hidden_id.Value =
  
        Txtwight.Text = "";

    }

       

    


    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditItem")
        {

            Fill_Controll(CDataConverter.ConvertToInt(e.CommandArgument));


        }
        if (e.CommandName == "RemoveItem")
        {
            Evaluation_Dept_Weight_DB.Delete(CDataConverter.ConvertToInt(e.CommandArgument));

            Smart_search_category_Selected(Smart_Search_depts.SelectedValue);
            Calc_Weigth_Total();
            ShowAlertMessage("تم الحذف بنجاح");
        }
    }

    private void Fill_Controll(int ID)
    {
        Evaluation_Dept_Weight_DT obj = Evaluation_Dept_Weight_DB.SelectByID(ID);
        hidden_id.Value = obj.Weight_Id.ToString();
        DdlMain_Item_Name.SelectedValue = obj.Main_Item_Id.ToString();
        Ddl_Sub_Item_Name.DataBind();

        fill_subitem();
        Ddl_Sub_Item_Name.SelectedValue = obj.Sub_Item_Id.ToString();

        Txtwight.Text = obj.Weight.ToString();

        Lbl_weight.Text = obj.Weight.ToString(); 


    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
    }
    public static void ShowAlertMessage(string error)
    {

        Page page = HttpContext.Current.Handler as Page;
        if (page != null)
        {
            error = error.Replace("'", "\'");
            ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('" + error + "');", true);
        }
    }



    protected void DdlMain_Item_Name_SelectedIndexChanged(object sender, EventArgs e)
    {
        fill_subitem();
    }

    public void  fill_subitem()
    {
        if (CDataConverter.ConvertToInt(DdlMain_Item_Name.SelectedValue) > 0)
        {
            Ddl_Sub_Item_Name.Items.Clear();
            General_Helping obj = new General_Helping();
            string sql = "SELECT [Sub_Item_Id], [Name] FROM [Evaluation_Sub_Items] WHERE [Main_Item_Id] = " + DdlMain_Item_Name.SelectedValue;
            DataTable dt = General_Helping.GetDataTable(sql);
            obj.SmartBindDDL(Ddl_Sub_Item_Name, dt, "Sub_Item_Id", "Name", "-- اختر --");
        }
    }

    protected void Ddl_Sub_Item_Name_SelectedIndexChanged(object sender, EventArgs e)
    {

        Evaluation_Dept_Weight_DT obj = Evaluation_Dept_Weight_DB.otherSelectByID(CDataConverter.ConvertToInt(Ddl_Sub_Item_Name.SelectedValue), CDataConverter.ConvertToInt(DdlMain_Item_Name.SelectedValue), CDataConverter.ConvertToInt(Smart_Search_depts.SelectedValue), CDataConverter.ConvertToInt(Smart_search_category.SelectedValue));

        if (obj != null && obj.Weight_Id != 0)
        {
            hidden_id.Value = obj.Weight_Id.ToString();
            Txtwight.Text = obj.Weight.ToString();
        }
        else
        {
            hidden_id.Value =
            Txtwight.Text = "";
        }
    }


    protected void ddl_sectors_SelectedIndexChanged(object sender, EventArgs e)
    {

     

        fill_depts();
     


    }

    protected void fill_depts()
    {
        Smart_Search_depts.sql_Connection = sql_Connection;
        //Smart_Search_depts.Query = "select Dept_ID,Dept_name from Departments where sec_sec_id='" + ddl_sectors.SelectedValue + "' ";
        string Query = "select Dept_ID,Dept_name from Departments where sec_sec_id='" + ddl_sectors.SelectedValue + "' ";
        Smart_Search_depts.datatble = General_Helping.GetDataTable(Query);
        Smart_Search_depts.Value_Field = "Dept_ID";
        Smart_Search_depts.Text_Field = "Dept_name";
        Smart_Search_depts.Orderby = "ORDER BY LTRIM(Dept_name)";
        Smart_Search_depts.DataBind();
       


    }

    protected void fillddl()
    {
        string Sql = "select Sec_id,Sec_name from Sectors";
        DataTable dt = General_Helping.GetDataTable(Sql);
        Obj_General_Helping.SmartBindDDL(ddl_sectors, dt, "Sec_id", "Sec_name", "اختر القطاع");

       


    }

}
