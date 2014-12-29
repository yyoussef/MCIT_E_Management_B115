using System;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for Inbox_DB
/// </summary>
public static class Inbox_Minister_DB
{
    #region "Private methods"

    private static Inbox_Minister_DT FillInfoObject(SqlDataReader dr)
    {

        Inbox_Minister_DT oInbox_DT = new Inbox_Minister_DT();


        oInbox_DT.ID = Convert.ToInt32(dr[Inbox_Minister_DT.EnumInfo_Inbox_Minister.ID.ToString()]);
        oInbox_DT.Proj_id = dr[Inbox_Minister_DT.EnumInfo_Inbox_Minister.Proj_id.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Inbox_Minister_DT.EnumInfo_Inbox_Minister.Proj_id.ToString()]);
        oInbox_DT.Type = dr[Inbox_Minister_DT.EnumInfo_Inbox_Minister.Type.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Inbox_Minister_DT.EnumInfo_Inbox_Minister.Type.ToString()]);
        oInbox_DT.Dept_ID = dr[Inbox_Minister_DT.EnumInfo_Inbox_Minister.Dept_ID.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Inbox_Minister_DT.EnumInfo_Inbox_Minister.Dept_ID.ToString()]);
        oInbox_DT.Emp_ID = dr[Inbox_Minister_DT.EnumInfo_Inbox_Minister.Emp_ID.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Inbox_Minister_DT.EnumInfo_Inbox_Minister.Emp_ID.ToString()]);
        oInbox_DT.Source_Type = dr[Inbox_Minister_DT.EnumInfo_Inbox_Minister.Source_Type.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Inbox_Minister_DT.EnumInfo_Inbox_Minister.Source_Type.ToString()]);
        oInbox_DT.Org_Id = dr[Inbox_Minister_DT.EnumInfo_Inbox_Minister.Org_Id.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Inbox_Minister_DT.EnumInfo_Inbox_Minister.Org_Id.ToString()]);
        oInbox_DT.Related_Type = dr[Inbox_Minister_DT.EnumInfo_Inbox_Minister.Related_Type.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Inbox_Minister_DT.EnumInfo_Inbox_Minister.Related_Type.ToString()]);
        oInbox_DT.Related_Id = dr[Inbox_Minister_DT.EnumInfo_Inbox_Minister.Related_Id.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Inbox_Minister_DT.EnumInfo_Inbox_Minister.Related_Id.ToString()]);
        oInbox_DT.Follow_Up_Dept_ID = dr[Inbox_Minister_DT.EnumInfo_Inbox_Minister.Follow_Up_Dept_ID.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Inbox_Minister_DT.EnumInfo_Inbox_Minister.Follow_Up_Dept_ID.ToString()]);
        oInbox_DT.Follow_Up_Emp_ID = dr[Inbox_Minister_DT.EnumInfo_Inbox_Minister.Follow_Up_Emp_ID.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Inbox_Minister_DT.EnumInfo_Inbox_Minister.Follow_Up_Emp_ID.ToString()]);
        oInbox_DT.Status = dr[Inbox_Minister_DT.EnumInfo_Inbox_Minister.Status.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Inbox_Minister_DT.EnumInfo_Inbox_Minister.Status.ToString()]);
        oInbox_DT.Subject = dr[Inbox_Minister_DT.EnumInfo_Inbox_Minister.Subject.ToString()] == DBNull.Value ? null : Convert.ToString(dr[Inbox_Minister_DT.EnumInfo_Inbox_Minister.Subject.ToString()]);
        oInbox_DT.Notes = dr[Inbox_Minister_DT.EnumInfo_Inbox_Minister.Notes.ToString()] == DBNull.Value ? null : Convert.ToString(dr[Inbox_Minister_DT.EnumInfo_Inbox_Minister.Notes.ToString()]);
        oInbox_DT.Name = dr[Inbox_Minister_DT.EnumInfo_Inbox_Minister.Name.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Inbox_Minister_DT.EnumInfo_Inbox_Minister.Name.ToString()]);
        oInbox_DT.Code = dr[Inbox_Minister_DT.EnumInfo_Inbox_Minister.Code.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Inbox_Minister_DT.EnumInfo_Inbox_Minister.Code.ToString()]);
        oInbox_DT.Date = dr[Inbox_Minister_DT.EnumInfo_Inbox_Minister.Date.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Inbox_Minister_DT.EnumInfo_Inbox_Minister.Date.ToString()]);
        oInbox_DT.Org_Name = dr[Inbox_Minister_DT.EnumInfo_Inbox_Minister.Org_Name.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Inbox_Minister_DT.EnumInfo_Inbox_Minister.Org_Name.ToString()]);
        oInbox_DT.Org_Out_Box_Code = dr[Inbox_Minister_DT.EnumInfo_Inbox_Minister.Org_Out_Box_Code.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Inbox_Minister_DT.EnumInfo_Inbox_Minister.Org_Out_Box_Code.ToString()]);
        oInbox_DT.Org_Out_Box_DT = dr[Inbox_Minister_DT.EnumInfo_Inbox_Minister.Org_Out_Box_DT.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Inbox_Minister_DT.EnumInfo_Inbox_Minister.Org_Out_Box_DT.ToString()]);
        oInbox_DT.Paper_No = dr[Inbox_Minister_DT.EnumInfo_Inbox_Minister.Paper_No.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Inbox_Minister_DT.EnumInfo_Inbox_Minister.Paper_No.ToString()]);
        oInbox_DT.Paper_Attached = dr[Inbox_Minister_DT.EnumInfo_Inbox_Minister.Paper_Attached.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Inbox_Minister_DT.EnumInfo_Inbox_Minister.Paper_Attached.ToString()]);
        oInbox_DT.Dept_Desc = dr[Inbox_Minister_DT.EnumInfo_Inbox_Minister.Dept_Desc.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Inbox_Minister_DT.EnumInfo_Inbox_Minister.Dept_Desc.ToString()]);
        oInbox_DT.Org_Out_Box_Person = dr[Inbox_Minister_DT.EnumInfo_Inbox_Minister.Org_Out_Box_Person.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Inbox_Minister_DT.EnumInfo_Inbox_Minister.Org_Out_Box_Person.ToString()]);
        oInbox_DT.Org_Dept_Name = dr[Inbox_Minister_DT.EnumInfo_Inbox_Minister.Org_Dept_Name.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Inbox_Minister_DT.EnumInfo_Inbox_Minister.Org_Dept_Name.ToString()]);
        oInbox_DT.sub_Cat_id = dr[Inbox_Minister_DT.EnumInfo_Inbox_Minister.sub_Cat_id.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Inbox_Minister_DT.EnumInfo_Inbox_Minister.sub_Cat_id.ToString()]);

        return oInbox_DT;
    }

    private static SqlParameter[] GetParameters(Inbox_Minister_DT obj, bool isSearch)
    {
        SqlParameter[] parms = new SqlParameter[30];


        if (!isSearch)
        {

            parms[0] = new SqlParameter(Inbox_Minister_DT.EnumInfo_Inbox_Minister.ID.ToString(), obj.ID);
            parms[0].Direction = ParameterDirection.InputOutput;

        }

        parms[1] = new SqlParameter(Inbox_Minister_DT.EnumInfo_Inbox_Minister.Proj_id.ToString(), obj.Proj_id);

        parms[2] = new SqlParameter(Inbox_Minister_DT.EnumInfo_Inbox_Minister.Type.ToString(), obj.Type);

        parms[3] = new SqlParameter(Inbox_Minister_DT.EnumInfo_Inbox_Minister.Dept_ID.ToString(), obj.Dept_ID);

        parms[4] = new SqlParameter(Inbox_Minister_DT.EnumInfo_Inbox_Minister.Emp_ID.ToString(), obj.Emp_ID);

        parms[5] = new SqlParameter(Inbox_Minister_DT.EnumInfo_Inbox_Minister.Org_Id.ToString(), obj.Org_Id);

        parms[6] = new SqlParameter(Inbox_Minister_DT.EnumInfo_Inbox_Minister.Related_Type.ToString(), obj.Related_Type);

        parms[7] = new SqlParameter(Inbox_Minister_DT.EnumInfo_Inbox_Minister.Related_Id.ToString(), obj.Related_Id);

        parms[8] = new SqlParameter(Inbox_Minister_DT.EnumInfo_Inbox_Minister.Follow_Up_Dept_ID.ToString(), obj.Follow_Up_Dept_ID);

        parms[9] = new SqlParameter(Inbox_Minister_DT.EnumInfo_Inbox_Minister.Follow_Up_Emp_ID.ToString(), obj.Follow_Up_Emp_ID);

        parms[10] = new SqlParameter(Inbox_Minister_DT.EnumInfo_Inbox_Minister.Status.ToString(), obj.Status);

        parms[11] = new SqlParameter(Inbox_Minister_DT.EnumInfo_Inbox_Minister.Subject.ToString(), obj.Subject);

        parms[12] = new SqlParameter(Inbox_Minister_DT.EnumInfo_Inbox_Minister.Notes.ToString(), obj.Notes);

        parms[13] = new SqlParameter(Inbox_Minister_DT.EnumInfo_Inbox_Minister.Name.ToString(), obj.Name);

        parms[14] = new SqlParameter(Inbox_Minister_DT.EnumInfo_Inbox_Minister.Code.ToString(), obj.Code);

        parms[15] = new SqlParameter(Inbox_Minister_DT.EnumInfo_Inbox_Minister.Date.ToString(), obj.Date);

        parms[16] = new SqlParameter(Inbox_Minister_DT.EnumInfo_Inbox_Minister.Org_Name.ToString(), obj.Org_Name);

        parms[17] = new SqlParameter(Inbox_Minister_DT.EnumInfo_Inbox_Minister.Org_Out_Box_Code.ToString(), obj.Org_Out_Box_Code);

        parms[18] = new SqlParameter(Inbox_Minister_DT.EnumInfo_Inbox_Minister.Org_Out_Box_DT.ToString(), obj.Org_Out_Box_DT);

        parms[19] = new SqlParameter(Inbox_Minister_DT.EnumInfo_Inbox_Minister.Paper_No.ToString(), obj.Paper_No);

        parms[20] = new SqlParameter(Inbox_Minister_DT.EnumInfo_Inbox_Minister.Paper_Attached.ToString(), obj.Paper_Attached);

        parms[21] = new SqlParameter(Inbox_Minister_DT.EnumInfo_Inbox_Minister.Dept_Desc.ToString(), obj.Dept_Desc);

        parms[22] = new SqlParameter(Inbox_Minister_DT.EnumInfo_Inbox_Minister.Source_Type.ToString(), obj.Source_Type);

        parms[23] = new SqlParameter(Inbox_Minister_DT.EnumInfo_Inbox_Minister.Org_Out_Box_Person.ToString(), obj.Org_Out_Box_Person);

        parms[24] = new SqlParameter(Inbox_Minister_DT.EnumInfo_Inbox_Minister.Org_Dept_Name.ToString(), obj.Org_Dept_Name);

        parms[25] = new SqlParameter(Inbox_Minister_DT.EnumInfo_Inbox_Minister.Enter_Date.ToString(), obj.Enter_Date);

        parms[26] = new SqlParameter(Inbox_Minister_DT.EnumInfo_Inbox_Minister.Dept_Dept_id.ToString(), obj.Dept_Dept_id);

        parms[27] = new SqlParameter(Inbox_Minister_DT.EnumInfo_Inbox_Minister.Group_id.ToString(), obj.Group_id);

        parms[28] = new SqlParameter(Inbox_Minister_DT.EnumInfo_Inbox_Minister.pmp_pmp_id.ToString(), obj.pmp_pmp_id);

        parms[29] = new SqlParameter(Inbox_Minister_DT.EnumInfo_Inbox_Minister.sub_Cat_id.ToString(), obj.sub_Cat_id); 

        return parms;
    }

    #endregion

    #region DataBase Function

    public static int Save(Inbox_Minister_DT obj)
    {
        try
        {
            SqlParameter[] parms = GetParameters(obj, false);

            SqlHelper.ExecuteScalar(Database.ConnectionString, CommandType.StoredProcedure, "Inbox_Minister_Save", parms);
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
            SqlHelper.ExecuteNonQuery(Database.ConnectionString, "Inbox_Minister_Delete", ID);
            return ID;
        }
        catch (Exception ex)
        {
            return -1;
        }
    }

    public static DataTable SelectAll(int proj_proj_id)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Inbox_Minister_Select", proj_proj_id).Tables[0];

    }

    public static Inbox_Minister_DT SelectByID(int ID)
    {
        try
        {
            SqlDataReader drTableName;
            Inbox_Minister_DT obj = new Inbox_Minister_DT();
            if (ID > 0)
            {
                drTableName = SqlHelper.ExecuteReader(Database.ConnectionString, "Inbox_Minister_Select", ID);
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
    public static void update_inbox_Track_Emp(string inbox_id, string Emp_ID, int Inbox_Status, int Type)
    {
        DataTable DT = General_Helping.GetDataTable("select * from Inbox_Track_Emp where inbox_id = " + inbox_id + " and Emp_ID =" + Emp_ID);
        if (DT.Rows.Count > 0)
        {

            string sql = "update Inbox_Track_Emp set Inbox_Status= " + Inbox_Status + " where inbox_id =" + inbox_id + " and Emp_ID =" + Emp_ID;
            General_Helping.ExcuteQuery(sql);
        }
        else
        {
            string sql = "insert into Inbox_Track_Emp (inbox_id,Emp_ID,Inbox_Status,Type_Track_emp) values ( " + inbox_id + "," + Emp_ID + "," + Inbox_Status + "," + "3" + ")";
            General_Helping.ExcuteQuery(sql);
        }

    }

    #endregion

}
