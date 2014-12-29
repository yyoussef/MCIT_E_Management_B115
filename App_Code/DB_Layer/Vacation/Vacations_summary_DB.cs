using System;
using System.Data.SqlClient;
using System.Data;


/// <summary>
/// Summary description for Vacations_summary_DB
/// </summary>
public class Vacations_summary_DB
{
    #region "Private methods"

    private static Vacations_summary_DT FillInfoObject(SqlDataReader dr)
    {

        Vacations_summary_DT oInfo_summary = new Vacations_summary_DT();


        oInfo_summary.id = Convert.ToInt32(dr[Vacations_summary_DT.EnumInfo_summary.id.ToString()]);
        oInfo_summary.emp_id = dr[Vacations_summary_DT.EnumInfo_summary.emp_id.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Vacations_summary_DT.EnumInfo_summary.emp_id.ToString()]);
        oInfo_summary.unusual = dr[Vacations_summary_DT.EnumInfo_summary.unusual.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Vacations_summary_DT.EnumInfo_summary.unusual.ToString()]);
        oInfo_summary.exhibitor = dr[Vacations_summary_DT.EnumInfo_summary.exhibitor.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Vacations_summary_DT.EnumInfo_summary.exhibitor.ToString()]);
        oInfo_summary.sick = dr[Vacations_summary_DT.EnumInfo_summary.sick.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Vacations_summary_DT.EnumInfo_summary.sick.ToString()]);
        oInfo_summary.hajj = dr[Vacations_summary_DT.EnumInfo_summary.hajj.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Vacations_summary_DT.EnumInfo_summary.hajj.ToString()]);
        oInfo_summary.birth = dr[Vacations_summary_DT.EnumInfo_summary.birth.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Vacations_summary_DT.EnumInfo_summary.birth.ToString()]);
        oInfo_summary.repeat = dr[Vacations_summary_DT.EnumInfo_summary.repeat.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Vacations_summary_DT.EnumInfo_summary.repeat.ToString()]);
        oInfo_summary.year = dr[Vacations_summary_DT.EnumInfo_summary.year.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Vacations_summary_DT.EnumInfo_summary.year.ToString()]);
        oInfo_summary.unusual_total = dr[Vacations_summary_DT.EnumInfo_summary.unusual_total.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Vacations_summary_DT.EnumInfo_summary.unusual_total.ToString()]);
        oInfo_summary.exhibitor_total = dr[Vacations_summary_DT.EnumInfo_summary.exhibitor_total.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Vacations_summary_DT.EnumInfo_summary.exhibitor_total.ToString()]);

        return oInfo_summary;
    }

    private static SqlParameter[] GetParameters(Vacations_summary_DT obj, bool isSearch)
    {
        SqlParameter[] parms = new SqlParameter[11];


        if (!isSearch)
        {

            parms[0] = new SqlParameter(Vacations_summary_DT.EnumInfo_summary.id.ToString(), obj.id);
            parms[0].Direction = ParameterDirection.InputOutput;

        }

        parms[1] = new SqlParameter(Vacations_summary_DT.EnumInfo_summary.emp_id.ToString(), obj.emp_id);

        parms[2] = new SqlParameter(Vacations_summary_DT.EnumInfo_summary.unusual.ToString(), obj.unusual);

        parms[3] = new SqlParameter(Vacations_summary_DT.EnumInfo_summary.exhibitor.ToString(), obj.exhibitor);

        parms[4] = new SqlParameter(Vacations_summary_DT.EnumInfo_summary.sick.ToString(), obj.sick);

        parms[5] = new SqlParameter(Vacations_summary_DT.EnumInfo_summary.hajj.ToString(), obj.hajj);

        parms[6] = new SqlParameter(Vacations_summary_DT.EnumInfo_summary.birth.ToString(), obj.birth);

        parms[7] = new SqlParameter(Vacations_summary_DT.EnumInfo_summary.repeat.ToString(), obj.repeat);

        parms[8] = new SqlParameter(Vacations_summary_DT.EnumInfo_summary.year.ToString(), obj.year);
        parms[9] = new SqlParameter(Vacations_summary_DT.EnumInfo_summary.exhibitor_total.ToString(), obj.exhibitor_total );
        parms[10] = new SqlParameter(Vacations_summary_DT.EnumInfo_summary.unusual_total .ToString(), obj.unusual_total);
        return parms;
    }

    #endregion

    public static int Save(Vacations_summary_DT obj)
    {
        try
        {
            SqlParameter[] parms = GetParameters(obj, false);

            SqlHelper.ExecuteScalar(Database.ConnectionString, CommandType.StoredProcedure, "Vacations_summary_Save", parms);
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
            SqlHelper.ExecuteNonQuery(Database.ConnectionString, "Vacations_summary_Delete", ID);
            return ID;
        }
        catch (Exception ex)
        {
            return -1;
        }
    }

    public static DataTable SelectAll()
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Vacations_summary_Select",  0).Tables[0];

    }

   
    public static Vacations_summary_DT SelectByID(int ID)
    {
        try
        {
            SqlDataReader drTableName;
            Vacations_summary_DT obj = new Vacations_summary_DT();
            if (ID > 0)
            {
                drTableName = SqlHelper.ExecuteReader(Database.ConnectionString, "Vacations_summary_Select", ID, CDataConverter.ConvertDateTimeNowRtnDt().Year);
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

    public static Vacations_summary_DT SelectBy_Emp_ID(int ID)
    {
        try
        {
            SqlDataReader drTableName;
            Vacations_summary_DT obj = new Vacations_summary_DT();

            drTableName = SqlHelper.ExecuteReader(Database.ConnectionString, "Vacations_summary_Select_Emp_ID", ID, CDataConverter.ConvertDateTimeNowRtnDt().Year);
            if (drTableName != null)
            {
                while (drTableName.Read())
                {
                    obj = FillInfoObject(drTableName);
                }

                drTableName.Close();
            }
            return obj;
        }
        catch (Exception ex)
        {

            return null;
        }
    }


}
