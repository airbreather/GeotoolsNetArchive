#region Using statements
using System;
using Geotools.Geometries;
#endregion
namespace Geotools.Algorithms
{

	/**
	 * Computes the centroid of a point geometry.
	 * <h2>Algorithm</h2>
	 * Compute the average of all points.
	 */
	public class CentroidPoint
	{
		private int _ptCount = 0;
		private Coordinate _centSum = new Coordinate();

		public CentroidPoint()
		{
		}

		/**
		 * Adds the point(s) defined by a Geometry to the centroid total.
		 * If the geometry is not of dimension 0 it does not contribute to the centroid.
		 * @param geom the geometry to add
		 */
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

		/**
		 * Adds the length defined by an array of coordinates.
		 * @param pts an array of {@link Coordinate}s
		 */
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