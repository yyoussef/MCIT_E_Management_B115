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

public partial class MainForm_Default : System.Web.UI.Page
{
    Session_CS Session_CS = new Session_CS();
    protected void Page_Load(object sender, EventArgs e)
    {
      //  Response.AppendHeader("Refresh", "10");


        if (!IsPostBack)
        {
            Session_CS.parent_id = -1;
            Show_Hide_Active_Module();
            Show_Hide_Notification();
            if (CDataConverter.ConvertToInt(Session_CS.UROL_UROL_ID.ToString()) == 2)
            {
                Tr_file_Archive.Visible = true;
            }

        }



    }

    private void Show_Hide_Notification()
    {
        //if (CDataConverter.ConvertToInt(Session_CS.UROL_UROL_ID) != 14)
        //{
        //    Tr4.Visible =
        //        Tr8.Visible
        //        = false;
        //}



        if (Session_CS.UROL_UROL_ID.ToString() == "14")
            Tr8.Visible = true;
        else
            Tr8.Visible = false;

        //if (CDataConverter.ConvertToInt(Session_CS.UROL_UROL_ID) == 2)
        //{
        //    Tr_file_Archive.Visible = true;
        //}
        //else
        //{
        //    Tr_file_Archive.Visible = false;
        //}


    }

    private void Show_Hide_Active_Module()
    {
        DataTable dtmodules = new DataTable();
        dtmodules = Project_class.Allmodulesbyfound(Session_CS.foundation_id);
        string master = "";
        Session_CS.Project_id = 0;
        for (int i = 0; i < dtmodules.Rows.Count; i++)
        {
            string id = dtmodules.Rows[i]["Mod_ID"].ToString();
            string tr = "Tr";
            string completetr = tr + id;
            //int con = tb.Controls.Count;
            //if (true)
            //{

            //}
            if (dtmodules.Rows[i]["Mod_status"].ToString() == "True")
            {


                HtmlTableRow tbr = (HtmlTableRow)tb.FindControl(completetr);
                if (tbr != null)
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
