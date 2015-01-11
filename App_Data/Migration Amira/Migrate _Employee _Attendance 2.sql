DECLARE @New_dept_id int ,@Sec_id int
set @New_dept_id = 310
set @Sec_id = 19

DECLARE @Pmp_Id int ,@job_no int,@sec_sec_id int,@group_id int,@mail NVARCHAR(MAX),@dept_dept_id int
DECLARE @DynamicSQL NVARCHAR(MAX)
Declare New_dept_emp CURSOR  FOR 
Select Pmp_Id,job_no,sec_sec_id,group_id,mail,dept_dept_id from employee
where dept_dept_id = @New_dept_id order by Pmp_Id asc

OPEN New_dept_emp 


FETCH NEXT FROM New_dept_emp INTO @Pmp_Id,@job_no,@sec_sec_id,@group_id ,@mail ,@dept_dept_id 
WHILE @@FETCH_STATUS = 0 
BEGIN

 Declare @DynamicSQLUpdate nvarchar(max) ,@pmp_id_updated int ,
 @sec_sec_id_updated int,@group_id_updated int,@mail_updated NVARCHAR(max),@dept_dept_id_updated int ,
  @Query_General_emp nvarchar(max) ,@ParmDefinition NVARCHAR(max)

                        set @Query_General_emp  = ' select @pmp_id_updated =  pmp_id '+
													' , @sec_sec_id_updated = sec_sec_id ,@group_id_updated = group_id ,@mail_updated=mail ,@dept_dept_id_updated = dept_dept_id  ' +
                                                   ' from employee WHERE job_no ='+cast( @job_no  as VARCHAR(1000))+' and dept_dept_id <>'+cast( @New_dept_id  as VARCHAR(1000));
                        SET @ParmDefinition = N' @pmp_id_updated int OUTPUT ,@sec_sec_id_updated int OUTPUT ,@group_id_updated int OUTPUT,@mail_updated nvarchar(max) OUTPUT,@dept_dept_id_updated int OUTPUT '
                        
                        
                        EXEC SP_EXECUTESQL @Query_General_emp ,
                   @ParmDefinition,
                   @pmp_id_updated = @pmp_id_updated OUTPUT ,
                   @sec_sec_id_updated  =@sec_sec_id_updated OUTPUT ,
                   @group_id_updated = @group_id_updated OUTPUT ,
                   @mail_updated = @mail_updated OUTPUT ,
                   @dept_dept_id_updated = @dept_dept_id_updated OUTPUT 
                          
             --  print        @pmp_id_updated   
--print cast( @Sec_ID  as VARCHAR(1000))

 if( @pmp_id_updated    >0)
 begin
 set @DynamicSQLUpdate = ' update employee set '+
						 'sec_sec_id ='+cast( @Sec_id   as VARCHAR(max))+  ',' +
						 'mail = '''+cast( @mail   as VARCHAR(max))+  ''', dept_dept_id ='+cast( @dept_dept_id   as VARCHAR(max))+ 
						 ' , Token_User_pin = 11111 ' +
						 ' WHERE pmp_id ='+cast( @pmp_id_updated   as VARCHAR(1000))+' ;'+
						 ' update employee set Token_User_pin = 22222 ' +
						 ' WHERE pmp_id ='+cast( @Pmp_Id   as VARCHAR(1000))
						 

--print @job_no

--print @DynamicSQLUpdate
EXEC SP_EXECUTESQL @DynamicSQLUpdate

 
 end
               
          
FETCH NEXT FROM New_dept_emp INTO @Pmp_Id,@job_no,@sec_sec_id,@group_id ,@mail ,@dept_dept_id 
END 

CLOSE New_dept_emp
DEALLOCATE New_dept_emp



