using System;
using System.Data.SqlClient;
using System.Data;

using System.Web.UI.WebControls;
using System.Data.SqlTypes;

/// <summary>
/// Summary description for Fin_Work_bill_Needs_DB
/// </summary>
public class Fin_Work_bill_Needs_DB
{
    #region "Private methods"

    private static Fin_Work_bill_Needs_DT FillInfoObject(SqlDataReader dr)
    {

        Fin_Work_bill_Needs_DT oInfo_Work_bill_Needs = new Fin_Work_bill_Needs_DT();


        oInfo_Work_bill_Needs.Fin_Need_ID = Convert.ToInt32(dr[Fin_Work_bill_Needs_DT.EnumInfo_Work_bill_Needs.Fin_Need_ID.ToString()]);
        oInfo_Work_bill_Needs.NMT_ID = dr[Fin_Work_bill_Needs_DT.EnumInfo_Work_bill_Needs.NMT_ID.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Fin_Work_bill_Needs_DT.EnumInfo_Work_bill_Needs.NMT_ID.ToString()]);
        oInfo_Work_bill_Needs.NST_ID = dr[Fin_Work_bill_Needs_DT.EnumInfo_Work_bill_Needs.NST_ID.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Fin_Work_bill_Needs_DT.EnumInfo_Work_bill_Needs.NST_ID.ToString()]);
        oInfo_Work_bill_Needs.Value = dr[Fin_Work_bill_Needs_DT.EnumInfo_Work_bill_Needs.Value.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Fin_Work_bill_Needs_DT.EnumInfo_Work_bill_Needs.Value.ToString()]);
        oInfo_Work_bill_Needs.Work_Or_Bill = dr[Fin_Work_bill_Needs_DT.EnumInfo_Work_bill_Needs.Work_Or_Bill.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Fin_Work_bill_Needs_DT.EnumInfo_Work_bill_Needs.Work_Or_Bill.ToString()]);
        oInfo_Work_bill_Needs.Work_Or_Bill_ID = dr[Fin_Work_bill_Needs_DT.EnumInfo_Work_bill_Needs.Work_Or_Bill_ID.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Fin_Work_bill_Needs_DT.EnumInfo_Work_bill_Needs.Work_Or_Bill_ID.ToString()]);

        return oInfo_Work_bill_Needs;
    }

    private static SqlParameter[] GetParameters(Fin_Work_bill_Needs_DT obj, bool isSearch)
    {
        SqlParameter[] parms = new SqlParameter[6];


        if (!isSearch)
        {

            parms[0] = new SqlParameter(Fin_Work_bill_Needs_DT.EnumInfo_Work_bill_Needs.Fin_Need_ID.ToString(), obj.Fin_Need_ID);
            parms[0].Direction = ParameterDirection.InputOutput;

        }

        parms[1] = new SqlParameter(Fin_Work_bill_Needs_DT.EnumInfo_Work_bill_Needs.NMT_ID.ToString(), obj.NMT_ID);

        parms[2] = new SqlParameter(Fin_Work_bill_Needs_DT.EnumInfo_Work_bill_Needs.NST_ID.ToString(), obj.NST_ID);

        parms[3] = new SqlParameter(Fin_Work_bill_Needs_DT.EnumInfo_Work_bill_Needs.Value.ToString(), obj.Value);

        parms[4] = new SqlParameter(Fin_Work_bill_Needs_DT.EnumInfo_Work_bill_Needs.Work_Or_Bill.ToString(), obj.Work_Or_Bill);

        parms[5] = new SqlParameter(Fin_Work_bill_Needs_DT.EnumInfo_Work_bill_Needs.Work_Or_Bill_ID.ToString(), obj.Work_Or_Bill_ID);

        return parms;
    }

    #endregion

    public static int Save(Fin_Work_bill_Needs_DT obj)
    {
        try
        {
            SqlParameter[] parms = GetParameters(obj, false);

            SqlHelper.ExecuteScalar(Database.ConnectionString, CommandType.StoredProcedure, "Fin_Work_bill_Needs_Save", parms);
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
            SqlHelper.ExecuteNonQuery(Database.ConnectionString, "Fin_Work_bill_Needs_Delete", ID);
            return ID;
        }
        catch (Exception ex)
        {
            return -1;
        }
    }

    public static DataTable SelectAll()
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Fin_Work_bill_Needs_Select", 0).Tables[0];

    }

   public static Fin_Work_bill_Needs_DT SelectByID(int ID)
    {
        try
        {
            SqlDataReader drTableName;
            Fin_Work_bill_Needs_DT obj = new Fin_Work_bill_Needs_DT();
            if (ID > 0)
            {
                drTableName = SqlHelper.ExecuteReader(Database.ConnectionString, "Fin_Work_bill_Needs_Select", ID);
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

   public static DataTable SelectAll_by_Parent_id(int ID, int Type_id)
   {
       return SqlHelper.ExecuteDataset(Database.ConnectionString, "Fin_Work_bill_Needs_Select_byParent_ID", ID, Type_id).Tables[0];
   }
}
