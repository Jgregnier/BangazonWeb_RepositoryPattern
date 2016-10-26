using Microsoft.EntityFrameworkCore;
using BangazonWeb.Models;

namespace BangazonWeb.Data
{
    //Class Name: BangazonWebContext
    //Author: Grant Regnier
    //Purpose of the class: The purpose of this class is to create a context in memory for our Controllers to interact with our Database
    //Methods in Class: No Methods but DBSets of Customer, LineItem, Order, PaymentType, Product, ProductType
    public class BangazonWebContext : DbContext
    {
        public BangazonWebContext(DbContextOptions<BangazonWebContext> options)
            : base(options)
        { }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<LineItem> LineItem { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<PaymentType> PaymentType { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductType> ProductType { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .Property(b => b.DateCreated)
                .HasDefaultValueSql("strftime('%Y-%m-%d %H:%M:%S')");

            modelBuilder.Entity<Product>()
                .Property(b => b.DateCreated)
                .HasDefaultValueSql("strftime('%Y-%m-%d %H:%M:%S')");
        }
    }

}