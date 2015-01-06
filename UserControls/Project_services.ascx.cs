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
using DBL;


public partial class UserControls_Project_services : System.Web.UI.UserControl
{
    string sql_Connection = Universal.GetConnectionString();

    //Session_CS Session_CS = new Session_CS();

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
           
          
            Filldata();
            //Fill_Controll(CDataConverter.ConvertToInt(Request["id"]));
        }

    }

    private void Filldata()
    {
        proj_services_DT obj = proj_services_DB.SelectByID(CDataConverter.ConvertToInt(Session_CS.Project_id.ToString()));
        txt_citizens.Text = obj.proj_citizen_service;
        txt_gov.Text = obj.proj_gov_service;
      
    }

    public void AddNewRecord()
    {
        proj_services_DT objselect = proj_services_DB.SelectByID(CDataConverter.ConvertToInt(Session_CS.Project_id.ToString()));
        hidden_Id.Value = objselect.id.ToString();
        proj_services_DT obj = new proj_services_DT();
        obj.id = CDataConverter.ConvertToInt(hidden_Id.Value);
        obj.proj_id = CDataConverter.ConvertToInt(Session_CS.Project_id.ToString());
        obj.proj_citizen_service = txt_citizens.Text;
        obj.proj_gov_service = txt_gov.Text;
        obj.id = proj_services_DB.Save(obj);
        hidden_Id.Value = obj.id.ToString();
        if (obj.id > 0)
            ShowAlertMessage("تم الحفظ بنجاح");
        //Filldata();
    }
    public static void ShowAlertMessage(string error)
    {

        Page page = HttpContext.Current.Handler as Page;
        if (page != null)
        {
            error = error.Replace("'", "\'");
            ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('" + error + "');", true);
        }
    }
   

    protected void SaveButton_Click(object sender, EventArgs e)
    {

        AddNewRecord();


    }

  
   

   

    
}

