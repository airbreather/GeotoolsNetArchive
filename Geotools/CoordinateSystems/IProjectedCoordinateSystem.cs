

#region Using
using System;
#endregion

namespace Geotools.CoordinateReferenceSystems
{
	/// <summary>
	///  A 2D cartographic coordinate system.
	/// </summary>
	public interface IProjectedCoordinateSystem : IHorizontalCoordinateSystem
	{
		/// <summary>
		/// Returns the GeographicCoordinateSystem.
		/// </summary>
		IGeographicCoordinateSystem GeographicCoordinateSystem { get; }

		/// <summary>
		/// Returns the LinearUnits.
		/// </summary>
		/// <remarks>
		///  The linear unit must be the same as the CS_CoordinateSystem units.
		/// </remarks>
		ILinearUnit LinearUnit { get; }

		/// <summary>
		/// Gets the projection.
		/// </summary>
		IProjection Projection { get; }
	}
}
