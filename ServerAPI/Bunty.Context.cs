﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServerAPI
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class cdbmsEntities : DbContext
    {
        public cdbmsEntities()
            : base("name=cdbmsEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<category> categories { get; set; }
        public DbSet<item> items { get; set; }
        public DbSet<menu> menus { get; set; }
        public DbSet<bill> bills { get; set; }
        public DbSet<inventory> inventories { get; set; }
        public DbSet<inventory_backup> inventory_backup { get; set; }
        public DbSet<kot> kots { get; set; }
        public DbSet<kot_backup> kot_backup { get; set; }
        public DbSet<login> logins { get; set; }
    }
}
