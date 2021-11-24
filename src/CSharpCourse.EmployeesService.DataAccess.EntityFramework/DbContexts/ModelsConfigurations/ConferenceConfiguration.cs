using System;
using CSharpCourse.EmployeesService.Domain.AggregationModels.Conference;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CSharpCourse.EmployeesService.DataAccess.DbContexts.ModelsConfigurations
{
    public class ConferenceConfiguration : IEntityTypeConfiguration<Conference>
    {
        public void Configure(EntityTypeBuilder<Conference> builder)
        {
            builder.ToTable("conferences");

            builder.HasKey(conference => conference.Id);
            builder.Property(p => p.Id).HasColumnName("id");

            builder.OwnsOne(m => m.Name, a =>
            {
                a.Property(p => p.Value).HasMaxLength(300)
                    .HasColumnName("name");
            });
            builder.OwnsOne(m => m.CreateDate, a =>
            {
                a.Property(p => p.Value)
                    .HasColumnName("create_date")
                    .HasDefaultValue(DateTime.UtcNow);
            });
            builder.OwnsOne(m => m.ConferenceDate, a =>
            {
                a.Property(p => p.Value)
                    .HasColumnName("conference_date");
            });
            builder.OwnsOne(m => m.Description, a =>
            {
                a.Property(p => p.Value).HasMaxLength(600)
                    .HasColumnName("description")
                    .HasDefaultValue("");
            });
        }
    }
}
