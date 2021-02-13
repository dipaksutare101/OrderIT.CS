using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrderIT.Model;

namespace OrderIT.DomainModel
{
    public class DiscountPolicy
    {
        public void EvaluateDiscount(Order order)
        {
            if (order == null)
                throw new ArgumentNullException("order");

            // more code here...
        }
    }
}
