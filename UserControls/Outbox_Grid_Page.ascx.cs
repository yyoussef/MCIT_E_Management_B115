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

public partial class UserControls_Outbox_Grid_Page : System.Web.UI.UserControl
{
    Session_CS Session_CS = new Session_CS();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session_CS.pmp_id != null && CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()) > 0)
            {
                btn_show_inbox.BackColor = System.Drawing.Color.Gray;
                Session_CS.Project_id = 0;
                Load_Grid();

            }
            else
            {
                Response.Redirect("~\\Grids_Dr_Hesham.aspx");
            }


        }


    }






    private void Load_Grid()
    {
        //string todayplus1 = VB_Classes.Dates.Dates_Operation.date_validate(DateTime.Now.AddDays(1).ToShortDateString());
        //string todayplus2 = VB_Classes.Dates.Dates_Operation.date_validate(DateTime.Now.AddDays(2).ToShortDateString());


        string todayplus1 = CDataConverter.ConvertDateTimeToFormatdmy((CDataConverter.ConvertDateTimeNowRtnDt().AddDays(1)));
        string todayplus2 = CDataConverter.ConvertDateTimeToFormatdmy((CDataConverter.ConvertDateTimeNowRtnDt().AddDays(2)));

        //string today = VB_Classes.Dates.Dates_Operation.date_validate(DateTime.Now.ToShortDateString());


        string today = CDataConverter.ConvertDateTimeToFormatdmy((CDataConverter.ConvertDateTimeNowRtnDt()));
        int group = CDataConverter.ConvertToInt(Session_CS.group_id.ToString());
        int parent = CDataConverter.ConvertToInt(Session_CS.parent_id.ToString());
        int pmp = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
        DataTable dt_Outbox_new = new DataTable();
        DataTable dt_Outbox_old = new DataTable();
        DataTable dt_Outbox_late = new DataTable();
        DataTable dt_Outbox_closed = new DataTable();
        DataTable dt_Outbox_follow = new DataTable();
        DataTable dt_Outbox_not_sent_visa = new DataTable();
        DataTable dt_Outbox_sent_visa = new DataTable();
        int active = 0;

        if (Request["Type"].ToString() == "1")
        {
            dt_Outbox_new = Outbox_class.new_Outbox_all(parent, group, pmp, active);
            tr_lbl_notsent.Visible = false;
            tr_lbl_sent.Visible = false;
            gvMain.Visible = true;
            gvMain.DataSource = dt_Outbox_new;
            gvMain.DataBind();
            lblMain.Text = "قائمة الصادر الجديد";
        }
        if (Request["Type"].ToString() == "visa")
        {

            dt_Outbox_not_sent_visa = Outbox_class.getOutbox_not_sent_visa(group);
            dt_Outbox_sent_visa = Outbox_class.getOutbox_sent_visa(group);

            gvMain.Visible = true;
            gvMain_Not_send_Visa.Visible = true;


            gvMain_Not_send_Visa.DataSource = dt_Outbox_not_sent_visa;
            gvMain.DataSource = dt_Outbox_sent_visa;

            gvMain_Not_send_Visa.DataBind();
            gvMain.DataBind();
            lblMain.Visible = false;
            Label_not_Send.Visible = true;
            Label_sent.Visible = true;
        }


        else if (Request["Type"].ToString() == "2")
        {
            //string sql_inbox_have_follow = sql_for_follow_only + "AND inbox_follow_emp.Have_follow=1 AND inbox_follow_emp.pmp_id =" + CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
            //DataTable dt_inbox_have_follow = General_Helping.GetDataTable(sql_inbox_have_follow);
            dt_Outbox_follow = Outbox_class.follow_Outbox_all(parent, group, pmp, active);
            gvMain.Visible = true;
            tr_lbl_notsent.Visible = false;
            tr_lbl_sent.Visible = false;

            gvMain.DataSource = dt_Outbox_follow;
            gvMain.DataBind();
            lblMain.Text = "قائمة الصادر الذي له متابعة";
        }
        else if (Request["Type"].ToString() == "10")
        {

            dt_Outbox_late = Outbox_class.late_Outbox_all(parent, group, pmp, todayplus1, todayplus2, active);
            gvMain.Visible = true;

            tr_lbl_notsent.Visible = false;
            tr_lbl_sent.Visible = false;
            gvMain.DataSource = dt_Outbox_late;
            gvMain.DataBind();
            lblMain.Text = "قائمة الصادر المتاخر";
        }
        else if (Request["Type"].ToString() == "3")
        {

            //string sql_inbox_old = main_sql_dr_hesham + " AND status=0 and From_Inbox_View.ID not in(select inbox_id from dbo.inbox_follow_emp  where inbox_follow_emp.Have_follow=1 and pmp_id =" + Session_CS.pmp_id + ")" + "or ( Inbox_Track_Emp.Emp_ID = " + CDataConverter.ConvertToInt(Session["parent_id"]) + " and Inbox_Status=2)";
            //DataTable dt_inbox_old = General_Helping.GetDataTable(sql_inbox_old);
            dt_Outbox_old = Outbox_class.old_Outbox_all(parent, group, pmp, active);
            gvMain.Visible = true;

            tr_lbl_notsent.Visible = false;
            tr_lbl_sent.Visible = false;

            gvMain.DataSource = dt_Outbox_old;
            gvMain.DataBind();
            lblMain.Text = "قائمة الصادر الجاري";
        }



        else if (Request["Type"].ToString() == "5")
        {
            //string sql_inbox_closed = main_sql_dr_hesham + " AND status=3 order by Inbox_Track_Manager.inbox_id desc";
            //DataTable dt_inbox_closed = General_Helping.GetDataTable(sql_inbox_closed);
            dt_Outbox_closed = Outbox_class.closed_Outbox_all(parent, group, pmp, active);
            gvMain.Visible = true;


            tr_lbl_notsent.Visible = false;
            tr_lbl_sent.Visible = false;
            gvMain.DataSource = dt_Outbox_closed;
            gvMain.DataBind();
            lblMain.Text = "قائمة الصادر المنتهي";
        }





        if (Request["Type"].ToString() == "5")
        {
            gvMain.Columns[7].Visible = false;
            btn_close_Outbox.Visible = false;
        }

        ////////////////////////////////////////////////////////////////////////





    }



    protected void gvMain_Not_send_Visa_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "show_inbox_Details")
        {
            string encrypted = Encryption.Encrypt(e.CommandArgument.ToString());
            Response.Redirect("Project_Outbox.aspx?id=" + encrypted);



        }

    }
    protected void btn_close_Outbox_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow grdrow in gvMain.Rows)
        {
            CheckBox chk = (CheckBox)grdrow.FindControl("chk1");
            if (chk.Checked)
            {
                string hidden_Id = ((Label)grdrow.FindControl("lbl_inbox_id")).Text;
                DataTable dt_close = General_Helping.GetDataTable("select group_id from Outbox where id = " + CDataConverter.ConvertToInt(hidden_Id));
                if (CDataConverter.ConvertToInt(dt_close.Rows[0]["group_id"].ToString()) == CDataConverter.ConvertToInt(Session_CS.group_id))
                {
                    DataTable DT = new DataTable();
                    DT = General_Helping.GetDataTable("select * from Outbox_Track_Manager where Outbox_id = " + hidden_Id);
                    if (DT.Rows.Count > 0)
                    {
                        string sql = "update Outbox_Track_Manager set All_visa_sent=0,Have_Visa=0,status=3 where Outbox_id =" + hidden_Id;
                        General_Helping.ExcuteQuery(sql);
                    }
                    DataTable dt_Inbox_Visa = General_Helping.GetDataTable("select * from Outbox_Track_Emp where Outbox_id =" + hidden_Id);
                    foreach (DataRow item in dt_Inbox_Visa.Rows)
                    {
                        Outbox_DB.update_Outbox_Track_Emp(hidden_Id, item["Emp_ID"].ToString(), 3, 1);
                    }

                    Outbox_Visa_Follows_DT obj = new Outbox_Visa_Follows_DT();// Inbox_Visa_Follows_DB.SelectByID(CDataConverter.ConvertToInt(hidden_Follow_ID.Value));
                    obj.Outbox_ID = CDataConverter.ConvertToInt(hidden_Id);
                    obj.Descrption = "تم إغلاق الموضوع";
                    // string date = DateTime.Now.ToShortDateString().ToString();

                    string date = CDataConverter.ConvertDateTimeToFormatdmy(CDataConverter.ConvertDateTimeNowRtnDt());
                    obj.Date = date;
                    //obj.time_follow = DateTime.UtcNow.ToLocalTime().ToLongTimeString();
                    obj.time_follow = CDataConverter.ConvertDateTimeNowRtnDt().ToLongTimeString();

                    obj.entery_pmp_id = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
                    obj.Visa_Emp_id = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
                    obj.Follow_ID = Outbox_Visa_Follows_DB.Save(obj);
                    ///////////////////////////////////////////////////////////////// when dr hesham close inbox update all have follow in inbox follow emp to be zero
                    General_Helping.ExcuteQuery("update Outbox_follow_emp set Have_follow = 0 where Outbox_id = " + hidden_Id);
                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                    //Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('تم إغلاق الموضوع بنجاح' )</script>");
                    Load_Grid();

                }
                else
                {
                    ShowAlertMessage(" غير مسموح بغلق هذا الموضوع"); return;
                }
                ///////////// change status = 3  /////////////////////////////////////////////

            }

        }

    }
    protected void btn_show_inbox_Click(object sender, EventArgs e)
    {
        Outbox_tb.Visible = true;
        emp_tb.Visible = false;
        btn_show_inbox.BackColor = System.Drawing.Color.Gray;
        //btn_show_emp.BackColor = System.Drawing.Co;
        btn_show_emp.BackColor = System.Drawing.ColorTranslator.FromHtml("#C2DDF0");
        //btn_show_emp.CssClass = "button";

    }
    protected void btn_show_emp_Click(object sender, EventArgs e)
    {
        btn_show_emp.BackColor = System.Drawing.Color.Gray;
        // btn_show_inbox.Style.Add("background-color", "#C2DDF0");
        btn_show_inbox.BackColor = System.Drawing.ColorTranslator.FromHtml("#C2DDF0");
        //btn_show_inbox.CssClass = "button";
        int group = CDataConverter.ConvertToInt(Session_CS.group_id.ToString());
        int parent = CDataConverter.ConvertToInt(Session_CS.parent_id.ToString());
        string todayplus1 = CDataConverter.ConvertDateTimeToFormatdmy(CDataConverter.ConvertDateTimeNowRtnDt().AddDays(1)); //DateTime.ParseExact(DateTime.Now.AddDays(1).ToString("dd/MM/yyyy"), "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
        string todayplus2 = CDataConverter.ConvertDateTimeToFormatdmy(CDataConverter.ConvertDateTimeNowRtnDt().AddDays(2));//DateTime.ParseExact(DateTime.Now.AddDays(2).ToString("dd/MM/yyyy"), "dd/MM/yyyy", null).ToString("dd/MM/yyyy");


        //string todayplus1 = CDataConverter.ConvertDateTimeNowRtnDt().AddDays(1).ToShortDateString();
        //string todayplus2 = CDataConverter.ConvertDateTimeNowRtnDt().AddDays(2).ToShortDateString();
        int pmp = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
        int active = 1;
        emp_tb.Visible = true;
        Outbox_tb.Visible = false;
        string ids = "";
        DataTable dt_all = new DataTable();
        if (Request["Type"].ToString() == "1")
        {
            dt_all = Outbox_class.new_Outbox_all(parent, group, pmp, active);
        }
        else if (Request["Type"].ToString() == "3")
        {
            dt_all = Outbox_class.old_Outbox_all(parent, group, pmp, active);
        }
        else if (Request["Type"].ToString() == "10")
        {
            dt_all = Outbox_class.late_Outbox_all(parent, group, pmp, todayplus1, todayplus2, active);
        }
        else if (Request["Type"].ToString() == "5")
        {
            dt_all = Outbox_class.closed_Outbox_all(parent, group, pmp, active);
        }
        else if (Request["Type"].ToString() == "2")
        {
            dt_all = Outbox_class.follow_Outbox_all(parent, group, pmp, active);
        }

        ViewState["dt_Outbox_old"] = dt_all;
        //DataTable resultDT = dt_all.Clone();
        //ViewState["resultDT"] = resultDT;
        for (int i = 0; i < dt_all.Rows.Count; i++)
        {
            ids = ids + "0" + dt_all.Rows[i]["empids"].ToString() + "0";
            //ids = ids + dt_all.Rows[i]["empids"].ToString();
        }
        DataTable dt = new DataTable();
        dt = General_Helping.GetDataTable("select pmp_id,pmp_name from employee where pmp_id in ( " + ids + ") order by ltrim(pmp_name)");

        //string[] res = ids.Split(',');
        //string[] res2 = res.Distinct().ToArray();
        //res2 = res2.Where(r => !string.IsNullOrEmpty(r)).ToArray();
        //DataTable dtemp = new DataTable();
        //DataTable dt = new DataTable();
        //dt.Columns.Add("pmp_id", typeof(int));
        //dt.Columns.Add("pmp_Name", typeof(string));
        //foreach (string id in res2)
        //{
        //    dtemp = General_Helping.GetDataTable("select pmp_name from employee where pmp_id = " + CDataConverter.ConvertToInt(id));
        //    dt.Rows.Add(CDataConverter.ConvertToInt(id), dtemp.Rows[0]["pmp_name"].ToString());
        //}
        lv1.DataSource = dt;
        lv1.DataBind();

    }
    protected void lv1_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        GridView gvinbox = (GridView)e.Item.FindControl("gv_in");
        HtmlInputHidden idhidden = (HtmlInputHidden)e.Item.FindControl("id");
        DataTable dt_inbox_old = ViewState["dt_Outbox_old"] as DataTable;
        DataTable resultDT = dt_inbox_old.Clone();//ViewState["resultDT"] as DataTable;
        DataRow[] foundRows;
        foundRows = dt_inbox_old.Select("empids" + " like '%," + CDataConverter.ConvertToInt(idhidden.Value) + ",%'");
        for (int i = 0; i < foundRows.Length; i++)
        {

            resultDT.ImportRow(foundRows[i]);
            resultDT.AcceptChanges();


        }
        gvinbox.DataSource = resultDT;
        gvinbox.DataBind();
        resultDT.Clear();





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

    protected void gvMain_Not_send_Visa_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvMain_Not_send_Visa.PageIndex = e.NewPageIndex;
        Load_Grid();
    }
    protected void gvMain_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvMain.PageIndex = e.NewPageIndex;
        Load_Grid();
    }

    protected void gvMain_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        // SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        //if (e.CommandName == "show_Outbox_Details")
        //{
        //    string encrypted = Encryption.Encrypt(e.CommandArgument.ToString());

        //    if (Request["Type"].ToString() == "1" || Request["Type"].ToString() == "2")
        //    {
        //        if (CDataConverter.ConvertToInt(Session_CS.parent_id.ToString()) > 0)
        //        {
        //            Outbox_DB.update_Outbox_Track_Manager(e.CommandArgument.ToString(), 0);
        //        }
        //        else
        //        {

        //            Outbox_DB.update_Outbox_Track_Emp(e.CommandArgument.ToString(), Session_CS.pmp_id.ToString(), 2, 1);
        //        }




        //        Response.Redirect("ViewProjectOutbox.aspx?id=" + encrypted);
        //    }
        //    else if (Request["Type"].ToString() == "3" || Request["Type"].ToString() == "5" || Request["Type"].ToString() == "10")
        //    {
        //        if (CDataConverter.ConvertToInt(Session_CS.parent_id.ToString()) > 0)
        //        {
        //            Response.Redirect("ViewProjectOutbox.aspx?id=" + encrypted);
        //        }
        //        if (CDataConverter.ConvertToInt(Session_CS.child_emp.ToString()) > 0)
        //        {

        //            int id = CDataConverter.ConvertToInt(e.CommandArgument);
        //            DataTable dtsec = General_Helping.GetDataTable("select pmp_pmp_id from Outbox where id = " + id);
        //            if (CDataConverter.ConvertToInt(dtsec.Rows[0]["pmp_pmp_id"].ToString()) == Session_CS.pmp_id)
        //            {
        //                Response.Redirect("Project_Outbox.aspx?id=" + encrypted);
        //            }
        //            else
        //                Response.Redirect("ViewProjectOutbox.aspx?id=" + encrypted);
        //        }
        //        else
        //        {
        //            Response.Redirect("ViewProjectOutbox.aspx?id=" + encrypted);
        //        }
        //    }


        //}



    }
    protected void gv_in_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        // SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        //if (e.CommandName == "show_Outbox_Details")
        //{
        //    string encrypted = Encryption.Encrypt(e.CommandArgument.ToString());

        //    if (Request["Type"].ToString() == "1" || Request["Type"].ToString() == "2")
        //    {
        //        if (CDataConverter.ConvertToInt(Session_CS.parent_id.ToString()) > 0)
        //        {
        //            Outbox_DB.update_Outbox_Track_Manager(e.CommandArgument.ToString(), 0);
        //        }
        //        else
        //        {

        //            Outbox_DB.update_Outbox_Track_Emp(e.CommandArgument.ToString(), Session_CS.pmp_id.ToString(), 2, 1);
        //        }




        //        Response.Redirect("ViewProjectOutbox.aspx?id=" + encrypted);
        //    }
        //    else if (Request["Type"].ToString() == "3" || Request["Type"].ToString() == "5" || Request["Type"].ToString() == "10")
        //    {
        //        if (CDataConverter.ConvertToInt(Session_CS.parent_id.ToString()) > 0)
        //        {
        //            Response.Redirect("ViewProjectOutbox.aspx?id=" + encrypted);
        //        }
        //        if (CDataConverter.ConvertToInt(Session_CS.child_emp.ToString()) > 0)
        //        {

        //            int id = CDataConverter.ConvertToInt(e.CommandArgument);
        //            DataTable dtsec = General_Helping.GetDataTable("select pmp_pmp_id from Outbox where id = " + id);
        //            if (CDataConverter.ConvertToInt(dtsec.Rows[0]["pmp_pmp_id"].ToString()) == Session_CS.pmp_id)
        //            {
        //                Response.Redirect("Project_Outbox.aspx?id=" + encrypted);
        //            }
        //            else
        //                Response.Redirect("ViewProjectOutbox.aspx?id=" + encrypted);
        //        }
        //        else
        //        {
        //            Response.Redirect("ViewProjectOutbox.aspx?id=" + encrypted);
        //        }
        //    }


        //}



    }



    public string GetUrl(object id)
    {

       string url = "";


      

       if (Request["Type"].ToString() == "1" || Request["Type"].ToString() == "2")
       {
           if (CDataConverter.ConvertToInt(Session_CS.parent_id.ToString()) > 0)
           {
               Outbox_DB.update_Outbox_Track_Manager(id.ToString(), 0);
           }
           else
           {

               Outbox_DB.update_Outbox_Track_Emp(id.ToString(), Session_CS.pmp_id.ToString(), 2, 1);
           }

           url = "~/MainForm/ViewProjectOutbox.aspx?id=" + Encryption.Encrypt(id.ToString());

       }
       else if (Request["Type"].ToString() == "3" || Request["Type"].ToString() == "5" || Request["Type"].ToString() == "10")
       {
           if (CDataConverter.ConvertToInt(Session_CS.parent_id.ToString()) > 0)
           {
               

               url = "~/MainForm/ViewProjectOutbox.aspx?id=" + Encryption.Encrypt(id.ToString());
           }
           if (CDataConverter.ConvertToInt(Session_CS.child_emp.ToString()) > 0)
           {

              
               DataTable dtsec = General_Helping.GetDataTable("select pmp_pmp_id from Outbox where id = " + id);
               if (CDataConverter.ConvertToInt(dtsec.Rows[0]["pmp_pmp_id"].ToString()) == Session_CS.pmp_id)
               {
                 
                   url = "~/MainForm/Project_Outbox.aspx?id=" + Encryption.Encrypt(id.ToString());
               }
               else
                   url = "~/MainForm/ViewProjectOutbox.aspx?id=" + Encryption.Encrypt(id.ToString());
           }
           else
           {
               url = "~/MainForm/ViewProjectOutbox.aspx?id=" + Encryption.Encrypt(id.ToString());
           }
       }

        return url;
    }
    protected void ImgBtnBack_Click(object sender, System.Web.UI.ImageClickEventArgs e)
    {
        Response.Redirect("~/MainForm/Default.aspx");
    }
}
