#region Using statements
using System;
using Geotools.Geometries;
#endregion
namespace Geotools.Algorithms
{
	/// <summary>
	/// Computes a point in the interior of an linear geometry.
	/// </summary>
	/// <remarks>
	/// <para>1. Find an interior vertex which is closest to the centroid of the linestring.</para>
	/// <para>2. If there is no interior vertex, find the endpoint which is closest to the centroid.</para>
	/// </remarks>
	public class InteriorPointLine 
	{

		private Coordinate _centroid;
		private double _minDistance = double.MaxValue;

		private Coordinate _interiorPoint = null;

		public InteriorPointLine(Geometry g)
		{
			_centroid = g.GetCentroid().GetCoordinate();
			AddInterior(g);
			if (_interiorPoint == null)
			{
				AddEndpoints(g);
			}
		}

		public Coordinate InteriorPoint
		{
			get
			{
				return _interiorPoint;
			}
		}

		/// <summary>
		/// Tests the interior vertices (if any) defined by a linear Geometry for the best inside point.
		/// </summary>
		/// <remarks>If a Geometry is not of dimension 1 it is not tested.</remarks>
		/// <param name="geom">geom the geometry to add.</param>
		private void AddInterior(Geometry geom)
		{
			if (geom is LineString) 
			{
				AddInterior(geom.GetCoordinates());
			}
			else if (geom is GeometryCollection) 
			{
				GeometryCollection gc = (GeometryCollection) geom;
				for (int i = 0; i < gc.GetNumGeometries(); i++) 
				{
					AddInterior(gc[i]);
				}
			}
		}
		private void AddInterior(CoordinateCollection pts)
		{
			for (int i = 1; i < pts.Count - 1; i++) 
			{
				Add(pts[i]);
			}
		}

		/// <summary>
		/// Tests the endpoint vertices defined by a linear Geometry for the best inside point.
		/// </summary>
		/// <remarks>
		/// If a Geometry is not of dimension 1 it is not tested.
		/// </remarks>
		/// <param name="geom">geom the geometry to add.</param>
		private void AddEndpoints(Geometry geom)
		{
			if (geom is LineString) 
			{
				AddEndpoints(geom.GetCoordinates());
			}
			else if (geom is GeometryCollection) 
			{
				GeometryCollection gc = (GeometryCollection) geom;
				for (int i = 0; i < gc.GetNumGeometries(); i++) 
				{
					AddEndpoints(gc[i]);
				}
			}
		}
		private void AddEndpoints(CoordinateCollection pts)
		{
			Add(pts[0]);
			Add(pts[pts.Count - 1]);
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


	}
}
