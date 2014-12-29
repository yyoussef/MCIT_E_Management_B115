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

public partial class UserControls_Inbox_Grid_Page : System.Web.UI.UserControl
{
    Session_CS Session_CS = new Session_CS();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session_CS.pmp_id != null && CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString()) > 0)
            {
                inbox_tb.Visible = true;
                btn_show_inbox.BackColor = System.Drawing.Color.Gray;
                Session_CS.Project_id = 0;
                Load_Grid_Dr_Hesham();
              

            }
            else
            {
                Response.Redirect("~\\Grids_Dr_Hesham.aspx");
            }


        }


    }






    private void Load_Grid_Dr_Hesham()
    {
        //string todayplus1 = VB_Classes.Dates.Dates_Operation.date_validate(DateTime.Now.AddDays(1).ToShortDateString());
        //string todayplus2 = VB_Classes.Dates.Dates_Operation.date_validate(DateTime.Now.AddDays(2).ToShortDateString());
        string todayplus1 = DateTime.ParseExact(CDataConverter.ConvertDateTimeNowRtnDt().AddDays(1).ToString("dd/MM/yyyy"), "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
        string todayplus2 = DateTime.ParseExact(CDataConverter.ConvertDateTimeNowRtnDt().AddDays(2).ToString("dd/MM/yyyy"), "dd/MM/yyyy", null).ToString("dd/MM/yyyy");

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
            btn_show_emp.Visible = false;
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
                    string date = CDataConverter.ConvertDateTimeToFormatdmy(CDataConverter.ConvertDateTimeNowRtnDt());
                    obj.Date = date;
                    obj.time_follow = DateTime.UtcNow.ToLocalTime().ToLongTimeString();
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

    protected void btn_show_inbox_Click(object sender, EventArgs e)
    {
        inbox_tb.Visible = true;
        emp_tb.Visible = false;
        btn_show_inbox.BackColor = System.Drawing.Color.Gray;
        //btn_show_emp.BackColor = System.Drawing.Co;
        btn_show_emp.BackColor = System.Drawing.ColorTranslator.FromHtml("#C2DDF0");
        Load_Grid_Dr_Hesham();
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
        string todayplus1 =CDataConverter.ConvertDateTimeToFormatdmy(CDataConverter.ConvertDateTimeNowRtnDt().AddDays(1)); //DateTime.ParseExact(CDataConverter.ConvertDateTimeNowRtnDt().AddDays(1).ToString("dd/MM/yyyy"), "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
        string todayplus2 = CDataConverter.ConvertDateTimeToFormatdmy(CDataConverter.ConvertDateTimeNowRtnDt().AddDays(2));//DateTime.ParseExact(CDataConverter.ConvertDateTimeNowRtnDt().AddDays(2).ToString("dd/MM/yyyy"), "dd/MM/yyyy", null).ToString("dd/MM/yyyy");

        int pmp = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());

        emp_tb.Visible = true;
        int active = 1;
        inbox_tb.Visible = false;
        string ids = "";
        DataTable dt_all = new DataTable();
        if (Request["Type"].ToString() == "1")
        {
            dt_all = Inbox_class.new_inbox_all(parent, group, pmp, active);
        }
        else if (Request["Type"].ToString() == "3")
        {
            dt_all = Inbox_class.old_inbox_all(parent, group, pmp, active);
        }
        else if (Request["Type"].ToString() == "10")
        {
            dt_all = Inbox_class.late_inbox_all(parent, group, pmp, todayplus1, todayplus2, active);
        }
        else if (Request["Type"].ToString() == "5")
        {
            dt_all = Inbox_class.closed_inbox_all(parent, group, pmp, active);
        }
        else if (Request["Type"].ToString() == "2")
        {
            dt_all = Inbox_class.follow_inbox_all(parent, pmp, active);
        }
        else if (Request["Type"].ToString() == "4")
        {
            dt_all = Inbox_class.understudy_inbox_all(group, active);
        }
      
        ViewState["dt_inbox_old"] = dt_all;
        //DataTable resultDT = dt_all.Clone();
        //ViewState["resultDT"] = resultDT;
        for (int i = 0; i < dt_all.Rows.Count; i++)
        {
            ids = ids + "0"+dt_all.Rows[i]["empids"].ToString()+"0";
        }
        DataTable dt = new DataTable();

        dt = General_Helping.GetDataTable("select pmp_id,pmp_name from employee where pmp_id in ( " + ids + ") order by ltrim(pmp_name)");




        //string[] res = ids.Split(',');
        //string[] res2 = res.Distinct().ToArray();
        
        //res2 = res2.Where(r => !string.IsNullOrEmpty(r)).ToArray();
        
        //DataTable dt = new DataTable();
        //dt.Columns.Add("pmp_id", typeof(int));
        //dt.Columns.Add("pmp_Name", typeof(string));

        //foreach (string id in res2)
        //{
        //    dtemp = General_Helping.GetDataTable("select pmp_name from employee where pmp_id = " + CDataConverter.ConvertToInt(id) );
        //    if (dtemp.Rows.Count>0)
        //    {
        //        dt.Rows.Add(CDataConverter.ConvertToInt(id), dtemp.Rows[0]["pmp_name"].ToString());
                
        //    }
            
               
            
        //}


        //DataView _dv = new DataView(dt);
        //_dv.Sort = "LTRIM(pmp_name)";

        //dt.DefaultView.Sort = "(pmp_name)";
        //dt.Select("", "LTRIM(pmp_name)");
        lv1.DataSource = dt;
        lv1.DataBind();
      
    }
    protected void lv1_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        int group = CDataConverter.ConvertToInt(Session_CS.group_id.ToString());
        int parent = CDataConverter.ConvertToInt(Session_CS.parent_id.ToString());

        //string todayplus1 = DateTime.ParseExact(DateTime.Now.AddDays(1).ToString("dd/MM/yyyy"), "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
        //string todayplus2 = DateTime.ParseExact(DateTime.Now.AddDays(2).ToString("dd/MM/yyyy"), "dd/MM/yyyy", null).ToString("dd/MM/yyyy");

        string todayplus1 = CDataConverter.ConvertDateTimeToFormatdmy( CDataConverter.ConvertDateTimeNowRtnDt().AddDays(1));
        string todayplus2 = CDataConverter.ConvertDateTimeToFormatdmy(CDataConverter.ConvertDateTimeNowRtnDt().AddDays(2));

        int pmp = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
        
        GridView gvinbox = (GridView)e.Item.FindControl("gv_in");
        HtmlInputHidden idhidden = (HtmlInputHidden)e.Item.FindControl("id");
        DataTable dt_inbox_old = ViewState["dt_inbox_old"] as DataTable; //Inbox_class.old_inbox_all(parent, group, pmp); //
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
        //var result = dt_inbox_old.Select(x => dt_inbox_old.Rows["empids"].Contains("'," + CDataConverter.ConvertToInt(idhidden.Value) + ",'"));
        //DataRow[] foundRows = (DataRow[])result;
        //for (int i = 0; i < result.Length; i++)
        //{

        //    resultDT.ImportRow(result[i]);
        //    resultDT.AcceptChanges();


        //}
        //gvinbox.DataSource = resultDT;
        //gvinbox.DataBind();


        //var result = from myRow in dt_inbox_old.AsEnumerable() where myRow.Field<string>("empids") == ",2," select myRow;//.Contains("'," + CDataConverter.ConvertToInt(idhidden.Value) + ",'") select myRow; //select the thing you want, not the collection
        //DataView obj = result.AsDataView();
        //DataTable dt = obj.ToTable();
        //for (int i = 0; i < dt.Rows.Count; i++)
        //{

        //    resultDT.ImportRow(dt.Rows[i] );
        //    resultDT.AcceptChanges();


        //}
        //gvinbox.DataSource = resultDT;
        //gvinbox.DataBind();
        //resultDT.Clear();



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

      
      
                //if (e.CommandName == "show_inbox_Details")
                //{
                //    string encrypted = Encryption.Encrypt(e.CommandArgument.ToString());


                //    if (Request["Type"].ToString() == "1" || Request["Type"].ToString() == "6")
                //    {

                //        if (CDataConverter.ConvertToInt(Session_CS.parent_id.ToString()) > 0)
                //        {


                //          Response.Redirect("ViewProjectInbox.aspx?id=" + encrypted);
                       


                //        }
                //        if (CDataConverter.ConvertToInt(Session_CS.child_emp.ToString()) > 0)
                //        {
                //            int id = CDataConverter.ConvertToInt(e.CommandArgument);
                //            DataTable dtsec = General_Helping.GetDataTable("select pmp_pmp_id from inbox where id = " + id);
                //            if (CDataConverter.ConvertToInt(dtsec.Rows[0]["pmp_pmp_id"].ToString()) == Session_CS.pmp_id)
                //            {
                //                Response.Redirect("Project_Inbox.aspx?id=" + encrypted);


                             
                //            }
                //            else
                //              Response.Redirect("ViewProjectInbox.aspx?id=" + encrypted);
                           

                //        }
                //        else
                //        {

                //           Response.Redirect("ViewProjectInbox.aspx?id=" + encrypted);
                      

                //        }


                //    }
                //    else if (Request["Type"].ToString() == "2" || Request["Type"].ToString() == "3" || Request["Type"].ToString() == "4" || Request["Type"].ToString() == "10" || Request["Type"].ToString() == "5" || Request["Type"].ToString() == "11" || Request["Type"].ToString() == "visa")
                //    {
                //        if (CDataConverter.ConvertToInt(Session_CS.parent_id.ToString()) > 0)
                //        {
                //            Response.Redirect("ViewProjectInbox.aspx?id=" + encrypted);
                        

                //        }
                //        if (CDataConverter.ConvertToInt(Session_CS.child_emp.ToString()) > 0)
                //        {
                //            int id = CDataConverter.ConvertToInt(e.CommandArgument);
                //            DataTable dtsec = General_Helping.GetDataTable("select pmp_pmp_id from inbox where id = " + id);
                //            if (CDataConverter.ConvertToInt(dtsec.Rows[0]["pmp_pmp_id"].ToString()) == Session_CS.pmp_id)
                //            {
                //               Response.Redirect("Project_Inbox.aspx?id=" + encrypted);
                                
                //            }
                //            else
                //                Response.Redirect("ViewProjectInbox.aspx?id=" + encrypted);
                //        }
                //        else
                //        {
                //           Response.Redirect("ViewProjectInbox.aspx?id=" + encrypted);
                          
                //        }

                //    }



                //}



           
        
    }




    public string GetUrl(object id)
    {
        
        
        
        string url ="";
       

        if (Request["Type"].ToString() == "1" || Request["Type"].ToString() == "6")
        {

            if (CDataConverter.ConvertToInt(Session_CS.parent_id.ToString()) > 0)
            {


              //  Response.Redirect("ViewProjectInbox.aspx?id=" + encrypted);

                url= "~/MainForm/ViewProjectInbox.aspx?id=" + Encryption.Encrypt(id.ToString());

            }
            if (CDataConverter.ConvertToInt(Session_CS.child_emp.ToString()) > 0)
            {
               
                   
                int id2 = CDataConverter.ConvertToInt(id);
                

                DataTable dtsec = General_Helping.GetDataTable("select pmp_pmp_id from inbox where id = " + id2);
                if (CDataConverter.ConvertToInt(dtsec.Rows[0]["pmp_pmp_id"].ToString()) == Session_CS.pmp_id)
                {
              

                    url = "~/MainForm/Project_Inbox.aspx?id=" + Encryption.Encrypt(id.ToString());


                }
                else
                    url = "~/MainForm/ViewProjectInbox.aspx?id=" + Encryption.Encrypt(id.ToString());
               

            }
            else
            {

                url = "~/MainForm/ViewProjectInbox.aspx?id=" + Encryption.Encrypt(id.ToString());


            }


        }
        else if (Request["Type"].ToString() == "2" || Request["Type"].ToString() == "3" || Request["Type"].ToString() == "4" || Request["Type"].ToString() == "10" || Request["Type"].ToString() == "5" || Request["Type"].ToString() == "11" || Request["Type"].ToString() == "visa")
        {
            if (CDataConverter.ConvertToInt(Session_CS.parent_id.ToString()) > 0)
            {
                url = "~/MainForm/ViewProjectInbox.aspx?id=" + Encryption.Encrypt(id.ToString());


            }
            if (CDataConverter.ConvertToInt(Session_CS.child_emp.ToString()) > 0)
            {
                
                DataTable dtsec = General_Helping.GetDataTable("select pmp_pmp_id from inbox where id = " + id);
                if (dtsec.Rows.Count>0)
                {
                    if (CDataConverter.ConvertToInt(dtsec.Rows[0]["pmp_pmp_id"].ToString()) == Session_CS.pmp_id)
                    {

                        url = "~/MainForm/Project_Inbox.aspx?id=" + Encryption.Encrypt(id.ToString());

                    }
                    else
                        url = "~/MainForm/ViewProjectInbox.aspx?id=" + Encryption.Encrypt(id.ToString());
                }
               
            }
            else
            {
                url = "~/MainForm/ViewProjectInbox.aspx?id=" + Encryption.Encrypt(id.ToString());

            }

        }





        return url;
    }


    

    protected void gv_in_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        //{

        //    if (e.CommandName == "show_inbox_Details")
        //    {
        //        string encrypted = Encryption.Encrypt(e.CommandArgument.ToString());


        //        if (Request["Type"].ToString() == "1" || Request["Type"].ToString() == "6")
        //        {

        //            if (CDataConverter.ConvertToInt(Session_CS.parent_id.ToString()) > 0)
        //            {


        //                Response.Redirect("ViewProjectInbox.aspx?id=" + encrypted);

        //            }
        //            if (CDataConverter.ConvertToInt(Session_CS.child_emp.ToString()) > 0)
        //            {
        //                int id = CDataConverter.ConvertToInt(e.CommandArgument);
        //                DataTable dtsec = General_Helping.GetDataTable("select pmp_pmp_id from inbox where id = " + id);
        //                if (CDataConverter.ConvertToInt(dtsec.Rows[0]["pmp_pmp_id"].ToString()) == Session_CS.pmp_id)
        //                {
        //                    Response.Redirect("Project_Inbox.aspx?id=" + encrypted);
        //                }
        //                else
        //                    Response.Redirect("ViewProjectInbox.aspx?id=" + encrypted);

        //            }
        //            else
        //            {

        //                Response.Redirect("ViewProjectInbox.aspx?id=" + encrypted);

        //            }


        //        }
        //        else if (Request["Type"].ToString() == "2" || Request["Type"].ToString() == "3" || Request["Type"].ToString() == "4" || Request["Type"].ToString() == "10" || Request["Type"].ToString() == "5" || Request["Type"].ToString() == "11" || Request["Type"].ToString() == "visa")
        //        {
        //            if (CDataConverter.ConvertToInt(Session_CS.parent_id.ToString()) > 0)
        //            {
        //                Response.Redirect("ViewProjectInbox.aspx?id=" + encrypted);

        //            }
        //            if (CDataConverter.ConvertToInt(Session_CS.child_emp.ToString()) > 0)
        //            {
        //                int id = CDataConverter.ConvertToInt(e.CommandArgument);
        //                DataTable dtsec = General_Helping.GetDataTable("select pmp_pmp_id from inbox where id = " + id);
        //                if (CDataConverter.ConvertToInt(dtsec.Rows[0]["pmp_pmp_id"].ToString()) == Session_CS.pmp_id)
        //                {
        //                    Response.Redirect("Project_Inbox.aspx?id=" + encrypted);
        //                }
        //                else
        //                    Response.Redirect("ViewProjectInbox.aspx?id=" + encrypted);
        //            }
        //            else
        //            {
        //                Response.Redirect("ViewProjectInbox.aspx?id=" + encrypted);
        //            }

        //        }



        //    }



        //}
    }
    protected void ImgBtnBack_Click(object sender, System.Web.UI.ImageClickEventArgs e)
    {
        Response.Redirect("~/MainForm/Default.aspx");
    }


}
