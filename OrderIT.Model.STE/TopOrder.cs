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
    
    public partial class TopOrder : INotifyComplexPropertyChanging, INotifyPropertyChanged
    {
        #region Primitive Properties
    
        [DataMember]
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    OnComplexPropertyChanging();
                    _name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
        private string _name;
    
        [DataMember]
        public int OrderId
        {
            get { return _orderId; }
            set
            {
                if (_orderId != value)
                {
                    OnComplexPropertyChanging();
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
                    OnComplexPropertyChanging();
                    _orderDate = value;
                    OnPropertyChanged("OrderDate");
                }
            }
        }
        private System.DateTime _orderDate;
    
        [DataMember]
        public Nullable<decimal> total
        {
            get { return _total; }
            set
            {
                if (_total != value)
                {
                    OnComplexPropertyChanging();
                    _total = value;
                    OnPropertyChanged("total");
                }
            }
        }
        private Nullable<decimal> _total;

        #endregion
        #region ChangeTracking
    
        private void OnComplexPropertyChanging()
        {
            if (_complexPropertyChanging != null)
            {
                _complexPropertyChanging(this, new EventArgs());
            }
        }
    
        event EventHandler INotifyComplexPropertyChanging.ComplexPropertyChanging { add { _complexPropertyChanging += value; } remove { _complexPropertyChanging -= value; } }
        private event EventHandler _complexPropertyChanging;
    
        private void OnPropertyChanged(String propertyName)
        {
            if (_propertyChanged != null)
            {
                _propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged { add { _propertyChanged += value; } remove { _propertyChanged -= value; } }
        private event PropertyChangedEventHandler _propertyChanged;
    
        public static void RecordComplexOriginalValues(String parentPropertyName, TopOrder complexObject, ObjectChangeTracker changeTracker)
        {
            if (String.IsNullOrEmpty(parentPropertyName))
            {
                throw new ArgumentException("String parameter cannot be null or empty.", "parentPropertyName");
            }
    
            if (changeTracker == null)
            {
                throw new ArgumentNullException("changeTracker");
            }
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.Name", parentPropertyName), complexObject == null ? null : (object)complexObject.Name);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.OrderId", parentPropertyName), complexObject == null ? null : (object)complexObject.OrderId);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.OrderDate", parentPropertyName), complexObject == null ? null : (object)complexObject.OrderDate);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.total", parentPropertyName), complexObject == null ? null : (object)complexObject.total);
        }

        #endregion
    }
}
