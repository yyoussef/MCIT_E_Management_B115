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

public partial class WebForms_Project_meetings : System.Web.UI.Page
{
    //Session_CS Session_CS = new Session_CS();
    string sql_Connection = Universal.GetConnectionString();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request["project"] != null && Request["project"] != "")
            {
                Session_CS.Project_id =CDataConverter.ConvertToInt( Request["project"]);
                if (Request["id"] != null && Request["id"] != "")
                {
                    SqlDataAdapter sqladptr = new SqlDataAdapter();
                    SqlConnection con = new SqlConnection(sql_Connection);
                    SqlCommand obj = new SqlCommand("Get_Meeting", con);
                    obj.CommandType = CommandType.StoredProcedure;
                    //obj.Parameters.Add(new SqlParameter("@ProjID", Session_CS.Project_id.ToString()));
                    obj.Parameters.Add(new SqlParameter("@id", Convert.ToInt16(Request["id"])));
                    meeting_ID.Value = Request["id"].ToString();
                    con.Open();
                    sqladptr.SelectCommand = obj;
                    DataTable DT = new DataTable();
                    sqladptr.Fill(DT);
                    con.Close();
                    Meeting_name.Text = DT.Rows[0]["Meeting_name"].ToString();
                    Meeting_date.Text = DT.Rows[0]["Meeting_date"].ToString();
                    Meeting_location.Text = DT.Rows[0]["Meeting_location"].ToString();
                    Notes.Text = DT.Rows[0]["Notes"].ToString();
                    mode.Value = "edit";

                }

            }
            FillGrid();
            btn_save_Doc.Enabled = false;
            btn_save_File.Enabled = false;
        }

    }
    private void FillGrid()
    {

        string sql = "select * from Meetings where 1=1 ";
        if (CDataConverter.ConvertToInt(Session_CS.Project_id.ToString()) > 0)
        {
            sql += " AND ProjID = " + int.Parse(Session_CS.Project_id.ToString());
        }
        else
            sql += " AND ProjID = 0 AND Dept_ID = " + int.Parse(Session_CS.dept_id.ToString());



        gvMain.DataSource = General_Helping.GetDataTable(sql); ;
        gvMain.DataBind();
    }
    private void FillSidesGrid(string MeetingID)
    {
        if (Session_CS.Project_id != null)
        {
            DataTable DT = new DataTable();
            if (MeetingID == "0")
            {
                SidesGV.DataSource = DT;
                SidesGV.DataBind();
            }
            else
            {
                SqlDataAdapter sqladptr = new SqlDataAdapter();
                SqlConnection con = new SqlConnection(sql_Connection);
                SqlCommand obj = new SqlCommand("Get_Meetings_Sides_By_MeetingID", con);
                obj.CommandType = CommandType.StoredProcedure;
                obj.Parameters.Add(new SqlParameter("@id", MeetingID.ToString()));
                con.Open();
                sqladptr.SelectCommand = obj;

                sqladptr.Fill(DT);
                SidesGV.DataSource = DT;
                SidesGV.DataBind();
                con.Close();
            }
        }
    }
    private void FillFilesGrid(string MeetingID)
    {
        if (Session_CS.Project_id != null)
        {
            DataTable DT = new DataTable();
            if (MeetingID == "0")
            {
                FilesGV.DataSource = DT;
                FilesGV.DataBind();
            }
            else
            {
                SqlDataAdapter sqladptr = new SqlDataAdapter();
                SqlConnection con = new SqlConnection(sql_Connection);
                SqlCommand obj = new SqlCommand("Get_Meetings_Files_By_MeetingID", con);
                obj.CommandType = CommandType.StoredProcedure;
                obj.Parameters.Add(new SqlParameter("@id", MeetingID.ToString()));
                con.Open();
                sqladptr.SelectCommand = obj;
                sqladptr.Fill(DT);
                FilesGV.DataSource = DT;
                FilesGV.DataBind();
                con.Close();
            }
        }
    }
    public void AddNewRecord()
    {
        bool isDate = false;
        if (Meeting_date.Text != "")
         //   if (VB_Classes.Dates.Dates_Operation.date_validate(Meeting_date.Text) != "")
            isDate = true;
        if (isDate == true && Meeting_date.Text != "" && Meeting_name.Text != "")
        {
            SqlParameter[] parms = new SqlParameter[11];
            parms[0] = new SqlParameter("id", 0);
            parms[0].Direction = ParameterDirection.InputOutput;
            parms[1] = new SqlParameter("Meeting_name", Meeting_name.Text);
            //parms[2] = new SqlParameter("Meeting_date", VB_Classes.Dates.Dates_Operation.date_validate(Meeting_date.Text));
            parms[2] = new SqlParameter("Meeting_date", Meeting_date.Text);
            parms[3] = new SqlParameter("mode", "new");
            parms[4] = new SqlParameter("Meeting_location", Meeting_location.Text);
            parms[5] = new SqlParameter("Notes", Notes.Text);
            parms[6] = new SqlParameter("ProjID", Session_CS.Project_id.ToString());
            parms[7] = new SqlParameter("Dept_ID", Session_CS.dept_id.ToString());
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
                parms[8] = new SqlParameter("File_data", Input);
                parms[9] = new SqlParameter("File_name", fileName);
                parms[10] = new SqlParameter("File_ext", type);
            }
            else
            {
                Byte[] Input = new Byte[3];
                parms[8] = new SqlParameter("File_data", Input);
                parms[9] = new SqlParameter("File_name", "");
                parms[10] = new SqlParameter("File_ext", "");
            }

            SqlHelper.ExecuteScalar(Database.ConnectionString, CommandType.StoredProcedure, "Add_Edit_Meeting", parms);
            int rows = Convert.ToInt32(parms[0].Value);
            meeting_ID.Value = rows.ToString();
            FillSidesGrid(rows.ToString());
            FillFilesGrid(rows.ToString());
            if (rows > 0)
                lblErrorMsg.Text = "تم الحفظ بنجاح.";
            else
                lblErrorMsg.Text = "حدث خطأ أثناء التسجيل من فضلك حاول مرة اخرى.";
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
            btn_save_Doc.Enabled = true;
            btn_save_File.Enabled = true;
        }
        else
        {
            UpdateExistRecord();
        }

    }
    private void UpdateExistRecord()
    {
        bool isDate = false;
        if (Meeting_date.Text != "")

           // if (VB_Classes.Dates.Dates_Operation.date_validate(Meeting_date.Text) != "")
            isDate = true;

        if (isDate == true && Meeting_date.Text != "" && Meeting_name.Text != "")
        {

            SqlDataAdapter sqladptr = new SqlDataAdapter();
            SqlConnection con = new SqlConnection(sql_Connection);
            SqlCommand obj = new SqlCommand("Add_Edit_Meeting", con);
            obj.CommandType = CommandType.StoredProcedure;

            obj.Parameters.Add(new SqlParameter("@id", Convert.ToInt16(meeting_ID.Value)));
            obj.Parameters.Add(new SqlParameter("@Meeting_name", Meeting_name.Text));
           // obj.Parameters.Add(new SqlParameter("@Meeting_date", VB_Classes.Dates.Dates_Operation.date_validate(Meeting_date.Text)));

            obj.Parameters.Add(new SqlParameter("@Meeting_date", Meeting_date.Text));
            obj.Parameters.Add(new SqlParameter("@Meeting_location", Meeting_location.Text));
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
            FillSidesGrid(meeting_ID.Value);
            FillFilesGrid(meeting_ID.Value);
            if (rows > 0)
                lblErrorMsg.Text = "تم التعديل بنجاح.";
            else
                lblErrorMsg.Text = "حدث خطأ أثناء التعديل من فضلك حاول مرة اخرى.";


        }
        else
            lblErrorMsg.Text = "أدخل كافة الحقول التى يسبقها *";
        FillGrid();
        SaveButton.Text = "حفظ";
    }
    private void Clear_Cntrl()
    {
        Meeting_name.Text = "";
        Meeting_date.Text = "";
        Meeting_location.Text = "";
        Notes.Text = "";
    }
    protected void GrdView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        lblErrorMsg.Text = "أدخل كافة الحقول التى يسبقها *";
        if (e.CommandName == "EditItem")
        {
            SqlDataAdapter sqladptr = new SqlDataAdapter();
            SqlConnection con = new SqlConnection(sql_Connection);
            SqlCommand obj = new SqlCommand("Get_Meeting", con);
            obj.CommandType = CommandType.StoredProcedure;
            // obj.Parameters.Add(new SqlParameter("@ProjID", Session_CS.Project_id.ToString()));
            obj.Parameters.Add(new SqlParameter("@id", Convert.ToInt16(e.CommandArgument)));
            meeting_ID.Value = e.CommandArgument.ToString();
            con.Open();
            sqladptr.SelectCommand = obj;
            DataTable DT = new DataTable();
            sqladptr.Fill(DT);


            con.Close();

            Meeting_name.Text = DT.Rows[0]["Meeting_name"].ToString();
            Meeting_date.Text = DT.Rows[0]["Meeting_date"].ToString();
            Meeting_location.Text = DT.Rows[0]["Meeting_location"].ToString();
            Notes.Text = DT.Rows[0]["Notes"].ToString();
            mode.Value = "edit";
            FillSidesGrid(DT.Rows[0]["id"].ToString());
            FillFilesGrid(DT.Rows[0]["id"].ToString());
            btn_save_Doc.Enabled = true;
            btn_save_File.Enabled = true;
        }

        if (e.CommandName == "RemoveItem")
        {
            SqlDataAdapter sqladptr = new SqlDataAdapter();
            SqlConnection con = new SqlConnection(sql_Connection);
            SqlCommand obj = new SqlCommand("Delete_Meeting", con);
            obj.CommandType = CommandType.StoredProcedure;
            //SqlParameter objpar = new SqlParameter("Parent", 0);
            obj.Parameters.Add(new SqlParameter("@id", Convert.ToInt16(e.CommandArgument)));
            con.Open();
            sqladptr.SelectCommand = obj;
            obj.ExecuteNonQuery();
            obj.CommandText = "Delete_Meeting_Sides";
            obj.ExecuteNonQuery();
            obj.CommandText = "Delete_Meeting_Files";
            obj.ExecuteNonQuery();
            con.Close();
            FillGrid();
            FillSidesGrid("0");
            FillFilesGrid("0");
            lblErrorMsg.Text = "تم الحذف بنجاح.";
            Reset();
        }
        TabPanel_dtl.Focus();
    }
    protected void SidesGV_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        lblErrorMsg2.Text = "أدخل كافة الحقول التى يسبقها *";
        if (e.CommandName == "EditItem")
        {
            SqlDataAdapter sqladptr = new SqlDataAdapter();
            SqlConnection con = new SqlConnection(sql_Connection);
            SqlCommand obj = new SqlCommand("Get_Meetings_Sides_By_ID", con);
            obj.CommandType = CommandType.StoredProcedure;
            // obj.Parameters.Add(new SqlParameter("@ProjID", Session_CS.Project_id.ToString()));
            obj.Parameters.Add(new SqlParameter("@id", Convert.ToInt16(e.CommandArgument)));
            meeting_ID.Value = e.CommandArgument.ToString();
            con.Open();
            sqladptr.SelectCommand = obj;
            DataTable DT = new DataTable();
            sqladptr.Fill(DT);
            con.Close();
            txt_side_Name.Text = DT.Rows[0]["Side_Name"].ToString();
            side_ID.Value = DT.Rows[0]["Side_ID"].ToString();

            mode2.Value = "edit";
        }

        if (e.CommandName == "RemoveItem")
        {
            SqlDataAdapter sqladptr = new SqlDataAdapter();
            SqlConnection con = new SqlConnection(sql_Connection);
            SqlCommand obj = new SqlCommand("Delete_Meeting_Side", con);
            obj.CommandType = CommandType.StoredProcedure;
            //SqlParameter objpar = new SqlParameter("Parent", 0);
            obj.Parameters.Add(new SqlParameter("@id", Convert.ToInt16(e.CommandArgument)));
            con.Open();
            sqladptr.SelectCommand = obj;
            int rows = obj.ExecuteNonQuery();
            con.Close();
            lblErrorMsg2.Text = "تم الحذف بنجاح.";
        }
        FillSidesGrid(meeting_ID.Value);
        FillFilesGrid(meeting_ID.Value);
    }
    protected void FilesGV_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "RemoveItem")
        {
            SqlDataAdapter sqladptr = new SqlDataAdapter();
            SqlConnection con = new SqlConnection(sql_Connection);
            SqlCommand obj = new SqlCommand("Delete_Meeting_File", con);
            obj.CommandType = CommandType.StoredProcedure;
            //SqlParameter objpar = new SqlParameter("Parent", 0);
            obj.Parameters.Add(new SqlParameter("@id", Convert.ToInt16(e.CommandArgument)));
            con.Open();
            sqladptr.SelectCommand = obj;
            int rows = obj.ExecuteNonQuery();
            con.Close();
            lblErrorMsg3.Text = "تم الحذف بنجاح.";
        }
        FillSidesGrid(meeting_ID.Value);
        FillFilesGrid(meeting_ID.Value);

    }
    protected void ImgBtnDelete_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void btn_save_Doc_Click(object sender, EventArgs e)
    {
        if (txt_side_Name.Text.Trim() != "")
        {
            SqlDataAdapter sqladptr = new SqlDataAdapter();
            SqlConnection con = new SqlConnection(sql_Connection);
            SqlCommand obj = new SqlCommand("Add_Edit_Meeting_Side", con);
            obj.CommandType = CommandType.StoredProcedure;
            obj.Parameters.Add(new SqlParameter("@Meeting_ID", Convert.ToInt16(meeting_ID.Value)));
            obj.Parameters.Add(new SqlParameter("@Side_Name", txt_side_Name.Text));
            obj.Parameters.Add(new SqlParameter("@mode", mode2.Value));
            if (mode2.Value == "new")
            {
                obj.Parameters.Add(new SqlParameter("@Side_ID", Convert.ToInt16("0")));
            }
            else
            {
                obj.Parameters.Add(new SqlParameter("@Side_ID", Convert.ToInt16(side_ID.Value)));
            }
            con.Open();
            int rows = obj.ExecuteNonQuery();
            con.Close();

            if (rows > 0)
                lblErrorMsg2.Text = "تم التعديل بنجاح.";
            else
                lblErrorMsg2.Text = "حدث خطأ أثناء التعديل من فضلك حاول مرة اخرى.";
            txt_side_Name.Text = "";
            side_ID.Value = "0";
            mode2.Value = "new";

        }
        else
            lblErrorMsg2.Text = "أدخل كافة الحقول التى يسبقها *";
        FillSidesGrid(meeting_ID.Value);
        btn_save_Doc.Text = "حفظ";
    }
    protected void btn_save_File_Click(object sender, EventArgs e)
    {
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
            SqlDataAdapter sqladptr = new SqlDataAdapter();
            SqlConnection con = new SqlConnection(sql_Connection);
            SqlCommand obj = new SqlCommand("Add_Edit_Meeting_File", con);
            obj.CommandType = CommandType.StoredProcedure;
            obj.Parameters.Add(new SqlParameter("@MeetingID", Convert.ToInt16(meeting_ID.Value)));
            obj.Parameters.Add(new SqlParameter("@File_data", Input));
            obj.Parameters.Add(new SqlParameter("@File_name", fileName));
            obj.Parameters.Add(new SqlParameter("@File_ext", type));
            con.Open();
            int rows = obj.ExecuteNonQuery();
            con.Close();

            if (rows > 0)
                lblErrorMsg3.Text = "تم الإضافة بنجاح.";
            else
                lblErrorMsg3.Text = "حدث خطأ أثناء التعديل من فضلك حاول مرة اخرى.";
        }
        else
            lblErrorMsg3.Text = "أدخل كافة الحقول التى يسبقها *";
        FillFilesGrid(meeting_ID.Value);
    }
    protected void ResetButton_Click(object sender, EventArgs e)
    {
        Reset();
    }
    private void Reset()
    {
        Meeting_name.Text = "";
        Meeting_date.Text = "";
        Meeting_location.Text = "";
        Notes.Text = "";
        mode.Value = "new";
        mode2.Value = "new";
        meeting_ID.Value = "0";
        side_ID.Value = "0";
        btn_save_Doc.Enabled = false;
        btn_save_File.Enabled = false;
    }
}
