
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Microsoft.Office.Interop.MSProject;
using System.Reflection;
using System.IO;

public partial class WebForms2_Import_From_MPP : System.Web.UI.Page
{
    Session_CS Session_CS = new Session_CS();
    public string main_activity = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        //  Session_CS.Project_id = "252";

    }

    private void Create_MPP()
    {
        string File_Name; //= "D://Test_Project.mpp";
        File_Name = Server.MapPath("~//Uploads/Project_Activities.mpp");
        Application appclass = new Application();

        appclass.FileOpen(File_Name, false, Missing.Value, Missing.Value, Missing.Value,
        Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value,
        PjPoolOpen.pjDoNotOpenPool, Missing.Value, Missing.Value, true, Missing.Value);



        appclass.Visible = false;
        Project proj = appclass.ActiveProject;
        for (int z = 1; z <= 3; z++)
            foreach (Microsoft.Office.Interop.MSProject.Task task_old in proj.Tasks)
                task_old.Delete();

        Microsoft.Office.Interop.MSProject.Task task;



        DataTable DT_Proj_Activitess = General_Helping.GetDataTable("select * from Project_Activities where PActv_Parent=0 and proj_proj_id =" + CDataConverter.ConvertToInt(Session_CS.Project_id) + "order by PActv_ID DESC ");
        for (int i = 0; i < DT_Proj_Activitess.Rows.Count; i++)
        {

            task = proj.Tasks.Add(DT_Proj_Activitess.Rows[i]["PActv_Desc"].ToString(), 1);
            task.PercentWorkComplete = DT_Proj_Activitess.Rows[i]["PActv_Progress"].ToString();
            task.OutlineLevel = (short)(1);
            if (CDataConverter.ConvertToInt(DT_Proj_Activitess.Rows[i]["PActv_Period"].ToString()) > 0)
                task.Duration = DT_Proj_Activitess.Rows[i]["PActv_Period"].ToString();
            task.Start = DT_Proj_Activitess.Rows[i]["PActv_Start_Date"].ToString();
            task.Finish = DT_Proj_Activitess.Rows[i]["PActv_End_Date"].ToString();
            task.Text1 = DT_Proj_Activitess.Rows[i]["PActv_Desc"].ToString();

            Load_Rec(proj, 1, DT_Proj_Activitess.Rows[i]["PActv_ID"].ToString());

        }



        appclass.SaveSheetSelection();
        appclass.FileCloseAll(PjSaveType.pjSave);



        // for open document for user
        FileStream fs = new FileStream(File_Name, FileMode.Open, FileAccess.Read);

        byte[] bytes = new byte[fs.Length];

        fs.Read(bytes, 0, System.Convert.ToInt32(fs.Length));

        fs.Close();


        Response.ContentType = "application/x-unknown";
        string File_Name_Show = "";
        File_Name_Show = "Project_Activities.mpp";
        Response.AddHeader("Content-Disposition", "attachment; filename=" + Server.UrlPathEncode(File_Name_Show));
        Response.BinaryWrite(bytes);
        Response.Flush();
        Response.Close();




    }

    private void Load_Rec(Project proj, int OutlineLevel, string PActv_ID)
    {
        Microsoft.Office.Interop.MSProject.Task task;
        DataTable DT_Proj_Activitess = new DataTable();
        DT_Proj_Activitess = General_Helping.GetDataTable("select * from Project_Activities where PActv_Parent =" + PActv_ID + "order by PActv_ID DESC ");

        if (DT_Proj_Activitess.Rows.Count != 0)
        {
            for (int i = 0; i < DT_Proj_Activitess.Rows.Count; i++)
            {

                DataRow row = DT_Proj_Activitess.Rows[i];
                task = proj.Tasks.Add(row["PActv_Desc"].ToString(), OutlineLevel + 1);
                task.PercentWorkComplete = row["PActv_Progress"].ToString();
                task.OutlineLevel = (short)(OutlineLevel + 1);
                if (CDataConverter.ConvertToInt(row["PActv_Period"].ToString()) > 0)
                    task.Duration = row["PActv_Period"].ToString();
                task.Start = row["PActv_Start_Date"].ToString();
                task.Finish = row["PActv_End_Date"].ToString();
                task.Text1 = row["PActv_Desc"].ToString();
                Load_Rec(proj, task.OutlineLevel, row["PActv_ID"].ToString());

            }


        }

    }





    protected void btn_Create_Click(object sender, EventArgs e)
    {
        Create_MPP();
    }

    protected void btn_Upload_Click(object sender, EventArgs e)
    {
        if (FileUpload.HasFile)
        {
            string DocName = FileUpload.FileName;
            int dotindex = DocName.LastIndexOf(".");
            string type = DocName.Substring(dotindex, DocName.Length - dotindex);
            if (type.ToLower() == ".mpp")
            {
                //try
                //{
                string Sql_Delete = "Delete from Project_Activities where proj_proj_id = " + CDataConverter.ConvertToInt(Session_CS.Project_id);
                General_Helping.ExcuteQuery(Sql_Delete);
                load_MPP();
                Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم إستيراد البيانات بنجاح')</script>");
                //}
                //catch
                //{
                //    Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('يوجد خطأ ما يرجى المحاولة مرة اخرى')</script>");
                //}

            }
        }


    }

    private void load_MPP()
    {

        ApplicationClass projectApp = new ApplicationClass();
        //Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('1234')</script>");
        // Open the file. There are a number of options in this constructor as you can see
        projectApp.FileOpen(FileUpload.PostedFile.FileName, true, Missing.Value, Missing.Value, Missing.Value,
        Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value,
        PjPoolOpen.pjDoNotOpenPool, Missing.Value, Missing.Value, Missing.Value, Missing.Value);

        // Get the active project 
        Project proj = projectApp.ActiveProject;
        int parent_count = 0;
        foreach (Task task in proj.Tasks)
        {


            if (task.OutlineLevel == 1)
            {
                main_activity = task.Name;
                parent_count++;
                string Sql = "insert into Project_Activities (Proj_Proj_Id,PActv_Progress,PActv_Desc,PActv_Start_Date,PActv_End_Date,PActv_Period," +
                             "PActv_Actual_Start_Date,PActv_Actual_End_Date,PActv_Parent) ";
                Sql += "values (" + Session_CS.Project_id.ToString() + ",'" + CDataConverter.ConvertToDecimal(task.PercentWorkComplete.ToString())
                    + "','" + task.Name + "','" + DateTime.Parse(task.Start.ToString()).ToString("dd/MM/yyyy") + "','"
                    + DateTime.Parse(task.Finish.ToString()).ToString("dd/MM/yyyy") + "','" + CDataConverter.ConvertToInt(task.Duration.ToString()) / 480
                    + "','" + DateTime.Parse(task.Start.ToString()).ToString("dd/MM/yyyy") + "','" + DateTime.Parse(task.Finish.ToString()).ToString("dd/MM/yyyy") +
                    "','" + "0" + "') select @@identity ";
                string Sql2 = "";
                int Table_ID = General_Helping.ExcuteQuery(Sql);
                DataTable _dt = General_Helping.GetDataTable("SELECT MAX(PActv_ID) AS LargestPActv_ID FROM Project_Activities");
                load_MPP_Rec(task, 1, CDataConverter.ConvertToInt(_dt.Rows[0]["LargestPActv_ID"].ToString()), task.Name);
            }

        }

        // Make sure to clean up and close the file



        projectApp.FileCloseAll(PjSaveType.pjDoNotSave);



    }

    void load_MPP_Rec(Task task, int Level, int Table_ID, string task_Name)
    {

        foreach (Task task_Child in task.OutlineChildren)
        {
            if (task_Child.OutlineLevel == Level + 1)
            {

                string Sql = "insert into Project_Activities (Proj_Proj_Id,PActv_Progress,PActv_Desc,PActv_Start_Date,PActv_End_Date,PActv_Period," +
                             "PActv_Actual_Start_Date,PActv_Actual_End_Date,PActv_Parent) ";
                Sql += "values (" + Session_CS.Project_id.ToString() + ",'" + CDataConverter.ConvertToDecimal(task.PercentWorkComplete.ToString()) + "','" + task_Child.Name + "','" + DateTime.Parse(task_Child.Start.ToString()).ToString("dd/MM/yyyy") + "','"
                    + DateTime.Parse(task_Child.Finish.ToString()).ToString("dd/MM/yyyy") + "','" + CDataConverter.ConvertToInt(task_Child.Duration.ToString()) / 480 + "','" + DateTime.Parse(task_Child.Start.ToString()).ToString("dd/MM/yyyy") + "','" + DateTime.Parse(task_Child.Finish.ToString()).ToString("dd/MM/yyyy") +
                    "','" + Table_ID + "') select @@identity ";

                int child_Table_ID = General_Helping.ExcuteQuery(Sql);

                DataTable _dt = General_Helping.GetDataTable("SELECT MAX(PActv_ID) AS LargestPActv_ID FROM Project_Activities");

                load_MPP_Rec(task_Child, task_Child.OutlineLevel, CDataConverter.ConvertToInt(_dt.Rows[0]["LargestPActv_ID"].ToString()), task_Name);
            }

        }

    }

}
//Project_Details.aspx?proj_id=250
//Project_Activities.aspx