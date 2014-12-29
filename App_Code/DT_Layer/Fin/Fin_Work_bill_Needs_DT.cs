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
/// Summary description for Fin_Work_bill_Needs_DT
/// </summary>
public class Fin_Work_bill_Needs_DT
{
    public enum EnumInfo_Work_bill_Needs
    {
        Fin_Need_ID, NMT_ID, NST_ID, Value, Work_Or_Bill, Work_Or_Bill_ID,
    }



    public Int32 Fin_Need_ID;

    public Int32 NMT_ID;

    public Int32 NST_ID;

    public Int32 Value;

    public Int32 Work_Or_Bill;

    public Int32 Work_Or_Bill_ID;
}
