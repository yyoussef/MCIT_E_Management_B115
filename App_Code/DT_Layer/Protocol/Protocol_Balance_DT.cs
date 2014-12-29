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
public class Protocol_Periods_Balance_DT
{
    public enum EnumInfo_period_balance
    {
        Protocol_Balance_ID, From_DT, To_DT,Amount_US,Amount_LE,Protocol_ID
    }



    public Int64 Protocol_Balance_ID;

    public String From_DT;

    public String To_DT;

    public Int64 Amount_US;

    public Int64 Amount_LE;

    public Int32 Protocol_ID;
}
