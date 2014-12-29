using System;
using System.Data.SqlClient;
using System.Data;


/// <summary>
/// Summary description for Vacations_Dayoff_DB
/// </summary>
public static class Vacations_Dayoff_DB
{
    #region "Private methods"

    private static Vacations_Dayoff_DT  FillInfoObject(SqlDataReader dr)
    {

        Vacations_Dayoff_DT oInfo_Vacation = new Vacations_Dayoff_DT();


        oInfo_Vacation.id = Convert.ToInt32(dr[Vacations_Dayoff_DT.EnumInfo_Vacations_Dayoff.id.ToString()]);
        oInfo_Vacation.user_id = dr[Vacations_Dayoff_DT.EnumInfo_Vacations_Dayoff.user_id.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Vacations_Dayoff_DT.EnumInfo_Vacations_Dayoff.user_id.ToString()]);
        oInfo_Vacation.request_user_id = dr[Vacations_Dayoff_DT.EnumInfo_Vacations_Dayoff.request_user_id.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Vacations_Dayoff_DT.EnumInfo_Vacations_Dayoff.request_user_id.ToString()]);
        //oInfo_Vacation.alternative_user_id = dr[Vacations_Dayoff_DT.EnumInfo_Vacations_Dayoff.alternative_user_id.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Vacations_Dayoff_DT.EnumInfo_Vacations_Dayoff.alternative_user_id.ToString()]);
        oInfo_Vacation.no_days = dr[Vacations_Dayoff_DT.EnumInfo_Vacations_Dayoff.no_days.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Vacations_Dayoff_DT.EnumInfo_Vacations_Dayoff.no_days.ToString()]);
        oInfo_Vacation.start_date = dr[Vacations_Dayoff_DT.EnumInfo_Vacations_Dayoff.start_date.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Vacations_Dayoff_DT.EnumInfo_Vacations_Dayoff.start_date.ToString()]);
        oInfo_Vacation.vacation_id = dr[Vacations_Dayoff_DT.EnumInfo_Vacations_Dayoff.vacation_id.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Vacations_Dayoff_DT.EnumInfo_Vacations_Dayoff.vacation_id.ToString()]);
        oInfo_Vacation.end_date = dr[Vacations_Dayoff_DT.EnumInfo_Vacations_Dayoff.end_date.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Vacations_Dayoff_DT.EnumInfo_Vacations_Dayoff.end_date.ToString()]);
        oInfo_Vacation.request_date = dr[Vacations_Dayoff_DT.EnumInfo_Vacations_Dayoff.request_date.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Vacations_Dayoff_DT.EnumInfo_Vacations_Dayoff.request_date.ToString()]);
        oInfo_Vacation.manager_approve = dr[Vacations_Dayoff_DT.EnumInfo_Vacations_Dayoff.manager_approve.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Vacations_Dayoff_DT.EnumInfo_Vacations_Dayoff.manager_approve.ToString()]);
        oInfo_Vacation.general_manager_approve = dr[Vacations_Dayoff_DT.EnumInfo_Vacations_Dayoff.general_manager_approve.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Vacations_Dayoff_DT.EnumInfo_Vacations_Dayoff.general_manager_approve.ToString()]);
        oInfo_Vacation.dept_id = dr[Vacations_Dayoff_DT.EnumInfo_Vacations_Dayoff.dept_id.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Vacations_Dayoff_DT.EnumInfo_Vacations_Dayoff.dept_id.ToString()]);

        //oInfo_Vacation.location = dr[Vacations_Dayoff_DT.EnumInfo_Vacations_Dayoff.location.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Vacations_Dayoff_DT.EnumInfo_Vacations_Dayoff.location.ToString()]);
        oInfo_Vacation.purpose = dr[Vacations_Dayoff_DT.EnumInfo_Vacations_Dayoff.purpose.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Vacations_Dayoff_DT.EnumInfo_Vacations_Dayoff.purpose.ToString()]);
        //oInfo_Vacation.person_to_meet = dr[Vacations_Dayoff_DT.EnumInfo_Vacations_Dayoff.person_to_meet.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Vacations_Dayoff_DT.EnumInfo_Vacations_Dayoff.person_to_meet.ToString()]);
        oInfo_Vacation.notes = dr[Vacations_Dayoff_DT.EnumInfo_Vacations_Dayoff.notes.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Vacations_Dayoff_DT.EnumInfo_Vacations_Dayoff.notes.ToString()]);
        oInfo_Vacation.start_hour = dr[Vacations_Dayoff_DT.EnumInfo_Vacations_Dayoff.start_hour.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Vacations_Dayoff_DT.EnumInfo_Vacations_Dayoff.start_hour.ToString()]);
        oInfo_Vacation.end_hour = dr[Vacations_Dayoff_DT.EnumInfo_Vacations_Dayoff.end_hour.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Vacations_Dayoff_DT.EnumInfo_Vacations_Dayoff.end_hour.ToString()]);
       // oInfo_Vacation.day_off = dr[Vacations_Dayoff_DT.EnumInfo_Vacations_Dayoff.day_off.ToString()] == DBNull.Value ? false : Convert.ToBoolean(dr[Vacations_Dayoff_DT.EnumInfo_Vacations_Dayoff.day_off.ToString()]);
        return oInfo_Vacation;
    }

    private static SqlParameter[] GetParameters(Vacations_Dayoff_DT obj, bool isSearch)
    {
        SqlParameter[] parms = new SqlParameter[15];


        if (!isSearch)
        {

            parms[0] = new SqlParameter(Vacations_Dayoff_DT.EnumInfo_Vacations_Dayoff.id.ToString(), obj.id);
            parms[0].Direction = ParameterDirection.InputOutput;

        }

        parms[1] = new SqlParameter(Vacations_Dayoff_DT.EnumInfo_Vacations_Dayoff.user_id.ToString(), obj.user_id);

        parms[2] = new SqlParameter(Vacations_Dayoff_DT.EnumInfo_Vacations_Dayoff.vacation_id.ToString(), obj.vacation_id);

        parms[3] = new SqlParameter(Vacations_Dayoff_DT.EnumInfo_Vacations_Dayoff.end_date.ToString(), obj.end_date);

        parms[4] = new SqlParameter(Vacations_Dayoff_DT.EnumInfo_Vacations_Dayoff.request_date.ToString(), obj.request_date);

        parms[5] = new SqlParameter(Vacations_Dayoff_DT.EnumInfo_Vacations_Dayoff.start_date.ToString(), obj.start_date);


        parms[6] = new SqlParameter(Vacations_Dayoff_DT.EnumInfo_Vacations_Dayoff.no_days.ToString(), obj.no_days);

        parms[7] = new SqlParameter(Vacations_Dayoff_DT.EnumInfo_Vacations_Dayoff.request_user_id.ToString(), obj.request_user_id);
        
        parms[8] = new SqlParameter(Vacations_Dayoff_DT.EnumInfo_Vacations_Dayoff.manager_approve.ToString(), obj.manager_approve);

        parms[9] = new SqlParameter(Vacations_Dayoff_DT.EnumInfo_Vacations_Dayoff.general_manager_approve.ToString(), obj.general_manager_approve);

        parms[10] = new SqlParameter(Vacations_Dayoff_DT.EnumInfo_Vacations_Dayoff.dept_id.ToString(), obj.dept_id);


        parms[11] = new SqlParameter(Vacations_Dayoff_DT.EnumInfo_Vacations_Dayoff.purpose.ToString(), obj.purpose);


        parms[12] = new SqlParameter(Vacations_Dayoff_DT.EnumInfo_Vacations_Dayoff.notes.ToString(), obj.notes);

        parms[13] = new SqlParameter(Vacations_Dayoff_DT.EnumInfo_Vacations_Dayoff.start_hour.ToString(), obj.start_hour);

        parms[14] = new SqlParameter(Vacations_Dayoff_DT.EnumInfo_Vacations_Dayoff.end_hour.ToString(), obj.end_hour);

        
        return parms;
    }

    #endregion

    public static int Save(Vacations_Dayoff_DT obj)
    {
        try
        {
            SqlParameter[] parms = GetParameters(obj, false);

            SqlHelper.ExecuteScalar(Database.ConnectionString, CommandType.StoredProcedure, "Add_Edit_VacationsDayOff", parms);
            return Convert.ToInt32(parms[0].Value);
        }
        catch (SqlException ex)
        {
            return -1;
        }
    }
    //ahmed.localoyb@gmail.com

    //eng.mahmoudeid@gmail.com
    //"remon" <remon@localoyb.com>, "Remon Gaber" <remongaber@hotmail.com>, 
    public static int Delete(int ID)
    {
        try
        {
            SqlHelper.ExecuteNonQuery(Database.ConnectionString, "Fin_Bills_Delete", ID);
            return ID;
        }
        catch (Exception ex)
        {
            return -1;
        }
    }

    public static DataTable SelectAll(int user_id)
    {
        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Get_User_VacationDayOffByID", user_id).Tables[0];
    }
    public static DataTable SelectByDayOff(int user_id)
    {
        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Get_User_Vacations_errand_DetailsDayOff", user_id).Tables[0];
    }
    public static DataTable Select_by_dept(int dept_id)
    {
        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Get_Dept_Vacations_DayOff_Details", dept_id).Tables[0];
    }
    public static DataTable SelectAll_by_user_id(int user_id)
    {
        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Get_User_Vacations_errand", user_id).Tables[0];
    }
    public static DataTable Select_VacOff_By_ID(int id)
    {
        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Get_Vacations_DayOff_ByID", id).Tables[0];
    }
    public static DataTable Select_old(int dept_id)
    {
        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Get_Dept_VcationDayOff_old", dept_id).Tables[0];
    }
    public static DataTable GetVacations_DayOffByID(int id)
    {
        return SqlHelper.ExecuteDataset(Database.ConnectionString, "GetVacations_DayOffByID", id).Tables[0];
    }

    public static DataTable Check_DT_Valid(string Strt_dt, string End_dt, int User_id)
    {
        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Vacations_DayOff_DT_Valid", Strt_dt, End_dt, User_id).Tables[0];
    }
    
}
