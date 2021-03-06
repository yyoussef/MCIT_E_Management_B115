﻿using System;
using System.Data.SqlClient;
using System.Data;

using System.Web.UI.WebControls;
using System.Data.SqlTypes;

/// <summary>
/// Summary description for Agreement_Work_Order_DB
/// </summary>
public class Agreement_Work_Order_DB
{
    #region "Private methods"

    private static Agreement_Work_Order_DT FillInfoObject(SqlDataReader dr)
    {

        Agreement_Work_Order_DT oInfo_Work_Order = new Agreement_Work_Order_DT();


        oInfo_Work_Order.Work_Order_ID = Convert.ToInt32(dr[Agreement_Work_Order_DT.EnumInfo_Work_Order.Work_Order_ID.ToString()]);
        oInfo_Work_Order.Company_ID = dr[Agreement_Work_Order_DT.EnumInfo_Work_Order.Company_ID.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Agreement_Work_Order_DT.EnumInfo_Work_Order.Company_ID.ToString()]);
        oInfo_Work_Order.Tender_Type_ID = dr[Agreement_Work_Order_DT.EnumInfo_Work_Order.Tender_Type_ID.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Agreement_Work_Order_DT.EnumInfo_Work_Order.Tender_Type_ID.ToString()]);
        oInfo_Work_Order.Tender_NO = dr[Agreement_Work_Order_DT.EnumInfo_Work_Order.Tender_NO.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Agreement_Work_Order_DT.EnumInfo_Work_Order.Tender_NO.ToString()]);
        oInfo_Work_Order.Tender_Year = dr[Agreement_Work_Order_DT.EnumInfo_Work_Order.Tender_Year.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Agreement_Work_Order_DT.EnumInfo_Work_Order.Tender_Year.ToString()]);
        oInfo_Work_Order.Project_ID = dr[Agreement_Work_Order_DT.EnumInfo_Work_Order.Project_ID.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Agreement_Work_Order_DT.EnumInfo_Work_Order.Project_ID.ToString()]);
        oInfo_Work_Order.Work_Total_Value = dr[Agreement_Work_Order_DT.EnumInfo_Work_Order.Work_Total_Value.ToString()] == DBNull.Value ? 0 : Convert.ToDecimal(dr[Agreement_Work_Order_DT.EnumInfo_Work_Order.Work_Total_Value.ToString()]);
        oInfo_Work_Order.Bil_Total_Value = dr[Agreement_Work_Order_DT.EnumInfo_Work_Order.Bil_Total_Value.ToString()] == DBNull.Value ? 0 : Convert.ToDecimal(dr[Agreement_Work_Order_DT.EnumInfo_Work_Order.Bil_Total_Value.ToString()]);

        oInfo_Work_Order.Work_Image = dr[Agreement_Work_Order_DT.EnumInfo_Work_Order.Work_Image.ToString()] == DBNull.Value ? null : (Byte[])(dr[Agreement_Work_Order_DT.EnumInfo_Work_Order.Work_Image.ToString()]);
        oInfo_Work_Order.Work_File = dr[Agreement_Work_Order_DT.EnumInfo_Work_Order.Work_File.ToString()] == DBNull.Value ? null : (Byte[])(dr[Agreement_Work_Order_DT.EnumInfo_Work_Order.Work_File.ToString()]);
        oInfo_Work_Order.Contract_Image = dr[Agreement_Work_Order_DT.EnumInfo_Work_Order.Contract_Image.ToString()] == DBNull.Value ? null : (Byte[])(dr[Agreement_Work_Order_DT.EnumInfo_Work_Order.Contract_Image.ToString()]);
        oInfo_Work_Order.Contract_File = dr[Agreement_Work_Order_DT.EnumInfo_Work_Order.Contract_File.ToString()] == DBNull.Value ? null : (Byte[])(dr[Agreement_Work_Order_DT.EnumInfo_Work_Order.Contract_File.ToString()]);
        //oInfo_Work_Order.Work_Image = (byte[])dr[Agreement_Work_Order_DT.EnumInfo_Work_Order.Work_Image.ToString()];
        //oInfo_Work_Order.Work_File = (byte[])dr[Agreement_Work_Order_DT.EnumInfo_Work_Order.Work_File.ToString()];
        //oInfo_Work_Order.Contract_Image = (byte[])dr[Agreement_Work_Order_DT.EnumInfo_Work_Order.Contract_Image.ToString()];
        //oInfo_Work_Order.Contract_File = (byte[])dr[Agreement_Work_Order_DT.EnumInfo_Work_Order.Contract_File.ToString()];
        oInfo_Work_Order.Code = dr[Agreement_Work_Order_DT.EnumInfo_Work_Order.Code.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Agreement_Work_Order_DT.EnumInfo_Work_Order.Code.ToString()]);
        oInfo_Work_Order.Date = dr[Agreement_Work_Order_DT.EnumInfo_Work_Order.Date.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Agreement_Work_Order_DT.EnumInfo_Work_Order.Date.ToString()]);
        oInfo_Work_Order.Comapny_Period = dr[Agreement_Work_Order_DT.EnumInfo_Work_Order.Comapny_Period.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Agreement_Work_Order_DT.EnumInfo_Work_Order.Comapny_Period.ToString()]);
        oInfo_Work_Order.Work_Image_Type = dr[Agreement_Work_Order_DT.EnumInfo_Work_Order.Work_Image_Type.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Agreement_Work_Order_DT.EnumInfo_Work_Order.Work_Image_Type.ToString()]);
        oInfo_Work_Order.Work_File_Type = dr[Agreement_Work_Order_DT.EnumInfo_Work_Order.Work_File_Type.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Agreement_Work_Order_DT.EnumInfo_Work_Order.Work_File_Type.ToString()]);
        oInfo_Work_Order.Contract_Image_Type = dr[Agreement_Work_Order_DT.EnumInfo_Work_Order.Contract_Image_Type.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Agreement_Work_Order_DT.EnumInfo_Work_Order.Contract_Image_Type.ToString()]);
        oInfo_Work_Order.Contract_File_Type = dr[Agreement_Work_Order_DT.EnumInfo_Work_Order.Contract_File_Type.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Agreement_Work_Order_DT.EnumInfo_Work_Order.Contract_File_Type.ToString()]);
        oInfo_Work_Order.Agreement_id = dr[Agreement_Work_Order_DT.EnumInfo_Work_Order.Agreement_id.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Agreement_Work_Order_DT.EnumInfo_Work_Order.Agreement_id.ToString()]);
        oInfo_Work_Order.executed_by = dr[Agreement_Work_Order_DT.EnumInfo_Work_Order.executed_by.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Agreement_Work_Order_DT.EnumInfo_Work_Order.executed_by.ToString()]);
        return oInfo_Work_Order;
    }

    private static SqlParameter[] GetParameters(Agreement_Work_Order_DT obj, bool isSearch)
    {
        SqlParameter[] parms = new SqlParameter[13];


        if (!isSearch)
        {

            parms[0] = new SqlParameter(Agreement_Work_Order_DT.EnumInfo_Work_Order.Work_Order_ID.ToString(), obj.Work_Order_ID);
            parms[0].Direction = ParameterDirection.InputOutput;

        }

        parms[1] = new SqlParameter(Agreement_Work_Order_DT.EnumInfo_Work_Order.Company_ID.ToString(), obj.Company_ID);

        parms[2] = new SqlParameter(Agreement_Work_Order_DT.EnumInfo_Work_Order.Tender_Type_ID.ToString(), obj.Tender_Type_ID);

        parms[3] = new SqlParameter(Agreement_Work_Order_DT.EnumInfo_Work_Order.Tender_NO.ToString(), obj.Tender_NO);

        parms[4] = new SqlParameter(Agreement_Work_Order_DT.EnumInfo_Work_Order.Tender_Year.ToString(), obj.Tender_Year);

        parms[5] = new SqlParameter(Agreement_Work_Order_DT.EnumInfo_Work_Order.Project_ID.ToString(), obj.Project_ID);

        parms[6] = new SqlParameter(Agreement_Work_Order_DT.EnumInfo_Work_Order.Work_Total_Value.ToString(), obj.Work_Total_Value);

        parms[7] = new SqlParameter(Agreement_Work_Order_DT.EnumInfo_Work_Order.Bil_Total_Value.ToString(), obj.Bil_Total_Value);
        //if (obj.Work_Image != null)

        //    parms[8] = new SqlParameter(Agreement_Work_Order_DT.EnumInfo_Work_Order.Work_Image.ToString(), obj.Work_Image);
        //else
        //    parms[8] = new SqlParameter(Agreement_Work_Order_DT.EnumInfo_Work_Order.Work_Image.ToString(), SqlBinary.Null);

        //if (obj.Work_File != null)
        //    parms[9] = new SqlParameter(Agreement_Work_Order_DT.EnumInfo_Work_Order.Work_File.ToString(), obj.Work_File);
        //else
        //    parms[9] = new SqlParameter(Agreement_Work_Order_DT.EnumInfo_Work_Order.Work_File.ToString(), SqlBinary.Null);

        //if (obj.Contract_Image != null)
        //    parms[10] = new SqlParameter(Agreement_Work_Order_DT.EnumInfo_Work_Order.Contract_Image.ToString(), obj.Contract_Image);
        //else
        //    parms[10] = new SqlParameter(Agreement_Work_Order_DT.EnumInfo_Work_Order.Contract_Image.ToString(), SqlBinary.Null);

        //if (obj.Contract_File != null)
        //    parms[11] = new SqlParameter(Agreement_Work_Order_DT.EnumInfo_Work_Order.Contract_File.ToString(), obj.Contract_File);
        //else
        //    parms[11] = new SqlParameter(Agreement_Work_Order_DT.EnumInfo_Work_Order.Contract_File.ToString(), SqlBinary.Null);

        parms[8] = new SqlParameter(Agreement_Work_Order_DT.EnumInfo_Work_Order.Code.ToString(), obj.Code);

        parms[9] = new SqlParameter(Agreement_Work_Order_DT.EnumInfo_Work_Order.Date.ToString(), obj.Date);

        parms[10] = new SqlParameter(Agreement_Work_Order_DT.EnumInfo_Work_Order.Comapny_Period.ToString(), obj.Comapny_Period);

        //parms[11] = new SqlParameter(Agreement_Work_Order_DT.EnumInfo_Work_Order.Work_Image_Type.ToString(), obj.Work_Image_Type);

        //parms[12] = new SqlParameter(Agreement_Work_Order_DT.EnumInfo_Work_Order.Work_File_Type.ToString(), obj.Work_File_Type);

        //parms[13] = new SqlParameter(Agreement_Work_Order_DT.EnumInfo_Work_Order.Contract_Image_Type.ToString(), obj.Contract_Image_Type);

        //parms[14] = new SqlParameter(Agreement_Work_Order_DT.EnumInfo_Work_Order.Contract_File_Type.ToString(), obj.Contract_File_Type);
        parms[11] = new SqlParameter(Agreement_Work_Order_DT.EnumInfo_Work_Order.Agreement_id.ToString(), obj.Agreement_id);
        parms[12] = new SqlParameter(Agreement_Work_Order_DT.EnumInfo_Work_Order.executed_by.ToString(), obj.executed_by);
        
        return parms;
    }

    #endregion

    #region DataBase Function

    public static int Save(Agreement_Work_Order_DT obj)
    {
        try
        {
            SqlParameter[] parms = GetParameters(obj, false);

            SqlHelper.ExecuteScalar(Database.ConnectionString, CommandType.StoredProcedure, "Agreement_Work_Order_Save", parms);
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
            SqlHelper.ExecuteNonQuery(Database.ConnectionString, "Agreement_Work_Order_Delete", ID);
            return ID;
        }
        catch (Exception ex)
        {
            return -1;
        }
    }

    public static DataTable SelectAll(int proj_proj_id)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Agreement_Work_Order_Select", 0, proj_proj_id).Tables[0];

    }

    public static DataTable Select_by_ID_Datatable(int ID)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Agreement_Work_Order_Select", ID, 0).Tables[0];

    }

    public static Agreement_Work_Order_DT SelectByID(int ID)
    {
        try
        {
            SqlDataReader drTableName;
            Agreement_Work_Order_DT obj = new Agreement_Work_Order_DT();
            if (ID > 0)
            {
                drTableName = SqlHelper.ExecuteReader(Database.ConnectionString, "Agreement_Work_Order_Select", ID, 0);
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
