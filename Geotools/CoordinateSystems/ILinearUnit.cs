

#region Using
using System;
#endregion

namespace Geotools.CoordinateReferenceSystems
{
	/// <summary>
	/// Definition of linear units.
	/// </summary>
	public interface ILinearUnit : IUnit
	{
		/// <summary>
		/// Returns the number of meters per LinearUnit.
		/// </summary>
		double MetersPerUnit { get; }
		
	}
}
