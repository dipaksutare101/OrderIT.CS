using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.ComponentModel;
using OrderIT.Model;

namespace OrderIT.WinGUI.Binding {
	public class BindableCollection : BindingList<Order>, ITypedList {
		public BindableCollection(List<Order> orders) : base(orders) { }
		#region ITypedList Members

		private PropertyDescriptorCollection _props = null;

		public PropertyDescriptorCollection PropertyDescriptors {
			get {
				if (_props == null) {
					// Collection returned from GetProperties doesn't allow adding new elements
					_props = new PropertyDescriptorCollection(null);
					foreach (PropertyDescriptor prop in TypeDescriptor.GetProperties(typeof(Order))) {
						_props.Add(prop);
					}
				}
				//_props.Add(new OrderPropDescriptor());
				return _props;
			}
		}

		public PropertyDescriptorCollection GetItemProperties(PropertyDescriptor[] listAccessors) {
			return PropertyDescriptors;
		}

		public string GetListName(PropertyDescriptor[] listAccessors) {
			return "Order";
		}

		#endregion
	}

	public class OrderPropDescriptor : PropertyDescriptor {
		public OrderPropDescriptor()
			: base("ShippingAddress.City", null) { }

		public override object GetValue(object component) {
			Order obj = (Order)component;
			return obj.ShippingAddress.City;
		}

		public override void SetValue(object component, object value) {
			Order obj = (Order)component;
			obj.ShippingAddress.City = (string)value;
		}

		public override bool CanResetValue(object component) {
			return false;
		}

		public override void ResetValue(object component) {

		}

		public override bool ShouldSerializeValue(object component) {
			return false;
		}

		public override bool IsReadOnly {
			get {
				return false;
			}
		}

		public override Type ComponentType {
			get {
				return typeof(Order);
			}
		}

		public override Type PropertyType {
			get {
				return typeof(string);
			}
		}
	}

}