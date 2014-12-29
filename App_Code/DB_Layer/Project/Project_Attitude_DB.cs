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
/// Summary description for Project_Attitude_DB
/// </summary>
public class Project_Attitude_DB
{
    private static Project_Attitude_DT FillInfoObject(SqlDataReader dr)
    {
        Project_Attitude_DT oproject_attitude_dt = new Project_Attitude_DT();

        oproject_attitude_dt.id = dr[Project_Attitude_DT.EnumInfo_Project_Attitude.id.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Project_Attitude_DT.EnumInfo_Project_Attitude.id.ToString()]);
        oproject_attitude_dt.last_attitude_date = dr[Project_Attitude_DT.EnumInfo_Project_Attitude.last_attitude_date .ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Project_Attitude_DT.EnumInfo_Project_Attitude.last_attitude_date.ToString()]);
        oproject_attitude_dt.last_attitude_desc =dr[Project_Attitude_DT.EnumInfo_Project_Attitude.last_attitude_desc.ToString()]==DBNull.Value ?string.Empty :Convert.ToString (dr[Project_Attitude_DT.EnumInfo_Project_Attitude.last_attitude_desc .ToString()]);
        oproject_attitude_dt.Proj_id = Convert.ToInt32(dr[Project_Attitude_DT.EnumInfo_Project_Attitude.Proj_id.ToString()]);
        return oproject_attitude_dt;
    }
    private static SqlParameter[] GetParameters(Project_Attitude_DT obj, bool isSearch)
    {
        SqlParameter[] parms = new SqlParameter[4];

        if (!isSearch)
        {

            parms[0] = new SqlParameter(Project_Attitude_DT.EnumInfo_Project_Attitude.id.ToString(),obj.id );
            parms[0].Direction = ParameterDirection.InputOutput;

        }

        //parms[0] = new SqlParameter(Project_Attitude_DT.EnumInfo_Project_Attitude.id.ToString(),obj.id );
        parms[1] = new SqlParameter(Project_Attitude_DT.EnumInfo_Project_Attitude.last_attitude_desc .ToString(), obj.last_attitude_desc );
        parms[2] = new SqlParameter(Project_Attitude_DT.EnumInfo_Project_Attitude.last_attitude_date .ToString(), obj.last_attitude_date );
        parms[3] = new SqlParameter(Project_Attitude_DT.EnumInfo_Project_Attitude.Proj_id .ToString(), obj.Proj_id );
        
        return parms;

    }

    public static int Save(Project_Attitude_DT  obj)
    {
        try
        {
            SqlParameter[] parms = GetParameters(obj, false);

            SqlHelper.ExecuteScalar(Database.ConnectionString, CommandType.StoredProcedure, "project_attitude_save", parms);
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
            SqlHelper.ExecuteNonQuery(Database.ConnectionString, "project_attitude_delete", ID);
            return ID;
        }
        catch (Exception ex)
        {
            return -1;
        }
    }

    public static DataTable SelectAll(int proj_id)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "project_attitude_select", proj_id,0).Tables[0];

    }

    public static Project_Attitude_DT  SelectByID(int ID)
    {
        try
        {
            SqlDataReader drTableName;
            Project_Attitude_DT  obj = new Project_Attitude_DT ();
            if (ID > 0)
            {
                drTableName = SqlHelper.ExecuteReader(Database.ConnectionString, "project_attitude_select", 0, ID);
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
