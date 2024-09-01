using MicroServiceShop.Message.WebAPI.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System.Data;

namespace MicroServiceShop.Message.WebAPI.DataAccess.Context
{
    public class DataContext : DbContext
    {
        public const string DEFAULT_SCHEMA = "message";
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DataContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectionString);

        }

        public DbSet<UserMessage> UserMessages { get; set; }
        public IDbConnection CreateConnection()
        {
            return new NpgsqlConnection(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserMessage>(entity =>
            {
                entity.ToTable("message", DEFAULT_SCHEMA);
            });
        }

    }
}
