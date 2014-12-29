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

public partial class WebForms_Project_presentation : System.Web.UI.Page
{
    Session_CS Session_CS = new Session_CS();
    string sql_Connection = Universal.GetConnectionString();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request["id"] != null && Request["id"] != "")
            {
                SqlDataAdapter sqladptr = new SqlDataAdapter();
                SqlConnection con = new SqlConnection(sql_Connection);
                SqlCommand obj = new SqlCommand("Get_Presentation", con);
                obj.CommandType = CommandType.StoredProcedure;
                //obj.Parameters.Add(new SqlParameter("@ProjID", Session_CS.Project_id.ToString()));
                obj.Parameters.Add(new SqlParameter("@id", Convert.ToInt16(Request["id"])));
                Presentation_ID.Value = Request["id"].ToString();
                con.Open();
                sqladptr.SelectCommand = obj;
                DataTable DT = new DataTable();
                sqladptr.Fill(DT);
                con.Close();
                Presentation_name.Text = DT.Rows[0]["Presentation_name"].ToString();
                Presentation_date.Text = DT.Rows[0]["Presentation_date"].ToString();
                Presentation_location.Text = DT.Rows[0]["Presentation_location"].ToString();
                Notes.Text = DT.Rows[0]["Notes"].ToString();
                mode.Value = "edit";

            }
            FillGrid();
        }
        
    }

    private void FillGrid()
    {
        string sql = "select * from Presentation where 1=1 ";
        if (CDataConverter.ConvertToInt(Session_CS.Project_id.ToString()) > 0)
        {
            sql += " AND ProjID = " + int.Parse(Session_CS.Project_id.ToString());
        }
        else
            sql += " AND ProjID = 0 AND Dept_ID = " + int.Parse(Session_CS.dept_id.ToString());



        gvMain.DataSource = General_Helping.GetDataTable(sql); ;
        gvMain.DataBind();
    }
    public void AddNewRecord()
    {
        bool isDate = false;
        if (Presentation_date.Text != "")

          //  if (VB_Classes.Dates.Dates_Operation.date_validate(Presentation_date.Text) != "")
            isDate = true;

        if (isDate == true && Presentation_date.Text != "" && Presentation_name.Text != "")
        {
            SqlDataAdapter sqladptr = new SqlDataAdapter();
            SqlConnection con = new SqlConnection(sql_Connection);
            SqlCommand obj = new SqlCommand("Add_Edit_Presentation", con);
            obj.CommandType = CommandType.StoredProcedure;
            obj.Parameters.Add(new SqlParameter("@id", "0"));
            obj.Parameters.Add(new SqlParameter("@Presentation_name", Presentation_name.Text));
            obj.Parameters.Add(new SqlParameter("@Presentation_date", Presentation_date.Text));
          // obj.Parameters.Add(new SqlParameter("@Presentation_date", VB_Classes.Dates.Dates_Operation.date_validate(Presentation_date.Text)));

            obj.Parameters.Add(new SqlParameter("@mode", "new"));
            obj.Parameters.Add(new SqlParameter("@Presentation_location", Presentation_location.Text));
            obj.Parameters.Add(new SqlParameter("@Notes", Notes.Text));
            obj.Parameters.Add(new SqlParameter("@ProjID", Session_CS.Project_id.ToString()));
            obj.Parameters.Add(new SqlParameter("@Dept_ID", Session_CS.dept_id.ToString()));

            if (File_data.HasFile)
            {
                string DocName = File_data.FileName;
                int dotindex = DocName.LastIndexOf(".");
                string type = DocName.Substring(dotindex, DocName.Length - dotindex);
                string fileName = DocName.Substring(0, dotindex);
                Stream myStream;
                int fileLen;
                StringBuilder displayString = new StringBuilder();
                fileLen = File_data.PostedFile.ContentLength;
                Byte[] Input = new Byte[fileLen];
                myStream = File_data.FileContent;
                myStream.Read(Input, 0, fileLen);

                obj.Parameters.Add(new SqlParameter("@File_data", Input));
                obj.Parameters.Add(new SqlParameter("@File_name", fileName));
                obj.Parameters.Add(new SqlParameter("@File_ext", type));
            }
            else
            {
                Byte[] Input = new Byte[3];
                obj.Parameters.Add(new SqlParameter("@File_data", Input));
                obj.Parameters.Add(new SqlParameter("@File_name", ""));
                obj.Parameters.Add(new SqlParameter("@File_ext", ""));
            }
            con.Open();
            int rows = obj.ExecuteNonQuery();
            con.Close();
            if (rows > 0)
                lblErrorMsg.Text = "تم الحفظ بنجاح.";
            else
                lblErrorMsg.Text = "حدث خطأ أثناء التسجيل من فضلك حاول مرة اخرى.";
            
            Presentation_name.Text = "";
            Presentation_date.Text = "";
            Presentation_location.Text = "";
            Notes.Text = "";

            FillGrid();
        }
        else
            lblErrorMsg.Text = "أدخل كافة الحقول التى يسبقها *";
    }

    private void DisplayFileContents()
    {
       
    }
   
    protected void SaveButton_Click(object sender, EventArgs e)
    {
        if (mode.Value == "new")
        {
            AddNewRecord();
        }
        else
        {  
            UpdateExistRecord();
        }
        Presentation_name.Text = "";
        Presentation_date.Text = "";
        Presentation_location.Text = "";
        Notes.Text = "";
        linkFile.Visible = false;
        mode.Value = "new";
    }

    private void UpdateExistRecord()
    {
        bool isDate = false;
        if (Presentation_date.Text != "")
          //  if (VB_Classes.Dates.Dates_Operation.date_validate(Presentation_date.Text) != "")
            isDate = true;

        if (isDate == true && Presentation_date.Text != "" && Presentation_name.Text != "")
        {
           
            SqlDataAdapter sqladptr = new SqlDataAdapter();
            SqlConnection con = new SqlConnection(sql_Connection);
            SqlCommand obj = new SqlCommand("Add_Edit_Presentation", con);
            obj.CommandType = CommandType.StoredProcedure;
            obj.Parameters.Add(new SqlParameter("@id", Convert.ToInt16(Presentation_ID.Value)));
            obj.Parameters.Add(new SqlParameter("@Presentation_name", Presentation_name.Text));
           // obj.Parameters.Add(new SqlParameter("@Presentation_date", VB_Classes.Dates.Dates_Operation.date_validate(Presentation_date.Text)));
            obj.Parameters.Add(new SqlParameter("@Presentation_date", Presentation_date.Text));

            obj.Parameters.Add(new SqlParameter("@Presentation_location", Presentation_location.Text));
            obj.Parameters.Add(new SqlParameter("@Notes", Notes.Text));
            obj.Parameters.Add(new SqlParameter("@ProjID", Session_CS.Project_id.ToString()));
            obj.Parameters.Add(new SqlParameter("@Dept_ID", Session_CS.dept_id.ToString()));
            if (File_data.HasFile)
            {
                string DocName = File_data.FileName;
                int dotindex = DocName.LastIndexOf(".");
                string type = DocName.Substring(dotindex, DocName.Length - dotindex);
                string fileName = DocName.Substring(0, dotindex);
                Stream myStream;
                int fileLen;
                StringBuilder displayString = new StringBuilder();
                fileLen = File_data.PostedFile.ContentLength;
                Byte[] Input = new Byte[fileLen];
                myStream = File_data.FileContent;
                myStream.Read(Input, 0, fileLen);

                obj.Parameters.Add(new SqlParameter("@mode", "editWithFile"));
                obj.Parameters.Add(new SqlParameter("@File_data", Input));
                obj.Parameters.Add(new SqlParameter("@File_name", fileName));
                obj.Parameters.Add(new SqlParameter("@File_ext", type));
            }
            else
            {
                Byte[] Input = new Byte[3];
                obj.Parameters.Add(new SqlParameter("@File_data", Input));
                obj.Parameters.Add(new SqlParameter("@File_name", ""));
                obj.Parameters.Add(new SqlParameter("@File_ext", ""));
                obj.Parameters.Add(new SqlParameter("@mode", "edit"));
            }
            con.Open();
            int rows = obj.ExecuteNonQuery();
            con.Close();
            
            if (rows > 0)
                lblErrorMsg.Text = "تم التعديل بنجاح.";
            else
                lblErrorMsg.Text = "حدث خطأ أثناء التعديل من فضلك حاول مرة اخرى.";
            
            Presentation_name.Text = "";
            Presentation_date.Text = "";
            Presentation_location.Text = "";
            Notes.Text = "";
        }
        else
            lblErrorMsg.Text = "أدخل كافة الحقول التى يسبقها *";
        FillGrid();
        SaveButton.Text = "حفظ";
    }
   protected void GrdView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        lblErrorMsg.Text = "أدخل كافة الحقول التى يسبقها *";
        if (e.CommandName == "EditItem")
        {
            SqlDataAdapter sqladptr = new SqlDataAdapter();
            SqlConnection con = new SqlConnection(sql_Connection);
            SqlCommand obj = new SqlCommand("Get_Presentation", con);
            obj.CommandType = CommandType.StoredProcedure;
            //obj.Parameters.Add(new SqlParameter("@ProjID", Session_CS.Project_id.ToString()));
            obj.Parameters.Add(new SqlParameter("@id", Convert.ToInt16(e.CommandArgument)));
            Presentation_ID.Value = e.CommandArgument.ToString();
            con.Open();
            sqladptr.SelectCommand = obj;
            DataTable DT = new DataTable();
            sqladptr.Fill(DT);
            con.Close();
            linkFile.Visible = false;
            if (DT.Rows[0]["File_name"].ToString() != "")
            {
                linkFile.HRef = "ALL_Document_Details.aspx?type=presentation&id=" + DT.Rows[0]["id"].ToString();
                linkFile.Visible = true;
            }
            Presentation_name.Text = DT.Rows[0]["Presentation_name"].ToString();
            Presentation_date.Text = DT.Rows[0]["Presentation_date"].ToString();
            Presentation_location.Text = DT.Rows[0]["Presentation_location"].ToString();
            Notes.Text = DT.Rows[0]["Notes"].ToString();
            mode.Value = "edit";
        }

        if (e.CommandName == "RemoveItem")
        {
            SqlDataAdapter sqladptr = new SqlDataAdapter();
            SqlConnection con = new SqlConnection(sql_Connection);
            SqlCommand obj = new SqlCommand("Delete_Presentation", con);
            obj.CommandType = CommandType.StoredProcedure;
            //SqlParameter objpar = new SqlParameter("Parent", 0);
            obj.Parameters.Add(new SqlParameter("@id", Convert.ToInt16(e.CommandArgument)));
            con.Open();
            sqladptr.SelectCommand = obj;
            DataTable DT = new DataTable();
            sqladptr.Fill(DT);
            con.Close();
            FillGrid();
            lblErrorMsg.Text = "تم الحذف بنجاح.";
        }
        

    }
    protected void ImgBtnDelete_Click(object sender, ImageClickEventArgs e)
    {

    }
}
