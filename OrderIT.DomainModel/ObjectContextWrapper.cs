using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;

namespace OrderIT.DomainModel
{
    public class ObjectContextWrapper : IObjectContext
    {
        public ObjectContextWrapper(ObjectContext context)
        {
            this.Context = context;
            this.objectStateManager = new ObjectStateManagerWrapper(context.ObjectStateManager);
        }
        
        #region IObjectContext Members

        public IObjectSet<T> CreateObjectSet<T>() where T : class
        {
            return this.Context.CreateObjectSet<T>();
        }

        public IObjectStateManager ObjectStateManager
        {
            get { return this.objectStateManager; }
        }

        #endregion

        public ObjectContext Context { get; set; }
        private IObjectStateManager objectStateManager;
    }
}
