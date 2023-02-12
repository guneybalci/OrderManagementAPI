using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework.Contexts
{
    public class RetailContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=MSKK-HCM-LT6548\SQLEXPRESS;Database=Retail;Trusted_Connection=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /* Customer Table */
            modelBuilder.Entity<Customer>()
            .HasMany<Order>(o => o.Orders)
            .WithOne(o => o.Customer)
            .HasForeignKey(c => c.Id);

            /* Order Table */
            modelBuilder.Entity<Order>()
              .HasOne<Customer>(o => o.Customer)
              .WithMany(c => c.Orders)
              .HasForeignKey(o => o.CustomerId);

            /* Product - Order / Many to Many */
            modelBuilder.Entity<ProductOrder>().HasKey(po => new { po.ProductId, po.OrderId });

            modelBuilder.Entity<ProductOrder>()
             .HasOne<Product>(p => p.Product)
             .WithMany(po => po.ProductOrders)
             .HasForeignKey(p => p.ProductId);

            modelBuilder.Entity<ProductOrder>()
         .HasOne<Order>(o => o.Order)
         .WithMany(po => po.ProductOrders)
         .HasForeignKey(o => o.OrderId);

            /* Log Table*/

            modelBuilder.Entity<Log>()
                .Property(l => l.Detail)
                .IsRequired(false);
            modelBuilder.Entity<Log>()
               .Property(l => l.Audit)
               .IsRequired(false);

            //modelBuilder.Entity<Log>()
            //.Property(l => l.Date)
            //.IsRequired(false);
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<ProductOrder> ProductOrders { get; set; }

        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }

        public DbSet<Log> Logs { get; set; }
    }
}
