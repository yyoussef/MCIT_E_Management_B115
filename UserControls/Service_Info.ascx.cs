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

public partial class UserControls_Add_inbox_Sub_cat : System.Web.UI.UserControl
{
    //Session_CS Session_CS = new Session_CS();
    public static bool flage = false;
    public static int service_id = 0;
    General_Helping Obj_General_Helping = new General_Helping();
    protected void Page_Load(object sender, EventArgs e)
    {
        //Session_CS.Project_id = 230;

        if (!IsPostBack)
        {
            Fill_Type();
            Get_Service_ID(Convert.ToInt32(ddlServiceType.SelectedValue), Convert.ToInt32(Session_CS.Project_id));
        }
    }
    protected void ddlServiceType_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Fill_Type();
        Get_Service_ID(Convert.ToInt32(ddlServiceType.SelectedValue), Convert.ToInt32(Session_CS.Project_id));
        lblPageStatus.Visible = false;

    }
    private void Fill_Type()
    {
        string sql = "select * from service_types";
        DataTable dt = General_Helping.GetDataTable(sql);
        ddlServiceType.DataSource = dt;
        ddlServiceType.DataValueField = "service_id";
        ddlServiceType.DataTextField = "name";
        ddlServiceType.DataBind();
    }
    public void Get_Service_ID(int service_index, int project_id)
    {
        string sql = "select * from service_info where service_type= " + service_index
            + " and project_id=" + project_id;
        DataTable dt = General_Helping.GetDataTable(sql);
        if (dt.Rows.Count > 0)
        {
            Service_Info_DT obj = Service_Info_DB.SelectByID(Convert.ToInt32(dt.Rows[0]["ID"].ToString()));
            ddlServiceType.SelectedIndex = Convert.ToInt32(obj.Service_Type);
            txtServiceSteps.Text = obj.Service_Steps.ToString();
            txtHotLine.Text = obj.Hot_Line.ToString();
            txtContactUs.Text = obj.Contact_Us.ToString();
            txtProjectLocation.Text = obj.Project_Location.ToString();
            flage = true;
        }
        else
        {
            txtContactUs.Text = "";
            txtHotLine.Text = "";
            txtProjectLocation.Text = "";
            txtServiceSteps.Text = "";
            flage = false;
        }

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        string sql = "select * from service_info where service_type= " + ddlServiceType.SelectedValue
           + " and project_id=" + Session_CS.Project_id;
        DataTable dt = General_Helping.GetDataTable(sql);

        if (dt.Rows.Count > 0)
        {
            Service_Info_DT obj = new Service_Info_DT();
            obj.ID = CDataConverter.ConvertToInt(dt.Rows[0]["ID"].ToString());
            obj.Hot_Line = txtHotLine.Text;
            obj.Project_Id = Convert.ToInt64(Session_CS.Project_id);
            obj.Project_Location = txtProjectLocation.Text;
            obj.Service_Steps = txtServiceSteps.Text;
            obj.Service_Type = Convert.ToInt32(ddlServiceType.SelectedValue);
            obj.Contact_Us = txtContactUs.Text;
            Service_Info_DB.Save(obj);
            lblPageStatus.Text = "تم التعديل بنجاح";

        }

        else
        {
            Service_Info_DT obj = new Service_Info_DT();
            obj.Hot_Line = txtHotLine.Text;
            obj.Project_Id = Convert.ToInt64(Session_CS.Project_id);
            obj.Project_Location = txtProjectLocation.Text;
            obj.Service_Steps = txtServiceSteps.Text;
            obj.Service_Type = Convert.ToInt32(ddlServiceType.SelectedValue);
            obj.Contact_Us = txtContactUs.Text;
            Service_Info_DB.Save(obj);
            lblPageStatus.Visible = true;
            lblPageStatus.Text = "تم الحفظ بنجاح";

        }


        lblPageStatus.Visible = true;
        // lblPageStatus.Text = "اختر التصنيف الرئيسى";

        //Fill_Type();
    }

}
