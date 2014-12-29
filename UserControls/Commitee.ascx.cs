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

public partial class UserControls_CommiteeUserCont : System.Web.UI.UserControl
{
    Session_CS Session_CS = new Session_CS();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            fillgrid();
    }
    /// <summary>
    /// this function will save the input data of the new commitee into 
    /// the corresponding database commitee table when the save button is clicked.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        
      //  string sql = "select * from Commitee where Commitee_Title='" + txtBox_CommiteeName.Text + "' and foundation_id = " + CDataConverter.ConvertToInt(Session_CS.foundation_id.ToString());
        
      //  DataTable dt = General_Helping.GetDataTable(sql);

        DataTable dt = SqlHelper.ExecuteDataset(Database.ConnectionString, "CommiteeSelect", txtBox_CommiteeName.Text, CDataConverter.ConvertToInt(Session_CS.foundation_id.ToString())).Tables[0];

     
        if (dt.Rows.Count > 0)
        {
            lblPageStatus.Visible = true;
            lblPageStatus.Text = "هذة اللجنه موجوده من قبل";
            return;
        }

        Commitee_DT commObj = new Commitee_DT();
        //Assign the value in the txtBox_CommiteeName to the commitee_Title member of commObj 
        commObj.Commitee_Title = txtBox_CommiteeName.Text;//Set the commitee object with text box value
        commObj.foundation_id = Session_CS.foundation_id;
        commObj.ID = CDataConverter.ConvertToInt(currCommitee_id.Value);//Set the ID to be hidden field value, will be initially 0 to save and have value for update
        commObj.ID = Commitee_DB.Save(commObj);//Call the save function to save the data entered in the database and return the ID for the saved record
        txtBox_CommiteeName.Text = "";//Make the input fields empty
        currCommitee_id.Value = "";//reset the value of the hidden field
        if (commObj.ID > 0)//The save operation has been done successfully
        {
            //ClientScript
            // ClientScriptManager clScript = new ClientScriptManager();
            //clScript.RegisterStartupScript(Type.DefaultBinder,"Sucess", "<script language=javascript>alert('تم الحفظ بنجاح')</script>"
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('تم الحفظ بنجاح')</script>");
            fillgrid();

        }
    }
    /// <summary>
    /// Will fill the Grid view with the data loaded from the Commitee Table
    /// found in the database.
    /// </summary>
    private void fillgrid()
    {
        //Call Commitee_DB select all to retrieve all the commitee names found in the table commitee in database
        DataTable commiteeDT = Commitee_DB.SelectAll(0,Session_CS.foundation_id);
        gvMain.DataSource = commiteeDT;//assign the data table to the grid view data source
        gvMain.DataBind();//Bind the grid grid view to the data loaded in the datasource

    }
    /// <summary>
    /// This event will be fired whenever the Edit or the Delete buttons are clicked
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvMain_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Show")//then the Edit button is clicked against certain commitee row in grid
        {
            //First read the Commitee Object from the Database that has been selected to be edited
            //Note that the selected Commitee ID is reserved in the Commannd Argument of the Row
            Commitee_DT commObj = Commitee_DB.SelectByID(CDataConverter.ConvertToInt(e.CommandArgument),CDataConverter.ConvertToInt(Session_CS.foundation_id.ToString()));
            txtBox_CommiteeName.Text = commObj.Commitee_Title.ToString();
            currCommitee_id.Value = commObj.ID.ToString();//put the id of the updated commitee in the hidden filed
            

        }
        else if (e.CommandName == "dlt")//then the delete button is clicked against certain commitee row in grid
        {

           // DataTable dt_delete = General_Helping.GetDataTable("select * from commitee_presidents where comt_id = " + e.CommandArgument);

            DataTable dt_delete = SqlHelper.ExecuteDataset(Database.ConnectionString, "Selectcommitee_presidents", e.CommandArgument).Tables[0];

            if (dt_delete.Rows.Count>0)
            {
                Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لم يتم الحذف بسبب وجود موظفين مرتبطين بهذه اللجنة')</script>");
                return;
            }
            Commitee_DB.Delete(CDataConverter.ConvertToInt(e.CommandArgument));//Call the delete operation of the database class created for the commitee
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('تم الحذف بنجاح')</script>");
            fillgrid();//Refresh the grid
            txtBox_CommiteeName.Text = "";//Empty the field if there was anything in it
        }
    }
}
