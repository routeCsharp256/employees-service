using System;
using System.Collections.Generic;
using CSharpCourse.EmployeesService.DataAccess.DbContexts.ModelsConfigurations;
using CSharpCourse.EmployeesService.Domain.AggregationModels;
using CSharpCourse.EmployeesService.Domain.AggregationModels.Conference;
using CSharpCourse.EmployeesService.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CSharpCourse.EmployeesService.DataAccess.DbContexts
{
    public class EmployeesDbContext : DbContext
    {
        public EmployeesDbContext(DbContextOptions<EmployeesDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Conference> Conferences { get; set; }
        public DbSet<EmployeeConference> EmployeeConferences { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ConferenceConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConferenceConfiguration());

            modelBuilder.Entity<Employee>(ent =>
            {
                ent.ToTable("employees");
                ent.Property(p => p.Id).HasColumnName("id");
                ent.Property(p => p.FirstName).HasColumnName("first_name");
                ent.Property(p => p.LastName).HasColumnName("last_name");
                ent.Property(p => p.MiddleName).HasColumnName("middle_name");
                ent.Property(p => p.Email).HasColumnName("email");
                ent.Property(p => p.BirthDay).HasColumnName("birth_day");
                ent.Property(p => p.HiringDate).HasColumnName("hiring_date");
                ent.Property(p => p.IsFired).HasColumnName("is_fired");
                ent.Property(p => p.FiredDate).HasColumnName("fired_date");
                ent.Property(p => p.ClothingSize).HasColumnName("clothing_size");
            });

            var dateTimeConverter = new ValueConverter<DateTime, DateTime>(
                v => v.ToUniversalTime(),
                v => DateTime.SpecifyKind(v.ToUniversalTime(), DateTimeKind.Utc));

            var nullableDateTimeConverter = new ValueConverter<DateTime?, DateTime?>(
                v => v.HasValue ? v.Value.ToUniversalTime() : v,
                v => v.HasValue ? DateTime.SpecifyKind(v.Value.ToUniversalTime(), DateTimeKind.Utc) : v);

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (entityType.IsKeyless)
                {
                    continue;
                }

                foreach (var property in entityType.GetProperties())
                {
                    if (property.ClrType == typeof(DateTime))
                    {
                        property.SetValueConverter(dateTimeConverter);
                    }
                    else if (property.ClrType == typeof(DateTime?))
                    {
                        property.SetValueConverter(nullableDateTimeConverter);
                    }
                }
            }

        }
    }
}
