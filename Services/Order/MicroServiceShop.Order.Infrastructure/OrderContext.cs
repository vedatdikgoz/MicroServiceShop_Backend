using MicroServiceShop.Order.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MicroServiceShop.Order.Infrastructure
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options) : base(options)
        {
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Domain.Entities.Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Domain.Entities.Order>().Property(x => x.TotalPrice).HasColumnType("decimal(9,2)");
            modelBuilder.Entity<OrderItem>().Property(x => x.ProductTotalPrice).HasColumnType("decimal(9,2)");
            modelBuilder.Entity<OrderItem>().Property(x => x.ProductPrice).HasColumnType("decimal(9,2)");
            

            base.OnModelCreating(modelBuilder);
        }
    }
}
