//////////////////////////////////////////////////////////////////////////////////////////
// Generated By:	MCIT\malmeligi using Mcit Generator
// Class Name:		proj_statistics_service_DB
// Date Generated:	27-06-2012
//////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Data.SqlClient;
using System.Data;


    public static class proj_statistics_service_DB
    {

        #region "Private methods"

        private static proj_statistics_service_DT FillInfoObject(SqlDataReader dr)
        {

           proj_statistics_service_DT obj_proj_statistics_service_DT = new proj_statistics_service_DT();

           
		obj_proj_statistics_service_DT.proj_statistics_service_id = Convert.ToInt32(dr[proj_statistics_service_DT.Enum_proj_statistics_service_DT.proj_statistics_service_id.ToString()]);
		obj_proj_statistics_service_DT.proj_id = dr[proj_statistics_service_DT.Enum_proj_statistics_service_DT.proj_id.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[proj_statistics_service_DT.Enum_proj_statistics_service_DT.proj_id.ToString()]);
		obj_proj_statistics_service_DT.service_id = dr[proj_statistics_service_DT.Enum_proj_statistics_service_DT.service_id.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[proj_statistics_service_DT.Enum_proj_statistics_service_DT.service_id.ToString()]);
		//obj_proj_statistics_service_DT.File_data = dr[proj_statistics_service_DT.Enum_proj_statistics_service_DT.File_data.ToString()] == DBNull.Value ? null : Convert.ToByte[](dr[proj_statistics_service_DT.Enum_proj_statistics_service_DT.File_data.ToString()]);
		obj_proj_statistics_service_DT.File_name = dr[proj_statistics_service_DT.Enum_proj_statistics_service_DT.File_name.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[proj_statistics_service_DT.Enum_proj_statistics_service_DT.File_name.ToString()]);
		obj_proj_statistics_service_DT.File_ext = dr[proj_statistics_service_DT.Enum_proj_statistics_service_DT.File_ext.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[proj_statistics_service_DT.Enum_proj_statistics_service_DT.File_ext.ToString()]);

           return obj_proj_statistics_service_DT;
        }

        private static SqlParameter[] GetParameters(proj_statistics_service_DT obj)
        {
            SqlParameter[] parms = new SqlParameter[6];
           
			
        

        parms[0] = new SqlParameter(proj_statistics_service_DT.Enum_proj_statistics_service_DT.proj_statistics_service_id.ToString(), obj.proj_statistics_service_id);
        parms[0].Direction = ParameterDirection.InputOutput;

        parms[1] = new SqlParameter(proj_statistics_service_DT.Enum_proj_statistics_service_DT.proj_id.ToString(), obj.proj_id);

        parms[2] = new SqlParameter(proj_statistics_service_DT.Enum_proj_statistics_service_DT.service_id.ToString(), obj.service_id);

        parms[3] = new SqlParameter(proj_statistics_service_DT.Enum_proj_statistics_service_DT.File_data.ToString(), obj.File_data);

        parms[4] = new SqlParameter(proj_statistics_service_DT.Enum_proj_statistics_service_DT.File_name.ToString(), obj.File_name);

        parms[5] = new SqlParameter(proj_statistics_service_DT.Enum_proj_statistics_service_DT.File_ext.ToString(), obj.File_ext);
            
            return parms;
        }

        #endregion

	    #region "DB methods"

        public static int Save(proj_statistics_service_DT obj)
        {
            try
            {
                SqlParameter[] parms = GetParameters(obj);

                SqlHelper.ExecuteScalar(Database.ConnectionString, CommandType.StoredProcedure, "proj_statistics_service_Save", parms);

             	    obj.proj_statistics_service_id = Convert.ToInt32(parms[0].Value) ; 

           return obj.proj_statistics_service_id ;
            }
            catch (Exception ex)
            {

                return -1;
            }
        }

        public static int Delete(int proj_statistics_service_ID)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(Database.ConnectionString, "proj_statistics_service_Delete", proj_statistics_service_ID);
                return proj_statistics_service_ID;
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
				 return SqlHelper.ExecuteDataset(Database.ConnectionString, "proj_statistics_service_Select", 0).Tables[0];
		
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public static proj_statistics_service_DT SelectByID(int proj_statistics_service_ID)
        {
            try
            {
              if (proj_statistics_service_ID > 0)
                {
                SqlDataReader drTableName;
                proj_statistics_service_DT oInfo_proj_statistics_service_DT = new proj_statistics_service_DT();

                drTableName = SqlHelper.ExecuteReader(Database.ConnectionString, "proj_statistics_service_Select", proj_statistics_service_ID);
                if (drTableName != null)
                {
                    while (drTableName.Read())
                    {
                        oInfo_proj_statistics_service_DT = FillInfoObject(drTableName);
                    }

                    drTableName.Close();
                }
                return oInfo_proj_statistics_service_DT;
               }
                else
                    return new proj_statistics_service_DT();
            }
            catch (Exception ex)
            {

                return null;
            }
        }
	#endregion


    }

