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
/// Summary description for Evaluation_Dept_Weightsc
/// </summary>
public class Evaluation_Dept_Weight_DT
{
    public enum EnumInfo_Evaluation_Dept_Weight
    {
        Weight_Id, Dept_id, Main_Item_Id, Sub_Item_Id, Weight, category
    }
    public Int32 Weight_Id, Dept_id, Main_Item_Id, Sub_Item_Id, category;
    public Decimal Weight;
}
