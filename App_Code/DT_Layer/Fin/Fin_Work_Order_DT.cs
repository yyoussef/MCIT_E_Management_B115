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
/// Summary description for Fin_Work_Order_DT
/// </summary>
public class Fin_Work_Order_DT
{
    public enum EnumInfo_Work_Order
    {
        Work_Order_ID, Company_ID, Tender_Type_ID, Tender_NO, Tender_Year, Project_ID, Work_Total_Value, Bil_Total_Value, Work_Image, Work_File, Contract_Image, Contract_File, Code, Date, Comapny_Period, Work_Image_Type, Work_File_Type, Contract_Image_Type, Contract_File_Type,
    }




    public Int32 Work_Order_ID;
    public Int32 Company_ID;
    
    public Int32 Tender_Type_ID;

    public Int32 Tender_NO;

    public Int32 Tender_Year;

    public Int32 Project_ID;

    public Decimal Work_Total_Value;

    public Decimal Bil_Total_Value;

    public Byte[] Work_Image;

    public Byte[] Work_File;

    public Byte[] Contract_Image;

    public Byte[] Contract_File;

    public String Code;

    public String Date;

    public String Comapny_Period;

    public String Work_Image_Type;

    public String Work_File_Type;

    public String Contract_Image_Type;

    public String Contract_File_Type;

}
