namespace CSharpCourse.EmployeesService.Domain.Models
{
    public static class Constants
    {
        public static Manager[] ManagersIssuingMerchandise => new[]
        {
            new Manager()
            {
                ManagerEmail = "kgmantynov@scharpcource.com",
                ManagerName = "Мартынов Константин Глебович"
            },
            new Manager()
            {
                ManagerEmail = "dskireev@scharpcource.com",
                ManagerName = "Киреев Дмитрий Сергеевич"
            },
            new Manager()
            {
                ManagerEmail = "dmsidorov@scharpcource.com",
                ManagerName = "Сидоров Дмитрий Миронович"
            },
            new Manager()
            {
                ManagerEmail = "pemedvedeva@scharpcource.com",
                ManagerName = "Медведева Полина Евгеньевна"
            },
            new Manager()
            {
                ManagerEmail = "akkazakova@scharpcource.com",
                ManagerName = "Казакова Амина Константиновна"
            },
            new Manager()
            {
                ManagerEmail = "amvorobiev@scharpcource.com",
                ManagerName = "Воробьев Артём Матвеевич"
            },
            new Manager()
            {
                ManagerEmail = "aaafanasiev@scharpcource.com",
                ManagerName = "Афанасьева Анна Александровна"
            },
            new Manager()
            {
                ManagerEmail = "gvivanov@scharpcource.com",
                ManagerName = "Иванов Гордей Владиславович"
            },
            new Manager()
            {
                ManagerEmail = "ktpachomov@scharpcource.com",
                ManagerName = "Пахомов Константин Тимофеевич"
            },
            new Manager()
            {
                ManagerEmail = "uvkuznetsova@scharpcource.com",
                ManagerName = "Кузнецова Ульяна Витальевна"
            }
        };
    }

    public class Manager
    {
        public string ManagerName { get; set; }
        public string ManagerEmail { get; set; }
    }
}
