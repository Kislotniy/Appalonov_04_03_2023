﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Lopushok_421.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Lopushok_DBEntities : DbContext
    {
        public Lopushok_DBEntities()
            : base("name=Lopushok_DBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Agents> Agents { get; set; }
        public virtual DbSet<Application> Application { get; set; }
        public virtual DbSet<Buyers> Buyers { get; set; }
        public virtual DbSet<Managers> Managers { get; set; }
        public virtual DbSet<Materials> Materials { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Products_Material> Products_Material { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Type_Materials> Type_Materials { get; set; }
        public virtual DbSet<Type_Products> Type_Products { get; set; }
        public virtual DbSet<Units> Units { get; set; }
    }
}