using System;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for Protocol_Main_Def_DB
/// </summary>
public class Protocol_Main_Def_DB
{
    #region "Private methods"

    private static Protocol_Main_Def_DT FillInfoObject(SqlDataReader dr)
    {

        Protocol_Main_Def_DT oInfo_Main_Def = new Protocol_Main_Def_DT();


        oInfo_Main_Def.Protocol_ID = Convert.ToInt32(dr[Protocol_Main_Def_DT.EnumInfo_Main_Def.Protocol_ID.ToString()]);
        oInfo_Main_Def.Type = dr[Protocol_Main_Def_DT.EnumInfo_Main_Def.Type.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Protocol_Main_Def_DT.EnumInfo_Main_Def.Type.ToString()]);
        oInfo_Main_Def.PMP_ID = dr[Protocol_Main_Def_DT.EnumInfo_Main_Def.PMP_ID.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Protocol_Main_Def_DT.EnumInfo_Main_Def.PMP_ID.ToString()]);
        oInfo_Main_Def.Period_Year = dr[Protocol_Main_Def_DT.EnumInfo_Main_Def.Period_Year.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Protocol_Main_Def_DT.EnumInfo_Main_Def.Period_Year.ToString()]);
        oInfo_Main_Def.Period_Month = dr[Protocol_Main_Def_DT.EnumInfo_Main_Def.Period_Month.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Protocol_Main_Def_DT.EnumInfo_Main_Def.Period_Month.ToString()]);
        oInfo_Main_Def.Period_Day = dr[Protocol_Main_Def_DT.EnumInfo_Main_Def.Period_Day.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Protocol_Main_Def_DT.EnumInfo_Main_Def.Period_Day.ToString()]);
        oInfo_Main_Def.Status = dr[Protocol_Main_Def_DT.EnumInfo_Main_Def.Status.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Protocol_Main_Def_DT.EnumInfo_Main_Def.Status.ToString()]);
        oInfo_Main_Def.Related_ID = dr[Protocol_Main_Def_DT.EnumInfo_Main_Def.Related_ID.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Protocol_Main_Def_DT.EnumInfo_Main_Def.Related_ID.ToString()]);
        oInfo_Main_Def.Total_Balance_LE = dr[Protocol_Main_Def_DT.EnumInfo_Main_Def.Total_Balance_LE.ToString()] == DBNull.Value ? 0 : Convert.ToInt64(dr[Protocol_Main_Def_DT.EnumInfo_Main_Def.Total_Balance_LE.ToString()]);
        oInfo_Main_Def.Total_Balance_US = dr[Protocol_Main_Def_DT.EnumInfo_Main_Def.Total_Balance_US.ToString()] == DBNull.Value ? 0 : Convert.ToInt64(dr[Protocol_Main_Def_DT.EnumInfo_Main_Def.Total_Balance_US.ToString()]);
        oInfo_Main_Def.Name = dr[Protocol_Main_Def_DT.EnumInfo_Main_Def.Name.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Protocol_Main_Def_DT.EnumInfo_Main_Def.Name.ToString()]);
        oInfo_Main_Def.Signt_DT = dr[Protocol_Main_Def_DT.EnumInfo_Main_Def.Signt_DT.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Protocol_Main_Def_DT.EnumInfo_Main_Def.Signt_DT.ToString()]);
        oInfo_Main_Def.Strt_DT = dr[Protocol_Main_Def_DT.EnumInfo_Main_Def.Strt_DT.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Protocol_Main_Def_DT.EnumInfo_Main_Def.Strt_DT.ToString()]);
        oInfo_Main_Def.End_DT = dr[Protocol_Main_Def_DT.EnumInfo_Main_Def.End_DT.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Protocol_Main_Def_DT.EnumInfo_Main_Def.End_DT.ToString()]);
        oInfo_Main_Def.Related_Type = dr[Protocol_Main_Def_DT.EnumInfo_Main_Def.Related_Type.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Protocol_Main_Def_DT.EnumInfo_Main_Def.Related_Type.ToString()]);
        oInfo_Main_Def.Related_Protocol_ID = dr[Protocol_Main_Def_DT.EnumInfo_Main_Def.Related_Protocol_ID.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Protocol_Main_Def_DT.EnumInfo_Main_Def.Related_Protocol_ID.ToString()]);

        return oInfo_Main_Def;
    }

    private static SqlParameter[] GetParameters(Protocol_Main_Def_DT obj, bool isSearch)
    {
        SqlParameter[] parms = new SqlParameter[16];


        if (!isSearch)
        {

            parms[0] = new SqlParameter(Protocol_Main_Def_DT.EnumInfo_Main_Def.Protocol_ID.ToString(), obj.Protocol_ID);
            parms[0].Direction = ParameterDirection.InputOutput;

        }

        parms[1] = new SqlParameter(Protocol_Main_Def_DT.EnumInfo_Main_Def.Type.ToString(), obj.Type);

        parms[2] = new SqlParameter(Protocol_Main_Def_DT.EnumInfo_Main_Def.PMP_ID.ToString(), obj.PMP_ID);

        parms[3] = new SqlParameter(Protocol_Main_Def_DT.EnumInfo_Main_Def.Period_Year.ToString(), obj.Period_Year);

        parms[4] = new SqlParameter(Protocol_Main_Def_DT.EnumInfo_Main_Def.Period_Month.ToString(), obj.Period_Month);

        parms[5] = new SqlParameter(Protocol_Main_Def_DT.EnumInfo_Main_Def.Period_Day.ToString(), obj.Period_Day);

        parms[6] = new SqlParameter(Protocol_Main_Def_DT.EnumInfo_Main_Def.Status.ToString(), obj.Status);

        parms[7] = new SqlParameter(Protocol_Main_Def_DT.EnumInfo_Main_Def.Total_Balance_LE.ToString(), obj.Total_Balance_LE);

        parms[8] = new SqlParameter(Protocol_Main_Def_DT.EnumInfo_Main_Def.Total_Balance_US.ToString(), obj.Total_Balance_US);

        parms[9] = new SqlParameter(Protocol_Main_Def_DT.EnumInfo_Main_Def.Name.ToString(), obj.Name);

        parms[10] = new SqlParameter(Protocol_Main_Def_DT.EnumInfo_Main_Def.Signt_DT.ToString(), obj.Signt_DT);

        parms[11] = new SqlParameter(Protocol_Main_Def_DT.EnumInfo_Main_Def.Strt_DT.ToString(), obj.Strt_DT);

        parms[12] = new SqlParameter(Protocol_Main_Def_DT.EnumInfo_Main_Def.End_DT.ToString(), obj.End_DT);

        parms[13] = new SqlParameter(Protocol_Main_Def_DT.EnumInfo_Main_Def.Related_ID.ToString(), obj.Related_ID);

        parms[14] = new SqlParameter(Protocol_Main_Def_DT.EnumInfo_Main_Def.Related_Type.ToString(), obj.Related_Type);

        parms[15] = new SqlParameter(Protocol_Main_Def_DT.EnumInfo_Main_Def.Related_Protocol_ID.ToString(), obj.Related_Protocol_ID);

        return parms;
    }

    #endregion

    #region DataBase Function

    public static int Save(Protocol_Main_Def_DT obj)
    {
        try
        {
            SqlParameter[] parms = GetParameters(obj, false);

            SqlHelper.ExecuteScalar(Database.ConnectionString, CommandType.StoredProcedure, "Protocol_Main_Def_Save", parms);
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
            SqlHelper.ExecuteNonQuery(Database.ConnectionString, "Protocol_Main_Def_Delete", ID);
            return ID;
        }
        catch (Exception ex)
        {
            return -1;
        }
    }

    public static DataTable SelectAll(int proj_proj_id)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Protocol_Main_Def_Select", proj_proj_id).Tables[0];

    }

    public static Protocol_Main_Def_DT SelectByID(int ID)
    {
        try
        {
            SqlDataReader drTableName;
            Protocol_Main_Def_DT obj = new Protocol_Main_Def_DT();
            if (ID > 0)
            {
                drTableName = SqlHelper.ExecuteReader(Database.ConnectionString, "Protocol_Main_Def_Select", ID);
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

    public static bool SelectBy_Name(string Name, int ID)
    {
        string Sql = "Select * from Protocol_Main_Def where Name='"+Name+"' and Protocol_ID <> '"+ID+"'";
        DataTable DT = SqlHelper.ExecuteDataset(Database.ConnectionString, CommandType.Text, Sql).Tables[0];
        if (DT.Rows.Count > 0)
            return true;
        else
            return false;
    }


    public static DataTable Select_Protocole_Data(string Name, int PMP_ID, int rol_rol_id, int Dept_Dept_id, string  Strt_DT,string End_DT)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "protocol_search", Name, PMP_ID, rol_rol_id, Dept_Dept_id,Strt_DT,End_DT ).Tables[0];

    }

}
