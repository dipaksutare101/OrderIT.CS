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
	public partial class CH16CustomerDTO : Form {
		public CH16CustomerDTO() {
			InitializeComponent();
		}
/*
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
*/
		private void btnRetrieveById_Click(object sender, EventArgs e)
		{
			using (CustomerDTOServiceClient proxy = new CustomerDTOServiceClient())
			{
				var customer = proxy.ReadCustomerUsingDTO(Convert.ToInt32(CustomerId.Text));
				CustomerName.Text = customer == null ? String.Empty : customer.Name;
				CustomerId.Tag = customer == null ? null : customer.Version;
				BillingAddress.Text = customer == null ? String.Empty : customer.BillingAddress.Address;
				BillingCity.Text = customer == null ? String.Empty : customer.BillingAddress.City;
				BillingCountry.Text = customer == null ? String.Empty : customer.BillingAddress.Country;
				BillingZipCode.Text = customer == null ? String.Empty : customer.BillingAddress.ZipCode;
				ShippingAddress.Text = customer == null ? String.Empty : customer.ShippingAddress.Address;
				ShippingCity.Text = customer == null ? String.Empty : customer.ShippingAddress.City;
				ShippingCountry.Text = customer == null ? String.Empty : customer.ShippingAddress.Country;
				ShippingZipCode.Text = customer == null ? String.Empty : customer.ShippingAddress.ZipCode;
				if (customer == null)
					MessageBox.Show("UserID doesn't exist");
			}
		}

		private void btnCreate_Click(object sender, EventArgs e)
		{
			using (CustomerDTOServiceClient proxy = new CustomerDTOServiceClient())
			{
				var cust = new CustomerDTO()
				{
					Name = CustomerName.Text,
					BillingAddress = new AddressInfo()
					{
						Address = BillingAddress.Text,
						City = BillingCity.Text,
						Country = BillingCountry.Text,
						ZipCode = BillingZipCode.Text
					},
					ShippingAddress = new AddressInfo()
					{
						Address = ShippingAddress.Text,
						City = ShippingCity.Text,
						Country = ShippingCountry.Text,
						ZipCode = ShippingZipCode.Text
					},
				};
				var id = proxy.CreateCustomerUsingDTO(cust);
				MessageBox.Show("Customer created with id " + id);
			}
		}

		private void btnUpdate_Click(object sender, EventArgs e)
		{
			using (CustomerDTOServiceClient proxy = new CustomerDTOServiceClient())
			{
				var cust = new CustomerDTO()
				{
					CompanyId = Convert.ToInt32(CustomerId.Text),
					Name = CustomerName.Text,
					Version = (Byte[])CustomerId.Tag,
					BillingAddress = new AddressInfo()
					{
						Address = BillingAddress.Text,
						City = BillingCity.Text,
						Country = BillingCountry.Text,
						ZipCode = BillingZipCode.Text
					},
					ShippingAddress = new AddressInfo()
					{
						Address = ShippingAddress.Text,
						City = ShippingCity.Text,
						Country = ShippingCountry.Text,
						ZipCode = ShippingZipCode.Text
					}
				};
				proxy.UpdateCustomerUsingDTO(cust);
				MessageBox.Show("Customer updated");
			}
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			using (CustomerDTOServiceClient proxy = new CustomerDTOServiceClient())
			{
				var id = Convert.ToInt32(CustomerId.Text);
				var version = (byte[])CustomerId.Tag;
				proxy.DeleteCustomerUsingDTO(id, version);
				MessageBox.Show("Customer deleted");
			}
		}
	}
}
