
#region Using statements
using System;
using Geotools.Geometries;
#endregion

namespace Geotools.Algorithms
{
	/// <summary>
	///  Computes a point in the interior of an point geometry.
	/// </summary>
	public class InteriorPointPoint
	{

		private Coordinate _centroid;
		private double _minDistance = double.MaxValue;

		private Coordinate _interiorPoint = null;

		public InteriorPointPoint(Geometry g)
		{
			_centroid = g.GetCentroid().GetCoordinate();
			Add(g);
		}


		/// <summary>
		/// Tests the point(s) defined by a Geometry for the best inside point.
		/// If a Geometry is not of dimension 0 it is not tested.
		/// </summary>
		/// <param name="geom">geom the geometry to add</param>
		private void Add(Geometry geom)
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
		private void Add(Coordinate point)
		{
			double dist = point.Distance(_centroid);
			if (dist < _minDistance) 
			{
				_interiorPoint = new Coordinate(point);
				_minDistance = dist;
			}
		}

		public Coordinate InteriorPoint
		{
			get
			{
				return _interiorPoint;
			}
		}
	}
}