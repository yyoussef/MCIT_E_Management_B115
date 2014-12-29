using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Evaluation_Strengths_weaknesses_DT
/// </summary>
public class Evaluation_Strengths_weaknesses_DT
{
    public enum EnumInfo_Strengths_weaknesses
    {
        Id, Evaluation_id, Direct_Emp_Note, Top_Emp_Note, type
    }



    public Int32 Id;

    public Int32 Evaluation_id;

    public String Direct_Emp_Note;

    public String Top_Emp_Note;
    public Int32 type;
}
