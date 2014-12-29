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



public partial class UserControls_Protocol_Main_Search_Control : System.Web.UI.UserControl
{
    string sql;
    SqlConnection conn;
    SqlDataAdapter da;
    DataSet ds;
    SqlCommand cmd;
    int page_no, page_total_count;
    General_Helping Obj_General_Helping = new General_Helping();
    private string sql_Connection = Database.ConnectionString;

    Session_CS Session_CS = new Session_CS();
    protected override void OnInit(EventArgs e)
    {
        string Query = "";
        Query = "SELECT Org_ID, Org_Desc FROM Organization";
        string Value_Field = "Org_ID";
        string Text_Field = "Org_Desc";

        Smart_Org1.sql_Connection = sql_Connection;
        Smart_Org1.datatble = General_Helping.GetDataTable(Query);
        Smart_Org1.Value_Field = Value_Field;
        Smart_Org1.Text_Field = Text_Field;
        Smart_Org1.DataBind();

        base.OnInit(e);

    }
   

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session_CS.Project_id != null)
        {
            gvMain.Columns[6].Visible = false;
            gvMain.Columns[8].Visible = false;
           
        }
        if (!IsPostBack)
        {

            txt_page_no.Text = "";
            
        }
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
    public void bindGridView(int startIndex, string sortExp, string direction)
    {
       // int endIndex = (startIndex * CDataConverter.ConvertToInt(gvMain.PageSize)) + CDataConverter.ConvertToInt(gvMain.PageSize);
       // string t1 = "";
       // string t2 = "";
       // string t3 = "";
       // string t4 = "";
       // string t5 = "";
       // string t6 = "";
       // sql = " SELECT DISTINCT  Protocol_Main_Def.Protocol_ID, Protocol_Main_Def.Name, Protocol_Main_Def.Strt_DT,CONVERT(datetime, dbo.datevalid(Protocol_Main_Def.Strt_DT), 103),CONVERT(datetime, dbo.datevalid(Protocol_Main_Def.End_DT), 103), Protocol_Main_Def.End_DT, Protocol_Main_Def.Total_Balance_LE, ";
       // sql += " Protocol_Main_Def.Total_Balance_US,  dbo.Protocol_Main_Def.Type   FROM Protocol_Main_Def LEFT OUTER JOIN Project ON Protocol_Main_Def.Protocol_ID = Project.Protocol_ID ";
       // sql += " where 1=1 ";

       // if (Session_CS.Project_id != null && CDataConverter.ConvertToInt(Session_CS.Project_id.ToString()) > 0)
       // {
       //     sql += " AND Project.Proj_id = " + CDataConverter.ConvertToInt(Session_CS.Project_id.ToString());
       // }

       // if (Protocole_name_text.Text != "")
       // {
       //     sql += " AND Name like" + "'%" + Protocole_name_text.Text + "%'";
       // }

       // if (Smart_Project.SelectedValue != "")
       // {
       //     sql += " AND Project.Proj_id = " + Smart_Project.SelectedValue;
       // }

       // if (string.IsNullOrEmpty(prot_strt_date_from.Text) && string.IsNullOrEmpty(prot_strt_date_to.Text))
       // {
       //     t1 = DateTime.ParseExact("01/01/1900", "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
       //     t2 = DateTime.MaxValue.ToString("dd/MM/yyyy");

       // }
       // else if (string.IsNullOrEmpty(prot_strt_date_from.Text))
       // {
       //     if (VB_Classes.Dates.Dates_Operation.date_validate(prot_strt_date_to.Text.Trim()) != "")
       //     {
       //         t1 = DateTime.ParseExact("01/01/1900", "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
       //         //t2 = DateTime.ParseExact(Inbox_date_to.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
       //         t2 = VB_Classes.Dates.Dates_Operation.date_validate(prot_strt_date_to.Text.Trim());
       //         sql += " AND convert(datetime,Strt_DT,103) < = '" + t2.ToString() + "'";
       //     }
       //     else
       //     {
       //         ShowAlertMessage("!!!!!ادخل التاريخ بطريقة صحيحة !!!!");
       //         return;
       //     }




       // }
       // else if (string.IsNullOrEmpty(prot_strt_date_to.Text))
       // {
       //     if (VB_Classes.Dates.Dates_Operation.date_validate(prot_strt_date_from.Text.Trim()) != "")
       //     {
       //         //t1 = DateTime.ParseExact(Inbox_date_from.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
       //         t2 = DateTime.MaxValue.ToString("dd/MM/yyyy");
       //         t1 = VB_Classes.Dates.Dates_Operation.date_validate(prot_strt_date_from.Text.Trim());
       //         sql += " AND convert(datetime,Strt_DT,103) > = '" + t1.ToString() + "'";

       //     }
       //     else
       //     {
       //         ShowAlertMessage("!!!!!ادخل التاريخ بطريقة صحيحة !!!!");
       //         return;
       //     }

       // }
       // else
       // {
       //     if (VB_Classes.Dates.Dates_Operation.date_validate(prot_strt_date_to.Text.Trim()) != "" && VB_Classes.Dates.Dates_Operation.date_validate(prot_strt_date_from.Text.Trim()) != "")
       //     {
       //         //t1 = DateTime.ParseExact(Inbox_date_from.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
       //         t2 = VB_Classes.Dates.Dates_Operation.date_validate(prot_strt_date_to.Text.Trim());
       //         //t2 = DateTime.ParseExact(Inbox_date_to.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
       //         t1 = VB_Classes.Dates.Dates_Operation.date_validate(prot_strt_date_from.Text.Trim());
       //         sql += " AND convert(datetime,Strt_DT,103) > = '" + t1.ToString() + "'";
       //         sql += " AND convert(datetime,Strt_DT,103) < = '" + t2.ToString() + "'";
       //     }
       //     else
       //     {
       //         ShowAlertMessage("!!!!!ادخل التاريخ بطريقة صحيحة !!!!");
       //         return;
       //     }

       // }
       // DateTime date1 = DateTime.ParseExact(t1, "dd/MM/yyyy", null);
       // DateTime date2 = DateTime.ParseExact(t2, "dd/MM/yyyy", null);
       // if (date2.Subtract(date1).Days < 0)
       // {
       //     ShowAlertMessage("!!!!!التاريخ الأول يجب ان يكون قبل التاريخ الثاني !!!!");
       //     return;
       // }
       // //////////////////////////////////////////////////////////// finished check on sign_strt_Date/////////////////////////////////////

       // /////////////////////////////////////////////////////// begin check on sign_end_date///////////////////////////////////////////
       // if (string.IsNullOrEmpty(prot_end_date_from.Text) && string.IsNullOrEmpty(prot_end_date_to.Text))
       // {
       //     t3 = DateTime.ParseExact("01/01/1900", "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
       //     t4 = DateTime.MaxValue.ToString("dd/MM/yyyy");
       // }
       // else if (string.IsNullOrEmpty(prot_end_date_from.Text))
       // {
       //     if (VB_Classes.Dates.Dates_Operation.date_validate(prot_end_date_to.Text.Trim()) != "")
       //     {
       //         t3 = DateTime.ParseExact("01/01/1900", "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
       //         //t2 = DateTime.ParseExact(Outbox_date_to.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
       //         t4 = VB_Classes.Dates.Dates_Operation.date_validate(prot_end_date_to.Text.Trim());
       //         sql += " AND convert(datetime,End_DT,103) < = '" + t4.ToString() + "'";
       //     }
       //     else
       //     {
       //         ShowAlertMessage("!!!!!ادخل التاريخ بطريقة صحيحة !!!!");
       //         return;
       //     }

       // }
       // else if (string.IsNullOrEmpty(prot_end_date_to.Text))
       // {
       //     if (VB_Classes.Dates.Dates_Operation.date_validate(prot_end_date_from.Text.Trim()) != "")
       //     {
       //         //t1 = DateTime.ParseExact(Outbox_date_from.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
       //         t4 = DateTime.MaxValue.ToString("dd/MM/yyyy");
       //         t3 = VB_Classes.Dates.Dates_Operation.date_validate(prot_end_date_from.Text.Trim());
       //         sql += " AND convert(datetime,End_DT,103) > = '" + t3.ToString() + "'";
       //     }
       //     else
       //     {
       //         ShowAlertMessage("!!!!!ادخل التاريخ بطريقة صحيحة !!!!");
       //         return;
       //     }

       // }
       // else
       // {
       //     if (VB_Classes.Dates.Dates_Operation.date_validate(prot_end_date_to.Text.Trim()) != "" && VB_Classes.Dates.Dates_Operation.date_validate(prot_end_date_from.Text.Trim()) != "")
       //     {
       //         //t1 = DateTime.ParseExact(Outbox_date_from.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
       //         //t2 = DateTime.ParseExact(Outbox_date_to.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
       //         t4 = VB_Classes.Dates.Dates_Operation.date_validate(prot_end_date_to.Text.Trim());
       //         t3 = VB_Classes.Dates.Dates_Operation.date_validate(prot_end_date_from.Text.Trim());
       //         sql += " AND convert(datetime,End_DT,103) > = '" + t3.ToString() + "'";
       //         sql += " AND convert(datetime,End_DT,103) < = '" + t4.ToString() + "'";
       //     }
       //     else
       //     {
       //         ShowAlertMessage("!!!!!ادخل التاريخ بطريقة صحيحة !!!!");
       //         return;
       //     }


       // }
       // /////////////////////////////////////////////////////////////////// end check on sign_end _date/////////////////////////////////////

       // sql += "order by " + sortExp + " " + direction;
       // DateTime date3 = DateTime.ParseExact(t3, "dd/MM/yyyy", null);
       // DateTime date4 = DateTime.ParseExact(t4, "dd/MM/yyyy", null);
       // if (date4.Subtract(date3).Days < 0)
       // {
       //     ShowAlertMessage("!!!!!التاريخ الأول يجب ان يكون قبل التاريخ الثاني !!!!");
       //     return;
       // }
       
       // DataTable dt = General_Helping.GetDataTable(sql);
       // float  y =  dt.Rows.Count;
       // float sa = y / 10;
       // //float rounded =  System.Math.Round(y);
       // page_total_count =CDataConverter.ConvertToInt( System.Math.Ceiling(CDataConverter.ConvertToDecimal(sa)));
       // Session["page_total_count"] = page_total_count.ToString();
       //gvMain.DataSource = dt;
       
       // gvMain.DataBind();
    }

    public void SearchRecord2()
    {
 
        string name="";
        int pmp_id=Session_CS.pmp_id ;
        int rol_id = Session_CS.UROL_UROL_ID; ;
        int dept_id=Session_CS.dept_id ;
        string Strt_DT=""  ;
        string End_DT="";

        if(Protocole_name_text.Text != "")
        {
            name = Protocole_name_text.Text;

        }
        if (prot_strt_date_from.Text != "")
        {
            Strt_DT = prot_strt_date_from.Text ;

        }
        if (prot_strt_date_to.Text != "")
        {
            End_DT = prot_strt_date_to.Text ;

        }
       DataTable dt=  Protocol_Main_Def_DB.Select_Protocole_Data(name,pmp_id,rol_id,dept_id,Strt_DT,End_DT);
       gvMain.DataSource = dt;
       gvMain.DataBind();

    }



    private  void SearchRecord(int startIndex, string sortExp, string direction)
    {
        int endIndex = (startIndex * CDataConverter.ConvertToInt(gvMain.PageSize)) + CDataConverter.ConvertToInt(gvMain.PageSize);
        string t1 = "";
        string t2 = "";
        string t3 = "";
        string t4 = "";
        string t5 = "";
        string t6 = "";

        int pmp_id = Session_CS.pmp_id;
        int rol_id = Session_CS.UROL_UROL_ID;
        int dept_id = Session_CS.dept_id;
        if (rol_id == 4)
        {
            sql = " set dateformat dmy; SELECT DISTINCT  Protocol_Main_Def.Protocol_ID, Protocol_Main_Def.Name,";

            sql += "CONVERT(datetime, dbo.datevalid(Protocol_Main_Def.Strt_DT),103),CONVERT(datetime, dbo.datevalid(Protocol_Main_Def.End_DT),103),Protocol_Main_Def.Strt_DT, Protocol_Main_Def.End_DT, Protocol_Main_Def.Total_Balance_LE, Protocol_Main_Def.Total_Balance_US,  dbo.Protocol_Main_Def.Type, EMPLOYEE.PMP_ID,EMPLOYEE.rol_rol_id, EMPLOYEE.Dept_Dept_id, Protocol_Main_Org.Org_ID ,Organization.Org_ID,Organization.Org_Desc   FROM Protocol_Main_Def inner JOIN dbo.Protocol_Projects on Protocol_Projects.Protocol_ID =Protocol_Main_Def.Protocol_ID inner join Project ON Protocol_Projects.Project_ID = Project.Proj_id  inner join EMPLOYEE on EMPLOYEE.PMP_ID=Project.pmp_pmp_id inner join dbo.Protocol_Main_Org on dbo.Protocol_Main_Org.Protocol_ID=Protocol_Main_Def.Protocol_ID  and Protocol_Main_Org.Org_Type=1  left outer join dbo.Organization on Organization.Org_ID=Protocol_Main_Org.Org_ID";
            
            sql += "  where Protocol_Main_Def.PMP_ID='" + pmp_id + "'";
        }
        else if (rol_id == 3)
        {
            sql = "set dateformat dmy ; SELECT DISTINCT  Protocol_Main_Def.Protocol_ID, Protocol_Main_Def.Name,CONVERT(datetime, dbo.datevalid(Protocol_Main_Def.Strt_DT),103),";
            sql += "CONVERT(datetime, dbo.datevalid(Protocol_Main_Def.End_DT),103),Protocol_Main_Def.Strt_DT ,Organization.Org_ID,Organization.Org_Desc,Protocol_Main_Def.End_DT, Protocol_Main_Def.Total_Balance_LE,Protocol_Main_Def.Total_Balance_US,  dbo.Protocol_Main_Def.Type FROM Protocol_Main_Def inner JOIN Protocol_Projects on Protocol_Projects.Protocol_ID =Protocol_Main_Def.Protocol_ID inner join Project ON Protocol_Projects.Project_ID = Project.Proj_id inner join dbo.Protocol_Main_Org on dbo.Protocol_Main_Org.Protocol_ID=Protocol_Main_Def.Protocol_ID  and Protocol_Main_Org.Org_Type=1  left outer join dbo.Organization on Organization.Org_ID=Protocol_Main_Org.Org_ID ";
            sql += " where   Project.Dept_Dept_id='" + dept_id + "'";
        }
        else //if (rol_id == 11 || rol_id == 2)
        {
            sql = " set dateformat dmy ; SELECT DISTINCT  Protocol_Main_Def.Protocol_ID,Organization.Org_ID,Organization.Org_Desc, Protocol_Main_Def.Name,CONVERT(datetime, dbo.datevalid(Protocol_Main_Def.Strt_DT),103),CONVERT(datetime, dbo.datevalid(Protocol_Main_Def.End_DT),103), Protocol_Main_Def.Strt_DT, Protocol_Main_Def.End_DT, Protocol_Main_Def.Total_Balance_LE, ";
            sql += " Protocol_Main_Def.Total_Balance_US,  dbo.Protocol_Main_Def.Type   FROM Protocol_Main_Def LEFT OUTER JOIN Project ON Protocol_Main_Def.Protocol_ID = Project.Protocol_ID LEFT OUTER join dbo.Protocol_Main_Org on dbo.Protocol_Main_Org.Protocol_ID=Protocol_Main_Def.Protocol_ID  and Protocol_Main_Org.Org_Type=1  left outer join dbo.Organization on Organization.Org_ID=Protocol_Main_Org.Org_ID ";
               sql += " where 1=1 ";

        }


        if (Protocole_name_text.Text != "")
        {
            sql += " AND Name like" + "'%" + Protocole_name_text.Text + "%'";
        }

        if (Smart_Org1.SelectedValue  != "")
        {
            sql += " AND Protocol_Main_Org.Org_ID = '" + Smart_Org1.SelectedValue + "'";
        }

      

        if (string.IsNullOrEmpty(prot_strt_date_from.Text) && string.IsNullOrEmpty(prot_strt_date_to.Text))
        {
            t1 = DateTime.ParseExact("01/01/1900", "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
            t2 = DateTime.MaxValue.ToString("dd/MM/yyyy");

        }
        else if (string.IsNullOrEmpty(prot_strt_date_from.Text))
        {
            if (VB_Classes.Dates.Dates_Operation.date_validate(prot_strt_date_to.Text.Trim()) != "")
            {
                t1 = DateTime.ParseExact("01/01/1900", "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
                //t2 = DateTime.ParseExact(Inbox_date_to.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
                t2 = VB_Classes.Dates.Dates_Operation.date_validate(prot_strt_date_to.Text.Trim());
                sql += " AND convert(datetime,Strt_DT,103) < = '" + t2.ToString() + "'";
            }
            else
            {
                ShowAlertMessage("!!!!!ادخل التاريخ بطريقة صحيحة !!!!");
                return;
            }




        }
        else if (string.IsNullOrEmpty(prot_strt_date_to.Text))
        {
            if (VB_Classes.Dates.Dates_Operation.date_validate(prot_strt_date_from.Text.Trim()) != "")
            {
                //t1 = DateTime.ParseExact(Inbox_date_from.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
                t2 = DateTime.MaxValue.ToString("dd/MM/yyyy");
                t1 = VB_Classes.Dates.Dates_Operation.date_validate(prot_strt_date_from.Text.Trim());
                sql += " AND convert(datetime,Strt_DT,103) > = '" + t1.ToString() + "'";

            }
            else
            {
                ShowAlertMessage("!!!!!ادخل التاريخ بطريقة صحيحة !!!!");
                return;
            }

        }
        else
        {
            if (VB_Classes.Dates.Dates_Operation.date_validate(prot_strt_date_to.Text.Trim()) != "" && VB_Classes.Dates.Dates_Operation.date_validate(prot_strt_date_from.Text.Trim()) != "")
            {
                //t1 = DateTime.ParseExact(Inbox_date_from.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
                t2 = VB_Classes.Dates.Dates_Operation.date_validate(prot_strt_date_to.Text.Trim());
                //t2 = DateTime.ParseExact(Inbox_date_to.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
                t1 = VB_Classes.Dates.Dates_Operation.date_validate(prot_strt_date_from.Text.Trim());
                sql += " AND convert(datetime,Strt_DT,103) > = '" + t1.ToString() + "'";
                sql += " AND convert(datetime,Strt_DT,103) < = '" + t2.ToString() + "'";
            }
            else
            {
                ShowAlertMessage("!!!!!ادخل التاريخ بطريقة صحيحة !!!!");
                return;
            }

        }
        DateTime date1 = DateTime.ParseExact(t1, "dd/MM/yyyy", null);
        DateTime date2 = DateTime.ParseExact(t2, "dd/MM/yyyy", null);
        if (date2.Subtract(date1).Days < 0)
        {
            ShowAlertMessage("!!!!!التاريخ الأول يجب ان يكون قبل التاريخ الثاني !!!!");
            return;
        }
        //////////////////////////////////////////////////////////// finished check on sign_strt_Date/////////////////////////////////////

        /////////////////////////////////////////////////////// begin check on sign_end_date///////////////////////////////////////////
        if (string.IsNullOrEmpty(prot_end_date_from.Text) && string.IsNullOrEmpty(prot_end_date_to.Text))
        {
            t3 = DateTime.ParseExact("01/01/1900", "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
            t4 = DateTime.MaxValue.ToString("dd/MM/yyyy");
        }
        else if (string.IsNullOrEmpty(prot_end_date_from.Text))
        {
            if (VB_Classes.Dates.Dates_Operation.date_validate(prot_end_date_to.Text.Trim()) != "")
            {
                t3 = DateTime.ParseExact("01/01/1900", "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
                //t2 = DateTime.ParseExact(Outbox_date_to.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
                t4 = VB_Classes.Dates.Dates_Operation.date_validate(prot_end_date_to.Text.Trim());
                sql += " AND convert(datetime,End_DT,103) < = '" + t4.ToString() + "'";
            }
            else
            {
                ShowAlertMessage("!!!!!ادخل التاريخ بطريقة صحيحة !!!!");
                return;
            }

        }
        else if (string.IsNullOrEmpty(prot_end_date_to.Text))
        {
            if (VB_Classes.Dates.Dates_Operation.date_validate(prot_end_date_from.Text.Trim()) != "")
            {
                //t1 = DateTime.ParseExact(Outbox_date_from.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
                t4 = DateTime.MaxValue.ToString("dd/MM/yyyy");
                t3 = VB_Classes.Dates.Dates_Operation.date_validate(prot_end_date_from.Text.Trim());
                sql += " AND convert(datetime,End_DT,103) > = '" + t3.ToString() + "'";
            }
            else
            {
                ShowAlertMessage("!!!!!ادخل التاريخ بطريقة صحيحة !!!!");
                return;
            }

        }
        else
        {
            if (VB_Classes.Dates.Dates_Operation.date_validate(prot_end_date_to.Text.Trim()) != "" && VB_Classes.Dates.Dates_Operation.date_validate(prot_end_date_from.Text.Trim()) != "")
            {
                //t1 = DateTime.ParseExact(Outbox_date_from.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
                //t2 = DateTime.ParseExact(Outbox_date_to.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
                t4 = VB_Classes.Dates.Dates_Operation.date_validate(prot_end_date_to.Text.Trim());
                t3 = VB_Classes.Dates.Dates_Operation.date_validate(prot_end_date_from.Text.Trim());
                sql += " AND convert(datetime,End_DT,103) > = '" + t3.ToString() + "'";
                sql += " AND convert(datetime,End_DT,103) < = '" + t4.ToString() + "'";
            }
            else
            {
                ShowAlertMessage("!!!!!ادخل التاريخ بطريقة صحيحة !!!!");
                return;
            }


        }
        /////////////////////////////////////////////////////////////////// end check on sign_end _date/////////////////////////////////////

        //sql += " order by dbo.Protocol_Main_Def.Protocol_ID desc";
        sql += "order by " + sortExp + " " + direction;
        DateTime date3 = DateTime.ParseExact(t3, "dd/MM/yyyy", null);
        DateTime date4 = DateTime.ParseExact(t4, "dd/MM/yyyy", null);
        if (date4.Subtract(date3).Days < 0)
        {
            ShowAlertMessage("!!!!!التاريخ الأول يجب ان يكون قبل التاريخ الثاني !!!!");
            return;
        }

        DataTable dt = General_Helping.GetDataTable(sql);

        float y = dt.Rows.Count;
        float sa = y / 10;

        page_total_count = CDataConverter.ConvertToInt(System.Math.Ceiling(CDataConverter.ConvertToDecimal(sa)));
        Session["page_total_count"] = page_total_count.ToString();
        if (dt.Rows.Count == 0)
        {
            gvMain.EmptyDataText = ".....عفوا لا يوجد بيانات ......";
            tr_paging.Visible = false;
            tr_page_count.Visible = false;
        }
        else
        {
            gvMain.DataSource = dt;
            tr_paging.Visible = true;
            tr_page_count.Visible = true;
            lbl_page_count.Text = page_total_count.ToString();
        }
        gvMain.DataBind();
    }

    //public void SearchRecord(int startIndex, string sortExp, string direction)
    //{
    //    int endIndex = (startIndex * CDataConverter.ConvertToInt(gvMain.PageSize)) + CDataConverter.ConvertToInt(gvMain.PageSize);
    //    string t1 = "";
    //    string t2 = "";
    //    string t3 = "";
    //    string t4 = "";
    //    string t5 = "";
    //    string t6 = "";
    //    sql = " SELECT DISTINCT  Protocol_Main_Def.Protocol_ID, Protocol_Main_Def.Name,CONVERT(datetime, dbo.datevalid(Protocol_Main_Def.Strt_DT),103),CONVERT(datetime, dbo.datevalid(Protocol_Main_Def.End_DT),103), Protocol_Main_Def.Strt_DT, Protocol_Main_Def.End_DT, Protocol_Main_Def.Total_Balance_LE, ";
    //    sql += " Protocol_Main_Def.Total_Balance_US,  dbo.Protocol_Main_Def.Type   FROM Protocol_Main_Def LEFT OUTER JOIN Project ON Protocol_Main_Def.Protocol_ID = Project.Protocol_ID ";
    //    sql += " where 1=1 ";

    //    if (Session_CS.Project_id != null && CDataConverter.ConvertToInt(Session_CS.Project_id.ToString()) > 0)
    //    {
    //        sql += " AND Project.Proj_id = " + CDataConverter.ConvertToInt(Session_CS.Project_id.ToString());
    //    }

    //    if (Protocole_name_text.Text != "")
    //    {
    //        sql += " AND Name like" + "'%" + Protocole_name_text.Text + "%'";
    //    }

    //    //if (Smart_Project.SelectedValue != "")
    //    //{
    //    //    sql += " AND Project.Proj_id = " + Smart_Project.SelectedValue;
    //    //}

    //    if (string.IsNullOrEmpty(prot_strt_date_from.Text) && string.IsNullOrEmpty(prot_strt_date_to.Text))
    //    {
    //        t1 = DateTime.ParseExact("01/01/1900", "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
    //        t2 = DateTime.MaxValue.ToString("dd/MM/yyyy");
            
    //    }
    //    else if (string.IsNullOrEmpty(prot_strt_date_from.Text))
    //    {
    //        if (VB_Classes.Dates.Dates_Operation.date_validate(prot_strt_date_to.Text.Trim()) != "")
    //        {
    //            t1 = DateTime.ParseExact("01/01/1900", "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
    //            //t2 = DateTime.ParseExact(Inbox_date_to.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
    //            t2 = VB_Classes.Dates.Dates_Operation.date_validate(prot_strt_date_to.Text.Trim());
    //            sql += " AND convert(datetime,Strt_DT,103) < = '" + t2.ToString() + "'";
    //        }
    //        else
    //        {
    //            ShowAlertMessage("!!!!!ادخل التاريخ بطريقة صحيحة !!!!");
    //            return;
    //        }
            
            

            
    //    }
    //    else if (string.IsNullOrEmpty(prot_strt_date_to.Text))
    //    {
    //        if (VB_Classes.Dates.Dates_Operation.date_validate(prot_strt_date_from.Text.Trim()) != "")
    //        {
    //            //t1 = DateTime.ParseExact(Inbox_date_from.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
    //            t2 = DateTime.MaxValue.ToString("dd/MM/yyyy");
    //            t1 = VB_Classes.Dates.Dates_Operation.date_validate(prot_strt_date_from.Text.Trim());
    //            sql += " AND convert(datetime,Strt_DT,103) > = '" + t1.ToString() + "'";

    //        }
    //        else
    //        {
    //            ShowAlertMessage("!!!!!ادخل التاريخ بطريقة صحيحة !!!!");
    //            return;
    //        }

    //    }
    //    else
    //    {
    //        if (VB_Classes.Dates.Dates_Operation.date_validate(prot_strt_date_to.Text.Trim()) != "" && VB_Classes.Dates.Dates_Operation.date_validate(prot_strt_date_from.Text.Trim()) != "")
    //        {
    //            //t1 = DateTime.ParseExact(Inbox_date_from.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
    //            t2 = VB_Classes.Dates.Dates_Operation.date_validate(prot_strt_date_to.Text.Trim());
    //            //t2 = DateTime.ParseExact(Inbox_date_to.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
    //            t1 = VB_Classes.Dates.Dates_Operation.date_validate(prot_strt_date_from.Text.Trim());
    //            sql += " AND convert(datetime,Strt_DT,103) > = '" + t1.ToString() + "'";
    //            sql += " AND convert(datetime,Strt_DT,103) < = '" + t2.ToString() + "'";
    //        }
    //        else
    //        {
    //            ShowAlertMessage("!!!!!ادخل التاريخ بطريقة صحيحة !!!!");
    //            return;
    //        }

    //    }
    //    DateTime date1 = DateTime.ParseExact(t1, "dd/MM/yyyy", null);
    //    DateTime date2 = DateTime.ParseExact(t2, "dd/MM/yyyy", null);
    //    if (date2.Subtract(date1).Days < 0)
    //    {
    //        ShowAlertMessage("!!!!!التاريخ الأول يجب ان يكون قبل التاريخ الثاني !!!!");
    //        return;
    //    }
    //    //////////////////////////////////////////////////////////// finished check on sign_strt_Date/////////////////////////////////////

    //    /////////////////////////////////////////////////////// begin check on sign_end_date///////////////////////////////////////////
    //    if (string.IsNullOrEmpty(prot_end_date_from.Text) && string.IsNullOrEmpty(prot_end_date_to.Text))
    //    {
    //        t3 = DateTime.ParseExact("01/01/1900", "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
    //        t4 = DateTime.MaxValue.ToString("dd/MM/yyyy");
    //    }
    //    else if (string.IsNullOrEmpty(prot_end_date_from.Text))
    //    {
    //        if (VB_Classes.Dates.Dates_Operation.date_validate(prot_end_date_to.Text.Trim()) != "")
    //        {
    //            t3 = DateTime.ParseExact("01/01/1900", "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
    //            //t2 = DateTime.ParseExact(Outbox_date_to.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
    //            t4 = VB_Classes.Dates.Dates_Operation.date_validate(prot_end_date_to.Text.Trim());
    //            sql += " AND convert(datetime,End_DT,103) < = '" + t4.ToString() + "'";
    //        }
    //        else
    //        {
    //            ShowAlertMessage("!!!!!ادخل التاريخ بطريقة صحيحة !!!!");
    //            return;
    //        }
           
    //    }
    //    else if (string.IsNullOrEmpty(prot_end_date_to.Text))
    //    {
    //        if (VB_Classes.Dates.Dates_Operation.date_validate(prot_end_date_from.Text.Trim()) != "")
    //        {
    //            //t1 = DateTime.ParseExact(Outbox_date_from.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
    //            t4 = DateTime.MaxValue.ToString("dd/MM/yyyy");
    //            t3 = VB_Classes.Dates.Dates_Operation.date_validate(prot_end_date_from.Text.Trim());
    //            sql += " AND convert(datetime,End_DT,103) > = '" + t3.ToString() + "'";
    //        }
    //        else
    //        {
    //            ShowAlertMessage("!!!!!ادخل التاريخ بطريقة صحيحة !!!!");
    //            return;
    //        }
           
    //    }
    //    else
    //    {
    //        if (VB_Classes.Dates.Dates_Operation.date_validate(prot_end_date_to.Text.Trim()) != "" && VB_Classes.Dates.Dates_Operation.date_validate(prot_end_date_from.Text.Trim()) != "")
    //        {
    //            //t1 = DateTime.ParseExact(Outbox_date_from.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
    //            //t2 = DateTime.ParseExact(Outbox_date_to.Text, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
    //            t4 = VB_Classes.Dates.Dates_Operation.date_validate(prot_end_date_to.Text.Trim());
    //            t3 = VB_Classes.Dates.Dates_Operation.date_validate(prot_end_date_from.Text.Trim());
    //            sql += " AND convert(datetime,End_DT,103) > = '" + t3.ToString() + "'";
    //            sql += " AND convert(datetime,End_DT,103) < = '" + t4.ToString() + "'";
    //        }
    //        else
    //        {
    //            ShowAlertMessage("!!!!!ادخل التاريخ بطريقة صحيحة !!!!");
    //            return;
    //        }
           

    //    }
    //    /////////////////////////////////////////////////////////////////// end check on sign_end _date/////////////////////////////////////

    //    //sql += " order by dbo.Protocol_Main_Def.Protocol_ID desc";
    //    sql += "order by " + sortExp + " " + direction;
    //    DateTime date3 = DateTime.ParseExact(t3, "dd/MM/yyyy", null);
    //    DateTime date4 = DateTime.ParseExact(t4, "dd/MM/yyyy", null);
    //    if (date4.Subtract(date3).Days < 0)
    //    {
    //        ShowAlertMessage("!!!!!التاريخ الأول يجب ان يكون قبل التاريخ الثاني !!!!");
    //        return;
    //    }
        
    //    DataTable dt = General_Helping.GetDataTable(sql);

    //    float y = dt.Rows.Count;
    //    float sa = y / 10;
        
    //    page_total_count = CDataConverter.ConvertToInt(System.Math.Ceiling(CDataConverter.ConvertToDecimal(sa)));
    //    Session["page_total_count"] = page_total_count.ToString();
    //    if (dt.Rows.Count == 0)
    //    {
    //        gvMain.EmptyDataText = ".....عفوا لا يوجد بيانات ......";
    //        tr_paging.Visible = false;
    //        tr_page_count.Visible = false;
    //    }
    //    else
    //    {
    //        gvMain.DataSource = dt;
    //        tr_paging.Visible = true;
    //        tr_page_count.Visible = true;
    //        lbl_page_count.Text = page_total_count.ToString();
    //    }
    //    gvMain.DataBind();
    //}

    protected void SaveButton_Click(object sender, EventArgs e)
    {
        SearchRecord(0, "Protocol_ID", "desc");
      //  SearchRecord2();
    }


    protected void gvMain_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void gvMain_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "Related_Item")
        {
            Response.Redirect("Protocol_Main.aspx?Related_ID=" + e.CommandArgument);
        }
        if (e.CommandName == "EditItem")
        {
            if (CDataConverter.ConvertToInt(Session_CS.group_id.ToString()) == 4)
            {
                Response.Redirect("Protocol_Main_Details.aspx?ID=" + e.CommandArgument);
            }
            else
            { Response.Redirect("Protocol_Main.aspx?ID=" + e.CommandArgument); }
            
        }
        if (e.CommandName == "RemoveItem")
        {

            Protocol_Main_Def_DB.Delete(CDataConverter.ConvertToInt(e.CommandArgument));
            gvMain.DataBind();
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم الحذف بنجاح')</script>");
            SearchRecord(0, "Protocol_ID", "desc");
        }

    }
    protected void gvMain_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvMain.PageIndex = e.NewPageIndex;
        txt_page_no.Text = (e.NewPageIndex+1).ToString();
        SearchRecord(CDataConverter.ConvertToInt(e.NewPageIndex.ToString()), "Protocol_ID", "ASC");
    }

    public string Get_Type(object obj)
    {
        string str = obj.ToString();
        if (str == "1")
            return "بروتوكول";
        else if (str == "2")
            return "اتفاقية";
        else if (str == "3")
            return "موافقة سلطة مختصة";
        else return "";
    }
    protected void gvMain_Sorting(object sender, GridViewSortEventArgs e)
    {
        string direction = HiddenField1.Value;
        if (direction == "ASC")
            HiddenField1.Value = "DESC";
        else
            HiddenField1.Value = "ASC";

        SearchRecord(CDataConverter.ConvertToInt(gvMain.PageIndex.ToString()), e.SortExpression, direction);
    }
   
    protected void Btn_page_Click(object sender, EventArgs e)
    {
        if (CDataConverter.ConvertToInt( txt_page_no.Text)  > 0  )
        {
            if (CDataConverter.ConvertToInt(txt_page_no.Text) <= gvMain.PageCount )
            {
                gvMain.PageIndex = CDataConverter.ConvertToInt(txt_page_no.Text)-1;
                SearchRecord(CDataConverter.ConvertToInt(gvMain.PageIndex.ToString()), "Protocol_ID", "ASC");
            }
            else
            {
                ShowAlertMessage("!!!!! رقم الصفحة الذي أدخلته غير موجود !!!!");
                txt_page_no.Text = "";
                return;
            }
        }
        else
        {
            //ShowAlertMessage("!!!!!لم يتم كتابة رقم الصفحة !!!!");
            return;
        }
    }
}
