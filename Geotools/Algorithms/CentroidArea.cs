#region Using statements
using System;
using Geotools.Geometries;
#endregion
namespace Geotools.Algorithms
{


	
	/// <summary>
	/// Computes the centroid of an area geometry.
	/// </summary>
	/// <remarks>
	/// Based on the usual algorithm for calculating
	/// the centroid as a weighted sum of the centroids
	/// of a decomposition of the area into (possibly overlapping) triangles.
	/// The algorithm has been extended to handle holes and multi-polygons.
	/// See <code>http://www.faqs.org/faqs/graphics/algorithms-faq/</code>
	/// for further details of the basic approach.
	/// </remarks>
	public class CentroidArea
	{
		private CGAlgorithms _cga = new RobustCGAlgorithms();

		private Coordinate _basePt = null;// the point all triangles are based at
		private Coordinate _triangleCent3 = new Coordinate();// temporary variable to hold centroid of triangle
		private double  _areasum2 = 0;        /* Partial area sum */
		private Coordinate _cg3 = new Coordinate(); // partial centroid sum

		public CentroidArea()
		{
			_basePt = null;
		}

	

		/// <summary>
		/// Adds the area defined by a Geometry to the centroid total. If the geometry has no area it does not contribute to the centroid.
		/// </summary>
		/// <param name="geom">geom the geometry to add</param>
		public void Add(Geometry geom)
		{
			if (geom is Polygon) 
			{
				Polygon poly = (Polygon) geom;
				SetBasePoint(poly.GetCoordinates()[0]);
				Add(poly);
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
		///  Adds the area defined by an array of
		///  coordinates.  The array must be a ring;
		///  i.e. end with the same coordinate as it starts with.
		/// </summary>
		/// <param name="ring"> ring an array of {@link Coordinate}s</param>
		public void Add(CoordinateCollection ring)
		{
			SetBasePoint(ring[0]);
			AddShell(ring);
		}

		public Coordinate GetCentroid()
		{
			Coordinate cent = new Coordinate();
			cent.X = _cg3.X / 3 / _areasum2;
			cent.Y = _cg3.Y / 3 / _areasum2;
			return cent;
		}

		private void SetBasePoint(Coordinate basePt)
		{
			if (this._basePt == null)
			{
				this._basePt = basePt;
			}
		}
		private void Add(Polygon poly)
		{
			AddShell(poly.GetExteriorRing().GetCoordinates());
			for (int i = 0; i < poly.GetNumInteriorRing(); i++) 
			{
				AddHole(poly.GetInteriorRingN(i).GetCoordinates());
			}
		}
		private void AddShell(CoordinateCollection pts)
		{
			bool isPositiveArea = ! _cga.IsCCW(pts);
			for (int i = 0; i < pts.Count - 1; i++) 
			{
				AddTriangle(_basePt, pts[i], pts[i+1], isPositiveArea);
			}
		}
		private void AddHole(CoordinateCollection pts)
		{
			bool isPositiveArea = _cga.IsCCW(pts);
			for (int i = 0; i < pts.Count - 1; i++) 
			{
				AddTriangle(_basePt, pts[i], pts[i+1], isPositiveArea);
			}
		}
		private void AddTriangle(Coordinate p0, Coordinate p1, Coordinate p2, bool isPositiveArea)
		{
			double sign = (isPositiveArea) ? 1.0 : -1.0;
			Centroid3( p0, p1, p2, _triangleCent3 );
			double area2 =  Area2( p0, p1, p2 );
			_cg3.X += sign * area2 * _triangleCent3.X;
			_cg3.Y += sign * area2 * _triangleCent3.Y;
			_areasum2 += sign * area2;
		}


		/// <summary>
		/// Returns three times the centroid of the triangle p1-p2-p3.
		///  The factor of 3 is
		///  left in to permit division to be avoided until later.
		/// </summary>
		/// <param name="p1"></param>
		/// <param name="p2"></param>
		/// <param name="p3"></param>
		/// <param name="c"></param>
		private static void Centroid3( Coordinate p1, Coordinate p2, Coordinate p3, Coordinate c )
		{
			c.X = p1.X + p2.X + p3.X;
			c.Y = p1.Y + p2.Y + p3.Y;
			return;
		}

		/**
		 * Returns twice the signed area of the triangle p1-p2-p3,
		 * positive if a,b,c are oriented ccw, and negative if cw.
		 */
		private static double Area2( Coordinate p1, Coordinate p2, Coordinate p3 )
		{
			return
				(p2.X - p1.X) * (p3.Y - p1.Y) -
				(p3.X - p1.X) * (p2.Y - p1.Y);
		}


	}
}