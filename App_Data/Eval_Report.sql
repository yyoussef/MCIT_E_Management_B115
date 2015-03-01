SELECT DISTINCT 
                      EMPLOYEE.pmp_name, EMPLOYEE.job_no,EMPLOYEE_1.pmp_name AS Manager_name ,
                       Evaluation_For_Employee.Direct_Mng_Eval, 
                       
                      
                    (SELECT     t1.pmp_name
FROM         Employee_Managers INNER JOIN
                      EMPLOYEE as t1 ON Employee_Managers.Mngr_Emp_ID = t1.PMP_ID
                      where Employee_Managers.Mngr_Level =2 and Employee_Managers.Emp_ID= EMPLOYEE.pmp_id) as Top_Manager_Name
                       ,Evaluation_For_Employee.Top_Mng_Eval, 
                      Evaluation_For_Employee.Final_Eval_Degree

FROM         EMPLOYEE INNER JOIN
                      Evaluation_For_Employee ON EMPLOYEE.PMP_ID = Evaluation_For_Employee.Pmp_Id INNER JOIN
                      Employee_Managers ON EMPLOYEE.PMP_ID = Employee_Managers.Emp_ID INNER JOIN
                      EMPLOYEE AS EMPLOYEE_1 ON Employee_Managers.Mngr_Emp_ID = EMPLOYEE_1.PMP_ID
WHERE     (EMPLOYEE.Dept_Dept_id = 310) AND (Employee_Managers.Mngr_Level = 1)