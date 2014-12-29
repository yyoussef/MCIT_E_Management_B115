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
/// Summary description for Project_Activities_DT
/// </summary>
public class Project_Activities_DT
{
    public enum EnumInfo_Activities
    {
        PActv_wieght, PActv_Progress, PActv_Period, PActv_Actual_Period, PActv_ID, PActv_Parent, PActv_is_Milestone, proj_proj_id, ActStat_ActStat_id, Excutive_responsible_Org_Org_id, PActv_Desc, PActv_Start_Date, PActv_End_Date, PActv_Actual_Start_Date, PActv_Actual_End_Date, PActv_Implementing_person, Notes, summery, priorities, funding_res_id, funding_amount, funding_res_source
    }



    public Decimal PActv_wieght;

    public Decimal PActv_Progress;

    public Decimal PActv_Period;

    public Decimal PActv_Actual_Period;

    public Int64 PActv_ID;

    public Int64 PActv_Parent;

    public Int64 PActv_is_Milestone;

    public Int64 proj_proj_id;

    public Int64 ActStat_ActStat_id;

    public Int64 Excutive_responsible_Org_Org_id;

    public String PActv_Desc;

    public String PActv_Start_Date;

    public String PActv_End_Date;

    public String PActv_Actual_Start_Date;

    public String PActv_Actual_End_Date;

    public String PActv_Implementing_person;

    public String Notes;

    public String summery;

    public Int64 priorities;

    public Int64 funding_res_id; 
    
    public Int64 funding_amount;

    public Int64 funding_res_source;
}
