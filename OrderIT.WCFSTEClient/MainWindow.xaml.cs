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
using OrderIT.STE.Client.CustomerService;
using OrderIT.STE.Model;

namespace OrderIT.STE.Client {
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window {
		public MainWindow() {
			InitializeComponent();
		}

		private void button1_Click(object sender, RoutedEventArgs e) {
			using (var proxy = new ServiceClient()) {
				Customer c = proxy.ReadCustomer(1);
				c.Name = "Stefano Mostarda" + DateTime.Now.Second;
				proxy.UpdateCustomer(c);
			}
		}

		private void button2_Click(object sender, RoutedEventArgs e) {
			using (var proxy = new ServiceClient()) {
				var o = proxy.ReadOrder(10);
				o.OrderDetails.Add(new OrderDetail() {
					Discount = 0,
					ProductId = 3,
					Quantity = 10,
					UnitPrice = 15
				});
				o.ShippingAddress.Address = "8th Avenue";
				proxy.UpdateOrder(o);
			}
		}

		private void button3_Click(object sender, RoutedEventArgs e) {
			using (var proxy = new ServiceClient()) {
				Supplier s = proxy.ReadSupplier(3);
				Product p = new Product { ProductId = 3 };
				p.MarkAsUnchanged();
				s.Products.Add(p);
				proxy.UpdateSupplier(s);
			}
		}
	}
}
