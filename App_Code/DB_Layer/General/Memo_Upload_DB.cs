//////////////////////////////////////////////////////////////////////////////////////////
// Generated By:	MCIT\MElshahed using Mcit Generator
// Class Name:		Memo_Upload_DB
// Date Generated:	10-10-2013
//////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Data.SqlClient;
using System.Data;


    public static class Memo_Upload_DB
    {

        #region "Private methods"

        private static Memo_Upload_DT FillInfoObject(SqlDataReader dr)
        {

           Memo_Upload_DT obj_Memo_Upload_DT = new Memo_Upload_DT();

           
		obj_Memo_Upload_DT.ID = Convert.ToInt32(dr[Memo_Upload_DT.Enum_Memo_Upload_DT.ID.ToString()]);
		obj_Memo_Upload_DT.File_Name = dr[Memo_Upload_DT.Enum_Memo_Upload_DT.File_Name.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Memo_Upload_DT.Enum_Memo_Upload_DT.File_Name.ToString()]);
		obj_Memo_Upload_DT.File_Ext = dr[Memo_Upload_DT.Enum_Memo_Upload_DT.File_Ext.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Memo_Upload_DT.Enum_Memo_Upload_DT.File_Ext.ToString()]);
        obj_Memo_Upload_DT.File_Title = dr[Memo_Upload_DT.Enum_Memo_Upload_DT.File_Title.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Memo_Upload_DT.Enum_Memo_Upload_DT.File_Title.ToString()]);
        obj_Memo_Upload_DT.sector_id = dr[Memo_Upload_DT.Enum_Memo_Upload_DT.sector_id.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Memo_Upload_DT.Enum_Memo_Upload_DT.sector_id.ToString()]);

           return obj_Memo_Upload_DT;
        }

        private static SqlParameter[] GetParameters(Memo_Upload_DT obj)
        {
            SqlParameter[] parms = new SqlParameter[5];
           
			
        

        parms[0] = new SqlParameter(Memo_Upload_DT.Enum_Memo_Upload_DT.ID.ToString(), obj.ID);
        parms[0].Direction = ParameterDirection.InputOutput;

        parms[1] = new SqlParameter(Memo_Upload_DT.Enum_Memo_Upload_DT.File_Name.ToString(), obj.File_Name);

        parms[2] = new SqlParameter(Memo_Upload_DT.Enum_Memo_Upload_DT.File_Ext.ToString(), obj.File_Ext);
        parms[3] = new SqlParameter(Memo_Upload_DT.Enum_Memo_Upload_DT.File_Title.ToString(), obj.File_Title);
        parms[4] = new SqlParameter(Memo_Upload_DT.Enum_Memo_Upload_DT.sector_id.ToString(), obj.sector_id);

            return parms;
        }

        #endregion

	    #region "DB methods"

        public static int Save(Memo_Upload_DT obj)
        {
            try
            {
                SqlParameter[] parms = GetParameters(obj);

                SqlHelper.ExecuteScalar(Database.ConnectionString, CommandType.StoredProcedure, "Memo_Upload_Save", parms);

             	    obj.ID = Convert.ToInt32(parms[0].Value) ; 

           return obj.ID ;
            }
            catch (Exception ex)
            {

                return -1;
            }
        }

        public static int Delete(int Memo_Upload_ID)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(Database.ConnectionString, "Memo_Upload_Delete", Memo_Upload_ID);
                return Memo_Upload_ID;
            }
            catch (Exception ex)
            {

                return -1;
            }
        }

        public static DataTable SelectAll(int id, int sector_id)
        {
            try
            {
				 return SqlHelper.ExecuteDataset(Database.ConnectionString, "Memo_Upload_Select", id ,sector_id).Tables[0];
		
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public static Memo_Upload_DT SelectByID(int Memo_Upload_ID)
        {
            try
            {
              if (Memo_Upload_ID > 0)
                {
                SqlDataReader drTableName;
                Memo_Upload_DT oInfo_Memo_Upload_DT = new Memo_Upload_DT();

                drTableName = SqlHelper.ExecuteReader(Database.ConnectionString, "Memo_Upload_Select", Memo_Upload_ID);
                if (drTableName != null)
                {
                    while (drTableName.Read())
                    {
                        oInfo_Memo_Upload_DT = FillInfoObject(drTableName);
                    }

                    drTableName.Close();
                }
                return oInfo_Memo_Upload_DT;
               }
                else
                    return new Memo_Upload_DT();
            }
            catch (Exception ex)
            {

                return null;
            }
        }
	#endregion


    }

