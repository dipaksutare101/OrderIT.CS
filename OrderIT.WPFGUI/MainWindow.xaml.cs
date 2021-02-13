using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using OrderIT.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace OrderIT.WPFGUI {
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window {
		public MainWindow() {
			InitializeComponent();
		}

		OrderITEntities ctx = new OrderITEntities();
		private void Window_Loaded(object sender, RoutedEventArgs e) {
			var orders = new ObservableCollection<Order>(ctx.Orders.Include("OrderDetails").ToList());
			orders.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(order_CollectionChanged);
			DataContext = orders;
			Customers.ItemsSource = ctx.Companies.OfType<Customer>().ToList();
			Products.ItemsSource = ctx.Products.ToList();
		}

		void order_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) {
			if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove) {
				foreach (Order item in e.OldItems) {
					ctx.Orders.DeleteObject(item);
				}
			}
			else if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add) {
				ctx.Orders.AddObject((Order)e.NewItems[0]);
			}
		}

		private void Button_Click(object sender, RoutedEventArgs e) {
			ctx.ObjectStateManager.GetObjectStateEntries(System.Data.EntityState.Modified).Select(c => c.Entity).OfType<OrderDetail>().Where(c => c.Order == null).ToList().ForEach(c => ctx.DeleteObject(c));
			ctx.DetectChanges();
			MessageBox.Show(orderDataGrid.Items.Count.ToString() + "-" + 
				ctx.ObjectStateManager.GetObjectStateEntries(System.Data.EntityState.Added).Count() + "-" +
				ctx.ObjectStateManager.GetObjectStateEntries(System.Data.EntityState.Modified).Count() + "-" +
				ctx.ObjectStateManager.GetObjectStateEntries(System.Data.EntityState.Deleted).Count());
			//ctx.SaveChanges();
		}
	}
}
