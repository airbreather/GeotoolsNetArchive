using System;
using Geotools.CoordinateTransformations;

namespace Geotools.CoordinateReferenceSystems
{
	/// <summary>
	/// A projection from geographic coordinates to projected coordinates.
	/// </summary>
	public class Projection : AbstractInformation, IProjection
	{
		//ParameterList _parameters;
		string _classication;
		ProjectionParameter[] _projectionParameters;

		#region Constructors
		
		/// <summary>
		/// Initializes a new instance of the Projection class.
		/// </summary>
		internal Projection(string name, ProjectionParameter[] projectionParameters, string classification, string remarks, string authority, string authorityCode)
			: base(remarks,authority,authorityCode,name,"","")
		{
			_projectionParameters = projectionParameters;
			_classication = classification;
		}
		#endregion

		#region Implementation of IProjection
		/// <summary>
		/// Gets the parameters for this projection.
		/// </summary>
		/// <param name="index">The index of the parameter to return.</param>
		/// <returns>IProjectionParameter containing the parameter information.</returns>
		public ProjectionParameter GetParameter(int index)
		{
			return _projectionParameters[index];
		}

		
		/// <summary>
		/// The number of parameters for this projection.
		/// </summary>
		public int NumParameters
		{
			get
			{
				return _projectionParameters.Length;
			}
		}

	
		/// <summary>
		/// Gets the class name for this projection.
		/// </summary>
		public string ClassName
		{
			get
			{
				return _classication;
			}
		}

		#endregion
	}
}
