//////////////////////////////////////////////////////////////////////////////////////////
// Generated By:	MCIT\nmghaith using Mcit Generator
// Class Name:		Employee_publicdata_DB
// Date Generated:	26-03-2012
//////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Data.SqlClient;
using System.Data;


public static class Employee_publicdata_DB
{

    #region "Private methods"

    private static Employee_publicdata_DT FillInfoObject(SqlDataReader dr)
    {

        Employee_publicdata_DT obj_Employee_publicdata_DT = new Employee_publicdata_DT();


        obj_Employee_publicdata_DT.id = Convert.ToInt32(dr[Employee_publicdata_DT.Enum_Employee_publicdata_DT.id.ToString()]);
        obj_Employee_publicdata_DT.pmp_id = dr[Employee_publicdata_DT.Enum_Employee_publicdata_DT.pmp_id.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Employee_publicdata_DT.Enum_Employee_publicdata_DT.pmp_id.ToString()]);
        obj_Employee_publicdata_DT.noofemployee = dr[Employee_publicdata_DT.Enum_Employee_publicdata_DT.noofemployee.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Employee_publicdata_DT.Enum_Employee_publicdata_DT.noofemployee.ToString()]);
        obj_Employee_publicdata_DT.englishlevel = dr[Employee_publicdata_DT.Enum_Employee_publicdata_DT.englishlevel.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Employee_publicdata_DT.Enum_Employee_publicdata_DT.englishlevel.ToString()]);
        obj_Employee_publicdata_DT.is_manager = dr[Employee_publicdata_DT.Enum_Employee_publicdata_DT.is_manager.ToString()] == DBNull.Value ? false : Convert.ToBoolean(dr[Employee_publicdata_DT.Enum_Employee_publicdata_DT.is_manager.ToString()]);
        obj_Employee_publicdata_DT.mobile = dr[Employee_publicdata_DT.Enum_Employee_publicdata_DT.mobile.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Employee_publicdata_DT.Enum_Employee_publicdata_DT.mobile.ToString()]);
        obj_Employee_publicdata_DT.phone = dr[Employee_publicdata_DT.Enum_Employee_publicdata_DT.phone.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Employee_publicdata_DT.Enum_Employee_publicdata_DT.phone.ToString()]);
        obj_Employee_publicdata_DT.mail = dr[Employee_publicdata_DT.Enum_Employee_publicdata_DT.mail.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Employee_publicdata_DT.Enum_Employee_publicdata_DT.mail.ToString()]);
        obj_Employee_publicdata_DT.current_tasks = dr[Employee_publicdata_DT.Enum_Employee_publicdata_DT.current_tasks.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Employee_publicdata_DT.Enum_Employee_publicdata_DT.current_tasks.ToString()]);

        return obj_Employee_publicdata_DT;
    }

    private static SqlParameter[] GetParameters(Employee_publicdata_DT obj)
    {
        SqlParameter[] parms = new SqlParameter[9];




        parms[0] = new SqlParameter(Employee_publicdata_DT.Enum_Employee_publicdata_DT.id.ToString(), obj.id);
        parms[0].Direction = ParameterDirection.InputOutput;

        parms[1] = new SqlParameter(Employee_publicdata_DT.Enum_Employee_publicdata_DT.pmp_id.ToString(), obj.pmp_id);

        parms[2] = new SqlParameter(Employee_publicdata_DT.Enum_Employee_publicdata_DT.noofemployee.ToString(), obj.noofemployee);

        parms[3] = new SqlParameter(Employee_publicdata_DT.Enum_Employee_publicdata_DT.englishlevel.ToString(), obj.englishlevel);

        parms[4] = new SqlParameter(Employee_publicdata_DT.Enum_Employee_publicdata_DT.is_manager.ToString(), obj.is_manager);

        parms[5] = new SqlParameter(Employee_publicdata_DT.Enum_Employee_publicdata_DT.mobile.ToString(), obj.mobile);

        parms[6] = new SqlParameter(Employee_publicdata_DT.Enum_Employee_publicdata_DT.phone.ToString(), obj.phone);

        parms[7] = new SqlParameter(Employee_publicdata_DT.Enum_Employee_publicdata_DT.mail.ToString(), obj.mail);

        parms[8] = new SqlParameter(Employee_publicdata_DT.Enum_Employee_publicdata_DT.current_tasks.ToString(), obj.current_tasks);

        return parms;
    }

    #endregion

    #region "DB methods"

    public static int Save(Employee_publicdata_DT obj)
    {
        try
        {
            SqlParameter[] parms = GetParameters(obj);

            SqlHelper.ExecuteScalar(Database.ConnectionString, CommandType.StoredProcedure, "Employee_publicdata_Save", parms);

            obj.id = Convert.ToInt32(parms[0].Value);

            return obj.id;
        }
        catch (Exception ex)
        {

            return -1;
        }
    }

    public static int Delete(int Employee_publicdata_ID)
    {
        try
        {
            SqlHelper.ExecuteNonQuery(Database.ConnectionString, "Employee_publicdata_Delete", Employee_publicdata_ID);
            return Employee_publicdata_ID;
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
            return SqlHelper.ExecuteDataset(Database.ConnectionString, "Employee_publicdata_Select", 0).Tables[0];

        }
        catch (Exception ex)
        {

            return null;
        }
    }

    public static Employee_publicdata_DT SelectByID(int Employee_publicdata_ID)
    {
        try
        {
            if (Employee_publicdata_ID > 0)
            {
                SqlDataReader drTableName;
                Employee_publicdata_DT oInfo_Employee_publicdata_DT = new Employee_publicdata_DT();

                drTableName = SqlHelper.ExecuteReader(Database.ConnectionString, "Employee_publicdata_Select", Employee_publicdata_ID);
                if (drTableName != null)
                {
                    while (drTableName.Read())
                    {
                        oInfo_Employee_publicdata_DT = FillInfoObject(drTableName);
                    }

                    drTableName.Close();
                }
                return oInfo_Employee_publicdata_DT;
            }
            else
                return new Employee_publicdata_DT();
        }
        catch (Exception ex)
        {

            return null;
        }
    }




    public static Employee_publicdata_DT SelectBypmp_id(int pmp_id)
    {



        try
        {
            if (pmp_id > 0)
            {
                SqlDataReader drTableName;
                Employee_publicdata_DT oInfo_Employee_publicdata_DT = new Employee_publicdata_DT();

                drTableName = SqlHelper.ExecuteReader(Database.ConnectionString, "Employee_publicdata_Select_by_pmp_id", pmp_id);
                if (drTableName != null)
                {
                    while (drTableName.Read())
                    {
                        oInfo_Employee_publicdata_DT = FillInfoObject(drTableName);
                    }

                    drTableName.Close();
                }
                return oInfo_Employee_publicdata_DT;
            }
            else
                return new Employee_publicdata_DT();
        }
        catch (Exception ex)
        {

            return null;
        }

    }
}
	#endregion


    

