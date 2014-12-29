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
/// Summary description for Departments_Documents_DT
/// </summary>
public class Departments_Documents_DT
{
    public enum EnumInfo_Documents
    {
        File_ID, File_Type, Dept_ID, Emp_ID, File_data, File_Desc, File_name, File_ext, Proj_Proj_id, Parent_ID, File_Sytem_Name, Page_Count, Entery_DT, TheOrder, upload_on_sector,
    }



    public Int32 File_ID, Proj_Proj_id, Parent_ID, Page_Count, upload_on_sector;

    public Int32 File_Type;

    public Int32 Dept_ID;

    public Int32 TheOrder;

    public Int32 Emp_ID;

    public Byte[] File_data;

    public String File_Desc, File_Sytem_Name, Entery_DT;

    public String File_name;

    public String File_ext;
}
