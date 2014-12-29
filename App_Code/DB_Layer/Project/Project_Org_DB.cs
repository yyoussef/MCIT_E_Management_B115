using System;
using System.Data.SqlClient;
using System.Data;
/// <summary>
/// Summary description for Project_Org_DB
/// </summary>
public class Project_Org_DB
{
    #region "Private methods"

    private static Project_Org_DT FillInfoObject(SqlDataReader dr)
    {

        Project_Org_DT oProject_Org_DT = new Project_Org_DT();


        oProject_Org_DT.Project_Org_ID = Convert.ToInt32(dr[Project_Org_DT.EnumInfo_Org.Project_Org_ID.ToString()]);
        oProject_Org_DT.Proj_id = dr[Project_Org_DT.EnumInfo_Org.Proj_id.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Project_Org_DT.EnumInfo_Org.Proj_id.ToString()]);
        oProject_Org_DT.Org_Type = dr[Project_Org_DT.EnumInfo_Org.Org_Type.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Project_Org_DT.EnumInfo_Org.Org_Type.ToString()]);
        oProject_Org_DT.Org_ID = dr[Project_Org_DT.EnumInfo_Org.Org_ID.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Project_Org_DT.EnumInfo_Org.Org_ID.ToString()]);

        return oProject_Org_DT;
    }

    private static SqlParameter[] GetParameters(Project_Org_DT obj, bool isSearch)
    {
        SqlParameter[] parms = new SqlParameter[4];


        if (!isSearch)
        {

            parms[0] = new SqlParameter(Project_Org_DT.EnumInfo_Org.Project_Org_ID.ToString(), obj.Project_Org_ID);
            parms[0].Direction = ParameterDirection.InputOutput;

        }

        parms[1] = new SqlParameter(Project_Org_DT.EnumInfo_Org.Proj_id.ToString(), obj.Proj_id);

        parms[2] = new SqlParameter(Project_Org_DT.EnumInfo_Org.Org_Type.ToString(), obj.Org_Type);

        parms[3] = new SqlParameter(Project_Org_DT.EnumInfo_Org.Org_ID.ToString(), obj.Org_ID);

        return parms;
    }

    #endregion
    #region DataBase Function

    public static int Save(Project_Org_DT obj)
    {
        try
        {
            SqlParameter[] parms = GetParameters(obj, false);

            SqlHelper.ExecuteScalar(Database.ConnectionString, CommandType.StoredProcedure, "Project_Org_Save", parms);
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
            SqlHelper.ExecuteNonQuery(Database.ConnectionString, "Project_Org_Delete", ID);
            return ID;
        }
        catch (Exception ex)
        {
            return -1;
        }
    }

    public static DataTable SelectAll(int proj_proj_id)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Project_Org_Select", proj_proj_id).Tables[0];

    }

    public static Project_Org_DT SelectByID(int ID)
    {
        try
        {
            SqlDataReader drTableName;
            Project_Org_DT obj = new Project_Org_DT();
            if (ID > 0)
            {
                drTableName = SqlHelper.ExecuteReader(Database.ConnectionString, "Project_Org_Select", ID);
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
