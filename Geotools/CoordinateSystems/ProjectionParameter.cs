

#region Using
using System;
#endregion

namespace Geotools.CoordinateReferenceSystems
{
	/// <summary>
	/// A named projection parameter value.
	/// </summary>
	/// <remarks>
	/// The linear units of parameters' values match the linear units of the
	/// containing projected coordinate system.  The angular units of parameter
	/// values match the angular units of the geographic coordinate system that
	/// the projected coordinate system is based on.  (Notice that this is
	/// different from CT_Parameter, where the units are always meters and
	/// degrees.)
	/// </remarks>
	public struct ProjectionParameter
	{
		public ProjectionParameter(string name, double v)
		{
			Name=name;
			Value=v;
		}
		/// <summary>
		/// The parameter name.
		/// </summary>
		public string Name;
		/// <summary>
		/// The parameter value.
		/// </summary>
		public double Value;
	}
}
