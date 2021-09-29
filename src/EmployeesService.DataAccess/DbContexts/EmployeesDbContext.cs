using EmployeesService.Core.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeesService.DataAccess.DbContexts
{
    public class EmployeesDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Conference> Conferences { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
