#region Using statements
using System;
using Geotools.Geometries;
#endregion
namespace Geotools.Algorithms
{

	/// <summary>
	/// Computes the centroid of a point geometry.
	/// </summary>
	/// <remarks>
	///  Compute the average of all points.
	/// </remarks>
	public class CentroidPoint
	{
		private int _ptCount = 0;
		private Coordinate _centSum = new Coordinate();

		public CentroidPoint()
		{
		}


		/// <summary>
		/// Adds the point(s) defined by a Geometry to the centroid total.
		/// </summary>
		/// <remarks>
		/// If the geometry is not of dimension 0 it does not contribute to the centroid.
		/// </remarks>
		/// <param name="geom">geom the geometry to add.</param>
		public void Add(Geometry geom)
		{
			if (geom is Point) 
			{
				Add(geom.GetCoordinate());
			}
			else if (geom is GeometryCollection) 
			{
				GeometryCollection gc = (GeometryCollection) geom;
				for (int i = 0; i < gc.GetNumGeometries(); i++) 
				{
					Add(gc[i]);
				}
			}
		}

		/// <summary>
		/// Adds the length defined by an array of coordinates.
		/// </summary>
		/// <param name="pt">pts an array of {@link Coordinate}s</param>
		public void Add(Coordinate pt)
		{
			_ptCount += 1;
			_centSum.X += pt.X;
			_centSum.Y += pt.Y;
		}

		public Coordinate GetCentroid()
		{
			Coordinate cent = new Coordinate();
			cent.X = _centSum.X / _ptCount;
			cent.Y = _centSum.Y / _ptCount;
			return cent;
		}

	}
}