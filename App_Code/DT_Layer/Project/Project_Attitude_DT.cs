using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
//using System.Xml.Linq;

/// <summary>
/// Summary description for Project_Attitude_DT
/// </summary>
public class Project_Attitude_DT
{
    public enum EnumInfo_Project_Attitude
    {
        id, last_attitude_desc, last_attitude_date, Proj_id

    }
    public Int32  id;
    public string last_attitude_desc;
    public string last_attitude_date;
    public Int32 Proj_id;



}
