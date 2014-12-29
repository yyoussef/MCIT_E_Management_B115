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
/// Summary description for Inbox_track_manager_DT
/// </summary>
public class Inbox_track_manager_DT
{
    public enum EnumInfo_Inbox_track_manager
    {
        inbox_id, IS_New_Mail, Have_Follow, Have_Visa, Visa_Desc, IS_Old_Mail, pmp_id, parent_pmp_id, Type_Track, All_visa_sent, status,
    }



    public Int32 inbox_id;

    public Int32 status;

    public Int32 IS_New_Mail;

    public Int32 IS_Old_Mail;

    public Int32 Have_Follow;

    public Int32 Have_Visa;

    public Int32 All_visa_sent;

    public Int32 pmp_id;

    public Int32 parent_pmp_id;

    public Int32 Type_Track;

    public string Visa_Desc;



   
}
