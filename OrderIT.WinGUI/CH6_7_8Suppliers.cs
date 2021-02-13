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
	public partial class CH6_7_8Suppliers : Form {
		public CH6_7_8Suppliers()
		{
			InitializeComponent();
		}

		private void AddProductTosupplier_Click(object sender, EventArgs e) {
			using (var ctx = new OrderITEntities()) {
				var s = ctx.Companies.OfType<Supplier>().First();
				var p = ctx.Products.First();
				s.Products.Add(p);
			}
		}

		private void btnCreateSupplier_Click(object sender, EventArgs e) {
			using (var ctx = new OrderITEntities()) {
				var supplier = new Supplier()
				{
					Name = SupplierName.Text,
					IBAN = IBAN.Text,
					PaymentDays = String.IsNullOrWhiteSpace(PaymentDays.Text) ? null : new short?(Convert.ToByte(PaymentDays.Text))
				};
				foreach (var item in ProductsSold.Items.Cast<ListViewItem>())
				{
					if (item.Checked)
					{
						supplier.Products.Add((Product)item.Tag);
					}
				}
				ctx.Companies.AddObject(supplier);
				ctx.ObjectStateManager.GetObjectStateEntries(EntityState.Added).Where(en => en.Entity is Product).ForEach(en => en.ChangeState(EntityState.Unchanged));
				ctx.SaveChanges();
				MessageBox.Show("Supplier created with id " + supplier.CompanyId);
			}
		}

		private void btnUpdateSupplierConnected_Click(object sender, EventArgs e) {
			using (var ctx = new OrderITEntities()) {
				var id = Convert.ToInt32(SupplierId.Text);
				var supp = ctx.Companies.OfType<Supplier>().First(c => c.CompanyId == id);
				supp.Name = SupplierName.Text;
				supp.IBAN = IBAN.Text;
				supp.PaymentDays = String.IsNullOrWhiteSpace(PaymentDays.Text) ? null : new short?(Convert.ToByte(PaymentDays.Text));
				ctx.SaveChanges();
				MessageBox.Show("Supplier updated");
			}
		}

		private void btnUpdateSupplierChangeObjectState_Click(object sender, EventArgs e) {
			var supp = new Supplier() {
				CompanyId = Convert.ToInt32(SupplierId.Text),
				Name = SupplierName.Text,
				IBAN = IBAN.Text,
				PaymentDays = Convert.ToInt16(PaymentDays.Text),
				Version = (byte[])SupplierId.Tag
			};
			UpdateSupplierWithChangeObjectState(supp);
		}

		private void UpdateSupplierWithChangeObjectState(Supplier supp) {
			using (var ctx = new OrderITEntities()) {
				ctx.Companies.Attach(supp);
				ctx.ObjectStateManager.ChangeObjectState(supp, EntityState.Modified);
				try
				{
					ctx.SaveChanges();
					MessageBox.Show("Supplier updated");
				}
				catch (OptimisticConcurrencyException ex)
				{
					var errorEntry = ex.StateEntries.First();
					ctx.Refresh(RefreshMode.ClientWins, errorEntry.Entity);
					var form = new EntriesComparer(errorEntry);
					form.ShowDialog();
					if (form.ApplyChanges)
					{
						ctx.SaveChanges();
						MessageBox.Show("Supplier updated");
					}
				}
			}
		}

		private void btnUpdateSupplierApplyCurrentValues_Click(object sender, EventArgs e) {
			var supp = new Supplier() {
				CompanyId = Convert.ToInt32(SupplierId.Text),
				Name = SupplierName.Text,
				IBAN = IBAN.Text,
				PaymentDays = Convert.ToInt16(PaymentDays.Text),
				Version = (byte[])SupplierId.Tag
			};
			UpdateSupplierWithApplyCurrentValues(supp);
		}

		private void UpdateSupplierWithApplyCurrentValues(Supplier supplier) {
			using (var ctx = new OrderITEntities()) {
				var dbSupplier = ctx.Companies.OfType<Supplier>().First(c => c.CompanyId == supplier.CompanyId);
				ctx.Companies.ApplyCurrentValues(supplier);
				var entry = ctx.ObjectStateManager.GetObjectStateEntry(dbSupplier);
				var origValues = entry.GetUpdatableOriginalValues();
				origValues.SetValue(origValues.GetOrdinal("Version"), supplier.Version);
				try
				{
					ctx.SaveChanges();
					MessageBox.Show("Supplier updated");
				}
				catch (OptimisticConcurrencyException ex)
				{
					var errorEntry = ex.StateEntries.First();
					ctx.Refresh(RefreshMode.ClientWins, errorEntry.Entity);
					var form = new EntriesComparer(errorEntry);
					form.ShowDialog();
					if (form.ApplyChanges)
					{
						ctx.SaveChanges();
						MessageBox.Show("Supplier updated");
					}
				}
			}
		}

		private void btnDeleteSupplierConnected_Click(object sender, EventArgs e) {
			using (var ctx = new OrderITEntities()) {
				var id = Convert.ToInt32(SupplierId.Text);
				var supplier = ctx.Companies.OfType<Supplier>().First(c => c.CompanyId == id);
				ctx.DeleteObject(supplier);
				ctx.SaveChanges();
				MessageBox.Show("Supplier deleted");
			}
		}

		private void btnDeleteSupplierDisconnected_Click(object sender, EventArgs e) {
			var supplier = new Supplier() { CompanyId = Convert.ToInt32(SupplierId.Text), Version = (byte[])SupplierId.Tag };
			DeleteSupplierDisconnected(supplier);
		}

		private void DeleteSupplierDisconnected(Supplier supplier) {
			using (var ctx = new OrderITEntities()) {
				ctx.Companies.Attach(supplier);
				ctx.DeleteObject(supplier);
				ctx.SaveChanges();
				MessageBox.Show("Supplier deleted");
			}
		}

		private void btnRetrieveById_Click(object sender, EventArgs e)
		{
			ProductsSold.ItemChecked -= new ItemCheckedEventHandler(ProductsSold_ItemChecked);
			using (var ctx = new OrderITEntities())
			{
				int id = Convert.ToInt32(SupplierId.Text);
				var supplier = ctx.Companies.OfType<Supplier>().Include(s => s.Products).FirstOrDefault(c => c.CompanyId == id);
				SupplierName.Text = supplier == null ? String.Empty : supplier.Name;
				SupplierId.Tag = supplier == null ? null : supplier.Version;
				IBAN.Text = supplier == null ? String.Empty : supplier.IBAN;
				PaymentDays.Text = supplier == null ? String.Empty : supplier.PaymentDays.ToString();
				if (supplier == null)
					MessageBox.Show("Supplier doesn't exist");
				else
				{
					ProductsSold.Items.Cast<ListViewItem>().ForEach(c => c.Checked = false);
					foreach (var item in supplier.Products)
					{
						ProductsSold.Items.Cast<ListViewItem>().First(c => c.Text == item.Name).Checked = true;
					}
				}
			}
			ProductsSold.ItemChecked += new ItemCheckedEventHandler(ProductsSold_ItemChecked);
		}

		private void CH6_7_8Suppliers_Load(object sender, EventArgs e)
		{
			ProductsSold.ItemChecked -= new ItemCheckedEventHandler(ProductsSold_ItemChecked);
			using (var ctx = new OrderITEntities())
			{
				ctx.ContextOptions.ProxyCreationEnabled = false;
				foreach (var item in ctx.Products.ToList())
					ProductsSold.Items.Add(new ListViewItem(item.Name) { Tag = item });
			}
		}

		private void ProductsSold_ItemChecked(object sender, ItemCheckedEventArgs e)
		{
			using (var ctx = new OrderITEntities()) {
				var supplier = new Supplier() { CompanyId = Convert.ToInt32(SupplierId.Text) };
				var product = new Product() { ProductId = ((Product)e.Item.Tag).ProductId };
				ctx.Companies.Attach(supplier);
				ctx.Products.Attach(product);
				if (!e.Item.Checked)
				{
					ctx.ObjectStateManager.ChangeRelationshipState(supplier, product, s => s.Products, EntityState.Deleted);
				}
				else
				{
					supplier.Products.Add(product);
				}
				ctx.SaveChanges();
				MessageBox.Show("Supplier deleted");
			}
		}
	}
}