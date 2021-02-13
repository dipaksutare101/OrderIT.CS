using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using OrderIT.Model;

namespace OrderIT.DomainModel.Tests
{
    [TestClass]
    public class OrderTests
    {
        ITrackingService trackingServiceStub;
        ITrackingService trackingServiceMock;
        MockRepository mocks;

        [TestInitialize]
        public void SetUp()
        {
            mocks = new MockRepository();
            trackingServiceStub = mocks.Stub<ITrackingService>();
            trackingServiceMock = mocks.DynamicMock<ITrackingService>();
        }

        [TestMethod]
        public void Total_CalculateWithoutDiscount_ReturnsTheCorrectSum()
        {
            var order = new Order();

            order.OrderDetails.Add(
              new OrderDetail { Quantity = 2, UnitPrice = 10 });
            order.OrderDetails.Add(
              new OrderDetail { Quantity = 3, UnitPrice = 15 });

            var result = order.Total;

            Assert.AreEqual(65, result);
        }

        [TestMethod]
        public void CheckDeliveryStatus_WhenOrderIsDelivered_ReturnsDelivered()
        {
					var order = new Order();

            DeliveryStatus result = order.CheckDeliveryStatus(
                new FakeTrackingService());

            Assert.AreEqual(DeliveryStatus.Delivered, result);
        }

        [TestMethod]
        public void StubCheckDeliveryStatus_WhenOrderIsDelivered_ReturnsDelivered()
        {
            SetupResult.On(trackingServiceStub)
                .Call(trackingServiceStub.GetTracking(null))
                .Return("delivered")
                .IgnoreArguments();
            mocks.ReplayAll();

            var order = new Order();

            DeliveryStatus result = order.CheckDeliveryStatus(trackingServiceStub);

            Assert.AreEqual(DeliveryStatus.Delivered, result);
        }

        [TestMethod]
        public void MockCheckDeliveryStatus_WhenOrderIsDelivered_ReturnsDelivered()
        {
            var order = new Order();
            order.TrackingTicket = "test";

            Expect.Call(trackingServiceMock.GetTracking(order.TrackingTicket))
                .Return("delivered");
            mocks.ReplayAll();

            DeliveryStatus result = order.CheckDeliveryStatus(trackingServiceMock);

            mocks.VerifyAll();
            Assert.AreEqual(DeliveryStatus.Delivered, result);
        }

    }
}
