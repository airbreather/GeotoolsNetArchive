

#region Using
using System;
#endregion

namespace Geotools.CoordinateReferenceSystems
{
	/// <summary>
	/// A base interface for metadata applicable to coordinate system objects.
	/// </summary>
	/// <remarks>
	/// <para>
	/// The metadata items 'Abbreviation', 'Alias', 'Authority', 'AuthorityCode',
	/// 'Name' and 'Remarks' were specified in the Simple Features interfaces,
	/// so they have been kept here.</para>
	/// 
	/// <para>This specification does not dictate what the contents of these items should
	/// be.  However, the following guidelines are suggested:</para>
	/// 
	/// <para>When CS_CoordinateSystemAuthorityFactory is used to create an object, the
	/// 'Authority' and 'AuthorityCode' values should be set to the authority name
	/// of the factory object, and the authority code supplied by the client,
	/// respectively.  The other values may or may not be set.  (If the authority is
	/// EPSG, the implementer may consider using the corresponding metadata values
	/// in the EPSG tables.)</para>
	/// 
	/// <para>When CS_CoordinateSystemFactory creates an object, the 'Name' should be set
	/// to the value supplied by the client.  All of the other metadata items should
	/// be left empty.</para>
	/// </remarks>
	public interface IInfo
	{
		/// <summary>
		/// Gets the abbreviation.
		/// </summary>
		string Abbreviation { get; }

		/// <summary>
		/// Gets the alias.
		/// </summary>
		string Alias { get; }

		/// <summary>
		/// Gets the authority name.
		/// </summary>
		/// <remarks>
		/// An Authority is an organization that maintains definitions of Authority
		/// Codes.  For example the European Petroleum Survey Group (EPSG) maintains
		/// a database of coordinate systems, and other spatial referencing objects,
		/// where each object has a code number ID.  For example, the EPSG code for a
		/// WGS84 Lat/Lon coordinate system is '4326'.
		/// </remarks>
		string Authority { get; }

		/// <summary>
		/// Gets the authority-specific identification code.
		/// </summary>
		/// <remarks>
		/// The AuthorityCode is a compact string defined by an Authority to reference
		/// a particular spatial reference object.  For example, the European Survey
		/// Group (EPSG) authority uses 32 bit integers to reference coordinate systems
		/// so all their code strings will consist of a few digits.  The EPSG code for
		/// WGS84 Lat/Lon is '4326'.
		/// </remarks>
		string AuthorityCode { get; }

		/// <summary>
		///  Gets the name.
		/// </summary>
		string Name { get; }

		/// <summary>
		/// Gets the provider-supplied remarks.
		/// </summary>
		string Remarks { get; }

		/// <summary>
		/// Gets a Well-Known text representation of this object.
		/// </summary>
		string WKT { get; }

		/// <summary>
		/// Gets an XML representation of this object.
		/// </summary>
		string XML { get; }
 
	}
}
