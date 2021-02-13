using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OrderIT.Model;
using System.Data.EntityClient;
using System.Configuration;
using System.Data.Objects;

namespace OrderIT.WinGUI {
	public partial class CH17 : Form {
		public CH17() {
			InitializeComponent();
		}
		OrderITEntities ctx = new OrderITEntities();
		Order _currentOrder; 
		private void CH15_Load(object sender, EventArgs e) {
			orderDetailsBindingSource.DataSource = orderBindingSource;
			orderDetailsBindingSource.DataMember = "OrderDetails";
			ctx.ContextOptions.LazyLoadingEnabled = false;
			customerBindingSource.DataSource = ctx.Companies.OfType<Customer>().ToList();
			productBindingSource.DataSource = ctx.Products.ToList();
			orderBindingSource.DataSource = new BindingList<Order>(ctx.Orders.Include("OrderDetails").ToList());
			discountTextBox.DataBindings.Add("Text", orderDetailsBindingSource, "Discount");
			productIdComboBox.DataBindings.Add("SelectedValue", orderDetailsBindingSource, "ProductId");
			quantityTextBox.DataBindings.Add("Text", orderDetailsBindingSource, "Quantity");
			unitPriceTextBox.DataBindings.Add("Text", orderDetailsBindingSource, "UnitPrice");
		}

		private void Save_Click(object sender, EventArgs e) {
			var datasource = ((BindingList<Order>)orderBindingSource.DataSource);
			foreach (var order in datasource.Where(o => o.OrderId == 0)) {
				ctx.Orders.AddObject(order);
			}
			ctx.ObjectStateManager.GetObjectStateEntries(System.Data.EntityState.Modified).Select(c => c.Entity).OfType<OrderDetail>().Where(c => c.Order == null).ToList().ForEach(c => ctx.DeleteObject(c));
			ctx.SaveChanges();
		}

		private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e) {
			ctx.Orders.DeleteObject((Order)orderBindingSource.Current);
		}

		private void toolStripButton1_Click(object sender, EventArgs e) {
			Validate();
		}

		private void toolStripButton2_Click(object sender, EventArgs e) {
			orderBindingSource.CancelEdit();
		}
	}
}
