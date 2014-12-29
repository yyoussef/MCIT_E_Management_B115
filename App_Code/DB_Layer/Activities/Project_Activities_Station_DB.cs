using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Project_Activities_Station_DB
/// </summary>
public static class Project_Activities_Station_DB
{
    public static int Save( Project_Activities_Station_DT Obj)
    {
        try
        {
           return SqlHelper.ExecuteNonQuery(Database.ConnectionString, "Project_Activities_Station_Save",  Obj.Month_id, Obj.PActv_ID, Obj.PActv_Progress, Obj.Notes);
        }
        catch (Exception ex)
        {
            return -1;
        }
    }

}
