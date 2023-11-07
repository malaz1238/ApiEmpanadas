using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Empanadas.Data.Entities;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection.Emit;
using System;

namespace Empanadas.Data
{
    public class Class
    {
        public class EmpanadasContext : DbContext
        {
            public DbSet<Order> Orders { get; set; }
            public DbSet<Product> Products { get; set; }
            public DbSet<User> Users { get; set; }
            public DbSet<Taste> Tastes { get; set; }
            public DbSet<LineOrder> ProductLines { get; set; }

            public EmpanadasContext(DbContextOptions<EmpanadasContext> dbContextOptions) : base(dbContextOptions)
            {

            }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<User>().HasDiscriminator(u => u.UserType);


                modelBuilder.Entity<User>().HasData(
                    new User
                    {
                        UserId = 1,
                        Name = "Guido",
                        Password = "4532",
                        UserType = "Admin",
                    },
                    new User
                    {
                        UserId = 2,
                        Name = "Amentha",
                        Password = "4865",
                        UserType = "Admin",
                    }
                    );

                modelBuilder.Entity<Product>().HasData(

                    new Product
                    {
                        ProductId = 1,
                        Description = "Empanada",
                        Price = 200,
                    }
                    );



                modelBuilder.Entity<Taste>().HasData(
                    new Taste
                    {
                        Id = 1,
                        TasteName = "Carne"
                    },
                    new Taste
                    {
                        Id = 2,
                        TasteName = "JyQ"
                    });

                // TABLA ENTRE PRODUCT Y COLOUR
                modelBuilder.Entity<Product>()
                .HasMany(p => p.Tastes)
                .WithMany()
                .UsingEntity(j => j 
                    .ToTable("TasteProducts") 
                );

                modelBuilder.Entity<LineOrder>()
                    .HasOne(ol => ol.Product)
                    .WithMany()
                    .HasForeignKey(ol => ol.ProductId);

                modelBuilder.Entity<Order>()
                    .HasMany(o => o.LinesOrders)
                    .WithOne()
                    .HasForeignKey(ol => ol.OrderId);

                modelBuilder.Entity<Order>()
                    .HasOne(o => o.User)
                    .WithMany(u => u.Orders)
                    .HasForeignKey(o => o.UserId);
            }
        }
    }
}
