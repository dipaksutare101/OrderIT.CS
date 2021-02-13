using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OrderIT.DomainModel;
using System.Data.Objects;
using OrderIT.Model;

namespace OrderIT.Web
{
    public class WebContextWrapper : IObjectContext
    {
        public WebContextWrapper()
        {
            if (HttpContext.Current.Items[ConfigurationKeys.ConnectionString] == null)
                throw new InvalidProgramException("You must register the HttpModule first.");

            this.Context = ((OrderITEntities)HttpContext.Current.Items[ConfigurationKeys.ConnectionString]);
            this.objectStateManager = new ObjectStateManagerWrapper(Context.ObjectStateManager);
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

        public OrderITEntities Context { get; set; }
        private IObjectStateManager objectStateManager;
    }
}