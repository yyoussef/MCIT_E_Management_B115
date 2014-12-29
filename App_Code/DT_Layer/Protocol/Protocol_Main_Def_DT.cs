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
/// Summary description for Protocol_Main_Def_DT
/// </summary>
public class Protocol_Main_Def_DT
{
    public enum EnumInfo_Main_Def
    {
        Protocol_ID, Type, PMP_ID, Related_ID, Period_Year, Period_Month, Period_Day, Status, Total_Balance_LE, Total_Balance_US, Name, Signt_DT, Strt_DT, End_DT, Related_Type, Related_Protocol_ID,
    }



    public Int32 Protocol_ID, Related_ID, Related_Type, Related_Protocol_ID;

    public Int32 Type;

    public Int32 PMP_ID;

    public Int32 Period_Year;

    public Int32 Period_Month;

    public Int32 Period_Day;

    public Int32 Status;

    public Int64 Total_Balance_LE;

    public Int64 Total_Balance_US;

    public String Name;

    public String Signt_DT;

    public String Strt_DT;

    public String End_DT;
}
