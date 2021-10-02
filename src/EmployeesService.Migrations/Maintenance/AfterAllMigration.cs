using FluentMigrator;

namespace EmployeesService.Migrations.Maintenance
{
    [Maintenance(MigrationStage.AfterAll)]
    public class AfterAllMigration : ForwardOnlyMigration
    {
        public override void Up()
        { }
    }
}
