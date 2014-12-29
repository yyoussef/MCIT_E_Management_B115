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

public partial class MainForm_AssignedActivities : System.Web.UI.Page
{
    Session_CS Session_CS = new Session_CS();
    protected void Page_Load(object sender, EventArgs e)
    {
        //////Proj Assigned Activities from view /////

        string sql_AssignedActivity = "select distinct proj_id,Proj_Title from Activities_Assigned_team";
        sql_AssignedActivity += " join Project_Activities on Activities_Assigned_team.activ_id=Project_Activities.PActv_ID";
        sql_AssignedActivity += " join Project on Project_Activities.proj_proj_id=Project.Proj_id where Activities_Assigned_team.emp_id = " + Session_CS.pmp_id.ToString();
        DataTable dt_AssignedActivity = General_Helping.GetDataTable(sql_AssignedActivity);
        GrdAssignedActivities.DataSource = dt_AssignedActivity;
        GrdAssignedActivities.DataBind();
    }
    public void GrdAssignedActivities_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int myproj = CDataConverter.ConvertToInt(e.CommandArgument);
        DataTable dt_Level = activityLeveling.ActivLevls.leveling(myproj, 0, 0, 0, 0);
        gvSub.DataSource = dt_Level;
        gvSub.DataBind();
        gvSub.Visible = true;
    }
    protected void gvSub_PreRender1(object sender, EventArgs e)
    {
        MergeRows(gvSub);

    }
    protected void MergeRows(GridView GridView)
    {
        
        if (GridView.Rows.Count > 1)
        {

            for (int rowIndex = GridView.Rows.Count - 2; rowIndex > -1; rowIndex--)
            {
                GridViewRow row = GridView.Rows[rowIndex];
                GridViewRow previousRow = GridView.Rows[rowIndex + 1];
                int lvl_row = CDataConverter.ConvertToInt(((TextBox)row.FindControl("txtLevel")).Text);
                int lvl_previousRow = CDataConverter.ConvertToInt(((TextBox)previousRow.FindControl("txtLevel")).Text);
                int activity=CDataConverter.ConvertToInt(((TextBox)row.FindControl("txtPActv_ID")).Text);


                if (lvl_previousRow < 5)
                    previousRow.Font.Size = 16 - lvl_previousRow * 2;
                else
                    previousRow.Font.Size = 8;
                
                    TextBox EmployeesTextBox = (TextBox)gvSub.Rows[rowIndex].FindControl("txtImplementingEmployee");
                    EmployeesTextBox.Text = "";
               
                string tempSql = "select *,pmp_name from Activities_Assigned_team join EMPLOYEE on Activities_Assigned_team.emp_id=EMPLOYEE.PMP_ID where Activities_Assigned_team.activ_id=" + activity;
                DataTable dt_AssignedActivity = General_Helping.GetDataTable(tempSql);
                if (dt_AssignedActivity.Rows.Count > 0)
                {
                    for (int i = 0; i < dt_AssignedActivity.Rows.Count;i++)
                        
                        EmployeesTextBox.Text += dt_AssignedActivity.Rows[i]["pmp_name"]+"; ";
                }
                if (lvl_row == 1)
                {
                    row.Font.Bold = true;
                    row.Font.Size = 14;
                    row.BackColor = System.Drawing.Color.FromArgb(235, 236, 239);
                    row.ForeColor = System.Drawing.Color.Black;

                }
                if (lvl_previousRow == 1)
                {
                    previousRow.Font.Bold = true;
                    previousRow.Font.Size = 14;
                    previousRow.BackColor = System.Drawing.Color.FromArgb(235, 236, 239);
                    previousRow.ForeColor = System.Drawing.Color.Black;
                }
                if (lvl_previousRow == 2)
                    previousRow.BackColor = System.Drawing.Color.FromArgb(138, 173, 198);

                if (lvl_previousRow == 3)
                    previousRow.BackColor = System.Drawing.Color.FromArgb(175, 207, 229);

                if (lvl_previousRow == 4)
                    previousRow.BackColor = System.Drawing.Color.FromArgb(194, 221, 238);

                if (lvl_previousRow == 5)
                    previousRow.BackColor = System.Drawing.Color.FromArgb(212, 226, 243);

                if (lvl_previousRow == 6)
                    previousRow.BackColor = System.Drawing.Color.FromArgb(240, 226, 243);

                if (lvl_previousRow == 7)
                    previousRow.BackColor = System.Drawing.Color.White;

                if (lvl_previousRow == 8)
                    previousRow.BackColor = System.Drawing.Color.White;

                if (lvl_previousRow == 9)
                    previousRow.BackColor = System.Drawing.Color.White;




                if (previousRow.Cells[1].Text == "&nbsp;")
                {
                    if (previousRow.Cells[1].RowSpan < 2)
                        row.Cells[1].RowSpan = 2;
                    else
                        row.Cells[1].RowSpan = CDataConverter.ConvertToInt(previousRow.Cells[1].RowSpan + 1);

                    previousRow.Cells[1].Visible = false;
                }


            }
        }
        else if (GridView.Rows.Count == 1)
        {
            GridView.Rows[0].Cells[1].Font.Bold = true;
            GridView.Rows[0].Cells[1].Font.Size = 14;
            GridView.Rows[0].Cells[1].BackColor = System.Drawing.Color.FromArgb(235, 236, 239);
        }
    }
}
