using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;
using System.Data;

namespace OrderIT.Model.Notifications
{
	public class PersistenceNotification : IObjectPersistenceNotification
	{
		string _username;
		public PersistenceNotification(string username)
		{
			_username = username;
		}

		public void BeforePersistence(ObjectStateEntry entry, ObjectContext context)
		{
		}

		public void AfterPersistence(ObjectStateEntry entry, ObjectContext context)
		{
			var type = entry.Entity.GetType();
			if (type.GetCustomAttributes(typeof(AuditableAttribute), false).Any())
			{
				string properties = null;
				if (entry.State == EntityState.Modified)
					properties = String.Join(", ", entry.GetModifiedProperties());
				context.ExecuteStoreCommand("Exec InsertAudit {0}, {1}, {2}, {3}, {4}", 
					entry.Entity.GetType().FullName, DateTime.Now, _username, entry.State.ToString().Substring(0,1), properties);
			}
		}
	}
}
