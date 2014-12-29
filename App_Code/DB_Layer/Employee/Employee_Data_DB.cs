using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Employee_Data_DB
/// </summary>
public class Employee_Data_DB
{
    private static Employee_Data_DT FillInfoObject(SqlDataReader dr)
    {

        Employee_Data_DT einfo = new Employee_Data_DT();
        einfo.PMP_ID = Convert.ToInt32(dr[Employee_Data_DT.EnumInfo_Employee_Data.PMP_ID.ToString()]);
        einfo.Dept_Dept_id = dr[Employee_Data_DT.EnumInfo_Employee_Data.Dept_Dept_id.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Employee_Data_DT.EnumInfo_Employee_Data.Dept_Dept_id.ToString()]);
        einfo.pmp_name = dr[Employee_Data_DT.EnumInfo_Employee_Data.pmp_name.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Employee_Data_DT.EnumInfo_Employee_Data.pmp_name.ToString()]);
        einfo.mail = dr[Employee_Data_DT.EnumInfo_Employee_Data.mail.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Employee_Data_DT.EnumInfo_Employee_Data.mail.ToString()]);
        einfo.sec_sec_id = dr[Employee_Data_DT.EnumInfo_Employee_Data.sec_sec_id.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Employee_Data_DT.EnumInfo_Employee_Data.sec_sec_id.ToString()]);
        einfo.Hire_date = dr[Employee_Data_DT.EnumInfo_Employee_Data.Hire_date.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Employee_Data_DT.EnumInfo_Employee_Data.Hire_date.ToString()]);
        einfo.pmp_title = dr[Employee_Data_DT.EnumInfo_Employee_Data.pmp_title.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Employee_Data_DT.EnumInfo_Employee_Data.pmp_title.ToString()]);
        einfo.job_no = dr[Employee_Data_DT.EnumInfo_Employee_Data.job_no.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Employee_Data_DT.EnumInfo_Employee_Data.job_no.ToString()]);
        einfo.direct_manager = dr[Employee_Data_DT.EnumInfo_Employee_Data.direct_manager.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Employee_Data_DT.EnumInfo_Employee_Data.direct_manager.ToString()]);
        einfo.higher_manager = dr[Employee_Data_DT.EnumInfo_Employee_Data.higher_manager.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Employee_Data_DT.EnumInfo_Employee_Data.higher_manager.ToString()]);
        einfo.vacation_mng_pmp_id = dr[Employee_Data_DT.EnumInfo_Employee_Data.vacation_mng_pmp_id.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Employee_Data_DT.EnumInfo_Employee_Data.vacation_mng_pmp_id.ToString()]);
        einfo.workstatus = dr[Employee_Data_DT.EnumInfo_Employee_Data.workstatus.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Employee_Data_DT.EnumInfo_Employee_Data.workstatus.ToString()]);
        einfo.category = dr[Employee_Data_DT.EnumInfo_Employee_Data.category.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Employee_Data_DT.EnumInfo_Employee_Data.category.ToString()]);
        einfo.university_degree = dr[Employee_Data_DT.EnumInfo_Employee_Data.university_degree.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Employee_Data_DT.EnumInfo_Employee_Data.university_degree.ToString()]);
        einfo.major = dr[Employee_Data_DT.EnumInfo_Employee_Data.major.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Employee_Data_DT.EnumInfo_Employee_Data.major.ToString()]);
        einfo.university_name = dr[Employee_Data_DT.EnumInfo_Employee_Data.university_name.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Employee_Data_DT.EnumInfo_Employee_Data.university_name.ToString()]);
        einfo.rol_rol_id = dr[Employee_Data_DT.EnumInfo_Employee_Data.rol_rol_id.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Employee_Data_DT.EnumInfo_Employee_Data.rol_rol_id.ToString()]);
        einfo.contact_person = Convert.ToBoolean(dr[Employee_Data_DT.EnumInfo_Employee_Data.contact_person.ToString()]);
        einfo.foundation_id = dr[Employee_Data_DT.EnumInfo_Employee_Data.foundation_id.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Employee_Data_DT.EnumInfo_Employee_Data.foundation_id.ToString()]);


        return einfo;

    }
    private static SqlParameter[] GetParameters(Employee_Data_DT obj, bool isSearch)
    {
        SqlParameter[] parms = new SqlParameter[19];


        if (!isSearch)
        {

            parms[0] = new SqlParameter(Employee_Data_DT.EnumInfo_Employee_Data.PMP_ID.ToString(), obj.PMP_ID);
            parms[0].Direction = ParameterDirection.InputOutput;
        }

        parms[1] = new SqlParameter(Employee_Data_DT.EnumInfo_Employee_Data.Dept_Dept_id.ToString(), obj.Dept_Dept_id);
        parms[2] = new SqlParameter(Employee_Data_DT.EnumInfo_Employee_Data.pmp_name.ToString(), obj.pmp_name);
        parms[3] = new SqlParameter(Employee_Data_DT.EnumInfo_Employee_Data.mail.ToString(), obj.mail);
        parms[4] = new SqlParameter(Employee_Data_DT.EnumInfo_Employee_Data.sec_sec_id.ToString(), obj.sec_sec_id);
        parms[5] = new SqlParameter(Employee_Data_DT.EnumInfo_Employee_Data.Hire_date.ToString(), obj.Hire_date);
        parms[6] = new SqlParameter(Employee_Data_DT.EnumInfo_Employee_Data.pmp_title.ToString(), obj.pmp_title);
        parms[7] = new SqlParameter(Employee_Data_DT.EnumInfo_Employee_Data.job_no.ToString(), obj.job_no);

        parms[8] = new SqlParameter(Employee_Data_DT.EnumInfo_Employee_Data.direct_manager.ToString(), obj.direct_manager);
        parms[9] = new SqlParameter(Employee_Data_DT.EnumInfo_Employee_Data.higher_manager.ToString(), obj.higher_manager);

        parms[10] = new SqlParameter(Employee_Data_DT.EnumInfo_Employee_Data.vacation_mng_pmp_id.ToString(), obj.vacation_mng_pmp_id);
        parms[11] = new SqlParameter(Employee_Data_DT.EnumInfo_Employee_Data.workstatus.ToString(), obj.workstatus);
        parms[12] = new SqlParameter(Employee_Data_DT.EnumInfo_Employee_Data.category.ToString(), obj.category);
        parms[13] = new SqlParameter(Employee_Data_DT.EnumInfo_Employee_Data.university_degree.ToString(), obj.university_degree);
        parms[14] = new SqlParameter(Employee_Data_DT.EnumInfo_Employee_Data.major.ToString(), obj.major);
        parms[15] = new SqlParameter(Employee_Data_DT.EnumInfo_Employee_Data.university_name.ToString(), obj.university_name);
        parms[16] = new SqlParameter(Employee_Data_DT.EnumInfo_Employee_Data.rol_rol_id.ToString(), obj.rol_rol_id);
        parms[17] = new SqlParameter(Employee_Data_DT.EnumInfo_Employee_Data.contact_person.ToString(), obj.contact_person);
        parms[18] = new SqlParameter(Employee_Data_DT.EnumInfo_Employee_Data.foundation_id.ToString(), obj.foundation_id);


        return parms;
    }

    public static int Save(Employee_Data_DT obj)
    {
        try
        {
            SqlParameter[] parms = GetParameters(obj, false);

            SqlHelper.ExecuteScalar(Database.ConnectionString, CommandType.StoredProcedure, "employee_save", parms);
            return Convert.ToInt32(parms[0].Value);
        }
        catch (SqlException ex)
        {
            return -1;
        }
    }


    public static DataTable Select_all(int pmp_ID)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "employee_select", pmp_ID).Tables[0];

    }

    public static DataTable Select_EmployeeData(string pmp_name, int Dept_id, string job_no,int foundation_id)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "employee_search", pmp_name, Dept_id, job_no,foundation_id).Tables[0];

    }

    public static DataTable Select_EvaluatedEmployeeData(int Pmp_id)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Select_EvaluatedEmployeeData", Pmp_id).Tables[0];

    }

    public static Employee_Data_DT Select_EmployeeByDeptID(int DeptID)
    {
        try
        {
            if (DeptID > 0)
            {
                SqlDataReader drTableName;
                Employee_Data_DT oInfo_Employee_Data_DT = new Employee_Data_DT();

                drTableName = SqlHelper.ExecuteReader(Database.ConnectionString, "Employee_Select_ByDept", DeptID);
                if (drTableName != null)
                {
                    while (drTableName.Read())
                    {
                        oInfo_Employee_Data_DT = FillInfoObject(drTableName);
                    }

                    drTableName.Close();
                }
                return oInfo_Employee_Data_DT;
            }
            else
                return new Employee_Data_DT();
        }
        catch (Exception ex)
        {

            return null;
        }
    }





}
