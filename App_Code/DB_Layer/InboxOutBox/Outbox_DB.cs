using System;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for Outbox_DB
/// </summary>
public static class Outbox_DB
{
    #region "Private methods"

    private static Outbox_DT FillInfoObject(SqlDataReader dr)
    {

        Outbox_DT oOutbox_DT = new Outbox_DT();


        oOutbox_DT.ID = Convert.ToInt32(dr[Outbox_DT.EnumInfo_Outbox.ID.ToString()]);
        oOutbox_DT.Proj_id = dr[Outbox_DT.EnumInfo_Outbox.Proj_id.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Outbox_DT.EnumInfo_Outbox.Proj_id.ToString()]);

        oOutbox_DT.Type = dr[Outbox_DT.EnumInfo_Outbox.Type.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Outbox_DT.EnumInfo_Outbox.Type.ToString()]);
        oOutbox_DT.Dept_ID = dr[Outbox_DT.EnumInfo_Outbox.Dept_ID.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Outbox_DT.EnumInfo_Outbox.Dept_ID.ToString()]);
        oOutbox_DT.Emp_ID = dr[Outbox_DT.EnumInfo_Outbox.Emp_ID.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Outbox_DT.EnumInfo_Outbox.Emp_ID.ToString()]);
        oOutbox_DT.Source_Type = dr[Outbox_DT.EnumInfo_Outbox.Source_Type.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Outbox_DT.EnumInfo_Outbox.Source_Type.ToString()]);
        oOutbox_DT.Org_Id = dr[Outbox_DT.EnumInfo_Outbox.Org_Id.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Outbox_DT.EnumInfo_Outbox.Org_Id.ToString()]);
       // oOutbox_DT.Related_link_type = dr[Outbox_DT.EnumInfo_Outbox.Related_link_type.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Outbox_DT.EnumInfo_Outbox.Related_link_type.ToString()]);
        oOutbox_DT.Related_Type = dr[Outbox_DT.EnumInfo_Outbox.Related_Type.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Outbox_DT.EnumInfo_Outbox.Related_Type.ToString()]);
        oOutbox_DT.Related_Id = dr[Outbox_DT.EnumInfo_Outbox.Related_Id.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Outbox_DT.EnumInfo_Outbox.Related_Id.ToString()]);
        oOutbox_DT.Follow_Up_Dept_ID = dr[Outbox_DT.EnumInfo_Outbox.Follow_Up_Dept_ID.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Outbox_DT.EnumInfo_Outbox.Follow_Up_Dept_ID.ToString()]);
        oOutbox_DT.Follow_Up_Emp_ID = dr[Outbox_DT.EnumInfo_Outbox.Follow_Up_Emp_ID.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Outbox_DT.EnumInfo_Outbox.Follow_Up_Emp_ID.ToString()]);
        oOutbox_DT.Status = dr[Outbox_DT.EnumInfo_Outbox.Status.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Outbox_DT.EnumInfo_Outbox.Status.ToString()]);
        oOutbox_DT.Subject = dr[Outbox_DT.EnumInfo_Outbox.Subject.ToString()] == DBNull.Value ? null : Convert.ToString(dr[Outbox_DT.EnumInfo_Outbox.Subject.ToString()]);
        oOutbox_DT.Notes = dr[Outbox_DT.EnumInfo_Outbox.Notes.ToString()] == DBNull.Value ? null : Convert.ToString(dr[Outbox_DT.EnumInfo_Outbox.Notes.ToString()]);
        oOutbox_DT.Name = dr[Outbox_DT.EnumInfo_Outbox.Name.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Outbox_DT.EnumInfo_Outbox.Name.ToString()]);
        oOutbox_DT.Code = dr[Outbox_DT.EnumInfo_Outbox.Code.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Outbox_DT.EnumInfo_Outbox.Code.ToString()]);
        oOutbox_DT.Date = dr[Outbox_DT.EnumInfo_Outbox.Date.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Outbox_DT.EnumInfo_Outbox.Date.ToString()]);
        oOutbox_DT.Org_Name = dr[Outbox_DT.EnumInfo_Outbox.Org_Name.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Outbox_DT.EnumInfo_Outbox.Org_Name.ToString()]);
        oOutbox_DT.Org_Out_Box_Code = dr[Outbox_DT.EnumInfo_Outbox.Org_Out_Box_Code.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Outbox_DT.EnumInfo_Outbox.Org_Out_Box_Code.ToString()]);
        oOutbox_DT.Org_Out_Box_DT = dr[Outbox_DT.EnumInfo_Outbox.Org_Out_Box_DT.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Outbox_DT.EnumInfo_Outbox.Org_Out_Box_DT.ToString()]);
        oOutbox_DT.Paper_No = dr[Outbox_DT.EnumInfo_Outbox.Paper_No.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Outbox_DT.EnumInfo_Outbox.Paper_No.ToString()]);
        oOutbox_DT.Paper_Attached = dr[Outbox_DT.EnumInfo_Outbox.Paper_Attached.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Outbox_DT.EnumInfo_Outbox.Paper_Attached.ToString()]);
        oOutbox_DT.Dept_Desc = dr[Outbox_DT.EnumInfo_Outbox.Dept_Desc.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Outbox_DT.EnumInfo_Outbox.Dept_Desc.ToString()]);
        oOutbox_DT.Org_Out_Box_Person = dr[Outbox_DT.EnumInfo_Outbox.Org_Out_Box_Person.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Outbox_DT.EnumInfo_Outbox.Org_Out_Box_Person.ToString()]);
        oOutbox_DT.Org_Dept_Name = dr[Outbox_DT.EnumInfo_Outbox.Org_Dept_Name.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Outbox_DT.EnumInfo_Outbox.Org_Dept_Name.ToString()]);
        oOutbox_DT.finished = dr[Outbox_DT.EnumInfo_Outbox.finished.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Outbox_DT.EnumInfo_Outbox.finished.ToString()]);
        oOutbox_DT.sub_Cat_id = dr[Outbox_DT.EnumInfo_Outbox.sub_Cat_id.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Outbox_DT.EnumInfo_Outbox.sub_Cat_id.ToString()]);
        oOutbox_DT.foundation_id = dr[Outbox_DT.EnumInfo_Outbox.foundation_id.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Outbox_DT.EnumInfo_Outbox.foundation_id.ToString()]);


        return oOutbox_DT;
    }

    private static SqlParameter[] GetParameters(Outbox_DT obj, bool isSearch)
    {
        SqlParameter[] parms = new SqlParameter[32];


        if (!isSearch)
        {

            parms[0] = new SqlParameter(Outbox_DT.EnumInfo_Outbox.ID.ToString(), obj.ID);
            parms[0].Direction = ParameterDirection.InputOutput;

        }

        parms[1] = new SqlParameter(Outbox_DT.EnumInfo_Outbox.Proj_id.ToString(), obj.Proj_id);

        parms[2] = new SqlParameter(Outbox_DT.EnumInfo_Outbox.Type.ToString(), obj.Type);

        parms[3] = new SqlParameter(Outbox_DT.EnumInfo_Outbox.Dept_ID.ToString(), obj.Dept_ID);

        parms[4] = new SqlParameter(Outbox_DT.EnumInfo_Outbox.Emp_ID.ToString(), obj.Emp_ID);

        parms[5] = new SqlParameter(Outbox_DT.EnumInfo_Outbox.Org_Id.ToString(), obj.Org_Id);

        parms[6] = new SqlParameter(Outbox_DT.EnumInfo_Outbox.Related_Type.ToString(), obj.Related_Type);

        parms[7] = new SqlParameter(Outbox_DT.EnumInfo_Outbox.Related_Id.ToString(), obj.Related_Id);

        parms[8] = new SqlParameter(Outbox_DT.EnumInfo_Outbox.Follow_Up_Dept_ID.ToString(), obj.Follow_Up_Dept_ID);

        parms[9] = new SqlParameter(Outbox_DT.EnumInfo_Outbox.Follow_Up_Emp_ID.ToString(), obj.Follow_Up_Emp_ID);

        parms[10] = new SqlParameter(Outbox_DT.EnumInfo_Outbox.Status.ToString(), obj.Status);

        parms[11] = new SqlParameter(Outbox_DT.EnumInfo_Outbox.Subject.ToString(), obj.Subject);

        parms[12] = new SqlParameter(Outbox_DT.EnumInfo_Outbox.Notes.ToString(), obj.Notes);

        parms[13] = new SqlParameter(Outbox_DT.EnumInfo_Outbox.Name.ToString(), obj.Name);

        parms[14] = new SqlParameter(Outbox_DT.EnumInfo_Outbox.Code.ToString(), obj.Code);

        parms[15] = new SqlParameter(Outbox_DT.EnumInfo_Outbox.Date.ToString(), obj.Date);

        parms[16] = new SqlParameter(Outbox_DT.EnumInfo_Outbox.Org_Name.ToString(), obj.Org_Name);

        parms[17] = new SqlParameter(Outbox_DT.EnumInfo_Outbox.Org_Out_Box_Code.ToString(), obj.Org_Out_Box_Code);

        parms[18] = new SqlParameter(Outbox_DT.EnumInfo_Outbox.Org_Out_Box_DT.ToString(), obj.Org_Out_Box_DT);

        parms[19] = new SqlParameter(Outbox_DT.EnumInfo_Outbox.Paper_No.ToString(), obj.Paper_No);

        parms[20] = new SqlParameter(Outbox_DT.EnumInfo_Outbox.Paper_Attached.ToString(), obj.Paper_Attached);

        parms[21] = new SqlParameter(Outbox_DT.EnumInfo_Outbox.Dept_Desc.ToString(), obj.Dept_Desc);

        parms[22] = new SqlParameter(Outbox_DT.EnumInfo_Outbox.Source_Type.ToString(), obj.Source_Type);

        parms[23] = new SqlParameter(Outbox_DT.EnumInfo_Outbox.Org_Out_Box_Person.ToString(), obj.Org_Out_Box_Person);

        parms[24] = new SqlParameter(Outbox_DT.EnumInfo_Outbox.Org_Dept_Name.ToString(), obj.Org_Dept_Name);

        parms[25] = new SqlParameter(Outbox_DT.EnumInfo_Outbox.Enter_Date.ToString(), obj.Enter_Date);

        parms[26] = new SqlParameter(Outbox_DT.EnumInfo_Outbox.Dept_Dept_id.ToString(), obj.Dept_Dept_id);

        parms[27] = new SqlParameter(Outbox_DT.EnumInfo_Outbox.Group_id.ToString(), obj.Group_id);

        parms[28] = new SqlParameter(Outbox_DT.EnumInfo_Outbox.pmp_pmp_id.ToString(), obj.pmp_pmp_id);

        parms[29] = new SqlParameter(Outbox_DT.EnumInfo_Outbox.finished.ToString(), obj.finished);

        parms[30] = new SqlParameter(Outbox_DT.EnumInfo_Outbox.sub_Cat_id.ToString(), obj.sub_Cat_id);

        parms[31] = new SqlParameter(Outbox_DT.EnumInfo_Outbox.foundation_id.ToString(), obj.foundation_id);

        return parms;
    }

    #endregion

    #region DataBase Function

    public static int Save(Outbox_DT obj)
    {
        try
        {
            SqlParameter[] parms = GetParameters(obj, false);

            SqlHelper.ExecuteScalar(Database.ConnectionString, CommandType.StoredProcedure, "Outbox_Save", parms);
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
            SqlHelper.ExecuteNonQuery(Database.ConnectionString, "Outbox_Delete", ID);
            return ID;
        }
        catch (Exception ex)
        {
            return -1;
        }
    }
   
    public static int Outbox_cat_save(int ID, int cat_id, int type, int Outbox_type)
    {
        try
        {
            SqlHelper.ExecuteNonQuery(Database.ConnectionString, "Outbox_cat_save", ID, cat_id, type, Outbox_type);
            return ID;
        }
        catch (Exception ex)
        {
            return -1;
        }
    }

    public static int Outbox_visa_emp_save(int Visa_Id, int Emp_ID, int Sender_ID)
    {
        try
        {
            SqlHelper.ExecuteNonQuery(Database.ConnectionString, "Outbox_visa_emp_save", Visa_Id, Emp_ID, Sender_ID);
            return 1;
        }
        catch (Exception ex)
        {
            return -1;
        }
    }

    public static DataTable SelectAll(int proj_proj_id)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Outbox_Select",  proj_proj_id).Tables[0];

    }
    public static DataTable Outbox_fillcontrol(int id)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Outbox_fillcontrol", id).Tables[0];

    }
    public static DataTable Outbox_Direct_Relating(int Related_type, int id)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Outbox_Direct_Relating", Related_type, id).Tables[0];

    }
    public static DataTable Outbox_getorg(int id)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Outbox_getorg", id).Tables[0];

    }
    public static Outbox_DT SelectByID(int ID)
    {
        try
        {
            SqlDataReader drTableName;
            Outbox_DT obj = new Outbox_DT();
            if (ID > 0)
            {
                drTableName = SqlHelper.ExecuteReader(Database.ConnectionString, "Outbox_Select", ID);
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
    public static void update_Outbox_Track_Emp(string Outbox_id, string Emp_ID, int Outbox_Status, int Type)
    {
        DataTable DT = General_Helping.GetDataTable("select * from Outbox_Track_Emp where Outbox_id = " + Outbox_id + " and Emp_ID =" + Emp_ID);
        if (DT.Rows.Count > 0)
        {

            string sql = "update Outbox_Track_Emp set Outbox_Status= " + Outbox_Status + " where Outbox_id =" + Outbox_id + " and Emp_ID =" + Emp_ID;
            General_Helping.ExcuteQuery(sql);
        }
        else
        {
            string sql = "insert into Outbox_Track_Emp (Outbox_id,Emp_ID,Outbox_Status,Type_Track_emp) values ( " + Outbox_id + "," + Emp_ID + "," + Outbox_Status + "," + "1" + ")";
            General_Helping.ExcuteQuery(sql);
        }

    }
    public static void update_Outbox_Track_Manager(string Outbox_id, int Status)
    {
        DataTable DT = General_Helping.GetDataTable("select * from Outbox_Track_Manager where Outbox_id = " + Outbox_id );
        if (DT.Rows.Count > 0)
        {

            string sql = "update Outbox_Track_Manager set Status= " + Status + " where Outbox_id =" + Outbox_id ;
            General_Helping.ExcuteQuery(sql);
        }
        

    }
    public static DataTable new_Outbox_all(int parent, int group, int pmp, int active)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "new_Outbox_all", parent, group, pmp,active).Tables[0];

    }
    public static DataTable old_Outbox_all(int parent, int group, int pmp, int active)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "old_Outbox_all", parent, group, pmp,active).Tables[0];

    }
    public static DataTable late_Outbox_all(int parent, int group, int pmp, string todayplus1, string todayplus2, int active)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "late_Outbox_all", parent, group, pmp, todayplus1, todayplus2,active).Tables[0];

    }
    public static DataTable closed_Outbox_all(int parent, int group, int pmp, int active)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "closed_Outbox_all", parent, group, pmp,active).Tables[0];

    }
    public static DataTable follow_Outbox_all(int parent, int group, int pmp, int active)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "follow_Outbox_all",parent, group, pmp,active).Tables[0];

    }
    public static DataTable get_Outbox_not_sent_visa(int group)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Outbox_Not_sent_visa", group).Tables[0];

    }
    public static DataTable get_Outbox_sent_visa(int group)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Outbox_sent_visa", group).Tables[0];

    }
    public static DataTable outbox_inside_data(int outbox_id)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "outboxinside_data", outbox_id).Tables[0];

    }


    public static DataTable outbox_cat_select(int inbox_id, int type)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "outbox_cat_select", inbox_id, type).Tables[0];

    }
    public static Outbox_DT SelectOutboxByOrg(int org_id)
    {
        try
        {
            SqlDataReader drTableName;
            Outbox_DT obj = new Outbox_DT();
            if (org_id > 0)
            {
                drTableName = SqlHelper.ExecuteReader(Database.ConnectionString, "Outbox_SelectByOrg", org_id);
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




    public static DataTable Foundations_Followup(int foundation_id)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Foundations_Followup", foundation_id).Tables[0];

    }

    #endregion

}
