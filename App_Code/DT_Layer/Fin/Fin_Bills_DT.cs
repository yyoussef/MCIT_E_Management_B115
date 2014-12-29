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
/// Summary description for Fin_Bills_DT
/// </summary>
public class Fin_Bills_DT
{
    public enum EnumInfo_Bills
    {
        Bil_ID, Work_Order_ID, Bil_Value, Date, Notes, Code, Bil_Percent, Type, Project_ID, Source_id, Provider_id
    }


    public Int32 Bil_Percent, Type, Project_ID, Source_id, Provider_id;
    public string Code;
    /// <summary>
    /// 
    /// </summary>
    protected Int32 mBil_ID;
    public Int32 Bil_ID
    {
        get
        {
            return mBil_ID;
        }
        set
        {
            mBil_ID = value;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    protected Int32 mWork_Order_ID;
    public Int32 Work_Order_ID
    {
        get
        {
            return mWork_Order_ID;
        }
        set
        {
            mWork_Order_ID = value;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    protected Decimal mBil_Value;
    public Decimal Bil_Value
    {
        get
        {
            return mBil_Value;
        }
        set
        {
            mBil_Value = value;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    protected String mDate;
    public String Date
    {
        get
        {
            return mDate;
        }
        set
        {
            mDate = value;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    protected String mNotes;
    public String Notes
    {
        get
        {
            return mNotes;
        }
        set
        {
            mNotes = value;
        }
    }

}

