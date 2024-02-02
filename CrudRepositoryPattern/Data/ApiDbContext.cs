using CrudRepositoryPattern.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudRepositoryPattern.Data
{
    public class ApiDbContext : DbContext
    {


        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {


        }

        public DbSet<Driver> Drivers { get; set; }


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.Entity<Driver>().HasData(new Driver { Name="sasa",}  );
        //}

    }
}
