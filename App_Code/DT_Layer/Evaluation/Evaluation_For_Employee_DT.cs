using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Evaluation_For_Employee_DT
/// </summary>
public class Evaluation_For_Employee_DT
{
    public enum EnumInfo_For_Employee
    {
        Evaluation_id, Pmp_Id, Month, Year, Direct_Mng_Finished, Top_Mng_Finished, Evaluator_emp_ID,
    }



    public Int32 Evaluation_id;

    public Int32 Pmp_Id;

    public Int32 Month;

    public Int32 Year;

    public Boolean Direct_Mng_Finished;

    public Boolean Top_Mng_Finished;

    public Int32 Evaluator_emp_ID;

}
