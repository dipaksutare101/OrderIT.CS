using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrderIT.Model;

namespace OrderIT.DomainModel.Tests
{
    public class FakeTrackingService : ITrackingService
    {
        public string GetTracking(string trackingTicket)
        {
            return "delivered";
        }
    }
}
