using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;

namespace OrderIT.DomainModel
{
    public class ObjectStateManagerWrapper : IObjectStateManager
    {
        public ObjectStateManagerWrapper(ObjectStateManager objectStateManager)
        {
            this.ObjectStateManager = objectStateManager;
        }

        #region IObjectStateManager Members

        public bool TryGetObjectStateEntry(object item, out ObjectStateEntry state)
        {
            return this.ObjectStateManager.TryGetObjectStateEntry(item, out state);
        }

        #endregion

        public ObjectStateManager ObjectStateManager { get; set; }
    }
}
