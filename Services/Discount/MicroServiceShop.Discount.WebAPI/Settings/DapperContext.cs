using MicroServiceShop.Discount.WebAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System.Data;

namespace MicroServiceShop.Discount.WebAPI.Settings
{
    public class DapperContext : DbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public const string DEFAULT_SCHEMA = "discount";
        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectionString);

        }
        public DbSet<Coupon> Coupons { get; set; }
        public IDbConnection CreateConnection()
        {
            return new NpgsqlConnection(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Coupon>(entity =>
            {
                entity.ToTable("coupons", DEFAULT_SCHEMA);

            });
        }
    }
}
