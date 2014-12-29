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
using System.Data.SqlClient;

/// <summary>
/// Summary description for Vocations_permission_DB
/// </summary>
/// 
public static class Vocations_permission_DB
{

    private static Vocations_permission_DT FillInfoObject(SqlDataReader dr)
    {

        Vocations_permission_DT oInfo_Vacation = new Vocations_permission_DT();

        oInfo_Vacation.id = Convert.ToInt32(dr[Vocations_permission_DT.EnumInfo_Vacation.id.ToString()]);
        oInfo_Vacation.user_id = dr[Vocations_permission_DT.EnumInfo_Vacation.user_id.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Vocations_permission_DT.EnumInfo_Vacation.user_id.ToString()]);
        oInfo_Vacation.request_user_id = dr[Vocations_permission_DT.EnumInfo_Vacation.request_user_id.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Vocations_permission_DT.EnumInfo_Vacation.request_user_id.ToString()]);
        oInfo_Vacation.alternative_user_id = dr[Vocations_permission_DT.EnumInfo_Vacation.alternative_user_id.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Vocations_permission_DT.EnumInfo_Vacation.alternative_user_id.ToString()]);
        oInfo_Vacation.permission_no = dr[Vocations_permission_DT.EnumInfo_Vacation.permission_no.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Vocations_permission_DT.EnumInfo_Vacation.permission_no.ToString()]);
        oInfo_Vacation.start_date = dr[Vocations_permission_DT.EnumInfo_Vacation.start_date.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Vocations_permission_DT.EnumInfo_Vacation.start_date.ToString()]);

        oInfo_Vacation.start_hour = dr[Vocations_permission_DT.EnumInfo_Vacation.start_hour.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Vocations_permission_DT.EnumInfo_Vacation.start_hour.ToString()]);
        oInfo_Vacation.end_hour = dr[Vocations_permission_DT.EnumInfo_Vacation.end_hour.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Vocations_permission_DT.EnumInfo_Vacation.end_hour.ToString()]);

        oInfo_Vacation.request_date = dr[Vocations_permission_DT.EnumInfo_Vacation.request_date.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Vocations_permission_DT.EnumInfo_Vacation.request_date.ToString()]);
        oInfo_Vacation.manager_approve = dr[Vocations_permission_DT.EnumInfo_Vacation.manager_approve.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Vocations_permission_DT.EnumInfo_Vacation.manager_approve.ToString()]);
        oInfo_Vacation.general_manager_approve = dr[Vocations_permission_DT.EnumInfo_Vacation.general_manager_approve.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Vocations_permission_DT.EnumInfo_Vacation.general_manager_approve.ToString()]);
        oInfo_Vacation.dept_id = dr[Vocations_permission_DT.EnumInfo_Vacation.dept_id.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Vocations_permission_DT.EnumInfo_Vacation.dept_id.ToString()]);
        return oInfo_Vacation;
    }

    private static SqlParameter[] GetParameters(Vocations_permission_DT obj, bool isSearch)
    {
        SqlParameter[] parms = new SqlParameter[12];


        if (!isSearch)
        {

            parms[0] = new SqlParameter(Vocations_permission_DT.EnumInfo_Vacation.id.ToString(), obj.id);
            parms[0].Direction = ParameterDirection.InputOutput;
        }

        parms[1] = new SqlParameter(Vocations_permission_DT.EnumInfo_Vacation.user_id.ToString(), obj.user_id);

        parms[2] = new SqlParameter(Vocations_permission_DT.EnumInfo_Vacation.dept_id.ToString(), obj.dept_id);

        parms[3] = new SqlParameter(Vocations_permission_DT.EnumInfo_Vacation.start_hour.ToString(), obj.start_hour);

        parms[4] = new SqlParameter(Vocations_permission_DT.EnumInfo_Vacation.request_date.ToString(), obj.request_date);

        parms[5] = new SqlParameter(Vocations_permission_DT.EnumInfo_Vacation.start_date.ToString(), obj.start_date);

        parms[6] = new SqlParameter(Vocations_permission_DT.EnumInfo_Vacation.alternative_user_id.ToString(), obj.alternative_user_id);

        parms[7] = new SqlParameter(Vocations_permission_DT.EnumInfo_Vacation.permission_no.ToString(), obj.permission_no);

        parms[8] = new SqlParameter(Vocations_permission_DT.EnumInfo_Vacation.request_user_id.ToString(), obj.request_user_id);

        parms[9] = new SqlParameter(Vocations_permission_DT.EnumInfo_Vacation.manager_approve.ToString(), obj.manager_approve);

        parms[10] = new SqlParameter(Vocations_permission_DT.EnumInfo_Vacation.general_manager_approve.ToString(), obj.general_manager_approve);

        parms[11] = new SqlParameter(Vocations_permission_DT.EnumInfo_Vacation.end_hour.ToString(), obj.end_hour);


        return parms;

    }



    public static int Save(Vocations_permission_DT obj)
    {
        try
        {
            SqlParameter[] parms = GetParameters(obj, false);

            SqlHelper.ExecuteScalar(Database.ConnectionString, CommandType.StoredProcedure, "Add_Edit_Vacation_permission", parms);
            return Convert.ToInt32(parms[0].Value);
        }
        catch (SqlException ex)
        {
            return -1;
        }
    }
    public static DataTable SelectAll(SqlParameter[] sqlParameters2)
    {
        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Get_Vocation_permission_Details", sqlParameters2).Tables[0];
    }
    public static DataTable Selecttotalbalance(SqlParameter[] sqlParameters)
    {
        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Get_Vocation_permission_remain", sqlParameters).Tables[0];
    }
    public static DataTable SelectAll_by_user_id2(int user_id, int year)
    {
        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Get_User_Vacations2", user_id,year).Tables[0];
    }
    public static DataTable Select_Vac_By_ID(int id)
    {
        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Get_permission_Details", id).Tables[0];
    }
    public static DataTable Check_DT_Valid(string Strt_dt, int User_id)
    {
        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Vocation_permission_DT_Valid", Strt_dt, User_id).Tables[0];
    }
    public static DataTable Select_by_dept(int dept_id)
    {
        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Get_Dept_Permission_Details", dept_id).Tables[0];
    }
    public static DataTable Select_by_dept0(int dept_id)
    {
        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Get_Dept_Vocation_permission_Details", dept_id).Tables[0];
    }
    public static DataTable Select_Old(int id)
    {
        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Get_Dept_VocationPerm_old", id).Tables[0];
    }
    
    public static int UpdatePerSummary(SqlParameter[] sqlParameters)
    {
        try
        {
            SqlHelper.ExecuteScalar(Database.ConnectionString, CommandType.StoredProcedure, "Update_Vacations_Summary", sqlParameters);
            return 1;
        }
        catch (SqlException ex)
        {

            return -1;
        }
    }



    public static DataTable Sector_VacationResposible(int sector_id, int foundation_id)
    {
        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Sector_VacationResposible", sector_id, foundation_id).Tables[0];
    }
}
