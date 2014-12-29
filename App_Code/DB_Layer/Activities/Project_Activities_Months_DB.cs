using System;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for Project_Activities_Months_DB
/// </summary>
public static class Project_Activities_Months_DB
{
    #region "Private methods"

    private static Project_Activities_Months_DT FillInfoObject(SqlDataReader dr)
    {

        Project_Activities_Months_DT oProject_Activities_Months_DT = new Project_Activities_Months_DT();


        oProject_Activities_Months_DT.ID = Convert.ToInt32(dr[Project_Activities_Months_DT.EnumInfo_Activities_Months.ID.ToString()]);
        oProject_Activities_Months_DT.Month = dr[Project_Activities_Months_DT.EnumInfo_Activities_Months.Month.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Project_Activities_Months_DT.EnumInfo_Activities_Months.Month.ToString()]);
        oProject_Activities_Months_DT.Year = dr[Project_Activities_Months_DT.EnumInfo_Activities_Months.Year.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Project_Activities_Months_DT.EnumInfo_Activities_Months.Year.ToString()]);
        oProject_Activities_Months_DT.Notes = dr[Project_Activities_Months_DT.EnumInfo_Activities_Months.Notes.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Project_Activities_Months_DT.EnumInfo_Activities_Months.Notes.ToString()]);
        oProject_Activities_Months_DT.End_DT = dr[Project_Activities_Months_DT.EnumInfo_Activities_Months.End_DT.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Project_Activities_Months_DT.EnumInfo_Activities_Months.End_DT.ToString()]);
        oProject_Activities_Months_DT.Active = dr[Project_Activities_Months_DT.EnumInfo_Activities_Months.Active.ToString()] == DBNull.Value ? false : Convert.ToBoolean(dr[Project_Activities_Months_DT.EnumInfo_Activities_Months.Active.ToString()]);

        return oProject_Activities_Months_DT;
    }

    private static SqlParameter[] GetParameters(Project_Activities_Months_DT obj, bool isSearch)
    {
        SqlParameter[] parms = new SqlParameter[6];


        if (!isSearch)
        {

            parms[0] = new SqlParameter(Project_Activities_Months_DT.EnumInfo_Activities_Months.ID.ToString(), obj.ID);
            parms[0].Direction = ParameterDirection.InputOutput;

        }

        parms[1] = new SqlParameter(Project_Activities_Months_DT.EnumInfo_Activities_Months.Month.ToString(), obj.Month);

        parms[2] = new SqlParameter(Project_Activities_Months_DT.EnumInfo_Activities_Months.Year.ToString(), obj.Year);

        parms[3] = new SqlParameter(Project_Activities_Months_DT.EnumInfo_Activities_Months.Notes.ToString(), obj.Notes);

        parms[4] = new SqlParameter(Project_Activities_Months_DT.EnumInfo_Activities_Months.Active.ToString(), obj.Active);

        parms[5] = new SqlParameter(Project_Activities_Months_DT.EnumInfo_Activities_Months.End_DT.ToString(), obj.End_DT);

        return parms;
    }

    #endregion

    #region DataBase Function

    public static int Save(Project_Activities_Months_DT obj)
    {
        try
        {
            SqlParameter[] parms = GetParameters(obj, false);

            SqlHelper.ExecuteScalar(Database.ConnectionString, CommandType.StoredProcedure, "Project_Activities_Months_Save", parms);
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
            SqlHelper.ExecuteNonQuery(Database.ConnectionString, "Project_Activities_Months_Delete", ID);
            return ID;
        }
        catch (Exception ex)
        {
            return -1;
        }
    }

    public static bool check_Active(int ID)
    {

        if (SqlHelper.ExecuteDataset(Database.ConnectionString, "Project_Activities_Months_Check_Valid", ID).Tables[0].Rows.Count > 0)
            return false;
        else
            return true;

    }

    public static Project_Activities_Months_DT Select_Active()
    {
        try
        {
            SqlDataReader drTableName;
            Project_Activities_Months_DT obj = new Project_Activities_Months_DT();

            drTableName = SqlHelper.ExecuteReader(Database.ConnectionString, "Project_Activities_Months_Select_Active");
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



    public static DataTable SelectAll(string Year)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Project_Activities_Months_Select",0, Year).Tables[0];

    }


    public static Project_Activities_Months_DT Selectby_month_Year(string Month, string Year)
    {
        try
        {
            SqlDataReader drTableName;
            Project_Activities_Months_DT obj = new Project_Activities_Months_DT();

            drTableName = SqlHelper.ExecuteReader(Database.ConnectionString, "Project_Activities_Months_Year_Select", Month, Year);
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

    public static Project_Activities_Months_DT SelectByID(int ID)
    {
        try
        {
            SqlDataReader drTableName;
            Project_Activities_Months_DT obj = new Project_Activities_Months_DT();
            if (ID > 0)
            {
                drTableName = SqlHelper.ExecuteReader(Database.ConnectionString, "Project_Activities_Months_Select", ID, "0");
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
