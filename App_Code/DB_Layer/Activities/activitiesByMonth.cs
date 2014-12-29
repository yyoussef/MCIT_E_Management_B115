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
/// Summary description for activitiesByMonth
/// </summary>
/// 

namespace activityversions
{
    public class activitiesByMonth
    {
        public static DataTable main_dt;
        public static DataTable final_dt;
        public static DataTable lvl_dt;
        public static DataTable getActivitiesByMonth(String TargetMonth,String TargetYear,Int32 proj_id )
        {
            main_dt = SqlHelper.ExecuteDataset(Database.ConnectionString, "Project_Activities_select_by_month_year", TargetMonth, TargetYear, proj_id).Tables[0];
            final_dt = main_dt.Clone();
            go_level(0);
            return final_dt;
        }

        public static int my_lvl = 1;
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
