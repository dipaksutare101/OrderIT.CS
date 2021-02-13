using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using OrderIT.Model.STE;

namespace OrderIT.OrderIT.WCFSTEService {
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
	[ServiceContract]
	public interface IService {

		[OperationContract]
		Customer ReadCustomer(int customerId);

		[OperationContract]
		void UpdateCustomer(Customer c);

		[OperationContract]
		Order ReadOrder(int orderId);

		[OperationContract]
		void UpdateOrder(Order o);

		[OperationContract]
		Supplier ReadSupplier(int supplierId);

		[OperationContract]
		void UpdateSupplier(Supplier s);
	}
}
