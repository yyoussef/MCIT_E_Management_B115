//////////////////////////////////////////////////////////////////////////////////////////
// Generated By:	MCIT\mmabdelmalek using Mcit Generator
// Class Name:		Admin_Module_DB
// Date Generated:	15-10-2012
//////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Data.SqlClient;
using System.Data;


    public static class Admin_Module_DB
    {

        #region "Private methods"

        private static Admin_Module_DT FillInfoObject(SqlDataReader dr)
        {

           Admin_Module_DT obj_Admin_Module_DT = new Admin_Module_DT();

           
		obj_Admin_Module_DT.pk_ID = Convert.ToInt32(dr[Admin_Module_DT.Enum_Admin_Module_DT.pk_ID.ToString()]);
		obj_Admin_Module_DT.Active = dr[Admin_Module_DT.Enum_Admin_Module_DT.Active.ToString()] == DBNull.Value ? false : Convert.ToBoolean(dr[Admin_Module_DT.Enum_Admin_Module_DT.Active.ToString()]);
		obj_Admin_Module_DT.Name = dr[Admin_Module_DT.Enum_Admin_Module_DT.Name.ToString()] == DBNull.Value ? null : Convert.ToString(dr[Admin_Module_DT.Enum_Admin_Module_DT.Name.ToString()]);

           return obj_Admin_Module_DT;
        }

        private static SqlParameter[] GetParameters(Admin_Module_DT obj)
        {
            SqlParameter[] parms = new SqlParameter[3];
           
			
        

        parms[0] = new SqlParameter(Admin_Module_DT.Enum_Admin_Module_DT.pk_ID.ToString(), obj.pk_ID);
        parms[0].Direction = ParameterDirection.InputOutput;

        parms[1] = new SqlParameter(Admin_Module_DT.Enum_Admin_Module_DT.Active.ToString(), obj.Active);

        parms[2] = new SqlParameter(Admin_Module_DT.Enum_Admin_Module_DT.Name.ToString(), obj.Name);
            
            return parms;
        }

        #endregion

	    #region "DB methods"

        public static int Save(Admin_Module_DT obj)
        {
            try
            {
                SqlParameter[] parms = GetParameters(obj);

                SqlHelper.ExecuteScalar(Database.ConnectionString, CommandType.StoredProcedure, "Admin_Module_Save", parms);

             	    obj.pk_ID = Convert.ToInt32(parms[0].Value) ; 

           return obj.pk_ID ;
            }
            catch (Exception ex)
            {

                return -1;
            }
        }

        public static int Delete(int Admin_Module_ID)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(Database.ConnectionString, "Admin_Module_Delete", Admin_Module_ID);
                return Admin_Module_ID;
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
				 return SqlHelper.ExecuteDataset(Database.ConnectionString, "Admin_Module_Select", 0).Tables[0];
		
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public static DataTable SelectNonActiveModule_found(int found)
        {
            try
            {
                return SqlHelper.ExecuteDataset(Database.ConnectionString, "Admin_Module__found_Select_All_nonActive", found).Tables[0];

            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public static DataTable SelectNonActiveModule()
        {
            try
            {
                return SqlHelper.ExecuteDataset(Database.ConnectionString, "Admin_Module_Select_All_nonActive").Tables[0];

            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public static DataTable SelectAllActiveModule_found(int found)
        {
            try
            {
                return SqlHelper.ExecuteDataset(Database.ConnectionString, "Admin_Module_Select_All_Active_found", found).Tables[0];

            }
            catch (Exception ex)
            {

                return null;
            }
        }
        public static DataTable SelectAllActiveModule()
        {
            try
            {
                return SqlHelper.ExecuteDataset(Database.ConnectionString, "Admin_Module_Select_All_Active").Tables[0];

            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public static Admin_Module_DT SelectByID(int Admin_Module_ID)
        {
            try
            {
              if (Admin_Module_ID > 0)
                {
                SqlDataReader drTableName;
                Admin_Module_DT oInfo_Admin_Module_DT = new Admin_Module_DT();

                drTableName = SqlHelper.ExecuteReader(Database.ConnectionString, "Admin_Module_Select", Admin_Module_ID);
                if (drTableName != null)
                {
                    while (drTableName.Read())
                    {
                        oInfo_Admin_Module_DT = FillInfoObject(drTableName);
                    }

                    drTableName.Close();
                }
                return oInfo_Admin_Module_DT;
               }
                else
                    return new Admin_Module_DT();
            }
            catch (Exception ex)
            {

                return null;
            }
        }
	#endregion


    }

