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
/// Summary description for Bulliten_View
/// </summary>
public class Bulliten_View
{
	public Bulliten_View()
	{
		//
		// TODO: Add constructor logic here
		//
	}




    public static DataTable new_bulliten(int Emp_ID, int Review_Status)
    {
        DataTable dt = new DataTable();

        dt = Review_Track_Emp_DB.Select_bulliten_new(Emp_ID,Review_Status);

        return dt;
    }


    public static DataTable closed_bulliten(int Emp_ID, int Review_Status)
    {
        DataTable dt = new DataTable();

        dt = Review_Track_Emp_DB.Select_bulliten_closed(Emp_ID, Review_Status);

        return dt;
    }

    public static DataTable new_bulliten_review()
    {
        DataTable dt = new DataTable();

        dt = Review_DB.SelectAll();

     

        return dt;
    }
}
