namespace CSharpCourse.EmployeesService.DataAccess.PredicateBuilders.Base
{
    /// <summary>Generic factory contract</summary>
    /// <typeparam name="TInstance">Type of returned instance of object</typeparam>
    public interface IFactory<out TInstance> where TInstance : class
    {
        TInstance Create();
    }
}
