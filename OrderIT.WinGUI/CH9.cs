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
using SampleSupport;
using System.Data.Common;
using System.Data.EntityClient;

namespace OrderIT.WinGUI {
	public partial class CH9 : Form {
		public CH9() {
			InitializeComponent();
		}

		private class p {
			public int OrderId { get; set; }
			public DateTime OrderDate { get; set; }
		}
		private void button1_Click(object sender, EventArgs e) {
			var name = "New York";
			using (var ctx = new OrderITEntities()) {
				var result = ctx.CreateQuery<Order>("SELECT VALUE c FROM " +
					"OrderITEntities.Orders as c " +
					"WHERE c.ShippingAddress.City = @city");
				result.Parameters.Add(new ObjectParameter("city", name));
				Dump(result);
			}
		}

		private void Dump(object p) {
			ObjectDumper.Write(p, treeView1, textBox1);
		}

		private void button2_Click(object sender, EventArgs e) {
			using (var ctx = new OrderITEntities()) {
				var result = ctx.CreateQuery<Order>("SELECT VALUE o FROM OrderITEntities.Orders AS o WHERE o.Customer.BillingAddress.City = 'New York'");
				Dump(result);
			}
		}

		private void button3_Click(object sender, EventArgs e) {
			using (var ctx = new OrderITEntities()) {
				var result = ctx.CreateQuery<Order>("SELECT VALUE o FROM OrderITEntities.Orders as o WHERE EXISTS (SELECT d FROM o.OrderDetails  as d WHERE d.Product.Brand = 'MyBrand')");
				Dump(result);
			}
		}

		private void button4_Click(object sender, EventArgs e) {
			using (var ctx = new OrderITEntities()) {
				var result = ctx.CreateQuery<Order>("SELECT VALUE o FROM OrderITEntities.Orders as o WHERE SUM(SELECT value d.discount FROM o.OrderDetails as d) = 0 ");
				Dump(result);
			}
		}

		private void button5_Click(object sender, EventArgs e) {
			using (var ctx = new OrderITEntities()) {
				var result = ctx.CreateQuery<Order>("SELECT VALUE o FROM OrderITEntities.Orders AS o WHERE COUNT(SELECT VALUE DISTINCT(d.product.productid) FROM o.OrderDetails AS d) > 1");
				Dump(result);
			}
		}

		private void button6_Click(object sender, EventArgs e) {
			using (var ctx = new OrderITEntities()) {
				var result = ctx.CreateQuery<Order>("SELECT VALUE o FROM OrderITEntities.Orders AS o ORDER BY o.OrderId LIMIT 5");
				Dump(result);
			}
		}

		private void button7_Click(object sender, EventArgs e) {
			using (var ctx = new OrderITEntities()) {
				var result = ctx.CreateQuery<Order>("SELECT VALUE o FROM OrderITEntities.Orders AS o ORDER BY o.orderid SKIP 5 LIMIT 5");
				Dump(result);
			}
		}

		private void button8_Click(object sender, EventArgs e) {
			using (var ctx = new OrderITEntities()) {
				var result = ctx.CreateQuery<DbDataRecord>("SELECT c.CompanyId, c.Name FROM OrderITEntities.Companies AS c");
				Dump(result);
			}
		}

		private void button9_Click(object sender, EventArgs e) {
			var result = GetCompaniesProjection();
			Dump(result);
		}

		private void button10_Click(object sender, EventArgs e) {
			using (var ctx = new OrderITEntities()) {
				var result = ctx.CreateQuery<DbDataRecord>("SELECT (o.ShippingAddress.Address + '-' + o.ShippingAddress.City + '-' + o.ShippingAddress.Country + '-' + o.ShippingAddress.ZipCode) AS ShippingAddress FROM OrderITEntities.Orders AS o");
				Dump(result);
			}
		}

		private void button11_Click(object sender, EventArgs e) {
			using (var ctx = new OrderITEntities()) {
				var result = ctx.CreateQuery<DbDataRecord>("SELECT o.OrderId, o.OrderDate, ROW(o.ShippingAddress.City, o.ShippingAddress.Address) AS ShippingAddress FROM OrderITEntities.Orders AS o");
				Dump(result);
				textConsole.Text = String.Empty;
				foreach (var item in result) {
					textConsole.Text += ((DbDataRecord)item["ShippingAddress"])["Address"].ToString() + "\r\n";
				}
			}
		}

		private void button12_Click(object sender, EventArgs e) {
			using (var ctx = new OrderITEntities()) {
				var result = ctx.CreateQuery<DbDataRecord>("SELECT o.OrderId, o.OrderDate, o.Customer FROM OrderITEntities.Orders AS o");
				Dump(result);
			}
		}

		private void button13_Click(object sender, EventArgs e) {
			using (var ctx = new OrderITEntities()) {
				var result = ctx.CreateQuery<DbDataRecord>("SELECT o.OrderId, o.OrderDate, o.Customer.CompanyId, o.Customer.Name FROM OrderITEntities.Orders AS o");
				Dump(result);
			}
		}

		private void button14_Click(object sender, EventArgs e) {
			using (var ctx = new OrderITEntities()) {
				var result = ctx.CreateQuery<DbDataRecord>("SELECT o.OrderId, o.OrderDate, o.OrderDetails FROM OrderITEntities.Orders AS o");
				Dump(result);
				textConsole.Text = String.Empty;
				foreach (var item in result) {
					textConsole.Text += item["OrderId"].ToString() + "\r\n";
					foreach (var detail in (List<OrderDetail>)item["OrderDetails"])
						textConsole.Text = "  " + detail.OrderDetailId.ToString() + "\r\n";
				}
			}
		}

		private void button15_Click(object sender, EventArgs e) {
			using (var ctx = new OrderITEntities()) {
				var result = ctx.CreateQuery<DbDataRecord>("SELECT o.OrderId, o.OrderDate, (SELECT d.OrderDetailId, d.Product.ProductId, d.Quantity FROM o.OrderDetails As d) as Details FROM OrderITEntities.Orders AS o");
				Dump(result);
			}
		}

		private void button16_Click(object sender, EventArgs e) {
			using (var ctx = new OrderITEntities()) {
				var result = ctx.CreateQuery<DbDataRecord>("SELECT o.OrderId, o.OrderDate, SUM(SELECT VALUE (d.UnitPrice - d.Discount) * d.Quantity FROM o.OrderDetails As d) AS Total FROM OrderITEntities.Orders AS o");
				Dump(result);
			}
		}

		private void button17_Click(object sender, EventArgs e) {
			using (var ctx = new OrderITEntities()) {
				var result = ctx.CreateQuery<DbDataRecord>("SELECT o.ShippingAddress.City, (SELECT VALUE o2 FROM OrderITEntities.Orders AS o2 WHERE o.ShippingAddress.City = o2.ShippingAddress.City) AS Orders FROM OrderITEntities.Orders AS o GROUP BY o.ShippingAddress.City");
				Dump(result);
			}
		}

		public List<KeyValue<int, string>> GetCompaniesProjection() {
			using (var ctx = new OrderITEntities()) {
				var q = ctx.CreateQuery<DbDataRecord>("SELECT c.companyid, c.Name " +
					"FROM OrderITEntities.Companies AS c").ToList();
				return q.Select(i => new KeyValue<int, string>(
					(int)i["CompanyId"], i["Name"].ToString())).ToList();
			}
		}

		private void button18_Click(object sender, EventArgs e) {
			using (var ctx = new OrderITEntities()) {
				var result = ctx.CreateQuery<DbDataRecord>("SELECT o.ShippingAddress.City, o.ShippingAddress.ZipCode, (SELECT VALUE o2 FROM OrderITEntities.Orders AS o2 WHERE o.ShippingAddress.City = o2.ShippingAddress.City) AS Orders FROM OrderITEntities.Orders AS o GROUP BY o.ShippingAddress.City, o.ShippingAddress.ZipCode");
				Dump(result);
			}
		}

		private void button19_Click(object sender, EventArgs e) {
			using (var ctx = new OrderITEntities()) {
				var result = ctx.CreateQuery<DbDataRecord>("SELECT o.ShippingAddress.City, (SELECT o2.OrderId, o2.OrderDate FROM OrderITEntities.Orders AS o2 WHERE o.ShippingAddress.City = o2.ShippingAddress.City) AS details FROM OrderITEntities.Orders AS o GROUP BY o.ShippingAddress.City");
				Dump(result);
			}
		}

		private void button20_Click(object sender, EventArgs e) {
			using (var ctx = new OrderITEntities()) {
				var result = ctx.CreateQuery<DbDataRecord>("SELECT o.ShippingAddress.City, (SELECT VALUE o2 FROM OrderITEntities.Orders AS o2 WHERE o.ShippingAddress.City = o2.ShippingAddress.City) AS details FROM OrderITEntities.Orders AS o GROUP BY o.ShippingAddress.City HAVING COUNT(o.ShippingAddress.City) > 2");
				Dump(result);
			}
		}

		private void button21_Click(object sender, EventArgs e) {
			using (var ctx = new OrderITEntities()) {
				var result = ctx.CreateQuery<DbDataRecord>("SELECT VALUE o FROM OrderITEntities.Orders AS o ORDER BY o.ShippingAddress.City");
				Dump(result);
			}
		}

		private void button22_Click(object sender, EventArgs e) {
			using (var ctx = new OrderITEntities()) {
				var result = ctx.CreateQuery<DbDataRecord>("SELECT VALUE o FROM OrderITEntities.Orders AS o ORDER BY o.ShippingAddress.City, o.ShippingAddress.ZipCode");
				Dump(result);
			}
		}

		private void button23_Click(object sender, EventArgs e) {
			using (var ctx = new OrderITEntities()) {
				var result = ctx.CreateQuery<Order>("SELECT VALUE o FROM OrderITEntities.Orders AS o ORDER BY Sum(SELECT VALUE (d.UnitPrice - d.Discount) * d.Quantity FROM o.OrderDetails AS d)");
				Dump(result);
			}
		}

		private void button24_Click(object sender, EventArgs e) {
			using (var ctx = new OrderITEntities()) {
				var result = ctx.CreateQuery<DbDataRecord>("SELECT o.OrderId, o.OrderDate, (Select VALUE d FROM o.OrderDetails AS d ORDER BY d.Quantity) AS Details FROM OrderITEntities.Orders AS o");
				Dump(result);
			}
		}

		private void button25_Click(object sender, EventArgs e) {
			using (var ctx = new OrderITEntities()) {
				var result = ctx.CreateQuery<Order>("SELECT VALUE o FROM OrderITEntities.Orders AS o ORDER BY o.Customer.ShippingAddress.City");
				Dump(result);
			}
		}

		private void button26_Click(object sender, EventArgs e) {
			using (var ctx = new OrderITEntities()) {
				var result = ctx.CreateQuery<DbDataRecord>("SELECT o.OrderId, o.OrderDate FROM OrderITEntities.Orders AS o JOIN OrderITEntities.Companies AS c ON o.Customer.CompanyId = c.CompanyId AND o.ShippingAddress.City = c.ShippingCity");
				Dump(result);
			}
		}

		private void button27_Click(object sender, EventArgs e) {
			using (var ctx = new OrderITEntities()) {
				var result = ctx.CreateQuery<Customer>("SELECT VALUE c FROM OFTYPE(OrderITEntities.Companies, OrderIT.Model.Customer) AS c");
				Dump(result);
			}
		}

		private void button28_Click(object sender, EventArgs e) {
		}

		private void button29_Click(object sender, EventArgs e) {
			using (var ctx = new OrderITEntities()) {
				var result = ctx.Orders.Where("it.ShippingAddress.City = 'New York'");
				Dump(result);
			}
		}

		private void button30_Click(object sender, EventArgs e) {
			using (var ctx = new OrderITEntities()) {
				var city = "New York";
				var zipCode = String.Empty;
				ObjectQuery<Order> result = ctx.Orders;
				if (city != String.Empty)
					result = result.Where("it.ShippingAddress.City = '" + city + "'");
				if (zipCode != String.Empty)
					result = result.Where("it.ShippingAddress.ZipCode = '" + zipCode + "'");
				Dump(result);
			}
		}

		private void button31_Click(object sender, EventArgs e) {
			using (var ctx = new OrderITEntities()) {
				ObjectQuery<Order> result = ctx.Orders;
				result.Name = "o";
				result = result.Where("o.ShippingAddress.ZipCode = '98765'");
				result.Name = "o2";
				result = result.Where("o2.ShippingAddress.ZipCode = '98765'");
				Dump(result);
			}
		}

		private void button32_Click(object sender, EventArgs e) {
			using (var ctx = new OrderITEntities()) {
				var sortField = "City";
				var result = ctx.Orders.OrderBy("it.ShippingAddress." + sortField);
				Dump(result);
			}
		}

		private void button33_Click(object sender, EventArgs e) {
			using (var ctx = new OrderITEntities()) {
				var city = "New York";
				var result = ctx.Orders.Where("it.ShippingAddress.City = @city", new ObjectParameter("city", city));
				Dump(result);
			}
		}

		private void button34_Click(object sender, EventArgs e) {

			using (EntityConnection conn = new EntityConnection(Parameters.ConnectionString)) {
				using (EntityCommand comm = new EntityCommand("SELECT value o FROM OrderITEntities.OrderDetails AS o", conn)) {
					conn.Open();
					EntityDataReader reader = comm.ExecuteReader(CommandBehavior.SequentialAccess);
					using (var ctx = new OrderITEntities()) {
						textConsole.Text = String.Empty;
						var x = ctx.Translate<OrderDetail>(reader).ToList();
						var t = x[0].Discount; 
						//while (reader.Read()) {
							//textConsole.Text += reader[0].ToString() + "-" + reader[1].ToString() + "-" + reader[2].ToString() + "\r\n";
						//}
					}
				}
			}
		
			/*using (EntityConnection conn = new EntityConnection(Parameters.ConnectionString)) {
				using (EntityCommand comm = new EntityCommand("SELECT VALUE o FROM OrderITEntities.Orders AS o", conn)) {
					conn.Open();
					EntityDataReader reader = comm.ExecuteReader(CommandBehavior.SequentialAccess);
					textConsole.Text = String.Empty;
					while (reader.Read()) {
						textConsole.Text += reader[0].ToString() + "-" + reader[1].ToString() + "-" + reader[2].ToString() + "\r\n";
					}
				}
			}*/
		}
	}

	public class KeyValue<T, K> {
		public KeyValue(T id, K value) {
			Id = id;
			Value = value;
		}
		public T Id { get; set; }
		public K Value { get; set; }
	}
}