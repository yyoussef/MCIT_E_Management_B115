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
/// Summary description for Inbox_OutBox_Files_DT
/// </summary>
public class Commission_Files_DT
{
    public enum EnumInfo_Commission_Files
    {
        Commission_File_ID, Commission_ID, Inbox_Or_Outbox, Original_Or_Attached, File_data, File_name, File_ext,
    }



    public Int32 Commission_File_ID;

    public Int32 Commission_ID;

    public Int32 Inbox_Or_Outbox;

    public Int32 Original_Or_Attached;

    public Byte[] File_data;

    public String File_name;

    public String File_ext;
}
