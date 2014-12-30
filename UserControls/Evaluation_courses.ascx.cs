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
using Dates;
using System.Data.SqlClient;

public partial class UserControls_Project_Attitude : System.Web.UI.UserControl
{
    //Session_CS Session_CS = new Session_CS();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillgrid();


        }
    }
    private void fillgrid()
    {
        DataTable dt = Evaluation_Courses_DB.SelectAll();
        gvMain.DataSource = dt;
        gvMain.DataBind();

    }
   

    protected void btn_Save_Click(object sender, EventArgs e)
    {

        Evaluation_Courses_DT obj = new Evaluation_Courses_DT();
        obj.Eval_Course_Id = CDataConverter.ConvertToInt(Course_ID.Value );
        obj.Course_Name = txt_course.Text;
        obj.Course_Description = txt_course_desc.Text;
        obj.Eval_Course_Id = Evaluation_Courses_DB.Save(obj);
        Course_ID.Value =
            txt_course.Text = "";

            if (obj.Eval_Course_Id > 0)
            {
                Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('تم الحفظ بنجاح')</script>");
                fillgrid();
                clear();
            }
        
      
            
           
        
    }

    
    protected void gvMain_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Show")

        {
            Evaluation_Courses_DT obj = Evaluation_Courses_DB.SelectByID(CDataConverter.ConvertToInt(e.CommandArgument ));
            Course_ID.Value = obj.Eval_Course_Id.ToString();
            txt_course.Text = obj.Course_Name.ToString();
            txt_course_desc.Text = obj.Course_Description.ToString();
        
        }
        else if (e.CommandName == "dlt")
        {
            Evaluation_Courses_DB.Delete(CDataConverter.ConvertToInt(e.CommandArgument ));
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('تم الحذف بنجاح')</script>");
           fillgrid();
           clear();

        }
    }
    private void clear()
    {
        Course_ID.Value=
        txt_course_desc.Text = "";
        txt_course.Text = "";
    }
}
