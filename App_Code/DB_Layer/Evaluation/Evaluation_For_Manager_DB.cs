//////////////////////////////////////////////////////////////////////////////////////////
// Generated By:	MCIT\Matta using Mcit Generator
// Class Name:		Evaluation_For_Manager_DB
// Date Generated:	09-01-2013
//////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Data.SqlClient;
using System.Data;


    public static class Evaluation_For_Manager_DB
    {

        #region "Private methods"

        private static Evaluation_For_Manager_DT FillInfoObject(SqlDataReader dr)
        {

           Evaluation_For_Manager_DT obj_Evaluation_For_Manager_DT = new Evaluation_For_Manager_DT();

           
		obj_Evaluation_For_Manager_DT.Evaluation_id = Convert.ToInt32(dr[Evaluation_For_Manager_DT.Enum_Evaluation_For_Manager_DT.Evaluation_id.ToString()]);
		obj_Evaluation_For_Manager_DT.Pmp_Id = dr[Evaluation_For_Manager_DT.Enum_Evaluation_For_Manager_DT.Pmp_Id.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Evaluation_For_Manager_DT.Enum_Evaluation_For_Manager_DT.Pmp_Id.ToString()]);
		obj_Evaluation_For_Manager_DT.Month = dr[Evaluation_For_Manager_DT.Enum_Evaluation_For_Manager_DT.Month.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Evaluation_For_Manager_DT.Enum_Evaluation_For_Manager_DT.Month.ToString()]);
		obj_Evaluation_For_Manager_DT.Year = dr[Evaluation_For_Manager_DT.Enum_Evaluation_For_Manager_DT.Year.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Evaluation_For_Manager_DT.Enum_Evaluation_For_Manager_DT.Year.ToString()]);
		obj_Evaluation_For_Manager_DT.Evaluator_emp_ID = dr[Evaluation_For_Manager_DT.Enum_Evaluation_For_Manager_DT.Evaluator_emp_ID.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Evaluation_For_Manager_DT.Enum_Evaluation_For_Manager_DT.Evaluator_emp_ID.ToString()]);
		obj_Evaluation_For_Manager_DT.Finished = dr[Evaluation_For_Manager_DT.Enum_Evaluation_For_Manager_DT.Finished.ToString()] == DBNull.Value ? false : Convert.ToBoolean(dr[Evaluation_For_Manager_DT.Enum_Evaluation_For_Manager_DT.Finished.ToString()]);

           return obj_Evaluation_For_Manager_DT;
        }

        private static SqlParameter[] GetParameters(Evaluation_For_Manager_DT obj)
        {
            SqlParameter[] parms = new SqlParameter[6];
           
			
        

        parms[0] = new SqlParameter(Evaluation_For_Manager_DT.Enum_Evaluation_For_Manager_DT.Evaluation_id.ToString(), obj.Evaluation_id);
        parms[0].Direction = ParameterDirection.InputOutput;

        parms[1] = new SqlParameter(Evaluation_For_Manager_DT.Enum_Evaluation_For_Manager_DT.Pmp_Id.ToString(), obj.Pmp_Id);

        parms[2] = new SqlParameter(Evaluation_For_Manager_DT.Enum_Evaluation_For_Manager_DT.Month.ToString(), obj.Month);

        parms[3] = new SqlParameter(Evaluation_For_Manager_DT.Enum_Evaluation_For_Manager_DT.Year.ToString(), obj.Year);

        parms[4] = new SqlParameter(Evaluation_For_Manager_DT.Enum_Evaluation_For_Manager_DT.Evaluator_emp_ID.ToString(), obj.Evaluator_emp_ID);

        parms[5] = new SqlParameter(Evaluation_For_Manager_DT.Enum_Evaluation_For_Manager_DT.Finished.ToString(), obj.Finished);
            
            return parms;
        }

        #endregion

	    #region "DB methods"

        public static int Save(Evaluation_For_Manager_DT obj)
        {
            try
            {
                SqlParameter[] parms = GetParameters(obj);

                SqlHelper.ExecuteScalar(Database.ConnectionString, CommandType.StoredProcedure, "Evaluation_For_Manager_Save", parms);

             	    obj.Evaluation_id = Convert.ToInt32(parms[0].Value) ; 

           return obj.Evaluation_id ;
            }
            catch (Exception ex)
            {

                return -1;
            }
        }

        public static int Delete(int Evaluation_For_Manager_ID)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(Database.ConnectionString, "Evaluation_For_Manager_Delete", Evaluation_For_Manager_ID);
                return Evaluation_For_Manager_ID;
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
				 return SqlHelper.ExecuteDataset(Database.ConnectionString, "Evaluation_For_Manager_Select", 0).Tables[0];
		
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public static Evaluation_For_Manager_DT SelectByID(int Evaluation_For_Manager_ID, int Evaluator_emp_id)
        {
            try
            {
                if (Evaluation_For_Manager_ID > 0)
                {
                    SqlDataReader drTableName;
                    Evaluation_For_Manager_DT oInfo_Evaluation_For_Manager_DT = new Evaluation_For_Manager_DT();

                    drTableName = SqlHelper.ExecuteReader(Database.ConnectionString, "Evaluation_For_Manager_Select", Evaluation_For_Manager_ID, Evaluator_emp_id);
                    if (drTableName != null)
                    {
                        while (drTableName.Read())
                        {
                            oInfo_Evaluation_For_Manager_DT = FillInfoObject(drTableName);
                        }

                        drTableName.Close();
                    }
                    return oInfo_Evaluation_For_Manager_DT;
                }
                else
                    return new Evaluation_For_Manager_DT();
            }
            catch (Exception ex)
            {

                return null;
            }
        }
	#endregion



        public static DataTable Select_Evaluation_Manager_For_Employee_Mngr(int emp_id, int manager_id)
        {
            return SqlHelper.ExecuteDataset(Database.ConnectionString, "Evaluation_For_Manager_Select_by_Employee_Mngr", emp_id, manager_id).Tables[0];
        }

        public static DataTable Evaluation_Manager_Notesselect(int Evaluation_id, string note_type)
        {
            return SqlHelper.ExecuteDataset(Database.ConnectionString, "Evaluation_Manager_Notesselect", Evaluation_id, note_type).Tables[0];
        }

        public static DataTable Evaluation_Manager_DetailedDegrees(int input_emp_id)
        {
            return SqlHelper.ExecuteDataset(Database.ConnectionString, "Evaluation_Manager_DetailedDegrees", input_emp_id).Tables[0];
        }
        


             public static DataTable Evaluation_Items_Managernotexist(int Pmp_Id, int Evaluator_emp_ID)
        {
            return SqlHelper.ExecuteDataset(Database.ConnectionString, "Evaluation_Items_Managernotexist", Pmp_Id, Evaluator_emp_ID).Tables[0];
        }


             public static DataTable Get_EvaluationID(int Pmp_Id, int Evaluator_emp_ID)
             {
                 return SqlHelper.ExecuteDataset(Database.ConnectionString, "Get_empEvaluationID", Pmp_Id, Evaluator_emp_ID).Tables[0];
             }

    }

