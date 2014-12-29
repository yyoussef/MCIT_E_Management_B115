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
/// Summary description for Protocol_Projects_DT
/// </summary>
public class Protocol_Projects_DT
{
    public enum EnumInfo_Projects
    {
        ID, Protocol_ID, Project_ID,
    }



    public Int32 ID;

    public Int32 Protocol_ID;

    public Int32 Project_ID;
}
