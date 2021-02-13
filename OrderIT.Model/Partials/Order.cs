using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrderIT.Model;

namespace OrderIT.Model
{
    public partial class Order
    {
        public decimal Total
        {
            get
            {
                decimal result = 0;
                this.OrderDetails.ForEach(d => result += d.UnitPrice * d.Quantity);

                return result;
            }
        }

        public string TrackingTicket { get; set; }

        internal DeliveryStatus CheckDeliveryStatus(ITrackingService service)
        {
            string res = service.GetTracking(this.TrackingTicket);

            if (res == "delivered")
                return DeliveryStatus.Delivered;

            return DeliveryStatus.Dispatching;
        }


        public DeliveryStatus CheckDeliveryStatus()
        {
            // REVIEW: use the IoC container
            //return this.CheckDeliveryStatus(new CarrierWebService());
            return DeliveryStatus.Delivered;
        }

    }
}
