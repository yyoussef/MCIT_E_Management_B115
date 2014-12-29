using System;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for Project_Objective_DB
/// </summary>
public class Project_Objective_DB
{
    #region "Private methods"

    private static Project_Objective_DT FillInfoObject(SqlDataReader dr)
    {

        Project_Objective_DT oProject_Objective_DT = new Project_Objective_DT();


        oProject_Objective_DT.Project_Object_ID = Convert.ToInt32(dr[Project_Objective_DT.EnumInfo_Objective.Project_Object_ID.ToString()]);
        oProject_Objective_DT.Proj_id = dr[Project_Objective_DT.EnumInfo_Objective.Proj_id.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Project_Objective_DT.EnumInfo_Objective.Proj_id.ToString()]);
        oProject_Objective_DT.Type = dr[Project_Objective_DT.EnumInfo_Objective.Type.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Project_Objective_DT.EnumInfo_Objective.Type.ToString()]);
        oProject_Objective_DT.Description = dr[Project_Objective_DT.EnumInfo_Objective.Description.ToString()] == DBNull.Value ? null : Convert.ToString(dr[Project_Objective_DT.EnumInfo_Objective.Description.ToString()]);

        return oProject_Objective_DT;
    }

    private static SqlParameter[] GetParameters(Project_Objective_DT obj, bool isSearch)
    {
        SqlParameter[] parms = new SqlParameter[4];


        if (!isSearch)
        {

            parms[0] = new SqlParameter(Project_Objective_DT.EnumInfo_Objective.Project_Object_ID.ToString(), obj.Project_Object_ID);
            parms[0].Direction = ParameterDirection.InputOutput;

        }

        parms[1] = new SqlParameter(Project_Objective_DT.EnumInfo_Objective.Proj_id.ToString(), obj.Proj_id);

        parms[2] = new SqlParameter(Project_Objective_DT.EnumInfo_Objective.Type.ToString(), obj.Type);

        parms[3] = new SqlParameter(Project_Objective_DT.EnumInfo_Objective.Description.ToString(), obj.Description);

        return parms;
    }

    #endregion

    #region DataBase Function

    public static int Save(Project_Objective_DT obj)
    {
        try
        {
            SqlParameter[] parms = GetParameters(obj, false);

            SqlHelper.ExecuteScalar(Database.ConnectionString, CommandType.StoredProcedure, "Project_Objective_Save", parms);
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
            SqlHelper.ExecuteNonQuery(Database.ConnectionString, "Project_Objective_Delete", ID);
            return ID;
        }
        catch (Exception ex)
        {
            return -1;
        }
    }

    public static DataTable SelectAll(int proj_proj_id)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Project_Objective_Select", proj_proj_id).Tables[0];

    }

    public static Project_Objective_DT SelectByID(int ID)
    {
        try
        {
            SqlDataReader drTableName;
            Project_Objective_DT obj = new Project_Objective_DT();
            if (ID > 0)
            {
                drTableName = SqlHelper.ExecuteReader(Database.ConnectionString, "Project_Objective_Select", ID);
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
