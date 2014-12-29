using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Collections.Generic;

public partial class MainForm_Eval_Report_Details : System.Web.UI.Page
{
    Session_CS Session_CS = new Session_CS();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Fill_EmployeeData();
            Fill_Grid();
        }

    }

    private void Fill_EmployeeData()
    {
        if (Request["id"] != "" && Request["id"] != null)
        {
            String decrypted_id = Encryption.Decrypt(Request.QueryString["id"].ToString());

            DataTable dt = Employee_Data_DB.Select_EvaluatedEmployeeData(CDataConverter.ConvertToInt( decrypted_id));
            if (dt.Rows.Count > 0)
            {
                Label3.Text = dt.Rows[0]["pmp_name"].ToString();
                Label7.Text = dt.Rows[0]["Dept_name"].ToString();
                Label8.Text = dt.Rows[0]["Sec_name"].ToString();

                if (dt.Rows[0]["Hire_date"].ToString() == DBNull.Value.ToString())
                {

                    Label9.Text = "ــــ";

                }
                else
                {
                    Label9.Text = dt.Rows[0]["Hire_date"].ToString();
                }
                if (dt.Rows[0]["pmp_title"].ToString() == DBNull.Value.ToString())
                {

                    Label10.Text = "ــــ";

                }
                else
                {

                    Label10.Text = dt.Rows[0]["pmp_title"].ToString();
                }

                if (dt.Rows[0]["job_no"].ToString() == DBNull.Value.ToString()   )
                {

                    Label11.Text = "ــــ";

                }
                else
                {
                    Label11.Text = dt.Rows[0]["job_no"].ToString();
                }
            }
        }


    }

    private void Fill_Grid()
    {
        if (Request["id"] != "" && Request["id"] != null)
        {
         String decrypted_id = Encryption.Decrypt(Request.QueryString["id"].ToString());
         DataTable dt = Evaluation_For_Manager_DB.Evaluation_Manager_DetailedDegrees(CDataConverter.ConvertToInt(decrypted_id ));
         GvDetails.DataSource = dt;
         GvDetails.DataBind();
         Calc_Total_For_Eval(dt);

        }
    }

    private void Calc_Total_For_Eval(DataTable DT)
    {

        if (DT.Rows.Count > 4)
        {
            string lbl_text = "  الإجمالى الكلى : ";
            int No_Evaluator = (DT.Columns.Count - 4) / 2;
            int strt_colum = 4;
            decimal lbl_avg=0;
            for (int i = 1; i <= No_Evaluator; i++)
            {
                decimal Eval_total = Get_Eval_Value(DT, strt_colum);
               
                lbl_text += "الموظف "+i+" : " + Eval_total + "% , ";
                strt_colum += 2;

                
            }

            if (DT.Columns.Count > 4)
            {
                decimal mng_avg = Get_Eval_tot(DT, DT.Columns.Count - 1);

                lbl_avg = mng_avg / No_Evaluator;
            }

            

            lbl_total.Text = lbl_text;

            lbl_average.Text= " إجمالي التقييم الكلي للمدير :"+ lbl_avg.ToString()+ " % ";
           
        }

        
    }

    private static decimal Get_Eval_Value(DataTable DT, int strt_colum)
    {
        decimal Eval_total = 0;
        foreach (DataRow Current_Row in DT.Rows)
        {
            Eval_total += Convert.ToDecimal(Current_Row[strt_colum].ToString());


        }
        return Eval_total;
    }


    private static decimal Get_Eval_tot(DataTable DT, int strt_colum)
    {
        decimal Eval_totall = 0;
        foreach (DataRow Current_Row in DT.Rows)
        {
            if (DT.Columns.Count > 4)
            {
                Eval_totall += Convert.ToDecimal(Current_Row[strt_colum].ToString());
            }
            else
            {
                
            }


        }
        return Eval_totall;
    }
}
