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

public partial class UserControls_Course_Programs : System.Web.UI.UserControl
{
    Session_CS Session_CS = new Session_CS();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(! IsPostBack )
        {
        //fill_grid();
        fill_programs();
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (ddl_programs.SelectedValue != "0" && tx_coursename.Text != "")
        {
            
            Courses_DT obj = new Courses_DT();
            obj.prog_id = CDataConverter.ConvertToInt(ddl_programs.SelectedValue);
            obj.course_name = tx_coursename.Text.Trim();
            obj.course_id = CDataConverter.ConvertToInt(course_id.Value);
            //--------------------------------------------------------------
            //Check first if a course with that name exists before saving
            string sqlComm = "SELECT * FROM Courses WHERE course_name='"+obj.course_name+"' AND prog_id="+obj.prog_id;
            SqlDataReader reader = SqlHelper.ExecuteReader(Database.ConnectionString,CommandType.Text,sqlComm);
            if (reader.HasRows)//This course name for that program does exist before
            {
                Page.RegisterStartupScript("Error", "<script language=javascript>alert('اسم الدورة التدريبية لهذا البرنامج يوجد من قبل، الرجاء اختيار اسم اخر.')</script>");
                return;//Will not continue to save to prevent repeated names
 
            }
            //Else will go ahead for saving or updating
            //--------------------------------------------------------------
            obj.course_id = Courses_DB.Save(obj);
            course_id.Value =
              tx_coursename.Text = "";

            if (obj.course_id > 0)
            {
                Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('تم الحفظ بنجاح')</script>");
                fill_grid();

            }

        }

        else
        {
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('يجب إختيار البرنامج  ')</script>");

        }



    }

    private void fill_grid()
    {
        DataTable dt = Courses_DB.SelectAll(0,CDataConverter.ConvertToInt(ddl_programs.SelectedValue ));
        gvcourses .DataSource = dt;
        gvcourses .DataBind();

    }

    private void fill_programs()
    {
            DataTable dt1 = Course_Programs_DB.SelectAll();
            ddl_programs .DataSource=dt1;
            ddl_programs .DataBind();
            ddl_programs.Items.Insert(0, new ListItem("..... اختر  البرنامج  ....", "0"));

    }
    protected void gvcourses_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Show")
        {
            Courses_DT obj = Courses_DB.SelectByID (CDataConverter.ConvertToInt(e.CommandArgument),0);
            course_id.Value = obj.course_id.ToString();
            tx_coursename.Text = obj.course_name.ToString();
        


        }
        else if (e.CommandName == "dlt")
        {
            Courses_DB.Delete(CDataConverter.ConvertToInt(e.CommandArgument));
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('تم الحذف بنجاح')</script>");
            fill_grid();
            course_id.Value =
       tx_coursename.Text = "";


        }
    }
    protected void ddl_programs_SelectedIndexChanged(object sender, EventArgs e)
    {
        fill_grid();
    }
}
