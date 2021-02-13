using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using OrderIT.Model;

namespace OrderIT.WCFService
{
	[ServiceContract]
	interface ICustomerService
	{
		[OperationContract]
		int CreateCustomer(Customer customer);

		[OperationContract]
		[ProxyResolverAttribute]
		Customer ReadCustomer(int customerId);

		[OperationContract]
		void UpdateCustomer(Customer customer);

		[OperationContract]
		void DeleteCustomer(int customerId, byte[] version);
	}
}
