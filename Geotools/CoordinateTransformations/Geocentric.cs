

#region Using
using System;
#endregion

namespace Geotools.CoordinateTransformations
{
	/// <summary>
	/// Transforms three dimensional geographic points  to geocentric
	/// coordinate points. Input points must be longitudes, latitudes
	/// and heights above the ellipsoid.
	/// </summary>
	/// <remarks>
	/// Not implemented.
	/// </remarks>
	internal class Geocentric : MathTransform
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the Geocentric class.
		/// </summary>
		public Geocentric()
		{
			throw new NotImplementedException();
		}
		#endregion
	}
}
