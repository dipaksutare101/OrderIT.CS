using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Data.Objects;
using System.Data.Metadata.Edm;
using System.Xml.Linq;
using System.Windows.Forms;
using System.Data;
using System.Linq.Expressions;
using System.Data.EntityClient;
using System.Data.SqlClient;
using System.Data.Common;
using System.Reflection;

namespace OrderIT.Model
{
	public enum AttachState { Unchanged, Modified, Deleted }

	public static class Helpers
	{
		public static T DeepCopy<T>(this T myObj)
		{
			using (MemoryStream stream = new MemoryStream())
			{
				try
				{
					BinaryFormatter bFormatter = new BinaryFormatter();
					bFormatter.Serialize(stream, myObj);
					stream.Seek(0, SeekOrigin.Begin);
					return (T)bFormatter.Deserialize(stream);
				}
				catch (Exception er)
				{
					throw;
				}
			}
		}

		public static void SmartAttach<T>(this ObjectSet<T> os, T input) where T : class
		{
			SmartAttach(os, input, AttachState.Unchanged, null);
		}

		public static void SmartAttach<T>(this ObjectSet<T> os, T input, AttachState state) where T : class
		{
			SmartAttach(os, input, state, null);
		}

		public static void SmartAttach<T>(this ObjectSet<T> os, T input, params Expression<Func<T, object>>[] modifiedProperties) where T : class
		{
			SmartAttach(os, input, AttachState.Modified, modifiedProperties);
		}

		private static void SmartAttach<T>(this ObjectSet<T> os, T input, AttachState state, params Expression<Func<T, object>>[] modifiedProperties) where T : class
		{
			var objectType = ObjectContext.GetObjectType(input.GetType());
			var osItem = os.Context.MetadataWorkspace.GetItem<EntityType>(objectType.FullName, DataSpace.OSpace);
			var csItem = (EntityType)os.Context.MetadataWorkspace.GetEdmSpaceType(osItem);
			var value = ((XElement)(csItem.KeyMembers.First().MetadataProperties.First(p => p.Name == "http://EFEX:InsertWhen").Value)).Value;
			var id = input.GetType().GetProperty(csItem.KeyMembers.First().Name).GetValue(input, null);
			var idType = input.GetType().GetProperty(csItem.KeyMembers.First().Name).PropertyType;
			if (id.Equals(Convert.ChangeType(value, idType)))
				os.AddObject(input);
			else
			{
				os.Attach(input);
				var entry = os.Context.ObjectStateManager.GetObjectStateEntry(input);
				if (state == AttachState.Modified)
				{
					if (modifiedProperties != null && modifiedProperties.Any())
						foreach (var property in modifiedProperties)
							entry.SetModifiedProperty(property);
					else
						entry.ChangeState(EntityState.Modified);
				}
				else if (state == AttachState.Deleted)
					entry.ChangeState(EntityState.Deleted);
			}
		}

		public static ObjectStateEntry SetModifiedProperty<T>(this ObjectStateEntry entry, Expression<Func<T, object>> expression)
		{
			var body = expression.Body as MemberExpression;
			if (body == null) throw new ArgumentException("Parameter expr must be a memberexpression");

			entry.SetModifiedProperty(body.Member.Name);
			return entry;
		}

		public static ObjectQuery<T> Include<T, TProp>(this ObjectQuery<T> oq, Expression<Func<T, TProp>> expression)
		{
			var body = expression.Body as MemberExpression;
			if (body == null) throw new ArgumentException("Parameter expression must be a memberexpression");

			return oq.Include(body.Member.Name);
		}

		private static void InternalAttach(ObjectContext ctx, object entity, bool addToContext, string entitySetName, List<object> analyzedEntities)
		{
			var objectType = ObjectContext.GetObjectType(entity.GetType());
			var associations = ctx.MetadataWorkspace.GetItems<AssociationType>(DataSpace.OSpace);
			var os = ctx.MetadataWorkspace.GetItem<EntityType>(objectType.FullName, DataSpace.OSpace);
			var item = (EntityType)ctx.MetadataWorkspace.GetEdmSpaceType(os);
			var value = ((XElement)(item.KeyMembers[0].MetadataProperties.First(p => p.Name == "http://EF:InsertWhen").Value)).Value;
			var idType = ((PrimitiveType)item.Members[item.KeyMembers[0].Name].TypeUsage.EdmType).ClrEquivalentType;
			var id = entity.GetType().GetProperty(item.KeyMembers[0].Name).GetValue(entity, null);
			if (id.Equals(Convert.ChangeType(value, idType)))
			{
				if (addToContext) ctx.AddObject(entitySetName, entity);
				foreach (var association in ctx.MetadataWorkspace.GetItems<AssociationType>(DataSpace.CSpace).Where(a => a.AssociationEndMembers[1].Name == objectType.Name))
				{
					var propName = association.ReferentialConstraints[0].ToProperties[0].Name;
					var foreignKey = entity.GetType().GetProperty(propName).GetValue(entity, null);
					var principalEntity = association.AssociationEndMembers[0].GetEntityType();
					var principalIdInsertValue = ((XElement)(principalEntity.KeyMembers[0].MetadataProperties.First(p => p.Name == "http://EF:InsertWhen").Value)).Value;
					var principalIdType = ((PrimitiveType)principalEntity.Members[principalEntity.KeyMembers[0].Name].TypeUsage.EdmType).ClrEquivalentType;
					var navPropName = item.NavigationProperties.First(p => p.RelationshipType.FullName == association.FullName).Name;
					var navObject = entity.GetType().GetProperty(navPropName).GetValue(entity, null);
					if (!foreignKey.Equals(Convert.ChangeType(principalIdInsertValue, idType)))
					{
						ctx.ObjectStateManager.GetObjectStateEntry(navObject).ChangeState(EntityState.Unchanged);
					}
				}
			}
			else
				if (addToContext) ctx.AttachTo(entitySetName, entity);
		}

		public static void ForEach<T>(this IEnumerable<T> source, Action<T> action) {
			for (int i = 0; i < source.Count(); i++) {
				action(source.ElementAt(i));
			}
		}

		public static IEnumerable<T> ExecuteFunctionWithComplexProperties<T>(this ObjectContext context, string functionName, ObjectSet<T> set, MergeOption mergeOption, params ObjectParameter[] parameters) where T : class, new() 
		{
			var storeConnection = ((EntityConnection)context.Connection).StoreConnection;
			using (var comm = storeConnection.CreateCommand())
			{
				try
				{
					comm.Connection = storeConnection;
					comm.CommandText  = functionName;
					comm.CommandType = CommandType.StoredProcedure;
					context.Connection.Open();
					using (var reader = comm.ExecuteReader())
					{
						var result = new List<T>();
						while (reader.Read())
						{
							var entity = new T();
							var type = typeof(T);
							for (var i = 0; i < reader.FieldCount; i++)
							{
								string[] subProperties = reader.GetName(i).Split('.');
								PropertyInfo pi = null;
								var obj = (object)entity;
								for (int j = 0; j < subProperties.Length; j++)
								{
									pi = obj.GetType().GetProperty(subProperties[j]);
									if (j < subProperties.Length - 1)
										obj = pi.GetValue(obj, null);
								}
								pi.SetValue(obj, reader.GetValue(i) is DBNull ? null : reader.GetValue(i), null);
							}
							if (set != null){
								if (mergeOption == MergeOption.AppendOnly)
								{
									ObjectStateEntry outEntity;
									if (context.ObjectStateManager.TryGetObjectStateEntry(context.CreateEntityKey(set.Name, entity), out outEntity))
										result.Add((T)outEntity.Entity);
									else
									{
										result.Add(entity);
										set.Attach(entity);
									}
								}
								else if (mergeOption == MergeOption.OverwriteChanges)
								{
									
								}
							}
						}
						return result;
					}
				}
				finally
				{
					context.Connection.Close();
				}
			}
		}
	}
}