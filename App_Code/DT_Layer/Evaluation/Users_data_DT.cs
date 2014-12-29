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
/// Summary description for Users_data_DT
/// </summary>
public class Users_data_DT
{
    public enum enuminfo_users_data
    {
        USR_ID, USR_Name, USR_Pass, pmp_pmp_id, UROL_UROL_ID, System_ID, account_active
    }
    public int USR_ID;
    public string USR_Name;
    public string USR_Pass;
    public int pmp_pmp_id;
    public int UROL_UROL_ID;
    public int System_ID;
    public bool account_active;

}
