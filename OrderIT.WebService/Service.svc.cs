using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using OrderIT.Model;

namespace OrderIT.WebService {
	public class Service1 : IService {
		public Customer GetData(int value) {
			using (OrderITEntities ctx = new OrderITEntities()) {
				return ctx.Companies.OfType<Customer>().FirstOrDefault(c => c.CompanyId == value);
			}
		}
	}
}
