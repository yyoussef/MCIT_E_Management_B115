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
using VB_Classes;
using VB_Classes.Dates;
using System.IO;
using System.Text;
using System.Data.SqlClient;

public partial class UserControls_Fin_Bills : System.Web.UI.UserControl
{
    General_Helping Obj_General_Helping = new General_Helping();
    private string sql_Connection = Database.ConnectionString;
    Session_CS Session_CS = new Session_CS();
    protected override void OnInit(EventArgs e)
    {
        #region BROWSER FOR departments

        Smart_Project_ID.sql_Connection = sql_Connection;
       // Smart_Project_ID.Query = "SELECT Proj_id, Proj_Title FROM Project";
        string Query = "SELECT Proj_id, Proj_Title FROM Project";
        Smart_Project_ID.datatble = General_Helping.GetDataTable(Query);
        Smart_Project_ID.Value_Field = "Proj_id";
        Smart_Project_ID.Text_Field = "Proj_Title";
        Smart_Project_ID.DataBind();
        this.Smart_Project_ID.Value_Handler += new Smart_Search.Delegate_Selected_Value(MOnMember_Data);
        //Inbox_organization.SelectedValue;


        #endregion
        base.OnInit(e);
    }
    private void MOnMember_Data(string Value)
    {
        if (Value != "")
        {
            Fil_Dll();
            pnl_bil.Visible = true;
            //Fil_Grid_bil();

            //int remain = 0;
            //DataTable dtbil = General_Helping.GetDataTable("SELECT  Fin_Work_Order.Work_Order_ID, convert(int,Fin_Work_Order.Work_Total_Value) as Work_Total_Value, convert(int,SUM(Fin_Bills.Bil_Value)) AS bil_total_value, Fin_Bills.Project_ID FROM Fin_Work_Order LEFT OUTER JOIN   Fin_Bills ON Fin_Work_Order.Work_Order_ID = Fin_Bills.Work_Order_ID where Fin_Work_Order.Project_ID = " + CDataConverter.ConvertToInt(Smart_Project_ID.SelectedValue) + "  GROUP BY Fin_Work_Order.Work_Order_ID, Fin_Work_Order.Work_Total_Value, Fin_Work_Order.Project_ID, Fin_Bills.Project_ID");
            //if (dtbil.Rows[0]["bil_total_value"] == "")
            //{
            //    remain = CDataConverter.ConvertToInt(dtbil.Rows[0]["Work_Total_Value"].ToString());
            //}
            //else
            //    remain = CDataConverter.ConvertToInt(dtbil.Rows[0]["Work_Total_Value"].ToString()) - CDataConverter.ConvertToInt(dtbil.Rows[0]["bil_total_value"].ToString());
            //lblval.Text = remain.ToString();


        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session_CS.Project_id != null && CDataConverter.ConvertToInt(Session_CS.Project_id.ToString()) > 0)
            {
                tr_Smart_Project.Visible = false;
                Smart_Project_ID.SelectedValue = Session_CS.Project_id.ToString();
                MOnMember_Data(Session_CS.Project_id.ToString());



            }
        }
    }

    private void Fil_Dll()
    {
        DataTable DT3 = new DataTable();
        DT3 = General_Helping.GetDataTable("select * from Needs_Main_Type ");
        Obj_General_Helping.SmartBindDDL(ddl_NMT_ID, DT3, "NMT_ID", "NMT_Desc", "....اختر البند الرئيسى ....");

        DataTable DT = new DataTable();
        DT = General_Helping.GetDataTable("select Work_Order_ID ,Code, (convert(nvarchar, Work_Total_Value)+'---------'+Date ) as name from Fin_Work_Order where Project_ID =" + Smart_Project_ID.SelectedValue);
        Obj_General_Helping.SmartBindDDL(ddl_Work_Order, DT, "Work_Order_ID", "Code", "....اختر رقم أمر التوريد ....");


        string qryStr = "";

        DateTime dtime = DateTime.Today;
        string currentYear = dtime.ToString("yyyy");
        int currentYearInt;
        currentYearInt = Convert.ToInt16(currentYear);
        DataTable dt5;
        //int cMonth = DateTime.Now.Month;
        int cMonth = CDataConverter.ConvertDateTimeNowRtnDt().Month ;
        if (cMonth < 7)
        {
            currentYearInt = currentYearInt - 1;
        }
        currentYear = currentYearInt.ToString();

        string sql = "SELECT     Project_Funding_Sources.Sources_ID, Project_Funding_Sources.Source_Name " +
                            "FROM         Project_Funding_Sources INNER JOIN " +
                            "Project_Period_Sources ON Project_Funding_Sources.Sources_ID = Project_Period_Sources.Sources_ID INNER JOIN " +
                            "Project_Period_Balance ON Project_Period_Sources.Period_ID = Project_Period_Balance.Period_ID " +
                            "WHERE     (Project_Period_Balance.Proj_id = " + Session_CS.Project_id + ") AND (Project_Period_Balance.Quarter_Year = '" + currentYear + "') " +
                            "GROUP BY Project_Funding_Sources.Sources_ID, Project_Funding_Sources.Source_Name";
        DataTable qrtrData = General_Helping.GetDataTable(sql);
        Obj_General_Helping.SmartBindDDL(ddl_Source, qrtrData, "Sources_ID", "Source_Name", "....اختر مصدر التمويل......");
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        //if ( CDataConverter.ConvertToDecimal(txt_Bil_Value.Text) + CDataConverter.ConvertToDecimal(txt_bils_Totala_hidden.Text) <= CDataConverter.ConvertToDecimal(lbl_Work_Total_Value.Text))
        //{
        int operation;
        if (CDataConverter.ConvertToInt(hidden_Bil_ID.Value) == 0)
            operation = (int)Project_Log_DB.Action.add;
        else
            operation = (int)Project_Log_DB.Action.edit;
        int tot = 0;
        //Fin_Bills_DT objtot = new Fin_Bills_DT();
        //objtot = Fin_Bills_DB.Selectvaluebill(CDataConverter.ConvertToInt(Smart_Project_ID.SelectedValue));
        DataTable dtbil = General_Helping.GetDataTable("SELECT  Fin_Work_Order.Work_Order_ID, convert(int,Fin_Work_Order.Work_Total_Value) as Work_Total_Value, convert(int,SUM(Fin_Bills.Bil_Value)) AS bil_total_value, Fin_Bills.Project_ID,convert(int, Fin_Work_Order.Work_Total_Value)-convert(int, SUM(Fin_Bills.Bil_Value)) as sub FROM Fin_Work_Order left outer JOIN  Fin_Bills ON Fin_Work_Order.Work_Order_ID = Fin_Bills.Work_Order_ID where Fin_Work_Order.Project_ID = " + CDataConverter.ConvertToInt(Smart_Project_ID.SelectedValue) + " and Fin_Work_Order.Work_Order_ID = " + CDataConverter.ConvertToInt(ddl_Work_Order.SelectedValue) + " GROUP BY Fin_Work_Order.Work_Order_ID, Fin_Work_Order.Work_Total_Value, Fin_Work_Order.Project_ID, Fin_Bills.Project_ID");
        if (dtbil.Rows[0]["bil_total_value"] == "")
        {
            tot = CDataConverter.ConvertToInt(txt_Bil_Value.Text);
        }
        else
            tot = CDataConverter.ConvertToInt(dtbil.Rows[0]["bil_total_value"].ToString()) + CDataConverter.ConvertToInt(txt_Bil_Value.Text);

        if (hidden_Bil_ID.Value == "")
        {
            if (tot > CDataConverter.ConvertToInt(dtbil.Rows[0]["Work_Total_Value"].ToString()))
            {
                Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('إجمالي قيمة الفواتير تتعدي قيمة امر التوريد')</script>");
                return;
            }

        }
        else
        {
            DataTable dtbillupdate = General_Helping.GetDataTable("SELECT  Fin_Work_Order.Work_Order_ID, convert(int,Fin_Work_Order.Work_Total_Value) as Work_Total_Value , convert(int,SUM(Fin_Bills.Bil_Value)) AS bil_total_value, Fin_Bills.Project_ID FROM Fin_Work_Order INNER JOIN  Fin_Bills ON Fin_Work_Order.Work_Order_ID = Fin_Bills.Work_Order_ID where Fin_Bills.Project_ID = " + CDataConverter.ConvertToInt(Smart_Project_ID.SelectedValue) + " and Bil_ID <> " + hidden_Bil_ID.Value + " and Fin_Work_Order.Work_Order_ID = " + CDataConverter.ConvertToInt(ddl_Work_Order.SelectedValue) + "  GROUP BY Fin_Work_Order.Work_Order_ID, Fin_Work_Order.Work_Total_Value, Fin_Work_Order.Project_ID, Fin_Bills.Project_ID");
            int totupdate = CDataConverter.ConvertToInt(dtbillupdate.Rows[0]["bil_total_value"].ToString()) + CDataConverter.ConvertToInt(txt_Bil_Value.Text);
            if (totupdate > CDataConverter.ConvertToInt(dtbillupdate.Rows[0]["Work_Total_Value"].ToString()))
            {
                Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('إجمالي قيمة الفواتير تتعدي قيمة امر التوريد')</script>");
                return;
            }
        }

        if (Check_bil_dtl_Value())
        {
            Fin_Bills_DT obj = new Fin_Bills_DT();

            obj.Bil_ID = CDataConverter.ConvertToInt(hidden_Bil_ID.Value);
            obj.Work_Order_ID = CDataConverter.ConvertToInt(ddl_Work_Order.SelectedValue);
            obj.Code = txt_Code.Text;
            obj.Date = VB_Classes.Dates.Dates_Operation.date_validate(txt_Date.Text);
            obj.Notes = txt_Notes.Text;
            obj.Bil_Value = CDataConverter.ConvertToDecimal(txt_Bil_Value.Text);
            obj.Bil_Percent = CDataConverter.ConvertToInt(txt_Bil_Percent.Text);
            obj.Type = CDataConverter.ConvertToInt(ddl_Type.SelectedValue);
            obj.Project_ID = CDataConverter.ConvertToInt(Smart_Project_ID.SelectedValue);
            obj.Source_id = CDataConverter.ConvertToInt(ddl_Source.SelectedValue);
            obj.Provider_id = CDataConverter.ConvertToInt(ddl_Provider.SelectedValue);


            obj.Bil_ID = Fin_Bills_DB.Save(obj);

            hidden_Bil_ID.Value = obj.Bil_ID.ToString();

            SaveBil_Dtl(obj);
            Fil_Grid_bil();


            Project_Log_DB.FillLog(CDataConverter.ConvertToInt(hidden_Bil_ID.Value), operation, Project_Log_DB.operation.Fin_Bills);
            // Clear_Cntrl();
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم الحفظ بنجاح')</script>");
            //int sub = CDataConverter.ConvertToInt(dtbil.Rows[0]["sub"].ToString());


            //lblval.Text = sub.ToString();

        }
        else
        {
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('قيمة الفاتورة لا يساوى اجمالى القيم التى فى تفاصيل الفاتورة')</script>");

        }
        //}
        //else
        //{
        //    Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('إجمالى الفواتير يتعدى المبلغ المحدد فى امر التوريد')</script>");

        //}
        string sql = "SELECT Fin_Work_Order.Work_Order_ID, CONVERT(int, Fin_Work_Order.Work_Total_Value) AS Work_Total_Value,";
        sql += " CONVERT(int, Fin_Bills.Bil_Value) as Bil_Value, Fin_Work_Order.Project_ID,";
        sql += " Fin_Bills.Bil_ID FROM Fin_Work_Order INNER JOIN Fin_Bills ON Fin_Work_Order.Work_Order_ID = Fin_Bills.Work_Order_ID ";
        sql += " where Fin_Work_Order.Work_Order_ID = " + CDataConverter.ConvertToInt( ddl_Work_Order.SelectedValue);
        sql += " and Fin_Work_Order.Project_ID = " + CDataConverter.ConvertToInt( Smart_Project_ID.SelectedValue);
        sql += " GROUP BY Fin_Work_Order.Work_Order_ID, Fin_Work_Order.Work_Total_Value, Fin_Work_Order.Project_ID, Fin_Bills.Project_ID, Fin_Bills.Bil_ID,Bil_Value";
        DataTable dt = General_Helping.GetDataTable(sql);
        int totv = 0;
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            totv += CDataConverter.ConvertToInt(dt.Rows[i]["Bil_Value"].ToString());
        }
        int total_work = CDataConverter.ConvertToInt(dt.Rows[0]["Work_Total_Value"].ToString());
        int sub = total_work - totv;
        lblval.Text = sub.ToString();

    }

    bool Check_bil_dtl_Value()
    {
        decimal Total_Value = 0;
        foreach (GridViewRow grdrow in grdView_Bil_Dtl.Rows)
        {
            if (grdrow.Visible)
            {
                Fin_Bills_Dtl_DT obj = new Fin_Bills_Dtl_DT();
                obj.Quantity = CDataConverter.ConvertToInt(((TextBox)grdrow.FindControl("txt_Quantity")).Text);
                obj.unit_value = CDataConverter.ConvertToDecimal(((TextBox)grdrow.FindControl("txt_unit_value")).Text);
                obj.Total_Value = obj.Quantity * obj.unit_value;
                Label lbl_Total_Value = (Label)grdrow.FindControl("lbl_Total_Value");
                Total_Value += obj.Total_Value;
            }
        }
        if (Total_Value == 0 || Total_Value == CDataConverter.ConvertToDecimal(txt_Bil_Value.Text))
            return true;
        else
            return false;

    }
    protected void btn_New_Click(object sender, EventArgs e)
    {
        Clear_Cntrl();
        Fil_Grd_Dtl_Init(Get_Bil_Dtl_Init());
        GrdView_Documents.DataBind();
        GridView_Needs.DataBind();
    }
    private void SaveBil_Dtl(Fin_Bills_DT obj_Fin_Bil)
    {
        decimal Total_Value = 0;
        foreach (GridViewRow grdrow in grdView_Bil_Dtl.Rows)
        {
            if (grdrow.Visible)
            {
                Fin_Bills_Dtl_DT obj = new Fin_Bills_Dtl_DT();
                TextBox txt_Bil_Dtl_ID = (TextBox)grdrow.FindControl("txt_Bil_Dtl_ID");
                obj.Bil_Dtl_ID = CDataConverter.ConvertToInt(txt_Bil_Dtl_ID.Text);
                obj.Bil_ID = obj_Fin_Bil.Bil_ID;
                obj.PActv_ID = CDataConverter.ConvertToInt(((TextBox)grdrow.FindControl("txt_PActv_ID")).Text);
                obj.Notes = ((TextBox)grdrow.FindControl("txt_Notes")).Text;
                obj.Quantity = CDataConverter.ConvertToInt(((TextBox)grdrow.FindControl("txt_Quantity")).Text);
                obj.unit_value = CDataConverter.ConvertToDecimal(((TextBox)grdrow.FindControl("txt_unit_value")).Text);
                obj.Total_Value = obj.Quantity * obj.unit_value;
                Label lbl_Total_Value = (Label)grdrow.FindControl("lbl_Total_Value");
                Total_Value += obj.Total_Value;
                lbl_Total_Value.Text = obj.Total_Value.ToString();

                txt_Bil_Dtl_ID.Text = Fin_Bills_Dtl_DB.Save(obj).ToString();
            }
        }

        //obj_Fin_Bil.Bil_Value = Total_Value;
        //txt_Bil_Value.Text = Total_Value.ToString();
        //Fin_Bills_DB.Save(obj_Fin_Bil);
        if (CDataConverter.ConvertToInt(ddl_Type.SelectedValue) == 1 && CDataConverter.ConvertToInt(ddl_Work_Order.SelectedValue) > 0)
        {
            Fin_Work_Order_DT obj_fin_work = Fin_Work_Order_DB.SelectByID(CDataConverter.ConvertToInt(ddl_Work_Order.SelectedValue));
            obj_fin_work.Bil_Total_Value += CDataConverter.ConvertToDecimal(txt_Bil_Value.Text);
            Fin_Work_Order_DB.Save(obj_fin_work);
            txt_bils_Totala_hidden.Text = txt_bils_Totala2.Text = obj_fin_work.Bil_Total_Value.ToString();
        }



    }



    protected void grdView_Bil_Dtl_RowCommand(object sender, GridViewCommandEventArgs e)
    {


        if (e.CommandName == "RemoveItem")
        {
            int Id = CDataConverter.ConvertToInt(e.CommandArgument);
            if (Id > 0)
            {
                Fin_Bills_Dtl_DB.Delete(Id);
                GridViewRow row = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
                Label lbl_Total_Value = (Label)row.FindControl("lbl_Total_Value");

                Fin_Bills_DT obj_Bil = Fin_Bills_DB.SelectByID(CDataConverter.ConvertToInt(hidden_Bil_ID.Value));
                obj_Bil.Bil_Value -= CDataConverter.ConvertToDecimal(lbl_Total_Value.Text);
                Fin_Bills_DB.Save(obj_Bil);
                if (CDataConverter.ConvertToInt(ddl_Work_Order.SelectedValue) > 0)
                {
                    Fin_Work_Order_DT obj_work = Fin_Work_Order_DB.SelectByID(CDataConverter.ConvertToInt(ddl_Work_Order.SelectedValue));
                    obj_work.Bil_Total_Value -= CDataConverter.ConvertToDecimal(lbl_Total_Value.Text);
                    Fin_Work_Order_DB.Save(obj_work);
                    txt_bils_Totala2.Text = txt_bils_Totala_hidden.Text = obj_work.Bil_Total_Value.ToString();

                }
                txt_Bil_Value.Text = obj_Bil.Bil_Value.ToString();

                Fil_grd_bil_dtl();
                Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم الحذف بنجاح')</script>");

            }
            else
            {
                //   grdView_Bil_Dtl.DeleteRow(grdView_Bil_Dtl.SelectedIndex);
                GridViewRow row = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
                TextBox txt_PActv_ID = (TextBox)row.FindControl("txt_PActv_ID");
                grdView_Bil_Dtl.Rows[row.RowIndex].Visible = false;
                //grdView_Bil_Dtl.DeleteRow(row.RowIndex);
                //DataTable dt = (DataTable)grdView_Bil_Dtl.DataSource;
                //for (int i = 0; i <= dt.Rows.Count; i++)
                //{
                //    if (dt.Rows[i]["PActv_ID"].ToString() == txt_PActv_ID.Text)
                //    {
                //        dt.Rows[i].Delete();
                //        break;
                //    }
                //}
                //Fil_Grd_Dtl_Init(dt);
                Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم الحذف بنجاح')</script>");
            }


        }

    }

    protected void GridView_Bil_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditItem")
        {
            foreach (GridViewRow grdrow in GridView_Bil.Rows)
            {
                grdrow.BackColor = System.Drawing.Color.White;

            }
            Fill_Controll(CDataConverter.ConvertToInt(e.CommandArgument));
            //lbl_Work_Total_Value.Text = (CDataConverter.ConvertToDecimal(lbl_Work_Total_Value.Text) - CDataConverter.ConvertToDecimal(txt_Bil_Value.Text)).ToString();
            txt_bils_Totala_hidden.Text = (CDataConverter.ConvertToDecimal(txt_bils_Totala_hidden.Text) - CDataConverter.ConvertToDecimal(txt_Bil_Value.Text)).ToString();
            Fil_grd_bil_dtl();
            Fil_Grid_Documents();
            Fil_Grd_Needs();
            GridViewRow row = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
            row.BackColor = System.Drawing.Color.FromArgb(255, 255, 153);
        }
        if (e.CommandName == "RemoveItem")
        {
            Fin_Bills_DB.Delete(CDataConverter.ConvertToInt(e.CommandArgument));

            GridViewRow row = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);

            Label lbl_Type = (Label)row.FindControl("lbl_Type");
            Label lbl_Bil_Value = (Label)row.FindControl("lbl_Bil_Value");

            if (lbl_Type.Text == "1" && CDataConverter.ConvertToInt(ddl_Work_Order.SelectedValue) > 0)
            {
                decimal Total_Value = CDataConverter.ConvertToDecimal(lbl_Bil_Value.Text);
                Fin_Work_Order_DT obj_fin_work = Fin_Work_Order_DB.SelectByID(CDataConverter.ConvertToInt(ddl_Work_Order.SelectedValue));
                obj_fin_work.Bil_Total_Value -= Total_Value;
                Fin_Work_Order_DB.Save(obj_fin_work);
                txt_bils_Totala_hidden.Text = txt_bils_Totala2.Text = obj_fin_work.Bil_Total_Value.ToString();
            }
            Fil_Grid_bil();

            DataTable dtbil = General_Helping.GetDataTable("SELECT  Fin_Work_Order.Work_Order_ID, convert(int,Fin_Work_Order.Work_Total_Value) as Work_Total_Value, convert(int,SUM(Fin_Bills.Bil_Value)) AS bil_total_value, Fin_Bills.Project_ID,convert(int, Fin_Work_Order.Work_Total_Value)-convert(int, SUM(Fin_Bills.Bil_Value)) as sub FROM Fin_Work_Order LEFT OUTER JOIN   Fin_Bills ON Fin_Work_Order.Work_Order_ID = Fin_Bills.Work_Order_ID where Fin_Work_Order.Project_ID = " + CDataConverter.ConvertToInt(Smart_Project_ID.SelectedValue) + " and Fin_Work_Order.Work_Order_ID =  " + CDataConverter.ConvertToInt(ddl_Work_Order.SelectedValue) + " GROUP BY Fin_Work_Order.Work_Order_ID, Fin_Work_Order.Work_Total_Value, Fin_Work_Order.Project_ID, Fin_Bills.Project_ID");

            int remain = CDataConverter.ConvertToInt(dtbil.Rows[0]["sub"].ToString());
            lblval.Text = remain.ToString();

        }
    }



    private void Fill_Controll(int ID)
    {

        Fin_Bills_DT obj = Fin_Bills_DB.SelectByID(ID);
        hidden_Bil_ID.Value = obj.Bil_ID.ToString();
        if (obj.Work_Order_ID > 0)
            ddl_Work_Order.SelectedValue = obj.Work_Order_ID.ToString();
        txt_Code.Text = obj.Code;
        txt_Date.Text = obj.Date;
        txt_Notes.Text = obj.Notes;
        txt_Bil_Value.Text = obj.Bil_Value.ToString();
        txt_Bil_Percent.Text = obj.Bil_Percent.ToString();
        ddl_Type.SelectedValue = obj.Type.ToString();
        if (obj.Source_id > 0)
        {
            ddl_Source.SelectedValue = obj.Source_id.ToString();
            GetDataSetProvider(CDataConverter.ConvertToInt(ddl_Source.SelectedValue));
            if (obj.Provider_id > 0)
                ddl_Provider.SelectedValue = obj.Provider_id.ToString();
        }
    }

    void Clear_Cntrl()
    {
        txt_Code.Text =
        txt_Date.Text =
        hidden_Bil_ID.Value =
        txt_Notes.Text =
        txt_Bil_Percent.Text =
        txt_Bil_Value.Text = "";


    }





    void Fil_Grid_bil()
    {
        GridView_Bil.DataSource = Fin_Bills_DB.SelectAll_by_Project_ID(CDataConverter.ConvertToInt(Smart_Project_ID.SelectedValue), CDataConverter.ConvertToInt(ddl_Work_Order.SelectedValue));
        GridView_Bil.DataBind();
    }

    void Fil_Grd_Dtl_Init(DataTable DT)
    {
        grdView_Bil_Dtl.DataSource = DT;
        grdView_Bil_Dtl.DataBind();

    }

    DataTable Get_Bil_Dtl_Init()
    {
        if (CDataConverter.ConvertToInt(ddl_Work_Order.SelectedValue) > 0)
            return Fin_Bills_Dtl_DB.SelectAll_init(CDataConverter.ConvertToInt(ddl_Work_Order.SelectedValue));
        else
            return new DataTable();
    }


    private void Fil_grd_bil_dtl()
    {
        grdView_Bil_Dtl.DataSource = Fin_Bills_Dtl_DB.SelectAll_Grid(CDataConverter.ConvertToInt(hidden_Bil_ID.Value));
        grdView_Bil_Dtl.DataBind();
    }
    protected void grdView_Bil_Dtl_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        // grdView_Bil_Dtl.DeleteRow(e.RowIndex);
        //grdView_Bil_Dtl.DataBind();

    }


    protected void btn_Doc_Click(object sender, EventArgs e)
    {
        if (CDataConverter.ConvertToInt(hidden_Bil_ID.Value) > 0)
        {
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

                if (CDataConverter.ConvertToInt(hidden_File_ID.Value) > 0)
                {
                    SqlCommand cmd = new SqlCommand();
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = " update Fin_Work_bill_Files set File_data=@File_data ,File_Desc=@File_Desc,File_name=@File_name,File_ext=@File_ext where File_ID =@File_ID";


                    cmd.Parameters.Add("@File_data", SqlDbType.VarBinary);
                    cmd.Parameters.Add("@File_ID", SqlDbType.Int);
                    cmd.Parameters.Add("@File_name", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@File_Desc", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@File_ext", SqlDbType.NVarChar);

                    cmd.Parameters["@File_data"].Value = Input;
                    cmd.Parameters["@File_ID"].Value = CDataConverter.ConvertToInt(hidden_File_ID.Value);
                    cmd.Parameters["@File_ext"].Value = type;
                    cmd.Parameters["@File_Desc"].Value = txt_File_Desc.Text;
                    cmd.Parameters["@File_name"].Value = txtFileName.Text;

                    con.Open();
                    cmd.ExecuteScalar();

                    con.Close();
                    txtFileName.Text =
                        txt_File_Desc.Text =
                    hidden_File_ID.Value = "";

                }
                else
                {
                    SqlCommand cmd = new SqlCommand();
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = " insert into Fin_Work_bill_Files ( Work_Or_Bill_ID,  Work_Or_Bill, File_data, File_name, File_ext,File_Desc) VALUES " +
                                                                        "( @Work_Or_Bill_ID,@Work_Or_Bill, @File_data, @File_name, @File_ext,@File_Desc)";


                    cmd.Parameters.Add("@File_data", SqlDbType.VarBinary);
                    cmd.Parameters.Add("@Work_Or_Bill", SqlDbType.Int);
                    cmd.Parameters.Add("@Work_Or_Bill_ID", SqlDbType.Int);
                    cmd.Parameters.Add("@File_name", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@File_ext", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@File_Desc", SqlDbType.NVarChar);


                    cmd.Parameters["@File_data"].Value = Input;
                    cmd.Parameters["@Work_Or_Bill_ID"].Value = CDataConverter.ConvertToInt(hidden_Bil_ID.Value);
                    cmd.Parameters["@Work_Or_Bill"].Value = 2;
                    cmd.Parameters["@File_ext"].Value = type;
                    cmd.Parameters["@File_Desc"].Value = txt_File_Desc.Text;
                    cmd.Parameters["@File_name"].Value = txtFileName.Text;

                    con.Open();
                    cmd.ExecuteScalar();

                    con.Close();
                    txtFileName.Text =
                        txt_File_Desc.Text =
                    hidden_File_ID.Value = "";

                }



            }





            // Clear_Cntrl();
            Fil_Grid_Documents();
            Fil_Grd_Needs();
        }
        else
        {
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('يجب إدخال بيانات الفاتورة أولا')</script>");

        }

    }

    protected void GrdView_Documents_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditItem")
        {
            DataTable DT = General_Helping.GetDataTable("select * from Fin_Work_bill_Files where File_ID=" + CDataConverter.ConvertToInt(e.CommandArgument));
            if (DT.Rows.Count > 0)
            {
                hidden_File_ID.Value = DT.Rows[0]["File_ID"].ToString();
                txtFileName.Text = DT.Rows[0]["File_name"].ToString();
                txt_File_Desc.Text = DT.Rows[0]["File_Desc"].ToString();

            }

        }

        if (e.CommandName == "RemoveItem")
        {
            General_Helping.ExcuteQuery("delete from Fin_Work_bill_Files where File_ID=" + CDataConverter.ConvertToInt(e.CommandArgument));
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم الحذف بنجاح')</script>");
            Fil_Grid_Documents();
        }
    }

    private void Fil_Grid_Documents()
    {

        DataTable DT = new DataTable();
        DT = General_Helping.GetDataTable("select * from Fin_Work_bill_Files where Work_Or_Bill = 2 and Work_Or_Bill_ID =" + CDataConverter.ConvertToInt(hidden_Bil_ID.Value));

        GrdView_Documents.DataSource = DT;
        GrdView_Documents.DataBind();
    }

    protected void txt_Bil_Percent_TextChanged(object sender, EventArgs e)
    {
        if (CDataConverter.ConvertToInt(txt_Bil_Percent.Text) > 0 && CDataConverter.ConvertToDecimal(lbl_Work_Total_Value.Text) > 0)
        {
            txt_Bil_Value.Text = CDataConverter.ConvertToDecimal(((CDataConverter.ConvertToInt(txt_Bil_Percent.Text) * CDataConverter.ConvertToDecimal(lbl_Work_Total_Value.Text)) / 100)).ToString();
        }

    }
    public string Get_Type(object obj)
    {
        string str = obj.ToString();
        if (str == "1")
            return "فاتورة";
        else if (str == "2")
            return "إشعار خصم";
        else return "";
    }

    protected void ddl_NMT_ID_SelectedIndexChanged(object sender, EventArgs e)
    {

        Fil_dll_nmt();
        TabPanel_All.ActiveTab = TabPanel_Needs;


    }

    protected void ddl_Work_Order_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (CDataConverter.ConvertToInt(ddl_Work_Order.SelectedValue) > 0)
        {
            Fin_Work_Order_DT obj = Fin_Work_Order_DB.SelectByID(CDataConverter.ConvertToInt(ddl_Work_Order.SelectedValue));
            txt_bils_Totala_hidden.Text = txt_bils_Totala2.Text = obj.Bil_Total_Value.ToString();
            lbl_Work_Total_Value.Text = obj.Work_Total_Value.ToString();
            Fil_Grid_bil();
            Fil_Grd_Dtl_Init(Get_Bil_Dtl_Init());
            int remain = 0;
            Label12.Visible = true;
            lblval.Visible = true;
            DataTable dtbil = General_Helping.GetDataTable("SELECT  Fin_Work_Order.Work_Order_ID, convert(int,Fin_Work_Order.Work_Total_Value) as Work_Total_Value, convert(int,SUM(Fin_Bills.Bil_Value)) AS bil_total_value, Fin_Bills.Project_ID,convert(int, Fin_Work_Order.Work_Total_Value)-convert(int, SUM(Fin_Bills.Bil_Value)) as sub FROM Fin_Work_Order LEFT OUTER JOIN   Fin_Bills ON Fin_Work_Order.Work_Order_ID = Fin_Bills.Work_Order_ID where Fin_Work_Order.Project_ID = " + CDataConverter.ConvertToInt(Smart_Project_ID.SelectedValue) + " and Fin_Work_Order.Work_Order_ID =  " + CDataConverter.ConvertToInt(ddl_Work_Order.SelectedValue) + " GROUP BY Fin_Work_Order.Work_Order_ID, Fin_Work_Order.Work_Total_Value, Fin_Work_Order.Project_ID, Fin_Bills.Project_ID");
            //if (dtbil.Rows[0]["bil_total_value"]=="")
            //{
            //    remain = CDataConverter.ConvertToInt(dtbil.Rows[0]["Work_Total_Value"].ToString());
            //}
            //else
            remain = CDataConverter.ConvertToInt(dtbil.Rows[0]["sub"].ToString());
            lblval.Text = remain.ToString();


        }


    }



    private void Fil_dll_nmt()
    {
        DataTable DT = new DataTable();
        DT = General_Helping.GetDataTable("select * from Needs_Sup_Type where nmt_nmt_id=" + ddl_NMT_ID.SelectedValue);
        Obj_General_Helping.SmartBindDDL(ddl_NST_ID, DT, "NST_ID", "NST_Desc", "....اختر البند الفرعى ....");
    }

    protected void btn_Needs_Click(object sender, EventArgs e)
    {
        if (CDataConverter.ConvertToInt(hidden_Bil_ID.Value) > 0)
        {
            Fin_Work_bill_Needs_DT obj = new Fin_Work_bill_Needs_DT();
            obj.Fin_Need_ID = CDataConverter.ConvertToInt(hidden_Fin_Need_ID.Value);
            obj.NMT_ID = CDataConverter.ConvertToInt(ddl_NMT_ID.SelectedValue);
            obj.NST_ID = CDataConverter.ConvertToInt(ddl_NST_ID.SelectedValue);
            obj.Value = CDataConverter.ConvertToInt(txt_Value.Text);
            obj.Work_Or_Bill = 2;
            obj.Work_Or_Bill_ID = CDataConverter.ConvertToInt(hidden_Bil_ID.Value);
            Fin_Work_bill_Needs_DB.Save(obj);
            txt_Value.Text = "";
            Fil_Grd_Needs();

        }
        else
        {
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('يجب إدخال بيانات الفاتورة أولا')</script>");


        }
    }


    protected void GridView_Needs_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditItem")
        {
            Fin_Work_bill_Needs_DT obj = Fin_Work_bill_Needs_DB.SelectByID(CDataConverter.ConvertToInt(e.CommandArgument));
            hidden_Fin_Need_ID.Value = obj.Fin_Need_ID.ToString();
            ddl_NMT_ID.SelectedValue = obj.NMT_ID.ToString();
            Fil_dll_nmt();
            ddl_NST_ID.SelectedValue = obj.NST_ID.ToString();
            txt_Value.Text = obj.Value.ToString();


        }

        if (e.CommandName == "RemoveItem")
        {
            Fin_Work_bill_Needs_DB.Delete(CDataConverter.ConvertToInt(e.CommandArgument));
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم الحذف بنجاح')</script>");
            Fil_Grd_Needs();
        }
    }
    private void Fil_Grd_Needs()
    {
        GridView_Needs.DataSource = Fin_Work_bill_Needs_DB.SelectAll_by_Parent_id(CDataConverter.ConvertToInt(hidden_Bil_ID.Value), 2);
        GridView_Needs.DataBind();
    }

    protected void ddl_Source_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetDataSetProvider(CDataConverter.ConvertToInt(ddl_Source.SelectedValue));
    }

    private void GetDataSetProvider(int ID)
    {
        string qryStr = "";
        DataTable qrtrData;
        DateTime dtime = DateTime.Today;

        string currentYear = dtime.ToString("yyyy");
        int currentYearInt;
        currentYearInt = Convert.ToInt16(currentYear);
        DataTable dt5;
       // int cMonth = DateTime.Now.Month;

        int cMonth = CDataConverter.ConvertDateTimeNowRtnDt().Month ;

        if (cMonth < 7)
        {
            currentYearInt = currentYearInt - 1;
        }
        currentYear = currentYearInt.ToString();
        string sql;
        sql = "SELECT     Project_Period_Sources.Provider_ID " +
                            "FROM         Project_Funding_Sources INNER JOIN " +
                            "Project_Period_Sources ON Project_Funding_Sources.Sources_ID = Project_Period_Sources.Sources_ID INNER JOIN " +
                            "Project_Period_Balance ON Project_Period_Sources.Period_ID = Project_Period_Balance.Period_ID " +
                            "WHERE     (Project_Period_Balance.Proj_id = " + Session_CS.Project_id + ") AND (Project_Period_Balance.Quarter_Year = '" + currentYear + "') " +
                            " AND (Project_Funding_Sources.Sources_ID = " + ID.ToString() + ")" +
                            "GROUP BY Provider_ID";

        switch (ID)
        {
            case 1:
                qryStr = "SELECT  0.00 as Value, 1 as Provider_ID,'بنك الإستثمار القومى' as Provider_Name";
                break;
            case 2:
                qryStr = "SELECT 0.00 as Value, [Loan_ID] as Provider_ID,[Loan_Name] as Provider_Name FROM [Loans] where Loan_ID in (" + sql + ")";
                break;
            case 3:
                qryStr = "select 0.00 as Value, Org_ID as Provider_ID, Org_Desc as Provider_Name from Project_Organization " +
                 " join Project on Proj_proj_id = Proj_id" +
                 " join Organization on org_org_id = org_id" +
                 " join employee on Project.pmp_pmp_id = EMPLOYEE.PMP_ID where  Proj_proj_id=" + Session_CS.Project_id + " AND Org_ID in (" + sql + ")";
                break;
            case 4:
                qryStr = "select 0.00 as Value, Protocol_ID as Provider_ID,Name as Provider_Name FROM Protocol_Def where Type=2 AND Protocol_ID in (" + sql + ")";
                break;
        }

        qrtrData = General_Helping.GetDataTable(qryStr);
        ddl_Provider.DataSource = qrtrData;
        ddl_Provider.DataBind();
    }


}
