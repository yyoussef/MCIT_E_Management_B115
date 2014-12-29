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

public partial class UserControls_Training_adminapprove : System.Web.UI.UserControl
{
    Session_CS Session_CS = new Session_CS();
    protected void Page_Load(object sender, EventArgs e)
    {


        if (!IsPostBack)
            fillddl();
           
            
    }

    void Fil_Grid(int course_id)
    {
        
        gv_adminapprove.DataSource = course_employee_DB.Select_Admin_Select(course_id); ;
        gv_adminapprove.DataBind();
    }
    protected void gv_adminapprove_RowDataBound(object sender, GridViewRowEventArgs e)
    {


    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //string status = "1";
        //for (int i = 0; i < gv_adminapprove.Rows.Count; i++)
        //{
        //    if (gv_adminapprove.Rows[i].RowType == System.Web.UI.WebControls.DataControlRowType.DataRow)
        //    {
        //        CheckBox ch = (CheckBox)gv_adminapprove.Rows[i].FindControl("CheckBox1");
        //        if (ch.Checked == true)
        //        {
        //            status = "1";
        //        }
        //        else if (ch.Checked == false)
        //        {
        //            status = "2";
        //        }

        //        int id = Convert.ToInt32(gv_adminapprove.Rows[i].Cells[0].Text);
        //        course_employee_DB.updateemployeestatus(id, status);
            //}
          
        }
    
    public void fillddl()
    {

        //DataTable dt_sub_cat = course_DB.SelectAll();
        //ddl_course.DataSource = dt_sub_cat;
        //ddl_course.DataBind();
    }
    protected void ddl_course_SelectedIndexChanged(object sender, EventArgs e)
    {
        int course_id =Convert.ToInt32(ddl_course.SelectedItem.Value);
        Fil_Grid(course_id);
        gv_adminapprove.DataBind();


    }
    protected void gv_adminapprove_DataBound(object sender, EventArgs e)
    {

        for (int i = 0; i < gv_adminapprove.Rows.Count; i++)
        {
            HyperLink hl = (HyperLink)gv_adminapprove.Rows[i].FindControl("HyperLink1");
            TextBox txt_id = (TextBox)gv_adminapprove.Rows[i].FindControl("txt_id");
            string id = txt_id.Text;
            if (gv_adminapprove.Rows[i].RowType == System.Web.UI.WebControls.DataControlRowType.DataRow)
            {
                if (gv_adminapprove.Rows[i].Cells[5].Text == "1")
                {
                    gv_adminapprove.Rows[i].Cells[5].Text = "مقبول";
                    hl.NavigateUrl = "~/MainForm/Training_Descion.aspx?id=" + id ;
                    hl.Text = "تعديل القرار";

                }
                else if (gv_adminapprove.Rows[i].Cells[5].Text == "2")
                {
                    gv_adminapprove.Rows[i].Cells[5].Text = "مرفوض";
                    hl.NavigateUrl = "~/MainForm/Training_Descion.aspx?id=" + id;
                    hl.Text = "تعديل القرار";
                    //gv_adminapprove.Rows[i].Cells[7].Text = "";
                }
                else if (gv_adminapprove.Rows[i].Cells[5].Text == "3")
                {
                    gv_adminapprove.Rows[i].Cells[5].Text = "لم ينظر في امره";
                    hl.NavigateUrl = "~/MainForm/Training_Descion.aspx?id=" + id;
                    hl.Text = "إتخاذ القرار";
                    //gv_adminapprove.Rows[i].Cells[7].Text = "";
                }
                else if (gv_adminapprove.Rows[i].Cells[5].Text == "4")
                {
                    gv_adminapprove.Rows[i].Cells[5].Text = "محول الي برنامج";
                    hl.NavigateUrl = "~/MainForm/Training_Descion.aspx?id=" + id;
                    hl.Text = "تعديل القرار";
                    //gv_adminapprove.Rows[i].Cells[7].Text = "";
                    ////gv_adminapprove.Rows[i].Cells[7].Text = "";
                }
                HyperLink HyperLink2 = (HyperLink)gv_adminapprove.Rows[i].FindControl("HyperLink2");
                if (HyperLink2.Text == "1" || HyperLink2.Text == "2")
                {
                    HyperLink2.Text = "عرض النتيجه";
                    HyperLink2.NavigateUrl = "~/MainForm/Training_userresult.aspx?type=2&id= " + id;
                    hl.Text = "لا يمكن تعديل القرار";
                    hl.Enabled = false;
                    
                }
                else
                {
                    HyperLink2.Text = "لم يدخل النتيجه بعد";
                    HyperLink2.Enabled = false;
                }

            }
        }
    }
}
