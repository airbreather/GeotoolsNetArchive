using System;
using Geotools.Positioning;

namespace Geotools.CoordinateReferenceSystems
{
	/// <summary>
	/// A 2D coordinate system suitable for positions on the Earth's surface.
	/// </summary>
	public class HorizontalCoordinateSystem : CoordinateSystem, IHorizontalCoordinateSystem
	{
		IHorizontalDatum _horizontalDatum;
		IAxisInfo[] _axisInfoArray;

		/// <summary>
		///  Initializes a new instance of the HorizontalCoordinateSystem class with the specified parameters.
		/// </summary>
		/// <param name="horizontalDatum">The horizontal datum to use.</param>
		/// <param name="axisInfoArray">Array of axis information.</param>
		public HorizontalCoordinateSystem(IHorizontalDatum horizontalDatum,IAxisInfo[] axisInfoArray)
			: this(horizontalDatum,axisInfoArray, "","","","","","")
		{
		}

		/// <summary>
		/// Initializes a new instance of the HorizontalCoordinateSystem class with the specified parameters.
		/// </summary>
		/// <param name="horizontalDatum">The horizontal datum to use.</param>
		/// <param name="axisInfoArray">Array of axis information.</param>
		/// <param name="remarks">Remarks about this object.</param>
		/// <param name="authority">The name of the authority.</param>
		/// <param name="authorityCode">The code the authority uses to identidy this object.</param>
		/// <param name="name">The name of the object.</param>
		/// <param name="alias">The alias of the object.</param>
		/// <param name="abbreviation">The abbreviated name of this object.</param>

		public HorizontalCoordinateSystem(IHorizontalDatum horizontalDatum,IAxisInfo[] axisInfoArray,
			string remarks, string authority, string authorityCode, string name, string alias, string abbreviation)
			: base(remarks, authority, authorityCode, name, alias, abbreviation)
		{
			if (horizontalDatum==null)
			{
				throw new ArgumentNullException("horizontalDatum");
			}
			if (axisInfoArray==null)
			{
				throw new ArgumentNullException("axisInfoArray");
			}
			_horizontalDatum = horizontalDatum;
			_axisInfoArray = axisInfoArray;
		}


		#region Implementation of IHorizontalCoordinateSystem

		

		/// <summary>
		/// Gets the horizontal datum information.
		/// </summary>
		public IHorizontalDatum HorizontalDatum
		{
			get
			{
				return _horizontalDatum;
			}
		}

		
		#endregion
	}
}
