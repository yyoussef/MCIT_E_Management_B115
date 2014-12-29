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
using System.Text;
using System.Data.SqlClient;
using System.IO;
using System.Data.OleDb;
using System.Text.RegularExpressions;

public partial class excelimportMoataz : System.Web.UI.Page
{
    Session_CS Session_CS = new Session_CS();
    //private string sql_Connection = ConfigurationManager.AppSettings["ConnectionString"].ToString();

    protected void Page_Load(object sender, EventArgs e)
    {
        string filePath11 = "";
    }
   
    protected void Button1_Click(object sender, EventArgs e)
    {
       
        string filePath1 = "";
        try
        {

            string filePath = "";
            filePath = File1.Value;
            string strConn;
            strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" +
            "Data Source=" + filePath + ";" +
            "Extended Properties=Excel 8.0;";
            OleDbDataAdapter myCommand = new OleDbDataAdapter("SELECT * FROM [moataz$]", strConn);
            DataSet myDataSet = new DataSet();
            myCommand.Fill(myDataSet, "ExcelInfo");
            //GridView1.DataSource = myDataSet.Tables["ExcelInfo"].DefaultView;
            //GridView1.DataBind();

            DataTable dt = myDataSet.Tables["ExcelInfo"];
            DataTable dt2 = new DataTable();

            SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString);
            for (int o = 0; o < dt.Rows.Count; o++) // Loop over the rows.
            {
                SqlDataAdapter sqladptr = new SqlDataAdapter();
               // string tempOrg = dt.Rows[o][1].ToString().Trim();
                string Name = dt.Rows[o][0].ToString().Trim();
                //tempOrg = tempOrg.Replace('أ', 'ا');
                //tempOrg = tempOrg.Replace('إ', 'ا');
                //tempOrg = tempOrg.Replace('آ', 'ا');
                //tempOrg = tempOrg.Replace('ي', 'ى');
                //tempOrg = tempOrg.Replace('ة', 'ه');
                //tempOrg = Regex.Replace(tempOrg, @"\s+", " ");
                //dt.Rows[o][3] = tempOrg;

                //string codeNo = Regex.Replace(dt.Rows[o][1].ToString().Trim(), @"\s+", " ");
                //int slaches = CountChar(codeNo, '/');
                //if (slaches == 3)
                //{
                //    int slachPos = codeNo.IndexOf('/');
                //    codeNo = codeNo.Substring(0, slachPos);
                //}

                ////<add name="ConnectionString" connectionString="Data Source=M116-YOUSSEF;Initial Catalog=MCIT_PROJECTS;Persist Security Info=True;User ID=sa;Password=sa" providerName="System.Data.SqlClient"/>
                //string OutBoxAll = Regex.Replace(dt.Rows[o][2].ToString().Trim(), @"\s+", " ");
                //string OutBoxDate = "";
                //string OutBoxCode = "";
                //int outSlaches = CountChar(OutBoxAll, '/');
                //if (outSlaches == 3)
                //{
                //    int slachOutPos = OutBoxAll.IndexOf('/');
                //    OutBoxDate = OutBoxAll.Substring(slachOutPos + 1);
                //    OutBoxCode = OutBoxAll.Substring(0, slachOutPos);
                //    int slachOutPos2 = 2;
                //}
                //else
                //{
                //    OutBoxDate = OutBoxAll;
                //}
               
                //string tempDate = dt.Rows[o][1].ToString().Trim();
                string date = dt.Rows[o][1].ToString().Trim();
                //if (tempDate.Length > 10)
                //    tempDate = tempDate.Substring(0, 10);
               // string tempVisaDate = dt.Rows[o][0].ToString().Trim();
                string Notes = dt.Rows[o][0].ToString().Trim();
                //if (tempVisaDate.Length > 10)
                //    tempVisaDate = tempVisaDate.Substring(0, 10);
                
                SqlCommand com1 = new SqlCommand("insert into moataz  values ('"+Name+"','"+date+"','"+Notes+"') ", con1);
                //string commText = " insert into Inbox (Date,Code,Org_Out_Box_DT,Org_Out_Box_Code,Org_Name,Subject,Paper_No,Notes,Follow_Up_Notes) " +
                //                                 " values ('" + tempDate + "', '" + codeNo + "', '" + OutBoxDate + "', '" + OutBoxCode + "', '" + dt.Rows[o][3] + "', '" + dt.Rows[o][4] + "', '" + 
                //                                 dt.Rows[o][5] + "', 'تم الرد " + dt.Rows[o][7] + "', '" + dt.Rows[o][14] + " " + dt.Rows[o][15] + "') ";

                com1.CommandType = CommandType.Text;
                con1.Open();
                try
                {
                    com1.ExecuteNonQuery();
                }
                catch { }
                //int yu = 0;
                //try 
                //{
                //    com1.CommandText = commText;
                //    com1.ExecuteNonQuery();

                //    commText = " select max(ID) as ID from Inbox";
                //    com1.CommandText = commText;
                //    sqladptr.SelectCommand = com1;
                //    DataTable maxID = new DataTable();
                //    sqladptr.Fill(maxID);

                //    commText = " insert into Inbox_Visa (Inbox_ID,Visa_date,Important_Degree_Txt,Emp_ID_Txt,Dept_ID_Txt,Visa_Desc,Visa_Period) " +
                //                                 " values (" + maxID.Rows[0][0] + ",'" + tempVisaDate + "', '" + dt.Rows[o][9] + "', '" + dt.Rows[o][10] + "', '" + dt.Rows[o][11] + "', '" + dt.Rows[o][12] + "', '" +
                //                                 dt.Rows[o][13] + "') ";
                //    com1.CommandText = commText;
                //    com1.ExecuteNonQuery();
                //}
                //catch 
                //{
                //    int s = 0;
                //}

                con1.Close();
            }

            //using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            //{
            //    cn.Open();
            //    using (SqlBulkCopy copy = new SqlBulkCopy(cn))
            //    {
            //        copy.ColumnMappings.Add(0, 1);
            //        copy.ColumnMappings.Add(1, 2);
            //        copy.ColumnMappings.Add(2, 3);
            //        copy.ColumnMappings.Add(3, 4);
            //        copy.ColumnMappings.Add(4, 5);
            //        copy.ColumnMappings.Add(5, 6);
            //        copy.ColumnMappings.Add(6, 7);
            //        copy.ColumnMappings.Add(7, 8);
            //        copy.ColumnMappings.Add(8, 9);
            //        copy.ColumnMappings.Add(9, 10);
            //        copy.ColumnMappings.Add(10, 11);
            //        copy.ColumnMappings.Add(11, 12);
            //        copy.ColumnMappings.Add(12, 13);
            //        copy.ColumnMappings.Add(13, 14);
            //        copy.ColumnMappings.Add(14, 15);
            //        copy.ColumnMappings.Add(15, 16);
            //        copy.ColumnMappings.Add(16, 17);
            //        copy.ColumnMappings.Add(17, 18);
            //        copy.ColumnMappings.Add(18, 19);

            //        copy.DestinationTableName = "Inbox_letters";
            //        //copy.WriteToServer(dt);
            //    }
            //}
        }
        //catch
        //{
        //}
        finally
        {
        }
    }
    public static int CountChar(string input, char c)
    {
        int retval = 0;
        for (int i = 0; i < input.Length; i++)
            if (c == input[i])
                retval++;
        return retval;
    }

}
