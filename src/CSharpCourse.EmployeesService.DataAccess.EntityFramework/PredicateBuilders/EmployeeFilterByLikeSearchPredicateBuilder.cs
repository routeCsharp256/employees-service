using System;
using System.Linq;
using System.Linq.Expressions;
using CSharpCourse.EmployeesService.DataAccess.Helpers;
using CSharpCourse.EmployeesService.Domain.Models.DTOs;
using CSharpCourse.EmployeesService.Domain.Models.Entities;
using CSharpCourse.EmployeesService.Domain.Models.Enums;

namespace CSharpCourse.EmployeesService.DataAccess.PredicateBuilders
{
    public class EmployeeFilterByLikeSearchPredicateBuilder : EmployeeFilterPredicateBuilder
    {
        public override Expression<Func<Employee, bool>> FilterByKeywords(EmployeesFilterDto filterRequest)
        {
            foreach (var columnKeyword in filterRequest.ColumnKeywords)
                switch (columnKeyword.Column)
                {
                    case EmployeeFilteringColumn.All:
                        Predicate = FilterByMultipleColumns(columnKeyword);
                        break;
                    case EmployeeFilteringColumn.Id:
                        Predicate = FilterById(columnKeyword);
                        break;
                    case EmployeeFilteringColumn.Name:
                        Predicate = FilterByName(columnKeyword);
                        break;
                }

            return Predicate;
        }

        private Expression<Func<Employee, bool>> FilterByMultipleColumns(
            ColumnKeywordEmployeeFilterDto columnKeyword)
        {
            var orPredicate = PredicateBuilderHelper.NewFalse<Employee>();

            //Filter by ids
            var filteringIds = columnKeyword.Ids;

            orPredicate = orPredicate
                .Or(x => filteringIds.Contains(x.Id));

            //Filter by name ids
            orPredicate = orPredicate.Or(FilterByName(columnKeyword));

            return Predicate.And(orPredicate);
        }
    }
}
