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




    public class project_success_elemets_DB
    {
        private static project_success_elements_DT  FillInfoObject(SqlDataReader dr)
        {
            project_success_elements_DT  oproject_success_elemets_DT = new project_success_elements_DT ();
            oproject_success_elemets_DT.id = dr[project_success_elements_DT .EnumInfo_project_success_elements.id.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[project_success_elements_DT.EnumInfo_project_success_elements.id.ToString()]);
            oproject_success_elemets_DT.succ_elm_desc = dr[project_success_elements_DT .EnumInfo_project_success_elements.succ_elm_desc.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[project_success_elements_DT .EnumInfo_project_success_elements.succ_elm_desc.ToString()]);
            oproject_success_elemets_DT.style_deal = dr[project_success_elements_DT .EnumInfo_project_success_elements.style_deal.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[project_success_elements_DT .EnumInfo_project_success_elements.style_deal.ToString()]);
            oproject_success_elemets_DT.proj_id = dr[project_success_elements_DT .EnumInfo_project_success_elements.proj_id.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[project_success_elements_DT .EnumInfo_project_success_elements.proj_id.ToString()]);
            return oproject_success_elemets_DT ;
        }

        private static SqlParameter[] GetParameters(project_success_elements_DT   obj, bool isSearch)
        {
            SqlParameter[] parms = new SqlParameter[4];

            if (!isSearch)
            {

                parms[0] = new SqlParameter(project_success_elements_DT .EnumInfo_project_success_elements.id.ToString(), obj.id);
                parms[0].Direction = ParameterDirection.InputOutput;

            }

            //parms[0] = new SqlParameter(Project_Attitude_DT.EnumInfo_Project_Attitude.id.ToString(),obj.id );
            parms[1] = new SqlParameter(project_success_elements_DT .EnumInfo_project_success_elements.succ_elm_desc.ToString(), obj.succ_elm_desc);
            parms[2] = new SqlParameter(project_success_elements_DT .EnumInfo_project_success_elements.style_deal.ToString(), obj.style_deal);
            parms[3] = new SqlParameter(project_success_elements_DT .EnumInfo_project_success_elements.proj_id.ToString(), obj.proj_id);

            return parms;

        }

        public static int Save(project_success_elements_DT  obj)
        {
            try
            {
                SqlParameter[] parms = GetParameters(obj, false);

                SqlHelper.ExecuteScalar(Database.ConnectionString, CommandType.StoredProcedure, "Project_success_elements_save", parms);
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
                SqlHelper.ExecuteNonQuery(Database.ConnectionString, "Project_success_elements_delete", ID);
                return ID;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public static DataTable SelectAll(int proj_id)
        {

            return SqlHelper.ExecuteDataset(Database.ConnectionString, "Project_success_elements_select", proj_id, 0).Tables[0];

        }

        public static project_success_elements_DT  SelectByID(int ID)
        {
            try
            {
                SqlDataReader drTableName;
                project_success_elements_DT obj = new project_success_elements_DT();
                if (ID > 0)
                {
                    drTableName = SqlHelper.ExecuteReader(Database.ConnectionString, "Project_success_elements_select", 0, ID);
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


    }


