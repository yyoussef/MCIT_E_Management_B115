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
using System.Globalization;
using ReportsClass;
using System.Data.Linq;
using System.Collections.Generic;
using System.Data.Entity.Core;


public partial class SuperAdmin_Foundations : System.Web.UI.Page
{

    Projects_ManagementEntities10 pmentity = new Projects_ManagementEntities10();
    Projects_ManagementEntities pmgenentity = new Projects_ManagementEntities();
    OutboxDataContext outboxDBContext = new OutboxDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            fillgrid();

        }

    }

    public string Get_Type(object obj)
    {
        string str = obj.ToString();
        if (str == "1")
            return "الكود يزداد تلقائيا";
        else
            return "الكود لا يزداد تلقائيا";
        //else return "وثيقة";
    }

    private string getNormalizedName(string str)
    {

        System.Text.StringBuilder normalizedSTR = new System.Text.StringBuilder(); ;
        char[] normalizedSTRarr = str.ToCharArray();
        foreach (char ch in normalizedSTRarr)
        {
            if (ch == 'أ' || ch == 'إ' || ch == 'ا' || ch == 'أ' || ch == 'آ')
            { normalizedSTR.Append('ا'); }
            else if (ch == 'ه' || ch == 'ة')
            { normalizedSTR.Append('ه'); }
            else if (ch == 'ي' || ch == 'ى' || ch == 'ئ')
            { normalizedSTR.Append('ى'); }
            else if (ch == 'ؤ' || ch == 'و')
            { normalizedSTR.Append('و'); }
            else
            { normalizedSTR.Append(ch); }
        }
        return normalizedSTR.ToString();

    }

    public void InsertOrUpdate(Foundations blog)
    {
        using (var context = new Projects_ManagementEntities())
        {
            context.Entry(blog).State = blog.Foundation_ID == 0 ?
                                       System.Data.Entity.EntityState.Added :
                                      System.Data.Entity.EntityState.Modified;

            context.SaveChanges();
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {


        string temp = getNormalizedName(txtBox_FoundName.Text.Trim());
        if (pmgenentity.Foundations.Any(o => o.Foundation_Name == temp))
        {
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('اسم الجهة موجود من فضلك ادخل اسم أخر')</script>");
            return;
        }
        else
        {
            Foundations found_obj = new Foundations();
            found_obj.Foundation_ID = Convert.ToInt32(found_id.Value);
            found_obj.Foundation_Name = txtBox_FoundName.Text;
            found_obj.FromAddress = txtBox_FromAddress.Text;
            found_obj.Host = txtBox_Host.Text;
            found_obj.connection_string = txt_connstring.Text;
            found_obj.Password = txtBox_Password.Text;
            found_obj.Port = Convert.ToInt32(txtBox_Port.Text);
            found_obj.UserName_mail = txtBox_UserName_mail.Text;
            if (chk_code.Checked == true)
            {
                found_obj.code_archiving = 1;
            }
            else
            {
                found_obj.code_archiving = 0;
            }

            if (Chk_islocal.Checked == true)
            {
                found_obj.islocal = true;
                found_obj.connection_string = txt_connstring.Text;
            }
            else
            {
                found_obj.islocal = false;
                found_obj.connection_string = "";
            }

            InsertOrUpdate(found_obj);

            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('تم الحفظ بنجاح')</script>");

            fillgrid();
            clear();
        }


    }

    private void fillgrid()
    {
        var foud_query = from foundd in pmgenentity.Foundations select foundd;

        List<Foundations> foud1 = foud_query.ToList();
        gvMain.DataSource = foud1;
        gvMain.DataBind();



    }

    private void clear()
    {
        //found_id.Value =

        chk_code.Checked = false;
        Chk_islocal.Checked = false;
        tr_local.Visible = false;
        CheckBox1.Checked =
        CheckBox2.Checked = false;
        txtBox_FoundName.Text =
        txtBox_Port.Text =
        txtBox_Host.Text =
        txtBox_Password.Text =
        txtBox_UserName_mail.Text =
        txtBox_FromAddress.Text =
        TextBox1.Text =
        TextBox2.Text = "";
    }


    protected void gvMain_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "dlt")
        {


            Foundations foun = new Foundations()
            {
                Foundation_ID = Convert.ToInt32(e.CommandArgument)
            };

            pmgenentity.Foundations.Attach(foun);
            pmgenentity.Foundations.Remove(foun);
            pmgenentity.SaveChanges();

            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('تم الحذف بنجاح')</script>");

        }
        else if (e.CommandName == "Show")
        {
            int comm_found_id = Convert.ToInt32(e.CommandArgument);
            Foundations found_sel = pmgenentity.Foundations.Where(x => x.Foundation_ID == comm_found_id).SingleOrDefault();
            if (found_sel != null)
            {
                try
                {
                    txtBox_FoundName.Text = found_sel.Foundation_Name.ToString();
                    txtBox_Port.Text = found_sel.Port.ToString();
                    txtBox_Host.Text = found_sel.Host.ToString();
                    txtBox_Password.Text = found_sel.Password.ToString();
                    txtBox_UserName_mail.Text = found_sel.UserName_mail.ToString();
                    txtBox_FromAddress.Text = found_sel.FromAddress.ToString();

                    if (found_sel.code_archiving == 1)
                    {
                        chk_code.Checked = true;
                    }
                    else
                        chk_code.Checked = false;

                    if (Convert.ToInt32(found_sel.islocal) == 1)
                    {
                        Chk_islocal.Checked = true;
                        txt_connstring.Text = found_sel.connection_string.ToString();
                        tr_local.Visible = true;

                    }
                    else
                        Chk_islocal.Checked = false;

                    found_id.Value = found_sel.Foundation_ID.ToString();
                }
                catch
                {

                }
            }


        }
        fillgrid();
    }


    protected void gvMain_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void Chk_islocal_CheckedChanged(object sender, EventArgs e)
    {
        if (Chk_islocal.Checked == true)
        {
            tr_local.Visible = true;
        }
        else
        {
            tr_local.Visible = false;
        }

    }
}
