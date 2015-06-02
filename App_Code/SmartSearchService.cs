using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;



public class DepartmentSmartSearch
{
    public string name;//Department Name
    public long id;//Department ID

}

public class EmployeeSmartSearch
{
    public string name;//Employee Name
    public long id;//Employee ID

}

public class InboxSmartSearch
{
    public string name;//Inbox Name
    public int id;//Inbox ID

}
public class OrganizationSmartSearch
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
    [WebMethod]
    public List<DepartmentSmartSearch> GetAllDepartments()//Gets all the departments
    {
        List<DepartmentSmartSearch> deptList = null;
        try
        {
            DataTable dt = General_Helping.GetDataTable("select Dept_id as ID, Dept_name as Name from Departments ");

            deptList = dt.AsEnumerable().Select(m => new DepartmentSmartSearch()
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
    public List<EmployeeSmartSearch> GetEmployeeByDept(string id)//Returns all the Employees employed in the supplied Department ID
    {
        DataTable dt = General_Helping.GetDataTable("select pmp_id as ID ,pmp_name as Name from Employee where dept_dept_id=" + id);

        List<EmployeeSmartSearch> empList = dt.AsEnumerable().Select(m => new EmployeeSmartSearch()
             {
                 id = m.Field<long>("ID"),
                 name = m.Field<string>("Name"),

             }).ToList();

        return empList;
    }
    [WebMethod]
    public List<InboxSmartSearch> GetAllInboxByEmpId(string id)//Returns all the inbox related to that employee ID
    {
        DataTable dt = General_Helping.GetDataTable("SELECT ID,Name FROM [dbo].[Inbox] WHERE Emp_ID =" + id);

        List<InboxSmartSearch> inboxList = dt.AsEnumerable().Select(m => new InboxSmartSearch()
        {
            id = m.Field<int>("ID"),
            name = m.Field<string>("Name"),

        }).ToList();

       
        return inboxList;

    }


    [WebMethod]
    public List<OrganizationSmartSearch> GetAllOrgByFoundId()//web service to get organization based on the foundation id saved in session
    {
        int found_id = CDataConverter.ConvertToInt(Session_CS.foundation_id.ToString());
    
        DataTable DT = SqlHelper.ExecuteDataset(Database.ConnectionString, "get_org_by_found", found_id).Tables[0];
        List<OrganizationSmartSearch> OrgList = DT.AsEnumerable().Select(m => new OrganizationSmartSearch()
        {
            id = m.Field<long>("Org_ID"),
            name = m.Field<string>("Org_Desc"),

        }).ToList();
        //Session["AngularComboID"] = OrgList;
        return OrgList;

    }
    
}

