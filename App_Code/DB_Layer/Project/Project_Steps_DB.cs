using System;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for Project_Steps_DB
/// </summary>
public class Project_Steps_DB
{
    #region "Private methods"

    private static Project_Steps_DT FillInfoObject(SqlDataReader dr)
    {

        Project_Steps_DT oProject_Steps_DT = new Project_Steps_DT();


        oProject_Steps_DT.Project_Steps_ID = Convert.ToInt32(dr[Project_Steps_DT.EnumInfo_Steps.Project_Steps_ID.ToString()]);
        oProject_Steps_DT.Proj_id = dr[Project_Steps_DT.EnumInfo_Steps.Proj_id.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Project_Steps_DT.EnumInfo_Steps.Proj_id.ToString()]);
        oProject_Steps_DT.Type = dr[Project_Steps_DT.EnumInfo_Steps.Type.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Project_Steps_DT.EnumInfo_Steps.Type.ToString()]);
        oProject_Steps_DT.Statge_Name = dr[Project_Steps_DT.EnumInfo_Steps.Statge_Name.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Project_Steps_DT.EnumInfo_Steps.Statge_Name.ToString()]);
        oProject_Steps_DT.Statge_Out_Put = dr[Project_Steps_DT.EnumInfo_Steps.Statge_Out_Put.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Project_Steps_DT.EnumInfo_Steps.Statge_Out_Put.ToString()]);

        return oProject_Steps_DT;
    }

    private static SqlParameter[] GetParameters(Project_Steps_DT obj, bool isSearch)
    {
        SqlParameter[] parms = new SqlParameter[5];


        if (!isSearch)
        {

            parms[0] = new SqlParameter(Project_Steps_DT.EnumInfo_Steps.Project_Steps_ID.ToString(), obj.Project_Steps_ID);
            parms[0].Direction = ParameterDirection.InputOutput;

        }

        parms[1] = new SqlParameter(Project_Steps_DT.EnumInfo_Steps.Proj_id.ToString(), obj.Proj_id);

        parms[2] = new SqlParameter(Project_Steps_DT.EnumInfo_Steps.Type.ToString(), obj.Type);

        parms[3] = new SqlParameter(Project_Steps_DT.EnumInfo_Steps.Statge_Name.ToString(), obj.Statge_Name);

        parms[4] = new SqlParameter(Project_Steps_DT.EnumInfo_Steps.Statge_Out_Put.ToString(), obj.Statge_Out_Put);

        return parms;
    }

    #endregion

    #region DataBase Function

    public static int Save(Project_Steps_DT obj)
    {
        try
        {
            SqlParameter[] parms = GetParameters(obj, false);

            SqlHelper.ExecuteScalar(Database.ConnectionString, CommandType.StoredProcedure, "Project_Steps_Save", parms);
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
            SqlHelper.ExecuteNonQuery(Database.ConnectionString, "Project_Steps_Delete", ID);
            return ID;
        }
        catch (Exception ex)
        {
            return -1;
        }
    }

    public static DataTable SelectAll(int proj_proj_id)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Project_Steps_Select", proj_proj_id).Tables[0];

    }

    public static Project_Steps_DT SelectByID(int ID)
    {
        try
        {
            SqlDataReader drTableName;
            Project_Steps_DT obj = new Project_Steps_DT();
            if (ID > 0)
            {
                drTableName = SqlHelper.ExecuteReader(Database.ConnectionString, "Project_Steps_Select", ID);
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
