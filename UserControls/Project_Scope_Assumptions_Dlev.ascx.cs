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


public partial class UserControls_Project_Scope_Assumptions_Dlev : System.Web.UI.UserControl
{
    string sql_Connection = Universal.GetConnectionString();

    int i;

    private int mType;
    //Session_CS Session_CS = new Session_CS();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            i = 1;
            if (mType == 1)
            {
                Lblassump.Visible = true;
                //Page.Title = "الإفتراضات";


            }
            else if (mType == 2)
            {
                Lblscope.Visible = true;
                //Page.Title = "النطاق";


            }
            else
            {
                Lbldeliv.Visible = true;
               // Page.Title = "المخرجات";

            }
            FillGrid();
            //Fill_Controll(CDataConverter.ConvertToInt(Request["id"]));
        }

    }

    private void FillGrid()
    {
        string sql = "select * from Psc_dl_asump where 1=1 and proj_proj_id = " + CDataConverter.ConvertToInt(Session_CS.Project_id.ToString());
        if (mType == 1)
        {
            sql += " AND Type = 1";
        }
        else if (mType == 2)
        {
            sql += " AND Type = 2 ";
        }
        else
        {
            sql += " AND Type = 3 ";
        }



        gvMain.DataSource = General_Helping.GetDataTable(sql); ;
        gvMain.DataBind();
    }

    public void AddNewRecord()
    {
        if (name.Text != "")
        {
            if (hidden_flag.Value == "1")
            {
                //string sql = "update Psc_dl_asump set Psc_dl_asump_Desc = " + name.Text + " where Psc_dl_asump_id =" + hidden_Id.Value;
                General_Helping.ExcuteQuery("update Psc_dl_asump set Psc_dl_asump_Desc = '" + name.Text + "' where Psc_dl_asump_id =" + hidden_Id.Value);
                Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم التعديل بنجاح')</script>");
                SaveButton.Text = "حفظ";
                FillGrid();
            }
            else
            {
                Project_Assumptions_DT obj = new Project_Assumptions_DT();
                obj.Psc_dl_asump_id = CDataConverter.ConvertToInt(hidden_Id.Value);
                obj.proj_proj_id = CDataConverter.ConvertToInt(Session_CS.Project_id.ToString());
                obj.Psc_dl_asump_Desc = name.Text;
                obj.Type = mType;
                obj.Psc_dl_asump_id = Project_Assumptions_DB.Save(obj);
                hidden_Id.Value = obj.Psc_dl_asump_id.ToString();
                if (obj.Psc_dl_asump_id > 0)
                    Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم الحفظ بنجاح')</script>");
                else
                    Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لم يتم الحفظ يرجى التأكد من البيانات ')</script>");
            }
        }
        else
        {
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لم يتم الحفظ يرجى التأكد من البيانات ')</script>");
            return;
        }

        hidden_Id.Value = "";
        name.Text = "";
        FillGrid();
    }

    private void DisplayFileContents()
    {

    }

    //private void Fill_Controll(int Psc_dl_asump_id)
    //{
    //    try
    //    {
    //        Project_Assumptions_DT obj = Project_Assumptions_DB.SelectByID(Psc_dl_asump_id);
    //        hidden_Id.Value = obj.Psc_dl_asump_id.ToString();
    //        hidden_Proj_id.Value = obj.proj_proj_id.ToString();
    //        name.Text = obj.Psc_dl_asump_Desc;
    //        //Request["Type"] = obj.Type;
    //        hidden_type.Value = obj.Type.ToString();

    //    }
    //    catch
    //    { }
    //}

    protected void SaveButton_Click(object sender, EventArgs e)
    {

        AddNewRecord();


    }

    private void UpdateExistRecord()
    {


    }

    protected void GrdView_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "EditItem")
        {

            DataTable DT = new DataTable();
            DT = General_Helping.GetDataTable("select *  from Psc_dl_asump where Psc_dl_asump_id = " + e.CommandArgument);
            if (DT.Rows.Count > 0)
            {
                name.Text = DT.Rows[0]["Psc_dl_asump_Desc"].ToString();
                hidden_Id.Value = e.CommandArgument.ToString();
            }
            SaveButton.Text = "تعديل";
            hidden_flag.Value = "1";
        }
        else if (e.CommandName == "RemoveItem")
        {
            General_Helping.ExcuteQuery("delete from Psc_dl_asump where Psc_dl_asump_id = " + e.CommandArgument);
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم الحذف بنجاح')</script>");
            FillGrid();
        }

    }

    protected void ImgBtnDelete_Click(object sender, ImageClickEventArgs e)
    {

    }

    public int Type    // the Type property
    {
        get
        {
            return mType;
        }
        set
        {
            mType = value;
        }
    }
}

