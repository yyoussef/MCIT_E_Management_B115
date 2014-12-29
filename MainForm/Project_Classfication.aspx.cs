using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class WebForms2_Project_Classfication : System.Web.UI.Page
{
    Session_CS Session_CS = new Session_CS();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request["Type_ID"] != null)
                Fil_Grid();
        }
    }

    void Fil_Grid()
    {
        DataTable DT = SqlHelper.ExecuteDataset(Database.ConnectionString, "project_Classification_Select",CDataConverter.ConvertToInt( Session_CS.pmp_id.ToString()),CDataConverter.ConvertToInt( Request["Type_ID"].ToString())).Tables[0];
        if (DT.Rows.Count > 0)
        {
            lblMain.Text = "قائمة المشروعات التابعة " + DT.Rows[0]["proj_Classification"].ToString();
        }
        GridView_proj.DataSource = DT;
        GridView_proj.DataBind();
    }

    

}
