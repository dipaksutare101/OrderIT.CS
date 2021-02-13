using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OrderIT.Model;
using System.Data.Metadata.Edm;
using System.Collections.ObjectModel;
using System.Xml.Linq;
using System.Data.Objects.DataClasses;
using System.Data.Objects;
using System.Data.EntityClient;
using System.Data.Mapping;
using System.Data.Common;
using System.ComponentModel.DataAnnotations;

namespace OrderIT.WinGUI
{
	public partial class CH12 : Form
	{
		public CH12()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			using (OrderITEntities ctx = new OrderITEntities())
			{
				ctx.Orders.ToTraceString();
				var items = ctx.MetadataWorkspace.GetItems(DataSpace.CSpace);
				var items2 = ctx.MetadataWorkspace.GetItems(DataSpace.SSpace);
				var items3 = ctx.MetadataWorkspace.GetItemCollection(DataSpace.CSpace);
				var items4 = ctx.MetadataWorkspace.GetItemCollection(DataSpace.SSpace);
				var item5 = ctx.MetadataWorkspace.GetItem<EntityType>("OrderITModel.Supplier", DataSpace.CSpace);
				var item6 = ctx.MetadataWorkspace.GetItem<EntityType>("OrderIT.Model.Supplier", DataSpace.OSpace);
				var item7 = ctx.MetadataWorkspace.GetFunctions("GetUDFTotalAmount", "OrderITModel", DataSpace.CSpace);
				EntityType osItem, csItem;
				var csloaded = ctx.MetadataWorkspace.TryGetItem<EntityType>("OrderITModel.Supplier", DataSpace.CSpace, out csItem);
				var osloaded = ctx.MetadataWorkspace.TryGetItem<EntityType>("OrderIT.Model.Supplier", DataSpace.CSpace, out osItem);
				var entities = ctx.MetadataWorkspace.GetItems<EntityType>(DataSpace.CSpace);
				foreach (var item in entities)
				{
					var currentTreeNode = tree.Nodes.Find("CSDLEntities", true).First().Nodes.Add(item.FullName);
					WriteTypeBaseTypes(currentTreeNode, item);
					WriteTypeDerivedTypes(currentTreeNode, item, entities);
					WriteProperties(currentTreeNode, item, ctx, DataSpace.CSpace);
				}
				foreach (var item in ctx.MetadataWorkspace.GetItems<EdmFunction>(DataSpace.CSpace).Where(i => i.NamespaceName != "Edm"))
				{
					var currentTreeNode = tree.Nodes.Find("CSDLFunctions", true).First().Nodes.Add(GetElementNameWithType(item.FullName, item.ReturnParameter.TypeUsage, DataSpace.CSpace));
					WriteFunctionParameters(currentTreeNode, item.Parameters, DataSpace.CSpace);
				}
				foreach (var item in ctx.MetadataWorkspace.GetItems<ComplexType>(DataSpace.CSpace))
				{
					var currentTreeNode = tree.Nodes.Find("CSDLComplexTypes", true).First().Nodes.Add(item.FullName);
					WriteProperties(currentTreeNode, item, ctx, DataSpace.CSpace);
				}
				foreach (var item in ctx.MetadataWorkspace.GetItems<EntityContainer>(DataSpace.CSpace))
				{
					var currentTreeNode = tree.Nodes.Find("CSDLContainers", true).First().Nodes.Add(item.Name);
					WriteFunctionImports(currentTreeNode, item);
					WriteEntitySets<EntitySet>(currentTreeNode, item);
					WriteEntitySets<AssociationSet>(currentTreeNode, item);
				}

				foreach (var item in
					ctx.MetadataWorkspace.GetItems<EntityType>(DataSpace.SSpace))
				{
					var currentTreeNode = tree.Nodes[1].Nodes[0].Nodes.Add(item.ToString());
					WriteProperties(currentTreeNode, item, ctx, DataSpace.SSpace);
				}
				foreach (var item in
					ctx.MetadataWorkspace.GetItems<EdmFunction>(DataSpace.SSpace)
						.Where(i => i.NamespaceName != "SqlServer"))
				{
					var currentTreeNode = tree.Nodes[1].Nodes[1].Nodes.Add(item.ToString());
					WriteFunctionParameters(currentTreeNode, item.Parameters,
						DataSpace.SSpace);
				}
				var container = ctx.MetadataWorkspace.GetItems<EntityContainer>
					(DataSpace.SSpace).First();
				var currentNode = tree.Nodes[1].Nodes[2].Nodes.Add(container.ToString());
				WriteEntitySets<EntitySet>(currentNode, container);
				WriteEntitySets<AssociationSet>(currentNode, container);
			}
		}

		private void WriteEntitySets<T>(TreeNode currentTreeNode, EntityContainer item) where T: EntitySetBase
		{
			var entitySetsNode = currentTreeNode.Nodes.Add(typeof(T) == typeof(EntitySet) ? "Entity sets" : "Association sets");
			foreach (var set in item.BaseEntitySets.OfType<T>())
			{
				var node = entitySetsNode.Nodes.Add(set.Name + ": " + set.ElementType);
			}
		}

		private void WriteFunctionImports(TreeNode currentTreeNode, EntityContainer item)
		{
			var funcsNode = currentTreeNode.Nodes.Add("FunctionImports");
			foreach (var func in item.FunctionImports)
			{
				var funcNode = funcsNode.Nodes.Add(func.Name);
				WriteFunctionParameters(funcNode, func.Parameters, DataSpace.CSpace);
			}
		}

		private void WriteProperties(TreeNode currentTreeNode, StructuralType item, OrderITEntities ctx, DataSpace space)
		{
			var node = currentTreeNode.Nodes.Add((space == DataSpace.CSpace) ? "Properties" : "Columns");
			foreach(var prop in item.Members)
			{
				var propNode = node.Nodes.Add(GetElementNameWithType(prop.Name, prop.TypeUsage, space));

				var entityItem = item as EntityType;
				if (entityItem != null)
				{
					if (entityItem.KeyMembers.Any(p => p.Name == prop.Name))
					{
						propNode.NodeFont = new Font(this.Font, FontStyle.Bold);
					}
					
					if (ctx.MetadataWorkspace.GetItems<AssociationType>(space).Where(a => a.IsForeignKey).Any(a => a.ReferentialConstraints[0].ToProperties[0].Name == prop.Name && a.ReferentialConstraints[0].ToRole.Name == item.Name))
					{
						propNode.NodeFont = new Font(this.Font, FontStyle.Bold);
						propNode.ForeColor = Color.Red;
					}
				}

				foreach (var facet in prop.TypeUsage.Facets)
				{
					propNode.Nodes.Add(facet.Name + ": " + facet.Value);
				}

				var metaNode = propNode.Nodes.Add("Metadata Properties");
				foreach (var meta in prop.MetadataProperties)
				{
					metaNode.Nodes.Add(meta.Name + ": " + meta.Value);
				}
			}
		}

		private void WriteTypeDerivedTypes(TreeNode currentTreeNode, EntityType item, ReadOnlyCollection<EntityType> entities)
		{
			var node = currentTreeNode.Nodes.Add("Derived types");
			var derivedTypes = entities.Where(e => e.BaseType != null && e.BaseType.FullName == item.FullName);
			foreach (var entity in derivedTypes)
			{
				node.Nodes.Add(entity.FullName);
			}
		}

		private void WriteTypeBaseTypes(TreeNode currentTreeNode, EntityType item)
		{
			var node = currentTreeNode.Nodes.Add("Base types");
			if (item.BaseType != null) 
				node.Nodes.Add(item.BaseType.FullName);
		}

		private void WriteFunctionParameters(TreeNode parentNode, ReadOnlyMetadataCollection<FunctionParameter> parameters, DataSpace space)
		{
			foreach (var param in parameters)
				parentNode.Nodes.Add(GetElementNameWithType(param.Name, param.TypeUsage, space) + ": " + param.Mode);
		}

		private string GetElementNameWithType(string name, TypeUsage usage, DataSpace space)
		{
			string nodeText = name + ": ";

			var primitiveType = (usage.EdmType as PrimitiveType);
			if (primitiveType != null)
				nodeText += (space == DataSpace.CSpace) ? primitiveType.ClrEquivalentType.ToString() : primitiveType.Name;
			else
			{
				if (usage.EdmType is CollectionType)
				{
					var underlyingType = ((CollectionType)usage.EdmType).TypeUsage.EdmType;
					if (underlyingType.BuiltInTypeKind == BuiltInTypeKind.RowType)
						nodeText += "List<DbDataRecord>";
					else
						nodeText += "List<" + underlyingType.FullName + ">";
				}
				else
					if (usage.EdmType.BuiltInTypeKind == BuiltInTypeKind.RowType)
						nodeText += "DbDataRecord";
					else
						nodeText += usage.EdmType;
			}

			return nodeText;
		}

		private void button2_Click(object sender, EventArgs e)
		{
			using (var ctx = new OrderITEntities())
			{
				//Order o = new Order() { OrderId = 0, CustomerId = 1 };
				//ctx.Orders.SmartAttach(o);
				Customer c = new Customer() { CompanyId = 1 };
				ctx.Companies.SmartAttach(c);
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			using (var ctx = new OrderITEntities())
			{
				var o = ctx.Orders.First();
				MessageBox.Show((o is IEntityWithChangeTracker).ToString());
			}
		}

		private void button4_Click(object sender, EventArgs e)
		{
			using (OrderITEntities ctx = new OrderITEntities())
			{
				EntityType en;
				ctx.Orders.ToTraceString();
				var baseType = ctx.MetadataWorkspace.GetItem<EdmType>("OrderITModel.Order", DataSpace.CSpace);
				while (baseType.BaseType != null)
				{
					baseType = baseType.BaseType;
				}
				var c = ctx.MetadataWorkspace.GetItems<EntityContainer>(DataSpace.CSpace).First();
				var set = c.BaseEntitySets.OfType<EntitySet>().First(s => s.ElementType.FullName == baseType.FullName);
				var eSql = "SELECT '' ";
				foreach (var prop in ((EntityType)baseType).Properties)
				{
					eSql += ", x." + prop.Name + " ";
				}
				eSql += " FROM " + c.Name + "." + set.Name + " as x";
				//dataGridView1.DataSource = ctx.CreateQuery<DbDataRecord>(eSql).ToList();

				//var type = Activator.CreateInstance();
			}
		}

		private void button5_Click(object sender, EventArgs e)
		{
			using (OrderITEntities ctx = new OrderITEntities())
			{
				ctx.OrderDetails.ToTraceString();
				var x = ctx.GetById<Customer>(1);
			}
		}
	}

	public static class p{
		public static T GetById<T>(this ObjectContext ctx, object id)
		{
			var container = ctx.MetadataWorkspace.GetEntityContainer(ctx.DefaultContainerName, DataSpace.CSpace);
			var osItem = ctx.MetadataWorkspace.GetItem<EntityType>(typeof(T).FullName, DataSpace.OSpace);
			var csItem = (EdmType)ctx.MetadataWorkspace.GetEdmSpaceType(osItem);
			while (csItem.BaseType != null)
				csItem = csItem.BaseType;

			var esName = container.BaseEntitySets.First(s => s.ElementType.FullName == csItem.FullName).Name;
			var fullEsName = container.Name + "." + esName;
			var keyName = ((EntityType)csItem).KeyMembers.First().Name;
			return (T)ctx.GetObjectByKey(new EntityKey(fullEsName, keyName, id)); 
			//var eSql = "select value e from " + esName + " as e where e." + keyName + " = @key";
			//return ctx.CreateQuery<T>(eSql, new ObjectParameter("key", id)).First();
		}
	}
}