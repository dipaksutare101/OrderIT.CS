using System;
using System.Linq;
using System.Xml.Linq;
using System.ComponentModel;
using Microsoft.Data.Entity.Design.Extensibility;

namespace OrderIT.DesignerExtensions
{
	class InsertWhenValue
	{
		internal static XName ELEMENTNAME = XName.Get("InsertWhen", "http://EFEX");

		private XElement _property;
		private PropertyExtensionContext _context;

		public InsertWhenValue(XElement property, PropertyExtensionContext context)
		{
			_context = context;
			_property = property;
		}

		[DisplayName("Add to context value")]
		[Description("Get or set the value by which the entity is added to the context")]
		[Category("Extensions")]
		[DefaultValue(false)]
		public string Value
		{
			get
			{
				XElement child = _property.Element(ELEMENTNAME);
				return (child == null) ? String.Empty : child.Value;
			}

			set
			{
				if (String.IsNullOrEmpty(value)) return;

				using (EntityDesignerChangeScope scope = _context.	CreateChangeScope("Set InsertWhen"))
				{
					var element = _property.Element(ELEMENTNAME);
					if (element == null)
						_property.Add(new XElement(ELEMENTNAME, value));
					else
						element.SetValue(value);

					scope.Complete();
				}
			}
		}
	}
}