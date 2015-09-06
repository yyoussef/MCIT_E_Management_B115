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

public partial class UserControls_EvaluationCounter : System.Web.UI.UserControl
{
    //Session_CS Session_CS = new Session_CS();
    protected void Page_Load(object sender, EventArgs e)
    {
       // if (!IsPostBack)
       // {
            DataTable dt_mng = SqlHelper.ExecuteDataset(Database.ConnectionString, "Evaluation_For_HR_Manage", 0, 0).Tables[0];
           // lnkEvalMng.Text = dt_mng.Rows.Count.ToString();
            lnkEvalMng.Text = "لديك عدد (" + dt_mng.Rows.Count.ToString() + ") تم تقيمه من المدير المباشر";
            if (dt_mng.Rows.Count < 1)
                extentionMethods.DisableLinkButton(lnkEvalMng);

            DataTable dt_top = SqlHelper.ExecuteDataset(Database.ConnectionString, "Evaluation_For_HR_Top", 0, 0).Tables[0];
            //lnkEvalTop.Text = dt_top.Rows.Count.ToString();
            lnkEvalTop.Text = "لديك عدد (" + dt_top.Rows.Count.ToString() + ") تم تقيمه من المدير الأعلى";
            if (dt_top.Rows.Count < 1)
                extentionMethods.DisableLinkButton(lnkEvalTop);

            DataTable dt_Not_Eval = SqlHelper.ExecuteDataset(Database.ConnectionString, "Evaluation_For_dt_Not_Eval", 0, 0).Tables[0];
            //lnkNotEval.Text = dt_Not_Eval.Rows.Count.ToString();
            lnkNotEval.Text = "لديك عدد (" + dt_Not_Eval.Rows.Count.ToString() + ") لم يتم تقييمه";
            if (dt_Not_Eval.Rows.Count < 1)
                extentionMethods.DisableLinkButton(lnkNotEval);

            //if (CDataConverter.ConvertToInt(dt_mng.Rows.Count) > 0
            //    || CDataConverter.ConvertToInt(dt_top.Rows.Count) > 0
            //    || CDataConverter.ConvertToInt(dt_Not_Eval.Rows.Count) > 0)
            //{
            //    lblEvaluation.ForeColor = System.Drawing.Color.Red;
            //}
       // }
    }


    protected void lnkEvalMng_Click(object sender, EventArgs e)
    {
        if (CDataConverter.ConvertToInt(lnkEvalMng.Text) > 0)
        {
            Response.Redirect("Hr_Eval_Grid.aspx?type=1");
        }
    }

    protected void lnkEvalTop_Click(object sender, EventArgs e)
    {
        if (CDataConverter.ConvertToInt(lnkEvalTop.Text) > 0)
        {
            Response.Redirect("Hr_Eval_Grid.aspx?type=2");
        }

    }

    protected void lnkNotEval_Click(object sender, EventArgs e)
    {
        if (CDataConverter.ConvertToInt(lnkNotEval.Text) > 0)
        {
            Response.Redirect("Hr_Eval_Grid.aspx?type=3");
        }

    }

}
