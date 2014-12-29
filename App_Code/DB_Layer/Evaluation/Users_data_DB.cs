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
/// Summary description for Users_data_DB
/// </summary>
public class Users_data_DB
{
    private static Users_data_DT FillInfoObject(SqlDataReader  dr)
    {
        Users_data_DT uinfo = new Users_data_DT();
        uinfo.USR_ID = Convert.ToInt32(dr[Users_data_DT.enuminfo_users_data.USR_ID .ToString()]);
        uinfo.USR_Name  = dr[Users_data_DT.enuminfo_users_data.USR_Name .ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Users_data_DT.enuminfo_users_data.USR_Name .ToString()]);
        uinfo.USR_Pass  = dr[Users_data_DT.enuminfo_users_data.USR_Pass .ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Users_data_DT.enuminfo_users_data.USR_Pass .ToString()]);
       uinfo.pmp_pmp_id  = dr[Users_data_DT.enuminfo_users_data.pmp_pmp_id .ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Users_data_DT.enuminfo_users_data.pmp_pmp_id.ToString()]);
      uinfo.UROL_UROL_ID   = dr[Users_data_DT.enuminfo_users_data.UROL_UROL_ID .ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Users_data_DT.enuminfo_users_data.UROL_UROL_ID .ToString()]);
       uinfo.System_ID  = dr[Users_data_DT.enuminfo_users_data.System_ID .ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Users_data_DT.enuminfo_users_data.System_ID .ToString()]);
       uinfo.account_active = Convert.ToBoolean(dr[Users_data_DT.enuminfo_users_data.account_active.ToString()]);
       return uinfo;

    }

    private static SqlParameter[] GetParameters(Users_data_DT uobj, bool isSearch)
    {
        SqlParameter[] parms = new SqlParameter[7];


        if (!isSearch)
        {

            parms[0] = new SqlParameter(Users_data_DT.enuminfo_users_data.USR_ID.ToString(), uobj .USR_ID);
            parms[0].Direction = ParameterDirection.InputOutput;
        }
        parms[1] = new SqlParameter(Users_data_DT.enuminfo_users_data.USR_Name .ToString(), uobj.USR_Name );
        parms[2] = new SqlParameter(Users_data_DT.enuminfo_users_data.USR_Pass .ToString(), uobj .USR_Pass );
        parms[3] = new SqlParameter(Users_data_DT.enuminfo_users_data.pmp_pmp_id .ToString(), uobj.pmp_pmp_id);
        parms[4] = new SqlParameter(Users_data_DT.enuminfo_users_data.UROL_UROL_ID .ToString(), uobj.UROL_UROL_ID );
        parms[5] = new SqlParameter(Users_data_DT.enuminfo_users_data.System_ID .ToString(), uobj.System_ID );
        parms[6] = new SqlParameter(Users_data_DT.enuminfo_users_data.account_active.ToString(), uobj.account_active);
        return parms;

    }
    public static int Save(Users_data_DT  uobj)
    {
        try
        {
            SqlParameter[] parms = GetParameters(uobj, false);

            SqlHelper.ExecuteScalar(Database.ConnectionString, CommandType.StoredProcedure, "users_save", parms);
            return Convert.ToInt32(parms[0].Value);
        }
        catch (SqlException ex)
        {
            return -1;
        }
    }


    public static DataTable Select_UsersData(int pmp_pmp_id,string user_name)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Users_DataSelect", pmp_pmp_id,user_name ).Tables[0];

    }


    public static DataTable UsersDataSelect(int pmp_pmp_id)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "UsersDataSelect", pmp_pmp_id).Tables[0];

    }

}
