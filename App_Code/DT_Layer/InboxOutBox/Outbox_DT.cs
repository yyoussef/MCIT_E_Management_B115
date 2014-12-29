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
/// Summary description for Inbox_DT
/// </summary>
public class Outbox_DT
{
    public enum EnumInfo_Outbox
    {
        ID, Proj_id, Type, Enter_Date, Group_id, pmp_pmp_id, Dept_ID, Source_Type, Org_Out_Box_Person, Org_Dept_Name, Emp_ID, Org_Id, Dept_Dept_id, Related_Type, Related_Id, Follow_Up_Dept_ID, Follow_Up_Emp_ID, Status, Subject, Notes, Name, Code, Date, Org_Name, Org_Out_Box_Code, Org_Out_Box_DT, Paper_No, Paper_Attached, Dept_Desc, sub_Cat_id, finished, foundation_id
    }



    public Int32 ID, Source_Type, finished, foundation_id;

    public Int32 Proj_id;

    public Int32 Type;

    public Int32 Dept_ID;

    public Int32 Emp_ID;

    public Int32 Org_Id, sub_Cat_id;

    public Int32 Group_id;

    public Int32 pmp_pmp_id;

    public Int32 Related_Type;

    public Int32 Related_Id;

    public Int32 Follow_Up_Dept_ID;

    public Int32 Follow_Up_Emp_ID;

    public Int32 Dept_Dept_id;

    public Int32 Status;

    public String Subject;

    public String Notes;

    public String Name;

    public String Code, Org_Out_Box_Person, Org_Dept_Name;

    public String Date;

    public String Enter_Date;

    public String Org_Name;

    public String Org_Out_Box_Code;

    public String Org_Out_Box_DT;

    public String Paper_No;

    public String Paper_Attached;

    public String Dept_Desc;
}
