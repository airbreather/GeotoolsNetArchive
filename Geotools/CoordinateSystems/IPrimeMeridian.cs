

#region Using
using System;
#endregion

namespace Geotools.CoordinateReferenceSystems
{
	/// <summary>
	///  A meridian used to take longitude measurements from.
	/// </summary>
	public interface IPrimeMeridian : IInfo
	{
		/// <summary>
		/// R Returns the AngularUnits.
		/// </summary>
		IAngularUnit AngularUnit { get; }
		
		/// <summary>
		/// Returns the longitude value relative to the Greenwich Meridian.
		/// </summary>
		/// <remarks>The longitude is expressed in this objects angular units.</remarks>
		double Longitude { get; }
		
	}
}
