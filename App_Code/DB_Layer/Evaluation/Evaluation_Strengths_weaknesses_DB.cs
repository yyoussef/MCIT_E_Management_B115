using System;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for Evaluation_Strengths_weaknesses_DB
/// </summary>
public static class Evaluation_Strengths_weaknesses_DB
{
    #region "Private methods"

    private static Evaluation_Strengths_weaknesses_DT FillInfoObject(SqlDataReader dr)
    {

        Evaluation_Strengths_weaknesses_DT oEvaluation_Strengths_weaknesses_DT = new Evaluation_Strengths_weaknesses_DT();


        oEvaluation_Strengths_weaknesses_DT.Id = Convert.ToInt32(dr[Evaluation_Strengths_weaknesses_DT.EnumInfo_Strengths_weaknesses.Id.ToString()]);
        oEvaluation_Strengths_weaknesses_DT.Evaluation_id = dr[Evaluation_Strengths_weaknesses_DT.EnumInfo_Strengths_weaknesses.Evaluation_id.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Evaluation_Strengths_weaknesses_DT.EnumInfo_Strengths_weaknesses.Evaluation_id.ToString()]);
        oEvaluation_Strengths_weaknesses_DT.Direct_Emp_Note = dr[Evaluation_Strengths_weaknesses_DT.EnumInfo_Strengths_weaknesses.Direct_Emp_Note.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Evaluation_Strengths_weaknesses_DT.EnumInfo_Strengths_weaknesses.Direct_Emp_Note.ToString()]);
        oEvaluation_Strengths_weaknesses_DT.Top_Emp_Note = dr[Evaluation_Strengths_weaknesses_DT.EnumInfo_Strengths_weaknesses.Top_Emp_Note.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Evaluation_Strengths_weaknesses_DT.EnumInfo_Strengths_weaknesses.Top_Emp_Note.ToString()]);
        oEvaluation_Strengths_weaknesses_DT.type = dr[Evaluation_Strengths_weaknesses_DT.EnumInfo_Strengths_weaknesses.Evaluation_id.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Evaluation_Strengths_weaknesses_DT.EnumInfo_Strengths_weaknesses.type.ToString()]);
        return oEvaluation_Strengths_weaknesses_DT;
    }

    private static SqlParameter[] GetParameters(Evaluation_Strengths_weaknesses_DT obj, bool isSearch)
    {
        SqlParameter[] parms = new SqlParameter[5];


        if (!isSearch)
        {

            parms[0] = new SqlParameter(Evaluation_Strengths_weaknesses_DT.EnumInfo_Strengths_weaknesses.Id.ToString(), obj.Id);
            parms[0].Direction = ParameterDirection.InputOutput;

        }

        parms[1] = new SqlParameter(Evaluation_Strengths_weaknesses_DT.EnumInfo_Strengths_weaknesses.Evaluation_id.ToString(), obj.Evaluation_id);

        parms[2] = new SqlParameter(Evaluation_Strengths_weaknesses_DT.EnumInfo_Strengths_weaknesses.Direct_Emp_Note.ToString(), obj.Direct_Emp_Note);

        parms[3] = new SqlParameter(Evaluation_Strengths_weaknesses_DT.EnumInfo_Strengths_weaknesses.Top_Emp_Note.ToString(), obj.Top_Emp_Note);
        parms[4] = new SqlParameter(Evaluation_Strengths_weaknesses_DT.EnumInfo_Strengths_weaknesses.type.ToString(), obj.type);

        return parms;
    }

    #endregion

    public static int Save(Evaluation_Strengths_weaknesses_DT obj)
    {
        try
        {
            SqlParameter[] parms = GetParameters(obj, false);

            SqlHelper.ExecuteScalar(Database.ConnectionString, CommandType.StoredProcedure, "Evaluation_Strengths_weaknesses_Save", parms);
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
            SqlHelper.ExecuteNonQuery(Database.ConnectionString, "Evaluation_Strengths_weaknesses_Delete", ID);
            return ID;
        }
        catch (Exception ex)
        {
            return -1;
        }
    }


    public static DataTable Select_Evaluation_For_Employee(int pmp_id , int type)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Evaluation_Strengths_weaknesses_Select_by_Employee_Year", pmp_id ,type).Tables[0];

    }
    public static DataTable SelectAll(int Work_Order_ID)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Evaluation_Strengths_weaknesses_Select", 0, Work_Order_ID).Tables[0];

    }


    public static Evaluation_Strengths_weaknesses_DT SelectByID(int ID)
    {
        try
        {
            SqlDataReader drTableName;
            Evaluation_Strengths_weaknesses_DT obj = new Evaluation_Strengths_weaknesses_DT();
            if (ID > 0)
            {
                drTableName = SqlHelper.ExecuteReader(Database.ConnectionString, "Evaluation_Strengths_weaknesses_Select", ID, 0);
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
}
