using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;

namespace OrderIT.DomainModel
{
    public interface IObjectStateManager
    {
        bool TryGetObjectStateEntry(object item, out ObjectStateEntry state);
    }
}
