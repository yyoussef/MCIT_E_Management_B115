using System;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for Evaluation_Training_Needs_DB
/// </summary>
public static class Evaluation_Training_Needs_DB
{
    #region "Private methods"

    private static Evaluation_Training_Needs_DT FillInfoObject(SqlDataReader dr)
    {

        Evaluation_Training_Needs_DT oEvaluation_Training_Needs_DT = new Evaluation_Training_Needs_DT();


        oEvaluation_Training_Needs_DT.Id = Convert.ToInt32(dr[Evaluation_Training_Needs_DT.EnumInfo_Training_Needs.Id.ToString()]);
        oEvaluation_Training_Needs_DT.Evaluation_id = dr[Evaluation_Training_Needs_DT.EnumInfo_Training_Needs.Evaluation_id.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Evaluation_Training_Needs_DT.EnumInfo_Training_Needs.Evaluation_id.ToString()]);
        oEvaluation_Training_Needs_DT.Name = dr[Evaluation_Training_Needs_DT.EnumInfo_Training_Needs.Name.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Evaluation_Training_Needs_DT.EnumInfo_Training_Needs.Name.ToString()]);
        oEvaluation_Training_Needs_DT.Direct_Emp_Note = dr[Evaluation_Training_Needs_DT.EnumInfo_Training_Needs.Direct_Emp_Note.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Evaluation_Training_Needs_DT.EnumInfo_Training_Needs.Direct_Emp_Note.ToString()]);
        oEvaluation_Training_Needs_DT.Eval_Course_Id = dr[Evaluation_Training_Needs_DT.EnumInfo_Training_Needs.Evaluation_id.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Evaluation_Training_Needs_DT.EnumInfo_Training_Needs.Eval_Course_Id.ToString()]);
        oEvaluation_Training_Needs_DT.Top_Emp_Note = dr[Evaluation_Training_Needs_DT.EnumInfo_Training_Needs.Top_Emp_Note.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Evaluation_Training_Needs_DT.EnumInfo_Training_Needs.Top_Emp_Note.ToString()]);

        return oEvaluation_Training_Needs_DT;
    }

    private static SqlParameter[] GetParameters(Evaluation_Training_Needs_DT obj, bool isSearch)
    {
        SqlParameter[] parms = new SqlParameter[6];


        if (!isSearch)
        {

            parms[0] = new SqlParameter(Evaluation_Training_Needs_DT.EnumInfo_Training_Needs.Id.ToString(), obj.Id);
            parms[0].Direction = ParameterDirection.InputOutput;

        }

        parms[1] = new SqlParameter(Evaluation_Training_Needs_DT.EnumInfo_Training_Needs.Evaluation_id.ToString(), obj.Evaluation_id);

        parms[2] = new SqlParameter(Evaluation_Training_Needs_DT.EnumInfo_Training_Needs.Name.ToString(), obj.Name);

        parms[3] = new SqlParameter(Evaluation_Training_Needs_DT.EnumInfo_Training_Needs.Direct_Emp_Note.ToString(), obj.Direct_Emp_Note);

        parms[4] = new SqlParameter(Evaluation_Training_Needs_DT.EnumInfo_Training_Needs.Eval_Course_Id.ToString(), obj.Eval_Course_Id);

        parms[5] = new SqlParameter(Evaluation_Training_Needs_DT.EnumInfo_Training_Needs.Top_Emp_Note.ToString(), obj.Top_Emp_Note);

        return parms;
    }

    #endregion

    public static int Save(Evaluation_Training_Needs_DT obj)
    {
        try
        {
            SqlParameter[] parms = GetParameters(obj, false);

            SqlHelper.ExecuteScalar(Database.ConnectionString, CommandType.StoredProcedure, "Evaluation_Training_Needs_Save", parms);
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
            SqlHelper.ExecuteNonQuery(Database.ConnectionString, "Evaluation_Training_Needs_Delete", ID);
            return ID;
        }
        catch (Exception ex)
        {
            return -1;
        }
    }

    public static DataTable SelectAll(int Work_Order_ID)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Evaluation_Training_Needs_Select", 0, Work_Order_ID).Tables[0];

    }

    public static Evaluation_Training_Needs_DT SelectByID(int ID)
    {
        try
        {
            SqlDataReader drTableName;
            Evaluation_Training_Needs_DT obj = new Evaluation_Training_Needs_DT();
            if (ID > 0)
            {
                drTableName = SqlHelper.ExecuteReader(Database.ConnectionString, "Evaluation_Training_Needs_Select", ID, 0);
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

    public static DataTable Select_Evaluation_For_Employee(int pmp_id)
    {
        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Evaluation_Training_Needs_Select_by_Employee_Year", pmp_id).Tables[0];
    }
}
