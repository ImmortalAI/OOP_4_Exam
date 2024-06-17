using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace N14
{
    internal class MyDbContext : DbContext
    {

        public DbSet<Employee> employees { get; set; }
        public DbSet<Company> companies { get; set; }
        public MyDbContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseNpgsql("Host=localhost;Port=5432;Database=testDB;Username=postgres;Password=1234");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>().HasMany(x => x.Employees).WithOne(x => x.Company).HasForeignKey(x => x.CompanyId);
        }
    }
}
