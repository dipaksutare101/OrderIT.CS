﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Data.EntityClient;
using System.Data.Metadata.Edm;
using System.Data.Objects.DataClasses;
using System.Data.Objects;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Linq;

namespace OrderIT.Model.STE
{
    public partial class OrderITEntities : ObjectContext
    {
        public const string ConnectionString = "name=OrderITEntities";
        public const string ContainerName = "OrderITEntities";
    
        #region Constructors
    
        public OrderITEntities()
            : base(ConnectionString, ContainerName)
        {
            Initialize();
        }
    
        public OrderITEntities(string connectionString)
            : base(connectionString, ContainerName)
        {
            Initialize();
        }
    
        public OrderITEntities(EntityConnection connection)
            : base(connection, ContainerName)
        {
            Initialize();
        }
    
        private void Initialize()
        {
            // Creating proxies requires the use of the ProxyDataContractResolver and
            // may allow lazy loading which can expand the loaded graph during serialization.
            ContextOptions.ProxyCreationEnabled = false;
            ObjectMaterialized += new ObjectMaterializedEventHandler(HandleObjectMaterialized);
        }
    
        private void HandleObjectMaterialized(object sender, ObjectMaterializedEventArgs e)
        {
            var entity = e.Entity as IObjectWithChangeTracker;
            if (entity != null)
            {
                bool changeTrackingEnabled = entity.ChangeTracker.ChangeTrackingEnabled;
                try
                {
                    entity.MarkAsUnchanged();
                }
                finally
                {
                    entity.ChangeTracker.ChangeTrackingEnabled = changeTrackingEnabled;
                }
                this.StoreReferenceKeyValues(entity);
            }
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
        public virtual ObjectResult<OrderDetail> GetOrderDetails(Nullable<int> orderid)
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
        public virtual ObjectResult<Nullable<decimal>> GetTotalOrdersAmount()
        {
            return base.ExecuteFunction<Nullable<decimal>>("GetTotalOrdersAmount");
        }
        public virtual ObjectResult<Company> GetCompanies()
        {
            return base.ExecuteFunction<Company>("GetCompanies");
        }
        public virtual ObjectResult<OrderDetail> GetPagedOrderDetails(Nullable<int> pageIndex, Nullable<int> rowsPerPage, ObjectParameter count)
        {
    
            ObjectParameter pageIndexParameter;
    
            if (pageIndex.HasValue)
            {
                pageIndexParameter = new ObjectParameter("pageIndex", pageIndex);
            }
            else
            {
                pageIndexParameter = new ObjectParameter("pageIndex", typeof(int));
            }
    
            ObjectParameter rowsPerPageParameter;
    
            if (rowsPerPage.HasValue)
            {
                rowsPerPageParameter = new ObjectParameter("rowsPerPage", rowsPerPage);
            }
            else
            {
                rowsPerPageParameter = new ObjectParameter("rowsPerPage", typeof(int));
            }
            return base.ExecuteFunction<OrderDetail>("GetPagedOrderDetails", pageIndexParameter, rowsPerPageParameter, count);
        }
        public virtual ObjectResult<byte[]> GetOrdersWithComplexProperties()
        {
            return base.ExecuteFunction<byte[]>("GetOrdersWithComplexProperties");
        }
        public virtual ObjectResult<Product> GetProducts()
        {
            return base.ExecuteFunction<Product>("GetProducts");
        }

        #endregion
    }
}
