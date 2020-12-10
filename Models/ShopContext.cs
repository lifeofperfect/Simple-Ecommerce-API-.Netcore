using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HPlusSport.API.Models
{
    public class ShopContext:DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options):base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasMany(a => a.Products).WithOne(c => c.Category).HasForeignKey(c => c.CategoryId);
            modelBuilder.Entity<Order>().HasOne(u => u.User);
            modelBuilder.Entity<Order>().HasMany(o => o.Products);
            modelBuilder.Entity<User>().HasMany(o => o.Orders).WithOne(u => u.User).HasForeignKey(u => u.UserId);


            modelBuilder.Seed();
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
