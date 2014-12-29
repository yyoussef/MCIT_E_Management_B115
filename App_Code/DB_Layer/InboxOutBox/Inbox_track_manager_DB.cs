using System;
using System.Data.SqlClient;
using System.Data;


/// <summary>
/// Summary description for Inbox_track_manager_DB
/// </summary>
public class Inbox_track_manager_DB
{
    #region "Private methods"

    private static Inbox_track_manager_DT FillInfoObject(SqlDataReader dr)
        {

            Inbox_track_manager_DT oInbox_Inbox_track_manager_DT = new Inbox_track_manager_DT();


            oInbox_Inbox_track_manager_DT.inbox_id = dr[Inbox_track_manager_DT.EnumInfo_Inbox_track_manager.inbox_id.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Inbox_track_manager_DT.EnumInfo_Inbox_track_manager.inbox_id.ToString()]);
            oInbox_Inbox_track_manager_DT.IS_New_Mail = dr[Inbox_track_manager_DT.EnumInfo_Inbox_track_manager.IS_New_Mail.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Inbox_track_manager_DT.EnumInfo_Inbox_track_manager.IS_New_Mail.ToString()]);
            oInbox_Inbox_track_manager_DT.status = dr[Inbox_track_manager_DT.EnumInfo_Inbox_track_manager.status.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Inbox_track_manager_DT.EnumInfo_Inbox_track_manager.status.ToString()]);
            oInbox_Inbox_track_manager_DT.IS_Old_Mail = dr[Inbox_track_manager_DT.EnumInfo_Inbox_track_manager.IS_Old_Mail.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Inbox_track_manager_DT.EnumInfo_Inbox_track_manager.IS_Old_Mail.ToString()]);
            oInbox_Inbox_track_manager_DT.All_visa_sent = dr[Inbox_track_manager_DT.EnumInfo_Inbox_track_manager.All_visa_sent.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Inbox_track_manager_DT.EnumInfo_Inbox_track_manager.All_visa_sent.ToString()]);
            oInbox_Inbox_track_manager_DT.Have_Follow = dr[Inbox_track_manager_DT.EnumInfo_Inbox_track_manager.Have_Follow.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Inbox_track_manager_DT.EnumInfo_Inbox_track_manager.Have_Follow.ToString()]);
            oInbox_Inbox_track_manager_DT.Have_Visa = dr[Inbox_track_manager_DT.EnumInfo_Inbox_track_manager.Have_Visa.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Inbox_track_manager_DT.EnumInfo_Inbox_track_manager.Have_Visa.ToString()]);
            oInbox_Inbox_track_manager_DT.pmp_id = dr[Inbox_track_manager_DT.EnumInfo_Inbox_track_manager.pmp_id.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Inbox_track_manager_DT.EnumInfo_Inbox_track_manager.pmp_id.ToString()]);
            oInbox_Inbox_track_manager_DT.parent_pmp_id = dr[Inbox_track_manager_DT.EnumInfo_Inbox_track_manager.parent_pmp_id.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Inbox_track_manager_DT.EnumInfo_Inbox_track_manager.parent_pmp_id.ToString()]);
            oInbox_Inbox_track_manager_DT.Type_Track = dr[Inbox_track_manager_DT.EnumInfo_Inbox_track_manager.Type_Track.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Inbox_track_manager_DT.EnumInfo_Inbox_track_manager.Type_Track.ToString()]);
            oInbox_Inbox_track_manager_DT.Visa_Desc = dr[Inbox_track_manager_DT.EnumInfo_Inbox_track_manager.Visa_Desc.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Inbox_track_manager_DT.EnumInfo_Inbox_track_manager.Visa_Desc.ToString()]);
            return oInbox_Inbox_track_manager_DT;
        }

    private static SqlParameter[] GetParameters(Inbox_track_manager_DT obj, bool isSearch)
    {
        SqlParameter[] parms = new SqlParameter[11];


        if (!isSearch)
        {

            parms[0] = new SqlParameter(Inbox_track_manager_DT.EnumInfo_Inbox_track_manager.inbox_id.ToString(), obj.inbox_id);
            parms[0].Direction = ParameterDirection.InputOutput;

        }

        parms[1] = new SqlParameter(Inbox_track_manager_DT.EnumInfo_Inbox_track_manager.IS_New_Mail.ToString(), obj.IS_New_Mail);

        parms[2] = new SqlParameter(Inbox_track_manager_DT.EnumInfo_Inbox_track_manager.Have_Follow.ToString(), obj.Have_Follow);

        //parms[3] = new SqlParameter(Inbox_track_manager_DT.EnumInfo_Inbox_track_manager.File_data.ToString(), obj.File_data);

        parms[3] = new SqlParameter(Inbox_track_manager_DT.EnumInfo_Inbox_track_manager.Have_Visa.ToString(), obj.Have_Visa);

        parms[4] = new SqlParameter(Inbox_track_manager_DT.EnumInfo_Inbox_track_manager.Visa_Desc.ToString(), obj.Visa_Desc);

        parms[5] = new SqlParameter(Inbox_track_manager_DT.EnumInfo_Inbox_track_manager.IS_Old_Mail.ToString(), obj.IS_Old_Mail);

        parms[6] = new SqlParameter(Inbox_track_manager_DT.EnumInfo_Inbox_track_manager.pmp_id.ToString(), obj.pmp_id);

        parms[7] = new SqlParameter(Inbox_track_manager_DT.EnumInfo_Inbox_track_manager.parent_pmp_id.ToString(), obj.parent_pmp_id);

        parms[8] = new SqlParameter(Inbox_track_manager_DT.EnumInfo_Inbox_track_manager.Type_Track.ToString(), obj.Type_Track);

        parms[9] = new SqlParameter(Inbox_track_manager_DT.EnumInfo_Inbox_track_manager.All_visa_sent.ToString(), obj.All_visa_sent);

        parms[10] = new SqlParameter(Inbox_track_manager_DT.EnumInfo_Inbox_track_manager.status.ToString(), obj.status);
        //parms[4] = new SqlParameter(Inbox_track_manager_DT.EnumInfo_Inbox_track_manager.Date.ToString(), obj.Date);

        //parms[6] = new SqlParameter(Inbox_Visa_Follows_DT.EnumInfo_Inbox_track_manager.File_name.ToString(), obj.File_name);

    //    parms[7] = new SqlParameter(Inbox_Visa_Follows_DT.EnumInfo_Inbox_track_manager.File_ext.ToString(), obj.File_ext);

        return parms;
    }

    #endregion

    #region DataBase Function

    public static int Save(Inbox_track_manager_DT obj)
    {
        try
        {
            SqlParameter[] parms = GetParameters(obj, false);

            SqlHelper.ExecuteScalar(Database.ConnectionString, CommandType.StoredProcedure, "Inbox_Track_Manager_Save", parms);
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
            SqlHelper.ExecuteNonQuery(Database.ConnectionString, "Inbox_Track_Manager_Delete", ID);
            return ID;
        }
        catch (Exception ex)
        {
            return -1;
        }
    }

    public static DataTable SelectAll(int proj_proj_id)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Inbox_Track_Manager_Select", proj_proj_id).Tables[0];

    }

    public static Inbox_track_manager_DT SelectByID(int ID)
    {
        try
        {
            SqlDataReader drTableName;
            Inbox_track_manager_DT obj = new Inbox_track_manager_DT();
            if (ID > 0)
            {
                drTableName = SqlHelper.ExecuteReader(Database.ConnectionString, "Inbox_Track_Manager_Select", ID);
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
