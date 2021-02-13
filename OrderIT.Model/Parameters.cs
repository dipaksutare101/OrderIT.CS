using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace OrderIT.Model
{
	public static class Parameters
	{
		public static string ConnectionString = ConfigurationManager.ConnectionStrings["OrderITEntities"].ConnectionString;
	}
}
