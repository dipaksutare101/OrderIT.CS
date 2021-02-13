using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using OrderIT.Model;
using OrderIT.Model.STE;
using System.Data;

namespace OrderIT.WCFService {
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
	public class OrderITService : IOrderService, IOrderSTEService, ICustomerDTOService, ICustomerService, ICustomerSTEService {

		/*ICustomerService Interface*/
		public int CreateCustomer(Model.Customer customer)
		{
			using (var ctx = new OrderIT.Model.OrderITEntities())
			{
				ctx.Companies.AddObject(customer);
				ctx.SaveChanges();
				return customer.CompanyId;
			}
		}

		public Model.Customer ReadCustomer(int customerId)
		{
			using (var ctx = new OrderIT.Model.OrderITEntities())
			{
				var result = ctx.Companies.OfType<OrderIT.Model.Customer>().FirstOrDefault(c => c.CompanyId == customerId);
				if (result != null)
					result.WSPassword = String.Empty;
				return result;
			}
		}

		public void UpdateCustomer(Model.Customer customer)
		{
			using (var ctx = new OrderIT.Model.OrderITEntities())
			{
				ctx.Companies.Attach(customer);
				var entry = ctx.ObjectStateManager.GetObjectStateEntry(customer);
				entry.SetModifiedProperty("ShippingAddress");
				entry.SetModifiedProperty("BillingAddress");
				entry.SetModifiedProperty("Name");
				entry.SetModifiedProperty("Version");
				ctx.SaveChanges();
			}
		}

		public void DeleteCustomer(int customerId, byte[] version)
		{
			using (var ctx = new OrderIT.Model.OrderITEntities())
			{
				var customerToDelete = new OrderIT.Model.Customer
				{
					CompanyId = customerId,
					Version = version
				};
				ctx.Companies.Attach(customerToDelete);
				ctx.Companies.DeleteObject(customerToDelete);
				ctx.SaveChanges();
			}
		}


		/*ICustomerDTOService Interface*/
		public int CreateCustomerUsingDTO(CustomerDTO customer)
		{
			using (var ctx = new OrderIT.Model.OrderITEntities())
			{
				var customerToAdd = new OrderIT.Model.Customer
				{
					BillingAddress = customer.BillingAddress,
					Name = customer.Name,
					ShippingAddress = customer.ShippingAddress,
					WSEnabled = false
				};
				ctx.Companies.AddObject(customerToAdd);
				ctx.SaveChanges();
				return customerToAdd.CompanyId;
			}
		}

		public CustomerDTO ReadCustomerUsingDTO(int customerId)
		{
			using (var ctx = new OrderIT.Model.OrderITEntities())
			{
				return ctx.Companies.OfType<OrderIT.Model.Customer>().Select(c => new CustomerDTO { BillingAddress = c.BillingAddress, CompanyId = c.CompanyId, Name = c.Name, ShippingAddress = c.ShippingAddress, Version = c.Version }).FirstOrDefault(c => c.CompanyId == customerId);
			}
		}

		public void UpdateCustomerUsingDTO(CustomerDTO customer)
		{
			using (var ctx = new OrderIT.Model.OrderITEntities())
			{
				var newCustomer = new OrderIT.Model.Customer { CompanyId = customer.CompanyId, Version = customer.Version };
				ctx.Companies.Attach(newCustomer);
				newCustomer.ShippingAddress = customer.ShippingAddress;
				newCustomer.BillingAddress = customer.BillingAddress;
				newCustomer.Name = customer.Name;
				ctx.SaveChanges();
			}
		}

		public void DeleteCustomerUsingDTO(int customerId, byte[] version)
		{
			using (var ctx = new OrderIT.Model.OrderITEntities())
			{
				var customerToDelete = new OrderIT.Model.Customer
				{
					CompanyId = customerId,
					Version = version,
					ShippingAddress = new Model.AddressInfo(),
					BillingAddress = new Model.AddressInfo()
				};
				ctx.Companies.Attach(customerToDelete);
				ctx.Companies.DeleteObject(customerToDelete);
				ctx.SaveChanges();
			}
		}


		/*ICustomerSTEService Interface*/
		public int CreateCustomerUsingSTE(Model.STE.Customer customer)
		{
			using (var ctx = new OrderIT.Model.STE.OrderITEntities())
			{
				ctx.Companies.ApplyChanges(customer);
				ctx.SaveChanges();
				return customer.CompanyId;
			}
		}

		public Model.STE.Customer ReadCustomerUsingSTE(int customerId)
		{
			using (var ctx = new OrderIT.Model.STE.OrderITEntities()) {
				return ctx.Companies.OfType<OrderIT.Model.STE.Customer>().FirstOrDefault(c => c.CompanyId == customerId);
			}
		}

		public void UpdateCustomerUsingSTE(Model.STE.Customer customer) {
			using (var ctx = new OrderIT.Model.STE.OrderITEntities()) {
				ctx.Companies.ApplyChanges(customer);
				ctx.SaveChanges();
			}
		}

		public void DeleteCustomerUsingSTE(Model.STE.Customer customer)
		{
			using (var ctx = new OrderIT.Model.STE.OrderITEntities())
			{
				ctx.Companies.ApplyChanges(customer);
				ctx.SaveChanges();
			}
		}


		/*IOrderService Interface*/
		public int CreateOrder(OrderIT.Model.Order order)
		{
			using (var ctx = new OrderIT.Model.OrderITEntities())
			{
				ctx.Orders.AddObject(order);
				ctx.SaveChanges();
				return order.OrderId;
			}
		}

		public OrderIT.Model.Order ReadOrder(int orderId)
		{
			using (var ctx = new OrderIT.Model.OrderITEntities())
			{
				return ctx.Orders.Include("OrderDetails").FirstOrDefault(o => o.OrderId == orderId);
			}
		}

		public void UpdateOrder(OrderIT.Model.Order order) {
			using (var ctx = new OrderIT.Model.OrderITEntities()) {
				ctx.ContextOptions.ProxyCreationEnabled = false;
				order.OrderDetails.ForEach(d => d.OrderId = order.OrderId);
				var dbOrder = ctx.Orders.Include("OrderDetails").First(o => o.OrderId == order.OrderId);
				var AddedDetails = order.OrderDetails.Except(dbOrder.OrderDetails).ToList();
				var RemovedDetails = dbOrder.OrderDetails.Except(order.OrderDetails).ToList();
				var ModifiedDetails = dbOrder.OrderDetails.Intersect(order.OrderDetails).ToList();
				dbOrder.ShippingAddress = order.ShippingAddress;
				dbOrder.Version = order.Version;
				AddedDetails.ForEach(d => dbOrder.OrderDetails.Add(d));
				RemovedDetails.ForEach(d => ctx.OrderDetails.DeleteObject(d));
				ModifiedDetails.ForEach(d => ctx.OrderDetails.ApplyCurrentValues(d));
				ctx.SaveChanges();
			}
		}

		public void DeleteOrder(int orderId, byte[] version) {
			using (var ctx = new OrderIT.Model.OrderITEntities()) {
				var order = new OrderIT.Model.Order { OrderId = orderId, Version = version };
				ctx.Orders.Attach(order);
				ctx.Orders.DeleteObject(order);
				ctx.SaveChanges();
			}
		}

		/*IOrderService Interface*/
		public int CreateOrderUsingSTE(Model.STE.Order order)
		{
			using (var ctx = new OrderIT.Model.STE.OrderITEntities())
			{
				ctx.Orders.ApplyChanges(order);
				ctx.SaveChanges();
				return order.OrderId;
			}
		}

		public Model.STE.Order ReadOrderUsingSTE(int orderId)
		{
			using (var ctx = new OrderIT.Model.STE.OrderITEntities())
			{
				return ctx.Orders.Include("OrderDetails").FirstOrDefault(o => o.OrderId == orderId);
			}
		}

		public void UpdateOrderUsingSTE(Model.STE.Order order)
		{
			using (var ctx = new OrderIT.Model.STE.OrderITEntities())
			{
				ctx.Orders.ApplyChanges(order);
				ctx.SaveChanges();
			}
		}

		public void DeleteOrderUsingSTE(OrderIT.Model.STE.Order order)
		{
			using (var ctx = new OrderIT.Model.STE.OrderITEntities())
			{
				ctx.Orders.ApplyChanges(order);
				ctx.SaveChanges();
			}
		}
	}
}
