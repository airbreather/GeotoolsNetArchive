

#region Using
using System;
#endregion

namespace Geotools.CoordinateReferenceSystems
{
	/// <summary>
	/// Creates spatial reference objects using codes.
	/// </summary>
	/// <remarks>
	/// The codes are maintained by an external authority. A commonly used
	/// authority is EPSG, which is also used in the GeoTIFF standard.
	/// </remarks>
	public interface ICoordinateSystemAuthorityFactory
	{
		/// <summary>
		/// Returns an AngularUnit object from a code.
		/// </summary>
		IAngularUnit CreateAngularUnit(string code);

		/// <summary>
		/// Creates a 3D coordinate system from a code. 
		/// </summary>
		ICompoundCoordinateSystem CreateCompoundCoordinateSystem(string code);

		/// <summary>
		/// Returns an Ellipsoid object from a code.
		/// </summary>
		IEllipsoid CreateEllipsoid(string code);

		/// <summary>
		/// Returns a GeographicCoordinateSystem object from a code.
		/// </summary>
		IGeographicCoordinateSystem CreateGeographicCoordinateSystem(string code);

		/// <summary>
		/// The horizontal coordinate system could be geographic or projected.
		/// </summary>
		IHorizontalCoordinateSystem CreateHorizontalCoordinateSystem(string code);

		/// <summary>
		/// Returns a HorizontalDatum object from a code.
		/// </summary>
		IHorizontalDatum CreateHorizontalDatum(string code);

		/// <summary>
		/// Returns a LinearUnit object from a code.
		/// </summary>
		ILinearUnit CreateLinearUnit(string code);

		/// <summary>
		/// Returns a PrimeMeridian object from a code.
		/// </summary>
		IPrimeMeridian CreatePrimeMeridian(string code);

		/// <summary>
		/// Returns a ProjectedCoordinateSystem object from a code.
		/// </summary>
		IProjectedCoordinateSystem CreateProjectedCoordinateSystem(string code);

		/// <summary>
		/// Create a vertical coordinate system from a code.
		/// </summary>
		IVerticalCoordinateSystem CreateVerticalCoordinateSystem(string code);

		/// <summary>
		/// Creates a vertical datum from a code.
		/// </summary>
		IVerticalDatum CreateVerticalDatum(string code);

		/// <summary>
		/// Gets a description of the object corresponding to a code.
		/// </summary>
		/// <param name="code"></param>
		/// <returns></returns>
		string DescriptionText(string code);

		/// <summary>
		///  Gets the Geoid code from a WKT name.
		/// </summary>
		/// <remarks>
		///  In the OGC definition of WKT horizontal datums, the geoid is
		///  referenced by a quoted string, which is used as a key value.  This
		///   method converts the key value string into a code recognized by this
		///   authority.
		/// </remarks>
		/// <param name="WKT">wkt Name of geoid defined by OGC (e.g. "European_Datum_1950")</param>
		/// <returns></returns>
		string GeoidFromWKTName(string WKT);

		/// <summary>
		/// Gets the WKT name of a Geoid.
		/// </summary>
		/// <remarks>
		/// In the OGC definition of WKT horizontal datums, the geoid is
		/// referenced by a quoted string, which is used as a key value.  This
		/// method gets the OGC WKT key value from a geoid code.
		/// </remarks>
		/// <param name="Geoid"></param>
		/// <returns>geoid Code value for geoid allocated by authority.</returns>
		string WktGeoidName(string Geoid);

		/// <summary>
		/// Returns the authority name.
		/// </summary>
		string Authority { get; }
 
	}
}
