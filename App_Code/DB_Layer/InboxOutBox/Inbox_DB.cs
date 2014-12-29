using System;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for Inbox_DB
/// </summary>
public static class Inbox_DB
{
    #region "Private methods"

    private static Inbox_DT FillInfoObject(SqlDataReader dr)
    {

        Inbox_DT oInbox_DT = new Inbox_DT();

         
        oInbox_DT.ID = Convert.ToInt32(dr[Inbox_DT.EnumInfo_Inbox.ID.ToString()]);
        oInbox_DT.Proj_id = dr[Inbox_DT.EnumInfo_Inbox.Proj_id.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Inbox_DT.EnumInfo_Inbox.Proj_id.ToString()]);
        oInbox_DT.Type = dr[Inbox_DT.EnumInfo_Inbox.Type.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Inbox_DT.EnumInfo_Inbox.Type.ToString()]);
        oInbox_DT.Dept_ID = dr[Inbox_DT.EnumInfo_Inbox.Dept_ID.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Inbox_DT.EnumInfo_Inbox.Dept_ID.ToString()]);
        oInbox_DT.Emp_ID = dr[Inbox_DT.EnumInfo_Inbox.Emp_ID.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Inbox_DT.EnumInfo_Inbox.Emp_ID.ToString()]);
        oInbox_DT.Source_Type = dr[Inbox_DT.EnumInfo_Inbox.Source_Type.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Inbox_DT.EnumInfo_Inbox.Source_Type.ToString()]);
        oInbox_DT.Org_Id = dr[Inbox_DT.EnumInfo_Inbox.Org_Id.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Inbox_DT.EnumInfo_Inbox.Org_Id.ToString()]);
        oInbox_DT.Related_Type = dr[Inbox_DT.EnumInfo_Inbox.Related_Type.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Inbox_DT.EnumInfo_Inbox.Related_Type.ToString()]);
        oInbox_DT.Related_Id = dr[Inbox_DT.EnumInfo_Inbox.Related_Id.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Inbox_DT.EnumInfo_Inbox.Related_Id.ToString()]);
        oInbox_DT.Follow_Up_Dept_ID = dr[Inbox_DT.EnumInfo_Inbox.Follow_Up_Dept_ID.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Inbox_DT.EnumInfo_Inbox.Follow_Up_Dept_ID.ToString()]);
        oInbox_DT.Follow_Up_Emp_ID = dr[Inbox_DT.EnumInfo_Inbox.Follow_Up_Emp_ID.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Inbox_DT.EnumInfo_Inbox.Follow_Up_Emp_ID.ToString()]);
        oInbox_DT.Status = dr[Inbox_DT.EnumInfo_Inbox.Status.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Inbox_DT.EnumInfo_Inbox.Status.ToString()]);
        oInbox_DT.Subject = dr[Inbox_DT.EnumInfo_Inbox.Subject.ToString()] == DBNull.Value ? null : Convert.ToString(dr[Inbox_DT.EnumInfo_Inbox.Subject.ToString()]);
        oInbox_DT.Notes = dr[Inbox_DT.EnumInfo_Inbox.Notes.ToString()] == DBNull.Value ? null : Convert.ToString(dr[Inbox_DT.EnumInfo_Inbox.Notes.ToString()]);
        oInbox_DT.Name = dr[Inbox_DT.EnumInfo_Inbox.Name.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Inbox_DT.EnumInfo_Inbox.Name.ToString()]);
        oInbox_DT.Code = dr[Inbox_DT.EnumInfo_Inbox.Code.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Inbox_DT.EnumInfo_Inbox.Code.ToString()]);
        oInbox_DT.Date = dr[Inbox_DT.EnumInfo_Inbox.Date.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Inbox_DT.EnumInfo_Inbox.Date.ToString()]);
        oInbox_DT.Org_Name = dr[Inbox_DT.EnumInfo_Inbox.Org_Name.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Inbox_DT.EnumInfo_Inbox.Org_Name.ToString()]);
        oInbox_DT.Org_Out_Box_Code = dr[Inbox_DT.EnumInfo_Inbox.Org_Out_Box_Code.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Inbox_DT.EnumInfo_Inbox.Org_Out_Box_Code.ToString()]);
        oInbox_DT.Org_Out_Box_DT = dr[Inbox_DT.EnumInfo_Inbox.Org_Out_Box_DT.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Inbox_DT.EnumInfo_Inbox.Org_Out_Box_DT.ToString()]);
        oInbox_DT.Paper_No = dr[Inbox_DT.EnumInfo_Inbox.Paper_No.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Inbox_DT.EnumInfo_Inbox.Paper_No.ToString()]);
        oInbox_DT.Paper_Attached = dr[Inbox_DT.EnumInfo_Inbox.Paper_Attached.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Inbox_DT.EnumInfo_Inbox.Paper_Attached.ToString()]);
        oInbox_DT.Dept_Desc = dr[Inbox_DT.EnumInfo_Inbox.Dept_Desc.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Inbox_DT.EnumInfo_Inbox.Dept_Desc.ToString()]);
        oInbox_DT.Org_Out_Box_Person = dr[Inbox_DT.EnumInfo_Inbox.Org_Out_Box_Person.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Inbox_DT.EnumInfo_Inbox.Org_Out_Box_Person.ToString()]);
        oInbox_DT.Org_Dept_Name = dr[Inbox_DT.EnumInfo_Inbox.Org_Dept_Name.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Inbox_DT.EnumInfo_Inbox.Org_Dept_Name.ToString()]);
        oInbox_DT.sub_Cat_id = dr[Inbox_DT.EnumInfo_Inbox.sub_Cat_id.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Inbox_DT.EnumInfo_Inbox.sub_Cat_id.ToString()]);
        oInbox_DT.finished = dr[Inbox_DT.EnumInfo_Inbox.finished.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Inbox_DT.EnumInfo_Inbox.finished.ToString()]);
        oInbox_DT.foundation_id = dr[Inbox_DT.EnumInfo_Inbox.foundation_id.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Inbox_DT.EnumInfo_Inbox.foundation_id.ToString()]);


        return oInbox_DT;
    }

    private static SqlParameter[] GetParameters(Inbox_DT obj, bool isSearch)
    {
        SqlParameter[] parms = new SqlParameter[32];


        if (!isSearch)
        {

            parms[0] = new SqlParameter(Inbox_DT.EnumInfo_Inbox.ID.ToString(), obj.ID);
            parms[0].Direction = ParameterDirection.InputOutput;

        }

        parms[1] = new SqlParameter(Inbox_DT.EnumInfo_Inbox.Proj_id.ToString(), obj.Proj_id);

        parms[2] = new SqlParameter(Inbox_DT.EnumInfo_Inbox.Type.ToString(), obj.Type);

        parms[3] = new SqlParameter(Inbox_DT.EnumInfo_Inbox.Dept_ID.ToString(), obj.Dept_ID);

        parms[4] = new SqlParameter(Inbox_DT.EnumInfo_Inbox.Emp_ID.ToString(), obj.Emp_ID);

        parms[5] = new SqlParameter(Inbox_DT.EnumInfo_Inbox.Org_Id.ToString(), obj.Org_Id);

        parms[6] = new SqlParameter(Inbox_DT.EnumInfo_Inbox.Related_Type.ToString(), obj.Related_Type);

        parms[7] = new SqlParameter(Inbox_DT.EnumInfo_Inbox.Related_Id.ToString(), obj.Related_Id);

        parms[8] = new SqlParameter(Inbox_DT.EnumInfo_Inbox.Follow_Up_Dept_ID.ToString(), obj.Follow_Up_Dept_ID);

        parms[9] = new SqlParameter(Inbox_DT.EnumInfo_Inbox.Follow_Up_Emp_ID.ToString(), obj.Follow_Up_Emp_ID);

        parms[10] = new SqlParameter(Inbox_DT.EnumInfo_Inbox.Status.ToString(), obj.Status);

        parms[11] = new SqlParameter(Inbox_DT.EnumInfo_Inbox.Subject.ToString(), obj.Subject);

        parms[12] = new SqlParameter(Inbox_DT.EnumInfo_Inbox.Notes.ToString(), obj.Notes);

        parms[13] = new SqlParameter(Inbox_DT.EnumInfo_Inbox.Name.ToString(), obj.Name);

        parms[14] = new SqlParameter(Inbox_DT.EnumInfo_Inbox.Code.ToString(), obj.Code);

        parms[15] = new SqlParameter(Inbox_DT.EnumInfo_Inbox.Date.ToString(), obj.Date);

        parms[16] = new SqlParameter(Inbox_DT.EnumInfo_Inbox.Org_Name.ToString(), obj.Org_Name);

        parms[17] = new SqlParameter(Inbox_DT.EnumInfo_Inbox.Org_Out_Box_Code.ToString(), obj.Org_Out_Box_Code);

        parms[18] = new SqlParameter(Inbox_DT.EnumInfo_Inbox.Org_Out_Box_DT.ToString(), obj.Org_Out_Box_DT);

        parms[19] = new SqlParameter(Inbox_DT.EnumInfo_Inbox.Paper_No.ToString(), obj.Paper_No);

        parms[20] = new SqlParameter(Inbox_DT.EnumInfo_Inbox.Paper_Attached.ToString(), obj.Paper_Attached);

        parms[21] = new SqlParameter(Inbox_DT.EnumInfo_Inbox.Dept_Desc.ToString(), obj.Dept_Desc);

        parms[22] = new SqlParameter(Inbox_DT.EnumInfo_Inbox.Source_Type.ToString(), obj.Source_Type);

        parms[23] = new SqlParameter(Inbox_DT.EnumInfo_Inbox.Org_Out_Box_Person.ToString(), obj.Org_Out_Box_Person);

        parms[24] = new SqlParameter(Inbox_DT.EnumInfo_Inbox.Org_Dept_Name.ToString(), obj.Org_Dept_Name);

        parms[25] = new SqlParameter(Inbox_DT.EnumInfo_Inbox.Enter_Date.ToString(), obj.Enter_Date);

        parms[26] = new SqlParameter(Inbox_DT.EnumInfo_Inbox.Dept_Dept_id.ToString(), obj.Dept_Dept_id);

        parms[27] = new SqlParameter(Inbox_DT.EnumInfo_Inbox.Group_id.ToString(), obj.Group_id);

        parms[28] = new SqlParameter(Inbox_DT.EnumInfo_Inbox.pmp_pmp_id.ToString(), obj.pmp_pmp_id);

        parms[29] = new SqlParameter(Inbox_DT.EnumInfo_Inbox.sub_Cat_id.ToString(), obj.sub_Cat_id);

        parms[30] = new SqlParameter(Inbox_DT.EnumInfo_Inbox.finished.ToString(), obj.finished);

        parms[31] = new SqlParameter(Inbox_DT.EnumInfo_Inbox.foundation_id.ToString(), obj.foundation_id);
        


        return parms;
    }

    #endregion

    #region DataBase Function

    public static int Save(Inbox_DT obj)
    {
        try
        {
            SqlParameter[] parms = GetParameters(obj, false);

            SqlHelper.ExecuteScalar(Database.ConnectionString, CommandType.StoredProcedure, "Inbox_Save", parms);
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
            SqlHelper.ExecuteNonQuery(Database.ConnectionString, "Inbox_Delete", ID);
            return ID;
        }
        catch (Exception ex)
        {
            return -1;
        }
    }
    public static int inbox_cat_save(int ID,int cat_id , int type , int inbox_type)
    {
        try
        {
            SqlHelper.ExecuteNonQuery(Database.ConnectionString, "inbox_cat_save", ID,cat_id,type,inbox_type);
            return ID;
        }
        catch (Exception ex)
        {
            return -1;
        }
    }

    public static int Inbox_sub_categories_update(string  name, string ID)
    {
        try
        {
            SqlHelper.ExecuteNonQuery(Database.ConnectionString, "Inbox_sub_categories_update", name, ID);
            return 1;
        }
        catch (Exception ex)
        {
            return -1;
        }
    }
    public static int inbox_visa_emp_save(int Visa_Id, int Emp_ID, int Sender_ID)
    {
        try
        {
            SqlHelper.ExecuteNonQuery(Database.ConnectionString, "inbox_visa_emp_save", Visa_Id, Emp_ID, Sender_ID);
            return 1;
        }
        catch (Exception ex)
        {
            return -1;
        }
    }
    //public static DataTable inbox_search_par(int group_id, int pmp, int main_cat, int sub_cat, string out_code, string code, string subject, int Org_id, string inbox_date_from, string inbox_date_to, string outbox_date_from, string outbox_date_to)
    //{

    //    return SqlHelper.ExecuteDataset(Database.ConnectionString, "inbox_search_par", group_id, pmp, main_cat, sub_cat, out_code, code, subject, Org_id, inbox_date_from, inbox_date_to, outbox_date_from, outbox_date_to).Tables[0];

    //}
    public static DataTable inbox_search_par(int group_id, int pmp, int main_cat, int sub_cat, string out_code, string code, string subject, int Org_id)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "inbox_search_par", group_id, pmp, main_cat, sub_cat, out_code, code, subject,Org_id).Tables[0];

    }
    public static DataTable SelectRelated(int id, int type)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "inbox_related", id, type).Tables[0];

    }
    public static DataTable inbox_Direct_Relating(int Related_type, int id)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "inbox_Direct_Relating", Related_type, id).Tables[0];

    }
    public static DataTable inbox_getorg(int id)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "inbox_getorg", id).Tables[0];

    }
    public static DataTable Selectcode(int found)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Get_code_arch_type", found).Tables[0];

    }
    public static DataTable inbox_fillcontrol(int id)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "inbox_fillcontrol", id).Tables[0];

    }
    public static DataTable SelectAll(int proj_proj_id)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Inbox_Select", proj_proj_id).Tables[0];

    }

    public static DataTable Inbox_cat_select(int inbox_id,int type)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Inbox_cat_select", inbox_id, type).Tables[0];

    }

    public static Inbox_DT SelectByID(int ID)
    {
        try
        {
            SqlDataReader drTableName;
            Inbox_DT obj = new Inbox_DT();
            if (ID > 0)
            {
                drTableName = SqlHelper.ExecuteReader(Database.ConnectionString, "Inbox_Select", ID);
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

    public static void update_inbox_Track_Emp(string inbox_id, string Emp_ID, int Inbox_Status,int Type)
    {
        //DataTable DT = General_Helping.GetDataTable("select * from Inbox_Track_Emp where inbox_id = " + inbox_id + " and Emp_ID =" + Emp_ID);
        DataTable DT = SqlHelper.ExecuteDataset(Database.ConnectionString, "get_data_from_inbox_track_emp_by_inbox_emp", inbox_id, Emp_ID).Tables[0];
        if (DT.Rows.Count > 0)
        {

            string sql = "update Inbox_Track_Emp set Inbox_Status= " + Inbox_Status + " where inbox_id =" + inbox_id + " and Emp_ID =" + Emp_ID;
            General_Helping.ExcuteQuery(sql);
        }
        else 
        {
            string sql = "insert into Inbox_Track_Emp (inbox_id,Emp_ID,Inbox_Status,Type_Track_emp) values ( " + inbox_id + "," + Emp_ID + "," + Inbox_Status + "," + "1"+ ")";
            General_Helping.ExcuteQuery(sql);
        }
        
    }
    public static void update_inbox_Track_manger(string inbox_id, int Status)
    {
        //DataTable DT = General_Helping.GetDataTable("select * from Inbox_Track_Manager where inbox_id = " + inbox_id );
        DataTable DT = SqlHelper.ExecuteDataset(Database.ConnectionString, "get_data_from_inbox_track_manager", inbox_id).Tables[0];
        if (DT.Rows.Count > 0)
        {

            string sql = "update Inbox_Track_Manager set Status= " + Status + " where inbox_id =" + inbox_id ;
            General_Helping.ExcuteQuery(sql);
        }
       

    }
    public static DataTable inbox_getparent_certainInbox(int inbox_id)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "inbox_get_parent_of_certain_inbox", inbox_id).Tables[0];

    }
    public static DataTable inbox_inside_data(int inbox_id)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "inboxinside_data", inbox_id).Tables[0];

    }
    public static DataTable new_inbox_all(int parent,int group,int pmp,int active)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "new_inbox_all", parent, group, pmp, active).Tables[0];

    }
    public static DataTable old_inbox_all(int parent, int group, int pmp, int active)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "old_inbox_all", parent, group, pmp, active).Tables[0];

    }
    public static DataTable late_inbox_all(int parent, int group, int pmp, string todayplus1, string todayplus2, int active)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "late_inbox_all", parent, group, pmp, todayplus1, todayplus2, active).Tables[0];

    }
    public static DataTable closed_inbox_all(int parent, int group, int pmp, int active)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "closed_inbox_all", parent, group, pmp, active).Tables[0];

    }
    public static DataTable follow_inbox_all(int parent, int pmp, int active)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "follow_inbox_all", parent, pmp, active).Tables[0];

    }
    public static DataTable understudy_inbox_all(int group, int active)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "understudy_inbox_all", group, active).Tables[0];

    }
    public static DataTable getchild(int pmp)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "getchildemp", pmp).Tables[0];

    }
    public static DataTable getparent(int child , int type)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "GetParent_bychild_inbox", child, type).Tables[0];

    }
    public static DataTable get_inbox_not_sent_visa(int group,int parent_id)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "inbox_Not_sent_visa", group, parent_id).Tables[0];

    }
    public static DataTable get_inbox_sent_visa(int group,int parent)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "inbox_sent_visa", group, parent).Tables[0];

    }
    public static Inbox_DT SelectInboxByOrg(int org_id)
    {
        try
        {
            SqlDataReader drTableName;
            Inbox_DT obj = new Inbox_DT();
            if (org_id > 0)
            {
                drTableName = SqlHelper.ExecuteReader(Database.ConnectionString, "Inbox_SelectByOrg", org_id);
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
