/*
 *  Copyright (C) 2002 Urban Science Applications, Inc. (translated from Java Topology Suite, 
 *  Copyright 2001 Vivid Solutions)
 *
 *  This library is free software; you can redistribute it and/or
 *  modify it under the terms of the GNU Lesser General Public
 *  License as published by the Free Software Foundation; either
 *  version 2.1 of the License, or (at your option) any later version.
 *
 *  This library is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
 *  Lesser General Public License for more details.
 *
 *  You should have received a copy of the GNU Lesser General Public
 *  License along with this library; if not, write to the Free Software
 *  Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
 *
 */

#region Using statements
using System;
using Geotools.Geometries;
#endregion

namespace Geotools.Algorithms
{

	/// <summary>
	/// Computes a point in the interior of an area geometry.
	/// </summary>
	/// <remarks>
	/// <list type="number">
	/// <description>Find the intersections between the geometry and the horizontal bisector of the area's envelope</description>
	/// <description>Pick the midpoint of the largest intersection (the intersections will be lines and points)</description>
	/// </list>
	/// Note: If a fixed precision model is used,
	/// in some cases this method may return a point
	/// which does not lie in the interior.
	/// </remarks>
	public class InteriorPointArea 
	{

		private static double Avg(double a, double b)
		{
			return (a + b) / 2.0;
		}

		private GeometryFactory _factory;
		private Coordinate _interiorPoint = null;
		private double _maxWidth = 0.0;

		public InteriorPointArea(Geometry g)
		{
			_factory = new GeometryFactory(g.PrecisionModel, g.GetSRID());
			Add(g);
		}
		public Coordinate InteriorPoint
		{
			get
			{
				return _interiorPoint;
			}
		}

		/// <summary>
		///  Tests the interior vertices (if any)  defined by a linear Geometry for the best inside point.
		/// </summary>
		/// <remarks> If a Geometry is not of dimension 1 it is not tested.</remarks>
		/// <param name="geom">geom the geometry to add.</param>
		private void Add(Geometry geom)
		{
			if (geom is Polygon) 
			{
				AddPolygon(geom);
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
		///  Finds a reasonable point at which to label a Geometry.
		/// </summary>
		/// <param name="geometry">geometry the geometry to analyze</param>
		public void AddPolygon(Geometry geometry) 
		{
			LineString bisector = HorizontalBisector(geometry);

			Geometry intersections = bisector.Intersection(geometry);
			Geometry widestIntersection = WidestGeometry(intersections);

			double width = widestIntersection.GetEnvelopeInternal().Width;
			if (_interiorPoint == null || width > _maxWidth) 
			{
				_interiorPoint = Centre(widestIntersection.GetEnvelopeInternal());
				_maxWidth = width;
			}
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="geometry"></param>
		/// <returns>if geometry is a collection, the widest sub-geometry; otherwise, the geometry itself</returns>
		protected Geometry WidestGeometry(Geometry geometry) 
		{
			if (!(geometry is GeometryCollection)) 
			{
				return geometry;
			}
			return WidestGeometry((GeometryCollection) geometry);
		}

		private Geometry WidestGeometry(GeometryCollection gc) 
		{
			if (gc.IsEmpty()) 
			{
				return gc;
			}

			Geometry widestGeometry = gc.GetGeometryN(0);
			for (int i = 1; i < gc.GetNumGeometries(); i++) 
			{ //Start at 1
				if (gc[i].GetEnvelopeInternal().Width >
					widestGeometry.GetEnvelopeInternal().Width) 
				{
					widestGeometry = gc[i];
				}
			}
			return widestGeometry;
		}

		protected LineString HorizontalBisector(Geometry geometry) 
		{
			Envelope envelope = geometry.GetEnvelopeInternal();

			// Assert: for areas, minx <> maxx
			double avgY = Avg(envelope.MinimumY, envelope.MaximumY);

			CoordinateCollection coords = new CoordinateCollection();
			coords.Add(	 new Coordinate(envelope.MinimumX, avgY) );
			coords.Add(  new Coordinate(envelope.MinimumX, avgY) );
															
			return _factory.CreateLineString(coords);
		
		}

		/// <summary>
		/// Returns the centre point of the envelope.
		/// </summary>
		/// <param name="envelope"> envelope the envelope to analyze.</param>
		/// <returns> the centre of the envelope.</returns>
		public Coordinate Centre(Envelope envelope) 
		{
			/*return new Coordinate(avg(envelope.getMinX(),
				envelope.getMaxX()),
				avg(envelope.getMinY(), envelope.getMaxY()));*/
			return new Coordinate(Avg(envelope.MinimumX, envelope.MaximumX), Avg(envelope.MinimumY, envelope.MinimumY));
		}

	}
}