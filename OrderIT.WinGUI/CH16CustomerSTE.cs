using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OrderIT.WinGUI.WCFServiceReference;
using System.ServiceModel.Security;

namespace OrderIT.WinGUI {
	public partial class CH16CustomerSTE : Form {
		public CH16CustomerSTE() {
			InitializeComponent();
		}
/*
		private void button1_Click(object sender, EventArgs e) {
			using (OrderITServiceClient ctx = new OrderITServiceClient()) {
				Customer_customer = ctx.Read();
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
				//order.OrderDetails.RemoveAt(0);
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
				var_customer = ctx.ReadDTO();
				customer.Name = "Stefano Mostarda" + DateTime.Now.Second;
				ctx.UpdateDTO(customer);
			}
		}

		private void button4_Click(object sender, EventArgs e) {
			using (OrderITServiceClient ctx = new OrderITServiceClient()) {
				var_customer = ctx.ReadSTE();
				customer.Name = "Stefano Mostarda" + DateTime.Now.Second;
				ctx.UpdateSTE(customer);
			}
		}
*/
		OrderIT.Model.STE.Customer _customer;

		private void btnRetrieveById_Click(object sender, EventArgs e)
		{
			using (CustomerSTEServiceClient proxy = new CustomerSTEServiceClient())
			{
				_customer = proxy.ReadCustomerUsingSTE(Convert.ToInt32(CustomerId.Text));
				CustomerName.Text =_customer == null ? String.Empty :_customer.Name;
				CustomerId.Tag =_customer == null ? null :_customer.Version;
				BillingAddress.Text =_customer == null ? String.Empty :_customer.BillingAddress.Address;
				BillingCity.Text =_customer == null ? String.Empty :_customer.BillingAddress.City;
				BillingCountry.Text =_customer == null ? String.Empty :_customer.BillingAddress.Country;
				BillingZipCode.Text =_customer == null ? String.Empty :_customer.BillingAddress.ZipCode;
				ShippingAddress.Text =_customer == null ? String.Empty :_customer.ShippingAddress.Address;
				ShippingCity.Text =_customer == null ? String.Empty :_customer.ShippingAddress.City;
				ShippingCountry.Text =_customer == null ? String.Empty :_customer.ShippingAddress.Country;
				ShippingZipCode.Text =_customer == null ? String.Empty :_customer.ShippingAddress.ZipCode;
				if (_customer == null)
					MessageBox.Show("UserID doesn't exist");
			}
		}

		private void btnCreate_Click(object sender, EventArgs e)
		{
			using (CustomerSTEServiceClient proxy = new CustomerSTEServiceClient())
			{
				var cust = new OrderIT.Model.STE.Customer()
				{
					Name = CustomerName.Text,
					BillingAddress = new OrderIT.Model.STE.AddressInfo()
					{
						Address = BillingAddress.Text,
						City = BillingCity.Text,
						Country = BillingCountry.Text,
						ZipCode = BillingZipCode.Text
					},
					ShippingAddress = new OrderIT.Model.STE.AddressInfo()
					{
						Address = ShippingAddress.Text,
						City = ShippingCity.Text,
						Country = ShippingCountry.Text,
						ZipCode = ShippingZipCode.Text
					},
				};
				var id = proxy.CreateCustomerUsingSTE(cust);
				MessageBox.Show("Customer created with id " + id);
			}
		}

		private void btnUpdate_Click(object sender, EventArgs e)
		{
			using (CustomerSTEServiceClient proxy = new CustomerSTEServiceClient())
			{
				_customer.Name = CustomerName.Text;
				_customer.BillingAddress.Address = BillingAddress.Text;
				_customer.BillingAddress.City = BillingCity.Text;
				_customer.BillingAddress.Country = BillingCountry.Text;
				_customer.BillingAddress.ZipCode = BillingZipCode.Text;
				_customer.ShippingAddress.Address = ShippingAddress.Text;
				_customer.ShippingAddress.City = ShippingCity.Text;
				_customer.ShippingAddress.Country = ShippingCountry.Text;
				_customer.ShippingAddress.ZipCode = ShippingZipCode.Text;
				_customer.ChangeTracker.State = Model.STE.ObjectState.Modified;
				proxy.UpdateCustomerUsingSTE(_customer);
				MessageBox.Show("Customer updated");
			}
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			using (CustomerSTEServiceClient proxy = new CustomerSTEServiceClient())
			{
				_customer.ChangeTracker.State = Model.STE.ObjectState.Deleted;
				proxy.DeleteCustomerUsingSTE(_customer);
				MessageBox.Show("Customer deleted");
			}
		}
	}
}
