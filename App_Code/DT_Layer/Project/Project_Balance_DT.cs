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
/// Summary description for Project_Balance_DT
/// </summary>
public class Project_Balance_DT
{
    public enum EnumInfo_Balance
    {
        Project_Balnce_ID, Proj_id, Fincial_Year_ID, Balance_Value_LE, Balance_Value_US, Description, Source_Desc, Total_Value
    }



    public Int32 Project_Balnce_ID;

    public Int32 Proj_id;

    public Int32 Fincial_Year_ID;

    public Decimal Balance_Value_LE;

    public Decimal Balance_Value_US, Total_Value;

    public String Description;

    public String Source_Desc;
}
