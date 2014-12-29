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
using System.Data.OleDb;
using System.Data.SqlClient;
using DBL;
using System.IO;
using System.Text;
using System.Web;

/// <summary>
/// Summary description for Sessions
/// </summary>
public class Session_CS
{

    //private  HttpCookie cook_parent_id = new HttpCookie("parent_id");


    //private HttpCookie cook_code_archiving = new HttpCookie("code_archiving");
    //private HttpCookie cook_Port = new HttpCookie("Port");


    //private HttpCookie cook_host = new HttpCookie("host");
    //private HttpCookie cook_FromAddress = new HttpCookie("FromAddress");
    //private HttpCookie cook_UserName_mail = new HttpCookie("UserName_mail");
    //private HttpCookie cook_Password = new HttpCookie("Password");
    //private HttpCookie cook_child_emp = new HttpCookie("child_emp");
    //private HttpCookie cook_Project_id = new HttpCookie("Project_id");

    //private HttpCookie cook_System_ID = new HttpCookie("System_ID");
    //private HttpCookie cook_group_id = new HttpCookie("group_id");
    //private HttpCookie cook_UserName = new HttpCookie("UserName");
    //private HttpCookie cook_Usr_Name = new HttpCookie("Usr_Name");
    //private HttpCookie cook_pmp_id = new HttpCookie("pmp_id");
    //private HttpCookie cook_dept = new HttpCookie("dept");
    //private HttpCookie cook_dept_id = new HttpCookie("dept_id");
    //private HttpCookie cook_UROL_UROL_ID = new HttpCookie("UROL_UROL_ID");
    //private HttpCookie cook_vacation_mng = new HttpCookie("vacation_mng");

    //private HttpCookie cook_sec_id = new HttpCookie("sec_id");
    //private HttpCookie cook_pmp_name = new HttpCookie("pmp_name");
    //private HttpCookie cook_parentbychild = new HttpCookie("parentbychild");
    //private HttpCookie cook_e_signature = new HttpCookie("e_signature");
    //private HttpCookie cook_Site_Name = new HttpCookie("Site_Name");
    //private HttpCookie cook_Hr_Eval = new HttpCookie("Hr_Eval");

    //private HttpCookie cook_Dept_parent_id = new HttpCookie("Dept_parent_id");
    //private HttpCookie cook_local_filesave = new HttpCookie("local_filesave");
    //private HttpCookie cook_local_connectionstring = new HttpCookie("local_connectionstring");










    public Int32 parent_id
    {
        get
        {
            if (!string.IsNullOrEmpty(HttpContext.Current.Request.Cookies["cook_parent_id"].Value))
            {

                //return CDataConverter.ConvertToInt(HttpContext.Current.Session["parent_id"]);
                //HttpCookie cook = new HttpCookie("parent_id");
                // return CDataConverter.ConvertToInt(cook_parent_id["parent_id"]);
                return CDataConverter.ConvertToInt(HttpContext.Current.Request.Cookies["cook_parent_id"].Value);

            }
            else
            {
                HttpContext.Current.Response.Redirect("~/default.aspx");
                return 0;
            }
        }

        set
        {
            //HttpContext.Current.Session["parent_id"] = value;

            HttpCookie cook_parent_id = new HttpCookie("cook_parent_id");
            //cook_parent_id["parent_id"] = value.ToString();
            cook_parent_id.Value = value.ToString();

            cook_parent_id.Expires = DateTime.Now.AddDays(1);
            HttpContext.Current.Response.Cookies.Add(cook_parent_id);


        }

    }








    public Int32 foundation_id
    {
        get
        {
            if (!string.IsNullOrEmpty(HttpContext.Current.Request.Cookies["cook_foundation_id"].Value))
            {

                //return CDataConverter.ConvertToInt(HttpContext.Current.Session["foundation_id"]);
                return CDataConverter.ConvertToInt(HttpContext.Current.Request.Cookies["cook_foundation_id"].Value);

            }
            else
            {
                HttpContext.Current.Response.Redirect("~/default.aspx");
                return 0;
            }
        }

        set
        {
            HttpCookie cook_foundation_id = new HttpCookie("cook_foundation_id");

            cook_foundation_id.Value = value.ToString();

            cook_foundation_id.Expires = DateTime.Now.AddDays(1);
            HttpContext.Current.Response.Cookies.Add(cook_foundation_id);
        }

    }
    public Int32 code_archiving
    {

        get
        {
            if (!string.IsNullOrEmpty(HttpContext.Current.Request.Cookies["cook_code_archiving"].Value))
            {

                //return CDataConverter.ConvertToInt(HttpContext.Current.Session["foundation_id"]);
                return CDataConverter.ConvertToInt(HttpContext.Current.Request.Cookies["cook_code_archiving"].Value);

            }
            else
            {
                HttpContext.Current.Response.Redirect("~/default.aspx");
                return 0;
            }
        }

        set
        {
            HttpCookie cook_code_archiving = new HttpCookie("cook_code_archiving");
            cook_code_archiving.Value = value.ToString();

            cook_code_archiving.Expires = DateTime.Now.AddDays(1);
            HttpContext.Current.Response.Cookies.Add(cook_code_archiving);
        }

    }
    public Int32 Port
    {
        get
        {
            if (!string.IsNullOrEmpty(HttpContext.Current.Request.Cookies["cook_Port"].Value))
       
            {

                //return CDataConverter.ConvertToInt(HttpContext.Current.Session["foundation_id"]);
                return CDataConverter.ConvertToInt(HttpContext.Current.Request.Cookies["cook_Port"].Value);

            }
            else
            {
                HttpContext.Current.Response.Redirect("~/default.aspx");
                return 0;
            }
        }

        set
        {
            HttpCookie cook_Port = new HttpCookie("cook_Port");
            cook_Port.Value = value.ToString();

            cook_Port.Expires = DateTime.Now.AddDays(1);
            HttpContext.Current.Response.Cookies.Add(cook_Port);
        }

    }
    public string Host
    {

        get
        {
            if (!string.IsNullOrEmpty(HttpContext.Current.Request.Cookies["cook_host"].Value))
            {

                //return CDataConverter.ConvertToInt(HttpContext.Current.Session["foundation_id"]);
                //return cook_host.Value.ToString();
                return HttpContext.Current.Request.Cookies["cook_host"].Value;


            }
            else
            {
                HttpContext.Current.Response.Redirect("~/default.aspx");
                return "";
            }
        }

        set
        {
            HttpCookie cook_host = new HttpCookie("cook_host");
            cook_host.Value = value;

            cook_host.Expires = DateTime.Now.AddDays(1);
            HttpContext.Current.Response.Cookies.Add(cook_host);
        }

    }
    public string FromAddress
    {


        get
        {
            if (!string.IsNullOrEmpty(HttpContext.Current.Request.Cookies["cook_FromAddress"].Value))
            {

                //return CDataConverter.ConvertToInt(HttpContext.Current.Session["foundation_id"]);
                //return cook_FromAddress.Value.ToString();
                return HttpContext.Current.Request.Cookies["cook_FromAddress"].Value;

            }
            else
            {
                HttpContext.Current.Response.Redirect("~/default.aspx");
                return "";
            }
        }

        set
        {
            HttpCookie cook_FromAddress = new HttpCookie("cook_FromAddress");
            cook_FromAddress.Value = value;

            cook_FromAddress.Expires = DateTime.Now.AddDays(1);
            HttpContext.Current.Response.Cookies.Add(cook_FromAddress);
        }
    }
    public string UserName_mail
    {

        get
        {
            if (!string.IsNullOrEmpty(HttpContext.Current.Request.Cookies["cook_UserName_mail"].Value))
            {

                //return CDataConverter.ConvertToInt(HttpContext.Current.Session["foundation_id"]);
                //return cook_UserName_mail.Value.ToString();
                return HttpContext.Current.Request.Cookies["cook_UserName_mail"].Value;

            }
            else
            {
                HttpContext.Current.Response.Redirect("~/default.aspx");
                return "";
            }
        }

        set
        {
            HttpCookie cook_UserName_mail = new HttpCookie("cook_UserName_mail");
            cook_UserName_mail.Value = value;

            cook_UserName_mail.Expires = DateTime.Now.AddDays(1);
            HttpContext.Current.Response.Cookies.Add(cook_UserName_mail);
        }


    }
    public string Password
    {
        get
        {
            if (!string.IsNullOrEmpty(HttpContext.Current.Request.Cookies["cook_Password"].Value))
            {

                //return CDataConverter.ConvertToInt(HttpContext.Current.Session["foundation_id"]);
                //return cook_Password.Value.ToString();
                return HttpContext.Current.Request.Cookies["cook_Password"].Value;

            }
            else
            {
                HttpContext.Current.Response.Redirect("~/default.aspx");
                return "";
            }
        }

        set
        {
            HttpCookie cook_Password = new HttpCookie("cook_Password");
            cook_Password.Value = value;

            cook_Password.Expires = DateTime.Now.AddDays(1);
            HttpContext.Current.Response.Cookies.Add(cook_Password);
        }


    }

    public Int32 child_emp
    {

        get
        {
            if (!string.IsNullOrEmpty(HttpContext.Current.Request.Cookies["cook_child_emp"].Value))
            {

                //return CDataConverter.ConvertToInt(HttpContext.Current.Session["foundation_id"]);
                //return CDataConverter.ConvertToInt(cook_child_emp.Value);
                return CDataConverter.ConvertToInt(HttpContext.Current.Request.Cookies["cook_child_emp"].Value);

            }
            else
            {
                HttpContext.Current.Response.Redirect("~/default.aspx");
                return 0;
            }
        }

        set
        {
            HttpCookie cook_child_emp = new HttpCookie("cook_child_emp");
            cook_child_emp.Value = value.ToString();

            cook_child_emp.Expires = DateTime.Now.AddDays(1);
            HttpContext.Current.Response.Cookies.Add(cook_child_emp);
        }


    }
    public Int32 Project_id
    {

        get
        {
            if (!string.IsNullOrEmpty(HttpContext.Current.Request.Cookies["cook_Project_id"].Value))
            {

                //return CDataConverter.ConvertToInt(HttpContext.Current.Session["foundation_id"]);
               // return CDataConverter.ConvertToInt(cook_Project_id.Value);
                return CDataConverter.ConvertToInt(HttpContext.Current.Request.Cookies["cook_Project_id"].Value);


            }
            else
            {
                HttpContext.Current.Response.Redirect("~/default.aspx");
                return 0;
            }
        }

        set
        {
            HttpCookie cook_Project_id = new HttpCookie("cook_Project_id");
            cook_Project_id.Value = value.ToString();

            cook_Project_id.Expires = DateTime.Now.AddDays(1);
            HttpContext.Current.Response.Cookies.Add(cook_Project_id);
        }


    }
    public Int32 System_ID
    {

        get
        {
            if (!string.IsNullOrEmpty(HttpContext.Current.Request.Cookies["cook_System_ID"].Value))
            {

                //return CDataConverter.ConvertToInt(HttpContext.Current.Session["foundation_id"]);
                //return CDataConverter.ConvertToInt(cook_System_ID.Value);
                return CDataConverter.ConvertToInt(HttpContext.Current.Request.Cookies["cook_System_ID"].Value);

            }
            else
            {
                HttpContext.Current.Response.Redirect("~/default.aspx");
                return 0;
            }
        }

        set
        {
            HttpCookie cook_System_ID = new HttpCookie("cook_System_ID");
            cook_System_ID.Value = value.ToString();

            cook_System_ID.Expires = DateTime.Now.AddDays(1);
            HttpContext.Current.Response.Cookies.Add(cook_System_ID);
        }



    }
    public Int32 group_id
    {
        get
        {
            if (!string.IsNullOrEmpty(HttpContext.Current.Request.Cookies["cook_group_id"].Value))
            {

                //return CDataConverter.ConvertToInt(HttpContext.Current.Session["foundation_id"]);
                //return CDataConverter.ConvertToInt(cook_group_id.Value);
                return CDataConverter.ConvertToInt(HttpContext.Current.Request.Cookies["cook_group_id"].Value);

            }
            else
            {
                HttpContext.Current.Response.Redirect("~/default.aspx");
                return 0;
            }
        }

        set
        {
            HttpCookie cook_group_id = new HttpCookie("cook_group_id");
            cook_group_id.Value = value.ToString();

            cook_group_id.Expires = DateTime.Now.AddDays(1);
            HttpContext.Current.Response.Cookies.Add(cook_group_id);
        }


    }
    public string UserName
    {


        get
        {
            if (!string.IsNullOrEmpty(HttpContext.Current.Request.Cookies["cook_UserName"].Value))
            {

                //return CDataConverter.ConvertToInt(HttpContext.Current.Session["foundation_id"]);
                //return cook_UserName.Value.ToString();
                return HttpContext.Current.Request.Cookies["cook_UserName"].Value;

            }
            else
            {
                HttpContext.Current.Response.Redirect("~/default.aspx");
                return "";
            }
        }

        set
        {
            HttpCookie cook_UserName = new HttpCookie("cook_UserName");
            cook_UserName.Value = value;

            cook_UserName.Expires = DateTime.Now.AddDays(1);
            HttpContext.Current.Response.Cookies.Add(cook_UserName);
        }
    }
    public string Usr_Name
    {

        get
        {
            if (!string.IsNullOrEmpty(HttpContext.Current.Request.Cookies["cook_Usr_Name"].Value))
            {

                //return CDataConverter.ConvertToInt(HttpContext.Current.Session["foundation_id"]);
                //return cook_Usr_Name.Value.ToString();
                return HttpContext.Current.Request.Cookies["cook_Usr_Name"].Value;

            }
            else
            {
                HttpContext.Current.Response.Redirect("~/default.aspx");
                return "";
            }
        }

        set
        {
            HttpCookie cook_Usr_Name = new HttpCookie("cook_Usr_Name");
            cook_Usr_Name.Value = value;

            cook_Usr_Name.Expires = DateTime.Now.AddDays(1);
            HttpContext.Current.Response.Cookies.Add(cook_Usr_Name);
        }


    }
    public Int32 pmp_id
    {

        get
        {
            //if (cook_pmp_id != null)
            //{

            //    //return CDataConverter.ConvertToInt(HttpContext.Current.Session["foundation_id"]);
            //    return CDataConverter.ConvertToInt(cook_pmp_id.Value);

            if (!string.IsNullOrEmpty(HttpContext.Current.Request.Cookies["cook_pmp_id"].Value))
            {

                //return CDataConverter.ConvertToInt(HttpContext.Current.Session["foundation_id"]);
                return CDataConverter.ConvertToInt(HttpContext.Current.Request.Cookies["cook_pmp_id"].Value.ToString());


            }
            else
            {
                HttpContext.Current.Response.Redirect("~/default.aspx");
                return 0;
            }
        }

        set
        {
            HttpCookie cook_pmp_id = new HttpCookie("cook_pmp_id");
            cook_pmp_id.Value = value.ToString();

            cook_pmp_id.Expires = DateTime.Now.AddDays(1);
            HttpContext.Current.Response.Cookies.Add(cook_pmp_id);
        }

    }
    public string dept
    {

        get
        {
            if (!string.IsNullOrEmpty(HttpContext.Current.Request.Cookies["cook_dept"].Value))
            {

                //return CDataConverter.ConvertToInt(HttpContext.Current.Session["foundation_id"]);
                return HttpContext.Current.Request.Cookies["cook_dept"].Value.ToString();

            }
            else
            {
                HttpContext.Current.Response.Redirect("~/default.aspx");
                return "";
            }
        }

        set
        {
            HttpCookie cook_dept = new HttpCookie("cook_dept");
            cook_dept.Value = value;

            cook_dept.Expires = DateTime.Now.AddDays(1);
            HttpContext.Current.Response.Cookies.Add(cook_dept);
        }


    }
    public Int32 dept_id
    {

        get
        {
            if (!string.IsNullOrEmpty(HttpContext.Current.Request.Cookies["cook_dept_id"].Value))
            {

                //return CDataConverter.ConvertToInt(HttpContext.Current.Session["foundation_id"]);
                return CDataConverter.ConvertToInt(HttpContext.Current.Request.Cookies["cook_dept_id"].Value);

            }
            else
            {
                HttpContext.Current.Response.Redirect("~/default.aspx");
                return 0;
            }
        }

        set
        {
            HttpCookie cook_dept_id = new HttpCookie("cook_dept_id");
            cook_dept_id.Value = value.ToString();

            cook_dept_id.Expires = DateTime.Now.AddDays(1);
            HttpContext.Current.Response.Cookies.Add(cook_dept_id);
        }

    }
    public Int32 UROL_UROL_ID
    {
        get
        {
            if (!string.IsNullOrEmpty(HttpContext.Current.Request.Cookies["cook_UROL_UROL_ID"].Value))
            {

                //return CDataConverter.ConvertToInt(HttpContext.Current.Session["foundation_id"]);
                return CDataConverter.ConvertToInt(HttpContext.Current.Request.Cookies["cook_UROL_UROL_ID"].Value);

            }
            else
            {
                HttpContext.Current.Response.Redirect("~/default.aspx");
                return 0;
            }
        }

        set
        {
            HttpCookie cook_UROL_UROL_ID = new HttpCookie("cook_UROL_UROL_ID");
            cook_UROL_UROL_ID.Value = value.ToString();

            cook_UROL_UROL_ID.Expires = DateTime.Now.AddDays(1);
            HttpContext.Current.Response.Cookies.Add(cook_UROL_UROL_ID);
        }
    }
    public Int32 vacation_mng
    {

        get
        {
            if (!string.IsNullOrEmpty(HttpContext.Current.Request.Cookies["cook_vacation_mng"].Value))
            {

                //return CDataConverter.ConvertToInt(HttpContext.Current.Session["foundation_id"]);
                return CDataConverter.ConvertToInt(HttpContext.Current.Request.Cookies["cook_vacation_mng"].Value);

            }
            else
            {
                HttpContext.Current.Response.Redirect("~/default.aspx");
                return 0;
            }
        }

        set
        {
            HttpCookie cook_vacation_mng = new HttpCookie("cook_vacation_mng");
            cook_vacation_mng.Value = value.ToString();

            cook_vacation_mng.Expires = DateTime.Now.AddDays(1);
            HttpContext.Current.Response.Cookies.Add(cook_vacation_mng);
        }

    }
    public Int32 sec_id
    {


        get
        {
            if (!string.IsNullOrEmpty(HttpContext.Current.Request.Cookies["cook_sec_id"].Value))
            {

                //return CDataConverter.ConvertToInt(HttpContext.Current.Session["foundation_id"]);
                return CDataConverter.ConvertToInt(HttpContext.Current.Request.Cookies["cook_sec_id"].Value);

            }
            else
            {
                HttpContext.Current.Response.Redirect("~/default.aspx");
                return 0;
            }
        }

        set
        {
            HttpCookie cook_sec_id = new HttpCookie("cook_sec_id");
            cook_sec_id.Value = value.ToString();

            cook_sec_id.Expires = DateTime.Now.AddDays(1);
            HttpContext.Current.Response.Cookies.Add(cook_sec_id);
        }



    }
    public string pmp_name
    {


        get
        {
            if (!string.IsNullOrEmpty(HttpContext.Current.Request.Cookies["cook_pmp_name"].Value))
            {

                //return CDataConverter.ConvertToInt(HttpContext.Current.Session["foundation_id"]);
                return HttpContext.Current.Request.Cookies["cook_pmp_name"].Value.ToString();

            }
            else
            {
                HttpContext.Current.Response.Redirect("~/default.aspx");
                return "";
            }
        }

        set
        {
            HttpCookie cook_pmp_name = new HttpCookie("cook_pmp_name");
            cook_pmp_name.Value = value;

            cook_pmp_name.Expires = DateTime.Now.AddDays(1);
            HttpContext.Current.Response.Cookies.Add(cook_pmp_name);
        }
    }

    public string parentbychild
    {

        get
        {
            if (!string.IsNullOrEmpty(HttpContext.Current.Request.Cookies["cook_parentbychild"].Value))
            {

                //return CDataConverter.ConvertToInt(HttpContext.Current.Session["foundation_id"]);
                return HttpContext.Current.Request.Cookies["cook_parentbychild"].Value.ToString();

            }
            else
            {
                HttpContext.Current.Response.Redirect("~/default.aspx");
                return "";
            }
        }

        set
        {
            HttpCookie cook_parentbychild = new HttpCookie("cook_parentbychild");
            cook_parentbychild.Value = value;

            cook_parentbychild.Expires = DateTime.Now.AddDays(1);
            HttpContext.Current.Response.Cookies.Add(cook_parentbychild);
        }

    }

    public string e_signature
    {

        get
        {
            if (!string.IsNullOrEmpty(HttpContext.Current.Request.Cookies["cook_e_signature"].Value))
            {

                //return CDataConverter.ConvertToInt(HttpContext.Current.Session["foundation_id"]);
                return HttpContext.Current.Request.Cookies["cook_e_signature"].Value.ToString();

            }
            else
            {
                HttpContext.Current.Response.Redirect("~/default.aspx");
                return "";
            }
        }

        set
        {
            HttpCookie cook_e_signature = new HttpCookie("cook_e_signature");
            cook_e_signature.Value = value;

            cook_e_signature.Expires = DateTime.Now.AddDays(1);
            HttpContext.Current.Response.Cookies.Add(cook_e_signature);
        }

    }

    public string Site_Name
    {

        get
        {
            if (!string.IsNullOrEmpty(HttpContext.Current.Request.Cookies["cook_Site_Name"].Value))
            {

                //return CDataConverter.ConvertToInt(HttpContext.Current.Session["foundation_id"]);
                return HttpContext.Current.Request.Cookies["cook_Site_Name"].Value.ToString();

            }
            else
            {
                HttpContext.Current.Response.Redirect("~/default.aspx");
                return "";
            }
        }

        set
        {
            HttpCookie cook_Site_Name = new HttpCookie("cook_Site_Name");
            cook_Site_Name.Value = value;

            cook_Site_Name.Expires = DateTime.Now.AddDays(1);
            HttpContext.Current.Response.Cookies.Add(cook_Site_Name);
        }

    }

    //public  Int32 is_vacation_mng
    //{


    //    get
    //    {
    //        if (HttpContext.Current.Session["is_vacation_mng"] != null)
    //        {

    //            return CDataConverter.ConvertToInt(HttpContext.Current.Session["is_vacation_mng"]);

    //        }
    //        else
    //        {

    //            HttpContext.Current.Response.Redirect("~/default.aspx");
    //            return 0;
    //        }
    //    }

    //    set
    //    {
    //        HttpContext.Current.Session["is_vacation_mng"] = value;
    //    }


    //}

    //public  Int32 Eval_mng
    //{


    //    get
    //    {
    //        if (HttpContext.Current.Session["Eval_mng"] != null)
    //        {

    //            return CDataConverter.ConvertToInt(HttpContext.Current.Session["Eval_mng"]);

    //        }
    //        else
    //        {

    //            HttpContext.Current.Response.Redirect("~/default.aspx");
    //            return 0;
    //        }
    //    }

    //    set
    //    {
    //        HttpContext.Current.Session["Eval_mng"] = value;
    //    }


    //}

    public Int32 Hr_Eval
    {



        get
        {
            if (!string.IsNullOrEmpty(HttpContext.Current.Request.Cookies["cook_Hr_Eval"].Value))
            {

                //return CDataConverter.ConvertToInt(HttpContext.Current.Session["foundation_id"]);
                return CDataConverter.ConvertToInt(HttpContext.Current.Request.Cookies["cook_Hr_Eval"].Value);

            }
            else
            {
                HttpContext.Current.Response.Redirect("~/default.aspx");
                return 0;
            }
        }

        set
        {
            HttpCookie cook_Hr_Eval = new HttpCookie("cook_Hr_Eval");
            cook_Hr_Eval.Value = value.ToString();
            cook_Hr_Eval.Expires = DateTime.Now.AddDays(1);
            HttpContext.Current.Response.Cookies.Add(cook_Hr_Eval);

        }


    }






    public Int32 Dept_parent_id
    {

        get
        {
            if (!string.IsNullOrEmpty(HttpContext.Current.Request.Cookies["cook_Dept_parent_id"].Value))
            {

                //return CDataConverter.ConvertToInt(HttpContext.Current.Session["foundation_id"]);
                return CDataConverter.ConvertToInt(HttpContext.Current.Request.Cookies["cook_Dept_parent_id"].Value);

            }
            else
            {
                HttpContext.Current.Response.Redirect("~/default.aspx");
                return 0;
            }
        }

        set
        {
            HttpCookie cook_Dept_parent_id = new HttpCookie("cook_Dept_parent_id");
            cook_Dept_parent_id.Value = value.ToString();

            cook_Dept_parent_id.Expires = DateTime.Now.AddDays(1);
            HttpContext.Current.Response.Cookies.Add(cook_Dept_parent_id);
        }


    }

    public Boolean local_filesave
    {

        get
        {
            if (!string.IsNullOrEmpty(HttpContext.Current.Request.Cookies["cook_local_filesave"].Value))
            {

                //return CDataConverter.ConvertToInt(HttpContext.Current.Session["foundation_id"]);
                return Convert.ToBoolean(HttpContext.Current.Request.Cookies["cook_local_filesave"].Value);

            }
            else
            {
                //HttpContext.Current.Response.Redirect("~/default.aspx");
                return false;
            }
        }

        set
        {
            HttpCookie cook_local_filesave = new HttpCookie("cook_local_filesave");
            cook_local_filesave.Value = value.ToString();
            cook_local_filesave.Expires = DateTime.Now.AddDays(1);
            HttpContext.Current.Response.Cookies.Add(cook_local_filesave);

        }



    }


    public string local_connectionstring
    {

        get
        {
            if (!string.IsNullOrEmpty(HttpContext.Current.Request.Cookies["cook_local_connectionstring"].Value))
            {
                return HttpContext.Current.Request.Cookies["cook_local_connectionstring"].Value;

                //return CDataConverter.ConvertToInt(HttpContext.Current.Session["foundation_id"]);


            }
            else
            {
                // HttpContext.Current.Response.Redirect("~/default.aspx");
                return "";
            }
        }

        set
        {
            HttpCookie cook_local_connectionstring = new HttpCookie("cook_local_connectionstring");
            cook_local_connectionstring.Value = value;

            cook_local_connectionstring.Expires = DateTime.Now.AddDays(1);
            HttpContext.Current.Response.Cookies.Add(cook_local_connectionstring);
        }

    }





}