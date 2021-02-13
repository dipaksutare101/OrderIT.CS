using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using OrderIT.Model.STE;

namespace OrderIT.WCFService
{
	[ServiceContract]
	interface ICustomerSTEService
	{
		[OperationContract]
		int CreateCustomerUsingSTE(Customer customer);

		[OperationContract]
		Customer ReadCustomerUsingSTE(int customerId);

		[OperationContract]
		void UpdateCustomerUsingSTE(Customer customer);

		[OperationContract]
		void DeleteCustomerUsingSTE(Customer customer);
	}
}
