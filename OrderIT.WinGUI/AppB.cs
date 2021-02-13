using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OrderIT.Model;
using System.Linq.Expressions;
using OrderIT.Model.Notifications;

namespace OrderIT.WinGUI
{
	public partial class AppB : Form
	{
		public AppB()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Order order;
			using (var ctx = new OrderITEntities())
			{
				order = ctx.Orders.First();
			}

			using (var ctx = new OrderITEntities())
			{
				ctx.Orders.SmartAttach(order, o => o.ActualShippingDate);
				ctx.SaveChanges();
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Customer c = new Customer()
			{
				BillingAddress = new AddressInfo()
				{
					Address = "a",
					City = "ci",
					Country = "co",
					ZipCode = "00000"
				},
				Email = "dddòddd@ddd.it",
				Name = "name",
				ShippingAddress = new AddressInfo()
				{
					Address = "a",
					City = "ci",
					Country = "co",
					ZipCode = "00000"
				},
				WSEnabled = false
			};
			var notification = new PersistenceNotification("username");
			using (var ctx = new OrderITEntities(notification))
			{
				ctx.Companies.SmartAttach(c);
				ctx.SaveChanges();
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			using (var ctx = new OrderITEntities())
			{
				ctx.ContextOptions.LazyLoadingEnabled = false;
				var x = ctx.Orders.Include(o => o.OrderDetails).ToList();
			}
		}

		private void button4_Click(object sender, EventArgs e)
		{
			using (var ctx = new OrderITEntities())
			{
				
				var entity = ctx.GeometrySamples.First();
				var geometries = entity.TypedSpatialData.STNumGeometries();
			}
		}

		private void button5_Click(object sender, EventArgs e)
		{
			using (var ctx = new OrderITEntities())
			{
				var o = ctx.Orders.First();
				var list = ctx.ExecuteFunctionWithComplexProperties<Order>("GetOrdersWithComplexProperties", ctx.Orders, System.Data.Objects.MergeOption.AppendOnly);
				var x = list.Count();
			}
		}
	}
}
