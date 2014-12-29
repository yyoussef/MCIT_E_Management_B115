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

using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;

public partial class UserControls_MemorandumShow : System.Web.UI.UserControl
{
    Session_CS Session_CS = new Session_CS();
    string sql;
    SqlConnection conn;
    SqlDataAdapter da;
    DataSet ds;
    SqlCommand cmd;
    private string sql_Connection = Database.ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //int pmp = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString());
            //string File_Name_Show = "";
            //string File_Name = "";

            //if (CDataConverter.ConvertToInt(Session_CS.parent_id.ToString())>0)
            //{
            //    File_Name = Server.MapPath("~//Uploads/UserManual/دلـــيل المستخدم للمدير.pdf");
            //    File_Name_Show = "دلـــيل المستخدم للمدير.pdf";
            //}
            //else if (CDataConverter.ConvertToInt(Session_CS.child_emp.ToString()) > 0)
            //{
            //    File_Name = Server.MapPath("~//Uploads/UserManual/دليل المستخدم للسكرتير.pdf");
            //    File_Name_Show = "دليل المستخدم للسكرتير.pdf";
            //}
            //else
            //{

            //    File_Name = Server.MapPath("~//Uploads/UserManual/دليل المستخدم للموظفين.pdf");
            //    File_Name_Show = "دليل المستخدم للموظفين.pdf";
            //}
            
            //FileStream fs = new FileStream(File_Name, FileMode.Open, FileAccess.Read);
            //byte[] bytes = new byte[fs.Length];
            //fs.Read(bytes, 0, System.Convert.ToInt32(fs.Length));
            //fs.Close();
            //Response.ContentType = "application/x-unknown";
            //Response.AddHeader("Content-Disposition", "attachment; filename=" + Server.UrlPathEncode(File_Name_Show));
            //Response.BinaryWrite(bytes);
            //Response.Flush();
            //Response.Close();
        }
    }
    protected void btn_arabic_doc_Click(object sender, EventArgs e)
    {
        if (Drop_arabic_doc.SelectedValue == "0")
        {
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert(' يجب اختيار مذكرة عرض ')</script>");
        }
        else
        {
            string File_Name_Show = "";
            string File_Name = "";
            if (CDataConverter.ConvertToInt(Drop_arabic_doc.SelectedValue) == 1)
            {
                File_Name = Server.MapPath("~//Uploads/MemorandumShow/1.مذكرة عرض على الوزير لتقييم كراسة .doc");
                File_Name_Show = "1.مذكرة عرض على الوزير لتقييم كراسة .doc";


            }
            else if (CDataConverter.ConvertToInt(Drop_arabic_doc.SelectedValue) == 2)
            {
                File_Name = Server.MapPath("~//Uploads/MemorandumShow/2. مذكرة عرض على الوزير بالقيمة التقديرية لكراسة.doc");
                File_Name_Show = "2. مذكرة عرض على الوزير بالقيمة التقديرية لكراسة.doc";

            }
            else if (CDataConverter.ConvertToInt(Drop_arabic_doc.SelectedValue) == 3)
            {
                File_Name = Server.MapPath("~//Uploads/MemorandumShow/3. مذكرة عرض على الوزير بالتامين الابتدائي.doc");
                File_Name_Show = "3. مذكرة عرض على الوزير بالتامين الابتدائي.doc";

            }
            else if (CDataConverter.ConvertToInt(Drop_arabic_doc.SelectedValue) == 4)
            {
                File_Name = Server.MapPath("~//Uploads/MemorandumShow/4. مذكرة عرض على الوزير بالاعلان.doc");
                File_Name_Show = "4. مذكرة عرض على الوزير بالاعلان.doc";

            }
            else if (CDataConverter.ConvertToInt(Drop_arabic_doc.SelectedValue) == 5)
            {
                File_Name = Server.MapPath("~//Uploads/MemorandumShow/lagntBat.doc");
                File_Name_Show = "5.  مذكرة عرض على وكيل الوزارة بتشكيل لجنة البت.doc";

            }
            else if (CDataConverter.ConvertToInt(Drop_arabic_doc.SelectedValue) == 6)
            {
                File_Name = Server.MapPath("~//Uploads/MemorandumShow/استمارة صرف مخازن.doc");
                File_Name_Show = "استمارة صرف مخازن.doc";

            }
            else if (CDataConverter.ConvertToInt(Drop_arabic_doc.SelectedValue) == 7)
            {
                File_Name = Server.MapPath("~//Uploads/MemorandumShow/فاكس من مدير ادارة الى السيد المشرف على قطاع البنية الأساسية للاتصالات.doc");
                File_Name_Show = "فاكس من مدير ادارة الى السيد المشرف على قطاع البنية الأساسية للاتصالات.doc";

            }
            else if (CDataConverter.ConvertToInt(Drop_arabic_doc.SelectedValue) == 8)
            {
                File_Name = Server.MapPath("~//Uploads/MemorandumShow/فاكس من مدير ادارة الى رئيس الادارة المركزية للشئون الهندسية.doc");
                File_Name_Show = "فاكس من مدير ادارة الى رئيس الادارة المركزية للشئون الهندسية.doc";

            }
            else if (CDataConverter.ConvertToInt(Drop_arabic_doc.SelectedValue) == 9)
            {
                File_Name = Server.MapPath("~//Uploads/MemorandumShow/فاكس من مدير ادارة لمسئول بجهة خارجية.doc");
                File_Name_Show = "فاكس من مدير ادارة لمسئول بجهة خارجية.doc";

            }
            else if (CDataConverter.ConvertToInt(Drop_arabic_doc.SelectedValue) == 10)
            {
                File_Name = Server.MapPath("~//Uploads/MemorandumShow/فاكس من مكتب رئاسة القطاع لمساعد وزير.doc");
                File_Name_Show = "فاكس من مكتب رئاسة القطاع لمساعد وزير .doc";

            }
            else if (CDataConverter.ConvertToInt(Drop_arabic_doc.SelectedValue) == 11)
            {
                File_Name = Server.MapPath("~//Uploads/MemorandumShow/فاكس من مكتب رئيس القطاع الى السيد المشرف على قطاع البنية الأساسية للاتصالات.doc");
                File_Name_Show = "فاكس من مكتب رئيس القطاع الى السيد المشرف على قطاع البنية الأساسية للاتصالات.doc";

            }
            else if (CDataConverter.ConvertToInt(Drop_arabic_doc.SelectedValue) == 12)
            {
                File_Name = Server.MapPath("~//Uploads/MemorandumShow/فاكس من مكتب رئيس القطاع الى رئيس الادارة المركزية للشئون الهندسية.doc");
                File_Name_Show = "فاكس من مكتب رئيس القطاع الى رئيس الادارة المركزية للشئون الهندسية.doc";

            }
            else if (CDataConverter.ConvertToInt(Drop_arabic_doc.SelectedValue) == 13)
            {
                File_Name = Server.MapPath("~//Uploads/MemorandumShow/مذكرة الوزير لطرح كراسة.doc");
                File_Name_Show = "مذكرة الوزير لطرح كراسة.doc";

            }
            else if (CDataConverter.ConvertToInt(Drop_arabic_doc.SelectedValue) == 14)
            {
                File_Name = Server.MapPath("~//Uploads/MemorandumShow/مذكرة داخلية من مدير ادارة الى رئيس القطاع.doc");
                File_Name_Show = "مذكرة داخلية من مدير ادارة الى رئيس القطاع.doc";

            }
            else if (CDataConverter.ConvertToInt(Drop_arabic_doc.SelectedValue) == 15)
            {
                File_Name = Server.MapPath("~//Uploads/MemorandumShow/مذكرة عرض على الوزير -   من مكتب رئاسة القطاع لشرح موقف تنفيذي لمشروع.doc");
                File_Name_Show = "مذكرة عرض على الوزير -   من مكتب رئاسة القطاع لشرح موقف تنفيذي لمشروع.doc";

            }
            else if (CDataConverter.ConvertToInt(Drop_arabic_doc.SelectedValue) == 16)
            {
                File_Name = Server.MapPath("~//Uploads/MemorandumShow/مذكرة عرض على الوزير لتوقيع بروتوكولات.doc");
                File_Name_Show = "مذكرة عرض على الوزير لتوقيع بروتوكولات.doc";

            }

            else if (CDataConverter.ConvertToInt(Drop_arabic_doc.SelectedValue) == 17)
            {
                File_Name = Server.MapPath("~//Uploads/MemorandumShow/TechnicalReport_ForMonaksa.doc");
                File_Name_Show = "نموذج التقرير الفني للجنة البت لمشروع.doc";

            }
            else if (CDataConverter.ConvertToInt(Drop_arabic_doc.SelectedValue) == 18)
            {
                File_Name = Server.MapPath("~//Uploads/MemorandumShow/QuantitiesRequiredTobeProvidedForm.xls");
                File_Name_Show = "نموذج الكميات المطلوب توفيرها من الاجهزة والشبكات ويرفق بخطاب للمهندس رأفت هندي.xls";

            }
            else if (CDataConverter.ConvertToInt(Drop_arabic_doc.SelectedValue) == 19)
            {
                File_Name = Server.MapPath("~//Uploads/MemorandumShow/TORForm.doc");
                File_Name_Show = "TOR نموذج.doc";

            }
            else if (CDataConverter.ConvertToInt(Drop_arabic_doc.SelectedValue) == 20)
            {
                File_Name = Server.MapPath("~//Uploads/MemorandumShow/badalatsafar.doc");
                File_Name_Show = "نموذج مذكرة بدلات سفر.doc";

            }

            else if (CDataConverter.ConvertToInt(Drop_arabic_doc.SelectedValue) == 21)
            {
                File_Name = Server.MapPath("~//Uploads/MemorandumShow/ProjectEndAndCloseForm.doc");
                File_Name_Show = "محضر بإنهاء وغلق مشروع.doc";

            }

            else if (CDataConverter.ConvertToInt(Drop_arabic_doc.SelectedValue) == 22)
            {
                File_Name = Server.MapPath("~//Uploads/MemorandumShow/FinancialTechnical_Report.doc");
                File_Name_Show = "تقرير مالي فني- لمناقصة.doc";

            }

            else if (CDataConverter.ConvertToInt(Drop_arabic_doc.SelectedValue) == 23)
            {
                File_Name = Server.MapPath("~//Uploads/MemorandumShow/LagnatElbat.doc");
                File_Name_Show = "مذكرة عرض على المهندس ايمن صادق بشان لجنة البت والترسية.doc";

            }

            else if (CDataConverter.ConvertToInt(Drop_arabic_doc.SelectedValue) == 24)
            {
                File_Name = Server.MapPath("~//Uploads/MemorandumShow/korrasa steps.pdf");
                File_Name_Show = "طوات اعمال طرح كراسة الشروط والمواصفات.pdf";

            }
            else if (CDataConverter.ConvertToInt(Drop_arabic_doc.SelectedValue) == 25)
            {
                File_Name = Server.MapPath("~//Uploads/MemorandumShow/memo_to_Prime.doc");
                File_Name_Show = "مذكرة عرض علي مساعد أول الوزير.doc";

            }

            else if (CDataConverter.ConvertToInt(Drop_arabic_doc.SelectedValue) == 26)
            {
                File_Name = Server.MapPath("~//Uploads/MemorandumShow/memo_to_finance.doc");
                File_Name_Show = "مذكرة لمدير الشئون المالية بالوزارة.doc";

            }


            //else if (CDataConverter.ConvertToInt(Drop_arabic_doc.SelectedValue) == 17)
            //{
            //    File_Name = Server.MapPath("~//Uploads/MemorandumShow/مذكرة عرض على د. هشام الديب - المشرف على القطاع.doc");
            //    File_Name_Show = "مذكرة عرض على د. هشام الديب - المشرف على القطاع.doc";

            //}

            else if (CDataConverter.ConvertToInt(Drop_arabic_doc.SelectedValue) == 27)
            {
                File_Name = Server.MapPath("~//Uploads/MemorandumShow/Travel_Memo.doc");
                File_Name_Show = "مذكرة عرض علي رئيس القطاع للسفر إلي المحافظات.doc";

            }

            else if (CDataConverter.ConvertToInt(Drop_arabic_doc.SelectedValue) == 28)
            {
                File_Name = Server.MapPath("~//Uploads/MemorandumShow/RegistrationForm.doc");
                File_Name_Show = "نموذج التقديم لدورة تدريبية .doc";

            }

            FileStream fs = new FileStream(File_Name, FileMode.Open, FileAccess.Read);
            byte[] bytes = new byte[fs.Length];
            fs.Read(bytes, 0, System.Convert.ToInt32(fs.Length));
            fs.Close();
            Response.ContentType = "application/x-unknown";
            Response.AddHeader("Content-Disposition", "attachment; filename=" + Server.UrlPathEncode(File_Name_Show));
            Response.BinaryWrite(bytes);
            Response.Flush();
            Response.Close();

        }
    }

    
}
