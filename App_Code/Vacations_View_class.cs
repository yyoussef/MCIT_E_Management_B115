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
/// Summary description for Vacations_View_class
/// </summary>
public class Vacations_View_class
{
	public Vacations_View_class()
	{
		//
		// TODO: Add constructor logic here
		//
	}



    public static DataTable new_vacations_requests(int pmp)
    {
        DataTable dt = new DataTable();
        dt = Vacations_DB.Select_by_dept(pmp);

        return dt;
    }


    public static DataTable new_vacations_requests_dept(int dept_id)
    {
        DataTable dt = new DataTable();
        dt = Vacations_DB.SelectVac_by_dept(dept_id );

        return dt;
    }

    public static DataTable new_Errand_requests(int pmp)
    {
        DataTable dt = new DataTable();
        dt = Vacations_errand_DB.Select_by_dept(pmp);

        return dt;
    }


    public static DataTable new_dayoff_requests(int pmp)
    {
        DataTable dt = new DataTable();
        dt = Vacations_Dayoff_DB.Select_by_dept(pmp);

        return dt;
    }



    public static DataTable new_permissions_requests(int pmp)
    {
        DataTable dt = new DataTable();
        dt = Vocations_permission_DB.Select_by_dept0(pmp);

        return dt;
    }

    public static DataTable Sector_Vacation_Resposible(int sector_id,int foundation_id)
    {
        DataTable dt = new DataTable();
        dt = Vocations_permission_DB.Sector_VacationResposible(sector_id,foundation_id);

        return dt;
    }

}
