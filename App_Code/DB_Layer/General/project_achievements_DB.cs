using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System;
using System.Data.SqlClient;



/// <summary>
/// Summary description for project_achievements_DB
/// </summary>
public class project_achievements_DB
{
    #region "Private methods"

    private static project_achievements_DT FillInfoObject(SqlDataReader dr)
    {

        project_achievements_DT oProject_achievements_DT = new project_achievements_DT();

        oProject_achievements_DT.ach_id = Convert.ToInt64(dr[project_achievements_DT.EnumInfo_project_achievements.ach_id.ToString()]);
        oProject_achievements_DT.ach_desc = dr[project_achievements_DT.EnumInfo_project_achievements.ach_desc.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[project_achievements_DT.EnumInfo_project_achievements.ach_desc.ToString()]);
        oProject_achievements_DT.ach_type = dr[project_achievements_DT.EnumInfo_project_achievements.ach_type.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[project_achievements_DT.EnumInfo_project_achievements.ach_type.ToString()]);
        oProject_achievements_DT.ach_other_desc = dr[project_achievements_DT.EnumInfo_project_achievements.ach_other_desc.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[project_achievements_DT.EnumInfo_project_achievements.ach_other_desc.ToString()]);
        oProject_achievements_DT.ach_from_date = dr[project_achievements_DT.EnumInfo_project_achievements.ach_from_date.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[project_achievements_DT.EnumInfo_project_achievements.ach_from_date.ToString()]);
        oProject_achievements_DT.ach_to_date = dr[project_achievements_DT.EnumInfo_project_achievements.ach_to_date.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[project_achievements_DT.EnumInfo_project_achievements.ach_to_date.ToString()]);
        oProject_achievements_DT.proj_id = dr[project_achievements_DT.EnumInfo_project_achievements.proj_id.ToString()] == DBNull.Value ? 0 : Convert.ToInt64(dr[project_achievements_DT.EnumInfo_project_achievements.proj_id.ToString()]);


        return oProject_achievements_DT;
    }

    private static SqlParameter[] GetParameters(project_achievements_DT obj, bool isSearch)
    {
        SqlParameter[] parms = new SqlParameter[7];


        if (!isSearch)
        {

            parms[0] = new SqlParameter(project_achievements_DT.EnumInfo_project_achievements.ach_id.ToString(), obj.ach_id);
            parms[0].Direction = ParameterDirection.InputOutput;

        }

        parms[1] = new SqlParameter(project_achievements_DT.EnumInfo_project_achievements.ach_desc.ToString(), obj.ach_desc);

        parms[2] = new SqlParameter(project_achievements_DT.EnumInfo_project_achievements.ach_type.ToString(), obj.ach_type);

        parms[3] = new SqlParameter(project_achievements_DT.EnumInfo_project_achievements.ach_other_desc.ToString(), obj.ach_other_desc);

        parms[4] = new SqlParameter(project_achievements_DT.EnumInfo_project_achievements.ach_from_date.ToString(), obj.ach_from_date);

        parms[5] = new SqlParameter(project_achievements_DT.EnumInfo_project_achievements.ach_to_date.ToString(), obj.ach_to_date);

        parms[6] = new SqlParameter(project_achievements_DT.EnumInfo_project_achievements.proj_id.ToString(), obj.proj_id);

    

        return parms;
    }

    #endregion

    #region DataBase Function

    public static int Save(project_achievements_DT obj)
    {
        try
        {
            SqlParameter[] parms = GetParameters(obj, false);

            SqlHelper.ExecuteScalar(Database.ConnectionString, CommandType.StoredProcedure, "project_achievements_Save", parms);
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
            SqlHelper.ExecuteNonQuery(Database.ConnectionString, "project_achievements_Delete", ID);
            return ID;
        }
        catch (Exception ex)
        {
            return -1;
        }
    }

    public static DataTable SelectAll(int proj_id)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "project_achievements_Select", 0, proj_id).Tables[0];

    }

    public static project_achievements_DT SelectByID(int ID)
    {
        try
        {
            SqlDataReader drTableName;
            project_achievements_DT obj = new project_achievements_DT();
            if (ID > 0)
            {
                drTableName = SqlHelper.ExecuteReader(Database.ConnectionString, "project_achievements_Select", ID, 0);
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
