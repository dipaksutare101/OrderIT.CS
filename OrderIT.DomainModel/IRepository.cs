using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderIT.DomainModel
{
    public interface IRepository<T> : ICollection<T> where T : class
    {
        IEnumerable<T> Query(Func<T, bool> predicate);
        T GetSingle(Func<T, bool> predicate);
        T GetSingleOrDefault(Func<T, bool> predicate);
        void Update(T entity);
    }
}
