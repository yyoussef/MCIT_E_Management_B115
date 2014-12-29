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
/// Summary description for Commission_class
/// </summary>
public class Commission_class
{
	public Commission_class()
	{
		//
		// TODO: Add constructor logic here
		//
        
	}
   
    public static DataTable new_com_all(int parent,int group,int pmp)
    {
        DataTable dt = new DataTable();

        dt = Commission_DB.new_com_all(parent, group, pmp);

        return dt;
    }
    public static DataTable old_com_all(int parent, int group, int pmp)
    {
        DataTable dt = new DataTable();

        dt = Commission_DB.old_com_all(parent, group, pmp);

        return dt;
    }
    public static DataTable late_com_all(int parent, int group, int pmp,string todayplus1, string todayplus2)
    {
        DataTable dt = new DataTable();

        dt = Commission_DB.late_com_all(parent, group, pmp, todayplus1, todayplus2);

        return dt;
    }
    public static DataTable closed_com_all(int parent, int group, int pmp)
    {
        DataTable dt = new DataTable();

        dt = Commission_DB.closed_com_all(parent, group, pmp);

        return dt;
    }
    public static DataTable follow_com_all(int parent, int pmp)
    {
        DataTable dt = new DataTable();

        dt = Commission_DB.follow_com_all(parent,  pmp);

        return dt;
    }
   
    public static DataTable getchild(int pmp)
    {
        DataTable dt = new DataTable();

        dt = Inbox_DB.getchild(pmp);

        return dt;
    }
}