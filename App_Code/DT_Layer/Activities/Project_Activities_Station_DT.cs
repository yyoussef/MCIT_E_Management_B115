using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Project_Activities_Station
/// </summary>
public class Project_Activities_Station_DT
{
    public enum EnumInfo_Activities_Versions_DT
    {
        Station_ID, Month_id, PActv_ID, PActv_Progress, Notes
    }



    public Decimal PActv_Progress;

    public int Station_ID, Month_id, PActv_ID;

    public string Notes;
}
