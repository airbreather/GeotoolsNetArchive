

#region Using
using System;
using Geotools.CoordinateReferenceSystems;
#endregion

namespace Geotools.CoordinateTransformations
{
	
	/// <summary>
	/// Creates coordinate transformations.
	/// </summary>
	public interface ICoordinateTransformationFactory 
	{
		/// <summary>
		/// Creates a transformation between two coordinate systems.
		/// </summary>
		/// <remarks>
		/// This method will examine the coordinate systems in order to
		/// construct a transformation between them. This method may fail if no
		/// path between the coordinate systems is found, using the normal failing
		/// behavior of the DCP (e.g. throwing an exception).
		/// </remarks>
		/// <param name="sourceCS">Input coordinate system.</param>
		/// <param name="targetCS">Output coordinate system.</param>
		ICoordinateTransformation CreateFromCoordinateSystems(ICoordinateSystem sourceCS, ICoordinateSystem targetCS);
	}

}
