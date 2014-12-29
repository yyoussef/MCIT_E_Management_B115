using System;
using System.Data.SqlClient;
using System.Data;

using System.Web.UI.WebControls;
using System.Data.SqlTypes;
/// <summary>
/// Summary description for Fin_Work_Order_Letter_DB
/// </summary>
public class Fin_Work_Order_Letter_DB
{
    #region "Private methods"

    private static Fin_Work_Order_Letter_DT FillInfoObject(SqlDataReader dr)
        {

            Fin_Work_Order_Letter_DT oFin_Work_Order_Letter_DT = new Fin_Work_Order_Letter_DT();

           
		oFin_Work_Order_Letter_DT.Letter_Id = Convert.ToInt32(dr[Fin_Work_Order_Letter_DT.EnumInfo_Work_Order_Letter.Letter_Id.ToString()]);
		oFin_Work_Order_Letter_DT.Work_Order_ID = dr[Fin_Work_Order_Letter_DT.EnumInfo_Work_Order_Letter.Work_Order_ID.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Fin_Work_Order_Letter_DT.EnumInfo_Work_Order_Letter.Work_Order_ID.ToString()]);
		oFin_Work_Order_Letter_DT.Letter_Value = dr[Fin_Work_Order_Letter_DT.EnumInfo_Work_Order_Letter.Letter_Value.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Fin_Work_Order_Letter_DT.EnumInfo_Work_Order_Letter.Letter_Value.ToString()]);
		oFin_Work_Order_Letter_DT.Letter_Percent = dr[Fin_Work_Order_Letter_DT.EnumInfo_Work_Order_Letter.Letter_Percent.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Fin_Work_Order_Letter_DT.EnumInfo_Work_Order_Letter.Letter_Percent.ToString()]);
		oFin_Work_Order_Letter_DT.Type = dr[Fin_Work_Order_Letter_DT.EnumInfo_Work_Order_Letter.Type.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Fin_Work_Order_Letter_DT.EnumInfo_Work_Order_Letter.Type.ToString()]);
        oFin_Work_Order_Letter_DT.Letter_File = dr[Fin_Work_Order_Letter_DT.EnumInfo_Work_Order_Letter.Letter_File.ToString()] == DBNull.Value ? null : (Byte[])(dr[Fin_Work_Order_Letter_DT.EnumInfo_Work_Order_Letter.Letter_File.ToString()]);
		oFin_Work_Order_Letter_DT.Strt_DT = dr[Fin_Work_Order_Letter_DT.EnumInfo_Work_Order_Letter.Strt_DT.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Fin_Work_Order_Letter_DT.EnumInfo_Work_Order_Letter.Strt_DT.ToString()]);
		oFin_Work_Order_Letter_DT.End_Dt = dr[Fin_Work_Order_Letter_DT.EnumInfo_Work_Order_Letter.End_Dt.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Fin_Work_Order_Letter_DT.EnumInfo_Work_Order_Letter.End_Dt.ToString()]);
		oFin_Work_Order_Letter_DT.Bank = dr[Fin_Work_Order_Letter_DT.EnumInfo_Work_Order_Letter.Bank.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Fin_Work_Order_Letter_DT.EnumInfo_Work_Order_Letter.Bank.ToString()]);
		oFin_Work_Order_Letter_DT.Letter_File_Type = dr[Fin_Work_Order_Letter_DT.EnumInfo_Work_Order_Letter.Letter_File_Type.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Fin_Work_Order_Letter_DT.EnumInfo_Work_Order_Letter.Letter_File_Type.ToString()]);
		oFin_Work_Order_Letter_DT.Alarm_DT = dr[Fin_Work_Order_Letter_DT.EnumInfo_Work_Order_Letter.Alarm_DT.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Fin_Work_Order_Letter_DT.EnumInfo_Work_Order_Letter.Alarm_DT.ToString()]);

            return oFin_Work_Order_Letter_DT;
        }

    private static SqlParameter[] GetParameters(Fin_Work_Order_Letter_DT obj, bool isSearch)
    {
        SqlParameter[] parms = new SqlParameter[9];


        if (!isSearch)
        {

            parms[0] = new SqlParameter(Fin_Work_Order_Letter_DT.EnumInfo_Work_Order_Letter.Letter_Id.ToString(), obj.Letter_Id);
            parms[0].Direction = ParameterDirection.InputOutput;

        }

        parms[1] = new SqlParameter(Fin_Work_Order_Letter_DT.EnumInfo_Work_Order_Letter.Work_Order_ID.ToString(), obj.Work_Order_ID);

        parms[2] = new SqlParameter(Fin_Work_Order_Letter_DT.EnumInfo_Work_Order_Letter.Letter_Value.ToString(), obj.Letter_Value);

        parms[3] = new SqlParameter(Fin_Work_Order_Letter_DT.EnumInfo_Work_Order_Letter.Letter_Percent.ToString(), obj.Letter_Percent);

        parms[4] = new SqlParameter(Fin_Work_Order_Letter_DT.EnumInfo_Work_Order_Letter.Type.ToString(), obj.Type);

       // parms[5] = new SqlParameter(Fin_Work_Order_Letter_DT.EnumInfo_Work_Order_Letter.Letter_File.ToString(), obj.Letter_File);

        parms[5] = new SqlParameter(Fin_Work_Order_Letter_DT.EnumInfo_Work_Order_Letter.Strt_DT.ToString(), obj.Strt_DT);

        parms[6] = new SqlParameter(Fin_Work_Order_Letter_DT.EnumInfo_Work_Order_Letter.End_Dt.ToString(), obj.End_Dt);

        parms[7] = new SqlParameter(Fin_Work_Order_Letter_DT.EnumInfo_Work_Order_Letter.Bank.ToString(), obj.Bank);

       // parms[9] = new SqlParameter(Fin_Work_Order_Letter_DT.EnumInfo_Work_Order_Letter.Letter_File_Type.ToString(), obj.Letter_File_Type);

        parms[8] = new SqlParameter(Fin_Work_Order_Letter_DT.EnumInfo_Work_Order_Letter.Alarm_DT.ToString(), obj.Alarm_DT);

        return parms;
    }

    #endregion

    #region DataBase Function

    public static int Save(Fin_Work_Order_Letter_DT obj)
    {
        try
        {
            SqlParameter[] parms = GetParameters(obj, false);

            SqlHelper.ExecuteScalar(Database.ConnectionString, CommandType.StoredProcedure, "Fin_Work_Order_Letter_Save", parms);
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
            SqlHelper.ExecuteNonQuery(Database.ConnectionString, "Fin_Work_Order_Letter_Delete", ID);
            return ID;
        }
        catch (Exception ex)
        {
            return -1;
        }
    }

    public static DataTable SelectAll(int proj_proj_id)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Fin_Work_Order_Letter_Select",  proj_proj_id).Tables[0];

    }

    public static DataTable Select_by_ID_Datatable(int ID)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Fin_Work_Order_Letter_Select_Main_id", ID).Tables[0];

    }

    public static Fin_Work_Order_Letter_DT SelectByID(int ID)
    {
        try
        {
            SqlDataReader drTableName;
            Fin_Work_Order_Letter_DT obj = new Fin_Work_Order_Letter_DT();
            if (ID > 0)
            {
                drTableName = SqlHelper.ExecuteReader(Database.ConnectionString, "Fin_Work_Order_Letter_Select", ID);
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
