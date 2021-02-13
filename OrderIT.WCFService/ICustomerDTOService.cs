using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using OrderIT.Model;

namespace OrderIT.WCFService
{
	[ServiceContract]
	interface ICustomerDTOService
	{
		[OperationContract]
		int CreateCustomerUsingDTO(CustomerDTO customer);

		[OperationContract]
		CustomerDTO ReadCustomerUsingDTO(int customerId);

		[OperationContract]
		void UpdateCustomerUsingDTO(CustomerDTO customer);

		[OperationContract]
		void DeleteCustomerUsingDTO(int customerId, byte[] version);
	}
}
