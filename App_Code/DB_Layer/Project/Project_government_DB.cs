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
/// Summary description for Project_government_DB
/// </summary>
public class Project_government_DB
{
    public static Project_governments_DT FillInfoObject(SqlDataReader dr)
    {
        Project_governments_DT opgov = new Project_governments_DT();
        opgov.proj_gov_id = dr[Project_governments_DT.projectgov_eunm.proj_gov_id.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Project_governments_DT.projectgov_eunm.proj_gov_id.ToString()]);
        opgov.Proj_id   = dr[Project_governments_DT.projectgov_eunm.Proj_id .ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Project_governments_DT.projectgov_eunm.Proj_id .ToString()]);
        opgov.gov_id  = dr[Project_governments_DT.projectgov_eunm.gov_id .ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Project_governments_DT.projectgov_eunm.gov_id .ToString()]);
        opgov.gov_notes = dr[Project_governments_DT .projectgov_eunm.gov_notes .ToString()] == DBNull.Value ? null : Convert.ToString(dr[Project_governments_DT.projectgov_eunm.gov_notes .ToString()]);

        return opgov;

    }
    private static SqlParameter[] GetParameters(Project_governments_DT obj, bool isSearch)
    {
         SqlParameter[] parms = new SqlParameter[4];
         if (!isSearch)
         {
             parms[0] = new SqlParameter(Project_governments_DT.projectgov_eunm.proj_gov_id.ToString(), obj.proj_gov_id);
             parms[0].Direction = ParameterDirection.InputOutput;

         }
         parms[1] = new SqlParameter(Project_governments_DT.projectgov_eunm.Proj_id .ToString(), obj.Proj_id );
         parms[2] = new SqlParameter(Project_governments_DT.projectgov_eunm.gov_id .ToString(), obj.gov_id );
         parms[3] = new SqlParameter(Project_governments_DT.projectgov_eunm.gov_notes .ToString(), obj.gov_notes );

         return parms;


    }

    public static int save(Project_governments_DT obj)
    {
        try
        {
            SqlParameter[] parms = GetParameters(obj, false);
            SqlHelper.ExecuteScalar(Database.ConnectionString, CommandType.StoredProcedure, "Project_gov_save", parms);
            return Convert.ToInt32(parms[0].Value);
        }
        catch (SqlException ex)
        {

            return -1;
        }
    }
    public static int Delete(int proj_id)
    {
        try
        {
            SqlHelper.ExecuteNonQuery(Database.ConnectionString, "project_gov_delete", proj_id);
            return proj_id ;
        }
        catch (Exception ex)
        {
            return -1;
        }
    }
    public static DataTable Select_data(int proj)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "select_geo",proj ).Tables[0];

    }
	
}
