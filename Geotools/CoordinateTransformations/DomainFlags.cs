

#region Using
using System;
#endregion

namespace Geotools.CoordinateTransformations
{
	/// <summary>
	/// Flags indicating parts of domain covered by a convex hull.
	/// </summary>
	/// <remarks>
	/// These flags can be combined.  For example, the value 3 corresponds to
	/// a combination of IDF_Inside and MF_DF_Outside, which means that some
	/// parts of the convex hull are inside the domain, and some parts of the
	/// convex hull are outside the domain.
	/// </remarks>
	public class DomainFlags
	{
		public int Value;

		
		/// <summary>
		/// At least one point in a convex hull is inside the transform's domain.
		/// </summary>
		public static int Inside=1;

		/// <summary>
		/// At least one point in a convex hull is outside the transform's domain.
		/// </summary>
		public static int Outside=2;
		
		/// <summary>
		/// At least one point in a convex hull is not transformed continuously.
		/// </summary>
		/// <remarks>
		/// As an example, consider a "Longitude_Rotation" transform which adjusts
		/// longitude coordinates to take account of a change in Prime Meridian.
		/// If the rotation is 5 degrees east, then the point (Lat=175,Lon=0)
		/// is not transformed continuously, since it is on the meridian line
		/// which will be split at +180/-180 degrees.
		/// </remarks>
		public static int Discontinuous=4;
	}
}
