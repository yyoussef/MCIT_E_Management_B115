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
using System.Data.SqlClient;

/// <summary>
/// Summary description for Governments_DB
/// </summary>
public class Governments_DB
{
    private static Governments_DT FillInfoObject(SqlDataReader dr)
    {
        Governments_DT ogovernmentobj = new Governments_DT();
        ogovernmentobj.gov_id = dr[Governments_DT.Governments_enuminfo.gov_id.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dr[Governments_DT.Governments_enuminfo.gov_id.ToString()]);
        ogovernmentobj.gov_name = dr[Governments_DT.Governments_enuminfo.gov_name.ToString()] == DBNull.Value ? string.Empty : Convert.ToString(dr[Governments_DT.Governments_enuminfo.gov_name.ToString()]);
        return ogovernmentobj;
    }
    private static SqlParameter[] GetParameters(Governments_DT obj, bool isSearch)
    {
        SqlParameter[] parms = new SqlParameter[2];
        if(!isSearch )
        {
            parms[0]=new SqlParameter (Governments_DT.Governments_enuminfo.gov_id.ToString(),obj.gov_id );
            parms[0].Direction = ParameterDirection.InputOutput;
        }
        parms[1] = new SqlParameter(Governments_DT.Governments_enuminfo.gov_name.ToString(), obj.gov_name);
        return parms;
    }
    public static DataTable Select_gov()
    {

        return SqlHelper.ExecuteDataset(Database.ConnectionString, "government_select").Tables[0];

    }




}
