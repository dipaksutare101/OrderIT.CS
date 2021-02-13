using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Reflection;

namespace OrderIT.Model {
	public class SimplePropertyDescriptor : PropertyDescriptor {
		private PropertyInfo _property;

		public SimplePropertyDescriptor(PropertyInfo property)
			: base(property.Name,
				(Attribute[])property.GetCustomAttributes(typeof(Attribute), true)) {
			_property = property;
		}

		public PropertyInfo Field { get { return _property; } }

		public override bool Equals(object obj) {
			SimplePropertyDescriptor other = obj as SimplePropertyDescriptor;
			return other != null && other._property.Equals(_property);
		}

		public override int GetHashCode() { return _property.GetHashCode(); }

		public override bool IsReadOnly { get { return false; } }

		public override void ResetValue(object component) { }

		public override bool CanResetValue(object component) { return false; }

		public override bool ShouldSerializeValue(object component) {
			return true;
		}

		public override Type ComponentType {
			get { return _property.DeclaringType; }
		}

		public override Type PropertyType { get { return _property.PropertyType; } }

		public override object GetValue(object component) {
			return _property.GetValue(component, null);
		}

		public override void SetValue(object component, object value) {
			_property.SetValue(component, value, null);
			OnValueChanged(component, EventArgs.Empty);
		}
	}
}
