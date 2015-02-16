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
          //  fillgrid();

            fill_foundations();

        }

    }

    public void InsertOrUpdate(Admin_Users  blog)
    {


        using (var context = new Projects_ManagementEntities())
        {
            context.Entry(blog).State = blog.ID  == 0 ?
                                      System.Data.Entity.EntityState.Added :
                                      System.Data.Entity.EntityState.Modified;

            context.SaveChanges();

        }
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {
        //DataTable dt = SqlHelper.ExecuteDataset(Database.ConnectionString, "AdminUsers_SelectName_Exsit", txt_loginname.Text).Tables[0];

          DataTable dt =  pmgenentity.AdminUsers_SelectName_Exsit(txt_loginname.Text).ToDataTable();

        if (ddl_Foundation.SelectedValue != "" && ddl_Foundation.SelectedValue != "0")
        {
            if (dt.Rows.Count <= 0)
            {
               //Admin_Users_DT obj = new Admin_Users_DT();
                Admin_Users obj = new Admin_Users();

            obj.ID = CDataConverter.ConvertToInt(adminuser_id.Value);
            obj.Name = txtBox_UserName.Text;
            obj.User_name = txt_loginname.Text;
            obj.Password = "1234";
            if (chk_account.Checked == true)
            {
                obj.account_active = true;
            }
            else
            {
                obj.account_active = false;
            }
            obj.foundation_id = CDataConverter.ConvertToInt(ddl_Foundation.SelectedValue);
           // obj.ID = Admin_Users_DB.Save(obj);
                InsertOrUpdate(obj);


            if (obj.ID > 0)
            {


                Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('تم الحفظ بنجاح')</script>");
                fillgrid();

            }
            clear();
            }

            else 
            {
                Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('إسم الدخول مسجل من قبل ')</script>");


            }

        }



        else
        {
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert(' يجب إختيار الجهة')</script>");

        }
    
    
    }

    private void fillgrid()
    {
        int foud = CDataConverter.ConvertToInt(ddl_Foundation.SelectedValue);

        var result = pmgenentity.Admin_Users.Where(x=>x.foundation_id== foud );

        DataTable dt = result.ToDataTable();

       // DataTable dt = Admin_Users_DB.SelectAll(0, CDataConverter.ConvertToInt(ddl_Foundation.SelectedValue));
        gvMain.DataSource = dt;
        gvMain.DataBind();



    }

   private void  fill_foundations()
    {
        
        DataTable dt = new DataTable();
        dt = (from found in pmgenentity.Foundations select found).ToDataTable();

        ddl_Foundation.DataSource = dt;
        ddl_Foundation.DataTextField = "Foundation_Name";
        ddl_Foundation.DataValueField = "Foundation_ID";
        ddl_Foundation.DataBind();
       
        ddl_Foundation.Items.Insert(0, new ListItem("....إختر الجهة ...","0"));

    }

    private void clear()
    {
        adminuser_id.Value =
        txt_loginname .Text = "";
       
        txtBox_UserName.Text = "";
       // chk_account.Checked = false;
       
    }



    protected void gvMain_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int x = CDataConverter.ConvertToInt(e.CommandArgument);

        if (e.CommandName == "Show")
        {
           

           // Admin_Users_DT  obj = Admin_Users_DB.SelectByID(CDataConverter.ConvertToInt(e.CommandArgument ),0);

            Admin_Users obj = pmgenentity.Admin_Users.Where(y=>y.ID==x).SingleOrDefault();

            txt_loginname.Text = obj.User_name.ToString();
            txtBox_UserName.Text = obj.Name.ToString();

            if (obj.account_active == true)
            {
                chk_account.Checked = true;
            }
            else
            {
                chk_account.Checked = false ;
            }
          

            
            adminuser_id.Value = obj.ID.ToString();

        }

        else if (e.CommandName == "dlt")
        {
           // Admin_Users_DB.Delete(CDataConverter.ConvertToInt(e.CommandArgument));

            Admin_Users obj = new Admin_Users() 
            { 
                ID = x 

            };
            pmgenentity.Admin_Users.Attach(obj);
            pmgenentity.Admin_Users.Remove(obj);
            pmgenentity.SaveChanges();

             Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('تم الحذف بنجاح')</script>");

            fillgrid();
            clear();




        }
    }


   




    protected void ddl_Foundation_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_Foundation.SelectedValue!= "" && ddl_Foundation.SelectedValue != "0")
        {
            fillgrid();
            gvMain.Visible = true;

        }

        else
        {

            gvMain.Visible = false;
        }

   }
}
