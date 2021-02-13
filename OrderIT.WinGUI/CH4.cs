using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OrderIT.Model;
using System.Data.Objects;
using System.Data.Objects.SqlClient;
using System.Linq.Expressions;
using SampleSupport;
using System.Data.EntityClient;
using System.Data.SqlClient;

namespace OrderIT.WinGUI {
	public partial class CH4 : Form {
		public CH4() {
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e) {
			using (var ctx = new OrderITEntities()) {
				Dump(from o in ctx.Orders
						 where o.ShippingAddress.City == "New York"
						 select o);
			}
		}

		private void button2_Click(object sender, EventArgs e) {
			using (var ctx = new OrderITEntities()) {
				var cities = new[] { "New York", "Seattle" };

				Dump(from o in ctx.Orders
												 where cities.Contains(o.ShippingAddress.City)
												 select o);
			}
		}

		private void button3_Click(object sender, EventArgs e) {
			using (var ctx = new OrderITEntities()) {
				Dump(from order in ctx.Orders
												 where order.Customer.BillingAddress.City == "New York"
												 select order);
			}
		}

		private void button4_Click(object sender, EventArgs e) {
			using (var ctx = new OrderITEntities()) {
				Dump(from order in ctx.Orders
												 where order.OrderDetails.Any(d => d.Product.Brand == "MyBrand")
												 select order);
			}
		}

		private void button5_Click(object sender, EventArgs e) {
			using (var ctx = new OrderITEntities()) {
				Dump(from order in ctx.Orders
												 where order.OrderDetails.All(d => d.Discount == 0)
												 select order);
			}
		}

		private void button6_Click(object sender, EventArgs e) {
			using (var ctx = new OrderITEntities()) {
				Dump(from order in ctx.Orders
												 where order.OrderDetails.Sum(d => d.Discount * d.Quantity) > 5
												 select order);
			}
		}

		private void button7_Click(object sender, EventArgs e) {
			using (var ctx = new OrderITEntities()) {
				Dump(from order in ctx.Orders
												 where order.OrderDetails.Select(d => d.Product.ProductId)
													 .Distinct()
													 .Count() > 1
												 select order);
			}
		}

		private void button8_Click(object sender, EventArgs e) {
			using (var ctx = new OrderITEntities()) {
				Dump((from order in ctx.Orders
													orderby order.OrderDate
													select order).Take(15));
			}
		}

		private void button9_Click(object sender, EventArgs e) {
			using (var ctx = new OrderITEntities()) {
				Dump((from o in ctx.Orders
													orderby o.OrderId
													select o).Skip(10).Take(10));
			}
		}

		private void button10_Click(object sender, EventArgs e) {
			using (var ctx = new OrderITEntities()) {
				Dump((from order in ctx.Orders
													where order.OrderId == 10
													select order).First());
			}
		}

		private void button11_Click(object sender, EventArgs e) {
			using (var ctx = new OrderITEntities()) {
				var key = new EntityKey("OrderITEntities.Orders", "OrderId", 3);
				var entity = ctx.GetObjectByKey(key); //throws exception if not found

			}
			using (var ctx = new OrderITEntities()) {
				var key = new EntityKey("OrderITEntities.Orders", "OrderId", 3);
				Object entity;
				var found = ctx.TryGetObjectByKey(key, out entity);//returns false if not found
			}
		}

		private void button12_Click(object sender, EventArgs e) {
			using (var ctx = new OrderITEntities()) {
				var date = DateTime.Today;
				string city = null;

				var result = ctx.Orders.AsQueryable();

				if (date != DateTime.MinValue)
					result = result.Where(o => o.OrderDate < date);

				if (String.IsNullOrEmpty(city))
					result = result.Where(o => o.ShippingAddress.City == city);

				Dump(result);
			}
		}

		private void button13_Click(object sender, EventArgs e) {
			using (var ctx = new OrderITEntities()) {
				Dump(from o in ctx.Orders
												 select new { o.OrderId, o.OrderDate, o.ShippingAddress });
			}
		}

		private void button14_Click(object sender, EventArgs e) {
			using (var ctx = new OrderITEntities()) {
				Dump(from o in ctx.Orders
												 select new {
													 o.OrderId,
													 o.OrderDate,
													 ShippingAddress = o.ShippingAddress.Address + "-" +
														 o.ShippingAddress.City + "-" + o.ShippingAddress.ZipCode + "-" +
														 o.ShippingAddress.Country
												 });
			}
		}

		private void button15_Click(object sender, EventArgs e) {
			using (var ctx = new OrderITEntities()) {
				Dump(from o in ctx.Orders
												 select new {
													 o.OrderId,
													 o.OrderDate,
													 Shipping = new { o.ShippingAddress.City, o.ShippingAddress.Address }
												 });
			}
		}

		private void button16_Click(object sender, EventArgs e) {
			using (var ctx = new OrderITEntities()) {
				Dump(from o in ctx.Orders
												 select new { o.OrderId, o.OrderDate, o.ShippingAddress, o.Customer });
			}
		}

		private void button17_Click(object sender, EventArgs e) {
			using (var ctx = new OrderITEntities()) {
				Dump(from o in ctx.Orders
												 select new { o.OrderId, o.OrderDate, o.ShippingAddress, o.Customer.Name });
			}
		}

		private void button18_Click(object sender, EventArgs e) {
			using (var ctx = new OrderITEntities()) {
				Dump(from o in ctx.Orders
						 select new OrderDTO {
							 Id = o.OrderId,
							 OrderDate = o.OrderDate,
							 ShippingAddress = o.ShippingAddress,
							 CustomerName = o.Customer.Name
						 });
			}
		}

		private void button19_Click(object sender, EventArgs e) {
			using (var ctx = new OrderITEntities()) {
				Dump(from o in ctx.Orders
												 select new { o.OrderId, o.OrderDate, o.ShippingAddress, o.OrderDetails });
			}
		}

		private void button20_Click(object sender, EventArgs e) {
			using (var ctx = new OrderITEntities()) {
				Dump(from o in ctx.Orders
												 select new {
													 o.OrderId,
													 o.OrderDate,
													 o.ShippingAddress,
													 Details = from d in o.OrderDetails
																		 select new {
																			 d.OrderDetailId,
																			 d.Product.ProductId,
																			 d.Quantity
																		 }
												 });
			}
		}

		private void button21_Click(object sender, EventArgs e) {
			using (var ctx = new OrderITEntities()) {
				Dump(from o in ctx.Orders
												 select new {
													 o.OrderId,
													 o.OrderDate,
													 o.ShippingAddress,
													 Total = o.OrderDetails.Sum(
																				d => d.Quantity * (d.UnitPrice - d.Discount))
												 });
			}
		}

		private void button22_Click(object sender, EventArgs e) {
			using (var ctx = new OrderITEntities()) {
				var result = from c in ctx.Orders
												 group c by c.ShippingAddress.City;

				foreach (var key in result) {
					Console.WriteLine(key.Key);
					foreach (var item in key)
						Console.WriteLine(item.OrderId);
				}
				Dump(result);
			}
		}

		private void button23_Click(object sender, EventArgs e) {
			using (var ctx = new OrderITEntities()) {
				var result = from c in ctx.Orders
										 group c by c.ShippingAddress.City into oGroup
										 select new { CityName = oGroup.Key, Items = oGroup };

				foreach (var key in result) {
					Console.WriteLine(key.CityName);
					foreach (var item in key.Items)
						Console.WriteLine(item.OrderId);
				}
				Dump(result);
			}
		}

		private void button24_Click(object sender, EventArgs e) {
			using (var ctx = new OrderITEntities()) {
				var result = from o in ctx.Orders
										 group o by new {
											 o.ShippingAddress.City,
											 o.ShippingAddress.ZipCode
										 };

				foreach (var key in result) {
					Console.WriteLine(key.Key.City + "-" + key.Key.ZipCode);
					foreach (var item in key)
						Console.WriteLine(item.OrderId);
				}
				Dump(result);
			}
		}

		private void button25_Click(object sender, EventArgs e) {
			using (var ctx = new OrderITEntities()) {
				var result = from o in ctx.Orders
										 group o by o.ShippingAddress.City into g
										 select new { g.Key, Items = g.Select(og => new { og.OrderId, og.OrderDate }) };

				foreach (var key in result) {
					Console.WriteLine(key.Key);
					foreach (var item in key.Items)
						Console.WriteLine(item.OrderId);
				}
				Dump(result);
			}
		}

		private void button26_Click(object sender, EventArgs e) {
			using (var ctx = new OrderITEntities()) {
				Dump(from o in ctx.Orders
						 group o by o.ShippingAddress.City into g
						 where g.Count() > 1
						 select g);
			}
		}

		private void button27_Click(object sender, EventArgs e) {
			using (var ctx = new OrderITEntities()) {
				Dump(from o in ctx.Orders
						 orderby o.ShippingAddress.City //descending
						 select o);
			}
		}

		private void button28_Click(object sender, EventArgs e) {
			using (var ctx = new OrderITEntities()) {
				Dump(from o in ctx.Orders
						 orderby o.OrderDetails.Sum(
								d => d.Quantity * (d.UnitPrice - d.Discount))
						 select new {
							 o.OrderId,
							 o.OrderDate,
							 o.ShippingAddress,
							 Total = o.OrderDetails.Sum(
														d => d.Quantity * (d.UnitPrice - d.Discount))
						 });
			}
		}

		private void button29_Click(object sender, EventArgs e) {
			using (var ctx = new OrderITEntities()) {
				Dump(from o in ctx.Orders
						 select new {
							 o.OrderId,
							 o.ShippingAddress.City,
							 Details = o.OrderDetails.OrderBy(d => d.Quantity)
						 });
			}
		}

		private void button30_Click(object sender, EventArgs e) {
			using (var ctx = new OrderITEntities()) {
				Dump(from o in ctx.Orders
						 orderby o.Customer.ShippingAddress.City
						 select o);
			}
		}

		private void button31_Click(object sender, EventArgs e) {
			using (var ctx = new OrderITEntities()) {
				Dump(from o in ctx.Orders
						 join c in ctx.Companies.OfType<Customer>()
										on new { o.ShippingAddress.City, o.Customer.CompanyId }
										equals new { c.ShippingAddress.City, c.CompanyId }
						 select o);
			}
		}

		private void button32_Click(object sender, EventArgs e) {
			using (var ctx = new OrderITEntities()) {
				Dump(from p in ctx.Products
												 select p);
			}
		}

		private void button33_Click(object sender, EventArgs e) {
			using (var ctx = new OrderITEntities()) {
				Dump(from p in ctx.Products
												 where p is Shoe
												 select p); //returns list of Product
			}
		}

		private void button34_Click(object sender, EventArgs e) {
			using (var ctx = new OrderITEntities()) {
				Dump(from p in ctx.Products.OfType<Shoe>()
						 select p); //returns a list of Shoe
			}
		}

		private void button35_Click(object sender, EventArgs e) {
			using (var ctx = new OrderITEntities()) {
				Dump(from p in ctx.Products.OfType<Shoe>()
						 where p.Sport == "Basket"
						 select p);
			}
		}

		private void button36_Click(object sender, EventArgs e) {
			using (var ctx = new OrderITEntities()) {
				Dump(from p in ctx.Products
						 where (p as Shoe).Sport == "Basket"
						 select p);
			}
		}

		private void button37_Click(object sender, EventArgs e) {
			using (var ctx = new OrderITEntities()) {
				Dump((from p in ctx.Products.OfType<Shoe>()
							where p.Sport == "Basket"
							select p).Cast<Product>());
			}
		}

		private void button38_Click(object sender, EventArgs e) {
			using (var ctx = new OrderITEntities()) {
				Dump(from o in ctx.Orders.Include("OrderDetails")
						 where o.OrderDate.AddDays(5) < o.ActualShippingDate
						 select o);
			}
		}

		private void button39_Click(object sender, EventArgs e) {
			using (var ctx = new OrderITEntities()) {
				Dump(from o in ctx.Orders.Include("OrderDetails")
												 where EntityFunctions.DiffDays(o.OrderDate, o.ActualShippingDate) > 5
												 select o);
			}
		}

		private void button40_Click(object sender, EventArgs e) {
			using (var ctx = new OrderITEntities()) {
				Dump(from o in ctx.Orders
						 where SqlFunctions.DateDiff("d", o.OrderDate, o.ActualShippingDate) > 5
						 select o);
			}
		}

		private void button41_Click(object sender, EventArgs e) {
			using (var ctx = new OrderITEntities()) {
				Dump(ctx.ExecuteStoreQuery<OrderDetail>("Select * from [OrderDetail]").ToList());
			}
		}

		private void button42_Click(object sender, EventArgs e) {
			using (var ctx = new OrderITEntities()) {
				var p = new EntityParameter("p0", DbType.String) { Value = 11 };
				Dump(ctx.ExecuteStoreQuery<OrderDetailProjection>("Select quantity, unitprice, discount from [OrderDetail] d join [order] o on (d.OrderId = d.OrderId) where o.orderid = @p0", 11));
			}
		}

		private void button43_Click(object sender, EventArgs e) {
			using (var ctx = new OrderITEntities()) {
				Dump(from o in ctx.Orders.Include("OrderDetails")
						 select o);
			}
		}

		private void button44_Click(object sender, EventArgs e) {
			using (var ctx = new OrderITEntities()) {
				Dump(from o in ctx.Orders.Include("OrderDetails")
												 select o);
			}
		}

		private void button45_Click(object sender, EventArgs e) {
			Order order;
			using (var ctx = new OrderITEntities()) {
				order = ctx.Orders.First();
				ctx.LoadProperty<Order>(order, o => o.OrderDetails);
				//ctx.LoadProperty(order, "OrderDetails");
				Dump(order);
			}
			
		}

		public void LoadProperty<T>(T entity, Expression<Func<T, object>> selector)
			where T : class {
			using (var ctx = new OrderITEntities()) {
				ctx.CreateObjectSet<T>().Attach(entity);
				ctx.LoadProperty<T>(entity, selector);
			}
		}

		private void Dump(object p) {
			ObjectDumper.Write(p, treeView1, textBox1);
		}

		private void button46_Click(object sender, EventArgs e)
		{
			using (var ctx = new OrderITEntities())
			{
				var x = from o in ctx.Orders
								join c in ctx.Companies.OfType<Customer>()
											 on new { o.ShippingAddress.City, o.Customer.CompanyId }
											 equals new { c.ShippingAddress.City, c.CompanyId }
											 into g
								from item in g.DefaultIfEmpty()
								select o;
				Dump(x);
			}
		}
	}

	public class OrderDetailProjection {
		public int Quantity { get; set; }
		public decimal UnitPrice { get; set; }
		public decimal Discount { get; set; }
	}

	public class OrderDTO {
		public int Id { get; set; }
		public DateTime OrderDate { get; set; }
		public AddressInfo ShippingAddress { get; set; }
		public string CustomerName { get; set; }
	}
}
