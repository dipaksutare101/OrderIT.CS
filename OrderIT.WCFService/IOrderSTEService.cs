using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using OrderIT.Model.STE;

namespace OrderIT.WCFService
{
	[ServiceContract]
	interface IOrderSTEService
	{
		[OperationContract]
		int CreateOrderUsingSTE(OrderIT.Model.STE.Order order);

		[OperationContract]
		[ProxyResolverAttribute]
		OrderIT.Model.STE.Order ReadOrderUsingSTE(int orderId);

		[OperationContract]
		[ProxyResolverAttribute]
		void UpdateOrderUsingSTE(OrderIT.Model.STE.Order order);

		[OperationContract]
		void DeleteOrderUsingSTE(OrderIT.Model.STE.Order order);
	}
}
