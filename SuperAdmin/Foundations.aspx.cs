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


public partial class SuperAdmin_Foundations : System.Web.UI.Page
{
    
 
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
    protected void btnSave_Click(object sender, EventArgs e)
    {
        
        
        Foundations_DT obj = new Foundations_DT();
      
        DataTable select_dt = Foundations_DB.foundation_exist(CDataConverter.ConvertToInt( found_id.Value ));
        DataTable resultDT = select_dt.Clone();
      
        string temp = getNormalizedName(txtBox_FoundName.Text.Trim());

        foreach (DataRow dr in select_dt.Rows)
        {
            if (getNormalizedName(dr["Foundation_Name"].ToString()).Contains(temp) )
            {
                resultDT.ImportRow(dr);
                resultDT.AcceptChanges();
                //if (resultDT.Rows.Count > 0)
                {
                    Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('اسم الجهة موجود من فضلك ادخل اسم أخر')</script>");
                    return;
                }

            }
        }
        if (resultDT.Rows.Count == 0  )
        {
            obj.Foundation_ID = CDataConverter.ConvertToInt(found_id.Value);
            obj.Foundation_Name = txtBox_FoundName.Text;
            obj.Port = CDataConverter.ConvertToInt(txtBox_Port.Text);
            obj.Host = txtBox_Host.Text;
            obj.UserName_mail = txtBox_UserName_mail.Text;
            obj.Password = txtBox_Password.Text;
            obj.FromAddress = txtBox_FromAddress.Text;
            if (chk_code.Checked == true)
            {
                obj.code_archiving = 1;
            }
            else
            {
                obj.code_archiving = 0;
            }

            if (Chk_islocal.Checked == true)
            {
                obj.islocal = true;
                obj.connection_string = txt_connstring.Text;
            }
            else
            {
                obj.islocal = false;
                obj.connection_string = "";
            }
            obj.Foundation_ID = Foundations_DB.Save(obj);
            found_id.Value =
            txtBox_FoundName.Text = "";

            if (obj.Foundation_ID > 0)
            {


                Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('تم الحفظ بنجاح')</script>");

                fillgrid();

            }

            clear();
        }
     
    }

    private void fillgrid()
    {
        DataTable dt = Foundations_DB.SelectAll();
        gvMain.DataSource = dt;
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
        if (e.CommandName == "Show")
        {
            Foundations_DT obj = Foundations_DB.SelectByID(CDataConverter.ConvertToInt(e.CommandArgument));
           
                txtBox_FoundName.Text = obj.Foundation_Name.ToString();
                txtBox_Port.Text = obj.Port.ToString();
                txtBox_Host.Text = obj.Host.ToString();
                txtBox_Password.Text = obj.Password.ToString();
                txtBox_UserName_mail.Text = obj.UserName_mail.ToString();
                txtBox_FromAddress.Text = obj.FromAddress.ToString();

                if (obj.code_archiving == 1)
                {
                    chk_code.Checked = true;
                }
                else
                    chk_code.Checked = false;

                if (CDataConverter.ConvertToInt(obj.islocal) == 1)
                {
                    Chk_islocal.Checked = true;
                    txt_connstring.Text = obj.connection_string.ToString();
                    tr_local.Visible = true;

                }
                else
                    Chk_islocal.Checked = false;

                found_id.Value = obj.Foundation_ID.ToString();
            }

       

        else if (e.CommandName == "dlt")
        {
            Departments_DT dt = Departments_DB.SelectByFoundationID(CDataConverter.ConvertToInt(e.CommandArgument));
            if (dt != null && dt.Dept_id > 0)
            {
                Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لا يمكن حذف الجهة يوجد إدارات تابعة لها ')</script>");

            }
            else
            {
               // Foundations_DB.Delete(CDataConverter.ConvertToInt(e.CommandArgument));
                Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('تم الحذف بنجاح')</script>");

            }
            fillgrid();
            clear();

        }
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
