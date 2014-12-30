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
using System.Security.Cryptography;
using System.Text;
using System.IO;
using System.Drawing;

public partial class UserControls_Inbox_Grid_Page_HM : System.Web.UI.UserControl
{
    //Session_CS Session_CS = new Session_CS();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session_CS.parent_id = -2;
            if (Session_CS.pmp_id != null && CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()) > 0)
            {
                Session_CS.Project_id = 0;
                Load_Grid_Dr_Hesham();

            }
            else
            {
                Response.Redirect("~\\Grids_Dr_Hesham.aspx");
            }


        }


    }

    //private void MergeGridviewRows(GridView gridView)
    //{
    //    for (int rowIndex = gridView.Rows.Count - 2; rowIndex >= 0; rowIndex--)
    //    {
    //        GridViewRow row = gridView.Rows[rowIndex];
    //        GridViewRow previousRow = gridView.Rows[rowIndex + 1];

    //        if (row.Cells[5].Text == previousRow.Cells[5].Text)
    //        {
    //            row.Cells[5].RowSpan = previousRow.Cells[5].RowSpan < 2 ? 2 : previousRow.Cells[5].RowSpan + 1;
    //            //row.Cells[1].RowSpan = previousRow.Cells[1].RowSpan < 2 ? 2 : previousRow.Cells[1].RowSpan + 1;

    //            //previousRow.Cells[6].Visible = false;
    //            //previousRow.Cells[1].Visible = false;
    //        }
    //    }
    //}

    //protected void gvMain_PreRender(object sender, EventArgs e)
    //{
    //    MergeGridviewRows(gvMain);
    //}

    //protected void gvMain_OnSorting(Object sender, GridViewSortEventArgs e)
    //{
    //    ViewState["sortExpr"] = e.SortExpression; Load_Grid_Dr_Hesham();
    //    gvMain.DataBind();
    //}
    private void helper_GroupHeader(string groupName, object[] values, GridViewRow row)
    {
        if (groupName == "pmp_name")
        {
            row.BackColor = Color.LightGray;
            row.Cells[0].Text = "&nbsp;&nbsp;" + row.Cells[0].Text;
        }
    }
    private void Load_Grid_Dr_Hesham()
    {
        //string todayplus1 = VB_Classes.Dates.Dates_Operation.date_validate(DateTime.Now.AddDays(1).ToShortDateString());
        //string todayplus2 = VB_Classes.Dates.Dates_Operation.date_validate(DateTime.Now.AddDays(2).ToShortDateString());
        string todayplus1 =CDataConverter.ConvertDateTimeToFormatdmy(CDataConverter.ConvertDateTimeNowRtnDt().AddDays(1));
        string todayplus2 =CDataConverter.ConvertDateTimeToFormatdmy(CDataConverter.ConvertDateTimeNowRtnDt().AddDays(2));

        string today = CDataConverter.ConvertDateTimeToFormatdmy((CDataConverter.ConvertDateTimeNowRtnDt()));
        int group = CDataConverter.ConvertToInt(Session_CS.group_id.ToString());
        int parent = CDataConverter.ConvertToInt(Session_CS.parent_id.ToString());
        int child = CDataConverter.ConvertToInt(Session_CS.child_emp.ToString());
        int parentbychild_for_visa = CDataConverter.ConvertToInt(Session_CS.parent_id.ToString());

        int pmp = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
        DataTable dt_inbox_late = new DataTable();
        DataTable dt_inbox_new = new DataTable();
        DataTable dt_inbox_old = new DataTable();
        DataTable dt_inbox_closed = new DataTable();
        DataTable dt_inbox_follow = new DataTable();
        DataTable dt_inbox_understudy = new DataTable();
        DataTable dt_inbox_not_sent_visa = new DataTable();
        DataTable dt_inbox_sent_visa = new DataTable();
        int active = 0;


        tbl_grd.Visible = true;
        ////////////////////////////////////////////////////////////////////////////////////////////////////////
        if (Request["Type"].ToString() == "1")
        {
            dt_inbox_new = Inbox_class.new_inbox_all(parent, group, pmp, active);
            tr_lbl_notsent.Visible = false;
            tr_lbl_sent.Visible = false;
            gvMain.Visible = true;


            gvMain.DataSource = dt_inbox_new;
            gvMain.DataBind();
            GridViewHelper helper = new GridViewHelper(this.gvMain);
            helper.RegisterGroup("pmp_name", true, true);
            helper.GroupHeader += new GroupEvent(helper_GroupHeader);
            helper.ApplyGroupSort();


            //GridViewHelper helper = new GridViewHelper(this.gvMain);
            //helper.RegisterGroup("pmp_name", true, true);
            //helper.ApplyGroupSort();
            //GroupGridView(gvMain.Rows, 0, 1);
           // MergeGridviewRows(gvMain);
            lblMain.Text = "قائمة الوارد الجديد";
        }
        if (Request["Type"].ToString() == "visa")
        {
            dt_inbox_not_sent_visa = Inbox_class.getinbox_not_sent_visa(group, parentbychild_for_visa);
            dt_inbox_sent_visa = Inbox_class.getinbox_sent_visa(group, parentbychild_for_visa);

            gvMain.Visible = true;
            gvMain_Not_send_Visa.Visible = true;

            gvMain_Not_send_Visa.DataSource = dt_inbox_not_sent_visa;
            gvMain.DataSource = dt_inbox_sent_visa;

            gvMain_Not_send_Visa.DataBind();
            gvMain.DataBind();
            lblMain.Visible = false;
            Label_not_Send.Visible = true;
            Label_sent.Visible = true;
        }


        else if (Request["Type"].ToString() == "2")
        {

            dt_inbox_follow = Inbox_class.follow_inbox_all(parent, pmp, active);
            gvMain.Visible = true;
            tr_lbl_notsent.Visible = false;
            tr_lbl_sent.Visible = false;

            gvMain.DataSource = dt_inbox_follow;
            gvMain.DataBind();
            lblMain.Text = "قائمة الوارد الذي له متابعة";
        }

        else if (Request["Type"].ToString() == "3")
        {

            dt_inbox_old = Inbox_class.old_inbox_all(parent, group, pmp, active);
            gvMain.Visible = true;

            tr_lbl_notsent.Visible = false;
            tr_lbl_sent.Visible = false;

            gvMain.DataSource = dt_inbox_old;
            gvMain.DataBind();
            lblMain.Text = "قائمة الوارد الجاري";
        }
        else if (Request["Type"].ToString() == "10")
        {

            dt_inbox_late = Inbox_class.late_inbox_all(parent, group, pmp, todayplus1, todayplus2, active);
            gvMain.Visible = true;

            tr_lbl_notsent.Visible = false;
            tr_lbl_sent.Visible = false;
            gvMain.DataSource = dt_inbox_late;
            gvMain.DataBind();
            lblMain.Text = "قائمة الوارد المتاخر";
        }


        else if (Request["Type"].ToString() == "5")
        {
            dt_inbox_closed = Inbox_class.closed_inbox_all(parent, group, pmp, active);
            gvMain.Visible = true;


            tr_lbl_notsent.Visible = false;
            tr_lbl_sent.Visible = false;
            gvMain.DataSource = dt_inbox_closed;
            gvMain.DataBind();
            lblMain.Text = "قائمة الوارد المنتهي";
        }

        else if (Request["Type"].ToString() == "4")
        {
            dt_inbox_understudy = Inbox_class.understudy_inbox_all(group, active);
            gvMain.Visible = true;

            gvMain.DataSource = dt_inbox_understudy;
            gvMain.DataBind();
            tr_lbl_notsent.Visible = false;
            tr_lbl_sent.Visible = false;
            lblMain.Text = "قائمة الوارد تحت الدراسة";
        }


        if (Request["Type"].ToString() == "3" || Request["Type"].ToString() == "10")
        {

            if (parent > 0)
            {
                btn_close_inbox.Visible = true;
                gvMain.Columns[8].Visible = true;
            }
            else
            {
                gvMain.Columns[8].Visible = false;
                btn_close_inbox.Visible = false;
            }
        }
        else
        {
            gvMain.Columns[8].Visible = false;
            btn_close_inbox.Visible = false;
        }

        ////////////////////////////////////////////////////////////////////////





    }


    protected void gv_Review_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "show_Review_Details")
        {


            Response.Redirect("..\\WebForms2\\ViewProjectReview.aspx?id=" + e.CommandArgument);
        }


    }
    protected void gv_com_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "show_com_Details")
        {
            Response.Redirect("..\\WebForms2\\View_Commission.aspx?id=" + e.CommandArgument);
        }


    }
    protected void gvMain_Not_send_Visa_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "show_inbox_Details")
        {
            string encrypted = Encryption.Encrypt(e.CommandArgument.ToString());
            //Session["encrypted"] = encrypted;

            Response.Redirect("Project_Inbox.aspx?id=" + encrypted);



        }

    }
    protected void btn_close_inbox_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow grdrow in gvMain.Rows)
        {
            CheckBox chk = (CheckBox)grdrow.FindControl("chk1");
            if (chk.Checked)
            {
                string hidden_Id = ((Label)grdrow.FindControl("lbl_inbox_id")).Text;
                DataTable dt_close = General_Helping.GetDataTable("select group_id from inbox where id = " + CDataConverter.ConvertToInt(hidden_Id));
                if (CDataConverter.ConvertToInt(dt_close.Rows[0]["group_id"].ToString()) == CDataConverter.ConvertToInt(Session_CS.group_id))
                {
                    DataTable DT = new DataTable();
                    DT = General_Helping.GetDataTable("select * from Inbox_Track_Manager where inbox_id = " + hidden_Id);
                    if (DT.Rows.Count > 0)
                    {
                        string sql = "update Inbox_Track_Manager set Have_Follow=0,All_visa_sent=0,Have_Visa=0,status=3 where inbox_id =" + hidden_Id;
                        General_Helping.ExcuteQuery(sql);
                    }
                    DataTable dt_Inbox_Visa = General_Helping.GetDataTable("select * from Inbox_Track_Emp where inbox_id =" + hidden_Id);
                    foreach (DataRow item in dt_Inbox_Visa.Rows)
                    {
                        Inbox_DB.update_inbox_Track_Emp(hidden_Id, item["Emp_ID"].ToString(), 3, 1);
                    }

                    Inbox_Visa_Follows_DT obj = new Inbox_Visa_Follows_DT();// Inbox_Visa_Follows_DB.SelectByID(CDataConverter.ConvertToInt(hidden_Follow_ID.Value));
                    obj.Inbox_ID = CDataConverter.ConvertToInt(hidden_Id);
                    obj.Descrption = "تم إغلاق الموضوع";
                   // string date = DateTime.Now.ToShortDateString().ToString();

                    string date = CDataConverter.ConvertDateTimeToFormatdmy(CDataConverter.ConvertDateTimeNowRtnDt());
                    obj.Date = date;
                   // obj.time_follow = DateTime.UtcNow.ToLocalTime().ToLongTimeString();

                 obj.time_follow = CDataConverter.ConvertDateTimeNowRtnDt().ToLongTimeString();
                    obj.entery_pmp_id = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
                    obj.Visa_Emp_id = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
                    obj.Follow_ID = Inbox_Visa_Follows_DB.Save(obj);
                    ///////////////////////////////////////////////////////////////// when dr hesham close inbox update all have follow in inbox follow emp to be zero
                    General_Helping.ExcuteQuery("update inbox_follow_emp set Have_follow = 0 where inbox_id = " + hidden_Id);
                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                    //Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('تم إغلاق الموضوع بنجاح' )</script>");
                    Load_Grid_Dr_Hesham();

                }
                else
                {
                    ShowAlertMessage(" غير مسموح بغلق هذا الموضوع"); return;
                }

                ///////////// change status = 3  /////////////////////////////////////////////
              

            }

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
    protected void gvMain_Not_send_Visa_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvMain_Not_send_Visa.PageIndex = e.NewPageIndex;
        Load_Grid_Dr_Hesham();
    }
    protected void gvMain_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvMain.PageIndex = e.NewPageIndex;
        Load_Grid_Dr_Hesham();
    }
    public string Encode(string encodeMe)
    {
        byte[] encoded = System.Text.Encoding.UTF8.GetBytes(encodeMe);
        return Convert.ToBase64String(encoded);
    }
    //public static string Encrypt(string pstrText)
    //{
    //    string pstrEncrKey = "1239;[pewGKG)NisarFidesTech";
    //    byte[] byKey = { };
    //    byte[] IV = { 18, 52, 86, 120, 144, 171, 205, 239 };
    //    byKey = System.Text.Encoding.UTF8.GetBytes(pstrEncrKey.Substring(0, 8));
    //    DESCryptoServiceProvider des = new DESCryptoServiceProvider();
    //    byte[] inputByteArray = Encoding.UTF8.GetBytes(pstrText);
    //    MemoryStream ms = new MemoryStream();
    //    CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(byKey, IV), CryptoStreamMode.Write);
    //    cs.Write(inputByteArray, 0, inputByteArray.Length);
    //    cs.FlushFinalBlock();
    //    return Convert.ToBase64String(ms.ToArray());
    //}
    protected void gvMain_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        
        if (e.CommandName == "show_inbox_Details")
        {
            string encrypted = Encryption.Encrypt(e.CommandArgument.ToString());
           

            if (Request["Type"].ToString() == "1" || Request["Type"].ToString() == "6" )
            {

                if (CDataConverter.ConvertToInt(Session_CS.parent_id.ToString()) > 0)
                {
                    
                    
                    Response.Redirect("ViewProjectInbox.aspx?id=" + encrypted);

                }
                if (CDataConverter.ConvertToInt(Session_CS.child_emp.ToString()) > 0)
                {
                    int id =CDataConverter.ConvertToInt( e.CommandArgument);
                    DataTable dtsec = General_Helping.GetDataTable("select pmp_pmp_id from inbox where id = " + id);
                    if (CDataConverter.ConvertToInt( dtsec.Rows[0]["pmp_pmp_id"].ToString() )== Session_CS.pmp_id)
                    {
                        Response.Redirect("Project_Inbox.aspx?id=" + encrypted);
                    }
                    else
                        Response.Redirect("ViewProjectInbox.aspx?id=" + encrypted);

                }
                else
                {
                   
                    Response.Redirect("ViewProjectInbox.aspx?id=" + encrypted);

                }


            }
            else if (Request["Type"].ToString() == "2" || Request["Type"].ToString() == "3" || Request["Type"].ToString() == "4" || Request["Type"].ToString() == "10" || Request["Type"].ToString() == "5" || Request["Type"].ToString() == "11" || Request["Type"].ToString() == "visa")
            {
                if (CDataConverter.ConvertToInt(Session_CS.parent_id.ToString()) > 0)
                {
                    Response.Redirect("ViewProjectInbox.aspx?id=" + encrypted);
                    
                }
                if (CDataConverter.ConvertToInt(Session_CS.child_emp.ToString()) > 0)
                {
                    int id =CDataConverter.ConvertToInt( e.CommandArgument);
                    DataTable dtsec = General_Helping.GetDataTable("select pmp_pmp_id from inbox where id = " + id);
                    if (CDataConverter.ConvertToInt(dtsec.Rows[0]["pmp_pmp_id"].ToString()) == Session_CS.pmp_id)
                    {
                        Response.Redirect("Project_Inbox.aspx?id=" + encrypted);
                    }
                    else
                        Response.Redirect("ViewProjectInbox.aspx?id=" + encrypted);
                }
                else
                {
                    Response.Redirect("ViewProjectInbox.aspx?id=" + encrypted);
                }

            }



        }



    }
    protected void ImgBtnBack_Click(object sender, System.Web.UI.ImageClickEventArgs e)
    {
        Response.Redirect("~/MainForm/Default.aspx");
    }

    void GroupGridView(GridViewRowCollection gvrc, int startIndex, int total)
    {

        if (total == 0) return;
        int i, count = 1;
        ArrayList lst = new ArrayList();
        lst.Add(gvrc[0]);
        var ctrl = gvrc[0].Cells[startIndex];
        for (i = 1; i < gvrc.Count; i++)
        {
            TableCell nextCell = gvrc[i].Cells[startIndex];
            if (ctrl.Text == nextCell.Text)
            {
                count++;
                nextCell.Visible = false;
                lst.Add(gvrc[i]);
            }
            else
            {
                if (count > 1)
                {
                    ctrl.RowSpan = count;
                    GroupGridView(new GridViewRowCollection(lst), startIndex + 1, total - 1);
                }
                count = 1;
                lst.Clear();
                ctrl = gvrc[i].Cells[startIndex];
                lst.Add(gvrc[i]);
            }
        }
        if (count > 1)
        {
            ctrl.RowSpan = count;
            GroupGridView(new GridViewRowCollection(lst), startIndex + 1, total - 1);
        }
        count = 1;
        lst.Clear();
    }
    protected void gvMain_DataBound(object sender, EventArgs e)
    {
        //for (int i = gvMain.Rows.Count - 1; i > 0; i--)
        //{
        //    GridViewRow row = gvMain.Rows[i];
        //    GridViewRow previousRow = gvMain.Rows[i - 1];
        //    for (int j = 0; j < row.Cells.Count; j++)
        //    {
        //        if (row.Cells[j].Text == previousRow.Cells[j].Text)
        //        {
        //            if (previousRow.Cells[j].RowSpan == 0)
        //            {
        //                if (row.Cells[j].RowSpan == 0)
        //                {
        //                    previousRow.Cells[j].RowSpan += 2;
        //                }
        //                else
        //                {
        //                    previousRow.Cells[j].RowSpan = row.Cells[j].RowSpan + 1;
        //                }
        //                row.Cells[j].Visible = false;
        //            }
        //        }
        //    }
        //}
    }
    protected void gvMain_Sorting(object sender, GridViewSortEventArgs e)
    {

    }
}
