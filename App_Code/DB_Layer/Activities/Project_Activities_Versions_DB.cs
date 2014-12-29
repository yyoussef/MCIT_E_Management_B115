using System;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for Project_Activities_Versions_DB
/// </summary>
public static class Project_Activities_Versions_DB
{
    #region "Private methods"

    private static Project_Activities_Versions_DT FillInfoObject(SqlDataReader dr)
    {

        Project_Activities_Versions_DT oInfo_Activities = new Project_Activities_Versions_DT();


        oInfo_Activities.PActv_wieght = dr[Project_Activities_Versions_DT.EnumInfo_Activities_Versions_DT.PActv_wieght.ToString()] == DBNull.Value ? 0 : Convert.ToDecimal(dr[Project_Activities_Versions_DT.EnumInfo_Activities_Versions_DT.PActv_wieght.ToString()]);
        oInfo_Activities.PActv_Progress = dr[Project_Activities_Versions_DT.EnumInfo_Activities_Versions_DT.PActv_Progress.ToString()] == DBNull.Value ? 0 : Convert.ToDecimal(dr[Project_Activities_Versions_DT.EnumInfo_Activities_Versions_DT.PActv_Progress.ToString()]);
        oInfo_Activities.PActv_Period = dr[Project_Activities_Versions_DT.EnumInfo_Activities_Versions_DT.PActv_Period.ToString()] == DBNull.Value ? 0 : Convert.ToDecimal(dr[Project_Activities_Versions_DT.EnumInfo_Activities_Versions_DT.PActv_Period.ToString()]);
        oInfo_Activities.PActv_Actual_Period = dr[Project_Activities_Versions_DT.EnumInfo_Activities_Versions_DT.PActv_Actual_Period.ToString()] == DBNull.Value ? 0 : Convert.ToDecimal(dr[Project_Activities_Versions_DT.EnumInfo_Activities_Versions_DT.PActv_Actual_Period.ToString()]);
        oInfo_Activities.PActv_ID = Convert.ToInt64(dr[Project_Activities_Versions_DT.EnumInfo_Activities_Versions_DT.PActv_ID.ToString()]);
        oInfo_Activities.PActv_Parent = dr[Project_Activities_Versions_DT.EnumInfo_Activities_Versions_DT.PActv_Parent.ToString()] == DBNull.Value ? 0 : Convert.ToInt64(dr[Project_Activities_Versions_DT.EnumInfo_Activities_Versions_DT.PActv_Parent.ToString()]);
        oInfo_Activities.PActv_is_Milestone = dr[Project_Activities_Versions_DT.EnumInfo_Activities_Versions_DT.PActv_is_Milestone.ToString()] == DBNull.Value ? 0 : Convert.ToInt64(dr[Project_Activities_Versions_DT.EnumInfo_Activities_Versions_DT.PActv_is_Milestone.ToString()]);
        oInfo_Activities.proj_proj_id = dr[Project_Activities_Versions_DT.EnumInfo_Activities_Versions_DT.proj_proj_id.ToString()] == DBNull.Value ? 0 : Convert.ToInt64(dr[Project_Activities_Versions_DT.EnumInfo_Activities_Versions_DT.proj_proj_id.ToString()]);
        oInfo_Activities.ActStat_ActStat_id = dr[Project_Activities_Versions_DT.EnumInfo_Activities_Versions_DT.ActStat_ActStat_id.ToString()] == DBNull.Value ? 0 : Convert.ToInt64(dr[Project_Activities_Versions_DT.EnumInfo_Activities_Versions_DT.ActStat_ActStat_id.ToString()]);
        oInfo_Activities.Excutive_responsible_Org_Org_id = dr[Project_Activities_Versions_DT.EnumInfo_Activities_Versions_DT.Excutive_responsible_Org_Org_id.ToString()] == DBNull.Value ? 0 : Convert.ToInt64(dr[Project_Activities_Versions_DT.EnumInfo_Activities_Versions_DT.Excutive_responsible_Org_Org_id.ToString()]);
        oInfo_Activities.PActv_Desc = dr[Project_Activities_Versions_DT.EnumInfo_Activities_Versions_DT.PActv_Desc.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Project_Activities_Versions_DT.EnumInfo_Activities_Versions_DT.PActv_Desc.ToString()]);
        oInfo_Activities.PActv_Start_Date = dr[Project_Activities_Versions_DT.EnumInfo_Activities_Versions_DT.PActv_Start_Date.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Project_Activities_Versions_DT.EnumInfo_Activities_Versions_DT.PActv_Start_Date.ToString()]);
        oInfo_Activities.PActv_End_Date = dr[Project_Activities_Versions_DT.EnumInfo_Activities_Versions_DT.PActv_End_Date.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Project_Activities_Versions_DT.EnumInfo_Activities_Versions_DT.PActv_End_Date.ToString()]);
        oInfo_Activities.PActv_Actual_Start_Date = dr[Project_Activities_Versions_DT.EnumInfo_Activities_Versions_DT.PActv_Actual_Start_Date.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Project_Activities_Versions_DT.EnumInfo_Activities_Versions_DT.PActv_Actual_Start_Date.ToString()]);
        oInfo_Activities.PActv_Actual_End_Date = dr[Project_Activities_Versions_DT.EnumInfo_Activities_Versions_DT.PActv_Actual_End_Date.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Project_Activities_Versions_DT.EnumInfo_Activities_Versions_DT.PActv_Actual_End_Date.ToString()]);
        oInfo_Activities.PActv_Implementing_person = dr[Project_Activities_Versions_DT.EnumInfo_Activities_Versions_DT.PActv_Implementing_person.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Project_Activities_Versions_DT.EnumInfo_Activities_Versions_DT.PActv_Implementing_person.ToString()]);
        oInfo_Activities.Notes = dr[Project_Activities_Versions_DT.EnumInfo_Activities_Versions_DT.Notes.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Project_Activities_Versions_DT.EnumInfo_Activities_Versions_DT.Notes.ToString()]);

        oInfo_Activities.Actv_month = dr[Project_Activities_Versions_DT.EnumInfo_Activities_Versions_DT.Actv_month.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Project_Activities_Versions_DT.EnumInfo_Activities_Versions_DT.Actv_month.ToString()]);
        oInfo_Activities.Actv_year = dr[Project_Activities_Versions_DT.EnumInfo_Activities_Versions_DT.Actv_year.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Project_Activities_Versions_DT.EnumInfo_Activities_Versions_DT.Actv_year.ToString()]);

        oInfo_Activities.summery = dr[Project_Activities_Versions_DT.EnumInfo_Activities_Versions_DT.summery.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Project_Activities_Versions_DT.EnumInfo_Activities_Versions_DT.summery.ToString()]);
        oInfo_Activities.priorities = dr[Project_Activities_Versions_DT.EnumInfo_Activities_Versions_DT.priorities.ToString()] == DBNull.Value ? 0 : Convert.ToInt64(dr[Project_Activities_Versions_DT.EnumInfo_Activities_Versions_DT.priorities.ToString()]);
        oInfo_Activities.funding_res_id = dr[Project_Activities_Versions_DT.EnumInfo_Activities_Versions_DT.funding_res_id.ToString()] == DBNull.Value ? 0 : Convert.ToInt64(dr[Project_Activities_Versions_DT.EnumInfo_Activities_Versions_DT.funding_res_id.ToString()]);
        oInfo_Activities.funding_amount = dr[Project_Activities_Versions_DT.EnumInfo_Activities_Versions_DT.funding_amount.ToString()] == DBNull.Value ? 0 : Convert.ToInt64(dr[Project_Activities_Versions_DT.EnumInfo_Activities_Versions_DT.funding_amount.ToString()]);
        oInfo_Activities.funding_res_source = dr[Project_Activities_Versions_DT.EnumInfo_Activities_Versions_DT.funding_res_source.ToString()] == DBNull.Value ? 0 : Convert.ToInt64(dr[Project_Activities_Versions_DT.EnumInfo_Activities_Versions_DT.funding_res_source.ToString()]);
        return oInfo_Activities;
    }

    private static SqlParameter[] GetParameters(Project_Activities_Versions_DT obj, bool isSearch)
    {
        SqlParameter[] parms = new SqlParameter[24];



        parms[0] = new SqlParameter(Project_Activities_Versions_DT.EnumInfo_Activities_Versions_DT.PActv_wieght.ToString(), obj.PActv_wieght);

        parms[1] = new SqlParameter(Project_Activities_Versions_DT.EnumInfo_Activities_Versions_DT.PActv_Progress.ToString(), obj.PActv_Progress);

        parms[2] = new SqlParameter(Project_Activities_Versions_DT.EnumInfo_Activities_Versions_DT.PActv_Period.ToString(), obj.PActv_Period);

        parms[3] = new SqlParameter(Project_Activities_Versions_DT.EnumInfo_Activities_Versions_DT.PActv_Actual_Period.ToString(), obj.PActv_Actual_Period);
        if (!isSearch)
        {

            parms[4] = new SqlParameter(Project_Activities_Versions_DT.EnumInfo_Activities_Versions_DT.PActv_ID.ToString(), obj.PActv_ID);
            parms[4].Direction = ParameterDirection.InputOutput;

        }

        parms[5] = new SqlParameter(Project_Activities_Versions_DT.EnumInfo_Activities_Versions_DT.PActv_Parent.ToString(), obj.PActv_Parent);

        parms[6] = new SqlParameter(Project_Activities_Versions_DT.EnumInfo_Activities_Versions_DT.PActv_is_Milestone.ToString(), obj.PActv_is_Milestone);

        parms[7] = new SqlParameter(Project_Activities_Versions_DT.EnumInfo_Activities_Versions_DT.proj_proj_id.ToString(), obj.proj_proj_id);

        parms[8] = new SqlParameter(Project_Activities_Versions_DT.EnumInfo_Activities_Versions_DT.ActStat_ActStat_id.ToString(), obj.ActStat_ActStat_id);

        parms[9] = new SqlParameter(Project_Activities_Versions_DT.EnumInfo_Activities_Versions_DT.Excutive_responsible_Org_Org_id.ToString(), obj.Excutive_responsible_Org_Org_id);

        parms[10] = new SqlParameter(Project_Activities_Versions_DT.EnumInfo_Activities_Versions_DT.PActv_Desc.ToString(), obj.PActv_Desc);

        parms[11] = new SqlParameter(Project_Activities_Versions_DT.EnumInfo_Activities_Versions_DT.PActv_Start_Date.ToString(), obj.PActv_Start_Date);

        parms[12] = new SqlParameter(Project_Activities_Versions_DT.EnumInfo_Activities_Versions_DT.PActv_End_Date.ToString(), obj.PActv_End_Date);

        parms[13] = new SqlParameter(Project_Activities_Versions_DT.EnumInfo_Activities_Versions_DT.PActv_Actual_Start_Date.ToString(), obj.PActv_Actual_Start_Date);

        parms[14] = new SqlParameter(Project_Activities_Versions_DT.EnumInfo_Activities_Versions_DT.PActv_Actual_End_Date.ToString(), obj.PActv_Actual_End_Date);

        parms[15] = new SqlParameter(Project_Activities_Versions_DT.EnumInfo_Activities_Versions_DT.PActv_Implementing_person.ToString(), obj.PActv_Implementing_person);

        parms[16] = new SqlParameter(Project_Activities_Versions_DT.EnumInfo_Activities_Versions_DT.Notes.ToString(), obj.Notes);

        parms[17] = new SqlParameter(Project_Activities_Versions_DT.EnumInfo_Activities_Versions_DT.summery.ToString(), obj.summery);

        parms[18] = new SqlParameter(Project_Activities_Versions_DT.EnumInfo_Activities_Versions_DT.priorities.ToString(), obj.priorities);

        parms[19] = new SqlParameter(Project_Activities_Versions_DT.EnumInfo_Activities_Versions_DT.funding_res_id.ToString(), obj.funding_res_id);

        parms[20] = new SqlParameter(Project_Activities_Versions_DT.EnumInfo_Activities_Versions_DT.funding_amount.ToString(), obj.funding_amount);

        parms[21] = new SqlParameter(Project_Activities_Versions_DT.EnumInfo_Activities_Versions_DT.funding_res_source.ToString(), obj.funding_res_source);

        parms[22] = new SqlParameter(Project_Activities_Versions_DT.EnumInfo_Activities_Versions_DT.Actv_month.ToString(), obj.Actv_month);

        parms[23] = new SqlParameter(Project_Activities_Versions_DT.EnumInfo_Activities_Versions_DT.Actv_year.ToString(), obj.Actv_year);

        return parms;
    }

    #endregion

    #region DataBase Function


    public static int Save(Project_Activities_DT obj_Main, string Actv_month, string Actv_year)
    {


        Project_Activities_Versions_DT obj_Versions = new Project_Activities_Versions_DT();

        obj_Versions.PActv_wieght = obj_Main.PActv_wieght;
        obj_Versions.PActv_Progress = obj_Main.PActv_Progress;
        obj_Versions.PActv_Period = obj_Main.PActv_Period;
        obj_Versions.PActv_Actual_Period = obj_Main.PActv_Actual_Period;
        obj_Versions.PActv_ID = obj_Main.PActv_ID;
        obj_Versions.PActv_Parent = obj_Main.PActv_Parent;
        obj_Versions.PActv_is_Milestone = obj_Main.PActv_is_Milestone;
        obj_Versions.proj_proj_id = obj_Main.proj_proj_id;
        obj_Versions.ActStat_ActStat_id = obj_Main.ActStat_ActStat_id;
        obj_Versions.Excutive_responsible_Org_Org_id = obj_Main.Excutive_responsible_Org_Org_id;
        obj_Versions.PActv_Desc = obj_Main.PActv_Desc;
        obj_Versions.PActv_Start_Date = obj_Main.PActv_Start_Date;
        obj_Versions.PActv_End_Date = obj_Main.PActv_End_Date;
        obj_Versions.PActv_Actual_Start_Date = obj_Main.PActv_Actual_Start_Date;
        obj_Versions.PActv_Actual_End_Date = obj_Main.PActv_Actual_End_Date;
        obj_Versions.PActv_Implementing_person = obj_Main.PActv_Implementing_person;
        obj_Versions.Notes = obj_Main.Notes;

        obj_Versions.Actv_month = Actv_month;
        obj_Versions.Actv_year = Actv_year;

        obj_Versions.summery = obj_Main.summery;
        obj_Versions.priorities = obj_Main.priorities;
        obj_Versions.funding_res_id = obj_Main.funding_res_id;
        obj_Versions.funding_amount = obj_Main.funding_amount;
        obj_Versions.funding_res_source = obj_Main.funding_res_source; 


        try
        {
            SqlParameter[] parms = GetParameters(obj_Versions, false);

            SqlHelper.ExecuteScalar(Database.ConnectionString, CommandType.StoredProcedure, "Project_Activities_Versions_Save", parms);
            return CDataConverter.ConvertToInt( obj_Main.PActv_ID);
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
            SqlHelper.ExecuteNonQuery(Database.ConnectionString, "Project_Activities_Versions_Delete", ID);
            return ID;
        }
        catch (Exception ex)
        {
            return -1;
        }
    }

    public static DataTable SelectAll()
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Project_Activities_Versions_Select", 0).Tables[0];

    }

    public static Project_Activities_Versions_DT SelectByID(int PActv_ID, string Actv_month, string Actv_year)
    {
        try
        {
            SqlDataReader drTableName;
            Project_Activities_Versions_DT obj = new Project_Activities_Versions_DT();
            if (PActv_ID > 0)
            {
                drTableName = SqlHelper.ExecuteReader(Database.ConnectionString, "Project_Activities_Versions_Select", PActv_ID);
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

            SqlHelper.ExecuteNonQuery(Database.ConnectionString, "Project_Activities_Versions_Increse_Recursive", PActv_ID);
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

            SqlHelper.ExecuteNonQuery(Database.ConnectionString, "Project_Activities_Versions_Increse_Recursive_Activities", PActv_ID);
            return PActv_ID;
        }
        catch (SqlException ex)
        {

            return -1;
        }
    }
    #endregion
}
