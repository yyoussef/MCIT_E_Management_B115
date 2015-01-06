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
using System.Text;
using System.Data.SqlClient;
using System.IO;

public partial class UserControls_Memo_Upload : System.Web.UI.UserControl
{


    string sql;
    SqlConnection conn;
    SqlDataAdapter da;
    DataSet ds;
    SqlCommand cmd;
    private string sql_Connection = Database.ConnectionString; //Session_CS Session_CS = new Session_CS();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fill_grid();
        }

    }


    //protected override void OnInit(EventArgs e)
    //{
    //    #region BROWSER FOR departments



    //    //fil_emp();


    //    //this.Smrt_Srch_DropDep.Value_Handler += new Smart_Search.Delegate_Selected_Value(MOnMember_Data);
    //    //Inbox_organization.SelectedValue;
    //    // fill project



    //    smart_Search_sector.sql_Connection = sql_Connection;
    //    smart_Search_sector.Query = "SELECT Sec_id, Sec_name FROM Sectors where foundation_id='" + Session_CS.foundation_id + "'";
    //    smart_Search_sector.Value_Field = "Sec_id";
    //    smart_Search_sector.Text_Field = "Sec_name";
    //    smart_Search_sector.DataBind();
    //   // this.smart_Search_sector.Value_Handler += new Smart_Search.Delegate_Selected_Value(MOnMember_Data);
       

    //    #endregion
    //    base.OnInit(e);
    //}


    protected void btnSave_Click(object sender, EventArgs e)
    {
        DataTable dtodj = Memo_Upload_DB.SelectAll(0, CDataConverter.ConvertToInt(Session_CS.sec_id));

        Memo_Upload_DT siteUploadObj = new  Memo_Upload_DT();

        if (SiteUploadlogo.HasFile)
        {
            Byte[] imagebyt = null;
            HttpPostedFile File = SiteUploadlogo.PostedFile;
            imagebyt = new Byte[File.ContentLength];
            File.InputStream.Read(imagebyt, 0, File.ContentLength);

            string filelogoname = "";
            string filelogoExt = "";

            filelogoname = this.SiteUploadlogo.PostedFile.FileName;//Reads The uploaded logo file name
            filelogoname = filelogoname.Substring(filelogoname.LastIndexOf("\\") + 1);

            filelogoExt = filelogoname.Substring((filelogoname.LastIndexOf(".")) + 1);

            string logopath = Server.MapPath("~\\Uploads\\MemorandumShow") + "\\";
            string fulllogopath = logopath + filelogoname;

            this.SiteUploadlogo.PostedFile.SaveAs(fulllogopath);

            siteUploadObj.File_Name = filelogoname.Substring(0, (filelogoname.LastIndexOf(".")));//Get the file name without the extension
            siteUploadObj.File_Ext = filelogoExt;//File extension
            siteUploadObj.File_Title = txt_name.Text;
            siteUploadObj.sector_id = CDataConverter.ConvertToInt( Session_CS.sec_id);
    

            string newlogoPath = "~/Uploads/SitesPics/" + siteUploadObj.File_Name + "." + siteUploadObj.File_Ext;

            ////////////////////////////////////////////////////////////////////////////////////////////////////////

          
            Memo_Upload_DB.Save(siteUploadObj);

            if (siteUploadObj.ID > 0)
            {
                Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('تم الحفظ بنجاح')</script>");
                txt_name.Text = "";
            }

            fill_grid();
        
        }


        else
        {

            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('يجب إختيار ملف للتحميل')</script>");

        }


       
    }


    private void fill_grid()
    {

        DataTable dt = Memo_Upload_DB.SelectAll(0, CDataConverter.ConvertToInt(Session_CS.sec_id));
        gvMain.DataSource = dt;
        gvMain.DataBind();
    }



    protected void gvMain_RowCommand(object sender, GridViewCommandEventArgs e)
    {
       
         if (e.CommandName == "dlt")
        {
           Memo_Upload_DB.Delete(CDataConverter.ConvertToInt(e.CommandArgument));
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('تم الحذف بنجاح')</script>");
            fill_grid();

        }
    }



}
