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
using System.Text;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Net.Mail;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using ReportsClass;
using EFModels;
public partial class UserControls_ViewProject_Outbox : System.Web.UI.UserControl
{
    private string sql_Connection = Database.ConnectionString;
    General_Helping Obj_General_Helping = new General_Helping();
    int id;
    string v_desc;
    OutboxContext outboxDBContext = new OutboxContext();
    //Session_CS Session_CS = new Session_CS();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(hidden_Number.Value))
        {
            string Div = "div" + hidden_Number.Value;
            string image = "image" + hidden_Number.Value;

         //   ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "success", "<script language=javascript>ChangeMeCase('" + Div + "','" + image + "','" + hidden_Number.Value + "');</script>", true);

        }

        if (!IsPostBack)
        {
            //fill_sectors();

            Smart_Search_dept.Show_OrgTree = true;
            int pmp = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());

            if (Request.QueryString["id"] != null)
            {
                //DateTime str = System.DateTime.Now; 
                DateTime str = CDataConverter.ConvertDateTimeNowRtnDt();
                DateTime str_dead = CDataConverter.ConvertDateTimeNowRtnDt().AddDays(7);
                txt_Visa_date.Text = CDataConverter.ConvertDateTimeNowRtrnString();
                txt_Dead_Line_DT.Text = CDataConverter.ConvertDateTimeToFormatdmy(str_dead); 
                txt_Follow_Date.Text = CDataConverter.ConvertDateTimeNowRtrnString();
                txt_time_follow.Text = CDataConverter.ConvertTimeNowRtnLongTimeFormat();

                String decrypted_id = Encryption.Decrypt(Request.QueryString["id"].ToString());
                id = Convert.ToInt16(decrypted_id);
                
                hidden_Id.Value = id.ToString();
                
                //if (CDataConverter.ConvertToInt(Session_CS.group_id.ToString()) == 3)
                //{
                //    DataTable dt_closed = General_Helping.GetDataTable(" select * from Outbox_Track_Emp where Emp_ID = " + pmp + " and Outbox_id = " + id);
                //    if (dt_closed.Rows.Count > 0)
                //    {
                //        btn_close_Outbox.Visible = true;
                        
                //    }
                //    else
                //    {
                //        btn_close_Outbox.Visible = false;
                        
                //    }
                //    //btn_end_late.Visible = false;
                //}
                //else
                //{
                //    if (CDataConverter.ConvertToInt(Session_CS.parent_id.ToString()) > 0)
                //    {
                //        btn_close_Outbox.Visible = true;
                //        //btn_end_late.Visible = true;

                //        //Trfollow.Visible = false;
                //    }
                //    else
                //    {
                //        btn_close_Outbox.Visible = false;
                //        //btn_end_late.Visible = false;
                //    }
                //}


                DataTable dt_closing = General_Helping.GetDataTable("SELECT   distinct  Outbox.ID, Outbox.pmp_pmp_id, parent_employee.parent_pmp_id, Outbox.foundation_id FROM         Outbox INNER JOIN   parent_employee ON Outbox.pmp_pmp_id = parent_employee.pmp_id where Outbox.id = " + id);
                if (CDataConverter.ConvertToInt(dt_closing.Rows[0]["parent_pmp_id"].ToString()) == pmp)
                {
                    btn_close_Outbox.Visible = true;
                    btn_end_late.Visible = true;
                    
                    

                }



                if (CDataConverter.ConvertToInt(Session_CS.child_emp.ToString()) > 0)
                {
                    DataTable dt_mng = General_Helping.GetDataTable("SELECT distinct EMPLOYEE.PMP_ID, EMPLOYEE.foundation_id, EMPLOYEE.pmp_name, parent_employee.pmp_id AS child_id FROM EMPLOYEE INNER JOIN parent_employee ON EMPLOYEE.PMP_ID = parent_employee.parent_pmp_id where parent_employee.pmp_id =" + CDataConverter.ConvertToInt(Session_CS.child_emp.ToString()));
                    ListItem obj = new ListItem(dt_mng.Rows[0]["pmp_name"].ToString(), dt_mng.Rows[0]["pmp_id"].ToString());
                    lst_emp.Items.Add(obj);
                }





                tr_old_emp.Visible = false;
                tr_old_emp_resp.Visible = false;
                string sql_for_chklist_emp = " select * from pmp_fav_View where pmp_fav_View.employee_id = " + CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()) + " ORDER BY LTRIM(pmp_name)";
                DataTable dt_emp_fav = General_Helping.GetDataTable(sql_for_chklist_emp);
                chklst_Visa_Emp_All.DataSource = dt_emp_fav;
                chklst_Visa_Emp_All.DataBind();
                //if (Session_CS.pmp_id.ToString() == "57")
                DataTable dt = General_Helping.GetDataTable("select parent_pmp_id,pmp_id from parent_employee where pmp_id = " + CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()) + "or parent_pmp_id = " + CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()));
                if (dt.Rows.Count > 0)
                {
                    if (CDataConverter.ConvertToInt(dt.Rows[0]["parent_pmp_id"].ToString()) == CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()))
                    {
                      //  Trfollow.Visible = false;

                       // Trfollow.Visible = true ;
                        Trfollow.Style.Add("display", "block");


                        TemplateE.Visible = false;
                        TemplateA.Visible = false;

                       // tr_follow_date.Visible = false;
                      //  tr_follow_desc.Visible = false;
                   //     tr_follow_doc.Visible = false;
                 //       tr_follow_person.Visible = false;
                //        tr_follow_save.Visible = false;
                //        tr_follow_proj.Visible = false;
                       

                        tr_follow_date.Style.Add("display", "none");
                        tr_follow_desc.Style.Add("display", "none");
                        tr_follow_doc.Style.Add("display", "none");
                        tr_follow_person.Style.Add("display", "none");
                        tr_follow_save.Style.Add("display", "none");
                        tr_follow_proj.Style.Add("display", "none");

                        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                        DataTable DT = new DataTable();
                        DT = General_Helping.GetDataTable("select * from Outbox_Track_Manager where Outbox_id = " + id);
                        if (DT.Rows.Count > 0)
                        {
                            //foreach (DataRow rw in DT.Rows)
                            //{
                            DataRow rw = DT.Rows[0];
                            //if (rw["status"].ToString() != "2")
                            //{
                            //    if (rw["Have_visa"].ToString() != "1")
                            //        //lnkBtnUnderStudy.Visible = true;

                            //}
                            if (CDataConverter.ConvertToInt(Session_CS.group_id.ToString()) == 3)
                            {
                                if (rw["IS_New_Mail"].ToString() != "3")
                                {
                                    conn.Open();
                                    string sql = "update Outbox_Track_Manager set status=0,Have_Follow=0 where Outbox_id =" + id;
                                    SqlCommand cmd = new SqlCommand(sql, conn);
                                    cmd.ExecuteNonQuery();
                                    conn.Close();
                                }
                            }

                            // }

                        }
                    }
                    //else
                    //{
                    //    tr_mngr1.Visible =
                    //   tr_mngr2.Visible = false;
                    //    GridView_Visa.Columns[6].Visible = false;

                    //}
                }
                else
                {
                    // tr_mngr1.Visible =
                    //tr_mngr2.Visible = false;

                    // GridView_Visa.Columns[6].Visible = false;
                    //DataTable dt_proj = General_Helping.GetDataTable(" select Proj_id from inbox where ID = " + id);
                    //Smart_Search_proj.sql_Connection = sql_Connection;
                    //if (CDataConverter.ConvertToInt(dt_proj.Rows[0]["Proj_id"].ToString()) > 0)
                    //{


                    //    Smart_Search_proj.SelectedValue = dt_proj.Rows[0]["Proj_id"].ToString();

                    //}
                    //else
                    //{
                    //    string sql = "";
                    //    string Main_sql = " SELECT  dbo.Project.Proj_id, dbo.Project.pmp_pmp_id, dbo.Project.Proj_Title, dbo.EMPLOYEE.pmp_name, dbo.Project.Proj_InitValue, dbo.Project.Proj_Notes,dbo.Protocol_Main_Def.Name, dbo.Protocol_Main_Def.Protocol_ID FROM dbo.Project LEFT OUTER JOIN dbo.Protocol_Main_Def ON dbo.Project.Protocol_ID = dbo.Protocol_Main_Def.Protocol_ID LEFT OUTER JOIN dbo.EMPLOYEE ON dbo.Project.pmp_pmp_id = dbo.EMPLOYEE.PMP_ID where 1=1  ";
                    //    if (Session_CS.UROL_UROL_ID != null && Session_CS.UROL_UROL_ID.ToString() == "4")
                    //    {
                    //        string Sql_Edit_Project = " or (Project.Proj_id IN (SELECT     Project_Team.proj_proj_id FROM Project_Team INNER JOIN Project ON Project_Team.proj_proj_id = Project.Proj_id  WHERE     (Edit_Project = 'true') AND (Project.Proj_is_commit = 2) and(Project_Team.pmp_pmp_id = " + Session_CS.pmp_id.ToString() + "))) ";
                    //        sql = Main_sql + " and Proj_is_commit = 2  and   pmp_pmp_id = " + Session_CS.pmp_id.ToString() + Sql_Edit_Project;
                    //    }
                    //    else if (Session_CS.UROL_UROL_ID != null && Session_CS.UROL_UROL_ID.ToString() == "3")
                    //    {

                    //        string Sql_Edit_Project = " or (Project.Proj_id IN (SELECT Project_Team.proj_proj_id FROM  Project_Team INNER JOIN Project ON Project_Team.proj_proj_id = Project.Proj_id  WHERE     (Edit_Project = 'true') AND (Project.Proj_is_commit = 2) and(Project_Team.pmp_pmp_id = " + Session_CS.pmp_id.ToString() + "))) ";
                    //        string sql_Proj_Deprts = " or Project.Dept_Dept_id in (select Dept_id from EMPLOYEE_Departemnts where PMP_ID = " + Session_CS.pmp_id.ToString() + ") and Proj_is_commit = 2 ";
                    //        sql = Main_sql + " and Proj_is_commit = 2 and  (pmp_pmp_id = " + Session_CS.pmp_id.ToString() + " or Project.Dept_Dept_id = " + Session_CS.dept_id.ToString() + ")" + sql_Proj_Deprts + Sql_Edit_Project;
                    //    }
                    //    else if (Session_CS.UROL_UROL_ID != null && Session_CS.UROL_UROL_ID.ToString() == "2")
                    //    {
                    //        sql = Main_sql + "and Proj_is_commit = 2 ";
                    //    }
                    //    Smart_Search_proj.Query = sql;
                    //    Smart_Search_proj.Value_Field = "Proj_id";
                    //    Smart_Search_proj.Text_Field = "Proj_Title";
                    //    Smart_Search_proj.DataBind();
                        if (pmp == 70)
                        {
                            //Trfollow.Visible = false;

                            //tr_follow_date.Visible = false;
                            //tr_follow_desc.Visible = false;
                            //tr_follow_doc.Visible = false;
                            //tr_follow_person.Visible = false;
                            //tr_follow_save.Visible = false;
                            //tr_follow_proj.Visible = false;


                            tr_follow_date.Style.Add("display", "none");
                            tr_follow_desc.Style.Add("display", "none");
                            tr_follow_doc.Style.Add("display", "none");
                            tr_follow_person.Style.Add("display", "none");
                            tr_follow_save.Style.Add("display", "none");
                            tr_follow_proj.Style.Add("display", "none");

                            //     tr_mngr1.Visible =
                            //tr_mngr2.Visible = true;
                            //     GridView_Visa.Columns[6].Visible = true;
                        }
                    }
                }
                //}
                //else
                //{
                //tr_mngr1.Visible =
                //    tr_mngr2.Visible = true;
                //GridView_Visa.Columns[6].Visible = false;
                // }
                //DataTable dt_follow = General_Helping.GetDataTable("select * from inbox_follow_emp where inbox_id=" + id + "AND pmp_id = " + pmp);
                //if (dt_follow.Rows.Count > 0)
                //{
                //    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                //    conn.Open();
                string sql_update = "update Outbox_follow_emp set Have_follow = 0";
                sql_update += " where ( Outbox_follow_emp.pmp_id =" + pmp;
                sql_update += " AND Outbox_follow_emp.Outbox_id = " + id;
                sql_update += ")";
                General_Helping.ExcuteQuery(sql_update);
                //    SqlCommand cmd = new SqlCommand(sql_update, conn);
                //    cmd.ExecuteNonQuery();
                //    conn.Close();

                //}
                Fill_Controll(id);
                Fil_Grid_Documents();
                Fil_Grid_Visa_Follow();
                Fil_Dll();
                fil_emp_Visa();
                Fil_Emp_Visa_Follow();///////
                Fil_Grid_Visa();
                if (CDataConverter.ConvertToInt(Session_CS.group_id.ToString()) == 3)
                {
                    Smart_Search_dept.SelectedValue = "15";
                }


                if (Session_CS.pmp_id >0)
                {
                   // drop_sectors.SelectedValue = Session_CS.sec_id.ToString();
                    fill_depts();



                }

            }


        }


    //private void fill_sectors()
    //{
    //    DataTable dt = Sectors_DB.SelectAll(0, CDataConverter.ConvertToInt(Session_CS.foundation_id.ToString()));
    //    drop_sectors.DataSource = dt;

    //    drop_sectors.DataBind();
    //    drop_sectors.Items.Insert(0, new ListItem("إختر القطاع", "0"));

    //}
    public string Get_Type_2(object obj)
    {
        string str = obj.ToString();
        if (str == "1")
        {
            //hidden1.Value = "inbox";
            return "وارد";
        }
        else if (str == "2")
        {
            //hidden1.Value = "Outbox";
            return "صادر";
        }
        else return "";
    }
    protected void GrdView_Relation_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditItem")
        {
            int row_Index = ((GridViewRow)(((ImageButton)e.CommandSource).NamingContainer)).RowIndex;

            //DataTable dt2 = ViewState["dt"];
            // DataTable dt2 = ViewState["dt"] as DataTable ; 
            // DataTable dt = General_Helping.GetDataTable("select * from inbox_relations where id = " + CDataConverter.ConvertToInt(e.CommandArgument));
            //string encrypted = Encryption.Encrypt(dt2.ro.ToString());
            //DataRow[]  res = dt2.Select("Inbox_or_outbox = 2 ");

            //DataRow[] resss = dt2.Select("ID =  " + CDataConverter.ConvertToInt(e.CommandArgument.ToString()) + " and Inbox_or_outbox = 1");
            //DataRow[] resss_in = dt2.Select("ID =  " + CDataConverter.ConvertToInt(e.CommandArgument.ToString()) + " and Inbox_or_outbox = 1");
            // string all = e.CommandArgument.ToString();
            // string[] res = all.Split('#');
            // string ID = res[0];
            string R2 = ((HtmlInputHidden)(GrdView_Relation.Rows[row_Index].FindControl("input_type"))).Value; //res[1];
            //Get_Type_2(res[1]);
            //DataRow[] res2 = dt2.Select("Inbox_or_outbox = 1 "); 
            //DataTable st3 = res as DataTable;

            string encrypted = Encryption.Encrypt(e.CommandArgument.ToString());
            if (R2 == "2")
            {
                Response.Redirect("ViewProjectOutbox.aspx?id=" + encrypted);
            }
            else if (R2 == "1")
            {
                Response.Redirect("ViewProjectInbox.aspx?id=" + encrypted);
            }

            //if (resss.Length>0)
            //{
            //    Response.Redirect("ViewProjectInbox.aspx?id=" + encrypted);
            //}
            //foreach (DataRow row in resss)
            //{

            //    Response.Redirect("ViewProjectOutbox.aspx?id=" + encrypted);

            //}
            //foreach (DataRow row in resss_in)
            //{

            //    Response.Redirect("ViewProjectInbox.aspx?id=" + encrypted);

            //}

            //foreach (DataRow row in res)
            //{

            //}
            //for (int i = 0; i < dt2.Rows.Count; i++)
            //{
            // string encrypted = Encryption.Encrypt(res.);
            //if (dt2.Rows[i]["inbox_or_outbox"].ToString() == "2" )
            //{
            //    Response.Redirect("ViewProjectOutbox.aspx?id=" + encrypted);    
            //}
            //else 
            //    Response.Redirect("ViewProjectInbox.aspx?id=" + encrypted);
            //}
            //if (dt.Rows[0]["inbox_or_outbox"].ToString()=="1")
            //{
            //    Response.Redirect("ViewProjectInbox.aspx?id=" + encrypted);
            //}
            //else
            //    Response.Redirect("ViewProjectOutbox.aspx?id=" + encrypted);    
            //DataTable dt = General_Helping.GetDataTable("select * from inbox_relations where ");
            //DataTable dt_relation = General_Helping.GetDataTable("select * from inbox_Relations where  Related_id<>0 and inbox_id = " + e.CommandArgument + " or Related_id = " + e.CommandArgument);
            //for (int i = 0; i < dt_relation.Rows.Count; i++)
            //{
            //    if (CDataConverter.ConvertToInt(dt_relation.Rows[i]["Related_Type"].ToString()) == 2 )
            //    {
            //        if (CDataConverter.ConvertToInt(dt_relation.Rows[i]["Related_id"].ToString()) == CDataConverter.ConvertToInt( e.CommandArgument))
            //        {
            //            Response.Redirect("ViewProjectOutbox.aspx?id=" + encrypted);    
            //        }
            //    }
            //    else
            //        Response.Redirect("ViewProjectInbox.aspx?id=" + encrypted);


            //string s = GrdView_Relation.SelectedRow.Cells[0].Text;
            //int row = Convert.ToInt32(e.CommandArgument);
            // string pc = GrdView_Relation.Rows[1].Cells[1].Text;
            //}


            //if ( == "inbox")
            //{
            //    Response.Redirect("ViewProjectInbox.aspx?id=" + encrypted);
            //}
            //else if (hidden1.Value == "Outbox")
            //{
            //    Response.Redirect("ViewProjectOutbox.aspx?id=" + encrypted);
            //}

        }
    }
    protected void fill_depts()
    {
        // if (drop_sectors.SelectedValue != "0")
        //{
        Smart_Search_dept.sql_Connection = sql_Connection;
        //Smart_Search_dept.Query = "select Dept_ID,Dept_name from Departments where sec_sec_id='" + drop_sectors.SelectedValue + "' ";
        string Query = "select * from Departments where foundation_id='" + Session_CS.foundation_id  + "' ";
        Smart_Search_dept.datatble = General_Helping.GetDataTable(Query);
        Smart_Search_dept.Value_Field = "Dept_ID";
        Smart_Search_dept.Text_Field = "Dept_name";
        Smart_Search_dept.Orderby = "ORDER BY LTRIM(Dept_name)";
        Smart_Search_dept.DataBind();
       // }

         //else
         //{
         //    Smart_Search_dept.Clear_Controls();
         //}


        //////////////////////////////////////////////////////////


    }

    //protected void drop_sectors_SelectedIndexChanged(object sender, EventArgs e)
    //{

    //    fill_depts();

    //}

    
    protected void radlst_Type_SelectedIndexChanged(object sender, EventArgs e)
    {
        fill_resp_Emp();
      
     
    }

    private void fill_resp_Emp()
    {
        tr_emp_list.Visible = true;
        string sql, sql_emp = "";


        if (radlst_Type.SelectedValue == "1")
        {
            sql_emp = " select * from pmp_fav_View where pmp_fav_View.employee_id = " + CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
            if (Smart_Search_dept.SelectedValue != "")
            {
                sql_emp += " AND Dept_Dept_id = " + Smart_Search_dept.SelectedValue;
            }
            //if (ddl_sectors2.SelectedValue != "" && ddl_sectors2.SelectedValue != "0")
            //{
            sql_emp += "  and  sec_sec_id=0";
            //}



        }
        else if (radlst_Type.SelectedValue == "2")
        {
            // sql_emp = " select * from employee where dbo.EMPLOYEE.workstatus = 1";


            sql_emp = "SELECT     EMPLOYEE.*,Departments.* FROM Departments  INNER JOIN EMPLOYEE ON Departments.Dept_id = EMPLOYEE.Dept_Dept_id where  EMPLOYEE.PMP_ID not in(select parent_pmp_id from dbo.parent_employee) and dbo.EMPLOYEE.workstatus = 1 and EMPLOYEE.foundation_id='" + Session_CS.foundation_id + "'";

            if (Smart_Search_dept.SelectedValue != "")
            {
                sql_emp += " and Dept_Dept_id = " + Smart_Search_dept.SelectedValue;
            }
            //// if (ddl_sectors2.SelectedValue != "" && ddl_sectors2.SelectedValue != "0")
            //// {
            //     sql_emp += "and  Sectors.Sec_id=0"; //+ ddl_sectors2.SelectedValue;
            //// }

        }
        else if (radlst_Type.SelectedValue == "3")
        {
            // sql_emp = " select * from employee where rol_rol_id=3  and dbo.EMPLOYEE.workstatus = 1";

            sql_emp = "SELECT     EMPLOYEE.*,Departments.* FROM Departments  INNER JOIN EMPLOYEE ON Departments.Dept_id = EMPLOYEE.Dept_Dept_id where dbo.EMPLOYEE.workstatus = 1 and rol_rol_id=3 and EMPLOYEE.foundation_id='" + Session_CS.foundation_id + "'";


            if (Smart_Search_dept.SelectedValue != "")
            {
                sql_emp += " AND Dept_Dept_id = " + Smart_Search_dept.SelectedValue;
            }

            //  //if (ddl_sectors2.SelectedValue != "" && ddl_sectors2.SelectedValue != "0")
            ////  {
            //  sql_emp += "and  Sectors.Sec_id="; +ddl_sectors2.SelectedValue;
            // // }

        }
        else if (radlst_Type.SelectedValue == "4")
        {
            // sql_emp = " select * from employee where contact_person=1 and dbo.EMPLOYEE.workstatus = 1 ";

            sql_emp = "SELECT     EMPLOYEE.*,Departments.* FROM Departments  INNER JOIN EMPLOYEE ON Departments.Dept_id = EMPLOYEE.Dept_Dept_id where dbo.EMPLOYEE.workstatus = 1 and contact_person=1 and EMPLOYEE.foundation_id='" + Session_CS.foundation_id + "'";

            if (Smart_Search_dept.SelectedValue != "")
            {
                sql_emp += " AND Dept_Dept_id = " + Smart_Search_dept.SelectedValue;
            }

            //// if (ddl_sectors2.SelectedValue != "" && ddl_sectors2.SelectedValue != "0")
            // //{
            //     sql_emp += "and  Sectors.Sec_id="; + ddl_sectors2.SelectedValue;
            // //}

        }

        else if (radlst_Type.SelectedValue == "5")
        {
            sql_emp = "  select EMPLOYEE.pmp_name + ' - رئيس ' + +' '+ Commitee.Commitee_Title as pmp_name ,EMPLOYEE.PMP_ID from EMPLOYEE inner join commitee_presidents on  EMPLOYEE.PMP_ID=commitee_presidents.pmp_id inner join Commitee on commitee_presidents.comt_id = Commitee.ID where  Commitee.foundation_id='" + Session_CS.foundation_id + "'";

        }

        else if (radlst_Type.SelectedValue == "6")
        {

            sql_emp = "select EMPLOYEE.pmp_name COLLATE DATABASE_DEFAULT  + ' -  ' + Departments.Dept_name  as pmp_name,EMPLOYEE.PMP_ID from EMPLOYEE inner join commitee_presidents on  EMPLOYEE.PMP_ID=commitee_presidents.pmp_id inner join Departments on  commitee_presidents.dept_id = Departments.Dept_id   inner join Sectors  on Sectors.Sec_id = Departments.Sec_sec_id where Sectors.foundation_id='" + Session_CS.foundation_id + "'";
        }
        sql_emp += " ORDER BY LTRIM(pmp_name)";
        DataTable dt_emp_fav = General_Helping.GetDataTable(sql_emp);
        chklst_Visa_Emp_All.DataSource = dt_emp_fav;
        chklst_Visa_Emp_All.DataBind();
    }
    protected void btn_add_Click(object sender, EventArgs e)
    {

        fill_listbox();
        //TabPanel_All.ActiveTab = TabPanel_Visa;
    }
    public void fill_listbox()
    {
        foreach (ListItem item in chklst_Visa_Emp_All.Items)
        {
            if (item.Selected)
            {
                ListItem obj = new ListItem(item.Text, item.Value);
                lst_emp.Items.Add(obj);
                item.Selected = false;
            }
            //foreach (ListItem item2 in lst_emp.Items)
            //{
            //    if (item2.Value == item.Value)
            //    {
            //        Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('احد الموظفين المختارين موجود من قبل')</script>");
            //        return;
            //    }

            //}

        }
    }
    protected void btn_delete_Click(object sender, EventArgs e)
    {
        if (lst_emp.SelectedValue == "")
        {
          //  Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('يجب اختيار موظف ليتم الحذف')</script>");

            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('يجب اختيار موظف ليتم الحذف');", true);

        }
        else
        {
            lst_emp.Items.Remove(lst_emp.SelectedItem);

            //foreach (ListItem item  in lst_emp.Items)
            //{

            //    ListItem item2 = chklst_Visa_Emp_All.Items.FindByValue(item.Value);
            //    if (item2 != null)
            //        item2.Selected = true;
            //    else item2.Selected = false;
            //}

        }
        //TabPanel_All.ActiveTab = TabPanel_Visa;

    }
    protected void chk_ALL_CheckedChanged(object sender, EventArgs e)
    {
        foreach (ListItem item in chklst_Visa_Emp_All.Items)
        {
            item.Selected = chk_ALL.Checked;
        }
        //TabPanel_All.ActiveTab = TabPanel_Visa;
    }
    protected override void OnInit(EventArgs e)
    {
        #region BROWSER FOR departments

   
        Smart_Search_proj.sql_Connection = sql_Connection;
        //Smart_Search_proj.Query = "SELECT Proj_id, Proj_Title FROM Project ";
        string Query = "SELECT Proj_id, Proj_Title FROM Project ";
        Smart_Search_proj.datatble = General_Helping.GetDataTable(Query);
        Smart_Search_proj.Value_Field = "Proj_id";
        Smart_Search_proj.Text_Field = "Proj_Title";
        Smart_Search_proj.DataBind();

        Smart_Search_dept.sql_Connection = sql_Connection;
       // Smart_Search_dept.Query = "SELECT Dept_id, Dept_name FROM Departments ";
        Query = "SELECT Dept_id, Dept_name FROM Departments ";
        Smart_Search_dept.datatble = General_Helping.GetDataTable(Query);
        Smart_Search_dept.Value_Field = "Dept_id";
        Smart_Search_dept.Text_Field = "Dept_name";
        Smart_Search_dept.DataBind();

         fill_depts();        
        this.Smart_Search_dept.Value_Handler += new Smart_Search.Delegate_Selected_Value(MOnMember_Data);
        #endregion
        base.OnInit(e);
    }
    private void MOnMember_Data(string Value)
    {
        dropdept_fun();
    }
    protected void dropdept_fun()
    {



        fil_emp_Visa();
        fill_resp_Emp();


    }
    private void Fil_Dll()
    {
        //DataTable DT = new DataTable();
        //DT = General_Helping.GetDataTable("select * from Departments");
        //Obj_General_Helping.SmartBindDDL(ddl_Visa_Dept_ID, DT, "Dept_ID", "Dept_name", "....اختر اسم الإدارة ....");


    }

    private void fil_emp_Visa()
    {
        int Dept_ID = CDataConverter.ConvertToInt(Smart_Search_dept.SelectedValue);
        string sql = "SELECT PMP_ID, pmp_name FROM EMPLOYEE ";
        if (Dept_ID > 0)
        {
            sql += " where Dept_Dept_id = " + Dept_ID;

        }
        sql += " order by pmp_name asc";
        chklst_Visa_Emp.DataSource = General_Helping.GetDataTable(sql);
        chklst_Visa_Emp.DataBind();


    }

    protected void ddl_Visa_Dept_ID_SelectedIndexChanged(object sender, EventArgs e)
    {
        //fil_emp_Visa();
    }

    private void Fill_Controll(int id)
    {
        try
        {
            DataTable allOutboxdata = Outbox_DB.Outbox_fillcontrol(id);
            DataRow Outall = allOutboxdata.Rows[0];


            Outbox_DT obj = Outbox_DB.SelectByID(id);
            hidden_Id.Value = Outall["id"].ToString();

            hidden_Proj_id.Value = Outall["Proj_id"].ToString();

            //hidden_Id.Value = obj.ID.ToString();
            //hidden_Proj_id.Value = obj.Proj_id.ToString();
            if (Outall["Type"].ToString() == "2")
            {
                lblLetterType.Text = "صادر خارجي";
            }
            if (Outall["Type"].ToString() == "1")
            { lblLetterType.Text = "صادر داخلي"; }

            lblCode.Text = Outall["Code"].ToString();
            lblLetterDate.Text = Outall["Date"].ToString();

            //lblCode.Text = obj.Code;
            //lblLetterDate.Text = obj.Date;
            //ddl_Type.SelectedValue = obj.Type.ToString();
            if (Outall["Source_Type"].ToString() == "1")
            {
                lblSourceType.Text = "البريد";
            }
            if (Outall["Source_Type"].ToString() == "2")
            { lblSourceType.Text = "الايميل"; }
            if (Outall["Source_Type"].ToString() == "3")
            { lblSourceType.Text = "الفاكس"; }


            if (Outall["Org_Dept_Name"].ToString() != "")
                lblDept_in.Text = Outall["Org_Out_Box_Person"].ToString();

            //if (obj.Org_Out_Box_Person != "")
            //lblOrg_Out_Box_Person.Text = obj.Org_Out_Box_Person.ToString();

            lblOrg_Out_Box_DT.Text = Outall["Org_Out_Box_DT"].ToString();
            lblOrg_Out_Box_Code.Text = Outall["Org_Out_Box_Code"].ToString();
            lbl_paper_no.Text = Outall["Paper_No"].ToString();
            lbl_att_no.Text = Outall["Paper_Attached"].ToString();
            txt_subject.Text = Outall["Subject"].ToString();
            txt_notes.Text = Outall["Notes"].ToString();
            //DataTable DT_vd = new DataTable();
            //DT_vd = General_Helping.GetDataTable("select * from Outbox_Track_Manager where Outbox_id = " + id);
            //if (DT_vd.Rows.Count > 0)
            //    txt_Visa_Desc.Text = DT_vd.Rows[0]["Visa_Desc"].ToString();
            //ddl_Related_Type.SelectedValue = obj.Related_Type.ToString();
            txt_Visa_Desc.Text = Outall["Visa_Desc"].ToString();
            if (Outall["Related_Type"].ToString() != "")
            {
                if (Outall["Related_Type"].ToString() == "1")
                { lblRelatedType.Text = "صادر جديد"; }
                if (Outall["Related_Type"].ToString() == "2")
                { lblRelatedType.Text = "رد على وارد"; }
                if (Outall["Related_Type"].ToString() == "3")
                { lblRelatedType.Text = "استعجال صادر"; }
                if (Outall["Related_Type"].ToString() == "4")
                { lblRelatedType.Text = "رد على تأشيرة وزير"; }
                if (Outall["Related_Type"].ToString() == "5")
                { lblRelatedType.Text = "أخري"; }

                if (Outall["Related_Type"].ToString() == "6")
                { lblRelatedType.Text = "وارد لصادر داخلي"; }

            }
            GrdView_Relation.DataSource = Inbox_DB.SelectRelated(id, 2);

            GrdView_Relation.DataBind();

            string all = "";
            int idrelated = 0;

            if (Outall["Related_Type"].ToString() != "")
            {
       

                DataTable dt_direct_related = Outbox_DB.Outbox_Direct_Relating(CDataConverter.ConvertToInt(Outall["Related_Type"].ToString()), CDataConverter.ConvertToInt(Outall["Related_Id"].ToString()));
                if (Outall["Related_Type"].ToString() == "1")
                {

                    lbl_Inbox_type.Visible = false;
                    lbl_letter.Visible = false;

                }

                if (Outall["Related_Type"].ToString() == "2" || Outall["Related_Type"].ToString() == "5")
                {
                    all = dt_direct_related.Rows[0]["con"].ToString();
                    string[] res = all.Split('-');
                    idrelated = CDataConverter.ConvertToInt(res[3].ToString());

                    lbl_Inbox_type.Text = "موضوع الخطاب الوارد :";


                    if (dt_direct_related.Rows.Count > 0)
                    {
                        int INid = idrelated;// CDataConverter.ConvertToInt(dt_direct_related.Rows[0]["id"].ToString());
                        string encrypted = Encryption.Encrypt(INid.ToString());
                        lbl_letter.Text = dt_direct_related.Rows[0]["con"].ToString();
                        lbl_letter.NavigateUrl = "../mainform/ViewProjectInbox.aspx?id=" + encrypted;
                    }
                }
                if (obj.Related_Type == 3)
                {
                    all = dt_direct_related.Rows[0]["con"].ToString();
                    string[] res = all.Split('-');
                    idrelated = CDataConverter.ConvertToInt(res[3].ToString());
                    lbl_Inbox_type.Text = "موضوع الخطاب الصادر :";

                    //string sql = "SELECT * from vw_outbox_DateString ";
                    //sql += " where  ID='" + CDataConverter.ConvertToInt(obj.Related_Id.ToString()) + "' ";

                    //if (CDataConverter.ConvertToInt(Session_CS.Project_id.ToString()) > 0)
                    //{
                    //    sql += " AND Proj_id = " + int.Parse(Session_CS.Project_id.ToString());
                    //}
                    //DataTable dt = General_Helping.GetDataTable(sql);
                    if (dt_direct_related.Rows.Count > 0)
                    {
                        int Outid = idrelated; //CDataConverter.ConvertToInt(dt.Rows[0]["id"].ToString());
                        string encrypted = Encryption.Encrypt(Outid.ToString());
                        lbl_letter.Text = dt_direct_related.Rows[0]["con"].ToString();
                        lbl_letter.NavigateUrl = "../mainform/ViewProjectOutbox.aspx?id=" + encrypted;
                    }

                }

                if (obj.Related_Type == 4)
                {
                    all = dt_direct_related.Rows[0]["con"].ToString();
                    string[] res = all.Split('-');
                    idrelated = CDataConverter.ConvertToInt(res[2].ToString());
                    lbl_Inbox_type.Text = "موضوع التأشيرة  :";

                    //string sql = "SELECT * from vw_inbox_minister_DateSubject ";
                    //sql += " where  ID='" + CDataConverter.ConvertToInt(obj.Related_Id.ToString()) + "' ";

                    //if (CDataConverter.ConvertToInt(Session_CS.Project_id.ToString()) > 0)
                    //{
                    //    sql += " AND Proj_id = " + int.Parse(Session_CS.Project_id.ToString());
                    //}
                    //DataTable dt = General_Helping.GetDataTable(sql);
                    if (dt_direct_related.Rows.Count > 0)
                    {
                        lbl_letter.Text = dt_direct_related.Rows[0]["con"].ToString();
                    }

                }



            }




            //if (obj.Org_Id.ToString() != "0")
            //{
            //    DataTable DT = new DataTable();
            //    DT = General_Helping.GetDataTable("SELECT  [Org_ID], [Org_Desc] FROM Organization WHERE Org_ID=" + obj.Org_Id);
            //    if (DT.Rows.Count != 0)
            //    {
            //        lblOrgName.Text = DT.Rows[0]["Org_Desc"].ToString();
            //    }

            //}
            //else
            //{
            //    DataTable DT = new DataTable();
            //    DT = General_Helping.GetDataTable("SELECT  [dept_ID], [Dept_name] FROM Departments WHERE dept_ID=" + obj.Dept_ID);
            //    if (DT.Rows.Count != 0)
            //    {
            //        lblOrgName.Text = DT.Rows[0]["Dept_name"].ToString();
            //    }
            //}
            DataTable dtorg = Outbox_DB.Outbox_getorg(id);

            lblOrgName.Text = dtorg.Rows[0]["Org_Desc"].ToString();

        }
        catch
        { }
    }
    public string Get_Visa_Emp_Dept(object obj)
    {
        string Visa_Id = obj.ToString();
        string dept_name = "";
        DataTable DT = new DataTable();

        DT = General_Helping.GetDataTable("SELECT distinct Departments.Dept_name FROM Departments INNER JOIN EMPLOYEE on EMPLOYEE.Dept_Dept_id=Departments.Dept_id INNER JOIN  Outbox_Visa_Emp ON Outbox_Visa_Emp.Emp_ID = EMPLOYEE.PMP_ID WHERE Outbox_Visa_Emp.Visa_Id  =" + Visa_Id);

        foreach (DataRow dr in DT.Rows)
        {
            dept_name += dr["Dept_name"].ToString() + ",";
        }
        return dept_name;

    }


    protected void btn_Visa_Follow_Click(object sender, EventArgs e)
    {
        if (CDataConverter.ConvertToInt(hidden_Id.Value) > 0)
        {
            Outbox_Visa_Follows_DT obj = Outbox_Visa_Follows_DB.SelectByID(CDataConverter.ConvertToInt(hidden_Follow_ID.Value));
            obj.Follow_ID = CDataConverter.ConvertToInt(hidden_Follow_ID.Value);
            obj.Outbox_ID = CDataConverter.ConvertToInt(hidden_Id.Value);
            obj.Descrption = txt_Descrption.Text;
            obj.Date = txt_Follow_Date.Text;
            obj.time_follow = txt_time_follow.Text;
            obj.entery_pmp_id = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
            obj.Visa_Emp_id = CDataConverter.ConvertToInt(ddl_Visa_Emp_id.SelectedValue);
            obj.Follow_ID = Outbox_Visa_Follows_DB.Save(obj);

            //DataTable dt_Inbox_Visa = General_Helping.GetDataTable("select * from Inbox_Track_Emp where inbox_id =" + hidden_Id.Value);
            //foreach (DataRow item in dt_Inbox_Visa.Rows)
            //{
            //    Inbox_DB.update_inbox_Track_Emp(hidden_Id.Value, item["Emp_ID"].ToString(), 4, 1);
            //}

            if (FileUpload_Visa_Follow.HasFile)
            {
                string DocName = FileUpload_Visa_Follow.FileName;
                int dotindex = DocName.LastIndexOf(".");
                string type = DocName.Substring(dotindex, DocName.Length - dotindex);

                Stream myStream;
                int fileLen;
                StringBuilder displayString = new StringBuilder();
                fileLen = FileUpload_Visa_Follow.PostedFile.ContentLength;
                Byte[] Input = new Byte[fileLen];
                myStream = FileUpload_Visa_Follow.FileContent;
                myStream.Read(Input, 0, fileLen);
                SqlCommand cmd = new SqlCommand();

                SqlConnection con = new SqlConnection();
              
                SqlConnection con_local = new SqlConnection();
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                con_local = new SqlConnection(Session_CS.local_connectionstring);
               
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = " update Outbox_Visa_Follows set File_data =@File_data ,File_name=@File_name,File_ext=@File_ext where Follow_ID =@Follow_ID";
                cmd.Parameters.Add("@File_data", SqlDbType.VarBinary);
                cmd.Parameters.Add("@File_name", SqlDbType.NVarChar);
                cmd.Parameters.Add("@File_ext", SqlDbType.NVarChar);
                cmd.Parameters.Add("@Follow_ID", SqlDbType.BigInt);

               // cmd.Parameters["@File_data"].Value = Input;
                cmd.Parameters["@File_name"].Value = DocName;
                cmd.Parameters["@File_ext"].Value = type;
                cmd.Parameters["@Follow_ID"].Value = obj.Follow_ID;


                if (string.IsNullOrEmpty(Session_CS.local_connectionstring))
                {
                    cmd.Connection = con;
                    cmd.Parameters["@File_data"].Value = Input;
                    con.Open();
                    cmd.ExecuteScalar();
                    con.Close();

                }
                else
                {

                    cmd.Connection = con;
                    cmd.Parameters["@File_data"].Value = DBNull.Value;
                    con.Open();
                    cmd.ExecuteScalar();
                    con.Close();
                    try
                    {
                        cmd.Connection = con_local;
                        cmd.Parameters["@File_data"].Value = Input;

                        con_local.Open();
                        cmd.ExecuteScalar();
                        con_local.Close();


                    }
                    catch
                    {
                        // can't connect to sql local, we should show message here
                    }
                }

                //con.Open();
                //cmd.ExecuteScalar();
                //con.Close();



            }
            ///////////// change have follow = 1 , All_visa_sent=0 /////////////////////////////////////////////

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            //DataTable DT = new DataTable();
            //DT = General_Helping.GetDataTable("select * from Inbox_Track_Manager where inbox_id = " + hidden_Id.Value);
            //if (DT.Rows.Count > 0)
            //{
            //    conn.Open();
            //    string sql = "update Inbox_Track_Manager set Have_Follow=1,All_visa_sent=0 where inbox_id =" + hidden_Id.Value;
            //    SqlCommand cmd = new SqlCommand(sql, conn);
            //    cmd.ExecuteNonQuery();
            //    conn.Close();

            //}
            int id = CDataConverter.ConvertToInt(hidden_Id.Value);
            if (CDataConverter.ConvertToInt(Session_CS.parent_id.ToString()) == 0)
            {
                string sql = "SELECT dbo.Outbox_Visa_Emp.Sender_ID, dbo.Outbox_Visa_Emp.Emp_ID FROM dbo.Outbox_Visa INNER JOIN dbo.Outbox_Visa_Emp ON dbo.Outbox_Visa.Visa_Id = dbo.Outbox_Visa_Emp.Visa_Id where dbo.Outbox_Visa.Outbox_ID = " + id + "AND dbo.Outbox_Visa_Emp.Emp_ID = " + CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
                DataTable dt = General_Helping.GetDataTable(sql);
                int sender1 = CDataConverter.ConvertToInt(dt.Rows[0]["Sender_id"].ToString());


                string both_see = " SELECT     Outbox_Visa_Emp.Visa_Emp_ID, Outbox_Visa_Emp.Visa_Id, Outbox_Visa_Emp.Emp_ID, Outbox_Visa_Emp.Sender_ID, Outbox_Visa.Outbox_ID FROM         Outbox_Visa_Emp LEFT OUTER JOIN                       Outbox_Visa ON Outbox_Visa_Emp.Visa_Id = Outbox_Visa.Visa_Id ";
                both_see += " where Sender_id=" + sender1 + " and Outbox_ID =" + id;
                DataTable dt_both_see = General_Helping.GetDataTable(both_see);
                for (int i = 0; i < dt_both_see.Rows.Count; i++)
                {
                    if (CDataConverter.ConvertToInt(dt_both_see.Rows[i]["Emp_ID"].ToString()) != CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()))
                    {
                        string sql_exist = "select * from Outbox_follow_emp where Outbox_id = " + id + " AND Outbox_follow_emp.pmp_id = " + CDataConverter.ConvertToInt(dt_both_see.Rows[i]["Emp_ID"].ToString());
                        DataTable dt_exist = General_Helping.GetDataTable(sql_exist);
                        if (dt_exist.Rows.Count > 0)
                        {
                            General_Helping.ExcuteQuery(" update Outbox_follow_emp set Have_follow = 1 where (Outbox_id = " + id + "  AND Outbox_follow_emp.pmp_id = " + CDataConverter.ConvertToInt(dt_both_see.Rows[i]["Emp_ID"].ToString()) + ")");

                        }
                        else
                        {
                            string Sql_insert = "insert into Outbox_follow_emp (pmp_id , Have_follow ,Outbox_id) values ( " + CDataConverter.ConvertToInt(dt_both_see.Rows[i]["Emp_ID"].ToString()) + ",1," + id + ")";
                            General_Helping.ExcuteQuery(Sql_insert);
                        }
                    }

                }
                string sql_sender_exist = "select * from Outbox_follow_emp where Outbox_id = " + id + " AND Outbox_follow_emp.pmp_id = " + sender1;
                DataTable dt_sender_exist = General_Helping.GetDataTable(sql_sender_exist);
                if (dt_sender_exist.Rows.Count > 0)
                {
                    General_Helping.ExcuteQuery(" update Outbox_follow_emp set Have_follow = 1 where (Outbox_id = " + id + " AND Outbox_follow_emp.pmp_id = " + sender1 + ")");
                }
                else
                {
                    string Sql_insert_parent = "insert into Outbox_follow_emp (pmp_id , Have_follow ,Outbox_id) values ( " + CDataConverter.ConvertToInt(dt.Rows[0]["Sender_ID"].ToString()) + ",1," + id + ")";
                    General_Helping.ExcuteQuery(Sql_insert_parent);
                }

            }

            if (Smart_Search_proj.SelectedValue != "")
            {

                conn.Open();
                string sql = "update Outbox set proj_id = " + Smart_Search_proj.SelectedValue;
                sql += " where ID  =" + hidden_Id.Value;
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();

            }
            Clear_visa_Follow();

            Fil_Grid_Visa_Follow();
        }
        else
        {
           // Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('يجب إدخال بيانات الخطاب أولا')</script>");

            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('يجب إدخال بيانات الخطاب أولا');", true);


        }

    }
    private void Clear_visa_Follow()
    {
        hidden_Follow_ID.Value =
        txt_Descrption.Text =
        txt_Follow_Date.Text = "";
        ddl_Visa_Emp_id.SelectedIndex = 0;
    }
    private void Fil_Grid_Visa_Follow()
    {
        DataTable DT = new DataTable();
        string Sql = "SELECT Outbox_Visa_Follows.Follow_ID,Outbox_Visa_Follows.File_name,"+
        " Outbox_Visa_Follows.time_follow,Outbox_Visa_Follows.Outbox_ID, Outbox_Visa_Follows.Descrption, "+
        " Outbox_Visa_Follows.Date, Outbox_Visa_Follows.Visa_Emp_id, EMPLOYEE.pmp_name " +
        " FROM Outbox_Visa_Follows INNER JOIN EMPLOYEE ON Outbox_Visa_Follows.Visa_Emp_id = EMPLOYEE.PMP_ID "+
        " where Outbox_ID =" + hidden_Id.Value;
        DT = General_Helping.GetDataTable(Sql);

        GridView_Visa_Follow.DataSource = DT;
        GridView_Visa_Follow.DataBind();
    }
    protected void GridView_Visa_Follow_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "EditItem")
        {

            Outbox_Visa_Follows_DT obj = Outbox_Visa_Follows_DB.SelectByID(CDataConverter.ConvertToInt(e.CommandArgument));
            if (obj.Follow_ID > 0)
            {
                hidden_Follow_ID.Value = obj.Follow_ID.ToString();
                txt_Descrption.Text = obj.Descrption;
                txt_Follow_Date.Text = obj.Date;
                ddl_Visa_Emp_id.SelectedValue = obj.Visa_Emp_id.ToString();

            }
        }

        if (e.CommandName == "RemoveItem")
        {
            Inbox_Visa_Follows_DB.Delete(CDataConverter.ConvertToInt(e.CommandArgument));

           // Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم الحذف بنجاح')</script>");

            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('لقد تم الحذف بنجاح');", true);



            Fil_Grid_Visa_Follow();
        }
    }
    private void Fil_Emp_Visa_Follow()
    {
        int grp = CDataConverter.ConvertToInt(Session_CS.group_id.ToString());
        if (CDataConverter.ConvertToInt(hidden_Id.Value) > 0)
        {
            DataTable DT = new DataTable();
            string sql = " SELECT  distinct   EMPLOYEE.PMP_ID, EMPLOYEE.pmp_name, Outbox_Visa.Outbox_ID ";
            sql += " FROM Outbox_Visa_Emp INNER JOIN EMPLOYEE ON Outbox_Visa_Emp.Emp_ID = EMPLOYEE.PMP_ID INNER JOIN Outbox_Visa ON Outbox_Visa_Emp.Visa_Id = Outbox_Visa.Visa_Id INNER JOIN Outbox ON Outbox_Visa.Outbox_ID = Outbox.ID ";
            sql += " where Outbox_ID=" + hidden_Id.Value;
            if (grp!=9)
            {
                sql += " AND EMPLOYEE.PMP_ID = " + CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());    
            }
            

            DT = General_Helping.GetDataTable(sql);
            //Obj_General_Helping.SmartBindDDL(ddl_Visa_Emp_id, DT, "PMP_ID", "pmp_name",);
            ddl_Visa_Emp_id.DataSource = DT;
            ddl_Visa_Emp_id.DataTextField = "pmp_name";
            ddl_Visa_Emp_id.DataValueField = "pmp_id";

            ddl_Visa_Emp_id.DataBind();

        }
    }

    protected void GrdView_Documents_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //if (e.CommandName == "EditItem")
        //{
        //    Inbox_OutBox_Files_DT obj = Inbox_OutBox_Files_DB.SelectByID(CDataConverter.ConvertToInt(e.CommandArgument));
        //    if (obj.Inbox_OutBox_File_ID > 0)
        //    {
        //        hidden_Inbox_OutBox_File_ID.Value = obj.Inbox_OutBox_File_ID.ToString();
        //        txtFileName.Text = obj.File_name;
        //        //ddl_Original_Or_Attached.SelectedValue = obj.Original_Or_Attached.ToString();
        //    }

    }

    private void Fil_Grid_Documents()
    {
        DataTable DT = new DataTable();
        DT = General_Helping.GetDataTable("select * from Inbox_OutBox_Files where Inbox_Or_Outbox = 2 and Inbox_Outbox_ID=" + id);

        GrdView_Documents.DataSource = DT;
        GrdView_Documents.DataBind();
    }


    protected void btn_print_report_Click(object sender, EventArgs e)
    {
        int found_id = CDataConverter.ConvertToInt(Session_CS.foundation_id.ToString());
        string user = Session_CS.pmp_name.ToString();
        if (Request.QueryString["id"] != null)
        {
            ReportDocument rd = new ReportDocument();
            string s = Server.MapPath("../Reports/InboxOutboxReport/outbox_Data.rpt");
            rd.Load(s);
            Reports.Load_Report(rd);
            rd.SetParameterValue("@out_ID", CDataConverter.ConvertToInt(hidden_Id.Value));
            rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
            rd.SetParameterValue("@user", user, "footerRep.rpt");
            rd.SetParameterValue("@found_id", found_id, "Logo_Header_pic_dynamic.rpt");

            if (rd.Rows.Count == 0)
            {
               // ShowAlertMessage("!!!!!هذا التقرير لا يوجد به بيانات للعرض !!!!");

                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('!!!!!هذا التقرير لا يوجد به بيانات للعرض !!!!');", true);

                return;
            }
            else
            {
                rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report");
            }
        }



    }
    public void update_Outbox_Track_Emp(string Outbox_id, int Emp_ID, int Outbox_Status, int Type)
    {
        ////DataTable DT = General_Helping.GetDataTable("select * from Outbox_Track_Emp where Outbox_id = " + Outbox_id + " and Emp_ID =" + Emp_ID);
        var Outbox_Track_Emps = outboxDBContext.Outbox_Track_Emp.Where(x => x.Outbox_id == CDataConverter.ConvertToInt(Outbox_id) && x.Emp_ID == Emp_ID);
        if (Outbox_Track_Emps.Count() > 0)
        {

            ////string sql = "update Outbox_Track_Emp set Outbox_Status= " + Outbox_Status + " where Outbox_id =" + Outbox_id + " and Emp_ID =" + Emp_ID;
            ////General_Helping.ExcuteQuery(sql);
            foreach (var Outbox_Track_Emp in Outbox_Track_Emps)
            {
                Outbox_Track_Emp.Outbox_Status = Outbox_Status;
            }
        }
        else
        {
            ////string sql = "insert into Outbox_Track_Emp (Outbox_id,Emp_ID,Outbox_Status,Type_Track_emp) values ( " + Outbox_id + "," + Emp_ID + "," + Outbox_Status + "," + "1" + ")";
            ////General_Helping.ExcuteQuery(sql);
            Outbox_Track_Emp OutboxTrackEmp = new Outbox_Track_Emp
            {
                Outbox_id = CDataConverter.ConvertToInt(Outbox_id),
                Emp_ID = Emp_ID,
                Outbox_Status = Outbox_Status,
                Type_Track_emp = 1

            };
            outboxDBContext.Outbox_Track_Emp.Add(OutboxTrackEmp);

        }
        outboxDBContext.SaveChanges();

    }
    protected void btn_close_Outbox_Click(object sender, EventArgs e)
    {

        ///////////// change status = 3  /////////////////////////////////////////////
        int id = CDataConverter.ConvertToInt(Request["id"]);
        DataTable DT = new DataTable();
        DT = General_Helping.GetDataTable("select * from Outbox_Track_Manager where Outbox_id = " + hidden_Id.Value);
        if (DT.Rows.Count > 0)
        {
            string sql = "update Outbox_Track_Manager set Have_Follow=0,All_visa_sent=0,Have_Visa=0,status=3 where Outbox_id =" + hidden_Id.Value;
            General_Helping.ExcuteQuery(sql);

        }
        DataTable dt_Outbox_Visa = General_Helping.GetDataTable("select * from Outbox_Track_Emp where Outbox_id =" + hidden_Id.Value);
        foreach (DataRow item in dt_Outbox_Visa.Rows)
        {
            update_Outbox_Track_Emp(hidden_Id.Value, CDataConverter.ConvertToInt(item["Emp_ID"].ToString()), 3, 1);
        }

        Outbox_Visa_Follows_DT obj = Outbox_Visa_Follows_DB.SelectByID(CDataConverter.ConvertToInt(hidden_Follow_ID.Value));
        obj.Follow_ID = CDataConverter.ConvertToInt(hidden_Follow_ID.Value);
        obj.Outbox_ID = CDataConverter.ConvertToInt(hidden_Id.Value);
        obj.Descrption = "تم إغلاق الموضوع";
        string date = CDataConverter.ConvertDateTimeToFormatdmy(CDataConverter.ConvertDateTimeNowRtnDt());
        obj.Date = date;
        obj.time_follow = CDataConverter.ConvertTimeNowRtnLongTimeFormat();
        obj.entery_pmp_id = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
        obj.Visa_Emp_id = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
        obj.Follow_ID = Outbox_Visa_Follows_DB.Save(obj);
        Fil_Grid_Visa_Follow();
        ///////////////////////////////////////////////////////////////// when dr hesham close Outbox update all have follow in Outbox follow emp to be zero
        General_Helping.ExcuteQuery("update Outbox_follow_emp set Have_follow = 0 where Outbox_id = " + id);
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('تم إغلاق الموضوع بنجاح' )</script>");

        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('تم إغلاق الموضوع بنجاح');", true);



    }
    protected void btn_end_late_Click(object sender, EventArgs e)
    {

        ///////////// change status = 3  /////////////////////////////////////////////
        int id = Convert.ToInt16(hidden_Id.Value);
        DataTable DT = new DataTable();
        DT = General_Helping.GetDataTable("select * from Outbox where ID = " + id);
        if (DT.Rows.Count > 0)
        {
            string sql = "update Outbox set finished=1 where ID =" + id;
            General_Helping.ExcuteQuery(sql);

        }
        //DataTable dt_Inbox_Visa = General_Helping.GetDataTable("select * from Inbox_Track_Emp where inbox_id =" + hidden_Id.Value);
        //foreach (DataRow item in dt_Inbox_Visa.Rows)
        //{
        //    Inbox_DB.update_inbox_Track_Emp(hidden_Id.Value, item["Emp_ID"].ToString(), 3, 1);
        //}

        Outbox_Visa_Follows_DT obj = Outbox_Visa_Follows_DB.SelectByID(CDataConverter.ConvertToInt(hidden_Follow_ID.Value));
        obj.Follow_ID = CDataConverter.ConvertToInt(hidden_Follow_ID.Value);
        obj.Outbox_ID = CDataConverter.ConvertToInt(hidden_Id.Value);
        obj.Descrption = "تم انهاء تأخير الموضوع";
        string date = CDataConverter.ConvertDateTimeToFormatdmy(CDataConverter.ConvertDateTimeNowRtnDt());
        obj.Date = date;
        obj.time_follow = CDataConverter.ConvertTimeNowRtnLongTimeFormat();
        obj.entery_pmp_id = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
        obj.Visa_Emp_id = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
        obj.Follow_ID = Outbox_Visa_Follows_DB.Save(obj);
        Fil_Grid_Visa_Follow();
        ///////////////////////////////////////////////////////////////// when dr hesham close inbox update all have follow in inbox follow emp to be zero
        //General_Helping.ExcuteQuery("update inbox_follow_emp set Have_follow = 0 where inbox_id = " + id);
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////

      //  Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('تم انهاء تأخير الموضوع بنجاح' )</script>");

        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('تم انهاء تأخير الموضوع بنجاح');", true);



    }
    //protected void btn_mzkra_Click(object sender, EventArgs e)
    //{
    //    string File_Name = Server.MapPath("~//Uploads/نموذج مذكرة.doc");
    //    FileStream fs = new FileStream(File_Name, FileMode.Open, FileAccess.Read);

    //    byte[] bytes = new byte[fs.Length];

    //    fs.Read(bytes, 0, System.Convert.ToInt32(fs.Length));

    //    fs.Close();
    //    Response.ContentType = "application/x-unknown";
    //    string File_Name_Show = "";
    //    File_Name_Show = "نموذج مذكرة.doc";
    //    Response.AddHeader("Content-Disposition", "attachment; filename=" + Server.UrlPathEncode(File_Name_Show));
    //    Response.BinaryWrite(bytes);
    //    Response.Flush();
    //    Response.Close();
    //}
    protected void btn_Ltr_Click(object sender, EventArgs e)
    {
        string File_Name = Server.MapPath("~//Uploads/نموذج خطاب.doc");
        FileStream fs = new FileStream(File_Name, FileMode.Open, FileAccess.Read);

        byte[] bytes = new byte[fs.Length];

        fs.Read(bytes, 0, System.Convert.ToInt32(fs.Length));

        fs.Close();
        Response.ContentType = "application/x-unknown";
        string File_Name_Show = "";
        File_Name_Show = "نموذج خطاب.doc";
        Response.AddHeader("Content-Disposition", "attachment; filename=" + Server.UrlPathEncode(File_Name_Show));
        Response.BinaryWrite(bytes);
        Response.Flush();
        Response.Close();
    }

    public string IpAddress()
    {
        string name = "";
        string ip = "";
        try
        {
            name = System.Net.Dns.GetHostName();
            ip = System.Net.Dns.GetHostAddresses(name).GetValue(1).ToString();
            return ip;
        }
        catch
        {
            name = System.Net.Dns.GetHostName();
            ip = System.Net.Dns.GetHostAddresses(name).GetValue(0).ToString();
            return ip;
        }
    }

    public  void ShowAlertMessage(string error)
    {

        Page page = HttpContext.Current.Handler as Page;
        if (page != null)
        {
            error = error.Replace("'", "\'");
           // ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('" + error + "');", true);

            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('" + error + "');", true);

        }
    }

    

    protected void btn_Visa_Click(object sender, EventArgs e)
    {
        int id = CDataConverter.ConvertToInt(hidden_Id.Value);
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        DataTable DT = new DataTable();
        DT = General_Helping.GetDataTable("select * from Outbox_Track_Manager where Outbox_id = " + id);
        if (DT.Rows.Count > 0)
        {
            conn.Open();
            //Outbox_Visa_Follows_DT obj_follow = Outbox_Visa_Follows_DB.SelectByID(CDataConverter.ConvertToInt(hidden_Follow_ID.Value));
            //obj_follow.Follow_ID = CDataConverter.ConvertToInt(hidden_Follow_ID.Value);
            //obj_follow.Outbox_ID = CDataConverter.ConvertToInt(hidden_Id.Value);
            //obj_follow.Descrption = txt_Visa_Desc.Text;
            //string date = CDataConverter.ConvertDateTimeToFormatdmy(CDataConverter.ConvertDateTimeNowRtnDt());
            //obj_follow.Date = date;
            //obj_follow.time_follow = CDataConverter.ConvertTimeNowRtnLongTimeFormat(); 
            //obj_follow.entery_pmp_id = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
            //obj_follow.Visa_Emp_id = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
            //obj_follow.Follow_ID = Outbox_Visa_Follows_DB.Save(obj_follow);

            Fil_Grid_Visa_Follow();

            if (CDataConverter.ConvertToInt(Session_CS.parent_id.ToString()) > 0)
            {
                Update_Have_Visa_all_emp(id);
            }

            //lnkBtnUnderStudy.Visible = false;
            Save_Visa(id);
            Save_trackmanager(id);
           // Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('تم حفظ التاشيرة بنجاح')</script>");

            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('تم حفظ التاشيرة بنجاح');", true);

            clear_Visa_cntrl();
            Fil_Grid_Visa();
            lst_emp.Items.Clear();
        }
        else
        {
            //Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لا يوجد بيانات للخطاب')</script>");

            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('لا يوجد بيانات للخطاب');", true);

        }
    }
    private void Save_trackmanager(int id)
    {
        DataTable dt = General_Helping.GetDataTable("select * from parent_employee where Type=2 and pmp_id= "+Session_CS.pmp_id);
        if (dt.Rows.Count > 0)
        {

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                foreach (ListItem item in lst_emp.Items)
                {
                    if (CDataConverter.ConvertToInt(item.Value) == CDataConverter.ConvertToInt(dt.Rows[i]["parent_pmp_id"].ToString()))
                    {
                        Outbox_Track_Manager_DT obj = new Outbox_Track_Manager_DT();
                        obj.Outbox_id = CDataConverter.ConvertToInt(hidden_Id.Value);
                        obj.Have_Visa = 0;
                        obj.Have_Follow = 0;
                        obj.IS_New_Mail = 1;
                        obj.status = 1;
                        obj.IS_Old_Mail = 0;
                        obj.Visa_Desc = "";
                        obj.Type_Track = 1;
                        obj.pmp_id = int.Parse(Session_CS.pmp_id.ToString());
                        obj.parent_pmp_id = CDataConverter.ConvertToInt(item.Value);
                        //obj.parent_pmp_id = CDataConverter.ConvertToInt(Session_CS.parent_id.ToString());
                        obj.All_visa_sent = 0;
                        obj.Outbox_id = Outbox_Track_Manager_DB.Save(obj);
                    }

                }
            }


        }
    }
    private void Update_Have_Visa_all_emp(int Outbox_ID)
    {
        string sql = "update Outbox_Track_Manager set status=0,Have_Follow=0,Have_visa=1 , ";
        sql += "Visa_Desc = '" + txt_Visa_Desc.Text + "'";
        sql += " where Outbox_id =" + Outbox_ID;
        General_Helping.ExcuteQuery(sql);

        string sql_all_User = "update Outbox_Track_Emp set Outbox_Status =2 where Outbox_id=" + Outbox_ID;
        General_Helping.ExcuteQuery(sql_all_User);
    }

    private void clear_Visa_cntrl()
    {
        hidden_Visa_Id.Value = "";

    }

    private void Save_Visa(int id)
    {
          DateTime visainitial = CDataConverter.ConvertToDate(txt_Visa_date.Text);
                DateTime visalastdate = CDataConverter.ConvertToDate(txt_Dead_Line_DT.Text);
                if (visalastdate >= visainitial)
                {
                    Outbox_Visa_DT obj = new Outbox_Visa_DT();
                    obj.Visa_Id = CDataConverter.ConvertToInt(hidden_Visa_Id.Value);
                    obj.Outbox_ID = id;
                    obj.Important_Degree = CDataConverter.ConvertToInt(ddl_Important_Degree.SelectedValue);
                    obj.Important_Degree_Txt = txt_Important_Degree_Txt.Text;
                    if (string.IsNullOrEmpty(obj.Important_Degree_Txt))
                        obj.Important_Degree_Txt = ddl_Important_Degree.SelectedItem.Text;
                    DateTime str = CDataConverter.ConvertDateTimeNowRtnDt();
                    obj.Visa_date = CDataConverter.ConvertDateTimeToFormatdmy(str);
                    //obj.Important_Degree = 1;
                    obj.Dept_ID = CDataConverter.ConvertToInt(Smart_Search_dept.SelectedValue);
                    obj.Visa_Desc = txt_Visa_Desc.Text;
                    obj.Dead_Line_DT = txt_Dead_Line_DT.Text;
                    obj.Visa_Goal_ID = CDataConverter.ConvertToInt(ddl_Visa_Goal_ID.SelectedValue);
                    obj.Emp_ID = CDataConverter.ConvertToInt(Session_CS.pmp_id);
                    obj.Visa_Id = Outbox_Visa_DB.Save(obj);
                    if (FileUpload_Visa.HasFile)
                    {
                        SqlCommand cmd = new SqlCommand();
                        SqlConnection con = new SqlConnection();

                        SqlConnection con_local = new SqlConnection();
                        con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                        con_local = new SqlConnection(Session_CS.local_connectionstring);

                        string DocName = FileUpload_Visa.FileName;
                        string Doc_Name = System.IO.Path.GetFileNameWithoutExtension(FileUpload_Visa.FileName);
                        int dotindex = DocName.LastIndexOf(".");
                        string type = DocName.Substring(dotindex, DocName.Length - dotindex);

                        Stream myStream;
                        int fileLen;
                        StringBuilder displayString = new StringBuilder();
                        fileLen = FileUpload_Visa.PostedFile.ContentLength;
                        Byte[] Input = new Byte[fileLen];
                        myStream = FileUpload_Visa.FileContent;
                        myStream.Read(Input, 0, fileLen);
                        cmd.Parameters.Add("@File_data", SqlDbType.VarBinary);
                        cmd.Parameters.Add("@File_name", SqlDbType.NVarChar);
                        cmd.Parameters.Add("@File_ext", SqlDbType.NVarChar);
                        cmd.Parameters.Add("@visa_ID", SqlDbType.BigInt);

                        //cmd.Parameters["@File_data"].Value = Input;
                        cmd.Parameters["@File_name"].Value = Doc_Name;
                        cmd.Parameters["@File_ext"].Value = type;
                        cmd.Parameters["@visa_ID"].Value = obj.Visa_Id;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = " update Outbox_Visa set File_data =@File_data ,File_name=@File_name,File_ext=@File_ext where visa_ID =@visa_ID";

                        if (string.IsNullOrEmpty(Session_CS.local_connectionstring))
                        {
                            cmd.Connection = con;
                            cmd.Parameters["@File_data"].Value = Input;
                            con.Open();
                            cmd.ExecuteScalar();
                            con.Close();

                        }
                        else
                        {

                            cmd.Connection = con;
                            cmd.Parameters["@File_data"].Value = DBNull.Value;
                            con.Open();
                            cmd.ExecuteScalar();
                            con.Close();
                            try
                            {
                                cmd.Connection = con_local;
                                cmd.Parameters["@File_data"].Value = Input;

                                con_local.Open();
                                cmd.ExecuteScalar();
                                con_local.Close();


                            }
                            catch
                            {
                                // can't connect to sql local, we should show message here
                            }
                        }


                    }
                    Save_inox_Visa(obj);
                }
                else
                {
                    //Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('أخر تاريخ يجب ان يكون اكبر من تاريخ التأشيره')</script>");
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('أخر تاريخ يجب ان يكون اكبر من تاريخ التأشيره');", true);

                }
        //if (CDataConverter.ConvertToInt(Session_CS.parent_id.ToString()) <= 0)
        //    Send_Visa(obj.Visa_Id.ToString());

    }

    private void Save_inox_Visa(Outbox_Visa_DT obj)
    {

        string Sql_Delete = "delete from Outbox_Visa_Emp where Visa_Id =" + obj.Visa_Id;
        General_Helping.ExcuteQuery(Sql_Delete);
        string Sql_insert = "";
        //foreach (ListItem item in chklst_Visa_Emp.Items)
        //{
        //    if (item.Selected)
        //    {
        //        if (CDataConverter.ConvertToInt(Session_CS.group_id.ToString()) == 2)
        //        {
        //            Sql_insert = "insert into Inbox_Visa_Emp ( Visa_Id , Emp_ID ,Sender_id) values ( " + obj.Visa_Id + "," + item.Value + ",57 " + ")";
        //        }
        //        else
        //        {
        //            Sql_insert = "insert into Inbox_Visa_Emp ( Visa_Id , Emp_ID ,Sender_id) values ( " + obj.Visa_Id + "," + item.Value + "," + CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()) + ")";
        //        }

        //        General_Helping.ExcuteQuery(Sql_insert);

        //        item.Selected = false;
        //    }

        //}

        foreach (ListItem item in lst_emp.Items)
        {

            DataTable dt = General_Helping.GetDataTable("select * from parent_employee where pmp_id = " + CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()));
            if (dt.Rows.Count > 0)
            {

                Sql_insert = "insert into Outbox_Visa_Emp ( Visa_Id , Emp_ID ,Sender_id) values ( " + obj.Visa_Id + "," + item.Value + "," + CDataConverter.ConvertToInt(dt.Rows[0]["parent_pmp_id"].ToString()) + ")";

            }
            else
            {

                Sql_insert = "insert into Outbox_Visa_Emp ( Visa_Id , Emp_ID ,Sender_id) values ( " + obj.Visa_Id + "," + item.Value + "," + CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()) + ")";
            }


            General_Helping.ExcuteQuery(Sql_insert);

            //item.Selected = false;


        }




    }
    //private void Save_inox_Visa(Inbox_Visa_DT obj)
    //{

    //    string Sql_Delete = "delete from Inbox_Visa_Emp where Visa_Id =" + obj.Visa_Id;
    //    General_Helping.ExcuteQuery(Sql_Delete);
    //    foreach (ListItem item in chklst_Visa_Emp.Items)
    //    {
    //        if (item.Selected)
    //        {

    //            string Sql_insert = "insert into Inbox_Visa_Emp ( Visa_Id , Emp_ID ,Sender_id) values ( " + obj.Visa_Id + "," + item.Value + "," + CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()) + ")";
    //            General_Helping.ExcuteQuery(Sql_insert);
    //            item.Selected = false;
    //        }

    //    }
    //}

    //protected void lnkBtnUnderStudy_Click(object sender, EventArgs e)
    //{
    //    int id = Convert.ToInt16(Request["id"]);
    //    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
    //    DataTable DT = new DataTable();
    //    DT = General_Helping.GetDataTable("select * from Inbox_Track_Manager where inbox_id = " + id);
    //    if (DT.Rows.Count > 0)
    //    {
    //        conn.Open();
    //        string sql = "update Inbox_Track_Manager set status=2 where inbox_id =" + id;
    //        SqlCommand cmd = new SqlCommand(sql, conn);
    //        cmd.ExecuteNonQuery();
    //        conn.Close();
    //        DataTable dt_get_group_id = General_Helping.GetDataTable("select group_id from employee where pmp_id = " + CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()));
    //        int group = CDataConverter.ConvertToInt(dt_get_group_id.Rows[0]["group_id"].ToString());
    //        if (group == 2)
    //        {
    //            Response.Redirect("~\\WebForms2");
    //        }
    //        else if (group == 3)
    //        {
    //            Response.Redirect("~\\WebForms");
    //        }


    //    }
    //}

    public string Get_Type(object obj)
    {
        string str = obj.ToString();
        if (str == "1")
            return "وثيقة أصلية";
        else if (str == "2")
            return "مرفقات";
        else return "وثيقة";
    }
    public string Get_Type_Visa(object obj)
    {
        string str = obj.ToString();
        if (str == "1")
            return "هام";
        else if (str == "2")
            return "عاجل";
        else if (str == "3")
            return "عادى";
        else return "";
    }
    public string Get_Visa_Emp(object obj)
    {
        string visa_ID = obj.ToString();
        string emp_name = "";
        DataTable DT = new DataTable();
        DT = General_Helping.GetDataTable("SELECT EMPLOYEE.pmp_name FROM Outbox_Visa_Emp INNER JOIN EMPLOYEE ON Outbox_Visa_Emp.Emp_ID = EMPLOYEE.PMP_ID WHERE Outbox_Visa_Emp.Visa_Id  =" + visa_ID);
        foreach (DataRow dr in DT.Rows)
        {
            emp_name += dr["pmp_name"].ToString() + ",";
        }

        return emp_name;

    }

    private void Fil_Grid_Visa()
    {
        DataTable DT = new DataTable();
        DT = General_Helping.GetDataTable("select * from Outbox_Visa where Outbox_ID=" + hidden_Id.Value);

        GridView_Visa.DataSource = DT;
        GridView_Visa.DataBind();
        DataTable dt = General_Helping.GetDataTable("select parent_pmp_id,pmp_id from parent_employee where pmp_id = " + CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()) + "or parent_pmp_id = " + CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()));

        foreach (GridViewRow row in GridView_Visa.Rows)
        {
            CheckBox chk = (CheckBox)row.FindControl("chkSent");
            Label lbl_emp = (Label)row.FindControl("lbl_emp");
            if (chk.Checked == true || lbl_emp.Text != Session_CS.pmp_id.ToString())
            {
                ImageButton img = (ImageButton)row.FindControl("ImgBtnEdit");
                ImageButton img2 = (ImageButton)row.FindControl("ImgBtnDelete");
                ImageButton img3 = (ImageButton)row.FindControl("ImgBtnEdit123");
                img.Visible = false;
                img2.Visible = false;
                img3.Visible = false;
                //img.Visible = false;
                //img2.Visible = false;

            }

        }
        //if (dt.Rows.Count > 0)
        //{
        //    if (CDataConverter.ConvertToInt(dt.Rows[0]["parent_pmp_id"].ToString()) == CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()))
        //    {
        //        GridView_Visa.Columns[8].Visible = GridView_Visa.Columns[9].Visible = GridView_Visa.Columns[10].Visible = true;
        //    }
        //    else
        //    {
        //        GridView_Visa.Columns[8].Visible = GridView_Visa.Columns[9].Visible = GridView_Visa.Columns[10].Visible = false;
        //    }
        //}
        //else
        //{
        //    GridView_Visa.Columns[8].Visible = GridView_Visa.Columns[9].Visible = GridView_Visa.Columns[10].Visible = false;
        //}




    }
    private void Fil_Visa_Lstbox(int ID)
    {
        string sql = "SELECT dbo.EMPLOYEE.pmp_name, dbo.Outbox_Visa_Emp.Emp_ID, dbo.Outbox_Visa_Emp.Visa_Id FROM  dbo.EMPLOYEE INNER JOIN dbo.Outbox_Visa_Emp ON dbo.EMPLOYEE.PMP_ID = dbo.Outbox_Visa_Emp.Emp_ID where dbo.Outbox_Visa_Emp.Visa_Id = " + ID;
        DataTable dt = General_Helping.GetDataTable(sql);
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            ListItem obj = new ListItem(dt.Rows[i]["pmp_name"].ToString(), dt.Rows[i]["Emp_ID"].ToString());
            lst_emp.Items.Add(obj);


        }

    }
    protected void GridView_Visa_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "EditItem")
        {
            Fil_Visa_Control(CDataConverter.ConvertToInt(e.CommandArgument));
            Fil_Visa_Lst(CDataConverter.ConvertToInt(e.CommandArgument));
            Fil_Visa_Lstbox(CDataConverter.ConvertToInt(e.CommandArgument));

        }
        if (e.CommandName == "RemoveItem")
        {
            Outbox_Visa_DB.Delete(CDataConverter.ConvertToInt(e.CommandArgument));
           // Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم الحذف بنجاح')</script>");

            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('لقد تم الحذف بنجاح');", true);

            Fil_Grid_Visa();
            Fil_Emp_Visa_Follow();
        }
        if (e.CommandName == "SendItem")
        {
            string Visa_ID = e.CommandArgument.ToString();
         
           // Send_Visa(e.CommandArgument.ToString());
            string dept = Session_CS.dept.ToString();
            string name = "";
            string Succ_names = "", Failed_name = "";
            DataTable dt_Outbox_Visa = General_Helping.GetDataTable("select * from Outbox_Visa_Emp where Visa_Id =" + Visa_ID);
            foreach (DataRow item in dt_Outbox_Visa.Rows)
            {
                update_Outbox_Track_Emp(hidden_Id.Value, CDataConverter.ConvertToInt(item["Emp_ID"].ToString()), 1, 1);
                string sqlformail = "SELECT * from employee ";
                sqlformail += " where pmp_id= " + item["Emp_ID"].ToString();
                DataTable ds = General_Helping.GetDataTable(sqlformail);

                string mail = ds.Rows[0]["mail"].ToString();

                name = ds.Rows[0]["pmp_name"].ToString();


                MailMessage _Message = new MailMessage();
                string str_subj = "";
                if (txt_subject.Text.Length > 160)
                {
                    if (int.Parse(Session_CS.group_id.ToString()) == 3)
                    {
                        str_subj = txt_subject.Text.Substring(0, 160);
                    }
                    else
                        str_subj = txt_subject.Text.Substring(0, 130);


                }
                else
                {
                    str_subj = txt_subject.Text;
                }


                string str_witoutn = str_subj.Replace("\n", "");
                str_subj = str_witoutn.Replace("\r", "");


                if (int.Parse(Session_CS.group_id.ToString()) == 3)
                {

                    _Message.Subject = ("OUTIR" + " - " + str_subj + " - " + lblLetterDate.Text).ToString();
                }
                else
                {

                    _Message.Subject = ("نظام الادارة الالكترونية - المراسلات" + " - " + str_subj + " - " + lblLetterDate.Text).ToString();
                }



                bool flag = false;
                string file = "";
                byte[] files = new byte[0];
                MemoryStream ms = new MemoryStream();
                DataTable dt = General_Helping.GetDataTable("select * from Inbox_OutBox_Files where Inbox_Outbox_ID =" + hidden_Id.Value + " and Inbox_Or_Outbox =2 ");
                foreach (DataRow dr in dt.Rows)
                {

                    if (dr["File_data"] != DBNull.Value)
                    {

                        file = dr["File_name"].ToString() + dr["File_ext"].ToString();
                        files = (byte[])dr["File_data"];
                        ms = new MemoryStream(files);
                        _Message.Attachments.Add(new Attachment(ms, file));
                        flag = true;

                    }
                }



                string address2 = System.Web.HttpContext.Current.Request.Url.Authority.ToString();
                String encrypted_id = Encryption.Encrypt(hidden_Id.Value);
                _Message.IsBodyHtml = true;
                _Message.Body = "<html><body dir='rtl'><h3 > السيد - " + name + " </h3>";
                _Message.Body += " <h3 > " + " وصلكم صادر من " + dept + " بتاريخ " + txt_Visa_date.Text + " بخصوص  <br/>" + "<h3 style=" + "color:blue >" + txt_subject.Text + "</h3>" + " </h3>";
                _Message.Body += " <h3 > " + "  وتأشيرة  السيد المدير المختص أن :" + "<h3 style=" + "color:blue >" + txt_Visa_Desc.Text + "</h3>" + " </h3>";

                _Message.Body += " <h3 > ورابط الصادر هو  :<br/>";
                _Message.Body += " <h3 >http:" + "/" + "/" + address2 + "/MainForm/ViewProjectOutbox.aspx?id=" + encrypted_id + "&1=1 </h3>";

                if (flag)
                    _Message.Body += "<h3 >  " + " ومرفق الوثائق الخاصة بهذا الصادر</h3> ";



                _Message.Body += "<h3 > مع تحيات </h3> ";
                _Message.Body += "<h3 >   " + Session_CS.e_signature.ToString() + "  </h3> ";
                _Message.Body += "</body></html>";

                //////




                Outbox_Visa_DT obj = Outbox_Visa_DB.SelectByID(CDataConverter.ConvertToInt(Visa_ID));
                obj.mail_sent = 1;
                Outbox_Visa_DB.Save(obj);
                /////////////////////// update have visa = 0/////////////////////////////////////////////
                Update_Have_Visa(Visa_ID);


                try
                {

                    SendingMailthread_class.Sendingmail(_Message, _Message.Subject, _Message.Body, mail, ms, file, encrypted_id, "");


                    Succ_names += name + ",";


                }
                catch (Exception ex)
                {
                    Failed_name += name + ",";


                }
            }
            string message = Show_Alert(Succ_names, Failed_name, Visa_ID);
            Fil_Grid_Visa();
            ///////////////  to store that mohammed eid send visa to employee
            Outbox_Visa_Follows_DT obj_follow = Outbox_Visa_Follows_DB.SelectByID(CDataConverter.ConvertToInt(hidden_Follow_ID.Value));
            obj_follow.Follow_ID = CDataConverter.ConvertToInt(hidden_Follow_ID.Value);
            obj_follow.Outbox_ID = CDataConverter.ConvertToInt(hidden_Id.Value);

            GridViewRow row = (GridViewRow)((ImageButton)e.CommandSource).NamingContainer;
            int xx = row.RowIndex;

            if (row != null)
            {
                v_desc = GridView_Visa.Rows[xx].Cells[3].Text;

                Label download = (Label)row.FindControl("lbl_desc");

                v_desc = download.Text;


            }
            obj_follow.Descrption = message + " ونص التأشيرة:   " + v_desc;

            obj_follow.Descrption = message + "و تم الارسال بواسطة النظام";

            string date = CDataConverter.ConvertDateTimeToFormatdmy(CDataConverter.ConvertDateTimeNowRtnDt());
            obj_follow.Date = date;
            obj_follow.time_follow = CDataConverter.ConvertTimeNowRtnLongTimeFormat();
            obj_follow.entery_pmp_id = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());

            obj_follow.Visa_Emp_id = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
            obj_follow.Follow_ID = Outbox_Visa_Follows_DB.Save(obj_follow);
            Fil_Grid_Visa_Follow();

            GridView_Visa.Rows[xx].Cells[8].Visible = false;
            GridView_Visa.Rows[xx].Cells[9].Visible = false;
            GridView_Visa.Rows[xx].Cells[10].Visible = false;


            // Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('" + message + "')</script>");

            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('" + message + "');", true);
        }

    }

    private void Send_Visa(string Visa_ID)
    {

        ////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////// Sending Mail Code /////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////
        string dept = Session_CS.dept.ToString();
        string name = "";
        string Succ_names = "", Failed_name = "";
        DataTable dt_Outbox_Visa = General_Helping.GetDataTable("select * from Outbox_Visa_Emp where Visa_Id =" + Visa_ID);
        foreach (DataRow item in dt_Outbox_Visa.Rows)
        {
            update_Outbox_Track_Emp(hidden_Id.Value, CDataConverter.ConvertToInt(item["Emp_ID"].ToString()), 1, 1);
            string sqlformail = "SELECT * from employee ";
            sqlformail += " where pmp_id= " + item["Emp_ID"].ToString();
            DataTable ds = General_Helping.GetDataTable(sqlformail);

            string mail = ds.Rows[0]["mail"].ToString();

            name = ds.Rows[0]["pmp_name"].ToString();


            MailMessage _Message = new MailMessage();
            string str_subj = "";
            if (txt_subject.Text.Length > 160)
            {
                if (int.Parse(Session_CS.group_id.ToString()) == 3)
                {
                    str_subj = txt_subject.Text.Substring(0, 160);
                }
                else
                    str_subj = txt_subject.Text.Substring(0, 130);


            }
            else
            {
                str_subj = txt_subject.Text;
            }


            string str_witoutn = str_subj.Replace("\n", "");
            str_subj = str_witoutn.Replace("\r", "");


            if (int.Parse(Session_CS.group_id.ToString()) == 3)
            {
                
                _Message.Subject = ("OUTIR" + " - " + str_subj + " - " + lblLetterDate.Text).ToString();
            }
            else
            {
                 
                _Message.Subject = ("نظام الادارة الالكترونية - المراسلات" + " - " + str_subj + " - " + lblLetterDate.Text).ToString();
            }



            bool flag = false;
            string file = "";
            byte[] files = new byte[0];
            MemoryStream ms = new MemoryStream();
            DataTable dt = General_Helping.GetDataTable("select * from Inbox_OutBox_Files where Inbox_Outbox_ID =" + hidden_Id.Value + " and Inbox_Or_Outbox =2 ");
            foreach (DataRow dr in dt.Rows)
            {

                if (dr["File_data"] != DBNull.Value)
                {

                     file = dr["File_name"].ToString() + dr["File_ext"].ToString();
                    files = (byte[])dr["File_data"];
                    ms = new MemoryStream(files);
                    _Message.Attachments.Add(new Attachment(ms, file));
                    flag = true;

                }
            }

         
          
            string address2 = System.Web.HttpContext.Current.Request.Url.Authority.ToString();
            String encrypted_id = Encryption.Encrypt(hidden_Id.Value);
            _Message.IsBodyHtml = true;
            _Message.Body = "<html><body dir='rtl'><h3 > السيد - " + name + " </h3>";
            _Message.Body += " <h3 > " + " وصلكم صادر من " + dept + " بتاريخ " + txt_Visa_date.Text + " بخصوص  <br/>" + "<h3 style=" + "color:blue >" + txt_subject.Text + "</h3>" + " </h3>";
            _Message.Body += " <h3 > " + "  وتأشيرة  السيد المدير المختص أن :" + "<h3 style=" + "color:blue >" + txt_Visa_Desc.Text + "</h3>" + " </h3>";

            _Message.Body += " <h3 > ورابط الصادر هو  :<br/>";
            _Message.Body += " <h3 >http:" + "/" + "/" + address2 + "/MainForm/ViewProjectOutbox.aspx?id=" + encrypted_id + "&1=1 </h3>";

            if (flag)
                _Message.Body += "<h3 >  " + " ومرفق الوثائق الخاصة بهذا الصادر</h3> ";



            _Message.Body += "<h3 > مع تحيات </h3> ";
            _Message.Body += "<h3 >   " + Session_CS.e_signature.ToString() + "  </h3> ";
            _Message.Body += "</body></html>";

            //////




            Outbox_Visa_DT obj = Outbox_Visa_DB.SelectByID(CDataConverter.ConvertToInt(Visa_ID));
            obj.mail_sent = 1;
            Outbox_Visa_DB.Save(obj);
            /////////////////////// update have visa = 0/////////////////////////////////////////////
            Update_Have_Visa(Visa_ID);

         
            try
            {
               
                SendingMailthread_class.Sendingmail(_Message,_Message.Subject, _Message.Body, mail, ms, file, encrypted_id, "");


                Succ_names += name + ",";


            }
            catch (Exception ex)
            {
                Failed_name += name + ",";


            }
        }
        string message = Show_Alert(Succ_names, Failed_name, Visa_ID);
        Fil_Grid_Visa();
        ///////////////  to store that mohammed eid send visa to employee
        Outbox_Visa_Follows_DT obj_follow = Outbox_Visa_Follows_DB.SelectByID(CDataConverter.ConvertToInt(hidden_Follow_ID.Value));
        obj_follow.Follow_ID = CDataConverter.ConvertToInt(hidden_Follow_ID.Value);
        obj_follow.Outbox_ID = CDataConverter.ConvertToInt(hidden_Id.Value);

        obj_follow.Descrption = message + "و تم الارسال بواسطة النظام";
        string date = CDataConverter.ConvertDateTimeToFormatdmy(CDataConverter.ConvertDateTimeNowRtnDt());
        obj_follow.Date = date;
        obj_follow.time_follow = CDataConverter.ConvertTimeNowRtnLongTimeFormat();
        obj_follow.entery_pmp_id = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());

        obj_follow.Visa_Emp_id = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
        obj_follow.Follow_ID = Outbox_Visa_Follows_DB.Save(obj_follow);
        Fil_Grid_Visa_Follow();

        


       // Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('" + message + "')</script>");

        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('"+message+"');", true);


    }
    private void Update_Have_Visa(string Visa_Id)
    {
        string Sql_Visa_Sent = "select Visa_Id from Outbox_Visa where mail_sent = 1 and Visa_Id !=" + Visa_Id + " and Outbox_id = " + hidden_Id.Value;
        int Visa_Sent_Count = General_Helping.GetDataTable(Sql_Visa_Sent).Rows.Count;
        if (Visa_Sent_Count == GridView_Visa.Rows.Count - 1)
        {
            DataTable DT = General_Helping.GetDataTable("select * from Outbox_Track_Manager where Outbox_id = " + hidden_Id.Value);
            if (DT.Rows.Count > 0)
            {
                string sql = "update Outbox_Track_Manager set Have_visa=0 , All_visa_sent=1 where Outbox_id =" + hidden_Id.Value;
                General_Helping.ExcuteQuery(sql);
            }
        }

    }

    private string Show_Alert(string Succ_names, string Failed_name, string visa_id)
    {
        string message = "";
        int flag = 0;
        if (!string.IsNullOrEmpty(Succ_names))
        {
            flag = 1;
            message += " لقد تم ارسال الايميل بنجاح إلي " + Succ_names;
        }
        if (!string.IsNullOrEmpty(Failed_name))
        {
            flag = 2;
            message += " ولم يتم ارسال الايميل إلي " + Failed_name;
        }

        if (flag == 1)
        {
            Outbox_Visa_DT obj = Outbox_Visa_DB.SelectByID(CDataConverter.ConvertToInt(visa_id));
            obj.mail_sent = 1;
            Outbox_Visa_DB.Save(obj);


        }

        return message;


        //      if (!string.IsNullOrEmpty(Failed_name))
        //        Page.RegisterStartupScript("Sucess", "<script language=javascript>alert(' لم يتم ارسال الايميل إلي " + Failed_name + "')</script>");

    }
    private void Fil_Visa_Lst(int ID)
    {
        string Sql_Delete = "select * from Outbox_Visa_Emp where Visa_Id =" + ID;
        DataTable DT = General_Helping.GetDataTable(Sql_Delete);
        foreach (DataRow dr in DT.Rows)
        {
            string Value = dr["Emp_ID"].ToString();
            ListItem item = chklst_Visa_Emp.Items.FindByValue(Value);
            if (item != null)
                item.Selected = true;
        }


    }

    private void Fil_Visa_Control(int ID)
    {
        Outbox_Visa_DT obj = Outbox_Visa_DB.SelectByID(ID);
        if (obj.Visa_Id > 0)
        {
            try
            {
                hidden_Visa_Id.Value = obj.Visa_Id.ToString();
                Smart_Search_dept.SelectedValue = obj.Dept_ID.ToString();
                if (obj.Important_Degree > 0)
                    ddl_Important_Degree.SelectedValue = obj.Important_Degree.ToString();
                else
                    txt_Important_Degree_Txt.Text = obj.Important_Degree_Txt;
                fil_emp_Visa();
                if (obj.Emp_ID > 0)
                {
                    ListItem item = chklst_Visa_Emp.Items.FindByValue(obj.Emp_ID.ToString());
                    if (item != null)
                        item.Selected = true;

                }
                txt_Visa_Desc.Text = obj.Visa_Desc;
                txt_Dead_Line_DT.Text = obj.Dead_Line_DT;
                ddl_Visa_Goal_ID.SelectedValue = obj.Visa_Goal_ID.ToString();

            }
            catch
            { }
        }



    }
    protected void GridView_Visa_rw_data_bound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string temp_sql = "";
            DataTable Dt;
            string id = (string)Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Visa_Id"));
            temp_sql = "select mail_sent from Outbox_Visa where Visa_Id=" + id;
            Dt = General_Helping.GetDataTable(temp_sql);
            if (Dt.Rows.Count > 0)
            {
                if (Dt.Rows[0]["mail_sent"].ToString() == "1")
                {
                    CheckBox chbsent = (CheckBox)e.Row.FindControl("chkSent");
                    chbsent.Checked = true;
                }

            }
        }
    }
    protected void Drop_arabic_doc_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (CDataConverter.ConvertToInt(Drop_arabic_doc.SelectedValue) == 1)
        //{
        //    string File_Name = Server.MapPath("~//Uploads/arabic doc/نموذج تقرير متكامل.doc");
        //    FileStream fs = new FileStream(File_Name, FileMode.Open, FileAccess.Read);
        //    byte[] bytes = new byte[fs.Length];
        //    fs.Read(bytes, 0, System.Convert.ToInt32(fs.Length));
        //    fs.Close();
        //    Response.ContentType = "application/x-unknown";
        //    string File_Name_Show = "";
        //    File_Name_Show = "نموذج تقرير متكامل.doc";
        //    Response.AddHeader("Content-Disposition", "attachment; filename=" + Server.UrlPathEncode(File_Name_Show));
        //    Response.BinaryWrite(bytes);
        //    Response.Flush();
        //    Response.Close();
        //}
        //string File_Name_Show = "";
        //string File_Name = "";
        //if (CDataConverter.ConvertToInt(Drop_arabic_doc.SelectedValue) == 1)
        //{
        //    File_Name = Server.MapPath("~//Uploads/arabic doc/نموذج تقرير متكامل.doc");
        //    File_Name_Show = "نموذج تقرير متكامل.doc";


        //}
        //else if (CDataConverter.ConvertToInt(Drop_arabic_doc.SelectedValue) == 2)
        //{
        //    File_Name = Server.MapPath("~//Uploads/arabic doc/نموذج تقرير مختصر.doc");
        //    File_Name_Show = "نموذج تقرير مختصر.doc";

        //}
        //else
        //{
        //    File_Name = Server.MapPath("~//Uploads/arabic doc/نموذج خطاب.doc");
        //    File_Name_Show = "نموذج خطاب.doc";

        //}
        //FileStream fs = new FileStream(File_Name, FileMode.Open, FileAccess.Read);
        //byte[] bytes = new byte[fs.Length];
        //fs.Read(bytes, 0, System.Convert.ToInt32(fs.Length));
        //fs.Close();
        //Response.ContentType = "application/x-unknown";
        //Response.AddHeader("Content-Disposition", "attachment; filename=" + Server.UrlPathEncode(File_Name_Show));
        //Response.BinaryWrite(bytes);
        //Response.Flush();
        //Response.Close();
        //Drop_arabic_doc.SelectedValue = "0";
        //Drop_english_doc.SelectedValue = "0";
    }
    protected void Drop_english_doc_SelectedIndexChanged(object sender, EventArgs e)
    {
        //string File_Name_Show = "";
        //string File_Name = "";
        //if (CDataConverter.ConvertToInt(Drop_english_doc.SelectedValue) == 1)
        //{
        //    File_Name = Server.MapPath("~//Uploads/English doc/Detailed Report Temp.doc");
        //    File_Name_Show = "Detailed Report Temp.doc";

        //}
        //else if (CDataConverter.ConvertToInt(Drop_english_doc.SelectedValue) == 2)
        //{
        //    File_Name = Server.MapPath("~//Uploads/English doc/Short Report Temp.doc");
        //    File_Name_Show = "Short Report Temp.doc";

        //}
        //else
        //{
        //    File_Name = Server.MapPath("~//Uploads/English doc/Letter Temp.doc");
        //    File_Name_Show = "Letter Temp.doc";

        //}
        //Drop_english_doc.SelectedIndex = 0;
        //FileStream fs = new FileStream(File_Name, FileMode.Open, FileAccess.Read);
        //byte[] bytes = new byte[fs.Length];
        //fs.Read(bytes, 0, System.Convert.ToInt32(fs.Length));
        //fs.Close();
        //Response.ContentType = "application/x-unknown";
        //Response.AddHeader("Content-Disposition", "attachment; filename=" + Server.UrlPathEncode(File_Name_Show));
        //Response.BinaryWrite(bytes);
        //Response.Flush();

        //Response.Close();



    }

    protected void btn_arabic_doc_Click(object sender, EventArgs e)
    {
        if (Drop_arabic_doc.SelectedValue == "0")
        {
            //Page.RegisterStartupScript("Sucess", "<script language=javascript>alert(' يجب اختيار نموذج ')</script>");

            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('يجب اختيار نموذج');", true);

        }
        else
        {
            string File_Name_Show = "";
            string File_Name = "";
            if (CDataConverter.ConvertToInt(Drop_arabic_doc.SelectedValue) == 1)
            {
                File_Name = Server.MapPath("~//Uploads/arabic doc/نموذج تقرير متكامل.doc");
                File_Name_Show = "نموذج تقرير متكامل.doc";


            }
            else if (CDataConverter.ConvertToInt(Drop_arabic_doc.SelectedValue) == 2)
            {
                File_Name = Server.MapPath("~//Uploads/arabic doc/نموذج تقرير مختصر.doc");
                File_Name_Show = "نموذج تقرير مختصر.doc";

            }
            else if (CDataConverter.ConvertToInt(Drop_arabic_doc.SelectedValue) == 3)
            {
                File_Name = Server.MapPath("~//Uploads/arabic doc/نموذج خطاب.doc");
                File_Name_Show = "نموذج خطاب.doc";

            }
            else if (CDataConverter.ConvertToInt(Drop_arabic_doc.SelectedValue) == 4)
            {
                File_Name = Server.MapPath("~//Uploads/arabic doc/خطاب الى مدير مكتب الوزير.docx");
                File_Name_Show = "خطاب الى مدير مكتب الوزير.docx";

            }
            else if (CDataConverter.ConvertToInt(Drop_arabic_doc.SelectedValue) == 5)
            {
                File_Name = Server.MapPath("~//Uploads/arabic doc/ل- احمد فرج.docx");
                File_Name_Show = "نموذج ل- احمد فرج.docx";

            }
            else if (CDataConverter.ConvertToInt(Drop_arabic_doc.SelectedValue) == 6)
            {
                File_Name = Server.MapPath("~//Uploads/arabic doc/ل ايمن صادق.doc");
                File_Name_Show = "نموذج ل ايمن صادق.doc";

            }
            else if (CDataConverter.ConvertToInt(Drop_arabic_doc.SelectedValue) == 7)
            {
                File_Name = Server.MapPath("~//Uploads/arabic doc/مذكرة  موارد .doc");
                File_Name_Show = "نموذج مذكرة  موارد .doc";

            }
            else if (CDataConverter.ConvertToInt(Drop_arabic_doc.SelectedValue) == 8)
            {
                File_Name = Server.MapPath("~//Uploads/arabic doc/مذكرة اتصالات .docx");
                File_Name_Show = "نموذج مذكرة اتصالات .docx";

            }
            else if (CDataConverter.ConvertToInt(Drop_arabic_doc.SelectedValue) == 9)
            {
                File_Name = Server.MapPath("~//Uploads/arabic doc/مذكرة ا-محمد شاهين تلفيات.docx");
                File_Name_Show = "نموذج مذكرة ا-محمد شاهين تلفيات.docx";

            }
            else if (CDataConverter.ConvertToInt(Drop_arabic_doc.SelectedValue) == 10)
            {
                File_Name = Server.MapPath("~//Uploads/arabic doc/مذكرة عرض ل-ايمن صادق .doc");
                File_Name_Show = "نموذج مذكرة عرض ل-ايمن صادق .doc";

            }
            else if (CDataConverter.ConvertToInt(Drop_arabic_doc.SelectedValue) == 11)
            {
                File_Name = Server.MapPath("~//Uploads/arabic doc/وزير .docx");
                File_Name_Show = "وزير .docx";

            }


            FileStream fs = new FileStream(File_Name, FileMode.Open, FileAccess.Read);
            byte[] bytes = new byte[fs.Length];
            fs.Read(bytes, 0, System.Convert.ToInt32(fs.Length));
            fs.Close();
            Response.ContentType = "application/x-unknown";
            Response.AddHeader("Content-Disposition", "attachment; filename=" + Server.UrlPathEncode(File_Name_Show));
            Response.BinaryWrite(bytes);
            Response.Flush();
            Response.Close();

        }
    }
    protected void btn_english_doc_Click(object sender, EventArgs e)
    {
        if (Drop_english_doc.SelectedValue == "0")
        {
           // Page.RegisterStartupScript("Sucess", "<script language=javascript>alert(' يجب اختيار نموذج ')</script>");

            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('يجب اختيار نموذج');", true);

        }
        else
        {
            string File_Name_Show = "";
            string File_Name = "";

            if (CDataConverter.ConvertToInt(Drop_english_doc.SelectedValue) == 1)
            {
                File_Name = Server.MapPath("~//Uploads/English doc/Detailed Report Temp.doc");
                File_Name_Show = "Detailed Report Temp.doc";

            }
            else if (CDataConverter.ConvertToInt(Drop_english_doc.SelectedValue) == 2)
            {
                File_Name = Server.MapPath("~//Uploads/English doc/Short Report Temp.doc");
                File_Name_Show = "Short Report Temp.doc";

            }
            else
            {
                File_Name = Server.MapPath("~//Uploads/English doc/Letter Temp.doc");
                File_Name_Show = "Letter Temp.doc";

            }
            FileStream fs = new FileStream(File_Name, FileMode.Open, FileAccess.Read);
            byte[] bytes = new byte[fs.Length];
            fs.Read(bytes, 0, System.Convert.ToInt32(fs.Length));
            fs.Close();
            Response.ContentType = "application/x-unknown";
            Response.AddHeader("Content-Disposition", "attachment; filename=" + Server.UrlPathEncode(File_Name_Show));
            Response.BinaryWrite(bytes);
            Response.Flush();
            Response.Close();

        }
    }
}

