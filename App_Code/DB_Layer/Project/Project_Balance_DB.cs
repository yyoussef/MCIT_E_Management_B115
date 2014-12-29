using System;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for Project_Balance_DB
/// </summary>
public class Project_Balance_DB
{
    #region "Private methods"

    private static Project_Balance_DT FillInfoObject(SqlDataReader dr)
    {

        Project_Balance_DT oProject_Balance_DT = new Project_Balance_DT();


        oProject_Balance_DT.Project_Balnce_ID = Convert.ToInt32(dr[Project_Balance_DT.EnumInfo_Balance.Project_Balnce_ID.ToString()]);
        oProject_Balance_DT.Proj_id = dr[Project_Balance_DT.EnumInfo_Balance.Proj_id.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Project_Balance_DT.EnumInfo_Balance.Proj_id.ToString()]);
        oProject_Balance_DT.Fincial_Year_ID = dr[Project_Balance_DT.EnumInfo_Balance.Fincial_Year_ID.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Project_Balance_DT.EnumInfo_Balance.Fincial_Year_ID.ToString()]);
        oProject_Balance_DT.Balance_Value_LE = dr[Project_Balance_DT.EnumInfo_Balance.Balance_Value_LE.ToString()] == DBNull.Value ? 0 : Convert.ToDecimal(dr[Project_Balance_DT.EnumInfo_Balance.Balance_Value_LE.ToString()]);
        oProject_Balance_DT.Balance_Value_US = dr[Project_Balance_DT.EnumInfo_Balance.Balance_Value_US.ToString()] == DBNull.Value ? 0 : Convert.ToDecimal(dr[Project_Balance_DT.EnumInfo_Balance.Balance_Value_US.ToString()]);
        oProject_Balance_DT.Total_Value = dr[Project_Balance_DT.EnumInfo_Balance.Total_Value.ToString()] == DBNull.Value ? 0 : Convert.ToDecimal(dr[Project_Balance_DT.EnumInfo_Balance.Total_Value.ToString()]);
        oProject_Balance_DT.Description = dr[Project_Balance_DT.EnumInfo_Balance.Description.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Project_Balance_DT.EnumInfo_Balance.Description.ToString()]);
        oProject_Balance_DT.Source_Desc = dr[Project_Balance_DT.EnumInfo_Balance.Source_Desc.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Project_Balance_DT.EnumInfo_Balance.Source_Desc.ToString()]);

        return oProject_Balance_DT;
    }

    private static SqlParameter[] GetParameters(Project_Balance_DT obj, bool isSearch)
    {
        SqlParameter[] parms = new SqlParameter[8];


        if (!isSearch)
        {

            parms[0] = new SqlParameter(Project_Balance_DT.EnumInfo_Balance.Project_Balnce_ID.ToString(), obj.Project_Balnce_ID);
            parms[0].Direction = ParameterDirection.InputOutput;

        }

        parms[1] = new SqlParameter(Project_Balance_DT.EnumInfo_Balance.Proj_id.ToString(), obj.Proj_id);

        parms[2] = new SqlParameter(Project_Balance_DT.EnumInfo_Balance.Fincial_Year_ID.ToString(), obj.Fincial_Year_ID);

        parms[3] = new SqlParameter(Project_Balance_DT.EnumInfo_Balance.Balance_Value_LE.ToString(), obj.Balance_Value_LE);

        parms[4] = new SqlParameter(Project_Balance_DT.EnumInfo_Balance.Balance_Value_US.ToString(), obj.Balance_Value_US);

        parms[5] = new SqlParameter(Project_Balance_DT.EnumInfo_Balance.Description.ToString(), obj.Description);

        parms[6] = new SqlParameter(Project_Balance_DT.EnumInfo_Balance.Source_Desc.ToString(), obj.Source_Desc);

        parms[7] = new SqlParameter(Project_Balance_DT.EnumInfo_Balance.Total_Value.ToString(), obj.Total_Value);

        return parms;
    }

    #endregion

    #region DataBase Function

    public static int Save(Project_Balance_DT obj)
    {
        try
        {
            SqlParameter[] parms = GetParameters(obj, false);

            SqlHelper.ExecuteScalar(Database.ConnectionString, CommandType.StoredProcedure, "Project_Balance_Save", parms);
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
            SqlHelper.ExecuteNonQuery(Database.ConnectionString, "Project_Balance_Delete", ID);
            return ID;
        }
        catch (Exception ex)
        {
            return -1;
        }
    }

    public static DataTable SelectAll(int proj_proj_id)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Project_Balance_Select", proj_proj_id).Tables[0];

    }

    public static Project_Balance_DT SelectByID(int ID)
    {
        try
        {
            SqlDataReader drTableName;
            Project_Balance_DT obj = new Project_Balance_DT();
            if (ID > 0)
            {
                drTableName = SqlHelper.ExecuteReader(Database.ConnectionString, "Project_Balance_Select", ID);
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
