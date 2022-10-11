using Microsoft.EntityFrameworkCore;
using Test.Entities;

namespace Test.Data.Context
{
    public class SqlContext: DbContext
    {
        public string _sqlConnectionString;

        public DbSet<Shop> Shop { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<ShopEmployee> ShopEmployee { get; set; }
        public DbSet<EmployeeType> EmployeeType { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_sqlConnectionString);
        }
    }
}
