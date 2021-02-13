using System;
using System.Linq;
using System.Xml.Linq;
using System.ComponentModel;
using Microsoft.Data.Entity.Design.Extensibility;

namespace OrderIT.DesignerExtensions
{
	class AuditableValue
	{
		internal static XName ELEMENTNAME = XName.Get("Auditable", "http://EFEX");

		private XElement _property;
		private PropertyExtensionContext _context;

		public AuditableValue(XElement property, PropertyExtensionContext context)
		{
			_context = context;
			_property = property;
		}

		[DisplayName("Auditable")]
		[Description("Get or set the value indicating if the class is auditable")]
		[Category("Extensions")]
		[DefaultValue(false)]
		public bool Value
		{
			get
			{
				XElement child = _property.Element(ELEMENTNAME);
				return (child == null) ? false : bool.Parse(child.Value);
			}

			set
			{
				using (EntityDesignerChangeScope scope = _context.	CreateChangeScope("Set Auditable"))
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