using System;

namespace Geotools.CoordinateReferenceSystems
{
	/// <summary>
	/// Proceedure used to measure vertical distances.
	/// </summary>
	public class VerticalDatum : Datum, IVerticalDatum
	{
		/// <summary>
		/// Initializes a new instance of the VerticalDatum class with the specified properties.
		/// </summary>
		/// <param name="name">The name of the vertical datum.</param>
		/// <param name="verticalDatumType">The datum type.</param>
		internal VerticalDatum(string name, DatumType verticalDatumType)
			: this(verticalDatumType,"","","",name,"","")
		{
		}

		/// <summary>
		/// Initializes a new instance of the VerticalDatum class with the specified properties.
		/// </summary>
		/// <param name="datumType">The datum type.</param>
		/// <param name="remarks">The provider-supplied remarks.</param>
		/// <param name="authority">The authority-specific identification code.</param>
		/// <param name="authorityCode">The authority-specific identification code.</param>
		/// <param name="name">The name.</param>
		/// <param name="alias">The alias.</param>
		/// <param name="abbreviation">The abbreviation.</param>
		public VerticalDatum(	DatumType datumType,
			string remarks,
			string authorityCode,
			string authority, 
			string name,
			string alias,
			string abbreviation )
			: base(datumType, remarks,authority,authorityCode, name, alias, abbreviation )
		{
		}

		#region Static
		
		/// <summary>
		/// Default vertical datum for ellipsoidal heights. Ellipsoidal heights
		/// are measured along the normal to the ellipsoid used in the definition
		/// of horizontal datum.
		/// </summary>
		public static VerticalDatum Ellipsoidal
		{
			get
			{
				return new VerticalDatum("Ellipsoidal", DatumType.IVD_Ellipsoidal);
			}
		}
		#endregion
	}
}
