﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data.Objects;
using System.Data.Common;
using System.Data.EntityClient;
using System.Data.Objects.DataClasses;
using System.Collections.Generic;
using OrderIT.Model.Notifications;

namespace OrderIT.Model
{
    public partial class OrderITEntities : ExtendedObjectContext
    {
        public const string ConnectionString = "name=OrderITEntities";
        public const string ContainerName = "OrderITEntities";
    
    	#region Constructors
    
        public OrderITEntities()
            : base(ConnectionString, ContainerName, null)
        {
            this.ContextOptions.LazyLoadingEnabled = true;
        }
    
        public OrderITEntities(IObjectPersistenceNotification notification)
            : base(ConnectionString, ContainerName, notification)
        {
            this.ContextOptions.LazyLoadingEnabled = true;
        }
    
        public OrderITEntities(string connectionString)
            : base(connectionString, ContainerName, null)
        {
            this.ContextOptions.LazyLoadingEnabled = true;
        }
    
        public OrderITEntities(string connectionString, IObjectPersistenceNotification notification)
            : base(connectionString, ContainerName, notification)
        {
            this.ContextOptions.LazyLoadingEnabled = true;
        }
    
        public OrderITEntities(EntityConnection connection)
            : base(connection, ContainerName, null)
        {
            this.ContextOptions.LazyLoadingEnabled = true;
        }
    
        public OrderITEntities(EntityConnection connection, IObjectPersistenceNotification notification)
            : base(connection, ContainerName, notification)
        {
            this.ContextOptions.LazyLoadingEnabled = true;
        }
        #endregion
    
        #region ObjectSet Properties
    
        public ObjectSet<Company> Companies
        {
            get { return _companies  ?? (_companies = CreateObjectSet<Company>("Companies")); }
        }
        private ObjectSet<Company> _companies;
    
        public ObjectSet<Order> Orders
        {
            get { return _orders  ?? (_orders = CreateObjectSet<Order>("Orders")); }
        }
        private ObjectSet<Order> _orders;
    
        public ObjectSet<OrderDetail> OrderDetails
        {
            get { return _orderDetails  ?? (_orderDetails = CreateObjectSet<OrderDetail>("OrderDetails")); }
        }
        private ObjectSet<OrderDetail> _orderDetails;
    
        public ObjectSet<Product> Products
        {
            get { return _products  ?? (_products = CreateObjectSet<Product>("Products")); }
        }
        private ObjectSet<Product> _products;
    
        public ObjectSet<GeometrySample> GeometrySamples
        {
            get { return _geometrySamples  ?? (_geometrySamples = CreateObjectSet<GeometrySample>("GeometrySamples")); }
        }
        private ObjectSet<GeometrySample> _geometrySamples;

        #endregion
        #region Function Imports
        public ObjectResult<OrderDetail> GetOrderDetails(Nullable<int> orderid)
        {
    
            ObjectParameter orderidParameter;
    
            if (orderid.HasValue)
            {
                orderidParameter = new ObjectParameter("orderid", orderid);
            }
            else
            {
                orderidParameter = new ObjectParameter("orderid", typeof(int));
            }
            return base.ExecuteFunction<OrderDetail>("GetOrderDetails", orderidParameter);
        }

        #endregion
    
      [EdmFunction("OrderITModel", "GetUDFTotalAmount")]
      public static Nullable<decimal> GetUDFTotalAmount(Nullable<decimal> unitPrice) { 
    		throw new NotImplementedException("CannotCall this method");
    }
      [EdmFunction("OrderITModel", "GetUDFTotalAmount")]
      public static Nullable<decimal> GetUDFTotalAmount(Nullable<decimal> unitPrice, Nullable<int> quantity, Nullable<decimal> discount) { 
    		throw new NotImplementedException("CannotCall this method");
    }
      [EdmFunction("OrderITModel", "GetUDFTotalAmountWithObjectParameter")]
      public static Nullable<decimal> GetUDFTotalAmountWithObjectParameter(OrderDetail detail) { 
    		throw new NotImplementedException("CannotCall this method");
    }
      [EdmFunction("OrderITModel", "GetUDFAddresses")]
      public static DbDataRecord GetUDFAddresses(Customer detail) { 
    		throw new NotImplementedException("CannotCall this method");
    }
      [EdmFunction("OrderITModel", "GetUDFTypedAddresses")]
      public static CustomerProjection GetUDFTypedAddresses(Customer customer) { 
    		throw new NotImplementedException("CannotCall this method");
    }
      [EdmFunction("OrderITModel", "GetUDFDetailsWithNoDiscount_Scalar")]
      public static IEnumerable<Nullable<int>> GetUDFDetailsWithNoDiscount_Scalar(Order o) { 
    		throw new NotImplementedException("CannotCall this method");
    }
      [EdmFunction("OrderITModel", "GetUDFDetailsWithNoDiscount_Record")]
      public static IEnumerable<DbDataRecord> GetUDFDetailsWithNoDiscount_Record(Order o) { 
    		throw new NotImplementedException("CannotCall this method");
    }
      [EdmFunction("OrderITModel", "GetUDFDetailsWithNoDiscount_Object")]
      public static IEnumerable<OrderDetail> GetUDFDetailsWithNoDiscount_Object(Order o) { 
    		throw new NotImplementedException("CannotCall this method");
    }}
}
