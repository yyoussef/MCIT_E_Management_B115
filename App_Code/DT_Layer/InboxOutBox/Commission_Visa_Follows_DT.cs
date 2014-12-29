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
/// Summary description for Inbox_Visa_Follows_DT
/// </summary>
public class Commission_Visa_Follows_DT
{
    public enum EnumInfo_Visa_Follows
    {
        Follow_ID, Commission_ID, Visa_Emp_id, File_data, Descrption, Date, time_follow, File_name, File_ext, entery_pmp_id, Type_Follow,
    }



    public Int32 Follow_ID;

    public Int32 Commission_ID;

    public Int32 entery_pmp_id;

    public Int32 Type_Follow;

    public Int32 Visa_Emp_id;

    public Byte[] File_data;

    public String Descrption;

    public String Date;

    public String time_follow;

    public String File_name;

    public String File_ext;
}
