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
using System.Data.Common;
using System.Transactions;

namespace OrderIT.WinGUI {
	public partial class CH6_7_8Customers : Form {
		public CH6_7_8Customers() {
			InitializeComponent();
		}

		private void btnCreateCustomer_Click(object sender, EventArgs e) {
			using (var ctx = new OrderITEntities()) {
				var cust = new Customer() {
					Name = CustomerName.Text,
					BillingAddress = new AddressInfo() {
						Address = BillingAddress.Text,
						City = BillingCity.Text,
						Country = BillingCountry.Text,
						ZipCode = BillingZipCode.Text
					},
					ShippingAddress = new AddressInfo() {
						Address = ShippingAddress.Text,
						City = ShippingCity.Text,
						Country = ShippingCountry.Text,
						ZipCode = ShippingZipCode.Text
					},
					WSEnabled = WSEnabled.Checked,
					WSUserName = WSUsername.Text,
					WSPassword = WSPassword.Text
				};
				ctx.Companies.AddObject(cust);
				ctx.SaveChanges();
				MessageBox.Show("Customer created with id = " + cust.CompanyId);
			}
		}

		private void btnUpdateCustomerConnected_Click(object sender, EventArgs e) {
			using (var ctx = new OrderITEntities()) {
				var id = Convert.ToInt32(CustomerId.Text);
				var cust = ctx.Companies.OfType<Customer>().First(c => c.CompanyId == id);
				cust.Name = CustomerName.Text;
				cust.WSEnabled = WSEnabled.Checked;
				cust.WSUserName = WSUsername.Text;
				cust.WSPassword = WSPassword.Text;
				cust.BillingAddress.Address = BillingAddress.Text;
				cust.BillingAddress.City = BillingCity.Text;
				cust.BillingAddress.Country = BillingCountry.Text;
				cust.BillingAddress.ZipCode = BillingZipCode.Text;
				cust.ShippingAddress.Address = ShippingAddress.Text;
				cust.ShippingAddress.City = ShippingCity.Text;
				cust.ShippingAddress.Country = ShippingCountry.Text;
				cust.ShippingAddress.ZipCode = ShippingZipCode.Text;
				try {
					ctx.SaveChanges();
					MessageBox.Show("Customer updated");
				}
				catch (OptimisticConcurrencyException ex) {
					var errorEntry = ex.StateEntries.First();
					ctx.Refresh(RefreshMode.ClientWins, errorEntry.Entity);
					var form = new EntriesComparer(errorEntry);
					form.ShowDialog();
					if (form.ApplyChanges) {
						ctx.SaveChanges();
						MessageBox.Show("Customer updated");
					}
				}
			}
		}

		private void btnUpdateCustomerChangeObjectState_Click(object sender, EventArgs e) {
			var cust = new Customer() {
				CompanyId = Convert.ToInt32(CustomerId.Text),
				Name = CustomerName.Text,
				Version = (Byte[])CustomerId.Tag,
				BillingAddress = new AddressInfo() {
					Address = BillingAddress.Text,
					City = BillingCity.Text,
					Country = BillingCountry.Text,
					ZipCode = BillingZipCode.Text
				},
				ShippingAddress = new AddressInfo() {
					Address = ShippingAddress.Text,
					City = ShippingCity.Text,
					Country = ShippingCountry.Text,
					ZipCode = ShippingZipCode.Text
				},
				WSEnabled = WSEnabled.Checked,
				WSUserName = WSUsername.Text,
				WSPassword = WSPassword.Text
			};
			UpdateCustomerWithChangeObjectState(cust);
		}

		private void UpdateCustomerWithChangeObjectState(Customer cust) {
			using (var ctx = new OrderITEntities()) {
				ctx.Companies.Attach(cust);
				ctx.ObjectStateManager.ChangeObjectState(cust, EntityState.Modified);
				try {
					ctx.SaveChanges();
					MessageBox.Show("Customer updated");
				}
				catch (OptimisticConcurrencyException ex) {
					var errorEntry = ex.StateEntries.First();
					ctx.Refresh(RefreshMode.ClientWins, errorEntry.Entity);
					var form = new EntriesComparer(errorEntry);
					form.ShowDialog();
					if (form.ApplyChanges) {
						ctx.SaveChanges();
						MessageBox.Show("Customer updated");
					}
				}
			}
		}

		private void btnUpdateCustomerApplyCurrentValues_Click(object sender, EventArgs e) {
			var cust = new Customer() {
				CompanyId = Convert.ToInt32(CustomerId.Text),
				Name = CustomerName.Text,
				Version = (Byte[])CustomerId.Tag,
				BillingAddress = new AddressInfo() {
					Address = BillingAddress.Text,
					City = BillingCity.Text,
					Country = BillingCountry.Text,
					ZipCode = BillingZipCode.Text
				},
				ShippingAddress = new AddressInfo() {
					Address = ShippingAddress.Text,
					City = ShippingCity.Text,
					Country = ShippingCountry.Text,
					ZipCode = ShippingZipCode.Text
				},
				WSEnabled = WSEnabled.Checked,
				WSUserName = WSUsername.Text,
				WSPassword = WSPassword.Text
			};
			UpdateCustomerWithApplyCurrentValues(cust);
		}

		private void UpdateCustomerWithApplyCurrentValues(Customer cust) {
			using (var ctx = new OrderITEntities()) {
				var dbCust = ctx.Companies.OfType<Customer>().First(c => c.CompanyId == cust.CompanyId);
				ctx.Companies.ApplyCurrentValues(cust);
				var entry = ctx.ObjectStateManager.GetObjectStateEntry(dbCust);
				var origValues = entry.GetUpdatableOriginalValues();
				origValues.SetValue(origValues.GetOrdinal("Version"), cust.Version);
				try {
					ctx.SaveChanges();
					MessageBox.Show("Customer updated");
				}
				catch (OptimisticConcurrencyException ex) {
					var errorEntry = ex.StateEntries.First();
					ctx.Refresh(RefreshMode.ClientWins, errorEntry.Entity);
					var form = new EntriesComparer(errorEntry);
					form.ShowDialog();
					if (form.ApplyChanges) {
						ctx.SaveChanges();
						MessageBox.Show("Customer updated");
					}
				}
			}
		}

		private void btnDeleteCustomer_Click(object sender, EventArgs e) {
			using (var ctx = new OrderITEntities()) {
				var id = Convert.ToInt32(CustomerId.Text);
				var customer = ctx.Companies.OfType<Customer>().First(c => c.CompanyId == id);
				ctx.DeleteObject(customer);
				ctx.SaveChanges();
				MessageBox.Show("Customer deleted");
			}
		}

		private void btnDeleteCustomerDisconnected_Click(object sender, EventArgs e) {
			using (var ctx = new OrderITEntities())
			{
				Customer cust = new Customer() { CompanyId = Convert.ToInt32(CustomerId.Text), BillingAddress = new AddressInfo(), ShippingAddress = new AddressInfo() };
				ctx.Companies.Attach(cust);
				ctx.DeleteObject(cust);
				ctx.SaveChanges();
				MessageBox.Show("Customer deleted");
			}
		}

		private void CH6_Load(object sender, EventArgs e) {
		}

		private void button3_Click(object sender, EventArgs e)
		{
			using (var ctx = new OrderITEntities())
			{
				var cust = new Customer()
				{
					Name = "Stefano Mostarda",
					BillingAddress = new AddressInfo() { Address = "via", City = "city", Country = "country", ZipCode = "zip" },
					ShippingAddress = new AddressInfo() { Address = "via", City = "city", Country = "country", ZipCode = "zip" },
					WSEnabled = false,
					WSPassword = String.Empty,
					WSUserName = String.Empty
				};
				ctx.Companies.AddObject(cust);
				using (var transaction = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions() { IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted }))
				{
					ctx.SaveChanges(SaveOptions.DetectChangesBeforeSave);
					using (var altCtx = new OrderITEntities("name=OrderITEntities2"))
					{
						var newCust = new Customer()
						{
							Name = "Marco De Sanctis",
							BillingAddress = new AddressInfo() { Address = "via", City = "city", Country = "country", ZipCode = "zip" },
							ShippingAddress = new AddressInfo() { Address = "via", City = "city", Country = "country", ZipCode = "zip" },
							WSEnabled = false,
							WSPassword = String.Empty,
							WSUserName = String.Empty
						};
						altCtx.Companies.AddObject(newCust);
						altCtx.SaveChanges();
					}
					transaction.Complete();
					ctx.AcceptAllChanges();
				}
			}
		}

		private void btnRetrieveById_Click(object sender, EventArgs e)
		{
			using (var ctx = new OrderITEntities())
			{
				int id = Convert.ToInt32(CustomerId.Text);
				var customer = ctx.Companies.OfType<Customer>().FirstOrDefault(c => c.CompanyId == id);
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
				WSUsername.Text = customer == null ? String.Empty : customer.WSUserName;
				WSPassword.Text = customer == null ? String.Empty : customer.WSPassword;
				WSEnabled.Checked = customer == null ? false : customer.WSEnabled ?? false;
				if (customer == null)
					MessageBox.Show("UserID doesn't exist");
			}
		}
	}
}