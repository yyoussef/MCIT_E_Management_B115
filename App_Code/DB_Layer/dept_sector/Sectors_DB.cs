//////////////////////////////////////////////////////////////////////////////////////////
// Generated By:	MCIT\wmibrahim using Mcit Generator
// Class Name:		Sectors_DB
// Date Generated:	04-03-2012
//////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Data.SqlClient;
using System.Data;


public static class Sectors_DB
{

    #region "Private methods"

    private static Sectors_DT FillInfoObject(SqlDataReader dr)
    {

        Sectors_DT obj_Sectors_DT = new Sectors_DT();


        obj_Sectors_DT.Sec_id = Convert.ToInt64(dr[Sectors_DT.Enum_Sectors_DT.Sec_id.ToString()]);
        obj_Sectors_DT.Sec_name = dr[Sectors_DT.Enum_Sectors_DT.Sec_name.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Sectors_DT.Enum_Sectors_DT.Sec_name.ToString()]);
        obj_Sectors_DT.foundation_id = dr[Sectors_DT.Enum_Sectors_DT.foundation_id.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Sectors_DT.Enum_Sectors_DT.foundation_id.ToString()]);

        return obj_Sectors_DT;
    }

    private static SqlParameter[] GetParameters(Sectors_DT obj)
    {
        SqlParameter[] parms = new SqlParameter[3];




        parms[0] = new SqlParameter(Sectors_DT.Enum_Sectors_DT.Sec_id.ToString(), obj.Sec_id);
        parms[0].Direction = ParameterDirection.InputOutput;

        parms[1] = new SqlParameter(Sectors_DT.Enum_Sectors_DT.Sec_name.ToString(), obj.Sec_name);
        parms[2] = new SqlParameter(Sectors_DT.Enum_Sectors_DT.foundation_id.ToString(), obj.foundation_id);

        return parms;
    }

    #endregion

    #region "DB methods"

    public static long Save(Sectors_DT obj)
    {
        try
        {
            SqlParameter[] parms = GetParameters(obj);

            SqlHelper.ExecuteScalar(Database.ConnectionString, CommandType.StoredProcedure, "Sectors_Save", parms);

            obj.Sec_id = Convert.ToInt32(parms[0].Value);

            return obj.Sec_id;
        }
        catch (Exception ex)
        {

            return -1;
        }
    }

    public static int Delete(int Sectors_ID)
    {
        try
        {
            SqlHelper.ExecuteNonQuery(Database.ConnectionString, "Sectors_Delete", Sectors_ID);
            return Sectors_ID;
        }
        catch (Exception ex)
        {

            return -1;
        }
    }

    public static DataTable SelectAll(int sec_id, int foundation_id)
    {
        try
        {
            return SqlHelper.ExecuteDataset(Database.ConnectionString, "Sectors_Select", sec_id, foundation_id).Tables[0];

        }
        catch (Exception ex)
        {

            return null;
        }
    }

    public static Sectors_DT SelectByID(int Sectors_ID,int Foundation_id)
    {
        try
        {
            if (Sectors_ID > 0)
            {
                SqlDataReader drTableName;
                Sectors_DT oInfo_Sectors_DT = new Sectors_DT();

                drTableName = SqlHelper.ExecuteReader(Database.ConnectionString, "Sectors_Select", Sectors_ID, Foundation_id);
                if (drTableName != null)
                {
                    while (drTableName.Read())
                    {
                        oInfo_Sectors_DT = FillInfoObject(drTableName);
                    }

                    drTableName.Close();
                }
                return oInfo_Sectors_DT;
            }
            else
                return new Sectors_DT();
        }
        catch (Exception ex)
        {

            return null;
        }
    }
    #endregion


}

