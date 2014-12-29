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
using System.Web.UI.WebControls;
using System.Collections.Generic;


public partial class UserControls_Training_Plan : System.Web.UI.UserControl
{

    private string sql_Connection = Database.ConnectionString;
    Session_CS Session_CS = new Session_CS();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            check_manageraccess();
            fill_ddl_programs();
            if (Request["mode"] != null && Request["mode"] == "manager")
            {

                lst_train.Items.Clear();
            }
            else
            {
                fill_emp_training();
            }
            
        }

    }



   protected override void OnInit(EventArgs e)
   {

       //this.Smart_Pmp_Id.Value_Handler += new Smart_Search.Delegate_Selected_Value(MOnMember_Data_Emp);
       fil_employee();
   }

   protected void fil_employee()
   {
       Smart_Pmp_Id.sql_Connection = sql_Connection;

       string Query = "select distinct dbo.Training_Plan.emp_id,EMPLOYEE.vacation_mng_pmp_id,EMPLOYEE.pmp_name from dbo.Training_Plan inner join dbo.EMPLOYEE on  dbo.Training_Plan.emp_id = EMPLOYEE.PMP_ID where dbo.EMPLOYEE.vacation_mng_pmp_id='" + CDataConverter.ConvertToInt(Session_CS.pmp_id) + "'  and dbo.Training_Plan.isapproved=0 and dbo.Training_Plan.emp_id not in (select dbo.Training_Plan.emp_id from dbo.Training_Plan where dbo.Training_Plan.isapproved=1 )";
      // Query += " and  Mngr_Emp_ID=" + Session_CS.pmp_id.ToString();
       Smart_Pmp_Id.datatble = General_Helping.GetDataTable(Query);
       Smart_Pmp_Id.Show_Code = false;
       Smart_Pmp_Id.Value_Field = "emp_id";
       Smart_Pmp_Id.Text_Field = "pmp_name";
       Smart_Pmp_Id.DataBind();
       this.Smart_Pmp_Id.Value_Handler += new Smart_Search.Delegate_Selected_Value(MOnMember_Data_Emp);
   }

   private void MOnMember_Data_Depart(string Value)
   {
       if (Value != "")
       {
          // fil_employee();
       }
       else
       {
           Smart_Pmp_Id.Clear_Controls();
           MOnMember_Data_Emp("");
         
       }
   }

   private void MOnMember_Data_Emp(string Value)
   {
       if (Value != "")
       {
           lst_train.Items.Clear();
           fill_train_formanager();
       }
       else
       {

       }

   }

  protected void check_manageraccess()    
   {
       if (Request["mode"] != null && Request["mode"] == "manager")
       {
           Smart_Pmp_Id.Visible = true;
           Smart_Pmp_Id.Enabled = true;
           Label16.Visible = true;
           fil_employee();

       }

   }


    private void fill_ddl_programs()
    {
        DataTable dt1 = Course_Programs_DB.SelectAll();
        Chk_training.DataSource = dt1;
        Chk_training.DataBind();
        Chk_training.DataTextField = "prog_name";
        Chk_training.DataValueField = "prog_id";
       

    }

    protected void  fill_emp_training()

    {
        DataTable dt_approve = Training_Plan_DB.Training_Plan_apprevedcourse_select(CDataConverter.ConvertToInt(Session_CS.pmp_id));
        if (dt_approve.Rows.Count > 0)
        {
            lst_train.Items.Clear();
            lst_train.DataSource = dt_approve;
            lst_train.DataBind();
            disable_fields();
        }
        else

        {
            DataTable dt = Training_Plan_DB.Training_Plan_course_select(CDataConverter.ConvertToInt(Session_CS.pmp_id));
            lst_train.Items.Clear();
            lst_train.DataSource = dt;
            lst_train.DataBind();
        }
    }

   protected void fill_train_formanager()
   {
       DataTable dt_approve = Training_Plan_DB.Training_Plan_apprevedcourse_select(CDataConverter.ConvertToInt(Smart_Pmp_Id.SelectedValue));
       if (dt_approve.Rows.Count > 0)
       {
           lst_train.Items.Clear();
           lst_train.DataSource = dt_approve;
           lst_train.DataBind();
         
       }
       else
       {
           DataTable dt = Training_Plan_DB.Training_Plan_course_select(CDataConverter.ConvertToInt(Smart_Pmp_Id.SelectedValue));
           lst_train.Items.Clear();
           lst_train.DataSource = dt;
           lst_train.DataBind();
       }

   }

    private void disable_fields()
    {
        Chk_training.Enabled = false;
        chk_ALL.Enabled = false;
        chklst_train_All.Enabled = false;
        btn_add.Enabled = false;
        btn_delete.Enabled = false;
        lst_train.Enabled = false;
        btn_save.Enabled = false;
        Smart_Pmp_Id.Enabled = false;
    }

  


    protected void btn_add_Click(object sender, EventArgs e)
    {

        fill_listbox();
       
    }

    public void fill_listbox()
    {
        foreach (ListItem item in chklst_train_All.Items)
        {
            if (item.Selected && lst_train.Items.FindByValue(item.Value) == null)
            {
                ListItem obj = new ListItem(item.Text, item.Value);
                lst_train.Items.Add(obj);
                item.Selected = false;
            }

        }
    }

    protected void btn_delete_Click(object sender, EventArgs e)
    {
        if (lst_train.SelectedValue == "")
        {

            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('يجب اختيار الدورة التدريبية ليتم الحذف');", true);

        }
        else
        {
            lst_train.Items.Remove(lst_train.SelectedItem);

       
        }

    }

    protected void chk_ALL_CheckedChanged(object sender, EventArgs e)
    {
        foreach (ListItem item in chklst_train_All.Items)
        {
            item.Selected = chk_ALL.Checked;
        }
        
    }


    protected void Chk_main_cat_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        DataTable dt;
        ListItem obj;
        foreach (ListItem item in Chk_training.Items)
        {
            if (item.Selected)
            {
                dt = General_Helping.GetDataTable(" select * from courses where prog_id = " + item.Value);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        obj = new ListItem(dt.Rows[i]["course_name"].ToString(), dt.Rows[i]["course_id"].ToString());

                        if (chklst_train_All.Items.FindByValue(obj.Value) == null)
                        {
                            chklst_train_All.Items.Add(obj);
                        }


                    }
                }
            }
            else
            {
                dt = General_Helping.GetDataTable(" select * from courses where prog_id = " + item.Value);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    obj = new ListItem(dt.Rows[i]["course_name"].ToString(), dt.Rows[i]["course_id"].ToString());
                    
                        chklst_train_All.Items.Remove(obj);

                      //  lst_train.Items.Remove(obj);


                }
            }
       

          
        }

        
    }

    protected void btn_save_Click(object sender, EventArgs e)
    {
      if (lst_train.Items.Count > 0)
     {

               Training_Plan_DT obj = new Training_Plan_DT();

                Save_training_list(obj);
               
      }
        else
      {
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('لا توجد دورات تدريبية في القائمة اليسري');", true);
      }


    }


    private void Save_training_list(Training_Plan_DT  obj)
    {

        if (Request["mode"] != null && Request["mode"] == "manager")
        {
            string Sql_Delete = "delete from Training_Plan where emp_id ='" + CDataConverter.ConvertToInt(Smart_Pmp_Id.SelectedValue) + "' and isapproved=1";
            General_Helping.ExcuteQuery(Sql_Delete);
        }
        else
        {

            string Sql_Delete = "delete from Training_Plan where emp_id ='" + CDataConverter.ConvertToInt(Session_CS.pmp_id) + "' and isapproved=0";
            General_Helping.ExcuteQuery(Sql_Delete);
        }

        foreach (ListItem item in lst_train.Items)
        {
             if (Request["mode"] != null && Request["mode"] == "manager")
                {
                  


                    Training_Plan_DB.training_plan_save(0, CDataConverter.ConvertToInt(item.Value), CDataConverter.ConvertToInt(Smart_Pmp_Id.SelectedValue), 1);
                  //  fill_emp_training();
                   
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('تم الحفظ بنجاح');", true);
                }
                else
                {
                 

                    Training_Plan_DB.training_plan_save(0, CDataConverter.ConvertToInt(item.Value), CDataConverter.ConvertToInt(Session_CS.pmp_id), 0);
                  //  fill_emp_training();
                   
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('تم الحفظ بنجاح');", true);
                }
        }
      

    }



    private void clear()

    {
        lst_train.Items.Clear();
    }

}
