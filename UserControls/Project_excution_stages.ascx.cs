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
using Dates;
using System.Data.SqlClient;

public partial class UserControls_Project_Attitude : System.Web.UI.UserControl
{
    Session_CS Session_CS = new Session_CS();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillgrid();


        }
    }
    private void fillgrid()
    {
        DataTable DT = project_excution_stages_DB.SelectAll (CDataConverter.ConvertToInt(Session_CS.Project_id));
        gvMain.DataSource = DT;
        gvMain.DataBind();

    }
   

    protected void btn_Save_Click(object sender, EventArgs e)
    {

            project_excution_stages_DT  obj=new project_excution_stages_DT ();
            obj.proj_id  = CDataConverter.ConvertToInt(Session_CS.Project_id.ToString());
            obj.proj_stage  = txt_stage.Text;
            obj.proj_stage_output  = txt_output .Text;
            obj.id = CDataConverter.ConvertToInt(stg_id.Value);
            obj.id = project_excution_stages_DB.Save(obj);
            stg_id.Value =
           txt_output .Text = "";
            txt_stage .Text = "";
            if (obj.id > 0)
            {
                Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('تم الحفظ بنجاح')</script>");
                fillgrid();

            }
        
      
            
           
        
    }

    
    protected void gvMain_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Show")
        {
            project_excution_stages_DT  obj = project_excution_stages_DB.SelectByID (CDataConverter.ConvertToInt(e.CommandArgument));
            stg_id .Value = obj.id.ToString();
           txt_stage .Text = obj.proj_stage.ToString();
            txt_output.Text = obj.proj_stage_output.ToString();


        }
        else if (e.CommandName == "dlt")
        {
            project_excution_stages_DB.Delete(CDataConverter.ConvertToInt(e.CommandArgument));
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('تم الحذف بنجاح')</script>");
            fillgrid();

        }
    }
}
