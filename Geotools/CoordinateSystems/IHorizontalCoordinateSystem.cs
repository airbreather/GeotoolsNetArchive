

#region Using
using System;
#endregion

namespace Geotools.CoordinateReferenceSystems
{
	/// <summary>
	/// A 2D coordinate system suitable for positions on the Earth's surface.
	/// </summary>
	public interface IHorizontalCoordinateSystem : ICoordinateSystem
	{
		/// <summary>
		/// Returns the HorizontalDatum.
		/// </summary>
		IHorizontalDatum HorizontalDatum { get; }
		
	}
}
