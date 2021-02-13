using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OrderIT.ModelIA;
using System.Data.Objects;
using System.Data.Objects.SqlClient;
using System.Data.Common;
using System.Transactions;

namespace OrderIT.WinGUI {	
	public partial class CH6_7_8OrdersIA : Form {
		public CH6_7_8OrdersIA()
		{
			InitializeComponent();
		}

		private void CreateOrder_Click(object sender, EventArgs e)
		{
			using (var transaction = new TransactionScope())
			{
				using (var ctx = new OrderITEntitiesIA())
				{
					var order = new Order
					{
						Customer = new Customer() { CompanyId = ((Customer)cmbCustomers.SelectedItem).CompanyId },
						OrderDate = DateTime.Now.Date,
						ShippingAddress = new AddressInfo()
						{
							Address = ShippingAddress.Text,
							City = ShippingCity.Text,
							Country = ShippingCountry.Text,
							ZipCode = ShippingZipCode.Text
						}
					};
					var r = new Random();
					foreach (var item in Details.Items)
					{
						var listItem = (ListViewItem)item;
						var detail = new OrderDetail()
						{
							OrderDetailId = r.Next(),
							Product = new Product { ProductId = ((OrderDetail)listItem.Tag).Product.ProductId },
							Quantity = Convert.ToInt32(listItem.SubItems[1].Text),
							UnitPrice = Convert.ToDecimal(listItem.SubItems[2].Text),
							Discount = Convert.ToDecimal(listItem.SubItems[3].Text)
						};
						order.OrderDetails.Add(detail);
					}
					ctx.Orders.AddObject(order);
					ctx.ObjectStateManager.ChangeObjectState(order.Customer, EntityState.Unchanged);
					foreach (var item in order.OrderDetails)
						ctx.ObjectStateManager.ChangeObjectState(item.Product, EntityState.Unchanged);

					ctx.SaveChanges();
					ctx.ExecuteStoreCommand("update product set availableitems = availableitems - od.Quantity from product p join [OrderDetail] od on od.ProductId = p.ProductId where od.orderid = {0}", order.OrderId);
					MessageBox.Show("Order created with id " + order.OrderId);
					OrderId.Text = order.OrderId.ToString();
				}
				transaction.Complete();
			}
		}

		private void UpdateOrder_Click(object sender, EventArgs e)
		{
			var order = new Order
			{
				OrderId = Convert.ToInt32(OrderId.Text),
				Customer = new Customer { CompanyId = ((Customer)cmbCustomers.SelectedItem).CompanyId },
				OrderDate = DateTime.ParseExact(OrderDate.Text, "dd/MM/yyyy", null),
				ActualShippingDate = String.IsNullOrWhiteSpace(ActualShippindDate.Text) ? null : new DateTime?(DateTime.ParseExact(ActualShippindDate.Text, "dd/MM/yyyy", null)),
				EstimatedShippingDate = String.IsNullOrWhiteSpace(EstimatedShippingDate.Text) ? null : new DateTime?(DateTime.ParseExact(EstimatedShippingDate.Text, "dd/MM/yyyy", null)),
				ShippingAddress = new AddressInfo()
				{
					Address = ShippingAddress.Text,
					City = ShippingCity.Text,
					Country = ShippingCountry.Text,
					ZipCode = ShippingZipCode.Text
				}
			};
			foreach (var item in Details.Items)
			{
				var listItem = (ListViewItem)item;
				var detail = new OrderDetail()
				{
					OrderDetailId = ((OrderDetail)listItem.Tag).OrderDetailId,
					Product = new Product { ProductId = ((OrderDetail)listItem.Tag).Product.ProductId },
					Quantity = Convert.ToInt32(listItem.SubItems[1].Text),
					UnitPrice = Convert.ToDecimal(listItem.SubItems[2].Text),
					Discount = Convert.ToDecimal(listItem.SubItems[3].Text),
				};
				order.OrderDetails.Add(detail);
			}

			using (var transaction = new TransactionScope())
			{
				using (var ctx = new ModelIA.OrderITEntitiesIA())
				{
					ctx.ExecuteStoreCommand("update product set availableitems = availableitems + od.Quantity from product p join [OrderDetail] od on od.ProductId = p.ProductId where od.orderid = {0}", order.OrderId);
					var dbOrder = ctx.Orders.Include("OrderDetails").First(o => o.OrderId == order.OrderId);
					var AddedDetails = order.OrderDetails.Except(dbOrder.OrderDetails).ToList();
					var RemovedDetails = dbOrder.OrderDetails.Except(order.OrderDetails).ToList();
					var ModifiedDetails = dbOrder.OrderDetails.Intersect(order.OrderDetails).ToList();
					dbOrder.Customer = order.Customer;
					ctx.Orders.ApplyCurrentValues(order);
					ctx.ObjectStateManager.ChangeObjectState(dbOrder.Customer, EntityState.Unchanged);
					AddedDetails.ForEach(d => dbOrder.OrderDetails.Add(d));
					RemovedDetails.ForEach(d => dbOrder.OrderDetails.Remove(d));
					ModifiedDetails.ForEach(d => ctx.OrderDetails.ApplyCurrentValues(d));
					ctx.ObjectStateManager.ChangeRelationshipState<ModelIA.Order>(dbOrder, dbOrder.Customer, o => o.Customer, EntityState.Deleted);
					ctx.SaveChanges();
					ctx.ExecuteStoreCommand("update product set availableitems = availableitems - od.Quantity from product p join [OrderDetail] od on od.ProductId = p.ProductId where od.orderid = {0}", order.OrderId);
				}
				transaction.Complete();
			}
		}

		private void DeleteOrderConnected_Click(object sender, EventArgs e) {
			using (var transaction = new TransactionScope())
			{
				using (var ctx = new ModelIA.OrderITEntitiesIA())
				{
					var order = new ModelIA.Order() { OrderId = Convert.ToInt32(OrderId.Text) };
					order.Customer = new ModelIA.Customer() { CompanyId = ((Customer)cmbCustomers.SelectedItem).CompanyId };
					ctx.Orders.Attach(order);
					ctx.Orders.DeleteObject(order);
					ctx.SaveChanges();
					ctx.ExecuteStoreCommand("update product set availableitems = availableitems + od.Quantity from product p join [OrderDetail] od on od.ProductId = p.ProductId where od.orderid = {0}", OrderId.Text);
				}
				transaction.Complete();
			}
		}

		private void DeleteOrderDisconnected_Click(object sender, EventArgs e)
		{
			using (var transaction = new TransactionScope())
			{
				using (var ctx = new ModelIA.OrderITEntitiesIA())
				{
					var id = Convert.ToInt32(OrderId.Text);
					var order = ctx.Orders.First(o => o.OrderId == id);
					ctx.Orders.DeleteObject(order);
					ctx.SaveChanges();
					ctx.ExecuteStoreCommand("update product set availableitems = availableitems + od.Quantity from product p join [OrderDetail] od on od.ProductId = p.ProductId where od.orderid = {0}", OrderId.Text);
				}
				transaction.Complete();
			}
		}

		private void CH6_Load(object sender, EventArgs e)
		{
			using (var ctx = new OrderITEntitiesIA())
			{
				ctx.ContextOptions.ProxyCreationEnabled = false;
				cmbCustomers.DataSource = ctx.Companies.OfType<Customer>().ToList();
				cmbProducts.DataSource = ctx.Products.ToList();
			}
		}

		private void button2_Click(object sender, EventArgs e) {
			var order = new ModelIA.Order { OrderId = 11, Customer = new ModelIA.Customer { CompanyId = 1 }, OrderDate = DateTime.Now.Date };
			var detail = new ModelIA.OrderDetail { OrderDetailId = 40, Product = new ModelIA.Product { ProductId = 1 } };
			var cust = new Customer { CompanyId = 2 };
			using (var ctx = new ModelIA.OrderITEntitiesIA()) {
				ctx.Orders.Attach(order);
				order.OrderDetails.Add(detail);
				ctx.DetectChanges();
			}
		}

		private void cmbCustomers_SelectedIndexChanged(object sender, EventArgs e)
		{
			var customer = (Customer)cmbCustomers.SelectedItem;
			ShippingAddress.Text = customer.ShippingAddress.Address;
			ShippingCity.Text = customer.ShippingAddress.City;
			ShippingCountry.Text = customer.ShippingAddress.Country;
			ShippingZipCode.Text = customer.ShippingAddress.ZipCode;
		}

		private void btnRetrieveById_Click(object sender, EventArgs e)
		{
			using (var ctx = new OrderITEntitiesIA())
			{
				ctx.ContextOptions.ProxyCreationEnabled = false;
				var id = Convert.ToInt32(OrderId.Text);
				var order = ctx.Orders.Include("Customer").Include("OrderDetails.Product").FirstOrDefault(c => c.OrderId == id);
				if (order == null)
				{
					MessageBox.Show("Order doesn't exist");
				}
				else
				{
					cmbCustomers.SelectedItem = cmbCustomers.Items.Cast<Customer>().First(c => c.CompanyId == order.Customer.CompanyId);
					ShippingAddress.Text = order.ShippingAddress.Address;
					ShippingCity.Text = order.ShippingAddress.City;
					ShippingCountry.Text = order.ShippingAddress.Country;
					ShippingZipCode.Text = order.ShippingAddress.ZipCode;
					OrderDate.Text = order.OrderDate.ToString("dd/MM/yyyy");
					EstimatedShippingDate.Text = (order.EstimatedShippingDate.HasValue) ? order.EstimatedShippingDate.Value.ToString("dd/MM/yyyy") : String.Empty;
					ActualShippindDate.Text = (order.ActualShippingDate.HasValue) ? order.ActualShippingDate.Value.ToString("dd/MM/yyyy") : String.Empty;

					Details.Items.Clear();
					foreach (var detail in order.OrderDetails)
					{
						Details.Items.Add(new ListViewItem(new string[] { detail.Product.Name, detail.Quantity.ToString(), detail.UnitPrice.ToString(), detail.Discount.ToString() }) { Tag = detail });
					}
				}
			}
		}

		private void RemoveDetail_Click(object sender, EventArgs e)
		{
			for (var i = 0; i < Details.SelectedItems.Count; i++)
			{
				Details.Items.Remove(Details.SelectedItems[i]);
			}
		}

		private void AddDetail_Click(object sender, EventArgs e)
		{
			Details.Items.Add(new ListViewItem(new string[] { cmbProducts.Text, txtOrderQuantity.Text, txtOrderPrice.Text, txtOrderDiscount.Text }) { Tag = new OrderDetail() { Product = ((Product)cmbProducts.SelectedValue), OrderDetailId = new Random().Next() * -1 } });
		}

	}
}