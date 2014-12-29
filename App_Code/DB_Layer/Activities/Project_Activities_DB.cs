using System;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for Project_Activities_DB
/// </summary>
public static class Project_Activities_DB
{
    #region "Private methods"

    private static Project_Activities_DT FillInfoObject(SqlDataReader dr)
    {

        Project_Activities_DT oInfo_Activities = new Project_Activities_DT();


        oInfo_Activities.PActv_wieght = dr[Project_Activities_DT.EnumInfo_Activities.PActv_wieght.ToString()] == DBNull.Value ? 0 : Convert.ToDecimal(dr[Project_Activities_DT.EnumInfo_Activities.PActv_wieght.ToString()]);
        oInfo_Activities.PActv_Progress = dr[Project_Activities_DT.EnumInfo_Activities.PActv_Progress.ToString()] == DBNull.Value ? 0 : Convert.ToDecimal(dr[Project_Activities_DT.EnumInfo_Activities.PActv_Progress.ToString()]);
        oInfo_Activities.PActv_Period = dr[Project_Activities_DT.EnumInfo_Activities.PActv_Period.ToString()] == DBNull.Value ? 0 : Convert.ToDecimal(dr[Project_Activities_DT.EnumInfo_Activities.PActv_Period.ToString()]);
        oInfo_Activities.PActv_Actual_Period = dr[Project_Activities_DT.EnumInfo_Activities.PActv_Actual_Period.ToString()] == DBNull.Value ? 0 : Convert.ToDecimal(dr[Project_Activities_DT.EnumInfo_Activities.PActv_Actual_Period.ToString()]);
        oInfo_Activities.PActv_ID = Convert.ToInt64(dr[Project_Activities_DT.EnumInfo_Activities.PActv_ID.ToString()]);
        oInfo_Activities.PActv_Parent = dr[Project_Activities_DT.EnumInfo_Activities.PActv_Parent.ToString()] == DBNull.Value ? 0 : Convert.ToInt64(dr[Project_Activities_DT.EnumInfo_Activities.PActv_Parent.ToString()]);
        oInfo_Activities.PActv_is_Milestone = dr[Project_Activities_DT.EnumInfo_Activities.PActv_is_Milestone.ToString()] == DBNull.Value ? 0 : Convert.ToInt64(dr[Project_Activities_DT.EnumInfo_Activities.PActv_is_Milestone.ToString()]);
        oInfo_Activities.proj_proj_id = dr[Project_Activities_DT.EnumInfo_Activities.proj_proj_id.ToString()] == DBNull.Value ? 0 : Convert.ToInt64(dr[Project_Activities_DT.EnumInfo_Activities.proj_proj_id.ToString()]);
        oInfo_Activities.ActStat_ActStat_id = dr[Project_Activities_DT.EnumInfo_Activities.ActStat_ActStat_id.ToString()] == DBNull.Value ? 0 : Convert.ToInt64(dr[Project_Activities_DT.EnumInfo_Activities.ActStat_ActStat_id.ToString()]);
        oInfo_Activities.Excutive_responsible_Org_Org_id = dr[Project_Activities_DT.EnumInfo_Activities.Excutive_responsible_Org_Org_id.ToString()] == DBNull.Value ? 0 : Convert.ToInt64(dr[Project_Activities_DT.EnumInfo_Activities.Excutive_responsible_Org_Org_id.ToString()]);
        oInfo_Activities.PActv_Desc = dr[Project_Activities_DT.EnumInfo_Activities.PActv_Desc.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Project_Activities_DT.EnumInfo_Activities.PActv_Desc.ToString()]);
        oInfo_Activities.PActv_Start_Date = dr[Project_Activities_DT.EnumInfo_Activities.PActv_Start_Date.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Project_Activities_DT.EnumInfo_Activities.PActv_Start_Date.ToString()]);
        oInfo_Activities.PActv_End_Date = dr[Project_Activities_DT.EnumInfo_Activities.PActv_End_Date.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Project_Activities_DT.EnumInfo_Activities.PActv_End_Date.ToString()]);
        oInfo_Activities.PActv_Actual_Start_Date = dr[Project_Activities_DT.EnumInfo_Activities.PActv_Actual_Start_Date.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Project_Activities_DT.EnumInfo_Activities.PActv_Actual_Start_Date.ToString()]);
        oInfo_Activities.PActv_Actual_End_Date = dr[Project_Activities_DT.EnumInfo_Activities.PActv_Actual_End_Date.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Project_Activities_DT.EnumInfo_Activities.PActv_Actual_End_Date.ToString()]);
        oInfo_Activities.PActv_Implementing_person = dr[Project_Activities_DT.EnumInfo_Activities.PActv_Implementing_person.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Project_Activities_DT.EnumInfo_Activities.PActv_Implementing_person.ToString()]);
        oInfo_Activities.Notes = dr[Project_Activities_DT.EnumInfo_Activities.Notes.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Project_Activities_DT.EnumInfo_Activities.Notes.ToString()]);
        oInfo_Activities.summery = dr[Project_Activities_DT.EnumInfo_Activities.summery.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Project_Activities_DT.EnumInfo_Activities.summery.ToString()]);
        oInfo_Activities.priorities = dr[Project_Activities_DT.EnumInfo_Activities.priorities.ToString()] == DBNull.Value ? 0 : Convert.ToInt64(dr[Project_Activities_DT.EnumInfo_Activities.priorities.ToString()]);
        oInfo_Activities.funding_res_id = dr[Project_Activities_DT.EnumInfo_Activities.funding_res_id.ToString()] == DBNull.Value ? 0 : Convert.ToInt64(dr[Project_Activities_DT.EnumInfo_Activities.funding_res_id.ToString()]);
        oInfo_Activities.funding_amount = dr[Project_Activities_DT.EnumInfo_Activities.funding_amount.ToString()] == DBNull.Value ? 0 : Convert.ToInt64(dr[Project_Activities_DT.EnumInfo_Activities.funding_amount.ToString()]);
        oInfo_Activities.funding_res_source = dr[Project_Activities_DT.EnumInfo_Activities.funding_res_source.ToString()] == DBNull.Value ? 0 : Convert.ToInt64(dr[Project_Activities_DT.EnumInfo_Activities.funding_res_source.ToString()]);
        return oInfo_Activities;
    }

    private static SqlParameter[] GetParameters(Project_Activities_DT obj, bool isSearch)
    {
        SqlParameter[] parms = new SqlParameter[22];



        parms[0] = new SqlParameter(Project_Activities_DT.EnumInfo_Activities.PActv_wieght.ToString(), obj.PActv_wieght);

        parms[1] = new SqlParameter(Project_Activities_DT.EnumInfo_Activities.PActv_Progress.ToString(), obj.PActv_Progress);

        parms[2] = new SqlParameter(Project_Activities_DT.EnumInfo_Activities.PActv_Period.ToString(), obj.PActv_Period);

        parms[3] = new SqlParameter(Project_Activities_DT.EnumInfo_Activities.PActv_Actual_Period.ToString(), obj.PActv_Actual_Period);
        if (!isSearch)
        {

            parms[4] = new SqlParameter(Project_Activities_DT.EnumInfo_Activities.PActv_ID.ToString(), obj.PActv_ID);
            parms[4].Direction = ParameterDirection.InputOutput;

        }

        parms[5] = new SqlParameter(Project_Activities_DT.EnumInfo_Activities.PActv_Parent.ToString(), obj.PActv_Parent);

        parms[6] = new SqlParameter(Project_Activities_DT.EnumInfo_Activities.PActv_is_Milestone.ToString(), obj.PActv_is_Milestone);

        parms[7] = new SqlParameter(Project_Activities_DT.EnumInfo_Activities.proj_proj_id.ToString(), obj.proj_proj_id);

        parms[8] = new SqlParameter(Project_Activities_DT.EnumInfo_Activities.ActStat_ActStat_id.ToString(), obj.ActStat_ActStat_id);

        parms[9] = new SqlParameter(Project_Activities_DT.EnumInfo_Activities.Excutive_responsible_Org_Org_id.ToString(), obj.Excutive_responsible_Org_Org_id);

        parms[10] = new SqlParameter(Project_Activities_DT.EnumInfo_Activities.PActv_Desc.ToString(), obj.PActv_Desc);

        parms[11] = new SqlParameter(Project_Activities_DT.EnumInfo_Activities.PActv_Start_Date.ToString(), obj.PActv_Start_Date);

        parms[12] = new SqlParameter(Project_Activities_DT.EnumInfo_Activities.PActv_End_Date.ToString(), obj.PActv_End_Date);

        parms[13] = new SqlParameter(Project_Activities_DT.EnumInfo_Activities.PActv_Actual_Start_Date.ToString(), obj.PActv_Actual_Start_Date);

        parms[14] = new SqlParameter(Project_Activities_DT.EnumInfo_Activities.PActv_Actual_End_Date.ToString(), obj.PActv_Actual_End_Date);

        parms[15] = new SqlParameter(Project_Activities_DT.EnumInfo_Activities.PActv_Implementing_person.ToString(), obj.PActv_Implementing_person);

        parms[16] = new SqlParameter(Project_Activities_DT.EnumInfo_Activities.Notes.ToString(), obj.Notes);

        parms[17] = new SqlParameter(Project_Activities_DT.EnumInfo_Activities.summery.ToString(), obj.summery);

        parms[18] = new SqlParameter(Project_Activities_DT.EnumInfo_Activities.priorities.ToString(), obj.priorities);

        parms[19] = new SqlParameter(Project_Activities_DT.EnumInfo_Activities.funding_res_id.ToString(), obj.funding_res_id);

        parms[20] = new SqlParameter(Project_Activities_DT.EnumInfo_Activities.funding_amount.ToString(), obj.funding_amount);

        parms[21] = new SqlParameter(Project_Activities_DT.EnumInfo_Activities.funding_res_source.ToString(), obj.funding_res_source);
        return parms;
    }

    #endregion

    #region DataBase Function

    public static int Save(Project_Activities_DT obj)
    {
        try
        {
            SqlParameter[] parms = GetParameters(obj, false);

            SqlHelper.ExecuteScalar(Database.ConnectionString, CommandType.StoredProcedure, "Project_Activities_Save", parms);
            return Convert.ToInt32(parms[4].Value);
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
            SqlHelper.ExecuteNonQuery(Database.ConnectionString, "Project_Activities_Delete", ID);
            return ID;
        }
        catch (Exception ex)
        {
            return -1;
        }
    }

    public static DataTable SelectAll()
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Project_Activities_Select", 0).Tables[0];

    }

    public static Project_Activities_DT SelectByID(int ID)
    {
        try
        {
            SqlDataReader drTableName;
            Project_Activities_DT obj = new Project_Activities_DT();
            if (ID > 0)
            {


                drTableName = SqlHelper.ExecuteReader(Database.ConnectionString, "Project_Activities_Select", ID);
                if (drTableName != null)
                {
                    while (drTableName.Read())
                    {
                        obj = FillInfoObject(drTableName);
                    }

                    drTableName.Close();
                }
            }
            return obj;
        }
        catch (Exception ex)
        {

            return null;
        }

    }


    public static long Increase_Recurcive(long PActv_ID)
    {
        try
        {

            SqlHelper.ExecuteNonQuery(Database.ConnectionString, "Project_Activities_Increse_Recursive", PActv_ID);
            return PActv_ID;
        }
        catch (SqlException ex)
        {

            return -1;
        }
    }

    public static long Increase_Recurcive_Activites(long PActv_ID)
    {
        try
        {

            SqlHelper.ExecuteNonQuery(Database.ConnectionString, "Project_Activities_Increse_Recursive_Activities", PActv_ID);
            return PActv_ID;
        }
        catch (SqlException ex)
        {

            return -1;
        }
    }
    #endregion


}
