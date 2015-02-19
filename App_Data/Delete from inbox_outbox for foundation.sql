declare @foundation_id int
set @foundation_id  = 0




delete from dbo.inbox_follow_emp 
where inbox_id in (select id from inbox 
where foundation_id = @foundation_id) 

delete  from dbo.Inbox_Track_Emp where inbox_id in (select id from inbox 
where foundation_id = @foundation_id) 


delete  from dbo.Inbox_Track_Manager where inbox_id in (select id from inbox 
where foundation_id = @foundation_id) 


delete  from dbo.Inbox_Visa where inbox_id in (select id from inbox 
where foundation_id = @foundation_id) 

delete  from dbo.Inbox_Visa_Follows where inbox_id in (select id from inbox 
where foundation_id = @foundation_id) 


delete  from inbox where foundation_id = @foundation_id


---------------------------------

delete   from dbo.outbox_follow_emp 
where outbox_id in (select id from outbox 
where foundation_id = @foundation_id) 

delete    from dbo.outbox_Track_Emp where outbox_id in (select id from outbox 
where foundation_id = @foundation_id) 


delete    from dbo.outbox_Track_Manager where outbox_id in (select id from outbox 
where foundation_id = @foundation_id) 


delete    from dbo.outbox_Visa where outbox_id in (select id from outbox 
where foundation_id = @foundation_id) 

delete    from dbo.outbox_Visa_Follows where outbox_id in (select id from outbox 
where foundation_id = @foundation_id) 

delete   from outbox where foundation_id = @foundation_id

--------------------------------------------------
delete   from Commission_follow_emp
where Commission_id  in (select Commission_id  from Commission
where foundation_id = @foundation_id) 

delete      from Commission_Track_Emp where Commission_id  in (select Commission_id  from Commission
where foundation_id = @foundation_id) 

delete      from Commission_Visa where Commission_id  in (select Commission_id  from Commission
where foundation_id = @foundation_id) 

delete  from dbo.Commission_Visa_Follows where Commission_id  in (select Commission_id  from Commission
where foundation_id = @foundation_id) 

delete     from Commission where foundation_id = @foundation_id


----------------------------------------------
--delete from users where pmp_pmp_id in (select pmp_id from employee 
--where foundation_id = @foundation_id) 

--delete from employee 
--where foundation_id = @foundation_id

--delete from Departments
--where foundation_id = @foundation_id

----------------------------------
--delete from Foundations
--where Foundation_ID = @foundation_id
---------------------------------
