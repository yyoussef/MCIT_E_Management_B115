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
/// Summary description for Protocol_Projects_DT
/// </summary>
public class Protocol_Main_Committee_DT
{
    public enum EnumInfo_period_balance
    {
        ID, Protocol_ID, Person_Name, Person_Job, Org_Type, Org_id, Notes,Dept_id,
    }



    public Int64 ID;

    public Int64 Protocol_ID;
    
    public String Person_Name;

    public String Person_Job;

    public Int64 Org_Type;

    public Int64 Org_id;

    public String Notes;

    public Int64 Dept_id;
}
