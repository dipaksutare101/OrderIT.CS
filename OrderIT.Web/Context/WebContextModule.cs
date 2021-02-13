using System.Web;
using System;
using OrderIT.Model;

namespace OrderIT.Web
{
    public class WebContextModule : IHttpModule
    {
        public void Dispose()
        {
        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += new EventHandler(context_BeginRequest);
            context.EndRequest += new EventHandler(context_EndRequest);
        }

		void context_BeginRequest(object sender, EventArgs e)
		{
			HttpContext.Current.Items[ConfigurationKeys.ConnectionString] = new OrderITEntities(Configuration.ConnectionString);
		}

        void context_EndRequest(object sender, EventArgs e)
        {
			var ctx = ((OrderITEntities)HttpContext.Current.Items[ConfigurationKeys.ConnectionString]);
            if (ctx != null)
                ctx.Dispose();
        }
    }
}