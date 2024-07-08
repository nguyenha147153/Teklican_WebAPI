using Microsoft.EntityFrameworkCore;
using Teklican.Domain.Accounts;
using Teklican.Domain.Cart;
using Teklican.Domain.Cart.Entities;
using Teklican.Domain.Categories;
using Teklican.Domain.Orders;
using Teklican.Domain.Orders.Entities;
using Teklican.Domain.Products;
using Teklican.Domain.Roles;

namespace Teklican.Infrastructure.Persistence
{
    public class TeklicanDbContext : DbContext
    {
       
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<LineItem> LineItems { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Account> Accounts { get; set; } = null!;
        public DbSet<Role> Roles { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Cart> Carts { get; set; } = null!;
        public DbSet<CartItem> CartItems { get; set; } = null!;


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=192.168.1.39,1434;Database=Teklican;User Id=sa;Password=123456;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TeklicanDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
