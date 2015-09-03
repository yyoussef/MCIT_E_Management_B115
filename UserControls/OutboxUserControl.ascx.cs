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

public partial class UserControls_OutboxUserControl : System.Web.UI.UserControl
{
    //Session_CS Session_CS = new Session_CS();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadgrid();
            Show_Hide_Catagerios_inbox();
        }
    }
    private void loadgrid()
    {
       //string todayplus1 = DateTime.ParseExact(CDataConverter.ConvertDateTimeNowRtnDt().AddDays(1).ToString("dd/MM/yyyy"), "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
        string todayplus1 =CDataConverter.ConvertDateTimeToFormatdmy( CDataConverter.ConvertDateTimeNowRtnDt().AddDays(1)); //DateTime.ParseExact(CDataConverter.ConvertDateTimeNowRtnDt().AddDays(1).ToString("dd/MM/yyyy"), "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
        string todayplus2 = CDataConverter.ConvertDateTimeToFormatdmy(CDataConverter.ConvertDateTimeNowRtnDt().AddDays(2));//DateTime.ParseExact(CDataConverter.ConvertDateTimeNowRtnDt().AddDays(2).ToString("dd/MM/yyyy"), "dd/MM/yyyy", null).ToString("dd/MM/yyyy");


       // string todayplus1 = CDataConverter.ConvertDateTimeNowRtnDt().AddDays(1).ToString();
      //  string todayplus2 = CDataConverter.ConvertDateTimeNowRtnDt().AddDays(2).ToString();
        //string todayplus1 = VB_Classes.Dates.Dates_Operation.date_validate(DateTime.Now.AddDays(1).ToShortDateString());
        //string todayplus2 = VB_Classes.Dates.Dates_Operation.date_validate(DateTime.Now.AddDays(2).ToShortDateString());

        //string today = VB_Classes.Dates.Dates_Operation.date_validate(DateTime.Now.ToShortDateString());

        //string today = VB_Classes.Dates.Dates_Operation.date_validate(CDataConverter.ConvertDateTimeNowRtnDt().ToShortDateString());
       string today = CDataConverter.ConvertDateTimeNowRtrnString();

        int group = CDataConverter.ConvertToInt(Session_CS.group_id.ToString());
        int parent = CDataConverter.ConvertToInt(Session_CS.parent_id.ToString());
        int child = CDataConverter.ConvertToInt(Session_CS.child_emp.ToString());
        int pmp = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
        
       
        DataTable dt_Outbox_new = new DataTable();
        DataTable dt_Outbox_old = new DataTable();
        DataTable dt_Outbox_late = new DataTable();
        DataTable dt_Outbox_closed = new DataTable();
        DataTable dt_Outbox_follow = new DataTable();
       
        //DataTable dt_getchild = new DataTable();
        DataTable dt_Outbox_not_sent_visa = new DataTable();
        DataTable dt_Outbox_sent_visa = new DataTable();

        //if (child > 0)
        //{
        //    dt_Outbox_not_sent_visa = Outbox_class.getOutbox_not_sent_visa(group);
        //    dt_Outbox_sent_visa = Outbox_class.getOutbox_sent_visa(group);
        //    tr_Outbox_have_visa.Visible = true;
        //}

        dt_Outbox_new = Outbox_class.new_Outbox_all(parent, group, pmp,0);
        dt_Outbox_old = Outbox_class.old_Outbox_all(parent, group, pmp,0);
        dt_Outbox_late = Outbox_class.late_Outbox_all(parent, group, pmp, todayplus1, todayplus2,0);
        dt_Outbox_closed = Outbox_class.closed_Outbox_all(parent, group, pmp,0);
        dt_Outbox_follow = Outbox_class.follow_Outbox_all(parent,group, pmp,0);
      
        /////////////////////// new Outbox ///////////

        link_new_Outbox_forall.Text = "لديك عدد (" + dt_Outbox_new.Rows.Count.ToString() + ") صادر جديد";
        if (dt_Outbox_new.Rows.Count < 1)
            extentionMethods.DisableLinkButton(link_new_Outbox_forall);
      
        /////////////// old Outbox link_old_Outbox_forall
        link_old_Outbox_forall.Text = "لديك عدد (" + dt_Outbox_old.Rows.Count.ToString() + ") صادر جارى";
        if (dt_Outbox_old.Rows.Count < 1)
            extentionMethods.DisableLinkButton(link_old_Outbox_forall);
      
      
        /////////////// late outbox
       
        link_late_Outbox_forall.Text = "لديك عدد (" + dt_Outbox_late.Rows.Count.ToString() + ") صادر متأخر";
        if (dt_Outbox_late.Rows.Count < 1)
            extentionMethods.DisableLinkButton(link_late_Outbox_forall);
        //////////// closed Outbox
       
        link_closed_Outbox_forall.Text = "لديك عدد (" + dt_Outbox_closed.Rows.Count.ToString() + ") صادر منتهى";
        if (dt_Outbox_closed.Rows.Count < 1)
            extentionMethods.DisableLinkButton(link_closed_Outbox_forall);
        //////////// follow Outbox
       
        link_Outbox_have_follow_forall.Text = "لديك عدد (" + dt_Outbox_follow.Rows.Count.ToString() + ") صادر له متابعة";
        if (dt_Outbox_follow.Rows.Count < 1)
            extentionMethods.DisableLinkButton(link_Outbox_have_follow_forall);


        ///////////// have visa inbox
        //lnk_btn_Outboxhavevisa.Text = dt_Outbox_not_sent_visa.Rows.Count.ToString();
    }
    void Show_Hide_Catagerios_inbox()
    {


        //if (CDataConverter.ConvertToInt(link_new_Outbox_forall.Text) > 0 || CDataConverter.ConvertToInt(link_Outbox_have_follow_forall.Text) > 0 || CDataConverter.ConvertToInt(link_late_Outbox_forall.Text)>0)
        //    lbl_archive_forall.ForeColor = System.Drawing.Color.Red;

        //chnage the BgColor for archiving
        if (CDataConverter.ConvertToInt(link_new_Outbox_forall.Text) > 0)
            td_link_new_Outbox_forall.BgColor = "#FCFBB2";


        if (CDataConverter.ConvertToInt(link_Outbox_have_follow_forall.Text) > 0)
            td_link_Outbox_have_follow_forall.BgColor = "#FCFBB2";



    }

    protected void lnk_btn_Outbox_new_forall_Click(object sender, EventArgs e)
    {
        if (CDataConverter.ConvertToInt(link_new_Outbox_forall.Text) > 0)
        {

            //lblMain.Text = "قائمة الوارد الجديد";


            Response.Redirect("Outbox_Grid_Page.aspx?Type=1");
           


          


        }
    }
    protected void lnk_btn_have_follow_forall_Click(object sender, EventArgs e)
    {
        if (CDataConverter.ConvertToInt(link_Outbox_have_follow_forall.Text) > 0)
        {

           // lblMain.Text = "قائمة الوارد له متابعة";


            Response.Redirect("Outbox_Grid_Page.aspx?Type=2");


           
        }
    }
    protected void lnk_btn_Outbox_old_forall_Click(object sender, EventArgs e)
    {
        if (CDataConverter.ConvertToInt(link_old_Outbox_forall.Text) > 0)
        {

           // lblMain.Text = "قائمة الوارد القديم";


            Response.Redirect("Outbox_Grid_Page.aspx?Type=3");
          
          


        }
    }
    protected void lnk_btn_Outbox_late_forall_Click(object sender, EventArgs e)
    {
        if (CDataConverter.ConvertToInt(link_late_Outbox_forall.Text) > 0)
        {

            // lblMain.Text = "قائمة الصادر المتاخر";


            Response.Redirect("Outbox_Grid_Page.aspx?Type=10");




        }
    }
    protected void lnk_btn_Outbox_closed_forall_Click(object sender, EventArgs e)
    {
        if (CDataConverter.ConvertToInt(link_closed_Outbox_forall.Text) > 0)
        {

            //lblMain.Text = "قائمة الوارد المنتهي";


            Response.Redirect("Outbox_Grid_Page.aspx?Type=5");


          

        }
    }
    protected void lnk_btn_Outbox_have_visa_Click(object sender, EventArgs e)
    {


        //lblMain.Text = "قائمة الوارد له تأشيرة";
        Response.Redirect("Outbox_Grid_Page.aspx?Type=visa");
        


    }
    
}
