

#region Using
using System;
#endregion

namespace Geotools.CoordinateReferenceSystems
{
	/// <summary>
	/// An approximation of the Earth's surface as a squashed sphere.
	/// </summary>
	public interface IEllipsoid : IInfo
	{
		/// <summary>
		/// Is the Inverse Flattening definitive for this ellipsoid?
		/// </summary>
		/// <remarks>
		/// Some ellipsoids use the IVF as the defining value, and calculate the
		/// polar radius whenever asked. Other ellipsoids use the polar radius to
		/// calculate the IVF whenever asked. This distinction can be important to
		/// avoid floating-point rounding errors.
		/// </remarks>
		/// <returns></returns>
		bool IsIvfDefinitive();

		/// <summary>
		///  The units of the semi-major and semi-minor axis values.
		/// </summary>
		ILinearUnit AxisUnit { get; }

		/// <summary>
		/// Returns the value of the inverse of the flattening constant.
		/// </summary>
		/// <remarks>
		/// The inverse flattening is related to the equatorial/polar radius
		/// by the formula ivf=re/(re-rp). For perfect spheres, this formula
		/// breaks down, and a special IVF value of zero is used.
		/// </remarks>
		double InverseFlattening { get; }

		/// <summary>
		///  The returned length is expressed in this object's axis units.
		/// </summary>
		double SemiMajorAxis { get; }

		/// <summary>
		/// The returned length is expressed in this object's axis units.
		/// </summary>
		double SemiMinorAxis { get; }
		
	}
}
