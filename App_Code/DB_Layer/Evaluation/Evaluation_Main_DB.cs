using System;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for Evaluation_Main_DT
/// </summary>
public static class Evaluation_Main_DB
{
    #region "Private methods"

    private static Evaluation_Main_DT FillInfoObject(SqlDataReader dr)
    {

        Evaluation_Main_DT oEvaluation_Main_DT = new Evaluation_Main_DT();


        oEvaluation_Main_DT.Id = Convert.ToInt32(dr[Evaluation_Main_DT.EnumInfo_Main.Id.ToString()]);
        oEvaluation_Main_DT.Evaluation_id = dr[Evaluation_Main_DT.EnumInfo_Main.Evaluation_id.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Evaluation_Main_DT.EnumInfo_Main.Evaluation_id.ToString()]);
        oEvaluation_Main_DT.Main_Item_Id = dr[Evaluation_Main_DT.EnumInfo_Main.Main_Item_Id.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Evaluation_Main_DT.EnumInfo_Main.Main_Item_Id.ToString()]);
        oEvaluation_Main_DT.Sub_Item_Id = dr[Evaluation_Main_DT.EnumInfo_Main.Sub_Item_Id.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Evaluation_Main_DT.EnumInfo_Main.Sub_Item_Id.ToString()]);
        oEvaluation_Main_DT.Direct_Emp_Degree_Id = dr[Evaluation_Main_DT.EnumInfo_Main.Direct_Emp_Degree_Id.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Evaluation_Main_DT.EnumInfo_Main.Direct_Emp_Degree_Id.ToString()]);
        oEvaluation_Main_DT.Top_Emp_Degree_Id = dr[Evaluation_Main_DT.EnumInfo_Main.Top_Emp_Degree_Id.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Evaluation_Main_DT.EnumInfo_Main.Top_Emp_Degree_Id.ToString()]);
        oEvaluation_Main_DT.Direct_Emp_Note = dr[Evaluation_Main_DT.EnumInfo_Main.Direct_Emp_Note.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Evaluation_Main_DT.EnumInfo_Main.Direct_Emp_Note.ToString()]);
        oEvaluation_Main_DT.Top_Emp_Note = dr[Evaluation_Main_DT.EnumInfo_Main.Top_Emp_Note.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Evaluation_Main_DT.EnumInfo_Main.Top_Emp_Note.ToString()]);
        oEvaluation_Main_DT.HR_Note = dr[Evaluation_Main_DT.EnumInfo_Main.HR_Note.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Evaluation_Main_DT.EnumInfo_Main.HR_Note.ToString()]);
        oEvaluation_Main_DT.Direct_Emp_Degree = dr[Evaluation_Main_DT.EnumInfo_Main.Direct_Emp_Degree.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Evaluation_Main_DT.EnumInfo_Main.Direct_Emp_Degree.ToString()]);
        oEvaluation_Main_DT.Top_Emp_Degree = dr[Evaluation_Main_DT.EnumInfo_Main.Top_Emp_Degree.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Evaluation_Main_DT.EnumInfo_Main.Top_Emp_Degree.ToString()]);


        return oEvaluation_Main_DT;
    }

    private static SqlParameter[] GetParameters(Evaluation_Main_DT obj, bool isSearch)
    {
        SqlParameter[] parms = new SqlParameter[11];


        if (!isSearch)
        {

            parms[0] = new SqlParameter(Evaluation_Main_DT.EnumInfo_Main.Id.ToString(), obj.Id);
            parms[0].Direction = ParameterDirection.InputOutput;

        }

        parms[1] = new SqlParameter(Evaluation_Main_DT.EnumInfo_Main.Evaluation_id.ToString(), obj.Evaluation_id);

        parms[2] = new SqlParameter(Evaluation_Main_DT.EnumInfo_Main.Main_Item_Id.ToString(), obj.Main_Item_Id);

        parms[3] = new SqlParameter(Evaluation_Main_DT.EnumInfo_Main.Sub_Item_Id.ToString(), obj.Sub_Item_Id);

        if (obj.Direct_Emp_Degree_Id == 0)
            parms[4] = new SqlParameter(Evaluation_Main_DT.EnumInfo_Main.Direct_Emp_Degree_Id.ToString(), DBNull.Value);
        else
        parms[4] = new SqlParameter(Evaluation_Main_DT.EnumInfo_Main.Direct_Emp_Degree_Id.ToString(), obj.Direct_Emp_Degree_Id);

        if (obj.Top_Emp_Degree_Id == 0)
            parms[5] = new SqlParameter(Evaluation_Main_DT.EnumInfo_Main.Top_Emp_Degree_Id.ToString(), DBNull.Value);
        else
            parms[5] = new SqlParameter(Evaluation_Main_DT.EnumInfo_Main.Top_Emp_Degree_Id.ToString(), obj.Top_Emp_Degree_Id);

        parms[6] = new SqlParameter(Evaluation_Main_DT.EnumInfo_Main.Direct_Emp_Note.ToString(), obj.Direct_Emp_Note);

        parms[7] = new SqlParameter(Evaluation_Main_DT.EnumInfo_Main.Top_Emp_Note.ToString(), obj.Top_Emp_Note);

        parms[8] = new SqlParameter(Evaluation_Main_DT.EnumInfo_Main.HR_Note.ToString(), obj.HR_Note);

        parms[9] = new SqlParameter(Evaluation_Main_DT.EnumInfo_Main.Direct_Emp_Degree.ToString(), obj.Direct_Emp_Degree);
        parms[10] = new SqlParameter(Evaluation_Main_DT.EnumInfo_Main.Top_Emp_Degree.ToString(), obj.Top_Emp_Degree);
        return parms;
    }

    #endregion

    public static int Save(Evaluation_Main_DT obj)
    {
        try
        {
            SqlParameter[] parms = GetParameters(obj, false);

            SqlHelper.ExecuteScalar(Database.ConnectionString, CommandType.StoredProcedure, "Evaluation_Main_Save", parms);
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
            SqlHelper.ExecuteNonQuery(Database.ConnectionString, "Evaluation_Main_Delete", ID);
            return ID;
        }
        catch (Exception ex)
        {
            return -1;
        }
    }

    public static int Evaluation_Main_DeletebyID(int Evaluation_id)
    {
        try
        {
            SqlHelper.ExecuteNonQuery(Database.ConnectionString, "Evaluation_Main_DeletebyID", Evaluation_id);
            return Evaluation_id;
        }
        catch (Exception ex)
        {
            return -1;
        }
    }


    public static DataTable SelectAll(int Work_Order_ID)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Evaluation_Main_Select", 0, Work_Order_ID).Tables[0];

    }


    public static Evaluation_Main_DT SelectByID(int ID)
    {
        try
        {
            SqlDataReader drTableName;
            Evaluation_Main_DT obj = new Evaluation_Main_DT();
            if (ID > 0)
            {
                drTableName = SqlHelper.ExecuteReader(Database.ConnectionString, "Evaluation_Main_Select", ID, 0);
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


    public static DataTable Select_Employee_Managers(int Emp_ID, int Mngr_Level)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Employee_Managers_Selectbyid",Emp_ID,Mngr_Level).Tables[0];

    }

    public static DataTable Evaluation_Employee_Finished(int Pmp_Id, int Evaluator_emp_ID)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Evaluation_For_Employee_Finishedselect", Pmp_Id , Evaluator_emp_ID).Tables[0];

    }

    public static DataTable Get_Weakness_Strengths(int Pmp_Id, int type, int Evaluator_emp_ID)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Get_Weakness_Strengths", Pmp_Id, type, Evaluator_emp_ID).Tables[0];

    }

    public static DataTable check_dept_category(int employee_id)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Evaluation_Dept_Weightselect", employee_id).Tables[0];

    }


    public static DataTable Get_Training_Needs(int Pmp_Id, int Evaluator_emp_ID)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Get_Training_Needs", Pmp_Id, Evaluator_emp_ID).Tables[0];

    }
    public static DataTable Set_Hr_Last_Eval_ID(int pmp_id)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Set_Hr_Last_Eval_ID", pmp_id).Tables[0];

    }

    public static DataTable Fill_Weakness_HR(int pmp_id)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Fill_Weakness_HR", pmp_id).Tables[0];

    }

    public static DataTable Get_Eval_Employee_Strengths(int pmp_id)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Get_Eval_Employee_Strengths", pmp_id).Tables[0];

    }

    public static DataTable Get_Eval_Employee_Training_needs(int pmp_id)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Get_Eval_Employee_Training_needs", pmp_id).Tables[0];

    }


}
