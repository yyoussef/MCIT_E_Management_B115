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

public partial class WebForms2_General_Search : System.Web.UI.Page
{
    //Session_CS Session_CS = new Session_CS();
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
   
    public void SearchRecord()
    {


        string sql = "	SELECT [File_ID],[File_Type],[File_name],[File_ext],[File_ext] as File_Type_Resolved FROM";

        sql += " [dbo].[Departments_Documents]";

        sql += " WHERE (File_Sytem_Name not like '' or File_data is not null ) and ";
        sql += " [proj_proj_id] =" + CDataConverter.ConvertToInt(Session_CS.Project_id.ToString()) ;
       // sql += " and [Dept_ID] =" + CDataConverter.ConvertToInt(Session_CS.dept_id.ToString());
       if (ddl_File_Type.SelectedValue != "0")
        sql += " and [File_Type] = " + CDataConverter.ConvertToInt(ddl_File_Type.SelectedValue);
       if (txt_file_name.Text != "")
           sql += " and [File_name] like '%" + txt_file_name.Text + "%'  ";
       if (txt_file_discribtion.Text != "")
           sql += " and [File_Desc] like '%" + txt_file_discribtion.Text + "%'";
        DataTable DT = new DataTable();
        
        DT=General_Helping.GetDataTable(sql);

        foreach (DataRow dr in DT.Rows)
        {
            if (dr["File_Type"].ToString() == "1")
                dr["File_Type_Resolved"] = "Word";
            else if (dr["File_Type"].ToString() == "2")
                dr["File_Type_Resolved"] = "Excel";
            else if (dr["File_Type"].ToString() == "3")
                dr["File_Type_Resolved"] = "PDF";
            else if (dr["File_Type"].ToString() == "4")
                dr["File_Type_Resolved"] = "Image";
            else if (dr["File_Type"].ToString() == "5")
                dr["File_Type_Resolved"] = "Power Point";
            else if (dr["File_Type"].ToString() == "6")
                dr["File_Type_Resolved"] = "Microsoft Project";
            else if (dr["File_Type"].ToString() == "7")
                dr["File_Type_Resolved"] = "Video";

        }
        if (DT.Rows.Count > 0)
        {
            int rowsaffected = DT.Rows.Count;
            TrRows.Visible = true;
            lblrows.Text = rowsaffected.ToString();
        }
        gvMain.DataSource = DT;
        gvMain.DataBind();

      
    }
    protected void SearchButton_Click(object sender, EventArgs e)
    {
        SearchRecord();
    }

    protected void gvMain_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvMain.PageIndex = e.NewPageIndex;
        SearchRecord();
    }
    protected void gvMain_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
