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
    
    public partial class CommissionContext : DbContext
    {
        public CommissionContext()
            : base("name=CommissionContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Commission> Commissions { get; set; }
        public virtual DbSet<Commission_Files> Commission_Files { get; set; }
        public virtual DbSet<Commission_Track_Emp> Commission_Track_Emp { get; set; }
        public virtual DbSet<Commission_Visa> Commission_Visa { get; set; }
        public virtual DbSet<Commission_Visa_Emp> Commission_Visa_Emp { get; set; }
        public virtual DbSet<Commission_Visa_Follows> Commission_Visa_Follows { get; set; }
        public virtual DbSet<Commission_follow_emp> Commission_follow_emp { get; set; }
    
        public virtual ObjectResult<get_Visa_Follow_Result> get_Visa_Follow(Nullable<int> commission_ID)
        {
            var commission_IDParameter = commission_ID.HasValue ?
                new ObjectParameter("Commission_ID", commission_ID) :
                new ObjectParameter("Commission_ID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<get_Visa_Follow_Result>("get_Visa_Follow", commission_IDParameter);
        }
    
        public virtual ObjectResult<get_comm_infor_formail_Result> get_comm_infor_formail(Nullable<int> commission_ID)
        {
            var commission_IDParameter = commission_ID.HasValue ?
                new ObjectParameter("Commission_ID", commission_ID) :
                new ObjectParameter("Commission_ID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<get_comm_infor_formail_Result>("get_comm_infor_formail", commission_IDParameter);
        }
    
        public virtual ObjectResult<string> get_commission_visa_emp(Nullable<int> visa_Id)
        {
            var visa_IdParameter = visa_Id.HasValue ?
                new ObjectParameter("Visa_Id", visa_Id) :
                new ObjectParameter("Visa_Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("get_commission_visa_emp", visa_IdParameter);
        }
    
        public virtual ObjectResult<Fil_Visa_foremployee_Result> Fil_Visa_foremployee(Nullable<int> visa_Id)
        {
            var visa_IdParameter = visa_Id.HasValue ?
                new ObjectParameter("Visa_Id", visa_Id) :
                new ObjectParameter("Visa_Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Fil_Visa_foremployee_Result>("Fil_Visa_foremployee", visa_IdParameter);
        }
    }
}
