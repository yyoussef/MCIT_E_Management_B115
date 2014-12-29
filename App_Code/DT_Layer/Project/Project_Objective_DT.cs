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
/// Summary description for Project_Objective_DT
/// </summary>
public class Project_Objective_DT
{
    public enum EnumInfo_Objective
    {
        Project_Object_ID, Proj_id, Type, Description,
    }



    public Int32 Project_Object_ID;

    public Int32 Proj_id;

    public Int32 Type;

    public String Description;
}
