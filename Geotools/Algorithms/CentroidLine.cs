#region Using statements
using System;
using Geotools.Geometries;
#endregion
namespace Geotools.Algorithms
{


	/**
	 * Computes the centroid of a linear geometry.
	 * <h2>Algorithm</h2>
	 * Compute the average of the midpoints
	 * of all line segments weighted by the segment length.
	 */
	public class CentroidLine
	{
		private Coordinate _centSum = new Coordinate();
		private double _totalLength = 0.0;

		public CentroidLine()
		{
		}

		/**
		 * Adds the linestring(s) defined by a Geometry to the centroid total.
		 * If the geometry is not linear it does not contribute to the centroid
		 * @param geom the geometry to add
		 */
		public void Add(Geometry geom)
		{
			if (geom is LineString) 
			{
				Add(geom.GetCoordinates());
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
		public void Add(CoordinateCollection pts)
		{
			for (int i = 0; i < pts.Count - 1; i++) 
			{
				double segmentLen = pts[i].Distance(pts[i + 1]);
				_totalLength += segmentLen;

				double midx = (pts[i].X + pts[i + 1].X) / 2;
				_centSum.X += segmentLen * midx;
				double midy = (pts[i].Y + pts[i + 1].Y) / 2;
				_centSum.Y += segmentLen * midy;
			}
		}

		public Coordinate GetCentroid()
		{
			Coordinate cent = new Coordinate();
			cent.X = _centSum.X / _totalLength;
			cent.Y = _centSum.Y / _totalLength;
			return cent;
		}

	}
}