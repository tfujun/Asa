using Microsoft.EntityFrameworkCore;
using Sheesh.Operations.Inventory.Domain.Entities;
using System.Configuration;

namespace Sheesh.Operations.Inventory.Domain
{
    public class AppDbContext : DbContext
    {
        public DbSet<Item> Items { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;

            optionsBuilder.UseNpgsql(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().ToTable("Items");
        }
    }
}
