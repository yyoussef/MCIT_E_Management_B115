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
using DBL;
using System.Text;

public partial class WebForms_Project_Complain : System.Web.UI.Page
{
    //Session_CS Session_CS = new Session_CS();
    string sql_Connection = Universal.GetConnectionString();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request["project"] != null && Request["project"] != "")
            {
                Session_CS.Project_id = CDataConverter.ConvertToInt( Request["project"]);
                if (Request["id"] != null && Request["id"] != "")
                {
                    SqlDataAdapter sqladptr = new SqlDataAdapter();
                    SqlConnection con = new SqlConnection(sql_Connection);
                    SqlCommand obj = new SqlCommand("Get_complain", con);
                    obj.CommandType = CommandType.StoredProcedure;
                    obj.Parameters.Add(new SqlParameter("@id", Convert.ToInt16(Request["id"])));
                    comp_ID.Value = Request["id"].ToString();
                    con.Open();
                    sqladptr.SelectCommand = obj;
                    DataTable DT = new DataTable();
                    sqladptr.Fill(DT);
                    con.Close();
                    complain_date.Text = DT.Rows[0]["complain_date"].ToString();
                    org_name.SelectedItem.Value = DT.Rows[0]["org_id"].ToString ();
                    //Event_location.Text = DT.Rows[0]["Event_location"].ToString();
                    Notes.Text = DT.Rows[0]["Notes"].ToString();        
                    mode.Value = "edit";

                }
                if (CDataConverter.ConvertToInt(Session_CS.UROL_UROL_ID.ToString()) == 2 || CDataConverter.ConvertToInt(Session_CS.UROL_UROL_ID.ToString()) == 3)
                {
                    gvMain.Visible =
                   Upload_File_data.Visible = false;
                    
                        complain_date.Enabled =
                        Image1.Enabled =

                        Notes.Enabled = false;

                }
            }
            FillGrid();
        }

    }
    private void FillGrid()
    {
        string sql = "select * from Complian where 1=1 ";
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
        if (CDataConverter.ConvertDateTimeToFormatdmy(CDataConverter.ConvertToDate(complain_date.Text)) != "")

           // if (VB_Classes.Dates.Dates_Operation.date_validate(complain_date.Text) != "")

            isDate = true;

        if (isDate == true && complain_date.Text != "" && org_name.SelectedIndex > 0)
        {
            //string Selectedvalue = "";
            //foreach (ListItem i in Event_attendence.Items)
            //{
            //    if (i.Selected)
            //    {
            //        Selectedvalue += i.Value + "#";
            //    }
        }
        SqlDataAdapter sqladptr = new SqlDataAdapter();
        SqlConnection con = new SqlConnection(sql_Connection);
        SqlCommand obj = new SqlCommand("Add_Edit_Complian", con);
        obj.CommandType = CommandType.StoredProcedure;
        obj.Parameters.Add(new SqlParameter("@id", "0"));
       
       
       // obj.Parameters.Add(new SqlParameter("@complian_date", VB_Classes.Dates.Dates_Operation.date_validate(complain_date.Text)));
        obj.Parameters.Add(new SqlParameter("@complian_date", CDataConverter.ConvertDateTimeToFormatdmy (CDataConverter.ConvertToDate(complain_date.Text))));

        obj.Parameters.Add(new SqlParameter("@mode", "new"));
        obj.Parameters.Add(new SqlParameter("@org_id",org_name.SelectedValue) );
        obj.Parameters.Add(new SqlParameter("@Notes", Notes.Text));
        obj.Parameters.Add(new SqlParameter("@ProjID", Session_CS.Project_id.ToString()));
        obj.Parameters.Add(new SqlParameter("@Dept_ID", Session_CS.dept_id.ToString()));

        if (Upload_File_data.HasFile)
        {
            string DocName = Upload_File_data.FileName;
            int dotindex = DocName.LastIndexOf(".");
            string type = DocName.Substring(dotindex, DocName.Length - dotindex);
            string fileName = DocName.Substring(0, dotindex);
            Stream myStream;
            int fileLen;
            StringBuilder displayString = new StringBuilder();
            fileLen = Upload_File_data.PostedFile.ContentLength;
            Byte[] Input = new Byte[fileLen];
            myStream = Upload_File_data.FileContent;
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

       
        complain_date.Text = "";
        Notes.Text = "";


        FillGrid();
    }
    //else
    //    lblErrorMsg.Text = "أدخل كافة الحقول التى يسبقها *";

//    private void DisplayFileContents()
//    {

//    }
    protected void SaveButton_Click(object sender, EventArgs e)
    {
        if (mode.Value == "new")
        {
            AddNewRecord();
        }
        else
        {
            Updatecomplian();
        }
        complain_date.Text = "";
       
        Notes.Text = "";

    }
    private void Updatecomplian()
    {
        bool isDate = false;
       // if (VB_Classes.Dates.Dates_Operation.date_validate(complain_date.Text) != "")

        if (CDataConverter.ConvertDateTimeToFormatdmy(CDataConverter.ConvertToDate(complain_date.Text)) != "")
            isDate = true;

        if (isDate == true && complain_date.Text != "" && org_name.SelectedIndex > 0)
        {
           

            //foreach (ListItem i in Event_attendence.Items)
            //{
            //    if (i.Selected)
            //    {
            //        Selectedvalue += i.Value + "#";
            //    }
            //}
            //Selectedvalue = Selectedvalue.Substring(0, Selectedvalue.Length - 1);

            SqlDataAdapter sqladptr = new SqlDataAdapter();
            SqlConnection con = new SqlConnection(sql_Connection);
            SqlCommand obj = new SqlCommand("Add_Edit_Complian", con);
            obj.CommandType = CommandType.StoredProcedure;
            obj.Parameters.Add(new SqlParameter("@id", Convert.ToInt16(comp_ID.Value)));
           // obj.Parameters.Add(new SqlParameter("@complian_date", VB_Classes.Dates.Dates_Operation.date_validate(complain_date.Text)));

            obj.Parameters.Add(new SqlParameter("@complian_date", CDataConverter.ConvertDateTimeToFormatdmy(CDataConverter.ConvertToDate(complain_date.Text))));
            obj.Parameters.Add(new SqlParameter("@org_id", Convert.ToInt32(org_name.SelectedValue)));
  
            obj.Parameters.Add(new SqlParameter("@Notes", Notes.Text));
            obj.Parameters.Add(new SqlParameter("@ProjID", Session_CS.Project_id.ToString()));
            obj.Parameters.Add(new SqlParameter("@Dept_ID", Session_CS.dept_id.ToString()));

            
            if (Upload_File_data.HasFile)
            {
                string DocName = Upload_File_data.FileName;
                int dotindex = DocName.LastIndexOf(".");
                string type = DocName.Substring(dotindex, DocName.Length - dotindex);
                string fileName = DocName.Substring(0, dotindex);
                Stream myStream;
                int fileLen;
                StringBuilder displayString = new StringBuilder();
                fileLen = Upload_File_data.PostedFile.ContentLength;
                Byte[] Input = new Byte[fileLen];
                myStream = Upload_File_data.FileContent;
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

            
        }
        else
           
        FillGrid();
        SaveButton.Text = "حفظ";
   }
    protected void GrdView_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "EditItem")
        {
            SqlDataAdapter sqladptr = new SqlDataAdapter();
            SqlConnection con = new SqlConnection(sql_Connection);
            SqlCommand obj = new SqlCommand("Get_complain", con);
            obj.CommandType = CommandType.StoredProcedure;
            //SqlParameter objpar = new SqlParameter("Parent", 0);
            //obj.Parameters.Add(new SqlParameter("@ProjID", Session_CS.Project_id.ToString()));
           
            comp_ID.Value = e.CommandArgument.ToString();
            obj.Parameters.Add(new SqlParameter("@id", comp_ID.Value));


            con.Open();
            sqladptr.SelectCommand = obj;
            DataTable DT = new DataTable();
            sqladptr.Fill(DT);

            con.Close();

            
               // org_name.SelectedValue  = DT.Rows[0]["org_id"].ToString();
                complain_date.Text = DT.Rows[0]["complian_date"].ToString();
                if (DT.Rows[0]["Notes"].ToString() != "")

                    Notes.Text = DT.Rows[0]["Notes"].ToString();

                if (DT.Rows[0]["File_name"].ToString() != "")
                {
                    string str = DT.Rows[0]["File_name"].ToString();
                }

                if (DT.Rows[0]["org_id"].ToString() != "0")
                    org_name.SelectedItem.Value = DT.Rows[0]["org_id"].ToString();

                mode.Value = "edit";
            
        }

            if (e.CommandName == "RemoveItem")
            {
                SqlDataAdapter sqladptr = new SqlDataAdapter();
                SqlConnection con = new SqlConnection(sql_Connection);
                SqlCommand obj = new SqlCommand("Delete_complain", con);
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
    


//    protected void ImgBtnDelete_Click(object sender, ImageClickEventArgs e)
//{}
    protected void complain_date_Load(object sender, EventArgs e)
    {

    }
}

