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
using System.IO;
public partial class UserControls_Foundations_Followup : System.Web.UI.UserControl
{
    Session_CS Session_CS = new Session_CS();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string urlPath = Request.Url.AbsolutePath.Trim();
     
            if (urlPath.Contains("SuperAdmin"))
            {
                ddl_Foundation.Visible = true;
                Label1.Visible = true;
                btn_print.Visible = true ;
                fill_foundations();
                fillgrid();
            }

            else
            {
                ddl_Foundation.Visible = false;
                Label1.Visible = false;
                fillgrid();
               
            }

            

        }

    }

    private void fill_foundations()
    {
        DataTable dt = Foundations_DB.SelectAll();
        ddl_Foundation.DataSource = dt;
        ddl_Foundation.DataTextField = "Foundation_Name";
        ddl_Foundation.DataValueField = "Foundation_ID";
        ddl_Foundation.DataBind();


        ddl_Foundation.Items.Insert(0, new ListItem("كـــل الــجــهــات", "0"));
      

    }

    protected void ddl_Foundation_SelectedIndexChanged(object sender, EventArgs e)
    {

        //if (ddl_Foundation.SelectedValue != "0")
       // {
            btn_print.Visible = true;
            gv_count.Visible = true;
            fillgrid();
           

        //}
        //else
        //{
        //    gv_count.Visible = false;
        //    btn_print.Visible = false ;
        //}

        

      

    }

    private void fillgrid()
    {
        DataTable dt;
        DataTable dt2;
        DataTable dt_foundall=new DataTable () ;
        dt_foundall.Columns.Add("found_name");
        dt_foundall.Columns.Add("Employee_count");
        dt_foundall.Columns.Add("Inbox_count");
        dt_foundall.Columns.Add("Visa_count");
        dt_foundall.Columns.Add("Follows_count");
        dt_foundall.Columns.Add("outbox_count");
        dt_foundall.Columns.Add("Visaoutbox_count");
        dt_foundall.Columns.Add("Followsoutbox_count");

        if (ddl_Foundation.SelectedValue == "0")
        {
            DataTable dtfound = Foundations_DB.SelectAll();
            if (dtfound.Rows.Count > 0)
            {
               
               for(int x=0;x<dtfound.Rows.Count;x++)
               {
                    dt2 = Outbox_DB.Foundations_Followup(CDataConverter.ConvertToInt(dtfound.Rows[x]["foundation_id"].ToString()));
                    if (dt2.Rows.Count > 0)
                    {
                       foreach( DataRow  row2 in dt2.Rows  )
                       {


                           dt_foundall.ImportRow(row2);
                      

                            
                       }

                    }
                }

               

                gv_count.DataSource = dt_foundall ;
                gv_count.DataBind();

               
            }

           

        }
        else
        {

            string urlPath2 = Request.Url.AbsolutePath.Trim();

            if (urlPath2.Contains("SuperAdmin"))
            {


                dt = Outbox_DB.Foundations_Followup(CDataConverter.ConvertToInt(ddl_Foundation.SelectedValue));

            }

            else
            {
                dt = Outbox_DB.Foundations_Followup(CDataConverter.ConvertToInt(Session_CS.foundation_id));

            }

            gv_count.DataSource = dt;
            gv_count.DataBind();
        }
       
    }


}
