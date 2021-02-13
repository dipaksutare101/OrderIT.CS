using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderIT.Model;

namespace OrderIT.DomainModel.Tests
{
    [TestClass]
    public class DiscountPolicyTests
    {
        private Order order;

        [TestInitialize]
        public void Init()
        {
            this.order = new Order();

            this.order.Customer = new Customer
            {
                Name = "Marco De Sanctis"
            };

            // more initialization code here...
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void EvaluateDiscount_InvokedWithNull_ThrowsArgumentNullEx()
        {
            var discountPolicy = new DiscountPolicy();
            discountPolicy.EvaluateDiscount(null);
        }

        [TestMethod]
        public void EvaluateDiscount_InvokedWithNotNull_DoesntFail()
        {
            var discountPolicy = new DiscountPolicy();
            discountPolicy.EvaluateDiscount(order);
        }
    }
}
