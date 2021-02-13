using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data.Objects;

namespace OrderIT.WinGUI {
	public class CustomBindingList<T> : BindingList<T> {
		private ObjectContext _ctx;
		public CustomBindingList(IList<T> list, ObjectContext ctx) : base(list) {
			_ctx = ctx;
		}
		protected override void RemoveItem(int index) {
			_ctx.DeleteObject(this[index]);
			base.RemoveItem(index);
		}
	}
}
