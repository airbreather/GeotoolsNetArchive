

#region Using
using System;
#endregion

namespace Geotools.CoordinateReferenceSystems
{
	/// <summary>
	/// A 3D coordinate system, with its origin at the center of the Earth.
	/// </summary>
	/// <remarks>
	/// The X axis points towards the prime meridian. The Y axis points East
	/// or West. The Z axis points North or South. By default the Z axis will
	/// point North, and the Y axis will point East (e.g. a right handed
	/// system), but you should check the axes for non-default values.
	/// </remarks>
	public interface IGeocentricCoordinateSystem : ICoordinateSystem
	{
		/// <summary>
		/// Returns the HorizontalDatum.
		/// </summary>
		/// <remarks>
		/// The horizontal datum is used to determine where the center of the Earth
		/// is considered to be. All coordinate points will be measured from the
		/// center of the Earth, and not the surface.
		/// </remarks>
		IHorizontalDatum HorizontalDatum { get; }

		/// <summary>
		/// Gets the units used along all the axes.
		/// </summary>
		ILinearUnit LinearUnit { get; }

		/// <summary>
		/// Returns the PrimeMeridian.
		/// </summary>
		IPrimeMeridian PrimeMeridian { get; }
	
	}
}
