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

public partial class UserControls_Fin_Document_View : System.Web.UI.UserControl
{
    //Session_CS Session_CS = new Session_CS();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request["id"] != null)
            {
                DataTable dt = Fin_Work_Order_DB.Select_by_ID_Datatable(CDataConverter.ConvertToInt(Request["id"].ToString()));
                byte[] bytes = null;
                string strtype = "";
                switch (Request["type"].ToLower())
                {
                    case "1":
                        bytes = (byte[])dt.Rows[0]["Work_Image"];
                        strtype = dt.Rows[0]["Work_Image_Type"].ToString();
                        break;
                    case "2":

                        bytes = (byte[])dt.Rows[0]["Work_File"];
                        strtype = dt.Rows[0]["Work_File_Type"].ToString();
                        break;
                    case "3":

                        bytes = (byte[])dt.Rows[0]["Contract_Image"];
                        strtype = dt.Rows[0]["Contract_Image_Type"].ToString();
                        break;
                    case "4":

                        bytes = (byte[])dt.Rows[0]["Contract_File"];
                        strtype = dt.Rows[0]["Contract_File_Type"].ToString();
                        break;

                }




                Response.ContentType = "application/x-unknown";
                string File_Name = "File" + strtype;
                //File_Name = DT.Rows[0]["File_name"].ToString()+DT.Rows[0]["File_ext"].ToString();
                Response.AddHeader("Content-Disposition", "attachment; filename=" + Server.UrlPathEncode(File_Name));
                Response.BinaryWrite(bytes);
                Response.Flush();
                Response.Close();
            }
        }
    }
}
