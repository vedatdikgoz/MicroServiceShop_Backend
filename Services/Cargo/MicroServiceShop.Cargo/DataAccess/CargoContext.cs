using MicroServiceShop.Cargo.WebAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System.Data;

namespace MicroServiceShop.Cargo.WebAPI.DataAccess
{
    public class CargoContext : DbContext
    {
        public const string DEFAULT_SCHEMA = "cargo";
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public CargoContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection")!;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectionString);

        }

        public DbSet<CargoCompany> CargoCompanies { get; set; }
        public DbSet<CargoDetail> CargoDetails { get; set; }
        public IDbConnection CreateConnection()
        {
            return new NpgsqlConnection(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CargoCompany>(entity =>
            {
                entity.ToTable("CargoCompany", DEFAULT_SCHEMA);
            });

            modelBuilder.Entity<CargoDetail>(entity =>
            {
                entity.ToTable("CargoDetail", DEFAULT_SCHEMA);
            });
        }
    }
}
