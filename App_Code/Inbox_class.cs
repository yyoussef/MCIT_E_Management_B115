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
public class Inbox_class
{
	public Inbox_class()
	{
		//
		// TODO: Add constructor logic here
		//
        
	}
   
    public static DataTable new_inbox_all(int parent,int group,int pmp,int active)
    {
        DataTable dt = new DataTable();

        dt = Inbox_DB.new_inbox_all(parent, group, pmp, active);

        return dt;
    }
    public static DataTable old_inbox_all(int parent, int group, int pmp, int active)
    {
        DataTable dt = new DataTable();

        dt = Inbox_DB.old_inbox_all(parent, group, pmp, active);

        return dt;
    }
    public static DataTable late_inbox_all(int parent, int group, int pmp, string todayplus1, string todayplus2, int active)
    {
        DataTable dt = new DataTable();

        dt = Inbox_DB.late_inbox_all(parent, group, pmp, todayplus1, todayplus2, active);

        return dt;
    }
    public static DataTable closed_inbox_all(int parent, int group, int pmp, int active)
    {
        DataTable dt = new DataTable();

        dt = Inbox_DB.closed_inbox_all(parent, group, pmp, active);

        return dt;
    }
    public static DataTable follow_inbox_all(int parent, int pmp, int active)
    {
        DataTable dt = new DataTable();

        dt = Inbox_DB.follow_inbox_all(parent, pmp, active);

        return dt;
    }
    public static DataTable understudy_inbox_all(int group, int active)
    {
        DataTable dt = new DataTable();

        dt = Inbox_DB.understudy_inbox_all(group, active);

        return dt;
    }
  
    public static DataTable getinbox_not_sent_visa(int group,int parent_id)
    {
        DataTable dt = new DataTable();

        dt = Inbox_DB.get_inbox_not_sent_visa(group, parent_id);

        return dt;
    }
    public static DataTable getinbox_sent_visa(int group,int parent)
    {
        DataTable dt = new DataTable();

        dt = Inbox_DB.get_inbox_sent_visa(group, parent);

        return dt;
    }
    public static DataTable getchild(int pmp)
    {
        DataTable dt = new DataTable();

        dt = Inbox_DB.getchild(pmp);

        return dt;
    }
    public static DataTable getparent(int child , int type )
    {
        DataTable dt = new DataTable();

        dt = Inbox_DB.getparent(child,type);

        return dt;
    }

}