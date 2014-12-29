using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Data;
using System.Web.Security;
using System.Collections;
using System.Configuration;

/// <summary>
/// Summary description for Project_class
/// </summary>
public class Project_class
{
    public Project_class()
	{
		//
		// TODO: Add constructor logic here
		//
        
	}
   
    public static DataTable Active_Projects(int rol,int Dept_id,int pmp)
    {
        DataTable dt = new DataTable();

        dt = Project_DB.SelectActive_Projects(rol,Dept_id,pmp);

        return dt;
    }
    public static DataTable Ended_Projects(int rol, int Dept_id, int pmp)
    {
        DataTable dt = new DataTable();

        dt = Project_DB.SelectEnded_Projects(rol, Dept_id, pmp);

        return dt;
    }
    public static DataTable under_follow_Projects(int rol, int Dept_id, int pmp)
    {
        DataTable dt = new DataTable();

        dt = Project_DB.Selectunder_follow_Projects(rol, Dept_id, pmp);

        return dt;
    }
    public static DataTable Stopped_Projects(int rol, int Dept_id, int pmp)
    {
        DataTable dt = new DataTable();

        dt = Project_DB.SelectStopped_Projects(rol, Dept_id, pmp);

        return dt;
    }
    public static DataTable Suggest_Approved_Projects(int rol, int Dept_id, int pmp)
    {
        DataTable dt = new DataTable();

        dt = Project_DB.SelectSuggest_Approved_Projects(rol, Dept_id, pmp);

        return dt;
    }
    public static DataTable Suggest_Projects(int rol, int Dept_id, int pmp)
    {
        DataTable dt = new DataTable();

        dt = Project_DB.SelectSuggest_Projects(rol, Dept_id, pmp);

        return dt;
    }
    public static DataTable Repeated_Projects(int rol, int Dept_id, int pmp)
    {
        DataTable dt = new DataTable();

        dt = Project_DB.SelectRepeated_Projects(rol, Dept_id, pmp);

        return dt;
    }
    public static DataTable Refused_Projects(int rol, int Dept_id, int pmp)
    {
        DataTable dt = new DataTable();

        dt = Project_DB.SelectRefused_Projects(rol, Dept_id, pmp);

        return dt;
    }
    public static DataTable Canceled_Projects(int rol, int Dept_id, int pmp)
    {
        DataTable dt = new DataTable();

        dt = Project_DB.SelectCanceled_Projects(rol, Dept_id, pmp);

        return dt;
    }

    public static DataTable Projects_Constraints()
    {
        DataTable dt = new DataTable();

        dt = Project_DB.Project_Constraints();

        return dt;
    }

    public static DataTable Allmodules()
    {
        DataTable dt = new DataTable();

        dt = Project_DB.SelectModules();

        return dt;
    }
    public static DataTable Allmodulesbyfound(int found)
    {
        DataTable dt = new DataTable();

        dt = Project_DB.SelectModulesbyfound(found);

        return dt;
    }
   
}