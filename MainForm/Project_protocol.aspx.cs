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

public partial class WebForms_Project_protocol : System.Web.UI.Page
{
    string sql_Connection = Universal.GetConnectionString();
    Session_CS Session_CS = new Session_CS();
    protected void Page_Load(object sender, EventArgs e)
    {


        if (!IsPostBack)
        {
            if (Request["project"] != null && Request["project"] != "")
            {
                Session_CS.Project_id = CDataConverter.ConvertToInt( Request["project"]);
                if (Request["id"] != null && Request["id"] != "")
                {
                    SqlConnection con = new SqlConnection(sql_Connection);
                    con.Open();
                    string d = Request["id"];
                    SqlDataAdapter sqladptr = new SqlDataAdapter();

                    SqlCommand obj = new SqlCommand("Get_Protocol", con);
                    obj.CommandType = CommandType.StoredProcedure;
                    //obj.Parameters.Add(new SqlParameter("@ProjID", Session_CS.Project_id.ToString()));
                    obj.Parameters.Add(new SqlParameter("@id", Convert.ToInt16(Request["id"])));
                    Protocol_ID.Value = Request["id"].ToString();

                    sqladptr.SelectCommand = obj;
                    DataTable DT = new DataTable();
                    sqladptr.Fill(DT);

                    Protocol_name.Text = DT.Rows[0]["Protocol_name"].ToString();
                    Protocol_date.Text = DT.Rows[0]["Protocol_date"].ToString();
                    Protocol_end_date.Text = DT.Rows[0]["Protocol_end_date"].ToString();
                    Protocol_location.Text = DT.Rows[0]["Protocol_location"].ToString();
                    Notes.Text = DT.Rows[0]["Notes"].ToString();
                   
                    linkFile.Visible = false;
                    if (DT.Rows[0]["File_name"].ToString() != "")
                    {
                        linkFile.HRef = "ALL_Document_Details.aspx?type=protocol&id=" + DT.Rows[0]["id"].ToString();
                        linkFile.Visible = true;
                    }

                    string s = DT.Rows[0]["Protocol_attendence"].ToString();
                    char[] stringSeparators = new char[] { '#' };

                    string[] words = s.Split(stringSeparators);



                    foreach (ListItem i in Protocol_attendence.Items)
                    {
                        i.Selected = false;
                        if (check_array(words, i.Value) == true)
                        {
                            i.Selected = true;
                        }
                    }

                    mode.Value = "edit";
                    con.Close();
                }
                
            }
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

    private void FillGrid()
    {
        if (Session_CS.Project_id != null)
        {
            SqlDataAdapter sqladptr = new SqlDataAdapter();
            SqlConnection con = new SqlConnection(sql_Connection);
            SqlCommand obj = new SqlCommand("Get_All_Protocol", con);
            obj.CommandType = CommandType.StoredProcedure;
            obj.Parameters.Add(new SqlParameter("@ProjID", Session_CS.Project_id.ToString()));
            con.Open();
            sqladptr.SelectCommand = obj;
            DataTable DT = new DataTable();
            sqladptr.Fill(DT);
            gvMain.DataSource = DT;
            gvMain.DataBind();

            SqlCommand obj2 = new SqlCommand("Get_Ext_Employees", con);
            obj2.CommandType = CommandType.StoredProcedure;
            if (Request["id"] != null && Request["id"] != "")
            {
                obj2.Parameters.Add(new SqlParameter("@protocol_id", Request["id"]));
            }
            else
            {
                obj2.Parameters.Add(new SqlParameter("@protocol_id", "0"));
            }
             
            sqladptr.SelectCommand = obj2;
            DataTable DT2 = new DataTable();
            sqladptr.Fill(DT2);
            
            protocol_attend.DataSource = DT2;
            protocol_attend.DataBind();
            con.Close();
        }
    }
    public void AddNewRecord()
    {
        bool isDate = false;
        if (Protocol_date.Text != "" && Protocol_end_date.Text != "")

         //   if (VB_Classes.Dates.Dates_Operation.date_validate(Protocol_date.Text) != "" && VB_Classes.Dates.Dates_Operation.date_validate(Protocol_end_date.Text) != "")
   
            isDate = true;

        bool isDate2 = false;
        if (Protocol_end_date.Text != "" && Protocol_end_date.Text != "")
       //     if (VB_Classes.Dates.Dates_Operation.date_validate(Protocol_end_date.Text) != "" && VB_Classes.Dates.Dates_Operation.date_validate(Protocol_end_date.Text) != "")
       
            
            isDate2 = true;

        if (isDate == true && isDate2 == true && Protocol_end_date.Text != "" && Protocol_date.Text != "" && Protocol_name.Text != "")
        {
            string Selectedvalue = "";
            foreach (ListItem i in Protocol_attendence.Items)
            {
                if (i.Selected)
                {
                    Selectedvalue += i.Value + "#";
                }
            }
            if (Selectedvalue.Length > 0)
                Selectedvalue = Selectedvalue.Substring(0, Selectedvalue.Length - 1);

            SqlDataAdapter sqladptr = new SqlDataAdapter();
            SqlConnection con = new SqlConnection(sql_Connection);
            SqlCommand obj = new SqlCommand("Add_Edit_Protocol", con);
            obj.CommandType = CommandType.StoredProcedure;
            obj.Parameters.Add(new SqlParameter("@id", "0"));
            obj.Parameters.Add(new SqlParameter("@Protocol_name", Protocol_name.Text));
            obj.Parameters.Add(new SqlParameter("@Protocol_attendence", Selectedvalue));
            obj.Parameters.Add(new SqlParameter("@Protocol_date", Protocol_date.Text));
            obj.Parameters.Add(new SqlParameter("@Protocol_end_date",Protocol_end_date.Text));

            //obj.Parameters.Add(new SqlParameter("@Protocol_date", VB_Classes.Dates.Dates_Operation.date_validate(Protocol_date.Text)));
            //obj.Parameters.Add(new SqlParameter("@Protocol_end_date", VB_Classes.Dates.Dates_Operation.date_validate(Protocol_end_date.Text)));

            obj.Parameters.Add(new SqlParameter("@mode", "new"));
            obj.Parameters.Add(new SqlParameter("@Protocol_location", Protocol_location.Text));
            obj.Parameters.Add(new SqlParameter("@Notes", Notes.Text));
            obj.Parameters.Add(new SqlParameter("@ProjID", Session_CS.Project_id.ToString()));
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

            SqlCommand obj6 = new SqlCommand("Get_Latest_Protocol", con);
            obj6.CommandType = CommandType.StoredProcedure;
            sqladptr.SelectCommand = obj6;
            DataTable DT2 = new DataTable();
            sqladptr.Fill(DT2);
            string p_ID = DT2.Rows[0]["maxid"].ToString();

            if (rows > 0)
                lblErrorMsg.Text = "تم الحفظ بنجاح.";
            else
                lblErrorMsg.Text = "حدث خطأ أثناء التسجيل من فضلك حاول مرة اخرى.";

            Protocol_name.Text = "";
            Protocol_date.Text = "";
            Protocol_end_date.Text = "";
            Protocol_location.Text = "";
            Notes.Text = "";

            SqlCommand obj2 = new SqlCommand("Delete_Emp_Ext", con);
            obj2.CommandType = CommandType.StoredProcedure;
            obj2.Parameters.Add(new SqlParameter("@protocol_id", p_ID));
            obj2.ExecuteNonQuery();


            
            /// code
            foreach (GridViewRow row in protocol_attend.Rows)
            {
                // Access the CheckBox
                CheckBox cb = (CheckBox)row.FindControl("ProductSelector");
                if (cb != null && cb.Checked)
                {
                    SqlCommand obj3 = new SqlCommand("Add_Edit_Emp_Ext", con);
                    obj3.CommandType = CommandType.StoredProcedure;
                    Label eID = (Label)row.FindControl("Employee_ID");
                    int productID = Convert.ToInt32(eID.Text);
                    obj3.Parameters.Add(new SqlParameter("@emp_id", productID));
                    obj3.Parameters.Add(new SqlParameter("@protocol_id", p_ID));
                    obj3.ExecuteNonQuery();
                }
            }
            FillGrid();
            con.Close();
        }
        else
            lblErrorMsg.Text = "أدخل كافة الحقول التى يسبقها *";
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

        Protocol_name.Text = "";
        Protocol_date.Text = "";
        Protocol_end_date.Text = "";
        Protocol_location.Text = "";
        Notes.Text = "";

        foreach (ListItem i in Protocol_attendence.Items)
        {
            i.Selected = false;
        }

        linkFile.Visible = false;
        mode.Value = "new";

    }

    private void UpdateExistRecord()
    {
        bool isDate = false;
        if (Protocol_date.Text != "" && Protocol_end_date.Text != "")

        //    if (VB_Classes.Dates.Dates_Operation.date_validate(Protocol_date.Text) != "" && VB_Classes.Dates.Dates_Operation.date_validate(Protocol_end_date.Text) != "")
      
            isDate = true;

        bool isDate2 = false;
        if (Protocol_end_date.Text != "" && Protocol_end_date.Text != "")
           // if (VB_Classes.Dates.Dates_Operation.date_validate(Protocol_end_date.Text) != "" && VB_Classes.Dates.Dates_Operation.date_validate(Protocol_end_date.Text) != "")

            
            
            isDate2 = true;

        if (isDate == true && isDate2 == true && Protocol_end_date.Text != "" && Protocol_date.Text != "" && Protocol_name.Text != "")
        {
            string Selectedvalue = "";

            foreach (ListItem i in Protocol_attendence.Items)
            {
                if (i.Selected)
                {
                    Selectedvalue += i.Value + "#";
                }
            }
            if (Selectedvalue.Length>0)
                Selectedvalue = Selectedvalue.Substring(0, Selectedvalue.Length - 1);

            SqlDataAdapter sqladptr = new SqlDataAdapter();
            SqlConnection con = new SqlConnection(sql_Connection);
            SqlCommand obj = new SqlCommand("Add_Edit_Protocol", con);
            obj.CommandType = CommandType.StoredProcedure;
            obj.Parameters.Add(new SqlParameter("@id", Convert.ToInt16(Protocol_ID.Value)));
            obj.Parameters.Add(new SqlParameter("@Protocol_name", Protocol_name.Text));
            obj.Parameters.Add(new SqlParameter("@Protocol_date", Protocol_date.Text));

           // obj.Parameters.Add(new SqlParameter("@Protocol_date", VB_Classes.Dates.Dates_Operation.date_validate(Protocol_date.Text)));
            obj.Parameters.Add(new SqlParameter("@Protocol_end_date", Protocol_end_date.Text));

           // obj.Parameters.Add(new SqlParameter("@Protocol_end_date", VB_Classes.Dates.Dates_Operation.date_validate(Protocol_end_date.Text)));
            obj.Parameters.Add(new SqlParameter("@Protocol_location", Protocol_location.Text));
            obj.Parameters.Add(new SqlParameter("@Notes", Notes.Text));
            obj.Parameters.Add(new SqlParameter("@ProjID", Session_CS.Project_id.ToString()));
            obj.Parameters.Add(new SqlParameter("@Protocol_attendence", Selectedvalue));
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
            

            if (rows > 0)
                lblErrorMsg.Text = "تم التعديل بنجاح.";
            else
                lblErrorMsg.Text = "حدث خطأ أثناء التعديل من فضلك حاول مرة اخرى.";

            Protocol_name.Text = "";
            Protocol_date.Text = "";
            Protocol_end_date.Text = "";
            Protocol_location.Text = "";
            Notes.Text = "";

            string p_ID = Protocol_ID.Value;
            SqlCommand obj2 = new SqlCommand("Delete_Emp_Ext", con);
            obj2.CommandType = CommandType.StoredProcedure;
            obj2.Parameters.Add(new SqlParameter("@protocol_id", p_ID));
            obj2.ExecuteNonQuery();



            /// code
            foreach (GridViewRow row in protocol_attend.Rows)
            {
                // Access the CheckBox
                CheckBox cb = (CheckBox)row.FindControl("ProductSelector");
                if (cb != null && cb.Checked)
                {
                    SqlCommand obj3 = new SqlCommand("Add_Edit_Emp_Ext", con);
                    obj3.CommandType = CommandType.StoredProcedure;
                    Label eID = (Label)row.FindControl("Employee_ID");
                    int productID = Convert.ToInt32(eID.Text);
                    obj3.Parameters.Add(new SqlParameter("@emp_id", productID));
                    obj3.Parameters.Add(new SqlParameter("@protocol_id", p_ID));
                    obj3.ExecuteNonQuery();
                }
            }
            con.Close();
        }
        else
            lblErrorMsg.Text = "أدخل كافة الحقول التى يسبقها *";
        FillGrid();
        SaveButton.Text = "حفظ";
    }
    protected void GrdView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        SqlConnection con = new SqlConnection(sql_Connection);
        con.Open();
        lblErrorMsg.Text = "أدخل كافة الحقول التى يسبقها *";
        if (e.CommandName == "EditItem")
        {
            SqlDataAdapter sqladptr = new SqlDataAdapter();
            
            SqlCommand obj = new SqlCommand("Get_Protocol", con);
            obj.CommandType = CommandType.StoredProcedure;
            //obj.Parameters.Add(new SqlParameter("@ProjID", Session_CS.Project_id.ToString()));
            obj.Parameters.Add(new SqlParameter("@id", Convert.ToInt16(e.CommandArgument)));
            Protocol_ID.Value = e.CommandArgument.ToString();
            
            sqladptr.SelectCommand = obj;
            DataTable DT = new DataTable();
            sqladptr.Fill(DT);
            linkFile.Visible = false;
            if (DT.Rows[0]["File_name"].ToString() != "")
            {
                linkFile.HRef = "ALL_Document_Details.aspx?type=protocol&id=" + DT.Rows[0]["id"].ToString();
                linkFile.Visible = true;
            }
            Protocol_name.Text = DT.Rows[0]["Protocol_name"].ToString();
            Protocol_date.Text = DT.Rows[0]["Protocol_date"].ToString();
            Protocol_end_date.Text = DT.Rows[0]["Protocol_end_date"].ToString();
            Protocol_location.Text = DT.Rows[0]["Protocol_location"].ToString();
            Notes.Text = DT.Rows[0]["Notes"].ToString();
            mode.Value = "edit";

            string s = DT.Rows[0]["Protocol_attendence"].ToString();
            char[] stringSeparators = new char[] { '#' };

            string[] words = s.Split(stringSeparators);



            foreach (ListItem i in Protocol_attendence.Items)
            {
                i.Selected = false;
                if (check_array(words, i.Value) == true)
                {
                    i.Selected = true;
                }
            }

            mode.Value = "edit";

            SqlCommand obj2 = new SqlCommand("Get_Ext_Employees", con);
            obj2.CommandType = CommandType.StoredProcedure;
            obj2.Parameters.Add(new SqlParameter("@protocol_id", Convert.ToInt16(e.CommandArgument)));
            sqladptr.SelectCommand = obj2;
            DataTable DT2 = new DataTable(); 
            sqladptr.Fill(DT2);
            protocol_attend.DataSource = DT2;
            protocol_attend.DataBind();
        }

        if (e.CommandName == "RemoveItem")
        {
            SqlDataAdapter sqladptr = new SqlDataAdapter();
            
            SqlCommand obj = new SqlCommand("Delete_Protocol", con);
            obj.CommandType = CommandType.StoredProcedure;
            //SqlParameter objpar = new SqlParameter("Parent", 0);
            obj.Parameters.Add(new SqlParameter("@id", Convert.ToInt16(e.CommandArgument)));
            sqladptr.SelectCommand = obj;
            DataTable DT = new DataTable();
            sqladptr.Fill(DT);
            FillGrid();
            lblErrorMsg.Text = "تم الحذف بنجاح.";
        }
        con.Close();
    }
    protected void ImgBtnDelete_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void protocol_attend_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //CheckBox cb = (CheckBox)e.Row.Cells[2].FindControl("ProductSelector");
        //cb.Checked = true;
    }
    protected void protocol_attend_DataBinding(object sender, EventArgs e)
    {

    }
    protected void protocol_attend_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //CheckBox cb = (CheckBox)e.Row.Cells[2].FindControl("ProductSelector");
        //cb.Checked = true;
    }

    protected void protocol_attend_DataBound(object sender, EventArgs e)
    {
        foreach (GridViewRow row in protocol_attend.Rows)
        {
            // Access the CheckBox
            CheckBox cb = (CheckBox)row.FindControl("ProductSelector");
            HiddenField hf = (HiddenField)row.FindControl("HiddenField1");
            if(hf.Value!="")
                cb.Checked = Convert.ToBoolean(hf.Value.ToString());
        }
    }
    protected void Protocol_attendence_DataBound(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request["id"] != null && Request["id"] != "")
            {
                SqlConnection con = new SqlConnection(sql_Connection);
                con.Open();
                string d = Request["id"];
                SqlDataAdapter sqladptr = new SqlDataAdapter();

                SqlCommand obj = new SqlCommand("Get_Protocol", con);
                obj.CommandType = CommandType.StoredProcedure;
               // obj.Parameters.Add(new SqlParameter("@ProjID", Session_CS.Project_id.ToString()));
                obj.Parameters.Add(new SqlParameter("@id", Convert.ToInt16(Request["id"])));
                Protocol_ID.Value = Request["id"].ToString();

                sqladptr.SelectCommand = obj;
                DataTable DT = new DataTable();
                sqladptr.Fill(DT);
                con.Close();

                string s = DT.Rows[0]["Protocol_attendence"].ToString();
                char[] stringSeparators = new char[] { '#' };

                string[] words = s.Split(stringSeparators);



                foreach (ListItem i in Protocol_attendence.Items)
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
}
