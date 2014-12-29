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
public class Project_Assumptions_DT
{
    public enum EnumInfo_Objective
    {
        Psc_dl_asump_id, Psc_dl_asump_Desc, proj_proj_id, Type,
    }



    public Int32 Psc_dl_asump_id;

   

    public Int32 Type;

    public String Psc_dl_asump_Desc;

    public Int32 proj_proj_id;
}
