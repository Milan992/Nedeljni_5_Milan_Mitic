﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfBetweenUs.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BetweenUsEntities : DbContext
    {
        public BetweenUsEntities()
            : base("name=BetweenUsEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tblAccount> tblAccounts { get; set; }
        public virtual DbSet<tblLike> tblLikes { get; set; }
        public virtual DbSet<tblPost> tblPosts { get; set; }
        public virtual DbSet<tblRequest> tblRequests { get; set; }
        public virtual DbSet<vwPost> vwPosts { get; set; }
    }
}
