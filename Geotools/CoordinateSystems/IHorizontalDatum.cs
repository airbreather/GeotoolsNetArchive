

#region Using
using System;
#endregion

namespace Geotools.CoordinateReferenceSystems
{
	/// <summary>
	/// Procedure used to measure positions on the surface of the Earth.
	/// </summary>
	public interface IHorizontalDatum : IDatum
	{
		/// <summary>
		/// Returns the Ellipsoid.
		/// </summary>
		IEllipsoid Ellipsoid { get; }

		/// <summary>
		/// Gets preferred parameters for a Bursa Wolf transformation into WGS84. 
		/// </summary>
		/// <remarks>
		/// The 7 returned values correspond to (dx,dy,dz) in meters, (ex,ey,ez)
		/// in arc-seconds, and scaling in parts-per-million.
		/// This method will always fail for horizontal datums with type CS_HD_Other.
		/// This method may also fail if no suitable transformation is available.
		/// Failures are indicated using the normal failing behavior of the DCP
		/// (e.g. throwing an exception).
		/// </remarks>
		WGS84ConversionInfo WGS84Parameters { get; }
		
	}
}
