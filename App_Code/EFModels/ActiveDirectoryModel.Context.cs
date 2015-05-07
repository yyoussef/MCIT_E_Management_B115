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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class ActiveDirectoryContext : DbContext
    {
        public ActiveDirectoryContext()
            : base("name=ActiveDirectoryContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<EMPLOYEE> EMPLOYEEs { get; set; }
        public virtual DbSet<Foundation> Foundations { get; set; }
        public virtual DbSet<Organization> Organizations { get; set; }
        public virtual DbSet<Site_Upload> Site_Upload { get; set; }
        public virtual DbSet<parent_employee> parent_employee { get; set; }
    
        public virtual ObjectResult<Foundations_Followup_Result> Foundations_Followup(Nullable<int> foundation_id)
        {
            var foundation_idParameter = foundation_id.HasValue ?
                new ObjectParameter("foundation_id", foundation_id) :
                new ObjectParameter("foundation_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Foundations_Followup_Result>("Foundations_Followup", foundation_idParameter);
        }
    
        public virtual ObjectResult<get_employee_from_Outbox_Visa_Follows_Result> get_employee_from_Outbox_Visa_Follows(Nullable<int> outbox_ID)
        {
            var outbox_IDParameter = outbox_ID.HasValue ?
                new ObjectParameter("Outbox_ID", outbox_ID) :
                new ObjectParameter("Outbox_ID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<get_employee_from_Outbox_Visa_Follows_Result>("get_employee_from_Outbox_Visa_Follows", outbox_IDParameter);
        }
    
        public virtual ObjectResult<fill_employee2_Result> fill_employee2(Nullable<int> dept_id)
        {
            var dept_idParameter = dept_id.HasValue ?
                new ObjectParameter("Dept_id", dept_id) :
                new ObjectParameter("Dept_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<fill_employee2_Result>("fill_employee2", dept_idParameter);
        }
    
        public virtual ObjectResult<get_org_by_found_Result> get_org_by_found(Nullable<int> found_id)
        {
            var found_idParameter = found_id.HasValue ?
                new ObjectParameter("found_id", found_id) :
                new ObjectParameter("found_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<get_org_by_found_Result>("get_org_by_found", found_idParameter);
        }
    
        public virtual ObjectResult<get_dept_by_found_Result> get_dept_by_found(Nullable<int> found_id)
        {
            var found_idParameter = found_id.HasValue ?
                new ObjectParameter("found_id", found_id) :
                new ObjectParameter("found_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<get_dept_by_found_Result>("get_dept_by_found", found_idParameter);
        }
    
        public virtual ObjectResult<get_sub_cat_by_main_cat_Result> get_sub_cat_by_main_cat(Nullable<int> cat_id)
        {
            var cat_idParameter = cat_id.HasValue ?
                new ObjectParameter("cat_id", cat_id) :
                new ObjectParameter("cat_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<get_sub_cat_by_main_cat_Result>("get_sub_cat_by_main_cat", cat_idParameter);
        }
    }
}
