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

using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;

public partial class UserControls_Open_UserManual : System.Web.UI.UserControl
{
    string sql;
    SqlConnection conn;
    SqlDataAdapter da;
    DataSet ds;
    SqlCommand cmd;
    private string sql_Connection = Database.ConnectionString;
    //Session_CS Session_CS = new Session_CS();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //int pmp = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
            string File_Name_Show = "";
            string File_Name = "";

            if (CDataConverter.ConvertToInt(Session_CS.parent_id.ToString())>0)
            {
                File_Name = Server.MapPath("~//Uploads/UserManual/user_manual_manger.pdf");
                File_Name_Show = "دلـــيل المستخدم للمدير.pdf";
            }
            else if (CDataConverter.ConvertToInt(Session_CS.child_emp.ToString()) > 0)
            {
                File_Name = Server.MapPath("~//Uploads/UserManual/user_manual_sec.pdf");
                File_Name_Show = "دليل المستخدم للسكرتير.pdf";
            }
            else
            {

                File_Name = Server.MapPath("~//Uploads/UserManual/user_manual_employee.pdf");
                File_Name_Show = "دليل المستخدم للموظفين.pdf";
            }
            
            FileStream fs = new FileStream(File_Name, FileMode.Open, FileAccess.Read);
            byte[] bytes = new byte[fs.Length];
            fs.Read(bytes, 0, System.Convert.ToInt32(fs.Length));
            fs.Close();
            Response.ContentType = "application/x-unknown";
            Response.AddHeader("Content-Disposition", "attachment; filename=" + Server.UrlPathEncode(File_Name_Show));
            Response.BinaryWrite(bytes);
            Response.Flush();
            Response.Close();
        }
    }

    
}
