//////////////////////////////////////////////////////////////////////////////////////////
// Generated By:	MCIT\tmeltaweel using Mcit Generator
// Class Name:		Employee_Managers_DB
// Date Generated:	19-04-2012
//////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Data.SqlClient;
using System.Data;


    public static class Employee_Managers_DB
    {

        #region "Private methods"

        private static Employee_Managers_DT FillInfoObject(SqlDataReader dr)
        {

           Employee_Managers_DT obj_Employee_Managers_DT = new Employee_Managers_DT();

           
		obj_Employee_Managers_DT.Emp_Mngr_ID = Convert.ToInt32(dr[Employee_Managers_DT.Enum_Employee_Managers_DT.Emp_Mngr_ID.ToString()]);
		obj_Employee_Managers_DT.Emp_ID = dr[Employee_Managers_DT.Enum_Employee_Managers_DT.Emp_ID.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Employee_Managers_DT.Enum_Employee_Managers_DT.Emp_ID.ToString()]);
		obj_Employee_Managers_DT.Mngr_Emp_ID = dr[Employee_Managers_DT.Enum_Employee_Managers_DT.Mngr_Emp_ID.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Employee_Managers_DT.Enum_Employee_Managers_DT.Mngr_Emp_ID.ToString()]);
		obj_Employee_Managers_DT.Mngr_Level = dr[Employee_Managers_DT.Enum_Employee_Managers_DT.Mngr_Level.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Employee_Managers_DT.Enum_Employee_Managers_DT.Mngr_Level.ToString()]);

           return obj_Employee_Managers_DT;
        }

        private static SqlParameter[] GetParameters(Employee_Managers_DT obj)
        {
            SqlParameter[] parms = new SqlParameter[4];
           
			
        

        parms[0] = new SqlParameter(Employee_Managers_DT.Enum_Employee_Managers_DT.Emp_Mngr_ID.ToString(), obj.Emp_Mngr_ID);
        parms[0].Direction = ParameterDirection.InputOutput;

        parms[1] = new SqlParameter(Employee_Managers_DT.Enum_Employee_Managers_DT.Emp_ID.ToString(), obj.Emp_ID);

        parms[2] = new SqlParameter(Employee_Managers_DT.Enum_Employee_Managers_DT.Mngr_Emp_ID.ToString(), obj.Mngr_Emp_ID);

        parms[3] = new SqlParameter(Employee_Managers_DT.Enum_Employee_Managers_DT.Mngr_Level.ToString(), obj.Mngr_Level);
            
            return parms;
        }

        #endregion

	    #region "DB methods"

        public static int Save(Employee_Managers_DT obj)
        {
            try
            {
                SqlParameter[] parms = GetParameters(obj);

                SqlHelper.ExecuteScalar(Database.ConnectionString, CommandType.StoredProcedure, "Employee_Managers_Save", parms);

             	    obj.Emp_Mngr_ID = Convert.ToInt32(parms[0].Value) ; 

           return obj.Emp_Mngr_ID ;
            }
            catch (Exception ex)
            {

                return -1;
            }
        }

        public static int Delete(int Employee_Managers_ID)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(Database.ConnectionString, "Employee_Managers_Delete", Employee_Managers_ID);
                return Employee_Managers_ID;
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
				 return SqlHelper.ExecuteDataset(Database.ConnectionString, "Employee_Managers_Select", 0).Tables[0];
		
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public static DataTable Selectby_EmpId(int PMP_ID, int Mngr_Level)
        {
            try
            {
                return SqlHelper.ExecuteDataset(Database.ConnectionString, "Employee_Managers_SelectbyEmpId", PMP_ID, Mngr_Level).Tables[0];

            }
            catch (Exception ex)
            {

                return null;
            }
        }


        public static Employee_Managers_DT SelectByID(int Employee_Managers_ID)
        {
            try
            {
              if (Employee_Managers_ID > 0)
                {
                SqlDataReader drTableName;
                Employee_Managers_DT oInfo_Employee_Managers_DT = new Employee_Managers_DT();

                drTableName = SqlHelper.ExecuteReader(Database.ConnectionString, "Employee_Managers_Select", Employee_Managers_ID);
                if (drTableName != null)
                {
                    while (drTableName.Read())
                    {
                        oInfo_Employee_Managers_DT = FillInfoObject(drTableName);
                    }

                    drTableName.Close();
                }
                return oInfo_Employee_Managers_DT;
               }
                else
                    return new Employee_Managers_DT();
            }
            catch (Exception ex)
            {

                return null;
            }
        }
	#endregion


    }

