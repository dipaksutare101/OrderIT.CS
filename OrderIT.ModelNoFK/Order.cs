//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;


namespace OrderIT.ModelIA
{
    [DataContract(IsReference = true)]
    [KnownType(typeof(OrderDetail))]
    [KnownType(typeof(Customer))]
    public partial class Order  : INotifyPropertyChanged, IEditableObject
    {
        #region INotifyPropertyChanged
    		public event PropertyChangedEventHandler PropertyChanged;
    
    		protected void NotifyPropertyChanged(String info) {
    			if (PropertyChanged != null) {
    				PropertyChanged(this, new PropertyChangedEventArgs(info));
    			}
    		}

        #endregion
        #region Primitive Properties
    	
        [DataMember]
        public virtual int OrderId
        {
            get { return _orderId; }
            set { _orderId = value; NotifyPropertyChanged("OrderId"); }
        }
        private int _orderId;
        protected int OrderIdEdit { get; set; }
    	
        [DataMember]
        public virtual System.DateTime OrderDate
        {
            get { return _orderDate; }
            set { _orderDate = value; NotifyPropertyChanged("OrderDate"); }
        }
        private System.DateTime _orderDate;
        protected System.DateTime OrderDateEdit { get; set; }
    	
        [DataMember]
        public virtual Nullable<System.DateTime> EstimatedShippingDate
        {
            get { return _estimatedShippingDate; }
            set { _estimatedShippingDate = value; NotifyPropertyChanged("EstimatedShippingDate"); }
        }
        private Nullable<System.DateTime> _estimatedShippingDate;
        protected Nullable<System.DateTime> EstimatedShippingDateEdit { get; set; }
    	
        [DataMember]
        public virtual Nullable<System.DateTime> ActualShippingDate
        {
            get { return _actualShippingDate; }
            set { _actualShippingDate = value; NotifyPropertyChanged("ActualShippingDate"); }
        }
        private Nullable<System.DateTime> _actualShippingDate;
        protected Nullable<System.DateTime> ActualShippingDateEdit { get; set; }

        #endregion
        #region Complex Properties
    	
        [DataMember]
        public virtual AddressInfo ShippingAddress
        {
            get { return _shippingAddress; }
            set { _shippingAddress = value; NotifyPropertyChanged("ShippingAddress"); }
        }
        private AddressInfo _shippingAddress = new AddressInfo();
        private AddressInfo _shippingAddressEdit = new AddressInfo();

        #endregion
        #region Navigation Properties
    
    	
        [DataMember]
        public virtual ICollection<OrderDetail> OrderDetails
        {
            get
            {
                if (_orderDetails == null)
                {
                    var newCollection = new FixupCollection<OrderDetail>();
                    newCollection.CollectionChanged += FixupOrderDetails;
                    _orderDetails = newCollection;
                }
                return _orderDetails;
            }
            set
            {
                if (!ReferenceEquals(_orderDetails, value))
                {
                    var previousValue = _orderDetails as FixupCollection<OrderDetail>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupOrderDetails;
                    }
                    _orderDetails = value;
                    var newValue = value as FixupCollection<OrderDetail>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupOrderDetails;
                    }
                    NotifyPropertyChanged("OrderDetails");
                }
            }
        }
        private ICollection<OrderDetail> _orderDetails;
    
    	
        [DataMember]
        public virtual Customer Customer
        {
            get;
            set;
        }

        #endregion
        #region Association Fixup
    
        private void FixupOrderDetails(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (OrderDetail item in e.NewItems)
                {
                    item.Order = this;
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
                }
            }
        }

        #endregion
        #region IEditableObject
    
        void IEditableObject.BeginEdit(){
    	    BeginEditProtected();
        }
    
        void IEditableObject.EndEdit(){
    	    EndEditProtected();
    	}
    
        void IEditableObject.CancelEdit(){
    	    CancelEditProtected();
        }
    	
        private bool isEditing = false;
    
    	protected virtual void BeginEditProtected(){
            if (!isEditing) 
            {
        		OrderIdEdit = OrderId;
        		OrderDateEdit = OrderDate;
        		EstimatedShippingDateEdit = EstimatedShippingDate;
        		ActualShippingDateEdit = ActualShippingDate;
                isEditing = true;
            }
    	}
    
        protected virtual void CancelEditProtected(){
            OrderId = OrderIdEdit;
            OrderDate = OrderDateEdit;
            EstimatedShippingDate = EstimatedShippingDateEdit;
            ActualShippingDate = ActualShippingDateEdit;
            isEditing = false;
        }
    
    	protected virtual void EndEditProtected(){
    	    isEditing = false;
        }
            

        #endregion
        #region Equality Operators
        public override bool Equals (object obj)
        {
            if (!(obj is Order))
                return false;
                    
            Order o = (Order)obj;
            return (1==1
              && this.OrderId == o.OrderId 
            );
        }
    
        public override int GetHashCode()
        {
            return (1
              ^ this.OrderId.GetHashCode()
            );
        }

        #endregion
    }
}
