delete
FROM            Employee_Managers
where Emp_ID in (
 select pmp_id from 
                         EMPLOYEE 

						 where Dept_Dept_id = 310)