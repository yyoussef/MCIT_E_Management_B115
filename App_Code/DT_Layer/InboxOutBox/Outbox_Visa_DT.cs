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
/// Summary description for Inbox_Visa_DT
/// </summary>
public class Outbox_Visa_DT
{
    public enum EnumInfo_Visa
    {
        Visa_Id, Outbox_ID, Important_Degree, Dept_ID, Emp_ID, Dead_Line_DT, Visa_Goal_ID, Follow_Up_Dept_ID, Follow_Up_Emp_ID, Visa_Satus, Visa_Desc, Visa_date, Important_Degree_Txt, Dept_ID_Txt, Emp_ID_Txt, Visa_Period, Follow_Up_Notes, saving_file, mail_sent
    }



    public Int32 Visa_Id, Visa_Goal_ID;

    public Int32 Outbox_ID;

    public Int32 Follow_Up_Dept_ID;

    public Int32 Follow_Up_Emp_ID;

    public String Follow_Up_Notes, Dead_Line_DT;


    public Int32 Important_Degree;

    public Int32 Dept_ID;

    public Int32 Emp_ID;

    public Int32 Visa_Satus;

    public String Visa_Desc;

    public String Visa_date;

    public String Important_Degree_Txt;

    public String Dept_ID_Txt;

    public String Emp_ID_Txt;

    public String Visa_Period;

    public String saving_file;

    public Int32 mail_sent;
}
