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
using System.Data.SqlClient;
using System.IO;
using System.Text;

public partial class Admin_Foundation_localconnection : System.Web.UI.Page
{
    Session_CS Session_CS = new Session_CS();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
         
            fillconstring();

        }

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {

        string connection = txt_connstring.Text;
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = connection;
        try
        {
            conn.Open();
        }
        catch
        {

            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('عفوا لم يتم الاتصال بقاعدة البيانات من فضلك ادخل البيانات الصحيحة')</script>");

        }
        
        if(conn.State == ConnectionState.Open)
        {
        int result = SqlHelper.ExecuteNonQuery(Database.ConnectionString, "Foundations_update", CDataConverter.ConvertToInt(Session_CS.foundation_id), txt_connstring.Text);

       


        if (result  > 0)
        {


            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('تم الحفظ بنجاح')</script>");


        }
        }
        else 
        {
            Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('عفوا لم يتم الاتصال من فضلك ادخل البيانات الصحيحة')</script>");


        }

    }

    private void fillconstring()
    {
        Foundations_DT  obj = Foundations_DB.SelectByID(CDataConverter.ConvertToInt(Session_CS.foundation_id));
        if( obj.connection_string != "" && obj.connection_string!=null )
        txt_connstring.Text = obj.connection_string.ToString();

    }

    private void create_tables()
    {
        ////begin create tables and stored procedures////////////////////////////////////////////
        string connectionn = txt_connstring.Text;
        SqlConnection connn = new SqlConnection();
        connn.ConnectionString = connectionn;

        SqlCommand com = new SqlCommand();
        try
        {
            connn.Open();

            StringBuilder query = new StringBuilder();

            query.Append ("CREATE PROCEDURE [dbo].[Fin_Work_bill_Files_Select] @id int AS SELECT * FROM [dbo].[Fin_Work_bill_Files] WHERE [File_ID] = @id ");
            query.AppendLine();
            query.Append (" go ");
            query.AppendLine();
            query.Append ( "CREATE TABLE [dbo].[Inbox_OutBox_Files]([Inbox_OutBox_File_ID] [int] NOT NULL,[Inbox_Outbox_ID] [int] NULL,[Inbox_Or_Outbox] [int] NULL,[Original_Or_Attached] [int] NULL,[File_data] [varbinary](max) NULL,[File_name] [nvarchar](4000) NULL,[File_ext] [nvarchar](50) NULL,CONSTRAINT [PK_Inbox_OutBox_Files] PRIMARY KEY CLUSTERED ([Inbox_OutBox_File_ID] ASC)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]) ON [PRIMARY]");

            query.AppendLine();
            query.Append(" go ");
            query.AppendLine();

            query.Append ( "CREATE PROCEDURE [dbo].[Get_File_Documents] @id  int As BEGIN SELECT Doc_File as File_data ,Doc_type as File_ext ,Doc_name as File_name , Source_id ,Files_id FROM [File_Documents] WHERE ([Doc_id] = @id) END ");
            query.AppendLine();
            query.Append(" go ");
            query.AppendLine();
            query.Append ("CREATE PROCEDURE [dbo].[Get_Event] @id  int AS BEGIN SELECT * FROM [Event] WHERE ([id] = @id ) END ");
            query.AppendLine();
            query.Append(" go ");
            query.AppendLine();
            query.Append ("CREATE PROCEDURE [dbo].[Departments_Documents_Select] @id int AS SET NOCOUNT ON SET TRANSACTION ISOLATION LEVEL READ COMMITTED IF @id >0 BEGIN SELECT * FROM [dbo].[Departments_Documents] WHERE [File_ID] = @id END ELSE IF @id = 0 BEGIN SELECT * FROM [dbo].[Departments_Documents] Order By File_ID DESC	END");
            query.AppendLine();
            query.Append(" go ");
            query.AppendLine();
            query.Append ( "CREATE TABLE [dbo].[Commission_Files]([Commission_File_ID] [int] NOT NULL,[Commission_ID] [int] NULL,[Inbox_Or_Outbox] [int] NULL,[Original_Or_Attached] [int] NULL,[File_data] [varbinary](max) NULL,[File_name] [nvarchar](4000) NULL,[File_ext] [nvarchar](50) NULL,CONSTRAINT [PK_Commission_Files] PRIMARY KEY CLUSTERED ([Commission_File_ID] ASC)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]) ON [PRIMARY] ");
            query.AppendLine();
            query.Append(" go ");
            query.AppendLine();
            query.Append ("CREATE TABLE [dbo].[Commission_Visa_Follows]([Follow_ID] [int] NOT NULL,[Commission_ID] [int] NULL,[Descrption] [nvarchar](4000) NULL,[Date] [nvarchar](50) NULL,[File_data] [varbinary](max) NULL,[File_name] [nvarchar](1000) NULL,[File_ext] [nvarchar](250) NULL,[Visa_Emp_id] [int] NULL,[entery_pmp_id] [int] NULL,	[time_follow] [nvarchar](50) NULL,[Type_Follow] [int] NULL, CONSTRAINT [PK_Commission_Visa_Follows] PRIMARY KEY CLUSTERED ([Follow_ID] ASC)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]) ON [PRIMARY] ");
            query.AppendLine();
            query.Append(" go ");
            query.Append ("CREATE TABLE [dbo].[Inbox_Visa_Follows](	[Follow_ID] [int] NOT NULL,[Inbox_ID] [int] NULL,	[Descrption] [nvarchar](500) NULL,	[Date] [nvarchar](50) NULL,	[File_data] [varbinary](max) NULL,[File_name] [nvarchar](1000) NULL,[File_ext] [nvarchar](250) NULL,[Visa_Emp_id] [int] NULL,[entery_pmp_id] [int] NULL,[time_follow] [nvarchar](50) NULL,[Type_Follow] [int] NULL,[Entery_Date] [nvarchar](50) NULL,CONSTRAINT [PK_Inbox_Visa_Follows] PRIMARY KEY CLUSTERED ([Follow_ID] ASC)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]) ON [PRIMARY] ");
            query.AppendLine();
            query.Append(" go ");
            query.AppendLine();
            query.Append ( "CREATE PROCEDURE [dbo].[Protocol_Main_Documents_Select] @id  int AS BEGIN SELECT     ID, Protocol_ID, File_Name , File_Type as File_ext, File_Source as File_data FROM         Protocol_Main_Documents  WHERE ([ID] = @id )END ");
            query.AppendLine();
            query.Append(" go ");
            query.AppendLine();
            query.Append ( "CREATE PROCEDURE [dbo].[Protocol_Finishing_Select] @id  int AS BEGIN SELECT     ID, Protocol_ID, File_Name , File_Type as File_ext, File_Source as File_data FROM         Protocol_Finishing WHERE ([ID] = @id ) END ");
            query.AppendLine();
            query.Append(" go ");
            query.AppendLine();
            query.Append ("CREATE PROCEDURE [dbo].[Protocol_Documents_Select] @id  int AS BEGIN SELECT     ID, Protocol_ID, File_Name , File_Type as File_ext, File_Source as File_data FROM         Protocol_Documents WHERE ([ID] = @id )END ");
            query.AppendLine();
            query.Append(" go ");
            query.AppendLine();
            query.Append ( "CREATE PROCEDURE [dbo].[Get_Protocol] @id  int AS BEGIN SELECT * FROM [Protocol] WHERE ([id] = @id) END");
            query.AppendLine();
            query.Append(" go ");
            query.AppendLine();
            query.Append ( "CREATE PROCEDURE [dbo].[Project_Needs_Document_select]  @id int AS SELECT * from Project_Needs_Document where id=@id ");
            query.AppendLine();
            query.Append(" go ");
            query.AppendLine();
            query.Append ( "CREATE PROCEDURE [dbo].[Project_End_Document_Select] @id int AS SELECT *  FROM	[dbo].[Project_End_Document] WHERE	[End_Doc_ID] = @id ");
            query.AppendLine();
            query.Append(" go ");
            query.AppendLine();
            query.Append ("create PROCEDURE [dbo].[proj_video_service_Select] @id int AS IF  (@id > 0 ) BEGIN SELECT * FROM [dbo].[proj_video_service] WHERE [proj_video_service_id] = @id END ELSE IF @id = 0 BEGIN SELECT * FROM [dbo].[proj_video_service] Order By proj_video_service_id DESC	END ");
            query.AppendLine();
            query.Append(" go ");
            query.AppendLine();
            query.Append ( "create PROCEDURE [dbo].[proj_statistics_service_Select] @id int AS IF  (@id > 0 ) BEGIN SELECT * FROM	[dbo].[proj_statistics_service] WHERE [proj_statistics_service_id] = @id END ELSE IF @id = 0 BEGIN SELECT * FROM [dbo].[proj_statistics_service] Order By proj_statistics_service_id DESC	 END ");
            query.AppendLine();
            query.Append(" go ");
            query.AppendLine();
            query.Append ( "CREATE PROCEDURE [dbo].[proj_img_service_Select] @id int AS IF  (@id > 0 ) BEGIN SELECT * FROM [dbo].[proj_img_service] WHERE [proj_img_service_id] = @id END ELSE IF @id = 0 BEGIN SELECT * FROM [dbo].[proj_img_service] Order By proj_img_service_id DESC	 END ");
            query.AppendLine();
            query.Append(" go ");
            query.AppendLine();
            query.Append ( "CREATE PROCEDURE [dbo].[Get_Presentation] @id  int AS BEGIN SELECT * FROM [Presentation] WHERE ([id] = @id) END ");
            query.AppendLine();
            query.Append(" go ");
            query.AppendLine();
            query.Append ( "CREATE TABLE [dbo].[Outbox_Visa_Follows](	[Follow_ID] [int] NOT NULL,	[Outbox_ID] [int] NULL,	[Descrption] [nvarchar](500) NULL,	[Date] [nvarchar](50) NULL,	[File_data] [varbinary](max) NULL,[File_name] [nvarchar](1000) NULL,	[File_ext] [nvarchar](250) NULL,	[Visa_Emp_id] [int] NULL,	[entery_pmp_id] [int] NULL,	[time_follow] [nvarchar](50) NULL,[Type_Follow] [int] NULL,CONSTRAINT [PK_Outbox_Visa_Follows] PRIMARY KEY CLUSTERED (	[Follow_ID] ASC)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]) ON [PRIMARY]");
            query.AppendLine();
            query.Append(" go ");
            query.AppendLine();
            query.Append ( "CREATE PROCEDURE [dbo].[Get_Outbox] @id  int As BEGIN SELECT I.*,O.* FROM [Outbox] I left outer join [Organization] O on I.Outbox_organization = O.Org_ID  WHERE (I.id = @id) END ");
            query.AppendLine();
            query.Append(" go ");
            query.AppendLine();
            query.Append ( "CREATE PROCEDURE [dbo].[Get_Meetings_Files_By_ID] @id  int As BEGIN SELECT * FROM [Meetings_Files]  WHERE  ([id] = @id) order by File_name ASC END ");
            query.AppendLine();
            query.Append(" go ");
            query.AppendLine();
            query.Append ( "create PROCEDURE [dbo].[Inbox_Visa_Select_For_Doc] @id int AS SELECT * FROM [dbo].[Inbox_Visa] WHERE [visa_ID] = @id ");
            query.AppendLine();
            query.Append(" go ");
            query.AppendLine();
            query.Append ( "Create PROCEDURE [dbo].[Inbox_Visa_Follows_Select_For_Doc] @id int AS SELECT	* FROM [dbo].[Inbox_Visa_Follows] WHERE [Follow_ID] = @id ");
            query.AppendLine();
            query.Append(" go ");
            query.AppendLine();
            query.Append ( "CREATE PROCEDURE [dbo].[Outbox_Visa_Follows_Select_For_Doc] @id int AS SELECT * FROM [dbo].[Outbox_Visa_Follows] WHERE [Follow_ID] = @id ");
            query.AppendLine();
            query.Append(" go ");
            query.AppendLine();
            query.Append ( "CREATE PROCEDURE [dbo].[Inbox_OutBox_Files_Select] @id int AS SET NOCOUNT ON SET TRANSACTION ISOLATION LEVEL READ COMMITTED IF (@id <>0) BEGIN SELECT	[Inbox_OutBox_File_ID],	[Inbox_Outbox_ID],	[Inbox_Or_Outbox],	[Original_Or_Attached],	[File_data],	[File_name],[File_ext] FROM [dbo].[Inbox_OutBox_Files] WHERE [Inbox_OutBox_File_ID] = @id END ELSE IF @id = 0 BEGIN SELECT	[Inbox_OutBox_File_ID],	[Inbox_Outbox_ID],	[Inbox_Or_Outbox],	[Original_Or_Attached],	[File_data],	[File_name],[File_ext] FROM [dbo].[Inbox_OutBox_Files] Order By Inbox_OutBox_File_ID DESC	END");
            query.AppendLine();
            query.Append(" go ");
            query.AppendLine();
            query.Append ("CREATE PROCEDURE [dbo].[Commission_Files_Select] @id int AS SET NOCOUNT ON SET TRANSACTION ISOLATION LEVEL READ COMMITTED IF (@id <>0) BEGIN SELECT	[Commission_File_ID],	[Commission_ID],	[Inbox_Or_Outbox],	[Original_Or_Attached],	[File_data],	[File_name],	[File_ext] FROM [dbo].[Commission_Files] WHERE [Commission_File_ID] = @id END ELSE IF @id = 0 BEGIN SELECT	[Commission_File_ID],	[Commission_ID],	[Inbox_Or_Outbox],	[Original_Or_Attached],	[File_data],	[File_name],	[File_ext] FROM [dbo].[Commission_Files] Order By Commission_File_ID DESC	 END");
            query.AppendLine();
            query.Append(" go ");
            query.AppendLine();
            query.Append ( "CREATE PROCEDURE [dbo].[Commission_Visa_Follows_Select_For_Doc] @id int AS SELECT * FROM	[dbo].[Commission_Visa_Follows] WHERE [Follow_ID] = @id ");

            com.Connection = connn;
            com.CommandText =  query.ToString();

            com.ExecuteScalar();
            connn.Close();
        }

        catch
        {

        }
    }

    protected void btn_create_Click(object sender, EventArgs e)
    {
        create_tables();
    }
    
}
