using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;
using System.Data.EntityClient;
using System.Data;

namespace OrderIT.Model.Notifications
{
	public class ExtendedObjectContext : ObjectContext
	{
		protected IObjectPersistenceNotification PersistenceNotification { get; set; }
		
		#region Constructors

		public ExtendedObjectContext(string ConnectionString, string ContainerName, IObjectPersistenceNotification notification)
			: base(ConnectionString, ContainerName)
		{
			this.ContextOptions.LazyLoadingEnabled = true;
			PersistenceNotification = notification;
		}

		public ExtendedObjectContext(EntityConnection connection, string ContainerName, IObjectPersistenceNotification notification)
			: base(connection, ContainerName)
		{
			this.ContextOptions.LazyLoadingEnabled = true;
			PersistenceNotification = notification;
		}
		#endregion

		public override int SaveChanges(SaveOptions options)
		{
			DetectChanges();
			if (PersistenceNotification != null)
				ObjectStateManager.GetObjectStateEntries(EntityState.Added | EntityState.Modified | EntityState.Deleted).ForEach(e => PersistenceNotification.BeforePersistence(e, this));
			var result = base.SaveChanges(SaveOptions.None);

			if (PersistenceNotification != null)
				ObjectStateManager.GetObjectStateEntries(EntityState.Added | EntityState.Modified | EntityState.Deleted).ForEach(e => PersistenceNotification.AfterPersistence(e, this));

			if (options.HasFlag(SaveOptions.AcceptAllChangesAfterSave))
				this.AcceptAllChanges();

			return result;
		}
	}
}