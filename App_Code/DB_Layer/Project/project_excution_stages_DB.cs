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
using System.Data.SqlClient;

/// <summary>
/// Summary description for project_excution_stages_DB
/// </summary>
public class project_excution_stages_DB
{
    private static project_excution_stages_DT FillInfoObject(SqlDataReader dr)
    {
        project_excution_stages_DT oproject_excution_stages_DT = new project_excution_stages_DT();
        oproject_excution_stages_DT.id=dr[project_excution_stages_DT.EnumInfo_project_excution_stages .id.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[project_excution_stages_DT.EnumInfo_project_excution_stages .id.ToString()]);
        oproject_excution_stages_DT.proj_stage=dr[project_excution_stages_DT .EnumInfo_project_excution_stages.proj_stage .ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[project_excution_stages_DT.EnumInfo_project_excution_stages.proj_stage .ToString()]);
        oproject_excution_stages_DT.proj_stage_output=dr[project_excution_stages_DT .EnumInfo_project_excution_stages.proj_stage_output.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[project_excution_stages_DT.EnumInfo_project_excution_stages.proj_stage_output  .ToString()]);
        oproject_excution_stages_DT.proj_id = dr[project_excution_stages_DT.EnumInfo_project_excution_stages.proj_id .ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[project_excution_stages_DT.EnumInfo_project_excution_stages.proj_id .ToString()]);
        return oproject_excution_stages_DT;
    }

    private static SqlParameter[] GetParameters(project_excution_stages_DT  obj, bool isSearch)
    {
        SqlParameter[] parms = new SqlParameter[4];

        if (!isSearch)
        {

            parms[0] = new SqlParameter(project_excution_stages_DT.EnumInfo_project_excution_stages.id.ToString(), obj.id);
            parms[0].Direction = ParameterDirection.InputOutput;

        }

        //parms[0] = new SqlParameter(Project_Attitude_DT.EnumInfo_Project_Attitude.id.ToString(),obj.id );
        parms[1] = new SqlParameter(project_excution_stages_DT.EnumInfo_project_excution_stages.proj_stage.ToString(), obj.proj_stage );
        parms[2] = new SqlParameter(project_excution_stages_DT.EnumInfo_project_excution_stages.proj_stage_output.ToString(), obj.proj_stage_output );
        parms[3] = new SqlParameter(project_excution_stages_DT.EnumInfo_project_excution_stages.proj_id .ToString(),obj.proj_id );

        return parms;

    }

    public static int Save(project_excution_stages_DT  obj)
    {
        try
        {
            SqlParameter[] parms = GetParameters(obj, false);

            SqlHelper.ExecuteScalar(Database.ConnectionString, CommandType.StoredProcedure, "project_excution_stages_save", parms);
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
            SqlHelper.ExecuteNonQuery(Database.ConnectionString, "project_excution_stages_delete", ID);
            return ID;
        }
        catch (Exception ex)
        {
            return -1;
        }
    }

    public static DataTable SelectAll(int proj_id)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "project_excution_stages_select", proj_id, 0).Tables[0];

    }

    public static project_excution_stages_DT  SelectByID(int ID)
    {
        try
        {
            SqlDataReader drTableName;
            project_excution_stages_DT  obj = new project_excution_stages_DT();
            if (ID > 0)
            {
                drTableName = SqlHelper.ExecuteReader(Database.ConnectionString, "project_excution_stages_select", 0, ID);
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
