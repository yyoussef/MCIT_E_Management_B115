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
    Session_CS Session_CS = new Session_CS();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            

            //if (Session_CS.Eval_mng.ToString() == "1")
            //{
                LI_Eval_Emp.Visible = true;
          //  }

            if (Session_CS.Hr_Eval.ToString() == "1")
            {
                Li_vacation.Visible = false;
                LI_Eval_Emp.Visible = true;
                //LI_Eval_Emp_Report.Visible = true;
            }
          //  ArrayList RolePages = General_Helping.GetUserPagesByRoleID(CDataConverter.ConvertToInt(Session_CS.UROL_UROL_ID));
            ArrayList UserPages = User_info.DT_User_Permission;
            ArrayList AllPages = new ArrayList();
            
            //AllPages.AddRange(RolePages);
            AllPages.AddRange(UserPages);

            Show_Hide_Menu_Item(AllPages);

        }
    }

    private void Show_Hide_Menu_Item(ArrayList arr)
    {
        foreach (Control cntrl_LI in MangerDepDiv.Controls)
        {
            if (cntrl_LI.GetType() == typeof(HtmlGenericControl))
            {
                foreach (Control cntrl_hidden in cntrl_LI.Controls)
                {
                    if (cntrl_hidden.GetType() == typeof(HtmlInputHidden))
                    {

                        if (arr.Contains(CDataConverter.ConvertToInt(((HtmlInputHidden)cntrl_hidden).Value)))
                        {
                            cntrl_LI.Visible = true;
                            break;
                        }
                    }
                    else if (cntrl_LI.GetType() == typeof(HtmlGenericControl))
                    {
                        foreach (Control cntrl_hidden_2 in cntrl_hidden.Controls)
                        {
                            if (cntrl_hidden_2.GetType() == typeof(HtmlInputHidden))
                            {

                                if (arr.Contains(CDataConverter.ConvertToInt(((HtmlInputHidden)cntrl_hidden_2).Value)))
                                {
                                    cntrl_hidden.Visible = true;
                                    break;
                                }
                            }
 
                    }
                    
 
                    }


                }
            }
        }
        //hidden1.Parent.Visible = false;


    }
}
