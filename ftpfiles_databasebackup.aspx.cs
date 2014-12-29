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


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // DownloadFile();
            DataTable dt2 = SqlHelper.ExecuteDataset(Database.ConnectionString, "Foundation_Backup_Filename", 2).Tables[0];



            int i;
            for (i = 0; i < dt2.Rows.Count; i++)
            {

                int selected_found_id = CDataConverter.ConvertToInt(dt2.Rows[i]["id"]);

                //string ResponseDescription = "";
                string PureFileName = (dt2.Rows[i]["found_backupfilename"]).ToString(); //new FileInfo(File_Title.ToString()).Name;
                //string PureFileName = File_Title;//new FileInfo(File_Title.ToString()).Name;
                string DownloadedFilePath = Server.MapPath("~/uploads/DBBackup") + "/" + PureFileName;
                string upload_path = System.Configuration.ConfigurationSettings.AppSettings["upload_path"].ToString();
                string downloadUrl = String.Format("{0}/{1}", upload_path, PureFileName);
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
                    int sucess = SqlHelper.ExecuteNonQuery(Database.ConnectionString, "update_Foundation_Backup_Filename", selected_found_id);
                    

                }
                catch (Exception X)
                {
                    throw X;
                }
            }
        }
    }
}
      




