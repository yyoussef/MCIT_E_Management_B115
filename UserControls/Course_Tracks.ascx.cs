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
    //Session_CS Session_CS = new Session_CS();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
         //   fill_ddl_course();
            fill_programs();
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (ddl_course.SelectedValue != "0" && ddl_programs.SelectedValue !="0")
        {
            Course_Tracks_DT obj = new Course_Tracks_DT();
            obj.track_name = txt_tracks.Text.Trim();
            obj.id = CDataConverter.ConvertToInt(track_id.Value);
            obj.course_id = CDataConverter.ConvertToInt(ddl_course.SelectedValue);

            //--------------------------------------------------------------
            //Check first if a course track with that name exists before saving
            string sqlComm = "SELECT * FROM Course_Tracks WHERE track_name='" + obj.track_name + "' AND course_id=" + obj.course_id;
            SqlDataReader reader = SqlHelper.ExecuteReader(Database.ConnectionString, CommandType.Text, sqlComm);
            if (reader.HasRows)//This track name for that course does exist before
            {
                Page.RegisterStartupScript("Error", "<script language=javascript>alert('اسم المسار لهذه الدورة التدريبية يوجد من قبل، الرجاء اختيار اسم اخر')</script>");
                return;//Will not continue to save to prevent repeated names

            }
            //Else will go ahead for saving or updating
            //--------------------------------------------------------------

            obj.id = Course_Tracks_DB.Save(obj);
            track_id.Value =
            txt_tracks.Text = "";
            if (obj.id > 0)
            {
                Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('تم الحفظ بنجاح')</script>");
                fill_grid();

            }
        }
        else
        {
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('  يجب إختيار إسم البرنامج والدورة التدريبية')</script>");

        }



    }

    private void fill_grid()
    {
        DataTable dt = Course_Tracks_DB.SelectAll(0,CDataConverter.ConvertToInt(ddl_course.SelectedValue ));
        gv_tracks .DataSource = dt;
        gv_tracks .DataBind();

    }
    private void fill_ddl_course()
    {
        DataTable dt1 = Courses_DB.SelectAll(0, CDataConverter.ConvertToInt(ddl_programs.SelectedValue ));
        ddl_course.DataSource = dt1;
        ddl_course.DataBind();
        ddl_course.DataTextField = "course_name";
        ddl_course.DataValueField = "course_id";
        ddl_course.Items.Insert(0, new ListItem("..... اختر  الدورة التريبية ....", "0"));

    }

    private void fill_programs()
    {
        DataTable dt1 = Course_Programs_DB.SelectAll();
        ddl_programs.DataSource = dt1;
        ddl_programs.DataBind();
        ddl_programs.Items.Insert(0, new ListItem("..... اختر  البرنامج  ....", "0"));

    }

    protected void gv_tracks_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Show")
        {
            Course_Tracks_DT   obj = Course_Tracks_DB.SelectByID(CDataConverter.ConvertToInt(e.CommandArgument),0);
            track_id.Value = obj.id.ToString();
            txt_tracks.Text = obj.track_name .ToString();
            ddl_course.SelectedValue = obj.course_id.ToString();
          


        }
        else if (e.CommandName == "dlt")
        {
            Course_Tracks_DB.Delete(CDataConverter.ConvertToInt(e.CommandArgument));
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('تم الحذف بنجاح')</script>");
            fill_grid();

            track_id.Value =
            txt_tracks.Text = "";
          

        }
    }
    protected void ddl_course_SelectedIndexChanged(object sender, EventArgs e)
    {
        fill_grid();

    }
    protected void ddl_programs_SelectedIndexChanged(object sender, EventArgs e)
    {
        fill_ddl_course();

    }
}
