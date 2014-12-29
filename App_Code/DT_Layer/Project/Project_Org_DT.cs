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
/// Summary description for Project_Org_DT
/// </summary>
public class Project_Org_DT
{
    public enum EnumInfo_Org
    {
        Project_Org_ID, Proj_id, Org_Type, Org_ID,
    }



    public Int32 Project_Org_ID;

    public Int32 Proj_id;

    public Int32 Org_Type;

    public Int32 Org_ID;
}
