

#region Using
using System;
#endregion

namespace Geotools.CoordinateTransformations
{
	/// <summary>
	/// Creates coordinate transformation objects from codes
	/// </summary>
	/// <remarks>
	/// The codes are maintained by an external authority.
	/// A commonly used authority is EPSG, which is also used in the GeoTIFF
	/// standard.
	/// </remarks>
	public interface ICoordinateTransformationAuthorityFactory 
	{
	
		/// <summary>
		/// The name of the authority.
		/// </summary>
		string Authority{get;}

		/// <summary>
		/// Creates a transformation from a single transformation code. 
		/// </summary>
		/// <remarks>
		/// The 'Authority' and 'AuthorityCode' values of the created object will be set
		/// to the authority of this object, and the code specified by the client,
		/// respectively.  The other metadata values may or may not be set.
		/// </remarks>
		/// <param name="code">param code Coded value for transformation.</param>
		ICoordinateTransformation CreateFromTransformationCode(string code);
		
		/// <summary>
		/// Creates a transformation from coordinate system codes.
		/// </summary>
		/// <param name="sourceCode">Coded value of source coordinate system.</param>
		/// <param name="targetCode">Coded value of target coordinate system.</param>
		ICoordinateTransformation CreateFromCoordinateSystemCodes(string sourceCode,string targetCode);
	}

}
