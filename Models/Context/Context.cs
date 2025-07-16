﻿using Microsoft.EntityFrameworkCore;
using Models.Entities;
using System;


namespace Models.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products => Set<Product>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(p => p.JsonDoc)
                .HasColumnType("jsonb");
        }
    }
}