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
using System.Xml.Linq;

/// <summary>
/// Summary description for project_achievements_DT
/// </summary>
public class project_achievements_DT
{
    public enum EnumInfo_project_achievements
	{
        ach_id, ach_desc, ach_type, ach_other_desc, ach_from_date, ach_to_date, proj_id	
	}

    public Int64 ach_id; 
    public string ach_desc;
    public Int32 ach_type;
    public string ach_other_desc;
    public string ach_from_date;
    public string ach_to_date;
    public Int64 proj_id;
}
