﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EFModels
{
    using System;
    using System.Collections.Generic;
    
    public partial class Inbox
    {
        public int ID { get; set; }
        public Nullable<int> Proj_id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Date { get; set; }
        public Nullable<int> Type { get; set; }
        public Nullable<int> Dept_ID { get; set; }
        public Nullable<int> Emp_ID { get; set; }
        public Nullable<int> Org_Id { get; set; }
        public string Org_Name { get; set; }
        public string Org_Out_Box_Code { get; set; }
        public string Org_Out_Box_DT { get; set; }
        public string Org_Out_Box_Person { get; set; }
        public string Subject { get; set; }
        public Nullable<int> Related_Type { get; set; }
        public Nullable<int> Related_Id { get; set; }
        public string Notes { get; set; }
        public string Paper_No { get; set; }
        public string Paper_Attached { get; set; }
        public Nullable<int> Follow_Up_Dept_ID { get; set; }
        public Nullable<int> Follow_Up_Emp_ID { get; set; }
        public string Dept_Desc { get; set; }
        public Nullable<int> Source_Type { get; set; }
        public Nullable<int> Status { get; set; }
        public string Org_Dept_Name { get; set; }
        public string Enter_Date { get; set; }
        public Nullable<int> Dept_Dept_ID { get; set; }
        public Nullable<int> Group_id { get; set; }
        public Nullable<int> pmp_pmp_id { get; set; }
        public Nullable<int> sub_Cat_id { get; set; }
        public Nullable<int> finished { get; set; }
        public Nullable<int> foundation_id { get; set; }
    }
}
namespace EFModels
{
    using System;
    using System.Collections.Generic;
    
    public partial class inbox_follow_emp
    {
        public int id { get; set; }
        public Nullable<int> pmp_id { get; set; }
        public Nullable<int> Have_follow { get; set; }
        public Nullable<int> inbox_id { get; set; }
    }
}
namespace EFModels
{
    using System;
    using System.Collections.Generic;
    
    public partial class Inbox_letters
    {
        public int id { get; set; }
        public string import_date { get; set; }
        public string reg__no { get; set; }
        public string export_org_date { get; set; }
        public string import_org { get; set; }
        public string subject { get; set; }
        public string docs_no { get; set; }
        public string import_sub_copy { get; set; }
        public string is_repolied { get; set; }
        public string visa_date { get; set; }
        public string importance_level { get; set; }
        public string exec_responsible { get; set; }
        public string axis_name { get; set; }
        public string visa_text { get; set; }
        public string mandate_name { get; set; }
        public string follow_up_responsible { get; set; }
        public string follow_up_situation { get; set; }
        public string save_file { get; set; }
        public string export_no { get; set; }
        public string export_date { get; set; }
    }
}
namespace EFModels
{
    using System;
    using System.Collections.Generic;
    
    public partial class inbox_Main_Categories
    {
        public int id { get; set; }
        public string Name { get; set; }
        public Nullable<int> group_id { get; set; }
    }
}
namespace EFModels
{
    using System;
    using System.Collections.Generic;
    
    public partial class Inbox_Minister
    {
        public int ID { get; set; }
        public Nullable<int> Proj_id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Date { get; set; }
        public Nullable<int> Type { get; set; }
        public Nullable<int> Dept_ID { get; set; }
        public Nullable<int> Emp_ID { get; set; }
        public Nullable<int> Org_Id { get; set; }
        public string Org_Name { get; set; }
        public string Org_Out_Box_Code { get; set; }
        public string Org_Out_Box_DT { get; set; }
        public string Org_Out_Box_Person { get; set; }
        public string Subject { get; set; }
        public Nullable<int> Related_Type { get; set; }
        public Nullable<int> Related_Id { get; set; }
        public string Notes { get; set; }
        public string Paper_No { get; set; }
        public string Paper_Attached { get; set; }
        public Nullable<int> Follow_Up_Dept_ID { get; set; }
        public Nullable<int> Follow_Up_Emp_ID { get; set; }
        public string Dept_Desc { get; set; }
        public Nullable<int> Source_Type { get; set; }
        public Nullable<int> Status { get; set; }
        public string Org_Dept_Name { get; set; }
        public string Enter_Date { get; set; }
        public Nullable<int> Dept_Dept_ID { get; set; }
        public Nullable<int> Group_id { get; set; }
        public Nullable<int> pmp_pmp_id { get; set; }
        public Nullable<int> sub_Cat_id { get; set; }
    }
}
namespace EFModels
{
    using System;
    using System.Collections.Generic;
    
    public partial class inbox_minister_Type
    {
        public int type_minister_id { get; set; }
        public string name { get; set; }
    }
}
namespace EFModels
{
    using System;
    using System.Collections.Generic;
    
    public partial class Inbox_Minister_Visa
    {
        public int Visa_Id { get; set; }
        public Nullable<int> Inbox_ID { get; set; }
        public string Visa_date { get; set; }
        public Nullable<int> Important_Degree { get; set; }
        public Nullable<int> Dept_ID { get; set; }
        public Nullable<int> Emp_ID { get; set; }
        public string Important_Degree_Txt { get; set; }
        public string Dept_ID_Txt { get; set; }
        public string Emp_ID_Txt { get; set; }
        public string Visa_Desc { get; set; }
        public string Visa_Period { get; set; }
        public Nullable<int> Visa_Satus { get; set; }
        public Nullable<int> Follow_Up_Dept_ID { get; set; }
        public Nullable<int> Follow_Up_Emp_ID { get; set; }
        public string saving_file { get; set; }
        public string Dead_Line_DT { get; set; }
        public Nullable<int> Visa_Goal_ID { get; set; }
        public string Follow_Up_Notes { get; set; }
        public Nullable<int> mail_sent { get; set; }
    }
}
namespace EFModels
{
    using System;
    using System.Collections.Generic;
    
    public partial class Inbox_Minister_Visa_Emp
    {
        public int Visa_Emp_ID { get; set; }
        public Nullable<int> Visa_Id { get; set; }
        public Nullable<int> Emp_ID { get; set; }
    }
}
namespace EFModels
{
    using System;
    using System.Collections.Generic;
    
    public partial class Inbox_Minister_Visa_Follows
    {
        public int Follow_ID { get; set; }
        public Nullable<int> Inbox_ID { get; set; }
        public string Descrption { get; set; }
        public string Date { get; set; }
        public byte[] File_data { get; set; }
        public string File_name { get; set; }
        public string File_ext { get; set; }
        public Nullable<int> Visa_Emp_id { get; set; }
        public Nullable<int> entery_pmp_id { get; set; }
        public string time_follow { get; set; }
        public Nullable<int> Type_Follow { get; set; }
    }
}
namespace EFModels
{
    using System;
    using System.Collections.Generic;
    
    public partial class Inbox_OutBox_Files
    {
        public int Inbox_OutBox_File_ID { get; set; }
        public Nullable<int> Inbox_Outbox_ID { get; set; }
        public Nullable<int> Inbox_Or_Outbox { get; set; }
        public Nullable<int> Original_Or_Attached { get; set; }
        public byte[] File_data { get; set; }
        public string File_name { get; set; }
        public string File_ext { get; set; }
    }
}
namespace EFModels
{
    using System;
    using System.Collections.Generic;
    
    public partial class Inbox_OutBox_Files_new
    {
        public int Inbox_OutBox_File_ID { get; set; }
        public Nullable<int> Inbox_Outbox_ID { get; set; }
        public Nullable<int> Inbox_Or_Outbox { get; set; }
        public Nullable<int> Original_Or_Attached { get; set; }
        public string File_name { get; set; }
        public string File_ext { get; set; }
        public System.Guid inout_id { get; set; }
        public byte[] file_data { get; set; }
    }
}
namespace EFModels
{
    using System;
    using System.Collections.Generic;
    
    public partial class Inbox_Relations
    {
        public int ID { get; set; }
        public Nullable<int> inbox_id { get; set; }
        public Nullable<int> inbox_id_type { get; set; }
        public Nullable<int> Related_ID { get; set; }
        public Nullable<int> Related_ID_Type { get; set; }
        public Nullable<int> foundation_id { get; set; }
    }
}
namespace EFModels
{
    using System;
    using System.Collections.Generic;
    
    public partial class inbox_sub_categories
    {
        public int id { get; set; }
        public string name { get; set; }
        public Nullable<int> main_id { get; set; }
    }
}
namespace EFModels
{
    using System;
    using System.Collections.Generic;
    
    public partial class Inbox_Track_Emp
    {
        public int ID { get; set; }
        public int inbox_id { get; set; }
        public Nullable<int> Emp_ID { get; set; }
        public Nullable<int> Inbox_Status { get; set; }
        public Nullable<int> Type_Track_emp { get; set; }
    }
}
namespace EFModels
{
    using System;
    using System.Collections.Generic;
    
    public partial class Inbox_Track_Manager
    {
        public int inbox_id { get; set; }
        public Nullable<int> status { get; set; }
        public int IS_New_Mail { get; set; }
        public int Have_Follow { get; set; }
        public int Have_Visa { get; set; }
        public string Visa_Desc { get; set; }
        public Nullable<int> IS_Old_Mail { get; set; }
        public Nullable<int> pmp_id { get; set; }
        public Nullable<int> parent_pmp_id { get; set; }
        public Nullable<int> Type_Track { get; set; }
        public Nullable<int> All_visa_sent { get; set; }
    }
}
namespace EFModels
{
    using System;
    using System.Collections.Generic;
    
    public partial class inbox_Type
    {
        public int Type_ID { get; set; }
        public string name { get; set; }
    }
}
namespace EFModels
{
    using System;
    using System.Collections.Generic;
    
    public partial class Inbox_Visa
    {
        public int Visa_Id { get; set; }
        public Nullable<int> Inbox_ID { get; set; }
        public string Visa_date { get; set; }
        public Nullable<int> Important_Degree { get; set; }
        public Nullable<int> Dept_ID { get; set; }
        public Nullable<int> Emp_ID { get; set; }
        public string Important_Degree_Txt { get; set; }
        public string Dept_ID_Txt { get; set; }
        public string Emp_ID_Txt { get; set; }
        public string Visa_Desc { get; set; }
        public string Visa_Period { get; set; }
        public Nullable<int> Visa_Satus { get; set; }
        public Nullable<int> Follow_Up_Dept_ID { get; set; }
        public Nullable<int> Follow_Up_Emp_ID { get; set; }
        public string Follow_Up_Notes { get; set; }
        public string saving_file { get; set; }
        public string Dead_Line_DT { get; set; }
        public Nullable<int> Visa_Goal_ID { get; set; }
        public Nullable<int> mail_sent { get; set; }
        public string Entery_Date { get; set; }
        public byte[] File_data { get; set; }
        public string File_name { get; set; }
        public string File_ext { get; set; }
    }
}
namespace EFModels
{
    using System;
    using System.Collections.Generic;
    
    public partial class Inbox_Visa_Emp
    {
        public int Visa_Emp_ID { get; set; }
        public Nullable<int> Visa_Id { get; set; }
        public Nullable<int> Emp_ID { get; set; }
        public Nullable<int> Sender_ID { get; set; }
    }
}
namespace EFModels
{
    using System;
    using System.Collections.Generic;
    
    public partial class Inbox_Visa_Follows
    {
        public int Follow_ID { get; set; }
        public Nullable<int> Inbox_ID { get; set; }
        public string Descrption { get; set; }
        public string Date { get; set; }
        public byte[] File_data { get; set; }
        public string File_name { get; set; }
        public string File_ext { get; set; }
        public Nullable<int> Visa_Emp_id { get; set; }
        public Nullable<int> entery_pmp_id { get; set; }
        public string time_follow { get; set; }
        public Nullable<int> Type_Follow { get; set; }
        public string Entery_Date { get; set; }
    }
}
namespace EFModels
{
    using System;
    using System.Collections.Generic;
    
    public partial class pmp_fav_View
    {
        public string pmp_name { get; set; }
        public long PMP_ID { get; set; }
        public Nullable<int> employee_id { get; set; }
        public Nullable<long> Dept_Dept_id { get; set; }
        public Nullable<int> sec_sec_id { get; set; }
    }
}
namespace EFModels
{
    using System;
    using System.Collections.Generic;
    
    public partial class vw_inbox_DateSubject
    {
        public int ID { get; set; }
        public Nullable<int> Proj_id { get; set; }
        public string Code { get; set; }
        public string con { get; set; }
        public Nullable<int> Group_id { get; set; }
        public string Date { get; set; }
    }
}
namespace EFModels
{
    using System;
    using System.Collections.Generic;
    
    public partial class vw_outbox_DateString
    {
        public int ID { get; set; }
        public Nullable<int> Proj_id { get; set; }
        public string Code { get; set; }
        public string con { get; set; }
        public Nullable<int> Group_id { get; set; }
        public string Date { get; set; }
    }
}
namespace EFModels
{
    using System;
    using System.Collections.Generic;
    
    public partial class vw_outbox_DateSubject
    {
        public int ID { get; set; }
        public Nullable<int> Proj_id { get; set; }
        public string Code { get; set; }
        public string con { get; set; }
        public Nullable<int> Group_id { get; set; }
        public string Date { get; set; }
    }
}
namespace EFModels
{
    using System;
    
    public partial class Fil_Emp_Visa_Follow_Result
    {
        public long PMP_ID { get; set; }
        public string pmp_name { get; set; }
        public Nullable<int> Inbox_ID { get; set; }
    }
}
namespace EFModels
{
    using System;
    
    public partial class get_data_from_parent_employee
    {
    }
}
namespace EFModels
{
    using System;
    
    public partial class get_employee_accoording_to_radiochek
    {
    }
}
namespace EFModels
{
    using System;
    
    public partial class get_files_by_inbox_id_Result
    {
        public int Inbox_OutBox_File_ID { get; set; }
        public Nullable<int> Inbox_Outbox_ID { get; set; }
        public Nullable<int> Inbox_Or_Outbox { get; set; }
        public Nullable<int> Original_Or_Attached { get; set; }
        public byte[] File_data { get; set; }
        public string File_name { get; set; }
        public string File_ext { get; set; }
    }
}
namespace EFModels
{
    using System;
    
    public partial class get_max_code_inbox
    {
    }
}
namespace EFModels
{
    using System;
    
    public partial class get_related_inbox_inbox_page
    {
    }
}
namespace EFModels
{
    using System;
    
    public partial class get_related_outbox_inbox_page
    {
    }
}
namespace EFModels
{
    using System;
    
    public partial class get_sub_cat_by_main_cat
    {
    }
}
namespace EFModels
{
    using System;
    
    public partial class Get_Visa_Emp
    {
    }
}
namespace EFModels
{
    using System;
    
    public partial class get_visa_follows_for_grid_Result
    {
        public int Follow_ID { get; set; }
        public string Entery_Date { get; set; }
        public string File_name { get; set; }
        public string time_follow { get; set; }
        public Nullable<int> Inbox_ID { get; set; }
        public string Descrption { get; set; }
        public string Date { get; set; }
        public Nullable<int> Visa_Emp_id { get; set; }
        public string pmp_name { get; set; }
    }
}
namespace EFModels
{
    using System;
    
    public partial class Inbox_by_emp_in_visa_Result
    {
        public int Visa_Id { get; set; }
        public Nullable<int> Inbox_ID { get; set; }
        public string Visa_date { get; set; }
        public Nullable<int> Important_Degree { get; set; }
        public Nullable<int> Dept_ID { get; set; }
        public Nullable<int> Emp_ID { get; set; }
        public string Important_Degree_Txt { get; set; }
        public string Dept_ID_Txt { get; set; }
        public string Emp_ID_Txt { get; set; }
        public string Visa_Desc { get; set; }
        public string Visa_Period { get; set; }
        public Nullable<int> Visa_Satus { get; set; }
        public Nullable<int> Follow_Up_Dept_ID { get; set; }
        public Nullable<int> Follow_Up_Emp_ID { get; set; }
        public string Follow_Up_Notes { get; set; }
        public string saving_file { get; set; }
        public string Dead_Line_DT { get; set; }
        public Nullable<int> Visa_Goal_ID { get; set; }
        public Nullable<int> mail_sent { get; set; }
        public Nullable<int> visa_emp { get; set; }
        public string inbox_date { get; set; }
        public string Subject { get; set; }
    }
}
namespace EFModels
{
    using System;
    
    public partial class Inbox_cat_select_Result
    {
        public Nullable<int> inbox_id { get; set; }
        public Nullable<int> Cat_id { get; set; }
        public Nullable<int> Type { get; set; }
        public Nullable<int> inbox_type { get; set; }
    }
}
namespace EFModels
{
    using System;
    
    public partial class inbox_DIrect_Relating_Result
    {
        public Nullable<int> Related_Type { get; set; }
        public string con { get; set; }
    }
}
namespace EFModels
{
    using System;
    
    public partial class inbox_fillcontrol_Result
    {
        public int ID { get; set; }
        public Nullable<int> Proj_id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Date { get; set; }
        public Nullable<int> Type { get; set; }
        public Nullable<int> Dept_ID { get; set; }
        public Nullable<int> Emp_ID { get; set; }
        public Nullable<int> Org_Id { get; set; }
        public string Org_Name { get; set; }
        public string Org_Out_Box_Code { get; set; }
        public string Org_Out_Box_DT { get; set; }
        public string Org_Out_Box_Person { get; set; }
        public string Subject { get; set; }
        public Nullable<int> Related_Type { get; set; }
        public Nullable<int> Related_Id { get; set; }
        public string Notes { get; set; }
        public string Paper_No { get; set; }
        public string Paper_Attached { get; set; }
        public Nullable<int> Follow_Up_Dept_ID { get; set; }
        public Nullable<int> Follow_Up_Emp_ID { get; set; }
        public string Dept_Desc { get; set; }
        public Nullable<int> Source_Type { get; set; }
        public Nullable<int> Status { get; set; }
        public string Org_Dept_Name { get; set; }
        public string Enter_Date { get; set; }
        public Nullable<int> Dept_Dept_ID { get; set; }
        public Nullable<int> Group_id { get; set; }
        public Nullable<int> pmp_pmp_id { get; set; }
        public Nullable<int> sub_Cat_id { get; set; }
        public Nullable<int> finished { get; set; }
        public Nullable<int> foundation_id { get; set; }
        public string Visa_Desc { get; set; }
    }
}
namespace EFModels
{
    using System;
    
    public partial class inbox_get_parent_of_certain_inbox_Result
    {
        public int ID { get; set; }
        public Nullable<int> pmp_pmp_id { get; set; }
        public int parent_pmp_id { get; set; }
        public Nullable<int> foundation_id { get; set; }
    }
}
namespace EFModels
{
    using System;
    
    public partial class inbox_getorg_Result
    {
        public Nullable<int> Org_Id { get; set; }
        public string Org_Desc { get; set; }
    }
}
namespace EFModels
{
    using System;
    
    public partial class Inbox_Minister_Select_Result
    {
        public int ID { get; set; }
        public Nullable<int> Proj_id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Date { get; set; }
        public Nullable<int> Type { get; set; }
        public Nullable<int> Dept_ID { get; set; }
        public Nullable<int> Emp_ID { get; set; }
        public Nullable<int> Org_Id { get; set; }
        public string Org_Name { get; set; }
        public string Org_Out_Box_Code { get; set; }
        public string Org_Out_Box_DT { get; set; }
        public string Org_Out_Box_Person { get; set; }
        public string Subject { get; set; }
        public Nullable<int> Related_Type { get; set; }
        public Nullable<int> Related_Id { get; set; }
        public string Notes { get; set; }
        public string Paper_No { get; set; }
        public string Paper_Attached { get; set; }
        public Nullable<int> Follow_Up_Dept_ID { get; set; }
        public Nullable<int> Follow_Up_Emp_ID { get; set; }
        public string Dept_Desc { get; set; }
        public Nullable<int> Source_Type { get; set; }
        public Nullable<int> Status { get; set; }
        public string Org_Dept_Name { get; set; }
        public string Enter_Date { get; set; }
        public Nullable<int> Dept_Dept_ID { get; set; }
        public Nullable<int> Group_id { get; set; }
        public Nullable<int> pmp_pmp_id { get; set; }
        public Nullable<int> sub_Cat_id { get; set; }
    }
}
namespace EFModels
{
    using System;
    
    public partial class Inbox_Minister_Visa_Follows_Search_Result
    {
        public int Follow_ID { get; set; }
        public Nullable<int> Inbox_ID { get; set; }
        public Nullable<int> Visa_Emp_id { get; set; }
        public Nullable<int> Type_Follow { get; set; }
        public Nullable<int> entery_pmp_id { get; set; }
        public byte[] File_data { get; set; }
        public string Descrption { get; set; }
        public string Date { get; set; }
        public string time_follow { get; set; }
        public string File_name { get; set; }
        public string File_ext { get; set; }
    }
}
namespace EFModels
{
    using System;
    
    public partial class Inbox_Minister_Visa_Follows_Select_For_Doc_Result
    {
        public int Follow_ID { get; set; }
        public Nullable<int> Inbox_ID { get; set; }
        public string Descrption { get; set; }
        public string Date { get; set; }
        public byte[] File_data { get; set; }
        public string File_name { get; set; }
        public string File_ext { get; set; }
        public Nullable<int> Visa_Emp_id { get; set; }
        public Nullable<int> entery_pmp_id { get; set; }
        public string time_follow { get; set; }
        public Nullable<int> Type_Follow { get; set; }
    }
}
namespace EFModels
{
    using System;
    
    public partial class Inbox_Minister_Visa_Follows_Select_Result
    {
        public int Follow_ID { get; set; }
        public Nullable<int> Inbox_ID { get; set; }
        public string Descrption { get; set; }
        public string Date { get; set; }
        public byte[] File_data { get; set; }
        public string File_name { get; set; }
        public string File_ext { get; set; }
        public Nullable<int> Visa_Emp_id { get; set; }
        public Nullable<int> entery_pmp_id { get; set; }
        public string time_follow { get; set; }
        public Nullable<int> Type_Follow { get; set; }
    }
}
namespace EFModels
{
    using System;
    
    public partial class Inbox_Minister_Visa_Select_Result
    {
        public int Visa_Id { get; set; }
        public Nullable<int> Inbox_ID { get; set; }
        public string Visa_date { get; set; }
        public Nullable<int> Important_Degree { get; set; }
        public Nullable<int> Dept_ID { get; set; }
        public Nullable<int> Emp_ID { get; set; }
        public string Important_Degree_Txt { get; set; }
        public string Dept_ID_Txt { get; set; }
        public string Emp_ID_Txt { get; set; }
        public string Visa_Desc { get; set; }
        public string Visa_Period { get; set; }
        public Nullable<int> Visa_Satus { get; set; }
        public Nullable<int> Follow_Up_Dept_ID { get; set; }
        public Nullable<int> Follow_Up_Emp_ID { get; set; }
        public string saving_file { get; set; }
        public string Dead_Line_DT { get; set; }
        public Nullable<int> Visa_Goal_ID { get; set; }
        public string Follow_Up_Notes { get; set; }
        public Nullable<int> mail_sent { get; set; }
    }
}
namespace EFModels
{
    using System;
    
    public partial class inbox_Not_sent_visa_Result
    {
        public int inbox_id { get; set; }
        public Nullable<int> Proj_id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Date { get; set; }
        public string Org_Out_Box_Code { get; set; }
        public Nullable<int> Group_id { get; set; }
        public Nullable<int> pmp_pmp_id { get; set; }
        public string incombination { get; set; }
        public Nullable<int> Type { get; set; }
        public Nullable<int> Emp_ID { get; set; }
        public Nullable<int> Related_Type { get; set; }
        public Nullable<int> Related_Id { get; set; }
        public string Paper_No { get; set; }
        public string Paper_Attached { get; set; }
        public string Org_Dept_Name { get; set; }
        public string outcombination { get; set; }
        public string Org_Desc { get; set; }
        public Nullable<long> Org_Id { get; set; }
        public string Subject { get; set; }
        public string Org_Out_Box_DT { get; set; }
        public string valid_date { get; set; }
        public string out_valid_date { get; set; }
    }
}
namespace EFModels
{
    using System;
    
    public partial class Inbox_OutBox_Files_Select_Result
    {
        public int Inbox_OutBox_File_ID { get; set; }
        public Nullable<int> Inbox_Outbox_ID { get; set; }
        public Nullable<int> Inbox_Or_Outbox { get; set; }
        public Nullable<int> Original_Or_Attached { get; set; }
        public byte[] File_data { get; set; }
        public string File_name { get; set; }
        public string File_ext { get; set; }
    }
}
namespace EFModels
{
    using System;
    
    public partial class inbox_related_Result
    {
        public Nullable<int> id { get; set; }
        public Nullable<int> Related_ID_Type { get; set; }
        public string Subject { get; set; }
    }
}
namespace EFModels
{
    using System;
    
    public partial class inbox_Relating_Result
    {
        public Nullable<int> Related_Type { get; set; }
        public string con { get; set; }
    }
}
namespace EFModels
{
    using System;
    
    public partial class inbox_search_par_2_Result
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Date { get; set; }
        public string Org_Out_Box_Code { get; set; }
        public string incombination { get; set; }
        public string outcombination { get; set; }
        public string Org_Desc { get; set; }
        public string Subject { get; set; }
        public string Org_Out_Box_DT { get; set; }
        public Nullable<System.DateTime> Column1 { get; set; }
        public string valid_date { get; set; }
        public string out_valid_date { get; set; }
    }
}
namespace EFModels
{
    using System;
    
    public partial class inbox_search_par_Result
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Date { get; set; }
        public string Org_Out_Box_Code { get; set; }
        public string incombination { get; set; }
        public string outcombination { get; set; }
        public string Org_Desc { get; set; }
        public string Subject { get; set; }
        public string Org_Out_Box_DT { get; set; }
        public Nullable<System.DateTime> Column1 { get; set; }
        public string valid_date { get; set; }
        public string out_valid_date { get; set; }
    }
}
namespace EFModels
{
    using System;
    
    public partial class Inbox_Select_Result
    {
        public int ID { get; set; }
        public Nullable<int> Proj_id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Date { get; set; }
        public Nullable<int> Type { get; set; }
        public Nullable<int> Dept_ID { get; set; }
        public Nullable<int> Emp_ID { get; set; }
        public Nullable<int> Org_Id { get; set; }
        public string Org_Name { get; set; }
        public string Org_Out_Box_Code { get; set; }
        public string Org_Out_Box_DT { get; set; }
        public string Org_Out_Box_Person { get; set; }
        public string Subject { get; set; }
        public Nullable<int> Related_Type { get; set; }
        public Nullable<int> Related_Id { get; set; }
        public string Notes { get; set; }
        public string Paper_No { get; set; }
        public string Paper_Attached { get; set; }
        public Nullable<int> Follow_Up_Dept_ID { get; set; }
        public Nullable<int> Follow_Up_Emp_ID { get; set; }
        public string Dept_Desc { get; set; }
        public Nullable<int> Source_Type { get; set; }
        public Nullable<int> Status { get; set; }
        public string Org_Dept_Name { get; set; }
        public string Enter_Date { get; set; }
        public Nullable<int> Dept_Dept_ID { get; set; }
        public Nullable<int> Group_id { get; set; }
        public Nullable<int> pmp_pmp_id { get; set; }
        public Nullable<int> sub_Cat_id { get; set; }
        public Nullable<int> finished { get; set; }
        public Nullable<int> foundation_id { get; set; }
    }
}
namespace EFModels
{
    using System;
    
    public partial class Inbox_SelectByOrg_Result
    {
        public int ID { get; set; }
        public Nullable<int> Proj_id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Date { get; set; }
        public Nullable<int> Type { get; set; }
        public Nullable<int> Dept_ID { get; set; }
        public Nullable<int> Emp_ID { get; set; }
        public Nullable<int> Org_Id { get; set; }
        public string Org_Name { get; set; }
        public string Org_Out_Box_Code { get; set; }
        public string Org_Out_Box_DT { get; set; }
        public string Org_Out_Box_Person { get; set; }
        public string Subject { get; set; }
        public Nullable<int> Related_Type { get; set; }
        public Nullable<int> Related_Id { get; set; }
        public string Notes { get; set; }
        public string Paper_No { get; set; }
        public string Paper_Attached { get; set; }
        public Nullable<int> Follow_Up_Dept_ID { get; set; }
        public Nullable<int> Follow_Up_Emp_ID { get; set; }
        public string Dept_Desc { get; set; }
        public Nullable<int> Source_Type { get; set; }
        public Nullable<int> Status { get; set; }
        public string Org_Dept_Name { get; set; }
        public string Enter_Date { get; set; }
        public Nullable<int> Dept_Dept_ID { get; set; }
        public Nullable<int> Group_id { get; set; }
        public Nullable<int> pmp_pmp_id { get; set; }
        public Nullable<int> sub_Cat_id { get; set; }
        public Nullable<int> finished { get; set; }
        public Nullable<int> foundation_id { get; set; }
    }
}
namespace EFModels
{
    using System;
    
    public partial class inbox_sent_visa_Result
    {
        public int inbox_id { get; set; }
        public Nullable<int> Proj_id { get; set; }
        public string proj_title { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Date { get; set; }
        public string Org_Out_Box_Code { get; set; }
        public Nullable<int> Group_id { get; set; }
        public Nullable<int> pmp_pmp_id { get; set; }
        public string incombination { get; set; }
        public Nullable<int> Type { get; set; }
        public Nullable<int> Emp_ID { get; set; }
        public Nullable<int> Related_Type { get; set; }
        public Nullable<int> Related_Id { get; set; }
        public string Paper_No { get; set; }
        public string Paper_Attached { get; set; }
        public string Org_Dept_Name { get; set; }
        public string outcombination { get; set; }
        public string Org_Desc { get; set; }
        public Nullable<long> Org_Id { get; set; }
        public string Subject { get; set; }
        public string Org_Out_Box_DT { get; set; }
        public string valid_date { get; set; }
        public string out_valid_date { get; set; }
    }
}
namespace EFModels
{
    using System;
    
    public partial class Inbox_Track_Manager_Select_Result
    {
        public int inbox_id { get; set; }
        public Nullable<int> status { get; set; }
        public int IS_New_Mail { get; set; }
        public int Have_Follow { get; set; }
        public int Have_Visa { get; set; }
        public Nullable<int> pmp_id { get; set; }
        public Nullable<int> All_visa_sent { get; set; }
        public Nullable<int> parent_pmp_id { get; set; }
        public Nullable<int> Type_Track { get; set; }
        public string Visa_Desc { get; set; }
    }
}
namespace EFModels
{
    using System;
    
    public partial class Inbox_Visa_Follows_Search_Result
    {
        public int Follow_ID { get; set; }
        public Nullable<int> Inbox_ID { get; set; }
        public Nullable<int> Visa_Emp_id { get; set; }
        public Nullable<int> Type_Follow { get; set; }
        public Nullable<int> entery_pmp_id { get; set; }
        public byte[] File_data { get; set; }
        public string Descrption { get; set; }
        public string Date { get; set; }
        public string time_follow { get; set; }
        public string File_name { get; set; }
        public string File_ext { get; set; }
    }
}
namespace EFModels
{
    using System;
    
    public partial class Inbox_Visa_Follows_Select_For_Doc_Result
    {
        public int Follow_ID { get; set; }
        public Nullable<int> Inbox_ID { get; set; }
        public string Descrption { get; set; }
        public string Date { get; set; }
        public byte[] File_data { get; set; }
        public string File_name { get; set; }
        public string File_ext { get; set; }
        public Nullable<int> Visa_Emp_id { get; set; }
        public Nullable<int> entery_pmp_id { get; set; }
        public string time_follow { get; set; }
        public Nullable<int> Type_Follow { get; set; }
        public string Entery_Date { get; set; }
    }
}
namespace EFModels
{
    using System;
    
    public partial class Inbox_Visa_Follows_Select_Result
    {
        public int Follow_ID { get; set; }
        public Nullable<int> Inbox_ID { get; set; }
        public string Descrption { get; set; }
        public string Date { get; set; }
        public byte[] File_data { get; set; }
        public string File_name { get; set; }
        public string File_ext { get; set; }
        public Nullable<int> Visa_Emp_id { get; set; }
        public Nullable<int> entery_pmp_id { get; set; }
        public string time_follow { get; set; }
        public Nullable<int> Type_Follow { get; set; }
        public string Entery_Date { get; set; }
    }
}
namespace EFModels
{
    using System;
    
    public partial class Inbox_Visa_Select_For_Doc_Result
    {
        public int Visa_Id { get; set; }
        public Nullable<int> Inbox_ID { get; set; }
        public string Visa_date { get; set; }
        public Nullable<int> Important_Degree { get; set; }
        public Nullable<int> Dept_ID { get; set; }
        public Nullable<int> Emp_ID { get; set; }
        public string Important_Degree_Txt { get; set; }
        public string Dept_ID_Txt { get; set; }
        public string Emp_ID_Txt { get; set; }
        public string Visa_Desc { get; set; }
        public string Visa_Period { get; set; }
        public Nullable<int> Visa_Satus { get; set; }
        public Nullable<int> Follow_Up_Dept_ID { get; set; }
        public Nullable<int> Follow_Up_Emp_ID { get; set; }
        public string Follow_Up_Notes { get; set; }
        public string saving_file { get; set; }
        public string Dead_Line_DT { get; set; }
        public Nullable<int> Visa_Goal_ID { get; set; }
        public Nullable<int> mail_sent { get; set; }
        public string Entery_Date { get; set; }
        public byte[] File_data { get; set; }
        public string File_name { get; set; }
        public string File_ext { get; set; }
    }
}
namespace EFModels
{
    using System;
    
    public partial class Inbox_Visa_Select_Result
    {
        public int Visa_Id { get; set; }
        public Nullable<int> Inbox_ID { get; set; }
        public string Visa_date { get; set; }
        public Nullable<int> Important_Degree { get; set; }
        public Nullable<int> Dept_ID { get; set; }
        public Nullable<int> Emp_ID { get; set; }
        public string Important_Degree_Txt { get; set; }
        public string Dept_ID_Txt { get; set; }
        public string Emp_ID_Txt { get; set; }
        public string Visa_Desc { get; set; }
        public string Visa_Period { get; set; }
        public Nullable<int> Visa_Satus { get; set; }
        public Nullable<int> Follow_Up_Dept_ID { get; set; }
        public Nullable<int> Follow_Up_Emp_ID { get; set; }
        public string Follow_Up_Notes { get; set; }
        public string saving_file { get; set; }
        public string Dead_Line_DT { get; set; }
        public Nullable<int> Visa_Goal_ID { get; set; }
        public Nullable<int> mail_sent { get; set; }
        public string Entery_Date { get; set; }
        public byte[] File_data { get; set; }
        public string File_name { get; set; }
        public string File_ext { get; set; }
    }
}
namespace EFModels
{
    using System;
    
    public partial class inboxinside_data_Result
    {
        public int ID { get; set; }
        public Nullable<int> Type { get; set; }
        public Nullable<long> Org_Id { get; set; }
        public string Dept_name { get; set; }
        public Nullable<long> Sec_sec_id { get; set; }
    }
}
