using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Vacations_summary_DB
/// </summary>
public class Vacations_summary_DT
{
    public enum EnumInfo_summary
    {
        id, emp_id, unusual, exhibitor, sick, hajj, birth, repeat, year,unusual_total,exhibitor_total
    }



    public Int32 id;

    public Int32 emp_id;

    public Int32 unusual;

    public Int32 exhibitor;

    public Int32 sick;

    public Int32 hajj;

    public Int32 birth;

    public Int32 repeat;

    public String year;

    public Int32 unusual_total;

    public Int32 exhibitor_total;

}
