using System;
using System.Data.SqlClient;
using System.Data;


/// <summary>
/// Summary description for Inbox_Visa_Follows_DB
/// </summary>
public class Inbox_Visa_Follows_DB
{
    #region "Private methods"

    private static Inbox_Visa_Follows_DT FillInfoObject(SqlDataReader dr)
    {

        Inbox_Visa_Follows_DT oInbox_Visa_Follows_DT = new Inbox_Visa_Follows_DT();


        oInbox_Visa_Follows_DT.Follow_ID = Convert.ToInt32(dr[Inbox_Visa_Follows_DT.EnumInfo_Visa_Follows.Follow_ID.ToString()]);
        oInbox_Visa_Follows_DT.Inbox_ID = dr[Inbox_Visa_Follows_DT.EnumInfo_Visa_Follows.Inbox_ID.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Inbox_Visa_Follows_DT.EnumInfo_Visa_Follows.Inbox_ID.ToString()]);
        oInbox_Visa_Follows_DT.entery_pmp_id = dr[Inbox_Visa_Follows_DT.EnumInfo_Visa_Follows.entery_pmp_id.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Inbox_Visa_Follows_DT.EnumInfo_Visa_Follows.entery_pmp_id.ToString()]);
        oInbox_Visa_Follows_DT.Type_Follow = dr[Inbox_Visa_Follows_DT.EnumInfo_Visa_Follows.Type_Follow.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Inbox_Visa_Follows_DT.EnumInfo_Visa_Follows.Type_Follow.ToString()]);
        oInbox_Visa_Follows_DT.Visa_Emp_id = dr[Inbox_Visa_Follows_DT.EnumInfo_Visa_Follows.Visa_Emp_id.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Inbox_Visa_Follows_DT.EnumInfo_Visa_Follows.Visa_Emp_id.ToString()]);
        oInbox_Visa_Follows_DT.File_data = dr[Inbox_Visa_Follows_DT.EnumInfo_Visa_Follows.File_data.ToString()] == DBNull.Value ? null : (Byte[])(dr[Inbox_Visa_Follows_DT.EnumInfo_Visa_Follows.File_data.ToString()]);
        oInbox_Visa_Follows_DT.Descrption = dr[Inbox_Visa_Follows_DT.EnumInfo_Visa_Follows.Descrption.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Inbox_Visa_Follows_DT.EnumInfo_Visa_Follows.Descrption.ToString()]);
        oInbox_Visa_Follows_DT.Date = dr[Inbox_Visa_Follows_DT.EnumInfo_Visa_Follows.Date.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Inbox_Visa_Follows_DT.EnumInfo_Visa_Follows.Date.ToString()]);
        oInbox_Visa_Follows_DT.time_follow = dr[Inbox_Visa_Follows_DT.EnumInfo_Visa_Follows.time_follow.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Inbox_Visa_Follows_DT.EnumInfo_Visa_Follows.time_follow.ToString()]);
        oInbox_Visa_Follows_DT.File_name = dr[Inbox_Visa_Follows_DT.EnumInfo_Visa_Follows.File_name.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Inbox_Visa_Follows_DT.EnumInfo_Visa_Follows.File_name.ToString()]);
        oInbox_Visa_Follows_DT.File_ext = dr[Inbox_Visa_Follows_DT.EnumInfo_Visa_Follows.File_ext.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Inbox_Visa_Follows_DT.EnumInfo_Visa_Follows.File_ext.ToString()]);
        oInbox_Visa_Follows_DT.Entery_Date = dr[Inbox_Visa_Follows_DT.EnumInfo_Visa_Follows.Entery_Date.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Inbox_Visa_Follows_DT.EnumInfo_Visa_Follows.Entery_Date.ToString()]);

        return oInbox_Visa_Follows_DT;
    }

    private static SqlParameter[] GetParameters(Inbox_Visa_Follows_DT obj, bool isSearch)
    {
        SqlParameter[] parms = new SqlParameter[9];


        if (!isSearch)
        {

            parms[0] = new SqlParameter(Inbox_Visa_Follows_DT.EnumInfo_Visa_Follows.Follow_ID.ToString(), obj.Follow_ID);
            parms[0].Direction = ParameterDirection.InputOutput;

        }

        parms[1] = new SqlParameter(Inbox_Visa_Follows_DT.EnumInfo_Visa_Follows.Inbox_ID.ToString(), obj.Inbox_ID);

        parms[2] = new SqlParameter(Inbox_Visa_Follows_DT.EnumInfo_Visa_Follows.Visa_Emp_id.ToString(), obj.Visa_Emp_id);

        //parms[3] = new SqlParameter(Inbox_Visa_Follows_DT.EnumInfo_Visa_Follows.File_data.ToString(), obj.File_data);

        parms[3] = new SqlParameter(Inbox_Visa_Follows_DT.EnumInfo_Visa_Follows.Descrption.ToString(), obj.Descrption);

        parms[4] = new SqlParameter(Inbox_Visa_Follows_DT.EnumInfo_Visa_Follows.Date.ToString(), obj.Date);

        parms[5] = new SqlParameter(Inbox_Visa_Follows_DT.EnumInfo_Visa_Follows.time_follow.ToString(), obj.time_follow);

        parms[6] = new SqlParameter(Inbox_Visa_Follows_DT.EnumInfo_Visa_Follows.entery_pmp_id.ToString(), obj.entery_pmp_id);

        parms[7] = new SqlParameter(Inbox_Visa_Follows_DT.EnumInfo_Visa_Follows.Type_Follow.ToString(), obj.Type_Follow);

        parms[8] = new SqlParameter(Inbox_Visa_Follows_DT.EnumInfo_Visa_Follows.Entery_Date.ToString(), obj.Entery_Date);

        //parms[6] = new SqlParameter(Inbox_Visa_Follows_DT.EnumInfo_Visa_Follows.File_name.ToString(), obj.File_name);

        //    parms[7] = new SqlParameter(Inbox_Visa_Follows_DT.EnumInfo_Visa_Follows.File_ext.ToString(), obj.File_ext);

        return parms;
    }

    #endregion

    #region DataBase Function

    public static int Save(Inbox_Visa_Follows_DT obj)
    {
        try
        {
            SqlParameter[] parms = GetParameters(obj, false);

            SqlHelper.ExecuteScalar(Database.ConnectionString, CommandType.StoredProcedure, "Inbox_Visa_Follows_Save", parms);
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
            SqlHelper.ExecuteNonQuery(Database.ConnectionString, "Inbox_Visa_Follows_Delete", ID);
            return ID;
        }
        catch (Exception ex)
        {
            return -1;
        }
    }

    public static DataTable SelectAll(int proj_proj_id)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Inbox_Visa_Follows_Select", proj_proj_id).Tables[0];

    }

    public static Inbox_Visa_Follows_DT SelectByID(int ID)
    {
        try
        {
            SqlDataReader drTableName;
            Inbox_Visa_Follows_DT obj = new Inbox_Visa_Follows_DT();
            if (ID > 0)
            {
                drTableName = SqlHelper.ExecuteReader(Database.ConnectionString, "Inbox_Visa_Follows_Select", ID);
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

            return new Inbox_Visa_Follows_DT();
        }

    }

    #endregion
}
