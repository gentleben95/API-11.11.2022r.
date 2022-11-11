using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace API.Entities
{
    public class TableTennisShopDbContext : DbContext
    {
        private string _connectionString =
            "Server=(localdb)\\mssqllocaldb;Database=TennisTableShopDb;Trusted_Connection=True;";
        public DbSet<TableTennisShop> TableTennisShops { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Items> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TableTennisShop>()
                .Property((t => t.Name))
                .IsRequired()
                .HasMaxLength(25);
            modelBuilder.Entity<Items>()
                .Property(d => d.Name)
                .IsRequired();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
