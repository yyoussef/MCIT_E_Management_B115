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
using System.IO;
using System.Text;

public partial class WebForms_Project : System.Web.UI.Page
{
    Session_CS Session_CS = new Session_CS();
    General_Helping Obj_General_Helping = new General_Helping();
    private string sql_Connection = Database.ConnectionString;


    protected override void OnInit(EventArgs e)
    {
        #region BROWSER FOR departments

        string Query = "SELECT Org_ID, Org_Desc FROM Organization";
        string Value_Field = "Org_ID";
        string Text_Field = "Org_Desc";

        Smart_Org_ID1.sql_Connection = sql_Connection;
        //Smart_Org_ID1.Query = Query;
        Smart_Org_ID1.datatble = General_Helping.GetDataTable(Query);
        Smart_Org_ID1.Value_Field = Value_Field;
        Smart_Org_ID1.Text_Field = Text_Field;
        Smart_Org_ID1.DataBind();

        Smart_Org_ID2.sql_Connection = sql_Connection;
        //Smart_Org_ID2.Query = Query;
        Smart_Org_ID2.datatble = General_Helping.GetDataTable(Query);
        Smart_Org_ID2.Value_Field = Value_Field;
        Smart_Org_ID2.Text_Field = Text_Field;
        Smart_Org_ID2.DataBind();

     //   Smart_Dept_id.sql_Connection = sql_Connection;
     ////   Smart_Dept_id.Query = "select * from Departments ";//where rol_rol_id in( 3,4)";
     //   Query = "select * from Departments ";
     //   Smart_Dept_id.datatble = General_Helping.GetDataTable(Query);
     //   Smart_Dept_id.Value_Field = "Dept_ID";
     //   Smart_Dept_id.Text_Field = "Dept_name";
     //   Smart_Dept_id.DataBind();

        Smart_PMP_ID.sql_Connection = sql_Connection;
        //Smart_PMP_ID.Query = "select * from EMPLOYEE ";//where rol_rol_id in( 3,4)";
        Query = "select * from EMPLOYEE ";
        Smart_PMP_ID.datatble = General_Helping.GetDataTable(Query);
        Smart_PMP_ID.Value_Field = "PMP_ID";
        Smart_PMP_ID.Text_Field = "pmp_name";
        Smart_PMP_ID.DataBind();

        Smart_Project.sql_Connection = sql_Connection;
        //Smart_Project.Query = " SELECT Proj_id, Proj_Title FROM Project ";
        Query = " SELECT Proj_id, Proj_Title FROM Project ";
        Smart_Project.datatble = General_Helping.GetDataTable(Query);
        Smart_Project.Value_Field = "Proj_id";
        Smart_Project.Text_Field = "Proj_Title";
        Smart_Project.DataBind();

        #endregion
        this.Smart_Dept_id.Value_Handler += new Smart_Search.Delegate_Selected_Value(MOnMember_Data_Depart);
        Smart_Dept_id.sql_Connection = sql_Connection;
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Smart_Dept_id.Show_OrgTree = true;
            fill_structure();
        }
    }

    protected void txt_End_Date_Plan_TextChanged(object sender, EventArgs e)
    {

        //string Strt_date = CDataConverter.ConvertDateTimeToFormatdmy (CDataConverter.ConvertToDate(txt_start_date_Plan.Text));
        //string End_date = CDataConverter.ConvertDateTimeToFormatdmy (CDataConverter.ConvertToDate(txt_End_Date_Plan.Text));
        //if (!VB_Classes.Dates.Dates_Operation.Date_compare(Strt_date, End_date))
        //{
        //    if (!string.IsNullOrEmpty(Strt_date) && !string.IsNullOrEmpty(End_date))
        //    {
        //        int Total_Days = DateTime.ParseExact(End_date, "dd/MM/yyyy", null).Subtract(DateTime.ParseExact(Strt_date, "dd/MM/yyyy", null)).Days;
        //        int Year = Total_Days / 360;
        //        txt_Period_by_year.Text = Year.ToString();

        //    }
        //    else
        //    {
        //        Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('أدخل التاريخ يوم/شهر/سنة ')</script>");

        //    }
        //}
        //else
        //{
        //    Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('تاريخ النهاية يجب ان يكون اكبر من تاريخ البداية')</script>");

        //}
    }

    protected void btn_Org2_Click(object sender, EventArgs e)
    {

    }

    protected void btn_Save_Click(object sender, EventArgs e)
    {

        Save_Project();
    }

    private void Save_Project()
    {
        Project_DT obj = Project_DB.SelectByID(CDataConverter.ConvertToInt(Smart_Project.SelectedValue));
        if (obj.Proj_id > 0)
        {
            obj.Proj_Code = txt_Proj_Code.Text;
            obj.Dept_Dept_id = CDataConverter.ConvertToInt(Smart_Dept_id.SelectedValue);
            obj.pmp_pmp_id = CDataConverter.ConvertToInt(Smart_PMP_ID.SelectedValue);
            obj.start_date_Plan = CDataConverter.ConvertDateTimeToFormatdmy (CDataConverter.ConvertToDate(txt_start_date_Plan.Text));
            obj.End_Date_Plan = CDataConverter.ConvertDateTimeToFormatdmy (CDataConverter.ConvertToDate(txt_End_Date_Plan.Text));
            obj.Period_by_year = CDataConverter.ConvertToInt(txt_Period_by_year.Text);
            obj.Region_Desc = txt_Region_Desc.Text;
            obj.Proj_Brief = txt_Proj_Brief.Text;
            obj.Proj_Goal_Stratege = txt_Proj_Goal_Stratege.Text;
            obj.Total_Balance_Value_LE = CDataConverter.ConvertToDecimal(txt_Total_Balance_Value_LE.Text);
            obj.Total_Balance_Value_US = CDataConverter.ConvertToDecimal(txt_Total_Balance_Value_US.Text);
            obj.Return_Value = txt_Return_Value.Text;
            obj.Proj_Notes = txt_Proj_Notes.Text;
            Project_DB.Save(obj);
            ///Sending_MailClass.sendmail(obj.Proj_Brief.ToString(), Session_CS.pmp_name.ToString());

            if (FileUpload1.HasFile)
            {
                string DocName = FileUpload1.FileName;
                int dotindex = DocName.LastIndexOf(".");
                string type = DocName.Substring(dotindex, DocName.Length - dotindex);

                Stream myStream;
                int fileLen;
                StringBuilder displayString = new StringBuilder();
                fileLen = FileUpload1.PostedFile.ContentLength;
                Byte[] Input = new Byte[fileLen];
                myStream = FileUpload1.FileContent;
                myStream.Read(Input, 0, fileLen);
                SqlCommand cmd = new SqlCommand();
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = " update Project set File_data=@File_data ,File_name=@File_name,File_ext=@File_ext where Proj_id =@Proj_id";


                cmd.Parameters.Add("@File_data", SqlDbType.VarBinary);
                cmd.Parameters.Add("@Proj_id", SqlDbType.Int);
                cmd.Parameters.Add("@File_name", SqlDbType.NVarChar);
                cmd.Parameters.Add("@File_ext", SqlDbType.NVarChar);

                cmd.Parameters["@File_data"].Value = Input;
                cmd.Parameters["@Proj_id"].Value = CDataConverter.ConvertToInt(Smart_Project.SelectedValue);
                cmd.Parameters["@File_ext"].Value = type;
                cmd.Parameters["@File_name"].Value = Smart_Project.SelectedText;
                con.Open();
                cmd.ExecuteScalar();
                con.Close();
            }
            Project_Region_DB.Delete_ALL_By_Project_ID(CDataConverter.ConvertToInt(Smart_Project.SelectedValue));
            foreach (ListItem Obj_Item in chk_gov_list.Items)
            {
                if (Obj_Item.Selected)
                {
                    Project_Region_DT obj_Region = new Project_Region_DT();
                    obj_Region.Proj_id = CDataConverter.ConvertToInt(Smart_Project.SelectedValue);
                    obj_Region.Region_ID = CDataConverter.ConvertToInt(Obj_Item.Value);
                    Project_Region_DB.Save(obj_Region);

                }
            }

        }
    }

    protected void fill_structure()
    {

        string Query = "";
        Query = "SELECT  * from    Departments  where foundation_id='" + Session_CS.foundation_id + "'";

        Smart_Dept_id.datatble = General_Helping.GetDataTable(Query);
        Smart_Dept_id.Value_Field = "Dept_id";
        Smart_Dept_id.Text_Field = "Dept_name";
        Smart_Dept_id.DataBind();

      
    }

    protected void fill_emplyees2()
    {
        Smart_PMP_ID.sql_Connection = sql_Connection;

        DataTable dtt = General_Helping.GetDataTable("SELECT     EMPLOYEE.PMP_ID, EMPLOYEE.pmp_name, Departments.sec_sec_id FROM    EMPLOYEE INNER JOIN     Departments ON EMPLOYEE.Dept_Dept_id = Departments.Dept_ID  where Departments.Dept_ID = '" + Smart_Dept_id.SelectedValue + "'");
        Smart_PMP_ID.datatble = dtt;
        Smart_PMP_ID.Value_Field = "PMP_ID";
        Smart_PMP_ID.Text_Field = "pmp_name";
        Smart_PMP_ID.Clear_Controls();
        Smart_PMP_ID.DataBind();





        //Lbl_count.Text = Smart_Emp_ID.Items_Count.ToString();
        //Lbl_count.Visible = true;
        //Label39.Visible = true;



    }
    private void MOnMember_Data_Depart(string Value)
    {



        if (Value != "")
        {

            fill_emplyees2();
        }
        else
        {
            //       if (!chk_allow_Chn_dept.Checked)
            Smart_PMP_ID.Clear_Controls();


        }


    }
}
