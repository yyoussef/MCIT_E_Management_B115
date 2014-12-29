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
/// Summary description for project_success_elements_DT
/// </summary>
public class project_success_elements_DT
{
    public enum EnumInfo_project_success_elements
    {
        id, succ_elm_desc, style_deal, proj_id
    }
    public int id;
    public string succ_elm_desc;
    public string style_deal;
    public int proj_id;

}
