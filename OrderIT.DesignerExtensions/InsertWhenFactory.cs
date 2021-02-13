using System.Xml.Linq;
using System.Linq;
using System.ComponentModel.Composition;
using Microsoft.Data.Entity.Design.Extensibility;

namespace OrderIT.DesignerExtensions
{
	[Export(typeof(IEntityDesignerExtendedProperty))]
	[EntityDesignerExtendedProperty(EntityDesignerSelection.ConceptualModelProperty)]
	class InsertWhenFactory : IEntityDesignerExtendedProperty
	{
		public object CreateProperty(XElement element, PropertyExtensionContext context)
		{
			var edmXName = XName.Get("Key", "http://schemas.microsoft.com/ado/2008/09/edm");
			var keys = element.Parent.Element(edmXName).Elements().Select(e => e.Attribute("Name").Value);
			if (keys.Contains(element.Attribute("Name").Value)) return new InsertWhenValue(element, context);
			return null;
		}
	}
}