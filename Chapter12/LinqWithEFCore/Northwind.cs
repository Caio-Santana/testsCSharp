using Microsoft.EntityFrameworkCore;

namespace Packt.Shared
{
    public class Northwind : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string path = System.IO.Path.Combine(System.Environment.CurrentDirectory, "Northwind.db");
            optionsBuilder.UseSqlite($"Filename={path}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(product => product.UnitPrice)
                .HasConversion<double>();

            modelBuilder.Entity<Customer>()
                .Property(customer => customer.CustomerID)
                .IsRequired()
                .HasMaxLength(5);

            modelBuilder.Entity<Customer>()
                .Property(customer => customer.CompanyName)
                .IsRequired()
                .HasMaxLength(40);
                
            modelBuilder.Entity<Customer>()
                .Property(customer => customer.City)
                .HasMaxLength(15);
        }
    }
}