using System;

namespace Geotools.CoordinateReferenceSystems
{
	/// <summary>
	/// A 3D coordinate system, with its origin at the centre of the Earth. 
	/// </summary>
	/// <remarks>
	/// The X axis points towards the
	/// prime meridian. The Y axis points East or West. The Z axis points North or South. By default the
	/// Z axis will point North, and the Y axis will point East (e.g. a right handed system), but you should
	/// check the axes for non-default values.
	/// </remarks>
	public class GeocentricCoordinateSystem: CoordinateSystem, IGeocentricCoordinateSystem
	{
		internal GeocentricCoordinateSystem(): base("","","","","","")
		{
			throw new NotImplementedException();
		}

		#region Implementation of IGeocentricCoordinateSystem
		
		public ILinearUnit LinearUnit
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public IHorizontalDatum HorizontalDatum
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		

		public IPrimeMeridian PrimeMeridian
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		#endregion
	}
}
