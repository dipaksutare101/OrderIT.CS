using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrderIT.Model;

namespace OrderIT.DomainModel
{
    public class CustomerRepository : Repository<Customer>
    {
        public CustomerRepository(IObjectContext context) : base(context) { }

        public override void Add(Customer entity)
        {
            // REVIEW: move it
            if (this.GetSingleOrDefault(c => c.Email == entity.Email) != null)
                throw new ArgumentException("Email already used");

            base.Add(entity);
        }
    }
}
