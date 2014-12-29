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
/// Summary description for Inbox_class
/// </summary>
public class Outbox_class
{
	public Outbox_class()
	{
		//
		// TODO: Add constructor logic here
		//
        
	}

    public static DataTable new_Outbox_all(int parent, int group, int pmp, int active)
    {
        DataTable dt = new DataTable();

        dt = Outbox_DB.new_Outbox_all(parent,group,pmp,active);

        return dt;
    }
    public static DataTable old_Outbox_all(int parent, int group, int pmp, int active)
    {
        DataTable dt = new DataTable();

        dt = Outbox_DB.old_Outbox_all(parent, group, pmp,active);

        return dt;
    }
    public static DataTable late_Outbox_all(int parent, int group, int pmp, string todayplus1, string todayplus2, int active)
    {
        DataTable dt = new DataTable();

        dt = Outbox_DB.late_Outbox_all(parent, group, pmp, todayplus1, todayplus2,active);

        return dt;
    }
    public static DataTable closed_Outbox_all(int parent, int group, int pmp, int active)
    {
        DataTable dt = new DataTable();

        dt = Outbox_DB.closed_Outbox_all(parent, group, pmp,active);

        return dt;
    }
    public static DataTable follow_Outbox_all(int parent, int group, int pmp, int active)
    {
        DataTable dt = new DataTable();

        dt = Outbox_DB.follow_Outbox_all(parent , group, pmp,active);

        return dt;
    }
    
  
    public static DataTable getOutbox_not_sent_visa(int group)
    {
        DataTable dt = new DataTable();

        dt = Outbox_DB.get_Outbox_not_sent_visa(group);

        return dt;
    }
    public static DataTable getOutbox_sent_visa(int group)
    {
        DataTable dt = new DataTable();

        dt = Outbox_DB.get_Outbox_sent_visa(group);

        return dt;
    }
   
}