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

public partial class UserControls_Site_Menu_Admin : System.Web.UI.UserControl
{
    //protected void Page_Load(object sender, EventArgs e)
    //{
    //    if (!IsPostBack)
    //    {



    //        if (Session["Eval_mng"].ToString() == "1")
    //        {
    //            LI_Eval_Emp.Visible = true;
    //        }

    //        if (Session["Hr_Eval"].ToString() == "1")
    //        {
    //            Li_vacation.Visible = false;
    //            LI_Eval_Emp.Visible = true;
    //            LI_Eval_Emp_Report.Visible = true;
    //        }

    //        Show_Hide_Menu_Item(General_Helping.DT_User_Permission);

    //    }
    //}

    //private void Show_Hide_Menu_Item(ArrayList arr)
    //{
    //    foreach (Control cntrl_LI in MangerDepDiv.Controls)
    //    {
    //        if (cntrl_LI.GetType() == typeof(HtmlGenericControl))
    //        {
    //            foreach (Control cntrl_hidden in cntrl_LI.Controls)
    //            {
    //                if (cntrl_hidden.GetType() == typeof(HtmlInputHidden))
    //                {

    //                    if (arr.Contains(CDataConverter.ConvertToInt(((HtmlInputHidden)cntrl_hidden).Value)))
    //                    {
    //                        cntrl_LI.Visible = true;
    //                        break;
    //                    }
    //                }

    //            }
    //        }
    //    }
    //    hidden1.Parent.Visible = false;


    //}
}
