using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OrderIT.Model;

namespace OrderIT.Web.Controllers
{
	[HandleError]
	public class CustomersController : Controller
	{
		public ActionResult Index()
		{
			ViewData.Model = ApplicationContext.Current.Companies.OfType<Customer>() as IEnumerable<Customer>;

			return View();
		}
	}
}
