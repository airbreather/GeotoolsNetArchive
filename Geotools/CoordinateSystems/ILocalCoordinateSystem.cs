

#region Using
using System;
#endregion

namespace Geotools.CoordinateReferenceSystems
{
	/// <summary>
	///  A local coordinate system, with uncertain relationship to the world. 
	/// </summary>
	/// <remarks>
	/// <para>In general, a local coordinate system cannot be related to other
	/// coordinate systems. However, if two objects supporting this interface
	/// have the same dimension, axes, units and datum then client code
	/// is permitted to assume that the two coordinate systems are identical.</para>
	/// <para>This allows several datasets from a common source (e.g. a CAD system)
	/// to be overlaid.
	/// In addition, some implementations of the Coordinate Transformation (CT)
	/// package may have a mechanism for correlating local datums.
	/// (E.g. from a database of transformations, which is created and
	/// maintained from real-world measurements.)</para>
	/// </remarks>
	public interface ILocalCoordinateSystem : ICoordinateSystem
	{
		/// <summary>
		/// Gets the local datum.
		/// </summary>
		ILocalDatum LocalDatum { get; }
	}
}
