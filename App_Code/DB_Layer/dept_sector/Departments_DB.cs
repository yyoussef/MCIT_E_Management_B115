//////////////////////////////////////////////////////////////////////////////////////////
// Generated By:	MCIT\Matta using Mcit Generator
// Class Name:		Departments_DB
// Date Generated:	12-11-2012
//////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Data.SqlClient;
using System.Data;


    public static class Departments_DB
    {

        #region "Private methods"

        private static Departments_DT FillInfoObject(SqlDataReader dr)
        {

           Departments_DT obj_Departments_DT = new Departments_DT();

           
		obj_Departments_DT.Dept_id = Convert.ToInt64(dr[Departments_DT.Enum_Departments_DT.Dept_id.ToString()]);
		obj_Departments_DT.Dept_type = dr[Departments_DT.Enum_Departments_DT.Dept_type.ToString()] == DBNull.Value ? Convert.ToInt64(null) : Convert.ToInt64(dr[Departments_DT.Enum_Departments_DT.Dept_type.ToString()]);
        obj_Departments_DT.Dept_parent_id = dr[Departments_DT.Enum_Departments_DT.Dept_parent_id.ToString()] == DBNull.Value ? Convert.ToInt64(null) : Convert.ToInt64(dr[Departments_DT.Enum_Departments_DT.Dept_parent_id.ToString()]);
        obj_Departments_DT.Sec_sec_id = dr[Departments_DT.Enum_Departments_DT.Sec_sec_id.ToString()] == DBNull.Value ? Convert.ToInt64(null) : Convert.ToInt64(dr[Departments_DT.Enum_Departments_DT.Sec_sec_id.ToString()]);
		obj_Departments_DT.Dept_name = dr[Departments_DT.Enum_Departments_DT.Dept_name.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Departments_DT.Enum_Departments_DT.Dept_name.ToString()]);
        obj_Departments_DT.foundation_id = dr[Departments_DT.Enum_Departments_DT.foundation_id.ToString()] == DBNull.Value ? Convert.ToInt32(null) : Convert.ToInt32(dr[Departments_DT.Enum_Departments_DT.foundation_id.ToString()]);

           return obj_Departments_DT;
        }

        private static SqlParameter[] GetParameters(Departments_DT obj)
        {
            SqlParameter[] parms = new SqlParameter[6];
           
			
        

        parms[0] = new SqlParameter(Departments_DT.Enum_Departments_DT.Dept_id.ToString(), obj.Dept_id);
        parms[0].Direction = ParameterDirection.InputOutput;

        parms[1] = new SqlParameter(Departments_DT.Enum_Departments_DT.Dept_type.ToString(), obj.Dept_type);

        parms[2] = new SqlParameter(Departments_DT.Enum_Departments_DT.Dept_parent_id.ToString(), obj.Dept_parent_id);

        parms[3] = new SqlParameter(Departments_DT.Enum_Departments_DT.Sec_sec_id.ToString(), obj.Sec_sec_id);

        parms[4] = new SqlParameter(Departments_DT.Enum_Departments_DT.Dept_name.ToString(), obj.Dept_name);

        parms[5] = new SqlParameter(Departments_DT.Enum_Departments_DT.foundation_id.ToString(), obj.foundation_id ); 
            return parms;
        }

        #endregion

	    #region "DB methods"

        public static int Save(Departments_DT obj)
        {
            try
            {
                SqlParameter[] parms = GetParameters(obj);

                SqlHelper.ExecuteScalar(Database.ConnectionString, CommandType.StoredProcedure, "Departments_Save", parms);

             	    obj.Dept_id = Convert.ToInt32(parms[0].Value) ; 

           return Convert.ToInt32(obj.Dept_id );
            }
            catch (Exception ex)
            {

                return -1;
            }
        }

        public static int Delete(int Departments_ID)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(Database.ConnectionString, "Departments_Delete", Departments_ID);
                return Departments_ID;
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
				 return SqlHelper.ExecuteDataset(Database.ConnectionString, "Departments_Select", 0).Tables[0];
		
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        

        public static Departments_DT SelectByFoundationID(int FoundationID)
        {
            try
            {
                if (FoundationID > 0)
                {
                    SqlDataReader drTableName;
                    Departments_DT oInfo_Departments_DT = new Departments_DT();

                    drTableName = SqlHelper.ExecuteReader(Database.ConnectionString, "Departemnts_Select_ByFoundation", FoundationID);
                    if (drTableName != null)
                    {
                        while (drTableName.Read())
                        {
                            oInfo_Departments_DT = FillInfoObject(drTableName);
                        }

                        drTableName.Close();
                    }
                    return oInfo_Departments_DT;
                }
                else
                    return new Departments_DT();
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public static Departments_DT SelectByID(int Departments_ID)
        {
            try
            {
              if (Departments_ID > 0)
                {
                SqlDataReader drTableName;
                Departments_DT oInfo_Departments_DT = new Departments_DT();

                drTableName = SqlHelper.ExecuteReader(Database.ConnectionString, "Departments_Select", Departments_ID);
                if (drTableName != null)
                {
                    while (drTableName.Read())
                    {
                        oInfo_Departments_DT = FillInfoObject(drTableName);
                    }

                    drTableName.Close();
                }
                return oInfo_Departments_DT;
               }
                else
                    return new Departments_DT();
            }
            catch (Exception ex)
            {

                return null;
            }
        }
	#endregion


    }

