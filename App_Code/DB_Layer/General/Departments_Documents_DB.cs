using System;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for Departments_Documents_DB
/// </summary>
public class Departments_Documents_DB
{

    #region "Private methods"

    private static Departments_Documents_DT FillInfoObject(SqlDataReader dr)
        {

            Departments_Documents_DT oDepartments_Documents_DT = new Departments_Documents_DT();

           
		oDepartments_Documents_DT.File_ID = Convert.ToInt32(dr[Departments_Documents_DT.EnumInfo_Documents.File_ID.ToString()]);
		oDepartments_Documents_DT.File_Type = dr[Departments_Documents_DT.EnumInfo_Documents.File_Type.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Departments_Documents_DT.EnumInfo_Documents.File_Type.ToString()]);
        oDepartments_Documents_DT.Parent_ID = dr[Departments_Documents_DT.EnumInfo_Documents.Parent_ID.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Departments_Documents_DT.EnumInfo_Documents.Parent_ID.ToString()]);
        oDepartments_Documents_DT.TheOrder = dr[Departments_Documents_DT.EnumInfo_Documents.TheOrder.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Departments_Documents_DT.EnumInfo_Documents.TheOrder.ToString()]);
        
        oDepartments_Documents_DT.Proj_Proj_id = dr[Departments_Documents_DT.EnumInfo_Documents.Proj_Proj_id.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Departments_Documents_DT.EnumInfo_Documents.Proj_Proj_id.ToString()]);
		oDepartments_Documents_DT.Dept_ID = dr[Departments_Documents_DT.EnumInfo_Documents.Dept_ID.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Departments_Documents_DT.EnumInfo_Documents.Dept_ID.ToString()]);
        oDepartments_Documents_DT.upload_on_sector = dr[Departments_Documents_DT.EnumInfo_Documents.upload_on_sector.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Departments_Documents_DT.EnumInfo_Documents.upload_on_sector.ToString()]);
        oDepartments_Documents_DT.Page_Count = dr[Departments_Documents_DT.EnumInfo_Documents.Page_Count.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Departments_Documents_DT.EnumInfo_Documents.Page_Count.ToString()]);
		oDepartments_Documents_DT.Emp_ID = dr[Departments_Documents_DT.EnumInfo_Documents.Emp_ID.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Departments_Documents_DT.EnumInfo_Documents.Emp_ID.ToString()]);
        oDepartments_Documents_DT.File_data = dr[Departments_Documents_DT.EnumInfo_Documents.File_data.ToString()] == DBNull.Value ? null : (Byte[])(dr[Departments_Documents_DT.EnumInfo_Documents.File_data.ToString()]);
		oDepartments_Documents_DT.File_Desc = dr[Departments_Documents_DT.EnumInfo_Documents.File_Desc.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Departments_Documents_DT.EnumInfo_Documents.File_Desc.ToString()]);
		oDepartments_Documents_DT.File_name = dr[Departments_Documents_DT.EnumInfo_Documents.File_name.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Departments_Documents_DT.EnumInfo_Documents.File_name.ToString()]);
		oDepartments_Documents_DT.File_ext = dr[Departments_Documents_DT.EnumInfo_Documents.File_ext.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Departments_Documents_DT.EnumInfo_Documents.File_ext.ToString()]);
        oDepartments_Documents_DT.File_Sytem_Name = dr[Departments_Documents_DT.EnumInfo_Documents.File_Sytem_Name.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Departments_Documents_DT.EnumInfo_Documents.File_Sytem_Name.ToString()]);
        oDepartments_Documents_DT.Entery_DT = dr[Departments_Documents_DT.EnumInfo_Documents.Entery_DT.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Departments_Documents_DT.EnumInfo_Documents.Entery_DT.ToString()]);

            return oDepartments_Documents_DT;
        }

    private static SqlParameter[] GetParameters(Departments_Documents_DT obj, bool isSearch)
    {
        SqlParameter[] parms = new SqlParameter[14];


        if (!isSearch)
        {

            parms[0] = new SqlParameter(Departments_Documents_DT.EnumInfo_Documents.File_ID.ToString(), obj.File_ID);
            parms[0].Direction = ParameterDirection.InputOutput;

        }

        parms[1] = new SqlParameter(Departments_Documents_DT.EnumInfo_Documents.File_Type.ToString(), obj.File_Type);

        parms[2] = new SqlParameter(Departments_Documents_DT.EnumInfo_Documents.Dept_ID.ToString(), obj.Dept_ID);

        parms[3] = new SqlParameter(Departments_Documents_DT.EnumInfo_Documents.Emp_ID.ToString(), obj.Emp_ID);

       // parms[4] = new SqlParameter(Departments_Documents_DT.EnumInfo_Documents.File_data.ToString(), obj.File_data);

        parms[4] = new SqlParameter(Departments_Documents_DT.EnumInfo_Documents.File_Desc.ToString(), obj.File_Desc);

        parms[5] = new SqlParameter(Departments_Documents_DT.EnumInfo_Documents.File_name.ToString(), obj.File_name);

        parms[6] = new SqlParameter(Departments_Documents_DT.EnumInfo_Documents.Proj_Proj_id.ToString(), obj.Proj_Proj_id);

        parms[7] = new SqlParameter(Departments_Documents_DT.EnumInfo_Documents.Parent_ID.ToString(), obj.Parent_ID);

        parms[8] = new SqlParameter(Departments_Documents_DT.EnumInfo_Documents.File_Sytem_Name.ToString(), obj.File_Sytem_Name);

        parms[9] = new SqlParameter(Departments_Documents_DT.EnumInfo_Documents.File_ext.ToString(), obj.File_ext);

        parms[10] = new SqlParameter(Departments_Documents_DT.EnumInfo_Documents.Page_Count.ToString(), obj.Page_Count);

        parms[11] = new SqlParameter(Departments_Documents_DT.EnumInfo_Documents.Entery_DT.ToString(), obj.Entery_DT);

        parms[12] = new SqlParameter(Departments_Documents_DT.EnumInfo_Documents.TheOrder.ToString(), obj.TheOrder);

        parms[13] = new SqlParameter(Departments_Documents_DT.EnumInfo_Documents.upload_on_sector.ToString(), obj.upload_on_sector);
        
        return parms;
    }

    #endregion

    #region DataBase Function

    public static int Save(Departments_Documents_DT obj)
    {
        try
        {
            SqlParameter[] parms = GetParameters(obj, false);

            SqlHelper.ExecuteScalar(Database.ConnectionString, CommandType.StoredProcedure, "Departments_Documents_Save", parms);
            return Convert.ToInt32(parms[0].Value);
        }
        catch (SqlException ex)
        {

            return -1;
        }
    }

    public static int Delete(int ID)
    {
        try
        {
            SqlHelper.ExecuteNonQuery(Database.ConnectionString, "Departments_Documents_Delete", ID);
            return ID;
        }
        catch (Exception ex)
        {
            return -1;
        }
    }

    public static DataTable SelectAll(int proj_proj_id)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Departments_Documents_Select",  proj_proj_id).Tables[0];

    }

    public static Departments_Documents_DT SelectByID(int id)
    {
        try
        {
            SqlDataReader drTableName;
            Departments_Documents_DT obj = new Departments_Documents_DT();
            if (id > 0)
            {
                drTableName = SqlHelper.ExecuteReader(Database.ConnectionString, "Departments_Documents_Select", id);
                if (drTableName != null)
                {
                    while (drTableName.Read())
                    {
                        obj = FillInfoObject(drTableName);
                    }

                    drTableName.Close();
                }
            }
            return obj;
        }
        catch (Exception ex)
        {

            return null;
        }

    }

    #endregion
}
