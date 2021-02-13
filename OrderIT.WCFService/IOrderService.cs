using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using OrderIT.Model;

namespace OrderIT.WCFService
{
	[ServiceContract]
	interface IOrderService
	{
		[OperationContract]
		int CreateOrder(Order order);

		[OperationContract]
		[ProxyResolverAttribute]
		Order ReadOrder(int orderId);

		[OperationContract]
		[ProxyResolverAttribute]
		void UpdateOrder(Order order);

		[OperationContract]
		void DeleteOrder(int orderId, byte[] version);
	}
}
