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
/// Summary description for Protocols_Def_DT
/// </summary>
public class Protocol_Def_DT
{
    public enum EnumInfo_Def
    {
        Protocol_ID,
	    PMP_ID ,
        Org_ID ,
	    Type ,
	    Status ,
	    Total_Balance_LE ,
	    Total_Balance_US ,
	    Name ,
	    Signt_Str_DT ,
	    Signt_End_DT ,
	    Documentary_DT ,
	    Concern_authority ,
	    approval_NM ,
	    approval_DT  ,
        Sign_Org,
        Sign_Authority,
        Job_Org,
        Job_Authority  ,
    }



    public Int32 Protocol_ID;

    public Int32 PMP_ID;

    public Int32 Org_ID;

    public Int32 Type;

    public Int32 Status;

    public Int64 Total_Balance_LE;

    public Int64 Total_Balance_US;

    public String Name, Job_Org, Job_Authority;

    public String Signt_Str_DT;

    public String Signt_End_DT;

    public String Documentary_DT;

    public String Concern_authority;

    public String approval_NM;

    public String approval_DT;

    public Boolean Sign_Org, Sign_Authority;
	
}

