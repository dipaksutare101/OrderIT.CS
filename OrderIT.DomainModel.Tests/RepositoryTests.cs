using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using System.Data.Objects;
using OrderIT.Model;

namespace OrderIT.DomainModel.Tests
{
    [TestClass]
    public class RepositoryTests
    {
        [TestInitialize]
        public void SetUp()
        {
            mocks = new MockRepository();
            objectContext = mocks.Stub<IObjectContext>();
            objectSet = mocks.DynamicMock<IObjectSet<Customer>>();

            SetupResult.On(objectContext)
                .Call(objectContext.CreateObjectSet<Customer>())
                .Return(objectSet);
        }

        MockRepository mocks;
        IObjectContext objectContext;
        IObjectSet<Customer> objectSet;

        [TestMethod]
        public void Repository_Add_CallsAddObject()
        {
            Customer customer = new Customer();
            Expect.Call(() => objectSet.AddObject(customer));
            mocks.ReplayAll();

            Repository<Customer> repository =
                new Repository<Customer>(objectContext);
            repository.Add(customer);

            mocks.VerifyAll();
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void Add_WithNotUniqueEmail_ThrowsException()
        {
            var customerSet = new FakeObjectSet<Customer>();
            
            objectContext = mocks.Stub<IObjectContext>();
            SetupResult.On(objectContext)
                .Call(objectContext.CreateObjectSet<Customer>())
                .Return(customerSet);

            mocks.ReplayAll();

            Customer c = new Customer();
            c.CompanyId = 3;
            c.Email = "sample@email.com";
            customerSet.AddObject(c);

            CustomerRepository repo = new CustomerRepository(this.objectContext);
            repo.Add(new Customer { Email = c.Email });

            Assert.Fail();
        }

    }
}
