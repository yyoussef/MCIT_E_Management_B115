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
using System.Data.SqlClient;
using System.Data.Entity;
using EFModels;


public partial class UserControls_EmployeeDirectParent : System.Web.UI.UserControl
{
    //Session_CS Session_CS = new Session_CS();
    private string sql_Connection = Database.ConnectionString;

    ActiveDirectoryContext ADContext = new ActiveDirectoryContext();
    int found_id = CDataConverter.ConvertToInt(Session_CS.foundation_id.ToString());

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            Fill_Groups();
            fillGrid();
        }
    }
    /// <summary>
    /// Will fill the grid from the view created for retrieving 
    /// the employees and their corresponding direct managers 
    /// </summary>
    /// 
    protected void ddl_Groups_SelectedIndexChanged(object sender, EventArgs e)
    {
        //string sql = "select * from employee where group_id = " + ddl_Groups.SelectedValue;

        int x = CDataConverter.ConvertToInt(ddl_Groups.SelectedValue);

        var query = from emp in ADContext.EMPLOYEEs where emp.Group_id == x select emp;


        DataTable dtdirectmng = query.ToDataTable();

        Smart_Search_Direct_Manager.sql_Connection = Smart_Search_Employee.sql_Connection = sql_Connection;

        Smart_Search_Direct_Manager.datatble = dtdirectmng;
        Smart_Search_Employee.datatble = dtdirectmng;

        Smart_Search_Direct_Manager.Value_Field = Smart_Search_Employee.Value_Field = "PMP_ID";

        Smart_Search_Direct_Manager.Text_Field = Smart_Search_Employee.Text_Field = "pmp_name";


        Smart_Search_Direct_Manager.DataBind();

        Smart_Search_Employee.DataBind();

        int g_id = CDataConverter.ConvertToInt( ddl_Groups.SelectedValue);

      


       var query2 = from empcorr in ADContext.EmployeeAndCorrParentEmplNames where empcorr.foundation_id == found_id && empcorr.Group_id== g_id select empcorr  ;
        DataTable dt = query2.ToDataTable();

      //  DataTable dt = General_Helping.GetDataTable("select * from EmployeeAndCorrParentEmplNames where foundation_id = "+CDataConverter.ConvertToInt(Session_CS.foundation_id.ToString()) +" and group_id= " +CDataConverter.ConvertToInt( ddl_Groups.SelectedValue));
        gvMain.DataSource = dt;
        gvMain.DataBind();

    }
  
    private void Fill_Groups()
    {
        //string sql = "select * from Employee_Groups where foundation_id="+CDataConverter.ConvertToInt(Session_CS.foundation_id.ToString());

        //DataTable dt = General_Helping.GetDataTable(sql);

       DataTable dt = (from empgroup in ADContext.Employee_Groups  where empgroup.foundation_id == found_id select empgroup).ToDataTable();

        ddl_Groups.DataSource = dt;
        ddl_Groups.DataValueField = "ID";
        ddl_Groups.DataTextField = "Name";
        ddl_Groups.DataBind();
        ddl_Groups.Items.Insert(0, new ListItem("اختر المجموعة......", "0"));
    }

    private void fillGrid()
    {
        //load the values in the grid

     //   string sqlSelectSt = "SELECT * FROM EmployeeAndCorrParentEmplNames where foundation_id='" + CDataConverter.ConvertToInt(Session_CS.foundation_id.ToString()) + "' and Group_id !='"+ DBNull.Value+"'";//Retrieve data from the View

        DataTable dt = (from emppar in ADContext.EmployeeAndCorrParentEmplNames where emppar.foundation_id == found_id && emppar.Group_id != null  select emppar).ToDataTable() ;

        try
        {
          //  DataSet set = SqlHelper.ExecuteDataset(sql_Connection, CommandType.Text, sqlSelectSt);

            gvMain.DataSource = dt ;
            gvMain.DataBind();
        }
        catch
        {
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('حدثت مشكلة في ملئ الجدول من قاعدة البيانات')</script>");
        }
    }

    /// <summary>
    /// will be fired when the user clicks the save button
    /// Is used to save data of the Employee and his corresponding 
    /// direct Manager and type
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    /// 

    public int InsertOrUpdate_parentemployee(parent_employee blog)
    {


        using (var context = new ActiveDirectoryContext())
        {

            context.Entry(blog).State = blog.ID == 0 ?
                                      System.Data.Entity.EntityState.Added :
                                      System.Data.Entity.EntityState.Modified;

            context.SaveChanges();
            return blog.ID;
        }
    }




    protected void btn_Save_Click(object sender, EventArgs e)
    {
        if (Smart_Search_Direct_Manager.SelectedValue != "" && Smart_Search_Employee.SelectedValue != "" && Smart_Search_Employee.SelectedValue!= Smart_Search_Direct_Manager.SelectedValue )
        {
            int selectedEmplID = CDataConverter.ConvertToInt(Smart_Search_Employee.SelectedValue);
            int selectedDirManagerID = CDataConverter.ConvertToInt(Smart_Search_Direct_Manager.SelectedValue);
            int type = CDataConverter.ConvertToInt(ddl_Type.SelectedValue);
           int group_id =  CDataConverter.ConvertToInt( ddl_Groups.SelectedValue);
            //Check first if a record with those values is available in database

         //   string checkSqlComm = "SELECT * FROM parent_employee WHERE pmp_id=" + selectedEmplID.ToString() + " AND Type=" + type.ToString();
            
           DataTable dts   = ( from paremp in ADContext.parent_employee where paremp.pmp_id == selectedEmplID && paremp.Type == type select paremp ).ToDataTable() ;

             
            try
            {
                if (dts.Rows.Count > 0)
                {
                    Page.RegisterStartupScript("Error", "<script language=javascript>alert('يوجد مدير مباشر لنفس نوع الخطاب للموظف')</script>");
                    return;
                }
                else
                {
                    var dtable = (from empcorr in ADContext.EmployeeAndCorrParentEmplNames where empcorr.foundation_id == found_id && empcorr.type_id == type && empcorr.Group_id == group_id  select empcorr).ToDataTable();

                    if (dtable.Rows.Count > 0)
                    {
                        Page.RegisterStartupScript("Error", "<script language=javascript>alert('  يوجد مدير مباشر لنفس  المجموعة ونفس نوع الخطاب')</script>");
                        return;
                    }
                }

                //SqlDataReader reader = SqlHelper.ExecuteReader(sql_Connection, CommandType.Text, checkSqlComm);
                //if (reader.HasRows)
                //{
                //    //this means that this record does exist before

                //    Page.RegisterStartupScript("Error", "<script language=javascript>alert('يوجد مدير مباشر لنفس نوع الخطاب للموظف')</script>");
                //    return;
                //}

                ////Else, this record doesn't exist before, so go ahead to save or update it

                //DataTable dt = General_Helping.GetDataTable("select ParentEmpID from EmployeeAndCorrParentEmplNames where foundation_id='" + CDataConverter.ConvertToInt(Session_CS.foundation_id.ToString()) + "'and type_id='" + CDataConverter.ConvertToInt(type) + "' and Group_id='" + CDataConverter.ConvertToInt(ddl_Groups.SelectedValue) + "' ");
                //if (dt.Rows.Count > 0)
                //{
                //    Page.RegisterStartupScript("Error", "<script language=javascript>alert('  يوجد مدير مباشر لنفس  المجموعة ونفس نوع الخطاب')</script>");
                //    return;
                //}

            }


            catch(Exception ex )
            {
                Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('حدث خطأ في قاعدة البيانات حاول مرة أخري')</script>");
            }

            //if (CDataConverter.ConvertToInt(currRow_id.Value) == 0)//user wants to save

            //{
                //User has supplied values for both the employee and his manager
              //  string sqlInsertCommand = "INSERT INTO parent_employee VALUES(" + selectedEmplID.ToString() + "," + selectedDirManagerID.ToString() + "," + type.ToString() + ")";



                //Write the values read in the database
                try
                {
                  //  SqlHelper.ExecuteScalar(sql_Connection, CommandType.Text, sqlInsertCommand);


                    parent_employee parempobj = new parent_employee();

                    parempobj.pmp_id = selectedEmplID;
                    parempobj.parent_pmp_id = selectedDirManagerID;
                    parempobj.Type = type;
                    InsertOrUpdate_parentemployee(parempobj);

                    Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('تم الحفظ بنجاح')</script>");
                }
                catch
                {
                    Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('غير قادر علي الحفظ في قاعدة البيانات حاول مرة أخري')</script>");
                }
         //   }

            //else//user wants to update certain row 
            //{
            //    string sqlUpdateCommand = "UPDATE parent_employee SET pmp_id=" + selectedEmplID.ToString() + ",parent_pmp_id=" + selectedDirManagerID.ToString() + ",type=" + type.ToString() + " WHERE ID=" + currRow_id.Value;
            //    try
            //    {
            //        SqlHelper.ExecuteNonQuery(sql_Connection, CommandType.Text, sqlUpdateCommand);
            //        Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('تم التعديل بنجاح')</script>");
            //    }
            //    catch
            //    {
            //        Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('غير قادر علي التعديل في قاعدة البيانات حاول مرة أخري')</script>");
            //    }
            //}
        }
        else
        {
            //Erro message to notify the user to select the employee and manager both
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('الرجاء إختيار كل من اسم الموظف و المدير المباشر ')</script>");

        }
        currRow_id.Value = "";//Reset the hidden field value
        this.Smart_Search_Employee.SelectedValue = "";//Reset the smart search for employee
        this.Smart_Search_Direct_Manager.SelectedValue = "";//Reset the smart search for direct manager

        fillGrid();//Refresh the Grid to view the newly added Row
    }
    /// <summary>
    /// This function will handle the update and delete that will be done
    /// in the grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvMain_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //Read the ID of the row against which certain action will be taken ,either to delete or to edit
        currRow_id.Value = (e.CommandArgument).ToString();
        int currRow = CDataConverter.ConvertToInt(currRow_id);
        if (e.CommandName == "show")//then the Edit button is clicked against certain row in grid
        {
            //get its data from database

           // string sqlSelectSt = "SELECT * FROM EmployeeAndCorrParentEmplNames WHERE ID=" + currRow_id.Value;

            DataTable dtselect = (from emp in ADContext.EmployeeAndCorrParentEmplNames where emp.ID == currRow select emp).ToDataTable();
            try
            {
                //SqlDataReader reader = SqlHelper.ExecuteReader(sql_Connection, CommandType.Text, sqlSelectSt);
                //if (reader.HasRows)
                //{
                //    while (reader.Read())
                //    {
                      
                //        this.Smart_Search_Employee.SelectedValue = reader.GetInt32(4).ToString();
                //        this.Smart_Search_Direct_Manager.SelectedValue = reader.GetInt32(5).ToString();
                      
                //        this.ddl_Type.SelectedValue = reader.GetString(0);
                    
                //    }
                //}


                if( dtselect.Rows.Count > 0 )

                {
                    this.Smart_Search_Employee.SelectedValue = dtselect.Rows[0]["pmp_id"].ToString();
                    this.Smart_Search_Direct_Manager.SelectedValue = dtselect.Rows[0]["parent_pmp_id"].ToString();

                     this.ddl_Type.SelectedValue = dtselect.Rows[0]["type"].ToString();

                }

            }
            catch
            {
                Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('حدث خطأ في قاعدة البيانات')</script>");

            }

        }
        else if (e.CommandName == "dlt")//then the delete button is clicked against certain row in grid
        {
            string deletComm = "DELETE FROM parent_employee WHERE ID=" + currRow_id.Value;
            try
            {
                SqlHelper.ExecuteNonQuery(sql_Connection, CommandType.Text, deletComm);
                Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('تم الحذف بنجاح')</script>");

                

              parent_employee paremm = new parent_employee ();
                {
                    ID = e.CommandArgument.ToString();
                };
             
                ADContext.parent_employee.Attach(paremm);
                ADContext.parent_employee.Remove (paremm);
             
                ADContext.SaveChanges();

            }
            catch
            {
                Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('حدث خطأ في قاعدة البيانات')</script>");
            }
            currRow_id.Value = "";//Reset the hidden field value
            fillGrid();//Refresh the grid

        }
    }
    /// <summary>
    /// This function initializes the smart search usercontrols
    /// with the employee names in both the employee and direct 
    /// managers smart search user controls, same names will be loaded in both
    /// </summary>
    /// <param name="e"></param>
    protected override void OnInit(EventArgs e)
    {
        //First:Fill the Employee smart search control
        //Smart_Search_Employee.sql_Connection = sql_Connection;
        //Smart_Search_Employee.Query = "select PMP_ID,pmp_name from dbo.EMPLOYEE";
        //Smart_Search_Employee.Value_Field = "PMP_ID";
        //Smart_Search_Employee.Text_Field = "pmp_name";
        //Smart_Search_Employee.DataBind();
        ////Second:fill the Direct manager smart search control with the same employee 
        ////names as loaded in the employee user control
        //Smart_Search_Direct_Manager.sql_Connection = sql_Connection;
        //Smart_Search_Direct_Manager.Query = "select PMP_ID,pmp_name from dbo.EMPLOYEE";
        //Smart_Search_Direct_Manager.Value_Field = "PMP_ID";
        //Smart_Search_Direct_Manager.Text_Field = "pmp_name";
        //Smart_Search_Direct_Manager.DataBind();

        //base.OnInit(e);//Call the base the original onit function of the user control


    }





}
