using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Data;

/// <summary>
/// Summary description for Project_Log_DB
/// </summary>
public class Project_Log_DB
{
    
    public enum operation
    {
        Project_Period_Balance = 1,
        Project_Activities = 2,
        Project_Constraints = 3,
        Project_Needs_Request = 4,
        Fin_Work_Order = 5,
        Departments_Documents = 6 ,
        Fin_Bills = 7,
        Agrement_Work_Order = 8 ,
        Project_Needs_Ratification = 9,
        Project_Needs_Avaialble = 10,
        Project_Needs_Recieve = 11,
        Organization = 12 ,
        Employee_Data = 13 ,
        project_status=14,

        vacations_manage=15,
        vacations_balance=16,






    }

    public enum Action
    {
        add = 1 ,
        edit = 2 ,
        read = 3,
        delete = 4
    }

    public static void FillLog(int recordID, int Action, operation enumoperation)
    {
        try

        {
            //Session_CS Session_CS = new Session_CS();
            string dateNow = CDataConverter.ConvertDateTimeNowRtrnString();
            int Pmp_id = 0;
            if (HttpContext.Current.Session["pmp_id"] != null && CDataConverter.ConvertToInt(HttpContext.Current.Session["pmp_id"]) > 0)
            {
                Pmp_id = CDataConverter.ConvertToInt(HttpContext.Current.Session["pmp_id"]);

                SqlHelper.ExecuteScalar(Database.ConnectionString, "Project_Log_Save", Pmp_id, CDataConverter.ConvertToInt(Session_CS.Project_id), Action, recordID, (int)enumoperation, dateNow);
            }
         }
        catch (Exception ex)
        {
        }
    }





}
