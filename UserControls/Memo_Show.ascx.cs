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

public partial class UserControls_MemorandumShow : System.Web.UI.UserControl
{
    Session_CS Session_CS = new Session_CS();
    string sql;
    SqlConnection conn;
    SqlDataAdapter da;
    DataSet ds;
    SqlCommand cmd;
    
    private string sql_Connection = Database.ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fill_ddl();
        }
    }
    private void fill_ddl()
    {
      DataTable dt=  Memo_Upload_DB.SelectAll(0,CDataConverter.ConvertToInt(Session_CS.sec_id));
        Drop_arabic_doc.DataSource=dt;
        Drop_arabic_doc.DataValueField="ID"  ;
        Drop_arabic_doc.DataTextField = "File_Title";
        Drop_arabic_doc.DataBind();
        Drop_arabic_doc.Items.Insert(0, new ListItem(".....إختر مذكرة ....", "0"));

    }
    protected void btn_arabic_doc_Click(object sender, EventArgs e)
    {
        if (Drop_arabic_doc.SelectedValue == "0")
        {
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert(' يجب اختيار مذكرة عرض ')</script>");
        }
        else
        {
            string File_Name_Show = "";
            string File_Name = "";

            //DataTable dt = Memo_Upload_DB.SelectAll(0, CDataConverter.ConvertToInt(Session_CS.sec_id));

            DataTable dt_all = General_Helping.GetDataTable("select * from Memo_Upload where id = " + CDataConverter.ConvertToInt(Drop_arabic_doc.SelectedValue));
            if (dt_all.Rows.Count > 0)
            {

                Memo_Upload_DT obj = new Memo_Upload_DT();

               // obj.File_Name = dt.Rows[0]["File_Name"].ToString();
                //obj.File_Name = Drop_arabic_doc.SelectedItem.Text;

                obj.File_Ext = dt_all.Rows[0]["File_Ext"].ToString();
                File_Name_Show = dt_all.Rows[0]["File_Name"].ToString() + "." + obj.File_Ext;
                File_Name = Server.MapPath("~//Uploads/MemorandumShow/" + File_Name_Show + "");

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
