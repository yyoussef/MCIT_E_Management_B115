


go

/****** Object:  Table [dbo].[Training_Plan]    Script Date: 12/11/2014 15:07:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Training_Plan](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[course_id] [int] NULL,
	[emp_id] [int] NULL,
	[isapproved] [int] NULL,
 CONSTRAINT [PK_Training_Plan] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
go
ALTER TABLE dbo.Project
ADD  project_cause nvarchar(max)
 
go

go
ALTER TABLE dbo.Project
ADD  project_innovation nvarchar(max)
 
go


alter table dbo.project_Achievements 
alter column ach_desc nvarchar(max)
go

alter table dbo.project_gov 
alter column gov_notes nvarchar(max)
go

GO

/****** Object:  StoredProcedure [dbo].[Training_Plan_Save]    Script Date: 12/11/2014 15:11:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Training_Plan_Save]

	
	@id int OUTPUT,
	@course_id int,
	@emp_id int,
	@isapproved int
	
AS

BEGIN



IF  (@id > 0 ) 


BEGIN


	UPDATE [dbo].[Training_Plan] SET
		
		
	[course_id] = @course_id,
	[emp_id] = @emp_id,
	[isapproved] = @isapproved	
		
	WHERE
		
		[id] = @id				
	
END

ELSE

BEGIN
	
	INSERT INTO [dbo].[Training_Plan] (	
	
		
	[course_id],
	[emp_id],
	[isapproved]			
		
	) VALUES (	
	
		
	@course_id,
	@emp_id,
	@isapproved
		
	)
	

	
	set @id = @@identity

END

END
	


set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON


GO

GO

/****** Object:  StoredProcedure [dbo].[Training_Plan_Select]    Script Date: 12/11/2014 15:12:16 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Training_Plan_Select]

	
	@id int
	
	
AS


IF  (@id > 0 ) 


BEGIN

SELECT
	
	*
		
FROM

	[dbo].[Training_Plan]
	
WHERE

	[id] = @id
	
END

	ELSE IF @id = 0

BEGIN

SELECT

	*
	
FROM

	[dbo].[Training_Plan] Order By id DESC	
	
END


set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON



GO
GO

/****** Object:  StoredProcedure [dbo].[Training_Plan_Delete]    Script Date: 12/11/2014 15:12:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Training_Plan_Delete]

		
	@id int

AS




DELETE FROM [dbo].Training_Plan

WHERE
	
	[id] = @id


	
	


GO

GO

/****** Object:  StoredProcedure [dbo].[Training_Plan_course_select]    Script Date: 12/11/2014 15:12:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

 CREATE  procedure [dbo].[Training_Plan_course_select]
 @emp_id int
 as
  select 
  dbo.Training_Plan.course_id ,dbo.Training_Plan.emp_id ,dbo.Training_Plan.isapproved,
  dbo.Courses.course_name
  
  from dbo.Training_Plan
  inner join dbo.Courses on dbo.Courses.course_id=dbo.Training_Plan.course_id 
  where dbo.Training_Plan.emp_id=@emp_id and dbo.Training_Plan.isapproved=0
GO

GO

/****** Object:  StoredProcedure [dbo].[Training_Plan_apprevedcourse_select]    Script Date: 12/11/2014 15:13:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

 create  procedure [dbo].[Training_Plan_apprevedcourse_select]
 @emp_id int
 as
  select 
  dbo.Training_Plan.course_id ,dbo.Training_Plan.emp_id ,dbo.Training_Plan.isapproved,
  dbo.Courses.course_name
  
  from dbo.Training_Plan
  inner join dbo.Courses on dbo.Courses.course_id=dbo.Training_Plan.course_id 
  where dbo.Training_Plan.emp_id=@emp_id and dbo.Training_Plan.isapproved=1
GO

GO

/****** Object:  StoredProcedure [dbo].[Training_Plan_mangerselect]    Script Date: 12/11/2014 15:13:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE procedure [dbo].[Training_Plan_mangerselect]
@emp_id int
as
select distinct dbo.Training_Plan.emp_id,EMPLOYEE.vacation_mng_pmp_id

from dbo.Training_Plan inner join dbo.EMPLOYEE 
on  dbo.Training_Plan.emp_id = EMPLOYEE.PMP_ID 
where dbo.EMPLOYEE.vacation_mng_pmp_id=@emp_id  and dbo.Training_Plan.isapproved=0 
and dbo.Training_Plan.emp_id not in (select dbo.Training_Plan.emp_id from dbo.Training_Plan where dbo.Training_Plan.isapproved=1 )
GO

GO

/****** Object:  UserDefinedFunction [dbo].[project_all_achievments]    Script Date: 12/14/2014 09:55:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE function [dbo].[project_all_achievments](@proj_id int)
returns nvarchar(max) as
begin
declare	@achiev nvarchar(max)
set	@achiev = ''
select	@achiev = @achiev + ' ــ ' + ach_desc
from(SELECT top(4) dbo.project_Achievements.ach_desc from dbo.project_Achievements 

where dbo.project_Achievements.Proj_id in (select proj_id from  dbo.project_Achievements

where proj_id=@proj_id  )) TopValues
return	@achiev 
end



GO

GO

/****** Object:  UserDefinedFunction [dbo].[project_all_constraints]    Script Date: 12/14/2014 09:56:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE function [dbo].[project_all_constraints](@proj_id int)
returns nvarchar(max) as
begin
declare	@cons nvarchar(max)
set	@cons = ''
select	@cons = @cons + ' ــ ' + PCONS_DESC
from(SELECT top(4) dbo.Project_Constraints.PCONS_DESC from  dbo.Project_Constraints

where dbo.Project_Constraints.PActv_PActv_ID in (select PActv_ID from  dbo.Project_Activities

where Project_Activities.proj_proj_id=@proj_id and dbo.Project_Constraints.PActv_PActv_ID=Project_Activities.PActv_ID )) TopValues
return	@cons 
end

GO

GO

/****** Object:  UserDefinedFunction [dbo].[project_all_geoscope]    Script Date: 12/14/2014 09:56:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE function [dbo].[project_all_geoscope](@proj_id int)
returns nvarchar(max) as
begin
declare	@gov_notes nvarchar(max)
set	@gov_notes = ''
select	@gov_notes = @gov_notes + ' ــ ' + gov_notes
from(SELECT  top(4) dbo.project_gov.gov_notes from dbo.project_gov

where dbo.project_gov.Proj_id in (select proj_id from  dbo.project_gov

where proj_id=@proj_id  )) TopValues
return	@gov_notes
end

GO

ALTER TABLE dbo.Outbox_Visa
ADD  File_data varbinary(MAX)
 
go

ALTER TABLE dbo.Outbox_Visa
ADD  File_name nvarchar(1000)
 
go

ALTER TABLE dbo.Outbox_Visa
ADD  File_ext nvarchar(250)
 
go


