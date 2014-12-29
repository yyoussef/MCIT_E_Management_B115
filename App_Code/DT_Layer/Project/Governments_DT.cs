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
/// Summary description for Governments_DT
/// </summary>
public class Governments_DT
{
    public enum Governments_enuminfo
    {
        gov_id, gov_name
    }
    public int gov_id;
    public string gov_name;
}
