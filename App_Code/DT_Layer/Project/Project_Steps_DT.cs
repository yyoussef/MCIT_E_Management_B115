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
/// Summary description for Project_Steps_DT
/// </summary>
public class Project_Steps_DT
{
    public enum EnumInfo_Steps
    {
        Project_Steps_ID, Proj_id, Type, Statge_Name, Statge_Out_Put,
    }



    public Int32 Project_Steps_ID;

    public Int32 Proj_id;

    public Int32 Type;

    public String Statge_Name;

    public String Statge_Out_Put;
}
