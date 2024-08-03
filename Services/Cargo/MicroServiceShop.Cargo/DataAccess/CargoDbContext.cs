using Microsoft.EntityFrameworkCore;
using System;

namespace MicroServiceShop.Cargo.WebAPI.DataAccess
{
    public class CargoDbContext : DbContext
    {
        public CargoDbContext(DbContextOptions<CargoDbContext> options) : base(options) { }
    }
}
