using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;

namespace OrderIT.DomainModel
{
    public interface IObjectContext
    {
        IObjectSet<T> CreateObjectSet<T>() where T : class;
        IObjectStateManager ObjectStateManager { get; }
    }
}
