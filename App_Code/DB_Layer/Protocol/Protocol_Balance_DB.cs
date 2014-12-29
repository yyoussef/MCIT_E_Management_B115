using System;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for Protocol_Projects_DB
/// </summary>
public static class Protocol_Periods_Balance_DB
{
    #region "Private methods"

    private static Protocol_Periods_Balance_DT FillInfoObject(SqlDataReader dr)
    {

        Protocol_Periods_Balance_DT oProtocol_balance_DT = new Protocol_Periods_Balance_DT();

    
        oProtocol_balance_DT.Protocol_Balance_ID = Convert.ToInt64(dr[Protocol_Periods_Balance_DT.EnumInfo_period_balance.Protocol_Balance_ID.ToString()]);
        oProtocol_balance_DT.From_DT = dr[Protocol_Periods_Balance_DT.EnumInfo_period_balance.From_DT.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Protocol_Periods_Balance_DT.EnumInfo_period_balance.From_DT.ToString()]);
        oProtocol_balance_DT.To_DT = dr[Protocol_Periods_Balance_DT.EnumInfo_period_balance.To_DT.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Protocol_Periods_Balance_DT.EnumInfo_period_balance.To_DT.ToString()]);
        oProtocol_balance_DT.Amount_US = dr[Protocol_Periods_Balance_DT.EnumInfo_period_balance.Amount_US.ToString()] == DBNull.Value ? 0 : Convert.ToInt64(dr[Protocol_Periods_Balance_DT.EnumInfo_period_balance.Amount_US.ToString()]);
        oProtocol_balance_DT.Amount_LE = dr[Protocol_Periods_Balance_DT.EnumInfo_period_balance.Amount_LE.ToString()] == DBNull.Value ? 0 : Convert.ToInt64(dr[Protocol_Periods_Balance_DT.EnumInfo_period_balance.Amount_LE.ToString()]);
        oProtocol_balance_DT.Protocol_ID = Convert.ToInt32(dr[Protocol_Periods_Balance_DT.EnumInfo_period_balance.Protocol_ID.ToString()]);
        return oProtocol_balance_DT;
    }

    private static SqlParameter[] GetParameters(Protocol_Periods_Balance_DT obj, bool isSearch)
    {
        SqlParameter[] parms = new SqlParameter[6];


        if (!isSearch)
        {

            parms[0] = new SqlParameter(Protocol_Periods_Balance_DT.EnumInfo_period_balance.Protocol_Balance_ID.ToString(), obj.Protocol_Balance_ID);
            parms[0].Direction = ParameterDirection.InputOutput;

        }

        parms[1] = new SqlParameter(Protocol_Periods_Balance_DT.EnumInfo_period_balance.From_DT.ToString(), obj.From_DT);

        parms[2] = new SqlParameter(Protocol_Periods_Balance_DT.EnumInfo_period_balance.To_DT.ToString(), obj.To_DT);

        parms[3] = new SqlParameter(Protocol_Periods_Balance_DT.EnumInfo_period_balance.Amount_US.ToString(), obj.Amount_US);

        parms[4] = new SqlParameter(Protocol_Periods_Balance_DT.EnumInfo_period_balance.Amount_LE.ToString(), obj.Amount_LE);

        parms[5] = new SqlParameter(Protocol_Periods_Balance_DT.EnumInfo_period_balance.Protocol_ID.ToString(), obj.Protocol_ID);

        return parms;
    }

    #endregion

    #region DataBase Function

    public static int Save(Protocol_Periods_Balance_DT obj)
    {
        try
        {
            SqlParameter[] parms = GetParameters(obj, false);

            SqlHelper.ExecuteScalar(Database.ConnectionString, CommandType.StoredProcedure, "Protocol_Balance_Save", parms);
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
            SqlHelper.ExecuteNonQuery(Database.ConnectionString, "Protocol_Balance_Delete", ID);
            return ID;
        }
        catch (Exception ex)
        {
            return -1;
        }
    }

    public static DataTable SelectAll(int prot_ID)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Protocol_Balance_Select", 0, prot_ID).Tables[0];

    }

    public static Protocol_Periods_Balance_DT SelectByID(int ID)
    {
        try
        {
            SqlDataReader drTableName;
            Protocol_Periods_Balance_DT obj = new Protocol_Periods_Balance_DT();
            if (ID > 0)
            {
                drTableName = SqlHelper.ExecuteReader(Database.ConnectionString, "Protocol_Balance_Select", ID, 0);
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
