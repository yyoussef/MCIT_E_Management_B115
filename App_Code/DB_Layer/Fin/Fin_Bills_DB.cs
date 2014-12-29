using System;
using System.Data.SqlClient;
using System.Data;


/// <summary>
/// Summary description for Fin_Bills_DB
/// </summary>
public static class Fin_Bills_DB
{
    #region "Private methods" 

    private static Fin_Bills_DT FillInfoObject(SqlDataReader dr)
    {
        Fin_Bills_DT oInfo_Bills = new Fin_Bills_DT();
        oInfo_Bills.Bil_ID = Convert.ToInt32(dr[Fin_Bills_DT.EnumInfo_Bills.Bil_ID.ToString()]);
        oInfo_Bills.Work_Order_ID = dr[Fin_Bills_DT.EnumInfo_Bills.Work_Order_ID.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Fin_Bills_DT.EnumInfo_Bills.Work_Order_ID.ToString()]);
        oInfo_Bills.Project_ID = dr[Fin_Bills_DT.EnumInfo_Bills.Project_ID.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Fin_Bills_DT.EnumInfo_Bills.Project_ID.ToString()]);
        oInfo_Bills.Source_id = dr[Fin_Bills_DT.EnumInfo_Bills.Source_id.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Fin_Bills_DT.EnumInfo_Bills.Source_id.ToString()]);
        oInfo_Bills.Provider_id = dr[Fin_Bills_DT.EnumInfo_Bills.Provider_id.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Fin_Bills_DT.EnumInfo_Bills.Provider_id.ToString()]);
        oInfo_Bills.Bil_Percent = dr[Fin_Bills_DT.EnumInfo_Bills.Bil_Percent.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Fin_Bills_DT.EnumInfo_Bills.Bil_Percent.ToString()]);
        oInfo_Bills.Type = dr[Fin_Bills_DT.EnumInfo_Bills.Type.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Fin_Bills_DT.EnumInfo_Bills.Type.ToString()]);
        oInfo_Bills.Code = dr[Fin_Bills_DT.EnumInfo_Bills.Code.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Fin_Bills_DT.EnumInfo_Bills.Code.ToString()]);
        oInfo_Bills.Bil_Value = dr[Fin_Bills_DT.EnumInfo_Bills.Bil_Value.ToString()] == DBNull.Value ? 0 : Convert.ToDecimal(dr[Fin_Bills_DT.EnumInfo_Bills.Bil_Value.ToString()]);
        oInfo_Bills.Date = dr[Fin_Bills_DT.EnumInfo_Bills.Date.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Fin_Bills_DT.EnumInfo_Bills.Date.ToString()]);
        oInfo_Bills.Notes = dr[Fin_Bills_DT.EnumInfo_Bills.Notes.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Fin_Bills_DT.EnumInfo_Bills.Notes.ToString()]);
        return oInfo_Bills;
    }

    private static SqlParameter[] GetParameters(Fin_Bills_DT obj, bool isSearch)
    {
        SqlParameter[] parms = new SqlParameter[11];


        if (!isSearch)
        {

            parms[0] = new SqlParameter(Fin_Bills_DT.EnumInfo_Bills.Bil_ID.ToString(), obj.Bil_ID);
            parms[0].Direction = ParameterDirection.InputOutput;

        }

        parms[1] = new SqlParameter(Fin_Bills_DT.EnumInfo_Bills.Work_Order_ID.ToString(), obj.Work_Order_ID);

        parms[2] = new SqlParameter(Fin_Bills_DT.EnumInfo_Bills.Bil_Value.ToString(), obj.Bil_Value);

        parms[3] = new SqlParameter(Fin_Bills_DT.EnumInfo_Bills.Date.ToString(), obj.Date);

        parms[4] = new SqlParameter(Fin_Bills_DT.EnumInfo_Bills.Notes.ToString(), obj.Notes);

        parms[5] = new SqlParameter(Fin_Bills_DT.EnumInfo_Bills.Code.ToString(), obj.Code);

        parms[6] = new SqlParameter(Fin_Bills_DT.EnumInfo_Bills.Bil_Percent.ToString(), obj.Bil_Percent);

        parms[7] = new SqlParameter(Fin_Bills_DT.EnumInfo_Bills.Type.ToString(), obj.Type);

        parms[8] = new SqlParameter(Fin_Bills_DT.EnumInfo_Bills.Project_ID.ToString(), obj.Project_ID);

        parms[9] = new SqlParameter(Fin_Bills_DT.EnumInfo_Bills.Source_id.ToString(), obj.Source_id);

        parms[10] = new SqlParameter(Fin_Bills_DT.EnumInfo_Bills.Provider_id.ToString(), obj.Provider_id);

        return parms;
    }

    #endregion

    public static int Save(Fin_Bills_DT obj)
    {
        try
        {
            SqlParameter[] parms = GetParameters(obj, false);

            SqlHelper.ExecuteScalar(Database.ConnectionString, CommandType.StoredProcedure, "Fin_Bills_Save", parms);
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
            SqlHelper.ExecuteNonQuery(Database.ConnectionString, "Fin_Bills_Delete", ID);
            return ID;
        }
        catch (Exception ex)
        {
            return -1;
        }
    }

    public static DataTable SelectAll(int Work_Order_ID)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Fin_Bills_Select", 0, Work_Order_ID).Tables[0];

    }
    public static DataTable Selectvaluebill(int proj_id)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "getworkbill", 0, proj_id).Tables[0];

    }

    public static DataTable SelectAll_by_Project_ID(int Project_ID, int Work_Order_Id)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Fin_Bills_Select_by_Project_ID", Project_ID, Work_Order_Id).Tables[0];

    }
    public static Fin_Bills_DT SelectByID(int ID)
    {
        try
        {
            SqlDataReader drTableName;
            Fin_Bills_DT obj = new Fin_Bills_DT();
            if (ID > 0)
            {
                drTableName = SqlHelper.ExecuteReader(Database.ConnectionString, "Fin_Bills_Select", ID, 0);
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