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

public partial class WebForms_Clear_Organization : System.Web.UI.Page
{
    //Session_CS Session_CS = new Session_CS();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btn_Search_Click(object sender, EventArgs e)
    {
        string sql = "SELECT * FROM Organization where New_ID is null";
        if (txt_Name.Text != "")
        {
            sql += " and Org_Desc like " + "'%" + txt_Name.Text.Trim() + "%'";

        }
        chklst_Org.DataSource = General_Helping.GetDataTable(sql);
        chklst_Org.DataBind();
        txt_Count.Text = chklst_Org.Items.Count.ToString();
    }

    protected void btn_Save_Click(object sender, EventArgs e)
    {

        if (!string.IsNullOrEmpty(txt_Name.Text))
        {
            string sql = " insert into Organization (Org_Desc) VALUES ('" + txt_Name.Text + "') select @@identity";
            int ID = General_Helping.ExcuteQuery(sql);

            if (ID > 0)
            {
                int operation;
                operation = (int)Project_Log_DB.Action.add;
                Project_Log_DB.FillLog(ID, operation, Project_Log_DB.operation.Organization);
                Clear_Control();
                //string Org_IDs = "";
                //foreach (ListItem Org_item in chklst_Org.Items)
                //{
                //    if (Org_item.Selected)
                //    {
                //        Org_IDs += CDataConverter.ConvertToInt(Org_item.Value) + ",";
                //    }
                //}
                ////if (Org_IDs.Length > 1)
                ////    Org_IDs = Org_IDs.Remove(Org_IDs.Length - 1, 1);
                //Org_IDs += ID.ToString();

                //string sql_Update = " update  Organization set  New_ID =" + ID + " where Org_ID in ("+Org_IDs+")";
                //General_Helping.ExcuteQuery(sql_Update);
                Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم الإضافة بنجاح')</script>");

                //txt_new_Name.Text =
                //txt_Name.Text = "";
                //btn_Search_Click(sender, e);
            }
        }
    }

    private void Clear_Control()
    {
        chklst_Org.DataSource = new DataTable();
        chklst_Org.DataBind();
        txt_Count.Text = txt_Name.Text = ""; ;
    }
}
