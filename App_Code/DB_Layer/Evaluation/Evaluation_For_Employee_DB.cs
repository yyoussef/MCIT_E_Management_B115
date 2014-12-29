using System;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for Evaluation_For_Employee_DB
/// </summary>
public static class Evaluation_For_Employee_DB
{
    #region "Private methods"

    private static Evaluation_For_Employee_DT FillInfoObject(SqlDataReader dr)
    {

        Evaluation_For_Employee_DT oEvaluation_For_Employee_DT = new Evaluation_For_Employee_DT();


        oEvaluation_For_Employee_DT.Evaluation_id = Convert.ToInt32(dr[Evaluation_For_Employee_DT.EnumInfo_For_Employee.Evaluation_id.ToString()]);
        oEvaluation_For_Employee_DT.Pmp_Id = dr[Evaluation_For_Employee_DT.EnumInfo_For_Employee.Pmp_Id.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Evaluation_For_Employee_DT.EnumInfo_For_Employee.Pmp_Id.ToString()]);
        oEvaluation_For_Employee_DT.Month = dr[Evaluation_For_Employee_DT.EnumInfo_For_Employee.Month.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Evaluation_For_Employee_DT.EnumInfo_For_Employee.Month.ToString()]);
        oEvaluation_For_Employee_DT.Year = dr[Evaluation_For_Employee_DT.EnumInfo_For_Employee.Year.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Evaluation_For_Employee_DT.EnumInfo_For_Employee.Year.ToString()]);
        oEvaluation_For_Employee_DT.Direct_Mng_Finished = dr[Evaluation_For_Employee_DT.EnumInfo_For_Employee.Direct_Mng_Finished.ToString()] == DBNull.Value ? false : Convert.ToBoolean(dr[Evaluation_For_Employee_DT.EnumInfo_For_Employee.Direct_Mng_Finished.ToString()]);
        oEvaluation_For_Employee_DT.Top_Mng_Finished = dr[Evaluation_For_Employee_DT.EnumInfo_For_Employee.Top_Mng_Finished.ToString()] == DBNull.Value ? false : Convert.ToBoolean(dr[Evaluation_For_Employee_DT.EnumInfo_For_Employee.Top_Mng_Finished.ToString()]);
        oEvaluation_For_Employee_DT.Evaluator_emp_ID = dr[Evaluation_For_Employee_DT.EnumInfo_For_Employee.Evaluator_emp_ID.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Evaluation_For_Employee_DT.EnumInfo_For_Employee.Evaluator_emp_ID.ToString()]);


        return oEvaluation_For_Employee_DT;
    }

    private static SqlParameter[] GetParameters(Evaluation_For_Employee_DT obj, bool isSearch)
    {
        SqlParameter[] parms = new SqlParameter[7];


        if (!isSearch)
        {

            parms[0] = new SqlParameter(Evaluation_For_Employee_DT.EnumInfo_For_Employee.Evaluation_id.ToString(), obj.Evaluation_id);
            parms[0].Direction = ParameterDirection.InputOutput;

        }

        parms[1] = new SqlParameter(Evaluation_For_Employee_DT.EnumInfo_For_Employee.Pmp_Id.ToString(), obj.Pmp_Id);

        parms[2] = new SqlParameter(Evaluation_For_Employee_DT.EnumInfo_For_Employee.Month.ToString(), obj.Month);

        parms[3] = new SqlParameter(Evaluation_For_Employee_DT.EnumInfo_For_Employee.Year.ToString(), obj.Year);

        parms[4] = new SqlParameter(Evaluation_For_Employee_DT.EnumInfo_For_Employee.Direct_Mng_Finished.ToString(), obj.Direct_Mng_Finished);

        parms[5] = new SqlParameter(Evaluation_For_Employee_DT.EnumInfo_For_Employee.Top_Mng_Finished.ToString(), obj.Top_Mng_Finished);

        parms[6] = new SqlParameter(Evaluation_For_Employee_DT.EnumInfo_For_Employee.Evaluator_emp_ID.ToString(), obj.Evaluator_emp_ID);


        return parms;
    }

    #endregion

    public static int Save(Evaluation_For_Employee_DT obj)
    {
        try
        {
            SqlParameter[] parms = GetParameters(obj, false);

            SqlHelper.ExecuteScalar(Database.ConnectionString, CommandType.StoredProcedure, "Evaluation_For_Employee_Save", parms);
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
            SqlHelper.ExecuteNonQuery(Database.ConnectionString, "Evaluation_For_Employee_Delete", ID);
            return ID;
        }
        catch (Exception ex)
        {
            return -1;
        }
    }

    public static void Clear_for_emp(int pmp_id, int mngr_ID)
    {
        //commented by Eng.:MaHmOuD
        //string sql = "select * from Evaluation_For_Employee where Pmp_Id =" + pmp_id + " and Year = "+DateTime.Now.Year;
        string sql =
        "SELECT *" + "\r\n" +
        "  FROM    Evaluation_For_Employee" + "\r\n" +
        "       LEFT JOIN" + "\r\n" +
        "          Employee_Managers" + "\r\n" +
        "       ON Employee_Managers.Mngr_Emp_ID =" + "\r\n" +
        "             dbo.Evaluation_For_Employee.Evaluator_emp_ID" + "\r\n" +
        " where Pmp_Id =" + pmp_id + " and Year = " + CDataConverter.ConvertDateTimeNowRtnDt().Year + " AND Employee_Managers.Mngr_Emp_ID = " + mngr_ID;

        DataTable dt = General_Helping.GetDataTable(sql);

        if (dt.Rows.Count > 0)
        {
            string eval_id = dt.Rows[0]["Evaluation_id"].ToString();

            string sql_Delete = "";//"delete from Evaluation_For_Employee where Evaluation_id = "+eval_id;
            sql_Delete += "  delete from Evaluation_Main where Evaluation_id = " + eval_id;
            sql_Delete += "  delete from Evaluation_Strengths_weaknesses where Evaluation_id = " + eval_id;
            sql_Delete += "  delete from Evaluation_Training_Needs where Evaluation_id = " + eval_id;

            General_Helping.ExcuteQuery(sql_Delete);

        }
    }

    public static DataTable SelectAll(int Work_Order_ID)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Evaluation_For_Employee_Select", 0, Work_Order_ID).Tables[0];

    }

    public static DataTable Select_Emp_Info(int pmp_ID)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Evaluation_For_Employee_Select_Info", pmp_ID).Tables[0];

    }

    public static DataTable Select_Evaluation_For_Employee(int pmp_ID)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Evaluation_For_Employee_Select_by_Employee_Year", pmp_ID).Tables[0];

    }

    public static DataTable Select_Evaluation_For_Employee_Mngr(int pmp_ID, int mngr_ID)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Evaluation_For_Employee_Select_by_Employee_Mngr", pmp_ID, mngr_ID).Tables[0];

    }

    public static DataTable Get_EvaluationID(int Pmp_Id, int Evaluator_emp_ID)
    {
        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Get_empEvaluationID", Pmp_Id, Evaluator_emp_ID).Tables[0];
    }

    public static DataTable Evaluationemp_Items_Managernotexist(int Pmp_Id, int Evaluator_emp_ID)
    {
        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Evaluationemp_Items_Managernotexist", Pmp_Id, Evaluator_emp_ID).Tables[0];
    }


    public static Evaluation_For_Employee_DT SelectByID(int ID)
    {
        try
        {
            SqlDataReader drTableName;
            Evaluation_For_Employee_DT obj = new Evaluation_For_Employee_DT();
            if (ID > 0)
            {
                drTableName = SqlHelper.ExecuteReader(Database.ConnectionString, "Evaluation_For_Employee_Select", ID, 0);
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

    public static Evaluation_For_Employee_DT SelectBypmpID(int ID)
    {
        try
        {
            SqlDataReader drTableName;
            Evaluation_For_Employee_DT obj = new Evaluation_For_Employee_DT();

            drTableName = SqlHelper.ExecuteReader(Database.ConnectionString, "Evaluation_For_Employee_Select_by_pmp", ID);
            if (drTableName != null)
            {
                while (drTableName.Read())
                {
                    obj = FillInfoObject(drTableName);
                }

                drTableName.Close();
            }
            return obj;
        }
        catch (Exception ex)
        {

            return null;
        }
    }

    public static Evaluation_For_Employee_DT Select_By_EmpID_And_MngrID(int pmp_id, int mngr_ID)
    {
        try
        {
            SqlDataReader drTableName;
            Evaluation_For_Employee_DT obj = new Evaluation_For_Employee_DT();

            drTableName = SqlHelper.ExecuteReader(Database.ConnectionString, "dbo.Evaluation_For_Employee_Select_by_pmp_Mngr", pmp_id, mngr_ID);
            if (drTableName != null)
            {
                while (drTableName.Read())
                {
                    obj = FillInfoObject(drTableName);
                }

                drTableName.Close();
            }
            return obj;
        }
        catch (Exception ex)
        {

            throw ex;
        }


    }

}
