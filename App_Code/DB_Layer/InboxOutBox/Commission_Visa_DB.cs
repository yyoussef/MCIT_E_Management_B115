using System;
using System.Data.SqlClient;
using System.Data;


/// <summary>
/// Summary description for Inbox_Visa_DB
/// </summary>
public class Commission_Visa_DB
{
    #region "Private methods"

    private static Commission_Visa_DT FillInfoObject(SqlDataReader dr)
    {

        Commission_Visa_DT oCommission_Visa_DT = new Commission_Visa_DT();


        oCommission_Visa_DT.Visa_Id = Convert.ToInt32(dr[Commission_Visa_DT.EnumInfo_Visa.Visa_Id.ToString()]);
        oCommission_Visa_DT.Commission_ID = dr[Commission_Visa_DT.EnumInfo_Visa.Commission_ID.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Commission_Visa_DT.EnumInfo_Visa.Commission_ID.ToString()]);
        oCommission_Visa_DT.Important_Degree = dr[Commission_Visa_DT.EnumInfo_Visa.Important_Degree.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Commission_Visa_DT.EnumInfo_Visa.Important_Degree.ToString()]);
        oCommission_Visa_DT.Dept_ID = dr[Commission_Visa_DT.EnumInfo_Visa.Dept_ID.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Commission_Visa_DT.EnumInfo_Visa.Dept_ID.ToString()]);
        oCommission_Visa_DT.Emp_ID = dr[Commission_Visa_DT.EnumInfo_Visa.Emp_ID.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Commission_Visa_DT.EnumInfo_Visa.Emp_ID.ToString()]);
        oCommission_Visa_DT.Visa_Satus = dr[Commission_Visa_DT.EnumInfo_Visa.Visa_Satus.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Commission_Visa_DT.EnumInfo_Visa.Visa_Satus.ToString()]);
        oCommission_Visa_DT.Visa_Desc = dr[Commission_Visa_DT.EnumInfo_Visa.Visa_Desc.ToString()] == DBNull.Value ? null : Convert.ToString(dr[Commission_Visa_DT.EnumInfo_Visa.Visa_Desc.ToString()]);
        oCommission_Visa_DT.Visa_date = dr[Commission_Visa_DT.EnumInfo_Visa.Visa_date.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Commission_Visa_DT.EnumInfo_Visa.Visa_date.ToString()]);
        oCommission_Visa_DT.Important_Degree_Txt = dr[Commission_Visa_DT.EnumInfo_Visa.Important_Degree_Txt.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Commission_Visa_DT.EnumInfo_Visa.Important_Degree_Txt.ToString()]);
        oCommission_Visa_DT.Dept_ID_Txt = dr[Commission_Visa_DT.EnumInfo_Visa.Dept_ID_Txt.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Commission_Visa_DT.EnumInfo_Visa.Dept_ID_Txt.ToString()]);
        oCommission_Visa_DT.Emp_ID_Txt = dr[Commission_Visa_DT.EnumInfo_Visa.Emp_ID_Txt.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Commission_Visa_DT.EnumInfo_Visa.Emp_ID_Txt.ToString()]);
        oCommission_Visa_DT.Emp_ID = dr[Commission_Visa_DT.EnumInfo_Visa.mail_sent.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Commission_Visa_DT.EnumInfo_Visa.mail_sent.ToString()]);
        oCommission_Visa_DT.Visa_Period = dr[Commission_Visa_DT.EnumInfo_Visa.Visa_Period.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Commission_Visa_DT.EnumInfo_Visa.Visa_Period.ToString()]);
        oCommission_Visa_DT.Follow_Up_Dept_ID = dr[Commission_Visa_DT.EnumInfo_Visa.Follow_Up_Dept_ID.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Commission_Visa_DT.EnumInfo_Visa.Follow_Up_Dept_ID.ToString()]);
        oCommission_Visa_DT.Follow_Up_Emp_ID = dr[Commission_Visa_DT.EnumInfo_Visa.Follow_Up_Emp_ID.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Commission_Visa_DT.EnumInfo_Visa.Follow_Up_Emp_ID.ToString()]);
        oCommission_Visa_DT.Follow_Up_Notes = dr[Commission_Visa_DT.EnumInfo_Visa.Follow_Up_Notes.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Commission_Visa_DT.EnumInfo_Visa.Follow_Up_Notes.ToString()]);
        
        oCommission_Visa_DT.saving_file = dr[Commission_Visa_DT.EnumInfo_Visa.saving_file.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Commission_Visa_DT.EnumInfo_Visa.saving_file.ToString()]);
        oCommission_Visa_DT.Dead_Line_DT = dr[Commission_Visa_DT.EnumInfo_Visa.Dead_Line_DT.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Commission_Visa_DT.EnumInfo_Visa.Dead_Line_DT.ToString()]);
        oCommission_Visa_DT.Visa_Goal_ID = dr[Commission_Visa_DT.EnumInfo_Visa.Visa_Goal_ID.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Commission_Visa_DT.EnumInfo_Visa.Visa_Goal_ID.ToString()]);


        return oCommission_Visa_DT;
    }

    private static SqlParameter[] GetParameters(Commission_Visa_DT obj, bool isSearch)
    {
        SqlParameter[] parms = new SqlParameter[19];


        if (!isSearch)
        {

            parms[0] = new SqlParameter(Commission_Visa_DT.EnumInfo_Visa.Visa_Id.ToString(), obj.Visa_Id);
            parms[0].Direction = ParameterDirection.InputOutput;

           

        }

        parms[1] = new SqlParameter(Commission_Visa_DT.EnumInfo_Visa.Commission_ID.ToString(), obj.Commission_ID);

        parms[2] = new SqlParameter(Commission_Visa_DT.EnumInfo_Visa.Important_Degree.ToString(), obj.Important_Degree);

        parms[3] = new SqlParameter(Commission_Visa_DT.EnumInfo_Visa.Dept_ID.ToString(), obj.Dept_ID);

        parms[4] = new SqlParameter(Commission_Visa_DT.EnumInfo_Visa.Emp_ID.ToString(), obj.Emp_ID);

        parms[5] = new SqlParameter(Commission_Visa_DT.EnumInfo_Visa.Visa_Satus.ToString(), obj.Visa_Satus);

        parms[6] = new SqlParameter(Commission_Visa_DT.EnumInfo_Visa.Visa_Desc.ToString(), obj.Visa_Desc);

        parms[7] = new SqlParameter(Commission_Visa_DT.EnumInfo_Visa.Visa_date.ToString(), obj.Visa_date);

        parms[8] = new SqlParameter(Commission_Visa_DT.EnumInfo_Visa.Important_Degree_Txt.ToString(), obj.Important_Degree_Txt);

        parms[9] = new SqlParameter(Commission_Visa_DT.EnumInfo_Visa.Dept_ID_Txt.ToString(), obj.Dept_ID_Txt);

        parms[10] = new SqlParameter(Commission_Visa_DT.EnumInfo_Visa.Emp_ID_Txt.ToString(), obj.Emp_ID_Txt);

        parms[11] = new SqlParameter(Commission_Visa_DT.EnumInfo_Visa.Visa_Period.ToString(), obj.Visa_Period);

        parms[12] = new SqlParameter(Commission_Visa_DT.EnumInfo_Visa.Follow_Up_Dept_ID.ToString(), obj.Follow_Up_Dept_ID);

        parms[13] = new SqlParameter(Commission_Visa_DT.EnumInfo_Visa.Follow_Up_Emp_ID.ToString(), obj.Follow_Up_Emp_ID);

        parms[14] = new SqlParameter(Commission_Visa_DT.EnumInfo_Visa.Follow_Up_Notes.ToString(), obj.Follow_Up_Notes);

        parms[15] = new SqlParameter(Commission_Visa_DT.EnumInfo_Visa.saving_file.ToString(), obj.saving_file);

        parms[16] = new SqlParameter(Commission_Visa_DT.EnumInfo_Visa.Dead_Line_DT.ToString(), obj.Dead_Line_DT);

        parms[17] = new SqlParameter(Commission_Visa_DT.EnumInfo_Visa.Visa_Goal_ID.ToString(), obj.Visa_Goal_ID);

        parms[18] = new SqlParameter(Commission_Visa_DT.EnumInfo_Visa.mail_sent.ToString(), obj.mail_sent);

        

        return parms;
    }

    #endregion

    #region DataBase Function

    public static int Save(Commission_Visa_DT obj)
    {
        try
        {
            SqlParameter[] parms = GetParameters(obj, false);

            SqlHelper.ExecuteScalar(Database.ConnectionString, CommandType.StoredProcedure, "Commission_Visa_Save", parms);
            return 
            Convert.ToInt32(parms[0].Value);
           

        
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
            SqlHelper.ExecuteNonQuery(Database.ConnectionString, "Commission_Visa_Delete", ID);
            return ID;
        }
        catch (Exception ex)
        {
            return -1;
        }
    }

    public static DataTable SelectAll(int proj_proj_id)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Commission_Visa_Select", proj_proj_id).Tables[0];

    }

    public static Commission_Visa_DT SelectByID(int Commission_ID)
    {
        try
        {
            SqlDataReader drTableName;
            Commission_Visa_DT obj = new Commission_Visa_DT();
            if (Commission_ID > 0)
            {
                drTableName = SqlHelper.ExecuteReader(Database.ConnectionString, "Commission_Visa_Select", Commission_ID);
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
