using System;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for Protocol_Projects_DB
/// </summary>
public static class Protocol_Projects_DB
{
    #region "Private methods"

    private static Protocol_Projects_DT FillInfoObject(SqlDataReader dr)
    {

        Protocol_Projects_DT oProtocol_Projects_DT = new Protocol_Projects_DT();


        oProtocol_Projects_DT.ID = Convert.ToInt32(dr[Protocol_Projects_DT.EnumInfo_Projects.ID.ToString()]);
        oProtocol_Projects_DT.Protocol_ID = dr[Protocol_Projects_DT.EnumInfo_Projects.Protocol_ID.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Protocol_Projects_DT.EnumInfo_Projects.Protocol_ID.ToString()]);
        oProtocol_Projects_DT.Project_ID = dr[Protocol_Projects_DT.EnumInfo_Projects.Project_ID.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Protocol_Projects_DT.EnumInfo_Projects.Project_ID.ToString()]);

        return oProtocol_Projects_DT;
    }

    private static SqlParameter[] GetParameters(Protocol_Projects_DT obj, bool isSearch)
    {
        SqlParameter[] parms = new SqlParameter[3];


        if (!isSearch)
        {

            parms[0] = new SqlParameter(Protocol_Projects_DT.EnumInfo_Projects.ID.ToString(), obj.ID);
            parms[0].Direction = ParameterDirection.InputOutput;

        }

        parms[1] = new SqlParameter(Protocol_Projects_DT.EnumInfo_Projects.Protocol_ID.ToString(), obj.Protocol_ID);

        parms[2] = new SqlParameter(Protocol_Projects_DT.EnumInfo_Projects.Project_ID.ToString(), obj.Project_ID);

        return parms;
    }

    #endregion

    #region DataBase Function

    public static int Save(Protocol_Projects_DT obj)
    {
        try
        {
            SqlParameter[] parms = GetParameters(obj, false);

            SqlHelper.ExecuteScalar(Database.ConnectionString, CommandType.StoredProcedure, "Protocol_Projects_Save", parms);
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
            SqlHelper.ExecuteNonQuery(Database.ConnectionString, "Protocol_Projects_Delete", ID);
            return ID;
        }
        catch (Exception ex)
        {
            return -1;
        }
    }

    public static DataTable SelectAll(int Protocol_id)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Protocol_Projects_Select",0, Protocol_id).Tables[0];

    }

    public static Protocol_Projects_DT SelectByID(int ID)
    {
        try
        {
            SqlDataReader drTableName;
            Protocol_Projects_DT obj = new Protocol_Projects_DT();
            if (ID > 0)
            {
                drTableName = SqlHelper.ExecuteReader(Database.ConnectionString, "Protocol_Projects_Select", ID, 0);
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
