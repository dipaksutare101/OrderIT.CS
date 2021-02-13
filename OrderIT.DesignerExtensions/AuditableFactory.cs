using System.Xml.Linq;
using System.Linq;
using System.ComponentModel.Composition;
using Microsoft.Data.Entity.Design.Extensibility;

namespace OrderIT.DesignerExtensions
{
	[Export(typeof(IEntityDesignerExtendedProperty))]
	[EntityDesignerExtendedProperty(EntityDesignerSelection.ConceptualModelEntityType)]
	class AuditableFactory : IEntityDesignerExtendedProperty
	{
		public object CreateProperty(XElement element, PropertyExtensionContext context)
		{
			return new AuditableValue(element, context);
		}
	}
}