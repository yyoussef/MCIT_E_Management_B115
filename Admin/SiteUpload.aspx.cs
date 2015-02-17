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
using System.Net;
using System.Net.Mail;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Globalization;
using ReportsClass;
using System.Data.Linq;
using System.Collections.Generic;
using System.Data.Entity.Core;

public partial class WebForms_SiteUpload : System.Web.UI.Page
{
    //Session_CS Session_CS = new Session_CS();
    static string img_src_path = "";

    Projects_ManagementEntities10 pmentity = new Projects_ManagementEntities10();
    Projects_ManagementEntities pmgenentity = new Projects_ManagementEntities();
    OutboxDataContext outboxDBContext = new OutboxDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {

            fill_site_upload();

        }


    }

    private void fill_site_upload()
    {
        int found_id = CDataConverter.ConvertToInt(Session_CS.foundation_id.ToString());
        //  DataTable dt = Site_Upload_DB.SelectAll(found_id);

        DataTable dt = (from site in pmgenentity.Site_Upload where site.foundation_id == found_id select site).ToDataTable();

        if (dt.Rows.Count > 0)
        {
            //read the values from database into the site upload dt object
            Site_Upload_DT obj = new Site_Upload_DT();
            obj.ID = (int)dt.Rows[0]["ID"];
            obj.Site_Name = dt.Rows[0]["Site_Name"].ToString();
            obj.File_Name = dt.Rows[0]["File_Name"].ToString();
            obj.File_Ext = dt.Rows[0]["File_Ext"].ToString();
            obj.logo_file_name = dt.Rows[0]["logo_File_Name"].ToString();
            obj.logo_file_Ext = dt.Rows[0]["logo_File_Ext"].ToString();
            obj.e_signature = dt.Rows[0]["e_signature"].ToString();
            //load the values into the page controls
            this.txtBox_SiteTitle.Text = obj.Site_Name;
            this.prevImg.Visible = true;
            this.prevlogo.Visible = true;
            prevImg.Src = "~/Uploads/SitesPics/" + obj.File_Name + "." + obj.File_Ext;
            prevlogo.Src = "~/Uploads/SitesPics/" + obj.logo_file_name + "." + obj.logo_file_Ext;
            this.lbl_sourceImageName.Visible = true;
            this.lbl_sourcelogoName.Visible = true;

            this.lbl_sourceImageName.Text = obj.File_Name + "." + obj.File_Ext;
            this.lbl_sourcelogoName.Text = obj.logo_file_name + "." + obj.logo_file_Ext;
            this.txtESignature.Text = obj.e_signature;
            this.ImageRecordID_HdnF.Value = obj.ID.ToString();
        }

    }

    public void InsertorUpdate(Site_Upload blog)
    {
        using (var context = new Projects_ManagementEntities())
        {
            context.Entry(blog).State = blog.ID == 0 ?
                System.Data.Entity.EntityState.Added :
                System.Data.Entity.EntityState.Modified;

            context.SaveChanges();
        }

    }



    protected void btnSave_Click(object sender, EventArgs e)
    {
        int found_id = CDataConverter.ConvertToInt(Session_CS.foundation_id.ToString());
        //DataTable dtodj = Site_Upload_DB.SelectAll(found_id);
        DataTable dtodj = (from site in pmgenentity.Site_Upload where site.foundation_id == found_id select site).ToDataTable();

        //  Site_Upload_DT siteUploadObj = new Site_Upload_DT();

        Site_Upload siteUploadObj = new Site_Upload();

        siteUploadObj.foundation_id = CDataConverter.ConvertToInt(Session_CS.foundation_id.ToString());

        if (this.SiteUploadPic.HasFile)
        {
            // save logo as binary to database to use it in Reports
            //-----------------------


            //First:Save the file to the uploads/SitesPics path 
            //-------------------------------------------
            string filename = "";
            string fileExt = "";


            string guid = System.Guid.NewGuid().ToString();

            filename = this.SiteUploadPic.PostedFile.FileName;//Reads The uploaded file name
            filename = filename.Substring(filename.LastIndexOf("\\") + 1);



            //Get the file extension for the loaded picture
            fileExt = filename.Substring((filename.LastIndexOf(".")) + 1);


            string path = Server.MapPath("~\\Uploads\\SitesPics") + "\\";

            string fullpath = path + filename;

            try
            {

                this.SiteUploadPic.PostedFile.SaveAs(fullpath);
            }

            catch (Exception exp)
            {
                string message = exp.Message;
            }


            //Second:Save the details of the picture in the database
            //------------------------------------------------------
            //Create the DT object to load data into it



            siteUploadObj.File_Name = filename.Substring(0, (filename.LastIndexOf(".")));//Get the file name without the extension
            siteUploadObj.File_Ext = fileExt;//File extension

            Session["ImageExt"] = fileExt;
            //set the image source to the new image

            string newPath = "~/Uploads/SitesPics/" + siteUploadObj.File_Name + "." + siteUploadObj.File_Ext;


            this.prevImg.Visible = true;
            prevImg.Src = newPath;


            Image MasterImage = (Image)Master.FindControl("headerImage");
            MasterImage.ImageUrl = newPath;


            //A message to show that saving has been done successfully


            this.lbl_sourceImageName.Visible = true;
            this.lbl_sourceImageName.Text = filename;


        }
        else
        {
            if (dtodj.Rows.Count > 0)
            {
                siteUploadObj.File_Name = dtodj.Rows[0]["File_Name"].ToString();
                siteUploadObj.File_Ext = dtodj.Rows[0]["File_Ext"].ToString();
            }

        }
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

            string logopath = Server.MapPath("~\\Uploads\\SitesPics") + "\\";
            string fulllogopath = logopath + filelogoname;
            try
            {
                this.SiteUploadlogo.PostedFile.SaveAs(fulllogopath);
            }
            catch
            {

            }


            siteUploadObj.logo_file_name = filelogoname.Substring(0, (filelogoname.LastIndexOf(".")));//Get the file name without the extension
            siteUploadObj.logo_file_Ext = filelogoExt;//File extension
            siteUploadObj.logo_image = imagebyt;

            string newlogoPath = "~/Uploads/SitesPics/" + siteUploadObj.logo_file_name + "." + siteUploadObj.logo_file_Ext;

            this.prevlogo.Visible = true;
            prevlogo.Src = newlogoPath;

            this.lbl_sourcelogoName.Visible = true;
            this.lbl_sourcelogoName.Text = filelogoname;
        }
        else
        {
            if (dtodj.Rows.Count > 0)
            {
                siteUploadObj.logo_file_name = dtodj.Rows[0]["logo_file_name"].ToString();
                siteUploadObj.logo_file_Ext = dtodj.Rows[0]["logo_file_Ext"].ToString();
                if (dtodj.Rows[0]["logo_image"].ToString() != DBNull.Value.ToString())
                {
                    siteUploadObj.logo_image = (byte[])(dtodj.Rows[0]["logo_image"]);
                }
            }
        }
        siteUploadObj.ID = CDataConverter.ConvertToInt(ImageRecordID_HdnF.Value);//To enable saving if 0, update otherwise
        siteUploadObj.Site_Name = this.txtBox_SiteTitle.Text;
        siteUploadObj.e_signature = txtESignature.Text;

        // this.ImageRecordID_HdnF.Value = Site_Upload_DB.Save(siteUploadObj).ToString();

        InsertorUpdate(siteUploadObj);

        if (siteUploadObj.ID > 0)
        {
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('تم الحفظ بنجاح')</script>");
        }
        else
        {
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert(' لم يتم الحفظ بنجاح')</script>");
        }
    }

}
