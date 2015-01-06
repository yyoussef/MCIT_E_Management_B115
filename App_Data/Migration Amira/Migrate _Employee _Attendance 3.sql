declare @Dept_Dept_id int
set @Dept_Dept_id = 310


update
EMPLOYEE
set Token_User_pin = 11111
where Token_User_pin = 22222 and job_no not in (select job_no from
EMPLOYEE
where Token_User_pin = 11111)

--select * from EMPLOYEE where Token_User_pin = 11111
DELETE from EMPLOYEE where Token_User_pin = 22222
update EMPLOYEE set Token_User_pin = NULL
delete from Users where pmp_pmp_id not in (select pmp_id from EMPLOYEE)


insert into dbo.Users(USR_ID, USR_Name, USR_Pass, pmp_pmp_id, UROL_UROL_ID, System_ID, account_active)

select PMP_ID+5000,substring(mail,0,LEN(mail) - CHARINDEX('@',reverse(mail))+1) as USR_Name,
'1234',PMP_ID,0,0,'true'
 from dbo.Employee where Dept_Dept_id=@Dept_Dept_id and pmp_id not in (select pmp_pmp_id from Users)


