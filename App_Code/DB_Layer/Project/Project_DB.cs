using System;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for Project_DB
/// </summary>
public class Project_DB
{
    #region "Private methods"

    private static Project_DT FillInfoObject(SqlDataReader dr)
        {

            Project_DT oProject_DT = new Project_DT();

           
		oProject_DT.Protocol_ID = dr[Project_DT.EnumInfo_Project.Protocol_ID.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Project_DT.EnumInfo_Project.Protocol_ID.ToString()]);
		oProject_DT.Proj_is_commit = dr[Project_DT.EnumInfo_Project.Proj_is_commit.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Project_DT.EnumInfo_Project.Proj_is_commit.ToString()]);
		oProject_DT.Proj_is_refused = dr[Project_DT.EnumInfo_Project.Proj_is_refused.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Project_DT.EnumInfo_Project.Proj_is_refused.ToString()]);
		oProject_DT.Proj_is_repeated = dr[Project_DT.EnumInfo_Project.Proj_is_repeated.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Project_DT.EnumInfo_Project.Proj_is_repeated.ToString()]);
		oProject_DT.Proj_Brief = dr[Project_DT.EnumInfo_Project.Proj_Brief.ToString()] == DBNull.Value ? null : Convert.ToString(dr[Project_DT.EnumInfo_Project.Proj_Brief.ToString()]);
		oProject_DT.Proj_Notes = dr[Project_DT.EnumInfo_Project.Proj_Notes.ToString()] == DBNull.Value ? null : Convert.ToString(dr[Project_DT.EnumInfo_Project.Proj_Notes.ToString()]);
		oProject_DT.Return_Value = dr[Project_DT.EnumInfo_Project.Return_Value.ToString()] == DBNull.Value ? null : Convert.ToString(dr[Project_DT.EnumInfo_Project.Return_Value.ToString()]);
		oProject_DT.Total_Balance_Value_LE = dr[Project_DT.EnumInfo_Project.Total_Balance_Value_LE.ToString()] == DBNull.Value ? 0 : Convert.ToDecimal(dr[Project_DT.EnumInfo_Project.Total_Balance_Value_LE.ToString()]);
		oProject_DT.Total_Balance_Value_US = dr[Project_DT.EnumInfo_Project.Total_Balance_Value_US.ToString()] == DBNull.Value ? 0 : Convert.ToDecimal(dr[Project_DT.EnumInfo_Project.Total_Balance_Value_US.ToString()]);
		oProject_DT.Proj_id = Convert.ToInt64(dr[Project_DT.EnumInfo_Project.Proj_id.ToString()]);
		oProject_DT.Dept_Dept_id = dr[Project_DT.EnumInfo_Project.Dept_Dept_id.ToString()] == DBNull.Value ? 0 : Convert.ToInt64(dr[Project_DT.EnumInfo_Project.Dept_Dept_id.ToString()]);
		oProject_DT.pmp_pmp_id = dr[Project_DT.EnumInfo_Project.pmp_pmp_id.ToString()] == DBNull.Value ? 0 : Convert.ToInt64(dr[Project_DT.EnumInfo_Project.pmp_pmp_id.ToString()]);
		oProject_DT.Period_by_year = dr[Project_DT.EnumInfo_Project.Period_by_year.ToString()] == DBNull.Value ? 0 : Convert.ToInt64(dr[Project_DT.EnumInfo_Project.Period_by_year.ToString()]);
        oProject_DT.File_data = dr[Project_DT.EnumInfo_Project.File_data.ToString()] == DBNull.Value ? null : (Byte[])(dr[Project_DT.EnumInfo_Project.File_data.ToString()]);
		oProject_DT.Proj_Code = dr[Project_DT.EnumInfo_Project.Proj_Code.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Project_DT.EnumInfo_Project.Proj_Code.ToString()]);
		oProject_DT.start_date_Plan = dr[Project_DT.EnumInfo_Project.start_date_Plan.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Project_DT.EnumInfo_Project.start_date_Plan.ToString()]);
		oProject_DT.End_Date_Plan = dr[Project_DT.EnumInfo_Project.End_Date_Plan.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Project_DT.EnumInfo_Project.End_Date_Plan.ToString()]);
		oProject_DT.start_date_Real = dr[Project_DT.EnumInfo_Project.start_date_Real.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Project_DT.EnumInfo_Project.start_date_Real.ToString()]);
		oProject_DT.End_Date_Real = dr[Project_DT.EnumInfo_Project.End_Date_Real.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Project_DT.EnumInfo_Project.End_Date_Real.ToString()]);
		oProject_DT.Region_Desc = dr[Project_DT.EnumInfo_Project.Region_Desc.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Project_DT.EnumInfo_Project.Region_Desc.ToString()]);
		oProject_DT.Proj_Title = dr[Project_DT.EnumInfo_Project.Proj_Title.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Project_DT.EnumInfo_Project.Proj_Title.ToString()]);
		oProject_DT.File_name = dr[Project_DT.EnumInfo_Project.File_name.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Project_DT.EnumInfo_Project.File_name.ToString()]);
		oProject_DT.File_ext = dr[Project_DT.EnumInfo_Project.File_ext.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Project_DT.EnumInfo_Project.File_ext.ToString()]);
		oProject_DT.Proj_Creation_Date = dr[Project_DT.EnumInfo_Project.Proj_Creation_Date.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Project_DT.EnumInfo_Project.Proj_Creation_Date.ToString()]);
        oProject_DT.Proj_Goal_Stratege = dr[Project_DT.EnumInfo_Project.Proj_Goal_Stratege.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Project_DT.EnumInfo_Project.Proj_Goal_Stratege.ToString()]);

            return oProject_DT;
        }

    private static SqlParameter[] GetParameters(Project_DT obj, bool isSearch)
    {
        SqlParameter[] parms = new SqlParameter[25];



        parms[0] = new SqlParameter(Project_DT.EnumInfo_Project.Protocol_ID.ToString(), obj.Protocol_ID);

        parms[1] = new SqlParameter(Project_DT.EnumInfo_Project.Proj_is_commit.ToString(), obj.Proj_is_commit);

        parms[2] = new SqlParameter(Project_DT.EnumInfo_Project.Proj_is_refused.ToString(), obj.Proj_is_refused);

        parms[3] = new SqlParameter(Project_DT.EnumInfo_Project.Proj_is_repeated.ToString(), obj.Proj_is_repeated);

        parms[4] = new SqlParameter(Project_DT.EnumInfo_Project.Proj_Brief.ToString(), obj.Proj_Brief);

        parms[5] = new SqlParameter(Project_DT.EnumInfo_Project.Proj_Notes.ToString(), obj.Proj_Notes);

        parms[6] = new SqlParameter(Project_DT.EnumInfo_Project.Return_Value.ToString(), obj.Return_Value);

        parms[7] = new SqlParameter(Project_DT.EnumInfo_Project.Total_Balance_Value_LE.ToString(), obj.Total_Balance_Value_LE);

        parms[8] = new SqlParameter(Project_DT.EnumInfo_Project.Total_Balance_Value_US.ToString(), obj.Total_Balance_Value_US);
        if (!isSearch)
        {

            parms[9] = new SqlParameter(Project_DT.EnumInfo_Project.Proj_id.ToString(), obj.Proj_id);
            parms[9].Direction = ParameterDirection.InputOutput;

        }

        parms[10] = new SqlParameter(Project_DT.EnumInfo_Project.Dept_Dept_id.ToString(), obj.Dept_Dept_id);

        parms[11] = new SqlParameter(Project_DT.EnumInfo_Project.pmp_pmp_id.ToString(), obj.pmp_pmp_id);

        parms[12] = new SqlParameter(Project_DT.EnumInfo_Project.Period_by_year.ToString(), obj.Period_by_year);

        parms[13] = new SqlParameter(Project_DT.EnumInfo_Project.File_data.ToString(), obj.File_data);

        parms[14] = new SqlParameter(Project_DT.EnumInfo_Project.Proj_Code.ToString(), obj.Proj_Code);

        parms[15] = new SqlParameter(Project_DT.EnumInfo_Project.start_date_Plan.ToString(), obj.start_date_Plan);

        parms[16] = new SqlParameter(Project_DT.EnumInfo_Project.End_Date_Plan.ToString(), obj.End_Date_Plan);

        parms[17] = new SqlParameter(Project_DT.EnumInfo_Project.start_date_Real.ToString(), obj.start_date_Real);

        parms[18] = new SqlParameter(Project_DT.EnumInfo_Project.End_Date_Real.ToString(), obj.End_Date_Real);

        parms[19] = new SqlParameter(Project_DT.EnumInfo_Project.Region_Desc.ToString(), obj.Region_Desc);

        parms[20] = new SqlParameter(Project_DT.EnumInfo_Project.Proj_Title.ToString(), obj.Proj_Title);

        parms[21] = new SqlParameter(Project_DT.EnumInfo_Project.File_name.ToString(), obj.File_name);

        parms[22] = new SqlParameter(Project_DT.EnumInfo_Project.File_ext.ToString(), obj.File_ext);

        parms[23] = new SqlParameter(Project_DT.EnumInfo_Project.Proj_Creation_Date.ToString(), obj.Proj_Creation_Date);

        parms[24] = new SqlParameter(Project_DT.EnumInfo_Project.Proj_Goal_Stratege.ToString(), obj.Proj_Goal_Stratege);

        return parms;
    }

    #endregion

    #region DataBase Function

    public static int Save(Project_DT obj)
    {
        try
        {
            SqlParameter[] parms = GetParameters(obj, false);

            SqlHelper.ExecuteScalar(Database.ConnectionString, CommandType.StoredProcedure, "Project_Save", parms);
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
            SqlHelper.ExecuteNonQuery(Database.ConnectionString, "Project_Delete", ID);
            return ID;
        }
        catch (Exception ex)
        {
            return -1;
        }
    }

    public static DataTable SelectAll(int proj_proj_id)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Project_Select", proj_proj_id).Tables[0];

    }

    
    //  add new function to retrieve Avtive Projects  //// added 16/10/2012
  
    public static DataTable SelectActive_Projects(int rol, int Dept_id, int pmp)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Project_Active", rol, Dept_id, pmp).Tables[0];

    }
    public static DataTable SelectEnded_Projects(int rol, int Dept_id, int pmp)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Project_Ended", rol, Dept_id, pmp).Tables[0];

    }
    public static DataTable Selectunder_follow_Projects(int rol, int Dept_id, int pmp)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Project_under_follow", rol, Dept_id, pmp).Tables[0];

    }
    public static DataTable SelectStopped_Projects(int rol, int Dept_id, int pmp)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Project_Stopped", rol, Dept_id, pmp).Tables[0];

    }
    public static DataTable SelectSuggest_Approved_Projects(int rol, int Dept_id, int pmp)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Project_sugg_approved", rol, Dept_id, pmp).Tables[0];

    }
    public static DataTable SelectSuggest_Projects(int rol, int Dept_id, int pmp)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Project_suggest", rol, Dept_id, pmp).Tables[0];

    }
    public static DataTable SelectRepeated_Projects(int rol, int Dept_id, int pmp)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Project_Repeated", rol, Dept_id, pmp).Tables[0];

    }
    public static DataTable SelectRefused_Projects(int rol, int Dept_id, int pmp)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Project_Refused", rol, Dept_id, pmp).Tables[0];

    }
    public static DataTable SelectCanceled_Projects(int rol, int Dept_id, int pmp)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Project_Canceled", rol, Dept_id, pmp).Tables[0];

    }
    public static DataTable Project_Constraints()
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Project_Constraints_IsCritical").Tables[0];

    }


    public static DataTable Selectneeds_no_approve()
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Needs_Select_No_Approvment").Tables[0];

    }
    public static DataTable Selectneeds_no_Available()
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Needs_Select_No_Available").Tables[0];

    }
    public static DataTable Selectneeds_Recievied()
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Needs_Select_Recieved").Tables[0];

    }
    public static DataTable Selectneeds_Approved(int pmp)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Needs_Approved_projectmng",pmp).Tables[0];

    }
    public static DataTable Selectneeds_Available_Recievable(int pmp)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Needs_Available_Recievable", pmp).Tables[0];

    }
    public static DataTable SelectModules()
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Allmodules").Tables[0];

    }
    public static DataTable SelectModulesbyfound(int found)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "SelectModulesbyfound", found).Tables[0];

    }
    public static Project_DT SelectByID(int ID)
    {
        try
        {
            SqlDataReader drTableName;
            Project_DT obj = new Project_DT();
            if (ID > 0)
            {
                drTableName = SqlHelper.ExecuteReader(Database.ConnectionString, "sp_Project_Select", ID);
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
