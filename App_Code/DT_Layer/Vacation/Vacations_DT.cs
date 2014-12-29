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
/// Summary description for Vacations_DT
/// </summary>
public class Vacations_DT
{
    public enum EnumInfo_Vacation
    {
        id, user_id, request_user_id, alternative_user_id, no_days, start_date, vacation_id, end_date, request_date, manager_approve, general_manager_approve, dept_id,
        type
            , notes, file_name,
    }

    /// <summary>
    /// 
    /// </summary>
    protected Int32 mdept_id;
    public Int32 dept_id
    {
        get
        {
            return mdept_id;
        }
        set
        {
            mdept_id = value;
        }
    }
    /// <summary>
    /// 
    /// </summary>
    protected Int32 mgeneral_manager_approve;
    public Int32 general_manager_approve
    {
        get
        {
            return mgeneral_manager_approve;
        }
        set
        {
            mgeneral_manager_approve = value;
        }
    }
    /// <summary>
    /// 
    /// </summary>
    protected Int32 mmanager_approve;
    public Int32 manager_approve
    {
        get
        {
            return mmanager_approve;
        }
        set
        {
            mmanager_approve = value;
        }
    }
    /// <summary>
    /// 
    /// </summary>
    protected Int32 mvacation_id;
    public Int32 vacation_id
    {
        get
        {
            return mvacation_id;
        }
        set
        {
            mvacation_id = value;
        }
    }
    /// <summary>
    /// 
    /// </summary>
    protected Int32 mno_days;
    public Int32 no_days
    {
        get
        {
            return mno_days;
        }
        set
        {
            mno_days = value;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    protected Int32 malternative_user_id;
    public Int32 alternative_user_id
    {
        get
        {
            return malternative_user_id;
        }
        set
        {
            malternative_user_id = value;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    protected Int32 mid;
    public Int32 id
    {
        get
        {
            return mid;
        }
        set
        {
            mid = value;
        }
    }

    /// <summary>
    /// 
    /// </summary>

    protected Int32 muser_id;
    public Int32 user_id
    {
        get
        {
            return muser_id;
        }
        set
        {
            muser_id = value;
        }
    }
    /// <summary>
    /// 
    /// </summary>
    protected Int32 mrequest_user_id;
    public Int32 request_user_id
    {
        get
        {
            return mrequest_user_id;
        }
        set
        {
            mrequest_user_id = value;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    protected String mstart_date;
    public String start_date
    {
        get
        {
            return mstart_date;
        }
        set
        {
            mstart_date = value;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    protected String mend_date;
    public String end_date
    {
        get
        {
            return mend_date;
        }
        set
        {
            mend_date = value;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    protected String mrequest_date;
    public String request_date
    {
        get
        {
            return mrequest_date;
        }
        set
        {
            mrequest_date = value;
        }
    }
    protected Int32 vtype;
    public Int32 type
    {
        get
        {
            return vtype;
        }
        set
        {
            vtype = value;
        }
    }

    protected String vnotes;
    public String notes
    {
        get
        {
            return vnotes;
        }
        set
        {
            vnotes = value;
        }
    }

    protected String vfile_name;
    public String file_name
    {
        get
        {
            return vfile_name;
        }
        set
        {
            vfile_name = value;
        }
    }
}

