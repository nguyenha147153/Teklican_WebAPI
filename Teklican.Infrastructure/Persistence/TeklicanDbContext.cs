using Microsoft.EntityFrameworkCore;
using Teklican.Domain.Categories;
using Teklican.Domain.Orders;
using Teklican.Domain.Orders.Entities;
using Teklican.Domain.Products;
using Teklican.Domain.Roles;
using Teklican.Domain.Users;

namespace Teklican.Infrastructure.Persistence
{
    public class TeklicanDbContext : DbContext
    {
        public TeklicanDbContext()
        {
            
        }
        public TeklicanDbContext(DbContextOptions<TeklicanDbContext> options)
            : base(options)
        {
            
        }
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<LineItem> LineItems { get; set; }
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Account> Accounts { get; set; } = null!;
        public DbSet<Role> Roles { get; set; }
        public DbSet<Category> Categories { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=MSI;Initial Catalog=Teklican_WebAPI;Integrated Security=True;Trust Server Certificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TeklicanDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
