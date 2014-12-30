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

public partial class MainForm_MainPage : System.Web.UI.Page
{
    //Session_CS Session_CS = new Session_CS();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataTable dtmodules = new DataTable();
            dtmodules = Project_class.Allmodules();
            string master = "";
            for (int i = 0; i < dtmodules.Rows.Count; i++)
            {
                string id = dtmodules.Rows[i]["pk_ID"].ToString();
                string tr = "Tr";
                string completetr = tr+id;
                //int con = tb.Controls.Count;
                //if (true)
                //{
                    
                //}
                if (dtmodules.Rows[i]["Active"].ToString()=="True")
                {
                    
                   
                    HtmlTableRow tbr = (HtmlTableRow)tb.FindControl(completetr);
                    if (tbr!=null)
                    {
                        tbr.Visible = true;    
                    }
                    
                    
                }
                else
                {
                    HtmlTableRow tbr = (HtmlTableRow)tb.FindControl(completetr);
                    if (tbr != null)
                    {
                        tbr.Visible = false;
                    }
                }
            }

        }
          
           

    }
   

 
}
