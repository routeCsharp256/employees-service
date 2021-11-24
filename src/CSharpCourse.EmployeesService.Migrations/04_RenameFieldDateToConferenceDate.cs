using FluentMigrator;

namespace CSharpCourse.EmployeesService.Migrations
{
    [Migration(4)]
    public class RenameFieldDateToConferenceDate: Migration
    {
        public override void Up()
        {
            Rename.Column("date")
                .OnTable(Constants.TableNames.Conferences)
                .To("conference_date");
        }

        public override void Down()
        {
            Rename.Column("conference_date").OnTable(Constants.TableNames.Conferences).To("date");
        }
    }
}
