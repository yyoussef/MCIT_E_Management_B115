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

public partial class Admin_Admin_Module : System.Web.UI.Page
{


    Projects_ManagementEntities10 pmentity = new Projects_ManagementEntities10();
    Projects_ManagementEntities pmgenentity = new Projects_ManagementEntities();
    OutboxDataContext outboxDBContext = new OutboxDataContext();

    string sql, Sql_insert;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Get_Module();
            Get_found();
        }

    }

    private void Get_found()
    {
        // DataTable dt = Foundations_DB.SelectAll();
        DataTable dt = new DataTable();
        dt = (from found in pmgenentity.Foundations select found).ToDataTable();

        drop_found.DataSource = dt;

        drop_found.DataBind();
        drop_found.Items.Insert(0, new ListItem("إختر الجهة", "0"));

    }

    protected void drop_found_SelectedIndexChanged(object sender, EventArgs e)
    {
        cbl_Module.ClearSelection();

        int found = CDataConverter.ConvertToInt(drop_found.SelectedValue);

        //  DataTable dt = General_Helping.GetDataTable("select * from admin_module_found where found_id= " + CDataConverter.ConvertToInt(drop_found.SelectedValue));

        DataTable dt = pmgenentity.Admin_Module_Found.Where(x => x.found_id == found).ToDataTable();

        foreach (DataRow row in dt.Rows)
        {
            string Value = row["Mod_ID"].ToString();
            if (row["Mod_status"].ToString() == "True")
            {
                ListItem item = cbl_Module.Items.FindByValue(Value);
                if (item != null)
                    item.Selected = true;
            }

        }
    }
    protected void Get_Module()
    {
        //sql = @"select * from Admin_Module  ORDER BY LTRIM(Name)";
        //DataTable dt = General_Helping.GetDataTable(sql);
        var query = from adminfound in pmgenentity.Admin_Module orderby adminfound.Name select adminfound;
        DataTable dt = query.ToDataTable();

        cbl_Module.DataSource = dt;
        cbl_Module.DataValueField = "pk_ID";
        cbl_Module.DataTextField = "Name";
        cbl_Module.DataBind();


    }

    public void InsertOrUpdate(Admin_Module_Found blog)
    {


        using (var context = new Projects_ManagementEntities())
        {
            context.Entry(blog).State = blog.ID == 0 ?
                                      System.Data.Entity.EntityState.Added :
                                      System.Data.Entity.EntityState.Modified;

            context.SaveChanges();

        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        int founnd = CDataConverter.ConvertToInt(drop_found.SelectedValue);

        //General_Helping.ExcuteQuery("delete from admin_module_found where found_id = " + CDataConverter.ConvertToInt(drop_found.SelectedValue));

        pmgenentity.Admin_Module_Found.RemoveRange(pmgenentity.Admin_Module_Found.Where(x => x.found_id == founnd));
        pmgenentity.SaveChanges();






        foreach (ListItem item in cbl_Module.Items)
        {
            if (item.Selected)
            {
                if (drop_found.SelectedValue != "0")
                {

                    // Sql_insert = "insert into admin_module_found ( Mod_id , Mod_status ,found_id) values ( " + item.Value + "," + 1 + "," + CDataConverter.ConvertToInt(drop_found.SelectedValue) + ")";
                    //  General_Helping.ExcuteQuery(Sql_insert);

                    Admin_Module_Found obj = new Admin_Module_Found();
                    obj.Mod_ID = CDataConverter.ConvertToInt(item.Value);
                    obj.Mod_status = true;
                    obj.found_id = CDataConverter.ConvertToInt(drop_found.SelectedValue);
                    InsertOrUpdate(obj);



                }

                //sql = "update Admin_Module set Active=1 where pk_ID=" + item.Value;

                //General_Helping.ExcuteQuery(sql);
            }
        }
        Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('تم الحفظ بنجاح')</script>");
    }
}
