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
using System.Data.SqlClient;
public partial class suber_admin_Default : System.Web.UI.Page
{
    static int currentid;
    protected void Page_Load(object sender, EventArgs e)
    {
        //SqlConnection con = new SqlConnection();
        //con.ConnectionString = "Data Source=10.60.201.106;Initial Catalog=Projects_Management;Persist Security Info=True;User ID=pms;Password=pms";
        //con.Open();
        if (!IsPostBack)
        {
            FillGrid();
            
        }

   
    }
    protected void FillGrid()
    {
    //    SqlConnection con = new SqlConnection();
    //    con.ConnectionString = "Data Source=10.60.201.106;Initial Catalog=Projects_Management;Persist Security Info=True;User ID=pms;Password=pms";
    //    con.Open();
       
    //        SqlCommand uu = new SqlCommand("selectall", con);
    //        uu.CommandType = CommandType.StoredProcedure;
    //        SqlDataAdapter di = new SqlDataAdapter("selectall", con);
    //        DataSet dw = new DataSet();
    //        di.Fill(dw, " Admin_Module");
    //        GridView1.DataSource = dw;
    //        GridView1.DataBind();
    //        con.Close();
         DataTable dat = new DataTable();
         dat = Admin_page_DB.SelectAll();
          GridView1.DataSource = dat;
          GridView1.DataBind();

        
    }

    protected void GridView1_RowCommand(Object sender, GridViewCommandEventArgs e) 
    {
        if (e.CommandName == "Delette")

        {

            Admin_page_DB.Delete(Int32.Parse(e.CommandArgument.ToString()));
//            DataTable da = new DataTable();
  //          da = Admin_page_DB.SelectAll();
            FillGrid();
           
            
        }
        if (e.CommandName=="Updates")
         {

             Admin_page_DT adminob = new Admin_page_DT() ;

         
            adminob =  Admin_page_DB.SelectByID(Int32.Parse(e.CommandArgument.ToString()));
           txt1.Text = adminob.Name;
           txt2.Text = adminob.PageFile;
           chkb1.Checked = adminob.Active;
           HiddenField1.Value = adminob.pk_ID.ToString();
           
          



        }
    }
    protected void save_Click(object sender, EventArgs e)
    {
        //SqlConnection co = new SqlConnection();
        //co.ConnectionString = "Data Source=10.60.201.106;Initial Catalog=Projects_Management;Persist Security Info=True;User ID=pms;Password=pms";
        //co.Open();
        Admin_page_DT admino = new  Admin_page_DT() ;
        admino.Name = txt1.Text;
        admino.Active = chkb1.Checked;
        admino.PageFile=txt2.Text;
        admino.pk_ID = Convert.ToInt32(HiddenField1.Value);
        int id = Admin_page_DB.Save(admino);
        HiddenField1.Value ="0";
        txt1.Text = "";
        txt2.Text = "";
        chkb1.Checked = false;
        //DataTable dat = new DataTable();
        //dat=Admin_page_DB.SelectAll();
        FillGrid();
       

    }



    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        //SqlConnection oo = new SqlConnection();
        //oo.ConnectionString = "Data Source=10.60.201.106;Initial Catalog=Projects_Management;Persist Security Info=True;User ID=pms;Password=pms";
        //oo.Open();

        //SqlCommand up = new SqlCommand("selectall", oo);
        //up.CommandType = CommandType.StoredProcedure;
        //SqlDataAdapter de = new SqlDataAdapter("selectall", oo);
        //DataSet dat = new DataSet();
        //de.Fill(dat, " Admin_Module");
        ////FillGrid();
        //GridView1.DataSource = dat;
        //GridView1.PageIndex = e.NewPageIndex;
        ////FillGrid();
        //GridView1.DataBind();
        //oo.Close();


          GridView1.PageIndex = e.NewPageIndex;
        FillGrid();

    
    }
}
