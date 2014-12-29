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

/// <summary>
/// Summary description for ActivLevls
/// </summary>

namespace activityLeveling
{
    public class ActivLevls
    {
        public static DataTable main_dt;
        public static DataTable final_dt;
        public static DataTable lvl_dt;
        public static DataTable leveling(Int32 proj_id, Int32 dept_id, Int32 pmp_id, Int32 join_const, Int32 join_indicators)
        {

            String general_sql = "select * ";
            if (join_const != 0)
            {
            general_sql += ",Project_Constraints.PCONS_IS_CRITICAL";
            }
            general_sql += ",(Case When PActv_Parent=0 Then PActv_Desc Else null End)as parent,(Case When PActv_Parent=0 Then 0 Else null End) as Parent_Actv_Num,PActv_Parent as LVL from Project_Activities ";
            general_sql += " join project on Project_Activities.proj_proj_id=project.proj_id ";
            general_sql += " LEFT JOIN Departments on project.Dept_Dept_id=Departments.Dept_ID ";
            general_sql += " LEFT JOIN Active_Satatus on Project_Activities.ActStat_ActStat_id=Active_Satatus.ActStat_ID ";
            general_sql += " LEFT JOIN Organization on Project_Activities.Excutive_responsible_Org_Org_id = Organization.org_id ";
            if (join_const != 0)
            {
                general_sql += " JOIN dbo.Project_Constraints ON dbo.Project_Activities.PActv_ID = dbo.Project_Constraints.PActv_PActv_ID ";
            }
            if (join_indicators != 0)
            {
                general_sql += "  JOIN Project_Activities_Indicators on Project_Activities.PActv_ID=Project_Activities_Indicators.pactv_pactv_id ";
                general_sql += "  JOIN Indicators_Type on Project_Activities_Indicators.indt_indt_id=Indicators_Type.IndT_id ";
                general_sql += "  JOIN Project_Activity_indicator_period on Project_Activities_Indicators.PAIP_period_id=Project_Activity_indicator_period.ID";
                
            }
          
            general_sql += " where 1=1";
            if (proj_id != 0)
            {
                general_sql += " and project.proj_id=" + proj_id;
            }
            else if (pmp_id != 0)
            {
                general_sql += " and project.pmp_pmp_id=" + pmp_id ;
            }
            else if (dept_id != 0)
            {
                general_sql += " and  project.dept_dept_id=" + dept_id;
            }
            general_sql += " order by PActv_ID";
            main_dt = General_Helping.GetDataTable(general_sql);
            if (join_const != 0)
                return main_dt;
            else
            {
                final_dt = main_dt.Clone();
                go_level(0);
                return final_dt;
            }
        }





        public static DataTable levelingacvtivity(Int32 proj_id, Int32 dept_id, Int32 pmp_id, Int32 join_const, Int32 join_indicators,int activ_Parent)
        {

            String general_sql = "select * ";
            if (join_const != 0)
            {
                general_sql += ",Project_Constraints.PCONS_IS_CRITICAL";
            }
            general_sql += ",(Case When PActv_Parent=0 Then PActv_Desc Else null End)as parent,(Case When PActv_Parent!=0 Then PActv_Desc Else null End)as PActv_Desc2,(Case When PActv_Parent=0 Then 0 Else null End) as Parent_Actv_Num,PActv_Parent as LVL from Project_Activities ";
            general_sql += " join project on Project_Activities.proj_proj_id=project.proj_id ";
            general_sql += " LEFT JOIN Departments on project.Dept_Dept_id=Departments.Dept_ID ";
            general_sql += " LEFT JOIN Active_Satatus on Project_Activities.ActStat_ActStat_id=Active_Satatus.ActStat_ID ";
            general_sql += " LEFT JOIN Organization on Project_Activities.Excutive_responsible_Org_Org_id = Organization.org_id ";
            if (join_const != 0)
            {
                general_sql += " JOIN dbo.Project_Constraints ON dbo.Project_Activities.PActv_ID = dbo.Project_Constraints.PActv_PActv_ID ";
            }
            if (join_indicators != 0)
            {
                general_sql += "  JOIN Project_Activities_Indicators on Project_Activities.PActv_ID=Project_Activities_Indicators.pactv_pactv_id ";
                general_sql += "  JOIN Indicators_Type on Project_Activities_Indicators.indt_indt_id=Indicators_Type.IndT_id ";
                general_sql += "  JOIN Project_Activity_indicator_period on Project_Activities_Indicators.PAIP_period_id=Project_Activity_indicator_period.ID";

            }

            general_sql += " where 1=1 and Project_Activities.PActv_Parent='"+ activ_Parent+"' or Project_Activities.PActv_ID="+activ_Parent  ;
            if (proj_id != 0)
            {
                general_sql += " and project.proj_id=" + proj_id;
            }
            else if (pmp_id != 0)
            {
                general_sql += " and project.pmp_pmp_id=" + pmp_id;
            }
            else if (dept_id != 0)
            {
                general_sql += " and  project.dept_dept_id=" + dept_id;
            }


            general_sql += " order by PActv_ID";
            main_dt = General_Helping.GetDataTable(general_sql);
           // if (join_const != 0)
                return main_dt;
            //else
            //{
            //   final_dt = main_dt.Clone();
            //    go_level(0);
            //    return final_dt;
            //}
        }




        public static int my_lvl = 1;

        public static DataTable leveling_For_Activities_Station(Int32 proj_id, int Month_id)
        {

            String general_sql = " SELECT * , (CASE WHEN PActv_Parent = 0 THEN PActv_Desc ELSE NULL END) AS parent, (CASE WHEN PActv_Parent = 0 THEN 0 ELSE NULL END) AS Parent_Actv_Num , PActv_Parent AS LVL from Project_Activities_Station_View_All ";
            
            
            general_sql += " where 1=1";
            if (proj_id != 0)
            {
                general_sql += " and proj_proj_id=" + proj_id;
            }
            if (Month_id != 0)
            {
                general_sql += " and Month_id=" + Month_id;
            }

            general_sql += " order by PActv_ID";

            main_dt = General_Helping.GetDataTable(general_sql);
            final_dt = main_dt.Clone();
            go_level(0);
            return final_dt;
        }

        public static DataTable leveling_For_Activities_Station_For_Grid(Int32 proj_id, int Month_id)
        {


            //String general_sql = "select * , (CASE WHEN PActv_Parent = 0 THEN PActv_Desc ELSE NULL END) AS parent, (CASE WHEN PActv_Parent = 0 THEN 0 ELSE NULL END) AS Parent_Actv_Num , PActv_Parent AS LVL from Project_Activities_Station_View_For_Grid ";


            //general_sql += " where 1=1";
            //if (proj_id != 0)
            //{
            //    general_sql += " and proj_proj_id=" + proj_id;
            //}
            //if (Month_id != 0)
            //{
            //    general_sql += " and Month_id in (0," + Month_id+")";
            //}

            //general_sql += " order by PActv_ID";

            main_dt = SqlHelper.ExecuteDataset(Database.ConnectionString, "Project_Activities_Station_Grid", proj_id, Month_id).Tables[0];
            final_dt = main_dt.Clone();
            go_level(0);
            return final_dt;
        }

        public static void go_level(Int32 activID)
        {
            int count = 1;
            foreach (DataRow activRow in main_dt.Rows)
            {
                if (CDataConverter.ConvertToInt(activRow["PActv_Parent"]) == 0)
                {
                    activRow["PActv_Desc"] = null;
                    activRow["Parent_Actv_Num"] = count;
                    count++;
                }
                if (CDataConverter.ConvertToInt(activRow["PActv_Parent"]) == activID)
                {
                    my_lvl = 1;
                    iterateLVL(CDataConverter.ConvertToInt(activRow["PActv_ID"]));
                    activRow["LVL"] = my_lvl;
                    final_dt.ImportRow(activRow);
                    final_dt.AcceptChanges();
                    go_level(CDataConverter.ConvertToInt(activRow["PActv_ID"]));
                   

                }

            }
        }
        
      
        private static void iterateLVL(Int32 activID)
        {
            String lvl_sql = "select * from Project_Activities where PActv_ID= " + activID;
            lvl_dt = General_Helping.GetDataTable(lvl_sql);
            if (lvl_dt.Rows.Count > 0)
            {
                if (CDataConverter.ConvertToInt(lvl_dt.Rows[0]["PActv_Parent"]) != 0)
                {
                    my_lvl++;
                    iterateLVL(CDataConverter.ConvertToInt(lvl_dt.Rows[0]["PActv_Parent"]));
                }
            }
        }
    }
}
