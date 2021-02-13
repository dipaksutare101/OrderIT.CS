using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrderIT.Model;

namespace OrderIT.Web
{
    public partial class Repository : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var products = ApplicationContext.Current.Companies.OfType<Customer>();
            Products.DataSource = products;
            Products.DataBind();
        }
    }
}