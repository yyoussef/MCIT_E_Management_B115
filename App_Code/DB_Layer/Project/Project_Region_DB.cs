using System;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for Project_Region_DB
/// </summary>
public class Project_Region_DB
{
    #region "Private methods"

    private static Project_Region_DT FillInfoObject(SqlDataReader dr)
    {

        Project_Region_DT oProject_Region_DT = new Project_Region_DT();


        oProject_Region_DT.Project_Region_ID = Convert.ToInt32(dr[Project_Region_DT.EnumInfo_Region.Project_Region_ID.ToString()]);
        oProject_Region_DT.Proj_id = dr[Project_Region_DT.EnumInfo_Region.Proj_id.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Project_Region_DT.EnumInfo_Region.Proj_id.ToString()]);
        oProject_Region_DT.Region_ID = dr[Project_Region_DT.EnumInfo_Region.Region_ID.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Project_Region_DT.EnumInfo_Region.Region_ID.ToString()]);

        return oProject_Region_DT;
    }

    private static SqlParameter[] GetParameters(Project_Region_DT obj, bool isSearch)
    {
        SqlParameter[] parms = new SqlParameter[3];


        if (!isSearch)
        {

            parms[0] = new SqlParameter(Project_Region_DT.EnumInfo_Region.Project_Region_ID.ToString(), obj.Project_Region_ID);
            parms[0].Direction = ParameterDirection.InputOutput;

        }

        parms[1] = new SqlParameter(Project_Region_DT.EnumInfo_Region.Proj_id.ToString(), obj.Proj_id);

        parms[2] = new SqlParameter(Project_Region_DT.EnumInfo_Region.Region_ID.ToString(), obj.Region_ID);

        return parms;
    }

    #endregion

    #region DataBase Function

    public static int Save(Project_Region_DT obj)
    {
        try
        {
            SqlParameter[] parms = GetParameters(obj, false);

            SqlHelper.ExecuteScalar(Database.ConnectionString, CommandType.StoredProcedure, "Project_Region_Save", parms);
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
            SqlHelper.ExecuteNonQuery(Database.ConnectionString, "Project_Region_Delete", ID);
            return ID;
        }
        catch (Exception ex)
        {
            return -1;
        }
    }

    public static DataTable SelectAll(int proj_proj_id)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Project_Region_Select", proj_proj_id).Tables[0];

    }

    public static Project_Region_DT SelectByID(int ID)
    {
        try
        {
            SqlDataReader drTableName;
            Project_Region_DT obj = new Project_Region_DT();
            if (ID > 0)
            {
                drTableName = SqlHelper.ExecuteReader(Database.ConnectionString, "Project_Region_Select", ID);
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

    public static void Delete_ALL_By_Project_ID(int ID)
    {
        SqlHelper.ExecuteNonQuery(Database.ConnectionString, "Project_Region_Delete_by_Proj_id", ID);
    }
}
