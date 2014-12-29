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

public partial class UserControls_geographic_scope : System.Web.UI.UserControl
{
    Session_CS Session_CS = new Session_CS();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //  fill_chklist();
            fill_datalist_gov();
            fil_desc();
            fil_chk_geo(CDataConverter.ConvertToInt(Session_CS.Project_id.ToString()));



        }
    }


    public void fill_datalist_gov()
    {
        DataTable dt = Governments_DB.Select_gov();

        datalist_gov.DataSource = dt;

        datalist_gov.DataBind();

    }

    public void fil_desc()
    {
        DataTable dt = Project_government_DB.Select_data(CDataConverter.ConvertToInt(Session_CS.Project_id.ToString()));

        if (dt.Rows.Count > 0)
        {
            DataRow dr = dt.Rows[0];
            txt_geo.Text = dt.Rows[0]["proj_gov_desc"].ToString();
        }
    }


    private void fil_chk_geo(int id)
    {
        string sqlsel = "select * from project_gov where Proj_id='" + id + "'";
        DataTable dt = General_Helping.GetDataTable(sqlsel);

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (dt.Rows.Count > 0)
            {

                foreach (DataListItem item in datalist_gov.Items)
                {
                    Label lbl_geo = (Label)item.FindControl("lbl_geo");
                    if (lbl_geo.Text == dt.Rows[i]["gov_id"].ToString())
                    //(lbl_geo.Text !="")
                    {
                        CheckBox chk_governments = (CheckBox)item.FindControl("chk_governments");

                        chk_governments.Checked = true;
                        TextBox txt_desc = (TextBox)item.FindControl("txt_desc");
                        txt_desc.Text = dt.Rows[i]["gov_notes"].ToString();
                        break;
                    }


                }

            }

        }







    }



    protected void btn_Save_scope_Click(object sender, EventArgs e)
    {
        Project_government_DB.Delete(CDataConverter.ConvertToInt(Session_CS.Project_id.ToString()));



        foreach (DataListItem item in datalist_gov.Items)
        {


            // HtmlInputCheckBox chk_governments = (HtmlInputCheckBox)item.FindControl("chk_governments");
            CheckBox chk_governments = (CheckBox)item.FindControl("chk_governments");
            if (chk_governments.Checked)
            {


                Project_governments_DT obj = new Project_governments_DT();
                obj.Proj_id = CDataConverter.ConvertToInt(Session_CS.Project_id.ToString());
                //obj.proj_gov_id = 0;
                // obj.gov_id = CDataConverter.ConvertToInt(chk_governments. );

                Label lbl_geo = (Label)item.FindControl("lbl_geo");
                obj.gov_id = CDataConverter.ConvertToInt(lbl_geo.Text);

                TextBox txt_desc = (TextBox)item.FindControl("txt_desc");
                obj.gov_notes = txt_desc.Text;

                Project_government_DB.save(obj);


            }







        }


        General_Helping.ExcuteQuery("update Project set proj_gov_desc='" + txt_geo.Text + "' where Proj_id='" + Session_CS.Project_id.ToString() + "'");
        Page.RegisterStartupScript("success", "<script language=javascript>alert('تم الحفظ بنجاح')</script>");

    }






}
