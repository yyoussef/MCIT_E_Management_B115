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
/// Summary description for Vocations_permission_DT
/// </summary>
public class Vocations_permission_DT
{
    public enum EnumInfo_Vacation
    {
        id, user_id, request_user_id, alternative_user_id, permission_no, start_date, request_date, manager_approve, general_manager_approve, dept_id, start_hour, end_hour
    }
    public Int32 id;
    public Int32 user_id;
    public Int32 request_user_id;
    public Int32 alternative_user_id;
    public Int32 dept_id;
    public Int32 manager_approve;
    public Int32 general_manager_approve;
    public Int32 permission_no;
    public String start_date;
    public String request_date;
    public String start_hour;
    public String  end_hour;
    
}
