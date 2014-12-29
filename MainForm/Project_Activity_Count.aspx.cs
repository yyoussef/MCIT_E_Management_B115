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
using System.Drawing;

public partial class WebForms2_Project_Activity_Count : System.Web.UI.Page
{
    // Developed by nora //
    Session_CS Session_CS = new Session_CS();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session_CS.Project_id.ToString() != null)
            {
                Session_CS.Project_id = int.Parse(Request.QueryString["proj_id"].ToString());
                FillGrid();
            }
            //ColorRow();

        }
    }


    public void FillGrid()
    {

        int id = int.Parse(Request.QueryString["proj_id"].ToString());
        DataTable dt_Level = activityLeveling.ActivLevls.leveling(id, 0, 0, 0, 0);
        gvSub.DataSource = dt_Level;
        gvSub.DataBind();
        if (dt_Level.Rows.Count > 0)
        {
            Decimal rw_indx = 0;
            foreach (DataRow rw in dt_Level.Rows)
            {
                ((ProgressBar)gvSub.Rows[CDataConverter.ConvertToInt(rw_indx)].FindControl("SubPB")).SetProgress(CDataConverter.ConvertToInt(rw["PActv_wieght"]), 100);
                rw_indx += 1;
            }
        }

    }
    //protected override void OnPreRender(EventArgs e)
    //{
    //    base.OnPreRender(e);

    //    //link the css file
    //    this.lASTreeViewThemeCssFile.Text = "<link id='astreeviewcssfile' href='' type='text/css' rel='stylesheet' />";

    //    string script = string.Format("document.getElementById('astreeviewcssfile').href='{0}'", this.astvMyTree.ThemeCssFile);
    //    this.ClientScript.RegisterStartupScript(this.GetType(), "js" + Guid.NewGuid().ToString(), script, true);

    //}
    protected void gvSub_PreRender1(object sender, EventArgs e)
    {
        MergeRows(gvSub);



    }

    protected void MergeRows2(GridView GridView)
    {
        int id = int.Parse(Request.QueryString["proj_id"].ToString());

        DataTable dt_Level = activityLeveling.ActivLevls.leveling(id, 0, 0, 0, 0);
        if (dt_Level.Rows.Count > 1)
        {

            for (int rowIndex = GridView.Rows.Count - 1; rowIndex > -1; rowIndex--)
            {
                GridViewRow row = GridView.Rows[rowIndex];

                if (row.RowType == DataControlRowType.DataRow)
                {
                    int Activity_ID = Convert.ToInt32(dt_Level.Rows[rowIndex]["PActv_ID"]);

                    if (Activity_ID != 0)
                    {
                        string str = "select * from Project_Activity_Count where pmp_pmp_id=" + int.Parse(Session_CS.pmp_id.ToString()) + " and proj_id= " + int.Parse(Session_CS.Project_id.ToString()) + " and PActv_ID=" + Activity_ID;
                        DataTable dt = General_Helping.GetDataTable(str);

                        if (dt.Rows.Count > 0)
                        {
                            row.BackColor = System.Drawing.Color.FromArgb(237, 129, 150);
                            row.ForeColor = System.Drawing.Color.Black;

                        }
                    }
                }
            }
        }
    }
    protected void MergeRows(GridView GridView)
    {
        int id = int.Parse(Request.QueryString["proj_id"].ToString());

        DataTable dt_Level = activityLeveling.ActivLevls.leveling(id, 0, 0, 0, 0);
        if (dt_Level.Rows.Count > 1)
        {

            for (int rowIndex = GridView.Rows.Count - 2; rowIndex > -1; rowIndex--)
            {
                GridViewRow row = GridView.Rows[rowIndex];
                GridViewRow previousRow = GridView.Rows[rowIndex + 1];

                if (row.RowType == DataControlRowType.DataRow)
                {
                    int Activity_ID = Convert.ToInt32(dt_Level.Rows[rowIndex + 1]["PActv_ID"]);

                    if (Activity_ID != 0)
                    {

                        if (CDataConverter.ConvertToInt(dt_Level.Rows[rowIndex + 1]["LVL"]) < 5)
                            previousRow.Font.Size = 16 - CDataConverter.ConvertToInt(dt_Level.Rows[rowIndex + 1]["LVL"]) * 2;
                        else
                            previousRow.Font.Size = 8;


                        if (CDataConverter.ConvertToInt(dt_Level.Rows[rowIndex]["LVL"]) == 1)
                        {
                            row.Font.Bold = true;
                            row.Font.Size = 14;
                            row.BackColor = System.Drawing.Color.FromArgb(235, 236, 239);
                            row.ForeColor = System.Drawing.Color.Black;

                        }
                        if (CDataConverter.ConvertToInt(dt_Level.Rows[rowIndex + 1]["LVL"]) == 1)
                        {
                            previousRow.Font.Bold = true;
                            previousRow.Font.Size = 14;
                            previousRow.BackColor = System.Drawing.Color.FromArgb(235, 236, 239);
                            previousRow.ForeColor = System.Drawing.Color.Black;
                        }
                        if (CDataConverter.ConvertToInt(dt_Level.Rows[rowIndex + 1]["LVL"]) == 2)
                            previousRow.BackColor = System.Drawing.Color.FromArgb(138, 173, 198);

                        if (CDataConverter.ConvertToInt(dt_Level.Rows[rowIndex + 1]["LVL"]) == 3)
                            previousRow.BackColor = System.Drawing.Color.FromArgb(175, 207, 229);

                        if (CDataConverter.ConvertToInt(dt_Level.Rows[rowIndex + 1]["LVL"]) == 4)
                            previousRow.BackColor = System.Drawing.Color.FromArgb(194, 221, 238);

                        if (CDataConverter.ConvertToInt(dt_Level.Rows[rowIndex + 1]["LVL"]) == 5)
                            previousRow.BackColor = System.Drawing.Color.FromArgb(212, 226, 243);

                        if (CDataConverter.ConvertToInt(dt_Level.Rows[rowIndex + 1]["LVL"]) == 6)
                            previousRow.BackColor = System.Drawing.Color.FromArgb(240, 226, 243);

                        if (CDataConverter.ConvertToInt(dt_Level.Rows[rowIndex + 1]["LVL"]) == 7)
                            previousRow.BackColor = System.Drawing.Color.White;

                        if (CDataConverter.ConvertToInt(dt_Level.Rows[rowIndex + 1]["LVL"]) == 8)
                            previousRow.BackColor = System.Drawing.Color.White;

                        if (CDataConverter.ConvertToInt(dt_Level.Rows[rowIndex + 1]["LVL"]) == 9)
                            previousRow.BackColor = System.Drawing.Color.White;




                        if (previousRow.Cells[1].Text == "&nbsp;")
                        {
                            if (previousRow.Cells[1].RowSpan < 2)
                                row.Cells[1].RowSpan = 2;
                            else
                                row.Cells[1].RowSpan = CDataConverter.ConvertToInt(previousRow.Cells[1].RowSpan + 1);

                            previousRow.Cells[1].Visible = false;
                        }



                        //end

                    }
                }




            }
        }
        else if (GridView.Rows.Count == 1)
        {
            GridView.Rows[0].Cells[1].Font.Bold = true;
            GridView.Rows[0].Cells[1].Font.Size = 14;
            GridView.Rows[0].Cells[1].BackColor = System.Drawing.Color.FromArgb(235, 236, 239);
        }
        MergeRows2(gvSub);
    }
    //private void ColorRow()
    //{
    //    if (Session_CS.Project_id.ToString != null )
    //    {
    //    int ActID = 0;
    //    string str ="select * from Project_Activity_Count where pmp_pmp_id=" + int.Parse (Session_CS.pmp_id.ToString ()) + " and proj_id= " + int.Parse (Session_CS.Project_id.ToString ()) + "and PActv_ID=" +  ;
    //    DataTable dt = General_Helping.GetDataTable(str);
    //    if (dt.Rows.Count > 0)
    //    {
    //        for (int i= 0; )
    //        {
    //            ActID = int.Parse(dt.Rows[0]["PActv_ID"].ToString());
    //        }
    //    }
    //    //return  ActID;
    //}
    //    //  if (CDataConverter.ConvertToInt(dt_Level.Rows[rowIndex + 1]["LVL"]) == 8)
    //   // previousRow.BackColor = System.Drawing.Color.White;
    //}

    protected void gvSub_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }


}
