using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Eval_Update_Emp : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string Sql = " select * from Evaluation_For_Employee where year = 2015 ";
            DataTable dt = General_Helping.GetDataTable(Sql);
            foreach (DataRow dr in dt.Rows)
            {
                DataTable DT_eval = SqlHelper.ExecuteDataset(Database.ConnectionString, "Eval_Calc_Emp_Select", CDataConverter.ConvertToInt(dr["Pmp_Id"].ToString())).Tables[0];
                if (DT_eval.Rows.Count > 0)
                {
                    string sql_update = " update Evaluation_For_Employee set Direct_Mng_Eval =" + CDataConverter.ConvertToDecimal(DT_eval.Rows[0]["Direct_Mng_Eval"]) +
                                        " , Top_Mng_Eval = " + CDataConverter.ConvertToDecimal(DT_eval.Rows[0]["Top_Mng_Eval"]) +
                                        " , Final_Eval_Degree = " + CDataConverter.ConvertToDecimal(DT_eval.Rows[0]["Final_Eval_Degree"]) +
                                        " where Evaluation_id = " + CDataConverter.ConvertToInt(dr["Evaluation_id"].ToString());
                    General_Helping.ExcuteQuery(sql_update);


                }

            }


        }

    }
}
