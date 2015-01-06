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

public partial class UserControls_Taining_UserUpdateCourseRequest : System.Web.UI.UserControl
{
    //Session_CS Session_CS = new Session_CS();
    int radiobuttonselectedvalu=0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            fillcontrols();
            fill_RadioButtonList();
        }
    }
    public void fill_RadioButtonList()
    {
        int request_id = Convert.ToInt32(Request["id"]);
        course_employee_DT cedt = new course_employee_DT();
        cedt = course_employee_DB.SelectByID(request_id);
        int course_id = Convert.ToInt32(Request["courseid"]);
        DataTable dt_sub_cat = General_Helping.GetDataTable(" select * from course WHERE course_id=" + cedt.course_id);
        rb_coursedates.DataSource = dt_sub_cat;
        

        rb_coursedates.DataBind();
        
        
        
       // course_details_DT cddt = new course_details_DT();
       //cddt=  course_details_DB.SelectByID(cedt.course_details_id);
       //rb_coursedates.SelectedValue = cddt.id.ToString();
    }
    public void fillcontrols()
    {
        int requestid = Convert.ToInt32(Request["id"]);
        course_employee_DT cedt = new course_employee_DT();
        cedt=course_employee_DB.SelectByID(requestid);
      
        course_DT cDT = course_DB.SelectByID(0,cedt.course_id);
        Courses_DT co_dt = Courses_DB.SelectByID(cedt.course_id, 0);

        tx_coursename.Text = co_dt.course_name;
        tx_organization.Text = cDT.organization;
      //  tx_courseplace.Text = cDT.course_place;
        tx_lastgenertiondate.Text = cDT.last_register_date;
        tx_noofemployee.Text = cDT.emp_no.ToString();

        




    }
  
    protected void Button1_Click(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(Request["id"]);

        int course_details_id = Convert.ToInt32(rb_coursedates.SelectedValue.ToString());

        course_employee_DB.updateemployeecoursedetails(id,Convert.ToInt32(rb_coursedates.SelectedValue.ToString()));
        
    }
    protected void rb_coursedates_SelectedIndexChanged(object sender, EventArgs e)
    {
        radiobuttonselectedvalu =Convert.ToInt32( rb_coursedates.SelectedValue.ToString());
    }
}
