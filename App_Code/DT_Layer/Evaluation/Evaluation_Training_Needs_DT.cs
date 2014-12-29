using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Evaluation_Training_Needs_DT
/// </summary>
public class Evaluation_Training_Needs_DT
{
	  public enum EnumInfo_Training_Needs
        {
            Id, Evaluation_id, Name, Direct_Emp_Note, Eval_Course_Id, Top_Emp_Note, 
        }

        

        public Int32 Id ;

        public Int32 Evaluation_id ;
    
        public String Name ;

        public String Direct_Emp_Note;

        public Int32 Eval_Course_Id;

        public String Top_Emp_Note ;
    }

