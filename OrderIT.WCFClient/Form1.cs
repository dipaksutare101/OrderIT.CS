using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OrderIT.WCFClient.WCFServiceReference;
using System.ServiceModel.Security;

namespace OrderIT.WCFClient {
	public partial class Form1 : Form {
		public Form1() {
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e) {
			using (OrderITServiceClient ctx = new OrderITServiceClient()) {
				Customer customer = ctx.Read();
				customer.Name = "Stefano Mostarda" + DateTime.Now.Second;
				ctx.Update(customer);
			}
		}

		private void button2_Click(object sender, EventArgs e) {
			using (OrderITServiceClient ctx = new OrderITServiceClient()) {
				var order = ctx.ReadOrder(49);
				order.ShippingAddress.Address = "7th avenue";
				order.ShippingAddress.City = "New York";
				order.ShippingAddress.Country = "USA";
				order.ShippingAddress.ZipCode = "7777";
				order.OrderDetails.RemoveAt(0);
				order.OrderDetails[0].Quantity = 4;
				OrderDetail d1 = new OrderDetail();
				d1.ProductId = 1;
				d1.Quantity = 5;
				d1.UnitPrice = 10;
				d1.Discount = 0;
				order.OrderDetails.Add(d1);
				ctx.UpdateOrder(order);
			}
		}

		private void button3_Click(object sender, EventArgs e) {
			using (OrderITServiceClient ctx = new OrderITServiceClient()) {
				var customer = ctx.ReadDTO();
				customer.Name = "Stefano Mostarda" + DateTime.Now.Second;
				ctx.UpdateDTO(customer);
			}
		}

		private void button4_Click(object sender, EventArgs e) {
			using (OrderITServiceClient ctx = new OrderITServiceClient()) {
				var customer = ctx.ReadSTE();
				customer.Name = "Stefano Mostarda" + DateTime.Now.Second;
				ctx.UpdateSTE(customer);
			}
		}
	}
}
