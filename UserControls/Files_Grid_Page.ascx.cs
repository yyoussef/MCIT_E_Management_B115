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

public partial class UserControls_Files_Grid_Page : System.Web.UI.UserControl
{
    Session_CS Session_CS = new Session_CS();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session_CS.pmp_id != null && CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()) > 0)
            {
                Session_CS.Project_id = 0;
                Load_Grid_Dr_Hesham();

            }
            else
            {
                Response.Redirect("~\\Grids_Dr_Hesham.aspx");
            }
        }
    }
    private void Load_Grid_Dr_Hesham()
    {
        string sql;
        DataTable dt_fliles;
        if (Request["Type"].ToString() == "300")
        {
            sql = "select Files.* from Files inner join  File_Archive_Status on File_Archive_Status.file_id = Files.Files_id and  File_Archive_Status.status = 0";
            dt_fliles = General_Helping.GetDataTable(sql);

            grd_files.DataSource = dt_fliles;
            grd_files.DataBind();
            lblMain.Text = "  قائمة  الملفات التي لم يتم الاطلاع عليها ";
            btn_close_inbox.Visible = false;


        }
        else
            if (Request["Type"].ToString() == "301")
            {
                sql = "select Files.* from Files inner join  File_Archive_Status on File_Archive_Status.file_id = Files.Files_id and  File_Archive_Status.status = 1";
                dt_fliles = General_Helping.GetDataTable(sql);

                grd_files.DataSource = dt_fliles;
                grd_files.DataBind();
                lblMain.Text = "  قائمة  الملفات التي  تم الاطلاع عليها ";
                btn_close_inbox.Visible = false;

            }

    }

    protected void btn_close_inbox_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow grdrow in grd_files.Rows)
        {
            CheckBox chk = (CheckBox)grdrow.FindControl("chk1");
            if (chk.Checked)
            {
                string hidden_Id = ((Label)grdrow.FindControl("lbl_inbox_id")).Text;
                ///////////// change status = 3  /////////////////////////////////////////////
                DataTable DT = new DataTable();
                DT = General_Helping.GetDataTable("select * from Inbox_Track_Manager where inbox_id = " + hidden_Id);
                if (DT.Rows.Count > 0)
                {
                    string sql = "update Inbox_Track_Manager set Have_Follow=0,All_visa_sent=0,Have_Visa=0,status=3 where inbox_id =" + hidden_Id;
                    General_Helping.ExcuteQuery(sql);
                }
                DataTable dt_Inbox_Visa = General_Helping.GetDataTable("select * from Inbox_Track_Emp where inbox_id =" + hidden_Id);
                foreach (DataRow item in dt_Inbox_Visa.Rows)
                {
                    Inbox_DB.update_inbox_Track_Emp(hidden_Id, item["Emp_ID"].ToString(), 3, 1);
                }

                Inbox_Visa_Follows_DT obj = new Inbox_Visa_Follows_DT();// Inbox_Visa_Follows_DB.SelectByID(CDataConverter.ConvertToInt(hidden_Follow_ID.Value));
                obj.Inbox_ID = CDataConverter.ConvertToInt(hidden_Id);
                obj.Descrption = "تم إغلاق الموضوع";
              //  string date = DateTime.Now.ToShortDateString().ToString();

                string date = CDataConverter.ConvertDateTimeNowRtnDt().ToShortDateString();
                obj.Date = date;
                //obj.time_follow = DateTime.UtcNow.ToLocalTime().ToLongTimeString();

                obj.time_follow = CDataConverter.ConvertDateTimeNowRtnDt().ToLongTimeString();

                obj.entery_pmp_id = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
                obj.Visa_Emp_id = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
                obj.Follow_ID = Inbox_Visa_Follows_DB.Save(obj);
                ///////////////////////////////////////////////////////////////// when dr hesham close inbox update all have follow in inbox follow emp to be zero
                General_Helping.ExcuteQuery("update inbox_follow_emp set Have_follow = 0 where inbox_id = " + hidden_Id);
                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                //Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('تم إغلاق الموضوع بنجاح' )</script>");
                Load_Grid_Dr_Hesham();

            }

        }

    }
    protected void ImgBtnBack_Click(object sender, System.Web.UI.ImageClickEventArgs e)
    {
        Response.Redirect("~/MainForm/Default.aspx");
    }
    protected void grd_files_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "fle_show")
        {
            General_Helping.ExcuteQuery("update update File_Archive_Status set status = 1 where file_id='" + e.CommandArgument + "'  ");
        }
    }
    protected void grd_files_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grd_files.PageIndex = e.NewPageIndex;
        Load_Grid_Dr_Hesham();
    }
}
