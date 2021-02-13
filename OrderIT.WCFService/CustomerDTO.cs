using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OrderIT.Model;
using System.Runtime.Serialization;

namespace OrderIT.WCFService {
	[DataContract(Namespace="http://schema.tempuri.org/CustomerDTO")]
	public class CustomerDTO
	{
		[DataMember]
		public int CompanyId { get; set; }
		[DataMember]
		public string Name { get; set; }
		[DataMember]
		public AddressInfo ShippingAddress { get; set; }
		[DataMember]
		public AddressInfo BillingAddress { get; set; }
		[DataMember]
		public byte[] Version { get; set; }
	}
}