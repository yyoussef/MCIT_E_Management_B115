using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Project_Exchange_DB
/// </summary>
public static class Project_Exchange_DB
{

    public static DataTable Select_For_Grid(int Proj_id, int Year)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Project_Exchange_Select_Grid", Proj_id, Year).Tables[0];

    }

    #region "Private methods"

    private static Project_Exchange_DT FillInfoObject(SqlDataReader dr)
    {

        Project_Exchange_DT oProject_Exchange_DT = new Project_Exchange_DT();


        oProject_Exchange_DT.Project_Exchange_ID = Convert.ToInt32(dr[Project_Exchange_DT.EnumInfo_Exchange.Project_Exchange_ID.ToString()]);
        oProject_Exchange_DT.Proj_id = dr[Project_Exchange_DT.EnumInfo_Exchange.Proj_id.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Project_Exchange_DT.EnumInfo_Exchange.Proj_id.ToString()]);
        oProject_Exchange_DT.Year = dr[Project_Exchange_DT.EnumInfo_Exchange.Year.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Project_Exchange_DT.EnumInfo_Exchange.Year.ToString()]);
        oProject_Exchange_DT.Sources_ID = dr[Project_Exchange_DT.EnumInfo_Exchange.Sources_ID.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Project_Exchange_DT.EnumInfo_Exchange.Sources_ID.ToString()]);
        oProject_Exchange_DT.Provider_ID = dr[Project_Exchange_DT.EnumInfo_Exchange.Provider_ID.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Project_Exchange_DT.EnumInfo_Exchange.Provider_ID.ToString()]);
        oProject_Exchange_DT.Rewards = dr[Project_Exchange_DT.EnumInfo_Exchange.Rewards.ToString()] == DBNull.Value ? 0 : Convert.ToDecimal(dr[Project_Exchange_DT.EnumInfo_Exchange.Rewards.ToString()]);
        oProject_Exchange_DT.Transitions = dr[Project_Exchange_DT.EnumInfo_Exchange.Transitions.ToString()] == DBNull.Value ? 0 : Convert.ToDecimal(dr[Project_Exchange_DT.EnumInfo_Exchange.Transitions.ToString()]);
        oProject_Exchange_DT.Hotels = dr[Project_Exchange_DT.EnumInfo_Exchange.Hotels.ToString()] == DBNull.Value ? 0 : Convert.ToDecimal(dr[Project_Exchange_DT.EnumInfo_Exchange.Hotels.ToString()]);
        oProject_Exchange_DT.Requirements = dr[Project_Exchange_DT.EnumInfo_Exchange.Requirements.ToString()] == DBNull.Value ? 0 : Convert.ToDecimal(dr[Project_Exchange_DT.EnumInfo_Exchange.Requirements.ToString()]);
        oProject_Exchange_DT.Training = dr[Project_Exchange_DT.EnumInfo_Exchange.Training.ToString()] == DBNull.Value ? 0 : Convert.ToDecimal(dr[Project_Exchange_DT.EnumInfo_Exchange.Training.ToString()]);
        oProject_Exchange_DT.Application = dr[Project_Exchange_DT.EnumInfo_Exchange.Application.ToString()] == DBNull.Value ? 0 : Convert.ToDecimal(dr[Project_Exchange_DT.EnumInfo_Exchange.Application.ToString()]);
        oProject_Exchange_DT.Tenders = dr[Project_Exchange_DT.EnumInfo_Exchange.Tenders.ToString()] == DBNull.Value ? 0 : Convert.ToDecimal(dr[Project_Exchange_DT.EnumInfo_Exchange.Tenders.ToString()]);
        oProject_Exchange_DT.Resources = dr[Project_Exchange_DT.EnumInfo_Exchange.Resources.ToString()] == DBNull.Value ? 0 : Convert.ToDecimal(dr[Project_Exchange_DT.EnumInfo_Exchange.Resources.ToString()]);
        oProject_Exchange_DT.Communication = dr[Project_Exchange_DT.EnumInfo_Exchange.Communication.ToString()] == DBNull.Value ? 0 : Convert.ToDecimal(dr[Project_Exchange_DT.EnumInfo_Exchange.Communication.ToString()]);
        oProject_Exchange_DT.Engineering = dr[Project_Exchange_DT.EnumInfo_Exchange.Engineering.ToString()] == DBNull.Value ? 0 : Convert.ToDecimal(dr[Project_Exchange_DT.EnumInfo_Exchange.Engineering.ToString()]);
        oProject_Exchange_DT.Licence = dr[Project_Exchange_DT.EnumInfo_Exchange.Licence.ToString()] == DBNull.Value ? 0 : Convert.ToDecimal(dr[Project_Exchange_DT.EnumInfo_Exchange.Licence.ToString()]);
        oProject_Exchange_DT.Reinvestment = dr[Project_Exchange_DT.EnumInfo_Exchange.Reinvestment.ToString()] == DBNull.Value ? 0 : Convert.ToDecimal(dr[Project_Exchange_DT.EnumInfo_Exchange.Reinvestment.ToString()]);

        return oProject_Exchange_DT;
    }

    private static SqlParameter[] GetParameters(Project_Exchange_DT obj, bool isSearch)
    {
        SqlParameter[] parms = new SqlParameter[17];


        if (!isSearch)
        {

            parms[0] = new SqlParameter(Project_Exchange_DT.EnumInfo_Exchange.Project_Exchange_ID.ToString(), obj.Project_Exchange_ID);
            parms[0].Direction = ParameterDirection.InputOutput;

        }

        parms[1] = new SqlParameter(Project_Exchange_DT.EnumInfo_Exchange.Proj_id.ToString(), obj.Proj_id);

        parms[2] = new SqlParameter(Project_Exchange_DT.EnumInfo_Exchange.Year.ToString(), obj.Year);

        parms[3] = new SqlParameter(Project_Exchange_DT.EnumInfo_Exchange.Sources_ID.ToString(), obj.Sources_ID);

        parms[4] = new SqlParameter(Project_Exchange_DT.EnumInfo_Exchange.Provider_ID.ToString(), obj.Provider_ID);

        parms[5] = new SqlParameter(Project_Exchange_DT.EnumInfo_Exchange.Rewards.ToString(), obj.Rewards);

        parms[6] = new SqlParameter(Project_Exchange_DT.EnumInfo_Exchange.Transitions.ToString(), obj.Transitions);

        parms[7] = new SqlParameter(Project_Exchange_DT.EnumInfo_Exchange.Hotels.ToString(), obj.Hotels);

        parms[8] = new SqlParameter(Project_Exchange_DT.EnumInfo_Exchange.Requirements.ToString(), obj.Requirements);

        parms[9] = new SqlParameter(Project_Exchange_DT.EnumInfo_Exchange.Training.ToString(), obj.Training);

        parms[10] = new SqlParameter(Project_Exchange_DT.EnumInfo_Exchange.Application.ToString(), obj.Application);

        parms[11] = new SqlParameter(Project_Exchange_DT.EnumInfo_Exchange.Tenders.ToString(), obj.Tenders);

        parms[12] = new SqlParameter(Project_Exchange_DT.EnumInfo_Exchange.Resources.ToString(), obj.Resources);

        parms[13] = new SqlParameter(Project_Exchange_DT.EnumInfo_Exchange.Communication.ToString(), obj.Communication);

        parms[14] = new SqlParameter(Project_Exchange_DT.EnumInfo_Exchange.Engineering.ToString(), obj.Engineering);

        parms[15] = new SqlParameter(Project_Exchange_DT.EnumInfo_Exchange.Licence.ToString(), obj.Licence);

        parms[16] = new SqlParameter(Project_Exchange_DT.EnumInfo_Exchange.Reinvestment.ToString(), obj.Reinvestment);

        return parms;
    }

    #endregion

    public static int Save(Project_Exchange_DT obj)
    {
        try
        {
            SqlParameter[] parms = GetParameters(obj, false);

            SqlHelper.ExecuteScalar(Database.ConnectionString, CommandType.StoredProcedure, "Project_Exchange_Save", parms);
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
            SqlHelper.ExecuteNonQuery(Database.ConnectionString, "Project_Exchange_Delete", ID);
            return ID;
        }
        catch (Exception ex)
        {
            return -1;
        }
    }

    public static DataTable SelectAll(int Work_Order_ID)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Project_Exchange_Select", 0, Work_Order_ID).Tables[0];

    }

   
    public static Project_Exchange_DT SelectByID(int ID)
    {
        try
        {
            SqlDataReader drTableName;
            Project_Exchange_DT obj = new Project_Exchange_DT();
            if (ID > 0)
            {
                drTableName = SqlHelper.ExecuteReader(Database.ConnectionString, "Project_Exchange_Select", ID, 0);
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
