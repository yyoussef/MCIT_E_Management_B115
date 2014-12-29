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
using System.Drawing;


public partial class WebForms_Project_Inbox_search : System.Web.UI.Page
{
    Session_CS Session_CS = new Session_CS();
    private string sql_Connection = ConfigurationManager.AppSettings["ConnectionString"].ToString();

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected override void OnInit(EventArgs e)
    {




        //string strConString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();

        //obj_Sql_Con = new System.Data.SqlClient.SqlConnection(strConString);

        //obj_Sql_Con.Open();

        ////end//

        #region BROWSER FOR departments

        Inbox_organization.sql_Connection = sql_Connection;
        string Query = "SELECT Org_ID, Org_Desc FROM Organization";
        Inbox_organization.Value_Field = "Org_ID";
        Inbox_organization.Text_Field = "Org_Desc";
        Inbox_organization.datatble = General_Helping.GetDataTable(Query);
        Inbox_organization.DataBind();
        //this.Smrt_Srch_DropDep.Value_Handler += new Smart_Search.Delegate_Selected_Value(MOnMember_Data);
        //Inbox_organization.SelectedValue;


        #endregion


        base.OnInit(e);
    }

    public void SearchRecord()
    {
        string strMaxDT = "";
        string strMinDT = "";

        strMaxDT = Inbox_date_to.Text;
        strMinDT = Inbox_date_from.Text;

        SqlDataAdapter sqladptr = new SqlDataAdapter();
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

        string procedureName = "";
        string procedureOperand = "";
        if (Letter_type.SelectedValue == "outbox")
        {
            procedureName = "Get_Outbox_Search";
            SqlCommand obj = new SqlCommand(procedureName, con);
            obj.CommandType = CommandType.StoredProcedure;
            //obj.Parameters.Add(new SqlParameter("@Outbox_type", "%" + Inbox_type.SelectedValue + "%"));
            obj.Parameters.Add(new SqlParameter("@Outbox_organization", Inbox_organization.SelectedValue));
            obj.Parameters.Add(new SqlParameter("@Outbox_year", "%" + Inbox_year.Text + "%"));
            obj.Parameters.Add(new SqlParameter("@Outbox_no", "%" + Inbox_no.Text + "%"));
            obj.Parameters.Add(new SqlParameter("@Outbox_name", "%" + Inbox_name.Text + "%"));
            obj.Parameters.Add(new SqlParameter("@Outbox_location", "%" + Inbox_location.Text + "%"));
            obj.Parameters.Add(new SqlParameter("@ProjID", Session_CS.Project_id.ToString()));
            obj.Parameters.Add(new SqlParameter("@Outbox_date_from", strMinDT));
            obj.Parameters.Add(new SqlParameter("@Outbox_date_to", strMaxDT));
            con.Open();
            sqladptr.SelectCommand = obj;
            DataTable DT = new DataTable();
            sqladptr.Fill(DT);
            gvMain.DataSource = DT;
            gvMain.DataBind();

            con.Close();
        }
        else if (Letter_type.SelectedValue == "all")
        {
            procedureName = "Get_Outbox_Search";
            SqlCommand obj = new SqlCommand(procedureName, con);
            obj.CommandType = CommandType.StoredProcedure;
            //obj.Parameters.Add(new SqlParameter("@Outbox_type", "%" + Inbox_type.SelectedValue + "%"));
            obj.Parameters.Add(new SqlParameter("@Outbox_organization", Inbox_organization.SelectedValue));
            obj.Parameters.Add(new SqlParameter("@Outbox_year", "%" + Inbox_year.Text + "%"));
            obj.Parameters.Add(new SqlParameter("@Outbox_no", "%" + Inbox_no.Text + "%"));
            obj.Parameters.Add(new SqlParameter("@ProjID", Session_CS.Project_id.ToString()));
            obj.Parameters.Add(new SqlParameter("@Outbox_name", "%" + Inbox_name.Text + "%"));
            obj.Parameters.Add(new SqlParameter("@Outbox_location", "%" + Inbox_location.Text + "%"));
            obj.Parameters.Add(new SqlParameter("@Outbox_date_from", strMinDT));
            obj.Parameters.Add(new SqlParameter("@Outbox_date_to", strMaxDT));
            con.Open();
            sqladptr.SelectCommand = obj;
            DataTable DT = new DataTable();
            sqladptr.Fill(DT);

            procedureName = "Get_Inbox_Search";
            SqlCommand obj2 = new SqlCommand(procedureName, con);
            obj2.CommandType = CommandType.StoredProcedure;
            //obj2.Parameters.Add(new SqlParameter("@Inbox_type", "%" + Inbox_type.SelectedValue + "%"));
            obj2.Parameters.Add(new SqlParameter("@Inbox_organization", Inbox_organization.SelectedValue));
            obj2.Parameters.Add(new SqlParameter("@Inbox_year", "%" + Inbox_year.Text + "%"));
            obj2.Parameters.Add(new SqlParameter("@Inbox_no", "%" + Inbox_no.Text + "%"));
            obj2.Parameters.Add(new SqlParameter("@ProjID", Session_CS.Project_id.ToString()));
            obj2.Parameters.Add(new SqlParameter("@Inbox_name", "%" + Inbox_name.Text + "%"));
            obj2.Parameters.Add(new SqlParameter("@Inbox_location", "%" + Inbox_location.Text + "%"));
            obj2.Parameters.Add(new SqlParameter("@Inbox_date_from", strMinDT));
            obj2.Parameters.Add(new SqlParameter("@Inbox_date_to", strMaxDT));

            sqladptr.SelectCommand = obj2;
            DataTable DT2 = new DataTable();
            sqladptr.Fill(DT2);
            DT.Merge(DT2);

            gvMain.DataSource = DT;
            gvMain.DataBind();
            //DT.Rows.a
            con.Close();

        }
        else if (Letter_type.SelectedValue == "inbox")
        {
            procedureName = "Get_Inbox_Search";
            SqlCommand obj = new SqlCommand(procedureName, con);
            obj.CommandType = CommandType.StoredProcedure;
            //obj.Parameters.Add(new SqlParameter("@Inbox_type", "%" + Inbox_type.SelectedValue + "%"));
            obj.Parameters.Add(new SqlParameter("@Inbox_organization", Inbox_organization.SelectedValue));
            obj.Parameters.Add(new SqlParameter("@Inbox_year", "%" + Inbox_year.Text + "%"));
            obj.Parameters.Add(new SqlParameter("@Inbox_no", "%" + Inbox_no.Text + "%"));
            obj.Parameters.Add(new SqlParameter("@Inbox_name", "%" + Inbox_name.Text + "%"));
            obj.Parameters.Add(new SqlParameter("@ProjID", Session_CS.Project_id.ToString()));
            obj.Parameters.Add(new SqlParameter("@Inbox_location", "%" + Inbox_location.Text + "%"));
            obj.Parameters.Add(new SqlParameter("@Inbox_date_from", strMinDT));
            obj.Parameters.Add(new SqlParameter("@Inbox_date_to", strMaxDT));
            con.Open();
            sqladptr.SelectCommand = obj;
            DataTable DT = new DataTable();
            sqladptr.Fill(DT);
            gvMain.DataSource = DT;
            gvMain.DataBind();
            //DT.Rows.a
            con.Close();

        }



    }

    protected void SaveButton_Click(object sender, EventArgs e)
    {
        GridView1.Visible = false;
        SearchRecord();
    }

    private void FillGrid()
    {
        if (Session_CS.Project_id != null)
        {
            SqlDataAdapter sqladptr = new SqlDataAdapter();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            SqlCommand obj = new SqlCommand("Get_All_Inbox", con);
            obj.CommandType = CommandType.StoredProcedure;
            obj.Parameters.Add(new SqlParameter("@ProjID", Session_CS.Project_id.ToString()));
            con.Open();
            sqladptr.SelectCommand = obj;
            DataTable DT = new DataTable();
            sqladptr.Fill(DT);
            gvMain.DataSource = DT;
            gvMain.DataBind();
        }
    }

    protected void gvMain_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        // searching through the rows
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string isInbox = (string)DataBinder.Eval(e.Row.DataItem, "isInbox");
            if (isInbox == "1")
                e.Row.BackColor = Color.FromName("#FFFFD4"); // is a "new" row
            else
                e.Row.BackColor = Color.FromName("#FFD4FF"); // is a "new" row
            //FFFFD4

            //FFD4FF
        }
    }

    protected void gvMain_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        //con.Open();
        //if (e.CommandName == "RelatedItem")
        //{
        //    SqlDataAdapter sqladptr = new SqlDataAdapter();
        //    string storedName = "";
        //    if (Letter_type.SelectedValue == "outbox")
        //    {
        //        storedName = "Get_Related_Outbox";
        //    }
        //    else
        //    {
        //        storedName = "Get_Related_Inbox";
        //    }
        //    SqlCommand obj2 = new SqlCommand(storedName, con);
        //    obj2.CommandType = CommandType.StoredProcedure;
        //    obj2.Parameters.Add(new SqlParameter("@inbox_id", Convert.ToInt16(e.CommandArgument)));
        //    sqladptr.SelectCommand = obj2;
        //    DataTable DT2 = new DataTable();
        //    sqladptr.Fill(DT2);
        //    GridView1.Visible = true;
        //    GridView1.DataSource = DT2;
        //    GridView1.DataBind();
        //    SearchRecord();
        //}

        if (e.CommandName == "RelatedItem")
        {
            int ID = CDataConverter.ConvertToInt(e.CommandArgument.ToString());
            GridViewRow row = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
            Label lbl_Type = (Label)row.FindControl("lbl_Type");
            int Box_Type = CDataConverter.ConvertToInt(lbl_Type.Text);
            int Reply_ID = CDataConverter.ConvertToInt(((Label)row.FindControl("lbl_Reply_ID")).Text);
            int Main_Type;

            if (Box_Type == 1 || Box_Type == 2 || Box_Type == 3)
                Main_Type = 1;
            else
                Main_Type = 2;

            DataTable OutDt = new DataTable();
            DataTable Test_Dt = new DataTable();
            //if (Box_Type != 1 || Box_Type != 4)
            //{
            string Sql = "select * from View_Select_All_Inbox_OutBox where ProjID = " + Session_CS.Project_id.ToString() + "Order by Convert_date";
            DataTable DT = SqlHelper.ExecuteDataset(Database.ConnectionString, CommandType.Text, Sql).Tables[0];

            foreach (DataColumn DT_Column in DT.Columns)
            {
                DataColumn obj_Colm = new DataColumn();
                obj_Colm.ColumnName = DT_Column.ColumnName;
                OutDt.Columns.Add(obj_Colm);
                DataColumn Test_obj_Colm = new DataColumn();
                Test_obj_Colm.ColumnName = DT_Column.ColumnName;
                Test_Dt.Columns.Add(Test_obj_Colm);
            }
            DataRow[] DR = DT.Select("id =" + ID + " and Main_Type=" + Main_Type);
            OutDt.ImportRow(DR[0]);
            Fil_OutDT(OutDt, DT, ID, Box_Type);
            if (Reply_ID > 0)
            {
                if (Box_Type == 1 || Box_Type == 3 || Box_Type == 2 || Box_Type == 5)
                    Main_Type = 1;
                else
                    Main_Type = 2;
                DataRow[] DR_reply = DT.Select("id =" + Reply_ID + " and Main_Type=" + Main_Type);
                if (DR_reply.Length > 0)
                {
                    if (chek_Row_Exit(OutDt, DR_reply[0]))
                    {
                        OutDt.ImportRow(DR_reply[0]);
                        Fil_OutDT(OutDt, DT, Reply_ID, CDataConverter.ConvertToInt(DR_reply[0]["type"]));
                    }
                }
            }

            foreach (DataRow  DR_Test in OutDt.Rows)
            {
                Test_Dt.ImportRow(DR_Test);
            }

            foreach (DataRow DR_New in Test_Dt.Rows)
            {
                int Next_ID = CDataConverter.ConvertToInt(DR_New["Reply_ID"].ToString());
                //if(Next_ID ==0)
                //    Next_ID = CDataConverter.ConvertToInt(DR_New["ID"].ToString());
                Fil_OutDT_ID(OutDt, DT, Next_ID, CDataConverter.ConvertToInt(DR_New["type"].ToString()));
            }
            //}

            GridView1.Visible = true;
            GridView1.DataSource = DT;
            GridView1.DataBind();
        }
    }

    private bool chek_Row_Exit(DataTable OutDt, DataRow dataRow)
    {
        DataRow[] DR = OutDt.Select("id =" + dataRow["ID"] + " and type=" + dataRow["type"]);
        if (DR.Length > 0)
            return false;

        else
            return true;
    }

    private void Fil_OutDT(DataTable OutDt, DataTable InDT, int ID, int Box_Type)
    {
        int Main_Type;
        if (Box_Type == 1 || Box_Type == 3 || Box_Type == 5)
            Main_Type = 1;
        else
            Main_Type = 2;

        DataRow[] DR = InDT.Select("Reply_ID =" + ID + " and Main_Type=" + Main_Type);
        if (DR.Length > 0)
        {
            for (int i = 0; i < DR.Length; i++)
            {
                int Next_Id = CDataConverter.ConvertToInt(DR[i]["id"]);
                int type = CDataConverter.ConvertToInt(DR[i]["type"]);
               // DR[i]["DED"] = "true";
                //InDT.Rows[InDT.Rows.IndexOf(DR[i])].Delete();
                if (chek_Row_Exit(OutDt, DR[i]))
                    OutDt.ImportRow(DR[i]);
                Fil_OutDT(OutDt, InDT, Next_Id, type);
               
            }
        }
      }

    private void Fil_OutDT_ID(DataTable OutDt, DataTable InDT, int ID, int Box_Type)
    {
        int Main_Type;
        if (Box_Type == 1 || Box_Type == 3 || Box_Type ==2)
            Main_Type = 1;
        else
            Main_Type = 2;

        DataRow[] DR = InDT.Select("ID =" + ID + " and Main_Type=" + Main_Type);
        if (DR.Length > 0)
        {
            for (int i = 0; i < DR.Length; i++)
            {
                int Next_Id = CDataConverter.ConvertToInt(DR[i]["id"]);
                int type = CDataConverter.ConvertToInt(DR[i]["type"]);
                // DR[i]["DED"] = "true";
                //InDT.Rows[InDT.Rows.IndexOf(DR[i])].Delete();
                if (chek_Row_Exit(OutDt, DR[i]))
                    OutDt.ImportRow(DR[i]);
                //Fil_OutDT_ID(OutDt, InDT, Next_Id, type);
            }
        }
    }



    public string Get_Type(object obj)
    {
        string str = obj.ToString();
        if (str == "1")
            return "وارد جديد";
        else if (str == "2")
            return "رد على صادر";
        else if (str == "3")
            return "استعجال وارد";
        else if (str == "4")
            return "صادر جديد";
        else if (str == "5")
            return "رد على وارد";
        else if (str == "6")
            return "استعجال صادر";
        else return "وارد";
    }
}
