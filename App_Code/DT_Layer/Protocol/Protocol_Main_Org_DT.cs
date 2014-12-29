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
/// Summary description for Protocol_Main_Org_DT
/// </summary>
public class Protocol_Main_Org_DT
{
    public enum EnumInfo_Main_Org
    {
        Protocol_Org_ID, Protocol_ID, Org_Type, Org_ID, Total_Balance_LE, Total_Balance_US, Org_Responsibilities,
    }



    public Int32 Protocol_Org_ID;

    public Int32 Protocol_ID;

    public Int32 Org_Type;

    public Int32 Org_ID;

    public Int64 Total_Balance_LE;

    public Int64 Total_Balance_US;

    public string Org_Responsibilities;
}
