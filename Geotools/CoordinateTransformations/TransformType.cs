

#region Using
using System;
#endregion

namespace Geotools.CoordinateTransformations
{
	/// <summary>
	/// Semantic type of transform used in coordinate transformation.
	/// </summary>
	public enum TransformType
	{	
		/// <summary>
		/// Unknown or unspecified type of transform.
		/// </summary>
		Other=0,

		/// <summary>
		/// Transform depends only on defined parameters.
		/// For example, a cartographic projection.
		/// </summary>
		Conversion=1,

		/// <summary>
		/// Transform depends only on empirically derived parameters.
		/// For example a datum transformation.
		/// </summary>
		Transformation=2,

		/// <summary>
		/// Transform depends on both defined and empirical parameters.
		/// </summary>
		ConversionAndTransformation=3
	}
}
