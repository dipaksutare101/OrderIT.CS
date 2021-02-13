using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;

namespace OrderIT.Model.Notifications
{
	public interface IObjectPersistenceNotification
	{
		void BeforePersistence(ObjectStateEntry entry, ObjectContext context);
		void AfterPersistence(ObjectStateEntry entry, ObjectContext context);
	}
}
