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
/// Summary description for Project_DT
/// </summary>
public class Project_DT
{
    public enum EnumInfo_Project
    {
        Protocol_ID, Proj_is_commit,Proj_Goal_Stratege, Proj_is_refused, Proj_is_repeated, Proj_Brief, Proj_Notes, Return_Value, Total_Balance_Value_LE, Total_Balance_Value_US, Proj_id, Dept_Dept_id, pmp_pmp_id, Period_by_year, File_data, Proj_Code, start_date_Plan, End_Date_Plan, start_date_Real, End_Date_Real, Region_Desc, Proj_Title, File_name, File_ext, Proj_Creation_Date,
    }



    public Int32 Protocol_ID;

    public Int32 Proj_is_commit;

    public Int32 Proj_is_refused;

    public Int32 Proj_is_repeated;

    public String Proj_Brief;

    public String Proj_Notes;

    public String Return_Value, Proj_Goal_Stratege;

    public Decimal Total_Balance_Value_LE;

    public Decimal Total_Balance_Value_US;

    public Int64 Proj_id;

    public Int64 Dept_Dept_id;

    public Int64 pmp_pmp_id;

    public Int64 Period_by_year;

    public Byte[] File_data;

    public String Proj_Code;

    public String start_date_Plan;

    public String End_Date_Plan;

    public String start_date_Real;

    public String End_Date_Real;

    public String Region_Desc;

    public String Proj_Title;

    public String File_name;

    public String File_ext;

    public String Proj_Creation_Date;
}
