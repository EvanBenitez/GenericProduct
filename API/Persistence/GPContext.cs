using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Persistence
{
    public class GPContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderedItem> OrderedItems { get; set; }

        public GPContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderedItem>().HasKey(i => new {i.OrderId, i.ProductId});
            modelBuilder.Entity<OrderedItem>().HasOne(i => i.Order)
                .WithMany(o => o.OrderedItems)
                .HasForeignKey(o => o.OrderId);
            modelBuilder.Entity<OrderedItem>().HasOne(i => i.Product)
                .WithMany(p => p.OrderedItems)
                .HasForeignKey(i => i.ProductId);

            modelBuilder.Entity<Product>().HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);

            modelBuilder.Entity<Customer>().HasOne(c => c.Address)
                .WithMany(a => a.Customers)
                .HasForeignKey(c => c.AddressId);
        }

    }
}