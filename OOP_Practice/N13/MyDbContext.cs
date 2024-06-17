using Microsoft.EntityFrameworkCore;
using N13;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace N13
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
    }
}
