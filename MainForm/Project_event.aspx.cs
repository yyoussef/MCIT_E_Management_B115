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

public partial class WebForms_Project_event : System.Web.UI.Page
{
    Session_CS Session_CS = new Session_CS();
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
                    SqlCommand obj = new SqlCommand("Get_Event", con);
                    obj.CommandType = CommandType.StoredProcedure;
                    //SqlParameter objpar = new SqlParameter("Parent", 0);
                    //obj.Parameters.Add(new SqlParameter("@ProjID", Session_CS.Project_id.ToString()));
                    obj.Parameters.Add(new SqlParameter("@id", Convert.ToInt16(Request["id"])));
                    Event_ID.Value = Request["id"].ToString();
                    con.Open();
                    sqladptr.SelectCommand = obj;
                    DataTable DT = new DataTable();
                    sqladptr.Fill(DT);
                    con.Close();
                    Event_name.Text = DT.Rows[0]["Event_name"].ToString();
                    Event_date.Text = DT.Rows[0]["Event_date"].ToString();
                    Event_location.Text = DT.Rows[0]["Event_location"].ToString();
                    Notes.Text = DT.Rows[0]["Notes"].ToString();
                    linkFile.Visible = false;
                    if (DT.Rows[0]["File_name"].ToString() != "")
                    {
                        linkFile.HRef = "ALL_Document_Details.aspx?type=Event&id=" + DT.Rows[0]["id"].ToString();
                        linkFile.Visible = true;
                    }
                    string s = DT.Rows[0]["Event_attendence"].ToString();
                    char[] stringSeparators = new char[] { '#' };

                    string[] words = s.Split(stringSeparators);



                    foreach (ListItem i in Event_attendence.Items)
                    {
                        i.Selected = false;
                        if (check_array(words, i.Value) == true)
                        {
                            i.Selected = true;
                        }
                    }

                    mode.Value = "edit";

                }
                if (CDataConverter.ConvertToInt(Session_CS.UROL_UROL_ID.ToString()) == 2 || CDataConverter.ConvertToInt(Session_CS.UROL_UROL_ID.ToString()) == 3)
                {
                    gvMain.Visible =
                    File_data.Visible = false;
                    Event_name.Enabled =
                        Event_date.Enabled =
                        Image1.Enabled =
                        Event_attendence.Enabled =
                        Notes.Enabled =
                    Event_location.Enabled = false;
                }
            }
            FillGrid();
        }

    }
    private void FillGrid()
    {
        string sql = "select * from Event where 1=1 ";
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
        if (Event_date.Text != "")
            isDate = true;

        if (isDate == true && Event_date.Text != "" && Event_name.Text != "")
        {
            string Selectedvalue = "";
            foreach (ListItem i in Event_attendence.Items)
            {
                if (i.Selected)
                {
                    Selectedvalue += i.Value + "#";
                }
            }
            SqlDataAdapter sqladptr = new SqlDataAdapter();
            SqlConnection con = new SqlConnection(sql_Connection);
            SqlCommand obj = new SqlCommand("Add_Edit_Event", con);
            obj.CommandType = CommandType.StoredProcedure;
            obj.Parameters.Add(new SqlParameter("@id", "0"));
            obj.Parameters.Add(new SqlParameter("@Event_name", Event_name.Text));
            obj.Parameters.Add(new SqlParameter("@Event_attendence", Selectedvalue));
            obj.Parameters.Add(new SqlParameter("@Event_date", Event_date.Text));
            obj.Parameters.Add(new SqlParameter("@mode", "new"));
            obj.Parameters.Add(new SqlParameter("@Event_location", Event_location.Text));
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

            Event_name.Text = "";
            Event_date.Text = "";
            Event_location.Text = "";
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
        Event_name.Text = "";
        Event_date.Text = "";
        Event_location.Text = "";
        Notes.Text = "";

        foreach (ListItem i in Event_attendence.Items)
        {
            i.Selected = false;
        }

        linkFile.Visible = false;
        mode.Value = "new";
    }
    private void UpdateExistRecord()
    {
        bool isDate = false;
        if (Event_date.Text != "")
            isDate = true;

        if (isDate == true && Event_date.Text != "" && Event_name.Text != "")
        {
            string Selectedvalue = "";

            foreach (ListItem i in Event_attendence.Items)
            {
                if (i.Selected)
                {
                    Selectedvalue += i.Value + "#";
                }
            }
            if (Selectedvalue.Length > 1)
                Selectedvalue = Selectedvalue.Substring(0, Selectedvalue.Length - 1);

            SqlDataAdapter sqladptr = new SqlDataAdapter();
            SqlConnection con = new SqlConnection(sql_Connection);
            SqlCommand obj = new SqlCommand("Add_Edit_Event", con);
            obj.CommandType = CommandType.StoredProcedure;
            obj.Parameters.Add(new SqlParameter("@id", Convert.ToInt16(Event_ID.Value)));
            obj.Parameters.Add(new SqlParameter("@Event_name", Event_name.Text));
            obj.Parameters.Add(new SqlParameter("@Event_date", Event_date.Text));
            obj.Parameters.Add(new SqlParameter("@Event_location", Event_location.Text));
            obj.Parameters.Add(new SqlParameter("@Notes", Notes.Text));
            obj.Parameters.Add(new SqlParameter("@ProjID", Session_CS.Project_id.ToString()));
            obj.Parameters.Add(new SqlParameter("@Dept_ID", Session_CS.dept_id.ToString()));
            obj.Parameters.Add(new SqlParameter("@Event_attendence", Selectedvalue));
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

            Event_name.Text = "";
            Event_date.Text = "";
            Event_location.Text = "";
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
            SqlCommand obj = new SqlCommand("Get_Event", con);
            obj.CommandType = CommandType.StoredProcedure;
            //SqlParameter objpar = new SqlParameter("Parent", 0);
            //obj.Parameters.Add(new SqlParameter("@ProjID", Session_CS.Project_id.ToString()));
            obj.Parameters.Add(new SqlParameter("@id", Convert.ToInt16(e.CommandArgument)));
            Event_ID.Value = e.CommandArgument.ToString();
            con.Open();
            sqladptr.SelectCommand = obj;
            DataTable DT = new DataTable();
            sqladptr.Fill(DT);
            con.Close();
            Event_name.Text = DT.Rows[0]["Event_name"].ToString();
            Event_date.Text = DT.Rows[0]["Event_date"].ToString();
            Event_location.Text = DT.Rows[0]["Event_location"].ToString();
            Notes.Text = DT.Rows[0]["Notes"].ToString();
            string str = DT.Rows[0]["File_name"].ToString();

            linkFile.Visible = false;
            if (DT.Rows[0]["File_name"].ToString() != "")
            {
                linkFile.HRef = "ALL_Document_Details.aspx?type=Event&id=" + DT.Rows[0]["id"].ToString();
                linkFile.Visible = true;
            }

            string s = DT.Rows[0]["Event_attendence"].ToString();
            char[] stringSeparators = new char[] { '#' };

            string[] words = s.Split(stringSeparators);



            foreach (ListItem i in Event_attendence.Items)
            {
                i.Selected = false;
                if (check_array(words, i.Value) == true)
                {
                    i.Selected = true;
                }
            }

            mode.Value = "edit";
        }

        if (e.CommandName == "RemoveItem")
        {
            SqlDataAdapter sqladptr = new SqlDataAdapter();
            SqlConnection con = new SqlConnection(sql_Connection);
            SqlCommand obj = new SqlCommand("Delete_Event", con);
            obj.CommandType = CommandType.StoredProcedure;
            //SqlParameter objpar = new SqlParameter("Parent", 0);
            obj.Parameters.Add(new SqlParameter("@id", Convert.ToInt16(e.CommandArgument)));
            con.Open();
            sqladptr.SelectCommand = obj;
            DataTable DT = new DataTable();
            sqladptr.Fill(DT);
            con.Close();
            lblErrorMsg.Text = "تم الحذف بنجاح.";
            FillGrid();
        }


    }
    public static bool check_array(string[] arr_list, string val_tocheck)
    {
        bool isExist = false;
        foreach (string val in arr_list)
        {
            if (val == val_tocheck)
                isExist = true;
        }
        return isExist;
    }
    public static ArrayList SelectedValues(ListBox lbox)
    {
        ArrayList selectedValues = new ArrayList();

        int[] selectedIndeces = lbox.GetSelectedIndices();
        foreach (int i in selectedIndeces)
            selectedValues.Add(lbox.Items[i].Value);
        return selectedValues;
    }
    protected void ImgBtnDelete_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void Event_attendence_DataBound(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request["id"] != null && Request["id"] != "")
            {
                SqlDataAdapter sqladptr = new SqlDataAdapter();
                SqlConnection con = new SqlConnection(sql_Connection);
                SqlCommand obj = new SqlCommand("Get_Event", con);
                obj.CommandType = CommandType.StoredProcedure;
                //SqlParameter objpar = new SqlParameter("Parent", 0);
                //obj.Parameters.Add(new SqlParameter("@ProjID", Session_CS.Project_id.ToString()));
                obj.Parameters.Add(new SqlParameter("@id", Convert.ToInt16(Request["id"])));
                Event_ID.Value = Request["id"].ToString();
                con.Open();
                sqladptr.SelectCommand = obj;
                DataTable DT = new DataTable();
                sqladptr.Fill(DT);
                con.Close();

                string s = DT.Rows[0]["Event_attendence"].ToString();
                char[] stringSeparators = new char[] { '#' };

                string[] words = s.Split(stringSeparators);



                foreach (ListItem i in Event_attendence.Items)
                {
                    i.Selected = false;
                    if (check_array(words, i.Value) == true)
                    {
                        i.Selected = true;
                    }
                }

                mode.Value = "edit";

            }
        }
    }
    protected void Event_date_Load(object sender, EventArgs e)
    {

    }
}
