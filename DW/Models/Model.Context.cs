﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DW.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DBEntities : DbContext
    {
        public DBEntities()
            : base("name=DBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<pregunta> preguntas { get; set; }
        public virtual DbSet<producto> productoes { get; set; }
        public virtual DbSet<servicio_tec> servicio_tec { get; set; }
        public virtual DbSet<tienda> tiendas { get; set; }
        public virtual DbSet<usuario> usuarios { get; set; }
    }
}
