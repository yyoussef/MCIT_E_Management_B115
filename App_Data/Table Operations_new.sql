

ALTER TABLE dbo.Foundations
ADD  code_outbox int
 
go

ALTER TABLE dbo.Outbox_Visa
ADD  File_data varbinary(MAX)
 
go

ALTER TABLE dbo.Outbox_Visa
ADD  File_name nvarchar(1000)
 
go

ALTER TABLE dbo.Outbox_Visa
ADD  File_ext nvarchar(250)
 
go


/* alter users_select stored */

ALTER PROCEDURE [dbo].[Users_Select]
	
	(
	@USR_Name nvarchar(255),
	@USR_Pass nvarchar(255)

	
	)
	
AS
	SELECT DISTINCT 
                      EMPLOYEE.PMP_ID, Users.USR_Name, Users.USR_Pass, EMPLOYEE.Token_User_pin, EMPLOYEE.Dept_Dept_id, EMPLOYEE.Group_id, Users.System_ID, 
                      EMPLOYEE.rol_rol_id AS UROL_UROL_ID, EMPLOYEE.foundation_id, EMPLOYEE.pmp_name, Departments.Dept_name,Departments.Dept_parent_id, EMPLOYEE.vacation_mng_pmp_id, 
                      Departments.Sec_sec_id, Foundations.code_archiving, Foundations.Port, Foundations.Host, EMPLOYEE.category, Foundations.UserName_mail, 
                      Foundations.Password, Foundations.code_outbox , Foundations.FromAddress, parent_employee_1.parent_pmp_id, parent_employee.pmp_id AS child,
                      Foundations.islocal,Foundations.connection_string
                      
FROM         EMPLOYEE INNER JOIN
                      Users ON EMPLOYEE.PMP_ID = Users.pmp_pmp_id AND Users.account_active = 1 INNER JOIN
                      Departments ON EMPLOYEE.Dept_Dept_id = Departments.Dept_id INNER JOIN
                      Foundations ON EMPLOYEE.foundation_id = Foundations.Foundation_ID LEFT OUTER JOIN
                      parent_employee ON EMPLOYEE.PMP_ID = parent_employee.pmp_id LEFT OUTER JOIN
                      parent_employee AS parent_employee_1 ON EMPLOYEE.PMP_ID = parent_employee_1.parent_pmp_id
WHERE     (Users.USR_Name = @USR_Name) AND (Users.USR_Pass = @USR_Pass) 

go

GO
/****** Object:  StoredProcedure [dbo].[get_org_by_found]    Script Date: 31/03/2015 01:03:21 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[get_org_by_found]
	@found_id int
AS
BEGIN
SELECT Org_ID, Org_Desc FROM Organization where foundation_id =@found_id
END

go



GO
/****** Object:  StoredProcedure [dbo].[get_all_projects]    Script Date: 31/03/2015 01:04:53 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[get_all_projects]
	
AS
BEGIN
SELECT Proj_id, Proj_Title FROM Project
END

go

GO
/****** Object:  StoredProcedure [dbo].[get_dept_by_found]    Script Date: 31/03/2015 01:06:01 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create  PROCEDURE [dbo].[get_dept_by_found]
	@found_id int
AS
BEGIN
	SELECT  * from    Departments  where foundation_id=@found_id
END

go


GO
/****** Object:  StoredProcedure [dbo].[select_main_cat_by_group]    Script Date: 31/03/2015 01:07:14 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[select_main_cat_by_group] 
	-- Add the parameters for the stored procedure here
	@group_id int
AS
BEGIN
	select * from Inbox_Main_Categories where group_id =@group_id
END

go

GO
/****** Object:  StoredProcedure [dbo].[get_files_by_inbox_id]    Script Date: 31/03/2015 01:08:49 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[get_files_by_inbox_id]
	-- Add the parameters for the stored procedure here
	@Inbox_Outbox_ID int
AS
BEGIN
	
	select * from Inbox_OutBox_Files where Inbox_Or_Outbox = 1 and Inbox_Outbox_ID=@Inbox_Outbox_ID
	
END
go

GO
/****** Object:  StoredProcedure [dbo].[get_inbox_visa]    Script Date: 31/03/2015 01:11:16 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[get_inbox_visa]
	@inbox_id int
AS
BEGIN
	select * from Inbox_Visa where Inbox_ID=@inbox_id
END

go

GO
/****** Object:  StoredProcedure [dbo].[Get_Visa_Emp]    Script Date: 31/03/2015 01:12:17 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[Get_Visa_Emp]
	
	@visa_id int
	
AS
BEGIN
		SELECT EMPLOYEE.pmp_name 
		FROM Inbox_Visa_Emp INNER JOIN EMPLOYEE ON Inbox_Visa_Emp.Emp_ID = EMPLOYEE.PMP_ID 
		WHERE Inbox_Visa_Emp.Visa_Id  =@visa_id
		
END


go


GO
/****** Object:  StoredProcedure [dbo].[Get_mail_sent_from_inbox_visa_by_visa]    Script Date: 31/03/2015 01:14:14 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[Get_mail_sent_from_inbox_visa_by_visa]
	
	@visa_id int
	
AS
BEGIN
		select mail_sent from Inbox_Visa where Visa_Id=@visa_id
		
END

go


GO
/****** Object:  StoredProcedure [dbo].[get_all_cat_sub_main]    Script Date: 31/03/2015 01:16:43 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[get_all_cat_sub_main] 
	@inbox_id int
AS
BEGIN
select * from inbox_cat where inbox_id=@inbox_id
END

go

GO
/****** Object:  StoredProcedure [dbo].[get_all_subs]    Script Date: 31/03/2015 01:25:41 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[get_all_subs] 
	@inbox_id int
AS
BEGIN
	SELECT     Inbox_sub_categories.id, Inbox_sub_categories.name, inbox_cat.Type
FROM         inbox_cat INNER JOIN
                      Inbox_sub_categories ON inbox_cat.Cat_id = Inbox_sub_categories.main_id
WHERE     (inbox_cat.inbox_id = @inbox_id) AND (inbox_cat.Type = 1)
END

go



GO
/****** Object:  StoredProcedure [dbo].[get_visa_follows_for_grid]    Script Date: 31/03/2015 01:26:50 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[get_visa_follows_for_grid]
	@inbox_id int
AS
BEGIN
	SELECT Inbox_Visa_Follows.Follow_ID,Inbox_Visa_Follows.Entery_Date,Inbox_Visa_Follows.File_name,Inbox_Visa_Follows.time_follow,Inbox_Visa_Follows.Inbox_ID, Inbox_Visa_Follows.Descrption, Inbox_Visa_Follows.Date, Inbox_Visa_Follows.Visa_Emp_id, EMPLOYEE.pmp_name 
	FROM Inbox_Visa_Follows INNER JOIN EMPLOYEE ON Inbox_Visa_Follows.Visa_Emp_id = EMPLOYEE.PMP_ID where Inbox_ID =@inbox_id
END

go

GO
/****** Object:  StoredProcedure [dbo].[Fil_Emp_Visa_Follow]    Script Date: 31/03/2015 01:27:55 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[Fil_Emp_Visa_Follow]
	@inbox_id int
AS
BEGIN
	 SELECT distinct EMPLOYEE.PMP_ID, EMPLOYEE.pmp_name, Inbox_Visa.Inbox_ID
	 FROM Inbox_Visa_Emp INNER JOIN  EMPLOYEE ON Inbox_Visa_Emp.Emp_ID = EMPLOYEE.PMP_ID INNER JOIN Inbox_Visa ON Inbox_Visa_Emp.Visa_Id = Inbox_Visa.Visa_Id INNER JOIN Inbox ON Inbox_Visa.Inbox_ID = Inbox.ID 
	 where Inbox_ID=@inbox_id
END

go


GO
/****** Object:  StoredProcedure [dbo].[get_employee_accoording_to_radiochek]    Script Date: 31/03/2015 01:30:31 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create  PROCEDURE [dbo].[get_employee_accoording_to_radiochek]
	@radiocheck nvarchar(20),
	@pmp_id int,
	@dept_id int = null,
	@found_id int
AS
BEGIN
		if(@radiocheck=7)
		begin
		select pmp_id from employee where PMP_ID=0
		end
		else if(@radiocheck=1)
		begin
		select * from pmp_fav_View 
		where pmp_fav_View.employee_id =@pmp_id 
		AND ( @dept_id = 0 or Dept_Dept_id= @dept_id ) ORDER BY LTRIM(pmp_name)
		end
		else if(@radiocheck=2)
		begin
		SELECT     PMP_ID,pmp_name,Dept_id FROM Departments  INNER JOIN EMPLOYEE ON Departments.Dept_id = EMPLOYEE.Dept_Dept_id
		 where  EMPLOYEE.PMP_ID not in(select parent_pmp_id from dbo.parent_employee) 
		and dbo.EMPLOYEE.workstatus = 1 and EMPLOYEE.foundation_id=@found_id 
		AND ( @dept_id = 0 or Dept_Dept_id= @dept_id ) ORDER BY LTRIM(pmp_name)
		end
		else if(@radiocheck=3)
		begin
		SELECT     PMP_ID,pmp_name FROM Departments  INNER JOIN EMPLOYEE ON Departments.Dept_id = EMPLOYEE.Dept_Dept_id 
		where dbo.EMPLOYEE.workstatus = 1 and rol_rol_id=3 and EMPLOYEE.foundation_id=@found_id
		AND ( @dept_id = 0 or Dept_Dept_id= @dept_id ) ORDER BY LTRIM(pmp_name)
		end
		
		else if(@radiocheck=4)
		begin
		SELECT     PMP_ID,pmp_name FROM Departments  INNER JOIN EMPLOYEE ON Departments.Dept_id = EMPLOYEE.Dept_Dept_id
		where dbo.EMPLOYEE.workstatus = 1 and contact_person=1 and EMPLOYEE.foundation_id=@found_id
		AND ( @dept_id = 0 or Dept_Dept_id= @dept_id ) ORDER BY LTRIM(pmp_name)
		end
		
		else if(@radiocheck=5)
		begin
		select EMPLOYEE.pmp_name + ' - رئيس ' + +' '+ Commitee.Commitee_Title as pmp_name ,EMPLOYEE.PMP_ID 
		from EMPLOYEE inner join commitee_presidents on  EMPLOYEE.PMP_ID=commitee_presidents.pmp_id 
		inner join Commitee on commitee_presidents.comt_id = Commitee.ID 
		where  Commitee.foundation_id=@found_id ORDER BY LTRIM(pmp_name)
		end
		
		else if(@radiocheck=6)
		begin
		select EMPLOYEE.pmp_name COLLATE DATABASE_DEFAULT  + ' -  ' + Departments.Dept_name  as pmp_name,EMPLOYEE.PMP_ID from EMPLOYEE inner join commitee_presidents on  EMPLOYEE.PMP_ID=commitee_presidents.pmp_id inner join Departments on  commitee_presidents.dept_id = Departments.Dept_id   inner join Sectors  on Sectors.Sec_id = Departments.Sec_sec_id
		 where Sectors.foundation_id=@found_id ORDER BY LTRIM(pmp_name)
		end
		
END

go



GO
/****** Object:  StoredProcedure [dbo].[get_all_departments]    Script Date: 31/03/2015 01:41:16 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[get_all_departments]
	
AS
BEGIN
SELECT Dept_id, Dept_name FROM Departments
END

go


GO
/****** Object:  StoredProcedure [dbo].[get_related_inbox_inbox_page]    Script Date: 01/04/2015 10:18:45 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[get_related_inbox_inbox_page]
	
	@group_id int,
	@proj_id int=null
	
AS
BEGIN
		set dateformat dmy SELECT vw_inbox_DateSubject.*,CONVERT(datetime, dbo.datevalid(Date)) as date1 
		from vw_inbox_DateSubject where group_id =  @group_id 
		
		AND ( Proj_id = 0 or Proj_id= @proj_id ) order by CONVERT(datetime, dbo.datevalid(Date)) desc
		
END

go

GO
/****** Object:  StoredProcedure [dbo].[get_data_from_parent_employee]    Script Date: 01/04/2015 10:31:53 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create  PROCEDURE [dbo].[get_data_from_parent_employee]
	
	@pmp_id int
	
AS
BEGIN
		select * from parent_employee where pmp_id =@pmp_id
		
END

go

GO
/****** Object:  StoredProcedure [dbo].[get_data_from_inbox_track_manager]    Script Date: 01/04/2015 10:36:26 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[get_data_from_inbox_track_manager]
	
	@inbox_id int
	
AS
BEGIN
		select inbox_id from Inbox_Track_Manager where inbox_id =@inbox_id
		
END

go


GO
/****** Object:  StoredProcedure [dbo].[fill_employee2]    Script Date: 01/04/2015 01:24:31 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create  PROCEDURE [dbo].[fill_employee2] 
	@Dept_id int
AS
BEGIN
	SELECT     EMPLOYEE.PMP_ID, EMPLOYEE.pmp_name, Departments.sec_sec_id 
	FROM    EMPLOYEE 
	INNER JOIN     Departments ON EMPLOYEE.Dept_Dept_id = Departments.Dept_ID  
	where Departments.Dept_ID =@Dept_id
END


go



GO
/****** Object:  StoredProcedure [dbo].[AdminUsers_SelectName_Exsit]    Script Date: 02/04/2015 10:16:29 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

alter  PROCEDURE [dbo].[AdminUsers_SelectName_Exsit]

	
   @User_name nvarchar(250),
   @ID int 
AS
begin


Select *  from dbo.Admin_Users  where User_name =@User_name and ID != @ID

END

go


GO
/****** Object:  StoredProcedure [dbo].[InboxOutbox_DeleteByOrg]    Script Date: 02/04/2015 02:02:59 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[InboxOutbox_DeleteByOrg]

	
	@Org_ID int
	
AS

declare @var nvarchar(250)
set @var ='affected'
IF @Org_ID > 0


BEGIN
 

if Not exists (SELECT top 1 id FROM	[dbo].[Inbox] WHERE Org_Id = @Org_ID

union  SELECT top 1 id FROM	[dbo].[Outbox] WHERE Org_Id = @Org_ID)

BEGIN

DELETE FROM Organization WHERE Org_ID=@Org_ID

select @var as row
End 

Else   
	BEGIN
	set  @var =''
	select @var as row
	
END

END
	


set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON

go


GO
/****** Object:  StoredProcedure [dbo].[Employee_Select_ByDept]    Script Date: 02/04/2015 02:52:42 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[Employee_Select_ByDept]

	
	@Dept_id int
	
	
AS




     IF not EXISTS (sELECT  * FROM	[dbo].[EMPLOYEE] WHERE  [Dept_Dept_id] = @Dept_id)


BEGIN 

delete FROM	[dbo].[Departments]  WHERE  [Dept_id] = @Dept_id 
	
END

	
	ELSE 

BEGIN
		
SELECT	top 1 * FROM [dbo].[EMPLOYEE]  WHERE [Dept_Dept_id] = @Dept_id
	
END


set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON


go



GO
/****** Object:  StoredProcedure [dbo].[Select_InboxCat_ByCatID]    Script Date: 16/04/2015 01:42:10 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[Select_InboxCat_ByCatID]

	
	@cat_id int ,
	@type int

	 
AS

declare @var nvarchar(250)
set  @var='rowsdeleted'

--IF  EXISTS (SELECT top 1 id fROM [dbo].inbox_sub_categories WHERE main_id = @cat_id)

--BEGIN 
--SELECT top 1 * fROM [dbo].inbox_sub_categories WHERE main_id = @cat_id 
--End


 IF not EXISTS(SELECT *  fROM [dbo].[inbox_cat] WHERE [Cat_id] = @cat_id and [type]=@type)
	
BEGIN 
	if(@type =1)
	begin
	delete from inbox_Main_Categories where [id] =@cat_id
	
    select @var as deleted
	
	end 
	else if(@type =2) 
	begin
	
    delete from inbox_sub_categories where [id] =@cat_id
    
    select @var as deleted
     
   
    end
    
END 

Else if(@type =1)


BEGIN 


SELECT  *,'' as deleted fROM [dbo].[inbox_Main_Categories] WHERE [id] = @cat_id
end 

Else 

begin 

SELECT  *,'' as deleted fROM [dbo].[inbox_sub_categories] WHERE [id] =@cat_id

End
 

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON


go

GO
/****** Object:  StoredProcedure [dbo].[SPOutboxCatDelete]    Script Date: 19/04/2015 10:54:55 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[SPOutboxCatDelete]
	@outbox_id int 
	
AS
	delete from  outbox_cat where  outbox_id=@outbox_id

	go

	
GO
/****** Object:  StoredProcedure [dbo].[SPOutbox_Visa_EmpDelete]    Script Date: 19/04/2015 11:23:51 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create  PROCEDURE [dbo].[SPOutbox_Visa_EmpDelete]
	@Visa_Id int 
	
AS
	delete from Outbox_Visa_Emp where Visa_Id = @Visa_Id

	go


	
GO
/****** Object:  StoredProcedure [dbo].[SP_vw_outbox_DateSubject]    Script Date: 19/04/2015 11:23:48 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[SP_vw_outbox_DateSubject]
	@groupID int,
	@ProjectID int
AS
	set dateformat dmy 
	if(@ProjectID>0)
	begin
		SELECT vw_outbox_DateSubject.*,CONVERT(datetime, dbo.datevalid(Date)) as date1 
		from vw_outbox_DateSubject 
		where  group_id = @groupID AND Proj_id = @ProjectID
		order by CONVERT(datetime, dbo.datevalid(Date)) desc
		end
	else
	begin
	SELECT vw_outbox_DateSubject.*,CONVERT(datetime, dbo.datevalid(Date)) as date1 
		from vw_outbox_DateSubject 
		where  group_id = @groupID 
		order by CONVERT(datetime, dbo.datevalid(Date)) desc
		end

		go

		
GO
/****** Object:  StoredProcedure [dbo].[SP_vw_inbox_minister_DateSubject]    Script Date: 19/04/2015 11:23:46 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[SP_vw_inbox_minister_DateSubject]
	@groupID int,
	@ProjectID int
AS
	set dateformat dmy 
	if(@ProjectID>0)
	begin
		SELECT vw_inbox_minister_DateSubject.* 
		from vw_inbox_minister_DateSubject 
		where  group_id = @groupID AND Proj_id = @ProjectID
		
		end
	else
	begin
	SELECT vw_inbox_minister_DateSubject.*
		from vw_inbox_minister_DateSubject 
		where  group_id = @groupID 
		
		end
		go


		
GO
/****** Object:  StoredProcedure [dbo].[SP_vw_inbox_DateSubject]    Script Date: 19/04/2015 11:23:44 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[SP_vw_inbox_DateSubject]
	@groupID int,
	@ProjectID int
AS
	set dateformat dmy 
	if(@ProjectID>0)
	begin
		SELECT vw_inbox_DateSubject.*,CONVERT(datetime, dbo.datevalid(Date)) as date1 
		from vw_inbox_DateSubject 
		where  group_id = @groupID AND Proj_id = @ProjectID
		order by CONVERT(datetime, dbo.datevalid(Date)) desc
		end
	else
	begin
	SELECT vw_inbox_DateSubject.*,CONVERT(datetime, dbo.datevalid(Date)) as date1 
		from vw_inbox_DateSubject 
		where  group_id = @groupID 
		order by CONVERT(datetime, dbo.datevalid(Date)) desc
		end

		go

		
GO
/****** Object:  StoredProcedure [dbo].[Outbox_cat_save]    Script Date: 19/04/2015 11:33:26 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[Outbox_cat_save]

		
	@Outbox_id int,
	@Cat_id int ,
	@Type int,
	@Outbox_type int

AS


SET NOCOUNT ON

INSERT INTO [dbo].[Outbox_cat] (	
	
		
	[Outbox_id],
	[Cat_id],
	[Type],
	[Outbox_type]
	
	
	) VALUES (	
	
		
	@Outbox_id,
	@Cat_id,
	@Type,
	@Outbox_type
	

		
	)
	

	
	set @Outbox_id = @@identity


	
	


set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON



go


GO
/****** Object:  StoredProcedure [dbo].[OutboxVisaEmpSelectVisa_Id]    Script Date: 19/04/2015 11:41:32 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[OutboxVisaEmpSelectVisa_Id]

		
	
	@Visa_Id int 
	

AS


SELECT dbo.EMPLOYEE.pmp_name, dbo.Outbox_Visa_Emp.Emp_ID, dbo.Outbox_Visa_Emp.Visa_Id 
FROM  dbo.EMPLOYEE INNER JOIN dbo.Outbox_Visa_Emp ON dbo.EMPLOYEE.PMP_ID = dbo.Outbox_Visa_Emp.Emp_ID 
where dbo.Outbox_Visa_Emp.Visa_Id = @Visa_Id

go


GO
/****** Object:  StoredProcedure [dbo].[OutboxVisaEmpSelectOutboxId]    Script Date: 19/04/2015 11:41:30 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[OutboxVisaEmpSelectOutboxId]

		
	
	@ID int 
	

AS


SELECT dbo.EMPLOYEE.pmp_name, dbo.Outbox_Visa_Emp.Emp_ID, dbo.Outbox_Visa_Emp.Visa_Id 
FROM  dbo.EMPLOYEE INNER JOIN dbo.Outbox_Visa_Emp ON dbo.EMPLOYEE.PMP_ID = dbo.Outbox_Visa_Emp.Emp_ID
 where dbo.Outbox_Visa_Emp.Visa_Id =@ID

 go

 
GO
/****** Object:  StoredProcedure [dbo].[OutboxVisaEmpSelectOutboxId1]    Script Date: 19/04/2015 11:41:28 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[OutboxVisaEmpSelectOutboxId1]

		
	
	@Outbox_Id int 
	

AS


SELECT   distinct EMPLOYEE.PMP_ID, EMPLOYEE.pmp_name, Outbox_Visa.Outbox_ID
                FROM   Outbox_Visa_Emp INNER JOIN  EMPLOYEE ON Outbox_Visa_Emp.Emp_ID = EMPLOYEE.PMP_ID 
                   INNER JOIN  Outbox_Visa ON Outbox_Visa_Emp.Visa_Id = Outbox_Visa.Visa_Id 
                    INNER JOIN  Outbox ON Outbox_Visa.Outbox_ID = Outbox.ID 
                 where Outbox_ID = @Outbox_Id
	 go

	 
GO
/****** Object:  StoredProcedure [dbo].[OutboxVisaEmpSelect]    Script Date: 19/04/2015 11:44:24 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[OutboxVisaEmpSelect]

		
	
	@Visa_Id int 
	

AS


select * from Outbox_Visa_Emp where Visa_Id =@Visa_Id

go


GO
/****** Object:  StoredProcedure [dbo].[outbox_Visa_Select_For_Doc]    Script Date: 19/04/2015 11:58:49 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[outbox_Visa_Select_For_Doc]

	
	@id int
	
	
AS


SELECT
	
	
	*
		
FROM

	[dbo].[Outbox_Visa]
	
WHERE

	[visa_id] = @id
	

	go




















