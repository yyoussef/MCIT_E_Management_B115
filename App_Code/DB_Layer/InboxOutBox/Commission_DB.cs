using System;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for Inbox_DB
/// </summary>
public static class Commission_DB
{
    #region "Private methods"

    private static Commission_DT FillInfoObject(SqlDataReader dr)
    {

        Commission_DT ocommission_DT = new Commission_DT();


        ocommission_DT.ID = Convert.ToInt32(dr[Commission_DT.EnumInfo_Commission.ID.ToString()]);
        ocommission_DT.Proj_id = dr[Commission_DT.EnumInfo_Commission.Proj_id.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Commission_DT.EnumInfo_Commission.Proj_id.ToString()]);
        ocommission_DT.Type = dr[Commission_DT.EnumInfo_Commission.Type.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Commission_DT.EnumInfo_Commission.Type.ToString()]);
        ocommission_DT.Dept_ID = dr[Commission_DT.EnumInfo_Commission.Dept_ID.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Commission_DT.EnumInfo_Commission.Dept_ID.ToString()]);
        ocommission_DT.Emp_ID = dr[Commission_DT.EnumInfo_Commission.Emp_ID.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Commission_DT.EnumInfo_Commission.Emp_ID.ToString()]);
        ocommission_DT.Source_Type = dr[Commission_DT.EnumInfo_Commission.Source_Type.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Commission_DT.EnumInfo_Commission.Source_Type.ToString()]);
        ocommission_DT.Org_Id = dr[Commission_DT.EnumInfo_Commission.Org_Id.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Commission_DT.EnumInfo_Commission.Org_Id.ToString()]);
        ocommission_DT.Related_Type = dr[Commission_DT.EnumInfo_Commission.Related_Type.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Commission_DT.EnumInfo_Commission.Related_Type.ToString()]);
        ocommission_DT.Related_Id = dr[Commission_DT.EnumInfo_Commission.Related_Id.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Commission_DT.EnumInfo_Commission.Related_Id.ToString()]);
        ocommission_DT.Follow_Up_Dept_ID = dr[Commission_DT.EnumInfo_Commission.Follow_Up_Dept_ID.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Commission_DT.EnumInfo_Commission.Follow_Up_Dept_ID.ToString()]);
        ocommission_DT.Follow_Up_Emp_ID = dr[Commission_DT.EnumInfo_Commission.Follow_Up_Emp_ID.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Commission_DT.EnumInfo_Commission.Follow_Up_Emp_ID.ToString()]);
        ocommission_DT.Status = dr[Commission_DT.EnumInfo_Commission.Status.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Commission_DT.EnumInfo_Commission.Status.ToString()]);
        ocommission_DT.Subject = dr[Commission_DT.EnumInfo_Commission.Subject.ToString()] == DBNull.Value ? null : Convert.ToString(dr[Commission_DT.EnumInfo_Commission.Subject.ToString()]);
        ocommission_DT.Notes = dr[Commission_DT.EnumInfo_Commission.Notes.ToString()] == DBNull.Value ? null : Convert.ToString(dr[Commission_DT.EnumInfo_Commission.Notes.ToString()]);
        ocommission_DT.Name = dr[Commission_DT.EnumInfo_Commission.Name.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Commission_DT.EnumInfo_Commission.Name.ToString()]);
        ocommission_DT.Code = dr[Commission_DT.EnumInfo_Commission.Code.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Commission_DT.EnumInfo_Commission.Code.ToString()]);
        ocommission_DT.Date = dr[Commission_DT.EnumInfo_Commission.Date.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Commission_DT.EnumInfo_Commission.Date.ToString()]);
        ocommission_DT.Org_Name = dr[Commission_DT.EnumInfo_Commission.Org_Name.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Commission_DT.EnumInfo_Commission.Org_Name.ToString()]);
        ocommission_DT.Org_Out_Box_Code = dr[Commission_DT.EnumInfo_Commission.Org_Out_Box_Code.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Commission_DT.EnumInfo_Commission.Org_Out_Box_Code.ToString()]);
        ocommission_DT.Org_Out_Box_DT = dr[Commission_DT.EnumInfo_Commission.Org_Out_Box_DT.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Commission_DT.EnumInfo_Commission.Org_Out_Box_DT.ToString()]);
        ocommission_DT.Paper_No = dr[Commission_DT.EnumInfo_Commission.Paper_No.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Commission_DT.EnumInfo_Commission.Paper_No.ToString()]);
        ocommission_DT.Paper_Attached = dr[Commission_DT.EnumInfo_Commission.Paper_Attached.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Commission_DT.EnumInfo_Commission.Paper_Attached.ToString()]);
        ocommission_DT.Dept_Desc = dr[Commission_DT.EnumInfo_Commission.Dept_Desc.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Commission_DT.EnumInfo_Commission.Dept_Desc.ToString()]);
        ocommission_DT.Org_Out_Box_Person = dr[Commission_DT.EnumInfo_Commission.Org_Out_Box_Person.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Commission_DT.EnumInfo_Commission.Org_Out_Box_Person.ToString()]);
        ocommission_DT.Org_Dept_Name = dr[Commission_DT.EnumInfo_Commission.Org_Dept_Name.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Commission_DT.EnumInfo_Commission.Org_Dept_Name.ToString()]);
        ocommission_DT.sub_Cat_id = dr[Commission_DT.EnumInfo_Commission.sub_Cat_id.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Commission_DT.EnumInfo_Commission.sub_Cat_id.ToString()]);
        ocommission_DT.finished = dr[Commission_DT.EnumInfo_Commission.finished.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Commission_DT.EnumInfo_Commission.finished.ToString()]);
        ocommission_DT.Resp_emp_close = dr[Commission_DT.EnumInfo_Commission.Resp_emp_close.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Commission_DT.EnumInfo_Commission.Resp_emp_close.ToString()]);
        ocommission_DT.Actual_emp_close = dr[Commission_DT.EnumInfo_Commission.Actual_emp_close.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Commission_DT.EnumInfo_Commission.Actual_emp_close.ToString()]);
        ocommission_DT.Date_close = dr[Commission_DT.EnumInfo_Commission.Date_close.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Commission_DT.EnumInfo_Commission.Date_close.ToString()]);
        ocommission_DT.foundation_id = dr[Commission_DT.EnumInfo_Commission.foundation_id.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Commission_DT.EnumInfo_Commission.foundation_id.ToString()]);
        



        return ocommission_DT;
    }

    private static SqlParameter[] GetParameters(Commission_DT obj, bool isSearch)
    {
        SqlParameter[] parms = new SqlParameter[35];


        if (!isSearch)
        {

            parms[0] = new SqlParameter(Commission_DT.EnumInfo_Commission.ID.ToString(), obj.ID);
            parms[0].Direction = ParameterDirection.InputOutput;

        }

        parms[1] = new SqlParameter(Commission_DT.EnumInfo_Commission.Proj_id.ToString(), obj.Proj_id);

        parms[2] = new SqlParameter(Commission_DT.EnumInfo_Commission.Type.ToString(), obj.Type);

        parms[3] = new SqlParameter(Commission_DT.EnumInfo_Commission.Dept_ID.ToString(), obj.Dept_ID);

        parms[4] = new SqlParameter(Commission_DT.EnumInfo_Commission.Emp_ID.ToString(), obj.Emp_ID);

        parms[5] = new SqlParameter(Commission_DT.EnumInfo_Commission.Org_Id.ToString(), obj.Org_Id);

        parms[6] = new SqlParameter(Commission_DT.EnumInfo_Commission.Related_Type.ToString(), obj.Related_Type);

        parms[7] = new SqlParameter(Commission_DT.EnumInfo_Commission.Related_Id.ToString(), obj.Related_Id);

        parms[8] = new SqlParameter(Commission_DT.EnumInfo_Commission.Follow_Up_Dept_ID.ToString(), obj.Follow_Up_Dept_ID);

        parms[9] = new SqlParameter(Commission_DT.EnumInfo_Commission.Follow_Up_Emp_ID.ToString(), obj.Follow_Up_Emp_ID);

        parms[10] = new SqlParameter(Commission_DT.EnumInfo_Commission.Status.ToString(), obj.Status);

        parms[11] = new SqlParameter(Commission_DT.EnumInfo_Commission.Subject.ToString(), obj.Subject);

        parms[12] = new SqlParameter(Commission_DT.EnumInfo_Commission.Notes.ToString(), obj.Notes);

        parms[13] = new SqlParameter(Commission_DT.EnumInfo_Commission.Name.ToString(), obj.Name);

        parms[14] = new SqlParameter(Commission_DT.EnumInfo_Commission.Code.ToString(), obj.Code);

        parms[15] = new SqlParameter(Commission_DT.EnumInfo_Commission.Date.ToString(), obj.Date);

        parms[16] = new SqlParameter(Commission_DT.EnumInfo_Commission.Org_Name.ToString(), obj.Org_Name);

        parms[17] = new SqlParameter(Commission_DT.EnumInfo_Commission.Org_Out_Box_Code.ToString(), obj.Org_Out_Box_Code);

        parms[18] = new SqlParameter(Commission_DT.EnumInfo_Commission.Org_Out_Box_DT.ToString(), obj.Org_Out_Box_DT);

        parms[19] = new SqlParameter(Commission_DT.EnumInfo_Commission.Paper_No.ToString(), obj.Paper_No);

        parms[20] = new SqlParameter(Commission_DT.EnumInfo_Commission.Paper_Attached.ToString(), obj.Paper_Attached);

        parms[21] = new SqlParameter(Commission_DT.EnumInfo_Commission.Dept_Desc.ToString(), obj.Dept_Desc);

        parms[22] = new SqlParameter(Commission_DT.EnumInfo_Commission.Source_Type.ToString(), obj.Source_Type);

        parms[23] = new SqlParameter(Commission_DT.EnumInfo_Commission.Org_Out_Box_Person.ToString(), obj.Org_Out_Box_Person);

        parms[24] = new SqlParameter(Commission_DT.EnumInfo_Commission.Org_Dept_Name.ToString(), obj.Org_Dept_Name);

        parms[25] = new SqlParameter(Commission_DT.EnumInfo_Commission.Enter_Date.ToString(), obj.Enter_Date);

        parms[26] = new SqlParameter(Commission_DT.EnumInfo_Commission.Dept_Dept_id.ToString(), obj.Dept_Dept_id);

        parms[27] = new SqlParameter(Commission_DT.EnumInfo_Commission.Group_id.ToString(), obj.Group_id);

        parms[28] = new SqlParameter(Commission_DT.EnumInfo_Commission.pmp_pmp_id.ToString(), obj.pmp_pmp_id);

        parms[29] = new SqlParameter(Commission_DT.EnumInfo_Commission.sub_Cat_id.ToString(), obj.sub_Cat_id);

        parms[30] = new SqlParameter(Commission_DT.EnumInfo_Commission.finished.ToString(), obj.finished);

        parms[31] = new SqlParameter(Commission_DT.EnumInfo_Commission.Resp_emp_close.ToString(), obj.Resp_emp_close);

        parms[32] = new SqlParameter(Commission_DT.EnumInfo_Commission.Actual_emp_close.ToString(), obj.Actual_emp_close);

        parms[33] = new SqlParameter(Commission_DT.EnumInfo_Commission.Date_close.ToString(), obj.Date_close);

        parms[34] = new SqlParameter(Commission_DT.EnumInfo_Commission.foundation_id.ToString(), obj.foundation_id);


        return parms;
    }

    #endregion

    #region DataBase Function

    public static int Save(Commission_DT obj)
    {
        try
        {
            SqlParameter[] parms = GetParameters(obj, false);

            SqlHelper.ExecuteScalar(Database.ConnectionString, CommandType.StoredProcedure, "Commission_Save", parms);
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
            SqlHelper.ExecuteNonQuery(Database.ConnectionString, "Commission_Delete", ID);
            return ID;
        }
        catch (Exception ex)
        {
            return -1;
        }
    }

    public static DataTable SelectAll(int proj_proj_id)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Commission_Select", proj_proj_id).Tables[0];

    }
    public static DataTable Com_fillcontrol(int id)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Com_fillcontrol", id).Tables[0];

    }

    public static Commission_DT SelectByID(int ID)
    {
        try
        {
            SqlDataReader drTableName;
            Commission_DT obj = new Commission_DT();
            if (ID > 0)
            {
                drTableName = SqlHelper.ExecuteReader(Database.ConnectionString, "Commission_Select", ID);
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

    public static void update_Commission_Track_Emp(string Commission_id, string Emp_ID, int Commission_Status, int Type)
    {
        DataTable DT = General_Helping.GetDataTable("select * from Commission_Track_Emp where Commission_id = " + Commission_id + " and Emp_ID =" + Emp_ID);
        if (DT.Rows.Count > 0)
        {

            string sql = "update Commission_Track_Emp set Commission_Status= " + Commission_Status + " where Commission_id =" + Commission_id + " and Emp_ID =" + Emp_ID;
            General_Helping.ExcuteQuery(sql);
        }
        else
        {
            string sql = "insert into Commission_Track_Emp (Commission_id,Emp_ID,Commission_Status,Type_Track_emp) values ( " + Commission_id + "," + Emp_ID + "," + Commission_Status + "," + "1" + ")";
            General_Helping.ExcuteQuery(sql);
        }

    }
    public static DataTable new_com_all(int parent, int group, int pmp)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "new_com_all", parent, group, pmp).Tables[0];

    }
    public static DataTable old_com_all(int parent, int group, int pmp)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "old_com_all", parent, group, pmp).Tables[0];

    }
    public static DataTable late_com_all(int parent, int group, int pmp, string todayplus1, string todayplus2)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "late_com_all", parent, group, pmp, todayplus1, todayplus2).Tables[0];

    }
    public static DataTable closed_com_all(int parent, int group, int pmp)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Closed_com_all", parent, group, pmp).Tables[0];

    }
    public static DataTable follow_com_all(int parent, int pmp)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "follow_com_all", parent, pmp).Tables[0];

    }
    #endregion

}
