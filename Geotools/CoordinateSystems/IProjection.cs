

#region Using
using System;
#endregion

namespace Geotools.CoordinateReferenceSystems
{
	/// <summary>
	/// Gets number of parameters of the projection.
	/// </summary>
	public interface IProjection : IInfo
	{
		/// <summary>
		/// Gets the projection classification name (e.g. 'Transverse_Mercator').
		/// </summary>
		string ClassName { get; }

		/// <summary>
		/// Gets number of parameters of the projection. 
		/// </summary>
		int NumParameters { get; }

		/// <summary>
		/// Gets an indexed parameter of the projection.
		/// </summary>
		/// <param name="Index">Zero based index of parameter to fetch.</param>
		ProjectionParameter GetParameter(int Index);
	}
}
