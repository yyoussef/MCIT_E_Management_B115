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
    
    public partial class Outbox
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
    
    public partial class Outbox_follow_emp
    {
        public int id { get; set; }
        public Nullable<int> pmp_id { get; set; }
        public Nullable<int> Have_follow { get; set; }
        public Nullable<int> Outbox_id { get; set; }
    }
}
namespace EFModels
{
    using System;
    using System.Collections.Generic;
    
    public partial class Outbox_Main_Categories
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
    
    public partial class Outbox_Sub_Categories
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
    
    public partial class Outbox_Track_Emp
    {
        public int ID { get; set; }
        public int Outbox_id { get; set; }
        public Nullable<int> Emp_ID { get; set; }
        public Nullable<int> Outbox_Status { get; set; }
        public Nullable<int> Type_Track_emp { get; set; }
    }
}
namespace EFModels
{
    using System;
    using System.Collections.Generic;
    
    public partial class Outbox_Track_Manager
    {
        public int Outbox_id { get; set; }
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
    
    public partial class Outbox_Visa
    {
        public int Visa_Id { get; set; }
        public Nullable<int> Outbox_ID { get; set; }
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
        public byte[] File_data { get; set; }
        public string File_name { get; set; }
        public string File_ext { get; set; }
    }
}
namespace EFModels
{
    using System;
    using System.Collections.Generic;
    
    public partial class Outbox_Visa_Emp
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
    
    public partial class Outbox_Visa_Follows
    {
        public int Follow_ID { get; set; }
        public Nullable<int> Outbox_ID { get; set; }
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
    
    public partial class outbox_cat_select_Result
    {
        public Nullable<int> outbox_id { get; set; }
        public Nullable<int> Cat_id { get; set; }
        public Nullable<int> Type { get; set; }
        public Nullable<int> outbox_type { get; set; }
    }
}
namespace EFModels
{
    using System;
    
    public partial class Outbox_DIrect_Relating_Result
    {
        public Nullable<int> Related_Type { get; set; }
        public string con { get; set; }
    }
}
namespace EFModels
{
    using System;
    
    public partial class Outbox_fillcontrol_Result
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
    
    public partial class Outbox_getorg_Result
    {
        public Nullable<int> Org_Id { get; set; }
        public string Org_Desc { get; set; }
    }
}
namespace EFModels
{
    using System;
    
    public partial class Outbox_search_par_Result
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Date { get; set; }
        public string Org_Desc { get; set; }
        public string Subject { get; set; }
        public Nullable<System.DateTime> valid_date { get; set; }
    }
}
namespace EFModels
{
    using System;
    
    public partial class Outbox_Select_Result
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
    
    public partial class Outbox_SelectByOrg_Result
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
    
    public partial class Outbox_Track_Manager_Select_Result
    {
        public int Outbox_id { get; set; }
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
    
    public partial class Outbox_Visa_Follows_Search_Result
    {
        public int Follow_ID { get; set; }
        public Nullable<int> Outbox_ID { get; set; }
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
    
    public partial class Outbox_Visa_Follows_Select_For_Doc_Result
    {
        public int Follow_ID { get; set; }
        public Nullable<int> Outbox_ID { get; set; }
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
    
    public partial class Outbox_Visa_Follows_Select_Result
    {
        public int Follow_ID { get; set; }
        public Nullable<int> Outbox_ID { get; set; }
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
    
    public partial class outbox_Visa_Select_For_Doc_Result
    {
        public int Visa_Id { get; set; }
        public Nullable<int> Outbox_ID { get; set; }
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
        public byte[] File_data { get; set; }
        public string File_name { get; set; }
        public string File_ext { get; set; }
    }
}
namespace EFModels
{
    using System;
    
    public partial class Outbox_Visa_Select_Result
    {
        public int Visa_Id { get; set; }
        public Nullable<int> Outbox_ID { get; set; }
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
        public byte[] File_data { get; set; }
        public string File_name { get; set; }
        public string File_ext { get; set; }
    }
}
namespace EFModels
{
    using System;
    
    public partial class OutboxInbox_SelectByOrg_Result
    {
        public int ID { get; set; }
        public Nullable<int> Proj_id { get; set; }
        public Nullable<int> Org_Id { get; set; }
    }
}
namespace EFModels
{
    using System;
    
    public partial class outboxinside_data_Result
    {
        public int ID { get; set; }
        public Nullable<int> Proj_id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Date { get; set; }
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
        public string Org_Out_Box_Code { get; set; }
        public string outcombination { get; set; }
        public string Org_Desc { get; set; }
        public Nullable<long> Org_Id { get; set; }
        public string Subject { get; set; }
        public string Org_Out_Box_DT { get; set; }
        public string valid_date { get; set; }
        public string out_valid_date { get; set; }
        public Nullable<int> Dept_Dept_ID { get; set; }
        public Nullable<int> finished { get; set; }
        public string notes { get; set; }
        public Nullable<int> foundation_id { get; set; }
        public string Dept_name { get; set; }
        public Nullable<long> Sec_sec_id { get; set; }
    }
}
namespace EFModels
{
    using System;
    
    public partial class OutboxVisaEmpSelect_Result
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
    
    public partial class OutboxVisaEmpSelectOutboxId_Result
    {
        public string pmp_name { get; set; }
        public Nullable<int> Emp_ID { get; set; }
        public Nullable<int> Visa_Id { get; set; }
    }
}
namespace EFModels
{
    using System;
    
    public partial class OutboxVisaEmpSelectOutboxId1_Result
    {
        public long PMP_ID { get; set; }
        public string pmp_name { get; set; }
        public Nullable<int> Outbox_ID { get; set; }
    }
}
namespace EFModels
{
    using System;
    
    public partial class OutboxVisaEmpSelectVisa_Id_Result
    {
        public string pmp_name { get; set; }
        public Nullable<int> Emp_ID { get; set; }
        public Nullable<int> Visa_Id { get; set; }
    }
}
namespace EFModels
{
    using System;
    
    public partial class SP_vw_outbox_DateSubject_Result
    {
        public int ID { get; set; }
        public Nullable<int> Proj_id { get; set; }
        public string Code { get; set; }
        public string con { get; set; }
        public Nullable<int> Group_id { get; set; }
        public string Date { get; set; }
        public Nullable<System.DateTime> date1 { get; set; }
    }
}
