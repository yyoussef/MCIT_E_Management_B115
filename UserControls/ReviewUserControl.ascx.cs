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

public partial class UserControls_ReviewUserControl : System.Web.UI.UserControl
{
    //Session_CS Session_CS = new Session_CS();
    protected void Page_Load(object sender, EventArgs e)
    {
        loadcounter();
        if (!IsPostBack)
        {
            loadcounter();
        }
    }




    private void loadcounter()
    {
        DataTable dt_new = new DataTable();
        DataTable dt_closed = new DataTable();

        //if (CDataConverter.ConvertToInt(Session_CS.parent_id.ToString())>0)
        //{
        //    dt_new = Bulliten_View.new_bulliten_review();
        //    link_new_Review.Text = dt_new.Rows.Count.ToString();

        //    tr_Review_emp_closed.Visible = false;
        //    tr_Review_Emp_New.Visible = false;
        //    tr_Review_new.Visible = true;
        //}
        //else
        //{
        dt_new = Bulliten_View.new_bulliten(CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()), 2);
        lnkbtn_Review_Emp_New.Text = dt_new.Rows.Count.ToString();

        dt_closed = Bulliten_View.closed_bulliten(CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()), 3);
        lnkbtn_Review_emp_closed.Text = dt_closed.Rows.Count.ToString();

        tr_Review_emp_closed.Visible = true;
        tr_Review_Emp_New.Visible = true;
       // tr_Review_new.Visible = false;
        //}

        //DataTable dt_Review_new = Bulliten_View.new_bulliten(CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()), 1);
        //if (dt_Review_new.Rows.Count > 0)
        //{
        //    lnkbtn_Review_Emp_New.Text = dt_Review_new.Rows.Count.ToString();
        //}

        //DataTable dt_Review_closed = Bulliten_View.closed_bulliten(CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()), 3);
        //if (dt_Review_closed.Rows.Count > 0)
        //{
        //    lnkbtn_Review_Emp_New.Text = dt_Review_closed.Rows.Count.ToString();
        //}



    }


    //private void Load_Grid_Count_Dr_Hesham()
    //{
    //    DataTable new_bulliten_review = Bulliten_View.new_bulliten_review();
    //    if (new_bulliten_review.Rows.Count > 0)
    //    {
    //        link_new_Review.Text = new_bulliten_review.Rows.Count.ToString();
    //    }
    //}


    protected void lnkbtn_Review_Emp_New_Click(object sender, EventArgs e)
    {
        if (CDataConverter.ConvertToInt(lnkbtn_Review_Emp_New.Text) > 0)
        {
            Response.Redirect("Review_Grid_Page.aspx?Type=newBulliten");
        }
    }

    protected void lnkbtn_Review_emp_closed_Click(object sender, EventArgs e)
    {
        if (CDataConverter.ConvertToInt(lnkbtn_Review_emp_closed.Text) > 0)
        {
            Response.Redirect("Review_Grid_Page.aspx?Type=closedBulliten");

        }
    }


   
}
