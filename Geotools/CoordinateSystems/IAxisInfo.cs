

#region Using
using System;
#endregion

namespace Geotools.CoordinateReferenceSystems
{
	/// <summary>
	/// Details of axis. This is used to label axes, and indicate the orientation.
	/// </summary>
	public interface IAxisInfo
	{
		/// <summary>
		/// Human readable name for axis.
		/// </summary>
		/// <remarks>Possible values are X, Y, Long, Lat or any other short string.</remarks>
		string Name{get;}

		/// <summary>
		/// Gets enumerated value for orientation.
		/// </summary>
		AxisOrientation Orientation{get;}
	}
}
