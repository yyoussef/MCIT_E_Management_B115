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
/// Summary description for Project_Region_DT
/// </summary>
public class Project_Region_DT
{
    public enum EnumInfo_Region
    {
        Project_Region_ID, Proj_id, Region_ID,
    }



    public Int32 Project_Region_ID;

    public Int32 Proj_id;

    public Int32 Region_ID;
}
