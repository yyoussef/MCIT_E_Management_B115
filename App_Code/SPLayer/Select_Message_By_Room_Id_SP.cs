//////////////////////////////////////////////////////////////////////////////////////////
// Generated By:	MCIT\mmabdelmalek using Mcit Generator
// Class Name:		Select_Message_By_Room_Id_SP
// Date Generated:	29-09-2012
//////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Data.SqlClient;
using System.Data;



    public class Select_Message_By_Room_Id_SP
    {
        public enum Enum_Select_Message_By_Room_Id_SP
        {
            Room_ID, 
        }

        
		/// <summary>
		/// 
		/// </summary>
		public Int32 Room_ID;
		

       #region "Private methods"

      
        private static SqlParameter[] GetParameters(Select_Message_By_Room_Id_SP obj)
        {
            SqlParameter[] parms = new SqlParameter[1];
           
			

        parms[0] = new SqlParameter(Select_Message_By_Room_Id_SP.Enum_Select_Message_By_Room_Id_SP.Room_ID.ToString(), obj.Room_ID);
            
            return parms;
        }

        #endregion

       #region "DB methods"

        public static DataTable  Get_DataTable(Select_Message_By_Room_Id_SP obj)
        {
            try
            {
                SqlParameter[] parms = GetParameters(obj);

          return SqlHelper.ExecuteDataset(Database.ConnectionString, CommandType.StoredProcedure, "Select_Message_By_Room_Id", parms).Tables[0];

            }
            catch (Exception ex)
            {

                return null;
            }
        }
     #endregion
    }

