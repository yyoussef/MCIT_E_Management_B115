using System;
using System.Data.SqlClient;
using System.Data;


/// <summary>
/// Summary description for Review_Visa_Follows_DB
/// </summary>
public class Review_Visa_Follows_DB
{
    #region "Private methods"

    private static Review_Visa_Follows_DT FillInfoObject(SqlDataReader dr)
    {

        Review_Visa_Follows_DT oReview_Visa_Follows_DT = new Review_Visa_Follows_DT();


        oReview_Visa_Follows_DT.Follow_ID = Convert.ToInt32(dr[Review_Visa_Follows_DT.EnumInfo_Visa_Follows.Follow_ID.ToString()]);
        oReview_Visa_Follows_DT.Review_ID = dr[Review_Visa_Follows_DT.EnumInfo_Visa_Follows.Review_ID.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Review_Visa_Follows_DT.EnumInfo_Visa_Follows.Review_ID.ToString()]);
        oReview_Visa_Follows_DT.entery_pmp_id = dr[Review_Visa_Follows_DT.EnumInfo_Visa_Follows.entery_pmp_id.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Review_Visa_Follows_DT.EnumInfo_Visa_Follows.entery_pmp_id.ToString()]);
        oReview_Visa_Follows_DT.Type_Follow = dr[Review_Visa_Follows_DT.EnumInfo_Visa_Follows.Type_Follow.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Review_Visa_Follows_DT.EnumInfo_Visa_Follows.Type_Follow.ToString()]);
        oReview_Visa_Follows_DT.Visa_Emp_id = dr[Review_Visa_Follows_DT.EnumInfo_Visa_Follows.Visa_Emp_id.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Review_Visa_Follows_DT.EnumInfo_Visa_Follows.Visa_Emp_id.ToString()]);
        oReview_Visa_Follows_DT.File_data = dr[Review_Visa_Follows_DT.EnumInfo_Visa_Follows.File_data.ToString()] == DBNull.Value ? null : (Byte[])(dr[Review_Visa_Follows_DT.EnumInfo_Visa_Follows.File_data.ToString()]);
        oReview_Visa_Follows_DT.Descrption = dr[Review_Visa_Follows_DT.EnumInfo_Visa_Follows.Descrption.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Review_Visa_Follows_DT.EnumInfo_Visa_Follows.Descrption.ToString()]);
        oReview_Visa_Follows_DT.Date = dr[Review_Visa_Follows_DT.EnumInfo_Visa_Follows.Date.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Review_Visa_Follows_DT.EnumInfo_Visa_Follows.Date.ToString()]);
        oReview_Visa_Follows_DT.time_follow = dr[Review_Visa_Follows_DT.EnumInfo_Visa_Follows.time_follow.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Review_Visa_Follows_DT.EnumInfo_Visa_Follows.time_follow.ToString()]);
        oReview_Visa_Follows_DT.File_name = dr[Review_Visa_Follows_DT.EnumInfo_Visa_Follows.File_name.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Review_Visa_Follows_DT.EnumInfo_Visa_Follows.File_name.ToString()]);
        oReview_Visa_Follows_DT.File_ext = dr[Review_Visa_Follows_DT.EnumInfo_Visa_Follows.File_ext.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Review_Visa_Follows_DT.EnumInfo_Visa_Follows.File_ext.ToString()]);

        return oReview_Visa_Follows_DT;
    }

    private static SqlParameter[] GetParameters(Review_Visa_Follows_DT obj, bool isSearch)
    {
        SqlParameter[] parms = new SqlParameter[8];


        if (!isSearch)
        {

            parms[0] = new SqlParameter(Review_Visa_Follows_DT.EnumInfo_Visa_Follows.Follow_ID.ToString(), obj.Follow_ID);
            parms[0].Direction = ParameterDirection.InputOutput;

        }

        parms[1] = new SqlParameter(Review_Visa_Follows_DT.EnumInfo_Visa_Follows.Review_ID.ToString(), obj.Review_ID);

        parms[2] = new SqlParameter(Review_Visa_Follows_DT.EnumInfo_Visa_Follows.Visa_Emp_id.ToString(), obj.Visa_Emp_id);

        //parms[3] = new SqlParameter(Review_Visa_Follows_DT.EnumInfo_Visa_Follows.File_data.ToString(), obj.File_data);

        parms[3] = new SqlParameter(Review_Visa_Follows_DT.EnumInfo_Visa_Follows.Descrption.ToString(), obj.Descrption);

        parms[4] = new SqlParameter(Review_Visa_Follows_DT.EnumInfo_Visa_Follows.Date.ToString(), obj.Date);

        parms[5] = new SqlParameter(Review_Visa_Follows_DT.EnumInfo_Visa_Follows.time_follow.ToString(), obj.time_follow);

        parms[6] = new SqlParameter(Review_Visa_Follows_DT.EnumInfo_Visa_Follows.entery_pmp_id.ToString(), obj.entery_pmp_id);

        parms[7] = new SqlParameter(Review_Visa_Follows_DT.EnumInfo_Visa_Follows.Type_Follow.ToString(), obj.Type_Follow);

        //parms[6] = new SqlParameter(Review_Visa_Follows_DT.EnumInfo_Visa_Follows.File_name.ToString(), obj.File_name);

        //    parms[7] = new SqlParameter(Review_Visa_Follows_DT.EnumInfo_Visa_Follows.File_ext.ToString(), obj.File_ext);

        return parms;
    }

    #endregion

    #region DataBase Function

    public static int Save(Review_Visa_Follows_DT obj)
    {
        try
        {
            SqlParameter[] parms = GetParameters(obj, false);

            SqlHelper.ExecuteScalar(Database.ConnectionString, CommandType.StoredProcedure, "Review_Visa_Follows_Save", parms);
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
            SqlHelper.ExecuteNonQuery(Database.ConnectionString, "Review_Visa_Follows_Delete", ID);
            return ID;
        }
        catch (Exception ex)
        {
            return -1;
        }
    }

    public static DataTable SelectAll(int proj_proj_id)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Review_Visa_Follows_Select", proj_proj_id).Tables[0];

    }

    public static Review_Visa_Follows_DT SelectByID(int ID)
    {
        try
        {
            SqlDataReader drTableName;
            Review_Visa_Follows_DT obj = new Review_Visa_Follows_DT();
            if (ID > 0)
            {
                drTableName = SqlHelper.ExecuteReader(Database.ConnectionString, "Review_Visa_Follows_Select", ID);
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
