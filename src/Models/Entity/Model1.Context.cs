﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LibraryManagementSystem.Models.Entity
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class DBKUTUPHANEEntities : DbContext
    {
        public DBKUTUPHANEEntities()
            : base("name=DBKUTUPHANEEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AUTHOR> AUTHOR { get; set; }
        public virtual DbSet<BOOK> BOOK { get; set; }
        public virtual DbSet<CASHBOX> CASHBOX { get; set; }
        public virtual DbSet<CATEGORY> CATEGORY { get; set; }
        public virtual DbSet<LOANS> LOANS { get; set; }
        public virtual DbSet<PUNISHMENT> PUNISHMENT { get; set; }
        public virtual DbSet<STAFF> STAFF { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<USER> USER { get; set; }
        public virtual DbSet<ABOUTUS> ABOUTUS { get; set; }
        public virtual DbSet<CONTACTUS> CONTACTUS { get; set; }
    
        public virtual ObjectResult<string> authormostbooks()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("authormostbooks");
        }
    }
}
