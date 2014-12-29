using System;
using System.Data.SqlClient;
using System.Data;


/// <summary>
/// Summary description for Vacations_DB
/// </summary>
public static class Vacations_DB
{
    #region "Private methods"

    private static Vacations_DT FillInfoObject(SqlDataReader dr)
    {

        Vacations_DT oInfo_Vacation = new Vacations_DT();

        oInfo_Vacation.id = Convert.ToInt32(dr[Vacations_DT.EnumInfo_Vacation.id.ToString()]);
        oInfo_Vacation.user_id = dr[Vacations_DT.EnumInfo_Vacation.user_id.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Vacations_DT.EnumInfo_Vacation.user_id.ToString()]);
        oInfo_Vacation.request_user_id = dr[Vacations_DT.EnumInfo_Vacation.request_user_id.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Vacations_DT.EnumInfo_Vacation.request_user_id.ToString()]);
        oInfo_Vacation.alternative_user_id = dr[Vacations_DT.EnumInfo_Vacation.alternative_user_id.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Vacations_DT.EnumInfo_Vacation.alternative_user_id.ToString()]);
        oInfo_Vacation.no_days = dr[Vacations_DT.EnumInfo_Vacation.no_days.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Vacations_DT.EnumInfo_Vacation.no_days.ToString()]);
        oInfo_Vacation.start_date = dr[Vacations_DT.EnumInfo_Vacation.start_date.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Vacations_DT.EnumInfo_Vacation.start_date.ToString()]);
        oInfo_Vacation.vacation_id = dr[Vacations_DT.EnumInfo_Vacation.vacation_id.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Vacations_DT.EnumInfo_Vacation.vacation_id.ToString()]);
        oInfo_Vacation.end_date = dr[Vacations_DT.EnumInfo_Vacation.end_date.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Vacations_DT.EnumInfo_Vacation.end_date.ToString()]);
        oInfo_Vacation.request_date = dr[Vacations_DT.EnumInfo_Vacation.request_date.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Vacations_DT.EnumInfo_Vacation.request_date.ToString()]);
        oInfo_Vacation.manager_approve = dr[Vacations_DT.EnumInfo_Vacation.manager_approve.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Vacations_DT.EnumInfo_Vacation.manager_approve.ToString()]);
        oInfo_Vacation.general_manager_approve = dr[Vacations_DT.EnumInfo_Vacation.general_manager_approve.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Vacations_DT.EnumInfo_Vacation.general_manager_approve.ToString()]);
        oInfo_Vacation.dept_id = dr[Vacations_DT.EnumInfo_Vacation.dept_id.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Vacations_DT.EnumInfo_Vacation.dept_id.ToString()]);
        oInfo_Vacation.type = dr[Vacations_DT.EnumInfo_Vacation.type.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Vacations_DT.EnumInfo_Vacation.type.ToString()]);
        oInfo_Vacation.notes = dr[Vacations_DT.EnumInfo_Vacation.notes.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Vacations_DT.EnumInfo_Vacation.notes.ToString()]);
        oInfo_Vacation.file_name = dr[Vacations_DT.EnumInfo_Vacation.file_name.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Vacations_DT.EnumInfo_Vacation.file_name.ToString()]);

        return oInfo_Vacation;
    }

    private static SqlParameter[] GetParameters(Vacations_DT obj, bool isSearch)
    {
        SqlParameter[] parms = new SqlParameter[15];


        if (!isSearch)
        {

            parms[0] = new SqlParameter(Vacations_DT.EnumInfo_Vacation.id.ToString(), obj.id);
            parms[0].Direction = ParameterDirection.InputOutput;

        }

        parms[1] = new SqlParameter(Vacations_DT.EnumInfo_Vacation.user_id.ToString(), obj.user_id);

        parms[2] = new SqlParameter(Vacations_DT.EnumInfo_Vacation.vacation_id.ToString(), obj.vacation_id);

        parms[3] = new SqlParameter(Vacations_DT.EnumInfo_Vacation.end_date.ToString(), obj.end_date);

        parms[4] = new SqlParameter(Vacations_DT.EnumInfo_Vacation.request_date.ToString(), obj.request_date);

        parms[5] = new SqlParameter(Vacations_DT.EnumInfo_Vacation.start_date.ToString(), obj.start_date);

        parms[6] = new SqlParameter(Vacations_DT.EnumInfo_Vacation.alternative_user_id.ToString(), obj.alternative_user_id);

        parms[7] = new SqlParameter(Vacations_DT.EnumInfo_Vacation.no_days.ToString(), obj.no_days);

        parms[8] = new SqlParameter(Vacations_DT.EnumInfo_Vacation.request_user_id.ToString(), obj.request_user_id);

        parms[9] = new SqlParameter(Vacations_DT.EnumInfo_Vacation.manager_approve.ToString(), obj.manager_approve);

        parms[10] = new SqlParameter(Vacations_DT.EnumInfo_Vacation.general_manager_approve.ToString(), obj.general_manager_approve);

        parms[11] = new SqlParameter(Vacations_DT.EnumInfo_Vacation.dept_id.ToString(), obj.dept_id);
        parms[12] = new SqlParameter(Vacations_DT.EnumInfo_Vacation.type.ToString(), obj.type);
        parms[13] = new SqlParameter(Vacations_DT.EnumInfo_Vacation.notes.ToString(), obj.notes);
        parms[14] = new SqlParameter(Vacations_DT.EnumInfo_Vacation.file_name.ToString(), obj.file_name);

        return parms;
    }

    #endregion

    public static int Save(Vacations_DT obj)
    {
        try
        {
            
            
            
            SqlParameter[] parms = GetParameters(obj, false);

            SqlHelper.ExecuteScalar(Database.ConnectionString, CommandType.StoredProcedure, "Add_Edit_Vacation", parms);
            return Convert.ToInt32(parms[0].Value);
        }
        catch (SqlException ex)
        {
            return -1;
        }
    }

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

    public static DataTable SelectAll(SqlParameter[] sqlParameters)
    {
        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Get_User_Vacations_Details", sqlParameters).Tables[0];
    }

    public static DataTable Select_by_dept(int dept_id)
    {
        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Get_Dept_Vacations_Details", dept_id).Tables[0];
    }

    public static DataTable SelectVac_by_dept(int dept_id)
    {
        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Get_Dept_VacationsErg_Details", dept_id).Tables[0];
    }

    public static DataTable Select_old(int dept_id)
    {
        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Get_Dept_Vacations_old", dept_id).Tables[0];
    }

    public static DataTable SelectAll_by_user_id(int user_id)
    {
        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Get_User_Vacations", user_id).Tables[0];
    }

    public static DataTable SelectAll_by_user_id2(int user_id, int year)
    {
        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Get_User_Vacations2", user_id, year).Tables[0];
    }
    public static DataTable get_user_role(int pmp_pmp_id)
    {
        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Get_User_Role", pmp_pmp_id).Tables[0];
    }
    public static DataTable get_vacation_limit(int vacID)
    {
        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Get_Vacation_Limit", vacID).Tables[0];
    }
    public static DataTable SelectByID(SqlParameter[] sqlParameters)
    {
        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Get_User_Vacations_Balance3", sqlParameters).Tables[0];
    }
    public static DataTable SelectVacSummary(SqlParameter[] sqlParameters)
    {
        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Get_User_Vacations_Summary", sqlParameters).Tables[0];
    }
    public static int UpdateVacSummary(SqlParameter[] sqlParameters)
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
    public static int UpdatePermSummary(SqlParameter[] sqlParameters)
    {
        try
        {
            SqlHelper.ExecuteScalar(Database.ConnectionString, CommandType.StoredProcedure, "Update_Permission_Summary", sqlParameters);
            return 1;
        }
        catch (SqlException ex)
        {

            return -1;
        }
    }


    public static DataTable SelectByID_Gmanager(SqlParameter[] sqlParameters)
    {
        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Get_User_Vacations_Balance2", sqlParameters).Tables[0];
    }
    public static DataTable Select_Vac_By_ID(int id)
    {
        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Get_Vacation_Details", id).Tables[0];
    }

    public static void vacation_summary(int vac_id)
    {
        int curYear = CDataConverter.ConvertDateTimeNowRtnDt().Year;
        SqlParameter[] sqlParams = new SqlParameter[] { new SqlParameter("@vac_id", CDataConverter.ConvertToInt(vac_id)), 
                                    new SqlParameter("@year", curYear.ToString())};
        DataTable SummaryDT = Vacations_DB.SelectVacSummary(sqlParams);
        string field_name = "";
        //if (CDataConverter.ConvertToInt(SummaryDT.Rows[0]["vacation_id"]) > 0 && CDataConverter.ConvertToInt(SummaryDT.Rows[0]["vacation_id"]) < 4)
        //{
        //    switch (CDataConverter.ConvertToInt(SummaryDT.Rows[0]["vacation_id"]))
        //    {
        //        case 1:
        //            field_name = "unusual";
        //            break;
        //        case 2:
        //            field_name = "exhibitor";
        //            break;
        //        case 3:
        //            field_name = "sick";
        //            break;
        //    }
        //}
        if (CDataConverter.ConvertToInt(SummaryDT.Rows[0]["vacation_id"]) == 1)
        {
            field_name = "unusual";
        }
        else if (CDataConverter.ConvertToInt(SummaryDT.Rows[0]["vacation_id"]) ==2)
        {
            field_name = "exhibitor";
        }
        else if (CDataConverter.ConvertToInt(SummaryDT.Rows[0]["vacation_id"]) == 3)
        {
            field_name = "sick";
        }
        else if (CDataConverter.ConvertToInt(SummaryDT.Rows[0]["vacation_id"]) == 5)
        {
            field_name = "hajj";
        }
        else if (CDataConverter.ConvertToInt(SummaryDT.Rows[0]["vacation_id"]) == 6)
        {
            field_name = "birth";
        }
        else if (CDataConverter.ConvertToInt(SummaryDT.Rows[0]["vacation_id"]) == 8)
        {
            field_name = "day_off_no";
        }
        if (field_name != "")
        {
            SqlParameter[] sqlParams2 = new SqlParameter[] { new SqlParameter("@result", CDataConverter.ConvertToInt(SummaryDT.Rows[0]["id"])), 
                                    new SqlParameter("@year", curYear.ToString()),
                                    new SqlParameter("@emp_id", CDataConverter.ConvertToInt(SummaryDT.Rows[0]["user_id"])),
                                    new SqlParameter("@no_days", CDataConverter.ConvertToInt(SummaryDT.Rows[0]["no_days"])),
                                    new SqlParameter("@field", field_name)};
            int UpdateSummary = Vacations_DB.UpdateVacSummary(sqlParams2);

            string sql_query = "UPDATE Vacations_summary set " + field_name + "=" + field_name + "-" + SummaryDT.Rows[0]["no_days"].ToString() + "  WHERE(emp_id = " + SummaryDT.Rows[0]["user_id"].ToString() + " and year = '" + curYear + "')";

            int result = General_Helping.ExcuteQuery(sql_query);
        }
    }

    public static DataTable Check_DT_Valid(string Strt_dt, string End_dt, int User_id)
    {
        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Vacations_users_DT_Valid", Strt_dt, End_dt, User_id).Tables[0];
    }
}
