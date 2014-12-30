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
using ReportsClass;

public partial class UserControls_Training_Reports : System.Web.UI.UserControl
{
    General_Helping Obj_General_Helping = new General_Helping();
    //Session_CS Session_CS = new Session_CS();
    string sql;
    SqlConnection conn;
    SqlDataAdapter da;
    DataSet ds;

    private string sql_Connection = Universal.GetConnectionString();

    protected override void OnInit(EventArgs e)
    {


        #region BROWSER FOR departments

        Smart_dept.sql_Connection = sql_Connection;
        string Query = "select Dept_ID,Dept_name from Departments ";
        Smart_dept.datatble = General_Helping.GetDataTable(Query);
        Smart_dept.Value_Field = "Dept_ID";
        Smart_dept.Text_Field = "Dept_name";
        Smart_dept.DataBind();
        this.Smart_dept.Value_Handler += new Smart_Search.Delegate_Selected_Value(MOnMember_Data);




        ////////////////////////////////////////////////////////////

        smart_employee.sql_Connection = sql_Connection;
        string Query1 = "select PMP_ID,pmp_name from dbo.EMPLOYEE ";
        smart_employee.datatble = General_Helping.GetDataTable(Query1);
        smart_employee.Value_Field = "PMP_ID";
        smart_employee.Text_Field = "pmp_name";
        smart_employee.DataBind();

        //////////////////////////////////////////////////////////




        #endregion


        base.OnInit(e);
    }


    private void MOnMember_Data(string Value)
    {

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Fill_course_Dll();
            fill_grid_courses();
        }
    }


    private void fill_grid_courses()
    {
        DataTable dt = General_Helping.GetDataTable("set dateformat dmy SELECT course.id, Courses.course_id, Courses.course_name, course.last_register_date,course.emp_no, course.created_by, course.organization, course.comments, course.candidate_criteria, course.duration, course.refrences, course.refrance_file, course.inbox_id, Course_Places.place_desc, Course_Tracks.track_name FROM Courses INNER JOIN course ON Courses.course_id = course.course_id INNER JOIN Course_Places ON Course_Places.place_id = course.course_place INNER JOIN EMPLOYEE AS EMPLOYEE_1 ON EMPLOYEE_1.PMP_ID = course.created_by INNER JOIN Course_Tracks ON Courses.course_id = Course_Tracks.course_id order by convert(datetime, course.last_register_date) desc");
        gv_viewuserrequest.DataSource = dt;
        gv_viewuserrequest.DataBind();
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

    public static void ShowAlertMessage(string error)
    {

        Page page = HttpContext.Current.Handler as Page;
        if (page != null)
        {
            error = error.Replace("'", "\'");
            ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('" + error + "');", true);
        }
    }

    protected void show_hide_tables()
    {
        tbl_Report.Style.Add("display", "none");
        tbl_Paramater.Style.Add("display", "block");
        tbl_Paramater1.Style.Add("display", "block");
    }


    
    private void Fill_course_Dll()
    {
        DataTable DTcourse = new DataTable();
        DTcourse = General_Helping.GetDataTable("select course_id,course_name from courses ");
        Obj_General_Helping.SmartBindDDL(dll_course, DTcourse, "course_id", "course_name", "....اختر إسم الدورة ....");
    }

    protected void Training_emp_Click(object sender, EventArgs e)
    {
        hidden_Rpt_Id.Value = "Training_employee";

        Div_dept.Style.Add("display", "block");
        Div_emp.Style.Add("display", "block");
        show_hide_tables();
        Page.Title = "تقرير " + Training_emp.Text;
        Label2.Visible = true;
        Label2.Text = Page.Title;
    }
    protected void Emp_Training_Click(object sender, EventArgs e)
    {
        hidden_Rpt_Id.Value = "Employee_trainings";

        Div_dept.Style.Add("display", "none");
        Div_emp.Style.Add("display", "none");
        Div_course.Style.Add("display", "block");
        show_hide_tables();

        Page.Title = "تقرير " + emptraining.Text;
        Label2.Visible = true;
        Label2.Text = Page.Title;
        dll_course.Visible = false;
        Button1.Visible = false;
    }
    protected void Emp_Approved_Training_Click(object sender, EventArgs e)
    {
        hidden_Rpt_Id.Value = "Emp_Approved_Training";

        Div_dept.Style.Add("display", "none");
        Div_emp.Style.Add("display", "none");
        Div_course.Style.Add("display", "block");
        show_hide_tables();

        Page.Title = "تقرير " + Emp_Approved_Training.Text;
        Label2.Visible = true;
        Label2.Text = Page.Title;
        dll_course.Visible = false;
        Button1.Visible = false;
    }


    protected void Emp_HR_Approved_Training_Click(object sender, EventArgs e)
    {
        hidden_Rpt_Id.Value = "Emp_HR_Approved_Training";

        Div_dept.Style.Add("display", "none");
        Div_emp.Style.Add("display", "none");
        Div_course.Style.Add("display", "block");
        show_hide_tables();

        Page.Title = "تقرير " + hr_approved_courses.Text ;
        Label2.Visible = true;
        Label2.Text = Page.Title;
        dll_course.Visible = false;
        Button1.Visible = false;
    }
    protected void Course_Results_Click(object sender, EventArgs e)
    {
        hidden_Rpt_Id.Value = "Course_Results";

        Div_dept.Style.Add("display", "none");
        Div_emp.Style.Add("display", "none");
        Div_course.Style.Add("display", "block");
        show_hide_tables();

        Page.Title = "تقرير " + lnk_results.Text;
        Label2.Visible = true;
        Label2.Text = Page.Title;
        dll_course.Visible = false;
        Button1.Visible = false;
    }

    protected void Emp_Passed_Training_Click(object sender, EventArgs e)
    {
        hidden_Rpt_Id.Value = "Emp_Passed_Training";

        Div_dept.Style.Add("display", "none");
        Div_emp.Style.Add("display", "none");
        Div_course.Style.Add("display", "block");
        show_hide_tables();

        Page.Title = "تقرير " + Emp_Passed_Training.Text;
        Label2.Visible = true;
        Label2.Text = Page.Title;
        dll_course.Visible = false;
        Button1.Visible = false;
    }
    protected void Emp_total_no_Training_Click(object sender, EventArgs e)
    {
        hidden_Rpt_Id.Value = "Emp_total_no_Training";
        SqlConnection conn = new SqlConnection(sql_Connection);

        sql = " select * from Training_View order by Training_View.course_id ";
        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        string user = Session_CS.pmp_name.ToString();
        ReportDocument rd = new ReportDocument();
        string s = Server.MapPath("../Reports/Employee_total_no_training.rpt");
        rd.Load(s);
        rd.SetDataSource(dt);
        Reports.Load_Report(rd);

        rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
        rd.SetParameterValue("@user", user, "footerRep.rpt");
        // rd.SetParameterValue("@id", dll_course.SelectedValue);

        if (rd.Rows.Count == 0)
        {
            ShowAlertMessage("هذا التقرير لا يوجد به بيانات للعرض !!!!");
            return;
        }
        else
        {
            rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report");
        }
        //Div_dept.Style.Add("display", "none");
        //Div_emp.Style.Add("display", "none");
        //Div_course.Style.Add("display", "block");
        //show_hide_tables();

        //Page.Title = "تقرير " + Emp_total_no_Training.Text;
        //Label2.Visible = true;
        //Label2.Text = Page.Title;
    }
    //protected void Emp_total_no_Training_drow_Click(object sender, EventArgs e)
    //{
    //    //hidden_Rpt_Id.Value = "Emp_total_no_Training";
    //    SqlConnection conn = new SqlConnection(sql_Connection);

    //    sql = " select * from Training_View order by Training_View.source_id ";
    //    //sql += " group by course_id,course_name";

    //    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
    //    DataTable dt = new DataTable();
    //    da.Fill(dt);
    //    string user = Session_CS.pmp_name.ToString();
    //    ReportDocument rd = new ReportDocument();
    //    string s = Server.MapPath("../Reports/Employee_total_no_training_drow.rpt");
    //    rd.Load(s);
    //    rd.SetDataSource(dt);
    //    Load_Report(rd);

    //    rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
    //    rd.SetParameterValue("@user", user, "footerRep.rpt");
    //    // rd.SetParameterValue("@id", dll_course.SelectedValue);

    //    if (rd.Rows.Count == 0)
    //    {
    //        ShowAlertMessage("هذا التقرير لا يوجد به بيانات للعرض !!!!");
    //        return;
    //    }
    //    else
    //    {
    //        rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report");
    //    }
    //    //Div_dept.Style.Add("display", "none");
    //    //Div_emp.Style.Add("display", "none");
    //    //Div_course.Style.Add("display", "block");
    //    //show_hide_tables();

    //    //Page.Title = "تقرير " + Emp_total_no_Training.Text;
    //    //Label2.Visible = true;
    //    //Label2.Text = Page.Title;
    //}

    protected void ImgBtnBack_Click(object sender, ImageClickEventArgs e)
    {
        //DataTable dt = General_Helping.GetDataTable("select System_ID from Users where pmp_pmp_id = " + CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()) + "and [USR_Name] = '" + Session_CS.Usr_Name.ToString() + "'");
        //if (dt.Rows[0]["System_ID"].ToString() == "1")
        //{
            Response.Redirect("../MainForm/Training_Reports.aspx");
        //}
        //else
        //{
        //    Response.Redirect("../WebForms2/Training_Reports.aspx");
        //}
    }



    protected void Button1_Click(object sender, EventArgs e)
    {

        /////////////////////////////////////////////////////////// Employee Training Courses Report ///////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        if (hidden_Rpt_Id.Value == "Training_employee")
        {
            SqlConnection conn = new SqlConnection(sql_Connection);

            int dept_id = 0;
            int emp_id = 0;


            sql = "select courses.course_id,courses.course_name,Course_Places.place_desc,course.last_register_date,course.organization,EMPLOYEE.PMP_ID,EMPLOYEE.pmp_name,Departments.Dept_ID,Departments.Dept_name  from EMPLOYEE inner join Departments on EMPLOYEE.Dept_Dept_id=Departments.Dept_ID inner join course_employee on course_employee.emp_id=EMPLOYEE.PMP_ID  inner join course on course.id=course_employee.course_id inner join Course_Places on Course_Places.place_id = course.course_place inner join courses on courses.course_id=course.course_id and  course_employee.status=1 where 1=1 ";
            
            if (smart_employee.SelectedValue != "")
            {
                //emp_id = int.Parse(smart_employee.SelectedValue);

                sql += " AND EMPLOYEE.PMP_ID=" + CDataConverter.ConvertToInt(smart_employee.SelectedValue);
            }

            if (Smart_dept.SelectedValue != "")
            {
                //dept_id = int.Parse(Smart_dept.SelectedValue);
                sql += " AND Departments.Dept_ID = " + CDataConverter.ConvertToInt(Smart_dept.SelectedValue);
            }
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);



            string user = Session_CS.pmp_name.ToString();
            ReportDocument rd = new ReportDocument();
            string s = Server.MapPath("../Reports/Training_Detail.rpt");
            rd.Load(s);
            rd.SetDataSource(dt);
            Reports.Load_Report(rd);

            rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
            rd.SetParameterValue("@user", user, "footerRep.rpt");
            if (rd.Rows.Count == 0)
            {
                ShowAlertMessage("هذا التقرير لا يوجد به بيانات للعرض !!!!");
                return;
            }
            else
            {
                rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report");
            }


        }

        else if (hidden_Rpt_Id.Value == "Employee_trainings")
        {
            SqlConnection conn = new SqlConnection(sql_Connection);
            if (dll_course.SelectedIndex != 0)
            {
                sql = "SELECT courses.course_name, EMPLOYEE.pmp_name, course_employee.status,courses.course_id FROM course INNER JOIN course_employee ON course.id = course_employee.course_id inner join courses on course.course_id=courses.course_id INNER JOIN EMPLOYEE ON course_employee.emp_id = EMPLOYEE.PMP_ID where 1=1";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                string user = Session_CS.pmp_name.ToString();
                ReportDocument rd = new ReportDocument();
                string s = Server.MapPath("../Reports/Training_emp.rpt");
                rd.Load(s);
                rd.SetDataSource(dt);
                Reports.Load_Report(rd);

                rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
                rd.SetParameterValue("@user", user, "footerRep.rpt");
                rd.SetParameterValue("@id", dll_course.SelectedValue);

                if (rd.Rows.Count == 0)
                {
                    ShowAlertMessage("هذا التقرير لا يوجد به بيانات للعرض !!!!");
                    return;
                }
                else
                {
                    rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report");
                }

            }
            else
            {
                ShowAlertMessage("!!!!!يجب اختيار اسم الدورة لعرض هذا التقرير !!!!");
                return;
            }
        }

        else if (hidden_Rpt_Id.Value == "Emp_Approved_Training")
        {
            SqlConnection conn = new SqlConnection(sql_Connection);
            if (dll_course.SelectedIndex != 0)
            {
                sql = " SELECT  courses.course_name, courses.course_id,Course_Places.place_desc ,course.start_date,course.end_date ,course.duration, course.organization,EMPLOYEE.PMP_ID, EMPLOYEE.pmp_name, Departments.Dept_id, Departments.Dept_name, EMPLOYEE.Hire_date,EMPLOYEE.pmp_title, EMPLOYEE.job_no FROM EMPLOYEE INNER JOIN Departments ON EMPLOYEE.Dept_Dept_id = Departments.Dept_id  INNER JOIN course_employee ON course_employee.emp_id = EMPLOYEE.PMP_ID INNER JOIN course ON course.id = course_employee.course_id inner join courses on courses.course_id = course.course_id inner join Course_Places on Course_Places.place_id = course.course_place WHERE     (course_employee.is_admin_approved = 1)";
                sql += "and courses.course_id='" + dll_course.SelectedValue + "' order by dept_id";

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                string user = Session_CS.pmp_name.ToString();
                ReportDocument rd = new ReportDocument();
                string s = Server.MapPath("../Reports/Employee_approved_Trainings.rpt");
                rd.Load(s);
                rd.SetDataSource(dt);
                Reports.Load_Report(rd);

                rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
                rd.SetParameterValue("@user", user, "footerRep.rpt");
                // rd.SetParameterValue("@id", dll_course.SelectedValue);

                if (rd.Rows.Count == 0)
                {
                    ShowAlertMessage("هذا التقرير لا يوجد به بيانات للعرض !!!!");
                    return;
                }
                else
                {
                    rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report");
                }
            }
            else
            {
                ShowAlertMessage("!!!!!يجب اختيار اسم الدورة لعرض هذا التقرير !!!!");
                return;

            }


        }



        else if (hidden_Rpt_Id.Value == "Emp_HR_Approved_Training")
        {
            SqlConnection conn = new SqlConnection(sql_Connection);
            if (dll_course.SelectedIndex != 0)
            {
                sql = "select courses.course_id, courses.course_name,course.start_date,course.end_date,Course_Places.place_desc,course_employee.admin_descion,EMPLOYEE.PMP_ID,EMPLOYEE.pmp_name,EMPLOYEE.job_no,EMPLOYEE.pmp_title  ,EMPLOYEE.Hire_date,Departments.Dept_ID,Departments.Dept_name from EMPLOYEE inner join Departments on EMPLOYEE.Dept_Dept_id=Departments.Dept_ID inner join course_employee on course_employee.emp_id=EMPLOYEE.PMP_ID inner join course on course.id=course_employee.course_id inner join Course_Places on course.course_place =Course_Places.place_id inner join courses on courses.course_id=course.course_id where 1=1";

                sql += "and courses.course_id='" + dll_course.SelectedValue + "'  ";

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                string user = Session_CS.pmp_name.ToString();
                ReportDocument rd = new ReportDocument();
                string s = Server.MapPath("../Reports/Employee_Approved_HR_Training.rpt");
                rd.Load(s);
                rd.SetDataSource(dt);
                Reports.Load_Report(rd);

                rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
                rd.SetParameterValue("@user", user, "footerRep.rpt");
                // rd.SetParameterValue("@id", dll_course.SelectedValue);

                if (rd.Rows.Count == 0)
                {
                    ShowAlertMessage("هذا التقرير لا يوجد به بيانات للعرض !!!!");
                    return;
                }
                else
                {
                    rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report");
                }
            }
            else
            {
                ShowAlertMessage("!!!!!يجب اختيار اسم الدورة لعرض هذا التقرير !!!!");
                return;

            }


        }



        else if (hidden_Rpt_Id.Value == "Emp_Passed_Training")
        {
            SqlConnection conn = new SqlConnection(sql_Connection);
            if (dll_course.SelectedIndex != 0)
            {
                sql = "select courses.course_name, courses.course_id,Course_Places.place_desc , course.duration, course.organization,EMPLOYEE.PMP_ID,EMPLOYEE.pmp_name, Departments.Dept_id, Departments.Dept_name,EMPLOYEE.Hire_date, EMPLOYEE.pmp_title, EMPLOYEE.job_no FROM         EMPLOYEE INNER JOIN     Departments ON EMPLOYEE.Dept_Dept_id = Departments.Dept_id INNER JOIN course_employee ON course_employee.emp_id = EMPLOYEE.PMP_ID INNER JOIN course ON course.id = course_employee.course_id inner join courses on courses.course_id = course.course_id inner join Course_Places on Course_Places.place_id = course.course_place WHERE     (course_employee.result = 1)";
                sql += "and courses.course_id='" + dll_course.SelectedValue + "' order by dept_id";

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                string user = Session_CS.pmp_name.ToString();
                ReportDocument rd = new ReportDocument();
                string s = Server.MapPath("../Reports/Employee_passed_Training.rpt");
                rd.Load(s);
                rd.SetDataSource(dt);
                Reports.Load_Report(rd);

                rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
                rd.SetParameterValue("@user", user, "footerRep.rpt");
                // rd.SetParameterValue("@id", dll_course.SelectedValue);

                if (rd.Rows.Count == 0)
                {
                    ShowAlertMessage("هذا التقرير لا يوجد به بيانات للعرض !!!!");
                    return;
                }
                else
                {
                    rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report");
                }
            }
            else
            {
                ShowAlertMessage("!!!!!يجب اختيار اسم الدورة لعرض هذا التقرير !!!!");
                return;

            }
        }
        /////////////////////////////////////// total no of employee Report/////////////////////////////
        else if (hidden_Rpt_Id.Value == "Emp_total_no_Training")
        {
            SqlConnection conn = new SqlConnection(sql_Connection);

            sql = " SELECT  course_id,course.course_name,COUNT(course_employee.id) AS 'أعداد المتقدمين',sum(CASE admin_descion WHEN 1 THEN 1 ELSE 0 END) AS [مقبول],sum(CASE admin_descion WHEN 2 THEN 1 ELSE 0 END) AS [غير مقبول],sum(CASE result WHEN 1 THEN 1 ELSE 0 END) AS [ناجح],sum(CASE result WHEN 2 THEN 1 ELSE 0 END) AS [راسب], sum(CASE result WHEN 3 THEN 1 ELSE 0 END) AS [معتذر] from dbo.course_employee INNER JOIN  course ON course_employee.course_id = course.id ";
            sql += "' group by course_id,course_name";

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            string user = Session_CS.pmp_name.ToString();
            ReportDocument rd = new ReportDocument();
            string s = Server.MapPath("../Reports/Employee_total_no_training.rpt");
            rd.Load(s);
            rd.SetDataSource(dt);
            Reports.Load_Report(rd);

            rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
            rd.SetParameterValue("@user", user, "footerRep.rpt");
            // rd.SetParameterValue("@id", dll_course.SelectedValue);

            if (rd.Rows.Count == 0)
            {
                ShowAlertMessage("هذا التقرير لا يوجد به بيانات للعرض !!!!");
                return;
            }
            else
            {
                rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report");
            }

            //else
            //{
            //    ShowAlertMessage("!!!!!يجب اختيار اسم الدورة لعرض هذا التقرير !!!!");
            //    return;

            //}
        }

        else if (hidden_Rpt_Id.Value == "Course_Results")
        {
            SqlConnection conn = new SqlConnection(sql_Connection);

            string SQL = "SELECT course_employee.course_id courseID,pmp_name,Dept_name,course.start_date,course. end_date,Course_Places.place_desc,courses.course_name, CASE WHEN result = 1 THEN 1 ELSE 0 END succeeded,CASE WHEN result = 2 THEN 1 ELSE 0 END failure FROM  course_employee JOIN EMPLOYEE ON dbo.course_employee.emp_id = dbo.EMPLOYEE.PMP_ID JOIN dbo.Departments ON dbo.EMPLOYEE.Dept_Dept_id = dbo.Departments.Dept_id JOIN course ON dbo.course_employee.course_id = dbo.course.id JOIN courses ON dbo.course.course_id = dbo.courses.course_id inner join Course_Places on course.course_place =Course_Places.place_id";
 
    

                if(dll_course.SelectedIndex != 0)
                {
                    SQL += " AND courses.course_id = " + dll_course.SelectedValue  ;
                  
                }
                SqlDataAdapter da = new SqlDataAdapter(SQL, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                string user = Session_CS.pmp_name.ToString();
                ReportDocument rd = new ReportDocument();
                string s = Server.MapPath("../Reports/Courese_results.rpt");
                rd.Load(s);
                rd.SetDataSource(dt);
                Reports.Load_Report(rd);

                rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
                rd.SetParameterValue("@user", user, "footerRep.rpt");
                // rd.SetParameterValue("@id", dll_course.SelectedValue);

                if (rd.Rows.Count == 0)
                {
                    ShowAlertMessage("هذا التقرير لا يوجد به بيانات للعرض !!!!");
                    return;
                }
                else
                {
                    rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report");
                }
            
           
        }

        


    }

    protected void gv_viewuserrequest_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "EditItem")
        {
            if (hidden_Rpt_Id.Value == "Training_employee")
            {
                SqlConnection conn = new SqlConnection(sql_Connection);

                int dept_id = 0;
                int emp_id = 0;


                sql = "select courses.course_id,courses.course_name,Course_Places.place_desc,course.last_register_date,course.organization,EMPLOYEE.PMP_ID,EMPLOYEE.pmp_name,Departments.Dept_ID,Departments.Dept_name  from EMPLOYEE inner join Departments on EMPLOYEE.Dept_Dept_id=Departments.Dept_ID inner join course_employee on course_employee.emp_id=EMPLOYEE.PMP_ID  inner join course on course.id=course_employee.course_id inner join Course_Places on Course_Places.place_id = course.course_place inner join courses on courses.course_id=course.course_id and  course_employee.status=1 where 1=1 ";

                if (smart_employee.SelectedValue != "")
                {
                    //emp_id = int.Parse(smart_employee.SelectedValue);

                    sql += " AND EMPLOYEE.PMP_ID=" + CDataConverter.ConvertToInt(smart_employee.SelectedValue);
                }

                if (Smart_dept.SelectedValue != "")
                {
                    //dept_id = int.Parse(Smart_dept.SelectedValue);
                    sql += " AND Departments.Dept_ID = " + CDataConverter.ConvertToInt(Smart_dept.SelectedValue);
                }
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);



                string user = Session_CS.pmp_name.ToString();
                ReportDocument rd = new ReportDocument();
                string s = Server.MapPath("../Reports/Training_Detail.rpt");
                rd.Load(s);
                rd.SetDataSource(dt);
                Reports.Load_Report(rd);

                rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
                rd.SetParameterValue("@user", user, "footerRep.rpt");
                if (rd.Rows.Count == 0)
                {
                    ShowAlertMessage("هذا التقرير لا يوجد به بيانات للعرض !!!!");
                    return;
                }
                else
                {
                    rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report");
                }


            }

            else if (hidden_Rpt_Id.Value == "Employee_trainings")
            {
                SqlConnection conn = new SqlConnection(sql_Connection);
                 sql = "SELECT courses.course_name, EMPLOYEE.pmp_name, course_employee.status,course.id FROM course INNER JOIN course_employee ON course.id = course_employee.course_id inner join courses on course.course_id=courses.course_id INNER JOIN EMPLOYEE ON course_employee.emp_id = EMPLOYEE.PMP_ID where 1=1";
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    string user = Session_CS.pmp_name.ToString();
                    ReportDocument rd = new ReportDocument();
                    string s = Server.MapPath("../Reports/Training_emp.rpt");
                    rd.Load(s);
                    rd.SetDataSource(dt);
                    Reports.Load_Report(rd);

                    rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
                    rd.SetParameterValue("@user", user, "footerRep.rpt");
                    rd.SetParameterValue("@id", CDataConverter.ConvertToInt(e.CommandArgument));

                    if (rd.Rows.Count == 0)
                    {
                        ShowAlertMessage("هذا التقرير لا يوجد به بيانات للعرض !!!!");
                        return;
                    }
                    else
                    {
                        rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report");
                    }

               
            }

            else if (hidden_Rpt_Id.Value == "Emp_Approved_Training")
            {
                SqlConnection conn = new SqlConnection(sql_Connection);

                sql = " SELECT  courses.course_name, courses.course_id,Course_Places.place_desc ,course.start_date,course.end_date ,course.duration, course.organization,EMPLOYEE.PMP_ID, EMPLOYEE.pmp_name, Departments.Dept_id, Departments.Dept_name, EMPLOYEE.Hire_date,EMPLOYEE.pmp_title, EMPLOYEE.job_no FROM EMPLOYEE INNER JOIN Departments ON EMPLOYEE.Dept_Dept_id = Departments.Dept_id  INNER JOIN course_employee ON course_employee.emp_id = EMPLOYEE.PMP_ID INNER JOIN course ON course.id = course_employee.course_id inner join courses on courses.course_id = course.course_id inner join Course_Places on Course_Places.place_id = course.course_place WHERE     (course_employee.is_admin_approved = 1)";
                sql += "and course_employee.course_id='" + CDataConverter.ConvertToInt(e.CommandArgument) + "' order by dept_id";

                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    string user = Session_CS.pmp_name.ToString();
                    ReportDocument rd = new ReportDocument();
                    string s = Server.MapPath("../Reports/Employee_approved_Trainings.rpt");
                    rd.Load(s);
                    rd.SetDataSource(dt);
                    Reports.Load_Report(rd);

                    rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
                    rd.SetParameterValue("@user", user, "footerRep.rpt");
                    // rd.SetParameterValue("@id", dll_course.SelectedValue);

                    if (rd.Rows.Count == 0)
                    {
                        ShowAlertMessage("هذا التقرير لا يوجد به بيانات للعرض !!!!");
                        return;
                    }
                    else
                    {
                        rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report");
                    }
              


            }



            else if (hidden_Rpt_Id.Value == "Emp_HR_Approved_Training")
            {
                SqlConnection conn = new SqlConnection(sql_Connection);
               
                    sql = "select courses.course_id, courses.course_name,course.start_date,course.end_date,Course_Places.place_desc,course_employee.admin_descion,EMPLOYEE.PMP_ID,EMPLOYEE.pmp_name,EMPLOYEE.job_no,EMPLOYEE.pmp_title  ,EMPLOYEE.Hire_date,Departments.Dept_ID,Departments.Dept_name from EMPLOYEE inner join Departments on EMPLOYEE.Dept_Dept_id=Departments.Dept_ID inner join course_employee on course_employee.emp_id=EMPLOYEE.PMP_ID inner join course on course.id=course_employee.course_id inner join Course_Places on course.course_place =Course_Places.place_id inner join courses on courses.course_id=course.course_id where 1=1";

                    sql += "and course.id='" + CDataConverter.ConvertToInt(e.CommandArgument) + "'  ";

                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    string user = Session_CS.pmp_name.ToString();
                    ReportDocument rd = new ReportDocument();
                    string s = Server.MapPath("../Reports/Employee_Approved_HR_Training.rpt");
                    rd.Load(s);
                    rd.SetDataSource(dt);
                    Reports.Load_Report(rd);

                    rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
                    rd.SetParameterValue("@user", user, "footerRep.rpt");
                    // rd.SetParameterValue("@id", dll_course.SelectedValue);

                    if (rd.Rows.Count == 0)
                    {
                        ShowAlertMessage("هذا التقرير لا يوجد به بيانات للعرض !!!!");
                        return;
                    }
                    else
                    {
                        rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report");
                    }
            


            }



            else if (hidden_Rpt_Id.Value == "Emp_Passed_Training")
            {
                SqlConnection conn = new SqlConnection(sql_Connection);
              
                    sql = "select courses.course_name, courses.course_id,Course_Places.place_desc , course.duration, course.organization,EMPLOYEE.PMP_ID,EMPLOYEE.pmp_name, Departments.Dept_id, Departments.Dept_name,EMPLOYEE.Hire_date, EMPLOYEE.pmp_title, EMPLOYEE.job_no FROM         EMPLOYEE INNER JOIN     Departments ON EMPLOYEE.Dept_Dept_id = Departments.Dept_id INNER JOIN course_employee ON course_employee.emp_id = EMPLOYEE.PMP_ID INNER JOIN course ON course.id = course_employee.course_id inner join courses on courses.course_id = course.course_id inner join Course_Places on Course_Places.place_id = course.course_place WHERE     (course_employee.result = 1)";
                    sql += "and course.id='" + CDataConverter.ConvertToInt(e.CommandArgument) + "' order by dept_id";

                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    string user = Session_CS.pmp_name.ToString();
                    ReportDocument rd = new ReportDocument();
                    string s = Server.MapPath("../Reports/Employee_passed_Training.rpt");
                    rd.Load(s);
                    rd.SetDataSource(dt);
                    Reports.Load_Report(rd);

                    rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
                    rd.SetParameterValue("@user", user, "footerRep.rpt");
                    // rd.SetParameterValue("@id", dll_course.SelectedValue);

                    if (rd.Rows.Count == 0)
                    {
                        ShowAlertMessage("هذا التقرير لا يوجد به بيانات للعرض !!!!");
                        return;
                    }
                    else
                    {
                        rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report");
                    }
             
            }
            /////////////////////////////////////// total no of employee Report/////////////////////////////
            else if (hidden_Rpt_Id.Value == "Emp_total_no_Training")
            {
                SqlConnection conn = new SqlConnection(sql_Connection);

                sql = " SELECT  course_id,course.course_name,COUNT(course_employee.id) AS 'أعداد المتقدمين',sum(CASE admin_descion WHEN 1 THEN 1 ELSE 0 END) AS [مقبول],sum(CASE admin_descion WHEN 2 THEN 1 ELSE 0 END) AS [غير مقبول],sum(CASE result WHEN 1 THEN 1 ELSE 0 END) AS [ناجح],sum(CASE result WHEN 2 THEN 1 ELSE 0 END) AS [راسب], sum(CASE result WHEN 3 THEN 1 ELSE 0 END) AS [معتذر] from dbo.course_employee INNER JOIN  course ON course_employee.course_id = course.id ";
                sql += "' group by course_id,course_name";

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                string user = Session_CS.pmp_name.ToString();
                ReportDocument rd = new ReportDocument();
                string s = Server.MapPath("../Reports/Employee_total_no_training.rpt");
                rd.Load(s);
                rd.SetDataSource(dt);
                Reports.Load_Report(rd);

                rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
                rd.SetParameterValue("@user", user, "footerRep.rpt");
                // rd.SetParameterValue("@id", dll_course.SelectedValue);

                if (rd.Rows.Count == 0)
                {
                    ShowAlertMessage("هذا التقرير لا يوجد به بيانات للعرض !!!!");
                    return;
                }
                else
                {
                    rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report");
                }

                //else
                //{
                //    ShowAlertMessage("!!!!!يجب اختيار اسم الدورة لعرض هذا التقرير !!!!");
                //    return;

                //}
            }

            else if (hidden_Rpt_Id.Value == "Course_Results")
            {
                SqlConnection conn = new SqlConnection(sql_Connection);

                string SQL = "SELECT course_employee.course_id courseID,pmp_name,Dept_name,course.start_date,course. end_date,Course_Places.place_desc,courses.course_name, CASE WHEN result = 1 THEN 1 ELSE 0 END succeeded,CASE WHEN result = 2 THEN 1 ELSE 0 END failure FROM  course_employee JOIN EMPLOYEE ON dbo.course_employee.emp_id = dbo.EMPLOYEE.PMP_ID JOIN dbo.Departments ON dbo.EMPLOYEE.Dept_Dept_id = dbo.Departments.Dept_id JOIN course ON dbo.course_employee.course_id = dbo.course.id JOIN courses ON dbo.course.course_id = dbo.courses.course_id inner join Course_Places on course.course_place =Course_Places.place_id";



               
                    SQL += " AND course.id = " + CDataConverter.ConvertToInt(e.CommandArgument);

               
                SqlDataAdapter da = new SqlDataAdapter(SQL, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                string user = Session_CS.pmp_name.ToString();
                ReportDocument rd = new ReportDocument();
                string s = Server.MapPath("../Reports/Courese_results.rpt");
                rd.Load(s);
                rd.SetDataSource(dt);
                Reports.Load_Report(rd);

                rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
                rd.SetParameterValue("@user", user, "footerRep.rpt");
                // rd.SetParameterValue("@id", dll_course.SelectedValue);

                if (rd.Rows.Count == 0)
                {
                    ShowAlertMessage("هذا التقرير لا يوجد به بيانات للعرض !!!!");
                    return;
                }
                else
                {
                    rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report");
                }


            }


        }

    }






    protected void CompletedCourse_Click(object sender, EventArgs e)
    {
       
        string SQL = " SELECT courses.course_id courseID,pmp_name, Dept_name,courses.course_name,CASE WHEN admin_descion = 1 THEN admin_descion ELSE 0 END accepted ,CASE WHEN admin_descion = 2 THEN 1 ELSE 0 END NoAccepted, CASE WHEN admin_descion = 5 THEN 1 ELSE 0 END apologized,CASE WHEN result = 1 THEN 1 ELSE 0 END succeeded, CASE WHEN result = 2 THEN 1 ELSE 0 END failure FROM  course_employee JOIN EMPLOYEE ON dbo.course_employee.emp_id = dbo.EMPLOYEE.PMP_ID JOIN dbo.Departments ON dbo.EMPLOYEE.Dept_Dept_id = dbo.Departments.Dept_id JOIN course ON dbo.course_employee.course_id = dbo.course.id join courses on  dbo.courses.course_id = course.course_id ORDER BY dbo.courses.course_id";
	  

        DataTable dt = General_Helping.GetDataTable(SQL);
      
        string user = Session_CS.pmp_name.ToString();
        ReportDocument rd = new ReportDocument();
        string s = Server.MapPath("../Reports/CompletedCoursesAndApplicantsNames.rpt");
        rd.Load(s);
        rd.SetDataSource(dt);
        Reports.Load_Report(rd);

        rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
        rd.SetParameterValue("@user", user, "footerRep.rpt");
        // rd.SetParameterValue("@id", dll_course.SelectedValue);

        if (rd.Rows.Count == 0)
        {
            ShowAlertMessage("هذا التقرير لا يوجد به بيانات للعرض !!!!");
            return;
        }
        else
        {
            rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report");
        }
         
    }
    protected void ITInfra_Courses_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(sql_Connection);

        sql = " SELECT    course.*,courses.course_name,place_desc FROM   course INNER JOIN courses on course.course_id = courses.course_id inner join Course_Places on course.course_place=Course_Places.place_id  WHERE (1 = 1)";

        DataTable dt = General_Helping.GetDataTable(sql);

        string user = Session_CS.pmp_name.ToString();
        ReportDocument rd = new ReportDocument();
        string s = Server.MapPath("../Reports/TrainingViewAllCourses.rpt");
        rd.Load(s);
        rd.SetDataSource(dt);
        Reports.Load_Report(rd);

        rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
        rd.SetParameterValue("@user", user, "footerRep.rpt");
        // rd.SetParameterValue("@id", dll_course.SelectedValue);

        if (rd.Rows.Count == 0)
        {
            ShowAlertMessage("هذا التقرير لا يوجد به بيانات للعرض !!!!");
            return;
        }
        else
        {
            rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report");
        }
    }

    protected void gv_viewuserrequest_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv_viewuserrequest.PageIndex = e.NewPageIndex;
        fill_grid_courses();
    }
}
