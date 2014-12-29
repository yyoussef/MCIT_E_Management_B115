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
using System.Text;
using System.IO;

public partial class WebForms_Protocol_Finishing : System.Web.UI.Page
{
    General_Helping Obj_General_Helping = new General_Helping();
    Session_CS Session_CS = new Session_CS();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            Fil_Grid();

        }
    }

    protected override void OnInit(EventArgs e)
    {




        //string strConString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();

        //obj_Sql_Con = new System.Data.SqlClient.SqlConnection(strConString);

        //obj_Sql_Con.Open();

        ////end//

        #region BROWSER FOR departments

        Smart_Search_Protocol.sql_Connection = Universal.GetConnectionString();
//        Smart_Search_Protocol.Query = "SELECT Protocol_ID, Name FROM Protocol_Def";
        string Query = "SELECT Protocol_ID, Name FROM Protocol_Def";
        Smart_Search_Protocol.datatble = General_Helping.GetDataTable(Query);
        Smart_Search_Protocol.Value_Field = "Protocol_ID";
        Smart_Search_Protocol.Text_Field = "Name";
        Smart_Search_Protocol.DataBind();
        //this.Smart_Search_Protocol.Value_Handler += new Smart_Search.Delegate_Selected_Value(MOnMember_Data);
        //Inbox_organization.SelectedValue;


        #endregion


        base.OnInit(e);
    }



    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (Smart_Search_Protocol.SelectedValue != "")
        {
            SqlCommand cmd_tbl = new SqlCommand();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            cmd_tbl.Connection = con;
            cmd_tbl.CommandType = CommandType.Text;

            if (CDataConverter.ConvertToInt(hidden_ID.Value) == 0)
                cmd_tbl.CommandText = " insert into Protocol_Finishing (Protocol_ID,Finish_Date,Finish_Type) VALUES (@Protocol_ID,@Finish_Date,@Finish_Type) select @@identity";
            else
            {
                cmd_tbl.CommandText = " update Protocol_Finishing set Protocol_ID =@Protocol_ID,Finish_Date=@Finish_Date,Finish_Type=@Finish_Type where id=@id  select @id";
                cmd_tbl.Parameters.Add("@id", SqlDbType.Int);
                cmd_tbl.Parameters["@id"].Value = CDataConverter.ConvertToInt(hidden_ID.Value);
            }

            cmd_tbl.Parameters.Add("@Protocol_ID", SqlDbType.Int);
            cmd_tbl.Parameters.Add("@Finish_Date", SqlDbType.NVarChar);
            cmd_tbl.Parameters.Add("@Finish_Type", SqlDbType.Int);

            cmd_tbl.Parameters["@Protocol_ID"].Value = CDataConverter.ConvertToInt( Smart_Search_Protocol.SelectedValue);
            cmd_tbl.Parameters["@Finish_Date"].Value = txt_Finish_Date.Text;
           // cmd_tbl.Parameters["@Finish_Date"].Value = VB_Classes.Dates.Dates_Operation.date_validate(txt_Finish_Date.Text);
            cmd_tbl.Parameters["@Finish_Type"].Value = CDataConverter.ConvertToInt(ddl_Finish_Type.SelectedValue);

            con.Open();
            object obj = cmd_tbl.ExecuteScalar();
            int id = CDataConverter.ConvertToInt(obj.ToString());
            Protocol_Def_DT obj_Protocol_Def = Protocol_Def_DB.SelectByID(CDataConverter.ConvertToInt(Smart_Search_Protocol.SelectedValue));
            if (obj_Protocol_Def.Protocol_ID > 0)
            {
                obj_Protocol_Def.Status = CDataConverter.ConvertToInt(ddl_Finish_Type.SelectedValue);
                Protocol_Def_DB.Save(obj_Protocol_Def);
            }
            con.Close();

            if (FileUpload1.HasFile && id != 0)
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
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = " update Protocol_Finishing set File_Name=@File_Name ,File_Type=@File_Type,File_Source=@File_Source where ID =@ID";


                cmd.Parameters.Add("@File_Source", SqlDbType.VarBinary);
                cmd.Parameters.Add("@ID", SqlDbType.Int);
                cmd.Parameters.Add("@File_Name", SqlDbType.NVarChar);
                cmd.Parameters.Add("@File_Type", SqlDbType.NVarChar);

                cmd.Parameters["@File_Source"].Value = Input;
                cmd.Parameters["@ID"].Value = id;
                cmd.Parameters["@File_Type"].Value = type;
                cmd.Parameters["@File_Name"].Value = DocName;

                con.Open();
                cmd.ExecuteScalar();

                con.Close();

            }


            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم الحفظ بنجاح')</script>");

            Clear_Cntrl();
            Fil_Grid();
        }
        else
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('يجب إختيار اسم البروتوكول')</script>");

    }



    //protected void btn_Doc_Click(object sender, EventArgs e)
    //{
    //    if (FileUpload1.HasFile)
    //    {
    //        string DocName = FileUpload1.FileName;
    //        int dotindex = DocName.LastIndexOf(".");
    //        string type = DocName.Substring(dotindex, DocName.Length - dotindex);

    //        Stream myStream;
    //        int fileLen;
    //        StringBuilder displayString = new StringBuilder();
    //        fileLen = FileUpload1.PostedFile.ContentLength;
    //        Byte[] Input = new Byte[fileLen];
    //        myStream = FileUpload1.FileContent;
    //        myStream.Read(Input, 0, fileLen);

    //        if (CDataConverter.ConvertToInt(hidden_Doc_ID.Value) > 0)
    //        {
    //            SqlCommand cmd = new SqlCommand();
    //            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
    //            cmd.Connection = con;
    //            cmd.CommandType = CommandType.Text;
    //            cmd.CommandText = " update Protocol_Documents set Protocol_ID=@Protocol_ID ,File_Name=@File_Name ,File_Type=@File_Type,File_Source=@File_Source where ID =@ID";


    //            cmd.Parameters.Add("@File_Source", SqlDbType.VarBinary);
    //            cmd.Parameters.Add("@Protocol_ID", SqlDbType.Int);
    //            cmd.Parameters.Add("@ID", SqlDbType.Int);
    //            cmd.Parameters.Add("@File_Name", SqlDbType.NVarChar);
    //            cmd.Parameters.Add("@File_Type", SqlDbType.NVarChar);

    //            cmd.Parameters["@File_Source"].Value = Input;
    //            cmd.Parameters["@ID"].Value = CDataConverter.ConvertToInt(hidden_Doc_ID.Value);
    //            cmd.Parameters["@Protocol_ID"].Value = CDataConverter.ConvertToInt(hidden_Protocol_ID.Value);
    //            cmd.Parameters["@File_Type"].Value = type;
    //            cmd.Parameters["@File_Name"].Value = txtFileName.Text;

    //            con.Open();
    //            cmd.ExecuteScalar();

    //            con.Close();
    //            txtFileName.Text =
    //            hidden_Doc_ID.Value = "";
    //        }
    //        else
    //        {
    //            SqlCommand cmd = new SqlCommand();
    //            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
    //            cmd.Connection = con;
    //            cmd.CommandType = CommandType.Text;
    //            cmd.CommandText = " insert into Protocol_Documents (Protocol_ID,File_Name,File_Type,File_Source) VALUES (@Protocol_ID,@File_Name,@File_Type,@File_Source)";


    //            cmd.Parameters.Add("@File_Source", SqlDbType.VarBinary);
    //            cmd.Parameters.Add("@Protocol_ID", SqlDbType.Int);
    //            cmd.Parameters.Add("@File_Name", SqlDbType.NVarChar);
    //            cmd.Parameters.Add("@File_Type", SqlDbType.NVarChar);

    //            cmd.Parameters["@File_Source"].Value = Input;
    //            cmd.Parameters["@Protocol_ID"].Value = CDataConverter.ConvertToInt(hidden_Protocol_ID.Value);
    //            cmd.Parameters["@File_Type"].Value = type;
    //            cmd.Parameters["@File_Name"].Value = txtFileName.Text;

    //            con.Open();
    //            cmd.ExecuteScalar();

    //            con.Close();
    //            txtFileName.Text =
    //            hidden_Doc_ID.Value = "";

    //        }



    //    }





    //    // Clear_Cntrl();
    //    Fil_Grid_Documents();

    //}



    protected void GrdView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditItem")
        {
            Fill_Controll(CDataConverter.ConvertToInt(e.CommandArgument));

        }

        if (e.CommandName == "RemoveItem")
        {
            string sql = "delete from Protocol_Finishing where ID = " + e.CommandArgument;
            General_Helping.ExcuteQuery(sql);
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم الحذف بنجاح')</script>");
            Fil_Grid();
        }
    }


    private void Fill_Controll(int ID)
    {
        DataTable DT = new DataTable();
        string sql = "select * from Protocol_Finishing where id= " + ID;
        DT =General_Helping.GetDataTable(sql);
        if(DT.Rows.Count >0 )
        {
            DataRow dr = DT.Rows[0];
            txt_Finish_Date.Text = dr["Finish_Date"].ToString();
            Smart_Search_Protocol.SelectedValue = dr["Protocol_ID"].ToString();
            ddl_Finish_Type.SelectedValue = dr["Finish_Type"].ToString();
            hidden_ID.Value =   ID.ToString();
            A2.Visible = true;
            A2.HRef = "ALL_Document_Details.aspx?type=protocolfnsh&id=" + ID;
        }
    }

    void Clear_Cntrl()
    {

        txt_Finish_Date.Text =
        
        hidden_ID.Value  ="";

        Smart_Search_Protocol.Clear_Controls();
        ddl_Finish_Type.SelectedIndex = 0;
        
        A2.Visible = false;



    }

    void Fil_Grid()
    {
        DataTable DT = new DataTable();
        string sql = " SELECT  Protocol_Finishing.ID,  Protocol_Finishing.Finish_Type , Protocol_Def.Protocol_ID, Protocol_Def.Name, Protocol_Def.PMP_ID, Protocol_Def.Signt_Str_DT, Protocol_Def.Signt_End_DT, Protocol_Def.Org_ID, " +
                    "  Protocol_Def.Total_Balance, Protocol_Def.Period, Protocol_Def.Type, Protocol_Def.Status, Protocol_Finishing.Finish_Date " +
                    " FROM         Protocol_Def INNER JOIN Protocol_Finishing ON Protocol_Def.Protocol_ID = Protocol_Finishing.Protocol_ID ";
        DT =General_Helping.GetDataTable(sql);

        grd_View_Mng.DataSource = DT;
        grd_View_Mng.DataBind();
    }

    public string Get_Type(object obj)
    {
        string str = obj.ToString();
        if (str == "1")
            return "بروتوكول";
        else if (str == "2")
            return "اتفاقية";
        else if (str == "3")
            return "موافقة السلطة المختصة";
        else return "بروتوكول";
    }

    public string Get_Status(object obj)
    {
        string str = obj.ToString();
        if (str == "2")
            return "تم الانتهاء بنجاح";
        else if (str == "3")
            return "ملغى";
       
        else return "";
    }

    
}
