using FluentMigrator;

namespace CSharpCourse.EmployeesService.Migrations.Maintenance
{
    [Maintenance(MigrationStage.BeforeAll)]
    public class BeforeAllMigration : ForwardOnlyMigration
    {
        public override void Up()
        { }
    }
}
