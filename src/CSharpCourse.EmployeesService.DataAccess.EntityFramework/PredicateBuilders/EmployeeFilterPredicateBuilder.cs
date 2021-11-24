using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CSharpCourse.EmployeesService.DataAccess.Helpers;
using CSharpCourse.EmployeesService.DataAccess.PredicateBuilders.Base;
using CSharpCourse.EmployeesService.Domain.Models.DTOs;
using CSharpCourse.EmployeesService.Domain.Models.Entities;
using CSharpCourse.EmployeesService.Domain.Models.Enums;

namespace CSharpCourse.EmployeesService.DataAccess.PredicateBuilders
{
    public abstract class EmployeeFilterPredicateBuilder : BasePredicateBuilder<Employee>,
        IEmployeeFilterPredicateBuilder
    {
        public abstract Expression<Func<Employee, bool>> FilterByKeywords(EmployeesFilterDto filterRequest);

        public Expression<Func<Employee, bool>> FilterByHiringDates(EmployeesFilterDto filterRequest)
        {
            if (filterRequest.HiringDate.From != null)
            {
                var dateFrom = filterRequest.HiringDate.From?.ToUniversalTime();
                Predicate = Predicate.And(x => dateFrom <= x.HiringDate);
            }

            if (filterRequest.HiringDate.To == null) return Predicate;
            {
                var dateTo = filterRequest.HiringDate.To?.ToUniversalTime().AddDays(1);
                Predicate = Predicate.And(x => dateTo > x.HiringDate);
            }

            return Predicate;
        }

        public Expression<Func<Employee, bool>> FilterByFiredDates(EmployeesFilterDto filterRequest)
        {
            if (filterRequest.FiredDate.From != null)
            {
                var dateFrom = filterRequest.FiredDate.From?.ToUniversalTime();
                Predicate = Predicate.And(x => dateFrom <= x.FiredDate);
            }

            if (filterRequest.FiredDate.To == null) return Predicate;
            {
                var dateTo = filterRequest.FiredDate.To?.ToUniversalTime().AddDays(1);
                Predicate = Predicate.And(x => dateTo > x.FiredDate);
            }

            return Predicate;
        }

        protected Expression<Func<Employee, bool>> FilterById(ColumnKeywordEmployeeFilterDto filterDtoRequest)
        {
            return Predicate.And(x => filterDtoRequest.Ids.Contains(x.Id));
        }

        public Expression<Func<Employee, bool>> FilterByName(ColumnKeywordEmployeeFilterDto filterDtoRequest)
        {
            if (filterDtoRequest.Names is not null && filterDtoRequest.Names.Count != 0)
            {
                var names = filterDtoRequest.Names.Select(x => x.ToLower())
                    .Distinct().ToList();
                Expression<Func<Employee, bool>> orPredicate =
                    PredicateBuilderHelper.NewFalse<Employee>();
                for (int i = 0; i < names.Count; i++)
                {
                    string oneName = names[i];
                    orPredicate = orPredicate.Or(x =>
                        string.Join(' ', new { x.LastName, x.FirstName, x.MiddleName })
                            .ToLower()
                            .Contains(oneName));
                }

                return orPredicate;
            }

            return PredicateBuilderHelper.NewFalse<Employee>();
        }

        public Expression<Func<Employee, bool>> FilterByStatus(EmployeesFilterDto filterRequest)
        {
            switch (filterRequest.EmployeeFilterStatus)
            {
                case EmployeeFilterStatus.Current:
                    Predicate = Predicate.And(it => !it.IsFired);
                    return Predicate;

                case EmployeeFilterStatus.Dismissed:
                    Predicate = Predicate.And(it => it.IsFired);
                    return Predicate;

                case EmployeeFilterStatus.All:
                    return Predicate;
            }

            return Predicate;
        }
    }
}
