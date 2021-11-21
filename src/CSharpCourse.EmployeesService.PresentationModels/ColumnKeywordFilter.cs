using System;
using System.Text.Json.Serialization;

namespace CSharpCourse.EmployeesService.PresentationModels
{
    /// <summary>Model that represent filter</summary>
    /// <typeparam name="TColumnIdEnum">Type of enum that represent columns.</typeparam>
    /// <footer><a href="https://www.google.com/search?q=Ozon.Exteca.Core.Shared.Models.ColumnKeywordFilter%601">`ColumnKeywordFilter` on google.com</a></footer>
    public class ColumnKeywordFilter<TColumnIdEnum> where TColumnIdEnum : Enum
    {
        /// <summary>Get or set filter Column.</summary>
        /// <footer><a href="https://www.google.com/search?q=Ozon.Exteca.Core.Shared.Models.ColumnKeywordFilter%601.Column">`ColumnKeywordFilter.Column` on google.com</a></footer>
        [JsonConverter(typeof (JsonStringEnumConverter))]
        public TColumnIdEnum Column { get; set; }

        /// <summary>Get or set keywords for search filter.</summary>
        /// <footer><a href="https://www.google.com/search?q=Ozon.Exteca.Core.Shared.Models.ColumnKeywordFilter%601.Keywords">`ColumnKeywordFilter.Keywords` on google.com</a></footer>
        public string[] Keywords { get; set; }
    }
}
