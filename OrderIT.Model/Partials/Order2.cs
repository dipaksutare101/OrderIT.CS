using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace OrderIT.Model {
	public partial class Order : IDataErrorInfo {
		void OnActualShippingDateChanged(Nullable<System.DateTime> value){
			if (value.HasValue && EstimatedShippingDate.HasValue && value.Value < EstimatedShippingDate.Value) {
				//errors.Add("ActualShippingDate", "Actual shipping date cannot be lower that estimated shipping date");
			}
		}

		Dictionary<string, string> errors = new Dictionary<string, string>();

		#region IDataErrorInfo Members

		string IDataErrorInfo.Error {
			get { return errors.Any() ? "There are errors" : String.Empty; }
		}

		string IDataErrorInfo.this[string columnName] {
			get { 
				if (errors.ContainsKey(columnName))
					return errors[columnName];
				else
					return String.Empty;
			}
		}

		#endregion
	}
}
