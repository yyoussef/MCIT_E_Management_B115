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

public partial class WebForms_Store_Resources : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;
    SqlDataAdapter da;
    SqlDataReader dr;
    DataSet ds;
    string sql;
    DataTable dt;
    Session_CS Session_CS = new Session_CS();
   
    
    
   protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            txtdate.Text = CDataConverter.ConvertDateTimeNowRtrnString();
            GetALL();
            GridViewStore.DataBind();
            
        }
       
       
    }
    public void GetALL()
   {
      
        
        if ( Request.QueryString["delete"] != null && !IsPostBack)
       {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            con.Open();
           string query = "delete from store where ID=" + Request.QueryString["delete"];
          
            cmd = new SqlCommand (query ,con);
            cmd.ExecuteNonQuery();
            con.Close();
           
            GridViewStore.DataBind();
            labcheck.Visible = true;
            labcheck.Text = "لقد تم الحذف";
            //Response.Redirect("Store_Resources.aspx");
       }
       if ( Request.QueryString["edit"] != null && !IsPostBack)
       {
           SaveBtn.Text = "تعديل";
         
        con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        con.Open();
        string query = " select [pc_Brandname_No],[Printer_No],[PC_No],[Server_No],[available_Date] from store where id = " + Request.QueryString["edit"];

        da = new SqlDataAdapter(query, con);
        dt = new DataTable();
        da.Fill(dt);
        if (dt.Rows.Count > 0)
        {
           // DateTime t1 = new DateTime();
            
            //t1 = DateTime.ParseExact(dt.Rows[0]["available_Date"], "dd/MM/yyyy", null);
            //string str;
            //str = dt.Rows[0]["available_Date"].ToString();
            //txtdate.Text = str;
            //t1 = DateTime.ParseExact(txtdate.Text,"MM/dd/yyyy", null);
            txtdate.Text = dt.Rows[0]["available_Date"].ToString();     
            txtpcb.Text = dt.Rows[0]["pc_Brandname_No"].ToString();
            txtprinter.Text = dt.Rows[0]["Printer_No"].ToString();
            txtpc.Text = dt.Rows[0]["PC_No"].ToString();
            txtserver.Text = dt.Rows[0]["Server_No"].ToString();
         }
       
       
       }
         
    }
    public void dimmed()
    {
        txtdate.Enabled = false;
        txtpc.Enabled = false;
        txtpcb.Enabled = false;
        txtprinter.Enabled = false;
        txtserver.Enabled = false;
    }
   public void clear()
   {
       
       txtpc.Text = "";
       txtpcb.Text = "";
       txtprinter.Text = "";
       txtserver.Text = "";
       
   }
    public void save()
   {
       DateTime t1 = CDataConverter.ConvertDateTimeNowRtnDt();
      

       con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
       con.Open();

           if (txtserver.Text == "")
           {
               txtserver.Text = "0";
           }
          
           if (txtpcb.Text == "")
               
               
              txtpcb.Text = "0"; 
           

           if (txtpc.Text == "")
               txtpcb.Text = "0";
               
            if (txtprinter.Text == "")
              
             txtprinter.Text = "0";
               
           if (txtdate.Text != "")
            {
                t1 = DateTime.ParseExact(txtdate.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
               
                            
            }
                else
               t1 = CDataConverter.ConvertDateTimeNowRtnDt();

           string sql = "insert into store (pc_Brandname_No,Printer_No,PC_No,Server_No,available_Date) values(" + txtpcb.Text + "," + txtprinter.Text + "," + txtpc.Text + "," + txtserver.Text + ",convert(nvarchar,'"+t1+"',103))";

            cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
           
            GridViewStore.DataBind();
            con.Close();
           
                   
       
    }

    public void update()
    {
        SaveBtn.Text = "تعديل";
        DateTime t1= new DateTime();
        con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
         string sql = " update store set pc_Brandname_No = @pc_Brandname_No , Printer_No = @Printer_No , PC_No = @PC_No , Server_No = @Server_No , available_Date = @available_Date  where id =" + Request.QueryString["edit"];
               
        cmd = new SqlCommand(sql, con);
        cmd.Parameters.AddWithValue("@pc_Brandname_No",txtpcb.Text);
        cmd.Parameters.AddWithValue("@Printer_No",txtprinter.Text);
        cmd.Parameters.AddWithValue("@PC_No ",txtpc.Text);
        cmd.Parameters.AddWithValue("@Server_No",txtserver.Text);

        if (txtdate.Text != "")
        {
            //t1 = DateTime.ParseExact(txtdate.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            
            cmd.Parameters.AddWithValue("@available_Date", txtdate.Text );
        }
               
        try
        {
            con.Open();
            cmd.ExecuteNonQuery();
           
        }
        catch { }
        finally
        {
            con.Close();
        }
        GridViewStore.DataBind();
        
       
    }

      protected void SaveBtn_Click(object sender, EventArgs e)
    {
        if (txtpcb.Text == "" & txtpc.Text == "" & txtprinter.Text == "" & txtserver.Text == "" & txtdate.Text == "")
        {
            txtdate.Text = CDataConverter.ConvertDateTimeNowRtrnString();
            labcheck.Visible = true;
            labcheck.Text = "لا توجد بيانات للإدخال";
        }
        
        else if (Request.QueryString["edit"] != null)
        {

           SaveBtn.Text = "تعديل";
           update();
           labcheck.Visible = true;
           labcheck.Text = "تم التعديل بنجاح";
           AnotherSaveBtn.Visible = true;
           dimmed();
                 
        }
        else
        {
            save();
            labcheck.Visible = true;
            labcheck.Text = "تم الادخال بنجاح";
            dimmed();
           
        }
        
        
    }


      protected void AnotherSaveBtn_Click(object sender, EventArgs e)
      {
          Response.Redirect("Store_Resources.aspx");
          SaveBtn.Visible = false;
          
      }
}
       
     
  




  