

#region Using
using System;
#endregion

namespace Geotools.CoordinateReferenceSystems
{

	/// <summary>
	/// An aggregate of two coordinate systems (CRS).
	/// One of these is usually a CRS based on a two dimensional coordinate system
	/// such as a geographic or a projected coordinate system with a horizontal
	/// datum.  The other is a vertical CRS which is a one-dimensional coordinate
	/// system with a vertical datum.
	/// </summary>
	public interface ICompoundCoordinateSystem : ICoordinateSystem
	{
		/// <summary>
		/// Gets first sub-coordinate system. 
		/// </summary>
		ICoordinateSystem HeadCS { get; }
		/// <summary>
		/// Gets second sub-coordinate system.
		/// </summary>
		ICoordinateSystem TailCS { get; }	
	}
}
