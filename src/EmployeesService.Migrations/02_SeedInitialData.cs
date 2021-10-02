using System;
using System.Collections.Generic;
using System.Linq;
using FluentMigrator;

namespace EmployeesService.Migrations
{
    [Migration(2)]
    public class SeedInitialData : Migration
    {
        private readonly
            List<(long id, string lastName, string firstName, string middleName, string email, DateTime birthDay, DateTime hirringDate
                )> _employees =
                new()
                {
                    new(1, "Ларионов", "Кирилл", "Тимурович", "qwer@ozon.ru",
                        new DateTime(1960, 3, 5, 3, 0, 0).ToUniversalTime(),
                        new DateTime(2021, 1, 3, 3, 0, 0).ToUniversalTime()),
                    new(2, "Шишкина", "Анна", "Давидовна", "asdf@ozon.ru",
                        new DateTime(1960, 3, 5, 3, 0, 0).ToUniversalTime(),
                        new DateTime(2021, 2, 4, 3, 0, 0).ToUniversalTime()),
                    new(3, "Романов", "Артём", "Евгеньевич", "zxcv@ozon.ru",
                        new DateTime(1960, 3, 5, 3, 0, 0).ToUniversalTime(),
                        new DateTime(2020, 2, 10, 3, 0, 0).ToUniversalTime()),
                    new(4, "Леонов", "Николай", "Артемьевич", "dfhg@ozon.ru",
                        new DateTime(1960, 3, 5, 3, 0, 0).ToUniversalTime(),
                        new DateTime(2021, 4, 12, 3, 0, 0).ToUniversalTime()),
                    new(5, "Родин", "Марк", "Степанович", "zxcv@ozon.ru",
                        new DateTime(1960, 3, 5, 3, 0, 0).ToUniversalTime(),
                        new DateTime(2021, 3, 8, 3, 0, 0).ToUniversalTime()),
                    new(6, "Лазарев", "Алексей", "Андреевич", "asdfa@ozon.ru",
                        new DateTime(1960, 3, 5, 3, 0, 0).ToUniversalTime(),
                        new DateTime(2021, 2, 9, 3, 0, 0).ToUniversalTime()),
                    new(7, "Панова", "Диана", "Матвеевна", "agasgasg@ozon.ru",
                        new DateTime(1960, 3, 5, 3, 0, 0).ToUniversalTime(),
                        new DateTime(2021, 1, 12, 3, 0, 0).ToUniversalTime()),
                    new(8, "Воробьев", "Пётр", "Александрович", "asdfsd@ozon.ru",
                        new DateTime(1960, 3, 5, 3, 0, 0).ToUniversalTime(),
                        new DateTime(2021, 2, 3, 3, 0, 0).ToUniversalTime()),
                    new(9, "Калинин", "Лев", "Антонович", "ewytr@ozon.ru",
                        new DateTime(1960, 3, 5, 3, 0, 0).ToUniversalTime(),
                        new DateTime(2021, 3, 7, 3, 0, 0).ToUniversalTime()),
                    new(10, "Пименов", "Александр", "Олегович", "trut@ozon.ru",
                        new DateTime(1960, 3, 5, 3, 0, 0).ToUniversalTime(),
                        new DateTime(2021, 4, 1, 3, 0, 0).ToUniversalTime()),
                    new(11, "Смирнов", "Роман", "Дмитриевич", "khjkg@ozon.ru",
                        new DateTime(1960, 3, 5, 3, 0, 0).ToUniversalTime(),
                        new DateTime(2021, 5, 12, 3, 0, 0).ToUniversalTime()),
                    new(12, "Горбунова", "Диана", "Львовна", "rtiuy@ozon.ru",
                        new DateTime(1960, 3, 5, 3, 0, 0).ToUniversalTime(),
                        new DateTime(2021, 2, 8, 3, 0, 0).ToUniversalTime()),
                    new(13, "Князева", "Арина", "Романовна", "tikj@ozon.ru",
                        new DateTime(1960, 3, 5, 3, 0, 0).ToUniversalTime(),
                        new DateTime(2021, 3, 2, 3, 0, 0).ToUniversalTime()),
                    new(14, "Казанцев", "Андрей", "Сергеевич", "cbnkh@ozon.ru",
                        new DateTime(1960, 3, 5, 3, 0, 0).ToUniversalTime(),
                        new DateTime(2021, 1, 6, 3, 0, 0).ToUniversalTime()),
                    new(15, "Попов", "Иван", "Иванович", "jgfds@ozon.ru",
                        new DateTime(1960, 3, 5, 3, 0, 0).ToUniversalTime(),
                        new DateTime(2021, 1, 3, 3, 0, 0).ToUniversalTime())
                };

        private readonly List<(long id, string name, DateTime createDate, DateTime date, string description)>
            _conferences =
                new()
                {
                    // TODO Какого-то лешего при new DateTime и сохранении в PG день и месяц меняются местами... надо разобраться потом
                    new(1, "NordicJS 2021", DateTime.UtcNow,
                        new DateTime(2021, 7, 10, 3, 0, 0).ToUniversalTime(),
                        "Конференция NordicJS 2021 проходит c 7 по 8 октября в городе Стокгольм, Швеция. Посмотреть, как проехать в место проведения конференции можно на сайте конгрессной площадки. Деловая программа NordicJS 2021 может включать несколько потоков или секций и размещается на сайте мероприятия с подробным списком докладчиков. Спикеров конференции NordicJS 2021 обычно окончательно утверждают за 1-2 месяца до начала конференции."),
                    new(2, "An Event Apart Denver 2021", DateTime.UtcNow,
                        new DateTime(2021, 11, 10).ToUniversalTime(),
                        "Конференция An Event Apart Denver 2021 проходит c 11 по 13 октября в городе Денвер, США. Посмотреть, как проехать в место проведения конференции можно на сайте конгрессной площадки. Деловая программа An Event Apart Denver 2021 может включать несколько потоков или секций и размещается на сайте мероприятия с подробным списком докладчиков. Спикеров конференции An Event Apart Denver 2021 обычно окончательно утверждают за 1-2 месяца до начала конференции."),
                    new(3, "OS Day. Российские аппаратные платформы и операционные системы 2021", DateTime.UtcNow,
                        new DateTime(2021, 5, 10).ToUniversalTime(),
                        "OS DAY — коммуникационная площадка для теоретиков и практиков системного программирования и разработки операционных платформ, место консолидации российских разработчиков, движущихся в сходных направлениях. Конференция объединяет создателей системного и прикладного ПО, производителей аппаратного обеспечения (процессоров, вычислительных комплексов), а также заказчиков, тем самым связывая все слои ИТ-индустрии России. "),
                    new(4, "An Event Apart San Francisco 2021", DateTime.UtcNow,
                        new DateTime(2021, 3, 12).ToUniversalTime(),
                        "Конференция An Event Apart San Francisco 2021 проходит c 13 по 15 декабря в городе Сан-Франциско, США. Посмотреть, как проехать в место проведения конференции можно на сайте конгрессной площадки. Деловая программа An Event Apart San Francisco 2021 может включать несколько потоков или секций и размещается на сайте мероприятия с подробным списком докладчиков. Спикеров конференции An Event Apart San Francisco 2021 обычно окончательно утверждают за 1-2 месяца до начала конференции.")
                };

        public override void Up()
        {
            var queryWithDataEmployees = string.Join(", ",
                _employees.Select(it =>
                    $"({it.id}, '{it.firstName}', '{it.lastName}', '{it.middleName}', '{it.email}', '{it.birthDay}', '{it.hirringDate}')"));
            var rawSqlEmployees = string.Concat(
                $"INSERT INTO \"{Constants.TableNames.Employees}\" (\"id\", \"first_name\", \"last_name\", \"middle_name\", \"email\", \"birth_day\", \"hiring_date\") VALUES ",
                queryWithDataEmployees,
                @" ON CONFLICT (""id"") DO UPDATE
                 SET ""id"" = excluded.""id""; ");
            Execute.Sql(rawSqlEmployees);

            var queryWithDataConferences = string.Join(", ",
                _conferences.Select(it =>
                    $"({it.id}, '{it.name}', '{it.createDate}', '{it.date}', '{it.description}')"));
            var rawSqlConferences = string.Concat(
                $"INSERT INTO \"{Constants.TableNames.Conferences}\" (\"id\", \"name\", \"create_date\", \"date\", \"description\") VALUES ",
                queryWithDataConferences,
                @" ON CONFLICT (""id"") DO UPDATE
                 SET ""id"" = excluded.""id""; ");
            Execute.Sql(rawSqlConferences);
        }

        public override void Down()
        {
            Delete.FromTable(Constants.TableNames.Conferences);
            Delete.FromTable(Constants.TableNames.Employees);
            Delete.FromTable(Constants.TableNames.EmployeesConferences);

        }
    }
}
