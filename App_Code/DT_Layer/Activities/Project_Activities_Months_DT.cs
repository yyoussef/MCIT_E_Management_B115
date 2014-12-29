using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Project_Activities_Months_DT
/// </summary>
public class Project_Activities_Months_DT
{

    public enum EnumInfo_Activities_Months
    {
        ID, Month, Year, Notes, Active, End_DT
    }



    public Int32 ID;

    public String Month;

    public String Year;

    public String Notes,End_DT;

    public Boolean Active;

}
