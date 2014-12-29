using System;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for Project_Objective_DB
/// </summary>
public class Project_Assumptions_DB
{
    #region "Private methods"

    private static Project_Assumptions_DT FillInfoObject(SqlDataReader dr)
    {

        Project_Assumptions_DT oProject_Assumptions_DT = new Project_Assumptions_DT();


        oProject_Assumptions_DT.Psc_dl_asump_id = Convert.ToInt32(dr[Project_Assumptions_DT.EnumInfo_Objective.Psc_dl_asump_id.ToString()]);
        oProject_Assumptions_DT.proj_proj_id = dr[Project_Assumptions_DT.EnumInfo_Objective.proj_proj_id.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Project_Assumptions_DT.EnumInfo_Objective.proj_proj_id.ToString()]);
        oProject_Assumptions_DT.Type = dr[Project_Assumptions_DT.EnumInfo_Objective.Type.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Project_Assumptions_DT.EnumInfo_Objective.Type.ToString()]);
        oProject_Assumptions_DT.Psc_dl_asump_Desc = dr[Project_Assumptions_DT.EnumInfo_Objective.Psc_dl_asump_Desc.ToString()] == DBNull.Value ? null : Convert.ToString(dr[Project_Assumptions_DT.EnumInfo_Objective.Psc_dl_asump_Desc.ToString()]);

        return oProject_Assumptions_DT;
    }

    private static SqlParameter[] GetParameters(Project_Assumptions_DT obj, bool isSearch)
    {
        SqlParameter[] parms = new SqlParameter[4];


        if (!isSearch)
        {

            parms[0] = new SqlParameter(Project_Assumptions_DT.EnumInfo_Objective.Psc_dl_asump_id.ToString(), obj.Psc_dl_asump_id);
            parms[0].Direction = ParameterDirection.InputOutput;

        }

        parms[1] = new SqlParameter(Project_Assumptions_DT.EnumInfo_Objective.proj_proj_id.ToString(), obj.proj_proj_id);

        parms[2] = new SqlParameter(Project_Assumptions_DT.EnumInfo_Objective.Type.ToString(), obj.Type);

        parms[3] = new SqlParameter(Project_Assumptions_DT.EnumInfo_Objective.Psc_dl_asump_Desc.ToString(), obj.Psc_dl_asump_Desc);

        return parms;
    }

    #endregion

    #region DataBase Function

    public static int Save(Project_Assumptions_DT obj)
    {
        try
        {
            SqlParameter[] parms = GetParameters(obj, false);

            SqlHelper.ExecuteScalar(Database.ConnectionString, CommandType.StoredProcedure, "Psc_dl_asump_Save", parms);
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
            SqlHelper.ExecuteNonQuery(Database.ConnectionString, "Psc_dl_asump_Delete", ID);
            return ID;
        }
        catch (Exception ex)
        {
            return -1;
        }
    }

    public static DataTable SelectAll(int proj_proj_id)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Psc_dl_asump_Select", proj_proj_id).Tables[0];

    }

    public static Project_Assumptions_DT SelectByID(int ID)
    {
        try
        {
            SqlDataReader drTableName;
            Project_Assumptions_DT obj = new Project_Assumptions_DT();
            if (ID > 0)
            {
                drTableName = SqlHelper.ExecuteReader(Database.ConnectionString, "Psc_dl_asump_Select", ID);
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

    #endregion
}
