using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Text;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Net.Mail;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Globalization;
using System.Data;
using System.Configuration;
using System;

public partial class UserControls_Project_Activities_Months : System.Web.UI.UserControl
{
    Session_CS Session_CS = new Session_CS();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            //ddl_Year.SelectedValue = DateTime.Now.Year.ToString();

            ddl_Year.SelectedValue = CDataConverter.ConvertDateTimeNowRtnDt().Year.ToString() ;
            Fill_Grid();

        }

    }



    protected void btn_Save_Click(object sender, EventArgs e)
    {
        if (Check_Valid())
        {
            Project_Activities_Months_DT obj = new Project_Activities_Months_DT();
            obj.ID = CDataConverter.ConvertToInt(hidden_ID.Value);
            obj.Month = DDL_month.SelectedValue;
            obj.Year = ddl_Year.SelectedValue;
            obj.Notes = txt_Notes.Text;
            obj.Active = chk_Active.Checked;
            obj.End_DT = txt_End_DT.Text;
            hidden_ID.Value = Project_Activities_Months_DB.Save(obj).ToString();

            //            else
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم الحفظ بنجاح')</script>");

            if (obj.Active)
                btn_Send.Enabled = true;
            else
                btn_Send.Enabled = false;


            Fill_Grid();

        }

    }

    protected void btn_new_Click(object sender, EventArgs e)
    {
        hidden_ID.Value = "";
        txt_End_DT.Text =
        txt_Notes.Text = "";
        chk_Active.Checked = false;
    }
    protected void btn_Send_Click(object sender, EventArgs e)
    {
        if (CDataConverter.ConvertToInt(hidden_ID.Value) > 0 && chk_Active.Checked)
            Send_Email_for_Proj_mngr();
    }


    void Send_Email_for_Proj_mngr()
    {


        string main_sql = " select distinct * from ALL_PMP_Manger_Dept_Manager ";
       //  string main_sql = " SELECT  distinct   EMPLOYEE.pmp_name, EMPLOYEE.mail FROM         EMPLOYEE  where pmp_id = 547";

        DataTable dt_act = General_Helping.GetDataTable(main_sql);
        string name = "";
        string Succ_names = "", Failed_name = "";
        if (dt_act.Rows.Count > 0)
        {
            MailMessage _Message = new MailMessage();
            _Message.Subject = "نظام الادارة الالكترونية - المراسلات";
            //_Message.BodyEncoding = Encoding.Unicode;
            _Message.BodyEncoding = Encoding.UTF8;
            _Message.SubjectEncoding = Encoding.UTF8;

            string address2 = "0";
            String encrypted_id = "0";
            string file = "";
            MemoryStream ms = new MemoryStream();

            _Message.Body = "<html><body dir='rtl'><h3 >";
            _Message.Body += " السادة مديرى المشروعات";
            _Message.Body += "    </h3> ";

            _Message.Body += " <h3 > " + "  وصلكم وارد من عصام زغلول يفيد بفتح الفترة للإدخال " + "<h3 style=color:blue >" + txt_Notes.Text + "</h3>" + "  وأن اخر تاريخ لقبول التقارير على نظام ال (pms) هو <br/><h3 style=color:blue >" + txt_End_DT.Text + "</h3>";
            _Message.Body += "<h3 > مع تحيات </h3> ";
            _Message.Body += "<h3 >   " + Session_CS.e_signature.ToString() + "  </h3> ";
            _Message.Body += "</body></html>";
          
            string mail = "";
            try
            {
                foreach (DataRow dr in dt_act.Rows)
                {
                     mail = dr["mail"].ToString();
                   
                }

               
                SendingMailthread_class.Sendingmail(_Message,_Message.Subject, _Message.Body, mail, ms, file, encrypted_id, "");

                Succ_names += name + ",";

            }
            catch (Exception ex)
            {
                Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لم يتم ارسال الايميل بنجاح')</script>");


            }
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم ارسال الايميل بنجاح')</script>");
        }

    }
    bool Check_Valid()
    {
        bool Flag = true;

        if (chk_Active.Checked && !Project_Activities_Months_DB.check_Active(CDataConverter.ConvertToInt(hidden_ID.Value)))
        {
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('يوجد شهر اخر نشط  ')</script>");
            Flag = false;
        }

        return Flag;
    }

    void Fil_Cntrol(Project_Activities_Months_DT obj)
    {
        if (obj.ID > 0)
        {
           
            hidden_ID.Value = obj.ID.ToString();
            DDL_month.SelectedValue = obj.Month;
            ddl_Year.SelectedValue = obj.Year;
            txt_Notes.Text = obj.Notes;
            chk_Active.Checked = obj.Active;
            txt_End_DT.Text = obj.End_DT;
             if (obj.Active)
                 btn_Send.Enabled = true;
             else
                 btn_Send.Enabled = false;
        }

    }


    protected void gvMain_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "Show")
        {
            Project_Activities_Months_DT obj = Project_Activities_Months_DB.SelectByID(CDataConverter.ConvertToInt(e.CommandArgument));
            Fil_Cntrol(obj);

        }

        if (e.CommandName == "dlt")
        {
            Project_Activities_Months_DB.Delete(CDataConverter.ConvertToInt(e.CommandArgument));
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم الحذف بنجاح')</script>");
            Fill_Grid();

        }
    }
    protected void ddl_Year_SelectedIndexChanged(object sender, EventArgs e)
    {
        Fill_Grid();
        DDL_month_SelectedIndexChanged(sender, e);
    }

    protected void DDL_month_SelectedIndexChanged(object sender, EventArgs e)
    {

        Project_Activities_Months_DT obj = Project_Activities_Months_DB.Selectby_month_Year(DDL_month.SelectedValue, ddl_Year.SelectedValue);
        Fil_Cntrol(obj);
    }

    void Fill_Grid()
    {
        DataTable Dt = Project_Activities_Months_DB.SelectAll(ddl_Year.SelectedValue);
        gvMain.DataSource = Dt;
        gvMain.DataBind();
    }
}

