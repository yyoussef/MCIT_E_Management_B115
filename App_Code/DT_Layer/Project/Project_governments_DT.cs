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
/// Summary description for Project_governments_DT
/// </summary>
public class Project_governments_DT
{
    public enum projectgov_eunm
    {
        proj_gov_id, Proj_id, gov_id, gov_notes
    }
    public int proj_gov_id;
    public int Proj_id;
    public int gov_id;
    public string gov_notes;
    
}
