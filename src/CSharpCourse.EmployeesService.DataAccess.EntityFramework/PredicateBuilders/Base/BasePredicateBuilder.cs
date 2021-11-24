using System;
using System.Linq.Expressions;
using CSharpCourse.EmployeesService.DataAccess.Helpers;

namespace CSharpCourse.EmployeesService.DataAccess.PredicateBuilders.Base
{
    public class BasePredicateBuilder<TEntity> : IPredicateBuilder<TEntity> where TEntity : class
    {
        protected Expression<Func<TEntity, bool>> Predicate { get; set; }

        protected BasePredicateBuilder() => this.Predicate = PredicateBuilderHelper.NewTrue<TEntity>();

        public Expression<Func<TEntity, bool>> Build() => this.Predicate;
    }
}
