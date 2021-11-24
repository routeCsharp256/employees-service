using CSharpCourse.EmployeesService.DataAccess.PredicateBuilders.Filters;
using CSharpCourse.EmployeesService.Domain.Models.DTOs;
using CSharpCourse.EmployeesService.Domain.Models.Entities;

namespace CSharpCourse.EmployeesService.DataAccess.PredicateBuilders
{
    public interface IEmployeeFilterPredicateBuilder
        : IFilterByKeywordsPredicateBuilder<Employee, EmployeesFilterDto>,
            IFilterByHiringDatesPredicateBuilder<Employee, EmployeesFilterDto>,
            IFilterByFiredDatesPredicateBuilder<Employee, EmployeesFilterDto>,
            IFilterByNamePredicateBuilder<Employee, string>,
            IFilterByStatusPredicateBuilder<Employee, EmployeesFilterDto>
    {

    }
}
