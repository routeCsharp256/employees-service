using EmployeesService.Core.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeesService.DataAccess.DbContexts
{
    public class EmployeesDbContext : DbContext
    {
        public DbSet<EmployeeDto> Employees { get; set; }
        public DbSet<ConferenceDto> Conferences { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}