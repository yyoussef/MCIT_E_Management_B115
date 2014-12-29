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

public partial class UserControls_Training_ViewUserRegisteredCourses : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void gv_viewuserrequest_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowIndex > -1)
        //{
        //    ((HyperLink)e.Row.Cells[7].Controls[0]).Attributes.Add("OnClick", "return confirm (\"هل انت متاكد من رغبتك في الحذف\");");
        //}
       
    }
    protected void gv_viewuserrequest_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < gv_viewuserrequest.Rows.Count; i++)
        {
            if (gv_viewuserrequest.Rows[i].RowType == System.Web.UI.WebControls.DataControlRowType.DataRow)
            {
                if (gv_viewuserrequest.Rows[i].Cells[4].Text == "3")
                {
                    gv_viewuserrequest.Rows[i].Cells[4].Text = "منتظر الرد";
                  //  gv_viewuserrequest.Rows[i].Cells[7].Text = "";
                    
                    
                }
                else if (gv_viewuserrequest.Rows[i].Cells[4].Text == "1")
                {
                    gv_viewuserrequest.Rows[i].Cells[4].Text = "مقبول";
                  //  gv_viewuserrequest.Rows[i].Cells[5].Text = "لا يمكنك التعديل";
                   // gv_viewuserrequest.Rows[i].Cells[6].Text = "لا يمكنك الحذف";
                   


                }


                else if (gv_viewuserrequest.Rows[i].Cells[4].Text == "2")
                {
                    gv_viewuserrequest.Rows[i].Cells[4].Text = "مرفوض";
                 //   gv_viewuserrequest.Rows[i].Cells[5].Text = "لا يمكنك التعديل";
                  //  gv_viewuserrequest.Rows[i].Cells[6].Text = "لا يمكنك الحذف";
                  //  gv_viewuserrequest.Rows[i].Cells[7].Text = "";

                }
                else
                {
                    gv_viewuserrequest.Rows[i].Cells[4].Text = "  غير محدد الحالة";

                }

                /////////////////////////////////////////////////////////////////result check/////////////////////////

                if (gv_viewuserrequest.Rows[i].Cells[5].Text == "3")
                {
                    gv_viewuserrequest.Rows[i].Cells[5].Text = "معتذر";


                }
                else if (gv_viewuserrequest.Rows[i].Cells[5].Text == "1")
                {
                    gv_viewuserrequest.Rows[i].Cells[5].Text = "ناجح";
              



                }


                else if (gv_viewuserrequest.Rows[i].Cells[5].Text == "2")
                {
                    gv_viewuserrequest.Rows[i].Cells[5].Text = "راسب";


                }
                else
                {
                    gv_viewuserrequest.Rows[i].Cells[5].Text = " لا توجد نتيجة مسجلة";

                }
               

             

       
            }
        }
    }
    protected void gv_viewuserrequest_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //if (e.CommandName == "RemoveItem")
        //{
        //    course_employee_DB.Delete(CDataConverter.ConvertToInt(e.CommandArgument));
        //    Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم الحذف بنجاح')</script>");
        //    gv_viewuserrequest.DataBind();
        //}
        //if (e.CommandName == "EditItem")
        //{
        //    Response.Redirect("~/WebForms/Training_User_Register.aspx?request_id=" + CDataConverter.ConvertToInt(e.CommandArgument));
        //}
    }
}
