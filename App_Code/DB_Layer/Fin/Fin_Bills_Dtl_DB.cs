using System;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for Fin_Bills_Dtl_DB
/// </summary>
public static class Fin_Bills_Dtl_DB
{
    #region "Private methods"

    private static Fin_Bills_Dtl_DT FillInfoObject(SqlDataReader dr)
    {

        Fin_Bills_Dtl_DT oInfo_Bills_Dtl = new Fin_Bills_Dtl_DT();


        oInfo_Bills_Dtl.Bil_Dtl_ID = Convert.ToInt32(dr[Fin_Bills_Dtl_DT.EnumInfo_Bills_Dtl.Bil_Dtl_ID.ToString()]);
        oInfo_Bills_Dtl.Bil_ID = dr[Fin_Bills_Dtl_DT.EnumInfo_Bills_Dtl.Bil_ID.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Fin_Bills_Dtl_DT.EnumInfo_Bills_Dtl.Bil_ID.ToString()]);
        oInfo_Bills_Dtl.PActv_ID = dr[Fin_Bills_Dtl_DT.EnumInfo_Bills_Dtl.PActv_ID.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Fin_Bills_Dtl_DT.EnumInfo_Bills_Dtl.PActv_ID.ToString()]);
        oInfo_Bills_Dtl.Quantity = dr[Fin_Bills_Dtl_DT.EnumInfo_Bills_Dtl.Quantity.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Fin_Bills_Dtl_DT.EnumInfo_Bills_Dtl.Quantity.ToString()]);
        oInfo_Bills_Dtl.unit_value = dr[Fin_Bills_Dtl_DT.EnumInfo_Bills_Dtl.unit_value.ToString()] == DBNull.Value ? 0 : Convert.ToDecimal(dr[Fin_Bills_Dtl_DT.EnumInfo_Bills_Dtl.unit_value.ToString()]);
        oInfo_Bills_Dtl.Total_Value = dr[Fin_Bills_Dtl_DT.EnumInfo_Bills_Dtl.Total_Value.ToString()] == DBNull.Value ? 0 : Convert.ToDecimal(dr[Fin_Bills_Dtl_DT.EnumInfo_Bills_Dtl.Total_Value.ToString()]);
        oInfo_Bills_Dtl.Notes = dr[Fin_Bills_Dtl_DT.EnumInfo_Bills_Dtl.Notes.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Fin_Bills_Dtl_DT.EnumInfo_Bills_Dtl.Notes.ToString()]);

        return oInfo_Bills_Dtl;
    }

    private static SqlParameter[] GetParameters(Fin_Bills_Dtl_DT obj, bool isSearch)
    {
        SqlParameter[] parms = new SqlParameter[7];


        if (!isSearch)
        {

            parms[0] = new SqlParameter(Fin_Bills_Dtl_DT.EnumInfo_Bills_Dtl.Bil_Dtl_ID.ToString(), obj.Bil_Dtl_ID);
            parms[0].Direction = ParameterDirection.InputOutput;

        }

        parms[1] = new SqlParameter(Fin_Bills_Dtl_DT.EnumInfo_Bills_Dtl.Bil_ID.ToString(), obj.Bil_ID);

        parms[2] = new SqlParameter(Fin_Bills_Dtl_DT.EnumInfo_Bills_Dtl.PActv_ID.ToString(), obj.PActv_ID);

        parms[3] = new SqlParameter(Fin_Bills_Dtl_DT.EnumInfo_Bills_Dtl.Quantity.ToString(), obj.Quantity);

        parms[4] = new SqlParameter(Fin_Bills_Dtl_DT.EnumInfo_Bills_Dtl.unit_value.ToString(), obj.unit_value);

        parms[5] = new SqlParameter(Fin_Bills_Dtl_DT.EnumInfo_Bills_Dtl.Total_Value.ToString(), obj.Total_Value);

        parms[6] = new SqlParameter(Fin_Bills_Dtl_DT.EnumInfo_Bills_Dtl.Notes.ToString(), obj.Notes);

        return parms;
    }

    #endregion

    public static int Save(Fin_Bills_Dtl_DT obj)
    {
        try
        {
            SqlParameter[] parms = GetParameters(obj, false);

            SqlHelper.ExecuteScalar(Database.ConnectionString, CommandType.StoredProcedure, "Fin_Bills_Dtl_Save", parms);
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
            SqlHelper.ExecuteNonQuery(Database.ConnectionString, "Fin_Bills_Dtl_Delete", ID);
            return ID;
        }
        catch (Exception ex)
        {
            return -1;
        }
    }

    public static DataTable SelectAll()
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Fin_Bills_Dtl_Select", 0).Tables[0];

    }

    public static DataTable SelectAll_Grid(int Bil_ID)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Fin_Bills_Dtl_Select_Grid", Bil_ID).Tables[0];

    }

    public static DataTable SelectAll_init(int Work_Order_ID)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Fin_Bills_Dtl_Select_Init", Work_Order_ID).Tables[0];

    }

    public static Fin_Bills_Dtl_DT SelectByID(int ID)
    {
        try
        {
            SqlDataReader drTableName;
            Fin_Bills_Dtl_DT obj = new Fin_Bills_Dtl_DT();
            if (ID > 0)
            {
                drTableName = SqlHelper.ExecuteReader(Database.ConnectionString, "Fin_Bills_Dtl_Select", ID);
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


}
