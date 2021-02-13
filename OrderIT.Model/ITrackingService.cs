using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderIT.Model
{
    public interface ITrackingService
    {
        string GetTracking(string trackingTicket);
    }
}
