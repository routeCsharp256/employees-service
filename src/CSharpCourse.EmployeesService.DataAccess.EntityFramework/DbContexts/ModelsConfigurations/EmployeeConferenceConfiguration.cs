using CSharpCourse.EmployeesService.Domain.AggregationModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CSharpCourse.EmployeesService.DataAccess.DbContexts.ModelsConfigurations
{
    public class EmployeeConferenceConfiguration : IEntityTypeConfiguration<EmployeeConference>
    {
        public void Configure(EntityTypeBuilder<EmployeeConference> builder)
        {
            builder.ToTable("employeesconferences");

            builder.Property(p => p.ConferenceId).HasColumnName("conferences_id");
            builder.Property(p => p.EmployeeId).HasColumnName("employees_id");

            builder.HasKey(m => new { m.EmployeeId, m.ConferenceId });
            builder.HasOne(m => m.Employee)
                .WithMany(m => m.EmployeeConferences)
                .HasForeignKey(k => k.EmployeeId);
            builder.HasOne(m => m.Conference)
                .WithMany(m => m.EmployeeConferences)
                .HasForeignKey(k => k.ConferenceId);
        }
    }
}
