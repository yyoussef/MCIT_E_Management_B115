using System;
using System.Data.SqlClient;
using System.Data;


/// <summary>
/// Summary description for Vacations_DB
/// </summary>
public  class DatabaseFunctions
{

    public static DataTable SelectDataByParam(SqlParameter[] sqlParameters, string stored_name)
    {
        try
        {
            return SqlHelper.ExecuteDataset(Database.ConnectionString, stored_name, sqlParameters).Tables[0];
        }
        catch (SqlException ex)
        {
            DataTable dt = new DataTable();
            return dt;
        }
    }

    public static DataTable SelectData(string SQL)
    {
        try
        {
            return SqlHelper.ExecuteDataset(Database.ConnectionString, CommandType.Text, SQL).Tables[0];
        }
        catch (SqlException ex)
        {
            DataTable dt = new DataTable();
            return dt;
        }
    }

    public static DataTable SelectDataWithoutParams( string stored_name)
    {
        try
        {
            return SqlHelper.ExecuteDataset(Database.ConnectionString, stored_name).Tables[0];
        }
        catch (SqlException ex)
        {
            DataTable dt = new DataTable();
            return dt;
        }
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
