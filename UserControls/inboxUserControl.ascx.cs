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

public partial class UserControls_inboxUserControl : System.Web.UI.UserControl
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
        string todayplus1 = CDataConverter.ConvertDateTimeToFormatdmy(CDataConverter.ConvertDateTimeNowRtnDt().AddDays(1));
       
      //string todayplus2 = DateTime.ParseExact(CDataConverter.ConvertDateTimeNowRtnDt().AddDays(2).ToString("dd/MM/yyyy"), "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
      string todayplus2 = CDataConverter.ConvertDateTimeToFormatdmy ( CDataConverter.ConvertDateTimeNowRtnDt().AddDays(2));
      string today = CDataConverter.ConvertDateTimeToFormatdmy((CDataConverter.ConvertDateTimeNowRtnDt()));

        int group = CDataConverter.ConvertToInt(Session_CS.group_id.ToString());

        int parent = CDataConverter.ConvertToInt(Session_CS.parent_id.ToString());
        int parentbychild_for_visa = CDataConverter.ConvertToInt(Session_CS.parent_id.ToString());

        int child = CDataConverter.ConvertToInt(Session_CS.child_emp.ToString());
        int pmp = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());




        DataTable dt_try = new DataTable();
        DataTable dt_inbox_late = new DataTable();
        DataTable dt_inbox_new = new DataTable();
        DataTable dt_inbox_old = new DataTable();
        DataTable dt_inbox_closed = new DataTable();
        DataTable dt_inbox_follow = new DataTable();
        DataTable dt_inbox_understudy = new DataTable();
        //DataTable dt_getchild = new DataTable();
        DataTable dt_inbox_not_sent_visa = new DataTable();
        DataTable dt_inbox_sent_visa = new DataTable();
        if (parent > 0)
        {
             
            tr_inbox_UnderStudy_forall.Visible = true;

        }
        else
        {
            tr_inbox_UnderStudy_forall.Visible = false;

        }
        //dt_getchild = Inbox_class.getchild(pmp);
        if (child > 0)
        {

            dt_inbox_not_sent_visa = Inbox_class.getinbox_not_sent_visa(group, parentbychild_for_visa);
            dt_inbox_sent_visa = Inbox_class.getinbox_sent_visa(group, parentbychild_for_visa);
            tr_inbox_have_visa.Visible = true;
        }
       

        dt_inbox_new = Inbox_class.new_inbox_all(parent, group, pmp,0);
        dt_inbox_old = Inbox_class.old_inbox_all(parent, group, pmp,0);
       dt_inbox_late = Inbox_class.late_inbox_all(parent, group, pmp, todayplus1, todayplus2,0);
       dt_inbox_closed = Inbox_class.closed_inbox_all(parent, group, pmp,0);
       dt_inbox_follow = Inbox_class.follow_inbox_all(parent, pmp,0);
       dt_inbox_understudy = Inbox_class.understudy_inbox_all(group,0);
        
        /////////////////////// new inbox ///////////


       link_new_inbox_forall.Text = "لديك عدد (" + dt_inbox_new.Rows.Count.ToString() + ") وارد جديد";
       if (dt_inbox_new.Rows.Count <1)
           extentionMethods.DisableLinkButton(link_new_inbox_forall) ;
       
        /////////////// old inbox 

       link_old_inbox_forall.Text = "لديك عدد (" + dt_inbox_old.Rows.Count.ToString() + ") وارد جارى";
        if (dt_inbox_old.Rows.Count < 1)
           extentionMethods.DisableLinkButton(link_old_inbox_forall);
        
       //////////////////// late inbox //////////////////        

        link_late_inbox_forall.Text = "لديك عدد (" + dt_inbox_late.Rows.Count.ToString() + ") وارد متأخر"; 
        if (dt_inbox_late.Rows.Count < 1)
           extentionMethods.DisableLinkButton(link_late_inbox_forall);
       
        //////////// closed inbox6

        link_closed_inbox_forall.Text = "لديك عدد (" + dt_inbox_closed.Rows.Count.ToString() + ") وارد منتهى";
        if (dt_inbox_closed.Rows.Count < 1)
            extentionMethods.DisableLinkButton(link_closed_inbox_forall);
       
        //////////// follow inbox
        link_inbox_have_follow_forall.Text = "لديك عدد (" + dt_inbox_follow.Rows.Count.ToString() + ") وارد له متابعة";
        if (dt_inbox_follow.Rows.Count < 1)
            extentionMethods.DisableLinkButton(link_inbox_have_follow_forall);
        
        
        //////////under study inbox
        lnkBtnUnderStudyCount_forall.Text = "لديك عدد (" + dt_inbox_understudy.Rows.Count.ToString() + ") وارد تحت الدراسة";
        if (dt_inbox_understudy.Rows.Count < 1)
            extentionMethods.DisableLinkButton(lnkBtnUnderStudyCount_forall);
        
        
        ///////////// have visa inbox

        lnk_btn_inboxhavevisa.Text = "لديك عدد (" + dt_inbox_not_sent_visa.Rows.Count.ToString() + ") وارد له تأشيرة";
        if (dt_inbox_not_sent_visa.Rows.Count < 1)
            extentionMethods.DisableLinkButton(lnk_btn_inboxhavevisa);
       
    }
    void Show_Hide_Catagerios_inbox()
    {


       // if (CDataConverter.ConvertToInt(link_new_inbox_forall.Text) > 0 || CDataConverter.ConvertToInt(link_inbox_have_follow_forall.Text) > 0)
            //lbl_archive_forall.ForeColor = System.Drawing.Color.Red;

        //chnage the BgColor for archiving
        //if (CDataConverter.ConvertToInt(link_new_inbox_forall.Text) > 0)
            //td_link_new_inbox_forall.BgColor = "#FCFBB2";


        //if (CDataConverter.ConvertToInt(link_inbox_have_follow_forall.Text) > 0)
            //td_link_inbox_have_follow_forall.BgColor = "#FCFBB2";



    }
   
    protected void lnk_btn_inbox_new_forall_Click(object sender, EventArgs e)
    {
        if (CDataConverter.ConvertToInt(link_new_inbox_forall.Text) > 0)
        {

            //lblMain.Text = "قائمة الوارد الجديد";

            if (Session_CS.parent_id<0)
            {
                Response.Redirect("Inbox_Grid_Page_HM.aspx?Type=1");
            }
            else

            Response.Redirect("Inbox_Grid_Page.aspx?Type=1");
           


          


        }
    }
    protected void lnk_btn_have_follow_forall_Click(object sender, EventArgs e)
    {
        if (CDataConverter.ConvertToInt(link_inbox_have_follow_forall.Text) > 0)
        {

           // lblMain.Text = "قائمة الوارد له متابعة";


            Response.Redirect("Inbox_Grid_Page.aspx?Type=2");


           
        }
    }
    protected void lnk_btn_inbox_old_forall_Click(object sender, EventArgs e)
    {
        if (CDataConverter.ConvertToInt(link_old_inbox_forall.Text) > 0)
        {

           // lblMain.Text = "قائمة الوارد القديم";


            Response.Redirect("Inbox_Grid_Page.aspx?Type=3");
          
          


        }
    }
    protected void lnk_btn_inbox_late_forall_Click(object sender, EventArgs e)
    {
        if (CDataConverter.ConvertToInt(link_late_inbox_forall.Text) > 0)
        {

           // lblMain.Text = "قائمة الوارد المتاخر";


            Response.Redirect("Inbox_Grid_Page.aspx?Type=10");


           

        }
    }
    protected void lnk_btn_inbox_closed_forall_Click(object sender, EventArgs e)
    {
        if (CDataConverter.ConvertToInt(link_closed_inbox_forall.Text) > 0)
        {

            //lblMain.Text = "قائمة الوارد المنتهي";


            Response.Redirect("Inbox_Grid_Page.aspx?Type=5");


          

        }
    }
    protected void lnk_btn_inbox_have_visa_Click(object sender, EventArgs e)
    {


        //lblMain.Text = "قائمة الوارد له تأشيرة";
        Response.Redirect("Inbox_Grid_Page.aspx?Type=visa");
        


    }
    protected void lnkBtnUnderStudy_forall_Click(object sender, EventArgs e)
    {
        if (CDataConverter.ConvertToInt(lnkBtnUnderStudyCount_forall.Text) > 0)
        {
            //lblMain.Text = "قائمة الوارد تحت الدراسة";
            Response.Redirect("Inbox_Grid_Page.aspx?Type=4");
         
        }
    }

   
}
