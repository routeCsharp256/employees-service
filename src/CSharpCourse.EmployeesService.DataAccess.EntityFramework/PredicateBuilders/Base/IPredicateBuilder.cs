using System;
using System.Linq.Expressions;

namespace CSharpCourse.EmployeesService.DataAccess.PredicateBuilders.Base
{
    public interface IPredicateBuilder<TEntity> where TEntity : class
    {
        Expression<Func<TEntity, bool>> Build();
    }
}
