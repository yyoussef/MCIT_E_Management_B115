using System;
using System.Data.SqlClient;
using System.Data;


/// <summary>
/// Summary description for Fin_Work_Activites_DB
/// </summary>
public static  class Fin_Work_Activites_DB
{

    #region "Private methods"

    private static Fin_Work_Activites_DT FillInfoObject(SqlDataReader dr)
    {

        Fin_Work_Activites_DT oInfo_Work_Activites = new Fin_Work_Activites_DT();


        oInfo_Work_Activites.Work_Act_ID = Convert.ToInt32(dr[Fin_Work_Activites_DT.EnumInfo_Work_Activites.Work_Act_ID.ToString()]);
        oInfo_Work_Activites.Work_Order_ID = dr[Fin_Work_Activites_DT.EnumInfo_Work_Activites.Work_Order_ID.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Fin_Work_Activites_DT.EnumInfo_Work_Activites.Work_Order_ID.ToString()]);
        oInfo_Work_Activites.PActv_ID = dr[Fin_Work_Activites_DT.EnumInfo_Work_Activites.PActv_ID.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Fin_Work_Activites_DT.EnumInfo_Work_Activites.PActv_ID.ToString()]);

        return oInfo_Work_Activites;
    }

    private static SqlParameter[] GetParameters(Fin_Work_Activites_DT obj, bool isSearch)
    {
        SqlParameter[] parms = new SqlParameter[3];


        if (!isSearch)
        {

            parms[0] = new SqlParameter(Fin_Work_Activites_DT.EnumInfo_Work_Activites.Work_Act_ID.ToString(), obj.Work_Act_ID);
            parms[0].Direction = ParameterDirection.InputOutput;

        }

        parms[1] = new SqlParameter(Fin_Work_Activites_DT.EnumInfo_Work_Activites.Work_Order_ID.ToString(), obj.Work_Order_ID);

        parms[2] = new SqlParameter(Fin_Work_Activites_DT.EnumInfo_Work_Activites.PActv_ID.ToString(), obj.PActv_ID);

        return parms;
    }

    #endregion

    #region DataBase Function

    public static int Save(Fin_Work_Activites_DT obj)
    {
        try
        {
            SqlParameter[] parms = GetParameters(obj, false);

            SqlHelper.ExecuteScalar(Database.ConnectionString, CommandType.StoredProcedure, "Fin_Work_Activites_Save", parms);
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
            SqlHelper.ExecuteNonQuery(Database.ConnectionString, "Fin_Work_Activites_Delete", ID);
            return ID;
        }
        catch (Exception ex)
        {
            return -1;
        }
    }

    public static int Delete_by_Work_Order_ID(int ID)
    {
        try
        {
            SqlHelper.ExecuteNonQuery(Database.ConnectionString, "Fin_Work_Activites_Delete_by_Work_Order_ID", ID);
            return ID;
        }
        catch (Exception ex)
        {
            return -1;
        }
    }


    
    public static DataTable SelectAll(int Work_Order_ID)
    {
        try
        {

            return SqlHelper.ExecuteDataset(Database.ConnectionString, "Fin_Work_Activites_Select", 0, Work_Order_ID).Tables[0];
        }

        catch (Exception ex)
        {

            return null;
        }
    }

    public static Fin_Work_Activites_DT SelectByID(int ID)
    {
        try
        {
            SqlDataReader drTableName;
            Fin_Work_Activites_DT obj = new Fin_Work_Activites_DT();
            if (ID > 0)
            {
                drTableName = SqlHelper.ExecuteReader(Database.ConnectionString, "Fin_Work_Activites_Select", ID, 0);
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
