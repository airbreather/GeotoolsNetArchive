using System;
using Geotools.Positioning;
using Geotools.CoordinateReferenceSystems;

namespace Geotools.CoordinateTransformations
{


	/// <summary>
	/// Abstract class from which transformation can inherit from to get default functionality.
	/// </summary>
	internal abstract class MathTransform : IMathTransform
	{
		/// <summary>
		/// Initializes a new instance of the AbstractMathTransform class.
		/// </summary>
		public MathTransform() 
		{
		}
		
		/// <summary>
		/// Initializes a new instance of the AbstractMathTransform class.
		/// </summary>
		/// <param name="remarks">Remarks about this object.</param>
		/// <param name="authority">The name of the authority.</param>
		/// <param name="authorityCode">The code the authority uses to identidy this object.</param>
		/// <param name="name">The name of the object.</param>
		/// <param name="alias">The alias of the object.</param>
		/// <param name="abbreviation">The abbreviated name of this object.</param>
		public MathTransform(string remarks,string authority, string authorityCode,
			string name,string alias,string abbreviation )
		{
		}

		#region Implementation of IMathTransform
		/// <summary>
		/// Not implemented.
		/// </summary>
		/// <param name="Ord"></param>
		/// <returns></returns>
		public double[]GetCodomainConvexHull(double[] Ord)
		{
			throw new NotImplementedException();
		}

		

		/// <summary>
		/// Not implemented.
		/// </summary>
		/// <returns></returns>
		public bool IsIdentity()
		{
			throw new NotImplementedException();
		}


		/// <summary>
		/// Not implemented.
		/// </summary>
		/// <param name="Ord"></param>
		/// <returns></returns>
		public DomainFlags GetDomainFlags(double[] Ord)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		///  Not implemented.
		/// </summary>
		/// <param name="Cp"></param>
		/// <returns></returns>
		public Matrix Derivative(CoordinatePoint Cp)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Not implemented.
		/// </summary>
		/// <param name="Cp"></param>
		/// <returns></returns>
		public virtual CoordinatePoint Transform(CoordinatePoint Cp)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		///  Not implemented.
		/// </summary>
		/// <param name="Ord"></param>
		/// <returns></returns>
		public virtual double[] TransformList(double[] Ord)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		///  Not implemented.
		/// </summary>
		public int GetDimTarget()
		{
			throw new NotImplementedException();
		}


		/// <summary>
		///  Not implemented.
		/// </summary>
		public int DimSource
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public virtual IMathTransform GetInverse()
		{
			throw new NotImplementedException();
		}

		public string WKT
		{
			get
			{
				throw new NotImplementedException();
			}
		}
		public string XML
		{
			get
			{
				throw new NotImplementedException();
			}
		}
		#endregion
	}
	
}
