

#region Using
using System;
#endregion

namespace Geotools.CoordinateReferenceSystems
{
	/// <summary>
	/// A one-dimensional coordinate system suitable for vertical measurements. 
	/// </summary>
	public interface IVerticalCoordinateSystem : ICoordinateSystem
	{
		/// <summary>
		/// Gets the vertical datum, which indicates the measurement method.
		/// </summary>
		IVerticalDatum VerticalDatum { get; }

		/// <summary>
		/// Gets the units used along the vertical axis.
		/// </summary>
		/// <remarks>
		/// The vertical units must be the same as the CS_CoordinateSystem units.
		/// </remarks>
		ILinearUnit VerticalUnit { get; }
	}

}
