using Microsoft.EntityFrameworkCore;
using RetailShop.Repository.EntityModels;
using System;

namespace RetailShop.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }

        public DbSet<OrderProduct> OrderProducts { get; set; }

    }
}
