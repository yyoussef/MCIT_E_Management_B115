using System;
using System.Data.SqlClient;
using System.Data;


/// <summary>
/// Summary description for Vacations_DB
/// </summary>
public static class NeedsNoApproving
{
    
    public static DataTable SelectData(SqlParameter[] sqlParameters,string stored_name)
    {
        return SqlHelper.ExecuteDataset(Database.ConnectionString, stored_name, sqlParameters).Tables[0];
    }

    public static int UpdateData(SqlParameter[] sqlParameters, string stored_name)
    {
        try
        {
            SqlHelper.ExecuteScalar(Database.ConnectionString, CommandType.StoredProcedure, stored_name, sqlParameters);
            return 1;
        }
        catch (SqlException ex)
        {

            return -1;
        }
    }

    
}
