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

public partial class WebForms_Project_presentation_search : System.Web.UI.Page
{
    //Session_CS Session_CS = new Session_CS();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void SearchRecord()
    {
        string strMaxDT = "";
        string strMinDT = "";

        strMaxDT = Presentation_date_to.Text;
        strMinDT = Presentation_date_from.Text;

        SqlDataAdapter sqladptr = new SqlDataAdapter();
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        SqlCommand obj = new SqlCommand("Get_Presentation_Search", con);
        obj.CommandType = CommandType.StoredProcedure;
        obj.Parameters.Add(new SqlParameter("@ProjID", Session_CS.Project_id.ToString()));
        obj.Parameters.Add(new SqlParameter("@Dept_ID", Session_CS.dept_id.ToString()));

        obj.Parameters.Add(new SqlParameter("@Presentation_name", "%" + Presentation_name.Text + "%"));
        obj.Parameters.Add(new SqlParameter("@Presentation_location", "%" + Presentation_location.Text + "%"));
        obj.Parameters.Add(new SqlParameter("@Presentation_date_from", strMinDT));
        obj.Parameters.Add(new SqlParameter("@Presentation_date_to", strMaxDT));

        con.Open();
        sqladptr.SelectCommand = obj;
        DataTable DT = new DataTable();
        sqladptr.Fill(DT);
        gvMain.DataSource = DT;
        gvMain.DataBind();

        con.Close();
    }

    protected void SaveButton_Click(object sender, EventArgs e)
    {
        SearchRecord();
    }

    private void FillGrid()
    {
        if (Session_CS.Project_id != null)
        {
            SqlDataAdapter sqladptr = new SqlDataAdapter();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            SqlCommand obj = new SqlCommand("Get_All_Presentation", con);
            obj.CommandType = CommandType.StoredProcedure;
            obj.Parameters.Add(new SqlParameter("@ProjID", Session_CS.Project_id.ToString()));
            con.Open();
            sqladptr.SelectCommand = obj;
            DataTable DT = new DataTable();
            sqladptr.Fill(DT);
            gvMain.DataSource = DT;
            gvMain.DataBind();
        }
    }
}
