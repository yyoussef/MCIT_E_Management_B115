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


public partial class UserControls_ViewProjectReview : System.Web.UI.UserControl
{
    Session_CS Session_CS = new Session_CS();
    private string sql_Connection = Database.ConnectionString;
    General_Helping Obj_General_Helping = new General_Helping();
    int id;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(hidden_Number.Value))
        {
            string Div = "div" + hidden_Number.Value;
            string image = "image" + hidden_Number.Value;
            Page.RegisterStartupScript("Sucess", "<script language=javascript>ChangeMeCase('" + Div + "','" + image + "','" + hidden_Number.Value + "');</script>");
        }

        if (!IsPostBack)
        {


            if (Request.QueryString["id"] != null)
            {
                //DateTime str = System.DateTime.Now;
                DateTime str_dead = CDataConverter.ConvertDateTimeNowRtnDt().AddDays(7);
               // txt_Visa_date.Text = CDataConverter.ConvertDateTimeNowRtrnString();
                //txt_Dead_Line_DT.Text = str_dead.ToString("dd/MM/yyyy");
                //txt_Follow_Date.Text = str.ToString("dd/MM/yyyy");
                //txt_time_follow.Text = DateTime.UtcNow.ToLocalTime().ToLongTimeString();
                String decrypted_id = Encryption.Decrypt(Request.QueryString["id"].ToString());
                id = Convert.ToInt16(decrypted_id);
                hidden_Id.Value = id.ToString();
                int pmp = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
                //if (CDataConverter.ConvertToInt(Session_CS.group_id.ToString()) == 3)
                //{
                //    DataTable dt_closed = General_Helping.GetDataTable(" select * from Review_Track_Emp where Emp_ID = " + pmp + " and Review_id = " + id);
                //    if (dt_closed.Rows.Count > 0)
                //    {
                //        btn_close_Review.Visible = true;

                //    }
                //    else
                //    {
                //        btn_close_Review.Visible = false;

                //    }
                //    btn_end_late.Visible = false;
                //}
                //else
                //{
                //    if (CDataConverter.ConvertToInt(Session_CS.parent_id.ToString()) > 0)
                //    {
                //        btn_close_Review.Visible = true;
                //        btn_end_late.Visible = true;

                //        //Trfollow.Visible = false;
                //    }
                //    else
                //    {
                //        btn_close_Review.Visible = false;
                //        btn_end_late.Visible = false;
                //    }
                //}


               // tr_old_emp.Visible = false;
                //tr_old_emp_resp.Visible = false;
                string sql_for_chklist_emp = " select * from pmp_fav_View where pmp_fav_View.employee_id = " + CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()) + " ORDER BY LTRIM(pmp_name)";
                DataTable dt_emp_fav = General_Helping.GetDataTable(sql_for_chklist_emp);
                //chklst_Visa_Emp_All.DataSource = dt_emp_fav;
               // chklst_Visa_Emp_All.DataBind();
                //if (Session_CS.pmp_id.ToString() == "57")
                DataTable dt = General_Helping.GetDataTable("select parent_pmp_id,pmp_id from parent_employee where pmp_id = " + CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()) + "or parent_pmp_id = " + CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()));
                if (dt.Rows.Count > 0)
                {
                    if (CDataConverter.ConvertToInt(dt.Rows[0]["parent_pmp_id"].ToString()) == CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()))
                    {
                        //Trfollow.Visible = false;
                      
                        //tr_follow_date.Visible = false;
                        //tr_follow_desc.Visible = false;
                        //tr_follow_doc.Visible = false;
                        //tr_follow_person.Visible = false;
                        //tr_follow_save.Visible = false;
                        //tr_follow_proj.Visible = false;
                        //tr_follow_time.Visible = false;
                        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                        DataTable DT = new DataTable();
                        DT = General_Helping.GetDataTable("select * from Review_Track_Manager where Review_id = " + id);
                        if (DT.Rows.Count > 0)
                        {
                            //foreach (DataRow rw in DT.Rows)
                            //{
                            DataRow rw = DT.Rows[0];
                            if (rw["status"].ToString() != "3")
                            {
                                //if (rw["Have_visa"].ToString() != "1")
                                //    lnkBtnUnderStudy.Visible = true;
                                string sql =
                                "UPDATE Review_Track_Manager" + "\r\n" +
                                "   SET status    = 3" + "\r\n" +
                                " WHERE Review_id =" + id;
                                SqlCommand cmd = new SqlCommand(sql, conn);
                                cmd.ExecuteNonQuery();
                                conn.Close();
                            }
                            if (CDataConverter.ConvertToInt(Session_CS.group_id.ToString()) == 3)
                            {
                                if (rw["IS_New_Mail"].ToString() != "3")
                                {
                                    conn.Open();
                                    string sql = "update Review_Track_Manager set status=0,Have_Follow=0 where Review_id =" + id;
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
                    #region commented by MahMOUd 

                    //// tr_mngr1.Visible =
                    ////tr_mngr2.Visible = false;

                    //// GridView_Visa.Columns[6].Visible = false;
                    //DataTable dt_proj = General_Helping.GetDataTable(" select Proj_id from Review where ID = " + id);
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
                    //    if (pmp == 70)
                    //    {
                    //        //Trfollow.Visible = false;
                    //        tr_follow_date.Visible = false;
                    //        tr_follow_desc.Visible = false;
                    //        tr_follow_doc.Visible = false;
                    //        tr_follow_person.Visible = false;
                    //        tr_follow_save.Visible = false;
                    //        tr_follow_proj.Visible = false;
                    //        //     tr_mngr1.Visible =
                    //        //tr_mngr2.Visible = true;
                    //        //     GridView_Visa.Columns[6].Visible = true;
                    //    }

                    //}
                    #endregion
                }
                //}
                //else
                //{
                //tr_mngr1.Visible =
                //    tr_mngr2.Visible = true;
                //GridView_Visa.Columns[6].Visible = false;
                // }
                //DataTable dt_follow = General_Helping.GetDataTable("select * from Review_follow_emp where Review_id=" + id + "AND pmp_id = " + pmp);
                //if (dt_follow.Rows.Count > 0)
                //{
                //    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                //    conn.Open();
                #region commented by MahMOUd
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //string sql_update = "update Review_follow_emp set Have_follow = 0";
                //sql_update += " where ( Review_follow_emp.pmp_id =" + pmp;
                //sql_update += " AND Review_follow_emp.Review_id = " + id;
                //sql_update += ")";
                //General_Helping.ExcuteQuery(sql_update);
                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                #endregion
                //    SqlCommand cmd = new SqlCommand(sql_update, conn);
                //    cmd.ExecuteNonQuery();
                //    conn.Close();

                //}
                Fill_Controll(id);
                Fil_Grid_Documents();
                //Fil_Grid_Visa_Follow();
                Fil_Dll();
                //fil_emp_Visa();
                Fil_Emp_Visa_Follow();
                //Fil_Grid_Visa();
               

            }


        }

    }

    

   
    

  

   

    protected override void OnInit(EventArgs e)
    {
        #region BROWSER FOR departments

        ////Smart_Org_ID.sql_Connection = sql_Connection;
        ////Smart_Org_ID.Query = "SELECT Org_ID, Org_Desc FROM Organization";
        ////Smart_Org_ID.Value_Field = "Org_ID";
        ////Smart_Org_ID.Text_Field = "Org_Desc";
        ////Smart_Org_ID.DataBind();

        ////fil_emp();
        ////Smart_Emp_ID.sql_Connection = sql_Connection;
        ////Smart_Emp_ID.Query = "SELECT PMP_ID, pmp_name FROM EMPLOYEE ";
        ////Smart_Emp_ID.Value_Field = "PMP_ID";
        ////Smart_Emp_ID.Text_Field = "pmp_name";
        ////Smart_Emp_ID.DataBind();

        ////this.Smrt_Srch_DropDep.Value_Handler += new Smart_Search.Delegate_Selected_Value(MOnMember_Data);
        ////Review_organization.SelectedValue;
        //// fill project

        //Smart_Search_proj.sql_Connection = sql_Connection;
        //Smart_Search_proj.Query = "SELECT Proj_id, Proj_Title FROM Project ";
        //Smart_Search_proj.Value_Field = "Proj_id";
        //Smart_Search_proj.Text_Field = "Proj_Title";
        //Smart_Search_proj.DataBind();

        //Smart_Search_dept.sql_Connection = sql_Connection;
        //Smart_Search_dept.Query = "SELECT Dept_id, Dept_name FROM Departments ";
        //Smart_Search_dept.Value_Field = "Dept_id";
        //Smart_Search_dept.Text_Field = "Dept_name";
        //Smart_Search_dept.DataBind();
        //this.Smart_Search_dept.Value_Handler += new Smart_Search.Delegate_Selected_Value(MOnMember_Data);
        #endregion
        base.OnInit(e);
    }

    private void MOnMember_Data(string Value)
    {
        dropdept_fun();
    }

    protected void dropdept_fun()
    {



        //fil_emp_Visa();


    }

    private void Fil_Dll()
    {
        //DataTable DT = new DataTable();
        //DT = General_Helping.GetDataTable("select * from Departments");
        //Obj_General_Helping.SmartBindDDL(ddl_Visa_Dept_ID, DT, "Dept_ID", "Dept_name", "....اختر اسم الإدارة ....");


    }

   

    protected void ddl_Visa_Dept_ID_SelectedIndexChanged(object sender, EventArgs e)
    {
        //fil_emp_Visa();
    }

    private void Fill_Controll(int id)
    {
        try
        {
            Review_DT obj = Review_DB.SelectByID(id);
            hidden_Id.Value = obj.ID.ToString();
            //hidden_Proj_id.Value = obj.Proj_id.ToString();
            //if (obj.Type == 2)
            //{
            //    lblLetterType.Text = "وارد خارجي";
            //}
            //if (obj.Type == 1)
            //{ lblLetterType.Text = "وارد داخلي"; }
          //  lblLetterType.Text = "xxxxxxxxxxx";
            lblCode.Text = obj.Code;
            lblLetterDate.Text = obj.Date;
            //ddl_Type.SelectedValue = obj.Type.ToString();
            //if (obj.Source_Type == 1)
            //{
            //    lblSourceType.Text = "البريد";
            //}
            //if (obj.Source_Type == 2)
            //{ lblSourceType.Text = "الايميل"; }
            //if (obj.Source_Type == 3)
            //{ lblSourceType.Text = "الفاكس"; }


            //if (obj.Org_Dept_Name != "")
            //    lblDept_in.Text = obj.Org_Dept_Name.ToString();

            //if (obj.Org_Out_Box_Person != "")
            //    lblOrg_Out_Box_Person.Text = obj.Org_Out_Box_Person.ToString();

            //lblOrg_Out_Box_DT.Text = obj.Org_Out_Box_DT.ToString();
            //lblOrg_Out_Box_Code.Text = obj.Org_Out_Box_Code.ToString();
            //lbl_paper_no.Text = obj.Paper_No.ToString();
            //lbl_att_no.Text = obj.Paper_Attached.ToString();
            txt_subject.Text = obj.Subject.ToString();
            txt_notes.Text = obj.Notes.ToString();
            //DataTable DT_vd = new DataTable();
            //DT_vd = General_Helping.GetDataTable("select * from Review_Track_Manager where Review_id = " + id);
            //if (DT_vd.Rows.Count > 0)
            //    txt_Visa_Desc.Text = DT_vd.Rows[0]["Visa_Desc"].ToString();
            ////ddl_Related_Type.SelectedValue = obj.Related_Type.ToString();
            //if (obj.Related_Type.ToString() != "")
            //{
            //    if (obj.Related_Type == 1)
            //    { lblRelatedType.Text = "وارد جديد"; }
            //    if (obj.Related_Type == 2)
            //    { lblRelatedType.Text = "رد على صادر"; }
            //    if (obj.Related_Type == 3)
            //    { lblRelatedType.Text = "استعجال وارد"; }


            //}
            //if (obj.Org_Id.ToString() != "")
            //{
            //    DataTable DT = new DataTable();
            //    DT = General_Helping.GetDataTable("SELECT  [Org_ID], [Org_Desc] FROM Organization WHERE Org_ID=" + obj.Org_Id);
            //    if (DT.Rows.Count != 0)
            //    {
            //        lblOrgName.Text = DT.Rows[0]["Org_Desc"].ToString();
            //    }

            //}


        }
        catch
        { }
    }

    //protected void btn_Visa_Follow_Click(object sender, EventArgs e)
    //{
    //    if (CDataConverter.ConvertToInt(hidden_Id.Value) > 0)
    //    {
    //        Review_Visa_Follows_DT obj = Review_Visa_Follows_DB.SelectByID(CDataConverter.ConvertToInt(hidden_Follow_ID.Value));
    //        obj.Follow_ID = CDataConverter.ConvertToInt(hidden_Follow_ID.Value);
    //        obj.Review_ID = CDataConverter.ConvertToInt(hidden_Id.Value);
    //        obj.Descrption = txt_Descrption.Text;
    //        obj.Date = txt_Follow_Date.Text;
    //        obj.time_follow = txt_time_follow.Text;
    //        obj.entery_pmp_id = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
    //        obj.Visa_Emp_id = CDataConverter.ConvertToInt(ddl_Visa_Emp_id.SelectedValue);
    //        obj.Follow_ID = Review_Visa_Follows_DB.Save(obj);

    //        //DataTable dt_Review_Visa = General_Helping.GetDataTable("select * from Review_Track_Emp where Review_id =" + hidden_Id.Value);
    //        //foreach (DataRow item in dt_Review_Visa.Rows)
    //        //{
    //        //    Review_DB.update_Review_Track_Emp(hidden_Id.Value, item["Emp_ID"].ToString(), 4, 1);
    //        //}

    //        if (FileUpload_Visa_Follow.HasFile)
    //        {
    //            string DocName = FileUpload_Visa_Follow.FileName;
    //            int dotindex = DocName.LastIndexOf(".");
    //            string type = DocName.Substring(dotindex, DocName.Length - dotindex);

    //            Stream myStream;
    //            int fileLen;
    //            StringBuilder displayString = new StringBuilder();
    //            fileLen = FileUpload_Visa_Follow.PostedFile.ContentLength;
    //            Byte[] Input = new Byte[fileLen];
    //            myStream = FileUpload_Visa_Follow.FileContent;
    //            myStream.Read(Input, 0, fileLen);

    //            SqlCommand cmd = new SqlCommand();
    //            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
    //            cmd.Connection = con;
    //            cmd.CommandType = CommandType.Text;
    //            cmd.CommandText = " update Review_Visa_Follows set File_data =@File_data ,File_name=@File_name,File_ext=@File_ext where Follow_ID =@Follow_ID";
    //            cmd.Parameters.Add("@File_data", SqlDbType.VarBinary);
    //            cmd.Parameters.Add("@File_name", SqlDbType.NVarChar);
    //            cmd.Parameters.Add("@File_ext", SqlDbType.NVarChar);
    //            cmd.Parameters.Add("@Follow_ID", SqlDbType.BigInt);

    //            cmd.Parameters["@File_data"].Value = Input;
    //            cmd.Parameters["@File_name"].Value = DocName;
    //            cmd.Parameters["@File_ext"].Value = type;
    //            cmd.Parameters["@Follow_ID"].Value = obj.Follow_ID;

    //            con.Open();
    //            cmd.ExecuteScalar();
    //            con.Close();



    //        }
    //        ///////////// change have follow = 1 , All_visa_sent=0 /////////////////////////////////////////////

    //        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
    //        //DataTable DT = new DataTable();
    //        //DT = General_Helping.GetDataTable("select * from Review_Track_Manager where Review_id = " + hidden_Id.Value);
    //        //if (DT.Rows.Count > 0)
    //        //{
    //        //    conn.Open();
    //        //    string sql = "update Review_Track_Manager set Have_Follow=1,All_visa_sent=0 where Review_id =" + hidden_Id.Value;
    //        //    SqlCommand cmd = new SqlCommand(sql, conn);
    //        //    cmd.ExecuteNonQuery();
    //        //    conn.Close();

    //        //}
    //        int id = Convert.ToInt16(Request["id"]);
    //        if (CDataConverter.ConvertToInt(Session_CS.parent_id.ToString()) == 0)
    //        {
    //            //string sql = "SELECT dbo.Review_Visa_Emp.Sender_ID, dbo.Review_Visa_Emp.Emp_ID FROM dbo.Review_Visa INNER JOIN dbo.Review_Visa_Emp ON dbo.Review_Visa.Visa_Id = dbo.Review_Visa_Emp.Visa_Id where dbo.Review_Visa.Review_ID = " + id + "AND dbo.Review_Visa_Emp.Emp_ID = " + CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
    //            string SQL =
    //            "SELECT dbo.Review_Visa_Emp.Sender_ID, dbo.Review_Visa_Emp.Emp_ID" + "\r\n" +
    //            "  FROM    dbo.Review_Visa" + "\r\n" +
    //            "       INNER JOIN" + "\r\n" +
    //            "          dbo.Review_Visa_Emp" + "\r\n" +
    //            "       ON dbo.Review_Visa.Visa_Id = dbo.Review_Visa_Emp.Visa_Id";
    //            SQL += " where dbo.Review_Visa.Review_ID = " + id + "AND dbo.Review_Visa_Emp.Emp_ID = " + CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
    //            DataTable dt = General_Helping.GetDataTable(SQL);
    //            int sender1 = CDataConverter.ConvertToInt(dt.Rows[0]["Sender_id"].ToString());


    //            //string both_see = " SELECT     Review_Visa_Emp.Visa_Emp_ID, Review_Visa_Emp.Visa_Id, Review_Visa_Emp.Emp_ID, Review_Visa_Emp.Sender_ID, Review_Visa.Review_ID FROM         Review_Visa_Emp LEFT OUTER JOIN                       Review_Visa ON Review_Visa_Emp.Visa_Id = Review_Visa.Visa_Id ";
    //            string both_see =
    //            "SELECT Review_Visa_Emp.Visa_Emp_ID," + "\r\n" +
    //            "       Review_Visa_Emp.Visa_Id," + "\r\n" +
    //            "       Review_Visa_Emp.Emp_ID," + "\r\n" +
    //            "       Review_Visa_Emp.Sender_ID," + "\r\n" +
    //            "       Review_Visa.Review_ID" + "\r\n" +
    //            "  FROM    Review_Visa_Emp" + "\r\n" +
    //            "       LEFT OUTER JOIN" + "\r\n" +
    //            "          Review_Visa" + "\r\n" +
    //            "       ON Review_Visa_Emp.Visa_Id = Review_Visa.Visa_Id";
    //            both_see += " where Sender_id=" + sender1 + " and Review_ID =" + id;
    //            DataTable dt_both_see = General_Helping.GetDataTable(both_see);
    //            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //            //for (int i = 0; i < dt_both_see.Rows.Count; i++)
    //            //{
    //            //    if (CDataConverter.ConvertToInt(dt_both_see.Rows[i]["Emp_ID"].ToString()) != CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()))
    //            //    {
    //            //        string sql_exist = "select * from Review_follow_emp where Review_id = " + id + " AND Review_follow_emp.pmp_id = " + CDataConverter.ConvertToInt(dt_both_see.Rows[i]["Emp_ID"].ToString());
    //            //        DataTable dt_exist = General_Helping.GetDataTable(sql_exist);
    //            //        if (dt_exist.Rows.Count > 0)
    //            //        {
    //            //            General_Helping.ExcuteQuery(" update Review_follow_emp set Have_follow = 1 where (Review_id = " + id + "  AND Review_follow_emp.pmp_id = " + CDataConverter.ConvertToInt(dt_both_see.Rows[i]["Emp_ID"].ToString()) + ")");

    //            //        }
    //            //        else
    //            //        {
    //            //            string Sql_insert = "insert into Review_follow_emp (pmp_id , Have_follow ,Review_id) values ( " + CDataConverter.ConvertToInt(dt_both_see.Rows[i]["Emp_ID"].ToString()) + ",1," + id + ")";
    //            //            General_Helping.ExcuteQuery(Sql_insert);
    //            //        }
    //            //    }

    //            //}

    //            //string sql_sender_exist = "select * from Review_follow_emp where Review_id = " + id + " AND Review_follow_emp.pmp_id = " + sender1;
    //            //DataTable dt_sender_exist = General_Helping.GetDataTable(sql_sender_exist);
    //            //if (dt_sender_exist.Rows.Count > 0)
    //            //{
    //            //    General_Helping.ExcuteQuery(" update Review_follow_emp set Have_follow = 1 where (Review_id = " + id + " AND Review_follow_emp.pmp_id = " + sender1 + ")");
    //            //}
    //            //else
    //            //{
    //            //    string Sql_insert_parent = "insert into Review_follow_emp (pmp_id , Have_follow ,Review_id) values ( " + CDataConverter.ConvertToInt(dt.Rows[0]["Sender_ID"].ToString()) + ",1," + id + ")";
    //            //    General_Helping.ExcuteQuery(Sql_insert_parent);
    //            //}
    //            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    //        }

    //        //if (Smart_Search_proj.SelectedValue != "")
    //        //{

    //        //    conn.Open();
    //        //    string sql = "update Review set proj_id = " + Smart_Search_proj.SelectedValue;
    //        //    sql += " where ID  =" + hidden_Id.Value;
    //        //    SqlCommand cmd = new SqlCommand(sql, conn);
    //        //    cmd.ExecuteNonQuery();
    //        //    conn.Close();

    //        //}
    //        Clear_visa_Follow();

    //        Fil_Grid_Visa_Follow();
    //    }
    //    else
    //    {
    //        Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('يجب إدخال بيانات الخطاب أولا')</script>");

    //    }

    //}

    private void Clear_visa_Follow()
    {
        hidden_Follow_ID.Value = "";
        //txt_Descrption.Text =
        //txt_Follow_Date.Text = "";
        //ddl_Visa_Emp_id.SelectedIndex = 0;
    }

    //private void Fil_Grid_Visa_Follow()
    //{
    //    DataTable DT = new DataTable();
    //    //string Sql = "SELECT Review_Visa_Follows.Follow_ID,Review_Visa_Follows.File_name,Review_Visa_Follows.time_follow,Review_Visa_Follows.Review_ID, Review_Visa_Follows.Descrption, Review_Visa_Follows.Date, Review_Visa_Follows.Visa_Emp_id, EMPLOYEE.pmp_name " +
    //    //             " FROM         Review_Visa_Follows INNER JOIN EMPLOYEE ON Review_Visa_Follows.Visa_Emp_id = EMPLOYEE.PMP_ID where Review_ID =" + hidden_Id.Value;
    //    string SQL =
    //    "SELECT Review_Visa_Follows.Follow_ID," + "\r\n" +
    //    "       Review_Visa_Follows.File_name," + "\r\n" +
    //    "       Review_Visa_Follows.time_follow," + "\r\n" +
    //    "       Review_Visa_Follows.Review_ID," + "\r\n" +
    //    "       Review_Visa_Follows.Descrption," + "\r\n" +
    //    "       Review_Visa_Follows.Date," + "\r\n" +
    //    "       Review_Visa_Follows.Visa_Emp_id," + "\r\n" +
    //    "       EMPLOYEE.pmp_name" + "\r\n" +
    //    "  FROM    Review_Visa_Follows" + "\r\n" +
    //    "       INNER JOIN" + "\r\n" +
    //    "          EMPLOYEE" + "\r\n" +
    //    "       ON Review_Visa_Follows.Visa_Emp_id = EMPLOYEE.PMP_ID" + "\r\n" +
    //    " WHERE Review_ID =" + hidden_Id.Value;
    //    DT = General_Helping.GetDataTable(SQL);

    //    GridView_Visa_Follow.DataSource = DT;
    //    GridView_Visa_Follow.DataBind();
    //}

    protected void GridView_Visa_Follow_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "EditItem")
        {

            Review_Visa_Follows_DT obj = Review_Visa_Follows_DB.SelectByID(CDataConverter.ConvertToInt(e.CommandArgument));
            if (obj.Follow_ID > 0)
            {
                hidden_Follow_ID.Value = obj.Follow_ID.ToString();
                //txt_Descrption.Text = obj.Descrption;
                //txt_Follow_Date.Text = obj.Date;
                //ddl_Visa_Emp_id.SelectedValue = obj.Visa_Emp_id.ToString();

            }
        }

        if (e.CommandName == "RemoveItem")
        {
            Review_Visa_Follows_DB.Delete(CDataConverter.ConvertToInt(e.CommandArgument));
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم الحذف بنجاح')</script>");
            //Fil_Grid_Visa_Follow();
        }
    }

    private void Fil_Emp_Visa_Follow()
    {
        int grp = CDataConverter.ConvertToInt(Session_CS.group_id.ToString());
        if (CDataConverter.ConvertToInt(hidden_Id.Value) > 0)
        {
            DataTable DT = new DataTable();
            //string sql = " SELECT  distinct   EMPLOYEE.PMP_ID, EMPLOYEE.pmp_name, Review_Visa.Review_ID ";
            //sql += " FROM Review_Visa_Emp INNER JOIN EMPLOYEE ON Review_Visa_Emp.Emp_ID = EMPLOYEE.PMP_ID INNER JOIN Review_Visa ON Review_Visa_Emp.Visa_Id = Review_Visa.Visa_Id INNER JOIN Review ON Review_Visa.Review_ID = Review.ID ";
            //sql += " where Review_ID=" + hidden_Id.Value;
            string sql =
            "SELECT DISTINCT EMPLOYEE.PMP_ID, EMPLOYEE.pmp_name, Review_Visa.Review_ID" + "\r\n" +
            "  FROM          Review_Visa_Emp" + "\r\n" +
            "             INNER JOIN" + "\r\n" +
            "                EMPLOYEE" + "\r\n" +
            "             ON Review_Visa_Emp.Emp_ID = EMPLOYEE.PMP_ID" + "\r\n" +
            "          INNER JOIN" + "\r\n" +
            "             Review_Visa" + "\r\n" +
            "          ON Review_Visa_Emp.Visa_Id = Review_Visa.Visa_Id" + "\r\n" +
            "       INNER JOIN" + "\r\n" +
            "          Review" + "\r\n" +
            "       ON Review_Visa.Review_ID = Review.ID" + "\r\n" +
            " WHERE Review_ID =" + hidden_Id.Value;


            if (grp != 9)
            {
                sql += " AND EMPLOYEE.PMP_ID = " + CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
            }


            DT = General_Helping.GetDataTable(sql);
            //Obj_General_Helping.SmartBindDDL(ddl_Visa_Emp_id, DT, "PMP_ID", "pmp_name",);
            //ddl_Visa_Emp_id.DataSource = DT;
            //ddl_Visa_Emp_id.DataTextField = "pmp_name";
            //ddl_Visa_Emp_id.DataValueField = "pmp_id";

            //ddl_Visa_Emp_id.DataBind();

        }
    }

    protected void GrdView_Documents_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //if (e.CommandName == "EditItem")
        //{
        //    Review_Files_DT obj = Review_Files_DB.SelectByID(CDataConverter.ConvertToInt(e.CommandArgument));
        //    if (obj.Review_OutBox_File_ID > 0)
        //    {
        //        hidden_Review_OutBox_File_ID.Value = obj.Review_OutBox_File_ID.ToString();
        //        txtFileName.Text = obj.File_name;
        //        //ddl_Original_Or_Attached.SelectedValue = obj.Original_Or_Attached.ToString();
        //    }

    }

    private void Fil_Grid_Documents()
    {
        DataTable DT = new DataTable();
        DT = General_Helping.GetDataTable("select * from Review_Files where  Review_ID=" + id);

        GrdView_Documents.DataSource = DT;
        GrdView_Documents.DataBind();
    }

    protected void btn_print_report_Click(object sender, EventArgs e)
    {
        string user = Session_CS.pmp_name.ToString();

        ReportDocument rd = new ReportDocument();
        string s = Server.MapPath("../Reports/ReviewReport/Review_Data.rpt");
        rd.Load(s);
        Reports.Load_Report(rd);
        rd.SetParameterValue("@Review_ID", CDataConverter.ConvertToInt(hidden_Id.Value));
        rd.SetParameterValue("@ip", IpAddress(), "footerRep.rpt");
        rd.SetParameterValue("@user", user, "footerRep.rpt");

        if (rd.Rows.Count == 0)
        {
            ShowAlertMessage("!!!!!هذا التقرير لا يوجد به بيانات للعرض !!!!");
            return;
        }
        else
        {
            rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report");
        }


    }

    //protected void btn_close_Review_Click(object sender, EventArgs e)
    //{

    //    ///////////// change status = 3  /////////////////////////////////////////////
    //    int id = Convert.ToInt16(Request["id"]);
    //    DataTable DT = new DataTable();
    //    DT = General_Helping.GetDataTable("select * from Review_Track_Manager where Review_id = " + hidden_Id.Value);
    //    if (DT.Rows.Count > 0)
    //    {
    //        string sql = "update Review_Track_Manager set Have_Follow=0,All_visa_sent=0,Have_Visa=0,status=3 where Review_id =" + hidden_Id.Value;
    //        General_Helping.ExcuteQuery(sql);

    //    }
    //    DataTable dt_Review_Visa = General_Helping.GetDataTable("select * from Review_Track_Emp where Review_id =" + hidden_Id.Value);
    //    foreach (DataRow item in dt_Review_Visa.Rows)
    //    {
    //        Review_DB.update_Review_Track_Emp(hidden_Id.Value, item["Emp_ID"].ToString(), 3, 1);
    //    }

    //    Review_Visa_Follows_DT obj = Review_Visa_Follows_DB.SelectByID(CDataConverter.ConvertToInt(hidden_Follow_ID.Value));
    //    obj.Follow_ID = CDataConverter.ConvertToInt(hidden_Follow_ID.Value);
    //    obj.Review_ID = CDataConverter.ConvertToInt(hidden_Id.Value);
    //    obj.Descrption = "تم إغلاق الموضوع";
    //    string date = DateTime.Now.ToShortDateString().ToString();
    //    obj.Date = date;
    //    obj.time_follow = DateTime.UtcNow.ToLocalTime().ToLongTimeString();
    //    obj.entery_pmp_id = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
    //    obj.Visa_Emp_id = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
    //    obj.Follow_ID = Review_Visa_Follows_DB.Save(obj);
    //    Fil_Grid_Visa_Follow();
    //    ///////////////////////////////////////////////////////////////// when dr hesham close Review update all have follow in Review follow emp to be zero
    //    //General_Helping.ExcuteQuery("update Review_follow_emp set Have_follow = 0 where Review_id = " + id);
    //    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    //    Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('تم إغلاق الموضوع بنجاح' )</script>");


    //}

    //protected void btn_end_late_Click(object sender, EventArgs e)
    //{

    //    ///////////// change status = 3  /////////////////////////////////////////////
    //    int id = Convert.ToInt16(Request["id"]);
    //    DataTable DT = new DataTable();
    //    DT = General_Helping.GetDataTable("select * from Review where ID = " + id);
    //    if (DT.Rows.Count > 0)
    //    {
    //        string sql = "update Review set finished=1 where ID =" + id;
    //        General_Helping.ExcuteQuery(sql);

    //    }
    //    //DataTable dt_Review_Visa = General_Helping.GetDataTable("select * from Review_Track_Emp where Review_id =" + hidden_Id.Value);
    //    //foreach (DataRow item in dt_Review_Visa.Rows)
    //    //{
    //    //    Review_DB.update_Review_Track_Emp(hidden_Id.Value, item["Emp_ID"].ToString(), 3, 1);
    //    //}

    //    Review_Visa_Follows_DT obj = Review_Visa_Follows_DB.SelectByID(CDataConverter.ConvertToInt(hidden_Follow_ID.Value));
    //    obj.Follow_ID = CDataConverter.ConvertToInt(hidden_Follow_ID.Value);
    //    obj.Review_ID = CDataConverter.ConvertToInt(hidden_Id.Value);
    //    obj.Descrption = "تم انهاء تأخير الموضوع";
    //    string date = DateTime.Now.ToShortDateString().ToString();
    //    obj.Date = date;
    //    obj.time_follow = DateTime.UtcNow.ToLocalTime().ToLongTimeString();
    //    obj.entery_pmp_id = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
    //    obj.Visa_Emp_id = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
    //    obj.Follow_ID = Review_Visa_Follows_DB.Save(obj);
    //    Fil_Grid_Visa_Follow();
    //    ///////////////////////////////////////////////////////////////// when dr hesham close Review update all have follow in Review follow emp to be zero
    //    //General_Helping.ExcuteQuery("update Review_follow_emp set Have_follow = 0 where Review_id = " + id);
    //    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    //    Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('تم انهاء تأخير الموضوع بنجاح' )</script>");


    //}

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

    public static void ShowAlertMessage(string error)
    {

        Page page = HttpContext.Current.Handler as Page;
        if (page != null)
        {
            error = error.Replace("'", "\'");
            ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('" + error + "');", true);
        }
    }

    

  

   

  

    private void Save_inox_Visa(Review_Visa_DT obj)
    {

        string Sql_Delete = "delete from Review_Visa_Emp where Visa_Id =" + obj.Visa_Id;
        General_Helping.ExcuteQuery(Sql_Delete);
        string Sql_insert = "";
        //foreach (ListItem item in chklst_Visa_Emp.Items)
        //{
        //    if (item.Selected)
        //    {
        //        if (CDataConverter.ConvertToInt(Session_CS.group_id.ToString()) == 2)
        //        {
        //            Sql_insert = "insert into Review_Visa_Emp ( Visa_Id , Emp_ID ,Sender_id) values ( " + obj.Visa_Id + "," + item.Value + ",57 " + ")";
        //        }
        //        else
        //        {
        //            Sql_insert = "insert into Review_Visa_Emp ( Visa_Id , Emp_ID ,Sender_id) values ( " + obj.Visa_Id + "," + item.Value + "," + CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()) + ")";
        //        }

        //        General_Helping.ExcuteQuery(Sql_insert);

        //        item.Selected = false;
        //    }

        //}

      




    }

    //private void Save_inox_Visa(Review_Visa_DT obj)
    //{

    //    string Sql_Delete = "delete from Review_Visa_Emp where Visa_Id =" + obj.Visa_Id;
    //    General_Helping.ExcuteQuery(Sql_Delete);
    //    foreach (ListItem item in chklst_Visa_Emp.Items)
    //    {
    //        if (item.Selected)
    //        {

    //            string Sql_insert = "insert into Review_Visa_Emp ( Visa_Id , Emp_ID ,Sender_id) values ( " + obj.Visa_Id + "," + item.Value + "," + CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()) + ")";
    //            General_Helping.ExcuteQuery(Sql_insert);
    //            item.Selected = false;
    //        }

    //    }
    //}

    protected void lnkBtnUnderStudy_Click(object sender, EventArgs e)
    {
        int id = Convert.ToInt16(Request["id"]);
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        DataTable DT = new DataTable();
        DT = General_Helping.GetDataTable("select * from Review_Track_Manager where Review_id = " + id);
        if (DT.Rows.Count > 0)
        {
            conn.Open();
            ///////////////////////////////////////////////////////////////////////////////////////////////
            ///////////////////// xxxxxxxxxxxxxxxxxxxx //////////////////////////////////////////////////// 
            ///////////////////////////////////////////////////////////////////////////////////////////////
            //string sql = "update Review_Track_Manager set status=2 where Review_id =" + id;
            string sql =
            "UPDATE Review_Track_Manager" + "\r\n" +
            "   SET status    = 3" + "\r\n" +
            " WHERE Review_id =" + id;
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            DataTable dt_get_group_id = General_Helping.GetDataTable("select group_id from employee where pmp_id = " + CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()));
            int group = CDataConverter.ConvertToInt(dt_get_group_id.Rows[0]["group_id"].ToString());
            if (group == 2)
            {
                Response.Redirect("~\\WebForms2");
            }
            else if (group == 3)
            {
                Response.Redirect("~\\WebForms");
            }


        }
    }

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
        DT = General_Helping.GetDataTable("SELECT EMPLOYEE.pmp_name FROM Review_Visa_Emp INNER JOIN EMPLOYEE ON Review_Visa_Emp.Emp_ID = EMPLOYEE.PMP_ID WHERE Review_Visa_Emp.Visa_Id  =" + visa_ID);
        foreach (DataRow dr in DT.Rows)
        {
            emp_name += dr["pmp_name"].ToString() + ",";
        }

        return emp_name;

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
            Review_Visa_DT obj = Review_Visa_DB.SelectByID(CDataConverter.ConvertToInt(visa_id));
            obj.mail_sent = 1;
            Review_Visa_DB.Save(obj);


        }

        return message;


        //      if (!string.IsNullOrEmpty(Failed_name))
        //        Page.RegisterStartupScript("Sucess", "<script language=javascript>alert(' لم يتم ارسال الايميل إلي " + Failed_name + "')</script>");

    }

    protected void GridView_Visa_rw_data_bound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string temp_sql = "";
            DataTable Dt;
            string id = (string)Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Visa_Id"));
            temp_sql = "select mail_sent from Review_Visa where Visa_Id=" + id;
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

   
}

