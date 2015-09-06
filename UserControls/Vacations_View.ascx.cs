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

public partial class UserControls_Vacations_View : System.Web.UI.UserControl
{

    //Session_CS Session_CS = new Session_CS();
    protected void Page_Load(object sender, EventArgs e)
    {

        //if (!IsPostBack)
        //{
        if (Session_CS.pmp_id != null && CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()) > 0)
        {
            load_counter();
            Show_Hide_Catagerios_vac();
        }
        //}
    }

    void Show_Hide_Catagerios_vac()
    {


        if (CDataConverter.ConvertToInt(lnkVocationsNo.Text) > 0 || CDataConverter.ConvertToInt(lnkErrandNo.Text) > 0 || CDataConverter.ConvertToInt(lnkDayOffNo.Text) > 0)
            lbl_Vcation.ForeColor = System.Drawing.Color.Red;

    }
    private void load_counter()
    {

        //if (Session_CS.is_vacation_mng.ToString() == "1")
        // {
      


        DataTable AllVacDT = Vacations_View_class.new_vacations_requests(CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()));

        //lnkVocationsNo.Text = AllVacDT.Rows.Count.ToString();
        lnkVocationsNo.Text = "لديك عدد (" + AllVacDT.Rows.Count.ToString() + ") طلب أجازة";
        if (AllVacDT.Rows.Count < 1)
            extentionMethods.DisableLinkButton(lnkVocationsNo);


        DataTable AllVacErgDT = Vacations_View_class.new_vacations_requests_dept(CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()));

        //lnkVocationsErgentNo.Text = AllVacErgDT.Rows.Count.ToString();
        lnkVocationsErgentNo.Text = "لديك عدد (" + AllVacErgDT.Rows.Count.ToString() + ") طلب أجازة عاجلة";
        if (AllVacErgDT.Rows.Count < 1)
            extentionMethods.DisableLinkButton(lnkVocationsErgentNo);




        Vacations_errand_DT VacObj2 = new Vacations_errand_DT();
        DataTable AllVacDT2 = Vacations_View_class.new_Errand_requests(CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()));


        //lnkErrandNo.Text = AllVacDT2.Rows.Count.ToString();
        lnkErrandNo.Text = "لديك عدد (" + AllVacDT2.Rows.Count.ToString() + ") طلب مأمورية";
        if (AllVacDT2.Rows.Count < 1)
            extentionMethods.DisableLinkButton(lnkErrandNo);

        Vacations_Dayoff_DT VacObj3 = new Vacations_Dayoff_DT();
        DataTable AllVacDT3 = Vacations_View_class.new_dayoff_requests(CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()));

      

        //lnkDayOffNo.Text = AllVacDT3.Rows.Count.ToString();
        lnkDayOffNo.Text = "لديك عدد (" + AllVacDT3.Rows.Count.ToString() + ") طلب يوم عطلة";
        if (AllVacDT3.Rows.Count < 1)
            extentionMethods.DisableLinkButton(lnkDayOffNo);

        Vocations_permission_DT VacPerm = new Vocations_permission_DT();
        DataTable AllVacPerm = Vacations_View_class.new_permissions_requests(CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()));
        
            
            //lnkpermNo.Text = AllVacPerm.Rows.Count.ToString();
            lnkpermNo.Text = "لديك عدد (" + AllVacPerm.Rows.Count.ToString() + ") طلب إذن";
            if (AllVacPerm.Rows.Count < 1)
                extentionMethods.DisableLinkButton(lnkpermNo);



        // }

    }



    protected void lnkVocationsNo_Click(object sender, EventArgs e)
    {

        if (CDataConverter.ConvertToInt(lnkVocationsNo.Text) > 0)
        {
            Response.Redirect("..\\MainForm\\vacations_manager.aspx?type=0");
        }
    }


    protected void lnkVocationsErgentNo_Click(object sender, EventArgs e)
    {

        if (CDataConverter.ConvertToInt(lnkVocationsErgentNo.Text) > 0)
        {
            Response.Redirect("..\\MainForm\\vacations_manager.aspx?type=1");
        }
    }

    protected void lnkErrandNo_Click(object sender, EventArgs e)
    {

        if (CDataConverter.ConvertToInt(lnkErrandNo.Text) > 0)
        {
            Response.Redirect("..\\MainForm\\vacations_errand_manager.aspx");
        }
    }



    protected void lnkDayOffNo_Click(object sender, EventArgs e)
    {
        if (CDataConverter.ConvertToInt(lnkDayOffNo.Text) > 0)
        {
            Response.Redirect("..\\MainForm\\vacations_dayoff_manager.aspx");
        }
    }

    protected void lnkpermNo_Click(object sender, EventArgs e)
    {
        if (CDataConverter.ConvertToInt(lnkpermNo.Text) > 0)
        {
            Response.Redirect("..\\MainForm\\permission_manager.aspx");
        }
    }







}
