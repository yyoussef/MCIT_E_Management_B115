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
using System.Text;

public partial class UserControls_Site_Menu3Copy : System.Web.UI.UserControl
{
    //Session_CS Session_CS = new Session_CS();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {


         
            /*if (Session_CS.Eval_mng.ToString() == "1")
            {
                LI_Eval_Emp.Visible = true;
            }

            if (Session_CS.Hr_Eval.ToString() == "1")
            {
                Li_vacation.Visible = false;
                LI_Eval_Emp.Visible = true;
                //LI_Eval_Emp_Report.Visible = true;
            }*/


            select_nonActive();

            int RoleID = CDataConverter.ConvertToInt(Session_CS.UROL_UROL_ID);
           int ProjectID = CDataConverter.ConvertToInt(Session_CS.Project_id);


           if (Request.QueryString["Proj_id"] != null && Request.QueryString["Proj_id"] != "")
               {
                   ProjectID = CDataConverter.ConvertToInt(Request["Proj_id"].ToString());
               }
         

            ArrayList AllPages = new ArrayList();
            ArrayList RolePages = new ArrayList();

            ArrayList UserPages = User_info.DT_User_Permission;
            AllPages.AddRange(UserPages);

            if (RoleID != 4)
            {
                RolePages = User_info.GetUserPagesByRoleID(RoleID);
                AllPages.AddRange(RolePages);
                
            }

            if (ProjectID >0  && isOwnProject(ProjectID))
            {
                RolePages = User_info.GetUserPagesByRoleID(4);
                AllPages.AddRange(RolePages);
                
            }

            //if (RoleID == 3 && ProjectID > 0 && isOwnProject(ProjectID))
            //{
               

            //    RolePages = General_Helping.GetUserPagesByRoleID(4);
            //    AllPages.AddRange(RolePages);

               

                Show_Hide_Menu_Item(AllPages);
                string InsideMCIT = System.Configuration.ConfigurationManager.AppSettings["InsideMCIT"].ToString();
                if (InsideMCIT != "1")
                {
                    li_doc_Show.Visible = false;
                   
                   
                }
            //}
            //else if (RoleID != 4 || (RoleID == 4 && ProjectID > 0))
            //{
            //    ArrayList RolePages = General_Helping.GetUserPagesByRoleID(RoleID);
            //    ArrayList UserPages = General_Helping.DT_User_Permission;
            //    ArrayList AllPages = new ArrayList();

            //    AllPages.AddRange(RolePages);
            //    AllPages.AddRange(UserPages);

            //    Show_Hide_Menu_Item(AllPages);

            //}
            ////case of pm without project id in the session
            //else if (RoleID == 4)
            //{
            //    ArrayList Pages = new ArrayList();
            //    //Pages.Add(85);
            //    //Pages.Add(77);
            //    //Pages.Add(100);
            //    Show_Hide_Menu_Item(Pages);
            //}

                ahref.HRef = "../MainForm/ProjectGeneralData.aspx?mode=edit&Proj_id=" + ProjectID;

        }
    }

    private void Show_Hide_Menu_Item(ArrayList arr)
    {
        //foreach (Control cntrl_LI in MangerDepDiv.Controls)
        //{
        //    if (cntrl_LI.GetType() == typeof(HtmlGenericControl))
        //    {

        foreach (Control cntrl_hidden in MangerDepDiv.Controls)
        {
            if (cntrl_hidden.GetType() == typeof(HtmlInputHidden))
            {

                if (arr.Contains(CDataConverter.ConvertToInt(((HtmlInputHidden)cntrl_hidden).Value)))
                {
                    cntrl_hidden.Visible = true;
                    break;
                }
            }
            else if (cntrl_hidden.GetType() == typeof(HtmlGenericControl))
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
        //    }
        //}
        //hidden1.Parent.Visible = false;


    }

    private bool isOwnProject(int projectID)
    {
        string sql = " SELECT Proj_id ,pmp_pmp_id  FROM  Project where Proj_id = '" + projectID + "' and pmp_pmp_id = '" + Session_CS.pmp_id + "'";
        DataTable DT = General_Helping.GetDataTable(sql);
        if (DT.Rows.Count > 0)
        {
            return true;
        }
        else 
        {
            string sql2 = " SELECT     Project_Team.proj_proj_id FROM         Project_Team WHERE     Edit_Project = 'true' and proj_proj_id = '" + projectID + "'";
            sql2 += " and pmp_pmp_id = '" + Session_CS.pmp_id+"'";
            DataTable DT2 = General_Helping.GetDataTable(sql2);
            if (DT2.Rows.Count > 0)
            {
                return true;
            }

        }
        return false;
    }


    private void select_nonActive()
    {
        DataTable dt = Admin_Module_DB.SelectNonActiveModule_found(Session_CS.foundation_id);
        //DataTable dt = Admin_Module_DB.SelectNonActiveModule();
        if (dt.Rows.Count > 0)
        {

            for (int i = 0; i < dt.Rows.Count;i++ )
            {
                if (dt.Rows[i]["pk_ID"].ToString() == "10")
                {
                    Mod_Training_10.Visible = false;
                }
                else if(dt.Rows[i]["pk_ID"].ToString() == "11")
                {
                    Mod_Evaluation_11.Visible = false ;
                }

                else if (dt.Rows[i]["pk_ID"].ToString() == "9")
                {
                    Mod_Vacation_9.Visible = false;
                }

            }


        }

    }


}
