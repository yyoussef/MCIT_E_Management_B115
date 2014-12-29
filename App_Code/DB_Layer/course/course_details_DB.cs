//////////////////////////////////////////////////////////////////////////////////////////
// Generated By:	MCIT-B51303A24F\Administrator using Mcit Generator
// Class Name:		course_details_DB
// Date Generated:	29-01-2012
//////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Data.SqlClient;
using System.Data;


public static class course_details_DB
{

    #region "Private methods"

    private static course_details_DT FillInfoObject(SqlDataReader dr)
    {

        course_details_DT obj_course_details_DT = new course_details_DT();


        obj_course_details_DT.id = Convert.ToInt32(dr[course_details_DT.Enum_course_details_DT.id.ToString()]);
        obj_course_details_DT.course_id = dr[course_details_DT.Enum_course_details_DT.course_id.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[course_details_DT.Enum_course_details_DT.course_id.ToString()]);
        obj_course_details_DT.start_date = dr[course_details_DT.Enum_course_details_DT.start_date.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[course_details_DT.Enum_course_details_DT.start_date.ToString()]);
        obj_course_details_DT.end_date = dr[course_details_DT.Enum_course_details_DT.end_date.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[course_details_DT.Enum_course_details_DT.end_date.ToString()]);
        obj_course_details_DT.place = dr[course_details_DT.Enum_course_details_DT.place.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[course_details_DT.Enum_course_details_DT.place.ToString()]);

        return obj_course_details_DT;
    }

    private static SqlParameter[] GetParameters(course_details_DT obj)
    {
        SqlParameter[] parms = new SqlParameter[5];




        parms[0] = new SqlParameter(course_details_DT.Enum_course_details_DT.id.ToString(), obj.id);
        parms[0].Direction = ParameterDirection.InputOutput;

        parms[1] = new SqlParameter(course_details_DT.Enum_course_details_DT.course_id.ToString(), obj.course_id);

        parms[2] = new SqlParameter(course_details_DT.Enum_course_details_DT.start_date.ToString(), obj.start_date);

        parms[3] = new SqlParameter(course_details_DT.Enum_course_details_DT.end_date.ToString(), obj.end_date);

        parms[4] = new SqlParameter(course_details_DT.Enum_course_details_DT.place.ToString(), obj.place);

        return parms;
    }

    #endregion

    #region "DB methods"

    public static int Save(course_details_DT obj)
    {
        try
        {
            SqlParameter[] parms = GetParameters(obj);

            SqlHelper.ExecuteScalar(Database.ConnectionString, CommandType.StoredProcedure, "course_details_Save", parms);
            return Convert.ToInt32(parms[0].Value);
        }
        catch (Exception ex)
        {

            return -1;
        }
    }

    public static int Delete(int course_details_ID)
    {
        try
        {
            SqlHelper.ExecuteNonQuery(Database.ConnectionString, "course_details_Delete", course_details_ID);
            return course_details_ID;
        }
        catch (Exception ex)
        {

            return -1;
        }
    }

    public static DataTable SelectAll()
    {
        try
        {
            return SqlHelper.ExecuteDataset(Database.ConnectionString, "course_details_Select", 0).Tables[0];

        }
        catch (Exception ex)
        {

            return null;
        }
    }

    public static course_details_DT SelectByID(int course_details_ID)
    {
        try
        {
            SqlDataReader drTableName;
            course_details_DT oInfo_course_details_DT = new course_details_DT();
            if (course_details_ID > 0)
            {


                drTableName = SqlHelper.ExecuteReader(Database.ConnectionString, "course_details_Select", course_details_ID);
                if (drTableName != null)
                {
                    while (drTableName.Read())
                    {
                        oInfo_course_details_DT = FillInfoObject(drTableName);
                    }

                    drTableName.Close();
                }
            }
            return oInfo_course_details_DT;
        }
        catch (Exception ex)
        {

            return null;
        }
    }


    public static course_details_DT SelectByCourseId(int course_ID)
    {
        try
        {
            SqlDataReader drTableName;
            course_details_DT oInfo_course_details_DT = new course_details_DT();

            drTableName = SqlHelper.ExecuteReader(Database.ConnectionString, "course_details_Select_ByCourseid ", course_ID);
            if (drTableName != null)
            {
                while (drTableName.Read())
                {
                    oInfo_course_details_DT = FillInfoObject(drTableName);
                }

                drTableName.Close();
            }
            return oInfo_course_details_DT;
        }
        catch (Exception ex)
        {

            return null;
        }
    }
    #endregion


}

