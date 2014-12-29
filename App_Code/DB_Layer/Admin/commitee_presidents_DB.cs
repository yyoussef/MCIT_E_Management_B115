//////////////////////////////////////////////////////////////////////////////////////////
// Generated By:	MCIT\MElshahed using Mcit Generator
// Class Name:		commitee_presidents_DB
// Date Generated:	27-09-2012
//////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Data.SqlClient;
using System.Data;


    public static class commitee_presidents_DB
    {

        #region "Private methods"

        private static commitee_presidents_DT FillInfoObject(SqlDataReader dr)
        {

           commitee_presidents_DT obj_commitee_presidents_DT = new commitee_presidents_DT();

           
		obj_commitee_presidents_DT.id = Convert.ToInt32(dr[commitee_presidents_DT.Enum_commitee_presidents_DT.id.ToString()]);
		obj_commitee_presidents_DT.pmp_id = dr[commitee_presidents_DT.Enum_commitee_presidents_DT.pmp_id.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[commitee_presidents_DT.Enum_commitee_presidents_DT.pmp_id.ToString()]);
		obj_commitee_presidents_DT.comt_id = dr[commitee_presidents_DT.Enum_commitee_presidents_DT.comt_id.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[commitee_presidents_DT.Enum_commitee_presidents_DT.comt_id.ToString()]);
		obj_commitee_presidents_DT.dept_id = dr[commitee_presidents_DT.Enum_commitee_presidents_DT.dept_id.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[commitee_presidents_DT.Enum_commitee_presidents_DT.dept_id.ToString()]);

           return obj_commitee_presidents_DT;
        }

        private static SqlParameter[] GetParameters(commitee_presidents_DT obj)
        {
            SqlParameter[] parms = new SqlParameter[4];
           
			
        

        parms[0] = new SqlParameter(commitee_presidents_DT.Enum_commitee_presidents_DT.id.ToString(), obj.id);
        parms[0].Direction = ParameterDirection.InputOutput;

        parms[1] = new SqlParameter(commitee_presidents_DT.Enum_commitee_presidents_DT.pmp_id.ToString(), obj.pmp_id);

        parms[2] = new SqlParameter(commitee_presidents_DT.Enum_commitee_presidents_DT.comt_id.ToString(), obj.comt_id);

        parms[3] = new SqlParameter(commitee_presidents_DT.Enum_commitee_presidents_DT.dept_id.ToString(), obj.dept_id);
            
            return parms;
        }

        #endregion

	    #region "DB methods"

        public static int Save(commitee_presidents_DT obj)
        {
            try
            {
                SqlParameter[] parms = GetParameters(obj);

                SqlHelper.ExecuteScalar(Database.ConnectionString, CommandType.StoredProcedure, "commitee_presidents_Save", parms);

             	    obj.id = Convert.ToInt32(parms[0].Value) ; 

           return obj.id ;
            }
            catch (Exception ex)
            {

                return -1;
            }
        }

        public static int Delete(int commitee_presidents_ID)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(Database.ConnectionString, "commitee_presidents_Delete", commitee_presidents_ID);
                return commitee_presidents_ID;
            }
            catch (Exception ex)
            {

                return -1;
            }
        }

        public static DataTable SelectAll(int id,int pmp_id)
        {
            try
            {
				 return SqlHelper.ExecuteDataset(Database.ConnectionString, "commitee_presidents_Select",id ,pmp_id ).Tables[0];
		
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public static commitee_presidents_DT SelectByID(int commitee_presidents_ID)
        {
            try
            {
              if (commitee_presidents_ID > 0)
                {
                SqlDataReader drTableName;
                commitee_presidents_DT oInfo_commitee_presidents_DT = new commitee_presidents_DT();

                drTableName = SqlHelper.ExecuteReader(Database.ConnectionString, "commitee_presidents_Select", commitee_presidents_ID);
                if (drTableName != null)
                {
                    while (drTableName.Read())
                    {
                        oInfo_commitee_presidents_DT = FillInfoObject(drTableName);
                    }

                    drTableName.Close();
                }
                return oInfo_commitee_presidents_DT;
               }
                else
                    return new commitee_presidents_DT();
            }
            catch (Exception ex)
            {

                return null;
            }
        }
	#endregion


    }

