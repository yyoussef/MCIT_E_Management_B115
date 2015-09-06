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

public partial class UserControls_TrainingCounter : System.Web.UI.UserControl
{
    //Session_CS Session_CS = new Session_CS();
    protected void Page_Load(object sender, EventArgs e)
    {
      //  if (Session_CS.is_vacation_mng.ToString() == "1")
       // {
            tr_lnk_Tran_Request.Visible = true;
       // }
        DataTable DT_train_New = course_DB.SelectAll_Cource_Not_Registered(CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()));
        if (DT_train_New != null )
        {
            //tr_Train_New.Visible = true;
           // lnk_Tran_New.Text = DT_train_New.Rows.Count.ToString();
            lnk_Tran_New.Text = "لديك عدد (" + DT_train_New.Rows.Count.ToString() + ") تدريب جديد";
            if (DT_train_New.Rows.Count < 1)
                extentionMethods.DisableLinkButton(lnk_Tran_New);
           // lblTraining.ForeColor = System.Drawing.Color.Red;
        }
        DataTable DT_Course_emp = course_DB.Select_Courses_Emlployee_Manager(CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()), "3");
        if (DT_Course_emp != null)
        {
            //lnk_Tran_Request.Text = DT_Course_emp.Rows.Count.ToString();
            lnk_Tran_Request.Text = "لديك عدد (" + DT_Course_emp.Rows.Count.ToString() + ") طلب تدريب";
            if (DT_Course_emp.Rows.Count < 1)
                extentionMethods.DisableLinkButton(lnk_Tran_Request);
            
        }

        DataTable dt_train_plan=Training_Plan_DB.Training_Plan_mangerselect(CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()));
        if (dt_train_plan != null )
        {
            //lnk_trainplan.Text = dt_train_plan.Rows.Count.ToString();
            lnk_trainplan.Text = "لديك عدد (" + dt_train_plan.Rows.Count.ToString() + ") خطط تدريبية";
            if (dt_train_plan.Rows.Count < 1)
                extentionMethods.DisableLinkButton(lnk_trainplan);
        }

        if (Session_CS.sec_id.ToString() != "1")
        {
            tr_lnk_Tran_Request.Visible = false;
            tr_Train_New.Visible = false;
        }
    }

    protected void lnk_Tran_Request_Click(object sender, EventArgs e)
    {
        if (CDataConverter.ConvertToInt(lnk_Tran_Request.Text) > 0)
        {
            Response.Redirect("..\\MainForm\\Training_view_userrequest.aspx");
        }
    }
    protected void lnk_Tran_New_Click(object sender, EventArgs e)
    {
        if (CDataConverter.ConvertToInt(lnk_Tran_New.Text) > 0)
        {
            Response.Redirect("..\\MainForm\\Training_User_Viewallcourse.aspx");
        }
    }


    protected void lnk_Trainplan_New_Click(object sender, EventArgs e)
    {
        if (CDataConverter.ConvertToInt(lnk_trainplan.Text) > 0)
        {
            Response.Redirect("..\\MainForm\\Training_Plan.aspx?mode=manager");
        }
    }

}
