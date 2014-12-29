using System;
using System.Data.SqlClient;
using System.Data;


public static class Project_Team_DB
{
    #region "Private methods"

    private static Project_Team_DT FillInfoObject(SqlDataReader dr)
    {

        Project_Team_DT oProject_Team_DT = new Project_Team_DT();


        oProject_Team_DT.PTem_ID = Convert.ToInt32(dr[Project_Team_DT.EnumInfo_Project_Team.PTem_ID.ToString()]);
        oProject_Team_DT.rol_rol_id = dr[Project_Team_DT.EnumInfo_Project_Team.rol_rol_id.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Project_Team_DT.EnumInfo_Project_Team.rol_rol_id.ToString()]);
        oProject_Team_DT.proj_proj_id = dr[Project_Team_DT.EnumInfo_Project_Team.proj_proj_id.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Project_Team_DT.EnumInfo_Project_Team.proj_proj_id.ToString()]);
        oProject_Team_DT.pmp_pmp_id = dr[Project_Team_DT.EnumInfo_Project_Team.pmp_pmp_id.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Project_Team_DT.EnumInfo_Project_Team.pmp_pmp_id.ToString()]);
        oProject_Team_DT.job_job_id = dr[Project_Team_DT.EnumInfo_Project_Team.job_job_id.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Project_Team_DT.EnumInfo_Project_Team.job_job_id.ToString()]);
        oProject_Team_DT.PTem_Task_Cat = dr[Project_Team_DT.EnumInfo_Project_Team.PTem_Task_Cat.ToString()] == DBNull.Value ? null : Convert.ToString(dr[Project_Team_DT.EnumInfo_Project_Team.PTem_Task_Cat.ToString()]);
        oProject_Team_DT.PTem_Name = dr[Project_Team_DT.EnumInfo_Project_Team.PTem_Name.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Project_Team_DT.EnumInfo_Project_Team.PTem_Name.ToString()]);
        oProject_Team_DT.PTem_Task = dr[Project_Team_DT.EnumInfo_Project_Team.PTem_Task.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Project_Team_DT.EnumInfo_Project_Team.PTem_Task.ToString()]);

        return oProject_Team_DT;
    }

    private static SqlParameter[] GetParameters(Project_Team_DT obj, bool isSearch)
    {
        SqlParameter[] parms = new SqlParameter[8];


        if (!isSearch)
        {

            parms[0] = new SqlParameter(Project_Team_DT.EnumInfo_Project_Team.PTem_ID.ToString(), obj.PTem_ID);
            parms[0].Direction = ParameterDirection.InputOutput;

        }

        parms[1] = new SqlParameter(Project_Team_DT.EnumInfo_Project_Team.rol_rol_id.ToString(), obj.rol_rol_id);

        parms[2] = new SqlParameter(Project_Team_DT.EnumInfo_Project_Team.proj_proj_id.ToString(), obj.proj_proj_id);

        parms[3] = new SqlParameter(Project_Team_DT.EnumInfo_Project_Team.pmp_pmp_id.ToString(), obj.pmp_pmp_id);

        parms[4] = new SqlParameter(Project_Team_DT.EnumInfo_Project_Team.job_job_id.ToString(), obj.job_job_id);

        parms[5] = new SqlParameter(Project_Team_DT.EnumInfo_Project_Team.PTem_Task_Cat.ToString(), obj.PTem_Task_Cat);

        parms[6] = new SqlParameter(Project_Team_DT.EnumInfo_Project_Team.PTem_Name.ToString(), obj.PTem_Name);

        parms[7] = new SqlParameter(Project_Team_DT.EnumInfo_Project_Team.PTem_Task.ToString(), obj.PTem_Task);

        return parms;
    }

    #endregion

    #region DataBase Function

    public static int Save(Project_Team_DT obj)
    {
        try
        {
            SqlParameter[] parms = GetParameters(obj, false);

            SqlHelper.ExecuteScalar(Database.ConnectionString, CommandType.StoredProcedure, "Project_Team_Save", parms);
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
            SqlHelper.ExecuteNonQuery(Database.ConnectionString, "Project_Team_Delete", ID);
            return ID;
        }
        catch (Exception ex)
        {
            return -1;
        }
    }

    public static DataTable SelectAll(int proj_proj_id)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Project_Team_Select", 0, proj_proj_id).Tables[0];

    }

    public static Project_Team_DT SelectByID(int ID)
    {
        try
        {
            SqlDataReader drTableName;
            Project_Team_DT obj = new Project_Team_DT();
            if (ID > 0)
            {
                drTableName = SqlHelper.ExecuteReader(Database.ConnectionString, "Project_Team_Select", ID, 0);
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

