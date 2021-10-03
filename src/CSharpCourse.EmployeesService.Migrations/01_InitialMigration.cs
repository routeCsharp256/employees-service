using FluentMigrator;

namespace CSharpCourse.EmployeesService.Migrations
{
    [Migration(1)]
    public class InitialMigration : Migration
    {
        public override void Up()
        {
            var employeesRawSql = @$"Create table {Constants.TableNames.Employees} (" +
                                  @"id bigserial, " +
                                  @"first_name varchar(100) not null, " +
                                  @"last_name varchar(100) not null, " +
                                  @"middle_name varchar(100) not null, " +
                                  @"email varchar(100) not null, " +
                                  @"birth_day timestamptz default (now() at time zone 'utc'), " +
                                  @"hiring_date timestamptz default (now() at time zone 'utc'), " +
                                  "primary key (id)" +
                                  ");";
            Execute.Sql(employeesRawSql);

            var conferencesRawSql = @$"Create table {Constants.TableNames.Conferences} (" +
                                  @"id bigserial, " +
                                  @"name varchar(500) not null, " +
                                  @"create_date timestamptz default (now() at time zone 'utc'), " +
                                  @"date timestamptz default (now() at time zone 'utc'), " +
                                  @"description text null, " +
                                  "primary key (id)" +
                                  ");";
            Execute.Sql(conferencesRawSql);

            var employeesConferencesRawSql = @$"Create table {Constants.TableNames.EmployeesConferences} (" +
                                  @$"{Constants.TableNames.Employees}_id int, " +
                                  @$"{Constants.TableNames.Conferences}_id int" +
                                  ");";
            Execute.Sql(employeesConferencesRawSql);
        }

        public override void Down()
        {
            Delete.Table(Constants.TableNames.Employees);
            Delete.Table(Constants.TableNames.Conferences);
            Delete.Table(Constants.TableNames.EmployeesConferences);
        }
    }
}
