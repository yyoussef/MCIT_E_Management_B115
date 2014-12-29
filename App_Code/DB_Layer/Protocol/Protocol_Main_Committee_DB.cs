using System;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for Protocol_Projects_DB
/// </summary>
public static class Protocol_Main_Committee_DB
{
    #region "Private methods"

    private static Protocol_Main_Committee_DT FillInfoObject(SqlDataReader dr)
    {

        Protocol_Main_Committee_DT oProtocol_Main_Committee_DT = new Protocol_Main_Committee_DT();

    
        oProtocol_Main_Committee_DT.ID = Convert.ToInt64(dr[Protocol_Main_Committee_DT.EnumInfo_period_balance.ID.ToString()]);
        oProtocol_Main_Committee_DT.Person_Name = dr[Protocol_Main_Committee_DT.EnumInfo_period_balance.Person_Name.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Protocol_Main_Committee_DT.EnumInfo_period_balance.Person_Name.ToString()]);
        oProtocol_Main_Committee_DT.Person_Job = dr[Protocol_Main_Committee_DT.EnumInfo_period_balance.Person_Job.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Protocol_Main_Committee_DT.EnumInfo_period_balance.Person_Job.ToString()]);
        oProtocol_Main_Committee_DT.Org_id = dr[Protocol_Main_Committee_DT.EnumInfo_period_balance.Org_id.ToString()] == DBNull.Value ? 0 : Convert.ToInt64(dr[Protocol_Main_Committee_DT.EnumInfo_period_balance.Org_id.ToString()]);
        oProtocol_Main_Committee_DT.Dept_id = dr[Protocol_Main_Committee_DT.EnumInfo_period_balance.Dept_id.ToString()] == DBNull.Value ? 0 : Convert.ToInt64(dr[Protocol_Main_Committee_DT.EnumInfo_period_balance.Dept_id.ToString()]);
        oProtocol_Main_Committee_DT.Org_Type = dr[Protocol_Main_Committee_DT.EnumInfo_period_balance.Org_Type.ToString()] == DBNull.Value ? 0 : Convert.ToInt64(dr[Protocol_Main_Committee_DT.EnumInfo_period_balance.Org_Type.ToString()]);
        oProtocol_Main_Committee_DT.Notes = dr[Protocol_Main_Committee_DT.EnumInfo_period_balance.Notes.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Protocol_Main_Committee_DT.EnumInfo_period_balance.Notes.ToString()]);
        oProtocol_Main_Committee_DT.Protocol_ID = Convert.ToInt32(dr[Protocol_Main_Committee_DT.EnumInfo_period_balance.Protocol_ID.ToString()]);
        return oProtocol_Main_Committee_DT;
    }

    private static SqlParameter[] GetParameters(Protocol_Main_Committee_DT obj, bool isSearch)
    {
        SqlParameter[] parms = new SqlParameter[8];


        if (!isSearch)
        {

            parms[0] = new SqlParameter(Protocol_Main_Committee_DT.EnumInfo_period_balance.ID.ToString(), obj.ID);
            parms[0].Direction = ParameterDirection.InputOutput;

        }

        parms[1] = new SqlParameter(Protocol_Main_Committee_DT.EnumInfo_period_balance.Person_Name.ToString(), obj.Person_Name);

        parms[2] = new SqlParameter(Protocol_Main_Committee_DT.EnumInfo_period_balance.Person_Job.ToString(), obj.Person_Job);

        parms[3] = new SqlParameter(Protocol_Main_Committee_DT.EnumInfo_period_balance.Org_id.ToString(), obj.Org_id);

        parms[4] = new SqlParameter(Protocol_Main_Committee_DT.EnumInfo_period_balance.Org_Type.ToString(), obj.Org_Type);

        parms[5] = new SqlParameter(Protocol_Main_Committee_DT.EnumInfo_period_balance.Notes.ToString(), obj.Notes);

        parms[6] = new SqlParameter(Protocol_Main_Committee_DT.EnumInfo_period_balance.Protocol_ID.ToString(), obj.Protocol_ID);

        parms[7] = new SqlParameter(Protocol_Main_Committee_DT.EnumInfo_period_balance.Dept_id.ToString(), obj.Dept_id);

        return parms;
    }

    #endregion

    #region DataBase Function

    public static int Save(Protocol_Main_Committee_DT obj)
    {
        try
        {
            SqlParameter[] parms = GetParameters(obj, false);

            SqlHelper.ExecuteScalar(Database.ConnectionString, CommandType.StoredProcedure, "Protocol_Main_Committee_Save", parms);
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
            SqlHelper.ExecuteNonQuery(Database.ConnectionString, "Protocol_Main_Committee_Delete", ID);
            return ID;
        }
        catch (Exception ex)
        {
            return -1;
        }
    }

    public static DataTable SelectAll(int prot_ID)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Protocol_Main_Committee_Select", 0, prot_ID).Tables[0];

    }

    public static Protocol_Main_Committee_DT SelectByID(int ID)
    {
        try
        {
            SqlDataReader drTableName;
            Protocol_Main_Committee_DT obj = new Protocol_Main_Committee_DT();
            if (ID > 0)
            {
                drTableName = SqlHelper.ExecuteReader(Database.ConnectionString, "Protocol_Main_Committee_Select", ID);
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
