//////////////////////////////////////////////////////////////////////////////////////////
// Generated By:	MCIT\Matta using Mcit Generator
// Class Name:		Employee_Groups_DB
// Date Generated:	26-09-2012
//////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Data.SqlClient;
using System.Data;


    public static class Employee_Groups_DB
    {

        #region "Private methods"

        private static Employee_Groups_DT FillInfoObject(SqlDataReader dr)
        {

           Employee_Groups_DT obj_Employee_Groups_DT = new Employee_Groups_DT();

           
		obj_Employee_Groups_DT.ID = Convert.ToInt64(dr[Employee_Groups_DT.Enum_Employee_Groups_DT.ID.ToString()]);
		obj_Employee_Groups_DT.Name = dr[Employee_Groups_DT.Enum_Employee_Groups_DT.Name.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Employee_Groups_DT.Enum_Employee_Groups_DT.Name.ToString()]);
        obj_Employee_Groups_DT.foundation_id = dr[Employee_Groups_DT.Enum_Employee_Groups_DT.foundation_id.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Employee_Groups_DT.Enum_Employee_Groups_DT.foundation_id.ToString()]);

           return obj_Employee_Groups_DT;
        }

        private static SqlParameter[] GetParameters(Employee_Groups_DT obj)
        {
            SqlParameter[] parms = new SqlParameter[3];
           
			
        

        parms[0] = new SqlParameter(Employee_Groups_DT.Enum_Employee_Groups_DT.ID.ToString(), obj.ID);
        parms[0].Direction = ParameterDirection.InputOutput;

        parms[1] = new SqlParameter(Employee_Groups_DT.Enum_Employee_Groups_DT.Name.ToString(), obj.Name);

        parms[2] = new SqlParameter(Employee_Groups_DT.Enum_Employee_Groups_DT.foundation_id.ToString(), obj.foundation_id);
            
            return parms;
        }

        #endregion

	    #region "DB methods"

        public static int Save(Employee_Groups_DT obj)
        {
            try
            {
                SqlParameter[] parms = GetParameters(obj);

                SqlHelper.ExecuteScalar(Database.ConnectionString, CommandType.StoredProcedure, "Employee_Groups_Save", parms);

             	    obj.ID = Convert.ToInt32(parms[0].Value) ; 

           return Convert.ToInt32(obj.ID) ;
            }
            catch (Exception ex)
            {

                return -1;
            }
        }

        public static int Delete(int Employee_Groups_ID)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(Database.ConnectionString, "Employee_Groups_Delete", Employee_Groups_ID);
                return Employee_Groups_ID;
            }
            catch (Exception ex)
            {

                return -1;
            }
        }

        public static DataTable SelectAll(int found_id)
        {
            try
            {
				 return SqlHelper.ExecuteDataset(Database.ConnectionString, "Employee_Groups_Select", 0,found_id).Tables[0];
		
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public static Employee_Groups_DT SelectByID(int Employee_Groups_ID,int found_id)
        {
            try
            {
              if (Employee_Groups_ID > 0)
                {
                SqlDataReader drTableName;
                Employee_Groups_DT oInfo_Employee_Groups_DT = new Employee_Groups_DT();

                drTableName = SqlHelper.ExecuteReader(Database.ConnectionString, "Employee_Groups_Select", Employee_Groups_ID,found_id);
                if (drTableName != null)
                {
                    while (drTableName.Read())
                    {
                        oInfo_Employee_Groups_DT = FillInfoObject(drTableName);
                    }

                    drTableName.Close();
                }
                return oInfo_Employee_Groups_DT;
               }
                else
                    return new Employee_Groups_DT();
            }
            catch (Exception ex)
            {

                return null;
            }
        }
	#endregion


    }

