using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using EFModels;


public class Department
{
    public string name;//Department Name
    public long id;//Department ID

}

public class Employee
{
    public string name;//Employee Name
    public long id;//Employee ID

}

//public partial class Inbox
//{
//    public string name;//Inbox Name
//    public int id;//Inbox ID

//}
public class Organization
{
    public string name;//The Organization name
    public long id;//the Organization ID
}

/// <summary>
/// Summary description for SmartSearchService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class SmartSearchService : System.Web.Services.WebService
{
    //public List<Organization> OrgList;
    public SmartSearchService()
    {
       // OrgList = new List<Organization>();
        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }
    [WebMethod]https://www.facebook.com/l.php?u=https%3A%2F%2Fwww.facebook.com%2Fprofile.php%3Fid%3D100009627397643%26ref%3D%252Fpymk-chain%26fref%3Dpymk&h=oAQGpTHeV&enc=AZMDte8hKwe0OWZzUTVrLKiDqdQU7Q0LSyFOqHAkQnezvyXfprQqc_4UgnHR_UPQ-GUVTWBIPQ146UC9sTZe78mFw7doALdNnim6IHC8El2uTIt8vY98DEAKO1ObSLCMMGnclkQifm85Aj3JPgWWM6xcJSVwpNzH2REjAq6REF81HpJM-pV46D57KkGA4Lx5ExL4GczNIxZ4I_oFf2L4uLjn_4zNWe4AJ2ic0W_iivzcKYp6d8DfM9rdh6QULpEeSGm72OxRAL2GG3zgNpZfw-wN2I3c-G3GnKJW0Vl5s5tV_OfznF122VbLXjU4JUILWYVrrasv7ZSrgHR3e3AL6YNFc5F8AE1aCd16g7r4mTAcS2tirq9FVhcWLmyAc6VY7d37Bxe16hAwXuSoFtMlEctnlQept66F6Nd8-EeFdEmWgbRjGkEXA42DYNCGarKSr_zXAIesb8AilGT-1DKfiU5odl_yJZZGoINh_Hod3m7ha2BTgMI1CTrOPwfYbqaDP_n9pD_p6JzqpzOPHZRtt-o2gfFzYuzjnOysaNBavK4NaKQIISbSwCcjsG1BtDBbLEPaNrbqyYQehra2sZYh_ymH
    public List<Department> GetAllDepartments()//Gets all the departments
    {
        List<Department> deptList = null;
        try
        {
            DataTable dt = General_Helping.GetDataTable("select Dept_id as ID, Dept_name as Name from Departments ");

            deptList = dt.AsEnumerable().Select(m => new Department()
            {
                id = m.Field<long>("ID"),
                name = m.Field<string>("Name"),

            }
            ).ToList();
        }
        catch (Exception e)
        {

        }
        return deptList;

    }

    [WebMethod]
    public List<Employee> GetEmployeeByDept(string id)//Returns all the Employees employed in the supplied Department ID
    {
        DataTable dt = General_Helping.GetDataTable("select pmp_id as ID ,pmp_name as Name from Employee where dept_dept_id=" + id);

        List<Employee> empList = dt.AsEnumerable().Select(m => new Employee()
             {
                 id = m.Field<long>("ID"),
                 name = m.Field<string>("Name"),

             }).ToList();

        return empList;
    }
    [WebMethod]
    public List<Inbox> GetAllInboxByEmpId(string id)//Returns all the inbox related to that employee ID
    {
        DataTable dt = General_Helping.GetDataTable("SELECT ID,Name FROM [dbo].[Inbox] WHERE Emp_ID =" + id);

        List<Inbox> inboxList = dt.AsEnumerable().Select(m => new Inbox()
        {
            ID = m.Field<int>("ID"),
            Name = m.Field<string>("Name"),

        }).ToList();

       
        return inboxList;

    }


    [WebMethod]
    public List<Organization> GetAllOrgByFoundId()//web service to get organization based on the foundation id saved in session
    {
        int found_id = CDataConverter.ConvertToInt(Session_CS.foundation_id.ToString());
    
        DataTable DT = SqlHelper.ExecuteDataset(Database.ConnectionString, "get_org_by_found", found_id).Tables[0];
        List<Organization> OrgList = DT.AsEnumerable().Select(m => new Organization()
        {
            id = m.Field<long>("Org_ID"),
            name = m.Field<string>("Org_Desc"),

        }).ToList();
        //Session["AngularComboID"] = OrgList;
        return OrgList;

    }
    
}

