using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N12
{
    internal class MyDbContext : DbContext
    {

        public DbSet<MyModel> MyModels { get; set; }
        public MyDbContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=testDB;Username=postgres;Password=1234");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MyModel>().HasData(new MyModel { Id=1, Name="first"});
        }
    }
}
