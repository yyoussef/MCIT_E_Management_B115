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
using System.Data;

/// <summary>
/// Summary description for Evaluation_Dept_Weightsc
/// </summary>
public class Evaluation_Dept_Weight_DB
{
    #region "Private methods"
    private static Evaluation_Dept_Weight_DT FillInfoObject(SqlDataReader dr)
    {
        Evaluation_Dept_Weight_DT oeval_dept_weight_DT = new Evaluation_Dept_Weight_DT();

        oeval_dept_weight_DT.Weight_Id = Convert.ToInt32(dr[Evaluation_Dept_Weight_DT.EnumInfo_Evaluation_Dept_Weight.Weight_Id.ToString()]);
        oeval_dept_weight_DT.Dept_id = dr[Evaluation_Dept_Weight_DT.EnumInfo_Evaluation_Dept_Weight.Dept_id.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Evaluation_Dept_Weight_DT.EnumInfo_Evaluation_Dept_Weight.Dept_id.ToString()]);
        oeval_dept_weight_DT.Main_Item_Id = dr[Evaluation_Dept_Weight_DT.EnumInfo_Evaluation_Dept_Weight.Main_Item_Id.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Evaluation_Dept_Weight_DT.EnumInfo_Evaluation_Dept_Weight.Main_Item_Id.ToString()]);
        oeval_dept_weight_DT.Sub_Item_Id = dr[Evaluation_Dept_Weight_DT.EnumInfo_Evaluation_Dept_Weight.Sub_Item_Id.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Evaluation_Dept_Weight_DT.EnumInfo_Evaluation_Dept_Weight.Sub_Item_Id.ToString()]);
        oeval_dept_weight_DT.Weight = dr[Evaluation_Dept_Weight_DT.EnumInfo_Evaluation_Dept_Weight.Weight.ToString()] == DBNull.Value ? 0 : Convert.ToDecimal(dr[Evaluation_Dept_Weight_DT.EnumInfo_Evaluation_Dept_Weight.Weight.ToString()]);
        oeval_dept_weight_DT.category = dr[Evaluation_Dept_Weight_DT.EnumInfo_Evaluation_Dept_Weight.category.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Evaluation_Dept_Weight_DT.EnumInfo_Evaluation_Dept_Weight.category.ToString()]);
        return oeval_dept_weight_DT;

    }
    private static SqlParameter[] GetParameters(Evaluation_Dept_Weight_DT obj, bool isSearch)
    {
        SqlParameter[] parms = new SqlParameter[6];


        if (!isSearch)
        {

            parms[0] = new SqlParameter(Evaluation_Dept_Weight_DT.EnumInfo_Evaluation_Dept_Weight.Weight_Id.ToString(), obj.Weight_Id);
            parms[0].Direction = ParameterDirection.InputOutput;

        }

        parms[1] = new SqlParameter(Evaluation_Dept_Weight_DT.EnumInfo_Evaluation_Dept_Weight.Dept_id.ToString(), obj.Dept_id);

        parms[2] = new SqlParameter(Evaluation_Dept_Weight_DT.EnumInfo_Evaluation_Dept_Weight.Main_Item_Id.ToString(), obj.Main_Item_Id);

        parms[3] = new SqlParameter(Evaluation_Dept_Weight_DT.EnumInfo_Evaluation_Dept_Weight.Sub_Item_Id.ToString(), obj.Sub_Item_Id);

        parms[4] = new SqlParameter(Evaluation_Dept_Weight_DT.EnumInfo_Evaluation_Dept_Weight.Weight.ToString(), obj.Weight);
        parms[5] = new SqlParameter(Evaluation_Dept_Weight_DT.EnumInfo_Evaluation_Dept_Weight.category.ToString(), obj.category);

        return parms;
    }
    #endregion

    #region DataBase Function

    public static int Save(Evaluation_Dept_Weight_DT obj)
    {
        try
        {
            SqlParameter[] parms = GetParameters(obj, false);

            SqlHelper.ExecuteScalar(Database.ConnectionString, CommandType.StoredProcedure, "Evaluation_Dept_Weight_save", parms);
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
            SqlHelper.ExecuteNonQuery(Database.ConnectionString, "Evaluation_Dept_Weight_delete", ID);
            return ID;
        }
        catch (Exception ex)
        {
            return -1;
        }
    }

    public static DataTable SelectAll()
    {
        int proj_proj_id = 0;
        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Evaluation_Dept_Weight_select", proj_proj_id).Tables[0];

    }

    public static Evaluation_Dept_Weight_DT SelectByID(int ID)
    {
        try
        {
            SqlDataReader drTableName;
            Evaluation_Dept_Weight_DT obj = new Evaluation_Dept_Weight_DT();
            if (ID > 0)
            {
                drTableName = SqlHelper.ExecuteReader(Database.ConnectionString, "Evaluation_Dept_Weight_select", ID);
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
    public static Evaluation_Dept_Weight_DT otherSelectByID(int Sub_Item_Id, int main_item_Id, int dept_id, int category)
    {
        try
        {
            SqlDataReader drTableName;
            Evaluation_Dept_Weight_DT obj = new Evaluation_Dept_Weight_DT();

            drTableName = SqlHelper.ExecuteReader(Database.ConnectionString, "Evaluation_Dept_Weight_otherselect", Sub_Item_Id, main_item_Id, dept_id, category);
            if (drTableName != null)
            {
                while (drTableName.Read())
                {
                    obj = FillInfoObject(drTableName);
                }

                drTableName.Close();
            }
            return obj;
        }
        catch (Exception ex)
        {

            return null;
        }

    }


    public static DataTable Evaluation_Dept_Weight_sum(int dept_id,int category)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Evaluation_Dept_Weight_sum", dept_id, category).Tables[0];

    }
    public static DataTable EvaluationDeptWeight_checkExist(int dept_id,int main_id,int sub_id,int category)
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "Evaluation_Dept_Weightselect_bycategory", dept_id,main_id ,sub_id,category).Tables[0];
        
    }

    #endregion
}