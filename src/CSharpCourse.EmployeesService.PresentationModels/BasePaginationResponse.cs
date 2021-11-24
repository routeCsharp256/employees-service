namespace CSharpCourse.EmployeesService.PresentationModels
{
    /// <summary>
    /// Base response with pagination.
    /// </summary>
    /// <typeparam name="T">Entity type.</typeparam>
    public class BasePaginationResponse<T>
    {
        public T[] Items { get; set; }
        public int TotalCount { get; set; }
    }

}
