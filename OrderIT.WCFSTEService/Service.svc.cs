using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using OrderIT.Model.STE;

namespace OrderIT.STE.CustomerService {
	public class Service : IService {
		public Customer ReadCustomer(int customerId) {
			using (OrderITEntities ctx = new OrderITEntities()) {
				return ctx.Companies.OfType<Customer>().FirstOrDefault(c => c.CompanyId == customerId);
			}
		}

		public void UpdateCustomer(Customer c) {
			using (OrderITEntities ctx = new OrderITEntities()) {
				ctx.Companies.ApplyChanges(c);
				ctx.SaveChanges();
			}
		}

		public Order ReadOrder(int orderId) {
			using (OrderITEntities ctx = new OrderITEntities()) {
				return ctx.Orders.Include("OrderDetails").FirstOrDefault(o => o.OrderId == orderId);
			}
		}

		public void UpdateOrder(Order o) {
			using (OrderITEntities ctx = new OrderITEntities()) {
				ctx.Orders.ApplyChanges(o);
				ctx.SaveChanges();
			}
		}

		public Supplier ReadSupplier(int supplierId) {
			using (OrderITEntities ctx = new OrderITEntities()) {
				var su = ctx.Companies.OfType<Supplier>().First(s => s.CompanyId == supplierId);
				return su;
			}
		}

		public void UpdateSupplier(Supplier s) {
			using (OrderITEntities ctx = new OrderITEntities()) {
				ctx.Companies.ApplyChanges(s);
				try {
					ctx.SaveChanges();
				}
				catch (Exception e){
					String h = "";
				}
			}
		}
	}
}