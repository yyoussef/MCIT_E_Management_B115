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
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;
using CrystalDecisions.Shared;
using MCIT.Web.Data;
using System.Data.SqlClient;
using DBL;
using activityLeveling;
using System.Globalization;
using ReportsClass;

public partial class UserControls_Eval_Emp_Report : System.Web.UI.UserControl
{
    string sql;
    SqlConnection conn;
    SqlDataAdapter da;
    DataSet ds;
    private string sql_Connection = Universal.GetConnectionString();
    string InsideMCIT = System.Configuration.ConfigurationManager.AppSettings["InsideMCIT"].ToString();
    //Session_CS Session_CS = new Session_CS();
    protected override void OnInit(EventArgs e)
    {
        

        this.Smart_Search_Departments.Value_Handler += new Smart_Search.Delegate_Selected_Value(MOnMember_Data_Depart);
        fil_Departements();
     

        base.OnInit(e);
    }
    void fil_Departements()
    {
        string Query = "";
        if (InsideMCIT == "1")
        {
            Query = "SELECT  * from    Departments  where foundation_id='" + Session_CS.foundation_id + "' and Sec_sec_id='"+Session_CS.sec_id+"'";


        }
        else
        {
            Query = "SELECT  * from    Departments  where foundation_id='" + Session_CS.foundation_id + "'";


        }
     

        Smart_Search_Departments.datatble = General_Helping.GetDataTable(Query);
        Smart_Search_Departments.Value_Field = "Dept_id";
        Smart_Search_Departments.Text_Field = "Dept_name";


        Smart_Search_Departments.DataBind();
        //this.Smart_Search_Departments.Value_Handler += new Smart_Search.Delegate_Selected_Value(MOnMember_Data_Depart);
 
    }
    private void MOnMember_Data_Depart(string Value)
    {
        if (Value != "")
        {
            fil_employee();
        }
    }
    void fil_employee()
    {
        smart_employee.sql_Connection = sql_Connection;

        //smart_employee.Query = "SELECT pmp_id, pmp_name FROM employee where  Dept_Dept_id =  " + Smart_Search_Departments.SelectedValue;
        string Query = "SELECT pmp_id, pmp_name FROM employee where  Dept_Dept_id =  " + Smart_Search_Departments.SelectedValue;
        smart_employee.datatble = General_Helping.GetDataTable(Query);
        smart_employee.Show_Code = false;
        smart_employee.Value_Field = "pmp_id";
        smart_employee.Text_Field = "pmp_name";
        smart_employee.DataBind();

    }


    protected void Page_Load(object sender, EventArgs e)
    {
        conn = new SqlConnection(sql_Connection);
        if (Session_CS.pmp_name != null)
        {
            if (!IsPostBack)
            {
                Smart_Search_Departments.Show_OrgTree = true;


                //Ddl_Sectors.SelectedValue = Session_CS.sec_id.ToString();
                //Ddl_Sectors.DataBind();
                fil_Departements();
                hidden_manager.Value = "";


                // ImgBtnResearch.Attributes.Add("OnClick", this.obj_Browserdept.ClientSideFunction);
                /////////// ht5dy hena///////////////////////////////////////
                // ImageButtonmanage.Attributes.Add("OnClick", this.obj_Browsermanage.ClientSideFunction);
                ///////////// end hena ///////////////////////////////////////////
                int pmp = int.Parse(Session_CS.pmp_id.ToString());
                //////////////////////////////////// get project manager data to drop list ////////////////////
                sql = "select distinct pmp_pmp_id,PTem_Name,rol_rol_id from dbo.Project_Team where rol_rol_id=4";
                ds = new DataSet();
                da = new SqlDataAdapter(sql, conn);
                da.Fill(ds, "projectsmanage");
            }
        }
    }
    protected void eval_empLB_Click(object sender, EventArgs e)
    {
        hidden_Rpt_Id.Value = "Archivig_inbox_Report";
        show_hide_tables();

        Label6.Visible = false;

        Page.Title = eval_empLB.Text;
        Label2.Visible = true;
        Label2.Text = Page.Title;

    }
    protected void General_inbox_LB_Click(object sender, EventArgs e)
    {
        hidden_Rpt_Id.Value = "General_inbox_Report";
        hidden_Report.Value = "1";
        show_hide_tables();

        Label6.Visible = false;

        Page.Title = General_inbox_LB.Text;
        Label2.Visible = true;
        Label2.Text = Page.Title;

    }
    protected void General_Outbox_LB_Click(object sender, EventArgs e)
    {
        hidden_Rpt_Id.Value = "General_Outbox_Report";
        hidden_Report.Value = "1sader";
        show_hide_tables();

        Label6.Visible = false;

        Page.Title = General_Outbox_LB.Text;
        Label2.Visible = true;
        Label2.Text = Page.Title;

    }
    protected void General_com_LB_Click(object sender, EventArgs e)
    {
        hidden_Rpt_Id.Value = "General_com_Report";
        hidden_Report.Value = "1taklef";
        show_hide_tables();

        Label6.Visible = false;

        Page.Title = General_com_LB.Text;
        Label2.Visible = true;
        Label2.Text = Page.Title;

    }
    protected void Inbox_doneby_periodLB_Click(object sender, EventArgs e)
    {
        hidden_Rpt_Id.Value = "General_inbox_Report";
        hidden_Report.Value = "2";
        show_hide_tables();

        Label6.Visible = false;

        Page.Title = Inbox_doneby_periodLB.Text;
        Label2.Visible = true;
        Label2.Text = Page.Title;

    }
    protected void Outbox_doneby_periodLB_Click(object sender, EventArgs e)
    {
        hidden_Rpt_Id.Value = "General_Outbox_Report";
        hidden_Report.Value = "2sader";
        show_hide_tables();

        Label6.Visible = false;

        Page.Title = Outbox_doneby_periodLB.Text;
        Label2.Visible = true;
        Label2.Text = Page.Title;

    }
    protected void com_doneby_periodLB_Click(object sender, EventArgs e)
    {
        hidden_Rpt_Id.Value = "General_com_Report";
        hidden_Report.Value = "2taklef";
        show_hide_tables();

        Label6.Visible = false;

        Page.Title = com_doneby_periodLB.Text;
        Label2.Visible = true;
        Label2.Text = Page.Title;

    }
    protected void Outbox_donebefordateLB_Click(object sender, EventArgs e)
    {
        hidden_Rpt_Id.Value = "General_Outbox_Report";
        hidden_Report.Value = "3sader";
        show_hide_tables();

        Label6.Visible = false;

        Page.Title = Outbox_donebefordateLB.Text;
        Label2.Visible = true;
        Label2.Text = Page.Title;

    }
    protected void com_donebefordateLB_Click(object sender, EventArgs e)
    {
        hidden_Rpt_Id.Value = "General_com_Report";
        hidden_Report.Value = "3taklef";
        show_hide_tables();

        Label6.Visible = false;

        Page.Title = com_donebefordateLB.Text;
        Label2.Visible = true;
        Label2.Text = Page.Title;

    }
    protected void inbox_donebefordateLB_Click(object sender, EventArgs e)
    {
        hidden_Rpt_Id.Value = "General_inbox_Report";
        hidden_Report.Value = "3";
        show_hide_tables();

        Label6.Visible = false;

        Page.Title = inbox_donebefordateLB.Text;
        Label2.Visible = true;
        Label2.Text = Page.Title;

    }
    protected void LatePeriodLB_Click(object sender, EventArgs e)
    {
        hidden_Rpt_Id.Value = "General_inbox_Report";
        hidden_Report.Value = "4";
        show_hide_tables();

        Label6.Visible = false;

        Page.Title = LatePeriodLB.Text;
        Label2.Visible = true;
        Label2.Text = Page.Title;

    }

    protected void Latedetail_Click(object sender, EventArgs e)
    {



        string user = Session_CS.pmp_name.ToString();
        ReportDocument rd = new ReportDocument();

        string s = Server.MapPath("../Reports/General_inbox_DetailReport.rpt");
        rd.Load(s);
        Reports.Load_Report(rd);

        //rd.SetParameterValue("@Dept_id", dept_id);

         rd.SetParameterValue("sec_id", CDataConverter.ConvertToInt(Session_CS.sec_id));

        //rd.SetParameterValue("@pmp_id", CDataConverter.ConvertToInt(Session_CS.pmp_id), "Header_Eval_Report.rpt");

        rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
        rd.SetParameterValue("@user", user, "footerRep.rpt");
        if (rd.Rows.Count == 0)
        {
            ShowAlertMessage("!!!!!هذا التقرير لا يوجد به بيانات للعرض !!!!");
            return;
        }
        else
        {
            rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report");
        }

    }


    protected void LatePeriodOutboxLB_Click(object sender, EventArgs e)
    {
        hidden_Rpt_Id.Value = "General_Outbox_Report";
        hidden_Report.Value = "4sader";
        show_hide_tables();

        Label6.Visible = false;

        Page.Title = LatePeriodOutboxLB.Text;
        Label2.Visible = true;
        Label2.Text = Page.Title;

    }
    protected void LatePeriodComLB_Click(object sender, EventArgs e)
    {
        hidden_Rpt_Id.Value = "General_com_Report";
        hidden_Report.Value = "4taklef";
        show_hide_tables();

        Label6.Visible = false;

        Page.Title = LatePeriodComLB.Text;
        Label2.Visible = true;
        Label2.Text = Page.Title;

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        int found_id = CDataConverter.ConvertToInt(Session_CS.foundation_id.ToString());
       //string todayplus2late = VB_Classes.Dates.Dates_Operation.date_validate(DateTime.Now.AddDays(2).ToShortDateString());

        string todayplus2late = CDataConverter.ConvertDateTimeToFormatdmy(CDataConverter.ConvertDateTimeNowRtnDt().AddDays(2));
        int parent = 0;
        ReportDocument rd = new ReportDocument();
        string s = "";
        string t1 = "";
        string t2 = "";
        #region com_Report
        
        
        if (hidden_Rpt_Id.Value == "General_com_Report")
        {



            if (smart_employee.SelectedValue != "")
            {
                sql = "set dateformat dmy select * from commission_Report_View where 1=1 ";

                if (hidden_Report.Value == "1taklef")
                {
                    sql += " and visa_emp =" + CDataConverter.ConvertToInt(smart_employee.SelectedValue);
                }
                if (hidden_Report.Value == "2taklef" || hidden_Report.Value == "3taklef")
                {
                    //sql += " and visa_emp_id =" + CDataConverter.ConvertToInt(smart_employee.SelectedValue);
                    sql += " and visa_emp =" + CDataConverter.ConvertToInt(smart_employee.SelectedValue);
                    sql += " AND commission_Report_View.finished =1 ";
                }
                if (hidden_Report.Value == "4taklef")
                {
                    sql += " and visa_emp =" + CDataConverter.ConvertToInt(smart_employee.SelectedValue);
                    sql += " AND commission_Report_View.finished <> 1   and CONVERT(datetime,Dead_Line_DT) < = '" + todayplus2late + "'";
                }
                if (string.IsNullOrEmpty(txt_date_from.Text) && string.IsNullOrEmpty(txt_date_to.Text))
                {

                    t1 = DateTime.ParseExact("01/01/1900", "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
                    t2 = DateTime.MaxValue.ToString("dd/MM/yyyy");

                }
                else if (string.IsNullOrEmpty(txt_date_from.Text))
                {
                    if (txt_date_to.Text.Trim() != "")
                    {
                        t1 = DateTime.ParseExact("01/01/1900", "dd/MM/yyyy", null).ToString("dd/MM/yyyy");

                        //t2 = DateTime.ParseExact(Inbox_date_to.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
                        t2 = CDataConverter.ConvertDateTimeToFormatdmy(CDataConverter.ConvertToDate(txt_date_to.Text.Trim()));


                        if (hidden_Report.Value == "1taklef" || hidden_Report.Value == "4taklef")
                        {
                            sql += " AND convert(datetime,visa_date) < = '" + t2.ToString() + "'";
                        }
                        if (hidden_Report.Value == "2taklef")
                        {
                            sql += " AND convert(datetime,visa_date) < = '" + t2.ToString() + "'";
                            sql += " AND convert(datetime,follow_date) < = '" + t2.ToString() + "'";
                        }
                        if (hidden_Report.Value == "3taklef")
                        {
                            sql += " AND convert(datetime,visa_date) < '" + t2.ToString() + "'";
                            sql += " AND convert(datetime,follow_date) < = '" + t2.ToString() + "'";
                        }


                    }
                    else
                    {
                        ShowAlertMessage("!!!!!ادخل التاريخ بطريقة صحيحة !!!!");
                        return;
                    }
                }
                else if (string.IsNullOrEmpty(txt_date_to.Text))
                {
                    if (txt_date_from.Text.Trim() != "")
                    {
                        //t1 = DateTime.ParseExact(Inbox_date_from.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
                        t2 = DateTime.MaxValue.ToString("dd/MM/yyyy");
                        t1 = CDataConverter.ConvertDateTimeToFormatdmy(CDataConverter.ConvertToDate(txt_date_from.Text.Trim()));

                        if (hidden_Report.Value == "1taklef" || hidden_Report.Value == "4taklef")
                        {
                            sql += " AND convert(datetime,visa_date) > = '" + t1.ToString() + "'";
                        }

                        else if (hidden_Report.Value == "2taklef")
                        {
                            sql += " AND convert(datetime,visa_date) > = '" + t1.ToString() + "'";
                            sql += " AND convert(datetime,follow_date) > = '" + t1.ToString() + "'";
                        }
                        else if (hidden_Report.Value == "3taklef")
                        {
                            sql += " AND convert(datetime,visa_date) <  '" + t1.ToString() + "'";
                            sql += " AND convert(datetime,follow_date) > = '" + t1.ToString() + "'";
                        }

                    }
                    else
                    {
                        ShowAlertMessage("!!!!!ادخل التاريخ بطريقة صحيحة !!!!");
                        return;
                    }
                }
                else
                {
                    if (txt_date_to.Text.Trim() != "" && txt_date_from.Text.Trim() != "")
                    {
                        //t1 = DateTime.ParseExact(Inbox_date_from.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
                        t2 = CDataConverter.ConvertDateTimeToFormatdmy(CDataConverter.ConvertToDate(txt_date_to.Text.Trim()));
                        //t2 = DateTime.ParseExact(Inbox_date_to.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
                        t1 = CDataConverter.ConvertDateTimeToFormatdmy(CDataConverter.ConvertToDate(txt_date_from.Text.Trim()));

                        if (hidden_Report.Value == "1taklef" || hidden_Report.Value == "4taklef")
                        {
                            sql += " AND convert(datetime,visa_date) > = '" + t1.ToString() + "'";
                            sql += " AND convert(datetime,visa_date) < = '" + t2.ToString() + "'";
                        }

                        else if (hidden_Report.Value == "2taklef")
                        {
                            sql += " AND convert(datetime,visa_date) > = '" + t1.ToString() + "'";
                            sql += " AND convert(datetime,visa_date) < = '" + t2.ToString() + "'";
                            sql += " AND convert(datetime,follow_date) > = '" + t1.ToString() + "'";
                            sql += " AND convert(datetime,follow_date) < = '" + t2.ToString() + "'";
                        }
                        else if (hidden_Report.Value == "3taklef")
                        {
                            sql += " AND convert(datetime,visa_date) < '" + t1.ToString() + "'";
                            sql += " AND convert(datetime,follow_date) > = '" + t1.ToString() + "'";
                            sql += " AND convert(datetime,follow_date) < = '" + t2.ToString() + "'";
                        }
                    }
                    else
                    {
                        ShowAlertMessage("!!!!!ادخل التاريخ بطريقة صحيحة !!!!");
                        return;
                    }

                }
                DateTime date3 = DateTime.ParseExact(t1, "dd/MM/yyyy", null);
                DateTime date4 = DateTime.ParseExact(t2, "dd/MM/yyyy", null);
                if (date4.Subtract(date3).Days < 0)
                {
                    ShowAlertMessage("!!!!!التاريخ الأول يجب ان يكون قبل التاريخ الثاني !!!!");
                    return;
                }
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);



                string user = Session_CS.pmp_name.ToString();
                //ReportDocument rd = new ReportDocument();
                s = Server.MapPath("../Reports/General_inbox_Report.rpt");
                rd.Load(s);
                rd.SetDataSource(dt);
                Reports.Load_Report(rd);
                if ( hidden_Report.Value == "1taklef")
                {
                    rd.SetParameterValue("@Report_name", "  المكلف به خلال فترة -تكليفات");
                }
                else if (hidden_Report.Value == "2taklef")
                {
                    rd.SetParameterValue("@Report_name", "المنجز في الفترة والمكلف به في هذه الفترة- تكليفات ");
                }
                else if ( hidden_Report.Value == "3taklef")
                {
                    rd.SetParameterValue("@Report_name", "المنجز في الفترة والمكلف به قبل هذه الفترة -تكليفات ");
                }
                else if ( hidden_Report.Value == "4taklef")
                {
                    rd.SetParameterValue("@Report_name", "المتأخر في فترة معينة- تكليفات ");
                }
                rd.SetParameterValue("@found_id", found_id, "Logo_Header_pic_dynamic.rpt");
                rd.SetParameterValue("@pmp_id", CDataConverter.ConvertToInt(smart_employee.SelectedValue), "Header_Eval_Report.rpt");
                rd.SetParameterValue("@pmp_id", CDataConverter.ConvertToInt(smart_employee.SelectedValue));
                rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
                rd.SetParameterValue("@user", user, "footerRep.rpt");
                if (dt.Rows.Count == 0)
                {
                    ShowAlertMessage("هذا التقرير لا يوجد به بيانات للعرض !!!!");
                    return;
                }
                else
                    rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report");
            }
            else
            {
                ShowAlertMessage("!!!!!يجب اختيار موظف !!!!");
                return;
            }

        }
        #endregion
        #region Outbox


        if (hidden_Rpt_Id.Value == "General_Outbox_Report")
        {



            if (smart_employee.SelectedValue != "")
            {
                sql = "set dateformat dmy select * from Outbox_Report_View where 1=1 ";

                if (hidden_Report.Value == "1sader")
                {
                    sql += " and visa_emp =" + CDataConverter.ConvertToInt(smart_employee.SelectedValue);
                }
                if (hidden_Report.Value == "2sader" || hidden_Report.Value == "3sader")
                {
                    //sql += " and visa_emp_id =" + CDataConverter.ConvertToInt(smart_employee.SelectedValue);
                    sql += " AND Outbox_Report_View.outbox_status =3 ";
                }
                if (hidden_Report.Value == "4sader")
                {
                    sql += " and visa_emp =" + CDataConverter.ConvertToInt(smart_employee.SelectedValue);
                    sql += " AND Outbox_Report_View.outbox_status <> 3   and CONVERT(datetime,Dead_Line_DT) < = '" + todayplus2late + "'";
                }
                if (string.IsNullOrEmpty(txt_date_from.Text) && string.IsNullOrEmpty(txt_date_to.Text))
                {

                    t1 = DateTime.ParseExact("01/01/1900", "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
                    t2 = DateTime.MaxValue.ToString("dd/MM/yyyy");

                }
                else if (string.IsNullOrEmpty(txt_date_from.Text))
                {
                    if (txt_date_to.Text.Trim() != "")
                    {
                        t1 = DateTime.ParseExact("01/01/1900", "dd/MM/yyyy", null).ToString("dd/MM/yyyy");

                        //t2 = DateTime.ParseExact(Inbox_date_to.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
                        t2 = CDataConverter.ConvertDateTimeToFormatdmy(CDataConverter.ConvertToDate(txt_date_to.Text.Trim()));


                        if (hidden_Report.Value == "1sader" || hidden_Report.Value == "4sader")
                        {
                            sql += " AND convert(datetime,visa_date) < = '" + t2.ToString() + "'";
                        }
                        if (hidden_Report.Value == "2sader")
                        {
                            sql += " AND convert(datetime,visa_date) < = '" + t2.ToString() + "'";
                            sql += " AND convert(datetime,follow_date) < = '" + t2.ToString() + "'";
                        }
                        if (hidden_Report.Value == "3sader")
                        {
                            sql += " AND convert(datetime,visa_date) < '" + t2.ToString() + "'";
                            sql += " AND convert(datetime,follow_date) < = '" + t2.ToString() + "'";
                        }


                    }
                    else
                    {
                        ShowAlertMessage("!!!!!ادخل التاريخ بطريقة صحيحة !!!!");
                        return;
                    }
                }
                else if (string.IsNullOrEmpty(txt_date_to.Text))
                {
                    if (txt_date_from.Text.Trim() != "")
                    {
                        //t1 = DateTime.ParseExact(Inbox_date_from.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
                        t2 = DateTime.MaxValue.ToString("dd/MM/yyyy");
                        t1 = CDataConverter.ConvertDateTimeToFormatdmy(CDataConverter.ConvertToDate(txt_date_from.Text.Trim()));

                        if (hidden_Report.Value == "1sader" || hidden_Report.Value == "4sader")
                        {
                            sql += " AND convert(datetime,visa_date) > = '" + t1.ToString() + "'";
                        }

                        else if (hidden_Report.Value == "2sader")
                        {
                            sql += " AND convert(datetime,visa_date) > = '" + t1.ToString() + "'";
                            sql += " AND convert(datetime,follow_date) > = '" + t1.ToString() + "'";
                        }
                        else if (hidden_Report.Value == "3sader")
                        {
                            sql += " AND convert(datetime,visa_date) <  '" + t1.ToString() + "'";
                            sql += " AND convert(datetime,follow_date) > = '" + t1.ToString() + "'";
                        }

                    }
                    else
                    {
                        ShowAlertMessage("!!!!!ادخل التاريخ بطريقة صحيحة !!!!");
                        return;
                    }
                }
                else
                {
                    if (txt_date_to.Text.Trim() != "" && txt_date_from.Text.Trim() != "")
                    {
                        //t1 = DateTime.ParseExact(Inbox_date_from.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
                       // t2 = VB_Classes.Dates.Dates_Operation.date_validate(txt_date_to.Text.Trim());
                        t2 = CDataConverter.ConvertDateTimeToFormatdmy(CDataConverter.ConvertToDate(txt_date_to.Text.Trim()));
                        //t2 = DateTime.ParseExact(Inbox_date_to.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
                       // t1 = VB_Classes.Dates.Dates_Operation.date_validate(txt_date_from.Text.Trim());
                        t1 = CDataConverter.ConvertDateTimeToFormatdmy(CDataConverter.ConvertToDate(txt_date_from.Text.Trim()));
                        if (hidden_Report.Value == "1sader" || hidden_Report.Value == "4sader")
                        {
                            sql += " AND convert(datetime,visa_date) > = '" + t1.ToString() + "'";
                            sql += " AND convert(datetime,visa_date) < = '" + t2.ToString() + "'";
                        }

                        else if (hidden_Report.Value == "2sader")
                        {
                            sql += " AND convert(datetime,visa_date) > = '" + t1.ToString() + "'";
                            sql += " AND convert(datetime,visa_date) < = '" + t2.ToString() + "'";
                            sql += " AND convert(datetime,follow_date) > = '" + t1.ToString() + "'";
                            sql += " AND convert(datetime,follow_date) < = '" + t2.ToString() + "'";
                        }
                        else if (hidden_Report.Value == "3sader")
                        {
                            sql += " AND convert(datetime,visa_date) < '" + t1.ToString() + "'";
                            sql += " AND convert(datetime,follow_date) > = '" + t1.ToString() + "'";
                            sql += " AND convert(datetime,follow_date) < = '" + t2.ToString() + "'";
                        }
                    }
                    else
                    {
                        ShowAlertMessage("!!!!!ادخل التاريخ بطريقة صحيحة !!!!");
                        return;
                    }

                }
                DateTime date3 = DateTime.ParseExact(t1, "dd/MM/yyyy", null);
                DateTime date4 = DateTime.ParseExact(t2, "dd/MM/yyyy", null);
                if (date4.Subtract(date3).Days < 0)
                {
                    ShowAlertMessage("!!!!!التاريخ الأول يجب ان يكون قبل التاريخ الثاني !!!!");
                    return;
                }
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);



                string user = Session_CS.pmp_name.ToString();
                //ReportDocument rd = new ReportDocument();
                s = Server.MapPath("../Reports/General_inbox_Report.rpt");
                rd.Load(s);
                rd.SetDataSource(dt);
                Reports.Load_Report(rd);
                if (hidden_Report.Value == "1sader")
                {
                    rd.SetParameterValue("@Report_name", " المكلف به خلال فترة -صادر ");
                }
                else if (hidden_Report.Value == "2sader")
                {
                    rd.SetParameterValue("@Report_name", " المنجز في الفترة والمكلف به في هذه الفترة -صادر ");
                }
                else if (hidden_Report.Value == "3sader")
                {
                    rd.SetParameterValue("@Report_name", "المنجز في الفترة والمكلف به قبل هذه الفترة -صادر ");
                }
                else if (hidden_Report.Value == "4sader")
                {
                    rd.SetParameterValue("@Report_name", "المتأخر في فترة معينة -صادر ");
                }
                rd.SetParameterValue("@found_id", found_id, "Logo_Header_pic_dynamic.rpt");
                rd.SetParameterValue("@pmp_id", CDataConverter.ConvertToInt(smart_employee.SelectedValue), "Header_Eval_Report.rpt");
                rd.SetParameterValue("@pmp_id", CDataConverter.ConvertToInt(smart_employee.SelectedValue));
                rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
                rd.SetParameterValue("@user", user, "footerRep.rpt");
                if (dt.Rows.Count == 0)
                {
                    ShowAlertMessage("هذا التقرير لا يوجد به بيانات للعرض !!!!");
                    return;
                }
                else
                    rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report");
            }
            else
            {
                ShowAlertMessage("!!!!!يجب اختيار موظف !!!!");
                return;
            }

        }
        #endregion
        #region Inbox_Report
        
        
        if (hidden_Rpt_Id.Value == "General_inbox_Report")
        {



            if (smart_employee.SelectedValue != "")
            {
                sql = "set dateformat dmy select * from inbox_Report_view where 1=1 ";
                if (hidden_Report.Value == "1")
                {
                    sql += " and visa_emp =" + CDataConverter.ConvertToInt(smart_employee.SelectedValue);
                }
                if (hidden_Report.Value == "2" || hidden_Report.Value == "3")
                {
                    
                    sql += " AND inbox_Report_view.inbox_status =3 ";
                }
                if (hidden_Report.Value == "4")
                {
                    sql += " and visa_emp =" + CDataConverter.ConvertToInt(smart_employee.SelectedValue);
                    sql += " AND inbox_Report_view.inbox_status <> 3  and CONVERT(datetime,Dead_Line_DT) < = '" + todayplus2late + "'";
                }
                if (string.IsNullOrEmpty(txt_date_from.Text) && string.IsNullOrEmpty(txt_date_to.Text))
                {

                    t1 = DateTime.ParseExact("01/01/1900", "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
                    t2 = DateTime.MaxValue.ToString("dd/MM/yyyy");

                }
                else if (string.IsNullOrEmpty(txt_date_from.Text))
                {
                    if (txt_date_to.Text.Trim() != "")
                        //if (VB_Classes.Dates.Dates_Operation.date_validate(txt_date_to.Text.Trim()) != "")
                    {
                        t1 = DateTime.ParseExact("01/01/1900", "dd/MM/yyyy", null).ToString("dd/MM/yyyy");

                        //t2 = DateTime.ParseExact(Inbox_date_to.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
                        t2 = CDataConverter.ConvertDateTimeToFormatdmy(CDataConverter.ConvertToDate(txt_date_to.Text.Trim()));


                        if (hidden_Report.Value == "1" || hidden_Report.Value == "4")
                        {
                            sql += " AND convert(datetime,visa_date) < = '" + t2.ToString() + "'";
                        }
                        if (hidden_Report.Value == "2")
                        {
                            sql += " AND convert(datetime,visa_date) < = '" + t2.ToString() + "'";
                            sql += " AND convert(datetime,follow_date) < = '" + t2.ToString() + "'";
                        }
                        if (hidden_Report.Value == "3")
                        {
                            sql += " AND convert(datetime,visa_date) < '" + t2.ToString() + "'";
                            sql += " AND convert(datetime,follow_date) < = '" + t2.ToString() + "'";
                        }


                    }
                    else
                    {
                        ShowAlertMessage("!!!!!ادخل التاريخ بطريقة صحيحة !!!!");
                        return;
                    }
                }
                else if (string.IsNullOrEmpty(txt_date_to.Text))
                {
                    if (txt_date_from.Text.Trim() != "")
                        //if (VB_Classes.Dates.Dates_Operation.date_validate(txt_date_from.Text.Trim()) != "")
                    {

                        //t1 = DateTime.ParseExact(Inbox_date_from.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
                        t2 = DateTime.MaxValue.ToString("dd/MM/yyyy");
                       // t1 = VB_Classes.Dates.Dates_Operation.date_validate(txt_date_from.Text.Trim());
                        t1 = CDataConverter.ConvertDateTimeToFormatdmy(CDataConverter.ConvertToDate(txt_date_from.Text.Trim()));
                        if (hidden_Report.Value == "1" || hidden_Report.Value == "4")
                        {
                            sql += " AND convert(datetime,visa_date) > = '" + t1.ToString() + "'";
                        }

                        else if (hidden_Report.Value == "2")
                        {
                            sql += " AND convert(datetime,visa_date) > = '" + t1.ToString() + "'";
                            sql += " AND convert(datetime,follow_date) > = '" + t1.ToString() + "'";
                        }
                        else if (hidden_Report.Value == "3")
                        {
                            sql += " AND convert(datetime,visa_date) <  '" + t1.ToString() + "'";
                            sql += " AND convert(datetime,follow_date) > = '" + t1.ToString() + "'";
                        }

                    }
                    else
                    {
                        ShowAlertMessage("!!!!!ادخل التاريخ بطريقة صحيحة !!!!");
                        return;
                    }
                }
                else
                {
                    if (txt_date_to.Text.Trim() != "" && txt_date_from.Text.Trim() != "")
                    {
                        //t2 = VB_Classes.Dates.Dates_Operation.date_validate(txt_date_to.Text.Trim());
                        t2 = CDataConverter.ConvertDateTimeToFormatdmy(CDataConverter.ConvertToDate(txt_date_to.Text.Trim()));

                       
                      //  t1 = VB_Classes.Dates.Dates_Operation.date_validate(txt_date_from.Text.Trim());

                        t1 = CDataConverter.ConvertDateTimeToFormatdmy(CDataConverter.ConvertToDate(txt_date_from.Text.Trim()));
                        if (hidden_Report.Value == "1" || hidden_Report.Value == "4")
                        {
                            sql += " AND convert(datetime,visa_date) > = '" + t1.ToString() + "'";
                            sql += " AND convert(datetime,visa_date) < = '" + t2.ToString() + "'";
                        }

                        else if (hidden_Report.Value == "2")
                        {
                            sql += " AND convert(datetime,visa_date) > = '" + t1.ToString() + "'";
                            sql += " AND convert(datetime,visa_date) < = '" + t2.ToString() + "'";
                            sql += " AND convert(datetime,follow_date) > = '" + t1.ToString() + "'";
                            sql += " AND convert(datetime,follow_date) < = '" + t2.ToString() + "'";
                        }
                        else if (hidden_Report.Value == "3")
                        {
                            sql += " AND convert(datetime,visa_date) < '" + t1.ToString() + "'";
                            sql += " AND convert(datetime,follow_date) > = '" + t1.ToString() + "'";
                            sql += " AND convert(datetime,follow_date) < = '" + t2.ToString() + "'";
                        }
                    }
                    else
                    {
                        ShowAlertMessage("!!!!!ادخل التاريخ بطريقة صحيحة !!!!");
                        return;
                    }

                }
                DateTime date3 = DateTime.ParseExact(t1, "dd/MM/yyyy", null);
                DateTime date4 = DateTime.ParseExact(t2, "dd/MM/yyyy", null);
                if (date4.Subtract(date3).Days < 0)
                {
                    ShowAlertMessage("!!!!!التاريخ الأول يجب ان يكون قبل التاريخ الثاني !!!!");
                    return;
                }
                sql += " order by inbox_Report_view.follow_id asc";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);



                string user = Session_CS.pmp_name.ToString();
                //ReportDocument rd = new ReportDocument();
                s = Server.MapPath("../Reports/General_inbox_Report.rpt");
                rd.Load(s);
                rd.SetDataSource(dt);
                Reports.Load_Report(rd);
                if (hidden_Report.Value == "1")
                {
                    rd.SetParameterValue("@Report_name", " المكلف به خلال فترة -وارد ");
                }
                else if (hidden_Report.Value == "2")
                {
                    rd.SetParameterValue("@Report_name", " المنجز في الفترة والمكلف به في هذه الفترة -وارد ");
                }
                else if (hidden_Report.Value == "3")
                {
                    rd.SetParameterValue("@Report_name", " المنجز في الفترة والمكلف به قبل هذه الفترة -وارد ");
                }
                else if (hidden_Report.Value == "4")
                {
                    rd.SetParameterValue("@Report_name", " المتأخر في فترة معينة- وارد ");
                }
                rd.SetParameterValue("@found_id", found_id, "Logo_Header_pic_dynamic.rpt");
                rd.SetParameterValue("@pmp_id", CDataConverter.ConvertToInt(smart_employee.SelectedValue), "Header_Eval_Report.rpt");
                rd.SetParameterValue("@pmp_id", CDataConverter.ConvertToInt(smart_employee.SelectedValue));
                rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
                rd.SetParameterValue("@user", user, "footerRep.rpt");
                if (dt.Rows.Count == 0)
                {
                    ShowAlertMessage("هذا التقرير لا يوجد به بيانات للعرض !!!!");
                    return;
                }
                else
                    rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report");
            }
            else
            {
                ShowAlertMessage("!!!!!يجب اختيار موظف !!!!");
                return;
            }

        }
        #endregion
        if (hidden_Rpt_Id.Value == "Archivig_inbox_Report")
        {
            DataTable dt_emp_group = General_Helping.GetDataTable("SELECT DISTINCT EMPLOYEE.PMP_ID,EMPLOYEE.Group_id, Users.System_ID, EMPLOYEE.rol_rol_id as UROL_UROL_ID,EMPLOYEE.pmp_name FROM EMPLOYEE INNER JOIN Users ON EMPLOYEE.PMP_ID = Users.pmp_pmp_id where EMPLOYEE.PMP_ID=" + CDataConverter.ConvertToInt(smart_employee.SelectedValue));
            int group_id = CDataConverter.ConvertToInt(dt_emp_group.Rows[0]["Group_id"]);

            DataTable dt_emp_MNG = General_Helping.GetDataTable("select parent_pmp_id,pmp_id from parent_employee where Type =1 and parent_pmp_id = " + CDataConverter.ConvertToInt(smart_employee.SelectedValue));
            if (dt_emp_MNG.Rows.Count > 0)
                parent = CDataConverter.ConvertToInt(dt_emp_MNG.Rows[0]["parent_pmp_id"]);
            else
                parent = 0;


            //string todayplus1 = VB_Classes.Dates.Dates_Operation.date_validate(DateTime.Now.AddDays(1).ToShortDateString());
            //string todayplus2 = VB_Classes.Dates.Dates_Operation.date_validate(DateTime.Now.AddDays(2).ToShortDateString());

            string todayplus1 = CDataConverter.ConvertDateTimeToFormatdmy(CDataConverter.ConvertDateTimeNowRtnDt().AddDays(1));
            string todayplus2 = CDataConverter.ConvertDateTimeToFormatdmy(CDataConverter.ConvertDateTimeNowRtnDt().AddDays(2));
            if (smart_employee.SelectedValue != "")
            {
                string user = Session_CS.pmp_name.ToString();

                s = Server.MapPath("../Reports/follow_emp_inbox.rpt");


                rd.Load(s);

                Reports.Load_Report(rd);




                rd.SetParameterValue("@pmp_id", CDataConverter.ConvertToInt(smart_employee.SelectedValue), "Header_Eval_Report.rpt");

                /////////////////// Handling logo issue ///////////////////////////////////////////////////
                rd.SetParameterValue("@found_id", found_id, "Logo_Header_pic_dynamic.rpt");
                ///////////// Handling first sub report Parameters

                rd.SetParameterValue("@pmp", CDataConverter.ConvertToInt(smart_employee.SelectedValue), "All_new_inbox.rpt");
                rd.SetParameterValue("@group_id", group_id, "All_new_inbox.rpt");
                rd.SetParameterValue("@parent", CDataConverter.ConvertToInt(parent), "All_new_inbox.rpt");
                if (txt_date_from.Text != "")
                {
                    rd.SetParameterValue("@fromdate", txt_date_from.Text, "All_new_inbox.rpt");
                }
                else
                {
                    rd.SetParameterValue("@fromdate", "01/01/1900", "All_new_inbox.rpt");
                }
                if (txt_date_to.Text != "")
                {
                    rd.SetParameterValue("@todate", txt_date_to.Text, "All_new_inbox.rpt");
                }
                else
                    rd.SetParameterValue("@todate", DateTime.MaxValue.ToString("dd/MM/yyyy"), "All_new_inbox.rpt");
                rd.SetParameterValue("@active", "0", "All_new_inbox.rpt");
                //////////////////////////////////////////////

                ///////////// Handling second sub report Parameters

                rd.SetParameterValue("@pmp", CDataConverter.ConvertToInt(smart_employee.SelectedValue), "old_inbox_all.rpt");
                rd.SetParameterValue("@group_id", group_id, "old_inbox_all.rpt");
                rd.SetParameterValue("@parent", CDataConverter.ConvertToInt(parent), "old_inbox_all.rpt");
                if (txt_date_from.Text != "")
                {
                    rd.SetParameterValue("@fromdate", txt_date_from.Text, "old_inbox_all.rpt");
                }
                else
                {
                    rd.SetParameterValue("@fromdate", "01/01/1900", "old_inbox_all.rpt");
                }
                if (txt_date_to.Text != "")
                {
                    rd.SetParameterValue("@todate", txt_date_to.Text, "old_inbox_all.rpt");
                }
                else
                    rd.SetParameterValue("@todate", DateTime.MaxValue.ToString("dd/MM/yyyy"), "old_inbox_all.rpt");
                rd.SetParameterValue("@active", 0, "old_inbox_all.rpt");
                ///////////////////////////////
                /////////////// Handling follow sub report Parameters


                rd.SetParameterValue("@pmp", CDataConverter.ConvertToInt(smart_employee.SelectedValue), "Follow_inbox_all.rpt");

                rd.SetParameterValue("@parent", CDataConverter.ConvertToInt(parent), "Follow_inbox_all.rpt");
                if (txt_date_from.Text != "")
                {
                    rd.SetParameterValue("@fromdate", txt_date_from.Text, "Follow_inbox_all.rpt");
                }
                else
                {
                    rd.SetParameterValue("@fromdate", "01/01/1900", "Follow_inbox_all.rpt");
                }
                if (txt_date_to.Text != "")
                {
                    rd.SetParameterValue("@todate", txt_date_to.Text, "Follow_inbox_all.rpt");
                }
                else
                    rd.SetParameterValue("@todate", DateTime.MaxValue.ToString("dd/MM/yyyy"), "Follow_inbox_all.rpt");
                rd.SetParameterValue("@active", 0, "Follow_inbox_all.rpt");
                /////////////////////////////////////////////////////////////////////
                /////////////// Handling late sub report Parameters

                rd.SetParameterValue("@pmp", CDataConverter.ConvertToInt(smart_employee.SelectedValue), "late_inbox_all.rpt");
                rd.SetParameterValue("@group_id", group_id, "late_inbox_all.rpt");
                rd.SetParameterValue("@parent", CDataConverter.ConvertToInt(parent), "late_inbox_all.rpt");
                rd.SetParameterValue("@todayplus1", todayplus1, "late_inbox_all.rpt");
                rd.SetParameterValue("@todayplus2", todayplus2, "late_inbox_all.rpt");

                if (txt_date_from.Text != "")
                {
                    rd.SetParameterValue("@fromdate", txt_date_from.Text, "late_inbox_all.rpt");
                }
                else
                {
                    rd.SetParameterValue("@fromdate", "01/01/1900", "late_inbox_all.rpt");
                }
                if (txt_date_to.Text != "")
                {
                    rd.SetParameterValue("@todate", txt_date_to.Text, "late_inbox_all.rpt");
                }
                else
                    rd.SetParameterValue("@todate", DateTime.MaxValue.ToString("dd/MM/yyyy"), "late_inbox_all.rpt");
                rd.SetParameterValue("@active", 0, "late_inbox_all.rpt");

                //////////////////////////////
                /////////////// Handling closed sub report Parameters

                rd.SetParameterValue("@pmp", CDataConverter.ConvertToInt(smart_employee.SelectedValue), "closed_inbox_all.rpt");
                rd.SetParameterValue("@group_id", group_id, "closed_inbox_all.rpt");
                rd.SetParameterValue("@parent", CDataConverter.ConvertToInt(parent), "closed_inbox_all.rpt");
                if (txt_date_from.Text != "")
                {
                    rd.SetParameterValue("@fromdate", txt_date_from.Text, "closed_inbox_all.rpt");
                }
                else
                {
                    rd.SetParameterValue("@fromdate", "01/01/1900", "closed_inbox_all.rpt");
                }
                if (txt_date_to.Text != "")
                {
                    rd.SetParameterValue("@todate", txt_date_to.Text, "closed_inbox_all.rpt");
                }
                else
                    rd.SetParameterValue("@todate", DateTime.MaxValue.ToString("dd/MM/yyyy"), "closed_inbox_all.rpt");
                rd.SetParameterValue("@active", 0, "closed_inbox_all.rpt");
                ////////////////////////////
                rd.SetParameterValue("@group_id", group_id, "understudy_inbox_all.rpt");
                if (txt_date_from.Text != "")
                {
                    rd.SetParameterValue("@fromdate", txt_date_from.Text, "understudy_inbox_all.rpt");
                }
                else
                {
                    rd.SetParameterValue("@fromdate", "01/01/1900", "understudy_inbox_all.rpt");
                }
                if (txt_date_to.Text != "")
                {
                    rd.SetParameterValue("@todate", txt_date_to.Text, "understudy_inbox_all.rpt");
                }
                else
                    rd.SetParameterValue("@todate", DateTime.MaxValue.ToString("dd/MM/yyyy"), "understudy_inbox_all.rpt");
                rd.SetParameterValue("@active", 0, "understudy_inbox_all.rpt");


                rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
                rd.SetParameterValue("@user", user, "footerRep.rpt");

                rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report");
            }
            else
            {
                ShowAlertMessage("!!!!!يجب اختيار موظف !!!!");
                return;
            }

        }
        if (hidden_Rpt_Id.Value == "Archivig_outbox_Report")
        {
            DataTable dt_emp_group = General_Helping.GetDataTable("SELECT DISTINCT EMPLOYEE.PMP_ID,EMPLOYEE.Group_id, Users.System_ID, EMPLOYEE.rol_rol_id as UROL_UROL_ID,EMPLOYEE.pmp_name FROM EMPLOYEE INNER JOIN Users ON EMPLOYEE.PMP_ID = Users.pmp_pmp_id where EMPLOYEE.PMP_ID=" + CDataConverter.ConvertToInt(smart_employee.SelectedValue));
            int group_id = CDataConverter.ConvertToInt(dt_emp_group.Rows[0]["Group_id"]);

            DataTable dt_emp_MNG = General_Helping.GetDataTable("select parent_pmp_id,pmp_id from parent_employee where Type =1 and parent_pmp_id = " + CDataConverter.ConvertToInt(smart_employee.SelectedValue));
            if (dt_emp_MNG.Rows.Count > 0)
                parent = CDataConverter.ConvertToInt(dt_emp_MNG.Rows[0]["parent_pmp_id"]);
            else
                parent = 0;


            //string todayplus1 = VB_Classes.Dates.Dates_Operation.date_validate(DateTime.Now.AddDays(1).ToShortDateString());
            //string todayplus2 = VB_Classes.Dates.Dates_Operation.date_validate(DateTime.Now.AddDays(2).ToShortDateString());

            string todayplus1 = CDataConverter.ConvertDateTimeToFormatdmy(CDataConverter.ConvertDateTimeNowRtnDt().AddDays(1));
            string todayplus2 = CDataConverter.ConvertDateTimeToFormatdmy(CDataConverter.ConvertDateTimeNowRtnDt().AddDays(2));
            if (smart_employee.SelectedValue != "")
            {
                string user = Session_CS.pmp_name.ToString();

                s = Server.MapPath("../Reports/outbox_archiving.rpt");


                rd.Load(s);

                Reports.Load_Report(rd);

                rd.SetParameterValue("@found_id", found_id, "Logo_Header_pic_dynamic.rpt");

                rd.SetParameterValue("@pmp_id", CDataConverter.ConvertToInt(smart_employee.SelectedValue), "Header_Eval_Report.rpt");

                rd.SetParameterValue("@pmp", CDataConverter.ConvertToInt(smart_employee.SelectedValue), "new_outbox_all.rpt");
                rd.SetParameterValue("@group_id", group_id, "new_outbox_all.rpt");
                rd.SetParameterValue("@parent", CDataConverter.ConvertToInt(parent), "new_outbox_all.rpt");
                rd.SetParameterValue("@active", 0, "new_outbox_all.rpt");

                rd.SetParameterValue("@pmp", CDataConverter.ConvertToInt(smart_employee.SelectedValue), "old_outbox_all.rpt");
                rd.SetParameterValue("@group_id", group_id, "old_outbox_all.rpt");
                rd.SetParameterValue("@parent", CDataConverter.ConvertToInt(parent), "old_outbox_all.rpt");
                rd.SetParameterValue("@active", 0, "old_outbox_all.rpt");

                rd.SetParameterValue("@pmp", CDataConverter.ConvertToInt(smart_employee.SelectedValue), "follow_outbox_all.rpt");
                rd.SetParameterValue("@group_id", group_id, "follow_outbox_all.rpt");
                rd.SetParameterValue("@parent", CDataConverter.ConvertToInt(parent), "follow_outbox_all.rpt");
                rd.SetParameterValue("@active", 0, "follow_outbox_all.rpt");

                rd.SetParameterValue("@pmp", CDataConverter.ConvertToInt(smart_employee.SelectedValue), "closed_outbox_all.rpt");
                rd.SetParameterValue("@group_id", group_id, "closed_outbox_all.rpt");
                rd.SetParameterValue("@parent", CDataConverter.ConvertToInt(parent), "closed_outbox_all.rpt");
                rd.SetParameterValue("@active", 0, "closed_outbox_all.rpt");

                rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
                rd.SetParameterValue("@user", user, "footerRep.rpt");

                rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report");
            }
            else
            {
                ShowAlertMessage("!!!!!يجب اختيار موظف !!!!");
                return;
            }





        }
        if (hidden_Rpt_Id.Value == "Archivig_Commission_Report")
        {
            DataTable dt_emp_group = General_Helping.GetDataTable("SELECT DISTINCT EMPLOYEE.PMP_ID,EMPLOYEE.Group_id, Users.System_ID, EMPLOYEE.rol_rol_id as UROL_UROL_ID,EMPLOYEE.pmp_name FROM EMPLOYEE INNER JOIN Users ON EMPLOYEE.PMP_ID = Users.pmp_pmp_id where EMPLOYEE.PMP_ID=" + CDataConverter.ConvertToInt(smart_employee.SelectedValue));
            int group_id = CDataConverter.ConvertToInt(dt_emp_group.Rows[0]["Group_id"]);

            DataTable dt_emp_MNG = General_Helping.GetDataTable("select parent_pmp_id,pmp_id from parent_employee where Type =1 and parent_pmp_id = " + CDataConverter.ConvertToInt(smart_employee.SelectedValue));
            if (dt_emp_MNG.Rows.Count > 0)
                parent = CDataConverter.ConvertToInt(dt_emp_MNG.Rows[0]["parent_pmp_id"]);
            else
                parent = 0;

            //string todayplus1 = VB_Classes.Dates.Dates_Operation.date_validate(DateTime.Now.AddDays(1).ToShortDateString());
            //string todayplus2 = VB_Classes.Dates.Dates_Operation.date_validate(DateTime.Now.AddDays(2).ToShortDateString());

            string todayplus1 = CDataConverter.ConvertDateTimeToFormatdmy(CDataConverter.ConvertDateTimeNowRtnDt().AddDays(1));
            string todayplus2 = CDataConverter.ConvertDateTimeToFormatdmy(CDataConverter.ConvertDateTimeNowRtnDt().AddDays(2));
            if (smart_employee.SelectedValue != "")
            {
                string user = Session_CS.pmp_name.ToString();

                s = Server.MapPath("../Reports/Archiving_Commession_Report.rpt");


                rd.Load(s);

                Reports.Load_Report(rd);

                rd.SetParameterValue("@found_id", found_id, "Logo_Header_pic_dynamic.rpt");
                rd.SetParameterValue("@pmp_id", CDataConverter.ConvertToInt(smart_employee.SelectedValue), "Header_Eval_Report.rpt");

                rd.SetParameterValue("@pmp", CDataConverter.ConvertToInt(smart_employee.SelectedValue), "all_new_commession.rpt");
                rd.SetParameterValue("@group_id", group_id, "all_new_commession.rpt");
                rd.SetParameterValue("@parent", CDataConverter.ConvertToInt(parent), "all_new_commession.rpt");

                rd.SetParameterValue("@pmp", CDataConverter.ConvertToInt(smart_employee.SelectedValue), "old_commission_report.rpt");
                rd.SetParameterValue("@group_id", group_id, "old_commission_report.rpt");
                rd.SetParameterValue("@parent", CDataConverter.ConvertToInt(parent), "old_commission_report.rpt");

                rd.SetParameterValue("@pmp", CDataConverter.ConvertToInt(smart_employee.SelectedValue), "Follow_commission_all.rpt");

                rd.SetParameterValue("@parent", CDataConverter.ConvertToInt(parent), "Follow_commission_all.rpt");

                rd.SetParameterValue("@pmp", CDataConverter.ConvertToInt(smart_employee.SelectedValue), "all_late_commission.rpt");
                rd.SetParameterValue("@group_id", group_id, "all_late_commission.rpt");
                rd.SetParameterValue("@parent", CDataConverter.ConvertToInt(parent), "all_late_commission.rpt");
                rd.SetParameterValue("@todayplus1", todayplus1, "all_late_commission.rpt");
                rd.SetParameterValue("@todayplus2", todayplus2, "all_late_commission.rpt");

                rd.SetParameterValue("@pmp", CDataConverter.ConvertToInt(smart_employee.SelectedValue), "closed_commission_report.rpt");
                rd.SetParameterValue("@group_id", group_id, "closed_commission_report.rpt");
                rd.SetParameterValue("@parent", CDataConverter.ConvertToInt(parent), "closed_commission_report.rpt");


                rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
                rd.SetParameterValue("@user", user, "footerRep.rpt");

                rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report");
            }
            else
            {
                ShowAlertMessage("!!!!!يجب اختيار موظف !!!!");
                return;
            }

        }
    }
    
    protected void show_hide_tables()
    {
        tbl_Report.Style.Add("display", "none");
        tbl_Paramater.Style.Add("display", "block");
    }

    public static void ShowAlertMessage(string error)
    {

        Page page = HttpContext.Current.Handler as Page;
        if (page != null)
        {
            error = error.Replace("'", "\'");
            ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('" + error + "');", true);
        }
    }
    public string IpAddress()
    {
        string name = "";
        string ip = "";
        try
        {
            name = System.Net.Dns.GetHostName();
            ip = System.Net.Dns.GetHostAddresses(name).GetValue(1).ToString();
            return ip;
        }
        catch
        {
            name = System.Net.Dns.GetHostName();
            ip = System.Net.Dns.GetHostAddresses(name).GetValue(0).ToString();
            return ip;
        }
    }
    //protected void Ddl_Sectors_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    fil_Departements();
    //}
    protected void ImgBtnBack_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("../MainForm/Archiving_Report.aspx");
    }

    protected void LinkButton5_Click(object sender, EventArgs e)
    {
        hidden_Rpt_Id.Value = "Archivig_outbox_Report";

        show_hide_tables();
        Label6.Visible = false;

        Page.Title = LinkButton5.Text;
        Label2.Visible = true;
        Label2.Text = Page.Title;

    }
    protected void LinkButton16_Click(object sender, EventArgs e)
    {
        hidden_Rpt_Id.Value = "Archivig_Commission_Report";

        show_hide_tables();
        Label6.Visible = false;

        Page.Title = LinkButton16.Text;
        Label2.Visible = true;
        Label2.Text = Page.Title;

    }
}
