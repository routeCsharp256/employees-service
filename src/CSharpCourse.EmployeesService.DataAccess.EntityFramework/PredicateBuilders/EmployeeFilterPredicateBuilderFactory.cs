using CSharpCourse.EmployeesService.DataAccess.PredicateBuilders.Base;

namespace CSharpCourse.EmployeesService.DataAccess.PredicateBuilders
{
    public class EmployeeFilterPredicateBuilderFactory : IFactory<IEmployeeFilterPredicateBuilder>
    {
        public IEmployeeFilterPredicateBuilder Create()
        {
            return new EmployeeFilterByLikeSearchPredicateBuilder();
        }
    }
}
