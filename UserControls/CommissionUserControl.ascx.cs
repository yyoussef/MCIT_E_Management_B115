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

public partial class UserControls_CommissionUserControl : System.Web.UI.UserControl
{
    //Session_CS Session_CS = new Session_CS();
    protected void Page_Load(object sender, EventArgs e)
    {
        loadgrid();
        Show_Hide_Catagerios_inbox();
    }
    private void loadgrid()
    {
      string todayplus1 = CDataConverter.ConvertDateTimeToFormatdmy((CDataConverter.ConvertDateTimeNowRtnDt().AddDays(1)));
      string todayplus2 = CDataConverter.ConvertDateTimeToFormatdmy((CDataConverter.ConvertDateTimeNowRtnDt().AddDays(2)));

        //string todayplus1 = DateTime.ParseExact(DateTime.Now.AddDays(1).ToString("dd/MM/yyyy"), "dd/MM/yyyy", null).ToString("dd/MM/yyyy");

        
        //string todayplus2 = DateTime.ParseExact(DateTime.Now.AddDays(2).ToString("dd/MM/yyyy"), "dd/MM/yyyy", null).ToString("dd/MM/yyyy");

      //  string todayplus1 = CDataConverter.ConvertDateTimeNowRtnDt().AddDays(1).ToString();


       // string todayplus2 = CDataConverter.ConvertDateTimeNowRtnDt().AddDays(2).ToString();

       // string today = VB_Classes.Dates.Dates_Operation.date_validate(DateTime.Now.ToShortDateString());
      string today = CDataConverter.ConvertDateTimeToFormatdmy((CDataConverter.ConvertDateTimeNowRtnDt()));
        int group = CDataConverter.ConvertToInt(Session_CS.group_id.ToString());
        int parent = CDataConverter.ConvertToInt(Session_CS.parent_id.ToString());
        int pmp = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());

        DataTable dt_com_late = new DataTable();
        DataTable dt_com_new = new DataTable();
        DataTable dt_com_old = new DataTable();
        DataTable dt_com_closed = new DataTable();
        DataTable dt_com_follow = new DataTable();

        dt_com_new = Commission_DB.new_com_all(parent, group, pmp);
        dt_com_old = Commission_DB.old_com_all(parent, group, pmp);
        dt_com_late = Commission_DB.late_com_all(parent, group, pmp, todayplus1, todayplus2);
        dt_com_closed = Commission_DB.closed_com_all(parent, group, pmp);
        dt_com_follow = Commission_DB.follow_com_all(parent, pmp);

        //////////////////// late com //////////////////        
        link_late_com.Text = dt_com_late.Rows.Count.ToString();
        /////////////////////// new com ///////////
        link_new_com.Text = dt_com_new.Rows.Count.ToString();

        /////////////// old com 
        link_old_com.Text = dt_com_old.Rows.Count.ToString();
        //////////// closed com
        link_closed_com.Text = dt_com_closed.Rows.Count.ToString();
        //////////// follow com
        link_com_have_follow.Text = dt_com_follow.Rows.Count.ToString();
    }
    void Show_Hide_Catagerios_inbox()
    {


        if (CDataConverter.ConvertToInt(link_new_com.Text) > 0)
            tr_link_new_com.BgColor = "#FCFBB2";
        if (CDataConverter.ConvertToInt(link_late_com.Text) > 0)
            td_com_late.BgColor = "#FCFBB2";
        if (CDataConverter.ConvertToInt(link_com_have_follow.Text) > 0)
            tr_link_com_have_follow.BgColor = "#FCFBB2";


        if (CDataConverter.ConvertToInt(link_new_com.Text) > 0 || CDataConverter.ConvertToInt(link_com_have_follow.Text) > 0 || CDataConverter.ConvertToInt(link_late_com.Text) > 0)
            lbl_commission.ForeColor = System.Drawing.Color.Red;

    }

    protected void lnk_btn_com_new_Click(object sender, EventArgs e)
    {
        if (CDataConverter.ConvertToInt(link_new_com.Text) > 0)
        {





            Response.Redirect("../mainform/Commission_Grid_Page.aspx?Type=newcom");

           


        }
    }
    protected void lnk_btn_com_have_follow_Click(object sender, EventArgs e)
    {
        if (CDataConverter.ConvertToInt(link_com_have_follow.Text) > 0)
        {




            Response.Redirect("Commission_Grid_Page.aspx?Type=followcom");


           


        }
    }
    protected void lnk_btn_com_old_Click(object sender, EventArgs e)
    {
        if (CDataConverter.ConvertToInt(link_old_com.Text) > 0)
        {

            //lblMain.Text = "قائمة التكليفات الجارية";



            Response.Redirect("Commission_Grid_Page.aspx?Type=oldcom");


            //tbl_grd.Visible = true;
            //tr_Liks.Visible = false;


        }
    }
    protected void lnk_btn_com_closed_Click(object sender, EventArgs e)
    {
        if (CDataConverter.ConvertToInt(link_closed_com.Text) > 0)
        {

            //lblMain.Text = "قائمة التكليفات المنتهية";



            Response.Redirect("Commission_Grid_Page.aspx?Type=closedcom");

            //tbl_grd.Visible = true;
            //tr_Liks.Visible = false;


        }
    }
    protected void lnk_btn_com_late_Click(object sender, EventArgs e)
    {
        if (CDataConverter.ConvertToInt(link_late_com.Text) > 0)
        {

            //lblMain.Text = "قائمة التكليف المتاخر";



            Response.Redirect("Commission_Grid_Page.aspx?Type=latecom");


            //tbl_grd.Visible = true;
            //tr_Liks.Visible = false;


        }
    }
}
