

#region Using
using System;
#endregion

namespace Geotools.CoordinateReferenceSystems
{
	/// <summary>
	/// Definition of angular units.
	/// </summary>
	public interface IAngularUnit : IUnit
	{
		/// <summary>
		/// Returns the number of radians per AngularUnit.
		/// </summary>
		double RadiansPerUnit { get; }
		
	}	
}
