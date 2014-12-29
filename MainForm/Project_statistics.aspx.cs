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

public partial class WebForms_Project_statistics : System.Web.UI.Page
{
    Session_CS Session_CS = new Session_CS();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            FillGrid();
    }

    private void FillGrid()
    {

        DateTime dtime = CDataConverter.ConvertDateTimeNowRtnDt().AddDays(2);
        string tomorrowDT = dtime.ToString("d");

        DateTime monthtime = CDataConverter.ConvertDateTimeNowRtnDt().AddMonths(1);
        string monthDT = monthtime.ToString("d");


        DateTime todaytime = CDataConverter.ConvertDateTimeNowRtnDt();
        string todayDT = todaytime.ToString("d");

        string sqlQry = "";
        DataTable _dtS=new DataTable();
        if (Session_CS.UROL_UROL_ID.ToString() == "4")
        {
            switch (Request["show"].ToLower())
            {
                case "protocol":
                    sqlQry = "SELECT Protocol.*,Project.Proj_Title FROM Project INNER JOIN Protocol ON Project.Proj_id = Protocol.ProjID INNER JOIN Project_Team ON Project.Proj_id = Project_Team.proj_proj_id  " +
                       " WHERE convert(datetime, Protocol.Protocol_end_date,103) between convert(datetime, '" + todayDT + "',103) and convert(datetime, '" + monthDT + "',103)" +
                       " and Project_Team.pmp_pmp_id=" + Session_CS.pmp_id;
                    _dtS = General_Helping.GetDataTable(sqlQry);
                    if (_dtS.Rows.Count > 0)
                    {
                        protocol_gv.DataSource = _dtS;
                        protocol_gv.DataBind();
                        protocol.Visible = true;
                    }
                    break;
                case "meetingwithout":
                    sqlQry = "SELECT Meetings.*,Project.Proj_Title FROM Project INNER JOIN Meetings ON Project.Proj_id = Meetings.ProjID INNER JOIN Project_Team ON Project.Proj_id = Project_Team.proj_proj_id  " +
                    " WHERE Meetings.File_name='' and convert(datetime, Meetings.Meeting_date,103) between convert(datetime, '" + todayDT + "',103) and convert(datetime, '" + tomorrowDT + "',103) " +
                       " and Project_Team.pmp_pmp_id=" + Session_CS.pmp_id +
                       " order by Project.Proj_id asc";
                    _dtS = General_Helping.GetDataTable(sqlQry);
                    if (_dtS.Rows.Count > 0)
                    {
                        meetings_without_gv.DataSource = _dtS;
                        meetings_without_gv.DataBind();
                        meetingwithout.Visible = true;
                    }
                    break;
                case "meeting":
                    sqlQry = "SELECT Meetings.*,Project.Proj_Title FROM Project INNER JOIN Meetings ON Project.Proj_id = Meetings.ProjID INNER JOIN Project_Team ON Project.Proj_id = Project_Team.proj_proj_id  " +
                   " WHERE convert(datetime, Meetings.Meeting_date,103) between convert(datetime, '" + todayDT + "',103) and convert(datetime, '" + tomorrowDT + "',103) " +
                       " and Project_Team.pmp_pmp_id=" + Session_CS.pmp_id +
                       " order by Project.Proj_id asc";
                    _dtS = General_Helping.GetDataTable(sqlQry);
                    if (_dtS.Rows.Count > 0)
                    {
                        meetings_gv.DataSource = _dtS;
                        meetings_gv.DataBind();
                        meeting.Visible = true;
                    }
                    break;
                case "events":
                    sqlQry = "SELECT Event.*,Project.Proj_Title FROM Event INNER JOIN Project ON Event.ProjID = Project.Proj_id INNER JOIN Project_Team ON Project.Proj_id = Project_Team.proj_proj_id  " +
                    " WHERE convert(datetime, Event.Event_date,103) between convert(datetime, '" + todayDT + "',103) and convert(datetime, '" + tomorrowDT + "',103) " +
                       " and Project_Team.pmp_pmp_id=" + Session_CS.pmp_id +
                       " order by Project.Proj_id asc";
                    _dtS = General_Helping.GetDataTable(sqlQry);
                    if (_dtS.Rows.Count > 0)
                    {
                        events_gv.DataSource = _dtS;
                        events_gv.DataBind();
                        events.Visible = true;
                    }
                    break;
            }
        }
        if (Session_CS.UROL_UROL_ID.ToString() == "2" || Session_CS.UROL_UROL_ID.ToString() == "3")
        {
            if (Request["show"] != null)
            {
                switch (Request["show"].ToLower())
                {
                    case "events":
                        sqlQry = "SELECT Event.*,Project.Proj_Title FROM Event INNER JOIN Project ON Event.ProjID = Project.Proj_id " +
                        " WHERE convert(datetime, Event.Event_date,103) between convert(datetime, '" + todayDT + "',103) and convert(datetime, '" + tomorrowDT + "',103)" +
                           " and (Event.Event_attendence='" + Session_CS.pmp_id + "' or Event.Event_attendence LIKE '" + Session_CS.pmp_id + "#%' or Event.Event_attendence LIKE '%#" + Session_CS.pmp_id + "' or Event.Event_attendence LIKE '%#" + Session_CS.pmp_id + "#%') " +
                           " order by Project.Proj_id asc";
                        _dtS = General_Helping.GetDataTable(sqlQry);
                        if (_dtS.Rows.Count > 0)
                        {
                            events_gv.DataSource = _dtS;
                            events_gv.DataBind();
                            events.Visible = true;
                        }
                        break;
                }
            }
        }

        if (Session_CS.UROL_UROL_ID.ToString() == "8" || Session_CS.UROL_UROL_ID.ToString() == "2")
        {
            if (Request["Protocol"] != null)
            {
                int Status = CDataConverter.ConvertToInt(Request["Protocol"].ToString());
                if (Status == 1)
                    Label_protocol.Text = "بروتوكولات / اتفاقيات الجارية";
                else if (Status == 2)
                    Label_protocol.Text = "بروتوكولات / اتفاقيات المنجزة";
                else if (Status == 3)
                    Label_protocol.Text = "بروتوكولات / اتفاقيات المتوقفة";

                string sql = "Select * from Protocol_Def where Status =" + Status;
                DataTable dt_Prtcl = General_Helping.GetDataTable(sql);
                if (dt_Prtcl.Rows.Count > 0)
                {
                    grd_View_Protocol.DataSource = dt_Prtcl;
                    grd_View_Protocol.DataBind();
                    Div_Protocol.Visible = true;
                }
            }
        }
    }
    protected void ImgBtnBack_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/WebForms2/default.aspx?return=1");
    }
    public string Get_Type(object obj)
    {
        string str = obj.ToString();
        if (str == "1")
            return "بروتوكول";
        else if (str == "2")
            return "اتفاقية";
        else if (str == "3")
            return "موافقة السلطة المختصة";
        else return "بروتوكول";
    }
}
