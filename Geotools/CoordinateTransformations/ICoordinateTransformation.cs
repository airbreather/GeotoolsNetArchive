
#region Using
using System;
using Geotools.CoordinateReferenceSystems;
#endregion

namespace Geotools.CoordinateTransformations
{
	/// <summary>
	/// Describes a coordinate transformation.
	/// </summary>
	/// <remarks>
	/// <para>This interface only describes a coordinate transformation, it does not
	/// actually perform the transform operation on points.  To transform
	/// points you must use a math transform.</para>
	/// <para>The math transform will transform positions in the source coordinate
	/// system into positions in the target coordinate system.
	/// </para>
	/// </remarks>
	public interface ICoordinateTransformation 
	{
		/// <summary>
		/// Name of transformation.
		/// </summary>

		string Name{get;}

		/// <summary>
		/// Authority which defined transformation and parameter values.
		/// </summary>
		/// <remarks>
		/// An Authority is an organization that maintains definitions of Authority
		/// Codes.  For example the European Petroleum Survey Group (EPSG) maintains
		/// a database of coordinate systems, and other spatial referencing objects,
		/// where each object has a code number ID.  For example, the EPSG code for a
		/// WGS84 Lat/Lon coordinate system is '4326'.
		/// </remarks>
		string Authority{get;}

		/// <summary>
		/// Code used by authority to identify transformation.
		/// </summary>
		/// <remarks>
		/// <para>The AuthorityCode is a compact string defined by an Authority to reference
		/// a particular spatial reference object.  For example, the European Survey
		/// Group (EPSG) authority uses 32 bit integers to reference coordinate systems,
		/// so all their code strings will consist of a few digits.  The EPSG code for
		/// WGS84 Lat/Lon is '4326'.</para>
		/// <para> An empty string is used for no code.</para></remarks>
		string AuthorityCode{get;}

		
		/// <summary>
		/// Gets the provider-supplied remarks.
		/// </summary>
		/// <returns></returns>
		string Remarks{get;}

		/// <summary>
		/// Human readable description of domain in source coordinate system.
		/// </summary>
		/// <returns></returns>
		string AreaOfUse{get;}

		/// <summary>
		/// Semantic type of transform.
		/// </summary>
		/// <remarks>For example, a datum transformation or a coordinate conversion.</remarks>
		TransformType TransformType{get;}

		/// <summary>
		/// Source coordinate system.
		/// </summary>
		ICoordinateSystem SourceCS{get;}

		
		/// <summary>
		/// Target coordinate system.
		/// </summary>
		ICoordinateSystem TargetCS{get;}

		/// <summary>
		/// Gets math transform.
		/// </summary>
		IMathTransform MathTransform{get;}
	}


}
