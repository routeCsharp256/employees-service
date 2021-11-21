using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CSharpCourse.EmployeesService.DataAccess.Helpers
{
    public static class PredicateBuilderHelper
    {
        public static Expression<Func<T, bool>> NewTrue<T>() => (Expression<Func<T, bool>>)(f => true);

        public static Expression<Func<T, bool>> NewFalse<T>() => (Expression<Func<T, bool>>)(f => false);

        public static Expression<Func<T, bool>> Or<T>(
            this Expression<Func<T, bool>> expr1,
            Expression<Func<T, bool>> expr2)
        {
            InvocationExpression invocationExpression =
                Expression.Invoke((Expression)expr2, expr1.Parameters.Cast<Expression>());
            return Expression.Lambda<Func<T, bool>>(
                (Expression)Expression.OrElse(expr1.Body, (Expression)invocationExpression),
                (IEnumerable<ParameterExpression>)expr1.Parameters);
        }

        public static Expression<Func<T, bool>> And<T>(
            this Expression<Func<T, bool>> expr1,
            Expression<Func<T, bool>> expr2)
        {
            InvocationExpression invocationExpression =
                Expression.Invoke((Expression)expr2, expr1.Parameters.Cast<Expression>());
            return Expression.Lambda<Func<T, bool>>(
                (Expression)Expression.AndAlso(expr1.Body, (Expression)invocationExpression),
                (IEnumerable<ParameterExpression>)expr1.Parameters);
        }
    }
}
