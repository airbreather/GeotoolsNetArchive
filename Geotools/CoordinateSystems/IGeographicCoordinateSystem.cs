

#region Using
using System;
#endregion

namespace Geotools.CoordinateReferenceSystems
{
	/// <summary>
	/// A coordinate system based on latitude and longitude.
	/// </summary>
	/// <remarks>
	///  Some geographic coordinate systems are Lat/Lon, and some are Lon/Lat.
	///  You can find out which this is by examining the axes.  You should also
	///  check the angular units, since not all geographic coordinate systems use
	///  degrees.
	/// </remarks>
	public interface IGeographicCoordinateSystem : IHorizontalCoordinateSystem
	{
		/// <summary>
		/// Returns the AngularUnit.
		/// </summary>
		/// <remarks>
		/// The angular unit must be the same as the CS_CoordinateSystem units.
		/// </remarks>
		IAngularUnit AngularUnit { get; }
	
		/// <summary>
		/// Gets the number of available conversions to WGS84 coordinates.
		/// </summary>
		int NumConversionToWGS84 { get; }

		/// <summary>
		/// Returns the PrimeMeridian.
		/// </summary>
		IPrimeMeridian PrimeMeridian { get; }
		
		/// <summary>
		/// Gets details on a conversion to WGS84.
		/// </summary>
		/// <remarks>
		/// Some geographic coordinate systems provide several transformations
		/// into WGS84, which are designed to provide good accuracy in different
		/// areas of interest.  The first conversion (with index=0) should
		/// provide acceptable accuracy over the largest possible area of
		/// interest.
		/// </remarks>
		/// <param name="Index">Zero based index of conversion to fetch.</param>
		WGS84ConversionInfo GetWGS84ConversionInfo(int Index) ;
	}
}
