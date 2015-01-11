declare @migrate_required_sec int;
set @migrate_required_sec=14;
declare @new_sec_id int;
set @new_sec_id = 19
--set @new_sec_id=(select MAX(sec_id) from Sectors);
declare @New_dept_id int;
set @New_dept_id = 310
--set @New_dept_id=(select MAX(dept_id) from Departments);
declare @maxemp_id int;
set @maxemp_id =  (select  isnull(max(PMP_ID),0) from dbo.EMPLOYEE);
-------------------------------------------------------
--set identity_insert dbo.Sectors on 
--insert into dbo.Sectors(Sec_id,Sec_name,foundation_id) 
--select SectorID+@new_sec_id,SectorName,1
-- from  dbo.Web_Sectors where SectorID=@migrate_required_sec
--set identity_insert dbo.Sectors off
----------------------------------------------------
--set identity_insert dbo.departments on 
--insert into dbo.Departments(Dept_id,Dept_name,Dept_parent_id,Dept_type,Sec_sec_id) 
--select DepartmentID+@New_dept_id,DepartmentName,0,0,Sector_ID+@new_sec_id
-- from  dbo.Web_Department where Sector_ID=@migrate_required_sec
--set identity_insert dbo.Departments off
-------------------------------------------------



insert into dbo.EMPLOYEE(PMP_ID,Dept_Dept_id,pmp_name,rol_rol_id,mail,Group_id,vacation_mng_pmp_id,
contact_person,status,sec_sec_id,Hire_date,pmp_title,job_no,direct_manager,higher_manager,Report_dept_manage,
workstatus,
category,university_degree,university_name,major,Token_User_pin,job_title_id,
foundation_id)

select EmployeeID+@maxemp_id,@New_dept_id,
EmployeeName,
0,EmailAddress,
0
,0 
,null,0,@new_sec_id,null,JobTypeName,EmployeeNumber,
0,0,

null,case WorkingStateChar when 'W' then 1 else 4 end,0,null,null,null,null
,null,1 from dbo.Employees left outer join Job_Types on Job_Types.JobTypeID=employees.JobTypeID
where
Web_EmpSectDeptID=47
-- DepartmentID=22


---------------------------------------------------------------
 update EMPLOYEE set mail=job_no+'@mcit.gov.eg' where mail is null or mail='' and Dept_Dept_id=@New_dept_id
-------------------------------------------------------------------
update dbo.EMPLOYEE set mail=t2.mail
,Hire_date=t2.Hire_date,pmp_title=t2.pmp_title,

category=t2.category,university_degree=t2.university_degree,university_name=t2.university_name,major=t2.major
,job_title_id=t2.job_title_id


from dbo.EMPLOYEE t1  inner join EMPLOYEE_3012bak t2 on t1.job_no=t2.job_no
where t1.Dept_Dept_id=@New_dept_id






