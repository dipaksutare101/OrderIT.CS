using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SqlServer.Types;
using System.IO;

namespace OrderIT.Model
{
	public partial class GeometrySample
	{
		SqlGeometry _geometry = null;

		public SqlGeometry TypedSpatialData
		{
			get
			{
				if (_geometry == null)
				{
					_geometry = new SqlGeometry();
					using (var stream = new System.IO.MemoryStream(SpatialData))
					using (var rdr = new System.IO.BinaryReader(stream))
						_geometry.Read(rdr);
				}
				return _geometry;
			}
			set
			{
				_geometry = value;
				using (var ms = new MemoryStream())
				{
					using (var bw = new BinaryWriter(ms))
						value.Write(bw);

					SpatialData = ms.ToArray();
				}
			}
		}
	}
}
