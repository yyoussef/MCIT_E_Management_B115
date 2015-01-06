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
using System.IO;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Smo.Agent;
using System.Data.SqlClient;
using System.Text;
using System.Net;
using System.Windows;
#region "Author"
// Name : Zainab Asaad
//Date : ON 10/08/014
#endregion
public partial class Database_Backup : System.Web.UI.Page
{
    #region "Members"
    string newdatabase_Name;
    string Olddatabase_Name;
    string createDB_command;
    string copyData_command;
    string backUP_command;
    string jobrunning_command;
    string jobexecuted_command;
    string custom_copyData_command;

    string custom_copy_command;
    string declare_varaibles;
    string copy_without_distinct;
    string copy_with_distinct;
    string backup_path;

    string jobname;
    string jobname2;
    string jobname3;
    int found_id;
    int cond;
    #endregion
    #region "Events"
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            gvmain();

        }



    }

    protected void ImgBtnEdit_Click(object sender, ImageClickEventArgs e)
    {
        //string File_Name = "";
       // File_Name = Convert.ToString(((ImageButton)sender).CommandArgument);

        //string New_File_Path =Server.MapPath("~/Uploads/DBBackup/" + File_Name) ;

                               // FileStream fs = new FileStream(New_File_Path, FileMode.Open, FileAccess.Read);

                                //byte[] bytes = new byte[fs.Length];

                                //fs.Read(bytes, 0, System.Convert.ToInt32(fs.Length));

                               // fs.Close();



       // Response.ContentType = "application/x-unknown";
       
        //Response.AddHeader("Content-Disposition", "attachment; filename=" + Server.UrlPathEncode(File_Name));
       // Response.BinaryWrite(bytes);
       // Response.Flush();
        //Response.Close();




 string file_Name = Convert.ToString(((ImageButton)sender).CommandArgument);
        System.IO.FileInfo Dfile = new System.IO.FileInfo(Server.MapPath("~/Uploads/DBBackup/" + file_Name));
        Response.ContentType = "APPLICATION/OCTET-STREAM";
        String Header = "Attachment; Filename=" + file_Name;
        Response.AppendHeader("Content-Disposition", Header);
      
        Response.WriteFile(Dfile.FullName);
      
        Response.End();


     //  string file_Name = Convert.ToString(((ImageButton)sender).CommandArgument);
       //string path = "D://NEW" + "/" + file_Name;
       // string path = "~/Uploads/DBBackup/" + file_Name;
       // Response.Redirect(path);

    }
  

    


    protected void bt_DB_Backup_Click(object sender, EventArgs e)
    {

        try
        {
            backup_path = System.Configuration.ConfigurationSettings.AppSettings["backup_path"].ToString();
            Olddatabase_Name = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString).Database;
            // set the new database name according to current foundation
            found_id = CDataConverter.ConvertToInt(Session_CS.foundation_id.ToString());
            newdatabase_Name = "Foundation" + "_" + found_id.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
            // set the command which will be used in sql agent job
            /////////////////////////////////// createDB_command ///////////////////////////////////////////
            createDB_command = ScriptDatabase(Olddatabase_Name, newdatabase_Name);
            /////////////////////////////////// copyData_command ///////////////////////////////////////////
            copyData_command = copy_Data(Olddatabase_Name, newdatabase_Name);
            /////////////////////////////////// copyData_command ///////////////////////////////////////////
            custom_copy_command = custom_Copy_Data(Olddatabase_Name, newdatabase_Name);
            /////////////////////////////////// backUP_command ///////////////////////////////////////////
            backUP_command = "  use " + newdatabase_Name;
            backUP_command += " DECLARE @name VARCHAR(50)   ";
            backUP_command += " DECLARE @path VARCHAR(256) ";
            backUP_command += " DECLARE @fileName VARCHAR(256)  ";
            backUP_command += " DECLARE @fileDate VARCHAR(20) ";
            // -- specify database backup directory
            backUP_command += " SET @path = '" + backup_path + "' ";
            backUP_command += " set @name='" + newdatabase_Name + "'";
            // -- specify filename format
            backUP_command += " SELECT @fileDate = CONVERT(VARCHAR(20),GETDATE(),112) + '_' + REPLACE(CONVERT(VARCHAR(20),GETDATE(),108),':','')";
            backUP_command += " SET @fileName = @path + @name +'.BAK' ";
            backUP_command += " BACKUP DATABASE @name TO DISK = @fileName ";

            string backupfile_Name = newdatabase_Name + ".BAK";
            jobrunning_command = "use " + Olddatabase_Name + " insert into foundation_backupfile (foundation_id,found_backupfilename,date,Status) values (" + found_id + ",'" + backupfile_Name + "'," + "'" + DateTime.Now.ToShortDateString() + "',1)";
            jobexecuted_command = "use " + Olddatabase_Name + " update foundation_backupfile set Status=1 where Status=0 and foundation_id=" + found_id;
            //jobname = "dbJob" + "_" + DateTime.Now.ToString("yyyy_MM_ddTHH_mm_ss");
            jobname = newdatabase_Name;
            createjob(jobname, newdatabase_Name, createDB_command, copyData_command, custom_copy_command, backUP_command, jobrunning_command, jobexecuted_command);
            //Response.Write(createDB_command);

            //jobname2 = "backupJob" + "_" + DateTime.Now.ToString("yyyy_MM_ddTHH_mm_ss");
            //createjob(jobname2, newdatabase_Name, "", "", "", backUP_command);

            //jobname3 = "custom_copyJob" + "_" + DateTime.Now.ToString("yyyy_MM_ddTHH_mm_ss");
            //createjob(jobname3, newdatabase_Name, "", "", custom_copy_command, "");

            backup_database(jobname, "", "", newdatabase_Name);


        }
        catch
        {

        }
    }
    #endregion
    #region "Methods"
    protected void gvmain()
    {
        /////////////////////////////////////////////////////////////////////////////////////////////
        ////////////---- ---- download files from ftp server w/o ftp in url -------------------//////
        /////////////////////////////////////////////////////////////////////////////////////////////
        //DataTable dt = SqlHelper.ExecuteDataset(Database.ConnectionString, "Foundation_Backup_Filename", Session_CS.foundation_id).Tables[0];

        ////int looping =  dt.Rows.Count ;
        //int i;
        //for (i = 0; i < dt.Rows.Count; i++)
        //{
        //    string File_Title = (dt.Rows[i]["found_backupfilename"]).ToString();
        //    int selected_found_id = CDataConverter.ConvertToInt(dt.Rows[i]["id"]);

        //    string ResponseDescription = "";
        //    string PureFileName = File_Title;//new FileInfo(File_Title.ToString()).Name;
        //    string DownloadedFilePath = "D:NEW" + "/" + PureFileName;
        //    string downloadUrl = String.Format("{0}/{1}", "ftp://" + "10.60.201.33", PureFileName);
        //    FtpWebRequest req = (FtpWebRequest)FtpWebRequest.Create(downloadUrl);
        //    req.Method = WebRequestMethods.Ftp.DownloadFile;
        //    // req.Credentials = new NetworkCredential(userName, password);
        //    req.UseBinary = true;
        //    req.Proxy = null;
        //    try
        //    {
        //        // WebResponse response = req.GetResponse();
        //        FtpWebResponse response = (FtpWebResponse)req.GetResponse();
        //        Stream stream = response.GetResponseStream();
        //        byte[] buffer = new byte[2048];
        //        FileStream fs = new FileStream(DownloadedFilePath, FileMode.Create);
        //        int ReadCount = stream.Read(buffer, 0, buffer.Length);
        //        while (ReadCount > 0)
        //        {
        //            fs.Write(buffer, 0, ReadCount);
        //            ReadCount = stream.Read(buffer, 0, buffer.Length);
        //        }
        //        //ResponseDescription = response.StatusDescription;
        //        fs.Close();
        //        stream.Close();
               // int sucess = SqlHelper.ExecuteNonQuery(Database.ConnectionString, "update_Foundation_Backup_Filename", selected_found_id);



        //    }
        //    catch (Exception X)
        //    {
        //        Console.WriteLine(X.Message);
        //    }
        //}
        ///////////////////////////////////////////////////////////////////////////////////
        /////////////////////////--------------------------///////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////



        // ---- show file in folder ----------//
        //string[] fileArray = Directory.GetFiles(@"D:\new\");
        //gvMain.DataSource = fileArray;
        //gvMain.DataBind();

       // ---------------------------------///

        //////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////---- selected files exists in ftp folder in app server status = 2 -------------////
        /////////////////////////////////////////////////////////////////////////////////////////////////
        DataTable dt2 = SqlHelper.ExecuteDataset(Database.ConnectionString, "Foundation_Backup_Filename2", Session_CS.foundation_id).Tables[0];



        gvMain.DataSource = dt2;
        gvMain.DataBind();
       
        foreach (GridViewRow row in gvMain.Rows)
        {
            Label LabStatus = (Label)row.FindControl("LabStatus");
            ImageButton ImgBtnEdit = (ImageButton)row.FindControl("ImgBtnEdit");
            Label Labelwait = (Label)row.FindControl("Labelwait");
           
            if (LabStatus.Text.ToString() == "2")
            {
                Labelwait.Visible = false;
                ImgBtnEdit.Visible = true;


            }
            else if (LabStatus.Text.ToString() == "0")
            {

                ImgBtnEdit.Visible = false;
                Labelwait.Visible = true;


            }




        }



    }
    ////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////
    ///////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// this function return a string which contains a script for copy databse structure without primary key and identity proerties
    /// </summary>
    /// <param name="oldDatabase"> the name of databse which will be copied</param>
    /// <param name="newDatabase_Name"> the name of new database </param>
    /// <returns></returns>
    public string ScriptDatabase(string oldDatabase, string newDatabase_Name)
    {

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);


        try
        {

            ServerConnection svconn = new ServerConnection(con);
            svconn.Connect();

            Server sv = new Server(svconn);


            Microsoft.SqlServer.Management.Smo.Database db = sv.Databases[oldDatabase];
            //Database db = 

            Microsoft.SqlServer.Management.Smo.Database newDatbase = new Microsoft.SqlServer.Management.Smo.Database(sv, newDatabase_Name);
            newDatbase.Create();

            ScriptingOptions options = new ScriptingOptions();
            StringBuilder sb = new StringBuilder();
            // options.ScriptData = true;
            options.ScriptDrops = false;
            options.ScriptSchema = true;
            // options.EnforceScriptingOptions = true;
            // options.Indexes = true;
            options.IncludeHeaders = true;
            //options.WithDependencies = true;

            TableCollection tables = db.Tables;


            foreach (Microsoft.SqlServer.Management.Smo.Table mytable in tables)
            {
                foreach (string line in db.Tables[mytable.Name].EnumScript(options))
                {
                    sb.Append(line + "\r\n");
                }
            }

            string[] splitter = new string[] { "\r\nGO\r\n" };
            string[] commandTexts = sb.ToString().Split(splitter, StringSplitOptions.RemoveEmptyEntries);

            string scriptresult1 = commandTexts[0].ToString();
            int index = scriptresult1.IndexOf("SET "); // to write use (database name) at the begining of sql script
            string scriptresult12 = scriptresult1.Insert(index, "use " + newDatabase_Name + "\n");
            scriptresult12 = scriptresult12.Replace("IDENTITY(1,1)", ""); // remove identity

            return scriptresult12;
        }
        catch (Exception e)
        {
            System.Diagnostics.Debug.WriteLine("PROGRAM FAILED: " + e.Message);

            return "";
        }
        finally
        {
            con.Close();
        }
    }
    /// <summary>
    /// this function create the job which responsible for copy database structure and data and finally do backup
    /// </summary>
    /// <param name="job_Name">the job name</param>
    /// <param name="db_Name">the new database name</param>
    /// <param name="createDB_command">the command of create db (structure)</param>
    /// <param name="copyData_command">the command of copy data without conditions (look up tables)</param>
    /// <param name="custom_copydata_command">the command of copy data with condition (remaining tables)</param>
    /// <param name="backUP_command">the command of backup new database</param>
    /// <returns></returns>
    public string createjob(string job_Name, string db_Name, string createDB_command, string copyData_command, string custom_copydata_command, string backUP_command, string job_running_step, string job_exectued_step)
    {

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

        ServerConnection svconn = new ServerConnection(con);
        svconn.Connect();

        Server server = new Server(svconn);

        // Get instance of SQL Agent SMO object 
        JobServer jobServer = server.JobServer;
        Job job = null;
        JobStep step = null;


        // Create Job 
        job = new Job(jobServer, job_Name);

        job.Create();
        job.ApplyToTargetServer("(local)");
        

        // Create  db step 
        if (createDB_command != "")
        {
            //lbltitle.Text = createDB_command;
            step = new JobStep(job, "Creationdb_Step");
            step.Command = createDB_command;
            step.SubSystem = AgentSubSystem.TransactSql;
            step.OnSuccessAction = StepCompletionAction.GoToNextStep;
            step.Create();
        }

        // Create  job status (running) 

        //lbltitle.Text = createDB_command;
        if (job_running_step != "")
        {
            step = new JobStep(job, "Job_running_step");
            step.Command = job_running_step;
            step.SubSystem = AgentSubSystem.TransactSql;
            step.OnSuccessAction = StepCompletionAction.GoToNextStep;
            step.Create();

        }


        // Copy data Step 
        if (custom_copydata_command != "")
        {
            step = new JobStep(job, "custom_copydata_Step");
            step.Command = custom_copydata_command;
            step.SubSystem = AgentSubSystem.TransactSql;
            step.OnSuccessAction = StepCompletionAction.GoToNextStep;

            step.Create();
        }
        //Custom copy data Step 
        if (copyData_command != "")
        {
            step = new JobStep(job, "copyData_Step");
            step.Command = copyData_command;
            step.SubSystem = AgentSubSystem.TransactSql;
            step.OnSuccessAction = StepCompletionAction.GoToNextStep;

            step.Create();
        }
        //Backup database Step 
        if (backUP_command != "")
        {
            step = new JobStep(job, "backUP_Step");
            step.Command = backUP_command;
            step.SubSystem = AgentSubSystem.TransactSql;
            step.OnSuccessAction = StepCompletionAction.GoToNextStep;
            step.Create();
        }
        // ensure back up process Step 
        if (job_exectued_step != "")
        {
            step = new JobStep(job, "Job_Exectued_Step");
            step.Command = job_exectued_step;
            step.SubSystem = AgentSubSystem.TransactSql;
            step.OnSuccessAction = StepCompletionAction.QuitWithSuccess;
            step.Create();
        }
        // job.ApplyToTargetServer(server.Name);

        return jobname;
    }
    /// <summary>
    /// this function start the created job then delete new database and job
    /// </summary>
    /// <param name="job_Name"></param>
    /// <param name="DB_Name"></param>
    public void backup_database(string job_Name, string job_Name2, string job_Name3, string DB_Name)
    {


        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

        ServerConnection svconn = new ServerConnection(con);
        svconn.Connect();

        Server server = new Server(svconn);

        try
        {
            //Get the particular job object using job name
            if (job_Name != "")
            {
                Microsoft.SqlServer.Management.Smo.Agent.Job job = server.JobServer.Jobs[job_Name];
                //Check the job state, if it is not running i.e Idle then start the job
                if (job.CurrentRunStatus == Microsoft.SqlServer.Management.Smo.Agent.JobExecutionStatus.Idle)
                {
                    lbltitle.Text = "job started";

                    job.Start();
                }
            }
            if (job_Name2 != "")
            {
                Microsoft.SqlServer.Management.Smo.Agent.Job job2 = server.JobServer.Jobs[job_Name2];
                //Check the job state, if it is not running i.e Idle then start the job
                if (job2.CurrentRunStatus == Microsoft.SqlServer.Management.Smo.Agent.JobExecutionStatus.Idle)
                    job2.Start();
            }
            if (job_Name3 != "")
            {
                Microsoft.SqlServer.Management.Smo.Agent.Job job3 = server.JobServer.Jobs[job_Name3];
                //Check the job state, if it is not running i.e Idle then start the job
                if (job3.CurrentRunStatus == Microsoft.SqlServer.Management.Smo.Agent.JobExecutionStatus.Idle)
                    job3.Start();
            }
            gvmain();

            // Delete job and database created 
            if (DB_Name != "")
            {
                //server.ConnectionContext.ExecuteNonQuery("USE msdb EXEC sp_delete_job @job_name ='" + job_Name + "'"); 
                //server.ConnectionContext.ExecuteNonQuery("USE msdb EXEC sp_delete_job @job_name ='" + job_Name2 + "'"); 
                //server.ConnectionContext.ExecuteNonQuery("USE msdb EXEC sp_delete_job @job_name ='" + job_Name3 + "'"); 
                // server.ConnectionContext.ExecuteNonQuery("USE master DROP DATABASE" + DB_Name );
            }
            lblerrMsg.Visible = true;
            lblerrMsg.Text = "تم حفظ نسخة من قاعدة البيانات بنجاح";

        }
        catch (Exception ex)
        {
            lblerrMsg.Text = "عفوا حدث خطأ أثناء حفظ قاعدة البيانات";

        }


    }
    public string custom_Copy_Data(string olddbname, string newdbname)
    {
        found_id = CDataConverter.ConvertToInt(Session_CS.foundation_id.ToString());

        custom_copy_command = " use" + " " + olddbname;
        custom_copy_command += " exec dynamic_Custom_copy_Data Inbox," + olddbname + "," + newdbname + ",'and foundation_id = " + found_id + "','',0";
        custom_copy_command += " exec dynamic_Custom_copy_Data inbox_cat," + olddbname + "," + newdbname + ",'and Inbox.foundation_id  = " + found_id + "','INNER JOIN Inbox ON Inbox.ID = inbox_cat.inbox_id',0";
        custom_copy_command += " exec dynamic_Custom_copy_Data inbox_follow_emp," + olddbname + "," + newdbname + ",'and Inbox.foundation_id = " + found_id + "','INNER JOIN Inbox ON Inbox.ID = inbox_follow_emp.inbox_id',0";
        custom_copy_command += " exec dynamic_Custom_copy_Data inbox_Main_Categories," + olddbname + "," + newdbname + ",'and EMPLOYEE.foundation_id  = " + found_id + "',' INNER JOIN EMPLOYEE ON inbox_Main_Categories.group_id = EMPLOYEE.Group_id',1";
        custom_copy_command += " exec dynamic_Custom_copy_Data inbox_sub_categories," + olddbname + "," + newdbname + ",'and EMPLOYEE.foundation_id  = " + found_id + "','INNER JOIN inbox_Main_Categories ON inbox_Main_Categories.id = inbox_sub_categories.main_id INNER JOIN EMPLOYEE ON EMPLOYEE.Group_id = inbox_Main_Categories.group_id',1";

        custom_copy_command += " exec dynamic_Custom_copy_Data Outbox," + olddbname + "," + newdbname + ",'and foundation_id = " + found_id + "','',0";
        custom_copy_command += " exec dynamic_Custom_copy_Data outbox_cat," + olddbname + "," + newdbname + ",'and outbox.foundation_id = " + found_id + "','INNER JOIN outbox   ON outbox.ID = outbox_cat.outbox_id',0";
        custom_copy_command += " exec dynamic_Custom_copy_Data outbox_follow_emp," + olddbname + "," + newdbname + ",'and outbox.foundation_id = " + found_id + "','INNER JOIN outbox ON outbox.ID = outbox_follow_emp.outbox_id',0";
        custom_copy_command += " exec dynamic_Custom_copy_Data outbox_Main_Categories," + olddbname + "," + newdbname + ",'and EMPLOYEE.foundation_id= " + found_id + "','INNER JOIN EMPLOYEE ON outbox_Main_Categories.group_id = EMPLOYEE.Group_id',1";
        custom_copy_command += " exec dynamic_Custom_copy_Data outbox_sub_categories," + olddbname + "," + newdbname + ",'and EMPLOYEE.foundation_id = " + found_id + "','INNER JOIN outbox_Main_Categories ON outbox_Main_Categories.id = outbox_sub_categories.main_id INNER JOIN EMPLOYEE ON outbox_Main_Categories.group_id = EMPLOYEE.Group_id',1";

        custom_copy_command += " exec dynamic_Custom_copy_Data outbox_Track_Emp," + olddbname + "," + newdbname + ",'and foundation_id = " + found_id + "','INNER JOIN outbox ON outbox_Track_Emp.outbox_id = outbox.ID',0";
        custom_copy_command += " exec dynamic_Custom_copy_Data outbox_Track_Manager," + olddbname + "," + newdbname + ",'and foundation_id  = " + found_id + "','INNER JOIN outbox ON outbox_Track_Manager.outbox_id = outbox.ID',0";
        custom_copy_command += " exec dynamic_Custom_copy_Data outbox_Visa," + olddbname + "," + newdbname + ",'and foundation_id  = " + found_id + "','INNER JOIN outbox ON outbox_Visa.outbox_id = outbox.ID',0";
        custom_copy_command += " exec dynamic_Custom_copy_Data outbox_Visa_Emp," + olddbname + "," + newdbname + ",'and foundation_id = " + found_id + "','INNER JOIN outbox_Visa ON outbox_Visa_Emp.Visa_Id = outbox_Visa.Visa_Id INNER JOIN outbox ON outbox_Visa.outbox_ID = outbox.ID',0";
        custom_copy_command += " exec dynamic_Custom_copy_Data outbox_Visa_Follows," + olddbname + "," + newdbname + ",'and foundation_id = " + found_id + "','INNER JOIN outbox  ON outbox.ID = outbox_Visa_Follows.outbox_ID',0";

        cond = 2;
        custom_copy_command += " exec dynamic_Custom_copy_Data inbox_OutBox_Files," + olddbname + "," + newdbname + ",'and foundation_id = " + found_id + " and inbox_Or_Outbox = " + cond + "','INNER JOIN outbox   ON outbox.ID = inbox_OutBox_Files.inbox_Outbox_ID',0";
        custom_copy_command += " exec dynamic_Custom_copy_Data Commission," + olddbname + "," + newdbname + ",'and Commission.foundation_id = " + found_id + "','',0";
        custom_copy_command += " exec dynamic_Custom_copy_Data Commission_follow_emp," + olddbname + "," + newdbname + ",'and foundation_id = " + found_id + "','INNER JOIN Commission ON Commission.ID = Commission_follow_emp.Commission_id',0";
        custom_copy_command += " exec dynamic_Custom_copy_Data Commission_Track_Emp," + olddbname + "," + newdbname + ",'and foundation_id = " + found_id + "','INNER JOIN Commission ON Commission_Track_Emp.Commission_id = Commission.ID',0";
        custom_copy_command += " exec dynamic_Custom_copy_Data Commission_Visa," + olddbname + "," + newdbname + ",'and foundation_id = " + found_id + "','INNER JOIN Commission ON Commission_Visa.Commission_id = Commission.ID',0";

        custom_copy_command += " exec dynamic_Custom_copy_Data Commission_Visa_Emp," + olddbname + "," + newdbname + ",'and foundation_id = " + found_id + "','INNER JOIN Commission_Visa ON Commission_Visa_Emp.Visa_Id = Commission_Visa.Visa_Id INNER JOIN Commission ON Commission_Visa.Commission_ID = Commission.ID',0";
        custom_copy_command += " exec dynamic_Custom_copy_Data Commission_Visa_Follows," + olddbname + "," + newdbname + ",'and foundation_id = " + found_id + "','INNER JOIN Commission  ON Commission.ID = Commission_Visa_Follows.Commission_ID',0";
        custom_copy_command += " exec dynamic_Custom_copy_Data Commission_Files," + olddbname + "," + newdbname + ",'and foundation_id = " + found_id + "','INNER JOIN Commission  ON Commission.ID = Commission_Files.Commission_ID',0";
        custom_copy_command += " exec dynamic_Custom_copy_Data Inbox_Relations," + olddbname + "," + newdbname + ",'and foundation_id = " + found_id + "','',0";
        custom_copy_command += " exec dynamic_Custom_copy_Data Inbox_Track_Emp," + olddbname + "," + newdbname + ",'and foundation_id = " + found_id + "','INNER JOIN Inbox ON Inbox_Track_Emp.inbox_id = Inbox.ID',0";


        custom_copy_command += " exec dynamic_Custom_copy_Data Inbox_Track_Manager," + olddbname + "," + newdbname + ",'and foundation_id = " + found_id + "','INNER JOIN Inbox ON Inbox_Track_Manager.inbox_id = Inbox.ID',0";
        custom_copy_command += " exec dynamic_Custom_copy_Data Inbox_Visa," + olddbname + "," + newdbname + ",'and foundation_id = " + found_id + "','INNER JOIN Inbox ON Inbox_Visa.inbox_id = Inbox.ID',0";
        custom_copy_command += " exec dynamic_Custom_copy_Data Inbox_Visa_Emp," + olddbname + "," + newdbname + ",'and foundation_id = " + found_id + "','INNER JOIN Inbox_Visa ON Inbox_Visa_Emp.Visa_Id = Inbox_Visa.Visa_Id INNER JOIN Inbox ON Inbox_Visa.Inbox_ID = Inbox.ID',0";
        custom_copy_command += " exec dynamic_Custom_copy_Data Inbox_Visa_Follows," + olddbname + "," + newdbname + ",'and foundation_id = " + found_id + "','INNER JOIN Inbox ON Inbox.ID = Inbox_Visa_Follows.Inbox_ID',0";
        cond = 1;
        custom_copy_command += " exec dynamic_Custom_copy_Data Inbox_OutBox_Files," + olddbname + "," + newdbname + ",'and foundation_id = " + found_id + "and Inbox_Or_Outbox = " + cond + "','INNER JOIN Inbox ON Inbox.ID = Inbox_OutBox_Files.Inbox_Outbox_ID',0";

        custom_copy_command += " exec dynamic_Custom_copy_Data Admin_Users," + olddbname + "," + newdbname + ",'and foundation_id = " + found_id + "','',0";
        custom_copy_command += " exec dynamic_Custom_copy_Data Site_Upload," + olddbname + "," + newdbname + ",'and foundation_id = " + found_id + "','',0";
        custom_copy_command += " exec dynamic_Custom_copy_Data Sectors," + olddbname + "," + newdbname + ",'and foundation_id = " + found_id + "','',0";
        custom_copy_command += " exec dynamic_Custom_copy_Data Departments," + olddbname + "," + newdbname + ",'and Departments.foundation_id = " + found_id + "','INNER JOIN Sectors ON Departments.Sec_sec_id = Sectors.Sec_id',0";
        custom_copy_command += " exec dynamic_Custom_copy_Data Commitee," + olddbname + "," + newdbname + ",'and foundation_id = " + found_id + "','',0";

        custom_copy_command += " exec dynamic_Custom_copy_Data Employee_Groups," + olddbname + "," + newdbname + ",'and foundation_id = " + found_id + "','',0";
        custom_copy_command += " exec dynamic_Custom_copy_Data EMPLOYEE," + olddbname + "," + newdbname + ",'and foundation_id = " + found_id + "','',0";
        custom_copy_command += " exec dynamic_Custom_copy_Data Employee_Managers," + olddbname + "," + newdbname + ",'and EMPLOYEE.foundation_id  = " + found_id + "','INNER JOIN EMPLOYEE ON Employee_Managers.Emp_ID = EMPLOYEE.PMP_ID',0";
        custom_copy_command += " exec dynamic_Custom_copy_Data Employee_publicdata," + olddbname + "," + newdbname + ",'and EMPLOYEE.foundation_id = " + found_id + "','INNER JOIN EMPLOYEE ON Employee_publicdata.pmp_id = EMPLOYEE.PMP_ID',0";
        custom_copy_command += " exec dynamic_Custom_copy_Data Employee_Ex_Training," + olddbname + "," + newdbname + ",'and foundation_id = " + found_id + "','INNER JOIN EMPLOYEE ON Employee_Ex_Training.pmp_id = EMPLOYEE.PMP_ID',0";


        custom_copy_command += " exec dynamic_Custom_copy_Data Users," + olddbname + "," + newdbname + ",'and foundation_id = " + found_id + "','INNER JOIN EMPLOYEE ON Users.pmp_pmp_id = EMPLOYEE.PMP_ID',0";
        custom_copy_command += " exec dynamic_Custom_copy_Data Users_Permission," + olddbname + "," + newdbname + ",'and EMPLOYEE.foundation_id  = " + found_id + "','INNER JOIN EMPLOYEE ON Users_Permission.pmp_pmp_id = EMPLOYEE.PMP_ID',0";
        custom_copy_command += " exec dynamic_Custom_copy_Data EMPLOYEE_Departemnts," + olddbname + "," + newdbname + ",'and EMPLOYEE.foundation_id  = " + found_id + "','INNER JOIN EMPLOYEE ON EMPLOYEE_Departemnts.PMP_ID = EMPLOYEE.PMP_ID',0";
        custom_copy_command += " exec dynamic_Custom_copy_Data commitee_presidents," + olddbname + "," + newdbname + ",'and foundation_id = " + found_id + "','INNER JOIN EMPLOYEE ON commitee_presidents.PMP_ID = EMPLOYEE.PMP_ID',0";
        custom_copy_command += " exec dynamic_Custom_copy_Data Organization," + olddbname + "," + newdbname + ",'and foundation_id = " + found_id + "','',0";


        custom_copy_command += " exec dynamic_Custom_copy_Data parent_employee," + olddbname + "," + newdbname + ",'and EMPLOYEE.foundation_id  = " + found_id + "','INNER JOIN EMPLOYEE ON parent_employee.pmp_id = EMPLOYEE.PMP_ID',0";
        custom_copy_command += " exec dynamic_Custom_copy_Data Admin_Module_Found," + olddbname + "," + newdbname + ",'and found_id = " + found_id + "','',0";



        return custom_copy_command;

    }
    public string copy_Data(string oldDb, string newdb)
    {
        string copyData = "";
        copyData = " use" + " " + oldDb;
        copyData += " exec dynamic_inserttabledata_migration " + oldDb + "," + newdb + ",Admin_Module,Admin_Module";
        copyData += " exec dynamic_inserttabledata_migration " + oldDb + "," + newdb + ",Admin_ModulePage,Admin_ModulePage";
        copyData += " exec dynamic_inserttabledata_migration " + oldDb + "," + newdb + ",Admin_Page,Admin_Page";
        copyData += " exec dynamic_inserttabledata_migration " + oldDb + "," + newdb + ",Admin_RoleModule,Admin_RoleModule";
        copyData += " exec dynamic_inserttabledata_migration " + oldDb + "," + newdb + ",Admin_Users,Admin_Users";
        //copyData += " declare @SourceDbName sysname='" + oldDb + "';";
        //copyData += " declare @copyData_command varchar(8000) ";
        //copyData += " declare @tableName sysname ";
        //copyData += " declare Cur_tab Cursor  ";
        //copyData += " for ";
        //copyData += " select name from sys.tables t where t.type='u' and name  in ('Admin_Module','Admin_ModulePage','Admin_Page','Admin_RoleModule','Admin_Users') order by name ;";
        //copyData += " open cur_tab  ";
        //copyData += " fetch next FROM CUR_TAB into @tablename; "; 
        //copyData += " DECLARE @listStr VARCHAR(MAX) ";
        //copyData += " WHILE @@FETCH_STATUS =0  ";
        //copyData += " begin     ";
        //copyData += " SET @listStr=null; ";
        //copyData += " SELECT @listStr = COALESCE(@listStr+',' ,'') + Name ";
        //copyData += " FROM sys.columns where object_id=object_id(@tableName) ; ";
        //copyData += " SET @copyData_command= @TABLENAME +' INSERT INTO '+@TABLENAME+'('+@liststr+') SELECT '+@liststr+' FROM  ";
        //copyData += "  ['+ convert(varchar,@SourceDbName )+'].[DBO].['+@tableName+'] ";
        //copyData += " '+ @TABLENAME ";
        //copyData += "  PRINT @copyData_command ";
        //copyData += " EXEC(@copyData_command) ";
        //copyData += "  fetch next FROM CUR_TAB into @tablename; ";
        //copyData += " end ";
        //copyData += " CLOSE CUR_TAB ";
        //copyData += " DEALLOCATE CUR_TAB ";
        //copyData += "--EXEC sp_MSforeachtable @copyData_command1='ALTER TABLE ? CHECK CONSTRAINT ALL'";
        //SqlHelper.ExecuteScalar(Database.ConnectionString, CommandType.Text, "Copy_Custom_pmsData",);
        return copyData;
    }
    #endregion

    
}