using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Transactions;
using OrderIT.DomainModel;
using Crad.MappingVerifier;

namespace OrderIT.IntegrationTests
{
    [TestClass]
    public class CustomerTests
    {
        private TransactionScope transaction;

        [TestInitialize]
        public void SetUp()
        {
            transaction = new TransactionScope();
        }

        [TestCleanup]
        public void CleanUp()
        {
            transaction.Dispose();
        }

        [TestMethod]
        public void Customer_IsStoredAndRetrievedCorrectly()
        {
            Customer original = new Customer
            {
                Name = "Marco De Sanctis",
                BillingAddress = "SampleBillingAddress"
            };

            using (EFInactionOrdersEntities context = new EFInactionOrdersEntities())
            {
                context.AddToCompanies(original);
                context.SaveChanges();
            }

            using (EFInactionOrdersEntities context = new EFInactionOrdersEntities())
            {
                Customer customer = (Customer)context.Companies
                    .Where(c => c.CompanyId == original.CompanyId).Single();

                Assert.AreEqual(original.Name, customer.Name);
                Assert.AreEqual(original.BillingAddress, customer.BillingAddress);
                //...
            }
        }

        [TestMethod]
        public void Customer_IsStoredAndRetrievedCorrectly_MappingVerifier()
        {
            using (EFInactionOrdersEntities context = new EFInactionOrdersEntities())
            {
                VerifyMapping.For<Customer>(context)
                    .Test(c => c.Name, "Marco De Sanctis")
                    .Test(c => c.BillingAddress, "SampleBillingAddress")
                    .Execute();
            }
        }

    }
}
