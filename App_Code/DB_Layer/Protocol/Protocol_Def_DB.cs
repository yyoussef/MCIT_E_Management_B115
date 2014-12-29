using System;
using System.Data.SqlClient;
using System.Data;


/// <summary>
/// Summary description for Protocols_Def_DB
/// </summary>
public static class Protocol_Def_DB
{
    #region "Private methods"

    private static Protocol_Def_DT FillInfoObject(SqlDataReader dr)
    {

        Protocol_Def_DT oProtocol_Def_DT = new Protocol_Def_DT();


        oProtocol_Def_DT.Protocol_ID = Convert.ToInt32(dr[Protocol_Def_DT.EnumInfo_Def.Protocol_ID.ToString()]);
        oProtocol_Def_DT.PMP_ID = dr[Protocol_Def_DT.EnumInfo_Def.PMP_ID.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Protocol_Def_DT.EnumInfo_Def.PMP_ID.ToString()]);
        oProtocol_Def_DT.Org_ID = dr[Protocol_Def_DT.EnumInfo_Def.Org_ID.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Protocol_Def_DT.EnumInfo_Def.Org_ID.ToString()]);
        oProtocol_Def_DT.Type = dr[Protocol_Def_DT.EnumInfo_Def.Type.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Protocol_Def_DT.EnumInfo_Def.Type.ToString()]);
        oProtocol_Def_DT.Status = dr[Protocol_Def_DT.EnumInfo_Def.Status.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Protocol_Def_DT.EnumInfo_Def.Status.ToString()]);
        oProtocol_Def_DT.Total_Balance_LE = dr[Protocol_Def_DT.EnumInfo_Def.Total_Balance_LE.ToString()] == DBNull.Value ? 0 : Convert.ToInt64(dr[Protocol_Def_DT.EnumInfo_Def.Total_Balance_LE.ToString()]);
        oProtocol_Def_DT.Total_Balance_US = dr[Protocol_Def_DT.EnumInfo_Def.Total_Balance_US.ToString()] == DBNull.Value ? 0 : Convert.ToInt64(dr[Protocol_Def_DT.EnumInfo_Def.Total_Balance_US.ToString()]);
        oProtocol_Def_DT.Name = dr[Protocol_Def_DT.EnumInfo_Def.Name.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Protocol_Def_DT.EnumInfo_Def.Name.ToString()]);
        oProtocol_Def_DT.Signt_Str_DT = dr[Protocol_Def_DT.EnumInfo_Def.Signt_Str_DT.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Protocol_Def_DT.EnumInfo_Def.Signt_Str_DT.ToString()]);
        oProtocol_Def_DT.Signt_End_DT = dr[Protocol_Def_DT.EnumInfo_Def.Signt_End_DT.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Protocol_Def_DT.EnumInfo_Def.Signt_End_DT.ToString()]);
        oProtocol_Def_DT.Documentary_DT = dr[Protocol_Def_DT.EnumInfo_Def.Documentary_DT.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Protocol_Def_DT.EnumInfo_Def.Documentary_DT.ToString()]);
        oProtocol_Def_DT.Concern_authority = dr[Protocol_Def_DT.EnumInfo_Def.Concern_authority.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Protocol_Def_DT.EnumInfo_Def.Concern_authority.ToString()]);
        oProtocol_Def_DT.approval_NM = dr[Protocol_Def_DT.EnumInfo_Def.approval_NM.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Protocol_Def_DT.EnumInfo_Def.approval_NM.ToString()]);
        oProtocol_Def_DT.approval_DT = dr[Protocol_Def_DT.EnumInfo_Def.approval_DT.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Protocol_Def_DT.EnumInfo_Def.approval_DT.ToString()]);
        oProtocol_Def_DT.Job_Org = dr[Protocol_Def_DT.EnumInfo_Def.Job_Org.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Protocol_Def_DT.EnumInfo_Def.Job_Org.ToString()]);
        oProtocol_Def_DT.Job_Authority = dr[Protocol_Def_DT.EnumInfo_Def.Job_Authority.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Protocol_Def_DT.EnumInfo_Def.Job_Authority.ToString()]);
        oProtocol_Def_DT.Sign_Org = dr[Protocol_Def_DT.EnumInfo_Def.Sign_Org.ToString()] == DBNull.Value ? false : Convert.ToBoolean(dr[Protocol_Def_DT.EnumInfo_Def.Sign_Org.ToString()]);
        oProtocol_Def_DT.Sign_Authority = dr[Protocol_Def_DT.EnumInfo_Def.Sign_Authority.ToString()] == DBNull.Value ? false : Convert.ToBoolean(dr[Protocol_Def_DT.EnumInfo_Def.Sign_Authority.ToString()]);

        return oProtocol_Def_DT;
    }

    private static SqlParameter[] GetParameters(Protocol_Def_DT obj, bool isSearch)
    {
        SqlParameter[] parms = new SqlParameter[18];


        if (!isSearch)
        {

            parms[0] = new SqlParameter(Protocol_Def_DT.EnumInfo_Def.Protocol_ID.ToString(), obj.Protocol_ID);
            parms[0].Direction = ParameterDirection.InputOutput;

        }

        parms[1] = new SqlParameter(Protocol_Def_DT.EnumInfo_Def.PMP_ID.ToString(), obj.PMP_ID);

        parms[2] = new SqlParameter(Protocol_Def_DT.EnumInfo_Def.Org_ID.ToString(), obj.Org_ID);

        parms[3] = new SqlParameter(Protocol_Def_DT.EnumInfo_Def.Type.ToString(), obj.Type);

        parms[4] = new SqlParameter(Protocol_Def_DT.EnumInfo_Def.Status.ToString(), obj.Status);

        parms[5] = new SqlParameter(Protocol_Def_DT.EnumInfo_Def.Total_Balance_LE.ToString(), obj.Total_Balance_LE);

        parms[6] = new SqlParameter(Protocol_Def_DT.EnumInfo_Def.Total_Balance_US.ToString(), obj.Total_Balance_US);

        parms[7] = new SqlParameter(Protocol_Def_DT.EnumInfo_Def.Name.ToString(), obj.Name);

        parms[8] = new SqlParameter(Protocol_Def_DT.EnumInfo_Def.Signt_Str_DT.ToString(), obj.Signt_Str_DT);

        parms[9] = new SqlParameter(Protocol_Def_DT.EnumInfo_Def.Signt_End_DT.ToString(), obj.Signt_End_DT);

        parms[10] = new SqlParameter(Protocol_Def_DT.EnumInfo_Def.Documentary_DT.ToString(), obj.Documentary_DT);

        parms[11] = new SqlParameter(Protocol_Def_DT.EnumInfo_Def.Concern_authority.ToString(), obj.Concern_authority);

        parms[12] = new SqlParameter(Protocol_Def_DT.EnumInfo_Def.approval_NM.ToString(), obj.approval_NM);

        parms[13] = new SqlParameter(Protocol_Def_DT.EnumInfo_Def.approval_DT.ToString(), obj.approval_DT);

        parms[14] = new SqlParameter(Protocol_Def_DT.EnumInfo_Def.Sign_Org.ToString(), obj.Sign_Org);

        parms[15] = new SqlParameter(Protocol_Def_DT.EnumInfo_Def.Sign_Authority.ToString(), obj.Sign_Authority);

        parms[16] = new SqlParameter(Protocol_Def_DT.EnumInfo_Def.Job_Authority.ToString(), obj.Job_Authority);

        parms[17] = new SqlParameter(Protocol_Def_DT.EnumInfo_Def.Job_Org.ToString(), obj.Job_Org);

        

        return parms;
    }

    #endregion

    #region DataBase Function

    public static int Save(Protocol_Def_DT obj)
    {
        try
        {
            SqlParameter[] parms = GetParameters(obj, false);

            SqlHelper.ExecuteScalar(Database.ConnectionString, CommandType.StoredProcedure, "Protocol_Def_Save", parms);
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
            SqlHelper.ExecuteNonQuery(Database.ConnectionString, "Protocol_Def_Delete", ID);
            return ID;
        }
        catch (Exception ex)
        {
            return -1;
        }
    }

    public static DataTable SelectAll()
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Protocol_Def_Select", 0).Tables[0];

    }

    public static Protocol_Def_DT SelectByID(int ID)
    {
        try
        {
            SqlDataReader drTableName;
            Protocol_Def_DT obj = new Protocol_Def_DT();
            if (ID > 0)
            {
                drTableName = SqlHelper.ExecuteReader(Database.ConnectionString, "Protocol_Def_Select", ID);
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
