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

public partial class UserControls_Archiving_Inbox : System.Web.UI.UserControl
{
    //Session_CS Session_CS = new Session_CS();
    protected void Page_Load(object sender, EventArgs e)
    {
       // if (!IsPostBack)
      //  {
            //        loadgrid();
            //        Show_Hide_Catagerios_inbox();
            GetCounts();
      //  }
    }

    private void GetCounts()
    {
        try
        {
            string sql = "select * from Files inner join  File_Archive_Status on File_Archive_Status.file_id = Files.Files_id and  File_Archive_Status.status = 0";
            DataTable dt_files = General_Helping.GetDataTable(sql);
           
                //lnk_files_count.Text = dt_files.Rows.Count.ToString();
                lnk_files_count.Text = "لديك عدد (" + dt_files.Rows.Count.ToString() + ") ملفات لم يتم الاطلاع عليها";
                if (dt_files.Rows.Count < 1)
                    extentionMethods.DisableLinkButton(lnk_files_count);
            

            sql = "select * from Files inner join  File_Archive_Status on File_Archive_Status.file_id = Files.Files_id and  File_Archive_Status.status = 1";
            dt_files = General_Helping.GetDataTable(sql);
           
                //lnk_archive_count.Text = dt_files.Rows.Count.ToString();
                lnk_archive_count.Text = "لديك عدد (" + dt_files.Rows.Count.ToString() + ") ملفات تم الاطلاع عليها";
                if (dt_files.Rows.Count < 1)
                    extentionMethods.DisableLinkButton(lnk_archive_count);
           
           
        }
        catch (Exception ex)
        { }
    }

    protected void lnk_files_Click(object sender, EventArgs e)
    {
        if (CDataConverter.ConvertToInt(lnk_files_count.Text) > 0)
        {
            //lblMain.Text = "قائمة الملفات التي لم يتم الاطلاع عليها ";
            Response.Redirect("~/MainForm/Files_Grid_Page.aspx?Type=300");


        }
    }
    protected void lnk_archive_Click(object sender, EventArgs e)
    {
        if (CDataConverter.ConvertToInt(lnk_archive_count.Text) > 0)
        {
            //lblMain.Text = "قائمة الملفات التي تم الاطلاع عليها ";
            Response.Redirect("~/MainForm/Files_Grid_Page.aspx?Type=301");

        }
    }
}
