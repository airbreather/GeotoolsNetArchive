

#region Using
using System;
#endregion

namespace Geotools.CoordinateReferenceSystems
{

	/// <summary>
	/// A coordinate system which sits inside another coordinate system. 
	/// The fitted coordinate system can be rotated and shifted, or use any other
	/// math transform to inject itself into the base coordinate system.
	/// </summary>
	public interface IFittedCoordinateSystem : ICoordinateSystem
	{
		/// <summary>
		/// Gets underlying coordinate system.
		/// </summary>
		ICoordinateSystem BaseCoordinateSystem { get; }


		/// <summary>
		/// Gets Well-Known Text of a math transform to the base coordinate system.
		/// </summary>
		/// <remarks>
		/// The dimension of this fitted coordinate system is
		/// determined by the source dimension of the math transform.  
		/// The transform should be one-to-one within this coordinate
		/// system's domain, and the base coordinate system dimension must be
		/// at least as big as the dimension of this coordinate system.
		/// </remarks>
		/// <returns></returns>
		string GetToBase();
		
	}
}
