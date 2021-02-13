//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.Serialization;

namespace OrderIT.Model.STE
{
    [DataContract(IsReference = true, Namespace="http://schema.tempuri.org/OrderSTE")]
    [KnownType(typeof(OrderDetail))]
    [KnownType(typeof(Customer))]
    public partial class Order: IObjectWithChangeTracker, INotifyPropertyChanged
    {
        #region Primitive Properties
    
        [DataMember]
        public int OrderId
        {
            get { return _orderId; }
            set
            {
                if (_orderId != value)
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added)
                    {
                        throw new InvalidOperationException("The property 'OrderId' is part of the object's key and cannot be changed. Changes to key properties can only be made when the object is not being tracked or is in the Added state.");
                    }
                    _orderId = value;
                    OnPropertyChanged("OrderId");
                }
            }
        }
        private int _orderId;
    
        [DataMember]
        public System.DateTime OrderDate
        {
            get { return _orderDate; }
            set
            {
                if (_orderDate != value)
                {
                    _orderDate = value;
                    OnPropertyChanged("OrderDate");
                }
            }
        }
        private System.DateTime _orderDate;
    
        [DataMember]
        public Nullable<System.DateTime> EstimatedShippingDate
        {
            get { return _estimatedShippingDate; }
            set
            {
                if (_estimatedShippingDate != value)
                {
                    _estimatedShippingDate = value;
                    OnPropertyChanged("EstimatedShippingDate");
                }
            }
        }
        private Nullable<System.DateTime> _estimatedShippingDate;
    
        [DataMember]
        public Nullable<System.DateTime> ActualShippingDate
        {
            get { return _actualShippingDate; }
            set
            {
                if (_actualShippingDate != value)
                {
                    _actualShippingDate = value;
                    OnPropertyChanged("ActualShippingDate");
                }
            }
        }
        private Nullable<System.DateTime> _actualShippingDate;
    
        [DataMember]
        public int CustomerId
        {
            get { return _customerId; }
            set
            {
                if (_customerId != value)
                {
                    ChangeTracker.RecordOriginalValue("CustomerId", _customerId);
                    if (!IsDeserializing)
                    {
                        if (Customer != null && Customer.CompanyId != value)
                        {
                            Customer = null;
                        }
                    }
                    _customerId = value;
                    OnPropertyChanged("CustomerId");
                }
            }
        }
        private int _customerId;
    
        [DataMember]
        public byte[] Version
        {
            get { return _version; }
            set
            {
                if (_version != value)
                {
                    ChangeTracker.RecordOriginalValue("Version", _version);
                    _version = value;
                    OnPropertyChanged("Version");
                }
            }
        }
        private byte[] _version;

        #endregion
        #region Complex Properties
    
        [DataMember]
        public AddressInfo ShippingAddress
        {
            get
            {
                if (!_shippingAddressInitialized && _shippingAddress == null)
                {
                    _shippingAddress = new AddressInfo();
                    ((INotifyComplexPropertyChanging)_shippingAddress).ComplexPropertyChanging += HandleShippingAddressChanging;
                }
                _shippingAddressInitialized = true;
                return _shippingAddress;
            }
            set
            {
                _shippingAddressInitialized = true;
                if (!Equals(_shippingAddress, value))
                {
                    if (_shippingAddress != null)
                    {
                        ((INotifyComplexPropertyChanging)_shippingAddress).ComplexPropertyChanging -= HandleShippingAddressChanging;
                    }
    
                    HandleShippingAddressChanging(this, null);
                    _shippingAddress = value;
                    OnPropertyChanged("ShippingAddress");
    
                    if (value != null)
                    {
                        ((INotifyComplexPropertyChanging)_shippingAddress).ComplexPropertyChanging += HandleShippingAddressChanging;
                    }
                }
            }
        }
        private AddressInfo _shippingAddress;
        private bool _shippingAddressInitialized;

        #endregion
        #region Navigation Properties
    
        [DataMember]
        public TrackableCollection<OrderDetail> OrderDetails
        {
            get
            {
                if (_orderDetails == null)
                {
                    _orderDetails = new TrackableCollection<OrderDetail>();
                    _orderDetails.CollectionChanged += FixupOrderDetails;
                }
                return _orderDetails;
            }
            set
            {
                if (!ReferenceEquals(_orderDetails, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_orderDetails != null)
                    {
                        _orderDetails.CollectionChanged -= FixupOrderDetails;
                        // This is the principal end in an association that performs cascade deletes.
                        // Remove the cascade delete event handler for any entities in the current collection.
                        foreach (OrderDetail item in _orderDetails)
                        {
                            ChangeTracker.ObjectStateChanging -= item.HandleCascadeDelete;
                        }
                    }
                    _orderDetails = value;
                    if (_orderDetails != null)
                    {
                        _orderDetails.CollectionChanged += FixupOrderDetails;
                        // This is the principal end in an association that performs cascade deletes.
                        // Add the cascade delete event handler for any entities that are already in the new collection.
                        foreach (OrderDetail item in _orderDetails)
                        {
                            ChangeTracker.ObjectStateChanging += item.HandleCascadeDelete;
                        }
                    }
                    OnNavigationPropertyChanged("OrderDetails");
                }
            }
        }
        private TrackableCollection<OrderDetail> _orderDetails;
    
        [DataMember]
        public Customer Customer
        {
            get { return _customer; }
            set
            {
                if (!ReferenceEquals(_customer, value))
                {
                    var previousValue = _customer;
                    _customer = value;
                    FixupCustomer(previousValue);
                    OnNavigationPropertyChanged("Customer");
                }
            }
        }
        private Customer _customer;

        #endregion
        #region ChangeTracking
    
        protected virtual void OnPropertyChanged(String propertyName)
        {
            if (ChangeTracker.State != ObjectState.Added && ChangeTracker.State != ObjectState.Deleted)
            {
                ChangeTracker.State = ObjectState.Modified;
            }
            if (_propertyChanged != null)
            {
                _propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
        protected virtual void OnNavigationPropertyChanged(String propertyName)
        {
            if (_propertyChanged != null)
            {
                _propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged{ add { _propertyChanged += value; } remove { _propertyChanged -= value; } }
        private event PropertyChangedEventHandler _propertyChanged;
        private ObjectChangeTracker _changeTracker;
    
        [DataMember]
        public ObjectChangeTracker ChangeTracker
        {
            get
            {
                if (_changeTracker == null)
                {
                    _changeTracker = new ObjectChangeTracker();
                    _changeTracker.ObjectStateChanging += HandleObjectStateChanging;
                }
                return _changeTracker;
            }
            set
            {
                if(_changeTracker != null)
                {
                    _changeTracker.ObjectStateChanging -= HandleObjectStateChanging;
                }
                _changeTracker = value;
                if(_changeTracker != null)
                {
                    _changeTracker.ObjectStateChanging += HandleObjectStateChanging;
                }
            }
        }
    
        private void HandleObjectStateChanging(object sender, ObjectStateChangingEventArgs e)
        {
            if (e.NewState == ObjectState.Deleted)
            {
                ClearNavigationProperties();
            }
        }
    
        // This entity type is the dependent end in at least one association that performs cascade deletes.
        // This event handler will process notifications that occur when the principal end is deleted.
        internal void HandleCascadeDelete(object sender, ObjectStateChangingEventArgs e)
        {
            if (e.NewState == ObjectState.Deleted)
            {
                this.MarkAsDeleted();
            }
        }
    
        protected bool IsDeserializing { get; private set; }
    
        [OnDeserializing]
        public void OnDeserializingMethod(StreamingContext context)
        {
            IsDeserializing = true;
        }
    
        [OnDeserialized]
        public void OnDeserializedMethod(StreamingContext context)
        {
            IsDeserializing = false;
            ChangeTracker.ChangeTrackingEnabled = true;
        }
        // Records the original values for the complex property ShippingAddress
        private void HandleShippingAddressChanging(object sender, EventArgs args)
        {
            if (ChangeTracker.State != ObjectState.Added && ChangeTracker.State != ObjectState.Deleted)
            {
                ChangeTracker.State = ObjectState.Modified;
            }
        }
    
    
        protected virtual void ClearNavigationProperties()
        {
            OrderDetails.Clear();
            Customer = null;
        }

        #endregion
        #region Association Fixup
    
        private void FixupCustomer(Customer previousValue)
        {
            // This is the dependent end in an association that performs cascade deletes.
            // Update the principal's event listener to refer to the new dependent.
            // This is a unidirectional relationship from the dependent to the principal, so the dependent end is
            // responsible for managing the cascade delete event handler. In all other cases the principal end will manage it.
            if (previousValue != null)
            {
                previousValue.ChangeTracker.ObjectStateChanging -= HandleCascadeDelete;
            }
    
            if (Customer != null)
            {
                Customer.ChangeTracker.ObjectStateChanging += HandleCascadeDelete;
            }
    
            if (IsDeserializing)
            {
                return;
            }
    
            if (Customer != null)
            {
                CustomerId = Customer.CompanyId;
            }
    
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("Customer")
                    && (ChangeTracker.OriginalValues["Customer"] == Customer))
                {
                    ChangeTracker.OriginalValues.Remove("Customer");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("Customer", previousValue);
                }
                if (Customer != null && !Customer.ChangeTracker.ChangeTrackingEnabled)
                {
                    Customer.StartTracking();
                }
            }
        }
    
        private void FixupOrderDetails(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (OrderDetail item in e.NewItems)
                {
                    item.Order = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("OrderDetails", item);
                    }
                    // This is the principal end in an association that performs cascade deletes.
                    // Update the event listener to refer to the new dependent.
                    ChangeTracker.ObjectStateChanging += item.HandleCascadeDelete;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (OrderDetail item in e.OldItems)
                {
                    if (ReferenceEquals(item.Order, this))
                    {
                        item.Order = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("OrderDetails", item);
                    }
                    // This is the principal end in an association that performs cascade deletes.
                    // Remove the previous dependent from the event listener.
                    ChangeTracker.ObjectStateChanging -= item.HandleCascadeDelete;
                }
            }
        }

        #endregion
    }
}
