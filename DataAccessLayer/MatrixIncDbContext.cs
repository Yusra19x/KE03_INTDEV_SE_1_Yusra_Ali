﻿using DataAccessLayer.Models;
using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{

        public class MatrixIncDbContext : DbContext
        {
            public MatrixIncDbContext(DbContextOptions<MatrixIncDbContext> options)
                : base(options)
            {
            }
                  
            public DbSet<Customer> Customers { get; set; }
            public DbSet<Product> Products { get; set; }
            public DbSet<Order> Orders { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);

                
                modelBuilder.Entity<Customer>()
                    .HasMany(c => c.Orders)
                    .WithOne(o => o.Customer!)
                    .HasForeignKey(o => o.CustomerId);
            }
        }
}
