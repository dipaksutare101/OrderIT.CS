using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderIT.DomainModel
{
    public static class Helpers
    {
        public static void ForEach<T>(this IEnumerable<T> list, Action<T> action)
        {
            if (list == null)
                throw new ArgumentNullException("list");
            if (action == null)
                throw new ArgumentNullException("action");

            foreach (T item in list)
            {
                action(item);
            }
        }
    }
}
