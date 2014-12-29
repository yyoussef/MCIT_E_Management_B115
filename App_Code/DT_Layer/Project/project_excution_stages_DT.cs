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
/// Summary description for project_excution_stages_DT
/// </summary>
public class project_excution_stages_DT
{
    public enum EnumInfo_project_excution_stages
    {
        id, proj_stage, proj_stage_output, proj_id
    }
    public int id;
    public string proj_stage;
    public string proj_stage_output;
    public int proj_id;
   
}
