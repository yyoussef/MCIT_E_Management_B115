using System;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for Protocol_Main_Org_DB
/// </summary>
public class Protocol_Main_Org_DB
{
    #region "Private methods"

    private static Protocol_Main_Org_DT FillInfoObject(SqlDataReader dr)
    {

        Protocol_Main_Org_DT oInfo_Main_Org = new Protocol_Main_Org_DT();


        oInfo_Main_Org.Protocol_Org_ID = Convert.ToInt32(dr[Protocol_Main_Org_DT.EnumInfo_Main_Org.Protocol_Org_ID.ToString()]);
        oInfo_Main_Org.Protocol_ID = dr[Protocol_Main_Org_DT.EnumInfo_Main_Org.Protocol_ID.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Protocol_Main_Org_DT.EnumInfo_Main_Org.Protocol_ID.ToString()]);
        oInfo_Main_Org.Org_Type = dr[Protocol_Main_Org_DT.EnumInfo_Main_Org.Org_Type.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Protocol_Main_Org_DT.EnumInfo_Main_Org.Org_Type.ToString()]);
        oInfo_Main_Org.Org_ID = dr[Protocol_Main_Org_DT.EnumInfo_Main_Org.Org_ID.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Protocol_Main_Org_DT.EnumInfo_Main_Org.Org_ID.ToString()]);
        oInfo_Main_Org.Total_Balance_LE = dr[Protocol_Main_Org_DT.EnumInfo_Main_Org.Total_Balance_LE.ToString()] == DBNull.Value ? 0 : Convert.ToInt64(dr[Protocol_Main_Org_DT.EnumInfo_Main_Org.Total_Balance_LE.ToString()]);
        oInfo_Main_Org.Total_Balance_US = dr[Protocol_Main_Org_DT.EnumInfo_Main_Org.Total_Balance_US.ToString()] == DBNull.Value ? 0 : Convert.ToInt64(dr[Protocol_Main_Org_DT.EnumInfo_Main_Org.Total_Balance_US.ToString()]);
        oInfo_Main_Org.Org_Responsibilities = dr[Protocol_Main_Org_DT.EnumInfo_Main_Org.Org_Responsibilities.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Protocol_Main_Org_DT.EnumInfo_Main_Org.Org_Responsibilities.ToString()]);

        
        return oInfo_Main_Org;
    }

    private static SqlParameter[] GetParameters(Protocol_Main_Org_DT obj, bool isSearch)
    {
        SqlParameter[] parms = new SqlParameter[7];


        if (!isSearch)
        {

            parms[0] = new SqlParameter(Protocol_Main_Org_DT.EnumInfo_Main_Org.Protocol_Org_ID.ToString(), obj.Protocol_Org_ID);
            parms[0].Direction = ParameterDirection.InputOutput;

        }

        parms[1] = new SqlParameter(Protocol_Main_Org_DT.EnumInfo_Main_Org.Protocol_ID.ToString(), obj.Protocol_ID);

        parms[2] = new SqlParameter(Protocol_Main_Org_DT.EnumInfo_Main_Org.Org_Type.ToString(), obj.Org_Type);

        parms[3] = new SqlParameter(Protocol_Main_Org_DT.EnumInfo_Main_Org.Org_ID.ToString(), obj.Org_ID);

        parms[4] = new SqlParameter(Protocol_Main_Org_DT.EnumInfo_Main_Org.Total_Balance_LE.ToString(), obj.Total_Balance_LE);

        parms[5] = new SqlParameter(Protocol_Main_Org_DT.EnumInfo_Main_Org.Total_Balance_US.ToString(), obj.Total_Balance_US);

        parms[6] = new SqlParameter(Protocol_Main_Org_DT.EnumInfo_Main_Org.Org_Responsibilities.ToString(), obj.Org_Responsibilities);

        return parms;
    }

    #endregion

    #region DataBase Function

    public static int Save(Protocol_Main_Org_DT obj)
    {
        try
        {
            SqlParameter[] parms = GetParameters(obj, false);

            SqlHelper.ExecuteScalar(Database.ConnectionString, CommandType.StoredProcedure, "Protocol_Main_Org_Save", parms);
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
            SqlHelper.ExecuteNonQuery(Database.ConnectionString, "Protocol_Main_Org_Delete", ID);
            return ID;
        }
        catch (Exception ex)
        {
            return -1;
        }
    }

    public static DataTable SelectAll(int proj_proj_id)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Protocol_Main_Org_Select", proj_proj_id).Tables[0];

    }

    public static Protocol_Main_Org_DT SelectByID(int ID)
    {
        try
        {
            SqlDataReader drTableName;
            Protocol_Main_Org_DT obj = new Protocol_Main_Org_DT();
            if (ID > 0)
            {
                drTableName = SqlHelper.ExecuteReader(Database.ConnectionString, "Protocol_Main_Org_Select", ID);
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

    public static object SelectAll_by_protocol_Id(int Protocol_ID,int Type_ID)
    {
        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Protocol_Main_Org_Select_by_Protocol_ID", Protocol_ID, Type_ID).Tables[0];
    }
}
