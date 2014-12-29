using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
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
using System.IO;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Smo.Agent;
using System.Data.SqlClient;
using System.Text;
using System.Net;
using System.Windows;
//using System.Windows.Forms;


public partial class fttp : System.Web.UI.Page
{
    protected void Page_Init(object sender, EventArgs e)
    {
       // ListView1.ItemCommand += new EventHandler<ListViewCommandEventArgs>(ListView1_ItemCommand);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
{
        // DownloadFile();
    DataTable dt2 = SqlHelper.ExecuteDataset(Database.ConnectionString, "Foundation_Backup_Filename2", 2).Tables[0];



    ListView1.DataSource = dt2;
    ListView1.DataBind();
        //string[] downloadFiles = GetFileList();

        


        //DataTable dt = new DataTable();
        //dt.Columns.Add("name");

        //for (int i = 0; i < downloadFiles.Length; i++)
        //{
        //    dt.Rows.Add(downloadFiles[i].ToString());
        //}

        //ListView1.DataSource = dt;
        //ListView1.DataBind();
        //int counter = 0;
        //if (dt.Rows.Count > 0)
        //{
        //    foreach (ListViewDataItem item in ListView1.Items)
        //    {

        //        Label File_Title = (Label)item.FindControl("File_Title");
        //        File_Title.Text = dt.Rows[counter]["name"].ToString();



        //        counter++;

        //    }
        //}
        }
        //Response.Redirect("ftp://10.60.201.33");

        //private FtpWebRequest FTPDetail(string FileName)
        //{
        //    string uri = "";
        //    string serverIp = "213.158.188.130"; //Ftp server IP address
        //    string Username = "administrator     "; // Ftp User name
        //    string Password = "P@ssw0rd321"; // Ftp Password
        //    uri = "ftp://" + serverIp + "/root/" + FileName;

        //    FtpWebRequest objFTP;
        //    objFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(uri));
        //    objFTP.Credentials = new NetworkCredential(Username, Password);
        //    objFTP.UsePassive = true;
        //    objFTP.KeepAlive = false;
        //    objFTP.Proxy = null;
        //    objFTP.UseBinary = false;
        //    objFTP.Timeout = 90000;
        //    return objFTP;
        //}



        string CompletePath = "C:/Doc/test.txt"; //path for file
        //public bool UploadFile()
        //{
        //    FtpWebRequest objFTP = null;
        //    try
        //    {
        //        objFTP = FTPDetail("File.txt");
        //        objFTP.Method = WebRequestMethods.Ftp.UploadFile;
        //        using (FileStream fs = File.OpenRead(CompletePath))
        //        {
        //            byte[] buff = new byte[fs.Length];
        //            using (Stream strm = objFTP.GetRequestStream())
        //            {
        //                contentLen = fs.Read(buff, 0, buff.Length);
        //                while (contentLen != 0)
        //                {
        //                    strm.Write(buff, 0, buff.Length);
        //                    contentLen = fs.Read(buff, 0, buff.Length);
        //                }
        //                objFTP = null;
        //            }
        //        }
        //        return true;
        //    }
        //    catch (Exception Ex)
        //    {
        //        if (objFTP != null)
        //        {
        //            objFTP.Abort();
        //        }
        //        throw Ex;
        //    }
        //} 


        string CompleteLocalPath = "C:/Doc/test.txt"; //path for file in my local pc
        //public bool DownloadFile()
        //{
        //    FtpWebRequest objFTP = null;
        //    try
        //    {
        //        objFTP = FTPDetail("File.txt");
        //        objFTP.Method = WebRequestMethods.Ftp.DownloadFile;
        //        using (FtpWebResponse response = (FtpWebResponse)objFTP.GetResponse())//get file from ftp
        //        {
        //            using (Stream ftpStream = response.GetResponseStream())
        //            {
        //                int contentLen;
        //                // save file in buffer

        //                using (FileStream fs = new FileStream(CompleteLocalPath, FileMode.OpenOrCreate))
        //                {

        //                    byte[] buff = new byte[2048];
        //                    contentLen = ftpStream.Read(buff, 0, buff.Length);
        //                    while (contentLen != 0)
        //                    {
        //                        fs.Write(buff, 0, buff.Length);
        //                        contentLen = ftpStream.Read(buff, 0, buff.Length);
        //                    }
        //                    objFTP = null;
        //                }
        //            }
        //        }
        //        return true;
        //    }
        //    catch (Exception Ex)
        //    {
        //        if (objFTP != null)
        //        {
        //            objFTP.Abort();
        //        }
        //        throw Ex;
        //    }
        //}
    }
    //public string[] GetFileList()
    //{
    //    string[] downloadFiles;
    //    StringBuilder result = new StringBuilder();
    //    FtpWebRequest reqFTP;

    //    try
    //    {
    //        reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(
    //                  "ftp://" + "10.60.201.33" + "/"));
    //        reqFTP.UseBinary = true;
    //        //reqFTP.Credentials = new NetworkCredential(ftpUserID, 
    //        //                                           ftpPassword);
    //        reqFTP.Method = WebRequestMethods.Ftp.ListDirectory;
    //        WebResponse response = reqFTP.GetResponse();
    //        StreamReader reader = new StreamReader(response
    //                                        .GetResponseStream());

    //        string line = reader.ReadLine();
    //        while (line != null)
    //        {
    //            result.Append(line);
    //            result.Append("\n");
    //            line = reader.ReadLine();
    //        }
    //        // to remove the trailing '\n'
    //        result.Remove(result.ToString().LastIndexOf('\n'), 1);
    //        reader.Close();
    //        response.Close();
    //        return result.ToString().Split('\n');
    //    }
    //    catch (Exception ex)
    //    {
    //        System.Windows.Forms.MessageBox.Show(ex.Message);
    //        downloadFiles = null;
    //        return downloadFiles;
    //    }
    //}
    //protected void ImgBtnEdit_Click(object sender, ImageClickEventArgs e)
    //{
    //    string file_Name = Convert.ToString(((ImageButton)sender).CommandArgument);
    //    string path = "D://NEW" + "/" + file_Name;
    //    Response.Redirect(path);

    //}
    //public void btnDownloadFile_Click(Object sender, ListViewCommandEventArgs e)
    public void ImgBtnEdit_Click(object sender, ImageClickEventArgs e)
    {
        //ListViewItem itemClicked = e.Item;
        //Label File_Title = (Label)e.Item.FindControl("File_Title");
        string file_Name = Convert.ToString(((ImageButton)sender).CommandArgument);

        /// Download File From FTP Server /// 
    ///Base url of FTP Server
    ///if file is in root then write FileName Only if is in use like "subdir1/subdir2/filename.ext"
    ///Username of FTP Server
    ///Password of FTP Server
    ///Folderpath where you want to Download the File
    /// Status String from Server
    //public static string DownloadFile(string FtpUrl,string FileNameToDownload,
    //                    string userName, string password,string tempDirPath)
    //{
        string ResponseDescription = "";
        string PureFileName = file_Name;//new FileInfo(File_Title.ToString()).Name;
        //string PureFileName = File_Title;//new FileInfo(File_Title.ToString()).Name;
        string DownloadedFilePath = Server.MapPath("~/uploads/DBBackup") + "/" + PureFileName;
        string downloadUrl = String.Format("{0}/{1}", "ftp://" + "10.60.201.33", PureFileName);
        FtpWebRequest req = (FtpWebRequest)FtpWebRequest.Create(downloadUrl);
        req.Method = WebRequestMethods.Ftp.DownloadFile;
        // req.Credentials = new NetworkCredential(userName, password);
        req.UseBinary = true;
        req.Proxy = null;
        try
        {
           // WebResponse response = req.GetResponse();
            FtpWebResponse response = (FtpWebResponse)req.GetResponse();
            Stream stream = response.GetResponseStream();
            byte[] buffer = new byte[2048];
            FileStream fs = new FileStream(DownloadedFilePath, FileMode.Create);
            int ReadCount = stream.Read(buffer, 0, buffer.Length);
            while (ReadCount > 0)
            {
                fs.Write(buffer, 0, ReadCount);
                ReadCount = stream.Read(buffer, 0, buffer.Length);
            }
            //ResponseDescription = response.StatusDescription;
            fs.Close();
            stream.Close();
        }
        catch(Exception X)
        {
           throw X;
        }
       // return ResponseDescription;
    

        //FtpWebRequest reqFTP;

        //StringBuilder result = new StringBuilder();

        //try
        //{
        //    //filePath = <<The full path where the 
        //    //file is to be created. the>>, 
        //    //fileName = <<Name of the file to be createdNeed not 
        //    //name on FTP server. name name()>>
        //    FileStream outputStream = new FileStream("D:NEW" +
        //                            "\\" + "ftpfiledownload", FileMode.Create);

        //    reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(
        //              "ftp://" + "10.60.201.33" + "/" + File_Title));
        //    reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;
        //    reqFTP.UseBinary = true;
        //    // reqFTP.Credentials = new NetworkCredential(ftpUserID,ftpPassword);
        //    FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
        //    Stream ftpStream = response.GetResponseStream();
        //    long cl = response.ContentLength;
        //    int bufferSize = 2048;
        //    int readCount;
        //    byte[] buffer = new byte[bufferSize];

        //    readCount = ftpStream.Read(buffer, 0, bufferSize);
        //    while (readCount > 0)
        //    {
        //        outputStream.Write(buffer, 0, readCount);
        //        readCount = ftpStream.Read(buffer, 0, bufferSize);
        //    }

        //    ftpStream.Close();
        //    outputStream.Close();
        //    response.Close();
        //}
        //catch (Exception ex)
        //{
        //    //MessageBox.Show(ex.Message);
        //    throw ex;

        //}

    }
    //public void btnDownloadFile_Click(Object sender, System.EventHandler e)
    //{


    //    ListViewItem itemClicked = e.Item;
    //    Label File_Title = (Label)e.Item.FindControl("File_Title");
    //    FtpWebRequest reqFTP;

    //    StringBuilder result = new StringBuilder();

    //    try
    //    {
    //        //filePath = <<The full path where the 
    //        //file is to be created. the>>, 
    //        //fileName = <<Name of the file to be createdNeed not 
    //        //name on FTP server. name name()>>
    //        FileStream outputStream = new FileStream("D:NEW" +
    //                                "\\" + "ftpfiledownload", FileMode.Create);

    //        reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(
    //                  "ftp://" + "10.60.201.33" + "/" + File_Title));
    //        reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;
    //        reqFTP.UseBinary = true;
    //        // reqFTP.Credentials = new NetworkCredential(ftpUserID,ftpPassword);
    //        FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
    //        Stream ftpStream = response.GetResponseStream();
    //        long cl = response.ContentLength;
    //        int bufferSize = 2048;
    //        int readCount;
    //        byte[] buffer = new byte[bufferSize];

    //        readCount = ftpStream.Read(buffer, 0, bufferSize);
    //        while (readCount > 0)
    //        {
    //            outputStream.Write(buffer, 0, readCount);
    //            readCount = ftpStream.Read(buffer, 0, bufferSize);
    //        }

    //        ftpStream.Close();
    //        outputStream.Close();
    //        response.Close();
    //    }
    //    catch (Exception ex)
    //    {
    //        //MessageBox.Show(ex.Message);
    //    }



    //}

    

}

