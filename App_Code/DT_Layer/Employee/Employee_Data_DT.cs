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
/// Summary description for Employee_Data_DT
/// </summary>
public class Employee_Data_DT
{
    public enum EnumInfo_Employee_Data
    {
        PMP_ID, Dept_Dept_id, pmp_name, mail, sec_sec_id, Hire_date, pmp_title, job_no, direct_manager, higher_manager, vacation_mng_pmp_id, workstatus, category, university_degree, major, university_name, rol_rol_id, contact_person, foundation_id
    }

    public Int32 vacation_mng_pmp_id;

    
    public int Dept_Dept_id;
    
    public String pmp_name;
   
    
    public string mail;

    public int sec_sec_id;
    public int rol_rol_id;
  

    public String Hire_date;
   

    public String pmp_title;
   
    public String job_no;
   
    public int direct_manager;
    
    public int higher_manager;
    

    public int PMP_ID;
    
   
      public int workstatus;
      public int category;
      public int university_degree;
      public String  major;
      public String university_name;
      public bool  contact_person;

      public int foundation_id;
    
}
