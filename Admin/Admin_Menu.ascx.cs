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

public partial class UserControls_Site_Menu : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

          //  int Cat_Type = CDataConverter.ConvertToInt(Session["Cat_Type"].ToString());
          //  if (Cat_Type != 1)
              //  myMenu.Visible = false;

        }
    }

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
