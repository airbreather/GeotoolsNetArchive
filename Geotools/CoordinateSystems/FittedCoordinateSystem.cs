using System;

namespace Geotools.CoordinateReferenceSystems
{
	/// <summary>
	/// A coordinate system which sits inside another coordinate system. The fitted coordinate system
	/// can be rotated and shifted, or use any other math transform to inject itself into the base
	/// coordinate system.
	/// </summary>
	/// <remarks>
	/// <para>The fitted coordinate system
	/// can be rotated and shifted, or use any other math transform to inject itself into the base
	/// coordinate system.
	/// </para>
	/// <para>This class is not implemented.</para>
	/// </remarks>
	/// <exception cref="NotImplementedException">This class is not implemented.</exception>
	public class FittedCoordinateSystem : CoordinateSystem, IFittedCoordinateSystem
	{
		internal FittedCoordinateSystem() : base("","","","","","")
		{
			throw new NotImplementedException();
		}

		public string GetToBase()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Gets Well-Known Text of a math transform to the base coordinate system. The dimension of this
		/// fitted coordinate system is determined by the source dimension of the math transform. The
		/// transform should be one-to-one within this coordinate system's domain, and the base coordinate
		/// system dimension must be at least as big as the dimension of this coordinate system.
		/// </summary>
		/// <remarks>Not implemented.</remarks>
		public string ToBase
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		
		public ICoordinateSystem BaseCoordinateSystem
		{
			get
			{
				throw new NotImplementedException();
			}
		}
	}
}
