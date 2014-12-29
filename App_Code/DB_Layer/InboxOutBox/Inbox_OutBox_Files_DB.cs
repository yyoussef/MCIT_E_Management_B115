using System;
using System.Data.SqlClient;
using System.Data;


/// <summary>
/// Summary description for Inbox_OutBox_Files_DB
/// </summary>
public static class Inbox_OutBox_Files_DB
{
    #region "Private methods"

    private static Inbox_OutBox_Files_DT FillInfoObject(SqlDataReader dr)
        {

            Inbox_OutBox_Files_DT oInbox_OutBox_Files_DT = new Inbox_OutBox_Files_DT();

           
		oInbox_OutBox_Files_DT.Inbox_OutBox_File_ID = Convert.ToInt32(dr[Inbox_OutBox_Files_DT.EnumInfo_OutBox_Files.Inbox_OutBox_File_ID.ToString()]);
		oInbox_OutBox_Files_DT.Inbox_Outbox_ID = dr[Inbox_OutBox_Files_DT.EnumInfo_OutBox_Files.Inbox_Outbox_ID.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Inbox_OutBox_Files_DT.EnumInfo_OutBox_Files.Inbox_Outbox_ID.ToString()]);
		oInbox_OutBox_Files_DT.Inbox_Or_Outbox = dr[Inbox_OutBox_Files_DT.EnumInfo_OutBox_Files.Inbox_Or_Outbox.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Inbox_OutBox_Files_DT.EnumInfo_OutBox_Files.Inbox_Or_Outbox.ToString()]);
		oInbox_OutBox_Files_DT.Original_Or_Attached = dr[Inbox_OutBox_Files_DT.EnumInfo_OutBox_Files.Original_Or_Attached.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Inbox_OutBox_Files_DT.EnumInfo_OutBox_Files.Original_Or_Attached.ToString()]);
		//oInbox_OutBox_Files_DT.File_data = dr[Inbox_OutBox_Files_DT.EnumInfo_OutBox_Files.File_data.ToString()] == DBNull.Value ? null : Convert.ToByte[](dr[Inbox_OutBox_Files_DT.EnumInfo_OutBox_Files.File_data.ToString()]);
		oInbox_OutBox_Files_DT.File_name = dr[Inbox_OutBox_Files_DT.EnumInfo_OutBox_Files.File_name.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Inbox_OutBox_Files_DT.EnumInfo_OutBox_Files.File_name.ToString()]);
		oInbox_OutBox_Files_DT.File_ext = dr[Inbox_OutBox_Files_DT.EnumInfo_OutBox_Files.File_ext.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Inbox_OutBox_Files_DT.EnumInfo_OutBox_Files.File_ext.ToString()]);

            return oInbox_OutBox_Files_DT;
        }

    private static SqlParameter[] GetParameters(Inbox_OutBox_Files_DT obj, bool isSearch)
    {
        SqlParameter[] parms = new SqlParameter[7];


        if (!isSearch)
        {

            parms[0] = new SqlParameter(Inbox_OutBox_Files_DT.EnumInfo_OutBox_Files.Inbox_OutBox_File_ID.ToString(), obj.Inbox_OutBox_File_ID);
            parms[0].Direction = ParameterDirection.InputOutput;

        }

        parms[1] = new SqlParameter(Inbox_OutBox_Files_DT.EnumInfo_OutBox_Files.Inbox_Outbox_ID.ToString(), obj.Inbox_Outbox_ID);

        parms[2] = new SqlParameter(Inbox_OutBox_Files_DT.EnumInfo_OutBox_Files.Inbox_Or_Outbox.ToString(), obj.Inbox_Or_Outbox);

        parms[3] = new SqlParameter(Inbox_OutBox_Files_DT.EnumInfo_OutBox_Files.Original_Or_Attached.ToString(), obj.Original_Or_Attached);

        parms[4] = new SqlParameter(Inbox_OutBox_Files_DT.EnumInfo_OutBox_Files.File_data.ToString(), obj.File_data);

        parms[5] = new SqlParameter(Inbox_OutBox_Files_DT.EnumInfo_OutBox_Files.File_name.ToString(), obj.File_name);

        parms[6] = new SqlParameter(Inbox_OutBox_Files_DT.EnumInfo_OutBox_Files.File_ext.ToString(), obj.File_ext);

        return parms;
    }

    #endregion


    #region DataBase Function

    public static int Save(Inbox_OutBox_Files_DT obj)
    {
        try
        {
            SqlParameter[] parms = GetParameters(obj, false);

            SqlHelper.ExecuteScalar(Database.ConnectionString, CommandType.StoredProcedure, "Inbox_OutBox_Files_Save", parms);
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
            SqlHelper.ExecuteNonQuery(Database.ConnectionString, "Inbox_OutBox_Files_Delete", ID);
            return ID;
        }
        catch (Exception ex)
        {
            return -1;
        }
    }


    public static DataTable SelectAll(int proj_proj_id)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Inbox_OutBox_Files_Select", proj_proj_id).Tables[0];

    }

    public static Inbox_OutBox_Files_DT SelectByID(int ID)
    {
        try
        {
            SqlDataReader drTableName;
            Inbox_OutBox_Files_DT obj = new Inbox_OutBox_Files_DT();
            if (ID > 0)
            {
                drTableName = SqlHelper.ExecuteReader(Database.ConnectionString, "Inbox_OutBox_Files_Select", ID);
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
