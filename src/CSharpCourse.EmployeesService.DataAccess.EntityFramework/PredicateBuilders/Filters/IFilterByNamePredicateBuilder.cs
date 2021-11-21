using System;
using System.Linq.Expressions;
using CSharpCourse.EmployeesService.DataAccess.PredicateBuilders.Base;
using CSharpCourse.EmployeesService.Domain.Models.DTOs;

namespace CSharpCourse.EmployeesService.DataAccess.PredicateBuilders.Filters
{
    public interface IFilterByNamePredicateBuilder<TEntity, TName> :
        IPredicateBuilder<TEntity>
        where TEntity : class
    {
        Expression<Func<TEntity, bool>> FilterByName(ColumnKeywordEmployeeFilterDto filterDtoRequest);
    }
}
