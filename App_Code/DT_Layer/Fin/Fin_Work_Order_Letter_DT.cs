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
/// Summary description for Fin_Work_Order_Letter_DT
/// </summary>
public class Fin_Work_Order_Letter_DT
{
    public enum EnumInfo_Work_Order_Letter
    {
        Letter_Id, Work_Order_ID, Letter_Value, Letter_Percent, Type, Letter_File, Strt_DT, End_Dt, Bank, Letter_File_Type, Alarm_DT,
    }



    public Int32 Letter_Id;

    public Int32 Work_Order_ID;

    public Int32 Letter_Value;

    public Int32 Letter_Percent;

    public Int32 Type;

    public Byte[] Letter_File;

    public String Strt_DT;

    public String End_Dt;

    public String Bank;

    public String Letter_File_Type;

    public String Alarm_DT;
}
