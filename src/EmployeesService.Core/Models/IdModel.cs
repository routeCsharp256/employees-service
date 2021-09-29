using System;

namespace EmployeesService.Core.Models
{
    public class IdModel<TKey> : IIdModel<TKey>
        where TKey : IEquatable<TKey>
    {
        public TKey Id { get; set; }
    }

    public interface IIdModel<TKey>
        where TKey : IEquatable<TKey>
    {
        TKey Id { get; set; }
    }
}