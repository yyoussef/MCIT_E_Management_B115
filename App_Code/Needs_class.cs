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
/// Summary description for Needs_class
/// </summary>
public class Needs_class
{
    public Needs_class()
	{
		//
		// TODO: Add constructor logic here
		//
        
	}
   
    public static DataTable Needs_No_Approve()
    {
        DataTable dt = new DataTable();

        dt = Project_DB.Selectneeds_no_approve();

        return dt;
    }
    public static DataTable Needs_No_Available()
    {
        DataTable dt = new DataTable();

        dt = Project_DB.Selectneeds_no_Available();

        return dt;
    }
    public static DataTable Needs_Recieved()
    {
        DataTable dt = new DataTable();

        dt = Project_DB.Selectneeds_Recievied();

        return dt;
    }
    public static DataTable Needs_Approved(int pmp)
    {
        DataTable dt = new DataTable();

        dt = Project_DB.Selectneeds_Approved(pmp);

        return dt;
    }
    public static DataTable Needs_Available_Recievable(int pmp)
    {
        DataTable dt = new DataTable();

        dt = Project_DB.Selectneeds_Available_Recievable(pmp);

        return dt;
    }
   
}