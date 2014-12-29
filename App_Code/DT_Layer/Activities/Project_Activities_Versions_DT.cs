using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Project_Activities_Versions_DT
/// </summary>
public class Project_Activities_Versions_DT
{
    public enum EnumInfo_Activities_Versions_DT
    {
        PActv_wieght, PActv_Progress, PActv_Period, PActv_Actual_Period, PActv_ID, PActv_Parent, PActv_is_Milestone, proj_proj_id, ActStat_ActStat_id, Excutive_responsible_Org_Org_id, PActv_Desc, PActv_Start_Date, PActv_End_Date, PActv_Actual_Start_Date, PActv_Actual_End_Date, PActv_Implementing_person, Notes, summery, priorities, funding_res_id, funding_amount, funding_res_source, Actv_month, Actv_year
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

    public String PActv_Start_Date, Actv_year, Actv_month;

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
