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
using OrderIT.Model.Notifications;


namespace OrderIT.Model
{
    [DataContract(IsReference = true)]
    [KnownType(typeof(Product))]
    [KnownType(typeof(Order))]
    public partial class OrderDetail  : INotifyPropertyChanged, IEditableObject
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
        public virtual int OrderDetailId
        {
            get { return _orderDetailId; }
            set { _orderDetailId = value; NotifyPropertyChanged("OrderDetailId"); }
        }
        private int _orderDetailId;
        protected int OrderDetailIdEdit { get; set; }
    	
        [DataMember]
        public virtual int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; NotifyPropertyChanged("Quantity"); }
        }
        private int _quantity;
        protected int QuantityEdit { get; set; }
    	
        [DataMember]
        public virtual decimal UnitPrice
        {
            get { return _unitPrice; }
            set { _unitPrice = value; NotifyPropertyChanged("UnitPrice"); }
        }
        private decimal _unitPrice;
        protected decimal UnitPriceEdit { get; set; }
    	
        [DataMember]
        public virtual decimal Discount
        {
            get { return _discount; }
            set { _discount = value; NotifyPropertyChanged("Discount"); }
        }
        private decimal _discount;
        protected decimal DiscountEdit { get; set; }
    	
        [DataMember]
        public virtual int ProductId
        {
            get { return _productId; }
            set
            {
                if (_productId != value)
                {
                    if (Product != null && Product.ProductId != value)
                    {
                        Product = null;
                    }
                    _productId = value;
                    NotifyPropertyChanged("ProductId");
                }
            }
        }
        private int _productId;
        protected int ProductIdEdit { get; set; }
    	
        [DataMember]
        public virtual int OrderId
        {
            get { return _orderId; }
            set
            {
                if (_orderId != value)
                {
                    if (Order != null && Order.OrderId != value)
                    {
                        Order = null;
                    }
                    _orderId = value;
                    NotifyPropertyChanged("OrderId");
                }
            }
        }
        private int _orderId;
        protected int OrderIdEdit { get; set; }

        #endregion
        #region Navigation Properties
    
    	
        [DataMember]
        public virtual Product Product
        {
            get { return _product; }
            set
            {
                if (!ReferenceEquals(_product, value))
                {
                    var previousValue = _product;
                    _product = value;
                    FixupProduct(previousValue);
                    NotifyPropertyChanged("Product");
                }
            }
        }
        private Product _product;
    
    	
        [DataMember]
        public virtual Order Order
        {
            get { return _order; }
            set
            {
                if (!ReferenceEquals(_order, value))
                {
                    var previousValue = _order;
                    _order = value;
                    FixupOrder(previousValue);
                    NotifyPropertyChanged("Order");
                }
            }
        }
        private Order _order;

        #endregion
        #region Association Fixup
    
        private void FixupProduct(Product previousValue)
        {
            if (Product != null)
            {
                if (ProductId != Product.ProductId)
                {
                    ProductId = Product.ProductId;
                }
            }
        }
    
        private void FixupOrder(Order previousValue)
        {
            if (previousValue != null && previousValue.OrderDetails.Contains(this))
            {
                previousValue.OrderDetails.Remove(this);
            }
    
            if (Order != null)
            {
                if (!Order.OrderDetails.Contains(this))
                {
                    Order.OrderDetails.Add(this);
                }
                if (OrderId != Order.OrderId)
                {
                    OrderId = Order.OrderId;
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
        		OrderDetailIdEdit = OrderDetailId;
        		QuantityEdit = Quantity;
        		UnitPriceEdit = UnitPrice;
        		DiscountEdit = Discount;
        		ProductIdEdit = ProductId;
        		OrderIdEdit = OrderId;
                isEditing = true;
            }
    	}
    
        protected virtual void CancelEditProtected(){
            OrderDetailId = OrderDetailIdEdit;
            Quantity = QuantityEdit;
            UnitPrice = UnitPriceEdit;
            Discount = DiscountEdit;
            ProductId = ProductIdEdit;
            OrderId = OrderIdEdit;
            isEditing = false;
        }
    
    	protected virtual void EndEditProtected(){
    	    isEditing = false;
        }
            

        #endregion
        #region Equality Operators
        public override bool Equals (object obj)
        {
            if (!this.GetType().IsInstanceOfType(obj) && !obj.GetType().IsInstanceOfType(this))
                return false;
                    
            OrderDetail o = (OrderDetail)obj;
            return (1==1
              && this.OrderDetailId == o.OrderDetailId 
            );
        }
    
        public override int GetHashCode()
        {
            return (1
              ^ this.OrderDetailId.GetHashCode()
            );
        }

        #endregion
    }
}
