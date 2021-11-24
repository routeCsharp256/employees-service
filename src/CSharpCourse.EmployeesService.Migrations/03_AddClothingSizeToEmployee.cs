using FluentMigrator;

namespace CSharpCourse.EmployeesService.Migrations
{
    [Migration(3)]
    public class AddClothingSizeToEmployee: Migration
    {
        public override void Up()
        {
            Alter
                .Table(Constants.TableNames.Employees)
                .AddColumn("clothing_size")
                .AsInt32()
                .WithDefaultValue(4);
        }

        public override void Down()
        {
            Delete.Column("clothing_size").FromTable(Constants.TableNames.Employees);
        }
    }
}
