using System.Collections.Generic;
using CSharpCourse.EmployeesService.Domain.Models.Enums;

namespace CSharpCourse.EmployeesService.Domain.Models.DTOs
{
    public class ColumnKeywordEmployeeFilterDto : ColumnKeywordFilter<EmployeeFilteringColumn>
    {
        public IReadOnlyCollection<long> Ids { get; set; }
        public IReadOnlyCollection<string> Names { get; set; }
    }
}
